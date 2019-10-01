Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D
'2019/04/02 ADD START
Imports Oracle.DataAccess.Client
'2019/04/02 ADD E N D
Module HKKET141M
	'//*****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    HKKET14M.BAS
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    Rise
	'//*＜説明＞
	'//*    販売計画入力 モジュール
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|Rise)          |新規
	'//*          |        |Rise)          |多数
	'//*          |20070727|Rise)          |画面整理、非在庫品抽出対象外
	'//*          |20070730|Rise)          |商品群抽出でのエラー是正
	'//*          |20071218|Rise)          |アドバイス計算方法変更
	'//*          |20071220|Rise)          |ＬＴ基準日を回答納期or当月１日→翌月１日固定
	'//*          |20081117|Rise)          |改行キー変換＋ＰＦキーでカーソル移動追加
	'//* 2.01     |20081118|Rise)          |Alt+PF4対応
	'//* 2.02     |20081203|Rise)          |発注限界日の表示方法の変更
	'//* 2.31     |20090106|Rise)          |期の算出方法の変更
	'//*****************************************************************************************
	'//*****************************************************************************************
	'// プログラム情報
	'//*****************************************************************************************
	'//ジョブＩＤ・ジョブ名称
	Public Const gvcstJOB_ID As String = "HKKET14"
	Public Const gvcstJOB_Titl As String = "販売計画入力"
	
	'//*****************************************************************************************
	'// インスタンス定義
	'//*****************************************************************************************
	'UPGRADE_ISSUE: ClsComn オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Public D0 As ClsComn '//System 関数
	'UPGRADE_ISSUE: ClsFocusCtrl オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Public ClsFocus As ClsFocusCtrl '//Set Enter
	'UPGRADE_ISSUE: ClsMessage オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Public ClsMessage As ClsMessage '//Message
	'UPGRADE_ISSUE: ClsOraDB オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    Public clsOra As ClsOraDB

	'//*****************************************************************************************
	'// 変数定義
	'//*****************************************************************************************
	'UPGRADE_ISSUE: gvtypIniFile オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Public gvINIInformation As gvtypIniFile '//ＩＮＩファイル構造体
	
	'//*****************************************************************************************
	'// 定数　　定義
	'//*****************************************************************************************
	Public Const gvcstPRCCL As Integer = 10
	
	'//*****************************************************************************************
	'// ＰＧ個別変数定義
	'//*****************************************************************************************
	'// 2007/02/17 ↓ ADD STR
	Public gvintPGHaita As Short '//プログラム起動排他フラグ
	'// 2007/02/17 ↑ ADD STR
	
	Public gvintInputCls As Short '//現在の入力モード
	Public gvblnInputFlg As Boolean '//
	Public gvintInputRow As Short '//現在の入力行
	Public gvstrUNYDT As String '//日付管理TBL.運用日付
	Public gvstrTERMNO As String '//日付管理TBL.期
	Public gvstrACCYY As String '//日付管理TBL.会計年度
    '2019/04/19 CHG START
    'Public gvobjdyn As Object
    Public gvobjdyn As DataTable = Nothing
    '2019/04/19 CHG E N D
    Public gvstrDspItemNM As String '//表示順項目名
	Public gvstrDspItemAD As String '//表示順項目名(A:昇順，D:降順)
	Public gvstrDisplayID As String '//現在の画面ID
	Public gvstrFilePath1 As String '//ファイルパス
	Public gvstrFileName1 As String '//ファイル名
	Public gvstrFilePath2 As String '//ファイルパス
	Public gvstrFileName2 As String '//ファイル名
	Public gvstrFilePath3 As String '//ファイルパス
	Public gvstrFileName3 As String '//ファイル名
	Public gvstrFilePath4 As String '//ファイルパス
	Public gvstrFileName4 As String '//ファイル名
	Public gvstrFilePath5 As String '//ファイルパス
	Public gvstrFileName5 As String '//ファイル名
	Public gvstrFilePath6 As String '//ファイルパス
	Public gvstrFileName6 As String '//ファイル名
	'// V2.30↓ ADD
	Public gvstrFilePath7 As String '//ファイルパス(入力ログテキストファイル)
	Public gvstrFileName7 As String '//ファイル名  (入力ログテキストファイル)
	'// V2.30↑ ADD
	
	Public Structure mtypHKKZTR '//退避情報
		Dim strHINCD() As String '//製品ｺｰﾄﾞ
	End Structure
	'UPGRADE_WARNING: 構造体 musrHKKZTR の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public musrHKKZTR As mtypHKKZTR
	'// 2007/02/24 ↓ ADD STR
	Public gvvntLeft As Object '//画面左位置
	Public gvvntTop As Object '//画面上位置
    '// 2007/02/24 ↑ ADD STR

    '2019/04/16 ADD START
    'SortOrder
    Private LvSortOrder As SortOrder
    '2019/04/16 ADD E N D

    '2019/04/24 ADD START
    Private InitSortColumn As Integer
    '2019/04/24 ADD E N D

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Main
    '//*
    '//* <戻り値>
    '//*
    '//* <引  数>     項目名                  I/O           内容
    '//*
    '//* <説  明>
    '//*    システム起動時の実行プロシジャー
    '//*****************************************************************************************
    'UPGRADE_WARNING: Sub Main() が完了したときにアプリケーションは終了します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"' をクリックしてください。
    Public Sub Main()
        '2019/04/11 DEL START
        'Dim ChkHTATRA As Object
        'Dim Get_Authority As Object
        'Dim gs_pgid As Object
        'Dim gs_userid As Object
        'Dim gvstrOPEID As Object 
        'Dim SSSWIN_LOGWRT As Object
        'Dim GetIniFile As Object
        'Dim Get_CommandLine As Object
        '2019/04/11 DEL E N D

        On Error GoTo ONERR_STEP

        '//共通オブジェクトのインスタンス作成
        If Not Ctr_Object(True) Then
            GoTo EXIT_STEP
        End If

        '//プログラム２重起動チェック
        'UPGRADE_WARNING: オブジェクト D0.ChkDuplicateInstance の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Not D0.ChkDuplicateInstance(gvcstJOB_Titl) Then
            MsgBox("【" & Trim(gvcstJOB_Titl) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, gvcstJOB_Titl)
            AppActivate(gvcstJOB_Titl)
            GoTo EXIT_STEP
        End If

        '//パラメータの取得
        If Not Get_CommandLine() Then
            GoTo EXIT_STEP
        End If

        '//ＩＮＩファイルの取得(共通)
        If Not GetIniFile(gvINIInformation) Then
            GoTo EXIT_STEP
        End If
        '// ★★★★★★★★★★★★★★★★★★★★
        '// 2008/01/24 START
        Call SSSWIN_LOGWRT("プログラム起動")
        '// 2008/01/24 END
        '// ★★★★★★★★★★★★★★★★★★★★
        '//ＩＮＩファイルの取得(個別)
        If Not Get_IndividualIniFile() Then
            GoTo EXIT_STEP
        End If

        '//データベース接続(ORACLEｻｰﾊﾞｰ)
        '2019/04/12 CHG START
        ''UPGRADE_WARNING: オブジェクト gvINIInformation.strSQLPWD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト gvINIInformation.strSQLUID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト gvINIInformation.strSQLDATABASE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト clsOra.OraConnect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If Not clsOra.OraConnect(gvINIInformation.strSQLDATABASE, gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD) Then
        '    GoTo EXIT_STEP
        'End If
        CON = DB_START_FOR_HKK(gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD, gvINIInformation.strSQLDATABASE)
        '2019/04/12 CHG E N D

        '//メッセージクラスへOraDatabaseプロパティをセットする
        '2019/04/12 DEL START
        ''UPGRADE_WARNING: オブジェクト ClsMessage.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ClsMessage.OraDatabase = clsOra.OraDatabase
        '2019/04/12 DEL E N D

        '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
        '//日付管理取得
        Call Get_HidukeKanri(gvstrUNYDT)

        '権限取得
        'UPGRADE_WARNING: オブジェクト gvstrOPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gs_userid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gs_userid = gvstrOPEID
        'UPGRADE_WARNING: オブジェクト gs_pgid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gs_pgid = gvcstJOB_ID
        'UPGRADE_WARNING: オブジェクト Get_Authority(gvstrUNYDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Get_Authority(gvstrUNYDT) = "9" Then
            '起動権限なしの場合、処理終了
            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & "RUNAUTH")
            '//終了処理
            Call Ctr_END()
        End If
        '''' ADD 2009/11/26  FKS) T.Yamamoto    End

        '//起動可否判定

        '// 2007/02/17 ↓ UPD STR
        '    '//V1.10 2006/09/20  CHG START  RISE)
        '    'If ChkHTATRA(gvstrOPEID, "1", "HKKET141", "HKKET01") = 9 Then
        '    If ChkHTATRA(gvstrOPEID, "1", gvcstJOB_ID, gvcstJOB_ID, "HKKET01") = 9 Then
        '    '//V1.10 2006/09/20  CHG E N D  RISE)
        '        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & "HKKET01_005"
        '        '//終了処理
        '        Call Ctr_END
        '    End If

        'UPGRADE_WARNING: オブジェクト ChkHTATRA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvintPGHaita = ChkHTATRA(gvstrOPEID, "1", gvcstJOB_ID, gvcstJOB_ID, "HKKET01")
        '// 2007/02/17 ↑ UPD STR

        If Not Get_UNYMTA() Then
            '//終了処理
            Call Ctr_END()
        End If

        '//画面表示
        '2019/04/12 CHG START
        'HKKET141F.Show()
        HKKET141F.ShowDialog()
        '2019/04/12 CHG E N D

        Exit Sub
        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//共通オブジェクトの解放
        Call Ctr_Object(False)

        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        MsgBox("<Sub_Main> " & vbCrLf & "実行時エラーです。処理を中止します。" & vbCrLf & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Ctr_Object
    '//*
    '//* <戻り値>     型          説明
    '//*              Boolean     True    :設定できた
    '//*                          False   :設定できなかった
    '//*
    '//* <引  数>     項目名             型              I/O           内容
    '//*              pmf_Set          Boolean          I             True:作成 False:解放
    '//* <説  明>
    '//*    オブジェクトインスタンスの作成／解放
    '//*****************************************************************************************
    Function Ctr_Object(ByRef pmf_Set As Boolean) As Boolean

        Const PROCEDURE As String = "Ctr_Object"

        On Error GoTo ONERR_STEP

        Ctr_Object = False

        If pmf_Set Then
            '//共通オブジェクトのインスタンス作成
            D0 = New ClsComn '//共通ｸﾗｽ
            '2019/04/11 DEL START
            'clsOra = New ClsOraDB '//Oracle
            '2019/04/11 DEL E N D
            ClsMessage = New ClsMessage '//Message
            ClsFocus = New ClsFocusCtrl '//Set Enter
        Else
            '//共通オブジェクトのインスタンス解放clsAKNITRA
            If Not (ClsFocus Is Nothing) Then '//Set Enter
                'UPGRADE_NOTE: オブジェクト ClsFocus をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                ClsFocus = Nothing
            End If
            If Not (ClsMessage Is Nothing) Then '//Message
                'UPGRADE_NOTE: オブジェクト ClsMessage をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                ClsMessage = Nothing
            End If
            '2019/04/19 DEL START
            'If Not (clsOra Is Nothing) Then '//Oracle
            '    'UPGRADE_NOTE: オブジェクト clsOra をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            '    clsOra = Nothing
            'End If
            '2019/04/19 DEL E N D
            If Not (D0 Is Nothing) Then '//共通ｸﾗｽ
                'UPGRADE_NOTE: オブジェクト D0 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                D0 = Nothing
            End If
        End If

        Ctr_Object = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_UNYMTA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    運用管理を取得する
    '//*****************************************************************************************
    Public Function Get_UNYMTA() As Boolean

        Const PROCEDURE As String = "Get_UNYMTA"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset
        Dim i As Short

        Get_UNYMTA = False

        On Error GoTo ONERR_STEP

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   UNYMTA " & vbCrLf

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'gvstrUNYDT = D0.Chk_Null(objRec("UNYDT"))
            gvstrUNYDT = D0.Chk_Null(dt.Rows(0)("UNYDT"))
            '2019/04/12 CHG E N D
            '// V2.31↓ UPD
            '        gvstrTERMNO = D0.Chk_Null(objRec("TERMNO"))
            If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
                gvstrTERMNO = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1975)
            Else
                gvstrTERMNO = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1974)
            End If
            '// V2.31↑ UPD
            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'gvstrACCYY = D0.Chk_Null(objRec("ACCYY"))
            gvstrACCYY = D0.Chk_Null(dt.Rows(0)("ACCYY"))
            '2019/04/12 CHG E N D
            '2008/06/14 ADD START
            If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
                gvstrACCYY = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1)
            Else
                gvstrACCYY = Mid(gvstrUNYDT, 1, 4)
            End If
            '2008/06/14 ADD E N D
        End If


        Get_UNYMTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_Initialize
    '//*
    '//* <戻り値>
    '//*
    '//* <引  数>     項目名                  I/O           内容
    '//*
    '//* <説  明>
    '//*    初期処理
    '//*****************************************************************************************
    Function Set_Initialize() As Boolean
        '2019/04/11 DEL START
        'Dim SetLvFormat As Object
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_Initialize"
        Set_Initialize = False

        On Error GoTo ONERR_STEP

        '// ＦＯＲＭキャプションセット
        'HKKET141F.Caption = gvcstJOB_Titl

        '//ＦＯＲＭ初期セット
        Call SetFormInitOrg(HKKET141F, 1)

        '// 画面クリアー
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.ModeAll の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call HKKET141M.Clr_Display(gvcstInputCls.ModeAll)

        '// 初期入力モード
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Header1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvintInputCls = gvcstInputCls.Header1

        '//項目入力制御設定
        Call HKKET141M.Set_InputControl(gvintInputCls)

        '//表示情報管理取得
        '2019/04/16 CHG START
        'Call SetLvFormat("E01", HKKET141F.lvwMEISAI)
        Call SetLvFormat("E01", HKKET141F.lvwMEISAI, LvSortOrder, InitSortColumn)
        '2019/04/16 CHG E N D

        '//担当者権限による画面制御
        Call Set_TantoControl(HKKET141F)

        '//担当者権限による画面制御
        Call SetDspFormat()

        Set_Initialize = True

        '--------------------------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '--------------------------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    SetDspFormat
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    画面表示情報より画面表示する
    '//*****************************************************************************************
    Public Function SetDspFormat() As Boolean
        '2019/04/11 DEL START
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "SetDspFormat"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/12 DEL START
        'Dim objRec As OraDynaset
        '2019/04/12 DEL E N D
        Dim i As Short

        SetDspFormat = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト D0.Mouse_ON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_ON()

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT *               " & vbCrLf
        strSQL = strSQL & "FROM   HKKDTRA          " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  PRCCL  = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "AND    TANCD  = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'ﾚｺｰﾄﾞｾｯﾄ獲得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        ''If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            '2019/04/12 CHG START
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optCARRIES_ON.Checked = IIf(objRec("SELWRG").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optCARRIES_OFF.Checked = IIf(objRec("SELWRG").Value = "0", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optSAFTY_STOCK.Checked = IIf(objRec("SELAZK").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtSAFTY_STOCK.Text = D0.Chk_NullN(objRec("AZKMNT").Value)
            'If HKKET141F.optSAFTY_STOCK.Checked Then
            '    HKKET141F.txtSAFTY_STOCK.Enabled = True
            'Else
            '    HKKET141F.txtSAFTY_STOCK.Enabled = False
            'End If
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optSTOCK.Checked = IIf(objRec("SELZK").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtSTOCK.Text = D0.Chk_NullN(objRec("ZKMNT").Value)
            'If HKKET141F.optSTOCK.Checked Then
            '    HKKET141F.txtSTOCK.Enabled = True
            'Else
            '    HKKET141F.txtSTOCK.Enabled = False
            'End If
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optSTOCK_MONTH.Checked = IIf(objRec("SELZMNT").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtSTOCK_MONTH.Text = D0.Chk_NullN(objRec("ZMNT").Value)
            'If HKKET141F.optSTOCK_MONTH.Checked Then
            '    HKKET141F.txtSTOCK_MONTH.Enabled = True
            'Else
            '    HKKET141F.txtSTOCK_MONTH.Enabled = False
            'End If
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optORDER_OMISSION.Checked = IIf(objRec("SELORD").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtORDER_OMISSION.Text = D0.Chk_NullN(objRec("ORDDT").Value)

            'If HKKET141F.optORDER_OMISSION.Checked Then
            '    HKKET141F.txtORDER_OMISSION.Enabled = True
            'Else
            '    HKKET141F.txtORDER_OMISSION.Enabled = False
            'End If

            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINCD.Text = D0.Chk_Null(objRec("HINCD").Value)

            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(0).Text = D0.Chk_Null(objRec("HINGRP1").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(1).Text = D0.Chk_Null(objRec("HINGRP2").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(2).Text = D0.Chk_Null(objRec("HINGRP3").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(3).Text = D0.Chk_Null(objRec("HINGRP4").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(4).Text = D0.Chk_Null(objRec("HINGRP5").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINGRP(5).Text = D0.Chk_Null(objRec("HINGRP6").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtHINNMA.Text = D0.Chk_Null(objRec("HINKTA").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(0).Text = D0.Chk_Null(objRec("ZAIRNK1").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(1).Text = D0.Chk_Null(objRec("ZAIRNK2").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(2).Text = D0.Chk_Null(objRec("ZAIRNK3").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(3).Text = D0.Chk_Null(objRec("ZAIRNK4").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(4).Text = D0.Chk_Null(objRec("ZAIRNK5").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(5).Text = D0.Chk_Null(objRec("ZAIRNK6").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(6).Text = D0.Chk_Null(objRec("ZAIRNK7").Value)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtZAIRNK(7).Text = D0.Chk_Null(objRec("ZAIRNK8").Value)
            ''//V1.10 2006/10/15  ADD START  RISE)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.txtMNFDD.Text = D0.Chk_Null(objRec("MNFDD").Value)
            ''//V1.10 2006/10/15  ADD E N D  RISE)

            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optORDER_ON.Checked = IIf(objRec("SELJYM").Value = "1", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optORDER_OFF.Checked = IIf(objRec("SELJYM").Value = "0", True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET141F.optONLY.Checked = IIf(objRec("SELGRP").Value = 1, True, False)
            ''UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            HKKET141F.optCARRIES_ON.Checked = IIf(dt.Rows(0)("SELWRG") = "1", True, False)
            HKKET141F.optCARRIES_OFF.Checked = IIf(dt.Rows(0)("SELWRG") = "0", True, False)
            HKKET141F.optSAFTY_STOCK.Checked = IIf(dt.Rows(0)("SELAZK") = "1", True, False)
            HKKET141F.txtSAFTY_STOCK.Text = D0.Chk_NullN(dt.Rows(0)("AZKMNT"))
            If HKKET141F.optSAFTY_STOCK.Checked Then
                HKKET141F.txtSAFTY_STOCK.Enabled = True
            Else
                HKKET141F.txtSAFTY_STOCK.Enabled = False
            End If
            HKKET141F.optSTOCK.Checked = IIf(dt.Rows(0)("SELZK") = "1", True, False)
            HKKET141F.txtSTOCK.Text = D0.Chk_NullN(dt.Rows(0)("ZKMNT"))
            If HKKET141F.optSTOCK.Checked Then
                HKKET141F.txtSTOCK.Enabled = True
            Else
                HKKET141F.txtSTOCK.Enabled = False
            End If
            HKKET141F.optSTOCK_MONTH.Checked = IIf(dt.Rows(0)("SELZMNT") = "1", True, False)
            HKKET141F.txtSTOCK_MONTH.Text = D0.Chk_NullN(dt.Rows(0)("ZMNT"))
            If HKKET141F.optSTOCK_MONTH.Checked Then
                HKKET141F.txtSTOCK_MONTH.Enabled = True
            Else
                HKKET141F.txtSTOCK_MONTH.Enabled = False
            End If
            HKKET141F.optORDER_OMISSION.Checked = IIf(dt.Rows(0)("SELORD") = "1", True, False)
            HKKET141F.txtORDER_OMISSION.Text = D0.Chk_NullN(dt.Rows(0)("ORDDT"))

            If HKKET141F.optORDER_OMISSION.Checked Then
                HKKET141F.txtORDER_OMISSION.Enabled = True
            Else
                HKKET141F.txtORDER_OMISSION.Enabled = False
            End If
            HKKET141F.txtHINCD.Text = D0.Chk_Null(dt.Rows(0)("HINCD"))
            HKKET141F.txtHINGRP(0).Text = D0.Chk_Null(dt.Rows(0)("HINGRP1"))
            HKKET141F.txtHINGRP(1).Text = D0.Chk_Null(dt.Rows(0)("HINGRP2"))
            HKKET141F.txtHINGRP(2).Text = D0.Chk_Null(dt.Rows(0)("HINGRP3"))
            HKKET141F.txtHINGRP(3).Text = D0.Chk_Null(dt.Rows(0)("HINGRP4"))
            HKKET141F.txtHINGRP(4).Text = D0.Chk_Null(dt.Rows(0)("HINGRP5"))
            HKKET141F.txtHINGRP(5).Text = D0.Chk_Null(dt.Rows(0)("HINGRP6"))
            HKKET141F.txtHINNMA.Text = D0.Chk_Null(dt.Rows(0)("HINKTA"))
            HKKET141F.txtZAIRNK(0).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK1"))
            HKKET141F.txtZAIRNK(1).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK2"))
            HKKET141F.txtZAIRNK(2).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK3"))
            HKKET141F.txtZAIRNK(3).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK4"))
            HKKET141F.txtZAIRNK(4).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK5"))
            HKKET141F.txtZAIRNK(5).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK6"))
            HKKET141F.txtZAIRNK(6).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK7"))
            HKKET141F.txtZAIRNK(7).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK8"))
            HKKET141F.txtMNFDD.Text = D0.Chk_Null(dt.Rows(0)("MNFDD"))
            HKKET141F.optORDER_ON.Checked = IIf(dt.Rows(0)("SELJYM") = "1", True, False)
            HKKET141F.optORDER_OFF.Checked = IIf(dt.Rows(0)("SELJYM") = "0", True, False)
            HKKET141F.optONLY.Checked = IIf(dt.Rows(0)("SELGRP") = 1, True, False)
            HKKET141F.optVERSION.Checked = IIf(dt.Rows(0)("SELVER") = 1, True, False)
            '2019/04/12 CHG E N D
        End If

        SetDspFormat = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: オブジェクト D0.Mouse_OFF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト clsOra.OraRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/19 CHG START
        'clsOra.OraRollback()
        Call DB_Rollback()
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    SavDspFormat
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    画面表示情報を更新する
    '//*****************************************************************************************
    Public Function SavDspFormat() As Boolean
        '2019/04/11 DEL START
        'Dim gvstrCLTID As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "SavDspFormat"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset
        Dim i As Short

        SavDspFormat = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト D0.Mouse_ON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_ON()

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT *               " & vbCrLf
        strSQL = strSQL & "FROM   HKKDTRA          " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  PRCCL  = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "AND    TANCD  = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'ﾚｺｰﾄﾞｾｯﾄ獲得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        'UPGRADE_WARNING: オブジェクト clsOra.OraBeginTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            strSQL = ""
            strSQL = strSQL & "UPDATE HKKDTRA                       " & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "SET    SELWRG    = " & D0.Edt_SQL("N", IIf(HKKET141F.optCARRIES_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELAZK    = " & D0.Edt_SQL("N", IIf(HKKET141F.optSAFTY_STOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      AZKMNT    = " & D0.Edt_SQL("N", IIf(CBool(Trim(CStr(HKKET141F.txtSAFTY_STOCK.Text = ""))), 0, HKKET141F.txtSAFTY_STOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELZK     = " & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZKMNT     = " & D0.Edt_SQL("N", IIf(CBool(Trim(CStr(HKKET141F.txtSTOCK.Text = ""))), 0, HKKET141F.txtSTOCK.Text)) & vbCrLf

            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELZMNT   = " & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK_MONTH.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZMNT      = " & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK_MONTH.Text) = "", 0, HKKET141F.txtSTOCK_MONTH.Text)) & vbCrLf

            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELORD    = " & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_OMISSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ORDDT     = " & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtORDER_OMISSION.Text) = "", 0, HKKET141F.txtORDER_OMISSION.Text)) & vbCrLf

            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINCD     = " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP1   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(0).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP2   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(1).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP3   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(2).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP4   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(3).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP5   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(4).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINGRP6   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(5).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      HINKTA    = " & D0.Edt_SQL("S", HKKET141F.txtHINNMA.Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK1   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(0).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK2   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(1).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK3   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(2).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK4   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(3).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK5   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(4).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK6   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(5).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK7   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(6).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      ZAIRNK8   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(7).Text) & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      MNFDD     = " & D0.Edt_SQL("S", HKKET141F.txtMNFDD.Text) & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELJYM    = " & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELGRP    = " & D0.Edt_SQL("N", IIf(HKKET141F.optONLY.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      SELVER    = " & D0.Edt_SQL("N", IIf(HKKET141F.optVERSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      OPEID     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",      CLTID     = " & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTTM     = " & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & ",      WRTTM     = " & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowDt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTDT     = " & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & ",      WRTDT     = " & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTFSTTM  = " & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & ",      WRTFSTTM  = " & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowDt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTFSTDT  = " & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & ",      WRTFSTDT  = " & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "WHERE  PRCCL     = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "AND    TANCD     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        Else
            strSQL = ""
            strSQL = "insert into HKKDTRA  " & vbCrLf
            strSQL = strSQL & "(PRCCL      " & vbCrLf
            strSQL = strSQL & " , TANCD    " & vbCrLf
            strSQL = strSQL & " , SELWRG   " & vbCrLf
            strSQL = strSQL & " , SELAZK   " & vbCrLf
            strSQL = strSQL & " , AZKMNT   " & vbCrLf
            strSQL = strSQL & " , SELZK    " & vbCrLf
            strSQL = strSQL & " , ZKMNT    " & vbCrLf
            strSQL = strSQL & " , SELZMNT  " & vbCrLf
            strSQL = strSQL & " , ZMNT     " & vbCrLf
            strSQL = strSQL & " , SELORD   " & vbCrLf
            strSQL = strSQL & " , ORDDT    " & vbCrLf
            strSQL = strSQL & " , HINCD    " & vbCrLf
            strSQL = strSQL & " , HINGRP1  " & vbCrLf
            strSQL = strSQL & " , HINGRP2  " & vbCrLf
            strSQL = strSQL & " , HINGRP3  " & vbCrLf
            strSQL = strSQL & " , HINGRP4  " & vbCrLf
            strSQL = strSQL & " , HINGRP5  " & vbCrLf
            strSQL = strSQL & " , HINGRP6  " & vbCrLf
            strSQL = strSQL & " , HINKTA   " & vbCrLf
            strSQL = strSQL & " , ZAIRNK1  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK2  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK3  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK4  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK5  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK6  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK7  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK8  " & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            strSQL = strSQL & " , MNFDD    " & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)

            strSQL = strSQL & " , SELJYM   " & vbCrLf
            strSQL = strSQL & " , SELGRP   " & vbCrLf
            strSQL = strSQL & " , SELVER   " & vbCrLf
            strSQL = strSQL & " , OPEID    " & vbCrLf
            strSQL = strSQL & " , CLTID    " & vbCrLf
            strSQL = strSQL & " , WRTTM    " & vbCrLf
            strSQL = strSQL & " , WRTDT    " & vbCrLf
            strSQL = strSQL & " , WRTFSTTM " & vbCrLf
            strSQL = strSQL & " , WRTFSTDT " & vbCrLf
            strSQL = strSQL & ")           " & vbCrLf
            strSQL = strSQL & "VALUES      " & vbCrLf
            strSQL = strSQL & "(            " & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optCARRIES_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSAFTY_STOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSAFTY_STOCK.Text) = "", 0, HKKET141F.txtSAFTY_STOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK.Text) = "", 0, HKKET141F.txtSTOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK_MONTH.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK_MONTH.Text) = "", 0, HKKET141F.txtSTOCK_MONTH.Text)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_OMISSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", HKKET141F.txtORDER_OMISSION.Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(0).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(1).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(2).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(3).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(4).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(5).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINNMA.Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(0).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(1).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(2).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(3).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(4).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(5).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(6).Text) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(7).Text) & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtMNFDD.Text) & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optONLY.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optVERSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowDt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト clsOra.OraGetNowDt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            strSQL = strSQL & ")           " & vbCrLf
        End If
        'UPGRADE_WARNING: オブジェクト clsOra.OraExecute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraExecute(strSQL)
        Call DB_Execute(strSQL)
        '2019/04/12 CHG E N D

        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        'UPGRADE_WARNING: オブジェクト clsOra.OraCommitTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/12 CHG E N D

        SavDspFormat = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: オブジェクト D0.Mouse_OFF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト clsOra.OraRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/19 CHG START
        'clsOra.OraRollback()
        Call DB_Rollback()
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_ObjectGotFocus
    '//*
    '//* <戻り値>
    '//*
    '//* <引  数>     項目名              I/O      内容
    '//*
    '//* <説  明>
    '//*    GotFocus時に共通で使用する関数（カーソル反転等)
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Sub Set_ObjectGotFocus(ByVal pmoObject As Object, Optional ByVal pmvIndex As Object = Nothing)
    Public Sub Set_ObjectGotFocus(ByVal pmoObject As Control, Optional ByVal pmvIndex As Object = Nothing)
        '2019/04/15 CHG E N D

        If TypeOf pmoObject Is System.Windows.Forms.TextBox Then
            'UPGRADE_WARNING: オブジェクト pmoObject.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15 CHG START
            'If Not pmoObject.Locked Then
            If Not (pmoObject.Enabled = False) Then
                '2019/04/15 CHG E N D
                'UPGRADE_WARNING: オブジェクト ClsFocus.SetSelCursor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ClsFocus.SetSelCursor(pmoObject)
            End If
        End If
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_TantoControl
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            pmForm              Form             I
    '//*
    '//* <説  明>
    '//*    担当者の権限で使用できるボタン等を設定する
    '//*****************************************************************************************
    Public Function Set_TantoControl(ByRef pmForm As Object) As Boolean
        '2019/04/11 DEL START
        'Dim gs_UPDAUTH As Object
        'Dim gs_SAPMAUTH As Object
        'Dim gs_FILEAUTH As Object
        'Dim Get_Authority As Object
        'Dim gs_pgid As Object
        'Dim gs_userid As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_TantoControl"

        Dim strSAPMODKB As String
        Dim strSAPCSVKB As String
        Dim i As Short

        Set_TantoControl = False

        On Error GoTo ONERR_STEP

        '/プログラムの実行権限を取得
        'UPGRADE_WARNING: オブジェクト gvstrOPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gs_userid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gs_userid = gvstrOPEID
        'UPGRADE_WARNING: オブジェクト gs_pgid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gs_pgid = gvcstJOB_ID
        'UPGRADE_WARNING: オブジェクト Get_Authority(gvstrUNYDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Get_Authority(gvstrUNYDT) = "9" Then
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト pmForm.Name の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case pmForm.Name
            Case "HKKET141F"
                '//CSV出力ボタン制御
                'UPGRADE_WARNING: オブジェクト gs_FILEAUTH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gs_FILEAUTH = "1" Then
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdCSVOUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdCSVOUT.Enabled = True
                Else
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdCSVOUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdCSVOUT.Enabled = False
                End If
                'UPGRADE_WARNING: オブジェクト gs_SAPMAUTH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gs_SAPMAUTH = "1" Then
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdINPUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdINPUT.Enabled = True
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdOUTPUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdOUTPUT.Enabled = True
                Else
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdINPUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdINPUT.Enabled = False
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdOUTPUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdOUTPUT.Enabled = False
                End If

                '// 2007/02/17 ↓ ADD STR
                If gvintPGHaita = 9 Then
                    HKKET141F.cmdOUTPUT.Enabled = False
                    HKKET141F.cmdCSVOUT.Enabled = False
                    HKKET141F.cmdINPUT.Enabled = False
                End If
                '// 2007/02/17 ↑ ADD STR

            Case "HKKET142F"
                '//CSV出力ボタン制御
                'UPGRADE_WARNING: オブジェクト gs_FILEAUTH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gs_FILEAUTH = "1" Then
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdCSVOUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdCSVOUT.Enabled = True
                Else
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdCSVOUT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdCSVOUT.Enabled = False
                End If
                'UPGRADE_WARNING: オブジェクト gs_SAPMAUTH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gs_SAPMAUTH <> "1" Then
                    'UPGRADE_WARNING: オブジェクト pmForm.txtLMAHKS の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    For i = 0 To pmForm.txtLMAHKS.UBound
                        'UPGRADE_WARNING: オブジェクト pmForm.txtLMAHKS の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pmForm.txtLMAHKS(i).Enabled = False
                        'UPGRADE_WARNING: オブジェクト pmForm.txtLMAHMS の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pmForm.txtLMAHMS(i).Enabled = False
                    Next i
                End If
                'UPGRADE_WARNING: オブジェクト gs_UPDAUTH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gs_UPDAUTH = "1" Then
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdUPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdUPD.Enabled = True
                Else
                    'UPGRADE_WARNING: オブジェクト pmForm.cmdUPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pmForm.cmdUPD.Enabled = False
                End If

                '// 2007/02/17 ↓ ADD STR
                If gvintPGHaita = 9 Then
                    HKKET142F.cmdCSVOUT.Enabled = False
                    HKKET142F.cmdUPD.Enabled = False
                End If
                '// 2007/02/17 ↑ ADD STR

            Case "HKKET143F"
        End Select
        '// 2007/01/09 ↑ UPD END

        Set_TantoControl = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function


    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Clr_Display
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            pm_lng_ProcCLS      Long             I      0:画面全体, 1:ヘッダ部, 2:明細部
    '//*
    '//* <説  明>
    '//*    画面クリア処理
    '//*****************************************************************************************
    Sub Clr_Display(Optional ByVal pm_lng_ProcCLS As Integer = 0)
        '2019/04/11 DEL START
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Clr_Display"

        Dim i As Short

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Detail1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Header1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.ModeAll の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case pm_lng_ProcCLS

            '//全画面
            Case gvcstInputCls.ModeAll
                With HKKET141F
                    .optCARRIES_ON.Checked = True
                    .optSAFTY_STOCK.Checked = True
                    .txtSAFTY_STOCK.Text = CStr(0)
                    .txtSTOCK.Text = CStr(0)
                    .txtSTOCK_MONTH.Text = CStr(0)
                    .txtORDER_OMISSION.Text = CStr(0)
                    .txtHINCD.Text = vbNullString
                    .txtHINGRP(0).Text = vbNullString
                    .txtHINGRP(1).Text = vbNullString
                    .txtHINGRP(2).Text = vbNullString
                    .txtHINGRP(3).Text = vbNullString
                    .txtHINGRP(4).Text = vbNullString
                    .txtHINGRP(5).Text = vbNullString
                    .txtHINNMA.Text = vbNullString
                    .txtZAIRNK(0).Text = vbNullString
                    .txtZAIRNK(1).Text = vbNullString
                    .txtZAIRNK(2).Text = vbNullString
                    .txtZAIRNK(3).Text = vbNullString
                    .txtZAIRNK(4).Text = vbNullString
                    .txtZAIRNK(5).Text = vbNullString
                    .txtZAIRNK(6).Text = vbNullString
                    .txtZAIRNK(7).Text = vbNullString
                    '//V1.10 2006/10/02  ADD START  RISE)
                    .txtMNFDD.Text = vbNullString
                    '//V1.10 2006/10/02  ADD E N D  RISE)
                    .optORDER_ON.Checked = True
                    .optONLY.Checked = True
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/11 CHG START
                    '.lvwMEISAI.ListItems.Clear()
                    .lvwMEISAI.Items.Clear()
                    '2019/04/11 CHG E N D
                End With

                '//ヘッダ部
            Case gvcstInputCls.Header1
                With HKKET141F
                    .optCARRIES_ON.Checked = True
                    .optSAFTY_STOCK.Checked = True
                    .txtSAFTY_STOCK.Text = CStr(0)
                    .txtSTOCK.Text = CStr(0)
                    .txtSTOCK_MONTH.Text = CStr(0)
                    .txtORDER_OMISSION.Text = CStr(0)
                    .txtHINCD.Text = vbNullString
                    .txtHINGRP(0).Text = vbNullString
                    .txtHINGRP(1).Text = vbNullString
                    .txtHINGRP(2).Text = vbNullString
                    .txtHINGRP(3).Text = vbNullString
                    .txtHINGRP(4).Text = vbNullString
                    .txtHINGRP(5).Text = vbNullString
                    .txtHINNMA.Text = vbNullString
                    .txtZAIRNK(0).Text = vbNullString
                    .txtZAIRNK(1).Text = vbNullString
                    .txtZAIRNK(2).Text = vbNullString
                    .txtZAIRNK(3).Text = vbNullString
                    .txtZAIRNK(4).Text = vbNullString
                    .txtZAIRNK(5).Text = vbNullString
                    '//V1.10 2006/10/02  ADD START  RISE)
                    .txtMNFDD.Text = vbNullString
                    '//V1.10 2006/10/02  ADD E N D  RISE)
                    .optORDER_ON.Checked = True
                    .optONLY.Checked = True
                End With

                '//ボディ部
            Case gvcstInputCls.Detail1
                With HKKET141F
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/11 CHG START
                    '.lvwMEISAI.ListItems.Clear()
                    .lvwMEISAI.Items.Clear()
                    '2019/04/11 CHG E N D
                End With
        End Select

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_InputControl
    '//*
    '//* <戻り値>
    '//*
    '//*
    '//* <引  数>   項目名                     I/O     内容
    '//*            pm_lng_ProcCLS              I      0:画面全体, 1:ヘッダ部, 2:明細部
    '//*
    '//* <説  明>
    '//*    項目,ファンクションキー使用可，使用不可設定処理
    '//*****************************************************************************************
    Sub Set_InputControl(Optional ByVal pm_lng_ProcCLS As Integer = 0)
        '2019/04/11 DEL START
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_InputControl"

        Dim i As Short

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Detail1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Header1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.ModeAll の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case pm_lng_ProcCLS

            '//全画面
            Case gvcstInputCls.ModeAll
                With HKKET141F
                    .fraWARNING.Enabled = False
                    .frmDISPLAY.Enabled = False
                    .frmGROUP.Enabled = False
                    .fraORDER.Enabled = False
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .lvwMEISAI.Enabled = False
                    .cmdSERCH.Enabled = False
                    .cmdALL_SELECT.Enabled = False
                    .cmdALL_RELEASE.Enabled = False
                    .cmdCSVOUT.Enabled = False
                    .cmdDISPLAY.Enabled = False
                    .cmdEND.Enabled = False
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .lvwMEISAI.Enabled = False
                End With

                '//ヘッダ部
            Case gvcstInputCls.Header1
                With HKKET141F
                    .fraWARNING.Enabled = True
                    .frmDISPLAY.Enabled = True
                    .frmGROUP.Enabled = True
                    .fraORDER.Enabled = True
                    .cmdSERCH.Enabled = True
                    .cmdEND.Enabled = True
                    '.cmdINPUT.Enabled = True

                    .cmdALL_SELECT.Enabled = False
                    .cmdALL_RELEASE.Enabled = False
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .lvwMEISAI.Enabled = False
                    .cmdCSVOUT.Enabled = False
                    .cmdOUTPUT.Enabled = False
                    .cmdDISPLAY.Enabled = False
                End With

                '//ボディ部
            Case gvcstInputCls.Detail1
                With HKKET141F
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .lvwMEISAI.Enabled = True
                    .cmdDISPLAY.Enabled = True

                    .cmdALL_SELECT.Enabled = True
                    .cmdALL_RELEASE.Enabled = True
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .lvwMEISAI.Enabled = True
                    .cmdDISPLAY.Enabled = True

                    '// 2007/02/24 ↓ ADD STR
                    ''''                .lvwMEISAI.SetFocus
                    '// 2007/02/24 ↑ ADD STR
                    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.FullRowSelect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    HKKET141F.lvwMEISAI.FullRowSelect = True


                End With
        End Select

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_DisplayData
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*
    '//*****************************************************************************************
    Public Function Get_DisplayData() As Boolean

        Const PROCEDURE As String = "Get_DisplayData"

        'UPGRADE_ISSUE: ListItem オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        '2019/04/11 DEL E N D

        Get_DisplayData = False

        'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Clear()
        HKKET141F.lvwMEISAI.Items.Clear()
        '2019/04/11 CHG E N D

        '2019/04/16 ADD START
        HKKET141F.LvSorter141F.Order = SortOrder.None
        '2019/04/16 ADD E N D

        '//販売計画前日Ｆ取得
        If Not Get_HKKZTRA() Then
            GoTo EXIT_STEP
        End If

        On Error GoTo ONERR_STEP

        Get_DisplayData = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_HKKZTRA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    販売計画前日Ｆを取得する
    '//*****************************************************************************************
    Public Function Get_HKKZTRA() As Boolean

        Const PROCEDURE As String = "Get_HKKZTRA"

        '// 2007/02/02 ↓ UPD STR
        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset
        Dim i As Short
        Dim j As Short
        Dim strZAI As String
        Dim strHIN As String
        Dim strSafty As String
        Dim strColumn As String
        Dim intMonth As Short
        Dim blnMonth As Boolean
        Dim strLMALDTA As String
        Dim aryMonthStr() As Object
        Dim intKeikaMonth As Short

        Get_HKKZTRA = False

        On Error GoTo ONERR_STEP

        intMonth = CShort(Mid(gvstrUNYDT, 5, 2))

        ' テーブル項目変換テーブル
        'UPGRADE_WARNING: Array に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        aryMonthStr = New Object() {"", "", "", "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}

        blnMonth = True
        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   HKKZTRA A" & vbCrLf
        strSQL = strSQL & ",      HKKZTRB B" & vbCrLf
        strSQL = strSQL & ",      ODINTRA C" & vbCrLf
        ''  strSQL = strSQL & ",      HINMTA  D" & vbCrLf   ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL

        '''''// 2007/02/13 ↓ ADD STR
        ''''    If HKKET141F.optVERSION.Value = True Then
        ''''        strZAI = vbNullString
        ''''        For i = 0 To HKKET141F.txtZAIRNK.UBound
        ''''            If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
        ''''                strZAI = strZAI & "     OR      INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf
        ''''            End If
        ''''        Next i
        ''''        If strZAI <> vbNullString Then
        ''''            strSQL = strSQL & ",   (SELECT SUBSTR(HINCD,1,6) HINCD FROM HINMTA " & vbCrLf
        ''''            strSQL = strSQL & "     WHERE (" & Mid(strZAI, 8) & ")" & vbCrLf
        ''''            strSQL = strSQL & "     AND   HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''            strSQL = strSQL & "     GROUP BY HINCD) D " & vbCrLf
        ''''        End If
        ''''    End If
        '''''// 2007/02/13 ↑ ADD END

        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  A.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  A.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  A.HINKTA LIKE " & D0.Edt_SQL("S", "%" & HKKET141F.txtHINNMA.Text & "%") & vbCrLf
        strSQL = strSQL & "  AND  A.HINCD = B.HINCD " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  B.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  B.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        strSQL = strSQL & "  AND  B.HINCD = C.HINCD " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  C.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  C.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        ''  strSQL = strSQL & "  AND  C.HINCD = D.HINCD " & vbCrLf                                                       ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL
        ''  strSQL = strSQL & "  AND  D.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf           ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL
        ''  strSQL = strSQL & "  AND  D.ZAIKB = " & D0.Edt_SQL("S", "1") & vbCrLf                                        ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL

        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  A.ZAIKB = " & D0.Edt_SQL("S", "1") & vbCrLf '                2007/08/09 ADD 2007/08/17 DEL 2007/09/10 ADD
        If Trim(HKKET141F.txtMNFDD.Text) <> "" Then
            '' 発注L/T = 調達L/T + 製造L/T
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.PRCDD,0)) + TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        End If

        '''''// 2007/02/13 ↓ ADD STR
        ''''    If HKKET141F.optVERSION.Value = True Then
        ''''        If strZAI <> vbNullString Then
        ''''            strSQL = strSQL & "  AND  D.HINCD = A.HINCD " & vbCrLf
        ''''        End If
        ''''    End If
        '''''// 2007/02/13 ↑ ADD END

        '''''// 2007/02/13 ↓ ADD STR
        ''''    If HKKET141F.optONLY.Value = True Then
        '''''// 2007/02/13 ↑ ADD END
        strZAI = vbNullString
        For i = 0 To HKKET141F.txtZAIRNK.UBound
            If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
                ''              strZAI = strZAI & "   OR   INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf ' 2007/07/31 UPD
                'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strZAI = strZAI & "   OR   INSTR(A.ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf
            End If
        Next i
        '''''// 2007/02/13 ↓ ADD STR
        ''''    End If
        '''''// 2007/02/13 ↑ ADD END

        strHIN = vbNullString
        'Debug.Print(HKKET141F.txtHINGRP.UBound)
        For i = 0 To HKKET141F.txtHINGRP.UBound
            Debug.Print(Trim(HKKET141F.txtHINGRP(i).Text))
            If Trim(HKKET141F.txtHINGRP(i).Text) <> "" Then
                '''''       strHIN = strHIN & "   OR   INSTR(HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 " & vbCrLf
                'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strHIN = strHIN & "   OR   INSTR(A.HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 " & vbCrLf ' 2007/07/30 UPD
            End If
        Next i

        '''''// 2007/02/13 ↓ ADD STR
        ''''    If HKKET141F.optONLY.Value = True Then
        '''''// 2007/02/13 ↑ ADD END

        If strZAI <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strZAI, 8) & ")" & vbCrLf
        End If
        '''''// 2007/02/13 ↓ ADD STR
        ''''    End If
        '''''// 2007/02/13 ↑ ADD END

        If strHIN <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strHIN, 8) & ")" & vbCrLf
        End If
        With HKKET141F
            strSafty = vbNullString

            If intMonth <= 3 Then
                intMonth = intMonth + 12
            End If

            If .optCARRIES_ON.Checked Then

                strLMALDTA = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
                intKeikaMonth = 0

                For i = intMonth To UBound(aryMonthStr)

                    If i <= 15 Then
                        blnMonth = True ' 当月
                    Else
                        blnMonth = False ' 次月
                    End If

                    intKeikaMonth = intKeikaMonth + 1

                    Select Case True
                        '安全在庫切れ
                        Case .optSAFTY_STOCK.Checked
                            If CShort(.txtSAFTY_STOCK.Text) >= intKeikaMonth Then
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMAMAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMAAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMBMAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMBAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                End If
                            End If
                            '在庫切れ
                        Case .optSTOCK.Checked
                            If CShort(.txtSTOCK.Text) >= intKeikaMonth Then
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMAMZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMAZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMBMZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strSafty = strSafty & "  OR  LMBZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                End If
                            End If
                            '在庫月数
                        Case .optSTOCK_MONTH.Checked
                            If blnMonth Then
                                If HKKET141F.optORDER_ON.Checked Then
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    strSafty = strSafty & "  OR  LMAMZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                Else
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    strSafty = strSafty & "  OR  LMAZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                End If
                            Else
                                If HKKET141F.optORDER_ON.Checked Then
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    strSafty = strSafty & "  OR  LMBMZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                Else
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    strSafty = strSafty & "  OR  LMBZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                End If
                            End If
                            '発注漏れ
                        Case .optORDER_OMISSION.Checked
                            If blnMonth Then
                                ''''                            strSafty = strSafty & "  OR  (TRIM(LMAHDT" & aryMonthStr(i) & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  OR  (TRIM(LMALDT" & aryMonthStr(i) & ") <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMAIPK" & aryMonthStr(i) & "),'0'))  >  0  " & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMANOS" & aryMonthStr(i) & "),'0'))  <= 0  " & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMANOSS" & aryMonthStr(i) & "),'0')) <= 0 )" & vbCrLf
                            Else
                                ''''                            strSafty = strSafty & "  OR  (TRIM(LMBHDT" & aryMonthStr(i) & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  OR  (TRIM(LMBLDT" & aryMonthStr(i) & ") <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBIPK" & aryMonthStr(i) & "),'0'))  >  0  " & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBNOS" & aryMonthStr(i) & "),'0'))  <= 0  " & vbCrLf
                                'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBNOSS" & aryMonthStr(i) & "),'0')) <= 0 )" & vbCrLf
                            End If

                    End Select
                Next i
            End If
        End With

        ' 比較SQLを付加する
        If strSafty <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strSafty, 7) & ")"
        End If

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn("SELECT COUNT(*)" & Mid(strSQL, 9), objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable("SELECT COUNT(*)" & Mid(strSQL, 9))
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'HKKET141F.txtCount.Text = VB6.Format(D0.Chk_NullN(objRec(0).Value), "#,##0")
            HKKET141F.txtCount.Text = VB6.Format(D0.Chk_NullN(dt.Rows(0)("COUNT(*)")), "#,##0")
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'If D0.Chk_NullN(objRec(0).Value) > 100 Then
            If D0.Chk_NullN(dt.Rows(0)("COUNT(*)")) > 100 Then
                '2019/04/12 CHG E N D
                'UPGRADE_WARNING: オブジェクト objRec().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/12 CHG START
                'If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "抽出件数：＝" & D0.Chk_NullN(objRec(0).Value) & "件") = MsgBoxResult.Cancel Then
                If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "抽出件数：＝" & D0.Chk_NullN(dt.Rows(0)("COUNT(*)")) & "件") = MsgBoxResult.Cancel Then
                    '2019/04/12 CHG E N D
                    HKKET141F.cmdALL_SELECT.Enabled = False
                    HKKET141F.cmdALL_RELEASE.Enabled = False
                    HKKET141F.cmdDISPLAY.Enabled = False
                    GoTo EXIT_STEP
                End If
            End If
        End If

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        dt = Nothing
        dt = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            '//販売計画前日Ｆより画面に表示する
            '2019/04/15 CHG START
            'If Not Set_HKKZTRA(objRec) Then
            If Not Set_HKKZTRA(dt) Then
                '2019/04/15 CHG E N D
                GoTo EXIT_STEP
            End If
        Else
            HKKET141F.txtCount.Text = CStr(0)
            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "105")
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKKZTRA = True

        ''''    Dim strSQL          As String
        ''''    Dim objRec          As OraDynaset
        ''''    Dim i               As Integer
        ''''    Dim j               As Integer
        ''''    Dim strZAI          As String
        ''''    Dim strHIN          As String
        ''''    Dim strSafty        As String
        ''''    Dim strColumn       As String
        ''''    Dim intMonth        As Integer
        ''''    Dim blnMonth        As Boolean
        ''''    Dim strLMALDTA      As String
        ''''
        ''''    Get_HKKZTRA = False
        ''''
        ''''    On Error GoTo ONERR_STEP
        ''''
        ''''    intMonth = CInt(Mid(gvstrUNYDT, 5, 2))
        ''''
        ''''    blnMonth = True
        ''''    ' SQL文の作成
        ''''    strSQL = ""
        ''''    strSQL = strSQL & "SELECT * " & vbCrLf
        ''''    strSQL = strSQL & "FROM   HKKZTRA A" & vbCrLf
        ''''    strSQL = strSQL & ",      HKKZTRB B" & vbCrLf
        ''''    strSQL = strSQL & ",      ODINTRA C" & vbCrLf
        ''''    strSQL = strSQL & "WHERE  A.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  A.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''    strSQL = strSQL & "  AND  A.HINKTA LIKE " & D0.Edt_SQL("S", "%" & HKKET141F.txtHINNMA.Text & "%") & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  A.HINCD = B.HINCD " & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  B.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  B.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  B.HINCD = C.HINCD " & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  C.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  C.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''    '//V1.10 2006/10/02  ADD START  RISE)
        ''''    If Trim(HKKET141F.txtMNFDD.Text) <> "" Then
        '''''''     strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        '''''' 発注L/T = 調達L/T + 製造L/T
        ''''        strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.PRCDD,0)) + TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        ''''    End If
        ''''    '//V1.10 2006/10/02  ADD E N D  RISE)
        ''''
        ''''
        ''''    strZAI = vbNullString
        ''''    For i = 0 To HKKET141F.txtZAIRNK.UBound
        ''''        If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
        ''''            strZAI = strZAI & "   OR   INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 "
        ''''        End If
        ''''    Next i
        ''''    strHIN = vbNullString
        ''''    For i = 0 To HKKET141F.txtHINGRP.UBound
        ''''        If Trim(HKKET141F.txtHINGRP(i).Text) <> "" Then
        ''''            strHIN = strHIN & "   OR   INSTR(HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 "
        ''''        End If
        ''''    Next i
        ''''    If strZAI <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strZAI, 8) & ")"
        ''''    End If
        ''''
        ''''    If strHIN <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strHIN, 8) & ")"
        ''''    End If
        ''''
        ''''    With HKKET141F
        ''''        strSafty = vbNullString
        ''''        If .optCARRIES_ON.Value Then
        ''''            j = 1
        ''''            Do
        ''''                If intMonth > 3 Then
        ''''                    strColumn = Chr(61 + intMonth)
        ''''                Else
        ''''                    strColumn = Chr(73 + intMonth)
        ''''                End If
        ''''                Select Case True
        ''''                    Case .optSAFTY_STOCK.Value
        ''''                        If blnMonth Then
        ''''                            strSafty = strSafty & "  OR  LMAAZM" & strColumn & " = '1'" & vbCrLf
        ''''                        Else
        ''''                            strSafty = strSafty & "  OR  LMBAZM" & strColumn & " = '1'" & vbCrLf
        ''''                        End If
        ''''
        ''''                        If j = CInt(.txtSAFTY_STOCK.Text) Then
        ''''                            Exit Do
        ''''                        End If
        ''''                    Case .optSTOCK.Value
        ''''                            If blnMonth Then
        ''''                                strSafty = strSafty & "  OR  LMAZKM" & strColumn & " = '1'" & vbCrLf
        ''''                            Else
        ''''                                strSafty = strSafty & "  OR  LMBZKM" & strColumn & " = '1'" & vbCrLf
        ''''                            End If
        ''''
        ''''                            If j = CInt(.txtSTOCK.Text) Then
        ''''                                Exit Do
        ''''                            End If
        ''''                    Case .optSTOCK_MONTH.Value
        ''''                            If blnMonth Then
        ''''                                strSafty = strSafty & "  OR  TRIM(LMAZKT" & strColumn & ") >= " & .txtSTOCK_MONTH.Text & vbCrLf
        ''''                            Else
        ''''                                strSafty = strSafty & "  OR  TRIM(LMBZKT" & strColumn & ") >= " & .txtSTOCK_MONTH.Text & vbCrLf
        ''''                                If strColumn = "L" Then
        ''''                                    Exit Do
        ''''                                End If
        ''''                            End If
        ''''                    Case .optORDER_OMISSION.Value
        ''''                        strLMALDTA = Format(gvstrUNYDT, "@@@@/@@/@@")
        ''''                        If blnMonth Then
        ''''                            strSafty = strSafty & "  OR  TRIM(LMAHDT" & strColumn & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
        ''''                        Else
        ''''                            strSafty = strSafty & "  OR  TRIM(LMBHDT" & strColumn & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
        ''''                            If strColumn = "L" Then
        ''''                                Exit Do
        ''''                            End If
        ''''                        End If
        ''''                End Select
        ''''                intMonth = intMonth + 1
        ''''                If intMonth = 4 Then
        ''''                    intMonth = 1
        ''''                    blnMonth = False
        ''''                End If
        ''''                If intMonth = 16 Then
        ''''                    intMonth = 4
        ''''                    blnMonth = False
        ''''                End If
        ''''                j = j + 1
        ''''            Loop
        ''''        End If
        ''''    End With
        ''''    If strSafty <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strSafty, 7) & ")"
        ''''    End If
        ''''
        ''''    ' データ取得
        ''''    If Not clsOra.OraCreateDyn("SELECT COUNT(*)" & Mid(strSQL, 9), objRec, , PROCEDURE) Then
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    If Not clsOra.OraEOF(objRec) Then
        ''''        HKKET141F.txtCount.Text = Format(D0.Chk_NullN(objRec(0).Value), "#,##0")
        ''''        If D0.Chk_NullN(objRec(0).Value) > 100 Then
        ''''            If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "抽出件数：＝" & D0.Chk_NullN(objRec(0).Value) & "件") = vbCancel Then
        ''''                HKKET141F.cmdALL_SELECT.Enabled = False
        ''''                HKKET141F.cmdALL_RELEASE.Enabled = False
        ''''                HKKET141F.cmdDISPLAY.Enabled = False
        ''''                GoTo EXIT_STEP
        ''''            End If
        ''''        End If
        ''''    End If
        ''''
        ''''    ' データ取得
        ''''    If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    If Not clsOra.OraEOF(objRec) Then
        ''''        '//販売計画前日Ｆより画面に表示する
        ''''        If Not Set_HKKZTRA(objRec) Then
        ''''            GoTo EXIT_STEP
        ''''        End If
        ''''    Else
        ''''        HKKET141F.txtCount.Text = 0
        ''''        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "105"
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    clsOra.OraCloseDyn objRec
        ''''
        ''''    Get_HKKZTRA = True
        '// 2007/02/02 ↑ UPD STR

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_HKKTRA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            pmStrHincd          String           I
    '//*            pmObjRec            OraDynaset       O
    '//*
    '//* <説  明>
    '//*    販売計画Ｆを取得する
    '//*****************************************************************************************
    Public Function Get_HKKTRA(ByRef pmStrHincd As String) As Boolean
        '2019/04/11 DEL START
        'Dim ORADYN_READONLY As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Get_HKKTRA"

        Dim strSQL As String

        Get_HKKTRA = False

        On Error GoTo ONERR_STEP

        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "AND    OPEID = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "AND    VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/19 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, gvobjdyn, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        gvobjdyn = DB_GetTable(strSQL)
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/19 CHG START
        'If Not clsOra.OraEOF(gvobjdyn) Then
        '    gvblnInputFlg = True
        'Else
        '    gvblnInputFlg = False
        'End If
        If gvobjdyn IsNot Nothing AndAlso gvobjdyn.Rows.Count > 0 Then
            gvblnInputFlg = True
        Else
            gvblnInputFlg = False
        End If
        '2019/04/19 CHG E N D

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT " & vbCrLf
        ''前年計画数量
        strSQL = strSQL & "  LMZHKSA, LMZHKSB, LMZHKSC, LMZHKSD, LMZHKSE, LMZHKSF, LMZHKSG, LMZHKSH, LMZHKSI, LMZHKSJ, LMZHKSK, LMZHKSL" & vbCrLf ' 1-12
        ''当年計画数量
        strSQL = strSQL & ", LMAHKSA, LMAHKSB, LMAHKSC, LMAHKSD, LMAHKSE, LMAHKSF, LMAHKSG, LMAHKSH, LMAHKSI, LMAHKSJ, LMAHKSK, LMAHKSL" & vbCrLf '13-24
        ''翌年計画数量
        strSQL = strSQL & ", LMBHKSA, LMBHKSB, LMBHKSC, LMBHKSD, LMBHKSE, LMBHKSF, LMBHKSG, LMBHKSH, LMBHKSI, LMBHKSJ, LMBHKSK, LMBHKSL" & vbCrLf '25-36
        '//前年見直数量
        strSQL = strSQL & ", LMZHMSA, LMZHMSB, LMZHMSC, LMZHMSD, LMZHMSE, LMZHMSF, LMZHMSG, LMZHMSH, LMZHMSI, LMZHMSJ, LMZHMSK, LMZHMSL" & vbCrLf '37-48
        '//当年見直数量
        strSQL = strSQL & ", LMAHMSA, LMAHMSB, LMAHMSC, LMAHMSD, LMAHMSE, LMAHMSF, LMAHMSG, LMAHMSH, LMAHMSI, LMAHMSJ, LMAHMSK, LMAHMSL" & vbCrLf '49-60
        '//翌年見直数量
        strSQL = strSQL & ", LMBHMSA, LMBHMSB, LMBHMSC, LMBHMSD, LMBHMSE, LMBHMSF, LMBHMSG, LMBHMSH, LMBHMSI, LMBHMSJ, LMBHMSK, LMBHMSL" & vbCrLf '61-72

        strSQL = strSQL & ", ZNKURITK ,ZNKSRETK" & vbCrLf
        ''//年初計画CSV取込み時はワークファイルから
        If gvblnInputFlg Then
            strSQL = strSQL & "FROM   HKKWTA HKKTRA　" & vbCrLf
        Else
            strSQL = strSQL & "FROM   HKKTRA " & vbCrLf
        End If
        strSQL = strSQL & "       ,HINMTA "
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  HKKTRA.HINCD  = " & D0.Edt_SQL("S", pmStrHincd) & vbCrLf
        strSQL = strSQL & "AND    HKKTRA.VHINCD = HINMTA.HINCD " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "AND    HKKTRA.VERFL  = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf


        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/19 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, gvobjdyn, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        gvobjdyn = DB_GetTable(strSQL)
        '2019/04/19 CHG E N D

        Get_HKKTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_HKKZTRA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            objRec              OraDynaset       I
    '//*
    '//* <説  明>
    '//*    販売計画前日表示
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKZTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKZTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA"

        '2019/04/15 ADD START
        Try
            '2019/04/15 ADD E N D

            '// 2007/02/02 ↓ UPD STR
            'UPGRADE_ISSUE: ListItem オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
            '2019/04/11 CHG START
            'Dim objLitem As ListItem
            '2019/04/11 CHG E N D
            Dim strSQL As String
            'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
            '2019/04/15 DEL START
            'Dim objRecB As OraDynaset
            '2019/04/15 DEL E N D
            'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
            '2019/04/15 DEL START
            'Dim objRecC As OraDynaset
            '2019/04/15 DEL E N D
            'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
            '2019/04/15 DEL START
            'Dim objRecD As OraDynaset
            '2019/04/15 DEL E N D
            Dim intMonth As Short
            Dim i As Short
            Dim j As Short
            Dim blnMonth As Boolean
            Dim strDate As String
            Dim strLMALDTA As String
            Dim SUMFRDSU As Double
            Dim aryMonthStr() As Object
            Dim intKeikaMonth As Short
            Dim intFindIndex As Short

            Set_HKKZTRA = False

            '2019/04/15 DEL START
            'On Error GoTo ONERR_STEP
            '2019/04/15 DEL E N D

            ' テーブル項目変換テーブル
            'UPGRADE_WARNING: Array に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            aryMonthStr = New Object() {"", "", "", "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}

            '2019/04/15 ADD START
            Dim itemCnt As Integer = 0
            '2019/04/15 ADD E N D

            'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15 CHG START
            'Do Until clsOra.OraEOF(objRec)
            For Each row As DataRow In pDT.Rows
                '2019/04/15 CHG E N D

                strLMALDTA = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
                intMonth = CShort(Mid(gvstrUNYDT, 5, 2))
                blnMonth = True

                intKeikaMonth = 0
                intFindIndex = 0

                If intMonth <= 3 Then
                    intMonth = intMonth + 12
                End If

                If HKKET141F.optCARRIES_ON.Checked Then

                    For i = intMonth To UBound(aryMonthStr)

                        If i <= 15 Then
                            blnMonth = True ' 当月
                        Else
                            blnMonth = False ' 次月
                        End If

                        Select Case True
                            '安全在庫切れ
                            Case HKKET141F.optSAFTY_STOCK.Checked
                                If blnMonth Then 'LMAMAZM
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '在庫切れ
                            Case HKKET141F.optSTOCK.Checked
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAMZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAMZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBMZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBMZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '在庫月数
                            Case HKKET141F.optSTOCK_MONTH.Checked
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMAMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMAMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMAZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMAZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMBMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMBMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMBZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMBZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '発注漏れ
                            Case HKKET141F.optORDER_OMISSION.Checked
                                '//V2.02 ↓ UPD
                                '                        If blnMonth Then
                                '''''                            If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(i))) <> "" Then
                                '''''                                If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                            If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <> "" Then
                                '                                If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                                    intFindIndex = i
                                '                                    Exit For
                                '                                End If
                                '                            End If
                                '                        Else
                                '''''                            If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(i))) <> "" Then
                                '''''                                If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                            If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <> "" Then
                                '                                If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                                    intFindIndex = i
                                '                                    Exit For
                                '                                End If
                                '                            End If
                                '                        End If
                                If blnMonth Then
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/15 CHG START
                                    'If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <> "" Then
                                    If D0.Chk_Null(row("LMALDT" & aryMonthStr(i))) <> "" Then
                                        '2019/04/15 CHG E N D
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") And Val(D0.Chk_Null(objRec("LMAIPK" & aryMonthStr(i)))) <> 0 And Val(D0.Chk_Null(objRec("LMANOS" & aryMonthStr(i)))) = 0 Then
                                        If D0.Chk_Null(row("LMALDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") _
                                         And Val(D0.Chk_Null(row("LMAIPK" & aryMonthStr(i)))) <> 0 _
                                         And Val(D0.Chk_Null(row("LMANOS" & aryMonthStr(i)))) = 0 Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/15 CHG START
                                    'If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <> "" Then
                                    If D0.Chk_Null(row("LMBLDT" & aryMonthStr(i))) <> "" Then
                                        '2019/04/15 CHG E N D
                                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") And Val(D0.Chk_Null(objRec("LMBIPK" & aryMonthStr(i)))) <> 0 And Val(D0.Chk_Null(objRec("LMBNOS" & aryMonthStr(i)))) = 0 Then
                                        If D0.Chk_Null(row("LMBLDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") _
                                         And Val(D0.Chk_Null(row("LMBIPK" & aryMonthStr(i)))) <> 0 _
                                         And Val(D0.Chk_Null(row("LMBNOS" & aryMonthStr(i)))) = 0 Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '//V2.02 ↑ UPD
                        End Select
                    Next i
                End If

                ' 警告表示の場合、該当月と発注予定数を設定 警告以外は、当月の発注予定数を表示
                If HKKET141F.optCARRIES_ON.Checked Then
                    If intFindIndex <> 0 Then
                        If blnMonth Then
                            'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/15 CHG START
                            'strDate = D0.Chk_Null(objRec("LMAYM" & aryMonthStr(intFindIndex)))
                            strDate = D0.Chk_Null(row("LMAYM" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                            'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/15 CHG START
                            'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                            SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                        Else
                            'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/15 CHG START
                            'strDate = D0.Chk_Null(objRec("LMBYM" & aryMonthStr(intFindIndex)))
                            strDate = D0.Chk_Null(row("LMBYM" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                            'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/15 CHG START
                            'SUMFRDSU = D0.Chk_NullN(objRec("LMBIPK" & aryMonthStr(intFindIndex)))
                            SUMFRDSU = D0.Chk_NullN(row("LMBIPK" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                        End If
                    Else
                        intFindIndex = intMonth
                        strDate = ""
                        'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/15 CHG START
                        'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                        SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                        '2019/04/15 CHG E N D
                    End If
                Else
                    intFindIndex = intMonth
                    strDate = ""
                    'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/15 CHG START
                    'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                    SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                    '2019/04/15 CHG E N D
                End If

                ' SQL文の作成
                strSQL = ""
                strSQL = strSQL & "SELECT * " & vbCrLf
                strSQL = strSQL & "FROM   HKKZTRB " & vbCrLf
                'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(objRec("HINCD"))) & vbCrLf
                strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(row("HINCD"))) & vbCrLf
                '2019/04/15 CHG E N D
                'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRecB, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dtHKKZTRB As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

                ' SQL文の作成
                strSQL = ""
                strSQL = strSQL & "SELECT        " & vbCrLf
                strSQL = strSQL & "  MDLCL       " & vbCrLf
                strSQL = strSQL & "FROM   HINMTA " & vbCrLf
                'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(objRec("HINCD"))) & vbCrLf
                strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(row("HINCD"))) & vbCrLf
                '2019/04/15 CHG E N D

                ' データ取得
                'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRecD, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dtHINMTA As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

                '2019/04/11 CHG START
                ''UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem = HKKET141F.lvwMEISAI.ListItems.Add
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(1) = VB6.Format(strDate, "@@@@/@@") '//警告年月
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(2) = D0.Chk_Null(objRec("HINCD")) '//製品ｺｰﾄﾞ
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(3) = D0.Chk_Null(objRec("HINKTA")) '//型式
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(4) = D0.Chk_Null(objRecD("MDLCL")) '//事業区分
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(5) = D0.Chk_Null(objRec("ZAIRNK")) '//在庫ﾗﾝｸ
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(6) = IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", "○", "×") '//生産中止
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(7) = IIf(D0.Chk_Null(objRec("SLENDKB")) = "1", "○", "×") '//販売停止
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(8) = D0.Chk_NullN(objRec("TOUZAISU")) '//現在庫数
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(9) = D0.Chk_NullN(objRec("JYCYUSU")) '//現受注数
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(10) = D0.Chk_NullN(objRec("MKMZAISU")) '//見込現在庫数
                ''//見込案件数 + 当月見積数
                ''// 2007/02/09 ↓ UPD STR
                'If blnMonth Then
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMAMAS" & aryMonthStr(intFindIndex)))
                'Else
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMBMAS" & aryMonthStr(intFindIndex)))
                'End If
                ''        objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMAMAS" & aryMonthStr(intFindIndex)))
                ''// 2007/02/09 ↑ UPD STR

                ''//見込含む時
                'If HKKET141F.optORDER_ON.Checked Then
                '	'//(見込月末在庫数-安全在庫数)/平均出庫数
                '	'// 2007/02/09 ↓ UPD STR
                '	If blnMonth Then
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMAMZKT" & aryMonthStr(intFindIndex)))
                '	Else
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMBMZKT" & aryMonthStr(intFindIndex)))
                '	End If
                '	'            If D0.Chk_NullN(objRecB("LMAAVTS")) = "0" Then
                '	'                objLitem.SubItems(12) = 0                        '//在庫月数
                '	'            Else
                '	'                If blnMonth Then
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMAMYGZ" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                Else
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMBMYGZ" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                End If
                '	'            End If
                '	'// 2007/02/09 ↑ UPD STR
                'Else
                '	'//(月末在庫数-安全在庫数)/平均出庫数
                '	'// 2007/02/09 ↓ UPD STR
                '	If blnMonth Then
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMAZKT" & aryMonthStr(intFindIndex)))
                '	Else
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMBZKT" & aryMonthStr(intFindIndex)))
                '	End If
                '	'            If D0.Chk_NullN(objRecB("LMAAVTS")) = "0" Then
                '	'                objLitem.SubItems(12) = 0
                '	'            Else
                '	'                If blnMonth Then
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMAYGZS" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                Else
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMBYGZS" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                End If
                '	'            End If
                '	'// 2007/02/09 ↑ UPD STR
                'End If
                ''//警告抽出しない時
                'If HKKET141F.optCARRIES_OFF.Checked Then
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(13) = D0.Chk_NullN(objRec("LMAAVTS")) '//平均出庫数
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(14) = D0.Chk_NullN(objRec("TOUZAISU")) '//在庫数
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(15) = D0.Chk_NullN(objRec("TOUZAISU")) - D0.Chk_NullN(objRec("ANZZAISU")) '//安全在庫切れ
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(16) = D0.Chk_NullN(objRec("TOUZAISU")) - D0.Chk_NullN(objRec("LMAAVTS")) '//在庫切れ
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(17) = SUMFRDSU
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(18) = " " '//締切余日数
                'Else
                '	If blnMonth Then
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(13) = D0.Chg_NumericRound(D0.Chk_NullN(objRecB("LMAAVZS" & aryMonthStr(intFindIndex))), 1, 3) '//平均出庫数
                '	Else
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(13) = D0.Chg_NumericRound(D0.Chk_NullN(objRecB("LMBAVZS" & aryMonthStr(intFindIndex))), 1, 3) '//平均出庫数
                '	End If
                '	'//見込含む時
                '	If HKKET141F.optORDER_ON.Checked Then
                '		If blnMonth Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMAMKZS" & aryMonthStr(intFindIndex))) '//在庫数
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMBMKZS" & aryMonthStr(intFindIndex))) '//在庫数
                '		End If
                '	Else
                '		If blnMonth Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMAZAIS" & aryMonthStr(intFindIndex))) '//在庫数
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMBZAIS" & aryMonthStr(intFindIndex))) '//在庫数
                '		End If
                '	End If
                '	'// 2007/02/09 ↓ UPD STR
                '	'            If objLitem.SubItems(14) - D0.Chk_NullN(objRec("ANZZAISU")) < 0 Then
                '	'                objLitem.SubItems(15) = objLitem.SubItems(14) - D0.Chk_NullN(objRec("ANZZAISU"))    '//安全在庫切れ
                '	'            Else
                '	'                objLitem.SubItems(15) = 0    '//安全在庫切れ
                '	'            End If
                '	'            If objLitem.SubItems(14) - D0.Chk_NullN(objRec("LMAAVTS")) < 0 Then
                '	'                objLitem.SubItems(16) = objLitem.SubItems(14) - D0.Chk_NullN(objRec("LMAAVTS"))    '//在庫切れ
                '	'            Else
                '	'                objLitem.SubItems(16) = 0    '//在庫切れ
                '	'            End If
                '	'//安全在庫切れ
                '	If HKKET141F.optORDER_ON.Checked Then
                '		'//(見込含む時)
                '		If blnMonth Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMAAZS" & aryMonthStr(intFindIndex)))
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMBAZS" & aryMonthStr(intFindIndex)))
                '		End If
                '	Else
                '		'//(見込含むまない)
                '		If blnMonth Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMAMAZS" & aryMonthStr(intFindIndex)))
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMBMAZS" & aryMonthStr(intFindIndex)))
                '		End If
                '	End If
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	If objLitem.SubItems(15) > 0 Then
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(15) = 0
                '	End If
                '	'//在庫切れ
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(16) = objLitem.SubItems(15) - D0.Chk_NullN(objRec("LMAAVTS"))
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	If objLitem.SubItems(16) > 0 Then
                '		'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		objLitem.SubItems(16) = 0
                '	End If
                '	'// 2007/02/09 ↑ UPD STR
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(17) = SUMFRDSU
                '	'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	objLitem.SubItems(18) = 0 '//締切余日数
                '	If blnMonth Then
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(intFindIndex))) = "" Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(18) = 0
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: DateDiff 動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"' をクリックしてください。
                '			objLitem.SubItems(18) = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                '		End If
                '	Else
                '		'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '		If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(intFindIndex))) = "" Then
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			objLitem.SubItems(18) = 0
                '		Else
                '			'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト aryMonthStr() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '			'UPGRADE_WARNING: DateDiff 動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"' をクリックしてください。
                '			objLitem.SubItems(18) = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                '		End If
                '	End If
                'End If
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(19) = D0.Chk_NullN(objRec("PRCDD")) + D0.Chk_NullN(objRec("MNFDD")) '//調達LT + 製造LT
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(20) = D0.Chk_Null(objRec("HINGRP")) '//商品分類
                With HKKET141F.lvwMEISAI
                    '0～20(全21列)
                    '//0:選
                    .Items.Add("", itemCnt)
                    '//1:警告年月
                    .Items(itemCnt).SubItems.Add(VB6.Format(strDate, "@@@@/@@"))
                    '//2:製品ｺｰﾄﾞ
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINCD")))
                    '//3:型式
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINKTA")))
                    '//4:事業区分
                    If dtHINMTA IsNot Nothing AndAlso dtHINMTA.Rows.Count > 0 Then
                        .Items(itemCnt).SubItems.Add(D0.Chk_Null(dtHINMTA.Rows(0)("MDLCL")))
                    Else
                        .Items(itemCnt).SubItems.Add("")
                    End If
                    '//5:在庫ﾗﾝｸ
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("ZAIRNK")))
                    '//6:生産中止
                    .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("PRDENDKB")) = "1", "○", "×"))
                    '//7:販売停止
                    .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("SLENDKB")) = "1", "○", "×"))
                    '//8:現在庫数
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")))
                    '//9:現受注数
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("JYCYUSU")))
                    '//10:見込現在庫数
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMZAISU")))
                    '//11:
                    '//見込案件数 + 当月見積数
                    If blnMonth Then
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMMITSU")) + D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMAMAS" & aryMonthStr(intFindIndex))))
                    Else
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMMITSU")) + D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMBMAS" & aryMonthStr(intFindIndex))))
                    End If
                    '//12:
                    '//見込含む時
                    If HKKET141F.optORDER_ON.Checked Then
                        '//(見込月末在庫数-安全在庫数)/平均出庫数
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAMZKT" & aryMonthStr(intFindIndex))))
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBMZKT" & aryMonthStr(intFindIndex))))
                        End If
                    Else
                        '//(月末在庫数-安全在庫数)/平均出庫数
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAZKT" & aryMonthStr(intFindIndex))))
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBZKT" & aryMonthStr(intFindIndex))))
                        End If
                    End If
                    '//警告抽出しない時
                    If HKKET141F.optCARRIES_OFF.Checked Then
                        '//13:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAAVTS"))) '//平均出庫数
                        '//14:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU"))) '//在庫数
                        '//15:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")) - D0.Chk_NullN(row("ANZZAISU"))) '//安全在庫切れ
                        '//16:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")) - D0.Chk_NullN(row("LMAAVTS"))) '//在庫切れ
                        '//17:
                        .Items(itemCnt).SubItems.Add(SUMFRDSU)
                        '//18:
                        .Items(itemCnt).SubItems.Add(" ") '//締切余日数
                    Else
                        '//13:
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chg_NumericRound(D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMAAVZS" & aryMonthStr(intFindIndex))), 1, 3)) '//平均出庫数
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chg_NumericRound(D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMBAVZS" & aryMonthStr(intFindIndex))), 1, 3)) '//平均出庫数
                        End If
                        '//14:
                        '//見込含む時
                        If HKKET141F.optORDER_ON.Checked Then
                            If blnMonth Then
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAMKZS" & aryMonthStr(intFindIndex)))) '//在庫数
                            Else
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBMKZS" & aryMonthStr(intFindIndex)))) '//在庫数
                            End If
                        Else
                            If blnMonth Then
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAZAIS" & aryMonthStr(intFindIndex)))) '//在庫数
                            Else
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBZAIS" & aryMonthStr(intFindIndex)))) '//在庫数
                            End If
                        End If
                        '//15:
                        '//安全在庫切れ
                        Dim items14 As Decimal = 0
                        If HKKET141F.optORDER_ON.Checked Then
                            '//(見込含む時)
                            If blnMonth Then
                                items14 = D0.Chk_NullN(row("LMAAZS" & aryMonthStr(intFindIndex)))
                            Else
                                items14 = D0.Chk_NullN(row("LMBAZS" & aryMonthStr(intFindIndex)))
                            End If
                        Else
                            '//(見込含むまない)
                            If blnMonth Then
                                items14 = D0.Chk_NullN(row("LMAMAZS" & aryMonthStr(intFindIndex)))
                            Else
                                items14 = D0.Chk_NullN(row("LMBMAZS" & aryMonthStr(intFindIndex)))
                            End If
                        End If
                        If items14 > 0 Then
                            items14 = 0
                        End If
                        .Items(itemCnt).SubItems.Add(items14.ToString)
                        '//16:
                        '//在庫切れ
                        Dim items15 As Decimal = 0
                        items15 = items14 - D0.Chk_NullN(row("LMAAVTS"))
                        If items15 > 0 Then
                            items15 = 0
                        End If
                        .Items(itemCnt).SubItems.Add(items15)
                        '//17:
                        .Items(itemCnt).SubItems.Add(SUMFRDSU)
                        '//18:
                        '//締切余日数
                        Dim items17 As Long = 0
                        If blnMonth Then
                            If D0.Chk_Null(row("LMAHDT" & aryMonthStr(intFindIndex))) = "" Then
                                items17 = 0
                            Else
                                items17 = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(row("LMAHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                            End If
                        Else
                            If D0.Chk_Null(row("LMBHDT" & aryMonthStr(intFindIndex))) = "" Then
                                items17 = 0
                            Else
                                items17 = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(row("LMBHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                            End If
                        End If
                        .Items(itemCnt).SubItems.Add(items17) '//締切余日数
                    End If
                    '//19:
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("PRCDD")) + D0.Chk_NullN(row("MNFDD"))) '//調達LT + 製造LT
                    '//20:
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINGRP"))) '//商品分類
                End With
                '2019/04/11 CHG E N D

                '2019/04/15 DEL START
                ''//次ﾚｺｰﾄﾞ検索
                ''UPGRADE_WARNING: オブジェクト clsOra.OraMoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'clsOra.OraMoveNext(objRec)
                '2019/04/15 DEL E N D

                '2019/04/15 ADD START
                itemCnt += 1
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                'Loop
            Next
            '2019/04/15 CHG E N D

            '2019/04/16 ADD START
            HKKET141F.lvwMEISAI.CheckBoxes = True
            '2019/04/16 ADD E N D

            '2019/04/16 ADD START
            HKKET141F.LvSorter141F.Order = LvSortOrder  'ItemAdd後に設定する
            Call SortLv(HKKET141F.lvwMEISAI, InitSortColumn, HKKET141F.LvSorter141F, True)
            '2019/04/16 ADD E N D

            '2019/04/15 ADD START
            Set_HKKZTRA = True
            '2019/04/15 ADD E N D

            '----------------------------------------------------------------------------------------
            '2019/04/15 DEL START
            'EXIT_STEP:
            '            On Error GoTo 0
            '            Exit Function
            '2019/04/15 DEL E N D
            '----------------------------------------------------------------------------------------
            '2019/04/15 DEL START
            'ONERR_STEP:
            '            'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '            ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
            '            Resume EXIT_STEP
            '2019/04/15 DEL E N D


            '2019/04/15 ADD START
        Catch ex As Exception
            ClsMessage.RuntimeErrorMsg(Err.Description & "(" & ex.Message & ")", PROCEDURE)
        End Try
        '2019/04/15 ADD E N D

    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Chk_InputDetail
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:変更有り , False:変更無し
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    画面に表示された内容が正しいか確認する
    '//*****************************************************************************************
    Public Function Chk_InputDetail() As Boolean

        Const PROCEDURE As String = "Chk_InputDetail"

        Dim i As Short
        Dim objCheckObject As Object
        Dim vntArray As Object

        Chk_InputDetail = False

        On Error GoTo ONERR_STEP

        With HKKET141F
            If .optCARRIES_ON.Checked Then
                'If Trim(.txtSAFTY_STOCK.Text) = vbNullString Or
                '                    Trim(.txtSTOCK.Text) = vbNullString Or
                '                    Trim(.txtSTOCK_MONTH.Text) = vbNullString Or
                '                    Trim(.txtORDER_OMISSION.Text) = vbNullString Then
                '    ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "101")
                '    GoTo EXIT_STEP
                'End If
                Select Case True
                    Case .optSAFTY_STOCK.Checked
                        'change start 20190927 kuwa ﾃｷｽﾄﾎﾞｯｸｽが未入力の時にキャストエラーが起きるので、処理を二回に分ける。　ADDするのを忘れない。
                        '上記のコメントアウトされている未入力時の処理をはじくコード（L2983~2989）はフォーカスがメッセージボックス表示後に当たらないため使わない？真偽不明
                        'If Trim(.txtSAFTY_STOCK.Text) = vbNullString Or CDbl(Trim(.txtSAFTY_STOCK.Text)) = 0 Then
                        If Trim(.txtSAFTY_STOCK.Text) = vbNullString Then
                            .txtSAFTY_STOCK.Text = " " '←フォーカスを当てるために半角スペースを追加
                            'change end 20190927 ADDする必要あり。
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSAFTY_STOCK.Focus()
                            GoTo EXIT_STEP

                            'add start 20190927 処理を二回に分けたので、二個目の処理を追加。
                        ElseIf CDbl(Trim(.txtSAFTY_STOCK.Text)) = 0 Then
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSAFTY_STOCK.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optSTOCK.Checked
                        'change start 20190927 kuwa 処理を二回に分ける
                        'If Trim(.txtSTOCK.Text) = vbNullString Or CDbl(Trim(.txtSTOCK.Text)) = 0 Then
                        If Trim(.txtSTOCK.Text) = vbNullString Then
                            .txtSTOCK.Text = " " 'フォーカス用
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa 二回目の処理追加
                        ElseIf CDbl(Trim(.txtSTOCK.Text)) = 0 Then
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optSTOCK_MONTH.Checked
                        'change start 20190927 kuwa　処理を二回に分ける
                        'If Trim(.txtSTOCK_MONTH.Text) = vbNullString Or CDbl(Trim(.txtSTOCK_MONTH.Text)) = 0 Then
                        If Trim(.txtSTOCK_MONTH.Text) = vbNullString Then
                            .txtSTOCK_MONTH.Text = " " 'フォーカス用
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK_MONTH.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa 二回目の処理追加
                        ElseIf CDbl(Trim(.txtSTOCK_MONTH.Text)) = 0 Then
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK_MONTH.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optORDER_OMISSION.Checked
                        'change start 20190927 kuwa 処理を二回に分ける
                        'If Trim(.txtORDER_OMISSION.Text) = vbNullString Or CDbl(Trim(.txtORDER_OMISSION.Text)) = 0 Then
                        If Trim(.txtORDER_OMISSION.Text) = vbNullString Then
                            .txtORDER_OMISSION.Text = " " 'フォーカス用
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "103")
                            .txtORDER_OMISSION.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa 二回目の処理追加
                        ElseIf CDbl(Trim(.txtORDER_OMISSION.Text)) = 0 Then
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "103")
                            .txtORDER_OMISSION.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                End Select
            End If

            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "104") = MsgBoxResult.Yes Then
                'UPGRADE_WARNING: オブジェクト D0.Mouse_ON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call D0.Mouse_ON()
                '//画面表示に必要なデータを取得し表示する
                If Not HKKET141M.Get_DisplayData Then
                    GoTo EXIT_STEP
                End If
            Else
                GoTo EXIT_STEP
            End If

        End With

        Chk_InputDetail = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: オブジェクト D0.Mouse_OFF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_IndividualIniFile
    '//*
    '//* <戻り値>
    '//*              True    :読込みＯＫ
    '//*              False   :読込みＥＲＲ
    '//*
    '//* <引  数>     項目名             I/O      内容
    '//*
    '//* <説  明>
    '//*    アプリケーション固有初期設定ファイル(INIﾌｧｲﾙ)の読込み処理
    '//*****************************************************************************************
    Public Function Get_IndividualIniFile() As Boolean
        '2019/04/12 DEL START
        'Dim gvcst_IniFilePath As Object
        '2019/04/12 DEL E N D

        Const PROCEDURE As String = "Get_IndividualIniFile"

        Dim wk_String As String
        Dim str_Key As String
        Dim str_Path As String

        On Error GoTo ONERR_STEP

        Get_IndividualIniFile = False

        wk_String = ""

        '実PATH取得
        '// 2015/05/29 UPD STT
        '    str_Path = GetFullPath(gvcst_IniFilePath)
        'UPGRADE_WARNING: オブジェクト gvcst_IniFilePath の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'str_Path = gvcst_IniFilePath
        str_Path = Application.StartupPath & "\SSSWIN.INI"
        '2019/04/12 CHG E N D
        '// 2015/05/29 UPD END

        '//-------------------------------------------------------------

        '//ファイルパス 取得
        str_Key = "FILEPATH1"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath1 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME1"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName1 = wk_String

        '//ファイルパス 取得
        str_Key = "FILEPATH2"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath2 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME2"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName2 = wk_String

        '//ファイルパス 取得
        str_Key = "FILEPATH3"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath3 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME3"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName3 = wk_String

        '//ファイルパス 取得
        str_Key = "FILEPATH4"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath4 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME4"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName4 = wk_String

        '//ファイルパス 取得
        str_Key = "FILEPATH5"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath5 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME5"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName5 = wk_String

        '//ファイルパス 取得
        str_Key = "FILEPATH6"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath6 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME6"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName6 = wk_String

        '// V2.30↓ ADD
        '//ファイルパス 取得
        str_Key = "FILEPATH7"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath7 = wk_String

        '//ファイル名   取得
        str_Key = "FILENAME7"
        'UPGRADE_WARNING: オブジェクト D0.GetIniString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName7 = wk_String
        '// V2.30↑ ADD

        '//-------------------------------------------------------------

        Get_IndividualIniFile = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ERROR_STEP:
        MsgBox("【" & Trim(gvcstJOB_Titl) & "】はＩＮＩファイルの取得に失敗しました。処理を中止します。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        GoTo EXIT_STEP
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function


    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Upd_IMPORT
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            str_Dialog          STRING          i       CSVエラー発生時に表示するファイル名
    '//*
    '//* <説  明>
    '//*
    '//*****************************************************************************************
    Public Function Upd_IMPORT(ByVal str_Dialog As String) As Boolean
        'delete start 20190930 kuwa Upd_IMPORT(CSV取込のパラメーター変換開始)なにかあればここから見直す。
        'Dim gvcstInputCls As Object
        'Dim ORATYPE_NUMBER As Object
        'Dim ORAPARM_OUTPUT As Object
        'Dim gvstrCLTID As Object
        'Dim ORATYPE_CHAR As Object
        'Dim ORAPARM_INPUT As Object
        'Dim gvstrOPEID As Object
        'delete end 20190930 kuwa

        Const PROCEDURE As String = "Upd_IMPORT"

        'UPGRADE_ISSUE: ListItem オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        '2019/04/11 DEL E N D
        Dim intRtnCd As Short
        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset


        Upd_IMPORT = False

        On Error GoTo ONERR_STEP
        'add start 20190930 kwua 
        Dim cmd As New OracleCommand
        cmd.Connection = CON
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "HKKPL15.HKKPL15B"
        '//PL/SQLを呼ぶ（前処理）
        '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
        'change start 20190930 kuwa Parameters.Removeの書き換え
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("PARA_PATH")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("PARA_FILE_ID")
        cmd.Parameters.Clear()
        'change end 20190930 kuwa

        '//ログインユーザーＩＤ
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("PARA_OPEID", gvstrOPEID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR
        Dim inP_OPEID As OracleParameter = New OracleParameter("P_OPEID", OracleDbType.Char, ParameterDirection.Input)
        inP_OPEID.Value = gvstrOPEID
        cmd.Parameters.Add(inP_OPEID)
        'change end 20190930 kuwa

        '//端末番号
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("PARA_CLTID", gvstrCLTID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
        Dim inP_CLTID As OracleParameter = New OracleParameter("P_CLTID", OracleDbType.Char, ParameterDirection.Input)
        inP_CLTID.Value = gvstrCLTID
        cmd.Parameters.Add(inP_CLTID)
        'change end 20190930 kuwa

        '//ファイルパス
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("PARA_PATH", gvstrFilePath1, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("PARA_PATH").serverType = ORATYPE_CHAR
        Dim inP_PATH As OracleParameter = New OracleParameter("P_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_PATH.Value = gvstrFilePath1
        cmd.Parameters.Add(inP_PATH)
        'change end 20190930 kuwa

        '//ファイルＩＤ
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("PARA_FILE_ID", gvstrFileName1, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("PARA_FILE_ID").serverType = ORATYPE_CHAR
        Dim inP_FILE_ID As OracleParameter = New OracleParameter("P_FILE_ID", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_FILE_ID.Value = gvstrFileName1
        cmd.Parameters.Add(inP_FILE_ID)
        'change end 20190930 kuwa

        '//戻り値
        intRtnCd = 0
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_NUMBER の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER
        Dim RTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.ReturnValue)
        RTNCD.Value = 0
        cmd.Parameters.Add(RTNCD)
        'change end 20190930 kuwa

        '//PL/SQLを呼ぶ（MAIN）
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: オブジェクト clsOra.OraExecute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraExecute("BEGIN :RTNCD := HKKPL15.HKKPL15B(" & ":PARA_OPEID,:PARA_CLTID,:PARA_PATH,:PARA_FILE_ID); " & "END;", , PROCEDURE)
        cmd.ExecuteNonQuery()

        '//戻り値異常
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190930 kuwa
        'Select Case clsOra.OraDatabase.Parameters("RTNCD").Value
        Select Case RTNCD.Value
            'change end 20190930 kuwa
            Case 0
            Case 1
                '            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "117", "エラー格納ファイル名：" & gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.csv"
                'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "117", "エラー格納ファイル名：" & str_Dialog)
            Case 9
                'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "123")
                GoTo EXIT_STEP
        End Select

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & " SELECT            " & vbCrLf
        strSQL = strSQL & "   HKKTRA.*        " & vbCrLf
        strSQL = strSQL & ",  HINMTA.HINNMA   " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZAIRNK   " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZNKURITK " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZNKSRETK " & vbCrLf
        strSQL = strSQL & ",  HINMTA.MDLCL    " & vbCrLf
        strSQL = strSQL & "FROM   HKKWTA HKKTRA" & vbCrLf
        strSQL = strSQL & "        ,HINMTA    " & vbCrLf
        strSQL = strSQL & " WHERE  HKKTRA.HINCD    = HINMTA.HINCD " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & " AND    HKKTRA.OPEID    = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & " AND    HKKTRA.CLTID    = " & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf

        strSQL = strSQL & " AND    HKKTRA.WRTFSTDT = TO_CHAR(SYSDATE,'YYYYMMDD')   " & vbCrLf

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Clear()
        HKKET141F.lvwMEISAI.Items.Clear()
        '2019/04/11 CHG E N D

        '2019/04/11 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Do Until clsOra.OraEOF(objRec)
        '    'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem = HKKET141F.lvwMEISAI.ListItems.Add
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(1) = "" '//警告年月
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(2) = D0.Chk_Null(objRec("HINCD")) '//製品ｺｰﾄﾞ
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(3) = D0.Chk_Null(objRec("HINNMA")) '//型式
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(4) = D0.Chk_Null(objRec("MDLCL")) '//事業区分
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(5) = D0.Chk_Null(objRec("ZAIRNK")) '//在庫ﾗﾝｸ
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(6) = " " '//生産中止
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(7) = " " '//販売停止
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(8) = " " '//現在庫数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(9) = " " '//現受注数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(10) = " " '//見込現在庫数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(11) = " " '//当月受注数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(12) = " " '//在庫月数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(13) = " " '//平均出庫数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(14) = " " '//在庫数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(15) = " " '//安全在庫切れ
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(16) = " " '//在庫切れ
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(17) = " " '//発注予定数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(18) = " " '//締切余日数
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(19) = " " '//発注LT
        '    'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    objLitem.SubItems(20) = " " '//商品群
        '    '//次ﾚｺｰﾄﾞ検索
        '    'UPGRADE_WARNING: オブジェクト clsOra.OraMoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    clsOra.OraMoveNext(objRec)
        'Loop
        With HKKET141F.lvwMEISAI
            Do Until clsOra.OraEOF(objRec)
                .Items.Add("")
                .Items(0).SubItems.Add("") '//警告年月
                .Items(1).SubItems.Add(D0.Chk_Null(objRec("HINCD"))) '//製品ｺｰﾄﾞ
                .Items(2).SubItems.Add(D0.Chk_Null(objRec("HINNMA"))) '//型式
                .Items(3).SubItems.Add(D0.Chk_Null(objRec("MDLCL"))) '//事業区分
                .Items(4).SubItems.Add(D0.Chk_Null(objRec("ZAIRNK"))) '//在庫ﾗﾝｸ
                .Items(5).SubItems.Add(" ") '//生産中止
                .Items(6).SubItems.Add(" ") '//販売停止
                .Items(7).SubItems.Add(" ") '//現在庫数
                .Items(8).SubItems.Add(" ") '//現受注数
                .Items(9).SubItems.Add(" ") '//見込現在庫数
                .Items(10).SubItems.Add(" ") '//当月受注数
                .Items(11).SubItems.Add(" ") '//在庫月数
                .Items(12).SubItems.Add(" ") '//平均出庫数
                .Items(13).SubItems.Add(" ") '//在庫数
                .Items(14).SubItems.Add(" ") '//安全在庫切れ
                .Items(15).SubItems.Add(" ") '//在庫切れ
                .Items(16).SubItems.Add(" ") '//発注予定数
                .Items(17).SubItems.Add(" ") '//締切余日数
                .Items(18).SubItems.Add(" ") '//発注LT
                .Items(19).SubItems.Add(" ") '//商品群
            Loop

        End With
        '2019/04/11 CHG E N D

        '// 初期入力モード
        'UPGRADE_WARNING: オブジェクト gvcstInputCls.Detail1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvintInputCls = gvcstInputCls.Detail1
        '//項目入力制御設定
        Call HKKET141M.Set_InputControl(gvintInputCls)

        '// 2007/02/24 ↓ DEL
        ''''    HKKET141F.SetFocus
        '// 2007/02/24 ↑ DEL
        'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.FullRowSelect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        HKKET141F.lvwMEISAI.FullRowSelect = True
        'UPGRADE_WARNING: オブジェクト HKKET141F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Item(1).Selected = True
        HKKET141F.lvwMEISAI.Items(0).Selected = True
        '2019/04/11 CHG E N D

        Upd_IMPORT = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraDatabase.Parameters.Remove("RTNCD")
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraDatabase.Parameters.Remove("PARA_PATH")
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraDatabase.Parameters.Remove("PARA_FILE_ID")

        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    DelHKKWTA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    販売計画Ｗを削除する
    '//*****************************************************************************************
    Public Function DelHKKWTA() As Boolean
        '2019/04/16 DEL START
        'Dim gvstrOPEID As Object
        '2019/04/16 DEL E N D

        Const PROCEDURE As String = "DelHKKWTA"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset
        Dim i As Short

        DelHKKWTA = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト D0.Mouse_ON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_ON()

        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        'UPGRADE_WARNING: オブジェクト clsOra.OraBeginTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        ''clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/12 CHG E N D

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "DELETE HKKWTA                       " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  OPEID     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: オブジェクト clsOra.OraExecute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraExecute(strSQL)
        Call DB_Execute(strSQL)
        '2019/04/12 CHG E N D

        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        'UPGRADE_WARNING: オブジェクト clsOra.OraCommitTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/12 CHG E N D

        DelHKKWTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: オブジェクト D0.Mouse_OFF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト clsOra.OraRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraRollback()
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Ctr_END
    '//*
    '//* <戻り値>     型          説明
    '//*
    '//* <引  数>     項目名             型              I/O           内容
    '//*
    '//* <説  明>
    '//*    プログラムの終了処理
    '//*****************************************************************************************
    Public Sub Ctr_END()
        '2019/04/11 DEL START
        'Dim gvstrOPEID As Object
        'Dim ChkHTATRA As Object
        'Dim SSSWIN_LOGWRT As Object
        '2019/04/11 DEL E N D
        '// ★★★★★★★★★★★★★★★★★★★★
        '// 2008/01/24 START
        Call SSSWIN_LOGWRT("プログラム終了")
        '// 2008/01/24 END
        '// ★★★★★★★★★★★★★★★★★★★★

        '//データベース接続解除(ORACLEｻｰﾊﾞｰ)
        Call ChkHTATRA(gvstrOPEID, "9", gvcstJOB_ID)
        '//データベース接続解除(ORACLEｻｰﾊﾞｰ)
        'UPGRADE_WARNING: オブジェクト clsOra.OraDisConnect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'Call clsOra.OraDisConnect()
        Call DB_CLOSE(CON)
        '2019/04/15 CHG E N D
        '//共通オブジェクトの解放
        Call Ctr_Object(False)
        '//プログラム終了
        End

    End Sub

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Run_DialogBox
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    ダイアログボックスを起動しファイル名を取得する
    '//*****************************************************************************************
    Public Function Run_DialogBox(ByRef pobjCommonDiaLog As Object, ByRef pstr_FilePath As String, ByRef pstr_FileName As String, Optional ByVal pintMode As Short = 1) As Boolean
        Dim cdlCancel As Object
        Dim cdlOFNFileMustExist As Object
        Dim cdlOFNOverwritePrompt As Object

        Const PROCEDURE As String = "Run_DialogBox"

        Dim i As Short
        Dim strWorkTemp As String

        Run_DialogBox = False

        On Error GoTo ONERR_STEP

        '//ダイアログボックスの起動
        If pintMode = 1 Then
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.Filter = "ＣＳＶ ファイル (*.csv)|*.csv"
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.DefaultExt = ".csv"
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.Flags の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト cdlOFNOverwritePrompt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190926 kuwa VB6のCommonDialogの.Flagsプロパティは.NETには存在しないため。
            'pobjCommonDiaLog.Flags = cdlOFNOverwritePrompt
            pobjCommonDiaLog.CheckFileExists = True　'.CheckFileExistsの規定値がTrueであるため
            'change end 20190926 kuwa
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.FileName = pstr_FileName
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'delete start 20190926 kuwa CommonDialogの代替となるものが.NETには存在しないため削除
            'pobjCommonDiaLog.CancelError = True
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.ShowSave の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'pobjCommonDiaLog.ShowSave()
            'delete end 20190926 kuwa
        Else
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.Filter = "ＣＳＶ ファイル (*.csv)|*.csv"
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.DefaultExt = ".csv"
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.Flags の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト cdlOFNFileMustExist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190926 kuwa VB6のCommonDialogの.Flagsプロパティは.NETには存在しないため。
            'pobjCommonDiaLog.Flags = cdlOFNFileMustExist
            pobjCommonDiaLog.CheckFileExists = True　'.CheckFileExistsの規定値がTrueであるため
            'change end 20190926 kuwa
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pobjCommonDiaLog.FileName = pstr_FileName
            'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'delete start 20190926 kuwa CommonDialogの代替となるものが.NETには存在しないため削除
            'pobjCommonDiaLog.CancelError = True
            ''UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.ShowOpen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'pobjCommonDiaLog.ShowOpen()
            'delete end 20190926 kuwa
        End If

        '//ダイアログボックスの入力内容確認
        'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If pobjCommonDiaLog.FileName = "" Then
            GoTo EXIT_STEP
        End If

        '//値を返す
        'UPGRADE_WARNING: オブジェクト pobjCommonDiaLog.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strWorkTemp = pobjCommonDiaLog.FileName
        For i = Len(strWorkTemp) To 1 Step -1
            If Mid(strWorkTemp, i, 1) = "\" Then
                pstr_FilePath = Mid(strWorkTemp, 1, i)
                pstr_FileName = Mid(strWorkTemp, i + 1)
                Exit For
            End If
        Next i

        Run_DialogBox = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト cdlCancel の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Err.Number = cdlCancel Then
            Resume EXIT_STEP
        End If
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '// 2007/02/24 ↓ ADD STR
    '//****************************************************************************************
    '//*
    '//* <名  称>
    '//*    SetFormInitOrg
    '//*
    '//* <戻り値>
    '//*
    '//* <引  数>     項目名              I/O      内容
    '//*              pm_Form             I       フォーム
    '//*              pm_Kbn              I       フォーム表示方法区分
    '//*                                          0:フォームをデフォルトサイズに設定
    '//*                                                              1:フォームサイズを設定しない
    '//* <説  明>
    '//*    画面の初期設定
    '//*****************************************************************************************
    Public Sub SetFormInitOrg(ByVal pm_Form As System.Windows.Forms.Form, Optional ByVal pm_Kbn As Short = 0)

        Const PROCEDURE As String = "SetFormInitOrg"

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

            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If IsNothing(gvvntTop) Then
                '//画面中央に表示（センタリング）
                .Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
                .Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
            Else
                '//画面保存位置の値で表示
                'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Top = VB6.TwipsToPixelsY(gvvntTop)
                'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .Left = VB6.TwipsToPixelsX(gvvntLeft)
            End If

            'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            gvvntLeft = VB6.PixelsToTwipsX(.Left)
            'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            gvvntTop = VB6.PixelsToTwipsY(.Top)

        End With

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト clsOra.OraRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        clsOra.OraRollback()
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Ctr_Setfocus
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:変更有り , False:変更無し
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    指定されたオブジェクトにセットフォーカスする
    '//*****************************************************************************************
    Public Sub Ctr_Setfocus(ByVal pmoSetFocusObject As Object)

        Const PROCEDURE As String = "Ctr_Setfocus"

        On Error Resume Next

        'UPGRADE_WARNING: オブジェクト pmoSetFocusObject.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pmoSetFocusObject.SetFocus()

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '// 2007/02/24 ↑ ADD STR

    '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_HidukeKanri
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    日付管理TBLの運用日付を取得する
    '//*****************************************************************************************
    Public Function Get_HidukeKanri(ByRef pstrUNYDT As String) As Boolean

        Const PROCEDURE As String = "Get_HidukeKanri"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim objRec As OraDynaset

        Get_HidukeKanri = False

        On Error GoTo ONERR_STEP

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT UNYDT " & vbCrLf
        strSQL = strSQL & "FROM   UNYMTA " & vbCrLf

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/12 CHG START
            'pstrUNYDT = D0.Chk_Null(objRec("UNYDT"))
            pstrUNYDT = D0.Chk_Null(dt.Rows(0)("UNYDT"))
            '2019/04/12 CHG E N D
        Else
            pstrUNYDT = ""
        End If

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/12 DEL E N D

        Get_HidukeKanri = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '''' ADD 2009/11/26  FKS) T.Yamamoto    End
End Module