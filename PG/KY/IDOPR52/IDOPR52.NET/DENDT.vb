Option Strict Off
Option Explicit On
Module DENDT_F54
	'
	' スロット名        : 移動伝票日付・画面項目スロット
	' ユニット名        : DENDT.F54
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/22
	' 使用プログラム名  : IDOPR52
	'
	Dim NotFirst As Short
	
	Function DENDT_CheckC(ByRef DENDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_CheckC = 0
		'UPGRADE_WARNING: オブジェクト DENDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(DENDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります。
			'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DENDT_CheckC = -1
		Else
			If Not IsDate(DENDT) Then
				rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります。
				'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DENDT_CheckC = -1
			Else
				'        '運用日付とのﾁｪｯｸ
				'             If CLng(Format(DENDT, "YYYYMMDD")) > CLng(DB_UNYMTA.UNYDT) Then
				'                 rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)  '日付に誤りがあります。修正してください。
				'                 DENDT_CheckC = -1
				'             End If
			End If
		End If
	End Function
	
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		'
		''''If Trim(DENDT) = "" Then                                        '2006.10.19
		''''    DENDT_InitVal = DB_UNYMTA.UNYDT     '運用の日付。           '2006.10.19
		''''Else                                                            '2006.10.19
		''''    DENDT_InitVal = DENDT               '前の日付。             '2006.10.19
		''''End If                                                          '2006.10.19
		'UPGRADE_WARNING: オブジェクト DENDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_InitVal = ""
	End Function
	
	Function DENDT_Skip(ByRef CT_DENDT As System.Windows.Forms.Control) As Object
		'
		''''CT_DENDT.SelStart = 8 'yyyy-mm-dd の dd のところ。              '2006.10.19
		''''DENDT_Skip = False                                              '2006.10.19
	End Function
	
	Function DENDT_Slist(ByVal DENDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: オブジェクト DENDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = DENDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト DENDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_Slist = Set_date.Value
		
	End Function
End Module