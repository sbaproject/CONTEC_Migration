Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_JDN2
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　受注情報検索
	'*  プログラムＩＤ　：  WLS_JDN2
	'*  作成者　　　　　：　ACE)古川
	'*  作成日　　　　　：  2006.07.28
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   構造体
	'************************************************************************************
	Private Structure Type_DB_JDNTRA_W
		Dim DATKB As String
		Dim JDNNO As String '受注番号
		Dim LINNO As String '行番号
		Dim DENDT As String '受注日付
		Dim TOKCD As String '得意先コード
		Dim TOKRN As String '得意先略称
		Dim NHSCD As String '納入先コード
		Dim NHSRN As String '納入先略称
		Dim HINNMA As String '形式
		Dim HINNMB As String '品名
		Dim UDOSU As Short '数量
		Dim JDNTRKBNM As String '受注取引区分名
		Dim JDNTRKB As String '受注取引区分
		Dim JDNDT As String '受注伝票日付
		Dim KENNMA As String '件名１
		Dim KENNMB As String '件名２
	End Structure
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	Private Const FM_PANEL3D1_CNT As Short = 2 'パネルコントロール数
	Private Const pc_intCntListRow As Short = 15 '明細行数
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	
	Private pv_DB_JDNTHA_W As Type_DB_JDNTRA_W
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	Private pv_strInit_JDNTRKB As String '受注取引区分
	Private WM_WLS_MAX As Short 'リスト行数
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'画面基礎情報設定
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REFERENCE '画面分類

            '20190603 CHG START
            '.Item_Cnt = 15 '画面項目数
            .Item_Cnt = 15 '画面項目数
            '20190603 CHG END
            .Dsp_Body_Cnt = 0 '画面表示明細数（０：明細なし、１～：表示時明細数）
			.Max_Body_Cnt = 0 '最大表示明細数（０：明細なし、１～：最大明細数）
			.Body_Col_Cnt = 0 '明細の列項目数
			.Dsp_Body_Move_Qty = 0 '画面移動量
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
		'受注取引区分ボタン
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_JDNTRKB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNTRKB
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
		'受注取引区分
		HD_JDNTRKB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
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
		'受注取引区分(名称)
		HD_JDNTRKBNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKBNM
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
		'客先注文番号
		HD_JDNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(6)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'得意先(ｺｰﾄﾞ)ボタン
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
		'得意先(ｺｰﾄﾞ)
		HD_TOKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
		'納入先ボタン
		'UPGRADE_WARNING: オブジェクト CS_JDNDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_JDNDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNDT
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
		'納入先コード
		HD_NHTCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHTCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 9
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
		'件名１
		HD_KENNMA.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
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
        '20190603 CHG START
        'WLSOK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
        btnF1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '20190603 CHG END
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

        '20190603 ADD START
        Index_Wk = Index_Wk + 1

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
        '20190603 ADD END

        Index_Wk = Index_Wk + 1
        '前ページイメージ
        '20190603 CHG START
        'CM_PrevCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '20190603 CHG END
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
        '20190603 CHG START
        'CM_NextCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '20190603 CHG END
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

        '20190603 ADD START
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
        '20190603 ADD END


        Index_Wk = Index_Wk + 1
        'キャンセルボタン
        '20190603 CHG START
        'WLSCANCEL.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190603 CHG END
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


        '画面基礎情報設定
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////////
        '// その他編集
        '///////////////////
        '20190603 DEL START
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1
        '    'FM_Panel3D1
        '    'UPGRADE_WARNING: オブジェクト WLS_JDN2.FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Me.FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Me.FM_Panel3D1(Wk_Cnt)
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
        '20190603 DEL END
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
		WM_WLS_MAX = pc_intCntListRow
		
		'返り値の設定
		WLSJDN_RTNJDNNO = ""
		
		'受注取引区分の初期値設定
		pv_strInit_JDNTRKB = Trim(WLSJDN_JDNTRKB)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYRIGHT制御
		Call WLS_JDN2_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_KENNMA.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call F_Get_JDNTHA()
						Call WLS_DspNew()
					Case Else
				End Select
				'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
				Call WLS_JDN2_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
		Call WLS_JDN2_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
				Call WLS_JDN2_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
				Call WLS_JDN2_0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		' === 20060902 === INSERT S - ACE)Nagasawa
		If gv_bolWLSJDN_LF_Enable = False Then
			Exit Function
		End If
		' === 20060902 === INSERT E -
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
		'CHG START FKS)INABA 2007/12/15 ******************
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = Val(Me.ActiveControl.Tag)
		'    Act_Index = CInt(Me.ActiveControl.Tag)
		'CHG  END  FKS)INABA 2007/12/15 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_JDN2_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
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

        ' === 20060801 === INSERT S - ACE)Nagasawa 検索画面表示ボタンを押したことが見えるようにする対応
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Ctl Is Button Then
            '検索画面呼出の場合は終了
            Exit Function
        End If

        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
			'明細行コントロールか判定
			If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
				'明細検索ボタンの明細行数変数に同じ行数を設定
				For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
					If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
						'設定済みの場合は終了
						Exit For
					End If
					Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
				Next 
			End If
		Else
			'明細検索ボタンの明細行数変数を初期化
			For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
				If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
					'設定済みの場合は終了
					Exit For
				End If
				Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
			Next 
		End If
		' === 20060801 === INSERT E
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Select Case Trg_Index
			Case Else
				'共通ﾌｫｰｶｽ取得処理
				Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		End Select
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
		'各検索画面呼出
		'    Select Case Trg_Index
		'        Case CInt(HD_AKNID.Tag)
		'            '案件IDのﾃｷｽﾄへﾌｫｰｶｽ移動
		
		'    End Select
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'共通KEYPRESS制御
		Call WLS_JDN2_0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_KENNMA.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call F_Get_JDNTHA()
						Call WLS_DspNew()
					Case Else
				End Select
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call WLS_JDN2_0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
		Call WLS_JDN2_0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                '            '項目色設定
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

            Case TypeOf pm_Ctl Is Label
                'パネルの場合
                Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060801 === INSERT S - ACE)Nagasawa　検索Wボタン対応
            Case TypeOf pm_Ctl Is Button
                'ボタンの場合
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060801 === INSERT E

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
		Call WLS_JDN2_0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
		'CHG START FKS)INABA 2007/12/15 ******************
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		Act_Index = Val(Me.ActiveControl.Tag)
		'    Act_Index = CInt(Me.ActiveControl.Tag)
		'CHG  END  FKS)INABA 2007/12/15 ******************
		
		'各検索画面呼出
		'UPGRADE_WARNING: オブジェクト CS_TOKCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_JDNDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			Case CShort(CS_JDNTRKB.Tag)
				'受取地区検索画面呼出
				Call WLS_JDN2_0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_JDNDT.Tag)
				Call WLS_JDN2_0001.F_Ctl_CS_NHSCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				'            '日付検索画面呼出
				'            Call WLS_JDN2_0001.F_Ctl_CS_JDNDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_TOKCD.Tag)
				'得意先検索画面呼出
				Call WLS_JDN2_0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                '20190603 CHG START
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
            '    'キャンセル
            '    Call Ctl_WLSCANCEL_Click()

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
                '20190603 CHG END

        End Select
		
	End Function

    Private Sub WLS_JDN2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '画面情報設定
        Call Init_Def_Dsp()

        '画面内容初期化
        Call WLS_JDN2_0001.F_Init_Clr_Dsp(-1, Main_Inf)

        '初期表示編集
        Call Edi_Dsp_Def()

        '画面表示位置設定
        Call CF_Set_Frm_Location(Me)

    End Sub

    '20190603 ADD START
    Private Sub WLS_JDN2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If Me.HD_JDNTRKB.Focused Then
                Call HD_JDNTRKB_KeyDown(HD_JDNTRKB, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_JDNTRKBNM.Focused Then
                Call HD_JDNTRKBNM_KeyDown(HD_JDNTRKBNM, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_JDNNO.Focused Then
                Call HD_JDNNO_KeyDown(HD_JDNNO, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_TOKCD.Focused Then
                Call HD_TOKCD_KeyDown(HD_TOKCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_NHTCD.Focused Then
                Call HD_NHTCD_KeyDown(HD_NHTCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_KENNMA.Focused Then
                Call HD_KENNMA_KeyDown(HD_KENNMA, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_JDNTRKB_KeyDown(HD_TANCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
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
            Me.HD_JDNTRKB.Text = ""
            Me.HD_JDNTRKBNM.Text = ""
            Me.HD_JDNNO.Text = ""
            Me.HD_TOKCD.Text = ""
            Me.HD_NHTCD.Text = ""
            Me.HD_KENNMA.Text = ""

            Me.HD_JDNTRKB.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190603 ADD END

    Private Sub WLS_JDN2_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Me.Close()
		
	End Sub

    '20190603 DEL START
    '   'UPGRADE_WARNING: イベント HD_JDNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    '   Private Sub HD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.TextChanged
    '	'Debug.Print Me.NAME & ".HD_JDNNO_Change"
    '	Call Ctl_Item_Change(HD_JDNNO)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Enter
		'Debug.Print Me.NAME & ".HD_JDNNO_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNNO)
	End Sub
	
	Private Sub HD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNNO_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNNO, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNNO_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Leave
		'Debug.Print Me.NAME & ".HD_JDNNO_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNNO)
	End Sub
	
	Private Sub HD_JDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNNO_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNNO_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNNO, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    ''UPGRADE_WARNING: イベント HD_JDNTRKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged
    '    'Debug.Print Me.NAME & ".HD_JDNTRKB_Change"
    '    Call Ctl_Item_Change(HD_JDNTRKB)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter
		'Debug.Print Me.NAME & ".HD_JDNTRKB_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNTRKB_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave
		'Debug.Print Me.NAME & ".HD_JDNTRKB_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    ''UPGRADE_WARNING: イベント HD_JDNTRKBNM.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_JDNTRKBNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.TextChanged
    '    'Debug.Print Me.NAME & ".HD_JDNTRKBNM_Change"
    '    Call Ctl_Item_Change(HD_JDNTRKBNM)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNTRKBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.Enter
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNTRKBNM)
	End Sub
	
	Private Sub HD_JDNTRKBNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKBNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNTRKBNM, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNTRKBNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKBNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNTRKBNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKBNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.Leave
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNTRKBNM)
	End Sub
	
	Private Sub HD_JDNTRKBNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKBNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNTRKBNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNTRKBNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKBNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNTRKBNM, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: イベント HD_NHTCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_NHTCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.TextChanged
    '    'Debug.Print Me.NAME & ".HD_NHTCD_Change"
    '    Call Ctl_Item_Change(HD_NHTCD)
    'End Sub
    '20190603 DEL END

    Private Sub HD_NHTCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.Enter
		'Debug.Print Me.NAME & ".HD_NHTCD_GotFocus"
		Call Ctl_Item_GotFocus(HD_NHTCD)
	End Sub
	
	Private Sub HD_NHTCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHTCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_NHTCD_KeyDown"
		Call Ctl_Item_KeyDown(HD_NHTCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_NHTCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHTCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_NHTCD_KeyPress"
		Call Ctl_Item_KeyPress(HD_NHTCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHTCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.Leave
		'Debug.Print Me.NAME & ".HD_NHTCD_LostFocus"
		Call Ctl_Item_LostFocus(HD_NHTCD)
	End Sub
	
	Private Sub HD_NHTCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHTCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_NHTCD_MouseDown"
		Call Ctl_Item_MouseDown(HD_NHTCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_NHTCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHTCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_NHTCD_MouseUp"
		Call Ctl_Item_MouseUp(HD_NHTCD, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: イベント HD_TOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
    '    'Debug.Print Me.NAME & ".HD_TOKCD_Change"
    '    Call Ctl_Item_Change(HD_TOKCD)
    'End Sub
    '20190603 DEL END

    Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
		'Debug.Print Me.NAME & ".HD_TOKCD_GotFocus"
		Call Ctl_Item_GotFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_TOKCD_KeyDown"
		Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_TOKCD_KeyPress"
		Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
		'Debug.Print Me.NAME & ".HD_TOKCD_LostFocus"
		Call Ctl_Item_LostFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_TOKCD_MouseDown"
		Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_TOKCD_MouseUp"
		Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: イベント HD_KENNMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_KENNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.TextChanged
    '    'Debug.Print Me.NAME & ".HD_KENNMA_Change"
    '    Call Ctl_Item_Change(HD_KENNMA)
    'End Sub
    '20190603 DEL START

    Private Sub HD_KENNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Enter
		'Debug.Print Me.NAME & ".HD_KENNMA_GotFocus"
		Call Ctl_Item_GotFocus(HD_KENNMA)
	End Sub
	
	Private Sub HD_KENNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMA.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_KENNMA_KeyDown"
		Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KENNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KENNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_KENNMA_KeyPress"
		Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KENNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Leave
		'Debug.Print Me.NAME & ".HD_KENNMA_LostFocus"
		Call Ctl_Item_LostFocus(HD_KENNMA)
	End Sub
	
	Private Sub HD_KENNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_KENNMA_MouseDown"
		Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KENNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_KENNMA_MouseUp"
		Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'Debug.Print "LST_KeyDown"
		Call Ctl_Item_KeyDown(LST, System.Windows.Forms.Keys.Return, 0)
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print "LST_KeyDown"
		Select Case KeyCode
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
				Call Ctl_Item_KeyDown(LST, KeyCode, Shift)
				
				'Escapeキー押下
			Case System.Windows.Forms.Keys.Escape
                '20190603 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190603 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190603 CHG START
                'Call CM_PrevCm_Click(CM_PrevCm, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190603 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190603 CHG START
                'Call CM_NextCm_Click(CM_NextCm, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190603 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190604 ADD START
    Private Sub CS_JDNTRKB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNTRKB.Click
        Call Ctl_Item_Click(CS_JDNTRKB)
    End Sub

    Private Sub CS_TOKCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_TOKCD.Click
        Call Ctl_Item_Click(CS_TOKCD)
    End Sub

    Private Sub CS_JDNDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNDT.Click
        Call Ctl_Item_Click(CS_JDNDT)
    End Sub
    '20190604 ADD END

    Private Sub CS_JDNTRKB_Click()
		'Debug.Print Me.NAME & ".CS_JDNTRKB_Click"
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_GotFocus()
		'Debug.Print Me.NAME & ".CS_JDNTRKB_GotFocus"
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_JDNTRKB_KeyUp"
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_JDNTRKB_MouseUp"
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_JDNDT_Click()
		'Debug.Print Me.NAME & ".CS_JDNDT_Click"
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_GotFocus()
		'Debug.Print Me.NAME & ".CS_JDNDT_GotFocus"
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_JDNDT_KeyUp"
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_JDNDT_MouseUp"
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_JDNDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_TOKCD_Click()
		'Debug.Print Me.NAME & ".CS_TOKCD_Click"
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_GotFocus()
		'Debug.Print Me.NAME & ".CS_TOKCD_GotFocus"
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_TOKCD_KeyUp"
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_TOKCD_MouseUp"
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
	End Sub

    '20190603 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	'Debug.Print "WLSCANCEL_Click"
    '	Call Ctl_Item_Click(WLSCANCEL)
    'End Sub

    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '       'Debug.Print "WLSOK_Click"
    '       Call Ctl_Item_Click(WLSOK)
    '   End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Debug.Print("btnF12_Click")
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Debug.Print("btnF1_Click")
        Call Ctl_Item_Click(btnF1)
    End Sub
    '20190603 CHG END

    '20190603 CHG START
    '   Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NextCm.Click
    '	'Debug.Print "CM_NextCm_Click"
    '	Call Ctl_Item_Click(CM_NextCm)
    'End Sub

    '   Private Sub CM_PrevCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PrevCm.Click
    '       'Debug.Print "CM_PrevCm_Click"
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
    '20190603 CHG END

    '20190603 DEL START
    '   Private Sub CM_NextCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_NextCm_MouseDown"
    '	Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_PrevCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_PrevCm_MouseDown"
    '	Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_NextCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_NextCm_MouseUp"
    '	Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
    'End Sub

    '   Private Sub CM_PrevCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       'Debug.Print "CM_PrevCm_MouseUp"
    '       Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
    '   End Sub
    '20190603 DEL END

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
			'すべての取得データを退避していない場合は退避処理実行
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			'退避している場合はページ数アップ
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Edi_Dsp_Def
	'   概要：  初期時の画面編集
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Edi_Dsp_Def() As Short
		Dim Index_Wk As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'WLS_JDN2_0001.F_Init_Clr_Dsp で初期化処理を実行済み
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_WLSOK_Click
	'   概要：  OKボタン押下時
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_WLSOK_Click() As Short
		
		'戻り値を設定
		WLSJDN_RTNJDNNO = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), 1, 8)
		
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
		
		'画面を表示するときに戻り値変数は初期化されている
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		Hide()
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			
			'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Select Case Me.ActiveControl.Name
				Case HD_JDNNO.Name, HD_JDNTRKB.Name, HD_NHTCD.Name, HD_TOKCD.Name, HD_KENNMA.Name
					'変数クリア
					Call WLS_Clear()
					'リスト編集
					Call F_Get_JDNTHA()
					Call WLS_DspNew()
					
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)

                    '20190603 ADD START
                Case btnF2.Name
                    '変数クリア
                    Call WLS_Clear()
                    'リスト編集
                    Call F_Get_JDNTHA()
                    Call WLS_DspNew()

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)
                    '20190603 ADD END

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
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		
		Dim Cnt As Integer
		Dim strWORK As String
		
		Cnt = 0
        Debug.Print(VB6.Format(Now, "hh:mi:ss"))

        '20190603 CHG START
        '        Do Until CF_Ora_EOF(Usr_Ody) = True

        '			'取得内容退避
        '			With pv_DB_JDNTHA_W
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.DATKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_DATKB", " ") '
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_JDNNO", " ") '受注番号
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.LINNO = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_LINNO", " ") '行番号
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_JDNDT", " ") '受注伝票日付
        '				.JDNDT = VB6.Format(strWORK, "@@@@/@@/@@")
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKMTA_TOKCD", " ") '得意先コード
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKMTA_TOKRN", " ") '得意先略称
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSMTA_NHSCD", " ") '納入先コード
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSMTA_NHSRN", " ") '納入先略称
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.HINNMA = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_HINNMA", " ") '品名
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.HINNMB = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_HINNMB", " ") '品名
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.UDOSU = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_UODSU", 0) '数量
        '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				.JDNTRKBNM = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNTRKB", " ") '受注取引区分

        '				''            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNTRKB", "")            '受注取引区分
        '				''            strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_DENDT", "")               '受注日付
        '				''            .DENDT = Format(strWORK, "@@@@/@@/@@")
        '				''            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMA", "")              '件名１
        '				''            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMB", "")              '件名２
        '			End With

        '			If pv_DB_JDNTHA_W.DATKB <> "1" Then GoTo WLS_DspNew_skip

        '			'表示改ページ
        '			If Cnt Mod WM_WLS_MAX = 0 Then
        '				'ウィンド表示ページカウンタをカウントアップ
        '				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '				'ウィンド表示データ領域をリスト行数分作成
        '				ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '				Cnt = 0
        '				'最終ページ退避
        '				WM_WLS_LastPage = WM_WLS_Pagecnt
        '			End If

        '			'表示メモリ展開
        '			Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '			Cnt = Cnt + 1

        'WLS_DspNew_skip: 
        '			Call CF_Ora_MoveNext(Usr_Ody)

        '			If Cnt >= WM_WLS_MAX Then
        '				Exit Do
        '			End If

        '		Loop

        '        '最終データ到達
        '        If CF_Ora_EOF(Usr_Ody) = True Then
        '            WM_WLS_LastFL = True
        '        End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            '取得内容退避
            With pv_DB_JDNTHA_W
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_DATKB"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_JDNNO"), " ") '受注番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .LINNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_LINNO"), " ") '行番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strWORK = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_JDNDT"), " ") '受注伝票日付
                .JDNDT = VB6.Format(strWORK, "@@@@/@@/@@")
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKMTA_TOKCD"), " ") '得意先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKMTA_TOKRN"), " ") '得意先略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSMTA_NHSCD"), " ") '納入先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSMTA_NHSRN"), " ") '納入先略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_HINNMA"), " ") '品名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMB = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_HINNMB"), " ") '品名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UDOSU = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_UODSU"), 0) '数量
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNTRKBNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTHA_JDNTRKB"), " ") '受注取引区分

            End With

            '表示改ページ
            If Cnt Mod WM_WLS_MAX = 0 Then
                'ウィンド表示ページカウンタをカウントアップ
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                'ウィンド表示データ領域をリスト行数分作成
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '表示メモリ展開
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

            Cnt = Cnt + 1

        Next

        '最終データ到達
        WM_WLS_LastFL = True
        '20190603 CHG END

        If Cnt > 0 Then
            'ページを表示
            '20190603 ADD START
            WM_WLS_Pagecnt = 0
            '20190603 ADD END
            Call WLS_DspPage()
		End If
		
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
		
		'表示データ有無チェック
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		intCnt = 0
		'明細行数分ループ
		Do While intCnt < WM_WLS_MAX
			'WM_WLS_Pagecnt = ページ数 - 1 が設定されている
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			'ADD START FKS)INABA 2007/01/11**********
			On Error Resume Next
			'ADD  END  FKS)INABA 2007/01/11**********
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		Const pad As String = "　　　　　　　　　　　　　　　　　　　　"
		
		With pv_DB_JDNTHA_W
			'        WM_WLS_DSPArray(ArrayCnt) = LeftWid2$(Trim(.JDNNO) & RightWid$(.LINNO, 2), 8) & " " & _
			''                                    LeftWid2$(.JDNDT, 10) & " " & _
			''                                    LeftWid2$(.TOKCD, 5) & " " & _
			''                                    LeftWid2$(.TOKRN & Space(20), 20) & " " & _
			''                                    LeftWid2$(.NHSCD, 9) & " " & _
			''                                    LeftWid2$(.NHSRN & Space(20), 20) & " " & _
			''                                    LeftWid2$(.HINNMA & Space(20), 20) & " " & _
			''                                    LeftWid2$(.HINNMB & Space(20), 20) & " " & _
			''                                    String(7 - Len(Format$(.UDOSU, "###,##0")), " ") + Format$(.UDOSU, "###,##0") & " " & _
			''                                    LeftWid2$(.JDNTRKBNM, 2)
			
			WM_WLS_DSPArray(ArrayCnt) = LeftWid(Trim(.JDNNO) & RightWid(.LINNO, 2), 8) & " " & LeftWid(.JDNDT & Space(10), 10) & " " & LeftWid(.TOKCD & Space(5), 5) & " " & LeftWid(.TOKRN & pad, 20) & " " & LeftWid(.NHSCD & Space(9), 9) & " " & LeftWid(.NHSRN & Space(20), 20) & " " & LeftWid(.HINNMA & Space(20), 20) & " " & LeftWid(.HINNMB & Space(20), 20) & " " & New String(" ", 7 - Len(VB6.Format(.UDOSU, "###,##0"))) & VB6.Format(.UDOSU, "###,##0") & " " & LeftWid(.JDNTRKBNM, 2)
			
		End With
		
	End Sub
	
	Private Function F_Get_JDNTHA() As Short
		
		Dim intRet As Short
		Dim strSQL As String
		Dim strTANCD As String
		Dim strJdnNo As String
		Dim strJDNTRKB As String
		Dim strJDNDT As String
		Dim strTOKCD As String
		Dim strKENNMA As String
		
		On Error GoTo F_Get_JDNTHA_Err
		
		intRet = 99
		
		'客先注文番号を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJdnNo = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNNO.Tag)))
		
		'受注取引区分を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJDNTRKB = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNTRKB.Tag)))
		
		'納入先コードを画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJDNDT = CF_Ora_Date(CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_NHTCD.Tag))))
		
		'得意先コードを画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strTOKCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_TOKCD.Tag)))
		
		'開始受注番号を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKENNMA = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_KENNMA.Tag)))
		
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "  JDNTRA.DATKB   AS JDNTRA_DATKB" '
		strSQL = strSQL & ", JDNTRA.JDNNO   AS JDNTRA_JDNNO" '受注番号
		strSQL = strSQL & ", JDNTRA.LINNO   AS JDNTRA_LINNO" '行番号
		strSQL = strSQL & ", JDNTRA.JDNDT   AS JDNTRA_JDNDT" '受注伝票日付
		strSQL = strSQL & ", JDNTRA.DENDT   AS JDNTRA_DENDT" '受注日付
		strSQL = strSQL & ", JDNTHA.JDNTRKB AS JDNTHA_JDNTRKB" '受注取引区分
		strSQL = strSQL & ", JDNTRA.TOKCD   AS TOKMTA_TOKCD" '得意先コード
		strSQL = strSQL & ", TOKMTA.TOKRN   AS TOKMTA_TOKRN" '得意先略称
		strSQL = strSQL & ", JDNTRA.NHSCD   AS NHSMTA_NHSCD" '納入先コード
		'CHG START FKS)INABA 2006/11/16 ***********************************************
		strSQL = strSQL & ", NVL(NHSMTA.NHSRN,'                                        ')   AS NHSMTA_NHSRN" '納入先略称
		'    strSQL = strSQL & ", NHSMTA.NHSRN   AS NHSMTA_NHSRN"        '納入先略称
		'CHG  END  FKS)INABA 2006/11/16 ***********************************************
		strSQL = strSQL & ", JDNTRA.HINNMA  AS JDNTRA_HINNMA" '型式
		strSQL = strSQL & ", JDNTRA.HINNMB  AS JDNTRA_HINNMB" '品名
		strSQL = strSQL & ", JDNTRA.UODSU   AS JDNTRA_UODSU" '数量
		strSQL = strSQL & ", JDNTHA.JDNTRKB AS JDNTHA_JDNTRKB" '受注取引区分
		strSQL = strSQL & ", MEIMTA.MEINMA  AS MEIMTA_JDNTRKBNM" '受注取引区分名称
		strSQL = strSQL & " FROM JDNTHA"
		strSQL = strSQL & ",     JDNTRA"
		strSQL = strSQL & ",     TOKMTA"
		strSQL = strSQL & ",     MEIMTA"
		strSQL = strSQL & ",     NHSMTA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "       JDNTHA.DATKB     = '" & gc_strDATKB_USE & "'"
		'受注取引区分
		If Trim(strJDNTRKB) <> "" Then
			strSQL = strSQL & " AND JDNTHA.JDNTRKB = '" & CF_Ora_String(strJDNTRKB, 2) & "'"
		End If
		strSQL = strSQL & " AND   JDNTRA.JDNNO     = JDNTHA.JDNNO "
		strSQL = strSQL & " AND   JDNTRA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND  (JDNTRA.JDNKB = '1' or JDNTRA.JDNKB = '2')"
		strSQL = strSQL & " AND   MEIMTA.MEICDA    = JDNTHA.JDNTRKB "
		strSQL = strSQL & " AND   MEIMTA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND   MEIMTA.KEYCD     = '" & gc_strKEYCD_JDNTRKB & "'"
		strSQL = strSQL & " AND   TOKMTA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND   TOKMTA.TOKCD     = JDNTHA.TOKCD "
		'ADD START FKS)INABA 2008/08/18***************************************************************
		strSQL = strSQL & " AND   JDNTHA.DATNO IN (SELECT MAX(DATNO) FROM JDNTHA GROUP BY JDNNO ) "
		'ADD  END  FKS)INABA 2008/08/18***************************************************************
		strSQL = strSQL & " "
		'CHG START FKS)INABA 2006/11/16 **************************************************************
		strSQL = strSQL & " AND   NHSMTA.NHSCD(+)     = JDNTHA.NHSCD "
		'    strSQL = strSQL & " AND   NHSMTA.NHSCD     = JDNTHA.NHSCD "
		'CHG  END  FKS)INABA 2006/11/16 **************************************************************
		
		'客先注文番号
		If Trim(strJdnNo) <> "" Then
			strSQL = strSQL & " AND JDNTRA.JDNNO  >= '" & CF_Ora_String(strJdnNo, 10) & "'"
		End If
		
		'納入先コード
		If Trim(strJDNDT) <> "" Then
			strSQL = strSQL & " AND JDNTRA.JDNDT  >= '" & CF_Ora_String(strJDNDT, 8) & "'"
		End If
		
		'得意先コード
		If Trim(strTOKCD) <> "" Then
			strSQL = strSQL & " AND JDNTRA.TOKCD   = '" & CF_Ora_String(strTOKCD, 10) & "'"
		End If
		
		'開始受注No
		If Trim(strKENNMA) <> "" Then
			'CHG START FKS)INABA 2006/11/16 *******************************************************************
			strSQL = strSQL & " AND JDNTRA.JDNNO >= '" & Trim(strKENNMA) & "'"
			'        strSQL = strSQL & " AND JDNTRA.KENNMA || JDNTHA.KENNMB LIKE '%" & Trim(strKENNMA) & "%'"
			'CHG  END  FKS)INABA 2006/11/16 *******************************************************************
		End If
		
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "  JDNTRA_JDNNO"
		
		If Dyn_Open = True Then
            'オープンしていたらクローズ
            '20190603 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190603 DEL END
            Dyn_Open = False
		End If

        'DBアクセス
        '20190603 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190603 CHG END
        Dyn_Open = True

        '20190603 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190603 CHG END
            LST.Items.Clear()
        End If

        intRet = 0
		
