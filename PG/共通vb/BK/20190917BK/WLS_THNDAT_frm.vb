Option Strict Off
Option Explicit On
Friend Class WLS_THNDAT
	Inherits System.Windows.Forms.Form
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　通販データ検索
    '*  プログラムＩＤ　：  WLS_THNDAT
    '*  作成者　　　　　：　両備）inoue
    '*  作成日　　　　　：  2013.07.01
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************
    '************************************************************************************
    '   Private定数
    '************************************************************************************

    Private Const FM_PANEL3D1_CNT As Short = 4 'パネルコントロール数

    '20190820 ADD START 
    Private FORM_LOAD_FLG As Boolean = False
    '20190820 ADD E N D 

    '************************************************************************************
    '   Private変数
    '************************************************************************************
    '=== 当画面の全情報を格納 =================
    'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_THNDATVIEW_W As TYPE_DB_THNDATVIEW 'リストへ表示するデータ1行分の入れ物
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
	Private WM_WLS_MAX As Short
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
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
		
		'画面基礎情報設定
		With Main_Inf.Dsp_Base
            .Dsp_Ctg = DSP_CTG_REFERENCE '画面分類
            '20190904 CHG START
            '.Item_Cnt = 20 '画面項目数
            .Item_Cnt = 16 '画面項目数
            '20190904 CHG END
            .Dsp_Body_Cnt = 0 '画面表示明細数（０：明細なし、１～：表示時明細数）
			.Max_Body_Cnt = 0 '最大表示明細数（０：明細なし、１～：最大明細数）
			.Body_Col_Cnt = 0 '明細の列項目数
			.Dsp_Body_Move_Qty = 0 '画面移動量
			.FormCtl = Me
		End With
		
		'画面項目情報
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'/////////////////////
		'// 全画面用制御用ｺﾝﾄﾛｰﾙ
		'/////////////////////
		
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// ヘッダ部編集
		'///////////////////
		Index_Wk = Index_Wk + 1
		'ステータス
		HD_STS.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_STS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
		'出荷予定日（開始）ボタン
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_ODNYTDT_ST.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_ODNYTDT_ST
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
		'出荷予定日（開始）
		HD_ODNYTDT_ST.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_ODNYTDT_ST
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
		'出荷予定日（終了）ボタン
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_ODNYTDT_ED.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_ODNYTDT_ED
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
		'出荷予定日（終了）
		HD_ODNYTDT_ED.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_ODNYTDT_ED
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
		'決済方法ボタン
		'UPGRADE_WARNING: オブジェクト CS_TOKCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_TOKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TOKCD
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
		'決済方法(ｺｰﾄﾞ)※得意先コード
		HD_TOKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
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
		'決済方法(名称)
		HD_KSHNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KSHNM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
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
		'製品コード
		HD_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'客先注文番号
		HD_TOKJDNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKJDNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 23
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 23
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
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
        '前ページイメージ
        '20190904 CHG START
        'CM_PrevCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '20190904 CHG END
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
        'OKボタン

        '20190904 CHG START
        'WLSOK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
        btnF1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '20190904 CHG END

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
        'キャンセルボタン
        '20190904 CHG START
        'WLSCANCEL.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190904 CHG END
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
        '次ページイメージ
        '20190904 CHG START
        'CM_NextCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '20190904 CHG END
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
		
		'画面基礎情報設定
		Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////////
        '// その他編集
        '///////////////////
        '20190904 DLT START
        '      For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '	Index_Wk = Index_Wk + 1
        '          'FM_Panel3D1
        '          'UPGRADE_WARNING: オブジェクト FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '          'FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '          'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)

        '          Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        '	Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        'Next
        '20190904 DLT END

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
		
		'上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
		Call CF_Init_Item_Property(Main_Inf)
		'画面項目情報を再設定
		Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)
		
		'///////////////////
		'// 特別項目の再設定
		'///////////////////
		
		'リスト行数の設定
		WM_WLS_MAX = 15
		
		'返り値の設定
		WLSTHNDAT_RTNJDNNO = ""
		
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLSTHNDAT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
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
		Call WLSTHNDAT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
            'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Select Case Me.ActiveControl.Name
                '20190904 CHG START
                'Case HD_STS.Name, HD_ODNYTDT_ST.Name, HD_ODNYTDT_ED.Name, HD_TOKCD.Name, HD_HINCD.Name, HD_TOKJDNNO.Name
                Case HD_STS.Name, HD_ODNYTDT_ST.Name, HD_ODNYTDT_ED.Name, HD_TOKCD.Name, HD_HINCD.Name, HD_TOKJDNNO.Name, btnF2.Name
                    '20190904 CHG END
                    '変数クリア
                    Call WLS_Clear()
                    'リスト編集
                    Call Get_THNDATVIEW()
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
	'   名称：  Function Get_THNDATVIEW
	'   概要：  案件情報検索
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_THNDATVIEW() As Short
		
		Dim strSQL As String
		Dim strWhere As String
		
		On Error GoTo Get_THNDATVIEW_Err
		
		'受注情報検索処理
		strSQL = ""
		strWhere = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        J.TOKJDNNO " '客先注文番号
		strSQL = strSQL & "      , CONCAT(RTRIM(J.JDNNO), SUBSTR(J.LINNO, 2))  as JDNNO " '受注番号＋行番号（2桁）
		strSQL = strSQL & "      , J.ODNYTDT " '出荷予定日
		strSQL = strSQL & "      , J.HINCD " '製品コード
		strSQL = strSQL & "      , M.MEINMA as KSHNMA " '決済方法
		strSQL = strSQL & "      , RTRIM(RTRIM(A.NHSNMA, ' '), '　') as NHSNMA " '納入先名称1
		strSQL = strSQL & "      , RTRIM(RTRIM(A.NHSNMB, ' '), '　') as NHSNMB " '納入先名称2
		strSQL = strSQL & "      , CASE WHEN J.ODNDT = '" & CF_Ora_String("", 8) & "' THEN '1' " 'ステータスコード
		strSQL = strSQL & "             ELSE CASE WHEN J.UDNDT <> '" & CF_Ora_String("", 8) & "' "
		strSQL = strSQL & "                        AND J.NYUDT =  '" & CF_Ora_String("", 8) & "' THEN '2' "
		strSQL = strSQL & "                       ELSE CASE WHEN J.NYUDT <> '" & CF_Ora_String("", 8) & "' THEN '3' "
		strSQL = strSQL & "                            END "
		strSQL = strSQL & "                  End "
		strSQL = strSQL & "        END AS STSCD "
		strSQL = strSQL & "      , CASE WHEN J.ODNDT = '" & CF_Ora_String("", 8) & "' THEN '未出荷' " 'ステータス名称
		strSQL = strSQL & "             ELSE CASE WHEN J.UDNDT <> '" & CF_Ora_String("", 8) & "' "
		strSQL = strSQL & "                        AND J.NYUDT =  '" & CF_Ora_String("", 8) & "' THEN '売上済' "
		strSQL = strSQL & "                       ELSE CASE WHEN J.NYUDT <> '" & CF_Ora_String("", 8) & "' THEN '入金済' "
		strSQL = strSQL & "                            END "
		strSQL = strSQL & "                  END "
		strSQL = strSQL & "        END AS STSNM "
		strSQL = strSQL & "   From JDNTRA J, JDNTHC C, JDNTHA A, MEIMTA M "
		
		'伝票削除区分
		strWhere = strWhere & "     J.DATKB =  '" & gc_strDATKB_USE & "' "
		'赤黒区分
		strWhere = strWhere & " And J.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		
		'ステータス
		If Trim(HD_STS.Text) <> "" Then
			Select Case Trim(HD_STS.Text)
				'未出荷
				Case gc_strSTS_MSK
					'出荷実績日が空
					strWhere = strWhere & "    And J.ODNDT =  '" & CF_Ora_String("", 8) & "' "
					'売上済
				Case gc_strSTS_ZUA
					'売上日が空でない、かつ、入金日が空
					strWhere = strWhere & "    And J.UDNDT <> '" & CF_Ora_String("", 8) & "' " & "  And J.NYUDT =  '" & CF_Ora_String("", 8) & "' "
					'入金済
				Case gc_strSTS_ZNK
					'入金日が空でない
					strWhere = strWhere & "    And J.NYUDT <> '" & CF_Ora_String("", 8) & "' "
					'全件
				Case gc_strSTS_ALL
					' 指定なし
			End Select
		End If
		
		'出荷予定日（開始）
		If Trim(HD_ODNYTDT_ST.Text) <> "" Then
			strWhere = strWhere & "    And J.ODNYTDT >= '" & CF_Ora_Date(Trim(HD_ODNYTDT_ST.Text)) & "' "
		End If
		
		'出荷予定日（終了）
		If Trim(HD_ODNYTDT_ED.Text) <> "" Then
			strWhere = strWhere & "    And J.ODNYTDT <= '" & CF_Ora_Date(Trim(HD_ODNYTDT_ED.Text)) & "' "
		End If
		
		'決済方法
		If Trim(HD_TOKCD.Text) <> "" Then
			strWhere = strWhere & "    And J.TOKCD = '" & CF_Ora_String(Trim(HD_TOKCD.Text), 5) & "' "
		End If
		
		'製品コード
		If Trim(HD_HINCD.Text) <> "" Then
			strWhere = strWhere & "    And J.HINCD like '" & Trim(HD_HINCD.Text) & "%' "
		End If
		
		'客先注文番号
		If Trim(HD_TOKJDNNO.Text) <> "" Then
			strWhere = strWhere & "    And J.TOKJDNNO like '" & Trim(HD_TOKJDNNO.Text) & "%' "
		End If
		
		'名称マスタの紐付け（決済方法）
		strWhere = strWhere & "    And M.DATKB  = '" & gc_strDATKB_USE & "' "
		strWhere = strWhere & "    And M.KEYCD  = '" & gc_strKEYCD_KSHTK & "' "
		strWhere = strWhere & "    And M.MEINMB = J.TOKCD "
		
		'受注見出Aトランの紐付け（納入先名称）
		strWhere = strWhere & "    And A.DATNO = J.DATNO "
		'受注取引区分
		strWhere = strWhere & " And A.JDNTRKB = '" & gc_strJDNTRKB_TAN & "' "
		
		'受注見出Cトランの紐付け（同一受注番号の中で最新のもの）
		strWhere = strWhere & "    And C.DATNO = J.DATNO "
		strWhere = strWhere & "    And C.JDNNO = J.JDNNO "
		
		If Trim(strWhere) <> "" Then
			strSQL = strSQL & " Where " & strWhere
		End If
		
		strSQL = strSQL & "  Order By "
		strSQL = strSQL & "           J.ODNYTDT "
		strSQL = strSQL & "         , J.HINCD "
		strSQL = strSQL & "         , M.MEINMA "
		strSQL = strSQL & "         , STSCD "
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		Dyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			LST.Items.Clear()
		End If
		
		Exit Function
		
