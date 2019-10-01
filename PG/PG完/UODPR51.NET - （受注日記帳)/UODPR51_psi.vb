Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(12)
		AE_PSIC = 13
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_INPTANCD 2202 code 6 - A L N A - - 1 -"
		AE_PSI(3) = "HD_INPTANNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(4) = "HD_STTWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(5) = "HD_ENDWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(6) = "HD_STTWRTTM 2202 date 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(7) = "HD_ENDWRTTM 2202 date 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(8) = "HD_STTJDNNO 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(9) = "HD_ENDJDNNO 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(10) = "HD_STTTOKCD 2202 code 5 - A L N S - - 1 -"
		AE_PSI(11) = "HD_STTTOKRN 0000 name 40 - A L N N - - 1 -"
		AE_PSI(12) = "HD_SJDNINKB 2202 code 1 - A R N 0 - - 1 -"
    End Sub
    '2019.03.26 ADD START
    '共通処理用DUMMY
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String
    End Structure
    '2019.03.26 ADD END
End Module