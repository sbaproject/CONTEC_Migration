Option Strict Off
Option Explicit On
Module ZMJGYCD_F51
	'
	' スロット名        : 会計事業所コード・画面項目スロット
	' ユニット名        : ZMJGYCD.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/30
	' 使用プログラム名  : BMNMT51
	'
	
	Function ZMJGYCD_CheckC(ByRef ZMJGYCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkZMJGYCD As String
		
		'UPGRADE_WARNING: オブジェクト ZMJGYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZMJGYCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト ZMJGYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(ZMJGYCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(ZMJGYCD)) = 0 Then
			rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: オブジェクト ZMJGYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZMJGYCD_CheckC = -1
		Else
			'UPGRADE_WARNING: オブジェクト ZMJGYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkZMJGYCD = ZMJGYCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMJGYCD))
			Call DB_GetEq(DBN_MEIMTA, 2, "021" & wkZMJGYCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト ZMJGYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ZMJGYCD_CheckC = 1
				End If
			Else
				rtn = Dsp_Msgbox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト ZMJGYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZMJGYCD_CheckC = -1
			End If
		End If
		
	End Function
End Module