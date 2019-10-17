Option Strict Off
Option Explicit On
Module ENDTOKNM_F61
	'
	' スロット名        : 得意先名称・画面項目スロット
	' ユニット名        : ENDTOKNM.F61
	' 記述者            : Standard Library
	' 作成日付          : 2011/02/21
	' 使用プログラム名  : THSFP61
	'
	
	Function ENDTOKNM_Derived(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト ENDTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKNM_Derived = ""
        'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(ENDTOKCD) = "" Then
            DB_TOKMTA.TOKRN = " "
        Else
            '2019/10/15 DEL START
            'Call TOKMTA_RClear()
            'Call DB_GetEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
            '2019/10/15 DEL END
            If DBSTAT = 0 Then
                If DB_TOKMTA.DATKB = "9" Then
                    '2019/10/15 DEL START
                    'Call TOKMTA_RClear()
                    '2019/10/15 DEL END
                End If
                'UPGRADE_WARNING: オブジェクト ENDTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ENDTOKNM_Derived = DB_TOKMTA.TOKRN
            Else
                '2019/10/15 DEL START
                'Call TOKMTA_RClear()
                'Call SIRMTA_RClear()                
                'Call DB_GetEq(DBN_SIRMTA, 1, ENDTOKCD, BtrNormal)
                '2019/10/15 DEL END
                If DBSTAT = 0 Then
                    If DB_SIRMTA.DATKB = "9" Then
                        '2019/10/15 DEL START
                        'Call SIRMTA_RClear()
                        '2019/10/15 DEL END
                    End If
                    'UPGRADE_WARNING: オブジェクト ENDTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ENDTOKNM_Derived = DB_SIRMTA.SIRRN
				Else
                    '2019/10/15 DEL START
                    'Call SIRMTA_RClear()
                    '2019/10/15 DEL END
                End If
			End If
		End If
	End Function
	
	Function ENDTOKNM_InitVal(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		
		Select Case FR_SSSMAIN.HD_THSCD.Text
			Case "0", "1", "2", "3"
				'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(ENDTOKCD) = "" Then
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ENDTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
				Else
					'UPGRADE_WARNING: オブジェクト ENDTOKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ENDTOKNM_InitVal = DB_TOKMTA.TOKRN
				End If
			Case "4", "5"
				'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(ENDTOKCD) = "" Then
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ENDTOKNM_InitVal = FillVal(" ", LenWid(DB_SIRMTA.SIRRN))
				Else
					'UPGRADE_WARNING: オブジェクト ENDTOKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ENDTOKNM_InitVal = DB_SIRMTA.SIRRN
				End If
		End Select
		
	End Function
End Module