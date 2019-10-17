Option Strict Off
Option Explicit On
Module THSFP61_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : THSPR61.E01
	' 記述者            : Standard Library
	' 作成日付          : 2011/02/21
	' 使用プログラム名  : THSFP61
	'
	Public GV_UNYDT As String
	
	Sub Chain_Proc()
		
	End Sub
	
	Sub InitDsp()
		'背景色設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(7) = 1

        '運用日取得
        '2019/10/15 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        '2019/10/15 CHG END
        GV_UNYDT = DB_UNYMTA.UNYDT
		
		
		'実行権限の取得
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		
	End Sub
	
	Public Function SSS_CLOSE() As Object
		
	End Function
	Function SSSMAIN_BeginPrg() As Object
        '画面表示前の初期設定処理を行う。
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '2019/10/15 DEL START
        'If App.PrevInstance Then
        '    '2019/10/15 CHG START
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/15 DEL END
        ' "しばらくお待ちください" ウィンドウ表示
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '2019/10/15 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/10/15 CHG END
        'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSSMAIN_BeginPrg = True
		SSS_ExportFLG = False '初期値：印刷処理
		'----------------------------------
		'   SSSWIN プログラム起動チェック
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		'デフォルト用紙サイズと印刷の向きを読み取り
		Call Set_defaultPrintInfo()
		
		Call InitDsp()
		' "しばらくお待ちください" ウィンドウ消去
		ICN_ICON.Close()
	End Function
	
	Function SSSMAIN_Close() As Object
		'終了時の後処理を行う。
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'
		Call WORKING_VIEW(False)
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
	
	Function SSSMAIN_Select() As Object
		'処理対象のデータの範囲を設定する。
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	Function SSSMAIN_Update() As Object
		'ファイルの中のカレントレコードの更新を行う。
		Dim Wk As Object
		'MsgBox "データを更新しました。"
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Update = 9
	End Function
	
	Function VSTART_GetEvent() As Short
		'
		VSTART_GetEvent = True
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			VSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_VIEW
		'    Call SSS_LIST(SSS_VIEW)
		'
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Sub WORKING_VIEW(ByRef Sw As Short)
        'ゲージの表示 etc...
        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/15 DEL START
        'CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 0
        '2019/10/15 DEL END
        If Sw Then
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
            '2019/10/15 CHG START
            'Call AE_StatusOut(PP_SSSMAIN, "作業中！ しばらくお待ちください。", System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE))
            '2019/10/15 CHG END
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/15 DEL START
            'CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = True
            '2019/10/15 DEL END
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CM_LCANCEL.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
		Else
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '既定値
			CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/15 DEL START
            'CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = False
            '2019/10/15 DEL END
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CM_LCANCEL.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
End Module