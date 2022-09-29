#pragma once
#include <Windows.h>
#include "BaseUtil.h"

#define RC_X(r)  ((r).left)
#define RC_Y(r)  ((r).top)
#define RC_W(r)  ((r).right - (r).left)
#define RC_H(r)  ((r).bottom - (r).top)

#define PROP_RAYMAI_This  TEXT("Raymai.This")
#define PROP_RAYMAI_DefWndProc  TEXT("Raymai.DefWndProc")
#define PROP_RAYMAI_SubclassProc  TEXT("Raymai.SubclassProc")

static void * MemAllocZero(size_t cb)
{
	return HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, cb);
}

static void MemFree(void *ptr)
{
	HeapFree(GetProcessHeap(), 0, ptr);
}

static void W32SetWindowRect(HWND hWnd, RECT const *prc, BOOL redraw)
{
	MoveWindow(hWnd, RC_X(*prc), RC_Y(*prc), RC_W(*prc), RC_H(*prc), redraw);
}

static void W32SetWindowTextf(HWND hWnd, LPCTSTR lpszFmt, ...)
{
	static TCHAR szText[1024];
	va_list ap;
	va_start(ap, lpszFmt);
	wvsprintf(szText, lpszFmt, ap);
	va_end(ap);
	SetWindowText(hWnd, szText);
}

static void W32GetChildRect(HWND hWnd, HWND hChild, RECT *prc)
{
	GetWindowRect(hChild, prc);
	ScreenToClient(hWnd, (POINT*)prc);
	ScreenToClient(hWnd, (POINT*)prc + 1);
}

static WNDPROC W32SetWndProc(HWND hWnd, WNDPROC lpfnNewProc)
{
	return (WNDPROC)(LPARAM)SetWindowLongPtr(hWnd, GWLP_WNDPROC, (LPARAM)lpfnNewProc);
}

static WNDPROC W32GetDefWndProc(HWND hWnd)
{
	WNDPROC defProc = (WNDPROC)GetProp(hWnd, PROP_RAYMAI_DefWndProc);
	return defProc ? defProc : DefWindowProc;
}

static BOOL W32TransparentBackgroundStatic(UINT msg, WPARAM wParam, LRESULT *plResult)
{
	if (msg == WM_CTLCOLORSTATIC)
	{
		SetTextColor((HDC)wParam, GetSysColor(COLOR_WINDOWTEXT));
		SetBkMode((HDC)wParam, TRANSPARENT);
		*plResult = (LRESULT)(WPARAM)GetStockObject(NULL_BRUSH);
		return TRUE;
	}
	return FALSE;
}
