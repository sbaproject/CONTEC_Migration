VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSHIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "製品一覧ウィンドウ"
   ClientHeight    =   6120
   ClientLeft      =   375
   ClientTop       =   3105
   ClientWidth     =   11505
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
   ScaleHeight     =   6120
   ScaleWidth      =   11505
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   9
      Top             =   1200
      Width           =   11295
      _ExtentX        =   19923
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
      Top             =   1560
      Width           =   11295
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   4230
      TabIndex        =   5
      Top             =   5505
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   5175
      TabIndex        =   6
      Top             =   5505
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1125
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   11535
      _ExtentX        =   20346
      _ExtentY        =   1984
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
      Begin VB.CommandButton COM_HINKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "商品区分"
         Height          =   375
         Left            =   120
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   120
         Width           =   1290
      End
      Begin VB.TextBox WLSHINKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   1380
         MaxLength       =   2
         TabIndex        =   1
         Top             =   120
         Width           =   435
      End
      Begin VB.ComboBox WLSKANA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   360
         Left            =   10125
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   3
         Top             =   120
         Width           =   1230
      End
      Begin VB.TextBox HD_Kana 
         Height          =   375
         IMEMode         =   6  '半角ｶﾀｶﾅ
         Left            =   9360
         TabIndex        =   11
         Text            =   "ｱｲｳｴｵ"
         Top             =   120
         Visible         =   0   'False
         Width           =   735
      End
      Begin VB.TextBox HD_NMA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   4845
         MaxLength       =   30
         TabIndex        =   2
         Text            =   "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
         Top             =   120
         Width           =   3795
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1695
         MaxLength       =   10
         TabIndex        =   4
         Text            =   "XXXXXXXX"
         Top             =   600
         Width           =   1155
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   120
         TabIndex        =   8
         Top             =   600
         Width           =   1620
         _ExtentX        =   2858
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
         Caption         =   "開始製品ｺｰﾄﾞ"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel51 
         Height          =   375
         Left            =   4080
         TabIndex        =   10
         Top             =   120
         Width           =   780
         _ExtentX        =   1376
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
         Caption         =   "型式"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 PNL_USENM 
         Height          =   375
         Index           =   3
         Left            =   8880
         TabIndex        =   12
         Top             =   120
         Width           =   1230
         _ExtentX        =   2170
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
      Begin VB.Label WLSHINKBNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   1  '実線
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   1800
         TabIndex        =   14
         Top             =   120
         Width           =   2055
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4455
      Picture         =   "WLS_HIN4.frx":0000
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   5355
      Picture         =   "WLS_HIN4.frx":0652
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5760
      Picture         =   "WLS_HIN4.frx":0CA4
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4860
      Picture         =   "WLS_HIN4.frx":12F6
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   3735
      Picture         =   "WLS_HIN4.frx":1948
      Top             =   5505
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   6210
      Picture         =   "WLS_HIN4.frx":1F9A
      Top             =   5505
      Width           =   360
   End
End
Attribute VB_Name = "WLSHIN"
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

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_NMALEN As Integer        '型式入力文字数
    Dim WM_WLS_LEN As Integer           '開始ｺｰﾄﾞ入力文字数
    Dim WM_WLS_KANALEN As Integer       'カナ入力文字数

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
    Dim WM_WLS_INIT As Integer          'ウィンド初期表示ﾌﾗｸﾞ(True or False)

    Dim WlsSelList$
    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$

    Dim DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub WLS_FORM_INIT()
    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_HINMTA

    '=== 表示開始コード桁数設定 ===
    WM_WLS_NMALEN = Len(DB_HINMTA.HINNMA) 'LenWid はダメ
'    WM_WLS_LEN = Len(DB_HINMTA.HINCD)     'LenWid はダメ
    WM_WLS_LEN = 8
    WM_WLS_KANALEN = Len(DB_HINMTA.HINNK) 'LenWid はダメ
    WlsSelList = "HINCD, HINNMA, HINNMB, DATKB, KHNKB,DSPKB"

    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "製品ｺｰﾄﾞ 型　　式                       品　　名                                          "
               'XXXXXXX8 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5

    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    'HD_TEXT.Height = 330
