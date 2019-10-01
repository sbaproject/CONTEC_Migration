Attribute VB_Name = "SSSMAIN0001"
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
'
'単プロジェクトごとの共通ライブラリ
Public PP_SSSMAIN As clsPP
Public CP_SSSMAIN(6 + 0 + 0 + 1) As clsCP
Public CQ_SSSMAIN(6) As String

'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
'初期処理時チェック実行フラグ
Public gv_bolInit                   As Boolean      '初期処理時はTrue(チェックなし）　それ以外はFalse
'画面初期化フラグ
Public gv_bolTNAPR82_INIT           As Boolean              'True:変更あり
Public gv_bolTNAPR82_LF_Enable      As Boolean              'LF処理実行フラグ(True：実行する）
Public gv_bolKeyFlg                 As Boolean
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
Public Type TNAPR82_TYPE_INPUT
    TEISYOYM            As String
    SOUBSCD             As String
    SOUBSNM             As String
    SOUCD               As String           '倉庫ｺｰﾄﾞ
    SOUNM               As String           '倉庫名
End Type
'画面情報
Public TNAPR82_InputData    As TNAPR82_TYPE_INPUT

'**********Private定数**********

'出力帳票ＩＤ
Private Const mc_strLIST_ID         As String = "TNAPR82"
'印刷中フラグ
Public gv_bolNowPrinting            As Boolean

'前回締処理実行日の翌月
Public gv_strInitYM                 As String
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

''**ﾁｪｯｸ関数関連 Start **
'//戻値
Public Const CHK_OK                 As Integer = 0              '正常
Public Const CHK_WARN               As Integer = 1              '警告
Public Const CHK_ERR_NOT_INPUT      As Integer = 10             '未入力エラー
Public Const CHK_ERR_ELSE           As Integer = 11             'その他エラー

'F_Chk_Jge_Action関数用
Public Const CHK_KEEP              As Integer = 0              'チェック続行
Public Const CHK_STOP              As Integer = 1              'チェック中断

'**ﾁｪｯｸ関数関連 End  **

'//F_Set_Next_Focus処理モード
Public Const NEXT_FOCUS_MODE_KEYRETURN     As Integer = 1      'KEYRETURNと同様の制御
Public Const NEXT_FOCUS_MODE_KEYRIGHT      As Integer = 2      'KEYRIGHTと同様の制御
Public Const NEXT_FOCUS_MODE_KEYDOWN       As Integer = 3      'KEYDOWNと同様の制御
'//F_Dsp_Item_Detail処理モード
Public Const DSP_SET                As Integer = 0              '表示
Public Const DSP_CLR                As Integer = 1              'クリア

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_SOUCD
    '   概要：  倉庫コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_SOUCD(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Mst_Inf             As TYPE_DB_SOUMTA
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String

    'チェック実行判定
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '中断の場合
        F_Chk_HD_SOUCD = Retn_Code
        Exit Function
    End If

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '初期化
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True
    Call DB_SOUMTA_Clear(Mst_Inf)

    '未入力チェック
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
'        Retn_Code = CHK_ERR_NOT_INPUT
        TNAPR82_InputData.SOUCD = ""
        TNAPR82_InputData.SOUNM = ""
    Else
        '未入力以外のチェック済
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '基礎チェック
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_005              '入力範囲外
        Else
            'マスタチェック
            If DSPSOUCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                '論理削除チェック
                If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgTNAPR82_E_015       '削除済みデータ
                Else
                    If Trim$(TNAPR82_InputData.SOUBSCD) <> "" And _
                        Trim$(TNAPR82_InputData.SOUBSCD) <> Trim$(Mst_Inf.SOUBSCD) Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgTNAPR82_E_016  '●場所ｺｰﾄﾞと倉庫ｺｰﾄﾞの関係が不正です。
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True
        
                        '取得項目格納
                        TNAPR82_InputData.SOUCD = Trim(Mst_Inf.SOUCD)
                        TNAPR82_InputData.SOUNM = Trim(Mst_Inf.SOUNM)
                    End If
                End If
            Else
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgTNAPR82_E_006          '該当データなし
            End If
        End If
        
    End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '戻値、メッセージ、ステータス、移動制御
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        'メッセージ出力
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_SOUCD = Retn_Code

End Function
    

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_SOUBSCD
    '   概要：  場所コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_SOUBSCD(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Mst_Inf             As TYPE_DB_MEIMTA
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String
    
    'チェック実行判定
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '中断の場合
        F_Chk_HD_SOUBSCD = Retn_Code
        Exit Function
    End If

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '初期化
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True
    Call DB_MEIMTA_Clear(Mst_Inf)

    '未入力チェック
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
'        Retn_Code = CHK_ERR_NOT_INPUT
        TNAPR82_InputData.SOUBSCD = ""
        TNAPR82_InputData.SOUBSNM = ""
    Else
        '未入力以外のチェック済
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '基礎チェック
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_005              '入力範囲外
        Else
            'マスタチェック
            If DSPMEIM_SEARCH("015", Input_Value, Mst_Inf) = 0 Then
                    'ＯＫ
                    Retn_Code = CHK_OK
                    pm_Chk_Move = True
    
                    '取得項目格納
                    TNAPR82_InputData.SOUBSCD = Trim(Mst_Inf.MEICDA)
                    TNAPR82_InputData.SOUBSNM = Trim(Mst_Inf.MEINMA)
'                End If
            Else
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgTNAPR82_E_006          '該当データなし
            End If
        End If
        
    End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '戻値、メッセージ、ステータス、移動制御
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        'メッセージ出力
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_SOUBSCD = Retn_Code

End Function
    


   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  対象項目のCHANGEの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_Change(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Wk_CurMoji          As String
    Dim Wk_Cnt              As Integer
    Dim Wk_EditMoji         As String
    Dim Wk_DspMoji          As String
    Dim Move_Flg            As Boolean
    
    Select Case True
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
        'ﾃｷｽﾄﾎﾞｯｸｽの場合
            '現在のﾃｷｽﾄ上の選択状態を取得
            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            
            '現在の値を取得
            Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
            
            Wk_EditMoji = ""
            
            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                Case IN_TYP_NUM
                '数値項目の場合
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                Case IN_TYP_DATE
                '日付項目の場合
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                Case IN_TYP_CODE, IN_TYP_STR
                'コード、文字項目
                    Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
                    '変更後の値変換
                    Case IN_STR_TYP_N
                        '全角の場合
                            '半角空白⇒全角空白
                            For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
                                    Wk_EditMoji = Wk_EditMoji & "　"
                                Else
                                    Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                End If
                            Next
                            
                    Case Else
                        '全角以外
                            '半角空白⇒全角空白
                            For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
                                    Wk_EditMoji = Wk_EditMoji & Space(2)
                                Else
                                    Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                End If
                            Next
                
                    End Select
                Case IN_TYP_YYYYMM
                '年月項目の場合
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                
                Case IN_TYP_HHMM
                '時刻項目の場合
                    Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                
                Case Else
            End Select
            
            '編集後の文字を表示形式に変換
            Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
        
            '選択文字と入力文字の置き換え
            '文字設定
            Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
            
            '現在ﾌｫｰｶｽ位置から右へ移動
            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
        
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
    
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
    
        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
    
    End Select

    '入力後処理
    Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    
    '明細入力後の後処理
    Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

End Function

   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Item_GotFocus
    '   概要：  対象項目のGOTFOCUSの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_GotFocus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Move_Flg As Boolean
    
    If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
    'ﾌｫｰｶｽを受け取れない場合
        '元の項目へﾌｫｰｶｽ移動
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
    Else
        
        '移動前と異なる場合のみ退避
        If pm_All.Dsp_Base.Cursor_Idx <> CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
            '前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
            pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
            '移動後のｲﾝﾃﾞｯｸｽを退避
            pm_All.Dsp_Base.Cursor_Idx = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)
        End If
        
        '選択状態の設定（初期選択）
        Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
        '項目色設定
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
    End If

