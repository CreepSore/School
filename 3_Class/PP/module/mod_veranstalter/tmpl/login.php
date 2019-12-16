<?php
    /* File: login.php
     * Author: Himmelbauer Eric
     * 
     * Creation-Date: 22.10.2019
     * Latest Change: 29.10.2019, Himmelbauer Eric
     *
     * Description:
     *   Implements Login-Functionality via PHP Sessions, so editing and adding Events per "add_or_update.php" is possible.
     *   Showing an error message is also possible by using the "errormsg" and "errortype" GET-Parameters.
     * 
     * GET-Parameters:
     *   - errormsg
     *     - The message you want to display inside the Alert-Box
     *     - Leaving this blank will hide the Alert-Box
     *   - errortype
     *     - Optional
     *     - The type of Alert you want to display (look up Bootstrap Alerts for reference)
     *     - Default = "danger"
     * 
     * Session-Parameters:
     *   - IN:
     *     //// NONE ////
     *   - OUT:
     *     //// NONE (yet) ////
     * 
     * To Do:
     *   1) Create Session and save organizer-id and edit-action into $_SESSION as "orga_id" and "action" accordingly
     * 
     */

    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_mail.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_actioncode.php');

    $error = '';
    $errortype = 'danger';

    if(isset($_GET['errormsg'])) {
        $error = $_GET['errormsg'];
        if(isset($_GET['errortype'])) {
            $errortype = $_GET['errortype'];
        }
    }
    
    
    if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['login-submit'])) {
        $tocheck = ['password' => "das Passwort"];
        $notset = [];
        foreach(array_keys($tocheck) as $check) {
            if(!isset($_POST[$check])) {
                $notset[] = $check;
            }
        }

        if(sizeof($notset) === 0) {
            $code = GGN_Utils::FetchActionCode($_POST['password']);

            if($code) {
                header('Location: ?page=add_or_update');
                die();
            } else {
                $error = "Das Passwort '{$_POST['password']}' ist ungültig!";
            }
        } else {
            $key = $notset[0];
            $error = "Es wurde {$tocheck[$key]} nicht gesetzt!";
        }
    }
?>

<div class="container">
    <div class="jumbotron" style="background-color: transparent; display: flex; justify-content: center; min-width: 400px;">
        <div class="card" style="max-width: 500px; flex-grow: 1;">
            <div class="card-header">
                <h3>Login</h3>
            </div>

            <div class="card-body">
                <div class="alert alert-<?php echo($errortype) ?>" role="alert" <?php echo(!$error ? 'hidden' : ''); ?>>
                    <?php
                    echo($error);
                    ?>
                </div>

                <form class="form-group" method="POST">
                    <input name="password" type="text" class="form-control" placeholder="XXXXXX" style="text-align: center;" required/>
                    <input name="login-submit" type="submit" class="form-control btn btn-info" value="Login" />
                </form>
            </div>
        </div>
    </div>
</div>
