Option Strict Off
Option Explicit On
Module ENDJDNNO_F61
	'
	' スロット名        : 終了受注伝票番号・画面項目スロット
	' ユニット名        : ENDJDNNO.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : UODPR51
	'
	
	Function ENDJDNNO_Check(ByVal ENDJDNNO As Object, ByVal STTJDNNO As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDJDNNO_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDJDNNO_Check = 0
		'UPGRADE_WARNING: オブジェクト ENDJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ENDJDNNO = "" Then
		Else
			'UPGRADE_WARNING: オブジェクト STTJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ENDJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDJDNNO < STTJDNNO Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: オブジェクト ENDJDNNO_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDJDNNO_Check = -1
			End If
		End If
	End Function
	
	Function ENDJDNNO_InitVal(ByVal ENDJDNNO As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDJDNNO_InitVal = FillVal("", LenWid(DB_JDNTRA.JDNNO))
	End Function
	
	Function ENDJDNNO_Slist(ByRef PP As clsPP, ByVal ENDJDNNO As Object) As Object
        'change start 20190808 kuwahara
        'DB_PARA(DBN_JDNTHA).KeyNo = 2
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "1"
        WLSJDN1.JDN1_PARA1 = "1" & "1"
        'change end 20190808 kuwahara

        '2019.03.26 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019.03.26 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDJDNNO_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDJDNNO_Slist = PP.SlistCom
	End Function
End Module