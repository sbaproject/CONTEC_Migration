Option Strict Off
Option Explicit On
Friend Class ClsComn
	'//*****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ClsComn.cls
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    RISE
	'//*＜説明＞
	'//*    共通関数クラス
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|RISE)          |新規作成
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// エラーメッセージ用
	'//-----------------------------------------------------------------------------------------
	Private Const cst_異常 As String = "実行時エラーです。システム担当者に連絡して下さい。"
	Private Const cst_詳細 As String = vbCrLf & vbCrLf & "[ 詳細 ]" & vbCrLf
	Private Const cst_参考 As String = vbCrLf & vbCrLf & "[ 参考 ]" & vbCrLf
	
	'//-----------------------------------------------------------------------------------------
	'// エラー発生時の格納変数
	'//-----------------------------------------------------------------------------------------
	Private gstrPROCEDURE As String 'ﾌﾟﾛｼｰｼﾞｬ名
	Private lngLastErrorNo As Integer '最終ｴﾗｰ№
	Private strLastErrorDesc As String '最終ｴﾗｰDescription
	
	'//-----------------------------------------------------------------------------------------
	'// ＡＰＩ使用宣言
	'//-----------------------------------------------------------------------------------------
	'//プライベートプログラムファイルの指定セクションの特定のキーの文字列値を読取る
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '2019/04/11 CHG START
    'Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/04/11 CHG E N D

	'//指定されたINIファイル（設定ファイル、初期化ファイル）の指定されたキーに値を書き込む（または、削除する）
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '2019/04/11 CHG START
    'Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    '2019/04/11 CHG E N D

	'//コンピュータ名取得
	Private Declare Function GetComputerName Lib "kernel32"  Alias "GetComputerNameA"(ByVal Buffer As String, ByRef SIZE As Integer) As Integer
	
	'//指定されたクラス名とウィンドウ名を持つトップレベルウィンドウ (親を持たないウィンドウ) を探します。子ウィンドウは探しません。
	Private Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
	
	'//通常使うプリンタ変更
	Private Declare Function SetDefaultPrinter Lib "winspool.drv"  Alias "SetDefaultPrinterA"(ByVal pszPrinter As String) As Integer
	
	'//ＳＨＥＬＬ起動関連の宣言
	Private Structure STARTUPINFO
		Dim cb As Integer
		Dim lpReserved As String
		Dim lpDesktop As String
		Dim lpTitle As String
		Dim dwX As Integer
		Dim dwY As Integer
		Dim dwXSize As Integer
		Dim dwYSize As Integer
		Dim dwXCountChars As Integer
		Dim dwYCountChars As Integer
		Dim dwFillAttribute As Integer
		Dim dwFlags As Integer
		Dim wShowWindow As Short
		Dim cbReserved2 As Short
		Dim lpReserved2 As Integer
		Dim hStdInput As Integer
		Dim hStdOutput As Integer
		Dim hStdError As Integer
	End Structure
	
	Private Structure PROCESS_INFORMATION
		Dim hProcess As Integer
		Dim hThread As Integer
		Dim dwProcessID As Integer
		Dim dwThreadID As Integer
	End Structure
	
	'UPGRADE_WARNING: 構造体 PROCESS_INFORMATION に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	'UPGRADE_WARNING: 構造体 STARTUPINFO に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function CreateProcessA Lib "kernel32" (ByVal lpApplicationName As Integer, ByVal lpCommandLine As String, ByVal lpProcessAttributes As Integer, ByVal lpThreadAttributes As Integer, ByVal bInheritHandles As Integer, ByVal dwCreationFlags As Integer, ByVal lpEnvironment As Integer, ByVal lpCurrentDirectory As Integer, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As Integer
	
	Private Const NORMAL_PRIORITY_CLASS As Integer = &H20
	Private Const GC_INFINITE2 As Short = -1
	
	Private Declare Function WaitForInputIdle Lib "user32" (ByVal hProcess As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'//開いているオブジェクトハンドルを閉じます
	Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
	
	'//アプリケーションが終わるまで待機します
	Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'//他のアプリケーションの終了コードを取得する
	Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer
	
	'//ウィンドウをアクティブにします。
	Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Integer) As Integer
	
	'//PeekMessage API 関連
	Private Const WM_KEYFIRST As Short = &H100s
	Private Const WM_KEYLAST As Short = &H108s
	Private Const WM_MOUSEFIRST As Short = &H200s
	Private Const WM_MOUSELAST As Short = &H209s
	Private Const PM_REMOVE As Short = &H1s
	
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Private Structure MSG
		Dim hwnd As Integer
		Dim message As Integer
		Dim wParam As Integer
		Dim lParam As Integer
		Dim time As Integer
		Dim pt As POINTAPI
	End Structure
	
	'//スレッドのメッセージキューにメッセージがあるかどうかをチェックし、もしあれば、指定された構造体にそのメッセージを格納します。
	'UPGRADE_WARNING: 構造体 MSG に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpmsg As MSG, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	
	'//現在のスレッドの実行を、指定された時間だけ中断します
	Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	Private Const LVM_FIRST As Short = &H1000s
	Private Const LVM_SETCOLUMNORDERARRAY As Integer = (LVM_FIRST + 58)
	Private Const LVM_GETCOLUMNORDERARRAY As Integer = (LVM_FIRST + 59)
	
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '2019/04/11 CHG START
    'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    '2019/04/11 CHG E N D
    '//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Set_Default_Printer
	'//*
	'//* <戻り値>     型                説明
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_InString       String          I             対象値
	'//*
	'//* <説  明>
	'//*    通常使うプリンタを変更する
	'//*****************************************************************************************
	Function Set_Default_Printer(ByVal pm_InString As String) As Object
		
		SetDefaultPrinter(pm_InString)
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　GetIniString
	'　機能　　Iniファイルを読み込む
	'　引数　　strSection  ： セッション名
	'　　　　　strKey      ： キー名
	'　　　　　strFileName ： INIファイル名
	'　返値　　取得した文字列
	'　備考　　なし
	'-----------------------------------------------------------
	Public Function GetIniString(ByVal strSection As String, ByVal strKey As String, ByVal strFileName As String) As String
		
		Dim lngRet As Integer
#Disable Warning BC40000 ' Type or member is obsolete
		Dim strValue As New VB6.FixedLengthString(255)
#Enable Warning BC40000 ' Type or member is obsolete
		
		' データ取得
		'// 2007/08/29 REP STT
		lngRet = GetPrivateProfileString(strSection, strKey, "", strValue.Value, 256, strFileName)
		'   lngRet = GetPrivateProfileString(strSection, strKey, "", strValue, 256, ByVal App.Path & "\" & gvcstJOB_ID & ".ini")
		'// 2007/08/29 REP END
		GetIniString = Left(strValue.Value, InStr(strValue.Value, vbNullChar) - 1)
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　WrtIniString
	'　機能　　Iniファイルに書き込む
	'　引数　　strSection  ： セッション名
	'　　　　　strKey      ： キー名
	'　　　　　strFileName ： INIファイル名
	'　　　　　strValue    ： 値
	'　返値　　取得した文字列
	'　備考　　なし
	'-----------------------------------------------------------
	Public Function WrtIniString(ByVal strSection As String, ByVal strKey As String, ByVal strFileName As String, ByVal strValue As String) As Boolean
		
		Dim lngRet As Integer
		
		' データ書込み
		lngRet = WritePrivateProfileString(strSection, strKey, strValue, strFileName)
		
		If lngRet = 1 Then
			WrtIniString = True
		Else
			WrtIniString = False
		End If
		
	End Function
	
	'-----------------------------------------------------------
	'  関数名   GetCurrentMachineName
	'  機能　   ﾏｼﾝ名取得
	'  引数　   なし
	'  返値　   String型   ﾏｼﾝ名
	'  備考　   なし
	'-----------------------------------------------------------
	Public Function GetCurrentMachineName() As String
		
		Const PROCEDURE As String = "GetCurrentMachineName"
		
#Disable Warning BC40000 ' Type or member is obsolete
		Dim bufMachineName As New VB6.FixedLengthString(128)
#Enable Warning BC40000 ' Type or member is obsolete
		Dim lResult As Integer
		
		On Error GoTo RUNTIME_ERROR
		
		lResult = GetComputerName(bufMachineName.Value, Len(bufMachineName.Value))
		
		GetCurrentMachineName = Ctr_AnsiLeftB(Left(bufMachineName.Value, InStr(bufMachineName.Value, vbNullChar) - 1), 5)
		
		GoTo END_SECTION
		
RUNTIME_ERROR: 
		lngLastErrorNo = Err.Number : strLastErrorDesc = Err.Description
		gstrPROCEDURE = IIf(gstrPROCEDURE = "", PROCEDURE, gstrPROCEDURE)
		Err.Raise(lngLastErrorNo,  , strLastErrorDesc)
		
		Exit Function
		
END_SECTION: 
		Exit Function
		
	End Function
	
	'-----------------------------------------------------------
	'  関数名   ChkDuplicateInstance
	'  機能　   重複起動をチェックする
	'  引数　   strCheckInstanceString (IN) ： ﾁｪｯｸ対象Instance
	'  返値　   Boolean   結果(True:起動exeなし False:起動exeあり)
	'  備考　   なし
	'-----------------------------------------------------------
	Function ChkDuplicateInstance(ByVal strCheckInstanceString As String) As Boolean
		
		On Error GoTo ONERR_STEP
		
		If (FindWindow(vbNullString, strCheckInstanceString) = 0) Then
			ChkDuplicateInstance = True
		Else
			ChkDuplicateInstance = False
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Chk_DuplicateInstance> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_AnsiLeftB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/11 CHG START
        'Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        Ctr_AnsiLeftB = LeftB(pm_Value, pm_Len)
        '2019/04/11 CHG E N D

		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_AnsiRightB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして右から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/11 CHG START
        'Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
        Ctr_AnsiRightB = RightB(pm_Value, pm_Len)
        '2019/04/11 CHG E N D

		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_AnsiMidB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Start           Long             I            切り取り開始バイト数
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして指定した位置から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/04/11 CHG START
            'Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
            Str_Value = MidB(pm_Value, pm_Start)
            '2019/04/11 CHG E N D
        Else
            'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/04/11 CHG START
            'Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
            Str_Value = MidB(pm_Value, pm_Start, pm_Len)
            '2019/04/11 CHG E N D

            '//全角文字が途中で途切れる場合１文字多めにカットする。
            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/04/11 CHG START
            'If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
            If LenB(Str_Value) > pm_Len Then
                '2019/04/11 CHG E N D
                Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
            End If
        End If

        Ctr_AnsiMidB = Str_Value

        Exit Function

    End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chk_Null
	'//*
	'//* <戻り値>     型          説明
	'//*             String      項目のNULLチェックをして戻す、NULLは""にする
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_InString       Variant          I            Nullﾁｪｯｸの対象値
	'//*
	'//* <説  明>
	'//*    ＮＵＬＬ値かチェックしデータ(String型)を戻す
	'//*****************************************************************************************
	Public Function Chk_Null(ByVal pm_InString As Object) As String
		
		On Error GoTo ONERR_STEP
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(pm_InString) Then
			Chk_Null = " "
		Else
			'UPGRADE_WARNING: オブジェクト pm_InString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Chk_Null = Trim(CStr(pm_InString))
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Chk_Null> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chk_NullN
	'//*
	'//* <戻り値>     型          説明
	'//*             Double      項目のNULLチェックをして戻す、NULLは0にする
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_InString       Variant           I            Nullﾁｪｯｸの対象値
	'//*
	'//* <説  明>
	'//*    ＮＵＬＬ値かチェックしデータ(String型)を戻す
	'//*****************************************************************************************
    '2019/04/11 CHG START
    'Public Function Chk_NullN(ByVal pm_InString As Object) As Double
    Public Function Chk_NullN(ByVal pm_InString As Object) As Decimal
        '2019/04/11 CHG E N D

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(pm_InString) Then
            Chk_NullN = 0
        Else
            'UPGRADE_WARNING: オブジェクト pm_InString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/11 CHG START
            'Chk_NullN = CDbl(Val(pm_InString))
            Chk_NullN = CDec(Val(pm_InString))
            '2019/04/11 CHG E N D
        End If

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        Call MsgBox("<Chk_NullN> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Edt_SQL
	'//*
	'//* <戻り値>       型          説明
	'//*                Variant     編集後文字
	'//*
	'//* <引  数>       項目名          型          I/O     内容
	'//*                pm_Str_Type     String      I       属性区分
	'//*                                                    (N:数値 ,S:文字, D0:日付, D6:日付, D8:日付)
	'//*                pm_Val_Char     Variant     I       対象文字列
	'//*                pm_bln_TrimMode Boolean     I       変換対象文字をTrimするか、しないかのフラグ（初期値はする）
	'//*                pm_bln_Null     Boolean     I       True :"" の時は、戻り値を" " にする（初期値）
	'//*                                                    False:"" の時は、戻り値をNullにする
	'//*
	'//* <説  明>
	'//*    渡された値をＳＱＬ文で操作できる文字に編集する
	'//*    ※SQL文のシングルコーテーション（'）を（''）に置換した文字列を返す
	'//*     （例＞「あ'あ'あ」→「あ''あ''あ」）
	'//*****************************************************************************************
    '2019/04/12 CHG START
    'Function Edt_SQL(ByVal pm_Str_Type As String, ByVal pm_Val_Char As Object, Optional ByVal pm_bln_TrimMode As Boolean = True, Optional ByVal pm_bln_Null As Boolean = True) As Object
    Function Edt_SQL(ByVal pm_Str_Type As String, ByVal pm_Val_Char As String, Optional ByVal pm_bln_TrimMode As Boolean = True, Optional ByVal pm_bln_Null As Boolean = True) As Object
        '2019/04/12 CHG E N D


        Dim Int_Year As Short
        Dim int_Month As Short
        Dim int_Day As Short
        Dim Var_Char As Object

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If (Trim(pm_Val_Char) = "") Or IsDBNull(pm_Val_Char) Then
            If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "S" Then
                If Not pm_bln_Null Then
                    'UPGRADE_WARNING: オブジェクト Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Edt_SQL = "Null"
                Else
                    'UPGRADE_WARNING: オブジェクト Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Edt_SQL = "' '"
                End If
            End If
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "N" And pm_Val_Char = 0 Then
        If StrConv(pm_Str_Type, VbStrConv.Uppercase) = "N" And pm_Val_Char = "0" Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Edt_SQL = 0
            GoTo EXIT_STEP
        End If

        If pm_bln_TrimMode Then
            'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_Val_Char = Trim(pm_Val_Char)
        End If

        Select Case StrConv(pm_Str_Type, VbStrConv.Uppercase)
            Case "S"
                'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                '2019/04/11 CHG START
                'GoSub Edt_SQL
                pm_Val_Char = GoSubEdtSQL(pm_Val_Char)
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Var_Char = Chr(39) & pm_Val_Char & Chr(39)
            Case "N"
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Var_Char = CDec(pm_Val_Char)
            Case "D"
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Var_Char = Chr(39) & pm_Val_Char & Chr(39)
            Case "D0"
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(pm_Val_Char, "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
            Case "D6"
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Int_Year = CShort(Mid(pm_Val_Char, 1, 2))
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                int_Month = CShort(Mid(pm_Val_Char, 3, 2))
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                int_Day = CShort(Mid(pm_Val_Char, 5, 2))
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(DateSerial(Int_Year, int_Month, int_Day), "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
            Case "D8"
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Int_Year = CShort(Mid(pm_Val_Char, 1, 4))
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                int_Month = CShort(Mid(pm_Val_Char, 5, 2))
                'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                int_Day = CShort(Mid(pm_Val_Char, 7, 2))
                'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
#Disable Warning BC40000 ' Type or member is obsolete
                Var_Char = Chr(39) & VB6.Format(DateSerial(Int_Year, int_Month, int_Day), "yyyy/mm/dd") & Chr(39)
#Enable Warning BC40000 ' Type or member is obsolete
        End Select

        'UPGRADE_WARNING: オブジェクト Var_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Edt_SQL = Var_Char

        GoTo EXIT_STEP
        '-------------------------------------------------------------------------------------------------------
        '2019/04/12 DEL START
        'Edt_SQL:
        '        '//初期ｾｯﾄ
        '        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        str_Temp = pm_Val_Char
        '        Str_Edit = ""
        '        Int_Start = 1
        '        Int_Find = 0

        '        Int_Find = InStr(str_Temp, LC_SingQuat)
        '        If Int_Find = 0 Then
        '            'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '            Return
        '        End If

        '        Do
        '            '//渡された文字列からｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝを検索し、存在しなければ抜ける
        '            Int_Find = InStr(str_Temp, LC_SingQuat)
        '            If Int_Find = 0 Then
        '                '//残りの文字列をｾｯﾄ
        '                Str_Edit = Str_Edit & str_Temp
        '                Exit Do
        '            End If

        '            '//ｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝを付加する
        '            Str_Edit = Str_Edit & Left(str_Temp, Int_Find) & LC_SingQuat

        '            '//検索開始位置ｾｯﾄ
        '            Int_Start = Int_Find + 1

        '            '//検索開始位置以降の文字列をｾｯﾄ
        '            str_Temp = Mid(str_Temp, Int_Start)
        '        Loop


        '        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pm_Val_Char = Str_Edit

        '        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '        Return
        '2019/04/12 DEL E N D
        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        Call MsgBox("<Edt_SQL> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Function

    '2019/04/12 ADD START
    Private Function GoSubEdtSQL(ByVal pm_Val_Char As String) As String
        Dim str_Temp As String
        Dim Str_Edit As String
        Dim Int_Start As Short
        Dim Int_Find As Short
        Const LC_SingQuat As String = "'"

        '//初期ｾｯﾄ
        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        str_Temp = pm_Val_Char
        Str_Edit = ""
        Int_Start = 1
        Int_Find = 0

        Int_Find = InStr(str_Temp, LC_SingQuat)
        If Int_Find = 0 Then
            'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            '2019/04/11 CHG START
            'Return
            Return pm_Val_Char
            '2019/04/11 CHG E N D
        End If

        Do
            '//渡された文字列からｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝを検索し、存在しなければ抜ける
            Int_Find = InStr(str_Temp, LC_SingQuat)
            If Int_Find = 0 Then
                '//残りの文字列をｾｯﾄ
                Str_Edit = Str_Edit & str_Temp
                Exit Do
            End If

            '//ｼﾝｸﾞﾙｸｫｰﾃｰｼｮﾝを付加する
            Str_Edit = Str_Edit & Left(str_Temp, Int_Find) & LC_SingQuat

            '//検索開始位置ｾｯﾄ
            Int_Start = Int_Find + 1

            '//検索開始位置以降の文字列をｾｯﾄ
            str_Temp = Mid(str_Temp, Int_Start)
        Loop


        'UPGRADE_WARNING: オブジェクト pm_Val_Char の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Val_Char = Str_Edit

        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '2019/04/11 CHG START
        'Return
        Return pm_Val_Char
        '2019/04/11 CHG E N D
    End Function
    '2019/04/12 ADD E N D

    '//****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Cnv_DateToNumeric
    '//*
    '//* <戻り値>     型          説明
    '//*              Long       日付をYYYYMMDDの数値型で返す（エラー時：0）
    '//*
    '//* <引  数>     項目名             型              I/O           内容
    '//*              pm_DDate          Date              I          変換する日付
    '//*
    '//* <説  明>
    '//*    日付型→数値型への変換
    '//*****************************************************************************************
	Function Cnv_DateToNumeric(ByVal pm_DDate As Date) As Integer
		
		On Error GoTo ONERR_STEP
		
		Cnv_DateToNumeric = 0
		
#Disable Warning BC40000 ' Type or member is obsolete
		Cnv_DateToNumeric = CInt(VB6.Format(pm_DDate, "YYYYMMDD"))
#Enable Warning BC40000 ' Type or member is obsolete
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Cnv_DateToNumeric> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Cnv_NumericToDate
	'//*
	'//* <戻り値>     型          説明
	'//*             Date        日付をYYYY/MM/DDで返す(エラー時：古い日付の"1800/01/01"を返す)
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*           pm_LonDate           Long              I          変換する数値
	'//*
	'//* <説  明>
	'//*    数値型→日付型への変換
	'//*****************************************************************************************
	Function Cnv_NumericToDate(ByVal pm_LonDate As Integer) As Date
		
		Dim strDate As String '//日付編集用
		
		On Error GoTo ONERR_STEP
		
#Disable Warning BC40000 ' Type or member is obsolete
		strDate = VB6.Format(pm_LonDate, "00/00/00")
#Enable Warning BC40000 ' Type or member is obsolete
		
		If Not IsDate(strDate) Then
			Cnv_NumericToDate = CDate("1800/01/01") '//古い日付を返す
		Else
#Disable Warning BC40000 ' Type or member is obsolete
			Cnv_NumericToDate = CDate(VB6.Format(strDate, "YYYY/MM/DD"))
#Enable Warning BC40000 ' Type or member is obsolete
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Call MsgBox("<Cnv_NumericToDate> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_Shell
	'//*
	'//* <戻り値>     型          説明
	'//*             Long        0:成功　-1:起動失敗 　1<=:実行ファイルより通知されたエラーレベル
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_CMD            String            I            実行ファイル名
	'//*              pm_vntFromObj     Variant           I            フォームオブジェクト（省略可）
	'//*              pm_vntMode        Variant           I            フォームオブジェクトが指定された場合のフォームの扱い
	'//*                                                      (Default) 1:Visible = True  で Enabled = False
	'//*                                                                2:Visible = True  で Enabled = True
	'//*                                                                3:Visible = False
	'//*
	'//* <説  明>
	'//*    アプリケーションを実行する
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20021001|RISE)          |新規作成
	'//*****************************************************************************************
	Public Function Ctr_Shell(ByVal pm_CMD As String, Optional ByRef pm_vntFromObj As Object = Nothing, Optional ByRef pm_vntFormDispMode As Object = 1) As Integer
		
		Dim wkProc As PROCESS_INFORMATION '//PROCESS_INFORMATION構造体
		Dim wkStart As STARTUPINFO '//STARTUPINFO構造体
		Dim wkRet As Integer '//SHELLの完了の戻り値
		Dim wkEstr As String '//エラー文言
		Dim wK_I As Short '//エラー文言の固定部の長さ
		Dim Wk_Str As String '//エラー文言編集ワーク
		Dim lpmsg As MSG '//MSG 構造体
		
		On Error GoTo Ctr_Shell_Error_Handler
		
		'//初期値設定
		Ctr_Shell = -1
		
		'//STARTUPINFO構造体のクリア
		wkStart.cb = Len(wkStart)
		
		'//SHELLの実行
		wkRet = CreateProcessA(0, pm_CMD, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, 0, wkStart, wkProc)
		
		Call WaitForInputIdle(wkProc.hProcess, GC_INFINITE2)
		Call CloseHandle(wkProc.hThread)
		
		'//指定された画面を制御する
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(pm_vntFromObj) Then
			Select Case pm_vntFormDispMode
				
				'//1:Visible = True  で Enabled = False
				Case 1
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Visible = True
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Enabled = False
					
					'//2:Visible = True  で Enabled = true
				Case 2
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Visible = True
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Enabled = True
					
					'//3:Visible = False
				Case 3
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Visible = False
					
					'//他
				Case Else
					'//何もしない
					
			End Select
		End If
		
		'//SHELLの完了を待ちあわせし、エラーコードを取得
		Do 
			'//タイムアウト秒数を1秒にて待ち合わせ
			wkRet = WaitForSingleObject(wkProc.hProcess, 1000)
			
			'//タイムアウトを判定し、タイムアウトでなければループ脱出
			If wkRet <> 258 Then
				Exit Do
			End If
			
			'//タイムアウト時、指定された画面をリフレッシュする。
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If Not IsNothing(pm_vntFromObj) Then
				'UPGRADE_WARNING: オブジェクト pm_vntFormDispMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_vntFormDispMode = 1 Or pm_vntFormDispMode = 2 Then
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Refresh の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Refresh()
				End If
			End If
			
		Loop 
		Call GetExitCodeProcess(wkProc.hProcess, wkRet)
		Call CloseHandle(wkProc.hProcess)
		
		'//結果
		If wkRet = 0 Then '//成功
			Ctr_Shell = 0
			GoTo EXIT_STEP
		End If
		
		If wkRet = -1 Then '//呼び出しエラー
			Ctr_Shell = -1
			GoTo EXIT_STEP
		End If
		
		If wkRet > 0 Then '//エラー
			Ctr_Shell = wkRet
			GoTo EXIT_STEP
		End If
		
EXIT_STEP: 
		
		'//指定された画面を制御する
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(pm_vntFromObj) Then
			Select Case pm_vntFormDispMode
				
				'//1:Visible = True  で Enabled = False
				Case 1
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Enabled = True
					
					'//2:Visible = True  で Enabled = true
				Case 2
					'//何もしない
					
					'//3:Visible = False
				Case 3
					'UPGRADE_WARNING: オブジェクト pm_vntFromObj.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_vntFromObj.Visible = True
					
					'//他
				Case Else
					'//何もしない
					
			End Select
			
			'//キーボードとマウスのキーバッファをクリアーする
			'UPGRADE_WARNING: オブジェクト pm_vntFromObj.hwnd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do Until 0 = PeekMessage(lpmsg, pm_vntFromObj.hwnd, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
			Loop 
			'UPGRADE_WARNING: オブジェクト pm_vntFromObj.hwnd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do Until 0 = PeekMessage(lpmsg, pm_vntFromObj.hwnd, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE)
			Loop 
			
			'//ウインドウをアクティブにする
			'UPGRADE_WARNING: オブジェクト pm_vntFromObj.hwnd の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SetForegroundWindow(pm_vntFromObj.hwnd)
			
		End If
		
		On Error GoTo 0
		Exit Function
		
Ctr_Shell_Error_Handler: 
		
		Ctr_Shell = -1
		Resume EXIT_STEP
		
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_TextLength
	'//*
	'//* <戻り値>     型                説明
	'//*              Integer           バイト数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_InString       String          I             対象値
	'//*
	'//* <説  明>
	'//*    テキスト項目のバイト長を計算する
	'//*****************************************************************************************
	Function Get_TextLength(ByVal pm_InString As String) As Short
		
		'//文字をＵＮＩＣＯＤＥから変換した後、バイト計算
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/11 CHG START
        'Get_TextLength = LenB(StrConv(pm_InString, vbFromUnicode))
        Get_TextLength = LenB(pm_InString)
        '2019/04/11 CHG E N D

	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_WaitTime
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     False：失敗、True：正常終了
	'//*
	'//* <引  数>     項目名             型          I/O    内容
	'//*              pm_Wsec           Integer     I      ここで指定した時間（秒）だけ待つ
	'//*
	'//* <説  明>
	'//*    時間待ちルーチン（秒）
	'//*****************************************************************************************
	Function Ctr_WaitTime(ByVal pm_Wsec As Short) As Boolean
		
		Dim LonMin As Integer '//指定秒数
		
		Ctr_WaitTime = False
		
		LonMin = pm_Wsec * 1000 '//Sleepはミリ秒単位なので変換する
		Sleep((LonMin))
		
		Ctr_WaitTime = True
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chg_NumericRound
	'//*
	'//* <戻り値>       型          説明
	'//*                Currency   端数処理結果
	'//*
	'//* <引  数>       項目名          型          I/O     内容
	'//*                pmd_INNUM       Currency    I       対象データ
	'//*                pmi_DISIT       Integer     I       対象小数点位置　1:第１位　  2:第２位　  3:第３位　  4:第４位
	'//*                pmi_SYORIKBN    Integer     I       処理区分　　　  1:切り上げ  2:切り捨て  3:四捨五入
	'//*
	'//* <説  明>
	'//*    数値端数処理を行う
	'//*****************************************************************************************
	Function Chg_NumericRound(ByVal pmd_INNUM As Decimal, ByVal pmi_DISIT As Short, ByVal pmi_SYORIKBN As Short) As Decimal
		
		Dim s_INNUM As String '//文字列に変換した数値
		Dim i_POSITION As Short '//小数点の先頭からの位置
		Dim i_LENGTH As Short '//文字列の文字数
		Dim d_KIRIAGE As Decimal '//切り上げ時加算分
		
		'//処理する数値を文字列に変換する
#Disable Warning BC40000 ' Type or member is obsolete
		s_INNUM = VB6.Format(Trim(Str(pmd_INNUM)), "0.0000")
#Enable Warning BC40000 ' Type or member is obsolete
		
		'//小数点の先頭からの位置を取得
		i_POSITION = InStr(1, s_INNUM, ".", 0)
		
		'//数値(文字列)をパラメータで指定された桁位置まで切りとる
		Select Case pmi_DISIT
			'//小数点第１位
			Case 1
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 1)
				d_KIRIAGE = 1
				
				'//小数点第２位
			Case 2
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 2)
				d_KIRIAGE = 0.1
				
				'//小数点第３位
			Case 3
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 3)
				d_KIRIAGE = 0.01
				
				'//小数点第４位
			Case 4
				s_INNUM = Mid(s_INNUM, 1, i_POSITION + 4)
				d_KIRIAGE = 0.001
		End Select
		
		'//文字数取得
		i_LENGTH = Len(s_INNUM)
		
		'//パラメータの処理区分で,数値の右端の１桁を処理する
		Select Case pmi_SYORIKBN
			'//切り上げ
			Case 1
				If Val(Right(s_INNUM, 1)) > 0 Then
					If Left(s_INNUM, 1) = "-" Then
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) - d_KIRIAGE
					Else
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) + d_KIRIAGE
					End If
				Else
					Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				End If
				
				'//切り捨て
			Case 2
				Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				
				'//四捨五入
			Case 3
				If Val(Right(s_INNUM, 1)) > 4 Then
					If Left(s_INNUM, 1) = "-" Then
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) - d_KIRIAGE
					Else
						Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1)) + d_KIRIAGE
					End If
				Else
					Chg_NumericRound = CDec(Left(s_INNUM, i_LENGTH - 1))
				End If
		End Select
		
	End Function

    '2019/04/11 CHG START
    'Public Sub SetCol_Order(ByVal parLV As System.Windows.Forms.Control)
    Public Sub SetCol_Order(ByVal parLV As ListView)
        '2019/04/11 CHG E N D
        Dim wCNT As Integer

        'UPGRADE_WARNING: オブジェクト parLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'wCNT = parLV.ColumnHeaders.Count
        wCNT = parLV.Columns.Count
        '2019/04/11 CHG E N D

        Call SendMessage(parLV.Handle.ToInt32, LVM_SETCOLUMNORDERARRAY, wCNT, LV_Col_Order(0))

    End Sub
    '2019/04/11 CHG START
    'Public Sub GetCol_Order(ByVal parLV As System.Windows.Forms.Control)
    Public Sub GetCol_Order(ByVal parLV As ListView)
        '2019/04/11 CHG E N D
        Dim wCNT As Integer

        'UPGRADE_WARNING: オブジェクト parLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'wCNT = parLV.ColumnHeaders.Count
        wCNT = parLV.Columns.Count
        '2019/04/11 CHG E N D

        ReDim LV_Col_Order(wCNT - 1)

        Call SendMessage(parLV.Handle.ToInt32, LVM_GETCOLUMNORDERARRAY, wCNT, LV_Col_Order(0))

    End Sub
	Public Sub Mouse_ON()
		'REMARK
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
	End Sub
	Public Sub Mouse_OFF()
		'REMARK
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
End Class