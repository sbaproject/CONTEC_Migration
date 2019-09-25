Option Strict Off
Option Explicit On
Module Functions
	' @(h) Common Module
	
	' @(s)
	'
	
	' ウィンドウにメッセージを送る関数の宣言
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function SendMessage Lib "user32.dll"  Alias "SendMessageA"(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	
	'API関数の宣言
	Private Const WM_KEYDOWN As Short = &H100s
	Private Declare Function PostMessage Lib "user32"  Alias "PostMessageA"(ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
	
	'コンピュータ名の長さを示す定数の宣言
	Private Const MAX_COMPUTERNAME_LENGTH As Short = 15 + 1
	
	' コンピュータ名を取得する関数の宣言
	Declare Function GetComputerName Lib "kernel32.dll"  Alias "GetComputerNameA"(ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
	
	'***Win32 APIのSHFileOperation()関数。ファイルシステムオブジェクトをコピーします。
	'プログラスバー付。
	'ファイル操作に関する情報を定義する構造体
	Structure SHFILEOPSTRUCT
		Dim hWnd As Integer
		Dim wFunc As Integer
		Dim pFrom As String
		Dim pTo As String
		Dim fFlags As Short
		Dim fAnyOperationsAborted As Integer
		Dim hNameMappings As Integer
		Dim lpszProgressTitle As String
	End Structure
	
	'どの操作を行うかを示す定数の宣言
	Public Const FO_COPY As Integer = &H2
	Public Const FOF_SIMPLEPROGRESS As Integer = &H100
	Public Const FOF_NOCONFIRMATION As Short = &H10s
	
	' ある位置から別の位置にメモリブロックを移動する関数の宣言
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Sub MoveMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
	
	' SHFILEOPSTRUCTのlpszProgressTitleまでのサイズ
	Public Const FILEOP_SIZE_ABORTED_TO_PROGRESSTITLE As Short = 12
	
	' ファイルを操作する関数の宣言
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function SHFileOperation Lib "shell32.dll"  Alias "SHFileOperationA"(ByRef lpFileOp As Any) As Integer
	
	'API関数のShowCursor=マウスポインタを消去
	Public Declare Function ShowCursor Lib "user32" (ByVal bShow As Integer) As Integer
	'***
	
	' AnsiInstrB の 2つの文字列引数に Ansi 文字列と、Ansi ﾊﾞｲﾄ位置を渡します。
	Function AnsiInstrB(ByRef arg1 As Object, ByRef arg2 As Object, Optional ByRef arg3 As Object = Nothing) As Short
		Dim pos As Object
		If IsNumeric(arg1) Then
			'UPGRADE_WARNING: オブジェクト arg1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト arg2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pos の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pos = AnsiLenB(AnsiLeftB(arg2, arg1))
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			AnsiInstrB = AnsiInstrB(arg1, AnsiStrConv(arg2, vbFromUnicode), AnsiStrConv(arg3, vbFromUnicode))
		Else
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			AnsiInstrB = AnsiInstrB(AnsiStrConv(arg1, vbFromUnicode), AnsiStrConv(arg2, vbFromUnicode))
		End If
	End Function
	' AnsiLeftBで処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
	
	' MidB で処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
	
	' 省略可能な引数をﾁｪｯｸしてから引数を設定します。
	Function AnsiMidB(ByVal StrArg As String, ByVal arg1 As Integer, Optional ByRef arg2 As Object = Nothing) As String
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(arg2) Then
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
		Else
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode), arg1, arg2), vbUnicode)
		End If
	End Function
	' 16 ﾋﾞｯﾄ環境では、Unicode <-> Ansi 変換は不必要なので、32 ﾋﾞｯﾄの時だけ
	
	Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	' AnsiLenB で処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
	Function AnsiLenB(ByVal StrArg As String) As Integer
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
	End Function
	
	' AnsiRightBで処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
	Function AnsiRightB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	' StrConv を呼び出します。
	Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If
		
	End Function
	
	Public Function AnsiTrimStringByByteCount(ByRef SrcStr As String, ByRef DstCount As Integer, Optional ByRef strRemainString As String = "") As String
		'概要：全角半角まじりのUnicode文字列を、文字をきらないように指定された
		'    : 文字数に丸めた文字列を返す
		'引数：SrcStr,Input,String,元の文字列
		'　　：DstCount,Input,Long,丸めるバイト数
		'説明：全角半角まじりのUnicode文字列を、文字をきらないように指定された
		'    : 文字数に丸めた文字列を返す
		Dim DstStr As String
		Dim TmpStr As String
		Dim SrcStrCount As Integer
		Dim i As Integer
		Dim CalcCount As Integer
		Dim TmpCount As Integer
		Dim fmt As String
		
		DstStr = ""
		SrcStrCount = Len(SrcStr)
		CalcCount = 0
		For i = 1 To SrcStrCount
			TmpStr = Mid(SrcStr, i, 1)
			TmpCount = AnsiLenB(TmpStr)
			If CalcCount + TmpCount > DstCount Then
				GoTo AnsiTrimStringByByteCount_End
			Else
				CalcCount = CalcCount + TmpCount
				DstStr = DstStr & TmpStr
			End If
		Next i
