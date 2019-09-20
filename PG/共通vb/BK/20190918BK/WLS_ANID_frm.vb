Option Strict Off
Option Explicit On
Friend Class WLS_ANID
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　案件検索
	'*  プログラムＩＤ　：  WLSTAN
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.12
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "0" '開始コード入力属性 [0,X]
	
	Private Const FM_PANEL3D1_CNT As Short = 2 'パネルコントロール数
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_AKNVIEW_W As TYPE_DB_ANKNVIEW
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
	Private WM_WLS_MAX As Short
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'画面基礎情報設定
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REFERENCE '画面分類
            ' === 20060922 === UPDATE S - ACE)Sejima
            'D        .Item_Cnt = 12                              '画面項目数
            ' === 20060922 === UPDATE ↓
            '20190514 CHG START
            '.Item_Cnt = 13 '画面項目数
            .Item_Cnt = 15 '画面項目数
            '20190514 CHG END

            ' === 20060922 === UPDATE E
            .Dsp_Body_Cnt = 0 '画面表示明細数（０：明細なし、１～：表示時明細数）
			.Max_Body_Cnt = 0 '最大表示明細数（０：明細なし、１～：最大明細数）
			.Body_Col_Cnt = 0 '明細の列項目数
			.Dsp_Body_Move_Qty = 0 '画面移動量
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
		
		Index_Wk = 0
		
		'///////////////////
		'// ヘッダ部編集
		'///////////////////
		'担当者ボタン
		'UPGRADE_WARNING: オブジェクト CS_TANCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_TANCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TANCD
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'担当者(ｺｰﾄﾞ)
		HD_TANCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		' === 20070206 === UPDATE E -
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'担当者(名称)
		HD_TANNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANNM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'受注予定日ボタン
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_JDNYTDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNYTDT
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'受注予定日
		HD_JDNYTDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNYTDT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'案件ID
		HD_OAKNID.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_OAKNID
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'リスト
		LST.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = LST
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1

        'OKボタン
        '20190705 CHG START
        'WLSOK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
        btnF1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '20190705 CHG END

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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1


        '20190705 ADD START

        '検索イメージ
        btnF2.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF2
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '20190705 ADD END


        '前ページイメージ
        '20190705 CHG START
        'CM_PrevCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '20190705 CHG END
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ｲﾒｰｼﾞ設定 ======================
		Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
		Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
		'=== ｲﾒｰｼﾞ設定 ======================
		
		Index_Wk = Index_Wk + 1

        '次ページイメージ
        '20190705 CHG START
        'CM_NextCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '20190705 CHG END

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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NextCm(0)
        Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NextCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================


        '20190705 ADD START
        Index_Wk = Index_Wk + 1

        'クリアイメージ
        btnF9.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '20190705 ADD END

        'キャンセルボタン
        '20190705 CHG START
        'WLSCANCEL.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190705 CHG END

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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        '20190705 DEL START
        'Index_Wk = Index_Wk + 1
        '20190705 DEL END


        '画面基礎情報設定
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////////
        '// その他編集
        '///////////////////
        '20190517 CHG START
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1
        '    'FM_Panel3D1
        '    'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        'Next

        Index_Wk = Index_Wk + 1
        'FM_Panel3D1
        'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        _FM_Panel3D1_0.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = _FM_Panel3D1_0
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        'FM_Panel3D1
        'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        _FM_Panel3D1_1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = _FM_Panel3D1_1
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '20190517 CHG END


        ' === 20060922 === INSERT S - ACE)Sejima
        Index_Wk = Index_Wk + 1
		'ヘッダパネル
		Panel3D1.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Panel3D1
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		' === 20060922 === INSERT E
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
		Call CF_Init_Item_Property(Main_Inf)
		'画面項目情報を再設定
		Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)
		
		'///////////////////
		'// 特別項目の再設定
		'///////////////////
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'リスト行数の設定
		WM_WLS_MAX = 15
		
		'返り値の設定
		WLSANK_RTNCODE = ""
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLSANID0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
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
		Call WLSANID0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Select Case Me.ActiveControl.Name
				Case HD_TANCD.Name, HD_JDNYTDT.Name, HD_OAKNID.Name
					'変数クリア
					Call WLS_Clear()
					'リスト編集
					Call Get_AKNVIEW()
					Call WLS_DspNew()
					
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)
					
				Case LST.Name
					Call Ctl_WLSOK_Click()
					
				Case Else
			End Select
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Clear
	'   概要：  変数初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		'画面表示ページ
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'検索結果保持配列
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_AKNVIEW
	'   概要：  案件情報検索
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_AKNVIEW() As Short
		
		Dim strSQL As String
		Dim strWhere As String
		
		' === 20060821 === INSERT S - ACE)Nagasawa
		On Error GoTo Get_AKNVIEW_Err
		' === 20060821 === INSERT E -
		
		'案件情報検索処理
		strSQL = ""
		strWhere = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        ""chAssignedName"" AS chAssignedName  " '担当者名
		strSQL = strSQL & "      , ""vchDesc1""       AS vchDesc1        " '件名
		strSQL = strSQL & "      , ""CompanyName""    AS CompanyName     " '得意先名
		strSQL = strSQL & "      , ""vchUser6""       AS vchUser6        " '代表型式
		strSQL = strSQL & "      , ""vchUser3""       AS vchUser3        " '受注予定日
		strSQL = strSQL & "      , ""iIncidentid""    AS iIncidentId     " '案件ID
		strSQL = strSQL & "      , ""vchUser10""      AS vchUser10       " '親案件ID
		strSQL = strSQL & "   From cszIncidentHanbai@HSODBC "
		'    strSQL = strSQL & "  Where (iStatusId              = " & gc_strANSTS_OPEN & " "
		'    strSQL = strSQL & "     or  iStatusId              = " & gc_strANSTS_KZK_OPEN & ") "
		
		'担当者ID
		If Trim(HD_TANCD.Text) <> "" Then
			strWhere = strWhere & "        Trim(""chAssignedTo"")  = '" & CF_Ora_Sgl(Trim(HD_TANCD.Text)) & "' "
		End If
		
		'親案件ID
		If IsNumeric(HD_OAKNID.Text) = True Then
			If Trim(strWhere) <> "" Then
				strWhere = strWhere & " and "
			End If
			strWhere = strWhere & "        Trim(""vchUser10"")      = '" & Trim(CStr(CInt(HD_OAKNID.Text))) & "' "
		End If
		
		If Trim(strWhere) <> "" Then
			strSQL = strSQL & " Where " & strWhere
		End If
		
		strSQL = strSQL & "  Order By "
		strSQL = strSQL & "           chAssignedName "
		strSQL = strSQL & "         , vchUser10      "
		strSQL = strSQL & "         , iIncidentId    "
		
		If Dyn_Open = True Then
            'クローズ
            '20190514 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190514 DEL END
            Dyn_Open = False
		End If

        'DBアクセス
        '20190514 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190514 CHG END

        Dyn_Open = True

        '20190514 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190514 CHG END
            LST.Items.Clear()
        End If

        ' === 20060821 === INSERT S - ACE)Nagasawa
        Exit Function
		
