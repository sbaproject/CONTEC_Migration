Option Strict Off
Option Explicit On
Module TELNO_O51
	'
	'�X���b�g��     �F�d�b�ԍ��n�C�t�����`�F�b�N
	'���j�b�g��     �FTELNO.O51
	'�L�q��         �FStandard Libraly
	'�쐬���t       �F2006/08/28
	'�g�p�v���O���� �F
	'
	Function CHK_TELNO(ByVal pTELNO As String) As Boolean
		'---------------------------------------------------------------------------
		' �Œ�l�}�X�^�ɓo�^����Ă���iCTLCD = '507'�j�n�C�t�����Ɠ��ꂩ�`�F�b�N����B
		'---------------------------------------------------------------------------
		' pTELNO : �`�F�b�N�Ώۓd�b�ԍ� ( XXXXXXXXX1XXXXXXXXX2 )
		' �Ԓl   : �n�C�t����
		'
		Dim lngCount As Integer
		Dim lngPos As Integer
		
		CHK_TELNO = False
        '20190822 CHG START
        'Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal)
        GetRowsCommon("FIXMTA", "where CTLCD = '507'")
        '20190822 CHG END
        If DBSTAT = 0 Then
			lngCount = 0
			
			lngPos = InStr(1, Trim(pTELNO), "-")
			
			Do While lngPos <> 0
				lngCount = lngCount + 1
				If lngPos + 1 > Len(pTELNO) Then
					lngPos = 0
				Else
					lngPos = InStr(lngPos + 1, Trim(pTELNO), "-")
				End If
			Loop 
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Trim(DB_FIXMTA.FIXVAL)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If lngCount <> SSSVal(Trim(DB_FIXMTA.FIXVAL)) Then
				Exit Function
			End If
		Else
			Exit Function
		End If
		
		CHK_TELNO = True
		
	End Function
End Module