AnsiTrimStringByByteCount_End: 
		fmt = "!"
		For i = 1 To DstCount
			fmt = fmt & "@"
		Next 
		DstStr = VB6.Format(DstStr, fmt)
		AnsiTrimStringByByteCount = Trim(DstStr)
		strRemainString = AnsiMidB(SrcStr, CalcCount + 1)
		
	End Function
	
	' Api関数を使用しコンピュータ名を取得する。
	Public Function GP_GetCmpName() As String
		
		Dim strComputerNameBuffer As New VB6.FixedLengthString(MAX_COMPUTERNAME_LENGTH)
		Dim lngComputerNameLength As Integer
		Dim lngResult As Integer
		
		' コンピュータ名の長さを設定
		lngComputerNameLength = Len(strComputerNameBuffer.Value)
		' コンピュータ名を取得
		lngResult = GetComputerName(strComputerNameBuffer.Value, lngComputerNameLength)
		' コンピュータ名を表示
		GP_GetCmpName = Left(strComputerNameBuffer.Value, InStr(strComputerNameBuffer.Value, vbNullChar) - 1)
		
	End Function
	
	'********************'********************'********************'
	'***  配列の昇順ソート（クイックソート）                      ***
	'********************'********************'********************'
	'*【関数名】
	'*   SortAsc
	'*【引数】
	'*   ByRef varData() As Variant = 【入出力】配列
	'*   ByVal lngSort_S As Long   = ソート開始添字
	'*   ByVal lngSort_E As Long   = ソート終了添字
	'*【戻り値】
	'*  なし
	'*【処理】
	'*  クイックソートする。
	'********************'********************'********************'
	Public Sub SortAsc(ByRef varData() As Object, ByVal lngSort_S As Integer, ByVal lngSort_E As Integer)
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varX As Object
		Dim varW As Object
		
		'** クイックソート
		'UPGRADE_WARNING: オブジェクト varData(lngSort_S + lngSort_E \ 2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		varX = varData((lngSort_S + lngSort_E) \ 2)
		lngI = lngSort_S
		lngJ = lngSort_E
		
		Do 
			'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do While varData(lngI) < varX
				lngI = lngI + 1
			Loop 
			'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do While varData(lngJ) > varX
				lngJ = lngJ - 1
			Loop 
			If lngI >= lngJ Then
				Exit Do
			End If
			
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varW の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varW = varData(lngI)
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varData(lngI) = varData(lngJ)
			'UPGRADE_WARNING: オブジェクト varW の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varData(lngJ) = varW
			
			lngI = lngI + 1
			lngJ = lngJ - 1
		Loop 
		If (lngSort_S < lngI - 1) Then
			Call SortAsc(varData, lngSort_S, lngI - 1)
		End If
		If (lngSort_E > lngJ + 1) Then
			Call SortAsc(varData, lngJ + 1, lngSort_E)
		End If
		
	End Sub
	
	'********************'********************'********************'
	'***  配列の降順ソート（クイックソート）                      ***
	'********************'********************'********************'
	'*【関数名】
	'*   SortAsc
	'*【引数】
	'*   ByRef varData() As Variant = 【入出力】配列
	'*   ByVal lngSort_S As Long   = ソート開始添字
	'*   ByVal lngSort_E As Long   = ソート終了添字
	'*【戻り値】
	'*  なし
	'*【処理】
	'*  クイックソートする。
	'********************'********************'********************'
	Public Sub SortDesc(ByRef varData() As Object, ByVal lngSort_S As Integer, ByVal lngSort_E As Integer)
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varX As Object
		Dim varW As Object
		
		'** クイックソート
		'UPGRADE_WARNING: オブジェクト varData(lngSort_S + lngSort_E \ 2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		varX = varData((lngSort_S + lngSort_E) \ 2)
		lngI = lngSort_S
		lngJ = lngSort_E
		
		Do 
			'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do While varData(lngI) > varX
				lngI = lngI + 1
			Loop 
			'UPGRADE_WARNING: オブジェクト varX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do While varData(lngJ) < varX
				lngJ = lngJ - 1
			Loop 
			If lngI >= lngJ Then
				Exit Do
			End If
			
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varW の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varW = varData(lngI)
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varData(lngI) = varData(lngJ)
			'UPGRADE_WARNING: オブジェクト varW の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varData(lngJ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varData(lngJ) = varW
			
			lngI = lngI + 1
			lngJ = lngJ - 1
		Loop 
		
		If (lngSort_S < lngI - 1) Then
			Call SortDesc(varData, lngSort_S, lngI - 1)
		End If
		If (lngSort_E > lngJ + 1) Then
			Call SortDesc(varData, lngJ + 1, lngSort_E)
		End If
		
	End Sub
	
	'UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Public Function Nz(ByVal var As Object, Optional ByVal str_Renamed As String = "") As Object
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(var) = True Then
			If str_Renamed = "" Then
				'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Nz = ""
			Else
				'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Nz = str_Renamed
			End If
			
		ElseIf Len(var) < 1 Then 
			If str_Renamed = "" Then
				'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Nz = ""
			Else
				'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Nz = str_Renamed
			End If
		Else
			'UPGRADE_WARNING: オブジェクト var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Nz = var
		End If
		
	End Function
	
	Public Function StChk(ByVal strVar As String) As String
		
		Dim strWK As String
		Dim strWk2 As String
		Dim lngIndex As Integer
		Const C_strQut As String = "'"
		
		'シングルコーテーション1個を2個に置き換える。
		'オラクルのINSERT及び、UPDATE文に使用してください。
		strWK = vbNullString
		If Len(strVar) > 0 Then
			
			'VB5以下で使用する。
			'        For lngIndex = 1 To Len(strVar)
			'            strWk2 = Mid(strVar, lngIndex, 1)
			'            If strWk2 = C_strQut Then
			'                strWK = strWK & strWk2 & C_strQut
			'            Else
			'                strWK = strWK & strWk2
			'            End If
			'        Next lngIndex
			
			'VB6以上で使用する。
			strWK = Replace(strVar, "'", "''")
		End If
		
		StChk = strWK
		
	End Function
	
	Public Function DblCChk(ByVal strVar As String) As String
		
		Dim strWK As String
		
		'ダブルコーテーション1個を2個に置き換える。
		'CSVファイル出力時に使用してください。
		strWK = vbNullString
		If Len(strVar) > 0 Then
			strWK = Replace(strVar, """", """""")
		End If
		
		DblCChk = strWK
		
	End Function
	
	Public Function NumNull(ByVal strVar As String) As String
		
		'strVar=Nullの場合、''を返す。
		If Trim(strVar) = vbNullString Then
			NumNull = "''"
		Else
			NumNull = strVar
		End If
		
	End Function
	
	'対象日の月末の日付を求める
	Public Function MonthEnd(ByVal datDate As Date) As Date
		
		Dim datWK As Date
		
		'対象日の最初の日を求める。
		datWK = CDate(VB6.Format(datDate, "yyyy/mm") & "/01")
		'対象月の最終日を求める。
		MonthEnd = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, datWK))
		
	End Function
	
	Public Function GP_AddZero(ByVal dblData As Double, ByVal lngKETA As Integer) As String
		
		Dim strResult As String
		
		'頭に0を付けて指定桁数データを返す。
		strResult = Right(New String("0", lngKETA) & dblData, lngKETA)
		
		GP_AddZero = CStr(strResult)
		
	End Function
	
	Public Function GP_AddSpace(ByVal strData As String, ByVal lngKETA As Integer) As String
		
		Dim strResult As String
		
		'頭にスペースを付けて指定桁数データを返す。
		strResult = AnsiRightB(Space(lngKETA) & strData, lngKETA)
		
		GP_AddSpace = strResult
		
	End Function
	
	Public Function GP_べき乗(ByVal dblData As Double, ByRef lngKETA As Integer) As String
		
		Dim dblWK As Double
		Dim lnbResult As Integer
		
		'べき乗計算。
		dblWK = 10 ^ (lngKETA)
		lnbResult = dblData * dblWK
		
		GP_べき乗 = CStr(lnbResult)
		
	End Function
	
	'********************************************************************************
	' @(f)      : Ctrl_send
	'
	' 機能      : コントロール移動を移動する。
	'
	' 返り値    :
	'
	' 引き数    : KeyAscii As Integer
	'
	' 備考      :
	
	Function GP_CtrlSend(ByRef KeyAscii As Short, ByRef frm As System.Windows.Forms.Form) As Object
		If KeyAscii = System.Windows.Forms.Keys.Return Then
			PostMessage(frm.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021s)
			KeyAscii = 0
		End If
	End Function
	
	'********************************************************************************
	' @(f)      : CtrlHanten
	'
	' 機能      : コントロールを反転表示する。
	'
	' 返り値    :
	'
	' 引き数    : Txt As TextBox : テキストボックス
	'
	' 備考      :
	
	Public Sub GP_CtrlHanten(ByRef Txt As System.Windows.Forms.TextBox)
		Txt.SelectionStart = 0
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		Txt.SelectionLength = LenB(Txt)
	End Sub
	
	Public Function GP_StrLengthTrim(ByVal strValue As String, ByVal lngLen As Integer) As Collection
		Dim lngMOJI As Integer
		Dim lngKETA As Integer
		Dim colWK As Collection
		Dim strValue_WK As String
		
		'商品名称の分割
		
		strValue_WK = strValue
		colWK = New Collection
		
		lngMOJI = 0
		lngKETA = 0
		
		Do Until lngKETA >= lngLen
			lngMOJI = lngMOJI + 1
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			lngKETA = lngKETA + LenB(StrConv(Mid(strValue_WK, lngMOJI, 1), vbFromUnicode))
		Loop 
		
		If lngKETA > lngLen Then
			colWK.Add(Left(strValue_WK, lngMOJI - 1))
			colWK.Add(Mid(strValue_WK, lngMOJI, AnsiLenB(strValue_WK) - (lngMOJI - 1)))
		Else
			colWK.Add(Left(strValue_WK, lngMOJI))
			colWK.Add(Mid(strValue_WK, lngMOJI + 1, AnsiLenB(strValue_WK) - lngMOJI))
		End If
		
	End Function
End Module