F_Get_JDNTHA_End: 
		
		F_Get_JDNTHA = intRet
		Exit Function
		
F_Get_JDNTHA_Err: 
		
		intRet = 99
		GoTo F_Get_JDNTHA_End
		
	End Function
	
	Private Function LeftWid2(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		LeftWid2 = ""
		
		If AnsiLenB(pm_Characters) <= pm_Wid Then
			LeftWid2 = pm_Characters & Space(pm_Wid - AnsiLenB(pm_Characters))
			Exit Function
		End If
		
		If AnsiLenB(pm_Characters) > pm_Wid Then
			
			Do Until lngKeta >= pm_Wid
				lngMoji = lngMoji + 1
                'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
                'lngKeta = lngKeta + LenB(StrConv(Mid(pm_Characters, lngMoji, 1), vbFromUnicode))
                lngKeta = lngKeta + LenB(Mid(pm_Characters, lngMoji, 1))
            Loop 
			
			If lngKeta > pm_Wid Then
				LeftWid2 = VB.Left(pm_Characters, lngMoji - 1) & Space(1)
			Else
				LeftWid2 = VB.Left(pm_Characters, lngMoji)
			End If
		End If
		
	End Function
	
	
	Private Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(StrArg)
#End If
    End Function
	
	' StrConv を呼び出します。
	Private Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If
		
	End Function
End Class