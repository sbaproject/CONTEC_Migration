VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.OCX"
Begin VB.Form WLS_PRN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "帳票毎のプリンタの設定と記録"
   ClientHeight    =   3720
   ClientLeft      =   2925
   ClientTop       =   4605
   ClientWidth     =   8295
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   3720
   ScaleWidth      =   8295
   Begin VB.Frame Frame4 
      Caption         =   "標準用紙サイズと印刷の向き"
      Height          =   855
      Left            =   120
      TabIndex        =   16
      Top             =   2520
      Width           =   4455
      Begin Threed5.SSPanel5 PNL_DefSize 
         Height          =   300
         Left            =   720
         TabIndex        =   20
         Top             =   300
         Width           =   2295
         _ExtentX        =   4048
         _ExtentY        =   529
         BackColor       =   12632256
         ForeColor       =   -2147483640
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "A4"
      End
      Begin Threed5.SSPanel5 PNL_DefOrient 
         Height          =   300
         Left            =   3720
         TabIndex        =   19
         Top             =   300
         Width           =   495
         _ExtentX        =   873
         _ExtentY        =   529
         BackColor       =   12632256
         ForeColor       =   -2147483640
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "縦"
      End
      Begin VB.Label Label5 
         Caption         =   "向き"
         Height          =   255
         Left            =   3360
         TabIndex        =   18
         Top             =   360
         Width           =   375
      End
      Begin VB.Label Label4 
         Caption         =   "ｻｲｽﾞ"
         Height          =   255
         Left            =   240
         TabIndex        =   17
         Top             =   360
         Width           =   495
      End
   End
   Begin VB.ListBox LstKyusi 
      Height          =   420
      Left            =   1305
      TabIndex        =   15
      Top             =   4770
      Width           =   825
   End
   Begin VB.ListBox LstForm 
      Height          =   420
      Left            =   135
      TabIndex        =   10
      Top             =   4770
      Width           =   825
   End
   Begin VB.Frame Frame3 
      Caption         =   "印刷の向き"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1185
      Left            =   5175
      TabIndex        =   8
      Top             =   1170
      Width           =   2130
      Begin VB.OptionButton OptOrient 
         Caption         =   "横"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   1305
         TabIndex        =   12
         TabStop         =   0   'False
         Top             =   720
         Width           =   735
      End
      Begin VB.OptionButton OptOrient 
         Caption         =   "縦"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   0
         Left            =   1305
         TabIndex        =   11
         TabStop         =   0   'False
         Top             =   270
         Width           =   735
      End
      Begin VB.Image ImgOrient 
         Height          =   465
         Left            =   405
         Top             =   450
         Width           =   465
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "用紙"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1185
      Left            =   90
      TabIndex        =   6
      Top             =   1170
      Width           =   4965
      Begin VB.ComboBox CmbKyusi 
         Height          =   300
         Left            =   945
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   720
         Width           =   3840
      End
      Begin VB.ComboBox CmbForm 
         Height          =   300
         Left            =   945
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   9
         TabStop         =   0   'False
         Top             =   270
         Width           =   3840
      End
      Begin VB.Label Label3 
         Caption         =   "給紙方法"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   135
         TabIndex        =   14
         Top             =   765
         Width           =   780
      End
      Begin VB.Label Label2 
         Caption         =   "ｻｲｽﾞ"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   135
         TabIndex        =   7
         Top             =   315
         Width           =   555
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "ﾌﾟﾘﾝﾀ"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   915
      Left            =   90
      TabIndex        =   3
      Top             =   135
      Width           =   8115
      Begin VB.ComboBox CmbPrn 
         Height          =   300
         Left            =   990
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   4
         TabStop         =   0   'False
         Top             =   315
         Width           =   6090
      End
      Begin VB.CommandButton CmdProper 
         Caption         =   "ﾌﾟﾛﾊﾟﾃｨ"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   7020
         TabIndex        =   2
         Top             =   315
         Width           =   1005
      End
      Begin VB.Label Label1 
         Caption         =   "ﾌﾟﾘﾝﾀ名"
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   135
         TabIndex        =   5
         Top             =   360
         Width           =   780
      End
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   5265
      TabIndex        =   0
      Top             =   2805
      Width           =   990
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   420
      Left            =   6645
      TabIndex        =   1
      Top             =   2805
      Width           =   990
   End
   Begin VB.Image ImgLib 
      Height          =   405
      Index           =   1
      Left            =   2925
      Picture         =   "WLS_PRN.frx":0000
      Top             =   4725
      Width           =   465
   End
   Begin VB.Image ImgLib 
      Height          =   465
      Index           =   0
      Left            =   2340
      Picture         =   "WLS_PRN.frx":0A62
      Top             =   4725
      Width           =   420
   End
