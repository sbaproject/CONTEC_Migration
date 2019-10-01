Option Strict Off
Option Explicit On
Module FRMEINM_F51
	'
	' スロット名        : KEY名称・画面項目スロット
	' ユニット名        : FRMEINM.F51
	' 記述者            :  Library
	' 作成日付          : 2006/07/12
	' 使用プログラム名  : MEIMT51
	'
	'
	
	Function FRMEINM_CheckC(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object

        '20190826 DEL START
        'Call MEIMTB_RClear()
        '20190826 DEL END

        'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(Trim$(FRKEYCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(FRKEYCD) = "" Or LenWid(Trim(FRKEYCD)) = 0 Then
			Exit Function
		End If
		'geteqではKEYCDの名称を取り出し辛いので直接名称を取り出す。
		'Call DB_GetSQL2(DBN_MEIMTA, "select distinct MEIKMKNM from meimta where KEYCD='" & FRKEYCD & "'")
		Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case Trim(FRKEYCD)
				Case ""
					DB_MEIMTA.MEIKMKNM = ""
				Case Else
					DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
			End Select
		Else
			DB_MEIMTA.MEIKMKNM = ""
		End If
		
	End Function
	
	Function FRMEINM_DerivedC(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(FRKEYCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(FRKEYCD) = "" Or LenWid(Trim(FRKEYCD)) = 0 Then
			Exit Function
		End If
		'geteqではKEYCDの名称を取り出し辛いので直接名称を取り出す。
		'Call DB_GetSQL2(DBN_MEIMTA, "select distinct MEIKMKNM from meimta where KEYCD='" & FRKEYCD & "'")
		Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case Trim(FRKEYCD)
				Case ""
					'UPGRADE_WARNING: オブジェクト FRMEINM_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FRMEINM_DerivedC = ""
				Case Else
					'UPGRADE_WARNING: オブジェクト FRMEINM_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FRMEINM_DerivedC = DB_MEIMTB.MEIKMKNM
			End Select
		Else
			'UPGRADE_WARNING: オブジェクト FRMEINM_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRMEINM_DerivedC = ""
		End If
		
	End Function
	
	Function FRMEINM_InitVal(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(FRKEYCD) = "" Then
			'UPGRADE_WARNING: オブジェクト FRMEINM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRMEINM_InitVal = ""
		Else
			'UPGRADE_WARNING: オブジェクト FRMEINM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRMEINM_InitVal = DB_MEIMTB.MEIKMKNM
		End If
		
	End Function
End Module