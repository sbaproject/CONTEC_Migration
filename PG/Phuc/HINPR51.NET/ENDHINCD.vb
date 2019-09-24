Option Strict Off
Option Explicit On
Module ENDHINCD_F53
	'
	' スロット名        : 終了・商品コード・画面項目スロット
	' ユニット名        : ENDHINCD.F01
	' 記述者            : Standard Library
	' 作成日付          : 1998/05/01
	' 使用プログラム名  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function ENDHINCD_Check(ByVal ENDHINCD As Object, ByVal STTHINCD As Object) As Object
		Dim LenWid As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDHINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDHINCD_Check = 0
		'UPGRADE_WARNING: オブジェクト STTHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ENDHINCD < STTHINCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: オブジェクト ENDHINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDHINCD_Check = -1
			Exit Function
		End If
		
		Call HINMTA_RClear()
		'UPGRADE_WARNING: オブジェクト ENDHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(ENDHINCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(ENDHINCD) = 0 Or Trim(ENDHINCD) = "" Or ENDHINCD = "ZZZZZZZZ" Then
		Else
			Call DB_GetEq(DBN_HINMTA, 1, ENDHINCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_HINMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        ENDHINCD_Check = -1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDHINCD_Check = -1
			''''''''End If
		End If
		
	End Function
	
	Function ENDHINCD_InitVal(ByVal ENDHINCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDHINCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDHINCD_InitVal = "ZZZZZZZZ"
	End Function
	
	
	Function ENDHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト STTHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
		WLSHIN.ShowDialog()
		WLSHIN.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDHINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDHINCD_Slist = PP.SlistCom
	End Function
End Module