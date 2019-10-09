Option Strict Off
Option Explicit On
Module IDOPR53_M01
	'
	' スロット名        : 製番出庫日記帳・メインファイル更新スロット
	' ユニット名        : IDOPR53.M01
	' 記述者            : Standard Library
	' 作成日付          : 1998/02/24
	' 使用プログラム名  : IDOPR53
	'
	
	Function CHK_LCTL() As Short
	End Function
	
	Function ENDCHK() As Short
	End Function
	
	Sub Loop_Mfil()
		Dim PlStat As Short
		
		G_PlCnd.sCndStr(0) = SSS_CLTID.Value
		G_PlCnd.sCndStr(1) = FR_SSSMAIN.HD_INPTANCD.Text
		G_PlCnd.sCndStr(2) = FR_SSSMAIN.HD_INPTANNM.Text
		G_PlCnd.sCndStr(3) = DeCNV_DATE((FR_SSSMAIN.HD_STTWRTDT).Text)
		G_PlCnd.sCndStr(4) = DeCNV_DATE((FR_SSSMAIN.HD_ENDWRTDT).Text)
		If Trim(FR_SSSMAIN.HD_STTWRTTM.Text) <> "" Then
			G_PlCnd.sCndStr(5) = VB6.Format(CDate(FR_SSSMAIN.HD_STTWRTTM.Text), "hhmmss")
		Else
			G_PlCnd.sCndStr(5) = "      "
		End If
		If Trim(FR_SSSMAIN.HD_ENDWRTTM.Text) <> "" Then
			G_PlCnd.sCndStr(6) = VB6.Format(CDate(FR_SSSMAIN.HD_ENDWRTTM.Text), "hhmmss")
		Else
			G_PlCnd.sCndStr(6) = "      "
		End If
		G_PlCnd.sCndStr(7) = DeCNV_DATE((FR_SSSMAIN.HD_STTOUTDT).Text)
		G_PlCnd.sCndStr(8) = DeCNV_DATE((FR_SSSMAIN.HD_ENDOUTDT).Text)
		
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
		G_PlInfo.Fno(0) = DBN_IDOPR53
		G_PlInfo.RCnt(0) = 1
		G_PlInfo.ArrayFlg(0) = 0
		'
		Call Mfil_FromSCR(-1)
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		PlStat = DB_PlSet(DBN_IDOPR53, 0)
		'
		''''PlStat = DB_PlExec(Get_EntryToPackage())
		PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_" & SSS_PrgId)
		If PlStat <> 0 And PlStat <> 1485 Then
			MsgBox("PL/SQL Error：" & PlStat)
		Else
			SSS_LFILCNT = G_PlCnd2.nCndNum(0)
			If SSS_LFILCNT > 0 Then
				Call CNT_GAUGE()
			End If
			'正常に終りました。
			'CRWで出力可
		End If
		PlStat = DB_PlFree
	End Sub
	
	Function NEXTCHK() As Short
	End Function
	
	Function NPSNCHK() As Short
	End Function
	
	Function RPSNCHK() As Short
	End Function
	
	Function SEL_RECORD() As String
	End Function
	
	Sub Set_Value()
	End Sub
	
	Function DeCNV_TIME(ByRef strTIME As String) As String
		
		DeCNV_TIME = Mid(strTIME, 1, 2) & Mid(strTIME, 4, 2) & Mid(strTIME, 7, 2)
		
	End Function
End Module