Get_AKNVIEW_Err: 
		LST.Items.Clear()
		' === 20060821 === INSERT E -
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		
		Dim Cnt As Integer
		Dim strJDNYTDT As String '受注予定日（案件情報・画面表示用）
		Dim strJDNYTDT_A As String '受注予定日（案件情報・検索条件比較用）
		Dim strJDNYTDT_W As String '受注予定日（画面・検索条件用）
		Dim bolPrev As Boolean '次頁検索フラグ（True：検索中）
		Dim bolNextData As Boolean '次頁存在フラグ（True：あり）
		
		Cnt = 0
		bolPrev = False
		bolNextData = False
		
		' === 20060821 === INSERT S - ACE)Nagasawa
		On Error GoTo WLS_DspNew_Err
        ' === 20060821 === INSERT E -


        '20190514 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'画面の受注予定日を取得
        '	If IsDate(HD_JDNYTDT.Text) = True Then
        '		strJDNYTDT_W = VB6.Format(Trim(HD_JDNYTDT.Text), "yyyymmdd")
        '	Else
        '		strJDNYTDT_W = "0"
        '	End If

        '	'案件情報の受注予定日を取得
        '	If IsDate(CF_Ora_GetDyn(Usr_Ody, "vchUser3", "")) = True Then
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strJDNYTDT = VB6.Format(CDate(CF_Ora_GetDyn(Usr_Ody, "vchUser3", "")), "yyyy/mm/dd")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		strJDNYTDT_A = VB6.Format(CDate(CF_Ora_GetDyn(Usr_Ody, "vchUser3", "")), "yyyymmdd")
        '	Else
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		If IsDate(VB6.Format(CF_Ora_GetDyn(Usr_Ody, "vchUser3", ""), "@@@@/@@/@@")) = True Then
        '			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			strJDNYTDT = VB6.Format(CF_Ora_GetDyn(Usr_Ody, "vchUser3", ""), "@@@@/@@/@@")
        '			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			strJDNYTDT_A = CF_Ora_GetDyn(Usr_Ody, "vchUser3", "")
        '		Else
        '			strJDNYTDT = Space(10)
        '			If strJDNYTDT_W = "0" Then
        '				strJDNYTDT_A = "0"
        '			Else
        '				strJDNYTDT_A = "-1"
        '			End If
        '		End If
        '	End If

        '	If CInt(strJDNYTDT_W) <= CInt(strJDNYTDT_A) Then

        '		If bolPrev = False Then

        '			'取得内容退避
        '			With DB_AKNVIEW_W
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.TANNM = CF_Ora_GetDyn(Usr_Ody, "chAssignedName", "") '担当者名
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.KENNM = CF_Ora_GetDyn(Usr_Ody, "vchDesc1", "") '件名
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.TOKRN = CF_Ora_GetDyn(Usr_Ody, "CompanyName", "") '得意先名
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.HINNMA = CF_Ora_GetDyn(Usr_Ody, "vchUser6", "") '代表型式
        '				.JDNYTDT = strJDNYTDT '受注予定日
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.ANKNID = VB6.Format(CF_Ora_GetDyn(Usr_Ody, "iIncidentId", 0), New String("0", 8)) '案件ID

        '				'親案件ID
        '				If IsNumeric(CF_Ora_GetDyn(Usr_Ody, "vchUser10", "")) = True Then
        '					' === 20060929 === UPDATE S - ACE)Nagasawa
        '					'                        .ANID_OYA = Format(CInt(CF_Ora_GetDyn(Usr_Ody, "vchUser10", "")), String(8, "0"))
        '					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '					.ANID_OYA = VB6.Format(CDec(CF_Ora_GetDyn(Usr_Ody, "vchUser10", "")), New String("0", 8))
        '					' === 20060929 === UPDATE E -
        '				Else
        '					.ANID_OYA = ""
        '				End If
        '			End With

        '			'表示改ページ
        '			If Cnt Mod WM_WLS_MAX = 0 Then
        '				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '				ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '				Cnt = 0
        '				'最終ページ退避
        '				WM_WLS_LastPage = WM_WLS_Pagecnt
        '			End If

        '			'表示メモリ展開
        '			Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '			Cnt = Cnt + 1
        '		Else
        '			'次頁あり
        '			bolNextData = True
        '		End If
        '	End If

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If bolPrev = True And bolNextData = True Then
        '		Exit Do
        '	End If

        '	If Cnt >= WM_WLS_MAX Then
        '		bolPrev = True
        '	End If
        'Loop 

        ''次頁がある場合は巻き戻し
        'If bolPrev = True And bolNextData = True Then
        '	Call CF_Ora_MovePrev(Usr_Ody)
        '	Call CF_Ora_MovePrev(Usr_Ody)
        '	Call CF_Ora_MoveNext(Usr_Ody)
        'End If

        ''最終データ到達
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        'End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            '画面の受注予定日を取得
            If IsDate(HD_JDNYTDT.Text) = True Then
                strJDNYTDT_W = VB6.Format(Trim(HD_JDNYTDT.Text), "yyyymmdd")
            Else
                strJDNYTDT_W = "0"
            End If

            '案件情報の受注予定日を取得
            If IsDate(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), "")) = True Then
                strJDNYTDT = VB6.Format(CDate(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), "")), "yyyy/mm/dd")
                strJDNYTDT_A = VB6.Format(CDate(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), "")), "yyyymmdd")
            Else
                If IsDate(VB6.Format(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), ""), "@@@@/@@/@@")) = True Then
                    strJDNYTDT = VB6.Format(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), ""), "@@@@/@@/@@")
                    strJDNYTDT_A = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser3"), "")
                Else
                    strJDNYTDT = Space(10)
                    If strJDNYTDT_W = "0" Then
                        strJDNYTDT_A = "0"
                    Else
                        strJDNYTDT_A = "-1"
                    End If
                End If
            End If

            If CInt(strJDNYTDT_W) <= CInt(strJDNYTDT_A) Then

                If bolPrev = False Then

                    '取得内容退避
                    DB_AKNVIEW_W.TANNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("chAssignedName"), "") '担当者名
                    DB_AKNVIEW_W.KENNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchDesc1"), "") '件名
                    DB_AKNVIEW_W.TOKRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("CompanyName"), "") '得意先名
                    DB_AKNVIEW_W.HINNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser6"), "") '代表型式
                    DB_AKNVIEW_W.JDNYTDT = strJDNYTDT '受注予定日
                    DB_AKNVIEW_W.ANKNID = VB6.Format(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("iIncidentId"), ""), New String("0", 8)) '案件ID

                    '親案件ID
                    If IsNumeric(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser10"), "")) = True Then
                        DB_AKNVIEW_W.ANID_OYA = VB6.Format(CDec(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("vchUser10"), "")), New String("0", 8))
                    Else
                        DB_AKNVIEW_W.ANID_OYA = ""
                    End If

                    '表示改ページ
                    If Cnt Mod WM_WLS_MAX = 0 Then
                        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                        ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                        Cnt = 0
                        '最終ページ退避
                        WM_WLS_LastPage = WM_WLS_Pagecnt
                    End If

                    '表示メモリ展開
                    Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

                    Cnt = Cnt + 1

                Else
                    '次頁あり
                    bolNextData = True
                End If

            End If

            If bolPrev = True And bolNextData = True Then
                Exit For
            End If

            If Cnt >= WM_WLS_MAX Then
                bolPrev = True
            End If
        Next

        WM_WLS_LastFL = True
        '20190514 CHG END

        If Cnt > 0 Then
            'ページを表示
            '20190514 ADD START
            WM_WLS_Pagecnt = 0
            '20190514 ADD END
            Call WLS_DspPage()
        End If

        ' === 20060821 === INSERT S - ACE)Nagasawa
        Exit Sub
		
