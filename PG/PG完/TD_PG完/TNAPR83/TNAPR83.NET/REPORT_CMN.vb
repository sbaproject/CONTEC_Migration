Option Strict Off
Option Explicit On
Module REPORT_CMN
	'
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@����
	'*  �v���O�������@�@�F�@����p���W���[��
	'*  �v���O�����h�c�@�F  REPORT_BAS
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.31
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	'ODBC API���g�p���邽�߂̐錾
	Declare Function SQLDataSources Lib "ODBC32.DLL" (ByVal henv As Integer, ByVal fDirection As Short, ByVal szDSN As String, ByVal cbDSNMax As Short, ByRef pcbDSN As Short, ByVal szDescription As String, ByVal cbDescriptionMax As Short, ByRef pcbDescription As Short) As Short
	Declare Function SQLAllocEnv Lib "ODBC32.DLL" (ByRef env As Integer) As Short
	Public Const SQL_SUCCESS As Integer = 0
	Public Const SQL_FETCH_NEXT As Integer = 1
	
	Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal fRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
	Public Const ODBC_ADD_DSN As Short = 1 '�f�[�^ �\�[�X�̒ǉ�
	Public Const ODBC_CONFIG_DSN As Short = 2 '�f�[�^ �\�[�X�̕ҏW
	Public Const ODBC_REMOVE_DSN As Short = 3 '�f�[�^ �\�[�X�̍폜
	'
	Public Const SSS_PRINTER As Short = 1 '�v�����^�[�o��
	Public Const SSS_VIEW As Short = 2 '�E�C���h�E�o��
	Public Const SSS_FILE As Short = 3 '�t�@�C���o��
	
	Public SSS_CRWOPATH As String '�t�@�C���o�͎��̏o�͐�p�X
	Public SSS_Lconfig As String '"USR":�N���X�^�����|�[�g�̃��[�U�[��`��D�悷��
	
	Public SSS_OUTKB As Short '���s���Ɉȉ��̂����ꂩ���ݒ肳���
	'    SSS_PRINTER, SSS_VIEW, SSS_FILE
	'������, �G���[������������, ���s���~������ 0 ��Ԃ�
	
	Public SSS_Makkb As Short '�o�͏����敪
	
	Public SSS_ExportFileName As String 'Exporţ�كt�@�C�����B�f�t�H���g�̓v���O�����h�c
	Public SSS_ExportFileEXT As String 'Exporţ�ق̊g���q�B�f�t�H���g��"RPT"
	Public SSS_ExportSep As String '������؂蕶���i������؂�t�H�[�}�b�g�̏ꍇ�̂ݗL���ŁA����ȊO�� "" �Ŏw��j
	Public SSS_ExportQuat As String '���p���i������؂�t�H�[�}�b�g�̏ꍇ�̂ݗL���ŁA����ȊO�� "" �Ŏw��j
	'
	Public SSS_Hide_Prnbutton As Boolean '�v���r���[��ʂŁA����{�^�����\��(True)�^�\��(False)  �f�t�H���g���\��
	Public SSS_Hide_Expbutton As Boolean '�v���r���[��ʂ���G�N�X�|�[�g�s��(True)�^��(False)      �f�t�H���g����
	Public SSS_Hide_Prnset As Boolean '�v���r���[��ʂŁA�v�����^�̐ݒ�s��(True)�^��(False)    �f�t�H���g����
	Public SSS_ShowProgress As Boolean '�o�͒��i���_�C�A���O �{�b�N�X�\��(True)�^��\��(False)   �f�t�H���g����\��
	Public SSS_Copies As Short '�������
	Public SSS_StartPageNo As Short '�ŏ��̃y�[�W�ԍ�
	Public SSS_StopPageNo As Short '�ŏI�̃y�[�W�ԍ�
	Public SSS_Collation As Short '�����y�[�W�̒��[�ŁA�����̃R�s�[������̏ꍇ�A�K���w�肷��
	'1 = �y�[�W�o�͏��� 1,2,3,1,2,3,1,2,3,....
	'2 = �y�[�W�o�͏��� 1,1,1,2,2,2,3,3,3,....
	
	Public SSS_Message As String '"�Y���f�[�^����"�ȊO�̃��b�Z�[�W��\������
	
	Public SSS_DefPaperSize As Short '���[���̃f�t�H�[���g�p���T�C�Y
	Public SSS_DefPaperSizeNm As String '�p���T�C�Y�̕\�����A�Ⴆ�� "A3"
	Public SSS_DefOrient As Short '���[���̃f�t�H�[���g�󎚌���
	Public SSS_DefOrientNm As String '���[���̃f�t�H�[���g�󎚌����̕\�����A"�c"����"��"
	'UPGRADE_WARNING: �\���� gSelDM �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public gSelDM As DEVMODE '�f�t�H�[���g�󎚐ݒ�p�\����
	
	Public SSS_DYNASQL As Boolean 'PR2�n���[�Ń_�C�i�~�b�N��SQL���g�p�����Ȃ���
	
	'Constants using to calculate structure size constants
	' --------------------------------------------------------------------
	Public Const PE_BYTE_LEN As Short = 1
	Public Const PE_WORD_LEN As Short = 2
	Public Const PE_LONG_LEN As Short = 4
	Public Const PE_DOUBLE_LEN As Short = 8
	Public Const PE_UNCHANGED As Short = -1
	Public Const PE_UNCHANGED_COLOR As Short = -2
	
	Public Const PE_DLLVERSION As Short = &H400s
	Public Const PE_ENGINEVERSION As Short = &H400s
	
	Public Const PE_UNCOLLATED As Short = 0
	Public Const PE_COLLATED As Short = 1
	Public Const PE_DEFAULTCOLLATION As Short = 2
	
	' Open and close print engine
	' ---------------------------
	Declare Function PEOpenEngine Lib "crpe32.dll" () As Short
	Declare Sub PECloseEngine Lib "crpe32.dll" ()
	
	' Get version info
	' ----------------
	Public Const PE_GV_DLL As Short = 100 'values for version parameter of PEGetVersion
	Public Const PE_GV_ENGINE As Short = 200
	
	Declare Function PEGetVersion Lib "crpe32.dll" (ByVal Version As Short) As Short
	
	' Open and close print job (i.e. report)
	' --------------------------------------
	Declare Function PEOpenPrintJob Lib "crpe32.dll" (ByVal RptName As String) As Short
	Declare Function PEClosePrintJob Lib "crpe32.dll" (ByVal printJob As Short) As Short
	
	' Start and cancel print job (i.e. print the report, usually after changing report)
	' ---------------------------------------------------------------------------------
	Declare Function PEStartPrintJob Lib "crpe32.dll" (ByVal printJob As Short, ByVal WaitOrNot As Short) As Short
	Declare Sub PECancelPrintJob Lib "crpe32.dll" (ByVal printJob As Short)
	Declare Function PEGetWindowHandle Lib "crpe32.dll" (ByVal printJob As Short) As Integer
	Declare Sub PECloseWindow Lib "crpe32.dll" (ByVal printJob As Short)
	
	' Print job status
	' ----------------
	Public Const PE_SIZEOF_JOB_INFO As Integer = 10 * PE_WORD_LEN + 4
	
	Structure T_PEJobInfo
		Dim StructSize As Short 'initialize to # of bytes in PEJobInfo
		Dim NumRecordsRead As Integer
		Dim NumRecordsSelected As Integer
		Dim NumRecordsPrinted As Integer
		Dim DisplayPageN As Short
		Dim LatestPageN As Short
		Dim StartPageN As Short
		Dim PrintEnded As Integer
	End Structure
	
	Structure SplitPEJobInfo
		Dim StructSize As Short 'initialize to PE_SIZEOF_JOB_INFO
		Dim NumRecordsRead1 As Short
		Dim NumRecordsRead2 As Short
		Dim NumRecordsSelected1 As Short
		Dim NumRecordsSelected2 As Short
		Dim NumRecordsPrinted1 As Short
		Dim NumRecordsPrinted2 As Short
		Dim DisplayPageN As Short
		Dim LatestPageN As Short
		Dim StartPageN As Short
		Dim PrintEnded As Integer
	End Structure
	
	'UPGRADE_WARNING: �\���� SplitPEJobInfo �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function RealPEGetJobStatus Lib "crpe32.dll"  Alias "PEGetJobStatus"(ByVal printJob As Short, ByRef JobInfo As SplitPEJobInfo) As Short
	
	' Print job error codes and messages
	' ----------------------------------
	Declare Function PEGetErrorCode Lib "crpe32.dll" (ByVal printJob As Short) As Short
	Declare Function PEGetErrorText Lib "crpe32.dll" (ByVal printJob As Short, ByRef TextHandle As Integer, ByRef TextLength As Short) As Short
	Declare Function PEGetHandleString Lib "crpe32.dll" (ByVal TextHandle As Integer, ByVal Buffer As String, ByVal BufferLength As Short) As Short
	
	' Controlling print to printer
	' ----------------------------
	Declare Function PEOutputToPrinter Lib "crpe32.dll" (ByVal printJob As Short, ByVal nCopies As Short) As Short
	Declare Function PEOutputToWindow Lib "crpe32.dll" (ByVal printJob As Short, ByVal Title As String, ByVal Lft As Integer, ByVal Top As Integer, ByVal Wdth As Integer, ByVal Height As Integer, ByVal style As Integer, ByVal PWindow As Integer) As Short
	
	Public Const PE_DLL_NAME_LEN As Short = 64
	Public Const PE_FULL_NAME_LEN As Short = 256
	Public Const PE_SIZEOF_TABLE_TYPE As Short = 324 '# bytes in PETableType
	
	Structure T_PEExportOptions
		Dim StructSize As Short 'initialize to # bytes in PEExportOptions
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_DLL_NAME_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_DLL_NAME_LEN)> Public FormatDLLName() As Char
		Dim FormatType1 As Short
		Dim FormatType2 As Short
		Dim FormatOptions1 As Short
		Dim FormatOptions2 As Short
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_DLL_NAME_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_DLL_NAME_LEN)> Public DestinationDLLName() As Char
		Dim DestinationType1 As Short
		Dim DestinationType2 As Short
		Dim DestinationOptions1 As Short
		Dim DestinationOptions2 As Short
		' following are set by PEGetExportOptions,
		' and ignored by PEGetExportOptions
		Dim NFormatOptionsBytes As Short
		Dim NDestinationOptionsBytes As Short
	End Structure
	Public Const PE_SIZEOF_EXPORT_OPTIONS As Integer = 11 * PE_WORD_LEN + 2 * PE_DLL_NAME_LEN
	
	'UPGRADE_WARNING: �\���� T_PEExportOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetExportOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef ExportOptions As T_PEExportOptions) As Short
	'UPGRADE_WARNING: �\���� T_PEExportOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEExportTo Lib "crpe32.dll" (ByVal printJob As Short, ByRef ExportOptions As T_PEExportOptions) As Short
	Declare Function PEHasSavedData Lib "crpe32.dll" (ByVal printJob As Short, ByRef HasSavedData As Integer) As Short
	Declare Function PEDiscardSavedData Lib "crpe32.dll" (ByVal printJob As Short) As Short

    ' Changing printer selection
    ' --------------------------
    '#Start(2003.11.16) CR9 Unicode �Ή�
    'Declare Function PESelectPrinter Lib "crpe32.dll" (ByVal printJob%, ByVal PrinterDriver$, ByVal PrinterName$, ByVal PortName$, ByVal DEVMODE As Long) As Integer
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '20190627 CHG START
    'Declare Function PESelectPrinter Lib "crpe32.dll" Alias "PESelectPrinterW" (ByVal printJob As Short, ByRef PriterDriver As Any, ByRef PrinterName As Any, ByRef PortName As Any, ByVal DEVMODE As Integer) As Short
    Declare Function PESelectPrinter Lib "crpe32.dll" Alias "PESelectPrinterW" (ByVal printJob As Short, ByRef PriterDriver As Integer, ByRef PrinterName As Integer, ByRef PortName As Integer, ByVal DEVMODE As Integer) As Short
    '20190627 CHG END
    '#End(2003.11.16)
    Declare Function PEGetSelectedPrinter Lib "crpe32.dll" (ByVal printJob As Short, ByRef DriverHandle As Integer, ByRef DriverLength As Short, ByRef PrinterHandle As Integer, ByRef PrinterLength As Short, ByRef PortHandle As Integer, ByRef PortLength As Short, ByVal DEVMODE As Integer) As Short
	
	' Setting section height and format
	' ---------------------------------
	Declare Function reportExportX Lib "CrwTDLL.DLL" (ByVal printJob As Integer, ByVal exportto As String, ByVal toFormat As Integer, ByVal toTarget As Integer, ByVal sep As String, ByVal quat As String) As Integer
	
	' values for SectionCode parameter
	' ---------------------------------
	Public Const PE_ALLSECTIONS As Short = 0
	Public Const PE_TITLESECTION As Short = 1000
	Public Const PE_HEADERSECTION As Short = 2000
	Public Const PE_GROUPHEADER As Short = 3000 'outer group header is 3000, next is 3001, etc.
	Public Const PE_DETAILSECTION As Short = 4000
	Public Const PE_GROUPFOOTER As Short = 5000 'outer group footer is 5000, next is 5001, etc.
	Public Const PE_FOOTERSECTION As Short = 7000
	Public Const PE_SUMMARYSECTION As Short = 8000
	Public Const PE_GRANDTOTALSECTION As Short = PE_SUMMARYSECTION
	'
	Structure T_PESectionOptions
		Dim StructSize As Short 'initialize to # bytes in PESectionOptions
		' use 0 to turn off, 1 to turn on and -1 to preserve each attribute
		Dim Visible As Short
		Dim NewPageBefore As Short
		Dim NewPageAfter As Short
		Dim KeepTogether As Short
		Dim SuppressBlankLines As Short
		Dim ResetPageNAfter As Short
		Dim PrintAtBottomOfPage As Short
		Dim backgroundColor As Integer 'Use PE_UNCHANGED_COLOR to preserve the existing color.
		Dim underlaySection As Short
		Dim showArea As Short
		Dim freeFormPlacement As Short
		Dim reserveMinimumPageFooter As Short 'BOOLEAN or PE_UNCHANGED;
	End Structure
	
	'UPGRADE_WARNING: �\���� T_PESectionOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetSectionFormat Lib "crpe32.dll" (ByVal printJob As Short, ByVal SectionCode As Short, ByRef Options As T_PESectionOptions) As Short
	'UPGRADE_WARNING: �\���� T_PESectionOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetSectionFormat Lib "crpe32.dll" (ByVal printJob As Short, ByVal SectionCode As Short, ByRef Options As T_PESectionOptions) As Short
	
	'##�e�[�u�����P�[�V�������
	'--------------------------
	Public Const PE_TABLE_LOCATION_LEN As Short = 256
	Public Const PE_CONNECTION_BUFFER_LEN As Short = 512
	Public Const PE_SIZEOF_TABLE_LOCATION As Short = 1026 '# bytes in PETableLocation
	Structure T_PETableLocation
		' initialize to # bytes in PETableLocation
		Dim StructSize As Short
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_TABLE_LOCATION_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_TABLE_LOCATION_LEN)> Public Location() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_TABLE_LOCATION_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_TABLE_LOCATION_LEN)> Public SubLocation() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_CONNECTION_BUFFER_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_CONNECTION_BUFFER_LEN)> Public ConnectBuffer() As Char 'Connection Info for attached tables
	End Structure
	
	Declare Function PEGetNTables Lib "crpe32.dll" (ByVal printJob As Short) As Short
	'UPGRADE_WARNING: �\���� T_PETableLocation �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetNthTableLocation Lib "crpe32.dll" (ByVal printJob As Short, ByVal TableN As Short, ByRef Location As T_PETableLocation) As Short
	'UPGRADE_WARNING: �\���� T_PETableLocation �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetNthTableLocation Lib "crpe32.dll" (ByVal printJob As Short, ByVal TableN As Short, ByRef Location As T_PETableLocation) As Short
	
	'
	Structure T_FormatOptions
		Dim StructSize As Short
		Dim useReportNumberFormat As Short
		Dim UseReportDateFormat As Short
	End Structure
	Public FormatOptions As T_FormatOptions
	'
	Structure T_UXDDiskOptions
		Dim StructSize As Short
		Dim fileName As String
	End Structure
	Public UXDDiskOptions As T_UXDDiskOptions
	'
	'##Window Options
	Structure T_PEWindowOptions
		Dim StructSize As Short 'initialize to PE_SIZEOF_WINDOW_OPTIONS
		Dim hasGroupTree As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim canDrillDown As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasNavigationControls As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasCancelButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasPrintButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasExportButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasZoomControl As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasCloseButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasProgressControls As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasSearchButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasPrintSetupButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim hasRefreshButton As Short '�\��(1)�A��\��(0)�A�ύX�Ȃ�(PE_UNCHANGED)
		Dim showToolbarTips As Short 'BOOL value, except use PE_UNCHANGED for no change
		'default is TRUE (*Show* tooltips on toolbar)
		Dim showDocumentTips As Short 'BOOL value, except use PE_UNCHANGED for no change
		'default is FALSE (*Hide* tooltips on document)
		Dim hasLaunchButton As Short 'Launch Seagate Analysis button on toolbar.
		'BOOL value, except use PE_UNCHANGED for no change
		'default is FALSE
	End Structure
	Public Const PE_SIZEOF_WINDOW_OPTIONS As Short = (16 * PE_WORD_LEN)
	'UPGRADE_WARNING: �\���� T_PEWindowOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetWindowOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef Options As T_PEWindowOptions) As Short
	'UPGRADE_WARNING: �\���� T_PEWindowOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetWindowOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef Options As T_PEWindowOptions) As Short
	
	'##Report Options
	Structure T_PEReportOptions
		Dim StructSize As Short
		Dim saveDataWithReport As Short
		Dim saveSummariesWithReport As Short
		Dim useIndexForSpeed As Short
		Dim translateDOSStrings As Short
		Dim translateDosMemos As Short
		Dim convertDateTimeType As Short
		Dim convertNullFieldToDefault As Short
		Dim morePrintEngineErrorMessages As Short
		Dim caseInsensitiveSQLData As Short
		Dim verifyOnEveryPrint As Short
		Dim zoomMode As Short
		Dim hasGroupTree As Short
		Dim dontGenerateDataForHiddenObjects As Short
		Dim performGroupingOnServer As Short
		Dim doAsyncQuery As Short
		Dim promptMode As Short
		Dim SelectDistinctRecords As Short
	End Structure
	Public Const PE_SIZEOF_REPORT_OPTIONS As Short = 18 * PE_WORD_LEN
	Public Const PE_ZOOM_FULL_SIZE As Short = 0 '100%
	Public Const PE_ZOOM_SIZE_FIT_ONE_SIDE As Short = 1 '�Ј���ɍ��킹
	Public Const PE_ZOOM_SIZE_FIT_BOTH_SIDES As Short = 2 '��ʗ����ɍ��킹
	
	'UPGRADE_WARNING: �\���� T_PEReportOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetReportOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef reportOptions As T_PEReportOptions) As Short
	'UPGRADE_WARNING: �\���� T_PEReportOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetReportOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef reportOptions As T_PEReportOptions) As Short
	'
	'##Print Options
	Public Const PE_MAXPAGEN As Integer = 65535
	Public Const PE_FILE_PATH_LEN As Short = 512
	Structure T_PEPrintOptions
		Dim StructSize As Short 'initialize to # bytes in PEPrintOptions
		'page and copy numbers are 1-origin
		'use 0 to preserve the existing settings
		Dim StartPageN As Short
		Dim stopPageN As Short
		Dim nReportCopies As Short
		Dim collation As Short
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_FILE_PATH_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_FILE_PATH_LEN)> Public outputFileName() As Char
	End Structure
	Public Const PE_SIZEOF_PRINT_OPTIONS As Integer = 5 * PE_WORD_LEN + PE_FILE_PATH_LEN
	'UPGRADE_WARNING: �\���� T_PEPrintOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetPrintOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef Options As T_PEPrintOptions) As Short
	'UPGRADE_WARNING: �\���� T_PEPrintOptions �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetPrintOptions Lib "crpe32.dll" (ByVal printJob As Short, ByRef Options As T_PEPrintOptions) As Short
	
	'##
	Public Const PE_JOBNOTSTARTED As Short = 1
	Public Const PE_JOBINPROGRESS As Short = 2
	Public Const PE_JOBCOMPLETED As Short = 3
	Public Const PE_JOBFAILED As Short = 4
	Public Const PE_JOBCANCELLED As Short = 5
	Public Const PE_JOBHALTED As Short = 6 'too many records or too much time
	
	Public Const PE_ERR_NOERROR As Short = 0
	Public Const PE_ERR_USERCANCELLED As Short = 545
	
	Public Const WS_MINIMIZE As Integer = 536870912
	Public Const WS_VISIBLE As Integer = 268435456
	Public Const WS_DISABLED As Integer = 134217728
	Public Const WS_CLIPSIBLINGS As Integer = 67108864
	Public Const WS_CLIPCHILDREN As Integer = 33554432
	Public Const WS_MAXIMIZE As Integer = 16777216
	Public Const WS_CAPTION As Integer = 12582912
	Public Const WS_BORDER As Integer = 8388608
	Public Const WS_DLGFRAME As Integer = 4194304
	Public Const WS_VSCROLL As Integer = 2097152
	Public Const WS_HSCROLL As Integer = 1048576
	Public Const WS_SYSMENU As Integer = 524288
	Public Const WS_THICKFRAME As Integer = 262144
	Public Const WS_MINIMIZEBOX As Integer = 131072
	Public Const WS_MAXIMIZEBOX As Integer = 65536
	Public Const CW_USEDEFAULT As Integer = -32768
	
	Public Const UXFCrystalReportType As Integer = 0
	Public Const UXFCommaSeparatedType As Integer = 0
	Public Const UXFTabSeparatedType As Integer = 1
	Public Const UXFTextType As Integer = 0
	Public Const UXFTabbedTextType As Integer = 1
	Public Const UXFXls4Type As Integer = 2
	Public Const UXFXls5Type As Integer = 3
	Public Const UXDDiskType As Integer = 0
	
	'##�G�N�X�|�[�g�E�t�@�C���̃^�C�v
	'--------------------------------
	Public Const CRW_CommaSeparatedType As Short = 0 '�b�r�u
	Public Const CRW_Xls5Type As Short = 1 'Excel v5.0
	Public Const CRW_CrystalReportType As Short = 2 '�N���X�^�����|�[�g
	Public Const CRW_RichTextType As Short = 9 '���b�`�e�L�X�g
	Public Const CRW_TabSeparatedType As Short = 10 '�^�u��؂�
	Public Const CRW_CharSeparatedType As Short = 11 '������؂�
	Public Const CRW_TextType As Short = 12 '�e�L�X�g
	Public Const CRW_TabbedTextType As Short = 14 '�^�u��؂�e�L�X�g
	Public Const CRW_Xls4Type As Short = 20 'Excel v4.0
	
	Public Const CRW_Visible As Short = -1 '�\��
	Public Const CRW_Hide As Short = 0 '��\��
	
	Public HCRW As Short '�ؽ����߰ĥ����������
	
	'##���O�I�����
	'--------------
	Public Const PE_SERVERNAME_LEN As Short = 128
	Public Const PE_DATABASENAME_LEN As Short = 128
	Public Const PE_USERID_LEN As Short = 128
	Public Const PE_PASSWORD_LEN As Short = 128
	Public Const PE_SIZEOF_LOGON_INFO As Short = 514 '# bytes in PELogOnInfo
	
	Structure T_PELogOnInfo
		'initialize to # bytes in PELogOnInfo
		Dim StructSize As Short
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_SERVERNAME_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_SERVERNAME_LEN)> Public ServerName() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_DATABASENAME_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_DATABASENAME_LEN)> Public DatabaseName() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_USERID_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_USERID_LEN)> Public UserID() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(PE_PASSWORD_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=PE_PASSWORD_LEN)> Public Password() As Char
	End Structure
	Public LogOnInfo As T_PELogOnInfo
	
	'UPGRADE_WARNING: �\���� T_PELogOnInfo �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PEGetNthTableLogOnInfo Lib "crpe32.dll" (ByVal printJob As Short, ByVal TableN As Short, ByRef LogOnInfo As T_PELogOnInfo) As Short
	'UPGRADE_WARNING: �\���� T_PELogOnInfo �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Declare Function PESetNthTableLogOnInfo Lib "crpe32.dll" (ByVal printJob As Short, ByVal TableN As Short, ByRef LogOnInfo As T_PELogOnInfo, ByVal Propagate As Short) As Short
	Declare Function PESetSelectionFormula Lib "crpe32.dll" (ByVal printJob As Short, ByVal formulaString As String) As Short
	
	'##�v�����^�[�ݒ�Ɋ֘A����
	'--------------------------
	Declare Function GetProfileString Lib "kernel32"  Alias "GetProfileStringA"(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer) As Integer
    '#Start(2003.11.16) CR9 Unicode �Ή�
    'Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, pDefault As PRINTER_DEFAULTS) As Long
    'UPGRADE_WARNING: �\���� PRINTER_DEFAULTS �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '20190627 CHG START
    'Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterW" (ByRef pPrinterName As Any, ByRef phPrinter As Integer, ByRef pDefault As PRINTER_DEFAULTS) As Integer
    Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterW" (ByRef pPrinterName As Integer, ByRef phPrinter As Integer, ByRef pDefault As PRINTER_DEFAULTS) As Integer
    '20190627 CHG END
    '#End(2003.11.16)
    Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Integer) As Integer
    '#Start(2003.11.16) CR9 Unicode �Ή�
    'Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, ByVal pDeviceName As String, ByVal pDevModeOutput As Long, ByVal pDevModeInput As Long, ByVal fmode As Long) As Long
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '20190627 CHG START
    'Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesW" (ByVal hwnd As Integer, ByVal hPrinter As Integer, ByRef pDeviceName As Any, ByVal pDevModeOutput As Integer, ByVal pDevModeInput As Integer, ByVal fmode As Integer) As Integer
    Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesW" (ByVal hwnd As Integer, ByVal hPrinter As Integer, ByRef pDeviceNameAs As Integer, ByVal pDevModeOutput As Integer, ByVal pDevModeInput As Integer, ByVal fmode As Integer) As Integer
    '20190627 CHG END
    '#End(2003.11.16)
    Declare Function DeviceCapabilities Lib "winspool.drv"  Alias "DeviceCapabilitiesA"(ByVal lpDeviceName As String, ByVal lpPort As String, ByVal iIndex As Integer, ByVal lpOutput As String, ByVal lpDevMode As Integer) As Integer
	Declare Function DeviceCapabilitiesNo Lib "winspool.drv"  Alias "DeviceCapabilitiesA"(ByVal lpDeviceName As String, ByVal lpPort As String, ByVal iIndex As Integer, ByVal lpOutput As Integer, ByVal lpDevMode As Integer) As Integer
	Declare Function agGetStringFromLPSTR Lib "SssAPI.dll" (ByVal src As String) As String
    'UPGRADE_NOTE: object �� object_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '20190627 CHG START
    'Declare Function agGetAddressForObject Lib "SssAPI.dll" (ByRef object_Renamed As Any) As Integer
    Declare Function agGetAddressForObject Lib "SssAPI.dll" (ByRef object_Renamed As Integer) As Integer
    '20190627 CHG END
    Declare Function agGetAddressForInteger Lib "SssAPI.dll"  Alias "agGetAddressForObject"(ByRef intnum As Short) As Integer
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
    '20190627 CHG START
    'Declare Sub agCopyData Lib "SssAPI.dll" (ByRef Source As Any, ByRef dest As Any, ByVal nCount As Integer)
    Declare Sub agCopyData Lib "SssAPI.dll" (ByRef Source As Object, ByRef dest As Object, ByVal nCount As Integer)
    '20190627 CHG END

    '## ������i���_�C�A���O �{�b�N�X�\���^��\����
    Declare Function PEEnableProgressDialog Lib "crpe32.dll" (ByVal printJob As Short, ByVal enable As Short) As Short
	
	'  paper selections
	Public Const DMPAPER_LETTER As Short = 1
	Public Const DMPAPER_FIRST As Short = DMPAPER_LETTER
	'Letter 8 1/2 x 11 in
	Public Const DMPAPER_LETTERSMALL As Short = 2 'Letter Small 8 1/2 x 11 in
	Public Const DMPAPER_TABLOID As Short = 3 'Tabloid 11 x 17 in
	Public Const DMPAPER_LEDGER As Short = 4 'Ledger 17 x 11 in
	Public Const DMPAPER_LEGAL As Short = 5 'Legal 8 1/2 x 14 in
	Public Const DMPAPER_STATEMENT As Short = 6 'Statement 5 1/2 x 8 1/2 in
	Public Const DMPAPER_EXECUTIVE As Short = 7 'Executive 7 1/4 x 10 1/2 in
	Public Const DMPAPER_A3 As Short = 8 'A3 297 x 420 mm
	Public Const DMPAPER_A4 As Short = 9 'A4 210 x 297 mm
	Public Const DMPAPER_A4SMALL As Short = 10 'A4 Small 210 x 297 mm
	Public Const DMPAPER_A5 As Short = 11 'A5 148 x 210 mm
	Public Const DMPAPER_B4 As Short = 12 'B4 250 x 354
	Public Const DMPAPER_B5 As Short = 13 'B5 182 x 257 mm
	Public Const DMPAPER_FOLIO As Short = 14 'Folio 8 1/2 x 13 in
	Public Const DMPAPER_QUARTO As Short = 15 'Quarto 215 x 275 mm
	Public Const DMPAPER_10X14 As Short = 16 '10x14 in
	Public Const DMPAPER_11X17 As Short = 17 '11x17 in
	Public Const DMPAPER_NOTE As Short = 18 'Note 8 1/2 x 11 in
	Public Const DMPAPER_ENV_9 As Short = 19 'Envelope #9 3 7/8 x 8 7/8
	Public Const DMPAPER_ENV_10 As Short = 20 'Envelope #10 4 1/8 x 9 1/2
	Public Const DMPAPER_ENV_11 As Short = 21 'Envelope #11 4 1/2 x 10 3/8
	Public Const DMPAPER_ENV_12 As Short = 22 'Envelope #12 4 \276 x 11
	Public Const DMPAPER_ENV_14 As Short = 23 'Envelope #14 5 x 11 1/2
	Public Const DMPAPER_CSHEET As Short = 24 'C size sheet
	Public Const DMPAPER_DSHEET As Short = 25 'D size sheet
	Public Const DMPAPER_ESHEET As Short = 26 'E size sheet
	Public Const DMPAPER_ENV_DL As Short = 27 'Envelope DL 110 x 220mm
	Public Const DMPAPER_ENV_C5 As Short = 28 'Envelope C5 162 x 229 mm
	Public Const DMPAPER_ENV_C3 As Short = 29 'Envelope C3  324 x 458 mm
	Public Const DMPAPER_ENV_C4 As Short = 30 'Envelope C4  229 x 324 mm
	Public Const DMPAPER_ENV_C6 As Short = 31 'Envelope C6  114 x 162 mm
	Public Const DMPAPER_ENV_C65 As Short = 32 'Envelope C65 114 x 229 mm
	Public Const DMPAPER_ENV_B4 As Short = 33 'Envelope B4  250 x 353 mm
	Public Const DMPAPER_ENV_B5 As Short = 34 'Envelope B5  176 x 250 mm
	Public Const DMPAPER_ENV_B6 As Short = 35 'Envelope B6  176 x 125 mm
	Public Const DMPAPER_ENV_ITALY As Short = 36 'Envelope 110 x 230 mm
	Public Const DMPAPER_ENV_MONARCH As Short = 37 'Envelope Monarch 3.875 x 7.5 in
	Public Const DMPAPER_ENV_PERSONAL As Short = 38 '6 3/4 Envelope 3 5/8 x 6 1/2 in
	Public Const DMPAPER_FANFOLD_US As Short = 39 'US Std Fanfold 14 7/8 x 11 in
	Public Const DMPAPER_FANFOLD_STD_GERMAN As Short = 40 'German Std Fanfold 8 1/2 x 12 in
	Public Const DMPAPER_FANFOLD_LGL_GERMAN As Short = 41 'German Legal Fanfold 8 1/2 x 13 in
	
	Public Const DMPAPER_LAST As Short = DMPAPER_FANFOLD_LGL_GERMAN
	
	Public Const DMPAPER_USER As Short = 256
	Public Const DM_IN_PROMPT As Short = 4
	Public Const DM_IN_BUFFER As Short = 8
	Public Const DM_OUT_BUFFER As Short = 2
	Public Const DMORIENT_PORTRAIT As Short = 1
	Public Const DMORIENT_LANDSCAPE As Short = 2
	Public Const DM_YRESOLUTION As Integer = &H2000
	Public Const PRINTER_ACCESS_USE As Short = &H8s
	Public Const PRINTER_ACCESS_ADMINISTER As Short = &H4s
	Public Const DC_PAPERNAMES As Short = 16
	Public Const DC_PAPERS As Short = 2
	Public Const DC_BINS As Short = 6
	Public Const DC_BINNAMES As Short = 12
	
	'  �f�o�C�X��������̃T�C�Y
	'#Start(2003.11.16) CR9 Unicode �Ή�
	'Public Const CCHDEVICENAME = 32
	Public Const CCHDEVICENAME As Short = 64
	'#End(2003.11.16)
	'  �t�H�[����������̃T�C�Y
	'#Start(2003.11.16) CR9 Unicode �Ή�
	'Public Const CCHFORMNAME = 32
	Public Const CCHFORMNAME As Short = 64
	'#End(2003.11.16)
	Structure DEVMODE
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(CCHDEVICENAME),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=CCHDEVICENAME)> Public dmDeviceName() As Char
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
		<VBFixedString(CCHFORMNAME),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=CCHFORMNAME)> Public dmFormName() As Char
		Dim dmUnusedPadding As Short
		Dim dmBitsPerPel As Short
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
		'2000/10/19 �P�s�ύX�@�����v�����^���ɑΉ�
		'    YOBI(1893) As Byte
		<VBFixedArray(1813)> Dim YOBI() As Byte
		'2000/10/19 �P�s�ǉ��@�����v�����^���ɑΉ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(80),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=80)> Public LongDeviceName() As Char
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			ReDim YOBI(1813)
		End Sub
	End Structure
	
	Structure PRINTER_DEFAULTS
		Dim PDATATYPE As String
		Dim PDEVMODE As Integer
		Dim DESIREDACCESS As Integer
	End Structure
	
	Structure SAVDEVMODE
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public RPTID() As Char
		'UPGRADE_WARNING: �\���� dm �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim dm As DEVMODE
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			dm.Initialize()
		End Sub
	End Structure
	
	Private strLSTID As String '������[ID
	
	Private strPrtSeq As String '������[ID
	
	' === 20061120 === UPDATE S - ACE)Nagasawa �����̓ǂݕ��̕ύX
	'�v���r���[��ʂł̃{�^���̕\���^��\��
	Private Const pv_intWindowButton_Visible As Short = 1 '�\��
	Private Const pv_intWindowButton_UnVisible As Short = 0 '��\��
	' === 20061120 === UPDATE E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub GetPrtSeq
	'   �T�v�F  ���[�p�V�[�P���X�擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�擾�����V�[�P���X�@�ُ�I���̏ꍇ�͋󕶎���Ԃ�
	'   ���l�F  USR9�ւ̐ڑ��͌Ăяo�����ōs������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GetPrtSeq() As String
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSeq As String
		'execute -------+---------------+---------------+---------------+---------------
		
		GetPrtSeq = ""
		
		'SQL���̍쐬
		strSQL = ""
		strSQL = strSQL & " SELECT PRTSEQ.NEXTVAL PRTSEQ "
		strSQL = strSQL & " FROM DUAL "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSeq = CStr(CF_Ora_GetDyn(Usr_Ody, "PRTSEQ", 0))
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		GetPrtSeq = strSeq
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub DeleteListWk
	'   �T�v�F  ���[�N�e�[�u���폜��������
	'   �����F�@pin_strTableName    : �폜�Ώۃe�[�u����
	'           pin_strPrtTanId     : �폜�Ώۂ̏o�͒S���҃R�[�h
	'           pin_strPrtSeq       : �폜�Ώۂ̂r�d�p
	'   �ߒl�F�@0 : ����I�� 2 : �����G���[ 9 : �ُ�I��
	'   ���l�F  USR9�ւ̐ڑ��͌Ăяo�����ōs������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DeleteListWk(ByRef pin_strTableName As String, ByRef pin_strPrtTanId As String, ByRef pin_strPrtSeq As String) As Short
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strSQL As String
		Dim bolRet As Boolean
		'execute -------+---------------+---------------+---------------+---------------
		
		DeleteListWk = 9
		
		'�����`�F�b�N
		'�e�[�u����
		If pin_strTableName = "" Then
			DeleteListWk = 2
			Exit Function
		End If
		'�o�͒S���҃R�[�h
		If pin_strPrtTanId = "" Then
			DeleteListWk = 2
			Exit Function
		End If
		'�r�d�p
		If pin_strPrtSeq = "" Then
			DeleteListWk = 2
			Exit Function
		End If
		
		'SQL����
		strSQL = ""
		strSQL = strSQL & " DELETE "
		strSQL = strSQL & " FROM " & pin_strTableName
		strSQL = strSQL & " WHERE  "
		strSQL = strSQL & "     PRTTANID = '" & pin_strPrtTanId & "' "
		strSQL = strSQL & " AND PRTSEQ = '" & pin_strPrtSeq & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR9, strSQL)
		If Not bolRet Then
			Exit Function
		End If
		
		DeleteListWk = 0
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub OutPutList_Main
	'   �T�v�F  �N���X�^�����|�[�g�o�̓��C������
	'   �����F�@pin_strLSTKB    : ���X�g�敪(1:�v�����^�[�o�� 2:�E�C���h�E�o�� 3:�t�@�C���o��)
	'           pin_strLSTID    : �o�͑Ώۃ��X�gID
	'           pin_strPrwName  : �v���r���[��ʖ�
	'           pin_strPrtSEQ   : �o�͑Ώۂr�d�p
	'           pin_ctlGAUGE    : �\���K�C�h(�R���g���[��)
	'   �ߒl�F�@0 : ����I�� 1 : ���ň���� 2 : �L�����Z�� 3 : �Y���f�[�^���� 9 : �ُ�I��
	'   ���l�F  �X�e�[�^�X�o�[�̕\���A�{�^���̔�\������ʂ̕ҏW�͌ďo���ōs������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function OutPutList_Main(ByVal pin_intLSTKB As Integer, _
	''                                ByVal pin_strLSTID As String, _
	''                                ByVal pin_strPrwName As String, _
	''                                ByVal pin_strPrtSeq As String, _
	''                                Optional ByRef pin_ctlGAUGE As SSPanel5 _
	''                                ) As Integer
	Public Function OutPutList_Main(ByVal pin_intLSTKB As Short, ByVal pin_strLSTID As String, ByVal pin_strPrwName As String, ByVal pin_strPrtSeq As String) As Short
		
		Dim intRtn As Short
		Dim bolRtn As Boolean
		Dim wkRptId As String
		Dim wkWindowOption As T_PEWindowOptions
		Dim wkPrintOption As T_PEPrintOptions
		Dim wkWidth, wkTop, wkLeft, wkHeight As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		' === 20070307 === UPDATE S - ACE)Nagasawa
		'    Dim intCnt          As Integer
		Dim intCnt As Decimal
		' === 20070307 === UPDATE E -
		Dim ErrorMsg As String
		Dim rtn As Integer
		
		On Error GoTo ERR_OutPutList_Main
		
		OutPutList_Main = 9
		ErrorMsg = ""
		
		strLSTID = pin_strLSTID
		strPrtSeq = pin_strPrtSeq
		
		' �N���X�^�����|�[�g�̃I�[�v��
		If CRW_INIT() = False Then
			ErrorMsg = "ERROR CRW_INIT"
			GoTo ERR_OutPutList_Main
		Else
			' ���|�[�g�������
			If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & pin_strLSTID & ".RPT") = False Then
				ErrorMsg = "ERROR CRW_OPEN"
				GoTo ERR_OutPutList_Main
			End If
		End If
		
		If CRW_DOCHECK() = False Then
			MsgBox("���ň�����ׁ̈A���s�ł��܂���B", MB_ICONEXCLAMATION)
			
			Call CRW_CLOSE()
			
			OutPutList_Main = 1
			Exit Function
		End If
		
		SSS_LSTOP = False
		
		strSQL = ""
		strSQL = strSQL & " select count(*) as LISTCNT "
		strSQL = strSQL & "   from " & pin_strLSTID
		strSQL = strSQL & "  where RPTCLTID = '" & SSS_CLTID.Value & "' "
		'    strSQL = strSQL & "    and PRTSEQ   =  " & strPrtSeq & " "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intCnt = CF_Ora_GetDyn(Usr_Ody, "LISTCNT", 0)
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'�L�����Z������
		If SSS_LSTOP = True Then
			Call CRW_CLOSE()
			OutPutList_Main = 2
			
			Exit Function
		End If
		
		'    If IsMissing(pin_ctlGAUGE) = True Then
		'        pin_ctlGAUGE.FloodPercent = 100
		'    End If
		
		If intCnt = 0 Then
			OutPutList_Main = 3
		Else
			'�_�C�A���O�ɂ��v�����^�ؑւ������ꂽ���̂��Đݒ肷��B
			'��p���[�̏ꍇ�N���X�^�����|�[�g�̃��[�U�[��`��D�悷��B
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(SSS_Lconfig) Then SSS_Lconfig = ""
			If SSS_Lconfig <> "USR" Then Call CRW_SET_PRINTER()
			
			Select Case pin_intLSTKB
				Case SSS_PRINTER
					bolRtn = CRW_PUTPRINTER()
					'��������̎w��
					wkPrintOption.StructSize = PE_SIZEOF_PRINT_OPTIONS
					intRtn = PEGetPrintOptions(HCRW, wkPrintOption)
					wkPrintOption.StartPageN = SSS_StartPageNo
					wkPrintOption.stopPageN = SSS_StopPageNo
					wkPrintOption.nReportCopies = SSS_Copies
					If SSS_Copies > 1 Then
						wkPrintOption.collation = IIf((SSS_Collation = 1), PE_COLLATED, PE_UNCOLLATED)
					End If
					intRtn = PESetPrintOptions(HCRW, wkPrintOption)
				Case SSS_VIEW
					'�v���r���[��ʂ̃f�t�H���g�T�C�Y���w��
					intRtn = GetPrivateProfileString("REPORT", "CRW_LEFT", "", wkStr.Value, 128, "SSSWIN.INI")
					If intRtn > 0 Then wkLeft = Int(CDbl(Left(wkStr.Value, intRtn)))
					intRtn = GetPrivateProfileString("REPORT", "CRW_TOP", "", wkStr.Value, 128, "SSSWIN.INI")
					If intRtn > 0 Then wkTop = Int(CDbl(Left(wkStr.Value, intRtn)))
					intRtn = GetPrivateProfileString("REPORT", "CRW_HEIGHT", "", wkStr.Value, 128, "SSSWIN.INI")
					If intRtn > 0 Then wkHeight = Int(CDbl(Left(wkStr.Value, intRtn)))
					intRtn = GetPrivateProfileString("REPORT", "CRW_WIDTH", "", wkStr.Value, 128, "SSSWIN.INI")
					If intRtn > 0 Then wkWidth = Int(CDbl(Left(wkStr.Value, intRtn)))
					
					'���m���`�F�b�N
					If wkTop <= 0 Or wkTop >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkTop = 0
					If wkLeft <= 0 Or wkLeft >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkLeft = 0
					If wkWidth <= 0 Or wkWidth >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15
					If wkHeight <= 0 Or wkHeight >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15
					If wkLeft + wkWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 - wkLeft
					If wkTop + wkHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 - wkHeight
					
					'�v���r���[��ʐݒ�
					intRtn = CRW_PUTWINDOW(CStr(FR_SSSMAIN.Text) & "���߰�", wkLeft, wkTop, wkWidth, wkHeight)
					
					'�v���r���[��ʂł̃{�^���\���^��\��
					wkWindowOption.StructSize = PE_SIZEOF_WINDOW_OPTIONS
					intRtn = PEGetWindowOptions(HCRW, wkWindowOption)
					' === 20061120 === UPDATE S - ACE)Nagasawa �����̓ǂݕ��̕ύX
					'                wkWindowOption.hasPrintButton = IIf((SSS_Hide_Prnbutton), 0, 1)
					'                wkWindowOption.hasExportButton = IIf((SSS_Hide_Expbutton), 0, 1)
					'                wkWindowOption.hasPrintSetupButton = IIf((SSS_Hide_Prnset), 0, 1)
					
					'����{�^���A�v�����^�ݒ�{�^���̐���i�\���^��\���j
					If Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_OK Then
						'��������L��
						wkWindowOption.hasPrintButton = pv_intWindowButton_Visible
						wkWindowOption.hasPrintSetupButton = pv_intWindowButton_Visible
					ElseIf Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_NG Then 
						'�����������
						wkWindowOption.hasPrintButton = pv_intWindowButton_UnVisible
						wkWindowOption.hasPrintSetupButton = pv_intWindowButton_UnVisible
					End If
					
					'�t�@�C���o�͌���
					If Inp_Inf.InpFILEAUTH = gc_strFILEAUTH_OK Then
						'�t�@�C���o�͌����L��
						wkWindowOption.hasExportButton = pv_intWindowButton_Visible
					ElseIf Inp_Inf.InpFILEAUTH = gc_strFILEAUTH_NG Then 
						'�t�@�C���o�͌�������
						wkWindowOption.hasExportButton = pv_intWindowButton_UnVisible
					End If
					' === 20061120 === UPDATE E -
					intRtn = PESetWindowOptions(HCRW, wkWindowOption)
					
				Case SSS_FILE
					intRtn = CRW_SETEXPATR()
			End Select
			
			If intRtn = False Then
				ErrorMsg = "ERROR OutPutList_Main �o�͐�I�� RTN=[" & Str(intRtn) & "]"
				GoTo ERR_OutPutList_Main
			End If
			
			If bolRtn = True Or intRtn = 1 Then
				System.Windows.Forms.Application.DoEvents()
				'�������
				If CRW_PRINT() = False Then
					ErrorMsg = "ERROR OutPutList_Main CRW_PRINT"
					GoTo ERR_OutPutList_Main
				End If
				
				OutPutList_Main = 0
				
			ElseIf intRtn <> PE_ERR_USERCANCELLED Then 
				'CRW�ŃG���[�����������ꍇ
				intRtn = MsgBox("OutPutList_Main��CRW�G���[���������܂����F[" & Str(intRtn) & "]")
				ErrorMsg = "ERROR OutPutList_Main �o�͐�I�� RTN=[" & Str(intRtn) & "]"
				GoTo ERR_OutPutList_Main
			End If
			
			Do While CRW_VIEWCHECK()
                '20190625 CHG START
                'Call Sleep(200)
                System.Threading.Thread.Sleep(200)
                '20190625 CHG END
                System.Windows.Forms.Application.DoEvents()
            Loop 
			
			System.Windows.Forms.Application.DoEvents()
		End If
		
		Call CRW_CLOSE()
		
