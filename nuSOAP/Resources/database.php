<?php

// DATABASE CLASS
class Database{
	private $stmt;

    private $host      = DB_HOST;
    private $user      = DB_USER;
    private $pass      = DB_PASS;
    private $dbname    = DB_NAME;
 
    private $dbh;
    private $error;
 
    public function __construct(){
        // Set DSN
        $dsn = 'mysql:host=' . $this->host . ';dbname=' . $this->dbname;
        // Set options
        $options = array(
            PDO::ATTR_PERSISTENT    => true,
            PDO::ATTR_ERRMODE       => PDO::ERRMODE_EXCEPTION
        );
        // Create a new PDO instanace
        try{
            $this->dbh = new PDO($dsn, $this->user, $this->pass, $options);
        }
        // Catch any errors
        catch(PDOException $e){
            $this->error = $e->getMessage();
        }
    }
	
	
	public function tableExists($id) {
		$results = $this->dbh->query("SHOW TABLES LIKE '$id'");
		if(!$results) {
			// die(print_r($dbh->errorInfo(), TRUE));
			return false;
		} else {
			if($results->rowCount()>0){
				return true;
			} else {
				return false;
			}
		}
	}

	public function run($query) {
		return $this->dbh->exec($query);
	}
	
	public function query($query){
		$this->stmt = $this->dbh->prepare($query);
	}
	
	public function bind($param, $value, $type = null){
		if (is_null($type)) {
		  switch (true) {
			case is_int($value):
			  $type = PDO::PARAM_INT;
			  break;
			case is_bool($value):
			  $type = PDO::PARAM_BOOL;
			  break;
			case is_null($value):
			  $type = PDO::PARAM_NULL;
			  break;
			default:
			  $type = PDO::PARAM_STR;
		  }
		}
		$this->stmt->bindValue($param, $value, $type);	 
	}
	
	public function execute(){
		return $this->stmt->execute();
	}
	
	public function resultset(){
		$this->execute();
		return $this->stmt->fetchAll(PDO::FETCH_ASSOC);
	}

	public function single(){
		$this->execute();
		return $this->stmt->fetch(PDO::FETCH_ASSOC);
	}

	public function rowCount(){
		return $this->stmt->rowCount();
	}
	
	public function lastInsertId(){
		return $this->dbh->lastInsertId();
	}
	
	public function beginTransaction(){
		return $this->dbh->beginTransaction();
	}

	public function endTransaction(){
		return $this->dbh->commit();
	}

	public function cancelTransaction(){
		return $this->dbh->rollBack();
	}

	public function debugDumpParams(){
		return $this->stmt->debugDumpParams();
	}
	
	public function showSQL() {
		return $this->stmt->queryString;
	}
	
	public function close() {
		$this->dbh = null;
	}

}