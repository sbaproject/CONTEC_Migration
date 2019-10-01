Attribute VB_Name = "AE_CMN"
Option Explicit
'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　共通
'*  モジュール名　　：　業務共通処理
'*  作成者　　　　　：　ACE)長澤
'*  作成日　　　　　：  2006.05.24
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************

'************************************************************************************
'   構造体
'************************************************************************************
    Public Type Cmn_Inp_Inf
        InpTanCd        As String       '入力担当者ＩＤ
        InpTanNm        As String       '入力担当者名
        InpTKCHGKB      As String       '単価変更権限
        InpCLIID        As String       'クライアントＩＤ
' === 20060828 === INSERT S - ACE)Sejima
        InpJDNUPDKB     As String       '受注更新権限
' === 20060828 === INSERT E
' === 20061030 === INSERT S - ACE)Nagasawa 権限の読み方の変更
        InpPRTAUTH      As String       '印刷権限
        InpFILEAUTH     As String       'ファイル出力権限
' === 20061030 === INSERT E -
    End Type
    
' === 20061014 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
    Public Type Cmn_JDNUPDATE_Enable
        bolJHD          As Boolean      'セットアップ発注
        bolFRD          As Boolean      '出荷指示
' === 20070715 === INSERT S - ACE)Nagasawa 出荷指示中でも出荷指示されていない明細は訂正可とする
        bolFRD_TAN      As Boolean      '出荷指示(単品)
        bolSSZ_TAN      As Boolean      '出荷指図（単品）
' === 20070715 === INSERT E -
' === 20061123 === INSERT S - ACE)Nagasawa メーカーコードには出荷指図数を編集
        bolSSZ          As Boolean      '出荷指図
' === 20061123 === INSERT E -
        bolODN          As Boolean      '出荷実績
' === 20061127 === INSERT S - ACE)Nagasawa 海外倉庫からの出荷実績考慮追加
        bolFRNMOV       As Boolean      '海外倉庫移動
' === 20061127 === INSERT E -
        bolURI          As Boolean      '売上
        bolSSA          As Boolean      '請求
        bolNYU          As Boolean      '入金
        bolJDN_End      As Boolean      '受注完了
    End Type
' === 20061014 === INSERT E -

' === 20061217 === INSERT S - ACE)Nagasawa 引当内訳ファイルの更新を行う
    '引当内訳ファイル更新情報
    Public Type Cmn_DTLTRA_Upd
        Moto_TRANO                      As String       '更新前トラン番号
        MOTO_MITNOV                     As String       '更新前版数
        Moto_LINNO                      As String       '更新前行番号
        TRANO                           As String       'トラン番号
        MITNOV                          As String       '版数
        LINNO                           As String       '行番号
        TRADT                           As String       '出荷予定日
    End Type
' === 20061217 === INSERT E -

' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
    '売上トラン請求書区分更新用
    Public Type Cmn_JDNTRA_UDNUpdate
        JDNNO                           As String       '受注番号
        LINNO                           As String       '行番号
        RECNO                           As String       'レコード管理番号
        SBNNO                           As String       '製番
        MRPKB                           As String       '請求書出力区分
    End Type
' === 20071213 === INSERT E -

' === 20070307 === INSERT S - ACE)Nagasawa
    '売上見出しトラン更新内容
    Public Type Cmn_UDNTHA_Upd
        DATNO()                         As String       '伝票管理番号（更新対象）
        DATNO_KRO()                     As String       '伝票管理番号（新/黒伝票用）
        DATNO_AKA()                     As String       '伝票管理番号（新/赤伝票用）
        ODNNO()                         As String       '出荷伝票番号（返品有りの場合のみ採番）
        ODNNO_GetSu                     As Currency     '出荷伝票番号採番数
        UDNNO_KRO()                     As String       '売上伝票番号（新/黒伝票用）
        UDNNO_AKA()                     As String       '売上伝票番号（新/赤伝票用）
' === 20070331 === INSERT S - ACE)Nagasawa 売上訂正返品対応
        FDNNO_KRO()                     As String       '納品書番号（新/黒伝票用）
        FDNNO_AKA()                     As String       '納品書番号（新/赤伝票用）
' === 20070331 === INSERT E -
        UDNNO_GetSu                     As Currency     '出荷伝票番号採番数
        JDNNO                           As String       '受注番号
        FDNNO()                         As String       '納品書番号
        TOKCD                           As String       '得意先コード
        TOKSEICD                        As String       '請求先コード
        UDNDT                           As String       '売上伝票日付（受注訂正日)
        JDNTRKB                         As String       '受注取引区分
        URIKJN                          As String       '売上基準
        TANCD                           As String       '営業担当者コード
        TANNM                           As String       '営業担当者名
        BUMCD                           As String       '営業部門コード
        BUMNM                           As String       '営業部門名
        CLMDL                           As String       '分類型式
        SMADT                           As String       '経理締日付
        SSADT()                         As String       '締日付
        KESDT()                         As String       '決算日付
        SSADT_Chk                       As String       '最大締日付（受注訂正日制御用）
        UDNDENDT_Chk                    As String       '最大売上日付（受注訂正日制御用）
        SMADT_Chk                       As String       '最大経理締日付（受注訂正日制御用）
        MAEUKKB                         As String       '前受区分
        FRNKB                           As String       '海外取引区分
        TUKKB                           As String       '通貨区分
        SSAKBN                          As String       '決算日付計算区分
        TOKZEIKB                        As String       '消費税区分（得意先）
        TOKRPSKB                        As String       '消費税端数処理桁数
        TOKZRNKB                        As String       '消費税端数処理区分
        curUrikn_Old()                  As Currency     '更新前売上金額    （伝票計）
        curFUrikn_Old()                 As Currency     '更新前外貨売上金額（伝票計）
        curUzeikn_Old()                 As Currency     '更新前消費税合計  （伝票計）
        curUrikn_New()                  As Currency     '更新後売上金額    （伝票計）
        curFUrikn_New()                 As Currency     '更新後外貨売上金額（伝票計）
        curUzeikn_New()                 As Currency     '更新後消費税合計  （伝票計）
        curSUrikn_Old                   As Currency     '更新前売上金額    （総合計）
        curSFUrikn_Old                  As Currency     '更新前外貨売上金額（総合計）
        curSUzeikn_Old                  As Currency     '更新前消費税合計　（総合計）
        curSUrikn_New                   As Currency     '更新後売上金額    （総合計）
        curSFUrikn_New                  As Currency     '更新後外貨売上金額（総合計）
        curSUzeikn_New                  As Currency     '更新後消費税合計  （総合計）
        bolAKAKRO()                     As Boolean      '赤黒作成フラグ
        bolUpd                          As Boolean      '更新フラグ(True　: 更新）
        strErr                          As String       'エラー箇所
' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
        usrBodyInf()                    As Cmn_JDNTRA_UDNUpdate     '明細情報
' === 20071213 === INSERT E -
    End Type
    
    '売上トラン更新内容
    Public Type Cmn_UDNTRA_Upd
        JDNNO                           As String       '受注番号
        LINNO                           As String       '行番号
        URILINNO                        As String       '行番号(売上トラン）
        RECNO                           As String       'レコード管理番号
        SBNNO                           As String       '製番
        HINCD                           As String       '製品コード
        TOKJDNNO                        As String       '客先注文番号
        BIKO                            As String       '備考
        URISU                           As Currency     '売上数量
        URITK                           As Currency     '単価
        FURITK                          As Currency     '外貨単価
        SIKTK                           As String       '仕切単価
        URIKN                           As Currency     '売上金額
        FURIKN                          As Currency     '外貨売上金額
        SIKKN                           As Currency     '仕切金額
        UZEKN                           As Currency     '消費税額
        HNURIKN                         As Currency     '返品分売上金額
        HNFURIKN                        As Currency     '返品分外貨売上税額
        HNUZEKN                         As Currency     '返品分消費税額
        HINZEIKB                        As String       '商品消費税区分
        ZEIRT                           As String       '税率
        bolHNPN                         As Boolean      '返品フラグ（True : 返品有り）
        bolUpd                          As Boolean      '更新フラグ（True : 更新）
        Bd_Index                        As Integer      '受注訂正画面の該当行
' === 20071213 === INSERT S - ACE)Nagasawa 請求書出力区分の追加
        MRPKB                           As String       '請求書出力区分
' === 20071213 === INSERT E -
    End Type
' === 20070307 === INSERT E -
'************************************************************************************
'   Public定数
'************************************************************************************
    '端数計算桁数
    Public Const gc_strRPSKB_D1     As String = "1"         '小数第一位
    Public Const gc_strRPSKB_D2     As String = "2"         '小数第二位
    Public Const gc_strRPSKB_D3     As String = "3"         '小数第三位
    Public Const gc_strRPSKB_D4     As String = "4"         '小数第四位
    Public Const gc_strRPSKB_D5     As String = "5"         '小数第五位
    Public Const gc_strRPSKB_I1     As String = "10"         '１
    Public Const gc_strRPSKB_I2     As String = "11"         '１０
    Public Const gc_strRPSKB_I3     As String = "12"         '１００
    
' === 20070908 === INSERT S - ACE)Nagasawa 受注番号"RA000T"と"RA001T"は行追加行わないように修正(受注番号採番ミス)
    Public Const gc_strJDNNO_RA000T  As String = "RA000T"
    Public Const gc_strJDNNO_RA001T  As String = "RA001T"
' === 20070908 === INSERT E -
'************************************************************************************
'   Public変数
'************************************************************************************
    Public Inp_Inf                  As Cmn_Inp_Inf          '入力者情報
    Public GV_SysDate               As String               'ＤＢサーバー日付
    Public GV_SysTime               As String               'ＤＢサーバー時刻
    Public GV_UNYDate               As String               '運用日付
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
    Public GV_bolMsgFlg             As Boolean              'メッセージ出力フラグ
' === 20060920 === INSERT E

'************************************************************************************
'   Private定数
'************************************************************************************
' === 20060828 === INSERT S - ACE)Sejima
    '権限グループ判定用
    Private Const mc_intCD          As Integer = 1          '権限グループ設定あり
    Private Const mc_intOLDCD       As Integer = 2          '旧権限グループ設定あり
    Private Const mc_intTKDT        As Integer = 4          '適用日設定あり
' === 20060828 === INSERT E
'************************************************************************************
'   Private変数
'************************************************************************************
    Dim strINIDATNM(4)  As String           'ＩＮＩのシンボル
    
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
'************************************************************************************
'   キーバッファクリア用API
'************************************************************************************
Private Type POINTAPI
    X As Long
    Y As Long
End Type
Private Type Msg
    hwnd    As Long
    message As Long
    wParam  As Long
    lParam  As Long
    time    As Long
    pt      As POINTAPI
End Type
Private Declare Function PeekMessage Lib "user32" Alias "PeekMessageA" _
        (lpMsg As Msg, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, _
         ByVal wMsgFilterMax As Long, ByVal wRemoveMsg As Long) As Long
Private Const WM_KEYFIRST = &H100
Private Const WM_KEYLAST = &H108
Private Const PM_REMOVE = &H1
' === 20060920 === INSERT E
    
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Init
'   概要：  プログラム起動時初期処理
'   引数：  なし
'   戻値：  なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub CF_Init()

    Dim datDT           As Date
    Dim DB_TANMTA       As TYPE_DB_TANMTA
    Dim DB_UNYMTA       As TYPE_DB_UNYMTA
    Dim strYMD          As String
    Dim intLenCommand   As String
    Dim intRet          As Integer
'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    Dim strRet          As String
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

    '二重起動ﾁｪｯｸ
    If App.PrevInstance Then
        MsgBox "【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", vbExclamation Or vbOKOnly, SSS_PrgNm
        End
    End If

    ' "しばらくお待ちください" ウィンドウ表示
    Load ICN_ICON
    
'   日付形式チェック
    datDT = Date
    strYMD = Format(Year(datDT), "0000") & "/" & Format(Month(datDT), "00") & "/" & Format(Day(datDT), "00")
    
    If CStr(datDT) <> strYMD Then
        MsgBox "日付の形式 '" & CStr(datDT) & "' が違います。" & vbCrLf _
             & "コントロールパネルの地域（地球の絵）の日付" & vbCrLf _
             & "の短い形式を yyyy/MM/dd に変更して下さい。", vbCritical
        Call Error_Exit("日付の形式が違います。")
    End If
    
    '---------------------
    ' 起動パラメータ設定
    '---------------------
    intLenCommand = LenWid(Trim$(Command$))
    If intLenCommand < 15 Then
        MsgBox "メニューから実行してください。", vbOKOnly, SSS_PrgNm
        Call Error_Exit("メニューから実行してください。")
    End If
    
    SSS_CLTID = MidWid$(Command$, 2, 5)
    SSS_OPEID = MidWid$(Command$, 7, 8)

    'リードオンリーモード設定
    If Left$(Command$, 1) = "'" Then SSS_ReadOnly = True

' === 20060828 === INSERT S - ACE)Sejima 単価変更権限取得に必要なため、下から移動
    '運用日付取得
    Call CF_Get_UnyDt
' === 20060828 === INSERT E
    
    '入力担当者名取得
    Inp_Inf.InpTanCd = SSS_OPEID
    Inp_Inf.InpCLIID = SSS_CLTID
    
'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    '入力担当者情報設定
    gs_userid = SSS_OPEID
    gs_pgid = SSS_PrgId
    
    '権限取得
    strRet = Get_Authority(GV_UNYDate)
    If strRet = "9" Then
        '起動権限なしの場合、処理終了
        Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2RUNAUTH")
        End
    End If
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

' === 20060830 === UPDATE S - ACE)Nagasawa 権限の考慮の修正
'    Call DB_TANMTA_Clear(DB_TANMTA)
'    intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
'    If intRet = 0 Then
'        Inp_Inf.InpTanNm = DB_TANMTA.TANNM              '入力担当者名
'' === 20060828 === UPDATE S - ACE)Sejima
''D        Inp_Inf.InpTKCHGKB = DB_TANMTA.TKCHGKB          '単価変更権限
'' === 20060828 === UPDATE ↓
'        '権限情報取得（単価変更権限、受注更新権限、etc...）
'        Call F_Get_KNG_Inf(DB_TANMTA, GV_UNYDate, Inp_Inf)
'' === 20060828 === UPDATE E
'    End If

    '入力担当者情報取得
    Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf)
' === 20060830 === UPDATE E -
    
    '---------------------
    ' SSSWIN.INI テーブル設定
    '---------------------
    strINIDATNM(0) = "USR_PATH"
    strINIDATNM(1) = "DAT_PATH"
    strINIDATNM(2) = "PRG_PATH"
    strINIDATNM(3) = "WRK_PATH"
    strINIDATNM(4) = "IMG_PATH"
    SSS_INICnt = 4
    'Iniファイル読込み
    Call CF_INIT_GETINI
    
' === 20060828 === DELETE S - ACE)Sejima 単価変更権限取得に必要なため、上に移動
'D    '運用日付取得
'D    Call CF_Get_UnyDt
' === 20060828 === DELETE E
    
' === 20061102 === INSERT S - ACE)Yano ﾛｸﾞﾌｧｲﾙ書込み（プログラム起動）
    Call SSSWIN_LOGWRT("プログラム起動")
' === 20061102 === INSERT E
    
    ' "しばらくお待ちください" ウィンドウ消去
    Unload ICN_ICON

End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_INIT_GETINI
    '   概要：  INIファイル読込み（共通）
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Sub CF_INIT_GETINI()
    Dim WL_WinDir As String, I As Integer, LENGTH As Integer
    Dim rtnPara As String * MAX_PATH
    '---------------------
    ' SSSWIN.INI 読込み
    '---------------------
    For I = 0 To SSS_INICnt
        rtnPara = ""
        LENGTH = GetPrivateProfileString("SSSWIN", ByVal strINIDATNM(I), "", rtnPara, Len(rtnPara), ByVal "SSSWIN.INI")
        If LENGTH = 0 Then
            MsgBox "SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(I) & "]"
            Call Error_Exit("SSSUSR.INI を確認してください。[" & strINIDATNM(I) & "]")
        Else
            SSS_INIDAT(I) = LeftWid$(rtnPara, LENGTH)
        End If
        If Right$(SSS_INIDAT(I), 1) <> "\" And Right$(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
    Next I
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_DspLineNo
    '   概要：  表示用行番号取得
    '   引数：　pm_Def_LineNo
    '           pm_HIKET51_DSP_DATA    :画面業務情報構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function F_Get_DspLineNo(pm_Def_LineNo As String, pm_JdnTrKb As String) As String

    Dim Ret_Value        As String
    
    Select Case pm_JdnTrKb
        Case gc_strJDNTRKB_SET
            'セットアップは頭２桁
            Ret_Value = Mid$(pm_Def_LineNo, 1, 2)
        
        Case Else
            '以外は後２桁
            Ret_Value = Mid$(pm_Def_LineNo, 2, 2)
    
    End Select
    
    F_Get_DspLineNo = Ret_Value
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_TANNM
    '   概要：  担当者名称取得
    '   引数：　pm_Def_LineNo
    '           pm_HIKET51_DSP_DATA    :画面業務情報構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_TANNM(pm_TANCD As String) As String

    Dim Ret_Value        As String
    Dim DB_TANMTA        As TYPE_DB_TANMTA
    Dim intRet           As Integer
    
    Ret_Value = ""
    
    '担当者マスタ検索
    Call DB_TANMTA_Clear(DB_TANMTA)
    intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
    If intRet = 0 Then
        Ret_Value = DB_TANMTA.TANNM
    End If
    
    CF_Get_TANNM = Ret_Value
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_Location
    '   概要：  初期表示位置設定
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Set_Frm_Location(pm_Form As Form) As Integer

    With pm_Form
        .Left = (Screen.Width - .Width) / 2
        .Top = (Screen.Height - .Height) / 2
    End With
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_IN_TANCD
    '   概要：  入力担当者編集
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Set_Frm_IN_TANCD(pm_Form As Form, pm_All As Cls_All) As Integer

    Dim Trg_Index       As Integer
    Dim Dsp_Value       As Variant
    
    With pm_Form
        '入力担当者コード
        Trg_Index = CInt(.HD_IN_TANCD.Tag)
        Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        
        '入力担当者名
        Trg_Index = CInt(.HD_IN_TANNM.Tag)
        Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
    End With
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_SYSTBASaiban
'   概要：  伝票管理NO採番処理
'   引数：　Pm_strDATNO()  :伝票管理No
'           Pm_strRECNO()  :レコード管理No
'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_SYSTBASaiban(ByRef pot_strDatNo() As String, _
                                       ByRef pot_strRECNO() As String) As Integer

    Dim strSQL                              As String
    Dim usrOdy                              As U_Ody
    Dim bolRet                              As Boolean
    Dim bolTran                             As Boolean
    Dim curDatNo                            As Currency
    Dim curRecNo                            As Currency
    Dim intCnt                              As Integer
    Dim strDATNO                            As String
    Dim strRecNo                            As String

On Error GoTo ERR_AE_SYSTBASaiban

    AE_SYSTBASaiban = 9
    
    bolTran = False

    'トランザクション開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTran = True

    'ユーザー情報管理テーブル取得
    strSQL = ""
    strSQL = strSQL & " Select *             "
    strSQL = strSQL & "   from SYSTBA        "
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    strSQL = strSQL & "    for Update NoWait "
    strSQL = strSQL & "    for Update  "
' === 20061108 === UPDATE E -

    'SQL実行
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
' === 20061108 === UPDATE E -
    If bolRet = False Then
        GoTo ERR_AE_SYSTBASaiban
    End If

    'EOF判定
    If CF_Ora_EOF(usrOdy) = True Then
        AE_SYSTBASaiban = 1
        GoTo ERR_AE_SYSTBASaiban
    End If

    '伝票管理No取得
    curDatNo = CCur(CF_Ora_GetDyn(usrOdy, "DATNO", "0")) + 1
    If curDatNo > 9999999999# Then
        '9999999999を超えた場合は戻る
        curDatNo = 1
    End If
    For intCnt = 1 To UBound(pot_strDatNo)
        pot_strDatNo(intCnt) = Format(CStr(curDatNo), "0000000000")
        curDatNo = curDatNo + 1
        If curDatNo > 9999999999# Then
            '9999999999を超えた場合は戻る
            curDatNo = 1
        End If
    Next intCnt

    'レコード管理No取得
    curRecNo = CCur(CF_Ora_GetDyn(usrOdy, "RECNO", "0")) + 1
    If curRecNo > 9999999999# Then
        '9999999999を超えた場合は戻る
        curRecNo = 1
    End If
    
    For intCnt = 1 To UBound(pot_strRECNO)
        pot_strRECNO(intCnt) = Format(CStr(curRecNo), "0000000000")
        curRecNo = curRecNo + 1
        If curRecNo > 9999999999# Then
            '9999999999を超えた場合は戻る
            curRecNo = 1
        End If
    Next intCnt

    'ユーザー情報管理テーブル更新
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    usrOdy.Obj_Ody.Edit
'    usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
'    If UBound(Pot_strRECNO) > 0 Then
'        usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
'    End If
'    If Trim(GV_SysTime) <> "" Then
'        usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
'    End If
'    If Trim(GV_SysDate) <> "" Then
'        usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
'    End If
'    usrOdy.Obj_Ody.Update
    
    If Trim(pot_strDatNo(UBound(pot_strDatNo))) = "" Then
        strDATNO = CF_Ora_GetDyn(usrOdy, "DATNO", "")
    Else
        strDATNO = pot_strDatNo(UBound(pot_strDatNo))
    End If
    
    If Trim(pot_strRECNO(UBound(pot_strRECNO))) = "" Then
        strRecNo = CF_Ora_GetDyn(usrOdy, "RECNO", "")
    Else
        strRecNo = pot_strRECNO(UBound(pot_strRECNO))
    End If
    
    strSQL = ""
    strSQL = strSQL & " UPDATE SYSTBA "
    strSQL = strSQL & "    SET DATNO = '" & strDATNO & "' "
    strSQL = strSQL & "      , RECNO = '" & strRecNo & "' "
    
    'ＳＱＬ実行
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo ERR_AE_SYSTBASaiban
    End If
