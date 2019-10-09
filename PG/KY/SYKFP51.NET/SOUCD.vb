Option Strict Off
Option Explicit On
Module SOUCD_F53
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :SOUCD.F53
	'記述者          :Standard Library
	'作成日付        :2006/06/20
	'使用プログラム  :SYKFP51
	'
	'
	Function SOUCD_Check(ByVal SOUCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUCD_Check = 0
		Call SOUMTA_RClear()
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(SOUCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(SOUCD) = 0 Or Trim(SOUCD) = "" Then
		Else
			Call DB_GetEq(DBN_SOUMTA, 1, SOUCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_SOUMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト SOUCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SOUCD_Check = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト SOUCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUCD_Check = -1
			End If
		End If
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call SCR_FromSOUMTA(De_Index)
	End Function
	
	Function SOUCD_Slist(ByRef PP As clsPP, ByVal SOUCD As Object) As Object
        '
        '2019/10/04 DEL START
        'DB_PARA(DBN_SOUMTA).KeyNo = 1
        'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_SOUMTA).KeyBuf = SOUCD
        '2019/10/04 DEL E N D
        WLSSOU1.ShowDialog()
        WLSSOU1.Close()
        'UPGRADE_WARNING: オブジェクト PP.SLISTCOM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SOUCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SOUCD_Slist = PP.SLISTCOM
	End Function
End Module