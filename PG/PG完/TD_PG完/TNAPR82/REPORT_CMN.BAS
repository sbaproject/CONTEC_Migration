Attribute VB_Name = "REPORT_CMN"
Option Explicit
'
'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　共通
'*  プログラム名　　：　印刷用モジュール
'*  プログラムＩＤ　：  REPORT_BAS
'*  作成者　　　　　：　ACE)長澤
'*  作成日　　　　　：  2006.05.31
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************
    
'************************************************************************************
'   Private定数
'************************************************************************************
'ODBC APIを使用するための宣言
Declare Function SQLDataSources Lib "ODBC32.DLL" (ByVal henv&, ByVal fDirection%, ByVal szDSN$, ByVal cbDSNMax%, pcbDSN%, ByVal szDescription$, ByVal cbDescriptionMax%, pcbDescription%) As Integer
Declare Function SQLAllocEnv% Lib "ODBC32.DLL" (env&)
Public Const SQL_SUCCESS As Long = 0
Public Const SQL_FETCH_NEXT As Long = 1

Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Long, ByVal fRequest As Long, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Long
Public Const ODBC_ADD_DSN = 1                       'データ ソースの追加
Public Const ODBC_CONFIG_DSN = 2                    'データ ソースの編集
Public Const ODBC_REMOVE_DSN = 3                    'データ ソースの削除
'
Public Const SSS_PRINTER% = 1                       'プリンター出力
Public Const SSS_VIEW% = 2                          'ウインドウ出力
Public Const SSS_FILE% = 3                          'ファイル出力

Public SSS_CRWOPATH As String                       'ファイル出力時の出力先パス
Public SSS_Lconfig As String                        '"USR":クリスタルレポートのユーザー定義を優先する

Public SSS_OUTKB As Integer                         '実行時に以下のいずれかが設定される
                                                    '    SSS_PRINTER, SSS_VIEW, SSS_FILE
                                                    'ただし, エラーが発生したり, 実行中止されると 0 を返す

Public SSS_Makkb As Integer                         '出力準備区分

Public SSS_ExportFileName As String                 'Exportﾌｧｲﾙファイル名。デフォルトはプログラムＩＤ
Public SSS_ExportFileEXT As String                  'Exportﾌｧｲﾙの拡張子。デフォルトは"RPT"
Public SSS_ExportSep    As String                   '文字区切り文字（文字区切りフォーマットの場合のみ有効で、それ以外は "" で指定）
Public SSS_ExportQuat   As String                   '引用符（文字区切りフォーマットの場合のみ有効で、それ以外は "" で指定）
'
Public SSS_Hide_Prnbutton As Boolean                'プレビュー画面で、印刷ボタンを非表示(True)／表示(False)  デフォルト＝表示
Public SSS_Hide_Expbutton As Boolean                'プレビュー画面からエクスポート不可(True)／可(False)      デフォルト＝可
Public SSS_Hide_Prnset    As Boolean                'プレビュー画面で、プリンタの設定不可(True)／可(False)    デフォルト＝可
Public SSS_ShowProgress   As Boolean                '出力中進捗ダイアログ ボックス表示(True)／非表示(False)   デフォルト＝非表示
Public SSS_Copies         As Integer                '印刷部数
Public SSS_StartPageNo    As Integer                '最初のページ番号
Public SSS_StopPageNo     As Integer                '最終のページ番号
Public SSS_Collation      As Integer                '複数ページの帳票で、複数のコピーを印刷の場合、必ず指定する
                                                    '1 = ページ出力順序 1,2,3,1,2,3,1,2,3,....
                                                    '2 = ページ出力順序 1,1,1,2,2,2,3,3,3,....
            
Public SSS_Message As String                        '"該当データ無し"以外のメッセージを表示する

Public SSS_DefPaperSize As Integer                  '帳票毎のデフォールト用紙サイズ
Public SSS_DefPaperSizeNm As String                 '用紙サイズの表示名、例えば "A3"
Public SSS_DefOrient As Integer                     '帳票毎のデフォールト印字向き
Public SSS_DefOrientNm As String                    '帳票毎のデフォールト印字向きの表示名、"縦"又は"横"
Public gSelDM As DEVMODE                            'デフォールト印字設定用構造体

Public SSS_DYNASQL As Boolean                       'PR2系帳票でダイナミックなSQLを使用かしないか

'Constants using to calculate structure size constants
' --------------------------------------------------------------------
Global Const PE_BYTE_LEN = 1
Global Const PE_WORD_LEN = 2
Global Const PE_LONG_LEN = 4
Global Const PE_DOUBLE_LEN = 8
Global Const PE_UNCHANGED = -1
Global Const PE_UNCHANGED_COLOR = -2

Global Const PE_DLLVERSION% = &H400
Global Const PE_ENGINEVERSION% = &H400

Global Const PE_UNCOLLATED = 0
Global Const PE_COLLATED = 1
Global Const PE_DEFAULTCOLLATION = 2

' Open and close print engine
' ---------------------------
Declare Function PEOpenEngine Lib "crpe32.dll" () As Integer
Declare Sub PECloseEngine Lib "crpe32.dll" ()

' Get version info
' ----------------
Global Const PE_GV_DLL% = 100                       'values for version parameter of PEGetVersion
Global Const PE_GV_ENGINE% = 200

Declare Function PEGetVersion Lib "crpe32.dll" (ByVal Version%) As Integer

' Open and close print job (i.e. report)
' --------------------------------------
Declare Function PEOpenPrintJob Lib "crpe32.dll" (ByVal RptName$) As Integer
Declare Function PEClosePrintJob Lib "crpe32.dll" (ByVal printJob%) As Integer

' Start and cancel print job (i.e. print the report, usually after changing report)
' ---------------------------------------------------------------------------------
Declare Function PEStartPrintJob Lib "crpe32.dll" (ByVal printJob%, ByVal WaitOrNot%) As Integer
Declare Sub PECancelPrintJob Lib "crpe32.dll" (ByVal printJob%)
Declare Function PEGetWindowHandle Lib "crpe32.dll" (ByVal printJob%) As Long
Declare Sub PECloseWindow Lib "crpe32.dll" (ByVal printJob%)

' Print job status
' ----------------
Global Const PE_SIZEOF_JOB_INFO = 10 * PE_WORD_LEN + 4

Type T_PEJobInfo
    StructSize As Integer                           'initialize to # of bytes in PEJobInfo

    NumRecordsRead As Long
    NumRecordsSelected As Long
    NumRecordsPrinted As Long

    DisplayPageN As Integer
    LatestPageN As Integer
    StartPageN As Integer

    PrintEnded As Long
End Type

Type SplitPEJobInfo
    StructSize As Integer                           'initialize to PE_SIZEOF_JOB_INFO

    NumRecordsRead1 As Integer
    NumRecordsRead2 As Integer
    NumRecordsSelected1 As Integer
    NumRecordsSelected2 As Integer
    NumRecordsPrinted1 As Integer
    NumRecordsPrinted2 As Integer

    DisplayPageN As Integer
    LatestPageN As Integer
    StartPageN As Integer

    PrintEnded As Long
End Type

Declare Function RealPEGetJobStatus Lib "crpe32.dll" Alias "PEGetJobStatus" (ByVal printJob%, JobInfo As SplitPEJobInfo) As Integer

' Print job error codes and messages
' ----------------------------------
Declare Function PEGetErrorCode Lib "crpe32.dll" (ByVal printJob%) As Integer
Declare Function PEGetErrorText Lib "crpe32.dll" (ByVal printJob%, TextHandle As Long, TextLength%) As Integer
Declare Function PEGetHandleString Lib "crpe32.dll" (ByVal TextHandle As Long, ByVal Buffer$, ByVal BufferLength%) As Integer

' Controlling print to printer
' ----------------------------
Declare Function PEOutputToPrinter Lib "crpe32.dll" (ByVal printJob%, ByVal nCopies%) As Integer
Declare Function PEOutputToWindow Lib "crpe32.dll" (ByVal printJob%, ByVal Title$, ByVal Lft&, ByVal Top&, ByVal Wdth&, ByVal Height&, ByVal style&, ByVal PWindow&) As Integer

