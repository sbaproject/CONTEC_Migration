Option Strict Off
Option Explicit On
Module ULTTKKB_F51
	'
	' スロット名        : ﾛｯﾄ単価区分・画面項目スロット
	' ユニット名        : ULTTKKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/21
	' 使用プログラム名  : TOKMT54
	'
	
	Function ULTTKKB_CheckC(ByRef ULTTKKB As Object, ByVal HINCD As Object, ByVal De_Index As Short) As Object
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ULTTKKB = ""
		Else
			'UPGRADE_WARNING: オブジェクト ULTTKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ULTTKKB_CheckC = 0
			'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case Trim(ULTTKKB)
				Case ""
					'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB = 9
				Case CStr(1)
					'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB = 1
				Case CStr(9)
					'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB = 9
				Case Else
					'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB = 9
			End Select
			
		End If
	End Function
	Function ULTTKKB_InitVal(ByVal HINCD As Object, ByVal ULTTKKB As Object, ByVal De_Index As Short) As Object
		'
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト ULTTKKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ULTTKKB_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(ULTTKKB) = "" Then
				'UPGRADE_WARNING: オブジェクト ULTTKKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ULTTKKB_InitVal = 9
			End If
		End If
		
	End Function
	Function ULTTKKB_DerivedC(ByVal HINCD As Object, ByVal ULTTKKB As Object, ByVal De_Index As Object) As Object
        '
        'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(HINCD) = "" Then
            '2019/10/18 DEL START
            'Call HINMTA_RClear()
            'Call TOKMTA_RClear()
            '2019/10/18 DEL E N D
            Call TOKMTC_RClear()

        Else
            'UPGRADE_WARNING: オブジェクト ULTTKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Select Case Trim(ULTTKKB)
				Case ""
					'UPGRADE_WARNING: オブジェクト ULTTKKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB_DerivedC = 9
				Case CStr(1)
					'UPGRADE_WARNING: オブジェクト ULTTKKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB_DerivedC = 1
				Case CStr(9)
					'UPGRADE_WARNING: オブジェクト ULTTKKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB_DerivedC = 9
				Case Else
					'UPGRADE_WARNING: オブジェクト ULTTKKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ULTTKKB_DerivedC = 9
			End Select
		End If
	End Function
End Module