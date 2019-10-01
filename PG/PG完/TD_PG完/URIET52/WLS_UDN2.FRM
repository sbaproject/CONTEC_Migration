VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSUDN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "売上伝票検索"
   ClientHeight    =   7380
   ClientLeft      =   2760
   ClientTop       =   2370
   ClientWidth     =   14355
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
   ScaleHeight     =   7380
   ScaleWidth      =   14355
   Begin VB.ListBox KEYBAK 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   5070
      Left            =   15360
      TabIndex        =   19
      Top             =   1440
      Visible         =   0   'False
      Width           =   1395
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   9
      Top             =   1440
      Width           =   15030
      _ExtentX        =   26511
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
      Height          =   4590
      Left            =   45
      TabIndex        =   0
      Top             =   1800
      Width           =   15030
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   5940
      TabIndex        =   6
      Top             =   6660
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   6885
      TabIndex        =   7
      Top             =   6660
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1155
      Left            =   0
      TabIndex        =   8
      Top             =   0
      Width           =   15195
      _ExtentX        =   26802
      _ExtentY        =   2037
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
      Begin VB.TextBox WLSJDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   9540
         MaxLength       =   2
         TabIndex        =   3
         Top             =   120
         Width           =   435
      End
      Begin VB.CommandButton COM_JDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "受注取区"
         Height          =   375
         Left            =   8400
         TabIndex        =   17
         TabStop         =   0   'False
         Top             =   120
         Width           =   1170
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   6840
         MaxLength       =   6
         TabIndex        =   2
         Top             =   120
         Width           =   1260
      End
      Begin VB.TextBox WLSTANCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1520
         MaxLength       =   6
         TabIndex        =   1
         Top             =   120
         Width           =   780
      End
      Begin VB.CommandButton COM_TANCD 
         Caption         =   "営業担当者"
         Height          =   375
         Left            =   80
         TabIndex        =   13
         Top             =   120
         Width           =   1455
      End
      Begin VB.CommandButton COM_TOKCD 
         Caption         =   "得意先      "
         Height          =   375
         Left            =   5280
         TabIndex        =   12
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox WLSTOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   6840
         MaxLength       =   10
         TabIndex        =   5
         Top             =   600
         Width           =   1260
      End
      Begin VB.CommandButton COM_UDNDT 
         BackColor       =   &H00C0C0C0&
         Caption         =   "売上日    "
         Height          =   375
         Left            =   80
         TabIndex        =   10
         Top             =   600
         Width           =   1455
      End
      Begin VB.TextBox WLSUDNDT 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "yyyy/MM/dd"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1041
            SubFormatType   =   3
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1520
         MaxLength       =   10
         TabIndex        =   4
         Top             =   600
         Width           =   1255
      End
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   375
         Index           =   1
         Left            =   5280
         TabIndex        =   14
         Top             =   120
         Width           =   1575
         _ExtentX        =   2778
         _ExtentY        =   661
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
         Alignment       =   8
         BevelOuter      =   1
         Caption         =   "開始受注番号"
         OutLine         =   -1  'True
      End
      Begin VB.Label WLSJDNTRNM 
         Alignment       =   2  '中央揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   1  '実線
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   9960
         TabIndex        =   18
         Top             =   120
         Width           =   1725
      End
      Begin VB.Label WLSTOKNM 
         Alignment       =   2  '中央揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   1  '実線
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   8090
         TabIndex        =   16
         Top             =   600
         Width           =   5685
      End
      Begin VB.Label WLSTANNM 
         Alignment       =   2  '中央揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   1  '実線
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   2280
         TabIndex        =   15
         Top             =   120
         Width           =   2805
      End
      Begin VB.Label Label1 
         BackColor       =   &H00C0C0C0&
         Caption         =   "以降"
         Height          =   375
         Left            =   2880
         TabIndex        =   11
         Top             =   720
         Width           =   615
      End
   End
   Begin VB.ListBox Lst1 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   4590
      Left            =   14520
      TabIndex        =   20
      Top             =   1800
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   5985
      Picture         =   "WLS_UDN2.frx":0000
      Top             =   7920
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   6885
      Picture         =   "WLS_UDN2.frx":0652
      Top             =   7920
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   7290
      Picture         =   "WLS_UDN2.frx":0CA4
      Top             =   7920
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   6390
      Picture         =   "WLS_UDN2.frx":12F6
      Top             =   7920
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5445
      Picture         =   "WLS_UDN2.frx":1948
      Top             =   6660
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   7920
      Picture         =   "WLS_UDN2.frx":1F9A
      Top             =   6660
      Width           =   360
   End
End
Attribute VB_Name = "WLSUDN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
    '以下の４行の設定を行うこと
    Const WM_WLS_MSTKB = "1"            'マスタ区分(1:得意先 2:納品先 3:担当者 4:得意先 5:商品)
    Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey = 10           '開始コードのソートキーNo
    Const WM_WLS_CDKey = -1             'カナ検索のソートキーNo+第一キー

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL As Integer          'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    Dim WM_WLS_SFIL1 As Integer          'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    
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

