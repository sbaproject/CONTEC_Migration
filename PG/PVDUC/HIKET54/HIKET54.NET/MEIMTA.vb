Option Strict Off
Option Explicit On
Module MEIMTA_DBM
	'==========================================================================
	'   MEIMTA.DBM   名称マスタ                       UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_MEIMTA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '伝票削除区分          0
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public KEYCD() As Char 'キー                  000
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEIKMKNM() As Char '項目名
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEICDA() As Char 'コード１
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public MEICDB() As Char 'コード２
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public MEINMA() As Char '名称１
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEINMB() As Char '名称２
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEINMC() As Char '名称３
		Dim MEISUA As Decimal '数値項目１            ###,###,##0.0000;;#
		Dim MEISUB As Decimal '数値項目２            ###,##0.0000;;#
		Dim MEISUC As Decimal '数値項目３            ###,##0.0000;;#
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBA() As Char '区分１
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBB() As Char '区分２
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBC() As Char '区分３
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public DSPORD() As Char '表示順序
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public RELFL() As Char '連携フラグ            X
		' === 20061227 === UPDATE S - ACE)Nagasawa
		'    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
		'    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
		'    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'    WRTFSTTM       As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
		'    WRTFSTDT       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '初回登録担当者ID
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '初回登録クライアントID
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '更新担当者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '更新クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char 'バッチ更新担当者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char 'バッチ更新クライアントID
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(7),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=7)> Public PGID() As Char 'ﾌﾟﾛｸﾞﾗﾑID
		' === 20061227 === UPDATE E -
	End Structure
	Public DB_MEIMTA As TYPE_DB_MEIMTA
	Public DBN_MEIMTA As Short
	
	'名称マスタ検索画面パラメータ
	Public WLSMEI_KEYCD As String 'キー
	
	'名称マスタ検索戻り値
	Public WLSMEI_RTNMEICDA As String 'コード１
	Public WLSMEI_RTNMEINMA As String '名称１
	'20130701 ADD START 新通販連携対応
	Public WLSMEI_RTNMEINMB As String '名称２
	'20130701 ADD END
	
	'ADD START FKS)INABA 2009/07/17 ****************************************************************************
	'連絡票№FC09071701
	Public WK_MEICDA As String
	'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub DB_MEIMTA_Clear
	'   概要：  名称マスタ構造体クリア
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub DB_MEIMTA_Clear(ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
		Dim Clr_DB_MEIMTA As TYPE_DB_MEIMTA
		'UPGRADE_WARNING: オブジェクト pot_DB_MEIMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_DB_MEIMTA = Clr_DB_MEIMTA
	End Sub
	
	' === 20060920 === INSERT S - ACE)Sejima 直送対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub DB_MEIMTA_SetData
	'   概要：  名称マスタ構造体データ退避
	'   引数：　なし
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
		
		'データ退避
		With pot_DB_MEIMTA
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.KEYCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEYCD", "") 'キー
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEIKMKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKMKNM", "") '項目名
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEICDA = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDA", "") 'コード１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEICDB = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDB", "") 'コード２
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEINMA = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMA", "") '名称１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEINMB = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMB", "") '名称２
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEINMC = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMC", "") '名称３
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEISUA = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUA", 0) '数値項目１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEISUB = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUB", 0) '数値項目２
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEISUC = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUC", 0) '数値項目３
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEIKBA = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBA", "") '区分１
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEIKBB = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBB", "") '区分２
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MEIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBC", "") '区分３
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.DSPORD = CF_Ora_GetDyn(pin_Usr_Ody, "DSPORD", "") '表示順序
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '連携フラグ
			' === 20061227 === UPDATE S - ACE)Nagasawa
			'            .OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "")               '最終作業者コード
			'            .CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "")               'クライアントＩＤ
			'            .WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "")               'タイムスタンプ（時間）
			'            .WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "")               'タイムスタンプ（日付）
			'            .WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
			'            .WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "")         'タイムスタンプ（登録日）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録担当者ID
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録クライアントID
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '更新担当者コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '更新クライアントＩＤ
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'バッチ更新担当者コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'バッチ更新クライアントID
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'ﾌﾟﾛｸﾞﾗﾑID
			' === 20061227 === UPDATE E -
		End With
		
	End Sub
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEIM_SEARCH
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEICDA : コード１
	'           pot_DB_MEIMTA : 検索結果
	'           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEICDB As Object = Nothing) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIM_SEARCH
		
		DSPMEIM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(pin_strMEICDB) = False Then
			'UPGRADE_WARNING: オブジェクト pin_strMEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
		End If
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			DSPMEIM_SEARCH = 1
			GoTo END_DSPMEIM_SEARCH
		End If
		
		'取得データ退避
		' === 20060920 === UPDATE S - ACE)Sejima
		'D        With pot_DB_MEIMTA
		'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
		'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
		'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
		'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
		'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
		'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
		'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
		'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
		'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
		'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
		'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
		'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
		'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
		'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
		'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
		'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
		'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
		'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
		'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
		'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
		'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
		'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
		'D        End With
		' === 20060920 === UPDATE ↓
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		' === 20060920 === UPDATE E
		
		DSPMEIM_SEARCH = 0
		
