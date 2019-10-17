Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'メッセージコード
	'共通
	Public Const gc_strMsgTHSFP61_I_001 As String = "1THSFP61_001" '○実行してよろしいですか？
	Public Const gc_strMsgTHSFP61_I_002 As String = "1THSFP61_002" '○終了してよろしいですか？
	Public Const gc_strMsgTHSFP61_I_003 As String = "1THSFP61_003" '○処理を終了しました。
	Public Const gc_strMsgTHSFP61_I_004 As String = "1THSFP61_004" '○処理を中断しました。
	Public Const gc_strMsgTHSFP61_I_005 As String = "1THSFP61_005" '○ファイルが存在します。上書きしてもよろしいですか?
	Public Const gc_strMsgTHSFP61_I_006 As String = "1THSFP61_006" '○抽出したデータをファイルに出力します。
	Public Const gc_strMsgTHSFP61_I_007 As String = "1THSFP61_007" '○終了します。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTHSFP61_E_008 As String = "2THSFP61_008" '●入力値が許容範囲外です。
	Public Const gc_strMsgTHSFP61_E_009 As String = "2THSFP61_009" '●該当するデータが存在しません。
	Public Const gc_strMsgTHSFP61_E_010 As String = "2THSFP61_010" '●ＤＢ参照エラーが発生しました。
	Public Const gc_strMsgTHSFP61_E_011 As String = "2THSFP61_011" '●ＣＳＶ出力処理でエラーが発生しました。
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(7)
		AE_PSIC = 8
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_THSCD 3303 code 1 - A L N 0 - - 1 -"
		AE_PSI(3) = "HD_FRNKB 3303 code 1 - A L N 0 - - 1 -"
		AE_PSI(4) = "HD_STTTOKCD 2202 code 5 - A L N S - - 1 -"
		AE_PSI(5) = "HD_STTTOKNM 0000 code 40 - A L N U - - 1 -"
		AE_PSI(6) = "HD_ENDTOKCD 2202 code 5 - A L N S - - 1 -"
		AE_PSI(7) = "HD_ENDTOKNM 0000 code 40 - A L N U - - 1 -"
	End Sub
End Module