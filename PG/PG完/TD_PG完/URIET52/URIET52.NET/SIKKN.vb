Option Strict Off
Option Explicit On
Module SIKKN_F51
	'
	' スロット名        : 営業仕切金額・画面項目スロット
	' ユニット名        : SIKKN.F51
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	'
	
	'売上単価＊売上数量
	Function SIKKN_Derived(ByVal SIKKN As Object, ByVal SIKTK As Object, ByVal URISU As Object, ByRef CP_SIKKN As clsCP) As Object
		'
		'UPGRADE_WARNING: オブジェクト SIKKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SIKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SIKKN_Derived = SIKKN
		'UPGRADE_WARNING: オブジェクト SIKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SIKTK) = "" Or Not IsNumeric(SIKTK) Then Exit Function
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		On Error GoTo OverFlow
		'' 2003/08/28 変更した単価 が 0 の場合前回の金額が残る
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SIKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SIKTK <> 0 Or URISU <> 0 Then
			''If SIKTK <> 0 And URISU <> 0 Then
			'        SIKKN_Derived = SIKTK * URISU                  '1996/08/26 Delete
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SIKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SIKKN_Derived = DCMFRC(SIKTK * URISU, 0, 0) '1996/08/26 Insert
		End If
		Exit Function
OverFlow: 
		CP_SIKKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト SIKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SIKKN_Derived = "??????????????????"
	End Function
End Module