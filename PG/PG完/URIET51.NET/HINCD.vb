Option Strict Off
Option Explicit On
Module HINCD_U01
	'
	' �X���b�g��        : ���i�R�[�h�E�t�@�C�����ڃX���b�g
	' ���j�b�g��        : HINCD.U01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	
	Sub Scr_HINCD_FromSYSTBD(ByVal De As Short)
		If Trim(DB_SYSTBD.DFLDKBCD) <> "" Then
			Call DP_SSSMAIN_HINCD(De, DB_SYSTBD.DFLDKBCD)
		End If
	End Sub
	
	Sub SYSTBD_HINCD_FromScr(ByVal De As Short)
		
	End Sub
End Module