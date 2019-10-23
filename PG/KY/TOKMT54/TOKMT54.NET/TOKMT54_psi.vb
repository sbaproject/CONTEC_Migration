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
		Dim UPDKB As String 'モード
		Dim DATKB As String '伝票削除区分
		Dim TOKCD As String '得意先コード
		Dim SKHINGRP As String '仕切用商品群
		Dim TRKRNK As String 'ランク
		Dim STTKSTDT As String '開始単価設定日付
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '更新フラグ
		' 2006/11/15  ADD END
		' === 20080926 === INSERT S - RISE)Izumi
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
		' === 20080926 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'メッセージコード
	'得意先別商品ランク登録
	Public Const gc_strMsgTOKMT54_E_001 As String = "2TOKMT54_001" '入力値が許容範囲外です。
	Public Const gc_strMsgTOKMT54_E_002 As String = "2TOKMT54_002" '該当するデータが存在しません。
	Public Const gc_strMsgTOKMT54_E_003 As String = "2TOKMT54_003" '削除済みレコードです。
	Public Const gc_strMsgTOKMT54_E_004 As String = "2TOKMT54_004" 'このコードは使用できません。
	Public Const gc_strMsgTOKMT54_E_005 As String = "2TOKMT54_005" '明細行に登録するデータがありません。
	Public Const gc_strMsgTOKMT54_A_006 As String = "1TOKMT54_006" '終了してよろしいですか？
	Public Const gc_strMsgTOKMT54_E_007 As String = "2TOKMT54_007" '仕切用商品群は必須入力項目です。
	Public Const gc_strMsgTOKMT54_A_008 As String = "1TOKMT54_008" '更新してよろしいですか？
	Public Const gc_strMsgTOKMT54_E_009 As String = "2TOKMT54_009" '処理を終了しました｡
	Public Const gc_strMsgTOKMT54_E_010 As String = "2TOKMT54_010" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgTOKMT54_E_011 As String = "2TOKMT54_011" 'システムエラー
	Public Const gc_strMsgTOKMT54_E_012 As String = "2TOKMT54_012" '適用日は必須入力項目です。
	Public Const gc_strMsgTOKMT54_E_013 As String = "2TOKMT54_013" 'ランクは必須入力項目です。
	Public Const gc_strMsgTOKMT54_E_014 As String = "2TOKMT54_014" '検索条件を入力して下さい。
	Public Const gc_strMsgTOKMT54_E_015 As String = "2TOKMT54_015" '日付に誤りがあります。修正してください。
	Public Const gc_strMsgTOKMT54_E_016 As String = "2TOKMT54_016" '該当する仕切用商品群が存在しません。
	Public Const gc_strMsgTOKMT54_E_017 As String = "2TOKMT54_017" '該当するランクが存在しません。
	Public Const gc_strMsgTOKMT54_A_018 As String = "1TOKMT54_018" '未登録のデータが存在します。更新を行います。
	Public Const gc_strMsgTOKMT54_A_019 As String = "1TOKMT54_019" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgTOKMT54_A_020 As String = "1TOKMT54_020" '現在の編集内容は破棄されます。よろしいですか？
	Public Const gc_strMsgTOKMT54_E_021 As String = "2TOKMT54_021" 'これ以降のデータはありません。
	Public Const gc_strMsgTOKMT54_E_022 As String = "2TOKMT54_022" '見出部の入力がまだのため明細行の入力ができません。
	' 2006/11/15  ADD START  KUMEDA
	Public Const gc_strMsgTOKMT54_E_023 As String = "2TOKMT54_023" '代表会社ではありません。
	' 2006/11/15  ADD END
	Public Const gc_strMsgTOKMT54_E_024 As String = "2TOKMT54_024" '更新権限がありません。
	'''' ADD 2008/06/05  FKS) S.Nakajima    Start
	Public Const gc_strMsgTOKMT54_E_025 As String = "2TOKMT54_025" '同一得意先に対し、複数のランクは登録できません。
	'''' ADD 2008/06/05  FKS) S.Nakajima    End
	'''' ADD 2008/06/10  FKS) S.Nakajima    Start
	Public Const gc_strMsgTOKMT54_E_026 As String = "2TOKMT54_026" '適用日が不正です。当日以降を入力して下さい。
	'''' ADD 2008/06/10  FKS) S.Nakajima    End
	' === 20080910 === INSERT S - RISE)Izumi
	Public Const gc_strMsgTOKMT54_E_901 As String = "2TOKMT54_901" '他のプログラムで更新されたため、更新できません。
	Public Const gc_strMsgTOKMT54_E_902 As String = "2TOKMT54_902" '他のプログラムで更新されたため、削除できません。
	' === 20080910 === INSERT E - RISE)Izumi
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module