End Function

   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyPress
    '   概要：  対象項目のKEYPRESSの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_KeyPress(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                   , ByRef pm_KeyAscii As Integer _
                                   , ByRef pm_Move_Flg As Boolean _
                                   , pm_All As Cls_All _
                                   , pm_Run_Flg As Boolean) As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim All_Sel_Flg         As Boolean
    Dim wk_Moji             As String
    Dim Wk_SelMoji          As String
    Dim Wk_BefMoji          As String
    Dim Wk_DelMoji          As String
    Dim Wk_EditMoji         As String
    Dim Wk_DspMoji          As String
    Dim Wk_Cnt              As Integer
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer
    Dim Wk_CurMoji          As String
    Dim Input_Flg           As Boolean
    Dim Re_Body_Crt         As Boolean
    
    '移動フラグ初期化
    pm_Move_Flg = False
    
    '入力フラグ初期化
    Input_Flg = False
    '明細部再作成フラグ初期化
    Re_Body_Crt = False
    
    '以下の入力の場合、無視する
    Select Case pm_KeyAscii
        Case 1 To 7, 9 To 12, 14 To 29, 127
            Beep
            pm_KeyAscii = 0
            Exit Function
    End Select
    
    '入力文字取得
    wk_Moji = Chr$(pm_KeyAscii)
    
    'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        
        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
        
        '現在の値を取得
        Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
        
        All_Sel_Flg = False
        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '全選択の場合（選択文字が最大バイト数と一致）
            All_Sel_Flg = True
            If Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB _
            And pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB = 1 Then
                All_Sel_Flg = False
            End If
        End If
        
        '入力コード判定
        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
        '入力可能文字の場合
            
           '入力可能な文字の場合、入力後処理、明細部再作成を行う
            Input_Flg = True
            Re_Body_Crt = True
            
            'CF_Jge_Input_Str関数の文字変更を考慮
            pm_KeyAscii = Asc(wk_Moji)
            
            '日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
            '表示形式が決まっているため一つずつ入力させる
            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                    If Act_SelLength <> 1 Then
                        Beep
                        pm_KeyAscii = 0
                        Exit Function
                    End If
            End Select
            
            If All_Sel_Flg = True Then
            '全選択時
                
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
                                      
                Else
                    '詰文字が左詰以外の場合
                    Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                
                End If
                
                '編集後の文字を表示形式に変換
                Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                
                '編集後のSelStartを決定
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '右端へ移動
                    Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                    Wk_SelLength = 0
                Else
                    '詰文字が左詰以外の場合
                    Wk_SelStart = 0
                    Wk_SelLength = 1
                End If
                
                '削除後の文字置き換え
                '文字設定
                Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                pm_KeyAscii = 0
    
                '編集後のSelStartを決定
                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                '編集後のSelLengthを決定
                pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                
            Else
            '部分選択もしくは、選択なし
                
                If Act_SelLength = 0 Then
                '選択なしの場合(挿入状態)
                    '挿入部分の前の文字を取得
                    Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        Select Case wk_Moji
                            Case "+"
                                '｢＋｣入力時
                                If Trim(Wk_BefMoji) <> "" Then
                                '前文字が上記の文字以外は挿入できない
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                                
                            Case "-"
                                '｢－｣入力時
                                If Trim(Wk_BefMoji) <> "" Then
                                '前文字が上記の文字以外は挿入できない
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                    
                            Case "."
                                '｢．｣入力時
                                If InStr(Wk_CurMoji, ".") > 1 Then
                                'すでに｢．｣が入力されいる場合
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                        End Select
                    End If

                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                    '空白除去後の現在の文字がMAXの場合、オーバーフロー

                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '一番右でオーバーフローした場合、次の項目へ
                            If Act_SelStart >= Len(Wk_CurMoji) Then
                            '編集前の開始位置が一番右の場合
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            Else
                                '入力不可
                                Beep
                            End If
                        Else
                            
                            '編集後の移動先を判定
                            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                                '詰文字が左詰の場合
                            Else
                            '編集後のSelStartを決定
                                If Act_SelStart + 1 > Len(Wk_CurMoji) Then
                                '１つ右の位置が右端の場合
                                    Wk_SelStart = Len(Wk_CurMoji)
                                Else
                                '１つ右へ
                                    Wk_SelStart = Act_SelStart + 1
                                End If
                                '編集後のSelLengthを決定
                                Wk_SelLength = 0
                                
                                '編集後のSelStartを決定
                                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                '編集後のSelLengthを決定
                                pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            End If
                            
                            '入力不可
                            Beep
                        End If

                        '入力不可
                        pm_KeyAscii = 0
                        Exit Function
                    End If
                
                    '文字編集
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                                 & Chr$(pm_KeyAscii) _
                                 & Mid$(Wk_CurMoji, Act_SelStart + 1)
                
                    '編集後の文字を表示形式に変換
                    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        '整数部で整数桁数より多く入力されている場合
                        If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                            '入力不可
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                        
                        '小数部があり小数桁数と設定値が同じ場合
                        If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                        And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            '入力不可
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                    End If
                    
                    '編集後のSelStartを決定
                    If Act_SelStart + 1 > Len(Wk_DspMoji) Then
                    '１つ右の位置が右端の場合
                        Wk_SelStart = Len(Wk_DspMoji)
                    Else
                    '１つ右へ
                        Wk_SelStart = Act_SelStart + 1
                    End If
                    '編集後のSelLengthを決定
                    Wk_SelLength = 0
                    
                    '削除後の文字置き換え
                    '文字設定
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                    pm_KeyAscii = 0
        
                    '編集後のSelStartを決定
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    '編集後のSelLengthを決定
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    
                    '編集後の移動先を判定
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                        '詰文字が左詰の場合
                        
                        If Wk_SelStart >= Len(Wk_DspMoji) Then
                        '編集後の開始位置が一番右の場合
                            '数値項目特別処理
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                '小数部があり小数桁数と設定値が同じ場合
                                If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                                And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                Else
                                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                    '編集後の文字がMAXの場合
                                        '現在ﾌｫｰｶｽ位置から右へ移動
                                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                    End If
                                End If
                            Else
                            '数値項目以外
                                If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                End If
                            End If
                        End If
                    Else
                        '詰文字が左詰以外の場合
                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                        '編集後の文字がMAXの場合
                            
                            '編集後のSelStartを決定
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            '編集後のSelLengthを決定
                            pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                            
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
                    End If
                Else
                '一部選択
                    '現在選択されている文字の１桁を取得
                     Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
                
                    If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
                    '選択文字が空文字以外でかつ入力対象の文字以外の場合
                        
                        '入力不可
                        Beep
                        pm_KeyAscii = 0
                        Exit Function
                    End If
                    
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        Select Case wk_Moji
                            Case "+"
                                '｢＋｣入力時
                                If Wk_SelMoji <> "-" _
                                And Wk_SelMoji <> "." _
                                And Wk_SelMoji <> "%" _
                                And Trim(Wk_SelMoji) <> "" Then
                                '選択文字が上記の文字以外は置き換えられない
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                                
                            Case "-"
                                '｢－｣入力時
                                If Wk_SelMoji <> "+" _
                                And Wk_SelMoji <> "." _
                                And Wk_SelMoji <> "%" _
                                And Trim(Wk_SelMoji) <> "" Then
                                '選択文字が上記の文字以外は置き換えられない
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                    
                            Case "."
                                '｢．｣入力時
                                If InStr(Wk_CurMoji, ".") > 0 Then
                                'すでに｢．｣が入力されいる場合
                                    '入力不可
                                    Beep
                                    pm_KeyAscii = 0
                                    Exit Function
                                End If
                        End Select
                    End If
                     
                    '文字編集
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                                 & Chr$(pm_KeyAscii) _
                                 & Mid$(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
                    
                    '編集後の文字を表示形式に変換
                    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        '整数部無しの場合
                        '整数部ありで整数桁数より多く入力されている場合
                        If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                            '入力不可
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                        
                        '小数部があり小数桁数と設定値が同じ場合
                        If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                        And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            '入力不可
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                    End If
                    
                    If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
                    '編集前の開始位置が最後の文字以降の場合
                        '編集後のSelStartを決定
                        Wk_SelStart = Len(Wk_DspMoji)
                        '編集後のSelLengthを決定
                        Wk_SelLength = 0
                    Else
                        '編集後のSelStartを決定
                        Wk_SelStart = Act_SelStart
                        '編集後のSelLengthを決定
                        Wk_SelLength = 1
                    End If
                    
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
                        '入力可能な文字が１桁の場合
                            '開始位置を一番右に設定
                            '編集後のSelStartを決定
                            Wk_SelStart = Len(Wk_DspMoji)
                            '編集後のSelLengthを決定
                            Wk_SelLength = 0
                        End If
                    
                    End If
                    
                    '編集後の文字置き換え
                    '文字設定
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                    pm_KeyAscii = 0
        
                    '編集後のSelStartを決定
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    '編集後のSelLengthを決定
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    
                    '編集後の移動先を判定
                    If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
                    '編集後の開始位置が最後の文字以降の場合
                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                        
                            '小数部があり小数桁数と設定値が同じ場合
                            If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 _
                            And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            Else
                                If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                End If
                            End If
                        
                        Else
                        '数値項目以外
                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '編集後の文字がMAXの場合
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                        End If
                    Else
                        '現在ﾌｫｰｶｽ位置から右へ移動
                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                    End If
                
                End If
            End If
        
        Else
        '入力コード以外
            Select Case pm_KeyAscii
                Case vbKeyBack
                    'BackSpaceキー
                    pm_KeyAscii = 0
                    Input_Flg = True
                    
                    '日付/年月/時刻の場合
                    Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                        Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                            '削除後のSelStartを決定
                            Wk_SelStart = Act_SelStart
                            For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
                                '削現在の開始位置から左へ移動し文字が入力対象かを判定
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf _
                                               , Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
                                    '入力文字でない場合
                                    Wk_SelStart = Wk_Cnt
                                    Exit For
                                End If
                            
                            Next
                            '編集後のSelLengthを決定
                            Wk_SelLength = Act_SelLength
                            
                            '編集後のSelStartを決定
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                            '編集後のSelLengthを決定
                            pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            
                            '削除不可
                            Exit Function
                        Case Else
                        
                    End Select
                    
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                        '開始位置が左の場合、終了
                        If Act_SelStart = 0 Then
                            '削除不可
                            Exit Function
                        End If
                        
                        '削除対象の文字１桁を取得
                         Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
                        
                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            If Wk_DelMoji = "." Then
                            '削除対象の文字が小数点の場合
                                If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) _
                                + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) _
                                > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                                '削除後の桁数オーバーの場合
                                    '削除不可
                                    Exit Function
                                End If
                            End If
                        End If
                    
                        '削除文字の判定
                        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
                        '削除文字が入力対象の文字の場合
                            If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                            '文字編集
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) _
                                            & Left(Wk_CurMoji, Act_SelStart - 1) _
                                            & Mid(Wk_CurMoji, Act_SelStart + 1)
                            Else
                            '削除対象がない為、空白を編集
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            End If
                        Else
                        '削除文字が入力対象の文字の以外場合
                            'そのまま
                            Wk_EditMoji = Wk_CurMoji
                        End If
                    
                        '削除後の文字を表示形式に変換
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                        
                        '削除後のSelStartを決定
                        Wk_SelStart = Act_SelStart
                        For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
                            '削除後に現在の開始位置からの文字が入力対象かを判定
                            If CF_Jge_Input_Str(pm_Dsp_Sub_Inf _
                                           , Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
                                Exit For
                            End If
                            '入力文字でない場合、右へ移動
                            Wk_SelStart = Wk_SelStart + 1
                        Next
                        '編集後のSelLengthを決定
                        Wk_SelLength = Act_SelLength
                        
                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '数値項目で未入力の場合は、一番右を開始位置に設定
                            If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
                                Wk_SelStart = Len(Wk_DspMoji)
                                '編集後のSelLengthを決定
                                Wk_SelLength = 0
                            End If
                        End If
                    Else
                    '詰文字が左詰以外の場合
                        If Act_SelStart = 0 Then
                        '開始位置が一番左の場合
                            If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                                '文字編集
                                Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) _
                                            & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            Else
                                '削除対象がない為、空白を編集
                                Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                            End If
                        
                            '削除後のSelStartを決定
                            Wk_SelStart = Act_SelStart
                        Else
                            '文字編集
                            Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) _
                                        & Mid(Wk_CurMoji, Act_SelStart + 1) _
                                        & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                        
                            '削除後のSelStartを決定
                            Wk_SelStart = Act_SelStart - 1
                        End If
                        '編集後のSelLengthを決定
                        Wk_SelLength = Act_SelLength
                    
                        '編集後の文字を表示形式に変換
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                    End If
            
                    '削除後の文字置き換え
                    '文字設定
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
            
                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                
                Case Else
                    pm_KeyAscii = 0
            
            End Select
        End If
    End If

    If Input_Flg = True Then
        '入力後処理
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    End If

    If Re_Body_Crt = True Then
        '明細入力後の後処理
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Item_MouseDown
    '   概要：  対象項目のMOUSEDOWNの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Item_MouseDown(pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All, pm_Button As Integer, pm_Shift As Integer, pm_X As Single, pm_Y As Single) As Integer
    Dim Wk_Index    As Integer
    Dim bolSameCtl  As Boolean

    If pm_Button = vbRightButton Then
    '右クリック
        
        bolSameCtl = False
        If CInt(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
        '右クリックしたコントロールがアクティブなコントロールと一致
            'カーソル制御用テキストにフォーカスを一時的に退避
            Wk_Index = CInt(FR_SSSMAIN.TX_CursorRest.Tag)
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
            bolSameCtl = True
        End If
        
        '｢項目内容コピー｣判定
        FR_SSSMAIN.SM_AllCopy = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
        
        '｢項目内容に貼り付け｣判定
        FR_SSSMAIN.SM_FullPast = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
        
        '対象コントロールの使用不可
        pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
        
        '｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
        If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
            'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
            pm_All.Dsp_Base.LostFocus_Flg = True
            'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
            FR_SSSMAIN.PopupMenu FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton
            'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
            pm_All.Dsp_Base.LostFocus_Flg = False
            DoEvents
        End If
    
        'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
        '以降の処理は行わない。
        If pm_All.Dsp_Base.IsUnload = True Then
            Exit Function
        End If
        
        '対象コントロールの使用可
        pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
        'フォーカスを移動を元に戻す
        If bolSameCtl = True Then
            Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
        End If
    
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_VS_Scrl_Change
    '   概要：  VS_ScrlのCHANGEの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_VS_Scrl_Change(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Move_Flg                As Boolean
    Dim Row_Move_Value          As Integer
    Dim Cur_Row                 As Integer
    Dim Next_Row                As Integer
    Dim Next_Index              As Integer
    
    '最上明細ｲﾝﾃﾞｯｸｽを退避
    Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index

    '画面の内容を退避
    Call CF_Body_Bkup(pm_All)
    '縦スクロールバーの値を最上明細ｲﾝﾃﾞｯｸｽに設定
    pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
    
    '画面ボディ情報の配列を再設定
    Call CF_Dell_Refresh_Body_Inf(pm_All)
    
    '画面表示
    Call CF_Body_Dsp(pm_All)

    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
    If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
    And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
        
        '現在の行を取得
        Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
        'ﾌｫｰｶｽ制御
        '移動量
        Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
        
        '移動後の行
        Next_Row = Cur_Row + Row_Move_Value
        If Next_Row <= 0 Then
            Next_Row = 1
        End If
        If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
            Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
        End If
        
        '移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
        Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
         If Next_Index > 0 Then
            If Next_Index = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
            '同一ｺﾝﾄﾛｰﾙの場合
                '選択状態の設定（初期選択）
                Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '項目色設定
                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
            Else
            '同一ｺﾝﾄﾛｰﾙでない場合
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        Else
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            Else
                
                If Row_Move_Value > 0 Then
                '上へ移動
                    'ヘッダ部の最後の項目の１つ後ろから
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
                Else
                '下へ移動
                    'フッタ部の最初の項目の１つ前から
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If
            End If
        End If
    End If
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Dsp_Body_Page
    '   概要：  明細部分のページ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_Dsp_Body_Page(pm_Page_Value As Integer, pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Move_Flg                As Boolean
    Dim Row_Move_Value          As Integer
    Dim Cur_Row                 As Integer
    Dim Next_Row                As Integer
    Dim Next_Index              As Integer
    
    '最上明細ｲﾝﾃﾞｯｸｽを退避
    Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index

    '画面の内容を退避
    Call CF_Body_Bkup(pm_All)
    '最上明細ｲﾝﾃﾞｯｸｽに設定
    '（画面表示明細数－１）×（ページ数－１）＋１　　⇒１、６、１１、１６となる
    pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - 1) _
                                      * (pm_Page_Value - 1) _
                                      + 1
    '画面表示
    Call CF_Body_Dsp(pm_All)

    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
    If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
    And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
        
        '現在の行を取得
        Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
        'ﾌｫｰｶｽ制御
        '移動量
        Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
        
        '移動後の行
        Next_Row = Cur_Row + Row_Move_Value
        If Next_Row <= 0 Then
            Next_Row = 1
        End If
        If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
            Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
        End If
        
        '移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
        Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
         If Next_Index > 0 Then
            If Next_Index = CInt(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
            '同一ｺﾝﾄﾛｰﾙの場合
                '選択状態の設定（初期選択）
                Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '項目色設定
                Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
            Else
            '同一ｺﾝﾄﾛｰﾙでない場合
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        Else
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            Else
                
                If Row_Move_Value > 0 Then
                '上へ移動
                    'ヘッダ部の最後の項目の１つ後ろから
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
                Else
                '下へ移動
                    'フッタ部の最初の項目の１つ前から
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If
            End If
        End If
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
    '   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Row As Integer, pm_All As Cls_All) As Boolean

    Dim Trg_Index               As Integer
    Dim Move_Flg                As Boolean
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    
    '画面明細の行と同一の明細をインデックスを取得
    Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
    
     If Trg_Index > 0 Then
        If Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
        '移動先が同じ場合
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
        
        Else
            '同一項目の１つ前からENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
        End If
    
    Else
        '入力可能な最初のインデックスを取得
        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
        If Focus_Ctl_Ok_Fst_Idx > 0 Then
            '同一項目の１つ前からENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_Paste
    '   概要：  貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_MN_Paste(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Integer
    
    Dim Clip_Value As String
    Dim Paste_Value As String
    
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer
    Dim Wk_EditMoji         As String
    Dim Wk_CurMoji          As String
    Dim Wk_DspMoji          As String
    
    'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
    Clip_Value = Clipboard.GetText()
    '入力文字可能を取り出す
    Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
    
    '貼り付け内容がない場合、処理中断
    If Paste_Value = "" Then
        Exit Function
    End If
    
    '現在のﾃｷｽﾄ上の選択状態を取得
    Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
    Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
    Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
    Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
    '現在の値を取得
    Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
    
    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
    '詰文字が左詰の場合
        
        '文字編集
        Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
        
        '編集後のSelStartを決定
        '右端へ移動
        Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
        Wk_SelLength = 0
    Else
    '詰文字が左詰以外の場合
    
        If Act_SelLength = 0 Then
        '選択なしの場合(挿入状態)
            '文字編集
            Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                         & Paste_Value _
                         & Mid$(Wk_CurMoji, Act_SelStart + 1)
        Else
        '一部選択
            If Act_SelLength >= 2 Then
            '２文字以上選択している場合は
            '選択文字より後ろの文字もつける
                '文字編集
                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                             & Paste_Value _
                             & Mid$(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
            Else
            '１文字以下選択している場合は
            '選択文字以降は入れ換え
                '文字編集
                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) _
                             & Paste_Value
            
            End If
        
        End If
    
        '編集後のSelStartを決定
        '左端へ移動
        Wk_SelStart = 0
        Wk_SelLength = 1
    
    End If
    
    Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
        Case IN_TYP_DATE
        '日付の場合、入力形式が決まっている場合
            '日付入力形式の桁数だけ取得
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
        Case IN_TYP_YYYYMM
        '年月の場合、入力形式が決まっている場合
            '日付入力形式の桁数だけ取得
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
        Case IN_TYP_HHMM
        '時刻の場合、入力形式が決まっている場合
            '日付入力形式の桁数だけ取得
            Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
        Case Else
    
    End Select
    
    '編集後の文字を表示形式に変換
    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
    
    'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
    
    '編集後のSelStartを決定
    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
    '編集後のSelLengthを決定
    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
    
    '入力後の後処理
    Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

    '明細入力後の後処理
    Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Dsp_Body
    '   概要：  指定された明細の初期値を設定する
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Dsp_Body(pm_Bd_Index As Integer, pm_All As Cls_All) As Integer
    Dim Wk_Index As Integer

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Item_Input_Aft
    '   概要：  画面で項目入力された場合の後処理を行います
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Boolean
    
    Dim Row_Inf_Max_S       As Integer
    Dim Row_Inf_Max_E       As Integer
    Dim Bd_Index            As Integer
    
    '明細の再作成を行う
     Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)

