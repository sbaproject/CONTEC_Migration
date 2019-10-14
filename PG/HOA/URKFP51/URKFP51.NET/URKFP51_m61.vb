Option Strict Off
Option Explicit On
Module URKFP51_M61
	'
	' スロット名        : FBデータ取込ﾜｰｸ更新・メインファイル更新スロット
	' ユニット名        : URKFP51.M61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : URKFP51
	'
	Const lngItemMax As Integer = 13
	
	Sub BATMAN()
		Dim rtn As Integer
		
		rtn = WRTTRN
		
		'戻り値によりメッセージを変更
		If rtn = 0 Then
			'正常終了時
			rtn = DSP_MsgBox("0", "CSV_CONFIRM", 4) 'CSVファイルを取込ました。
		End If
	End Sub
	
	Function WRTTRN() As Short
		
		Dim RecCount As Integer
		Dim rt As Short
		Dim rtn As Short
		Dim WL_WinDir As String
		Dim wLength As Short
		Dim rtnPara As New VB6.FixedLengthString(128)
		Dim wkPATH As String
		Dim wkFILE As String
		Dim strPath As String
		'
		Dim fso As Object
		Dim wkFil As String
		Dim wkExt As String
		
		WRTTRN = 9 '途中で処理が失敗すると9が返る 2006/12/26 FJCL)Saito
		
		RecCount = 0
		'
		On Error GoTo ERR_SYORI
		'
		'DELETE 2006/12/26 FJCL)Saito
		'    WL_WinDir = Environ$("WINDIR")
		'    If WL_WinDir = "" Then
		'        MsgBox "環境変数 ""WINDIR"" が取得できません。"
		'        Call Error_Exit("環境変数 ""WINDIR"" が取得できません。")
		'    End If
		
		'    strPath = Trim(LC_strPG_ID) & ".csv"
		'    strPath = WL_WinDir
		'    CommonDialog1.InitDir = SSS_INIDAT(3)   '初期表示ディレクトリをセット
		'        CommonDialog1.FileName = strPath        'ファイル名をデフォルトセット
		'DELETE
		
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.FILEDLG.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FR_SSSMAIN.FILEDLG.FileName = ""
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.FILEDLG.ShowOpen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FR_SSSMAIN.FILEDLG.ShowOpen() 'ダイアログを開く
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.FILEDLG.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strPath = FR_SSSMAIN.FILEDLG.FileName '選択されたファイル名を変数に格納
		
		'ダイアログ画面でパスが取得できなかったときは処理終了
		If strPath = "" Then
			WRTTRN = 1
			Exit Function
		End If
		
		'DELETE 2006/12/26 FJCL)Saito
		'    If Right$(Trim$(WL_WinDir), 1) <> "\" Then
		'        WL_WinDir = WL_WinDir & "\"
		'    End If
		'
		'    wLength = GetPrivateProfileString("FBDATA", ByVal "IN_PATH", "", rtnPara, 128, ByVal WL_WinDir & "SSSWIN.INI")
		'    If wLength = 0 Then
		'        MsgBox "SSSWIN.INI を確認してください。" & Chr(13) & "[" & "IN_PATH" & "]"
		'        Call Error_Exit("SSSWIN.INI を確認してください。[" & "IN_PATH" & "]")
		'    Else
		'        wkPATH = Left$(rtnPara, wLength)
		'    End If
		'
		'    If Right$(Trim$(wkPATH), 1) <> "\" Then
		'        wkPATH = wkPATH & "\"
		'    End If
		'
		'    wLength = GetPrivateProfileString("FBDATA", ByVal "IN_FILE", "", rtnPara, 128, ByVal WL_WinDir & "SSSWIN.INI")
		'    If wLength = 0 Then
		'        MsgBox "SSSWIN.INI を確認してください。" & Chr(13) & "[" & "IN_FILE" & "]"
		'        Call Error_Exit("SSSWIN.INI を確認してください。[" & "IN_FILE" & "]")
		'    Else
		'        wkFILE = Left$(rtnPara, wLength)
		'    End If
		'
		'DELETE 2006/12/26 FJCL)Saito
		
		'    wkFILE = wkPATH & wkFILE
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.FILEDLG.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkFILE = FR_SSSMAIN.FILEDLG.FileName
		'
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'
		'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
		'チェックがある場合は、削除処理を行う
		If FR_SSSMAIN.HD_ALLDEL.CheckState = 1 Then
			'''' ADD 2011/05/19  FKS) T.Yamamoto    End
			If DEL_FBDATA() = 9 Then '2006.11.06
				GoTo ERR_SYORI '2006.11.06
			End If '2006.11.06
			'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
		End If
		'''' ADD 2011/05/19  FKS) T.Yamamoto    End
		
		'2006.11.06 固定長ＣＳＶから可変長ＣＳＶに変更
		If GET_FBDATA(wkFILE, RecCount) = 9 Then
			GoTo ERR_SYORI
		End If
		
		If RecCount = 0 Then
			rtn = MsgBox("該当データはありません。", CDbl(MsgBoxStyle.OKOnly & MB_ICONEXCLAMATION), SSS_PrgNm)
			'
			Call DB_AbortTransaction()
			WRTTRN = 8
		Else
			fso = CreateObject("Scripting.FileSystemObject")
			'
			'支払データのファイル名取得(拡張子なしの名称)
			'UPGRADE_WARNING: オブジェクト fso.GetBaseName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkFil = fso.GetBaseName(wkFILE)
			'
			'支払データの拡張子取得
			'UPGRADE_WARNING: オブジェクト fso.GetExtensionName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkExt = "." & fso.GetExtensionName(wkFILE)
			'
			'ファイル名の変更(同じディレクトリ内に別名で移動すれば、名前を変更したことになる)
			'UPGRADE_WARNING: オブジェクト fso.MoveFile の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call fso.MoveFile(wkFILE, wkPATH & "取込済_" & VB6.Format(Now, "YYYYMMDD") & wkFil & wkExt)
			'
			Call DB_EndTransaction()
			WRTTRN = 0
		End If
		
		Exit Function
		'
