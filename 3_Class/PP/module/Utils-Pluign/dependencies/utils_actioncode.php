<?php
    /* File: utils_actioncode.php
     * Author: Himmelbauer Eric
     * 
     * Creation-Date: 17.10.2019
     * Latest Change: 17.10.2019
     *
     * Description:
     *   Implements all Utilities that are needed to generate ActionCodes.
     * 
     */

    require_once('utils.php');

    class GGN_UtilsActionCode {	
       /* Function: AddAction
        * Author: Himmelbauer Eric
        * 
        * Parameters:
        *   - (string) $codeType
        *     - The Type of ActionCode you want to generate.
        *     - For further reference see "GenerateActionCode".
        *   - (string) $actionParameter
        *     - The information you want to save inside the parameter-column of the ActionCode
        *     - Can be literally anything, adapts to your needs.
        *   - (string) $action
        *     - The label of the ActionCode
        *     - Only used for coder-reference.
        *     - Example: Use "HREF" if you are looking to redirect after using the code.
        * 
        * Description:
        *   Adds an ActionCode into the Database and returns the generated Code.
        * 
        * Returns:
        *   Returns the Code that was inserted into the Database.
        */
        public static function AddAction(string $codeType, string $actionParameter, string $action) {
            $code = self::GenerateActionCode($codeType);

            $db = JFactory::getDbo();
            $query = $db->getQuery(true);
            
            $columns = array(
                'Code',
                'CodeType',
                'Action',
                'ActionParameter'
            );

            $data = array(
                $code,
                $codeType,
                $action,
                $actionParameter
            );

            $query->insert($db->quoteName('ggn_actioncode'))->columns($db->quoteName($columns))->values(implode(',', $db->quote($data)));
            $db->setQuery($query);
            $db->execute();

            return $code;
        }

       /* Function: GenerateActionCode
        * Author: Himmelbauer Eric
        * 
        * Parameters:
        *   - (string) $codeType
        *     - The Type of ActionCode-String you want to generate.
        *     - 2 Types:
        *       - ONETIME
        *         - For use inside a Form
        *         - String is 6 chars long, and only includes big letters and numbers.
        *       - URL
        *         - For use inside a HTTP-Url
        *         - String is 32 chars long and includes big + small letters and numbers.
        * 
        * Description:
        *   Generates an unused, unique ActionCode-String.
        * 
        * Returns:
        *   Returns the generated string.
        */
        public static function GenerateActionCode(string $codeType) {
            $db = JFactory::getDbo();
            $CodeCount = function($code, $db) {
                $query = $db->getQuery(true);

                $query->select('*')->from($db->quoteName('ggn_actioncode'))->where($db->quoteName('code'). ' = ' .$db->quote($code));
                $db->setQuery($query);
                $result = $db->loadObjectList();
                return count($result);
            };

            switch($codeType) {
                case 'URL': 
                    $code = '';
                    do {
                        $code = GGN_Utils::RandomString(32, true);
                    } while($CodeCount($code, $db) > 0);
                    return $code;
                    break;

                case 'ONETIME':
                    $code = '';
                    do {
                        $code = GGN_Utils::RandomString(6, false);
                    } while($CodeCount($code, $db) > 0);
                    return $code;
                    break;

                default:
                    return false;
                    break;
            }
        }
    }