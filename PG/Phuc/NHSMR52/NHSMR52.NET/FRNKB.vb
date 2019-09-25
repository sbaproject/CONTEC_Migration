Option Strict Off
Option Explicit On
Module FRNKB_F71
	'
	' スロット名        : 海外取引区分画面項目スロット
	' ユニット名        : FRNKB.F71
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : NHSMR51
	'
	' 備考              : 0:国内
	'                     1:海外
	
	Function FRNKB_CheckC(ByRef FRNKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト FRNKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FRNKB_CheckC = 0
		Select Case FRNKB
			Case "0", "1"
			Case Else
				'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				FRNKB = "0"
		End Select
	End Function
	
	Function FRNKB_Derived(ByVal NHSCD As Object) As Object
		
		If FR_SSSMAIN.HD_FRNKB.Text = " " Then
			Call DP_SSSMAIN_FRNKB(0, "0")
			Call AE_InOutModeN_SSSMAIN("FRNKB", "2202")
		End If
		
	End Function
	
	Function FRNKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト FRNKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FRNKB_InitVal = "0"
	End Function
End Module