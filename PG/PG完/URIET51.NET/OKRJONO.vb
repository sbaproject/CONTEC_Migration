Option Strict Off
Option Explicit On
Module OKRJONO_F61
	'
	' �X���b�g��        : �󒍓`�[�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : OKRJONO.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	'
	Public from_JDNNO_Unit As Boolean ' �󒍔ԍ����͎��iMAX�W���@�\����ׁ̈j
	
	Function OKRJONO_InitVal(ByVal OKRJONO As Object, ByRef PP As clsPP, ByRef CP_OKRJONO As clsCP) As Object
		Dim WK_OKRJONO As Object
		If from_JDNNO_Unit = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g OKRJONO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g OKRJONO_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			OKRJONO_InitVal = OKRJONO
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g OKRJONO_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			OKRJONO_InitVal = ""
		End If
		from_JDNNO_Unit = False
	End Function
End Module