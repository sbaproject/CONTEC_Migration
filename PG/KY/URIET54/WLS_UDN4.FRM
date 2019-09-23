VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSUDN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "売上明細検索"
   ClientHeight    =   6360
   ClientLeft      =   2310
   ClientTop       =   1695
   ClientWidth     =   15030
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
   ScaleHeight     =   6360
   ScaleWidth      =   15030
   Begin VB.ListBox LST1 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      ItemData        =   "WLS_UDN4.frx":0000
      Left            =   15075
      List            =   "WLS_UDN4.frx":0007
      TabIndex        =   19
      Top             =   1800
      Width           =   1875
   End
   Begin VB.ListBox KEYBAK 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   5070
      Left            =   15075
      TabIndex        =   12
      Top             =   1440
      Visible         =   0   'False
      Width           =   2715
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   0
      TabIndex        =   11
      Top             =   1320
      Width           =   14880
      _ExtentX        =   26247
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
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
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3540
      ItemData        =   "WLS_UDN4.frx":0011
      Left            =   0
      List            =   "WLS_UDN4.frx":0013
      TabIndex        =   0
      Top             =   1680
      Width           =   14880
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   6120
      TabIndex        =   8
      Top             =   5790
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   7245
      TabIndex        =   10
      Top             =   5790
      Width           =   1095
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1230
      Left            =   0
      TabIndex        =   9
      Top             =   0
      Width           =   15030
      _ExtentX        =   26511
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
      Begin VB.TextBox WLSURIKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   10020
         MaxLength       =   1
         TabIndex        =   7
         Top             =   600
         Width           =   285
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
         Left            =   11460
         MaxLength       =   10
         TabIndex        =   3
         Top             =   120
         Width           =   1255
      End
      Begin VB.CommandButton COM_UDNDT 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "売上日付"
         Height          =   375
         Left            =   10020
         TabIndex        =   20
         TabStop         =   0   'False
         Top             =   120
         Width           =   1455
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   8565
         MaxLength       =   6
         TabIndex        =   6
         Top             =   600
         Width           =   1155
      End
      Begin VB.TextBox WLSJDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   1380
         MaxLength       =   2
         TabIndex        =   1
         Top             =   120
         Width           =   435
      End
      Begin VB.CommandButton COM_JDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "受注取区"
         Height          =   375
         Left            =   120
         TabIndex        =   16
         TabStop         =   0   'False
         Top             =   120
         Width           =   1290
      End
      Begin VB.TextBox HD_TOKJDNNO 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   5520
         TabIndex        =   2
         Text            =   "XXXXXXXXX1XXXXXXXXX2XXX"
         Top             =   120
         Width           =   4215
      End
      Begin VB.TextBox WLSNHSCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   4920
         MaxLength       =   9
         TabIndex        =   5
         Text            =   "XXXXXXXX9"
         Top             =   600
         Width           =   1395
      End
      Begin VB.TextBox WLSTOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         Left            =   1380
         MaxLength       =   5
         TabIndex        =   4
         Text            =   "XXXX5"
         Top             =   600
         Width           =   915
      End
      Begin VB.CommandButton COM_TOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "得意先 "
         Height          =   375
         Left            =   120
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   600
         Width           =   1290
      End
      Begin VB.CommandButton COM_NHSCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         Caption         =   "納入先 "
         Height          =   375
         Left            =   3840
         TabIndex        =   14
         TabStop         =   0   'False
         Top             =   600
         Width           =   1155
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Index           =   0
         Left            =   3840
         TabIndex        =   15
         Top             =   120
         Width           =   1755
         _ExtentX        =   3096
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
         Caption         =   "客先注文番号"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   6960
         TabIndex        =   18
         Top             =   600
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
         Caption         =   "受注番号"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Index           =   1
         Left            =   10290
         TabIndex        =   22
         Top             =   600
         Width           =   3045
         _ExtentX        =   5371
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
         Caption         =   "1:売上済 2:未売上"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin VB.Label Label1 
         BackColor       =   &H00C0C0C0&
         Caption         =   "以降"
         Height          =   375
         Left            =   12825
         TabIndex        =   21
         Top             =   240
         Width           =   615
      End
      Begin VB.Label WLSJDNTRNM 
         Alignment       =   2  '中央揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BorderStyle     =   1  '実線
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   1800
         TabIndex        =   17
         Top             =   120
         Width           =   1725
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   6840
      Picture         =   "WLS_UDN4.frx":0015
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   7740
      Picture         =   "WLS_UDN4.frx":0667
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   7335
      Picture         =   "WLS_UDN4.frx":0CB9
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   6435
      Picture         =   "WLS_UDN4.frx":130B
      Top             =   8190
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5520
      Picture         =   "WLS_UDN4.frx":195D
      Top             =   5760
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   8520
      Picture         =   "WLS_UDN4.frx":1FAF
      Top             =   5760
      Width           =   360
   End
End
Attribute VB_Name = "WLSUDN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

' 2008/07/02 ADD START FKS)NAKATA
'XX 更新日付 :   2008/7/02
'XX 更新理由 :   レスポンス対応
'XX 更新内容
'XX ①「*受注取区」をサブ画面にて選択した場合、即時検索させない
'XX ②検索結果が０件の場合はメッセージを表示させる
'XX
'XX 本レスポンス対応ではコメントアウトを 「 'XX 」にて表記する。
' 2008/07/02 ADD E.N.D FKS)NAKATA

' 2008/07/03 ADD START FKS)NAKATA
'XX 更新日付 :  2008/7/03
'XX 更新理由 :   レスポンス対応
'XX 更新内容
'XX ①画面表示「*受注取区」(COM_JDNTRKB)を「受注取区」に変更
'XX ②検索結果数を表示させる(100件以上の場合)
'XX ③入力必須項目を「受注取区+客先注文番号」「受注番号」に設定する
'XX ④必須項目の入力がない場合はメッセージを表示させる
' 2008/07/03 ADD E.N.D FKS)NAKATA


'2008/07/05 ADD START FKS)NAKATA
'XX 画面表示記録用
    Private Type TYPE_LSTBOX_EXC
        LSTNO As String    'リストボックス番号
        JDNNO As String    '受注№
        UDNDT As String    '売上日
    End Type
Private WK_LSTBOX_BEF() As TYPE_LSTBOX_EXC

Dim WM_WLS_LIST_END As Boolean  '最終ページフラグ

Dim WM_WLS_PAGE_END As Integer  '最終ページ番号
Dim WM_WLS_LIST_CNT As Integer  '最終リスト番号
Dim WM_WLS_PAGE_CLICK_NUM As Integer 'ページ送りボタンクリック数

'2008/07/05 ADD E.N.D FKS)NAKATA



    '以下の４行の設定を行うこと
    Const WM_WLS_MSTKB = "1"            'マスタ区分(1:得意先 2:納品先 3:担当者 4:仕入先 5:商品)
    Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey = 10            '開始コードのソートキーNo
    Const WM_WLS_CDKey = -1              'カナ検索のソートキーNo+第一キー
    
    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_SFIL1 As Integer         'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    Dim WM_WLS_SFIL2 As Integer         'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    Dim WM_WLS_SFIL3 As Integer         'ウィンド表示ｻﾌﾞﾌｧｲﾙ
    
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
    Dim WlsOrderBy$
    Dim WlsFromWhere$
        

Private pv_blnChange_Flg As Boolean

Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

'20090115 ADD START RISE)Tanimura '連絡票No.523
Private mJDNTRKB    As String           ' 受注取区
Private mJDNNO      As String           ' 受注番号
Private mTOKJDNNO   As String           ' 客先注文番号
'20090115 ADD END   RISE)Tanimura

Private Sub COM_JDNTRKB_Click()
Dim wkJDNTRKB   As String
Dim strSQL As String

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
    
'2008/07/02 ADD START FKS)NAKATA
'XX 受注取引区分一覧サブ画面にて区分が選択された時、即検索をさせないため追加
    WLSJDNTRKB.Text = ""
    WLSJDNTRNM.Caption = ""
'2008/07/02 ADD E.N.D FKS)NAKATA
    
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        WLSJDNTRKB.Text = ""
        WLSJDNTRNM.Caption = ""
        Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
        Call P_SetFocus(WLSJDNTRKB)
        WLSJDNTRKB.SelStart = 0
        WLSJDNTRKB.SelLength = Len(WLSJDNTRKB.Text)
    Else
        wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid$(PP_SSSMAIN.SlistCom, 2)))
        Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
        If DBSTAT = 0 Then
            WLSJDNTRKB.Text = Left$(DB_MEIMTA.MEICDA, 2)
            WLSJDNTRNM.Caption = DB_MEIMTA.MEINMA

'2008/07/02 DEL START FKS)NAKATA
'XX 受注取引区分一覧サブ画面にて区分が選択された時、即検索をさせないため消去

'XX '            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
'XX '            WM_WLS_ENDKEY = "9"
'XX            WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
'XX            WM_WLS_ENDKEY = "1" & "9"
'XX            WM_WLS_KeyCode = 0
'XX            WM_WLS_Dspflg = True
'XX            WM_WLS_Pagecnt = -1
'XX            DoEvents
'XX '''            strSQL = ""
'XX '''            strSQL = strSQL & " SELECT * FROM ( "
'XX '''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
'XX '''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'XX '''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'XX '''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
'XX '''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
'XX '''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
'XX '''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'XX '''
'XX '''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'XX '''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
'XX            Call WLS_BaseSQL(WM_WLS_STTKEY)
'XX            If WLSSSS_SET_KEYBAK() = True Then
'XX                Call WLSSSS_DSP
'XX            End If
'XX            PP_SSSMAIN.SlistCom = Null
'2008/07/02 DEL E.N.D FKS)NAKATA
        Else
            Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
            Call P_SetFocus(WLSJDNTRKB)
            WLSJDNTRKB.SelStart = 0
            WLSJDNTRKB.SelLength = Len(WLSJDNTRKB.Text)
        End If
    End If

End Sub

Private Sub COM_TOKCD_Click()
    Dim I As Integer
    Dim W_Key As String
    Dim strSQL As String
    
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
            WLSTOKCD.Text = RTrim(DB_TOKMTA.TOKCD)
            WM_WLS_KeyCode = -1
            WM_WLS_Dspflg = False
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1