'''''    Dim WlsSelList$
    Dim SWlsSelList
    Dim WlsOrderBy$
    Dim WlsFromWhere$

Private pv_blnChange_Flg As Boolean

Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub COM_TANCD_Click()
    DB_PARA(DBN_TANMTA).KeyBuf = WLSTANCD.Text
    WLSTAN.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSTAN
    DoEvents
    WM_WLS_Dspflg = False
    KEYBAK.Clear
    LST.Clear
    Lst1.Clear
    If IsNull(PP_SSSMAIN.SlistCom) Then
        WLSTANCD.Text = ""
        WLSTANNM.Caption = ""
    Else
        Call DB_GetEq(DBN_TANMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
        If DBSTAT = 0 Then
            WLSTANCD.Text = DB_TANMTA.TANCD
            WLSTANNM.Caption = DB_TANMTA.TANNM
        End If
    End If
    WM_WLS_STTKEY = "1"
    WM_WLS_ENDKEY = Null
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
'''''    WM_WLS_KeyNo = WM_WLS_TextKey
    WM_WLS_Pagecnt = -1
    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
    Call WLS_BaseSQL(WM_WLS_STTKEY)

    If WLSSSS_SET_KEYBAK() = True Then
        Call WLSSSS_DSP
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_TOKCD_Click()
    DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
    WLSTOK.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSTOK
    DoEvents
    WM_WLS_Dspflg = False
    KEYBAK.Clear
    LST.Clear
    Lst1.Clear
    If IsNull(PP_SSSMAIN.SlistCom) Then
        WLSTOKCD.Text = ""
        WLSTOKNM.Caption = ""
    Else
        Call DB_GetEq(DBN_TOKMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
        If DBSTAT = 0 Then
            WLSTOKCD.Text = DB_TOKMTA.TOKCD
            WLSTOKNM.Caption = DB_TOKMTA.TOKRN
        End If
    End If
    WM_WLS_STTKEY = "1"
    WM_WLS_ENDKEY = Null
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
'''''    WM_WLS_KeyNo = WM_WLS_TextKey
    WM_WLS_Pagecnt = -1
'    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
    Call WLS_BaseSQL(WM_WLS_STTKEY)
    If WLSSSS_SET_KEYBAK() = True Then
        Call WLSSSS_DSP
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_JDNTRKB_Click()
Dim wkJDNTRKB   As String

    WLS_MEI1.Caption = "受注取引区分一覧"
    WLS_MEI1!LST.Clear
    Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
    Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
        If DB_MEIMTA.DATKB <> "9" Then
        WLS_MEI1!LST.AddItem LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40)
        End If
        Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    Loop
    SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
    WLS_MEI1.Show 1
    Unload WLS_MEI1
    DoEvents
    WM_WLS_Dspflg = False
    KEYBAK.Clear
    LST.Clear
    Lst1.Clear
    If IsNull(PP_SSSMAIN.SlistCom) Then
        WLSJDNTRKB.Text = ""
        WLSJDNTRNM.Caption = ""
    Else
        wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2))) & Space(Len(DB_MEIMTA.MEICDB))
        Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
        If DBSTAT = 0 Then
            WLSJDNTRKB.Text = LeftWid(DB_MEIMTA.MEICDA, 2)
            WLSJDNTRNM.Caption = DB_MEIMTA.MEINMA
        End If
    End If
    WM_WLS_STTKEY = "1"
    WM_WLS_ENDKEY = Null
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
'''''    WM_WLS_KeyNo = WM_WLS_TextKey
    WM_WLS_Pagecnt = -1
    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
    Call WLS_BaseSQL(WM_WLS_STTKEY)
    If WLSSSS_SET_KEYBAK() = True Then
        Call WLSSSS_DSP
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_UDNDT_Click()
    Dim I As Integer
    
    Set_date = CNV_DATE(DB_UNYMTA.UNYDT)
    WLS_DATE.Show 1
    Unload WLS_DATE
    DoEvents
    WM_WLS_Dspflg = False
    KEYBAK.Clear
    LST.Clear
    Lst1.Clear
    WLSUDNDT.Text = Set_date
    WM_WLS_STTKEY = "1"
    WM_WLS_ENDKEY = Null
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
    Call WLS_BaseSQL(WM_WLS_STTKEY)
    If WLSSSS_SET_KEYBAK() = True Then
        Call WLSSSS_DSP
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub Form_Activate()
'DEL START FKS)INABA 2009/02/27 ***********
'レスポンス対応
'    Call WLSSSS_FORM_ACTIVATE
'DEL  END  FKS)INABA 2009/02/27 ***********
    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    Call WLS_FORM_LOAD
    Call WLSSSS_FORM_INIT
    pv_blnChange_Flg = False
End Sub

Private Sub HD_TEXT_Change()
    Dim s As Long
    s = HD_TEXT.SelStart
    HD_TEXT.Text = Left(StrConv(HD_TEXT.Text, vbUpperCase), HD_TEXT.MaxLength)
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
    Dim I, STAT%

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
            HD_TEXT.SelStart = 0
            HD_TEXT.SelLength = HD_TEXT.MaxLength
            WM_WLS_STTKEY = "11" & HD_TEXT.Text
            WM_WLS_ENDKEY = Null
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_KeyNo = WM_WLS_TextKey
            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
            Call WLS_BaseSQL(WM_WLS_STTKEY)
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            WM_WLS_Pagecnt = -1
            If WLSSSS_SET_KEYBAK() = True Then
                Call WLSSSS_DSP
            End If
'        Case 40  '↓キー
'            LST.ListIndex = 0
'            LST.SetFocus
        Case 112  'F･１キー
            SendKeys "%1"
        Case 113  'F･１キー
            SendKeys "%2"
    End Select
End Sub

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True

    Call LST_KeyDown(13, 0)
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case 13
            Call WLS_SLIST_MOVE(Lst1.List(LST.ListIndex), WM_WLS_LEN)
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
    
    Call WLS_MEISQL
    Call WLS_TRASQL
    WK_DENDT = Left$(DB_UDNTHA.UDNDT, 4) + "/" + Mid$(DB_UDNTHA.UDNDT, 5, 2) + "/" + Right$(DB_UDNTHA.UDNDT, 2)
''''LST.AddItem Left$(DB_UDNTHA.JDNNO, 6) + Mid$(DB_UDNTRA.JDNLINNO, 2, 2) + "   " + AnsiLeftB(DB_MEIMTA.MEINMA, 10) + "  " + WK_DENDT + "  " _
''''          + AnsiLeftB(DB_UDNTHA.TOKRN, 40) + "  " + AnsiLeftB(DB_UDNTHA.KENNMA, 40)
    LST.AddItem Left$(DB_UDNTHA.JDNNO, 6) + "   " + AnsiLeftB(DB_MEIMTA.MEINMA, 10) + "  " + WK_DENDT + "  " _
              + AnsiLeftB(DB_UDNTHA.TOKRN, 40) + "  " + AnsiLeftB(DB_UDNTHA.KENNMA, 40)
    Lst1.AddItem DB_UDNTHA.DATNO
End Sub

Sub WLS_TRASQL()

    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
'''    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
'''    WlsFromWhere = "From UDNTRA Where DATNO = '" & DB_UDNTHA.DATNO & "'" & " AND LINNO = '001'"
'''    WlsOrderBy = ""
'''    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
'''    Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
End Sub

Sub WLS_MEISQL()

    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    Call MEIMTA_RClear
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    WlsFromWhere = "From MEIMTA Where KEYCD = '006'" & " And MEICDA = '" & DB_UDNTHA.JDNTRKB & "'" & " And MEICDB = ' '"
    WlsOrderBy = "Order By MEICDA, MEICDB"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)
End Sub

Private Function WLS_DSP_CHECK()
Dim wkTOKCD As String
Dim wkTANCD As String
    
    '====================================
    '   WINDOW 表示可能チェック
    '       WLS_DSP_CHECK = True  :表示可
    '       WLS_DSP_CHECK = FALSE :表示不可
    '====================================
    WLS_DSP_CHECK = SSS_OK
    If DB_UDNTHA.DATKB <> "1" Then
        WLS_DSP_CHECK = SSS_END
        Exit Function
    End If
    If DB_UDNTHA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
    If DB_UDNTHA.AKAKROKB <> "1" Then WLS_DSP_CHECK = SSS_NEXT
    wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text))
'CHG START FKS)INABA 2009/02/27 ******************
'空白除去対応
    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
    If (Trim$(WLSTOKCD.Text) <> "") And (Trim$(DB_UDNTHA.TOKCD) <> Trim$(wkTOKCD)) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(WLSTANCD.Text) <> "") And (Trim$(DB_UDNTHA.TANCD) <> Trim$(wkTANCD)) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(WLSJDNTRKB.Text) <> "") And (Trim$(DB_UDNTHA.JDNTRKB) <> Trim$(WLSJDNTRKB.Text)) Then WLS_DSP_CHECK = SSS_NEXT
'    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
'    If (Trim$(WLSTOKCD.Text) <> "") And (DB_UDNTHA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
'    If (Trim$(WLSTANCD.Text) <> "") And (DB_UDNTHA.OPEID <> wkTANCD) Then WLS_DSP_CHECK = SSS_NEXT
'    If (Trim$(WLSJDNTRKB.Text) <> "") And (DB_UDNTHA.JDNTRKB <> WLSJDNTRKB.Text) Then WLS_DSP_CHECK = SSS_NEXT
'CHG START FKS)INABA 2009/02/27 ******************
    If (Trim$(WLSUDNDT.Text) <> "") And (DB_UDNTHA.UDNDT < DeCNV_DATE(WLSUDNDT)) Then WLS_DSP_CHECK = SSS_NEXT
    If (Trim$(HD_TEXT.Text) <> "") And (DB_UDNTHA.JDNNO < HD_TEXT) Then WLS_DSP_CHECK = SSS_NEXT
    Call DB_GetEq(DBN_UDNTRA, 1, DB_UDNTHA.DATNO & "001", BtrNormal)
    '売上データを抽出
    If DB_UDNTRA.DKBID <> "01" Then WLS_DSP_CHECK = SSS_NEXT
End Function

Private Function WLS_DSP_SUB_CHECK()

    WLS_DSP_SUB_CHECK = SSS_OK
End Function

Private Sub WLS_FORM_LOAD()

    '=== WINDOW 位置設定 ===
    WLSUDN.Left = (Screen.Width - WLSUDN.Width) / 2
    WLSUDN.Top = (Screen.Height - WLSUDN.Height) / 2

    '=== ｺｰﾄﾞTEXT ===
    'WLSTOKCD.Height = 330
    'WLSRN.Height = 330
'''''    WLSTOKCD.Text = ""
'''''    WLSTOKRN.Caption = ""

    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_UDNTHA
    WM_WLS_SFIL = DBN_MEIMTA
    WM_WLS_SFIL1 = DBN_UDNTRA

    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = LenWid(DB_UDNTHA.DATNO)
    
    SWlsSelList = "*"

    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "受注番号 受注取区    売上日      得意先                                   件名"
    '=== コンボＢＯＸ設定 ===
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
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                Call WLS_BaseSQL(WL_Key)
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

Private Sub WLSTANCD_Change()
    Dim s As Long
    s = WLSTANCD.SelStart
    WLSTANCD.Text = StrConv(WLSTANCD.Text, vbUpperCase)
    WLSTANCD.SelStart = s
End Sub

Private Sub WLSTANCD_GotFocus()
'''    If LenWid(WLSTANCD.Text) > 0 Then
'''        WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
'''    Else
'''        WLSTANCD.Text = Space$(LenWid(DB_TANMTA.TANCD))
'''    End If
    WLSTANCD.SelStart = 0
    WLSTANCD.SelLength = LenWid(DB_TANMTA.TANCD)

End Sub

Private Sub WLSTANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim I, STAT%

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            WLSTANCD.Text = SSS_EDTITM_WLS(WLSTANCD.Text, LenWid(DB_TANMTA.TANCD), "0")
            WLSTANCD.SelStart = 0
            WLSTANCD.SelLength = LenWid(DB_TANMTA.TANCD)
            If Trim$(WLSTANCD.Text) = "" Then
                WLSTANNM.Caption = ""
                WM_WLS_STTKEY = "1"
                WM_WLS_ENDKEY = Null
                WM_WLS_KeyCode = 0
                WM_WLS_Dspflg = True
                WM_WLS_Pagecnt = -1
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP
                End If
            Else
                Call DB_GetEq(DBN_TANMTA, 1, WLSTANCD.Text, BtrNormal)
                If DBSTAT = 0 Then
                    WLSTANNM.Caption = DB_TANMTA.TANNM
                    WM_WLS_STTKEY = "1"
                    WM_WLS_ENDKEY = Null
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP
                    End If
                End If
            End If
'        Case 40  '↓キー
'            LST.ListIndex = 0
'            LST.SetFocus
        Case 112  'F･１キー
            SendKeys "%1"
        Case 113  'F･１キー
            SendKeys "%2"
    End Select

End Sub

Private Sub WLSTOKCD_GotFocus()
'''    If LenWid(WLSTOKCD.Text) > 0 Then
'''        WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
'''    Else
'''        WLSTOKCD.Text = Space$(LenWid(DB_TOKMTA.TOKCD))
'''    End If
    WLSTOKCD.SelStart = 0
    WLSTOKCD.SelLength = LenWid(DB_TOKMTA.TOKCD)

End Sub

Private Sub WLSTOKCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim I, STAT%

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            'WLSTOKCD.Text = SSS_EDTITM_WLS(WLSTOKCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
            WLSTOKCD.SelStart = 0
            WLSTOKCD.SelLength = LenWid(DB_TOKMTA.TOKCD)
            If Trim$(WLSTOKCD.Text) = "" Then
                WLSTOKNM.Caption = ""
                WM_WLS_STTKEY = "1"
                WM_WLS_ENDKEY = Null
                WM_WLS_KeyCode = 0
                WM_WLS_Dspflg = True
                WM_WLS_Pagecnt = -1
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP
                End If
            Else
                Call DB_GetEq(DBN_TOKMTA, 1, WLSTOKCD.Text, BtrNormal)
                If DBSTAT = 0 Then
                    WLSTOKNM.Caption = DB_TOKMTA.TOKRN
                    WM_WLS_STTKEY = "1"
                    WM_WLS_ENDKEY = Null
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP
                    End If
                End If
            End If
'        Case 40  '↓キー
'            LST.ListIndex = 0
'            LST.SetFocus
        Case 112  'F･１キー
            SendKeys "%1"
        Case 113  'F･１キー
            SendKeys "%2"
    End Select

End Sub

Private Sub WLSJDNTRKB_GotFocus()
'''    If LenWid(WLSJDNTRKB.Text) > 0 Then
'''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
'''    Else
'''        WLSJDNTRKB.Text = Space$(LenWid(DB_UDNTHA.JDNTRKB))
'''    End If
    WLSJDNTRKB.SelStart = 0
    WLSJDNTRKB.SelLength = LenWid(DB_UDNTHA.JDNTRKB)

End Sub

Private Sub WLSJDNTRKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim I, STAT%
    Dim wkJDNTRKB   As String

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
            WLSJDNTRKB.SelStart = 0
            WLSJDNTRKB.SelLength = LenWid(DB_UDNTHA.JDNTRKB)
            If Trim$(WLSJDNTRKB.Text) = "" Then
                WM_WLS_STTKEY = "1"
                WM_WLS_ENDKEY = Null
                WM_WLS_KeyCode = 0
                WM_WLS_Dspflg = True
                WM_WLS_Pagecnt = -1
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                Call WLS_BaseSQL(WM_WLS_STTKEY)
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP
                End If
            Else
                wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
                If DBSTAT = 0 Then
                    WLSJDNTRNM.Caption = DB_MEIMTA.MEINMA
                    WM_WLS_STTKEY = "1"
                    WM_WLS_ENDKEY = Null
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP
                    End If
                End If
            End If
'        Case 40  '↓キー
'            LST.ListIndex = 0
'            LST.SetFocus
        Case 112  'F･１キー
            SendKeys "%1"
        Case 113  'F･１キー
            SendKeys "%2"
    End Select

End Sub

Private Sub WLSUDNDT_Change()
    WLSUDNDT.SelLength = 1
    If pv_blnChange_Flg = True Then
        Exit Sub
    Else
        Call CtrlDatChange(WLSUDNDT)
    End If
End Sub

Private Sub WLSUDNDT_Click()
    WLSUDNDT.SelStart = 0
    WLSUDNDT.SelLength = 1
End Sub

Private Sub WLSUDNDT_GotFocus()
    If Len(Trim(WLSUDNDT.Text)) = 0 Then
        pv_blnChange_Flg = True
        WLSUDNDT.Text = Space(10)
        pv_blnChange_Flg = False
        WLSUDNDT.SelStart = 0
        WLSUDNDT.SelLength = 1
    ElseIf Len(Trim(WLSUDNDT.Text)) >= 8 Then
        WLSUDNDT.SelStart = 8
        WLSUDNDT.SelLength = 1
    Else
        WLSUDNDT.SelStart = 0
        WLSUDNDT.SelLength = 1
    End If
End Sub

Private Sub WLSUDNDT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim strDat As String

    Select Case True
        'ｴﾝﾀｰｷｰ押
        Case KEYCODE = vbKeyReturn And Shift = 0
            Dim I As Integer
            Dim W_Key As String
        
            If Trim$(WLSUDNDT) <> "" Then
                If CHECK_DATE(WLSUDNDT) = False Then
                    Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
                    WLSUDNDT.SetFocus
                    Exit Sub
                End If
            End If
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            Lst1.Clear
            WM_WLS_STTKEY = "1"
            WM_WLS_ENDKEY = Null
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
            Call WLS_BaseSQL(WM_WLS_STTKEY)
            If WLSSSS_SET_KEYBAK() = True Then
                Call WLSSSS_DSP
            End If
            
        '→押
        Case KEYCODE = vbKeyRight And Shift = 0
            KEYCODE = 0
            '→制御
            If WLSUDNDT.SelStart < Len(WLSUDNDT.Text) Then
                WLSUDNDT.SelStart = WLSUDNDT.SelStart + 1
                WLSUDNDT.SelLength = 1
                Call NextForcus(WLSUDNDT)
            End If

        '↓押
        Case KEYCODE = vbKeyDown And Shift = 0
            '↓制御
            KEYCODE = 0

        '↓押
        Case KEYCODE = vbKeyUp And Shift = 0
            '↓制御
            KEYCODE = 0

        '←押
        Case KEYCODE = vbKeyLeft And Shift = 0
            KEYCODE = 0
            '←制御
            If WLSUDNDT.SelStart > 0 Then
                WLSUDNDT.SelStart = WLSUDNDT.SelStart - 1
                WLSUDNDT.SelLength = 1
                Call PrevForcus(WLSUDNDT)
            End If
            
        Case KEYCODE = vbKeyDelete And Shift = 0
            KEYCODE = 0
        
''        'TAB押
''        Case KEYCODE = vbKeyF16
''            Call F_SendKey(KEYCODE, "HD_KESIDT")
''        Case KEYCODE = vbKeyS And Shift = 2
''            pv_blnChange_Flg = True
''            WLSUDNDT.Text = Space(10)
''            WLSUDNDT.SelStart = 0
''            WLSUDNDT.SelLength = 1
''            pv_blnChange_Flg = False

    End Select
End Sub

Private Sub WLSUDNDT_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyBack Then
        KeyAscii = 0
        pv_blnChange_Flg = True
        If WLSUDNDT.SelStart > 0 Then
            WLSUDNDT.SelStart = WLSUDNDT.SelStart - 1
        End If
        WLSUDNDT.SelLength = 1
        Call PrevForcus(WLSUDNDT)
        pv_blnChange_Flg = False
    Else
        ' ADD 2007/02/20 数値以外は入力不可
        Select Case True
            Case (KeyAscii >= Asc("0") And KeyAscii <= Asc("9"))
            
            Case Else
                KeyAscii = 0
        End Select
        ' ADD 2007/02/20 数値以外は入力不可
    End If
End Sub

Private Sub WLSUDNDT_LOSTFocus()
'''    Dim I As Integer
'''    Dim W_Key As String
'''    Dim strDat As String
'''
'''    If Trim$(WLSUDNDT) <> "" Then
'''        If ConvDat(Trim(WLSUDNDT.Text), strDat) = False Then
'''            WLSUDNDT.SetFocus
'''            Exit Sub
'''        End If
'''        If CHECK_DATE(WLSUDNDT) = False Then
'''            Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
'''            WLSUDNDT.SetFocus
'''            Exit Sub
'''        End If
'''    End If
'''    WM_WLS_STTKEY = "1"
'''    WM_WLS_ENDKEY = Null
'''    WM_WLS_KeyCode = 0
'''    WM_WLS_Dspflg = True
'''    WM_WLS_Pagecnt = -1
'''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
'''    If WLSSSS_SET_KEYBAK() = True Then
'''        Call WLSSSS_DSP
'''    End If
'''
End Sub
'''''
'''''Private Sub WLSHINNMA_LOSTFocus()
'''''    Dim I As Integer
'''''    Dim W_Key As String
'''''
'''''    WM_WLS_STTKEY = "1"
'''''    WM_WLS_ENDKEY = Null
'''''    WM_WLS_KeyCode = 0
'''''    WM_WLS_Dspflg = True
'''''    WM_WLS_Pagecnt = -1
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
'''''    If WLSSSS_SET_KEYBAK() = True Then
'''''        Call WLSSSS_DSP
'''''    End If
'''''
'''''End Sub

Private Sub WLSMAE_Click()
    Dim WL_Key As String

    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    Else
        Exit Sub
    End If
     WL_Key = KEYBAK.List(WM_WLS_Pagecnt)
     'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    Call WLS_BaseSQL(WL_Key)
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
    Lst1.Clear
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
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    ''98/09/25 削除
    ''WM_WLS_KeyNo = WM_WLS_TextKey
    W_Key = DB_PARA(WM_WLS_MFIL).KeyBuf
    Call WLS_BaseSQL(W_Key)
    'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
    If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
        '2001/07/25 追加一行
        WM_WLS_INIT = 1
        Call WLSSSS_DSP
    End If
End Sub

Private Sub WLSSSS_FORM_INIT()
    Dim I As Integer

    WM_WLS_KeyCode = False
    WM_WLS_MAX = LST.Height \ 240
    'HD_TEXT.Height = 330
''''HD_TEXT.MaxLength = WM_WLS_LEN
''''HD_TEXT.Width = (WM_WLS_LEN + 1) * 120
    HD_TEXT.MaxLength = 6
    HD_TEXT.Width = (6 + 1) * 120
    WM_WLS_STTKEY = "1"
    WM_WLS_ENDKEY = Null
    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
        HD_TEXT.Text = ""
    End If
    ''98/09/25 追加
    WM_WLS_KeyNo = WM_WLS_TextKey

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

    Do While DBSTAT = 0
        WL_Mode = WLSSSS_DSP_CHECK()
        If WL_Mode = SSS_OK Then
            WL_Mode = WLS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
                KEYBAK.AddItem DB_UDNTHA.DATKB & DB_UDNTHA.DENKB & DB_UDNTHA.JDNNO & DB_UDNTHA.DATNO
            End If
        End If
        If WL_Mode = SSS_NEXT Then
            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        ElseIf WL_Mode = SSS_RPSN Then
            WL_Key = WLSSSS_RPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
                Call WLS_BaseSQL(WL_Key)
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
        ElseIf WL_Mode = SSS_NPSN Then
            WL_Key = WLSSSS_NPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
                Call WLS_BaseSQL(WL_Key)
                'Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
        Else
            Exit Do
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then
        WLSSSS_SET_KEYBAK = False
    End If
End Function

Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

Function AnsiLenB(ByVal StrArg As String) As Long
'概要：文字数ｶｳﾝﾄ
'引数：StrArg,Input,String,対象文字列
'説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
    AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
  #Else
    AnsiLenB = LenB(StrArg)
#End If
End Function

' StrConv を呼び出します。
Function AnsiStrConv(StrArg, flag)
#If Win32 Then
    AnsiStrConv = StrConv(StrArg, flag)
#Else
    AnsiStrConv = StrArg
#End If

End Function

Public Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Long) As String

