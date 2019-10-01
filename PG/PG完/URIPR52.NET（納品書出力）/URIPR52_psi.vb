Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(15)
		AE_PSIC = 16
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_HAKKOU 3303 code 1 - A R N 0 0 - 1 -"
		AE_PSI(3) = "HD_KINKYU 3303 code 1 - A R N 0 0 - 1 -"
		AE_PSI(4) = "HD_TANCD 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(5) = "HD_TANNM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(6) = "HD_BMNCD 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(7) = "HD_BMNNM 0000 name 40 - A L N U - - 1 -"
		AE_PSI(8) = "HD_DENDT 3303 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(9) = "HD_JDNNO 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(10) = "HD_TOKCD 2202 code 5 - A L N S !@@@@@ - 1 -"
		AE_PSI(11) = "HD_TOKRN 0000 name 40 - A L N U - - 1 -"
		AE_PSI(12) = "HD_JDNTRKB 2202 code 2 - A L N U !@@ - 1 -"
		AE_PSI(13) = "HD_JDNTRNM 0000 name 10 - A L N U - - 1 -"
		AE_PSI(14) = "HD_PRTKB 3303 code 1 - A R N 0 0 - 1 -"
		AE_PSI(15) = "HV_FDNNO 0000 code 8 - A L N N - - 1 -"
    End Sub
    'delete start 20190808 kuwahara
    '2019.03.26 ADD START
    '担当者マスタ検索戻り値
    'Public WLSTAN_RTNCODE As String     '担当者コード
    'Public WLSTAN_TANTKDT As String     '適用日
    'Public WLSTAN_TANCLAKB As String    '営業担当者検索フラグ(空白:全件表示 "1":営業担当者のみ)
    'delete end 20190808 kuwahara

    '共通処理用DUMMY
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String
    End Structure
    '2019.03.26 ADD E N D
End Module