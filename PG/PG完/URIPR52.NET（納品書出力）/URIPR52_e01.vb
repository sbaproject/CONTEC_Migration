Option Strict Off
Option Explicit On
Module URIPR52_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : URIPR52.E01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIPR52
	'
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(7) = 1
		CL_SSSMAIN(11) = 1
		CL_SSSMAIN(13) = 1

        '2019.04.08 del start
        ''運用日の取得
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)

        ''実行権限の取得
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
        'If gs_PRTAUTH = "1" Then '印刷権限有り
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = True
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_LSTART"), Object).Enabled = False
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'Else
        '	CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
        '	CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
        '	CType(FR_SSSMAIN.Controls("MN_VSTART"), Object).Enabled = True
        'End If

        ''ADD 2007/02/19 IMAI 印刷フラグ初期化
        'SSS_DonePrintFlg = 0
        '2019.04.08 del end

	End Sub
	
	Sub INQ_LIST()
		Dim Rtn As Short
        '
        DLGLST1.ShowDialog()

        Select Case SSS_RTNWIN
            Case 0 ' 印刷
                '2019.04.12 del start
                'Rtn = LSTART_GetEvent()
                  '2019.04.12 del end
            Case 1 ' プレビュー
                Rtn = VSTART_GetEvent()
            Case 2 ' ファイル出力
                '2019.04.12 del start
                'Rtn = FSTART_GetEvent()
                '2019.04.12 del end
            Case Else
        End Select

    End Sub
End Module