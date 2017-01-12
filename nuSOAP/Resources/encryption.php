<?php
function API_VERIFY_AUTHLEVEL($API_PUBLIC_KEY, $API_VERIFY, $AUTHLEVEL) {
	$verify = false;
	try {
		$sql = 'SELECT `API_PRIVATE_KEY` FROM `' . DB_PREFIX . 'api` WHERE `API_PUBLIC_KEY` = :API_PUBLIC_KEY AND `AUTHLEVEL` <= :AUTHLEVEL LIMIT 1'; 
		$db = new Database();
		$db->query($sql);
		$db->bind( ":API_PUBLIC_KEY", $API_PUBLIC_KEY );
		$db->bind( ":AUTHLEVEL", $AUTHLEVEL );
		if($row = $db->single()) {
			$API_PRIVATE_KEY = $row['API_PRIVATE_KEY'];
			$tdes = new TripleDES($API_PRIVATE_KEY);
			$decrypted = $tdes->Decrypt($API_VERIFY, $API_PRIVATE_KEY);
			if (strpos($decrypted, ':valid:') !== FALSE) {
				$verify = true;
			}
		}
		$db = null;
	} catch (Exception $e) {
			// just trap error and do nothing
	}
	return $verify;
}

class TripleDES {
	private $bPassword;
	private $sPassword;
	
	function __construct($Password = "") {
		if($Password == "") {
			$Password = "password";
		}
		$this->bPassword  = md5(utf8_encode($Password),TRUE);
		$this->bPassword .= substr($this->bPassword,0,8);
		$this->sPassword - $Password;
	}

	function Password($Password = "") {
		if($Password == "") {
			return $this->sPassword;
		} else {
			$this->bPassword  = md5(utf8_encode($Password),TRUE);
			$this->bPassword .= substr($this->bPassword,0,8);
			$this->sPassword - $Password;
		}
	}

	function PasswordHash() {
		return $this->bPassword;
	}
	
	function Encrypt($Message, $Password = "") {
		if($Password <> "") { $this->Password($Password); }
		$size=mcrypt_get_block_size('tripledes','ecb');
		$padding=$size-((strlen($Message)) % $size);
		$Message .= str_repeat(chr($padding),$padding);
		$encrypt  = mcrypt_encrypt('tripledes',$this->bPassword,$Message,'ecb');   
		return base64_encode($encrypt);
	}

	function Decrypt($message, $Password = "") {
		if($Password <> "") { $this->Password($Password); }
		return mcrypt_decrypt('tripledes', $this->bPassword, base64_decode($message), 'ecb');
	}

}