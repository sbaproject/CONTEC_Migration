Option Strict Off
Option Explicit On
Module SSSMAIN_FP1
	
	Sub DSPCNT(ByRef RECSU As Integer, ByRef CNT As Integer)
		Dim I As Integer
		'
		I = 0
		If CNT <> 0 And RECSU <> 0 Then I = CNT / RECSU * 100
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CNT.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FR_SSSMAIN.Controls("CNT"), Object).FloodPercent = I
		If I < 50 Then
			'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CNT.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(FR_SSSMAIN.Controls("CNT"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLACK)
		Else
			'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CNT.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(FR_SSSMAIN.Controls("CNT"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Sub SSS_CLOSE()
		Call DB_End()
	End Sub
	
	'ファイルにカレントレコードの追加処理を行う。
	Function SSSMAIN_Append() As Object
		FR_SSSMAIN.Enabled = False
		Call BATMAN()
		FR_SSSMAIN.Enabled = True
		MsgBox("処理が終了しました。", MB_OK, Trim(SSS_PrgNm))
		Call DSPCNT(0, 0)
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CNT.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FR_SSSMAIN.Controls("CNT"), Object).Visible = False
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Append の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Append = 1
	End Function
	
	'画面表示前の初期設定処理を行う。
	Function SSSMAIN_BeginPrg() As Object 'Generated.
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '2019/09/23　仮
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/09/23　仮
        ' "しばらくお待ちください" ウィンドウ表示  97/05/29
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '2019/09/23　CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/09/23　仮 E N D
        'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN プログラム起動チェック
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		Call INITDSP()
		' "しばらくお待ちください" ウィンドウ消去  97/05/29
		ICN_ICON.Close()
	End Function
	
	'終了時の後処理を行う。
	Function SSSMAIN_Close() As Object 'Generated.
		' 排他テーブル更新（CLOSE）
		Call SSSWIN_EXCTBZ_CLOSE()
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Init の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Init = True
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Last の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Last = 0
	End Function
	
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Next の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Next = 0
	End Function
	
	'処理対象のデータの範囲を設定する。
	Function SSSMAIN_Select() As Object 'Generated.
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	'ファイルの中のカレントレコードの更新を行う。
	Function SSSMAIN_Update() As Object 'Generated.
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Update = 9
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SLISTCOM As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SLISTCOM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SLISTCOM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SLISTCOM = LeftWid(SLISTCOM, LENGTH)
	End Sub
End Module