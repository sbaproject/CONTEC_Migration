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
    Private Const FM_PANEL3D1_CNT As Short = 5 'パネルコントロール数

    '2019/06/25 ADD START
    Public D0 As ClsComn
    '2019/06/25 ADD END

    'カレンダ表示モード
    '基準日
    Private Const mc_strCalMode_INPDATEF As String = "1"
    Private Const mc_strCalMode_INPDATET As String = "2"

    'HD_Cursol_WkのGFで印刷処理を実行するかどうか
    Private mv_bolTNAPR81_GF_Flg As Boolean

    '20190625 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '20190625 ADD END

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
            .Dsp_Ctg = DSP_CTG_REFERENCE '画面分類
            .Item_Cnt = 40 '画面項目数
            .Dsp_Body_Cnt = 0 '画面表示明細数（０：明細なし、１～：表示時明細数）
            .Max_Body_Cnt = 0 '最大表示明細数（０：明細なし、１～：最大明細数）
            .Body_Col_Cnt = 0 '明細の列項目数
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '印刷
        MN_LSTART.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_LSTART
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '画面表示
        MN_VSTART.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_VSTART
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        'ファイル出力
        MN_FSTART.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_FSTART
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '印刷設定
        MN_LCONFIG.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_LCONFIG
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '画面初期化
        '20190625 CHG START
        '      MN_APPENDC.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        '20190625 CHG END
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '終了イメージ
        '20190625 CHG START
        '      CM_EndCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190625 CHG END
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
        Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '印刷イメージ
        CM_LSTART.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LSTART
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_LSTART_Inf.Click_Off_Img = IM_LSTART(0)
        Main_Inf.IM_LSTART_Inf.Click_On_Img = IM_LSTART(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '画面表示イメージ
        CM_VSTART.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_VSTART
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_VSTART_Inf.Click_Off_Img = IM_VSTART(0)
        Main_Inf.IM_VSTART_Inf.Click_On_Img = IM_VSTART(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '印刷設定イメージ
        CM_LCONFIG.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LCONFIG
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== ｲﾒｰｼﾞ設定 ======================
        Main_Inf.IM_LCONFIG_Inf.Click_Off_Img = IM_LCONFIG(0)
        Main_Inf.IM_LCONFIG_Inf.Click_On_Img = IM_LCONFIG(1)
        '=== ｲﾒｰｼﾞ設定 ======================

        Index_Wk = Index_Wk + 1
        '検索イメージ
        '20190625 CHG START
        '      CM_SLIST.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
        btnF5.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF5
        '20190625 CHG END
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '担当者ｺｰﾄﾞ
        HD_SOUCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUCD
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
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
        '入力担当者(名称)
        HD_SOUNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUNM
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
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
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
        'ﾁｪｯｸﾎﾞｯｸｽﾌｫｰｶｽ退避用２
        HD_Cursol_Wk2.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_Cursol_Wk2
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        'ﾁｪｯｸﾎﾞｯｸｽﾌｫｰｶｽ退避用
        HD_Cursol_Wk.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_Cursol_Wk
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '画面基礎情報設定
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ

        '///////////////
        '// ボディ部編集
        '///////////////

        '///////////////
        '// フッタ部編集
        '///////////////

        Index_Wk = Index_Wk + 1
        'ゲージ
        'UPGRADE_WARNING: オブジェクト GAUGE.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        GAUGE.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = GAUGE
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

        Index_Wk = Index_Wk + 1
        '中止ボタン
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CM_LCANCEL.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LCANCEL
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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Ctl.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/26 CHG START
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Locked = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Enabled = False
        '2019/06/26 CHG END

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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
            'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
            'UPGRADE_WARNING: オブジェクト Main_Inf.Dsp_Sub_Inf().Detail.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
        '初期状態で中止ボタンは使用不可
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CM_LCANCEL.Enabled = False

        'ロストフォーカスフラグ初期化
        gv_bolTNAPR81_LF_Enable = True

        '印刷処理フラグ初期化
        mv_bolTNAPR81_GF_Flg = True

        '印刷中フラグ初期化
        gv_bolNowPrinting = False
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
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
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

        'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

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
                'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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

        'KEYLEFT制御(ﾌｫｰｶｽ移動なし)
        Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

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
                'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
                Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
                Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

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

        If gv_bolTNAPR81_LF_Enable = False Then
            Exit Function
        End If
        'ﾛｽﾄﾌｫｰｶｽ実行判定
        If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
            Main_Inf.Dsp_Base.LostFocus_Flg = False
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
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

            '@'        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
            '@'        '選択状態の設定
            '@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
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
            Case CShort(HD_Cursol_Wk.Tag)

                On Error Resume Next

                '帳票出力処理
                Call HD_SOUCD.Focus()
                If mv_bolTNAPR81_GF_Flg Then

                    Call PrintTNAPR81_Main(Main_Inf, -1)
                    'キーフラグを元に戻す
                    gv_bolKeyFlg = False
                End If
                mv_bolTNAPR81_GF_Flg = False

            Case CShort(HD_Cursol_Wk2.Tag)
                'ﾁｪｯｸﾎﾞｯｸｽの後の項目にﾌｫｰｶｽを受け取った場合

                If Trg_Index > Main_Inf.Dsp_Base.Cursor_Idx Then
                    '次のﾌｫｰｶｽに移動
                    Call F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, Main_Inf)
                Else
                    '前ﾌｫｰｶｽ位置へ移動
                    Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
                End If

            Case Else
                If Trg_Index = CShort(HD_SOUCD.Tag) Then
                    mv_bolTNAPR81_GF_Flg = True
                End If

                '共通ﾌｫｰｶｽ取得処理
                Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
        '2019/06/25  ADD START
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '2019/06/25 ADD END
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
                '            '項目色設定
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

                '2019/06/25 CHG START
                'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '2019/06/25 CHG END
                'パネルの場合
                Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                'イメージの場合
                Select Case Trg_Index
                    Case CShort(CM_EndCm.Tag)
                        '終了ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                    Case CShort(CM_LSTART.Tag)
                        '印刷ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LSTART_Inf, False, Main_Inf)
                    Case CShort(CM_VSTART.Tag)
                        '画面表示ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_VSTART_Inf, False, Main_Inf)
                    Case CShort(CM_LCONFIG.Tag)
                        '印刷設定ｲﾒｰｼﾞ
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, False, Main_Inf)
                    Case CShort(CM_SLIST.Tag)
                        '検索ｲﾒｰｼﾞ
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
                '20190626 CHG START
                'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190626 CHG END

                '終了ｲﾒｰｼﾞ
                Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_LSTART.Tag)
                '印刷ｲﾒｰｼﾞ
                Call CF_Set_Prompt(IMG_LSTART_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_VSTART.Tag)
                '画面表示ｲﾒｰｼﾞ
                Call CF_Set_Prompt(IMG_VSTART_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_LCONFIG.Tag)
                '印刷設定ｲﾒｰｼﾞ
                Call CF_Set_Prompt(IMG_LCONFIG_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
                '20190626 CHG START
                'Case CShort(CM_SLIST.Tag)
            Case CShort(btnF5.Tag)
                '20190626 CHG END

                '検索ｲﾒｰｼﾞ
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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = Val(Me.ActiveControl.Tag)

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)

        Select Case Trg_Index

            '20190626 CHG START
            'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190626 CHG END

                '終了ｲﾒｰｼﾞ
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

            Case CShort(CM_LSTART.Tag)
                '帳票印刷ｲﾒｰｼﾞ
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LSTART_Inf, True, Main_Inf)

            Case CShort(CM_VSTART.Tag)
                '帳票表示ｲﾒｰｼﾞ
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_VSTART_Inf, True, Main_Inf)

            Case CShort(CM_LCONFIG.Tag)
                '印刷設定ｲﾒｰｼﾞ
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, True, Main_Inf)

            '20190626 CHG START
                'Case CShort(CM_SLIST.Tag)
            Case CShort(btnF5.Tag)
                '20190626 CHG END

                '検索ｲﾒｰｼﾞ
                Select Case Main_Inf.Dsp_Sub_Inf(Act_Index).Ctl.Name
                    Case Me.HD_SOUCD.Name
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
                    Case Else
                End Select

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = Val(pm_Ctl.Tag)

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = Val(Me.ActiveControl.Tag)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '各検索画面呼出
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case Trg_Index
            Case CShort(CM_LCANCEL.Tag)
                '中止
                Call Ctl_CM_LCancel_Click()
                'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

            Case CShort(MN_Ctrl.Tag)
                '処理１
                Call Ctl_MN_Ctrl_Click()

            Case CShort(MN_LSTART.Tag), CShort(CM_LSTART.Tag)
                '印刷
                Call Ctl_MN_LSTART_Click()

            Case CShort(MN_VSTART.Tag), CShort(CM_VSTART.Tag)
                '画面表示
                Call Ctl_MN_VSTART_Click()

            Case CShort(MN_FSTART.Tag)
                'ファイル出力
                Call Ctl_MN_FSTART_Click()

            Case CShort(MN_LCONFIG.Tag), CShort(CM_LCONFIG.Tag)
                '印刷設定
                Call Ctl_MN_LCONFIG_Click()

            '20190625 CHG START
                'Case CShort(MN_EndCm.Tag), CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190625 CHG END

                '終了
                Call Ctl_MN_EndCm_Click()

            Case CShort(MN_EditMn.Tag)
                '処理２
                Call Ctl_MN_EditMn_Click()

            '20190625 CHG START
                'Case CShort(MN_APPENDC.Tag)
            Case CShort(btnF9.Tag)
                '20190625 CHG END

                '画面初期化
                Call Ctl_MN_APPENDC_Click()

            Case CShort(MN_ClearItm.Tag)
                '項目初期化
                Call Ctl_MN_ClearItm_Click()

            Case CShort(MN_UnDoItem.Tag)
                '項目復元
                Call Ctl_MN_UnDoItem_Click()

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

            '20190625 CHG START
                'Case CShort(MN_Slist.Tag), CShort(CM_SLIST.Tag)
            Case CShort(btnF5.Tag)
                '20190625 CHG END

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
        gv_bolKeyFlg = False
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

        Dim Trg_Index As Short
        Dim Act_Index As Short

        If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
            Main_Inf.Dsp_Base.VS_Scr_Flg = False
            Exit Function
        End If

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Ctl.Tag)
        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '共通VS_SCRL_CHANGE制御
        Call CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        '「印刷」判定
        MN_LSTART.Enabled = CF_Jge_Enabled_MN_LStart(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        '「画面表示」判定
        MN_VSTART.Enabled = CF_Jge_Enabled_MN_VStart(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        '「印刷設定」判定
        MN_LCONFIG.Enabled = CF_Jge_Enabled_MN_LConfig(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        '｢終了｣判定
        MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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

        '｢画面初期化｣判定
        MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢項目初期化｣判定
        MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢項目復元｣判定
        MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢明細行初期化｣判定
        '    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢明細行削除｣判定
        '    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢明細行挿入｣判定
        '    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '｢明細行復元｣判定
        '    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
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
    '   名称：  Function Ctl_MN_Oprt_Click
    '   概要：  メニュー処理３の使用可不可を制御
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

        '｢候補の一覧｣判定
        MN_Slist.Enabled = CF_Jge_Enabled_MN_SList(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'ｱｸﾃｨﾌﾞな項目の検索機能がない場合、使用不可
        'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Select Case Me.ActiveControl.Name
            Case HD_SOUCD.Text
                MN_Slist.Enabled = False
            Case Else
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

        '画面内容初期化
        Call F_Init_Clr_Dsp(-1, Main_Inf)

        '画面ボディ部初期化
        Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '初期表示編集
        Call Edi_Dsp_Def()

        '画面明細表示
        Call CF_Body_Dsp(Main_Inf)

        '初期ﾌｫｰｶｽ位置設定
        Call F_Init_Cursor_Set(Main_Inf)

        '入力担当者編集
        '2019/06/25 CHG START
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
        Call CF_Set_Frm_IN_TANCD_TNAPR81(Me, Main_Inf)
        '2019/06/25 CHG END
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
        Dim Trg_Index As Short
        Dim Wk_Row As Short
        Dim Wk_Index As Short

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '選択項目の初期化
        '画面内容初期化
        Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

        'UPGRADE_ISSUE: Control NAME は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Select Case Me.ActiveControl.Name
            Case Else
        End Select
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

        '共通ﾌｫｰｶｽ取得処理
        Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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
        Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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
            '担当者コード
            Case CShort(Me.HD_SOUCD.Tag)
                Call SListOpen_SOUCD(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
                '
            Case Else
        End Select

        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SListOpen_SOUCD
    '   概要：  担当者コード検索画面表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub SListOpen_SOUCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All)

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        '担当者コード検索
        Trg_Index = CShort(Me.HD_SOUCD.Tag)
        WLSTAN_TANCLAKB = gc_strTANCLKB_EIGYO

        Next_Focus = Trg_Index + 1

        'ﾌｫｰｶｽを担当者コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolTNAPR81_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '担当者検索画面を呼び出す
            WLSSOU.ShowDialog()
            WLSSOU.Close()

            gv_bolTNAPR81_LF_Enable = True

            If WLSSOU_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSSOU_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

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
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    'ﾁｪｯｸ後移動なし
                    Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
                End If
            End If
        End If

    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UnDoDe_Click
    '   概要：  明細行復元
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_UnDoDe_Click() As Short
        '    Dim Act_Index   As Integer
        '
        '    '割当ｲﾝﾃﾞｯｸｽ取得
        '    Act_Index = CInt(Me.ActiveControl.Tag)
        '
        '    '該当行の復元処理
        '    Call CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '
        ''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        ''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '割当ｲﾝﾃﾞｯｸｽ取得
        'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        Act_Index = CShort(Me.ActiveControl.Tag)

        '該当項目の貼り付け
        '注）メニューの画面｢貼り付け｣と同一関数を使用！！
        Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_LSTART_Click
    '   概要：  帳票印刷
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_LSTART_Click() As Short
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

        '    If Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_OK Then
        '印刷処理
        Call PrintTNAPR81_Main(Main_Inf, SSS_PRINTER)
        '    End If

        'キーフラグを元に戻す
        gv_bolKeyFlg = False
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_VSTART_Click
    '   概要：  帳票画面表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_VSTART_Click() As Short
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        Call PrintTNAPR81_Main(Main_Inf, SSS_VIEW)
        'キーフラグを元に戻す
        gv_bolKeyFlg = False
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_FSTART_Click
    '   概要：  帳票ファイル出力
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_FSTART_Click() As Short
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        Call PrintTNAPR81_Main(Main_Inf, SSS_FILE)
        'キーフラグを元に戻す
        gv_bolKeyFlg = False
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_LCONFIG_Click
    '   概要：  印刷設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_LCONFIG_Click() As Short
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        WLS_PRN.ShowDialog()
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearDE_Click
    '   概要：  明細行初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_ClearDE_Click() As Short
        '
        '    Dim Act_Index   As Integer
        '
        '    '割当ｲﾝﾃﾞｯｸｽ取得
        '    Act_Index = CInt(Me.ActiveControl.Tag)
        '
        '    '該当行の初期化処理
        '    Call CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '
        ''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        ''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
        'UPGRADE_WARNING: オブジェクト SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Index_Wk = CShort(SYSDT.Tag)
        '画面日付
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        Call SSSMAIN0001.ShowGauge(False)
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

        Dim Bd_Index As Short

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CM_LCancel_Click
    '   概要：  中止ボタンクリック
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CM_LCancel_Click() As Short

        SSS_LSTOP = True

        Ctl_CM_LCancel_Click = 0
    End Function

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        '印刷中なら終了しない
        If gv_bolNowPrinting Then
            Cancel = MsgBoxResult.Cancel
            '20190626 ADD START
            eventArgs.Cancel = Cancel
            '20190626 ADD END
            Exit Sub
        End If

        '終了メッセージの出力
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTNAPR81_I_002, Main_Inf) = MsgBoxResult.No Then
            Cancel = MsgBoxResult.Cancel
            '20190626 ADD START
            eventArgs.Cancel = Cancel
            '20190626 ADD END
            Exit Sub
        End If

        Main_Inf.Dsp_Base.IsUnload = True

        'DB切断
        '2019/06/25 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        'Call CF_Ora_DisConnect(gv_Oss_USR9, gv_Odb_USR9)
        Call DB_CLOSE(CON)
        Call DB_CLOSE(CON_USR9)
        '2019/06/25 CHG END

        Call SSSWIN_LOGWRT("プログラム終了")

        eventArgs.Cancel = Cancel
    End Sub






















    'UPGRADE_WARNING: イベント HD_SOUCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub HD_SOUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.TextChanged
        Debug.Print("HD_SOUCD_Change")
        Call Ctl_Item_Change(HD_SOUCD)
    End Sub

    Private Sub HD_SOUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Enter
        Debug.Print("HD_SOUCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_SOUCD)
    End Sub


    Private Sub HD_SOUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_SOUCD, KEYCODE, Shift)
    End Sub

    Private Sub HD_SOUCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SOUCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_SOUCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_SOUCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub HD_SOUCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_SOUCD)
    End Sub


    Private Sub HD_SOUCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Leave
        Debug.Print("HD_SOUCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_SOUCD)
    End Sub


    Private Sub HD_SOUCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_SOUCD, Button, Shift, X, Y)
    End Sub


    Private Sub HD_SOUCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_SOUCD, Button, Shift, X, Y)
    End Sub


    Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
        '一度きりのため使用不可
        Main_Inf.TM_StartUp_Ctl.Enabled = False
        '初期ﾌｫｰｶｽ位置設定
        Call F_Init_Cursor_Set(Main_Inf)
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'DB接続
        Call CF_Ora_USR1_Open() 'USR1
        Call CF_Ora_USR9_Open() 'USR9

        '共通初期化処理
        Call CF_Init()

        '前回締処理実行日の取得
        gv_strInitYM = F_Get_InitYM()

        '画面情報設定
        Call Init_Def_Dsp()

        '画面内容初期化
        Call F_Init_Clr_Dsp(-1, Main_Inf)

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

        'システム共通処理
        Call CF_System_Process(Me)

        '画面表示位置設定
        Call CF_Set_Frm_Location(Me)

        '入力担当者編集
        '2019/06/26 CHG START
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
        Call CF_Set_Frm_IN_TANCD_TNAPR81(Me, Main_Inf)
        SetBar(Me)
        '2019/06/26 CHG END
    End Sub

    '20190625 ADD START
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
    '20190625 ADD END

    Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
        Debug.Print("CM_EndCm_Click")
        Call Ctl_Item_Click(CM_EndCm)
    End Sub

    Private Sub CM_LCANCEL_Click()
        Debug.Print("CM_LCANCEL_Click")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_Click(CM_LCANCEL)
    End Sub

    Private Sub CM_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_LCONFIG.Click
        Debug.Print("CM_LCONFIG_Click")
        Call Ctl_Item_Click(CM_LCONFIG)
    End Sub

    Private Sub CM_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_LSTART.Click
        Debug.Print("CM_LSTART_Click")
        Call Ctl_Item_Click(CM_LSTART)
    End Sub

    Private Sub CM_SLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click
        Debug.Print("CM_SLIST_Click")
        Call Ctl_Item_Click(CM_SLIST)
    End Sub

    Private Sub CM_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_VSTART.Click
        Debug.Print("CM_VSTART_Click")
        Call Ctl_Item_Click(CM_VSTART)
    End Sub

    Private Sub CS_ENDDENDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CS_ENDDENDT.Click
        Debug.Print("CS_ENDDENDT_Click")
        Call Ctl_Item_Click(CS_ENDDENDT)
    End Sub

    Private Sub CS_STTDENDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CS_STTDENDT.Click
        Debug.Print("CS_STTDENDT_Click")
        Call Ctl_Item_Click(CS_STTDENDT)
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

    Public Sub MN_FSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_FSTART.Click
        Debug.Print("MN_FSTART_Click")
        Call Ctl_Item_Click(MN_FSTART)
    End Sub

    Public Sub MN_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_LCONFIG.Click
        Debug.Print("MN_LCONFIG_Click")
        Call Ctl_Item_Click(MN_LCONFIG)
    End Sub

    Public Sub MN_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_LSTART.Click
        Debug.Print("MN_LSTART_Click")
        Call Ctl_Item_Click(MN_LSTART)
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

    Public Sub MN_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_VSTART.Click
        Debug.Print("MN_VSTART_Click")
        Call Ctl_Item_Click(MN_VSTART)
    End Sub

    Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseDown")
        Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCANCEL_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CM_LCANCEL_MouseDown")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseDown(CM_LCANCEL, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCONFIG_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LCONFIG_MouseDown")
        Call Ctl_Item_MouseDown(CM_LCONFIG, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LSTART.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LSTART_MouseDown")
        Call Ctl_Item_MouseDown(CM_LSTART, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseDown")
        Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_VSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_VSTART.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_VSTART_MouseDown")
        Call Ctl_Item_MouseDown(CM_VSTART, Button, Shift, X, Y)
    End Sub

    Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseMove")
        Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCANCEL_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CM_LCANCEL_MouseMove")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseMove(CM_LCANCEL, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCONFIG_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LCONFIG_MouseMove")
        Call Ctl_Item_MouseMove(CM_LCONFIG, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LSTART.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LSTART_MouseMove")
        Call Ctl_Item_MouseMove(CM_LSTART, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseMove")
        Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_VSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_VSTART.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_VSTART_MouseMove")
        Call Ctl_Item_MouseMove(CM_VSTART, Button, Shift, X, Y)
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

    Private Sub CM_LCANCEL_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CM_LCANCEL_MouseUp")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(CM_LCANCEL, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCONFIG_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LCONFIG_MouseUp")
        Call Ctl_Item_MouseUp(CM_LCONFIG, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LSTART.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_LSTART_MouseUp")
        Call Ctl_Item_MouseUp(CM_LSTART, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseUp")
        Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_VSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_VSTART.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_VSTART_MouseUp")
        Call Ctl_Item_MouseUp(CM_VSTART, Button, Shift, X, Y)
    End Sub

    Private Sub CM_LCANCEL_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CM_LCANCEL_KeyDown")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_KeyDown(CM_LCANCEL, KEYCODE, Shift)
    End Sub

    Private Sub CM_LCANCEL_KeyPress(ByRef KeyAscii As Short)
        Debug.Print("CM_LCANCEL_KeyPress")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_KeyPress(CM_LCANCEL, KeyAscii)
    End Sub


    Private Sub CM_LCANCEL_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CM_LCANCEL_KeyUp")
        'UPGRADE_WARNING: オブジェクト CM_LCANCEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_KeyUp(CM_LCANCEL)
    End Sub

    Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANCD)
    End Sub






    Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
        Debug.Print("HD_IN_TANCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
        Debug.Print("HD_IN_TANCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
        Debug.Print("HD_IN_TANNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
        Debug.Print("HD_IN_TANNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANNM)
    End Sub

    Private Sub TX_Message_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Click
        Debug.Print("TX_Message_Click")
        Call Ctl_Item_Click(TX_Message)
    End Sub

    Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Message_MouseDown")
        Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
        Debug.Print("TX_Message_GotFocus")
        Call Ctl_Item_GotFocus(TX_Message)
    End Sub

    Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
        Debug.Print("TX_Message_LostFocus")
        Call Ctl_Item_LostFocus(TX_Message)
    End Sub

    Private Sub TX_Mode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Mode.Click
        Debug.Print("TX_Mode_Click")
        Call Ctl_Item_Click(TX_Mode)
    End Sub

    Private Sub TX_Mode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Mode.Enter
        Debug.Print("TX_Mode_GotFocus")
        Call Ctl_Item_GotFocus(TX_Mode)
    End Sub

    Private Sub TX_Mode_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Mode.Leave
        Debug.Print("TX_Mode_LostFocus")
        Call Ctl_Item_LostFocus(TX_Mode)
    End Sub

    Private Sub HD_Cursol_Wk_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_Cursol_Wk.Enter
        Debug.Print("HD_Cursol_Wk_GotFocus")
        Call Ctl_Item_GotFocus(HD_Cursol_Wk)
    End Sub

    Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("FM_Panel3D1_MouseUp")
        'UPGRADE_WARNING: オブジェクト FM_Panel3D1() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
    End Sub

    Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseUp")
        'UPGRADE_WARNING: オブジェクト SYSDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    End Sub

    Private Sub HD_Cursol_Wk2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_Cursol_Wk2.Enter
        Debug.Print("HD_Cursol_Wk2_GotFocus")
        Call Ctl_Item_GotFocus(HD_Cursol_Wk2)
    End Sub

    Private Sub HD_Cursol_Wk_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_Cursol_Wk.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_Cursol_Wk_MouseDown")
        Call Ctl_Item_MouseDown(HD_Cursol_Wk, Button, Shift, X, Y)
    End Sub

    Private Sub HD_Cursol_Wk2_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_Cursol_Wk2.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_Cursol_Wk2_MouseDown")
        Call Ctl_Item_MouseDown(HD_Cursol_Wk2, Button, Shift, X, Y)
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



    Private Sub HD_Cursol_Wk_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_Cursol_Wk.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_Cursol_Wk_MouseUp")
        Call Ctl_Item_MouseUp(HD_Cursol_Wk, Button, Shift, X, Y)
    End Sub

    Private Sub HD_Cursol_Wk2_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_Cursol_Wk2.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_Cursol_Wk2_MouseUp")
        Call Ctl_Item_MouseUp(HD_Cursol_Wk2, Button, Shift, X, Y)
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

    '2019/06/25 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_IN_TANCD_TNAPR81
    '   概要：  入力担当者編集
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD_TNAPR81(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '入力担当者コード
            'UPGRADE_ISSUE: Control HD_IN_TANCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '入力担当者名
            'UPGRADE_ISSUE: Control HD_IN_TANNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '2019/06/25 ADD END

    '20190625 ADD START
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Call Ctl_Item_Click(btnF1)
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Call Ctl_Item_Click(btnF2)
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Call Ctl_Item_Click(btnF3)
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Call Ctl_Item_Click(btnF4)
    End Sub

    Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
        Call Ctl_Item_Click(btnF5)
    End Sub

    Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
        Call Ctl_Item_Click(btnF6)
    End Sub

    Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
        Call Ctl_Item_Click(btnF7)
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        Call Ctl_Item_Click(btnF10)
    End Sub

    Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
        Call Ctl_Item_Click(btnF11)
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub
    '20190625 ADD END

End Class