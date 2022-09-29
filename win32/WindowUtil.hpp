#pragma once
#include "WindowUtil.h"

template <typename T>
static LRESULT CALLBACK StaticWndProc(HWND hWnd, UINT msg, WPARAM w, LPARAM l)
{
	T *pThis;
	if (msg == WM_NCCREATE)
	{
		pThis = (T*)(((LPCREATESTRUCT)l)->lpCreateParams);
		SetProp(hWnd, PROP_RAYMAI_This, pThis);
	}
	else
	{
		pThis = (T*)GetProp(hWnd, PROP_RAYMAI_This);
	}
	if (pThis) return pThis->WndProc(hWnd, msg, w, l);
	return CallWindowProc(W32GetDefWndProc(hWnd), hWnd, msg, w, l);
}