WLS_DspNew_Err: 
		WM_WLS_LastFL = True
		' === 20060821 === INSERT E -
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		With DB_AKNVIEW_W
			' === 20061127 === UPDATE S - ACE)Nagasawa
			'            WM_WLS_DSPArray(ArrayCnt) = LeftWid$(.TANNM, 6) & Space(1) & _
			''                                        LeftWid$(.KENNM, 40) & Space(1) & _
			''                                        LeftWid$(.TOKRN, 36) & Space(1) & _
			''                                        LeftWid$(.HINNMA, 30) & Space(1) & _
			''                                        LeftWid$(.JDNYTDT, 10) & Space(1) & _
			''                                        LeftWid$(.ANKNID, 8) & Space(1) & _
			''                                        LeftWid$(.ANID_OYA, 8) & Space(10) & _
			''                                        LeftWid$(.ANKNID, 8)
			
			WM_WLS_DSPArray(ArrayCnt) = CF_SpaceLenFormat(LeftWid(.TANNM, 6), 6, True) & Space(1) & CF_SpaceLenFormat(LeftWid(.KENNM, 40), 40) & Space(1) & CF_SpaceLenFormat(LeftWid(.TOKRN, 36), 36) & Space(1) & CF_SpaceLenFormat(LeftWid(.HINNMA, 28), 28) & Space(1) & CF_SpaceLenFormat(LeftWid(.JDNYTDT, 10), 10) & Space(1) & CF_SpaceLenFormat(LeftWid(.ANKNID, 8), 8) & Space(1) & CF_SpaceLenFormat(LeftWid(.ANID_OYA, 8), 8) & Space(10) & CF_SpaceLenFormat(LeftWid(.ANKNID, 8), 8) & Space(2)
			' === 20061127 === UPDATE E -
		End With
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspPage
	'   概要：  リスト編集処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim intCnt As Short
		
		LST.Items.Clear()
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		intCnt = 0
		Do While intCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			' === 20061228 === INSERT S - ACE)Nagasawa
			On Error Resume Next
			' === 20061228 === INSERT E -
			LST.Focus()
		End If
	End Sub
	
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'KEYRIGHT制御
		Call WLSANID0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSANID0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSANID0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_OAKNID.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call Get_AKNVIEW()
						Call WLS_DspNew()
					Case Else
				End Select
				'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
				Call WLSANID0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'            'ﾁｪｯｸ後移動あり
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		'
		'    Dim Move_Flg        As Boolean
		'    Dim Rtn_Chk         As Integer
		'    Dim Chk_Move_Flg    As Boolean
		'    Dim Dsp_Mode        As Integer
		'
		'    Move_Flg = False
		'    Chk_Move_Flg = False
		'
		'    '各項目のﾁｪｯｸﾙｰﾁﾝ
		'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		'
		'    If Rtn_Chk = CHK_OK Then
		'    'チェックＯＫ時
		'        '取得内容表示
		'        Dsp_Mode = DSP_SET
		'    Else
		'    'チェックＮＧ時
		'        '取得内容クリア
		'        Dsp_Mode = DSP_CLR
		'    End If
		'    '取得内容表示/クリア
		'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		'
		'    If Chk_Move_Flg = True Then
		'    'ﾁｪｯｸ後移動あり
		'        'KEYDOWN制御
		'        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		'        If Move_Flg = True Then
		'        '次の項目へ移動した場合
		'            'ﾁｪｯｸ後移動あり
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'        Else
		'            '選択状態の設定（初期選択）
		'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'
		'            '項目色設定
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
		'        End If
		'    Else
		'        'ﾁｪｯｸ後移動なし
		'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
		'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
		'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'    End If
		
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
		Call WLSANID0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSANID0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSANID0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
				Call WLSANID0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'            'ﾁｪｯｸ後移動あり
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		
		'    Dim Move_Flg        As Boolean
		'    Dim Rtn_Chk         As Integer
		'    Dim Chk_Move_Flg    As Boolean
		'    Dim Dsp_Mode        As Integer
		'
		'    Move_Flg = False
		'    Chk_Move_Flg = True
		'
		'    '各項目のﾁｪｯｸﾙｰﾁﾝ
		'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		'
		'    If Rtn_Chk = CHK_OK Then
		'    'チェックＯＫ時
		'        '取得内容表示
		'        Dsp_Mode = DSP_SET
		'    Else
		'    'チェックＮＧ時
		'        '取得内容クリア
		'        Dsp_Mode = DSP_CLR
		'    End If
		'    '取得内容表示/クリア
		'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		'
		'    If Chk_Move_Flg = True Then
		'    'ﾁｪｯｸ後移動あり
		'        'KEYUP制御
		'        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		'
		'        If Move_Flg = True Then
		'        '次の項目へ移動した場合
		'            'ﾁｪｯｸ後移動あり
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'        Else
		'            '選択状態の設定（初期選択）
		'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'
		'            '項目色設定
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
		'        End If
		'
		'    Else
		'    'ﾁｪｯｸ後移動なし
		'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
		'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
		'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'    End If
		
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
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		Move_Flg = True
		
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
				'            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				Call WLSANID0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, Main_Inf, True)
				
				'Shift+TAB押
			Case pm_KeyCode = System.Windows.Forms.Keys.F15
				pm_KeyCode = 0
				'前ﾌｫｰｶｽ位置へ移動
				Call WLSANID0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
				'F5押
			Case pm_KeyCode = System.Windows.Forms.Keys.F5 And Trg_Index = CShort(HD_JDNYTDT.Tag)
				pm_KeyCode = 0
				'UPGRADE_WARNING: オブジェクト CS_JDNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call Ctl_Item_Click(CS_JDNYTDT)
				
				'F5押
			Case pm_KeyCode = System.Windows.Forms.Keys.F5 And Trg_Index = CShort(HD_TANCD.Tag)
				pm_KeyCode = 0
				'UPGRADE_WARNING: オブジェクト CS_TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call Ctl_Item_Click(CS_TANCD)
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
		
		' === 20060902 === INSERT S - ACE)Nagasawa
		If gv_bolWLSANID_LF_Enable = False Then
			Exit Function
		End If
		' === 20060902 === INSERT E -
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLSANID0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call WLSANID0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'        'ﾁｪｯｸ後移動あり
			'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			
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
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'画面単位の処理(ﾁｪｯｸなど)
		'明細部でかつ移動前が明細部でない場合
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'ﾍｯﾀﾞ部ﾁｪｯｸ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If
		
		' === 20060810 === INSERT S - ACE)Nagasawa 検索画面表示ボタンを押したことが見えるようにする対応
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '2019/03/12 CHG START
        'If TypeOf pm_Ctl Is SSCommand5 Then
        If TypeOf pm_Ctl Is Button Then
            '2019/03/12 CHG E N D
            '検索画面呼出の場合は終了
            Exit Function
        End If
        ' === 20060810 === INSERT E

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        Select Case Trg_Index
            Case Else
                '共通ﾌｫｰｶｽ取得処理
                Call WLSANID0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)


        End Select
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'共通KEYPRESS制御
		Call WLSANID0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSANID0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSANID0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_OAKNID.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call Get_AKNVIEW()
						Call WLS_DspNew()
					Case Else
				End Select
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call WLSANID0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
				'            'ﾁｪｯｸ後移動あり
				'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				
				'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
				'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			End If
			
		Else
			'        '項目色設定(入力開始で色をﾌｫｰｶｽありの前景色＝黒に設定！！)
			'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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
		Call WLSANID0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		
		' === 20061205 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061205 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
				'            '項目色設定
				'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
				
				' === 20060810 === INSERT S - ACE)Nagasawa　検索Wボタン対応
                '2019/03/12 CHG START
                'Case TypeOf pm_Ctl Is SSCommand5
            Case TypeOf pm_Ctl Is Button
                '2019/03/12 CHG E N D
                'ボタンの場合
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                '2019/03/12 CHG START
                'If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    '2019/03/12 CHG E N D
                    Call WLSANID0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060810 === INSERT E -

                '2019/03/12 CHG START
                'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '2019/03/12 CHG E N D
                'パネルの場合
                Call WLSANID0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060922 === INSERT S - ACE)Sejima
            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                'ピクチャーの場合
                Call WLSANID0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                ' === 20060922 === INSERT E

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                'イメージの場合
                Select Case Trg_Index
                    Case CShort(CM_PrevCm.Tag)
                        '前頁ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                    Case CShort(CM_NextCm.Tag)
                        '次頁ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
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
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(CM_PrevCm.Tag)
				'前頁ｲﾒｰｼﾞ
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)
			Case CShort(CM_NextCm.Tag)
				'次頁ｲﾒｰｼﾞ
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)
		End Select
		
		'共通MOUSEDOWN制御
		Call WLSANID0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'各検索画面呼出
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_TANCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			Case CShort(CS_TANCD.Tag)
				'受注取引区分検索画面呼出
				Call WLSANID0001.F_Ctl_CS_TANCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_JDNYTDT.Tag)
				'見積日検索画面呼出
				Call WLSANID0001.F_Ctl_CS_JDNYTDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                '20190604 CHG START
   '         Case CShort(CM_PrevCm.Tag)
            '	'前頁
            '	Call Ctl_CM_PrevCm_Click()

            'Case CShort(CM_NextCm.Tag)
            '	'次頁
            '	Call Ctl_CM_NextCm_Click()

            'Case CShort(WLSOK.Tag)
            '	'OK
            '	Call Ctl_WLSOK_Click()

            'Case CShort(WLSCANCEL.Tag)
   '             'キャンセル
   '             Call Ctl_WLSCANCEL_Click()

            Case CShort(btnF7.Tag)
                '前頁
                Call Ctl_CM_PrevCm_Click()

            Case CShort(btnF8.Tag)
                '次頁
                Call Ctl_CM_NextCm_Click()

            Case CShort(btnF1.Tag)
                'OK
                Call Ctl_WLSOK_Click()

            Case CShort(btnF12.Tag)
                'キャンセル
                Call Ctl_WLSCANCEL_Click()
                '20190604 CHG END


        End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_CM_PrevCm_Click
	'   概要：  前ページ
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_CM_PrevCm_Click() As Short
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_CM_NextCm_Click
	'   概要：  次ページ
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_CM_NextCm_Click() As Short
		
		If LST.Items.Count <= 0 Then Exit Function
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_WLSOK_Click
	'   概要：  OKボタン押下時
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_WLSOK_Click() As Short
		
		WLSANK_RTNCODE = RightWid(VB6.GetItemString(LST, LST.SelectedIndex), 8)
		
		Call Ctl_WLSCANCEL_Click()
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_WLSCANCEL_Click
	'   概要：  キャンセルボタン押下時
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_WLSCANCEL_Click() As Short
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		Hide()
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目の貼り付け
		Call WLSANID0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
		
		' === 20061117 === INSERT S - ACE)Nagasawa VBエラー発生対応
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061117 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'画面内容初期化
		Call WLSANID0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)
		
		'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Select Case Me.ActiveControl.Name
			Case HD_TANCD.Name
				Call WLSANID0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
				
		End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'共通ﾌｫｰｶｽ取得処理
		Call WLSANID0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	End Function
	
	'UPGRADE_WARNING: Form イベント WLS_ANID.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_ANID_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'    '初期フォーカス位置設定
		'    Call WLSANID0001.F_Init_Cursor_Set(Main_Inf)
		
	End Sub

    Private Sub WLS_ANID_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '画面情報設定
        Call Init_Def_Dsp()

        '画面内容初期化
        Call WLSANID0001.F_Init_Clr_Dsp(-1, Main_Inf)

        '初期表示編集
        Call Edi_Dsp_Def()

        '画面表示位置設定
        Call CF_Set_Frm_Location(Me)

        'システム共通処理
        Call CF_System_Process(Me)

    End Sub


    '20190705 ADD START
    Private Sub WLS_ANID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub


    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_JDNYTDT.Focused Then
                Call HD_JDNYTDT_KeyDown(HD_JDNYTDT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_OAKNID.Focused Then
                Call HD_OAKNID_KeyDown(HD_OAKNID, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_TANCD_KeyDown(HD_TANCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            LST.Items.Clear()
            Me.HD_TANCD.Text = ""
            Me.HD_TANNM.Text = ""
            Me.HD_JDNYTDT.Text = ""
            Me.HD_OAKNID.Text = ""

            Me.HD_TANCD.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190705 ADD END


    '20190705 CHG START
    '   Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NextCm.Click
    '	Debug.Print("CM_NextCm_Click")
    '	Call Ctl_Item_Click(CM_NextCm)
    'End Sub

    '   Private Sub CM_PrevCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PrevCm.Click
    '       Debug.Print("CM_PrevCm_Click")
    '       Call Ctl_Item_Click(CM_PrevCm)
    '   End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        Debug.Print("btnF8_Click")
        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        Debug.Print("btnF7_Click")
        Call Ctl_Item_Click(btnF7)
    End Sub
    '20190705 CHG END


    Private Sub CS_JDNYTDT_Click()
		Debug.Print("CS_JDNYTDT_Click")
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_JDNYTDT)
	End Sub
	
	Private Sub CS_TANCD_Click()
		Debug.Print("CS_TANCD_Click")
		'UPGRADE_WARNING: オブジェクト CS_TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_TANCD)
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		Debug.Print("LST_KeyDown")
		Call Ctl_Item_KeyDown(HD_TANCD, System.Windows.Forms.Keys.Return, 0)
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("LST_KeyDown")
		Select Case KeyCode
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
				Call Ctl_Item_KeyDown(LST, KeyCode, Shift)
				
				'Escapeキー押下
			Case System.Windows.Forms.Keys.Escape
                '20190705 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190705 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190705 CHG START
                'Call CM_PrevCm_Click(CM_PrevCm, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190705 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190705 CHG START
                'Call CM_NextCm_Click(CM_NextCm, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190705 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190705 CHG START
    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    Debug.Print("WLSCANCEL_Click")
    '    Call Ctl_Item_Click(WLSCANCEL)
    'End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Debug.Print("btnF12_Click")
        Call Ctl_Item_Click(btnF12)
    End Sub
    '20190705 CHG END


    Private Sub WLSCANCEL_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSCANCEL.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("WLSCANCEL_KeyDown")
		Select Case True
			Case KeyCode = System.Windows.Forms.Keys.F16 And Shift = 0
				Call Ctl_Item_KeyDown(WLSCANCEL, KeyCode, Shift)
			Case Else
		End Select
	End Sub

    '20190705 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Debug.Print("WLSOK_Click")
    '    Call Ctl_Item_Click(WLSOK)
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Debug.Print("btnF1_Click")
        Call Ctl_Item_Click(btnF1)
    End Sub
    '20190705 CHG END

    Private Sub CM_NextCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NextCm_MouseDown")
        '20190514 DEL START
        'Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
        '20190514 DEL END
    End Sub
	
	Private Sub CM_PrevCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PrevCm_MouseDown")
        '20190514 DEL START
        'Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
        '20190514 DEL END
    End Sub
	
	Private Sub HD_JDNYTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNYTDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_JDNYTDT_MouseDown")
		Call Ctl_Item_MouseDown(HD_JDNYTDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_OAKNID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OAKNID.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_OAKNID_MouseDown")
		Call Ctl_Item_MouseDown(HD_OAKNID, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TANCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TANNM_MouseDown")
		Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_NextCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NextCm_MouseUp")
        '20190514 DEL START
        'Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
        '20190514 DEL END
    End Sub
	
	Private Sub CM_PrevCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PrevCm_MouseUp")
        '20190514 DEL START
        'Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
        '20190514 DEL END
    End Sub
	
	Private Sub CS_JDNYTDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_JDNYTDT_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_JDNYTDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_TANCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_TANCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNYTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNYTDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_JDNYTDT_MouseUp")
		Call Ctl_Item_MouseUp(HD_JDNYTDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_OAKNID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OAKNID.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_OAKNID_MouseUp")
		Call Ctl_Item_MouseUp(HD_OAKNID, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TANCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TANNM_MouseUp")
		Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNYTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNYTDT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_JDNYTDT_KeyDown")
		Call Ctl_Item_KeyDown(HD_JDNYTDT, KeyCode, Shift)
	End Sub
	
	Private Sub HD_OAKNID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OAKNID.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_OAKNID_KeyDown")
		Call Ctl_Item_KeyDown(HD_OAKNID, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TANCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TANNM_KeyDown")
		Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNYTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNYTDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_JDNYTDT_KeyPress")
		Call Ctl_Item_KeyPress(HD_JDNYTDT, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_OAKNID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OAKNID.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_OAKNID_KeyPress")
		Call Ctl_Item_KeyPress(HD_OAKNID, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TANCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TANNM_KeyPress")
		Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub CS_JDNYTDT_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print("CS_JDNYTDT_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_JDNYTDT)
	End Sub
	
	Private Sub CS_TANCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print("CS_TANCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_TANCD)
	End Sub
	
	Private Sub CS_JDNYTDT_GotFocus()
		Debug.Print("CS_JDNYTDT_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_JDNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_JDNYTDT)
	End Sub
	
	Private Sub CS_TANCD_GotFocus()
		Debug.Print("CS_TANCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_TANCD)
	End Sub
	
	Private Sub HD_JDNYTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNYTDT.Enter
		Debug.Print("HD_JDNYTDT_GotFocus")
		Call Ctl_Item_GotFocus(HD_JDNYTDT)
	End Sub
	
	Private Sub HD_OAKNID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OAKNID.Enter
		Debug.Print("HD_OAKNID_GotFocus")
		Call Ctl_Item_GotFocus(HD_OAKNID)
	End Sub
	
	Private Sub HD_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Enter
		Debug.Print("HD_TANCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_TANCD)
	End Sub
	
	Private Sub HD_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Enter
		Debug.Print("HD_TANNM_GotFocus")
		Call Ctl_Item_GotFocus(HD_TANNM)
	End Sub
	
	Private Sub HD_JDNYTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNYTDT.Leave
		Debug.Print("HD_JDNYTDT_LostFocus")
		Call Ctl_Item_LostFocus(HD_JDNYTDT)
	End Sub
	
	Private Sub HD_OAKNID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OAKNID.Leave
		Debug.Print("HD_OAKNID_LostFocus")
		Call Ctl_Item_LostFocus(HD_OAKNID)
	End Sub
	
	Private Sub HD_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Leave
		Debug.Print("HD_TANCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_TANCD)
	End Sub
	
	Private Sub HD_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Leave
		Debug.Print("HD_TANNM_LostFocus")
		Call Ctl_Item_LostFocus(HD_TANNM)
	End Sub


    '20190514 DEL START
    '   'UPGRADE_WARNING: イベント HD_JDNYTDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    '   Private Sub HD_JDNYTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNYTDT.TextChanged
    '	Debug.Print("HD_JDNYTDT_Change")
    '	Call Ctl_Item_Change(HD_JDNYTDT)
    'End Sub

    ''UPGRADE_WARNING: イベント HD_OAKNID.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_OAKNID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OAKNID.TextChanged
    '	Debug.Print("HD_OAKNID_Change")
    '	Call Ctl_Item_Change(HD_OAKNID)
    'End Sub

    ''UPGRADE_WARNING: イベント HD_TANCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.TextChanged
    '	Debug.Print("HD_TANCD_Change")
    '	Call Ctl_Item_Change(HD_TANCD)
    'End Sub

    ''UPGRADE_WARNING: イベント HD_TANNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.TextChanged
    '	Debug.Print("HD_TANNM_Change")
    '	Call Ctl_Item_Change(HD_TANNM)
    'End Sub
    '20190514 DEL END


    Private Sub WLSOK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSOK.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("WLSOK_KeyDown")
		Select Case True
			Case KeyCode = System.Windows.Forms.Keys.F16 And Shift = 0
				Call Ctl_Item_KeyDown(WLSOK, KeyCode, Shift)
			Case Else
		End Select
	End Sub
	
	' === 20060921 === INSERT S - ACE)Sejima
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
	End Sub
	' === 20060921 === INSERT E
	
	' === 20060922 === INSERT S - ACE)Sejima
	Private Sub Panel3D1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Panel3D1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Panel3D1_MouseUp")
		Call Ctl_Item_MouseUp(Panel3D1, Button, Shift, X, Y)
	End Sub
	' === 20060922 === INSERT E
End Class