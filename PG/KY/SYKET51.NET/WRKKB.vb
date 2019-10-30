Option Strict Off
Option Explicit On
Module WRKKB_F51
	'
	' スロット名        : 処理区分・画面項目スロット
	' ユニット名        : WRKKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/16
	' 使用プログラム名  : SYKET51
	'
	Dim NotFirst As Short
	
	Function WRKKB_CheckC(ByRef WRKKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト WRKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WRKKB_CheckC = 0
		'
		Select Case WRKKB
			Case "1"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "1"
			Case "2"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "2"
			Case "3"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "3"
			Case "4"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "4"
			Case "5"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "5"
			Case "6"
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "6"
			Case Else
				'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WRKKB = "1"
		End Select
		'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_WRKKB = WRKKB
	End Function
	
	Function WRKKB_InitVal(ByVal WRKKB As Object) As Object
		'
		If NotFirst = False Then
			NotFirst = True
			'UPGRADE_WARNING: オブジェクト WRKKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WRKKB_InitVal = "1"
		Else
			'UPGRADE_WARNING: オブジェクト WRKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WRKKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WRKKB_InitVal = WRKKB
		End If
		
	End Function
End Module