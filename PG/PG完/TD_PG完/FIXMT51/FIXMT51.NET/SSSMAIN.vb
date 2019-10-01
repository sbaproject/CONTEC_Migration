Option Strict Off
Option Explicit On
Module SSSMAIN_MT1
	'2008/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
	Public HaitaUpdFlg As Short '排他フラグ【0:更新可能,1:更新不可(他PG更新)】
	'2008/07/08 E.N.D ADD FNAP)YAMANE  連絡票№：排他-共通
	'
	'for NewRRR VA03 by SWaN Corp.
	'最終更新日=2002/8/28
	''''''''''''''''''''''''''''''
	Function SSSMAIN_Append() As Object
		' ファイルにカレントレコードの追加処理を行う。
		'
		If PP_SSSMAIN.LastDe <> 0 Then
			FR_SSSMAIN.Enabled = False
			Call UPDMST()
			FR_SSSMAIN.Enabled = True
			'2007/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
			If HaitaUpdFlg = 1 Then Exit Function
			'2007/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Append の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Append = 9
	End Function
	
	'追加モードになるときの処理を行う。
	Function SSSMAIN_AppendC() As Object
		'    If FR_SSSMAIN.BackColor <> &HC0C0C0 Then FR_SSSMAIN.BackColor = &HC0C0C0
		'UPGRADE_WARNING: オブジェクト SSSMAIN_AppendC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_AppendC = True
		SSS_FASTKEY.Value = ""
		SSS_LASTKEY.Value = ""
	End Function

    '画面表示前の初期設定処理を行う。
    Function SSSMAIN_BeginPrg() As Object
        '20190801 DEL START
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        ' "しばらくお待ちください" ウィンドウ表示  97/05/29
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        'Load(ICN_ICON)
        '20190801 DEL END
        'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSSMAIN_BeginPrg = True
        '----------------------------------
        '   SSSWIN プログラム起動チェック
        '----------------------------------
        Call SSSWIN_INIT()
        Call SSSWIN_OPEN()
        Call Set_StripeColor()
        Call INITDSP()
        ' "しばらくお待ちください" ウィンドウ消去  97/05/29
        ICN_ICON.Close()
    End Function

    '終了時の後処理を行う。
    Function SSSMAIN_Close() As Object
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Close = True
	End Function
	
	'処理対象のデータの中のカレントレコードを再度読み込む。
	Function SSSMAIN_Current() As Object
		SSSMAIN_Current = DSPMST()
	End Function
	
	'ファイルからカレントレコードを削除する。
	Function SSSMAIN_Delete() As Object
	End Function
	
	Function SSSMAIN_First() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_First の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_First = 0
	End Function
	
	'更新モードになるときの処理を行う。
	Function SSSMAIN_Indicate() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Indicate の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Indicate = 3
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Last の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Last = 0
	End Function
	
	'処理対象のデータの中からカレントの次のレコードを読み込む。
	Function SSSMAIN_Next() As Object
		SSSMAIN_Next = MST_NEXT()
	End Function
	
	'処理対象のデータの中からカレントの一つ前のレコードを読み込む。
	Function SSSMAIN_Prev() As Object
		'UPGRADE_WARNING: オブジェクト MST_PREV() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Prev = MST_PREV()
	End Function
	
	'処理対象のデータの範囲を設定する。
	Function SSSMAIN_Select() As Object
		SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	Function SSSMAIN_Update() As Object
		' ファイルの中のカレントレコードの更新を行います。
		'
		FR_SSSMAIN.Enabled = False
		Call UPDMST()
		FR_SSSMAIN.Enabled = True
		'2007/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
		If HaitaUpdFlg = 1 Then Exit Function
		'2007/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
		'----------------------------------------------------------------------
		'   MT1変更（追加）
		'    SSSMAIN_Update = 9
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Update = 2
	End Function
	
	'更新モードになるときの処理を行う。
	Function SSSMAIN_UpdateC() As Object
		'    If FR_SSSMAIN.BackColor <> &HE0FFFF Then FR_SSSMAIN.BackColor = &HE0FFFF
		'UPGRADE_WARNING: オブジェクト SSSMAIN_UpdateC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_UpdateC = True
	End Function
	
	Sub SSS_CLOSE()
		'
		Call DB_End()
	End Sub
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Function PREV_GETEVENT() As Short
		Dim rtn As Object
		'変更データ有り時更新判定処理
		PREV_GETEVENT = -1
		'2008/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
		HaitaUpdFlg = 0
		'2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And PP_SSSMAIN.Mode >= 3 Then '1999/01/05  Update
			'UPGRADE_WARNING: オブジェクト rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			rtn = MsgBox("未登録のデータが存在します。更新を行います。", 48 + MsgBoxStyle.YesNoCancel)
			If rtn = MsgBoxResult.Yes Then 'はい選択時（更新＋改ページ）
				If AE_CompleteCheck_SSSMAIN(0) = 0 Then '1999/01/05  Insert
					FR_SSSMAIN.Enabled = False
					Call UPDMST()
					FR_SSSMAIN.Enabled = True
					'2008/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
					If HaitaUpdFlg = 1 Then PREV_GETEVENT = 0
					'2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
				Else '1999/01/05  Insert
					PREV_GETEVENT = 0 '必須処理キャンセル  '1999/01/05  Insert
				End If '1999/01/05  Insert
			ElseIf rtn = MsgBoxResult.Cancel Then 
				PREV_GETEVENT = 0 'キャンセル選択時（処理キャンセル）
			End If
		End If
	End Function
	
	Function NEXTCm_GETEVENT() As Short
		Dim rtn As Object
		'変更データ有り時更新判定処理
		NEXTCm_GETEVENT = -1
		'2008/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
		HaitaUpdFlg = 0
		'2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And PP_SSSMAIN.Mode >= 3 Then '1999/01/05  Update
			'UPGRADE_WARNING: オブジェクト rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			rtn = MsgBox("未登録のデータが存在します。更新を行います。", 48 + MsgBoxStyle.YesNoCancel)
			If rtn = MsgBoxResult.Yes Then 'はい選択時（更新＋改ページ）
				If AE_CompleteCheck_SSSMAIN(0) = 0 Then '1999/01/05  Insert
					FR_SSSMAIN.Enabled = False
					Call UPDMST()
					FR_SSSMAIN.Enabled = True
					'2008/07/08 START ADD FNAP)YAMANE 連絡票№：排他-共通
					If HaitaUpdFlg = 1 Then NEXTCm_GETEVENT = 0
					'2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票№：排他-共通
				Else '1999/01/05  Insert
					NEXTCm_GETEVENT = 0 '必須処理キャンセル  '1999/01/05  Insert
				End If '1999/01/05  Insert
			ElseIf rtn = MsgBoxResult.Cancel Then 
				NEXTCm_GETEVENT = 0 'キャンセル選択時（処理キャンセル）
			End If
		End If
	End Function
	
	Function INSERTDE_GETEVENT() As Short
		Dim rtn As Object
		Dim Wk_De As Short
		'変更データ有り時更新判定処理
		If PP_SSSMAIN.LastDe = PP_SSSMAIN.MaxDe + 1 Then
			Wk_De = PP_SSSMAIN.De
			PP_SSSMAIN.De = PP_SSSMAIN.MaxDe
			Call AE_DeleteDe_SSSMAIN()
			PP_SSSMAIN.De = Wk_De
			'         PP_SSSMAIN.LastDe = PP_SSSMAIN.MaxDe
		End If
		INSERTDE_GETEVENT = -1
	End Function
End Module