Dim lngMoji     As Long
Dim lngKeta     As Long

    lngMoji = 0
    lngKeta = 0
    GP_Get_NM = ""
    
    If AnsiLenB(strNM) <= lngMR Then
        GP_Get_NM = strNM
        Exit Function
    End If
    
    If AnsiLenB(strNM) > lngMR Then
    
        Do Until lngKeta >= lngMR
            lngMoji = lngMoji + 1
            lngKeta = lngKeta + LenB(StrConv(Mid(strNM, lngMoji, 1), vbFromUnicode))
        Loop
    
        If lngKeta > lngMR Then
            GP_Get_NM = Left(strNM, lngMoji - 1)
        Else
            GP_Get_NM = Left(strNM, lngMoji)
        End If
    End If
    
End Function

Private Function ConvDat(ByVal strTarget As String, ByRef strDat As String) As Boolean

    Dim blnRtnVal   As Boolean
    Dim strYYYY     As String
    Dim strMM       As String
    Dim strDD       As String
    
    blnRtnVal = False
    strDat = ""
    strYYYY = ""
    strMM = ""
    strDD = ""
    
    If IsDate(strTarget) = True Then
        strDat = strTarget
        blnRtnVal = True
    Else
        If Len(strTarget) = 8 Then
            strYYYY = Left(strTarget, 4)
            strMM = Mid(strTarget, 5, 2)
            strDD = Right(strTarget, 2)
            If IsDate(strYYYY & "/" & strMM & "/" & strDD) = True Then
                strDat = strYYYY & "/" & strMM & "/" & strDD
                blnRtnVal = True
            End If
        End If
    End If
    
    ConvDat = blnRtnVal