'2008/07/04 DEL START FKS)NAKATA
'XX サブ画面にて選ばれた場合、即検索行かないようにする。
'XX            W_Key = "1" & "1" & HD_TEXT.Text
'XX            DoEvents
'XX'''            strSQL = ""
'XX'''            strSQL = strSQL & " SELECT * FROM ( "
'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'XX            Call WLS_BaseSQL(W_Key)
'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
'XX            If WLSSSS_SET_KEYBAK() = True Then
'XX                WM_WLS_INIT = 1
'XX                Call WLSSSS_DSP
'XX            End If
'2008/07/04 DEL E.N.D FKS)NAKATA

        End If
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_NHSCD_Click()
    Dim I As Integer
    Dim W_Key As String
    Dim strSQL As String
    
    DB_PARA(DBN_NHSMTA).KeyBuf = WLSNHSCD.Text
    WLSNHS.Show 1 '0:入力候補一覧は入力後に残す指定。
    ''98/09/25 追加
    Unload WLSNHS
    DoEvents
    If IsNull(PP_SSSMAIN.SlistCom) Then
        DB_NHSMTA.NHSCD = ""
    Else
        Call DB_GetEq(DBN_NHSMTA, 1, Left$(PP_SSSMAIN.SlistCom, 9), BtrNormal)
        If DBSTAT = 0 Then
            WLSNHSCD.Text = DB_NHSMTA.NHSCD
            WM_WLS_KeyCode = -1
            WM_WLS_Dspflg = False
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            
'2008/07/05 DEL START FKS)NAKATA
'XX ボタンを押された場合、即検索に行かない
'XX            W_Key = "1" & "1" & HD_TEXT.Text
'XX            DoEvents
'XX'''            strSQL = ""
'XX'''            strSQL = strSQL & " SELECT * FROM ( "
'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'XX'''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
'XX'''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'XX            Call WLS_BaseSQL(W_Key)
'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
'XX            If WLSSSS_SET_KEYBAK() = True Then
'XX                WM_WLS_INIT = 1
'XX                Call WLSSSS_DSP
'XX            End If
'2008/07/05 DEL E.N.D FKS)NAKATA
        End If
    End If
    PP_SSSMAIN.SlistCom = Null

End Sub

Private Sub COM_UDNDT_Click()
    Dim I As Integer
    Dim strSQL As String
    
    Set_date = CNV_DATE(DB_UNYMTA.UNYDT)
    WLS_DATE.Show 1
    Unload WLS_DATE
    DoEvents
    
    WLSUDNDT.Text = Set_date
'    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
    WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
'    WM_WLS_ENDKEY = "9"
    WM_WLS_ENDKEY = "1" & "9"
    WM_WLS_KeyCode = 0
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    DoEvents
'''    strSQL = ""
'''    strSQL = strSQL & " SELECT * FROM ( "
'''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
'''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)

'2008/07/05 DEL START FKS)NAKATA
'XX 日付が選択されて時に即検索にいかないよう消去
'XX    Call WLS_BaseSQL(WM_WLS_STTKEY)
'XX    If WLSSSS_SET_KEYBAK() = True Then
'XX        Call WLSSSS_DSP
'XX    End If
'2008/07/05 DEL E.ND FKS)NAKATA

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
    pv_blnChange_Flg = False
End Sub
'

Private Sub HD_TEXT_Change()
    Dim s As Long
    s = HD_TEXT.SelStart
    HD_TEXT.Text = StrConv(HD_TEXT.Text, vbUpperCase)
    HD_TEXT.SelStart = s
End Sub

Private Sub HD_TEXT_GotFocus()
''    If LenWid(HD_TEXT.Text) > 0 Then
''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
''    Else
''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
''    End If
    HD_TEXT.SelStart = 0
    HD_TEXT.SelLength = HD_TEXT.MaxLength
End Sub

Private Sub HD_TEXT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim I, STAT%
    Dim strSQL As String

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
            HD_TEXT.SelStart = 0
            HD_TEXT.SelLength = HD_TEXT.MaxLength
'            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
            WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
'            WM_WLS_ENDKEY = "9"
            WM_WLS_ENDKEY = "1" & "9"
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_KeyNo = WM_WLS_TextKey
'''            strSQL = ""
'''            strSQL = strSQL & " SELECT * FROM ( "
'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
            Call WLS_BaseSQL(WM_WLS_STTKEY)
            
            KEYBAK.Clear
            LST.Clear
            LST1.Clear
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

Private Sub HD_TOKJDNNO_GotFocus()
    HD_TOKJDNNO.SelStart = 0
    HD_TOKJDNNO.SelLength = LenWid(HD_TOKJDNNO.Text)
End Sub

Private Sub HD_TOKJDNNO_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Call WLS_BaseSQL(W_Key)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        WM_WLS_INIT = 1
        Call WLSSSS_DSP
    End If
End Sub

''Private Sub HD_TOKJDNNO_LostFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
'''''''    If LST.ListCount > 0 Then
'''''''        LST.ListIndex = 0
'''''''    Else
'''''''        WLSTOKCD.SetFocus
'''''''    End If
''
''End Sub

Private Sub WLSJDNTRKB_GotFocus()
''    If LenWid(WLSJDNTRKB.Text) > 0 Then
''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
''    Else
''        WLSJDNTRKB.Text = Space$(LenWid(DB_UDNTHA.JDNTRKB))
''    End If
    WLSJDNTRKB.SelStart = 0
    WLSJDNTRKB.SelLength = LenWid(DB_UDNTHA.JDNTRKB)

End Sub

Private Sub WLSJDNTRKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim I, STAT%
    Dim wkJDNTRKB   As String
    Dim strSQL As String

    Select Case KEYCODE
        Case 13
            WM_WLS_Dspflg = False
            KEYBAK.Clear
            LST.Clear
            LST1.Clear
            WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
            WLSJDNTRKB.SelStart = 0
            WLSJDNTRKB.SelLength = LenWid(DB_UDNTHA.JDNTRKB)
            If Trim$(WLSJDNTRKB.Text) = "" Then
                Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
                Call P_SetFocus(WLSJDNTRKB)
                WLSJDNTRKB.SelStart = 0
                WLSJDNTRKB.SelLength = Len(WLSJDNTRKB.Text)
'2008/07/02 ADD START FKS)NAKATA
'XX 受注取引区分がブランクの場合、表示を消す。
                WLSJDNTRNM.Caption = ""
'2008/07/02 ADD E.N.D FKS)NAKATA
            Else
                wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
                Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
                If DBSTAT = 0 Then
                    WLSJDNTRKB.Text = Left$(DB_MEIMTA.MEICDA, 2)
                    WLSJDNTRNM.Caption = DB_MEIMTA.MEINMA
'                    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
                    WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
'                    WM_WLS_ENDKEY = "9"
                    WM_WLS_ENDKEY = "1" & "9"
                    WM_WLS_KeyCode = 0
                    WM_WLS_Dspflg = True
                    WM_WLS_Pagecnt = -1
'''                    strSQL = ""
'''                    strSQL = strSQL & " SELECT * FROM ( "
'''                    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
'''                    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    Call WLS_BaseSQL(WM_WLS_STTKEY)
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP
                    End If
                Else
                    Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
                    Call P_SetFocus(WLSJDNTRKB)
                    WLSJDNTRKB.SelStart = 0
                    WLSJDNTRKB.SelLength = Len(WLSJDNTRKB.Text)
                
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
    Dim WK_JDNNO As String * 8, WK_DENDT As String * 10, WK_UDNDT As String * 10
'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 売上済の場合
    If g_strURIKB = "1" Then
'20090115 ADD END   RISE)Tanimura
    WK_JDNNO = Left$(DB_UDNTRA.JDNNO, 6) + Mid$(DB_UDNTRA.JDNLINNO, 2, 2)
    WK_UDNDT = Left$(DB_UDNTRA.UDNDT, 4) + "/" + Mid$(DB_UDNTRA.UDNDT, 5, 2) + "/" + Right$(DB_UDNTRA.UDNDT, 2)
        
    WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_UDNTRA.TOKCD & "'"
    WlsOrderBy = ""
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
    
    Call NHSMTA_RClear
    WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_UDNTRA.NHSCD & "'"
    WlsOrderBy = ""
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)

    Call JDNTRA_RClear
    WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
    WlsFromWhere = WlsFromWhere + "   AND AKAKROKB = '1'"
    WlsFromWhere = WlsFromWhere + "   AND JDNNO = '" & DB_UDNTRA.JDNNO & "'"
    WlsFromWhere = WlsFromWhere + "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
    WlsOrderBy = " ORDER BY DATNO DESC"
    DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)

    WK_DENDT = Left$(DB_JDNTRA.DENDT, 4) + "/" + Mid$(DB_JDNTRA.DENDT, 5, 2) + "/" + Right$(DB_JDNTRA.DENDT, 2)

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 未売上の場合
    Else
        WK_JDNNO = Left$(DB_ODNTRA.JDNNO, 6) + Mid$(DB_ODNTRA.JDNLINNO, 2, 2)
        WK_UDNDT = Left$(DB_ODNTRA.ODNDT, 4) + "/" + Mid$(DB_ODNTRA.ODNDT, 5, 2) + "/" + Right$(DB_ODNTRA.ODNDT, 2)
        
        WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_ODNTRA.TOKCD & "'"
        WlsOrderBy = ""
        DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)

        Call NHSMTA_RClear
        WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_ODNTRA.NHSCD & "'"
        WlsOrderBy = ""
        DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)

        Call JDNTRA_RClear
        WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
        WlsFromWhere = WlsFromWhere + "   AND AKAKROKB = '1'"
        WlsFromWhere = WlsFromWhere + "   AND JDNNO = '" & DB_ODNTRA.JDNNO & "'"
        WlsFromWhere = WlsFromWhere + "   AND LINNO = '" & DB_ODNTRA.JDNLINNO & "'"
        WlsOrderBy = " ORDER BY DATNO DESC"
        DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)

        WK_DENDT = Left$(DB_JDNTRA.DENDT, 4) + "/" + Mid$(DB_JDNTRA.DENDT, 5, 2) + "/" + Right$(DB_JDNTRA.DENDT, 2)
    End If
'20090115 ADD END   RISE)Tanimura

'2008/07/05 ADD START FKS)NAKATA
'XX 受注番号で検索したものには受注取区を表示しない
    Dim wkTRKB As String
    If Trim(HD_TEXT.Text) <> "" Then
        wkTRKB = ""
    Else
        wkTRKB = WLSJDNTRKB
    End If
'2008/07/05 E.N.D START FKS)NAKATA
    
    
'2008/04/07 FKS)ASANO ADD START
    If Left$(WK_DENDT, 4) <> "    " Then
'2008/04/07 FKS)ASANO ADD END
'20090115 ADD START RISE)Tanimura '連絡票No.523
        ' 売上済の場合
        If g_strURIKB = "1" Then
'20090115 ADD END   RISE)Tanimura
        LST.AddItem WK_JDNNO + " " + WK_UDNDT + " " + WK_DENDT + " " _
                  + LeftWid2$(DB_UDNTRA.TOKCD, 5) + " " + LeftWid2$(DB_TOKMTA.TOKRN, 20) + " " _
                  + LeftWid2$(DB_UDNTRA.NHSCD, 9) + " " + LeftWid2$(DB_NHSMTA.NHSRN, 20) + " " _
                  + LeftWid2$(DB_UDNTRA.HINNMA, 20) + " " + LeftWid2$(DB_UDNTRA.HINNMB, 10) + " " _
                  + String(7 - Len(Format$(DB_UDNTRA.URISU, "###,##0")), " ") + Format$(DB_UDNTRA.URISU, "###,##0") + " " + wkTRKB

        '2008/07/05 DEL START FKS)NAKATA
         'XX         + String(7 - Len(Format$(DB_UDNTRA.URISU, "###,##0")), " ") + Format$(DB_UDNTRA.URISU, "###,##0") + " " + WLSJDNTRKB       ' DB_UDNTHA.JDNTRKB
        '2008/07/05 DEL E.N.D FKS)NAKATA
        
        LST1.AddItem DB_UDNTRA.DATNO + DB_UDNTRA.LINNO + DB_UDNTRA.UDNNO
