Attribute VB_Name = "SSSVALUE"
Option Explicit

'--------------------
'■変数や定数の宣言部
'--------------------

'流用分
Public Const SSS_PrgId = "URKET73"
Public Const SSS_PrgNm = "前受充当戻し処理"

Public SSS_CLTID    As String * 5
Public SSS_OPEID    As String * 8
'流用分:END

Public Const SSS_SubWindowNm = "差額入金登録"

Public Const OPTION_SHOW_FLAG       As Boolean = True       '★オプション項目を表示するかどうかのﾌﾗｸﾞ
Public Const SHOW_HIDE_COLUMN_FLAG  As Boolean = False      '★隠し項目を表示するかどうかのﾌﾗｸﾞ(DEBUG用)
Public Const AUTHORITY_ENABLE       As Boolean = True       '★権限を有効とするかどうかのﾌﾗｸﾞ
Public Const UPDATE_MODE            As Integer = 2          '★NKSTRAの更新モード　1:全データを削除し、追加
                                                                                  '2:常に追加(前データとの差額)
                                                                            
Public GGG As String
                                                                            
Public gstrUnydt    As String * 8  '運用日日付を格納

Public gstrKesidt   As String * 8  '画面で入力した消込日を格納
Public gstrTokseicd As String * 5  '画面で入力した請求先ｺｰﾄﾞを格納
Public gstrKaidt_Fr As String * 8  '画面で入力した回収予定日(開始)を格納
Public gstrKaidt_To As String * 8  '画面で入力した回収予定日(終了)を格納
Public gstrFridt    As String * 8  '画面で入力した振込期日を格納

Public Const TesuryoID  As String = "05"    '★手数料額のｻﾏﾘID
Public Const SyohiID    As String = "09"    '★消費税額のｻﾏﾘID

'スプレッドの列名と番号の関連付け
Public Const COL_CHK        As Integer = 1      'ﾁｪｯｸﾎﾞｯｸｽ
Public Const COL_NO         As Integer = 2      'No.
Public Const COL_NXTKB      As Integer = 3      '帳端
Public Const COL_HYUDNDT    As Integer = 4      '売上日(スラッシュ付き)
Public Const COL_HYJDNNO    As Integer = 5      '受注日(行番号付き)
Public Const COL_HYKAIDT    As Integer = 6      '回収予定日(スラッシュ付き)
Public Const COL_TOKJDNNO   As Integer = 7      '客先注文番号
Public Const COL_TANNM      As Integer = 8      '担当者名
Public Const COL_URIKN      As Integer = 9      '税抜売上金額
Public Const COL_UZEKN      As Integer = 10     '消費税額
Public Const COL_KOMIKN     As Integer = 11     '税込売上金額
Public Const COL_KESIKN     As Integer = 12     '消込額
Public Const COL_MINYUKN    As Integer = 13     '未入金額
Public Const COL_HYFRIDT    As Integer = 14     '振込期日(スラッシュ付き)
Public Const COL_BFKESIKN   As Integer = 15     '消込額(締日前)
Public Const COL_AFKESIKN   As Integer = 16     '消込額(締日後)
Public Const COL_JDNNO      As Integer = 17     '受注番号
Public Const COL_JDNLINNO   As Integer = 18     '受注行番号(3桁)
Public Const COL_UDNDT      As Integer = 19     '売上日
Public Const COL_KESDT      As Integer = 20     '決済日
Public Const COL_TOKCD      As Integer = 21     '得意先ｺｰﾄﾞ
Public Const COL_TOKSEICD   As Integer = 22     '請求先ｺｰﾄﾞ
Public Const COL_TANCD      As Integer = 23     '担当者ｺｰﾄﾞ
Public Const COL_JDNDT      As Integer = 24     '受注日
Public Const COL_TUKKB      As Integer = 25     '通貨区分
Public Const COL_INVNO      As Integer = 26     'ｲﾝﾎﾞｲｽNo.
Public Const COL_FURIKN     As Integer = 27     '海外売上金額
Public Const COL_FRNKB      As Integer = 28     '海外取引区分
Public Const COL_UDNDATNO   As Integer = 29     '売上DATNO
Public Const COL_UDNLINNO   As Integer = 30     '売上LINNO
Public Const COL_MAEUKKB    As Integer = 31     '前受区分
Public Const COL_JDNDATNO   As Integer = 32     '受注DATNO


