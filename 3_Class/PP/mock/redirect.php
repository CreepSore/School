Redirecting in 3 seconds ...

<?php
    $redirection = "/index.php";
    if(isset($_GET['url'])) {
        $redirection = $_GET['url'];
    }

    sleep(3);
    header("Location: $redirection");
    die();
?>