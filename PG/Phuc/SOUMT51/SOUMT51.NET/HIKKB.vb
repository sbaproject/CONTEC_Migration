Option Strict Off
Option Explicit On
Module HIKKB_F51
	'
	' スロット名         : 引当対象区分・画面項目スロット
	' ユニット名         : HIKKB.F51
	' 記述者             : Standard Library
	' 作成日付           : 2006/08/28
	' 使用プログラム名   : SOUMT51
	'
	
	Function HIKKB_CheckC(ByRef HIKKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト HIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HIKKB_CheckC = 0
		Select Case HIKKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: オブジェクト HIKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HIKKB = "1"
		End Select
		
	End Function
	'
	'Function HIKKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     HIKKB_InitVal = " "
	'    Else
	'     HIKKB_InitVal = "1"
	'    End If
	'
	'End Function
	Function HIKKB_DerivedC(ByVal HIKKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト HIKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(HIKKB) = "" Then
				
				'UPGRADE_WARNING: オブジェクト HIKKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HIKKB_DerivedC = "1"
			End If
		End If
	End Function
End Module