Global Const PE_DLL_NAME_LEN = 64
Global Const PE_FULL_NAME_LEN = 256
Global Const PE_SIZEOF_TABLE_TYPE = 324             '# bytes in PETableType

Type T_PEExportOptions
    StructSize As Integer                           'initialize to # bytes in PEExportOptions

    FormatDLLName As String * PE_DLL_NAME_LEN
    FormatType1 As Integer
    FormatType2 As Integer
    FormatOptions1 As Integer
    FormatOptions2 As Integer

    DestinationDLLName As String * PE_DLL_NAME_LEN
    DestinationType1 As Integer
    DestinationType2 As Integer
    DestinationOptions1 As Integer
    DestinationOptions2 As Integer

    ' following are set by PEGetExportOptions,
    ' and ignored by PEGetExportOptions
    NFormatOptionsBytes As Integer
    NDestinationOptionsBytes As Integer
End Type
Global Const PE_SIZEOF_EXPORT_OPTIONS = 11 * PE_WORD_LEN + 2 * PE_DLL_NAME_LEN

Declare Function PEGetExportOptions Lib "crpe32.dll" (ByVal printJob%, ExportOptions As T_PEExportOptions) As Integer
Declare Function PEExportTo Lib "crpe32.dll" (ByVal printJob%, ExportOptions As T_PEExportOptions) As Integer
Declare Function PEHasSavedData Lib "crpe32.dll" (ByVal printJob%, HasSavedData As Long) As Integer
Declare Function PEDiscardSavedData Lib "crpe32.dll" (ByVal printJob%) As Integer

' Changing printer selection
' --------------------------
'#Start(2003.11.16) CR9 Unicode 対応
'Declare Function PESelectPrinter Lib "crpe32.dll" (ByVal printJob%, ByVal PrinterDriver$, ByVal PrinterName$, ByVal PortName$, ByVal DEVMODE As Long) As Integer
Declare Function PESelectPrinter Lib "crpe32.dll" Alias "PESelectPrinterW" (ByVal printJob%, PriterDriver As Any, PrinterName As Any, PortName As Any, ByVal DEVMODE As Long) As Integer
'#End(2003.11.16)
Declare Function PEGetSelectedPrinter Lib "crpe32.dll" (ByVal printJob%, DriverHandle As Long, DriverLength%, PrinterHandle As Long, PrinterLength%, PortHandle As Long, PortLength%, ByVal DEVMODE As Long) As Integer

' Setting section height and format
' ---------------------------------
Declare Function reportExportX Lib "CrwTDLL.DLL" (ByVal printJob&, ByVal exportto$, ByVal toFormat&, ByVal toTarget&, ByVal sep$, ByVal quat$) As Long

' values for SectionCode parameter
' ---------------------------------
Global Const PE_ALLSECTIONS = 0
Global Const PE_TITLESECTION = 1000
Global Const PE_HEADERSECTION = 2000
Global Const PE_GROUPHEADER = 3000                  'outer group header is 3000, next is 3001, etc.
Global Const PE_DETAILSECTION = 4000
Global Const PE_GROUPFOOTER = 5000                  'outer group footer is 5000, next is 5001, etc.
Global Const PE_FOOTERSECTION = 7000
Global Const PE_SUMMARYSECTION = 8000
Global Const PE_GRANDTOTALSECTION = PE_SUMMARYSECTION
'
Type T_PESectionOptions
    StructSize          As Integer                  'initialize to # bytes in PESectionOptions

    ' use 0 to turn off, 1 to turn on and -1 to preserve each attribute
    Visible             As Integer
    NewPageBefore       As Integer
    NewPageAfter        As Integer
    KeepTogether        As Integer
    SuppressBlankLines  As Integer
    ResetPageNAfter     As Integer
    PrintAtBottomOfPage As Integer
    backgroundColor     As Long                     'Use PE_UNCHANGED_COLOR to preserve the existing color.
    underlaySection     As Integer
    showArea            As Integer
    freeFormPlacement   As Integer
    reserveMinimumPageFooter As Integer             'BOOLEAN or PE_UNCHANGED;
End Type

Declare Function PESetSectionFormat Lib "crpe32.dll" (ByVal printJob%, ByVal SectionCode%, Options As T_PESectionOptions) As Integer
Declare Function PEGetSectionFormat Lib "crpe32.dll" (ByVal printJob%, ByVal SectionCode%, Options As T_PESectionOptions) As Integer

'##テーブルロケーション情報
'--------------------------
Global Const PE_TABLE_LOCATION_LEN = 256
Global Const PE_CONNECTION_BUFFER_LEN = 512
Global Const PE_SIZEOF_TABLE_LOCATION = 1026        '# bytes in PETableLocation
Type T_PETableLocation
    ' initialize to # bytes in PETableLocation
    StructSize As Integer
    Location  As String * PE_TABLE_LOCATION_LEN
    SubLocation As String * PE_TABLE_LOCATION_LEN
    ConnectBuffer As String * PE_CONNECTION_BUFFER_LEN  'Connection Info for attached tables
End Type

Declare Function PEGetNTables Lib "crpe32.dll" (ByVal printJob%) As Integer
Declare Function PEGetNthTableLocation Lib "crpe32.dll" (ByVal printJob%, ByVal TableN%, Location As T_PETableLocation) As Integer
Declare Function PESetNthTableLocation Lib "crpe32.dll" (ByVal printJob%, ByVal TableN%, Location As T_PETableLocation) As Integer

'
Type T_FormatOptions
    StructSize As Integer
    useReportNumberFormat As Integer
    UseReportDateFormat As Integer
End Type
Global FormatOptions As T_FormatOptions
'
Type T_UXDDiskOptions
    StructSize As Integer
    fileName As String
End Type
Global UXDDiskOptions As T_UXDDiskOptions
'
'##Window Options
Type T_PEWindowOptions
    StructSize As Integer                           'initialize to PE_SIZEOF_WINDOW_OPTIONS

    hasGroupTree As Integer                         '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    canDrillDown As Integer                         '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasNavigationControls As Integer                '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasCancelButton As Integer                      '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasPrintButton As Integer                       '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasExportButton As Integer                      '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasZoomControl As Integer                       '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasCloseButton As Integer                       '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasProgressControls As Integer                  '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasSearchButton As Integer                      '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasPrintSetupButton As Integer                  '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    hasRefreshButton As Integer                     '表示(1)、非表示(0)、変更なし(PE_UNCHANGED)
    showToolbarTips As Integer                      'BOOL value, except use PE_UNCHANGED for no change
                                                    'default is TRUE (*Show* tooltips on toolbar)
    showDocumentTips As Integer                     'BOOL value, except use PE_UNCHANGED for no change
                                                    'default is FALSE (*Hide* tooltips on document)
    hasLaunchButton As Integer                      'Launch Seagate Analysis button on toolbar.
                                                    'BOOL value, except use PE_UNCHANGED for no change
                                                    'default is FALSE
End Type
Global Const PE_SIZEOF_WINDOW_OPTIONS = (16 * PE_WORD_LEN)
Declare Function PEGetWindowOptions Lib "crpe32.dll" (ByVal printJob%, Options As T_PEWindowOptions) As Integer
Declare Function PESetWindowOptions Lib "crpe32.dll" (ByVal printJob%, Options As T_PEWindowOptions) As Integer

'##Report Options
Type T_PEReportOptions
    StructSize As Integer
    saveDataWithReport As Integer
    saveSummariesWithReport As Integer
    useIndexForSpeed As Integer
    translateDOSStrings As Integer
    translateDosMemos As Integer
    convertDateTimeType As Integer
    convertNullFieldToDefault As Integer
    morePrintEngineErrorMessages As Integer
    caseInsensitiveSQLData As Integer
    verifyOnEveryPrint As Integer
    zoomMode As Integer
    hasGroupTree As Integer
    dontGenerateDataForHiddenObjects As Integer
    performGroupingOnServer As Integer
    doAsyncQuery As Integer
    promptMode As Integer
    SelectDistinctRecords As Integer
