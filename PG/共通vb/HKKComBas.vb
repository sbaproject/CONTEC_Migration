Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

'2019/04/24 ADD START
Imports Oracle.DataAccess.Client
'2019/04/24 ADD E N D

Module HKKCom
    '//*****************************************************************************************
    '//*
    '//*＜名称＞
    '//*    HKKComBas.BAS
    '//*
    '//*＜バージョン＞
    '//*    1.00
    '//*＜作成者＞
    '//*    RISE
    '//*＜説明＞
    '//*    システム関連・共通モジュール
    '//*****************************************************************************************
    '//* CHANGE HISTORY
    '//* Version  |YYYYMMDD|Programmer     |Description
    '//* ---------|--------|---------------|---------------------------------------------------*
    '//* 1.00     |20060705|Rise)          |新規
    '//* 1.10     |20060904|Rise)          |FMMAXのメニューからの起動対応
    '//* 1.10     |20080124|Rise)          |FMMAXの開始／終了ログを出力する。
    '//* 1.10     |20080215|Rise)          |FMMAXの開始／終了ログのパスが無くてもエラーとしない。
    '//* 　　     |        | 　　　　　　　|（バッチはログなしだが同一処理をする為）
    '//* 1.11     |20081202|Rise)          |↑↓が正しく表示されない
    '//*****************************************************************************************

    '2019/04/12 ADD START
    Public CON As OracleConnection = Nothing
    '2019/04/12 ADD E N D

    '2019/05/08 ADD START
    Public CON_USR9 As OracleConnection = Nothing
    '2019/05/08 ADD E N D

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    '2019/04/11 ADD START
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/04/11 ADD E N D

    '2019/04/16 ADD START
    ''ListViewItemSorterに指定するフィールド
    'Public listViewItemSorter As ListViewItemComparer
    '上矢印
    Public CON_ARROW_UP As String = "↑"
    '下矢印
    Public CON_ARROW_DOWN As String = "↓"
    '2019/04/16 ADD E N D

    '20190710 ADD START　←　AE_CMNに同様の記載あり
    Public GV_UNYDate As String '運用日付
    '20190710 ADD END


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
	'// ファイルパス
	'//-----------------------------------------------------------------------------------------
    '// 2015/05/29 UPD STT
    '2019/04/12 DEL START
    'Public Const gvcst_IniFilePath As String = "..\ENV\SSSWIN.INI" '//INI File Path
    '2019/04/12 DEL E N D
    'Public Const gvcst_IniFilePath         As String = "\\ammlw01\C$\FMMAX\CNT\ENV\SSSWIN.INI"  '//INI File Path
	'// 2015/05/29 UPD END
	'// 2008/01/24 ADD STT
	Public Const gvcst_IniFilePath2 As String = "C:\Documents and Settings" '//FM_MAX用 INI File Path2 + Wsno + Path3
	Public Const gvcst_IniFilePath3 As String = "\WINDOWS\SSSWIN.INI" '//FM_MAX用
	'// 2008/01/24 ADD END
	
	Public Const gvcst_BatFilePath As String = "..\BAT\" '//BAT File Path
	Public Const gvcst_BinFilePath As String = "..\BIN\" '//EXE File Path
	Public Const gvcst_RptFilePath As String = "..\RPT\" '//CrystalReport File Path
	Public Const gvcst_LogFilePath As String = "..\LOG\" '//LOG File Path
	Public Const gvcst_SqlFilePath As String = "..\SQL\" '//Sql File Path
	Public Const gvcst_TmpFilePath As String = "..\TMP\" '//TMP File Path
	Public Const gvcst_BakFilePath As String = "..\BKUP\" '//BAK File Path
	
	'//-----------------------------------------------------------------------------------------
	'// ＩＮＩ情報構造体
	'//-----------------------------------------------------------------------------------------
	Public Structure gvtypIniFile
		Dim strSQLDATABASE As String '//データベース名
		Dim strSQLUID As String '//ユーザーID
		Dim strSQLPWD As String '//パスワード
		'//2008/01/24 ADD START
		Dim strLOGPATH As String '//ログ出力先 FM_MAX
		'//2008/01/24 ADD END
	End Structure

    '2019/04/16 DEL START
    'Public Enum gvcstSortOrder
    '    intAscending = 0 '//全て
    '    intDescending = 1 '//ヘッダー入力1
    'End Enum
    '2019/04/16 DEL E N D

    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
    '// 2008/01/24 ADD START
    '==========================================================================
    '   SYSTBE       運用ログ定義体                                           =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_SYSTBE
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public PRGID() As Char 'プログラムID          X(8)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(60),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=60)> Public LOGNM() As Char '備考(ｴﾗｰ情報・運用)   X(60)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      X(8)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      X(05)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ（時間）      9(06)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ（日付）      9(08)
    'End Structure
    '   Public DB_SYSTBE As TYPE_DB_SYSTBE
    'Public DBN_SYSTBE As Short
    '20190611 del end
    
	'ファイル構造体初期化用データ
	Structure DB_CLRDAT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(2048),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2048)> Public FILLER() As Char '初期化データ
	End Structure
	Public DB_CLRREC As DB_CLRDAT
	'// 2008/01/24 ADD END
	'//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
	
	'//-----------------------------------------------------------------------------------------
	'// 入力モード
	'//-----------------------------------------------------------------------------------------
	Public Enum gvcstInputCls
		ModeAll = 0 '//全て
		Header1 = 1 '//ヘッダー入力1
		Header2 = 2 '//ヘッダー入力2
		Header3 = 3 '//ヘッダー入力3
		Detail1 = 11 '//明細入力1
		Detail2 = 12 '//明細入力2
		Detail3 = 13 '//明細入力3
		Detail4 = 14 '//明細入力4
		Detail5 = 15 '//明細入力5
		Tail1 = 11 '//テール入力1
		Tail2 = 11 '//テール入力2
		Tail3 = 11 '//テール入力3
		Tail4 = 11 '//テール入力4
		Tail5 = 11 '//テール入力5
		Etc1 = 91 '//その他１
		Etc2 = 92 '//その他２
		Etc3 = 93 '//その他３
	End Enum
	
	'//-----------------------------------------------------------------------------------------
	'// ＰＧ起動パラメータ　　定義
	'//-----------------------------------------------------------------------------------------
	Public gvstrCLTID As String '//端末番号
	Public gvstrOPEID As String '//ログイン担当者コード
	
    '2019/04/12 CHG START
    'Public gvobjInfTraDynaset As Object
    Private gvobjInfTraDynaset As DataTable = Nothing
    '2019/04/12 CHG E N D

	Structure LvFormatMs_REC
		Dim TANCD As String
		Dim FRMID As String
		Dim LTVID As String
		Dim INQITM As String
		Dim ADKB As String
		<VBFixedArray(26)> Dim Item() As String
		<VBFixedArray(26)> Dim Text() As String
		<VBFixedArray(26)> Dim SIZE() As Double
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			'UPGRADE_WARNING: 配列 Item の下限が 1 から 0 に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"' をクリックしてください。
			ReDim Item(26)
			'UPGRADE_WARNING: 配列 Text の下限が 1 から 0 に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"' をクリックしてください。
			ReDim Text(26)
			'UPGRADE_WARNING: 配列 SIZE の下限が 1 から 0 に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"' をクリックしてください。
			ReDim SIZE(26)
		End Sub
	End Structure
	
	'UPGRADE_WARNING: 構造体 LvFormatMsBuf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public LvFormatMsBuf As LvFormatMs_REC
	
	Public LV_Col_Order() As Integer
	Public LV_Col_Order_CHK() As Integer
	
	'------------------------------------------------------------------------------
	'  関数名   chkHTATRA
	'  機能     排他制御ﾌｧｲﾙ検索
	'  引数　   strPERSON     As string (IN)  : 担当者
	'  　　　   strSTRSTS     As string (IN)  : 起動区分       1:初回登録時 H:排他検査時 9:終了時
	'  　　　   strSTRPG      As string (IN)  : 起動プログラム
	'  　　　   strHAITAPG1   As string (IN)  : 排他プログラム１
	'  　　　   strHAITAPG2   As string (IN)  : 排他プログラム２
	'  　　　   strHAITAPG3   As string (IN)  : 排他プログラム３
	'  返値　   Integer型  0:正常 9:異常
	'  備考　   なし
	'------------------------------------------------------------------------------
	Public Function ChkHTATRA(ByVal strPERSON As String, ByVal strSTARTSTS As String, ByVal strSTARTPG As String, Optional ByVal strHAITAPG1 As String = vbNullString, Optional ByVal strHAITAPG2 As String = vbNullString, Optional ByVal strHAITAPG3 As String = vbNullString) As Short
		
		Const PROCEDURE As String = "ChkHTATRA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/19 CHG START
        'Dim objRec As OraDynaset
        Dim dt As DataTable = Nothing
        '2019/04/19 CHG E N D
		Dim intCount As Short
		Dim strWHERE As String
		
		On Error GoTo ONERR_STEP
		
		If strHAITAPG1 <> "" Or strHAITAPG2 <> "" Or strHAITAPG3 <> "" Then
			strWHERE = " GYMCD In ("
			If strHAITAPG1 <> "" Then
				'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strWHERE = strWHERE & D0.Edt_SQL("S", strHAITAPG1) & ","
			End If
			If strHAITAPG2 <> "" Then
				'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strWHERE = strWHERE & D0.Edt_SQL("S", strHAITAPG2) & ","
			End If
			If strHAITAPG3 <> "" Then
				'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strWHERE = strWHERE & D0.Edt_SQL("S", strHAITAPG3) & ","
			End If
			strWHERE = Mid(Trim(strWHERE), 1, Len(Trim(strWHERE)) - 1)
			strWHERE = strWHERE & ")"
		Else
			strWHERE = ""
		End If
		
		Select Case strSTARTSTS
			Case "1"
				strSQL = ""
				strSQL = strSQL & "DELETE                             " & vbCrLf
				strSQL = strSQL & "FROM   HTATRA                      " & vbCrLf
				strSQL = strSQL & "WHERE  TANID  = '" & strPERSON & "'" & vbCrLf
				strSQL = strSQL & "AND    CLTID  = '" & gvstrCLTID & "'" & vbCrLf
                '2019/04/12 CHG START
                'clsOra.OraExecute(strSQL)
                Call DB_Execute(strSQL)
                '2019/04/12 CHG E N D

				If strWHERE <> "" Then
					strSQL = ""
					strSQL = strSQL & "SELECT *             " & vbCrLf
					strSQL = strSQL & "FROM   HTATRA        " & vbCrLf
					strSQL = strSQL & "WHERE  " & strWHERE & vbCrLf
					'ﾚｺｰﾄﾞｾｯﾄ獲得
                    'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                    '2019/04/19 ADD START
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/04/19 ADD E N D
                    'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                    '2019/04/19 ADD START
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        ChkHTATRA = 9
                        Exit Function
                    End If
                    '2019/04/19 ADD E N D
                End If
				strSQL = ""
				strSQL = strSQL & "SELECT *               " & vbCrLf
				strSQL = strSQL & "FROM   HTATRA          " & vbCrLf
				strSQL = strSQL & "WHERE  TANID  = '" & strPERSON & "'" & vbCrLf
				'ﾚｺｰﾄﾞｾｯﾄ獲得
                'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                '2019/04/19 ADD START
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/04/19 ADD E N D

				'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                '2019/04/19 ADD START
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    strSQL = ""
                    strSQL = strSQL & "UPDATE HTATRA                       " & vbCrLf
                    strSQL = strSQL & "SET    GYMCD  = '" & strSTARTPG & "'" & vbCrLf
                    strSQL = strSQL & "WHERE  TANID  = '" & strPERSON & "' " & vbCrLf
                    Call DB_Execute(strSQL)
                Else
                    strSQL = ""
                    strSQL = "INSERT INTO HTATRA                           " & vbCrLf
                    strSQL = strSQL & "(TANID                              " & vbCrLf
                    strSQL = strSQL & ",GYMCD                              " & vbCrLf
                    strSQL = strSQL & ",OPEID                              " & vbCrLf
                    strSQL = strSQL & ",CLTID                              " & vbCrLf
                    strSQL = strSQL & ",WRTTM                              " & vbCrLf
                    strSQL = strSQL & ",WRTDT                              " & vbCrLf
                    strSQL = strSQL & ",WRTFSTTM                           " & vbCrLf
                    strSQL = strSQL & ",WRTFSTDT                           " & vbCrLf
                    strSQL = strSQL & ")                                   " & vbCrLf
                    strSQL = strSQL & "VALUES                              " & vbCrLf
                    strSQL = strSQL & "( '" & strPERSON & "'               " & vbCrLf
                    strSQL = strSQL & ",'" & strSTARTPG & "'               " & vbCrLf
                    strSQL = strSQL & ",'" & strPERSON & "'                " & vbCrLf
                    strSQL = strSQL & ",'" & gvstrCLTID & "' " & vbCrLf
                    strSQL = strSQL & ",'" & OraGetNowTm() & "'       " & vbCrLf
                    strSQL = strSQL & ",'" & OraGetNowDt() & "'       " & vbCrLf
                    strSQL = strSQL & ",'" & OraGetNowTm() & "'       " & vbCrLf
                    strSQL = strSQL & ",'" & OraGetNowDt() & "'       " & vbCrLf
                    strSQL = strSQL & ")                                   " & vbCrLf
                    Call DB_Execute(strSQL)
                End If
                '2019/04/19 ADD E N D
                ChkHTATRA = 0
				Exit Function
			Case "H"
				If strWHERE <> "" Then
					strSQL = ""
					strSQL = strSQL & "SELECT *             " & vbCrLf
					strSQL = strSQL & "FROM   HTATRA        " & vbCrLf
					strSQL = strSQL & "WHERE  " & strWHERE & vbCrLf
					'ﾚｺｰﾄﾞｾｯﾄ獲得
                    'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                    '2019/04/19 ADD START
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/04/19 ADD E N D
                    'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                    '2019/04/19 ADD START
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        ChkHTATRA = 9
                        Exit Function
                    End If
                    '2019/04/19 ADD E N D
				End If
				ChkHTATRA = 0
				Exit Function
			Case "9"
				strSQL = ""
				strSQL = strSQL & "SELECT *                           " & vbCrLf
				strSQL = strSQL & "FROM   HTATRA                      " & vbCrLf
				strSQL = strSQL & "WHERE  TANID  = '" & strPERSON & "'" & vbCrLf
				'ﾚｺｰﾄﾞｾｯﾄ獲得
                'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                '2019/04/19 ADD START
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/04/19 ADD E N D
                'UPGRADE_WARNING: ChkHTATRA に変換されていないステートメントがあります。ソース コードを確認してください。
                '2019/04/19 ADD START
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    strSQL = ""
                    strSQL = strSQL & "DELETE                             " & vbCrLf
                    strSQL = strSQL & "FROM   HTATRA                      " & vbCrLf
                    strSQL = strSQL & "WHERE  TANID  = '" & strPERSON & "'" & vbCrLf
                    Call DB_Execute(strSQL)
                End If
                '2019/04/19 ADD E N D
				ChkHTATRA = 0
				Exit Function
		End Select
		
		ChkHTATRA = 0
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_CommandLine
	'//*
	'//* <戻り値>
	'//*              True    :正常終了
	'//*              False   :異常終了
	'//*
	'//* <引  数>     項目名             I/O      内容
	'//*            　pmt_CommandLine　　I/O      コマンドライン構造体
	'//* <説  明>
	'//*    コマンドラインの引数を取得する
	'//**************************************************************************************
	Public Function Get_CommandLine() As Boolean
		
		Const PROCEDURE As String = "Get_CommandLine"
		
		Dim Str_GetCmdLine As String
		Dim lng_GetCmdLineLen As Integer
		Dim vntArray As Object
		
		On Error GoTo ONERR_STEP
		
		Get_CommandLine = False
		
		'//V1.10 2006/09/02  CHG START  RISE)
		Str_GetCmdLine = VB.Command()
		'    Str_GetCmdLine = Trim(StrConv(Command(), vbUpperCase))
		'//V1.10 2006/09/02  CHG END
		lng_GetCmdLineLen = Len(Str_GetCmdLine)
		
		If lng_GetCmdLineLen = 0 Then
			GoTo EXIT_STEP
		End If
		
		'//コマンドラインの解析
		'UPGRADE_WARNING: オブジェクト vntArray の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		vntArray = Split(Str_GetCmdLine, " ")
		
		'//V1.10 2006/09/02  CHG START  RISE)
		'//端末ＩＤ
		'UPGRADE_WARNING: オブジェクト vntArray() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvstrCLTID = Mid(vntArray(0), 2, 5)
		'//ログイン担当者コード
		'UPGRADE_WARNING: オブジェクト vntArray() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvstrOPEID = Mid(vntArray(0), 7, 8)
		
		'    '//コマンドラインの解析
		'    vntArray = Split(Str_GetCmdLine)
		'
		'    '//端末ＩＤ
		'    If Len(vntArray(0)) = 0 Then
		'        GoTo ERROR_STEP
		'    Else
		'        gvstrCLTID = vntArray(0)
		'    End If
		'
		'    '//ログイン担当者コード
		'    If Len(vntArray(1)) = 0 Then
		'        GoTo ERROR_STEP
		'    Else
		'        gvstrOPEID = vntArray(1)
		'    End If
		'//V1.10 2006/09/02  CHG END
		
		Get_CommandLine = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ERROR_STEP: 
		MsgBox("【" & Trim(gvcstJOB_Titl) & "】はパラメータの取得に失敗しました。処理を中止します。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, My.Application.Info.Title)
		GoTo EXIT_STEP
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_CommandLineByPosition
	'//*
	'//* <戻り値>
	'//*              True    :正常終了
	'//*              False   :異常終了
	'//*
	'//* <引  数>   項目名              I/O     内容
	'//*            pmiPosition         I       パラメータ項目順番(1,2はシステム共通なので3以降)
	'//*            pmsValue            O       パラメータ内容
	'//*
	'//* <説  明>
	'//*    コマンドラインから指定した位置のアプリケーション固有引数を取得する
	'//**************************************************************************************
	Public Function Get_CommandLineByPosition(ByVal pmiPosition As Short, ByRef pmsValue As String) As Boolean
		
		Const PROCEDURE As String = "Get_CommandLineByPosition"
		
		Dim strCmdLine As String
		Dim vntArray As Object
		
		Get_CommandLineByPosition = False
		pmsValue = ""
		
		strCmdLine = Trim(StrConv(VB.Command(), VbStrConv.UpperCase))
		
		If Len(strCmdLine) = 0 Then
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト vntArray の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		vntArray = Split(strCmdLine)
		
		If UBound(vntArray) < pmiPosition - 1 Then
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト vntArray() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pmsValue = vntArray(pmiPosition - 1)
		
		Get_CommandLineByPosition = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    GetIniFile
	'//*
	'//* <戻り値>
	'//*              True    :読込みＯＫ
	'//*              False   :読込みＥＲＲ
	'//*
	'//* <引  数>     項目名             I/O      内容
	'//*              pmtIni             I       ＩＮＩファイル情報
	'//*
	'//* <説  明>
	'//*    システム共通初期設定ファイル(INIﾌｧｲﾙ)の読込み処理
	'//*****************************************************************************************
	Public Function GetIniFile(ByRef pmtIni As gvtypIniFile) As Boolean
		
		Const PROCEDURE As String = "GetIniFile"
		Const IniFileSection As String = "HKK_DBConnection" '//Ini Section Name
		'// 2008/01/24 ADD STT
		Const IniFileSection2 As String = "DAT_PATH" '//Ini Section Name log_file
		Dim str_log_pas As String
		'// 2008/01/24 ADD END
		
		Dim wk_String As String
		Dim str_Section As String
		Dim str_Key As String
		Dim str_Path As String
		
		On Error GoTo ONERR_STEP
		
		GetIniFile = False
		
		wk_String = ""
		
		'実PATH取得
        '// 2015/05/29 UPD STT
        '2019/04/12 CHG START
        'str_Path = GetFullPath(gvcst_IniFilePath)
        str_Path = Application.StartupPath & "\SSSWIN.INI"
        '2019/04/12 CHG E N D
		'    str_Path = gvcst_IniFilePath
		'// 2015/05/29 UPD END
		
		'//-------------------------------------------------------------
		
		'//データベース名 取得
		str_Key = "DBNAME"
		wk_String = D0.GetIniString(IniFileSection, str_Key, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		
		pmtIni.strSQLDATABASE = wk_String
		
		'//ログインＩＤ 取得
		str_Key = "LOGINID"
		wk_String = D0.GetIniString(IniFileSection, str_Key, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		
		pmtIni.strSQLUID = wk_String
		
		'//パスワード 取得
		str_Key = "PASSWORD"
		wk_String = D0.GetIniString(IniFileSection, str_Key, str_Path)
		If Trim(wk_String) = "" Then
			GoTo ERROR_STEP
		End If
		
		pmtIni.strSQLPWD = wk_String
		
		'//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
		'// 2008/01/24 ADD STT
		'実PATH取得
		str_Path = gvcst_IniFilePath2 & "\" & gvstrCLTID & gvcst_IniFilePath3
		'//ログ出力ファイル名 取得
		'CHG START FKS)INABA 2010/08/11 ****************************************************************************
		'連絡票№FC10081101
		wk_String = D0.GetIniString("SSSWIN", "DAT_PATH", "SSSWIN.INI")
		'    wk_String = D0.GetIniString("SSSWIN", "DAT_PATH", str_Path)
		'CHG  END  FKS)INABA 2010/08/11 ****************************************************************************
		
		'// 20080215 DEL START　バッチから呼ばれる場合はＩＮＩファイルがちがうので取得できないのでNullでもＯＫとする。
		'//    If Trim(wk_String) = "" Then
		'//        GoTo ERROR_STEP
		'//    End If
		'// 20080215 DEL END
		pmtIni.strLOGPATH = wk_String
		'// 2008/01/24 ADD END
		'//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
		
		GetIniFile = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ERROR_STEP: 
		MsgBox("【" & Trim(gvcstJOB_Titl) & "】はＩＮＩファイルの取得に失敗しました。処理を中止します。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, My.Application.Info.Title)
		GoTo EXIT_STEP
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    GetFullPath
	'//*
	'//* <戻り値>
	'//*              ""    :存在しない
	'//*              <>""  :フォルダー存在
	'//*
	'//* <引  数>     項目名             I/O      内容
	'//*              pms_FolderNM       I       フォルダー名
	'//*                                         例 "..\INI" , "..\..\INI" , "INI"
	'//*                                         (フォルダー名INIが記述されていれば上記のいずれでも指定可能)
	'//* <説  明>
	'//*    実フォルダーのパスを取得する
	'//*****************************************************************************************
	Public Function GetFullPath(ByVal pms_FolderNM As String) As String
		
		Const PROCEDURE As String = "GetFullPath"

        '2019/04/24 CHG START
        'Const cst_UpPATH As String = "..\"

        'Dim str_FolderNM As String
        'Dim str_FileNM As String
        'Dim bln_Exist As Boolean
        'Dim bln_FolderExist As Boolean
        'Dim str_MyPath As String
        'Dim vnt_MyName As Object
        'Dim i As Short

        'On Error GoTo ONERR_STEP

        'GetFullPath = ""

        ''//引数PATH名からPATH名のみを取り出す
        'str_FolderNM = ""
        'str_FileNM = ""
        'bln_Exist = False

        'For i = 1 To Len(pms_FolderNM)
        '	Select Case Mid(pms_FolderNM, i, 1)
        '		Case "."
        '			If str_FileNM <> "" Then
        '				str_FileNM = str_FileNM & Mid(pms_FolderNM, i, 1)
        '			End If
        '		Case "\"
        '			bln_Exist = True
        '			If str_FolderNM <> "" Then
        '				bln_Exist = False
        '			End If
        '		Case Else

        '			If bln_Exist Then
        '				str_FolderNM = str_FolderNM & Mid(pms_FolderNM, i, 1)
        '			End If
        '			If Not bln_Exist Then
        '				str_FileNM = str_FileNM & Mid(pms_FolderNM, i, 1)
        '			End If
        '	End Select
        'Next i

        ''//2003/07/01
        ''//V1.10 2006/09/02  CHG START  RISE)
        ''    ChDrive App.Path
        ''//V1.10 2006/09/02  CHG END
        'ChDir(My.Application.Info.DirectoryPath)

        'str_MyPath = ""
        'bln_FolderExist = True

        'Do While bln_FolderExist

        '	'//１つ上の上位階層から検索する
        '	'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '	'UPGRADE_WARNING: オブジェクト vnt_MyName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	vnt_MyName = Dir(str_MyPath, FileAttribute.Directory) ' 最初のフォルダ名を返します。

        '	bln_FolderExist = False
        '	'UPGRADE_WARNING: オブジェクト vnt_MyName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	Do While vnt_MyName <> ""
        '		'//2007/08/29 //////////////////////////////////////////////////////////////////////////////////////////////////////
        '		On Error Resume Next
        '		'//2007/08/29 //////////////////////////////////////////////////////////////////////////////////////////////////////

        '		Select Case vnt_MyName
        '			Case "."
        '			Case ".."
        '				bln_FolderExist = True
        '			Case Else
        '				'UPGRADE_WARNING: オブジェクト vnt_MyName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				If (GetAttr(str_MyPath & vnt_MyName) And FileAttribute.Directory) = FileAttribute.Directory Then
        '					'UPGRADE_WARNING: オブジェクト vnt_MyName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '					If StrConv(vnt_MyName, VbStrConv.UpperCase) = StrConv(str_FolderNM, VbStrConv.UpperCase) Then
        '						GetFullPath = str_MyPath & str_FolderNM & IIf(str_FileNM <> "", "\" & str_FileNM, "")
        '						GoTo EXIT_STEP
        '					End If
        '				End If
        '		End Select

        '		'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト vnt_MyName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		vnt_MyName = Dir()
        '	Loop 

        '	'//１つ上の上位階層から検索する
        '	str_MyPath = str_MyPath & cst_UpPATH ' パスを設定します。(１階層上)

        '      Loop
        GetFullPath = System.IO.Path.GetFullPath(pms_FolderNM)
        '2019/04/24 CHG E N D
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//****************************************************************************************
	'//*
	'//* <名  称>
	'//*    SetFormInit
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*              pm_Form             I       フォーム
	'//*              pm_Kbn              I       フォーム表示方法区分
	'//*                                          0:フォームをデフォルトサイズに設定
	'//*                                          1:フォームサイズを設定しない
	'//* <説  明>
	'//*    画面の初期設定
	'//*****************************************************************************************
	Public Sub SetFormInit(ByVal pm_Form As System.Windows.Forms.Form, Optional ByVal pm_Kbn As Short = 0)
		
		Const PROCEDURE As String = "SetFormInit"
		
		Dim i As Short
		
		On Error GoTo ONERR_STEP
		
		With pm_Form
			If pm_Kbn = 0 Then
				.Height = VB6.TwipsToPixelsY(11520) '//高さ
				.Width = VB6.TwipsToPixelsX(15360) '//幅
			End If
			
			'//画面表示状態
			.WindowState = System.Windows.Forms.FormWindowState.Normal
			
			'//フォームのキーボードイベントを先に実行
			.KeyPreview = True
			
			'//画面中央に表示（センタリング）
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
			
		End With
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    ChgMaeZero
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pm_lng_ProcCLS      Long             I      0:画面全体, 1:ヘッダ部, 2:明細部
	'//*
	'//* <説  明>
	'//*    前ゼロ処理
	'//*****************************************************************************************
	Public Function ChgMaeZero(ByRef pmo_object As Object) As Boolean
		
		Const PROCEDURE As String = "ChgMaeZero"
		
		Dim dtaToday As Date
		
		ChgMaeZero = True
		
		On Error GoTo ONERR_STEP
		
		'//年チェック
		'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(pmo_object.Text) <> "" Then
			'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pmo_object.MaxLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pmo_object.Text = VB6.Format(pmo_object.Text, New String("0", pmo_object.MaxLength))
		End If
		
		ChgMaeZero = False
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    ChgObjectFormat
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pms_Kubun           Object           I      編集タイプ
	'//*            pmo_object          Object           I      編集対象コントロール
	'//*            pmi_Mode            Object           I      使用フォーマット(1:GotFocus 2:LostFocus)
	'//*
	'//* <説  明>
	'//*    数値型フォーマット編集処理
	'//*****************************************************************************************
	Public Function ChgObjectFormat(ByVal pms_Kubun As String, ByRef pmo_object As Object, ByVal pmi_Mode As Short) As Boolean
		
		Const PROCEDURE As String = "ChgObjectFormat"
		
		Dim vntValue As Object
		Dim vntFormat As Object
		Dim blnChgOK As Boolean
		
		ChgObjectFormat = True
		
		On Error GoTo ONERR_STEP
		
		'//編集フォーマット取得
		'UPGRADE_WARNING: オブジェクト vntFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		vntFormat = ""
		'UPGRADE_WARNING: オブジェクト pmo_object.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(pmo_object.Tag) <> "" Then
			Select Case pmi_Mode
				Case 1
					'UPGRADE_WARNING: オブジェクト pmo_object.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト vntFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					vntFormat = Left(pmo_object.Tag, InStr(pmo_object.Tag, ";") - 1)
				Case 2
					'UPGRADE_WARNING: オブジェクト pmo_object.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト vntFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					vntFormat = Mid(pmo_object.Tag, InStr(pmo_object.Tag, ";") + 1)
			End Select
		End If
		
		'//編集値の確認と取得
		blnChgOK = False
		Select Case pms_Kubun
			Case "N"
				'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If IsNumeric(pmo_object.Text) Then
					blnChgOK = True
					'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					vntValue = CDec(pmo_object.Text)
				Else
					'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					vntValue = pmo_object.Text
				End If
			Case "D"
				Select Case pmi_Mode
					Case 1
						'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If IsDate(pmo_object.Text) Then
							blnChgOK = True
							'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							vntValue = CDate(pmo_object.Text)
						Else
							'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							vntValue = pmo_object.Text
						End If
					Case 2
						'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If IsDate(Mid(pmo_object.Text, 1, 4) & "/" & Mid(pmo_object.Text, 5, 2) & "/" & Mid(pmo_object.Text, 7, 2)) Then
							blnChgOK = True
							'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							vntValue = CDate(Mid(pmo_object.Text, 1, 4) & "/" & Mid(pmo_object.Text, 5, 2) & "/" & Mid(pmo_object.Text, 7, 2))
						Else
							'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							vntValue = pmo_object.Text
						End If
				End Select
		End Select
		
		'UPGRADE_WARNING: オブジェクト vntFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If vntFormat <> "" And blnChgOK Then
			'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vntFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pmo_object.Text = VB6.Format(vntValue, vntFormat)
		Else
			'UPGRADE_WARNING: オブジェクト pmo_object.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vntValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pmo_object.Text = vntValue
		End If
		
		ChgObjectFormat = False
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		Resume EXIT_STEP
	End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    SetLvFormat
    '//*
    '//* <戻り値>   型                  説明
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            pms_FORM_ID         String           I      画面ＩＤ
    '//*            pms_ListView        ListView         I      編集対象コントロール(ListView)
    '//*
    '//* <説  明>
    '//*    リストビューフォーマット編集処理
    '//*****************************************************************************************
    '2019/04/11 CHG START
    'Public Sub SetLvFormat(ByRef pms_FORM_ID As String, ByRef pms_ListView As System.Windows.Forms.Control)
    '    Dim wIDX As Short
    '    Dim wERR As Short
    '    Dim wKEY() As String
    '    Dim wIDX_CHK As Short
    '    Dim wIndex As Integer

    '    With pms_ListView

    '        wERR = 0
    '        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        ReDim LV_Col_Order(.ColumnHeaders.Count - 1)
    '        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        ReDim LV_Col_Order_CHK(.ColumnHeaders.Count - 1)
    '        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        ReDim wKEY(.ColumnHeaders.Count - 1)
    '        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        For wIDX = 0 To .ColumnHeaders.Count - 1
    '            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            wKEY(wIDX) = .ColumnHeaders(wIDX + 1).Key
    '        Next wIDX
    '        If GetLvFormatMS(pms_FORM_ID) Then
    '            Call ToLvFormatMsBuf()
    '            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            For wIDX = 0 To .ColumnHeaders.Count - 1
    '                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                For wIDX_CHK = 0 To .ColumnHeaders.Count - 1
    '                    wERR = -1
    '                    If wKEY(wIDX_CHK) = Trim(LvFormatMsBuf.Item(wIDX + 1)) Then
    '                        wERR = 0
    '                        Exit For
    '                    End If
    '                Next wIDX_CHK
    '                If wERR = 0 Then
    '                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    LV_Col_Order(wIDX) = .ColumnHeaders(Trim(LvFormatMsBuf.Item(wIDX + 1))).Index - 1
    '                    If ChkCol_Order(LV_Col_Order(wIDX)) <> 0 Then
    '                        wERR = -1
    '                        Exit For
    '                    End If
    '                End If
    '            Next wIDX
    '            If wERR = 0 Then
    '                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                For wIDX = 0 To .ColumnHeaders.Count - 1
    '                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .ColumnHeaders(Trim(LvFormatMsBuf.Item(wIDX + 1))).Width = LvFormatMsBuf.SIZE(wIDX + 1)
    '                Next wIDX
    '                Call D0.SetCol_Order(pms_ListView)
    '                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                wIndex = .ColumnHeaders(Trim(LvFormatMsBuf.INQITM)).Index - 1
    '                'UPGRADE_WARNING: オブジェクト pms_ListView.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .SortKey = wIndex
    '                If LvFormatMsBuf.ADKB = "A" Then
    '                    '//V1.11 ↓ UPD
    '                    '                    .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text = "↓" & .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text
    '                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .ColumnHeaders(wIndex + 1).Text = "↓" & .ColumnHeaders(wIndex + 1).Text
    '                    '//V1.11 ↑ UPD
    '                Else
    '                    '//V1.11 ↓ UPD
    '                    '                    .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text = "↑" & .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text
    '                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .ColumnHeaders(wIndex + 1).Text = "↑" & .ColumnHeaders(wIndex + 1).Text
    '                    '//V1.11 ↑ UPD
    '                End If
    '                Call SortLv(pms_ListView, wIndex, LvFormatMsBuf.ADKB)
    '                Exit Sub
    '            End If
    '        Else
    '            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .ColumnHeaders(1).Text = "↓" & .ColumnHeaders(1).Text
    '        End If
    '    End With
    'End Sub 
    Public Sub SetLvFormat(ByRef pms_FORM_ID As String, ByRef pms_ListView As ListView, ByRef pSortOrder As SortOrder, ByRef pInitSortColumn As Integer)
        Dim wIDX As Short
        Dim wERR As Short
        Dim wKEY() As String
        Dim wIDX_CHK As Short
        Dim wIndex As Integer

        With pms_ListView

            wERR = 0
            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ReDim LV_Col_Order(.Columns.Count - 1)
            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ReDim LV_Col_Order_CHK(.Columns.Count - 1)
            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ReDim wKEY(.Columns.Count - 1)
            'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            For wIDX = 0 To .Columns.Count - 1
                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/12 CHG START
                'wKEY(wIDX) = .Columns(wIDX + 1).Name
                wKEY(wIDX) = .Columns(wIDX).Name
                '2019/04/12 CHG E N D
            Next wIDX
            If GetLvFormatMS(pms_FORM_ID) Then
                Call ToLvFormatMsBuf()
                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                For wIDX = 0 To .Columns.Count - 1
                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    For wIDX_CHK = 0 To .Columns.Count - 1
                        wERR = -1
                        If wKEY(wIDX_CHK) = Trim(LvFormatMsBuf.Item(wIDX + 1)) Then
                            wERR = 0
                            Exit For
                        End If
                    Next wIDX_CHK
                    If wERR = 0 Then
                        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/12 CHG START
                        ''LV_Col_Order(wIDX) = .Columns(Trim(LvFormatMsBuf.Item(wIDX + 1))).Index - 1
                        LV_Col_Order(wIDX) = .Columns(Trim(LvFormatMsBuf.Item(wIDX + 1))).Index
                        '2019/04/12 CHG E N D
                        If ChkCol_Order(LV_Col_Order(wIDX)) <> 0 Then
                            wERR = -1
                            Exit For
                        End If
                    End If
                Next wIDX
                If wERR = 0 Then
                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    For wIDX = 0 To .Columns.Count - 1
                        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Columns(Trim(LvFormatMsBuf.Item(wIDX + 1))).Width = LvFormatMsBuf.SIZE(wIDX + 1)
                    Next wIDX
                    Call D0.SetCol_Order(pms_ListView)
                    'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/12 CHG START
                    'wIndex = .Columns(Trim(LvFormatMsBuf.INQITM)).Index - 1
                    wIndex = .Columns(Trim(LvFormatMsBuf.INQITM)).Index
                    '2019/04/12 CHG E N D
                    '2019/04/24 ADD START
                    pInitSortColumn = .Columns(Trim(LvFormatMsBuf.INQITM)).Index
                    '2019/04/24 ADD E N D
                    'UPGRADE_WARNING: オブジェクト pms_ListView.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/16 DEL START
                    '.SortKey = wIndex
                    '2019/04/16 DEL E N D
                    If LvFormatMsBuf.ADKB = "A" Then

                        '2019/04/16 ADD START
                        pSortOrder = SortOrder.Descending
                        '2019/04/16 ADD E N D

                        '//V1.11 ↓ UPD
                        '.ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text = "↓" & .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text
                        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/12 CHG START
                        '.Columns(wIndex + 1).Text = "↓" & .Columns(wIndex + 1).Text
                        .Columns(wIndex).Text = CON_ARROW_DOWN & .Columns(wIndex).Text
                        '2019/04/12 CHG E N D
                        '//V1.11 ↑ UPD
                    Else

                        '2019/04/16 ADD START
                        pSortOrder = SortOrder.Ascending
                        '2019/04/16 ADD E N D

                        '//V1.11 ↓ UPD
                        '.ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text = "↑" & .ColumnHeaders(Trim$(LvFormatMsBuf.Item(wIndex + 1))).Text
                        'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/12 CHG START
                        '.Columns(wIndex + 1).Text = "↑" & .Columns(wIndex + 1).Text
                        .Columns(wIndex).Text = CON_ARROW_UP & .Columns(wIndex).Text
                        '2019/04/12 CHG E N D
                        '//V1.11 ↑ UPD
                    End If
                    '2019/04/16 DEL START
                    'Call SortLv(pms_ListView, wIndex, LvFormatMsBuf.ADKB)
                    '2019/04/16 DEL E N D
                    Exit Sub
                End If
            Else
                'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/16 CHG START
                '.Columns(1).Text = "↓" & .Columns(1).Text
                .Columns(1).Text = CON_ARROW_DOWN & .Columns(0).Text
                '2019/04/16 CHG E N D
            End If
        End With
    End Sub
    '2019/04/11 CHG E N D
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    GetLvFormatMS
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            pms_DisplayID       String           I      画面ＩＤ
    '//*
    '//* <説  明>
    '//*    前回の画面表示順情報を取得する
    '//*****************************************************************************************
    Public Function GetLvFormatMS(ByRef pms_DisplayID As String) As Boolean
		
		Const PROCEDURE As String = "GetLvFormatMS"
		
		Dim strSQL As String
		
		GetLvFormatMS = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT * " & vbCrLf
		strSQL = strSQL & "FROM   INFTRA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "WHERE  TANCD = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  AND  FRMID = " & D0.Edt_SQL("S", gvcstJOB_ID & "." & pms_DisplayID) & vbCrLf
		
		' データ取得
		'UPGRADE_WARNING: GetLvFormatMS に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        gvobjInfTraDynaset = DB_GetTable(strSQL)
        '2019/04/12 ADD E N D

		'UPGRADE_WARNING: GetLvFormatMS に変換されていないステートメントがあります。ソース コードを確認してください。
		
		GetLvFormatMS = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	Public Function ChkCol_Order(ByRef parNum As Integer) As Short
		Dim wMAX As Integer
		Dim WIX As Integer
		
		ChkCol_Order = 0
		
		wMAX = UBound(LV_Col_Order)
		If parNum < 0 Or parNum > wMAX Then
			ChkCol_Order = -1
			Exit Function
		End If
		If LV_Col_Order_CHK(parNum) <> 0 Then
			ChkCol_Order = -1
			Exit Function
		Else
			LV_Col_Order_CHK(parNum) = -1
		End If
		
	End Function
	Public Sub ToLvFormatMsBuf()
		With LvFormatMsBuf
            '2019/04/12 CHG START
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANCD = gvobjInfTraDynaset.Fields("TANCD").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FRMID = gvobjInfTraDynaset.Fields("FRMID").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LTVID = gvobjInfTraDynaset.Fields("LTVID").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.INQITM = gvobjInfTraDynaset.Fields("INQITM").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ADKB = gvobjInfTraDynaset.Fields("ADKB").Value

            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(1) = gvobjInfTraDynaset.Fields("INDITMA").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(1) = gvobjInfTraDynaset.Fields("INDSIZA").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(2) = gvobjInfTraDynaset.Fields("INDITMB").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(2) = gvobjInfTraDynaset.Fields("INDSIZB").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(3) = gvobjInfTraDynaset.Fields("INDITMC").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(3) = gvobjInfTraDynaset.Fields("INDSIZC").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(4) = gvobjInfTraDynaset.Fields("INDITMD").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(4) = gvobjInfTraDynaset.Fields("INDSIZD").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(5) = gvobjInfTraDynaset.Fields("INDITME").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(5) = gvobjInfTraDynaset.Fields("INDSIZE").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(6) = gvobjInfTraDynaset.Fields("INDITMF").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(6) = gvobjInfTraDynaset.Fields("INDSIZF").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(7) = gvobjInfTraDynaset.Fields("INDITMG").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(7) = gvobjInfTraDynaset.Fields("INDSIZG").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(8) = gvobjInfTraDynaset.Fields("INDITMH").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(8) = gvobjInfTraDynaset.Fields("INDSIZH").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(9) = gvobjInfTraDynaset.Fields("INDITMI").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(9) = gvobjInfTraDynaset.Fields("INDSIZI").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(10) = gvobjInfTraDynaset.Fields("INDITMJ").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(10) = gvobjInfTraDynaset.Fields("INDSIZJ").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(11) = gvobjInfTraDynaset.Fields("INDITMK").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(11) = gvobjInfTraDynaset.Fields("INDSIZK").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(12) = gvobjInfTraDynaset.Fields("INDITML").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(12) = gvobjInfTraDynaset.Fields("INDSIZL").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(13) = gvobjInfTraDynaset.Fields("INDITMM").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(13) = gvobjInfTraDynaset.Fields("INDSIZM").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(14) = gvobjInfTraDynaset.Fields("INDITMN").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(14) = gvobjInfTraDynaset.Fields("INDSIZN").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(15) = gvobjInfTraDynaset.Fields("INDITMO").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(15) = gvobjInfTraDynaset.Fields("INDSIZO").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(16) = gvobjInfTraDynaset.Fields("INDITMP").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(16) = gvobjInfTraDynaset.Fields("INDSIZP").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(17) = gvobjInfTraDynaset.Fields("INDITMQ").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(17) = gvobjInfTraDynaset.Fields("INDSIZQ").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(18) = gvobjInfTraDynaset.Fields("INDITMR").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(18) = gvobjInfTraDynaset.Fields("INDSIZR").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(19) = gvobjInfTraDynaset.Fields("INDITMS").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(19) = gvobjInfTraDynaset.Fields("INDSIZS").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(20) = gvobjInfTraDynaset.Fields("INDITMT").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(20) = gvobjInfTraDynaset.Fields("INDSIZT").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(21) = gvobjInfTraDynaset.Fields("INDITMU").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(21) = gvobjInfTraDynaset.Fields("INDSIZU").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(22) = gvobjInfTraDynaset.Fields("INDITMV").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(22) = gvobjInfTraDynaset.Fields("INDSIZV").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(23) = gvobjInfTraDynaset.Fields("INDITMW").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(23) = gvobjInfTraDynaset.Fields("INDSIZW").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(24) = gvobjInfTraDynaset.Fields("INDITMX").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(24) = gvobjInfTraDynaset.Fields("INDSIZX").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(25) = gvobjInfTraDynaset.Fields("INDITMY").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(25) = gvobjInfTraDynaset.Fields("INDSIZY").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Item(26) = gvobjInfTraDynaset.Fields("INDITMZ").Value
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIZE(26) = gvobjInfTraDynaset.Fields("INDSIZZ").Value

            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TANCD = gvobjInfTraDynaset.Rows(0)("TANCD")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRMID = gvobjInfTraDynaset.Rows(0)("FRMID")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LTVID = gvobjInfTraDynaset.Rows(0)("LTVID")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .INQITM = gvobjInfTraDynaset.Rows(0)("INQITM")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ADKB = gvobjInfTraDynaset.Rows(0)("ADKB")

            ReDim Preserve .Item(26)
            ReDim Preserve .SIZE(26)

            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(1) = gvobjInfTraDynaset.Rows(0)("INDITMA")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(1) = gvobjInfTraDynaset.Rows(0)("INDSIZA")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(2) = gvobjInfTraDynaset.Rows(0)("INDITMB")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(2) = gvobjInfTraDynaset.Rows(0)("INDSIZB")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(3) = gvobjInfTraDynaset.Rows(0)("INDITMC")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(3) = gvobjInfTraDynaset.Rows(0)("INDSIZC")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(4) = gvobjInfTraDynaset.Rows(0)("INDITMD")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(4) = gvobjInfTraDynaset.Rows(0)("INDSIZD")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(5) = gvobjInfTraDynaset.Rows(0)("INDITME")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(5) = gvobjInfTraDynaset.Rows(0)("INDSIZE")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(6) = gvobjInfTraDynaset.Rows(0)("INDITMF")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(6) = gvobjInfTraDynaset.Rows(0)("INDSIZF")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(7) = gvobjInfTraDynaset.Rows(0)("INDITMG")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(7) = gvobjInfTraDynaset.Rows(0)("INDSIZG")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(8) = gvobjInfTraDynaset.Rows(0)("INDITMH")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(8) = gvobjInfTraDynaset.Rows(0)("INDSIZH")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(9) = gvobjInfTraDynaset.Rows(0)("INDITMI")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(9) = gvobjInfTraDynaset.Rows(0)("INDSIZI")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(10) = gvobjInfTraDynaset.Rows(0)("INDITMJ")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(10) = gvobjInfTraDynaset.Rows(0)("INDSIZJ")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(11) = gvobjInfTraDynaset.Rows(0)("INDITMK")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(11) = gvobjInfTraDynaset.Rows(0)("INDSIZK")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(12) = gvobjInfTraDynaset.Rows(0)("INDITML")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(12) = gvobjInfTraDynaset.Rows(0)("INDSIZL")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(13) = gvobjInfTraDynaset.Rows(0)("INDITMM")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(13) = gvobjInfTraDynaset.Rows(0)("INDSIZM")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(14) = gvobjInfTraDynaset.Rows(0)("INDITMN")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(14) = gvobjInfTraDynaset.Rows(0)("INDSIZN")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(15) = gvobjInfTraDynaset.Rows(0)("INDITMO")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(15) = gvobjInfTraDynaset.Rows(0)("INDSIZO")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(16) = gvobjInfTraDynaset.Rows(0)("INDITMP")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(16) = gvobjInfTraDynaset.Rows(0)("INDSIZP")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(17) = gvobjInfTraDynaset.Rows(0)("INDITMQ")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(17) = gvobjInfTraDynaset.Rows(0)("INDSIZQ")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(18) = gvobjInfTraDynaset.Rows(0)("INDITMR")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(18) = gvobjInfTraDynaset.Rows(0)("INDSIZR")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(19) = gvobjInfTraDynaset.Rows(0)("INDITMS")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(19) = gvobjInfTraDynaset.Rows(0)("INDSIZS")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(20) = gvobjInfTraDynaset.Rows(0)("INDITMT")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(20) = gvobjInfTraDynaset.Rows(0)("INDSIZT")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(21) = gvobjInfTraDynaset.Rows(0)("INDITMU")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(21) = gvobjInfTraDynaset.Rows(0)("INDSIZU")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(22) = gvobjInfTraDynaset.Rows(0)("INDITMV")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(22) = gvobjInfTraDynaset.Rows(0)("INDSIZV")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(23) = gvobjInfTraDynaset.Rows(0)("INDITMW")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(23) = gvobjInfTraDynaset.Rows(0)("INDSIZW")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(24) = gvobjInfTraDynaset.Rows(0)("INDITMX")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(24) = gvobjInfTraDynaset.Rows(0)("INDSIZX")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(25) = gvobjInfTraDynaset.Rows(0)("INDITMY")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(25) = gvobjInfTraDynaset.Rows(0)("INDSIZY")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .Item(26) = gvobjInfTraDynaset.Rows(0)("INDITMZ")
            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIZE(26) = gvobjInfTraDynaset.Rows(0)("INDSIZZ")
            '2019/04/12 CHG E N D
        End With
    End Sub
    '2019/04/11 CHG START
    'Public Sub SortLv(ByRef inLV As System.Windows.Forms.Control, ByRef inIDX As Integer, Optional ByVal inSortOrder As String = "")
    '    With inLV
    '        On Error Resume Next
    '        'UPGRADE_WARNING: オブジェクト inLV.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        'UPGRADE_WARNING: オブジェクト inLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .ColumnHeaders(.SortKey + 1).Text = Mid(.ColumnHeaders(.SortKey + 1).Text, 2)
    '        On Error Resume Next

    '        'UPGRADE_WARNING: オブジェクト inLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Select Case Trim(inLV.ColumnHeaders(inIDX + 1).Tag)
    '            Case "DATE"
    '                'UPGRADE_WARNING: オブジェクト inLV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                Call CvSort_DATE_ON(inLV, inIDX)
    '            Case "NUMBER"
    '                'UPGRADE_WARNING: オブジェクト inLV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                Call CvSort_NUMBER_ON(inLV, inIDX)
    '        End Select

    '        If inSortOrder = "A" Then
    '            'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .SortOrder = gvcstSortOrder.intAscending 'UP
    '            'UPGRADE_WARNING: オブジェクト inLV.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .SortKey = inIDX

    '        ElseIf inSortOrder = "D" Then
    '            'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .SortOrder = gvcstSortOrder.intDescending 'DOWN
    '            'UPGRADE_WARNING: オブジェクト inLV.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .SortKey = inIDX
    '        Else
    '            'UPGRADE_WARNING: オブジェクト inLV.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            If .SortKey = inIDX Then
    '                'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                If .SortOrder = gvcstSortOrder.intAscending Then
    '                    'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .SortOrder = gvcstSortOrder.intDescending 'DOWN
    '                Else
    '                    'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .SortOrder = gvcstSortOrder.intAscending 'UP
    '                End If
    '            Else
    '                'UPGRADE_WARNING: オブジェクト inLV.SortKey の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .SortKey = inIDX
    '                'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .SortOrder = gvcstSortOrder.intAscending 'UP
    '            End If
    '        End If
    '        'UPGRADE_WARNING: オブジェクト inLV.Sorted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        .Sorted = True
    '        'UPGRADE_WARNING: オブジェクト inLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Select Case Trim(inLV.ColumnHeaders(inIDX + 1).Tag)
    '            Case "DATE"
    '                'UPGRADE_WARNING: オブジェクト inLV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                Call CvSort_DATE_OFF(inLV, inIDX)
    '            Case "NUMBER"
    '                'UPGRADE_WARNING: オブジェクト inLV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                Call CvSort_NUMBER_OFF(inLV, inIDX)
    '        End Select
    '        'UPGRADE_WARNING: オブジェクト inLV.SortOrder の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        If .SortOrder = gvcstSortOrder.intAscending Then
    '            'UPGRADE_WARNING: オブジェクト inLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .ColumnHeaders(inIDX + 1).Text = "↓" & .ColumnHeaders(inIDX + 1).Text
    '        Else
    '            'UPGRADE_WARNING: オブジェクト inLV.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .ColumnHeaders(inIDX + 1).Text = "↑" & .ColumnHeaders(inIDX + 1).Text
    '        End If


    '    End With
    'End Sub
    Public Sub SortLv(ByRef pListView As ListView, ByVal pColumnIndex As Integer, ByRef pLvSorter As ListViewItemComparer, ByVal pSortOrderPriorityFlg As Boolean)

        Try
            'ソート列の表示矢印をクリアする
            For i As Integer = 0 To pListView.Columns.Count - 1
                Do  '(画面を開く毎に矢印が追加されるため)
                    Dim strStart As String = Mid(pListView.Columns(i).Text, 1, 1)
                    If strStart = CON_ARROW_UP Or strStart = CON_ARROW_DOWN Then
                        pListView.Columns(i).Text = Mid(pListView.Columns(i).Text, 2)
                    Else
                        Exit Do
                    End If
                Loop
            Next

            'ソートオーダーを優先するかどうか(Column設定より前)
            pLvSorter.SortOrderPriorityFlg = pSortOrderPriorityFlg

            'クリックされた列を設定
            pLvSorter.Column = pColumnIndex

            '文字列または数値を設定
            If pListView.Columns(pColumnIndex).TextAlign = HorizontalAlignment.Right Then
                pLvSorter.Mode = ListViewItemComparer.ComparerMode.Integer
            Else
                pLvSorter.Mode = ListViewItemComparer.ComparerMode.String
            End If

            '並び替える
            pListView.Sort()

            'ソート列の表示矢印を表示する
            If pLvSorter.Order = SortOrder.Ascending Then
                pListView.Columns(pColumnIndex).Text = CON_ARROW_UP & pListView.Columns(pColumnIndex).Text
            Else
                pListView.Columns(pColumnIndex).Text = CON_ARROW_DOWN & pListView.Columns(pColumnIndex).Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '2019/04/11 CHG E N D

	Public Sub CvSort_NUMBER_ON(ByRef parLV As ListView, ByRef parIndex As Integer)
		Dim WIX As Integer
		Dim wItem As String
		Dim wFormat As String
		
		wFormat = New String("0", 20) & "." & New String("0", 10)
		
		'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'With parLV.ListItems
        With parLV.Items
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            For WIX = 1 To .Count
                'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                With .Item(WIX)
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        wItem = .Text
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        'wItem = .SubItems(parIndex)
                        wItem = .SubItems(parIndex).Text
                        '2019/04/11 CHG E N D
                    End If
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Tag = wItem & Chr(9) & .Tag
                    If IsNumeric(wItem) = True Then
                        If CDec(wItem) >= 0 Then
                            wItem = VB6.Format(CDbl(wItem), wFormat)
                        Else
                            wItem = InvNumber(VB6.Format(CDec(wItem), wFormat))
                        End If
                    Else
                        wItem = ""
                    End If
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Text = wItem
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        '.SubItems(parIndex) = wItem
                        .SubItems(parIndex).Text = wItem
                        '2019/04/11 CHG E N D
                    End If
                End With
            Next WIX
        End With

    End Sub
	Public Sub CvSort_NUMBER_OFF(ByRef parLV As ListView, ByRef parIndex As Integer)
		Dim WIX As Integer
		Dim wPOS As Integer
		'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'With parLV.ListItems
        With parLV.Items
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            For WIX = 1 To .Count
                'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                With .Item(WIX)
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wPOS = InStr(.Tag, Chr(9))
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Text = Left(.Tag, wPOS - 1)
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        '.SubItems(parIndex) = Left(.Tag, wPOS - 1)
                        .SubItems(parIndex).Text = Left(.Tag, wPOS - 1)
                        '2019/04/11 CHG E N D
                    End If
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Tag = Mid(.Tag, wPOS + 1)
                End With
            Next WIX
        End With
    End Sub
	Public Function InvNumber(ByVal ParNumSTR As String) As String
		Dim WIX As Integer
		Dim outNumSTR As String
		outNumSTR = ""
		For WIX = 1 To Len(ParNumSTR)
			Select Case Mid(ParNumSTR, WIX, 1)
				Case "-"
					outNumSTR = outNumSTR & " "
				Case "0"
					outNumSTR = outNumSTR & "9"
				Case "1"
					outNumSTR = outNumSTR & "8"
				Case "2"
					outNumSTR = outNumSTR & "7"
				Case "3"
					outNumSTR = outNumSTR & "6"
				Case "4"
					outNumSTR = outNumSTR & "5"
				Case "5"
					outNumSTR = outNumSTR & "4"
				Case "6"
					outNumSTR = outNumSTR & "3"
				Case "7"
					outNumSTR = outNumSTR & "2"
				Case "8"
					outNumSTR = outNumSTR & "1"
				Case "9"
					outNumSTR = outNumSTR & "0"
				Case Else
					outNumSTR = outNumSTR & Mid(ParNumSTR, WIX, 1)
			End Select
		Next WIX
		InvNumber = outNumSTR
	End Function
	Public Sub CvSort_DATE_ON(ByRef parLV As ListView, ByVal parIndex As Integer)
		Dim WIX As Integer
		Dim wItem As String
		'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'With parLV.ListItems
        With parLV.Items
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            For WIX = 1 To .Count
                'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                With .Item(WIX)
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        wItem = .Text
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        'wItem = .SubItems(parIndex)
                        wItem = .SubItems(parIndex).Text
                        '2019/04/11 CHG E N D
                    End If
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Tag = wItem & Chr(9) & .Tag
                    If IsDate(wItem) = True Then
                        wItem = VB6.Format(VB6.Format(wItem, "YYYY/MM/DD"), "YYYY/MM/DD")
                    Else
                        wItem = ""
                    End If
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Text = wItem
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        '.SubItems(parIndex) = wItem
                        .SubItems(parIndex).Text = wItem
                        '2019/04/11 CHG E N D
                    End If
                End With
            Next WIX
        End With

    End Sub
	Public Sub CvSort_DATE_OFF(ByRef parLV As ListView, ByVal parIndex As Integer)
		Dim WIX As Integer
		Dim wPOS As Integer
		'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'With parLV.ListItems
        With parLV.Items
            '2019/04/11 CHG E N D
            'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            For WIX = 1 To .Count
                'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                With .Item(WIX)
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wPOS = InStr(.Tag, Chr(9))
                    If parIndex = 0 Then
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        .Text = Left(.Tag, wPOS - 1)
                    Else
                        'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        '.SubItems(parIndex) = Left(.Tag, wPOS - 1)
                        .SubItems(parIndex).Text = Left(.Tag, wPOS - 1)
                        '2019/04/11 CHG E N D
                    End If
                    'UPGRADE_WARNING: オブジェクト parLV.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Tag = Mid(.Tag, wPOS + 1)
                End With
            Next WIX
        End With

    End Sub
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    SavLvFormat
	'//*
	'//* <戻り値>   型                  説明
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pms_FORM_ID         String           I      画面ＩＤ
	'//*            pms_ListView        ListView         I      編集対象コントロール(ListView)
	'//*
	'//* <説  明>
	'//*    リストビューフォーマット編集処理
	'//*****************************************************************************************
    '2019/04/11 CHG START
    'Public Sub SavLvFormat(ByRef pms_FORM_ID As String, ByRef pms_ListView As System.Windows.Forms.Control)
    Public Sub SavLvFormat(ByRef pms_FORM_ID As String, ByRef pms_ListView As ListView)
        '2019/04/11 CHG E N D
        Dim wIDX As Short

        With pms_ListView
            Call ClrLvFormatMsBuf()
            Call D0.GetCol_Order(pms_ListView)

            '2019/04/11 CHG START
            ''UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'For wIDX = 0 To .ColumnHeaders.Count - 1
            '	'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	LvFormatMsBuf.Item(wIDX + 1) = .ColumnHeaders(LV_Col_Order(wIDX) + 1).Key
            '	'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	LvFormatMsBuf.Text(wIDX + 1) = .ColumnHeaders(LV_Col_Order(wIDX) + 1).Text
            '	'UPGRADE_WARNING: オブジェクト pms_ListView.ColumnHeaders の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	LvFormatMsBuf.SIZE(wIDX + 1) = .ColumnHeaders(LV_Col_Order(wIDX) + 1).Width
            'Next wIDX
            For wIDX = 0 To .columns.Count - 1
                LvFormatMsBuf.Item(wIDX + 1) = .Columns(LV_Col_Order(wIDX) + 1).Name
                LvFormatMsBuf.Text(wIDX + 1) = .Columns(LV_Col_Order(wIDX) + 1).Text
                LvFormatMsBuf.SIZE(wIDX + 1) = .Columns(LV_Col_Order(wIDX) + 1).Width
            Next wIDX
            '2019/04/11 CHG E N D
            Call UpdLvFormatMS(pms_FORM_ID)
        End With
    End Sub
	Public Sub ClrLvFormatMsBuf()
		
		Dim i As Short
		
		With LvFormatMsBuf
			.TANCD = Space(1)
			.FRMID = Space(1)
			.LTVID = Space(1)
			.INQITM = Space(1)
			.ADKB = Space(1)
			For i = 1 To 26
				.Item(i) = Space(1)
				.Text(i) = Space(1)
				.SIZE(i) = 0
			Next i
		End With
	End Sub
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    GetLvFormatMS
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pms_DisplayID       String           I      画面ＩＤ
	'//*
	'//* <説  明>
	'//*    今回の画面表示順情報を更新する
	'//*****************************************************************************************
	Public Sub UpdLvFormatMS(ByRef pms_DisplayID As String)
		
		Dim i As Short
		Dim strSQL As String
		
		Const PROCEDURE As String = "UpdLvFormatMS"
		
		strSQL = ""
		strSQL = strSQL & "SELECT * " & vbCrLf
		strSQL = strSQL & "FROM   INFTRA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "WHERE  TANCD = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  AND  FRMID = " & D0.Edt_SQL("S", gvcstJOB_ID & "." & pms_DisplayID) & vbCrLf
		
		' データ取得
		'UPGRADE_WARNING: UpdLvFormatMS に変換されていないステートメントがあります。ソース コードを確認してください。
 
        '2019/04/12 CHG START
        'UPGRADE_WARNING: UpdLvFormatMS に変換されていないステートメントがあります。ソース コードを確認してください。
        With LvFormatMsBuf
            'For i = 1 To 26
            '    If Mid(.Text(i), 1, 1) = "↑" Or Mid(.Text(i), 1, 1) = "↓" Then
            '        'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        gvobjInfTraDynaset.Fields("INQITM").Value = .Item(i)
            '        If Mid(.Text(i), 1, 1) = "↑" Then
            '            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '            gvobjInfTraDynaset.Fields("ADKB").Value = "D"
            '        Else
            '            'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '            gvobjInfTraDynaset.Fields("ADKB").Value = "A"
            '        End If
            '        Exit For
            '    End If
            'Next i
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMA").Value = .Item(1)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZA").Value = .SIZE(1)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMB").Value = .Item(2)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZB").Value = .SIZE(2)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMC").Value = .Item(3)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZC").Value = .SIZE(3)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMD").Value = .Item(4)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZD").Value = .SIZE(4)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITME").Value = .Item(5)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZE").Value = .SIZE(5)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMF").Value = .Item(6)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZF").Value = .SIZE(6)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMG").Value = .Item(7)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZG").Value = .SIZE(7)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMH").Value = .Item(8)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZH").Value = .SIZE(8)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMI").Value = .Item(9)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZI").Value = .SIZE(9)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMJ").Value = .Item(10)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZJ").Value = .SIZE(10)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMK").Value = .Item(11)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZK").Value = .SIZE(11)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITML").Value = .Item(12)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZL").Value = .SIZE(12)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMM").Value = .Item(13)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZM").Value = .SIZE(13)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMN").Value = .Item(14)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZN").Value = .SIZE(14)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMO").Value = .Item(15)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZO").Value = .SIZE(15)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMP").Value = .Item(16)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZP").Value = .SIZE(16)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMQ").Value = .Item(17)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZQ").Value = .SIZE(17)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMR").Value = .Item(18)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZR").Value = .SIZE(18)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMS").Value = .Item(19)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZS").Value = .SIZE(19)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMT").Value = .Item(20)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZT").Value = .SIZE(20)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMU").Value = .Item(21)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZU").Value = .SIZE(21)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMV").Value = .Item(22)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZV").Value = .SIZE(22)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMW").Value = .Item(23)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZW").Value = .SIZE(23)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMX").Value = .Item(24)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZX").Value = .SIZE(24)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMY").Value = .Item(25)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZY").Value = .SIZE(25)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDITMZ").Value = .Item(26)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("INDSIZZ").Value = .SIZE(26)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("OPEID").Value = gvstrOPEID
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("CLTID").Value = gvstrCLTID
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("WRTTM").Value = clsOra.OraGetNowTm
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Fields("WRTDT").Value = clsOra.OraGetNowDt(1)
            ''UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvobjInfTraDynaset.Update()

            Dim inqitm As String = ""
            Dim adkb As String = ""
            For i = 1 To 26
                '2019/04/16 CHG START
                'If Mid(.Text(i), 1, 1) = "↑" Or Mid(.Text(i), 1, 1) = "↓" Then
                If Mid(.Text(i), 1, 1) = CON_ARROW_UP Or Mid(.Text(i), 1, 1) = CON_ARROW_DOWN Then
                    '2019/04/16 CHG E N D
                    'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    inqitm = .Item(i)
                    If Mid(.Text(i), 1, 1) = CON_ARROW_UP Then
                        'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        gvobjInfTraDynaset.Rows(0)("ADKB").Value = "D"
                    Else
                        'UPGRADE_WARNING: オブジェクト gvobjInfTraDynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        gvobjInfTraDynaset.Rows(0)("ADKB").Value = "A"
                    End If
                    Exit For
                End If
            Next i

            ' SQL文の作成
            strSQL = ""
            strSQL &= vbCrLf & " UPDATE INFTRA SET "
            strSQL &= vbCrLf & " INQITM = " & inqitm
            strSQL &= vbCrLf & ",ADKB = " & adkb
            strSQL &= vbCrLf & ",INDITMA = " & .Item(1)
            strSQL &= vbCrLf & ",INDSIZA = " & .SIZE(1)
            strSQL &= vbCrLf & ",INDITMB = " & .Item(2)
            strSQL &= vbCrLf & ",INDSIZB = " & .SIZE(2)
            strSQL &= vbCrLf & ",INDITMC = " & .Item(3)
            strSQL &= vbCrLf & ",INDSIZC = " & .SIZE(3)
            strSQL &= vbCrLf & ",INDITMD = " & .Item(4)
            strSQL &= vbCrLf & ",INDSIZD = " & .SIZE(4)
            strSQL &= vbCrLf & ",INDITME = " & .Item(5)
            strSQL &= vbCrLf & ",INDSIZE = " & .SIZE(5)
            strSQL &= vbCrLf & ",INDITMF = " & .Item(6)
            strSQL &= vbCrLf & ",INDSIZF = " & .SIZE(6)
            strSQL &= vbCrLf & ",INDITMG = " & .Item(7)
            strSQL &= vbCrLf & ",INDSIZG = " & .SIZE(7)
            strSQL &= vbCrLf & ",INDITMH = " & .Item(8)
            strSQL &= vbCrLf & ",INDSIZH = " & .SIZE(8)
            strSQL &= vbCrLf & ",INDITMI = " & .Item(9)
            strSQL &= vbCrLf & ",INDSIZI = " & .SIZE(9)
            strSQL &= vbCrLf & ",INDITMJ = " & .Item(10)
            strSQL &= vbCrLf & ",INDSIZJ = " & .SIZE(10)
            strSQL &= vbCrLf & ",INDITMK = " & .Item(11)
            strSQL &= vbCrLf & ",INDSIZK = " & .SIZE(11)
            strSQL &= vbCrLf & ",INDITML = " & .Item(12)
            strSQL &= vbCrLf & ",INDSIZL = " & .SIZE(12)
            strSQL &= vbCrLf & ",INDITMM = " & .Item(13)
            strSQL &= vbCrLf & ",INDSIZM = " & .SIZE(13)
            strSQL &= vbCrLf & ",INDITMN = " & .Item(14)
            strSQL &= vbCrLf & ",INDSIZN = " & .SIZE(14)
            strSQL &= vbCrLf & ",INDITMO = " & .Item(15)
            strSQL &= vbCrLf & ",INDSIZO = " & .SIZE(15)
            strSQL &= vbCrLf & ",INDITMP = " & .Item(16)
            strSQL &= vbCrLf & ",INDSIZP = " & .SIZE(16)
            strSQL &= vbCrLf & ",INDITMQ = " & .Item(17)
            strSQL &= vbCrLf & ",INDSIZQ = " & .SIZE(17)
            strSQL &= vbCrLf & ",INDITMR = " & .Item(18)
            strSQL &= vbCrLf & ",INDSIZR = " & .SIZE(18)
            strSQL &= vbCrLf & ",INDITMS = " & .Item(19)
            strSQL &= vbCrLf & ",INDSIZS = " & .SIZE(19)
            strSQL &= vbCrLf & ",INDITMT = " & .Item(20)
            strSQL &= vbCrLf & ",INDSIZT = " & .SIZE(20)
            strSQL &= vbCrLf & ",INDITMU = " & .Item(21)
            strSQL &= vbCrLf & ",INDSIZU = " & .SIZE(21)
            strSQL &= vbCrLf & ",INDITMV = " & .Item(22)
            strSQL &= vbCrLf & ",INDSIZV = " & .SIZE(22)
            strSQL &= vbCrLf & ",INDITMW = " & .Item(23)
            strSQL &= vbCrLf & ",INDSIZW = " & .SIZE(23)
            strSQL &= vbCrLf & ",INDITMX = " & .Item(24)
            strSQL &= vbCrLf & ",INDSIZX = " & .SIZE(24)
            strSQL &= vbCrLf & ",INDITMY = " & .Item(25)
            strSQL &= vbCrLf & ",INDSIZY = " & .SIZE(25)
            strSQL &= vbCrLf & ",INDITMZ = " & .Item(26)
            strSQL &= vbCrLf & ",INDSIZZ = " & .SIZE(26)
            strSQL &= vbCrLf & ",OPEID = " & gvstrOPEID
            strSQL &= vbCrLf & ",CLTID = " & gvstrCLTID
            '2019/04/12 CHG START
            'strSQL &= vbCrLf & ",WRTTM = " & clsOra.OraGetNowTm
            strSQL &= vbCrLf & ",WRTTM = " & OraGetNowTm()
            '2019/04/12 CHG E N D
            '2019/04/12 CHG START
            'strSQL &= vbCrLf & ",WRTDT = " & clsOra.OraGetNowDt(1)
            strSQL &= vbCrLf & ",WRTDT = " & OraGetNowDt(1)
            '2019/04/12 CHG E N D
            strSQL &= vbCrLf & " WHERE  TANCD = " & D0.Edt_SQL("S", gvstrOPEID)
            strSQL &= vbCrLf & " AND    FRMID = " & D0.Edt_SQL("S", gvcstJOB_ID & "." & pms_DisplayID)

            Call DB_Execute(strSQL)
            '2019/04/12 CHG E N D
        End With
		
		'UPGRADE_WARNING: UpdLvFormatMS に変換されていないステートメントがあります。ソース コードを確認してください。
		
		On Error GoTo 0
		
		Exit Sub
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Sub
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    GetTanKengen
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pms_DisplayID       String           I      画面ＩＤ
	'//*
	'//* <説  明>
	'//*    今回の画面表示順情報を更新する
	'//*****************************************************************************************
	Public Function GetTanKengen(ByVal pms_TANCD As String, Optional ByVal pms_UNYDT As String = "", Optional ByRef pms_SAPMODKB As String = "", Optional ByRef pms_SAPCSVKB As String = "") As Boolean
		
        '2019/04/26 DEL START
        'Dim i As Short
        '2019/04/26 DEL E N D
        Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/26 CHG START
        'Dim objRec1 As OraDynaset
        Dim dtRec1 As DataTable = Nothing
        '2019/04/26 CHG E N D
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/26 CHG START
        'Dim objRec2 As OraDynaset
        Dim dtRec2 As DataTable = Nothing
        '2019/04/26 CHG E N D
        Dim strKNGGRCD As String
		
		GetTanKengen = False
		
		Const PROCEDURE As String = "GetTanKengen"
		
		On Error GoTo ONERR_STEP
		
		'//初期化
		pms_SAPMODKB = ""
		pms_SAPCSVKB = ""
		strKNGGRCD = ""
		
		strSQL = ""
		strSQL = strSQL & "SELECT TANTKDT, KNGGRCD, OLDGRCD " & vbCrLf
		strSQL = strSQL & "FROM   TANMTA        " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "WHERE  TANCD       = " & D0.Edt_SQL("S", pms_TANCD) & vbCrLf
		strSQL = strSQL & "  AND  DATKB       = '1'" & vbCrLf
		
		'ﾚｺｰﾄﾞｾｯﾄ獲得
        'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/26 ADD START
        dtRec1 = DB_GetTable(strSQL)
        '2019/04/26 ADD E N D
		
        'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。
       
        '2019/04/26 ADD START
        If dtRec1 IsNot Nothing AndAlso dtRec1.Rows.Count > 0 Then
            If D0.Chk_Null(dtRec1.Rows(0)("TANTKDT")) <> "" Then
                If D0.Chk_Null(dtRec1.Rows(0)("TANTKDT")) <= pms_UNYDT Then
                    strKNGGRCD = D0.Chk_Null(dtRec1.Rows(0)("KNGGRCD"))
                Else
                    strKNGGRCD = D0.Chk_Null(dtRec1.Rows(0)("OLDGRCD"))
                End If
            End If
        End If
        '2019/04/26 ADD E N D

		If strKNGGRCD <> "" Then
			strSQL = ""
			strSQL = strSQL & "SELECT SAPMODKB,SAPCSVKB " & vbCrLf
			strSQL = strSQL & "FROM   KNGMTA        " & vbCrLf
			'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "WHERE  KNGGRCD     = " & D0.Edt_SQL("S", strKNGGRCD) & vbCrLf
			strSQL = strSQL & "  AND  DATKB       = '1'" & vbCrLf
			
			'ﾚｺｰﾄﾞｾｯﾄ獲得
            'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。
             
            '2019/04/26 ADD START
            dtRec2 = DB_GetTable(strSQL)
            '2019/04/26 ADD E N D

            'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。
            
            '2019/04/26 ADD START
            If dtRec2 IsNot Nothing AndAlso dtRec2.Rows.Count > 0 Then
                pms_SAPMODKB = D0.Chk_Null(dtRec2.Rows(0)("SAPMODKB"))
                pms_SAPCSVKB = D0.Chk_Null(dtRec2.Rows(0)("SAPCSVKB"))
            Else
                pms_SAPMODKB = "9"
                pms_SAPCSVKB = "9"
            End If
            '2019/04/26 ADD E N D

		Else
			pms_SAPMODKB = "9"
			pms_SAPCSVKB = "9"
		End If
		
		GetTanKengen = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
        'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。
        
        '2019/04/26 ADD START
        dtRec1 = Nothing
        '2019/04/26 ADD E N D

        'UPGRADE_WARNING: GetTanKengen に変換されていないステートメントがあります。ソース コードを確認してください。
        
        '2019/04/26 ADD START
        dtRec2 = Nothing
        '2019/04/26 ADD E N D

		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
		Resume EXIT_STEP
	End Function
	
	'//*************************************************************************************************
	'//*
	'//* <名  称>
	'//*    Put_TextFile
	'//*
	'//* <戻り値>   型          説明
	'//*            Boolean     正常に書き込まれたかのステータス
	'//*                        (True :正常 False:異常)
	'//*
	'//* <引  数>   項目名             型              I/O           内容
	'//*            pm_strFileName     String           I            出力ﾌｧｲﾙ名(パス含む)
	'//*            pm_strMessage      String           I            出力内容
	'//*            pm_intDeleteFlg    Boolean          I            書き込みフラグ
	'//*                                                             (True :新規ﾌｧｲﾙ作成 False:ﾌｧｲﾙ追加)
	'//*
	'//* <説  明>
	'//*    テキストファイルに出力する
	'//*************************************************************************************************
	Function Put_TextFile(ByVal pm_strFileName As String, Optional ByVal pm_strMessage As String = "", Optional ByVal pm_intDeleteFlg As Boolean = False) As Boolean
		
		Dim int_FileNO As Short '//ファイルNo
		
		Const PROCEDURE As String = "Put_TextFile"
		
		On Error GoTo ONERR_STEP
		
		Put_TextFile = False
		
		int_FileNO = FreeFile
		If pm_intDeleteFlg Then
			FileOpen(int_FileNO, pm_strFileName, OpenMode.Output)
		Else
			FileOpen(int_FileNO, pm_strFileName, OpenMode.Append)
		End If
		
		PrintLine(int_FileNO, pm_strMessage)
		
		FileClose(int_FileNO)
		
		Put_TextFile = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		Resume EXIT_STEP
	End Function
	
	'//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
	'// 2008/01/24 ADD START
	'//*************************************************************************************************
	'//*
	'//* <名  称>
	'//*    SSSWIN_LOGWRT
	'//*
	'//* <戻り値>   型          説明
	'//*            String      正常に書き込まれたかのステータス
	'//*
	'//*
	'//* <引  数>   項目名             型              I/O           内容
	'//*            pm_strFileName     String           I            出力ﾌｧｲﾙ名(パス含む)
	'//*            pm_strMessage      String           I            出力内容
	'//*            pm_intDeleteFlg    Boolean          I            書き込みフラグ
	'//*                                                             (True :新規ﾌｧｲﾙ作成 False:ﾌｧｲﾙ追加)
	'//*
	'//* <説  明>
	'//*    テキストファイルに出力する
	'//*************************************************************************************************
	Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
		Dim errcnt, Fno, rtn As Short
		Dim wbuf As String
		'
		'///Call ResetDBSTAT(DBN_SYSTBE)
		'
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '2019/04/11 CHG START
        'DB_SYSTBE = LSet(DB_CLRREC)
        DB_SYSTBE = Nothing
        '2019/04/11 CHG E N D
        DB_SYSTBE.PRGID = gvcstJOB_ID
		DB_SYSTBE.LOGNM = LogMsg
		DB_SYSTBE.OPEID = gvstrOPEID
		DB_SYSTBE.CLTID = gvstrCLTID
		DB_SYSTBE.WRTTM = VB6.Format(Now, "hhnnss")
		DB_SYSTBE.WRTDT = VB6.Format(Now, "YYYYMMDD")
		'
		errcnt = 0
		Fno = FreeFile
		On Error Resume Next
		'ディレクトリ存在チェック
		'// wbuf = Dir$(SSS_INIDAT(1), 16)
		'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		wbuf = Dir(gvINIInformation.strLOGPATH, 16)
		If wbuf = "" Then
			Call MsgBox("SSSWIN.INI の DAT_PATH の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
			'//////       Call SSS_CLOSE
			'//////       rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
			End
		End If
		Err.Clear()
		On Error GoTo ErrorLogFile
		'// Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
		FileOpen(Fno, gvINIInformation.strLOGPATH & "SYSTBE.DTA", OpenMode.Append, OpenAccess.Write, OpenShare.LockWrite)
		On Error GoTo 0
		PrintLine(Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT)
		FileClose(Fno)
		Exit Sub
ErrorLogFile: 
		errcnt = errcnt + 1
		'//    If errcnt > SSS_ReTryCnt Then
		'//        If MsgBox("履歴ファイルロックエラー !" & Chr$(13) & "中止しても宜しいですか？", 20) = 6 Then
		'//            Call SSS_CLOSE
		'//            rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
		'//            End
		'//        Else
		'//            errcnt = 0
		'//        End If
		'//    End If
		'//    DoEvents
		Resume 
	End Sub
	'// 2008/01/24 ADD END
    '//★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★

    '2019/04/11 ADD START
    Sub Error_Exit(ByVal ErrorMsg As String)
        '//処理無し
    End Sub
    '2019/04/11 ADD E N D

    '2019/04/11 ADD START
    Function Get_DBHEAD() As String
        '現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
        Dim ret As Short
        Dim wkStr As New VB6.FixedLengthString(128)

        Get_DBHEAD = ""
        '20190219
        'ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
        If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
    End Function
    '2019/04/11 ADD E N D

    '2019/04/12 ADD START
    '-----------------------------------------------------------
    '　関数名　GetNowTm
    '　機能　　サーバの現在時刻取得
    '　引数　　なし
    '　返値　　現在時刻(HHMMSS)
    '　備考　　なし
    '-----------------------------------------------------------
    Public Function OraGetNowTm() As String

        Const PROCEDURE As String = "OraGetNowTm"

        On Error GoTo ONERR_STEP

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/26 DEL START
        'Dim objRec As OraDynaset
        '2019/04/26 DEL E N D

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'HH24MISS') NTIME " & vbCrLf
        strSQL = strSQL & "FROM   DUAL " & vbCrLf

        ' データ取得
        'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 ADD E N D

        'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            OraGetNowTm = dt.Rows(0)("NTIME")
        Else
            OraGetNowTm = Format(Now, "HHMMSS")
        End If
        '2019/04/12 ADD E N D

        'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        '// 2007/01/17 ↓ DEL STR
        ''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
        '''''                            cst_詳細 & Err.Description, _
        '''''                            vbOKOnly + vbCritical, App.Title
        '// 2007/01/17 ↑ DEL END
        Resume EXIT_STEP
    End Function
    '2019/04/12 ADD E N D

    '2019/04/12 ADD START
    '-----------------------------------------------------------
    '　関数名　GetNowDt
    '　機能　　サーバの現在日付取得
    '　引数　　戻り値の書式区分(0:yymmdd 1:yyyymmdd) (省略時=0)
    '　返値　　現在日付(YYYYMMDD)
    '　備考　　なし
    '-----------------------------------------------------------
    Public Function OraGetNowDt(Optional ByVal pmiKBN As Short = 0) As String

        Const PROCEDURE As String = "OraGetNowDt"

        On Error GoTo ONERR_STEP

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/26 DEL START
        'Dim objRec As OraDynaset
        '2019/04/26 DEL E N D
        Dim lngDate As Integer

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'YYYYMMDD') NDATE " & vbCrLf
        strSQL = strSQL & "FROM   DUAL " & vbCrLf

        'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 ADD E N D

        'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            lngDate = dt.Rows(0)("NDATE")
        Else
            lngDate = Format(Now, "YYYYMMDD")
        End If
        '2019/04/12 ADD E N D

        Select Case pmiKBN
            Case 0
                OraGetNowDt = Mid(CStr(lngDate), 3)
            Case 1
                OraGetNowDt = CStr(lngDate)
        End Select

        'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        '// 2007/01/17 ↓ DEL STR
        ''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
        '''''                            cst_詳細 & Err.Description, _
        '''''                            vbOKOnly + vbCritical, App.Title
        '// 2007/01/17 ↑ DEL END
        Resume EXIT_STEP
    End Function
    '2019/04/12 ADD E N D

    '2019/04/24 ADD START
    Public Sub SetBar(ByRef pForm As Form)

        Try
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = gvstrTERMNO
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = gvstrOPEID
            DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = My.Application.Info.AssemblyName
        Catch ex As Exception
            MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub
    '2019/04/24 ADD E N D



    '20190710 ADD START　←　AE_PROC.vbに同様のFunction
    Public Function LeftB(ByVal str As String, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If byteCount <= btBytes.Length Then
            Return hEncode.GetString(btBytes, 0, byteCount)
        End If

        Return str
    End Function

    Public Function RightB(ByVal str As String, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If byteCount <= btBytes.Length Then
            Return hEncode.GetString(btBytes, btBytes.Length - byteCount, byteCount)
        End If

        Return str
    End Function

    Public Function MidB(ByVal str As String, ByVal startindex As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If startindex <= btBytes.Length Then
            Dim byteCount As Integer = btBytes.Length - startindex + 1
            Return hEncode.GetString(btBytes, startindex - 1, byteCount)
        End If

        Return String.Empty
    End Function

    Public Function MidB(ByVal str As String, ByVal startindex As Integer, ByVal byteCount As Integer) As String
        If String.IsNullOrEmpty(str) = True Then
            Return ""
        End If

        Dim hEncode As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncode.GetBytes(str)

        If startindex <= btBytes.Length Then
            If (btBytes.Length - startindex) < byteCount Then
                byteCount = btBytes.Length - startindex + 1
            End If
            Return hEncode.GetString(btBytes, startindex - 1, byteCount)
        End If

        Return String.Empty
    End Function

    Public Function LenB(ByVal str As String) As Integer
        If String.IsNullOrEmpty(str) = True Then
            Return 0
        End If
        'Shift JISに変換したときに必要なバイト数を返す
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str)
    End Function

    Public Function LenWid(ByVal pm_Characters As Object) As Object
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(pm_Characters) Then
            'Call AE_SystemError("LenWid のパラメタに", 190)
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト LenWid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            LenWid = System.DBNull.Value
            Exit Function '--------------------
        End If
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Characters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/03/12 CHG START
        'LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
        LenWid = LenB(pm_Characters)
        '2019/03/12 CHG E N D
    End Function
    '20190710 ADD END　←　AE_PROC.vbに同様のFunction

End Module