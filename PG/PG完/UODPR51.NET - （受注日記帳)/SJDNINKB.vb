Option Strict Off
Option Explicit On
Module SJDNINKB_F61
	'
	' スロット名        : 受注取込種別区分・画面項目スロット
	' ユニット名        : SJDNINKB.F61
	' 記述者            : DVP_NT40
	' 作成日付          : 2007/01/11
	' 使用プログラム名  : UODPR51
	'
	' 備考              : 1:日締
	'                     2:曜日締
	
	Function SJDNINKB_CheckC(ByRef SJDNINKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト SJDNINKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SJDNINKB_CheckC = 0
		
		'UPGRADE_WARNING: オブジェクト SJDNINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SJDNINKB) = "" Then '2007.01.11
			'UPGRADE_WARNING: オブジェクト SJDNINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SJDNINKB = " " '2007.01.11
			Exit Function '2007.01.11
		End If '2007.01.11
		
		Select Case SJDNINKB
			Case "1", "2", "3", "4"
			Case Else
				'UPGRADE_WARNING: オブジェクト SJDNINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SJDNINKB = " "
				Call DSP_MsgBox(SSS_CONFRM, "UODPR51", 0)
				'UPGRADE_WARNING: オブジェクト SJDNINKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SJDNINKB_CheckC = -1
		End Select
		
	End Function
	
	Function SJDNINKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト SJDNINKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SJDNINKB_InitVal = " "
	End Function
End Module