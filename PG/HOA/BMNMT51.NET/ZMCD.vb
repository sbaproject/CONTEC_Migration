Option Strict Off
Option Explicit On
Module ZMCD_F51
	'
	' スロット名        : 会計区分・画面項目スロット
	' ユニット名        : ZMCD.F01
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/30
	' 使用プログラム名  : BMNMT51
	'
	Function ZMCD_CheckC(ByRef ZMCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkZMCD As String
		
		'UPGRADE_WARNING: オブジェクト ZMCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZMCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト ZMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(ZMCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(ZMCD)) = 0 Then
			rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: オブジェクト ZMCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZMCD_CheckC = -1
		Else
			'UPGRADE_WARNING: オブジェクト ZMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkZMCD = ZMCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMCD))
			Call DB_GetEq(DBN_MEIMTA, 2, "022" & wkZMCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト ZMCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ZMCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト ZMCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZMCD_CheckC = -1
			End If
		End If
		
	End Function
End Module