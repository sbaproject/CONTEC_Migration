Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/10/10 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/10/10 ADD E N D
    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(9)
		AE_PSIC = 10
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N 0 000000 - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(2) = "HD_SKHINGRP 3303 code 4 - A L N U - - 1 -"
		AE_PSI(3) = "HD_SKHINGNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(4) = "BD_UPDKB 0000 code 4 - A L N A - - 1 -"
		AE_PSI(5) = "BD_RNKCD 3303 code 1 - A L N U !@ - 1 -"
		AE_PSI(6) = "BD_URISETDT 3303 date 10 - A L N A YYYY/MM/DD - 1 -"
		AE_PSI(7) = "BD_SIKRT 3303 numb 6 - A R N C ##0.00 - 1 -"
		AE_PSI(8) = "BV_V_DATKB 0000 code 1 - A L N N - - 1 -"
		AE_PSI(9) = "BV_V_SIKRT 0000 numb 6 - A R N C ##0.00 - 1 -"
	End Sub
End Module