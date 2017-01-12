<?php
	// Configuration
	include('config.php');

	if(DEBUG) {
		error_reporting(E_ALL);
		ini_set('display_errors', 1);
	} else {
		error_reporting(0);
		ini_set('display_errors', 0);
	}
	
	// Helper classes
	include('lib/database.php');
	include('lib/push.php');
	include('lib/encryption.php');

	// SOAP :  INITIALIZATION
	require_once('lib/soap.php');
	
	
	$SERVICE_NAMESPACE = "urn:" . SOAP_SERVICE_NAME;
	$server = new soap_server();
	$server->configureWSDL(SOAP_SERVICE_NAME, $SERVICE_NAMESPACE);

	// PHP functions
	include('soap_functions.php');
	
	// SOAP exposure of Structures for WSDL
	include('soap_types.php');
	
	// SOAP exposure of PHP functions for WSDL
	include('soap_methods.php');

	// SOAP :  END OF SCRIPT
	$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
	if($HTTP_RAW_POST_DATA == '') { $HTTP_RAW_POST_DATA = file_get_contents('php://input'); }
	$server->service($HTTP_RAW_POST_DATA);
	
	// Force terminate PHP
	exit(0);