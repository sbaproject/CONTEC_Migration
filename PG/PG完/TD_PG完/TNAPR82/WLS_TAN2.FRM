VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSTAN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "担当者一覧ウィンドウ"
   ClientHeight    =   5835
   ClientLeft      =   1230
   ClientTop       =   3285
   ClientWidth     =   9600
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   5835
   ScaleWidth      =   9600
   Begin VB.TextBox HD_TANBMNCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   3705
      MaxLength       =   6
      TabIndex        =   4
      Text            =   "XXXXX6"
      Top             =   525
      Width           =   795
   End
   Begin Threed5.SSPanel5 PNL_BMNCD 
      Height          =   375
      Left            =   2115
      TabIndex        =   13
      Top             =   525
      Width           =   1635
      _ExtentX        =   2884
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "所属部門ｺｰﾄﾞ"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   4800
      TabIndex        =   6
      Top             =   5160
      Width           =   915
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   3855
      TabIndex        =   5
      Top             =   5160
      Width           =   915
   End
   Begin VB.TextBox HD_Kana 
      Height          =   375
      IMEMode         =   6  '半角ｶﾀｶﾅ
      Left            =   6480
      TabIndex        =   12
      TabStop         =   0   'False
      Text            =   "ｱｲｳｴｵ"
      Top             =   90
      Visible         =   0   'False
      Width           =   690
   End
   Begin VB.TextBox HD_TAN 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   3720
      MaxLength       =   20
      TabIndex        =   2
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   90
      Width           =   2475
   End
   Begin Threed5.SSPanel5 PNL_TANNM 
      Height          =   375
      Left            =   2115
      TabIndex        =   11
      Top             =   90
      Width           =   1635
      _ExtentX        =   2884
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "担当者名"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 PNL_USENM 
      Height          =   375
      Index           =   3
      Left            =   7180
      TabIndex        =   10
      Top             =   90
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "カナ検索"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ComboBox WLSKANA 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   360
      Left            =   8325
      Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
      TabIndex        =   3
      Top             =   90
      Width           =   1185
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   9
      Top             =   1080
      Width           =   9510
      _ExtentX        =   16775
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   "WLSLABEL"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      Left            =   45
      TabIndex        =   0
      Top             =   1440
      Width           =   9510
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1035
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   9600
      _ExtentX        =   16933
      _ExtentY        =   1826
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1170
         MaxLength       =   13
         TabIndex        =   1
         Text            =   "XXXXX6"
         Top             =   90
         Width           =   795
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   90
         TabIndex        =   8
         Top             =   90
         Width           =   1095
         _ExtentX        =   1931
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "開始ｺｰﾄﾞ"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5835
      Picture         =   "WLS_TAN2.frx":0000
      Top             =   5160
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   3360
      Picture         =   "WLS_TAN2.frx":0652
      Top             =   5160
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4425
      Picture         =   "WLS_TAN2.frx":0CA4
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5325
      Picture         =   "WLS_TAN2.frx":12F6
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4920
      Picture         =   "WLS_TAN2.frx":1948
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4020
      Picture         =   "WLS_TAN2.frx":1F9A
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
End
Attribute VB_Name = "WLSTAN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '以下の ３行の設定を行うこと
    Const WM_WLS_MSTKB = "3"            'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
    Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]
    Const WM_WLSKEY_ZOKUSEI_BMN = "0"   '部門コード入力属性 [0,X]
    Const WM_WLS_KanaINPUT = False      'カナ直接入力使用（True:直接入力 False:カナコンボ）
    Const WM_WLS_TanINPUT = True
    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey = 1            '開始コードのソートキーNo
    Const WM_WLS_KanaKey = 2            'カナ検索のソートキーNo+第一キー
    Const WM_WLS_TanKey = 3
    Const WM_WLS_BmnKey = 4

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL As Integer
    Dim WM_WLS_LEN As Integer           '開始ｺｰﾄﾞ入力文字数
    Dim WM_WLS_KANALEN As Integer       'カナ入力文字数
    Dim WM_WLS_TANLEN As Integer        '担当者名入力文字数
    
    'ウィンド内部使用変数
    Dim WM_WLS_MAX As Integer           '１画面の表示件数
    Dim WM_WLS_STTKEY                   '開始キー
    Dim WM_WLS_ENDKEY                   '終了キー
    Dim WM_WLS_KeyNo As Integer         'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
    Dim WM_WLS_Pagecnt As Integer       'ウィンド表示ページカウンタ
    Dim WM_WLS_LastPage As Integer      'ウィンド最終ページ
    Dim WM_WLS_LastFL As Boolean        'ウィンド最終データ到達フラグ
    Dim WM_WLS_DSPArray() As String     'ウィンド表示データ
    Dim WM_WLS_Dspflg As Integer        'ウィンド表示ﾌﾗｸﾞ(True or False)

    Dim WlsSelList$
    Dim SWlsSelList$
    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$

    Dim DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub WLS_FORM_INIT()
    
    DBN_TANMTA = 0
    DB_PARA(DBN_TANMTA).tblid = "TANMTA"
    DB_PARA(DBN_TANMTA).DBID = "USR1"
    
    DBN_BMNMTA = 1
    DB_PARA(DBN_BMNMTA).tblid = "BMNMTA"
    DB_PARA(DBN_BMNMTA).DBID = "USR1"
    
    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_TANMTA
    WM_WLS_SFIL = DBN_BMNMTA
    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = Len(DB_TANMTA.TANCD)     'LenWid はダメ
    WM_WLS_KANALEN = Len(DB_TANMTA.TANNK) 'LenWid はダメ
    WM_WLS_TANLEN = Len(DB_TANMTA.TANNM)
    WlsSelList = "TANCD, TANNM, TANNK, TANBMNCD,DATKB,TANCLAKB,TANCLBKB"
    SWlsSelList = "*"
    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "コード  担当者名                        所属部門"
               'XXXXX6  MMMMMMMMM1MMMMMMMMM2MMMMMMMMMM3  MMMMMMMMM1MMMMMMMMM2

    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    'HD_TEXT.Height = 330
    HD_TEXT.MaxLength = WM_WLS_LEN
    HD_TEXT.Width = (WM_WLS_LEN + 1) * 120
    

