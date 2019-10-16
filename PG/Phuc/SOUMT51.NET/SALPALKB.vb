Option Strict Off
Option Explicit On
Module SALPALKB_F51
	'
	' スロット名         : 販売計画対象区分・画面項目スロット
	' ユニット名         : SALPALKB.F51
	' 記述者             : Standard Library
	' 作成日付           : 2006/08/28
	' 使用プログラム名   : SOUMT51
	'
	
	Function SALPALKB_CheckC(ByRef SALPALKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SALPALKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SALPALKB_CheckC = 0
		Select Case SALPALKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: オブジェクト SALPALKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SALPALKB = "1"
		End Select
		
	End Function
	'
	'Function SALPALKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SALPALKB_InitVal = " "
	'    Else
	'     SALPALKB_InitVal = "1"
	'    End If
	'
	'End Function
	Function SALPALKB_DerivedC(ByVal SALPALKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト SALPALKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(SALPALKB) = "" Then
				
				'UPGRADE_WARNING: オブジェクト SALPALKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SALPALKB_DerivedC = "1"
			End If
		End If
	End Function
End Module