Option Strict Off
Option Explicit On
Module SpreadBas
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�̔C�ӂ̃J�����ɃJ�[�\�����ړ�������B
	'�y�� �� ���z GP_SpActiveCell
	'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
	'             ByVal lngCol As Long�F��
	'             ByVal lngRow As Long�F�s
	'�y��    �l�z
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	
	Public Sub GP_SpActiveCell(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
		Dim ActionActiveCell As Object
		With objSpread
            '2019/10/03 DEL START
            '         'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .SetFocus()
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g ActionActiveCell �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Action = ActionActiveCell
            '         'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.EditMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .EditMode = True
            '2019/10/03 DEL END
        End With
		
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�̒P��I�����[�h�̐ݒ�B
	'�y�� �� ���z GP_SpSingleMode
	'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
	'�y��    �l�z
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	
	Public Sub GP_SpSingleMode(ByRef objSpread As Object)
		Dim OperationModeSingle As Object
		Dim ActionClearText As Object
		
		With objSpread
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ReDraw = False
			'�X�v���b�h�̃N���A
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ActionClearText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Action = ActionClearText
			'�\���s=0
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MaxRows = 0
			'���͕s�B�I���̂݁B
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.OperationMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g OperationModeSingle �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.OperationMode = OperationModeSingle
			'�I���Z���̃Z���F�B
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.SelBackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.SelBackColor = &HFF8080
			'�����s�y�ъ�s�̔w�i�F�B
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.SetOddEvenRowColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call .SetOddEvenRowColor(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), &H8000000F, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ReDraw = True
		End With
		
	End Sub
End Module