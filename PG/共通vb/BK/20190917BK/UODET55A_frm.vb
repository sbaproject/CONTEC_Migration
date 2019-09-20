Option Strict Off
Option Explicit On
Friend Class FR_SSSSUB01
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	' === 20061224 === UPDATE S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	'Private Const FM_PANEL3D1_CNT       As Integer = 4  'パネルコントロール数
	Private Const FM_PANEL3D1_CNT As Short = 7 'パネルコントロール数
    ' === 20061224 === UPDATE E -

    '20190909 ADD START
    Private FORM_LOAD_FLG = False
    '20190909 ADD END


    Private pv_ctlActiveCtrl As System.Windows.Forms.Control
	
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
		Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
		Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
		Main_Inf.Dsp_TX_Message = TX_Message
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'画面基礎情報設定
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_ENTRY '画面分類
			' === 20061015 === UPDATE S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
			'        .Item_Cnt = 38                              '画面項目数
			' === 20061224 === UPDATE S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
			'        .Item_Cnt = 39                              '画面項目数
			.Item_Cnt = 45 '画面項目数
			' === 20061224 === UPDATE E -
			' === 20061015 === UPDATE E -
			.Dsp_Body_Cnt = -1 '画面表示明細数（-1：明細なし、０：制限なし、１～：表示時明細数）
			.Max_Body_Cnt = -1 '最大表示明細数（-1：明細なし、０：制限なし、１～：最大明細数）
			.Body_Col_Cnt = 0 '明細の列項目数
			.Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1 '画面移動量
			' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
			.FormCtl = Me
			' === 20060920 === INSERT E
		End With
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'画面項目情報
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// メニュー部編集
		'///////////////////
		Index_Wk = Index_Wk + 1
        '処理１
        '20190809 CHG START
        'MN_Ctrl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl

        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '登録
        '20190809 CHG START
        'MN_Execute.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute

        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '削除
        '20190809 CHG START
        'MN_DeleteCM.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteCM

        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '画面印刷
        '20190809 CHG START
        'MN_HARDCOPY.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY

        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END


        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '終了

        '20190809 CHG START
        'MN_EndCm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
        btnF12.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190809 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '処理２
        '20190809 CHG START
        'MN_EditMn.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '画面初期化
        '20190809 CHG START
        'MN_APPENDC.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '項目初期化
        '20190809 CHG START
        'MN_ClearItm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '項目復元
        '20190809 CHG START
        'MN_UnDoItem.Tag = CStr(Index_Wk)
        '      Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '明細行初期化
        '20190809 CHG START
        'MN_ClearDE.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '明細行削除
        '20190809 CHG START
        'MN_DeleteDE.Tag = CStr(Index_Wk)
        '      Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '明細行挿入
        '20190809 CHG START
        'MN_InsertDE.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_InsertDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '明細行復元
        '20190809 CHG START
        'MN_UnDoDe.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoDe
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '切り取り
        '20190809 CHG START
        'MN_Cut.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        'コピー
        '20190809 CHG START
        'MN_Copy.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '貼り付け
        '20190809 CHG START
        'MN_Paste.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '操作３
        '20190809 CHG START
        'MN_Oprt.Tag = CStr(Index_Wk)
        '      Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '項目の一覧
        '20190809 CHG START
        'MN_Slist.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
        btnF5.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF5
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '項目内容にコピー
        '20190809 CHG START
        'SM_AllCopy.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '取り消し
        '20190809 CHG START
        'SM_Esc.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '項目に貼り付け
        '20190809 CHG START
        'SM_FullPast.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '20190809 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '終了イメージ
        '20190910 CHG START
        CM_EndCm.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm

        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190910 CHG END

        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
        Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '検索イメージ
        CM_SLIST.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
        Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        'ヘッダイメージ
        Image1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '処理日付
        'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SYSDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '///////////////////
        '// ヘッダ部編集
        '///////////////////
        Index_Wk = Index_Wk + 1
        '開発場所ｺｰﾄﾞﾎﾞﾀﾝ
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CS_KHTBSCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_KHTBSCD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '開発場所ｺｰﾄﾞ
        HD_KHTBSCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSCD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        ' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        ' === 20070206 === UPDATE E -
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 9
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '開発場所名称１
        HD_KHTBSNMA.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSNMA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '開発場所名称２
        HD_KHTBSNMB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSNMB
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
        Index_Wk = Index_Wk + 1
        '電話番号
        HD_KHTBSTL.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSTL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_TEL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '郵便番号
        HD_KHTBSZIPCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSZIPCD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_TEL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        'FAX番号
        HD_KHTBSFAX.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSFAX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_TEL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        ' === 20061224 === INSERT E -

        Index_Wk = Index_Wk + 1
        '住所１
        HD_KHTBSADA.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSADA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '住所２
        HD_KHTBSADB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSADB
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '住所３
        HD_KHTBSADC.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KHTBSADC
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 60
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        ' === 20061015 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
        Index_Wk = Index_Wk + 1
        '画面の項目が全て使用不可の場合にフォーカス退避用
        'HD_Cursol_Wk_1
        HD_Cursol_Wk_1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_Cursol_Wk_1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        ' === 20061015 === INSERT E -

        '画面基礎情報設定
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ

        '///////////////
        '// ボディ部編集
        '///////////////

        '    '画面基礎情報設定
        '    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////
        '// フッタ部編集
        '///////////////

        '画面基礎情報設定
        Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////////
        '// メッセージ部編集
        '///////////////////
        Index_Wk = Index_Wk + 1
        'メッセージ
        TX_Message.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Message
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        'TX_Mode
        TX_Mode.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '///////////////////
        '// その他編集
        '///////////////////
        For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
            Index_Wk = Index_Wk + 1
            'FM_Panel3D1
            'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190910 CHG START
            'FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
            'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
            dummyCtl.Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
            '20190910 CHG END

            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        Next

        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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
        '画面変更なしとする
        gv_bolUODET55A_INIT = False
        '''''    gv_bolUODET55A_LF_Enable = True
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            Call SSSMAIN0003.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
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
        Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

        If Move_Flg = True Then
            '次の項目へ移動した場合
            '各項目のﾁｪｯｸﾙｰﾁﾝ
            Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
                Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            'KEYDOWN制御
            Call SSSMAIN0003.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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
        Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
            '次の項目へ移動した場合
            '各項目のﾁｪｯｸﾙｰﾁﾝ
            Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
                Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            'KEYUP制御
            Call SSSMAIN0003.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

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
            If gv_bolUODET55A_KeyFlg = True Then
                Exit Function
            End If

            gv_bolUODET55A_KeyFlg = True
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
                Call SSSMAIN0003.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

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
        Dim Dsp_Mode As Short

        '''''    If gv_bolUODET55A_LF_Enable = False Then
        '''''        Exit Function
        '''''    End If

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '======================= 変更部分 2006.07.02 Start =================================
        'ﾛｽﾄﾌｫｰｶｽ実行判定
        If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
            Main_Inf.Dsp_Base.LostFocus_Flg = False
            Exit Function
        End If
        '======================= 変更部分 2006.07.02 End =================================

        Move_Flg = False
        Chk_Move_Flg = True

        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

            '@'        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
            '@'        '選択状態の設定
            '@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_DATE_SEL_KBN_DAY)
            '@'        '項目色設定
            '@'        Call CF_Set_Item_Color(Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS)

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

        'フォーカスのあるコントロール退避
        pv_ctlActiveCtrl = pm_Ctl

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        '画面単位の処理(ﾁｪｯｸなど)
        '明細部でかつ移動前が明細部でない場合
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            'ﾍｯﾀﾞ部ﾁｪｯｸ
            If gv_bolInit = False Then '画面初期化の場合は行わない
                Rtn_Chk = SSSMAIN0003.F_Ctl_Head_Chk(Main_Inf)
            Else
                Rtn_Chk = CHK_OK
            End If
            'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
            If Rtn_Chk <> CHK_OK Then
                Exit Function
            End If
        End If

        ' === 20060803 === INSERT S - ACE)Sejima
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '20190809 DLT START
        'If TypeOf pm_Ctl Is SSCommand5 Then
        If TypeOf pm_Ctl Is Button Then
            '20190809 DLT END
            '検索画面呼出の場合は終了
            Exit Function
        End If
        ' === 20060803 === INSERT E

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        Select Case Trg_Index
            Case Else
                '共通ﾌｫｰｶｽ取得処理
                Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        End Select
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

        '処理１
        Call Ctl_MN_Ctrl_Click()
        '処理２
        Call Ctl_MN_EditMn_Click()
        '操作３
        Call Ctl_MN_Oprt_Click()
        ' === 20060901 === DELETE S - ACE)Sejima ボタンイメージ可視制御対応
        'D    'メニュー使用可否制御
        'D    Call F_Ctl_MN_Enabled
        ' === 20060901 === DELETE E

    End Function

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
        Call SSSMAIN0003.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

        If Move_Flg = True Then
            '次の項目へ移動した場合
            '各項目のﾁｪｯｸﾙｰﾁﾝ
            Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then

                '現在ﾌｫｰｶｽ位置から右へ移動
                Call SSSMAIN0003.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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

        '20190910 ADD START
        If FORM_LOAD_FLG = False Then
            Exit Function
        End If
        '20190910 ADD END

        Dim Trg_Index As Short

        If Main_Inf.Dsp_Base.Change_Flg = True Then
            Main_Inf.Dsp_Base.Change_Flg = False
            Exit Function
        End If

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        '共通KEYCHANG制御
        Call SSSMAIN0003.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

        ' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061117 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        Select Case True
            Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
                ' === 20061024 === INSERT S - ACE)Nagasawa 文字列入力項目の途中までの選択を可能とする
                If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Typ <> IN_TYP_STR Then
                    ' === 20061024 === INSERT E -
                    '選択状態の設定（初期選択）
                    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                    '======================= 変更部分 2006.07.02 Start =================================
                    '            '項目色設定
                    '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
                    '======================= 変更部分 2006.07.02 End =================================
                    ' === 20061024 === INSERT S - ACE)Nagasawa 文字列入力項目の途中までの選択を可能とする
                End If
                ' === 20061024 === INSERT E -

                ' === 20060803 === INSERT S - ACE)Sejima
 '20190809 DLT START
            'Case TypeOf pm_Ctl Is SSCommand5
            Case TypeOf pm_Ctl Is Button
                '20190809 DLT END
                'ボタンの場合
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                '20190809 CHG START
                'If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    '20190809 CHG END
                    Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060803 === INSERT E
                 '20190809 CHG START
            'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '20190809 CHG END
                'パネルの場合
                Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                'イメージの場合
                Select Case Trg_Index
                    Case CShort(CM_EndCm.Tag)
                        '終了ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)

                    Case CShort(CM_SLIST.Tag)
                        '検索Wｲﾒｰｼﾞ
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
                'ｲﾒｰｼﾞ１(初期化)
                Call CF_Clr_Prompt(Main_Inf)

            Case CShort(CM_EndCm.Tag)
                '終了ｲﾒｰｼﾞ
                ' === 20060926 === UPDATE S - ACE)Nagasawa
                '            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)
                Call CF_Set_Prompt(IMG_ENDCM_SUB_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
                ' === 20060926 === UPDATE E -

            Case CShort(CM_SLIST.Tag)
                '検索Wｲﾒｰｼﾞ
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

        '''''    Act_Index = CInt(pv_ctlActiveCtrl.Tag)

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        '======================= 変更部分 2006.07.02 Start =================================
        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)
        '======================= 変更部分 2006.07.02 End =================================
        Select Case Trg_Index
            Case CShort(CM_EndCm.Tag)
                '終了ｲﾒｰｼﾞ
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

            Case CShort(CM_SLIST.Tag)
                '検索Wｲﾒｰｼﾞ
                Select Case Act_Index
                    Case CShort(HD_KHTBSCD.Tag)
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)

                End Select

        End Select

        '======================= 変更部分 2006.07.02 Start =================================
        '共通MOUSEDOWN制御
        Call SSSMAIN0003.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
        '======================= 変更部分 2006.07.02 End =================================

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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '各検索画面呼出
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case Trg_Index
            Case CShort(CS_KHTBSCD.Tag)
                '開発場所検索画面呼出
                Call SSSMAIN0003.F_Ctl_CS_KHTBSCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

            Case CShort(MN_Ctrl.Tag)
                '処理１
                Call Ctl_MN_Ctrl_Click()

            Case CShort(MN_Execute.Tag)
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

            '20190910 ADD START
            Case CShort(btnF12.Tag)
                '終了
                Call Ctl_MN_EndCm_Click()
                Exit Function
            '20190910 ADD END

            Case CShort(MN_EditMn.Tag)
                '処理２
                Call Ctl_MN_EditMn_Click()

            Case CShort(MN_APPENDC.Tag)
                '画面初期化
                Call Ctl_MN_APPENDC_Click()

                '20190910 ADD START
            Case CShort(btnF9.Tag)
                '画面初期化
                Call Ctl_MN_APPENDC_Click()
                '20190910 ADD END

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

            Case CShort(MN_Slist.Tag), CShort(CM_SLIST.Tag)
                '項目の一覧
                Call Ctl_MN_Slist_Click()

            '20190910 ADD START
            Case CShort(btnF5.Tag)
                '項目の一覧
                Call Ctl_MN_Slist_Click()
            '20190910 ADD END

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
        'キーフラグを元に戻す
        gv_bolUODET55A_KeyFlg = False
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_VS_Scrl_Change
    '   概要：  縦スクロールのCHANGE制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_VS_Scrl_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
        '
        '    Dim Trg_Index   As Integer
        '    Dim Act_Index   As Integer
        '
        '    If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
        '        Main_Inf.Dsp_Base.VS_Scr_Flg = False
        '        Exit Function
        '    End If
        '
        '    '割当ｲﾝﾃﾞｯｸｽ取得
        '    Trg_Index = CInt(pm_Ctl.Tag)
        '    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        '    Act_Index = CInt(Me.ActiveControl.Tag)
        '
        '    '共通VS_SCRL_CHANGE制御
        '    Call CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '
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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Ant_Index = CShort(Me.ActiveControl.Tag)

        '｢登録｣判定
        ' === 20060828 === UPDATE S - ACE)Sejima
        'D    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        ' === 20060828 === UPDATE ↓
        MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        ' === 20060828 === UPDATE E
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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
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
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EditMn_Click
    '   概要：  メニュー操作３の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Oprt_Click() As Short

        Dim Ant_Index As Short

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Ant_Index = CShort(Me.ActiveControl.Tag)

        '｢候補の一覧｣初期可
        MN_Slist.Enabled = False
        '｢候補の一覧｣判定

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'ｱｸﾃｨﾌﾞな項目の検索機能がある場合、使用可
        'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Select Case Me.ActiveControl.Name
            Case HD_KHTBSCD.Name
                '検索機能のある入力項目の場合

                MN_Slist.Enabled = True
        End Select
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

        '画面明細情報設定
        Call Init_Def_Body_Inf()

        '画面内容初期化
        Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)

        '入力担当者編集
        '20190809 CHG START
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
        '20190809 CHG END

        '画面ボディ部初期化
        Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '初期表示編集
        Call Edi_Dsp_Def()

        '画面明細表示
        Call CF_Body_Dsp(Main_Inf)

        gv_bolInit = True

        '初期ﾌｫｰｶｽ位置設定
        Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)

        gv_bolInit = False

        '画面変更なしとする
        gv_bolUODET55A_INIT = False

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearDE_Click
    '   概要：  明細行初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_ClearDE_Click() As Short

        Dim Act_Index As Short

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当行の初期化処理
        Call SSSMAIN0003.CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        ' === 20060901 === DELETE S - ACE)Sejima
        'D' === 20060830 === INSERT S - ACE)Sejima ★初期値セット処理★
        'D    '各項目の初期化内容に、同項目の初期値をセット
        'D    Call CF_Set_Item_Clr_Value(-1, Main_Inf, CLR_VALUE_SET)
        'D' === 20060830 === INSERT E
        ' === 20060901 === DELETE E

        '画面内容初期化
        Call SSSMAIN0003.F_Init_Clr_Dsp(Act_Index, Main_Inf)

        ' === 20060721 === UPDATE S - ACE)Nagasawa
        '    '入力担当者編集
        '    Call CF_Set_Frm_IN_TANCD(FR_SSSSUB01, Main_Inf)

        'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Select Case Me.ActiveControl.Name
            Case HD_KHTBSCD.Name
                ' === 20060901 === UPDATE S - ACE)Sejima
                'D            Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
                ' === 20060901 === UPDATE ↓
                ' === 20060901 === UPDATE S - ACE)Sejima
                'D            Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_DEF, Main_Inf)
                ' === 20060901 === UPDATE ↓
                Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
                ' === 20060901 === UPDATE E
                ' === 20060901 === UPDATE E
            Case Else
        End Select

        ' === 20060721 === UPDATE E - ACE)Nagasawa

        ' === 20060901 === DELETE S - ACE)Sejima
        'D' === 20060830 === INSERT S - ACE)Sejima ★初期値セット処理★
        'D    '各項目の初期化内容をクリア
        'D    Call CF_Set_Item_Clr_Value(-1, Main_Inf)
        'D' === 20060830 === INSERT E
        ' === 20060901 === DELETE E

        '共通ﾌｫｰｶｽ取得処理
        Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
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
    '   名称：  Function Ctl_MN_Execute_Click
    '   概要：  登録
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Execute_Click() As Short
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
        Dim Act_Index As Short

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当行の削除処理
        Call SSSMAIN0003.CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        ' === 20060721 === INSERT S - ACE)Nagasawa
        Dim intRet As Short

        intRet = SSSMAIN0003.F_Ctl_Head_Chk(Main_Inf)
        If intRet <> CHK_OK Then
            Exit Function
        End If
        ' === 20060721 === INSERT E - ACE)Nagasawa

        Me.Close()

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
    '   名称：  Function Ctl_MN_InsertDE_Click
    '   概要：  明細行挿入
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_InsertDE_Click() As Short
        Dim Act_Index As Short

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当行の挿入処理
        Call SSSMAIN0003.CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当項目の貼り付け
        Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        Act_Index = CShort(pv_ctlActiveCtrl.Tag)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

        Select Case Act_Index
            '開発場所ｺｰﾄﾞ
            Case CShort(Me.HD_KHTBSCD.Tag)
                Call CS_KHTBSCD_Click()

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
        Dim Act_Index As Short

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当行の復元処理
        Call SSSMAIN0003.CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
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
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)

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

        ' === 20061116 === INSERT S - ACE)Nagasawa VBエラー発生対応
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当項目の貼り付け
        '注）メニューの画面｢貼り付け｣と同一関数を使用！！
        Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_MN_Enabled
    '   概要：  メニュー使用可否制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Ctl_MN_Enabled() As Short

        Dim Trg_Index As Short
        Dim Wk_Index As Short

        F_Ctl_MN_Enabled = 9
        'メニューボタンイメージの可視制御
        '終了ボタン
        Trg_Index = CShort(Me.CM_EndCm.Tag)
        Wk_Index = CShort(Me.MN_EndCm.Tag)
        Main_Inf.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = Main_Inf.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
        '検索画面表示ボタン
        Trg_Index = CShort(Me.CM_SLIST.Tag)
        Wk_Index = CShort(Me.MN_Slist.Tag)
        Main_Inf.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = Main_Inf.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled

        F_Ctl_MN_Enabled = 0

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
        ' === 20060901 === INSERT S - ACE)Sejima
        Dim Wk_Def_Set As Short
        ' === 20060901 === INSERT E
        ' === 20060911 === INSERT S - ACE)Nagasawa 開発場所の名称マニュアル入力区分の取得追加
        Dim Focus_Ctl As Boolean
        ' === 20060911 === INSERT E -

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        ' === 20060830 === UPDATE S - ACE)Sejima
        'D    '画面日付
        'D    Index_Wk = CInt(SYSDT.Tag)
        'D'    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所ｺｰﾄﾞ
        'D    Index_Wk = CInt(HD_KHTBSCD.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSCD, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所名１
        'D    Index_Wk = CInt(HD_KHTBSNMA.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所名２
        'D    Index_Wk = CInt(HD_KHTBSNMB.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所住所１
        'D    Index_Wk = CInt(HD_KHTBSADA.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所住所２
        'D    Index_Wk = CInt(HD_KHTBSADB.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        'D
        'D    '開発場所住所３
        'D    Index_Wk = CInt(HD_KHTBSADC.Tag)
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADC, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        ' === 20060830 === UPDATE ↓
        '画面日付
        'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Index_Wk = CShort(SYSDT.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        Call CF_Set_Bef_Rest_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk))
        ' === 20060901 === UPDATE E

        '開発場所ｺｰﾄﾞ
        Index_Wk = CShort(HD_KHTBSCD.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSCD, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSCD <> .NHSCD Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSCD)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSCD, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E

        '開発場所名１
        Index_Wk = CShort(HD_KHTBSNMA.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSNMA <> .NHSNMA Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSNMA)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E

        '開発場所名２
        Index_Wk = CShort(HD_KHTBSNMB.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSNMB <> .NHSNMB Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSNMB)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E

        ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
        '開発場所郵便番号
        Index_Wk = CShort(HD_KHTBSZIPCD.Tag)
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSZIPCD <> .NHSZIPCD Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSZIPCD)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSZIPCD, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)

        '開発場所電話番号
        Index_Wk = CShort(HD_KHTBSTL.Tag)
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSTL <> .NHSTL Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSTL)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSTL, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)

        '開発場所FAX番号
        Index_Wk = CShort(HD_KHTBSFAX.Tag)
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSFAX <> .NHSFAX Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSFAX)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSFAX, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20061224 === INSERT E -

        '開発場所住所１
        Index_Wk = CShort(HD_KHTBSADA.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSADA <> .NHSADA Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSADA)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADA, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E

        '開発場所住所２
        Index_Wk = CShort(HD_KHTBSADB.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSADB <> .NHSADB Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSADB)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADB, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E

        '開発場所住所３
        Index_Wk = CShort(HD_KHTBSADC.Tag)
        ' === 20060901 === UPDATE S - ACE)Sejima
        'D    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADC, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF, True)
        ' === 20060901 === UPDATE ↓
        With UODET55A_NHSMTA_Def
            If UODET55A_NHSMTA_Inf.NHSADC <> .NHSADC Then
                Wk_Def_Set = SET_FLG_DB_ERR
                Call CF_Set_Item_Def_Value(Main_Inf.Dsp_Sub_Inf(Index_Wk), .NHSADC)
            Else
                Wk_Def_Set = SET_FLG_DEF
            End If
        End With
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADC, Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, Wk_Def_Set)
        ' === 20060901 === UPDATE E
        ' === 20060830 === UPDATE E

        ' === 20060911 === INSERT S - ACE)Nagasawa 開発場所の名称マニュアル入力区分による制御の追加
        '** ｺﾝﾄﾛｰﾙ制御 **
        '【開発場所名】
        '名称ﾏﾆｭｱﾙ入力区分='1'の場合、開発場所名は変更可
        If UODET55A_NHSMTA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
            Focus_Ctl = True
        Else
            Focus_Ctl = False
        End If

        Index_Wk = CShort(Me.HD_KHTBSNMA.Tag)
        Call CF_Set_Item_Focus_Ctl(Focus_Ctl, Main_Inf.Dsp_Sub_Inf(Index_Wk))

        Index_Wk = CShort(Me.HD_KHTBSNMB.Tag)
        Call CF_Set_Item_Focus_Ctl(Focus_Ctl, Main_Inf.Dsp_Sub_Inf(Index_Wk))
        ' === 20060911 === INSERT E -

        ' === 20061015 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
        '画面項目のロック
        If gv_bolUODET55A_Locked = True Then
            '開発場所コード
            Index_Wk = CShort(Me.HD_KHTBSCD.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所名１
            Index_Wk = CShort(Me.HD_KHTBSNMA.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所名２
            Index_Wk = CShort(Me.HD_KHTBSNMB.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
            '開発場所郵便番号
            Index_Wk = CShort(Me.HD_KHTBSZIPCD.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所電話番号
            Index_Wk = CShort(Me.HD_KHTBSTL.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所FAX番号
            Index_Wk = CShort(Me.HD_KHTBSFAX.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))
            ' === 20061224 === INSERT E -

            '開発場所住所１
            Index_Wk = CShort(Me.HD_KHTBSADA.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所住所２
            Index_Wk = CShort(Me.HD_KHTBSADB.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            '開発場所住所３
            Index_Wk = CShort(Me.HD_KHTBSADC.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))

            'フォーカス退避用
            Index_Wk = CShort(Me.HD_Cursol_Wk_1.Tag)
            Call CF_Set_Item_Focus_Ctl(True, Main_Inf.Dsp_Sub_Inf(Index_Wk))
        Else
            'フォーカス退避用
            Index_Wk = CShort(Me.HD_Cursol_Wk_1.Tag)
            Call CF_Set_Item_Focus_Ctl(False, Main_Inf.Dsp_Sub_Inf(Index_Wk))
        End If
        ' === 20061015 === INSERT E -

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
                'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail

                '初期化用情報
                'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)

                '復元情報
                'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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

    End Function

    Private Sub FR_SSSSUB01_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        '    Set FR_SSSSUB01 = Nothing
        ' === 20060907 === INSERT S - ACE)Sejima
        Main_Inf.Dsp_Base.IsUnload = True
        ' === 20060907 === INSERT E

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
        '一度きりのため使用不可
        Main_Inf.TM_StartUp_Ctl.Enabled = False
        '初期ﾌｫｰｶｽ位置設定
        Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
    End Sub

    ' === 20060721 === DELETE S - ACE)Nagasawa
    'Private Sub Form_Activate()
    '
    '    '初期フォーカス位置設定
    '    Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
    '
    'End Sub
    ' === 20060721 === DELETE E - ACE)Nagasawa

    Private Sub FR_SSSSUB01_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '20190909 ADD START
        FORM_LOAD_FLG = True
        '20190909 ADD END

        '画面情報設定
        Call Init_Def_Dsp()

        '画面内容初期化
        Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)

        '画面明細情報設定
        Call Init_Def_Body_Inf()

        '画面明細部初期化
        Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '明細ロケーション
        Call Set_Body_Location()

        '初期表示編集
        Call Edi_Dsp_Def()

        '画面明細表示
        Call CF_Body_Dsp(Main_Inf)

        '画面表示位置設定
        Call CF_Set_Frm_Location(Me)

        '    '入力担当者編集
        '    Call CF_Set_Frm_IN_TANCD(FR_SSSSUB01, Main_Inf)

        'システム共通処理
        Call CF_System_Process(Me)

        '画面編集なしとする
        gv_bolUODET55A_INIT = False

        ''20190909  ADD START
        SetBar(Me)
        ''20190909  ADD END

    End Sub

    '20190909 ADD START
    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---戻り値設定---'
            SetBar = True

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    '20190909 ADD END
    Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
        Debug.Print("CM_EndCm_Click")
        Call Ctl_Item_Click(CM_EndCm)
    End Sub

    Private Sub CM_SLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click
        Debug.Print("CM_SLIST_Click")
        Call Ctl_Item_Click(CM_SLIST)
    End Sub

    Private Sub CS_KHTBSCD_Click()
        Debug.Print("CS_KHTBSCD_Click")
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_Click(CS_KHTBSCD)
    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        Debug.Print("Image1_Click")
        Call Ctl_Item_Click(Image1)
    End Sub

    Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
        Debug.Print("MN_APPENDC_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_APPENDC)
        '20190809 DLT END
    End Sub

    Public Sub MN_ClearDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearDE.Click
        Debug.Print("MN_ClearDE_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_ClearDE)
        '20190809 DLT END
    End Sub

    Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
        Debug.Print("MN_ClearItm_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_ClearItm)
        '20190809 DLT END
    End Sub

    Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
        Debug.Print("MN_Copy_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Copy)
        '20190809 DLT END
    End Sub

    Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
        Debug.Print("MN_Ctrl_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Ctrl)
        '20190809 DLT END
    End Sub

    Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
        Debug.Print("MN_Cut_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Cut)
        '20190809 DLT END
    End Sub

    Public Sub MN_DeleteCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteCM.Click
        Debug.Print("MN_DeleteCM_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_DeleteCM)
        '20190809 DLT END
    End Sub

    Public Sub MN_DeleteDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteDE.Click
        Debug.Print("MN_DeleteDE_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_DeleteDE)
        '20190809 DLT END
    End Sub

    Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
        Debug.Print("MN_EditMn_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_EditMn)
        '20190809 DLT END
    End Sub

    Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
        Debug.Print("MN_EndCm_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_EndCm)
        '20190809 DLT END
    End Sub

    Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
        Debug.Print("MN_Execute_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Execute)
        '20190809 DLT END
    End Sub

    Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
        Debug.Print("MN_HARDCOPY_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_HARDCOPY)
        '20190809 DLT END
    End Sub

    Public Sub MN_InsertDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_InsertDE.Click
        Debug.Print("MN_InsertDE_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_InsertDE)
        '20190809 DLT END
    End Sub

    Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
        Debug.Print("MN_Oprt_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Oprt)
        '20190809 DLT END
    End Sub

    Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
        Debug.Print("MN_Paste_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Paste)
        '20190809 DLT END
    End Sub

    Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
        Debug.Print("MN_Slist_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_Slist)
        '20190809 DLT END
    End Sub

    Public Sub MN_UnDoDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoDe.Click
        Debug.Print("MN_UnDoDe_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_UnDoDe)
        '20190809 DLT END
    End Sub

    Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
        Debug.Print("MN_UnDoItem_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(MN_UnDoItem)
        '20190809 DLT END
    End Sub

    Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseDown")
        Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseDown")
        Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADA_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSADA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADB_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSADB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADC_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADC.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADC_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSADC, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSNMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSNMA_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSNMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSNMB_MouseDown")
        Call Ctl_Item_MouseDown(HD_KHTBSNMB, Button, Shift, X, Y)
    End Sub

    Private Sub SYSDT_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseDown")
        'UPGRADE_WARNING: オブジェクト SYSDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
    End Sub

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

    Private Sub CM_SLIST_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseMove")
        Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
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

    Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseUp")
        Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CS_KHTBSCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_KHTBSCD_MouseUp")
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(CS_KHTBSCD, Button, Shift, X, Y)
    End Sub

    Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("FM_Panel3D1_MouseUp")
        'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADA_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSADA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADB_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSADB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADC_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSADC.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSADC_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSADC, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSNMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSNMA_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSNMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KHTBSNMB_MouseUp")
        Call Ctl_Item_MouseUp(HD_KHTBSNMB, Button, Shift, X, Y)
    End Sub

    Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("Image1_MouseUp")
        Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
    End Sub

    Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseUp")
        'UPGRADE_WARNING: オブジェクト SYSDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Message_MouseUp")
        Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KHTBSADA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADA_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSADA, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSADB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADB_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSADB, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSADC_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADC.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADC_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSADC, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSCD, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSNMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSNMA_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSNMA, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSNMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSNMB_KeyDown")
        Call Ctl_Item_KeyDown(HD_KHTBSNMB, KeyCode, Shift)
    End Sub

    Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TX_Message_KeyDown")
        Call Ctl_Item_KeyDown(TX_Message, KeyCode, Shift)
    End Sub

    Private Sub HD_KHTBSADA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSADA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSADA_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSADA, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KHTBSADB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSADB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSADB_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSADB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KHTBSADC_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSADC.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSADC_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSADC, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KHTBSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KHTBSNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSNMA_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSNMA, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KHTBSNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSNMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KHTBSNMB_KeyPress")
        Call Ctl_Item_KeyPress(HD_KHTBSNMB, KeyAscii)
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

    Private Sub CS_KHTBSCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
        Debug.Print("CS_KHTBSCD_KeyUp")
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_KeyUp(CS_KHTBSCD)
    End Sub

    Private Sub CS_KHTBSCD_GotFocus()
        Debug.Print("CS_KHTBSCD_GotFocus")
        'UPGRADE_WARNING: オブジェクト CS_KHTBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_GotFocus(CS_KHTBSCD)
    End Sub

    Private Sub HD_KHTBSADA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADA.Enter
        Debug.Print("HD_KHTBSADA_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSADA)
    End Sub

    Private Sub HD_KHTBSADB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADB.Enter
        Debug.Print("HD_KHTBSADB_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSADB)
    End Sub

    Private Sub HD_KHTBSADC_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADC.Enter
        Debug.Print("HD_KHTBSADC_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSADC)
    End Sub

    Private Sub HD_KHTBSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSCD.Enter
        Debug.Print("HD_KHTBSCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSCD)
    End Sub

    Private Sub HD_KHTBSNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMA.Enter
        Debug.Print("HD_KHTBSNMA_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSNMA)
    End Sub

    Private Sub HD_KHTBSNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMB.Enter
        Debug.Print("HD_KHTBSNMB_GotFocus")
        Call Ctl_Item_GotFocus(HD_KHTBSNMB)
    End Sub

    Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
        Debug.Print("TX_Message_GotFocus")
        Call Ctl_Item_GotFocus(TX_Message)
    End Sub

    Private Sub HD_KHTBSADA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADA.Leave
        Debug.Print("HD_KHTBSADA_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSADA)
    End Sub

    Private Sub HD_KHTBSADB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADB.Leave
        Debug.Print("HD_KHTBSADB_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSADB)
    End Sub

    Private Sub HD_KHTBSADC_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADC.Leave
        Debug.Print("HD_KHTBSADC_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSADC)
    End Sub

    Private Sub HD_KHTBSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSCD.Leave
        Debug.Print("HD_KHTBSCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSCD)
    End Sub

    Private Sub HD_KHTBSNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMA.Leave
        Debug.Print("HD_KHTBSNMA_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSNMA)
    End Sub

    Private Sub HD_KHTBSNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMB.Leave
        Debug.Print("HD_KHTBSNMB_LostFocus")
        Call Ctl_Item_LostFocus(HD_KHTBSNMB)
    End Sub

    Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
        Debug.Print("TX_Message_LostFocus")
        Call Ctl_Item_LostFocus(TX_Message)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSADA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSADA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADA.TextChanged
        Debug.Print("HD_KHTBSADA_Change")
        Call Ctl_Item_Change(HD_KHTBSADA)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSADB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSADB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADB.TextChanged
        Debug.Print("HD_KHTBSADB_Change")
        Call Ctl_Item_Change(HD_KHTBSADB)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSADC.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSADC_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSADC.TextChanged
        Debug.Print("HD_KHTBSADC_Change")
        Call Ctl_Item_Change(HD_KHTBSADC)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSCD.TextChanged
        Debug.Print("HD_KHTBSCD_Change")
        Call Ctl_Item_Change(HD_KHTBSCD)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMA.TextChanged
        Debug.Print("HD_KHTBSNMA_Change")
        Call Ctl_Item_Change(HD_KHTBSNMA)
    End Sub

    'UPGRADE_WARNING: イベント HD_KHTBSNMB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_KHTBSNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSNMB.TextChanged
        Debug.Print("HD_KHTBSNMB_Change")
        Call Ctl_Item_Change(HD_KHTBSNMB)
    End Sub

    'UPGRADE_WARNING: イベント TX_Message.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
        Debug.Print("TX_Message_Change")
        Call Ctl_Item_Change(TX_Message)
    End Sub

    Private Sub HD_KHTBSADA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADA_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSADA)
    End Sub

    Private Sub HD_KHTBSADB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADB_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSADB)
    End Sub

    Private Sub HD_KHTBSADC_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSADC.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSADC_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSADC)
    End Sub

    Private Sub HD_KHTBSCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSCD)
    End Sub

    Private Sub HD_KHTBSNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSNMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSNMA_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSNMA)
    End Sub

    Private Sub HD_KHTBSNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSNMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KHTBSNMB_KeyUp")
        Call Ctl_Item_KeyUp(HD_KHTBSNMB)
    End Sub

    Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
        Debug.Print("SM_AllCopy_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(SM_AllCopy)
        '20190809 DLT END
    End Sub

    Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
        Debug.Print("SM_Esc_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(SM_Esc)
        '20190809 DLT END
    End Sub

    Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
        Debug.Print("SM_FullPast_Click")
        '20190809 DLT START
        'Call Ctl_Item_Click(SM_FullPast)
        '20190809 DLT END
    End Sub

    ' === 20061015 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
    Private Sub HD_Cursol_Wk_1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Cursol_Wk_1.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_Cursol_Wk_1_KeyDown")
		Call Ctl_Item_KeyDown(HD_Cursol_Wk_1, KeyCode, Shift)
	End Sub
	
	Private Sub HD_Cursol_Wk_1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_Cursol_Wk_1.Enter
		Debug.Print("HD_Cursol_Wk_1_GotFocus")
		Call Ctl_Item_GotFocus(HD_Cursol_Wk_1)
	End Sub
	
	Private Sub HD_Cursol_Wk_1_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Cursol_Wk_1.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_Cursol_Wk_1_KeyUp")
		Call Ctl_Item_KeyUp(HD_Cursol_Wk_1)
	End Sub
	' === 20061015 === INSERT E -
	
	' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	'UPGRADE_WARNING: イベント HD_KHTBSZIPCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KHTBSZIPCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSZIPCD.TextChanged
		Debug.Print("HD_KHTBSZIPCD_Change")
		Call Ctl_Item_Change(HD_KHTBSZIPCD)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSZIPCD.Enter
		Debug.Print("HD_KHTBSZIPCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_KHTBSZIPCD)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSZIPCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSZIPCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_KHTBSZIPCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSZIPCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_KHTBSZIPCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_KHTBSZIPCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KHTBSZIPCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSZIPCD.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSZIPCD_KeyUp")
		Call Ctl_Item_KeyUp(HD_KHTBSZIPCD)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSZIPCD.Leave
		Debug.Print("HD_KHTBSZIPCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_KHTBSZIPCD)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSZIPCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSZIPCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_KHTBSZIPCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KHTBSZIPCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSZIPCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSZIPCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_KHTBSZIPCD, Button, Shift, X, Y)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_KHTBSTL.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KHTBSTL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSTL.TextChanged
		Debug.Print("HD_KHTBSTL_Change")
		Call Ctl_Item_Change(HD_KHTBSTL)
	End Sub
	
	Private Sub HD_KHTBSTL_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSTL.Enter
		Debug.Print("HD_KHTBSTL_GotFocus")
		Call Ctl_Item_GotFocus(HD_KHTBSTL)
	End Sub
	
	Private Sub HD_KHTBSTL_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSTL.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSTL_KeyDown")
		Call Ctl_Item_KeyDown(HD_KHTBSTL, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KHTBSTL_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSTL.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_KHTBSTL_KeyPress")
		Call Ctl_Item_KeyPress(HD_KHTBSTL, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KHTBSTL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSTL.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSTL_KeyUp")
		Call Ctl_Item_KeyUp(HD_KHTBSTL)
	End Sub
	
	Private Sub HD_KHTBSTL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSTL.Leave
		Debug.Print("HD_KHTBSTL_LostFocus")
		Call Ctl_Item_LostFocus(HD_KHTBSTL)
	End Sub
	
	Private Sub HD_KHTBSTL_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSTL.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSTL_MouseDown")
		Call Ctl_Item_MouseDown(HD_KHTBSTL, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KHTBSTL_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSTL.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSTL_MouseUp")
		Call Ctl_Item_MouseUp(HD_KHTBSTL, Button, Shift, X, Y)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_KHTBSFAX.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KHTBSFAX_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSFAX.TextChanged
		Debug.Print("HD_KHTBSFAX_Change")
		Call Ctl_Item_Change(HD_KHTBSFAX)
	End Sub
	
	Private Sub HD_KHTBSFAX_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSFAX.Enter
		Debug.Print("HD_KHTBSFAX_GotFocus")
		Call Ctl_Item_GotFocus(HD_KHTBSFAX)
	End Sub
	
	Private Sub HD_KHTBSFAX_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSFAX.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSFAX_KeyDown")
		Call Ctl_Item_KeyDown(HD_KHTBSFAX, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KHTBSFAX_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KHTBSFAX.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_KHTBSFAX_KeyPress")
		Call Ctl_Item_KeyPress(HD_KHTBSFAX, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KHTBSFAX_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KHTBSFAX.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KHTBSFAX_KeyUp")
		Call Ctl_Item_KeyUp(HD_KHTBSFAX)
	End Sub
	
	Private Sub HD_KHTBSFAX_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KHTBSFAX.Leave
		Debug.Print("HD_KHTBSFAX_LostFocus")
		Call Ctl_Item_LostFocus(HD_KHTBSFAX)
	End Sub
	
	Private Sub HD_KHTBSFAX_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSFAX.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSFAX_MouseDown")
		Call Ctl_Item_MouseDown(HD_KHTBSFAX, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KHTBSFAX_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KHTBSFAX.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KHTBSFAX_MouseUp")
		Call Ctl_Item_MouseUp(HD_KHTBSFAX, Button, Shift, X, Y)
	End Sub

    '20190910 ADD START
    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        Debug.Print("btnF5_Click")
        Call Ctl_Item_Click(btnF5)
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Debug.Print("btnF9_Click")
        btnF9.Select()
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Debug.Print("btnF12_Click")
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub CS_KHTBSCD_Click(sender As Object, e As EventArgs) Handles CS_KHTBSCD.Click
        Debug.Print("CS_KHTBSCD_Click")
        Call Ctl_Item_Click(CS_KHTBSCD)
    End Sub

    Private Sub FR_SSSSUB01_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    'Me.btnF1.PerformClick()
                Case Keys.F5
                    Me.btnF5.PerformClick()
                Case Keys.F9
                    Me.btnF9.PerformClick()
                Case Keys.F12
                    Me.btnF12.PerformClick()
            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190910 ADD END
    ' === 20061224 === INSERT E -
End Class