End Sub

Private Function WLS_DSP_CHECK()
    If DB_TANMTA.DATKB = "9" Then
        WLS_DSP_CHECK = SSS_NEXT
    Else
        WLS_DSP_CHECK = SSS_OK
    End If
End Function

Private Sub WLS_SetArray(ByVal ArrayCnt%)
    '====================================
    '   WINDOW 明細設定
    '====================================
    Call WLS_BMNSQL
    'WM_WLS_DSPArray(ArrayCnt) = DB_TANMTA.TANCD & "  " & LeftWid(DB_TANMTA.TANNM, Len(DB_TANMTA.TANNM)) & "  " & LeftWid(DB_BMNMTA.BMNNM, Len(DB_BMNMTA.BMNNM))
    WM_WLS_DSPArray(ArrayCnt) = DB_TANMTA.TANCD & "  " & LeftWid(DB_TANMTA.TANNM, 30) & "  " & LeftWid(DB_BMNMTA.BMNNM, Len(DB_BMNMTA.BMNNM))

End Sub

Sub WLS_TextSQL()
    WM_WLS_KeyNo = WM_WLS_TextKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From TANMTA Where TANCD >= '" & WM_WLS_STTKEY & "'"
    WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
    WlsOrderBy = "Order By TANCD"
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub
Sub WLS_TANSQL()
    WM_WLS_KeyNo = WM_WLS_TanKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From TANMTA Where TANNM Like '%" & WM_WLS_STTKEY & "%'"
    WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
    WlsOrderBy = "Order By TANCD"
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_KanaSQL()
    WM_WLS_KeyNo = WM_WLS_KanaKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From TANMTA Where TANNK >= '" & WM_WLS_STTKEY & "' And TANNK < '" & WM_WLS_ENDKEY & "'"
    WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
    WlsOrderBy = "Order By TANCD"
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub
Sub WLS_TANBMNSQL()
    WM_WLS_KeyNo = WM_WLS_TanKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From TANMTA Where TANBMNCD = '" & WM_WLS_STTKEY & "'"
    WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
    WlsOrderBy = "Order By TANCD"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_BMNSQL()
    WM_WLS_KeyNo = WM_WLS_BmnKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    Call BMNMTA_RClear
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From BMNMTA Where BMNCD = '" & Trim$(DB_TANMTA.TANBMNCD) & "'"
    WlsOrderBy = "Order By BMNCD"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)
