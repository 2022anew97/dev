#pragma once
#include <Windows.h>

typedef struct W32Err
{
	DWORD w32err;
	HRESULT hr;
} W32Err;

#define W32Err_IsErr(e)  ((e.w32err) || FAILED(e.hr))