' === 20061108 === UPDATE E -

    bolRet = CF_Ora_CloseDyn(usrOdy)
    If bolRet = False Then
        GoTo ERR_AE_SYSTBASaiban
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTran = False

    AE_SYSTBASaiban = 0

EXIT_AE_SYSTBASaiban:
    Exit Function

ERR_AE_SYSTBASaiban:

' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    If gv_Int_OraErr = 54 Then
    If gv_Int_OraErr = 2049 Then
' === 20061108 === UPDATE E -
        '他で使用中
        AE_SYSTBASaiban = 2
    End If

    If bolTran = True Then
        'ロールバック
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If

    GoTo EXIT_AE_SYSTBASaiban

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_SYSTBCSaiban
'   概要：  伝票NO採番処理
'   引数：　Pin_strDKBSB     :採番対象の伝票取引区分種別
'           Pot_strDENNO     :取得された伝票№
'           Pin_strADDDENCD  :見積番号の採番の場合、処理年月(数字６桁）
'           Pin_strKbn       :受注番号の場合取引区分
'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, _
                                       ByRef Pot_strDENNO As String, _
                                       Optional ByVal Pin_strADDDENCD As String, _
                                       Optional ByVal Pin_strKbn As String) As Integer

    Dim strSQL                              As String
    Dim usrOdy                              As U_Ody
    Dim bolRet                              As Boolean
    Dim bolTran                             As Boolean
    Dim curDENNO                            As Currency
    Dim strDenNo                            As String
    Dim intCnt                              As Integer
    Dim strRtn                              As String
    Dim strFixCd                            As String
' === 20060814 === INSERT S - ACE)Nagasawa
    Dim intRet                              As Integer
' === 20060814 === INSERT E -
' === 20061119 === INSERT S - ACE)Nagasawa
    Dim strDate                             As String
    Dim strTime                             As String
' === 20061119 === INSERT E -
' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
    Dim bolJDNNO_OK                         As Boolean
    Dim usrOdy_JDN                          As U_Ody
' === 20070909 === INSERT E -

On Error GoTo ERR_AE_SYSTBCSaiban

    AE_SYSTBCSaiban = 9
    
    bolTran = False
    Pot_strDENNO = ""
    strFixCd = ""

    If IsMissing(Pin_strADDDENCD) = True And Pin_strDKBSB = gc_strDKBSB_MIT Then
        GoTo EXIT_AE_SYSTBCSaiban
    End If
    
    'トランザクション開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTran = True
            
    Select Case Pin_strDKBSB
        '見積番号の採番
        Case gc_strDKBSB_MIT
            
' === 20060814 === UPDATE S - ACE)Nagasawa
'            'ユーザー伝票Noテーブル取得
'            strSQL = ""
'            strSQL = strSQL & " Select *             "
'            strSQL = strSQL & "   from SYSTBC        "
'            strSQL = strSQL & "  Where DKBSB    = '" & Pin_strDKBSB & "' "
'            strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
'            strSQL = strSQL & "    for Update NoWait "
'
'            'SQL実行
'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
'            If bolRet = False Then
'                GoTo ERR_AE_SYSTBCSaiban
'            End If
'
'            'EOF判定
'            If CF_Ora_EOF(usrOdy) = True Then
'                Pot_strDENNO = "00000001"
'                'ユーザー伝票Noテーブル追加
'                usrOdy.Obj_Ody.AddNew
'                usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT              '伝票取引区分種別
'                usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD           '伝票付属ｺｰﾄﾞ
'                usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT              '伝票名称
'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '伝票No
'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
'                If Trim(GV_SysTime) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               'タイムスタンプ（時間）
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
'                End If
'                If Trim(GV_SysDate) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               'タイムスタンプ（日付）
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
'                End If
'                usrOdy.Obj_Ody.Update
'            Else
'                curDenNo = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
'
'                '見積番号は４桁
'                If curDenNo > 9999 Then
'                    curDenNo = 1
'                End If
'                strDenNo = Format(CStr(curDenNo), "00000000")
'
'                Pot_strDENNO = strDenNo
'
'                'ユーザー伝票Noテーブル更新
'                usrOdy.Obj_Ody.Edit
'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                     '伝票No
'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
'                If Trim(GV_SysTime) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
'                End If
'                If Trim(GV_SysDate) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
'                End If
'                usrOdy.Obj_Ody.Update
'            End If
'
'            bolRet = CF_Ora_CloseDyn(usrOdy)
'            If bolRet = False Then
'                    GoTo ERR_AE_SYSTBCSaiban
'            End If

            '見積番号採番処理
            intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
            If intRet <> 0 Then
                AE_SYSTBCSaiban = intRet
                GoTo ERR_AE_SYSTBCSaiban
            End If
' === 20060814 === UPDATE E -
            
        '受注番号の採番
        Case gc_strDKBSB_UOD
            '採番マスタ取得
            strSQL = ""
            strSQL = strSQL & " Select *             "
            strSQL = strSQL & "   from SAIMTA        "
            strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'            strSQL = strSQL & "    for Update NoWait "
            strSQL = strSQL & "    for Update "
' === 20061108 === UPDATE E -
            
            'SQL実行
' === 20061119 === UPDATE S - ACE)Nagasawa
'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
' === 20061119 === UPDATE E -
            If bolRet = False Then
                GoTo ERR_AE_SYSTBCSaiban
            End If
            
' === 20061119 === INSERT S - ACE)Nagasawa
            'タイムスタンプ決定
            strDate = ""
            strTime = ""
            If Trim(GV_SysTime) <> "" Then
'                strDate = GV_SysTime
                strDate = GV_SysDate
                strTime = GV_SysTime
            Else
                strDate = CStr(Format(Now, "yyyymmdd"))
                strTime = CStr(Format(Now, "hhmmss"))
            End If
' === 20061119 === INSERT E -

            'EOF判定
            If CF_Ora_EOF(usrOdy) = True Then
' === 20060927 === UPDATE S - ACE)Nagasawa
'                Pot_strDENNO = "00001"
                Pot_strDENNO = "0001"
' === 20060927 === UPDATE E -

' === 20070909 === INSERT S - ACE)Nagasawa
                strFixCd = "R"
' === 20070909 === INSERT E - ACE)Nagasawa

                'ユーザー伝票Noテーブル追加
' === 20061119 === UPDATE S - ACE)Nagasawa
'                usrOdy.Obj_Ody.AddNew
'                usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD            '伝票種別
'                usrOdy.Obj_Ody.Fields("FIXCD").Value = "R"                          '固定値
'                strFixCd = "R"
'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '連番
'                usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1)                    '区分１
'                usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1)                    '区分２
'                usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1)                    '区分３
'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
'                If Trim(GV_SysTime) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               'タイムスタンプ（時間）
'                    usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime            'タイムスタンプ（登録時間）
'                End If
'                If Trim(GV_SysDate) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               'タイムスタンプ（日付）
'                    usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate            'タイムスタンプ（登録日付）
'                End If
'                usrOdy.Obj_Ody.Update
                
                strSQL = ""
' === 20070909 === UPDATE S - ACE)Nagasawa
'                strSQL = strSQL & " INSERT INTO SYSTBC "
                strSQL = strSQL & " INSERT INTO SAIMTA "
                strSQL = strSQL & " ( "
' === 20070909 === UPDATE E -
                strSQL = strSQL & "     SDKBSB    "
                strSQL = strSQL & "   , FIXCD     "
                strSQL = strSQL & "   , SDENNO    "
                strSQL = strSQL & "   , SAIKBA    "
                strSQL = strSQL & "   , SAIKBB    "
                strSQL = strSQL & "   , SAIKBC    "
                strSQL = strSQL & "   , FOPEID    "
                strSQL = strSQL & "   , FCLTID    "
                strSQL = strSQL & "   , WRTFSTTM  "
                strSQL = strSQL & "   , WRTFSTDT  "
                strSQL = strSQL & "   , OPEID     "
                strSQL = strSQL & "   , CLTID     "
                strSQL = strSQL & "   , WRTTM     "
                strSQL = strSQL & "   , WRTDT     "
                strSQL = strSQL & "   , UOPEID    "
                strSQL = strSQL & "   , UCLTID    "
                strSQL = strSQL & "   , UWRTTM    "
                strSQL = strSQL & "   , UWRTDT    "
                strSQL = strSQL & "   , PGID      "
' === 20070909 === INSERT S - ACE)Nagasawa
                strSQL = strSQL & " ) "
' === 20070909 === INSERT E -
                strSQL = strSQL & " VALUES  "
                strSQL = strSQL & "   ( '" & gc_strSDKBSB_UOD & "' "
                strSQL = strSQL & "   , '" & "R" & "' "
                strSQL = strSQL & "   , '" & Pot_strDENNO & "' "
' === 20070909 === UPDATE S - ACE)Nagasawa
'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
                strSQL = strSQL & "   , '" & Space(1) & "' "
                strSQL = strSQL & "   , '" & Space(1) & "' "
                strSQL = strSQL & "   , '" & Space(1) & "' "
' === 20070909 === UPDATE E -
                strSQL = strSQL & "   , '" & SSS_OPEID & "' "
                strSQL = strSQL & "   , '" & SSS_CLTID & "' "
                strSQL = strSQL & "   , '" & strTime & "' "
                strSQL = strSQL & "   , '" & strDate & "' "
                strSQL = strSQL & "   , '" & SSS_OPEID & "' "
                strSQL = strSQL & "   , '" & SSS_CLTID & "' "
                strSQL = strSQL & "   , '" & strTime & "' "
                strSQL = strSQL & "   , '" & strDate & "' "
                strSQL = strSQL & "   , '" & SSS_OPEID & "' "
                strSQL = strSQL & "   , '" & SSS_CLTID & "' "
                strSQL = strSQL & "   , '" & strTime & "' "
                strSQL = strSQL & "   , '" & strDate & "' "
                strSQL = strSQL & "   , '" & SSS_PrgId & "') "
' === 20061119 === UPDATE E -
            Else
                '連番取得
                strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
                strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")
                
                If strDenNo = "" Then
                    GoTo ERR_AE_SYSTBCSaiban
                End If
                
' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
                bolJDNNO_OK = False
                Do Until bolJDNNO_OK = True
' === 20070909 === INSERT E -

                    '受注番号
                    For intCnt = 4 To 1 Step -1
'CHG START FKS)INABA 2007/09/07 *************************************************************************
                        bolRet = JDNNO_CntUp(Mid(strDenNo, intCnt, 1), strRtn)
                        strDenNo = Left(strDenNo, intCnt - 1) & strRtn & Mid(strDenNo, intCnt + 1)
    '                    bolRet = JDNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
    '                    strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
'CHG  END  FKS)INABA 2007/09/07 *************************************************************************
                        If bolRet = False Then
                            Exit For
                        End If
                    Next intCnt
                
    ' === 20060927 === INSERT S - ACE)Nagasawa
    '                If strDenNo = "00000" Then
    '                   strDenNo = "00001"
    '                End If
                    If Trim(strDenNo) = "0000" Then
                       strDenNo = "0001 "
                    End If
    ' === 20060927 === INSERT E -
                    
' === 20070909 === INSERT S - ACE)Nagasawa 受注番号が既に受注見出しトランに存在する場合はとばす("RA000T"と"RA001T"は使用不可)
                    '"RA000T"と"RA001T"は除外
                    If Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA000T, 3, 4) _
                    And Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA001T, 3, 4) Then
                        '受注マスタ検索
                        strSQL = ""
                        strSQL = strSQL & " Select JDNNO         "
                        strSQL = strSQL & "   from JDNTHA        "
                        strSQL = strSQL & "  Where JDNNO IN ('" & strFixCd & "A" & Mid(strDenNo, 1, 4) & "' "
                        strSQL = strSQL & "                , '" & strFixCd & "B" & Mid(strDenNo, 1, 4) & "' "
                        strSQL = strSQL & "                , '" & strFixCd & "S" & Mid(strDenNo, 1, 4) & "')"
                        
                        'SQL実行
                        bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_JDN, strSQL)
                        If bolRet = False Then
                            GoTo ERR_AE_SYSTBCSaiban
                        End If
            
                        'EOF判定
                        If CF_Ora_EOF(usrOdy_JDN) = True Then
                            bolJDNNO_OK = True
                        End If
                        
                        bolRet = CF_Ora_CloseDyn(usrOdy_JDN)
                        If bolRet = False Then
                            GoTo ERR_AE_SYSTBCSaiban
                        End If
                    End If
                    
                Loop
' === 20070909 === INSERT E -
                
                Pot_strDENNO = strDenNo
        
                'ユーザー伝票Noテーブル更新
' === 20061119 === UPDATE S - ACE)Nagasawa
'                usrOdy.Obj_Ody.Edit
'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '伝票No
'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
'                If Trim(GV_SysTime) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
'                End If
'                If Trim(GV_SysDate) <> "" Then
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
'                Else
'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
'                End If
'                usrOdy.Obj_Ody.Update
                
                strSQL = ""
                strSQL = strSQL & " UPDATE SAIMTA "
                strSQL = strSQL & " SET "
                strSQL = strSQL & "     SDENNO = '" & Pot_strDENNO & "' "
                strSQL = strSQL & "   , OPEID  = '" & SSS_OPEID & "' "
                strSQL = strSQL & "   , CLTID  = '" & SSS_CLTID & "' "
                strSQL = strSQL & "   , WRTTM  = '" & strTime & "' "
                strSQL = strSQL & "   , WRTDT  = '" & strDate & "' "
                strSQL = strSQL & "   , UOPEID = '" & SSS_OPEID & "' "
                strSQL = strSQL & "   , UCLTID = '" & SSS_CLTID & "' "
                strSQL = strSQL & "   , UWRTTM = '" & strTime & "' "
                strSQL = strSQL & "   , UWRTDT = '" & strDate & "' "
                strSQL = strSQL & "   , PGID   = '" & SSS_PrgId & "' "
                strSQL = strSQL & "  WHERE SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
' === 20061119 === UPDATE E -
            End If
            
' === 20061119 === INSERT S - ACE)Nagasawa
            'SQL実行
            bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            If bolRet = False Then
                GoTo ERR_AE_SYSTBCSaiban
            End If
' === 20061119 === INSERT E -
        
            bolRet = CF_Ora_CloseDyn(usrOdy)
            If bolRet = False Then
                    GoTo ERR_AE_SYSTBCSaiban
            End If
            
    End Select
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTran = False

    '採番
    Select Case Pin_strDKBSB
        '見積番号
        Case gc_strDKBSB_MIT
            Pot_strDENNO = Mid(Pin_strADDDENCD, 3, 4) & Mid(Pot_strDENNO, 5, 4)
        
        '受注番号
        Case gc_strDKBSB_UOD
            Select Case Pin_strKbn
' === 20060927 === UPDATE S - ACE)Nagasawa
'                Case gc_strJDNTRKB_TAN                     '単品
'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_SET                     'セットアップ
'                    Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_SYS                     'システム
'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_SYR                     '修理
'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_HSY                     '保守
'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_KAS                     '貸出
'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
'                Case gc_strJDNTRKB_ELS                     'その他
'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
                Case gc_strJDNTRKB_TAN                     '単品
                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_SET                     'セットアップ
                    Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_SYS                     'システム
                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_SYR                     '修理
                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_HSY                     '保守
                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_KAS                     '貸出
                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
                Case gc_strJDNTRKB_ELS                     'その他
                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
' === 20060927 === UPDATE E -
                Case Else
            End Select
        Case Else
            
    End Select
    
    AE_SYSTBCSaiban = 0

EXIT_AE_SYSTBCSaiban:
    Exit Function

ERR_AE_SYSTBCSaiban:

' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    If gv_Int_OraErr = 54 Then
    If gv_Int_OraErr = 51 Then
' === 20061108 === UPDATE E -
        '他で使用中
        AE_SYSTBCSaiban = 2
    End If

    If bolTran = True Then
        'ロールバック
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If

    GoTo EXIT_AE_SYSTBCSaiban

End Function

' === 20060814 === INSERT S - ACE)Nagasawa
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function F_SYSTBC_Update
'   概要：  SYSTBC更新処理
'   引数：　Pin_strADDDENCD  :処理年月(数字６桁）
' 　　　　　Pot_strDENNO     :取得された伝票№
'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Static Function F_SYSTBC_Update(ByVal Pin_strADDDENCD As String, _
                                        ByRef Pot_strDENNO As String) As Integer

    Dim strSQL                              As String
    Dim usrOdy                              As U_Ody
    Dim bolRet                              As Boolean
    Dim curDENNO                            As Currency
    Dim strDenNo                            As String
    Dim strSTTNO                            As String
    Dim strENDNO                            As String

On Error GoTo ERR_F_SYSTBC_Update

    F_SYSTBC_Update = 9

    Pot_strDENNO = ""
    strSTTNO = ""
    strENDNO = ""
  
    'ユーザー伝票Noテーブル取得
    strSQL = ""
    strSQL = strSQL & " Select *             "
    strSQL = strSQL & "   from SYSTBC        "
    strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_MIT & "' "
    strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    strSQL = strSQL & "    for Update NoWait "
    strSQL = strSQL & "    for Update "
' === 20061108 === UPDATE E -
    
    'SQL実行
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
    If bolRet = False Then
        GoTo ERR_F_SYSTBC_Update
    End If

    'EOF判定
    If CF_Ora_EOF(usrOdy) = True Then
        strSTTNO = "00000001"
        strENDNO = "00009999"
        Pot_strDENNO = strSTTNO
        'ユーザー伝票Noテーブル追加
        usrOdy.Obj_Ody.AddNew
        usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT              '伝票取引区分種別
        usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD           '伝票付属ｺｰﾄﾞ
        usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT              '伝票名称
        usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '伝票No
        usrOdy.Obj_Ody.Fields("STTNO").Value = strSTTNO                     '開始伝票NO.
        usrOdy.Obj_Ody.Fields("ENDNO").Value = strENDNO                     '終了伝票NO.
        usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '伝票No
        usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
        usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
        If Trim(GV_SysTime) <> "" Then
            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               'タイムスタンプ（時間）
            usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime            'タイムスタンプ（登録時間）
        Else
            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
            usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = CStr(Format(Now, "hhmmss"))
        End If
        If Trim(GV_SysDate) <> "" Then
            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               'タイムスタンプ（日付）
            usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate            'タイムスタンプ（登録日付）
        Else
            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
            usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = CStr(Format(Now, "yyyymmdd"))
        End If
        usrOdy.Obj_Ody.Update
    Else
        curDENNO = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
        strSTTNO = CF_Ora_GetDyn(usrOdy, "STTNO", "0")
        strENDNO = CF_Ora_GetDyn(usrOdy, "ENDNO", "")
        If IsNumeric(strENDNO) = False Then
            strENDNO = "00009999"
        End If
        
        '見積番号は４桁
        If curDENNO > CF_Get_CCurString(strENDNO) Then
            curDENNO = CF_Get_CCurString(strSTTNO)
        End If
        strDenNo = Format(CStr(curDENNO), String(8, "0"))
        
        Pot_strDENNO = strDenNo

        'ユーザー伝票Noテーブル更新
        usrOdy.Obj_Ody.Edit
        usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '伝票No
        usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '最終作業者ｺｰﾄﾞ
        usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    'クライアントID
        If Trim(GV_SysTime) <> "" Then
            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
        Else
            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
        End If
        If Trim(GV_SysDate) <> "" Then
            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
        Else
            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
        End If
        usrOdy.Obj_Ody.Update
    End If

    bolRet = CF_Ora_CloseDyn(usrOdy)
    If bolRet = False Then
            GoTo ERR_F_SYSTBC_Update
    End If
    
    F_SYSTBC_Update = 0

EXIT_F_SYSTBC_Update:
    Exit Function

ERR_F_SYSTBC_Update:

' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    If gv_Int_OraErr = 54 Then
    If gv_Int_OraErr = 51 Then
' === 20061108 === UPDATE E -
        '他で使用中
        F_SYSTBC_Update = 2
    End If

    GoTo EXIT_F_SYSTBC_Update

End Function
' === 20060814 === INSERT E -

' === 20060815 === INSERT S - ACE)Nagasawa
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_SYSTBCSaiban_PUDLNO
'   概要：  入出庫番号採番処理
'   引数：　Pm_strJDNTRKB   :受注取引区分
'           Pm_strPUDLNO()  :入出庫番号
'           Pm_intEntryKb   :登録訂正区分（1:登録　2:訂正）
'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060822 === UPDATE S - ACE)Sejima 入出庫番号採番処理
'DPublic Static Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, _
'D                                              ByRef Pm_strPUDLNO() As String) As Integer
' === 20060822 === UPDATE ↓
Public Static Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, _
                                              ByRef Pm_strPUDLNO() As String, _
                                     Optional ByVal Pm_intEntryKb As Integer = 1) As Integer
' === 20060822 === UPDATE E

    Dim strSQL                              As String
    Dim usrOdy                              As U_Ody
    Dim bolRet                              As Boolean
    Dim bolTran                             As Boolean
    Dim curDENNO                            As Currency
    Dim curSTTNO                            As Currency
    Dim curENDNO                            As Currency
    Dim strADDDENCD                         As String
    Dim intCnt                              As Integer
    Dim intGetData                          As Integer