End Function

Private Function CtrlDatChange(ByRef Ctl As TextBox) As String

    Dim lngSelstart As Long
    Dim Wk_DspMoji As String
    Dim Wk_EditMoji As String
        Wk_EditMoji = CnvDspItem_Date(Ctl.Text)
    
    '編集後の文字を表示形式に変換
    Wk_DspMoji = CnvDspItem_Date(Wk_EditMoji)

    pv_blnChange_Flg = True
    lngSelstart = Ctl.SelStart
    Ctl.Text = Left(Wk_DspMoji & Space(10), 10)
    Ctl.SelStart = lngSelstart
    Ctl.SelLength = 1
    'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ可
    pv_blnChange_Flg = False

    '現在ﾌｫｰｶｽ位置から右へ移動
    Call NextForcus(Ctl)

End Function

Private Function CnvDspItem_Date(ByVal strValue As String) As String

    Dim Rtn_Str_Value As String
    
    Rtn_Str_Value = strValue

    '日付の場合
    If Trim(Rtn_Str_Value) = "" Then
    '未入力の場合
        Rtn_Str_Value = String(10, Space(1))
    Else
    '入力ありの場合
        If Len(Trim(Rtn_Str_Value)) <> Len("YYYYMMDD") Then
        '入力形式が異なる場合
            '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
            Rtn_Str_Value = LTrim(Rtn_Str_Value) & String(10, Space(1))
            '右からバイト数分だけ取得
            Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
        Else
            '表示形式有
            Rtn_Str_Value = CF_Ctr_AnsiLeftB(Format(Rtn_Str_Value, "0000/00/00") & String(10, Space(1)), 10)
        End If
    End If
        
    CnvDspItem_Date = Rtn_Str_Value