Public Const COL_BFHYFRIDT  As Integer = 33     '変更前振込期日(スラッシュ付き)
Public Const COL_BFCHECK    As Integer = 34     '変更前ﾁｪｯｸﾎﾞﾀﾝ
Public Const COL_KESIKN_MAE As Integer = 35     '消込前金額

Public Const COL_HENPI      As Integer = 36     '返品フラグ


'明細関連項目を格納する構造体
Private Type TYPE_FR_SSSSUB
    SUB_DKBID       As String * 2
    SUB_DKBNM       As String * 6
    SUB_UPDID       As String * 2
    SUB_DFLDKBCD    As String * 13
    SUB_DKBZAIFL    As String * 1
    SUB_DKBTEGFL    As String * 1
    SUB_DKBFLA      As String * 1
    SUB_DKBFLB      As String * 1
    SUB_DKBFLC      As String * 1
    SUB_KOUZA       As String * 10
    SUB_NYUKN       As String * 9
    SUB_LINCMA      As String * 20
End Type
Public gtypeFR_SUB(2) As TYPE_FR_SSSSUB

'流用分
Public Const gc_DKBSB_NKN   As String = "050"
Public Const gc_DKBSB_KES   As String = "056"
Public strKDNNO             As String
Public strKDNNO_MIN         As String
Public strKDNNO_MAX         As String

Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Long) As Long
'Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long

Global Const SSS_ReTryCnt% = 100             'ログファイルオープンリトライカウント

Global strINIDATNM(4)       As String           'ＩＮＩのシンボル
Global SSS_INIDAT(4)        As String           'ＩＮＩの内容
Global Set_date             As String * 10      'ｶﾚﾝﾀﾞｰWINDOW用
Global SSS_INICnt           As Integer          'INI ファイル最終インデックス
Public WLSDATE_RTNCODE      As String           '日付（yyyy/mm/dd）

'#Start(2003.3.28) ロングファイルネーム環境に対応
Global Const MAX_PATH = 260
'#End(2003.3.28)

Public gs_UPDAUTH   As String   '更新権限
Public gs_PRTAUTH   As String   '印刷権限
Public gs_FILEAUTH  As String   'ファイル出力権限
Public gs_SALTAUTH  As String   '販売単価変更権限
Public gs_HDNTAUTH  As String   '発注単価変更権限
Public gs_SAPMAUTH  As String   '販売計画年初計画修正権限

Public WLSKOZ_RTNCODE As String '勘定口座検索戻り値
Public WLSTBD_RTNCODE As String '入金種別検索戻り値
Public WLSTOKSUB_RTNCODE As String '請求先検索戻り値
Public WLSTOK_RTNCODE As String '得意先検索戻り値

Public GV_SysDate               As String               'ＤＢサーバー日付
Public GV_SysTime               As String               'ＤＢサーバー時刻
Public GV_UNYDate               As String

Type T_G_LB
    tgLB1(16 * 1024) As Byte
    tgLB2(4 * 1024) As Byte 'Pre=16
    'tgLB3(4 * 1024) As Byte
End Type
Global G_LB As T_G_LB

'ファイル構造体初期化用データ
Type DB_CLRDAT
    FILLER As String * 2048      '初期化データ
End Type
Global DB_CLRREC As DB_CLRDAT

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

Public Const gc_strMsgEXCTBZ_ERROR          As String = "2URKET73_034"  '更新異常

'流用分:END
