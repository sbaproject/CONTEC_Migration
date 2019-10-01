Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

'2019/04/02 ADD START
Imports Oracle.DataAccess.Client
'2019/04/02 ADD E N D

Module HKKET142M
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 2.00     |20080627|Rise)          |変更①入力指示が入力されたら、入庫計画(連携)項目をロックする。
	'//* 2.10     |20080627|Rise)          |変更①年初計画の取込処理時に本テーブル(HKKTRA)を更新する。
	'//*          |        |               |      また、取込処理時、更新ボタン押下時は無条件に更新する。
	'//* 2.20     |20080701|Rise)          |変更①新生産対応（優先フラグ項目の追加）
	'//* 2.30     |20081222|Rise)          |販売計画画面での入力ログを出力する
	'//*****************************************************************************************

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

	'//*****************************************************************************************
	'// ＰＧ個別変数定義
	'//*****************************************************************************************
	Public gvlngNowPage As Integer '//現在表示頁数
	Public gvlngDefaultPage As Integer '//初期表示頁数
	Public gvlngMAXPage As Integer '//最大表示頁数
	Public gvlngMINPage As Integer '//最小表示頁数
	Public gvstrNowItem As String '//現在表示製品
	Public gvblnLMAHMS As Boolean '//変更ﾌﾗｸﾞ
	Public gvblnLMZNOS As Boolean '//変更ﾌﾗｸﾞ
	Public gvintNowItem As Short '//現在表示製品
	Public gvstrCalcDate As String '//通算日
	Public gvstrCalcDate2 As String '//計算日付
	Public gvstrCalcDate3 As String '//計算日付
	'// 2006/10/27 ↓ ADD STR
	Public gvstrHINKB As String '//現在表示の製品区分
	'// 2006/10/27 ↑ ADD END
	'// 2007/01/09 ↓ ADD STR
	Public gvlngSyukaYoteiHikaku As Integer '//出荷予定比較日数
	Public gvstrHINGRP As String '//現在表示中の商品郡
	'// 2007/01/09 ↑ ADD END
	
	Public Structure mtypHKKTRA '//退避情報
        '2019/04/10 CHG START
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMAHKS() As String*10 '//年初計画
        'Dim blnLMAHKS() As Boolean '//年初計画(入力制御)
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMAHKS_ORG() As String*10 '//年初計画(初回値)
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMAHMS() As String*10 '//見直計画
        'Dim blnLMAHMS() As Boolean '//見直計画(入力制御)
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMAHMS_ORG() As String*10 '//見直計画(初回値)
        ''// 2006/11/13 ↓ ADD STR
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMZPNO() As String*12 '//生産計画番号
        ''// 2006/11/13 ↑ ADD END
        ''// 2007/01/09 ↓ ADD STR
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMAPDT() As String*8 '//計画年月日
        'Dim intLTKBN() As Short '//LT期間区分(2:調達LT/1:製造LT/0:通常)
        '      '// 2007/01/09 ↑ ADD END
        Dim strLMAHKS() As String       '//年初計画
        Dim blnLMAHKS() As Boolean      '//年初計画(入力制御)
        Dim strLMAHKS_ORG() As String   '//年初計画(初回値)
        Dim strLMAHMS() As String       '//見直計画
        Dim blnLMAHMS() As Boolean      '//見直計画(入力制御)
        Dim strLMAHMS_ORG() As String   '//見直計画(初回値)
        Dim strLMZPNO() As String       '//生産計画番号
        Dim strLMAPDT() As String       '//計画年月日
        Dim intLTKBN() As Short         '//LT期間区分(2:調達LT/1:製造LT/0:通常)
         '2019/04/10 CHG E N D
	End Structure
	
	Public Structure mtypHKKZTRA '//退避情報
		Dim strDSPMONTH() As String '//表示年月
		Dim dblLAST_JDNTR() As Double '//前年受注実績
		Dim dblLAST_ODNTRA() As Double '//前年出庫実績
		Dim dblLAST_HDNTRA() As Double '//前年発注実績
		Dim dblINPTRA() As Double '//入庫予定
		Dim dblOUTTRA() As Double '//出庫予定
		Dim dblSKYOUT() As Double '//支給品出庫
		Dim dblLAST_STOCK() As Double '//月末在庫
		Dim strLMZLDT() As String '//発注限界日
		Dim strLMZHDT() As String '//発注日
		Dim strLMZZKM() As String '//在庫切れマーク
		Dim strLMZAZM() As String '//安全在庫切れマーク
		Dim strLMZMZKM() As String '//見込在庫切れマーク
		Dim strLMZMAZM() As String '//見込安全在庫切れマーク
		Dim dblLMZZKT() As Double '//在庫月数
		Dim dblLMZMZKT() As Double '//見込在庫月数
		Dim dblLMAVZS() As Double '//平均出庫数
		'// 2007/01/09 ↓ ADD STR
		Dim dblLAST_NDNTRA() As Double '//前年出庫実績
		Dim dblYOSLST() As Double '//予測月末在庫
		Dim dblMYOSLST() As Double '//見込予測月末在庫
		'// 2007/01/09 ↑ ADD END
	End Structure
	
	Public Structure mtypMKMTRA '//退避情報
		Dim dblMKMAK() As Double '//見込案件
		Dim dblMKMMT() As Double '//見込見積
		Dim dblMKMOUTTRA() As Double '//見込出庫予定
		Dim dblMKMLST() As Double '//見込月末在庫
	End Structure
	
    Public Structure mtypODINTRA '//退避情報
        '2019/04/10 CHG START
        'Dim dblLMAODSSA() As Double '//発注済数
        'Dim dblLMAKODSA() As Double '//緊急発注済
        'Dim dblLMZNOSSA() As Double '//入庫指示済数
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strINPPLAN() As String*10 '//（入力）入庫計画数
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strINPPLAN_ORG() As String*10 '//（入力）入庫計画数(初期値)
        'Dim dblDspINPPLAN() As Double '//（表示）入庫計画数
        'Dim dblDspINPPLAN_ORG() As Double '//（表示）入庫計画数(初期値)
        'Dim dblDspINPPLAN_ZEN() As Double '//（表示）入庫計画数(当日初期値)
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMZNOSS() As String*10 '//入庫指示数
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMZNOSS_ORG() As String*10 '//入庫指示数(初回値)
        ''// V2.20↓ ADD
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMZNPF() As String*4 '//優先フラグ
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim strLMZNPF_ORG() As String*4 '//優先フラグ(読み込み時)
        ''// V2.20↑ ADD

        Dim dblLMAODSSA() As Double         '//発注済数
        Dim dblLMAKODSA() As Double         '//緊急発注済
        Dim dblLMZNOSSA() As Double         '//入庫指示済数
        Dim strINPPLAN() As String          '//（入力）入庫計画数
        Dim strINPPLAN_ORG() As String      '//（入力）入庫計画数(初期値)
        Dim dblDspINPPLAN() As Double       '//（表示）入庫計画数
        Dim dblDspINPPLAN_ORG() As Double   '//（表示）入庫計画数(初期値)
        Dim dblDspINPPLAN_ZEN() As Double   '//（表示）入庫計画数(当日初期値)
        Dim strLMZNOSS() As String          '//入庫指示数
        Dim strLMZNOSS_ORG() As String      '//入庫指示数(初回値)
        Dim strLMZNPF() As String           '//優先フラグ
        Dim strLMZNPF_ORG() As String       '//優先フラグ(読み込み時)
        '2019/04/10 CHG E N D
    End Structure
	
	'UPGRADE_WARNING: 構造体 musrHKKTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public musrHKKTRA As mtypHKKTRA
	'UPGRADE_WARNING: 構造体 musrHKKZTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public musrHKKZTRA As mtypHKKZTRA
	'UPGRADE_WARNING: 構造体 musrMKMTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public musrMKMTRA As mtypMKMTRA
	'UPGRADE_WARNING: 構造体 musrODINTRA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public musrODINTRA As mtypODINTRA
	
	'// 2007/02/24 ↓ ADD STR
	Public Const gvcst_COLOR_MIDORIIRO As Integer = &H80FF80 '//緑色
	'// 2007/02/24 ↑ ADD END
	Public Const gvcst_COLOR_SIRO As Integer = &HFFFFFF '//白色
	Public Const gvcst_COLOR_HAIIRO As Integer = &H8000000F '//灰色
	Public Const gvcst_COLOR_MIZURO As Integer = &HE2D4A4 '//水色
	Public Const gvcst_COLOR_MOMOIRO As Integer = &H8988EA '//桃色
	Public Const gvcst_COLOR_AKAIRO As Integer = &HFF '//赤色
	Public Const gvcst_COLOR_KAKIIRO As Integer = &H3657E6 '//柿色
	Public Const gvcst_COLOR_DAIDAIIRO As Short = &H6DE0s '//橙色
	
	'// 2007/02/24 ↓ ADD STR
	Public strHKKTRA_DAY As String '//日付時刻
	Public strODINTRA_DAY As String '//日付時刻
	'// 2007/02/24 ↑ ADD END
	
	'// V2.10↓ ADD
	Public intNensyoImportMode As Short '//年初計画取込処理フラグ(1:取込モード 0:通常入力)
	'// V2.10↑ ADD
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Ctr_PagePrevNext
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    コマンドボタンの前頁・次頁の表示する
	'//*****************************************************************************************
	Public Function Ctr_PagePrevNext(ByVal pmsMode As String) As Boolean
		
		Const PROCEDURE As String = "Ctr_PagePrevNext"
		
		Dim lngNowPage As Integer
		
		Ctr_PagePrevNext = False
		
		On Error GoTo ONERR_STEP
		
		
		'//頁カウントの加算・減産
		Select Case pmsMode
			Case "P"
				If gvlngNowPage <= 0 Then
					'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "215")
					GoTo EXIT_STEP
				End If
				gvlngNowPage = gvlngNowPage - 1
			Case "N"
				If gvlngNowPage + 1 > 23 Then
					'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "214")
					GoTo EXIT_STEP
				End If
				gvlngNowPage = gvlngNowPage + 1
		End Select
		
		HKKET142F.txtTERM_PRE.Visible = False
		HKKET142F.txtTERM.Visible = False
		HKKET142F.txtTERM_NEXT.Visible = False
		If gvlngNowPage >= -1 And gvlngNowPage <= 11 Then
			HKKET142F.txtTERM_PRE.Left = VB6.TwipsToPixelsX(1680)
			HKKET142F.txtTERM_PRE.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) - 1)) - 105)
			
			HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX((840 * (14 - gvlngNowPage)))
			HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((12 + gvlngNowPage) - 11)) - 105)
			
			HKKET142F.txtTERM_PRE.Visible = True
			HKKET142F.txtTERM.Visible = True
			HKKET142F.txtTERM_NEXT.Visible = False
		End If
		
		If gvlngNowPage >= 12 And gvlngNowPage <= 23 Then
			HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX(1680)
			HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) + 11)) - 105)
			
			HKKET142F.txtTERM_NEXT.Left = VB6.TwipsToPixelsX((840 * ((13 - gvlngNowPage) + 13)))
			HKKET142F.txtTERM_NEXT.Width = VB6.TwipsToPixelsX((840 * (gvlngNowPage - 11)) - 105)
			
			HKKET142F.txtTERM.Visible = True
			HKKET142F.txtTERM_NEXT.Visible = True
			HKKET142F.txtTERM_PRE.Visible = False
		End If
		
		'//画面表示に必要なデータを取得し表示する
		If Not Set_DisplayData(gvlngNowPage) Then
			GoTo EXIT_STEP
		End If
		
		Ctr_PagePrevNext = True
		
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
		
		Const PROCEDURE As String = "Set_Initialize"
		Dim i As Short
		
		Set_Initialize = False
		
		On Error GoTo ONERR_STEP
		
		'// ＦＯＲＭキャプションセット
		'HKKET142F.Caption = gvcstJOB_Titl
		
		'//ＦＯＲＭ初期セット
		Call SetFormInitOrg(HKKET142F, 1)
		
		'// 画面クリアー
		Call Clr_Display()
		
		gvstrNowItem = musrHKKZTR.strHINCD(gvintNowItem)
		HKKET142F.txtNOWPAGE.Text = CStr(gvintNowItem)
		HKKET142F.txtMAXPAGE.Text = CStr(UBound(musrHKKZTR.strHINCD))
		HKKET142F.txtHINCD.Text = gvstrNowItem
		
		HKKET142F.txtHINCD.Text = gvstrNowItem
		
		HKKET142F.txtHINCD2.Text = HKKET141F.txtHINCD.Text
		HKKET142F.txtHINGRP2(0).Text = HKKET141F.txtHINGRP(0).Text
		HKKET142F.txtHINGRP2(1).Text = HKKET141F.txtHINGRP(1).Text
		HKKET142F.txtHINGRP2(2).Text = HKKET141F.txtHINGRP(2).Text
		HKKET142F.txtHINGRP2(3).Text = HKKET141F.txtHINGRP(3).Text
		HKKET142F.txtHINGRP2(4).Text = HKKET141F.txtHINGRP(4).Text
		HKKET142F.txtHINGRP2(5).Text = HKKET141F.txtHINGRP(5).Text
		
		HKKET142F.txtHINNMA2.Text = HKKET141F.txtHINNMA.Text
		
		HKKET142F.txtZAIRNK2(0).Text = HKKET141F.txtZAIRNK(0).Text
		HKKET142F.txtZAIRNK2(1).Text = HKKET141F.txtZAIRNK(1).Text
		HKKET142F.txtZAIRNK2(2).Text = HKKET141F.txtZAIRNK(2).Text
		HKKET142F.txtZAIRNK2(3).Text = HKKET141F.txtZAIRNK(3).Text
		HKKET142F.txtZAIRNK2(4).Text = HKKET141F.txtZAIRNK(4).Text
		HKKET142F.txtZAIRNK2(5).Text = HKKET141F.txtZAIRNK(5).Text
		HKKET142F.txtZAIRNK2(6).Text = HKKET141F.txtZAIRNK(6).Text
		HKKET142F.txtZAIRNK2(7).Text = HKKET141F.txtZAIRNK(7).Text
		
		HKKET142F.txtTODAY.Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
		HKKET142F.txtTERM.Text = gvstrTERMNO & "期"
		HKKET142F.txtTERM_PRE.Text = CDbl(gvstrTERMNO) - 1 & "期"
		HKKET142F.txtTERM_NEXT.Text = CDbl(gvstrTERMNO) + 1 & "期"
		
		
		
		HKKET142F.txtTERM.Left = VB6.TwipsToPixelsX(1680)
		HKKET142F.txtTERM.Width = VB6.TwipsToPixelsX((840 * ((13 - gvlngDefaultPage + 1) + 10)) - 105)
		
		HKKET142F.txtTERM_NEXT.Left = VB6.TwipsToPixelsX((840 * ((13 - gvlngDefaultPage + 1) + 12)))
		HKKET142F.txtTERM_NEXT.Width = VB6.TwipsToPixelsX((840 * (gvlngDefaultPage - 11)) - 105)
		
		HKKET142F.txtTERM.Visible = True
		HKKET142F.txtTERM_PRE.Visible = False
		HKKET142F.txtTERM_NEXT.Visible = True
		
		HKKET142F.txtWARNING.Text = IIf(HKKET141F.optCARRIES_ON.Checked, "する", "しない")
		If HKKET141F.optCARRIES_ON.Checked Then
			Select Case True
				Case HKKET141F.optSAFTY_STOCK.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSAFTY_STOCK.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSAFTY_STOCK.Text
				Case HKKET141F.optSTOCK.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSTOCK.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSTOCK.Text
				Case HKKET141F.optSTOCK_MONTH.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optSTOCK_MONTH.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtSTOCK_MONTH.Text
				Case HKKET141F.optORDER_OMISSION.Checked
					HKKET142F.txtSTOCKNM.Text = HKKET141F.optORDER_OMISSION.Text
					HKKET142F.txtSTOCK.Text = HKKET141F.txtORDER_OMISSION.Text
			End Select
		End If
		HKKET142F.txtJDMKM.Text = IIf(HKKET141F.optORDER_ON.Checked, "含む", "含まない")
		HKKET142F.txtGROUP.Text = IIf(HKKET141F.optONLY.Checked, "個別", "ﾊﾞｰｼﾞｮﾝ集計")
		
		ReDim musrHKKTRA.strLMAHKS(0)
		ReDim musrHKKTRA.blnLMAHKS(0)
		ReDim musrHKKTRA.strLMAHKS_ORG(0)
		ReDim musrHKKTRA.strLMAHMS(0)
		ReDim musrHKKTRA.blnLMAHMS(0)
		ReDim musrHKKTRA.strLMAHMS_ORG(0)
		
		ReDim musrHKKZTRA.strDSPMONTH(0)
		ReDim musrHKKZTRA.dblLAST_JDNTR(0)
		ReDim musrHKKZTRA.dblLAST_ODNTRA(0)
		ReDim musrHKKZTRA.dblLAST_HDNTRA(0)
		'// 2007/01/09 ↓ ADD STR
		ReDim musrHKKZTRA.dblLAST_NDNTRA(0)
		'// 2007/01/09 ↑ ADD END
		ReDim musrHKKZTRA.dblINPTRA(0)
		ReDim musrHKKZTRA.dblOUTTRA(0)
		ReDim musrHKKZTRA.dblSKYOUT(0)
		ReDim musrHKKZTRA.dblLAST_STOCK(0)
		ReDim musrHKKZTRA.strLMZLDT(0)
		ReDim musrHKKZTRA.strLMZHDT(0)
		ReDim musrHKKZTRA.strLMZZKM(0)
		ReDim musrHKKZTRA.strLMZAZM(0)
		ReDim musrHKKZTRA.strLMZMZKM(0)
		ReDim musrHKKZTRA.strLMZMAZM(0)
		ReDim musrHKKZTRA.dblLMZZKT(0)
		ReDim musrHKKZTRA.dblLMZMZKT(0)
		ReDim musrHKKZTRA.dblLMAVZS(0)
		'// 2007/01/09 ↓ ADD STR
		ReDim musrHKKZTRA.dblYOSLST(0)
		ReDim musrHKKZTRA.dblMYOSLST(0)
		'// 2007/01/09 ↑ ADD END
		
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMMT(0)
		ReDim musrMKMTRA.dblMKMOUTTRA(0)
		ReDim musrMKMTRA.dblMKMLST(0)
		
		ReDim musrODINTRA.dblLMAODSSA(0)
		ReDim musrODINTRA.dblLMAKODSA(0)
		ReDim musrODINTRA.dblLMZNOSSA(0)
		ReDim musrODINTRA.strINPPLAN(0)
		ReDim musrODINTRA.strINPPLAN_ORG(0)
		ReDim musrODINTRA.dblDspINPPLAN(0)
		ReDim musrODINTRA.dblDspINPPLAN_ORG(0)
		ReDim musrODINTRA.dblDspINPPLAN_ZEN(0)
		ReDim musrODINTRA.strLMZNOSS(0)
		ReDim musrODINTRA.strLMZNOSS_ORG(0)
		'// V2.20↓ ADD
		ReDim musrODINTRA.strLMZNPF(0)
		ReDim musrODINTRA.strLMZNPF_ORG(0)
		'// V2.20↑ ADD
		
		'//画面表示に必要なデータを取得し表示する
		If Not Get_DisplayData Then
			GoTo EXIT_STEP
		End If
		
		If Not Set_DisplayData(gvlngDefaultPage) Then
			GoTo EXIT_STEP
		End If
		
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
	Sub Clr_Display()
		
		Const PROCEDURE As String = "Clr_Display"
		
		Dim i As Short
		
		On Error GoTo ONERR_STEP
		
		'UPGRADE_WARNING: Controls メソッド Controls.Count には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		For i = 0 To HKKET142F.Controls.Count() - 1
			'UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case TypeName(CType(HKKET142F.Controls(i), Object))
				'//オブジェクトが対象
				Case "TextBox" '//ﾃｷｽﾄﾎﾞｯｸｽ
					CType(HKKET142F.Controls(i), Object).Text = vbNullString
				Case Else
			End Select
		Next i
		
		For i = 0 To HKKET142F.cmdMONTH.UBound
			HKKET142F.cmdMONTH(i).Text = vbNullString
		Next i
		
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
		
		If Not HKKET142M.Get_HKKTRA Then '//販売計画Ｆ取得
			GoTo EXIT_STEP
		End If
		
		If Not HKKET142M.Get_HINMTA Then '//商品マスタ取得
			GoTo EXIT_STEP
		End If
		
		'// 2007/01/09 ↓ ADD STR
		If Not HKKET142M.Get_FIXMTA Then '//固定値マスタ取得
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 ↑ ADD END
		
		If Not HKKET142M.Get_HKKZTRA Then '//販売計画前日Ｆ取得
			GoTo EXIT_STEP
		End If
		
		
		If Not HKKET142M.Get_HKKZTRA_M Then '//販売計画前日Ｆ取得
			GoTo EXIT_STEP
		End If
		
		'// 2007/01/09 ↓ ADD STR
		If Not HKKET142M.Get_LTKIKAN Then '//LT期間区分の取得
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 ↑ ADD END
		
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
	'//*    Set_DisplayData
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            pm_gvlngNowPage     Long             I      現在の頁
	'//*
	'//* <説  明>
	'//*
	'//*****************************************************************************************
	Public Function Set_DisplayData(ByRef pm_gvlngNowPage As Integer) As Boolean
		
		
		Const PROCEDURE As String = "Set_DisplayData"
		
		Dim i As Short
		Dim j As Short
		Dim strDate As String
		
		Set_DisplayData = False
		
		On Error GoTo ONERR_STEP
		
		i = pm_gvlngNowPage
		j = 0
		''//前年受注実績
		HKKET142F.txtLAST_JDNTR.Text = vbNullString
		''//前年出庫実績
		HKKET142F.txtLAST_ODNTRA.Text = vbNullString
		''//前年発注実績
		HKKET142F.txtLAST_HDNTRA.Text = vbNullString
		''//入庫予定
		HKKET142F.txtINPTRA.Text = vbNullString
		''//出庫予定
		HKKET142F.txtOUTTRA.Text = vbNullString
		''//支給品出庫
		HKKET142F.txtSKYOUT.Text = vbNullString
		''//見込案件
		HKKET142F.txtMKMAK.Text = vbNullString
		''//見込見積
		HKKET142F.txtMKMMT.Text = vbNullString
		''//見込出庫予定
		HKKET142F.txtMKMOUTTRA.Text = vbNullString
		'// 2007/01/09 ↓ ADD STR
		''//予測月末在庫
		HKKET142F.txtYOSLST.Text = vbNullString
		'// 2007/01/09 ↑ ADD END
		''//発注済計
		HKKET142F.txtLMAODSSA.Text = vbNullString
		''//緊急発注済計
		HKKET142F.txtLMAKODSA.Text = vbNullString
		''//入庫指示済数
		HKKET142F.txtLMZNOSSA.Text = vbNullString
		''//入庫計画数
		HKKET142F.txtDspINPPLAN.Text = vbNullString
		
		Do 
			'//表示月
			If musrHKKZTRA.strDSPMONTH(i) <> "" Then
				If CInt(Right(musrHKKZTRA.strDSPMONTH(i), 2)) > 9 Then
					HKKET142F.cmdMONTH(j).Text = Right(musrHKKZTRA.strDSPMONTH(i), 2) & "月"
				Else
					HKKET142F.cmdMONTH(j).Text = StrConv(Right(musrHKKZTRA.strDSPMONTH(i), 1), VbStrConv.Wide) & "月"
				End If
			Else
				HKKET142F.cmdMONTH(j).Text = ""
			End If
			HKKET142F.cmdMONTH(j).Tag = musrHKKZTRA.strDSPMONTH(i)
			
			'// 2007/02/24 ↓ ADD STR
			''//表示月のボタン表面の色を見込出庫予定が入っていたときは緑にする
			If musrMKMTRA.dblMKMOUTTRA(i) <> 0 Then
				HKKET142F.cmdMONTH(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIDORIIRO) ' 緑色
			Else
				HKKET142F.cmdMONTH(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO) ' 灰色
			End If
			'// 2007/02/24 ↑ ADD END
			
			'//年初計画
			If Trim(musrHKKTRA.strLMAHKS(i)) = "" Then
				HKKET142F.txtLMAHKS(j).Text = ""
			Else
				HKKET142F.txtLMAHKS(j).Text = VB6.Format(Trim(musrHKKTRA.strLMAHKS(i)), "####0")
			End If
			'//見直計画
			If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
				HKKET142F.txtLMAHMS(j).Text = ""
			Else
				HKKET142F.txtLMAHMS(j).Text = VB6.Format(Trim(musrHKKTRA.strLMAHMS(i)), "####0")
			End If
			
			'// 2007/02/03 ↓ ADD STR
			''//入庫計画数
			'        If Trim(musrODINTRA.strINPPLAN(i)) = "" Then
			'            HKKET142F.txtINPPLAN(j).Text = ""
			'        Else
			HKKET142F.txtINPPLAN(j).Text = VB6.Format(Val(Trim(musrODINTRA.strINPPLAN(i))), "####0")
			'        End If
			'// 2007/02/03 ↑ ADD END
			'// V2.20↓ ADD
			If HKKET141F.optVERSION.Checked = True Then
				HKKET142F.txtLMZNPF(j).Text = "-"
			Else
				HKKET142F.txtLMZNPF(j).Text = musrODINTRA.strLMZNPF(i)
			End If
			'// V2.20↑ ADD
			
			If HKKET142F.cmdMONTH(j).Text <> "" Then
				''//前年受注実績
				HKKET142F.txtLAST_JDNTR.Text = HKKET142F.txtLAST_JDNTR.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_JDNTR(i), "####0"), 6) & "  "
				''//前年出庫実績
				HKKET142F.txtLAST_ODNTRA.Text = HKKET142F.txtLAST_ODNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_ODNTRA(i), "####0"), 6) & "  "
				''//前年発注実績
				HKKET142F.txtLAST_HDNTRA.Text = HKKET142F.txtLAST_HDNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_HDNTRA(i), "####0"), 6) & "  "
				''//入庫予定
				HKKET142F.txtINPTRA.Text = HKKET142F.txtINPTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblINPTRA(i), "####0"), 6) & "  "
				''//出庫予定
				HKKET142F.txtOUTTRA.Text = HKKET142F.txtOUTTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblOUTTRA(i), "####0"), 6) & "  "
				''//支給品出庫
				HKKET142F.txtSKYOUT.Text = HKKET142F.txtSKYOUT.Text & Right("      " & VB6.Format(musrHKKZTRA.dblSKYOUT(i), "####0"), 6) & "  "
				''//月末在庫
				HKKET142F.txtLAST_STOCK(j).Text = CStr(musrHKKZTRA.dblLAST_STOCK(i))
				''//見込案件
				HKKET142F.txtMKMAK.Text = HKKET142F.txtMKMAK.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMAK(i), "####0"), 6) & "  "
				''//見込見積
				HKKET142F.txtMKMMT.Text = HKKET142F.txtMKMMT.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMMT(i), "####0"), 6) & "  "
				''//見込出庫予定
				HKKET142F.txtMKMOUTTRA.Text = HKKET142F.txtMKMOUTTRA.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMOUTTRA(i), "####0"), 6) & "  "
				''//見込月末在庫
				HKKET142F.txtMKMLST(j).Text = CStr(musrMKMTRA.dblMKMLST(i))
				'// 2007/01/09 ↓ ADD STR
				''//予測月末在庫
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "####0"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "####0"), 6) & "  "
				End If
				'// 2007/01/09 ↑ ADD END
				''//発注済計
				HKKET142F.txtLMAODSSA.Text = HKKET142F.txtLMAODSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAODSSA(i), "####0"), 6) & "  "
				''//緊急発注済計
				HKKET142F.txtLMAKODSA.Text = HKKET142F.txtLMAKODSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAKODSA(i), "####0"), 6) & "  "
				''//入庫指示済数
				HKKET142F.txtLMZNOSSA.Text = HKKET142F.txtLMZNOSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMZNOSSA(i), "####0"), 6) & "  "
				''//入庫計画数
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
				''//入庫指示数
				HKKET142F.txtLMZNOSS(j).Text = Trim(musrODINTRA.strLMZNOSS(i))
			Else
				''//前年受注実績
				HKKET142F.txtLAST_JDNTR.Text = HKKET142F.txtLAST_JDNTR.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_JDNTR(i), "#####"), 6) & "  "
				''//前年出庫実績
				HKKET142F.txtLAST_ODNTRA.Text = HKKET142F.txtLAST_ODNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_ODNTRA(i), "#####"), 6) & "  "
				''//前年発注実績
				HKKET142F.txtLAST_HDNTRA.Text = HKKET142F.txtLAST_HDNTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblLAST_HDNTRA(i), "#####"), 6) & "  "
				''//入庫予定
				HKKET142F.txtINPTRA.Text = HKKET142F.txtINPTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblINPTRA(i), "#####"), 6) & "  "
				''//出庫予定
				HKKET142F.txtOUTTRA.Text = HKKET142F.txtOUTTRA.Text & Right("      " & VB6.Format(musrHKKZTRA.dblOUTTRA(i), "#####"), 6) & "  "
				''//支給品出庫
				HKKET142F.txtSKYOUT.Text = HKKET142F.txtSKYOUT.Text & Right("      " & VB6.Format(musrHKKZTRA.dblSKYOUT(i), "#####"), 6) & "  "
				''//月末在庫
				HKKET142F.txtLAST_STOCK(j).Text = ""
				''//見込案件
				HKKET142F.txtMKMAK.Text = HKKET142F.txtMKMAK.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMAK(i), "#####"), 6) & "  "
				''//見込見積
				HKKET142F.txtMKMMT.Text = HKKET142F.txtMKMMT.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMMT(i), "#####"), 6) & "  "
				''//見込出庫予定
				HKKET142F.txtMKMOUTTRA.Text = HKKET142F.txtMKMOUTTRA.Text & Right("      " & VB6.Format(musrMKMTRA.dblMKMOUTTRA(i), "#####"), 6) & "  "
				''//見込月末在庫
				HKKET142F.txtMKMLST(j).Text = ""
				'// 2007/01/09 ↓ ADD STR
				''//予測月末在庫
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "#####"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "#####"), 6) & "  "
				End If
				'// 2007/01/09 ↑ ADD END
				''//発注済計
				HKKET142F.txtLMAODSSA.Text = HKKET142F.txtLMAODSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAODSSA(i), "#####"), 6) & "  "
				''//緊急発注済計
				HKKET142F.txtLMAKODSA.Text = HKKET142F.txtLMAKODSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMAKODSA(i), "#####"), 6) & "  "
				''//入庫指示済数
				HKKET142F.txtLMZNOSSA.Text = HKKET142F.txtLMZNOSSA.Text & Right("      " & VB6.Format(musrODINTRA.dblLMZNOSSA(i), "#####"), 6) & "  "
				''//入庫計画数
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "#####"), 6) & "  "
				''//入庫指示数
				HKKET142F.txtLMZNOSS(j).Text = ""
			End If
			
			HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			
			'//月末在庫
			If musrHKKZTRA.strLMZAZM(i) = "0" And musrHKKZTRA.strLMZZKM(i) = "0" Then
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
			ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then 
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
			ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then 
				HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
			End If
			
			If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
				If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
					HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
				End If
			End If
			'//見込月末在庫
			If musrHKKZTRA.strLMZMAZM(i) = "0" And musrHKKZTRA.strLMZMZKM(i) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
			ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
			ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
			End If
			
			If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
				If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
					HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
				End If
			End If
			
			'//発注日
			'        If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then                         2007/08/16 DEL
			'            HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO           2007/08/16 DEL
			'        End If                                                               2007/08/16 DEL
			
			If HKKET142F.cmdMONTH(j).Text = "" Then
				HKKET142F.cmdMONTH(j).Enabled = False
				HKKET142F.txtLMAHKS(j).ReadOnly = True
				HKKET142F.txtLMAHMS(j).ReadOnly = True
				HKKET142F.txtLMZNOSS(j).ReadOnly = True
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				'// V2.20↓ ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				'// V2.20↑ ADD
			Else
				HKKET142F.cmdMONTH(j).Enabled = True
				HKKET142F.txtLMAHKS(j).ReadOnly = False
				HKKET142F.txtLMAHMS(j).ReadOnly = False
				HKKET142F.txtLMZNOSS(j).ReadOnly = False
				HKKET142F.txtINPPLAN(j).ReadOnly = False
				'// V2.20↓ ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = False
				'// V2.20↑ ADD
			End If
			
			If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
				If HKKET142F.cmdMONTH(j).Tag >= Mid(gvstrUNYDT, 1, 6) Then
					'//見直し数/年初計画数
					gvstrCalcDate = CStr(CDbl(Get_CLDMTA(1)) + ((CDbl(HKKET142F.txtPRCCD.Text) + CDbl(HKKET142F.txtMNFDD.Text)) * 5))
					gvstrCalcDate2 = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(Get_CLDMTA(2))), "yyyymmdd")
					If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate2, 1, 6) Then
						HKKET142F.txtLMAHKS(j).ReadOnly = True
						'// 2006/11/17 ↓ DEL STR 見直し数は運用日付以降は入力可能とする。
						'                   HKKET142F.txtLMAHMS(j).Locked = True
						'// 2006/11/17 ↑ DEL END
					Else
						HKKET142F.txtLMAHKS(j).ReadOnly = False
						HKKET142F.txtLMAHMS(j).ReadOnly = False
						HKKET142F.txtINPPLAN(j).ReadOnly = False
						'// V2.20↓ ADD
						HKKET142F.txtLMZNPF(j).ReadOnly = False
						'// V2.20↑ ADD
					End If
					'//入庫指示数
					gvstrCalcDate = CStr(CDbl(Get_CLDMTA(1)) + (CDbl(HKKET142F.txtMNFDD.Text) * 5))
					gvstrCalcDate3 = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, CDate(Get_CLDMTA(2))), "yyyymmdd")
					If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate3, 1, 6) Then
						HKKET142F.txtLMZNOSS(j).ReadOnly = True
					End If
					'//////////////////////////////////////////////////////////////////////////////////
					'//               If Trim(musrODINTRA.strLMZNOSS(j)) <> "" Then   '// @TT
					'//                   HKKET142F.txtLMZNOSS(j).Locked = True
					'//               End If
					'//////////////////////////////////////////////////////////////////////////////////
				Else
					HKKET142F.txtLMAHKS(j).ReadOnly = True
					HKKET142F.txtLMAHMS(j).ReadOnly = True
					HKKET142F.txtLMZNOSS(j).ReadOnly = True
					HKKET142F.txtINPPLAN(j).ReadOnly = True
					'// V2.20↓ ADD
					HKKET142F.txtLMZNPF(j).ReadOnly = True
					'// V2.20↑ ADD
				End If
				HKKET142F.cmdCALC.Enabled = True
				HKKET142F.cmdUPD.Enabled = True
			Else
				HKKET142F.txtLMAHKS(j).ReadOnly = True
				HKKET142F.txtLMAHMS(j).ReadOnly = True
				HKKET142F.txtLAST_STOCK(j).ReadOnly = True
				HKKET142F.txtMKMLST(j).ReadOnly = True
				HKKET142F.txtLMZNOSS(j).ReadOnly = True
				HKKET142F.cmdCALC.Enabled = False
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				'// V2.20↓ ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				'// V2.20↑ ADD
				'HKKET142F.cmdUPD.Enabled = False
			End If
			
			If Trim(musrHKKTRA.strLMAHMS_ORG(i)) <> "" Then
				HKKET142F.txtLMAHKS(j).ReadOnly = True
			End If
			
			If HKKET142F.txtLMAHKS(j).ReadOnly Then
				HKKET142F.txtLMAHKS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMAHKS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			If HKKET142F.txtLMAHMS(j).ReadOnly Then
				HKKET142F.txtLMAHMS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMAHMS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			If HKKET142F.txtINPPLAN(j).ReadOnly Then
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			
			'// V2.20↓ ADD
			If HKKET142F.txtLMZNPF(j).ReadOnly Then
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
			End If
			'// V2.20↑ ADD
			
			If HKKET142F.txtLMZNOSS(j).ReadOnly Then
				HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
			Else
				If System.Drawing.ColorTranslator.ToOle(HKKET142F.txtLMAHMS(j).BackColor) = gvcst_COLOR_HAIIRO Then
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_DAIDAIIRO)
				Else
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_SIRO)
				End If
				If HKKET142F.cmdMONTH(j).Tag < Mid(gvstrCalcDate2, 1, 6) And HKKET142F.cmdMONTH(j).Tag >= Mid(gvstrCalcDate3, 1, 6) Then
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_DAIDAIIRO)
				End If
			End If
			'// 2006/11/17 ↓ ADD STR 部品の入庫指示数は入力可能とする
			'// 2006/11/14 ↓ ADD STR
			'''     If Trim(musrHKKTRA.strLMZPNO(i)) = "" Then
			'''         HKKET142F.txtLMZNOSS(j).Locked = True
			'''         HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_HAIIRO
			'''     End If
			'// 2006/11/14 ↑ ADD END
			If gvstrHINKB = "3" Or gvstrHINKB = "4" Or gvstrHINKB = "5" Then
			Else
				If Trim(musrHKKTRA.strLMZPNO(i)) = "" Then
					HKKET142F.txtLMZNOSS(j).ReadOnly = True
					HKKET142F.txtLMZNOSS(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				End If
			End If
			'// 2006/11/17 ↑ ADD END
			'// 2007/02/12 ↓ ADD STR
			Select Case musrHKKTRA.intLTKBN(i)
				Case 0
					If System.Drawing.ColorTranslator.ToOle(HKKET142F.txtLMAHMS(j).BackColor) <> gvcst_COLOR_HAIIRO Then
						HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' 薄いグリーン
						'// V2.20↓ ADD
						HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' 薄いグリーン
						'// V2.20↑ ADD
					End If
				Case 1
					HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' オレンジ
					'// V2.20↓ ADD
					HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' オレンジ
					'// V2.20↑ ADD
				Case 2
					HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' 薄い黄色
					'// V2.20↓ ADD
					HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' 薄い黄色
					'// V2.20↑ ADD
			End Select
			'// 2007/02/12 ↑ ADD STR
			
			'// V2.00↓ ADD
			If Trim(HKKET142F.txtLMZNOSS(j).Text) <> "" And Val(Trim(HKKET142F.txtLMZNOSS(j).Text)) <> 0 Then
				HKKET142F.txtINPPLAN(j).ReadOnly = True
				HKKET142F.txtINPPLAN(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				'// V2.20↓ ADD
				HKKET142F.txtLMZNPF(j).ReadOnly = True
				HKKET142F.txtLMZNPF(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
				'// V2.20↑ ADD
			End If
			'// V2.00↑ ADD
			
			j = j + 1
			i = i + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		''//前年受注実績
		HKKET142F.txtLAST_JDNTR.Text = RTrim(HKKET142F.txtLAST_JDNTR.Text)
		''//前年出庫実績
		HKKET142F.txtLAST_ODNTRA.Text = RTrim(HKKET142F.txtLAST_ODNTRA.Text)
		''//前年発注実績
		HKKET142F.txtLAST_HDNTRA.Text = RTrim(HKKET142F.txtLAST_HDNTRA.Text)
		''//入庫予定
		HKKET142F.txtINPTRA.Text = RTrim(HKKET142F.txtINPTRA.Text)
		''//出庫予定
		HKKET142F.txtOUTTRA.Text = RTrim(HKKET142F.txtOUTTRA.Text)
		''//支給品出庫
		HKKET142F.txtSKYOUT.Text = RTrim(HKKET142F.txtSKYOUT.Text)
		''//見込案件
		HKKET142F.txtMKMAK.Text = RTrim(HKKET142F.txtMKMAK.Text)
		''//見込見積
		HKKET142F.txtMKMMT.Text = RTrim(HKKET142F.txtMKMMT.Text)
		''//見込出庫予定
		HKKET142F.txtMKMOUTTRA.Text = RTrim(HKKET142F.txtMKMOUTTRA.Text)
		'// 2007/01/09 ↓ ADD STR
		''//予測月末在庫
		HKKET142F.txtYOSLST.Text = RTrim(HKKET142F.txtYOSLST.Text)
		'// 2007/01/09 ↑ ADD END
		''//発注済計
		HKKET142F.txtLMAODSSA.Text = RTrim(HKKET142F.txtLMAODSSA.Text)
		''//緊急発注済計
		HKKET142F.txtLMAKODSA.Text = RTrim(HKKET142F.txtLMAKODSA.Text)
		''//入庫指示済数
		HKKET142F.txtLMZNOSSA.Text = RTrim(HKKET142F.txtLMZNOSSA.Text)
		''//入庫計画数
		HKKET142F.txtDspINPPLAN.Text = RTrim(HKKET142F.txtDspINPPLAN.Text)
		
		'// 2007/02/09 ↓ ADD STR
		Call Dsp_ItemColor()
		'// 2007/02/09 ↑ ADD END
		
		'//担当者権限による画面制御
		Call Set_TantoControl(HKKET142F)
		
		Set_DisplayData = True
		
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
	'//*    Set_CalcData
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*
	'//*****************************************************************************************
	Public Function Set_CalcData() As Boolean
		
		Const PROCEDURE As String = "Set_CalcData"
		
		Dim i As Short
		Dim j As Short
		Dim k As Short
		Dim strDate As String
		Dim dblCalc As Double
		Dim dblCalc2 As Double
		Dim dblDspINPPLAN As Double
		
		Set_CalcData = False
		
		On Error GoTo ONERR_STEP
		
		'// 2007/02/20 ↓ ADD STR
		If Val(HKKET142F.txtMINSODSU.Text) = 0 Or Val(HKKET142F.txtSODADDSU.Text) = 0 Then
			'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "225")
		End If
		'// 2007/02/20 ↑ ADD STR
		
		'// 2007/01/09 ↓ ADD STR
		
		'//予測月末在庫の算出
		Call Set_YosokuGetumatu()
		
		'//入庫計画数の算出
		Call Set_NyukoKeikakuSu()
		
		'//入庫計画数の入力チェック
		If Not Chk_NyukoKeikakuSu Then
			GoTo EXIT_STEP
		End If
		
		'//月末在庫・見込月末在庫の算出
		Call Set_Getumatuzaiko()
		
		i = 0
		Do 
			
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'// 2007/02/24 ↓ UPD STR
				'            '//安全在庫切れマーク(予測月末在庫が０以下の場合は１：在庫切れ)
				'            If musrHKKZTRA.dblYOSLST(i) <= 0 Then
				'//安全在庫切れマーク(予測月末在庫が０未満の場合は１：在庫切れ)
				If musrHKKZTRA.dblYOSLST(i) < 0 Then
					'// 2007/02/24 ↑ UPD STR
					musrHKKZTRA.strLMZAZM(i) = "1"
				Else
					musrHKKZTRA.strLMZAZM(i) = "0"
				End If
				
				'// 2007/02/24 ↓ UPD STR
				'            '//在庫切れマーク(予測月末在庫が－安全在庫数以下の場合は１：在庫切れ)
				'            If musrHKKZTRA.dblYOSLST(i) <= CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
				'//在庫切れマーク(予測月末在庫が－安全在庫数以下の場合は１：在庫切れ)
				If musrHKKZTRA.dblYOSLST(i) < CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
					'// 2007/02/24 ↑ UPD STR
					musrHKKZTRA.strLMZZKM(i) = "1"
				Else
					musrHKKZTRA.strLMZZKM(i) = "0"
				End If
				
				'// 2007/02/24 ↓ UPD STR
				'            '//見込安全在庫切れマーク(見込予測月末在庫が０以下の場合は１：在庫切れ)
				'            If musrHKKZTRA.dblMYOSLST(i) <= 0 Then
				'//見込安全在庫切れマーク(見込予測月末在庫が０未満の場合は１：在庫切れ)
				If musrHKKZTRA.dblMYOSLST(i) < 0 Then
					'// 2007/02/24 ↑ UPD STR
					musrHKKZTRA.strLMZMAZM(i) = "1"
				Else
					musrHKKZTRA.strLMZMAZM(i) = "0"
				End If
				
				'// 2007/02/24 ↓ UPD STR
				'            '//見込在庫切れマーク(見込予測月末在庫が－安全在庫数以下の場合は１：在庫切れ)
				'            If musrHKKZTRA.dblMYOSLST(i) <= CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
				'//見込在庫切れマーク(見込予測月末在庫が－安全在庫数以下の場合は１：在庫切れ)
				If musrHKKZTRA.dblMYOSLST(i) < CDbl(HKKET142F.txtANZZAISU.Text) * -1 Then
					'// 2007/02/24 ↑ UPD STR
					musrHKKZTRA.strLMZMZKM(i) = "1"
				Else
					musrHKKZTRA.strLMZMZKM(i) = "0"
				End If
				
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		'//　項目に色を付ける
		Call Dsp_ItemColor()
		
		Set_CalcData = True
		'// 2007/01/09 ↑ ADD END
		
		'// 2007/01/09 ↓ DEL STR
		''''    Const PROCEDURE         As String = "Set_CalcData"
		''''
		''''    Dim i           As Integer
		''''    Dim j           As Integer
		''''    Dim k           As Integer
		''''    Dim strDate     As String
		''''    Dim dblCalc     As Double
		''''    Dim dblCalc2    As Double
		''''    Dim dblDspINPPLAN  As Double
		''''
		''''    Set_CalcData = False
		''''
		''''    On Error GoTo ONERR_STEP
		''''
		''''    i = 0
		''''    'j = gvlngNowPage
		''''    Do
		''''        If i = 0 Then
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                '//月末在庫:                   入庫予定                   出庫予定　　　　　　　　　　支給品出庫
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//見込月末在庫:          入庫予定                    出庫予定　　　　　　　　　  支給品出庫                 '//見込出庫予定
		''''                musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            Else
		''''                '//月末在庫:                   入庫予定                   入庫指示数                  出庫予定　　　　　　　　　　支給品出庫
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//見込月末在庫:          入庫予定                   入庫指示数                  出庫予定　　　　　　　　　  支給品出庫                 '//見込出庫予定
		''''                musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            End If
		''''        Else
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                '//月末在庫:                   月末在庫(前月)                     入庫予定                   出庫予定　　　　　　　　　　支給品出庫
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) + (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//見込月末在庫:          見込月末在庫(前月)            入庫予定                   出庫予定　　　　　　　　　  支給品出庫                 '//見込出庫予定
		''''                musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) + (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            Else
		''''                '//月末在庫:                   月末在庫(前月)                     入庫予定                   入庫指示数                  出庫予定　　　　　　　　　　支給品出庫
		''''                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
		''''                '//見込月末在庫:          見込月末在庫(前月)            入庫予定                   入庫指示数                  出庫予定　　　　　　　　　  支給品出庫                 '//見込出庫予定
		''''                musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) + musrODINTRA.strLMZNOSS(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i))
		''''            End If
		''''        End If
		''''        If musrMKMTRA.dblMKMLST(i) < 0 Then
		''''            musrMKMTRA.dblMKMLST(i) = 0
		''''        End If
		''''        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
		''''            '//安全在庫切れマーク(月末在庫が安全在庫数より少ない場合は１：在庫切れ)
		''''            If CDbl(HKKET142F.txtANZZAISU.Text) > musrHKKZTRA.dblLAST_STOCK(i) Then
		''''                musrHKKZTRA.strLMZAZM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZAZM(i) = "0"
		''''            End If
		''''
		''''            '//在庫切れマーク(月末在庫が０以下の場合は１：在庫切れ)
		''''            If musrHKKZTRA.dblLAST_STOCK(i) <= 0 Then
		''''                musrHKKZTRA.strLMZZKM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZZKM(i) = "0"
		''''            End If
		''''
		''''            '//見込安全在庫切れマーク(見込月末在庫が安全在庫数より少ない場合は１：在庫切れ)
		''''            If CDbl(HKKET142F.txtANZZAISU.Text) > musrMKMTRA.dblMKMLST(i) Then
		''''                musrHKKZTRA.strLMZMAZM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZMAZM(i) = "0"
		''''            End If
		''''
		''''            '//見込在庫切れマーク(見込月末在庫が０以下の場合は１：在庫切れ)
		''''            If musrMKMTRA.dblMKMLST(i) <= 0 Then
		''''                musrHKKZTRA.strLMZMZKM(i) = "1"
		''''            Else
		''''                musrHKKZTRA.strLMZMZKM(i) = "0"
		''''            End If
		''''            '//入庫計画数(算出)
		''''            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
		''''                If IsNumeric(musrHKKTRA.strLMAHMS(i)) Or _
		'''''                    IsNumeric(musrHKKTRA.strLMAHKS(i)) Then
		''''                    If musrHKKTRA.strLMAHMS(i) = "" Then
		''''                        dblCalc = Val(musrHKKTRA.strLMAHKS(i))
		''''                    Else
		''''                        dblCalc = Val(musrHKKTRA.strLMAHMS(i))
		''''                    End If
		''''                End If
		''''                dblDspINPPLAN = CDbl(HKKET142F.txtANZZAISU.Text) + dblCalc + musrMKMTRA.dblMKMLST(i - 1)
		''''                'If dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text) <= 0 Then
		''''                '    musrODINTRA.dblDspINPPLAN(i) = CDbl(HKKET142F.txtMINSODSU.Text)
		''''                'End If
		''''                'If dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text) > 0 Then
		''''                '    If CDbl(HKKET142F.txtSODADDSU.Text) = 0 Then
		''''                '        dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text)) / 1)
		''''                '    Else
		''''                '        dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtANZZAISU.Text)) / CDbl(HKKET142F.txtSODADDSU.Text))
		''''                '    End If
		''''                '    musrODINTRA.dblDspINPPLAN(i) = CDbl(HKKET142F.txtMINSODSU) + (CDbl(HKKET142F.txtSODADDSU.Text) * dblCalc2)
		''''                'End If
		''''                If CDbl(HKKET142F.txtSODADDSU.Text) <> 0 Then
		''''                    dblCalc2 = Round((dblDspINPPLAN - CDbl(HKKET142F.txtMINSODSU)) / CDbl(HKKET142F.txtSODADDSU.Text) + 0.9) * CDbl(HKKET142F.txtSODADDSU.Text) + CDbl(HKKET142F.txtMINSODSU)
		''''                Else
		''''                    dblCalc2 = 0
		''''                End If
		''''                musrODINTRA.dblDspINPPLAN(i) = dblCalc2
		''''            Else
		''''                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ORG(i)
		''''            End If
		''''        End If
		''''
		''''        If gvlngNowPage <= i Then
		''''            If j < 13 Then
		''''                ''//月末在庫
		''''                HKKET142F.txtLAST_STOCK(j).Text = musrHKKZTRA.dblLAST_STOCK(i)
		''''                ''//見込月末在庫
		''''                HKKET142F.txtMKMLST(j).Text = musrMKMTRA.dblMKMLST(i)
		'''''                HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_SIRO
		'''''                HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_SIRO
		'''''                HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_SIRO
		''''
		''''                '//月末在庫
		''''                If musrHKKZTRA.strLMZAZM(i) = "0" And _
		'''''                    musrHKKZTRA.strLMZZKM(i) = "0" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_MIZURO
		''''                ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_AKAIRO
		''''                ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then
		''''                    HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_MOMOIRO
		''''                End If
		''''                If HKKET141F.optCARRIES_ON.Value And HKKET141F.optSTOCK_MONTH.Value Then
		''''                    If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
		''''                        HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_KAKIIRO
		''''                    End If
		''''                End If
		''''                '//見込月末在庫
		''''                If musrHKKZTRA.strLMZMAZM(i) = "0" And _
		'''''                    musrHKKZTRA.strLMZMZKM(i) = "0" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_MIZURO
		''''                ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_AKAIRO
		''''                ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then
		''''                    HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_MOMOIRO
		''''                End If
		''''
		''''                If HKKET141F.optCARRIES_ON.Value And HKKET141F.optSTOCK_MONTH.Value Then
		''''                    If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
		''''                        HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_KAKIIRO
		''''                    End If
		''''                End If
		''''
		''''                '//発注日
		''''                If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then
		''''                    HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO
		''''                End If
		''''                j = j + 1
		''''            End If
		''''        End If
		''''        i = i + 1
		''''        If i = 36 Then
		''''            Exit Do
		''''        End If
		''''    Loop
		''''
		''''    ''//入庫計画数
		''''    HKKET142F.txtINPPLAN.Text = vbNullString
		''''    i = gvlngNowPage
		''''    j = 0
		''''    Do
		''''        ''//入庫計画数
		''''        HKKET142F.txtINPPLAN.Text = HKKET142F.txtINPPLAN.Text & Right("      " & Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
		''''        i = i + 1
		''''        j = j + 1
		''''        If j = 13 Then
		''''            Exit Do
		''''        End If
		''''    Loop
		''''    ''//入庫計画数
		''''    HKKET142F.txtINPPLAN.Text = RTrim(HKKET142F.txtINPPLAN.Text)
		''''
		''''    Set_CalcData = True
		'// 2007/01/09 ↑ DEL END
		
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
	'//*    Dsp_ItemColor
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*
	'//*****************************************************************************************
	Public Function Dsp_ItemColor() As Boolean
		
		Const PROCEDURE As String = "Dsp_ItemColor"
		
		Dim i As Short
		Dim j As Short
		Dim k As Short
		Dim strDate As String
		Dim dblCalc As Double
		Dim dblCalc2 As Double
		Dim dblDspINPPLAN As Double
		
		Dsp_ItemColor = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			If gvlngNowPage <= i Then
				If j < 13 Then
					''//月末在庫
					HKKET142F.txtLAST_STOCK(j).Text = CStr(musrHKKZTRA.dblLAST_STOCK(i))
					''//見込月末在庫
					HKKET142F.txtMKMLST(j).Text = CStr(musrMKMTRA.dblMKMLST(i))
					'                HKKET142F.txtMKMLST(j).BackColor = gvcst_COLOR_SIRO
					'                HKKET142F.txtLAST_STOCK(j).BackColor = gvcst_COLOR_SIRO
					'                HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_SIRO
					
					'//月末在庫
					If musrHKKZTRA.strLMZAZM(i) = "0" And musrHKKZTRA.strLMZZKM(i) = "0" Then
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
					ElseIf musrHKKZTRA.strLMZZKM(i) = "1" Then 
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
					ElseIf musrHKKZTRA.strLMZAZM(i) = "1" Then 
						HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
					End If
					If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
						If musrHKKZTRA.dblLMZZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
							HKKET142F.txtLAST_STOCK(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
						End If
					End If
					'//見込月末在庫
					If musrHKKZTRA.strLMZMAZM(i) = "0" And musrHKKZTRA.strLMZMZKM(i) = "0" Then
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MIZURO)
					ElseIf musrHKKZTRA.strLMZMZKM(i) = "1" Then 
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_AKAIRO)
					ElseIf musrHKKZTRA.strLMZMAZM(i) = "1" Then 
						HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_MOMOIRO)
					End If
					
					If HKKET141F.optCARRIES_ON.Checked And HKKET141F.optSTOCK_MONTH.Checked Then
						If musrHKKZTRA.dblLMZMZKT(i) >= CDbl(HKKET141F.txtSTOCK_MONTH.Text) Then
							HKKET142F.txtMKMLST(j).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_KAKIIRO)
						End If
					End If
					
					'//発注日
					'           If Trim(musrHKKZTRA.strLMZHDT(i)) <> "" Then                     2007/08/16 DEL
					'               HKKET142F.txtLMZNOSS(j).BackColor = gvcst_COLOR_AKAIRO       2007/08/16 DEL
					'            End If                                                          2007/08/16 DEL
					
					j = j + 1
				End If
				
			End If
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Dsp_ItemColor = True
		
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
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Cra_GraphCSV
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    入庫計画数が繰越した数以上は次月に加算できない
	'//*****************************************************************************************
	Public Function Cra_GraphCSV(ByVal strFilePath As String, ByVal str_FileName As String) As Boolean
		
		Const PROCEDURE As String = "Cra_GraphCSV"
		
		Dim i As Integer
		Dim intFileNo As Short
		Dim strBuff As String

        Dim int_Idx As Short
        Dim str_DialogFilePath As String
        Dim str_DialogFileName_1 As String
        Dim str_DialogFileName_2 As String
		Dim str_FileName_1 As String
		Dim str_FileName_2 As String
        'add test start 20190930 kuwa CSV
        str_DialogFilePath = "C:\Users\CIS03\Desktop\HKKET14CSV"
        'add end 20190930 kuwa

        Cra_GraphCSV = False
		
		On Error GoTo ONERR_STEP
		
		'//月別用ファイル名を作成する
		str_FileName_1 = str_FileName
		
		'//個別用ファイル名を作成する
		int_Idx = InStr(1, str_FileName, ".")
		str_FileName_2 = Mid(str_FileName, 1, int_Idx - 1) & "_2" & Mid(str_FileName, int_Idx)
		
		'//ダイアログボックス起動
		str_DialogFileName_1 = str_FileName_1
		If Not Run_DialogBox((HKKET142F.cdl_SAVE2), str_DialogFilePath, str_DialogFileName_1) Then
			GoTo EXIT_STEP
		End If
		
		'//個別用ファイル名を作成する
		int_Idx = InStr(1, str_DialogFileName_1, ".")
		str_DialogFileName_2 = Mid(str_DialogFileName_1, 1, int_Idx - 1) & "_2" & Mid(str_DialogFileName_1, int_Idx)
		
		'//検索結果ＣＳＶ処理(月別項目)
		intFileNo = FreeFile()
		FileOpen(intFileNo, strFilePath & "\" & str_FileName_1, OpenMode.Output)
		
		'//１行目
		strBuff = ""
		strBuff = strBuff & "コード" & ","
		strBuff = strBuff & "項目" & ","
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.strDSPMONTH(i) '//表示年月
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//２行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "年初計画,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKTRA.strLMAHKS(i) '//年初計画
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//３行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見直計画,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKTRA.strLMAHMS(i) '//見直計画
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//４行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "前年受注実績,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblLAST_JDNTR(i) '//前年受注実績
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//５行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "入庫予定,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblINPTRA(i) '//入庫予定
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//６行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "出庫予定,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblOUTTRA(i) '//出庫予定
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//７行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "支給品出庫,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblSKYOUT(i) '//支給品出庫
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//８行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "月末在庫,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblLAST_STOCK(i) '//月末在庫
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//９行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見込案件,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMAK(i) '//見込案件
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//10行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見込見積,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMMT(i) '//見込見積
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//11行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見込出庫予定,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMOUTTRA(i) '//見込出庫予定
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//12行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見込月末在庫,"
		For i = 0 To 35
			strBuff = strBuff & musrMKMTRA.dblMKMLST(i) '//見込月末在庫
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//13行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "予測月末在庫,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblYOSLST(i) '//予測月末在庫
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//14行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "見込予測月末在庫,"
		For i = 0 To 35
			strBuff = strBuff & musrHKKZTRA.dblMYOSLST(i) '//見込予測月末在庫
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//15行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "発注済数,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMAODSSA(i) '//発注済数
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//16行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "緊急発注済,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMAKODSA(i) '//緊急発注済
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//17行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "入庫指示済数,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.dblLMZNOSSA(i) '//入庫指示済数
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//18行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "入庫計画数,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.strINPPLAN(i) '//入庫計画数
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		'//19行目
		strBuff = HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & "入庫指示数,"
		For i = 0 To 35
			strBuff = strBuff & musrODINTRA.strLMZNOSS(i) '//入庫指示数
			If i < 35 Then
				strBuff = strBuff & ","
			End If
		Next i
		PrintLine(intFileNo, strBuff)
		
		FileClose(intFileNo)
		
		'//検索結果ＣＳＶ処理(個別項目)
		intFileNo = FreeFile()
		FileOpen(intFileNo, strFilePath & "\" & str_FileName_2, OpenMode.Output)
		
		'//１行目
		strBuff = ""
		strBuff = strBuff & "ｺｰﾄﾞ" & ","
		strBuff = strBuff & "型式" & ","
		strBuff = strBuff & "在庫ﾗﾝｸ" & ","
		strBuff = strBuff & "商品郡" & ","
		strBuff = strBuff & "最小発注数" & ","
		strBuff = strBuff & "発注増加数" & ","
		strBuff = strBuff & "安全在庫数" & ","
		strBuff = strBuff & "安全在庫基準月数" & ","
		strBuff = strBuff & "在庫月数" & ","
		strBuff = strBuff & "平均出庫数" & ","
		strBuff = strBuff & "出荷変化率" & ","
		strBuff = strBuff & "調達L/T" & ","
		strBuff = strBuff & "生産L/T" & ","
		strBuff = strBuff & "当月入庫実績" & ","
		strBuff = strBuff & "当月出庫実績" & ","
		strBuff = strBuff & "現在庫" & ","
		strBuff = strBuff & "備考ｺﾒﾝﾄ" & ","
		strBuff = strBuff & "ﾒﾓｺﾒﾝﾄ"
		PrintLine(intFileNo, strBuff)
		
		'//２行目
		strBuff = ""
		strBuff = strBuff & HKKET142F.txtHINCD.Text & ","
		strBuff = strBuff & HKKET142F.txtHINNMA.Text & ","
		strBuff = strBuff & HKKET142F.txtZAIRNK.Text & ","
		strBuff = strBuff & gvstrHINGRP & ","
		strBuff = strBuff & HKKET142F.txtMINSODSU.Text & ","
		strBuff = strBuff & HKKET142F.txtSODADDSU.Text & ","
		strBuff = strBuff & HKKET142F.txtANZZAISU.Text & ","
		strBuff = strBuff & HKKET142F.txtLMAMSAVTS.Text & ","
		strBuff = strBuff & HKKET142F.txtLMAAVTS.Text & ","
		strBuff = strBuff & HKKET142F.txtLMZAVTSA.Text & ","
		strBuff = strBuff & HKKET142F.txtCHGRATE.Text & ","
		strBuff = strBuff & HKKET142F.txtPRCCD.Text & ","
		strBuff = strBuff & HKKET142F.txtMNFDD.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUNYUKO.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUSYUKO.Text & ","
		strBuff = strBuff & HKKET142F.txtTOUZAISU.Text & ","
		strBuff = strBuff & HKKET142F.txtHINCM.Text & ","
		strBuff = strBuff & HKKET142F.txtMEMO.Text
		PrintLine(intFileNo, strBuff)
		
		FileClose(intFileNo)
		
		'//選択されたファイルの移動
		On Error Resume Next
		Kill(str_DialogFilePath & str_DialogFileName_1)
		FileCopy(strFilePath & "\" & str_FileName_1, str_DialogFilePath & str_DialogFileName_1)
		Kill(strFilePath & "\" & str_FileName_1)
		On Error GoTo 0
		
		'//選択されたファイルの移動
		On Error Resume Next
		Kill(str_DialogFilePath & str_DialogFileName_2)
		FileCopy(strFilePath & "\" & str_FileName_2, str_DialogFilePath & str_DialogFileName_2)
		Kill(strFilePath & "\" & str_FileName_2)
		On Error GoTo 0
		
		Cra_GraphCSV = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chk_NyukoKeikakuSu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    入庫計画数が繰越した数以上は次月に加算できない
	'//*****************************************************************************************
	Public Function Chk_NyukoKeikakuSu() As Boolean
		
		Const PROCEDURE As String = "Chk_NyukoKeikakuSu"
		
		Dim dblNyukoKeiSu_CAL As Double
		Dim dblNyukoKeiSu_ORG As Double
		Dim i As Short
		Dim j As Short
		
		Chk_NyukoKeikakuSu = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			
			'//当月以降のみ処理する
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'//製造LT期間内のみでチェックする
				If musrHKKTRA.intLTKBN(i) = 1 Then
					If Val(Trim(musrODINTRA.strINPPLAN(i))) > musrODINTRA.dblDspINPPLAN_ZEN(i) Then
						'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "219")
						GoTo EXIT_STEP
					End If
				End If
				
				'//調達LT期間内のみでチェックする
				If musrHKKTRA.intLTKBN(i) = 2 Then
					dblNyukoKeiSu_CAL = dblNyukoKeiSu_CAL + Val(Trim(musrODINTRA.strINPPLAN(i)))
					dblNyukoKeiSu_ORG = dblNyukoKeiSu_ORG + musrODINTRA.dblDspINPPLAN_ZEN(i)
					
					If dblNyukoKeiSu_CAL > dblNyukoKeiSu_ORG Then
						'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "219")
						GoTo EXIT_STEP
					End If
					
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Chk_NyukoKeikakuSu = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Set_NyukoKeikakuSu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    入庫計画数を求める
	'//*****************************************************************************************
	Public Function Set_NyukoKeikakuSu() As Boolean
		
		Const PROCEDURE As String = "Set_NyukoKeikakuSu"
		
		''  Dim dblMokuhyoChi   As Double
		Dim dblNyukoKeiSu As Double
		''  Dim dblKeisanMinus  As Double
		''  Dim dblKeisanPlus   As Double
		
		'//2007/12/18 ADD START
		Dim dblKomiyosoku As Double 'アドバイス込みの予測月末在庫
		Dim dblKurikosi As Double '繰越
		'//200712/18 ADD END
		
		Dim i As Short
		Dim j As Short
		Dim dblWork As Double
		
		
		Set_NyukoKeikakuSu = False
		
		On Error GoTo ONERR_STEP
		'//2007/12/18 ADD START
		dblKomiyosoku = 0
		dblKurikosi = 0
		'//2007/12/18 ADD END
		i = 0
		Do 
			'// 2007/11/27 REP START ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			'//
			'//        '//当月以降のみ処理する
			'//        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//            musrODINTRA.dblDspINPPLAN(i) = 0
			'//            dblMokuhyoChi = 0
			'//            dblNyukoKeiSu = 0
			'//
			'//'// 2007/02/17 ↓ DLL STR
			'//'            If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//'// 2007/02/17 ↑ DLL END
			'//
			'//                '//目標値の取得（見直計画または年初計画(見直し優先)）
			'//                If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
			'//                    dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
			'//                Else
			'//                    dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
			'//                End If
			'//
			'//                '//入庫計画数の計算
			'//                If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 Then
			'//'                    dblNyukoKeiSu = dblMokuhyoChi - musrHKKZTRA.dblYOSLST(i)
			'//                    dblNyukoKeiSu = dblMokuhyoChi - musrHKKZTRA.dblYOSLST(i - 1)
			'//'                Else
			'//'                    dblNyukoKeiSu = Val(Trim(musrODINTRA.strINPPLAN(i)))
			'//                End If
			'//
			'//                '//繰越計算
			'//                If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 Then
			'//                    If musrHKKTRA.intLTKBN(i) <> 0 Then
			'//                        If musrODINTRA.dblDspINPPLAN_ZEN(i) > dblNyukoKeiSu Then
			'//                            dblKeisanMinus = dblKeisanMinus + (dblNyukoKeiSu - musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                        Else
			'//                            dblKeisanPlus = dblKeisanPlus + (dblNyukoKeiSu - musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                        End If
			'//                    End If
			'//                End If
			'//
			'//                '//繰越計算結果反映と入庫計画数設定
			'//                Select Case musrHKKTRA.intLTKBN(i)
			'//
			'//                    Case 0              '//通常
			'//'// 2007/02/12 ↓ ADD START
			'//                        '//予測月末在庫が－１以下のときに計算する
			'//                        If musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi < 0 Then
			'//'                            dblWork = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i))
			'//                            dblWork = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi)
			'//                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblWork
			'//                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblWork
			'//                            dblNyukoKeiSu = dblWork
			'//                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(dblNyukoKeiSu)
			'//                        Else
			'//'                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblKeisanPlus + dblKeisanMinus
			'//'                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + dblKeisanPlus + dblKeisanMinus
			'//                            musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//'// 2007/06/29 ↓ UPD START @T
			'//'                           musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//                           '//予測月末在庫:            前月予測月末在庫                入庫予定                    見込出庫予定                 目標値
			'//                            musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi
			'//'// 2007/06/29 ↑ UPD END   @T
			'//                            dblNyukoKeiSu = 0
			'//                        End If
			'//'// 2007/02/12 ↑ ADD END
			'//
			'//'                        If musrHKKZTRA.dblYOSLST(i) + dblKeisanPlus + dblKeisanMinus <> 0 Then
			'//'                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrHKKZTRA.dblYOSLST(i) + dblKeisanPlus + dblKeisanMinus)
			'//'                        If dblNyukoKeiSu <> 0 Then
			'//'                            musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(dblNyukoKeiSu)
			'//'                        Else
			'//'                            musrODINTRA.dblDspINPPLAN(i) = dblNyukoKeiSu
			'//'                        End If
			'//                        dblKeisanPlus = 0
			'//                        dblKeisanMinus = 0
			'//                    Case 1              '//製造LT
			'//                        If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//                            If musrODINTRA.dblDspINPPLAN_ZEN(i) <= 0 Then
			'//                                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ZEN(i)
			'//                            Else
			'//                                musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrODINTRA.dblDspINPPLAN_ZEN(i))
			'//                            End If
			'//                        Else
			'//                            dblKeisanPlus = 0
			'//                            dblKeisanMinus = 0
			'//                        End If
			'//                    Case 2              '//調達LT
			'//                        If musrHKKZTRA.dblYOSLST(i) < 0 Then
			'//                            If musrODINTRA.dblDspINPPLAN_ZEN(i) <= 0 Then
			'//                                musrODINTRA.dblDspINPPLAN(i) = musrODINTRA.dblDspINPPLAN_ZEN(i)
			'//                            Else
			'//                                musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(musrODINTRA.dblDspINPPLAN_ZEN(i) + dblKeisanMinus)
			'//                                dblKeisanMinus = 0
			'//                            End If
			'//                        Else
			'//                            dblKeisanPlus = 0
			'//                            dblKeisanMinus = 0
			'//                        End If
			'//
			'//                End Select
			'//
			'// 2007/02/12 ↓ ADD STR
			'//            End If
			'// 2007/02/12 ↑ ADD END
			'//
			'//        End If
			'////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			
			'//当月以降のみ処理する
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				musrODINTRA.dblDspINPPLAN(i) = 0 '//アドバイス初期クリア
				dblNyukoKeiSu = 0
				
				dblKomiyosoku = dblKurikosi + musrHKKZTRA.dblMYOSLST(i) '//前月までのアドバイス込みの予測月末在庫
				
				'// 2008/05/21 ↓ ADD STR 入庫指示数にスペースかゼロが入ってる場合は、アドバイス値は繰り越す
				If Val(Trim(musrODINTRA.strLMZNOSS(i))) <> 0 Then
					musrODINTRA.dblDspINPPLAN(i) = 0
				Else
					'// 2008/05/21 ↑ ADD STR
					
					'//繰越計算結果反映と入庫計画数設定
					Select Case musrHKKTRA.intLTKBN(i)
						Case 0 '//通常 増減可
							If dblKomiyosoku < 0 Then '//在庫不足  入庫計画の追加をアドバイス
								musrODINTRA.dblDspINPPLAN(i) = Get_Hacyusu(0 - dblKomiyosoku)
							Else
								'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
								'                                If Get_Hacyusu(dblKomiyosoku) > musrODINTRA.strINPPLAN(i) Then  '//在庫過多  入庫計画の取消をアドバイス
								'                                    musrODINTRA.dblDspINPPLAN(i) = 0 - musrODINTRA.strINPPLAN(i)
								If Get_Hacyusu(dblKomiyosoku) > Val(musrODINTRA.strINPPLAN(i)) Then '//在庫過多  入庫計画の取消をアドバイス
									musrODINTRA.dblDspINPPLAN(i) = 0 - Val(musrODINTRA.strINPPLAN(i))
									'// 2008/05/27 ↑ UPD STR
								Else '//在庫過多  入庫計画の減算をアドバイス
									'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
									'                                    If Get_Hacyusu(dblKomiyosoku) < musrODINTRA.strINPPLAN(i) Then
									If Get_Hacyusu(dblKomiyosoku) < Val(musrODINTRA.strINPPLAN(i)) Then
										'// 2008/05/27 ↑ UPD STR
										'// 2008/05/27 ↓ UPD STR 入庫計画(連携)をｱﾄﾞﾊﾞｲｽ通り入力してもｱﾄﾞﾊﾞｲｽ値が０にならない対応
										'                                         musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										If dblKomiyosoku <> 0 Then
											musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										Else
											musrODINTRA.dblDspINPPLAN(i) = 0
										End If
										'// 2008/05/27 ↑ UPD STR
									Else
										musrODINTRA.dblDspINPPLAN(i) = 0
									End If
								End If
							End If
						Case 1 '//製造LT　増減不可
							musrODINTRA.dblDspINPPLAN(i) = 0
						Case 2 '//調達LT　減のみ可
							If dblKomiyosoku < 0 Then
								musrODINTRA.dblDspINPPLAN(i) = 0 '//在庫不足  次月へアドバイスを繰越
							Else
								'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
								'                                If Get_Hacyusu(dblKomiyosoku) > musrODINTRA.strINPPLAN(i) Then        '//在庫過多  入庫計画の取消をアドバイス
								'                                     musrODINTRA.dblDspINPPLAN(i) = 0 - musrODINTRA.strINPPLAN(i)
								If Get_Hacyusu(dblKomiyosoku) > Val(musrODINTRA.strINPPLAN(i)) Then '//在庫過多  入庫計画の取消をアドバイス
									musrODINTRA.dblDspINPPLAN(i) = 0 - Val(musrODINTRA.strINPPLAN(i))
									'// 2008/05/27 ↑ UPD STR
								Else '//在庫過多  入庫計画の減算をアドバイス
									'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
									'                                    If Get_Hacyusu(dblKomiyosoku) < musrODINTRA.strINPPLAN(i) Then
									If Get_Hacyusu(dblKomiyosoku) < Val(musrODINTRA.strINPPLAN(i)) Then
										'// 2008/05/27 ↑ UPD STR
										'// 2008/05/27 ↓ UPD STR 入庫計画(連携)をｱﾄﾞﾊﾞｲｽ通り入力してもｱﾄﾞﾊﾞｲｽ値が０にならない対応
										'                                         musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										If dblKomiyosoku <> 0 Then
											musrODINTRA.dblDspINPPLAN(i) = 0 - Get_Hacyusu(dblKomiyosoku)
										Else
											musrODINTRA.dblDspINPPLAN(i) = 0
										End If
										'// 2008/05/27 ↑ UPD STR
									Else
										musrODINTRA.dblDspINPPLAN(i) = 0
									End If
								End If
							End If
					End Select
					
					'// 2008/05/21 ↓ ADD STR 入庫指示数にスペースかゼロが入ってる場合は、アドバイス値は繰り越す
				End If
				'// 2008/05/21 ↑ ADD STR
				
				'//翌月繰越アドバイス（アドバイスの累計）
				dblKurikosi = dblKurikosi + musrODINTRA.dblDspINPPLAN(i)
			End If

            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop 
		
		''//予測月末在庫
		HKKET142F.txtYOSLST.Text = vbNullString
		i = gvlngNowPage
		j = 0
		Do 
			''//予測月末在庫
			If musrHKKZTRA.strDSPMONTH(i) = "" Then
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "#####"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "#####"), 6) & "  "
				End If
			Else
				If HKKET141F.optORDER_ON.Checked Then
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblMYOSLST(i), "####0"), 6) & "  "
				Else
					HKKET142F.txtYOSLST.Text = HKKET142F.txtYOSLST.Text & Right("      " & VB6.Format(musrHKKZTRA.dblYOSLST(i), "####0"), 6) & "  "
				End If
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		''//予測月末在庫
		HKKET142F.txtYOSLST.Text = RTrim(HKKET142F.txtYOSLST.Text)
		
		''//入庫計画数
		HKKET142F.txtDspINPPLAN.Text = vbNullString
		i = gvlngNowPage
		j = 0
		Do 
			''//入庫計画数
			If musrHKKZTRA.strDSPMONTH(i) = "" Then
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "#####"), 6) & "  "
			Else
				HKKET142F.txtDspINPPLAN.Text = HKKET142F.txtDspINPPLAN.Text & Right("      " & VB6.Format(musrODINTRA.dblDspINPPLAN(i), "####0"), 6) & "  "
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		''//入庫計画数
		HKKET142F.txtDspINPPLAN.Text = RTrim(HKKET142F.txtDspINPPLAN.Text)
		
		Set_NyukoKeikakuSu = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/02/02 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chk_Hacyusu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    発注ロット単位に入力されているか確認する
	'//*****************************************************************************************
	Public Function Chk_Hacyusu() As Boolean
		
		Const PROCEDURE As String = "Chk_Hacyusu"
		
		Dim i As Double
		
		On Error GoTo ONERR_STEP
		
		Chk_Hacyusu = False

        '2019/04/19 CHG START
        'For i = 1 To UBound(musrODINTRA.strINPPLAN)
        For i = 0 To musrODINTRA.strINPPLAN.Length - 1
            '2019/04/19 CHG E N D

            '// 2007/02/24 ↓ ADD
            '//当月以降のみ処理する
            If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
                '// 2007/02/24 ↑ ADD

                If Val(Trim(musrODINTRA.strINPPLAN(i))) <> 0 Then
                    '// 最小発注数と比較
                    If Val(Trim(musrODINTRA.strINPPLAN(i))) < Val(HKKET142F.txtMINSODSU.Text) Then
                        Exit For
                    End If
                    '// 発注ロット単位か確認
                    If Val(HKKET142F.txtSODADDSU.Text) <> 0 Then
                        If Val(Trim(musrODINTRA.strINPPLAN(i))) - Val(HKKET142F.txtMINSODSU.Text) <> 0 Then
                            'UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                            If ((Val(Trim(musrODINTRA.strINPPLAN(i))) - Val(HKKET142F.txtMINSODSU.Text)) Mod Val(HKKET142F.txtSODADDSU.Text)) <> 0 Then
                                Exit For
                            End If
                        End If
                    End If
                End If


                '// 2007/02/24 ↓ ADD
            End If
            '// 2007/02/24 ↑ ADD

        Next i

        '2019/04/19 CHG START
        'If i < UBound(musrODINTRA.strINPPLAN) Then
        If i < musrODINTRA.strINPPLAN.Length - 1 Then
            '2019/04/19 CHG E N D
            'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "224", vbCrLf & Mid(musrHKKZTRA.strDSPMONTH(i), 1, 4) & "/" & Mid(musrHKKZTRA.strDSPMONTH(i), 5, 2) & "が" & "最小発注数より小さいか、発注増加数単位に入力されていません。")
            '// 2007/02/24 ↓ DEL
            ''''        GoTo EXIT_STEP
            '// 2007/02/24 ↑ DEL
        End If

        Chk_Hacyusu = True

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
	'// 2007/02/02 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Set_NyukoKeikakuSu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    月末在庫・見込月末在庫を求める
	'//*****************************************************************************************
	Public Function Set_Getumatuzaiko() As Boolean
		
		Const PROCEDURE As String = "Set_Getumatuzaiko"
		
		Dim dblMokuhyoChi As Double
		Dim dblNyukoKeiSu As Double
		''' Dim dblKeisanMinus  As Double
		''' Dim dblKeisanPlus   As Double
		Dim i As Short
		Dim j As Short
		
		Set_Getumatuzaiko = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			
			'//当月以降のみ処理する
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
					
					'// << 当    月 >>
					
					'                '//月末在庫:                   現在在庫数                        入庫予定                   出庫予定　　　　　　　　　　支給品出庫
					musrHKKZTRA.dblLAST_STOCK(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//月末在庫:                   現在在庫数                        入庫予定                   出庫予定　　　　　　　　　　支給品出庫
					'                musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//見込月末在庫:          月末在庫                       '//見込出庫予定
					musrMKMTRA.dblMKMLST(i) = musrHKKZTRA.dblLAST_STOCK(i) - musrMKMTRA.dblMKMOUTTRA(i)
				Else
					
					'// << 翌月以降 >>
					
					'//月末在庫:                   月末在庫(前月)                     入庫予定                   出庫予定　　　　　　　　　　支給品出庫
					musrHKKZTRA.dblLAST_STOCK(i) = musrHKKZTRA.dblLAST_STOCK(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i))
					'//見込月末在庫:          見込月末在庫(前月)            入庫予定                   出庫予定　　　　　　　　　  支給品出庫                 '//見込出庫予定
					musrMKMTRA.dblMKMLST(i) = musrMKMTRA.dblMKMLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i)) - musrMKMTRA.dblMKMOUTTRA(i)
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Set_Getumatuzaiko = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_Hacyusu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    最小発注数を下回る場合は最小発注数を、超える場合は発注増加単位に丸めて発注数を求める
	'//*****************************************************************************************
	Public Function Get_Hacyusu(ByVal dblNyukoKeiSu As Double) As Double
		
		Const PROCEDURE As String = "Get_Hacyusu"
		
		Dim dblZoukaCnt As Double
		Dim dblZoukaSu As Double
		
		On Error GoTo ONERR_STEP
		
		'// 2007/02/20 ↓ UPD
		Get_Hacyusu = 0
		
		If Val(HKKET142F.txtMINSODSU.Text) = 0 And dblNyukoKeiSu < 0 Then
			'//最小発注数が存在しないのでそのまま返す
			Get_Hacyusu = System.Math.Abs(dblNyukoKeiSu) ' HKKET142F.txtMINSODSU
			Exit Function
		End If
		
		If dblNyukoKeiSu < Val(HKKET142F.txtMINSODSU.Text) Then
			'//最小発注数より小さいので最小発注数にする
			'        Get_Hacyusu = Val(HKKET142F.txtMINSODSU)
			dblZoukaSu = Val(HKKET142F.txtMINSODSU.Text)
			dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtMINSODSU.Text)
			Do 
				If dblNyukoKeiSu > 0 Or Val(HKKET142F.txtSODADDSU.Text) = 0 Then
					Exit Do
				End If
				dblZoukaSu = dblZoukaSu + Val(HKKET142F.txtSODADDSU.Text)
				dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtSODADDSU.Text)
			Loop 
			dblNyukoKeiSu = dblZoukaSu
			
		End If
		
		'//最小発注数と発注増加数を考慮に入れて入庫計画数を計算する
		If Val(HKKET142F.txtSODADDSU.Text) = 0 Then
			'//発注増加数が０の場合
			dblZoukaCnt = 0
			
			'//増加単位が存在しないのでそのまま返す
			Get_Hacyusu = dblNyukoKeiSu
		Else
			'//発注増加数が０で無い場合
			dblZoukaCnt = Int((dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU.Text)) / Val(HKKET142F.txtSODADDSU.Text))
			
			'//増加単位切り上げ数
			'UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			If (dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU.Text)) Mod Val(HKKET142F.txtSODADDSU.Text) <> 0 Then
				dblZoukaCnt = dblZoukaCnt + 1
			End If
			
			'入庫計画数      最小発注単位                  増加数        発注増加単位数
			Get_Hacyusu = Val(HKKET142F.txtMINSODSU.Text) + (dblZoukaCnt * Val(HKKET142F.txtSODADDSU.Text))
		End If
		
		''''    Get_Hacyusu = 0
		''''
		''''    If Val(HKKET142F.txtMINSODSU) = 0 Then
		''''        '//最小発注数が存在しないのでそのまま返す
		''''        Get_Hacyusu = dblNyukoKeiSu
		''''    End If
		''''
		''''    If dblNyukoKeiSu < Val(HKKET142F.txtMINSODSU) Then
		''''        '//最小発注数より小さいので最小発注数にする
		'''''        Get_Hacyusu = Val(HKKET142F.txtMINSODSU)
		''''        dblZoukaSu = Val(HKKET142F.txtMINSODSU)
		''''        dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtMINSODSU)
		''''        Do
		''''            If dblNyukoKeiSu > 0 Then
		''''                Exit Do
		''''            End If
		''''            dblZoukaSu = dblZoukaSu + Val(HKKET142F.txtSODADDSU)
		''''            dblNyukoKeiSu = dblNyukoKeiSu + Val(HKKET142F.txtSODADDSU)
		''''        Loop
		''''        dblNyukoKeiSu = dblZoukaSu
		''''
		''''    End If
		''''
		''''    '//最小発注数と発注増加数を考慮に入れて入庫計画数を計算する
		''''    If Val(HKKET142F.txtSODADDSU) = 0 Then
		''''        '//発注増加数が０の場合
		''''        dblZoukaCnt = 0
		''''
		''''        '//増加単位が存在しないのでそのまま返す
		''''        Get_Hacyusu = dblNyukoKeiSu
		''''    Else
		''''        '//発注増加数が０で無い場合
		''''        dblZoukaCnt = Int((dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU)) / Val(HKKET142F.txtSODADDSU))
		''''
		''''        '//増加単位切り上げ数
		''''        If (dblNyukoKeiSu - Val(HKKET142F.txtMINSODSU)) Mod Val(HKKET142F.txtSODADDSU) <> 0 Then
		''''            dblZoukaCnt = dblZoukaCnt + 1
		''''        End If
		''''
		''''        '入庫計画数      最小発注単位                  増加数        発注増加単位数
		''''        Get_Hacyusu = Val(HKKET142F.txtMINSODSU) + (dblZoukaCnt * Val(HKKET142F.txtSODADDSU))
		''''    End If
		'// 2007/02/20 ↑ UPD
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Set_YosokuGetumatu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    予測月末在庫を求める
	'//*****************************************************************************************
	Public Function Set_YosokuGetumatu() As Boolean
		
		Const PROCEDURE As String = "Set_YosokuGetumatu"
		
		Dim lngZanEigyoHi As Integer
		Dim lngTouEigyoHi As Integer
		Dim dblMokuhyoChi As Double
		Dim dblZanHiAnbun As Double
		Dim dblSyukoYotei As Double
		Dim i As Short
		Dim j As Short
		
		Set_YosokuGetumatu = False
		
		On Error GoTo ONERR_STEP
		
		i = 0
		Do 
			'// 2007/11/27 REP START ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			'//        '//当月以降のみ処理する
			'//        If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//           '//目標値の取得（見直計画または年初計画(見直し優先)）txtLMAHMS
			'//            If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
			'//                dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
			'//            Else
			'//                dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
			'//            End If
			'//
			'//            If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
			'//
			'//                '// << 当    月 >>
			'//
			'//                '//出庫予定
			'//                dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)
			'//
			'//                '//残営業日の取得
			'//                lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")
			'//
			'//                '//当月営業日の取得
			'//                lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")
			'//
			'//                '//残日数按分値
			'//                If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
			'//                    '//残日数が４日以下の場合
			'//                    dblZanHiAnbun = 0
			'//                Else
			'//                    '//出荷予定比較日数から按分値を求める
			'//                    If dblSyukoYotei < Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
			'//                        '//出庫予定が目標値の４日分を超えない場合
			'//                        dblZanHiAnbun = Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
			'//                    Else
			'//                        '//出庫予定が目標値の４日分を超えた場合
			'//                        dblZanHiAnbun = Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
			'//                    End If
			'//             End If
			'//
			'//'// 2007/01/28 ↓ ADD START
			'//                HKKET142F.txtZanHiAnbun = CStr(dblZanHiAnbun)
			'//                HKKET142F.txtZanDeAnbun = CStr(Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
			'//                HKKET142F.txtZAN = CStr(lngZanEigyoHi)
			'//                HKKET142F.txtZEN = CStr(lngTouEigyoHi)
			'//'// 2007/01/28 ↑ ADD END
			'//
			'//                '//計算：予測月末在庫(見込含まない)
			'//                '//予測月末在庫:           現在在庫数                        入庫予定                    出庫予定　　　　　　　　 　支給品出庫                 安全在庫                            残日数按分値
			'//                musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun
			'//
			'//                '//計算：予測月末在庫(見込含む)
			'//                '//予測月末在庫:           現在在庫数                         入庫予定                   出庫予定　　　　　　　　　  支給品出庫                 見込出庫予定                 安全在庫                            残日数按分値
			'//                musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun
			'//
			'//            Else
			'//
			'//                '// << 翌月以降 >>
			'//
			'//                '// 計算：予測月末在庫(見込含まない)
			'//
			'//'// 2007/01/28 ↓ UPD START
			'//'                '//予測月末在庫:           前月予測月末在庫               入庫予定                    安全在庫                            目標値
			'//'                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (CDbl(HKKET142F.txtANZZAISU.Text)) - dblMokuhyoChi
			'//                '//予測月末在庫:           前月予測月末在庫               入庫予定                   目標値
			'//                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi
			'//'// 2007/01/28 ↑ UPD END
			'//
			'//                '//計算：予測月末在庫(見込含む)
			'//
			'//'// 2007/01/28 ↓ UPD START
			'//'                '//予測月末在庫:            前月予測月末在庫                入庫予定                    見込出庫予定                 安全在庫                            目標値
			'//'                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - (musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblMokuhyoChi
			'//                '//予測月末在庫:            前月予測月末在庫                入庫予定                    見込出庫予定                 目標値
			'//                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi
			'//'// 2007/01/28 ↑ UPD END
			'//
			'//            End If
			'//
			'//        End If
			'// 2007/11/27 REP END ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
			'//当月以降のみ処理する
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				'//目標値の取得（見直計画または年初計画(見直し優先)）txtLMAHMS
				If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
					dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
				Else
					dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
				End If
				
				If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
					'//【当月】
					dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i) '//出庫予定
					lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31") '//残営業日の取得
					lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31") '//当月営業日の取得
					If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then '//残日数按分値
						dblZanHiAnbun = 0 '//残日数が４日以下の場合
					Else
						'//出荷予定比較日数から按分値を求める
						If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then '//出庫予定が目標値の４日分を超えない場合
							dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
						Else
							dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi) '//出庫予定が目標値の４日分を超えた場合
						End If
					End If
					
					HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
					HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
					HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
					HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)
					
					'今回入力分を入庫予定として計算する。
					
					'//計算：予測月末在庫(見込含まない)
					'//予測月末在庫:           現在在庫数                        入庫予定                    出庫予定　　　　　 　　 　 支給品出庫                 安全在庫                            残日数按分値    (入力入庫計画 － 前日入力入庫計画)
					'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
					'                musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 ↑ UPD STR
					
					'//計算：予測月末在庫(見込含む)
					'//予測月末在庫:           現在在庫数                        入庫予定                    出庫予定　　　　　　　　　  支給品出庫                 見込出庫予定                 安全在庫                            残日数按分値    (入力入庫計画 － 前日入力入庫計画)
					'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
					'                musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblMYOSLST(i) = Val(HKKET142F.txtTOUZAISU.Text) + musrHKKZTRA.dblINPTRA(i) - (musrHKKZTRA.dblOUTTRA(i) + musrHKKZTRA.dblSKYOUT(i) + musrMKMTRA.dblMKMOUTTRA(i) + CDbl(HKKET142F.txtANZZAISU.Text)) - dblZanHiAnbun + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 ↑ UPD STR
				Else
					'// 【翌月以降】
					'// 計算：予測月末在庫(見込含まない)
					
					'//予測月末在庫:           前月予測月末在庫               入庫予定                   目標値         (入力入庫計画 － 前日入力入庫計画)
					'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
					'                musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblYOSLST(i) = musrHKKZTRA.dblYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - dblMokuhyoChi + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 ↑ UPD STR
					
					'//計算：予測月末在庫(見込含む)
					
					'//予測月末在庫:            前月予測月末在庫                入庫予定                    見込出庫予定                 目標値          (入力入庫計画 － 前日入力入庫計画)
					'// 2008/05/27 ↓ UPD STR 入庫計画(連携)にスペースが入力されるとエラーが発生する
					'                musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi + (musrODINTRA.strINPPLAN(i) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					musrHKKZTRA.dblMYOSLST(i) = musrHKKZTRA.dblMYOSLST(i - 1) + musrHKKZTRA.dblINPTRA(i) - musrMKMTRA.dblMKMOUTTRA(i) - dblMokuhyoChi + (Val(musrODINTRA.strINPPLAN(i)) - musrODINTRA.dblDspINPPLAN_ZEN(i))
					'// 2008/05/27 ↑ UPD STR
				End If
			End If
			
			i = i + 1
			If i = 36 Then
				Exit Do
			End If
		Loop 
		
		Set_YosokuGetumatu = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_EigyoNisu
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    指定された期間の営業日数を取得する
	'//*****************************************************************************************
	Public Function Get_EigyoNisu(ByVal strStart As String, ByVal strEnd As String) As Integer
		
		Const PROCEDURE As String = "Get_EigyoNisu"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D

		On Error GoTo ONERR_STEP
		
		Get_EigyoNisu = 0
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(V1.SLSMDD) AS SLSMDD FROM " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & " (SELECT SLSMDD FROM CLDMTA WHERE CLDDT BETWEEN " & D0.Edt_SQL("S", strStart) & " AND " & D0.Edt_SQL("S", strEnd) & vbCrLf
		strSQL = strSQL & " GROUP BY SLSMDD) V1" & vbCrLf
		
		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'Get_EigyoNisu = D0.Chk_NullN(objRec("SLSMDD"))
        Get_EigyoNisu = D0.Chk_NullN(dt.Rows(0)("SLSMDD"))
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_FIXMTA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    予測月末在庫を計算する
	'//*****************************************************************************************
	Public Function Get_FIXMTA() As Boolean
		
		Const PROCEDURE As String = "Get_FIXMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objRec As OraDynaset
		
		Get_FIXMTA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT FIXVAL " & vbCrLf
		strSQL = strSQL & "FROM   FIXMTA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "WHERE  CTLCD = " & D0.Edt_SQL("S", "402") & vbCrLf
		
		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'gvlngSyukaYoteiHikaku = D0.Chk_NullN(objRec("FIXVAL"))
        gvlngSyukaYoteiHikaku = D0.Chk_NullN(dt.Rows(0)("FIXVAL"))
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

		Get_FIXMTA = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'// 2007/01/09 ↓ ADD STR
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_LTKIKAN
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    リードタイム期間の算出を行う
	'//*****************************************************************************************
	Public Function Get_LTKIKAN() As Boolean
		
		Const PROCEDURE As String = "Get_LTKIKAN"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D
        Dim dblSLSMDD As Double
		Dim i As Short
		
		Get_LTKIKAN = False
		
		On Error GoTo ONERR_STEP
		
		'// 2007/03/10 ↓ ADD 調達LT/製造LT が 0 の時 は何もしない
		If Val(HKKET142F.txtMNFDD.Text) = 0 And Val(HKKET142F.txtPRCCD.Text) = 0 Then
			Get_LTKIKAN = True
			GoTo EXIT_STEP
		End If
		'// 2007/03/10 ↑ ADD
		
		i = 0
		Do 
			If musrHKKZTRA.strDSPMONTH(i) >= Mid(gvstrUNYDT, 1, 6) Then
				
				'// 2007/12/20 ↓ LT基準日は翌月１日固定
				'        If Trim(musrHKKTRA.strLMAPDT(i)) = "" Then
				'            musrHKKTRA.strLMAPDT(i) = musrHKKZTRA.strDSPMONTH(i) & "01"
				'        End If
				If Mid(musrHKKZTRA.strDSPMONTH(i), 5, 2) = "12" Then
					musrHKKTRA.strLMAPDT(i) = CDbl(musrHKKZTRA.strDSPMONTH(i)) + 89 & "01" '12月→翌年1月
				Else
					musrHKKTRA.strLMAPDT(i) = CDbl(musrHKKZTRA.strDSPMONTH(i)) + 1 & "01"
				End If
				'// 2007/12/20 ↓ LT基準日は翌月１日固定
				
				'//SQL文の作成
				strSQL = ""
				strSQL = strSQL & "SELECT SLSMDD  " & vbCrLf
				strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
				'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "WHERE  CLDDT = " & D0.Edt_SQL("S", musrHKKTRA.strLMAPDT(i)) & vbCrLf
				
				'//データ取得
				'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

				'//遡り日数算出(製造LT)
				If Val(HKKET142F.txtMNFDD.Text) - 1 < 0 Then
					'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/15 CHG START
                    'dblSLSMDD = D0.Chk_NullN(objRec("SLSMDD"))
                    dblSLSMDD = D0.Chk_NullN(dt.Rows(0)("SLSMDD"))
                    '2019/04/15 CHG E N D
                Else
                    'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/15 CHG START
                    'dblSLSMDD = D0.Chk_NullN(objRec("SLSMDD")) - (Val(HKKET142F.txtMNFDD.Text) * 5 - 1)
                    dblSLSMDD = D0.Chk_NullN(dt.Rows(0)("SLSMDD")) - (Val(HKKET142F.txtMNFDD.Text) * 5 - 1)
                    '2019/04/15 CHG E N D
                End If
				
				'//SQL文の作成
				strSQL = ""
				strSQL = strSQL & "SELECT CLDDT  " & vbCrLf
				strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
				'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("N", dblSLSMDD) & vbCrLf
				strSQL = strSQL & " ORDER BY CLDWKKB DESC "
				
				'//データ取得
				'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

				'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'If D0.Chk_Null(objRec("CLDDT")) < gvstrUNYDT Then
                If D0.Chk_Null(dt.Rows(0)("CLDDT")) < gvstrUNYDT Then
                    musrHKKTRA.intLTKBN(i) = 1
                Else

                    '//遡り日数算出(調達LT)
                    If Val(HKKET142F.txtPRCCD.Text) - 1 < 0 Then
                        dblSLSMDD = dblSLSMDD
                    Else
                        dblSLSMDD = dblSLSMDD - (Val(HKKET142F.txtPRCCD.Text) * 5 - 1)
                    End If

                    '//SQL文の作成
                    strSQL = ""
                    strSQL = strSQL & "SELECT CLDDT  " & vbCrLf
                    strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
                    'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("N", dblSLSMDD) & vbCrLf
                    strSQL = strSQL & " ORDER BY CLDWKKB DESC "

                    '//データ取得
                    'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/15 CHG START
                    'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
                    '    GoTo EXIT_STEP
                    'End If
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/04/15 CHG E N D

                    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/15 CHG START
                    'If D0.Chk_Null(objRec("CLDDT")) < gvstrUNYDT Then
                    If D0.Chk_Null(dt.Rows(0)("CLDDT")) < gvstrUNYDT Then
                        '2019/04/15 CHG E N D
                        musrHKKTRA.intLTKBN(i) = 2
                    End If

                End If

                '// 2007/02/12 ↓ ADD STR
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If musrHKKTRA.intLTKBN(i) = 0 Then
                        musrHKKTRA.intLTKBN(i) = 1
                    End If
                End If
                '// 2007/02/12 ↑ ADD END

                '// 2008/05/21 ↓ ADD STR
                '// 製造LT・調達LT期間でない月が発生したので以降の月は処理しない
                If musrHKKTRA.intLTKBN(i) = 0 Then
                    Exit Do
                End If
                '// 2008/05/21 ↑ ADD END

            End If

            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop
		
		'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

		Get_LTKIKAN = True
		
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
	'// 2007/01/09 ↑ ADD END
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_HINMTA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    商品マスタを取得する
	'//*****************************************************************************************
	Public Function Get_HINMTA() As Boolean
		
		Const PROCEDURE As String = "Get_HINMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objRec As OraDynaset
		
		Get_HINMTA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT *  " & vbCrLf
		strSQL = strSQL & "FROM   HINMTA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
		
		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//商品マスタより画面に表示する
        '2019/04/15 CHG START
        'If Not Set_HINMTA(objRec) Then
        If Not Set_HINMTA(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HINMTA = True

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
	'//*    Get_CLDMTA
	'//*
	'//* <戻り値>   型                  説明
	'//*            String              取得値
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            Index               Integer          I
	'//*
	'//* <説  明>
	'//*    カレンダマスタを取得する
	'//*****************************************************************************************
	Public Function Get_CLDMTA(ByRef Index As Short) As String
		
		Const PROCEDURE As String = "Get_CLDMTA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRec As OraDynaset
        '2019/04/15 DEL E N D

		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		If Index = 1 Then
			strSQL = strSQL & "SELECT SLSMDD" & vbCrLf
			strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "WHERE  CLDDT = " & D0.Edt_SQL("S", gvstrUNYDT) & vbCrLf
		Else
			strSQL = strSQL & "SELECT NVL(TRIM(TO_CHAR(TO_DATE(MIN(CLDDT),'YYYY/MM/DD'),'YYYY/MM/DD')),'" & VB6.Format(gvstrUNYDT, "@@@@/@@/@@") & "')" & vbCrLf
			strSQL = strSQL & "FROM   CLDMTA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "WHERE  SLSMDD = " & D0.Edt_SQL("S", gvstrCalcDate) & vbCrLf
		End If
		
		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15 CHG START
            'Get_CLDMTA = D0.Chk_Null(objRec(0))
            Get_CLDMTA = D0.Chk_Null(dt.Rows(0)(0))
            '2019/04/15 CHG E N D
        End If

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
	'//*    Get_HKKZTRA_M
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    販売計画前日Ｆを取得する
	'//*****************************************************************************************
	Public Function Get_HKKZTRA_M() As Boolean
		
		Const PROCEDURE As String = "Get_HKKZTRA_M"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objRec As OraDynaset
		Dim i As Short
		Dim j As Short
		
		Get_HKKZTRA_M = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT HINKTA, HINNMB, ZAIRNK,TOUZAISU ,MINSODSU ,SODADDSU ,ANZZAISU ,PRCDD, MNFDD ,LMAAVTS ,HINCM ,MEMO" & vbCrLf
		strSQL = strSQL & "FROM   HKKZTRA " & vbCrLf
		strSQL = strSQL & ",      HKKZTRB " & vbCrLf
		strSQL = strSQL & "WHERE HKKZTRA.HINCD = HKKZTRB.HINCD "
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & "  AND HKKZTRA.HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "  AND HKKZTRA.HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//販売計画前日Ｆより画面に表示する
        '2019/04/15 CHG START
        'If Not Set_HKKZTRA_M(objRec) Then
        If Not Set_HKKZTRA_M(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKKZTRA_M = True

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
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRecA As OraDynaset
        '2019/04/15 DEL E N D
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRecB As OraDynaset
        '2019/04/15 DEL E N D
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/15 DEL START
        'Dim objRecC As OraDynaset
        '2019/04/15 DEL E N D
        Dim i As Short
		Dim j As Short
		
		Get_HKKZTRA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//前年表示年月(0～11)
		strSQL = strSQL & "  LMZYMA, LMZYMB, LMZYMC, LMZYMD, LMZYME, LMZYMF, LMZYMG, LMZYMH, LMZYMI, LMZYMJ, LMZYMK, LMZYML" & vbCrLf
		'//当年表示年月(11～23)
		strSQL = strSQL & ", LMAYMA, LMAYMB, LMAYMC, LMAYMD, LMAYME, LMAYMF, LMAYMG, LMAYMH, LMAYMI, LMAYMJ, LMAYMK, LMAYML" & vbCrLf
		'//翌年表示年月(24～35)
		strSQL = strSQL & ", LMBYMA, LMBYMB, LMBYMC, LMBYMD, LMBYME, LMBYMF, LMBYMG, LMBYMH, LMBYMI, LMBYMJ, LMBYMK, LMBYML" & vbCrLf
		'//前年入庫予定数(36～47)
		strSQL = strSQL & ", LMZNKYSA, LMZNKYSB, LMZNKYSC, LMZNKYSD, LMZNKYSE, LMZNKYSF, LMZNKYSG, LMZNKYSH, LMZNKYSI, LMZNKYSJ, LMZNKYSK, LMZNKYSL" & vbCrLf
		'//当年入庫予定数(48～59)
		strSQL = strSQL & ", LMANKYSA, LMANKYSB, LMANKYSC, LMANKYSD, LMANKYSE, LMANKYSF, LMANKYSG, LMANKYSH, LMANKYSI, LMANKYSJ, LMANKYSK, LMANKYSL" & vbCrLf
		'//翌年入庫予定数(60～71)
		strSQL = strSQL & ", LMBNKYSA, LMBNKYSB, LMBNKYSC, LMBNKYSD, LMBNKYSE, LMBNKYSF, LMBNKYSG, LMBNKYSH, LMBNKYSI, LMBNKYSJ, LMBNKYSK, LMBNKYSL" & vbCrLf
		'//前年出庫予定数(72～83)
		strSQL = strSQL & ", LMZSKYSA, LMZSKYSB, LMZSKYSC, LMZSKYSD, LMZSKYSE, LMZSKYSF, LMZSKYSG, LMZSKYSH, LMZSKYSI, LMZSKYSJ, LMZSKYSK, LMZSKYSL" & vbCrLf
		'//当年出庫予定数(84～95)
		strSQL = strSQL & ", LMASKYSA, LMASKYSB, LMASKYSC, LMASKYSD, LMASKYSE, LMASKYSF, LMASKYSG, LMASKYSH, LMASKYSI, LMASKYSJ, LMASKYSK, LMASKYSL" & vbCrLf
		'//翌年出庫予定数(96～107)
		strSQL = strSQL & ", LMBSKYSA, LMBSKYSB, LMBSKYSC, LMBSKYSD, LMBSKYSE, LMBSKYSF, LMBSKYSG, LMBSKYSH, LMBSKYSI, LMBSKYSJ, LMBSKYSK, LMBSKYSL" & vbCrLf
		'//前年発注限界日(108～119)
		strSQL = strSQL & ", LMZLDTA, LMZLDTB, LMZLDTC, LMZLDTD, LMZLDTE, LMZLDTF, LMZLDTG, LMZLDTH, LMZLDTI, LMZLDTJ, LMZLDTK, LMZLDTL" & vbCrLf
		'//当年発注限界日(120～131)
		strSQL = strSQL & ", LMALDTA, LMALDTB, LMALDTC, LMALDTD, LMALDTE, LMALDTF, LMALDTG, LMALDTH, LMALDTI, LMALDTJ, LMALDTK, LMALDTL" & vbCrLf
		'//翌年発注限界日(132～143)
		strSQL = strSQL & ", LMBLDTA, LMBLDTB, LMBLDTC, LMBLDTD, LMBLDTE, LMBLDTF, LMBLDTG, LMBLDTH, LMBLDTI, LMBLDTJ, LMBLDTK, LMBLDTL" & vbCrLf
		'//前年支給品出庫数(144～155)
		strSQL = strSQL & ", LMZSKSSA, LMZSKSSB, LMZSKSSC, LMZSKSSD, LMZSKSSE, LMZSKSSF, LMZSKSSG, LMZSKSSH, LMZSKSSI, LMZSKSSJ, LMZSKSSK, LMZSKSSL" & vbCrLf
		'//当年支給品出庫数(156～167)
		strSQL = strSQL & ", LMASKSSA, LMASKSSB, LMASKSSC, LMASKSSD, LMASKSSE, LMASKSSF, LMASKSSG, LMASKSSH, LMASKSSI, LMASKSSJ, LMASKSSK, LMASKSSL" & vbCrLf
		'//翌年支給品出庫数(168～179)
		strSQL = strSQL & ", LMBSKSSA, LMBSKSSB, LMBSKSSC, LMBSKSSD, LMBSKSSE, LMBSKSSF, LMBSKSSG, LMBSKSSH, LMBSKSSI, LMBSKSSJ, LMBSKSSK, LMBSKSSL" & vbCrLf
		'//前年緊急発注済数(180～191)
		strSQL = strSQL & ", LMZKODSA, LMZKODSB, LMZKODSC, LMZKODSD, LMZKODSE, LMZKODSF, LMZKODSG, LMZKODSH, LMZKODSI, LMZKODSJ, LMZKODSK, LMZKODSL" & vbCrLf
		'//当年緊急発注済数(192～203)
		strSQL = strSQL & ", LMAKODSA, LMAKODSB, LMAKODSC, LMAKODSD, LMAKODSE, LMAKODSF, LMAKODSG, LMAKODSH, LMAKODSI, LMAKODSJ, LMAKODSK, LMAKODSL" & vbCrLf
		'//翌年緊急発注済数(204～215)
		strSQL = strSQL & ", LMBKODSA, LMBKODSB, LMBKODSC, LMBKODSD, LMBKODSE, LMBKODSF, LMBKODSG, LMBKODSH, LMBKODSI, LMBKODSJ, LMBKODSK, LMBKODSL" & vbCrLf
		'//前年入庫指示済数(216～227)
		strSQL = strSQL & ", LMZNOSSA, LMZNOSSB, LMZNOSSC, LMZNOSSD, LMZNOSSE, LMZNOSSF, LMZNOSSG, LMZNOSSH, LMZNOSSI, LMZNOSSJ, LMZNOSSK, LMZNOSSL" & vbCrLf
		'//当年入庫指示済数(228～239)
		strSQL = strSQL & ", LMANOSSA, LMANOSSB, LMANOSSC, LMANOSSD, LMANOSSE, LMANOSSF, LMANOSSG, LMANOSSH, LMANOSSI, LMANOSSJ, LMANOSSK, LMANOSSL" & vbCrLf
		'//翌年入庫指示済数(240～251)
		strSQL = strSQL & ", LMBNOSSA, LMBNOSSB, LMBNOSSC, LMBNOSSD, LMBNOSSE, LMBNOSSF, LMBNOSSG, LMBNOSSH, LMBNOSSI, LMBNOSSJ, LMBNOSSK, LMBNOSSL" & vbCrLf
		'//前年発注済数(252～263)
		strSQL = strSQL & ", LMZODSSA, LMZODSSB, LMZODSSC, LMZODSSD, LMZODSSE, LMZODSSF, LMZODSSG, LMZODSSH, LMZODSSI, LMZODSSJ, LMZODSSK, LMZODSSL" & vbCrLf
		'//当年発注済数(264～275)
		strSQL = strSQL & ", LMAODSSA, LMAODSSB, LMAODSSC, LMAODSSD, LMAODSSE, LMAODSSF, LMAODSSG, LMAODSSH, LMAODSSI, LMAODSSJ, LMAODSSK, LMAODSSL" & vbCrLf
		'//翌年発注済数(276～287)
		strSQL = strSQL & ", LMBODSSA, LMBODSSB, LMBODSSC, LMBODSSD, LMBODSSE, LMBODSSF, LMBODSSG, LMBODSSH, LMBODSSI, LMBODSSJ, LMBODSSK, LMBODSSL" & vbCrLf
		'//前年受注数(288～299)
		strSQL = strSQL & ", LMZJYSA, LMZJYSB, LMZJYSC, LMZJYSD, LMZJYSE, LMZJYSF, LMZJYSG, LMZJYSH, LMZJYSI, LMZJYSJ, LMZJYSK, LMZJYSL" & vbCrLf
		'//当年受注数(300～311)
		strSQL = strSQL & ", LMAJYSA, LMAJYSB, LMAJYSC, LMAJYSD, LMAJYSE, LMAJYSF, LMAJYSG, LMAJYSH, LMAJYSI, LMAJYSJ, LMAJYSK, LMAJYSL" & vbCrLf
		'//翌年受注数(312～323)
		strSQL = strSQL & ", LMBJYSA, LMBJYSB, LMBJYSC, LMBJYSD, LMBJYSE, LMBJYSF, LMBJYSG, LMBJYSH, LMBJYSI, LMBJYSJ, LMBJYSK, LMBJYSL" & vbCrLf
		'//前年売上数(324～335)
		strSQL = strSQL & ", LMZURSA, LMZURSB, LMZURSC, LMZURSD, LMZURSE, LMZURSF, LMZURSG, LMZURSH, LMZURSI, LMZURSJ, LMZURSK, LMZURSL" & vbCrLf
		'//当年売上数(336～347)
		strSQL = strSQL & ", LMAURSA, LMAURSB, LMAURSC, LMAURSD, LMAURSE, LMAURSF, LMAURSG, LMAURSH, LMAURSI, LMAURSJ, LMAURSK, LMAURSL" & vbCrLf
		'//翌年売上数(348～359)
		strSQL = strSQL & ", LMBURSA, LMBURSB, LMBURSC, LMBURSD, LMBURSE, LMBURSF, LMBURSG, LMBURSH, LMBURSI, LMBURSJ, LMBURSK, LMBURSL" & vbCrLf
		'//前年入庫実績数(360～371)
		strSQL = strSQL & ", LMZNKJSA, LMZNKJSB, LMZNKJSC, LMZNKJSD, LMZNKJSE, LMZNKJSF, LMZNKJSG, LMZNKJSH, LMZNKJSI, LMZNKJSJ, LMZNKJSK, LMZNKJSL" & vbCrLf
		'//当年入庫実績数(372～383)
		strSQL = strSQL & ", LMANKJSA, LMANKJSB, LMANKJSC, LMANKJSD, LMANKJSE, LMANKJSF, LMANKJSG, LMANKJSH, LMANKJSI, LMANKJSJ, LMANKJSK, LMANKJSL" & vbCrLf
		'//翌年入庫実績数(384～395)
		strSQL = strSQL & ", LMBNKJSA, LMBNKJSB, LMBNKJSC, LMBNKJSD, LMBNKJSE, LMBNKJSF, LMBNKJSG, LMBNKJSH, LMBNKJSI, LMBNKJSJ, LMBNKJSK, LMBNKJSL" & vbCrLf
		'//前年出庫実績数(396～407)
		strSQL = strSQL & ", LMZSKJSA, LMZSKJSB, LMZSKJSC, LMZSKJSD, LMZSKJSE, LMZSKJSF, LMZSKJSG, LMZSKJSH, LMZSKJSI, LMZSKJSJ, LMZSKJSK, LMZSKJSL" & vbCrLf
		'//当年出庫実績数(408～419)
		strSQL = strSQL & ", LMASKJSA, LMASKJSB, LMASKJSC, LMASKJSD, LMASKJSE, LMASKJSF, LMASKJSG, LMASKJSH, LMASKJSI, LMASKJSJ, LMASKJSK, LMASKJSL" & vbCrLf
		'//翌年出庫実績数(420～431)
		strSQL = strSQL & ", LMBSKJSA, LMBSKJSB, LMBSKJSC, LMBSKJSD, LMBSKJSE, LMBSKJSF, LMBSKJSG, LMBSKJSH, LMBSKJSI, LMBSKJSJ, LMBSKJSK, LMBSKJSL" & vbCrLf
		'//前年発注実績数(432～443)
		strSQL = strSQL & ", LMZODJSA, LMZODJSB, LMZODJSC, LMZODJSD, LMZODJSE, LMZODJSF, LMZODJSG, LMZODJSH, LMZODJSI, LMZODJSJ, LMZODJSK, LMZODJSL" & vbCrLf
		'//当年発注実績数(444～455)
		strSQL = strSQL & ", LMAODJSA, LMAODJSB, LMAODJSC, LMAODJSD, LMAODJSE, LMAODJSF, LMAODJSG, LMAODJSH, LMAODJSI, LMAODJSJ, LMAODJSK, LMAODJSL" & vbCrLf
		'//翌年発注実績数(456～467)
		strSQL = strSQL & ", LMBODJSA, LMBODJSB, LMBODJSC, LMBODJSD, LMBODJSE, LMBODJSF, LMBODJSG, LMBODJSH, LMBODJSI, LMBODJSJ, LMBODJSK, LMBODJSL" & vbCrLf
		'//前年月末在庫数(468～479)
		strSQL = strSQL & ", LMZZAISA, LMZZAISB, LMZZAISC, LMZZAISD, LMZZAISE, LMZZAISF, LMZZAISG, LMZZAISH, LMZZAISI, LMZZAISJ, LMZZAISK, LMZZAISL" & vbCrLf
		'//当年月末在庫数(480～491)
		strSQL = strSQL & ", LMAZAISA, LMAZAISB, LMAZAISC, LMAZAISD, LMAZAISE, LMAZAISF, LMAZAISG, LMAZAISH, LMAZAISI, LMAZAISJ, LMAZAISK, LMAZAISL" & vbCrLf
		'//翌年月末在庫数(492～503)
		strSQL = strSQL & ", LMBZAISA, LMBZAISB, LMBZAISC, LMBZAISD, LMBZAISE, LMBZAISF, LMBZAISG, LMBZAISH, LMBZAISI, LMBZAISJ, LMBZAISK, LMBZAISL" & vbCrLf
		'//前年見込月末在庫数(504～515)
		strSQL = strSQL & ", LMZMKZSA, LMZMKZSB, LMZMKZSC, LMZMKZSD, LMZMKZSE, LMZMKZSF, LMZMKZSG, LMZMKZSH, LMZMKZSI, LMZMKZSJ, LMZMKZSK, LMZMKZSL" & vbCrLf
		'//当年見込月末在庫数(516～527)
		strSQL = strSQL & ", LMAMKZSA, LMAMKZSB, LMAMKZSC, LMAMKZSD, LMAMKZSE, LMAMKZSF, LMAMKZSG, LMAMKZSH, LMAMKZSI, LMAMKZSJ, LMAMKZSK, LMAMKZSL" & vbCrLf
		'//翌年見込月末在庫数(528～539)
		strSQL = strSQL & ", LMBMKZSA, LMBMKZSB, LMBMKZSC, LMBMKZSD, LMBMKZSE, LMBMKZSF, LMBMKZSG, LMBMKZSH, LMBMKZSI, LMBMKZSJ, LMBMKZSK, LMBMKZSL" & vbCrLf
		'//前年見込見積数(540～551)
		strSQL = strSQL & ", LMZMMSA, LMZMMSB, LMZMMSC, LMZMMSD, LMZMMSE, LMZMMSF, LMZMMSG, LMZMMSH, LMZMMSI, LMZMMSJ, LMZMMSK, LMZMMSL" & vbCrLf
		'//当年見込見積数(552～563)
		strSQL = strSQL & ", LMAMMSA, LMAMMSB, LMAMMSC, LMAMMSD, LMAMMSE, LMAMMSF, LMAMMSG, LMAMMSH, LMAMMSI, LMAMMSJ, LMAMMSK, LMAMMSL" & vbCrLf
		'//翌年見込見積数(564～575)
		strSQL = strSQL & ", LMBMMSA, LMBMMSB, LMBMMSC, LMBMMSD, LMBMMSE, LMBMMSF, LMBMMSG, LMBMMSH, LMBMMSI, LMBMMSJ, LMBMMSK, LMBMMSL" & vbCrLf
		'//前年見込出庫予定数(576～587)
		strSQL = strSQL & ", LMZMSSA, LMZMSSB, LMZMSSC, LMZMSSD, LMZMSSE, LMZMSSF, LMZMSSG, LMZMSSH, LMZMSSI, LMZMSSJ, LMZMSSK, LMZMSSL" & vbCrLf
		'//当年見込出庫予定数(588～599)
		strSQL = strSQL & ", LMAMSSA, LMAMSSB, LMAMSSC, LMAMSSD, LMAMSSE, LMAMSSF, LMAMSSG, LMAMSSH, LMAMSSI, LMAMSSJ, LMAMSSK, LMAMSSL" & vbCrLf
		'//翌年見込出庫予定数(600～611)
		strSQL = strSQL & ", LMBMSSA, LMBMSSB, LMBMSSC, LMBMSSD, LMBMSSE, LMBMSSF, LMBMSSG, LMBMSSH, LMBMSSI, LMBMSSJ, LMBMSSK, LMBMSSL" & vbCrLf
		'//前年出庫予定計画数(612～623)
		strSQL = strSQL & ", LMZSKKSA, LMZSKKSB, LMZSKKSC, LMZSKKSD, LMZSKKSE, LMZSKKSF, LMZSKKSG, LMZSKKSH, LMZSKKSI, LMZSKKSJ, LMZSKKSK, LMZSKKSL" & vbCrLf
		'//当年出庫予定計画数(624～635)
		strSQL = strSQL & ", LMASKKSA, LMASKKSB, LMASKKSC, LMASKKSD, LMASKKSE, LMASKKSF, LMASKKSG, LMASKKSH, LMASKKSI, LMASKKSJ, LMASKKSK, LMASKKSL" & vbCrLf
		'//翌年出庫予定計画数(636～647)
		strSQL = strSQL & ", LMBSKKSA, LMBSKKSB, LMBSKKSC, LMBSKKSD, LMBSKKSE, LMBSKKSF, LMBSKKSG, LMBSKKSH, LMBSKKSI, LMBSKKSJ, LMBSKKSK, LMBSKKSL" & vbCrLf
		strSQL = strSQL & "FROM   HKKZTRA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecA, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtHKKZTRA As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//前年在庫切れマーク(0～11)
		strSQL = strSQL & "  LMZZKMA, LMZZKMB, LMZZKMC, LMZZKMD, LMZZKME, LMZZKMF, LMZZKMG, LMZZKMH, LMZZKMI, LMZZKMJ, LMZZKMK, LMZZKML" & vbCrLf
		'//当年在庫切れマーク(12～23)
		strSQL = strSQL & ", LMAZKMA, LMAZKMB, LMAZKMC, LMAZKMD, LMAZKME, LMAZKMF, LMAZKMG, LMAZKMH, LMAZKMI, LMAZKMJ, LMAZKMK, LMAZKML" & vbCrLf
		'//翌年在庫切れマーク(24～35)
		strSQL = strSQL & ", LMBZKMA, LMBZKMB, LMBZKMC, LMBZKMD, LMBZKME, LMBZKMF, LMBZKMG, LMBZKMH, LMBZKMI, LMBZKMJ, LMBZKMK, LMBZKML" & vbCrLf
		'//前年安全在庫切れマーク(36～47)
		strSQL = strSQL & ", LMZAZMA, LMZAZMB, LMZAZMC, LMZAZMD, LMZAZME, LMZAZMF, LMZAZMG, LMZAZMH, LMZAZMI, LMZAZMJ, LMZAZMK, LMZAZML" & vbCrLf
		'//当年安全在庫切れマーク(48～59)
		strSQL = strSQL & ", LMAAZMA, LMAAZMB, LMAAZMC, LMAAZMD, LMAAZME, LMAAZMF, LMAAZMG, LMAAZMH, LMAAZMI, LMAAZMJ, LMAAZMK, LMAAZML" & vbCrLf
		'//翌年安全在庫切れマーク(60～71)
		strSQL = strSQL & ", LMBAZMA, LMBAZMB, LMBAZMC, LMBAZMD, LMBAZME, LMBAZMF, LMBAZMG, LMBAZMH, LMBAZMI, LMBAZMJ, LMBAZMK, LMBAZML" & vbCrLf
		'//前年見込在庫切れマーク(72～83)
		strSQL = strSQL & ", LMZMZKMA, LMZMZKMB, LMZMZKMC, LMZMZKMD, LMZMZKME, LMZMZKMF, LMZMZKMG, LMZMZKMH, LMZMZKMI, LMZMZKMJ, LMZMZKMK, LMZMZKML" & vbCrLf
		'//当年見込在庫切れマーク(84～95)
		strSQL = strSQL & ", LMAMZKMA, LMAMZKMB, LMAMZKMC, LMAMZKMD, LMAMZKME, LMAMZKMF, LMAMZKMG, LMAMZKMH, LMAMZKMI, LMAMZKMJ, LMAMZKMK, LMAMZKML" & vbCrLf
		'//翌年見込在庫切れマーク(96～107)
		strSQL = strSQL & ", LMBMZKMA, LMBMZKMB, LMBMZKMC, LMBMZKMD, LMBMZKME, LMBMZKMF, LMBMZKMG, LMBMZKMH, LMBMZKMI, LMBMZKMJ, LMBMZKMK, LMBMZKML" & vbCrLf
		'//前年見込安全在庫切れマーク(108～119)
		strSQL = strSQL & ", LMZMAZMA, LMZMAZMB, LMZMAZMC, LMZMAZMD, LMZMAZME, LMZMAZMF, LMZMAZMG, LMZMAZMH, LMZMAZMI, LMZMAZMJ, LMZMAZMK, LMZMAZML" & vbCrLf
		'//当年見込安全在庫切れマーク(120～131)
		strSQL = strSQL & ", LMAMAZMA, LMAMAZMB, LMAMAZMC, LMAMAZMD, LMAMAZME, LMAMAZMF, LMAMAZMG, LMAMAZMH, LMAMAZMI, LMAMAZMJ, LMAMAZMK, LMAMAZML" & vbCrLf
		'//翌年見込安全在庫切れマーク(132～143)
		strSQL = strSQL & ", LMBMAZMA, LMBMAZMB, LMBMAZMC, LMBMAZMD, LMBMAZME, LMBMAZMF, LMBMAZMG, LMBMAZMH, LMBMAZMI, LMBMAZMJ, LMBMAZMK, LMBMAZML" & vbCrLf
		'//前年在庫切れ数(144～155)
		strSQL = strSQL & ", LMZZKSA, LMZZKSB, LMZZKSC, LMZZKSD, LMZZKSE, LMZZKSF, LMZZKSG, LMZZKSH, LMZZKSI, LMZZKSJ, LMZZKSK, LMZZKSL" & vbCrLf
		'//当年在庫切れ数(156～167)
		strSQL = strSQL & ", LMAZKSA, LMAZKSB, LMAZKSC, LMAZKSD, LMAZKSE, LMAZKSF, LMAZKSG, LMAZKSH, LMAZKSI, LMAZKSJ, LMAZKSK, LMAZKSL" & vbCrLf
		'//翌年在庫切れ数(168～179)
		strSQL = strSQL & ", LMBZKSA, LMBZKSB, LMBZKSC, LMBZKSD, LMBZKSE, LMBZKSF, LMBZKSG, LMBZKSH, LMBZKSI, LMBZKSJ, LMBZKSK, LMBZKSL" & vbCrLf
		'//前年安全在庫切れ数(180～191)
		strSQL = strSQL & ", LMZAZSA, LMZAZSB, LMZAZSC, LMZAZSD, LMZAZSE, LMZAZSF, LMZAZSG, LMZAZSH, LMZAZSI, LMZAZSJ, LMZAZSK, LMZAZSL" & vbCrLf
		'//当年安全在庫切れ数(192～203)
		strSQL = strSQL & ", LMAAZSA, LMAAZSB, LMAAZSC, LMAAZSD, LMAAZSE, LMAAZSF, LMAAZSG, LMAAZSH, LMAAZSI, LMAAZSJ, LMAAZSK, LMAAZSL" & vbCrLf
		'//翌年安全在庫切れ数(204～215)
		strSQL = strSQL & ", LMBAZSA, LMBAZSB, LMBAZSC, LMBAZSD, LMBAZSE, LMBAZSF, LMBAZSG, LMBAZSH, LMBAZSI, LMBAZSJ, LMBAZSK, LMBAZSL" & vbCrLf
		'//前年見込在庫切れ数(216～227)
		strSQL = strSQL & ", LMZMZKSA, LMZMZKSB, LMZMZKSC, LMZMZKSD, LMZMZKSE, LMZMZKSF, LMZMZKSG, LMZMZKSH, LMZMZKSI, LMZMZKSJ, LMZMZKSK, LMZMZKSL" & vbCrLf
		'//当年見込在庫切れ数(228～239)
		strSQL = strSQL & ", LMAMZKSA, LMAMZKSB, LMAMZKSC, LMAMZKSD, LMAMZKSE, LMAMZKSF, LMAMZKSG, LMAMZKSH, LMAMZKSI, LMAMZKSJ, LMAMZKSK, LMAMZKSL" & vbCrLf
		'//翌年見込在庫切れ数(240～251)
		strSQL = strSQL & ", LMBMZKSA, LMBMZKSB, LMBMZKSC, LMBMZKSD, LMBMZKSE, LMBMZKSF, LMBMZKSG, LMBMZKSH, LMBMZKSI, LMBMZKSJ, LMBMZKSK, LMBMZKSL" & vbCrLf
		'//前年見込安全在庫切れ数(252～263)
		strSQL = strSQL & ", LMZMAZSA, LMZMAZSB, LMZMAZSC, LMZMAZSD, LMZMAZSE, LMZMAZSF, LMZMAZSG, LMZMAZSH, LMZMAZSI, LMZMAZSJ, LMZMAZSK, LMZMAZSL" & vbCrLf
		'//当年見込安全在庫切れ数(264～275)
		strSQL = strSQL & ", LMAMAZSA, LMAMAZSB, LMAMAZSC, LMAMAZSD, LMAMAZSE, LMAMAZSF, LMAMAZSG, LMAMAZSH, LMAMAZSI, LMAMAZSJ, LMAMAZSK, LMAMAZSL" & vbCrLf
		'//翌年見込安全在庫切れ数(276～287)
		strSQL = strSQL & ", LMBMAZSA, LMBMAZSB, LMBMAZSC, LMBMAZSD, LMBMAZSE, LMBMAZSF, LMBMAZSG, LMBMAZSH, LMBMAZSI, LMBMAZSJ, LMBMAZSK, LMBMAZSL" & vbCrLf
		'//前年発注日(288～299)
		strSQL = strSQL & ", LMZHDTA, LMZHDTB, LMZHDTC, LMZHDTD, LMZHDTE, LMZHDTF, LMZHDTG, LMZHDTH, LMZHDTI, LMZHDTJ, LMZHDTK, LMZHDTL" & vbCrLf
		'//当年発注日(300～311)
		strSQL = strSQL & ", LMAHDTA, LMAHDTB, LMAHDTC, LMAHDTD, LMAHDTE, LMAHDTF, LMAHDTG, LMAHDTH, LMAHDTI, LMAHDTJ, LMAHDTK, LMAHDTL" & vbCrLf
		'//翌年発注日(312～323)
		strSQL = strSQL & ", LMBHDTA, LMBHDTB, LMBHDTC, LMBHDTD, LMBHDTE, LMBHDTF, LMBHDTG, LMBHDTH, LMBHDTI, LMBHDTJ, LMBHDTK, LMBHDTL" & vbCrLf
		'//前年在庫月数(324～335)
		strSQL = strSQL & ", LMZZKTA, LMZZKTB, LMZZKTC, LMZZKTD, LMZZKTE, LMZZKTF, LMZZKTG, LMZZKTH, LMZZKTI, LMZZKTJ, LMZZKTK, LMZZKTL" & vbCrLf
		'//当年在庫月数(336～347)
		strSQL = strSQL & ", LMAZKTA, LMAZKTB, LMAZKTC, LMAZKTD, LMAZKTE, LMAZKTF, LMAZKTG, LMAZKTH, LMAZKTI, LMAZKTJ, LMAZKTK, LMAZKTL" & vbCrLf
		'//翌年在庫月数(348～359)
		strSQL = strSQL & ", LMBZKTA, LMBZKTB, LMBZKTC, LMBZKTD, LMBZKTE, LMBZKTF, LMBZKTG, LMBZKTH, LMBZKTI, LMBZKTJ, LMBZKTK, LMBZKTL" & vbCrLf
		'//前年見込在庫月数(360～371)
		strSQL = strSQL & ", LMZMZKTA, LMZMZKTB, LMZMZKTC, LMZMZKTD, LMZMZKTE, LMZMZKTF, LMZMZKTG, LMZMZKTH, LMZMZKTI, LMZMZKTJ, LMZMZKTK, LMZMZKTL" & vbCrLf
		'//当年見込在庫月数(372～383)
		strSQL = strSQL & ", LMAMZKTA, LMAMZKTB, LMAMZKTC, LMAMZKTD, LMAMZKTE, LMAMZKTF, LMAMZKTG, LMAMZKTH, LMAMZKTI, LMAMZKTJ, LMAMZKTK, LMAMZKTL" & vbCrLf
		'//翌年見込在庫月数(384～395)
		strSQL = strSQL & ", LMBMZKTA, LMBMZKTB, LMBMZKTC, LMBMZKTD, LMBMZKTE, LMBMZKTF, LMBMZKTG, LMBMZKTH, LMBMZKTI, LMBMZKTJ, LMBMZKTK, LMBMZKTL" & vbCrLf
		'//前年平均出庫数(前月)(396～407)
		strSQL = strSQL & ", LMZAVZSA, LMZAVZSB, LMZAVZSC, LMZAVZSD, LMZAVZSE, LMZAVZSF, LMZAVZSG, LMZAVZSH, LMZAVZSI, LMZAVZSJ, LMZAVZSK, LMZAVZSL" & vbCrLf
		'//当年平均出庫数(前月)(408～419)
		strSQL = strSQL & ", LMAAVZSA, LMAAVZSB, LMAAVZSC, LMAAVZSD, LMAAVZSE, LMAAVZSF, LMAAVZSG, LMAAVZSH, LMAAVZSI, LMAAVZSJ, LMAAVZSK, LMAAVZSL" & vbCrLf
		'//翌年平均出庫数(前月)(420～431)
		strSQL = strSQL & ", LMBAVZSA, LMBAVZSB, LMBAVZSC, LMBAVZSD, LMBAVZSE, LMBAVZSF, LMBAVZSG, LMBAVZSH, LMBAVZSI, LMBAVZSJ, LMBAVZSK, LMBAVZSL" & vbCrLf
		'//前年見込案件数(432～443)
		strSQL = strSQL & ", LMZMASA, LMZMASB, LMZMASC, LMZMASD, LMZMASE, LMZMASF, LMZMASG, LMZMASH, LMZMASI, LMZMASJ, LMZMASK, LMZMASL" & vbCrLf
		'//当年見込案件数(444～455)
		strSQL = strSQL & ", LMAMASA, LMAMASB, LMAMASC, LMAMASD, LMAMASE, LMAMASF, LMAMASG, LMAMASH, LMAMASI, LMAMASJ, LMAMASK, LMAMASL" & vbCrLf
		'//翌年見込案件数(456～467)
		strSQL = strSQL & ", LMBMASA, LMBMASB, LMBMASC, LMBMASD, LMBMASE, LMBMASF, LMBMASG, LMBMASH, LMBMASI, LMBMASJ, LMBMASK, LMBMASL" & vbCrLf
		'//前年見込出庫予定数(468～479)
		strSQL = strSQL & ", LMZMASSA, LMZMASSB, LMZMASSC, LMZMASSD, LMZMASSE, LMZMASSF, LMZMASSG, LMZMASSH, LMZMASSI, LMZMASSJ, LMZMASSK, LMZMASSL" & vbCrLf
		'//当年見込出庫予定数(480～491)
		strSQL = strSQL & ", LMAMASSA, LMAMASSB, LMAMASSC, LMAMASSD, LMAMASSE, LMAMASSF, LMAMASSG, LMAMASSH, LMAMASSI, LMAMASSJ, LMAMASSK, LMAMASSL" & vbCrLf
		'//翌年見込出庫予定数(492～503)
		strSQL = strSQL & ", LMBMASSA, LMBMASSB, LMBMASSC, LMBMASSD, LMBMASSE, LMBMASSF, LMBMASSG, LMBMASSH, LMBMASSI, LMBMASSJ, LMBMASSK, LMBMASSL" & vbCrLf
		'// 2007/01/09 ↓ ADD STR
		'//前年予測月末在庫数量(504～515)
		strSQL = strSQL & ", LMZYGZSA, LMZYGZSB, LMZYGZSC, LMZYGZSD, LMZYGZSE, LMZYGZSF, LMZYGZSG, LMZYGZSH, LMZYGZSI, LMZYGZSJ, LMZYGZSK, LMZYGZSL" & vbCrLf
		'//当年予測月末在庫数量(516～527)
		strSQL = strSQL & ", LMAYGZSA, LMAYGZSB, LMAYGZSC, LMAYGZSD, LMAYGZSE, LMAYGZSF, LMAYGZSG, LMAYGZSH, LMAYGZSI, LMAYGZSJ, LMAYGZSK, LMAYGZSL" & vbCrLf
		'//翌年予測月末在庫数量(516～539)
		strSQL = strSQL & ", LMBYGZSA, LMBYGZSB, LMBYGZSC, LMBYGZSD, LMBYGZSE, LMBYGZSF, LMBYGZSG, LMBYGZSH, LMBYGZSI, LMBYGZSJ, LMBYGZSK, LMBYGZSL" & vbCrLf
		'//前年見込予測月末在庫数量(540～551)
		strSQL = strSQL & ", LMZMYGZA, LMZMYGZB, LMZMYGZC, LMZMYGZD, LMZMYGZE, LMZMYGZF, LMZMYGZG, LMZMYGZH, LMZMYGZI, LMZMYGZJ, LMZMYGZK, LMZMYGZL" & vbCrLf
		'//当年見込予測月末在庫数量(552～563)
		strSQL = strSQL & ", LMAMYGZA, LMAMYGZB, LMAMYGZC, LMAMYGZD, LMAMYGZE, LMAMYGZF, LMAMYGZG, LMAMYGZH, LMAMYGZI, LMAMYGZJ, LMAMYGZK, LMAMYGZL" & vbCrLf
		'//翌年見込予測月末在庫数量(564～575)
		strSQL = strSQL & ", LMBMYGZA, LMBMYGZB, LMBMYGZC, LMBMYGZD, LMBMYGZE, LMBMYGZF, LMBMYGZG, LMBMYGZH, LMBMYGZI, LMBMYGZJ, LMBMYGZK, LMBMYGZL" & vbCrLf
		'// 2007/01/09 ↑ ADD END
		strSQL = strSQL & "FROM   HKKZTRB " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecB, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtHKKZTRB As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT " & vbCrLf
		'//前年入庫指示数(0～11)
		strSQL = strSQL & "  LMZNOSA, LMZNOSB, LMZNOSC, LMZNOSD, LMZNOSE, LMZNOSF, LMZNOSG, LMZNOSH, LMZNOSI, LMZNOSJ, LMZNOSK, LMZNOSL "
		'//当年入庫指示数(12～23)
		strSQL = strSQL & ", LMANOSA, LMANOSB, LMANOSC, LMANOSD, LMANOSE, LMANOSF, LMANOSG, LMANOSH, LMANOSI, LMANOSJ, LMANOSK, LMANOSL "
		'//翌年入庫指示数(24～35)
		strSQL = strSQL & ", LMBNOSA, LMBNOSB, LMBNOSC, LMBNOSD, LMBNOSE, LMBNOSF, LMBNOSG, LMBNOSH, LMBNOSI, LMBNOSJ, LMBNOSK, LMBNOSL "
		'//前年入庫計画数(36～47)
		strSQL = strSQL & ", LMZNPSA, LMZNPSB, LMZNPSC, LMZNPSD, LMZNPSE, LMZNPSF, LMZNPSG, LMZNPSH, LMZNPSI, LMZNPSJ, LMZNPSK, LMZNPSL "
		'//当年入庫計画数(48～59)
		strSQL = strSQL & ", LMANPSA, LMANPSB, LMANPSC, LMANPSD, LMANPSE, LMANPSF, LMANPSG, LMANPSH, LMANPSI, LMANPSJ, LMANPSK, LMANPSL "
		'//翌年入庫計画数(60～71)
		strSQL = strSQL & ", LMBNPSA, LMBNPSB, LMBNPSC, LMBNPSD, LMBNPSE, LMBNPSF, LMBNPSG, LMBNPSH, LMBNPSI, LMBNPSJ, LMBNPSK, LMBNPSL "
		'// 2007/01/09 ↓ ADD STR
		'//前年前日入庫計画数(72～83)
		strSQL = strSQL & ", LMZZNPA, LMZZNPB, LMZZNPC, LMZZNPD, LMZZNPE, LMZZNPF, LMZZNPG, LMZZNPH, LMZZNPI, LMZZNPJ, LMZZNPK, LMZZNPL "
		'//当年前日入庫計画数(84～95)
		strSQL = strSQL & ", LMAZNPA, LMAZNPB, LMAZNPC, LMAZNPD, LMAZNPE, LMAZNPF, LMAZNPG, LMAZNPH, LMAZNPI, LMAZNPJ, LMAZNPK, LMAZNPL "
		'//翌年前日入庫計画数(96～107)
		strSQL = strSQL & ", LMBZNPA, LMBZNPB, LMBZNPC, LMBZNPD, LMBZNPE, LMBZNPF, LMBZNPG, LMBZNPH, LMBZNPI, LMBZNPJ, LMBZNPK, LMBZNPL "
		'// 2007/01/09 ↑ ADD END
		'// 2007/02/02 ↓ ADD STR
		'//前年入庫入力計画数量(108～119)
		strSQL = strSQL & ", LMZIPKA, LMZIPKB, LMZIPKC, LMZIPKD, LMZIPKE, LMZIPKF, LMZIPKG, LMZIPKH, LMZIPKI, LMZIPKJ, LMZIPKK, LMZIPKL "
		'//当年入庫入力計画数量(120～131)
		strSQL = strSQL & ", LMAIPKA, LMAIPKB, LMAIPKC, LMAIPKD, LMAIPKE, LMAIPKF, LMAIPKG, LMAIPKH, LMAIPKI, LMAIPKJ, LMAIPKK, LMAIPKL "
		'//翌年入庫入力計画数量(132～143)
		strSQL = strSQL & ", LMBIPKA, LMBIPKB, LMBIPKC, LMBIPKD, LMBIPKE, LMBIPKF, LMBIPKG, LMBIPKH, LMBIPKI, LMBIPKJ, LMBIPKK, LMBIPKL "
		'// 2007/02/02 ↑ ADD END
		'// 2007/02/24 ↓ ADD END
		strSQL = strSQL & ", WRTDT,WRTTM" & vbCrLf '144-145
		'// 2007/02/24 ↑ ADD END
		'// V2.20↓ ADD
		'//前年入庫計画優先ﾌﾗｸﾞ(146～157)
		strSQL = strSQL & ", LMZNPFA, LMZNPFB, LMZNPFC, LMZNPFD, LMZNPFE, LMZNPFF, LMZNPFG, LMZNPFH, LMZNPFI, LMZNPFJ, LMZNPFK, LMZNPFL "
		'//当年入庫計画優先ﾌﾗｸﾞ(158～169)
		strSQL = strSQL & ", LMANPFA, LMANPFB, LMANPFC, LMANPFD, LMANPFE, LMANPFF, LMANPFG, LMANPFH, LMANPFI, LMANPFJ, LMANPFK, LMANPFL "
		'//翌年入庫計画優先ﾌﾗｸﾞ(170～181)
		strSQL = strSQL & ", LMBNPFA, LMBNPFB, LMBNPFC, LMBNPFD, LMBNPFE, LMBNPFF, LMBNPFG, LMBNPFH, LMBNPFI, LMBNPFJ, LMBNPFK, LMBNPFL "
		'// V2.20↑ ADD
		strSQL = strSQL & " FROM   ODINTRA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & " WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & " WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D

		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRecC, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dtODINTRA As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

		'//販売計画前日Ｆより画面に表示する
        If Not Set_HKKZTRA(dtHKKZTRA, dtHKKZTRB, dtODINTRA) Then
            GoTo EXIT_STEP
        End If
		
        '2019/04/15 DEL START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraCloseDyn(objRecA)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraCloseDyn(objRecB)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraCloseDyn(objRecC)
        '2019/04/15 DEL E N D

		Get_HKKZTRA = True
		
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
	'//*
	'//* <説  明>
	'//*    販売計画Ｆを取得する
	'//*****************************************************************************************
	Public Function Get_HKKTRA() As Boolean
        '2019/04/15 DEL START
        'Dim ORADYN_READONLY As Object
        'Dim gvstrOPEID As Object
        '2019/04/15 DEL E N D

		Const PROCEDURE As String = "Get_HKKTRA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objRec As OraDynaset
		
		Get_HKKTRA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & "SELECT * " & vbCrLf
		strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "AND    OPEID = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
		' データ取得
		'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D
        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            gvblnInputFlg = True
        Else
            gvblnInputFlg = False
        End If

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT " & vbCrLf
        ''前年計画数量
        strSQL = strSQL & "  LMZHKSA, LMZHKSB, LMZHKSC, LMZHKSD, LMZHKSE, LMZHKSF, LMZHKSG, LMZHKSH, LMZHKSI, LMZHKSJ, LMZHKSK, LMZHKSL" & vbCrLf ' 1-12
        ''当年計画数量
        strSQL = strSQL & ", LMAHKSA, LMAHKSB, LMAHKSC, LMAHKSD, LMAHKSE, LMAHKSF, LMAHKSG, LMAHKSH, LMAHKSI, LMAHKSJ, LMAHKSK, LMAHKSL" & vbCrLf '13-24
        ''翌年計画数量
        strSQL = strSQL & ", LMBHKSA, LMBHKSB, LMBHKSC, LMBHKSD, LMBHKSE, LMBHKSF, LMBHKSG, LMBHKSH, LMBHKSI, LMBHKSJ, LMBHKSK, LMBHKSL" & vbCrLf '25-36
        '//前年見直数量(
        strSQL = strSQL & ", LMZHMSA, LMZHMSB, LMZHMSC, LMZHMSD, LMZHMSE, LMZHMSF, LMZHMSG, LMZHMSH, LMZHMSI, LMZHMSJ, LMZHMSK, LMZHMSL" & vbCrLf '37-48
        '//当年見直数量(
        strSQL = strSQL & ", LMAHMSA, LMAHMSB, LMAHMSC, LMAHMSD, LMAHMSE, LMAHMSF, LMAHMSG, LMAHMSH, LMAHMSI, LMAHMSJ, LMAHMSK, LMAHMSL" & vbCrLf '49-60
        '//翌年見直数量(
        strSQL = strSQL & ", LMBHMSA, LMBHMSB, LMBHMSC, LMBHMSD, LMBHMSE, LMBHMSF, LMBHMSG, LMBHMSH, LMBHMSI, LMBHMSJ, LMBHMSK, LMBHMSL" & vbCrLf '61-72
        ''//年初計画CSV取込み時はワークファイルから
        If gvblnInputFlg Then
            '// 2006/11/13 ↓ ADD STR
            '//前年生産計画番号
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '73-84
            '//当年生産計画番号
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '85-96
            '//翌年生産計画番号
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '97-108
            '// 2006/11/13 ↑ ADD END
            '// 2007/01/09 ↓ ADD STR
            '//前年計画年月日
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '109-120
            '//当年計画年月日
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '121-132
            '//翌年計画年月日
            strSQL = strSQL & ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL" & vbCrLf '133-144
            '// 2007/01/09 ↑ ADD END
            '// 2007/02/24 ↓ ADD STR
            strSQL = strSQL & ", NULL,NULL" & vbCrLf '145-146
            '// 2007/02/24 ↑ ADD END
            strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
        Else
            '// 2006/11/13 ↓ ADD STR
            '//前年生産計画番号
            strSQL = strSQL & ", LMZPNOA, LMZPNOB, LMZPNOC, LMZPNOD, LMZPNOE, LMZPNOF, LMZPNOG, LMZPNOH, LMZPNOI, LMZPNOJ, LMZPNOK, LMZPNOL" & vbCrLf '73-84
            '//当年生産計画番号
            strSQL = strSQL & ", LMAPNOA, LMAPNOB, LMAPNOC, LMAPNOD, LMAPNOE, LMAPNOF, LMAPNOG, LMAPNOH, LMAPNOI, LMAPNOJ, LMAPNOK, LMAPNOL" & vbCrLf '85-96
            '//翌年生産計画番号
            strSQL = strSQL & ", LMBPNOA, LMBPNOB, LMBPNOC, LMBPNOD, LMBPNOE, LMBPNOF, LMBPNOG, LMBPNOH, LMBPNOI, LMBPNOJ, LMBPNOK, LMBPNOL" & vbCrLf '97-108
            '// 2006/11/13 ↑ ADD END
            '// 2007/01/09 ↓ ADD STR
            '//前年計画年月日
            strSQL = strSQL & ", LMZPDTA, LMZPDTB, LMZPDTC, LMZPDTD, LMZPDTE, LMZPDTF, LMZPDTG, LMZPDTH, LMZPDTI, LMZPDTJ, LMZPDTK, LMZPDTL" & vbCrLf '109-120
            '//当年計画年月日
            strSQL = strSQL & ", LMAPDTA, LMAPDTB, LMAPDTC, LMAPDTD, LMAPDTE, LMAPDTF, LMAPDTG, LMAPDTH, LMAPDTI, LMAPDTJ, LMAPDTK, LMAPDTL" & vbCrLf '121-132
            '//翌年計画年月日
            strSQL = strSQL & ", LMBPDTA, LMBPDTB, LMBPDTC, LMBPDTD, LMBPDTE, LMBPDTF, LMBPDTG, LMBPDTH, LMBPDTI, LMBPDTJ, LMBPDTK, LMBPDTL" & vbCrLf '133-144
            '// 2007/01/09 ↑ ADD END
            '// 2007/02/24 ↓ ADD STR
            strSQL = strSQL & ", WRTDT,WRTTM" & vbCrLf '145-146
            '// 2007/02/24 ↑ ADD END
            strSQL = strSQL & "FROM   HKKTRA " & vbCrLf
        End If
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/12 CHG START
        'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD) & vbCrLf
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET142F.txtHINCD.Text) & vbCrLf
        '2019/04/12 CHG E N D
        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        dt = Nothing
        dt = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

        '//販売計画Ｆより画面に表示する
        '2019/04/15 CHG START
        'If Not Set_HKKTRA(objRec) Then
        If Not Set_HKKTRA(dt) Then
            '2019/04/15 CHG E N D
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

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
	'//*    Set_HINMTA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            objRec              OraDynaset       I
	'//*
	'//* <説  明>
	'//*    商品マスタ表示
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HINMTA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HINMTA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HINMTA"

        Set_HINMTA = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '2019/04/15 CHG START
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtHINNMA.Text = D0.Chk_Null(objRec("HINNMA"))
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtHINNMB.Text = D0.Chk_Null(objRec("HINNMB"))
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtZAIRNK.Text = D0.Chk_Null(objRec("ZAIRNK"))
            ''// 2007/03/10 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            ''// 2007/03/10 ↑ ADD STR
            ''// 2006/10/27 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvstrHINKB = D0.Chk_Null(objRec("HINKB"))
            ''// 2006/10/27 ↑ ADD END
            ''// 2007/01/09 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gvstrHINGRP = D0.Chk_Null(objRec("HINGRP"))
            ''// 2007/01/09 ↑ ADD END
            ''// 2007/02/17 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtPRDENDKB.Text = IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", "手配可", "手配終了") '//生産中止
            ''// 2007/02/17 ↑ ADD END
            ''// 2007/02/24 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtPRDENDKB.BackColor = System.Drawing.ColorTranslator.FromOle(IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", gvcst_COLOR_HAIIRO, gvcst_COLOR_AKAIRO)) '//生産中止
            ''// 2007/02/24 ↑ ADD END
            ''// 2007/07/04 ↓ ADD STR
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtPLANTK.Text = D0.Chk_Null(objRec("PLANTK"))
            ''// 2007/07/04 ↑ ADD END
            HKKET142F.txtHINNMA.Text = D0.Chk_Null(pDT.Rows(0)("HINNMA"))
            HKKET142F.txtHINNMB.Text = D0.Chk_Null(pDT.Rows(0)("HINNMB"))
            HKKET142F.txtZAIRNK.Text = D0.Chk_Null(pDT.Rows(0)("ZAIRNK"))
            HKKET142F.txtPRCCD.Text = D0.Chk_NullN(pDT.Rows(0)("PRCDD"))
            HKKET142F.txtMNFDD.Text = D0.Chk_NullN(pDT.Rows(0)("MNFDD"))
            gvstrHINKB = D0.Chk_Null(pDT.Rows(0)("HINKB"))
            gvstrHINGRP = D0.Chk_Null(pDT.Rows(0)("HINGRP"))
            HKKET142F.txtPRDENDKB.Text = IIf(D0.Chk_Null(pDT.Rows(0)("PRDENDKB")) = "1", "手配可", "手配終了") '//生産中止
            HKKET142F.txtPRDENDKB.BackColor = System.Drawing.ColorTranslator.FromOle(IIf(D0.Chk_Null(pDT.Rows(0)("PRDENDKB")) = "1", gvcst_COLOR_HAIIRO, gvcst_COLOR_AKAIRO)) '//生産中止
            HKKET142F.txtPLANTK.Text = D0.Chk_Null(pDT.Rows(0)("PLANTK"))
            '2019/04/15 CHG E N D
        Else
            HKKET142F.txtHINNMA.Text = vbNullString
            HKKET142F.txtHINNMB.Text = vbNullString
            HKKET142F.txtZAIRNK.Text = vbNullString
            '// 2007/03/10 ↓ ADD STR
            HKKET142F.txtPRCCD.Text = CStr(0)
            HKKET142F.txtMNFDD.Text = CStr(0)
            '// 2007/03/10 ↑ ADD END
            '// 2006/10/27 ↓ ADD STR
            gvstrHINKB = ""
            '// 2006/10/27 ↑ ADD END
            '// 2007/01/09 ↓ ADD STR
            gvstrHINGRP = ""
            '// 2007/01/09 ↑ ADD END
            '// 2007/07/04 ↓ ADD STR
            HKKET142F.txtPLANTK.Text = CStr(0)
            '// 2007/07/04 ↑ ADD END
        End If

        '// 2008/05/27 ↓ UPD END

        '// 2008/04/30 ↓ ADD STR (バージョン集計時は、計画単価は、その製品ﾊﾞｰｼﾞｮﾝの最新製品の情報を表示する)
        If HKKET141F.optVERSION.Checked = True Then
            Call Get_KEIKAKUTANKA()
        End If
        '// 2008/05/27 ↑ ADD END

        Set_HINMTA = True

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
	'//*            objRecB             OraDynaset       I
	'//*            objRecC             OraDynaset       I
	'//*
	'//* <説  明>
	'//*    販売計画前日表示
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKZTRA(ByRef objRec As OraDynaset, ByRef objRecB As OraDynaset, ByRef objRecC As OraDynaset) As Boolean
    Public Function Set_HKKZTRA(ByRef pDT_HKKZTRA As DataTable, ByRef pDT_HKKZTRB As DataTable, ByRef pDT_ODINTRA As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA"

        Dim i As Short
        Dim j As Short
        Dim strDate As String
        Dim strDispMnth As String

        Set_HKKZTRA = False

        On Error GoTo ONERR_STEP
        strDispMnth = Mid(CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")))), 1, 4) & "0401"

        i = 0

        Do
            '//年初計画
            ReDim musrHKKTRA.blnLMAHKS(i)
            '//見直計画
            ReDim musrHKKTRA.blnLMAHMS(i)
            ''//表示月
            ReDim Preserve musrHKKZTRA.strDSPMONTH(i)
            ''//前年受注実績
            ReDim Preserve musrHKKZTRA.dblLAST_JDNTR(i)
            ''//前年出庫実績
            ReDim Preserve musrHKKZTRA.dblLAST_ODNTRA(i)
            ''//前年発注実績
            ReDim Preserve musrHKKZTRA.dblLAST_HDNTRA(i)
            '// 2007/01/09 ↓ ADD STR
            ''//前年入庫実績
            ReDim Preserve musrHKKZTRA.dblLAST_NDNTRA(i)
            '// 2007/01/09 ↑ ADD END
            ''//入庫予定
            ReDim Preserve musrHKKZTRA.dblINPTRA(i)
            ''//出庫予定
            ReDim Preserve musrHKKZTRA.dblOUTTRA(i)
            ''//支給品出庫
            ReDim Preserve musrHKKZTRA.dblSKYOUT(i)
            ''//月末在庫
            ReDim Preserve musrHKKZTRA.dblLAST_STOCK(i)
            '//発注限界日
            ReDim Preserve musrHKKZTRA.strLMZLDT(i)
            '//発注日
            ReDim Preserve musrHKKZTRA.strLMZHDT(i)
            '//在庫切れマーク
            ReDim Preserve musrHKKZTRA.strLMZZKM(i)
            '//安全在庫切れマーク
            ReDim Preserve musrHKKZTRA.strLMZAZM(i)
            '//見込在庫切れマーク
            ReDim Preserve musrHKKZTRA.strLMZMZKM(i)
            '//見込安全在庫切れマーク
            ReDim Preserve musrHKKZTRA.strLMZMAZM(i)
            '//在庫月数
            ReDim Preserve musrHKKZTRA.dblLMZZKT(i)
            '//見込在庫月数
            ReDim Preserve musrHKKZTRA.dblLMZMZKT(i)
            '//平均出庫数
            ReDim Preserve musrHKKZTRA.dblLMAVZS(i)
            '// 2007/01/09 ↓ ADD STR
            '//予測月末在庫
            ReDim Preserve musrHKKZTRA.dblYOSLST(i)
            '//見込予測月末在庫
            ReDim Preserve musrHKKZTRA.dblMYOSLST(i)
            '// 2007/01/09 ↑ ADD END
            ''//見込案件
            ReDim Preserve musrMKMTRA.dblMKMAK(i)
            ''//見込見積
            ReDim Preserve musrMKMTRA.dblMKMMT(i)
            ''//見込出庫予定
            ReDim Preserve musrMKMTRA.dblMKMOUTTRA(i)
            ''//見込月末在庫
            ReDim Preserve musrMKMTRA.dblMKMLST(i)
            ''//発注済計
            ReDim Preserve musrODINTRA.dblLMAODSSA(i)
            ''//緊急発注済計
            ReDim Preserve musrODINTRA.dblLMAKODSA(i)
            ''//入庫指示済数
            ReDim Preserve musrODINTRA.dblLMZNOSSA(i)
            '// 2007/01/09 ↓ ADD STR
            ''//（入力）入庫計画数
            ReDim Preserve musrODINTRA.strINPPLAN(i)
            ''//（入力）入庫計画数
            ReDim Preserve musrODINTRA.strINPPLAN_ORG(i)
            ''//（表示）入庫計画数
            ReDim Preserve musrODINTRA.dblDspINPPLAN(i)
            ''//（表示）入庫計画数
            ReDim Preserve musrODINTRA.dblDspINPPLAN_ORG(i)
            ''//（表示）入庫計画数(当日初回)
            ReDim Preserve musrODINTRA.dblDspINPPLAN_ZEN(i)
            '// 2007/01/09 ↑ ADD END
            ''//入庫指示数
            ReDim Preserve musrODINTRA.strLMZNOSS(i)
            ''//入庫指示数(初回値)
            ReDim Preserve musrODINTRA.strLMZNOSS_ORG(i)
            '// V2.20↓ ADD
            '//入庫計画優先ﾌﾗｸﾞ
            ReDim Preserve musrODINTRA.strLMZNPF(i)
            '//入庫計画優先ﾌﾗｸﾞ(読み込み時)
            ReDim Preserve musrODINTRA.strLMZNPF_ORG(i)
            '// V2.20↑ ADD

            'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15 CHG START
            'If Not clsOra.OraEOF(objRec) Then
            If pDT_HKKZTRA IsNot Nothing AndAlso pDT_HKKZTRA.Rows.Count > 0 Then
                '2019/04/15 CHG E N D

                '2019/04/15 ADD START
                Dim drHKKZTRA As DataRow = pDT_HKKZTRA.Rows(0)
                Dim drHKKZTRB As DataRow = pDT_HKKZTRB.Rows(0)
                Dim drODINTRA As DataRow = pDT_ODINTRA.Rows(0)
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                ' ''//表示月
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strDSPMONTH(i) = D0.Chk_Null(objRec(i))
                ''// 2006/10/26 ↓ UPD STR
                ''            If i > 11 Then
                ''                ''//前年受注実績
                ''                musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(objRec(i + 288))
                ''                ''//前年出庫実績
                ''                musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(objRec(i + 396))
                ''                ''//前年発注実績
                ''                musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(objRec(i + 432))
                ''            Else
                ''                ''//前年受注実績
                ''                musrHKKZTRA.dblLAST_JDNTR(i) = 0
                ''                ''//前年出庫実績
                ''                musrHKKZTRA.dblLAST_ODNTRA(i) = 0
                ''                ''//前年発注実績
                ''                musrHKKZTRA.dblLAST_HDNTRA(i) = 0
                ''            End If
                ' ''//前年受注実績
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(objRec(i + 288))
                ' ''//前年出庫実績
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(objRec(i + 396))
                ' ''//前年発注実績
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(objRec(i + 432))
                ''// 2006/10/26 ↑ UPD END
                ''// 2007/01/09 ↓ ADD STR
                ' ''//前年入庫実績
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLAST_NDNTRA(i) = D0.Chk_NullN(objRec(i + 360))
                ''// 2007/01/09 ↑ ADD END
                ' ''//入庫予定
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblINPTRA(i) = D0.Chk_NullN(objRec(i + 36))
                ' ''//出庫予定
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblOUTTRA(i) = D0.Chk_NullN(objRec(i + 72))
                ' ''//支給品出庫
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblSKYOUT(i) = D0.Chk_NullN(objRec(i + 144))
                ' ''//月末在庫
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLAST_STOCK(i) = D0.Chk_NullN(objRec(i + 468))
                ''//発注限界日
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZLDT(i) = D0.Chk_Null(objRec(i + 108))
                ''//発注日
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZHDT(i) = D0.Chk_Null(objRecB(i + 288))
                ''//在庫切れマーク
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZZKM(i) = D0.Chk_Null(objRecB(i))
                ''//安全在庫切れマーク
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZAZM(i) = D0.Chk_Null(objRecB(i + 36))
                ''//見込在庫切れマーク
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZMZKM(i) = D0.Chk_Null(objRecB(i + 72))
                ''//見込安全在庫切れマーク
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.strLMZMAZM(i) = D0.Chk_Null(objRecB(i + 108))
                ''//在庫月数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLMZZKT(i) = D0.Chk_NullN(objRecB(i + 324))
                ''//見込在庫月数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLMZMZKT(i) = D0.Chk_NullN(objRecB(i + 360))
                ''//平均出庫数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblLMAVZS(i) = D0.Chk_NullN(objRecB(i + 396))
                ''// 2007/01/09 ↓ ADD STR
                ''//予測月末在庫
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblYOSLST(i) = D0.Chk_NullN(objRecB(i + 504))
                ''//見込予測月末在庫
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKZTRA.dblMYOSLST(i) = D0.Chk_NullN(objRecB(i + 540))
                ''// 2007/01/09 ↑ ADD END
                ' ''//見込案件
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrMKMTRA.dblMKMAK(i) = D0.Chk_NullN(objRecB(i + 432))
                ' ''//見込見積
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrMKMTRA.dblMKMMT(i) = D0.Chk_NullN(objRec(i + 540))
                ''// 2007/01/09 ↓ UPD STR
                ''            ''//見込出庫予定
                ''            musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(objRec(i + 576)) + D0.Chk_NullN(objRecB(i + 468)) + D0.Chk_NullN(objRec(i + 612))
                ' ''//見込出庫予定
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(objRecB(i + 468)) + D0.Chk_NullN(objRec(i + 576))
                ''// 2007/01/09 ↑ UPD END
                ' ''//見込月末在庫
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrMKMTRA.dblMKMLST(i) = D0.Chk_NullN(objRec(i + 504))
                ' ''//発注済計
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblLMAODSSA(i) = D0.Chk_NullN(objRec(i + 252))
                ' ''//緊急発注済計
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblLMAKODSA(i) = D0.Chk_NullN(objRec(i + 180))
                ' ''//入庫指示済数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblLMZNOSSA(i) = D0.Chk_NullN(objRec(i + 216))
                ''// 2007/01/09 ↓ ADD STR
                ' ''//（入力）入庫計画数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.strINPPLAN(i) = CStr(Val(D0.Chk_Null(objRecC(i + 108))))
                ' ''//（入力）入庫計画数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.strINPPLAN_ORG(i) = CStr(Val(D0.Chk_Null(objRecC(i + 108))))
                ' ''//（表示）入庫計画数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblDspINPPLAN(i) = D0.Chk_NullN(objRecC(i + 36))
                ' ''//（表示）入庫計画数
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblDspINPPLAN_ORG(i) = D0.Chk_NullN(objRecC(i + 36))
                ' ''//（表示）入庫計画数(当日初回)
                ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrODINTRA.dblDspINPPLAN_ZEN(i) = D0.Chk_NullN(objRecC(i + 72))
                ''// 2007/01/09 ↑ ADD END
                ''            If IsNumeric(musrHKKTRA.strLMAHMS(i)) Then
                ''                If HKKET141F.optORDER_ON.Value Then
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(musrHKKTRA.strLMAHMS(i)) + CDbl(D0.Chk_Null(objRec(i + 515)))
                ''                Else
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(musrHKKTRA.strLMAHMS(i)) + CDbl(D0.Chk_Null(objRec(i + 479)))
                ''                End If
                ''            Else
                ''                If HKKET141F.optORDER_ON.Value Then
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(Val(musrHKKTRA.strLMAHKS(i))) + CDbl(D0.Chk_Null(objRec(i + 515)))
                ''                Else
                ''                    musrODINTRA.dblDspINPPLAN(i) = CDbl(Val(musrHKKTRA.strLMAHKS(i))) + CDbl(D0.Chk_Null(objRec(i + 479)))
                ''                End If
                ''            End If
                ''UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'If Not clsOra.OraEOF(objRecC) Then
                '    '//入庫指示数
                '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    If IsNumeric(D0.Chk_Null(objRecC(i))) Then
                '        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        musrODINTRA.strLMZNOSS(i) = CStr(CDbl(D0.Chk_Null(objRecC(i))))
                '        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        musrODINTRA.strLMZNOSS_ORG(i) = CStr(CDbl(D0.Chk_Null(objRecC(i))))
                '    Else
                '        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        musrODINTRA.strLMZNOSS(i) = D0.Chk_Null(objRecC(i))
                '        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        musrODINTRA.strLMZNOSS_ORG(i) = D0.Chk_Null(objRecC(i))
                '    End If
                '    '// 2007/02/24 ↓ ADD END
                '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    strODINTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 1, 4) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 5, 2) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRecC(144)), 8), 7, 2) & " " & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 1, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 3, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRecC(145)), 6), 5, 2)
                '    '// 2007/02/24 ↑ ADD END
                '    '// V2.20↓ ADD
                '    '//優先フラグ
                '    'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    musrODINTRA.strLMZNPF(i) = IIf(D0.Chk_Null(objRecC(i + 146)) = "", "0   ", objRecC(i + 146))
                '    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '    '// V2.20↑ ADD
                'Else
                '    '//入庫指示数
                '    musrODINTRA.strLMZNOSS(i) = " "
                '    musrODINTRA.strLMZNOSS_ORG(i) = " "
                '    '// 2007/02/24 ↓ ADD END
                '    strODINTRA_DAY = Space(19)
                '    '// 2007/02/24 ↑ ADD END
                '    '// V2.20↓ ADD
                '    '//優先フラグ
                '    musrODINTRA.strLMZNPF(i) = "0   "
                '    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '    '// V2.20↑ ADD
                'End If

                ''//表示月
                musrHKKZTRA.strDSPMONTH(i) = D0.Chk_Null(drHKKZTRA(i))
                ''//前年受注実績
                musrHKKZTRA.dblLAST_JDNTR(i) = D0.Chk_NullN(drHKKZTRA(i + 288))
                ''//前年出庫実績
                musrHKKZTRA.dblLAST_ODNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 396))
                ''//前年発注実績
                musrHKKZTRA.dblLAST_HDNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 432))
                ''//前年入庫実績
                musrHKKZTRA.dblLAST_NDNTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 360))
                ''//入庫予定
                musrHKKZTRA.dblINPTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 36))
                ''//出庫予定
                musrHKKZTRA.dblOUTTRA(i) = D0.Chk_NullN(drHKKZTRA(i + 72))
                ''//支給品出庫
                musrHKKZTRA.dblSKYOUT(i) = D0.Chk_NullN(drHKKZTRA(i + 144))
                ''//月末在庫
                musrHKKZTRA.dblLAST_STOCK(i) = D0.Chk_NullN(drHKKZTRA(i + 468))
                '//発注限界日
                musrHKKZTRA.strLMZLDT(i) = D0.Chk_Null(drHKKZTRA(i + 108))
                '//発注日
                musrHKKZTRA.strLMZHDT(i) = D0.Chk_Null(drHKKZTRB(i + 288))
                '//在庫切れマーク
                musrHKKZTRA.strLMZZKM(i) = D0.Chk_Null(drHKKZTRB(i))
                '//安全在庫切れマーク
                musrHKKZTRA.strLMZAZM(i) = D0.Chk_Null(drHKKZTRB(i + 36))
                '//見込在庫切れマーク
                musrHKKZTRA.strLMZMZKM(i) = D0.Chk_Null(drHKKZTRB(i + 72))
                '//見込安全在庫切れマーク
                musrHKKZTRA.strLMZMAZM(i) = D0.Chk_Null(drHKKZTRB(i + 108))
                '//在庫月数
                musrHKKZTRA.dblLMZZKT(i) = D0.Chk_NullN(drHKKZTRB(i + 324))
                '//見込在庫月数
                musrHKKZTRA.dblLMZMZKT(i) = D0.Chk_NullN(drHKKZTRB(i + 360))
                '//平均出庫数
                musrHKKZTRA.dblLMAVZS(i) = D0.Chk_NullN(drHKKZTRB(i + 396))
                '//予測月末在庫
                musrHKKZTRA.dblYOSLST(i) = D0.Chk_NullN(drHKKZTRB(i + 504))
                '//見込予測月末在庫
                musrHKKZTRA.dblMYOSLST(i) = D0.Chk_NullN(drHKKZTRB(i + 540))
                ''//見込案件
                musrMKMTRA.dblMKMAK(i) = D0.Chk_NullN(drHKKZTRB(i + 432))
                ''//見込見積
                musrMKMTRA.dblMKMMT(i) = D0.Chk_NullN(drHKKZTRA(i + 540))
                ''//見込出庫予定
                musrMKMTRA.dblMKMOUTTRA(i) = D0.Chk_NullN(drHKKZTRB(i + 468)) + D0.Chk_NullN(drHKKZTRA(i + 576))
                ''//見込月末在庫
                musrMKMTRA.dblMKMLST(i) = D0.Chk_NullN(drHKKZTRA(i + 504))
                ''//発注済計
                musrODINTRA.dblLMAODSSA(i) = D0.Chk_NullN(drHKKZTRA(i + 252))
                ''//緊急発注済計
                musrODINTRA.dblLMAKODSA(i) = D0.Chk_NullN(drHKKZTRA(i + 180))
                ''//入庫指示済数
                musrODINTRA.dblLMZNOSSA(i) = D0.Chk_NullN(drHKKZTRA(i + 216))
                ''//（入力）入庫計画数
                musrODINTRA.strINPPLAN(i) = CStr(Val(D0.Chk_Null(drODINTRA(i + 108))))
                ''//（入力）入庫計画数
                musrODINTRA.strINPPLAN_ORG(i) = CStr(Val(D0.Chk_Null(drODINTRA(i + 108))))
                ''//（表示）入庫計画数
                musrODINTRA.dblDspINPPLAN(i) = D0.Chk_NullN(drODINTRA(i + 36))
                ''//（表示）入庫計画数
                musrODINTRA.dblDspINPPLAN_ORG(i) = D0.Chk_NullN(drODINTRA(i + 36))
                ''//（表示）入庫計画数(当日初回)
                musrODINTRA.dblDspINPPLAN_ZEN(i) = D0.Chk_NullN(drODINTRA(i + 72))
                '2019/04/15　仮
                If pDT_ODINTRA IsNot Nothing AndAlso pDT_ODINTRA.Rows.Count > 0 Then
                    '2019/04/15　仮
                    '//入庫指示数
                    If IsNumeric(D0.Chk_Null(drODINTRA(i))) Then
                        musrODINTRA.strLMZNOSS(i) = CStr(CDbl(D0.Chk_Null(drODINTRA(i))))
                        musrODINTRA.strLMZNOSS_ORG(i) = CStr(CDbl(D0.Chk_Null(drODINTRA(i))))
                    Else
                        musrODINTRA.strLMZNOSS(i) = D0.Chk_Null(drODINTRA(i))
                        musrODINTRA.strLMZNOSS_ORG(i) = D0.Chk_Null(drODINTRA(i))
                    End If
                    strODINTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 1, 4) _
                                  & "/" & Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 5, 2) _
                                  & "/" & Mid(Right(Space(8) & D0.Chk_Null(drODINTRA(144)), 8), 7, 2) _
                                  & " " & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 1, 2) _
                                  & ":" & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 3, 2) _
                                  & ":" & Mid(Right(Space(6) & D0.Chk_Null(drODINTRA(145)), 6), 5, 2)
                    '//優先フラグ
                    musrODINTRA.strLMZNPF(i) = IIf(D0.Chk_Null(drODINTRA(i + 146)) = "", "0   ", drODINTRA(i + 146))
                    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                Else
                    '//入庫指示数
                    musrODINTRA.strLMZNOSS(i) = " "
                    musrODINTRA.strLMZNOSS_ORG(i) = " "
                    strODINTRA_DAY = Space(19)
                    '//優先フラグ
                    musrODINTRA.strLMZNPF(i) = "0   "
                    musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                End If
                '2019/04/15 CHG E N D
            Else
                strDate = Mid(VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, i, CDate(VB6.Format(strDispMnth, "@@@@/@@/@@"))), "YYYYMMDD"), 1, 6)
                ''//表示月
                musrHKKZTRA.strDSPMONTH(i) = strDate
                ''//前年受注実績
                musrHKKZTRA.dblLAST_JDNTR(i) = 0
                '// 2007/01/09 ↓ ADD STR
                ''//前年入庫実績
                musrHKKZTRA.dblLAST_NDNTRA(i) = 0
                '// 2007/01/09 ↑ ADD END
                ''//前年出庫実績
                musrHKKZTRA.dblLAST_ODNTRA(i) = 0
                ''//前年発注実績
                musrHKKZTRA.dblLAST_HDNTRA(i) = 0
                ''//入庫予定
                musrHKKZTRA.dblINPTRA(i) = 0
                ''//出庫予定
                musrHKKZTRA.dblOUTTRA(i) = 0
                ''//支給品出庫
                musrHKKZTRA.dblSKYOUT(i) = 0
                '//在庫切れマーク
                musrHKKZTRA.strLMZZKM(i) = ""
                '//安全在庫切れマーク
                musrHKKZTRA.strLMZAZM(i) = ""
                '//見込在庫切れマーク
                musrHKKZTRA.strLMZMZKM(i) = ""
                '//見込安全在庫切れマーク
                musrHKKZTRA.strLMZMAZM(i) = ""
                '//発注限界日
                musrHKKZTRA.strLMZLDT(i) = ""
                '//発注日
                musrHKKZTRA.strLMZHDT(i) = ""
                '//在庫月数
                musrHKKZTRA.dblLMZZKT(i) = 0
                '//見込在庫月数
                musrHKKZTRA.dblLMZMZKT(i) = 0
                ''//月末在庫
                musrHKKZTRA.dblLAST_STOCK(i) = 0
                ''//平均出庫数
                musrHKKZTRA.dblLMAVZS(i) = 0
                '// 2007/01/09 ↓ ADD STR
                ''//予測月末在庫
                musrHKKZTRA.dblYOSLST(i) = 0
                ''//見込予測月末在庫
                musrHKKZTRA.dblMYOSLST(i) = 0
                '// 2007/01/09 ↑ ADD END
                ''//見込案件
                musrMKMTRA.dblMKMAK(i) = 0
                ''//見込見積
                musrMKMTRA.dblMKMMT(i) = 0
                ''//見込出庫予定
                musrMKMTRA.dblMKMOUTTRA(i) = 0
                ''//見込月末在庫
                musrMKMTRA.dblMKMLST(i) = 0
                ''//発注済計
                musrODINTRA.dblLMAODSSA(i) = 0
                ''//緊急発注済計
                musrODINTRA.dblLMAKODSA(i) = 0
                ''//入庫指示済数
                musrODINTRA.dblLMZNOSSA(i) = 0
                '// 2007/01/09 ↓ ADD STR
                ''//（入力）入庫計画数
                musrODINTRA.strINPPLAN(i) = " "
                ''//（入力）入庫計画数
                musrODINTRA.strINPPLAN_ORG(i) = " "
                ''//（表示）入庫計画数
                musrODINTRA.dblDspINPPLAN(i) = 0
                ''//（表示）入庫計画数(初回値)
                musrODINTRA.dblDspINPPLAN_ORG(i) = 0
                ''//（表示）入庫計画数(当日初回)
                musrODINTRA.dblDspINPPLAN_ZEN(i) = 0
                '// 2007/01/09 ↑ ADD END
                '//入庫指示数
                musrODINTRA.strLMZNOSS(i) = " "
                '//入庫指示数(初回値)
                musrODINTRA.strLMZNOSS_ORG(i) = " "
                '// 2007/02/24 ↓ ADD END
                strHKKTRA_DAY = Space(19)
                '// 2007/02/24 ↑ ADD END
                '// V2.20↓ ADD
                '//優先フラグ
                musrODINTRA.strLMZNPF(i) = "0   "
                musrODINTRA.strLMZNPF_ORG(i) = musrODINTRA.strLMZNPF(i)
                '// V2.20↑ ADD
            End If
            If Trim(musrODINTRA.strLMZNOSS(i)) = "" Then
                '//年初計画
                musrHKKTRA.blnLMAHKS(i) = True
                '//見直計画
                musrHKKTRA.blnLMAHMS(i) = True
            Else
                '//年初計画
                musrHKKTRA.blnLMAHKS(i) = False
                '//見直計画
                musrHKKTRA.blnLMAHMS(i) = False
            End If
            i = i + 1
            If i = 36 Then
                Exit Do
            End If
        Loop

        Set_HKKZTRA = True

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
	'//*    Set_HKKZTRB
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
	Public Function Set_HKKZTRB(ByRef objRec As OraDynaset) As Boolean
		
		Const PROCEDURE As String = "Set_HKKZTRB"
		
		Dim i As Short
		Dim j As Short
		
		Set_HKKZTRB = False
		
		On Error GoTo ONERR_STEP
		
		i = gvlngNowPage
		j = 0
		
		Do 
			
			'//月末在庫
			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If D0.Chk_Null(objRec(i + 48)) = "0" And D0.Chk_Null(objRec(i + 12)) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(128, 255, 255)
				'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf D0.Chk_Null(objRec(i + 48)) = "1" And D0.Chk_Null(objRec(i + 12)) = "0" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 255)
				'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf D0.Chk_Null(objRec(i + 48)) = "0" And D0.Chk_Null(objRec(i + 12)) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.Red
			End If
			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If D0.Chk_Null(objRec(i + 336)) >= HKKET141F.txtSTOCK_MONTH.Text Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 0)
			End If
			
			'//見込月末在庫
			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If D0.Chk_Null(objRec(i + 120)) = "0" And D0.Chk_Null(objRec(i + 228)) = "0" Then
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(128, 255, 255)
				'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf D0.Chk_Null(objRec(i + 120)) = "1" And D0.Chk_Null(objRec(i + 228)) = "0" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.FromARGB(255, 128, 255)
				'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf D0.Chk_Null(objRec(i + 120)) = "0" And D0.Chk_Null(objRec(i + 228)) = "1" Then 
				HKKET142F.txtMKMLST(j).BackColor = System.Drawing.Color.Red
			End If
			
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		Set_HKKZTRB = True
		
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
	'//*    Set_HKKZTRA_M
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
    'Public Function Set_HKKZTRA_M(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKZTRA_M(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA_M"
        Dim i As Short

        Dim lngZanEigyoHi As Integer
        Dim lngTouEigyoHi As Integer
        Dim dblMokuhyoChi As Double
        Dim dblZanHiAnbun As Double
        Dim dblSyukoYotei As Double

        Set_HKKZTRA_M = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '2019/04/15 CHG START
            ''//品名
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtHINNMB.Text = D0.Chk_Null(objRec("HINNMB"))
            ''//型式
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtHINNMA.Text = D0.Chk_Null(objRec("HINKTA"))
            ''//在庫ﾗﾝｸ
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtZAIRNK.Text = D0.Chk_Null(objRec("ZAIRNK"))
            ''//最小発注数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtMINSODSU.Text = D0.Chk_NullN(objRec("MINSODSU"))
            ''//発注増加数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtSODADDSU.Text = D0.Chk_NullN(objRec("SODADDSU"))
            ''//安全在庫数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtANZZAISU.Text = D0.Chk_NullN(objRec("ANZZAISU"))
            ''//安全在庫基準月数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'If D0.Chk_NullN(objRec("LMAAVTS")) = 0 Then
            '    HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            'Else
            '    'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    HKKET142F.txtLMAMSAVTS.Text = D0.Chg_NumericRound(D0.Chk_NullN(objRec("ANZZAISU")) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            'End If
            ''//在庫月数
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        If D0.Chk_NullN(objRec("LMAAVTS")) = 0 Then
            '            HKKET142F.txtLMAAVTS.Text = CStr(0)
            '        Else
            '            '// 2007/01/09 ↓ UPD STR
            '            '                    HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblLAST_STOCK(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            If HKKET141F.optORDER_ON.Checked Then
            '                'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '                'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '                HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblMYOSLST(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            Else
            '                'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '                'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '                HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblYOSLST(i) - D0.Chk_NullN(objRec("ANZZAISU"))) / D0.Chk_NullN(objRec("LMAAVTS")), 3, 3)
            '            End If
            '            '// 2007/01/09 ↑ UPD END
            '        End If
            '        Exit For
            '    End If
            'Next i
            ''//平均出庫数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtLMZAVTSA.Text = D0.Chk_NullN(objRec("LMAAVTS"))

            ''//出庫変化率
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If musrHKKZTRA.dblLMAVZS(i) = 0 Then
            '            HKKET142F.txtCHGRATE.Text = CStr(0)
            '        Else
            '            'UPGRADE_WARNING: オブジェクト D0.Chg_NumericRound の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '            HKKET142F.txtCHGRATE.Text = D0.Chg_NumericRound(musrHKKZTRA.dblLMAVZS(i - 1) / musrHKKZTRA.dblLMAVZS(i), 3, 3)
            '        End If
            '        Exit For
            '    End If
            'Next i
            ''
            ''// 2007/07/02 ↓ ADD START @@@@@@初回から按分欄を表示する@@@@@@@@@@@@@@@@@@@@@@@@@tohjo
            ''//目標値の取得（見直計画または年初計画(見直し優先)）
            'If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
            '    dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
            'Else
            '    dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
            'End If
            ''//出庫予定
            'dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)

            ''//残営業日の取得
            'lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")

            ''//当月営業日の取得
            'lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")

            ''//残日数按分値
            'If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
            '    '//残日数が４日以下の場合
            '    dblZanHiAnbun = 0
            'Else
            '    '//出荷予定比較日数から按分値を求める
            '    If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
            '        '//出庫予定が目標値の４日分を超えない場合
            '        dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
            '    Else
            '        '//出庫予定が目標値の４日分を超えた場合
            '        dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
            '    End If
            'End If

            'HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
            'HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
            'HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
            'HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)
            ''// 2007/07/02 ↑ ADD END @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            ''// 2008/04/30 ↓ ADD STR (バージョン集計時は、HKKTRAの値を表示する)
            'If HKKET141F.optVERSION.Checked = True Then
            '    '//調達ＬＴ
            '    'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            '    '//生産ＬＴ
            '    'UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            'End If
            ''// 2008/04/30 ↑ ADD END

            ''// 2007/03/10 ↓ DEL STR
            ''        '//調達ＬＴ
            ''        HKKET142F.txtPRCCD.Text = D0.Chk_NullN(objRec("PRCDD"))
            ''        '//生産ＬＴ
            ''        HKKET142F.txtMNFDD.Text = D0.Chk_NullN(objRec("MNFDD"))
            ''// 2007/03/10 ↑ DEL END

            ''// 2007/01/09 ↓ ADD STR
            ''//当月入庫実績
            'HKKET142F.txtTOUNYUKO.Text = CStr(0)
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If i + 12 <= 35 Then
            '            HKKET142F.txtTOUNYUKO.Text = CStr(musrHKKZTRA.dblLAST_NDNTRA(i + 12))
            '            Exit For
            '        End If
            '    End If
            'Next i
            ''//当月出庫実績
            'HKKET142F.txtTOUSYUKO.Text = CStr(0)
            'For i = 0 To 35
            '    If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
            '        If i + 12 <= 35 Then
            '            HKKET142F.txtTOUSYUKO.Text = CStr(musrHKKZTRA.dblLAST_ODNTRA(i + 12))
            '            Exit For
            '        End If
            '    End If
            'Next i
            ''// 2007/01/09 ↑ ADD END

            ''//現在庫数
            ''UPGRADE_WARNING: オブジェクト D0.Chk_NullN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtTOUZAISU.Text = D0.Chk_NullN(objRec("TOUZAISU"))
            ''//備考
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtHINCM.Text = D0.Chk_Null(objRec("HINCM"))
            ''//メモ
            ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'HKKET142F.txtMEMO.Text = D0.Chk_Null(objRec("MEMO"))

            '//品名
            HKKET142F.txtHINNMB.Text = D0.Chk_Null(pDT.Rows(0)("HINNMB"))
            '//型式
             HKKET142F.txtHINNMA.Text = D0.Chk_Null(pDT.Rows(0)("HINKTA"))
            '//在庫ﾗﾝｸ
            HKKET142F.txtZAIRNK.Text = D0.Chk_Null(pDT.Rows(0)("ZAIRNK"))
            '//最小発注数
            HKKET142F.txtMINSODSU.Text = D0.Chk_NullN(pDT.Rows(0)("MINSODSU"))
            '//発注増加数
            HKKET142F.txtSODADDSU.Text = D0.Chk_NullN(pDT.Rows(0)("SODADDSU"))
            '//安全在庫数
            HKKET142F.txtANZZAISU.Text = D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))
            '//安全在庫基準月数
            If D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")) = 0 Then
                HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            Else
                HKKET142F.txtLMAMSAVTS.Text = D0.Chg_NumericRound(D0.Chk_NullN(pDT.Rows(0)("ANZZAISU")) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
            End If
            '//在庫月数
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")) = 0 Then
                        HKKET142F.txtLMAAVTS.Text = CStr(0)
                    Else
                         If HKKET141F.optORDER_ON.Checked Then
                            HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblMYOSLST(i) - D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
                        Else
                            HKKET142F.txtLMAAVTS.Text = D0.Chg_NumericRound((musrHKKZTRA.dblYOSLST(i) - D0.Chk_NullN(pDT.Rows(0)("ANZZAISU"))) / D0.Chk_NullN(pDT.Rows(0)("LMAAVTS")), 3, 3)
                        End If
                      End If
                    Exit For
                End If
            Next i
            '//平均出庫数
            HKKET142F.txtLMZAVTSA.Text = D0.Chk_NullN(pDT.Rows(0)("LMAAVTS"))
            '//出庫変化率
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If musrHKKZTRA.dblLMAVZS(i) = 0 Then
                        HKKET142F.txtCHGRATE.Text = CStr(0)
                    Else
                         HKKET142F.txtCHGRATE.Text = D0.Chg_NumericRound(musrHKKZTRA.dblLMAVZS(i - 1) / musrHKKZTRA.dblLMAVZS(i), 3, 3)
                    End If
                    Exit For
                End If
            Next i
            '//目標値の取得（見直計画または年初計画(見直し優先)）
            If Trim(musrHKKTRA.strLMAHMS(i)) = "" Then
                dblMokuhyoChi = Val(musrHKKTRA.strLMAHKS(i))
            Else
                dblMokuhyoChi = Val(musrHKKTRA.strLMAHMS(i))
            End If
            '//出庫予定
            dblSyukoYotei = musrHKKZTRA.dblOUTTRA(i)

            '//残営業日の取得
            lngZanEigyoHi = Get_EigyoNisu(gvstrUNYDT, Mid(gvstrUNYDT, 1, 6) & "31")

            '//当月営業日の取得
            lngTouEigyoHi = Get_EigyoNisu(Mid(gvstrUNYDT, 1, 6) & "01", Mid(gvstrUNYDT, 1, 6) & "31")

            '//残日数按分値
            If lngZanEigyoHi <= gvlngSyukaYoteiHikaku Then
                '//残日数が４日以下の場合
                dblZanHiAnbun = 0
            Else
                '//出荷予定比較日数から按分値を求める
                If dblSyukoYotei < System.Math.Round(dblMokuhyoChi * gvlngSyukaYoteiHikaku / lngTouEigyoHi) Then
                    '//出庫予定が目標値の４日分を超えない場合
                    dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi)
                Else
                    '//出庫予定が目標値の４日分を超えた場合
                    dblZanHiAnbun = System.Math.Round(dblMokuhyoChi * (lngZanEigyoHi - gvlngSyukaYoteiHikaku) / lngTouEigyoHi)
                End If
            End If

            HKKET142F.txtZanHiAnbun.Text = CStr(dblZanHiAnbun)
            HKKET142F.txtZanDeAnbun.Text = CStr(System.Math.Round(dblMokuhyoChi * lngZanEigyoHi / lngTouEigyoHi))
            HKKET142F.txtZAN.Text = CStr(lngZanEigyoHi)
            HKKET142F.txtZEN.Text = CStr(lngTouEigyoHi)

            If HKKET141F.optVERSION.Checked = True Then
                '//調達ＬＴ
                HKKET142F.txtPRCCD.Text = D0.Chk_NullN(pDT.Rows(0)("PRCDD"))
                '//生産ＬＴ
                HKKET142F.txtMNFDD.Text = D0.Chk_NullN(pDT.Rows(0)("MNFDD"))
            End If
            '//当月入庫実績
            HKKET142F.txtTOUNYUKO.Text = CStr(0)
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If i + 12 <= 35 Then
                        HKKET142F.txtTOUNYUKO.Text = CStr(musrHKKZTRA.dblLAST_NDNTRA(i + 12))
                        Exit For
                    End If
                End If
            Next i
            '//当月出庫実績
            HKKET142F.txtTOUSYUKO.Text = CStr(0)
            For i = 0 To 35
                If musrHKKZTRA.strDSPMONTH(i) = Mid(gvstrUNYDT, 1, 6) Then
                    If i + 12 <= 35 Then
                        HKKET142F.txtTOUSYUKO.Text = CStr(musrHKKZTRA.dblLAST_ODNTRA(i + 12))
                        Exit For
                    End If
                End If
            Next i
           
            '//現在庫数
            HKKET142F.txtTOUZAISU.Text = D0.Chk_NullN(pDT.Rows(0)("TOUZAISU"))
            '//備考
            HKKET142F.txtHINCM.Text = D0.Chk_Null(pDT.Rows(0)("HINCM"))
            '//メモ
            HKKET142F.txtMEMO.Text = D0.Chk_Null(pDT.Rows(0)("MEMO"))
            '2019/04/15 CHG E N D
        Else
            '//最小発注数
            HKKET142F.txtMINSODSU.Text = CStr(0)
            '//発注増加数
            HKKET142F.txtSODADDSU.Text = CStr(0)
            '//安全在庫数
            HKKET142F.txtANZZAISU.Text = CStr(0)
            '//安全在庫基準月数
            HKKET142F.txtLMAMSAVTS.Text = CStr(0)
            '//在庫月数
            HKKET142F.txtLMAAVTS.Text = CStr(0)
            '//平均出庫数
            HKKET142F.txtLMZAVTSA.Text = CStr(0)
            '//出庫変化率
            HKKET142F.txtCHGRATE.Text = CStr(0)
            '//調達ＬＴ
            HKKET142F.txtPRCCD.Text = CStr(0)
            '//生産ＬＴ
            HKKET142F.txtMNFDD.Text = CStr(0)
            '//現在庫数
            HKKET142F.txtTOUZAISU.Text = CStr(0)
            '//備考
            HKKET142F.txtHINCM.Text = vbNullString
            '//メモ
            HKKET142F.txtMEMO.Text = vbNullString

            '// 2008/04/30 ↓ ADD STR (バージョン集計時は、HKKTRAの値を表示する)
            If HKKET141F.optVERSION.Checked = True Then
                '//調達ＬＴ
                HKKET142F.txtPRCCD.Text = CStr(0)
                '//生産ＬＴ
                HKKET142F.txtMNFDD.Text = CStr(0)
            End If
            '// 2008/04/30 ↑ ADD END

        End If

        '// 2007/02/24 ↓ ADD END
        If strHKKTRA_DAY > strODINTRA_DAY Then
            HKKET142F.txtWRTDTTM.Text = strHKKTRA_DAY
        Else
            HKKET142F.txtWRTDTTM.Text = strODINTRA_DAY
        End If
        '// 2007/02/24 ↑ ADD END

        Set_HKKZTRA_M = True

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
	'//*    Set_HKKTRA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            objRec              OraDynaset       I
	'//*
	'//* <説  明>
	'//*    販売計画Ｆ表示
	'//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKTRA"

        Dim i As Short
        Dim j As Short

        Set_HKKTRA = False

        On Error GoTo ONERR_STEP

        '//年初計画/見直計画
        i = 0
        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If pDT IsNot Nothing AndAlso pDT.Rows.Count > 0 Then
            '2019/04/15 CHG E N D

            '2019/04/15 ADD START
            Dim row As DataRow = pDT.Rows(0)
            '2019/04/15 ADD E N D
            Do
                ReDim Preserve musrHKKTRA.strLMAHKS(i)
                ReDim Preserve musrHKKTRA.strLMAHKS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMAHMS(i)
                ReDim Preserve musrHKKTRA.strLMAHMS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMZPNO(i)
                '// 2007/01/09 ↓ ADD STR
                ReDim Preserve musrHKKTRA.strLMAPDT(i)
                ReDim Preserve musrHKKTRA.intLTKBN(i)
                '// 2007/01/09 ↑ ADD END
                '2019/04/15 CHG START
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMAHKS(i) = D0.Chk_Null(objRec(i))
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMAHKS_ORG(i) = D0.Chk_Null(objRec(i))
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMAHMS(i) = D0.Chk_Null(objRec(i + 36))
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMAHMS_ORG(i) = D0.Chk_Null(objRec(i + 36))
                ''// 2006/11/13 ↓ ADD STR
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMZPNO(i) = D0.Chk_Null(objRec(i + 72))
                ''// 2006/11/13 ↑ ADD END
                ''// 2007/01/09 ↓ ADD STR
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'musrHKKTRA.strLMAPDT(i) = D0.Chk_Null(objRec(i + 108))
                'musrHKKTRA.intLTKBN(i) = 0
                ''// 2007/01/09 ↑ ADD END
                musrHKKTRA.strLMAHKS(i) = D0.Chk_Null(row(i))
                musrHKKTRA.strLMAHKS_ORG(i) = D0.Chk_Null(row(i))
                musrHKKTRA.strLMAHMS(i) = D0.Chk_Null(row(i + 36))
                musrHKKTRA.strLMAHMS_ORG(i) = D0.Chk_Null(row(i + 36))
                musrHKKTRA.strLMZPNO(i) = D0.Chk_Null(row(i + 72))
                musrHKKTRA.strLMAPDT(i) = D0.Chk_Null(row(i + 108))
                musrHKKTRA.intLTKBN(i) = 0
                '2019/04/15 CHG E N D
                i = i + 1
                If i = 36 Then
                    Exit Do
                End If
            Loop
            '// 2007/02/24 ↓ ADD END
            'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15 CHG START
            'strHKKTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 1, 4) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 5, 2) & "/" & Mid(Right(Space(8) & D0.Chk_Null(objRec(145 - 1)), 8), 7, 2) & " " & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 1, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 3, 2) & ":" & Mid(Right(Space(6) & D0.Chk_Null(objRec(146 - 1)), 6), 5, 2)
            strHKKTRA_DAY = Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 1, 4) _
                          & "/" & Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 5, 2) _
                          & "/" & Mid(Right(Space(8) & D0.Chk_Null(row(145 - 1)), 8), 7, 2) _
                          & " " & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 1, 2) _
                          & ":" & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 3, 2) _
                          & ":" & Mid(Right(Space(6) & D0.Chk_Null(row(146 - 1)), 6), 5, 2)
            '2019/04/15 CHG E N D
            '// 2007/02/24 ↑ ADD END
        Else
            Do
                ReDim Preserve musrHKKTRA.strLMAHKS(i)
                ReDim Preserve musrHKKTRA.strLMAHKS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMAHMS(i)
                ReDim Preserve musrHKKTRA.strLMAHMS_ORG(i)
                ReDim Preserve musrHKKTRA.strLMZPNO(i)
                '// 2007/01/09 ↓ ADD STR
                ReDim Preserve musrHKKTRA.strLMAPDT(i)
                ReDim Preserve musrHKKTRA.intLTKBN(i)
                '// 2007/01/09 ↑ ADD END
                musrHKKTRA.strLMAHKS(i) = " "
                musrHKKTRA.strLMAHKS_ORG(i) = " "
                musrHKKTRA.strLMAHMS(i) = " "
                musrHKKTRA.strLMAHMS_ORG(i) = " "
                '// 2006/11/13 ↓ ADD STR
                musrHKKTRA.strLMZPNO(i) = " "
                '// 2006/11/13 ↑ ADD END
                '// 2007/01/09 ↓ ADD STR
                musrHKKTRA.strLMAPDT(i) = " "
                musrHKKTRA.intLTKBN(i) = 0
                '// 2007/01/09 ↑ ADD END
                i = i + 1
                If i = 36 Then
                    Exit Do
                End If
            Loop
            '// 2007/02/24 ↓ ADD END
            strHKKTRA_DAY = Space(19)
            '// 2007/02/24 ↑ ADD END
        End If
        Set_HKKTRA = True

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
	'//*    Set_ODINTRA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*            objRec              OraDynaset       I
	'//*
	'//* <説  明>
	'//*    入庫指示情報表示
	'//*****************************************************************************************
	Public Function Set_ODINTRA(ByRef objRec As OraDynaset) As Boolean
		
		Const PROCEDURE As String = "Set_ODINTRA"
		
		Dim i As Short
		Dim j As Short
		
		Set_ODINTRA = False
		
		On Error GoTo ONERR_STEP
		
		i = gvlngNowPage
		Do 
			'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HKKET142F.txtLMZNOSS(j).Text = D0.Chk_Null(objRec(i + 1))
			i = i + 1
			j = j + 1
			If j = 13 Then
				Exit Do
			End If
		Loop 
		
		Set_ODINTRA = True
		
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
	'//*    Upd_Main
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    更新処理
	'//*****************************************************************************************
    Public Function Upd_Main(Optional ByRef pstr_FileName As String = "") As Boolean
        '2019/04/19 DEL START
        'Dim ORAPARM_OUTPUT As Object
        'Dim ORATYPE_NUMBER As Object
        'Dim gvstrCLTID As Object
        'Dim ORATYPE_CHAR As Object
        'Dim ORAPARM_INPUT As Object
        'Dim gvstrOPEID As Object
        '2019/04/19 DEL E N D

        Const PROCEDURE As String = "Upd_Main"

        '2019/04/19 DEL START
        'Dim wCNT As Integer
        '2019/04/19 DEL E N D
        '2019/04/19 DEL START
        'Dim i As Integer
        '2019/04/19 DEL E N D
        Dim intRtnCd As Short
        '2019/04/19 DEL START
        'Dim OraPArray1 As Object
        'Dim OraPArray2 As Object
        'Dim OraPArray3 As Object
        'Dim OraPArray4 As Object
        ''// 2007/01/09 ↓ ADD STR
        'Dim OraPArray5 As Object
        'Dim OraPArray6 As Object
        'Dim OraPArray7 As Object
        'Dim OraPArray8 As Object
        ''// 2007/01/09 ↑ ADD END
        ''// V2.20↓ ADD
        'Dim OraPArray9 As Object '//優先フラグ用
        ''// V2.20↑ ADD
        '2019/04/19 DEL E N D

        Upd_Main = False

        On Error GoTo ONERR_STEP

        '2019/04/19 ADD START
        Dim cmd As New OracleCommand
        cmd.Connection = CON
        cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "BEGIN :RTNCD  := HKKET14.HKKET14B( " _
        '                & " :P_OPEID       " _
        '                & ",:P_CLTID       " _
        '                & ",:P_HINCD       " _
        '                & ",:P_VERFL       " _
        '                & ",:P_YM          " _
        '                & ",:P_HKKTRA      " _
        '                & ",:P_HKS         " _
        '                & ",:P_HMS         " _
        '                & ",:P_LMZNOS      " _
        '                & ",:P_NOS         " _
        '                & ",:P_YZS         " _
        '                & ",:P_MZS         " _
        '                & ",:P_INPS        " _
        '                & ",:P_NPS         " _
        '                & ",:P_NPF         " _
        '                & ",:P_HKKET_PATH  " _
        '                & ",:P_HKKET_FILE  " _
        '                & ",:P_ORDER_PATH  " _
        '                & ",:P_ORDER_FILE  " _
        '                & ",:P_MEMO        " _
        '                & ",:P_JNL_PATH    " _
        '                & ",:P_JNL_FILE    " _
        '                & ");              " _
        '                & "END;"
        cmd.CommandText = "HKKET14.HKKET14B"
        '2019/04/19 ADD E N D

        '2019/04/19 DEL START
        'wCNT = 37
        '2019/04/19 DEL E N D
 
        '//作業担当者
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_OPEID", gvstrOPEID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_OPEID").serverType = ORATYPE_CHAR
        Dim inP_OPEID As OracleParameter = New OracleParameter("P_OPEID", OracleDbType.Char, ParameterDirection.Input)
        inP_OPEID.Value = gvstrOPEID
        cmd.Parameters.Add(inP_OPEID)
        '2019/04/19 CHG E N D

        '//端末ID
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_CLTID", gvstrCLTID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_CLTID").serverType = ORATYPE_CHAR
        Dim inP_CLTID As OracleParameter = New OracleParameter("P_CLTID", OracleDbType.Char, ParameterDirection.Input)
        inP_CLTID.Value = gvstrCLTID
        cmd.Parameters.Add(inP_CLTID)
        '2019/04/19 CHG E N D

        '//製品コード
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_HINCD", HKKET142F.txtHINCD, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_HINCD").serverType = ORATYPE_CHAR
        Dim inP_HINCD As OracleParameter = New OracleParameter("P_HINCD", OracleDbType.Char, ParameterDirection.Input)
        inP_HINCD.Value = HKKET142F.txtHINCD.Text
        cmd.Parameters.Add(inP_HINCD)
        '2019/04/19 CHG E N D

        '//ﾊﾞｰｼﾞｮﾝ集計:1あり0なし
        '2019/04/19 CHG START
        'If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
        '    'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    clsOra.OraDatabase.Parameters.Add("P_VERFL", "0", ORAPARM_INPUT)
        'Else
        '    'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    clsOra.OraDatabase.Parameters.Add("P_VERFL", "1", ORAPARM_INPUT)
        'End If
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_VERFL").serverType = ORATYPE_CHAR
        Dim inP_VERFL As OracleParameter = New OracleParameter("P_VERFL", OracleDbType.Char, ParameterDirection.Input)
        If Not HKKET141F.optVERSION.Checked Or gvblnInputFlg Then
            inP_VERFL.Value = "0"
        Else
            inP_VERFL.Value = "1"
        End If
        cmd.Parameters.Add(inP_VERFL)
        '2019/04/19 CHG E N D

        '//表示年月
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_YM", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 6)
        Dim inP_YM As OracleParameter = New OracleParameter("P_YM", OracleDbType.Char, ParameterDirection.Input)
        inP_YM.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_YM.Size = musrHKKZTRA.strDSPMONTH.Length
        inP_YM.ArrayBindSize = New Integer(inP_YM.Size - 1) {}
        For cnt As Integer = 0 To inP_YM.Size - 1
            inP_YM.ArrayBindSize(cnt) = 6
        Next
        inP_YM.Value = musrHKKZTRA.strDSPMONTH
        cmd.Parameters.Add(inP_YM)
        '2019/04/19 CHG E N D

        '//年初計画変更:1あり0なし 
        '2019/04/19 CHG START
        'If intNensyoImportMode = 1 Then
        '    'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "1", ORAPARM_INPUT)
        'Else
        '    If gvblnLMAHMS Then
        '        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "1", ORAPARM_INPUT)
        '    Else
        '        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        clsOra.OraDatabase.Parameters.Add("P_HKKTRA", "0", ORAPARM_INPUT)
        '    End If
        'End If
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_HKKTRA").serverType = ORATYPE_CHAR
        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Dim inP_HKKTRA As OracleParameter = New OracleParameter("P_HKKTRA", OracleDbType.Char, ParameterDirection.Input)
        If intNensyoImportMode = 1 Then
            inP_HKKTRA.Value = "1"
        Else
            If gvblnLMAHMS Then
                inP_HKKTRA.Value = "1"
            Else
                inP_HKKTRA.Value = "0"
            End If
        End If
        cmd.Parameters.Add(inP_HKKTRA)
        '2019/04/19 CHG E N D

        '//年初計画変更
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_HKS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_HKS As OracleParameter = New OracleParameter("P_HKS", OracleDbType.Char, ParameterDirection.Input)
        inP_HKS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_HKS.Size = musrHKKTRA.strLMAHKS.Length
        inP_HKS.ArrayBindSize = New Integer(inP_HKS.Size - 1) {}
        For cnt As Integer = 0 To inP_HKS.Size - 1
            inP_HKS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_HKS.Value(cnt)
            If musrHKKTRA.strLMAHKS(cnt) = "" Then
                inP_HKS.Value(cnt) = Space(10)
            Else
                inP_HKS.Value(cnt) = musrHKKTRA.strLMAHKS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_HKS)
        '2019/04/19 CHG E N D

        '//見直し計画数
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_HMS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_HMS As OracleParameter = New OracleParameter("P_HMS", OracleDbType.Char, ParameterDirection.Input)
        inP_HMS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_HMS.Size = musrHKKTRA.strLMAHMS.Length
        inP_HMS.ArrayBindSize = New Integer(inP_HMS.Size - 1) {}
        For cnt As Integer = 0 To inP_HMS.Size - 1
            inP_HMS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_HMS.Value(cnt)
            If musrHKKTRA.strLMAHMS(cnt) = "" Then
                inP_HMS.Value(cnt) = Space(10)
            Else
                inP_HMS.Value(cnt) = musrHKKTRA.strLMAHMS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_HMS)
        '2019/04/19 CHG E N D

        '//入庫指示数変更:1あり0なし 
        '2019/04/19 CHG START
        'If intNensyoImportMode = 1 Then
        '    'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "1", ORAPARM_INPUT)
        'Else
        '    If gvblnLMZNOS Then
        '        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "1", ORAPARM_INPUT)
        '    Else
        '        'UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        clsOra.OraDatabase.Parameters.Add("P_LMZNOS", "0", ORAPARM_INPUT)
        '    End If
        'End If
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_LMZNOS").serverType = ORATYPE_CHAR
        Dim inP_LMZNOS As OracleParameter = New OracleParameter("P_LMZNOS", OracleDbType.Char, ParameterDirection.Input)
        If intNensyoImportMode = 1 Then
            inP_LMZNOS.Value = "1"

        Else
            If gvblnLMZNOS Then
                inP_LMZNOS.Value = "1"

            Else
                inP_LMZNOS.Value = "0"

            End If
        End If
        cmd.Parameters.Add(inP_LMZNOS)
        '2019/04/19 CHG E N D

        '//入庫指示数
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_NOS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_NOS As OracleParameter = New OracleParameter("P_NOS", OracleDbType.Char, ParameterDirection.Input)
        inP_NOS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NOS.Size = musrODINTRA.strLMZNOSS.Length
        inP_NOS.ArrayBindSize = New Integer(inP_NOS.Size - 1) {}
        For cnt As Integer = 0 To inP_NOS.Size - 1
            inP_NOS.ArrayBindSize(cnt) = 10
            ReDim Preserve inP_NOS.Value(cnt)
            If musrODINTRA.strLMZNOSS(cnt) = "" Then
                inP_NOS.Value(cnt) = Space(10)
            Else
                inP_NOS.Value(cnt) = musrODINTRA.strLMZNOSS(cnt)
            End If
        Next
        cmd.Parameters.Add(inP_NOS)
        '2019/04/19 CHG E N D

        '//予測月末在庫
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_YZS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_YZS As OracleParameter = New OracleParameter("P_YZS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_YZS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_YZS.Size = musrHKKZTRA.dblYOSLST.Length
        inP_YZS.ArrayBindSize = New Integer(inP_YZS.Size - 1) {}
        For cnt As Integer = 0 To inP_YZS.Size - 1
            inP_YZS.ArrayBindSize(cnt) = 10
        Next
        inP_YZS.Value = musrHKKZTRA.dblYOSLST
        cmd.Parameters.Add(inP_YZS)
        '2019/04/19 CHG E N D

        '//見込予測月末在庫
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_MZS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_MZS As OracleParameter = New OracleParameter("P_MZS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_MZS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_MZS.Size = musrHKKZTRA.dblMYOSLST.Length
        inP_MZS.ArrayBindSize = New Integer(inP_MZS.Size - 1) {}
        For cnt As Integer = 0 To inP_MZS.Size - 1
            inP_MZS.ArrayBindSize(cnt) = 10
        Next
        inP_MZS.Value = musrHKKZTRA.dblMYOSLST
        cmd.Parameters.Add(inP_MZS)

        '//入庫計画数（入力）
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_INPS", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 10)
        Dim inP_INPS As OracleParameter = New OracleParameter("P_INPS", OracleDbType.Char, ParameterDirection.Input)
        inP_INPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_INPS.Size = musrODINTRA.strINPPLAN.Length
        inP_INPS.ArrayBindSize = New Integer(inP_INPS.Size - 1) {}
        For cnt As Integer = 0 To inP_INPS.Size - 1
            inP_INPS.ArrayBindSize(cnt) = 10
        Next
        inP_INPS.Value = musrODINTRA.strINPPLAN
        cmd.Parameters.Add(inP_INPS)
        '2019/04/19 CHG E N D

        '//入庫計画数（表示）
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_NPS", ORAPARM_INPUT, ORATYPE_NUMBER, wCNT, 10)
        Dim inP_NPS As OracleParameter = New OracleParameter("P_NPS", OracleDbType.Decimal, ParameterDirection.Input)
        inP_NPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NPS.Size = musrODINTRA.dblDspINPPLAN.Length
        inP_NPS.ArrayBindSize = New Integer(inP_NPS.Size - 1) {}
        For cnt As Integer = 0 To inP_NPS.Size - 1
            inP_NPS.ArrayBindSize(cnt) = 10
        Next
        inP_NPS.Value = musrODINTRA.dblDspINPPLAN
        cmd.Parameters.Add(inP_NPS)
        '2019/04/19 CHG E N D

        '//優先フラグ
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.AddTable("P_NPF", ORAPARM_INPUT, ORATYPE_CHAR, wCNT, 4)
        Dim inP_NPF As OracleParameter = New OracleParameter("P_NPF", OracleDbType.Char, ParameterDirection.Input)
        inP_NPF.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inP_NPF.Size = musrODINTRA.strLMZNPF.Length
        inP_NPF.ArrayBindSize = New Integer(inP_NPF.Size - 1) {}
        For cnt As Integer = 0 To inP_NPF.Size - 1
            inP_NPF.ArrayBindSize(cnt) = 4
            ReDim Preserve inP_NPF.Value(cnt)
            inP_NPF.Value(cnt) = Mid(Trim(musrODINTRA.strLMZNPF(cnt)) & "    ", 1, 4)
        Next
        cmd.Parameters.Add(inP_NPF)
        '2019/04/19 CHG E N D

        '//ファイルパス
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_HKKET_PATH", gvstrFilePath5, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_HKKET_PATH").serverType = ORATYPE_CHAR
        Dim inP_HKKET_PATH As OracleParameter = New OracleParameter("P_HKKET_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_HKKET_PATH.Value = gvstrFilePath5
        cmd.Parameters.Add(inP_HKKET_PATH)
        '2019/04/19 CHG E N D

        '//ファイルＩＤ
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_HKKET_FILE", gvstrFileName5 & VB6.Format(Now, "YYYYMMDD") & ".CSV", ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_HKKET_FILE").serverType = ORATYPE_CHAR
        Dim inP_HKKET_FILE As OracleParameter = New OracleParameter("P_HKKET_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_HKKET_FILE.Value = gvstrFileName5 & VB6.Format(Now, "YYYYMMDD") & ".CSV"
        cmd.Parameters.Add(inP_HKKET_FILE)
        '2019/04/19 CHG E N D

        '//ファイルパス
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_ORDER_PATH", gvstrFilePath6, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_ORDER_PATH").serverType = ORATYPE_CHAR
        Dim inP_ORDER_PATH As OracleParameter = New OracleParameter("P_ORDER_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_ORDER_PATH.Value = gvstrFilePath6
        cmd.Parameters.Add(inP_ORDER_PATH)
        '2019/04/19 CHG E N D

        '//ファイルＩＤ
        pstr_FileName = gvstrFileName6 & "_" & HKKET142F.txtHINCD.Text & "_" & VB6.Format(Now, "YYYYMMDD") & "_" & VB6.Format(Now, "HHMMSS") & ".CSV"
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_ORDER_FILE", pstr_FileName, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_ORDER_FILE").serverType = ORATYPE_CHAR
        Dim inP_ORDER_FILE As OracleParameter = New OracleParameter("P_ORDER_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_ORDER_FILE.Value = pstr_FileName
        cmd.Parameters.Add(inP_ORDER_FILE)
        '2019/04/19 CHG E N D

        '//メモ
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_MEMO", HKKET142F.txtMEMO.Text, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_MEMO").serverType = ORATYPE_CHAR
        Dim inP_MEMO As OracleParameter = New OracleParameter("P_MEMO", OracleDbType.Char, ParameterDirection.Input)
        inP_MEMO.Value = HKKET142F.txtMEMO.Text
        cmd.Parameters.Add(inP_MEMO)
        '2019/04/19 CHG E N D

        '//ファイルパス
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_JNL_PATH", gvstrFilePath7, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_JNL_PATH").serverType = ORATYPE_CHAR
        Dim inP_JNL_PATH As OracleParameter = New OracleParameter("P_JNL_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_JNL_PATH.Value = gvstrFilePath7
        cmd.Parameters.Add(inP_JNL_PATH)
        '2019/04/19 CHG E N D

        '//ファイルＩＤ
        pstr_FileName = gvstrFileName7 & "_" & VB6.Format(Now, "YYYYMM") & ".CSV"
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("P_JNL_FILE", pstr_FileName, ORAPARM_INPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_CHAR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("P_JNL_FILE").serverType = ORATYPE_CHAR
        Dim inP_JNL_FILE As OracleParameter = New OracleParameter("P_JNL_FILE", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_JNL_FILE.Value = pstr_FileName
        cmd.Parameters.Add(inP_JNL_FILE)
        '2019/04/19 CHG E N D

        '//戻り値
        intRtnCd = 0
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト ORATYPE_NUMBER の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER
        'change start 20190925 kuwa test
        'Dim outRTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.Output)
        Dim outRTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.ReturnValue)
        'change end 20190925 kuwa
        'add test start 20190925 kuwa
        outRTNCD.Value = 0
        'add end 20190925 kuwa
        cmd.Parameters.Add(outRTNCD)
        '2019/04/19 CHG E N D 

        '2019/04/19 DEL START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray1 = clsOra.OraDatabase.Parameters("P_YM")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray2 = clsOra.OraDatabase.Parameters("P_HKS")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray3 = clsOra.OraDatabase.Parameters("P_HMS")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray4 = clsOra.OraDatabase.Parameters("P_NOS")
        ''// 2007/01/09 ↓ ADD STR
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray5 = clsOra.OraDatabase.Parameters("P_YZS")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray6 = clsOra.OraDatabase.Parameters("P_MZS")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray7 = clsOra.OraDatabase.Parameters("P_INPS")
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray8 = clsOra.OraDatabase.Parameters("P_NPS")
        ''// 2007/01/09 ↑ ADD END
        ''// V2.20↓ ADD
        ''//優先フラグ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'OraPArray9 = clsOra.OraDatabase.Parameters("P_NPF")
        ''// V2.20↑ ADD
        '2019/04/19 DEL E N D

        '2019/04/19 DEL START
        'For i = LBound(musrHKKZTRA.strDSPMONTH) To UBound(musrHKKZTRA.strDSPMONTH)
        '    '//表示年月
        '    'UPGRADE_WARNING: オブジェクト OraPArray1.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray1.put_Value(musrHKKZTRA.strDSPMONTH(i), i)
        '    '//年初計画
        '    'UPGRADE_WARNING: オブジェクト OraPArray2.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray2.put_Value(musrHKKTRA.strLMAHKS(i), i)
        '    '//見直計画
        '    'UPGRADE_WARNING: オブジェクト OraPArray3.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray3.put_Value(musrHKKTRA.strLMAHMS(i), i)
        '    '//入庫指示数
        '    'UPGRADE_WARNING: オブジェクト OraPArray4.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray4.put_Value(musrODINTRA.strLMZNOSS(i), i)
        '    '// 2007/01/09 ↓ ADD STR
        '    '//予測月末在庫
        '    'UPGRADE_WARNING: オブジェクト OraPArray5.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray5.put_Value(musrHKKZTRA.dblYOSLST(i), i)
        '    '//前月予測月末在庫
        '    'UPGRADE_WARNING: オブジェクト OraPArray6.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray6.put_Value(musrHKKZTRA.dblMYOSLST(i), i)
        '    '//入庫計画数
        '    'UPGRADE_WARNING: オブジェクト OraPArray7.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray7.put_Value(musrODINTRA.strINPPLAN(i), i)
        '    '//入庫計画数
        '    'UPGRADE_WARNING: オブジェクト OraPArray8.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray8.put_Value(musrODINTRA.dblDspINPPLAN(i), i)
        '    '// 2007/01/09 ↑ ADD END
        '    '// V2.20↓ ADD
        '    '//優先フラグ
        '    'UPGRADE_WARNING: オブジェクト OraPArray9.put_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    OraPArray9.put_Value(Mid(Trim(musrODINTRA.strLMZNPF(i)) & "    ", 1, 4), i)
        '    '// V2.20↑ ADD
        'Next i
        '2019/04/19 DEL E N D

        '//PL/SQLを呼ぶ（MAIN）
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraExecute の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If Not clsOra.OraExecute("BEGIN :RTNCD  := HKKET14.HKKET14B( " & " :P_OPEID ,:P_CLTID ,:P_HINCD ,:P_VERFL " & ",:P_YM          " & ",:P_HKKTRA      " & ",:P_HKS         " & ",:P_HMS         " & ",:P_LMZNOS      " & ",:P_NOS         " & ",:P_YZS         " & ",:P_MZS         " & ",:P_INPS        " & ",:P_NPS         " & ",:P_NPF         " & ",:P_HKKET_PATH  " & ",:P_HKKET_FILE  " & ",:P_ORDER_PATH  " & ",:P_ORDER_FILE  " & ",:P_MEMO        " & ",:P_JNL_PATH    " & ",:P_JNL_FILE    " & ");              " & "END;", , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        cmd.ExecuteNonQuery()
        '2019/04/19 CHG E N D
 
        '//戻り値異常
        '2019/04/19 CHG START
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If clsOra.OraDatabase.Parameters("RTNCD").Value <> 0 Then
        '    GoTo EXIT_STEP
        'End If
        If outRTNCD.Value.ToString <> 0 Then
            GoTo EXIT_STEP
        End If
        '2019/04/19 CHG E N D 

        Upd_Main = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
        '2019/04/19 CHG START
        ''//戻り値
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        ''//作業担当者
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_OPEID")
        ''//端末ID
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_CLTID")
        ''//製品コード
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HINCD")
        ''//ﾊﾞｰｼﾞｮﾝ集計:1あり0なし
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_VERFL")
        ''//表示年月
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_YM")
        ''//年初計画変更:1あり0なし
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HKKTRA")
        ''//年初計画
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HKS")
        ''//見直計画
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HMS")
        ''//入庫指示数変更:1あり0なし
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_LMZNOS")
        ''//入庫指示数
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_NOS")
        ''// 2007/01/09 ↓ ADD STR
        ''//予測月末在庫数
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_YZS")
        ''//見込予測月末在庫数
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_MZS")
        ''//入庫計画数（入力）
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_INPS")
        ''//入庫計画数（表示）
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_NPS")
        ''// 2007/01/09 ↑ ADD END
        ''// V2.20↓ ADD
        ''//優先フラグ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_NPF")
        ''// V2.20↑ ADD
        ''//ファイルパス
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HKKET_PATH")
        ''//ファイルＩＤ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_HKKET_FILE")
        ''//ファイルパス
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_ORDER_PATH")
        ''//ファイルＩＤ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_ORDER_FILE")
        ''//ファイルＩＤ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_MEMO")
        ''// V2.30↓ ADD
        ''//ファイルパス
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_JNL_PATH")
        ''//ファイルＩＤ
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("P_JNL_FILE")
        ''// V2.30↑ ADD
        ''//戻り値
        ''UPGRADE_WARNING: オブジェクト clsOra.OraDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        cmd.Parameters.Clear()
        '2019/04/19 CHG E N D

        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
	
	'// 2008/05/27 ↓ ADD END 計画単価の取得
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Get_KEIKAKUTANKA
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    ﾊﾞｰｼﾞｮﾝ集計時に計画単価を取得する
	'//*****************************************************************************************
	Public Function Get_KEIKAKUTANKA() As Boolean
		
		Const PROCEDURE As String = "Get_KEIKAKUTANKA"
		
		Dim strSQL As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim objRec As OraDynaset
		
		Get_KEIKAKUTANKA = False
		
		On Error GoTo ONERR_STEP
		
		' SQL文の作成
		strSQL = ""
		strSQL = strSQL & " SELECT HINMTA.PLANTK PLANTK" & vbCrLf
		strSQL = strSQL & " FROM   ( " & vbCrLf
		strSQL = strSQL & "         SELECT * " & vbCrLf
		strSQL = strSQL & "         FROM   ( " & vbCrLf
		strSQL = strSQL & "                 SELECT * " & vbCrLf
		strSQL = strSQL & "                 FROM   HKKZTRA " & vbCrLf
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "                 WHERE  HINCD LIKE " & D0.Edt_SQL("S", Trim(Mid(HKKET142F.txtHINCD.Text, 1, 6)) & "%") & vbCrLf
		strSQL = strSQL & "                   AND  VERFL = 0" & vbCrLf
		strSQL = strSQL & "                 ORDER BY HINCD DESC" & vbCrLf
		strSQL = strSQL & "                ) V1" & vbCrLf
		strSQL = strSQL & "         WHERE  ROWNUM = 1" & vbCrLf
		strSQL = strSQL & "        ) V2" & vbCrLf
		strSQL = strSQL & "        ,HINMTA " & vbCrLf
		strSQL = strSQL & " WHERE  HINMTA.HINCD (+) = V2.HINCD" & vbCrLf

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190927 kuwa
        '      If Not clsOra.OraCreateDyn(strSQL, objRec,  , PROCEDURE) Then
        '	GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190927 kuwa
        'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190927 kuwa
        'HKKET142F.txtPLANTK.Text = D0.Chk_Null(objRec("PLANTK"))
        HKKET142F.txtPLANTK.Text = D0.Chk_Null(dt.Rows(0)("PLANTK"))
        'change end 20190927 kuwa

        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'delete start 20190927 kuwa
        'clsOra.OraCloseDyn(objRec)
        'delete end 20190927 kuwa

        Get_KEIKAKUTANKA = True
		
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
	'// 2008/05/27 ↑ ADD END
	
	'// V2.20↓ ADD
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Chk_YuusenFlg
	'//*
	'//* <戻り値>   型                  説明
	'//*            Boolean             True:OK , False:Error
	'//*
	'//* <引  数>   項目名              型              I/O     内容
	'//*
	'//* <説  明>
	'//*    優先フラグの入力状況を確認する
	'//*****************************************************************************************
	Public Function Chk_YuusenFlg() As Boolean
		
		Const PROCEDURE As String = "Chk_YuusenFlg"
		
		Dim i As Short
		Dim intErrFlg As Short
		Dim intErrIdx As Short
		
		Chk_YuusenFlg = False
		
		On Error GoTo ONERR_STEP
		
		intErrFlg = 0
		
		For i = 0 To UBound(musrODINTRA.strINPPLAN)
			
			'//入力Check
			If Val(Trim(musrODINTRA.strINPPLAN(i))) = 0 And Val(Trim(musrODINTRA.strLMZNPF(i))) = 1 Then
				'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "226", vbCrLf & "入庫計画(連携)が 0(ゼロ) のため、優先を 1 にすることができません。 [" & VB6.Format(musrHKKZTRA.strDSPMONTH(i), "0000年00月") & "]")
				intErrFlg = 1
				intErrIdx = i
				Exit For
			End If
			
			'//入力Check
			If Val(Trim(musrODINTRA.strLMZNPF(i))) <> 1 And Val(Trim(musrODINTRA.strLMZNPF(i))) <> 0 Then
				'UPGRADE_WARNING: オブジェクト ClsMessage.MsgLibrary の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "226", vbCrLf & "入庫計画(優先)は 0(ゼロ) 又は 1 の入力です。[" & VB6.Format(musrHKKZTRA.strDSPMONTH(i), "0000年00月") & "]")
				intErrFlg = 1
				intErrIdx = i
				Exit For
			End If
			
		Next i
		
		If intErrFlg = 0 Then
			Chk_YuusenFlg = True
		Else
			Chk_YuusenFlg = False
		End If
		
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
	'// V2.20↑ ADD
End Module