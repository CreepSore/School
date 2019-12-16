<?php
  ini_set('display_errors', 1);
  ini_set('display_startup_errors', 1);
  error_reporting(E_ALL);
  require_once('dbapi.php');
  require_once('utils.php');
?>

<html>
  <head>
    <title>Test Sandbox PP-2019</title>
    <style>
        * {
            font-family: Arial;
        }
    </style>
  </head>

  <body>
    <form method="POST">
      <input type="submit" value="QueryTest" name="test-select-query" />
    </form>
    <br />
    <form method="POST">
        <input type="submit" value="Create new Link" name="test-add-action"/>
        <?php
            if(isset($_POST['test-add-action'])) {
                $code = Utils::AddAction('URL', '/redirect.php?url=/index.php', 'HREF', 0);
                echo("<a href=\"/action.php?code=$code\">ADDED LINK</a>");
            }
        ?>
    </form>

    <?php
        $code = Utils::GenerateActionCode('URL');
        echo "URL ActionCode: $code <br />";

        $code = Utils::GenerateActionCode('ONETIME');
        echo "One-Time ActionCode: $code <br />";
    ?>

    <?php
      if(isset($_POST["test-select-query"])) {
        require_once('dbconf.php');
        $dbCfg = DbConfig::CreateDefault();
        $dbCon = new DbCon($dbCfg);
        $res = $dbCon->DoQuery("select * from Veranstalter");

        foreach($res as $row) {
          echo($row['id'] . ' ' . $row['name'] . ' ' . $row['email'] . '<br />');
        }
      }
    ?>
  </body>
</html>
