Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/09/23 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/09/23 ADD E N D

    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(5)
		AE_PSIC = 6
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_STTBNKCD 2202 code 7 - A L N U - - 1 -"
		AE_PSI(3) = "HD_STTBNKNM 0000 name 50 - A L N U - - 1 -"
		AE_PSI(4) = "HD_ENDBNKCD 2202 code 7 - A L N U - - 1 -"
		AE_PSI(5) = "HD_ENDBNKNM 0000 name 50 - A L N U - - 1 -"
	End Sub
End Module