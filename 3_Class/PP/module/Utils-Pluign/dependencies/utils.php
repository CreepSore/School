<?php
    /* File: utils.php
     * Author: Ainberger Philip, Ratzberger Tobias, Himmelbauer Eric, Ruff Sebastian
     * 
     * Creation-Date: 08.09.2019
     * Latest Change: 24.10.2019
     *
     * Description:
     *   Implements all Utilities that are shared between every Project-Group.
     * 
     */

    class GGN_Utils {
		/* Function: GetNextId
		 * Author: Himmelbauer Eric
		 * 
		 * Parameters:
		 *   - (string) $tableName
		 *     - The name of the table you want to fetch the next id from. 
		 *   - (string) $idColumnName
		 *     - The name of the column you want to fetch the next id from.
		 * 
		 * Description:
		 *   Gets the next id of a specified column from a specified table.
		 *   The use of this function should be avoided:
		 *     Primary-Key inserts will be handled by the Database via AUTO_INCREMENT
		 * 
		 * Returns:
		 *   Returns false if the Query was not successful.
		 *   Returns the next Id if the Query was successful.
		 */
        public static function GetNextId(string $tableName, string $idColumnName) {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);
    
            $query->select($db->quoteName($idColumnName))->from($db->quoteName($tableName))->order($idColumnName);
            $db->setQuery($query);
            $result = $db->loadObjectList();

            if(!$result) {
                echo "[GetNextId] Query failed! QUERY: $query";
                return false;
            }

            return ($result[0][$idColumnName] + 1);
        }
		
		
		public static function GetUserInformationByUserId(string $userId) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$query
				->select(array('*'))
				->from($db->quoteName('ggn_users', 'users'))
				->where($db->quoteName('UserId') . ' = '. $db->quote($userId));

			$db->setQuery($query);
			$result= $db->loadObjectList();
			return $result;
        }
		
		
		public static function GetUserInformationFromEmail(string $email) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$query
				->select(array('*'))
				->from($db->quoteName('ggn_users', 'users'))
				->where($db->quoteName('Email') . ' = '. $db->quote($email));

			$db->setQuery($query);
			$result= $db->loadObjectList();
			return $result;
        }
		
		public static function VerifyActionCode($userId, $code) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$query
				->select(array('*'))
				->from($db->quoteName('ggn_actioncode', 'action'))
				->where(array($db->quoteName('ActionParameter') . ' = '. $db->quote($userId),$db->quoteName('Code') . ' = '. $db->quote($code)));

			$db->setQuery($query);
			$result= $db->loadObjectList();
						
			return sizeof($result) > 0;
		}
		
		
		public static function DeleteActionCode($userId, $code) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$conditions = array(
				$db->quoteName('ActionParameter') .' = '. $db->quote($userId), 
				$db->quoteName('Code') . ' = ' . $db->quote($code)
			);

			$query->delete($db->quoteName('ggn_actioncode'));
			$query->where($conditions);

			$db->setQuery($query);

			return $db->execute();
		}
		
		/* Function: FetchActionCode
		 * Author: Himmelbauer Eric
		 * 
		 * Parameters:
		 *   - $code
		 *     - The code you want to fetch the information from.
		 * 
		 * Description:
		 *   Fetches the whole table-row of the actioncode.  
		 *   For further reference see the database structure.
		 * 
		 * Returns:
		 *   Returns false if the specified ActionCode does not exist.
		 *   Returns the ActionCode-Row if the Code does exist.
		 */
		public static function FetchActionCode($code) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$query
				->select(array('*'))
				->from($db->quoteName('ggn_actioncode', 'action'))
				->where($db->quoteName('Code') . ' = '. $db->quote($code));

			$db->setQuery($query);
			$obj = $db->loadObjectList();
			if(count($obj) > 0) {
				return $obj[0];
			} else {
				return false;
			}
        }
		
		public static function DeactivateEventByParticipantId($participantId, $eventId) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$fields = array( $db->quoteName('Active') . ' = 0' );

			// Conditions for which records should be updated.
			$conditions = array(
				$db->quoteName('ParticipantId') . ' = ' . $db->quote($participantId),
				$db->quoteName('EventId') . ' = '.$db->quote($eventId)
			);

			$query->update($db->quoteName('ggn_participant'))->set($fields)->where($conditions);

			$db->setQuery($query);
			return $db->execute();
        }
		
		public static function VerifyPhoneNumber($userId, $phone) {
            $db = JFactory::getDbo();
			$query = $db->getQuery(true);

			$query
				->select(array('*'))
				->from($db->quoteName('ggn_users', 'users'))
				->where(array($db->quoteName('UserId') . ' = '. $db->quote($userId),$db->quoteName('TelephoneNumber') . ' LIKE '. $db->quote('%'.$phone)));

			$db->setQuery($query);
			$result= $db->loadObjectList();
						
			return sizeof($result) > 0;
        }
		
		
		public static function GetEventsByUserId(string $userId) {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);
    				
			$query
				->select(array('title', 'dateStart', 'dateEnd', 'concat_ws(\' \',ggn_participant.FirstName,ggn_participant.LastName) as Name', 'TIMESTAMPDIFF(YEAR, Birthdate, CURDATE()) as Age','EventId','ParticipantId','Active'))
				->from($db->quoteName('ggn_users', 'users'))
				->join('INNER', $db->quoteName('ggn_participant') . ' using(' . $db->quoteName('UserId') . ')')
				->join('INNER', $db->quoteName('ggn_event') . ' using(' . $db->quoteName('EventId') . ')')
				->where($db->quoteName('UserId') . ' = '. $db->quote($userId))
				->order($db->quoteName('Active').' DESC, dateStart');
				
            $db->setQuery($query);
			$result = $db->loadObjectList();

            return $result;
        }
		
		public static function GetEventByParticipant(string $eventId, string $participantId) {
            $db = JFactory::getDbo();
            $query = $db->getQuery(true);
    				
			$query
				->select(array('title', 'dateStart', 'dateEnd', 'concat_ws(\' \',ggn_participant.FirstName,ggn_participant.LastName) as Name', 'TIMESTAMPDIFF(YEAR, Birthdate, CURDATE()) as Age','EventId','ParticipantId'))
				->from($db->quoteName('ggn_users', 'users'))
				->join('INNER', $db->quoteName('ggn_participant') . ' using(' . $db->quoteName('UserId') . ')')
				->join('INNER', $db->quoteName('ggn_event') . ' using(' . $db->quoteName('EventId') . ')')
				->where(array($db->quoteName('ParticipantId') . ' = '. $db->quote($participantId), $db->quoteName('EventId') . ' = '. $db->quote($eventId)));
				
            $db->setQuery($query);
			$result = $db->loadObjectList();

            return $result;
        }

		/* Function: RandomString
		 * Author: Himmelbauer Eric
		 * 
		 * Parameters:
		 *   - (int) $length
		 *     - The length of the generated String
		 *   - (bool) $useLowercase
		 *     - Optional
		 *     - Set to true if you also want to generate lowercase letters
		 * 
		 * Description:
		 *   Generates a random string of a specified length.
		 *   The Charset includes the chars '0'-'9' and 'A'-'Z'.
		 *   Setting the $useLowercase parameter to true adds the char range 'a'-'z'.
		 * 
		 * Returns:
		 *   Returns the generated String
		 */
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
		
		/* Function: ReadFileContent
		 * Author: Himmelbauer Eric
		 * 
		 * Parameters:
		 *   - (string) $path
		 *     - The path to the file you want to read
		 *   - (bool) $asArray
		 *     - Optional
		 *     - Set to true if you want to get the Lines as Array
		 *     - Keeping this at false will give you a String
		 * 
		 * Description:
		 *   Reads all Text from a File
		 * 
		 * Returns:
		 *   Returns the readed File Contents
		 */
		public static function ReadFileContent($path, bool $asArray = false) {
            $hFile = fopen($path, "r");
            if($asArray) {
                $data = [];
            } else {
                $data = "";
            }

            while($line = fgets($hFile)) {
                if($asArray) {
                    $data[] = $line;
                } else {
                    $data .= $line;
                }            
            }

            return $data;
        }
    }
?>