End Sub

Private Sub WLS_DspNew()
    Dim WL_Mode As Integer
Dim cnt%

    WL_Mode = 0
    cnt = 0
    Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        WL_Mode = WLS_DSP_CHECK()
        If WL_Mode = SSS_OK Then
            If cnt = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                WM_WLS_LastPage = WM_WLS_Pagecnt
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            End If
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
            cnt = cnt + 1
        End If
        If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
    If cnt > 0 Then
        Call WLS_DspPage
    Else
        LST.Clear
    End If
End Sub

Private Sub WLS_DspPage()
Dim WL_Mode As Integer
Dim cnt%

    LST.Clear
    cnt = 0
    Do While cnt < WM_WLS_MAX
        If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
            LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        End If
        cnt = cnt + 1
    Loop
    If LST.ListCount > 0 Then
        LST.ListIndex = 0
        LST.SetFocus
    End If
End Sub


Sub WLS_Kana_Init()

    'カナ検索 Combo 初期化
    'この一行を実行しないと, WLSKANA.ListIndex = 0 でエラーになる
    WLSKANA.AddItem "コード"

    If WM_WLS_KanaKey < 1 Then
    'カナ検索をしない
        PNL_USENM(3).Visible = False
        WLSKANA.Visible = False
        HD_Kana.Visible = False
    ElseIf WM_WLS_KanaINPUT Then
    'カナ手入力項目の有効化
        WLSKANA.Visible = False
        HD_Kana.Visible = True
        HD_Kana.Width = WLSKANA.Width
        HD_Kana.Left = WLSKANA.Left
    Else
        WLSKANA.AddItem "ア行      ｱｵ"
        WLSKANA.AddItem "カ行      ｶｺ"
        WLSKANA.AddItem "サ行      ｻｿ"
        WLSKANA.AddItem "タ行      ﾀﾄ"
        WLSKANA.AddItem "ナ行      ﾅﾉ"
        WLSKANA.AddItem "ハ行      ﾊﾎ"
        WLSKANA.AddItem "マ行      ﾏﾓ"
        WLSKANA.AddItem "ヤ行      ﾔﾖ"
        WLSKANA.AddItem "ラ行      ﾗﾛ"
        WLSKANA.AddItem "ワ行      ﾜﾝ"
    End If
End Sub
'
'以下は画面イベント処理
'
Private Sub Form_Activate()

    '=== WINDOW 位置設定 ===
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    WM_WLS_STTKEY = ""
    WM_WLS_ENDKEY = Null
    HD_TEXT.Text = ""
    WM_WLS_Dspflg = False
    WLSKANA.ListIndex = 0
    HD_Kana.Text = ""
    HD_TAN.Text = ""
    HD_TANBMNCD.Text = ""
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    WM_WLS_LastPage = -1
    WM_WLS_LastFL = False
    ReDim WM_WLS_DSPArray(0)

    Call WLS_TextSQL
    Call WLS_DspNew

    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
    Call WLS_Kana_Init
