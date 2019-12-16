<?php
    /* File: request.php
     * Author: Himmelbauer Eric
     * 
     * Creation-Date: 22.10.2019
     * Latest Change: 22.10.2019, Himmelbauer Eric
     *
     * Description:
     *   Implements Front-/ and Backend-Logic for debugging purposes.
     *   With this View you are able to request an e-mail with an ActionCode, which you can use to Login into "login.php"
     *
     * To Do:
     *   1) This File should be deleted if no further testing is required.
     * 
     */

    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_mail.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_actioncode.php');

    if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['request-submit'])) {
        $tocheck = ['orga-name' => "der Organisationsname", 'orga-mail' => 'die Email'];
        $notset = [];
        foreach(array_keys($tocheck) as $check) {
            if(!isset($_POST[$check])) {
                $notset[] = $check;
            }
        }

        if(sizeof($notset) === 0) { 
            $mailerror = "";
            $code = GGN_UtilsActionCode::AddAction('ONETIME', $_POST['orga-mail'], 'REGISTER_ORG');
            GGN_UtilsMail::SendMail(
                new GGN_MailData($_POST['orga-mail'], 'Veranstaltungsanmeldung', 
                    GGN_UtilsMail::RenderTemplate(
                        GGN_Utils::ReadFileContent('./plugins/eventmanagement/plg_vamanagement/mail_templates/vereinCode.html'), 
                        array('code' => $code)
                    )
                ), 
            $mailerror);
        } else {
            $key = $notset[0];
            $error = "Es wurde {$tocheck[$key]} nicht gesetzt!";
        }
    }
?>


<div class="container">
  <div class="row">
    <div class="col-sm"></div>
    <div class="col-sm">      
        <div class="card">
            <div class="card-header">
                <h3>Anfrage</h3>
            </div>

            <div class="card-body">
                <div class="alert alert-danger" role="alert" <?php echo(!$error ? 'hidden' : ''); ?>>
                    <?php
                        echo($error);
                    ?>
                </div>

                <form class="form-group" method="POST">
                    <input name="orga-name" type="text" class="form-control" placeholder="Verein-Name" style="text-align: center;" required/>
                    <input name="orga-mail" type="text" class="form-control" placeholder="E-Mail" style="text-align: center;" required/>
                    <input name="request-submit" type="submit" class="form-control btn btn-info" value="Request" />
                </form>
            </div>
        </div>
    </div>
    <div class="col-sm"></div>
  </div>
</div>