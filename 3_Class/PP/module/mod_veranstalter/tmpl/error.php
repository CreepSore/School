<?php
    /* File: error.php
     * Author: Himmelbauer Eric
     * 
     * Creation-Date: 23.10.2019
     * Latest Change: 23.10.2019, Himmelbauer Eric
     *
     * Description:
     *   Acts as an 404-Errorpage if the View-Controller does not find any pages linked to the GET-Parameter "page".
     * 
     * GET-Parameters:
     *   - error
     *     - Mandatory
     *     - The Text you want to display
     *
     */

    $error = $_GET['error'];
?>

<div class="alert alert-danger" role="alert" <?php echo(!$error ? 'hidden' : ''); ?>>
    <?php
        echo($error);
    ?>
</div>