'    HD_NMA.MaxLength = WM_WLS_NMALEN
'    HD_NMA.Width = (WM_WLS_NMALEN + 1) * 120
    HD_TEXT.MaxLength = WM_WLS_LEN
    HD_TEXT.Width = (WM_WLS_LEN + 1) * 120
    WM_WLS_INIT = True
End Sub

Private Function WLS_DSP_CHECK()
Dim wkHINCD As String
    wkHINCD = DB_HINMTA.HINCD
    If DB_HINMTA.DATKB = "9" Then
        WLS_DSP_CHECK = SSS_NEXT
    Else
        If DB_HINMTA.KHNKB = "9" Then
            WLS_DSP_CHECK = SSS_NEXT
        Else
            If DB_HINMTA.DSPKB = "1" Then
                WLS_DSP_CHECK = SSS_OK
            Else
                WLS_DSP_CHECK = SSS_NEXT
            End If
        End If
    End If
End Function

Private Sub WLS_SetArray(ByVal ArrayCnt%)
    '====================================
    '   WINDOW 明細設定
    '====================================
    WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA.HINCD, 8) & " " & LeftWid$(DB_HINMTA.HINNMA, 30) & " " & LeftWid$(DB_HINMTA.HINNMB, 50)
End Sub

Sub WLS_KbSQL()
    WM_WLS_KeyNo = WM_WLS_TextKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'    WlsFromWhere = "From HINMTA Where HINKB = '" & WM_WLS_STTKEY & "'"
    WlsFromWhere = "From HINMTA Where HINKB = '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    
    WlsOrderBy = "Order By HINCD"
' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
'    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy

    If Trim(WM_WLS_STTKEY) <> "" Then
        DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " _
                   & WlsSelList & " " _
                   & WlsFromWhere _
                   & " AND DSPKB = '1' " _
                   & " UNION ALL " _
                   & "Select /*+ INDEX(HINMTA X_HINMTA06) */ " _
                   & WlsSelList & " " _
                   & WlsFromWhere _
                   & " AND DSPKB = '9' " _
                   & WlsOrderBy
    Else
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    End If
' === 20081205 === UPDATE E
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_NmaSQL()
    WM_WLS_KeyNo = WM_WLS_NmaKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    
' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
'D    WlsFromWhere = "From HINMTA Where HINNMA Like " & "'%" & WM_WLS_STTKEY & "%'"
'D    If Trim(WLSHINKB.Text) <> "" Then
'D        'DWlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
'D    End If
'D
'D    WlsOrderBy = "Order By HINCD"
'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    
    Dim strSQL As String
    
    strSQL = " SELECT "
    
    'ヒント句の設定
    Select Case True
        '条件がない場合
        Case Trim(WM_WLS_STTKEY) = "" And Trim(WLSHINKB.Text) = ""
            strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA01) */ "
            
        '上記以外
        Case Else
            strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA06) */ "

    End Select
    
    '取得項目編集
    strSQL = strSQL & WlsSelList
    
    '検索条件
    strSQL = strSQL & " FROM HINMTA WHERE HINNMA Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"   '型式
    If Trim(WLSHINKB.Text) <> "" Then                                                       '商品区分
        strSQL = strSQL & " AND HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
    End If
    
    'SQLの編集（ユニオンさせる）
    DB_SQLBUFF = strSQL
    DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '1' "
    DB_SQLBUFF = DB_SQLBUFF & " UNION ALL "
    DB_SQLBUFF = DB_SQLBUFF & strSQL
    DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '9' "
    DB_SQLBUFF = DB_SQLBUFF & " ORDER BY HINCD "
' === 20081205 === UPDATE E

    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_TextSQL()
    WM_WLS_KeyNo = WM_WLS_TextKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'    WlsFromWhere = "From HINMTA Where HINCD >= '" & WM_WLS_STTKEY & "'"
    WlsFromWhere = "From HINMTA Where HINCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    If Trim(WLSHINKB.Text) <> "" Then
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
        WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
    WlsOrderBy = "Order By HINCD"
' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy

    '商品区分が入力されている場合
    If Trim(WLSHINKB.Text) <> "" Then
        DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " _
                    & WlsSelList & " " & WlsFromWhere _
                    & " and DSPKB = '1' " _
                    & " UNION ALL " _
                    & " SELECT /*+ INDEX(HINMTA X_HINMTA06) */ " _
                    & WlsSelList & " " & WlsFromWhere _
                    & " and DSPKB = '9' " _
                    & WlsOrderBy
    Else
        DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA01) */ " _
                    & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    End If
' === 20081205 === UPDATE E
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_KanaSQL()
    WM_WLS_KeyNo = WM_WLS_KanaKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'    WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & WM_WLS_ENDKEY & "'"
    WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & AE_EditSQLText(WM_WLS_ENDKEY) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    'WlsOrderBy = "Order By HINNK, HINCD"
    If Trim(WLSHINKB.Text) <> "" Then
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
        WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
    WlsOrderBy = "Order By  HINCD"
' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    If Trim(WM_WLS_STTKEY) <> "" Then
        DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA02) */ " _
                    & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Else
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    End If
' === 20081205 === UPDATE E
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
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
        WLSKANA.AddItem "ア        ｱｵ"
        WLSKANA.AddItem "カ        ｶｺ"
        WLSKANA.AddItem "サ        ｻｿ"
        WLSKANA.AddItem "タ        ﾀﾄ"
        WLSKANA.AddItem "ナ        ﾅﾉ"
        WLSKANA.AddItem "ハ        ﾊﾎ"
        WLSKANA.AddItem "マ        ﾏﾓ"
        WLSKANA.AddItem "ヤ        ﾔﾖ"
        WLSKANA.AddItem "ラ        ﾗﾛ"
        WLSKANA.AddItem "ワ        ﾜﾝ"
    End If
End Sub

Private Sub COM_HINKB_Click()
Dim wkHINKB   As String
Dim strSQL      As String
Dim W_BUF

    WLS_MEI1.Caption = "商品区分一覧"
    WLS_MEI1!LST.Clear
    Call DB_GetGrEq(DBN_MEIMTA, 3, "077", BtrNormal)
    Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "077"
        If DB_MEIMTA.DATKB <> "9" Then
        WLS_MEI1!LST.AddItem LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40)
        End If
        Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    Loop
    SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
    PP_SSSMAIN.SlistCom = Null
    WLS_MEI1.Show 1
    Unload WLS_MEI1
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        WM_WLS_Dspflg = False
        DoEvents
        WM_WLS_Dspflg = True
        Exit Sub
    Else
        wkHINKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid$(PP_SSSMAIN.SlistCom, 2)))
        Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
        If DBSTAT = 0 Then
            WLSHINKB.Text = Left$(DB_MEIMTA.MEICDA, 2)
            WLSHINKBNM.Caption = LeftB$(DB_MEIMTA.MEINMA, 16)
                
            Select Case True
            
                Case Trim(HD_NMA.Text) <> ""
                    WM_WLS_Dspflg = False
                    HD_TEXT.Text = ""
                    WLSKANA.ListIndex = 0
                    WM_WLS_STTKEY = HD_NMA.Text
                    WM_WLS_ENDKEY = HD_NMA.Text
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    WM_WLS_LastPage = -1
                    WM_WLS_LastFL = False
                    ReDim WM_WLS_DSPArray(0)
            
                    Call WLS_NmaSQL
                    Call WLS_DspNew
                Case Trim(HD_TEXT.Text) <> ""
                    WM_WLS_Dspflg = False
                    HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
                    WM_WLS_STTKEY = HD_TEXT.Text
                    WM_WLS_ENDKEY = Null
                    WLSKANA.ListIndex = 0
                    HD_NMA.Text = ""
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    WM_WLS_LastPage = -1
                    WM_WLS_LastFL = False
                    ReDim WM_WLS_DSPArray(0)
            
                    Call WLS_TextSQL
                    Call WLS_DspNew
                Case WLSKANA.ListIndex > 0
                    HD_TEXT.Text = ""
                    HD_NMA.Text = ""
                    W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
                    WM_WLS_STTKEY = Left$(W_BUF, 1)
                    WM_WLS_ENDKEY = Chr$(Asc(Right$(W_BUF, 1)) + 1)
                    ReDim WM_WLS_DSPArray(0)
                    Call WLS_KanaSQL
                    Call WLS_DspNew
               
                Case Else
                    WM_WLS_Dspflg = False
                    HD_TEXT.Text = ""
                    WLSKANA.ListIndex = 0
                    HD_NMA.Text = ""
                    WM_WLS_STTKEY = WLSHINKB.Text
                    WM_WLS_ENDKEY = Null
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
                    WM_WLS_LastPage = -1
                    WM_WLS_LastFL = False
                    ReDim WM_WLS_DSPArray(0)
            
                    Call WLS_KbSQL
                    Call WLS_DspNew
            End Select
            PP_SSSMAIN.SlistCom = Null
        Else
            Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
            Call P_SetFocus(WLSHINKB)
            WLSHINKB.SelStart = 0
            WLSHINKB.SelLength = Len(WLSHINKB.Text)
        End If
    End If