END_DSPMEIM_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIM_SEARCH: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEINMA_SEARCH_A1
	'   概要：  名称マスタ検索(名称１のあいまい検索）
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEINMA : 名称１
	'           pot_DB_MEIMTA : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMA_SEARCH_A1(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, Optional ByRef pin_strMEICDA As Object = Nothing) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMA_SEARCH_A1
		
		DSPMEINMA_SEARCH_A1 = 9
		
		strSQL = ""
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
		'ADD START FKS)INABA 2009/07/17 ****************************************************************************
		'連絡票№FC09071701
		'UPGRADE_WARNING: オブジェクト pin_strMEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(pin_strMEICDA) = True Or Trim(pin_strMEICDA) = "" Then
		Else
			'UPGRADE_WARNING: オブジェクト pin_strMEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
		End If
		strSQL = strSQL & "   ORDER BY MEICDA "
		'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
		
		'件数取得
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		If intData = 0 Then
			'取得データなし
			DSPMEINMA_SEARCH_A1 = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			DSPMEINMA_SEARCH_A1 = 1
			GoTo END_DSPMEINMA_SEARCH_A1
		End If
		
		'取得データ退避
		ReDim pot_DB_MEIMTA(intData)
		intIdx = 1
		Do Until CF_Ora_EOF(Usr_Ody_LC) = True
			' === 20060920 === UPDATE S - ACE)Sejima
			'D            With pot_DB_MEIMTA(intIdx)
			'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
			'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
			'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
			'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
			'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
			'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
			'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
			'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
			'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
			'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
			'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
			'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
			'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
			'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
			'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
			'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
			'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
			'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
			'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
			'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
			'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
			'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
			'D            End With
			' === 20060920 === UPDATE ↓
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intIdx))
			' === 20060920 === UPDATE E
			intIdx = intIdx + 1
			Call CF_Ora_MoveNext(Usr_Ody_LC)
		Loop 
		
		DSPMEINMA_SEARCH_A1 = 0
		
