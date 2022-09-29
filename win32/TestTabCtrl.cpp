#include "TestTabCtrl.h"
#include "WindowUtil.hpp"
#include <CommCtrl.h>

class TestTabCtrlFlow
{
public:
	WNDPROC const m_StaticWndProc;
	HWND m_hWnd;
	HWND m_hTabCtrl;
	HWND m_tab0_btnTopLeft;
	HWND m_tab0_btnTopRight;
	HWND m_tab0_btnBottomLeft;
	HWND m_tab0_btnBottomRight;
	HWND m_tab0_lblHelloWorld;
	int m_iOldTab;

	TestTabCtrlFlow() :
		m_StaticWndProc(StaticWndProc<TestTabCtrlFlow>),
		m_hWnd(0), m_hTabCtrl(0),
		m_tab0_btnTopLeft(0),
		m_tab0_btnTopRight(0),
		m_tab0_btnBottomLeft(0),
		m_tab0_btnBottomRight(0),
		m_tab0_lblHelloWorld(0),
		m_iOldTab(-1)
	{
		WNDCLASS wc = { 0 };
		wc.lpfnWndProc = m_StaticWndProc;
		wc.lpszClassName = TEXT("TestTabCtrlFlow");
		wc.hbrBackground = (HBRUSH)(COLOR_3DFACE + 1);
		wc.hCursor = LoadCursor(0, IDC_ARROW);
		wc.style = CS_HREDRAW | CS_VREDRAW;
		RegisterClass(&wc);
		m_hWnd = CreateWindowEx(0,
			wc.lpszClassName, NULL,
			WS_TILEDWINDOW,
			CW_USEDEFAULT, 0,
			CW_USEDEFAULT, 0,
			0, 0, 0, this);
		ShowWindow(m_hWnd, 1);
		while (IsWindow(m_hWnd))
		{
			MSG msg;
			if (GetMessage(&msg, 0, 0, 0))
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
		}
	}
	LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
	{
		LRESULT lResult = 0;
		BOOL overrid = 0;
		//
		if (hWnd == m_tab0_btnTopLeft) return WndProc_tab0_CornerButton(hWnd, msg, wParam, lParam);
		if (hWnd == m_tab0_btnTopRight) return WndProc_tab0_CornerButton(hWnd, msg, wParam, lParam);
		if (hWnd == m_tab0_btnBottomLeft) return WndProc_tab0_CornerButton(hWnd, msg, wParam, lParam);
		if (hWnd == m_tab0_btnBottomRight) return WndProc_tab0_CornerButton(hWnd, msg, wParam, lParam);
		//
		if (msg == WM_NCCREATE) m_hWnd = hWnd;
		if (msg == WM_CREATE)
		{
			m_hTabCtrl = CreateWindowEx(0, WC_TABCONTROL, NULL,
				WS_CHILD | WS_VISIBLE,
				10, 10, 300, 300, hWnd, 0, 0, 0);
		}
		if (m_hTabCtrl) TabCtrl_onWndMsg(msg, wParam, lParam);
		if (!overrid) overrid = W32TransparentBackgroundStatic(msg, wParam, &lResult);
		if (!overrid) lResult = DefWindowProc(hWnd, msg, wParam, lParam);
		return lResult;
	}

	void TabCtrl_onWndMsg(UINT msg, WPARAM, LPARAM lParam)
	{
		TCITEM tcItem;
		TCHAR tcItem_Text[MAX_PATH];
		if (msg == WM_CREATE)
		{
			ZeroMemory(&tcItem, sizeof(tcItem));
			tcItem.mask = TCIF_TEXT;
			tcItem.pszText = tcItem_Text;
			lstrcpy(tcItem_Text, TEXT("Alpha"));
			TabCtrl_InsertItem(m_hTabCtrl, 0, &tcItem);
			lstrcpy(tcItem_Text, TEXT("Beta"));
			TabCtrl_InsertItem(m_hTabCtrl, 1, &tcItem);
			lstrcpy(tcItem_Text, TEXT("Gamma"));
			TabCtrl_InsertItem(m_hTabCtrl, 2, &tcItem);
		}
		else if (msg == WM_SIZE)
		{
			RECT rc;
			SetRect(&rc, 0, 0, LOWORD(lParam), HIWORD(lParam));
			InflateRect(&rc, -10, -10);
			W32SetWindowRect(m_hTabCtrl, &rc, FALSE);
			TabCtrl_initTabPage();
		}
		else if (msg == WM_NOTIFY)
		{
			NMHDR const * const pNMHDR = (NMHDR*)lParam;
			if (pNMHDR->hwndFrom == m_hTabCtrl)
			{
				switch (pNMHDR->code)
				{
				case TCN_SELCHANGE:
					TabCtrl_initTabPage();
					break;
				}
			}
		}
	}

