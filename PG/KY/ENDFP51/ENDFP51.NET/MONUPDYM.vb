Option Strict Off
Option Explicit On
Module MONUPDYM_F51
	'
	' スロット名        : 前回月次更新実行日付・画面項目スロット
	' ユニット名        : MONUPDYM.F02
	' 記述者            : Standard Library
	' 作成日付          : 1997/06/26
	' 使用プログラム名  : ENDFP01
	'
	'
	Dim NotFirst As Short
	
	Function MONUPDYM_Check(ByRef MONUPDYM As Object) As Object
		Dim Rtn As Short
		Dim W_dt As String
		Dim W_nxtdt As Object
		'
		'UPGRADE_WARNING: オブジェクト MONUPDYM_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		MONUPDYM_Check = 0
		''
		''2001/05/11 '日付範囲チェックを追加
		If Not CHECK_DATE(MONUPDYM) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト MONUPDYM_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MONUPDYM_Check = -1
			Exit Function
		End If
		''
		Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal) 'Insert
		'UPGRADE_WARNING: オブジェクト MONUPDYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		W_dt = Get_TouAcedt(CShort(LeftWid(MONUPDYM, 4)), CShort(MidWid(MONUPDYM, 6, 2)))
		If W_dt <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 3) ' 月次更新済。
			'UPGRADE_WARNING: オブジェクト MONUPDYM_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MONUPDYM_Check = -1
		End If
		
		'UPGRADE_WARNING: オブジェクト SSSVal(MidWid(DB_SYSTBA.MONUPDDT, 5, 2)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト W_nxtdt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		W_nxtdt = CStr(DateSerial(SSSVal(LeftWid(DB_SYSTBA.MONUPDDT, 4)), SSSVal(MidWid(DB_SYSTBA.MONUPDDT, 5, 2)) + 1, 1))
		'UPGRADE_WARNING: オブジェクト W_nxtdt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		W_nxtdt = Get_TouAcedt(CShort(LeftWid(W_nxtdt, 4)), CShort(MidWid(W_nxtdt, 6, 2)))
		If DB_SYSTBA.ZAIHYKKB <> "1" And W_dt > CNV_DATE(DB_SYSTBA.HYKSTTDT) Then
			'UPGRADE_WARNING: オブジェクト W_nxtdt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If W_nxtdt < W_dt Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 4) ' 前月月次更新要求。
				'UPGRADE_WARNING: オブジェクト MONUPDYM_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				MONUPDYM_Check = -1
			End If
		End If
		
	End Function
	
	Function MONUPDYM_InitVal(ByVal MONUPDYM As Object) As Object
		'
		If NotFirst = False Or Not IsDate(MONUPDYM) Then
			NotFirst = True
			MONUPDYM_InitVal = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, Today)
		Else
			'UPGRADE_WARNING: オブジェクト MONUPDYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト MONUPDYM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			MONUPDYM_InitVal = MONUPDYM
		End If
	End Function
End Module