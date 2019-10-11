Attribute VB_Name = "SSSWIN_BAS"
Option Explicit
'
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'#Start(2003.10.28)
'#Start(2003.4.22) PrintFormの代わりに、フォーム印刷を実装
'Public gSelectedPrinter As Printer
Public gSelectedDeviceName As String
Public gSelectedPapeSize As Integer
Public gSelectedOrientation As String

Private Type PALETTEENTRY
   peRed As Byte
   peGreen As Byte
   peBlue As Byte
   peFlags As Byte
End Type

Private Type LOGPALETTE
   palVersion As Integer
   palNumEntries As Integer
   palPalEntry(255) As PALETTEENTRY  ' Enough for 256 colors
End Type

Private Type GUID
   Data1 As Long
   Data2 As Integer
   Data3 As Integer
   Data4(7) As Byte
End Type

Private Const RASTERCAPS As Long = 38
Private Const RC_PALETTE As Long = &H100
Private Const SIZEPALETTE As Long = 104

Private Type RECT
   Left As Long
   Top As Long
   Right As Long
   Bottom As Long
End Type

Private Declare Function CreateCompatibleDC Lib "gdi32" ( _
   ByVal hdc As Long) As Long
Private Declare Function CreateCompatibleBitmap Lib "gdi32" ( _
   ByVal hdc As Long, ByVal nWidth As Long, _
   ByVal nHeight As Long) As Long
Private Declare Function GetDeviceCaps Lib "gdi32" ( _
   ByVal hdc As Long, ByVal iCapabilitiy As Long) As Long
Private Declare Function GetSystemPaletteEntries Lib "gdi32" ( _
   ByVal hdc As Long, ByVal wStartIndex As Long, _
   ByVal wNumEntries As Long, lpPaletteEntries As PALETTEENTRY) _
   As Long
Private Declare Function CreatePalette Lib "gdi32" ( _
   lpLogPalette As LOGPALETTE) As Long
Private Declare Function SelectObject Lib "gdi32" ( _
   ByVal hdc As Long, ByVal hObject As Long) As Long
Private Declare Function BitBlt Lib "gdi32" ( _
   ByVal hDCDest As Long, ByVal XDest As Long, _
   ByVal YDest As Long, ByVal nWidth As Long, _
   ByVal nHeight As Long, ByVal hDCSrc As Long, _
   ByVal XSrc As Long, ByVal YSrc As Long, ByVal dwRop As Long) _
   As Long
Private Declare Function DeleteDC Lib "gdi32" ( _
   ByVal hdc As Long) As Long
Private Declare Function GetForegroundWindow Lib "user32" () _
   As Long
Private Declare Function SelectPalette Lib "gdi32" ( _
   ByVal hdc As Long, ByVal hPalette As Long, _
   ByVal bForceBackground As Long) As Long
Private Declare Function RealizePalette Lib "gdi32" ( _
   ByVal hdc As Long) As Long
Private Declare Function GetWindowDC Lib "user32" ( _
   ByVal hwnd As Long) As Long
Private Declare Function GetDC Lib "user32" ( _
   ByVal hwnd As Long) As Long
Private Declare Function GetWindowRect Lib "user32" ( _
   ByVal hwnd As Long, lpRect As RECT) As Long
Private Declare Function ReleaseDC Lib "user32" ( _
   ByVal hwnd As Long, ByVal hdc As Long) As Long
Private Declare Function GetDesktopWindow Lib "user32" () As Long

Private Type PicBmp
   Size As Long
   Type As Long
   hBmp As Long
   hPal As Long
   Reserved As Long
End Type

Private Declare Function OleCreatePictureIndirect Lib "olepro32.dll" (PicDesc As PicBmp, RefIID As GUID, ByVal fPictureOwnsHandle As Long, IPic As IPicture) As Long
'#End(2003.4.22)
Private Const PRINTER_ACCESS_USE = &H8
Private Const DM_OUT_BUFFER = 2
Private Const BI_RGB = 0&
Private Const GMEM_MOVEABLE = &H2
Private Const DIB_RGB_COLORS = 0 '  color table in RGBs
Private Const HORZRES = 8            '  Horizontal width in pixels
Private Const VERTRES = 10           '  Vertical width in pixels
Private Const DMCOLOR_COLOR = 2
Private Type BITMAPINFOHEADER '40 bytes
        biSize As Long
        biWidth As Long
        biHeight As Long
        biPlanes As Integer
        biBitCount As Integer
        biCompression As Long
        biSizeImage As Long
        biXPelsPerMeter As Long
        biYPelsPerMeter As Long
        biClrUsed As Long
        biClrImportant As Long
End Type
Private Type BITMAPINFO '24Bit Color
        bmiHeader As BITMAPINFOHEADER
End Type
Private Type BITMAP '14 bytes
        bmType As Long
        bmWidth As Long
        bmHeight As Long
        bmWidthBytes As Long
        bmPlanes As Integer
        bmBitsPixel As Integer
        bmBits As Long
End Type
Private Type PRINTER_DEFAULTS
    PDATATYPE As String
    PDEVMODE As Long
    DESIREDACCESS As Long
End Type
Private Type sDEVMODE
    dmDeviceName As String * 32
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
    dmFormName As String * 32
    dmUnusedPadding As Integer
    dmBitsPerPel As Long
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
End Type
Private Type DOCINFO
        cbSize As Long
        lpszDocName As String
        lpszOutput As String
End Type
Private Declare Function GetObjectAPI Lib "gdi32" Alias "GetObjectA" (ByVal hObject As Long, ByVal nCount As Long, lpObject As Any) As Long
Private Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Long, ByVal dwBytes As Long) As Long
Private Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Function GlobalLock Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Function GlobalUnlock Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Function GetDIBits Lib "gdi32" (ByVal aHDC As Long, ByVal hBitmap As Long, ByVal nStartScan As Long, ByVal nNumScans As Long, lpBits As Any, lpBI As BITMAPINFO, ByVal wUsage As Long) As Long
Private Declare Function StretchDIBits Lib "gdi32" (ByVal hdc As Long, ByVal X As Long, ByVal Y As Long, ByVal dx As Long, ByVal dy As Long, ByVal SrcX As Long, ByVal SrcY As Long, ByVal wSrcWidth As Long, ByVal wSrcHeight As Long, lpBits As Any, lpBitsInfo As BITMAPINFO, ByVal wUsage As Long, ByVal dwRop As Long) As Long
Private Declare Function sOpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, pDefault As PRINTER_DEFAULTS) As Long
Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
Private Declare Function snDocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, ByVal pDeviceName As String, ByVal pnDevModeOutput As Long, ByVal pnDevModeInput As Long, ByVal fmode As Long) As Long
Private Declare Function sDocumentProperties Lib "winspool.drv" Alias "DocumentPropertiesA" (ByVal hwnd As Long, ByVal hPrinter As Long, ByVal pDeviceName As String, pDevModeOutput As Any, pDevModeInput As Any, ByVal fmode As Long) As Long
Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, lpInitData As Any) As Long
Private Declare Function StartDoc Lib "gdi32" Alias "StartDocA" (ByVal hdc As Long, lpdi As DOCINFO) As Long
Private Declare Function EndDocAPI Lib "gdi32" Alias "EndDoc" (ByVal hdc As Long) As Long
Private Declare Function StartPage Lib "gdi32" (ByVal hdc As Long) As Long
Private Declare Function EndPage Lib "gdi32" (ByVal hdc As Long) As Long
Private Declare Sub memcpy Lib "kernel32" Alias "RtlMoveMemory" (ByRef Dst As Any, ByRef src As Any, ByVal LENGTH As Long)
'#End(2003.10.28)

Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Long
Declare Function VBEXEC1 Lib "VBEXEC32" (ByVal hwnd As Long, ByVal kb As Long, ByVal prg As String) As Long
'=======================================
'ＳＳＳＷＩＮ．ＩＮＩ
'=======================================
'---------------------------------------------------------------
Dim SSS_INIDATNM(4) As String           'ＩＮＩのシンボル
Global SSS_INIDAT(4) As String          'ＩＮＩの内容
'SSS_INIDATNM(0) = "USR_PATH"           '開発環境PATH
'SSS_INIDATNM(1) = "DAT_PATH"           'データPATH
'SSS_INIDATNM(2) = "PRG_PATH"           'プログラムPATH
'SSS_INIDATNM(3) = "WRK_PATH"           'ワークPATH
'SSS_INIDATNM(4) = "IMGPATH"            'イメージPATH
'---------------------------------------------------------------

Global SSS_WRKDT(5) As String * 8


Global Set_date             As String * 10   'ｶﾚﾝﾀﾞｰWINDOW用
Global SSS_CLTID            As String * 5
Global SSS_OPEID            As String * 8
Global SSS_SMADT            As String * 8
Global SSS_SSADT            As String * 8
Global SSS_KESDT            As String * 8
Global SSS_ACNT             As Integer
Global SSS_SMFKB            As Currency
Global SSS_WLSLIST_KETA     As Integer       '簡易WINDOW用データ取得桁数
Global SSS_RTNWIN                            'ｳｲﾝﾄﾞｳからの返り値
Global SSS_MFIL             As Integer       'ﾒｲﾝﾌｧｲﾙ
Global SSS_MFILNM           As String        'ﾘｽﾄﾌｧｲﾙ名
Global SSS_MFILKEYNO        As Integer       'ﾒｲﾝﾌｧｲﾙｷｰ番号
Global SSS_MFILCNT          As Long          'ﾒｲﾝﾌｧｲﾙ読み込み件数
Global SSS_MFILTCNT         As Long          'ﾒｲﾝﾌｧｲﾙ総件数
Global SSS_RPTID            As String        'ｸﾘｽﾀﾙﾚﾎﾟｰﾄID
Global SSS_LSTMFIL          As Integer       '印刷ワークメインファイル番号
Global SSS_LSTMFILNM        As String        '印刷ワークメインファイル名
Global SSS_LFILCNT          As Long          '印刷用ファイル出力件数
Global SSS_LASTKEY          As String * 128  '画面表示用KEY
Global SSS_FASTKEY          As String * 128  '画面表示用KEY
Global SSS_LSTOP            As Integer       '印刷中断フラッグ（TRUE:中止）
Global SSS_ExportFLG        As Integer       'ファイル出力区分
Global SSS_ExportFileKB     As Integer       '出力ファイル作成区分
Global SSS_ExportFileType   As Integer       'ファイルタイプ区分
Global SSS_ExecuteFile(10)  As String        '実行チェーンファイル
Global SSS_UPDATEFL         As Integer       '更新可能フラグ
Global SSS_ExecuteMsgFL     As Integer       '更新時メッセージフラグ
Global SSS_BILFL            As Integer       'ビリング発行区分(1:発行/9:なし)
Global SSS_INICnt           As Integer       'INI ファイル最終インデックス
Global SSS_DeleteFl         As Integer       '削除実行フラグ  98/03/19
Global SSS_MainDe           As Integer       'Main 画面インデックス  98/03/19
Global SSS_VALKB            As Boolean       '有効データ区分(True=明細行なしでの登録可)
Global SSS_STRIPE_COLOR     As Long          'ストライプ色