End Function
        
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Befe_Focus
    '   概要：  前のフォーカス位置設定(LEFTなど)
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Befe_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Trg_Index               As Integer
    Dim Index_Wk                As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Cur_Top_Index           As Integer
    Dim Focus_Ctl_Ok_Lst_Idx    As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    '次の項目を検索
    For Index_Wk = Trg_Index - 1 To 1 Step -1

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
        'フッタ部からボディ部へ移動する場合
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                Index_Wk = Focus_Ctl_Ok_Fst_Idx
            End If

        End If

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
        'ボディ部からヘッダ部へ移動する場合
            If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
            '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合

                '画面の内容を退避
                Call CF_Body_Bkup(pm_All)
                '移動可能行を一番上に表示した場合の最上明細インデックスを設定
                pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                    '縦スクロールバーを設定
                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                End If
                '画面ボディ情報の配列を再設定
                Call CF_Dell_Refresh_Body_Inf(pm_All)
                '画面表示
                Call CF_Body_Dsp(pm_All)

                '入力可能な最後のインデックスを取得
                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
                If Focus_Ctl_Ok_Lst_Idx > 0 Then
                    Index_Wk = Focus_Ctl_Ok_Lst_Idx
                End If

            End If
        End If

        'ﾌｫｰｶｽ移動がOK
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
            If pm_Run_Flg = True Then
                '実行指定がある場合(基本あり)
                'ﾌｫｰｶｽ移動
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            End If
            '移動フラグ決定
            pm_Move_Flg = True
            Exit For
        End If
    Next

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Next_Focus
    '   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Sta_Index           As Integer
    Dim Index_Wk            As Integer
    Dim Rtn_Chk             As Integer
    Dim Bd_Index            As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
    Dim Focus_Ctl_Ok_Lst_Idx    As Integer
    Dim Focus_Ctl_Ok_Fst_Idx_Wk As Integer
    Dim Cur_Top_Index       As Integer
    Dim intRet              As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    'ボディ部
        'Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
        '最終準備行の場合
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)

            If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
            '入力可能な最初の項目の場合
                'モードにより検索開始位置を決定
                Select Case pm_Mode
                    Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
                    'KEYRETURN、KEYDOWNの場合
                        '検索開始はフッタ部の最初の項目から
                        Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx

                    Case NEXT_FOCUS_MODE_KEYRIGHT
                    'KEYRIGHTの場合
                        '割当ｲﾝﾃﾞｯｸｽ取得
                        '検索開始は対象の項目の次
                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1

                End Select
            Else
                '検索開始は対象の項目の次
                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            End If

        Else
        '最終準備行以外の場合
            If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
            '表示されている最終行の場合
                '入力可能な最後のインデックスを取得
                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)

                If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
                '入力可能な最後の項目の場合
                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                    '最終準備行以外＆画面上の最終行＆最終項目
                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合

                        '画面の内容を退避
                        Call CF_Body_Bkup(pm_All)
                        '移動可能行を一番下に表示した場合の最上明細インデックスを設定
                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                            '縦スクロールバーを設定
                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                        End If
                        '画面ボディ情報の配列を再設定
                        Call CF_Dell_Refresh_Body_Inf(pm_All)
                        '画面表示
                        Call CF_Body_Dsp(pm_All)

                        '明細１番下行の入力可能な最初のインデックスを取得
                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
                            '明細１番下行の最初の項目の一つ前から検索
                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
                        Else
                            '検索開始は対象の項目の次
                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                        End If

                     Else
                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
                        '検索開始は対象の項目の次
                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                     End If
                Else
                '入力可能な最後の項目以外の場合
                    '検索開始は対象の項目の次
                    Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                End If

            Else
            '最終行以外場合
                '検索開始は対象の項目の次
                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            End If
        End If

    Else
    'ボディ部以外
        '検索開始は対象の項目の次
        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
    End If

    '次の項目を検索
    For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD _
        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
        'ヘッダ部からボディ部へ移動する場合
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            'ﾍｯﾀﾞ部ﾁｪｯｸ
            If gv_bolInit = False Then
                Rtn_Chk = F_Ctl_Head_Chk(pm_All)
            Else
                Rtn_Chk = CHK_OK
            End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
            If Rtn_Chk <> CHK_OK Then
            'チェックＮＧの場合
                'キーフラグを元に戻す
                gv_bolKeyFlg = False
                Exit For
            End If
        End If

        'ﾌｫｰｶｽ移動がOK
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
            If pm_Run_Flg = True Then
            '実行指定がある場合(基本あり)
                'ﾌｫｰｶｽ移動
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            End If
            '移動フラグ決定
            pm_Move_Flg = True
            Exit For
        End If

    Next

    '最終項目まで検索終了時
    If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
        'モードにより検索終了後の処理を決定
        Select Case pm_Mode
            Case NEXT_FOCUS_MODE_KEYRETURN
            'KEYRETURNの場合
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            Call PrintTNAPR82_Main(pm_All, -1)
            'キーフラグを元に戻す
            gv_bolKeyFlg = False
