Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	Private Const FM_PANEL3D1_CNT As Short = 13 'パネルコントロール数
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Init_Def_Dsp
	'   概要：  各画面の項目情報を設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Init_Def_Dsp() As Short
		
		Dim Index_Wk As Short
		Dim BD_Cnt As Short
		Dim Wk_Cnt As Short
		
		'画面基礎共通情報設定
		Call CF_Init_Def_Dsp(Me, Main_Inf)
		
		'/////////////////////
		'// メッセージ共通設定
		'/////////////////////
		Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
		Main_Inf.On_IM_Denkyu = IM_Denkyu(1)
		Main_Inf.Off_IM_Denkyu = IM_Denkyu(2)
		Main_Inf.Dsp_TX_Message = TX_Message
		
		
		'画面基礎情報設定
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REFERENCE '画面分類
			.Item_Cnt = 183 '画面項目数
			.Dsp_Body_Cnt = 15 '画面表示明細数（０：明細なし、１～：表示時明細数）
			.Max_Body_Cnt = 200 '最大表示明細数（０：明細なし、１～：最大明細数）
			.Body_Col_Cnt = 9 '明細の列項目数
			.Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1 '画面移動量
			.FormCtl = Me
		End With
		
		'選択明細オプションボタン画像設定♪
		HIKET54_Bd_Sel_Img.Click_Off_Img = IM_Opt(0)
		HIKET54_Bd_Sel_Img.Click_On_Img = IM_Opt(1)
		
		'画面項目情報
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'/////////////////////
		'// 全画面用制御用ｺﾝﾄﾛｰﾙ
		'/////////////////////
		'初期設定用タイマー
		Main_Inf.TM_StartUp_Ctl = TM_StartUp
		Main_Inf.TM_StartUp_Ctl.Interval = 1
		Main_Inf.TM_StartUp_Ctl.Enabled = True
		
		Index_Wk = 0
		'カーソル制御用テキスト
		TX_CursorRest.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// メニュー部編集
		'///////////////////
		Index_Wk = Index_Wk + 1
		'処理１
		MN_Ctrl.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'実行
		MN_Execute.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'画面印刷
		MN_HARDCOPY.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'終了
		MN_EndCm.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'処理２
		MN_EditMn.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'項目初期化
		MN_ClearItm.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'項目復元
		MN_UnDoItem.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'切り取り
		MN_Cut.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'コピー
		MN_Copy.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'貼り付け
		MN_Paste.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'操作３
		MN_Oprt.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'選択
		MN_SELECTCM.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_SELECTCM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'前ページ
		MN_PREV.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_PREV
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'次ページ
		MN_NEXTCM.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_NEXTCM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'候補の一覧
		MN_Slist.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'項目内容にコピー
		SM_AllCopy.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'取り消し
		SM_Esc.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'項目に貼り付け
		SM_FullPast.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'終了イメージ
		CM_EndCm.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ｲﾒｰｼﾞ設定 ======================
		Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
		Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
		'=== ｲﾒｰｼﾞ設定 ======================
		
		Index_Wk = Index_Wk + 1
		'実行イメージ
		CM_Execute.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ｲﾒｰｼﾞ設定 ======================
		Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
		Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
		'=== ｲﾒｰｼﾞ設定 ======================
		
		Index_Wk = Index_Wk + 1
		'検索画面表示イメージ
		CM_SLIST.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ｲﾒｰｼﾞ設定 ======================
		Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
		Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
		'=== ｲﾒｰｼﾞ設定 ======================
		
		Index_Wk = Index_Wk + 1
		'ヘッダイメージ
		Image1.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'検索イメージ
		CM_SELECTCM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SELECTCM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ｲﾒｰｼﾞ設定 ======================
		Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SELECTCM(0)
		Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SELECTCM(1)
		'=== ｲﾒｰｼﾞ設定 ======================
		
		Index_Wk = Index_Wk + 1
		'処理日付
		'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SYSDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// ヘッダ部編集
		'///////////////////
		Index_Wk = Index_Wk + 1
		'製番
		HD_SBNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		'UPD 20160216 START C2-20160129-01
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
		'UPD 20160216 END C2-20160129-01
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'製品コードボタン
		'UPGRADE_WARNING: オブジェクト CS_HINCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'製品コード
		HD_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		'''' UPD 2009/02/20  FKS) S.Nakajima    Start
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'''' UPD 2009/02/20  FKS) S.Nakajima    End
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'型式
		HD_HINNMA.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'品名
		HD_HINNMB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		
		Index_Wk = Index_Wk + 1
		'入力担当者(ｺｰﾄﾞ)
		HD_IN_TANCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'入力担当者(名称)
		HD_IN_TANNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////
		'// ボディ部編集
		'///////////////
		
		Index_Wk = Index_Wk + 1
		'縦スクロール
		VS_Scrl.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = VS_Scrl
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== 明細縦スクロールバー設定 ======================
		Main_Inf.Bd_Vs_Scrl = VS_Scrl
		'=== 明細縦スクロールバー設定 ======================
		
		Index_Wk = Index_Wk + 1
		'選択明細オプションボタン(ﾋﾟｸﾁｬｰ)
		BD_SELECTB(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ
		
		Index_Wk = Index_Wk + 1
		'出荷予定日
		BD_OUTYTDT(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTDT(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'数量
		BD_OUTYTSU(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTSU(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'元製番
		BD_ORGSBNNO(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ORGSBNNO(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPD 20160216 START C2-20160129-01
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
		'UPD 20160216 END C2-20160129-01
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'出庫理由
		BD_OUTRSNNM(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTRSNNM(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'得意先略称
		BD_TOKRN(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'仕入先略称
		BD_SIRRN(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIRRN(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'登録日
		BD_WRTFSTDT(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WRTFSTDT(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'倉庫名
		BD_SOUNM(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			BD_SELECTB.Load(BD_Cnt) '選択明細オプションボタン(ﾋﾟｸﾁｬｰ(BD_Cnt)
			BD_OUTYTDT.Load(BD_Cnt) '出庫予定日
			BD_OUTYTSU.Load(BD_Cnt) '数量
			BD_ORGSBNNO.Load(BD_Cnt) '元製番
			BD_OUTRSNNM.Load(BD_Cnt) '出庫理由名
			BD_TOKRN.Load(BD_Cnt) '得意先略称
			BD_SIRRN.Load(BD_Cnt) '仕入先略称
			BD_WRTFSTDT.Load(BD_Cnt) '登録日
			BD_SOUNM.Load(BD_Cnt) '倉庫名
			
			Index_Wk = Index_Wk + 1
			'選択明細オプションボタン(ﾋﾟｸﾁｬｰ)
			BD_SELECTB(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'出庫予定日
			BD_OUTYTDT(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTDT(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'数量
			BD_OUTYTSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTSU(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'元製番
			BD_ORGSBNNO(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ORGSBNNO(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'出庫理由名
			BD_OUTRSNNM(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTRSNNM(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'得意先略称
			BD_TOKRN(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'仕入先略称
			BD_SIRRN(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIRRN(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'登録日
			BD_WRTFSTDT(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WRTFSTDT(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'倉庫名
			BD_SOUNM(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'明細部の１行上の情報を設定
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
		Next 
		
		'///////////////
		'// フッタ部編集
		'///////////////
		Index_Wk = Index_Wk + 1
		'引当／解除ボタン
		'UPGRADE_WARNING: オブジェクト CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_HIK.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HIK
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ
		
		'///////////////////
		'// メッセージ部編集
		'///////////////////
		Index_Wk = Index_Wk + 1
		'メッセージ
		TX_Message.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Message
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'TX_Mode
		TX_Mode.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// その他編集
		'///////////////////
		For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
			Index_Wk = Index_Wk + 1
			'FM_Panel3D1
			'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
			'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		Next 
		
		'上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
		Call CF_Init_Item_Property(Main_Inf)
		'画面項目情報を再設定
		Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)
		
		'///////////////////
		'// 特別項目の再設定
		'///////////////////
		'カーソル制御用テキスト
		TX_CursorRest.TabStop = False
		TX_Message.TabStop = False
		gv_bolHIKET54_LF_Enable = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_VbKeyReturn
	'   概要：  各項目のVBKEYRETURN制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyReturn(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
			'キーフラグを元に戻す
			gv_bolKeyFlg = False
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_VbKeyRight
	'   概要：  各項目のVBKEYRIGHT制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyRight(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYRIGHT制御
		Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			'取得内容表示/クリア
			Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
				Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_VbKeyDown
	'   概要：  各項目のVBKEYDOWN制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyDown(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = False
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			'KEYDOWN制御
			Call SSSMAIN0001.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			If Move_Flg = True Then
				'次の項目へ移動した場合
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				
				'項目色設定
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_VbKeyLeft
	'   概要：  各項目のVBKEYLEFT制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyLeft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYLEFT制御
		Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			'取得内容表示/クリア
			Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
				Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_VbKeyUp
	'   概要：  各項目のVBKEYUP制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyUp(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			'KEYUP制御
			Call SSSMAIN0001.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			
			If Move_Flg = True Then
				'次の項目へ移動した場合
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				
				'項目色設定
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
			End If
			
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyDown
	'   概要：  各項目のKEYDOWN制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef pm_KeyCode As Short, ByRef pm_Shift As Short) As Short
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		
		'Enter時のみフラグをON
		If pm_KeyCode = System.Windows.Forms.Keys.Return Then
			If gv_bolKeyFlg = True Then
				Exit Function
			End If
			
			gv_bolKeyFlg = True
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case True
			'ｴﾝﾀｰｷｰ押
			Case pm_KeyCode = System.Windows.Forms.Keys.Return And pm_Shift = 0
				pm_KeyCode = 0
				'ｴﾝﾀｰｷｰ制御
				Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'→押
			Case pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 0
				pm_KeyCode = 0
				'→制御
				Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'↓押
			Case pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 0
				pm_KeyCode = 0
				'↓制御
				Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'←押
			Case pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 0
				pm_KeyCode = 0
				'←制御
				Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'↑押
			Case pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 0
				'↑制御
				pm_KeyCode = 0
				Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'DELETE押
			Case pm_KeyCode = System.Windows.Forms.Keys.Delete And pm_Shift = 0
				pm_KeyCode = 0
				Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
				'INSERT押
			Case pm_KeyCode = System.Windows.Forms.Keys.Insert And pm_Shift = 0
				pm_KeyCode = 0
				Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
				'TAB押
			Case pm_KeyCode = System.Windows.Forms.Keys.F16
				pm_KeyCode = 0
				'ｴﾝﾀｰｷｰ制御
				Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'Shift+TAB押
			Case pm_KeyCode = System.Windows.Forms.Keys.F15
				pm_KeyCode = 0
				'前ﾌｫｰｶｽ位置へ移動
				Call SSSMAIN0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
				'ファンクションキー押下時
			Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
				'ファンクションキー共通処理
				Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
				
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_LostFocus
	'   概要：  各項目のLOSTFOCUS制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_LostFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		If gv_bolHIKET54_LF_Enable = False Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'ﾛｽﾄﾌｫｰｶｽ実行判定
		If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
			Main_Inf.Dsp_Base.LostFocus_Flg = False
			Exit Function
		End If
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_GotFocus
	'   概要：  各項目のGOTFOCUS制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_GotFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Wk_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'画面単位の処理(ﾁｪｯｸなど)
		'①明細部でﾌｫｰｶｽを受け取った場合のヘッダ部の入力ﾁｪｯｸなど
		'明細部でかつ移動前が明細部でない場合
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'ﾍｯﾀﾞ部ﾁｪｯｸ
			Rtn_Chk = SSSMAIN0001.F_Ctl_Head_Chk(Main_Inf)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If
		
		'UPGRADE_WARNING: オブジェクト CS_HIK.NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Ctl Is SSCommand5 And pm_Ctl.Name <> CS_HIK.NAME Then
			'検索画面呼出の場合は終了
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
			'明細行コントロールか判定
			If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
				'明細検索ボタンの明細行数変数に同じ行数を設定
				For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
					'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
						'設定済みの場合は終了
						Exit For
					End If
					'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
				Next 
			End If
		Else
			'明細検索ボタンの明細行数変数を初期化
			For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
					'設定済みの場合は終了
					Exit For
				End If
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
			Next 
		End If
		
		'②明細部内での次行へ移動した場合のﾁｪｯｸなど
		
		'共通ﾌｫｰｶｽ取得処理
		Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
		'処理１
		Call Ctl_MN_Ctrl_Click()
		'処理２
		Call Ctl_MN_EditMn_Click()
		'操作３
		Call Ctl_MN_Oprt_Click()
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyPress
	'   概要：  各項目のKEYPRESS制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyPress(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef pm_KeyAscii As Short) As Short
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'共通KEYPRESS制御
		Call SSSMAIN0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			'取得内容表示/クリア
			Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call SSSMAIN0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				
				'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			End If
			
		Else
			'項目色設定(入力開始で色をﾌｫｰｶｽありの前景色＝黒に設定！！)
			Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_Change
	'   概要：  各項目のCHANG制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		
		If Main_Inf.Dsp_Base.Change_Flg = True Then
			Main_Inf.Dsp_Base.Change_Flg = False
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'共通KEYCHANG制御
		Call SSSMAIN0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
		'画面単位の処理(ﾁｪｯｸなど)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_MouseUp
	'   概要：  各項目のMOUSEUP制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseUp(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
				
			Case TypeOf pm_Ctl Is SSPanel5
				'パネルの場合
				Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case TypeOf pm_Ctl Is SSCommand5
				'ボタンの場合
				'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
				If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
					Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				End If
				
			Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'イメージの場合
				Select Case Trg_Index
					Case CShort(CM_EndCm.Tag)
						'終了ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
					Case CShort(CM_Execute.Tag)
						'実行ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
						
					Case CShort(CM_SLIST.Tag)
						'検索画面表示ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
						
					Case CShort(CM_SELECTCM.Tag)
						'検索ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)
				End Select
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_MouseMove
	'   概要：  各項目のMOUSEMOVE制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseMove(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(Image1.Tag)
				'ｲﾒｰｼﾞ１初期化
				Call CF_Clr_Prompt(Main_Inf)
				
			Case CShort(CM_EndCm.Tag)
				'終了ｲﾒｰｼﾞ
				Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
			Case CShort(CM_Execute.Tag)
				'実行ｲﾒｰｼﾞ
				Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
			Case CShort(CM_SLIST.Tag)
				'検索画面ｲﾒｰｼﾞ
				Call CF_Set_Prompt(IMG_SLIST_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
			Case CShort(CM_SELECTCM.Tag)
				'検索？ｲﾒｰｼﾞ
				Call CF_Set_Prompt(IMG_SELECTCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_MouseDown
	'   概要：  各項目のMOUSEDOWN制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(CM_EndCm.Tag)
				'終了ｲﾒｰｼﾞ
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)
				
			Case CShort(CM_Execute.Tag)
				'実行ｲﾒｰｼﾞ
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)
				
			Case CShort(CM_SLIST.Tag)
				'検索画面表示ｲﾒｰｼﾞ
				'「選択」判定
				Select Case Act_Index
					Case CShort(Me.HD_SBNNO.Tag), CShort(Me.HD_HINCD.Tag)
						
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
						
					Case Else
						
				End Select
				
			Case CShort(CM_SELECTCM.Tag)
				'検索ｲﾒｰｼﾞ
				'「選択」判定
				Select Case Act_Index
					Case CShort(Me.HD_SBNNO.Tag), CShort(Me.HD_HINCD.Tag)
						
					Case Else
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)
						
				End Select
				
		End Select
		
		Select Case pm_Ctl.Name
			Case BD_SELECTB(1).Name
				'選択明細オプションボタンイメージ
				Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET54_Bd_Sel_Index)
				Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case Else
				
		End Select
		
		'共通MOUSEDOWN制御
		Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_Click
	'   概要：  各項目のCLICK制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: オブジェクト CS_HINCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			Case CShort(CM_SLIST.Tag), CShort(CS_HINCD.Tag)
				
				If Main_Inf.Dsp_Base.Head_Ok_Flg = True Then
					Exit Function
				End If
			Case Else
		End Select
		
		'各検索画面呼出
		'UPGRADE_WARNING: オブジェクト CS_HINCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			'■メニュー
			Case CShort(MN_Ctrl.Tag)
				'処理１
				Call Ctl_MN_Ctrl_Click()
				
			Case CShort(MN_Execute.Tag)
				'実行
				Call Ctl_MN_Execute_Click()
				
				'        Case CInt(MN_DeleteCM.Tag)
				'            '削除
				'            Call Ctl_MN_DeleteCM_Click
				
			Case CShort(MN_HARDCOPY.Tag)
				'画面印刷
				Call Ctl_MN_HARDCOPY_Click()
				
			Case CShort(MN_EndCm.Tag)
				'終了
				Call Ctl_MN_EndCm_Click()
				Exit Function
				
			Case CShort(MN_EditMn.Tag)
				'処理２
				Call Ctl_MN_EditMn_Click()
				
				'        Case CInt(MN_APPENDC.Tag)
				'            '画面初期化
				'            Call Ctl_MN_APPENDC_Click
				
			Case CShort(MN_ClearItm.Tag)
				'項目初期化
				Call Ctl_MN_ClearItm_Click()
				
			Case CShort(MN_UnDoItem.Tag)
				'項目復元
				Call Ctl_MN_UnDoItem_Click()
				
				'        Case CInt(MN_ClearDE.Tag)
				'            '明細行初期化
				'            Call Ctl_MN_ClearDE_Click
				'
				'        Case CInt(MN_DeleteCM.Tag)
				'            '明細行削除
				'            Call Ctl_MN_DeleteDE_Click
				'
				'        Case CInt(MN_InsertDE.Tag)
				'            '明細行挿入
				'            Call Ctl_MN_InsertDE_Click
				'
				'        Case CInt(MN_UnDoDe.Tag)
				'            '明細行復元
				'            Call Ctl_MN_UnDoDe_Click
				
			Case CShort(MN_Cut.Tag)
				'切り取り
				Call Ctl_MN_Cut_Click()
				
			Case CShort(MN_Copy.Tag)
				'コピー
				Call Ctl_MN_Copy_Click()
				
			Case CShort(MN_Paste.Tag)
				'貼り付け
				Call Ctl_MN_Paste_Click()
				
			Case CShort(MN_Oprt.Tag)
				'操作３
				Call Ctl_MN_Oprt_Click()
				
			Case CShort(MN_SELECTCM.Tag)
				'選択（明細部クリア）
				Call Ctl_MN_SELECTCM_Click()
				
				'        Case CInt(MN_PREV.Tag)
				'            '前ページ
				'            Call Ctl_MN_PREV_Click
				'
				'        Case CInt(MN_NEXTCM.Tag)
				'            '次ページ
				'            Call Ctl_MN_NEXTCM_Click
				
			Case CShort(MN_Slist.Tag)
				'候補の一覧
				Call Ctl_MN_Slist_Click()
				
			Case CShort(SM_AllCopy.Tag)
				'項目内容にコピー
				Call Ctl_SM_AllCopy_Click()
				
			Case CShort(SM_Esc.Tag)
				'取り消し
				Call Ctl_SM_Esc_Click()
				
			Case CShort(SM_FullPast.Tag)
				'項目に貼り付け
				Call Ctl_SM_FullPast_Click()
				
				'■メニューイメージ
			Case CShort(CM_EndCm.Tag)
				'終了
				Call Ctl_MN_EndCm_Click()
				Exit Function
				
			Case CShort(CM_Execute.Tag)
				'実行
				Call Ctl_MN_Execute_Click()
				
			Case CShort(CM_SLIST.Tag)
				'検索W表示
				Call Ctl_MN_Slist_Click()
				
			Case CShort(CM_SELECTCM.Tag)
				'選択（明細部クリア）
				Call Ctl_MN_SELECTCM_Click()
				
				'■ほか
			Case CShort(CS_HIK.Tag)
				'引当／解除ボタン
				Call Ctl_CS_HIK_Click()
				
			Case CShort(CS_HINCD.Tag)
				'製品検索画面呼出
				Call SSSMAIN0001.F_Ctl_CS_HINCD(Main_Inf)
				
		End Select
		
		'ステータスバー初期化
		Call CF_Clr_Prompt(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyUp
	'   概要：  各項目のCLICK制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Act_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Act_Index = CShort(pm_Ctl.Tag)
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		
		'各検索画面呼出
		Select Case Act_Index
			Case CShort(HD_SBNNO.Tag)
				'製番のﾃｷｽﾄへﾌｫｰｶｽ移動
				
			Case CShort(HD_HINCD.Tag)
				'製品ｺｰﾄﾞのﾃｷｽﾄへﾌｫｰｶｽ移動
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_VS_Scrl_Change
	'   概要：  縦スクロールのCHANGE制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_VS_Scrl_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		
		If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
			Main_Inf.Dsp_Base.VS_Scr_Flg = False
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'共通VS_SCRL_CHANGE制御
		Call SSSMAIN0001.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		'行選択
		Trg_Index = CShort(BD_SELECTB(1).Tag)
		Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Ctrl_Click
	'   概要：  メニュー処理１の使用可不可を制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Ctrl_Click() As Short
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Head_Ok_Flg = False (ヘッダにフォーカスがある場合)
		If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
			'｢実行｣使用可能
			MN_Execute.Enabled = True
		Else
			'｢実行｣使用不可
			MN_Execute.Enabled = False
		End If
		'｢画面印刷｣判定
		MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢終了｣判定
		MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_EditMn_Click
	'   概要：  メニュー処理２の使用可不可を制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_EditMn_Click() As Short
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'｢項目初期化｣判定
		MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢項目復元｣判定
		MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢切り取り｣判定
		MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢コピー｣判定
		MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢貼り付け｣判定
		MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Oprt_Click
	'   概要：  メニュー操作３の使用可不可を制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Oprt_Click() As Short
		
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'「選択」判定
		Select Case Ant_Index
			Case CShort(Me.HD_SBNNO.Tag), CShort(Me.HD_HINCD.Tag)
				
				MN_SELECTCM.Enabled = False
				
			Case Else
				MN_SELECTCM.Enabled = True
				
		End Select
		'メニュー使用可/不可制御
		'メニュー内容に合わせて変更する
		'｢候補の一覧｣初期化
		MN_Slist.Enabled = False
		
		'使用可制御
		'ｱｸﾃｨﾌﾞな項目の検索機能がある場合、使用可
		'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Select Case Me.ActiveControl.Name
			Case HD_HINCD.Name
				'検索機能のある入力項目の場合
				
				MN_Slist.Enabled = True
		End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Execute_Click
	'   概要：  メニュー動作（実行）
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Execute_Click() As Short
		
		Dim Wk_Index As Short
		
		If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
			'（ヘッダ部入力後、確定する動きと同じ）
			Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx
			Call SSSMAIN0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, True, Main_Inf)
		End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_APPENDC_Click
	'   概要：  画面初期化制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_APPENDC_Click() As Short
		
		'画面内容初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'ヘッダ部入力制御
		Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
		
		'画面ボディ部初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面明細表示
		Call CF_Body_Dsp(Main_Inf)
		
		'初期フォーカス位置設定
		Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_ClearDE_Click
	'   概要：  明細行初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_ClearDE_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_ClearItm_Click
	'   概要：  項目初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_ClearItm_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'画面内容初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)
		
		'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Select Case Me.ActiveControl.Name
			Case HD_HINCD.Name
				Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
		End Select
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'共通ﾌｫｰｶｽ取得処理
		Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Copy_Click
	'   概要：  コピー
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Copy_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目のコピー
		Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Cut_Click
	'   概要：  切り取り
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Cut_Click() As Short
		
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の切り取り
		Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'項目初期化
		Call Ctl_MN_ClearItm_Click()
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_DeleteCM_Click
	'   概要：  削除
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_DeleteCM_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_DeleteDE_Click
	'   概要：  明細行削除
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_DeleteDE_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_EndCm_Click
	'   概要：  終了
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_EndCm_Click() As Short
		Me.Close()
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_SELECTCM_Click
	'   概要：  選択（明細部クリア）
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_SELECTCM_Click() As Short
		
		Dim Wk_Index As Short
		
		Dim Act_Index As Short
		
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		If Act_Index <= Main_Inf.Dsp_Base.Head_Lst_Idx Then
			'ヘッダ部（検索条件）にいるときは処理を行わない
			Exit Function
		End If
		
		'画面内容初期化（入力項目を除く）
		Wk_Index = CShort(BD_SELECTB(1).Tag)
		Call F_Clr_Dsp_Out(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf)
		
		'ヘッダ部入力制御
		Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
		
		'画面ボディ部初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面明細表示
		Call CF_Body_Dsp(Main_Inf)
		
		'入力担当者編集
		Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
		
		'初期フォーカス位置設定
		Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_HARDCOPY_Click
	'   概要：  画面印刷
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_HARDCOPY_Click() As Short
		
		Dim wk_Cursor As Short
		
		'Operable=TRUEの時のみok
		If PP_SSSMAIN.Operable = False Then
			Exit Function
		End If
		'ハードコピーイベント実行
		If SSSMAIN_Hardcopy_Getevent() Then
			wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_InsertDE_Click
	'   概要：  明細行挿入
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_InsertDE_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Paste_Click
	'   概要：  貼り付け
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Paste_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の貼り付け
		Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Slist_Click
	'   概要：  項目の一覧
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Slist_Click() As Short
		
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		
		Select Case Act_Index
			'参照見積番号
			Case CShort(Me.HD_HINCD.Tag)
				Call CS_HINCD_Click()
				
			Case Else
		End Select
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_UnDoDe_Click
	'   概要：  明細行復元
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_UnDoDe_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_UnDoItem_Click
	'   概要：  項目復元
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_UnDoItem_Click() As Short
		
		Dim Act_Index As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の復元処理
		Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
		
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
		
		'項目色設定
		Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SM_AllCopy_Click
	'   概要：  項目内容にコピー
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_AllCopy_Click() As Short
		
		'項目内容にコピー
		Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_SM_Esc_Click
	'   概要：  取り消し
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_Esc_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_SM_FullPast_Click
	'   概要：  項目に貼り付け
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_FullPast_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の貼り付け
		'注）メニューの画面｢貼り付け｣と同一関数を使用！！
		Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_CS_HIK_Click
	'   概要：  引当／解除ボタン
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_CS_HIK_Click() As Short
		
		Dim Trg_Index As Short
		Dim strMsg As String
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Trg_Index = CShort(Me.CS_HIK.Tag)
		
		If CF_Set_Focus_Ctl(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf) = True Then
			
			'更新権限がない場合は排他制御は行わない
			If Inp_Inf.InpJDNUPDKB = gc_strJDNUPDKB_OK Then
				
				'排他チェックを行う
				Select Case CF_Chk_Lock_EXCTBZ(strMsg)
					'正常
					Case 0
						
						'排他処理中
					Case 1
						Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_018, Main_Inf, "", strMsg)
						Exit Function
						
						'異常終了
					Case 9
						Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, Main_Inf)
						Exit Function
						
				End Select
				
				' add 20170616 start
				'排他チェックを行う
				Select Case CF_Chk_Lock_EXCTBZ2(strMsg)
					'正常
					Case 0
						
						'排他処理中
					Case 1
						Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_018, Main_Inf, "", strMsg)
						Exit Function
						
						'異常終了
					Case 9
						Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, Main_Inf)
						Exit Function
						
				End Select
				' add 20170616 end
			End If
			
			'インターフェース格納
			'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    連絡票№FC12031301
			'        Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET54_Bd_Sel_Index), _
			''                             HIKET54_DSP_DATA_Inf, _
			''                             HIKET54_Interface)
			Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET54_Bd_Sel_Index), HIKET54_DSP_DATA_Inf, HIKET54_Interface, HIKET54_Bd_Sel_Index)
			'''' UPD 2012/03/13  FKS) T.Yamamoto    End
			
			Me.Hide()
			
			'在庫引当／個別解除表示
			FR_SSSSUB01.Show()
			
		End If
		
		
	End Function
	
	' add 20170616 start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_Lock_EXCTBZ2
	'   概要：　排他制御処理
	'   引数：　Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ2(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ2 = 9
		pot_strMsg = ""
		bolTrn = False
		
		intRet = AE_Execute_PLSQL_EXCTBZ_2("C", strMsg)
		If intRet <> 0 Then
			'排他エラー
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ2 = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御
		intRet = AE_Execute_PLSQL_EXCTBZ_2("W", strMsg)
		If intRet <> 0 Then
			'排他エラー
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ2 = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ2 = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	' add 20170616 end
	
	'□□□□□□□□ 全画面ローカル共通処理 End □□□□□□□□□□□□□□□□
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Edi_Dsp_Def
	'   概要：  初期時の画面編集
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Edi_Dsp_Def() As Short
		Dim Index_Wk As Short
		Dim strSYSDT As String
		
		'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Index_Wk = CShort(SYSDT.Tag)
		'画面日付
		'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
		Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Init_Def_Body_Inf
	'   概要：  画面ボディ情報設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Init_Def_Body_Inf() As Short
		
		Dim Bd_Col_Index As Short
		Dim Index_Wk As Short
		
		'初期画面ボディ情報設定
		Call CF_Init_Set_Body_Inf(Main_Inf)
		
		If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細行が存在する場合
			
			'画面ボディの列分の配列定義
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'初期状態
			Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT
			
			'初期化用設定
			'画面ボディの列分の配列定義
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'初期状態
			Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'復元情報設定
			'列分の復元行の配列定義
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'初期状態
			Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'画面ボディ情報の配列０番目に列情報を定義する
			For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
				'画面ボディ情報
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
				
				'初期化用情報
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
				
				'復元情報
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
			Next 
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Set_Body_Location
	'   概要：  明細の配置
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Set_Body_Location() As Short
		
		Const Hosei_Value As Short = -20
		
		Dim BD_OUTYTDT_Top As Short
		Dim BD_OUTYTDT_Height As Short
		
		Dim BD_OUTYTSU_Top As Short
		Dim BD_ORGSBNNO_Top As Short
		Dim BD_OUTRSNNM_Top As Short
		Dim BD_TOKRN_Top As Short
		Dim BD_SIRRN_Top As Short
		Dim BD_WRTFSTDT_Top As Short
		Dim BD_SOUNM_Top As Short
		
		Dim Bd_Index As Short
		
		'１行目のNoのTopとHeightを基準とする
		BD_OUTYTDT_Top = VB6.FromPixelsUserY(BD_OUTYTDT(1).Top, 0, 9703.92, 579)
		BD_OUTYTDT_Height = VB6.FromPixelsUserHeight(BD_OUTYTDT(1).Height, 9703.92, 579) + Hosei_Value
		
		'１行目｢入出庫日｣から｢数量｣までの相対位置を取得
		BD_OUTYTSU_Top = VB6.FromPixelsUserY(BD_OUTYTSU(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢元製番｣までの相対位置を取得
		BD_ORGSBNNO_Top = VB6.FromPixelsUserY(BD_ORGSBNNO(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢出庫理由名｣までの相対位置を取得
		BD_OUTRSNNM_Top = VB6.FromPixelsUserY(BD_OUTRSNNM(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢得意先略称｣までの相対位置を取得
		BD_TOKRN_Top = VB6.FromPixelsUserY(BD_TOKRN(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢仕入先略称｣までの相対位置を取得
		BD_SIRRN_Top = VB6.FromPixelsUserY(BD_SIRRN(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢登録日｣までの相対位置を取得
		BD_WRTFSTDT_Top = VB6.FromPixelsUserY(BD_WRTFSTDT(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		'１行目｢入出庫日｣から｢倉庫名｣までの相対位置を取得
		BD_SOUNM_Top = VB6.FromPixelsUserY(BD_SOUNM(1).Top, 0, 9703.92, 579) - BD_OUTYTDT_Top
		
		'表示最終行まで処理
		For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			'配置
			BD_SELECTB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_OUTYTDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_OUTYTSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_ORGSBNNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_OUTRSNNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_TOKRN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_SIRRN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_WRTFSTDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			BD_SOUNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1))
			
			'表示
			BD_SELECTB(Bd_Index).Visible = True
			BD_OUTYTDT(Bd_Index).Visible = True
			BD_OUTYTSU(Bd_Index).Visible = True
			BD_ORGSBNNO(Bd_Index).Visible = True
			BD_OUTRSNNM(Bd_Index).Visible = True
			BD_TOKRN(Bd_Index).Visible = True
			BD_SIRRN(Bd_Index).Visible = True
			BD_WRTFSTDT(Bd_Index).Visible = True
			BD_SOUNM(Bd_Index).Visible = True
			
		Next 
		
		'スクロールバーの設定
		VS_Scrl.Top = VB6.ToPixelsUserY(BD_OUTYTDT_Top, 0, 9703.92, 579)
		VS_Scrl.Height = VB6.ToPixelsUserHeight(BD_OUTYTDT_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt, 9703.92, 579)
		
	End Function
	
	Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
		'一度きりのため使用不可
		Main_Inf.TM_StartUp_Ctl.Enabled = False
		'画面印刷起動時はTRUEとする
		PP_SSSMAIN.Operable = True
		'初期ﾌｫｰｶｽ位置設定s
		Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'DB接続
		Call CF_Ora_USR1_Open()
		
		'共通初期化処理
		Call CF_Init()
		
		'画面情報設定
		Call Init_Def_Dsp()
		
		'画面内容初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'画面明細情報設定
		Call Init_Def_Body_Inf()
		
		'画面明細部初期化
		Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'明細ロケーション
		Call Set_Body_Location()
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面明細表示
		Call CF_Body_Dsp(Main_Inf)
		
		'画面表示位置設定
		Call CF_Set_Frm_Location(Me)
		
		'入力担当者編集
		Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
		
		'システム共通処理
		Call CF_System_Process(Me)
		
	End Sub
	
	'UPGRADE_NOTE: VS_Scrl.Change はイベントからプロシージャに変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' をクリックしてください。
	'UPGRADE_WARNING: VScrollBar イベント VS_Scrl.Change には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub VS_Scrl_Change(ByVal newScrollValue As Integer)
		Debug.Print("VS_Scrl_Change")
		Call Ctl_VS_Scrl_Change(VS_Scrl)
	End Sub
	
	'UPGRADE_WARNING: イベント BD_SELECTB.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_SELECTB_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SELECTB.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
			Debug.Print("BD_SELECTB_Click")
			Call Ctl_Item_Click(BD_SELECTB(Index))
		End If
	End Sub
	
	Private Sub CS_HIK_Click()
		Debug.Print("CS_HIK_Click")
		'UPGRADE_WARNING: オブジェクト CS_HIK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_HIK)
	End Sub
	
	Private Sub CS_HINCD_Click()
		Debug.Print("CS_HINCD_Click")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_HINCD)
	End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		Debug.Print("CM_Execute_Click")
		Call Ctl_Item_Click(CM_Execute)
	End Sub
	
	Private Sub CM_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SELECTCM.Click
		Debug.Print("CM_SELECTCM_Click")
		Call Ctl_Item_Click(CM_SELECTCM)
	End Sub
	
	Private Sub CM_SLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click
		Debug.Print("CM_SLIST_Click")
		Call Ctl_Item_Click(CM_SLIST)
	End Sub
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Debug.Print("CM_EndCm_Click")
		Call Ctl_Item_Click(CM_EndCm)
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
		Debug.Print("MN_Ctrl_Click")
		Call Ctl_Item_Click(MN_Ctrl)
	End Sub
	
	Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
		Debug.Print("MN_Execute_Click")
		Call Ctl_Item_Click(MN_Execute)
	End Sub
	
	'Private Sub MN_DeleteCM_Click()
	'    Debug.Print "MN_DeleteCM_Click"
	'    Call Ctl_Item_Click(MN_DeleteCM)
	'End Sub
	
	Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
		Debug.Print("MN_HARDCOPY_Click")
		Call Ctl_Item_Click(MN_HARDCOPY)
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Debug.Print("MN_EndCm_Click")
		Call Ctl_Item_Click(MN_EndCm)
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
		Debug.Print("MN_EditMn_Click")
		Call Ctl_Item_Click(MN_EditMn)
	End Sub
	
	'Private Sub MN_APPENDC_Click()
	'    Debug.Print "MN_APPENDC_Click"
	'    Call Ctl_Item_Click(MN_APPENDC)
	'End Sub
	
	Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
		Debug.Print("MN_ClearItm_Click")
		Call Ctl_Item_Click(MN_ClearItm)
	End Sub
	
	Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
		Debug.Print("MN_UnDoItem_Click")
		Call Ctl_Item_Click(MN_UnDoItem)
	End Sub
	
	'Private Sub MN_ClearDE_Click()
	'    Debug.Print "MN_ClearDE_Click"
	'    Call Ctl_Item_Click(MN_ClearDE)
	'End Sub
	'
	'Private Sub MN_DeleteDE_Click()
	'    Debug.Print "MN_DeleteDE_Click"
	'    Call Ctl_Item_Click(MN_DeleteDE)
	'End Sub
	'
	'Private Sub MN_InsertDE_Click()
	'    Debug.Print "MN_InsertDE_Click"
	'    Call Ctl_Item_Click(MN_InsertDE)
	'End Sub
	'
	'Private Sub MN_UnDoDe_Click()
	'    Debug.Print "MN_UnDoDe_Click"
	'    Call Ctl_Item_Click(MN_UnDoDe)
	'End Sub
	
	Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
		Debug.Print("MN_Cut_Click")
		Call Ctl_Item_Click(MN_Cut)
	End Sub
	
	Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
		Debug.Print("MN_Copy_Click")
		Call Ctl_Item_Click(MN_Copy)
	End Sub
	
	Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
		Debug.Print("MN_Paste_Click")
		Call Ctl_Item_Click(MN_Paste)
	End Sub
	
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
		Debug.Print("MN_Oprt_Click")
		Call Ctl_Item_Click(MN_Oprt)
	End Sub
	
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
		Debug.Print("MN_Slist_Click")
		Call Ctl_Item_Click(MN_Slist)
	End Sub
	
	'Private Sub SM_ShortCut_Click()
	'    Debug.Print "SM_ShortCut_Click"
	'    Call Ctl_Item_Click(SM_ShortCut)
	'End Sub
	
	Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
		Debug.Print("SM_AllCopy_Click")
		Call Ctl_Item_Click(SM_AllCopy)
	End Sub
	
	Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
		Debug.Print("SM_FullPast_Click")
		Call Ctl_Item_Click(SM_FullPast)
	End Sub
	
	Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
		Debug.Print("SM_Esc_Click")
		Call Ctl_Item_Click(SM_Esc)
	End Sub
	
	Private Sub HD_SBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseDown")
		Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMA_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMB_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINNMB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANNM_MouseDown")
		Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SELECTB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SELECTB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_MouseDown")
		Call Ctl_Item_MouseDown(BD_SELECTB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTYTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTYTDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_MouseDown")
		Call Ctl_Item_MouseDown(BD_OUTYTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTYTSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTYTSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_OUTYTSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_ORGSBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ORGSBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_MouseDown")
		Call Ctl_Item_MouseDown(BD_ORGSBNNO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTRSNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTRSNNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_MouseDown")
		Call Ctl_Item_MouseDown(BD_OUTRSNNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_MouseDown")
		Call Ctl_Item_MouseDown(BD_TOKRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SIRRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIRRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_MouseDown")
		Call Ctl_Item_MouseDown(BD_SIRRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_WRTFSTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_WRTFSTDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_MouseDown")
		Call Ctl_Item_MouseDown(BD_WRTFSTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_MouseDown")
		Call Ctl_Item_MouseDown(BD_SOUNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseDown")
		Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SELECTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SELECTCM_MouseDown")
		Call Ctl_Item_MouseDown(CM_SELECTCM, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SLIST_MouseDown")
		Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseDown")
		Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseMove")
		Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SELECTCM_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SELECTCM_MouseMove")
		Call Ctl_Item_MouseMove(CM_SELECTCM, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SLIST_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SLIST_MouseMove")
		Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseMove")
		Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_HIK_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_HIK_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_HIK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_HIK, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_HINCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_HINCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMA_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMB_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINNMB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANNM_MouseUp")
		Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SELECTB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SELECTB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_MouseUp")
		Call Ctl_Item_MouseUp(BD_SELECTB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTYTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTYTDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_MouseUp")
		Call Ctl_Item_MouseUp(BD_OUTYTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTYTSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTYTSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_OUTYTSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_ORGSBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ORGSBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_MouseUp")
		Call Ctl_Item_MouseUp(BD_ORGSBNNO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_OUTRSNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_OUTRSNNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_MouseUp")
		Call Ctl_Item_MouseUp(BD_OUTRSNNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_MouseUp")
		Call Ctl_Item_MouseUp(BD_TOKRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SIRRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIRRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_MouseUp")
		Call Ctl_Item_MouseUp(BD_SIRRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_WRTFSTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_WRTFSTDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_MouseUp")
		Call Ctl_Item_MouseUp(BD_WRTFSTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_MouseUp")
		Call Ctl_Item_MouseUp(BD_SOUNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("SYSDT_MouseUp")
		'UPGRADE_WARNING: オブジェクト SYSDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseUp")
		Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SELECTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SELECTCM_MouseUp")
		Call Ctl_Item_MouseUp(CM_SELECTCM, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_SLIST_MouseUp")
		Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseUp")
		Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_CursorRest_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_CursorRest.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_CursorRest_MouseUp")
		Call Ctl_Item_MouseUp(TX_CursorRest, Button, Shift, X, Y)
	End Sub
	
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINCD, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMA_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINNMA, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMB_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINNMB, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_IN_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_IN_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANNM_KeyDown")
		Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SELECTB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SELECTB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_KeyDown")
		Call Ctl_Item_KeyDown(BD_SELECTB(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_OUTYTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTYTDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_KeyDown")
		Call Ctl_Item_KeyDown(BD_OUTYTDT(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_OUTYTSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTYTSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_OUTYTSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_ORGSBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ORGSBNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_KeyDown")
		Call Ctl_Item_KeyDown(BD_ORGSBNNO(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_OUTRSNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTRSNNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_KeyDown")
		Call Ctl_Item_KeyDown(BD_OUTRSNNM(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyDown")
		Call Ctl_Item_KeyDown(BD_TOKRN(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SIRRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIRRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_KeyDown")
		Call Ctl_Item_KeyDown(BD_SIRRN(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_WRTFSTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_WRTFSTDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_KeyDown")
		Call Ctl_Item_KeyDown(BD_WRTFSTDT(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyDown")
		Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub HD_SBNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SBNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_SBNNO_KeyPress")
		Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINNMA_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINNMA, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINNMB_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINNMB, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_IN_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_IN_TANCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_IN_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_IN_TANNM_KeyPress")
		Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SELECTB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SELECTB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_KeyPress")
		Call Ctl_Item_KeyPress(BD_SELECTB(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_OUTYTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_OUTYTDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_KeyPress")
		Call Ctl_Item_KeyPress(BD_OUTYTDT(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_OUTYTSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_OUTYTSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_OUTYTSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_ORGSBNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_ORGSBNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_KeyPress")
		Call Ctl_Item_KeyPress(BD_ORGSBNNO(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_OUTRSNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_OUTRSNNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_KeyPress")
		Call Ctl_Item_KeyPress(BD_OUTRSNNM(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TOKRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyPress")
		Call Ctl_Item_KeyPress(BD_TOKRN(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SIRRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIRRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_KeyPress")
		Call Ctl_Item_KeyPress(BD_SIRRN(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_WRTFSTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_WRTFSTDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_KeyPress")
		Call Ctl_Item_KeyPress(BD_WRTFSTDT(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SOUNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SOUNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyPress")
		Call Ctl_Item_KeyPress(BD_SOUNM(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub CS_HINCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
		Debug.Print("CS_HINCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_HINCD)
	End Sub
	
	Private Sub CS_HIK_GotFocus()
		Debug.Print("CS_HIK_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_HIK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_HIK)
	End Sub
	
	Private Sub CS_HINCD_GotFocus()
		Debug.Print("CS_HINCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_HINCD)
	End Sub
	
	Private Sub HD_SBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Enter
		Debug.Print("HD_SBNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Enter
		Debug.Print("HD_HINCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Enter
		Debug.Print("HD_HINNMA_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Enter
		Debug.Print("HD_HINNMB_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINNMB)
	End Sub
	
	Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
		Debug.Print("HD_IN_TANCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_IN_TANCD)
	End Sub
	
	Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
		Debug.Print("HD_IN_TANNM_GotFocus")
		Call Ctl_Item_GotFocus(HD_IN_TANNM)
	End Sub
	
	Private Sub BD_SELECTB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SELECTB.Enter
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_GotFocus")
		Call Ctl_Item_GotFocus(BD_SELECTB(Index))
	End Sub
	
	Private Sub BD_OUTYTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTDT.Enter
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_GotFocus")
		Call Ctl_Item_GotFocus(BD_OUTYTDT(Index))
	End Sub
	
	Private Sub BD_OUTYTSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTSU.Enter
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_OUTYTSU(Index))
	End Sub
	
	Private Sub BD_ORGSBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ORGSBNNO.Enter
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_GotFocus")
		Call Ctl_Item_GotFocus(BD_ORGSBNNO(Index))
	End Sub
	
	Private Sub BD_OUTRSNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTRSNNM.Enter
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_GotFocus")
		Call Ctl_Item_GotFocus(BD_OUTRSNNM(Index))
	End Sub
	
	Private Sub BD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.Enter
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_GotFocus")
		Call Ctl_Item_GotFocus(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_SIRRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIRRN.Enter
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_GotFocus")
		Call Ctl_Item_GotFocus(BD_SIRRN(Index))
	End Sub
	
	Private Sub BD_WRTFSTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_WRTFSTDT.Enter
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_GotFocus")
		Call Ctl_Item_GotFocus(BD_WRTFSTDT(Index))
	End Sub
	
	Private Sub BD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Enter
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_GotFocus")
		Call Ctl_Item_GotFocus(BD_SOUNM(Index))
	End Sub
	
	Private Sub CS_HIK_LostFocus()
		Debug.Print("CS_HIK_LostFocus")
		'UPGRADE_WARNING: オブジェクト CS_HIK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_LostFocus(CS_HIK)
	End Sub
	
	Private Sub HD_SBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Leave
		Debug.Print("HD_SBNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Leave
		Debug.Print("HD_HINCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Leave
		Debug.Print("HD_HINNMA_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Leave
		Debug.Print("HD_HINNMB_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINNMB)
	End Sub
	
	Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
		Debug.Print("HD_IN_TANCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_IN_TANCD)
	End Sub
	
	Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
		Debug.Print("HD_IN_TANNM_LostFocus")
		Call Ctl_Item_LostFocus(HD_IN_TANNM)
	End Sub
	
	Private Sub BD_OUTYTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTDT.Leave
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_LostFocus")
		Call Ctl_Item_LostFocus(BD_OUTYTDT(Index))
	End Sub
	
	Private Sub BD_OUTYTSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTSU.Leave
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_OUTYTSU(Index))
	End Sub
	
	Private Sub BD_ORGSBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ORGSBNNO.Leave
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_LostFocus")
		Call Ctl_Item_LostFocus(BD_ORGSBNNO(Index))
	End Sub
	
	Private Sub BD_OUTRSNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTRSNNM.Leave
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_LostFocus")
		Call Ctl_Item_LostFocus(BD_OUTRSNNM(Index))
	End Sub
	
	Private Sub BD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.Leave
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_LostFocus")
		Call Ctl_Item_LostFocus(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_SIRRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIRRN.Leave
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_LostFocus")
		Call Ctl_Item_LostFocus(BD_SIRRN(Index))
	End Sub
	
	Private Sub BD_WRTFSTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_WRTFSTDT.Leave
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_LostFocus")
		Call Ctl_Item_LostFocus(BD_WRTFSTDT(Index))
	End Sub
	
	Private Sub BD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Leave
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_LostFocus")
		Call Ctl_Item_LostFocus(BD_SOUNM(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント HD_SBNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_SBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.TextChanged
		Debug.Print("HD_SBNNO_Change")
		Call Ctl_Item_Change(HD_SBNNO)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_HINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.TextChanged
		Debug.Print("HD_HINCD_Change")
		Call Ctl_Item_Change(HD_HINCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_HINNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_HINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.TextChanged
		Debug.Print("HD_HINNMA_Change")
		Call Ctl_Item_Change(HD_HINNMA)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_HINNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_HINNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.TextChanged
		Debug.Print("HD_HINNMB_Change")
		Call Ctl_Item_Change(HD_HINNMB)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_IN_TANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_IN_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.TextChanged
		Debug.Print("HD_IN_TANCD_Change")
		Call Ctl_Item_Change(HD_IN_TANCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_IN_TANNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_IN_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.TextChanged
		Debug.Print("HD_IN_TANNM_Change")
		Call Ctl_Item_Change(HD_IN_TANNM)
	End Sub
	
	'UPGRADE_WARNING: イベント BD_OUTYTDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_OUTYTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTDT.TextChanged
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_Change")
		Call Ctl_Item_Change(BD_OUTYTDT(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_OUTYTSU.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_OUTYTSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTYTSU.TextChanged
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_Change")
		Call Ctl_Item_Change(BD_OUTYTSU(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_ORGSBNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_ORGSBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ORGSBNNO.TextChanged
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_Change")
		Call Ctl_Item_Change(BD_ORGSBNNO(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_OUTRSNNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_OUTRSNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_OUTRSNNM.TextChanged
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_Change")
		Call Ctl_Item_Change(BD_OUTRSNNM(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_TOKRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.TextChanged
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_Change")
		Call Ctl_Item_Change(BD_TOKRN(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_SIRRN.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_SIRRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIRRN.TextChanged
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_Change")
		Call Ctl_Item_Change(BD_SIRRN(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_WRTFSTDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_WRTFSTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_WRTFSTDT.TextChanged
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_Change")
		Call Ctl_Item_Change(BD_WRTFSTDT(Index))
	End Sub
	
	'UPGRADE_WARNING: イベント BD_SOUNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub BD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.TextChanged
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_Change")
		Call Ctl_Item_Change(BD_SOUNM(Index))
	End Sub
	
	Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseDown")
		Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseUp")
		Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_Message_KeyDown")
		Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
	End Sub
	
	Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Message.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("TX_Message_KeyPress")
		Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		Debug.Print("TX_Message_GotFocus")
		Call Ctl_Item_GotFocus(TX_Message)
	End Sub
	
	Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
		Debug.Print("TX_Message_LostFocus")
		Call Ctl_Item_LostFocus(TX_Message)
	End Sub
	
	'UPGRADE_WARNING: イベント TX_Message.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
		Debug.Print("TX_Message_Change")
		Call Ctl_Item_Change(TX_Message)
	End Sub
	
	Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
		Debug.Print("Image1_Click")
		Call Ctl_Item_Click(Image1)
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseMove")
		Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseUp")
		Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
	End Sub
	
	Public Sub MN_NEXTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NEXTCM.Click
		Debug.Print("MN_NEXTCM_Click")
		Call Ctl_Item_Click(MN_NEXTCM)
	End Sub
	
	Public Sub MN_PREV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_PREV.Click
		Debug.Print("MN_PREV_Click")
		Call Ctl_Item_Click(MN_PREV)
	End Sub
	
	Public Sub MN_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SELECTCM.Click
		Debug.Print("MN_SELECTCM_Click")
		Call Ctl_Item_Click(MN_SELECTCM)
	End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		'メッセージ出力
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_001, Main_Inf) <> MsgBoxResult.Yes Then
			Cancel = True
			Exit Sub
		End If
		Main_Inf.Dsp_Base.IsUnload = True
		
		'DB接続解除
		Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
		
		Call SSSWIN_LOGWRT("プログラム終了")
		
		'共通終了処理？
		'UPGRADE_NOTE: オブジェクト FR_SSSMAIN をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		Me = Nothing
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub HD_SBNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyUp")
		Call Ctl_Item_KeyUp(HD_SBNNO)
	End Sub
	
	Private Sub HD_HINCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMA.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMA_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMB.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMB_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINNMB)
	End Sub
	
	Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANCD_KeyUp")
		Call Ctl_Item_KeyUp(HD_IN_TANCD)
	End Sub
	
	Private Sub HD_IN_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANNM_KeyUp")
		Call Ctl_Item_KeyUp(HD_IN_TANNM)
	End Sub
	
	Private Sub BD_SELECTB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SELECTB.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
		Debug.Print("BD_SELECTB_KeyUp")
		Call Ctl_Item_KeyUp(BD_SELECTB(Index))
	End Sub
	
	Private Sub BD_OUTYTDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTYTDT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTYTDT.GetIndex(eventSender)
		Debug.Print("BD_OUTYTDT_KeyUp")
		Call Ctl_Item_KeyUp(BD_OUTYTDT(Index))
	End Sub
	
	Private Sub BD_OUTYTSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTYTSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTYTSU.GetIndex(eventSender)
		Debug.Print("BD_OUTYTSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_OUTYTSU(Index))
	End Sub
	
	Private Sub BD_ORGSBNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ORGSBNNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ORGSBNNO.GetIndex(eventSender)
		Debug.Print("BD_ORGSBNNO_KeyUp")
		Call Ctl_Item_KeyUp(BD_ORGSBNNO(Index))
	End Sub
	
	Private Sub BD_OUTRSNNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_OUTRSNNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_OUTRSNNM.GetIndex(eventSender)
		Debug.Print("BD_OUTRSNNM_KeyUp")
		Call Ctl_Item_KeyUp(BD_OUTRSNNM(Index))
	End Sub
	
	Private Sub BD_TOKRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKRN.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyUp")
		Call Ctl_Item_KeyUp(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_SIRRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIRRN.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SIRRN.GetIndex(eventSender)
		Debug.Print("BD_SIRRN_KeyUp")
		Call Ctl_Item_KeyUp(BD_SIRRN(Index))
	End Sub
	
	Private Sub BD_WRTFSTDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_WRTFSTDT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_WRTFSTDT.GetIndex(eventSender)
		Debug.Print("BD_WRTFSTDT_KeyUp")
		Call Ctl_Item_KeyUp(BD_WRTFSTDT(Index))
	End Sub
	
	Private Sub BD_SOUNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyUp")
		Call Ctl_Item_KeyUp(BD_SOUNM(Index))
	End Sub
	
	Private Sub CS_HIK_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Debug.Print("CS_HIK_KeyDown")
		If KEYCODE >= System.Windows.Forms.Keys.F1 And KEYCODE <= System.Windows.Forms.Keys.F12 Then
			'UPGRADE_WARNING: オブジェクト CS_HIK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call Ctl_Item_KeyDown(CS_HIK, KEYCODE, Shift)
		End If
	End Sub
	Private Sub VS_Scrl_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VS_Scrl.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VS_Scrl_Change(eventArgs.newValue)
		End Select
	End Sub
End Class