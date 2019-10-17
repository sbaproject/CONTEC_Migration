Option Strict Off
Option Explicit On
Module STTTOKNM_F61
	'
	' スロット名        : 得意先名称・画面項目スロット
	' ユニット名        : STTTOKNM.F61
	' 記述者            : Standard Library
	' 作成日付          : 2011/02/21
	' 使用プログラム名  : THSFP61
	'
	
	Function STTTOKNM_Derived(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト STTTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKNM_Derived = ""
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTTOKCD) = "" Then
			DB_TOKMTA.TOKRN = " "
		Else
			Call TOKMTA_RClear()
			Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
				'UPGRADE_WARNING: オブジェクト STTTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STTTOKNM_Derived = DB_TOKMTA.TOKRN
			Else
				Call TOKMTA_RClear()
				Call SIRMTA_RClear()
				Call DB_GetEq(DBN_SIRMTA, 1, STTTOKCD, BtrNormal)
				If DBSTAT = 0 Then
					If DB_SIRMTA.DATKB = "9" Then
						Call SIRMTA_RClear()
					End If
					'UPGRADE_WARNING: オブジェクト STTTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKNM_Derived = DB_SIRMTA.SIRRN
				Else
					Call SIRMTA_RClear()
				End If
			End If
		End If
		
	End Function
	
	Function STTTOKNM_InitVal(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		
		Select Case FR_SSSMAIN.HD_THSCD.Text
			Case "0", "1", "2", "3"
				'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(STTTOKCD) = "" Then
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
				Else
					'UPGRADE_WARNING: オブジェクト STTTOKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKNM_InitVal = DB_TOKMTA.TOKRN
				End If
			Case "4", "5"
				'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(STTTOKCD) = "" Then
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKNM_InitVal = FillVal(" ", LenWid(DB_SIRMTA.SIRRN))
				Else
					'UPGRADE_WARNING: オブジェクト STTTOKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKNM_InitVal = DB_SIRMTA.SIRRN
				End If
		End Select
		
	End Function
End Module