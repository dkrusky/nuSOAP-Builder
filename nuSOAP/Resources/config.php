<?php
	define('DEBUG',									false);

/*****************************
	SOAP
******************************/
	define('SOAP_SERVICE_NAME',						'');

/*****************************
	DATABASE
******************************/
	define('DB_HOST',								'127.0.0.1');
	define('DB_NAME',								'');
	define('DB_PREFIX',								'my_');
	define('DB_USER',								'root');
	define('DB_PASS',								'');

/*****************************
	URBAN AIRSHIP
	Push services (iOS, Android, Blackberry, Windows)
******************************/
	define('PUSH_UA_SERVER',						'https://go.urbanairship.com/api/push/');
	define('PUSH_UA_APP_KEY',						'');
	define('PUSH_UA_APP_SECRET',					'');
	define('PUSH_UA_SOUND',							'');
	
/*****************************
	ANDROID PUSH
******************************/
	define('PUSH_GCM_SANDBOX',						false);
	if(PUSH_GCM_SANDBOX) {
		// Sandbox
		define('PUSH_GCM_KEY',						'');
		define('PUSH_GCM_SERVER',					'https://android.googleapis.com/gcm/send');
		define('PUSH_GCM_SOUND',					'');
	} else {
		// Live
		define('PUSH_GCM_KEY',						'');
		define('PUSH_GCM_SERVER',					'https://android.googleapis.com/gcm/send');
		define('PUSH_GCM_SOUND',					'');
	}

/*****************************
	APPLE PUSH
******************************/
	define('PUSH_APNS_SANDBOX',						false);
	if(PUSH_APNS_SANDBOX) {
		// Sandbox
		define('PUSH_APNS_SERVER',					'ssl://gateway.sandbox.push.apple.com:2195');
		define('PUSH_APNS_CERTIFICATE',				'');
		define('PUSH_APNS_CERTIFICATE_PASSPHRASE',	'');
		define('PUSH_APNS_SOUND',					'');
	} else {
		// Live
		define('PUSH_APNS_SERVER',					'ssl://gateway.push.apple.com:2195');
		define('PUSH_APNS_CERTIFICATE',				'');
		define('PUSH_APNS_CERTIFICATE_PASSPHRASE',	'');
		define('PUSH_APNS_SOUND',					'');
	}
	