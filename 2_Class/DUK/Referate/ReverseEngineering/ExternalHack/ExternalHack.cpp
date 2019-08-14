// ExternalHack.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include "pch.h"
#include <iostream>
#include <Windows.h>


void WriteValue(DWORD pid, DWORD addr, int val);
int GetNewVal(DWORD pid, DWORD addr);


int main()
{
	DWORD pid;
	std::cout << "Please input the PID: ";
	std::cin >> pid;

	DWORD addr;
	std::cout << "Please input the Address: 0x";
	std::cin >> std::hex >> addr >> std::dec;

	int newVal;
	std::cout << "Please input the new Value: ";
	std::cin >> newVal;


	WriteValue(pid, addr, newVal);
	std::cout << "Value was changed to " << GetNewVal(pid, addr);

	char buff[1024];
	std::cin >> buff;
}


void WriteValue(DWORD pid, DWORD addr, int val) {
	HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);
	WriteProcessMemory(hProc, (void*)addr, &val, sizeof(int), 0);
	CloseHandle(hProc);
}

int GetNewVal(DWORD pid, DWORD addr) {
	int result;

	HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);
	ReadProcessMemory(hProc, (void*)addr, &result, sizeof(int), 0);
	CloseHandle(hProc);

	return result;
}