Global Const SSS_ReTryCnt% = 100             'ログファイルオープンリトライカウント
'
Global Const SSS_OK% = 1                     'ウインドウにて使用
Global Const SSS_NEXT% = 2                   '
Global Const SSS_NPSN% = 3                   '
Global Const SSS_RPSN% = 4                   '
Global Const SSS_END% = 5                    '
Global Const SSS_SKIP% = 6                   '

Global Const SSS_STRIPE_ET = &HFFFFC0        '
Global Const SSS_STRIPE_DL = &HC0FFC0        '
Global Const SSS_STRIPE_MR = &HFFFFC0        '
Global Const SSS_STRIPE_MT = &HFFFFC0        '

Global SSS_ZEIRT(8)         As Currency      '消費税率（区分別配列）

'#Start(2003.3.28) ロングファイルネーム環境に対応
Global Const MAX_PATH = 260
'#End(2003.3.28)

'2001/04 時間測定用変数 → 所要時間測定用ルーチン(PutLogTime)で使用
Global SSS_SttTm
Global SSS_FinTm
Global TimeMode%

'2001/04 リードオンリーモード
Global SSS_ReadOnly%

'ファイル構造体初期化用データ
Type DB_CLRDAT
    FILLER As String * 2048      '初期化データ
End Type
Global DB_CLRREC As DB_CLRDAT

' 請求関係
Type TYPE_SME
    SMEDT As String
    KESDT As String
End Type
'
Dim SPSN As Integer
Type ITM_PKG
    ST As Integer
    ITM As String
End Type
Dim ITMPKG As ITM_PKG
'
Global SSS_MSTKB            As String * 1    'マスタ区分
Global Const MSTKB_TOKMTA$ = "1"             '  得意先マスタ区分
Global Const MSTKB_NHSMTA$ = "2"             '  納品先マスタ区分
Global Const MSTKB_TANMTA$ = "3"             '  担当者マスタ区分
Global Const MSTKB_SIRMTA$ = "4"             '  仕入先マスタ区分
Global Const MSTKB_HINMTA$ = "5"             '  商品マスタ区分
Global Const MSTKB_BMNMTA$ = "6"             '  部門マスタ区分
'
' eee モード
'
Global Const EEEMODE_APPEND% = 1    ' 追加
Global Const EEEMODE_SELECT% = 2    ' 選択
Global Const EEEMODE_INQUIRE% = 3   ' 問合せ
Global Const EEEMODE_UPDATE% = 4    ' 更新

' Function パラメータ
' MsgBox パラメータ
Global Const MB_OK = 0                 ' OK ボタンのみ
Global Const MB_OKCANCEL = 1           ' OK と ｷｬﾝｾﾙ ボタン
Global Const MB_ABORTRETRYIGNORE = 2   ' 中止, 再試行, 無視 ボタン
Global Const MB_YESNOCANCEL = 3        ' はい, いいえ, ｷｬﾝｾﾙ ボタン
Global Const MB_YESNO = 4              ' はい, いいえ ボタン
Global Const MB_RETRYCANCEL = 5        ' 再試行 と ｷｬﾝｾﾙ ボタン

Global Const MB_ICONSTOP = 16          ' 警告
Global Const MB_ICONQUESTION = 32      ' 確認
Global Const MB_ICONEXCLAMATION = 48   ' 注意
Global Const MB_ICONINFORMATION = 64   ' インフォメーションのアイコン

Global Const MB_APPLMODAL = 0          ' アプリケーション モーダル
Global Const MB_DEFBUTTON1 = 0         ' 第 1 ボタンをデフォルトにする
Global Const MB_DEFBUTTON2 = 256       ' 第 2 ボタンをデフォルトにする
Global Const MB_DEFBUTTON3 = 512       ' 第 3 ボタンをデフォルトにする
Global Const MB_SYSTEMMODAL = 4096     ' システム モード

' MsgKB メッセージ種別
Global Const SSS_GINFO$ = "9"          ' アイテムに対する説明
Global Const SSS_EEE$ = "0"            ' ｅｅｅのメッセージ
Global Const SSS_CONFRM$ = "1"         ' 確認メッセージ
Global Const SSS_ERROR$ = "2"          ' ＳＳＳエラーメッセージ
Global Const SSS_CINFO$ = "3"          ' ＳＳＳプロンプト表示
' MsgBox ボタンの戻り値
Global Const IDOK = 1                  ' OK ボタン
Global Const IDCANCEL = 2              ' ｷｬﾝｾﾙ ボタン
Global Const IDABORT = 3               ' 中止 ボタン
Global Const IDRETRY = 4               ' 再試行 ボタン
Global Const IDIGNORE = 5              ' 無視 ボタン
Global Const IDYES = 6                 ' はい ボタン
Global Const IDNO = 7                  ' いいえ ボタン

'[印刷] ダイアログ フラグ
Global Const PD_ALLPAGES = &H0&
Global Const PD_SELECTION = &H1&
Global Const PD_PAGENUMS = &H2&
Global Const PD_NOSELECTION = &H4&
Global Const PD_NOPAGENUMS = &H8&
Global Const PD_COLLATE = &H10&
Global Const PD_PRINTTOFILE = &H20&
Global Const PD_PRINTSETUP = &H40&
Global Const PD_NOWARNING = &H80&
Global Const PD_RETURNDC = &H100&
Global Const PD_RETURNIC = &H200&
Global Const PD_RETURNDEFAULT = &H400&
Global Const PD_SHOWHELP = &H800&
Global Const PD_USEDEVMODECOPIES = &H40000
Global Const PD_DISABLEPRINTTOFILE = &H80000
Global Const PD_HIDEPRINTTOFILE = &H100000
'
'
'==========================================================================
'   SYSTBE       運用ログ定義体                                           =
'==========================================================================
Type TYPE_DB_SYSTBE
    PRGID          As String * 8     'プログラムID          X(8)
    LOGNM          As String * 60    '備考(ｴﾗｰ情報・運用)   X(60)
    OPEID          As String * 8     '最終作業者コード      X(8)
    CLTID          As String * 5     'クライアントＩＤ      X(05)
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ（時間）      9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ（日付）      9(08)
End Type
Global DB_SYSTBE As TYPE_DB_SYSTBE
Global DBN_SYSTBE As Integer

'==========================================================================
'   LINK_IN,OUT   連携レコード定義体                                      =
'==========================================================================
Type TYPE_LINK
    DENNO          As String * 8     '伝票番号          X(8)
    DENDT          As String * 8     '伝票日付          X(8)
    TOKCD          As String * 6     '得意先CD          X(6)
    SIRCD          As String * 6     '仕入先CD          X(6)
    NHSCD          As String * 6     '納品先CD          X(6)
    BMNCD          As String * 6     '部門CD            X(6)
    HINCD          As String * 16    '商品CD            X(16)
    SOUCD          As String * 3     '倉庫ｺｰﾄﾞ          X(3)
    FILLER         As String * 41
End Type
Global Link_IN As TYPE_LINK
Global Link_OUT As TYPE_LINK
'
Type TYPE_LINK_CLR
    FILLER         As String * 100
End Type
Global Link_Clr As TYPE_LINK_CLR
'
Global Link_ON As Integer            'プログラムリンク判定用フラグ
Global Link_Index As Integer         'プログラムリンク用インデックス

''2001/06/11 画面圧縮機能
Private Type TYPE_BAR
    ctr         As Control          ' バーコントロール
    iBarCnt     As Integer          ' バー格納コントロール数
    ctrBars()   As Control          ' バー格納コントロール
End Type

Private Type TYPE_RELINFO
    ctr         As Control          ' 隣接コントロール
    bJstFg      As Boolean          ' 左隣接=底辺、下隣接=左辺と一致
End Type

Private Type TYPE_CTRLINFO
    nLeft       As Long             ' Left値
    nTop        As Long             ' Top値
    nHeight     As Long             ' Height値
    nWidth      As Long             ' Width値
    ctr         As Control          ' コントロール
    iLeftCnt    As Integer          ' 左隣接コントロール数
    tLefts()    As TYPE_RELINFO     ' 左隣接コントロール
    iDownCnt    As Integer          ' 下隣接コントロール数
    tDowns()    As TYPE_RELINFO     ' 下隣接コントロール
End Type

Private Type TYPE_CTRLGRP
    sGrpNm      As String           ' コンテナグループ名
    iCtrCnt     As Integer          ' コントロール数
    tCtrs()     As TYPE_CTRLINFO    ' コントロール情報
End Type
Public gs_kengen As String
Public gs_ari As String
Public gs_userid As String
Public gs_pgid   As String
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
Public Function Get_Authority(ec_DATE As String, Optional ec_CRW As Control) As String

'変数宣言
Dim ls_sql  As String
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
ls_sql = ls_sql & "   AND T.TANCD   = '" & SSS_OPEID & "'"
ls_sql = ls_sql & "   AND T.DATKB   = '1'"

'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
Call DB_GetSQL2(DBN_KNGMTB, ls_sql)

If DBSTAT <> 0 Then
    '取得データなしの場合は権限なしとみなす。
    Get_Authority = 9
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
    Get_Authority = 1
End If

If ec_CRW Is Nothing Then
Else
    If gs_PRTAUTH = "1" Then
        '印刷権限がある場合
        ec_CRW.WindowShowPrintBtn = True    '印刷ボタン
    Else
        '印刷権限が無い場合
        ec_CRW.WindowShowPrintBtn = False   '印刷ボタン
    End If
    If gs_FILEAUTH = "1" Then
        'エクスポート権限がある場合
        ec_CRW.WindowShowExportBtn = True   'エクスポートボタン
    Else
        'エクスポート権限が無い場合
        ec_CRW.WindowShowExportBtn = False  'エクスポートボタン
    End If
End If

End Function






''
'
Function Get_SMEDT1(ByVal psmedd As Integer, ByVal psmecc As Integer, ByVal pdendt As String, ByVal pnext As Integer) As String
' 請求締日算出（日）  締初期日付／締サイクル／伝票日付／帳端区分
Dim dd As Integer, mm As Integer, yy As Integer
Dim cnt As Integer, I As Integer
Dim setidx As Integer, idx As Integer, addMM As Integer
ReDim smeday(15) As Integer
    '
    yy = Year(pdendt)
    mm = Month(pdendt)
    dd = Day(pdendt)
    '
    If psmecc = 1 Then         '毎日締め
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
        Get_Acedt = CStr(DateSerial(Year(wdate), Month(wdate) + 1, 0))
    ElseIf Right$(wdate, 2) <= DB_SYSTBA.SMADD Then
        Get_Acedt = Left$(wdate, 8) & DB_SYSTBA.SMADD
    Else
        Get_Acedt = CStr(DateSerial(Year(wdate), Month(wdate) + 1, SSSVal(DB_SYSTBA.SMADD)))
    End If
End Function

Function Get_STTSMEDT1(ByVal psmedd As Integer, ByVal psmecc As Integer, ByVal pdendt As String) As String
' 請求開始日付算出（日）  締初期日付／締サイクル／伝票日付
Dim dd As Integer, mm As Integer, yy As Integer
Dim cnt As Integer, I As Integer
Dim setidx As Integer, idx As Integer, addMM As Integer
ReDim smeday(15) As Integer
    '
    yy = Year(pdendt)
    mm = Month(pdendt)
    dd = Day(pdendt)
    '
    If psmecc = 1 Then         '毎日締め
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

