VERSION 5.00
Begin VB.Form WLS_HCP 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "メイン画面印刷"
   ClientHeight    =   3000
   ClientLeft      =   1605
   ClientTop       =   3210
   ClientWidth     =   6750
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   9
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "WLS_HCP.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   3000
   ScaleWidth      =   6750
   Begin VB.PictureBox Picture1 
      BeginProperty Font 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   420
      Left            =   1800
      ScaleHeight     =   360
      ScaleWidth      =   450
      TabIndex        =   9
      Top             =   4365
      Width           =   510
   End
   Begin VB.Frame Frame3 
      Caption         =   "印刷の向き"
      Height          =   1230
      Left            =   3060
      TabIndex        =   5
      Top             =   1530
      Width           =   2175
      Begin VB.OptionButton OptOrient 
         Caption         =   "横"
         Height          =   375
         Index           =   1
         Left            =   1215
         TabIndex        =   8
         TabStop         =   0   'False
         Top             =   720
         Width           =   735
      End
      Begin VB.OptionButton OptOrient 
         Caption         =   "縦"
         Height          =   375
         Index           =   0
         Left            =   1215
         TabIndex        =   7
         TabStop         =   0   'False
         Top             =   270
         Width           =   735
      End
      Begin VB.Image ImgOrient 
         Height          =   465
         Left            =   270
         Top             =   450
         Width           =   465
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "用紙のサイズ"
      Height          =   1230
      Left            =   90
      TabIndex        =   4
      Top             =   1530
      Width           =   2895
      Begin VB.ComboBox CmbFormDefault 
         BeginProperty Font 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         ItemData        =   "WLS_HCP.frx":030A
         Left            =   225
         List            =   "WLS_HCP.frx":0311
         TabIndex        =   11
         Text            =   "ﾃﾞﾌｫﾙﾄ用紙サイズ"
         Top             =   450
         Width           =   2400
      End
      Begin VB.ComboBox CmbForm 
         BeginProperty Font 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         ItemData        =   "WLS_HCP.frx":0321
         Left            =   225
         List            =   "WLS_HCP.frx":0334
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   6
         TabStop         =   0   'False
         Top             =   450
         Width           =   2400
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "ﾌﾟﾘﾝﾀ"
      Height          =   1230
      Left            =   90
      TabIndex        =   2
      Top             =   135
      Width           =   6540
      Begin VB.CheckBox CHK_DEFAULT_PRN 
         Caption         =   "ﾃﾞﾌｫﾙﾄﾌﾟﾘﾝﾀのﾃﾞﾌｫﾙﾄ用紙を使う"
         BeginProperty Font 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   3375
         TabIndex        =   10
         Top             =   765
         Width           =   3030
      End
      Begin VB.ComboBox CmbPrn 
         BeginProperty Font 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   225
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   3
         TabStop         =   0   'False
         Top             =   360
         Width           =   6135
      End
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "印刷"
      Height          =   420
      Left            =   5490
      TabIndex        =   0
      Top             =   1635
      Width           =   1035
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   420
      Left            =   5490
      TabIndex        =   1
      Top             =   2295
      Width           =   1035
   End
   Begin VB.Image ImgLib 
      Height          =   465
      Index           =   0
      Left            =   360
      Picture         =   "WLS_HCP.frx":0383
      Top             =   4320
      Width           =   420
   End
   Begin VB.Image ImgLib 
      Height          =   405
      Index           =   1
      Left            =   945
      Picture         =   "WLS_HCP.frx":0E75
      Top             =   4320
      Width           =   465
   End
End
Attribute VB_Name = "WLS_HCP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Declare Function EnumPrinters Lib "winspool.drv" Alias _
    "EnumPrintersA" (ByVal flags As Long, ByVal NAME As String, _
    ByVal Level As Long, pPrinterEnum As Long, ByVal cdBuf As Long, _
    pcbNeeded As Long, pcReturned As Long) As Long
    
Private Declare Function PtrToStr Lib "kernel32" Alias "lstrcpyA" _
    (ByVal lRet As String, ByVal Ptr As Long) As Long
    
Private Declare Function StrLen Lib "kernel32" Alias "lstrlenA" _
    (ByVal Ptr As Long) As Long

Private Declare Function GetProfileString Lib "kernel32" Alias "GetProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long) As Long
Private Declare Function agGetStringFromLPSTR$ Lib "SssAPI.dll" (ByVal src$)

Const PRINTER_ENUM_LOCAL = &H2
Const PRINTER_ENUM_CONNECTIONS = &H4

Private Sub CHK_DEFAULT_PRN_Click()
    Dim I As Integer
    Dim DEF$

    If CHK_DEFAULT_PRN.Value = 1 Then
        Frame2.Enabled = False
        CmbForm.Enabled = False
        CmbForm.Visible = False
        CmbFormDefault.Visible = True
        DEF = GetDefDevice
        For I = 0 To CmbPrn.ListCount - 1
            If CmbPrn.List(I) = DEF Then
                CmbPrn.ListIndex = I
                CmbPrn.Enabled = False
                If Printer.Orientation = vbPRORPortrait Then
                    OptOrient(0).Value = True
                Else
                    OptOrient(1).Value = True       '未設定の場合は横にする
                End If
                Exit For
            End If
        Next I
    Else
        Frame2.Enabled = True
        CmbFormDefault.Visible = False
        CmbForm.Enabled = True
        CmbForm.Visible = True
        CmbPrn.Enabled = True
    End If
