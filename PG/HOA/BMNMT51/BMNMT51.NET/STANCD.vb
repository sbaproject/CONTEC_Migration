Option Strict Off
Option Explicit On
Module STANCD_F51
	'
	'スロット名      :生産部門・画面項目スロット
	'ユニット名      :STANCD.F01
	'記述者          :Standard Library
	'作成日付        :2006/06/15
	'使用プログラム  :BMNMT51
	'
	Function STANCD_CheckC(ByRef STANCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkSTANCD As String
		
		'UPGRADE_WARNING: オブジェクト STANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STANCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト STANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(STANCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(STANCD)) = 0 Then
		Else
			'UPGRADE_WARNING: オブジェクト STANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSTANCD = STANCD & Space(Len(DB_MEIMTA.MEICDA) - Len(STANCD))
			Call DB_GetEq(DBN_MEIMTA, 2, "025" & wkSTANCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト STANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STANCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト STANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STANCD_CheckC = -1
			End If
		End If
		
	End Function
End Module