Function CHECK_DATE(ByVal DT) As Integer
' 日付の汎用チェック（２０５０年まで有効）
'
    On Error GoTo ErrDate
    If IsDate(DT) And Year(DT) <= 2050 And Year(DT) >= 1900 Then
        CHECK_DATE = True
    Else
ErrDate:
        CHECK_DATE = False
    End If
End Function

Sub Clr_Prompt(PP As clsPP)
' SSS/Win で表示したプロンプトメッセージを消します。
    '
    Call AE_StatusClear(PP, Cn_WHITE)
End Sub

Function CNV_DATE(pdate As String) As String
'
    If LenWid(pdate) = 8 Then
        CNV_DATE = LeftWid$(pdate, 4) & "/" & MidWid$(pdate, 5, 2) & "/" & RightWid$(pdate, 2)
    ElseIf LenWid(pdate) = 6 Then
        CNV_DATE = LeftWid$(pdate, 2) & "/" & MidWid$(pdate, 3, 2) & "/" & RightWid$(pdate, 2)
    Else
        CNV_DATE = ""
    End If
End Function

Function DCMFRC(IN_SU As Currency, MARUME As Currency, KETA As Currency) As Currency
'  IN_SU:被編集数値, MARUME:まるめパラメータ
'  KETA:まるめる桁位置(少数第1位が0 少数第2位が-1 整数1の位が1 整数2の位が2)
     Dim WL_KETA@, WL_MARUME@, WL_SU@
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

Function DeCNV_DATE(pdate As String) As String
    '
    If LenWid(pdate) = 10 Then
        DeCNV_DATE = LeftWid$(pdate, 4) & MidWid$(pdate, 6, 2) & RightWid$(pdate, 2)
    ElseIf LenWid(pdate) = 8 Then
        DeCNV_DATE = LeftWid$(pdate, 2) & MidWid$(pdate, 4, 2) & RightWid$(pdate, 2)
    Else
        DeCNV_DATE = ""
    End If
End Function

Function DSP_MsgBox(MSGKB As String, msgName As String, MSGSQ As Integer) As Integer
    '[V4.1]　メッセージ出力時にPPを退避　以下追加
    '※メイン画面からのメッセ-ジ出力のみ対応。サブ画面未対応。
    Dim WK_PP As clsPP
    WK_PP = PP_SSSMAIN
    '[V4.1]　メッセージ出力時にPPを退避　以上追加
