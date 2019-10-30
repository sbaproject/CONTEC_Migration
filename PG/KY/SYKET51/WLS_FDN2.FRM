VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSFDN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "出荷指示対象検索"
   ClientHeight    =   6405
   ClientLeft      =   2310
   ClientTop       =   1695
   ClientWidth     =   14325
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
   ScaleHeight     =   6405
   ScaleWidth      =   14325
   Begin VB.ListBox LST1 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      Left            =   14385
      TabIndex        =   21
      Top             =   1800
      Width           =   1410
   End
   Begin VB.ListBox KEYBAK 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   5070
      Left            =   14400
      TabIndex        =   9
      Top             =   1440
      Visible         =   0   'False
      Width           =   2715
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   90
      TabIndex        =   8
      Top             =   1440
      Width           =   14115
      _ExtentX        =   24897
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
      Left            =   90
      TabIndex        =   0
      Top             =   1800
      Width           =   14115
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   6120
      TabIndex        =   5
      Top             =   5790
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   7245
      TabIndex        =   6
      Top             =   5790
      Width           =   1095
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1230
      Left            =   0
      TabIndex        =   7
      Top             =   -15
      Width           =   14385
      _ExtentX        =   25374
      _ExtentY        =   2170
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
      Begin VB.Frame Frame1 
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   0  'なし
         Caption         =   "Frame1"
         Enabled         =   0   'False
         Height          =   525
         Left            =   120
         TabIndex        =   16
         Top             =   75
         Width           =   5910
         Begin VB.TextBox HD_WRKNM 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H00C0C0C0&
            Height          =   375
            Left            =   1230
            Locked          =   -1  'True
            TabIndex        =   18
            Text            =   "XXXXXXXXX1"
            Top             =   0
            Width           =   1395
         End
         Begin VB.TextBox HD_FDNDT 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H00C0C0C0&
            Height          =   375
            Left            =   4350
            Locked          =   -1  'True
            TabIndex        =   17
            Text            =   "9999/99/99"
            Top             =   15
            Width           =   1395
         End
         Begin Threed5.SSPanel5 Panel3D4 
            Height          =   375
            Left            =   0
            TabIndex        =   19
            Top             =   0
            Width           =   1275
            _ExtentX        =   1535
            _ExtentY        =   503
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
            Caption         =   "処理区分"
            OutLine         =   -1  'True
            RoundedCorners  =   0   'False
         End
         Begin Threed5.SSPanel5 SSPanel51 
            Height          =   375
            Left            =   3120
            TabIndex        =   20
            Top             =   15
            Width           =   1275
            _ExtentX        =   1535
            _ExtentY        =   503
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
            Caption         =   "対象日"
            OutLine         =   -1  'True
            RoundedCorners  =   0   'False
         End
      End
      Begin VB.TextBox HD_WRKKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00C0C0C0&
         Enabled         =   0   'False
         Height          =   375
         Left            =   10800
         TabIndex        =   15
         Text            =   "X"
         Top             =   240
         Visible         =   0   'False
         Width           =   1395
      End
      Begin VB.CommandButton COM_SOUCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "倉庫"
         Height          =   375
         Left            =   8475
         TabIndex        =   14
         TabStop         =   0   'False
         Top             =   120
         Width           =   1050
      End
      Begin VB.TextBox WLSSOUCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   9510
         TabIndex        =   1
         Text            =   "XXXX5"
         Top             =   120
         Width           =   915
      End
      Begin VB.TextBox WLSHINNMA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   4440
         TabIndex        =   3
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
         Top             =   600
         Width           =   3735
      End
      Begin VB.TextBox WLSHINCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   1350
         MaxLength       =   10
         TabIndex        =   2
         Text            =   "XXXXXXXX10"
         Top             =   600
         Width           =   1395
      End
      Begin VB.TextBox WLSTOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   9510
         TabIndex        =   4
         Text            =   "XXXX5"
         Top             =   600
         Width           =   915
      End
      Begin VB.CommandButton COM_TOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "得意先"
         Height          =   375
         Left            =   8475
         TabIndex        =   10
         TabStop         =   0   'False
         Top             =   600
         Width           =   1050
      End
      Begin VB.CommandButton COM_HINCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "製品ｺｰﾄﾞ"
         Height          =   375
         Left            =   120
         TabIndex        =   11
         TabStop         =   0   'False
         Top             =   600
         Width           =   1275
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Left            =   3240
         TabIndex        =   13
         Top             =   600
         Width           =   1275
         _ExtentX        =   1535
         _ExtentY        =   503
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
         Caption         =   "型式"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin VB.Label Label1 
         BackColor       =   &H00C0C0C0&
         Caption         =   "迄"
         Height          =   255
         Left            =   6075
         TabIndex        =   12
         Top             =   165
         Width           =   255
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   6840
      Picture         =   "WLS_FDN2.frx":0000
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   7740
      Picture         =   "WLS_FDN2.frx":0652
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   7335
      Picture         =   "WLS_FDN2.frx":0CA4
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   6435
      Picture         =   "WLS_FDN2.frx":12F6
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5625
      Picture         =   "WLS_FDN2.frx":1948
      Top             =   5790
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   8460
      Picture         =   "WLS_FDN2.frx":1F9A
      Top             =   5790
      Width           =   360
   End
