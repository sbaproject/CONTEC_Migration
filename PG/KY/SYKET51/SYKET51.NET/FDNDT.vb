Option Strict Off
Option Explicit On
Module FDNDT_F51
	'
	' スロット名        : 出荷予定日・画面項目スロット
	' ユニット名        : FDNDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2005/06/20
	' 使用プログラム名  : SYKET51
	'
	'
	Dim NotFirst As Short
	
	Function FDNDT_CheckC(ByVal FDNDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト FDNDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FDNDT_CheckC = 0
		rtn = CHECK_DATE(FDNDT)
		If rtn Then
			'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If FDNDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 1) '当日より前日指定は入力できません。
				'UPGRADE_WARNING: オブジェクト FDNDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				FDNDT_CheckC = -1
			Else
				'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CHK_KADOYMD(FDNDT) = False Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 2) '可能物流稼動日以降がは入力できません。
					'UPGRADE_WARNING: オブジェクト FDNDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FDNDT_CheckC = -1
				Else
					'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If FDNDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
						If DSP_MsgBox(SSS_CONFRM, "SYKET51", 3) <> IDYES Then '翌稼動日を指定しています。実行してもよろしいですか？
							'UPGRADE_WARNING: オブジェクト FDNDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							FDNDT_CheckC = 1
						End If
					End If
				End If
			End If
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト FDNDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FDNDT_CheckC = -1
		End If
		'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_FDNDT = FDNDT
		
	End Function
	
	Function FDNDT_InitVal(ByVal FDNDT As Object) As Object
		'
		If NotFirst = False Or Not IsDate(FDNDT) Then
			NotFirst = True
			'UPGRADE_WARNING: オブジェクト FDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FDNDT_InitVal = DB_UNYMTA.UNYDT '運用日マスタの運用日。
		Else
			'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FDNDT_InitVal = FDNDT '前の伝票の日付。
		End If
		'UPGRADE_WARNING: オブジェクト FDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_FDNDT = FDNDT_InitVal
		
	End Function
	
	Function FDNDT_Skip(ByRef CT_FDNDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: オブジェクト CT_FDNDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CT_FDNDT.SelStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
		'UPGRADE_WARNING: オブジェクト FDNDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FDNDT_Skip = False
	End Function
	''
	'''''Function FDNDT_DerivedC(ByVal FDNDT, ByVal JDNNO)
	'''''Dim Rtn As Integer
	'''''    '
	'''''    FDNDT_DerivedC = FDNDT
	'''''    Rtn = CHECK_DATE(FDNDT)
	'''''    If Rtn Then
	'''''        If FDNDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
	'''''            Rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 1) '当日より前日指定は入力できません。
	'''''            FDNDT_DerivedC = -1
	'''''        Else
	'''''            If CHK_KADOYMD(FDNDT) = False Then
	'''''                Rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 2) '可能物流稼動日以降がは入力できません。
	'''''                FDNDT_DerivedC = -1
	'''''            Else
	'''''                If FDNDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
	'''''                    If DSP_MsgBox(SSS_CONFRM, "SYKET51", 3) <> IDYES Then  '翌稼動日を指定しています。実行してもよろしいですか？
	'''''                        FDNDT_DerivedC = 1
	'''''                    End If
	'''''                End If
	'''''            End If
	'''''        End If
	'''''    Else
	'''''        Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
	'''''        FDNDT_DerivedC = -1
	'''''    End If
	''
	'''''End Function
	
	Function FDNDT_Slist(ByVal FDNDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: オブジェクト FDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = FDNDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト FDNDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FDNDT_Slist = Set_date.Value
	End Function
End Module