Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_PRN
	Inherits System.Windows.Forms.Form
	'UPGRADE_WARNING: 構造体 SelDM の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Dim SelDM As DEVMODE
	Dim SavDevice As String
	Dim dspflg As Boolean
	
	
	'UPGRADE_WARNING: イベント CmbForm.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub CmbForm_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbForm.SelectedIndexChanged
		
		If dspflg Then Exit Sub
		SelDM.dmPaperSize = CShort(VB6.GetItemString(LstForm, CmbForm.SelectedIndex))
		SelDM.dmFormName = VB6.GetItemString(CmbForm, CmbForm.SelectedIndex) & Chr(0)
		WLSOK.Focus()
	End Sub
	
	'UPGRADE_WARNING: イベント CmbKyusi.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub CmbKyusi_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbKyusi.SelectedIndexChanged
		
		If dspflg Then Exit Sub
		SelDM.dmDefaultSource = CShort(VB6.GetItemString(LstKyusi, CmbKyusi.SelectedIndex))
		WLSOK.Focus()
	End Sub
	
	'UPGRADE_WARNING: イベント CmbPrn.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub CmbPrn_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbPrn.SelectedIndexChanged
		
		If dspflg Then Exit Sub
		If VB6.GetItemString(CmbPrn, CmbPrn.SelectedIndex) <> SavDevice Then
			Call GetDevMode(VB6.GetItemString(CmbPrn, CmbPrn.SelectedIndex), DM_OUT_BUFFER)
		End If
		WLSOK.Focus()
	End Sub
	
	Private Sub CmbPrn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmbPrn.Enter
		SavDevice = VB6.GetItemString(CmbPrn, CmbPrn.SelectedIndex)
	End Sub
	
	Private Sub CmdProper_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdProper.Click
		
		Call GetDevMode(VB6.GetItemString(CmbPrn, CmbPrn.SelectedIndex), DM_IN_BUFFER Or DM_IN_PROMPT Or DM_OUT_BUFFER)
		WLSOK.Focus()
	End Sub
	
	'UPGRADE_WARNING: Form イベント WLS_PRN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_PRN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Me.Enabled = False
		'WLSOK.Left = (WLS_PRN.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
		'WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
		System.Windows.Forms.Application.DoEvents()
		If GetUsePrinter(SelDM) Then
			Call DisplayPrinter()
		Else
			Call GetDevMode(GetDefDevice(), DM_OUT_BUFFER)
		End If
		Me.Enabled = True
		WLSOK.Focus()
	End Sub
	
	Private Sub WLS_PRN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim I As Short
		
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		'UPGRADE_ISSUE: Printers メソッド Printers.count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		For I = 0 To Printers.count - 1
			'UPGRADE_ISSUE: Printer プロパティ Printers.DeviceName はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
			CmbPrn.Items.Add(Printers(I).DeviceName)
		Next 
		'Default 用紙サイズと印刷向きを表示
		'UPGRADE_WARNING: オブジェクト PNL_DefSize.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PNL_DefSize.Caption = SSS_DefPaperSizeNm
		If SSS_DefOrient = 2 Then
			'UPGRADE_WARNING: オブジェクト PNL_DefOrient.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PNL_DefOrient.Caption = "横"
		Else
			'UPGRADE_WARNING: オブジェクト PNL_DefOrient.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PNL_DefOrient.Caption = "縦"
		End If
		Call Init_Prompt()
	End Sub
	
	Function GetDefDevice() As String
		Dim DEF As String
		Dim di As Integer
		Dim npos As Short
		
		DEF = New String(Chr(0), 128)
		di = GetProfileString("WINDOWS", "DEVICE", "", DEF, 127)
		'#Start(2003.5.20) プリンタがインストールされていない場合のランタイムエラーを防ぐ
		If di = 0 Then
			MsgBox("このＰＣにはプリンタがインストールされていないようです。" & vbCr & "帳票プログラムの実行にはプリンタ(ドライバ)が必須です。" & vbCr & "インストールして下さい。" & vbCr & "―――――――――――――――――――――――――――――――――" & vbCr & "プリンタ(ドライバ）がない場合は、正しく実行されない可能性があります。", MsgBoxStyle.Exclamation)
			GetDefDevice = ""
			Exit Function
		End If
		'#End(2003.5.20)
		DEF = agGetStringFromLPSTR(DEF)
		npos = InStr(DEF, ",")
		'#Start(2003.5.20) プリンタ名が127バイトを超える時のランタイムエラーを防ぐ
		If npos < 1 Then
			MsgBox("プリンタ名に異常があるようです。" & vbCr & "プリンタ名の長さが127バイト以内にして下さい。", MsgBoxStyle.Exclamation)
			GetDefDevice = ""
			Exit Function
		End If
		'#End(2003.5.20)
		GetDefDevice = VB.Left(DEF, npos - 1)
		
	End Function
	
	Sub GetDevMode(ByVal dv As String, ByVal fmode As Integer)
		Dim hPrinter, res As Integer
		Dim pdefs As PRINTER_DEFAULTS
		Dim bufsize As Integer
		Dim dmInBuf() As Byte
		Dim dmOutBuf() As Byte
		Dim I As Short
		pdefs.PDATATYPE = vbNullString
		pdefs.PDEVMODE = 0
		'    pdefs.DesiredAccess = PRINTER_ACCESS_ADMINISTER
		pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
		
		'#Start(2003.11.17) CR9 Unicode 対応
		Dim UniDv() As Byte
		
		'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
		UniDv = System.Text.UnicodeEncoding.Unicode.GetBytes(dv & Chr(0))
		' OpenPrinterBynum の3つ目のパラメータには 0 を指定できますが、
		' 全てのプリンタプロパティは編集できなくなります。
		'res& = OpenPrinter(dv, hPrinter, pdefs)
		res = OpenPrinter(UniDv(0), hPrinter, pdefs)
		'#End(2003.11.17)
		
		'    res& = OpenPrinterBynum(devname$, hPrinter, 0)
		If res = 0 Then Exit Sub
		
		'#Start(2003.11.17) CR9 Unicode 対応
		'bufsize = DocumentProperties(Me.hwnd, hPrinter, dv, 0, 0, 0)
		bufsize = DocumentProperties(Me.Handle.ToInt32, hPrinter, UniDv(0), 0, 0, 0)
		'#End(2003.11.17)
		
		If bufsize < Len(SelDM) Then bufsize = Len(SelDM)
		ReDim dmInBuf(bufsize)
		ReDim dmOutBuf(bufsize)
		'UPGRADE_WARNING: オブジェクト SelDM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		agCopyData(SelDM, dmInBuf(0), Len(SelDM))
		
		'#Start(2003.11.17) CR9 Unicode 対応
		'res = DocumentProperties(Me.hwnd, hPrinter, dv, agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
		res = DocumentProperties(Me.Handle.ToInt32, hPrinter, UniDv(0), agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
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
				'UPGRADE_WARNING: オブジェクト SelDM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				agCopyData(dmOutBuf(0), SelDM, Len(SelDM))
				'2000/10/19 一行追加　長いプリンタ名に対応
				SelDM.LongDeviceName = RTrim(dv) & Chr(0)
				'デフォールト用紙サイズと印字向きが登録されている場合、それをデフォールトに
				'#Start(2002.2.27) プリンタプロパティでの指定に従うので、次の２行を外す
				'SelDM.dmOrientation = SSS_DefOrient
				'SelDM.dmPaperSize = SSS_DefPaperSize
				'#End(2002.2.27)
				Call DisplayPrinter()
			Case IDCANCEL
			Case Else
				MsgBox("プリンタの情報が取得できません。", 0, "プリンタの設定")
		End Select
		ClosePrinter(hPrinter)
	End Sub
	
	Sub DisplayPrinter()
		Dim MidWid As Object
		Dim devname, devoutput As String
		Dim count As Integer
		Dim names As String
		Dim a, S As String
		Dim di As Integer
		Dim I, J As Short
		Dim NoBuf() As Byte
		Dim No As Short
		
		CmbForm.Items.Clear()
		LstForm.Items.Clear()
		CmbKyusi.Items.Clear()
		LstKyusi.Items.Clear()
		
		dspflg = True
		If (CmbPrn.Items.Count > 0) And (CmbPrn.SelectedIndex < 0) Then CmbPrn.SelectedIndex = 0
		'2000/10/19 １行変更　長いプリンタ名に対応
		'    devname$ = agGetStringFromLPSTR$(SelDM.dmDeviceName)
		devname = agGetStringFromLPSTR(SelDM.LongDeviceName)
		For I = 0 To CmbPrn.Items.Count - 1
			If VB6.GetItemString(CmbPrn, I) = devname Then
				CmbPrn.SelectedIndex = I
				Exit For
			End If
		Next 
		
		'    devname$ = CmbPrn.List(CmbPrn.ListIndex)
		'    devoutput$ = GetDeviceOutput$(dev$)
		devoutput = ""
		
		' 使用可能な用紙サイズを取得します。
		count = DeviceCapabilities(devname, devoutput, DC_PAPERNAMES, vbNullString, 0)
		If count <= 0 Then
			MsgBox("使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定")
			Exit Sub
		End If
		
		' 情報を保持できる十分な領域を確保します。
		names = New String(Chr(0), 64 * count)
		di = DeviceCapabilities(devname, devoutput, DC_PAPERNAMES, names, 0)
		
		' 使用可能な用紙サイズを取得します。
		count = DeviceCapabilitiesNo(devname, devoutput, DC_PAPERS, 0, 0)
		If count <= 0 Then
			MsgBox("使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定")
			Exit Sub
		End If
		
		' 情報を保持できる十分な領域を確保します。
		ReDim NoBuf(2 * count)
		di = DeviceCapabilitiesNo(devname, devoutput, DC_PAPERS, agGetAddressForObject(NoBuf(0)), 0)
		
		' 取得した情報を表示します。
		For I = 0 To count - 1
			No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
			LstForm.Items.Add(CStr(No))
			'UPGRADE_WARNING: オブジェクト MidWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			a = MidWid(names, I * 64 + 1, 64)
			a = agGetStringFromLPSTR(a)
			CmbForm.Items.Add(a)
			If No = SelDM.dmPaperSize Then
				CmbForm.SelectedIndex = I
			End If
		Next 
		
		' 使用可能な用紙サイズを取得します。
		count = DeviceCapabilities(devname, devoutput, DC_BINNAMES, vbNullString, 0)
		If count <= 0 Then
			MsgBox("使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定")
			Exit Sub
		End If
		
		' 情報を保持できる十分な領域を確保します。
		names = New String(Chr(0), 24 * count)
		di = DeviceCapabilities(devname, devoutput, DC_BINNAMES, names, 0)
		
		' 使用可能な用紙サイズを取得します。
		count = DeviceCapabilitiesNo(devname, devoutput, DC_BINS, 0, 0)
		If count <= 0 Then
			MsgBox("使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定")
			Exit Sub
		End If
		
		' 情報を保持できる十分な領域を確保します。
		ReDim NoBuf(2 * count)
		di = DeviceCapabilitiesNo(devname, devoutput, DC_BINS, agGetAddressForObject(NoBuf(0)), 0)
		
		' 取得した情報を表示します。
		For I = 0 To count - 1
			No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
			LstKyusi.Items.Add(CStr(No))
			'UPGRADE_WARNING: オブジェクト MidWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			a = MidWid(names, I * 24 + 1, 24)
			a = agGetStringFromLPSTR(a)
			CmbKyusi.Items.Add(a)
			If No = SelDM.dmDefaultSource Then
				CmbKyusi.SelectedIndex = I
			End If
		Next 
		
		If SelDM.dmOrientation = DMORIENT_PORTRAIT Then
			OptOrient(0).Checked = True
			ImgOrient.Image = ImgLib(0).Image
		Else
			OptOrient(1).Checked = True
			ImgOrient.Image = ImgLib(1).Image
		End If
		dspflg = False
	End Sub
	
	
	'UPGRADE_WARNING: イベント OptOrient.CheckedChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub OptOrient_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptOrient.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = OptOrient.GetIndex(eventSender)
			If dspflg Then Exit Sub
			ImgOrient.Image = ImgLib(Index).Image
			If Index = 0 Then
				SelDM.dmOrientation = DMORIENT_PORTRAIT
			Else
				SelDM.dmOrientation = DMORIENT_LANDSCAPE
			End If
			WLSOK.Focus()
		End If
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'
		Me.Close()
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call PutUsePrinter(SelDM)
		Me.Close()
	End Sub
End Class