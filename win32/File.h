#pragma once
#include "Err.h"

EXTERN_C W32Err *W32OpenFile(W32Err *pErr, HANDLE *phFile,
	TCHAR const *pszFile,
	// GENERIC_READ, GENERIC_WRITE, FILE_APPEND_DATA...
	DWORD dwAccess,
	// 0, FILE_SHARE_READ...
	DWORD dwShare,
	// OPEN_EXISTING
	DWORD dwMode,
	// 0, FILE_FLAG_WRITE_THROUGH...
	DWORD dwFlag);

EXTERN_C W32Err *W32GetFileSize64(W32Err *pErr, UINT64 *pcbFile,
	HANDLE hFile);
