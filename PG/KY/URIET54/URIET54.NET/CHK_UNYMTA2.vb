Option Strict Off
Option Explicit On
Module CHK_UNYMTA2
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CHK_UNYDT
	'   �T�v�F  �^�p���t�`�F�b�N
	'   �����F
	'   �ߒl�F�@0:����(�^�p���t�������̓��t�Ɠ���) -1:�^�p���}�X�^��
	'�@�@�@�@�@ 1:�^�p���t�������̓��t���傫�� 2:�^�p���t�������̓��t��菬����
	'   ���l�F�A���[��739
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CHK_UNYDT(ByRef CHK_DT As String) As Object
		Dim strSQL As String
		Dim ls_UNYDT As String
		Dim ls_CHK_DT As String
		Dim DB_UNYMTA_BK As TYPE_DB_UNYMTA
		
		On Error GoTo ERR_CHK_UNYDT
		ls_CHK_DT = Trim(CHK_DT)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CHK_UNYDT = 9
		'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
		DB_UNYMTA_BK = LSet(DB_UNYMTA)
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM UNYMTA "
		'DB�A�N�Z�X
		Call DB_GetSQL2(DBN_UNYMTA, strSQL)
		ls_UNYDT = Trim(DB_UNYMTA.UNYDT)
		
		If ls_UNYDT = ls_CHK_DT Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CHK_UNYDT = 0
		ElseIf ls_UNYDT > ls_CHK_DT Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CHK_UNYDT = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CHK_UNYDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CHK_UNYDT = 2
		End If
		
END_CHK_UNYDT: 
		'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
		DB_UNYMTA = LSet(DB_UNYMTA_BK)
		Exit Function
		
ERR_CHK_UNYDT: 
		GoTo END_CHK_UNYDT
	End Function
End Module