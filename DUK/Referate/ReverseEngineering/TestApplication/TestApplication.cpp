// TestApplication.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include "pch.h"
#include <Windows.h>
#include <iostream>
#include <time.h>

int hp = 100;

void DecreaseHealth(int dec);
bool CheckDeath();

int main()
{
	srand(time(0));
	std::cout << "PID: " << GetCurrentProcessId() << std::endl;
	std::cout << "HP Pointer-Address: " << std::hex << "0x" << &hp << std::endl;
	
	while (getchar()) {
		int rnd = rand() % 10;
		DecreaseHealth(rnd);
		if (CheckDeath()) {
			std::cout << "Dead.";
			break;
		}
	}
}


void DecreaseHealth(int dec) {
	hp -= dec;
	if (hp < 0)
		hp = 0;
	std::cout << "Health: " << std::dec << hp;
}

bool CheckDeath() {
	return hp <= 0;
}