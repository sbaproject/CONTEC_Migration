Option Strict Off
Option Explicit On
Module NHSCD_F71
	'
	'スロット名      :納品先コード・画面項目スロット
	'ユニット名      :NHSCD.F71
	'記述者          :Standard Library
	'作成日付        :2006/09/26
	'使用プログラム  :NHSMR51
	'
	
	Function NHSCD_Check(ByRef PP As clsPP, ByVal De_Index As Object, ByVal NHSCD As Object) As Object
		Dim Rtn As Object
		' === 20081009 === INSERT S - RISE)Izumi 連絡表No.655
		Dim intLoop As Short
		' === 20081009 === INSERT E - RISE)Izumi
		'
		'UPGRADE_WARNING: オブジェクト NHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCD_Check = 0
        'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(NHSCD) = "" Then
            'UPGRADE_WARNING: オブジェクト NHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            NHSCD_Check = -1
            Exit Function
        End If


        'Call DB_GetEq(DBN_NHSMTA, 1, NHSCD, BtrNormal)
        Dim strSQL1 As String = ""
        strSQL1 = strSQL1 & "select * from NHSMTA  Where NHSCD  = '" & NHSCD & "'"

        Dim dt As DataTable = DB_GetTable(strSQL1)
        For j As Integer = 0 To dt.Rows.Count - 1
            DB_NHSMTA2.NHSCD = dt.Rows(j)("NHSCD")
            DB_NHSMTA2.WRTDT = dt.Rows(j)("WRTDT")
            DB_NHSMTA2.WRTTM = dt.Rows(j)("WRTTM")
            DB_NHSMTA2.UWRTDT = dt.Rows(j)("UWRTDT")
            DB_NHSMTA2.UWRTTM = dt.Rows(j)("UWRTTM")
            DB_NHSMTA2.OPEID = dt.Rows(j)("OPEID")
            DB_NHSMTA2.CLTID = dt.Rows(j)("CLTID")
            DB_NHSMTA2.UOPEID = dt.Rows(j)("UOPEID")
            DB_NHSMTA2.UCLTID = dt.Rows(j)("UCLTID")
        Next

        ' === 20080916 === UPDATE S - RISE)Izumi
        ''2007/12/11 add-str T.KAWAMUKAI 元データのタイムスタンプ退避
        '        M_MOTO_inf.WRTTM = DB_NHSMTA.WRTTM            '更新時刻
        '        M_MOTO_inf.WRTDT = DB_NHSMTA.WRTDT            '更新日付
        '        M_MOTO_inf.UWRTTM = DB_NHSMTA.UWRTTM          'バッチ更新時刻
        '        M_MOTO_inf.UWRTDT = DB_NHSMTA.UWRTDT          'バッチ更新日付
        ''2007/12/11 add-end T.KAWAMUKAI
        '納入先マスタ：排他更新日時取得
        '20190821 CHG START
        '      HAITA_NHSMTA.NHSCD = DB_NHSMTA.NHSCD
        'HAITA_NHSMTA.WRTDT = DB_NHSMTA.WRTDT
        'HAITA_NHSMTA.WRTTM = DB_NHSMTA.WRTTM
        'HAITA_NHSMTA.UWRTDT = DB_NHSMTA.UWRTDT
        'HAITA_NHSMTA.UWRTTM = DB_NHSMTA.UWRTTM
        'HAITA_NHSMTA.OPEID = DB_NHSMTA.OPEID
        'HAITA_NHSMTA.CLTID = DB_NHSMTA.CLTID
        'HAITA_NHSMTA.UOPEID = DB_NHSMTA.UOPEID
        'HAITA_NHSMTA.UCLTID = DB_NHSMTA.UCLTID

        HAITA_NHSMTA.NHSCD = DB_NHSMTA2.NHSCD
        HAITA_NHSMTA.WRTDT = DB_NHSMTA2.WRTDT
        HAITA_NHSMTA.WRTTM = DB_NHSMTA2.WRTTM
        HAITA_NHSMTA.UWRTDT = DB_NHSMTA2.UWRTDT
        HAITA_NHSMTA.UWRTTM = DB_NHSMTA2.UWRTTM
        HAITA_NHSMTA.OPEID = DB_NHSMTA2.OPEID
        HAITA_NHSMTA.CLTID = DB_NHSMTA2.CLTID
        HAITA_NHSMTA.UOPEID = DB_NHSMTA2.UOPEID
        HAITA_NHSMTA.UCLTID = DB_NHSMTA2.UCLTID
        '20190821 CHG END
        ' === 20080916 === UPDATE E - RISE)Izumi

        If DBSTAT <> 0 Then
			CType(FR_SSSMAIN.Controls("MN_DeleteCm"), Object).Enabled = False
			Call Dsp_Prompt("RNOTFOUND", 0) '新規レコードです
			' === 20081009 === INSERT S - RISE)Izumi 連絡表No.655
			'入力された納入先コードが9桁か確認する
			'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(Trim(NHSCD)) = 9 Then
				'納入先コードに数字以外が含まれていないかチェックする
				For intLoop = 1 To 9
					'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Select Case Mid(NHSCD, intLoop, 1)
						Case "0" To "9"
						Case Else
							'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Rtn = MF_DspMsg("NHSMR52_003") '納入先コードに数字以外の文字は登録はできません。
							'UPGRADE_WARNING: オブジェクト NHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							NHSCD_Check = -1
							Exit Function
					End Select
				Next intLoop
			Else
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = MF_DspMsg("NHSMR52_004") '納入先コードは9桁で登録してください。
				'UPGRADE_WARNING: オブジェクト NHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSCD_Check = -1
				Exit Function
			End If
			' === 20081009 === INSERT E - RISE)Izumi
		Else
            'If DB_NHSMTA.DATKB = "9" Then
            If DB_NHSMTA2.DATKB = "9" Then
                'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) '削除済レコードです
            End If
            'CType(FR_SSSMAIN.Controls("MN_DeleteCm"), Object).Enabled = True
            'SSS_LASTKEY.Value = DB_NHSMTA.NHSCD
            SSS_LASTKEY.Value = DB_NHSMTA2.NHSCD
            'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Rtn = AE_ChOprtLater(PP, EEEMODE_UPDATE)
		End If
	End Function
	
	Function NHSCD_Slist(ByRef PP As clsPP, ByVal NHSCD As Object) As Object
        '
        'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_NHSMTA).KeyBuf = NHSCD
        '20190821 CHG END
        'WLSNHS.ShowDialog()
        'WLSNHS.Close()
        WLSNHS2.ShowDialog()
        WLSNHS2.Close()
        '20190821 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト NHSCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        NHSCD_Slist = PP.SlistCom
	End Function
End Module