'20090115 ADD START RISE)Tanimura '連絡票No.523
        ' 未売上の場合
        Else
            LST.AddItem WK_JDNNO + " " + WK_UDNDT + " " + WK_DENDT + " " _
                      + LeftWid2$(DB_ODNTRA.TOKCD, 5) + " " + LeftWid2$(DB_TOKMTA.TOKRN, 20) + " " _
                      + LeftWid2$(DB_ODNTRA.NHSCD, 9) + " " + LeftWid2$(DB_NHSMTA.NHSRN, 20) + " " _
                      + LeftWid2$(DB_ODNTRA.HINNMA, 20) + " " + LeftWid2$(DB_ODNTRA.HINNMB, 10) + " " _
                      + String(7 - Len(Format$(DB_ODNTRA.OTPSU, "###,##0")), " ") + Format$(DB_ODNTRA.OTPSU, "###,##0") + " " + wkTRKB

            LST1.AddItem DB_ODNTRA.DATNO + DB_ODNTRA.LINNO + DB_ODNTRA.ODNNO
        End If
'20090115 ADD END   RISE)Tanimura

'2008/07/05 ADD START FKS)NAKATA
        'XX 画面に表示されるListBoxの内容を退避させる。
         If WM_WLS_LIST_END = False Then
            
            ReDim Preserve WK_LSTBOX_BEF(LST.ListCount)
            
            WK_LSTBOX_BEF(LST.ListCount).LSTNO = LST.ListCount  'リスト番号
            WK_LSTBOX_BEF(LST.ListCount).JDNNO = WK_JDNNO        '受注№
            WK_LSTBOX_BEF(LST.ListCount).UDNDT = WK_UDNDT        '売上日
        End If
        
'2008/07/05 ADD E.N.D FKS)NAKATA

'2008/04/07 FKS)ASANO ADD START
    End If
'2008/04/07 FKS)ASANO ADD END

 End Sub

Private Function WLS_DSP_CHECK()
Dim wkTOKCD As String
Dim wkNHSCD As String

'2008/07/04 ADD START FKS)NAKATA
Dim wkTOKJDNNO As String
Dim wkTOKCNT As Integer
'2008/07/04 ADD E.N.D FKS)NAKATA


    '====================================
    '   WINDOW 表示可能チェック
    '       WLS_DSP_CHECK = True  :表示可
    '       WLS_DSP_CHECK = FALSE :表示不可
    '====================================
'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 売上済の場合
    If g_strURIKB = "1" Then
'20090115 ADD END   RISE)Tanimura
    WLS_DSP_CHECK = SSS_OK
    If DB_UDNTRA.DATKB <> "1" Then
        WLS_DSP_CHECK = SSS_END
        Exit Function
    End If
    If DB_UDNTRA.AKAKROKB <> "1" Then
        WLS_DSP_CHECK = SSS_END
        Exit Function
    End If
    If DB_UDNTRA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
'''    Call DB_GetEq(DBN_UDNTHA, 1, DB_UDNTRA.DATNO, BtrNormal)
'''    If DBSTAT = 0 Then
'''        If DB_UDNTHA.JDNTRKB <> WLSJDNTRKB Then WLS_DSP_CHECK = SSS_NEXT
'''    Else
'''        WLS_DSP_CHECK = SSS_NEXT
'''    End If

    wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTRA.TOKCD) - Len(WLSTOKCD.Text))
    wkNHSCD = WLSNHSCD.Text & Space(Len(DB_UDNTRA.NHSCD) - Len(WLSNHSCD.Text))
    

    
    
'2008/07/04 ADD START FKS)NAKATA
    wkTOKCNT = Len(HD_TOKJDNNO.Text)
    wkTOKJDNNO = Left$(Trim(DB_UDNTRA.TOKJDNNO), wkTOKCNT)
'2008/07/04 ADD E.N.D FKS)NAKATA

