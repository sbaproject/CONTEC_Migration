Option Strict Off
Option Explicit On
Module ODNYTDT_F51
	'
	' スロット名        : 出荷予定日・画面項目スロット
	' ユニット名        : ODNYTDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2005/06/20
	' 使用プログラム名  : SYKFP51
	'
	'
	Dim NotFirst As Short
	
	Function ODNYTDT_CheckC(ByVal ODNYTDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ODNYTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ODNYTDT_CheckC = 0
		rtn = CHECK_DATE(ODNYTDT)
		If rtn Then
			'UPGRADE_WARNING: オブジェクト ODNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ODNYTDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKFP51", 0) '当日より前日指定は入力できません。
				'UPGRADE_WARNING: オブジェクト ODNYTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ODNYTDT_CheckC = -1
			Else
				'UPGRADE_WARNING: オブジェクト ODNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CHK_KADOYMD(ODNYTDT) = False Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKFP51", 1) '可能物流稼動日以降がは入力できません。
					'UPGRADE_WARNING: オブジェクト ODNYTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ODNYTDT_CheckC = -1
				Else
					'UPGRADE_WARNING: オブジェクト ODNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If ODNYTDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
						If DSP_MsgBox(SSS_CONFRM, "SYKFP51", 2) <> IDYES Then '翌稼動日を指定しています。実行してもよろしいですか？
							'UPGRADE_WARNING: オブジェクト ODNYTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							ODNYTDT_CheckC = 1
						End If
					End If
				End If
			End If
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ODNYTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ODNYTDT_CheckC = -1
		End If
	End Function
	
	Function ODNYTDT_InitVal(ByVal ODNYTDT As Object) As Object
		'''''If NotFirst = False Or Not IsDate(ODNYTDT) Then
		''''    NotFirst = True
		''''    ODNYTDT_InitVal = DB_UNYMTA.UNYDT       '運用日マスタの運用日。
		''''Else
		''''    ODNYTDT_InitVal = ODNYTDT        '前の伝票の日付。
		''''End If
		
		'UPGRADE_WARNING: オブジェクト ODNYTDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ODNYTDT_InitVal = DB_UNYMTA.UNYDT '運用日マスタの運用日。
	End Function
	
	Function ODNYTDT_Skip(ByRef CT_ODNYTDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: オブジェクト CT_ODNYTDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/09/23 CHG START
        'CT_ODNYTDT.SelStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        DirectCast(CT_ODNYTDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        '2019/09/23 CHG E N D
        'UPGRADE_WARNING: オブジェクト ODNYTDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ODNYTDT_Skip = False
	End Function
	
	Function ODNYTDT_Slist(ByVal ODNYTDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: オブジェクト ODNYTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = ODNYTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト ODNYTDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ODNYTDT_Slist = Set_date.Value
	End Function
End Module