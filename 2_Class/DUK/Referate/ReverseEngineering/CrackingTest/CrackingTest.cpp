// CrackingTest.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include "pch.h"
#include <iostream>

const char * password = "ehdes1337";

int main()
{
	char input[1024];

	std::cout << "Please input the password: ";
	std::cin >> input;

	if (strcmp(password, input) == 0) {
		std::cout << "Correct Password =)";
	} else {
		std::cout << "Incorrect Password =(";
	}

	std::cin >> input;
}
