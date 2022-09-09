#include "File.h"

EXTERN_C W32Err *W32OpenFile(W32Err *pErr, HANDLE *phFile,
	TCHAR const *pszFile,
	DWORD dwAccess,
	DWORD dwShare,
	DWORD dwMode,
	DWORD dwFlag)
{
	memset(pErr, 0, sizeof(*pErr));
	*phFile = CreateFile(pszFile, dwAccess, dwShare, NULL, dwMode, dwFlag, 0);
	if (*phFile == INVALID_HANDLE_VALUE)
	{
		pErr->w32err = GetLastError();
		*phFile = 0;
	}
	return pErr->w32err ? pErr : NULL;
}

EXTERN_C W32Err *W32GetFileSize64(W32Err *pErr, UINT64 *pcbFile,
	HANDLE hFile)
{
	DWORD lo = 0, hi = 0, err = 0;
	memset(pErr, 0, sizeof(*pErr));
	lo = GetFileSize(hFile, &hi);
	err = GetLastError();
	/*
		Do not check GetLastError() only.
		In Win9x, GetLastError() returns non-zero even when no error.
	*/
	if (lo == INVALID_FILE_SIZE && err)
	{
		pErr->w32err = err;
	}
	else
	{
		*pcbFile = (((UINT64)hi) << 32) | lo;
	}
	return pErr->w32err ? pErr : NULL;
}
