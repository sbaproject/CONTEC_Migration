VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_MEI 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "名称マスタ項目名"
   ClientHeight    =   4170
   ClientLeft      =   5250
   ClientTop       =   3585
   ClientWidth     =   7410
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
   ScaleHeight     =   4170
   ScaleWidth      =   7410
   Begin Threed5.SSPanel5 PNL 
      Height          =   375
      Left            =   3135
      TabIndex        =   3
      Top             =   5475
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
      Left            =   2590
      TabIndex        =   2
      Top             =   3780
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   3730
      TabIndex        =   1
      Top             =   3780
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      Left            =   15
      TabIndex        =   0
      Top             =   0
      Width           =   7395
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4890
      Picture         =   "WLS_MEI.frx":0000
      Top             =   3765
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   2160
      Picture         =   "WLS_MEI.frx":0652
      Top             =   3765
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   2700
      Picture         =   "WLS_MEI.frx":0CA4
      Top             =   4995
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   3600
      Picture         =   "WLS_MEI.frx":12F6
      Top             =   4995
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3195
      Picture         =   "WLS_MEI.frx":1948
      Top             =   4995
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   2295
      Picture         =   "WLS_MEI.frx":1F9A
      Top             =   4995
      Visible         =   0   'False
      Width           =   360
   End
End
Attribute VB_Name = "WLS_MEI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　名称マスタ検索
    '*  プログラムＩＤ　：  WLS_MEI
    '*  作成者　　　　　：　ACE)高橋
    '*  作成日　　　　　：  2006.05.12
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************

    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MEICDALEN        As Integer          'コード１文字数
    Private WM_WLS_MEINMALEN        As Integer          '名称１文字数
    
    'ウィンド内部使用変数
    Private WM_WLS_DSP_Caption      As String           '画面ｷｬﾌﾟｼｮﾝ表示データ
    Private WM_WLS_DSPArray()       As String           'ウィンド表示データ

' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)
    
    Private Dyn_Open            As Boolean          'ダイナセット状態（True:Open False:Close)
' === 20060828 === INSERT E -
    
    Private DblClickFl              As Boolean
    
    Private Usr_Ody                 As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_MEIMTA_W             As TYPE_DB_MEIMTA   '検索結果退避

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
        '=== 表示桁数設定 ===
' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        WM_WLS_MAX = 15                 '画面表示件数
' === 20060828 === INSERT E -

        WM_WLS_MEICDALEN = Len(DB_MEIMTA_W.MEICDA)     'LenWid はダメ
        WM_WLS_MEINMALEN = Len(DB_MEIMTA_W.MEINMA)     'LenWid はダメ
        '変数初期化
        WLSMEI_RTNMEICDA = ""
        WLSMEI_RTNMEINMA = ""
        '変数初期化
        Call WLS_Clear
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
        
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_MEIMTA_W.MEICDA, WM_WLS_MEICDALEN) & Space(1) & _
                                    LeftWid$(DB_MEIMTA_W.MEINMA, WM_WLS_MEINMALEN)
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_TextSQL
    '   概要：  検索sql作成
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_TextSQL()
    Dim strSQL          As String
    
    strSQL = ""
    strSQL = strSQL & " Select KEYCD "          'キー
    strSQL = strSQL & "      , MEIKMKNM "       '項目名
    strSQL = strSQL & "      , MEICDA "         'コード１
    strSQL = strSQL & "      , MEINMA "         '名称１
    strSQL = strSQL & "   from MEIMTA "
    strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "   and  KEYCD = '" & WLSMEI_KEYCD & "'"
    strSQL = strSQL & "   order by "
    strSQL = strSQL & "        KEYCD "          'キー
' === 20060726 === INSERT S - ACE)Nagasawa
    strSQL = strSQL & "      , DSPORD "         '表示順序
' === 20060726 === INSERT E -
    strSQL = strSQL & "      , MEICDA "         'コード１
    
' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)    'DBアクセス

    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    Dyn_Open = True
    LST.Clear
' === 20060828 === UPDATE E -

End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_DspNew
    '   概要：  リスト編集処理(初期情報)
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_DspNew()
    Dim Cnt             As Long
    
    Cnt = 0
    Do Until CF_Ora_EOF(Usr_Ody) = True
        
' === 20060828 === DELETE S - ACE)Nagasawa ▲▼ボタン追加
'        If Cnt > 0 Then
'            ReDim Preserve WM_WLS_DSPArray(Cnt)
'        End If
' === 20060828 === DELETE E -
        
        '取得内容退避
        DB_MEIMTA_W.KEYCD = CF_Ora_GetDyn(Usr_Ody, "KEYCD", "")             'キー
        DB_MEIMTA_W.MEIKMKNM = CF_Ora_GetDyn(Usr_Ody, "MEIKMKNM", "")       '項目名
        DB_MEIMTA_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "")           'コード１
        DB_MEIMTA_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "")           '名称１
        
        '表示メモリ展開
' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
'        '１件目は画面ｷｬﾌﾟｼｮﾝ用
'        If Cnt = 0 Then
'            WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
'        End If
'
'        Call WLS_SetArray(Cnt)

        '１件目は画面ｷｬﾌﾟｼｮﾝ用
        If Cnt = 0 And WM_WLS_Pagecnt = -1 Then
            WM_WLS_DSP_Caption = DB_MEIMTA_W.MEIKMKNM
        End If
        
        '表示改ページ
        If Cnt Mod WM_WLS_MAX = 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            Cnt = 0
            '最終ページ退避
            WM_WLS_LastPage = WM_WLS_Pagecnt
        End If
        
        Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
' === 20060828 === UPDATE E -
        
        Cnt = Cnt + 1
        
        Call CF_Ora_MoveNext(Usr_Ody)
        
' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        If Cnt >= WM_WLS_MAX Then
            Exit Do
        End If
' === 20060828 === INSERT E -
    Loop
    
' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
'    If Cnt > 0 Then
'        '画面表示
'        Call WLS_Dsp
'    Else
'        Me.Caption = ""
'        LST.Clear
'    End If
'
'    'クローズ
'    Call CF_Ora_CloseDyn(Usr_Ody)
    
    '最終データ到達
    If CF_Ora_EOF(Usr_Ody) = True Then
        WM_WLS_LastFL = True
    End If
    
    If Cnt > 0 Then
        'ページを表示
        Call WLS_Dsp
    Else
        If WM_WLS_Pagecnt = 1 Then
            Me.Caption = ""
            LST.Clear
        End If
    End If
' === 20060828 === UPDATE E -

End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Dsp
    '   概要：  画面編集処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_Dsp()
        Dim intCnt     As Integer
        
        '画面ｷｬﾌﾟｼｮﾝ編集
        Me.Caption = WM_WLS_DSP_Caption
        
' === 20060828 === UPDATE S - ACE)Nagasawa ▲▼ボタン追加
'        '表示リスト編集
'        LST.Clear
'        intCnt = 0
'        For intCnt = 0 To UBound(WM_WLS_DSPArray)
'            LST.AddItem WM_WLS_DSPArray(intCnt)
'        Next
        
        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If

        LST.Clear
        intCnt = 0
        Do While intCnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
                LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)
            End If
            intCnt = intCnt + 1
        Loop
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            LST.SetFocus
        End If
' === 20060828 === UPDATE E -

        'フォーカス設定
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            LST.SetFocus
        End If
        
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Clear
    '   概要：  変数初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()

        '検索結果保持変数
        WM_WLS_DSP_Caption = ""
        '検索結果保持配列
        ReDim WM_WLS_DSPArray(0)

' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        '画面表示ページ
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
' === 20060828 === INSERT E -

    End Sub


Private Sub Form_Activate()
    '// 各ボタン配置
' === 20060828 === DELETE S - ACE)Nagasawa ▲▼ボタン追加
'    WLSOK.Left = (WLS_MEI.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
'    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
' === 20060828 === DELETE E -
    
    '// 画面編集
    Call WLS_TextSQL
    Call WLS_DspNew
    
    If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0
    
    DblClickFl = False
End Sub

Private Sub Form_Load()
    WLS_MEI.Top = (Screen.Height - WLS_MEI.Height) / 2
    WLS_MEI.Left = (Screen.Width - WLS_MEI.Width) / 2
    Call Init_Prompt
    Call WLS_FORM_INIT
End Sub

Private Sub LST_DblClick()
    
    DblClickFl = True

    Call LST_KeyDown(13, 0)
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case 13
            WLSMEI_RTNMEICDA = LeftWid$(LST.List(LST.ListIndex), WM_WLS_MEICDALEN)
            WLSMEI_RTNMEINMA = MidWid$(LST.List(LST.ListIndex), WM_WLS_MEICDALEN + 2, WM_WLS_MEINMALEN)
            If DblClickFl = False Then Call WLSCANCEL_Click
        Case 27
            Call WLSCANCEL_Click
' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
        '←キー押下
        Case vbKeyLeft
            Call WLSMAE_Click
            
        '→キー押下
        Case vbKeyRight
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
' === 20060828 === INSERT E -
    End Select
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If DblClickFl Then Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()
' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
' === 20060828 === INSERT E -
    
    Hide
End Sub

Private Sub WLSOK_Click()
    Call LST_KeyDown(13, 0)
End Sub

' === 20060828 === INSERT S - ACE)Nagasawa ▲▼ボタン追加
Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub
    
    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspNew
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_Dsp
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
        Call WLS_Dsp
    End If
End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub
' === 20060828 === INSERT E -

