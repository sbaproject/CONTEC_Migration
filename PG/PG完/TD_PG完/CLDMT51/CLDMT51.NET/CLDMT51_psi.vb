Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	''================================================================================
	'☆　画面ボディ部の行単位の業務情報　　　　　☆
	'☆　　Cls_Dsp_Body_Row_Infとの互換性を　　　☆
	'☆　　共通の全てのＰＧで宣言する　　　　　　☆
	'☆　　そのため以下の｢Dummy｣は必須！！ 　　　☆
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String 'ダミー
		Dim Selected As String '選択/非選択
		Dim DATKB As String '伝票削除区分
		Dim CLDDT As String '日付
		Dim CLDWKKB As String '曜日
		Dim CLDHLKB As String '祝日
		Dim SLSMDD As String '営業通算日数
		Dim PRDKDDD As String '生産稼働日数
		Dim DTBKDDD As String '物流稼働日数
		Dim CLDSMDD As String '暦日通算日数
		Dim SLDKB As String '営業日区分
		Dim BNKKDKB As String '銀行稼動区分
		Dim PRDKDKB As String '生産稼動区分
		Dim DTBKDKB As String '物流稼動区分
		'2007/12/27 add-str T.KAWAMUKAI 2007/12/17 del M.SUEZAWA
		'''    WRTTM           As String       '更新時間
		'''    WRTDT           As String       '更新日付
		'''    UWRTTM          As String       'バッチ時間
		'''    UWRTDT          As String       'バッチ日付
		'2007/12/27 add-end T.KAWAMUKAI
		' === 20081001 === INSERT S - RISE)Izumi
		'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '最終作業者コード（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char 'クライアントＩＤ（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		' === 20081001 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'メッセージコード
	'固定値登録
	Public Const gc_strMsgCLDMT51_E_001 As String = "2CLDMT51_001" '入力区分が違います。
	Public Const gc_strMsgCLDMT51_E_002 As String = "2CLDMT51_002" '該当するデータが存在しません。
	Public Const gc_strMsgCLDMT51_A_003 As String = "1CLDMT51_003" '終了してよろしいですか？
	Public Const gc_strMsgCLDMT51_A_004 As String = "1CLDMT51_004" '更新してよろしいですか？
	Public Const gc_strMsgCLDMT51_E_005 As String = "2CLDMT51_005" '処理を終了しました｡
	Public Const gc_strMsgCLDMT51_E_006 As String = "2CLDMT51_006" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgCLDMT51_E_007 As String = "2CLDMT51_007" 'システムエラー
	Public Const gc_strMsgCLDMT51_E_008 As String = "2CLDMT51_008" '明細行に登録するデータがありません。
	Public Const gc_strMsgCLDMT51_A_009 As String = "1CLDMT51_009" '未登録のデータが存在します。更新を行います。
	Public Const gc_strMsgCLDMT51_E_010 As String = "2CLDMT51_010" '登録年月が変更されているため更新できません。
	Public Const gc_strMsgCLDMT51_A_011 As String = "1CLDMT51_011" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgCLDMT51_E_012 As String = "2CLDMT51_012" '更新権限がありません。
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module