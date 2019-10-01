Option Strict Off
Option Explicit On
Module GNKKN_F04
	'
	' スロット名        : 原価金額・画面項目スロット
	' ユニット名        : GNKKN.F04
	' 記述者            : Standard Library
	' 作成日付          : 1997/05/24
	' 使用プログラム名  : URIET01, URIET02
	
	'原価単価＊売上数量
	Function GNKKN_Derived(ByVal GNKKN As Object, ByVal GNKTK As Object, ByVal URISU As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト GNKKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト GNKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GNKKN_Derived = GNKKN
		'UPGRADE_WARNING: オブジェクト GNKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(GNKTK) = "" Or Not IsNumeric(GNKTK) Then Exit Function
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		'' 2003/08/28 変更した単価 が 0 の場合前回の金額が残る
		''If GNKTK <> 0 And URISU <> 0 Then
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト GNKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GNKKN_Derived = DCMFRC(GNKTK * URISU, 5, 0)
		''End If
	End Function
End Module