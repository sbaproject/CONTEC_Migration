Option Strict Off
Option Explicit On
Module URISU_F61
	'
	' スロット名        : 売上数量・画面項目スロット
	' ユニット名        : URISU.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	'
	
	Function URISU_CHECKC(ByVal BKTHKKB As Object, ByVal URISU As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal HINID As Object, ByVal HINCD As Object) As Object
		Dim Rtn As Short
		Dim strSQL As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		'
		' 分割不可区分（1：入力可、9：不可）が不可　かつ
		' 受注数量と異なる入力売上数量を入力した場合エラー
		'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU - ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト BKTHKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU) <> URISU Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '分割不可のため、分割売上はできません。
			MsgBox("分割不可のため、分割売上はできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'通販時、分割売上不可
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UODSU - ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (UODSU - ATZHIKSU) <> URISU Then
				'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '分割不可のため、分割売上はできません。
				'2008/2/27 FKS)ichihara CHG START
				'            MsgBox "通販データの為、分割売上はできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
				MsgBox("諸口コードまたは通販データの為、分割売上はできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
				'2008/2/27 FKS)ichihara CHG END
				'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECKC = -1
				Exit Function
			End If
		End If
		
		' 受注数、又は受注数を超える数量は入力不可
		' ATZHIKSU⇒売上済み数
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UODSU - ATZHIKSU - URISU < 0 Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '受注数、又は受注数を超える数量は入力できません。
			MsgBox("受注数、又は受注数を超える数量は入力できません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECKC = -1
			Exit Function
		End If
		
		' 数量０は入力不可
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If URISU = 0 Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '数量０は入力できません。
			MsgBox("数量ゼロは入力できません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		
		intDe = PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & WG_JDNDATNO & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
		Call DB_GetSQL2(DBN_JDNTRA, strSQL)
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU < CDec(URISU) And DB_JDNTRA.ZAIKB = "1" Then
			'''' UPD 2009/02/23  FKS) S.Nakajima    Start
			'        MsgBox "出荷数不一致のため、売上登録出来ません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 7) '未出荷ありのため、売上登録出来ません。
			'''' UPD 2009/02/23  FKS) S.Nakajima    End
			'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECKC = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM USRET51"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
        'change 20190807 START hou
        'Call DB_GetSQL2(DBN_USRET51, strSQL)
        CON_USR9 = DB_START_USR9()
        DB_GetTable(strSQL, CON_USR9)
        'change 20190807 END hou


        'UPGRADE_WARNING: オブジェクト SSSVal(DB_ExtNum.ExtNum(0)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change 20190807 START hou
        'If SSSVal(DB_ExtNum.ExtNum(0)) <> 0 Then
        If SSSVal(1) <> 0 Then
            'change 20190807 END hou

            'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change 20190807 START hou
            'If URISU < DB_ExtNum.ExtNum(0) Then
            If URISU < 1 Then
                'change 20190807 END hou

                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 2) '売上数以上のｼﾘｱﾙが登録
                'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                URISU_CHECKC = -1
                Exit Function
            End If
        End If

        'UPGRADE_WARNING: オブジェクト URISU_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        URISU_CHECKC = 0
		'
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal UDNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SOUCD As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		'
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_JDNTRKB(0) <> "51" Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
		If DBSTAT = 0 Then
			If DB_HINMTA.SERIKB = "9" Then
				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
				Exit Function
			End If
		Else
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		EXEPATH = AE_AppPath & "USRET51.EXE /RPTCLTID:" & SSS_CLTID.Value & " /RSTDT:" & VB6.Format(UDNDT, "YYYYMMDD") & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX) & " /SOUCD:" & Trim(SOUCD)
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
	End Function
End Module