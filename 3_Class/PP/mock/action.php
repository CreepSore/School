<?php
    require_once('dbconf.php');
    require_once('dbapi.php');

    // Kill Script if no code has been specified
    if(!isset($_GET['code'])) {
        header('Location: /index.php');
        die();
    }

    $code = $_GET['code'];
    $dbCon = new DbCon(DbConfig::CreateDefault());
    $res = $dbCon->DoQuery("select * from ActionCode where code='$code' and codeType='URL'");
    
    $actiondata = $res->fetch(PDO::FETCH_ASSOC);

    if(!$actiondata) {
        header('Location: /index.php');
        die();
    }

    switch($actiondata['action']) {
        case 'HREF':
            $param = $actiondata['actionParameter'];
            header("Location: $param");
            break;

        default: 
            header('Location: /index.php');
            break;
    }
?>