End Type
Global Const PE_SIZEOF_REPORT_OPTIONS = 18 * PE_WORD_LEN
Global Const PE_ZOOM_FULL_SIZE = 0                  '100%
Global Const PE_ZOOM_SIZE_FIT_ONE_SIDE = 1          '片一方に合わせ
Global Const PE_ZOOM_SIZE_FIT_BOTH_SIDES = 2        '画面両方に合わせ

Declare Function PEGetReportOptions Lib "crpe32.dll" (ByVal printJob%, reportOptions As T_PEReportOptions) As Integer
Declare Function PESetReportOptions Lib "crpe32.dll" (ByVal printJob%, reportOptions As T_PEReportOptions) As Integer
'
'##Print Options
Global Const PE_MAXPAGEN = 65535
Global Const PE_FILE_PATH_LEN = 512
Type T_PEPrintOptions
    StructSize As Integer                           'initialize to # bytes in PEPrintOptions
                                                    'page and copy numbers are 1-origin
                                                    'use 0 to preserve the existing settings
    StartPageN As Integer
    stopPageN As Integer
    nReportCopies As Integer
    collation As Integer
    outputFileName As String * PE_FILE_PATH_LEN
End Type
Global Const PE_SIZEOF_PRINT_OPTIONS = 5 * PE_WORD_LEN + PE_FILE_PATH_LEN
Declare Function PESetPrintOptions Lib "crpe32.dll" (ByVal printJob%, Options As T_PEPrintOptions) As Integer
Declare Function PEGetPrintOptions Lib "crpe32.dll" (ByVal printJob%, Options As T_PEPrintOptions) As Integer

'##
Global Const PE_JOBNOTSTARTED% = 1
Global Const PE_JOBINPROGRESS% = 2
Global Const PE_JOBCOMPLETED% = 3
Global Const PE_JOBFAILED% = 4
Global Const PE_JOBCANCELLED% = 5
Global Const PE_JOBHALTED = 6                       'too many records or too much time

Global Const PE_ERR_NOERROR = 0
Global Const PE_ERR_USERCANCELLED = 545

Global Const WS_MINIMIZE& = 536870912
Global Const WS_VISIBLE& = 268435456
Global Const WS_DISABLED& = 134217728
Global Const WS_CLIPSIBLINGS& = 67108864
Global Const WS_CLIPCHILDREN& = 33554432
Global Const WS_MAXIMIZE& = 16777216
Global Const WS_CAPTION& = 12582912
Global Const WS_BORDER& = 8388608
Global Const WS_DLGFRAME& = 4194304
Global Const WS_VSCROLL& = 2097152
Global Const WS_HSCROLL& = 1048576
Global Const WS_SYSMENU& = 524288
Global Const WS_THICKFRAME& = 262144
Global Const WS_MINIMIZEBOX& = 131072
Global Const WS_MAXIMIZEBOX& = 65536
Global Const CW_USEDEFAULT& = -32768

Global Const UXFCrystalReportType& = 0
Global Const UXFCommaSeparatedType& = 0
Global Const UXFTabSeparatedType& = 1
Global Const UXFTextType& = 0
Global Const UXFTabbedTextType& = 1
Global Const UXFXls4Type& = 2
Global Const UXFXls5Type& = 3
Global Const UXDDiskType& = 0

'##エクスポート・ファイルのタイプ
'--------------------------------
Global Const CRW_CommaSeparatedType% = 0            'ＣＳＶ
Global Const CRW_Xls5Type% = 1                      'Excel v5.0
Global Const CRW_CrystalReportType% = 2             'クリスタルレポート
Global Const CRW_RichTextType% = 9                  'リッチテキスト
Global Const CRW_TabSeparatedType% = 10             'タブ区切り
Global Const CRW_CharSeparatedType% = 11            '文字区切り
Global Const CRW_TextType% = 12                     'テキスト
Global Const CRW_TabbedTextType% = 14               'タブ区切りテキスト
Global Const CRW_Xls4Type% = 20                     'Excel v4.0

Global Const CRW_Visible% = -1                      '表示
Global Const CRW_Hide% = 0                          '非表示

Global HCRW As Integer                              'ｸﾘｽﾀﾙﾚﾎﾟｰﾄ･ﾌﾟﾘﾝﾄﾊﾝﾄﾞﾙ

'##ログオン情報
'--------------
Global Const PE_SERVERNAME_LEN = 128
Global Const PE_DATABASENAME_LEN = 128
Global Const PE_USERID_LEN = 128
Global Const PE_PASSWORD_LEN = 128
Global Const PE_SIZEOF_LOGON_INFO = 514             '# bytes in PELogOnInfo

Type T_PELogOnInfo
    'initialize to # bytes in PELogOnInfo
    StructSize As Integer
    ServerName As String * PE_SERVERNAME_LEN
    DatabaseName  As String * PE_DATABASENAME_LEN
    UserID As String * PE_USERID_LEN
    Password  As String * PE_PASSWORD_LEN
End Type
Global LogOnInfo As T_PELogOnInfo

Declare Function PEGetNthTableLogOnInfo Lib "crpe32.dll" (ByVal printJob%, ByVal TableN%, LogOnInfo As T_PELogOnInfo) As Integer
Declare Function PESetNthTableLogOnInfo Lib "crpe32.dll" (ByVal printJob%, ByVal TableN%, LogOnInfo As T_PELogOnInfo, ByVal Propagate%) As Integer
Declare Function PESetSelectionFormula Lib "crpe32.dll" (ByVal printJob%, ByVal formulaString$) As Integer

'##プリンター設定に関連部分
'--------------------------
Declare Function GetProfileString Lib "kernel32" Alias "GetProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long) As Long
'#Start(2003.11.16) CR9 Unicode 対応
'Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, pDefault As PRINTER_DEFAULTS) As Long
Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterW" (pPrinterName As Any, phPrinter As Long, pDefault As PRINTER_DEFAULTS) As Long
'#End(2003.11.16)
Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
'#Start(2003.11.16) CR9 Unicode 対応
'Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, ByVal pDeviceName As String, ByVal pDevModeOutput As Long, ByVal pDevModeInput As Long, ByVal fmode As Long) As Long
Declare Function DocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesW" (ByVal hwnd As Long, ByVal hPrinter As Long, pDeviceName As Any, ByVal pDevModeOutput As Long, ByVal pDevModeInput As Long, ByVal fmode As Long) As Long
'#End(2003.11.16)
Declare Function DeviceCapabilities Lib "winspool.drv" Alias "DeviceCapabilitiesA" (ByVal lpDeviceName As String, ByVal lpPort As String, ByVal iIndex As Long, ByVal lpOutput As String, ByVal lpDevMode As Long) As Long
Declare Function DeviceCapabilitiesNo Lib "winspool.drv" Alias "DeviceCapabilitiesA" (ByVal lpDeviceName As String, ByVal lpPort As String, ByVal iIndex As Long, ByVal lpOutput As Long, ByVal lpDevMode As Long) As Long
Declare Function agGetStringFromLPSTR$ Lib "SssAPI.dll" (ByVal src$)
Declare Function agGetAddressForObject& Lib "SssAPI.dll" (object As Any)
Declare Function agGetAddressForInteger& Lib "SssAPI.dll" Alias "agGetAddressForObject" (intnum%)
Declare Sub agCopyData Lib "SssAPI.dll" (Source As Any, dest As Any, ByVal nCount&)


'## 印刷中進捗ダイアログ ボックス表示／非表示に
Declare Function PEEnableProgressDialog Lib "crpe32.dll" (ByVal printJob%, ByVal enable%) As Integer

'  paper selections
Public Const DMPAPER_LETTER = 1
Public Const DMPAPER_FIRST = DMPAPER_LETTER
                                                    'Letter 8 1/2 x 11 in
