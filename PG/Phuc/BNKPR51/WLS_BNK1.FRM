VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSBNK 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "銀行検索ウィンドウ"
   ClientHeight    =   5025
   ClientLeft      =   375
   ClientTop       =   3105
   ClientWidth     =   14070
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
   ScaleHeight     =   5025
   ScaleWidth      =   14070
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   3
      Top             =   120
      Width           =   13815
      _ExtentX        =   24368
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
      Top             =   480
      Width           =   13815
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   6113
      TabIndex        =   1
      Top             =   4545
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   7058
      TabIndex        =   2
      Top             =   4545
      Width           =   915
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4455
      Picture         =   "WLS_BNK1.frx":0000
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   5355
      Picture         =   "WLS_BNK1.frx":0652
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5760
      Picture         =   "WLS_BNK1.frx":0CA4
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4860
      Picture         =   "WLS_BNK1.frx":12F6
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5618
      Picture         =   "WLS_BNK1.frx":1948
      Top             =   4545
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   8093
      Picture         =   "WLS_BNK1.frx":1F9A
      Top             =   4545
      Width           =   360
   End
End
Attribute VB_Name = "WLSBNK"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '以下の ３行の設定を行うこと
    Const WM_WLS_MSTKB = "5"            'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
    Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]
    Const WM_WLS_KanaINPUT = False      'カナ直接入力使用（True:直接入力 False:カナコンボ）

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_NmaKey = 1             '型式コードのソートキーNo
    Const WM_WLS_TextKey = 2            '開始コードのソートキーNo
    Const WM_WLS_KanaKey = 3            'カナ検索のソートキーNo+第一キー
    Const WM_WLS_MEIKey = 4

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL As Integer          'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    Dim WM_WLS_LEN As Integer           '開始ｺｰﾄﾞ入力文字数

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
    Dim SWlsSelList
    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$

    Dim DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub WLS_FORM_INIT()
    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_BNKMTA

    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = Len(DB_BNKMTA.BNKCD)     'LenWid はダメ
    WlsSelList = "BNKCD, BNKNM ,STNNM, DATKB"
    SWlsSelList = "*"

    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "銀行ｺｰﾄﾞ  銀行名称                                            支店名称"
               'XXXXXX7   MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5  MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5

    WM_WLS_MAX = CInt((LST.Height - 15) / 240)

End Sub

Private Function WLS_DSP_CHECK()
    If DB_BNKMTA.DATKB = "9" Then
        WLS_DSP_CHECK = SSS_NEXT
    Else
        WLS_DSP_CHECK = SSS_OK
    End If
End Function

Private Sub WLS_SetArray(ByVal ArrayCnt%)
    '====================================
    '   WINDOW 明細設定
    '====================================
    Call WLS_MEISQL
    WM_WLS_DSPArray(ArrayCnt) = DB_BNKMTA.BNKCD & "   " & LeftWid$(DB_BNKMTA.BNKNM, Len(DB_BNKMTA.BNKNM)) & "  " & LeftWid$(DB_BNKMTA.STNNM, Len(DB_BNKMTA.STNNM))
End Sub

Sub WLS_TextSQL()
    WM_WLS_KeyNo = WM_WLS_TextKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From BNKMTA Where BNKCD >= '" & WM_WLS_STTKEY & "'"
    WlsOrderBy = "Order By BNKCD"
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_MEISQL()
    WM_WLS_KeyNo = WM_WLS_MEIKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = ""
    WlsOrderBy = "Order By BNKCD"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
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

'
'以下は画面イベント処理
'
Private Sub Form_Activate()

    '=== WINDOW 位置設定 ===
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    WM_WLS_STTKEY = ""
    WM_WLS_ENDKEY = Null
    WM_WLS_Dspflg = False
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