' === 20060822 === INSERT S - ACE)Sejima
    Dim strNewPUDLNO                        As String        'SYSTBC更新用
' === 20060822 === INSERT E

On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO

    AE_SYSTBCSaiban_PUDLNO = 9
    
    bolTran = False
    
    intGetData = 0
    '受注取引区分により判定
    Select Case Pm_strJDNTRKB
        '単品、システム、その他
        Case gc_strJDNTRKB_TAN, gc_strJDNTRKB_SYS, gc_strJDNTRKB_ELS
            intGetData = UBound(Pm_strPUDLNO)
            
        'セットアップ
        Case gc_strJDNTRKB_SET
' === 20070312 === UPDATE S - ACE)Nagasawa セットアップも入出庫番号は全部取得
'' === 20060822 === UPDATE S - ACE)Sejima 入出庫番号採番処理
''D            intGetData = 1
'' === 20060822 === UPDATE ↓
'            Select Case Pm_intEntryKb
'                Case 1
'                    '登録の場合
'                    intGetData = 1
'                Case Else
'                    '訂正の場合
'                    intGetData = 0
'
'            End Select
'' === 20060822 === UPDATE E
            intGetData = UBound(Pm_strPUDLNO)
' === 20070312 === UPDATE E -
        
        '修理、保守、貸出
        Case gc_strJDNTRKB_SYR, gc_strJDNTRKB_HSY, gc_strJDNTRKB_KAS
            intGetData = 0
        
        Case Else
    End Select
    
    'トランザクション開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTran = True

    'ユーザー伝票№テーブル取得
    strSQL = ""
    strSQL = strSQL & " Select *             "
    strSQL = strSQL & "   from SYSTBC        "
    strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    strSQL = strSQL & "    for Update NoWait "
    strSQL = strSQL & "    for Update "
' === 20061108 === UPDATE E -

    'SQL実行
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
' === 20061108 === UPDATE E -
    If bolRet = False Then
        GoTo ERR_AE_SYSTBCSaiban_PUDLNO
    End If

    'EOF判定
    If CF_Ora_EOF(usrOdy) = True Then
        AE_SYSTBCSaiban_PUDLNO = 1
        GoTo ERR_AE_SYSTBCSaiban_PUDLNO
    End If

    '伝票付属コード取得
    strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
    
    '開始伝票No取得
    If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
        curSTTNO = 1
    Else
        curSTTNO = CCur(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
    End If
    
    '終了伝票No取得
    If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
        curENDNO = 1
    Else
        curENDNO = CCur(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
    End If
    
    '伝票NO.取得
    curDENNO = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
    If curDENNO > curENDNO Then
        '終了伝票NOを超えた場合は戻る
        curDENNO = curSTTNO
    End If
    
    For intCnt = 1 To intGetData
' === 20060822 === UPDATE S - ACE)Sejima
'D        Pm_strPUDLNO(intCnt) = strADDDENCD & Format(curDENNO, String(8, "0"))
' === 20060822 === UPDATE ↓
        strNewPUDLNO = Format(curDENNO, String(8, "0"))
        Pm_strPUDLNO(intCnt) = strADDDENCD & strNewPUDLNO
' === 20060822 === UPDATE E
        curDENNO = curDENNO + 1
        If curDENNO > curENDNO Then
            '終了伝票Noを超えた場合は戻る
            curDENNO = curSTTNO
        End If
    Next intCnt

    'ユーザー伝票№テーブル更新
    If intGetData > 0 Then
' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'        usrOdy.Obj_Ody.Edit
'' === 20060822 === UPDATE S - ACE)Sejima
''D        usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
'' === 20060822 === UPDATE ↓
'        usrOdy.Obj_Ody.Fields("DENNO").Value = strNewPUDLNO
'' === 20060822 === UPDATE E
'        If Trim(GV_SysTime) <> "" Then
'            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
'        Else
'            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
'        End If
'        If Trim(GV_SysDate) <> "" Then
'            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
'        Else
'            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
'        End If
'        usrOdy.Obj_Ody.Update

        strSQL = ""
        strSQL = strSQL & " UPDATE SYSTBC "
        strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewPUDLNO, 8) & "' "
        
        If Trim(GV_SysTime) <> "" Then
            strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
        Else
            strSQL = strSQL & "      , WRTTM      = '" & CStr(Format(Now, "hhmmss")) & "' "
        End If
        
        If Trim(GV_SysDate) <> "" Then
            strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
        Else
            strSQL = strSQL & "      , WRTDT      = '" & CStr(Format(Now, "yyyymmdd")) & "' "
        End If
        
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_PUDL & "' "
        
        'ＳＱＬ実行
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
            GoTo ERR_AE_SYSTBCSaiban_PUDLNO
        End If
' === 20061108 === UPDATE E -
    End If

    bolRet = CF_Ora_CloseDyn(usrOdy)
    If bolRet = False Then
        GoTo ERR_AE_SYSTBCSaiban_PUDLNO
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTran = False
    
    AE_SYSTBCSaiban_PUDLNO = 0

EXIT_AE_SYSTBCSaiban_PUDLNO:
    Exit Function

ERR_AE_SYSTBCSaiban_PUDLNO:

' === 20061108 === UPDATE S - ACE)Nagasawa レスポンス対応
'    If gv_Int_OraErr = 54 Then
    If gv_Int_OraErr = 51 Then
' === 20061108 === UPDATE E -
        '他で使用中
        AE_SYSTBCSaiban_PUDLNO = 2
    End If

    If bolTran = True Then
        'ロールバック
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If

    GoTo EXIT_AE_SYSTBCSaiban_PUDLNO

End Function
' === 20060815 === INSERT E -

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function JDNNO_CntUp
'   概要：  受注番号カウントアップ処理
'   引数：　pin_strJDNNO     :カウントアップ対象文字
'           pot_strRtn     :カウントアップ後文字
'   戻値：  True:桁上がりあり  False:桁上がりなし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function JDNNO_CntUp(ByVal pin_strJDNNO As String, _
                             ByRef pot_strRtn As String) As Boolean

    Dim intJDNNO                As Integer
    Dim strJdnNo                As String
    
    JDNNO_CntUp = False
    
' === 20060927 === UPDATE S - ACE)Nagasawa
'    Select Case pin_strJDNNO
    Select Case Trim(pin_strJDNNO)
' === 20060927 === UPDATE E -
        Case "9"
            pot_strRtn = "A"
            Exit Function
            
        Case "Z"
            pot_strRtn = "0"
            JDNNO_CntUp = True
            Exit Function
            
' === 20060927 === INSERT S - ACE)Nagasawa
        Case ""
            pot_strRtn = " "
            JDNNO_CntUp = True
            Exit Function
' === 20060927 === INSERT E -
    End Select
    
    intJDNNO = Asc(pin_strJDNNO)
    pot_strRtn = Chr(intJDNNO + 1)
    
    Select Case pot_strRtn
        Case "I", "O"
            intJDNNO = Asc(pot_strRtn)
            pot_strRtn = Chr(intJDNNO + 1)
        Case Else
    End Select
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CalcTAX_Meisai
'   概要：  消費税計算処理
'   引数：　Pin_strHINZEIKB    :商品消費税区分
'           Pin_curZEIRT       :消費税率
'           Pin_curTANKA       :単価(税抜き単価)
'           Pin_curSURYO       :数量
'           Pin_strTOKZEIKB    :得意先消費税区分
'           Pin_strTOKRPSKB    :消費税端数処理桁数
'           Pin_strTOKZRNKB    :消費税端数処理区分
'           Pot_curUZEKN       :消費税額
'   戻値：  True : 正常  False : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
'Public Static Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, _
'                                         ByVal Pin_curZEIRT As Currency, _
'                                         ByVal Pin_curTANKA As Currency, _
'                                         ByVal Pin_curSURYO As Currency, _
'                                         ByVal Pin_strTOKZEIKB As String, _
'                                         ByVal Pin_strTOKRPSKB As String, _
'                                         ByVal Pin_strTOKZRNKB As String, _
'                                         ByRef Pot_curUZEKN As Currency) As Integer
                                         
Public Static Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, _
                                         ByVal Pin_curZEIRT As Currency, _
                                         ByVal Pin_curTANKA As Currency, _
                                         ByVal Pin_curSURYO As Currency, _
                                         ByVal Pin_strTOKZEIKB As String, _
                                         ByVal Pin_strTOKRPSKB As String, _
                                         ByVal Pin_strTOKZRNKB As String, _
                                         ByRef Pot_curUZEKN As Currency, _
                                         Optional ByVal Pin_curKingk As Currency = 0) As Boolean
' === 20061116 === UPDATE E -

    Dim curZeigk            As Currency
    Dim strRPSKB            As String
    
On Error GoTo ERR_AE_CalcTAX_Meisai

    AE_CalcTAX_Meisai = False
        
    Pot_curUZEKN = 0
    
    strRPSKB = ""
    Select Case Pin_strTOKRPSKB
        '円未満
        Case gc_strTOKRPSKB_0
            strRPSKB = gc_strRPSKB_I1
        '十円未満
        Case gc_strTOKRPSKB_10
            strRPSKB = gc_strRPSKB_I2
        '百円未満
        Case gc_strTOKRPSKB_100
            strRPSKB = gc_strRPSKB_I3
            
    End Select
        
    Select Case Pin_strHINZEIKB             '商品消費税区分
        '取引先区分どおり
        Case gc_strHINZEIKB_TOK
            Select Case Pin_strTOKZEIKB     '得意先消費税区分
                '税抜き、税込み
                Case gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_NUK
' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
'                    curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
                    If Pin_curKingk = 0 Then
                        curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
                    Else
                        curZeigk = Pin_curKingk * Pin_curZEIRT / 100
                    End If
' === 20061116 === UPDATE E -
                    Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
                    Pot_curUZEKN = curZeigk
                    
                '非課税
                Case gc_strTOKZEIKB_HIK
            
            End Select
            
        '税抜き,税込み
        Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
' === 20061116 === UPDATE S - ACE)Nagasawa システムの場合は単価 * 数量<>金額を可能とする
'            curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
            If Pin_curKingk = 0 Then
                curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
            Else
                curZeigk = Pin_curKingk * Pin_curZEIRT / 100
            End If
' === 20061116 === UPDATE E -
            Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
            Pot_curUZEKN = curZeigk
        '非課税
        Case gc_strHINZEIKB_HIK
        Case Else
    End Select
    
    AE_CalcTAX_Meisai = True

EXIT_AE_CalcTAX_Meisai:

    Exit Function

ERR_AE_CalcTAX_Meisai:

    GoTo EXIT_AE_CalcTAX_Meisai

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CalcRoundKingk
'   概要：  金額まるめ計算処理
'   引数：　Pio_curKingk       :まるめ金額
'           Pin_strRPSKB    :金額端数処理桁数（消費税端数処理桁数の場合
'           Pin_strZRNKB    :金額端数処理区分
'   戻値：  なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Currency, _
                             ByVal pin_strRPSKB As String, _
                             ByVal pin_strZRNKB As String)

    Dim curKingk            As Currency
    Dim curKingk_wk         As Currency
    
    curKingk = 0
    
    Select Case pin_strRPSKB             '金額端数処理桁数
        '１
        Case gc_strRPSKB_I1
            curKingk = Pio_curKingk
        '１０
        Case gc_strRPSKB_I2
            curKingk = Pio_curKingk / 10
        '１００
        Case gc_strRPSKB_I3
            curKingk = Pio_curKingk / 100
        '小数第一位
        Case gc_strRPSKB_D1
            curKingk = Pio_curKingk
        '小数第二位
        Case gc_strRPSKB_D2
            curKingk = Pio_curKingk * 10
        '小数第三位
        Case gc_strRPSKB_D3
            curKingk = Pio_curKingk * 100
        '小数第四位
        Case gc_strRPSKB_D4
            curKingk = Pio_curKingk * 1000
        '小数第五位
        Case gc_strRPSKB_D5
            curKingk = Pio_curKingk * 10000
    End Select
    
    Select Case pin_strZRNKB             '金額端数処理区分
        '切捨て
        Case gc_strTOKZRNKB_DWN
            curKingk = Fix(curKingk)
        '四捨五入
        Case gc_strTOKZRNKB_RND
' === 20061115 === UPDATE S - ACE)Nagasawa
'            curKingk = Round(curKingk)
            If curKingk >= 0 Then
                curKingk = Fix(curKingk + 0.5)
            Else
                curKingk = Fix(curKingk - 0.5)
            End If
' === 20061115 === UPDATE E -
        '切り上げ
        Case gc_strTOKZRNKB_UP
            curKingk_wk = Fix(curKingk)
            If curKingk_wk < curKingk Then
                curKingk = curKingk_wk + 1
            Else
                curKingk = curKingk_wk
            End If
    End Select
    
    Select Case pin_strRPSKB             '金額端数処理桁数
        '１
        Case gc_strRPSKB_I1
            curKingk = curKingk
        '１０
        Case gc_strRPSKB_I2
            curKingk = curKingk * 10
        '１００
        Case gc_strRPSKB_I3
            curKingk = curKingk * 100
        '小数第一位
        Case gc_strRPSKB_D1
            curKingk = curKingk
        '小数第二位
        Case gc_strRPSKB_D2
            curKingk = curKingk / 10
        '小数第三位
        Case gc_strRPSKB_D3
            curKingk = curKingk / 100
        '小数第四位
        Case gc_strRPSKB_D4
            curKingk = curKingk / 1000
        '小数第五位
        Case gc_strRPSKB_D5
            curKingk = curKingk / 10000
    End Select
    
    Pio_curKingk = curKingk

End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_Calc_SIKRT
'   概要：  仕切率計算処理
'   引数：　Pin_curTANKA       :単価
'           Pin_curTEIKATK     :定価
'           Pin_strTKNZRNKB    :金額端数処理区分
'   戻値：  仕切率
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_Calc_SIKRT(ByVal Pin_curTANKA As Currency, _
                                     ByVal Pin_curTEIKATK As Currency, _
                                     ByVal Pin_strTKNZRNKB As String) As Currency

    Dim curSIKRT            As Currency
    Dim strZRNKB            As String
    
    AE_Calc_SIKRT = 0
    If Pin_curTEIKATK = 0 Then
        curSIKRT = 0
    Else
        curSIKRT = Pin_curTANKA / Pin_curTEIKATK * 100
    End If
    
    Select Case Pin_strTKNZRNKB             '金額端数処理区分
        '切捨て
        Case gc_strTOKZRNKB_DWN
            strZRNKB = gc_strTOKZRNKB_UP
        '四捨五入
        Case gc_strTOKZRNKB_RND
            strZRNKB = gc_strTOKZRNKB_RND
        '切り上げ
        Case gc_strTOKZRNKB_UP
            strZRNKB = gc_strTOKZRNKB_DWN
    End Select

    '金額丸め処理
' === 20061020 === UPDATE S - ACE)Nagasawa オーバーフロー対応
'    Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
    Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D2, strZRNKB)
' === 20061020 === UPDATE E -
    
    AE_Calc_SIKRT = curSIKRT

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_Calc_TANKA
'   概要：  単価計算処理（仕切率より）
'   引数：　Pin_curSIKRT       :仕切率
'           Pin_curTEIKATK     :定価
'           Pin_strTKNRPSKB    :金額端数処理桁数
'           Pin_strTKNZRNKB    :金額端数処理区分
'   戻値：  単価
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_Calc_TANKA(ByVal Pin_curSIKRT As Currency, _
                                     ByVal Pin_curTEIKATK As Currency, _
                                     ByVal Pin_strTKNRPSKB As String, _
                                     ByVal Pin_strTKNZRNKB As String) As Currency

    Dim curTanka            As Currency
    
    AE_Calc_TANKA = 0
    curTanka = Pin_curTEIKATK * Pin_curSIKRT / 100

    '金額丸め処理
    Call AE_CalcRoundKingk(curTanka, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
    
    AE_Calc_TANKA = curTanka

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_Calc_BSART
'   概要：  売差率計算処理
'   引数：　Pin_curTANKA       :単価
'           Pin_curSIKTK       :仕切単価
'           Pin_strTKNRPSKB    :金額端数処理桁数
'           Pin_strTKNZRNKB    :金額端数処理区分
'   戻値：  仕切率
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_Calc_BSART(ByVal Pin_curTANKA As Currency, _
                                     ByVal Pin_curSIKTK As Currency, _
                                     ByVal Pin_strTKNRPSKB As String, _
                                     ByVal Pin_strTKNZRNKB As String) As Currency

    Dim curBSART            As Currency
    
    AE_Calc_BSART = 0
    
    If Pin_curTANKA = 0 Then
        curBSART = 0
    Else
        curBSART = (Pin_curTANKA - Pin_curSIKTK) / Pin_curTANKA * 100
    End If

    '金額丸め処理
' === 20061025 === UPDATE S - ACE)Nagasawa 必ず小数第二位で丸める
'    Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
    Call AE_CalcRoundKingk(curBSART, gc_strRPSKB_D2, Pin_strTKNZRNKB)
' === 20061025 === UPDATE E -
    
    AE_Calc_BSART = curBSART

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CalcDateAdd
'   概要：  日付計算処理
'   引数：　Pio_strDate     :計算対象日(数字８桁、またはyyyy/mm/ddの形式）
'           Pin_intAddDate  :加算対象日数（マイナス値は減算）
'           Pin_strKind     :営業日種別("1":営業日 "2":銀行稼働日　"3":物流稼働日）
'                            省略時は営業日による考慮無し
'   戻値：  0 : 正常 9 : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, _
                               ByVal Pin_intAddDate As Integer, _
                               Optional ByVal Pin_strKind As String = "0") As Integer

    Dim strDate         As String
    Dim Mst_Inf         As TYPE_DB_CLDMTA
    Dim intAddDate      As Integer              '日付計算用
    
    AE_CalcDateAdd = 9
    
    strDate = ""
    
    '日付整合性チェック
    If IsDate(Pio_strDate) = True Then
        strDate = Pio_strDate
    End If
    
    '日付様式に変換
    If IsDate(Format(Pio_strDate, "@@@@/@@/@@")) = True Then
        strDate = Format(Pio_strDate, "@@@@/@@/@@")
    End If
    
    If Trim(strDate) = "" Then
        Exit Function
    End If
    
    '日付加算
    strDate = DateAdd("d", Pin_intAddDate, strDate)
    
    'カレンダマスタ検索
    If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
        Exit Function
    End If

    If Pin_intAddDate >= 0 Then
        intAddDate = 1
    Else
        intAddDate = -1
    End If
    
    Select Case Pin_strKind
        '営業日計算
        Case "1"
            Do Until Mst_Inf.SLDKB = "1"
                strDate = DateAdd("d", intAddDate, strDate)
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
                    Exit Function
                End If
            Loop
            
        '銀行稼働日計算
        Case "2"
            Do Until Mst_Inf.BNKKDKB = "1"
                strDate = DateAdd("d", intAddDate, strDate)
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
                    Exit Function
                End If
            Loop
        
        '物流稼働日計算
        Case "3"
            Do Until Mst_Inf.DTBKDKB = "1"
                strDate = DateAdd("d", intAddDate, strDate)
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
                    Exit Function
                End If
            Loop
    
        Case Else
        
    End Select
    
    Pio_strDate = strDate
    AE_CalcDateAdd = 0

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CmnMsgLibrary
'   概要：  標準メッセージ表示処理
'   引数：  Pin_strPgNm     : プログラム名
'           Pin_strMsgCode  : メッセージコード（DB検索用）
'           pm_All  　　　  : 画面情報
'           pin_strMsg      : 追加メッセージ
'           pin_strHeadMsg  : メッセージ先頭への追加メッセージ
'   戻値：  選択ボタン
'   備考：  アプリの実行時に出力される標準メッセージ。
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20061031 === UPDATE S - ACE)Nagasawa
'Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, _
'                                 ByVal Pin_strMsgCode As String, _
'                                 ByRef pm_All As Cls_All, _
'                                 Optional ByVal pin_strMsg As String = "") As Integer
Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, _
                                 ByVal Pin_strMsgCode As String, _
                                 ByRef pm_All As Cls_All, _
                                 Optional ByVal pin_strMsg As String = "", _
                                 Optional ByVal pin_strHeadMsg As String = "") As Integer
' === 20061031 === UPDATE E -

    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim strMsg_add      As String
    
' === 20060914 === INSERT S - ACE)Nagasawa
    On Error Resume Next
' === 20060914 === INSERT E -

    AE_CmnMsgLibrary = False

    If pm_All.Dsp_IM_Denkyu Is Nothing Then
    Else
        'プロンプトメッセージのクリア
        Call CF_Clr_Prompt(pm_All)
    End If
    
    strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1)         'メッセージ種別
    strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2)           'メッセージアイテム
    
' === 20060810 === INSERT S - ACE)Nagasawa
    Beep
' === 20060810 === INSERT E -

    'メッセージマスタ検索
    intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
    If intRet <> 0 Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, Pin_strPgNm)
            Exit Function
        End If
    End If

    '追加メッセージの編集
    strMsg_add = ""
    If Mst_Inf.MSGSQ = "9" Then
        'ＤＢアクセス系エラーとする
' === 20061026 === UPDATE S - ACE)Nagasawa メッセージ表示の変更（発生箇所を表示しない場合あり）
'        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg

        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
        
        '追加メッセージがある場合、発生箇所として表示する
        If Trim(pin_strMsg) <> "" Then
            strMsg_add = strMsg_add & "発生箇所   : " & pin_strMsg
        End If
' === 20061026 === UPDATE E -
    Else
        If Trim(pin_strMsg) <> "" Then
            strMsg_add = vbCrLf & pin_strMsg
        End If
    End If

' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
    'メッセージフラグTrue
    GV_bolMsgFlg = True
    'キーバッファのクリア
    Call ClearKeyBuffers(pm_All)
