#pragma once
#pragma comment(linker,"\"/manifestdependency:type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='*' publicKeyToken='6595b64144ccf1df' language='*'\"")

#include "Err.h"

static W32Err w32err;
#define W32ERR  W32Err_IsErr(w32err)

#include "TestTabCtrl.h"

void RawMain(void)
{
	LoadLibrary(TEXT("comctl32"));
	TestTabCtrl();
	ExitProcess(0);
}

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
	RawMain();
	return 0;
}
