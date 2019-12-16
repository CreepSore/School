<?php
defined('_JEXEC') or die;

jimport('joomla.plugin.plugin');

class BS2Plugin extends JPlugin
{

    protected $autoloadLanguage = true;

    function checkAuthentification($userId, $email, $telephoneNumber)
    {
        $db = JFactory::getDbo();

        //$sql = "SELECT TelephoneNumber FROM vaUsers WHERE UserId = " + $userId + " and Email =" + $email;
        //$result = $db->query($sql);

        $query = $db->getQuery(true);

        $query->select($db->quoteName('TelephoneNumber'));
        $query->from($db->quoteName('vaUsers'));
        $query->where($db->quoteName('UserId') . ' = ' . $db->quote($userId));
        $query->where($db->quoteName('Email') . ' = ' . $db->quote($email));

        $db->setQuery($query);

        $results = $db->loadObjectList();

        return true;
    }
}

// ----------- Stored Procedures -----------
//GetUserInformationById
//Übergabe der UserID (Guid), Rückgabe aller Spalten

//ValidateTelephonenumber
//Übergabe der letzten 3 Ziffer der Telefonnummer


?>