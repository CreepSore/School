<?php
    require_once('dbconf.php');
    require_once('dbapi.php');

    class Utils {
        public static $dbcon = null;

        public static function GetDbCon() {
            return self::$dbcon !== null ? self::$dbcon : self::$dbcon = new DbCon(DbConfig::CreateDefault());
        }

        public static function AddAction($codeType, $actionParameter, $action, $vsId) {
            $dbcon = self::GetDbCon();
            $id = self::GetNextId('ActionCode', 'id');
            $code = self::GenerateActionCode($codeType);
            $execQuery = "insert into `ActionCode`(`id`, `codeType`, `code`, `actionParameter`, `creationDate`, `action`, `veranstalterId`) values($id, '$codeType', '$code', '$actionParameter', sysdate(), '$action', $vsId)";
            $execState = $dbcon->DoExec($execQuery);
            return $execState ? $code : false;
        }

        public static function GenerateActionCode($codeType) {
            $dbcon = self::GetDbCon();
            $codeExists = function($code, $dbcon) {
                $query = $dbcon->DoQuery("select * from `ActionCode` where code='$code'");
                return $query && $query->fetch();
            };
            
            switch($codeType) {
                case 'URL': 
                    $code = '';
                    do {
                        $code = self::RandomString(32, true);
                    } while($codeExists($code, $dbcon));
                    return $code;
                    break;

                case 'ONETIME':
                    $code = '';
                    do {
                        $code = self::RandomString(6);
                    } while($codeExists($code, $dbcon));
                    return $code;
                    break;

                default:
                    return false;
                    break;
            }
        }

        public static function GetNextId(string $tableName, string $idColumnName) {
            $dbcon = self::GetDbCon();
            $query = "select * from (select `$idColumnName` from `$tableName` order by `$idColumnName` desc) as `limiter` limit 1";

            $queryResult = $dbcon->DoQuery($query);
            if(!$queryResult) {
                echo "[GetNextId] Query failed! QUERY: $query";
                return false;
            }

            $fetchResult = $queryResult->fetch(PDO::FETCH_ASSOC);
            return ($fetchResult ? $fetchResult[$idColumnName] + 1 : 1);
        }

        public static function RandomString(int $length, $useLowercase = false) {
            $usedChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
            if($useLowercase) {
                $usedChars .= strtolower($usedChars);
            }
            $usedChars .= '1234567890';

            $chars = str_split($usedChars);
            $result = "";
            for($i = 0; $i < $length; $i++) {
                $result = $result . $chars[array_rand($chars)];
            }
            return $result;
        }
    }
?>