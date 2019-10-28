Option Strict Off
Option Explicit On
Module FRDSU_F51
	'
	' スロット名        : 出荷指示数量・画面項目スロット
	' ユニット名        : FRDSU.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/16
	' 使用プログラム名  : SYKET51
	'
	'注)2008/05/20現在OTPSUは処理内では未使用
	Function FRDSU_CheckC(ByVal FRDSU As Object, ByVal OTPSU As Object, ByVal FRDKNSU As Object, ByVal BKTHKKB As Object, ByVal HINCD As Object, ByVal WRKKB As Object, ByVal De_index As Object, ByVal Ex_FRDSU As Object) As Object
		Dim rtn As Short
		Dim wkHINCD As String
		'
		'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FRDSU_CheckC = 0
		'UPGRADE_WARNING: オブジェクト SSSVal(FRDSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(FRDSU) = 0 Then Exit Function
		
		'出荷指示数上限ﾁｪｯｸ
		'UPGRADE_WARNING: オブジェクト SSSVal(FRDSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(FRDKNSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(FRDKNSU) < SSSVal(FRDSU) Then
			rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 5)
			'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRDSU_CheckC = -1
			Exit Function
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(FRDSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(FRDKNSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト BKTHKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (BKTHKKB = "9") And (SSSVal(FRDKNSU) <> SSSVal(FRDSU)) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 6)
				'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				FRDSU_CheckC = -1
				Exit Function
			End If
		End If
		
		'移動時分割入力は不可とする
		'UPGRADE_WARNING: オブジェクト SSSVal(FRDSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(FRDKNSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(FRDKNSU) <> SSSVal(FRDSU) Then
			rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 6)
			'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRDSU_CheckC = -1
			Exit Function
		End If
		
		'出荷停止商品
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
		If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
		Else
			''''2007.03.08 UPD-START
			''''    If (DBSTAT = "9") Or (DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT) Then
			''''        rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 7)
			''''        FRDSU_CheckC = -1
			''''    End If
			If DBSTAT = CDbl("9") Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
				'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				FRDSU_CheckC = -1
			Else
				If DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 7)
					'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FRDSU_CheckC = -1
				End If
				If DB_HINMTA.ORTSTPKB = "8" Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKET51", 8)
					'UPGRADE_WARNING: オブジェクト FRDSU_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FRDSU_CheckC = -1
				End If
			End If
			''''2007.03.08 UPD-END
		End If
		
	End Function
	
	Function FRDSU_DerivedC(ByVal HINCD As Object, ByVal FRDSU As Object) As Object
		'UPGRADE_WARNING: オブジェクト FRDSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FRDSU_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FRDSU_DerivedC = FRDSU
		
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then Exit Function
	End Function
End Module