' SSS/Win 共通のメッセージを表示します。
    '
    ''Close後はメッセージを表示しない
    If RsOpened(DBN_SYSTBH) = False Then Exit Function
    ''
    DB_SYSTBH.MSGNM = msgName
    Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
    If DBSTAT = 0 Then
        DSP_MsgBox = MsgBox(Trim$(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
    Else
        MsgBox "メッセージファイルエラー  " & Chr(13) & Chr(13) & "DBSTAT=" & Format$(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & Format$(MSGSQ, "0"), MB_OK, Trim$(SSS_PrgNm)
        Call Error_Exit("メッセージファイルエラー!")
    End If
    '[V4.1]　メッセージ出力時にPPを退避　以下追加
    PP_SSSMAIN = WK_PP
    '[V4.1]　メッセージ出力時にPPを退避　以上追加
End Function

Sub Dsp_Prompt(msgName As String, MSGSQ As Integer, Optional vForm As Variant)
Dim COLCD As Long
    '
    DB_SYSTBH.MSGNM = msgName
    Call DB_GetEq(DBN_SYSTBH, 1, SSS_CINFO & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
    If DBSTAT = 0 Then
        Select Case DB_SYSTBH.COLSQ
            Case "1"
                COLCD = Cn_BLACK
            Case "2"
                COLCD = Cn_RED
            Case "3"
                COLCD = Cn_GREEN
            Case "4"
                COLCD = Cn_YELLOW
            Case "5"
                COLCD = Cn_BLUE
            Case "6"
                COLCD = Cn_MAGENTA
            Case "7"
                COLCD = Cn_CYAN
            Case "8"
                COLCD = Cn_WHITE
        End Select
        If IsMissing(vForm) Then
            FR_SSSMAIN!TX_Message.Text = DB_SYSTBH.MSGCM
            FR_SSSMAIN!TX_Message.ForeColor = COLCD
        Else
            Dim wForm As Form
            Set wForm = vForm
            wForm!TX_Message.Text = DB_SYSTBH.MSGCM
            wForm!TX_Message.ForeColor = COLCD
        End If
    End If
End Sub

Function Dsp_PromptGen(msgName As String, MSGSQ As Integer) As String
' 標準ジェネレートメッセージの表示
    '
    DB_SYSTBH.MSGNM = msgName
    Call DB_GetEq(DBN_SYSTBH, 1, SSS_GINFO & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
    If DBSTAT = 0 Then
        Dsp_PromptGen = Trim$(DB_SYSTBH.MSGCM)
    Else
        Call Error_Exit("メッセージファイルエラー!")
    End If
End Function

Sub Error_Exit(ByVal ErrorMsg As String)
Dim rtn, I As Integer
    '
    Call SSSWIN_LOGWRT(ErrorMsg)
    MsgBox "プログラムを終了します。", MB_OK, Trim$(SSS_PrgNm)
    '
    If DBSTAT <> 0 Then
        MsgBox "エラーログの書き込みエラー ! Windows を再起動してください"
    '
    Else
        For I = SSS_MAX_DB - 1 To 0 Step -1
            Call DB_NCCLOSE(I)
        Next I
    End If
    Call DB_End
    rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
    End
End Sub

Function FillVal(ByVal ch As String, ByVal cnt As Integer) As Variant
' 指定された文字を指定回数分連結する。
Dim I As Integer, rtn As String
    '
    For I = 1 To cnt
        rtn = rtn & ch
    Next I
    FillVal = rtn
End Function

Function Get_BGNAcedt(ByVal yy As Integer, ByVal mm As Integer) As String
' 当期開始日付
Dim wdate As String, acedt As String
ReDim mmdd(1) As String
    '
    wdate = Format$(yy, "0000") & "/" & Format$(mm, "00") & "/01"
    If Not CHECK_DATE(wdate) Then
        Call Error_Exit("日付エラー(Get_BGNAcedt): " & yy & mm)
    End If
    acedt = Get_STTTouAcedt(yy, mm)
    mmdd(1) = RightWid$(acedt, 5)
    mmdd(0) = RightWid$(CStr(DateSerial(1995, SSSVal(DB_SYSTBA.SMAMM), SSSVal(DB_SYSTBA.SMADD) + 1)), 5)
    '
    If mmdd(0) > mmdd(1) Then
        Get_BGNAcedt = Format$(Year(acedt) - 1, "0000") & "/" & mmdd(0)
    Else
        Get_BGNAcedt = Format$(Year(acedt), "0000") & "/" & mmdd(0)
    End If
End Function

Function Get_KESDT1(ByVal psmedd As Integer, ByVal psmecc As Integer, ByVal pkesmm As Integer, ByVal pkesdd As Integer, ByVal pdate As String) As String
' 回収日付算出（日）  締初期日付／締サイクル／回収サイクル／回収日／今回締日
Dim dd As Integer
    '
    If psmecc = 1 Then
        Get_KESDT1 = pdate
        Exit Function
    End If
    '
    If pkesdd = 99 Then pkesdd = 30
    If pkesdd > 27 Then
        Get_KESDT1 = CStr(DateSerial(Year(pdate), Month(pdate) + pkesmm + 1, 0))
    Else
        Get_KESDT1 = CStr(DateSerial(Year(pdate), Month(pdate) + pkesmm, pkesdd))
    End If
End Function

Function Get_KESDT2(ByVal psmedd As Integer, ByVal pkesmm As Integer, ByVal pkesdd As Integer, ByVal pdate As String) As String
' 回収日付算出（曜日）  締初期日付／回収サイクル／回収日／伝票日付
    '
    Get_KESDT2 = CStr(DateSerial(Year(pdate), Month(pdate), Day(pdate) + pkesmm * 7 + pkesdd - psmedd))
End Function

Function Get_SMEDT2(ByVal psdwkb As Integer, pdate As String, pnext As Integer) As String
' 請求締日付算出（曜日）
    '
    If Weekday(pdate) > psdwkb Then
        Get_SMEDT2 = CStr(DateSerial(Year(pdate), Month(pdate), Day(pdate) + (7 - Weekday(pdate) + psdwkb) + (7 * pnext)))
    Else
        Get_SMEDT2 = CStr(DateSerial(Year(pdate), Month(pdate), Day(pdate) + (psdwkb - Weekday(pdate)) + (7 * pnext)))
    End If
End Function

Function Get_STTTouAcedt(ByVal yy As Integer, ByVal mm As Integer) As String
'当月経理開始日付
Dim wdate As String
    '
    wdate = Format$(yy, "0000") & "/" & Format$(mm, "00") & "/01"
    If Not CHECK_DATE(wdate) Then
        Call Error_Exit("日付エラー(Get_STTTouAcedt): " & yy & mm)
    End If
    If DB_SYSTBA.SMADD > "27" Then
        Get_STTTouAcedt = LeftWid$(wdate, 8) & "01"
    Else
        Get_STTTouAcedt = CStr(DateSerial(Year(wdate), Month(wdate) - 1, SSSVal(DB_SYSTBA.SMADD) + 1))
    End If
End Function

Function Get_TouAcedt(ByVal yy As Integer, ByVal mm As Integer) As String
' 当月経理締日付
Dim wdate As String
    '
    wdate = Format$(yy, "0000") & "/" & Format$(mm, "00") & "/01"
    If Not CHECK_DATE(wdate) Then
        Call Error_Exit("日付エラー(Get_TouAcedt): " & yy & mm)
    End If
    If DB_SYSTBA.SMADD > "27" Then
        Get_TouAcedt = CStr(DateSerial(Year(wdate), Month(wdate) + 1, 0))
    Else
        Get_TouAcedt = Left$(wdate, 8) & DB_SYSTBA.SMADD
    End If
End Function

Function HighValue(cnt As Integer) As String
    HighValue = String$(cnt, Chr$(122))
End Function

Sub Init_Prompt()
' プロンプト表示領域を初期化します。
    '
    FR_SSSMAIN!IM_Denkyu(0).Picture = FR_SSSMAIN!IM_Denkyu(1).Picture
    FR_SSSMAIN!TX_Message.Text = ""
    FR_SSSMAIN!TX_Message.ForeColor = &H0&
End Sub

Function JSTDT$(ByVal IN_DT$)
    Dim FormatDate$, yy@, mm@, dd@, I@

    yy = SSSVal(LeftWid$(IN_DT, 4))
    mm = SSSVal(MidWid$(IN_DT, 5, 2))
    dd = SSSVal(MidWid$(IN_DT, 7, 2))
    If dd > 27 Then
        dd = 0
        I = 31
        Do While (I > 27) And (dd = 0)
            FormatDate = Format$(yy, "0000") + "/" + Format$(mm, "00") + "/" + Format$(I, "00")
            If IsDate(FormatDate) Then
                dd = I
            End If
            I = I - 1
        Loop
    End If
    JSTDT = Format$(yy * 10000 + mm * 100 + dd, "00000000")
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
Function Link_Modal(ByVal EXE_NM$) As Integer
Dim Rtc, Full_Nm$
    On Error Resume Next
    LSet Link_Clr = Link_OUT
    Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & SSS_CLTID & SSS_OPEID & ":" & Link_Clr.FILLER & Chr(34)
    Link_Modal = VBEXEC1(FR_SSSMAIN.hwnd, 1, Full_Nm)
    LSet Link_Clr = Link_IN
End Function

Function Link_Shell(ByVal EXE_NM$) As Integer
Dim Rtc%, Full_Nm$
    On Error Resume Next
    LSet Link_Clr = Link_OUT
    Full_Nm = SSS_INIDAT(2) & "EXE\" & EXE_NM & " " & Chr(34) & LeftWid(SSS_CLTID, 5) & LeftWid(SSS_OPEID, 8) & ":" & Link_Clr.FILLER & Chr(34)
    Link_Shell = Shell(Full_Nm, 1)
    LSet Link_Clr = Link_IN
    If Link_ON Then   'メニュー起動でない場合には終了する
        SSS_NoMsg_EXIT
    End If
End Function

Function SSS_EDTITM_EEE(CP As clsCP, ByVal Item, ByVal De)
Dim WrkStr
    On Error GoTo ErrEdit
    WrkStr = IIf(Item = 0, Empty, FormatAndRound(Item, CP.FormatChr))
    If LenWid(WrkStr) > CP.MaxLength Then
        If CP.KeyInOkClass = Asc("C") Then
ErrEdit:
            SSS_EDTITM_EEE = String(CP.MaxLength, "*")
        Else
            SSS_EDTITM_EEE = RightWid$(WrkStr, CP.MaxLength)
        End If
    Else
        SSS_EDTITM_EEE = WrkStr
    End If
End Function

Function SSS_EDTITM_WLS(ByVal Item, ByVal KETA, ByVal HENSYU) As String
    Select Case HENSYU
        Case "0"
            SSS_EDTITM_WLS = RightWid$(FormatAndRound(Item, "00000000000000000000"), KETA)
        Case Else
            SSS_EDTITM_WLS = Item
    End Select
End Function

Function SSS_GETITM(TStr As String, DChar As String, ItmNo As Integer) As String
Dim I As Integer
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

Sub SSS_GETITMS(TStr As String, DChar As String)
Dim L As Integer, EPSN As Integer
    '
    EPSN = InStr(SPSN, TStr, DChar)
    If EPSN = 0 Then
        L = LenWid(TStr)
        If SPSN <= L Then
            ITMPKG.ST = True
            ITMPKG.ITM = MidWid$(TStr, SPSN, (L - SPSN + 1))
            SPSN = L + 1
        Else
            ITMPKG.ST = False
            ITMPKG.ITM = ""
        End If
    Else
        ITMPKG.ST = True
        ITMPKG.ITM = MidWid$(TStr, SPSN, (EPSN - SPSN))
        SPSN = EPSN + 1
    End If
End Sub

Function SSS_UPLCHAR(ByVal VST As String) As String
' 引数の最後文字のアスキー値を繰り上げる
    If VST = HighValue(LenWid(VST)) Then
        SSS_UPLCHAR = VST
    Else
        Select Case LenWid(VST)
            Case 0
                SSS_UPLCHAR = VST
            Case 1
                SSS_UPLCHAR = Chr$(Asc(VST) + 1)
            Case Else
                SSS_UPLCHAR = MidWid$(VST, 1, LenWid(VST) - 1) & Chr$(Asc(MidWid$(VST, LenWid(VST), 1)) + 1)
        End Select
    End If
End Function

Function SSS_WEEKNM(ByVal idx As Integer) As String
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

Function SSSMAIN_ErrorMsg(ByVal Cd_Error)

End Function

Sub SSSWIN_CLOSE()
Dim I As Integer
    '
    For I = SSS_MAX_DB - 1 To 0 Step -1
        If Left$(DB_PARA(I).DBID, 4) = "USR1" Or Trim$(DB_PARA(I).DBID) >= "USR4" Then
            Call DB_Close(I)
'            If DBSTAT <> 0 Then
'                MsgBox ("ファイルＣＬＯＳＥエラー" + DB_PARA(i).tblid)
'            End If
        Else
            Call JB_Close(I)
        End If
    Next I
    '
    Call SSS_CLOSE
    Call SSSWIN_LOGWRT("プログラム終了")
End Sub

Sub SSSWIN_INIT()
Dim I%
Dim DT, YMD$
'   日付形式チェック 1997/02/17 追加
    DT = Date
    YMD = Format(Year(DT), "0000") & "/" & Format(Month(DT), "00") & "/" & Format(Day(DT), "00")
    If CStr(DT) <> YMD Then
        MsgBox "日付の形式 '" & CStr(DT) & "' が違います。" & vbCrLf _
             & "コントロールパネルの地域（地球の絵）の日付" & vbCrLf _
             & "の短い形式を yyyy/MM/dd に変更して下さい。", vbCritical
        Call Error_Exit("日付の形式が違います。")
    End If
    '---------------------
    ' 起動パラメータ設定
    '---------------------
    I = LenWid(Trim$(Command$))
    If I < 15 Then
        MsgBox "メニューから実行してください。", vbOKOnly, SSS_PrgNm
        Call Error_Exit("メニューから実行してください。")
    End If
    SSS_CLTID = MidWid$(Command$, 2, 5)
    SSS_OPEID = MidWid$(Command$, 7, 8)
    Link_Clr.FILLER = ""
    LSet Link_OUT = Link_Clr
    Link_ON = False
    If I > 15 Then ' 1997/04/17
        Link_ON = True
        Link_Clr.FILLER = MidWid$(Command$, 16, I - 15) ' 1997/04/17
    End If
    LSet Link_IN = Link_Clr

    '2001/04 リードオンリーモード設定
    If Left$(Command$, 1) = "'" Then SSS_ReadOnly = True

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
    Call SSSWIN_INIT_GETINI
    '
    Call Init_Fil
    
    ''2001/12/14 画面圧縮機能
    ''（画面が大きすぎる場合には, サイズを80%フォントを7.5Pに縮小）
    FormControls FR_SSSMAIN
    '
    PP_SSSMAIN.FormWidth = FR_SSSMAIN.Width
    PP_SSSMAIN.FormHeight = FR_SSSMAIN.Height
    FR_SSSMAIN.Top = (Screen.Height - FR_SSSMAIN.Height) / 2
    FR_SSSMAIN.Left = (Screen.Width - FR_SSSMAIN.Width) / 2
''''''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更の為、SSSWIN_OPENでセット(DEL-START)
''''FR_SSSMAIN!SYSDT.Caption = Format$(Now, "YYYY/MM/DD")
''''''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更の為、SSSWIN_OPENでセット(DEL-E N D)
    FR_SSSMAIN.Icon = ICN_ICON.Icon
    FR_SSSMAIN.Caption = Trim$(SSS_PrgNm)

    ''2001/12/14 場所を８行上に変更
    ''2001/06/11 画面圧縮機能
    ''（画面が大きすぎる場合には, サイズを80%フォントを7.5Pに縮小）
    'FormControls FR_SSSMAIN

    AE_Title = SSS_PrgId

    '2001/04 時間測定モードかどうか
    Call SetTimeLog
End Sub

Sub SSSWIN_INIT_GETINI()
    Dim WL_WinDir As String, I As Integer, LENGTH As Integer
    Dim rtnPara As String * MAX_PATH
    '---------------------
    ' SSSWIN.INI 読込み
    '---------------------
    For I = 0 To SSS_INICnt
        rtnPara = ""
        LENGTH = GetPrivateProfileString("SSSWIN", ByVal SSS_INIDATNM(I), "", rtnPara, Len(rtnPara), ByVal "SSSWIN.INI")
        If LENGTH = 0 Then
            MsgBox "SSSWIN.INI を確認してください。" & Chr(13) & "[" & SSS_INIDATNM(I) & "]"
            Call Error_Exit("SSSUSR.INI を確認してください。[" & SSS_INIDATNM(I) & "]")
        Else
            '#Start(2003.4.3) 長いパス、全角文字含むパス対応
            'SSS_INIDAT(I) = Left$(rtnPara, LENGTH)
            SSS_INIDAT(I) = LeftWid$(rtnPara, LENGTH)
            '#End(2003.4.3)
        End If
        If Right$(SSS_INIDAT(I), 1) <> "\" And Right$(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
    Next I
End Sub

Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
Dim Fno As Integer, errcnt As Integer, rtn As Integer
Dim wbuf As String
    '
    Call ResetDBSTAT(DBN_SYSTBE)
    '
    LSet DB_SYSTBE = DB_CLRREC
    DB_SYSTBE.PRGID = SSS_PrgId
    DB_SYSTBE.LOGNM = LogMsg
    DB_SYSTBE.OPEID = SSS_OPEID
    DB_SYSTBE.CLTID = SSS_CLTID
    DB_SYSTBE.WRTTM = Format$(Now, "hhnnss")
    DB_SYSTBE.WRTDT = Format$(Now, "YYYYMMDD")
    '
    errcnt = 0
    Fno = FreeFile
    On Error Resume Next
    'ディレクトリ存在チェック
    wbuf = Dir$(SSS_INIDAT(1), 16)
    If wbuf = "" Then
        Call MsgBox("SSSWIN.INI の DAT_PATH の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
        'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
        Call SSS_CLOSE
        rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
        End
    End If
    Err = 0
    On Error GoTo ErrorLogFile
    Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
    On Error GoTo 0
    Print #Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT
    Close #Fno
    Exit Sub
ErrorLogFile:
    errcnt = errcnt + 1
    If errcnt > SSS_ReTryCnt Then
        If MsgBox("履歴ファイルロックエラー !" & Chr$(13) & "中止しても宜しいですか？", 20) = 6 Then
            Call SSS_CLOSE
            rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
            End
        Else
            errcnt = 0
        End If
    End If
    DoEvents
    Resume
End Sub

Sub SSSWIN_OPEN()
    Dim I As Integer, DBFLocation  As String
'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    Dim rtn As Integer
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

    '
    Call SSSWIN_LOGWRT("プログラム起動")
    '
    For I = 0 To SSS_MAX_DB - 1
        If Trim$(DB_PARA(I).DBID) = "USR1" Or Trim$(DB_PARA(I).DBID) >= "USR4" Then
            Call DB_Open(I, DB_PARA(I).DBID, DB_PARA(I).tblid)
            If DBSTAT <> 0 Then
                MsgBox ("ファイルＯＰＥＮエラー" + DB_PARA(I).tblid + Str$(DBSTAT)): End
            End If
        Else
        ' Linkチェック外す 97/02/12
            Call JB_Open(I)
        End If
    Next I
    '
    Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
    ''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更(ADD-START)
    Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
    FR_SSSMAIN!SYSDT.Caption = CNV_DATE(DB_UNYMTA.UNYDT)
    ''2006/10/07 画面日付の設定をマシン日付→運用日マスタの運用日に変更(ADD-E N D)

'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    '権限取得
    If Get_Authority(DB_UNYMTA.UNYDT) = "9" Then
        '起動権限なしの場合、処理終了
        rtn = DSP_MsgBox(SSS_ERROR, "RUNAUTH", 0)
        End
    End If
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

End Sub

Sub SSS_NoMsg_EXIT()
    Dim rtn

    Call SSSWIN_CLOSE
    rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
    End
End Sub

Function SSSVal(INP_Value As Variant) As Variant
    If IsNumeric(INP_Value) = True Then
        SSSVal = CCur(INP_Value)
    Else
        SSSVal = 0
    End If
End Function

'途中中止／フラグファイルの作成
'vFname:プログラムＩＤ。必須
'vPrgNm:中止ウィンドウ上表示されるプログラム名称。省略された場合は、SSS_PrgNmを使う
'-----------------------
Sub Make_infoFile(vFname As String, Optional vPrgNm As Variant)
Dim wkFileStr As String
Dim wkDATE As String
Dim wkTime As String
Dim cmdLine As String
Dim ret As Double
Dim wkSchema As String
Dim wkPkgUsr As String
Dim wkStr As String * 128

    On Error Resume Next
    wkPkgUsr = "USR1"
    ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr, Len(wkStr), "SSSWIN.INI")
    If ret > 0 Then
        wkPkgUsr = Left(wkStr, ret)
    End If
    wkSchema = Get_DbSchema(wkPkgUsr)           'スキーマ名
    wkFileStr = SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID & ".flg"
    'クライアント専用フォルダに、PRGID_ｸﾗｲｱﾝﾄID.flg ファイルを落とす
    Open wkFileStr For Output As #1
    Print #1, SSS_PrgId
    Print #1, SSS_PrgNm
    wkDATE = Format(Now, "YYYY/MM/DD")
    Print #1, wkDATE
    wkTime = Format(Now, "HH:MM:SS")
    Print #1, wkTime
    Close #1
    '中止用プログラムを起動
    If IsMissing(vPrgNm) Then
        cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID & wkSchema & "_" & vFname & "$" & Trim$(SSS_PrgNm)
    Else
        cmdLine = SSS_INIDAT(2) & "EXE\pStop.exe " & SSS_CLTID & wkSchema & "_" & vFname & "$" & Trim$(vPrgNm)
    End If
    ret = Shell(cmdLine)
End Sub

'途中中止／フラグファイルの削除
'vFname:プログラムＩＤ。
'------------------------
Sub Remove_infoFile(vFname As String)
    'make_infoFile でクライアント専用フォルダに作成したファイル（PRGID_ｸﾗｲｱﾝﾄID.flg）を削除する
Dim wkSchema As String
Dim wkPkgUsr As String
Dim ret As Integer
Dim wkStr As String * 128
    
    On Error Resume Next
    wkPkgUsr = "USR1"
    ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr, Len(wkStr), "SSSWIN.INI")
    If ret > 0 Then
        wkPkgUsr = Left(wkStr, ret)
    End If
    wkSchema = Get_DbSchema(wkPkgUsr)           'スキーマ名
    Kill (SSS_INIDAT(3) & wkSchema & "_" & vFname & "_" & SSS_CLTID & ".flg")
End Sub

'2001/04 時間測定用ルーチン
'Global SSS_SttTm
'Global SSS_FinTm
'Global TimeMode%
'
'測定結果を出力（FinTime - SttTime）
Sub PutLogTime(ByVal logStr$)
Dim Fno As Integer
Dim ClcTime, Logtime As String
    If Not TimeMode Then Exit Sub
    ClcTime = SSS_FinTm - SSS_SttTm
    Logtime = FormatAndRound(ClcTime, "###,##0.00")
    Fno = FreeFile
    On Error Resume Next
    Open SSS_INIDAT(3) & SSS_PrgId & ".Log" For Append As Fno
    Print #Fno, logStr & vbTab & "(" & Logtime & ")" & vbTab & SSS_OPEID & SSS_CLTID & vbTab & Now
    Close #Fno
End Sub

'時間測定するかを SSSwin.Iniの情報で判定
Sub SetTimeLog()
Dim Buff As String * 50, ret, GetStr$
    On Error Resume Next
    Buff = " "
    ret = GetPrivateProfileString("SSSWIN", "TIMELOG", "", Buff, Len(Buff), "SSSWIN.INI")
    GetStr = UCase(Left$(Buff, InStr(Buff, Chr$(0)) - 1))
    If GetStr = "TRUE" Then TimeMode = True
End Sub

''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' このサブルーチンでは、SYSTBHに登録してあるMSGKBは "S" と統一。
' エラーメッセージを表示した後の処理は、アプリ側で行う
' 補助メッセージExtMsgのある場合は、新たの行でそのメッセージを表示する
''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub SSS_ERROR_CHECK(ErrCode As Integer, tblName As String, SEQNO As String, ExtMsg As String)
Dim ret As Integer
Dim wkMsg As String

    wkMsg = ""
    If Trim(G_PlCnd2.sErrMsg) <> "" Then wkMsg = Chr(13) & "--------------" & Chr(13) & Trim(G_PlCnd2.sErrMsg)

    Select Case ErrCode
    Case -20099                             'SYSTBHに登録してあるメッセージを表示する
        DB_SYSTBH.MSGNM = tblName
        Call DB_GetEq(DBN_SYSTBH, 1, "S" & DB_SYSTBH.MSGNM & Format$(SEQNO, "0"), BtrNormal)
        If DBSTAT = 0 Then
            'SYSTBHに該当メッセージが存在している場合
            If ExtMsg = "" Then
                ret = MsgBox(Trim$(DB_SYSTBH.MSGCM) & wkMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
            Else
                ret = MsgBox(Trim$(DB_SYSTBH.MSGCM) & Chr(13) & ExtMsg, SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
            End If
        Else
            'SYSTBHに該当メッセージが登録していない場合
            MsgBox "メッセージテーブルに登録されていないメッセージを表示しようとしました。" & Chr(13) & "テーブル名=[" & Trim(tblName) & "]" & Chr(13) & "連番=[" & Format$(SEQNO, "0") & "]" & Chr(13) & "システムの開発サイドにご連絡下さい", vbOKOnly Or vbCritical, SSS_PrgNm
        End If
    Case -20005, 20005, -20006, 20006, -20007, 20007, -20008, 20008     'サーバ側ファイルＩ／Ｏエラー
        MsgBox "サーバ側のファイルＩ／Ｏ操作エラーが発生しました。" & Chr(13) & "サーバ側のログ用フォルダに問題があると思われます。" & Chr(13) & "システム管理者にご連絡下さい。" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
    Case -20010, 20010                             'ユーザによる中止された
        MsgBox "ユーザーにより実行が中止されました。" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
    Case -20015, 20015                             '順序が存在していない
        MsgBox "順序が未作成です。" & Chr(13) & "管理ツールで順序の作成／更新を行って下さい。" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
    Case Else
        'オラクルの一般エラーの場合
        If ErrCode = -54 Then
            MsgBox "他のユーザによりデータがロックされています。" & Chr(13) & "暫らく待ってから再実行して下さい。" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
        Else
            MsgBox "データベース側にエラーが発生しました。" & Chr(13) & "エラー番号 ＝［ " & Str$(ErrCode) & " ］" & Chr(13) & "システム管理者にご連絡下さい。" & wkMsg, vbOKOnly Or vbExclamation, SSS_PrgNm
        End If
    End Select
End Sub

Function Get_EntryToPackage() As String
Dim wkStr As String * 128, wkUsr As String
Dim ret As Integer
Dim wkSchema As String

    wkUsr = "USR1"
    ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr, Len(wkStr), ByVal "SSSWIN.INI")
    If ret > 0 Then wkUsr = Left$(wkStr, ret)
    wkSchema = Get_DbSchema(wkUsr)
    Get_EntryToPackage = wkSchema & "." & SSS_PrgId & "_PACK.M_" & SSS_PrgId
End Function

Function Get_EntryToPackage2(ByVal vPack As String, ByVal vEntry As String) As String
' 全てのフレームで使用可能
'       vPack="HDNDL05" → HDNDL05_PACK, vPack = "" の時は、SSS_PrgID が使用される
'       vEntry="M_xxxxxx","M2_xxxxxx","MW_xxxxxx"
Dim wkStr As String * 128, wkDbhead As String, wkUsr As String, wkPack As String
Dim ret As Integer
Dim wkSchema As String

    wkUsr = "USR1"
    ret = GetPrivateProfileString("REPORT", "PACK_LOADED_AT", "", wkStr, Len(wkStr), ByVal "SSSWIN.INI")
    If ret > 0 Then wkUsr = Left$(wkStr, ret)
    wkSchema = Get_DbSchema(wkUsr)
    wkPack = SSS_PrgId
    If vPack <> "" Then wkPack = vPack
    Get_EntryToPackage2 = wkSchema & "." & wkPack & "_PACK." & vEntry
End Function

Sub Set_StripeColor(Optional vFraId As Variant)
Dim ret As Integer
Dim wkStr As String * 128
Dim wkFraId As String

    If IsMissing(vFraId) Then
        '通常のケース
        wkFraId = Left$(SSS_FraId, 2)
    Else
        'DLからドリルダウンでETを呼出す場合など
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
    ret = GetPrivateProfileString("SSSWIN", "STRIPE_COLOR_" & wkFraId, "", wkStr, 128, "SSSWIN.INI")
    If ret > 0 Then
        SSS_STRIPE_COLOR = CLng(Left$(wkStr, ret))
    Else
        ret = GetPrivateProfileString("SSSUSR", "STRIPE_COLOR_" & wkFraId, "", wkStr, 128, SSS_INIDAT(0) & "SSSUSR.INI")
        If ret > 0 Then
            SSS_STRIPE_COLOR = CLng(Left$(wkStr, ret))
        End If
    End If
End Sub

Function Get_DBHEAD() As String
'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
Dim ret%, wkStr As String * 128

    Get_DBHEAD = ""
    ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr, 128, ByVal "SSSWIN.INI")
    If ret > 0 Then Get_DBHEAD = Left$(wkStr, ret)
End Function

''2001/06/11 画面圧縮機能
''2001/07/16 一部改訂
''2001/11/09 画面情報はｅｅｅを利用
' フォームの伸縮
'   I   frm         フォーム
'   I   gOptFntSz   フォントサイズ
Public Sub FormControls(ByVal frm As Form, Optional ByVal gOptFntSz As Single)
    On Error Resume Next
    Dim I As Integer, iGrpCnt As Integer
    Dim nLeft As Long, nHeight As Long, nWidth As Long
    Dim gFactor As Single, gFntSz As Single
    Dim sFrmNm As String
    Dim ctr As Control
    Dim tTol As TYPE_BAR, tMsg As TYPE_BAR
    Dim tGrps() As TYPE_CTRLGRP

    ''2001/11/09 画面情報はｅｅｅを利用
    If PP_SSSMAIN.FormHeight > Screen.Height Or PP_SSSMAIN.FormWidth > Screen.Width Then
    ''If frm.Height > Screen.Height Or frm.Width > Screen.Width Then
        gFactor = 0.8

        Select Case gOptFntSz
        Case 0, 7.5: gFntSz = 7.5
        Case Else:   gFntSz = 8
        End Select

        sFrmNm = frm.NAME

        ' バーコントロールの取得
        getBarControls frm, tTol, tMsg

        ' 補正対象コントロールの設定
        getHoseiControls frm, iGrpCnt, tGrps()

        ' フォームの伸縮
        ''2001/11/09 画面情報はｅｅｅを利用
        nHeight = calTwip(PP_SSSMAIN.FormHeight + 780, gFactor)
        nWidth = calTwip(PP_SSSMAIN.FormWidth + 120, gFactor)
        frm.Left = frm.Left + calTwip(PP_SSSMAIN.FormWidth + 120 - nWidth, 0.5)
        frm.Top = frm.Top + calTwip(PP_SSSMAIN.FormHeight + 780 - nHeight, 0.5)
        ''nHeight = calTwip(frm.Height, gFactor)
        ''nWidth = calTwip(frm.Width, gFactor)
        ''frm.Left = frm.Left + calTwip(frm.Width - nWidth, 0.5)
        ''frm.Top = frm.Top + calTwip(frm.Height - nHeight, 0.5)
        frm.Height = nHeight
        frm.Width = nWidth

        ' コントロールの伸縮
        tTol.iBarCnt = 0
        tMsg.iBarCnt = 0

        For Each ctr In frm.Controls
            If (TypeOf ctr Is Menu) Or (TypeOf ctr Is Timer) Then

            ElseIf TypeOf ctr Is Line Then
                ctr.X1 = calTwip(ctr.X1, gFactor)
                ctr.X2 = calTwip(ctr.X2, gFactor)
                ctr.Y1 = calTwip(ctr.Y1, gFactor)
                ctr.Y2 = calTwip(ctr.Y2, gFactor)
            Else
                If TypeOf ctr Is Image Then
                    Select Case getContainer(ctr).NAME
                    Case tTol.ctr.NAME
                        ReDim Preserve tTol.ctrBars(tTol.iBarCnt)
                        Set tTol.ctrBars(tTol.iBarCnt) = ctr
                        tTol.iBarCnt = tTol.iBarCnt + 1

                    Case tMsg.ctr.NAME
                        ReDim Preserve tMsg.ctrBars(tMsg.iBarCnt)
                        Set tMsg.ctrBars(tMsg.iBarCnt) = ctr
                        tMsg.iBarCnt = tMsg.iBarCnt + 1

                    End Select
                Else
                    nLeft = ctr.Left

                    ctr.Font.Size = gFntSz
                    ctr.Left = calTwip(ctr.Left, gFactor)
                    ctr.Top = calTwip(ctr.Top, gFactor)
                    ctr.Height = calTwip(ctr.Height, gFactor)
                    ctr.Width = calTwip(ctr.Width, gFactor)

                    If TypeOf ctr Is TextBox Then
                        Select Case getContainer(ctr).NAME
                        Case tTol.ctr.NAME: ctr.Left = nLeft
                        End Select
                    End If
                End If
            End If
        Next

        ' ツールバーとメッセージバーの補正
        hoseiBar frm, tTol, tMsg, gFactor

        ' 各ブロックのコントロールを補正
        For I = 0 To iGrpCnt - 1
            hoseiControls tGrps(I).iCtrCnt, tGrps(I).tCtrs()
        Next
    End If
End Sub

' 補正対象コントロールの取得
'   I   frm     フォーム
'   O   iGrpCnt コンテナグループ数
'   O   tGrps() コンテナグループ別コントロール情報
Private Sub getHoseiControls(ByVal frm As Form, iGrpCnt As Integer, tGrps() As TYPE_CTRLGRP)
    Dim I As Integer, J As Integer, k As Integer
    Dim ctr As Control

    ' コンテナグループ別のコントロールを取得
    iGrpCnt = 0

    For Each ctr In frm.Controls
        If (TypeOf ctr Is Menu) Or (TypeOf ctr Is Timer) Or _
           (TypeOf ctr Is Line) Then

        Else
            getGrpControls ctr, iGrpCnt, tGrps()
        End If
    Next

    ' 隣接するコントロールを確定
    For I = 0 To iGrpCnt - 1
        relControl tGrps(I).iCtrCnt, tGrps(I).tCtrs()
    Next
End Sub

' コンテナグループ別のコントロールを取得
'   I   ctr     コントロール
'   O   iGrpCnt コンテナグループ数
'   O   tGrps() コンテナグループ別コントロール
Private Sub getGrpControls(ByVal ctr As Control, iGrpCnt As Integer, tGrps() As TYPE_CTRLGRP)
    Dim bOvrFg As Boolean
    Dim I As Integer
    Dim tCtr As TYPE_CTRLINFO

    bOvrFg = False
    For I = 0 To iGrpCnt - 1
        If tGrps(I).sGrpNm = ctr.Container.NAME Then
            bOvrFg = True
            Exit For
        End If
    Next

    If bOvrFg Then
        ReDim Preserve tGrps(I).tCtrs(tGrps(I).iCtrCnt)

        tCtr.nLeft = ctr.Left
        tCtr.nTop = ctr.Top
        tCtr.nHeight = ctr.Height
        tCtr.nWidth = ctr.Width
        Set tCtr.ctr = ctr

        tGrps(I).tCtrs(tGrps(I).iCtrCnt) = tCtr
        tGrps(I).iCtrCnt = tGrps(I).iCtrCnt + 1
    Else
        ReDim Preserve tGrps(iGrpCnt)
        ReDim Preserve tGrps(iGrpCnt).tCtrs(tGrps(iGrpCnt).iCtrCnt)

        tGrps(iGrpCnt).sGrpNm = ctr.Container.NAME
        tCtr.nLeft = ctr.Left
        tCtr.nTop = ctr.Top
        tCtr.nHeight = ctr.Height
        tCtr.nWidth = ctr.Width
        Set tCtr.ctr = ctr
        tGrps(iGrpCnt).tCtrs(tGrps(iGrpCnt).iCtrCnt) = tCtr

        tGrps(iGrpCnt).iCtrCnt = tGrps(iGrpCnt).iCtrCnt + 1
        iGrpCnt = iGrpCnt + 1
    End If
End Sub

' 隣接するコントロールを確定
'   I   iCtrCnt コントロール数
'   O   tCtrs() コントロール
Private Sub relControl(ByVal iCtrCnt As Integer, tCtrs() As TYPE_CTRLINFO)
    Dim I As Integer, J As Integer
    Dim iTwipX As Integer, iTwipY As Integer
    Dim nRight As Long, nDown As Long, nMin As Long, nMax As Long
    Dim tRel As TYPE_RELINFO

    iTwipX = Screen.TwipsPerPixelX
    iTwipY = Screen.TwipsPerPixelY

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

                        Set tRel.ctr = tCtrs(J).ctr
                        Select Case tCtrs(I).nTop + tCtrs(I).nHeight - iTwipY
                        Case nMax: tRel.bJstFg = True
                        Case Else: tRel.bJstFg = False
                        End Select

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

                        Set tRel.ctr = tCtrs(J).ctr
                        Select Case tCtrs(I).nLeft + tCtrs(I).nWidth - iTwipX
                        Case nMax: tRel.bJstFg = True
                        Case Else: tRel.bJstFg = False
                        End Select

                        tCtrs(I).tDowns(tCtrs(I).iDownCnt) = tRel
                        tCtrs(I).iDownCnt = tCtrs(I).iDownCnt + 1

                    End Select
                End If
            End If
        Next
    Next

'    debugZoom iCtrCnt, tCtrs()
End Sub

Private Sub debugZoom(ByVal iCtrCnt As Integer, tCtrs() As TYPE_CTRLINFO)
    Dim bJstFg As Boolean
    Dim I As Integer, J As Integer
    Dim iNo As Integer

    For I = 0 To iCtrCnt - 1
        Debug.Print CStr(I) & ": ";
        Debug.Print tCtrs(I).ctr.NAME & ", "
        Debug.Print "  Left -> ";
        For J = 0 To tCtrs(I).iLeftCnt - 1
'            iNo = tCtrs(i).tLefts(j).iNo
            bJstFg = tCtrs(I).tLefts(J).bJstFg
'            Debug.Print tCtrs(iNo).ctr.Name & "(" & bJstFg & ")" & ", ";
            Debug.Print tCtrs(I).tLefts(J).ctr.NAME & "(" & bJstFg & ")" & ", ";
        Next
        Debug.Print
        Debug.Print "  Down -> ";
        For J = 0 To tCtrs(I).iDownCnt - 1
'            iNo = tCtrs(i).tDowns(j).iNo
            bJstFg = tCtrs(I).tDowns(J).bJstFg
'            Debug.Print tCtrs(iNo).ctr.Name & "(" & bJstFg & ")" & ", ";
            Debug.Print tCtrs(I).tDowns(J).ctr.NAME & "(" & bJstFg & ")" & ", ";
        Next
        Debug.Print
    Next
End Sub

' バーコントロールの取得
'   I   frm     フォーム
'   O   tTol    ツールバー情報
'   O   tMsg    メッセージバー情報
Private Sub getBarControls(ByVal frm As Form, tTol As TYPE_BAR, tMsg As TYPE_BAR)
    Dim obj As Object

    For Each obj In frm.Controls
        Select Case UCase$(obj.NAME)
        Case "SYSDT"
            Do
                Set tTol.ctr = obj
                Set obj = obj.Container
            Loop While Not (TypeOf obj Is Form)

        Case "TX_MESSAGE"
            Do
                Set tMsg.ctr = obj
                Set obj = obj.Container
            Loop While Not (TypeOf obj Is Form)

        End Select
    Next
End Sub

' コントロールの補正
'   I   iCtrCnt コントロール数
'   O   tCtrs() コントロール
Private Sub hoseiControls(ByVal iCtrCnt As Integer, tCtrs() As TYPE_CTRLINFO)
    Dim I As Integer, J As Integer
    Dim iTwipX As Integer, iTwipY As Integer
    Dim nLeft As Long, nTop As Long
    Dim nRight As Long, nDown As Long
    Dim tCrt As TYPE_CTRLINFO
    Dim tCrtsL() As TYPE_CTRLINFO

    iTwipX = Screen.TwipsPerPixelX
    iTwipY = Screen.TwipsPerPixelY

    ' 左隣接コントロールのLeft値を補正
    For I = 0 To iCtrCnt - 2
        For J = I + 1 To iCtrCnt - 1
            If tCtrs(J).nLeft < tCtrs(I).nLeft Then
                tCrt = tCtrs(I)
                tCtrs(I) = tCtrs(J)
                tCtrs(J) = tCrt
            End If
        Next
    Next

    For I = 0 To iCtrCnt - 1
        ReDim Preserve tCrtsL(I)
        tCrtsL(I) = tCtrs(I)

        nLeft = tCtrs(I).ctr.Left + tCtrs(I).ctr.Width - iTwipX
        For J = 0 To tCtrs(I).iLeftCnt - 1
            tCtrs(I).tLefts(J).ctr.Left = nLeft
        Next
    Next

    ' 下隣接コントロールのTop値とWidth値を補正
    For I = 0 To iCtrCnt - 2
        For J = I + 1 To iCtrCnt - 1
            If tCtrs(J).nTop < tCtrs(I).nTop Then
                tCrt = tCtrs(I)
                tCtrs(I) = tCtrs(J)
                tCtrs(J) = tCrt
            End If
        Next
    Next

    For I = 0 To iCtrCnt - 1
        nTop = tCtrs(I).ctr.Top + tCtrs(I).ctr.Height - iTwipY
        nRight = tCtrs(I).ctr.Left + tCtrs(I).ctr.Width - iTwipX
        For J = 0 To tCtrs(I).iDownCnt - 1
            tCtrs(I).tDowns(J).ctr.Top = nTop
            If tCtrs(I).tDowns(J).bJstFg Then
                tCtrs(I).tDowns(J).ctr.Width = nRight - tCtrs(I).tDowns(J).ctr.Left + iTwipX
            End If
        Next
    Next

    ' 左隣接コントロールのHeight値を補正
    For I = 0 To iCtrCnt - 1
        nDown = tCrtsL(I).ctr.Top + tCrtsL(I).ctr.Height - iTwipY
        For J = 0 To tCrtsL(I).iLeftCnt - 1
            If tCrtsL(I).tLefts(J).bJstFg Then
                tCrtsL(I).tLefts(J).ctr.Height = nDown - tCrtsL(I).tLefts(J).ctr.Top + iTwipY
            End If
        Next
    Next
End Sub

' Widthの修正
'   I   nTwip       Twip値
'   I   gFactor     倍率
Private Function calTwip(ByVal nWidth As Long, ByVal gFactor As Single) As Long
    calTwip = ((nWidth * gFactor) \ 15) * 15
End Function

' 指定のコントロールが格納されている最上位のコンテナを取得
'   I   ctr     コントロール
Private Function getContainer(ByVal ctr As Control) As Object
    Dim obj As Object

    Set obj = ctr

    Do While Not (TypeOf obj.Container Is Form)
        Set obj = obj.Container
    Loop

    ' 最上位のコンテナコントロールが無ければフォームを返す
    If obj.NAME = ctr.NAME Then
        Set obj = obj.Container
    End If

    Set getContainer = obj
End Function

' ツールバーとメッセージバーの補正
'   I   frm     フォーム
'   I   tTol    ツールバー情報
'   I   tMsg    メッセージバー情報
'   I   gFactor 倍率
Private Sub hoseiBar(ByVal frm As Form, tTol As TYPE_BAR, tMsg As TYPE_BAR, ByVal gFactor As Single)
    On Error Resume Next
    Dim I As Integer
    Dim nTop As Long

    ' ツールバーと格納コントロールの補正
    tTol.ctr.Left = -45
    tTol.ctr.Top = 0

    For I = 0 To tTol.iBarCnt - 1
        nTop = tTol.ctr.Height * 0.5 - tTol.ctrBars(I).Height * 0.5
        tTol.ctrBars(I).Top = nTop
    Next

    ' メッセージバーと格納コントロールの補正
    tMsg.ctr.Left = -45
    tMsg.ctr.Top = frm.ScaleHeight - tMsg.ctr.Height + Screen.TwipsPerPixelY * 4

    For I = 0 To tMsg.iBarCnt - 1
        tMsg.ctrBars(I).Top = calTwip(tMsg.ctrBars(I).Top, gFactor)
    Next
End Sub

'
Function Get_DbSchema(vUser As String) As String
    '指定したUSRのスキーマを取得する
Dim ret As Integer
Dim wkStr As String * 128
Dim wkBuf As String
    
    ret = GetPrivateProfileString("DBNAMES", vUser, "", wkStr, Len(wkStr), "SSSWIN.INI")
    If ret > 0 And UCase(Left(wkStr, ret)) <> "DEFAULT" Then
        Get_DbSchema = Left(wkStr, ret)
    Else
        Get_DbSchema = Get_DBHEAD() & "_" & vUser
    End If
End Function

'''''''
'#Start(2003.10.28)
'#Start(2003.4.22)
Public Function CreateBitmapPicture(ByVal hBmp As Long, _
   ByVal hPal As Long) As Picture

   Dim r As Long
   Dim Pic As PicBmp
   Dim IPic As IPicture
   Dim IID_IDispatch As GUID

   With IID_IDispatch
      .Data1 = &H20400
      .Data4(0) = &HC0
      .Data4(7) = &H46
   End With

   With Pic
      .Size = Len(Pic)          ' Length of structure
      .Type = vbPicTypeBitmap   ' Type of Picture (bitmap)
      .hBmp = hBmp              ' Handle to bitmap
      .hPal = hPal              ' Handle to palette (may be null)
   End With

   r = OleCreatePictureIndirect(Pic, IID_IDispatch, 1, IPic)
   Set CreateBitmapPicture = IPic
End Function
''''''''''''
Function CaptureWindow(ByVal hWndSrc As Long, _
    ByVal Client As Boolean, ByVal LeftSrc As Long, _
    ByVal TopSrc As Long, ByVal WidthSrc As Long, _
    ByVal HeightSrc As Long) As Picture
    
    Dim hDCMemory As Long
    Dim hBmp As Long
    Dim hBmpPrev As Long
    Dim r As Long
    Dim hDCSrc As Long
    Dim hPal As Long
    Dim hPalPrev As Long
    Dim RasterCapsScrn As Long
    Dim HasPaletteScrn As Long
    Dim PaletteSizeScrn As Long
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
       LogPal.palVersion = &H300
       LogPal.palNumEntries = 256
       r = GetSystemPaletteEntries(hDCSrc, 0, 256, _
           LogPal.palPalEntry(0))
       hPal = CreatePalette(LogPal)
       hPalPrev = SelectPalette(hDCMemory, hPal, 0)
       r = RealizePalette(hDCMemory)
    End If
    
    r = BitBlt(hDCMemory, 0, 0, WidthSrc, HeightSrc, hDCSrc, _
       LeftSrc, TopSrc, vbSrcCopy)
    
    hBmp = SelectObject(hDCMemory, hBmpPrev)
    
    If HasPaletteScrn And (PaletteSizeScrn = 256) Then
       hPal = SelectPalette(hDCMemory, hPalPrev, 0)
    End If
    
    r = DeleteDC(hDCMemory)
    r = ReleaseDC(hWndSrc, hDCSrc)
    
    Set CaptureWindow = CreateBitmapPicture(hBmp, hPal)
End Function

''''''
Public Function CaptureForm(frmSrc As Form) As Picture
    ' Call CaptureWindow to capture the entire form given it's window
    ' handle and then return the resulting Picture object
    Set CaptureForm = CaptureWindow(frmSrc.hwnd, False, 0, 0, _
       frmSrc.ScaleX(frmSrc.Width, vbTwips, vbPixels), _
       frmSrc.ScaleY(frmSrc.Height, vbTwips, vbPixels))
End Function
'ハードコピー
Public Sub Exec_Hardcopy(pform As Form)
    gSelectedDeviceName = ""
    If Printers.count = 0 Then
        Call MsgBox("このＰＣにはプリンタがインストールされていないため" & vbCr & "画面ハードコピーができません。" & vbCr & "プリンタをインストールしてから再度実行して下さい。", vbExclamation Or vbOKOnly, App.Title)
        gSelectedDeviceName = False
        Exit Sub
    End If
    Load WLS_HCP
    WLS_HCP.Show 1
    DoEvents
    If gSelectedDeviceName <> "" Then
        'Form のスクリーンショットを
        'Picture1 の Picture プロパティに代入します。
        Set WLS_HCP.Picture1.Picture = CaptureForm(pform)
        '指定したプリンタにPicture1を印刷します。
        APIPrint (gSelectedDeviceName)
    End If
    Unload WLS_HCP
End Sub
'
' 指定したディバイス（プリンタ）から、ＤｅｖＭｏｄｅ構造体を取得し、情報の設定を行ない。
Sub APIPrint(Device$)
    Dim dm As sDEVMODE
    Dim hPrinter&, di&
    Dim prhdc&
    Dim dinfo As DOCINFO
    Dim pdefs As PRINTER_DEFAULTS
    Dim bufsize&
    Dim dmInBuf() As Byte
    Dim dmOutBuf() As Byte

    pdefs.PDATATYPE = vbNullString
    pdefs.PDEVMODE = 0
    pdefs.DESIREDACCESS = PRINTER_ACCESS_USE

    di& = sOpenPrinter(Device, hPrinter, pdefs)
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
        MsgBox "プリンタの情報が取得できません。", 0, "ハードコピー"
        GoTo PrintEnd2
    End Select
    
    Call memcpy(dm, dmOutBuf(0), Len(dm))
    dm.dmOrientation = gSelectedOrientation
    dm.dmPaperSize = gSelectedPapeSize
    dm.dmColor = DMCOLOR_COLOR
    Call memcpy(dmOutBuf(0), dm, Len(dm))
    
    prhdc = CreateDC("winspool", Device, vbNullString, dmOutBuf(0))
    If prhdc = 0 Then GoTo PrintEnd2
    
    dinfo.cbSize = Len(dinfo)
    dinfo.lpszDocName = "画面ID：" & SSS_PrgId
    dinfo.lpszOutput = vbNullString
    
    di = StartDoc(prhdc, dinfo)
    di = StartPage(prhdc)
    PrintBitmap prhdc
    di = EndPage(prhdc)
    If di >= 0 Then di = EndDocAPI(prhdc)

PrintEnd1:
    DeleteDC (prhdc)

PrintEnd2:
    ClosePrinter hPrinter
    
End Sub
'
'フォームのスクリーンショットを印刷する
Sub PrintBitmap(hdc&)
    Dim bi As BITMAPINFO
    Dim dctemp&, dctemp2&
    Dim Msg$
    Dim bufsize&
    Dim bm As BITMAP
    Dim ghnd&
    Dim gptr&
    Dim xpix&, ypix&
    Dim doscale As Double
    Dim uy&, ux&
    Dim di&
    
    dctemp = CreateCompatibleDC(WLS_HCP.Picture1.hdc)
    di = GetObjectAPI(WLS_HCP.Picture1.Picture, Len(bm), bm)
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
    di = GetDIBits(dctemp, WLS_HCP.Picture1.Picture, 0, bm.bmHeight, ByVal gptr, bi, DIB_RGB_COLORS)
    
    xpix = GetDeviceCaps(hdc, HORZRES) - 200    '余白分引く
    ypix = GetDeviceCaps(hdc, VERTRES) - 200
    doscale = xpix / bm.bmWidth
    If ypix / bm.bmHeight < doscale Then
        doscale = ypix / bm.bmHeight
    End If
    If doscale > 6 Then
        doscale = 6             '上限サイズ　（1024*768 → A4横 で最適?）
    End If
    ux = Int(bm.bmWidth * doscale)
    uy = Int(bm.bmHeight * doscale)
    di = StretchDIBits(hdc, 100, 100, ux, uy, 0, 0, bm.bmWidth, bm.bmHeight, ByVal gptr, bi, DIB_RGB_COLORS, vbSrcCopy)
    
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

    Call DB_BeginTransaction(BTR_Exclude)
    DB_EXCTBZ.CLTID = SSS_CLTID
    DB_EXCTBZ.GYMCD = SSS_PrgId
    Call DB_GetEq(DBN_EXCTBZ, 1, DB_EXCTBZ.CLTID & DB_EXCTBZ.GYMCD, BtrNormal)
    If DBSTAT = 0 Then
        DB_EXCTBZ.LCKTM = Format$(Now, "hhnnss")
        Call DB_Update(DBN_EXCTBZ, 1)
    Else
        Call EXCTBZ_RClear
        DB_EXCTBZ.CLTID = SSS_CLTID
        DB_EXCTBZ.GYMCD = SSS_PrgId
        DB_EXCTBZ.LCKTM = Format$(Now, "hhnnss")
        Call DB_Insert(DBN_EXCTBZ, 1)
    End If
    Call DB_EndTransaction

End Sub

Public Sub SSSWIN_EXCTBZ_CLOSE()

    Call DB_BeginTransaction(BTR_Exclude)
    DB_EXCTBZ.CLTID = SSS_CLTID
    DB_EXCTBZ.GYMCD = SSS_PrgId
    Call DB_GetEq(DBN_EXCTBZ, 1, DB_EXCTBZ.CLTID & DB_EXCTBZ.GYMCD, BtrNormal)
    If DBSTAT = 0 Then
        Call DB_Delete(DBN_EXCTBZ)
    End If
    Call DB_EndTransaction

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
Function SSSWIN_EXCTBZ_CHECK2(pin_strGYMCD) As Integer
' === 20130530 === UPDATE E
    
    Dim strSQL As String
    Dim bolRet As Boolean

    SSSWIN_EXCTBZ_CHECK2 = 9
    
    strSQL = ""
    strSQL = strSQL & " SELECT * "
    strSQL = strSQL & "  FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
' === 20130530 === UPDATE S - FWEST)Koroyasu
'    strSQL = strSQL & "        GYMCD   = '" & Trim$(FR_SSSMAIN.HD_JDNNO) & "'"    '受注番号
    strSQL = strSQL & "        GYMCD   = '" & Trim$(pin_strGYMCD) & "'"    '業務コード
' === 20130530 === UPDATE E
    Call DB_GetSQL2(DBN_EXCTBZ, strSQL)

    If DBSTAT = 0 Then
        If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID _
        And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
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
Function SSSWIN_Execute_EXCTBZ(pin_strGYMCD) As Boolean
' === 20130530 === UPDATE E

    Dim strSQL As String

    SSSWIN_Execute_EXCTBZ = False
    
    Call DB_BeginTransaction(BTR_Exclude)

    strSQL = ""
    strSQL = strSQL & " INSERT INTO "
    strSQL = strSQL & "        EXCTBZ "         '排他テーブル
    strSQL = strSQL & "      ( CLTID "          'クライアントID
    strSQL = strSQL & "      , GYMCD "          '受注番号
    strSQL = strSQL & "      , LCKTM "          'タイムスタンプ
    strSQL = strSQL & "      , INTLCD "         'プログラムID
    strSQL = strSQL & "      ) "
    strSQL = strSQL & " VALUES "
    strSQL = strSQL & "      ( '" & SSS_CLTID & "' "                    'クライアントID
' === 20130530 === UPDATE S - FWEST)Koroyasu
'   strSQL = strSQL & "      , '" & Trim$(FR_SSSMAIN.HD_JDNNO) & "' "   '受注番号
    strSQL = strSQL & "      , '" & Trim$(pin_strGYMCD) & "' "          '業務コード
' === 20130530 === UPDATE E
    strSQL = strSQL & "      , '" & Format$(Now, "hhnnss") & "' "       'タイムスタンプ
    strSQL = strSQL & "      , '" & SSS_PrgId & "'"                     'プログラムID
    strSQL = strSQL & "      ) "
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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

    Call DB_BeginTransaction(BTR_Exclude)

    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "     'クライアントID
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "     'プログラムID
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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
Function SSSWIN_EXCTBZ_CHECK3(pin_strGYMCD) As Integer
    
    Dim strSQL As String
    Dim bolRet As Boolean

    SSSWIN_EXCTBZ_CHECK3 = 9
    
    strSQL = ""
    strSQL = strSQL & " SELECT * "
    strSQL = strSQL & "  FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        GYMCD   = '" & Trim$(pin_strGYMCD) & "'"    '業務コード
    Call DB_GetSQL2(DBN_EXCTBZ, strSQL)

    If DBSTAT = 0 Then
        If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID _
        And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
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
Function SSSWIN_Execute_EXCTBZ2(pin_strGYMCD) As Boolean

    Dim strSQL As String

    SSSWIN_Execute_EXCTBZ2 = False
    
    Call DB_BeginTransaction(BTR_Exclude)

    strSQL = ""
    strSQL = strSQL & " INSERT INTO "
    strSQL = strSQL & "        EXCTBZ "         '排他テーブル
    strSQL = strSQL & "      ( CLTID "          'クライアントID
    strSQL = strSQL & "      , GYMCD "          '受注番号
    strSQL = strSQL & "      , LCKTM "          'タイムスタンプ
    strSQL = strSQL & "      , INTLCD "         'プログラムID
    strSQL = strSQL & "      , EXTCD "          '削除フラグ
    strSQL = strSQL & "      ) "
    strSQL = strSQL & " VALUES "
    strSQL = strSQL & "      ( '" & SSS_CLTID & "' "                    'クライアントID
    strSQL = strSQL & "      , '" & Trim$(pin_strGYMCD) & "' "          '業務コード
    strSQL = strSQL & "      , '" & Format$(Now, "hhnnss") & "' "       'タイムスタンプ
    strSQL = strSQL & "      , '" & SSS_PrgId & "'"                     'プログラムID
    strSQL = strSQL & "      , '1'"                                     '削除フラグ
    strSQL = strSQL & "      ) "
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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

    Call DB_BeginTransaction(BTR_Exclude)

    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "     'クライアントID
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "     'プログラムID
    strSQL = strSQL & "    AND EXTCD    = '1'"                      '削除フラグ
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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
Function CF_Chk_EXCTBZ(pin_strGYMCD As String) As Integer

    Dim strSQL  As String
    Dim bolRet  As Boolean

    CF_Chk_EXCTBZ = 9

    '排他チェック
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " SELECT * "
    strSQL = strSQL & "  FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        GYMCD   = '" & Trim$(pin_strGYMCD) & "'"    '業務コード
    Call DB_GetSQL2(DBN_EXCTBZ, strSQL)

    If DBSTAT = 0 Then
        If Trim(DB_EXCTBZ.CLTID) = SSS_CLTID _
        And Trim(DB_EXCTBZ.INTLCD) = SSS_PrgId Then
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
Function CF_Ins_EXCTBZ(pin_strGYMCD As String) As Boolean

    Dim strSQL          As String

    CF_Ins_EXCTBZ = False

    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " INSERT INTO "
    strSQL = strSQL & "        EXCTBZ "         '排他テーブル
    strSQL = strSQL & "      ( CLTID "          'クライアントID
    strSQL = strSQL & "      , GYMCD "          '業務コード
    strSQL = strSQL & "      , LCKTM "          'タイムスタンプ
    strSQL = strSQL & "      , INTLCD "         'プログラムID
    strSQL = strSQL & "      , EXTCD "          '削除フラグ
    strSQL = strSQL & "      ) "
    strSQL = strSQL & " VALUES "
    strSQL = strSQL & "      ( '" & SSS_CLTID & "' "                    'クライアントID
    strSQL = strSQL & "      , '" & Trim$(pin_strGYMCD) & "' "          '業務コード
    strSQL = strSQL & "      , '" & Format$(Now, "hhnnss") & "' "       'タイムスタンプ
    strSQL = strSQL & "      , '" & SSS_PrgId & "'"                     'プログラムID
    strSQL = strSQL & "      , '0'"                                     '削除フラグ
    strSQL = strSQL & "      ) "
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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

    Dim strSQL          As String

    CF_Upd_EXCTBZ = False

    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " UPDATE "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "    SET "
    strSQL = strSQL & "        LCKTM    = '" & Format$(Now, "hhnnss") & "' "    'タイムスタンプ
    strSQL = strSQL & "      , EXTCD    = '1'"                                  '削除フラグ
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "     'クライアントID
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "     'プログラムID
    strSQL = strSQL & "    AND EXTCD    = '0'"                      '削除フラグ
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

    CF_Upd_EXCTBZ = True

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Upd_EXCTBZ2
'   概要：  排他制御処理(UPDATE)
'   引数：  pin_strGYMCD：業務コード
'   戻値：　True : 正常 False : 異常
'   備考：  排他制御(UPDATE)を実行する
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function CF_Upd_EXCTBZ2(pin_strGYMCD As String) As Boolean

    Dim strSQL          As String

    CF_Upd_EXCTBZ2 = False

    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " UPDATE "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "    SET "
    strSQL = strSQL & "        LCKTM    = '" & Format$(Now, "hhnnss") & "' "    'タイムスタンプ
    strSQL = strSQL & "      , EXTCD    = '0'"                                  '削除フラグ
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "     'クライアントID
    strSQL = strSQL & "    AND GYMCD    = '" & pin_strGYMCD & "' "  '業務コード
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "     'プログラムID
    strSQL = strSQL & "    AND EXTCD    <> ' '"                     '削除フラグ
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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

    Dim strSQL          As String

    CF_Del_EXCTBZ2 = False

    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御解除
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "     'クライアントID
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "     'プログラムID
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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

    Dim strSQL          As String

    CF_Del_EXCTBZ3 = False

    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御解除
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " DELETE FROM "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "             'クライアントID
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "             'プログラムID
    strSQL = strSQL & "    AND EXTCD    = '1' "                             '削除フラグ
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

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
Function CF_EXCTBZ_Unlock(pm_All As clsPP, pin_strGYMCD As String) As Boolean

    Dim strSQL          As String

    CF_EXCTBZ_Unlock = False
    
    'トランザクションの開始
    Call DB_BeginTransaction(BTR_Exclude)

    '排他制御
    'SQL編集
    strSQL = ""
    strSQL = strSQL & " UPDATE "
    strSQL = strSQL & "        EXCTBZ "     '排他テーブル
    strSQL = strSQL & "    SET "
    strSQL = strSQL & "        LCKTM    = '" & Format$(Now, "hhnnss") & "' "    'タイムスタンプ
    strSQL = strSQL & "      , EXTCD    = '0'"                                  '削除フラグ
    strSQL = strSQL & "  WHERE "
    strSQL = strSQL & "        CLTID    = '" & SSS_CLTID & "' "                 'クライアントID
    strSQL = strSQL & "    AND GYMCD    = '" & pin_strGYMCD & "' "              '業務コード
    strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' "                 'プログラムID
    strSQL = strSQL & "    AND EXTCD    = '1'"                                  '削除フラグ
    Call DB_Execute(DBN_EXCTBZ, strSQL)

    Call DB_EndTransaction

    CF_EXCTBZ_Unlock = True

End Function
' === 20130829 === UPDATE E -
' === 20130711 === INSERT E -



