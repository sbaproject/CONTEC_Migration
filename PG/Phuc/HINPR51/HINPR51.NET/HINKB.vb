Option Strict Off
Option Explicit On
Module HINKB_F51
	'
	' スロット名        : 商品区分区分・画面項目スロット
	' ユニット名        : HINJUNKB.FM1
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : HINMR01
	'
	' 備考              : 1:商品
	'                     2:製品
	'                     3:部品
	'
	
	Function HINKB_CheckC(ByRef HINKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト HINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINKB) = "" Then
			'UPGRADE_WARNING: オブジェクト HINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HINKB = "1"
		End If
		Select Case HINKB
			Case "1", "2", "3", "4", "5", "9"
			Case Else
				'UPGRADE_WARNING: オブジェクト HINKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HINKB = "1"
		End Select
		'UPGRADE_WARNING: オブジェクト HINKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HINKB_CheckC = 0
	End Function
	
	Function HINKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト HINKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HINKB_InitVal = "1"
	End Function
End Module