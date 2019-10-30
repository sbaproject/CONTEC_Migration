Option Strict Off
Option Explicit On
Module URKPR62_M01
	'
	' スロット名        : 入金消込日記帳（邦貨版）・メインファイル更新スロット
	' ユニット名        : URKPR62.M01
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/31
	' 使用プログラム名  : URKPR62
	'
	
	Function CHK_LCTL() As Short
	End Function
	
	Function ENDCHK() As Short
	End Function
	
	Sub Loop_Mfil()
		Dim PlStat As Short
		
		G_PlCnd.sCndStr(0) = SSS_CLTID.Value
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
		G_PlInfo.Fno(0) = DBN_URKPR62
		G_PlInfo.RCnt(0) = 1
		G_PlInfo.ArrayFlg(0) = 0
		'
		Call Mfil_FromSCR(-1)
		DB_URKPR62.STTWRTDT = DeCNV_DATE((FR_SSSMAIN.HD_STTWRTDT).Text)
		DB_URKPR62.ENDWRTDT = DeCNV_DATE((FR_SSSMAIN.HD_ENDWRTDT).Text)
		DB_URKPR62.STTWRTTM = Mid(FR_SSSMAIN.HD_STTWRTTM.Text, 1, 2) & Mid(FR_SSSMAIN.HD_STTWRTTM.Text, 4, 2) & Mid(FR_SSSMAIN.HD_STTWRTTM.Text, 7, 2)
		DB_URKPR62.ENDWRTTM = Mid(FR_SSSMAIN.HD_ENDWRTTM.Text, 1, 2) & Mid(FR_SSSMAIN.HD_ENDWRTTM.Text, 4, 2) & Mid(FR_SSSMAIN.HD_ENDWRTTM.Text, 7, 2)
		DB_URKPR62.STTKSIDT = DeCNV_DATE((FR_SSSMAIN.HD_STTKSIDT).Text)
		DB_URKPR62.ENDKSIDT = DeCNV_DATE((FR_SSSMAIN.HD_ENDKSIDT).Text)
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		PlStat = DB_PlSet(DBN_URKPR62, 0)
		'
		PlStat = DB_PlExec(Get_EntryToPackage())
		'PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_" & SSS_PrgId)
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