End
Attribute VB_Name = "WLSFDN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '以下の４行の設定を行うこと
    Const WM_WLS_MSTKB = "1"            'マスタ区分(1:得意先 2:納品先 3:担当者 4:仕入先 5:商品)
    Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey = 2            '開始コードのソートキーNo
    Const WM_WLS_CDKey = -1              'カナ検索のソートキーNo+第一キー

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL As Integer          'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    
    Dim WM_WLS_LEN As Integer           '開始ｺｰﾄﾞ入力文字数

    'ウィンド内部使用変数
    Dim WM_WLS_MAX As Integer           '１画面の表示件数
    Dim WM_WLS_STTKEY                   '開始キー
    Dim WM_WLS_ENDKEY                   '終了キー
    Dim WM_WLS_KeyCode As Integer       'ｺﾝﾎﾞﾎﾞｯｸｽ表示用
    Dim WM_WLS_KeyNo As Integer         'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
    Dim WM_WLS_Pagecnt As Integer       'ウィンド表示ページカウンタ
    Dim WM_WLS_Dspflg As Integer        'ウィンド表示ﾌﾗｸﾞ(True or False)
    Dim WM_WLS_INIT As Integer          'ウィンド初期表示ﾌﾗｸﾞ(True or False)

    Dim WlsSelList$
    Dim SWlsSelList
'''''    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$


Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub COM_HINCD_Click()
    Dim I As Integer
    Dim W_Key As String
    
    DB_PARA(DBN_HINMTA).KeyBuf = WLSHINCD.Text
    WLSHIN.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSHIN
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        DB_HINMTA.HINCD = ""
    Else
'''' UPD 2009/02/20  FKS) S.Nakajima    Start
'        Call DB_GetEq(DBN_HINMTA, 1, Left$(PP_SSSMAIN.SlistCom, 8), BtrNormal)
        Call DB_GetEq(DBN_HINMTA, 1, Left$(PP_SSSMAIN.SlistCom, 10), BtrNormal)
