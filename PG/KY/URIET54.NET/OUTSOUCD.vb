Option Strict Off
Option Explicit On
Module OUTSOUCD_F51
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :OUTSOUCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/09/11
	'使用プログラム  :URIET54/URIET55
	'
	'
	Function OUTSOUCD_CheckC(ByVal OUTSOUCD As Object, ByVal DE_INDEX As Object) As Object
		Dim rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト OUTSOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        OUTSOUCD_CheckC = 0
        '2019/09/19 DEL START
        'Call SOUMTA_RClear()
        '2019/09/19 DEL E N D
        'UPGRADE_WARNING: オブジェクト OUTSOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(OUTSOUCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(OUTSOUCD) = 0 Or Trim(OUTSOUCD) = "" Then
		Else
			Call DB_GetEq(DBN_SOUMTA, 1, OUTSOUCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_SOUMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト OUTSOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					OUTSOUCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト OUTSOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				OUTSOUCD_CheckC = -1
			End If
		End If
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call SCR_FromSOUMTA(DE_INDEX)
	End Function
	
	Function OUTSOUCD_Slist(ByRef PP As clsPP, ByVal OUTSOUCD As Object) As Object
        '2019/09/30 DEL START
        'DB_PARA(DBN_SOUMTA).KeyNo = 1
        'UPGRADE_WARNING: オブジェクト OUTSOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_SOUMTA).KeyBuf = OUTSOUCD
        '2019/09/30 DEL E N D
        WLSSOU.ShowDialog()
		WLSSOU.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト OUTSOUCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		OUTSOUCD_Slist = PP.SlistCom
	End Function
End Module