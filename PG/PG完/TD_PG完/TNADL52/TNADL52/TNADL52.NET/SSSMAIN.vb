Option Strict Off
Option Explicit On
Module SSSMAIN_DL4
	'
	Public SSS_CHK As Short
	Public SSS_MFIL_KeyNo As Short
	Public SSS_SelectFL As Boolean
	
	Public SSS_MaxPage As Short '最大格納頁数(1～ )
	Public SSS_SQLPage As Short 'ＳＱＬ取得頁数(1～ )
	Public SSS_CurPage As Short 'カレント頁(1～ )
	Public SSS_LastPage As Short '最終頁(1～ )
	Public SSS_PageLine As Short '頁内行数(1～ )
	Public SSS_LastLine As Short '最終頁最終行（1 ～ SSS_PageLine）
	Public SSS_WrkKey As String 'KEY設定用ワーク
	Public SSS_LastSTOP As Boolean
	Public SSS_NoDataDSP As Boolean
	
	Sub CRW_END()
	End Sub
	
	Sub SSS_CLOSE()
		Call DB_End()
	End Sub
	
	'ファイルにカレントレコードの追加処理を行う。
	Function SSSMAIN_Append() As Object
	End Function
	
	'追加モードになるときの処理を行う。
	Function SSSMAIN_AppendC() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_AppendC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_AppendC = True
	End Function
	
	'画面表示前の初期設定処理を行う。
	Function SSSMAIN_BeginPrg(ByRef PP As clsPP) As Object
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '20190711 DEL START
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '' "しばらくお待ちください" ウィンドウ表示  97/05/29
        ''UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        'Load(ICN_ICON)
        '20190711 DEL END
        SSS_NoDataDSP = False
		'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_BeginPrg = True
		'----------------------------------
		'   SSSWIN プログラム起動チェック
		'----------------------------------
		SSS_PageLine = PP_SSSMAIN.MaxDspC + 1
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
	
	'カレント頁データを表示する。
	Function SSSMAIN_Current() As Object
		Dim I As Short
		Dim W_DBSTAT As Short
		'
		Call DSP_HEAD()
		If SSS_LastPage < 1 Then Exit Function
		I = 0
		Do While I < SSS_PageLine
			Call DSP_BODY(I)
			I = I + 1
			If SSS_CurPage = SSS_LastPage Then
				If I >= SSS_LastLine Then Exit Do
			End If
		Loop 
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Current = I
	End Function
	
	'ファイルからカレントレコードを削除する。
	Function SSSMAIN_Delete() As Object
	End Function
	
	'処理対象のデータの中の先頭のレコードを読み込む。
	Function SSSMAIN_First() As Object
	End Function
	
	'表示モードになるときの処理を行う。
	Function SSSMAIN_Indicate() As Object
		Dim rtn As Short
		'
		SSS_CurPage = 0
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
		Call SET_GAMEN_KEY()
		rtn = GET_DSP_DATA()
		If rtn = True Then
			CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = True
			CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = True
			If Link_ON And Not SSS_SelectFL Then
				CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = False
				CType(FR_SSSMAIN.Controls("CM_SELECTCM"), Object).Enabled = False
			Else
				CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = True
				CType(FR_SSSMAIN.Controls("CM_SELECTCM"), Object).Enabled = True
			End If
		Else
			If SSS_NoDataDSP Then
				Call DSP_HEAD()
			Else
				Call DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			End If
			CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = False
			CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = False
		End If
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '既定値
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Indicate の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Indicate = rtn
	End Function
	
	'処理対象のデータの中の最終のレコードを読み込む。
	Function SSSMAIN_Last() As Object
	End Function
	
	'処理対象のデータの中からカレントの次のレコードを読み込む。
	Function SSSMAIN_Next() As Object
		Dim rtn As Short
		'
		If SSS_CurPage < SSS_LastPage Then
			SSS_CurPage = SSS_CurPage + 1
		ElseIf SSS_CurPage >= SSS_MaxPage Then 
			'Call DSP_MsgBox(SSS_ERROR, "ENDREC", 0)     ' これ以降のデータはありません。
			MsgBox("最終頁です｡ 再度条件を入力してください｡")
		Else
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
			Call SET_DATA_KEY()
			rtn = GET_DSP_DATA()
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '既定値
			If rtn = False Then
				Call DSP_MsgBox(SSS_ERROR, "ENDREC", 0) ' これ以降のデータはありません。
			End If
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Next = SSSMAIN_Current()
	End Function
	
	'処理対象のデータの中からカレントの一つ前のレコードを読み込む。
	Function SSSMAIN_Prev() As Object
		'
		If SSS_CurPage <= 1 Then
			MsgBox("先頭頁です｡ 再度条件を入力してください｡")
		Else
			SSS_CurPage = SSS_CurPage - 1
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Prev = SSSMAIN_Current()
	End Function

    '処理対象のデータの範囲を設定する。
    Function SSSMAIN_Select() As Object
        '20190712 DELL START
        'CType(FR_SSSMAIN.Controls("MN_PREV"), Object).Enabled = True
        'CType(FR_SSSMAIN.Controls("MN_NEXTCM"), Object).Enabled = True
        'CType(FR_SSSMAIN.Controls("MN_SELECTCM"), Object).Enabled = True
        '' 97/09/17 リンク時の初期表示対応
        ''SSSMAIN_Select = 1
        'If Link_ON And Not SSS_SelectFL Then
        '    'UPGRADE_WARNING: オブジェクト SSSMAIN_Select の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    SSSMAIN_Select = 2
        'Else
        '    'UPGRADE_WARNING: オブジェクト SSSMAIN_Select の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    SSSMAIN_Select = 1
        'End If
        '20190712 DELL END
    End Function

    'ファイルの中のカレントレコードの更新を行う。
    Function SSSMAIN_Update() As Object
	End Function
	
	'更新モードになるときの処理を行う。
	Function SSSMAIN_UpdateC() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_UpdateC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_UpdateC = True
	End Function
	
	'画面から入出力バッファにデータを転送する。
	Sub SSSMfil_FromScr(ByVal De As Short)
	End Sub
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
End Module