'''' UPD 2009/02/20  FKS) S.Nakajima    End
        If DBSTAT = 0 Then
            WLSHINCD.Text = DB_HINMTA.HINCD
            WM_WLS_KeyCode = -1
            WM_WLS_Dspflg = False
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            W_Key = SSS_CLTID & SSS_PrgId & "1"
            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
            If WLSSSS_SET_KEYBAK() = True Then
                WM_WLS_INIT = 1
                Call WLSSSS_DSP
            End If
        End If
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_SOUCD_Click()
    Dim I As Integer
    Dim W_Key As String
    
    DB_PARA(DBN_SOUMTA).KeyBuf = WLSSOUCD.Text
    WLSSOU.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSSOU
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        DB_SOUMTA.SOUCD = ""
    Else
        Call DB_GetEq(DBN_SOUMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
        If DBSTAT = 0 Then
            WLSSOUCD.Text = Trim(DB_SOUMTA.SOUCD)
            WM_WLS_KeyCode = -1
            'Call DB_GetEq(TOKMTA, 1, PP_SSSMAIN.SLISTCOM, BtrNormal)
            'Call WLS_DSP
        
            WM_WLS_Dspflg = False
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            W_Key = SSS_CLTID & SSS_PrgId & "1"
            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
            If WLSSSS_SET_KEYBAK() = True Then
                WM_WLS_INIT = 1
                Call WLSSSS_DSP
            End If
        End If
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_TOKCD_Click()
    Dim I As Integer
    Dim W_Key As String
    
    DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
    WLSTOK.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSTOK
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        DB_TOKMTA.TOKCD = ""
    Else
        Call DB_GetEq(DBN_TOKMTA, 1, Left$(PP_SSSMAIN.SlistCom, 5), BtrNormal)
        If DBSTAT = 0 Then
            WLSTOKCD.Text = Trim(DB_TOKMTA.TOKCD)
            WM_WLS_KeyCode = -1
            WM_WLS_Dspflg = False
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            W_Key = SSS_CLTID & SSS_PrgId & "1"
            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
            If WLSSSS_SET_KEYBAK() = True Then
                WM_WLS_INIT = 1
                Call WLSSSS_DSP
            End If
        End If
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub Form_Activate()
    Call WLSSSS_FORM_ACTIVATE
    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    Call WLS_FORM_LOAD
    Call WLSSSS_FORM_INIT
End Sub
'
'''''Private Sub HD_TEXT_GotFocus()
'''''    If LenWid(HD_TEXT.Text) > 0 Then
'''''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
'''''    Else
'''''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
'''''    End If
'''''    HD_TEXT.SelStart = 0
'''''    HD_TEXT.SelLength = HD_TEXT.MaxLength
'''''End Sub
'
'''''Private Sub HD_TEXT_KeyDown(KeyCode As Integer, Shift As Integer)
'''''    Dim I, STAT%
'''''
'''''    Select Case KeyCode
'''''        Case 13
'''''            WM_WLS_Dspflg = False
'''''            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
'''''            HD_TEXT.SelStart = 0
'''''            HD_TEXT.SelLength = HD_TEXT.MaxLength
'''''            WM_WLS_STTKEY = "11" & HD_TEXT.Text
'''''            WM_WLS_ENDKEY = Null
'''''            WM_WLS_KeyCode = 0
'''''            WM_WLS_Dspflg = True
'''''            WM_WLS_KeyNo = WM_WLS_TextKey
'''''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
'''''            KEYBAK.Clear
'''''            LST.Clear
'''''            WM_WLS_Pagecnt = -1
'''''            If WLSSSS_SET_KEYBAK() = True Then
'''''                Call WLSSSS_DSP
'''''            End If
''''''        Case 40  '↓キー
''''''            LST.ListIndex = 0
''''''            LST.SetFocus
'''''        Case 112  'F･１キー
'''''            SendKeys "%1"
'''''        Case 113  'F･１キー
'''''            SendKeys "%2"
'''''    End Select
'''''End Sub

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True

    Call LST_KeyDown(13, 0)
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case 13
            Call WLS_SLIST_MOVE(LST1.List(LST.ListIndex), WM_WLS_LEN)
            'DblClickイベント障害対応  97/04/07
            'Call WLSCANCEL_CLICK
            If DblClickFl = False Then Call WLSCANCEL_CLICK
        Case 27
            Call WLSCANCEL_CLICK
        Case 37  '←キー
            Call WLSMAE_Click
'       Case 38  '↑キー
'           If LST.ListIndex = 0 Then
'               LST.ListIndex = -1
'               HD_TEXT.SetFocus
'           End If
        Case 39  '→キー
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
        Case 112  'F･１キー
            SendKeys "%1"
        Case 113  'F･１キー
            SendKeys "%2"
    End Select
End Sub

Private Sub WLS_DISPLAY()
    '====================================
    '   WINDOW 明細表示
    '====================================
    Dim WK_TK As String * 13, WK_DENDT As String * 10, WK_NOKDT As String * 10
    WK_DENDT = Left$(DB_SYKTRA.ODNYTDT, 4) + "/" + Mid$(DB_SYKTRA.ODNYTDT, 5, 2) + "/" + Right$(DB_SYKTRA.ODNYTDT, 2)
        
    WlsFromWhere = "From SOUMTA Where SOUCD = '" & DB_SYKTRA.OUTSOUCD & "'"
    WlsOrderBy = "Order By SOUCD"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)
    
''    LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + Left$(DB_SYKTRA.HINNMA, 30) + " " + Left$(DB_SYKTRA.TOKNMA, 40) + " " + Left$(DB_SOUMTA.SOUNM, 20)
'''    LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + Left(StrConv(DB_SYKTRA.HINNMA, vbWide), 15) + " " + Left(StrConv(DB_SYKTRA.TOKNMA, vbWide), 20) + " " + Left(StrConv(DB_SOUMTA.SOUNM, vbWide), 10)
''''LST.AddItem DB_SYKTRA.JDNNO + "       " + WK_DENDT + " " + LeftWid$(DB_SYKTRA.HINNMA, 30) + " " + LeftWid$(DB_SYKTRA.TOKNMA, 40) + " " + LeftWid$(DB_SOUMTA.SOUNM, 20)
    LST.AddItem Left(DB_SYKTRA.SBNNO, 10) + "  " + WK_DENDT + " " + LeftWid$(DB_SYKTRA.HINNMA, 30) + " " + LeftWid$(DB_SYKTRA.TOKNMA, 40) + " " + LeftWid$(DB_SOUMTA.SOUNM, 20)
    LST1.AddItem DB_SYKTRA.JDNNO & DB_SYKTRA.OUTSOUCD & DB_SYKTRA.TOKCD
 End Sub

Private Function WLS_DSP_CHECK()
Dim wkTOKCD As String
Dim wkHINCD As String
    '====================================
    '   WINDOW 表示可能チェック
    '       WLS_DSP_CHECK = True  :表示可
    '       WLS_DSP_CHECK = FALSE :表示不可
    '====================================
    WLS_DSP_CHECK = SSS_OK
    If DB_SYKTRA.DATKB <> "1" Then
        WLS_DSP_CHECK = SSS_END
        Exit Function
    End If
'''''    If SSSVal(DB_FDNTHA.FDNENDKB) = 8 Or SSSVal(DB_FDNTHA.FDNENDKB) = 7 Then
'''''        WLS_DSP_CHECK = SSS_NEXT
'''''    Else
'''''        WLS_DSP_CHECK = SSS_OK
'''''        DBSTAT = 0
'    ElseIf SSSVal(DB_FDNTHA.FDNENDKB) = 9 Then
'        WLS_DSP_CHECK = WLS_DSP_SUB_CHECK
'''''    End If
    If WM_WLS_KeyNo = WM_WLS_TextKey Then
        If DB_SYKTRA.CLTID <> SSS_CLTID Then WLS_DSP_CHECK = SSS_END
        If DB_SYKTRA.PGID <> SSS_PrgId Then WLS_DSP_CHECK = SSS_END
        If DB_SYKTRA.DATKB <> "1" Then WLS_DSP_CHECK = SSS_END
        Select Case HD_WRKKB
            Case "2"
                If DB_SYKTRA.WRKKB <> "4" Then WLS_DSP_CHECK = SSS_NEXT
            Case "3"
                If DB_SYKTRA.WRKKB <> "6" Then WLS_DSP_CHECK = SSS_NEXT
            Case "4"
                If DB_SYKTRA.WRKKB <> "7" Then WLS_DSP_CHECK = SSS_NEXT
            Case "5"
                If DB_SYKTRA.WRKKB <> "8" Then WLS_DSP_CHECK = SSS_NEXT
            Case "6"
                If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Then
                Else
                    WLS_DSP_CHECK = SSS_NEXT
                End If
            Case Else
''''''''''''''''If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
                If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "5" Then
                Else
                    WLS_DSP_CHECK = SSS_NEXT
                End If
        End Select
        If DB_SYKTRA.ODNYTDT > DeCNV_DATE(HD_FDNDT) Then WLS_DSP_CHECK = SSS_NEXT
    End If
    wkTOKCD = WLSTOKCD.Text & Space(Len(DB_SYKTRA.TOKCD) - Len(WLSTOKCD.Text))
    wkHINCD = WLSHINCD.Text & Space(Len(DB_SYKTRA.HINCD) - Len(WLSHINCD.Text))
    If (Trim$(WLSSOUCD.Text) <> "") And (DB_SYKTRA.OUTSOUCD <> WLSSOUCD.Text) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(WLSTOKCD.Text) <> "") And (DB_SYKTRA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(WLSHINCD.Text) <> "") And (DB_SYKTRA.HINCD <> wkHINCD) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(WLSHINNMA.Text) <> "") And (InStr(1, DB_SYKTRA.HINNMA, WLSHINNMA.Text) = 0) Then WLS_DSP_CHECK = SSS_NEXT
