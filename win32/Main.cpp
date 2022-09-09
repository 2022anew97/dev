#pragma once
#include "File.h"
#include <stdio.h>

#define CONCAT__(a,b)  a ## b
#define CONCAT(a,b)  CONCAT__(a, b)

static W32Err w32err;
#define W32ERR  W32Err_IsErr(w32err)

int main()
{
	HANDLE hFile = 0;
	UINT64 cbFile = 0;
	if (W32OpenFile(&w32err, &hFile, TEXT("Main.cpp"), GENERIC_READ, 0, OPEN_EXISTING, 0)) goto eof;
	if (W32GetFileSize64(&w32err, &cbFile, hFile)) goto eof;
	printf("File Size = %I64u \n", cbFile);
eof:
	if (W32ERR) printf("Win32 error %u\n", w32err.w32err);
	if (hFile) CloseHandle(hFile);
	Sleep(2000);
	return 0;
}
