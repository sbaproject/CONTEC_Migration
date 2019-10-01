Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module SSSWIN_BAS
	'
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'#Start(2003.10.28)
	'#Start(2003.4.22) PrintFormの代わりに、フォーム印刷を実装
	'Public gSelectedPrinter As Printer
	Public gSelectedDeviceName As String
	Public gSelectedPapeSize As Short
	Public gSelectedOrientation As String
	
	Private Structure PALETTEENTRY
		Dim peRed As Byte
		Dim peGreen As Byte
		Dim peBlue As Byte
		Dim peFlags As Byte
	End Structure
	
	Private Structure LOGPALETTE
		Dim palVersion As Short
		Dim palNumEntries As Short
		<VBFixedArray(255)> Dim palPalEntry() As PALETTEENTRY ' Enough for 256 colors
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim palPalEntry(255)
		End Sub
	End Structure
	
	Private Structure GUID
		Dim Data1 As Integer
		Dim Data2 As Short
		Dim Data3 As Short
		<VBFixedArray(7)> Dim Data4() As Byte
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim Data4(7)
		End Sub
	End Structure
	
	Private Const RASTERCAPS As Integer = 38
	Private Const RC_PALETTE As Integer = &H100s
	Private Const SIZEPALETTE As Integer = 104
	
	Private Structure RECT
		'UPGRADE_NOTE: Left は Left_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim Left_Renamed As Integer
		Dim Top As Integer
		'UPGRADE_NOTE: Right は Right_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim Right_Renamed As Integer
		Dim Bottom As Integer
	End Structure
	
	Private Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function CreateCompatibleBitmap Lib "gdi32" (ByVal hdc As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer
	Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal iCapabilitiy As Integer) As Integer
	'UPGRADE_WARNING: 構造体 PALETTEENTRY に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function GetSystemPaletteEntries Lib "gdi32" (ByVal hdc As Integer, ByVal wStartIndex As Integer, ByVal wNumEntries As Integer, ByRef lpPaletteEntries As PALETTEENTRY) As Integer
	'UPGRADE_WARNING: 構造体 LOGPALETTE に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function CreatePalette Lib "gdi32" (ByRef lpLogPalette As LOGPALETTE) As Integer
	Private Declare Function SelectObject Lib "gdi32" (ByVal hdc As Integer, ByVal hObject As Integer) As Integer
	Private Declare Function BitBlt Lib "gdi32" (ByVal hDCDest As Integer, ByVal XDest As Integer, ByVal YDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hDCSrc As Integer, ByVal XSrc As Integer, ByVal YSrc As Integer, ByVal dwRop As Integer) As Integer
	Private Declare Function DeleteDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function GetForegroundWindow Lib "user32" () As Integer
	Private Declare Function SelectPalette Lib "gdi32" (ByVal hdc As Integer, ByVal hPalette As Integer, ByVal bForceBackground As Integer) As Integer
	Private Declare Function RealizePalette Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Integer) As Integer
	Private Declare Function GetDC Lib "user32" (ByVal hwnd As Integer) As Integer
	'UPGRADE_WARNING: 構造体 RECT に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function GetWindowRect Lib "user32" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
	Private Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Integer, ByVal hdc As Integer) As Integer
	Private Declare Function GetDesktopWindow Lib "user32" () As Integer
	
	Private Structure PicBmp
		Dim Size As Integer
		Dim Type As Integer
		Dim hBmp As Integer
		Dim hPal As Integer
		Dim Reserved As Integer
	End Structure
	
	'UPGRADE_WARNING: 構造体 IPicture に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	'UPGRADE_WARNING: 構造体 GUID に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	'UPGRADE_WARNING: 構造体 PicBmp に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Function OleCreatePictureIndirect Lib "olepro32.dll" (ByRef PicDesc As PicBmp, ByRef RefIID As GUID, ByVal fPictureOwnsHandle As Integer, ByRef IPic As System.Drawing.Image) As Integer
	'#End(2003.4.22)
	Private Const PRINTER_ACCESS_USE As Short = &H8s
	Private Const DM_OUT_BUFFER As Short = 2
	Private Const BI_RGB As Short = 0
	Private Const GMEM_MOVEABLE As Short = &H2s
	Private Const DIB_RGB_COLORS As Short = 0 '  color table in RGBs
	Private Const HORZRES As Short = 8 '  Horizontal width in pixels
	Private Const VERTRES As Short = 10 '  Vertical width in pixels
	Private Const DMCOLOR_COLOR As Short = 2
	Private Structure BITMAPINFOHEADER '40 bytes
		Dim biSize As Integer
		Dim biWidth As Integer
		Dim biHeight As Integer
		Dim biPlanes As Short
		Dim biBitCount As Short
		Dim biCompression As Integer
		Dim biSizeImage As Integer
		Dim biXPelsPerMeter As Integer
		Dim biYPelsPerMeter As Integer
		Dim biClrUsed As Integer
		Dim biClrImportant As Integer
	End Structure
	Private Structure BITMAPINFO '24Bit Color
		Dim bmiHeader As BITMAPINFOHEADER
	End Structure
	Private Structure BITMAP '14 bytes
		Dim bmType As Integer
		Dim bmWidth As Integer
		Dim bmHeight As Integer
		Dim bmWidthBytes As Integer
		Dim bmPlanes As Short
		Dim bmBitsPixel As Short
		Dim bmBits As Integer
	End Structure
	Private Structure PRINTER_DEFAULTS
		Dim PDATATYPE As String
		Dim PDEVMODE As Integer
		Dim DESIREDACCESS As Integer
	End Structure
	Private Structure sDEVMODE
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(32),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=32)> Public dmDeviceName() As Char
		Dim dmSpecVersion As Short
		Dim dmDriverVersion As Short
		Dim dmSize As Short
		Dim dmDriverExtra As Short
		Dim dmFields As Integer
		Dim dmOrientation As Short
		Dim dmPaperSize As Short
		Dim dmPaperLength As Short
		Dim dmPaperWidth As Short
		Dim dmScale As Short
		Dim dmCopies As Short
		Dim dmDefaultSource As Short
		Dim dmPrintQuality As Short
		Dim dmColor As Short
		Dim dmDuplex As Short
		Dim dmYResolution As Short
		Dim dmTTOption As Short
		Dim dmCollate As Short
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(32),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=32)> Public dmFormName() As Char
		Dim dmUnusedPadding As Short
		Dim dmBitsPerPel As Integer
		Dim dmPelsWidth As Integer
		Dim dmPelsHeight As Integer
		Dim dmDisplayFlags As Integer
		Dim dmDisplayFrequency As Integer
		Dim dmICMMethod As Integer
		Dim dmICMIntent As Integer
		Dim dmMediaType As Integer
		Dim dmDitherType As Integer
		Dim dmReserved1 As Integer
		Dim dmReserved2 As Integer
	End Structure
	Private Structure DOCINFO
		Dim cbSize As Integer
		Dim lpszDocName As String
		Dim lpszOutput As String
	End Structure
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Function GetObjectAPI Lib "gdi32"  Alias "GetObjectA"(ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Any) As Integer
    Private Declare Function GetObjectAPI Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As BITMAP) As Integer
    '20190806 DELL END
    Private Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Integer, ByVal dwBytes As Integer) As Integer
	Private Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Integer) As Integer
	Private Declare Function GlobalLock Lib "kernel32" (ByVal hMem As Integer) As Integer
	Private Declare Function GlobalUnlock Lib "kernel32" (ByVal hMem As Integer) As Integer
    'UPGRADE_WARNING: 構造体 BITMAPINFO に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Any, ByRef lpBI As BITMAPINFO, ByVal wUsage As Integer) As Integer
    Private Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Integer, ByRef lpBI As BITMAPINFO, ByVal wUsage As Integer) As Integer
    '20190806 CHG END
    'UPGRADE_WARNING: 構造体 BITMAPINFO に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Function StretchDIBits Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal wSrcWidth As Integer, ByVal wSrcHeight As Integer, ByRef lpBits As Any, ByRef lpBitsInfo As BITMAPINFO, ByVal wUsage As Integer, ByVal dwRop As Integer) As Integer
    Private Declare Function StretchDIBits Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal wSrcWidth As Integer, ByVal wSrcHeight As Integer, ByRef lpBits As Integer, ByRef lpBitsInfo As BITMAPINFO, ByVal wUsage As Integer, ByVal dwRop As Integer) As Integer
    '20190806 CHG END
    'UPGRADE_WARNING: 構造体 PRINTER_DEFAULTS に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
    Private Declare Function sOpenPrinter Lib "winspool.drv"  Alias "OpenPrinterA"(ByVal pPrinterName As String, ByRef phPrinter As Integer, ByRef pDefault As PRINTER_DEFAULTS) As Integer
	Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
	Private Declare Function snDocumentProperties Lib "winspool.drv"  Alias "DocumentPropertiesA"(ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByVal pnDevModeOutput As Integer, ByVal pnDevModeInput As Integer, ByVal fmode As Integer) As Integer
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Function sDocumentProperties Lib "winspool.drv"  Alias "DocumentPropertiesA"(ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByRef pDevModeOutput As Any, ByRef pDevModeInput As Any, ByVal fmode As Integer) As Integer
    Private Declare Function sDocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByRef pDevModeOutput As Integer, ByRef pDevModeInput As Integer, ByVal fmode As Integer) As Integer
    '20190806 CHG END
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Function CreateDC Lib "gdi32"  Alias "CreateDCA"(ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByRef lpInitData As Any) As Integer
    Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByRef lpInitData As Integer) As Integer
    '20190806 CHG END
    'UPGRADE_WARNING: 構造体 DOCINFO に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
    Private Declare Function StartDoc Lib "gdi32"  Alias "StartDocA"(ByVal hdc As Integer, ByRef lpdi As DOCINFO) As Integer
	Private Declare Function EndDocAPI Lib "gdi32"  Alias "EndDoc"(ByVal hdc As Integer) As Integer
	Private Declare Function StartPage Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function EndPage Lib "gdi32" (ByVal hdc As Integer) As Integer
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Private Declare Sub memcpy Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Dst As Any, ByRef src As Any, ByVal LENGTH As Integer)
    Private Declare Sub memcpy Lib "kernel32" Alias "RtlMoveMemory" (ByRef Dst As Object, ByRef src As Object, ByVal LENGTH As Integer)
    '20190806 CHG END
    '#End(2003.10.28)

    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '20190806 CHG END
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '20190806 CHG START
    'Declare Function WritePrivateProfileString Lib "kernel32"  Alias "WritePrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
    Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    '20190806 CHG END
    Declare Function VBEXEC1 Lib "VBEXEC32" (ByVal hwnd As Integer, ByVal kb As Integer, ByVal prg As String) As Integer
	'=======================================
	'ＳＳＳＷＩＮ．ＩＮＩ
	'=======================================
	'---------------------------------------------------------------
	Dim SSS_INIDATNM(4) As String 'ＩＮＩのシンボル
	Public SSS_INIDAT(4) As String 'ＩＮＩの内容
    'SSS_INIDATNM(0) = "USR_PATH"           '開発環境PATH
    'SSS_INIDATNM(1) = "DAT_PATH"           'データPATH
    'SSS_INIDATNM(2) = "PRG_PATH"           'プログラムPATH
    'SSS_INIDATNM(3) = "WRK_PATH"           'ワークPATH
    'SSS_INIDATNM(4) = "IMGPATH"            'イメージPATH
    '---------------------------------------------------------------

    'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
    '2019806 CHG START
    'Public SSS_WRKDT(5) As String*8
    <VBFixedStringAttribute(8)> Public SSS_WRKDT(5) As String
    '20190806 CHG END


    Public Set_date As New VB6.FixedLengthString(10) 'ｶﾚﾝﾀﾞｰWINDOW用
	Public SSS_CLTID As New VB6.FixedLengthString(5)
	Public SSS_OPEID As New VB6.FixedLengthString(8)
	Public SSS_SMADT As New VB6.FixedLengthString(8)
	Public SSS_SSADT As New VB6.FixedLengthString(8)
	Public SSS_KESDT As New VB6.FixedLengthString(8)
	Public SSS_ACNT As Short
	Public SSS_SMFKB As Decimal
	Public SSS_WLSLIST_KETA As Short '簡易WINDOW用データ取得桁数
	Public SSS_RTNWIN As Object 'ｳｲﾝﾄﾞｳからの返り値
	Public SSS_MFIL As Short 'ﾒｲﾝﾌｧｲﾙ
	Public SSS_MFILNM As String 'ﾘｽﾄﾌｧｲﾙ名
	Public SSS_MFILKEYNO As Short 'ﾒｲﾝﾌｧｲﾙｷｰ番号
	Public SSS_MFILCNT As Integer 'ﾒｲﾝﾌｧｲﾙ読み込み件数
	Public SSS_MFILTCNT As Integer 'ﾒｲﾝﾌｧｲﾙ総件数
	Public SSS_RPTID As String 'ｸﾘｽﾀﾙﾚﾎﾟｰﾄID
	Public SSS_LSTMFIL As Short '印刷ワークメインファイル番号
	Public SSS_LSTMFILNM As String '印刷ワークメインファイル名
	Public SSS_LFILCNT As Integer '印刷用ファイル出力件数
	Public SSS_LASTKEY As New VB6.FixedLengthString(128) '画面表示用KEY
	Public SSS_FASTKEY As New VB6.FixedLengthString(128) '画面表示用KEY
	Public SSS_LSTOP As Short '印刷中断フラッグ（TRUE:中止）
	Public SSS_ExportFLG As Short 'ファイル出力区分
	Public SSS_ExportFileKB As Short '出力ファイル作成区分
	Public SSS_ExportFileType As Short 'ファイルタイプ区分
	Public SSS_ExecuteFile(10) As String '実行チェーンファイル
	Public SSS_UPDATEFL As Short '更新可能フラグ
	Public SSS_ExecuteMsgFL As Short '更新時メッセージフラグ
	Public SSS_BILFL As Short 'ビリング発行区分(1:発行/9:なし)
	Public SSS_INICnt As Short 'INI ファイル最終インデックス
	Public SSS_DeleteFl As Short '削除実行フラグ  98/03/19
	Public SSS_MainDe As Short 'Main 画面インデックス  98/03/19
	Public SSS_VALKB As Boolean '有効データ区分(True=明細行なしでの登録可)
	Public SSS_STRIPE_COLOR As Integer 'ストライプ色
	
	Public Const SSS_ReTryCnt As Short = 100 'ログファイルオープンリトライカウント
	'
	Public Const SSS_OK As Short = 1 'ウインドウにて使用
	Public Const SSS_NEXT As Short = 2 '
	Public Const SSS_NPSN As Short = 3 '
	Public Const SSS_RPSN As Short = 4 '
	Public Const SSS_END As Short = 5 '
	Public Const SSS_SKIP As Short = 6 '
	
	Public Const SSS_STRIPE_ET As Integer = &HFFFFC0 '
	Public Const SSS_STRIPE_DL As Integer = &HC0FFC0 '
	Public Const SSS_STRIPE_MR As Integer = &HFFFFC0 '
	Public Const SSS_STRIPE_MT As Integer = &HFFFFC0 '
	
	Public SSS_ZEIRT(8) As Decimal '消費税率（区分別配列）
	
	'#Start(2003.3.28) ロングファイルネーム環境に対応
	Public Const MAX_PATH As Short = 260
	'#End(2003.3.28)
	
	'2001/04 時間測定用変数 → 所要時間測定用ルーチン(PutLogTime)で使用
	Public SSS_SttTm As Object
	Public SSS_FinTm As Object
	Public TimeMode As Short
	
	'2001/04 リードオンリーモード
	Public SSS_ReadOnly As Short
	
	'ファイル構造体初期化用データ
	Structure DB_CLRDAT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(2048),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2048)> Public FILLER() As Char '初期化データ
	End Structure
	Public DB_CLRREC As DB_CLRDAT
	
	' 請求関係
	Structure TYPE_SME
		Dim SMEDT As String
		Dim KESDT As String
	End Structure
	'
	Dim SPSN As Short
	Structure ITM_PKG
		Dim ST As Short
		Dim ITM As String
	End Structure
	Dim ITMPKG As ITM_PKG
	'
	Public SSS_MSTKB As New VB6.FixedLengthString(1) 'マスタ区分
	Public Const MSTKB_TOKMTA As String = "1" '  得意先マスタ区分
	Public Const MSTKB_NHSMTA As String = "2" '  納品先マスタ区分
	Public Const MSTKB_TANMTA As String = "3" '  担当者マスタ区分
	Public Const MSTKB_SIRMTA As String = "4" '  仕入先マスタ区分
	Public Const MSTKB_HINMTA As String = "5" '  商品マスタ区分
	Public Const MSTKB_BMNMTA As String = "6" '  部門マスタ区分
	'
	' eee モード
	'
	Public Const EEEMODE_APPEND As Short = 1 ' 追加
	Public Const EEEMODE_SELECT As Short = 2 ' 選択
	Public Const EEEMODE_INQUIRE As Short = 3 ' 問合せ
	Public Const EEEMODE_UPDATE As Short = 4 ' 更新
	
	' Function パラメータ
	' MsgBox パラメータ
	Public Const MB_OK As Short = 0 ' OK ボタンのみ
	Public Const MB_OKCANCEL As Short = 1 ' OK と ｷｬﾝｾﾙ ボタン
	Public Const MB_ABORTRETRYIGNORE As Short = 2 ' 中止, 再試行, 無視 ボタン
	Public Const MB_YESNOCANCEL As Short = 3 ' はい, いいえ, ｷｬﾝｾﾙ ボタン
	Public Const MB_YESNO As Short = 4 ' はい, いいえ ボタン
	Public Const MB_RETRYCANCEL As Short = 5 ' 再試行 と ｷｬﾝｾﾙ ボタン
	
	Public Const MB_ICONSTOP As Short = 16 ' 警告
	Public Const MB_ICONQUESTION As Short = 32 ' 確認
	Public Const MB_ICONEXCLAMATION As Short = 48 ' 注意
	Public Const MB_ICONINFORMATION As Short = 64 ' インフォメーションのアイコン
	
	Public Const MB_APPLMODAL As Short = 0 ' アプリケーション モーダル
	Public Const MB_DEFBUTTON1 As Short = 0 ' 第 1 ボタンをデフォルトにする
	Public Const MB_DEFBUTTON2 As Short = 256 ' 第 2 ボタンをデフォルトにする
	Public Const MB_DEFBUTTON3 As Short = 512 ' 第 3 ボタンをデフォルトにする
	Public Const MB_SYSTEMMODAL As Short = 4096 ' システム モード
	
	' MsgKB メッセージ種別
	Public Const SSS_GINFO As String = "9" ' アイテムに対する説明
	Public Const SSS_EEE As String = "0" ' ｅｅｅのメッセージ
	Public Const SSS_CONFRM As String = "1" ' 確認メッセージ
	Public Const SSS_ERROR As String = "2" ' ＳＳＳエラーメッセージ
	Public Const SSS_CINFO As String = "3" ' ＳＳＳプロンプト表示
	' MsgBox ボタンの戻り値
	Public Const IDOK As Short = 1 ' OK ボタン
	Public Const IDCANCEL As Short = 2 ' ｷｬﾝｾﾙ ボタン
	Public Const IDABORT As Short = 3 ' 中止 ボタン
	Public Const IDRETRY As Short = 4 ' 再試行 ボタン
	Public Const IDIGNORE As Short = 5 ' 無視 ボタン
	Public Const IDYES As Short = 6 ' はい ボタン
	Public Const IDNO As Short = 7 ' いいえ ボタン
	
	'[印刷] ダイアログ フラグ
	Public Const PD_ALLPAGES As Integer = &H0
	Public Const PD_SELECTION As Integer = &H1
	Public Const PD_PAGENUMS As Integer = &H2
	Public Const PD_NOSELECTION As Integer = &H4
	Public Const PD_NOPAGENUMS As Integer = &H8
	Public Const PD_COLLATE As Integer = &H10
	Public Const PD_PRINTTOFILE As Integer = &H20
	Public Const PD_PRINTSETUP As Integer = &H40
	Public Const PD_NOWARNING As Integer = &H80
	Public Const PD_RETURNDC As Integer = &H100
	Public Const PD_RETURNIC As Integer = &H200
	Public Const PD_RETURNDEFAULT As Integer = &H400
	Public Const PD_SHOWHELP As Integer = &H800
	Public Const PD_USEDEVMODECOPIES As Integer = &H40000
	Public Const PD_DISABLEPRINTTOFILE As Integer = &H80000
	Public Const PD_HIDEPRINTTOFILE As Integer = &H100000
    '
    '
    '==========================================================================
    '   SYSTBE       運用ログ定義体                                           =
    '==========================================================================
    '20190806 DELL START
    '   Structure TYPE_DB_SYSTBE
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public PRGID() As Char 'プログラムID          X(8)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(60),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=60)> Public LOGNM() As Char '備考(ｴﾗｰ情報・運用)   X(60)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      X(8)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      X(05)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ（時間）      9(06)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ（日付）      9(08)
    'End Structure
    'Public DB_SYSTBE As TYPE_DB_SYSTBE
    'Public DBN_SYSTBE As Short
    '20190806 DELL END

    '==========================================================================
    '   LINK_IN,OUT   連携レコード定義体                                      =
    '==========================================================================
    Structure TYPE_LINK
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public DENNO() As Char '伝票番号          X(8)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public DENDT() As Char '伝票日付          X(8)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public TOKCD() As Char '得意先CD          X(6)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public SIRCD() As Char '仕入先CD          X(6)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public NHSCD() As Char '納品先CD          X(6)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public BMNCD() As Char '部門CD            X(6)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(16),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=16)> Public HINCD() As Char '商品CD            X(16)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public SOUCD() As Char '倉庫ｺｰﾄﾞ          X(3)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(41),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=41)> Public FILLER() As Char
	End Structure
	Public Link_IN As TYPE_LINK
	Public Link_OUT As TYPE_LINK
	'
	Structure TYPE_LINK_CLR
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(100),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=100)> Public FILLER() As Char
	End Structure
	Public Link_Clr As TYPE_LINK_CLR
	'
	Public Link_ON As Short 'プログラムリンク判定用フラグ
	Public Link_Index As Short 'プログラムリンク用インデックス
	
	''2001/06/11 画面圧縮機能
	Private Structure TYPE_BAR
		Dim ctr As System.Windows.Forms.Control ' バーコントロール
		Dim iBarCnt As Short ' バー格納コントロール数
		Dim ctrBars() As System.Windows.Forms.Control ' バー格納コントロール
	End Structure
	
	Private Structure TYPE_RELINFO
		Dim ctr As System.Windows.Forms.Control ' 隣接コントロール
		Dim bJstFg As Boolean ' 左隣接=底辺、下隣接=左辺と一致
	End Structure
	
	Private Structure TYPE_CTRLINFO
		Dim nLeft As Integer ' Left値
		Dim nTop As Integer ' Top値
		Dim nHeight As Integer ' Height値
		Dim nWidth As Integer ' Width値
		Dim ctr As System.Windows.Forms.Control ' コントロール
		Dim iLeftCnt As Short ' 左隣接コントロール数
		Dim tLefts() As TYPE_RELINFO ' 左隣接コントロール
		Dim iDownCnt As Short ' 下隣接コントロール数
		Dim tDowns() As TYPE_RELINFO ' 下隣接コントロール
	End Structure
	
	Private Structure TYPE_CTRLGRP
		Dim sGrpNm As String ' コンテナグループ名
		Dim iCtrCnt As Short ' コントロール数
		Dim tCtrs() As TYPE_CTRLINFO ' コントロール情報
	End Structure
	Public gs_kengen As String
	Public gs_ari As String
	Public gs_userid As String
	Public gs_pgid As String
	Public gs_UPDAUTH As String
	Public gs_PRTAUTH As String
	Public gs_FILEAUTH As String
	Public gs_SALTAUTH As String
	Public gs_HDNTAUTH As String
	Public gs_SAPMAUTH As String
	
	'**************************************************************************************************
	'プロシジャ名   ：Get_Authority
	'処理概要       ：プログラムの実行権限を取得する
	'                 CrystalReportのプレビュー画面の印刷ボタンをユーザ権限によって制御する
	'引数   １：ec_DATE(担当者の適用日を判断する日付)
	'       ２：ec_CRW(CrystalReportコントロール名) オプション
	'戻値   1：権限マスタにデータ有り
	'       9：権限マスタにデータなし
	'**************************************************************************************************
	Public Function Get_Authority(ByRef ec_DATE As String, Optional ByRef ec_CRW As Object = Nothing) As String
		
		'変数宣言
		Dim ls_sql As String
		'Dim Usr_Ody As U_Ody
		
		'初期値は全権限なし
		gs_UPDAUTH = "9" '更新権限
		gs_PRTAUTH = "9" '印刷権限
		gs_FILEAUTH = "9" 'ファイル出力権限
		gs_SALTAUTH = "9" '販売単価変更権限
		gs_HDNTAUTH = "9" '発注単価変更権限
		gs_SAPMAUTH = "9" '販売計画年初計画修正権限
		
		'ユーザIDから印刷権限を取得する
		ls_sql = "  SELECT "
		ls_sql = ls_sql & " K.UPDAUTH,"
		ls_sql = ls_sql & " K.PRTAUTH,"
		ls_sql = ls_sql & " K.FILEAUTH,"
		ls_sql = ls_sql & " K.SALTAUTH,"
		ls_sql = ls_sql & " K.HDNTAUTH,"
		ls_sql = ls_sql & " K.SAPMAUTH "
		ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
		ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
		ls_sql = ls_sql & "   AND K.PGID    = '" & SSS_PrgId & "'"
		ls_sql = ls_sql & "   AND K.DATKB   = '1'"
		ls_sql = ls_sql & "   AND T.TANCD   = '" & SSS_OPEID.Value & "'"
		ls_sql = ls_sql & "   AND T.DATKB   = '1'"
		
		'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		Call DB_GetSQL2(DBN_KNGMTB, ls_sql)
		
		If DBSTAT <> 0 Then
			'取得データなしの場合は権限なしとみなす。
			Get_Authority = CStr(9)
		Else
			Do Until DBSTAT <> 0
				' gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")      '更新権限
				' gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")      '印刷権限
				' gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")    'ファイル出力権限
				' gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")    '販売単価変更権限
				' gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")    '発注単価変更権限
				' gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")    '販売計画年初計画修正権限
				gs_UPDAUTH = DB_KNGMTB.UPDAUTH
				gs_PRTAUTH = DB_KNGMTB.PRTAUTH
				gs_FILEAUTH = DB_KNGMTB.FILEAUTH
				gs_SALTAUTH = DB_KNGMTB.SALTAUTH
				gs_HDNTAUTH = DB_KNGMTB.HDNTAUTH
				gs_SAPMAUTH = DB_KNGMTB.SAPMAUTH
				
				'次レコード
				'  Call DB_GetNext(Usr_Ody)
				Call DB_GetNext(DBN_KNGMTB, BtrNormal)
			Loop 
			Get_Authority = CStr(1)
		End If
		
		If ec_CRW Is Nothing Then
		Else
			If gs_PRTAUTH = "1" Then
				'印刷権限がある場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowPrintBtn = True '印刷ボタン
			Else
				'印刷権限が無い場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowPrintBtn = False '印刷ボタン
			End If
			If gs_FILEAUTH = "1" Then
				'エクスポート権限がある場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowExportBtn = True 'エクスポートボタン
			Else
				'エクスポート権限が無い場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowExportBtn = False 'エクスポートボタン
			End If
		End If
		
	End Function
	
	
	
	
	
	
	''
	'
	Function Get_SMEDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pdendt As String, ByVal pnext As Short) As String
		' 請求締日算出（日）  締初期日付／締サイクル／伝票日付／帳端区分
		Dim mm, dd, yy As Short
		Dim cnt, I As Short
		Dim idx, setidx, addMM As Short
		Dim smeday(15) As Short
		'
		yy = Year(CDate(pdendt))
		mm = Month(CDate(pdendt))
		dd = VB.Day(CDate(pdendt))
		'
		If psmecc = 1 Then '毎日締め
			Get_SMEDT1 = CStr(DateSerial(yy, mm, dd + pnext))
			Exit Function
		End If
		'
		If psmecc <= 0 Or psmecc > 15 Then psmecc = 30
		cnt = Int(30 / psmecc) '締回数／月
		setidx = False
		For I = 0 To cnt - 1
			smeday(I) = psmedd + psmecc * I
			If smeday(I) > 27 Then smeday(I) = 99
			If dd <= smeday(I) And setidx = False Then
				idx = I + pnext '該当日付の締日配列添字
				setidx = True
			End If
		Next I
		If setidx = False Then idx = cnt + pnext
		addMM = Int(idx / cnt)
		idx = idx Mod cnt
		If idx < 0 Then idx = idx + cnt
		'
		If smeday(idx) = 99 Then
			Get_SMEDT1 = CStr(DateSerial(yy, mm + addMM + 1, 0))
		Else
			Get_SMEDT1 = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
		End If
	End Function
	
	Function Get_Acedt(ByVal wdate As String) As String
		' 該当経理締日付
		'
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("日付エラー(Get_Acedt): " & wdate)
		End If
		If DB_SYSTBA.SMADD > "27" Then
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
		ElseIf Right(wdate, 2) <= DB_SYSTBA.SMADD Then 
			Get_Acedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBA.SMADD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, SSSVal(DB_SYSTBA.SMADD)))
		End If
	End Function
	
	Function Get_STTSMEDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pdendt As String) As String
		' 請求開始日付算出（日）  締初期日付／締サイクル／伝票日付
		Dim mm, dd, yy As Short
		Dim cnt, I As Short
		Dim idx, setidx, addMM As Short
		Dim smeday(15) As Short
		'
		yy = Year(CDate(pdendt))
		mm = Month(CDate(pdendt))
		dd = VB.Day(CDate(pdendt))
		'
		If psmecc = 1 Then '毎日締め
			Get_STTSMEDT1 = pdendt '当日を返す
			Exit Function
		End If
		'
		If psmecc <= 0 Or psmecc > 15 Then psmecc = 30
		cnt = Int(30 / psmecc) '締回数／月
		setidx = False
		For I = 0 To cnt - 1
			smeday(I) = psmedd + psmecc * I
			If smeday(I) > 27 Then smeday(I) = 99
			If dd <= smeday(I) And setidx = False Then
				idx = I - 1 '該当日付の前の締日配列添字
				setidx = True
			End If
		Next I
		If setidx = False Then idx = cnt - 1
		addMM = Int(idx / cnt)
		If idx < 0 Then idx = idx + cnt
		'
		If smeday(idx) = 99 Then
			Get_STTSMEDT1 = CStr(DateSerial(yy, mm, 1))
		Else
			Get_STTSMEDT1 = CStr(DateSerial(yy, mm + addMM, smeday(idx) + 1))
		End If
	End Function
	
	Function CHECK_DATE(ByVal DT As Object) As Short
		' 日付の汎用チェック（２０５０年まで有効）
		'
		On Error GoTo ErrDate
		'UPGRADE_WARNING: オブジェクト DT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IsDate(DT) And Year(DT) <= 2050 And Year(DT) >= 1900 Then
			CHECK_DATE = True
		Else
