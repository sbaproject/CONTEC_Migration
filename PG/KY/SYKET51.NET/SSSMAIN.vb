Option Strict Off
Option Explicit On
Module SSSMAIN_ET1
	'
	'for NewRRR VA03 by SWaN Corp.
	'最終更新日=2002/8/28
	''''''''''''''''''''''''''''''
	Sub SSS_CLOSE()
		'
		Call DB_End()
		Call CRW_END()
	End Sub
	
	'ファイルにカレントレコードの追加処理を行う。
	Function SSSMAIN_Append() As Object
		If SSS_UPDATEFL Then
			' 一行追加  PL/SQL対応
			G_PlCnd.nJobMode = 0 'Insert MODE
			FR_SSSMAIN.Enabled = False
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Append = INQ_UPDATE()
			FR_SSSMAIN.Enabled = True
			PP_SSSMAIN.SuppressGotLostFocus = 1
		Else
			MsgBox("このデータは追加できません。")
			'UPGRADE_WARNING: オブジェクト SSSMAIN_Append の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Append = 0
		End If
	End Function
	
	'追加モードになるときの処理を行う。
	Function SSSMAIN_AppendC() As Object
		'   If FR_SSSMAIN.BackColor <> &HC0C0C0 Then FR_SSSMAIN.BackColor = &HC0C0C0
		'UPGRADE_WARNING: オブジェクト SSSMAIN_AppendC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_AppendC = True
	End Function
	
	'画面表示前の初期設定処理を行う。
	Function SSSMAIN_BeginPrg(ByRef PP As clsPP) As Object
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '2019/10/28 DEL START
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/28 DEL E N D
        ' "しばらくお待ちください" ウィンドウ表示  97/05/29
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '2019/10/28 CHG START
        'Load(ICN_ICON)
        ICN_ICON.ShowDialog()
        '2019/10/28 CHG E N D
        'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN プログラム起動チェック
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		Call Set_StripeColor()
		' 排他テーブル更新（OPEN）
		'Call SSSWIN_EXCTBZ_OPEN
		'ADD START FKS)INABA 2009/11/19 *********************
		'連絡票№758
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		'ADD  END  FKS)INABA 2009/11/19 *********************
		Call INITDSP()
		' クリスタルレポート
		If CRW_INIT() = False Then
			Call Error_Exit("ERROE CRW_INIT")
		End If
		' "しばらくお待ちください" ウィンドウ消去  97/05/29
		ICN_ICON.Close()
	End Function
	
	'終了時の後処理を行う。
	Function SSSMAIN_Close() As Object
		' 排他テーブル更新（CLOSE）
		Call SSSWIN_EXCTBZ_CLOSE()
		' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130416 === INSERT E -
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Close = True
	End Function
	
	'処理対象のデータの中のカレントレコードを再度読み込む。
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: オブジェクト DSPTRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Current = DSPTRN()
	End Function
	
	'ファイルからカレントレコードを削除する。
	Function SSSMAIN_Delete() As Object
		Dim Rtn As Short
		'
		If SSS_UPDATEFL Then
			' 一行追加  PL/SQL対応
			G_PlCnd.nJobMode = 2 'Delete MODE
			FR_SSSMAIN.Enabled = False
			Rtn = DELTRN()
			FR_SSSMAIN.Enabled = True
			PP_SSSMAIN.SuppressGotLostFocus = 1
			'UPGRADE_WARNING: オブジェクト SSSMAIN_Delete の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Delete = Rtn
		Else
			MsgBox("このデータは削除できません。")
			'UPGRADE_WARNING: オブジェクト SSSMAIN_Delete の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Delete = 0
		End If
	End Function
	
	'処理対象のデータの中の先頭のレコードを読み込む。
	Function SSSMAIN_First() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_First の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_First = False
	End Function
	
	'更新モードになるときの処理を行う。
	Function SSSMAIN_Indicate() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Indicate の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Indicate = 3
	End Function
	
	Function SSSMAIN_Init() As Object
		SSS_UPDATEFL = True
	End Function
	
	'処理対象のデータの中の最終のレコードを読み込む。
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Last の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Last = False
	End Function
	
	'処理対象のデータの中からカレントの次のレコードを読み込む。
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Next の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Next = False
	End Function
	
	'処理対象のデータの中からカレントの一つ前のレコードを読み込む。
	Function SSSMAIN_Prev() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Prev の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Prev = False
	End Function
	
	'処理対象のデータの範囲を設定する。
	Function SSSMAIN_Select() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Select の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Select = 2 '動作モードの変更を行わない
	End Function
	
	'ファイルの中のカレントレコードの更新を行う。
	Function SSSMAIN_Update() As Object
		If SSS_UPDATEFL Then
			' 一行追加  PL/SQL対応
			G_PlCnd.nJobMode = 1 'Update MODE
			FR_SSSMAIN.Enabled = False
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Update = INQ_UPDATE()
			FR_SSSMAIN.Enabled = True
			'SSSMAIN_Update = 5
			PP_SSSMAIN.SuppressGotLostFocus = 1
		Else
			MsgBox("このデータは更新できません。")
			'UPGRADE_WARNING: オブジェクト SSSMAIN_Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSMAIN_Update = 0
		End If
	End Function
	
	'更新モードになるときの処理を行う。
	Function SSSMAIN_UpdateC() As Object
		'   If FR_SSSMAIN.BackColor <> &HE0FFFF Then FR_SSSMAIN.BackColor = &HE0FFFF
		'UPGRADE_WARNING: オブジェクト SSSMAIN_UpdateC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_UpdateC = True
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
		'PP_SSSMAIN.CursorDirection = 1
		'WLS_SLISTCOM = SlistCom
	End Sub
End Module