End Function

Private Function NextForcus(ByRef Ctl As TextBox)

    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Next_SelStart       As Integer
    Dim Wk_Point            As Integer
    Dim Wk_SelLength        As Integer

'    '移動フラグ初期化
'    pm_Move_Flg = False

    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
    
        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = Ctl.SelStart
        Act_SelLength = Ctl.SelLength
        Act_SelStr = Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = 10 Then
        '全選択の場合（選択文字が最大バイト数と一致）
            '詰文字が左詰の場合
            '最終文字を選択する
            Ctl.SelStart = Len(Ctl.Text) - 1
            Ctl.SelLength = 1
        Else
            If Act_SelStart = Len(Ctl.Text) Then
            '選択開始位置が一番右の場合
''                Select Case Ctl.NAME
''                    Case WLSHDNDT.NAME
''                        If IsDate(Ctl.Text) = True Then
''                            WLSHDNDT.ForeColor = COLOR_BLACK
''                            WLSSIRCD.SetFocus
''                        End If
''                End Select
                Ctl.SelStart = Len(Ctl.Text) - 1
                Ctl.SelLength = 1
            Else
            '選択開始位置が一番右でない場合

                '１つ右の１桁を取得
                Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)

                If Str_Wk = "" Then
                '一番右へ移動し選択なし状態に
                    Ctl.SelStart = Len(Ctl.Text)
                    Ctl.SelLength = 0
                Else
                    '右に１桁ずつずらし入力可能な文字を検索
                    Next_SelStart = -1
                    For Wk_Point = Act_SelStart + 1 To Len(Ctl.Text) Step 1

                        Str_Wk = Mid(Ctl.Text, Wk_Point, 1)

                        '日付/年月/時刻項目の場合
                            '入力可能文字＆と空白も移動可能
                            If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
                                Next_SelStart = Wk_Point - 1
                                Exit For
                            End If
                    Next

                    If Next_SelStart = -1 Then
                    '選択可能な文字がない場合
