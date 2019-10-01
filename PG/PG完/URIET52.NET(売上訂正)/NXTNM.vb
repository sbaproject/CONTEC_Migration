Option Strict Off
Option Explicit On
Module NXTNM_F51
	'
	' スロット名        : 帳端区分名称・画面項目スロット
	' ユニット名        : NXTNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	
	'商品ファイルより商品名１取得。
	Function NXTNM_Derived(ByVal NXTKB As Object, ByVal ENTDT As Object) As Object
		'    If Not IsNull(NXTKB) Then
		'UPGRADE_WARNING: オブジェクト NXTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NXTKB) <> "" Then
			'If SSSVal(NXTKB) = 1 Or SSSVal(NXTKB) = 2 Then
			'UPGRADE_WARNING: オブジェクト NXTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NXTNM_Derived = Mid(SSS_SSADT.Value, 5, 2) & "/" & Mid(SSS_SSADT.Value, 7, 2) & "請求"
			'End If
		Else
			'UPGRADE_WARNING: オブジェクト NXTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NXTNM_Derived = ""
		End If
	End Function
End Module