'2008/07/05 CHG START FKS)NAKATA
'XX    If (Trim$(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> WLSNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
       If (Trim$(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> wkNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
'2008/07/05 CHG START FKS)NAKATA

    If (Trim$(WLSTOKCD.Text) <> "") And (DB_UDNTRA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
    
'2008/07/04 CHG STRAT FKS)NAKATA
'XX    If (Trim$(HD_TOKJDNNO.Text) <> "") And (DB_UDNTRA.TOKJDNNO <> HD_TOKJDNNO.Text) Then WLS_DSP_CHECK = SSS_NEXT
       
       If (Trim$(HD_TOKJDNNO.Text) <> "") And _
                (Trim$(HD_TOKJDNNO.Text) <> wkTOKJDNNO) Then
             WLS_DSP_CHECK = SSS_NEXT
       End If
    
'2008/07/04 CHG E.N.D FKS)NAKATA

    If (Trim$(WLSUDNDT.Text) <> "") And (DB_UDNTRA.UDNDT < DeCNV_DATE(WLSUDNDT)) Then WLS_DSP_CHECK = SSS_NEXT

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 未売上の場合
    Else
        WLS_DSP_CHECK = SSS_OK

        If DB_ODNTRA.DATKB <> "1" Then
            WLS_DSP_CHECK = SSS_END
            Exit Function
        End If

        If DB_ODNTRA.DENKB <> "1" Then
            WLS_DSP_CHECK = SSS_END
            Exit Function
        End If

        wkTOKCD = WLSTOKCD.Text & Space(Len(DB_ODNTRA.TOKCD) - Len(WLSTOKCD.Text))
        wkNHSCD = WLSNHSCD.Text & Space(Len(DB_ODNTRA.NHSCD) - Len(WLSNHSCD.Text))

        wkTOKCNT = Len(HD_TOKJDNNO.Text)
        wkTOKJDNNO = Left$(Trim(DB_ODNTRA.TOKJDNNO), wkTOKCNT)

        If Trim$(WLSNHSCD.Text) <> "" And Trim$(Left$(DB_ODNTRA.NHSCD, Len(Trim$(wkNHSCD)))) <> Trim$(wkNHSCD) Then
            WLS_DSP_CHECK = SSS_NEXT
        End If

        If Trim$(WLSTOKCD.Text) <> "" And Trim$(Left$(DB_ODNTRA.TOKCD, Len(Trim$(wkTOKCD)))) <> Trim$(wkTOKCD) Then
            WLS_DSP_CHECK = SSS_NEXT
        End If

        If Trim$(HD_TOKJDNNO.Text) <> "" And Trim$(HD_TOKJDNNO.Text) <> wkTOKJDNNO Then
            WLS_DSP_CHECK = SSS_NEXT
        End If
    End If
'20090115 ADD END   RISE)Tanimura
End Function

Private Function WLS_DSP_SUB_CHECK()
'''''    Dim WL_OTPSU As Currency
'''''    WLS_DSP_SUB_CHECK = SSS_OK
'''''    Call DB_GetGrEq(DBN_UDNTRA, 1, "1" & DB_UDNTRA.JDNNO, BtrNormal)
'''''    Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1") And (SSSVal(DB_UDNTRA.JDNLINNO) < 990)
'''''        WL_OTPSU = 0
'''''        Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1")
'''''            Call DB_GetNext(DBN_UDNTRA, BtrNormal)
'''''        Loop
'''''        WL_OTPSU = DB_UDNTRA.FRDSU - DB_UDNTRA.HIKSU
'''''        If WL_OTPSU > 0 Then
'''''            WLS_DSP_SUB_CHECK = SSS_OK
'''''            DBSTAT = 0
'''''            Exit Function
'''''        Else
'''''            WLS_DSP_SUB_CHECK = SSS_NEXT
'''''        End If
'''''        Call DB_GetNext(DBN_UDNTRA, BtrNormal)
'''''    Loop
'''''    DBSTAT = 0
End Function

Private Sub WLS_FORM_LOAD()

    '=== WINDOW 位置設定 ===
    WLSUDN.Left = (Screen.Width - WLSUDN.Width) / 2
    WLSUDN.Top = (Screen.Height - WLSUDN.Height) / 2

    '=== ｺｰﾄﾞTEXT ===
    'WLSTOKCD.Height = 285
    'WLSRN.Height = 285
    'WLSTOKCD.Text = ""


    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_UDNTRA
    WM_WLS_SFIL1 = DBN_TOKMTA
    WM_WLS_SFIL2 = DBN_NHSMTA
    WM_WLS_SFIL3 = DBN_JDNTRA

    SWlsSelList = "*"


    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = LenWid(DB_UDNTRA.DATNO) + LenWid(DB_UDNTRA.LINNO) + LenWid(DB_UDNTRA.UDNNO)

    '=== ＬＡＢＥＬ設定 ===
    WLSLABEL = "受注番号 売上日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"

    WM_WLS_INIT = 0
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadイベント障害対応  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub WLSATO_Click()
    Dim WL_Key As String
    Dim strSQL As String
    

'2008/07/05 ADD START FKS)NAKATA
'XX ページ送りカウント
If WM_WLS_PAGE_END > WM_WLS_PAGE_CLICK_NUM Then
    WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM + 1
End If
'2008/07/05 ADD E.N.D FKS)NAKATA
    
    
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
                

'''                strSQL = ""
'''                strSQL = strSQL & " SELECT * FROM ( "
'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'2008/07/04 CHG START FKS)NAKATA
'XX                Call WLS_BaseSQL(WL_Key)
'20090115 CHG START RISE)Tanimura '連絡票No.523
'                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                ' 売上済の場合
                If g_strURIKB = "1" Then
                    Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)

                ' 未売上の場合
                Else
                    ' 受注番号から検索
                    If Trim(HD_TEXT.Text) <> "" Then
                        strSQL = ""
                        strSQL = strSQL & "SELECT"
                        strSQL = strSQL & "  * "
                        strSQL = strSQL & "FROM"
                        strSQL = strSQL & "  ("
                        strSQL = strSQL & "   SELECT"
                        strSQL = strSQL & "     A.*"
                        strSQL = strSQL & "   FROM"
                        strSQL = strSQL & "     ODNTRA A"
                        strSQL = strSQL & "   , ("
                        strSQL = strSQL & "      SELECT"
                        strSQL = strSQL & "        B2.*"
                        strSQL = strSQL & "      FROM"
                        strSQL = strSQL & "        JDNTHA B1"
                        strSQL = strSQL & "      , JDNTRA B2"
                        strSQL = strSQL & "      WHERE"
                        strSQL = strSQL & "        B1.DATNO = B2.DATNO"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
                        strSQL = strSQL & "                                 SELECT"
                        strSQL = strSQL & "                                   MAX(DATNO) DATNO"
                        strSQL = strSQL & "                                 , LINNO      LINNO"
                        strSQL = strSQL & "                                 FROM"
                        strSQL = strSQL & "                                   JDNTRA"
                        strSQL = strSQL & "                                 WHERE"
                        strSQL = strSQL & "                                   JDNNO " & mJDNNO
                        strSQL = strSQL & "                                 GROUP BY"
                        strSQL = strSQL & "                                   JDNNO"
                        strSQL = strSQL & "                                 , LINNO"
                        strSQL = strSQL & "                                )"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B2.OTPSU > B2.URISU"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
                        strSQL = strSQL & "      AND"
            ' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
            '            strSQL = strSQL & "        B1.FRNKB = '0'"
                        strSQL = strSQL & "       (B1.FRNKB = '0'"
                        strSQL = strSQL & "        OR ("
                        strSQL = strSQL & "                  B1.FRNKB   = '1' "
                        strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
                        strSQL = strSQL & "           )"
                        strSQL = strSQL & "       )"
            ' === 20110305 === UPDATE E TOM)Morimoto
                        strSQL = strSQL & "     ) B "
                        strSQL = strSQL & "   WHERE"
                        strSQL = strSQL & "     A.JDNNO = B.JDNNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DATKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DENKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.OTPSU > 0"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO " & mJDNNO
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid$(WL_Key, 3, 21) & "' "
                        strSQL = strSQL & "  ) "
                        strSQL = strSQL & "ORDER BY"
                        strSQL = strSQL & "  DATKB "
                        strSQL = strSQL & ", DENKB "
                        strSQL = strSQL & ", JDNNO "
                        strSQL = strSQL & ", JDNLINNO "
                        strSQL = strSQL & ", ODNDT "

                    ' 受注取区 + 客先注文番号
                    ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then
                        strSQL = ""
                        strSQL = strSQL & "SELECT"
                        strSQL = strSQL & "  * "
                        strSQL = strSQL & "FROM"
                        strSQL = strSQL & "  ("
                        strSQL = strSQL & "   SELECT"
                        strSQL = strSQL & "     A.*"
                        strSQL = strSQL & "   FROM"
                        strSQL = strSQL & "     ODNTRA A"
                        strSQL = strSQL & "   , ("
                        strSQL = strSQL & "      SELECT"
                        strSQL = strSQL & "        B2.*"
                        strSQL = strSQL & "      FROM"
                        strSQL = strSQL & "        JDNTHA B1"
                        strSQL = strSQL & "      , JDNTRA B2"
                        strSQL = strSQL & "      WHERE"
                        strSQL = strSQL & "        B1.DATNO = B2.DATNO"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
                        strSQL = strSQL & "                                 SELECT"
                        strSQL = strSQL & "                                   MAX(DATNO) DATNO"
                        strSQL = strSQL & "                                 , LINNO      LINNO"
                        strSQL = strSQL & "                                 FROM"
                        strSQL = strSQL & "                                   JDNTRA"
                        strSQL = strSQL & "                                 GROUP BY"
                        strSQL = strSQL & "                                   JDNNO"
                        strSQL = strSQL & "                                 , LINNO"
                        strSQL = strSQL & "                                )"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B2.OTPSU > B2.URISU"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
                        strSQL = strSQL & "      AND"
            ' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
            '            strSQL = strSQL & "        B1.FRNKB = '0'"
                        strSQL = strSQL & "       (B1.FRNKB = '0'"
                        strSQL = strSQL & "        OR ("
                        strSQL = strSQL & "                  B1.FRNKB   = '1' "
                        strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
                        strSQL = strSQL & "           )"
                        strSQL = strSQL & "       )"
            ' === 20110305 === UPDATE E TOM)Morimoto
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
                        strSQL = strSQL & "     ) B "
                        strSQL = strSQL & "   WHERE"
                        strSQL = strSQL & "     A.JDNNO = B.JDNNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DATKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DENKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.OTPSU > 0"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid$(WL_Key, 3, 21) & "' "
                        strSQL = strSQL & "  ) "
                        strSQL = strSQL & "ORDER BY"
                        strSQL = strSQL & "  DATKB "
                        strSQL = strSQL & ", DENKB "
                        strSQL = strSQL & ", JDNNO "
                        strSQL = strSQL & ", JDNLINNO "
                        strSQL = strSQL & ", ODNDT "
                    End If

                    Call DB_GetSQL2(DBN_ODNTRA, strSQL)
                End If
'20090115 CHG END   RISE)Tanimura
'2008/07/04 CHG E.N.D FKS)NAKATA
'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
            Call WLSSSS_DSP
'2008/07/05 ADD START FKS)NAKATA
            'XX 最終ページの表示チェック(最終ページを一度確認している場合)
            If KEYBAK.List(WM_WLS_Pagecnt + 1) = "z" And LST.ListCount > UBound(WK_LSTBOX_BEF()) Then
                Call CHK_ListBox
            ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then
                Call CHK_ListBox
            End If
            
'2008/07/05 ADD E.N.D FKS)NAKATA
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

Private Sub WLSHINCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        Call WLS_BaseSQL(W_Key)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        End If
    End If
End Sub

''Private Sub WLSHINCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
'''''''    If LST.ListCount > 0 Then
'''''''        WLSHINNMA.SetFocus
'''''''    Else
'''''''        WLSHINCD.SetFocus
'''''''    End If
''
''End Sub

Private Sub WLSSOUCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        Call WLS_BaseSQL(W_Key)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        End If
    End If
End Sub

''Private Sub WLSSOUCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
'''''''    If LST.ListCount > 0 Then
'''''''        WLSSOUCD.SetFocus
'''''''    Else
'''''''        WLSUDNDT.SetFocus
'''''''    End If
''
''End Sub

Private Sub WLSHINNMA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Call WLS_BaseSQL(W_Key)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        If WLSSSS_SET_KEYBAK() = True Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        End If
    End If
End Sub

''Private Sub WLSHINNMA_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
''''''''    If LST.ListCount > 0 Then
''''''''        WLSTOKCD.SetFocus
''''''''    Else
''''''''        WLSHINNMA.SetFocus
''''''''    End If
''
''End Sub

''Private Sub WLSJDNTRKB_LostFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
''''''    If LST.ListCount > 0 Then
''''''        LST.ListIndex = 0
''''''    Else
''''''        WLSTOKCD.SetFocus
''''''    End If
''
''
''End Sub

Private Sub WLSNHSCD_Change()
    Dim s As Long
    s = WLSNHSCD.SelStart
    WLSNHSCD.Text = StrConv(WLSNHSCD.Text, vbUpperCase)
    WLSNHSCD.SelStart = s
End Sub

Private Sub WLSNHSCD_GotFocus()
    WLSNHSCD.SelStart = 0
    WLSNHSCD.SelLength = LenWid(WLSNHSCD.Text)
End Sub

Private Sub WLSNHSCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        Call WLS_BaseSQL(W_Key)
        
 '2008/07/02 CHG START FKS)NAKATA
'XX        If WLSSSS_SET_KEYBAK() = True Then
'XX            WM_WLS_INIT = 1
'XX            Call WLSSSS_DSP
'XX        End If
            KEYBAK.Clear
            LST.Clear
            LST1.Clear
            WM_WLS_Pagecnt = -1
            If WLSSSS_SET_KEYBAK() = True Then
                Call WLSSSS_DSP
            End If
'2008/07/02 CHG START FKS)NAKATA

    End If

End Sub

''Private Sub WLSNHSCD_LostFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
''
''End Sub
''
Private Sub WLSTOKCD_GotFocus()
    WLSTOKCD.SelStart = 0
    WLSTOKCD.SelLength = LenWid(WLSTOKCD.Text)
End Sub

Private Sub WLSTOKCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        Dim I As Integer
        Dim W_Key As String
        Dim strSQL As String
    
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 削除
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        W_Key = "1" & "1" & HD_TEXT.Text
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Call WLS_BaseSQL(W_Key)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        
'2008/07/05 ADD START FKS)NAKATA
        KEYBAK.Clear
        LST.Clear
        LST1.Clear
        WM_WLS_Pagecnt = -1
        WM_WLS_INIT = 1
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP
        End If
'2008/07/05 ADD E.N.D FKS)NAKATA

    End If
End Sub

''Private Sub WLSTOKCD_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''
''    WM_WLS_Dspflg = False
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    ''98/09/25 削除
''    ''WM_WLS_KeyNo = WM_WLS_TextKey
''    W_Key = "1" & "1" & HD_TEXT.Text
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        WM_WLS_INIT = 1
''        Call WLSSSS_DSP
''    End If
'''''''    If LST.ListCount > 0 Then
'''''''        LST.ListIndex = 0
'''''''    Else
'''''''        WLSTOKCD.SetFocus
'''''''    End If
''
''End Sub
''
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
            Dim strSQL As String
        
            If Trim$(WLSUDNDT) <> "" Then
                If CHECK_DATE(WLSUDNDT) = False Then
                    Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
                    Call P_SetFocus(WLSUDNDT)
                    Exit Sub
                End If
            End If
            
    '        WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
            WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
    '        WM_WLS_ENDKEY = "9"
            WM_WLS_ENDKEY = "1" & "9"
            WM_WLS_KeyCode = 0
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
'''            strSQL = ""
'''            strSQL = strSQL & " SELECT * FROM ( "
'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''    '''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
    '''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
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

''Private Sub WLSUDNDT_LOSTFocus()
''    Dim I As Integer
''    Dim W_Key As String
''    Dim strSQL As String
''    Dim strDat As String
''
''    If Trim$(WLSUDNDT) <> "" Then
''        If ConvDat(Trim(WLSUDNDT.Text), strDat) = False Then
''            WLSUDNDT.SetFocus
''            Exit Sub
''        End If
''        If CHECK_DATE(WLSUDNDT) = False Then
''            Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
''            Call P_SetFocus(WLSUDNDT)
''            Exit Sub
''        End If
''    End If
''    WM_WLS_STTKEY = "1" & "1"
'''    WM_WLS_ENDKEY = "9"
''    WM_WLS_ENDKEY = "1" & "9"
''    WM_WLS_KeyCode = 0
''    WM_WLS_Dspflg = True
''    WM_WLS_Pagecnt = -1
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
''    If WLSSSS_SET_KEYBAK() = True Then
''        Call WLSSSS_DSP
''    End If
''
''End Sub
''

'20090115 ADD START RISE)Tanimura '連絡票No.523
Private Sub WLSURIKB_GotFocus()
    WLSURIKB.SelStart = 0
    WLSURIKB.SelLength = LenWid(WLSURIKB.Text)
End Sub

Private Sub WLSURIKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Dim W_Key   As String

    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1

        ' 入力された値が 1 or 2 でない場合
        If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
            ' 無条件に 1 にする
            WLSURIKB.Text = "1"
        End If

        W_Key = "1" & "1" & HD_TEXT.Text

        Call WLS_BaseSQL(W_Key)

        KEYBAK.Clear
        LST.Clear
        LST1.Clear
        WM_WLS_Pagecnt = -1
        WM_WLS_INIT = 1
        If WLSSSS_SET_KEYBAK() = True Then
            Call WLSSSS_DSP
        End If
    End If
End Sub

Private Sub WLSURIKB_LostFocus()
    ' 入力された値が 1 or 2 でない場合
    If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
        ' 無条件に 1 にする
        WLSURIKB.Text = "1"
    End If
End Sub
'20090115 ADD END   RISE)Tanimura

Private Sub WLSMAE_Click()
    Dim WL_Key As String
    Dim strSQL As String


'2008/07/05 ADD START FKS)NAKATA
'XX ページ送りカウント
If WM_WLS_PAGE_CLICK_NUM > 0 Then
    WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM - 1
End If
'2008/07/05 ADD E.N.D FKS)NAKATA
    
    
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    Else
        Exit Sub
    End If
    WL_Key = KEYBAK.List(WM_WLS_Pagecnt)
''    strSQL = ""
''    strSQL = strSQL & " SELECT * FROM ( "
''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'20080702 CHG START FKS)NAKATA
'XX    Call WLS_BaseSQL(WL_Key)
  ''     Call DB_GetPre(DBN_UDNTRA, BtrNormal)
'20090115 CHG START RISE)Tanimura '連絡票No.523
'       Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                ' 売上済の場合
                If g_strURIKB = "1" Then
                    Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)

                ' 未売上の場合
                Else
                    ' 受注番号から検索
                    If Trim(HD_TEXT.Text) <> "" Then
                        strSQL = ""
                        strSQL = strSQL & "SELECT"
                        strSQL = strSQL & "  * "
                        strSQL = strSQL & "FROM"
                        strSQL = strSQL & "  ("
                        strSQL = strSQL & "   SELECT"
                        strSQL = strSQL & "     A.*"
                        strSQL = strSQL & "   FROM"
                        strSQL = strSQL & "     ODNTRA A"
                        strSQL = strSQL & "   , ("
                        strSQL = strSQL & "      SELECT"
                        strSQL = strSQL & "        B2.*"
                        strSQL = strSQL & "      FROM"
                        strSQL = strSQL & "        JDNTHA B1"
                        strSQL = strSQL & "      , JDNTRA B2"
                        strSQL = strSQL & "      WHERE"
                        strSQL = strSQL & "        B1.DATNO = B2.DATNO"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
                        strSQL = strSQL & "                                 SELECT"
                        strSQL = strSQL & "                                   MAX(DATNO) DATNO"
                        strSQL = strSQL & "                                 , LINNO      LINNO"
                        strSQL = strSQL & "                                 FROM"
                        strSQL = strSQL & "                                   JDNTRA"
                        strSQL = strSQL & "                                 WHERE"
                        strSQL = strSQL & "                                   JDNNO " & mJDNNO
                        strSQL = strSQL & "                                 GROUP BY"
                        strSQL = strSQL & "                                   JDNNO"
                        strSQL = strSQL & "                                 , LINNO"
                        strSQL = strSQL & "                                )"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B2.OTPSU > B2.URISU"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
                        strSQL = strSQL & "      AND"
            ' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
            '            strSQL = strSQL & "        B1.FRNKB = '0'"
                        strSQL = strSQL & "       (B1.FRNKB = '0'"
                        strSQL = strSQL & "        OR ("
                        strSQL = strSQL & "                  B1.FRNKB   = '1' "
                        strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
                        strSQL = strSQL & "           )"
                        strSQL = strSQL & "       )"
            ' === 20110305 === UPDATE E TOM)Morimoto
                        strSQL = strSQL & "     ) B "
                        strSQL = strSQL & "   WHERE"
                        strSQL = strSQL & "     A.JDNNO = B.JDNNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DATKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DENKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.OTPSU > 0"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO " & mJDNNO
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid$(WL_Key, 3, 21) & "' "
                        strSQL = strSQL & "  ) "
                        strSQL = strSQL & "ORDER BY"
                        strSQL = strSQL & "  DATKB "
                        strSQL = strSQL & ", DENKB "
                        strSQL = strSQL & ", JDNNO "
                        strSQL = strSQL & ", JDNLINNO "
                        strSQL = strSQL & ", ODNDT "

                    ' 受注取区 + 客先注文番号
                    ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then
                        strSQL = ""
                        strSQL = strSQL & "SELECT"
                        strSQL = strSQL & "  * "
                        strSQL = strSQL & "FROM"
                        strSQL = strSQL & "  ("
                        strSQL = strSQL & "   SELECT"
                        strSQL = strSQL & "     A.*"
                        strSQL = strSQL & "   FROM"
                        strSQL = strSQL & "     ODNTRA A"
                        strSQL = strSQL & "   , ("
                        strSQL = strSQL & "      SELECT"
                        strSQL = strSQL & "        B2.*"
                        strSQL = strSQL & "      FROM"
                        strSQL = strSQL & "        JDNTHA B1"
                        strSQL = strSQL & "      , JDNTRA B2"
                        strSQL = strSQL & "      WHERE"
                        strSQL = strSQL & "        B1.DATNO = B2.DATNO"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
                        strSQL = strSQL & "                                 SELECT"
                        strSQL = strSQL & "                                   MAX(DATNO) DATNO"
                        strSQL = strSQL & "                                 , LINNO      LINNO"
                        strSQL = strSQL & "                                 FROM"
                        strSQL = strSQL & "                                   JDNTRA"
                        strSQL = strSQL & "                                 GROUP BY"
                        strSQL = strSQL & "                                   JDNNO"
                        strSQL = strSQL & "                                 , LINNO"
                        strSQL = strSQL & "                                )"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B2.OTPSU > B2.URISU"
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
                        strSQL = strSQL & "      AND"
            ' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
            '            strSQL = strSQL & "        B1.FRNKB = '0'"
                        strSQL = strSQL & "       (B1.FRNKB = '0'"
                        strSQL = strSQL & "        OR ("
                        strSQL = strSQL & "                  B1.FRNKB   = '1' "
                        strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
                        strSQL = strSQL & "           )"
                        strSQL = strSQL & "       )"
            ' === 20110305 === UPDATE E TOM)Morimoto
                        strSQL = strSQL & "      AND"
                        strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
                        strSQL = strSQL & "     ) B "
                        strSQL = strSQL & "   WHERE"
                        strSQL = strSQL & "     A.JDNNO = B.JDNNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DATKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.DENKB = '1'"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.OTPSU > 0"
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
                        strSQL = strSQL & "   AND"
                        strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid$(WL_Key, 3, 21) & "' "
                        strSQL = strSQL & "  ) "
                        strSQL = strSQL & "ORDER BY"
                        strSQL = strSQL & "  DATKB "
                        strSQL = strSQL & ", DENKB "
                        strSQL = strSQL & ", JDNNO "
                        strSQL = strSQL & ", JDNLINNO "
                        strSQL = strSQL & ", ODNDT "
                    End If

                    Call DB_GetSQL2(DBN_ODNTRA, strSQL)
                End If
'20090115 CHG END   RISE)Tanimura
'20080702 CHG END FKS)NAKATA

''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
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
    Dim strSQL As String
    
    If WM_WLS_Dspflg = False Then Exit Sub
    
    LST.Clear
    LST1.Clear
        
'2008/07/05 ADD START FKS)NAKATA
'XX 配列の初期化
    If WM_WLS_LIST_END = False Then
        ReDim Preserve WK_LSTBOX_BEF(0)
    End If
'2008/07/05 ADD E.N.D FKS)NAKATA
    
    
'2008/07/03 CHG START FKS)NAKATA
'XX 入力必須条件が「受注取区+客先注文番号」「受注番号」になったため変更
'XX    If Trim$(WLSJDNTRKB) <> "" Then
       If (Trim$(WLSJDNTRKB) <> "" And Trim$(HD_TOKJDNNO.Text) <> "") Or Trim$(HD_TEXT.Text) <> "" Then
'2008/07/03 CHG E.N.D FKS)NAKATA
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
'''                        strSQL = ""
'''                        strSQL = strSQL & " SELECT * FROM ( "
'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
                        Call WLS_BaseSQL(WL_Key)
'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    End If
                ElseIf WL_Mode = SSS_NPSN Then
                    WL_Key = WLSSSS_NPSN()
                    If LenWid(WL_Key) = 0 Then
                        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    Else
'''                        strSQL = ""
'''                        strSQL = strSQL & " SELECT * FROM ( "
'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
                        Call WLS_BaseSQL(WL_Key)
'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    End If
                End If
                         
            Loop
            If LST.ListCount > 0 Then
'                LST.SetFocus
                LST.ListIndex = 0
            End If
        End If
        
        If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
            If (LeftWid$(KEYBAK.List(WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
                KEYBAK.AddItem HighValue(1)
                WM_WLS_LIST_END = True
            End If
'2008/07/05 ADD START FKS)NAKATA
        'Else
        'XX 画面表示記録用配列の初期化
        '    ReDim WK_LSTBOX_BEF(0)
'2008/07/05 ADD E.N.D FKS)NAKATA
        End If
    End If
    
    If LST.ListCount <= 0 Then
        MsgBox "      該当するデータが存在しません。"
        WM_WLS_Dspflg = False
        Call UDNTRA_RClear
'20090115 ADD START RISE)Tanimura '連絡票No.523
        Call ODNTRA_RClear
'20090115 ADD END   RISE)Tanimura
        Call JDNTRA_RClear
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
    Dim strSQL As String
    
    WM_WLS_Dspflg = False
    WM_WLS_KeyCode = 2
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    ''98/09/25 削除
    ''WM_WLS_KeyNo = WM_WLS_TextKey
    W_Key = "1" & "1" & HD_TEXT.Text
    Call UDNTRA_RClear
'20090115 ADD START RISE)Tanimura '連絡票No.523
    Call ODNTRA_RClear
'20090115 ADD END   RISE)Tanimura
    If SSSVal(WLSJDNTRKB) <> 0 Then
'''        strSQL = ""
'''        strSQL = strSQL & " SELECT * FROM ( "
'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        Call WLS_BaseSQL(W_Key)
        If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP
        End If
    Else
        Call P_SetFocus(WLSJDNTRKB)
    End If
End Sub

Private Sub WLSSSS_FORM_INIT()
    Dim I As Integer

    WM_WLS_KeyCode = False
'''''    WM_WLS_MAX = LST.Height \ 225
'''''    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    WM_WLS_MAX = CInt((LST.Height - 15) / 200)
    
    'HD_TEXT.Height = 285
'''''    HD_TEXT.MaxLength = WM_WLS_LEN
'''''    HD_TEXT.Width = (WM_WLS_LEN + 1) * 100
    WM_WLS_STTKEY = "1" & "1"
'    WM_WLS_ENDKEY = "9"
    WM_WLS_ENDKEY = "1" & "9"

'''''    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
'''''    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
'''''        HD_TEXT.Text = ""
'''''    End If
    ''98/09/25 追加
    WM_WLS_KeyNo = WM_WLS_TextKey
    
    WLSJDNTRKB.Text = ""
    HD_TOKJDNNO.Text = ""
    WLSNHSCD.Text = ""
    WLSTOKCD.Text = ""
    HD_TEXT.Text = ""

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' デフォルトは売上済
    WLSURIKB.Text = "1"
'20090115 ADD END   RISE)Tanimura

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
    Dim strSQL As String


    WLSSSS_SET_KEYBAK = True

        
    LST.Clear
    LST1.Clear
        
    Do While DBSTAT = 0
        WL_Mode = WLSSSS_DSP_CHECK()
        If WL_Mode = SSS_OK Then
            WL_Mode = WLS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
'20090115 ADD START RISE)Tanimura '連絡票No.523
                ' 売上済の場合
                If g_strURIKB = "1" Then
'20090115 ADD END   RISE)Tanimura
                KEYBAK.AddItem DB_UDNTRA.DATKB & DB_UDNTRA.AKAKROKB & DB_UDNTRA.JDNNO & DB_UDNTRA.JDNLINNO & DB_UDNTRA.UDNDT
'20090115 ADD START RISE)Tanimura '連絡票No.523
                ' 未売上の場合
                Else
                    KEYBAK.AddItem DB_ODNTRA.DATKB & DB_ODNTRA.DENKB & DB_ODNTRA.JDNNO & DB_ODNTRA.JDNLINNO & DB_ODNTRA.ODNDT
                End If
'20090115 ADD END   RISE)Tanimura
            End If
        End If
        If WL_Mode = SSS_NEXT Then
            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        ElseIf WL_Mode = SSS_RPSN Then
            WL_Key = WLSSSS_RPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
'''                strSQL = ""
'''                strSQL = strSQL & " SELECT * FROM ( "
'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                Call WLS_BaseSQL(WL_Key)
            End If
        ElseIf WL_Mode = SSS_NPSN Then
            WL_Key = WLSSSS_NPSN()
            If LenWid(WL_Key) = 0 Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            Else
'''                strSQL = ""
'''                strSQL = strSQL & " SELECT * FROM ( "
'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
                Call WLS_BaseSQL(WL_Key)
'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
            End If
        Else
            Exit Do
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then
        WLSSSS_SET_KEYBAK = False
    End If
End Function

Private Sub P_SetFocus(ByRef objCtl As Control)

On Error Resume Next
    objCtl.SetFocus
    
End Sub

Private Function LeftWid2$(ByVal pm_Characters$, ByVal pm_Wid As Long)

Dim lngMoji     As Long
Dim lngKeta     As Long

    lngMoji = 0
    lngKeta = 0
    LeftWid2$ = ""
    
    If AnsiLenB(pm_Characters$) <= pm_Wid Then
        LeftWid2$ = pm_Characters$ + Space(pm_Wid - AnsiLenB(pm_Characters$))
        Exit Function
    End If
    
    If AnsiLenB(pm_Characters$) > pm_Wid Then
    
        Do Until lngKeta >= pm_Wid
            lngMoji = lngMoji + 1
            lngKeta = lngKeta + LenB(StrConv(Mid(pm_Characters$, lngMoji, 1), vbFromUnicode))
        Loop
    
        If lngKeta > pm_Wid Then
            LeftWid2$ = Left(pm_Characters$, lngMoji - 1) & Space(1)
        Else
            LeftWid2$ = Left(pm_Characters$, lngMoji)
        End If
    End If
    
End Function


Private Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

Private Function AnsiLenB(ByVal StrArg As String) As Long
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
Private Function AnsiStrConv(StrArg, flag)
#If Win32 Then
    AnsiStrConv = StrConv(StrArg, flag)
#Else
    AnsiStrConv = StrArg
#End If

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


Private Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Long) As String

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


Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
Dim strSQL As String
Dim wkTOKCD As String
Dim wkTANCD As String
Dim strSQLWhere As String
Dim strSQLWhereB As String

'2008/07/03 ADD START FKS)NAKATA
'XX あいまい検索用変数
Dim wkJDNNO As String           '受注番号
Dim wkTOKJDNNO As String        '客先注文番号

Dim wkKEYBAK As String
'2008/07/03 ADD START FKS)NAKATA

    
    'XX 最終ページフラグの初期化
    WM_WLS_LIST_END = False
    WM_WLS_PAGE_CLICK_NUM = 0


'2008/07/03 ADD START FKS)NAKATA
    'XX 必須項目が入力されていない場合、メッセージを表示させる。
    If (Trim(WLSJDNTRKB.Text) = "" Or Trim(HD_TOKJDNNO.Text) = "") And Trim(HD_TEXT.Text) = "" Then
        MsgBox "[受注取区＋客先注文番号」または「受注番号」を入力して下さい。"
        Exit Sub
    End If
    

    'XX 受注番号を検索用文字に変更する。
    If Len(Trim(HD_TEXT.Text)) >= 6 Then
            'XX 受注番号が６桁入力されている場合、「 = JDNNO」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkJDNNO = " = '" + Trim(HD_TEXT.Text) + "'"
            wkJDNNO = " = '" + AE_EditSQLText(Trim(HD_TEXT.Text)) + "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    ElseIf Len(Trim(HD_TEXT.Text)) > 0 And Len(Trim(HD_TEXT.Text)) < 6 Then
            'XX 受注番号が６桁以下の場合、「 LIKE JDNNO%」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkJDNNO = " LIKE '" + Trim(HD_TEXT.Text) + "%'"
            wkJDNNO = " LIKE '" + AE_EditSQLText(Trim(HD_TEXT.Text)) + "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
        
        
    'XX 客先注文番号を検索用文字に変更する。番号に規則がないため語尾に「％」を付ける。
    If Trim(HD_TOKJDNNO.Text) <> "" Then
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkTOKJDNNO = " LIKE '" + Trim(HD_TOKJDNNO.Text) + "%'"
            wkTOKJDNNO = " LIKE '" + AE_EditSQLText(Trim(HD_TOKJDNNO.Text)) + "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
    
'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 売上状態を退避する
    g_strURIKB = WLSURIKB.Text
'20090115 ADD END   RISE)Tanimura

    'XX 件数取得
    If SerchCount(wkJDNNO, wkTOKJDNNO) <> True Then
        Exit Sub
    End If

    
'    If WM_WLS_Pagecnt > -1 Then
'
'    'XX 「↑」ボタンが押された場合
'    wkKEYBAK = KEYBAK.List(WM_WLS_Pagecnt)
'    wkJDNNO = Mid$(wkKEYBAK, 3, 8)
'    wkUDNDT = Right$(wkKEYBAK, 8)
'
'
'         strSQL = ""
'        strSQL = strSQL & " SELECT * "
'        strSQL = strSQL & " FROM "
'        strSQL = strSQL & "   (SELECT UDNTRA.*  "
'        strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
'        strSQL = strSQL & "      (SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
'        strSQL = strSQL & "        FROM UDNTHA "
'        strSQL = strSQL & "        WHERE DENKB = '1' "
'        strSQL = strSQL & "          AND JDNNO >= '" & wkJDNNO & "'"
'        strSQL = strSQL & "          AND UDNDT >= '" & wkUDNDT & "'"
'        strSQL = strSQL & "        GROUP BY UDNNO ) B"
'        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'        strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
'        strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
'        strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
'        strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
'        strSQL = strSQL & "   AND UDNTRA.JDNNO  >= '" & wkJDNNO & "'"
'        strSQL = strSQL & " ) "
'        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'
    
'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 売上済の場合
    If g_strURIKB = "1" Then
        '=== ＬＡＢＥＬ設定 ===
        WLSLABEL = "受注番号 売上日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"

        WM_WLS_MFIL = DBN_UDNTRA
'20090115 ADD END   RISE)Tanimura
    'XX 「受注番号」が入力されている場合、以下の処理にて検索する。
    If Trim(HD_TEXT.Text) <> "" Then
                
            'XX 必須項目が受注番号の場合
            strSQL = ""
            strSQL = strSQL & " SELECT * "
            strSQL = strSQL & " FROM "
            strSQL = strSQL & "   (SELECT UDNTRA.*  "
            strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
            strSQL = strSQL & "      (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
            strSQL = strSQL & "        FROM UDNTHA "
            strSQL = strSQL & "        WHERE DENKB = '1' "
            strSQL = strSQL & "          AND JDNNO " & wkJDNNO
            strSQL = strSQL & "        GROUP BY UDNNO ) B"
'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
            strSQL = strSQL & "     ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
            strSQL = strSQL & "        FROM  UDNTRA "
            strSQL = strSQL & "        WHERE DENKB = '1' "
            strSQL = strSQL & "          AND DATKB = '1' "
            strSQL = strSQL & "          AND AKAKROKB = '1' "
            strSQL = strSQL & "          AND JDNNO " & wkJDNNO
            strSQL = strSQL & "        GROUP BY RECNO ) C"
'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
            strSQL = strSQL & "   AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
            strSQL = strSQL & "   AND UDNTRA.RECNO = C.RECNO "
'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
            strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
            strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
            strSQL = strSQL & "   AND UDNTRA.JDNNO  " & wkJDNNO
            strSQL = strSQL & " ) "
            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
        
    'XX 「受注取区 + 客先注文番号」が入力されている場合
    ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then
        
            strSQL = ""
            strSQL = strSQL & " SELECT * "
            strSQL = strSQL & " FROM (SELECT UDNTRA. * "
            strSQL = strSQL & "         FROM UDNTRA , "
            strSQL = strSQL & "         UDNTHA ,"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
'            strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) DT "
'            strSQL = strSQL & "             FROM    UDNTRA "
'            strSQL = strSQL & "             WHERE   TOKJDNNO " & wkTOKJDNNO
'            strSQL = strSQL & "             AND     AKAKROKB = '1' "
'            strSQL = strSQL & "             AND     DATKB = '1' "
'            strSQL = strSQL & "             GROUP BY UDNNO "
'            strSQL = strSQL & "         ) B "
            strSQL = strSQL & "         (SELECT   RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
            strSQL = strSQL & "             FROM  UDNTRA "
            strSQL = strSQL & "             WHERE DENKB = '1' "
            strSQL = strSQL & "             AND   DATKB = '1' "
            strSQL = strSQL & "             AND   AKAKROKB = '1' "
            strSQL = strSQL & "             AND   TOKJDNNO " & wkTOKJDNNO
            strSQL = strSQL & "             GROUP BY RECNO "
            strSQL = strSQL & "         ) B "
'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
            strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO "
            strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT "
'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
'            strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO "
            strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
            strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
            strSQL = strSQL & "     AND UDNTHA.DENKB = '1' ) "
            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO , UDNDT "
            
    End If
    
'2008/07/03 ADD E.N.D FKS)NAKATA
'2008/07/03 DEL START FKS)NAKATA
'XX    strSQL = ""
'XX    strSQL = strSQL & " SELECT * FROM ( "
'XX    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
'XX    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
'XX    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
'XX''    strSQL = strSQL & "    AND UDNTHA.URIKJN <> '02'"       '検収基準売上は返品不可 2007.08.23 ADD
'XX    strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
'XX    strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
'XX    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & strKeyBak & "')"
'XX    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
'2008/07/03 DEL E.N.D FKS)NAKATA


    Call DB_GetSQL2(DBN_UDNTRA, strSQL)

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 未売上の場合
    Else
        '=== ＬＡＢＥＬ設定 ===
        WLSLABEL = "受注番号 出荷日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"

        WM_WLS_MFIL = DBN_ODNTRA

        ' 受注番号から検索
        If Trim(HD_TEXT.Text) <> "" Then
            strSQL = ""
            strSQL = strSQL & "SELECT"
            strSQL = strSQL & "  * "
            strSQL = strSQL & "FROM"
            strSQL = strSQL & "  ("
            strSQL = strSQL & "   SELECT"
            strSQL = strSQL & "     A.*"
            strSQL = strSQL & "   FROM"
            strSQL = strSQL & "     ODNTRA A"
            strSQL = strSQL & "   , ("
            strSQL = strSQL & "      SELECT"
            strSQL = strSQL & "        B2.*"
            strSQL = strSQL & "      FROM"
            strSQL = strSQL & "        JDNTHA B1"
            strSQL = strSQL & "      , JDNTRA B2"
            strSQL = strSQL & "      WHERE"
            strSQL = strSQL & "        B1.DATNO = B2.DATNO"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
            strSQL = strSQL & "                                 SELECT"
            strSQL = strSQL & "                                   MAX(DATNO) DATNO"
            strSQL = strSQL & "                                 , LINNO      LINNO"
            strSQL = strSQL & "                                 FROM"
            strSQL = strSQL & "                                   JDNTRA"
            strSQL = strSQL & "                                 WHERE"
            strSQL = strSQL & "                                   JDNNO " & wkJDNNO
            strSQL = strSQL & "                                 GROUP BY"
            strSQL = strSQL & "                                   JDNNO"
            strSQL = strSQL & "                                 , LINNO"
            strSQL = strSQL & "                                )"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B2.OTPSU > B2.URISU"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
            strSQL = strSQL & "      AND"
' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
'            strSQL = strSQL & "        B1.FRNKB = '0'"
            strSQL = strSQL & "       (B1.FRNKB = '0'"
            strSQL = strSQL & "        OR ("
            strSQL = strSQL & "                  B1.FRNKB   = '1' "
            strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
            strSQL = strSQL & "           )"
            strSQL = strSQL & "       )"
' === 20110305 === UPDATE E TOM)Morimoto
            strSQL = strSQL & "     ) B "
            strSQL = strSQL & "   WHERE"
            strSQL = strSQL & "     A.JDNNO = B.JDNNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DATKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DENKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.OTPSU > 0"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNNO " & wkJDNNO
            strSQL = strSQL & "  ) "
            strSQL = strSQL & "ORDER BY"
            strSQL = strSQL & "  DATKB "
            strSQL = strSQL & ", DENKB "
            strSQL = strSQL & ", JDNNO "
            strSQL = strSQL & ", JDNLINNO "
            strSQL = strSQL & ", ODNDT "

        ' 受注取区 + 客先注文番号
        ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then
            strSQL = ""
            strSQL = strSQL & "SELECT"
            strSQL = strSQL & "  * "
            strSQL = strSQL & "FROM"
            strSQL = strSQL & "  ("
            strSQL = strSQL & "   SELECT"
            strSQL = strSQL & "     A.*"
            strSQL = strSQL & "   FROM"
            strSQL = strSQL & "     ODNTRA A"
            strSQL = strSQL & "   , ("
            strSQL = strSQL & "      SELECT"
            strSQL = strSQL & "        B2.*"
            strSQL = strSQL & "      FROM"
            strSQL = strSQL & "        JDNTHA B1"
            strSQL = strSQL & "      , JDNTRA B2"
            strSQL = strSQL & "      WHERE"
            strSQL = strSQL & "        B1.DATNO = B2.DATNO"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
            strSQL = strSQL & "                                 SELECT"
            strSQL = strSQL & "                                   MAX(DATNO) DATNO"
            strSQL = strSQL & "                                 , LINNO      LINNO"
            strSQL = strSQL & "                                 FROM"
            strSQL = strSQL & "                                   JDNTRA"
            strSQL = strSQL & "                                 GROUP BY"
            strSQL = strSQL & "                                   JDNNO"
            strSQL = strSQL & "                                 , LINNO"
            strSQL = strSQL & "                                )"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B2.OTPSU > B2.URISU"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
            strSQL = strSQL & "      AND"
' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
'            strSQL = strSQL & "        B1.FRNKB = '0'"
            strSQL = strSQL & "       (B1.FRNKB = '0'"
            strSQL = strSQL & "        OR ("
            strSQL = strSQL & "                  B1.FRNKB   = '1' "
            strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
            strSQL = strSQL & "           )"
            strSQL = strSQL & "       )"
' === 20110305 === UPDATE E TOM)Morimoto
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
            strSQL = strSQL & "     ) B "
            strSQL = strSQL & "   WHERE"
            strSQL = strSQL & "     A.JDNNO = B.JDNNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DATKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DENKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.OTPSU > 0"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
            strSQL = strSQL & "  ) "
            strSQL = strSQL & "ORDER BY"
            strSQL = strSQL & "  DATKB "
            strSQL = strSQL & ", DENKB "
            strSQL = strSQL & ", JDNNO "
            strSQL = strSQL & ", JDNLINNO "
            strSQL = strSQL & ", ODNDT "
        End If

        Call DB_GetSQL2(DBN_ODNTRA, strSQL)
    End If
'20090115 ADD END   RISE)Tanimura

End Sub

'2008/07/04/ ADD START FKS)NAKATA
Private Function SerchCount(wkJDNNO, wkTOKJDNNO) As Boolean
'XX
'XX 検索件数取得ファンクション (戻り値：True / False)
'XX


Dim strSQL As String
Dim strMSG As String            '検索件数表示用

Dim wkCNT  As Double
Dim wkPAGE As Double
Dim wkLIST As Double
Dim I As Integer



'2008/07/05 ADD START FKS)NAKATA
Dim wkTOKCD As String
Dim wkNHSCD As String
Dim wkUDNDT As String
    

    'XX 得意先を検索用文字に変更する。
    If Len(Trim(WLSTOKCD.Text)) >= 5 Then
            'XX 得意先が４桁入力されている場合、「 = TOKCD」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkTOKCD = " = '" + Trim(WLSTOKCD.Text) + "'"
            wkTOKCD = " = '" + AE_EditSQLText(Trim(WLSTOKCD.Text)) + "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    ElseIf Len(Trim(WLSTOKCD.Text)) > 0 And Len(Trim(WLSTOKCD.Text)) < 5 Then
            'XX 得意先が４桁以下の場合、「 LIKE TOKCD%」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkTOKCD = " LIKE '" + Trim(WLSTOKCD.Text) + "%'"
            wkTOKCD = " LIKE '" + AE_EditSQLText(Trim(WLSTOKCD.Text)) + "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
    
    
    'XX 納入先を検索用文字に変更する。
If Len(Trim(WLSNHSCD.Text)) >= 9 Then
            'XX 納入先が９桁入力されている場合、「 = wkNHSCD」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkNHSCD = " = '" + Trim(WLSNHSCD.Text) + "'"
            wkNHSCD = " = '" + AE_EditSQLText(Trim(WLSNHSCD.Text)) + "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    ElseIf Len(Trim(WLSNHSCD.Text)) > 0 And Len(Trim(WLSNHSCD.Text)) < 9 Then
            'XX 納入先が９桁以下の場合、「 LIKE TOKCD%」の形にする
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'            wkNHSCD = " LIKE '" + Trim(WLSNHSCD.Text) + "%'"
            wkNHSCD = " LIKE '" + AE_EditSQLText(Trim(WLSNHSCD.Text)) + "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
    End If
    
    
    'XX 売上日を「yyyy/mm/dd」から「yyyymmdd」に変更する。
    wkUDNDT = WLSUDNDT.Text
    wkUDNDT = Left$(wkUDNDT, 4) + Mid$(wkUDNDT, 6, 2) + Right$(wkUDNDT, 2)

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 検索条件を退避しておく
    mJDNTRKB = WLSJDNTRKB.Text      ' 受注取区
    mJDNNO = wkJDNNO                ' 受注番号
    mTOKJDNNO = wkTOKJDNNO          ' 客先注文番号
'20090115 ADD END   RISE)Tanimura

'2008/07/05 ADD E.N.D FKS)NAKATA
        
    SerchCount = True

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 売上済の場合
    If g_strURIKB = "1" Then
'20090115 ADD END   RISE)Tanimura
    If Trim(wkJDNNO) <> "" Then

        'XX 受注番号から検索
        strSQL = ""
'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
'        strSQL = strSQL & " FROM JDNTRA"
'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN"
'        strSQL = strSQL & " ("
'        strSQL = strSQL & "  SELECT TRIM(JDNNO) || TRIM(JDNLINNO) "
        strSQL = strSQL & "  SELECT COUNT(DATNO) "
        strSQL = strSQL & "  FROM "
        strSQL = strSQL & "    (SELECT UDNTRA.*  "
        strSQL = strSQL & "     FROM UDNTRA ,UDNTHA , "
        strSQL = strSQL & "       (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
        strSQL = strSQL & "         FROM UDNTHA "
        strSQL = strSQL & "         WHERE DENKB = '1' "
        strSQL = strSQL & "           AND JDNNO " & wkJDNNO
    If wkUDNDT <> "" Then
        strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
    End If
    If wkTOKCD <> "" Then
        strSQL = strSQL & "           AND TOKCD " & wkTOKCD
    End If
    If wkNHSCD <> "" Then
        strSQL = strSQL & "           AND NHSCD " & wkNHSCD
    End If
        strSQL = strSQL & "         GROUP BY UDNNO ) B"
'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
        strSQL = strSQL & "      ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
        strSQL = strSQL & "         FROM  UDNTRA "
        strSQL = strSQL & "         WHERE DENKB = '1' "
        strSQL = strSQL & "           AND DATKB = '1' "
        strSQL = strSQL & "           AND AKAKROKB = '1' "
        strSQL = strSQL & "           AND JDNNO " & wkJDNNO
    If wkUDNDT <> "" Then
        strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
    End If
    If wkTOKCD <> "" Then
        strSQL = strSQL & "           AND TOKCD " & wkTOKCD
    End If
    If wkNHSCD <> "" Then
        strSQL = strSQL & "           AND NHSCD " & wkNHSCD
    End If
        strSQL = strSQL & "         GROUP BY RECNO ) C"
'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
        strSQL = strSQL & "   WHERE UDNTRA.DATNO = UDNTHA.DATNO "
        strSQL = strSQL & "    AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
        strSQL = strSQL & "    AND UDNTHA.UDNNO = B.UDNNO "
'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
        strSQL = strSQL & "    AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
        strSQL = strSQL & "    AND UDNTRA.RECNO = C.RECNO "
'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
        strSQL = strSQL & "    AND UDNTRA.DATKB = '1' "
        strSQL = strSQL & "    AND UDNTRA.AKAKROKB = '1' "
        strSQL = strSQL & "    AND UDNTRA.JDNNO  " & wkJDNNO
        strSQL = strSQL & "   ) "
'        strSQL = strSQL & " ) "
        
    ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then

        'XX 受注取区 + 客先注文番号
        strSQL = ""
'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
'        strSQL = strSQL & " FROM JDNTRA"
'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN (SELECT TRIM(JDNNO) || TRIM(JDNLINNO)"
        strSQL = strSQL & "  SELECT COUNT(DATNO) "
        strSQL = strSQL & " FROM (SELECT UDNTRA. *"
        strSQL = strSQL & "     FROM UDNTRA ,"
        strSQL = strSQL & "         UDNTHA ,"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
'        strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO"
        strSQL = strSQL & "         (SELECT RECNO"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
        strSQL = strSQL & "             ,MAX(WRTFSTDT || WRTFSTTM) DT"
        strSQL = strSQL & "         FROM UDNTRA"
        strSQL = strSQL & "         WHERE TOKJDNNO" & wkTOKJDNNO
    If wkUDNDT <> "" Then
        strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
    End If
    If wkTOKCD <> "" Then
        strSQL = strSQL & "           AND TOKCD " & wkTOKCD
    End If
    If wkNHSCD <> "" Then
        strSQL = strSQL & "           AND NHSCD " & wkNHSCD
    End If
        strSQL = strSQL & "         AND AKAKROKB = '1'"
        strSQL = strSQL & "         AND DATKB = '1'"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
'        strSQL = strSQL & "         GROUP BY UDNNO) B"
        strSQL = strSQL & "         GROUP BY RECNO) B"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
        strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO"
        strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT"
'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
'        strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO"
        strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
        strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
        strSQL = strSQL & "     AND UDNTHA.DENKB = '1')"
 '       strSQL = strSQL & " )"
 End If

'20090115 ADD START RISE)Tanimura '連絡票No.523
    ' 未売上の場合
    Else
        ' 受注番号から検索
        If Trim(wkJDNNO) <> "" Then
            strSQL = ""
            strSQL = strSQL & "SELECT"
            strSQL = strSQL & "  COUNT(DATNO) "
            strSQL = strSQL & "FROM"
            strSQL = strSQL & "  ("
            strSQL = strSQL & "   SELECT"
            strSQL = strSQL & "     A.*"
            strSQL = strSQL & "   FROM"
            strSQL = strSQL & "     ODNTRA A"
            strSQL = strSQL & "   , ("
            strSQL = strSQL & "      SELECT"
            strSQL = strSQL & "        B2.*"
            strSQL = strSQL & "      FROM"
            strSQL = strSQL & "        JDNTHA B1"
            strSQL = strSQL & "      , JDNTRA B2"
            strSQL = strSQL & "      WHERE"
            strSQL = strSQL & "        B1.DATNO = B2.DATNO"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
            strSQL = strSQL & "                                 SELECT"
            strSQL = strSQL & "                                   MAX(DATNO) DATNO"
            strSQL = strSQL & "                                 , LINNO      LINNO"
            strSQL = strSQL & "                                 FROM"
            strSQL = strSQL & "                                   JDNTRA"
            strSQL = strSQL & "                                 WHERE"
            strSQL = strSQL & "                                   JDNNO " & wkJDNNO
            strSQL = strSQL & "                                 GROUP BY"
            strSQL = strSQL & "                                   JDNNO"
            strSQL = strSQL & "                                 , LINNO"
            strSQL = strSQL & "                                )"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B2.OTPSU > B2.URISU"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
            strSQL = strSQL & "      AND"
' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
'            strSQL = strSQL & "        B1.FRNKB = '0'"
            strSQL = strSQL & "       (B1.FRNKB = '0'"
            strSQL = strSQL & "        OR ("
            strSQL = strSQL & "                  B1.FRNKB   = '1' "
            strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
            strSQL = strSQL & "           )"
            strSQL = strSQL & "       )"
' === 20110305 === UPDATE E TOM)Morimoto
            strSQL = strSQL & "     ) B "
            strSQL = strSQL & "   WHERE"
            strSQL = strSQL & "     A.JDNNO = B.JDNNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DATKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DENKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.OTPSU > 0"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNNO " & wkJDNNO
            If wkTOKCD <> "" Then
                strSQL = strSQL & "   AND"
                strSQL = strSQL & "     A.TOKCD " & wkTOKCD
            End If
            If wkNHSCD <> "" Then
                strSQL = strSQL & "   AND"
                strSQL = strSQL & "     A.NHSCD " & wkNHSCD
            End If
            strSQL = strSQL & "  ) "

        ' 受注取区 + 客先注文番号
        ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then
            strSQL = ""
            strSQL = strSQL & "SELECT"
            strSQL = strSQL & "  COUNT(DATNO) "
            strSQL = strSQL & "FROM"
            strSQL = strSQL & "  ("
            strSQL = strSQL & "   SELECT"
            strSQL = strSQL & "     A.*"
            strSQL = strSQL & "   FROM"
            strSQL = strSQL & "     ODNTRA A"
            strSQL = strSQL & "   , ("
            strSQL = strSQL & "      SELECT"
            strSQL = strSQL & "        B2.*"
            strSQL = strSQL & "      FROM"
            strSQL = strSQL & "        JDNTHA B1"
            strSQL = strSQL & "      , JDNTRA B2"
            strSQL = strSQL & "      WHERE"
            strSQL = strSQL & "        B1.DATNO = B2.DATNO"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
            strSQL = strSQL & "                                 SELECT"
            strSQL = strSQL & "                                   MAX(DATNO) DATNO"
            strSQL = strSQL & "                                 , LINNO      LINNO"
            strSQL = strSQL & "                                 FROM"
            strSQL = strSQL & "                                   JDNTRA"
            strSQL = strSQL & "                                 GROUP BY"
            strSQL = strSQL & "                                   JDNNO"
            strSQL = strSQL & "                                 , LINNO"
            strSQL = strSQL & "                                )"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B2.OTPSU > B2.URISU"
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
            strSQL = strSQL & "      AND"
' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
'            strSQL = strSQL & "        B1.FRNKB = '0'"
            strSQL = strSQL & "       (B1.FRNKB = '0'"
            strSQL = strSQL & "        OR ("
            strSQL = strSQL & "                  B1.FRNKB   = '1' "
            strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
            strSQL = strSQL & "           )"
            strSQL = strSQL & "       )"
' === 20110305 === UPDATE E TOM)Morimoto
            strSQL = strSQL & "      AND"
            strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
            strSQL = strSQL & "     ) B "
            strSQL = strSQL & "   WHERE"
            strSQL = strSQL & "     A.JDNNO = B.JDNNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DATKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.DENKB = '1'"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.OTPSU > 0"
            strSQL = strSQL & "   AND"
            strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
            If wkTOKCD <> "" Then
                strSQL = strSQL & "   AND"
                strSQL = strSQL & "     A.TOKCD " & wkTOKCD
            End If
            If wkNHSCD <> "" Then
                strSQL = strSQL & "   AND"
                strSQL = strSQL & "     A.NHSCD " & wkNHSCD
            End If
            strSQL = strSQL & "  ) "
        End If
    End If
'20090115 ADD END   RISE)Tanimura

        Call DB_GetSQL2(DBN_JDNTHA, strSQL)

 
        'XX　検索結果が１００件以上ならメッセージを表示
    If DB_ExtNum.ExtNum(0) >= 100 Then
    
        strMSG = strMSG & "検索件数：" & DB_ExtNum.ExtNum(0) & "件"
        
        If MsgBox(strMSG, vbOKCancel) = vbCancel Then
            SerchCount = False
            WM_WLS_Dspflg = False
            Call JDNTRA_RClear
            Exit Function
        End If
    End If

'XX 該当データがない場合、メッセージを表示させる
    If DB_ExtNum.ExtNum(0) <= 0 Then
        MsgBox "      該当するデータが存在しません。"
        SerchCount = False
        WM_WLS_Dspflg = False
        Call UDNTRA_RClear
        Exit Function
    End If
    

'XX ページ送り用に、最終ページ番号と最終リスト番号を算出する。
    
    wkCNT = DB_ExtNum.ExtNum(0)
    
    '最終ページ番号
    WM_WLS_PAGE_END = Int(wkCNT / 18) + CInt(IIf((wkCNT Mod 18) = 0, 0, 1))

    '最終リスト番号
    Do While (wkCNT > 18)
        wkCNT = wkCNT - 18
    Loop
    
    WM_WLS_LIST_CNT = wkCNT

End Function
'2008/07/04/ ADD E.N.D FKS)NAKATA

'2008/07/05 ADD START FKS)NAKATA
Private Sub CHK_ListBox()


Dim wkLSTCNT As String
Dim wkJDNNO As String
Dim wkUDNDT As String

Dim lstLSTCNT As String
Dim lstJDNNO As String
Dim lstUDNDT As String

Dim wkStr   As String

Dim I As Integer
    
            
        If LST.ListCount <> UBound(WK_LSTBOX_BEF()) Then
           
           'XX　配列の取り出し
           wkLSTCNT = Trim(WK_LSTBOX_BEF(UBound(WK_LSTBOX_BEF())).LSTNO)
           wkJDNNO = Trim(WK_LSTBOX_BEF(wkLSTCNT).JDNNO)
           wkUDNDT = Trim(WK_LSTBOX_BEF(wkLSTCNT).UDNDT)
           
           'XX ListBoxからの取り出し
           wkStr = LST.List(wkLSTCNT - 1)
           
           lstJDNNO = Left$(Trim(wkStr), 8)
           lstUDNDT = Mid$(Trim(wkStr), 10, 10)
           
           If wkJDNNO = lstJDNNO And wkUDNDT = lstUDNDT Then
           
                For I = LST.ListCount - 1 To wkLSTCNT Step -1
                    LST.RemoveItem (I)
                Next
           Else
                Exit Sub
           End If
           
        'XX ページ送りされた場合の対処
        ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then
                
                For I = LST.ListCount - 1 To WM_WLS_LIST_CNT Step -1
                    LST.RemoveItem (I)
                Next
        End If
            
End Sub
'2008/07/05 ADD START FKS)NAKATA

