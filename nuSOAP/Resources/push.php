<?php
class push {

		// General push wrapper. Uses database to obtain unique token and to determine device type
        public static function notify($type, $token, $message, $data) {
                $return = false;
				switch($type) {
						case 0: // android
								$return = push::gcm(
										$token,
										$message,
										$data
								);
								break;

						case 1: // ios
								$return = push::apns(
										$token,
										$message,
										$data
								);
								break;

						case 2: // blackberry
								$return = push::bb(
										$token,
										$message,
										$data
								);
								break;

						case 3: // windows phone
								$return = push::wp(
										$token,
										$message,
										$data
								);
								break;

						case 4: // windows device
								$return = push::wd(
										$token,
										$message,
										$data
								);
								break;
				}
				return $return;
        }

		// Apple Push Notification Service
        public static function apns($token, $message, $data) {
			$return = false;
			$payload = '';
				
			$debug_msg = "No Errors";
			
			$ctx = stream_context_create();
			stream_context_set_option($ctx, 'ssl', 'local_cert', PUSH_APNS_CERTIFICATE);
			stream_context_set_option($ctx, 'ssl', 'passphrase', PUSH_APNS_CERTIFICATE_PASSPHRASE);
			$fp = stream_socket_client(PUSH_APNS_SERVER,
				$err,
				$errstr,
				60,
				STREAM_CLIENT_CONNECT|STREAM_CLIENT_PERSISTENT,
				$ctx);

			if (!$fp) {
				$debug_msg = "Failed to connect $err $errstr";
			} else {
				// Create the payload body
				$body['aps'] = array(
					'badge' => 1
					,'alert' => $message
					,'sound' => PUSH_ALERT_SOUND
				);
				$body['msg'] = $data;
				

				$payload = json_encode($body);

				// Build the binary notification
				$msg = chr(0) . pack('n', 32) . pack('H*', str_replace(' ', '', $token)) . pack('n', strlen($payload)) . $payload;

				// Send it to the server
				$result = fwrite($fp, $msg, strlen($msg));

				if (!$result) {
					$debug_msg = "Message not delivered";
				} else {
					$apple_error = "";
					// echo 'Message successfully delivered amar'.$message. PHP_EOL;
					$debug_msg = "Packet Delivered to APNS of " . var_export($result, true) . " bytes.";
					if($apple_error <> "") {
						$debug_msg .= '<br />Error: ' . var_export($apple_error, true);
					} else {
						$debug_msg .= '<br />No Errors from Apple';
					}

					$return = true;
				}
				
			}

			// Close the connection to the server
			fclose($fp);

			if(DEBUG == true) {
				$debug_msg = 'Token - ' . $token . '<br />Data - ' . $data . '<br />Payload - ' . $payload . '<br />' . $debug_msg;
				echo $debug_msg;
			}
	
			return $return;
        }

		// Google Cloud Messaging
        public static function gcm($token, $message, $data) {
			$return = false;
		
			$debug_msg = "No Errors";
		
			// Set POST variables
			$payload = json_encode(
							array(
								'registration_ids' => $token,
								'data' => $message,
								'msg' => $data,
								'dry_run' => PUSH_GCM_SANDBOX
							)
					);
			
			// GCM Authentication
			$headers = array(
				'Authorization: key=' . PUSH_GCM_KEY,
				'Content-Type: application/json'
			);
			
			// Open connection
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_URL, PUSH_GCM_SERVER);
			curl_setopt($ch, CURLOPT_POST, true);
			curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	 
			// Disabling SSL Certificate support temporarly
			curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
			curl_setopt($ch, CURLOPT_POSTFIELDS, $payload);
	 
			// Execute post
			$result = curl_exec($ch);
			
			if ($result === false) {
				$debug_msg = 'Curl failed: ' . curl_error($ch);
			} else {
				$return = true;
			}
			
			// Close connection
			curl_close($ch);

			if(DEBUG == true) {
				$debug_msg = 'Token - ' . $token . '<br />Data - ' . $data . '<br />Payload - ' . $payload . '<br />' . $debug_msg;
				echo $debug_msg;
			}

			return $return;
        }
		
		// Blackberry
        public static function bb($token, $message, $data) {
			return false;
        }
		
		// Windows Phone
        public static function wp($token, $message, $data) {
			return false;
        }
		
		// Windows Device
        public static function wd($token, $message, $data) {
			return false;
        }
		
		
		public static function notify_ua($type, $token, $message, $data) {
			// 0 = android
			// 1 = ios
			// 2 = blackberry
			// 3 = windows phone
			// 4 = windows device

			$device_param = null;
			$audience = Array();
			$notification = Array();
			$devices = Array();

			switch($type) {
					case 0: // android
							$device_param = "apid";
							$device = "android";
							break;
					case 1: // ios
							$device_param = "device_token";
							$device = "ios";
							break;
					case 2: // blackberry
							$device_param = "device_pin";
							$device = "blackberry";
							break;
					case 3: // windows phone
							$device_param = "mpns";
							$device = "windows";
							break;
					case 4: // windows device
							$device_param = "wns";
							$device = "windows";
							break;
			}

			$audience = Array($device_param=>$token);
			if($message !== null) { $notification['alert'] = $message; }
			if($data !== null) { $notification['extra'] = Array("msg"=>$data); }
			if($device == 'ios') {
				$notification['sound'] = PUSH_UA_SOUND;
				$notification['badge'] = '+1';
			}

			$devices = Array( $device );

			$array = Array(
								"audience"=>$audience,
								"notification"=>Array(
														$device=>$notification
													),
								"device_types"=>$devices
							);

			$json = json_encode($array);

			$session = curl_init(PUSH_UA_SERVER);
			curl_setopt($session, CURLOPT_USERPWD, PUSH_UA_APP_KEY . ':' . PUSH_UA_APP_SECRET);
			curl_setopt($session, CURLOPT_POST, True);
			curl_setopt($session, CURLOPT_POSTFIELDS, $json);
			curl_setopt($session, CURLOPT_HEADER, False);
			curl_setopt($session, CURLOPT_RETURNTRANSFER, True);
			curl_setopt($session, CURLOPT_HTTPHEADER, array('Content-Type:application/json', 'Accept: application/vnd.urbanairship+json; version=3;'));
			$content = curl_exec($session);
			$response = curl_getinfo($session);

			if($response['http_code'] != 202) {
					return false; //$response['http_code'];
			} else {
					return true;
			}
		}

}
