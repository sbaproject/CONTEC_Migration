Option Strict Off
Option Explicit On
Module SSSVALUE
	
	'--------------------
	'■変数や定数の宣言部
	'--------------------
	
	'流用分
	Public Const SSS_PrgId As String = "URKET53"
	Public Const SSS_PrgNm As String = "入金消込(個別/全体)"
	
	Public SSS_CLTID As New VB6.FixedLengthString(5)
	Public SSS_OPEID As New VB6.FixedLengthString(8)
	'流用分:END
	
	Public Const SSS_SubWindowNm As String = "差額入金登録"
	
	Public Const OPTION_SHOW_FLAG As Boolean = True '★オプション項目を表示するかどうかのﾌﾗｸﾞ
	Public Const SHOW_HIDE_COLUMN_FLAG As Boolean = False '★隠し項目を表示するかどうかのﾌﾗｸﾞ(DEBUG用)
	Public Const AUTHORITY_ENABLE As Boolean = True '★権限を有効とするかどうかのﾌﾗｸﾞ
	Public Const UPDATE_MODE As Short = 2 '★NKSTRAの更新モード　1:全データを削除し、追加
	'2:常に追加(前データとの差額)
	
	Public GGG As String
	
	Public gstrUnydt As New VB6.FixedLengthString(8) '運用日日付を格納
	
	Public gstrKesidt As New VB6.FixedLengthString(8) '画面で入力した消込日を格納
	Public gstrTokseicd As New VB6.FixedLengthString(5) '画面で入力した請求先ｺｰﾄﾞを格納
	'// V2.00↓ UPD
	''Public gstrKaidt    As String * 8  '画面で入力した回収予定日を格納
	Public gstrKaidt_Fr As New VB6.FixedLengthString(8) '画面で入力した回収予定日(開始)を格納
	Public gstrKaidt_To As New VB6.FixedLengthString(8) '画面で入力した回収予定日(終了)を格納
	'// V2.00↑ UPD
	Public gstrFridt As New VB6.FixedLengthString(8) '画面で入力した振込期日を格納
	
	Public Const TesuryoID As String = "05" '★手数料額のｻﾏﾘID
	Public Const SyohiID As String = "09" '★消費税額のｻﾏﾘID

    'スプレッドの列名と番号の関連付け
    Public Const COL_CHK As Short = 0 'ﾁｪｯｸﾎﾞｯｸｽ
    Public Const COL_NO As Short = 1 'No.
    Public Const COL_NXTKB As Short = 2 '帳端
    Public Const COL_HYUDNDT As Short = 3 '売上日(スラッシュ付き)
    Public Const COL_HYJDNNO As Short = 4 '受注日(行番号付き)
    Public Const COL_HYKAIDT As Short = 5 '回収予定日(スラッシュ付き)
    Public Const COL_TOKJDNNO As Short = 6 '客先注文番号
    Public Const COL_TANNM As Short = 7 '担当者名
    Public Const COL_URIKN As Short = 8 '税抜売上金額
    Public Const COL_UZEKN As Short = 9 '消費税額
    Public Const COL_KOMIKN As Short = 10 '税込売上金額
    Public Const COL_KESIKN As Short = 11 '消込額
    'Public Const COL_MINYUKN As Short = 12 '未入金額
    'Public Const COL_HYFRIDT As Short = 13 '振込期日(スラッシュ付き)
    Public Const COL_HYFRIDT As Short = 12 '振込期日(スラッシュ付き)

    Public Const COL_MINYUKN As Short = 13 '未入金額

    Public Const COL_BFKESIKN As Short = 14 '消込額(締日前)
    Public Const COL_AFKESIKN As Short = 15 '消込額(締日後)
    Public Const COL_JDNNO As Short = 16 '受注番号
    Public Const COL_JDNLINNO As Short = 17 '受注行番号(3桁)
    Public Const COL_UDNDT As Short = 18 '売上日
    Public Const COL_KESDT As Short = 19 '決済日
    Public Const COL_TOKCD As Short = 20 '得意先ｺｰﾄﾞ
    Public Const COL_TOKSEICD As Short = 21 '請求先ｺｰﾄﾞ
    Public Const COL_TANCD As Short = 22 '担当者ｺｰﾄﾞ
    Public Const COL_JDNDT As Short = 23 '受注日
    Public Const COL_TUKKB As Short = 24 '通貨区分
    Public Const COL_INVNO As Short = 25 'ｲﾝﾎﾞｲｽNo.
    Public Const COL_FURIKN As Short = 26 '海外売上金額
    Public Const COL_FRNKB As Short = 27 '海外取引区分
    Public Const COL_UDNDATNO As Short = 28 '売上DATNO
    Public Const COL_UDNLINNO As Short = 29 '売上LINNO
    Public Const COL_MAEUKKB As Short = 30 '前受区分
    Public Const COL_JDNDATNO As Short = 31 '受注DATNO

    '// V2.00↓ ADD
    Public Const COL_BFHYFRIDT As Short = 32 '変更前振込期日(スラッシュ付き)
    Public Const COL_BFCHECK As Short = 33 '変更前ﾁｪｯｸﾎﾞﾀﾝ
    Public Const COL_KESIKN_MAE As Short = 34 '消込前金額
    '// V2.00↑ ADD
    '// V2.03↓ ADD
    Public Const COL_HENPI As Short = 35 '返品フラグ
    '// V2.03↑ ADD
    '2009/09/15 ADD START RISE)MIYAJIMA
    Public Const COL_SSADT As Short = 36 '締日付
    '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '明細関連項目を格納する構造体
    '2019/04/17 CHG START
    'Private Structure TYPE_FR_SSSSUB
    Public Structure TYPE_FR_SSSSUB
        '2019/04/17 CHG E N D
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public SUB_DKBID As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public SUB_DKBNM As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public SUB_UPDID As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(13), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=13)> Public SUB_DFLDKBCD As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SUB_DKBZAIFL As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SUB_DKBTEGFL As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SUB_DKBFLA As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SUB_DKBFLB As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SUB_DKBFLC As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public SUB_KOUZA As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public SUB_NYUKN As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public SUB_LINCMA As String

    End Structure
    Public gtypeFR_SUB(2) As TYPE_FR_SSSSUB

    '流用分
    Public Const gc_DKBSB_NKN As String = "050"
	Public Const gc_DKBSB_KES As String = "056"
	Public strKDNNO As String
	Public strKDNNO_MIN As String
	Public strKDNNO_MAX As String

    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '2019/04/17 CHG START
    'Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/04/17 CHG E N D
    '2019/04/17 DEL START
    'Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Integer) As Integer
    '2019/04/17 DEL E N D
    'Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long

    Public Const SSS_ReTryCnt As Short = 100 'ログファイルオープンリトライカウント
	
	Public strINIDATNM(4) As String 'ＩＮＩのシンボル
	Public SSS_INIDAT(4) As String 'ＩＮＩの内容
	Public Set_date As New VB6.FixedLengthString(10) 'ｶﾚﾝﾀﾞｰWINDOW用
    Public SSS_INICnt As Short 'INI ファイル最終インデックス
    '2019/04/26 DEL START
    'Public WLSDATE_RTNCODE As String '日付（yyyy/mm/dd）
    '2019/04/26 DEL E N D

    '#Start(2003.3.28) ロングファイルネーム環境に対応
    Public Const MAX_PATH As Short = 260
    '#End(2003.3.28)

    '2019/04/26 DEL START
    'Public gs_UPDAUTH As String '更新権限
    'Public gs_PRTAUTH As String '印刷権限
    'Public gs_FILEAUTH As String 'ファイル出力権限
    'Public gs_SALTAUTH As String '販売単価変更権限
    'Public gs_HDNTAUTH As String '発注単価変更権限
    'Public gs_SAPMAUTH As String '販売計画年初計画修正権限
    '2019/04/26 DEL E N D

    Public WLSKOZ_RTNCODE As String '勘定口座検索戻り値
	Public WLSTBD_RTNCODE As String '入金種別検索戻り値
	Public WLSTOKSUB_RTNCODE As String '請求先検索戻り値
    'Public WLSTOK_RTNCODE As String '得意先検索戻り値

    '2019/04/19 DEL START 仮 AE_CMN.vbと重複してるため
    'Public GV_SysDate As String 'ＤＢサーバー日付
    'Public GV_SysTime As String 'ＤＢサーバー時刻
    'Public GV_UNYDate As String
    '2019/04/19 DEL E N D

    Structure T_G_LB
		<VBFixedArray(16 * 1024)> Dim tgLB1() As Byte
		<VBFixedArray(4 * 1024)> Dim tgLB2() As Byte 'Pre=16
		'tgLB3(4 * 1024) As Byte
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim tgLB1(16 * 1024)
			ReDim tgLB2(4 * 1024)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 G_LB の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public G_LB As T_G_LB
	
	'ファイル構造体初期化用データ
	Structure DB_CLRDAT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(2048),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2048)> Public FILLER() As Char '初期化データ
	End Structure
	Public DB_CLRREC As DB_CLRDAT

    '==========================================================================
    '   SYSTBE       運用ログ定義体                                           =
    '==========================================================================
    'Structure TYPE_DB_SYSTBE
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

    Public Const gc_strMsgEXCTBZ_ERROR As String = "2URKET53_034" '更新異常
	
	'流用分:END
End Module