END_DSPMEINMA_SEARCH_A1: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMA_SEARCH_A1: 
		
	End Function
	
	'ADD START FKS)INABA 2009/07/17 ****************************************************************************
	'連絡票№FC09071701
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEINMA_SEARCH_A2
	'   概要：  名称マスタ検索(名称１でのあいまい検索(存在チェックのみ)）
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEINMA : 名称１
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMA_SEARCH_A2(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMA_SEARCH_A2
		
		DSPMEINMA_SEARCH_A2 = 9
		
		strSQL = ""
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
		strSQL = strSQL & "   ORDER BY MEICDA "
		
		'件数取得
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		If intData = 0 Then
			'取得データなし
			DSPMEINMA_SEARCH_A2 = 1
			Exit Function
		End If
		
		DSPMEINMA_SEARCH_A2 = 0
		
END_DSPMEINMA_SEARCH_A2: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMA_SEARCH_A2: 
		
	End Function
	'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEINMB_SEARCH
	'   概要：  名称マスタ検索(名称２の検索）
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEINMB : 名称２
	'           pot_DB_MEIMTA : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMB_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEINMB As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMB_SEARCH
		
		DSPMEINMB_SEARCH = 9
		
		strSQL = ""
		strSQL = " Select * " & strSQL
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMB =    '" & CF_Ora_String(pin_strMEINMB, 20) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			DSPMEINMB_SEARCH = 1
			GoTo END_DSPMEINMB_SEARCH
		End If
		
		'取得データ退避
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			' === 20060920 === UPDATE S - ACE)Sejima 直送対応
			'D            With pot_DB_MEIMTA
			'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
			'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
			'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
			'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
			'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
			'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
			'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
			'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
			'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
			'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
			'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
			'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
			'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
			'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
			'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
			'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
			'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
			'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
			'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
			'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
			'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
			'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
			'D            End With
			' === 20060920 === UPDATE ↓
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
			' === 20060920 === UPDATE E
		End If
		
		DSPMEINMB_SEARCH = 0
		
END_DSPMEINMB_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMB_SEARCH: 
		
	End Function
	
	' === 20060920 === INSERT S - ACE)Sejima 直送対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEIKBA_SEARCH
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEIKBA : 区分１
	'           pot_DB_MEIMTA : 検索結果
	'           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIKBA_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEIKBA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIKBA_SEARCH
		
		DSPMEIKBA_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			DSPMEIKBA_SEARCH = 1
			GoTo END_DSPMEIKBA_SEARCH
		End If
		
		'取得データ退避
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		
		DSPMEIKBA_SEARCH = 0
		
END_DSPMEIKBA_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIKBA_SEARCH: 
		
	End Function
	' === 20060920 === INSERT E
	
	' === 20060822 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_KNNOUGYO
	'   概要：  今回納期－納入業者（納期情報登録用）取得
	'   引数：  pm_All           : 画面情報
	'           pot_intMaxLinNo  : 取得行№
	'   戻値：  0 : 正常　1 : 該当データなし　9 : 異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_KNNOUGYO(ByVal pin_strBINCD As String, ByRef pot_strKNNOUGYO As String) As Short
		
		Dim strKNNOUGYO As String
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim Ret_Value As Short
		
		On Error GoTo CF_Get_KNNOUGYO_Err
		
		'いったん「異常」
		Ret_Value = 9
		'いったん「なし」
		strKNNOUGYO = gc_strKNNOUGYO_NO
		
		If Trim(pin_strBINCD) <> "" Then
			
			'便名コードの入力がある場合、同コードをキーとして名称マスタを検索
			Call DB_MEIMTA_Clear(Mst_Inf)
			intRet = DSPMEIM_SEARCH(gc_strKEYCD_BINCD, pin_strBINCD, Mst_Inf)
			
			If intRet = 0 Then
				If Trim(Mst_Inf.MEINMB) <> "" Then
					'データが取得でき、かつ名称２に値が入っている
					'　⇒その値を返す（＝納入業者）
					strKNNOUGYO = Trim(Mst_Inf.MEINMB)
					
				End If
			End If
			
		End If
		
		'「正常」
		Ret_Value = 0
		
CF_Get_KNNOUGYO_End: 
		'取得したコードを返す
		pot_strKNNOUGYO = strKNNOUGYO
		
		CF_Get_KNNOUGYO = Ret_Value
		Exit Function
		
CF_Get_KNNOUGYO_Err: 
		GoTo CF_Get_KNNOUGYO_End
		
	End Function
	' === 20060822 === INSERT E
	
	' === 20060921 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_CRM_RsnCnKb
	'   概要：  受注（ｷｬﾝｾﾙ）理由取得（CRM用）
	'   引数：　pin_strKEYCD   : キー
	'           pin_strMEICDA  : コード１
	'           pot_strRsnCnKb : 理由ｺｰﾄﾞ（名称３）
	'           pot_strRsnCnNm : 理由名称（名称２）
	'   戻値：　0:正常  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CRM_RsnCnKb(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strRsnCnKb As String, ByRef pot_strRsnCnNm As String) As Short
		
		Dim Ret_Value As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		On Error GoTo CF_Get_CRM_RsnCnKb_End
		
		CF_Get_CRM_RsnCnKb = 9
		
		'いったんエラー扱い
		Ret_Value = 9
		
		'戻す変数を初期化
		pot_strRsnCnKb = ""
		pot_strRsnCnNm = ""
		
		If DSPMEIM_SEARCH(pin_strKEYCD, pin_strMEICDA, Mst_Inf) = 0 Then
			'論理削除チェック
			If Mst_Inf.DATKB = "9" Then
			Else
				'取得値を格納
				pot_strRsnCnKb = Trim(Mst_Inf.MEINMC)
				pot_strRsnCnNm = Trim(Mst_Inf.MEINMB)
			End If
		End If
		
		'CRM編集用に加工
		pot_strRsnCnKb = CF_ZeroLenFormat(pot_strRsnCnKb, 6, True)
		pot_strRsnCnNm = CF_Ctr_AnsiLeftB(pot_strRsnCnNm & Space(40), 40)
		
		'正常扱い
		Ret_Value = 0
		
CF_Get_CRM_RsnCnKb_End: 
		'戻り値を返す
		CF_Get_CRM_RsnCnKb = Ret_Value
		
	End Function
	' === 20060921 === INSERT E
	
	' === 20061110 === INSERT S - ACE)Nagasawa セットアップ仕変更対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEIM_SEARCH_ALL
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pot_DB_MEIMTA : 検索結果（配列）
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIM_SEARCH_ALL(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim strSQL_Where As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIM_SEARCH_ALL
		
		DSPMEIM_SEARCH_ALL = 9
		
		'戻り値のクリア
		Erase pot_DB_MEIMTA
		
		strSQL = ""
		strSQL = strSQL & " Select Count(*) As CNTDATA"
		
		strSQL_Where = ""
		strSQL_Where = strSQL_Where & "   from MEIMTA "
		strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		strSQL = strSQL & strSQL_Where
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		'件数取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		'検索
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & strSQL_Where
		
		ReDim pot_DB_MEIMTA(intData)
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		'取得データ退避
		intData = 1
		Do Until CF_Ora_EOF(Usr_Ody_LC) = True
			
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))
			
			Call CF_Ora_MoveNext(Usr_Ody_LC)
			intData = intData + 1
		Loop 
		
		DSPMEIM_SEARCH_ALL = 0
		