End Function

Private Function WLS_DSP_SUB_CHECK()
    Dim WL_OTPSU As Currency
    WLS_DSP_SUB_CHECK = SSS_OK
    Call DB_GetGrEq(DBN_SYKTRA, 1, "1" & DB_SYKTRA.JDNNO, BtrNormal)
    Do While (DBSTAT = 0) And (DB_SYKTRA.DATKB = "1") And (SSSVal(DB_SYKTRA.JDNLINNO) < 990)
        WL_OTPSU = 0
        Do While (DBSTAT = 0) And (DB_SYKTRA.DATKB = "1")
            Call DB_GetNext(DBN_SYKTRA, BtrNormal)
        Loop
        WL_OTPSU = DB_SYKTRA.FRDSU - DB_SYKTRA.HIKSU
        If WL_OTPSU > 0 Then
            WLS_DSP_SUB_CHECK = SSS_OK
            DBSTAT = 0
            Exit Function
        Else
            WLS_DSP_SUB_CHECK = SSS_NEXT
        End If
        Call DB_GetNext(DBN_SYKTRA, BtrNormal)
    Loop
    DBSTAT = 0
End Function

Private Sub WLS_FORM_LOAD()

    '=== WINDOW 位置設定 ===
    WLSFDN.Left = (Screen.Width - WLSFDN.Width) / 2
    WLSFDN.Top = (Screen.Height - WLSFDN.Height) / 2

    '=== ｺｰﾄﾞTEXT ===
    'WLSTOKCD.Height = 285
    'WLSRN.Height = 285
    'WLSTOKCD.Text = ""

    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_SYKTRA
    WM_WLS_SFIL = DBN_SOUMTA

    SWlsSelList = "*"


    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = LenWid(DB_SYKTRA.JDNNO) + LenWid(DB_SYKTRA.OUTSOUCD) + LenWid(DB_SYKTRA.TOKCD)

    '=== ＬＡＢＥＬ設定 ===
