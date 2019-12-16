<?php
    /* File: utils_mail.php
     * Author: Ainberger Philip, Himmelbauer Eric
     * 
     * Creation-Date: 03.10.2019
     * Latest Change: 06.10.2019
     *
     * Description:
     *   Implements all Utilities that are needed to use Mail-Templates and send Mails.
     *
     */

    class GGN_UtilsMail {
        public static function SendMail($mailData, &$error) {
            $mailer = JFactory::getMailer();
            $config = JFactory::getConfig();
            
            $mailer->isHTML(true);
            $mailer->Encoding = 'base64';
            $mailer->addRecipient($mailData->recipients);
			$mailer->setSubject($mailData->subject);
            $mailer->setBody($mailData->body);


            $error = $mailer->Send();
		    return $error !== false;
        }

        public static function RenderTemplate(string $view, array $viewData) {
            foreach(array_keys($viewData) as $key) {
                $view = str_replace('{k:' . $key . '}', $viewData[$key], $view);
            }
            return $view;
        }
    }

    class GGN_MailData {
        public $subject;
        public $body;
        public $recipients;

        public function __construct($recipients, string $subject, string $body) {
            $this->recipients = $recipients;
            $this->subject = $subject;
            $this->body = $body;
        }
    }
?>