''                        Select Case Ctl.NAME
''                            Case WLSHDNDT.NAME
''                                If IsDate(Ctl.Text) = True Then
''                                    WLSHDNDT.ForeColor = COLOR_BLACK
''                                    WLSSIRCD.SetFocus
''                                End If
''                        End Select
                    Else
                    '選択可能な文字がある場合

                        If Act_SelLength = 0 Then
                        '移動前の選択文字数がない場合
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        Ctl.SelStart = Next_SelStart
                        Ctl.SelLength = Wk_SelLength
                    End If
                End If
            End If

        End If
    
End Function

Private Function PrevForcus(ByRef Ctl As TextBox)

    Dim Index_Wk            As Integer
    Dim Act_SelStart        As Integer
    Dim Act_SelLength       As Integer
    Dim Act_SelStr          As String
    Dim Act_SelStrB         As Long
    Dim Str_Wk              As String
    Dim Next_SelStart       As Integer
    Dim Wk_Point            As Integer
    Dim Wk_SelLength        As Integer

'    '移動フラグ初期化
'    pm_Move_Flg = False

    '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
    
        '現在のﾃｷｽﾄ上の選択状態を取得
        Act_SelStart = Ctl.SelStart
        Act_SelLength = Ctl.SelLength
        Act_SelStr = Ctl.SelText
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

        If Act_SelStart = 0 And Act_SelStrB = 10 Then
        '全選択の場合（選択文字が最大バイト数と一致）
            '詰文字が左詰の場合
            '最終文字を選択する
            Ctl.SelStart = Len(Ctl.Text) - 1
            Ctl.SelLength = 1
        Else
            If Act_SelStart = Len(Ctl.Text) Then
            '選択開始位置が一番右の場合
