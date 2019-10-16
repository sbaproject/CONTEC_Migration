Option Strict Off
Option Explicit On
Module SOUKB_F51
	'
	' スロット名         : 倉庫種別選択・画面項目スロット
	' ユニット名         : SOUKB.F51
	' 記述者             : Standard Library
	' 作成日付           : 2006/05/29
	' 使用プログラム名   : SOUMT51
	'
	
	Function SOUKB_CheckC(ByRef SOUKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUKB_CheckC = 0
		Select Case SOUKB
			Case "1", "2"
			Case Else
				'UPGRADE_WARNING: オブジェクト SOUKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUKB = "1"
		End Select
		
	End Function
	'
	'Function SOUKB_InitVal(ByVal SOUCD, ByVal De_Index As Integer)
	'    If Trim$(SOUCD) = "" Then
	'     SOUKB_InitVal = " "
	'    Else
	'     SOUKB_InitVal = "1"
	'    End If
	'
	'End Function
	Function SOUKB_DerivedC(ByVal SOUKB As Object, ByVal SOUCD As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト SOUKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(SOUKB) = "" Then
				
				'UPGRADE_WARNING: オブジェクト SOUKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUKB_DerivedC = "1"
			End If
		End If
	End Function
End Module