Option Strict Off
Option Explicit On
Module MAEUKNM_F61
	'
	' スロット名        : 売上基準名称・画面項目スロット
	' ユニット名        : MAEUKNM.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	
	Function MAEUKNM_Derived(ByVal MAEUKKB As Object) As Object
		'UPGRADE_WARNING: オブジェクト MAEUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(MAEUKKB) <> "" Then
			'UPGRADE_WARNING: オブジェクト MAEUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case Trim(MAEUKKB)
				Case "1"
					'UPGRADE_WARNING: オブジェクト MAEUKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					MAEUKNM_Derived = "通常"
				Case "2"
					'UPGRADE_WARNING: オブジェクト MAEUKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					MAEUKNM_Derived = "前受"
			End Select
		Else
			'UPGRADE_WARNING: オブジェクト MAEUKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MAEUKNM_Derived = ""
		End If
	End Function
End Module