''                Select Case Ctl.NAME
''                    Case WLSHDNDT.NAME
''                        If IsDate(Ctl.Text) = True Then
''                            WLSHDNDT.ForeColor = COLOR_BLACK
''                            WLSHDNTRKB.SetFocus
''                        End If
''                End Select
            Else
            '選択開始位置が一番右でない場合

                '１つ右の１桁を取得
                Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)

                If Str_Wk = "" Then
                '一番右へ移動し選択なし状態に
                    Ctl.SelStart = Len(Ctl.Text)
                    Ctl.SelLength = 0
                Else
                    '右に１桁ずつずらし入力可能な文字を検索
                    Next_SelStart = -1
'                    For Wk_Point = Act_SelStart + 1 To 0 Step -1       ' DEL 2007/02/20
                    For Wk_Point = Act_SelStart + 1 To 1 Step -1        ' ADD 2007/02/20

                        Str_Wk = Mid(Ctl.Text, Wk_Point, 1)

                        '日付/年月/時刻項目の場合
                            '入力可能文字＆と空白も移動可能
                            If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
                                Next_SelStart = Wk_Point - 1
                                Exit For
                            End If
                    Next

                    If Next_SelStart = -1 Then
                    '選択可能な文字がない場合
        ''                Select Case Ctl.NAME
        ''                    Case WLSHDNDT.NAME
        ''                        If IsDate(Ctl.Text) = True Then
        ''                            WLSHDNDT.ForeColor = COLOR_BLACK
        ''                            WLSHDNTRKB.SetFocus
        ''                        End If
        ''                End Select
                    Else
                    '選択可能な文字がある場合

                        If Act_SelLength = 0 Then
                        '移動前の選択文字数がない場合
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If

                        Ctl.SelStart = Next_SelStart
                        Ctl.SelLength = Wk_SelLength
                    End If
                End If
            End If

        End If
    
