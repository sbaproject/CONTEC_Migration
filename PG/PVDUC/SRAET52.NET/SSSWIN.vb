Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module SSSWIN_BAS
	'
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'#Start(2003.10.28)
	'#Start(2003.4.22) PrintForm�̑���ɁA�t�H�[�����������
	'Public gSelectedPrinter As Printer
	Public gSelectedDeviceName As String
	Public gSelectedPapeSize As Short
    Public gSelectedOrientation As String

    '2019/09/23 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String '�_�~�[
        Dim DKBID As String
        Dim DKBNM As String
        Dim KANKOZ As String
        Dim NYUKN As Decimal
        Dim FNYUKN As Double
        Dim BNKCD As String
        Dim BNKNM As String
        Dim JDNNO As String
        Dim JDNLINNO As String
        Dim STNNM As String
        Dim TEGDT As String
        Dim TEGNO As String
        Dim LINCMA As String
        Dim LINCMB As String
        Dim SYSTBD As TYPE_DB_SYSTBD
    End Structure
    '2019/09/23 ADD END

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
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			ReDim palPalEntry(255)
		End Sub
	End Structure
	
	Private Structure GUID
		Dim Data1 As Integer
		Dim Data2 As Short
		Dim Data3 As Short
		<VBFixedArray(7)> Dim Data4() As Byte
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			ReDim Data4(7)
		End Sub
	End Structure
	
	Private Const RASTERCAPS As Integer = 38
	Private Const RC_PALETTE As Integer = &H100s
	Private Const SIZEPALETTE As Integer = 104
	
	Private Structure RECT
		'UPGRADE_NOTE: Left �� Left_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim Left_Renamed As Integer
		Dim Top As Integer
		'UPGRADE_NOTE: Right �� Right_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		Dim Right_Renamed As Integer
		Dim Bottom As Integer
	End Structure
	
	Private Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function CreateCompatibleBitmap Lib "gdi32" (ByVal hdc As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer
	Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal iCapabilitiy As Integer) As Integer
	'UPGRADE_WARNING: �\���� PALETTEENTRY �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function GetSystemPaletteEntries Lib "gdi32" (ByVal hdc As Integer, ByVal wStartIndex As Integer, ByVal wNumEntries As Integer, ByRef lpPaletteEntries As PALETTEENTRY) As Integer
	'UPGRADE_WARNING: �\���� LOGPALETTE �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function CreatePalette Lib "gdi32" (ByRef lpLogPalette As LOGPALETTE) As Integer
	Private Declare Function SelectObject Lib "gdi32" (ByVal hdc As Integer, ByVal hObject As Integer) As Integer
	Private Declare Function BitBlt Lib "gdi32" (ByVal hDCDest As Integer, ByVal XDest As Integer, ByVal YDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hDCSrc As Integer, ByVal XSrc As Integer, ByVal YSrc As Integer, ByVal dwRop As Integer) As Integer
	Private Declare Function DeleteDC Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function GetForegroundWindow Lib "user32" () As Integer
	Private Declare Function SelectPalette Lib "gdi32" (ByVal hdc As Integer, ByVal hPalette As Integer, ByVal bForceBackground As Integer) As Integer
	Private Declare Function RealizePalette Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Integer) As Integer
	Private Declare Function GetDC Lib "user32" (ByVal hwnd As Integer) As Integer
	'UPGRADE_WARNING: �\���� RECT �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
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
	
	'UPGRADE_WARNING: �\���� IPicture �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: �\���� GUID �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: �\���� PicBmp �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
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
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
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
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
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
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B    
    '2019/09/23 CHG START
    'Private Declare Function GetObjectAPI Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Any) As Integer
    Private Declare Function GetObjectAPI Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Integer, ByVal nCount As Integer, ByRef lpObject As Integer) As Integer
    '2019/09/23 CHG END

    Private Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Integer, ByVal dwBytes As Integer) As Integer
	Private Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Integer) As Integer
	Private Declare Function GlobalLock Lib "kernel32" (ByVal hMem As Integer) As Integer
	Private Declare Function GlobalUnlock Lib "kernel32" (ByVal hMem As Integer) As Integer
    'UPGRADE_WARNING: �\���� BITMAPINFO �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Private Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Any, ByRef lpBI As BITMAPINFO, ByVal wUsage As Integer) As Integer
    Private Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Integer, ByRef lpBI As BITMAPINFO, ByVal wUsage As Integer) As Integer
    '2019/09/23 CHG END
    'UPGRADE_WARNING: �\���� BITMAPINFO �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Private Declare Function StretchDIBits Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal wSrcWidth As Integer, ByVal wSrcHeight As Integer, ByRef lpBits As Any, ByRef lpBitsInfo As BITMAPINFO, ByVal wUsage As Integer, ByVal dwRop As Integer) As Integer
    Private Declare Function StretchDIBits Lib "gdi32" (ByVal hdc As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal wSrcWidth As Integer, ByVal wSrcHeight As Integer, ByRef lpBits As Integer, ByRef lpBitsInfo As BITMAPINFO, ByVal wUsage As Integer, ByVal dwRop As Integer) As Integer
    '2019/09/23 CHG END
    'UPGRADE_WARNING: �\���� PRINTER_DEFAULTS �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
    Private Declare Function sOpenPrinter Lib "winspool.drv"  Alias "OpenPrinterA"(ByVal pPrinterName As String, ByRef phPrinter As Integer, ByRef pDefault As PRINTER_DEFAULTS) As Integer
	Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
	Private Declare Function snDocumentProperties Lib "winspool.drv"  Alias "DocumentPropertiesA"(ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByVal pnDevModeOutput As Integer, ByVal pnDevModeInput As Integer, ByVal fmode As Integer) As Integer
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Private Declare Function sDocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByRef pDevModeOutput As Any, ByRef pDevModeInput As Any, ByVal fmode As Integer) As Integer
    Private Declare Function sDocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Integer, ByVal hPrinter As Integer, ByVal pDeviceName As String, ByRef pDevModeOutput As Integer, ByRef pDevModeInput As Integer, ByVal fmode As Integer) As Integer
    '2019/09/23 CHG END
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByRef lpInitData As Any) As Integer
    Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByRef lpInitData As Integer) As Integer
    '2019/09/23 CHG END
    'UPGRADE_WARNING: �\���� DOCINFO �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
    Private Declare Function StartDoc Lib "gdi32"  Alias "StartDocA"(ByVal hdc As Integer, ByRef lpdi As DOCINFO) As Integer
	Private Declare Function EndDocAPI Lib "gdi32"  Alias "EndDoc"(ByVal hdc As Integer) As Integer
	Private Declare Function StartPage Lib "gdi32" (ByVal hdc As Integer) As Integer
	Private Declare Function EndPage Lib "gdi32" (ByVal hdc As Integer) As Integer
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Private Declare Sub memcpy Lib "kernel32" Alias "RtlMoveMemory" (ByRef Dst As Any, ByRef src As Any, ByVal LENGTH As Integer)
    Private Declare Sub memcpy Lib "kernel32" Alias "RtlMoveMemory" (ByRef Dst As Object, ByRef src As Object, ByVal LENGTH As Integer)
    '2019/09/23 CHG END
    '#End(2003.10.28)

    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/09/23 CHG END
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Integer
    Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    '2019/09/23 CHG END
    Declare Function VBEXEC1 Lib "VBEXEC32" (ByVal hwnd As Integer, ByVal kb As Integer, ByVal prg As String) As Integer
	'=======================================
	'�r�r�r�v�h�m�D�h�m�h
	'=======================================
	'---------------------------------------------------------------
	Dim SSS_INIDATNM(4) As String '�h�m�h�̃V���{��
	Public SSS_INIDAT(4) As String '�h�m�h�̓��e
    'SSS_INIDATNM(0) = "USR_PATH"           '�J����PATH
    'SSS_INIDATNM(1) = "DAT_PATH"           '�f�[�^PATH
    'SSS_INIDATNM(2) = "PRG_PATH"           '�v���O����PATH
    'SSS_INIDATNM(3) = "WRK_PATH"           '���[�NPATH
    'SSS_INIDATNM(4) = "IMGPATH"            '�C���[�WPATH
    '---------------------------------------------------------------

    'UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
    '2019/09/23 CHG START
    'Public SSS_WRKDT(5) As String*8
    <VBFixedStringAttribute(8)> Public SSS_WRKDT(5) As String
    '2019/09/23 CHG END


    Public Set_date As New VB6.FixedLengthString(10) '����ްWINDOW�p
	Public SSS_CLTID As New VB6.FixedLengthString(5)
	Public SSS_OPEID As New VB6.FixedLengthString(8)
	Public SSS_SMADT As New VB6.FixedLengthString(8)
	Public SSS_SSADT As New VB6.FixedLengthString(8)
	Public SSS_KESDT As New VB6.FixedLengthString(8)
	Public SSS_ACNT As Short
	Public SSS_SMFKB As Decimal
	Public SSS_WLSLIST_KETA As Short '�Ȉ�WINDOW�p�f�[�^�擾����
	Public SSS_RTNWIN As Object '����޳����̕Ԃ�l
	Public SSS_MFIL As Short 'Ҳ�̧��
	Public SSS_MFILNM As String 'ؽ�̧�ٖ�
	Public SSS_MFILKEYNO As Short 'Ҳ�̧�ٷ��ԍ�
	Public SSS_MFILCNT As Integer 'Ҳ�̧�ٓǂݍ��݌���
	Public SSS_MFILTCNT As Integer 'Ҳ�̧�ّ�����
	Public SSS_RPTID As String '�ؽ����߰�ID
	Public SSS_LSTMFIL As Short '������[�N���C���t�@�C���ԍ�
	Public SSS_LSTMFILNM As String '������[�N���C���t�@�C����
	Public SSS_LFILCNT As Integer '����p�t�@�C���o�͌���
	Public SSS_LASTKEY As New VB6.FixedLengthString(128) '��ʕ\���pKEY
	Public SSS_FASTKEY As New VB6.FixedLengthString(128) '��ʕ\���pKEY
	Public SSS_LSTOP As Short '������f�t���b�O�iTRUE:���~�j
	Public SSS_ExportFLG As Short '�t�@�C���o�͋敪
	Public SSS_ExportFileKB As Short '�o�̓t�@�C���쐬�敪
	Public SSS_ExportFileType As Short '�t�@�C���^�C�v�敪
	Public SSS_ExecuteFile(10) As String '���s�`�F�[���t�@�C��
	Public SSS_UPDATEFL As Short '�X�V�\�t���O
	Public SSS_ExecuteMsgFL As Short '�X�V�����b�Z�[�W�t���O
	Public SSS_BILFL As Short '�r�����O���s�敪(1:���s/9:�Ȃ�)
	Public SSS_INICnt As Short 'INI �t�@�C���ŏI�C���f�b�N�X
	Public SSS_DeleteFl As Short '�폜���s�t���O  98/03/19
	Public SSS_MainDe As Short 'Main ��ʃC���f�b�N�X  98/03/19
	Public SSS_VALKB As Boolean '�L���f�[�^�敪(True=���׍s�Ȃ��ł̓o�^��)
	Public SSS_STRIPE_COLOR As Integer '�X�g���C�v�F
	
	Public Const SSS_ReTryCnt As Short = 100 '���O�t�@�C���I�[�v�����g���C�J�E���g
	'
	Public Const SSS_OK As Short = 1 '�E�C���h�E�ɂĎg�p
	Public Const SSS_NEXT As Short = 2 '
	Public Const SSS_NPSN As Short = 3 '
	Public Const SSS_RPSN As Short = 4 '
	Public Const SSS_END As Short = 5 '
	Public Const SSS_SKIP As Short = 6 '
	
	Public Const SSS_STRIPE_ET As Integer = &HFFFFC0 '
	Public Const SSS_STRIPE_DL As Integer = &HC0FFC0 '
	Public Const SSS_STRIPE_MR As Integer = &HFFFFC0 '
	Public Const SSS_STRIPE_MT As Integer = &HFFFFC0 '
	
	Public SSS_ZEIRT(8) As Decimal '����ŗ��i�敪�ʔz��j
	
	'#Start(2003.3.28) �����O�t�@�C���l�[�����ɑΉ�
	Public Const MAX_PATH As Short = 260
	'#End(2003.3.28)
	
	'2001/04 ���ԑ���p�ϐ� �� ���v���ԑ���p���[�`��(PutLogTime)�Ŏg�p
	Public SSS_SttTm As Object
	Public SSS_FinTm As Object
	Public TimeMode As Short
	
	'2001/04 ���[�h�I�����[���[�h
	Public SSS_ReadOnly As Short
	
	'�t�@�C���\���̏������p�f�[�^
	Structure DB_CLRDAT
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2048),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2048)> Public FILLER() As Char '�������f�[�^
	End Structure
	Public DB_CLRREC As DB_CLRDAT
	
	' �����֌W
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
	Public SSS_MSTKB As New VB6.FixedLengthString(1) '�}�X�^�敪
	Public Const MSTKB_TOKMTA As String = "1" '  ���Ӑ�}�X�^�敪
	Public Const MSTKB_NHSMTA As String = "2" '  �[�i��}�X�^�敪
	Public Const MSTKB_TANMTA As String = "3" '  �S���҃}�X�^�敪
	Public Const MSTKB_SIRMTA As String = "4" '  �d����}�X�^�敪
	Public Const MSTKB_HINMTA As String = "5" '  ���i�}�X�^�敪
	Public Const MSTKB_BMNMTA As String = "6" '  ����}�X�^�敪
	'
	' eee ���[�h
	'
	Public Const EEEMODE_APPEND As Short = 1 ' �ǉ�
	Public Const EEEMODE_SELECT As Short = 2 ' �I��
	Public Const EEEMODE_INQUIRE As Short = 3 ' �⍇��
	Public Const EEEMODE_UPDATE As Short = 4 ' �X�V
	
	' Function �p�����[�^
	' MsgBox �p�����[�^
	Public Const MB_OK As Short = 0 ' OK �{�^���̂�
	Public Const MB_OKCANCEL As Short = 1 ' OK �� ��ݾ� �{�^��
	Public Const MB_ABORTRETRYIGNORE As Short = 2 ' ���~, �Ď��s, ���� �{�^��
	Public Const MB_YESNOCANCEL As Short = 3 ' �͂�, ������, ��ݾ� �{�^��
	Public Const MB_YESNO As Short = 4 ' �͂�, ������ �{�^��
	Public Const MB_RETRYCANCEL As Short = 5 ' �Ď��s �� ��ݾ� �{�^��
	
	Public Const MB_ICONSTOP As Short = 16 ' �x��
	Public Const MB_ICONQUESTION As Short = 32 ' �m�F
	Public Const MB_ICONEXCLAMATION As Short = 48 ' ����
	Public Const MB_ICONINFORMATION As Short = 64 ' �C���t�H���[�V�����̃A�C�R��
	
	Public Const MB_APPLMODAL As Short = 0 ' �A�v���P�[�V���� ���[�_��
	Public Const MB_DEFBUTTON1 As Short = 0 ' �� 1 �{�^�����f�t�H���g�ɂ���
	Public Const MB_DEFBUTTON2 As Short = 256 ' �� 2 �{�^�����f�t�H���g�ɂ���
	Public Const MB_DEFBUTTON3 As Short = 512 ' �� 3 �{�^�����f�t�H���g�ɂ���
	Public Const MB_SYSTEMMODAL As Short = 4096 ' �V�X�e�� ���[�h
	
	' MsgKB ���b�Z�[�W���
	Public Const SSS_GINFO As String = "9" ' �A�C�e���ɑ΂������
	Public Const SSS_EEE As String = "0" ' �������̃��b�Z�[�W
	Public Const SSS_CONFRM As String = "1" ' �m�F���b�Z�[�W
	Public Const SSS_ERROR As String = "2" ' �r�r�r�G���[���b�Z�[�W
	Public Const SSS_CINFO As String = "3" ' �r�r�r�v�����v�g�\��
	' MsgBox �{�^���̖߂�l
	Public Const IDOK As Short = 1 ' OK �{�^��
	Public Const IDCANCEL As Short = 2 ' ��ݾ� �{�^��
	Public Const IDABORT As Short = 3 ' ���~ �{�^��
	Public Const IDRETRY As Short = 4 ' �Ď��s �{�^��
	Public Const IDIGNORE As Short = 5 ' ���� �{�^��
	Public Const IDYES As Short = 6 ' �͂� �{�^��
	Public Const IDNO As Short = 7 ' ������ �{�^��
	
	'[���] �_�C�A���O �t���O
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
    '   SYSTBE       �^�p���O��`��                                           =
    '==========================================================================
    '2019/09/23 DEL START
    'Structure TYPE_DB_SYSTBE
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public PRGID() As Char '�v���O����ID          X(8)
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(60),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=60)> Public LOGNM() As Char '���l(�װ���E�^�p)   X(60)
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h      X(8)
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c      X(05)
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ���߁i���ԁj      9(06)
    'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ���߁i���t�j      9(08)
    'End Structure
    'Public DB_SYSTBE As TYPE_DB_SYSTBE
    '2019/09/23 DEL END
    Public DBN_SYSTBE As Short
	
	'==========================================================================
	'   LINK_IN,OUT   �A�g���R�[�h��`��                                      =
	'==========================================================================
	Structure TYPE_LINK
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public DENNO() As Char '�`�[�ԍ�          X(8)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public DENDT() As Char '�`�[���t          X(8)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public TOKCD() As Char '���Ӑ�CD          X(6)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public SIRCD() As Char '�d����CD          X(6)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public NHSCD() As Char '�[�i��CD          X(6)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public BMNCD() As Char '����CD            X(6)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(16),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=16)> Public HINCD() As Char '���iCD            X(16)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public SOUCD() As Char '�q�ɺ���          X(3)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(41),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=41)> Public FILLER() As Char
	End Structure
	Public Link_IN As TYPE_LINK
	Public Link_OUT As TYPE_LINK
	'
	Structure TYPE_LINK_CLR
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(100),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=100)> Public FILLER() As Char
	End Structure
	Public Link_Clr As TYPE_LINK_CLR
	'
	Public Link_ON As Short '�v���O���������N����p�t���O
	Public Link_Index As Short '�v���O���������N�p�C���f�b�N�X
	
	''2001/06/11 ��ʈ��k�@�\
	Private Structure TYPE_BAR
		Dim ctr As System.Windows.Forms.Control ' �o�[�R���g���[��
		Dim iBarCnt As Short ' �o�[�i�[�R���g���[����
		Dim ctrBars() As System.Windows.Forms.Control ' �o�[�i�[�R���g���[��
	End Structure
	
	Private Structure TYPE_RELINFO
		Dim ctr As System.Windows.Forms.Control ' �אڃR���g���[��
		Dim bJstFg As Boolean ' ���א�=��ӁA���א�=���ӂƈ�v
	End Structure
	
	Private Structure TYPE_CTRLINFO
		Dim nLeft As Integer ' Left�l
		Dim nTop As Integer ' Top�l
		Dim nHeight As Integer ' Height�l
		Dim nWidth As Integer ' Width�l
		Dim ctr As System.Windows.Forms.Control ' �R���g���[��
		Dim iLeftCnt As Short ' ���אڃR���g���[����
		Dim tLefts() As TYPE_RELINFO ' ���אڃR���g���[��
		Dim iDownCnt As Short ' ���אڃR���g���[����
		Dim tDowns() As TYPE_RELINFO ' ���אڃR���g���[��
	End Structure
	
	Private Structure TYPE_CTRLGRP
		Dim sGrpNm As String ' �R���e�i�O���[�v��
		Dim iCtrCnt As Short ' �R���g���[����
		Dim tCtrs() As TYPE_CTRLINFO ' �R���g���[�����
	End Structure
	''
	'
	Function Get_SMEDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pdendt As String, ByVal pnext As Short) As String
		' ���������Z�o�i���j  ���������t�^���T�C�N���^�`�[���t�^���[�敪
		Dim mm, dd, yy As Short
		Dim cnt, I As Short
		Dim idx, setidx, addMM As Short
		Dim smeday(15) As Short
		'
		yy = Year(CDate(pdendt))
		mm = Month(CDate(pdendt))
		dd = VB.Day(CDate(pdendt))
		'
		If psmecc = 1 Then '��������
			Get_SMEDT1 = CStr(DateSerial(yy, mm, dd + pnext))
			Exit Function
		End If
		'
		If psmecc <= 0 Or psmecc > 15 Then psmecc = 30
		cnt = Int(30 / psmecc) '���񐔁^��
		setidx = False
		For I = 0 To cnt - 1
			smeday(I) = psmedd + psmecc * I
			If smeday(I) > 27 Then smeday(I) = 99
			If dd <= smeday(I) And setidx = False Then
				idx = I + pnext '�Y�����t�̒����z��Y��
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
		Dim DB_SYSTBA As Object
		' �Y���o�������t
		'
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("���t�G���[(Get_Acedt): " & wdate)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_SYSTBA.SMADD > "27" Then
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
			'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf Right(wdate, 2) <= DB_SYSTBA.SMADD Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Get_Acedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBA.SMADD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, SSSVal(DB_SYSTBA.SMADD)))
		End If
	End Function
	
	Function Get_STTSMEDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pdendt As String) As String
		' �����J�n���t�Z�o�i���j  ���������t�^���T�C�N���^�`�[���t
		Dim mm, dd, yy As Short
		Dim cnt, I As Short
		Dim idx, setidx, addMM As Short
		Dim smeday(15) As Short
		'
		yy = Year(CDate(pdendt))
		mm = Month(CDate(pdendt))
		dd = VB.Day(CDate(pdendt))
		'
		If psmecc = 1 Then '��������
			Get_STTSMEDT1 = pdendt '������Ԃ�
			Exit Function
		End If
		'
		If psmecc <= 0 Or psmecc > 15 Then psmecc = 30
		cnt = Int(30 / psmecc) '���񐔁^��
		setidx = False
		For I = 0 To cnt - 1
			smeday(I) = psmedd + psmecc * I
			If smeday(I) > 27 Then smeday(I) = 99
			If dd <= smeday(I) And setidx = False Then
				idx = I - 1 '�Y�����t�̑O�̒����z��Y��
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
		' ���t�̔ėp�`�F�b�N�i�Q�O�T�O�N�܂ŗL���j
		'
		On Error GoTo ErrDate
		'UPGRADE_WARNING: �I�u�W�F�N�g DT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If IsDate(DT) And Year(DT) <= 2050 And Year(DT) >= 1900 Then
			CHECK_DATE = True
		Else
ErrDate: 
			CHECK_DATE = False
		End If
	End Function
	
	Sub Clr_Prompt(ByRef PP As clsPP)
		' SSS/Win �ŕ\�������v�����v�g���b�Z�[�W�������܂��B
		'
		Call AE_StatusClear(PP, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE))
	End Sub
	
	Function CNV_DATE(ByRef pdate As String) As String
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(pdate) = 8 Then
			CNV_DATE = LeftWid(pdate, 4) & "/" & MidWid(pdate, 5, 2) & "/" & RightWid(pdate, 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(pdate) = 6 Then 
			CNV_DATE = LeftWid(pdate, 2) & "/" & MidWid(pdate, 3, 2) & "/" & RightWid(pdate, 2)
		Else
			CNV_DATE = ""
		End If
	End Function
	
	Function DCMFRC(ByRef IN_SU As Decimal, ByRef MARUME As Decimal, ByRef KETA As Decimal) As Decimal
		'  IN_SU:��ҏW���l, MARUME:�܂�߃p�����[�^
		'  KETA:�܂�߂錅�ʒu(������1�ʂ�0 ������2�ʂ�-1 ����1�̈ʂ�1 ����2�̈ʂ�2)
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
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(pdate) = 10 Then
			DeCNV_DATE = LeftWid(pdate, 4) & MidWid(pdate, 6, 2) & RightWid(pdate, 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pdate) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(pdate) = 8 Then 
			DeCNV_DATE = LeftWid(pdate, 2) & MidWid(pdate, 4, 2) & RightWid(pdate, 2)
		Else
			DeCNV_DATE = ""
		End If
	End Function
	
	Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
		'    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
		'    '�����C����ʂ���̃��b�Z-�W�o�͂̂ݑΉ��B�T�u��ʖ��Ή��B
		'    Dim WK_PP As clsPP
		'    WK_PP = PP_SSSMAIN
		'    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
		'' SSS/Win ���ʂ̃��b�Z�[�W��\�����܂��B
		'    '
		'    ''Close��̓��b�Z�[�W��\�����Ȃ�
		'    If RsOpened(DBN_SYSTBH) = False Then Exit Function
		'    ''
		'    DB_SYSTBH.MSGNM = msgName
		'    Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
		'    If DBSTAT = 0 Then
		'        DSP_MsgBox = MsgBox(Trim$(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
		'    Else
		'        MsgBox "���b�Z�[�W�t�@�C���G���[  " & Chr(13) & Chr(13) & "DBSTAT=" & Format$(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & Format$(MSGSQ, "0"), MB_OK, Trim$(SSS_PrgNm)
		'        Call Error_Exit("���b�Z�[�W�t�@�C���G���[!")
		'    End If
		'    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȉ��ǉ�
		'    PP_SSSMAIN = WK_PP
		'    '[V4.1]�@���b�Z�[�W�o�͎���PP��ޔ��@�ȏ�ǉ�
	End Function
	
	Sub Dsp_Prompt(ByRef msgName As String, ByRef MSGSQ As Short, Optional ByRef vForm As Object = Nothing)
		'Dim COLCD As Long
		'    '
		'    DB_SYSTBH.MSGNM = msgName
		'    Call DB_GetEq(DBN_SYSTBH, 1, SSS_CINFO & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
		'    If DBSTAT = 0 Then
		'        Select Case DB_SYSTBH.COLSQ
		'            Case "1"
		'                COLCD = Cn_BLACK
		'            Case "2"
		'                COLCD = Cn_RED
		'            Case "3"
		'                COLCD = Cn_GREEN
		'            Case "4"
		'                COLCD = Cn_YELLOW
		'            Case "5"
		'                COLCD = Cn_BLUE
		'            Case "6"
		'                COLCD = Cn_MAGENTA
		'            Case "7"
		'                COLCD = Cn_CYAN
		'            Case "8"
		'                COLCD = Cn_WHITE
		'        End Select
		'        If IsMissing(vForm) Then
		'            FR_SSSMAIN!TX_Message.Text = DB_SYSTBH.MSGCM
		'            FR_SSSMAIN!TX_Message.ForeColor = COLCD
		'        Else
		'            Dim wForm As Form
		'            Set wForm = vForm
		'            wForm!TX_Message.Text = DB_SYSTBH.MSGCM
		'            wForm!TX_Message.ForeColor = COLCD
		'        End If
		'    End If
	End Sub
	
	Function Dsp_PromptGen(ByRef msgName As String, ByRef MSGSQ As Short) As String
		' �W���W�F�l���[�g���b�Z�[�W�̕\��
		'
		'    DB_SYSTBH.MSGNM = msgName
		'    Call DB_GetEq(DBN_SYSTBH, 1, SSS_GINFO & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
		'    If DBSTAT = 0 Then
		'        Dsp_PromptGen = Trim$(DB_SYSTBH.MSGCM)
		'    Else
		'        Call Error_Exit("���b�Z�[�W�t�@�C���G���[!")
		'    End If
	End Function
	
	Sub Error_Exit(ByVal ErrorMsg As String)
		'Dim rtn, I As Integer
		'    '
		'    Call SSSWIN_LOGWRT(ErrorMsg)
		'    MsgBox "�v���O�������I�����܂��B", MB_OK, Trim$(SSS_PrgNm)
		'    '
		'    If DBSTAT <> 0 Then
		'        MsgBox "�G���[���O�̏������݃G���[ ! Windows ���ċN�����Ă�������"
		'    '
		'    Else
		'        For I = SSS_MAX_DB - 1 To 0 Step -1
		'            Call DB_NCCLOSE(I)
		'        Next I
		'    End If
		'    Call DB_End
		'''''rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
		'    End
	End Sub
	
	Function FillVal(ByVal ch As String, ByVal cnt As Short) As Object
		' �w�肳�ꂽ�������w��񐔕��A������B
		Dim I As Short
		Dim rtn As String
		'
		For I = 1 To cnt
			rtn = rtn & ch
		Next I
		'UPGRADE_WARNING: �I�u�W�F�N�g FillVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		FillVal = rtn
	End Function
	
	Function Get_BGNAcedt(ByVal yy As Short, ByVal mm As Short) As String
		Dim DB_SYSTBA As Object
		' �����J�n���t
		Dim wdate, acedt As String
		Dim mmdd(1) As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("���t�G���[(Get_BGNAcedt): " & yy & mm)
		End If
		acedt = Get_STTTouAcedt(yy, mm)
		mmdd(1) = RightWid(acedt, 5)
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBA.SMADD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMAMM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mmdd(0) = RightWid(CStr(DateSerial(1995, SSSVal(DB_SYSTBA.SMAMM), SSSVal(DB_SYSTBA.SMADD) + 1)), 5)
		'
		If mmdd(0) > mmdd(1) Then
			Get_BGNAcedt = VB6.Format(Year(CDate(acedt)) - 1, "0000") & "/" & mmdd(0)
		Else
			Get_BGNAcedt = VB6.Format(Year(CDate(acedt)), "0000") & "/" & mmdd(0)
		End If
	End Function
	
	Function Get_KESDT1(ByVal psmedd As Short, ByVal psmecc As Short, ByVal pkesmm As Short, ByVal pkesdd As Short, ByVal pdate As String) As String
		' ������t�Z�o�i���j  ���������t�^���T�C�N���^����T�C�N���^������^�������
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
		' ������t�Z�o�i�j���j  ���������t�^����T�C�N���^������^�`�[���t
		'
		Get_KESDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + pkesmm * 7 + pkesdd - psmedd))
	End Function
	
	Function Get_SMEDT2(ByVal psdwkb As Short, ByRef pdate As String, ByRef pnext As Short) As String
		' ���������t�Z�o�i�j���j
		'
		If WeekDay(CDate(pdate)) > psdwkb Then
			Get_SMEDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + (7 - WeekDay(CDate(pdate)) + psdwkb) + (7 * pnext)))
		Else
			Get_SMEDT2 = CStr(DateSerial(Year(CDate(pdate)), Month(CDate(pdate)), VB.Day(CDate(pdate)) + (psdwkb - WeekDay(CDate(pdate))) + (7 * pnext)))
		End If
	End Function
	
	Function Get_STTTouAcedt(ByVal yy As Short, ByVal mm As Short) As String
		Dim DB_SYSTBA As Object
		'�����o���J�n���t
		Dim wdate As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("���t�G���[(Get_STTTouAcedt): " & yy & mm)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_SYSTBA.SMADD > "27" Then
			Get_STTTouAcedt = LeftWid(wdate, 8) & "01"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_SYSTBA.SMADD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Get_STTTouAcedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) - 1, SSSVal(DB_SYSTBA.SMADD) + 1))
		End If
	End Function
	
	Function Get_TouAcedt(ByVal yy As Short, ByVal mm As Short) As String
		Dim DB_SYSTBA As Object
		' �����o�������t
		Dim wdate As String
		'
		wdate = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		If Not CHECK_DATE(wdate) Then
			Call Error_Exit("���t�G���[(Get_TouAcedt): " & yy & mm)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If DB_SYSTBA.SMADD > "27" Then
			Get_TouAcedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DB_SYSTBA.SMADD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Get_TouAcedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		End If
	End Function
	
	Function HighValue(ByRef cnt As Short) As String
		HighValue = New String(Chr(122), cnt)
	End Function
	
	Sub Init_Prompt()
        ' �v�����v�g�\���̈�����������܂��B
        '
        '2019/09/23 DEL START
        '      CType(FR_SSSMAIN.Controls("IM_Denkyu"), Object)(0).Image = CType(FR_SSSMAIN.Controls("IM_Denkyu"), Object)(1).Image
        'CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
        '      CType(FR_SSSMAIN.Controls("TX_Message"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&H0)
        '2019/09/23 DEL END
    End Sub
	
	Sub Init_SubPrompt()
		'' �v�����v�g�\���̈�����������܂��B
		'    '
		'    FR_SSSSUB!IM_Denkyu(0).Picture = FR_SSSSUB!IM_Denkyu(1).Picture
		'    FR_SSSSUB!SUB_TX_Message.Text = ""
		'    FR_SSSSUB!SUB_TX_Message.ForeColor = &H0&
	End Sub
	
	Function JSTDT(ByVal IN_DT As String) As String
		Dim FormatDate As String
		Dim dd, yy, mm, I As Decimal
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		yy = SSSVal(LeftWid(IN_DT, 4))
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mm = SSSVal(MidWid(IN_DT, 5, 2))
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
	
	'���[�_�������N�֐�
	'�G���[�R�[�h�ɒ��ӁiLink_Shell�֐��͖߂�l 0 ���G���[�j
	'      * VBEXEC1�֐��̖߂�l
	'              0 : ����.
	'          10001 : �N�����s.
	'             -4 : �^�C�}�ݒ莸�s.
	'             -5 : �I���Ď����ɌĂяo��������ēx�Ă΂ꂽ.
	'           -999 : �����I��.
	'
	Function Link_Modal(ByVal EXE_NM As String) As Short
		Dim Rtc As Object
		Dim Full_Nm As String
		On Error Resume Next
        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'Link_Clr = LSet(Link_OUT)
        '2019/09/23 DEL END
        Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & SSS_CLTID.Value & SSS_OPEID.Value & ":" & Link_Clr.FILLER & Chr(34)
		Link_Modal = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, Full_Nm)
        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'Link_Clr = LSet(Link_IN)
        '2019/09/23 DEL END
    End Function
	
	Function Link_Shell(ByVal EXE_NM As String) As Short
		Dim Rtc As Short
		Dim Full_Nm As String
		On Error Resume Next
        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'Link_Clr = LSet(Link_OUT)
        '2019/09/23 DEL END
        Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & LeftWid(SSS_CLTID.Value, 5) & LeftWid(SSS_OPEID.Value, 8) & ":" & Link_Clr.FILLER & Chr(34)
		Link_Shell = Shell(Full_Nm, 1)
        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'Link_Clr = LSet(Link_IN)
        '2019/09/23 DEL END
        If Link_ON Then '���j���[�N���łȂ��ꍇ�ɂ͏I������
			SSS_NoMsg_EXIT()
		End If
	End Function
	
	Function SSS_EDTITM_EEE(ByRef CP As clsCP, ByVal Item As Object, ByVal De As Object) As Object
		Dim WrkStr As Object
		On Error GoTo ErrEdit
		'UPGRADE_WARNING: �I�u�W�F�N�g Item �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WrkStr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WrkStr = IIf(Item = 0, Nothing, FormatAndRound(Item, CP.FormatChr))
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WrkStr) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(WrkStr) > CP.MaxLength Then
			If CP.KeyInOkClass = Asc("C") Then
ErrEdit: 
				SSS_EDTITM_EEE = New String("*", CP.MaxLength)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g WrkStr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SSS_EDTITM_EEE = RightWid(WrkStr, CP.MaxLength)
			End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WrkStr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSS_EDTITM_EEE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_EDTITM_EEE = WrkStr
		End If
	End Function
	
	Function SSS_EDTITM_WLS(ByVal Item As Object, ByVal KETA As Object, ByVal HENSYU As Object) As String
		Select Case HENSYU
			Case "0"
				'UPGRADE_WARNING: �I�u�W�F�N�g KETA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SSS_EDTITM_WLS = RightWid(FormatAndRound(Item, "00000000000000000000"), KETA)
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Item �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		' �����̍Ō㕶���̃A�X�L�[�l���J��グ��
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If VST = HighValue(LenWid(VST)) Then
			SSS_UPLCHAR = VST
		Else
			Select Case LenWid(VST)
				Case 0
					SSS_UPLCHAR = VST
				Case 1
					SSS_UPLCHAR = Chr(Asc(VST) + 1)
				Case Else
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					SSS_UPLCHAR = MidWid(VST, 1, LenWid(VST) - 1) & Chr(Asc(MidWid(VST, LenWid(VST), 1)) + 1)
			End Select
		End If
	End Function
	
	Function SSS_WEEKNM(ByVal idx As Short) As String
		' �j������Ԃ��B
		Select Case idx
			Case 1
				SSS_WEEKNM = "���j��"
			Case 2
				SSS_WEEKNM = "���j��"
			Case 3
				SSS_WEEKNM = "�Ηj��"
			Case 4
				SSS_WEEKNM = "���j��"
			Case 5
				SSS_WEEKNM = "�ؗj��"
			Case 6
				SSS_WEEKNM = "���j��"
			Case 7
				SSS_WEEKNM = "�y�j��"
			Case Else
				SSS_WEEKNM = ""
		End Select
	End Function
	
	Function SSSMAIN_ErrorMsg(ByVal Cd_Error As Object) As Object
		
	End Function
	
	Sub SSSWIN_CLOSE()
		Dim I As Short
		'
		''''    For I = SSS_MAX_DB - 1 To 0 Step -1
		''''        If Left$(DB_PARA(I).DBID, 4) = "USR1" Or Trim$(DB_PARA(I).DBID) >= "USR4" Then
		''''            Call DB_Close(I)
		'''''            If DBSTAT <> 0 Then
		'''''                MsgBox ("�t�@�C���b�k�n�r�d�G���[" + DB_PARA(i).tblid)
		'''''            End If
		''''        Else
		''''            Call JB_Close(I)
		''''        End If
		''''    Next I
		''''    '
		''''    Call SSS_CLOSE
		''''    Call SSSWIN_LOGWRT("�v���O�����I��")
	End Sub
	
	Sub SSSWIN_INIT()
		''''Dim I%
		''''Dim DT, YMD$
		'''''   ���t�`���`�F�b�N 1997/02/17 �ǉ�
		''''    DT = Date
		''''    YMD = Format(Year(DT), "0000") & "/" & Format(Month(DT), "00") & "/" & Format(Day(DT), "00")
		''''    If CStr(DT) <> YMD Then
		''''        MsgBox "���t�̌`�� '" & CStr(DT) & "' ���Ⴂ�܂��B" & vbCrLf _
		'''''             & "�R���g���[���p�l���̒n��i�n���̊G�j�̓��t" & vbCrLf _
		'''''             & "�̒Z���`���� yyyy/MM/dd �ɕύX���ĉ������B", vbCritical
		''''        Call Error_Exit("���t�̌`�����Ⴂ�܂��B")
		''''    End If
		''''    '---------------------
		''''    ' �N���p�����[�^�ݒ�
		''''    '---------------------
		''''    I = LenWid(Trim$(Command$))
		''''    If I < 15 Then
		''''        MsgBox "���j���[������s���Ă��������B", vbOKOnly, SSS_PrgNm
		''''        Call Error_Exit("���j���[������s���Ă��������B")
		''''    End If
		''''    SSS_CLTID = MidWid$(Command$, 2, 5)
		''''    SSS_OPEID = MidWid$(Command$, 7, 8)
		''''    Link_Clr.FILLER = ""
		''''    LSet Link_OUT = Link_Clr
		''''    Link_ON = False
		''''    If I > 15 Then ' 1997/04/17
		''''        Link_ON = True
		''''        Link_Clr.FILLER = MidWid$(Command$, 16, I - 15) ' 1997/04/17
		''''    End If
		''''    LSet Link_IN = Link_Clr
		''''
		''''    '2001/04 ���[�h�I�����[���[�h�ݒ�
		''''    If Left$(Command$, 1) = "'" Then SSS_ReadOnly = True
		''''
		''''    '---------------------
		''''    ' �ް��ް���������
		''''    '---------------------
		''''    Call DB_Start("", "") ' 1997/02/12
		''''    Call DB_SetPGID(SSS_PrgId)
		''''    '�v���O�������̂����O�ɏo�͂���(2003.3.13)>>
		''''    Call DB_SetPGNM(SSS_PrgNm)
		''''    '<<(2003.3.13)
		''''
		''''    '---------------------
		''''    ' SSSWIN.INI �e�[�u���ݒ�
		''''    '---------------------
		''''    SSS_INIDATNM(0) = "USR_PATH"
		''''    SSS_INIDATNM(1) = "DAT_PATH"
		''''    SSS_INIDATNM(2) = "PRG_PATH"
		''''    SSS_INIDATNM(3) = "WRK_PATH"
		''''    SSS_INIDATNM(4) = "IMG_PATH"
		''''    SSS_INICnt = 4
		''''    Call SSSWIN_INIT_GETINI
		''''    '
		''''    Call Init_Fil
		''''
		''''    ''2001/12/14 ��ʈ��k�@�\
		''''    ''�i��ʂ��傫������ꍇ�ɂ�, �T�C�Y��80%�t�H���g��7.5P�ɏk���j
		''''    FormControls FR_SSSMAIN
		''''    '
		''''    PP_SSSMAIN.FormWidth = FR_SSSMAIN.Width
		''''    PP_SSSMAIN.FormHeight = FR_SSSMAIN.Height
		''''    FR_SSSMAIN.Top = (Screen.Height - FR_SSSMAIN.Height) / 2
		''''    FR_SSSMAIN.Left = (Screen.Width - FR_SSSMAIN.Width) / 2
		''''    FR_SSSMAIN!SYSDT.Caption = Format$(Now, "YYYY/MM/DD")
		''''    FR_SSSMAIN.Icon = ICN_ICON.Icon
		''''    FR_SSSMAIN.Caption = Trim$(SSS_PrgNm)
		''''
		''''    ''2001/12/14 �ꏊ���W�s��ɕύX
		''''    ''2001/06/11 ��ʈ��k�@�\
		''''    ''�i��ʂ��傫������ꍇ�ɂ�, �T�C�Y��80%�t�H���g��7.5P�ɏk���j
		''''    'FormControls FR_SSSMAIN
		''''
		''''    AE_Title = SSS_PrgId
		''''
		''''    '2001/04 ���ԑ��胂�[�h���ǂ���
		''''    Call SetTimeLog
	End Sub
	
	Sub SSSWIN_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI �Ǎ���
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", SSS_INIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				MsgBox("SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & SSS_INIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI ���m�F���Ă��������B[" & SSS_INIDATNM(I) & "]")
			Else
				'#Start(2003.4.3) �����p�X�A�S�p�����܂ރp�X�Ή�
				'SSS_INIDAT(I) = Left$(rtnPara, LENGTH)
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
				'#End(2003.4.3)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub
	
	Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
		''''Dim Fno As Integer, errcnt As Integer, rtn As Integer
		''''Dim wbuf As String
		''''    '
		''''    Call ResetDBSTAT(DBN_SYSTBE)
		''''    '
		''''    LSet DB_SYSTBE = DB_CLRREC
		''''    DB_SYSTBE.PRGID = SSS_PrgId
		''''    DB_SYSTBE.LOGNM = LogMsg
		''''    DB_SYSTBE.OPEID = SSS_OPEID
		''''    DB_SYSTBE.CLTID = SSS_CLTID
		''''    DB_SYSTBE.WRTTM = Format$(Now, "hhnnss")
		''''    DB_SYSTBE.WRTDT = Format$(Now, "YYYYMMDD")
		''''    '
		''''    errcnt = 0
		''''    Fno = FreeFile
		''''    On Error Resume Next
		''''    '�f�B���N�g�����݃`�F�b�N
		''''    wbuf = Dir$(SSS_INIDAT(1), 16)
		''''    If wbuf = "" Then
		''''        Call MsgBox("SSSWIN.INI �� DAT_PATH �̐ݒ肳��Ă���f�B���N�g�������݂��܂���B" & Chr(13) & "SSSWIN.INI���C�����ĉ������B", 48)
		''''        'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
		''''''''        Call SSS_CLOSE
		''''''''        rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
		''''        End
		''''    End If
		''''    Err = 0
		''''    On Error GoTo ErrorLogFile
		''''    Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
		''''    On Error GoTo 0
		''''    Print #Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT
		''''    Close #Fno
		''''    Exit Sub
		''''ErrorLogFile:
		''''    errcnt = errcnt + 1
		''''    If errcnt > SSS_ReTryCnt Then
		''''        If MsgBox("�����t�@�C�����b�N�G���[ !" & Chr$(13) & "���~���Ă��X�����ł����H", 20) = 6 Then
		''''''''            Call SSS_CLOSE
		''''''''            rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
		''''            End
		''''        Else
		''''            errcnt = 0
		''''        End If
		''''    End If
		''''    DoEvents
		''''    Resume
	End Sub
	
	Sub SSSWIN_OPEN()
		''''    Dim I As Integer, DBFLocation  As String
		''''    '
		''''    Call SSSWIN_LOGWRT("�v���O�����N��")
		''''    '
		''''    For I = 0 To SSS_MAX_DB - 1
		''''        If Trim$(DB_PARA(I).DBID) = "USR1" Or Trim$(DB_PARA(I).DBID) >= "USR4" Then
		''''            Call DB_Open(I, DB_PARA(I).DBID, DB_PARA(I).tblid)
		''''            If DBSTAT <> 0 Then
		''''                MsgBox ("�t�@�C���n�o�d�m�G���[" + DB_PARA(I).tblid + Str$(DBSTAT)): End
		''''            End If
		''''        Else
		''''        ' Link�`�F�b�N�O�� 97/02/12
		''''            Call JB_Open(I)
		''''        End If
		''''    Next I
		''''    '
		''''    Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
	End Sub
	
	Sub SSS_NoMsg_EXIT()
		Dim rtn As Object
		
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: �I�u�W�F�N�g rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
		End
	End Sub
	
	Function SSSVal(ByRef INP_Value As Object) As Object
		If IsNumeric(INP_Value) = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g INP_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSVal = CDec(INP_Value)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSSVal = 0
		End If
	End Function
	
	'�r�����~�^�t���O�t�@�C���̍쐬
	'vFname:�v���O�����h�c�B�K�{
	'vPrgNm:���~�E�B���h�E��\�������v���O�������́B�ȗ����ꂽ�ꍇ�́ASSS_PrgNm���g��
	'-----------------------
	Sub Make_infoFile(ByRef vFname As String, Optional ByRef vPrgNm As Object = Nothing)
		Dim wkFileStr As String
		Dim wkDate As String
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
		wkSchema = Get_DbSchema(wkPkgUsr) '�X�L�[�}��
		wkFileStr = SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID.Value & ".flg"
		'�N���C�A���g��p�t�H���_�ɁAPRGID_�ײ���ID.flg �t�@�C���𗎂Ƃ�
		FileOpen(1, wkFileStr, OpenMode.Output)
		PrintLine(1, SSS_PrgId)
		PrintLine(1, SSS_PrgNm)
		wkDate = VB6.Format(Now, "YYYY/MM/DD")
		PrintLine(1, wkDate)
		wkTime = VB6.Format(Now, "HH:MM:SS")
		PrintLine(1, wkTime)
		FileClose(1)
		'���~�p�v���O�������N��
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(vPrgNm) Then
			cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID.Value & wkSchema & "_" & vFname & "$" & Trim(SSS_PrgNm)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g vPrgNm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID.Value & wkSchema & "_" & vFname & "$" & Trim(vPrgNm)
		End If
		ret = Shell(cmdLine)
	End Sub
	
	'�r�����~�^�t���O�t�@�C���̍폜
	'vFname:�v���O�����h�c�B
	'------------------------
	Sub Remove_infoFile(ByRef vFname As String)
		'make_infoFile �ŃN���C�A���g��p�t�H���_�ɍ쐬�����t�@�C���iPRGID_�ײ���ID.flg�j���폜����
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
		wkSchema = Get_DbSchema(wkPkgUsr) '�X�L�[�}��
		Kill((SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID.Value & ".flg"))
	End Sub
	
	'2001/04 ���ԑ���p���[�`��
	'Global SSS_SttTm
	'Global SSS_FinTm
	'Global TimeMode%
	'
	'���茋�ʂ��o�́iFinTime - SttTime�j
	Sub PutLogTime(ByVal logStr As String)
		Dim Fno As Short
		Dim ClcTime As Object
		Dim Logtime As String
		If Not TimeMode Then Exit Sub
		'UPGRADE_WARNING: �I�u�W�F�N�g SSS_SttTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSS_FinTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ClcTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ClcTime = SSS_FinTm - SSS_SttTm
		Logtime = FormatAndRound(ClcTime, "###,##0.00")
		Fno = FreeFile
		On Error Resume Next
		FileOpen(Fno, SSS_INIDAT(3) & SSS_PrgId & ".Log", OpenMode.Append)
		PrintLine(Fno, logStr & vbTab & "(" & Logtime & ")" & vbTab & SSS_OPEID.Value & SSS_CLTID.Value & vbTab & Now)
		FileClose(Fno)
	End Sub
	
	'���ԑ��肷�邩�� SSSwin.Ini�̏��Ŕ���
	Sub SetTimeLog()
		Dim Buff As New VB6.FixedLengthString(50)
		Dim ret As Object
		Dim GetStr As String
		On Error Resume Next
		Buff.Value = " "
		'UPGRADE_WARNING: �I�u�W�F�N�g ret �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ret = GetPrivateProfileString("SSSWIN", "TIMELOG", "", Buff.Value, Len(Buff.Value), "SSSWIN.INI")
		GetStr = UCase(Left(Buff.Value, InStr(Buff.Value, Chr(0)) - 1))
		If GetStr = "TRUE" Then TimeMode = True
	End Sub
	
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	' ���̃T�u���[�`���ł́ASYSTBH�ɓo�^���Ă���MSGKB�� "S" �Ɠ���B
	' �G���[���b�Z�[�W��\��������̏����́A�A�v�����ōs��
	' �⏕���b�Z�[�WExtMsg�̂���ꍇ�́A�V���̍s�ł��̃��b�Z�[�W��\������
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Sub SSS_ERROR_CHECK(ByRef ErrCode As Short, ByRef tblName As String, ByRef SeqNo As String, ByRef ExtMsg As String)
		'Dim ret As Integer
		'Dim wkMsg As String
		'
		'    wkMsg = ""
		'    If Trim(G_PlCnd2.sErrMsg) <> "" Then wkMsg = Chr(13) & "--------------" & Chr(13) & Trim(G_PlCnd2.sErrMsg)
		'
		'    Select Case ErrCode
		'    Case -20099                             'SYSTBH�ɓo�^���Ă��郁�b�Z�[�W��\������
		'        DB_SYSTBH.MSGNM = tblName
		'        Call DB_GetEq(DBN_SYSTBH, 1, "S" & DB_SYSTBH.MSGNM & Format$(SeqNo, "0"), BtrNormal)
		'        If DBSTAT = 0 Then
		'            'SYSTBH�ɊY�����b�Z�[�W�����݂��Ă���ꍇ
		'            If ExtMsg = "" Then
		'                ret = MsgBox(Trim$(DB_SYSTBH.MSGCM) & wkMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
		'            Else
		'                ret = MsgBox(Trim$(DB_SYSTBH.MSGCM) & Chr(13) & ExtMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
		'            End If
		'        Else
		'            'SYSTBH�ɊY�����b�Z�[�W���o�^���Ă��Ȃ��ꍇ
		'            MsgBox "���b�Z�[�W�e�[�u���ɓo�^����Ă��Ȃ����b�Z�[�W��\�����悤�Ƃ��܂����B" & Chr(13) & "�e�[�u����=[" & Trim(tblName) & "]" & Chr(13) & "�A��=[" & Format$(SeqNo, "0") & "]" & Chr(13) & "�V�X�e���̊J���T�C�h�ɂ��A��������", vbOKOnly Or vbCritical, SSS_PrgNm
		'        End If
		'    Case -20005, 20005, -20006, 20006, -20007, 20007, -20008, 20008     '�T�[�o���t�@�C���h�^�n�G���[
		'        MsgBox "�T�[�o���̃t�@�C���h�^�n����G���[���������܂����B" & Chr(13) & "�T�[�o���̃��O�p�t�H���_�ɖ�肪����Ǝv���܂��B" & Chr(13) & "�V�X�e���Ǘ��҂ɂ��A���������B" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
		'    Case -20010, 20010                             '���[�U�ɂ�钆�~���ꂽ
		'        MsgBox "���[�U�[�ɂ����s�����~����܂����B" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
		'    Case -20015, 20015                             '���������݂��Ă��Ȃ�
		'        MsgBox "���������쐬�ł��B" & Chr(13) & "�Ǘ��c�[���ŏ����̍쐬�^�X�V���s���ĉ������B" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
		'    Case Else
		'        '�I���N���̈�ʃG���[�̏ꍇ
		'        If ErrCode = -54 Then
		'            MsgBox "���̃��[�U�ɂ��f�[�^�����b�N����Ă��܂��B" & Chr(13) & "�b�炭�҂��Ă���Ď��s���ĉ������B" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
		'        Else
		'            MsgBox "�f�[�^�x�[�X���ɃG���[���������܂����B" & Chr(13) & "�G���[�ԍ� ���m " & Str$(ErrCode) & " �n" & Chr(13) & "�V�X�e���Ǘ��҂ɂ��A���������B" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
		'        End If
		'    End Select
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
		' �S�Ẵt���[���Ŏg�p�\
		'       vPack="HDNDL05" �� HDNDL05_PACK, vPack = "" �̎��́ASSS_PrgID ���g�p�����
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
		
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(vFraId) Then
			'�ʏ�̃P�[�X
			wkFraId = Left(SSS_FraId, 2)
		Else
			'DL����h�����_�E����ET���ďo���ꍇ�Ȃ�
			'UPGRADE_WARNING: �I�u�W�F�N�g vFraId �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		'���݂̊���DBHEAD ��Ԃ��A�����ݒ�̏ꍇ�́A""��Ԃ��B
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function
	
	''2001/06/11 ��ʈ��k�@�\
	''2001/07/16 �ꕔ����
	''2001/11/09 ��ʏ��͂������𗘗p
	' �t�H�[���̐L�k
	'   I   frm         �t�H�[��
	'   I   gOptFntSz   �t�H���g�T�C�Y
	Public Sub FormControls(ByVal frm As System.Windows.Forms.Form, Optional ByVal gOptFntSz As Single = 0)
		On Error Resume Next
		Dim I, iGrpCnt As Short
		Dim nHeight, nLeft, nWidth As Integer
		Dim gFactor, gFntSz As Single
		Dim sFrmNm As String
		Dim ctr As System.Windows.Forms.Control
		'UPGRADE_WARNING: �\���� tMsg �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �\���� tTol �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim tTol, tMsg As TYPE_BAR
		Dim tGrps() As TYPE_CTRLGRP
		
		''2001/11/09 ��ʏ��͂������𗘗p
		If PP_SSSMAIN.FormHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) Or PP_SSSMAIN.FormWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) Then
			''If frm.Height > Screen.Height Or frm.Width > Screen.Width Then
			gFactor = 0.8
			
			Select Case gOptFntSz
				Case 0, 7.5 : gFntSz = 7.5
				Case Else : gFntSz = 8
			End Select
			
			sFrmNm = frm.Name
			
			' �o�[�R���g���[���̎擾
			getBarControls(frm, tTol, tMsg)
			
			' �␳�ΏۃR���g���[���̐ݒ�
			getHoseiControls(frm, iGrpCnt, tGrps)
			
			' �t�H�[���̐L�k
			''2001/11/09 ��ʏ��͂������𗘗p
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
			
			' �R���g���[���̐L�k
			tTol.iBarCnt = 0
			tMsg.iBarCnt = 0
			
			For	Each ctr In frm.Controls
                'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                '2019/09/23 CHG START
                'If (TypeOf ctr Is System.Windows.Forms.ToolStripMenuItem) Or (TypeOf ctr Is System.Windows.Forms.Timer) Then
                If (TypeOf ctr Is System.Windows.Forms.ContextMenuStrip) Then
                    '2019/09/23 CHG END
                    'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                ElseIf TypeOf ctr Is System.Windows.Forms.Label Then
                    '2019/09/23 DEL START
                    'UPGRADE_WARNING: �I�u�W�F�N�g ctr.X1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ctr.X1 = calTwip(ctr.X1, gFactor)
                    'UPGRADE_WARNING: �I�u�W�F�N�g ctr.X2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ctr.X2 = calTwip(ctr.X2, gFactor)
                    'UPGRADE_WARNING: �I�u�W�F�N�g ctr.Y1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ctr.Y1 = calTwip(ctr.Y1, gFactor)
                    'UPGRADE_WARNING: �I�u�W�F�N�g ctr.Y2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ctr.Y2 = calTwip(ctr.Y2, gFactor)
                    '2019/09/23 DEL END
                Else
                        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                        If TypeOf ctr Is System.Windows.Forms.PictureBox Then
						'UPGRADE_WARNING: �I�u�W�F�N�g getContainer(ctr).Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Select Case getContainer(ctr).Name
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
						
						'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
						If TypeOf ctr Is System.Windows.Forms.TextBox Then
							'UPGRADE_WARNING: �I�u�W�F�N�g getContainer(ctr).Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Select Case getContainer(ctr).Name
								Case tTol.ctr.Name : ctr.Left = VB6.TwipsToPixelsX(nLeft)
							End Select
						End If
					End If
				End If
			Next ctr
			
			' �c�[���o�[�ƃ��b�Z�[�W�o�[�̕␳
			hoseiBar(frm, tTol, tMsg, gFactor)
			
			' �e�u���b�N�̃R���g���[����␳
			For I = 0 To iGrpCnt - 1
				hoseiControls(tGrps(I).iCtrCnt, tGrps(I).tCtrs)
			Next 
		End If
	End Sub
	
	' �␳�ΏۃR���g���[���̎擾
	'   I   frm     �t�H�[��
	'   O   iGrpCnt �R���e�i�O���[�v��
	'   O   tGrps() �R���e�i�O���[�v�ʃR���g���[�����
	Private Sub getHoseiControls(ByVal frm As System.Windows.Forms.Form, ByRef iGrpCnt As Short, ByRef tGrps() As TYPE_CTRLGRP)
		Dim J, I, k As Short
		Dim ctr As System.Windows.Forms.Control
		
		' �R���e�i�O���[�v�ʂ̃R���g���[�����擾
		iGrpCnt = 0
		
		For	Each ctr In frm.Controls
            'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            'If (TypeOf ctr Is System.Windows.Forms.ToolStripMenuItem) Or (TypeOf ctr Is System.Windows.Forms.Timer) Or (TypeOf ctr Is System.Windows.Forms.Label) Then
            If (TypeOf ctr Is System.Windows.Forms.ContextMenuStrip) Or (TypeOf ctr Is System.Windows.Forms.Label) Then
                '2019/09/23 CHG END
            Else
                    getGrpControls(ctr, iGrpCnt, tGrps)
			End If
		Next ctr
		
		' �אڂ���R���g���[�����m��
		For I = 0 To iGrpCnt - 1
			relControl(tGrps(I).iCtrCnt, tGrps(I).tCtrs)
		Next 
	End Sub
	
	' �R���e�i�O���[�v�ʂ̃R���g���[�����擾
	'   I   ctr     �R���g���[��
	'   O   iGrpCnt �R���e�i�O���[�v��
	'   O   tGrps() �R���e�i�O���[�v�ʃR���g���[��
	Private Sub getGrpControls(ByVal ctr As System.Windows.Forms.Control, ByRef iGrpCnt As Short, ByRef tGrps() As TYPE_CTRLGRP)
		Dim bOvrFg As Boolean
		Dim I As Short
		'UPGRADE_WARNING: �\���� tCtr �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
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
			
			'UPGRADE_WARNING: �I�u�W�F�N�g tGrps().tCtrs(tGrps().iCtrCnt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: �I�u�W�F�N�g tGrps().tCtrs(tGrps().iCtrCnt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			tGrps(iGrpCnt).tCtrs(tGrps(iGrpCnt).iCtrCnt) = tCtr
			
			tGrps(iGrpCnt).iCtrCnt = tGrps(iGrpCnt).iCtrCnt + 1
			iGrpCnt = iGrpCnt + 1
		End If
	End Sub
	
	' �אڂ���R���g���[�����m��
	'   I   iCtrCnt �R���g���[����
	'   O   tCtrs() �R���g���[��
	Private Sub relControl(ByVal iCtrCnt As Short, ByRef tCtrs() As TYPE_CTRLINFO)
		Dim I, J As Short
		Dim iTwipX, iTwipY As Short
		Dim nMin, nRight, nDown, nMax As Integer
		Dim tRel As TYPE_RELINFO
		
		iTwipX = VB6.TwipsPerPixelX
		iTwipY = VB6.TwipsPerPixelY
		
		' ���אڃR���g���[���̊m��
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
								
								'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs().tLefts(tCtrs().iLeftCnt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								tCtrs(I).tLefts(tCtrs(I).iLeftCnt) = tRel
								tCtrs(I).iLeftCnt = tCtrs(I).iLeftCnt + 1
								
						End Select
					End If
				End If
			Next 
		Next 
		
		' ���אڃR���g���[���̊m��
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
								
								'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs().tDowns(tCtrs().iDownCnt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
	
	' �o�[�R���g���[���̎擾
	'   I   frm     �t�H�[��
	'   O   tTol    �c�[���o�[���
	'   O   tMsg    ���b�Z�[�W�o�[���
	Private Sub getBarControls(ByVal frm As System.Windows.Forms.Form, ByRef tTol As TYPE_BAR, ByRef tMsg As TYPE_BAR)
		Dim obj As Object
		
		For	Each obj In frm.Controls
			'UPGRADE_WARNING: �I�u�W�F�N�g obj.Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case UCase(obj.Name)
				Case "SYSDT"
					Do 
						tTol.ctr = obj
						'UPGRADE_WARNING: �I�u�W�F�N�g obj.Container �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						obj = obj.Container
					Loop While Not (TypeOf obj Is System.Windows.Forms.Form)
					
				Case "TX_MESSAGE"
					Do 
						tMsg.ctr = obj
						'UPGRADE_WARNING: �I�u�W�F�N�g obj.Container �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						obj = obj.Container
					Loop While Not (TypeOf obj Is System.Windows.Forms.Form)
					
			End Select
		Next obj
	End Sub
	
	' �R���g���[���̕␳
	'   I   iCtrCnt �R���g���[����
	'   O   tCtrs() �R���g���[��
	Private Sub hoseiControls(ByVal iCtrCnt As Short, ByRef tCtrs() As TYPE_CTRLINFO)
		Dim I, J As Short
		Dim iTwipX, iTwipY As Short
		Dim nLeft, nTop As Integer
		Dim nRight, nDown As Integer
		'UPGRADE_WARNING: �\���� tCrt �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim tCrt As TYPE_CTRLINFO
		Dim tCrtsL() As TYPE_CTRLINFO
		
		iTwipX = VB6.TwipsPerPixelX
		iTwipY = VB6.TwipsPerPixelY
		
		' ���אڃR���g���[����Left�l��␳
		For I = 0 To iCtrCnt - 2
			For J = I + 1 To iCtrCnt - 1
				If tCtrs(J).nLeft < tCtrs(I).nLeft Then
					'UPGRADE_WARNING: �I�u�W�F�N�g tCrt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					tCrt = tCtrs(I)
					'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					tCtrs(I) = tCtrs(J)
					'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs(J) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					tCtrs(J) = tCrt
				End If
			Next 
		Next 
		
		For I = 0 To iCtrCnt - 1
			ReDim Preserve tCrtsL(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g tCrtsL(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			tCrtsL(I) = tCtrs(I)
			
			nLeft = VB6.PixelsToTwipsX(tCtrs(I).ctr.Left) + VB6.PixelsToTwipsX(tCtrs(I).ctr.Width) - iTwipX
			For J = 0 To tCtrs(I).iLeftCnt - 1
				tCtrs(I).tLefts(J).ctr.Left = VB6.TwipsToPixelsX(nLeft)
			Next 
		Next 
		
		' ���אڃR���g���[����Top�l��Width�l��␳
		For I = 0 To iCtrCnt - 2
			For J = I + 1 To iCtrCnt - 1
				If tCtrs(J).nTop < tCtrs(I).nTop Then
					'UPGRADE_WARNING: �I�u�W�F�N�g tCrt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					tCrt = tCtrs(I)
					'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					tCtrs(I) = tCtrs(J)
					'UPGRADE_WARNING: �I�u�W�F�N�g tCtrs(J) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		' ���אڃR���g���[����Height�l��␳
		For I = 0 To iCtrCnt - 1
			nDown = VB6.PixelsToTwipsY(tCrtsL(I).ctr.Top) + VB6.PixelsToTwipsY(tCrtsL(I).ctr.Height) - iTwipY
			For J = 0 To tCrtsL(I).iLeftCnt - 1
				If tCrtsL(I).tLefts(J).bJstFg Then
					tCrtsL(I).tLefts(J).ctr.Height = VB6.TwipsToPixelsY(nDown - VB6.PixelsToTwipsY(tCrtsL(I).tLefts(J).ctr.Top) + iTwipY)
				End If
			Next 
		Next 
	End Sub
	
	' Width�̏C��
	'   I   nTwip       Twip�l
	'   I   gFactor     �{��
	Private Function calTwip(ByVal nWidth As Integer, ByVal gFactor As Single) As Integer
		calTwip = ((nWidth * gFactor) \ 15) * 15
	End Function
	
	' �w��̃R���g���[�����i�[����Ă���ŏ�ʂ̃R���e�i���擾
	'   I   ctr     �R���g���[��
	Private Function getContainer(ByVal ctr As System.Windows.Forms.Control) As Object
		Dim obj As Object
		
		obj = ctr
		
		'UPGRADE_WARNING: �I�u�W�F�N�g obj.Container �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Do While Not (TypeOf obj.Container Is System.Windows.Forms.Form)
			'UPGRADE_WARNING: �I�u�W�F�N�g obj.Container �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			obj = obj.Container
		Loop 
		
		' �ŏ�ʂ̃R���e�i�R���g���[����������΃t�H�[����Ԃ�
		'UPGRADE_WARNING: �I�u�W�F�N�g obj.Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If obj.Name = ctr.Name Then
			'UPGRADE_WARNING: �I�u�W�F�N�g obj.Container �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			obj = obj.Container
		End If
		
		getContainer = obj
	End Function
	
	' �c�[���o�[�ƃ��b�Z�[�W�o�[�̕␳
	'   I   frm     �t�H�[��
	'   I   tTol    �c�[���o�[���
	'   I   tMsg    ���b�Z�[�W�o�[���
	'   I   gFactor �{��
	Private Sub hoseiBar(ByVal frm As System.Windows.Forms.Form, ByRef tTol As TYPE_BAR, ByRef tMsg As TYPE_BAR, ByVal gFactor As Single)
		On Error Resume Next
		Dim I As Short
		Dim nTop As Integer
		
		' �c�[���o�[�Ɗi�[�R���g���[���̕␳
		tTol.ctr.Left = VB6.TwipsToPixelsX(-45)
		tTol.ctr.Top = 0
		
		For I = 0 To tTol.iBarCnt - 1
			nTop = VB6.PixelsToTwipsY(tTol.ctr.Height) * 0.5 - VB6.PixelsToTwipsY(tTol.ctrBars(I).Height) * 0.5
			tTol.ctrBars(I).Top = VB6.TwipsToPixelsY(nTop)
		Next 
		
		' ���b�Z�[�W�o�[�Ɗi�[�R���g���[���̕␳
		tMsg.ctr.Left = VB6.TwipsToPixelsX(-45)
		tMsg.ctr.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frm.ClientRectangle.Height) - VB6.PixelsToTwipsY(tMsg.ctr.Height) + VB6.TwipsPerPixelY * 4)
		
		For I = 0 To tMsg.iBarCnt - 1
			tMsg.ctrBars(I).Top = VB6.TwipsToPixelsY(calTwip(VB6.PixelsToTwipsY(tMsg.ctrBars(I).Top), gFactor))
		Next 
	End Sub
	
	'
	Function Get_DbSchema(ByRef vUser As String) As String
		'�w�肵��USR�̃X�L�[�}���擾����
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
		'UPGRADE_WARNING: �\���� IID_IDispatch �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim IID_IDispatch As GUID
		
		With IID_IDispatch
			.Data1 = &H20400
			.Data4(0) = &HC0s
			.Data4(7) = &H46s
		End With
		
		With Pic
			.Size = Len(Pic) ' Length of structure
            'UPGRADE_ISSUE: �萔 vbPicTypeBitmap �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            '2019/09/23 DEL START
            '.Type = vbPicTypeBitmap ' Type of Picture (bitmap)
            '2019/09/23 DEL END
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
		'UPGRADE_WARNING: �\���� LogPal �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
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

        'UPGRADE_ISSUE: �萔 vbSrcCopy �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'r = BitBlt(hDCMemory, 0, 0, WidthSrc, HeightSrc, hDCSrc, LeftSrc, TopSrc, vbSrcCopy)
        '2019/09/23 DEL END
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
        'UPGRADE_ISSUE: �萔 vbPixels �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbTwips �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Form ���\�b�h frmSrc.ScaleY �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: Form ���\�b�h frmSrc.ScaleX �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '2019/09/23 DEL START
        'CaptureForm = CaptureWindow(frmSrc.Handle.ToInt32, False, 0, 0, frmSrc.ScaleX(VB6.PixelsToTwipsX(frmSrc.Width), vbTwips, vbPixels), frmSrc.ScaleY(VB6.PixelsToTwipsY(frmSrc.Height), vbTwips, vbPixels))
        '2019/09/23 DEL END
    End Function
	'�n�[�h�R�s�[
	''''Public Sub Exec_Hardcopy(pform As Form)
	''''    gSelectedDeviceName = ""
	''''    If Printers.count = 0 Then
	''''        Call MsgBox("���̂o�b�ɂ̓v�����^���C���X�g�[������Ă��Ȃ�����" & vbCr & "��ʃn�[�h�R�s�[���ł��܂���B" & vbCr & "�v�����^���C���X�g�[�����Ă���ēx���s���ĉ������B", vbExclamation Or vbOKOnly, App.Title)
	''''        gSelectedDeviceName = False
	''''        Exit Sub
	''''    End If
	''''    Load WLS_HCP
	''''    WLS_HCP.Show 1
	''''    DoEvents
	''''    If gSelectedDeviceName <> "" Then
	''''        'Form �̃X�N���[���V���b�g��
	''''        'Picture1 �� Picture �v���p�e�B�ɑ�����܂��B
	''''        Set WLS_HCP.Picture1.Picture = CaptureForm(pform)
	''''        '�w�肵���v�����^��Picture1��������܂��B
	''''        APIPrint (gSelectedDeviceName)
	''''    End If
	''''    Unload WLS_HCP
	''''End Sub
	'
	' �w�肵���f�B�o�C�X�i�v�����^�j����A�c�����l�������\���̂��擾���A���̐ݒ���s�Ȃ��B
	''''Sub APIPrint(Device$)
	''''    Dim dm As sDEVMODE
	''''    Dim hPrinter&, di&
	''''    Dim prhdc&
	''''    Dim dinfo As DOCINFO
	''''    Dim pdefs As PRINTER_DEFAULTS
	''''    Dim bufsize&
	''''    Dim dmInBuf() As Byte
	''''    Dim dmOutBuf() As Byte
	''''
	''''    pdefs.PDATATYPE = vbNullString
	''''    pdefs.PDEVMODE = 0
	''''    pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
	''''
	''''    di& = sOpenPrinter(Device, hPrinter, pdefs)
	''''    If di = 0 Then Exit Sub
	''''    bufsize = snDocumentProperties(0, hPrinter, Device, 0, 0, 0)
	''''    ReDim dmInBuf(bufsize - 1)
	''''    ReDim dmOutBuf(bufsize - 1)
	''''    di = sDocumentProperties(0, hPrinter, Device, dmOutBuf(0), dmInBuf(0), DM_OUT_BUFFER)
	''''
	''''    Select Case di
	''''    Case IDOK
	''''    Case IDCANCEL
	''''        GoTo PrintEnd2
	''''    Case Else
	''''        MsgBox "�v�����^�̏�񂪎擾�ł��܂���B", 0, "�n�[�h�R�s�["
	''''        GoTo PrintEnd2
	''''    End Select
	''''
	''''    Call memcpy(dm, dmOutBuf(0), Len(dm))
	''''    dm.dmOrientation = gSelectedOrientation
	''''    dm.dmPaperSize = gSelectedPapeSize
	''''    dm.dmColor = DMCOLOR_COLOR
	''''    Call memcpy(dmOutBuf(0), dm, Len(dm))
	''''
	''''    prhdc = CreateDC("winspool", Device, vbNullString, dmOutBuf(0))
	''''    If prhdc = 0 Then GoTo PrintEnd2
	''''
	''''    dinfo.cbSize = Len(dinfo)
	''''    dinfo.lpszDocName = "���ID�F" & SSS_PrgId
	''''    dinfo.lpszOutput = vbNullString
	''''
	''''    di = StartDoc(prhdc, dinfo)
	''''    di = StartPage(prhdc)
	''''    PrintBitmap prhdc
	''''    di = EndPage(prhdc)
	''''    If di >= 0 Then di = EndDocAPI(prhdc)
	''''
	''''PrintEnd1:
	''''    DeleteDC (prhdc)
	''''
	''''PrintEnd2:
	''''    ClosePrinter hPrinter
	''''
	''''End Sub
	'
	'�t�H�[���̃X�N���[���V���b�g���������
	''''Sub PrintBitmap(hdc&)
	''''    Dim bi As BITMAPINFO
	''''    Dim dctemp&, dctemp2&
	''''    Dim Msg$
	''''    Dim bufsize&
	''''    Dim bm As BITMAP
	''''    Dim ghnd&
	''''    Dim gptr&
	''''    Dim xpix&, ypix&
	''''    Dim doscale As Double
	''''    Dim uy&, ux&
	''''    Dim di&
	''''
	''''    dctemp = CreateCompatibleDC(WLS_HCP.Picture1.hdc)
	''''    di = GetObjectAPI(WLS_HCP.Picture1.Picture, Len(bm), bm)
	''''    With bi.bmiHeader
	''''        .biSize = Len(bi.bmiHeader)
	''''        .biWidth = bm.bmWidth
	''''        .biHeight = bm.bmHeight
	''''        .biPlanes = 1
	''''        .biBitCount = 24
	''''        .biCompression = BI_RGB
	''''        bufsize = .biWidth
	''''        bufsize = bufsize * 3
	''''        bufsize = ((bufsize + 3) / 4) * 4
	''''        bufsize = bufsize * .biHeight
	''''    End With
	''''    ghnd = GlobalAlloc(GMEM_MOVEABLE, bufsize)
	''''    gptr = GlobalLock(ghnd)
	''''    di = GetDIBits(dctemp, WLS_HCP.Picture1.Picture, 0, bm.bmHeight, ByVal gptr, bi, DIB_RGB_COLORS)
	''''
	''''    xpix = GetDeviceCaps(hdc, HORZRES) - 200    '�]��������
	''''    ypix = GetDeviceCaps(hdc, VERTRES) - 200
	''''    doscale = xpix / bm.bmWidth
	''''    If ypix / bm.bmHeight < doscale Then
	''''        doscale = ypix / bm.bmHeight
	''''    End If
	''''    If doscale > 6 Then
	''''        doscale = 6             '����T�C�Y�@�i1024*768 �� A4�� �ōœK?�j
	''''    End If
	''''    ux = Int(bm.bmWidth * doscale)
	''''    uy = Int(bm.bmHeight * doscale)
	''''    di = StretchDIBits(hdc, 100, 100, ux, uy, 0, 0, bm.bmWidth, bm.bmHeight, ByVal gptr, bi, DIB_RGB_COLORS, vbSrcCopy)
	''''
	''''    di = GlobalUnlock(ghnd)
	''''    di = GlobalFree(ghnd)
	''''    di = DeleteDC(dctemp)
	''''End Sub
	''''
	'�n�[�h�R�s�[�C�x���g�B�d�����ɂ��ďo�����B
	''''Function SSSMAIN_Hardcopy_Getevent() As Boolean
	''''    Call Exec_Hardcopy(FR_SSSMAIN)
	''''    SSSMAIN_Hardcopy_Getevent = False
	''''End Function
	'#End(2003.4.22)
	'#End(2003.10.28)
End Module