Public Const DMPAPER_LETTERSMALL = 2                'Letter Small 8 1/2 x 11 in
Public Const DMPAPER_TABLOID = 3                    'Tabloid 11 x 17 in
Public Const DMPAPER_LEDGER = 4                     'Ledger 17 x 11 in
Public Const DMPAPER_LEGAL = 5                      'Legal 8 1/2 x 14 in
Public Const DMPAPER_STATEMENT = 6                  'Statement 5 1/2 x 8 1/2 in
Public Const DMPAPER_EXECUTIVE = 7                  'Executive 7 1/4 x 10 1/2 in
Public Const DMPAPER_A3 = 8                         'A3 297 x 420 mm
Public Const DMPAPER_A4 = 9                         'A4 210 x 297 mm
Public Const DMPAPER_A4SMALL = 10                   'A4 Small 210 x 297 mm
Public Const DMPAPER_A5 = 11                        'A5 148 x 210 mm
Public Const DMPAPER_B4 = 12                        'B4 250 x 354
Public Const DMPAPER_B5 = 13                        'B5 182 x 257 mm
Public Const DMPAPER_FOLIO = 14                     'Folio 8 1/2 x 13 in
Public Const DMPAPER_QUARTO = 15                    'Quarto 215 x 275 mm
Public Const DMPAPER_10X14 = 16                     '10x14 in
Public Const DMPAPER_11X17 = 17                     '11x17 in
Public Const DMPAPER_NOTE = 18                      'Note 8 1/2 x 11 in
Public Const DMPAPER_ENV_9 = 19                     'Envelope #9 3 7/8 x 8 7/8
Public Const DMPAPER_ENV_10 = 20                    'Envelope #10 4 1/8 x 9 1/2
Public Const DMPAPER_ENV_11 = 21                    'Envelope #11 4 1/2 x 10 3/8
Public Const DMPAPER_ENV_12 = 22                    'Envelope #12 4 \276 x 11
Public Const DMPAPER_ENV_14 = 23                    'Envelope #14 5 x 11 1/2
Public Const DMPAPER_CSHEET = 24                    'C size sheet
Public Const DMPAPER_DSHEET = 25                    'D size sheet
Public Const DMPAPER_ESHEET = 26                    'E size sheet
Public Const DMPAPER_ENV_DL = 27                    'Envelope DL 110 x 220mm
Public Const DMPAPER_ENV_C5 = 28                    'Envelope C5 162 x 229 mm
Public Const DMPAPER_ENV_C3 = 29                    'Envelope C3  324 x 458 mm
Public Const DMPAPER_ENV_C4 = 30                    'Envelope C4  229 x 324 mm
Public Const DMPAPER_ENV_C6 = 31                    'Envelope C6  114 x 162 mm
Public Const DMPAPER_ENV_C65 = 32                   'Envelope C65 114 x 229 mm
Public Const DMPAPER_ENV_B4 = 33                    'Envelope B4  250 x 353 mm
Public Const DMPAPER_ENV_B5 = 34                    'Envelope B5  176 x 250 mm
Public Const DMPAPER_ENV_B6 = 35                    'Envelope B6  176 x 125 mm
Public Const DMPAPER_ENV_ITALY = 36                 'Envelope 110 x 230 mm
Public Const DMPAPER_ENV_MONARCH = 37               'Envelope Monarch 3.875 x 7.5 in
Public Const DMPAPER_ENV_PERSONAL = 38              '6 3/4 Envelope 3 5/8 x 6 1/2 in
Public Const DMPAPER_FANFOLD_US = 39                'US Std Fanfold 14 7/8 x 11 in
Public Const DMPAPER_FANFOLD_STD_GERMAN = 40        'German Std Fanfold 8 1/2 x 12 in
Public Const DMPAPER_FANFOLD_LGL_GERMAN = 41        'German Legal Fanfold 8 1/2 x 13 in

Public Const DMPAPER_LAST = DMPAPER_FANFOLD_LGL_GERMAN

Public Const DMPAPER_USER = 256
Public Const DM_IN_PROMPT = 4
Public Const DM_IN_BUFFER = 8
Public Const DM_OUT_BUFFER = 2
Public Const DMORIENT_PORTRAIT = 1
Public Const DMORIENT_LANDSCAPE = 2
Public Const DM_YRESOLUTION = &H2000&
Public Const PRINTER_ACCESS_USE = &H8
Public Const PRINTER_ACCESS_ADMINISTER = &H4
Public Const DC_PAPERNAMES = 16
Public Const DC_PAPERS = 2
Public Const DC_BINS = 6
Public Const DC_BINNAMES = 12

'  デバイス名文字列のサイズ
'#Start(2003.11.16) CR9 Unicode 対応
'Public Const CCHDEVICENAME = 32
Public Const CCHDEVICENAME = 64
'#End(2003.11.16)
'  フォーム名文字列のサイズ
'#Start(2003.11.16) CR9 Unicode 対応
'Public Const CCHFORMNAME = 32
Public Const CCHFORMNAME = 64
'#End(2003.11.16)
Type DEVMODE
    dmDeviceName As String * CCHDEVICENAME
    dmSpecVersion As Integer
    dmDriverVersion As Integer
    dmSize As Integer
    dmDriverExtra As Integer
    dmFields As Long
    dmOrientation As Integer
    dmPaperSize As Integer
    dmPaperLength As Integer
    dmPaperWidth As Integer
    dmScale As Integer
    dmCopies As Integer
    dmDefaultSource As Integer
    dmPrintQuality As Integer
    dmColor As Integer
    dmDuplex As Integer
    dmYResolution As Integer
    dmTTOption As Integer
    dmCollate As Integer
    dmFormName As String * CCHFORMNAME
    dmUnusedPadding As Integer
    dmBitsPerPel As Integer
    dmPelsWidth As Long
    dmPelsHeight As Long
    dmDisplayFlags As Long
    dmDisplayFrequency As Long
    dmICMMethod As Long
    dmICMIntent As Long
    dmMediaType As Long
    dmDitherType As Long
    dmReserved1 As Long
    dmReserved2 As Long
'2000/10/19 １行変更　長いプリンタ名に対応
'    YOBI(1893) As Byte
    YOBI(1813) As Byte
'2000/10/19 １行追加　長いプリンタ名に対応
    LongDeviceName As String * 80
End Type

Type PRINTER_DEFAULTS
    PDATATYPE As String
    PDEVMODE As Long
    DESIREDACCESS As Long
End Type

Type SAVDEVMODE
    RPTID As String * 8
    dm As DEVMODE
End Type

Private strLSTID    As String           '印刷帳票ID

Private strPrtSeq    As String           '印刷帳票ID

' === 20061120 === UPDATE S - ACE)Nagasawa 権限の読み方の変更
'プレビュー画面でのボタンの表示／非表示
Private Const pv_intWindowButton_Visible    As Integer = 1          '表示
Private Const pv_intWindowButton_UnVisible  As Integer = 0          '非表示
' === 20061120 === UPDATE E -

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub GetPrtSeq
'   概要：  帳票用シーケンス取得処理
'   引数：　なし
'   戻値：　取得したシーケンス　異常終了の場合は空文字を返す
'   備考：  USR9への接続は呼び出し元で行うこと
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function GetPrtSeq() As String
    
'local variable +---------------+---------------+---------------+---------------
    Dim strSQL                  As String
    Dim Usr_Ody                 As U_Ody
    Dim strSeq                  As String
'execute -------+---------------+---------------+---------------+---------------
    
    GetPrtSeq = ""
    
    'SQL文の作成
    strSQL = ""
    strSQL = strSQL & " SELECT PRTSEQ.NEXTVAL PRTSEQ "
    strSQL = strSQL & " FROM DUAL "
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL)
    
    strSeq = CStr(CF_Ora_GetDyn(Usr_Ody, "PRTSEQ", 0))
    
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    
    GetPrtSeq = strSeq
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub DeleteListWk
'   概要：  ワークテーブル削除処理処理
'   引数：　pin_strTableName    : 削除対象テーブル名
'           pin_strPrtTanId     : 削除対象の出力担当者コード
'           pin_strPrtSeq       : 削除対象のＳＥＱ
'   戻値：　0 : 正常終了 2 : 引数エラー 9 : 異常終了
'   備考：  USR9への接続は呼び出し元で行うこと
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DeleteListWk(pin_strTableName As String, pin_strPrtTanId As String, pin_strPrtSeq As String) As Integer

'local variable +---------------+---------------+---------------+---------------
    Dim strSQL                  As String
    Dim bolRet                  As Boolean