END_OutPutList_Main: 
		Exit Function
		
ERR_OutPutList_Main: '
		Call SSSWIN_LOGWRT(ErrorMsg)
		
		If DBSTAT <> 0 Then
			MsgBox("�G���[���O�̏������݃G���[ ! Windows ���ċN�����Ă�������")
		End If
		
		rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
		
		GoTo END_OutPutList_Main
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_INIT
	'   �T�v�F  �N���X�^�����|�[�g������
	'   �����F  �Ȃ�
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CRW_INIT() As Boolean
		
		Dim rtn As Integer
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim tmpStr As String
		
		CRW_INIT = False
		
		If PEGetVersion(PE_GV_DLL) < PE_DLLVERSION Then
			MsgBox("�N���X�^�����|�[�g�̃o�[�W�������Ⴂ�܂��B(DLL) ")
			Exit Function
		End If
		
		If PEGetVersion(PE_GV_ENGINE) < PE_ENGINEVERSION Then
			MsgBox("�N���X�^�����|�[�g�̃o�[�W�������Ⴂ�܂��B(Engine)")
			Exit Function
		End If
		
		If PEOpenEngine() = False Then
			MsgBox("�N���X�^�����|�[�g�̊J�n�Ɏ��s���܂����B")
		End If
		
		CRW_INIT = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_OPEN
	'   �T�v�F  ���|�[�g�������
	'   �����F  ReportPath : ����Ώۃ��|�[�g�p�X
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_OPEN(ByRef ReportPath As String) As Boolean
		
		HCRW = PEOpenPrintJob(ReportPath)
		If HCRW = 0 Then
			MsgBox("CRW_OPEN.PEOpenPrintJob : " & CRW_GETERRMSG(HCRW))
			CRW_OPEN = False
		Else
			CRW_OPEN = True
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_DOCHECK
	'   �T�v�F  ��������۔���
	'   �����F  �Ȃ�
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_DOCHECK() As Boolean
		'
		Dim JINF As T_PEJobInfo
		
		JINF.StructSize = PE_SIZEOF_JOB_INFO
		
		Select Case PEGetJobStatus(HCRW, JINF)
			Case PE_JOBINPROGRESS
				CRW_DOCHECK = False
			Case Else
				CRW_DOCHECK = True
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_SET_PRINTER
	'   �T�v�F  �v�����^�ݒ�
	'   �����F  �Ȃ�
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub CRW_SET_PRINTER()
        '20190627 DEL START
        '      Dim PrinterName As String
        'Dim UniDevice() As Byte
        'Dim UniDriver() As Byte
        'Dim UniPort() As Byte
        'Dim DriverName As String
        'Dim PortName As String
        'Dim buf As New VB6.FixedLengthString(128)
        'Dim DriverHandle As Integer
        'Dim DriverLength As Short
        'Dim PrinterHandle As Integer
        'Dim PrinterLength As Short
        'Dim PortHandle As Integer
        'Dim PortLength As Short
        'Dim result As Short
        'Dim Mode As Integer
        ''UPGRADE_WARNING: �\���� dm �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        'Dim dm As DEVMODE
        'Dim I As Short
        'Dim dmOutBuf() As Byte

        'If GetUsePrinter(dm) Then
        '	DriverName = "winspool"
        '	PortName = ""
        '	PrinterName = agGetStringFromLPSTR(dm.LongDeviceName)
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes("winspool" & Chr(0))
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Chr(0))
        '	'UPGRADE_ISSUE: Printers ���\�b�h Printers.count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '	For I = 0 To Printers.count - 1
        '		'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DeviceName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '		If Printers(I).DeviceName = PrinterName Then
        '			'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DriverName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '			'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '			UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(I).DriverName & Chr(0))
        '			'UPGRADE_ISSUE: Printer �v���p�e�B Printers.Port �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '			'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '			UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(I).Port & Chr(0))
        '			Exit For
        '		End If
        '	Next 
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(PrinterName & Chr(0))
        '	ReDim dmOutBuf(4096)
        '	'UPGRADE_WARNING: �I�u�W�F�N�g dm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	agCopyData(dm, dmOutBuf(0), Len(dm) - 80) '���ɒǉ������v�����^���̕�������
        '	Call PESelectPrinter(HCRW, UniDriver(0), UniDevice(0), UniPort(0), agGetAddressForObject(dmOutBuf(0)))
        'ElseIf HasDefaultSetting(SSS_PrgId) Then 
        '	'���[�̃f�t�H�[���g�p���T�C�Y�ƈ󎚌������o�^����Ă���ꍇ
        '	Call GetDevMode2(GetDefDevice2(), DM_OUT_BUFFER)
        '	DriverName = "winspool"
        '	PortName = ""
        '	PrinterName = agGetStringFromLPSTR(gSelDM.LongDeviceName)
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes("winspool" & Chr(0))
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Chr(0))
        '	'UPGRADE_ISSUE: Printers ���\�b�h Printers.count �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
        '	For I = 0 To Printers.count - 1
        '		'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DeviceName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '		If Printers(I).DeviceName = PrinterName Then
        '			'UPGRADE_ISSUE: Printer �v���p�e�B Printers.DriverName �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '			'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '			UniDriver = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(I).DriverName & Chr(0))
        '			'UPGRADE_ISSUE: Printer �v���p�e�B Printers.Port �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '			'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '			UniPort = System.Text.UnicodeEncoding.Unicode.GetBytes(Printers(I).Port & Chr(0))
        '			Exit For
        '		End If
        '	Next 
        '	'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '	UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(PrinterName & Chr(0))
        '	'#End(2003.11.16)
        '	'Default�p�����ށ�SSS_DefPaperSize
        '	'Default�󎚌�����SSS_DefOrient
        '	gSelDM.dmOrientation = SSS_DefOrient
        '	gSelDM.dmPaperSize = SSS_DefPaperSize
        '	ReDim dmOutBuf(4096)
        '	'UPGRADE_WARNING: �I�u�W�F�N�g gSelDM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	agCopyData(gSelDM, dmOutBuf(0), Len(gSelDM) - 80) '���ɒǉ������v�����^���̕�������
        '	Call PESelectPrinter(HCRW, UniDriver(0), UniDevice(0), UniPort(0), agGetAddressForObject(dmOutBuf(0)))
        'Else
        '	If PEGetSelectedPrinter(HCRW, DriverHandle, DriverLength, PrinterHandle, PrinterLength, PortHandle, PortLength, Mode) = 1 Then
        '		If PEGetHandleString(DriverHandle, buf.Value, DriverLength) = 1 Then
        '			DriverName = LeftWid(buf.Value, DriverLength)
        '			If PEGetHandleString(PrinterHandle, buf.Value, PrinterLength) = 1 Then
        '				PrinterName = LeftWid(buf.Value, PrinterLength)
        '				If PEGetHandleString(PortHandle, buf.Value, PortLength) = 1 Then
        '					PortName = LeftWid(buf.Value, PortLength)
        '					If PESelectPrinter(HCRW, DriverName, PrinterName, PortName, 0) = 1 Then
        '					End If
        '				End If
        '			End If
        '		End If
        '	End If
        'End If
        '20190627 DEL END
    End Sub
	
	Private Function CRW_PUTPRINTER() As Boolean
		
		If PEOutputToPrinter(HCRW, SSS_Copies) = False Then
			If PEGetErrorCode(HCRW) = PE_ERR_NOERROR Then
				CRW_PUTPRINTER = True
			Else
				MsgBox("CRW_PUTPRINTER.PEOutputToPrinter : " & CRW_GETERRMSG(HCRW))
				CRW_PUTPRINTER = False
			End If
		Else
			CRW_PUTPRINTER = True
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_PUTWINDOW
	'   �T�v�F  �o�͐���E�C���h�E�ɐݒ�(�v���r���[���)
	'   �����F  pin_strWHEDER : �v���r���[��ʃ^�C�g��
	'           pin_intWLEFT  : ��ʈʒu(��)
	'           pin_intWTOP   : ��ʍ���
	'           pin_intWWIDTH : ��ʕ�
	'           pin_intWHIGH  : ��ʈʒu(�c)
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_PUTWINDOW(ByVal pin_strWHEDER As String, ByVal pin_intWLEFT As Short, ByVal pin_intWTOP As Short, ByVal pin_intWWIDTH As Short, ByVal pin_intWHIGH As Short) As Boolean
		
		If PEOutputToWindow(HCRW, pin_strWHEDER, pin_intWLEFT, pin_intWTOP, pin_intWWIDTH, pin_intWHIGH, 0, 0) = False Then
			If PEGetErrorCode(HCRW) = PE_ERR_NOERROR Then
				CRW_PUTWINDOW = True
			Else
				MsgBox("CRW_PUTWINDOW.PEOutputToWindow : " & CRW_GETERRMSG(HCRW))
				CRW_PUTWINDOW = False
			End If
		Else
			CRW_PUTWINDOW = True
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_SETEXPATR
	'   �T�v�F  �t�@�C���o�͐ݒ�
	'   �����F  �Ȃ�
	'   �ߒl�F�@0 : ����I���@1 : �ُ�I��  545(PE_ERR_USERCANCELLED) : �L�����Z��
	'   ���l�F�@���[�U�[�ɂ��L�����Z�����́APE_ERR_USERCANCELLED ��Ԃ��B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_SETEXPATR() As Short
		
		Dim ExpOption As T_PEExportOptions
		
		CRW_SETEXPATR = False
		ExpOption.StructSize = PE_SIZEOF_EXPORT_OPTIONS
		
		If PEGetExportOptions(HCRW, ExpOption) = False Then
			If PEGetErrorCode(HCRW) = PE_ERR_USERCANCELLED Then
				CRW_SETEXPATR = PE_ERR_USERCANCELLED
			Else
				MsgBox("CRW_SETEXPATR.PEGetExportOptions : " & CRW_GETERRMSG(HCRW))
			End If
		Else
			If PEExportTo(HCRW, ExpOption) = False Then
				MsgBox("CRW_SETEXPATR.PEExportTo : " & CRW_GETERRMSG(HCRW))
			Else
				CRW_SETEXPATR = True
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_SETEXPATR
	'   �T�v�F  ���|�[�g�o�͏���
	'   �����F  �Ȃ�
	'   �ߒl�F�@0 : ����I���@1 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_PRINT() As Short
		
		Dim intRtn As Short
		Dim JINF As T_PEJobInfo
		
		JINF.StructSize = PE_SIZEOF_JOB_INFO
		
		If CRW_DOCHECK() = False Then
			MsgBox("�o�͒��ׁ̈A���s�ł��܂���B", 48)
			CRW_PRINT = False
			Exit Function
		End If
		
		intRtn = PEDiscardSavedData(HCRW)
		If intRtn = 0 Then
			MsgBox("PEDiscardSavedData�ŃG���[���������܂����B")
			CRW_PRINT = False
			Exit Function
		End If
		
		intRtn = Crw_ChgLocOra
		If intRtn = 0 Then
			MsgBox("CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW))
			CRW_PRINT = False
			Exit Function
		End If
		
		'������i���_�C�A���O�{�b�N�X�\���^��\��
		If SSS_ShowProgress Then '�\��
			intRtn = PEEnableProgressDialog(HCRW, True)
		Else
			intRtn = PEEnableProgressDialog(HCRW, False)
		End If
		
		'�v���r���[��ʂ̃Y�[�����x����ݒ�
		Dim wkReportOptions As T_PEReportOptions
		
		wkReportOptions.StructSize = PE_SIZEOF_REPORT_OPTIONS
		intRtn = PEGetReportOptions(HCRW, wkReportOptions)
		wkReportOptions.zoomMode = PE_ZOOM_FULL_SIZE
		intRtn = PESetReportOptions(HCRW, wkReportOptions)
		
		intRtn = PEStartPrintJob(HCRW, 1)
		If intRtn = 1 Then
			intRtn = PEGetJobStatus(HCRW, JINF)
			Select Case intRtn
				Case PE_JOBCOMPLETED
				Case PE_JOBCANCELLED
					MsgBox("�o�͂���������܂����B")
					Call PECloseWindow(HCRW)
				Case Else
					MsgBox("CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW))
					CRW_PRINT = False
					Exit Function
			End Select
		Else
			intRtn = PEGetErrorCode(HCRW)
			MsgBox("CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW))
			CRW_PRINT = False
			Exit Function
		End If
		CRW_PRINT = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_SETEXPATR
	'   �T�v�F  ORACLE���[�N�f�[�^�[�x�[�X�ؑ�
	'   �����F  �Ȃ�
	'   �ߒl�F�@0 : ����I���@1 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function Crw_ChgLocOra() As Boolean
		
		Dim rtn, usrNo As Short
		Dim LogOnInfo As T_PELogOnInfo
		Dim TblLocation As T_PETableLocation
		Dim SSS_DBHEAD, CRW_DSN As String
		Dim wkStr As New VB6.FixedLengthString(128)
		Dim newSelectionFormula As String
		Dim wkPassWord, wkUsr As String
		
		SSS_DBHEAD = Get_DBHEAD()
		
		rtn = GetPrivateProfileString("REPORT", "CRW_DSN_ORA", "", wkStr.Value, 128, "SSSWIN.INI")
		If rtn = 0 Then rtn = GetPrivateProfileString("REPORT", "CRW_DSN", "", wkStr.Value, 128, "SSSWIN.INI")
		If rtn > 0 Then CRW_DSN = Left(wkStr.Value, rtn)
		
		TblLocation.StructSize = PE_SIZEOF_TABLE_LOCATION
		
		'���O�I�����Z�b�g
		LogOnInfo.StructSize = PE_SIZEOF_LOGON_INFO
		LogOnInfo.ServerName = CRW_DSN & Chr(0)
		LogOnInfo.DatabaseName = Get_DBHEAD & "_" & ORA_MAX_USR1 & Chr(0)
		LogOnInfo.Password = ORA_MAX_PASS & Chr(0)
		LogOnInfo.UserID = Get_DBHEAD & "_" & ORA_MAX_USR1 & Chr(0)
		rtn = PESetNthTableLogOnInfo(HCRW, 0, LogOnInfo, False)
		If rtn = 0 Then
			Crw_ChgLocOra = False
			Exit Function
		End If
		newSelectionFormula = "{" & strLSTID & ".RPTCLTID} = '" & SSS_CLTID.Value & "'"
		rtn = PESetSelectionFormula(HCRW, newSelectionFormula)
		If rtn <> 1 Then
			rtn = PEGetErrorCode(HCRW)
			MsgBox("Failed to Set SelectionFormula")
			Crw_ChgLocOra = False
			Exit Function
		End If
		Crw_ChgLocOra = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_VIEWCHECK
	'   �T�v�F  �ޭ�����޳�̕\����ԃ`�F�b�N
	'   �����F  �Ȃ�
	'   �ߒl�F�@0 : ����I���@1 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_VIEWCHECK() As Short
		
		Dim wkHandle As Integer
		
		wkHandle = PEGetWindowHandle(HCRW)
		If wkHandle <> 0 Then
			CRW_VIEWCHECK = 1
		Else
			CRW_VIEWCHECK = 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_CLOSE
	'   �T�v�F  �v�����g�W���u�����B
	'   �����F  �Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CRW_CLOSE()
		
		Dim rtn As Short
		
		rtn = PEClosePrintJob(HCRW)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_END
	'   �T�v�F  �N���X�^�����|�[�g�G���W�����I������B
	'   �����F  �Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CRW_END()
		
		Call PECloseEngine()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CRW_END
	'   �T�v�F  �G���[���b�Z�[�W�擾
	'   �����F  �Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CRW_GETERRMSG(ByRef HPRN As Short) As String
		
		Dim HTXT As Integer
		Dim TXTLEN As Short
		Dim ERRTEXT As New VB6.FixedLengthString(128)
		
		If PEGetErrorText(HPRN, HTXT, TXTLEN) = False Then
			CRW_GETERRMSG = "�G���[���b�Z�[�W�̎擾�Ɏ��s���܂����B"
		Else
			If PEGetHandleString(HTXT, ERRTEXT.Value, TXTLEN) = False Then
				CRW_GETERRMSG = "�G���[���b�Z�[�W�̎擾�Ɏ��s���܂����B"
			Else
				CRW_GETERRMSG = ERRTEXT.Value
			End If
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function PEGetJobStatus
	'   �T�v�F  �X�e�[�^�X�擾
	'   �����F
	'   �ߒl�F�@�擾���ꂽ�X�e�[�^�X
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function PEGetJobStatus(ByVal job As Short, ByRef Info As T_PEJobInfo) As Short
		
		Dim splitinfo As SplitPEJobInfo
		Dim temp1 As Integer
		Dim temp2 As Integer
		
		splitinfo.StructSize = PE_SIZEOF_JOB_INFO
		PEGetJobStatus = RealPEGetJobStatus(job, splitinfo)
		If PEGetJobStatus <> -1 Then
			temp1 = splitinfo.NumRecordsRead1
			If temp1 < 0 Then
				temp1 = 65536 + temp1
			End If
			temp2 = splitinfo.NumRecordsRead2
			If temp2 < 0 Then
				temp2 = 65536 + temp2
			End If
			temp2 = temp2 * 65536
			Info.NumRecordsRead = temp1 + temp2
			
			temp1 = splitinfo.NumRecordsSelected1
			If temp1 < 0 Then
				temp1 = 65536 + temp1
			End If
			temp2 = splitinfo.NumRecordsSelected2
			If temp2 < 0 Then
				temp2 = 65536 + temp2
			End If
			temp2 = temp2 * 65536
			Info.NumRecordsSelected = temp1 + temp2
			
			temp1 = splitinfo.NumRecordsPrinted1
			If temp1 < 0 Then
				temp1 = 65536 + temp1
			End If
			temp2 = splitinfo.NumRecordsPrinted2
			If temp2 < 0 Then
				temp2 = 65536 + temp2
			End If
			Info.NumRecordsPrinted = temp1 + temp2
			Info.LatestPageN = splitinfo.LatestPageN
			Info.StartPageN = splitinfo.StartPageN
			Info.DisplayPageN = splitinfo.DisplayPageN
			Info.PrintEnded = splitinfo.PrintEnded
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function GetUsePrinter
	'   �T�v�F  �Z�[�u�����v�����^�������o���B
	'   �����F
	'   �ߒl�F�@True : ����I�� False : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Public Function GetUsePrinter(ByRef dm As DEVMODE) As Boolean
		
		Dim sdm As SAVDEVMODE
		Dim ws As String
		Dim WL_RPTID As New VB6.FixedLengthString(8)
		Dim Fno As Short
		Dim I As Short
		Dim found As Boolean
		
		On Error GoTo GetUsePrinter_Err
		
		GetUsePrinter = False
		'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		ws = Dir(SSS_INIDAT(3) & "SSSPRN.CFG")
		If ws = "" Then Exit Function
		
		' === 20060905 === UPDATE S - ACE)Nagasawa
		'    WL_RPTID = strLSTID
		If Trim(SSS_RPTID) = "" Then
			WL_RPTID.Value = SSS_PrgId
		Else
			WL_RPTID.Value = SSS_RPTID
		End If
		' === 20060905 === UPDATE E -
		
		Fno = FreeFile
		FileOpen(Fno, SSS_INIDAT(3) & "SSSPRN.CFG", OpenMode.Random, , , Len(sdm))
		I = 1
		found = False
		Do 
			'UPGRADE_WARNING: Get �́AFileGet �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			FileGet(Fno, sdm, I)
			If EOF(Fno) Then Exit Do
			If Left(sdm.dm.LongDeviceName, 1) = Chr(0) Then
				sdm.dm.LongDeviceName = sdm.dm.dmDeviceName
			End If
			If sdm.RPTID = WL_RPTID.Value Then
				'UPGRADE_WARNING: �I�u�W�F�N�g dm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				dm = sdm.dm
				found = True
				GetUsePrinter = True
				Exit Do
			End If
			I = I + 1
		Loop 
		FileClose(Fno)
		Dim devname, devoutput As String
		Dim count As Integer
		Dim names As String
		Dim a As String
		Dim di As Integer
		Dim NoBuf() As Byte
		Dim No As Short
		If found Then
			'�p��Name�ɂ��p���ԍ��̒u���������s��
			devname = agGetStringFromLPSTR(dm.LongDeviceName)
			devoutput = ""
			' �g�p�\�ȗp���T�C�Y���擾���܂��B
			count = DeviceCapabilities(devname, devoutput, DC_PAPERNAMES, vbNullString, 0)
			If count <= 0 Then
				MsgBox("�g�p�\�ȗp���T�C�Y�̏�񂪎擾�ł��܂���B", 0, "�v�����^�̐ݒ�")
				Exit Function
			End If
			' ����ێ��ł���\���ȗ̈���m�ۂ��܂��B
			names = New String(Chr(0), 64 * count)
			di = DeviceCapabilities(devname, devoutput, DC_PAPERNAMES, names, 0)
			' �g�p�\�ȗp���T�C�Y���擾���܂��B
			count = DeviceCapabilitiesNo(devname, devoutput, DC_PAPERS, 0, 0)
			If count <= 0 Then
				MsgBox("�g�p�\�ȗp���T�C�Y�̏�񂪎擾�ł��܂���B", 0, "�v�����^�̐ݒ�")
				Exit Function
			End If
			' ����ێ��ł���\���ȗ̈���m�ۂ��܂��B
			ReDim NoBuf(2 * count)
			di = DeviceCapabilitiesNo(devname, devoutput, DC_PAPERS, agGetAddressForObject(NoBuf(0)), 0)
			' �擾��������ݒ肵�܂��B
			For I = 0 To count - 1
				No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
				a = MidWid(names, I * 64 + 1, 64)
				a = agGetStringFromLPSTR(a)
				If a = agGetStringFromLPSTR(dm.dmFormName) Then
					dm.dmPaperSize = No '�p���T�C�Y�ԍ���u������
					Exit For
				End If
			Next 
		End If
		Exit Function
		
GetUsePrinter_Err: 
		GetUsePrinter = False
		MsgBox(SSS_INIDAT(3) & "SSSPRN.CFG" & " ���ǂ߂܂���B")
		Exit Function
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub PutUsePrinter
	'   �T�v�F  �v�����^�����Z�[�u����B
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub PutUsePrinter(ByRef dm As DEVMODE)
		
		Dim sdm As SAVDEVMODE
		Dim WL_RPTID As New VB6.FixedLengthString(8)
		Dim Fno As Short
		Dim I As Short
		
		On Error GoTo PutUsePrinter_Err
		If Trim(SSS_RPTID) = "" Then
			WL_RPTID.Value = SSS_PrgId
		Else
			WL_RPTID.Value = SSS_RPTID
		End If
		Fno = FreeFile
		FileOpen(Fno, SSS_INIDAT(3) & "SSSPRN.CFG", OpenMode.Random, , , Len(sdm))
		I = 1
		Do 
			'UPGRADE_WARNING: Get �́AFileGet �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			FileGet(Fno, sdm, I)
			If EOF(Fno) Or sdm.RPTID = WL_RPTID.Value Then
				sdm.RPTID = WL_RPTID.Value
				'UPGRADE_WARNING: �I�u�W�F�N�g sdm.dm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				sdm.dm = dm
				'UPGRADE_WARNING: Put �́AFilePut �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				FilePut(Fno, sdm, I)
				Exit Do
			End If
			I = I + 1
		Loop 
		FileClose(Fno)
		Exit Sub
		
PutUsePrinter_Err: 
		MsgBox(SSS_INIDAT(3) & "SSSPRN.CFG" & " �ɏ������߂܂���B")
		Exit Sub
	End Sub
	
	
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'' ��񂪓o�^����Ă���ꍇ�́A���̏������ꂼ��Z�b�g����Ă���
	''   Default�p���T�C�Y�� SSS_DefPaperSize�i0�ȊO�j
	''   Default�󎚌���  �� SSS_DefOrient�i0�ȊO�j
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Function HasDefaultSetting(ByRef vPrgid As String) As Boolean
		If SSS_DefPaperSize <> 0 And SSS_DefOrient <> 0 Then
			HasDefaultSetting = True
		Else
			HasDefaultSetting = False
		End If
	End Function
	
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'' �f�t�H�[���g�v�����^���iDeviceName�j���擾����
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Function GetDefDevice2() As String
		Dim DEF As String
		Dim di As Integer
		Dim npos As Short
		
		DEF = New String(Chr(0), 128)
		di = GetProfileString("WINDOWS", "DEVICE", "", DEF, 127)
		'#Start(2003.5.20) �v�����^���C���X�g�[������Ă��Ȃ��ꍇ�����^�C���G���[��h��
		If di = 0 Then
			MsgBox("���̂o�b�ɂ̓v�����^���C���X�g�[������Ă��Ȃ��悤�ł��B" & vbCr & "���[�v���O�����̎��s�ɂ̓v�����^(�h���C�o)���K�{�ł��B" & vbCr & "�C���X�g�[�����ĉ������B" & vbCr & "�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\" & vbCr & "�v�����^(�h���C�o�j���Ȃ��ꍇ�́A���������s����Ȃ��\��������܂��B ", MsgBoxStyle.Exclamation)
			GetDefDevice2 = ""
			Exit Function
		End If
		'#End(2003.5.20)
		DEF = agGetStringFromLPSTR(DEF)
		npos = InStr(DEF, ",")
		'#Start(2003.5.20) �v�����^����127�o�C�g�𒴂��鎞�̃����^�C���G���[��h��
		If npos < 1 Then
			MsgBox("�v�����^���Ɉُ킪����悤�ł��B" & vbCr & "�v�����^���̒�����127�o�C�g�ȓ��ɂ��ĉ������B", MsgBoxStyle.Exclamation)
			GetDefDevice2 = ""
			Exit Function
		End If
		'#End(2003.5.20)
		GetDefDevice2 = Left(DEF, npos - 1)
	End Function
	
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'' �w�肵���f�o�C�X�̏����擾���A�O���[�o���\���� gSelDM �ɃZ�b�g����
	'' ��������̏ꍇ�́A�Z�b�g����Ȃ�
	'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Sub GetDevMode2(ByVal dv As String, ByVal fmode As Integer)
		Dim hPrinter, res As Integer
		Dim pdefs As PRINTER_DEFAULTS
		Dim bufsize As Integer
		Dim dmInBuf() As Byte
		Dim dmOutBuf() As Byte
		Dim UniDevice() As Byte
		
		'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
		UniDevice = System.Text.UnicodeEncoding.Unicode.GetBytes(dv & Chr(0))
		
		pdefs.PDATATYPE = vbNullString
		pdefs.PDEVMODE = 0
		pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
		
		res = OpenPrinter(UniDevice(0), hPrinter, pdefs)
		
		If res = 0 Then Exit Sub
		bufsize = DocumentProperties(FR_SSSMAIN.Handle.ToInt32, hPrinter, UniDevice(0), 0, 0, 0)
		
		If bufsize < Len(gSelDM) Then bufsize = Len(gSelDM)
		ReDim dmInBuf(bufsize)
		ReDim dmOutBuf(bufsize)
		'UPGRADE_WARNING: �I�u�W�F�N�g gSelDM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		agCopyData(gSelDM, dmInBuf(0), Len(gSelDM))
		
		res = DocumentProperties(FR_SSSMAIN.Handle.ToInt32, hPrinter, UniDevice(0), agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
		
		' �f�[�^�o�b�t�@�� DEVMODE �\���̂փR�s�[
		If res = IDOK Then
			'UPGRADE_WARNING: �I�u�W�F�N�g gSelDM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			agCopyData(dmOutBuf(0), gSelDM, Len(gSelDM))
			gSelDM.LongDeviceName = RTrim(dv) & Chr(0)
		End If
		ClosePrinter(hPrinter)
	End Sub
End Module