' === 20060920 === INSERT E
    
    'Windowsに制御を戻す
    DoEvents
    
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
    'メッセージ出力終了するまでは抜ける
    If GV_bolMsgFlg = False Then
        Exit Function
    End If
' === 20060920 === INSERT E
    
    'メッセージ表示
    Select Case Mst_Inf.BTNKB
        'OK
        Case gc_strBTNKB_OKOnly
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
' === 20061031 === UPDATE E -
            
        'OK/キャンセル
        Case gc_strBTNKB_OKCancel
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
' === 20061031 === UPDATE E -
            
        '中止/再試行/無視
        Case gc_strBTNKB_AbortRetryIgnore
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
' === 20061031 === UPDATE E -
            
        'はい/いいえ/キャンセル
        Case gc_strBTNKB_YesNoCancel
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
' === 20061031 === UPDATE E -
        
        'はい/いいえ
        Case gc_strBTNKB_YesNo
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
' === 20061031 === UPDATE E -
            
        '再試行/キャンセル
        Case gc_strBTNKB_RetryCancel
' === 20061031 === UPDATE S - ACE)Nagasawa
'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
            AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
' === 20061031 === UPDATE E -
        
        Case Else
        
    End Select
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
    'メッセージフラグFalse
    GV_bolMsgFlg = False
' === 20060920 === INSERT E
        
End Function
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応

'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CmnMsgLibrary_2
'   概要：  標準メッセージ表示処理（画面情報なし版）
'   引数：  Pin_strPgNm     : プログラム名
'           Pin_strMsgCode  : メッセージコード（DB検索用）
'           pin_strMsg      : 追加メッセージ
'           pin_strHeadMsg  : メッセージ先頭への追加メッセージ
'   戻値：  選択ボタン
'   備考：  アプリの実行時に出力される標準メッセージ。
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_CmnMsgLibrary_2(ByVal Pin_strPgNm As String, _
                                   ByVal Pin_strMsgCode As String, _
                                   Optional ByVal pin_strMsg As String = "", _
                                   Optional ByVal pin_strHeadMsg As String = "") As Integer

    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim strMsg_add      As String
    
    On Error Resume Next

    AE_CmnMsgLibrary_2 = False
    
    strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1)         'メッセージ種別
    strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2)           'メッセージアイテム
    
    Beep

    'メッセージマスタ検索
    intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
    If intRet <> 0 Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, Pin_strPgNm)
            Exit Function
        End If
    End If

    '追加メッセージの編集
    strMsg_add = ""
    If Mst_Inf.MSGSQ = "9" Then
        'ＤＢアクセス系エラーとする
        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
        
        '追加メッセージがある場合、発生箇所として表示する
        If Trim(pin_strMsg) <> "" Then
            strMsg_add = strMsg_add & "発生箇所   : " & pin_strMsg
        End If
    Else
        If Trim(pin_strMsg) <> "" Then
            strMsg_add = vbCrLf & pin_strMsg
        End If
    End If
    
    'メッセージフラグTrue
    GV_bolMsgFlg = True
    
    'Windowsに制御を戻す
    DoEvents
    
    'メッセージ出力終了するまでは抜ける
    If GV_bolMsgFlg = False Then
        Exit Function
    End If
    
    'メッセージ表示
    Select Case Mst_Inf.BTNKB
        'OK
        Case gc_strBTNKB_OKOnly
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
            
        'OK/キャンセル
        Case gc_strBTNKB_OKCancel
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        '中止/再試行/無視
        Case gc_strBTNKB_AbortRetryIgnore
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        'はい/いいえ/キャンセル
        Case gc_strBTNKB_YesNoCancel
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
        
        'はい/いいえ
        Case gc_strBTNKB_YesNo
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        '再試行/キャンセル
        Case gc_strBTNKB_RetryCancel
            AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
        
        Case Else
        
    End Select
    
    'メッセージフラグFalse
    GV_bolMsgFlg = False
        
End Function
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub ClearKeyBuffers
'   概要：  キーバッファクリア処理
'   引数：  pm_All  　　　  : 画面情報
'   戻値：  なし
'   備考：  APIによるキーバッファのクリア
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub ClearKeyBuffers(ByRef pm_All As Cls_All)
    Dim tMsg As Msg
    Dim lngRet As Long
    
    Do
        lngRet = PeekMessage(tMsg, pm_All.Dsp_Base.FormCtl.hwnd, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
    Loop Until lngRet = 0
End Sub
' === 20060920 === INSERT E

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_GetSMEDT
'   概要：  締日計算処理
'   引数：  Pin_strDate     : 計算対象日付(８桁の数値Or日付）
'           Pin_strTOKSMEKB : 締区分
'           Pin_strTOKSMEDD : 締初期日付（売上）
'           Pin_strTOKSMECC : 締サイクル（売上）
'           Pin_strTOKSDWKB : 締め曜日
'           Pin_intCHTNKB   : 帳端区分(計算対象日から何回目の締日かを指定)
'           Pot_strSMEDT    : 計算結果締日
'   戻値：  0：正常　9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function AE_GetSMEDT(ByVal pin_strDate As String, _
                     ByVal Pin_strTOKSMEKB As String, _
                     ByVal Pin_strTOKSMEDD As String, _
                     ByVal Pin_strTOKSMECC As String, _
                     ByVal Pin_strTOKSDWKB As String, _
                     ByVal Pin_intCHTNKB As Integer, _
                     ByRef Pot_strSMEDT As String) As Integer
                     
    Dim strDate     As String
    Dim yy          As Integer
    Dim mm          As Integer
    Dim dd          As Integer
    Dim Cnt         As Integer
    Dim I           As Integer
    Dim setidx      As Integer
    Dim idx         As Integer
    Dim addMM       As Integer
    Dim smeday(15)  As Integer
    Dim intTOKSMECC As Integer
    Dim intTOKSMEDD As Integer
    Dim intTOKSDWKB As Integer
    
    AE_GetSMEDT = 9
    Pot_strSMEDT = ""
    
    '日付チェック
    If IsDate(pin_strDate) = True Then
        strDate = Format(pin_strDate, "yyyy/mm/dd")
    Else
        If IsDate(Format(pin_strDate, "@@@@/@@/@@")) = True Then
            strDate = Format(pin_strDate, "@@@@/@@/@@")
        Else
            Exit Function
        End If
    End If
    
    yy = Year(strDate)
    mm = Month(strDate)
    dd = Day(strDate)
    
    If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
        '締初期日付取得
        If IsNumeric(Pin_strTOKSMEDD) = True Then
            intTOKSMEDD = CInt(Pin_strTOKSMEDD)
        Else
            Exit Function
        End If
    
        '締サイクル取得
        If IsNumeric(Pin_strTOKSMECC) = True Then
            intTOKSMECC = CInt(Pin_strTOKSMECC)
        Else
            Exit Function
        End If
        
        '締区分＝"日"の場合
        If intTOKSMECC = 1 Then         '毎日締め
            Pot_strSMEDT = CStr(DateSerial(yy, mm, dd + Pin_intCHTNKB))
            Exit Function
        End If
        '
        If intTOKSMECC <= 0 Or intTOKSMECC > 15 Then intTOKSMECC = 30
        Cnt = Int(30 / intTOKSMECC) '締回数／月
        setidx = False
        For I = 0 To Cnt - 1
            smeday(I) = intTOKSMEDD + intTOKSMECC * I
            If smeday(I) > 27 Then smeday(I) = 99
            If dd <= smeday(I) And setidx = False Then
                idx = I + Pin_intCHTNKB '該当日付の締日配列添字
                setidx = True
            End If
        Next I
        If setidx = False Then idx = Cnt + Pin_intCHTNKB
        addMM = Int(idx / Cnt)
        idx = idx Mod Cnt
        If idx < 0 Then idx = idx + Cnt
        '
        If smeday(idx) = 99 Then
            Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM + 1, 0))
        Else
            Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
        End If
        
    Else
        '締曜日取得
        If IsNumeric(Pin_strTOKSDWKB) = True Then
            intTOKSDWKB = CInt(Pin_strTOKSDWKB)
        Else
            Exit Function
        End If
        
        '締日区分＝"曜日"の場合
        If Weekday(strDate) > intTOKSDWKB Then
            Pot_strSMEDT = CStr(DateSerial(Year(strDate), Month(strDate), Day(strDate) + (7 - Weekday(strDate) + intTOKSDWKB) + (7 * Pin_intCHTNKB)))
        Else
            Pot_strSMEDT = CStr(DateSerial(Year(strDate), Month(strDate), Day(strDate) + (intTOKSDWKB - Weekday(strDate)) + (7 * Pin_intCHTNKB)))
        End If
    End If
    
    Pot_strSMEDT = Format(Pot_strSMEDT, "yyyymmdd")
    
    AE_GetSMEDT = 0
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_GetUDNYTDT
'   概要：  売上予定日計算処理
'   引数：  Pin_strDEFNOKDT : 納期(８桁の数値Or日付）
'           Pin_strODNYTDT  : 出荷予定日
'           Pin_strUDNYTDT  : 売上予定日（画面入力項目)
'           Pin_strTOKSMEKB : 締区分
'           Pin_strTOKSMEDD : 締初期日付（売上）
'           Pin_strTOKSMECC : 締サイクル（売上）
'           Pin_strTOKSDWKB : 締め曜日
'           Pin_strURIKJN   : 売上基準
'           Pot_strUDNYTDT  : 計算結果売上予定日(yyyymmddの形式）
'   戻値：  0：正常　9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, _
                       ByVal pin_strODNYTDT As String, _
                       ByVal Pin_strUDNYTDT As String, _
                       ByVal Pin_strTOKSMEKB As String, _
                       ByVal Pin_strTOKSMEDD As String, _
                       ByVal Pin_strTOKSMECC As String, _
                       ByVal Pin_strTOKSDWKB As String, _
                       ByVal pin_strURIKJN As String, _
                       ByRef Pot_strUDNYTDT As String) As Integer
                     
    Dim strDate     As String
    Dim strDate2    As String
    Dim intRet      As Integer
    Dim strSMEDT    As String
    
    AE_GetUDNYTDT = 9
    Pot_strUDNYTDT = ""
    
    Select Case pin_strURIKJN
        '出荷基準
        Case gc_strURIKJN_SYK
            '日付チェック
            If IsDate(pin_strODNYTDT) = True Then
                strDate = Format(pin_strODNYTDT, "yyyymmdd")
            Else
                If IsDate(Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
                    strDate = pin_strODNYTDT
                Else
                    Exit Function
                End If
            End If
            
            '営業日取得
            intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
            If intRet <> 0 Then
                Exit Function
            End If
        
        '検収基準、工事完了基準
        Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
            '日付チェック
        
' === 20060726 === INSERT S - ACE)Nagasawa
            If Trim(Pin_strUDNYTDT) <> "" Then
' === 20060726 === INSERT E -
            If IsDate(Pin_strUDNYTDT) = True Then
                strDate = Format(Pin_strUDNYTDT, "yyyymmdd")
            Else
                If IsDate(Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
                    strDate = Pin_strUDNYTDT
                Else
                    Exit Function
                End If
            End If
' === 20060726 === INSERT S - ACE)Nagasawa
            Else
                If IsDate(pin_strODNYTDT) = True Then
                    strDate = Format(pin_strODNYTDT, "yyyymmdd")
                Else
                    If IsDate(Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
                        strDate = pin_strODNYTDT
                    Else
                        Exit Function
                    End If
                End If
            End If
' === 20060726 === INSERT E -
            
            Pot_strUDNYTDT = strDate
        
        '役務完了基準
        Case gc_strURIKJN_EKM
' === 20060830 === UPDATE S - ACE)Nagasawa
'            '日付チェック
'            If IsDate(Pin_strDEFNOKDT) = True Then
'                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
'            Else
'                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
'                    strDate = Pin_strDEFNOKDT
'                Else
'                    Exit Function
'                End If
'            End If
'
'            '売上予定日を計算
'            intRet = AE_GetSMEDT(strDate, _
'                                 Pin_strTOKSMEKB, _
'                                 Pin_strTOKSMEDD, _
'                                 Pin_strTOKSMECC, _
'                                 Pin_strTOKSDWKB, _
'                                 1, _
'                                 strDate2)

            '日付チェック
            If IsDate(pin_strODNYTDT) = True Then
                strDate2 = Format(pin_strODNYTDT, "yyyymmdd")
            Else
                If IsDate(Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
                    strDate2 = pin_strODNYTDT
                Else
                    Exit Function
                End If
            End If
' === 20060830 === UPDATE E -

            If intRet = 9 Then
                Exit Function
            End If
            
            '営業日取得
            intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
            If intRet <> 0 Then
                Exit Function
            End If
            
    End Select
    
    
    AE_GetUDNYTDT = 0
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_GetKRSMADT
'   概要：  経理締日計算処理
'   引数：  Pin_strKJNDT    : 基準日
'           Pot_strSMADT  　: 計算結果経理締日(yyyymmddの形式）
'   戻値：  0：正常　9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function AE_GetKRSMADT(ByVal pin_strKJNDT As String, _
                       ByRef Pot_strSMADT As String) As Integer
                     
    Dim strSMEDT                As String
    Dim strSQL                  As String
    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA
    Dim intRet                  As Integer
    
    AE_GetKRSMADT = 9
    Pot_strSMADT = ""
    
    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
    
    'ユーザー情報管理テーブル検索
    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
        Exit Function
    End If
    
    '経理締日計算
    intRet = AE_GetSMEDT(pin_strKJNDT _
                       , gc_strSMEKB_DAY _
                       , Mst_Inf_SYSTBA.SMEDD _
                       , "99" _
                       , "" _
                       , 0 _
                       , strSMEDT)
    If intRet <> 0 Then
        Exit Function
    End If
    
    Pot_strSMADT = strSMEDT
    
    AE_GetKRSMADT = 0
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Execute_PLSQL_GetTanka
    '   概要：  PL/SQL実行処理(単価取得処理)
    '   引数：　Pin_strHINCD  : 商品コード
    '           Pin_strTOKCD  : 得意先コード
    '           Pin_strDATE   : 適用日
    '           Pin_strTUKKB  : 通貨区分
    '           Pin_lngSU     : 数量
    '           Pot_curTanka  : 取得単価
    '           Pot_curSIKRT  : 取得仕切率
    '           Pin_strJDNKB  : 受注区分（"1"海外　それ以外は空白）
    '           Pot_curTEITK  : 定価
    '   戻値：　0 : 正常 9: 異常
    '   備考：  単価取得用PL/SQL(PRC_CMNPL90_01)を実行する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, _
                                          ByVal pin_strTOKCD As String, _
                                          ByVal pin_strDate As String, _
                                          ByVal pin_strTUKKB As String, _
                                          ByVal Pin_lngSU As Long, _
                                          ByRef Pot_curTANKA As Currency, _
                                          ByRef Pot_curSIKRT As Currency, _
                                          Optional ByRef Pin_strJDNKB As String = "", _
                                          Optional ByRef Pot_curTEITK As Currency) As Integer

    Dim strSQL      As String           'SQL文
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(製品コード)
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(得意先コード)
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(適用日)
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(通貨区分)
    Dim lngPara5    As Long             'ﾊﾟﾗﾒｰﾀ5(数量)
    Dim strPara6    As String           'ﾊﾟﾗﾒｰﾀ6(受注区分)
    Dim lngPara7    As Long             'ﾊﾟﾗﾒｰﾀ7(復帰ｺｰﾄﾞ)
    Dim lngPara8    As Long             'ﾊﾟﾗﾒｰﾀ8(ｴﾗｰｺｰﾄﾞ)
    Dim strPara9    As String           'ﾊﾟﾗﾒｰﾀ9(ｴﾗｰ内容)
' === 20060920 === UPDATE S - ACE)Nagasawa
'    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10(販売単価)
    Dim lngPara10   As Currency         'ﾊﾟﾗﾒｰﾀ10(販売単価)
' === 20060920 === UPDATE E -
    Dim lngPara11   As Long             'ﾊﾟﾗﾒｰﾀ11(仕切率)
    Dim lngPara12   As Long             'ﾊﾟﾗﾒｰﾀ12(定価)
    Dim param(13)   As OraParameter     'PL/SQLのバインド変数
    Dim bolRet      As Boolean
    
    AE_Execute_PLSQL_GetTanka = 9
    
    '受渡し変数初期設定
    strPara1 = pin_strHINCD
    strPara2 = pin_strTOKCD
    strPara3 = pin_strDate
    strPara4 = pin_strTUKKB
    lngPara5 = Pin_lngSU
    strPara6 = Pin_strJDNKB
    lngPara7 = 0
    lngPara8 = 0
    strPara9 = ""
    lngPara10 = 0
    lngPara11 = 0
    lngPara12 = 0

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P9", strPara9, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P12", lngPara12, ORAPARM_OUTPUT

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
    Set param(11) = gv_Odb_USR1.Parameters("P11")
    Set param(12) = gv_Odb_USR1.Parameters("P12")

    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_NUMBER
    param(6).serverType = ORATYPE_CHAR
    param(7).serverType = ORATYPE_NUMBER
    param(8).serverType = ORATYPE_NUMBER
    param(9).serverType = ORATYPE_VARCHAR2
    param(10).serverType = ORATYPE_NUMBER
    param(11).serverType = ORATYPE_NUMBER
    param(12).serverType = ORATYPE_NUMBER

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"

    'DBアクセス
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo AE_Execute_PLSQL_GetTanka_END
    End If

    '** 戻り値取得
    lngPara7 = param(7).Value
    lngPara8 = param(8).Value
    If IsNull(param(9).Value) = False Then
        strPara9 = param(9).Value
    End If

    If IsNull(param(10).Value) = False Then
        lngPara10 = param(10).Value
    Else
        lngPara10 = 0
    End If
    
    If IsNull(param(11).Value) = False Then
        lngPara11 = param(11).Value
    Else
        lngPara11 = 0
    End If
    
    If IsNull(param(12).Value) = False Then
        lngPara12 = param(12).Value
    Else
        lngPara12 = 0
    End If
    
    Pot_curTANKA = CCur(lngPara10)
    Pot_curSIKRT = CCur(lngPara11)
    Pot_curTEITK = CCur(lngPara12)
    
    'エラー情報設定
    gv_Int_OraErr = lngPara8
    gv_Str_OraErrText = strPara9 & vbCrLf
    
    AE_Execute_PLSQL_GetTanka = lngPara7
    
AE_Execute_PLSQL_GetTanka_END:
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
    gv_Odb_USR1.Parameters.Remove "P11"
    gv_Odb_USR1.Parameters.Remove "P12"

    
End Function

' === 20060829 === DELETE S - ACE)Nagasawa 使用されていないため削除
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
''   名称：  Function AE_Get_TANKA
''   概要：  単価、仕切率取得処理
''   引数：　Pin_strHINCD       :製品コード
''           Pin_strTOKCD       :得意先コード
''           Pin_strDATE        :基準日
''           Pot_curSIKRT       :仕切率
''           Pot_curTANKA       :取得単価
''   戻値：  0 : 正常　9 : 異常
''   備考：
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
'                                    ByVal pin_strTOKCD As String, _
'                                    ByVal pin_strDate As String, _
'                                    ByRef Pot_curSIKRT As Currency, _
'                                    ByRef Pot_curTANKA As Currency) As Integer
'
'    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '商品マスタ検索結果
''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       'ランク別仕切り率マスタ検索結果
'    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '得意先マスタ検索結果
''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '得意先別商品ランクマスタ検索結果
'
'    AE_Get_TANKA = 9
'
'    Pot_curSIKRT = 100
'    Pot_curTANKA = 0
'
'    '商品マスタ検索
'    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
'        GoTo AE_Get_TANKA_ERR
'    End If
'
'    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
'        GoTo AE_Get_TANKA_ERR
'    End If
'
''**********************仮☆★☆★
'    Pot_curSIKRT = 90
'    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
''**********************仮☆★☆★
''    '得意先マスタ検索
''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    '得意先別商品ランクマスタ検索
''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    '仕切率取得
''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
''        GoTo AE_Get_TANKA_ERR
''    End If
''
''    '仕切率取得
''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
''
''    '単価取得
''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
''                                 Mst_Inf_HINMTA.TEIKATK, _
''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
''                                 Mst_Inf_TOKMTA.TKNZRNKB)
'
'    AE_Get_TANKA = 0
'
'    Exit Function
'
'AE_Get_TANKA_ERR:
'
'End Function
' === 20060829 === DELETE E -

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Get_SysDt
'//*
'//* <戻り値>     型          説明
'//*              Boolean     True:正常 / False:異常
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    DBサーバーの日付(西暦)を取得する。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20041016|ACE)Moriga     |新規作成
'//**************************************************************************************
Public Function CF_Get_SysDt() As Boolean
    
    On Error GoTo ERR_HANDLE
    
    Dim Str_Sql         As String
    Dim Usr_Ody         As U_Ody
    Dim Str_Val         As String
    Dim Lng_Cnt         As Long
    Dim Lng_Idx         As Long
    Dim Str_SysDt       As String
    
    CF_Get_SysDt = False
    
    '// 初期化
    GV_SysDate = ""
    GV_SysTime = ""
    Str_SysDt = ""
    
    Str_Sql = ""
    Str_Sql = Str_Sql & "SELECT"
    Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
    Str_Sql = Str_Sql & "FROM"
    Str_Sql = Str_Sql & "       Dual "
    
    If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
        GoTo ERR_HANDLE
    End If
    
    Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
    
    GV_SysDate = Mid(Str_SysDt, 1, 8)
    GV_SysTime = Mid(Str_SysDt, 9, 6)
    
    CF_Get_SysDt = True

