Option Strict Off
Option Explicit On
Module HINCD_F84
	'
	' スロット名        : 商品コード・画面項目スロット
	' ユニット名        : HINCD.F81
	' 記述者            : Muratani
	' 作成日付          : 2006/08/29
	' 使用プログラム名  : HINMR61
	'
	
	Function HINCD_CheckC(ByRef PP As clsPP, ByRef CP_HINCD As clsCP, ByVal De_Index As Object, ByRef HINCD As Object) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: オブジェクト HINCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HINCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then Exit Function
		' < ORACLEエンジンとJETエンジンの仕様の違いに関わる誤ったカストマイズを防ぐため >
		' < ユニット内に本来不要(eeeで処理済）なコード中の英字を大文字化する処理を追加  >
		'
		' 【小文字を入力できるようにカストマイズする場合は以下の点に注意してください。】
		'    -"ABC-0123"と"abc-0123"という２つのレコードの作成は許されません。
		'    -コードの大小は、画面上では文字コード順、帳票上ではアルファベット順（大文字
		'     ／小文字関係なし）となりますのでソート結果、検索結果に注意が必要です。
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HINCD = UCase(HINCD)
		'
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetEq(DBN_HINMTA, 1, HINCD & Space(10 - Len(HINCD)), BtrNormal)
        If DBSTAT <> 0 Then
            '20190705 DELL START
            'Call HINMTA_RClear()
            '20190705 DELL END
            '''        Call Dsp_Prompt("RNOTFOUND", 0)             ' 新規レコードです。
            '''        HINCD_CheckC = -1
            'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当するレコードが存在しません
            'UPGRADE_WARNING: オブジェクト HINCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            HINCD_CheckC = 1

        Else

            If DB_HINMTA.DATKB = "9" Then
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4)
				'UPGRADE_WARNING: オブジェクト HINCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HINCD_CheckC = -1
			Else
				If DB_HINMTA.ZAIKB = "9" Then
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_CONFRM, "TNADL51", 0) '在庫管理対象外の為エラー
					'UPGRADE_WARNING: オブジェクト HINCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					HINCD_CheckC = -1
				Else
					If DB_HINMTA.KHNKB = "9" Then
						'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Rtn = DSP_MsgBox(SSS_ERROR, "HINCD", 0) '仮製品の為エラー
						'UPGRADE_WARNING: オブジェクト HINCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						HINCD_CheckC = -1
					End If
				End If
			End If
			'
			'''        If Trim$(DB_HINMTA.KHNKB) = "9" Or Trim$(DB_HINMTA.KHNKB) = "" Then
			'''       '     FR_SSSMAIN.LB_KARINM.Caption = "仮登録"
			'''        Else
			'''      '      FR_SSSMAIN.LB_KARINM.Caption = ""
			'''        End If
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call SCR_FromHINMTA(De_Index)
			
			SSS_LASTKEY.Value = DB_HINMTA.HINCD
			
		End If
		
	End Function

    Function HINCD_Slist(ByRef PP As clsPP, ByVal HINCD As Object) As Object
        '20190708 CHG START
        'WLSHIN.Text = "製品一覧"
        WLSHIN4.Text = "製品一覧"
        '20190708 CHG END
        '20190708 DELL START
        'DB_PARA(DBN_HINMTA).KeyNo = 1
        ''    DB_PARA(DBN_HINMTA).KeyBuf = HINCD
        'DB_PARA(DBN_HINMTA).KeyBuf = ""
        '20190708 DELL END
        '20190708 CHG START
        'WLSHIN.ShowDialog()
        'WLSHIN.Close()
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        '20190708 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト HINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        HINCD_Slist = PP.SlistCom
    End Function
End Module