Option Strict Off
Option Explicit On
Module URKPR52_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : URKPR52.E01
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/31
	' 使用プログラム名  : URKPR52
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		
		
		'2009/01/14 CHG START FKS)NAKATA 連絡票№514
		''    '実行権限の取得
		''    Call Get_Authority(DB_UNYMTA.UNYDT)
		
		''実行権限がない場合は、エラーメッセージを表示し起動させない。
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT)) = 9 Then
			Call MsgBox("実行権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		'2009/01/14 CHG E.N.D FKS)NAKATA
		
		
		
		'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
		If gs_PRTAUTH = "1" Then '印刷権限有り
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
		Else
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
		End If
		If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = True
		Else
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = False
		End If
		
		
	End Sub
	
	Sub INQ_LIST()
		Dim Rtn As Short
		'
		DLGLST1.ShowDialog()
		Select Case SSS_RTNWIN
			Case 0 ' 印刷
				Rtn = LSTART_GetEvent()
			Case 1 ' プレビュー
				Rtn = VSTART_GetEvent()
			Case 2 ' ファイル出力
				Rtn = FSTART_GetEvent()
			Case Else
		End Select
	End Sub
	Function SSSMAIN_OPEID_BeginPrg(ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_OPEID.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_OPEID_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_OPEID_BeginPrg = True
	End Function
	Function SSSMAIN_OPENM_BeginPrg(ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_OPENM.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_OPENM_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_OPENM_BeginPrg = True
	End Function
	Function SSSMAIN_STTTOKRN_BeginPrg(ByRef PP As clsPP, ByRef CP_STTTOKRN As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_STTTOKRN.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_STTTOKRN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_STTTOKRN_BeginPrg = True
	End Function
	Function SSSMAIN_STTTANNM_BeginPrg(ByRef PP As clsPP, ByRef CP_STTTANNM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_STTTANNM.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_STTTANNM_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_STTTANNM_BeginPrg = True
	End Function
End Module