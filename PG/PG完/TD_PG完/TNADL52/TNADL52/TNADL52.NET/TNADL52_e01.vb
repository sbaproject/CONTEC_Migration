Option Strict Off
Option Explicit On
Module TNADL52_E01
	'
	' �X���b�g��        : ��ʏ����X���b�g
	' ���j�b�g��        : TNADL52.E01
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/03/30
	' �g�p�v���O������  : TNADL52
	'
	Dim WRK_MFIL() As TYPE_DB_TNADL52
	
	Sub DSP_BODY(ByRef De As Short)
		'UPGRADE_WARNING: �I�u�W�F�N�g DB_TNADL52 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TNADL52 = WRK_MFIL((SSS_CurPage - 1) * SSS_PageLine + De)
		Call SCR_FromMfil(De)
	End Sub
	
	Sub DSP_HEAD()
		Call SCR_FromSOUMTA(0)
	End Sub
	
	'DL4�ł͎g�p���Ȃ�
	'Function DSP_KEYCHK()
	'End Function
	
	Sub INITDSP()
	End Sub
	
	Sub SET_DATA_KEY()
		G_PlCnd.sCndStr(1) = SSS_WrkKey
	End Sub
	
	Sub SET_GAMEN_KEY()
		SSS_SQLPage = 1
		SSS_MaxPage = 1
		ReDim WRK_MFIL(SSS_MaxPage * SSS_PageLine)
		SSS_LastPage = 0
		SSS_LastLine = 0
		SSS_WrkKey = ""
		' SSS_SMADT = DeCNV_DATE(Get_Acedt(CNV_DATE(RD_SSSMAIN_DSPYM(0))))
		
		'�^�p�����擾
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		SSS_SMADT.Value = DeCNV_DATE(Get_Acedt(CNV_DATE(DB_UNYMTA.UNYDT)))
		
		'�\�������]��
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		G_PlCnd.sCndStr(0) = RD_SSSMAIN_SOUCD(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTHINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		G_PlCnd.sCndStr(1) = RD_SSSMAIN_STTHINCD(0)
		G_PlCnd.sCndStr(2) = SSS_SMADT.Value
		G_PlCnd.sOpeID = SSS_OPEID.Value
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
		G_PlInfo.Fno(0) = DBN_TNADL52
		G_PlInfo.RCnt(0) = 1
		G_PlInfo.ArrayFlg(0) = 1
		G_PlInfo.RMax(0) = SSS_SQLPage * SSS_PageLine + 1
	End Sub
	
	Function GET_DSP_DATA() As Integer
		Dim PLSTAT, cnt As Integer
		Dim i As Short
		GET_DSP_DATA = False
		PLSTAT = DB_PlStart(1)
		PLSTAT = DB_PlCndSet
		PLSTAT = DB_PlSet(DBN_TNADL52, 0)
		PLSTAT = DB_PlExec(SSS_PrgId & "_PACK.M2_" & SSS_PrgId)
		If PLSTAT <> 0 Then
			MsgBox("PL/SQL Error�F" & PLSTAT)
		Else
			cnt = DB_PlGetCnt(DBN_TNADL52)
			If cnt = SSS_SQLPage * SSS_PageLine + 1 Then
				PLSTAT = DB_PlGet(DBN_TNADL52, cnt - 1)
				SSS_WrkKey = DB_TNADL52.HINCD
				cnt = cnt - 1
			Else
				SSS_WrkKey = HighValue(Len(DB_TNADL52.HINCD))
			End If
			If cnt > 0 Then
				GET_DSP_DATA = True
				SSS_MaxPage = SSS_MaxPage + SSS_SQLPage
				ReDim Preserve WRK_MFIL(SSS_MaxPage * SSS_PageLine)
				i = 0
				Do While cnt > i
					PLSTAT = DB_PlGet(DBN_TNADL52, i)
					'UPGRADE_WARNING: �I�u�W�F�N�g WRK_MFIL(i + SSS_LastPage * SSS_PageLine) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WRK_MFIL(i + SSS_LastPage * SSS_PageLine) = DB_TNADL52
					i = i + 1
				Loop 
				SSS_LastPage = SSS_LastPage + Int((cnt - 1) / SSS_PageLine) + 1
				SSS_LastLine = (cnt - 1) Mod SSS_PageLine + 1
				SSS_CurPage = SSS_CurPage + 1
			End If
		End If
		PLSTAT = DB_PlFree
	End Function
	
	Function SSSMAIN_OPEID_BeginPrg(ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_OPEID.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_OPEID_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_OPEID_BeginPrg = True
	End Function
	Function SSSMAIN_OPENM_BeginPrg(ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_OPENM.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_OPENM_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_OPENM_BeginPrg = True
	End Function
	Function SSSMAIN_SOUNM_BeginPrg(ByRef PP As clsPP, ByRef CP_SOUNM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		CL_SSSMAIN(CP_SOUNM.CpPx) = 5
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_SOUNM_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_SOUNM_BeginPrg = True
	End Function
	Function SSSMAIN_HINCD_BeginPrg(ByRef PP As clsPP, ByRef CP_HINCD As clsCP) As Object
		AE_BackColor(5) = &H8000000F '�w�i�F�F�O���[
		Dim i, stt As Short
		stt = 5
		For i = stt + 1 To stt + 11 * 15
			CL_SSSMAIN(i) = 5
		Next i
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_HINCD_BeginPrg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SSSMAIN_HINCD_BeginPrg = True
	End Function
End Module