'execute -------+---------------+---------------+---------------+---------------
    
    DeleteListWk = 9
    
    '引数チェック
    'テーブル名
    If pin_strTableName = "" Then
        DeleteListWk = 2
        Exit Function
    End If
    '出力担当者コード
    If pin_strPrtTanId = "" Then
        DeleteListWk = 2
        Exit Function
    End If
    'ＳＥＱ
    If pin_strPrtSeq = "" Then
        DeleteListWk = 2
        Exit Function
    End If
    
    'SQL生成
    strSQL = ""
    strSQL = strSQL & " DELETE "
    strSQL = strSQL & " FROM " & pin_strTableName
    strSQL = strSQL & " WHERE  "
    strSQL = strSQL & "     PRTTANID = '" & pin_strPrtTanId & "' "
    strSQL = strSQL & " AND PRTSEQ = '" & pin_strPrtSeq & "' "
    
    'SQL実行
    bolRet = CF_Ora_Execute(gv_Odb_USR9, strSQL)
    If Not bolRet Then
        Exit Function
    End If
    
    DeleteListWk = 0

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub OutPutList_Main
'   概要：  クリスタルレポート出力メイン処理
'   引数：　pin_strLSTKB    : リスト区分(1:プリンター出力 2:ウインドウ出力 3:ファイル出力)
'           pin_strLSTID    : 出力対象リストID
'           pin_strPrwName  : プレビュー画面名
'           pin_strPrtSEQ   : 出力対象ＳＥＱ
'           pin_ctlGAUGE    : 表示ガイド(コントロール)
'   戻値：　0 : 正常終了 1 : 他で印刷中 2 : キャンセル 3 : 該当データ無し 9 : 異常終了
'   備考：  ステータスバーの表示、ボタンの非表示等画面の編集は呼出元で行うこと
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'Public Function OutPutList_Main(ByVal pin_intLSTKB As Integer, _
'                                ByVal pin_strLSTID As String, _
'                                ByVal pin_strPrwName As String, _
'                                ByVal pin_strPrtSeq As String, _
'                                Optional ByRef pin_ctlGAUGE As SSPanel5 _
'                                ) As Integer
Public Function OutPutList_Main(ByVal pin_intLSTKB As Integer, _
                                ByVal pin_strLSTID As String, _
                                ByVal pin_strPrwName As String, _
                                ByVal pin_strPrtSeq As String _
                                ) As Integer

    Dim intRtn          As Integer
    Dim bolRtn          As Boolean
    Dim wkRptId$
    Dim wkWindowOption  As T_PEWindowOptions
    Dim wkPrintOption   As T_PEPrintOptions
    Dim wkTop%, wkLeft%, wkWidth%, wkHeight%
    Dim wkStr           As String * 128
    Dim Usr_Ody         As U_Ody
    Dim strSQL          As String
' === 20070307 === UPDATE S - ACE)Nagasawa
'    Dim intCnt          As Integer
    Dim intCnt          As Currency
' === 20070307 === UPDATE E -
    Dim ErrorMsg        As String
    Dim rtn             As Long
    
    On Error GoTo ERR_OutPutList_Main
    
    OutPutList_Main = 9
    ErrorMsg = ""
    
    strLSTID = pin_strLSTID
    strPrtSeq = pin_strPrtSeq
    
    ' クリスタルレポートのオープン
    If CRW_INIT() = False Then
        ErrorMsg = "ERROR CRW_INIT"
        GoTo ERR_OutPutList_Main
    Else
        ' レポート印刷準備
        If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & pin_strLSTID & ".RPT") = False Then
            ErrorMsg = "ERROR CRW_OPEN"
            GoTo ERR_OutPutList_Main
        End If
    End If

    If CRW_DOCHECK() = False Then
        MsgBox "他で印刷中の為、実行できません。", MB_ICONEXCLAMATION
        
        Call CRW_CLOSE
        
        OutPutList_Main = 1
        Exit Function
    End If
    
    SSS_LSTOP = False

    strSQL = ""
    strSQL = strSQL & " select count(*) as LISTCNT "
    strSQL = strSQL & "   from " & pin_strLSTID
    strSQL = strSQL & "  where RPTCLTID = '" & SSS_CLTID & "' "
'    strSQL = strSQL & "    and PRTSEQ   =  " & strPrtSeq & " "
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL)
    
    intCnt = CF_Ora_GetDyn(Usr_Ody, "LISTCNT", 0)
    
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    
    'キャンセル処理
    If SSS_LSTOP = True Then
        Call CRW_CLOSE
        OutPutList_Main = 2
        
        Exit Function
    End If

'    If IsMissing(pin_ctlGAUGE) = True Then
'        pin_ctlGAUGE.FloodPercent = 100
'    End If

    If intCnt = 0 Then
        OutPutList_Main = 3
    Else
        'ダイアログによりプリンタ切替えをされたものを再設定する。
        '専用帳票の場合クリスタルレポートのユーザー定義を優先する。
        If IsNull(SSS_Lconfig) Then SSS_Lconfig = ""
        If SSS_Lconfig <> "USR" Then Call CRW_SET_PRINTER
        
        Select Case pin_intLSTKB
            Case SSS_PRINTER
                bolRtn = CRW_PUTPRINTER()
                '印刷部数の指定
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
                'プレビュー画面のデフォルトサイズを指定
                intRtn = GetPrivateProfileString("REPORT", "CRW_LEFT", "", wkStr, 128, ByVal "SSSWIN.INI")
                If intRtn > 0 Then wkLeft = Int(Left$(wkStr, intRtn))
                intRtn = GetPrivateProfileString("REPORT", "CRW_TOP", "", wkStr, 128, ByVal "SSSWIN.INI")
                If intRtn > 0 Then wkTop = Int(Left$(wkStr, intRtn))
                intRtn = GetPrivateProfileString("REPORT", "CRW_HEIGHT", "", wkStr, 128, ByVal "SSSWIN.INI")
                If intRtn > 0 Then wkHeight = Int(Left$(wkStr, intRtn))
                intRtn = GetPrivateProfileString("REPORT", "CRW_WIDTH", "", wkStr, 128, ByVal "SSSWIN.INI")
                If intRtn > 0 Then wkWidth = Int(Left$(wkStr, intRtn))
                
                '正確性チェック
                If wkTop <= 0 Or wkTop >= Screen.Height / 15 Then wkTop = 0
                If wkLeft <= 0 Or wkLeft >= Screen.Width / 15 Then wkLeft = 0
                If wkWidth <= 0 Or wkWidth >= Screen.Width / 15 Then wkWidth = Screen.Width / 15
                If wkHeight <= 0 Or wkHeight >= Screen.Height / 15 Then wkHeight = Screen.Height / 15
                If wkLeft + wkWidth > Screen.Width / 15 Then wkWidth = Screen.Width / 15 - wkLeft
                If wkTop + wkHeight > Screen.Height / 15 Then wkHeight = Screen.Height / 15 - wkHeight
                
                'プレビュー画面設定
                intRtn = CRW_PUTWINDOW(CStr(FR_SSSMAIN.Caption) & "･ﾚﾎﾟｰﾄ", wkLeft, wkTop, wkWidth, wkHeight)
                
                'プレビュー画面でのボタン表示／非表示
                wkWindowOption.StructSize = PE_SIZEOF_WINDOW_OPTIONS
                intRtn = PEGetWindowOptions(HCRW, wkWindowOption)
' === 20061120 === UPDATE S - ACE)Nagasawa 権限の読み方の変更
'                wkWindowOption.hasPrintButton = IIf((SSS_Hide_Prnbutton), 0, 1)
'                wkWindowOption.hasExportButton = IIf((SSS_Hide_Expbutton), 0, 1)
'                wkWindowOption.hasPrintSetupButton = IIf((SSS_Hide_Prnset), 0, 1)
                
                '印刷ボタン、プリンタ設定ボタンの制御（表示／非表示）
                If Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_OK Then
                    '印刷権限有り
                    wkWindowOption.hasPrintButton = pv_intWindowButton_Visible
                    wkWindowOption.hasPrintSetupButton = pv_intWindowButton_Visible
                ElseIf Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_NG Then
                    '印刷権限無し
                    wkWindowOption.hasPrintButton = pv_intWindowButton_UnVisible
                    wkWindowOption.hasPrintSetupButton = pv_intWindowButton_UnVisible
                End If

                'ファイル出力権限
                If Inp_Inf.InpFILEAUTH = gc_strFILEAUTH_OK Then
                    'ファイル出力権限有り
                    wkWindowOption.hasExportButton = pv_intWindowButton_Visible
                ElseIf Inp_Inf.InpFILEAUTH = gc_strFILEAUTH_NG Then
                    'ファイル出力権限無し
                    wkWindowOption.hasExportButton = pv_intWindowButton_UnVisible
                End If