	LRESULT CALLBACK WndProc_tab0_CornerButton(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
	{
		UINT const timerID_CheckMouseOver = 100;
		LPCTSTR const prop_CheckMouseOver = TEXT("CheckMouseOverState");
		struct CheckMouseOverState
		{
			BOOL isMouseOver;
			TCHAR szOldText[MAX_PATH];
		};
		if (msg == WM_MOUSEMOVE)
		{
			CheckMouseOverState *pState = (CheckMouseOverState*)GetProp(hWnd, prop_CheckMouseOver);
			if (pState && pState->isMouseOver) goto eof;
			if (!pState) pState = (CheckMouseOverState*)MemAllocZero(sizeof(*pState));
			if (!pState) goto eof;
			pState->isMouseOver = TRUE;
			GetWindowText(hWnd, pState->szOldText, ARRAYSIZE(pState->szOldText));
			SetProp(hWnd, prop_CheckMouseOver, pState);
			SetTimer(hWnd, timerID_CheckMouseOver, 100, NULL);
			SetWindowText(hWnd, TEXT("MouseOver = true"));
		}
		else if (msg == WM_TIMER && wParam == timerID_CheckMouseOver)
		{
			POINT point;
			GetCursorPos(&point);
			if (WindowFromPoint(point) == hWnd) goto eof;
			CheckMouseOverState *pState = (CheckMouseOverState*)GetProp(hWnd, prop_CheckMouseOver);
			if (pState)
			{
				pState->isMouseOver = FALSE;
				SetWindowText(hWnd, pState->szOldText);
			}
			KillTimer(hWnd, wParam);
		}
		else if (msg == WM_NCDESTROY)
		{
			void *pState = GetProp(hWnd, prop_CheckMouseOver);
			if (pState) MemFree(pState);
		}
	eof:
		return CallWindowProc(W32GetDefWndProc(hWnd), hWnd, msg, wParam, lParam);
	}

	void MaybeCreateButton(HWND &hButton, LPCTSTR lpszText)
	{
		if (!hButton)
		{
			hButton = CreateWindowEx(0, WC_BUTTON, lpszText, WS_CHILD, 0, 0, 0, 0, m_hWnd, 0, 0, NULL);
			SetProp(hButton, PROP_RAYMAI_This, this);
			SetProp(hButton, PROP_RAYMAI_DefWndProc, W32SetWndProc(hButton, m_StaticWndProc));
		}
	}

	void TabCtrl_initTabPage()
	{
		int const iCurrTab = TabCtrl_GetCurSel(m_hTabCtrl);
		MaybeCreateButton(m_tab0_btnTopLeft, TEXT("Top Left"));
		MaybeCreateButton(m_tab0_btnTopRight, TEXT("Top Right"));
		MaybeCreateButton(m_tab0_btnBottomLeft, TEXT("Bottom Left"));
		MaybeCreateButton(m_tab0_btnBottomRight, TEXT("Bottom Right"));
		if (!m_tab0_lblHelloWorld)
		{
			m_tab0_lblHelloWorld = CreateWindowEx(0, WC_STATIC, TEXT("Hello World!"), WS_CHILD, 0, 0, 0, 0, m_hWnd, 0, 0, NULL);
			HFONT hfo = CreateFont(-48, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, TEXT("Arial"));
			SendMessage(m_tab0_lblHelloWorld, WM_SETFONT, (WPARAM)hfo, 0);
		}
		if (m_iOldTab != iCurrTab)
		{
			ShowWindow(m_tab0_btnTopLeft, 0);
			ShowWindow(m_tab0_btnTopRight, 0);
			ShowWindow(m_tab0_btnBottomLeft, 0);
			ShowWindow(m_tab0_btnBottomRight, 0);
			ShowWindow(m_tab0_lblHelloWorld, 0);
		}
		if (iCurrTab == 0)
		{
			RECT rcTabCtrl;
			W32GetChildRect(m_hWnd, m_hTabCtrl, &rcTabCtrl);
			TabCtrl_AdjustRect(m_hTabCtrl, FALSE, &rcTabCtrl);
			int buttonWidth = RC_W(rcTabCtrl) / 4;
			int buttonHeight = RC_H(rcTabCtrl) / 6;
			RECT rc = rcTabCtrl;
			rc.right = rc.left + buttonWidth;
			rc.bottom = rc.top + buttonHeight;
			W32SetWindowRect(m_tab0_btnTopLeft, &rc, 0);
			rc = rcTabCtrl;
			rc.left = rc.right - buttonWidth;
			rc.bottom = rc.top + buttonHeight;
			W32SetWindowRect(m_tab0_btnTopRight, &rc, 0);
			rc = rcTabCtrl;
			rc.right = rc.left + buttonWidth;
			rc.top = rc.bottom - buttonHeight;
			W32SetWindowRect(m_tab0_btnBottomLeft, &rc, 0);
			rc = rcTabCtrl;
			rc.left = rc.right - buttonWidth;
			rc.top = rc.bottom - buttonHeight;
			W32SetWindowRect(m_tab0_btnBottomRight, &rc, 0);
			{
				rc = rcTabCtrl;
				rc.left += buttonWidth + 5;
				rc.right -= buttonWidth + 5;
				rc.bottom = rc.top + buttonHeight;
				W32SetWindowRect(m_tab0_lblHelloWorld, &rc, 0);
			}
#define SHOWW(x)   ShowWindow(x, 1)
			SHOWW(m_tab0_btnTopLeft);
			SHOWW(m_tab0_btnTopRight);
			SHOWW(m_tab0_btnBottomLeft);
			SHOWW(m_tab0_btnBottomRight);
			SHOWW(m_tab0_lblHelloWorld);
		}
		m_iOldTab = iCurrTab;
	}
};

EXTERN_C void TestTabCtrl(void)
{
	TestTabCtrlFlow();
}