End
Attribute VB_Name = "WLS_PRN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim SelDM As DEVMODE
Dim SavDevice As String
Dim dspflg As Boolean


Private Sub CmbForm_Click()
    
    If dspflg Then Exit Sub
    SelDM.dmPaperSize = LstForm.List(CmbForm.ListIndex)
    SelDM.dmFormName = CmbForm.List(CmbForm.ListIndex) & Chr(0)
    WLSOK.SetFocus
End Sub

Private Sub CmbKyusi_Click()
    
    If dspflg Then Exit Sub
    SelDM.dmDefaultSource = LstKyusi.List(CmbKyusi.ListIndex)
    WLSOK.SetFocus
End Sub

Private Sub CmbPrn_Click()
    
    If dspflg Then Exit Sub
    If CmbPrn.List(CmbPrn.ListIndex) <> SavDevice Then
        Call GetDevMode(CmbPrn.List(CmbPrn.ListIndex), DM_OUT_BUFFER)
    End If
    WLSOK.SetFocus
End Sub

Private Sub CmbPrn_GotFocus()
    SavDevice = CmbPrn.List(CmbPrn.ListIndex)
End Sub

Private Sub CmdProper_Click()
    
    Call GetDevMode(CmbPrn.List(CmbPrn.ListIndex), DM_IN_BUFFER Or DM_IN_PROMPT Or DM_OUT_BUFFER)
    WLSOK.SetFocus
End Sub

Private Sub Form_Activate()
    Me.Enabled = False
    'WLSOK.Left = (WLS_PRN.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
    'WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
    DoEvents
    If GetUsePrinter(SelDM) Then
        Call DisplayPrinter
    Else
        Call GetDevMode(GetDefDevice(), DM_OUT_BUFFER)
    End If
    Me.Enabled = True
    WLSOK.SetFocus
End Sub

Private Sub Form_Load()
    Dim I%
    
    WLS_PRN.Top = (Screen.Height - WLS_PRN.Height) / 2
    WLS_PRN.Left = (Screen.Width - WLS_PRN.Width) / 2
    For I = 0 To Printers.count - 1
        CmbPrn.AddItem Printers(I).DeviceName
    Next
    'Default 用紙サイズと印刷向きを表示
    PNL_DefSize.Caption = SSS_DefPaperSizeNm
    If SSS_DefOrient = 2 Then
        PNL_DefOrient.Caption = "横"
    Else
        PNL_DefOrient.Caption = "縦"
    End If
    Call Init_Prompt
End Sub

Function GetDefDevice() As String
    Dim DEF$
    Dim di&
    Dim npos%

    DEF$ = String$(128, 0)
    di = GetProfileString("WINDOWS", "DEVICE", "", DEF$, 127)
    '#Start(2003.5.20) プリンタがインストールされていない場合のランタイムエラーを防ぐ
    If di = 0 Then
        MsgBox "このＰＣにはプリンタがインストールされていないようです。" & vbCr & "帳票プログラムの実行にはプリンタ(ドライバ)が必須です。" & vbCr & "インストールして下さい。" & vbCr & "―――――――――――――――――――――――――――――――――" & vbCr & "プリンタ(ドライバ）がない場合は、正しく実行されない可能性があります。", vbExclamation
        GetDefDevice = ""
        Exit Function
    End If
    '#End(2003.5.20)
    DEF$ = agGetStringFromLPSTR$(DEF$)
    npos% = InStr(DEF$, ",")
    '#Start(2003.5.20) プリンタ名が127バイトを超える時のランタイムエラーを防ぐ
    If npos < 1 Then
        MsgBox "プリンタ名に異常があるようです。" & vbCr & "プリンタ名の長さが127バイト以内にして下さい。", vbExclamation
        GetDefDevice = ""
        Exit Function
    End If
    '#End(2003.5.20)
    GetDefDevice = Left$(DEF$, npos% - 1)

