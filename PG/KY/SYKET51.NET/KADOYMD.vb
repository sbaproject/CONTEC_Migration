Option Strict Off
Option Explicit On
Module KADOYMD_O51
	'
	'�X���b�g��     �F�����ғ����`�F�b�N
	'���j�b�g��     �FKADOYMD.O51
	'�L�q��         �FStandard Libraly
	'�쐬���t       �F2006/07/13
	'�g�p�v���O���� �F
	'
	Function CHK_KADOYMD(ByVal pdate As String) As Boolean
		'---------------------------------------------------------------------------
		' �`�F�b�N�Ώۓ��t�����e���ꂽ�͈�(�Œ�l�}�X�^)�̕����ғ������`�F�b�N����B
		'---------------------------------------------------------------------------
		' pDate : �`�F�b�N�Ώۓ��t ( YYYY/MM/DD )
		'
		' �Ԃ�l: False ..... ���e���ꂽ�͈͂̕����ғ����ł͂Ȃ��B
		'         True  ..... ���e���ꂽ�͈͂̕����ғ����ł���B
		'
		Dim lngFIXVAL As Integer
		Dim lngI As Integer
		
		CHK_KADOYMD = False
		
		If IsDate(pdate) = False Then
			Exit Function
		End If
		
		pdate = DeCNV_DATE(pdate) 'YYYY/MM/DD �� YYYYMMDD
		
		'�Œ�l�}�X�^�擾
		Call DB_GetEq(DBN_FIXMTA, 1, "401", BtrNormal) '�����ғ����̋��e�͈�
		If DBSTAT <> 0 Then
			Exit Function
		End If
		If DB_FIXMTA.DATKB = "9" Then
			Exit Function
		End If
		lngFIXVAL = CInt(Trim(DB_FIXMTA.FIXVAL))
		
		'�J�����_�}�X�^����
		lngI = 0
		Call DB_GetGrEq(DBN_CLDMTA, 1, DB_UNYMTA.UNYDT, BtrNormal)
		Do While (DBSTAT = 0) And (lngI <= lngFIXVAL)
			If DB_CLDMTA.DTBKDKB = "1" Then '�����ғ����敪
				lngI = lngI + 1
				If pdate = DB_CLDMTA.CLDDT Then
					CHK_KADOYMD = True
					Exit Do
				End If
			End If
			Call DB_GetNext(DBN_CLDMTA, BtrNormal)
		Loop 
		
	End Function
End Module