EXIT_HANDLE:
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function
    
ERR_HANDLE:
    GoTo EXIT_HANDLE
    
End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Get_UnyDt
'//*
'//* <戻り値>     型          説明
'//*              Boolean     True:正常 / False:異常
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    運用日付(西暦)を取得する。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20060706|ACE)Nagasawa   |新規作成
'//**************************************************************************************
Public Function CF_Get_UnyDt() As Boolean
    
    Dim intRet      As Integer
    Dim Mst_Inf     As TYPE_DB_UNYMTA
    
    CF_Get_UnyDt = False
    
    '初期化
    GV_UNYDate = ""
    
    'サーバーのシステム日付取得
    Call CF_Get_SysDt
    
    '運用日付を取得
    intRet = DSPUNYDT_SEARCH(Mst_Inf)
    If intRet = 0 Then
        GV_UNYDate = Mst_Inf.UNYDT
    Else
        GV_UNYDate = GV_SysDate
    End If
    
    CF_Get_UnyDt = True
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Execute_PLSQL_PRC_UODFP53
    '   概要：  PL/SQL実行処理(自動発注処理)
    '   引数：　Pin_strPRCCASE  : 処理ケース（"1":登録 "2":訂正 "3": 削除）
    '           Pin_strJDNNO    : 受注番号
    '           Pin_strLINNO    : 行番号
    '           Pin_strSBNNO    : 製番
    '           Pin_strHINCD    : 商品コード
    '           Pin_lngBFRSU    : 変更前受注数量（登録の場合はゼロ）
    '           Pin_lngAFTSU    : 変更後受注数量（削除の場合はゼロ）
    '           Pin_strZAIRNK   : 在庫ランク
    '           Pin_lngBFRSU    : 変更前出荷予定日（登録、削除の場合は設定なし）
    '           Pin_lngAFTSU    : 変更後出荷予定日（登録、削除の場合は設定なし）
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：  自動発注処理PL/SQL(PRC_UODFP53_01)を実行する
    '           ただし、変更前受注数量＝変更後受注数量の場合は実行しない
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20061102 === UPDATE S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
'Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
'                                           , ByVal pin_strJDNNO As String _
'                                           , ByVal pin_strLINNO As String _
'                                           , ByVal pin_strSBNNO As String _
'                                           , ByVal pin_strHINCD As String _
'                                           , ByVal Pin_lngBFRSU As Currency _
'                                           , ByVal Pin_lngAFTSU As Currency _
'                                           , Optional ByVal Pin_strBFRSYK As String = "" _
'                                           , Optional ByVal Pin_strAFTSYK As String = "") As Integer
Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
                                           , ByVal pin_strJDNNO As String _
                                           , ByVal pin_strLINNO As String _
                                           , ByVal pin_strSBNNO As String _
                                           , ByVal pin_strHINCD As String _
                                           , ByVal Pin_lngBFRSU As Currency _
                                           , ByVal Pin_lngAFTSU As Currency _
                                           , ByVal Pin_strZAIRNK As String _
                                           , Optional ByVal Pin_strBFRSYK As String = "" _
                                           , Optional ByVal Pin_strAFTSYK As String = "") As Integer
' === 20061102 === UPDATE E -

    Dim strSQL      As String           'SQL文
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(処理ケース)
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(受注番号)
    Dim strPara5    As String           'ﾊﾟﾗﾒｰﾀ5(行番号)
    Dim strPara6    As String           'ﾊﾟﾗﾒｰﾀ6(製番)
    Dim strPara7    As String           'ﾊﾟﾗﾒｰﾀ7(製品コード)
    Dim lngPara8    As Long             'ﾊﾟﾗﾒｰﾀ8(変更前受注数量)
    Dim lngPara9    As Long             'ﾊﾟﾗﾒｰﾀ9(変更後受注数量)
    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10(復帰ｺｰﾄﾞ)
    Dim lngPara11   As Long             'ﾊﾟﾗﾒｰﾀ11(ｴﾗｰｺｰﾄﾞ)
    Dim strPara12   As String * 1000    'ﾊﾟﾗﾒｰﾀ12(ｴﾗｰ内容)
    Dim lngPara13   As Long             'ﾊﾟﾗﾒｰﾀ13(読込件数)
    Dim lngPara14   As Long             'ﾊﾟﾗﾒｰﾀ14(登録件数)
    Dim param(15)   As OraParameter     'PL/SQLのバインド変数
    Dim bolRet      As Boolean
' === 20061102 === INSERT S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
    Dim Mst_Inf     As TYPE_DB_MEIMTA
    Dim bolExit     As Boolean
' === 20061102 === INSERT E -
    
    AE_Execute_PLSQL_PRC_UODFP53 = 9
    
' === 20060824 === UPDATE S - ACE)Nagasawa 納期変更時も自動発注処理を呼び出す
'    '変更前受注数量＝変更後受注数量の場合は処理終了
'    If Pin_lngBFRSU = Pin_lngAFTSU Then
'        AE_Execute_PLSQL_PRC_UODFP53 = 0
'        Exit Function
'    End If

    '変更前受注数量＝変更後受注数量、変更前出荷予定日＝変更後出荷予定日の場合は処理終了
    If Pin_lngBFRSU = Pin_lngAFTSU _
    And Pin_strBFRSYK = Pin_strAFTSYK Then
        AE_Execute_PLSQL_PRC_UODFP53 = 0
        Exit Function
    End If
' === 20060824 === UPDATE E -
    
' === 20061102 === INSERT S - ACE)Nagasawa 自動発注処理の呼び出し条件の追加
    bolExit = True
    Call DB_MEIMTA_Clear(Mst_Inf)
    If DSPMEIM_SEARCH(gc_strKEYCD_ZAIRNK, Pin_strZAIRNK, Mst_Inf) = 0 Then
        If Mst_Inf.DATKB = gc_strDATKB_USE Then
            If Mst_Inf.MEIKBA = gc_strJDNSEISAN_OK Then
                bolExit = False
            End If
        End If
    End If
    
    '受注生産対象品以外は処理を行わない
    If bolExit = True Then
        AE_Execute_PLSQL_PRC_UODFP53 = 0
        Exit Function
    End If
' === 20061102 === INSERT E -

    '受渡し変数初期設定
    strPara1 = SSS_OPEID
    strPara2 = SSS_CLTID
    strPara3 = Pin_strPRCCASE
    strPara4 = pin_strJDNNO
    strPara5 = pin_strLINNO
    strPara6 = pin_strSBNNO
    strPara7 = pin_strHINCD
    lngPara8 = Pin_lngBFRSU
    lngPara9 = Pin_lngAFTSU
    lngPara10 = 0
    lngPara11 = 0
    strPara12 = ""
    lngPara13 = 0
    lngPara14 = 0

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P12", strPara12, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P13", lngPara13, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P14", lngPara14, ORAPARM_OUTPUT

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
    Set param(11) = gv_Odb_USR1.Parameters("P11")
    Set param(12) = gv_Odb_USR1.Parameters("P12")
    Set param(13) = gv_Odb_USR1.Parameters("P13")
    Set param(14) = gv_Odb_USR1.Parameters("P14")

    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_CHAR
    param(6).serverType = ORATYPE_CHAR
    param(7).serverType = ORATYPE_CHAR
    param(8).serverType = ORATYPE_NUMBER
    param(9).serverType = ORATYPE_NUMBER
    param(10).serverType = ORATYPE_NUMBER
    param(11).serverType = ORATYPE_NUMBER
    param(12).serverType = ORATYPE_VARCHAR2
    param(13).serverType = ORATYPE_NUMBER
    param(14).serverType = ORATYPE_NUMBER

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"

    'DBアクセス
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo AE_Execute_PLSQL_PRC_UODFP53_END
    End If

    '** 戻り値取得
    lngPara10 = param(10).Value
    lngPara11 = param(11).Value
    If IsNull(param(12).Value) = False Then
        strPara12 = param(12).Value
    End If
    lngPara13 = param(13).Value
    lngPara14 = param(14).Value
    
    'エラー情報設定
    gv_Int_OraErr = lngPara11
    gv_Str_OraErrText = Trim(strPara12) & vbCrLf
    
    AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
    
AE_Execute_PLSQL_PRC_UODFP53_END:
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
    gv_Odb_USR1.Parameters.Remove "P11"
    gv_Odb_USR1.Parameters.Remove "P12"
    gv_Odb_USR1.Parameters.Remove "P13"
    gv_Odb_USR1.Parameters.Remove "P14"
    
End Function

' === 20060828 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_TKCHGKB
    '   概要：  権限情報取得
    '   引数：　pin_DB_TANMTA  : 担当者マスタ情報
    '           pin_strUnyDate : 運用日付
    '   戻値：　権限グループ
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Get_KNG_Inf(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, _
                               ByVal pin_strUnyDate As String, _
                               ByRef Inp_Inf As Cmn_Inp_Inf) As Integer

    Dim Mst_Inf_KNGMTA      As TYPE_DB_KNGMTA
    Dim strKNGGRCD          As String
    
    '初期化
    With Inp_Inf
        'いったん、権限なしとする
        .InpTKCHGKB = gc_strTKCHGKB_NG
        .InpJDNUPDKB = gc_strJDNUPDKB_NG
    End With
    
    '権限グループ取得
    strKNGGRCD = F_Get_KNGGRCD(pin_DB_TANMTA, pin_strUnyDate)
    
    If Trim(strKNGGRCD) <> "" Then
        '権限グループが取得できた場合、権限マスタを検索
        Call DB_KNGMTA_Clear(Mst_Inf_KNGMTA)
        If KNGMTA_SEARCH(strKNGGRCD, Mst_Inf_KNGMTA) = 0 Then
            With Inp_Inf
                '単価変更権限
                .InpTKCHGKB = Mst_Inf_KNGMTA.SALTKKB
                '受注更新権限
                .InpJDNUPDKB = Mst_Inf_KNGMTA.JDNUPDKB
            End With
        End If
    End If
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_KNGGRCD
    '   概要：  権限グループ取得
    '   引数：　pin_DB_TANMTA  : 担当者マスタ情報
    '           pin_strDate    : 運用日付
    '   戻値：　権限グループ
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Get_KNGGRCD(pin_DB_TANMTA As TYPE_DB_TANMTA, pin_strDate As String) As String

    Dim bolTANTKDT   As Boolean        '適用日判定フラグ（True：適用日＜＝運用日）
    Dim intWk        As Integer
    Dim Ret_Value    As String
    
    '初期化
    bolTANTKDT = False
    Ret_Value = ""
    intWk = 0
    
    With pin_DB_TANMTA
                    
        '権限グループ設定あり
        If Trim(.KNGGRCD) <> "" Then
            intWk = intWk + mc_intCD
        End If
        
        '旧権限グループ設定あり
        If Trim(.OLDGRCD) <> "" Then
            intWk = intWk + mc_intOLDCD
        End If
        
        '適用日設定あり
        If Trim(.TANTKDT) <> "" Then
            intWk = intWk + mc_intTKDT
            '適用日判定
            If Trim(.TANTKDT) <= pin_strDate Then
                bolTANTKDT = True
            End If
        End If
        
        '権限グループ、旧権限グループ、適用日の設定有無に応じて判定を行う。
        '（2^3の8ﾊﾟﾀｰﾝ）
        Select Case intWk
            Case mc_intCD + mc_intOLDCD + mc_intTKDT
                '①権限グループ、旧権限グループ、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.KNGGRCD)
                Else
                    Ret_Value = Trim(.OLDGRCD)
                End If
                
            Case mc_intCD + mc_intOLDCD
                '②権限グループ、旧権限グループの設定あり
                Ret_Value = Trim(.KNGGRCD)
            
            Case mc_intCD + mc_intTKDT
                '③権限グループ、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.KNGGRCD)
                Else
                    Ret_Value = Trim(.OLDGRCD)
                End If
            
            Case mc_intOLDCD + mc_intTKDT
                '④旧権限グループ、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.KNGGRCD)
                Else
                    Ret_Value = Trim(.OLDGRCD)
                End If
            
            Case mc_intCD
                '⑤権限グループの設定あり
                Ret_Value = Trim(.KNGGRCD)
            
            Case mc_intOLDCD
                '⑥旧権限グループの設定あり
            
            Case mc_intTKDT
                '⑦適用日の設定あり
            
            Case Else
                '⑧いずれも設定なし
                
        End Select
        
    End With
    
    F_Get_KNGGRCD = Ret_Value
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_TANBMNCD
    '   概要：  所属部門コード取得
    '   引数：　pin_DB_TANMTA  : 担当者マスタ情報
    '           pin_strDate : 運用日付
    '   戻値：　所属部門コード
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_TANBMNCD(pin_DB_TANMTA As TYPE_DB_TANMTA, pin_strDate As String) As String

    Dim bolTANTKDT   As Boolean        '適用日判定フラグ（True：適用日＜＝基準日）
    Dim intWk        As Integer
    Dim Ret_Value    As String
    
    '初期化
    bolTANTKDT = False
    Ret_Value = ""
    intWk = 0
    
    With pin_DB_TANMTA
                    
        '所属部門コード設定あり
        If Trim(.TANBMNCD) <> "" Then
            intWk = intWk + mc_intCD
        End If
        
        '旧所属部門コード設定あり
        If Trim(.OLDBMNCD) <> "" Then
            intWk = intWk + mc_intOLDCD
        End If
        
        '適用日設定あり
        If Trim(.TANTKDT) <> "" Then
            intWk = intWk + mc_intTKDT
            '適用日判定
            If Trim(.TANTKDT) <= pin_strDate Then
                bolTANTKDT = True
            End If
        End If
        
        '所属部門コード、旧所属部門コード、適用日の設定有無に応じて判定を行う。
        '（2^3の8ﾊﾟﾀｰﾝ）
        Select Case intWk
            Case mc_intCD + mc_intOLDCD + mc_intTKDT
                '①所属部門コード、旧所属部門コード、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.TANBMNCD)
                Else
                    Ret_Value = Trim(.OLDBMNCD)
                End If
                
            Case mc_intCD + mc_intOLDCD
                '②所属部門コード、旧所属部門コードの設定あり
                Ret_Value = Trim(.TANBMNCD)
            
            Case mc_intCD + mc_intTKDT
                '③所属部門コード、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.TANBMNCD)
                Else
                    Ret_Value = Trim(.OLDBMNCD)
                End If
            
            Case mc_intOLDCD + mc_intTKDT
                '④旧所属部門コード、適用日の設定あり
                If bolTANTKDT = True Then
                    Ret_Value = Trim(.TANBMNCD)
                Else
                    Ret_Value = Trim(.OLDBMNCD)
                End If
            
            Case mc_intCD
                '⑤所属部門コードの設定あり
                Ret_Value = Trim(.TANBMNCD)
            
            Case mc_intOLDCD
                '⑥旧所属部門コードの設定あり
            
            Case mc_intTKDT
                '⑦適用日の設定あり
            
            Case Else
                '⑧いずれも設定なし
                
        End Select
        
    End With
    
    CF_Get_TANBMNCD = Ret_Value
    
End Function
' === 20060828 === INSERT E

' === 20060829 === INSERT S - ACE)Nagasawa 赤黒伝票が発生する場合は警告を表示する
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_UpdateJDN_Chk
'   概要：  受注訂正チェック
'   引数：  pin_strKJNDT    : 判定基準日（受注日）
'           pin_strTOKCD  　: 得意先コード
'   戻値：  0：正常　1: 月次仮締日過ぎ　2: 請求締日過ぎ　9: 異常
'   備考：  得意先マスタ.請求締日、ユーザー情報管理テーブル.月次仮締日を見て
'　　　　　 受注訂正が可能かどうかの判断を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function AE_UpdateJDN_Chk(ByVal pin_strKJNDT As String, _
                          ByVal pin_strTOKCD As String) As Integer
                     
    Dim strSMEDT                As String
    Dim strSQL                  As String
    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA
    Dim Mst_Inf_TOKMTA          As TYPE_DB_TOKMTA
    Dim intRet                  As Integer
    
    AE_UpdateJDN_Chk = 9
    
    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
    
    'ユーザー情報管理テーブル検索
    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
        Exit Function
    End If
    
    '基準日と月次仮締日の比較
    If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
        If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_SYSTBA.UKSMEDT Then
            AE_UpdateJDN_Chk = 1
            Exit Function
        End If
    End If
    
    Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
    
' === 20061026 === DELETE S - ACE)Nagasawa 請求締のチェックは行わない
'    '得意先マスタ検索
'    If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
'        Exit Function
'    End If
'
'    '基準日と請求締日の比較
'    If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
'        If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
'            AE_UpdateJDN_Chk = 2
'            Exit Function
'        End If
'    End If
' === 20061026 === DELETE E -
    
    AE_UpdateJDN_Chk = 0
    
End Function
' === 20060829 === INSERT E -

' === 20060830 === INSERT S - ACE)Nagasawa 権限の取得は画面の日付を基準に行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function F_Get_INPTANCD_Inf
'   概要：  入力担当者情報取得処理
'   引数：  pin_strTANCD    : 担当者コード
'           pot_Inp_Inf     : 取得結果入力担当者情報
'           pin_strKJNDT    : 判定基準日（省略された場合は運用日とする）
'   戻値：  0：正常　9: 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function F_Get_INPTANCD_Inf(ByVal pin_strTANCD As String, _
                            ByRef pot_Inp_Inf As Cmn_Inp_Inf, _
                            Optional ByVal pin_strKJNDT As String = "") As Integer
                     
    Dim Mst_Inf_TANMTA          As TYPE_DB_TANMTA
    Dim intRet                  As Integer
    Dim strKJNDT                As String
' === 20061030 === INSERT S - ACE)Nagasawa 権限の読み方の変更
    Dim strRet                  As String
' === 20061030 === INSERT E -
    
    F_Get_INPTANCD_Inf = 9
    
    '基準日が省略された場合は運用日を使用する
    If Trim(pin_strKJNDT) = "" Then
        strKJNDT = GV_UNYDate
    Else
        strKJNDT = CF_Ora_Date(pin_strKJNDT)
    End If
    
    '担当者マスタ検索
    Call DB_TANMTA_Clear(Mst_Inf_TANMTA)
    intRet = DSPTANCD_SEARCH(pin_strTANCD, Mst_Inf_TANMTA)
    If intRet = 0 Then
        pot_Inp_Inf.InpTanNm = Mst_Inf_TANMTA.TANNM              '入力担当者名
' === 20061030 === UPDATE S - ACE)Nagasawa 権限の読み方の変更
'        '権限情報取得（単価変更権限、受注更新権限、etc...）
'        Call F_Get_KNG_Inf(Mst_Inf_TANMTA, strKJNDT, pot_Inp_Inf)
'    End If
    End If
    
    '初期化
    With Inp_Inf
        'いったん、権限なしとする
        .InpTKCHGKB = gc_strTKCHGKB_NG                      '販売単価変更権限
        .InpJDNUPDKB = gc_strJDNUPDKB_NG                    '更新権限
        .InpPRTAUTH = gc_strJDNUPDKB_NG                     '印刷権限
        .InpFILEAUTH = gc_strJDNUPDKB_NG                    'ファイル出力権限
    End With
    
    '権限取得ロジックへの引数セット
    gs_userid = pin_strTANCD            '入力担当者ID
    gs_pgid = SSS_PrgId                 'プログラムID
    
    '権限取得
    strRet = Get_Authority(strKJNDT)
    
    '取得された権限セット
    With Inp_Inf
        .InpTKCHGKB = gs_SALTAUTH                           '販売単価変更権限
        .InpJDNUPDKB = gs_UPDAUTH                           '更新権限
        .InpPRTAUTH = gs_PRTAUTH                            '印刷権限
        .InpFILEAUTH = gs_FILEAUTH                          'ファイル出力権限
    End With
' === 20061030 === UPDATE E -
    
    F_Get_INPTANCD_Inf = 0
    
End Function
' === 20060830 === INSERT E -

' === 20060905 === INSERT S - ACE)Hashiri 赤伝票を作成
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_AKADEN_INSERT
'   概要：  赤伝票作成処理
'   引数：  pin_strDATNO        : 伝票管理№
'           pin_strMOTODATNO  　: 元伝票管理№
'           pin_strOPEID  　    : 最終作業者コード
'           pin_strCLTID      　: クライアントＩＤ
'           pin_strJODCNKB    　: 受注キャンセル理由区分
'           pin_strJDNDT      　: 受注伝票日付(省略された場合、運用日)
'   戻値：  0：正常　9: 異常
'   備考：  パラメータの値を元に赤伝票を作成する
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20061108 === UPDATE S - ACE)Nagasawa
'Public Function AE_AKADEN_INSERT(ByVal pin_strDATNO As String, _
'                          ByVal pin_strMOTODATNO As String, _
'                          ByVal pin_strOPEID As String, _
'                          ByVal pin_strCLTID As String, _
'                          ByVal pin_strJODCNKB As String) As Integer
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_AKADEN_JDNTHB_SQL
'   概要：  赤伝票作成処理_受注納入先トランSQL文作成
'   引数：  pin_strDATNO        : 伝票管理№
'           pin_strMotoDatNo  　: 元伝票管理№
'           pin_strOPEID  　    : 最終作業者コード
'           pin_strCLTID      　: クライアントＩＤ
'   戻値：  SQL文字列
'   備考：  受注納入先トランINSERT文の作成
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function AE_AKADEN_JDNTHB_SQL(ByVal pin_strDatNo As String, _
                                      ByVal pin_strMotoDatNo As String, _
                                      ByVal pin_strOPEID As String, _
                                      ByVal pin_strCLTID As String) As String
                     
    Dim strSQL As String
    
    strSQL = ""
    strSQL = strSQL & " Insert into JDNTHB "
    strSQL = strSQL & "        ( DATNO "           '伝票管理№
    strSQL = strSQL & "        , DATKB "           '伝票削除区分
    strSQL = strSQL & "        , AKAKROKB "        '赤黒区分
    strSQL = strSQL & "        , JDNNO "           '受注番号
    strSQL = strSQL & "        , NHSZP "           '納入先郵便番号
    strSQL = strSQL & "        , NHSTL "           '納入先電話番号
    strSQL = strSQL & "        , NHSFX "           '納入先FAX番号
