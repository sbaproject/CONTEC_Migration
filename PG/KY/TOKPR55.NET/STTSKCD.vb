Option Strict Off
Option Explicit On
Module STTSKCD_F51
	'
	'スロット名      :仕切用商品群コード・画面項目スロット
	'ユニット名      :SKCD.F55
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function STTSKCD_Check(ByVal STTSKCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTSKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTSKCD_Check = 0
        'Call RNKMTA_RClear()
        'UPGRADE_WARNING: オブジェクト STTSKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(STTSKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(STTSKCD) = 0 Or Trim(STTSKCD) = "" Then
		Else
			Call DB_GetEq(DBN_RNKMTA, 1, STTSKCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_RNKMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        STTSKCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTSKCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromRNKMTA(De_Index)
	End Function
	
	Function STTSKCD_Slist(ByRef PP As clsPP, ByVal STTSKCD As Object) As Object
		'
		DB_PARA(DBN_RNKMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト STTSKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_RNKMTA).KeyBuf = STTSKCD
        ''''WLS_MEI1.Show 1
        ''''Unload WLS_MEI1
        ''''STTSKCD_Slist = PP.SlistCom

        WLS_MEI.Text = "ランク一覧"
        CType(WLS_MEI.Controls("LST"), Object).Items.Clear()
        Call DB_GetGrEq(DBN_MEIMTA, 3, "043", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "043"
			If DB_MEIMTA.DATKB <> "9" Then
                CType(WLS_MEI.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
            End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
        WLS_MEI.ShowDialog()
        WLS_MEI.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト STTSKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTSKCD_Slist = PP.SlistCom
		
	End Function
	Function STTSKCD_InitVal(ByVal STTSKCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト STTSKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTSKCD_InitVal = " "
		
	End Function
End Module