On Error Resume Next
            FR_SSSMAIN.HD_TEISYOYM.SetFocus
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
                pm_Move_Flg = True
            Case NEXT_FOCUS_MODE_KEYRIGHT
            'KEYRIGHTの場合
                '検索開始項目で選択状態が移動する
                '選択状態の設定（初期選択）
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
            Case NEXT_FOCUS_MODE_KEYDOWN
            'KEYDOWNの場合

        End Select
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Left_Next_Focus
    '   概要：  Left押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Wk_Point            As Integer
    Dim Wk_SelStart         As Integer
    Dim Wk_SelLength        As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '全選択の場合（選択文字が最大バイト数と一致）
            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                '詰文字が左詰の場合
                '１文字目を選択する
                pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            Else
                '詰文字が左詰以外の場合
                '１つ前の項目へ
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)

            End If
        Else
            If Act_SelStart = 0 Then
            '開始位置が一番左の場合
                '１つ前の項目へ
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
            Else

                '左に１桁ずつずらし入力可能な文字を検索
                Wk_SelStart = -1
                For Wk_Point = Act_SelStart - 1 To 0 Step -1
                    Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                        Wk_SelStart = Wk_Point
                        Exit For
                    End If
                Next

                If Wk_SelStart = -1 Then
                '選択可能な文字がない場合
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                Else
                '選択可能な文字がある場合
                    If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) _
                    And Act_SelLength = 0 Then
                    '移動前の選択開始位置が一番右以外でかつ
                    '選択文字数がない場合のみ、
                        '同じ項目で移動する場合に選択文字数は継続する
                        Wk_SelLength = 0
                    Else
                        Wk_SelLength = 1
                    End If

                    pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                End If

            End If
        End If
    Else
    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
        '１つ前の項目へ
        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Right_Next_Focus
    '   概要：  Right押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, pm_Run_Flg As Boolean) As Integer
    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Next_SelStart       As Integer
    Dim Wk_Point            As Integer
    Dim Wk_SelLength        As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
        '全選択の場合（選択文字が最大バイト数と一致）
            If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                '詰文字が左詰の場合
                '最終文字を選択する
                pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            Else
                '詰文字が左詰以外の場合
                '１桁目を選択する
                pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                pm_Dsp_Sub_Inf.Ctl.SelLength = 1
            End If
        Else
            If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
            '選択開始位置が一番右の場合
                'ENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
            Else
            '選択開始位置が一番右でない場合

                '１つ右の１桁を取得
                Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)

                If Str_Wk = "" Then
                    '次の１桁がない場合
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '一番右へ移動し選択なし状態に
                        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                        pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                    Else
                    '詰文字が左詰以外の場合
                        If Act_SelLength = 0 Then
                        '移動前の選択文字数がない場合
                            '一番右へ移動し選択なし状態に
                            pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                        Else
                            'ENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
                    End If
                Else

                    '右に１桁ずつずらし入力可能な文字を検索
                    Next_SelStart = -1
                    For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1

                        Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)

                        Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                            Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                            '日付/年月/時刻項目の場合
                                '入力可能文字＆と空白も移動可能
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 _
                                Or Str_Wk = Space(1) Then
                                    Next_SelStart = Wk_Point
                                    Exit For
                                End If
                            Case Else
                            '日付/年月/時刻項目以外の場合
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                                    Next_SelStart = Wk_Point
                                    Exit For
                                End If
                            
                        End Select
                    Next

                    If Next_SelStart = -1 Then
                    '選択可能な文字がない場合
                        'ENTキー押下と同様に次の項目へ
                        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                    Else
                    '選択可能な文字がある場合

                        If Act_SelLength = 0 Then
                        '移動前の選択文字数がない場合
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                        pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    End If
                End If
            End If

        End If
    Else
    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
        'ENTキー押下と同様に次の項目へ
        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Down_Next_Focus
    '   概要：  Down押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All) As Integer
    Dim Trg_Index   As Integer
    Dim Index_Wk    As Integer
    Dim Next_Index  As Integer
    Dim Wk_Cnt      As Integer
    Dim Cur_Top_Index As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    '明細部の場合
        Wk_Cnt = 0
        Do
            Wk_Cnt = Wk_Cnt + 1
            '現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
            Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)

            If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
            '項目数を超えた場合
                'ENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                Exit Do
            End If

            If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD _
            And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.NAME = pm_Dsp_Sub_Inf.Ctl.NAME Then
            '移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
                If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
                'ﾌｫｰｶｽ受取ＯＫ
                    '同一列に移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
                    pm_Move_Flg = True
                    Exit Do
                End If
            Else
            '次の項目名が明細部でない場合
                If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
                    '画面の内容を退避
                    Call CF_Body_Bkup(pm_All)
                    '移動可能行を一番下に表示した場合の最上明細インデックスを設定
                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                        '縦スクロールバーを設定
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                    End If
                    '画面表示
                    Call CF_Body_Dsp(pm_All)
                    '明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                    If Next_Index > 0 Then
                        If Next_Index = Trg_Index Then
                        '同一ｺﾝﾄﾛｰﾙの場合
                            '移動無しで終了
                            pm_Move_Flg = False
                            Exit Do
                        Else
                        '同一ｺﾝﾄﾛｰﾙでない場合
                            '同一項目の１つ前からENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    Else
                        '入力可能な最初のインデックスを取得
                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
                            '同一項目の１つ前からENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        Else
                            'フッタ部の最初の項目の１つ前から
                            'ENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    End If

                Else
                '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
                    'フッタ部の最初の項目の１つ前から
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                    Exit Do
                End If
            End If
        Loop

    Else
    '明細部以外の場合
        'ENTキー押下と同様に次の項目へ
        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Up_Next_Focus
    '   概要：  Up押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All) As Integer
    Dim Trg_Index   As Integer
    Dim Index_Wk    As Integer
    Dim Next_Index  As Integer
    Dim Wk_Cnt      As Integer
    Dim Cur_Top_Index As Integer
    Dim Focus_Ctl_Ok_Fst_Idx    As Integer

    '移動フラグ初期化
    pm_Move_Flg = False

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
    '明細部の場合
        Wk_Cnt = 0
        Do
            Wk_Cnt = Wk_Cnt + 1
            '現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
            Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)

            If Next_Index < 0 Then
            'マイナスの場合
                '１つ前の項目へ
                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
                Exit Do
            End If

            If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD _
            And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.NAME = pm_Dsp_Sub_Inf.Ctl.NAME Then
            '移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
                If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
                'ﾌｫｰｶｽ受取ＯＫ
                    '同一列に移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
                    pm_Move_Flg = True
                    Exit Do
                End If
            Else
            '次の項目名が明細部でない場合
                If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
                '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
                    '画面の内容を退避
                    Call CF_Body_Bkup(pm_All)
                    '移動可能行を一番上に表示した場合の最上明細インデックスを設定
                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                        '縦スクロールバーを設定
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                    End If
                    '画面ボディ情報の配列を再設定
                    Call CF_Dell_Refresh_Body_Inf(pm_All)
                    '画面表示
                    Call CF_Body_Dsp(pm_All)
                    '明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
                    If Next_Index > 0 Then
                        If Next_Index = Trg_Index Then
                        '同一ｺﾝﾄﾛｰﾙの場合
                            '移動無しで終了
                            pm_Move_Flg = False
                            Exit Do
                        Else
                        '同一ｺﾝﾄﾛｰﾙでない場合
                            '同一項目の１つ後ろから
                            '１つ前の項目へ
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
                            Exit Do
                        End If
                    Else
                        '入力可能な最初のインデックスを取得
                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
                            '入力可能な最初の項目の１つ後ろから
                            '１つ前の項目へ
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
                            Exit Do
                        Else
                            'ヘッダ部の最後の項目の１つ後ろから
                            '１つ前の項目へ
                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
                            Exit Do

                        End If
                    End If
                Else
                    'ヘッダ部の最後の項目の１つ後ろから
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
                    Exit Do
                End If

            End If
        Loop
    Else
    '明細部以外の場合
        '１つ前の項目へ
        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Clr_Dsp
    '   概要：  各画面の項目を初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Clr_Dsp(pm_Index As Integer, pm_All As Cls_All) As Integer

    Dim Index_Wk        As Integer
    Dim Wk_Index_S      As Integer
    Dim Wk_Index_E      As Integer
    Dim Now_Dt          As Date
    Dim Wk_Mode         As Integer

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Now_Dt = Now
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    If pm_Index = -1 Then
        Wk_Index_S = 1
        Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
        pm_All.Dsp_Base.Head_Ok_Flg = False
        Wk_Mode = ITM_ALL_CLR
    Else
        Wk_Index_S = pm_Index
        Wk_Index_E = pm_Index
        Wk_Mode = ITM_ALL_ONLY
    End If

    For Index_Wk = Wk_Index_S To Wk_Index_E

        '共通初期化
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)

        '全体初期化の場合
        If Wk_Mode = ITM_ALL_CLR Then
            'フッタ部以降の項目を全ﾌｫｰｶｽなしとする
            If Index_Wk > pm_All.Dsp_Base.Foot_Fst_Idx Then
                Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
            End If
        End If

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '個別初期化
        Select Case Index_Wk
            Case CInt(FR_SSSMAIN.HD_TEISYOYM.Tag)
            '経理締日付
                '初期画面編集時、値が入っていないため編集↓
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = gv_strInitYM
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(gv_strInitYM, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

            Case CInt(FR_SSSMAIN.HD_SOUBSCD.Tag)
            '倉庫
                '初期画面編集時、値が入っていないため編集↓
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "" '
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
            Case CInt(FR_SSSMAIN.HD_SOUCD.Tag)
            '倉庫
                '初期画面編集時、値が入っていないため編集↓
                If Len(Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value)) = 0 Then
                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value = "" '
                End If
                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item("", pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
        
        End Select
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    Next

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Clr_Dsp_Body
    '   概要：  各画面のボディ項目を初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Clr_Dsp_Body(pm_Bd_Index As Integer, pm_All As Cls_All) As Integer
'
'    Dim Index_Bd_Wk         As Integer
'    Dim Wk_Bd_Index_S       As Integer
'    Dim Wk_Bd_Index_E       As Integer
'    Dim Wk_Mode             As Integer
'    Dim Wk_Index            As Integer
'    Dim Wk_Row              As Integer
'
'    If pm_Bd_Index = -1 Then
'        Wk_Bd_Index_S = 1
'        Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
'
'        '画面ボディ情報
'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
'
''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'        'スクロール初期化
'        '最大値
'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '最小値
'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '最大ｽｸﾛｰﾙ量
'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '最小ｽｸﾛｰﾙ量
'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
'        '初期値
'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
'        Wk_Mode = BODY_ALL_CLR
'    Else
'        Wk_Bd_Index_S = pm_Bd_Index
'        Wk_Bd_Index_E = pm_Bd_Index
'        Wk_Mode = BODY_ALL_ONLY
'    End If
'
'    For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
'
'        '共通初期化
'        Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
'
'        '配列０の初期情報を対象行にコピー
'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
'
'        '全体初期化の場合
'        If Wk_Mode = BODY_ALL_CLR Then
'            '全行初期状態
'            pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
'        End If
'
'        '個別初期化
''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'        '以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
'        '(対象の明細の番号情報だけが必要、)
'        Wk_Index = CInt(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
'        'Dsp_Body_Infの行ＮＯに変換
'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'        'Dsp_Body_Infに値を初期値を設定
'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
'
'    Next
'
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Cursor_Set
    '   概要：  画面初期状態時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Init_Cursor_Set(pm_All As Cls_All) As Integer

    Dim Trg_Index    As Integer

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
    '入力担当者コード（条件）にフォーカス設定
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(FR_SSSMAIN.HD_TEISYOYM.Tag)
    
    'ﾌｫｰｶｽ移動
    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
    '選択状態の設定（初期選択）
    Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
    '項目色設定
    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_Jge_Action
    '   概要：  各チェック関数のチェック前の
    '　　　　　 チェック続行を判定
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_From_Process　　　 :呼出元処理
    '           pm_Err_Rtn　　     　 :エラー戻値
    '           pm_Msg_Flg　　     　 :メッセージフラグ
    '           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                 , ByRef pm_Err_Rtn As Integer _
                                 , ByRef pm_Msg_Flg As Boolean _
                                 , ByRef pm_Move As Boolean) As Integer
    Dim Rtn_Cd     As Integer

    '続行
    Rtn_Cd = CHK_KEEP

    Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
        Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN _
           , CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '前回と同じチェック内容の場合
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '項目のステータスがエラーなし
                    '中断
                    Rtn_Cd = CHK_STOP
                    'メッセージ非表示
                    pm_Msg_Flg = False
                    '移動可
                    pm_Move = True
                    'チェックＯＫ
                    pm_Err_Rtn = CHK_OK
                End If
            End If

        Case CHK_FROM_KEYPRESS
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '前回と同じチェック内容の場合
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '項目のステータスがエラーなし
                    '中断
                    Rtn_Cd = CHK_STOP
                    'メッセージ非表示
                    pm_Msg_Flg = False
                    '移動可
                    pm_Move = True
                    'チェックＯＫ
                    pm_Err_Rtn = CHK_OK
                End If

            End If

        Case CHK_FROM_KEYRETURN
            '｢KEYRETURN｣
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '前回と同じチェック内容の場合
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                '項目のステータスがエラーなし
                    '中断
                    Rtn_Cd = CHK_STOP
                    'メッセージ非表示
                    pm_Msg_Flg = False
                    '移動可
                    pm_Move = True
                    'チェックＯＫ
                    pm_Err_Rtn = CHK_OK
                End If

            End If

        Case CHK_FROM_ALL_CHK
            '一括チェックなど｣
            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            '前回と同じチェック内容の場合
                If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT _
                And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
                '項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
                    '中断
                    Rtn_Cd = CHK_STOP
                    'メッセージ非表示
                    pm_Msg_Flg = False
                    '移動可
                    pm_Move = True
                    'チェックＯＫ
                    pm_Err_Rtn = CHK_OK
                End If

            End If
    
    End Select

    If Rtn_Cd = CHK_STOP Then
    'チェックを中断
        'チェック関数呼出元処理をクリア
        pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
    End If

    F_Chk_Jge_Action = Rtn_Cd

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_Jge_Msg_Move
    '   概要：  各チェック関数のチェック後の
    '　　　　　 メッセージ、ステータス、移動制御
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_From_Process　　　 :呼出元処理
    '           pm_Err_Rtn　　     　 :エラー戻値
    '           pm_Msg_Flg　　     　 :メッセージフラグ
    '           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                                 , ByRef pm_Err_Rtn As Integer _
                                 , ByRef pm_Msg_Flg As Boolean _
                                 , ByRef pm_Move As Boolean) As Integer

    'メッセージ表示なし
    pm_Msg_Flg = False
    '移動可
    pm_Move = True

    If pm_Err_Rtn = CHK_OK Then
    'チェックＯＫ
        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
    Else

        Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
            Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN _
               , CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '必須入力で未入力
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '１度も未入力以外チェックをしていない場合
                            'チェックＯＫとする
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            'メッセージ出力なし
                            pm_Msg_Flg = False
                            '移動ＯＫ
                            pm_Move = True
                        Else
                        '１度でも未入力チェックをしている場合
                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            '前回と同じチェック内容の場合
                                'チェックエラーとする
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            Else
                                '前回と異なるチェック内容の場合
                                'チェックエラーとする
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = False
                            End If
                        
                        End If
                    Case CHK_ERR_ELSE
                    'その他エラー時
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                        '前回と同じチェック内容の場合
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            'メッセージ出力なし
                            pm_Msg_Flg = False
                            '移動ＯＫ
                            pm_Move = True
                        Else
                        '前回と異なるチェック内容の場合
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＯＫ
                            pm_Move = False
                        End If

                End Select

            Case CHK_FROM_KEYPRESS
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '必須入力で未入力
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '１度も未入力以外チェックをしていない場合
                            'チェックＯＫとする
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            'メッセージ出力なし
                            pm_Msg_Flg = False
                            '移動ＯＫ
                            pm_Move = True
                        Else
                        '１度でも未入力チェックをしている場合
                            'チェックエラーとする
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                            'メッセージ出力なし
                            pm_Msg_Flg = False
                            '移動ＯＫ
                            pm_Move = True
                        End If
                    Case CHK_ERR_ELSE
                    'その他エラー時
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        'メッセージ出力あり
                        pm_Msg_Flg = True
                        '移動ＮＧ
                        pm_Move = False

                End Select

            Case CHK_FROM_KEYRETURN
                '｢KEYRETURN｣
                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '必須入力で未入力
                        If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                        '１度も未入力以外チェックをしていない場合
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                            pm_Err_Rtn = CHK_OK
                            'メッセージ出力なし
                            pm_Msg_Flg = False
                            '移動ＯＫ
                            pm_Move = True
                        Else
                        '１度でも未入力チェックをしている場合
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＮＧ
                            pm_Move = False
                        End If

                    Case CHK_ERR_ELSE
                    'その他エラー時
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        'メッセージ出力あり
                        pm_Msg_Flg = True
                        '移動ＮＧ
                        pm_Move = False

                End Select
            Case CHK_FROM_ALL_CHK

                Select Case pm_Err_Rtn
                    Case CHK_ERR_NOT_INPUT
                    '必須入力で未入力
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                        'メッセージ出力あり
                        pm_Msg_Flg = True
                        '移動ＮＧ
                        pm_Move = False

                    Case CHK_ERR_ELSE
                    'その他エラー時
                        pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                        'メッセージ出力あり
                        pm_Msg_Flg = True
                        '移動ＮＧ
                        pm_Move = False

                End Select

        End Select

    End If

    'チェック関数呼出元処理をクリア
    pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_Item_Detail
    '   概要：  各項目の画面表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_Item_Detail(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)

    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        Case FR_SSSMAIN.HD_SOUBSCD.NAME
            '場所コードによる画面表示
            Call F_Dsp_HD_SOUBSCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        Case FR_SSSMAIN.HD_TEISYOYM.NAME
            '経理締日付による画面表示
            Call F_Dsp_HD_TEISYOYM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
        Case FR_SSSMAIN.HD_SOUCD.NAME
            '倉庫コードによる画面表示
            Call F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_SOUCD_Inf
    '   概要：  倉庫コードによる画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '表示
        '項目内容が変更された場合
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '【倉庫名】
            Trg_Index = CInt(FR_SSSMAIN.HD_SOUNM.Tag)
            Dsp_Value = CF_Cnv_Dsp_Item(TNAPR82_InputData.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
            
            '復元内容、前回内容を退避
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    'クリア
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '【倉庫名】
        Trg_Index = CInt(FR_SSSMAIN.HD_SOUNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End If

    '前回チェック内容に退避
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_SOUBSCD_Inf
    '   概要：  場所コードによる画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_SOUBSCD_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '表示
        '項目内容が変更された場合
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '【場所名】
            Trg_Index = CInt(FR_SSSMAIN.HD_SOUBSNM.Tag)
            Dsp_Value = CF_Cnv_Dsp_Item(TNAPR82_InputData.SOUBSNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
            
            '復元内容、前回内容を退避
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    'クリア
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '【場所名】
        Trg_Index = CInt(FR_SSSMAIN.HD_SOUBSNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End If

    '前回チェック内容に退避
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Item_Chk
    '   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Item_Chk(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, pm_All As Cls_All) As Integer

    Dim Rtn_Chk      As Integer
    
    '各ﾁｪｯｸ関数と同じ戻値
    Rtn_Chk = CHK_OK
    pm_Chk_Move_Flg = True
    
    '①基本入力内容のチェック
    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

        Case FR_SSSMAIN.HD_TEISYOYM.NAME
        '経理締日付コード
            'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            'ﾁｪｯｸ
            Rtn_Chk = F_Chk_HD_TEISYOYM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        Case FR_SSSMAIN.HD_SOUBSCD.NAME
        '場所コード
            'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            'ﾁｪｯｸ
            Rtn_Chk = F_Chk_HD_SOUBSCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        Case FR_SSSMAIN.HD_SOUCD.NAME
        '倉庫コード
            'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
            Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
            'ﾁｪｯｸ
            Rtn_Chk = F_Chk_HD_SOUCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)


    End Select
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    F_Ctl_Item_Chk = Rtn_Chk

End Function

'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_TEISYOYM
    '   概要：  基準日のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Chk_HD_TEISYOYM(pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf _
                             , pm_Chk_Move As Boolean _
                             , pm_All As Cls_All) As Integer

    Dim Input_Value         As String
    Dim Retn_Code           As Integer
    Dim Msg_Flg             As Boolean
    Dim Rtn_Cd              As Integer
    Dim Err_Cd              As String

    'チェック実行判定
    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
    If Rtn_Cd = CHK_STOP Then
        '中断の場合
        F_Chk_HD_TEISYOYM = Retn_Code
        Exit Function
    End If

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '初期化
    Retn_Code = CHK_OK
    Err_Cd = ""
    Msg_Flg = False
    pm_Chk_Move = True

    '未入力チェック
    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Retn_Code = CHK_ERR_ELSE
        Err_Cd = gc_strMsgTNAPR82_E_015              '年月エラー
    Else
        '未入力以外のチェック済
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

        '基礎チェック
        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
            Retn_Code = CHK_ERR_ELSE
            Err_Cd = gc_strMsgTNAPR82_E_014              '年月エラー
        Else
            'ＯＫ
            Retn_Code = CHK_OK
            pm_Chk_Move = True

            '取得項目格納
            TNAPR82_InputData.TEISYOYM = Input_Value
        End If
        
    End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '戻値、メッセージ、ステータス、移動制御
    Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
        'メッセージ出力
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Chk_HD_TEISYOYM = Retn_Code

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Head_Chk
    '   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Head_Chk(pm_All As Cls_All) As Integer

    Dim Index_Wk        As Integer
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    Dim intMoveFocus    As Integer

    '各ﾁｪｯｸ関数と同じ戻値
    Rtn_Chk = CHK_OK

    'ヘッダ部の最終項目まで各項目のﾁｪｯｸを行う
    For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx

        '各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
        Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)

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
        Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
        
        'チェックＮＧ
        If Rtn_Chk <> CHK_OK Then

            '未入力メッセージ
'            If Rtn_Chk = CHK_ERR_NOT_INPUT Then
'                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgMITET51_E_011, pm_All)
'            End If

            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

            F_Ctl_Head_Chk = Rtn_Chk
            Exit Function
        End If
    Next

    '関連ﾁｪｯｸ
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
    'チェックＮＧ
    If Rtn_Chk <> CHK_OK Then

        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)

        F_Ctl_Head_Chk = Rtn_Chk
        Exit Function
    End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    
    If Rtn_Chk = CHK_OK _
    And pm_All.Dsp_Base.Head_Ok_Flg = False Then
    'チェックＯＫでかつ
    'ヘッダ部のチェックが初めての場合
