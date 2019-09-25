Option Strict Off
Option Explicit On
Module SRSCNKB_F51
	'
	' スロット名         : ｼﾘｱﾙｽｷｬﾝ要否選択・画面項目スロット
	' ユニット名         : SRSCNKB.F01
	' 記述者             : Standard Library
	' 作成日付           : 2006/05/29
	' 使用プログラム名   : SOUMT51
	'
	'
	
	Function SRSCNKB_CheckC(ByRef SRSCNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SRSCNKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SRSCNKB_CheckC = 0
		Select Case SRSCNKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: オブジェクト SRSCNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SRSCNKB = "1"
		End Select
	End Function
	'
	'Function SRSCNKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SRSCNKB_InitVal = " "
	'    Else
	'     SRSCNKB_InitVal = "1"
	'    End If
	'End Function
	Function SRSCNKB_DerivedC(ByVal SRSCNKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト SRSCNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(SRSCNKB) = "" Then
				
				'UPGRADE_WARNING: オブジェクト SRSCNKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SRSCNKB_DerivedC = "1"
			End If
		End If
	End Function
End Module