<?php
    class DbConfig {
        public $host;
        public $port;
        public $db;
        public $username;
        public $password;

        public function __construct($host = '', $port = 0, $db = '', $username = '', $password = '') {
            $this->host     = $host;
            $this->port     = $port;
            $this->username = $username;
            $this->password = $password;
            $this->db       = $db;
        }

        public static function CreateDefault() {
            $defHost     = 'localhost';
            $defPort     = 3306;
            $defDb       = 'pp2019';
            $defUsername = 'pp2019';
            $defPassword = 'pp2019_pwd';

            return new DbConfig($defHost, $defPort, $defDb, $defUsername, $defPassword);
        }
    }
?>