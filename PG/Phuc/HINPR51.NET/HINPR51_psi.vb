Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/09/24 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/09/24 ADD E N D
    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(7)
		AE_PSIC = 8
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_KHNKB 2202 code 1 - A R N U - - 1 -"
		AE_PSI(3) = "HD_STTHINCD 2202 code 8 - A L N U - - 1 -"
		AE_PSI(4) = "HD_STTHINNM 0000 name 30 - A L N U - - 1 -"
		AE_PSI(5) = "HD_ENDHINCD 2202 code 8 - A L N U - - 1 -"
		AE_PSI(6) = "HD_ENDHINNM 0000 name 30 - A L N U - - 1 -"
		AE_PSI(7) = "HD_HINKB 2202 code 1 - A R N U - - 1 -"
	End Sub
End Module