' === 20070220 === INSERT S - ACE)Nagasawa 得意先名称保持対応
    strSQL = strSQL & "        , TOKNMA "          '得意先名称１
    strSQL = strSQL & "        , TOKNMB "          '得意先名称２
' === 20070220 === INSERT E -
' === 20070307 === INSERT S - ACE)Nagasawa EDI備考対応（40バイト→100バイト）
    strSQL = strSQL & "        , DENCMEDI "        'ＥＤＩ備考
' === 20070307 === INSERT E -
    strSQL = strSQL & "        , FOPEID "          '初回登録ユーザID
    strSQL = strSQL & "        , FCLTID "          '初回登録クライアントID
    strSQL = strSQL & "        , WRTFSTTM "        'タイムスタンプ（登録時間）
    strSQL = strSQL & "        , WRTFSTDT "        'タイムスタンプ（登録日付）
    strSQL = strSQL & "        , OPEID "           'ユーザID（訂正）
    strSQL = strSQL & "        , CLTID "           'クライアントID（訂正）
    strSQL = strSQL & "        , WRTTM "           'タイムスタンプ（訂正時間）
    strSQL = strSQL & "        , WRTDT "           'タイムスタンプ（訂正日）
    strSQL = strSQL & "        , UOPEID "          'ユーザID（バッチ）
    strSQL = strSQL & "        , UCLTID "          'クライアントID（バッチ）
    strSQL = strSQL & "        , UWRTTM "          'タイムスタンプ（バッチ時間）
    strSQL = strSQL & "        , UWRTDT "          'タイムスタンプ（バッチ日）
    strSQL = strSQL & "        , PGID "            '更新PGID
    strSQL = strSQL & "        ) "
    strSQL = strSQL & " Select "
    strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
    strSQL = strSQL & "        ,  DATKB "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
    strSQL = strSQL & "        ,  JDNNO "
    strSQL = strSQL & "        ,  NHSZP "
    strSQL = strSQL & "        ,  NHSTL "
    strSQL = strSQL & "        ,  NHSFX "
' === 20070220 === INSERT S - ACE)Nagasawa 得意先名称保持対応
    strSQL = strSQL & "        ,  TOKNMA "
    strSQL = strSQL & "        ,  TOKNMB "
' === 20070220 === INSERT E -
' === 20070307 === INSERT S - ACE)Nagasawa EDI備考対応（40バイト→100バイト）
    strSQL = strSQL & "        ,  DENCMEDI "
' === 20070307 === INSERT E -
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
    strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
    strSQL = strSQL & " From  "
    strSQL = strSQL & "     JDNTHB  "
    strSQL = strSQL & " Where  "
    strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"

    AE_AKADEN_JDNTHB_SQL = strSQL
    
End Function
' === 20061223 === INSERT E -

' === 20060912 === INSERT S - ACE)Sejima CRM連携CSV排他対応
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_INI_CRM
'   概要：  CRM関連INIファイル情報取得
'   引数：  pin_strFileName     : INIﾌｧｲﾙ名称
'           pot_strCSVFilePath　: CSVﾌｧｲﾙﾊﾟｽ
'           pot_curRetry  　    : ﾘﾄﾗｲ回数
'           pot_curWait       　: ﾘﾄﾗｲ間隔
'           pot_strAddMsg     　: 追記ｴﾗｰﾒｯｾｰｼﾞ
'   戻値：  0:正常終了　9:異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_INI_CRM(ByVal pin_strFileName As String, _
                               ByRef pot_strCSVFilePath As String, _
                               ByRef pot_curRetry As Currency, _
                               ByRef pot_curWait As Currency) As Integer
                     
    Dim Ret_Value        As Integer
    Dim lRet             As Long
    Dim strRet           As String * 256
    Dim strWk            As String
    Dim intRet           As Integer
    
    CF_Get_INI_CRM = 9
    
    'いったん正常扱い
    Ret_Value = 0
    
    'iniファイルより、
    '　①CSV読込リトライ間隔
    strRet = ""
' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
'    lRet = GetPrivateProfileString("CRM", "Wait", "", strRet, Len(strRet), pin_strFileName)
'    If lRet > 0 Then
'        If IsNumeric(strRet) = True Then
'            'iniファイルから取得できて、かつ数値として正しい
'            pot_curWait = LeftWid(strRet, lRet)
'
'        Else
'            'iniファイルから取得できたが、数値として正しくない
'            Ret_Value = 9
'
'        End If
'
'    Else
'        'iniファイルから取得できない
'        Ret_Value = 9
'
'    End If
    
    intRet = CF_Get_IniInf("CRM", "Wait", strRet)
    If intRet = 0 Then
        If IsNumeric(strRet) = True Then
            'iniファイルから取得できて、かつ数値として正しい
            pot_curWait = CF_Get_CCurString(strRet)
        Else
            'iniファイルから取得できたが、数値として正しくない
            Ret_Value = 9

        End If

    Else
        'iniファイルから取得できない
        Ret_Value = 9

    End If
' === 20061102 === UPDATE E -

    '　　（読み込めない場合は AE_CONST.bas の固定値を使用し、エラーとしない）
    If Ret_Value = 9 Then
        pot_curWait = CRM_RETRY_WAIT
        Ret_Value = 0
    End If
    
    
    '　②CSV読込リトライ回数
    strRet = ""
' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
'    lRet = GetPrivateProfileString("CRM", "Retry", "", strRet, Len(strRet), pin_strFileName)
'    If lRet > 0 Then
'        If IsNumeric(strRet) = True Then
'            'iniファイルから取得できて、かつ数値として正しい
'            pot_curRetry = LeftWid(strRet, lRet)
'
'        Else
'            'iniファイルから取得できたが、数値として正しくない
'            Ret_Value = 9
'
'        End If
'
'    Else
'        'iniファイルから取得できない
'        Ret_Value = 9
'
'    End If
    
    intRet = CF_Get_IniInf("CRM", "Retry", strRet)
    If intRet = 0 Then
        If IsNumeric(strRet) = True Then
            'iniファイルから取得できて、かつ数値として正しい
            pot_curRetry = CF_Get_CCurString(strRet)
        Else
            'iniファイルから取得できたが、数値として正しくない
            Ret_Value = 9

        End If

    Else
        'iniファイルから取得できない
        Ret_Value = 9

    End If
' === 20061102 === UPDATE E -

    '　　（読み込めない場合は AE_CONST.bas の固定値を使用し、エラーとしない）
    If Ret_Value = 9 Then
        pot_curRetry = CRM_RETRY_MAX
        Ret_Value = 0
    End If
    
    
    '　③CSVファイルパス
    strRet = ""
' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル読込み変更
'    lRet = GetPrivateProfileString("CRM", "CSVPath", "", strRet, Len(strRet), pin_strFileName)
'    If lRet > 0 Then
'        pot_strCSVFilePath = LeftWid(strRet, lRet)
'    Else
'        'iniファイルから取得できない
'        Ret_Value = 9
'    End If
    
    '　③CSVファイルパス
    intRet = CF_Get_IniInf("CRM", "CSVPath", strRet)
    If intRet = 0 Then
        pot_strCSVFilePath = strRet
    Else
        'iniファイルから取得できない
        Ret_Value = 9
    End If
' === 20061102 === UPDATE E -
    
    CF_Get_INI_CRM = Ret_Value
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Ctl_OpenCRMCsv
'   概要：  CRM関連INIファイルオープン処理
'   引数：  pin_intFileNo       : ファイル番号
'           pin_strCSVFilePath　: CSVﾌｧｲﾙﾊﾟｽ
'           pin_curRetry  　    : ﾘﾄﾗｲ回数
'           pin_curWait       　: ﾘﾄﾗｲ間隔
'   戻値：  0:正常終了　9:異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ctl_OpenCRMCsv(ByVal pin_intFileNo As Integer, _
                                  ByVal pin_strCSVFilePath As String, _
                                  ByVal pin_curRetry As Currency, _
                                  ByVal pin_curWait As Currency) As Boolean
                     
    Dim bolOpen          As Boolean
    Dim curRetryCnt      As Currency
    Dim curRetryMax      As Currency
    
    CF_Ctl_OpenCRMCsv = False
    
    'リトライ回数の上限を設定
    curRetryMax = pin_curRetry
'    If curRetryMax >= 10 Then
'        curRetryMax = 10
'    End If
    
    curRetryCnt = 0
    bolOpen = False
    'ファイルを開くか、最大回数を超えてリトライするまでループ
    Do Until bolOpen = True Or curRetryCnt > curRetryMax
    
        DoEvents
        
        '上書き禁止、追記モードでオープン
        On Error Resume Next
        Open pin_strCSVFilePath For Append Lock Write As pin_intFileNo
        Select Case Err
            Case 70
                '既にファイルが開かれている場合、リトライ
                '（リトライ間隔分の時間、一時停止。ただし最終回を除く）
                If curRetryCnt < curRetryMax Then
                    Call Sleep(pin_curWait * 1000)
                End If
            
            Case 0
                '正常にオープン
                bolOpen = True
                
            Case Else
        
        End Select
    
        curRetryCnt = curRetryCnt + 1
    
    Loop
    
    CF_Ctl_OpenCRMCsv = bolOpen
    
End Function
' === 20060912 === INSERT E

' === 20061013 === INSERT S - ACE)Nagasawa 売上基準の入力制限追加
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_URIKJN_Input
'   概要：  入力売上基準チェック処理
'   引数：  pin_strJDNTRKB      : 受注取引区分
'           pin_strURIKJN     　: 売上基準
'   戻値：  0:正常終了(チェックＯＫ）　1:チェックＮＧ  9:異常終了
'   備考：  受注取引区分より入力された売上基準が入力可能値かどうか判定します
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_URIKJN_Input(ByVal pin_strJDNTRKB As String, _
                                    ByVal pin_strURIKJN As String) As Integer
    
' === 20061030 === INSERT S - ACE)Nagasawa 売上基準のチェック変更
    Dim Mst_Inf                     As TYPE_DB_MEIMTA
    Dim intRet                      As Integer
' === 20061030 === INSERT E -
    
    CF_Chk_URIKJN_Input = 9
    
' === 20061030 === UPDATE S - ACE)Nagasawa 売上基準のチェック変更
'    Select Case pin_strJDNTRKB
'        '単品の場合
'        Case gc_strJDNTRKB_TAN
'            '出荷基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        'セットアップの場合
'        Case gc_strJDNTRKB_SET
'            '出荷基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        'システムの場合
'        Case gc_strJDNTRKB_SYS
'            '出荷基準、検収基準、工事完了基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_SYK _
'            And pin_strURIKJN <> gc_strURIKJN_KNS _
'            And pin_strURIKJN <> gc_strURIKJN_KOJ Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        '修理の場合
'        Case gc_strJDNTRKB_SYR
'            '検収基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        '保守の場合
'        Case gc_strJDNTRKB_HSY
'            '役務完了基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_EKM Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        '貸出の場合
'        Case gc_strJDNTRKB_KAS
'            '検収完了基準以外はエラー
'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
'                CF_Chk_URIKJN_Input = 1
'                Exit Function
'            End If
'
'        '上記以外
'        Case Else
'            CF_Chk_URIKJN_Input = 1
'            Exit Function
'
'    End Select
'
'    CF_Chk_URIKJN_Input = 0

    Call DB_MEIMTA_Clear(Mst_Inf)
    
    '名称マスタ検索
    CF_Chk_URIKJN_Input = 1
    intRet = DSPMEIM_SEARCH(gc_strKEYCD_URIKJN_Chk, pin_strJDNTRKB, Mst_Inf, pin_strURIKJN)
    If intRet = 0 Then
        If Mst_Inf.DATKB = gc_strDATKB_USE Then
            CF_Chk_URIKJN_Input = 0
        End If
    End If
' === 20061030 === UPDATE E -
    
End Function
' === 20061013 === INSERT E -

' === 20061026 === INSERT S - ACE)Nagasawa 客先伝票指定区分変更
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_DspTOKDNKB
'   概要：  画面表示用客先伝票指定区分取得処理
'   引数：  pin_strTOKDNKB      : 客先伝票指定区分
'   戻値：  画面表示用客先伝票指定区分(vbChecked/vbUnchecked)
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_DspTOKDNKB(ByVal pin_strTOKDNKB As String) As Integer
    
    If pin_strTOKDNKB = gc_strTOKDNKB_NML Then
        '"通常"の場合、チェックOFF
        CF_Get_DspTOKDNKB = vbUnchecked
    Else
        '"通常"以外の場合、チェックON
        CF_Get_DspTOKDNKB = vbChecked
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_UpdTOKDNKB
'   概要：  受注トラン更新用客先伝票指定区分取得処理
'   引数：  pin_intTOKDNKB              : 画面の客先伝票指定区分
'   引数：  pin_strTOKDNKB_TOKMTA       : 得意先マスタの客先伝票指定区分
'   戻値：  受注トラン行進用客先伝票指定区分
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_UpdTOKDNKB(ByVal pin_intTOKDNKB As Integer, _
                                  ByVal pin_strTOKDNKB_TOKMTA As String) As String
    
    If pin_intTOKDNKB = vbUnchecked Then
        'チェックOFFの場合、"通常"
        CF_Get_UpdTOKDNKB = gc_strTOKDNKB_NML
    Else
        'チェックONの場合
        If pin_strTOKDNKB_TOKMTA = gc_strTOKDNKB_NML Then
            '得意先マスタの客先指定伝票区分が"通常"の場合は指定
            CF_Get_UpdTOKDNKB = gc_strTOKDNKB_STI
        Else
            '得意先マスタの客先伝票指定区分使用
            CF_Get_UpdTOKDNKB = pin_strTOKDNKB_TOKMTA
        End If
    End If
    
End Function
' === 20061026 === INSERT E -

' === 20061028 === INSERT S - ACE)Nagasawa FAX番号チェックの追加
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_FAXNO
'   概要：  FAX番号チェック処理
'   引数：  pin_strFAXNO       : チェック対象FAX番号
'           pin_intKETA        : FAX番号入力可能桁数
'           pin_intFAX_HAIHUN  : FAX番号ハイフン数
'           pin_intFAX_LSTNUM  : FAX番号最終数値部分桁数
'           pin_strFRNKB       : 海外取引区分
'   戻値：  0 : チェックOK   9 : チェックNG
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_FAXNO(ByVal pin_strFAXNO As String, _
                             ByVal pin_intKETA As Integer, _
                             ByVal pin_intFAX_HAIHUN As Integer, _
                             ByVal pin_intFAX_LSTNUM As Integer, _
                             ByVal pin_strFRNKB As String) As Integer
    
    Dim intHaihun           As Integer
    Dim intCnt              As Integer
    Dim intLstHaihun        As Integer          '最後のハイフン位置
    
    CF_Chk_FAXNO = 9
    
    'ファックス番号の書式チェックを追加
    If pin_strFRNKB <> gc_strFRNKB_FRN Then
        
        '空白はOKとする
        If Trim(pin_strFAXNO) = "" Then
            CF_Chk_FAXNO = 0
            Exit Function
        End If
        
        'ハイフンが先頭の場合はエラー
        If Mid(pin_strFAXNO, 1, 1) = "-" Then
            CF_Chk_FAXNO = 10
            Exit Function
        End If
        
        'ハイフンが最後の場合はエラー
        If Right(pin_strFAXNO, 1) = "-" Then
            CF_Chk_FAXNO = 30
            Exit Function
        End If
        
        'ハイフンが連続して存在する場合エラー
        If InStr(pin_strFAXNO, "--") > 0 Then
            CF_Chk_FAXNO = 20
            Exit Function
        End If
        
        '桁数チェック
        If Len(pin_strFAXNO) > pin_intKETA Then
            CF_Chk_FAXNO = 40
            Exit Function
        End If
        
        'ハイフン数チェック
        intHaihun = 0
        intLstHaihun = 0
        For intCnt = 1 To Len(pin_strFAXNO)
            If Mid(pin_strFAXNO, intCnt, 1) = "-" Then
                intHaihun = intHaihun + 1
                intLstHaihun = intCnt
            End If
        Next
        
        If intHaihun <> pin_intFAX_HAIHUN Then
            CF_Chk_FAXNO = 50
            Exit Function
        End If
        
        '最終部の桁数チェック
        If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) <> pin_intFAX_LSTNUM Then
            CF_Chk_FAXNO = 60
            Exit Function
        End If
        
    End If
    
    CF_Chk_FAXNO = 0
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_CLMDL_FRN
'   概要：  分類型式取得処理（海外）
'   引数：  pin_strJDNTRKB     : 受注取引区分
'           pin_strMDLCL       : 商品マスタ.集計分類（受注トラン.分類型式）
'           pin_strCLMDL_DSP   : 画面.分類型式
'   戻値：  取得された分類型式
'   備考：　受注取引区分により受注トランに編集する分類型式の値を決定します
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_CLMDL_FRN(ByVal pin_strJDNTRKB As String, _
                                 ByVal pin_strMDLCL As String, _
                                 ByVal pin_strCLMDL_DSP As String) As String
    
    Dim Rtn_Value               As String
    
    CF_Get_CLMDL_FRN = ""
    Rtn_Value = ""
    
    Select Case pin_strJDNTRKB
        '単品
        Case gc_strJDNTRKB_TAN
            Rtn_Value = pin_strMDLCL
            
        'セットアップ
        Case gc_strJDNTRKB_SET
        
        'システム
        Case gc_strJDNTRKB_SYS
        
        '修理
       Case gc_strJDNTRKB_SYR
' === 20061119 === INSERT S - ACE)Nagasawa
'            Rtn_Value = pin_strCLMDL_DSP
            Rtn_Value = pin_strMDLCL
' === 20061119 === INSERT E -
        
        '保守
        Case gc_strJDNTRKB_HSY
' === 20061119 === INSERT S - ACE)Nagasawa
'            Rtn_Value = pin_strCLMDL_DSP
            Rtn_Value = pin_strMDLCL
' === 20061119 === INSERT E -
        
        '貸出
        Case gc_strJDNTRKB_KAS
            Rtn_Value = pin_strMDLCL
        
        Case Else
    End Select
    
    CF_Get_CLMDL_FRN = Rtn_Value
    
End Function
' === 20061028 === INSERT E -

' === 20061031 === INSERT S - ACE)Nagasawa 排他制御の追加
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Execute_PLSQL_EXCTBZ
    '   概要：  PL/SQL実行処理(排他制御処理)
    '   引数：　Pin_strPRCCASE   : 処理ケース(C:チェック W:書込処理 D:削除処理)
    '           Pot_strMsg       : エラー内容
    '   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
    '   備考：  排他制御用PL/SQL(PRC_EXCTBZ)を実行する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, _
                                        ByRef pot_strMsg As String) As Integer

    Dim strSQL      As String           'SQL文
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(処理ケース)
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(業務コード(PGID))
    Dim lngPara5    As Long             'ﾊﾟﾗﾒｰﾀ5(復帰ｺｰﾄﾞ)
    Dim lngPara6    As Long             'ﾊﾟﾗﾒｰﾀ6(ｴﾗｰｺｰﾄﾞ)
    Dim strPara7    As String           'ﾊﾟﾗﾒｰﾀ7(ｴﾗｰ内容)
    Dim param(7)    As OraParameter     'PL/SQLのバインド変数
    Dim bolRet      As Boolean
    
    AE_Execute_PLSQL_EXCTBZ = 9
    
    '受渡し変数初期設定
    strPara1 = Inp_Inf.InpTanCd
    strPara2 = SSS_CLTID
    strPara3 = Pin_strPRCCASE
    strPara4 = SSS_PrgId
    lngPara5 = 0
    lngPara6 = 0
    strPara7 = ""
    
    pot_strMsg = ""

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_OUTPUT

    'データ型をオブジェクトにセット
    Set param(1) = gv_Odb_USR1.Parameters("P1")
    Set param(2) = gv_Odb_USR1.Parameters("P2")
    Set param(3) = gv_Odb_USR1.Parameters("P3")
    Set param(4) = gv_Odb_USR1.Parameters("P4")
    Set param(5) = gv_Odb_USR1.Parameters("P5")
    Set param(6) = gv_Odb_USR1.Parameters("P6")
    Set param(7) = gv_Odb_USR1.Parameters("P7")

    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_NUMBER
    param(6).serverType = ORATYPE_NUMBER
    param(7).serverType = ORATYPE_VARCHAR2

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"

    'DBアクセス
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo AE_Execute_PLSQL_EXCTBZ_END
    End If

    '** 戻り値取得
    lngPara5 = param(5).Value
    lngPara6 = param(6).Value
    If IsNull(param(7).Value) = False Then
        strPara7 = param(7).Value
        pot_strMsg = strPara7
    End If

    'エラー情報設定
    gv_Int_OraErr = lngPara6
    gv_Str_OraErrText = strPara7
    
    AE_Execute_PLSQL_EXCTBZ = lngPara5
    