' === 20061120 === UPDATE E -
                intRtn = PESetWindowOptions(HCRW, wkWindowOption)
                
            Case SSS_FILE
                intRtn = CRW_SETEXPATR()
        End Select
        
        If intRtn = False Then
            ErrorMsg = "ERROR OutPutList_Main 出力先選択 RTN=[" & Str$(intRtn) & "]"
            GoTo ERR_OutPutList_Main
        End If
        
        If bolRtn = True Or intRtn = 1 Then
            DoEvents
            '印刷処理
            If CRW_PRINT() = False Then
                ErrorMsg = "ERROR OutPutList_Main CRW_PRINT"
                GoTo ERR_OutPutList_Main
            End If
            
            OutPutList_Main = 0
                
        ElseIf intRtn <> PE_ERR_USERCANCELLED Then
            'CRWでエラーが発生した場合
            intRtn = MsgBox("OutPutList_MainでCRWエラーが発生しました：[" & Str(intRtn) & "]")
            ErrorMsg = "ERROR OutPutList_Main 出力先選択 RTN=[" & Str$(intRtn) & "]"
            GoTo ERR_OutPutList_Main
        End If
        
        Do While CRW_VIEWCHECK()
            Call Sleep(200)
            DoEvents
        Loop
        
        DoEvents
    End If
    
    Call CRW_CLOSE
    
END_OutPutList_Main:
    Exit Function
    
ERR_OutPutList_Main:    '
    Call SSSWIN_LOGWRT(ErrorMsg)
    
    If DBSTAT <> 0 Then
        MsgBox "エラーログの書き込みエラー ! Windows を再起動してください"
    End If
    
    rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)

    GoTo END_OutPutList_Main

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_INIT
'   概要：  クリスタルレポート初期化
'   引数：  なし
'   戻値：　True : 正常終了　False : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CRW_INIT() As Boolean

    Dim rtn As Long
    Dim wkStr As String * 128
    Dim tmpStr As String

    CRW_INIT = False
    
    If PEGetVersion(PE_GV_DLL) < PE_DLLVERSION Then
        MsgBox "クリスタルレポートのバージョンが違います。(DLL) "
        Exit Function
    End If
    
    If PEGetVersion(PE_GV_ENGINE) < PE_ENGINEVERSION Then
        MsgBox "クリスタルレポートのバージョンが違います。(Engine)"
        Exit Function
    End If

    If PEOpenEngine() = False Then
        MsgBox "クリスタルレポートの開始に失敗しました。"
    End If

    CRW_INIT = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_OPEN
'   概要：  レポート印刷準備
'   引数：  ReportPath : 印刷対象レポートパス
'   戻値：　True : 正常終了　False : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_OPEN(ReportPath As String) As Boolean
    
    HCRW = PEOpenPrintJob(ReportPath)
    If HCRW = 0 Then
        MsgBox "CRW_OPEN.PEOpenPrintJob : " & CRW_GETERRMSG(HCRW)
        CRW_OPEN = False
    Else
        CRW_OPEN = True
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_DOCHECK
'   概要：  印刷処理可否判定
'   引数：  なし
'   戻値：　True : 正常終了　False : 異常終了
'   備考：
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
'   名称：  Function CRW_SET_PRINTER
'   概要：  プリンタ設定
'   引数：  なし
'   戻値：　True : 正常終了　False : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub CRW_SET_PRINTER()

    Dim PrinterName As String
    Dim UniDevice() As Byte
    Dim UniDriver() As Byte
    Dim UniPort() As Byte
    Dim DriverName As String
    Dim PortName As String
    Dim buf As String * 128
    Dim DriverHandle As Long
    Dim DriverLength As Integer
    Dim PrinterHandle As Long
    Dim PrinterLength As Integer
    Dim PortHandle As Long
    Dim PortLength As Integer
    Dim result As Integer
    Dim Mode As Long
    Dim dm As DEVMODE
    Dim I As Integer
    Dim dmOutBuf() As Byte

    If GetUsePrinter(dm) Then
        DriverName = "winspool"
        PortName = ""
        PrinterName = agGetStringFromLPSTR$(dm.LongDeviceName)
        UniDriver = "winspool" & Chr(0)
        UniPort = Chr(0)
        For I = 0 To Printers.count - 1
            If Printers(I).DeviceName = PrinterName Then
                UniDriver = Printers(I).DriverName & Chr(0)
                UniPort = Printers(I).Port & Chr(0)
                Exit For
            End If
        Next
        UniDevice = PrinterName & Chr(0)
        ReDim dmOutBuf(4096)
        agCopyData dm, dmOutBuf(0), Len(dm) - 80    '後ろに追加したプリンタ名の分を引く
        Call PESelectPrinter(HCRW, UniDriver(0), UniDevice(0), UniPort(0), agGetAddressForObject(dmOutBuf(0)))
    ElseIf HasDefaultSetting(SSS_PrgId) Then
        '帳票のデフォールト用紙サイズと印字向きが登録されている場合
        Call GetDevMode2(GetDefDevice2(), DM_OUT_BUFFER)
        DriverName = "winspool"
        PortName = ""
        PrinterName = agGetStringFromLPSTR$(gSelDM.LongDeviceName)
        UniDriver = "winspool" & Chr(0)
        UniPort = Chr(0)
        For I = 0 To Printers.count - 1
            If Printers(I).DeviceName = PrinterName Then
                UniDriver = Printers(I).DriverName & Chr(0)
                UniPort = Printers(I).Port & Chr(0)
                Exit For
            End If
        Next
        UniDevice = PrinterName & Chr(0)
        '#End(2003.11.16)
        'Default用紙ｻｲｽﾞ＝SSS_DefPaperSize
        'Default印字向き＝SSS_DefOrient
        gSelDM.dmOrientation = SSS_DefOrient
        gSelDM.dmPaperSize = SSS_DefPaperSize
        ReDim dmOutBuf(4096)
        agCopyData gSelDM, dmOutBuf(0), Len(gSelDM) - 80    '後ろに追加したプリンタ名の分を引く
        Call PESelectPrinter(HCRW, UniDriver(0), UniDevice(0), UniPort(0), agGetAddressForObject(dmOutBuf(0)))
    Else
        If PEGetSelectedPrinter(HCRW, DriverHandle, DriverLength, PrinterHandle, PrinterLength, PortHandle, PortLength, Mode) = 1 Then
            If PEGetHandleString(DriverHandle, buf, DriverLength) = 1 Then
                DriverName = LeftWid$(buf, DriverLength)
                If PEGetHandleString(PrinterHandle, buf, PrinterLength) = 1 Then
                    PrinterName = LeftWid$(buf, PrinterLength)
                    If PEGetHandleString(PortHandle, buf, PortLength) = 1 Then
                    PortName = LeftWid$(buf, PortLength)
                        If PESelectPrinter(HCRW, DriverName, PrinterName, PortName, 0) = 1 Then
                        End If
                    End If
                End If
            End If
        End If
    End If
End Sub

