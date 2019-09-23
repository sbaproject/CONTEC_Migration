Option Strict Off
Option Explicit On
Module FURIKN_F52
	'
	' スロット名        : 売上金額・画面項目スロット
	' ユニット名        : FURIKN.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/30
	' 使用プログラム名  : URIET61/URIET62
	'
	
	'売上単価＊売上数量
	Function FURIKN_Derived(ByVal FURIKN As Object, ByVal FURITK As Object, ByVal URISU As Object, ByVal HINID As Object, ByRef CP_FURIKN As clsCP) As Object
		'
		'【通販】及び【システムで諸口商品】時、算出処理回避
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: オブジェクト FURIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FURIKN_Derived = FURIKN
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト FURIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FURIKN_Derived = FURIKN
		'UPGRADE_WARNING: オブジェクト FURITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(FURITK) = "" Or Not IsNumeric(FURITK) Then Exit Function
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		On Error GoTo OverFlow
		'' 2003/08/28 変更した単価 が 0 の場合前回の金額が残る
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FURITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If FURITK <> 0 Or URISU <> 0 Then
			''If FURITK <> 0 And URISU <> 0 Then
			'       FURIKN_Derived = FURITK * URISU                     '1996/08/26 Delete
			''''''''FURIKN_Derived = DCMFRC(FURITK * URISU, 0, 0)       '1996/08/26 Insert
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FURITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FURIKN_Derived = DCMFRC(FURITK * URISU, 5, -4) '2007.02.08
		End If
		Exit Function
OverFlow: 
		CP_FURIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト FURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FURIKN_Derived = "??????????????????"
	End Function
End Module