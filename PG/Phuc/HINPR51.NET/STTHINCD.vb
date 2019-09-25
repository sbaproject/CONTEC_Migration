Option Strict Off
Option Explicit On
Module STTHINCD_F55
	'
	' スロット名        : 開始商品コード・画面項目スロット
	' ユニット名        : STTHINCD.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function STTHINCD_Check(ByVal STTHINCD As Object) As Object
		Dim LenWid As Object
		Dim rtn As Short
		Dim wkHINCD As String
        '
        'UPGRADE_WARNING: オブジェクト STTHINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTHINCD_Check = 0
        '2019/09/25 DEL START
        'Call HINMTA_RClear()
        '2019/09/25 DEL END
        'UPGRADE_WARNING: オブジェクト STTHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(STTHINCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(STTHINCD) = 0 Or Trim(STTHINCD) = "" Then
		Else
			Call DB_GetEq(DBN_HINMTA, 1, STTHINCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_HINMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        STTHINCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTHINCD_Check = -1
			''''''''End If
			
		End If
		'Call SCR_FromHINMTA(De_Index)
	End Function
	
	Function STTHINCD_InitVal() As Object
		Dim LenWid As Object
		'
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTHINCD_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINCD))
	End Function
	
	Function STTHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
        'UPGRADE_WARNING: オブジェクト STTHINC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/09/25 DEL START
        'DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
        '2019/09/25 DEL END
        '2019/09/25 CHG START
        'WLSHIN.ShowDialog()
        'WLSHIN.Close()
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        '2019/09/25 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト STTHINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTHINCD_Slist = PP.SlistCom
	End Function
End Module