Private Function CRW_PUTPRINTER() As Boolean
    
    If PEOutputToPrinter(HCRW, SSS_Copies) = False Then
        If PEGetErrorCode(HCRW) = PE_ERR_NOERROR Then
            CRW_PUTPRINTER = True
        Else
            MsgBox "CRW_PUTPRINTER.PEOutputToPrinter : " & CRW_GETERRMSG(HCRW)
            CRW_PUTPRINTER = False
        End If
    Else
        CRW_PUTPRINTER = True
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_PUTWINDOW
'   概要：  出力先をウインドウに設定(プレビュー画面)
'   引数：  pin_strWHEDER : プレビュー画面タイトル
'           pin_intWLEFT  : 画面位置(横)
'           pin_intWTOP   : 画面高さ
'           pin_intWWIDTH : 画面幅
'           pin_intWHIGH  : 画面位置(縦)
'   戻値：　True : 正常終了　False : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_PUTWINDOW(ByVal pin_strWHEDER As String, _
                               ByVal pin_intWLEFT As Integer, _
                               ByVal pin_intWTOP As Integer, _
                               ByVal pin_intWWIDTH As Integer, _
                               ByVal pin_intWHIGH As Integer) As Boolean

    If PEOutputToWindow(HCRW, pin_strWHEDER, pin_intWLEFT, pin_intWTOP, pin_intWWIDTH, pin_intWHIGH, 0, 0) = False Then
        If PEGetErrorCode(HCRW) = PE_ERR_NOERROR Then
            CRW_PUTWINDOW = True
        Else
            MsgBox "CRW_PUTWINDOW.PEOutputToWindow : " & CRW_GETERRMSG(HCRW)
            CRW_PUTWINDOW = False
        End If
    Else
        CRW_PUTWINDOW = True
    End If
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_SETEXPATR
'   概要：  ファイル出力設定
'   引数：  なし
'   戻値：　0 : 正常終了　1 : 異常終了  545(PE_ERR_USERCANCELLED) : キャンセル
'   備考：　ユーザーによるキャンセル時は、PE_ERR_USERCANCELLED を返す。
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_SETEXPATR() As Integer

    Dim ExpOption As T_PEExportOptions

    CRW_SETEXPATR = False
    ExpOption.StructSize = PE_SIZEOF_EXPORT_OPTIONS
    
    If PEGetExportOptions(HCRW, ExpOption) = False Then
        If PEGetErrorCode(HCRW) = PE_ERR_USERCANCELLED Then
            CRW_SETEXPATR = PE_ERR_USERCANCELLED
        Else
            MsgBox "CRW_SETEXPATR.PEGetExportOptions : " & CRW_GETERRMSG(HCRW)
        End If
    Else
        If PEExportTo(HCRW, ExpOption) = False Then
            MsgBox "CRW_SETEXPATR.PEExportTo : " & CRW_GETERRMSG(HCRW)
        Else
            CRW_SETEXPATR = True
        End If
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_SETEXPATR
'   概要：  レポート出力処理
'   引数：  なし
'   戻値：　0 : 正常終了　1 : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_PRINT() As Integer

    Dim intRtn      As Integer
    Dim JINF        As T_PEJobInfo
    
    JINF.StructSize = PE_SIZEOF_JOB_INFO
    
    If CRW_DOCHECK() = False Then
        MsgBox "出力中の為、実行できません。", 48
        CRW_PRINT = False
        Exit Function
    End If
    
    intRtn = PEDiscardSavedData(HCRW)
    If intRtn = 0 Then
        MsgBox "PEDiscardSavedDataでエラーが発生しました。"
        CRW_PRINT = False
        Exit Function
    End If
    
    intRtn = Crw_ChgLocOra
    If intRtn = 0 Then
        MsgBox "CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW)
        CRW_PRINT = False
        Exit Function
    End If
    
    '印刷中進捗ダイアログボックス表示／非表示
    If SSS_ShowProgress Then   '表示
        intRtn = PEEnableProgressDialog(HCRW, True)
    Else
        intRtn = PEEnableProgressDialog(HCRW, False)
    End If
    
    'プレビュー画面のズームレベルを設定
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
                MsgBox "出力が取り消されました。"
                Call PECloseWindow(HCRW)
            Case Else
                MsgBox "CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW)
                CRW_PRINT = False
                Exit Function
        End Select
    Else
        intRtn = PEGetErrorCode(HCRW)
        MsgBox "CRW_PRINT.CRW_STATUS : " & intRtn & Chr(13) & CRW_GETERRMSG(HCRW)
        CRW_PRINT = False
        Exit Function
    End If
    CRW_PRINT = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_SETEXPATR
'   概要：  ORACLEワークデーターベース切替
'   引数：  なし
'   戻値：　0 : 正常終了　1 : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function Crw_ChgLocOra() As Boolean

    Dim rtn As Integer, usrNo As Integer
    Dim LogOnInfo As T_PELogOnInfo
    Dim TblLocation As T_PETableLocation
    Dim SSS_DBHEAD As String, CRW_DSN As String, wkStr As String * 128
    Dim newSelectionFormula As String
    Dim wkPassWord As String, wkUsr As String

    SSS_DBHEAD = Get_DBHEAD()

    rtn = GetPrivateProfileString("REPORT", "CRW_DSN_ORA", "", wkStr, 128, ByVal "SSSWIN.INI")
    If rtn = 0 Then rtn = GetPrivateProfileString("REPORT", "CRW_DSN", "", wkStr, 128, ByVal "SSSWIN.INI")
    If rtn > 0 Then CRW_DSN = Left$(wkStr, rtn)

    TblLocation.StructSize = PE_SIZEOF_TABLE_LOCATION
    
    'ログオン情報セット
    LogOnInfo.StructSize = PE_SIZEOF_LOGON_INFO
    LogOnInfo.ServerName = CRW_DSN + Chr$(0)
    LogOnInfo.DatabaseName = Get_DBHEAD & "_" & ORA_MAX_USR1 & Chr$(0)
    LogOnInfo.Password = ORA_MAX_PASS & Chr$(0)
    LogOnInfo.UserID = Get_DBHEAD & "_" & ORA_MAX_USR1 & Chr$(0)
    rtn = PESetNthTableLogOnInfo(HCRW, 0, LogOnInfo, False)
    If rtn = 0 Then
        Crw_ChgLocOra = False
        Exit Function
    End If
        newSelectionFormula = "{" & strLSTID & ".RPTCLTID} = '" & SSS_CLTID & "'"
        rtn = PESetSelectionFormula(HCRW, newSelectionFormula)
        If rtn <> 1 Then
            rtn = PEGetErrorCode(HCRW)
            MsgBox "Failed to Set SelectionFormula"
            Crw_ChgLocOra = False
            Exit Function
        End If
    Crw_ChgLocOra = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_VIEWCHECK
'   概要：  ﾋﾞｭｰｳｲﾝﾄﾞｳの表示状態チェック
'   引数：  なし
'   戻値：　0 : 正常終了　1 : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_VIEWCHECK() As Integer

    Dim wkHandle As Long
    
    wkHandle = PEGetWindowHandle(HCRW)
    If wkHandle <> 0 Then
        CRW_VIEWCHECK = 1
    Else
        CRW_VIEWCHECK = 0
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_CLOSE
'   概要：  プリントジョブを閉じる。
'   引数：  なし
'   戻値：　なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Sub CRW_CLOSE()

    Dim rtn As Integer

    rtn = PEClosePrintJob(HCRW)
    
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_END
'   概要：  クリスタルレポートエンジンを終了する。
'   引数：  なし
'   戻値：　なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub CRW_END()

    Call PECloseEngine
    
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CRW_END
'   概要：  エラーメッセージ取得
'   引数：  なし
'   戻値：　なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CRW_GETERRMSG(HPRN As Integer) As String

    Dim HTXT        As Long
    Dim TXTLEN      As Integer
    Dim ERRTEXT     As String * 128
    
    If PEGetErrorText(HPRN, HTXT, TXTLEN) = False Then
        CRW_GETERRMSG = "エラーメッセージの取得に失敗しました。"
    Else
        If PEGetHandleString(HTXT, ERRTEXT, TXTLEN) = False Then
            CRW_GETERRMSG = "エラーメッセージの取得に失敗しました。"
        Else
            CRW_GETERRMSG = ERRTEXT
        End If
    End If
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function PEGetJobStatus
'   概要：  ステータス取得
'   引数：
'   戻値：　取得されたステータス
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function PEGetJobStatus(ByVal job As Integer, Info As T_PEJobInfo) As Integer

    Dim splitinfo As SplitPEJobInfo
    Dim temp1 As Long
    Dim temp2 As Long
    
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
'   名称：  Function GetUsePrinter
'   概要：  セーブしたプリンタ情報を取り出す。
'   引数：
'   戻値：　True : 正常終了 False : 異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

