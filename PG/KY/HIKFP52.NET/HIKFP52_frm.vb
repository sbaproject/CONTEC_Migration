Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
	Private Const FM_PANEL3D1_CNT As Short = 4 'パネルコントロール数
	'*** End Of Generated Declaration Section ****
	
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	
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
			.Item_Cnt = 38 '画面項目数
			.Dsp_Body_Cnt = -1 '画面表示明細数（-1：明細なし、０：制限なし、１～：表示時明細数）
			.Max_Body_Cnt = -1 '最大表示明細数（-1：明細なし、０：制限なし、１～：最大明細数）
			.Body_Col_Cnt = 0 '明細の列項目数
			' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
			.FormCtl = Me
			' === 20060920 === INSERT E
		End With
		
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
		'登録
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
		'削除
		MN_DeleteCM.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteCM
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
		'画面初期化
		MN_APPENDC.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
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
		'明細行初期化
		MN_ClearDE.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearDE
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
		'明細行削除
		MN_DeleteDE.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteDE
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
		'明細行挿入
		MN_InsertDE.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_InsertDE
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
		'明細行復元
		MN_UnDoDe.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoDe
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
		'項目の一覧
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
		'登録イメージ
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
		CM_Slist.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Slist
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
		' === 20060925 === UPDATE S - ACE)Nagasawa
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		' === 20060925 === UPDATE E -
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
		
		'    Index_Wk = Index_Wk + 1
		'    '製品コード
		'    CS_HINCD.Tag = Index_Wk
		'    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'製品コード
		HD_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		' === 20061127 === UPDATE S - ACE)Nagasawa コードの大文字変換処理追加
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		' === 20061127 === UPDATE E -
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		
		'///////////////
		'// ボディ部編集
		'///////////////
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ
		
		
		'///////////////
		'// フッタ部編集
		'///////////////
		
		Index_Wk = Index_Wk + 1
		'ダミーテキスト
		TX_Dummy.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Dummy
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
		
		'E★★★★★★★★★★★★★★★★★★★★★★★★★★★★E
		
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		
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
		Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
			' === 20060915 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正2
			'キーフラグを元に戻す
			gv_bolKeyFlg = False
			' === 20060915 === INSERT E -
		End If
		'取得内容表示/クリア
		Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'        'ﾁｪｯｸ後移動あり
			'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
			'更新前チェック⇒ＤＢ更新⇒初期化
			Call F_Ctl_Upd_Process(Main_Inf)
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
		Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
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
		Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		
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
		Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			'KEYDOWN制御
			Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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
		Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'ﾁｪｯｸ後移動あり
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
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
		Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		
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
		Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			'KEYUP制御
			Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			
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
		
		' === 20060802 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
		'Enter時のみフラグをON
		If pm_KeyCode = System.Windows.Forms.Keys.Return Then
			If gv_bolKeyFlg = True Then
				Exit Function
			End If
			
			gv_bolKeyFlg = True
		End If
		' === 20060802 === INSERT E -
		
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
				Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
				' === 20060930 === INSERT S - ACE)Nagasawa ファンクションキー処理対応
				'ファンクションキー押下時
			Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
				'ファンクションキー共通処理
				Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
				' === 20060930 === INSERT E -
				
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
		
		If gv_bolHIKFP52_LF_Enable = False Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
		Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			
			'現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
			'選択状態の設定
			Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), CStr(0))
			'項目色設定
			Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
			
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
		Dim Move_Flg As Boolean
		Dim Wk_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'画面単位の処理(ﾁｪｯｸなど)
		'明細部でかつ移動前が明細部でない場合
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'ﾍｯﾀﾞ部ﾁｪｯｸ
			Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Select Case Trg_Index
			Case CShort(TX_Dummy.Tag)
				'ダミーコントロールにフォーカス移動した場合、製品コードのチェック
				'            Call CF_Set_Chk_From_Process(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_Process, Main_Inf)
				'            '製品コードのﾁｪｯｸ
				'            Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf _
				''                                   , pm_Chk_Move_Flg _
				''                                   , pm_All)
				
			Case Else
				'共通ﾌｫｰｶｽ取得処理
				Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
		End Select
		
		'メニュー使用可否制御
		Call F_Ctl_MN_Enabled(Main_Inf)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		Call CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
	'   概要：  各項目のCHANGE制御
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
		Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                ' === 20060802 === DELETE S - ACE)Nagasawa
                '            '項目色設定
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
                ' === 20060802 === DELETE E -

            Case TypeOf pm_Ctl Is Label
                'パネルの場合
                Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'イメージの場合
				Select Case Trg_Index
					Case CShort(CM_EndCm.Tag)
						'終了ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
						
					Case CShort(CM_Execute.Tag)
						'実行ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
						
					Case CShort(CM_Slist.Tag)
						'検索画面表示ｲﾒｰｼﾞ
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
						
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
				'登録ｲﾒｰｼﾞ
				' === 20060802 === UPDATE S - ACE)Nagasawa
				'            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)
				Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				' === 20060802 === UPDATE E -
				
			Case CShort(CM_Slist.Tag)
				'検索画面ｲﾒｰｼﾞ
				Call CF_Set_Prompt(IMG_SLIST_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
				
			Case CShort(CM_Slist.Tag)
				'検索画面表示ｲﾒｰｼﾞ
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
				
		End Select
		
		'共通MOUSEDOWN制御
		Call CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
		
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
		Dim Act_Index As Short
		Dim Wk_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Select Case Trg_Index
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			Case CShort(MN_Ctrl.Tag)
				'処理１
				Call Ctl_MN_Ctrl_Click()
				
			Case CShort(MN_Execute.Tag), CShort(CM_Execute.Tag)
				'登録
				Call Ctl_MN_Execute_Click()
				
			Case CShort(MN_DeleteCM.Tag)
				'削除
				Call Ctl_MN_DeleteCM_Click()
				
			Case CShort(MN_HARDCOPY.Tag)
				'画面印刷
				Call Ctl_MN_HARDCOPY_Click()
				
			Case CShort(MN_EndCm.Tag), CShort(CM_EndCm.Tag)
				'終了
				Call Ctl_MN_EndCm_Click()
				Exit Function
				
			Case CShort(MN_EditMn.Tag)
				'処理２
				Call Ctl_MN_EditMn_Click()
				
			Case CShort(MN_APPENDC.Tag)
				'画面初期化
				Call Ctl_MN_APPENDC_Click()
				
			Case CShort(MN_ClearItm.Tag)
				'項目初期化
				Call Ctl_MN_ClearItm_Click()
				
			Case CShort(MN_UnDoItem.Tag)
				'項目復元
				Call Ctl_MN_UnDoItem_Click()
				
			Case CShort(MN_ClearDE.Tag)
				'明細行初期化
				Call Ctl_MN_ClearDE_Click()
				
			Case CShort(MN_DeleteCM.Tag)
				'明細行削除
				Call Ctl_MN_DeleteDE_Click()
				
			Case CShort(MN_InsertDE.Tag)
				'明細行挿入
				Call Ctl_MN_InsertDE_Click()
				
			Case CShort(MN_UnDoDe.Tag)
				'明細行復元
				Call Ctl_MN_UnDoDe_Click()
				
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
				
			Case CShort(MN_Slist.Tag), CShort(CM_Slist.Tag)
				'項目の一覧
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
				
		End Select
		
		'ステータスバー初期化
		Call CF_Clr_Prompt(Main_Inf)
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'｢登録｣判定
		MN_APPENDC.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢削除｣判定
		MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢画面印刷｣判定
		MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢終了｣判定
		MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'メニュー使用可/不可制御
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'｢画面初期化｣判定
		MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢項目初期化｣判定
		MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢項目復元｣判定
		MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢明細行初期化｣判定
		MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢明細行削除｣判定
		MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢明細行挿入｣判定
		MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢明細行復元｣判定
		MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢切り取り｣判定
		MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢コピー｣判定
		MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'｢貼り付け｣判定
		MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_EditMn_Click
	'   概要：  メニュー操作３の使用可不可を制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Oprt_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_Execute_Click
	'   概要：  実行(抽出データを検索)
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Execute_Click() As Short
		
		Dim Wk_Index As Short
		
		'製品コードにおけるEnterキー押下処理をコール
		Call HD_HINCD_KeyDown(HD_HINCD, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Return Or 0 * &H10000))
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_HARDCOPY_Click
	'   概要：  画面印刷
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_HARDCOPY_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_EndCm_Click
	'   概要：  終了
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_EndCm_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Me.Close()
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'画面内容初期化
		Call F_Init_Clr_Dsp(Act_Index, Main_Inf)
		
		'共通ﾌｫｰｶｽ取得処理
		Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
	'   名称：  Function Ctl_MN_Cut_Click
	'   概要：  切り取り
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Cut_Click() As Short
		Dim Act_Index As Short
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
	'   名称：  Function Ctl_MN_Copy_Click
	'   概要：  コピー
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Copy_Click() As Short
		
		'項目内容にコピー
		Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
	'   概要：  候補の一覧
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Slist_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Call F_Ctl_CS(Main_Inf)
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
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_SM_Esc_Click
	'   概要：  取り消し
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_Esc_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
		
		' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の貼り付け
		'注）メニューの画面｢貼り付け｣と同一関数を使用！！
		Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_SELECTCM_Click
	'   概要：  選択（明細部クリア）
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_SELECTCM_Click() As Short
		
		'ヘッダ部入力制御
		Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
		
		'画面ボディ部初期化
		Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面明細表示
		Call CF_Body_Dsp(Main_Inf)
		
		'初期フォーカス位置設定
		Call F_Init_Cursor_Set(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KEYUP
	'   概要：  各項目のKEYUP制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		' === 20060731 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		' === 20060731 === INSERT E -
		'
		'    '各検索画面呼出
		'    Select Case Trg_Index
		'        Case CInt(CS_HINCD.Tag)
		'    End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		Call F_Init_Clr_Dsp(-1, Main_Inf)
		
		'ヘッダ部入力制御
		Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
		
		'画面ボディ部初期化
		Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()

        '入力担当者編集
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)

        '画面明細表示
        Call CF_Body_Dsp(Main_Inf)
		
		'初期フォーカス位置設定
		Call F_Init_Cursor_Set(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_ClearDE_Click
	'   概要：  明細行初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_ClearDE_Click() As Short
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
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_DeleteDE_Click
	'   概要：  明細行削除
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_DeleteDE_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_MN_InsertDE_Click
	'   概要：  明細行挿入
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_InsertDE_Click() As Short
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Index_Wk = CShort(SYSDT.Tag)
		'画面日付
		'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
		Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
			
			'画面ボディ情報の配列０番目に列情報を定義する
			For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
		'一度きりのため使用不可
		Main_Inf.TM_StartUp_Ctl.Enabled = False
		'初期ﾌｫｰｶｽ位置設定s
		Call F_Init_Cursor_Set(Main_Inf)
	End Sub
	
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'DB接続
		Call CF_Ora_USR1_Open()
		
		'共通初期化処理
		Call CF_Init()
		
		'画面情報設定
		Call Init_Def_Dsp()
		
		'画面内容初期化
		Call F_Init_Clr_Dsp(-1, Main_Inf)
		
		'ヘッダ部入力制御
		Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
		
		'画面明細情報設定
		Call Init_Def_Body_Inf()
		
		'画面明細部初期化
		Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'明細ロケーション
		Call Set_Body_Location()
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面明細表示
		Call CF_Body_Dsp(Main_Inf)
		
		'画面表示位置設定
		Call CF_Set_Frm_Location(Me)

        '入力担当者編集
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)

        'システム共通処理
        Call CF_System_Process(Me)
		
	End Sub
	
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		'メッセージ出力
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_Q_EXIT03, Main_Inf) <> MsgBoxResult.Yes Then
			Cancel = True
		Else
			'検索画面クローズ
			Call F_Ctl_WLS_Close()
			
			' === 20060907 === INSERT S - ACE)Sejima
			Main_Inf.Dsp_Base.IsUnload = True
            ' === 20060907 === INSERT E
            '共通終了処理？
            'UPGRADE_NOTE: オブジェクト FR_SSSMAIN をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            'Me = Nothing

            ' === 20060802 === INSERT S - ACE)Nagasawa
            'DB接続解除
            '2019/10/24 CHG START
            'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
            DB_CLOSE(CON)
            '2019/10/24 CHG E N D
            ' === 20060802 === INSERT E -

            ' === 20061102 === INSERT S - ACE)Yano ﾛｸﾞﾌｧｲﾙ書込み（プログラム終了）
            Call SSSWIN_LOGWRT("プログラム終了")
			' === 20061102 === INSERT E
			
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Debug.Print("CM_EndCm_Click")
		Call Ctl_Item_Click(CM_EndCm)
	End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		Debug.Print("CM_Execute_Click")
		Call Ctl_Item_Click(CM_Execute)
	End Sub
	
	Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click
		Debug.Print("CM_Slist_Click")
		Call Ctl_Item_Click(CM_Slist)
	End Sub
	
	Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
		Debug.Print("Image1_Click")
		Call Ctl_Item_Click(Image1)
	End Sub
	
	Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
		Debug.Print("MN_APPENDC_Click")
		Call Ctl_Item_Click(MN_APPENDC)
	End Sub
	
	Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
		Debug.Print("MN_ClearItm_Click")
		Call Ctl_Item_Click(MN_ClearItm)
	End Sub
	
	Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
		Debug.Print("MN_Copy_Click")
		Call Ctl_Item_Click(MN_Copy)
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
		Debug.Print("MN_Ctrl_Click")
		Call Ctl_Item_Click(MN_Ctrl)
	End Sub
	
	Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
		Debug.Print("MN_Cut_Click")
		Call Ctl_Item_Click(MN_Cut)
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
		Debug.Print("MN_EditMn_Click")
		Call Ctl_Item_Click(MN_EditMn)
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Debug.Print("MN_EndCm_Click")
		Call Ctl_Item_Click(MN_EndCm)
	End Sub
	
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
		Debug.Print("MN_Oprt_Click")
		Call Ctl_Item_Click(MN_Oprt)
	End Sub
	
	Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
		Debug.Print("MN_Paste_Click")
		Call Ctl_Item_Click(MN_Paste)
	End Sub
	
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
		Debug.Print("MN_Slist_Click")
		Call Ctl_Item_Click(MN_Slist)
	End Sub
	
	Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
		Debug.Print("MN_UnDoItem_Click")
		Call Ctl_Item_Click(MN_UnDoItem)
	End Sub
	
	Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
		Debug.Print("SM_AllCopy_Click")
		Call Ctl_Item_Click(SM_AllCopy)
	End Sub
	
	Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
		Debug.Print("SM_Esc_Click")
		Call Ctl_Item_Click(SM_Esc)
	End Sub
	
	Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
		Debug.Print("SM_FullPast_Click")
		Call Ctl_Item_Click(SM_FullPast)
	End Sub
	
	'Private Sub SM_ShortCut_Click()
	'    Debug.Print "SM_ShortCut_Click"
	'    Call Ctl_Item_Click(SM_ShortCut)
	'End Sub
	
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseDown")
		Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseDown")
		Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Slist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Slist_MouseDown")
		Call Ctl_Item_MouseDown(CM_Slist, Button, Shift, X, Y)
	End Sub
	
	'Private Sub FM_Panel3D1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    Debug.Print "FM_Panel3D1_MouseDown"
	'    Call Ctl_Item_MouseDown(FM_Panel3D1(Index), Button, Shift, X, Y)
	'End Sub
	
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
	
	' === 20060810 === DELETE S - ACE)Nagasawa
	'Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    Debug.Print "Image1_MouseDown"
	'    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
	'End Sub
	' === 20060810 === DELETE E -
	
	Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseDown")
		Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseMove")
		Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseMove")
		Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Slist_MouseMove")
		Call Ctl_Item_MouseMove(CM_Slist, Button, Shift, X, Y)
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseMove")
		Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseUp")
		Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseUp")
		Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Slist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Slist_MouseUp")
		Call Ctl_Item_MouseUp(CM_Slist, Button, Shift, X, Y)
	End Sub
	
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
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
	
	Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseUp")
		Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseUp")
		Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
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
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_Message_KeyDown")
		Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
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
	
	Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Message.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("TX_Message_KeyPress")
		Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
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
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		Debug.Print("TX_Message_GotFocus")
		Call Ctl_Item_GotFocus(TX_Message)
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
	
	Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
		Debug.Print("TX_Message_LostFocus")
		Call Ctl_Item_LostFocus(TX_Message)
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
	
	'UPGRADE_WARNING: イベント TX_Message.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
		Debug.Print("TX_Message_Change")
		Call Ctl_Item_Change(TX_Message)
	End Sub
	
	' === 20070127 === DELETE S - ACE)Nagasawa
	'Private Sub SYSDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    Debug.Print "SYSDT_MouseDown"
	'    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
	'End Sub
	' === 20070127 === DELETE E -
	
	Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("SYSDT_MouseUp")
		'UPGRADE_WARNING: オブジェクト SYSDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Dummy_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Dummy_MouseDown")
		Call Ctl_Item_MouseDown(TX_Dummy, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Dummy_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Dummy_MouseUp")
		Call Ctl_Item_MouseUp(TX_Dummy, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Dummy_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Dummy.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_Dummy_KeyDown")
		Call Ctl_Item_KeyDown(TX_Dummy, KEYCODE, Shift)
	End Sub
	
	Private Sub TX_Dummy_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Dummy.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("TX_Dummy_KeyPress")
		Call Ctl_Item_KeyPress(TX_Dummy, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Dummy_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Enter
		Debug.Print("TX_Dummy_GotFocus")
		Call Ctl_Item_GotFocus(TX_Dummy)
	End Sub
	
	Private Sub TX_Dummy_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Leave
		Debug.Print("TX_Dummy_LostFocus")
		Call Ctl_Item_LostFocus(TX_Dummy)
	End Sub
	
	'UPGRADE_WARNING: イベント TX_Dummy.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub TX_Dummy_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.TextChanged
		Debug.Print("TX_Dummy_Change")
		Call Ctl_Item_Change(TX_Dummy)
	End Sub
	
	'Private Sub MN_APPENDC_Click()
	'    Debug.Print "MN_APPENDC_Click"
	'    Call Ctl_Item_Click(MN_APPENDC)
	'End Sub
	
	Public Sub MN_ClearDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearDE.Click
		Debug.Print("MN_ClearDE_Click")
		Call Ctl_Item_Click(MN_ClearDE)
	End Sub
	
	'Private Sub MN_ClearItm_Click()
	'    Debug.Print "MN_ClearItm_Click"
	'    Call Ctl_Item_Click(MN_ClearItm)
	'End Sub
	
	'Private Sub MN_Copy_Click()
	'    Debug.Print "MN_Copy_Click"
	'    Call Ctl_Item_Click(MN_Copy)
	'End Sub
	
	'Private Sub MN_Ctrl_Click()
	'    Debug.Print "MN_Ctrl_Click"
	'    Call Ctl_Item_Click(MN_Ctrl)
	'End Sub
	
	'Private Sub MN_Cut_Click()
	'    Debug.Print "MN_Cut_Click"
	'    Call Ctl_Item_Click(MN_Cut)
	'End Sub
	
	Public Sub MN_DeleteCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteCM.Click
		Debug.Print("MN_DeleteCM_Click")
		Call Ctl_Item_Click(MN_DeleteCM)
	End Sub
	
	Public Sub MN_DeleteDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteDE.Click
		Debug.Print("MN_DeleteDE_Click")
		Call Ctl_Item_Click(MN_DeleteDE)
	End Sub
	
	'Private Sub MN_EditMn_Click()
	'    Debug.Print "MN_EditMn_Click"
	'    Call Ctl_Item_Click(MN_EditMn)
	'End Sub
	
	'Private Sub MN_EndCm_Click()
	'    Debug.Print "MN_EndCm_Click"
	'    Call Ctl_Item_Click(MN_EndCm)
	'End Sub
	
	Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
		Debug.Print("MN_Execute_Click")
		Call Ctl_Item_Click(MN_Execute)
	End Sub
	
	Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
		Debug.Print("MN_HARDCOPY_Click")
		Call Ctl_Item_Click(MN_HARDCOPY)
	End Sub
	
	Public Sub MN_InsertDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_InsertDE.Click
		Debug.Print("MN_InsertDE_Click")
		Call Ctl_Item_Click(MN_InsertDE)
	End Sub
	
	'Private Sub MN_Oprt_Click()
	'    Debug.Print "MN_Oprt_Click"
	'    Call Ctl_Item_Click(MN_Oprt)
	'End Sub
	
	'Private Sub MN_Paste_Click()
	'    Debug.Print "MN_Paste_Click"
	'    Call Ctl_Item_Click(MN_Paste)
	'End Sub
	
	'Private Sub MN_Slist_Click()
	'    Debug.Print "MN_Slist_Click"
	'    Call Ctl_Item_Click(MN_Slist)
	'End Sub
	
	Public Sub MN_UnDoDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoDe.Click
		Debug.Print("MN_UnDoDe_Click")
		Call Ctl_Item_Click(MN_UnDoDe)
	End Sub
	
	'Private Sub MN_UnDoItem_Click()
	'    Debug.Print "MN_UnDoItem_Click"
	'    Call Ctl_Item_Click(MN_UnDoItem)
	'End Sub
	
	'Private Sub SM_AllCopy_Click()
	'    Debug.Print "SM_AllCopy_Click"
	'    Call Ctl_Item_Click(SM_AllCopy)
	'End Sub
	
	'Private Sub SM_Esc_Click()
	'    Debug.Print "SM_Esc_Click"
	'    Call Ctl_Item_Click(SM_Esc)
	'End Sub
	'
	'Private Sub SM_FullPast_Click()
	'    Debug.Print "SM_FullPast_Click"
	'    Call Ctl_Item_Click(SM_FullPast)
	'End Sub
	'
	'Private Sub SM_ShortCut_Click()
	'    Debug.Print "SM_ShortCut_Click"
	'    Call Ctl_Item_Click(SM_ShortCut)
	'End Sub
	
	' === 20060802 === INSERT S - ACE)Nagasawa
	Private Sub HD_HINCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_Click")
		Call Ctl_Item_KeyUp(HD_HINCD)
	End Sub
	' === 20060802 === INSERT E -
End Class