End Sub

Private Sub Form_Load()
    Dim I As Integer, J As Integer, ret As Integer
    Dim count As Integer
    Dim prnobj As Printer
    Dim defaultPrinterIndex As Integer
    
    CmbFormDefault.Visible = False
    CmbFormDefault.Enabled = False

    Me.Top = (Screen.Height - Me.Height) / 2
    Me.Left = (Screen.Width - Me.Width) / 2
    
    Dim lNeeded         As Long
    Dim lNumbers        As Long
    Dim lRet            As Long
    Dim cbBuffer        As Long
    Dim PrinterEnumBuffer()  As Long
    
    Dim lFlag       As Long
    Dim lLevel      As Long
    Dim strName     As String
    
    cbBuffer = 3072&
    ReDim PrinterEnumBuffer(cbBuffer \ 4)
    
    lFlag = PRINTER_ENUM_LOCAL Or PRINTER_ENUM_CONNECTIONS
    lLevel = 4
    strName = vbNullString
    
    lRet = EnumPrinters(lFlag, strName, lLevel, PrinterEnumBuffer(0), cbBuffer, lNeeded, lNumbers)
    If lRet = 0 Then
        If cbBuffer < lNeeded Then
            ReDim PrinterEnumBuffer(lNeeded \ 4)
            lRet = EnumPrinters(lFlag, strName, lLevel, PrinterEnumBuffer(0), lNeeded, lNeeded, lNumbers)
        End If
    End If
    
    defaultPrinterIndex = 0 '未設定の場合は、最初のプリンターをデフォルトとする
    If lRet <> 0 Then
        Dim strPrinterName  As String
        Dim lOffset         As Long
        
        For I = 0 To (lNumbers - 1)
            Select Case lLevel
                Case 1
                    lOffset = I * 4 + 2
                Case 2
                    lOffset = I * 21 + 2
                Case 4
                    lOffset = I * 3
                Case 5
                    lOffset = I * 5
            End Select
            
            strPrinterName = Space$(StrLen(PrinterEnumBuffer(lOffset)))
            PtrToStr strPrinterName, PrinterEnumBuffer(lOffset)
            CmbPrn.AddItem strPrinterName
        Next
    Else
        For I = 0 To Printers.count - 1
            CmbPrn.AddItem Printers(I).DeviceName
        Next
    End If
    CmbPrn.ListIndex = 0
    For I = 0 To CmbPrn.ListCount - 1
        If CmbPrn.List(I) = Printer.DeviceName Then
            CmbPrn.ListIndex = I
            Exit For
        End If
    Next
    'デフォルト用紙サイズの確定
    Select Case Printer.PaperSize
    Case vbPRPSA3
        CmbForm.ListIndex = 0
    Case vbPRPSA4
        CmbForm.ListIndex = 1
    Case vbPRPSA5
        CmbForm.ListIndex = 2
    Case vbPRPSB4
        CmbForm.ListIndex = 3
    Case vbPRPSB5
        CmbForm.ListIndex = 4
    Case Else
        CmbForm.ListIndex = 1   'その他の用紙はA4にする
    End Select
    
    'デフォルト向きの確定
    OptOrient(1).Value = True

End Sub


Private Sub OptOrient_Click(Index As Integer)
    ImgOrient.Picture = ImgLib(Index).Picture

End Sub

Private Sub WLSCANCEL_Click()
    Me.Hide
End Sub

Private Sub WLSOK_Click()
    Dim I%, J%, DEF$
    If CHK_DEFAULT_PRN.Value = 1 Then
        'ﾃﾞﾌｫﾙﾄﾌﾟﾘﾝﾀとﾃﾞﾌｫﾙﾄ用紙を使う
        DEF = GetDefDevice
        For I = 0 To Printers.count - 1
            If Printers(I).DeviceName = DEF Then
                J = I
                Exit For
            End If
        Next
        gSelectedDeviceName = DEF
        gSelectedPapeSize = Printers(J).PaperSize
    Else
        For I = 0 To Printers.count - 1
            If Printers(I).DeviceName = CmbPrn.List(CmbPrn.ListIndex) Then
                J = I
                Exit For
            End If
        Next
        gSelectedDeviceName = CmbPrn.Text
        Select Case Left$(CmbForm.Text, 2)
        Case "A3"
            gSelectedPapeSize = vbPRPSA3
        Case "A4"
            gSelectedPapeSize = vbPRPSA4
        Case "A5"
            gSelectedPapeSize = vbPRPSA5
        Case "B5"
            gSelectedPapeSize = vbPRPSB5
        Case "B4"
            gSelectedPapeSize = vbPRPSB4
        Case Else
            gSelectedPapeSize = Printer.PaperSize
        End Select
    End If
    If OptOrient(0).Value = True Then
        gSelectedOrientation = 1
    Else
        gSelectedOrientation = 2
    End If
    Me.Hide
End Sub

Private Function GetDefDevice() As String
    Dim DEF$
    Dim di&
    Dim npos%

    DEF$ = String$(128, 0)
    di = GetProfileString("WINDOWS", "DEVICE", "", DEF$, 127)
    DEF$ = agGetStringFromLPSTR$(DEF$)
    npos% = InStr(DEF$, ",")
    GetDefDevice = Left$(DEF$, npos% - 1)

End Function

