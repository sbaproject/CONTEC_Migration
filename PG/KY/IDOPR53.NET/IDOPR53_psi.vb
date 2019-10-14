Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/10/11 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/10/11 ADD E N D

    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(9)
		AE_PSIC = 10
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_INPTANCD 2202 code 6 - A L N U - - 1 -"
		AE_PSI(3) = "HD_INPTANNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(4) = "HD_STTWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(5) = "HD_ENDWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(6) = "HD_STTWRTTM 2202 date 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(7) = "HD_ENDWRTTM 2202 date 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(8) = "HD_STTOUTDT 2202 date 10 - A L N S YYYY/MM/DD - 1 -"
		AE_PSI(9) = "HD_ENDOUTDT 2202 date 10 - A L N S YYYY/MM/DD - 1 -"
	End Sub
End Module