END_DSPMEIM_SEARCH_ALL: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIM_SEARCH_ALL: 
		
	End Function
	' === 20061110 === INSERT E -
	
	' === 20070213 === INSERT S - ACE)Nagasawa システム受注で機器受注を入力可とする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEIKB_SEARCH
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pot_DB_MEIMTA : 検索結果
	'           pin_strMEIKBA : 区分１（省略された場合、検索条件に含めない）
	'           pin_strMEIKBB : 区分２（省略された場合、検索条件に含めない）
	'           pin_strMEIKBC : 区分３（省略された場合、検索条件に含めない）
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：  区分での検索
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIKB_SEARCH(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEIKBA As String = "", Optional ByVal pin_strMEIKBB As String = "", Optional ByVal pin_strMEIKBC As String = "") As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIKB_SEARCH
		
		DSPMEIKB_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		'区分１
		If Trim(pin_strMEIKBA) <> "" Then
			strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
		End If
		
		'区分２
		If Trim(pin_strMEIKBB) <> "" Then
			strSQL = strSQL & "   and  MEIKBB = '" & pin_strMEIKBB & "' "
		End If
		
		'区分３
		If Trim(pin_strMEIKBC) <> "" Then
			strSQL = strSQL & "   and  MEIKBC = '" & pin_strMEIKBC & "' "
		End If
		
		'並び順
		strSQL = strSQL & "  Order By KEYCD, MEICDA "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			DSPMEIKB_SEARCH = 1
			GoTo END_DSPMEIKB_SEARCH
		End If
		
		'取得データ退避
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		
		DSPMEIKB_SEARCH = 0
		
END_DSPMEIKB_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIKB_SEARCH: 
		
	End Function
	' === 20070213 === INSERT E -
	
	' === 20130719 === INSERT S - FWEST)Koroyasau エンドユーザ対応
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function ENDUSRNM_SEARCH
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD     : キー１
	'           pin_strMEICDA    : コード
	'           pot_strENDUSRNM  : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function ENDUSRNM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strENDUSRNM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_ENDUSRNM_SEARCH
		
		ENDUSRNM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strMEICDA) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データなし
			ENDUSRNM_SEARCH = 1
			GoTo END_ENDUSRNM_SEARCH
		End If
		
		'取得データ退避
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
		
		ENDUSRNM_SEARCH = 0
		
END_ENDUSRNM_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_ENDUSRNM_SEARCH: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function ENDUSRNM_SEARCH2
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pin_strMEINM  : 名称
	'           pot_DB_MEIMTA : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function ENDUSRNM_SEARCH2(ByVal pin_strKEYCD As String, ByVal pin_strMEINM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_ENDUSRNM_SEARCH2
		
		ENDUSRNM_SEARCH2 = 9
		
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        Rtrim(MEINMA) "
		strSQL = strSQL & "        , Rtrim(MEINMB) "
		strSQL = strSQL & "        , Rtrim(MEINMC) "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC)  = '" & Trim(pin_strMEINM) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
			'取得データなし
			ENDUSRNM_SEARCH2 = 1
			GoTo END_ENDUSRNM_SEARCH2
		End If
		
		ENDUSRNM_SEARCH2 = 0
		
END_ENDUSRNM_SEARCH2: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_ENDUSRNM_SEARCH2: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RPTTKA_CHK_SEARCH
	'   概要：  名称マスタ検索
	'   引数：  pin_strMEINM  : 名称
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RPTTKA_CHK_SEARCH(ByVal pin_strMEINM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_RPTTKA_CHK_SEARCH
		
		RPTTKA_CHK_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select MEINMA "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & gc_strKEYCD_YUKOKGN & "' "
		strSQL = strSQL & "   and  MEINMA  = '" & Trim(pin_strMEINM) & "' "
		strSQL = strSQL & "   and  MEIKBA  = '" & gc_strRPTTKA_ON & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
			'取得データなし
			RPTTKA_CHK_SEARCH = 1
			GoTo END_RPTTKA_CHK_SEARCH
		End If
		
		RPTTKA_CHK_SEARCH = 0
		
END_RPTTKA_CHK_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_RPTTKA_CHK_SEARCH: 
		
	End Function
	' === 20130719 === INSERT E -
End Module