ErrDate: 
			CHECK_DATE = False
		End If
	End Function
	
	Sub Clr_Prompt(ByRef PP As clsPP)
		' SSS/Win で表示したプロンプトメッセージを消します。
		'
		Call AE_StatusClear(PP, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE))
	End Sub
	
	Function CNV_DATE(ByRef pdate As String) As String
		'
		'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(pdate) = 8 Then
			CNV_DATE = LeftWid(pdate, 4) & "/" & MidWid(pdate, 5, 2) & "/" & RightWid(pdate, 2)
			'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(pdate) = 6 Then 
			CNV_DATE = LeftWid(pdate, 2) & "/" & MidWid(pdate, 3, 2) & "/" & RightWid(pdate, 2)
		Else
			CNV_DATE = ""
		End If
	End Function
	
	Function DCMFRC(ByRef IN_SU As Decimal, ByRef MARUME As Decimal, ByRef KETA As Decimal) As Decimal
		'  IN_SU:被編集数値, MARUME:まるめパラメータ
		'  KETA:まるめる桁位置(少数第1位が0 少数第2位が-1 整数1の位が1 整数2の位が2)
		Dim WL_MARUME, WL_KETA, WL_SU As Decimal
		WL_KETA = 10 ^ KETA
		WL_MARUME = MARUME / 10
		If IN_SU < 0 Then
			WL_SU = IN_SU / WL_KETA - WL_MARUME
			DCMFRC = Fix(WL_SU) * WL_KETA
		Else
			WL_SU = IN_SU / WL_KETA + WL_MARUME
			DCMFRC = Int(WL_SU) * WL_KETA
		End If
	End Function
	
	Function DeCNV_DATE(ByRef pdate As String) As String
		'
		'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(pdate) = 10 Then
			DeCNV_DATE = LeftWid(pdate, 4) & MidWid(pdate, 6, 2) & RightWid(pdate, 2)
			'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(pdate) = 8 Then 
			DeCNV_DATE = LeftWid(pdate, 2) & MidWid(pdate, 4, 2) & RightWid(pdate, 2)
		Else
			DeCNV_DATE = ""
		End If
	End Function
	
	Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
		'[V4.1]　メッセージ出力時にPPを退避　以下追加
		'※メイン画面からのメッセ-ジ出力のみ対応。サブ画面未対応。
		Dim WK_PP As clsPP
		'UPGRADE_WARNING: オブジェクト WK_PP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WK_PP = PP_SSSMAIN
        '[V4.1]　メッセージ出力時にPPを退避　以上追加
        ' SSS/Win 共通のメッセージを表示します。
        '
        ''Close後はメッセージを表示しない
        '20190807 DELL START
        'If RsOpened(DBN_SYSTBH) = False Then Exit Function
        '20190807 DELL END
        ''
        DB_SYSTBH.MSGNM = msgName
        '20190806 CHG START
        'Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & VB6.Format(MSGSQ, "0"), BtrNormal)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE MSGKB = '" & MSGKB & "'"
        sqlWhereStr = sqlWhereStr & " AND MSGNM = '" & DB_SYSTBH.MSGNM & "'"
        Call GetRowsCommon("SYSTBH", sqlWhereStr)

        If DB_SYSTBH.MSGKB Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190806 CHG END
        If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.ICNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNON) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSP_MsgBox = MsgBox(Trim(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim(SSS_PrgNm))
		Else
			MsgBox("メッセージファイルエラー  " & Chr(13) & Chr(13) & "DBSTAT=" & VB6.Format(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & VB6.Format(MSGSQ, "0"), MsgBoxStyle.OKOnly, Trim(SSS_PrgNm))
			Call Error_Exit("メッセージファイルエラー!")
		End If
		'[V4.1]　メッセージ出力時にPPを退避　以下追加
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN = WK_PP
		'[V4.1]　メッセージ出力時にPPを退避　以上追加
	End Function
	
	Sub Dsp_Prompt(ByRef msgName As String, ByRef MSGSQ As Short, Optional ByRef vForm As Object = Nothing)
		Dim COLCD As Integer
		'
		DB_SYSTBH.MSGNM = msgName
		Call DB_GetEq(DBN_SYSTBH, 1, SSS_CINFO & DB_SYSTBH.MSGNM & VB6.Format(MSGSQ, "0"), BtrNormal)
		Dim wForm As System.Windows.Forms.Form
		If DBSTAT = 0 Then
			Select Case DB_SYSTBH.COLSQ
				Case "1"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
				Case "2"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_RED)
				Case "3"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_GREEN)
				Case "4"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_YELLOW)
				Case "5"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE)
				Case "6"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_MAGENTA)
				Case "7"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_CYAN)
				Case "8"
					COLCD = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
			End Select
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If IsNothing(vForm) Then
				CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = DB_SYSTBH.MSGCM
				CType(FR_SSSMAIN.Controls("TX_Message"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(COLCD)
			Else
				wForm = vForm
				CType(wForm.Controls("TX_Message"), Object).Text = DB_SYSTBH.MSGCM
				CType(wForm.Controls("TX_Message"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(COLCD)
			End If
		End If
	End Sub
	
	Function Dsp_PromptGen(ByRef msgName As String, ByRef MSGSQ As Short) As String
		' 標準ジェネレートメッセージの表示
		'
		DB_SYSTBH.MSGNM = msgName
		Call DB_GetEq(DBN_SYSTBH, 1, SSS_GINFO & DB_SYSTBH.MSGNM & VB6.Format(MSGSQ, "0"), BtrNormal)
		If DBSTAT = 0 Then
			Dsp_PromptGen = Trim(DB_SYSTBH.MSGCM)
		Else
			Call Error_Exit("メッセージファイルエラー!")
		End If
	End Function
	
	Sub Error_Exit(ByVal ErrorMsg As String)
		Dim rtn As Object
		Dim I As Short
		'
		Call SSSWIN_LOGWRT(ErrorMsg)
		MsgBox("プログラムを終了します。", MsgBoxStyle.OKOnly, Trim(SSS_PrgNm))
		'
		If DBSTAT <> 0 Then
			MsgBox("エラーログの書き込みエラー ! Windows を再起動してください")
			'
		Else
			For I = SSS_MAX_DB - 1 To 0 Step -1
				Call DB_NCCLOSE(I)
			Next I
		End If
		Call DB_End()
		'UPGRADE_WARNING: オブジェクト rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
		End
	End Sub
	
	Function FillVal(ByVal ch As String, ByVal cnt As Short) As Object
		' 指定された文字を指定回数分連結する。
		Dim I As Short
		Dim rtn As String
		'
		For I = 1 To cnt
			rtn = rtn & ch
		Next I
		'UPGRADE_WARNING: オブジェクト FillVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FillVal = rtn
	End Function
	
	Function Get_BGNAcedt(ByVal yy As Short, ByVal mm As Short) As String
		' 当期開始日付
		Dim wdate, acedt As String
		Dim mmdd(1) As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("日付エラー(Get_BGNAcedt): " & yy & mm)
		End If
		acedt = Get_STTTouAcedt(yy, mm)
		mmdd(1) = RightWid(acedt, 5)
		'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBA.SMADD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mmdd(0) = RightWid(CStr(DateSerial(1995, SSSVal(DB_SYSTBA.SMAMM), SSSVal(DB_SYSTBA.SMADD) + 1)), 5)
		'
		If mmdd(0) > mmdd(1) Then
			Get_BGNAcedt = VB6.Format(Year(CDate(acedt)) - 1, "0000") & "/" & mmdd(0)
		Else
			Get_BGNAcedt = VB6.Format(Year(CDate(acedt)), "0000") & "/" & mmdd(0)
		End If
	End Function
	
	Function Get_KESDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pkesmm As Short, ByVal pkesdd As Short, ByVal pdate As String) As String
		' 回収日付算出（日）  締初期日付／締サイクル／回収サイクル／回収日／今回締日
		Dim dd As Short
		'
		If psmecc = 1 Then
			Get_KESDT1 = pdate
			Exit Function
		End If
		'
		If pkesdd = 99 Then pkesdd = 30
		If pkesdd > 27 Then
			Get_KESDT1 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)) + pkesmm + 1, 0))
		Else
			Get_KESDT1 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)) + pkesmm, pkesdd))
		End If
	End Function
	
	Function Get_KESDT2(ByVal psmedd As Short, ByVal pkesmm As Short, ByVal pkesdd As Short, ByVal pdate As String) As String
		' 回収日付算出（曜日）  締初期日付／回収サイクル／回収日／伝票日付
		'
		Get_KESDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + pkesmm * 7 + pkesdd - psmedd))
	End Function
	
	Function Get_SMEDT2(ByVal psdwkb As Short, ByRef pdate As String, ByRef pnext As Short) As String
		' 請求締日付算出（曜日）
		'
		If WeekDay(CDate(pdate)) > psdwkb Then
			Get_SMEDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + (7 - WeekDay(CDate(pdate)) + psdwkb) + (7 * pnext)))
		Else
			Get_SMEDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + (psdwkb - WeekDay(CDate(pdate))) + (7 * pnext)))
		End If
	End Function
	
	Function Get_STTTouAcedt(ByVal yy As Short, ByVal mm As Short) As String
		'当月経理開始日付
		Dim wdate As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("日付エラー(Get_STTTouAcedt): " & yy & mm)
		End If
		If DB_SYSTBA.SMADD > "27" Then
			Get_STTTouAcedt = LeftWid(wdate, 8) & "01"
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBA.SMADD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Get_STTTouAcedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) - 1, SSSVal(DB_SYSTBA.SMADD) + 1))
		End If
	End Function
	
	Function Get_TouAcedt(ByVal yy As Short, ByVal mm As Short) As String
		' 当月経理締日付
		Dim wdate As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("日付エラー(Get_TouAcedt): " & yy & mm)
		End If
		If DB_SYSTBA.SMADD > "27" Then
			Get_TouAcedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
		Else
			Get_TouAcedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		End If
	End Function
	
	Function HighValue(ByRef cnt As Short) As String
		HighValue = New String(Chr(122), cnt)
	End Function
	
	Sub Init_Prompt()
        ' プロンプト表示領域を初期化します。
        '20190807 DELL START
        '      CType(FR_SSSMAIN.Controls("IM_Denkyu"), Object)(0).Image = CType(FR_SSSMAIN.Controls("IM_Denkyu"), Object)(1).Image
        'CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
        'CType(FR_SSSMAIN.Controls("TX_Message"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&H0)
        '20190807 DELL END
    End Sub
	
	Function JSTDT(ByVal IN_DT As String) As String
		Dim FormatDate As String
		Dim dd, yy, mm, I As Decimal
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(LeftWid(IN_DT, 4))
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(MidWid(IN_DT, 5, 2))
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		dd = SSSVal(MidWid(IN_DT, 7, 2))
		If dd > 27 Then
			dd = 0
			I = 31
			Do While (I > 27) And (dd = 0)
				FormatDate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/" & VB6.Format(I, "00")
				If IsDate(FormatDate) Then
					dd = I
				End If
				I = I - 1
			Loop 
		End If
		JSTDT = VB6.Format(yy * 10000 + mm * 100 + dd, "00000000")
	End Function
	
	'モーダルリンク関数
	'エラーコードに注意（Link_Shell関数は戻り値 0 がエラー）
	'      * VBEXEC1関数の戻り値
	'              0 : 正常.
	'          10001 : 起動失敗.
	'             -4 : タイマ設定失敗.
	'             -5 : 終了監視中に呼び出し元から再度呼ばれた.
	'           -999 : 強制終了.
	'
	Function Link_Modal(ByVal EXE_NM As String) As Short
		Dim Rtc As Object
		Dim Full_Nm As String
		On Error Resume Next
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'Link_Clr = LSet(Link_OUT)
        '20190806 CHG END
        Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & SSS_CLTID.Value & SSS_OPEID.Value & ":" & Link_Clr.FILLER & Chr(34)
		Link_Modal = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, Full_Nm)
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'Link_Clr = LSet(Link_IN)
        '20190806 DELL END
    End Function
	
	Function Link_Shell(ByVal EXE_NM As String) As Short
		Dim Rtc As Short
		Dim Full_Nm As String
		On Error Resume Next
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'Link_Clr = LSet(Link_OUT)
        '20190806 DELL END
        Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & LeftWid(SSS_CLTID.Value, 5) & LeftWid(SSS_OPEID.Value, 8) & ":" & Link_Clr.FILLER & Chr(34)
		Link_Shell = Shell(Full_Nm, 1)
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'Link_Clr = LSet(Link_IN)
        '20190806 DELL END
        If Link_ON Then 'メニュー起動でない場合には終了する
			SSS_NoMsg_EXIT()
		End If
	End Function
	
	Function SSS_EDTITM_EEE(ByRef CP As clsCP, ByVal Item As Object, ByVal De As Object) As Object
		Dim WrkStr As Object
		On Error GoTo ErrEdit
		'UPGRADE_WARNING: オブジェクト Item の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WrkStr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WrkStr = IIf(Item = 0, Nothing, FormatAndRound(Item, CP.FormatChr))
		'UPGRADE_WARNING: オブジェクト LenWid(WrkStr) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(WrkStr) > CP.MaxLength Then
			If CP.KeyInOkClass = Asc("C") Then
