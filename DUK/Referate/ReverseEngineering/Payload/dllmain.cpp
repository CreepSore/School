// dllmain.cpp : Definiert den Einstiegspunkt für die DLL-Anwendung.
#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <stdio.h>
#include <fstream>
#include <sstream>

BOOL __stdcall mainThread(void* hModule) {
	MessageBox(NULL, TEXT("Injection successfully completed"), TEXT("Succeeded"), MB_OK | MB_ICONINFORMATION);
	
	std::fstream input = std::fstream("C:\tmp\addr.conf", 3, 64);

	DWORD address;
	input >> std::hex >> address;

	int * health = (int*)address;

	while (!GetAsyncKeyState(VK_NUMPAD0)) {
		*health = 1337;
	}
	
	FreeLibraryAndExitThread((HMODULE)hModule, 0);
}


BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		CreateThread(nullptr, NULL, (LPTHREAD_START_ROUTINE)mainThread, (void*)hModule, NULL, nullptr);
		break;
	}
	return TRUE;
}

