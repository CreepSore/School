<?php
    require_once('dbconf.php');
    
    class DbCon {
        private $host     = '';
        private $port     = 3306;
        private $db       = '';
        private $username = '';
        private $password = '';

        private $pdo = null;

        public function __construct($host, $port = null, $username = null, $password = null, $db = null) {
            if($host !== null && $port !== null && $username !== null && $password !== null && $db !== null) {
                $this->host     = $host;
                $this->port     = $port;
                $this->username = $username;
                $this->password = $password;
                $this->db       = $db;
            } else if ($host !== null) {
                $this->host = $host->host;
                $this->port = $host->port;
                $this->db = $host->db;
                $this->username = $host->username;
                $this->password = $host->password;
            }
        }

        private function __clone() { }

        public function DoQuery(string $query) {
            if($this->pdo === null) {
                $this->pdo = new PDO("mysql:host=$this->host;dbname=$this->db", $this->username, $this->password);
            }
            return $this->pdo->query($query);
        }

        public function DoExec(string $execQuery) {
            if($this->pdo === null) {
                $this->pdo = new PDO("mysql:host=$this->host;dbname=$this->db", $this->username, $this->password);
            }
            $result = $this->pdo->exec($execQuery);

            return $this->pdo->errorInfo();
        }

        public function GetLastError() {
            return $this->pdo->errorInfo();
        }
    }
?>