Get_THNDATVIEW_Err: 
		LST.Items.Clear()
		
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
		
		On Error GoTo WLS_DspNew_Err
		
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			If bolPrev = False Then
				'取得内容退避
				With DB_THNDATVIEW_W
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "") '客先注文番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "") '受注番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.STSNM = CF_Ora_GetDyn(Usr_Ody, "STSNM", "") 'ステータス
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ODNYTDT = VB6.Format(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", ""), "@@@@/@@/@@") '出荷予定日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.KSHNMA = CF_Ora_GetDyn(Usr_Ody, "KSHNMA", "") '決済方法
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, NHSNMB, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") & CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '納入先名
				End With
				
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
			
			Call CF_Ora_MoveNext(Usr_Ody)
			
			If bolPrev = True And bolNextData = True Then
				Exit Do
			End If
			
			If Cnt >= WM_WLS_MAX Then
				bolPrev = True
			End If
		Loop 
		
		'次頁がある場合は巻き戻し
		If bolPrev = True And bolNextData = True Then
			Call CF_Ora_MovePrev(Usr_Ody)
			Call CF_Ora_MovePrev(Usr_Ody)
			Call CF_Ora_MoveNext(Usr_Ody)
		End If
		
		'最終データ到達
		If CF_Ora_EOF(Usr_Ody) = True Then
			WM_WLS_LastFL = True
		End If
		
		If Cnt > 0 Then
			'ページを表示
			Call WLS_DspPage()
		End If
		
		Exit Sub
		
WLS_DspNew_Err: 
		WM_WLS_LastFL = True
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		With DB_THNDATVIEW_W
			WM_WLS_DSPArray(ArrayCnt) = CF_SpaceLenFormat(LeftWid(.TOKJDNNO, 23), 23, True) & Space(1) & CF_SpaceLenFormat(LeftWid(.JDNNO, 8), 8) & Space(1) & CF_SpaceLenFormat(LeftWid(.STSNM, 6), 6) & Space(1) & CF_SpaceLenFormat(LeftWid(.ODNYTDT, 10), 10) & Space(1) & CF_SpaceLenFormat(LeftWid(.HINCD, 8), 8) & Space(1) & CF_SpaceLenFormat(LeftWid(.KSHNMA, 12), 12) & Space(2) & CF_SpaceLenFormat(LeftWid(.NHSNMA, 60), 60) & Space(1)
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
			
			On Error Resume Next
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'KEYRIGHT制御
		Call WLSTHNDAT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSTHNDAT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSTHNDAT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_TOKJDNNO.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call Get_THNDATVIEW()
						Call WLS_DspNew()
					Case Else
				End Select
				'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
				Call WLSTHNDAT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
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
		Call WLSTHNDAT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSTHNDAT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSTHNDAT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
				Call WLSTHNDAT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
			Else
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
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
				Call WLSTHNDAT0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, Main_Inf, True)
				
				'Shift+TAB押
			Case pm_KeyCode = System.Windows.Forms.Keys.F15
				pm_KeyCode = 0
				'前ﾌｫｰｶｽ位置へ移動
				Call WLSTHNDAT0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
				'F5押
			Case pm_KeyCode = System.Windows.Forms.Keys.F5 And Trg_Index = CShort(HD_ODNYTDT_ST.Tag)
				pm_KeyCode = 0
				Call Ctl_Item_Click(HD_ODNYTDT_ST)
				
				'F5押
			Case pm_KeyCode = System.Windows.Forms.Keys.F5 And Trg_Index = CShort(HD_ODNYTDT_ED.Tag)
				pm_KeyCode = 0
				Call Ctl_Item_Click(HD_ODNYTDT_ED)
				
				'F5押
			Case pm_KeyCode = System.Windows.Forms.Keys.F5 And Trg_Index = CShort(HD_TOKCD.Tag)
				pm_KeyCode = 0
				Call Ctl_Item_Click(HD_TOKCD)
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
		
		If gv_bolWLSTHNDAT_LF_Enable = False Then
			Exit Function
		End If
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLSTHNDAT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call WLSTHNDAT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
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
			'ﾍｯﾀﾞ部ﾁｪｯｸ
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If

        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '20190829 CHG START
        'If TypeOf pm_Ctl Is SSCommand5 Then
        If TypeOf pm_Ctl Is Button Then
            '20190829 CHG END
            '検索画面呼出の場合は終了
            Exit Function
        End If

        Select Case Trg_Index
			Case Else
				'共通ﾌｫｰｶｽ取得処理
				Call WLSTHNDAT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
		End Select
		
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'共通KEYPRESS制御
		Call WLSTHNDAT0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLSTHNDAT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call WLSTHNDAT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_TOKJDNNO.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call Get_THNDATVIEW()
						Call WLS_DspNew()
					Case Else
				End Select
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call WLSTHNDAT0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
			Else
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			End If
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

        '20190820 ADD START 
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '20190820 ADD E N D 

        Dim Trg_Index As Short
		
		If Main_Inf.Dsp_Base.Change_Flg = True Then
			Main_Inf.Dsp_Base.Change_Flg = False
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'共通KEYCHANG制御
		Call WLSTHNDAT0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