ERR_SYORI: 
		rt = DSP_MsgBox("0", "CSV_CONFIRM", 3)
		'    rt = MsgBox("ファイルの抽出に失敗しました。", MB_OK + MB_ICONSTOP, Trim$(SSS_PrgNm))
		Call DB_AbortTransaction()
		'
	End Function
	
	Private Function DEL_FBDATA() As Short
		
		Dim strSQL As String
		
		DEL_FBDATA = 9
		
		'// ↓ UPD 2008-12-26 RISE)Morita
		''''    strSql = ""
		''''    strSql = strSql & "Delete From FBTRA"
		''''    strSql = strSql & " Where DATKB = '9'"
		strSQL = ""
		strSQL = strSQL & " DELETE "
		strSQL = strSQL & " FROM FBTRA"
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
		'    If FR_SSSMAIN.HD_ALLDEL.Value = 1 Then
		'        'チェックがある場合は、全削除
		'    Else
		'        strSql = strSql & " WHERE DATKB = '9'"
		'    End If
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		'// ↑ UPD 2008-12-26 RISE)Morita
		
		Call DB_Execute(DBN_FBTRA, strSQL)
		If DBSTAT = 0 Then
			DEL_FBDATA = 0
		End If
		
	End Function
	
	'最大のFBRFNOの番号を取得する関数 Add 2006/12/26 FJCL)Saito
	Private Function GET_FBRFNO() As String
		Dim strSQL As String
		
		GET_FBRFNO = ""
		
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(FBRFNO) From FBTRA"
		
		Call DB_GetSQL2(DBN_FBTRA, strSQL)
		'SQL実行に成功した時の処理
		If DBSTAT = 0 Then
			GET_FBRFNO = CStr(DB_ExtNum.ExtNum(0))
		End If
		
	End Function
	
	'''' ADD 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
	'''' UPD 2011/09/02  FKS) T.Yamamoto    Start    連絡票№FC11090201
	''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    連絡票№FC11072001
	''Private Function CNT_FBTRA(ByVal strFBRFNO As String) As Integer
	'Private Function CNT_FBTRA(ByVal strFBRFNO As String, ByVal strFBBNKCD As String) As Integer
	''''' UPD 2011/07/20  FKS) T.Yamamoto    End
	Private Function CNT_FBTRA(ByVal strFBRFNO As String, ByVal strFBCLTCD As String, ByVal strFBBNKCD As String) As Short
		'''' UPD 2011/09/02  FKS) T.Yamamoto    End
		Dim strSQL As String
		
		CNT_FBTRA = 0
		
		'''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11111501
		''''' UPD 2011/09/02  FKS) T.Yamamoto    Start    連絡票№FC11090201
		'''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    連絡票№FC11072001
		'''    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO
		''    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO & " AND FBBNKCD = " & strFBBNKCD
		'''''' UPD 2011/07/20  FKS) T.Yamamoto    End
		'    strSql = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = " & strFBRFNO & " AND FBCLTCD = " & strFBCLTCD & " AND FBBNKCD = " & strFBBNKCD
		''''' UPD 2011/09/02  FKS) T.Yamamoto    End
		strSQL = "SELECT COUNT(FBRFNO) FROM FBTRA WHERE FBRFNO = '" & strFBRFNO & "' AND FBCLTCD = '" & strFBCLTCD & "' AND FBBNKCD = '" & strFBBNKCD & "'"
		'''' UPD 2011/11/15  FKS) T.Yamamoto    End
		
		Call DB_GetSQL2(DBN_FBTRA, strSQL)
		
		If DBSTAT = 0 Then
			CNT_FBTRA = DB_ExtNum.ExtNum(0)
		End If
		
	End Function
	'''' ADD 2011/05/19  FKS) T.Yamamoto    End
	
	Private Function GET_FBDATA(ByVal strFullPath As String, ByRef lngRecCount As Integer) As Short
		Dim Fno As Integer
		Dim strDATA As String
		Dim strAry(lngItemMax) As String
		Dim lngPos As Integer
		Dim i As Integer
		Dim lngStart As Integer
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
		'    Dim strSeqno                        As String
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		
		GET_FBDATA = 9
		
		lngRecCount = 0
		
		Fno = FreeFile
		
		FileOpen(Fno, strFullPath, OpenMode.Input)
		
		'''' DEL 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
		'    '初期連番値をセット 2006/12/26 FJCL)Saito
		'    strSeqno = Format(GET_FBRFNO + 1, "000000")
		'''' DEL 2011/05/19  FKS) T.Yamamoto    End
		
		Do While Not EOF(1)
			strDATA = LineInput(Fno)
			lngRecCount = lngRecCount + 1
			
			'ダブルクォーテーションの削除 2006/12/26 FJCL)Saito
			strDATA = Replace(strDATA, """", "", 1, -1)
			
			'配列クリア
			For i = 0 To UBound(strAry)
				strAry(i) = ""
			Next i
			
			'レコードをカンマで分割して配列にセット
			lngStart = 1
			lngPos = InStr(lngStart, strDATA, ",")
			i = 0
			Do While lngPos <> 0
				strAry(i) = strAry(i) & Mid(strDATA, lngStart, lngPos - lngStart)
				'
				lngStart = lngPos + 1
				lngPos = InStr(lngStart, strDATA, ",")
				i = i + 1
			Loop 
			
			'FB入金ファイルのレコード種類チェック
			Select Case strAry(0)
				Case "1" 'ヘッダ
					DB_URKFP51A.FBDATKB = strAry(0) 'As String * 1     'データ区分
					DB_URKFP51A.FBSBTCD = strAry(1) 'As String * 2     '種別コード
					DB_URKFP51A.FBCODKB = strAry(2) 'As String * 1     'コード区分
					DB_URKFP51A.FBMAKDT = strAry(3) 'As String * 6     '作成日
					DB_URKFP51A.FBKJSDT = strAry(4) 'As String * 6     '勘定日（自）
					DB_URKFP51A.FBKJEDT = strAry(5) 'As String * 6     '勘定日（至）
					DB_URKFP51A.FBGINCD = strAry(6) 'As String * 4     '銀行コード
					DB_URKFP51A.FBGINNM = strAry(7) 'As String * 15    '銀行名
					DB_URKFP51A.FBSTNCD = strAry(8) 'As String * 3     '支店コード
					DB_URKFP51A.FBSTNNM = strAry(9) 'As String * 15    '支店名
					DB_URKFP51A.FBYKNKB = strAry(10) 'As String * 1     '預金種別
					DB_URKFP51A.FBKOZNO = strAry(11) 'As String * 7     '口座番号
					DB_URKFP51A.FBKOZNM = strAry(12) 'As String * 40    '口座名
					DB_URKFP51A.FBDMYELA = strAry(13) 'As String * 93    'ダミーA
				Case "2" 'データ
					'データAかデータBの判定ができないが今回必要な部分には関係ないのでデータAのレイアウトとする
					DB_URKFP51B.FBDATKB = strAry(0) 'As String * 1     'データ区分
					'''' UPD 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
					'照会番号のセットを戻す
					'                '照会番号のセット方法を連番に変更 2006/12/26 FJCL)Saito
					''               DB_URKFP51B.FBRFNO = strAry(1)          'As String * 6     '照会番号
					'                DB_URKFP51B.FBRFNO = strSeqno
					'                strSeqno = Format(strSeqno + 1, "000000")
					DB_URKFP51B.FBRFNO = strAry(1) 'As String * 6     '照会番号
					'''' UPD 2011/05/19  FKS) T.Yamamoto    End
					DB_URKFP51B.FBKJNDT = strAry(2) 'As String * 6     '勘定日
					DB_URKFP51B.FBKSNDT = strAry(3) 'As String * 6     '起算日
					DB_URKFP51B.FBNYKEL = strAry(4) 'As String * 10    '金額
					DB_URKFP51B.FBTTKEL = strAry(5) 'As String * 10    'うち他店券金額
					DB_URKFP51B.FBCLTCD = strAry(6) 'As String * 10    '振込依頼人コード
					DB_URKFP51B.FBCLTNM = strAry(7) 'As String * 48    '振込依頼人名
					DB_URKFP51B.FBSMGNM = strAry(8) 'As String * 15    '仕向銀行名
					DB_URKFP51B.FBSMSNM = strAry(9) 'As String * 15    '仕向支店名
					DB_URKFP51B.FBDELKB = strAry(10) 'As String * 1     '取消区分
					DB_URKFP51B.FBEDIEL = strAry(11) 'As String * 20    'ＥＤＩ情報
					DB_URKFP51B.FBDMYELB = strAry(12) 'As String * 52    'ダミーB
				Case "8" 'トレーラ
					'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
					DB_URKFP51D = LSet(DB_URKFP51)
					DB_URKFP51D.FBDATKB = strAry(0) 'As String * 1     'データ区分
					DB_URKFP51D.FBFGSEL = strAry(1) 'As String * 6     '振込合計件数
					DB_URKFP51D.FBFGKEL = strAry(2) 'As String * 12    '振込合計金額
					DB_URKFP51D.FBTGSEL = strAry(3) 'As String * 6     '取消合計件数
					DB_URKFP51D.FBTGKEL = strAry(4) 'As String * 12    '取消合計金額
					DB_URKFP51D.FBDMYELD = strAry(5) 'As String * 163   'ダミーD
				Case "9" 'エンド
					'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
					DB_URKFP51E = LSet(DB_URKFP51)
					DB_URKFP51E.FBDATKB = strAry(0) 'As String * 1     'データ区分
					DB_URKFP51E.FBDMYELE = strAry(1) 'As String * 199   'ダミーE
				Case Else 'その他
			End Select
			
			If strAry(0) = "2" Then
				DB_FBTRA.DATKB = "1"
				'
				Call FBTRA_FromURKFP51A() '文字項目はIRTでセット(但し日付の項目と銀行は単純転送できないので別転送とする)
				Call FBTRA_FromURKFP51B() '文字項目はIRTでセット(但し日付の項目と金額は単純転送できないので別転送とする)
				
				'日付項目は変換が必要
				'2019/04/02 UPD START <C2-20190123-01> CIS)山口
				'If Trim$(DB_URKFP51B.FBKJNDT) <> "" Then DB_FBTRA.FBKJDT = CStr(Val(DB_URKFP51B.FBKJNDT) + 19880000):
				'If Trim$(DB_URKFP51B.FBKSNDT) <> "" Then DB_FBTRA.FBKSDT = CStr(Val(DB_URKFP51B.FBKSNDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBMAKDT) <> "" Then DB_FBTRA.FBSSDT = CStr(Val(DB_URKFP51A.FBMAKDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBKJSDT) <> "" Then DB_FBTRA.FBKJJDT = CStr(Val(DB_URKFP51A.FBKJSDT) + 19880000):
				'If Trim$(DB_URKFP51A.FBKJEDT) <> "" Then DB_FBTRA.FBKJIDT = CStr(Val(DB_URKFP51A.FBKJEDT) + 19880000):
				If Trim(DB_URKFP51B.FBKJNDT) <> "" Then DB_FBTRA.FBKJDT = CStr(Val(DB_URKFP51B.FBKJNDT) + 20180000)
				If Trim(DB_URKFP51B.FBKSNDT) <> "" Then DB_FBTRA.FBKSDT = CStr(Val(DB_URKFP51B.FBKSNDT) + 20180000)
				If Trim(DB_URKFP51A.FBMAKDT) <> "" Then DB_FBTRA.FBSSDT = CStr(Val(DB_URKFP51A.FBMAKDT) + 20180000)
				If Trim(DB_URKFP51A.FBKJSDT) <> "" Then DB_FBTRA.FBKJJDT = CStr(Val(DB_URKFP51A.FBKJSDT) + 20180000)
				If Trim(DB_URKFP51A.FBKJEDT) <> "" Then DB_FBTRA.FBKJIDT = CStr(Val(DB_URKFP51A.FBKJEDT) + 20180000)
				'2019/04/02 UPD END <C2-20190123-01> CIS)山口
				
				'口座番号編集               '2006.11.06
				DB_FBTRA.FBKOZNO = New String("0", Len(DB_URKFP51A.FBKOZNO) - Len(Trim(DB_URKFP51A.FBKOZNO))) & Trim(DB_URKFP51A.FBKOZNO)
				
				'銀行コード編集             '2006.11.06
				DB_FBTRA.FBBNKCD = New String("0", Len(DB_URKFP51A.FBGINCD) - Len(Trim(DB_URKFP51A.FBGINCD))) & Trim(DB_URKFP51A.FBGINCD) & New String("0", Len(DB_URKFP51A.FBSTNCD) - Len(Trim(DB_URKFP51A.FBSTNCD))) & Trim(DB_URKFP51A.FBSTNCD)
				
				'入金額編集
				DB_FBTRA.FBNYUKN = CDec(Val(DB_URKFP51B.FBNYKEL))
				
				'振込依頼人名編集 2006/12/26 FJCL)Saito
				DB_FBTRA.FBCLTNM = Trim(Replace(DB_FBTRA.FBCLTNM, Trim(DB_FBTRA.FBCLTCD), "", 1, -1))
				
				'振込依頼人コード編集       '2006.11.06
				DB_FBTRA.FBCLTCD = Right(DB_FBTRA.FBCLTCD, 7) & "   "
				'
				DB_FBTRA.WRTTM = VB6.Format(Now, "hhmmss") '2006.11.06
				DB_FBTRA.WRTDT = VB6.Format(Now, "YYYYMMDD") '2006.11.06
				DB_FBTRA.WRTFSTTM = VB6.Format(Now, "hhmmss") '2006.11.06
				DB_FBTRA.WRTFSTDT = VB6.Format(Now, "YYYYMMDD") '2006.11.06
				
				'''' UPD 2011/05/19  FKS) T.Yamamoto    Start    自動入金登録対応
				'            Call DB_Insert(DBN_FBTRA, 1)
				'''' UPD 2011/09/02  FKS) T.Yamamoto    Start    連絡票№FC11090201
				''''' UPD 2011/07/20  FKS) T.Yamamoto    Start    連絡票№FC11072001
				''銀行、照会番号をキーとするよう変更
				''          If CNT_FBTRA(DB_FBTRA.FBRFNO) = 0 Then
				'          If CNT_FBTRA(DB_FBTRA.FBRFNO, DB_FBTRA.FBBNKCD) = 0 Then
				''''' UPD 2011/07/20  FKS) T.Yamamoto    End
				'銀行、口座、照会番号をキーとするよう変更
				If CNT_FBTRA(DB_FBTRA.FBRFNO, DB_FBTRA.FBCLTCD, DB_FBTRA.FBBNKCD) = 0 Then
					'''' UPD 2011/09/02  FKS) T.Yamamoto    End
					Call DB_Insert(DBN_FBTRA, 1)
				End If
				'''' UPD 2011/05/19  FKS) T.Yamamoto    End
			End If
		Loop 
		
		FileClose(Fno)
		
		GET_FBDATA = 0
		
	End Function
End Module