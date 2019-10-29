<?php
	defined('_JEXEC') or die;
	
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_mail.php');
    require_once('./plugins/eventmanagement/plg_vamanagement/dependencies/utils_actioncode.php');
		
	if(!isset($_GET['page'])) {
		header("Location: ?page=login");
		die();
	}

	$page = $_GET['page'];

	$path = JModuleHelper::getLayoutPath('mod_veranstalter', $params->get('layout', $_GET['page']));
	if(file_exists($path)) {
		require($path);
	} else {
		header("Location: ?page=error&error=Invalid Page '$page'");
	}