'        '１行目のボディ部を準備最終行として開放する
'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
        'フッタ部を開放する
        Call F_Foot_In_Ready(pm_All)
        'チェックＯＫ
        pm_All.Dsp_Base.Head_Ok_Flg = True
    End If

    F_Ctl_Head_Chk = Rtn_Chk

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Head_RelChk
    '   概要：  ﾍｯﾀﾞ部の関連ﾁｪｯｸ
    '   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象（ゼロ:案件IDへ移動）
    '   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Head_RelChk(pm_All As Cls_All, ByRef pm_ErrIdx As Integer) As Integer

    Dim Index_Wk        As Integer
    Dim Rtn_Chk         As Integer
    Dim Trg_IndexStt    As Integer
    Dim ValueStt        As String
    Dim ValueEnd        As String
    Dim Err_Cd          As String       'エラーコード

    '各ﾁｪｯｸ関数と同じ戻値
    Rtn_Chk = CHK_ERR_ELSE
    Err_Cd = ""
    pm_ErrIdx = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
    
    Rtn_Chk = CHK_OK
    
F_Ctl_Head_RelChk_END:

    If Trim(Err_Cd) <> "" Then
        'メッセージ出力
        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    End If

    F_Ctl_Head_RelChk = Rtn_Chk

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Body_Chk
    '   概要：  ﾎﾞﾃﾞｨ部のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Ctl_Body_Chk(pm_All As Cls_All) As Integer
