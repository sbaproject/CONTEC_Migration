Option Strict Off
Option Explicit On
Module UODPR51_E61
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : UODPR51.E61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : UODPR51
	'
	
	Sub Chain_Proc()
		
	End Sub

    Sub InitDsp()
        AE_BackColor(1) = &H8000000F
        '
        CL_SSSMAIN(0) = 1
        CL_SSSMAIN(1) = 1
        CL_SSSMAIN(3) = 1
        CL_SSSMAIN(11) = 1
        '
        '2019.03.27 DEL START
        'CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '2019.03.27 DEL END

        '''''    '---権限取得---
        '''''   Dim wkDATE As String, wkCRW As Control
        '''''   wkDATE = Format(Now, "YYYYMMDD")
        '''''   gs_userid = Left(SSS_OPEID, 6)          'ユーザID
        '''''   gs_pgid = "THSMR51"                     'プログラムID
        '''''   If Get_Authority(wkDATE, wkCRW) = 9 Then
        '''''      Call MsgBox("実行権限がありません。", vbOKOnly)
        '''''      End
        '''''   End If

        '実行権限の取得
        '2019.03.27 DEL START
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
        'If gs_PRTAUTH = "1" Then '印刷権限有り
        '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '    CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = True
        'Else
        '    CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '    CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '    CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        '    CType(FR_SSSMAIN.Controls("MN_FSTART"), Object).Enabled = False
        'End If

        '2019.03.27 DEL END

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
		'
		CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
	End Sub
End Module