AE_Execute_PLSQL_EXCTBZ_END:
    '** パラメタ解消
    gv_Odb_USR1.Parameters.Remove "P1"
    gv_Odb_USR1.Parameters.Remove "P2"
    gv_Odb_USR1.Parameters.Remove "P3"
    gv_Odb_USR1.Parameters.Remove "P4"
    gv_Odb_USR1.Parameters.Remove "P5"
    gv_Odb_USR1.Parameters.Remove "P6"
    gv_Odb_USR1.Parameters.Remove "P7"
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_Lock_EXCTBZ
'   概要：　排他制御処理
'   引数：　Pot_strMsg       : エラー内容
'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_Lock_EXCTBZ(ByRef pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Chk_Lock_EXCTBZ_Err

    CF_Chk_Lock_EXCTBZ = 9
    pot_strMsg = ""
    bolTrn = False
    
    '排他チェック
    intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
    If intRet <> 0 Then
        '排他エラー
        pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'トランザクションの開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
    
    '排他制御
    intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
    If intRet <> 0 Then
        '排他エラー
        pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Chk_Lock_EXCTBZ = 0
    
    Exit Function
    
CF_Chk_Lock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Unlock_EXCTBZ
'   概要：　排他制御解除処理
'   引数：　Pot_strMsg       : エラー内容
'   戻値：　0 : 正常  9 : 異常
'   備考：  排他制御（排他テーブルからの削除）を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Unlock_EXCTBZ(ByRef pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Unlock_EXCTBZ_Err

    CF_Unlock_EXCTBZ = 9
    pot_strMsg = ""
    bolTrn = False
    
    'トランザクションの開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
    
    '排他制御解除
    intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
    If intRet <> 0 Then
        '排他エラー
        pot_strMsg = strMsg
        CF_Unlock_EXCTBZ = intRet
        GoTo CF_Unlock_EXCTBZ_Err
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Unlock_EXCTBZ = 0
    
    Exit Function
    
CF_Unlock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_IniInf
'   概要：  Iniファイル読込み処理（プログラム固有）
'   引数：  pin_strSection :
'   戻値：  0 : 正常 9 : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_IniInf(pin_strSection As String, _
                              pin_strKey As String, _
                              pot_strValue As String) As Integer

    Dim Wk          As String * 256
    Dim lngRet      As Long
    
    CF_Get_IniInf = 9
    
    pot_strValue = ""
    
    'Iniファイル読込み
    lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk, Len(Wk), App.Path & "\" & SSS_PrgId & ".ini")
    If lngRet > 0 Then
        pot_strValue = CF_Ctr_AnsiLeftB(Wk, lngRet)
        pot_strValue = Trim$(pot_strValue)
    Else
        Exit Function
    End If
    
    CF_Get_IniInf = 0
    
End Function
' === 20061031 === INSERT E -

' === 20061206 === INSERT S - ACE)Nagasawa 商品状態チェックの変更
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_HINCD
'   概要：  製品コード状態チェック処理
'   引数：  pm_Mst_Inf : 商品マスタ用構造体
'   戻値：  0  : 正常
'           10 : 受注停止
'           20 : 生産終了(手配終了)
'           30 : 出荷停止
'           40 : 出荷準備中
'   備考：　入力された製品コードの状態のチェックを行います
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_HINCD(pm_Mst_Inf As TYPE_DB_HINMTA) As Integer

    CF_Chk_HINCD = 0
    
    '出荷準備中チェック
    If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
        CF_Chk_HINCD = 40
    End If
    
    '出荷停止品チェック
    If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
        CF_Chk_HINCD = 30
    End If
    
    '生産終了品チェック
    If pm_Mst_Inf.PRDENDKB = gc_strPRDENDKB_END Then
        CF_Chk_HINCD = 20
    End If
    
    '受注停止品チェック
    If pm_Mst_Inf.JODSTPKB = gc_strJODSTPKB_STOP Then
        CF_Chk_HINCD = 10
    End If
    
End Function
' === 20061206 === INSERT E -

' === 20061216 === INSERT S - ACE)Nagasawa 製品コードの入力制限追加
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_HINCD2
'   概要：  製品コード商品区分チェック処理
'   引数：  pin_strHINKB   : 商品区分
'           pin_strJDNTRKB : 受注取引区分
'   戻値：  0 : 正常　9 : エラー
'   備考：　入力された製品コードの状態のチェックを行います
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_HINCD2(pin_strHINKB As String, _
                              pin_strJDNTRKB As String) As Integer

    CF_Chk_HINCD2 = 9
    
    '受注取引区分により判定
    Select Case Trim(pin_strJDNTRKB)
        '単品の場合
        Case gc_strJDNTRKB_TAN
        
            '商品区分により判断
            Select Case Trim(pin_strHINKB)
                '製品の場合
                Case gc_strHINKB_SEIHIN
                    CF_Chk_HINCD2 = 0
                '商品の場合
                Case gc_strHINKB_SYOHIN
                    CF_Chk_HINCD2 = 0
                
                Case Else
            End Select
            
        'セットアップの場合
        Case gc_strJDNTRKB_SET
            '全てＯＫ
            CF_Chk_HINCD2 = 0
    
        'システムの場合
        Case gc_strJDNTRKB_SYS
            '全てＯＫ
            CF_Chk_HINCD2 = 0
        
        '修理の場合
        Case gc_strJDNTRKB_SYR
            '全てＯＫ
            CF_Chk_HINCD2 = 0
        
        '保守の場合
        Case gc_strJDNTRKB_HSY
            '全てＯＫ
            CF_Chk_HINCD2 = 0
        
        '貸出の場合
        Case gc_strJDNTRKB_KAS
' === 20060112 === UPDATE S - ACE)Nagasawa 製品コードの入力制限追加
'            '全てＯＫ
'            CF_Chk_HINCD2 = 0

            '商品区分により判断
            Select Case Trim(pin_strHINKB)
                '製品の場合
                Case gc_strHINKB_SEIHIN
                    CF_Chk_HINCD2 = 0
                '商品の場合
                Case gc_strHINKB_SYOHIN
                    CF_Chk_HINCD2 = 0
                
                Case Else
            End Select
' === 20060112 === UPDATE E -
        
    End Select
    
End Function
' === 20061216 === INSERT E -


'' === 20061228 === UPDATE E -
Public Function CF_Chk_CLMDL(pin_strCLMDL As String, _
                             pin_strJDNDT As String, _
                             pin_strJDNTRKB As String, _
                             Optional pin_strCMPKTCD As String = " ") As Integer
' === 20070207 === UPDATE E -

    Dim strSQL              As String
    Dim Usr_Ody_KATA        As U_Ody
    Dim strRtn              As String
    
On Error GoTo Err_CF_Chk_CLMDL

    CF_Chk_CLMDL = 9
    strRtn = ""
    
' === 20061228 === UPDATE S - ACE)Nagasawa 分類型式のチェック変更
'    If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Then
    If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Or Trim(pin_strJDNTRKB) = "" Then
' === 20061228 === UPDATE E -
        CF_Chk_CLMDL = 0
        Exit Function
    End If
    
    '分類型式チェック関数呼び出し
' === 20070207 === UPDATE S - ACE)Nagasawa システム受注で機器受注を入力可とする
'    strSQL = ""
'    strSQL = strSQL & " SELECT "
'' === 20061228 === UPDATE S - ACE)Nagasawa 分類型式のチェック変更
''    strSQL = strSQL & "        GET_PCODE_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
''    strSQL = strSQL & "                      ,'" & CF_Ora_Sgl(pin_strJDNDT) & "') AS RTN "
'    strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
'' === 20061228 === UPDATE E -
'    strSQL = strSQL & "   FROM DUAL "
    
    If Trim(pin_strJDNTRKB) = gc_strJDNTRKB_SYS Then
        'システム受注の場合システム用分類型式チェック
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        CHECK_KATA_SYS('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
        strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
        strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "'"
        strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strCMPKTCD) & "') AS RTN "
        strSQL = strSQL & "   FROM DUAL "
    Else
        'システム受注以外の場合は通常の分類型式チェック
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
        strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
        strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
        strSQL = strSQL & "   FROM DUAL "
    End If
' === 20070207 === UPDATE E -
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_KATA, strSQL)
    
    '内容取得
    If CF_Ora_EOF(Usr_Ody_KATA) = False Then
        strRtn = CF_Ora_GetDyn(Usr_Ody_KATA, "RTN", "")
    End If
    
    If Trim(strRtn) <> "" Then
        CF_Chk_CLMDL = 0
    End If
    
End_CF_Chk_CLMDL:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_KATA)
    
    Exit Function
    
Err_CF_Chk_CLMDL:
    GoTo End_CF_Chk_CLMDL

End Function
' === 20061213 === INSERT E -

Public Function CF_DTLTRA_Update(ByVal pm_strTRAKB As String, _
                                 ByVal pm_strTRANO As String, _
                                 ByVal pm_strMITNOV As String, _
                                 ByVal pm_strLINNO_OLD As String, _
                                 ByVal pm_strLINNO_NEW As String, _
                                 ByVal pm_strODNYTDT As String, _
                                 ByVal pm_strErrCd As String, _
                                 ByRef pm_All As Cls_All) As Integer
' === 20070126 === UPDATE E -

    Dim strSQL              As String
    Dim bolRet              As Boolean
    
On Error GoTo CF_DTLTRA_Update_Err

    CF_DTLTRA_Update = 9
    
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " UPDATE "
    strSQL = strSQL & "        DTLTRA "
    strSQL = strSQL & "    SET "
    strSQL = strSQL & "        LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
    strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strODNYTDT) & "' "
' === 20070126 === INSERT S - ACE)Nagasawa
    strSQL = strSQL & "      , OPEID   = '" & CF_Ora_String(SSS_OPEID, 8) & "' "
    strSQL = strSQL & "      , CLTID   = '" & CF_Ora_String(SSS_CLTID, 5) & "' "
    strSQL = strSQL & "      , WRTTM   = '" & GV_SysTime & "' "
    strSQL = strSQL & "      , WRTDT   = '" & GV_SysDate & "' "
' === 20070126 === INSERT E -
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
    strSQL = strSQL & "    AND MITNOV  = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
    strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
' === 20070126 === INSERT S - ACE)Nagasawa
    strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
' === 20070126 === INSERT E -

    'SQL実行
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo CF_DTLTRA_Update_Err
    End If
    
    CF_DTLTRA_Update = 0
    
CF_DTLTRA_Update_End:
    Exit Function

CF_DTLTRA_Update_Err:
    Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update")
    GoTo CF_DTLTRA_Update_End
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_DTLTRA_Delete
    '   概要：  引当内訳ファイル削除処理
    '   引数：　pm_strTRAKB     : トラン種別
    '           pm_strTRANO     : 見積番号
    '           pm_strMITNOV    : 見積番号版数
    '           pm_strLINNO     : 行番号(更新前)
    '           pm_strErrCd     : 更新異常エラーコード
    '  　     　pm_All          : 画面情報
    '   戻値：　0:正常  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20070126 === UPDATE S - ACE)Nagasawa
'Public Function CF_DTLTRA_Delete(ByVal pm_strTRANO As String, _
'                                 ByVal pm_strMITNOV As String, _
'                                 ByVal pm_strLINNO As String, _
'                                 ByVal pm_strErrCd As String, _
'                                 ByRef pm_All As Cls_All) As Integer
Public Function CF_DTLTRA_Delete(ByVal pm_strTRAKB As String, _
                                 ByVal pm_strTRANO As String, _
                                 ByVal pm_strMITNOV As String, _
                                 ByVal pm_strLINNO As String, _
                                 ByVal pm_strErrCd As String, _
                                 ByRef pm_All As Cls_All) As Integer
' === 20070126 === UPDATE E -

    Dim strSQL              As String
    Dim bolRet              As Boolean
    
On Error GoTo CF_DTLTRA_Delete_Err

    CF_DTLTRA_Delete = 9
    
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        DTLTRA "
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
    strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
    strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
' === 20070126 === INSERT S - ACE)Nagasawa
    strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
' === 20070126 === INSERT E -

    'SQL実行
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo CF_DTLTRA_Delete_Err
    End If
    
    CF_DTLTRA_Delete = 0
    
CF_DTLTRA_Delete_End:
    Exit Function

CF_DTLTRA_Delete_Err:
    Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete")
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_DTLTRA_Update_Ins
    '   概要：  引当内訳ファイル更新処理
    '   引数：　pm_strTRANO_NEW   : トラン番号(新)
    '  　     　pm_strMITNOV_NEW  : 版数(新)
    '  　     　pm_strLINNO_NEW   : 行番号(新)
    '  　     　pm_strTRADT       : 出荷予定日(新)
    '   　      pm_strTRANO_NEW   : トラン番号(旧)
    '  　     　pm_strMITNOV_NEW  : 版数(旧)
    '  　     　pm_strLINNO_NEW   : 行番号(旧)
    '  　     　Pm_strPUDLNO      : 入出庫番号
    '  　     　pm_strErrCd   　　: 更新異常エラーコード
    '  　     　pm_All        : 画面情報
    '   戻値：　0:正常  9:異常
    '   備考：  受注登録時の更新処理(見積の仮引当を受注に付け替える処理）
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20070126 === UPDATE S - ACE)Nagasawa
'Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, _
'                                      ByVal pm_strMITNOV_NEW As String, _
'                                      ByVal pm_strLINNO_NEW As String, _
'                                      ByVal pm_strTRADT As String, _
'                                      ByVal pm_strTRANO_OLD As String, _
'                                      ByVal pm_strMITNOV_OLD As String, _
'                                      ByVal pm_strLINNO_OLD As String, _
'                                      ByVal pm_strErrCd As String, _
'                                      ByRef pm_All As Cls_All) As Integer
Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRAKB As String, _
                                     ByVal pm_strTRANO As String, _
                                     ByVal pm_strMITNOV As String, _
                                     ByVal pm_strLINNO As String, _
                                     ByVal pm_strErrCd As String, _
                                     ByRef pm_All As Cls_All) As Integer
' === 20070126 === UPDATE E -

    Dim strSQL              As String
    Dim bolRet              As Boolean
    
On Error GoTo CF_DTLTRA_Delete_Ins_Err

    CF_DTLTRA_Delete_Ins = 9
    
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        DTLTRA "
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
    strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
    strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
' === 20070126 === INSERT S - ACE)Nagasawa
    strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
' === 20070126 === INSERT E -

    'SQL実行
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo CF_DTLTRA_Delete_Ins_Err
    End If
    
    CF_DTLTRA_Delete_Ins = 0
    
CF_DTLTRA_Delete_Ins_End:
    Exit Function

CF_DTLTRA_Delete_Ins_Err:
    Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete_Ins")
    
End Function
' === 20061217 === INSERT E -

' === 20061217 === INSERT S - ACE)Nagasawa

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Execute_PLSQL_TNADL53
    '   概要：  推定在庫照会用PL/SQL実行処理
    '   引数：　なし
    '   戻値：　戻り値
    '   備考：  PL/SQLを実行する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_Execute_PLSQL_TNADL53(pin_strHINCD As String, _
                                         pin_strSOUCD As String, _
                                         pin_curRELZAISU As Currency) As Integer

    Dim strSQL      As String           'SQL文
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4
    Dim lngPara5    As Long             'ﾊﾟﾗﾒｰﾀ5
    Dim strPara6    As String           'ﾊﾟﾗﾒｰﾀ6
    Dim lngPara7    As Long             'ﾊﾟﾗﾒｰﾀ7
    Dim lngPara8    As Long             'ﾊﾟﾗﾒｰﾀ8
    Dim strPara9    As String           'ﾊﾟﾗﾒｰﾀ9
    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10
    Dim lngPara11   As Long             'ﾊﾟﾗﾒｰﾀ11
    Dim param(12)    As OraParameter     'PL/SQLのバインド変数
    
    '受渡し変数初期設定
    strPara1 = Inp_Inf.InpTanCd                         '入力担当者コード
    strPara2 = Inp_Inf.InpCLIID                         'クライアントID
    strPara3 = CF_Ora_String(pin_strHINCD, 10)          '製品コード
    strPara4 = CF_Ora_String(pin_strSOUCD, 3)           '倉庫コード
    lngPara5 = pin_curRELZAISU                          '現在在庫数
    strPara6 = CF_Ora_String(SSS_PrgId, 10)
    lngPara7 = 0
    lngPara8 = 0
    strPara9 = ""
    lngPara10 = 0
    lngPara10 = 0

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P9", strPara9, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT

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
    Set param(11) = gv_Odb_USR1.Parameters("P11")

    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_NUMBER
    param(6).serverType = ORATYPE_CHAR
    param(7).serverType = ORATYPE_NUMBER
    param(8).serverType = ORATYPE_NUMBER
    param(9).serverType = ORATYPE_VARCHAR2
    param(10).serverType = ORATYPE_NUMBER
    param(11).serverType = ORATYPE_NUMBER

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_TNADL53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"

    'DBアクセス
    Call CF_Ora_Execute(gv_Odb_USR1, strSQL)

    '** 戻り値取得
    lngPara7 = param(7).Value
    lngPara8 = param(8).Value
    strPara9 = param(9).Value
    lngPara10 = param(10).Value
    lngPara11 = param(11).Value
    
    '戻り値設定
    AE_Execute_PLSQL_TNADL53 = lngPara7

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
    gv_Odb_USR1.Parameters.Remove "P11"

End Function
' === 20061217 === INSERT E -

' === 20061219 === INSERT S - ACE)Nagasawa 在庫数チェックの変更
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Chk_INPSU_ZAISU
    '   概要：  在庫数チェック処理
    '   引数：  pm_strHINCD    : 製品コード
    '  　     　pm_curUODSU    : チェック対象数量(出荷実績数＋出荷指示数はﾏｲﾅｽしておく)
    '  　     　pm_strJDNINKB  : 受注取込種別
    '  　     　pm_All         : 画面情報
    '           pm_strTHNSOUCD : 通販倉庫コード
    '   戻値：　0:ﾁｪｯｸOK 1:現在庫ﾁｪｯｸNG 2:有効在庫ﾁｪｯｸNG 3:安全在庫ﾁｪｯｸNG 9:異常
    '   備考：　チェック対象数量に対して、在庫が足りているかをチェックする
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_INPSU_ZAISU(ByVal pm_strHINCD As String, _
                                   ByVal pm_curCHKSU As Currency, _
                                   ByVal pm_strJDNINKB As String, _
                                   ByRef pm_All As Cls_All, _
                                   Optional ByVal pm_strTHNSOUCD As String = "") As Integer

    Dim strSQL              As String
    Dim strSOUCD            As String
    Dim bolRet              As Boolean
    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA
    Dim Usr_Ody             As U_Ody
    Dim curRELZAISU         As Currency
    Dim curHIKSU            As Currency
    Dim bolDyn_Open         As Boolean
    
On Error GoTo CF_Chk_INPSU_ZAISU_Err

    CF_Chk_INPSU_ZAISU = 9
    
    curRELZAISU = 0
    curHIKSU = 0
    bolDyn_Open = False
        
    If Trim(pm_strHINCD) = "" Then
        CF_Chk_INPSU_ZAISU = 0
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    '製品コードより商品マスタ検索
    Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
    If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
        Exit Function
    End If
    
    '在庫管理しないものはチェックしない
    If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
        CF_Chk_INPSU_ZAISU = 0
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    '倉庫コード判定
    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
        strSOUCD = Trim(pm_strTHNSOUCD)
    Else
        strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
    End If
    
    '倉庫別在庫マスタ検索
    strSQL = ""
    strSQL = strSQL & " SELECT "
    strSQL = strSQL & "        RELZAISU "
    strSQL = strSQL & "      , HIKSU "
    strSQL = strSQL & "   FROM "
    strSQL = strSQL & "        HINMTB "
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
    strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
    strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
    
    'SQL実行
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    bolDyn_Open = True
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
        curHIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
    End If
    
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    bolDyn_Open = False
    
    '現在庫チェック
    If (curRELZAISU) - pm_curCHKSU < 0 Then
        CF_Chk_INPSU_ZAISU = 1
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    '有効在庫チェック
    If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
        CF_Chk_INPSU_ZAISU = 2
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    '通販は安全在庫数チェックは行わない
    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
        CF_Chk_INPSU_ZAISU = 0
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    '安全在庫数チェック
    If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
        CF_Chk_INPSU_ZAISU = 3
        GoTo CF_Chk_INPSU_ZAISU_End
    End If
    
    CF_Chk_INPSU_ZAISU = 0
    
CF_Chk_INPSU_ZAISU_End:

    If bolDyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
    End If
    
    Exit Function

CF_Chk_INPSU_ZAISU_Err:
    GoTo CF_Chk_INPSU_ZAISU_End
    
End Function
' === 20061219 === INSERT E -

' === 20070208 === INSERT S - ACE)Nagasawa 在庫数チェックの変更Ver2
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Chk_INPSU_ZAISU_2
    '   概要：  在庫数チェック処理
    '   引数：  pm_strHINCD    : 製品コード
    '  　     　pm_curUODSU    : チェック対象数量(出荷実績数はﾏｲﾅｽしておく)
    '  　     　pm_curMNSSU    : 控除数量(見積登録の場合は参照元見積数量
    '  　     　　　　　　　　　 　　　　 見積訂正の場合は元見積数量
    '  　     　　　　　　　　　 　　　　 受注登録の場合は仮引当数
    '  　     　　　　　　　　　 　　　　 受注訂正の場合は元数量－（出荷実績数）)
    '  　     　pm_strJDNINKB  : 受注取込種別（見積のチェックの際は"0"）
    '  　     　pm_All         : 画面情報
    '           pm_strTHNSOUCD : 通販倉庫コード
    '   戻値：　0:ﾁｪｯｸOK 1:現在庫ﾁｪｯｸNG 2:有効在庫ﾁｪｯｸNG 3:安全在庫ﾁｪｯｸNG 9:異常
    '   備考：　チェック対象数量に対して、在庫が足りているかをチェックする
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_INPSU_ZAISU_2(ByVal pm_strHINCD As String, _
                                     ByVal pm_curCHKSU As Currency, _
                                     ByVal pm_curMNSSU As Currency, _
                                     ByVal pm_strJDNINKB As String, _
                                     ByRef pm_All As Cls_All, _
                                     Optional ByVal pm_strTHNSOUCD As String = "") As Integer

    Dim strSQL              As String
    Dim strSOUCD            As String
    Dim strTHNSOUCD         As String
    Dim bolRet              As Boolean
    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA
    Dim Usr_Ody             As U_Ody
    Dim curRELZAISU         As Currency
    Dim curHIKSU            As Currency
    Dim bolDyn_Open         As Boolean
    