'
'    Dim Index_Wk_Col    As Integer
'    Dim Index_Wk_Row    As Integer
'    Dim Trg_Index       As Integer
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
'    Dim Dsp_Mode        As Integer
'
'    Dim Err_Row         As Integer
'    Dim Err_Dsp_Sub_Inf_Wk  As Cls_Dsp_Sub_Inf
'    Dim Bd_Idx          As Integer
'    Dim Err_Index       As Integer
'    Dim Move_Flg        As Boolean
'    Dim Focus_Ctl_Ok_Fst_Idx As Integer
'
'
'    '各ﾁｪｯｸ関数と同じ戻値
'    Rtn_Chk = CHK_OK
'
'    'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
'    For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
'
'        Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
'            Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
'                '入力待状態、入力済状態状態を対象
'
'                For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
'
'                    '画面明細の隠行の項目のｲﾝﾃﾞｯｸｽを取得
'                    Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row( _
'                                  pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm _
'                                , pm_All)
'
'                    'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
'                    Set Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
'
'                    'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
'                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value _
'                                          , Dsp_Sub_Inf_Wk _
'                                          , pm_All)
'                    '画面項目詳細情報を設定
'                    Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
'
'                    '各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
'                    Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
'
'                    If Rtn_Chk = CHK_OK Then
'                    'チェックＯＫ時
'                        '取得内容表示
'                        Dsp_Mode = DSP_SET
'                    Else
'                    'チェックＮＧ時
'                        '取得内容クリア
'                        Dsp_Mode = DSP_CLR
'                    End If
'                    '取得内容表示/クリア
'                    Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
'
'                    '｢画面ボディ情報｣にワークの｢画面項目情報｣を編集
'                    '画面項目詳細情報を設定
'                    '条件によって変更される項目のみ
'                    Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col) _
'                                                      , Dsp_Sub_Inf_Wk.Detail)
'
'                    'チェックＮＧ
'                    If Rtn_Chk <> CHK_OK Then
'
'                        'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
'                        'エラー用変数格納
'                        '行情報
'                        Err_Row = Index_Wk_Row
'                        '対象ｺﾝﾄﾛｰﾙ情報
'                        Set Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
'                        '画面項目詳細情報を設定
'                        Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
'
'                        GoTo ERR_EXIT
'                    End If
'
'                Next
'        End Select
'    Next
'
'
''    '関連ﾁｪｯｸ
''    Rtn_Chk = F_Ctl_Body_RelChk(pm_All)
'    'チェックＮＧ
'    If Rtn_Chk <> CHK_OK Then
'
'        'ﾁｪｯｸ後移動なし
''            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
'
'        F_Ctl_Body_Chk = Rtn_Chk
'        Exit Function
'    End If
'
'
'    F_Ctl_Body_Chk = Rtn_Chk
'
'    Exit Function
'
'ERR_EXIT:
''エラー時、ﾌｫｰｶｽ移動
'    '対象行を画面に表示
'    Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
'    '対象行から画面明細の行を取得
'    Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
'    '画面明細の行と同一の明細をインデックスを取得
'    Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
'
'     If Err_Index > 0 Then
'        '同一項目の１つ前からENTキー押下と同様に次の項目へ
'        Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
''        '選択状態の設定（初期選択）
''        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
''        '項目色設定
''        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
'
'    Else
'        '入力可能な最初のインデックスを取得
'        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
'        If Focus_Ctl_Ok_Fst_Idx > 0 Then
'            '同一項目の１つ前からENTキー押下と同様に次の項目へ
'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
'        End If
'    End If
'
'    F_Ctl_Body_Chk = Rtn_Chk
'    Exit Function
'
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Foot_In_Ready
    '   概要：  フッタ部の入力準備
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Foot_In_Ready(pm_All As Cls_All) As Integer
'
'    Dim Index_Wk        As Integer
'
'    'フッタ部内で処理
'    For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
'        Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.NAME
''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'            Case FR_SSSMAIN.TL_NHSCD.NAME _
'               , FR_SSSMAIN.TL_NOKDTPRT.NAME _
'               , FR_SSSMAIN.TL_YUKODT.NAME _
'               , FR_SSSMAIN.TL_DENCMA.NAME _
'               , FR_SSSMAIN.TL_TFPATH.NAME _
'               , FR_SSSMAIN.TL_SBAMITKN.NAME
''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
'            '初期状態で入力可能なｺﾝﾄﾛｰﾙ
'                '入力可能
'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
'        End Select
'    Next
'
End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_MitList_PrtMain
    '   概要：  棚卸結果表出力出力処理
    '   引数：　pm_TNAPR82Data      画面入力データ
    '           pm_intMode          1:プリンタ出力  2:画面表示  3:ファイル出力
    '   戻値：　0:正常終了  1:他で印刷中  3:該当データ無し 5:中断 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function PrintTNAPR82_Main(pm_All As Cls_All, pm_intMode As Integer) As Integer

    Dim intRet          As Integer
    Dim intRet2         As Integer
    Dim intMode         As Integer
    Dim bolRet          As Boolean
    Dim bolTrans        As Boolean
    Dim strPrtSeq       As String
    Dim strSQL          As String
    Dim strMsgCd        As String
    Dim bolOraErr       As Boolean
    Dim intCursor       As Integer
    Dim strLIST_ID      As String

    bolTrans = False

    'すでに印刷を開始している場合は処理を行えない
    If gv_bolNowPrinting = True Then
        Exit Function
    End If

    '印刷中フラグセット
    gv_bolNowPrinting = True

    PrintTNAPR82_Main = 9

    SSS_LSTOP = False
    strMsgCd = ""
    bolOraErr = False

    'ボタンの使用可／不可
    FR_SSSMAIN.MN_LSTART.Enabled = False
    FR_SSSMAIN.MN_VSTART.Enabled = False
    FR_SSSMAIN.CM_LSTART.Visible = False
    FR_SSSMAIN.CM_VSTART.Visible = False
    FR_SSSMAIN.CM_LCANCEL.Enabled = True

    'カーソル退避
    intCursor = FR_SSSMAIN.MousePointer
    FR_SSSMAIN.MousePointer = vbHourglass

    'ヘッダ部のチェック
    intRet = F_Ctl_Head_Chk(pm_All)
    If intRet <> CHK_OK Then
    'チェックＮＧの場合
        GoTo Error_Handler
    End If

    'モードなしの場合、選択画面表示
    If pm_intMode = -1 Then

        gv_bolTNAPR82_LF_Enable = False

        DoEvents

        DLGLST02_ACE.Show vbModal
        intMode = SSS_RTNWIN + 1

        gv_bolTNAPR82_LF_Enable = True
    Else
        intMode = pm_intMode
    End If

    If intMode <> SSS_PRINTER And intMode <> SSS_VIEW And intMode <> SSS_FILE Then
        '中断
        PrintTNAPR82_Main = 0
        GoTo Exit_Handler
    End If

    '***更新処理***

    'ゲージの初期化
    Call InitGauge
    Call ShowGauge(True)

    'USR9でトランザクション開始
    bolRet = CF_Ora_BeginTrans(gv_Oss_USR1)
    If Not bolRet Then
        strMsgCd = gc_strMsgTNAPR82_E_010
        bolOraErr = True
        GoTo Error_Handler
    End If
    bolTrans = True

    'ＳＥＱの取得