End Sub

'
'以下は画面イベント処理
'
Private Sub Form_Activate()

    '=== WINDOW 位置設定 ===
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    If WM_WLS_INIT = True Then
        WM_WLS_STTKEY = ""
        WM_WLS_ENDKEY = Null
        HD_NMA.Text = ""
        HD_TEXT.Text = ""
        WM_WLS_Dspflg = False
        WLSKANA.ListIndex = 0
        HD_Kana.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)
    
'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
'画面表示時に検索しない
'        Call WLS_TextSQL
'        Call WLS_DspNew
'デフォルトで製品を設定
        WLSHINKB.Text = "1"
        Call DB_GetEq(DBN_MEIMTA, 2, "077" & WLSHINKB.Text, BtrNormal)
        If DBSTAT = 0 Then
            WLSHINKBNM.Caption = LeftB$(DB_MEIMTA.MEINMA, 16)
        End If
        Call P_SetFocus(HD_NMA)
'''' UPD 2011/02/07  FKS) T.Yamamoto    End
        WM_WLS_INIT = False
    End If

    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
    Call WLS_Kana_Init
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

Private Sub HD_NMA_Change()
    Dim S As Long
    S = HD_NMA.SelStart
    HD_NMA.Text = StrConv(HD_NMA.Text, vbUpperCase)
    HD_NMA.SelStart = S
End Sub

Private Sub HD_NMA_GotFocus()
''    If LenWid(HD_NMA.Text) > 0 Then
''        HD_NMA.Text = SSS_EDTITM_WLS(HD_NMA.Text, HD_NMA.MaxLength, WM_WLSKEY_ZOKUSEI)
''    Else
''        HD_NMA.Text = Space$(HD_NMA.MaxLength)
''    End If
    HD_NMA.SelStart = 0
    HD_NMA.SelLength = HD_NMA.MaxLength
End Sub

Private Sub HD_NMA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = ""
        WLSKANA.ListIndex = 0
        WM_WLS_STTKEY = HD_NMA.Text
        WM_WLS_ENDKEY = HD_NMA.Text
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_NmaSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_TEXT_Change()
    Dim S As Long
    S = HD_TEXT.SelStart
    HD_TEXT.Text = StrConv(HD_TEXT.Text, vbUpperCase)
    HD_TEXT.SelStart = S
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
        HD_NMA.Text = ""
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

Private Sub WLSHINKB_GotFocus()
    WLSHINKB.SelStart = 0
    WLSHINKB.SelLength = LenWid(DB_HINMTA.HINKB)
End Sub

Private Sub WLSHINKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim i, STAT%
    Dim wkHINKB   As String
    Dim strSQL      As String
    Dim W_BUF
    
    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            WLSHINKB.Text = SSS_EDTITM_WLS(WLSHINKB.Text, LenWid(DB_HINMTA.HINKB), "0")
            WLSHINKB.SelStart = 0
            WLSHINKB.SelLength = LenWid(DB_HINMTA.HINKB)
            If Trim$(WLSHINKB.Text) = "" Then
                WM_WLS_Dspflg = False
                WLSHINKB.Text = ""
                WLSHINKBNM.Caption = ""
                WM_WLS_STTKEY = Format$(HD_TEXT.Text)
                WLSKANA.ListIndex = 0
                HD_NMA.Text = ""
                WM_WLS_Dspflg = True
                WM_WLS_Pagecnt = -1
                WM_WLS_LastPage = -1
                WM_WLS_LastFL = False
                ReDim WM_WLS_DSPArray(0)
        
                Call WLS_TextSQL
                Call WLS_DspNew
            Else
                wkHINKB = WLSHINKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSHINKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
                If DBSTAT = 0 Then
                    WLSHINKB.Text = Left$(DB_MEIMTA.MEICDA, 2)
                    WLSHINKBNM.Caption = LeftB$(DB_MEIMTA.MEINMA, 16)
                    Select Case True
                    
                        Case Trim(HD_NMA.Text) <> ""
                            WM_WLS_Dspflg = False
                            HD_TEXT.Text = ""
                            WLSKANA.ListIndex = 0
                            WM_WLS_STTKEY = HD_NMA.Text
                            WM_WLS_ENDKEY = HD_NMA.Text
                            WM_WLS_Dspflg = True
                            WM_WLS_Pagecnt = -1
                            WM_WLS_LastPage = -1
                            WM_WLS_LastFL = False
                            ReDim WM_WLS_DSPArray(0)
                    
                            Call WLS_NmaSQL
                            Call WLS_DspNew
                        Case Trim(HD_TEXT.Text) <> ""
                            WM_WLS_Dspflg = False
                            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
                            WM_WLS_STTKEY = HD_TEXT.Text
                            WM_WLS_ENDKEY = Null
                            WLSKANA.ListIndex = 0
                            HD_NMA.Text = ""
                            WM_WLS_Dspflg = True
                            WM_WLS_Pagecnt = -1
                            WM_WLS_LastPage = -1
                            WM_WLS_LastFL = False
                            ReDim WM_WLS_DSPArray(0)
                    
                            Call WLS_TextSQL
                            Call WLS_DspNew
                        Case WLSKANA.ListIndex > 0
                            HD_TEXT.Text = ""
                            HD_NMA.Text = ""
                            W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
                            WM_WLS_STTKEY = Left$(W_BUF, 1)
                            WM_WLS_ENDKEY = Chr$(Asc(Right$(W_BUF, 1)) + 1)
                            ReDim WM_WLS_DSPArray(0)
                            Call WLS_KanaSQL
                            Call WLS_DspNew
                       
                        Case Else
                            WM_WLS_Dspflg = False
                            HD_TEXT.Text = ""
                            WLSKANA.ListIndex = 0
                            HD_NMA.Text = ""
                            WM_WLS_STTKEY = WLSHINKB.Text
                            WM_WLS_ENDKEY = Null
                            WM_WLS_Dspflg = True
                            WM_WLS_Pagecnt = -1
                            WM_WLS_LastPage = -1
                            WM_WLS_LastFL = False
                            ReDim WM_WLS_DSPArray(0)
                    
                            Call WLS_KbSQL
                            Call WLS_DspNew
                    End Select
                Else
                    Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
                    Call P_SetFocus(WLSHINKB)
                    WLSHINKB.SelStart = 0
                    WLSHINKB.SelLength = Len(WLSHINKB.Text)
                
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
        HD_NMA.Text = ""
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

Private Sub P_SetFocus(ByRef objCtl As Control)

On Error Resume Next
    objCtl.SetFocus
    
End Sub


