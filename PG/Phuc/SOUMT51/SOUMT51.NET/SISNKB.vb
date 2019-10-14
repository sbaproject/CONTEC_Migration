Option Strict Off
Option Explicit On
Module SISNKB_F51
	'
	' スロット名        : 資産元区分・画面項目スロット
	' ユニット名        : SISNKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/13
	' 使用プログラム名  : SOUMT51
	'
	
	Function SISNKB_CheckC(ByRef SISNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SISNKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SISNKB_CheckC = 0
		'
		Select Case SISNKB
			Case "0", "1"
			Case Else
				'UPGRADE_WARNING: オブジェクト SISNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SISNKB = "0"
		End Select
		'UPGRADE_WARNING: オブジェクト SISNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SISNKB = "1" Then '他社
			Call AE_InOutModeN_SSSMAIN("SOUTRICD", "3303")
		Else
			Call AE_InOutModeN_SSSMAIN("SOUTRICD", "2202")
		End If
	End Function
	'
	'Function SISNKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SISNKB_InitVal = " "
	'    Else
	'     SISNKB_InitVal = "0"
	'    End If
	'End Function
	Function SISNKB_DerivedC(ByVal SISNKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト SISNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(SISNKB) = "" Then
				
				'UPGRADE_WARNING: オブジェクト SISNKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SISNKB_DerivedC = "0"
			End If
		Else
			'UPGRADE_WARNING: オブジェクト SISNKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SISNKB_DerivedC = ""
		End If
	End Function
End Module