End Function

Sub GetDevMode(ByVal dv As String, ByVal fmode As Long)
    Dim hPrinter&, res&
    Dim pdefs As PRINTER_DEFAULTS
    Dim bufsize&
    Dim dmInBuf() As Byte
    Dim dmOutBuf() As Byte
    Dim I%
    pdefs.PDATATYPE = vbNullString
    pdefs.PDEVMODE = 0
'    pdefs.DesiredAccess = PRINTER_ACCESS_ADMINISTER
    pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
    
    '#Start(2003.11.17) CR9 Unicode 対応
    Dim UniDv() As Byte
    
    UniDv = dv & Chr(0)
    ' OpenPrinterBynum の3つ目のパラメータには 0 を指定できますが、
    ' 全てのプリンタプロパティは編集できなくなります。
    'res& = OpenPrinter(dv, hPrinter, pdefs)
    res& = OpenPrinter(UniDv(0), hPrinter, pdefs)
    '#End(2003.11.17)
    
'    res& = OpenPrinterBynum(devname$, hPrinter, 0)
    If res = 0 Then Exit Sub

    '#Start(2003.11.17) CR9 Unicode 対応
    'bufsize = DocumentProperties(Me.hwnd, hPrinter, dv, 0, 0, 0)
    bufsize = DocumentProperties(Me.hwnd, hPrinter, UniDv(0), 0, 0, 0)
    '#End(2003.11.17)

    If bufsize < Len(SelDM) Then bufsize = Len(SelDM)
    ReDim dmInBuf(bufsize)
    ReDim dmOutBuf(bufsize)
    agCopyData SelDM, dmInBuf(0), Len(SelDM)

    '#Start(2003.11.17) CR9 Unicode 対応
    'res = DocumentProperties(Me.hwnd, hPrinter, dv, agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
    res = DocumentProperties(Me.hwnd, hPrinter, UniDv(0), agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
    '#End(2003.11.17)
    
    ' データバッファを DEVMODE 構造体へコピー
    Select Case res
    Case IDOK
'        For i = 0 To 2000
'            If dmInBuf(i) <> dmOutBuf(i) Then
'                MsgBox i
'                Exit For
'            End If
'        Next
        agCopyData dmOutBuf(0), SelDM, Len(SelDM)
'2000/10/19 一行追加　長いプリンタ名に対応
        SelDM.LongDeviceName = RTrim$(dv) & Chr(0)
        'デフォールト用紙サイズと印字向きが登録されている場合、それをデフォールトに
        '#Start(2002.2.27) プリンタプロパティでの指定に従うので、次の２行を外す
        'SelDM.dmOrientation = SSS_DefOrient
        'SelDM.dmPaperSize = SSS_DefPaperSize
        '#End(2002.2.27)
        Call DisplayPrinter
    Case IDCANCEL
    Case Else
        MsgBox "プリンタの情報が取得できません。", 0, "プリンタの設定"
    End Select
    ClosePrinter hPrinter
End Sub

Sub DisplayPrinter()
    Dim devname$, devoutput$
    Dim count&
    Dim names$
    Dim a$, S$
    Dim di&
    Dim I%, J%
    Dim NoBuf() As Byte
    Dim No%
    
    CmbForm.Clear
    LstForm.Clear
    CmbKyusi.Clear
    LstKyusi.Clear
    
    dspflg = True
    If (CmbPrn.ListCount > 0) And (CmbPrn.ListIndex < 0) Then CmbPrn.ListIndex = 0
'2000/10/19 １行変更　長いプリンタ名に対応
'    devname$ = agGetStringFromLPSTR$(SelDM.dmDeviceName)
    devname$ = agGetStringFromLPSTR$(SelDM.LongDeviceName)
    For I = 0 To CmbPrn.ListCount - 1
        If CmbPrn.List(I) = devname$ Then
            CmbPrn.ListIndex = I
            Exit For
        End If
    Next
    
'    devname$ = CmbPrn.List(CmbPrn.ListIndex)
'    devoutput$ = GetDeviceOutput$(dev$)
    devoutput = ""

    ' 使用可能な用紙サイズを取得します。
    count = DeviceCapabilities(devname$, devoutput$, DC_PAPERNAMES, vbNullString, 0)
    If count <= 0 Then
        MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
        Exit Sub
    End If

    ' 情報を保持できる十分な領域を確保します。
    names$ = String$(64 * count, 0)
    di = DeviceCapabilities(devname$, devoutput$, DC_PAPERNAMES, names$, 0)
    
    ' 使用可能な用紙サイズを取得します。
    count = DeviceCapabilitiesNo(devname$, devoutput$, DC_PAPERS, 0, 0)
    If count <= 0 Then
        MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
        Exit Sub
    End If

    ' 情報を保持できる十分な領域を確保します。
    ReDim NoBuf(2 * count)
    di = DeviceCapabilitiesNo(devname$, devoutput$, DC_PAPERS, agGetAddressForObject(NoBuf(0)), 0)

    ' 取得した情報を表示します。
    For I = 0 To count - 1
        No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
        LstForm.AddItem No
        a$ = MidWid(names$, I * 64 + 1, 64)
        a$ = agGetStringFromLPSTR$(a$)
        CmbForm.AddItem a$
        If No = SelDM.dmPaperSize Then
            CmbForm.ListIndex = I
        End If
    Next
    
    ' 使用可能な用紙サイズを取得します。
    count = DeviceCapabilities(devname$, devoutput$, DC_BINNAMES, vbNullString, 0)
    If count <= 0 Then
        MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
        Exit Sub
    End If

    ' 情報を保持できる十分な領域を確保します。
    names$ = String$(24 * count, 0)
    di = DeviceCapabilities(devname$, devoutput$, DC_BINNAMES, names$, 0)
    
    ' 使用可能な用紙サイズを取得します。
    count = DeviceCapabilitiesNo(devname$, devoutput$, DC_BINS, 0, 0)
    If count <= 0 Then
        MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
        Exit Sub
    End If

    ' 情報を保持できる十分な領域を確保します。
    ReDim NoBuf(2 * count)
    di = DeviceCapabilitiesNo(devname$, devoutput$, DC_BINS, agGetAddressForObject(NoBuf(0)), 0)

    ' 取得した情報を表示します。
    For I = 0 To count - 1
        No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
        LstKyusi.AddItem No
        a$ = MidWid(names$, I * 24 + 1, 24)
        a$ = agGetStringFromLPSTR$(a$)
        CmbKyusi.AddItem a$
        If No = SelDM.dmDefaultSource Then
            CmbKyusi.ListIndex = I
        End If
    Next
    
    If SelDM.dmOrientation = DMORIENT_PORTRAIT Then
        OptOrient(0) = True
        ImgOrient.Picture = ImgLib(0).Picture
    Else
        OptOrient(1) = True
        ImgOrient.Picture = ImgLib(1).Picture
    End If
    dspflg = False
End Sub


Private Sub OptOrient_Click(Index As Integer)
    If dspflg Then Exit Sub
    ImgOrient.Picture = ImgLib(Index).Picture
    If Index = 0 Then
        SelDM.dmOrientation = DMORIENT_PORTRAIT
    Else
        SelDM.dmOrientation = DMORIENT_LANDSCAPE
    End If
    WLSOK.SetFocus
End Sub

Private Sub WLSCANCEL_CLICK()
    '
    Unload Me
End Sub

Private Sub WLSOK_Click()
    Call PutUsePrinter(SelDM)
    Unload Me
End Sub
