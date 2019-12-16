<?php
    /* File: add_or_update.php
     * Author: Himmelbauer Eric, Ruff Sebastian
     * 
     * Creation-Date: 22.10.2019
     * Latest Change: 29.10.2019, Himmelbauer Eric
     *
     * Description:
     *   Implements Front-/ and Backend-Logic to Add or Edit events.
     *   If the user is not logged in, he will be redirected to the "login.php" page, where an error message will be displayed.
     * 
     * Session-Parameters:
     *   - IN:
     *     - orga_id:
     *       - Stores the DB-Id of the organizer that logged in on "login.php"
     *     - action:
     *       - Stores the Type of the ActionCode that was used to Login on "login.php"
     *       - Can be either "ADD" or "EDIT"
     *   - OUT:
     *     //// NONE ////
     * 
     * To Do:
     *   1) Implement Database-Loading Logic
     *   2) Implement Database-Synchronization Logic
     *
     */

    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_mail.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_actioncode.php');
    
    session_start();
    if(!isset($_SESSION['orga_id']) || !isset($_SESSION['action'])) {
        session_destroy();
        header('Location: ?page=login&errormsg=Bitte loggen sie sich ein bevor sie eine Veranstaltung hinzufügen oder editieren!&errortype=danger');
        die();
    }

    $orgaId = $_SESSION['orga_id'];
    $action = $_SESSION['action'];

    $view;
    if($action === 'edit') {
        if(!isset($_SESSION['event_id'])) {
            session_destroy();
            header("Location: ?page=error&error=Keine Event-Id zum Bearbeiten gefunden.");
            die();
        }

        $eventId = $_SESSION['event_id'];
        
        $db = JFactory::getDbo();
        $query = $db->getQuery(true);
                
        $query
            ->select('*')
            ->from($db->quoteName('ggn_event', 'event'))
            ->join('INNER', $db->quoteName('ggn_participant') . ' using(' . $db->quoteName('UserId') . ')')
            ->join('INNER', $db->quoteName('ggn_event') . ' using(' . $db->quoteName('EventId') . ')')
            ->where($db->quoteName('EventId') . ' = '. $db->quote($eventId));
            
        $db->setQuery($query);
        $result = $db->loadObjectList();

        var_dump($result);

        $view = array(
            
        );
    }

    $error = '';

    if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['update-submit'])) {
        
    }
?>

<div class="container">
  <div class="jumbotron" style="background-color: transparent; display: flex; justify-content: center; min-width: 400px;">
    <div class="card" style="max-width: 500px; flex-grow: 1;">
        <div class="card-header">
            <h3 style="font-size: 21px; text-align: center;">Veranstaltung anmelden</h3>
        </div>

        <div class="card-body">
            <div class="alert alert-danger" role="alert" <?php echo(!$error ? 'hidden' : ''); ?>>
                <?php
                    echo($error);
                ?>
            </div>
            <form class="form-group" method="POST" id="edit-form">
                <label for="name-input">Name:</label>
                <input name="name-input" id="name-input" type="text" class="form-control" placeholder="Veranstaltungsname" style="text-align: center;" required />
                
                <label for="date-start-input">Startdatum:</label>
                <div style="display: flex; justify-content: center;">
                    <input name="date-start-input" id="date-start-input" type="date" class="form-control" style="text-align: center; flex-grow: 1;" required/>
                    <input name="date-time-start-input" id="date-time-start-input" type="time" class="form-control" style="flex-shrink: 3; min-width: 80px;" required/>
                </div>

                <label for="date-end-input">Enddatum:</label>
                <div style="display: flex; justify-content: center;">
                    <input name="date-end-input" id="date-end-input" type="date" class="form-control" style="text-align: center; flex-grow: 1;" required/>
                    <input name="date-time-end-input" id="date-time-end-input" type="time" class="form-control" style="flex-shrink: 3; min-width: 80px;" required/>
                </div>

                <br />
                <textarea name="description-input" id="description-input" class="form-control" placeholder="Beschreibung"></textarea>
                <br />

                <div class="alert alert-warning" id="date-warning-box" style="display: none;">
                    <p class="font-weight-normal" style="margin-bottom: 0;" id="date-warning-text"></p>
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" name="ignore-date-warning" id="ignore-date-warning" class="custom-control-input">
                        <label class="custom-control-label" for="ignore-date-warning">Warnung ignorieren</label>
                    </div>
                </div>

                <input name="update-submit" type="submit" class="form-control btn btn-info" value="Speichern" />
            </form>
        </div>
    </div>
  </div>

  <script>
      document.getElementById("edit-form").onsubmit = function() {
        let startDate = document.getElementById("date-start-input").valueAsDate;
        let startTime = document.getElementById("date-time-start-input").valueAsDate;
        startDate.setHours(startTime.getHours());
        startDate.setMinutes(startTime.getMinutes());

        let endDate = document.getElementById("date-end-input").valueAsDate;
        let endTime = document.getElementById("date-time-end-input").valueAsDate;
        endDate.setHours(endTime.getHours());
        endDate.setMinutes(endTime.getMinutes());

        let currentDate = new Date();

        if(document.getElementById("ignore-date-warning").checked) {
            return true;
        }

        if((startDate < currentDate || endDate < currentDate)) {
            document.getElementById("date-warning-text").innerText = "Das angegebene Datum liegt in der Vergangenheit!";
            document.getElementById("date-warning-box").style.display = "block";
            return false;
        }

        if(endDate < startDate) {
            document.getElementById("date-warning-text").innerText = "Das Enddatum ist vor dem Startdatum!";
            document.getElementById("date-warning-box").style.display = "block";
            return false;
        }
      };
  </script>
</div>