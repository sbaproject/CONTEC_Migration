VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_MEI1 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "名称"
   ClientHeight    =   4200
   ClientLeft      =   5250
   ClientTop       =   3585
   ClientWidth     =   5955
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
   ScaleHeight     =   4200
   ScaleWidth      =   5955
   Begin Threed5.SSPanel5 PNL 
      Height          =   375
      Left            =   0
      TabIndex        =   3
      Top             =   4275
      Width           =   4155
      _ExtentX        =   5106
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
      Alignment       =   1
      BevelOuter      =   1
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   1950
      TabIndex        =   2
      Top             =   3780
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   3120
      TabIndex        =   1
      Top             =   3780
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5955
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   1440
      Picture         =   "WLS_MEI1.frx":0000
      Top             =   3780
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4320
      Picture         =   "WLS_MEI1.frx":0652
      Top             =   3780
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Enabled         =   0   'False
      Height          =   330
      Index           =   0
      Left            =   2040
      Picture         =   "WLS_MEI1.frx":0CA4
      Top             =   4800
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Enabled         =   0   'False
      Height          =   330
      Index           =   0
      Left            =   2940
      Picture         =   "WLS_MEI1.frx":12F6
      Top             =   4800
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Enabled         =   0   'False
      Height          =   330
      Index           =   1
      Left            =   3345
      Picture         =   "WLS_MEI1.frx":1948
      Top             =   4800
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Enabled         =   0   'False
      Height          =   330
      Index           =   1
      Left            =   2445
      Picture         =   "WLS_MEI1.frx":1F9A
      Top             =   4800
      Visible         =   0   'False
      Width           =   360
   End
End
Attribute VB_Name = "WLS_MEI1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07
'2006/07/19 レイアウト変更大幅改変 ページ繰り機能追加　(ﾁｪｯｸ漏れあるかも)
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

Private Sub Form_Activate()
    WLSOK.Left = (WLS_MEI1.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
    If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0
    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    WLS_MEI1.Top = (Screen.Height - WLS_MEI1.Height) / 2
    WLS_MEI1.Left = (Screen.Width - WLS_MEI1.Width) / 2
    Call Init_Prompt
End Sub

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True

    Call LST_KeyDown(13, 0)
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
            'Call WLSMAE_Click
''            If LST.ListIndex <> 0 Then
''                LST.ListIndex = LST.ListIndex - 1
''            End If
            
        Case vbKeyRight    '→キー
            'Call WLSATO_Click
''            If LST.ListCount > 0 Then
''                LST.ListIndex = -1
''            End If
'            If WM_WLS_Pagecnt > 0 Then
'                WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
'                Call WLS_DspPage
'            End If
''            If LST.ListIndex < LST.ListCount - 1 Then
''                LST.ListIndex = LST.ListIndex + 1
''            End If
    End Select

End Sub
Private Sub WLSATO_Click()

Dim lngIndex As Long

'    If LST.ListCount <= 0 Then Exit Sub
'    If LST.ListCount <= WM_WLS_MAX Then Exit Sub
'    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
'        If Not WM_WLS_LastFL Then Call WLS_DspNew
'    Else
''        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
''        Call WLS_DspPage
'    End If

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
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), SSS_WLSLIST_KETA)
    'DblClickイベント障害対応  97/04/07
    'Call WLSCANCEL_CLICK
    If DblClickFl = False Then Call WLSCANCEL_CLICK
End Sub
Private Sub WLS_DspNew()
    Dim WL_Mode As Integer
Dim cnt%

    WL_Mode = 0
    cnt = 0
    Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
'        WL_Mode = WLS_DSP_CHECK()
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
            Call DB_GetNext(SSS_MFIL, BtrNormal)
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
    If cnt > 0 Then
        Call WLS_DspPage
    Else
        LST.Clear
    End If
End Sub
Private Sub WLS_SetArray(ByVal ArrayCnt%)

    '====================================
    '   WINDOW 明細設定
    '====================================
   ' WM_WLS_DSPArray(ArrayCnt) = DB_MEIMTB.KEYCD & " " & DB_MEIMTB.MEIKMKNM
    ' WM_WLS_DSPArray(ArrayCnt) = LST.List(LST.ListIndex)
     WM_WLS_DSPArray(ArrayCnt) = LST.List(ArrayCnt)
End Sub
Private Function WLS_DSP_CHECK()
'    If DB_MEIMTB.DATKB = "9" Then
'        WLS_DSP_CHECK = SSS_NEXT
'    Else
'        WLS_DSP_CHECK = SSS_OK
'    End If
End Function

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

