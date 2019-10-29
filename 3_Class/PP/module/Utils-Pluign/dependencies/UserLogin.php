<?php

class UserLogin
{
    public static function createPersForm($i, $person, $errArr)
    {
        UserLogin::createInput("Geben Sie Ihren Vorname ein", "firstnamePers$i", $person[0], "Max", $errArr[0]);
        UserLogin::createInput("Geben Sie Ihren Nachname ein", "lastnamePers$i", $person[1], "Mustermann", $errArr[1]);
        UserLogin::createInput("Geben Sie Ihre E-Mail Adresse ein", "mailPers$i", $person[2], "email",$errArr[2]);
        UserLogin::createInput("Geben Sie Ihre Telefonnummer ein", "telPers$i", $person[3], "0660123456", $errArr[3]);

    }

    public static function createChildForm($i, $child, $errArr)
    {
        UserLogin::createInput("Geben Sie Ihren Vorname ein", "firstnamePers$i", $child[0], "Max", $errArr[0]);
        UserLogin::createInput("Geben Sie Ihren Nachname ein", "lastnamePers$i", $child[1], "Mustermann", $errArr[1]);
        UserLogin::createInput("Geben Sie Ihr Alter ein", "lastnamePers$i", $child[2], "Mustermann", $errArr[2]);
    }

    public static function createInput($text, $name, $value, $placeholder, $isErr)
    {
        echo "<div class='form-group' >
                <label for='$name'>$text</label >
                   <input type = 'text' class='form-control' id = '$name' name = '$name' aria-describedby = 'idName$name'
                    placeholder = $placeholder value='$value'>
                </div>";
    }

    public static function uuid()

    {
        try {
            $data = random_bytes(16);

            $data[6] = chr(ord($data[6]) & 0x0f | 0x40);
            $data[8] = chr(ord($data[8]) & 0x3f | 0x80);

            return vsprintf('%s%s-%s-%s-%s-%s%s%s', str_split(bin2hex($data), 4));

        } catch (exception $e) {
            echo $e->getMessage();
        }


    }

    public static function SaveLoginData(string $Gender, string $FirstName, string $LastName, string $Email, int $TelephoneNumber, string $EventId, int $valid, int $Active)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);
        } catch (exception $e) {
            echo " Ein Datenbankfehler ist aufgetreten";
        }

        $uuid = UserLogin::uuid();

        $columns = array(
            'UserID',
            'Gender',
            'FirstName',
            'LastName',
            'EMail',
            'TelephoneNumber'
        );

        $data = array(
            $uuid,
            $Gender,
            $FirstName,
            $LastName,
            $Email,
            $TelephoneNumber
        );

        $query->insert($db->quoteName('ggn_users'))->columns($db->quoteName($columns))->values(implode(',', $db->quote($data)));
        $db->setQuery($query);
        $db->execute();

        if ($valid == 1) {
            UserLogin::setParticipant($uuid, $FirstName, $LastName, $Active, $EventId, null);
        }

        return $uuid;
    }

    public static function getMaxParticipants($EventId)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);


            $query->select('maxParticipants');
            $query->from($db->quoteName('ggn_event'));
            $query->where($db->quoteName('EventId') . ' = ' . $db->quote($EventId));

            $db->setQuery($query);
            $maxNumber = $db->loadResult();

            return $maxNumber;
        } catch (exception $e) {
            echo $e->getMessage();
        }
    }

    public static function getParticipantsNumber($EventId)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);

            $query->select('COUNT(*)');
            $query->from($db->quoteName('ggn_participant'));
            $query->where($db->quoteName('EventId') . ' = ' . $db->quote($EventId));

            $db->setQuery($query);
            $currentNumber = $db->loadResult();

            return $currentNumber;
        } catch (exception $e) {
            echo $e->getMessage();
        }
    }

    public static function setParticipant(string $Uuid, string $FirstName, string $LastName, int $Active, string $EventId, $BirthDate)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);

            $ParticipantId = UserLogin::uuid();

            $columns = array(
                'UserID',
                'ParticipantId',
                'FirstName',
                'LastName',
                'Active',
                'EventId',
                'BirthDate'
            );

            $data = array(
                $Uuid,
                $ParticipantId,
                $FirstName,
                $LastName,
                $Active,
                $EventId,
                $BirthDate
            );

            $query->insert($db->quoteName('ggn_participant'))->columns($db->quoteName($columns))->values(implode(',', $db->quote($data)));
            $db->setQuery($query);
            $db->execute();
        } catch (exception $e) {
            echo $e->getMessage();
        }
    }


    public static function addChild(string $Uuid, string $FirstName, string $LastName, int $Active, string $EventId, string $BirthDate)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);

            $ParticipantId = UserLogin::uuid();

            $columns = array(
                'UserID',
                'ParticipantId',
                'FirstName',
                'LastName',
                'Active',
                'EventId',
                'BirthDate'
            );

            $data = array(
                $Uuid,
                $ParticipantId,
                $FirstName,
                $LastName,
                $Active,
                $EventId,
                $BirthDate
            );

            $query->insert($db->quoteName('ggn_participant'))->columns($db->quoteName($columns))->values(implode(',', $db->quote($data)));
            $db->setQuery($query);
            $db->execute();

            UserLogin::setParticipant($Uuid, $FirstName, $LastName, $Active, $EventId, $BirthDate);
        } catch (exception $e) {
            echo $e->getMessage();
        }

    }

    public static function getWaitList(string $WaitlistId)
    {
        UserLogin::GetNextId('WaitlistId', $WaitlistId);
    }

    public static function setWaitList(string $ParticipantId, string $EventId, string $WaitlistId, Datetime $TimeStamp)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);

            $columns = array(
                'WaitlistId',
                'TimeStamp',
                'EventId',
                'ParticipantId',
            );

            $data = array(
                $WaitlistId,
                $TimeStamp,
                $EventId,
                $ParticipantId

            );


            $query->insert($db->quoteName('ggn_waitlist'))->columns($db->quoteName($columns))->values(implode(',', $db->quote($data)));
            $db->setQuery($query);
            $db->execute();

        } catch (exception $e) {
            echo $e->getMessage();
        }
    }

    public static function GetNextId(string $tableName, string $idColumnName)
    {
        try {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);

            $query->select($db->quoteName($idColumnName))->from($db->quoteName($tableName))->order($idColumnName);
            $db->setQuery($query);
            $result = $db->loadObjectList();

            if (!$result) {
                echo "[GetNextId] Query failed! QUERY: $query";
                return false;
            }

            return ($result[0][$idColumnName] + 1);

        } catch (exception $e) {
            echo $e->getMessage();
        }
    }

    public static function Test()
    {
        return "blablabla";
    }
}

?>