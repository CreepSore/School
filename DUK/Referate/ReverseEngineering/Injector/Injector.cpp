// Injector.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include "pch.h"
#include <iostream>
#include <Windows.h>

void InjectDLL(DWORD pid, const char * filename);

int main()
{
	DWORD pid;
	std::cout << "Please input the Pid: ";
	std::cin >> pid;

	std::cout << "Injecting payload ..." << std::endl;

	InjectDLL(pid, "Payload.dll");
}

void InjectDLL(DWORD pid, const char * filename) {
	HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);

	void * pageAddr = VirtualAllocEx(hProc, NULL, 255, MEM_COMMIT, PAGE_READWRITE);

	WriteProcessMemory(hProc, pageAddr, filename, strlen(filename), NULL);
	std::cout << "Last Error: " << GetLastError() << std::endl;

	HANDLE hThread = CreateRemoteThread(hProc, nullptr, NULL,
		(LPTHREAD_START_ROUTINE)GetProcAddress(GetModuleHandle(TEXT("kernel32.dll")), "LoadLibraryA"),
		pageAddr, NULL, nullptr);

	std::cout << "Thread Handle: " << hThread << std::endl;

	CloseHandle(hProc);
}