ErrEdit: 
				SSS_EDTITM_EEE = New String("*", CP.MaxLength)
			Else
				'UPGRADE_WARNING: オブジェクト WrkStr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SSS_EDTITM_EEE = RightWid(WrkStr, CP.MaxLength)
			End If
		Else
			'UPGRADE_WARNING: オブジェクト WrkStr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSS_EDTITM_EEE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSS_EDTITM_EEE = WrkStr
		End If
	End Function
	
	Function SSS_EDTITM_WLS(ByVal Item As Object, ByVal KETA As Object, ByVal HENSYU As Object) As String
		Select Case HENSYU
			Case "0"
				'UPGRADE_WARNING: オブジェクト KETA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SSS_EDTITM_WLS = RightWid(FormatAndRound(Item, "00000000000000000000"), KETA)
			Case Else
				'UPGRADE_WARNING: オブジェクト Item の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SSS_EDTITM_WLS = Item
		End Select
	End Function
	
	Function SSS_GETITM(ByRef TStr As String, ByRef DChar As String, ByRef ItmNo As Short) As String
		Dim I As Short
		'
		SPSN = 1
		Do 
			Call SSS_GETITMS(TStr, DChar)
			I = I + 1
		Loop Until I = ItmNo Or ITMPKG.ST = False
		If I = ItmNo Then
			SSS_GETITM = ITMPKG.ITM
		Else
			SSS_GETITM = ""
		End If
	End Function
	
	Sub SSS_GETITMS(ByRef TStr As String, ByRef DChar As String)
		Dim L, EPSN As Short
		'
		EPSN = InStr(SPSN, TStr, DChar)
		If EPSN = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			L = LenWid(TStr)
			If SPSN <= L Then
				ITMPKG.ST = True
				ITMPKG.ITM = MidWid(TStr, SPSN, L - SPSN + 1)
				SPSN = L + 1
			Else
				ITMPKG.ST = False
				ITMPKG.ITM = ""
			End If
		Else
			ITMPKG.ST = True
			ITMPKG.ITM = MidWid(TStr, SPSN, EPSN - SPSN)
			SPSN = EPSN + 1
		End If
	End Sub
	
	Function SSS_UPLCHAR(ByVal VST As String) As String
		' 引数の最後文字のアスキー値を繰り上げる
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If VST = HighValue(LenWid(VST)) Then
			SSS_UPLCHAR = VST
		Else
			Select Case LenWid(VST)
				Case 0
					SSS_UPLCHAR = VST
				Case 1
					SSS_UPLCHAR = Chr(Asc(VST) + 1)
				Case Else
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SSS_UPLCHAR = MidWid(VST, 1, LenWid(VST) - 1) & Chr(Asc(MidWid(VST, LenWid(VST), 1)) + 1)
			End Select
		End If
	End Function
	
	Function SSS_WEEKNM(ByVal idx As Short) As String
		' 曜日名を返す。
		Select Case idx
			Case 1
				SSS_WEEKNM = "日曜日"
			Case 2
				SSS_WEEKNM = "月曜日"
			Case 3
				SSS_WEEKNM = "火曜日"
			Case 4
				SSS_WEEKNM = "水曜日"
			Case 5
				SSS_WEEKNM = "木曜日"
			Case 6
				SSS_WEEKNM = "金曜日"
			Case 7
				SSS_WEEKNM = "土曜日"
			Case Else
				SSS_WEEKNM = ""
		End Select
	End Function
	
	Function SSSMAIN_ErrorMsg(ByVal Cd_Error As Object) As Object
		
	End Function
	
	Sub SSSWIN_CLOSE()
		Dim I As Short
		'
		For I = SSS_MAX_DB - 1 To 0 Step -1
			If Left(DB_PARA(I).DBID, 4) = "USR1" Or Trim(DB_PARA(I).DBID) >= "USR4" Then
				Call DB_Close(I)
				'            If DBSTAT <> 0 Then
				'                MsgBox ("ファイルＣＬＯＳＥエラー" + DB_PARA(i).tblid)
				'            End If
			Else
				Call JB_Close(I)
			End If
		Next I
		'
		Call SSS_CLOSE()
		Call SSSWIN_LOGWRT("プログラム終了")
	End Sub
	
	Sub SSSWIN_INIT()
		Dim I As Short
		Dim DT As Object
		Dim YMD As String
		'   日付形式チェック 1997/02/17 追加
		'UPGRADE_WARNING: オブジェクト DT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DT = Today
		'UPGRADE_WARNING: オブジェクト DT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		YMD = VB6.Format(Year(DT), "0000") & "/" & VB6.Format(Month(DT), "00") & "/" & VB6.Format(VB.Day(DT), "00")
		'UPGRADE_WARNING: オブジェクト DT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CStr(DT) <> YMD Then
			'UPGRADE_WARNING: オブジェクト DT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MsgBox("日付の形式 '" & CStr(DT) & "' が違います。" & vbCrLf & "コントロールパネルの地域（地球の絵）の日付" & vbCrLf & "の短い形式を yyyy/MM/dd に変更して下さい。", MsgBoxStyle.Critical)
			Call Error_Exit("日付の形式が違います。")
		End If
		'---------------------
		' 起動パラメータ設定
		'---------------------
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		I = LenWid(Trim(VB.Command()))
		If I < 15 Then
			MsgBox("メニューから実行してください。", MsgBoxStyle.OKOnly, SSS_PrgNm)
			Call Error_Exit("メニューから実行してください。")
		End If
		SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
		SSS_OPEID.Value = MidWid(VB.Command(), 7, 8)
		Link_Clr.FILLER = ""
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20910806 DELL START
        'Link_OUT = LSet(Link_Clr)
        '20190806 DELL END
        Link_ON = False
		If I > 15 Then ' 1997/04/17
			Link_ON = True
			Link_Clr.FILLER = MidWid(VB.Command(), 16, I - 15) ' 1997/04/17
		End If
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'Link_IN = LSet(Link_Clr)
        '20190806 DELL END

        '2001/04 リードオンリーモード設定
        If Left(VB.Command(), 1) = "'" Then SSS_ReadOnly = True
		
		'---------------------
		' ﾃﾞｰﾀﾍﾞｰｽ初期処理
		'---------------------
		Call DB_Start("", "") ' 1997/02/12
		Call DB_SetPGID(SSS_PrgId)
		'プログラム名称をログに出力ため(2003.3.13)>>
		Call DB_SetPGNM(SSS_PrgNm)
		'<<(2003.3.13)
		
		'---------------------
		' SSSWIN.INI テーブル設定
		'---------------------
		SSS_INIDATNM(0) = "USR_PATH"
		SSS_INIDATNM(1) = "DAT_PATH"
		SSS_INIDATNM(2) = "PRG_PATH"
		SSS_INIDATNM(3) = "WRK_PATH"
		SSS_INIDATNM(4) = "IMG_PATH"
		SSS_INICnt = 4
		Call SSSWIN_INIT_GETINI()
        '20190806 DELL START
        '        Call Init_Fil()
        '20190806 DELL END

        ''2001/12/14 画面圧縮機能
        ''（画面が大きすぎる場合には, サイズを80%フォントを7.5Pに縮小）
        '20190806 DELL START
        'FormControls(FR_SSSMAIN)
        '20190806 DELL END
        '
        PP_SSSMAIN.FormWidth = VB6.PixelsToTwipsX(FR_SSSMAIN.Width)
		PP_SSSMAIN.FormHeight = VB6.PixelsToTwipsY(FR_SSSMAIN.Height)
		FR_SSSMAIN.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(FR_SSSMAIN.Height)) / 2)
		FR_SSSMAIN.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(FR_SSSMAIN.Width)) / 2)
		''''''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更の為、SSSWIN_OPENでセット(DEL-START)
		''''FR_SSSMAIN!SYSDT.Caption = Format$(Now, "YYYY/MM/DD")
		''''''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更の為、SSSWIN_OPENでセット(DEL-E N D)
		FR_SSSMAIN.Icon = ICN_ICON.Icon
		FR_SSSMAIN.Text = Trim(SSS_PrgNm)
		
		''2001/12/14 場所を８行上に変更
		''2001/06/11 画面圧縮機能
		''（画面が大きすぎる場合には, サイズを80%フォントを7.5Pに縮小）
		'FormControls FR_SSSMAIN
		
		AE_Title = SSS_PrgId
		
		'2001/04 時間測定モードかどうか
		Call SetTimeLog()
	End Sub
	
	Sub SSSWIN_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI 読込み
		'---------------------
		For I = 0 To SSS_INICnt
            rtnPara.Value = ""
            '20190806 CHG START Application.StartupPath & "\
            'LENGTH = GetPrivateProfileString("SSSWIN", SSS_INIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
            LENGTH = GetPrivateProfileString("SSSWIN", SSS_INIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), Application.StartupPath & "\SSSWIN.INI")
            '20190806 CHG END
            If LENGTH = 0 Then
				MsgBox("SSSWIN.INI を確認してください。" & Chr(13) & "[" & SSS_INIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI を確認してください。[" & SSS_INIDATNM(I) & "]")
			Else
				'#Start(2003.4.3) 長いパス、全角文字含むパス対応
				'SSS_INIDAT(I) = Left$(rtnPara, LENGTH)
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
				'#End(2003.4.3)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub

    Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
        '20190806 ADD START
        Dim li_MsgRtn As Integer

        Try
            '20190806 ADD END

            Dim errcnt, Fno, rtn As Short
        Dim wbuf As String
        '
        Call ResetDBSTAT(DBN_SYSTBE)
        '
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '20190806 DELL START
        'DB_SYSTBE = LSet(DB_CLRREC)
        '20190806 DELL END
        DB_SYSTBE.PRGID = SSS_PrgId
        DB_SYSTBE.LOGNM = LogMsg
        DB_SYSTBE.OPEID = SSS_OPEID.Value
        DB_SYSTBE.CLTID = SSS_CLTID.Value
        DB_SYSTBE.WRTTM = VB6.Format(Now, "hhnnss")
        DB_SYSTBE.WRTDT = VB6.Format(Now, "YYYYMMDD")
        '
        errcnt = 0
        Fno = FreeFile()
        '20190806 DELL START
        'On Error Resume Next
        '20190806 DELL END
        'ディレクトリ存在チェック
        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        wbuf = Dir(SSS_INIDAT(1), 16)
        If wbuf = "" Then
            Call MsgBox("SSSWIN.INI の DAT_PATH の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
            'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
            Call SSS_CLOSE()
            rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            End
        End If
        Err.Clear()
        '20190806 DELL START
        'On Error GoTo ErrorLogFile
        'FileOpen(Fno, SSS_INIDAT(1) & "SYSTBE.DTA", OpenMode.Append, OpenAccess.Write, OpenShare.LockWrite)
        'On Error GoTo 0
        'PrintLine(Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT)
        '20190806 DELL END
        FileClose(Fno)
        Exit Sub
        '20190806 DELL START
        'ErrorLogFile:
        '        errcnt = errcnt + 1
        '        If errcnt > SSS_ReTryCnt Then
        '            If MsgBox("履歴ファイルロックエラー !" & Chr(13) & "中止しても宜しいですか？", 20) = 6 Then
        '                Call SSS_CLOSE()
        '                rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
        '                End
        '            Else
        '                errcnt = 0
        '            End If
        '        End If
        '        System.Windows.Forms.Application.DoEvents()
        '        Resume
        '20190806 DELL END
        '20190806 ADD START
        Catch ex As Exception
        li_MsgRtn = MsgBox("SSSWIN_LOGWRT" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally
        End Try
        '20190806 ADD END
    End Sub

    Sub SSSWIN_OPEN()
		Dim I As Short
		Dim DBFLocation As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
		Dim rtn As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'
		Call SSSWIN_LOGWRT("プログラム起動")
        '20190806 CHG  START
        '      For I = 0 To SSS_MAX_DB - 1
        '	If Trim(DB_PARA(I).DBID) = "USR1" Or Trim(DB_PARA(I).DBID) >= "USR4" Then
        '		Call DB_Open(I, DB_PARA(I).DBID, DB_PARA(I).tblid)
        '		If DBSTAT <> 0 Then
        '			MsgBox("ファイルＯＰＥＮエラー" & DB_PARA(I).tblid & Str(DBSTAT)) : End
        '		End If
        '	Else
        '		' Linkチェック外す 97/02/12
        '		Call JB_Open(I)
        '	End If
        'Next I
        CON = DB_START()
        For I = 0 To SSS_MAX_DB - 1
            RsOpened(I) = True
        Next I
        '20190806 CHG END
        '20190806 CHG START
        'Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
        If SYSTBA_SEARCH(DB_SYSTBA) <> 0 Then
            Exit Sub
        End If
        '20190806 CHG END
        ''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更(ADD-START)
        '20190806 CHG STAR
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190806 CHG END
        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!SYSDT.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190806 CHG START
        'CType(FR_SSSMAIN.Controls("SYSDT"), Object).Caption = CNV_DATE(DB_UNYMTA.UNYDT)
        CType(FR_SSSMAIN.Controls("FM_Panel3D14").Controls("SYSDT"), Object).Text = CNV_DATE(DB_UNYMTA.UNYDT)
        '20190806 CHG END
        ''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更(ADD-E N D)

        '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
        '権限取得
        '20190806 DELL START
        '      If Get_Authority(DB_UNYMTA.UNYDT) = "9" Then
        '	'起動権限なしの場合、処理終了
        'rtn = DSP_MsgBox(SSS_ERROR, "RUNAUTH", 0)
        '	End
        'End If
        '2019080627 CHG END
        '''' ADD 2009/11/26  FKS) T.Yamamoto    End

    End Sub
	
	Sub SSS_NoMsg_EXIT()
		Dim rtn As Object
		
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
		End
	End Sub
	
	Function SSSVal(ByRef INP_Value As Object) As Object
		If IsNumeric(INP_Value) = True Then
			'UPGRADE_WARNING: オブジェクト INP_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSVal = CDec(INP_Value)
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSVal = 0
		End If
	End Function
	
	'途中中止／フラグファイルの作成
	'vFname:プログラムＩＤ。必須
	'vPrgNm:中止ウィンドウ上表示されるプログラム名称。省略された場合は、SSS_PrgNmを使う
	'-----------------------
	Sub Make_infoFile(ByRef vFname As String, Optional ByRef vPrgNm As Object = Nothing)
		Dim wkFileStr As String
		Dim wkDATE As String
		Dim wkTime As String
		Dim cmdLine As String
		Dim ret As Double
		Dim wkSchema As String
		Dim wkPkgUsr As String
		Dim wkStr As New VB6.FixedLengthString(128)
		
		On Error Resume Next
		wkPkgUsr = "USR1"
		ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr.Value, Len(wkStr.Value), "SSSWIN.INI")
		If ret > 0 Then
			wkPkgUsr = Left(wkStr.Value, ret)
		End If
		wkSchema = Get_DbSchema(wkPkgUsr) 'スキーマ名
		wkFileStr = SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID.Value & ".flg"
		'クライアント専用フォルダに、PRGID_ｸﾗｲｱﾝﾄID.flg ファイルを落とす
		FileOpen(1, wkFileStr, OpenMode.Output)
		PrintLine(1, SSS_PrgId)
		PrintLine(1, SSS_PrgNm)
		wkDATE = VB6.Format(Now, "YYYY/MM/DD")
		PrintLine(1, wkDATE)
		wkTime = VB6.Format(Now, "HH:MM:SS")
		PrintLine(1, wkTime)
		FileClose(1)
		'中止用プログラムを起動
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(vPrgNm) Then
			cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID.Value & wkSchema & "_" & vFname & "$" & Trim(SSS_PrgNm)
		Else
			'UPGRADE_WARNING: オブジェクト vPrgNm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID.Value & wkSchema & "_" & vFname & "$" & Trim(vPrgNm)
		End If
		ret = Shell(cmdLine)
	End Sub
	
	'途中中止／フラグファイルの削除
	'vFname:プログラムＩＤ。
	'------------------------
	Sub Remove_infoFile(ByRef vFname As String)
		'make_infoFile でクライアント専用フォルダに作成したファイル（PRGID_ｸﾗｲｱﾝﾄID.flg）を削除する
		Dim wkSchema As String
		Dim wkPkgUsr As String
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		On Error Resume Next
		wkPkgUsr = "USR1"
		ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr.Value, Len(wkStr.Value), "SSSWIN.INI")
		If ret > 0 Then
			wkPkgUsr = Left(wkStr.Value, ret)
		End If
		wkSchema = Get_DbSchema(wkPkgUsr) 'スキーマ名
		Kill((SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID.Value & ".flg"))
	End Sub
	
	'2001/04 時間測定用ルーチン
	'Global SSS_SttTm
	'Global SSS_FinTm
	'Global TimeMode%
	'
	'測定結果を出力（FinTime - SttTime）
	Sub PutLogTime(ByVal logStr As String)
		Dim Fno As Short
		Dim ClcTime As Object
		Dim Logtime As String
		If Not TimeMode Then Exit Sub
		'UPGRADE_WARNING: オブジェクト SSS_SttTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSS_FinTm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ClcTime の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ClcTime = SSS_FinTm - SSS_SttTm
		Logtime = FormatAndRound(ClcTime, "###,##0.00")
		Fno = FreeFile
		On Error Resume Next
		FileOpen(Fno, SSS_INIDAT(3) & SSS_PrgId & ".Log", OpenMode.Append)
		PrintLine(Fno, logStr & vbTab & "(" & Logtime & ")" & vbTab & SSS_OPEID.Value & SSS_CLTID.Value & vbTab & Now)
		FileClose(Fno)
	End Sub
	
	'時間測定するかを SSSwin.Iniの情報で判定
	Sub SetTimeLog()
		Dim Buff As New VB6.FixedLengthString(50)
		Dim ret As Object
		Dim GetStr As String
		On Error Resume Next
		Buff.Value = " "
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSWIN", "TIMELOG", "", Buff.Value, Len(Buff.Value), "SSSWIN.INI")
		GetStr = UCase(Left(Buff.Value, InStr(Buff.Value, Chr(0)) - 1))
		If GetStr = "TRUE" Then TimeMode = True
	End Sub
	
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	' このサブルーチンでは、SYSTBHに登録してあるMSGKBは "S" と統一。
	' エラーメッセージを表示した後の処理は、アプリ側で行う
	' 補助メッセージExtMsgのある場合は、新たの行でそのメッセージを表示する
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Sub SSS_ERROR_CHECK(ByRef ErrCode As Short, ByRef tblName As String, ByRef SEQNO As String, ByRef ExtMsg As String)
		Dim ret As Short
		Dim wkMsg As String
		
		wkMsg = ""
		If Trim(G_PlCnd2.sErrMsg) <> "" Then wkMsg = Chr(13) & "--------------" & Chr(13) & Trim(G_PlCnd2.sErrMsg)
		
		Select Case ErrCode
			Case -20099 'SYSTBHに登録してあるメッセージを表示する
				DB_SYSTBH.MSGNM = tblName
				Call DB_GetEq(DBN_SYSTBH, 1, "S" & DB_SYSTBH.MSGNM & VB6.Format(SEQNO, "0"), BtrNormal)
				If DBSTAT = 0 Then
					'SYSTBHに該当メッセージが存在している場合
					If ExtMsg = "" Then
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.ICNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNON) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ret = MsgBox(Trim(DB_SYSTBH.MSGCM) & wkMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim(SSS_PrgNm))
					Else
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.ICNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNON) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ret = MsgBox(Trim(DB_SYSTBH.MSGCM) & Chr(13) & ExtMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim(SSS_PrgNm))
					End If
				Else
					'SYSTBHに該当メッセージが登録していない場合
					MsgBox("メッセージテーブルに登録されていないメッセージを表示しようとしました。" & Chr(13) & "テーブル名=[" & Trim(tblName) & "]" & Chr(13) & "連番=[" & VB6.Format(SEQNO, "0") & "]" & Chr(13) & "システムの開発サイドにご連絡下さい", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, SSS_PrgNm)
				End If
			Case -20005, 20005, -20006, 20006, -20007, 20007, -20008, 20008 'サーバ側ファイルＩ／Ｏエラー
				MsgBox("サーバ側のファイルＩ／Ｏ操作エラーが発生しました。" & Chr(13) & "サーバ側のログ用フォルダに問題があると思われます。" & Chr(13) & "システム管理者にご連絡下さい。" & wkMsg, MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, SSS_PrgNm)
			Case -20010, 20010 'ユーザによる中止された
				MsgBox("ユーザーにより実行が中止されました。" & wkMsg, MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, SSS_PrgNm)
			Case -20015, 20015 '順序が存在していない
				MsgBox("順序が未作成です。" & Chr(13) & "管理ツールで順序の作成／更新を行って下さい。" & wkMsg, MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, SSS_PrgNm)
			Case Else
				'オラクルの一般エラーの場合
				If ErrCode = -54 Then
					MsgBox("他のユーザによりデータがロックされています。" & Chr(13) & "暫らく待ってから再実行して下さい。" & wkMsg, MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, SSS_PrgNm)
				Else
					MsgBox("データベース側にエラーが発生しました。" & Chr(13) & "エラー番号 ＝［ " & Str(ErrCode) & " ］" & Chr(13) & "システム管理者にご連絡下さい。" & wkMsg, MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, SSS_PrgNm)
				End If
		End Select
	End Sub
	
	Function Get_EntryToPackage() As String
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim wkUsr As String
		Dim ret As Short
		Dim wkSchema As String
		
		wkUsr = "USR1"
		ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr.Value, Len(wkStr.Value), "SSSWIN.INI")
		If ret > 0 Then wkUsr = Left(wkStr.Value, ret)
		wkSchema = Get_DbSchema(wkUsr)
		Get_EntryToPackage = wkSchema & "." & SSS_PrgId & "_PACK.M_" & SSS_PrgId
	End Function
	
	Function Get_EntryToPackage2(ByVal vPack As String, ByVal vEntry As String) As String
		' 全てのフレームで使用可能
		'       vPack="HDNDL05" → HDNDL05_PACK, vPack = "" の時は、SSS_PrgID が使用される
		'       vEntry="M_xxxxxx","M2_xxxxxx","MW_xxxxxx"
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim wkUsr, wkDbhead, wkPack As String
		Dim ret As Short
		Dim wkSchema As String
		
		wkUsr = "USR1"
		ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr.Value, Len(wkStr.Value), "SSSWIN.INI")
		If ret > 0 Then wkUsr = Left(wkStr.Value, ret)
		wkSchema = Get_DbSchema(wkUsr)
		wkPack = SSS_PrgId
		If vPack <> "" Then wkPack = vPack
		Get_EntryToPackage2 = wkSchema & "." & wkPack & "_PACK." & vEntry
	End Function
	
	Sub Set_StripeColor(Optional ByRef vFraId As Object = Nothing)
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim wkFraId As String
		
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(vFraId) Then
			'通常のケース
			wkFraId = Left(SSS_FraId, 2)
		Else
			'DLからドリルダウンでETを呼出す場合など
			'UPGRADE_WARNING: オブジェクト vFraId の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkFraId = vFraId
		End If
		Select Case UCase(wkFraId)
			Case "ET"
				SSS_STRIPE_COLOR = SSS_STRIPE_ET
			Case "DL"
				SSS_STRIPE_COLOR = SSS_STRIPE_DL
			Case "MR"
				SSS_STRIPE_COLOR = SSS_STRIPE_MR
			Case "MT"
				SSS_STRIPE_COLOR = SSS_STRIPE_MT
		End Select
		'
		ret = GetPrivateProfileString("SSSWIN", "STRIPE_COLOR_" & wkFraId, "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then
			SSS_STRIPE_COLOR = CInt(Left(wkStr.Value, ret))
		Else
			ret = GetPrivateProfileString("SSSUSR", "STRIPE_COLOR_" & wkFraId, "", wkStr.Value, 128, SSS_INIDAT(0) & "SSSUSR.INI")
			If ret > 0 Then
				SSS_STRIPE_COLOR = CInt(Left(wkStr.Value, ret))
			End If
		End If
	End Sub
	
	Function Get_DBHEAD() As String
		'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function
	
	''2001/06/11 画面圧縮機能
	''2001/07/16 一部改訂
	''2001/11/09 画面情報はｅｅｅを利用
	' フォームの伸縮
	'   I   frm         フォーム
	'   I   gOptFntSz   フォントサイズ
	Public Sub FormControls(ByVal frm As System.Windows.Forms.Form, Optional ByVal gOptFntSz As Single = 0)
		On Error Resume Next
		Dim I, iGrpCnt As Short
		Dim nHeight, nLeft, nWidth As Integer
		Dim gFactor, gFntSz As Single
		Dim sFrmNm As String
		Dim ctr As System.Windows.Forms.Control
		'UPGRADE_WARNING: 構造体 tMsg の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		'UPGRADE_WARNING: 構造体 tTol の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim tTol, tMsg As TYPE_BAR
		Dim tGrps() As TYPE_CTRLGRP
		
		''2001/11/09 画面情報はｅｅｅを利用
		If PP_SSSMAIN.FormHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) Or PP_SSSMAIN.FormWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) Then
			''If frm.Height > Screen.Height Or frm.Width > Screen.Width Then
			gFactor = 0.8
			
			Select Case gOptFntSz
				Case 0, 7.5 : gFntSz = 7.5
				Case Else : gFntSz = 8
			End Select
			
			sFrmNm = frm.Name
			
			' バーコントロールの取得
			getBarControls(frm, tTol, tMsg)
			
			' 補正対象コントロールの設定
			getHoseiControls(frm, iGrpCnt, tGrps)
			
			' フォームの伸縮
			''2001/11/09 画面情報はｅｅｅを利用
			nHeight = calTwip(PP_SSSMAIN.FormHeight + 780, gFactor)
			nWidth = calTwip(PP_SSSMAIN.FormWidth + 120, gFactor)
			frm.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frm.Left) + calTwip(PP_SSSMAIN.FormWidth + 120 - nWidth, 0.5))
			frm.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frm.Top) + calTwip(PP_SSSMAIN.FormHeight + 780 - nHeight, 0.5))
			''nHeight = calTwip(frm.Height, gFactor)
			''nWidth = calTwip(frm.Width, gFactor)
			''frm.Left = frm.Left + calTwip(frm.Width - nWidth, 0.5)
			''frm.Top = frm.Top + calTwip(frm.Height - nHeight, 0.5)
			frm.Height = VB6.TwipsToPixelsY(nHeight)
			frm.Width = VB6.TwipsToPixelsX(nWidth)
			
			' コントロールの伸縮
			tTol.iBarCnt = 0
			tMsg.iBarCnt = 0
			
			For	Each ctr In frm.Controls
                'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                '20190806 CHG START
                'If (TypeOf ctr Is System.Windows.Forms.ToolStripMenuItem) Or (TypeOf ctr Is System.Windows.Forms.Timer) Then
                If (TypeOf ctr Is System.Windows.Forms.ContextMenuStrip) Then
                    '20190806 CHG END

                    'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                ElseIf TypeOf ctr Is System.Windows.Forms.Label Then
                    '20190806 DELL START
                    ''UPGRADE_WARNING: オブジェクト ctr.X1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ctr.X1 = calTwip(ctr.X1, gFactor)
                    ''UPGRADE_WARNING: オブジェクト ctr.X2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ctr.X2 = calTwip(ctr.X2, gFactor)
                    ''UPGRADE_WARNING: オブジェクト ctr.Y1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ctr.Y1 = calTwip(ctr.Y1, gFactor)
                    ''UPGRADE_WARNING: オブジェクト ctr.Y2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ctr.Y2 = calTwip(ctr.Y2, gFactor)
                    '20190806 DELL END
                Else
                    'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                    If TypeOf ctr Is System.Windows.Forms.PictureBox Then
						'UPGRADE_WARNING: オブジェクト getContainer(ctr).NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Select Case getContainer(ctr).NAME
							Case tTol.ctr.Name
								ReDim Preserve tTol.ctrBars(tTol.iBarCnt)
								tTol.ctrBars(tTol.iBarCnt) = ctr
								tTol.iBarCnt = tTol.iBarCnt + 1
								
							Case tMsg.ctr.Name
								ReDim Preserve tMsg.ctrBars(tMsg.iBarCnt)
								tMsg.ctrBars(tMsg.iBarCnt) = ctr
								tMsg.iBarCnt = tMsg.iBarCnt + 1
								
						End Select
					Else
						nLeft = VB6.PixelsToTwipsX(ctr.Left)
						
						ctr.Font = VB6.FontChangeSize(ctr.Font, gFntSz)
						ctr.Left = VB6.TwipsToPixelsX(calTwip(VB6.PixelsToTwipsX(ctr.Left), gFactor))
						ctr.Top = VB6.TwipsToPixelsY(calTwip(VB6.PixelsToTwipsY(ctr.Top), gFactor))
						ctr.Height = VB6.TwipsToPixelsY(calTwip(VB6.PixelsToTwipsY(ctr.Height), gFactor))
						ctr.Width = VB6.TwipsToPixelsX(calTwip(VB6.PixelsToTwipsX(ctr.Width), gFactor))
						
						'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
						If TypeOf ctr Is System.Windows.Forms.TextBox Then
							'UPGRADE_WARNING: オブジェクト getContainer(ctr).NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Select Case getContainer(ctr).NAME
								Case tTol.ctr.Name : ctr.Left = VB6.TwipsToPixelsX(nLeft)
							End Select
						End If
					End If
				End If
			Next ctr
			
			' ツールバーとメッセージバーの補正
			hoseiBar(frm, tTol, tMsg, gFactor)
			
			' 各ブロックのコントロールを補正
			For I = 0 To iGrpCnt - 1
				hoseiControls(tGrps(I).iCtrCnt, tGrps(I).tCtrs)
			Next 
		End If
	End Sub
	
	' 補正対象コントロールの取得
	'   I   frm     フォーム
	'   O   iGrpCnt コンテナグループ数
	'   O   tGrps() コンテナグループ別コントロール情報
	Private Sub getHoseiControls(ByVal frm As System.Windows.Forms.Form, ByRef iGrpCnt As Short, ByRef tGrps() As TYPE_CTRLGRP)
		Dim J, I, k As Short
		Dim ctr As System.Windows.Forms.Control
		
		' コンテナグループ別のコントロールを取得
		iGrpCnt = 0
		
		For	Each ctr In frm.Controls
            'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            '20190806 CHG START
            'If (TypeOf ctr Is System.Windows.Forms.ToolStripMenuItem) Or (TypeOf ctr Is System.Windows.Forms.Timer) Or (TypeOf ctr Is System.Windows.Forms.Label) Then
            If (TypeOf ctr Is System.Windows.Forms.ContextMenuStrip) Or (TypeOf ctr Is System.Windows.Forms.Label) Then
                '20190806 CHG END
            Else
                getGrpControls(ctr, iGrpCnt, tGrps)
			End If
		Next ctr
		
		' 隣接するコントロールを確定
		For I = 0 To iGrpCnt - 1
			relControl(tGrps(I).iCtrCnt, tGrps(I).tCtrs)
		Next 
	End Sub
	
	' コンテナグループ別のコントロールを取得
	'   I   ctr     コントロール
	'   O   iGrpCnt コンテナグループ数
	'   O   tGrps() コンテナグループ別コントロール
	Private Sub getGrpControls(ByVal ctr As System.Windows.Forms.Control, ByRef iGrpCnt As Short, ByRef tGrps() As TYPE_CTRLGRP)
		Dim bOvrFg As Boolean
		Dim I As Short
		'UPGRADE_WARNING: 構造体 tCtr の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim tCtr As TYPE_CTRLINFO
		
		bOvrFg = False
		For I = 0 To iGrpCnt - 1
			If tGrps(I).sGrpNm = ctr.Parent.Name Then
				bOvrFg = True
				Exit For
			End If
		Next 
		
		If bOvrFg Then
			ReDim Preserve tGrps(I).tCtrs(tGrps(I).iCtrCnt)
			
			tCtr.nLeft = VB6.PixelsToTwipsX(ctr.Left)
			tCtr.nTop = VB6.PixelsToTwipsY(ctr.Top)
			tCtr.nHeight = VB6.PixelsToTwipsY(ctr.Height)
			tCtr.nWidth = VB6.PixelsToTwipsX(ctr.Width)
			tCtr.ctr = ctr
			
			'UPGRADE_WARNING: オブジェクト tGrps().tCtrs(tGrps().iCtrCnt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			tGrps(I).tCtrs(tGrps(I).iCtrCnt) = tCtr
			tGrps(I).iCtrCnt = tGrps(I).iCtrCnt + 1
		Else
			ReDim Preserve tGrps(iGrpCnt)
			ReDim Preserve tGrps(iGrpCnt).tCtrs(tGrps(iGrpCnt).iCtrCnt)
			
			tGrps(iGrpCnt).sGrpNm = ctr.Parent.Name
			tCtr.nLeft = VB6.PixelsToTwipsX(ctr.Left)
			tCtr.nTop = VB6.PixelsToTwipsY(ctr.Top)
			tCtr.nHeight = VB6.PixelsToTwipsY(ctr.Height)
			tCtr.nWidth = VB6.PixelsToTwipsX(ctr.Width)
			tCtr.ctr = ctr
			'UPGRADE_WARNING: オブジェクト tGrps().tCtrs(tGrps().iCtrCnt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			tGrps(iGrpCnt).tCtrs(tGrps(iGrpCnt).iCtrCnt) = tCtr
			
			tGrps(iGrpCnt).iCtrCnt = tGrps(iGrpCnt).iCtrCnt + 1
			iGrpCnt = iGrpCnt + 1
		End If
	End Sub
	
	' 隣接するコントロールを確定
	'   I   iCtrCnt コントロール数
	'   O   tCtrs() コントロール
	Private Sub relControl(ByVal iCtrCnt As Short, ByRef tCtrs() As TYPE_CTRLINFO)
		Dim I, J As Short
		Dim iTwipX, iTwipY As Short
		Dim nMin, nRight, nDown, nMax As Integer
		Dim tRel As TYPE_RELINFO
		
		iTwipX = VB6.TwipsPerPixelX
		iTwipY = VB6.TwipsPerPixelY
		
		' 左隣接コントロールの確定
		For I = 0 To iCtrCnt - 1
			nRight = tCtrs(I).nLeft + tCtrs(I).nWidth - iTwipX
			For J = 0 To iCtrCnt - 1
				If J <> I Then
					If nRight = tCtrs(J).nLeft Then
						nMin = tCtrs(J).nTop
						nMax = nMin + tCtrs(J).nHeight - iTwipY
						Select Case tCtrs(J).nTop
							Case nMin To nMax '- iTwipY
								ReDim Preserve tCtrs(I).tLefts(tCtrs(I).iLeftCnt)
								
								tRel.ctr = tCtrs(J).ctr
								Select Case tCtrs(I).nTop + tCtrs(I).nHeight - iTwipY
									Case nMax : tRel.bJstFg = True
									Case Else : tRel.bJstFg = False
								End Select
								
								'UPGRADE_WARNING: オブジェクト tCtrs().tLefts(tCtrs().iLeftCnt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								tCtrs(I).tLefts(tCtrs(I).iLeftCnt) = tRel
								tCtrs(I).iLeftCnt = tCtrs(I).iLeftCnt + 1
								
						End Select
					End If
				End If
			Next 
		Next 
		
		' 下隣接コントロールの確定
		For I = 0 To iCtrCnt - 1
			nDown = tCtrs(I).nTop + tCtrs(I).nHeight - iTwipY
			For J = 0 To iCtrCnt - 1
				If J <> I Then
					If nDown = tCtrs(J).nTop Then
						nMin = tCtrs(J).nLeft
						nMax = nMin + tCtrs(J).nWidth - iTwipX
						Select Case tCtrs(J).nLeft
							Case nMin To nMax '- iTwipX
								ReDim Preserve tCtrs(I).tDowns(tCtrs(I).iDownCnt)
								
								tRel.ctr = tCtrs(J).ctr
								Select Case tCtrs(I).nLeft + tCtrs(I).nWidth - iTwipX
									Case nMax : tRel.bJstFg = True
									Case Else : tRel.bJstFg = False
								End Select
								
								'UPGRADE_WARNING: オブジェクト tCtrs().tDowns(tCtrs().iDownCnt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								tCtrs(I).tDowns(tCtrs(I).iDownCnt) = tRel
								tCtrs(I).iDownCnt = tCtrs(I).iDownCnt + 1
								
						End Select
					End If
				End If
			Next 
		Next 
		
		'    debugZoom iCtrCnt, tCtrs()
	End Sub
	
	Private Sub debugZoom(ByVal iCtrCnt As Short, ByRef tCtrs() As TYPE_CTRLINFO)
		Dim bJstFg As Boolean
		Dim I, J As Short
		Dim iNo As Short
		
		For I = 0 To iCtrCnt - 1
			System.Diagnostics.Debug.Write(CStr(I) & ": ")
			Debug.Print(tCtrs(I).ctr.Name & ", ")
			System.Diagnostics.Debug.Write("  Left -> ")
			For J = 0 To tCtrs(I).iLeftCnt - 1
				'            iNo = tCtrs(i).tLefts(j).iNo
				bJstFg = tCtrs(I).tLefts(J).bJstFg
				'            Debug.Print tCtrs(iNo).ctr.Name & "(" & bJstFg & ")" & ", ";
				System.Diagnostics.Debug.Write(tCtrs(I).tLefts(J).ctr.Name & "(" & bJstFg & ")" & ", ")
			Next 
			Debug.Print("")
			System.Diagnostics.Debug.Write("  Down -> ")
			For J = 0 To tCtrs(I).iDownCnt - 1
				'            iNo = tCtrs(i).tDowns(j).iNo
				bJstFg = tCtrs(I).tDowns(J).bJstFg
				'            Debug.Print tCtrs(iNo).ctr.Name & "(" & bJstFg & ")" & ", ";
				System.Diagnostics.Debug.Write(tCtrs(I).tDowns(J).ctr.Name & "(" & bJstFg & ")" & ", ")
			Next 
			Debug.Print("")
		Next 
	End Sub
	
	' バーコントロールの取得
	'   I   frm     フォーム
	'   O   tTol    ツールバー情報
	'   O   tMsg    メッセージバー情報
	Private Sub getBarControls(ByVal frm As System.Windows.Forms.Form, ByRef tTol As TYPE_BAR, ByRef tMsg As TYPE_BAR)
		Dim obj As Object
		
		For	Each obj In frm.Controls
			'UPGRADE_WARNING: オブジェクト obj.NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case UCase(obj.NAME)
				Case "SYSDT"
					Do 
						tTol.ctr = obj
						'UPGRADE_WARNING: オブジェクト obj.Container の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						obj = obj.Container
					Loop While Not (TypeOf obj Is System.Windows.Forms.Form)
					
				Case "TX_MESSAGE"
					Do 
						tMsg.ctr = obj
						'UPGRADE_WARNING: オブジェクト obj.Container の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						obj = obj.Container
					Loop While Not (TypeOf obj Is System.Windows.Forms.Form)
					
			End Select
		Next obj
	End Sub
	
	' コントロールの補正
	'   I   iCtrCnt コントロール数
	'   O   tCtrs() コントロール
	Private Sub hoseiControls(ByVal iCtrCnt As Short, ByRef tCtrs() As TYPE_CTRLINFO)
		Dim I, J As Short
		Dim iTwipX, iTwipY As Short
		Dim nLeft, nTop As Integer
		Dim nRight, nDown As Integer
		'UPGRADE_WARNING: 構造体 tCrt の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim tCrt As TYPE_CTRLINFO
		Dim tCrtsL() As TYPE_CTRLINFO
		
		iTwipX = VB6.TwipsPerPixelX
		iTwipY = VB6.TwipsPerPixelY
		
		' 左隣接コントロールのLeft値を補正
		For I = 0 To iCtrCnt - 2
			For J = I + 1 To iCtrCnt - 1
				If tCtrs(J).nLeft < tCtrs(I).nLeft Then
					'UPGRADE_WARNING: オブジェクト tCrt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCrt = tCtrs(I)
					'UPGRADE_WARNING: オブジェクト tCtrs(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCtrs(I) = tCtrs(J)
					'UPGRADE_WARNING: オブジェクト tCtrs(J) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCtrs(J) = tCrt
				End If
			Next 
		Next 
		
		For I = 0 To iCtrCnt - 1
			ReDim Preserve tCrtsL(I)
			'UPGRADE_WARNING: オブジェクト tCrtsL(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			tCrtsL(I) = tCtrs(I)
			
			nLeft = VB6.PixelsToTwipsX(tCtrs(I).ctr.Left) + VB6.PixelsToTwipsX(tCtrs(I).ctr.Width) - iTwipX
			For J = 0 To tCtrs(I).iLeftCnt - 1
				tCtrs(I).tLefts(J).ctr.Left = VB6.TwipsToPixelsX(nLeft)
			Next 
		Next 
		
		' 下隣接コントロールのTop値とWidth値を補正
		For I = 0 To iCtrCnt - 2
			For J = I + 1 To iCtrCnt - 1
				If tCtrs(J).nTop < tCtrs(I).nTop Then
					'UPGRADE_WARNING: オブジェクト tCrt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCrt = tCtrs(I)
					'UPGRADE_WARNING: オブジェクト tCtrs(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCtrs(I) = tCtrs(J)
					'UPGRADE_WARNING: オブジェクト tCtrs(J) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					tCtrs(J) = tCrt
				End If
			Next 
		Next 
		
		For I = 0 To iCtrCnt - 1
			nTop = VB6.PixelsToTwipsY(tCtrs(I).ctr.Top) + VB6.PixelsToTwipsY(tCtrs(I).ctr.Height) - iTwipY
			nRight = VB6.PixelsToTwipsX(tCtrs(I).ctr.Left) + VB6.PixelsToTwipsX(tCtrs(I).ctr.Width) - iTwipX
			For J = 0 To tCtrs(I).iDownCnt - 1
				tCtrs(I).tDowns(J).ctr.Top = VB6.TwipsToPixelsY(nTop)
				If tCtrs(I).tDowns(J).bJstFg Then
					tCtrs(I).tDowns(J).ctr.Width = VB6.TwipsToPixelsX(nRight - VB6.PixelsToTwipsX(tCtrs(I).tDowns(J).ctr.Left) + iTwipX)
				End If
			Next 
		Next 
		
		' 左隣接コントロールのHeight値を補正
		For I = 0 To iCtrCnt - 1
			nDown = VB6.PixelsToTwipsY(tCrtsL(I).ctr.Top) + VB6.PixelsToTwipsY(tCrtsL(I).ctr.Height) - iTwipY
			For J = 0 To tCrtsL(I).iLeftCnt - 1
				If tCrtsL(I).tLefts(J).bJstFg Then
					tCrtsL(I).tLefts(J).ctr.Height = VB6.TwipsToPixelsY(nDown - VB6.PixelsToTwipsY(tCrtsL(I).tLefts(J).ctr.Top) + iTwipY)
				End If
			Next 
		Next 
	End Sub
	
	' Widthの修正
	'   I   nTwip       Twip値
	'   I   gFactor     倍率
	Private Function calTwip(ByVal nWidth As Integer, ByVal gFactor As Single) As Integer
		calTwip = ((nWidth * gFactor) \ 15) * 15
	End Function
	
	' 指定のコントロールが格納されている最上位のコンテナを取得
	'   I   ctr     コントロール
	Private Function getContainer(ByVal ctr As System.Windows.Forms.Control) As Object
		Dim obj As Object
		
		obj = ctr
		
		'UPGRADE_WARNING: オブジェクト obj.Container の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Do While Not (TypeOf obj.Container Is System.Windows.Forms.Form)
			'UPGRADE_WARNING: オブジェクト obj.Container の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			obj = obj.Container
		Loop 
		
		' 最上位のコンテナコントロールが無ければフォームを返す
		'UPGRADE_WARNING: オブジェクト obj.NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If obj.NAME = ctr.Name Then
			'UPGRADE_WARNING: オブジェクト obj.Container の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			obj = obj.Container
		End If
		
		getContainer = obj
	End Function
	
	' ツールバーとメッセージバーの補正
	'   I   frm     フォーム
	'   I   tTol    ツールバー情報
	'   I   tMsg    メッセージバー情報
	'   I   gFactor 倍率
	Private Sub hoseiBar(ByVal frm As System.Windows.Forms.Form, ByRef tTol As TYPE_BAR, ByRef tMsg As TYPE_BAR, ByVal gFactor As Single)
		On Error Resume Next
		Dim I As Short
		Dim nTop As Integer
		
		' ツールバーと格納コントロールの補正
		tTol.ctr.Left = VB6.TwipsToPixelsX(-45)
		tTol.ctr.Top = 0
		
		For I = 0 To tTol.iBarCnt - 1
			nTop = VB6.PixelsToTwipsY(tTol.ctr.Height) * 0.5 - VB6.PixelsToTwipsY(tTol.ctrBars(I).Height) * 0.5
			tTol.ctrBars(I).Top = VB6.TwipsToPixelsY(nTop)
		Next 
		
		' メッセージバーと格納コントロールの補正
		tMsg.ctr.Left = VB6.TwipsToPixelsX(-45)
		tMsg.ctr.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frm.ClientRectangle.Height) - VB6.PixelsToTwipsY(tMsg.ctr.Height) + VB6.TwipsPerPixelY * 4)
		
		For I = 0 To tMsg.iBarCnt - 1
			tMsg.ctrBars(I).Top = VB6.TwipsToPixelsY(calTwip(VB6.PixelsToTwipsY(tMsg.ctrBars(I).Top), gFactor))
		Next 
	End Sub
	
	'
	Function Get_DbSchema(ByRef vUser As String) As String
		'指定したUSRのスキーマを取得する
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim wkBuf As String
		
		ret = GetPrivateProfileString("DBNAMES", vUser, "", wkStr.Value, Len(wkStr.Value), "SSSWIN.INI")
		If ret > 0 And UCase(Left(wkStr.Value, ret)) <> "DEFAULT" Then
			Get_DbSchema = Left(wkStr.Value, ret)
		Else
			Get_DbSchema = Get_DBHEAD() & "_" & vUser
		End If
	End Function
	
	'''''''
	'#Start(2003.10.28)
	'#Start(2003.4.22)
	Public Function CreateBitmapPicture(ByVal hBmp As Integer, ByVal hPal As Integer) As System.Drawing.Image
		
		Dim r As Integer
		Dim Pic As PicBmp
		Dim IPic As System.Drawing.Image
		'UPGRADE_WARNING: 構造体 IID_IDispatch の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim IID_IDispatch As GUID
		
		With IID_IDispatch
			.Data1 = &H20400
			.Data4(0) = &HC0s
			.Data4(7) = &H46s
		End With
		
		With Pic
			.Size = Len(Pic) ' Length of structure
            'UPGRADE_ISSUE: 定数 vbPicTypeBitmap はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
            '20190806 DELL START
            '.Type = vbPicTypeBitmap ' Type of Picture (bitmap)
            '20190806 DELL END
            .hBmp = hBmp ' Handle to bitmap
			.hPal = hPal ' Handle to palette (may be null)
		End With
		
		r = OleCreatePictureIndirect(Pic, IID_IDispatch, 1, IPic)
		CreateBitmapPicture = IPic
	End Function
	''''''''''''
	Function CaptureWindow(ByVal hWndSrc As Integer, ByVal Client As Boolean, ByVal LeftSrc As Integer, ByVal TopSrc As Integer, ByVal WidthSrc As Integer, ByVal HeightSrc As Integer) As System.Drawing.Image
		
		Dim hDCMemory As Integer
		Dim hBmp As Integer
		Dim hBmpPrev As Integer
		Dim r As Integer
		Dim hDCSrc As Integer
		Dim hPal As Integer
		Dim hPalPrev As Integer
		Dim RasterCapsScrn As Integer
		Dim HasPaletteScrn As Integer
        Dim PaletteSizeScrn As Integer
        Dim vbSrcCopy As Integer
        'UPGRADE_WARNING: 構造体 LogPal の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim LogPal As LOGPALETTE
		
		If Client Then
			hDCSrc = GetDC(hWndSrc)
		Else
			hDCSrc = GetWindowDC(hWndSrc)
		End If
		
		hDCMemory = CreateCompatibleDC(hDCSrc)
		hBmp = CreateCompatibleBitmap(hDCSrc, WidthSrc, HeightSrc)
		hBmpPrev = SelectObject(hDCMemory, hBmp)
		
		RasterCapsScrn = GetDeviceCaps(hDCSrc, RASTERCAPS)
		HasPaletteScrn = RasterCapsScrn And RC_PALETTE
		PaletteSizeScrn = GetDeviceCaps(hDCSrc, SIZEPALETTE)
		If HasPaletteScrn And (PaletteSizeScrn = 256) Then
			LogPal.palVersion = &H300s
			LogPal.palNumEntries = 256
			r = GetSystemPaletteEntries(hDCSrc, 0, 256, LogPal.palPalEntry(0))
			hPal = CreatePalette(LogPal)
			hPalPrev = SelectPalette(hDCMemory, hPal, 0)
			r = RealizePalette(hDCMemory)
		End If
		
		'UPGRADE_ISSUE: 定数 vbSrcCopy はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		r = BitBlt(hDCMemory, 0, 0, WidthSrc, HeightSrc, hDCSrc, LeftSrc, TopSrc, vbSrcCopy)
		
		hBmp = SelectObject(hDCMemory, hBmpPrev)
		
		If HasPaletteScrn And (PaletteSizeScrn = 256) Then
			hPal = SelectPalette(hDCMemory, hPalPrev, 0)
		End If
		
		r = DeleteDC(hDCMemory)
		r = ReleaseDC(hWndSrc, hDCSrc)
		
		CaptureWindow = CreateBitmapPicture(hBmp, hPal)
	End Function
	
	''''''
	Public Function CaptureForm(ByRef frmSrc As System.Windows.Forms.Form) As System.Drawing.Image
        ' Call CaptureWindow to capture the entire form given it's window
        ' handle and then return the resulting Picture object
        'UPGRADE_ISSUE: 定数 vbPixels はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbTwips はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: Form メソッド frmSrc.ScaleY はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'UPGRADE_ISSUE: Form メソッド frmSrc.ScaleX はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '20190806 CHG START
        'CaptureForm = CaptureWindow(frmSrc.Handle.ToInt32, False, 0, 0, frmSrc.ScaleX(VB6.PixelsToTwipsX(frmSrc.Width), vbTwips, vbPixels), frmSrc.ScaleY(VB6.PixelsToTwipsY(frmSrc.Height), vbTwips, vbPixels))
        '20190806 CHG END
    End Function
    'ハードコピー
    Public Sub Exec_Hardcopy(ByRef pform As System.Windows.Forms.Form)
        '20190806 DELL START
        'gSelectedDeviceName = ""
        ''UPGRADE_ISSUE: Printers メソッド Printers.count はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'If Printers.count = 0 Then
        '    Call MsgBox("このＰＣにはプリンタがインストールされていないため" & vbCr & "画面ハードコピーができません。" & vbCr & "プリンタをインストールしてから再度実行して下さい。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        '    gSelectedDeviceName = CStr(False)
        '    Exit Sub
        'End If
        ''UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        'Load(WLS_HCP)
        'WLS_HCP.ShowDialog()
        'System.Windows.Forms.Application.DoEvents()
        'If gSelectedDeviceName <> "" Then
        '    'Form のスクリーンショットを
        '    'Picture1 の Picture プロパティに代入します。
        '    WLS_HCP.Picture1.Image = CaptureForm(pform)
        '    '指定したプリンタにPicture1を印刷します。
        '    APIPrint((gSelectedDeviceName))
        'End If
        'WLS_HCP.Close()
        '20190806 DELL END
    End Sub
    '
    ' 指定したディバイス（プリンタ）から、ＤｅｖＭｏｄｅ構造体を取得し、情報の設定を行ない。
    Sub APIPrint(ByRef Device As String)
		Dim dm As sDEVMODE
		Dim hPrinter, di As Integer
		Dim prhdc As Integer
		Dim dinfo As DOCINFO
		Dim pdefs As PRINTER_DEFAULTS
		Dim bufsize As Integer
		Dim dmInBuf() As Byte
		Dim dmOutBuf() As Byte
		
		pdefs.PDATATYPE = vbNullString
		pdefs.PDEVMODE = 0
		pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
		
		di = sOpenPrinter(Device, hPrinter, pdefs)
		If di = 0 Then Exit Sub
		bufsize = snDocumentProperties(0, hPrinter, Device, 0, 0, 0)
		ReDim dmInBuf(bufsize - 1)
		ReDim dmOutBuf(bufsize - 1)
		di = sDocumentProperties(0, hPrinter, Device, dmOutBuf(0), dmInBuf(0), DM_OUT_BUFFER)
		
		Select Case di
			Case IDOK
			Case IDCANCEL
				GoTo PrintEnd2
			Case Else
				MsgBox("プリンタの情報が取得できません。", 0, "ハードコピー")
				GoTo PrintEnd2
		End Select
		
		'UPGRADE_WARNING: オブジェクト dm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call memcpy(dm, dmOutBuf(0), Len(dm))
		dm.dmOrientation = CShort(gSelectedOrientation)
		dm.dmPaperSize = gSelectedPapeSize
		dm.dmColor = DMCOLOR_COLOR
		'UPGRADE_WARNING: オブジェクト dm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call memcpy(dmOutBuf(0), dm, Len(dm))
		
		prhdc = CreateDC("winspool", Device, vbNullString, dmOutBuf(0))
		If prhdc = 0 Then GoTo PrintEnd2
		
		dinfo.cbSize = Len(dinfo)
		dinfo.lpszDocName = "画面ID：" & SSS_PrgId
		dinfo.lpszOutput = vbNullString
		
		di = StartDoc(prhdc, dinfo)
		di = StartPage(prhdc)
		PrintBitmap(prhdc)
		di = EndPage(prhdc)
		If di >= 0 Then di = EndDocAPI(prhdc)
		
