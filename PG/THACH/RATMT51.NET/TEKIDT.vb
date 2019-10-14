Option Strict Off
Option Explicit On
Module TEKIDT_F51
	'
	' スロット名        : 単価設定日付・画面項目スロット
	' ユニット名        : TEKIDT.FM1
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/28
	' 使用プログラム名  : RATMT51
	'
	
	Function TEKIDT_Check(ByVal TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		Dim wkTUKKB As String
		'
		'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TEKIDT_Check = 0
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(TEKIDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
			'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TEKIDT_Check = -1
			'Call TUKMTA_RClear
			
		Else
			If Not IsDate(TEKIDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
				'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TEKIDT_Check = -1
				'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TEKIDT = ""
			Else
				'最新データ存在ﾁｪｯｸ
				'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If TEKIDT_Check = 0 Then
                    '                If CLng(Format(TEKIDT, "YYYYMMDD")) < CLng(DB_UNYMTA.UNYDT) Then
                    'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。                    
                    '2019/10/14 CHG START
                    'Call DB_GetGrEq(DBN_TUKMTA, 2, "1" & TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
                    GetRowsCommon(DBN_TUKMTA, "WHERE DATKB = '1' AND TUKKB = '" & TUKKB & "' AND TEKIDT = '" & VB6.Format(TEKIDT, "YYYYMMDD") & "'")
                    '2019/10/14 CHG END
                    'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If (DBSTAT = 0) And (DB_TUKMTA.DATKB = "1") And (DB_TUKMTA.TUKKB = TUKKB) And (DB_TUKMTA.TEKIDT > VB6.Format(TEKIDT, "YYYYMMDD")) Then
						Rtn = DSP_MsgBox(SSS_CONFRM, "RATMT51", 0) '既に新しい日付で登録済の為エラー
						'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						TEKIDT_Check = -1
					End If
					'                End If
				End If
			End If
		End If
		
		'適用日にデータが入ったら、当該データを検索
		'UPGRADE_WARNING: オブジェクト TEKIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If TEKIDT_Check = 0 Then
            'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/14 CHG START
            'Call DB_GetEq(DBN_TUKMTA, 1, TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
            GetRowsCommon(DBN_TUKMTA, "WHERE DATKB = '1' AND TUKKB = '" & TUKKB & "' AND TEKIDT = '" & VB6.Format(TEKIDT, "YYYYMMDD") & "'")
            '2019/10/14 CHG END
            If DBSTAT = 0 Then
				Call SCR_FromMfil(De_Index)
				If DB_TUKMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(De_Index, "削除")
				Else
					Call DP_SSSMAIN_UPDKB(De_Index, "更新")
				End If
				'20081002 ADD START RISE)Tanimura '排他処理
				' [引数De_Indexは画面上の行数(0～)]
				M_RATMT_A_inf(De_Index).OPEID = DB_TUKMTA.OPEID ' 最終作業者コード
				M_RATMT_A_inf(De_Index).CLTID = DB_TUKMTA.CLTID ' クライアントＩＤ
				M_RATMT_A_inf(De_Index).WRTTM = DB_TUKMTA.WRTTM ' タイムスタンプ（時間）
				M_RATMT_A_inf(De_Index).WRTDT = DB_TUKMTA.WRTDT ' タイムスタンプ（日付）
				M_RATMT_A_inf(De_Index).UOPEID = DB_TUKMTA.UOPEID ' ユーザID（バッチ）
				M_RATMT_A_inf(De_Index).UCLTID = DB_TUKMTA.UCLTID ' クライアントID（バッチ）
				M_RATMT_A_inf(De_Index).UWRTTM = DB_TUKMTA.UWRTTM ' タイムスタンプ（バッチ時間）
				M_RATMT_A_inf(De_Index).UWRTDT = DB_TUKMTA.UWRTDT ' タイムスタンプ（バッチ日）
				'20081002 ADD END   RISE)Tanimura
			Else
				Call DP_SSSMAIN_UPDKB(De_Index, "追加")
				'20081002 ADD START RISE)Tanimura '排他処理
				Call RATMT51_MF_Clear_UWRTDTTM(De_Index)
				'20081002 ADD END   RISE)Tanimura
			End If
			
		End If
	End Function
	
	Function TEKIDT_DerivedC(ByVal TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Short) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TEKIDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TEKIDT_DerivedC = TEKIDT
        'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(TUKKB) = "" Then
            '2019/09/24 DEL START
            'Call TUKMTA_RClear()
            '2019/09/24 DEL E N D
        Else
            'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Select Case Trim(TEKIDT)
				Case ""
					'TEKIDT_DerivedC = Date           '本日の日付。
					'UPGRADE_WARNING: オブジェクト TEKIDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					TEKIDT_DerivedC = DB_UNYMTA.UNYDT '運用日付
				Case Else
					'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(TEKIDT) <> "" Then
						'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト TEKIDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						TEKIDT_DerivedC = TEKIDT
					Else
						'TEKIDT_DerivedC = Date
						'UPGRADE_WARNING: オブジェクト TEKIDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						TEKIDT_DerivedC = DB_UNYMTA.UNYDT '運用日付
					End If
			End Select
			
		End If
	End Function
	
	Function TEKIDT_InitVal(ByVal TEKIDT As Object, ByVal TUKKB As Object, ByVal De_Index As Short) As Object
		'
		'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TUKKB) = "" Then
			'UPGRADE_WARNING: オブジェクト TEKIDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TEKIDT_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(TEKIDT) = "" Then
				'TEKIDT_InitVal = Date
				'UPGRADE_WARNING: オブジェクト TEKIDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TEKIDT_InitVal = DB_UNYMTA.UNYDT '運用日付
			End If
		End If
		
	End Function
	
	Function TEKIDT_Skip(ByRef CT_TEKIDT As System.Windows.Forms.Control, ByVal TEKIDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TEKIDT) <> "" Then
            'UPGRADE_WARNING: オブジェクト CT_TEKIDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/24 CHG START
            'CT_TEKIDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
            DirectCast(CT_TEKIDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
            '2019/09/24 CHG E N D
        End If
		'UPGRADE_WARNING: オブジェクト TEKIDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TEKIDT_Skip = False
	End Function
	
	Function TEKIDT_Slist(ByVal TEKIDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = TEKIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト TEKIDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TEKIDT_Slist = Set_date.Value
	End Function
End Module