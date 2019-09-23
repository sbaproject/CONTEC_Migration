Option Strict Off
Option Explicit On
Module GNKTK_O01
	'
	' �X���b�g��        : �����P���Z�o�i�]�������Ή��j�E�I�v�V���i���X���b�g
	' ���j�b�g��        : GNKTK.O01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/05/24
	' �g�p�v���O������  : URIET01
	'
	
	Function CALC_GNKTK(ByRef pHINCD As String) As Decimal
		'
		If DB_HINMTA.HINCD <> pHINCD Then
			Call HINMTA_RClear()
			Call DB_GetEq(DBN_HINMTA, 1, pHINCD, BtrNormal)
		End If
		CALC_GNKTK = DB_HINMTA.GNKTK
	End Function
	
	Function CALC_GNKTK2(ByRef pHINCD As String, ByRef pSMADT As String) As Decimal
		CALC_GNKTK2 = 0
		'
		Call HINSMA_RClear()
		Call DB_GetLsEq(DBN_HINSMA, 1, pHINCD & pSMADT, BtrNormal)
		Do While DBSTAT = 0 And DB_HINSMA.HINCD = pHINCD
			If (IsDate(CNV_DATE(DB_HINSMA.HYKSETDT)) Or IsDate(CNV_DATE(DB_HINSMA.HYKUPDDT))) And DB_HINSMA.LSTSRETK <> 0 Then
				CALC_GNKTK2 = DB_HINSMA.LSTSRETK
				Exit Do
			End If
			Call DB_GetPre(DBN_HINSMA, BtrNormal)
		Loop 
		
		If CALC_GNKTK2 = 0 Then CALC_GNKTK2 = CALC_GNKTK(pHINCD)
	End Function
	
	
	Function CALC_GNKTK3(ByRef pHINCD As String, ByRef pSMADT As String) As Decimal
		CALC_GNKTK3 = 0
		'
		Call HINSMA_RClear()
		Call DB_GetLsEq(DBN_HINSMA, 1, pHINCD & pSMADT, BtrNormal)
		Do While DBSTAT = 0 And DB_HINSMA.HINCD = pHINCD
			If (IsDate(CNV_DATE(DB_HINSMA.HYKSETDT)) Or IsDate(CNV_DATE(DB_HINSMA.HYKUPDDT))) And DB_HINSMA.SOUAVRTK <> 0 Then
				CALC_GNKTK3 = DB_HINSMA.SOUAVRTK
				Exit Do
			End If
			Call DB_GetPre(DBN_HINSMA, BtrNormal)
		Loop 
		
		If CALC_GNKTK3 = 0 Then CALC_GNKTK3 = CALC_GNKTK(pHINCD)
	End Function
End Module