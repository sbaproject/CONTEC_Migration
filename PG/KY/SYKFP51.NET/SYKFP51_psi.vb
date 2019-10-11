Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/10/02 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/10/02 ADD E N D
    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(6)
		AE_PSIC = 7
		AE_PSI(0) = "HD_ODNYTDT 3303 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(1) = "HD_SOUCD 2202 code 3 - A R N 0 000 - 1 -"
		AE_PSI(2) = "HD_SOUNM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(3) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(4) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(5) = "HD_WRTFSTDT 0000 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(6) = "HD_WRTFSTTM 0000 code 8 - A L Y 0 HH:MM:SS - 1 -"
	End Sub
End Module