End Function


Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Long

    CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))

    Exit Function

End Function

Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, _
                           ByVal pm_Len As Long) As String

    CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    Exit Function

End Function


Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
Dim strSQL As String
Dim wkTOKCD As String
Dim wkTANCD As String
Dim strSQLWhere As String
Dim strSQLWhereB As String

    strSQL = ""
    strSQLWhere = ""
    strSQLWhereB = ""
    
    wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTHA.TOKCD) - Len(WLSTOKCD.Text))
'CHG START FKS)INABA 2009/02/27 ***************************************************
'検索条件変更対応
    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.TANCD) - Len(WLSTANCD.Text))
'    wkTANCD = WLSTANCD.Text & Space(Len(DB_UDNTHA.OPEID) - Len(WLSTANCD.Text))
'CHG  END  FKS)INABA 2009/02/27 ***************************************************
'CHG START FKS)INABA 2009/11/25 ***************************************************
'連絡票№661
'    If (Trim$(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & wkTOKCD & "' "
'    If (Trim$(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & wkTANCD & "' "
'    If (Trim$(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & WLSJDNTRKB.Text & "' "
'    If (Trim$(WLSUDNDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.UDNDT >= '" & DeCNV_DATE(WLSUDNDT) & "' "
'    If (Trim$(HD_TEXT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNNO >= '" & HD_TEXT & "' "
    If (Trim$(WLSTOKCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TOKCD = '" & AE_EditSQLText(wkTOKCD) & "' "
    If (Trim$(WLSTANCD.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.TANCD = '" & AE_EditSQLText(wkTANCD) & "' "
    If (Trim$(WLSJDNTRKB.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "' "
    If (Trim$(WLSUDNDT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.UDNDT >= '" & DeCNV_DATE(WLSUDNDT) & "' "
    If (Trim$(HD_TEXT.Text) <> "") Then strSQLWhere = strSQLWhere & "   AND A.JDNNO >= '" & AE_EditSQLText(HD_TEXT) & "' "
'CHG  END  FKS)INABA 2009/11/25 ***************************************************
    strSQL = "SELECT * FROM (    "
'CHG START FKS)INABA 2009/02/27 ***************************************************
'レスポンス対応
    strSQL = strSQL & "SELECT /*+ ORDERED */ A.* FROM ( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B, UDNTHA A "
'    strSQL = strSQL & "SELECT A.* FROM UDNTHA A ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B"
'CHG  END  FKS)INABA 2009/02/27 ***************************************************
    strSQL = strSQL & " WHERE A.DATKB = '1' "
    strSQL = strSQL & "   AND A.DENKB = '1' "
    strSQL = strSQL & "   AND A.AKAKROKB = '1' "
    strSQL = strSQL & "   AND A.WRTFSTDT || A.WRTFSTTM = B.DT "
    strSQL = strSQL & "   AND A.UDNNO = B.UDNNO "
    strSQL = strSQL & strSQLWhere
'CHG START FKS)INABA 2009/11/25 ***************************************************
'連絡票№661
'    strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO || A.DATNO >= '" & strKeyBak & "' "
    strSQL = strSQL & "   AND A.DATKB || A.DENKB || A.JDNNO || A.DATNO >= '" & AE_EditSQLText(strKeyBak) & "' "
'CHG  END  FKS)INABA 2009/11/25 ***************************************************
    strSQL = strSQL & "   Order By A.JDNNO ) C"
    
    Call DB_GetSQL2(WM_WLS_MFIL, strSQL)
End Sub