'20190829 CHG START
            'Case TypeOf pm_Ctl Is SSCommand5
            Case TypeOf pm_Ctl Is Button
                '20190829 CHG END
                'ボタンの場合
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                '20190829 CHG STAR
                'If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    '20190829 CHG END
                    Call WLSTHNDAT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                '20190829 CHG START
            'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '20190829 CHG END
                'パネルの場合
                Call WLSTHNDAT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'ピクチャーの場合
				Call WLSTHNDAT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
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
		Call WLSTHNDAT0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'各検索画面呼出
		'UPGRADE_WARNING: オブジェクト CS_TOKCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			Case CShort(CS_ODNYTDT_ST.Tag)
				'出荷予定日（開始）検索画面呼出
				Call WLSTHNDAT0001.F_Ctl_CS_ODNYTDT_ST(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_ODNYTDT_ED.Tag)
				'出荷予定日（終了）検索画面呼出
				Call WLSTHNDAT0001.F_Ctl_CS_ODNYTDT_ED(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_TOKCD.Tag)
				'決済方法検索画面呼出
				Call WLSTHNDAT0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                '20190904 CHG START
                'Case CShort(CM_PrevCm.Tag)
                '	'前頁
                '	Call Ctl_CM_PrevCm_Click()

                'Case CShort(CM_NextCm.Tag)
                '	'次頁
                '	Call Ctl_CM_NextCm_Click()

                'Case CShort(WLSOK.Tag)
                '	'OK
                '	Call Ctl_WLSOK_Click()

                'Case CShort(WLSCANCEL.Tag)
                '	'キャンセル
                '	Call Ctl_WLSCANCEL_Click()

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
                '20190904 CHG END
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
		
		WLSTHNDAT_RTNJDNNO = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), 25, 8)
		
		Call Ctl_WLSCANCEL_Click()
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
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'該当項目のコピー
		Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
		Call WLSTHNDAT0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
		Call WLSTHNDAT0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)
		
		'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Select Case Me.ActiveControl.Name
			Case HD_TOKCD.Name
				Call WLSTHNDAT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
				
		End Select
		
		'共通ﾌｫｰｶｽ取得処理
		Call WLSTHNDAT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
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
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KEYUP
	'   概要：  各項目のKEYUP制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
	End Function
	
	Private Sub WLS_THNDAT_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'画面情報設定
		Call Init_Def_Dsp()
		
		'画面内容初期化
		Call WLSTHNDAT0001.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面表示位置設定
		Call CF_Set_Frm_Location(Me)
		
		'システム共通処理
		Call CF_System_Process(Me)

        '20190904 ADD START
        LST.Items.Clear()
        FORM_LOAD_FLG = True
        '20190904 ADD END

    End Sub

    Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NextCm.Click
        Debug.Print("CM_NextCm_Click")
        Call Ctl_Item_Click(CM_NextCm)
    End Sub

    Private Sub CM_PrevCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PrevCm.Click
        Debug.Print("CM_PrevCm_Click")
        Call Ctl_Item_Click(CM_PrevCm)
    End Sub

    Private Sub CS_ODNYTDT_ST_Click()
        Debug.Print("CS_ODNYTDT_ST_Click")
        'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_Click(CS_ODNYTDT_ST)
    End Sub

    Private Sub CS_ODNYTDT_ED_Click()
        Debug.Print("CS_ODNYTDT_ED_Click")
        'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_Click(CS_ODNYTDT_ED)
    End Sub

    Private Sub CS_TOKCD_Click()
        Debug.Print("CS_TOKCD_Click")
        'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_Click(CS_TOKCD)
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
        Debug.Print("LST_KeyDown")
        '何でもよい
        Call Ctl_Item_KeyDown(HD_STS, System.Windows.Forms.Keys.Return, 0)
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
                Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                Call CM_PrevCm_Click(CM_PrevCm, New System.EventArgs())

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                Call CM_NextCm_Click(CM_NextCm, New System.EventArgs())
                If LST.Items.Count > 0 Then
                    LST.SelectedIndex = -1
                End If
        End Select

    End Sub

    Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
        Debug.Print("WLSCANCEL_Click")
        Call Ctl_Item_Click(WLSCANCEL)
    End Sub

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

    Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
        Debug.Print("WLSOK_Click")
        Call Ctl_Item_Click(WLSOK)
    End Sub

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

    '-------------------------------------
    Private Sub CM_NextCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NextCm_MouseDown")
        Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
    End Sub

    Private Sub CM_PrevCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PrevCm_MouseDown")
        Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
    End Sub

    Private Sub HD_STS_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STS.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_STS_MouseDown")
        Call Ctl_Item_MouseDown(HD_STS, Button, Shift, X, Y)
    End Sub

    Private Sub HD_ODNYTDT_ST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ODNYTDT_ST.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_ODNYTDT_ST_MouseDown")
        Call Ctl_Item_MouseDown(HD_ODNYTDT_ST, Button, Shift, X, Y)
    End Sub

    Private Sub HD_ODNYTDT_ED_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ODNYTDT_ED.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_ODNYTDT_ED_MouseDown")
        Call Ctl_Item_MouseDown(HD_ODNYTDT_ED, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KSHNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KSHNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KSHNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_KSHNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_HINCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKJDNNO_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKJDNNO, Button, Shift, X, Y)
    End Sub

    '-------------------------------------
    Private Sub CM_NextCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NextCm_MouseUp")
        Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
    End Sub

    Private Sub CM_PrevCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PrevCm_MouseUp")
        Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
    End Sub

    Private Sub CS_ODNYTDT_ST_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_ODNYTDT_ST_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_ODNYTDT_ST, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_ODNYTDT_ED_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_ODNYTDT_ED_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_ODNYTDT_ED, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_TOKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("CS_TOKCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_STS_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STS.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_STS_MouseUp")
		Call Ctl_Item_MouseUp(HD_STS, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_ODNYTDT_ST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ODNYTDT_ST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_ODNYTDT_ST_MouseUp")
		Call Ctl_Item_MouseUp(HD_ODNYTDT_ST, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_ODNYTDT_ED_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ODNYTDT_ED.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_ODNYTDT_ED_MouseUp")
		Call Ctl_Item_MouseUp(HD_ODNYTDT_ED, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KSHNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KSHNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_KSHNM_MouseUp")
		Call Ctl_Item_MouseUp(HD_KSHNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKJDNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_TOKJDNNO, Button, Shift, X, Y)
	End Sub
	
	'-------------------------------------
	Private Sub HD_STS_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STS.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_STS_KeyDown")
		Call Ctl_Item_KeyDown(HD_STS, KeyCode, Shift)
	End Sub
	
	Private Sub HD_ODNYTDT_ST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ODNYTDT_ST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_ODNYTDT_ST_KeyDown")
		Call Ctl_Item_KeyDown(HD_ODNYTDT_ST, KeyCode, Shift)
	End Sub
	
	Private Sub HD_ODNYTDT_ED_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ODNYTDT_ED.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_ODNYTDT_ED_KeyDown")
		Call Ctl_Item_KeyDown(HD_ODNYTDT_ED, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KSHNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KSHNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_KSHNM_KeyDown")
		Call Ctl_Item_KeyDown(HD_KSHNM, KeyCode, Shift)
	End Sub
	
	Private Sub HD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKJDNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_TOKJDNNO, KeyCode, Shift)
	End Sub
	
	'-------------------------------------
	Private Sub HD_STS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_STS_KeyPress")
		Call Ctl_Item_KeyPress(HD_STS, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_ODNYTDT_ST_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ODNYTDT_ST.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_ODNYTDT_ST_KeyPress")
		Call Ctl_Item_KeyPress(HD_ODNYTDT_ST, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_ODNYTDT_ED_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ODNYTDT_ED.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_ODNYTDT_ED_KeyPress")
		Call Ctl_Item_KeyPress(HD_ODNYTDT_ED, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TOKCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KSHNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KSHNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_KSHNM_KeyPress")
		Call Ctl_Item_KeyPress(HD_KSHNM, KeyAscii)
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
	
	Private Sub HD_TOKJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKJDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TOKJDNNO_KeyPress")
		Call Ctl_Item_KeyPress(HD_TOKJDNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'-------------------------------------
	Private Sub CS_ODNYTDT_ST_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print("CS_ODNYTDT_ST_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_ODNYTDT_ST)
	End Sub
	
	Private Sub CS_ODNYTDT_ED_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print("CS_ODNYTDT_ED_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_ODNYTDT_ED)
	End Sub
	
	Private Sub CS_TOKCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print("CS_TOKCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_TOKCD)
	End Sub
	
	'-------------------------------------
	Private Sub CS_ODNYTDT_ST_GotFocus()
		Debug.Print("CS_ODNYTDT_ST_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ST の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_ODNYTDT_ST)
	End Sub
	
	Private Sub CS_ODNYTDT_ED_GotFocus()
		Debug.Print("CS_ODNYTDT_ED_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_ODNYTDT_ED の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_ODNYTDT_ED)
	End Sub
	
	Private Sub CS_TOKCD_GotFocus()
		Debug.Print("CS_TOKCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_TOKCD)
	End Sub
	
	Private Sub HD_STS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STS.Enter
		Debug.Print("HD_STS_GotFocus")
		Call Ctl_Item_GotFocus(HD_STS)
	End Sub
	
	Private Sub HD_ODNYTDT_ST_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ST.Enter
		Debug.Print("HD_ODNYTDT_ST_GotFocus")
		Call Ctl_Item_GotFocus(HD_ODNYTDT_ST)
	End Sub
	
	Private Sub HD_ODNYTDT_ED_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ED.Enter
		Debug.Print("HD_ODNYTDT_ED_GotFocus")
		Call Ctl_Item_GotFocus(HD_ODNYTDT_ED)
	End Sub
	
	Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
		Debug.Print("HD_TOKCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_KSHNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KSHNM.Enter
		Debug.Print("HD_KSHNM_GotFocus")
		Call Ctl_Item_GotFocus(HD_KSHNM)
	End Sub
	
	Private Sub HD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Enter
		Debug.Print("HD_HINCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Enter
		Debug.Print("HD_TOKJDNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_TOKJDNNO)
	End Sub
	
	'-------------------------------------
	Private Sub HD_STS_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STS.Leave
		Debug.Print("HD_STS_LostFocus")
		Call Ctl_Item_LostFocus(HD_STS)
	End Sub
	
	Private Sub HD_ODNYTDT_ST_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ST.Leave
		Debug.Print("HD_ODNYTDT_ST_LostFocus")
		Call Ctl_Item_LostFocus(HD_ODNYTDT_ST)
	End Sub
	
	Private Sub HD_ODNYTDT_ED_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ED.Leave
		Debug.Print("HD_ODNYTDT_ED_LostFocus")
		Call Ctl_Item_LostFocus(HD_ODNYTDT_ED)
	End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
		Debug.Print("HD_TOKCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_KSHNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KSHNM.Leave
		Debug.Print("HD_KSHNM_LostFocus")
		Call Ctl_Item_LostFocus(HD_KSHNM)
	End Sub
	
	Private Sub HD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Leave
		Debug.Print("HD_HINCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_TOKJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Leave
		Debug.Print("HD_TOKJDNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_TOKJDNNO)
	End Sub
	
	'-------------------------------------
	'UPGRADE_WARNING: イベント HD_STS.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_STS_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STS.TextChanged
		Debug.Print("HD_STS_Change")
		Call Ctl_Item_Change(HD_STS)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_ODNYTDT_ST.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_ODNYTDT_ST_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ST.TextChanged
		Debug.Print("HD_ODNYTDT_ST_Change")
		Call Ctl_Item_Change(HD_ODNYTDT_ST)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_ODNYTDT_ED.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_ODNYTDT_ED_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ODNYTDT_ED.TextChanged
		Debug.Print("HD_ODNYTDT_ED_Change")
		Call Ctl_Item_Change(HD_ODNYTDT_ED)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
		Debug.Print("HD_TOKCD_Change")
		Call Ctl_Item_Change(HD_TOKCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_KSHNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_KSHNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KSHNM.TextChanged
		Debug.Print("HD_KSHNM_Change")
		Call Ctl_Item_Change(HD_KSHNM)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_HINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.TextChanged
		Debug.Print("HD_HINCD_Change")
		Call Ctl_Item_Change(HD_HINCD)
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TOKJDNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TOKJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.TextChanged
		Debug.Print("HD_TOKJDNNO_Change")
		Call Ctl_Item_Change(HD_TOKJDNNO)
	End Sub
	
	
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub Panel3D1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Panel3D1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Panel3D1_MouseUp")
		Call Ctl_Item_MouseUp(Panel3D1, Button, Shift, X, Y)
	End Sub

    Private Sub CS_ODNYTDT_ST_Click(sender As Object, e As EventArgs) Handles CS_ODNYTDT_ST.Click
        Debug.Print("CS_ODNYTDT_ST_Click")
        Call Ctl_Item_Click(CS_ODNYTDT_ST)
    End Sub

    Private Sub CS_ODNYTDT_ED_Click(sender As Object, e As EventArgs) Handles CS_ODNYTDT_ED.Click
        Debug.Print("CS_ODNYTDT_ED_Click")
        Call Ctl_Item_Click(CS_ODNYTDT_ED)
    End Sub

    Private Sub CS_TOKCD_Click(sender As Object, e As EventArgs) Handles CS_TOKCD.Click
        Debug.Print("CS_TOKCD_Click")
        Call Ctl_Item_Click(CS_TOKCD)
    End Sub

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Debug.Print("btnF1_Click")
        Call Ctl_Item_Click(btnF1)
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        Debug.Print("btnF2_Click")
        Try
            btnF2.Focus()
            Call HD_STS_KeyDown(HD_STS, New System.Windows.Forms.KeyEventArgs(Keys.Return))
        Catch ex As Exception
            MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        Debug.Print("btnF7_Click")
        Call Ctl_Item_Click(btnF7)
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        Debug.Print("btnF8_Click")
        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Debug.Print("btnF9_Click")
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            LST.Items.Clear()

            HD_STS.Text = ""
            HD_ODNYTDT_ST.Text = ""
            HD_ODNYTDT_ED.Text = ""
            HD_TOKCD.Text = ""
            HD_KSHNM.Text = ""
            HD_HINCD.Text = ""
            HD_TOKJDNNO.Text = ""

            HD_STS.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Debug.Print("btnF12_Click")
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub WLS_THNDAT_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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
End Class