''''WLSLABEL = "受注番号or製番   出荷指示日 型 式                          得意先　　　　　　　　　　　           　倉庫名"
    WLSLABEL = "製番        出荷指示日 型 式                          得意先　　　　　　　　　　　           　倉庫名"

    '=== コンボＢＯＸ設定 ===
'''''    WLSCOMBO.AddItem "伝票No.順"
'''''    WLSCOMBO.AddItem "得意先順"
'''''    WLSCOMBO.ListIndex = 0
    WM_WLS_INIT = 0
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadイベント障害対応  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub WLSATO_Click()
    Dim WL_Key As String

    If LST.ListCount > 0 Then
        If (LeftWid$(KEYBAK.List(WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
            Exit Sub
        Else
            If (WM_WLS_Pagecnt + 1) > (KEYBAK.ListCount - 1) Then
                'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                If WLSSSS_SET_KEYBAK() = False Then Exit Sub
            Else
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                WL_Key = KEYBAK.List(WM_WLS_Pagecnt)
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
            Call WLSSSS_DSP
        End If
    End If
End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub

Private Sub WLSCANCEL_CLICK()
    'UnLoadイベント障害対応  97/04/07
    'Unload Me
    Hide
End Sub

Private Sub WLSHINCD_Change()
    Dim s As Long
    s = WLSHINCD.SelStart
    WLSHINCD.Text = StrConv(WLSHINCD.Text, vbUpperCase)
    WLSHINCD.SelStart = s
End Sub

Private Sub WLSHINCD_GotFocus()
    WLSHINCD.SelStart = 0
    WLSHINCD.SelLength = LenWid(WLSHINCD.Text)
End Sub

Private Sub WLSHINCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = SSS_CLTID & SSS_PrgId & "1"
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        Else
            LST.Clear
            LST1.Clear
        End If
    End If
End Sub

Private Sub WLSHINCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1"
''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    Else
''        LST.Clear
''    End If

End Sub

Private Sub WLSHINNMA_Change()
    Dim s As Long
    s = WLSHINNMA.SelStart
    WLSHINNMA.Text = StrConv(WLSHINNMA.Text, vbUpperCase)
    WLSHINNMA.SelStart = s
End Sub

Private Sub WLSHINNMA_GotFocus()
    WLSHINNMA.SelStart = 0
    WLSHINNMA.SelLength = LenWid(WLSHINNMA.Text)
End Sub

Private Sub WLSSOUCD_Change()
    Dim s As Long
    s = WLSSOUCD.SelStart
    WLSSOUCD.Text = StrConv(WLSSOUCD.Text, vbUpperCase)
    WLSSOUCD.SelStart = s
End Sub

Private Sub WLSSOUCD_GotFocus()
    WLSSOUCD.SelStart = 0
    WLSSOUCD.SelLength = LenWid(WLSSOUCD.Text)
End Sub

Private Sub WLSSOUCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = SSS_CLTID & SSS_PrgId & "1"
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        Else
            LST.Clear
            LST1.Clear
        End If
    End If
End Sub

Private Sub WLSSOUCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1"
''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    Else
''        LST.Clear
''    End If
''
End Sub

Private Sub WLSHINNMA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = SSS_CLTID & SSS_PrgId & "1"
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        Else
            LST.Clear
            LST1.Clear
        End If
    End If
End Sub

Private Sub WLSHINNMA_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1"
''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    Else
''        LST.Clear
''    End If

End Sub

Private Sub WLSTOKCD_GotFocus()
    WLSTOKCD.SelStart = 0
    WLSTOKCD.SelLength = LenWid(WLSTOKCD.Text)
End Sub

Private Sub WLSTOKCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = SSS_CLTID & SSS_PrgId & "1"
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        Else
            LST.Clear
            LST1.Clear
        End If
    End If
End Sub

Private Sub WLSTOKCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1"
''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    Else
''        LST.Clear
''    End If

End Sub

Private Sub WLSMAE_Click()
    Dim WL_Key As String

    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    Else
        Exit Sub
    End If
    WL_Key = KEYBAK.List(WM_WLS_Pagecnt)
    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    Call WLSSSS_DSP
End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub WLSOK_Click()
    Call LST_KeyDown(13, 0)
End Sub

Private Sub WLSSSS_DSP()
    Dim WL_Mode As Integer
    Dim WL_Key As String

    If WM_WLS_Dspflg = False Then Exit Sub

    LST.Clear
    LST1.Clear
    If DBSTAT = 0 Then
        Do While (DBSTAT = 0) And (LST.ListCount < WM_WLS_MAX) And (WL_Mode <> SSS_END)
            WL_Mode = WLSSSS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                WL_Mode = WLS_DSP_CHECK()
                If WL_Mode = SSS_OK Then
                    Call WLS_DISPLAY
                End If
            End If
            If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            ElseIf WL_Mode = SSS_RPSN Then
                WL_Key = WLSSSS_RPSN()
                If LenWid(WL_Key) = 0 Then
                    Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                Else
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                End If
            ElseIf WL_Mode = SSS_NPSN Then
                WL_Key = WLSSSS_NPSN()
                If LenWid(WL_Key) = 0 Then
                    Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                Else
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                End If
            End If
        Loop
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
        End If
    End If
    If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
        If (LeftWid$(KEYBAK.List(WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
            KEYBAK.AddItem HighValue(1)
        End If
    End If
End Sub

Private Function WLSSSS_DSP_CHECK()
    Dim CHKDAT

    WLSSSS_DSP_CHECK = SSS_OK

    If Not IsNull(WM_WLS_ENDKEY) Then
        If LeftWid$(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
            WLSSSS_DSP_CHECK = SSS_END
            Exit Function
        End If
    End If

End Function

Private Sub WLSSSS_FORM_ACTIVATE()
    Dim I As Integer
    Dim W_Key As String

    WM_WLS_Dspflg = False
    WM_WLS_KeyCode = 2
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    ''98/09/25 削除
    ''WM_WLS_KeyNo = WM_WLS_TextKey
    W_Key = SSS_CLTID & SSS_PrgId & "1"
    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
    If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
        WM_WLS_INIT = 1
        Call WLSSSS_DSP
    End If
End Sub

Private Sub WLSSSS_FORM_INIT()
    Dim I As Integer

    WM_WLS_KeyCode = False
    WM_WLS_MAX = LST.Height \ 225
    
    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    'HD_TEXT.Height = 285
'''''    HD_TEXT.MaxLength = WM_WLS_LEN
'''''    HD_TEXT.Width = (WM_WLS_LEN + 1) * 100
    WM_WLS_STTKEY = SSS_CLTID & SSS_PrgId & "1"
    WM_WLS_ENDKEY = SSS_CLTID & SSS_PrgId & "9"
'''''    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
'''''    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
'''''        HD_TEXT.Text = ""
'''''    End If
    ''98/09/25 追加
    WM_WLS_KeyNo = WM_WLS_TextKey
    Select Case MidWid$(DB_PARA(WM_WLS_MFIL).KeyBuf, 14, 1)
        Case "2"
                HD_WRKNM = "通販"
        Case "3"
                HD_WRKNM = "初期不良"
        Case "4"
                HD_WRKNM = "製番"
        Case "5"
                HD_WRKNM = "支給品"
        Case "6"
                HD_WRKNM = "移動"
        Case Else
                HD_WRKNM = "通常"
    End Select
    HD_WRKKB = MidWid$(DB_PARA(WM_WLS_MFIL).KeyBuf, 14, 1)
    HD_FDNDT = MidWid$(DB_PARA(WM_WLS_MFIL).KeyBuf, 15, 10)
    WLSSOUCD.Text = ""
    WLSTOKCD.Text = ""
    WLSHINCD.Text = ""
    WLSHINNMA.Text = ""

End Sub

Private Function WLSSSS_NPSN()
    Dim WL_Key As String
    WL_Key = ""
    WLSSSS_NPSN = WL_Key
End Function

Private Function WLSSSS_RPSN()
    Dim WL_Key As String
    WL_Key = ""
    WLSSSS_RPSN = WL_Key
End Function

Private Function WLSSSS_SET_KEYBAK()
    Dim WL_Mode As Integer
    Dim WL_Key As String

    WLSSSS_SET_KEYBAK = True

    LST.Clear
    LST1.Clear
    Do While DBSTAT = 0
        WL_Mode = WLSSSS_DSP_CHECK()
        If WL_Mode = SSS_OK Then
            WL_Mode = WLS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
            End If
        End If
        If WL_Mode = SSS_NEXT Then
            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        ElseIf WL_Mode = SSS_RPSN Then
            WL_Key = WLSSSS_RPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
        ElseIf WL_Mode = SSS_NPSN Then
            WL_Key = WLSSSS_NPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
        Else
            Exit Do
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then
        WLSSSS_SET_KEYBAK = False
    End If
End Function