Public Function GetUsePrinter(dm As DEVMODE) As Boolean

    Dim sdm As SAVDEVMODE
    Dim ws$
    Dim WL_RPTID As String * 8
    Dim Fno%
    Dim I%
    Dim found As Boolean
    
    On Error GoTo GetUsePrinter_Err
    
    GetUsePrinter = False
    ws = Dir(SSS_INIDAT(3) & "SSSPRN.CFG")
    If ws = "" Then Exit Function
    
' === 20060905 === UPDATE S - ACE)Nagasawa
'    WL_RPTID = strLSTID
    If Trim(SSS_RPTID) = "" Then
        WL_RPTID = SSS_PrgId
    Else
        WL_RPTID = SSS_RPTID
    End If
' === 20060905 === UPDATE E -
    
    Fno = FreeFile
    Open SSS_INIDAT(3) & "SSSPRN.CFG" For Random As Fno Len = Len(sdm)
    I = 1
    found = False
    Do
        Get Fno, I, sdm
        If EOF(Fno) Then Exit Do
        If Left(sdm.dm.LongDeviceName, 1) = Chr(0) Then
            sdm.dm.LongDeviceName = sdm.dm.dmDeviceName
        End If
        If sdm.RPTID = WL_RPTID Then
            dm = sdm.dm
            found = True
            GetUsePrinter = True
            Exit Do
        End If
        I = I + 1
    Loop
    Close Fno
    If found Then
        '用紙Nameによる用紙番号の置き換えを行う
        Dim devname$, devoutput$
        Dim count&
        Dim names$
        Dim a$
        Dim di&
        Dim NoBuf() As Byte
        Dim No%
        devname$ = agGetStringFromLPSTR$(dm.LongDeviceName)
        devoutput = ""
        ' 使用可能な用紙サイズを取得します。
        count = DeviceCapabilities(devname$, devoutput$, DC_PAPERNAMES, vbNullString, 0)
        If count <= 0 Then
            MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
            Exit Function
        End If
        ' 情報を保持できる十分な領域を確保します。
        names$ = String$(64 * count, 0)
        di = DeviceCapabilities(devname$, devoutput$, DC_PAPERNAMES, names$, 0)
        ' 使用可能な用紙サイズを取得します。
        count = DeviceCapabilitiesNo(devname$, devoutput$, DC_PAPERS, 0, 0)
        If count <= 0 Then
            MsgBox "使用可能な用紙サイズの情報が取得できません。", 0, "プリンタの設定"
            Exit Function
        End If
        ' 情報を保持できる十分な領域を確保します。
        ReDim NoBuf(2 * count)
        di = DeviceCapabilitiesNo(devname$, devoutput$, DC_PAPERS, agGetAddressForObject(NoBuf(0)), 0)
        ' 取得した情報を設定します。
        For I = 0 To count - 1
            No = NoBuf(I * 2) + NoBuf(I * 2 + 1) * 256
            a$ = MidWid(names$, I * 64 + 1, 64)
            a$ = agGetStringFromLPSTR$(a$)
            If a$ = agGetStringFromLPSTR$(dm.dmFormName) Then
                dm.dmPaperSize = No         '用紙サイズ番号を置き換え
                Exit For
            End If
        Next
    End If
    Exit Function

GetUsePrinter_Err:
    GetUsePrinter = False
    MsgBox SSS_INIDAT(3) & "SSSPRN.CFG" & " が読めません。"
    Exit Function
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Sub PutUsePrinter
'   概要：  プリンタ情報をセーブする。
'   引数：
'   戻値：
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub PutUsePrinter(dm As DEVMODE)

    Dim sdm As SAVDEVMODE
    Dim WL_RPTID As String * 8
    Dim Fno%
    Dim I%
    
    On Error GoTo PutUsePrinter_Err
    If Trim(SSS_RPTID) = "" Then
        WL_RPTID = SSS_PrgId
    Else
        WL_RPTID = SSS_RPTID
    End If
    Fno = FreeFile
    Open SSS_INIDAT(3) & "SSSPRN.CFG" For Random As Fno Len = Len(sdm)
    I = 1
    Do
        Get Fno, I, sdm
        If EOF(Fno) Or sdm.RPTID = WL_RPTID Then
            sdm.RPTID = WL_RPTID
            sdm.dm = dm
            Put Fno, I, sdm
            Exit Do
        End If
        I = I + 1
    Loop
    Close Fno
    Exit Sub

PutUsePrinter_Err:
    MsgBox SSS_INIDAT(3) & "SSSPRN.CFG" & " に書き込めません。"
    Exit Sub
End Sub


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'' 情報が登録されている場合は、次の情報をそれぞれセットされている
''   Default用紙サイズ→ SSS_DefPaperSize（0以外）
''   Default印字向き  → SSS_DefOrient（0以外）
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function HasDefaultSetting(vPrgid As String) As Boolean
    If SSS_DefPaperSize <> 0 And SSS_DefOrient <> 0 Then
        HasDefaultSetting = True
    Else
        HasDefaultSetting = False
    End If
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'' デフォールトプリンタ情報（DeviceName）を取得する
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function GetDefDevice2() As String
    Dim DEF$
    Dim di&
    Dim npos%

    DEF$ = String$(128, 0)
    di = GetProfileString("WINDOWS", "DEVICE", "", DEF$, 127)
    '#Start(2003.5.20) プリンタがインストールされていない場合ランタイムエラーを防ぐ
    If di = 0 Then
        MsgBox "このＰＣにはプリンタがインストールされていないようです。" & vbCr & "帳票プログラムの実行にはプリンタ(ドライバ)が必須です。" & vbCr & "インストールして下さい。" & vbCr & "――――――――――――――――――――――――――――――――" & vbCr & "プリンタ(ドライバ）がない場合は、正しく実行されない可能性があります。 ", vbExclamation
        GetDefDevice2 = ""
        Exit Function
    End If
    '#End(2003.5.20)
    DEF$ = agGetStringFromLPSTR$(DEF$)
    npos% = InStr(DEF$, ",")
    '#Start(2003.5.20) プリンタ名が127バイトを超える時のランタイムエラーを防ぐ
    If npos < 1 Then
        MsgBox "プリンタ名に異常があるようです。" & vbCr & "プリンタ名の長さが127バイト以内にして下さい。", vbExclamation
        GetDefDevice2 = ""
        Exit Function
    End If
    '#End(2003.5.20)
    GetDefDevice2 = Left$(DEF$, npos% - 1)
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'' 指定したデバイスの情報を取得し、グローバル構造体 gSelDM にセットする
'' 何から非常の場合は、セットされない
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub GetDevMode2(ByVal dv As String, ByVal fmode As Long)
    Dim hPrinter&, res&
    Dim pdefs As PRINTER_DEFAULTS
    Dim bufsize&
    Dim dmInBuf() As Byte
    Dim dmOutBuf() As Byte
    Dim UniDevice() As Byte
    
    UniDevice = dv & Chr(0)
    
    pdefs.PDATATYPE = vbNullString
    pdefs.PDEVMODE = 0
    pdefs.DESIREDACCESS = PRINTER_ACCESS_USE
    
    res& = OpenPrinter(UniDevice(0), hPrinter, pdefs)
        
    If res = 0 Then Exit Sub
    bufsize = DocumentProperties(FR_SSSMAIN.hwnd, hPrinter, UniDevice(0), 0, 0, 0)
        
    If bufsize < Len(gSelDM) Then bufsize = Len(gSelDM)
    ReDim dmInBuf(bufsize)
    ReDim dmOutBuf(bufsize)
    agCopyData gSelDM, dmInBuf(0), Len(gSelDM)
    
    res = DocumentProperties(FR_SSSMAIN.hwnd, hPrinter, UniDevice(0), agGetAddressForObject(dmOutBuf(0)), agGetAddressForObject(dmInBuf(0)), fmode)
    
    ' データバッファを DEVMODE 構造体へコピー
    If res = IDOK Then
        agCopyData dmOutBuf(0), gSelDM, Len(gSelDM)
        gSelDM.LongDeviceName = RTrim$(dv) & Chr(0)
    End If
    ClosePrinter hPrinter
End Sub
