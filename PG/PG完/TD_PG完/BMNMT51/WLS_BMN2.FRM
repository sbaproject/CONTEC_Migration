VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_BMN1 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "部門検索ウィンドウ"
   ClientHeight    =   5100
   ClientLeft      =   1665
   ClientTop       =   3300
   ClientWidth     =   9060
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
   ScaleHeight     =   5100
   ScaleWidth      =   9060
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   4530
      TabIndex        =   3
      Top             =   4530
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   3405
      TabIndex        =   2
      Top             =   4530
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3636
      Left            =   120
      TabIndex        =   1
      Top             =   480
      Width           =   8775
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   8775
      _ExtentX        =   15478
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
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5790
      Picture         =   "WLS_BMN2.frx":0000
      Top             =   4530
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   2910
      Picture         =   "WLS_BMN2.frx":0652
      Top             =   4530
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3825
      Picture         =   "WLS_BMN2.frx":0CA4
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4725
      Picture         =   "WLS_BMN2.frx":12F6
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5130
      Picture         =   "WLS_BMN2.frx":1948
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4230
      Picture         =   "WLS_BMN2.frx":1F9A
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
End
Attribute VB_Name = "WLS_BMN1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_BmnKey = 1

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
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

    Dim WlsSelList$                     'テーブル項目
    Dim SWlsSelList$                    'テーブル全項目
    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$


Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub Form_Activate()
    WLSMAE.Left = (WLS_BMN1.Width - (WLSMAE.Width + WLSOK.Width + WLSCANCEL.Width + WLSATO.Width + 60)) / 2
    WLSOK.Left = WLSMAE.Left + WLSMAE.Width + 60
    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
    WLSATO.Left = WLSCANCEL.Left + WLSCANCEL.Width + 60
    '=== WINDOW 位置設定 ===
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    WM_WLS_STTKEY = ""
    WM_WLS_ENDKEY = Null

    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    WM_WLS_LastPage = -1
    WM_WLS_LastFL = False
    ReDim WM_WLS_DSPArray(0)

   ' Call WLS_BMNSQL
  '  Call WLS_DspNew
    'If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0

    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
    
    
End Sub

Private Sub Form_Load()
    WLS_BMN1.Top = (Screen.Height - WLS_BMN1.Height) / 2
    WLS_BMN1.Left = (Screen.Width - WLS_BMN1.Width) / 2
    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_BMNMTA

    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = Len(DB_BMNMTA.BMNCD)     'LenWid はダメ
    WlsSelList = "BMNCD,BMNNM,STTTKDT,ENDTKDT"
    SWlsSelList = "*"
    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "部門ｺｰﾄﾞ 部門名                                   適用開始日 適用終了日"
               'XXXXX6　 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 YYYY/MM/DD　YYYY/MM/DD

    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    
    Call Init_Prompt
End Sub
Private Function WLS_DSP_CHECK()
    If DB_BMNMTA.DATKB = "9" Then
        WLS_DSP_CHECK = SSS_NEXT
    Else
        WLS_DSP_CHECK = SSS_OK
    End If
End Function
Private Sub WLS_SetArray(ByVal ArrayCnt%)
    '====================================
    '   WINDOW 明細設定
    '====================================
'    WM_WLS_DSPArray(ArrayCnt) = DB_BMNMTA.BMNCD & "  " & LeftWid(DB_BMNMTA.BMNNM, 40) & "  " & CNV_DATE(DB_BMNMTA.STTTKDT) & "  " & CNV_DATE(DB_BMNMTA.ENDTKDT)
    WM_WLS_DSPArray(ArrayCnt) = DB_BMNMTA.BMNCD & "   " & DB_BMNMTA.BMNNM & " " & CNV_DATE(DB_BMNMTA.STTTKDT) & "  " & CNV_DATE(DB_BMNMTA.ENDTKDT)

End Sub
Private Sub WLS_DspNew()
'    Dim WL_Mode As Integer
'Dim cnt%
'
'    WL_Mode = 0
'    cnt = 0
'    Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
'        WL_Mode = WLS_DSP_CHECK()
'        If WL_Mode = SSS_OK Then
'            If cnt = 0 Then
'                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
'                WM_WLS_LastPage = WM_WLS_Pagecnt
'                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
'            End If
'            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
'            cnt = cnt + 1
'        End If
'        If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
'            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
'        End If
'    Loop
'    If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
'    If cnt > 0 Then
'        Call WLS_DspPage
'    Else
'        LST.Clear
'    End If
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

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True

    'Call LST_KeyDown(13, 0)
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
'    Select Case KEYCODE
'        Case 13
'            Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), SSS_WLSLIST_KETA)
'            'DblClickイベント障害対応  97/04/07
'            'Call WLSCANCEL_CLICK
'            If DblClickFl = False Then Call WLSCANCEL_CLICK
'        Case 27
'            Call WLSCANCEL_CLICK
'    End Select
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

''    If LST.ListCount <= 0 Then Exit Sub
''
''    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
''        If Not WM_WLS_LastFL Then Call WLS_DspNew
''    Else
''        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
''        Call WLS_DspPage
''    End If

    Dim lngIndex As Long
    lngIndex = LST.TopIndex
    lngIndex = lngIndex + WM_WLS_MAX
    
    If lngIndex <= LST.ListCount - 1 Then
        If lngIndex + WM_WLS_MAX > LST.ListCount Then
            LST.TopIndex = LST.ListCount - WM_WLS_MAX
            LST.ListIndex = LST.ListCount - WM_WLS_MAX
        Else
            LST.TopIndex = lngIndex
            LST.ListIndex = lngIndex
        End If
    End If

End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub

Private Sub WLSMAE_Click()
'''    If WM_WLS_Pagecnt > 0 Then
'''        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
'''        Call WLS_DspPage
'''    End If
Dim lngIndex As Long

    lngIndex = LST.TopIndex
    lngIndex = lngIndex - WM_WLS_MAX
    
    If lngIndex > 0 Then
        LST.TopIndex = lngIndex
        LST.ListIndex = lngIndex
    Else
        LST.TopIndex = 0
        LST.ListIndex = 0
    End If


End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadイベント障害対応  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub WLSCANCEL_CLICK()
    'UnLoadイベント障害対応  97/04/07
    'Unload Me
    Hide
End Sub

Private Sub WLSOK_Click()
    'Call LST_KeyDown(13, 0)
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
    Call WLSCANCEL_CLICK
    
End Sub