End Sub
Private Sub HD_TAN_GotFocus()
'''    If LenWid(HD_TAN.Text) > 0 Then
'''        HD_TAN.Text = SSS_EDTITM_WLS(HD_TAN.Text, HD_TAN.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_TAN.Text = Space$(HD_TAN.MaxLength)
'''    End If
    HD_TAN.SelStart = 0
    HD_TAN.SelLength = HD_TAN.MaxLength
End Sub

Private Sub HD_TAN_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = ""
        HD_TANBMNCD.Text = ""
        WLSKANA.ListIndex = 0
        WM_WLS_STTKEY = HD_TAN.Text
        WM_WLS_ENDKEY = HD_TAN.Text
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_TANSQL
        Call WLS_DspNew

    End If
End Sub

Private Sub HD_Kana_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = ""
        WM_WLS_STTKEY = HD_Kana.Text
        WM_WLS_ENDKEY = Chr$(Asc("ﾝ") + 1)
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_KanaSQL
        Call WLS_DspNew
        
    End If
End Sub

Private Sub HD_Kana_KeyPress(KeyAscii As Integer)
    If KeyAscii < Asc(" ") Then Exit Sub
        ''2000/04/18 カナ入力文字範囲の誤りを修正
        ''If KeyAscii < Asc("ｱ") Or KeyAscii > Asc("ﾝ") Then
        If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then Exit Sub
        If KeyAscii < Asc("｡") Or KeyAscii > Asc("ﾟ") Then
        KeyAscii = 0
    End If
End Sub

Private Sub HD_TANBMNCD_Change()
    Dim s As Long
    s = HD_TANBMNCD.SelStart
    HD_TANBMNCD.Text = StrConv(HD_TANBMNCD.Text, vbUpperCase)
    HD_TANBMNCD.SelStart = s
End Sub

Private Sub HD_TANBMNCD_GotFocus()
''    If LenWid(HD_TANBMNCD.Text) > 0 Then
''        HD_TANBMNCD.Text = SSS_EDTITM_WLS(HD_TANBMNCD.Text, HD_TANBMNCD.MaxLength, WM_WLSKEY_ZOKUSEI_BMN)
''    Else
''        HD_TEXT.Text = Space$(HD_TANBMNCD.MaxLength)
''    End If
    HD_TANBMNCD.SelStart = 0
    HD_TANBMNCD.SelLength = HD_TANBMNCD.MaxLength
End Sub

Private Sub HD_TANBMNCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TANBMNCD.Text = SSS_EDTITM_WLS(HD_TANBMNCD.Text, HD_TANBMNCD.MaxLength, WM_WLSKEY_ZOKUSEI_BMN)
        WM_WLS_STTKEY = HD_TANBMNCD.Text
        WM_WLS_ENDKEY = Null
        WLSKANA.ListIndex = 0
        HD_Kana.Text = ""
        HD_TAN.Text = ""
        HD_TEXT.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_TANBMNSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_TEXT_Change()
    Dim s As Long
    s = HD_TEXT.SelStart
    HD_TEXT.Text = StrConv(HD_TEXT.Text, vbUpperCase)
    HD_TEXT.SelStart = s
End Sub

Private Sub HD_TEXT_GotFocus()
'''    If LenWid(HD_TEXT.Text) > 0 Then
'''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
'''    End If
    HD_TEXT.SelStart = 0
    HD_TEXT.SelLength = HD_TEXT.MaxLength
End Sub

Private Sub HD_TEXT_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        WM_WLS_STTKEY = HD_TEXT.Text
        WM_WLS_ENDKEY = Null
        WLSKANA.ListIndex = 0
        HD_Kana.Text = ""
        HD_TANBMNCD.Text = ""
        HD_TAN.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadイベント障害対応  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case vbKeyReturn
            Call WLSOK_Click
        Case vbKeyEscape
            Call WLSCANCEL_CLICK
        Case vbKeyLeft     '←キー
            Call WLSMAE_Click
        Case vbKeyRight    '→キー
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
End Sub


Private Sub WLSKANA_Click()
Dim W_BUF
    If WM_WLS_Dspflg = False Then Exit Sub
    WM_WLS_Dspflg = False
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    WM_WLS_LastPage = -1
    WM_WLS_LastFL = False
    ReDim WM_WLS_DSPArray(0)

    If WLSKANA.ListIndex > 0 Then
        HD_TEXT.Text = ""
        HD_TAN.Text = ""
        HD_TANBMNCD.Text = ""
        W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
        WM_WLS_STTKEY = Left$(W_BUF, 1)
        WM_WLS_ENDKEY = Chr$(Asc(Right$(W_BUF, 1)) + 1)
        Call WLS_KanaSQL
    Else
        WM_WLS_STTKEY = Format$(HD_TEXT.Text)
        Call WLS_TextSQL
    End If
    Call WLS_DspNew
End Sub

Private Sub WLSKANA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = True
        Call WLSKANA_Click
    Else
        WM_WLS_Dspflg = False
    End If
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspNew
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub

Private Sub WLSMAE_Click()
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub WLSOK_Click()
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
    Call WLSCANCEL_CLICK
End Sub

Private Sub WLSCANCEL_CLICK()
    'UnLoadイベント障害対応  97/04/07
    'Unload Me
    Hide
End Sub
