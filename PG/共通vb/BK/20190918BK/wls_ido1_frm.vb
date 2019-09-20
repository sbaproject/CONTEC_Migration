Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_IDO1
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　受注情報検索
	'*  プログラムＩＤ　：  WLS_IDO1
	'*  作成者　　　　　：　ACE)古川
	'*  作成日　　　　　：  2006.07.28
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   構造体
	'************************************************************************************
	Private Structure Type_DB_SBNTRA_W
		Dim DATNO As String ' 伝票管理番号
		Dim OUTYTDT As String ' 出庫予定日
		Dim SBNNO As String ' 製番
		Dim HINCD As String ' 製品コード
		Dim HINNMA As String ' 型式
		'CHG START FKS)INABA 2006/11/27 *********************************************
		Dim FRDYTSU As Integer ' 数量
		'        FRDYTSU     As Integer      ' 数量
		'CHG  END  FKS)INABA 2006/11/27 *********************************************
		Dim OUTBMCD As String ' 送り先部門コード
		Dim OUTBNNM As String ' 送り先部門名
		Dim NHSCD As String ' 納入先コード
		Dim NHSNMA As String ' 納入先名
		Dim OUTSOUCD As String ' 出庫倉庫コード
		Dim OUTSOUNM As String ' 出庫倉庫名
	End Structure
	'************************************************************************************
	'   Private定数
	'************************************************************************************
	Private Const FM_PANEL3D1_CNT As Short = 1 'パネルコントロール数
	Private Const pc_intCntListRow As Short = 15 '明細行数
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'=== 当画面の全情報を格納 =================
	'UPGRADE_WARNING: 構造体 Main_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Main_Inf As Cls_All
	'=== 当画面の全情報を格納 =================
	
	Private pv_DB_SBNTRA_W As Type_DB_SBNTRA_W
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	Private WM_WLS_MAX As Short 'リスト行数
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_DATNOarray() As String '表示しないデータ
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
            '20190604 CHG START
            '.Item_Cnt = 16 '画面項目数
            .Item_Cnt = 17 '画面項目数
            '20190604 CHG END
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
		'出庫指示日付ボタン
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
		'出庫指示日付
		HD_JDNDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNDT
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
		'送り先部門ボタン
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
		'送り先部門
		HD_JDNTRKB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
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
		'製品コードボタン
		'UPGRADE_WARNING: オブジェクト CS_HINCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
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
		'納入先コードボタン
		'UPGRADE_WARNING: オブジェクト CS_NHSCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CS_NHSCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_NHSCD
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
		HD_NHSCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSCD
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
		'製番
		HD_SBNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'CHG START FKS)INABA 2007/02/26 **************************************
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'CHG  END  FKS)INABA 2007/02/26 **************************************
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
        '20190604 CHG START
        'WLSOK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
        btnF1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '20190604 CHG END
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
        '20190604 CHG START
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '20190604 CHG END

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
        '20190604 CHG START
        'CM_PrevCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '20190604 CHG END
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
        '20190604 CHG START
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '20190604 CHG END

        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '次ページイメージ
        '20190604 CHG START
        'CM_NextCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '20190604 CHG END
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
        '20190604 CHG START
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '20190604 CHG END

        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NextCm(0)
		Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NextCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        '20190604 ADD START
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
        '20190604 ADD END


        Index_Wk = Index_Wk + 1
        'キャンセルボタン
        '20190604 CHG START
        'WLSCANCEL.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190604 CHG END
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
        '20190604 CHG START
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '20190604 CHG END


        '画面基礎情報設定
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        '///////////////////
        '// その他編集
        '///////////////////
        '20190604 DEL START
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1
        '    'FM_Panel3D1
        '    'CHG START FKS)INABA 2006/11/27 ***************************************************
        '    'UPGRADE_WARNING: オブジェクト Me.FM_Panel3D1().Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Me.FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    '        FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    'CHG  END  FKS)INABA 2006/11/27 ***************************************************
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
        '20190604 DEL END
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
		WLS_IDO1_DATNO = ""
		
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
		Call WLS_IDO1_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_IDO1_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_IDO1_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_SBNNO.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call F_Get_SBNTRA()
						Call WLS_DspNew()
					Case Else
				End Select
				'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
				Call WLS_IDO1_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
		Call WLS_IDO1_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_IDO1_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_IDO1_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
				Call WLS_IDO1_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
				Call WLS_IDO1_0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
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
		If gv_bolWLS_IDO1_LF_Enable = False Then
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
		Rtn_Chk = WLS_IDO1_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_IDO1_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
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
				Call WLS_IDO1_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
		Call WLS_IDO1_0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'次の項目へ移動した場合
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = WLS_IDO1_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_IDO1_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Select Case Me.ActiveControl.Name
					Case HD_SBNNO.Name
						'変数クリア
						Call WLS_Clear()
						'リスト編集
						Call F_Get_SBNTRA()
						Call WLS_DspNew()
					Case Else
				End Select
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call WLS_IDO1_0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
		Call WLS_IDO1_0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
                Call WLS_IDO1_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060801 === INSERT S - ACE)Nagasawa　検索Wボタン対応
            Case TypeOf pm_Ctl Is Button
                'ボタンの場合
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    Call WLS_IDO1_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
		Call WLS_IDO1_0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		'UPGRADE_WARNING: オブジェクト CS_NHSCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_TOKCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_HINCD.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CS_JDNDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Trg_Index
			Case CShort(CS_JDNDT.Tag)
				'出庫指示日付検索画面呼出
				Call WLS_IDO1_0001.F_Ctl_CS_JDNDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_JDNTRKB.Tag)
				'送り先部門検索画面呼出
				Call WLS_IDO1_0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_HINCD.Tag)
				'製品検索画面呼出
				Call WLS_IDO1_0001.F_Ctl_CS_HINCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_TOKCD.Tag)
				'得意先検索画面呼出
				Call WLS_IDO1_0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_NHSCD.Tag)
				'納入先検索画面呼出
				Call WLS_IDO1_0001.F_Ctl_CS_NHSCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
                '20190604 CHG END

        End Select
		
	End Function

    '20190604 ADD START
    Private Sub CS_HINCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_HINCD.Click
        Call Ctl_Item_Click(CS_HINCD)
    End Sub
    '20190604 ADD END

    Private Sub CS_HINCD_Click()
		Debug.Print(Me.Name & ".CS_HINCD_Click")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_HINCD)
	End Sub
	
	Private Sub CS_HINCD_GotFocus()
		Debug.Print(Me.Name & ".CS_HINCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_HINCD)
	End Sub
	
	Private Sub CS_HINCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print(Me.Name & ".CS_HINCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_HINCD)
	End Sub
	
	Private Sub CS_HINCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print(Me.Name & ".CS_HINCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_HINCD, Button, Shift, X, Y)
	End Sub

    '20190604 ADD START
    Private Sub CS_NHSCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_NHSCD.Click
        Call Ctl_Item_Click(CS_NHSCD)
    End Sub
    '20190604 ADD END

    Private Sub CS_NHSCD_Click()
		Debug.Print(Me.Name & ".CS_NHSCD_Click")
		'UPGRADE_WARNING: オブジェクト CS_NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_NHSCD)
	End Sub
	
	Private Sub CS_NHSCD_GotFocus()
		Debug.Print(Me.Name & ".CS_NHSCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_NHSCD)
	End Sub
	
	Private Sub CS_NHSCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print(Me.Name & ".CS_NHSCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_NHSCD)
	End Sub
	
	Private Sub CS_NHSCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print(Me.Name & ".CS_NHSCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_NHSCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub WLS_IDO1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'画面情報設定
		Call Init_Def_Dsp()
		
		'画面内容初期化
		Call WLS_IDO1_0001.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'初期表示編集
		Call Edi_Dsp_Def()
		
		'画面表示位置設定
		Call CF_Set_Frm_Location(Me)
		
	End Sub


    '20190604 ADD START
    Private Sub WLS_IDO1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If Me.HD_JDNDT.Focused Then
                Call HD_JDNDT_KeyDown(HD_JDNDT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_JDNTRKB.Focused Then
                Call HD_JDNTRKB_KeyDown(HD_JDNTRKB, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_HINCD.Focused Then
                Call HD_HINCD_KeyDown(HD_HINCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_TOKCD.Focused Then
                Call HD_TOKCD_KeyDown(HD_TOKCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_NHSCD.Focused Then
                Call HD_NHSCD_KeyDown(HD_NHSCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_SBNNO.Focused Then
                Call HD_SBNNO_KeyDown(HD_SBNNO, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_JDNDT_KeyDown(HD_JDNDT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
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
            Me.HD_JDNDT.Text = ""
            Me.HD_JDNTRKB.Text = ""
            Me.HD_HINCD.Text = ""
            Me.HD_TOKCD.Text = ""
            Me.HD_NHSCD.Text = ""
            Me.HD_SBNNO.Text = ""

            Me.HD_JDNDT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    '20190604 ADD END


    'UPGRADE_WARNING: イベント HD_HINCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.TextChanged
    '	Debug.Print(Me.Name & ".HD_HINCD_Change")
    '	Call Ctl_Item_Change(HD_HINCD)
    'End Sub

    Private Sub HD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Enter
		Debug.Print(Me.Name & ".HD_HINCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_HINCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_HINCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Leave
		Debug.Print(Me.Name & ".HD_HINCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_HINCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_HINCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
	End Sub


    'UPGRADE_WARNING: イベント HD_JDNTRKB.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged
    '	Debug.Print(Me.Name & ".HD_JDNTRKB_Change")
    '	Call Ctl_Item_Change(HD_JDNTRKB)
    'End Sub

    Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter
		Debug.Print(Me.Name & ".HD_JDNTRKB_GotFocus")
		Call Ctl_Item_GotFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_JDNTRKB_KeyDown")
		Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_JDNTRKB_KeyPress")
		Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave
		Debug.Print(Me.Name & ".HD_JDNTRKB_LostFocus")
		Call Ctl_Item_LostFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_JDNTRKB_MouseDown")
		Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_JDNTRKB_MouseUp")
		Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub

    'UPGRADE_WARNING: イベント HD_JDNDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_JDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.TextChanged
    '	Debug.Print(Me.Name & ".HD_JDNDT_Change")
    '	Call Ctl_Item_Change(HD_JDNDT)
    'End Sub

    Private Sub HD_JDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.Enter
		Debug.Print(Me.Name & ".HD_JDNDT_GotFocus")
		Call Ctl_Item_GotFocus(HD_JDNDT)
	End Sub
	
	Private Sub HD_JDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNDT.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_JDNDT_KeyDown")
		Call Ctl_Item_KeyDown(HD_JDNDT, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_JDNDT_KeyPress")
		Call Ctl_Item_KeyPress(HD_JDNDT, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.Leave
		Debug.Print(Me.Name & ".HD_JDNDT_LostFocus")
		Call Ctl_Item_LostFocus(HD_JDNDT)
	End Sub
	
	Private Sub HD_JDNDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_JDNDT_MouseDown")
		Call Ctl_Item_MouseDown(HD_JDNDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_JDNDT_MouseUp")
		Call Ctl_Item_MouseUp(HD_JDNDT, Button, Shift, X, Y)
	End Sub

    'UPGRADE_WARNING: イベント HD_TOKCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
    '	Debug.Print(Me.Name & ".HD_TOKCD_Change")
    '	Call Ctl_Item_Change(HD_TOKCD)
    'End Sub

    Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
		Debug.Print(Me.Name & ".HD_TOKCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_TOKCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_TOKCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
		Debug.Print(Me.Name & ".HD_TOKCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_TOKCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_TOKCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
	End Sub

    'UPGRADE_WARNING: イベント HD_NHSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_NHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.TextChanged
    '	Debug.Print(Me.Name & ".HD_NHSCD_Change")
    '	Call Ctl_Item_Change(HD_NHSCD)
    'End Sub

    Private Sub HD_NHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Enter
		Debug.Print(Me.Name & ".HD_NHSCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_NHSCD)
	End Sub
	
	Private Sub HD_NHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_NHSCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_NHSCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_NHSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_NHSCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_NHSCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Leave
		Debug.Print(Me.Name & ".HD_NHSCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_NHSCD)
	End Sub
	
	Private Sub HD_NHSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_NHSCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_NHSCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_NHSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_NHSCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_NHSCD, Button, Shift, X, Y)
	End Sub

    'UPGRADE_WARNING: イベント HD_SBNNO.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub HD_SBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.TextChanged
    '	Debug.Print(Me.Name & ".HD_SBNNO_Change")
    '	Call Ctl_Item_Change(HD_SBNNO)
    'End Sub

    Private Sub HD_SBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Enter
		Debug.Print(Me.Name & ".HD_SBNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_SBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print(Me.Name & ".HD_SBNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_SBNNO, KeyCode, Shift)
	End Sub
	
	Private Sub HD_SBNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SBNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print(Me.Name & ".HD_SBNNO_KeyPress")
		Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Leave
		Debug.Print(Me.Name & ".HD_SBNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_SBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_SBNNO_MouseDown")
		Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print(Me.Name & ".HD_SBNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		Debug.Print("LST_KeyDown")
		Call Ctl_Item_KeyDown(LST, System.Windows.Forms.Keys.Return, 0)
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
                '20190604 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190604 CHG END

                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '20190604 CHG START
                'Call CM_PrevCm_Click(CM_PrevCm, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190604 CHG END

                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '20190604 CHG START
                'Call CM_NextCm_Click(CM_NextCm, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190604 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190604 ADD START
    Private Sub CS_JDNTRKB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNTRKB.Click
        Call Ctl_Item_Click(CS_JDNTRKB)
    End Sub
    '20190604 ADD END

    Private Sub CS_JDNTRKB_Click()
		Debug.Print(Me.Name & ".CS_JDNTRKB_Click")
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_GotFocus()
		Debug.Print(Me.Name & ".CS_JDNTRKB_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print(Me.Name & ".CS_JDNTRKB_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print(Me.Name & ".CS_JDNTRKB_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
	End Sub

    '20190604 ADD START
    Private Sub CS_JDNDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNDT.Click
        Call Ctl_Item_Click(CS_JDNDT)
    End Sub
    '20190604 ADD END

    Private Sub CS_JDNDT_Click()
		Debug.Print(Me.Name & ".CS_JDNDT_Click")
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_GotFocus()
		Debug.Print(Me.Name & ".CS_JDNDT_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print(Me.Name & ".CS_JDNDT_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print(Me.Name & ".CS_JDNDT_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_JDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_JDNDT, Button, Shift, X, Y)
	End Sub

    '20190604 ADD START
    Private Sub CS_TOKCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_TOKCD.Click
        Call Ctl_Item_Click(CS_TOKCD)
    End Sub
    '20190604 ADD END

    Private Sub CS_TOKCD_Click()
		Debug.Print(Me.Name & ".CS_TOKCD_Click")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_Click(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_GotFocus()
		Debug.Print(Me.Name & ".CS_TOKCD_GotFocus")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_GotFocus(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		Debug.Print(Me.Name & ".CS_TOKCD_KeyUp")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_KeyUp(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print(Me.Name & ".CS_TOKCD_MouseUp")
		'UPGRADE_WARNING: オブジェクト CS_TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
	End Sub

    '20190604 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	Debug.Print("WLSCANCEL_Click")
    '	Call Ctl_Item_Click(WLSCANCEL)
    'End Sub

    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '       Debug.Print("WLSOK_Click")
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
    '20190604 CHG END

    '20190604 CHG START
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
    '20190604 CHG END

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
		
		'WLS_IDO1_0001.F_Init_Clr_Dsp で初期化処理を実行済み
		
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
		' LSTとKEYBAKとのリストは同期している。LST上で選択してKEYBAKの値を取得する(9/28)
		WLS_IDO1_DATNO = VB6.GetItemString(KEYBAK, LST.SelectedIndex)
		
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
		
		'画面を表示するときに戻り値変数は初期化されている
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		Me.Close()
		' Hide
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
		Rtn_Chk = WLS_IDO1_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_IDO1_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			
			'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Select Case Me.ActiveControl.Name
				Case HD_JDNDT.Name, HD_JDNTRKB.Name, HD_HINCD.Name, HD_TOKCD.Name, HD_NHSCD.Name, HD_SBNNO.Name
					'変数クリア
					Call WLS_Clear()
					'リスト編集
					Call F_Get_SBNTRA()
					Call WLS_DspNew()
					
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)

                    '20190604 ADD START
                Case btnF2.Name
                    '変数クリア
                    Call WLS_Clear()
                    'リスト編集
                    Call F_Get_SBNTRA()
                    Call WLS_DspNew()

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)
                    '20190604 ADD END

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
		ReDim WM_WLS_DATNOarray(0)
		
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

        '20190604 CHG START
        '        Do Until CF_Ora_EOF(Usr_Ody) = True

        '            '取得内容退避
        '            With pv_DB_SBNTRA_W
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .DATNO = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_DATNO", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .OUTYTDT = VB6.Format(CF_Ora_GetDyn(Usr_Ody, "SBNTRA_OUTYTDT", " "), "@@@@/@@/@@") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .SBNNO = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_SBNNO", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .HINCD = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_HINCD", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .HINNMA = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_HINNMA", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .FRDYTSU = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_FRDYTSU", 0) '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .OUTBMCD = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_OUTBMCD", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .OUTBNNM = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_OUTBNNM", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .NHSCD = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_NHSCD", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_NHSNMA", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .OUTSOUCD = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_OUTSOUCD", " ") '
        '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .OUTSOUNM = CF_Ora_GetDyn(Usr_Ody, "SBNTRA_OUTSOUNM", " ") '

        '            End With

        '            '        If pv_DB_SBNTRA_W.DATKB <> "1" Then GoTo WLS_DspNew_skip

        '            '表示改ページ
        '            If Cnt Mod WM_WLS_MAX = 0 Then
        '                'ウィンド表示ページカウンタをカウントアップ
        '                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '                'ウィンド表示データ領域をリスト行数分作成
        '                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '                ReDim Preserve WM_WLS_DATNOarray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '                Cnt = 0
        '                '最終ページ退避
        '                WM_WLS_LastPage = WM_WLS_Pagecnt
        '            End If

        '            '表示メモリ展開
        '            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '            Cnt = Cnt + 1

        'WLS_DspNew_skip:
        '            Call CF_Ora_MoveNext(Usr_Ody)

        '            If Cnt >= WM_WLS_MAX Then
        '                Exit Do
        '            End If

        '        Loop

        '        '最終データ到達
        '        If CF_Ora_EOF(Usr_Ody) = True Then
        '			WM_WLS_LastFL = True
        '		End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            '取得内容退避
            With pv_DB_SBNTRA_W
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_DATNO"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OUTYTDT = VB6.Format(DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_OUTYTDT"), " "), "@@@@/@@/@@") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBNNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_SBNNO"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_HINCD"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_HINNMA"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .FRDYTSU = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_FRDYTSU"), 0) '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OUTBMCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_OUTBMCD"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OUTBNNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_OUTBNNM"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_NHSCD"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_NHSNMA"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OUTSOUCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_OUTSOUCD"), " ") '
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OUTSOUNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("SBNTRA_OUTSOUNM"), " ") '

            End With

            '表示改ページ
            If Cnt Mod WM_WLS_MAX = 0 Then
                'ウィンド表示ページカウンタをカウントアップ
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                'ウィンド表示データ領域をリスト行数分作成
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                ReDim Preserve WM_WLS_DATNOarray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
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
        '20190604 CHG END

        If Cnt > 0 Then
            'ページを表示
            '20190604 ADD START
            WM_WLS_Pagecnt = 0
            '20190604 ADD END
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
		KEYBAK.Items.Clear()
		
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
				KEYBAK.Items.Add(WM_WLS_DATNOarray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
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
		
		With pv_DB_SBNTRA_W
			WM_WLS_DSPArray(ArrayCnt) = LeftWid(Trim(.OUTYTDT), 10) & " " & LeftWid(.SBNNO & Space(10), 10) & " " & LeftWid(.HINCD & Space(8), 8) & " " & LeftWid(.HINNMA & pad, 20) & " " & New String(" ", 7 - Len(VB6.Format(.FRDYTSU, "###,##0"))) & VB6.Format(.FRDYTSU, "###,##0") & " " & LeftWid(.OUTBMCD & Space(6), 6) & " " & LeftWid(.OUTBNNM & Space(20), 20) & " " & LeftWid(.NHSCD & Space(5), 5) & " " & LeftWid(.NHSNMA & Space(20), 20) & " " & LeftWid(.OUTSOUCD & Space(3), 3) & " " & LeftWid(.OUTSOUNM & Space(20), 20)
			
			WM_WLS_DATNOarray(ArrayCnt) = .DATNO
		End With
		
	End Sub
	
	Private Function F_Get_SBNTRA() As Short
		
		Dim intRet As Short
		Dim strSQL As String
		Dim strOUTYTDT As String ' 出荷指示日付
		Dim strOUTBMCD As String ' 送り先部門
		Dim strHINCD As String ' 製品コード
		Dim strTOKCD As String ' 得意先コード
		Dim strNHSCD As String ' 納入先コード
		Dim strSBNNO As String ' 製番
		Dim strTANCD As String
		Dim strJdnNo As String
		Dim strJDNTRKB As String
		Dim strJDNDT As String
		Dim strKENNMA As String
		
		On Error GoTo F_Get_SBNTRA_Err
		
		intRet = 99
		
		'出庫指示日付を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strOUTYTDT = CF_Ora_Date(CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNDT.Tag))))
		
		'送り先部門を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strOUTBMCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNTRKB.Tag)))
		
		'製品コードを画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strHINCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_HINCD.Tag)))
		
		'得意先コードを画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strTOKCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_TOKCD.Tag)))
		
		'納入先コードを画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strNHSCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_NHSCD.Tag)))
		
		'製番を画面から取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSBNNO = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_SBNNO.Tag)))
		
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "  SBNTRA.DATNO   as SBNTRA_DATNO" '伝票管理番号
		strSQL = strSQL & ", SBNTRA.OUTYTDT as SBNTRA_OUTYTDT" '出庫予定日
		strSQL = strSQL & ", SBNTRA.SBNNO   as SBNTRA_SBNNO" '製番
		strSQL = strSQL & ", SBNTRA.HINCD   as SBNTRA_HINCD" '製品コード
		strSQL = strSQL & ", SBNTRA.HINNMA  as SBNTRA_HINNMA" '型式
		strSQL = strSQL & ", SBNTRA.FRDYTSU as SBNTRA_FRDYTSU" '数量
		strSQL = strSQL & ", SBNTRA.OUTBMCD as SBNTRA_OUTBMCD" '送り先部門コード
		strSQL = strSQL & ", SBNTRA.OUTBNNM as SBNTRA_OUTBNNM" '送り先部門名称
		strSQL = strSQL & ", SBNTRA.NHSCD   as SBNTRA_NHSCD" '納入先コード
		strSQL = strSQL & ", SBNTRA.NHSNMA  as SBNTRA_NHSNMA" '納入先名1
		strSQL = strSQL & ", SBNTRA.OUTSOUCD as SBNTRA_OUTSOUCD" '出庫倉庫コード
		strSQL = strSQL & ", SBNTRA.OUTSOUNM as SBNTRA_OUTSOUNM" '出庫倉庫名
		strSQL = strSQL & " FROM SBNTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "       SBNTRA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & "  AND  SBNTRA.FRDYTSU <> SBNTRA.OUTSMSU"
		If Trim(strOUTYTDT) <> "" Then
			strSQL = strSQL & "  AND SBNTRA.OUTYTDT >= '" & CF_Ora_Date(strOUTYTDT) & "'"
		End If
		If Trim(strOUTBMCD) <> "" Then
			strSQL = strSQL & "  AND SBNTRA.OUTBMCD = '" & CF_Ora_String(strOUTBMCD, 6) & "'"
		End If
		If Trim(strHINCD) <> "" Then
			strSQL = strSQL & "  AND SBNTRA.HINCD = '" & CF_Ora_String(strHINCD, 8) & "'"
		End If
		If Trim(strTOKCD) <> "" Then
			strSQL = strSQL & "  AND SBNTRA.TOKCD = '" & CF_Ora_String(strTOKCD, 10) & "'"
		End If
		If Trim(strNHSCD) <> "" Then
			strSQL = strSQL & "  AND SBNTRA.NHSCD = '" & CF_Ora_String(strNHSCD, 10) & "'"
		End If
		If Trim(strSBNNO) <> "" Then
			'CHG START FKS)INABA 2007/02/03***********************************************************
			strSQL = strSQL & "  AND SBNTRA.SBNNO LIKE '" & Trim(CF_Ora_String(strSBNNO, 20)) & "%'"
			'        strSQL = strSQL & "  AND SBNTRA.SBNNO = '" & CF_Ora_String(strSBNNO, 20) & "'"
			'CHG  END  FKS)INABA 2007/02/03***********************************************************
		End If
		
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "  SBNTRA_OUTYTDT"
		'ADD START FKS)INABA 2006/11/27 ****************************************************
		strSQL = strSQL & ", SBNTRA_SBNNO" '製番
		strSQL = strSQL & ", SBNTRA_HINCD" '製品コード
		'ADD  END  FKS)INABA 2006/11/27 ****************************************************
		
		If Dyn_Open = True Then
            'オープンしていたらクローズ
            '20190604 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190604 DEL START
            Dyn_Open = False
		End If

        'DBアクセス
        '20190604 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190604 CHG END

        Dyn_Open = True

        '20190604 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190604 CHG END
            LST.Items.Clear()
            KEYBAK.Items.Clear()
        End If

        intRet = 0
		
F_Get_SBNTRA_End: 
		
		F_Get_SBNTRA = intRet
		Exit Function
		
F_Get_SBNTRA_Err: 
		
		intRet = 99
		GoTo F_Get_SBNTRA_End
		
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