'    strPrtSeq = GetPrtSeq()
'    If strPrtSeq = "" Then
'        strMsgCd = gc_strMsgTNAPR82_E_007
'        bolOraErr = True
'        Exit Function
'    End If
    strLIST_ID = "TNAPR82"
    '帳票用ワーク作成処理の呼び出し（PLSQL）
     Call F_Execute_PLSQL
    If Not bolRet Then
        strMsgCd = gc_strMsgTNAPR82_E_008
        bolOraErr = True
        GoTo Error_Handler
    End If

    'ゲージの更新
    Call RefreshGauge(1, 1)

    If SSS_LSTOP = False Then
        'コミット
        bolRet = CF_Ora_CommitTrans(gv_Oss_USR1)
        If Not bolRet Then
            strMsgCd = gc_strMsgTNAPR82_E_010
            bolOraErr = True
            GoTo Error_Handler
        End If
        bolTrans = False

        '帳票出力
        intRet = OutPutList_Main(intMode, strLIST_ID, "", strPrtSeq)
        If intRet <> 0 Then
            PrintTNAPR82_Main = intRet
            Select Case intRet
                Case 1      '他で印刷中
                    'メッセージ出力済み
                Case 2      'キャンセル
                    strMsgCd = gc_strMsgTNAPR82_I_004
                Case 3      'データなし
                    strMsgCd = gc_strMsgTNAPR82_E_006
                Case Else   'それ以外
                    strMsgCd = gc_strMsgTNAPR82_E_011
            End Select
            GoTo Error_Handler
        End If

    Else
        '処理中断
        'ロールバック
        If bolTrans Then
            Call CF_Ora_RollbackTrans(gv_Oss_USR1)
        End If
        bolTrans = False
    End If

    PrintTNAPR82_Main = 0

