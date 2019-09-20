Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_HCP
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_NOTE: NAME は NAME_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Declare Function EnumPrinters Lib "winspool.drv"  Alias "EnumPrintersA"(ByVal flags As Integer, ByVal NAME_Renamed As String, ByVal Level As Integer, ByRef pPrinterEnum As Integer, ByVal cdBuf As Integer, ByRef pcbNeeded As Integer, ByRef pcReturned As Integer) As Integer
	
	Private Declare Function PtrToStr Lib "kernel32"  Alias "lstrcpyA"(ByVal lRet As String, ByVal Ptr As Integer) As Integer
	
	Private Declare Function StrLen Lib "kernel32"  Alias "lstrlenA"(ByVal Ptr As Integer) As Integer
	
	Private Declare Function GetProfileString Lib "kernel32"  Alias "GetProfileStringA"(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer) As Integer
	Private Declare Function agGetStringFromLPSTR Lib "SssAPI.dll" (ByVal src As String) As String
	
	Const PRINTER_ENUM_LOCAL As Short = &H2s
	Const PRINTER_ENUM_CONNECTIONS As Short = &H4s

    '2019/03/12　仮
    '   'UPGRADE_WARNING: イベント CHK_DEFAULT_PRN.CheckStateChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    'Private Sub CHK_DEFAULT_PRN_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHK_DEFAULT_PRN.CheckStateChanged
    '	Dim I As Short
    '	Dim DEF As String

    '	If CHK_DEFAULT_PRN.CheckState = 1 Then
    '		Frame2.Enabled = False
    '		CmbForm.Enabled = False
    '		CmbForm.Visible = False
    '		CmbFormDefault.Visible = True
    '		DEF = GetDefDevice
    '		For I = 0 To CmbPrn.Items.Count - 1
    '			If VB6.GetItemString(CmbPrn, I) = DEF Then
    '				CmbPrn.SelectedIndex = I
    '				CmbPrn.Enabled = False
    '				'UPGRADE_ISSUE: 定数 vbPRORPortrait はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				'UPGRADE_ISSUE: Printer プロパティ Printer.Orientation はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '				If Printer.Orientation = vbPRORPortrait Then
    '					OptOrient(0).Checked = True
    '				Else
    '					OptOrient(1).Checked = True '未設定の場合は横にする
    '				End If
    '				Exit For
    '			End If
    '		Next I
    '	Else
    '		Frame2.Enabled = True
    '		CmbFormDefault.Visible = False
    '		CmbForm.Enabled = True
    '		CmbForm.Visible = True
    '		CmbPrn.Enabled = True
    '	End If
    '   End Sub
    '2019/03/12　仮

    '2019/03/12　仮
    'Private Sub WLS_HCP_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    '	Dim J, I, ret As Short
    '	Dim count As Short
    '	'UPGRADE_ISSUE: Printer オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '	Dim prnobj As Printer
    '	Dim defaultPrinterIndex As Short

    '	CmbFormDefault.Visible = False
    '	CmbFormDefault.Enabled = False

    '	Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
    '	Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)

    '	Dim lNeeded As Integer
    '	Dim lNumbers As Integer
    '	Dim lRet As Integer
    '	Dim cbBuffer As Integer
    '	Dim PrinterEnumBuffer() As Integer

    '	Dim lFlag As Integer
    '	Dim lLevel As Integer
    '	Dim strName As String

    '	cbBuffer = 3072
    '	ReDim PrinterEnumBuffer(cbBuffer \ 4)

    '	lFlag = PRINTER_ENUM_LOCAL Or PRINTER_ENUM_CONNECTIONS
    '	lLevel = 4
    '	strName = vbNullString

    '	lRet = EnumPrinters(lFlag, strName, lLevel, PrinterEnumBuffer(0), cbBuffer, lNeeded, lNumbers)
    '	If lRet = 0 Then
    '		If cbBuffer < lNeeded Then
    '			ReDim PrinterEnumBuffer(lNeeded \ 4)
    '			lRet = EnumPrinters(lFlag, strName, lLevel, PrinterEnumBuffer(0), lNeeded, lNeeded, lNumbers)
    '		End If
    '	End If

    '	defaultPrinterIndex = 0 '未設定の場合は、最初のプリンターをデフォルトとする
    '	Dim strPrinterName As String
    '	Dim lOffset As Integer
    '	If lRet <> 0 Then

    '		For I = 0 To (lNumbers - 1)
    '			Select Case lLevel
    '				Case 1
    '					lOffset = I * 4 + 2
    '				Case 2
    '					lOffset = I * 21 + 2
    '				Case 4
    '					lOffset = I * 3
    '				Case 5
    '					lOffset = I * 5
    '			End Select

    '			strPrinterName = Space(StrLen(PrinterEnumBuffer(lOffset)))
    '			PtrToStr(strPrinterName, PrinterEnumBuffer(lOffset))
    '			CmbPrn.Items.Add(strPrinterName)
    '		Next 
    '	Else
    '		'UPGRADE_ISSUE: Printers メソッド Printers.count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
    '		For I = 0 To Printers.count - 1
    '			'UPGRADE_ISSUE: Printer プロパティ Printers.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '			CmbPrn.Items.Add(Printers(I).DeviceName)
    '		Next 
    '	End If
    '	CmbPrn.SelectedIndex = 0
    '	For I = 0 To CmbPrn.Items.Count - 1
    '		'UPGRADE_ISSUE: Printer プロパティ Printer.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '		If VB6.GetItemString(CmbPrn, I) = Printer.DeviceName Then
    '			CmbPrn.SelectedIndex = I
    '			Exit For
    '		End If
    '	Next 
    '	'デフォルト用紙サイズの確定
    '	'UPGRADE_ISSUE: 定数 vbPRPSB5 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbPRPSB4 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbPRPSA5 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbPRPSA4 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbPRPSA3 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: Printer プロパティ Printer.PaperSize はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '	Select Case Printer.PaperSize
    '		Case vbPRPSA3
    '			CmbForm.SelectedIndex = 0
    '		Case vbPRPSA4
    '			CmbForm.SelectedIndex = 1
    '		Case vbPRPSA5
    '			CmbForm.SelectedIndex = 2
    '		Case vbPRPSB4
    '			CmbForm.SelectedIndex = 3
    '		Case vbPRPSB5
    '			CmbForm.SelectedIndex = 4
    '		Case Else
    '			CmbForm.SelectedIndex = 1 'その他の用紙はA4にする
    '	End Select

    '	'デフォルト向きの確定
    '	OptOrient(1).Checked = True

    '   End Sub
    '2019/03/12　仮


    'UPGRADE_WARNING: イベント OptOrient.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub OptOrient_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptOrient.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = OptOrient.GetIndex(eventSender)
			ImgOrient.Image = ImgLib(Index).Image
			
		End If
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Me.Hide()
	End Sub

    '2019/03/12　仮
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	Dim I, J As Short
    '	Dim DEF As String
    '	If CHK_DEFAULT_PRN.CheckState = 1 Then
    '		'ﾃﾞﾌｫﾙﾄﾌﾟﾘﾝﾀとﾃﾞﾌｫﾙﾄ用紙を使う
    '		DEF = GetDefDevice
    '		'UPGRADE_ISSUE: Printers メソッド Printers.count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
    '		For I = 0 To Printers.count - 1
    '			'UPGRADE_ISSUE: Printer プロパティ Printers.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '			If Printers(I).DeviceName = DEF Then
    '				J = I
    '				Exit For
    '			End If
    '		Next 
    '		gSelectedDeviceName = DEF
    '		'UPGRADE_ISSUE: Printer プロパティ Printers.PaperSize はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '		gSelectedPapeSize = Printers(J).PaperSize
    '	Else
    '		'UPGRADE_ISSUE: Printers メソッド Printers.count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
    '		For I = 0 To Printers.count - 1
    '			'UPGRADE_ISSUE: Printer プロパティ Printers.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '			If Printers(I).DeviceName = VB6.GetItemString(CmbPrn, CmbPrn.SelectedIndex) Then
    '				J = I
    '				Exit For
    '			End If
    '		Next 
    '		gSelectedDeviceName = CmbPrn.Text
    '		Select Case VB.Left(CmbForm.Text, 2)
    '			Case "A3"
    '				'UPGRADE_ISSUE: 定数 vbPRPSA3 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				gSelectedPapeSize = vbPRPSA3
    '			Case "A4"
    '				'UPGRADE_ISSUE: 定数 vbPRPSA4 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				gSelectedPapeSize = vbPRPSA4
    '			Case "A5"
    '				'UPGRADE_ISSUE: 定数 vbPRPSA5 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				gSelectedPapeSize = vbPRPSA5
    '			Case "B5"
    '				'UPGRADE_ISSUE: 定数 vbPRPSB5 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				gSelectedPapeSize = vbPRPSB5
    '			Case "B4"
    '				'UPGRADE_ISSUE: 定数 vbPRPSB4 はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '				gSelectedPapeSize = vbPRPSB4
    '			Case Else
    '				'UPGRADE_ISSUE: Printer プロパティ Printer.PaperSize はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
    '				gSelectedPapeSize = Printer.PaperSize
    '		End Select
    '	End If
    '	If OptOrient(0).Checked = True Then
    '		gSelectedOrientation = CStr(1)
    '	Else
    '		gSelectedOrientation = CStr(2)
    '	End If
    '	Me.Hide()
    '   End Sub
    '2019/03/12　仮
	
	Private Function GetDefDevice() As String
		Dim DEF As String
		Dim di As Integer
		Dim npos As Short
		
		DEF = New String(Chr(0), 128)
		di = GetProfileString("WINDOWS", "DEVICE", "", DEF, 127)
		DEF = agGetStringFromLPSTR(DEF)
		npos = InStr(DEF, ",")
		GetDefDevice = VB.Left(DEF, npos - 1)
		
	End Function
End Class