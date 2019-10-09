Option Strict Off
Option Explicit On
Module IDOPR53_E01
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : IDOPR53.E01
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : IDOPR53
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		AE_BackColor(1) = &H8000000F
		'
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(3) = 1
		'
		'実行権限の取得
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
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
End Module