PrintEnd1: 
		DeleteDC(prhdc)
		
PrintEnd2: 
		ClosePrinter(hPrinter)
		
	End Sub
	'
	'フォームのスクリーンショットを印刷する
	Sub PrintBitmap(ByRef hdc As Integer)
		Dim bi As BITMAPINFO
		Dim dctemp, dctemp2 As Integer
		Dim Msg As String
		Dim bufsize As Integer
		Dim bm As BITMAP
		Dim ghnd As Integer
		Dim gptr As Integer
		Dim xpix, ypix As Integer
		Dim doscale As Double
		Dim uy, ux As Integer
        Dim di As Integer
        '20190806 ADD START
        Dim vbSrcCopy As Integer
        '20190806 ADD END

        'UPGRADE_ISSUE: PictureBox プロパティ Picture1.hdc はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '20190806 CHG START
        'dctemp = CreateCompatibleDC(WLS_HCP.Picture1.hdc)
        dctemp = CreateCompatibleDC(WLS_HCP.Picture1.CreateGraphics.GetHdc)
        '20190806 CHG END
        'UPGRADE_WARNING: オブジェクト bm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        di = GetObjectAPI(CInt(CObj(WLS_HCP.Picture1.Image)), Len(bm), bm)
		With bi.bmiHeader
			.biSize = Len(bi.bmiHeader)
			.biWidth = bm.bmWidth
			.biHeight = bm.bmHeight
			.biPlanes = 1
			.biBitCount = 24
			.biCompression = BI_RGB
			bufsize = .biWidth
			bufsize = bufsize * 3
			bufsize = ((bufsize + 3) / 4) * 4
			bufsize = bufsize * .biHeight
		End With
		ghnd = GlobalAlloc(GMEM_MOVEABLE, bufsize)
		gptr = GlobalLock(ghnd)
		di = GetDIBits(dctemp, CInt(CObj(WLS_HCP.Picture1.Image)), 0, bm.bmHeight, gptr, bi, DIB_RGB_COLORS)
		
		xpix = GetDeviceCaps(hdc, HORZRES) - 200 '余白分引く
		ypix = GetDeviceCaps(hdc, VERTRES) - 200
		doscale = xpix / bm.bmWidth
		If ypix / bm.bmHeight < doscale Then
			doscale = ypix / bm.bmHeight
		End If
		If doscale > 6 Then
			doscale = 6 '上限サイズ　（1024*768 → A4横 で最適?）
		End If
		ux = Int(bm.bmWidth * doscale)
		uy = Int(bm.bmHeight * doscale)
		'UPGRADE_ISSUE: 定数 vbSrcCopy はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		di = StretchDIBits(hdc, 100, 100, ux, uy, 0, 0, bm.bmWidth, bm.bmHeight, gptr, bi, DIB_RGB_COLORS, vbSrcCopy)
		
		di = GlobalUnlock(ghnd)
		di = GlobalFree(ghnd)
		di = DeleteDC(dctemp)
	End Sub
	
	'ハードコピーイベント。Ｅｅｅにより呼出される。
	Function SSSMAIN_Hardcopy_Getevent() As Boolean
		Call Exec_Hardcopy(FR_SSSMAIN)
		SSSMAIN_Hardcopy_Getevent = False
	End Function
	'#End(2003.4.22)
	'#End(2003.10.28)
	
	Public Sub SSSWIN_EXCTBZ_OPEN()
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		DB_EXCTBZ.CLTID = SSS_CLTID.Value
		DB_EXCTBZ.GYMCD = SSS_PrgId
		Call DB_GetEq(DBN_EXCTBZ, 1, DB_EXCTBZ.CLTID & DB_EXCTBZ.GYMCD, BtrNormal)
        If DBSTAT = 0 Then
            DB_EXCTBZ.LCKTM = VB6.Format(Now, "hhnnss")
            Call DB_Update(DBN_EXCTBZ, 1)
        Else
            '20190806 DELL START
            'Call EXCTBZ_RClear()
            '20190806 DELL END
            DB_EXCTBZ.CLTID = SSS_CLTID.Value
			DB_EXCTBZ.GYMCD = SSS_PrgId
			DB_EXCTBZ.LCKTM = VB6.Format(Now, "hhnnss")
			Call DB_Insert(DBN_EXCTBZ, 1)
		End If
		Call DB_EndTransaction()
		
	End Sub
	
	Public Sub SSSWIN_EXCTBZ_CLOSE()
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		DB_EXCTBZ.CLTID = SSS_CLTID.Value
		DB_EXCTBZ.GYMCD = SSS_PrgId
		Call DB_GetEq(DBN_EXCTBZ, 1, DB_EXCTBZ.CLTID & DB_EXCTBZ.GYMCD, BtrNormal)
		If DBSTAT = 0 Then
			Call DB_Delete(DBN_EXCTBZ)
		End If
		Call DB_EndTransaction()
		
	End Sub
	
	Function SSSWIN_EXCTBZ_CHECK() As String
		'排他チェックエラー（Link_Shell関数は戻り値 "9" がエラー）
		'             "1" & 業務名: 正常.
		'             "9" & 業務名: 排他.
		
		SSSWIN_EXCTBZ_CHECK = "1"
		Call DB_GetGrEq(DBN_GYMTBZ, 2, SSS_PrgId, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_GYMTBZ.NGGYMCD) = Trim(SSS_PrgId)) And (SSSWIN_EXCTBZ_CHECK = "1")
			Call DB_GetEq(DBN_EXCTBZ, 2, DB_GYMTBZ.GYMCD, BtrNormal)
			If DBSTAT = 0 Then
				SSSWIN_EXCTBZ_CHECK = "9" & DB_GYMTBZ.GYMNM
			End If
			Call DB_GetNext(DBN_GYMTBZ, BtrNormal)
		Loop 
		
	End Function
	
	' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_EXCTBZ_CHECK2
	'   概要：　排他チェック処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Function SSSWIN_EXCTBZ_CHECK2() As Integer
	Function SSSWIN_EXCTBZ_CHECK2(ByRef pin_strGYMCD As Object) As Short
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		SSSWIN_EXCTBZ_CHECK2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'    strSQL = strSQL & "        GYMCD   = '" & Trim$(FR_SSSMAIN.HD_JDNNO) & "'"    '受注番号
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "        GYMCD   = '" & Trim(pin_strGYMCD) & "'" '業務コード
		' === 20130530 === UPDATE E
		Call DB_GetSQL2(DBN_EXCTBZ, strSQL)
		
		If DBSTAT = 0 Then
			If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID.Value And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
				SSSWIN_EXCTBZ_CHECK2 = 0
			Else
				'検索結果が存在した場合
				SSSWIN_EXCTBZ_CHECK2 = 1
				'処理終了
				Exit Function
			End If
		Else
			'検索結果が0件の場合
			'排他制御（排他テーブルへ書き込み）
			' === 20130530 === UPDATE S - FWEST)Koroyasu
			'        bolRet = SSSWIN_Execute_EXCTBZ
			bolRet = SSSWIN_Execute_EXCTBZ(pin_strGYMCD)
			' === 20130530 === UPDATE E
			If bolRet = False Then
				Exit Function
			End If
			SSSWIN_EXCTBZ_CHECK2 = 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Execute_EXCTBZ
	'   概要：  排他制御処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Function SSSWIN_Execute_EXCTBZ() As Boolean
	Function SSSWIN_Execute_EXCTBZ(ByRef pin_strGYMCD As Object) As Boolean
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		
		SSSWIN_Execute_EXCTBZ = False
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "      ( CLTID " 'クライアントID
		strSQL = strSQL & "      , GYMCD " '受注番号
		strSQL = strSQL & "      , LCKTM " 'タイムスタンプ
		strSQL = strSQL & "      , INTLCD " 'プログラムID
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & SSS_CLTID.Value & "' " 'クライアントID
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'   strSQL = strSQL & "      , '" & Trim$(FR_SSSMAIN.HD_JDNNO) & "' "   '受注番号
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , '" & Trim(pin_strGYMCD) & "' " '業務コード
		' === 20130530 === UPDATE E
		strSQL = strSQL & "      , '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , '" & SSS_PrgId & "'" 'プログラムID
		strSQL = strSQL & "      ) "
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		SSSWIN_Execute_EXCTBZ = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Unlock_EXCTBZ
	'   概要：　排他制御解除処理
	'   引数：
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Unlock_EXCTBZ() As Boolean
		
		Dim strSQL As String
		
		SSSWIN_Unlock_EXCTBZ = False
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		SSSWIN_Unlock_EXCTBZ = True
		
	End Function
	' === 20130416 === INSERT E -
	
	' === 20130617 === INSERT S - FWEST)Koroyasu 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_EXCTBZ_CHECK3
	'   概要：　排他チェック処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_EXCTBZ_CHECK3(ByRef pin_strGYMCD As Object) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		SSSWIN_EXCTBZ_CHECK3 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "        GYMCD   = '" & Trim(pin_strGYMCD) & "'" '業務コード
		Call DB_GetSQL2(DBN_EXCTBZ, strSQL)
		
		If DBSTAT = 0 Then
			If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID.Value And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
				SSSWIN_EXCTBZ_CHECK3 = 0
			Else
				'検索結果が存在した場合
				SSSWIN_EXCTBZ_CHECK3 = 1
				'処理終了
				Exit Function
			End If
		Else
			'検索結果が0件の場合
			'排他制御（排他テーブルへ書き込み）
			bolRet = SSSWIN_Execute_EXCTBZ2(pin_strGYMCD)
			If bolRet = False Then
				Exit Function
			End If
			SSSWIN_EXCTBZ_CHECK3 = 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Execute_EXCTBZ2
	'   概要：  排他制御処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Execute_EXCTBZ2(ByRef pin_strGYMCD As Object) As Boolean
		
		Dim strSQL As String
		
		SSSWIN_Execute_EXCTBZ2 = False
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "      ( CLTID " 'クライアントID
		strSQL = strSQL & "      , GYMCD " '受注番号
		strSQL = strSQL & "      , LCKTM " 'タイムスタンプ
		strSQL = strSQL & "      , INTLCD " 'プログラムID
		strSQL = strSQL & "      , EXTCD " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & SSS_CLTID.Value & "' " 'クライアントID
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "      , '" & Trim(pin_strGYMCD) & "' " '業務コード
		strSQL = strSQL & "      , '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , '" & SSS_PrgId & "'" 'プログラムID
		strSQL = strSQL & "      , '1'" '削除フラグ
		strSQL = strSQL & "      ) "
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		SSSWIN_Execute_EXCTBZ2 = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Unlock_EXCTBZ2
	'   概要：　排他制御解除処理
	'   引数：
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Unlock_EXCTBZ2() As Boolean
		
		Dim strSQL As String
		
		SSSWIN_Unlock_EXCTBZ2 = False
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		strSQL = strSQL & "    AND EXTCD    = '1'" '削除フラグ
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		SSSWIN_Unlock_EXCTBZ2 = True
		
	End Function
	' === 20130617 === INSERT E -
	
	' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_EXCTBZ
	'   概要：　排他チェック処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Chk_EXCTBZ(ByRef pin_strGYMCD As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		CF_Chk_EXCTBZ = 9
		
		'排他チェック
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        GYMCD   = '" & Trim(pin_strGYMCD) & "'" '業務コード
		Call DB_GetSQL2(DBN_EXCTBZ, strSQL)
		
		If DBSTAT = 0 Then
			If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID.Value And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
				bolRet = CF_Upd_EXCTBZ2(pin_strGYMCD)
				CF_Chk_EXCTBZ = 0
			Else
				'検索結果が存在した場合
				CF_Chk_EXCTBZ = 1
				'処理終了
				Exit Function
			End If
		Else
			'検索結果0件の場合
			'排他制御（排他テーブルへ書き込み）
			bolRet = CF_Ins_EXCTBZ(pin_strGYMCD)
			If bolRet = False Then
				Exit Function
			End If
			CF_Chk_EXCTBZ = 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ins_EXCTBZ
	'   概要：  排他制御処理(INSERT)
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御(INSERT)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Ins_EXCTBZ(ByRef pin_strGYMCD As String) As Boolean
		
		Dim strSQL As String
		
		CF_Ins_EXCTBZ = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " INSERT INTO "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "      ( CLTID " 'クライアントID
		strSQL = strSQL & "      , GYMCD " '業務コード
		strSQL = strSQL & "      , LCKTM " 'タイムスタンプ
		strSQL = strSQL & "      , INTLCD " 'プログラムID
		strSQL = strSQL & "      , EXTCD " '削除フラグ
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "      , '" & Trim(pin_strGYMCD) & "' " '業務コード
		strSQL = strSQL & "      , '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , '" & SSS_PrgId & "'" 'プログラムID
		strSQL = strSQL & "      , '0'" '削除フラグ
		strSQL = strSQL & "      ) "
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_Ins_EXCTBZ = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Upd_EXCTBZ
	'   概要：  排他制御処理(UPDATE)
	'   引数：
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御(UPDATE)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Upd_EXCTBZ() As Boolean
		
		Dim strSQL As String
		
		CF_Upd_EXCTBZ = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LCKTM    = '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , EXTCD    = '1'" '削除フラグ
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		strSQL = strSQL & "    AND EXTCD    = '0'" '削除フラグ
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_Upd_EXCTBZ = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Upd_EXCTBZ2
	'   概要：  排他制御処理(UPDATE)
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御(UPDATE)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Upd_EXCTBZ2(ByRef pin_strGYMCD As String) As Boolean
		
		Dim strSQL As String
		
		CF_Upd_EXCTBZ2 = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LCKTM    = '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , EXTCD    = '0'" '削除フラグ
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND GYMCD    = '" & pin_strGYMCD & "' " '業務コード
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		strSQL = strSQL & "    AND EXTCD    <> ' '" '削除フラグ
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_Upd_EXCTBZ2 = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Del_EXCTBZ2
	'   概要：　排他制御解除処理
	'   引数：
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Del_EXCTBZ2() As Boolean
		
		Dim strSQL As String
		
		CF_Del_EXCTBZ2 = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御解除
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_Del_EXCTBZ2 = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Del_EXCTBZ3
	'   概要：　排他制御解除処理
	'   引数：
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_Del_EXCTBZ3() As Boolean
		
		Dim strSQL As String
		
		CF_Del_EXCTBZ3 = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御解除
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		strSQL = strSQL & "    AND EXTCD    = '1' " '削除フラグ
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_Del_EXCTBZ3 = True
		
	End Function
	
	' === 20130829 === UPDATE S - FWEST)Koroyasu 排他制御の追加
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function CF_EXCTBZ_Unlock
	''   概要：  排他制御処理(Unlock)
	''   引数：  pm_All : 画面情報
	''   戻値：　True : 正常 False : 異常
	''   備考：  排他制御(Unlock)を実行する
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Function CF_EXCTBZ_Unlock(pm_All As clsPP) As Boolean
	'
	'    Dim strSQL          As String
	'    Dim bolRet          As Boolean
	'    Dim bolTrn          As Boolean
	'    Dim Max_Row         As Integer
	'    Dim Wk_Row          As Integer
	'
	'    CF_EXCTBZ_Unlock = False
	'
	'    bolRet = CF_Upd_EXCTBZ
	'    If bolRet = False Then
	'        Exit Function
	'    End If
	'
	'    '現在の最大行を取得
	'    Max_Row = pm_All.LastDe
	'
	'    For Wk_Row = 0 To Max_Row - 1
	'        If Trim(RD_SSSMAIN_SBNNO(Wk_Row)) <> "" Then
	'            'トランザクションの開始
	'            Call DB_BeginTransaction(BTR_Exclude)
	'
	'            '排他制御
	'            'SQL編集
	'            strSQL = ""
	'            strSQL = strSQL & " UPDATE "
	'            strSQL = strSQL & "        EXCTBZ "     '排他テーブル
	'            strSQL = strSQL & "    SET "
	'            strSQL = strSQL & "        LCKTM    = '" & Format$(Now, "hhnnss") & "' "    'タイムスタンプ
	'            strSQL = strSQL & "      , EXTCD    = '0'"                                  '削除フラグ
	'            strSQL = strSQL & "  WHERE "
	'            strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "                 'クライアントID
	'            strSQL = strSQL & "    AND GYMCD    = '" & Left$(RD_SSSMAIN_SBNNO(Wk_Row), 6) & "' "     '業務コード
	'            strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "                 'プログラムID
	'            strSQL = strSQL & "    AND EXTCD    = '1'"                                  '削除フラグ
	'            Call DB_Execute(DBN_EXCTBZ, strSQL)
	'
	'            Call DB_EndTransaction
	'        End If
	'
	'    Next
	'
	'    bolRet = CF_Del_EXCTBZ3
	'    If bolRet = False Then
	'        Exit Function
	'    End If
	'
	'    CF_EXCTBZ_Unlock = True
	'
	'End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_EXCTBZ_Unlock
	'   概要：  排他制御処理(Unlock)
	'   引数：  pm_All : 画面情報
	'           pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御(Unlock)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_EXCTBZ_Unlock(ByRef pm_All As clsPP, ByRef pin_strGYMCD As String) As Boolean
		
		Dim strSQL As String
		
		CF_EXCTBZ_Unlock = False
		
		'トランザクションの開始
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		'排他制御
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        EXCTBZ " '排他テーブル
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LCKTM    = '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSQL = strSQL & "      , EXTCD    = '0'" '削除フラグ
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
		strSQL = strSQL & "    AND GYMCD    = '" & pin_strGYMCD & "' " '業務コード
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
		strSQL = strSQL & "    AND EXTCD    = '1'" '削除フラグ
		Call DB_Execute(DBN_EXCTBZ, strSQL)
		
		Call DB_EndTransaction()
		
		CF_EXCTBZ_Unlock = True
		
	End Function
	' === 20130829 === UPDATE E -
	' === 20130711 === INSERT E -
End Module