Exit_Handler:
    'メッセージの表示
    If strMsgCd <> "" Then
        If bolOraErr Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All, "PrintTNAPR82_Main")
        Else
            Call AE_CmnMsgLibrary(SSS_PrgNm, strMsgCd, pm_All)
        End If
    End If

    'ボタンの使用可／不可
    FR_SSSMAIN.MN_LSTART.Enabled = True
    FR_SSSMAIN.MN_VSTART.Enabled = True
    FR_SSSMAIN.CM_LSTART.Visible = True
    FR_SSSMAIN.CM_VSTART.Visible = True
    FR_SSSMAIN.CM_LCANCEL.Enabled = False

    'カーソルを戻す
    FR_SSSMAIN.MousePointer = intCursor

    'ゲージの初期化
    Call InitGauge
    Call ShowGauge(False)

    '印刷中フラグセット
    gv_bolNowPrinting = False

    Exit Function

Error_Handler:

    'ロールバック
    If bolTrans Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    bolTrans = False

    GoTo Exit_Handler

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function F_Execute_PLSQL
'   概要：  SQL実行処理
'   引数：  なし
'   戻値：  0 : 正常 9: 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Execute_PLSQL() As Integer
        
    
    Dim strSQL      As String           'SQL文
    
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(担当者ｺｰﾄﾞ)
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(ｸﾗｲｱﾝﾄID)
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(経理締日付)
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(場所ｺｰﾄﾞ)
    Dim strPara5    As String           'ﾊﾟﾗﾒｰﾀ5(倉庫ｺｰﾄﾞ)
    
    Dim lngPara6    As Long             'ﾊﾟﾗﾒｰﾀ3(ﾘﾀｰﾝｺｰﾄﾞ)
    Dim lngPara7    As Long             'ﾊﾟﾗﾒｰﾀ5(ｴﾗｰｺｰﾄﾞ)
    Dim strPara8    As String           'ﾊﾟﾗﾒｰﾀ6(ｴﾗｰ内容)
    Dim lngPara9    As Long             'ﾊﾟﾗﾒｰﾀ7(読込件数)
    Dim lngPara10    As Long             'ﾊﾟﾗﾒｰﾀ8(登録件数)
    Dim param(10)    As OraParameter      'PL/SQLのバインド変数
    Dim bolRet      As Boolean
    
    F_Execute_PLSQL = 9
    
    '受渡し変数初期設定
    strPara1 = SSS_OPEID
    strPara2 = SSS_CLTID
    strPara3 = TNAPR82_InputData.TEISYOYM
    strPara4 = TNAPR82_InputData.SOUBSCD
    strPara5 = TNAPR82_InputData.SOUCD
    lngPara6 = 0
    lngPara7 = 0
    strPara8 = ""
    lngPara9 = 0
    lngPara10 = 0

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
    
    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P8", strPara8, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT

    'データ型をオブジェクトにセット
    Set param(1) = gv_Odb_USR1.Parameters("P1")
    Set param(2) = gv_Odb_USR1.Parameters("P2")
    Set param(3) = gv_Odb_USR1.Parameters("P3")
    Set param(4) = gv_Odb_USR1.Parameters("P4")
    Set param(5) = gv_Odb_USR1.Parameters("P5")
    
    Set param(6) = gv_Odb_USR1.Parameters("P6")
    Set param(7) = gv_Odb_USR1.Parameters("P7")
    Set param(8) = gv_Odb_USR1.Parameters("P8")
    Set param(9) = gv_Odb_USR1.Parameters("P9")
    Set param(10) = gv_Odb_USR1.Parameters("P10")
    
    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_CHAR
    
    param(6).serverType = ORATYPE_NUMBER
    param(7).serverType = ORATYPE_NUMBER
    param(8).serverType = ORATYPE_VARCHAR2
    param(9).serverType = ORATYPE_NUMBER
    param(10).serverType = ORATYPE_NUMBER

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_TNAPR82_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10); End;"

    'DBアクセス
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo F_Execute_PLSQL_END
    End If

    '** 戻り値取得
    lngPara6 = param(6).Value
    If IsNull(param(8).Value) = False Then
        strPara8 = param(8).Value
    End If
    
    'エラー情報設定
    gv_Str_OraErrText = strPara8
    
    F_Execute_PLSQL = lngPara6
    
F_Execute_PLSQL_END:
    '** パラメタ解消
    gv_Odb_USR1.Parameters.Remove "P1"
    gv_Odb_USR1.Parameters.Remove "P2"
    gv_Odb_USR1.Parameters.Remove "P3"
    
    gv_Odb_USR1.Parameters.Remove "P4"
    gv_Odb_USR1.Parameters.Remove "P5"
    gv_Odb_USR1.Parameters.Remove "P6"
    gv_Odb_USR1.Parameters.Remove "P7"
    gv_Odb_USR1.Parameters.Remove "P8"
    gv_Odb_USR1.Parameters.Remove "P9"
    gv_Odb_USR1.Parameters.Remove "P10"
End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_GATUDO
    '   概要：  日付、締日から月度を算出
    '   引数：　pm_DT   日付(YYYYMMDD)
    '   戻値：　月度(YYYYMM)
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Get_GATUDO(pm_DT As String, pm_SMEDD As String) As String

    Dim bolRet                  As Boolean
    Dim strSQL                  As String
    Dim Usr_Ody                 As U_Ody
    Dim strYM                   As String

    On Error GoTo ERR_HANDLE
    F_Get_GATUDO = Mid(pm_DT, 1, 6)
    
    '前回経理締実行日の月度を算出
    strSQL = " select GET_GATUDO("
    strSQL = strSQL & "  '" & pm_DT & "'"
    strSQL = strSQL & " ,'" & pm_SMEDD & "'"
    strSQL = strSQL & " ) from dual "

    'DBアクセス
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    If bolRet = False Then
        GoTo ERR_HANDLE
    End If

    If CF_Ora_EOF(Usr_Ody) = False Then
        strYM = CF_Ora_GetDyn(Usr_Ody, 0)
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    F_Get_GATUDO = strYM

EXIT_HANDLE:
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function
    
ERR_HANDLE:
    GoTo EXIT_HANDLE
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_InitYM
    '   概要：  初期表示用の月度を取得
    '   引数：　無し
    '   戻値：　月度(YYYYMM)
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Get_InitYM() As String

    Dim strYM                   As String
    Dim datDT                   As Date
    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA

    '初期化
    F_Get_InitYM = ""
    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
    
    'ユーザー情報管理テーブル検索
    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
        Exit Function
    End If
    
    '前回経理締実行日の月度を算出
    strYM = F_Get_GATUDO(Mst_Inf_SYSTBA.SMAUPDDT, Mst_Inf_SYSTBA.SMEDD)

    ''月度＋１月
    datDT = Format(Format(strYM & "01", "@@@@/@@/@@"), "YYYY/MM/DD")
    datDT = DateAdd("d", -1, DateAdd("m", 2, datDT))
    F_Get_InitYM = datDT
'    F_Get_InitYM = Format(datDT, "YYYYMM")

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_TEISYOYM_Inf
    '   概要：  基準日による画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Dsp_HD_TEISYOYM_Inf(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, pm_All As Cls_All) As Integer

    Dim Trg_Index   As Integer
    Dim Focus_Ctl   As Boolean
    Dim Dsp_Value   As Variant
    Dim Wk_Index    As Integer

    If pm_Mode = DSP_SET Then
    '表示
        '項目内容が変更された場合
        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
            
            '復元内容、前回内容を退避
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
        
        End If
    Else
    'クリア
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    End If

    '前回チェック内容に退避
    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub RefreshGauge
'   概要：  ゲージのカウントアップ
'   引数：　pin_intAllLine      : 全体件数
'           pin_intNowCnt       : 処理済件数
'   戻値：　なし
'   備考：  なし
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub InitGauge()
    FR_SSSMAIN.GAUGE.FloodPercent = 0
    FR_SSSMAIN.GAUGE.ForeColor = Cn_BLACK
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub RefreshGauge
'   概要：  ゲージのカウントアップ
'   引数：　pin_intAllLine      : 全体件数
'           pin_intNowCnt       : 処理済件数
'   戻値：　なし
'   備考：  なし
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub RefreshGauge(pin_intAllLine As Integer, pin_intNowCnt As Integer)
    '
    'ゲージの表示
    If pin_intAllLine > 0 And pin_intNowCnt > 0 Then
        FR_SSSMAIN.GAUGE.FloodPercent = pin_intNowCnt / pin_intAllLine * 100
        If FR_SSSMAIN.GAUGE.FloodPercent > 45 Then
            FR_SSSMAIN.GAUGE.ForeColor = Cn_WHITE
        Else
            FR_SSSMAIN.GAUGE.ForeColor = Cn_BLACK
        End If
    End If
    DoEvents
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub ShowGauge
'   概要：  ゲージのカウントアップ
'   引数：　pin_intAllLine      : 全体件数
'           pin_intNowCnt       : 処理済件数
'   戻値：　なし
'   備考：  なし
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub ShowGauge(pin_bolVisible As Boolean)
    
    'ゲージの表示・非表示を設定
    FR_SSSMAIN.GAUGE.Visible = pin_bolVisible
    FR_SSSMAIN.CM_LCANCEL.Visible = pin_bolVisible

End Sub