On Error GoTo CF_Chk_INPSU_ZAISU_2_Err

    CF_Chk_INPSU_ZAISU_2 = 9
    
    curRELZAISU = 0
    curHIKSU = 0
    bolDyn_Open = False
        
    If Trim(pm_strHINCD) = "" Then
        CF_Chk_INPSU_ZAISU_2 = 0
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    '//////////////////////////////////////////////////
    '/ マスタ系のチェック
    '//////////////////////////////////////////////////
    
    '製品コードより商品マスタ検索
    Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
    If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
        Exit Function
    End If
    
    '在庫管理しないものはチェックしない
    If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
        CF_Chk_INPSU_ZAISU_2 = 0
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    '倉庫コード判定
    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
        strSOUCD = Trim(pm_strTHNSOUCD)
        strTHNSOUCD = Trim(pm_strTHNSOUCD)
    Else
        strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
    
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        SOUCD "
        strSQL = strSQL & "   FROM "
        strSQL = strSQL & "        SOUMTA "
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        SOUKOKB = '02' "
        'SQL実行
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        bolDyn_Open = True
        If CF_Ora_EOF(Usr_Ody) = False Then
            strTHNSOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")
        End If
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        bolDyn_Open = False
    End If
    
    '倉庫別在庫マスタ検索
    strSQL = ""
    strSQL = strSQL & " SELECT "
    strSQL = strSQL & "        RELZAISU "
    strSQL = strSQL & "   FROM "
    strSQL = strSQL & "        HINMTB "
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
    strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
    strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
    
    'SQL実行
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    bolDyn_Open = True
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
    End If
    
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    bolDyn_Open = False
    
    
    '//////////////////////////////////////////////////
    '/ 見積（仮引当）分の見積数の合計
    '//////////////////////////////////////////////////
    '通販以外のときのみ
    If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
        '見積検索
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        SUM(TRA.MITSU) YTSU "
        strSQL = strSQL & "   FROM "
        strSQL = strSQL & "        MITTHA THA "
        strSQL = strSQL & "       ,MITTRA TRA "
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        THA.DATNO = TRA.DATNO "
        strSQL = strSQL & "    AND THA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
        strSQL = strSQL & "    AND THA.JDNNO = '          ' "
        strSQL = strSQL & "    AND TRA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
        strSQL = strSQL & "    AND TRA.HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
        strSQL = strSQL & "    AND TRA.KHIKKB = '1' "
        'SQL実行
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        bolDyn_Open = True
        If CF_Ora_EOF(Usr_Ody) = False Then
            curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
        End If
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        bolDyn_Open = False
    End If
    
    '//////////////////////////////////////////////////
    '/ 受注分の（受注数 - 実績数）の合計
    '//////////////////////////////////////////////////
    '受注検索
    strSQL = ""
    strSQL = strSQL & " SELECT "
    strSQL = strSQL & "        SUM(TRA.UODSU - TRA.OTPSU) YTSU "
    strSQL = strSQL & "   FROM "
    strSQL = strSQL & "        JDNTHA THA "
    strSQL = strSQL & "       ,JDNTRA TRA "
    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
    strSQL = strSQL & "                ,JDNNO "
    strSQL = strSQL & "          FROM   JDNTHA "
    strSQL = strSQL & "          WHERE  JDNENDKB = '0' "
    strSQL = strSQL & "          GROUP BY JDNNO "
    strSQL = strSQL & "        ) THB "
    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
    strSQL = strSQL & "                ,JDNNO "
    strSQL = strSQL & "                ,LINNO "
    strSQL = strSQL & "          FROM   JDNTRA "
    strSQL = strSQL & "          WHERE  DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
    strSQL = strSQL & "            AND  HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
    strSQL = strSQL & "            AND  UODSU > OTPSU "
    strSQL = strSQL & "          GROUP BY JDNNO "
    strSQL = strSQL & "                  ,LINNO "
    strSQL = strSQL & "        ) TRB "
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        THA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
    strSQL = strSQL & "    AND THA.AKAKROKB = '1' "
    strSQL = strSQL & "    AND THA.DATNO    = THB.DATNO "
    strSQL = strSQL & "    AND THA.JDNNO    = THB.JDNNO "
    strSQL = strSQL & "    AND TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
    strSQL = strSQL & "    AND TRA.AKAKROKB = '1' "
    strSQL = strSQL & "    AND TRA.DATNO    = TRB.DATNO "
    strSQL = strSQL & "    AND TRA.JDNNO    = TRB.JDNNO "
    strSQL = strSQL & "    AND TRA.LINNO    = TRB.LINNO "
    strSQL = strSQL & "    AND THA.DATNO    = TRA.DATNO "
    strSQL = strSQL & "    AND THA.JDNTRKB  IN ( '01', '11', '21' ) "
    strSQL = strSQL & "    AND TRA.HINCD    = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
    strSQL = strSQL & "    AND TRA.JDNKB    IN ( '1', '2' ) "
    '通販時は通販倉庫
    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
        strSQL = strSQL & " AND TRA.SOUCD = '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
    Else
        strSQL = strSQL & " AND TRA.SOUCD <> '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
    End If
    'SQL実行
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    bolDyn_Open = True
    If CF_Ora_EOF(Usr_Ody) = False Then
        curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
    End If
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    bolDyn_Open = False
    
    '//////////////////////////////////////////////////
    '/ 支給品分の（予定数 - 実績数）の合計
    '//////////////////////////////////////////////////
    '通販以外のときのみ
    If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
        '支給品検索
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        SUM(OUTYOTSU - OUTZMISU) YTSU "
        strSQL = strSQL & "   FROM "
        strSQL = strSQL & "        SKYTBL "
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
        strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
        strSQL = strSQL & "    AND PLANKB = ' ' "
        'SQL実行
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        bolDyn_Open = True
        If CF_Ora_EOF(Usr_Ody) = False Then
            curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
        End If
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        bolDyn_Open = False
    End If
    
    '//////////////////////////////////////////////////
    '/ 製番出庫の（予定数 - 実績数）の合計
    '//////////////////////////////////////////////////
    '通販以外のときのみ
    If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
        '製番出庫検索
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "        SUM(FRDYTSU - OUTSMSU) YTSU "
        strSQL = strSQL & "   FROM "
        strSQL = strSQL & "        SBNTRA "
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
        strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
        strSQL = strSQL & "    AND OUTSOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
        'SQL実行
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        bolDyn_Open = True
        If CF_Ora_EOF(Usr_Ody) = False Then
            curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
        End If
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        bolDyn_Open = False
    End If
    
    '出荷予定数の補正
    curHIKSU = curHIKSU - pm_curMNSSU
    
    
    '//////////////////////////////////////////////////
    '/ 各種チェック
    '//////////////////////////////////////////////////
    '現在庫チェック
    If (curRELZAISU) - pm_curCHKSU < 0 Then
        CF_Chk_INPSU_ZAISU_2 = 1
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    '有効在庫チェック
    If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
        CF_Chk_INPSU_ZAISU_2 = 2
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    '通販は安全在庫数チェックは行わない
    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
        CF_Chk_INPSU_ZAISU_2 = 0
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    '安全在庫数チェック
    If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
        CF_Chk_INPSU_ZAISU_2 = 3
        GoTo CF_Chk_INPSU_ZAISU_2_End
    End If
    
    CF_Chk_INPSU_ZAISU_2 = 0
    
CF_Chk_INPSU_ZAISU_2_End:

    If bolDyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
    End If
    
    Exit Function

CF_Chk_INPSU_ZAISU_2_Err:
    GoTo CF_Chk_INPSU_ZAISU_2_End
    
End Function
' === 20070208 === INSERT E -

' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_ZIPCD
'   概要：  郵便番号チェック処理
'   引数：  pin_strZIPCD            : チェック対象郵便番号
'           pin_intKETA             : 郵便番号入力可能桁数
'           pin_intZIP_HAIHUN       : ハイフン位置（左より）
'           pin_strFRNKB            : 海外取引区分
'   戻値：  0 : チェックOK   9 : チェックNG
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_ZIPCD(ByVal pin_strZIPCD As String, _
                             ByVal pin_intKETA As Integer, _
                             ByVal pin_intZIP_HAIHUN As Integer, _
                             ByVal pin_strFRNKB As String) As Integer
    
    Dim intHaihun           As Integer
    Dim intCnt              As Integer
    Dim intLstHaihun        As Integer          '最後のハイフン位置
    
    CF_Chk_ZIPCD = 9
    
    '取引先が国内の場合のみチェックを行う
    If pin_strFRNKB <> gc_strFRNKB_FRN Then
        
        '空白はOKとする
        If Trim(pin_strZIPCD) = "" Then
            CF_Chk_ZIPCD = 0
            Exit Function
        End If
        
        '桁数チェック
        If Len(pin_strZIPCD) <> pin_intKETA Then
            CF_Chk_ZIPCD = 10
            Exit Function
        End If
        
        'ハイフン位置チェック
        For intCnt = 1 To pin_intKETA
            If intCnt = pin_intZIP_HAIHUN Then
                If MidWid(pin_strZIPCD, intCnt, 1) <> "-" Then
                    CF_Chk_ZIPCD = 20
                    Exit Function
                End If
            Else
                If IsNumeric(MidWid(pin_strZIPCD, intCnt, 1)) = False Then
                    CF_Chk_ZIPCD = 20
                    Exit Function
                End If
            End If
        Next
    End If
    
    CF_Chk_ZIPCD = 0
    
End Function
' === 20061223 === INSERT E -

' === 20070115 === INSERT S - ACE)Nagasawa 訂正前に更新時間チェックを入れる
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_UWRTDTTM
'   概要：  バッチ更新日付時間取得処理
'   引数：  pin_strTBLNM            : 検索対象テーブル名
'           pin_strDATNO            : 伝票管理番号（省略時条件に含めない）
'           pin_strRECNO            : レコード管理番号（省略時条件に含めない）
'           pot_strUWRTDT           : バッチ更新日付
'           pot_strUWRTTM           : バッチ更新時刻
'   戻値：  0 : 正常終了  9 : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_UWRTDTTM(ByVal pin_strTBLNM As String, _
                                ByRef pot_strUWRTDT As String, _
                                ByRef pot_strUWRTTM As String, _
                                Optional ByVal pin_strDatNo As String = "", _
                                Optional ByVal pin_strRECNO As String = "", _
                                Optional ByVal pin_strELSE As String = "") As Integer
    
On Error GoTo CF_Get_UWRTDTTM_ERR
    
    Dim Str_Sql         As String
    Dim Usr_Ody         As U_Ody
    Dim Str_Where       As String
    
    CF_Get_UWRTDTTM = 9
    
    '// 初期化
    pot_strUWRTDT = ""
    pot_strUWRTTM = ""
    
    '引数チェック
    If Trim(pin_strDatNo) = "" And Trim(pin_strRECNO) = "" And Trim(pin_strELSE) = "" Then
        GoTo CF_Get_UWRTDTTM_END
    End If
    
    Str_Sql = ""
    Str_Sql = Str_Sql & " SELECT "
    Str_Sql = Str_Sql & "        UWRTDT "
    Str_Sql = Str_Sql & "      , UWRTTM "
    Str_Sql = Str_Sql & "   FROM "
    Str_Sql = Str_Sql & "        " & Trim(pin_strTBLNM)
    
    '検索条件編集
    Str_Where = ""
    '伝票管理番号
    If Trim(pin_strDatNo) <> "" Then
        Str_Where = Str_Where & "        DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
    End If
    
    'レコード管理番号
    If Trim(pin_strRECNO) <> "" Then
        If Trim(Str_Where) <> "" Then
            Str_Where = Str_Where & " AND "
        End If
        
        Str_Where = Str_Where & "        RECNO = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
    End If
    
    'それ以外
    If Trim(pin_strELSE) <> "" Then
        If Trim(Str_Where) <> "" Then
            Str_Where = Str_Where & " AND "
        End If
        
        Str_Where = Str_Where & pin_strELSE
    End If
    
    If Trim(Str_Where) <> "" Then
        Str_Sql = Str_Sql & "  WHERE " & Str_Where
    End If
    
' === 20080209 === INSERT S - ACE)Nagasawa 行ロック追加
    Str_Sql = Str_Sql & "  For Update "
' === 20080209 === INSERT E -

    If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
        GoTo CF_Get_UWRTDTTM_ERR
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        pot_strUWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT"))
        pot_strUWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM"))
    End If
    
    CF_Get_UWRTDTTM = 0

CF_Get_UWRTDTTM_END:
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function
    
CF_Get_UWRTDTTM_ERR:
    GoTo CF_Get_UWRTDTTM_END
    
End Function
' === 20070115 === INSERT E -

' === 20070301 === INSERT S - ACE)Nagasawa 消費税が算出できなかった場合にメッセージ表示
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_TAXKBN_TOK
'   概要：  消費税取得用の区分チェック処理（得意先）
'   引数：  Pin_strTOKZEIKB　: 得意先消費税区分
'           Pin_strTOKRPSKB　: 消費税端数処理桁数
'           Pin_strTOKZRNKB　: 消費税端数処理区分
'           Pot_strErrMsg　　: エラーメッセージ
'   戻値：  True : チェックOK  False : チェックNG
'   備考：　消費税が取得できるかどうかのチェックを行います
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_TAXKBN_TOK(ByVal Pin_strTOKZEIKB As String, _
                                  ByVal Pin_strTOKRPSKB As String, _
                                  ByVal Pin_strTOKZRNKB As String, _
                                  ByRef Pot_strErrMsg As String) As Boolean

    Dim strErrMsg       As String
    
    CF_Chk_TAXKBN_TOK = True
    Pot_strErrMsg = ""
    strErrMsg = ""
    
    '得意先消費税区分チェック
    Select Case Trim(Pin_strTOKZEIKB)
        Case gc_strTOKZEIKB_NUK, gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_HIK
        Case Else
            strErrMsg = "消費税区分"
    End Select
    
    '消費税端数処理桁数チェック
    Select Case Trim(Pin_strTOKRPSKB)
        Case gc_strTOKRPSKB_0, gc_strTOKRPSKB_10, gc_strTOKRPSKB_100
        Case Else
            If Trim(strErrMsg) <> "" Then
                strErrMsg = strErrMsg & "、"
            End If
            strErrMsg = strErrMsg & "得意先消費税端数処理"
    End Select
    
    '消費税端数処理区分チェック
    Select Case Trim(Pin_strTOKZRNKB)
        Case gc_strTOKZRNKB_DWN, gc_strTOKZRNKB_RND, gc_strTOKZRNKB_UP
        Case Else
            If InStr(1, strErrMsg, "得意先消費税端数処理") = 0 Then
                If Trim(strErrMsg) <> "" Then
                    strErrMsg = strErrMsg & "、"
                End If
                strErrMsg = strErrMsg & "得意先消費税端数処理"
            End If
    End Select

    If Trim(strErrMsg) <> "" Then
        Pot_strErrMsg = vbCrLf & "取引先詳細登録画面で" & strErrMsg & "を確認してください。"
        CF_Chk_TAXKBN_TOK = False
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_TAXKBN_HIN
'   概要：  消費税取得用の区分チェック処理（商品）
'   引数：  Pin_strHINZEIKB　: 商品消費税区分
'           Pin_strZEIRNKKB　: 消費税ランク
'           Pot_strErrMsg　　: エラーメッセージ
'   戻値：  True : チェックOK  False : チェックNG
'   備考：　消費税が取得できるかどうかのチェックを行います
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_TAXKBN_HIN(ByVal Pin_strHINZEIKB As String, _
                                  ByVal pin_strZEIRNKKB As String, _
                                  ByRef Pot_strErrMsg As String) As Boolean

    Dim strErrMsg       As String
    
    CF_Chk_TAXKBN_HIN = True
    Pot_strErrMsg = ""
    strErrMsg = ""

    '商品消費税区分チェック
    Select Case Trim(Pin_strHINZEIKB)
        Case gc_strHINZEIKB_TOK, gc_strHINZEIKB_NUK, gc_strHINZEIKB_KOM, gc_strHINZEIKB_HIK
        Case Else
            strErrMsg = "消費税区分"
    End Select
    
    '消費税ランク
    If Trim(pin_strZEIRNKKB) = "" Then
        If Trim(strErrMsg) <> "" Then
            strErrMsg = strErrMsg & "、"
        End If
        strErrMsg = strErrMsg & "消費税率"
    End If
    
    If Trim(strErrMsg) <> "" Then
        Pot_strErrMsg = vbCrLf & "商品詳細登録画面で" & strErrMsg & "を確認してください。"
        CF_Chk_TAXKBN_HIN = False
    End If
    
End Function
' === 20070301 === INSERT E -

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CmnSYSTBCSaiban
'   概要：  SYSTBCより伝票番号採番処理
'   引数：　Pm_strJDNTRKB      :伝票取引区分種別
'           Pm_strADDDENCD     :伝票付属コード("":空文字の場合は検索条件に含めない)
'           Pm_strDENNO()      :採番された伝票番号
'           Pm_strGetADDDENCD  :伝票付属コード
'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Static Function AE_CmnSYSTBCSaiban(ByVal Pm_strDKBSB As String, _
                                          ByVal Pm_strADDDENCD As String, _
                                          ByRef Pm_strDENNO() As String, _
                                 Optional ByRef Pm_strGetADDDENCD As String) As Integer

    Dim strSQL                              As String
    Dim usrOdy                              As U_Ody
    Dim bolRet                              As Boolean
    Dim bolTran                             As Boolean
    Dim curDENNO                            As Currency
    Dim curSTTNO                            As Currency
    Dim curENDNO                            As Currency
    Dim strADDDENCD                         As String
    Dim intCnt                              As Integer
    Dim strNewNO                            As String

On Error GoTo ERR_AE_CmnSYSTBCSaiban

    AE_CmnSYSTBCSaiban = 9
    
    bolTran = False
    
    Pm_strGetADDDENCD = ""
    
    'トランザクション開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTran = True

    'ユーザー伝票№テーブル取得
    strSQL = ""
    strSQL = strSQL & " Select *             "
    strSQL = strSQL & "   from SYSTBC        "
    strSQL = strSQL & "  Where DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
    If Pm_strADDDENCD <> "" Then
        strSQL = strSQL & "    And ADDDENCD = '" & CF_Ora_String(Pm_strADDDENCD, 13) & "' "
    End If
    strSQL = strSQL & "    for Update "

    'SQL実行
    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
    If bolRet = False Then
        GoTo ERR_AE_CmnSYSTBCSaiban
    End If

    'EOF判定
    If CF_Ora_EOF(usrOdy) = True Then
        AE_CmnSYSTBCSaiban = 1
        GoTo ERR_AE_CmnSYSTBCSaiban
    End If

    '伝票付属コード取得
    Pm_strGetADDDENCD = CF_Ora_GetDyn(usrOdy, "ADDDENCD", "")
    
    '開始伝票No取得
    If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
        curSTTNO = 1
    Else
        curSTTNO = CCur(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
    End If
    
    '終了伝票No取得
    If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
        curENDNO = 1
    Else
        curENDNO = CCur(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
    End If
    
    '伝票NO.取得
    curDENNO = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
    If curDENNO > curENDNO Then
        '終了伝票NOを超えた場合は戻る
        curDENNO = curSTTNO
    End If
    
    For intCnt = 1 To UBound(Pm_strDENNO)
        strNewNO = Format(curDENNO, String(8, "0"))
        Pm_strDENNO(intCnt) = strNewNO
        curDENNO = curDENNO + 1
        If curDENNO > curENDNO Then
            '終了伝票Noを超えた場合は戻る
            curDENNO = curSTTNO
        End If
    Next intCnt

    'ユーザー伝票№テーブル更新
    If UBound(Pm_strDENNO) > 0 Then
    
        strSQL = ""
        strSQL = strSQL & " UPDATE SYSTBC "
        strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewNO, 8) & "' "
        
        If Trim(GV_SysTime) <> "" Then
            strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
        Else
            strSQL = strSQL & "      , WRTTM      = '" & CStr(Format(Now, "hhmmss")) & "' "
        End If
        
        If Trim(GV_SysDate) <> "" Then
            strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
        Else
            strSQL = strSQL & "      , WRTDT      = '" & CStr(Format(Now, "yyyymmdd")) & "' "
        End If
        
        strSQL = strSQL & "  WHERE "
        strSQL = strSQL & "        DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
        
        'ＳＱＬ実行
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
            GoTo ERR_AE_CmnSYSTBCSaiban
        End If
    End If

    bolRet = CF_Ora_CloseDyn(usrOdy)
    If bolRet = False Then
        GoTo ERR_AE_CmnSYSTBCSaiban
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTran = False
    
    AE_CmnSYSTBCSaiban = 0

EXIT_AE_CmnSYSTBCSaiban:
    Exit Function

ERR_AE_CmnSYSTBCSaiban:

    If gv_Int_OraErr = 51 Then
        '他で使用中
        AE_CmnSYSTBCSaiban = 2
    End If

    If bolTran = True Then
        'ロールバック
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If

    GoTo EXIT_AE_CmnSYSTBCSaiban

End Function
' === 20070327 === INSERT E -

