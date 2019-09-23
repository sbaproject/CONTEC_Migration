Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSUDN
	Inherits System.Windows.Forms.Form
	
	' 2008/07/02 ADD START FKS)NAKATA
	'XX 更新日付 :   2008/7/02
	'XX 更新理由 :   レスポンス対応
	'XX 更新内容
	'XX ①「*受注取区」をサブ画面にて選択した場合、即時検索させない
	'XX ②検索結果が０件の場合はメッセージを表示させる
	'XX
	'XX 本レスポンス対応ではコメントアウトを 「 'XX 」にて表記する。
	' 2008/07/02 ADD E.N.D FKS)NAKATA
	
	' 2008/07/03 ADD START FKS)NAKATA
	'XX 更新日付 :  2008/7/03
	'XX 更新理由 :   レスポンス対応
	'XX 更新内容
	'XX ①画面表示「*受注取区」(COM_JDNTRKB)を「受注取区」に変更
	'XX ②検索結果数を表示させる(100件以上の場合)
	'XX ③入力必須項目を「受注取区+客先注文番号」「受注番号」に設定する
	'XX ④必須項目の入力がない場合はメッセージを表示させる
	' 2008/07/03 ADD E.N.D FKS)NAKATA
	
	
	'2008/07/05 ADD START FKS)NAKATA
	'XX 画面表示記録用
	Private Structure TYPE_LSTBOX_EXC
		Dim LSTNO As String 'リストボックス番号
		Dim JDNNO As String '受注№
		Dim UDNDT As String '売上日
	End Structure
	Private WK_LSTBOX_BEF() As TYPE_LSTBOX_EXC
	
	Dim WM_WLS_LIST_END As Boolean '最終ページフラグ
	
	Dim WM_WLS_PAGE_END As Short '最終ページ番号
	Dim WM_WLS_LIST_CNT As Short '最終リスト番号
	Dim WM_WLS_PAGE_CLICK_NUM As Short 'ページ送りボタンクリック数
	
	'2008/07/05 ADD E.N.D FKS)NAKATA
	
	
	
	'以下の４行の設定を行うこと
	Const WM_WLS_MSTKB As String = "1" 'マスタ区分(1:得意先 2:納品先 3:担当者 4:仕入先 5:商品)
	Const WM_WLSKEY_ZOKUSEI As String = "0" '開始コード入力属性 [0,X]
	
	'検索キーNo（使用しない場合は-1を設定）
	Const WM_WLS_TextKey As Short = 10 '開始コードのソートキーNo
	Const WM_WLS_CDKey As Short = -1 'カナ検索のソートキーNo+第一キー
	
	'ウィンドﾕｰｻﾞｰ設定変数
	Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Dim WM_WLS_SFIL1 As Short 'ウィンド表示ｻﾌﾞﾌｧｲﾙ
	Dim WM_WLS_SFIL2 As Short 'ウィンド表示ｻﾌﾞﾌｧｲﾙ
	Dim WM_WLS_SFIL3 As Short 'ウィンド表示ｻﾌﾞﾌｧｲﾙ
	
	Dim WM_WLS_LEN As Short '開始ｺｰﾄﾞ入力文字数
	
	'ウィンド内部使用変数
	Dim WM_WLS_MAX As Short '１画面の表示件数
	Dim WM_WLS_STTKEY As Object '開始キー
	Dim WM_WLS_ENDKEY As Object '終了キー
	Dim WM_WLS_KeyCode As Short 'ｺﾝﾎﾞﾎﾞｯｸｽ表示用
	Dim WM_WLS_KeyNo As Short 'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
	Dim WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Dim WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	Dim WM_WLS_INIT As Short 'ウィンド初期表示ﾌﾗｸﾞ(True or False)
	
	Dim WlsSelList As String
	Dim SWlsSelList As Object
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	
	Private pv_blnChange_Flg As Boolean
	
	Private DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	'20090115 ADD START RISE)Tanimura '連絡票No.523
	Private mJDNTRKB As String ' 受注取区
	Private mJDNNO As String ' 受注番号
	Private mTOKJDNNO As String ' 客先注文番号
	'20090115 ADD END   RISE)Tanimura
	
	Private Sub COM_JDNTRKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_JDNTRKB.Click
		Dim wkJDNTRKB As String
		Dim strSQL As String
		
		WLS_MEI1.Text = "受注取引区分一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		
		Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		
		'2008/07/02 ADD START FKS)NAKATA
		'XX 受注取引区分一覧サブ画面にて区分が選択された時、即検索をさせないため追加
		WLSJDNTRKB.Text = ""
		WLSJDNTRNM.Text = ""
		'2008/07/02 ADD E.N.D FKS)NAKATA
		
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			WLSJDNTRKB.Text = ""
			WLSJDNTRNM.Text = ""
			Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
			Call P_SetFocus(WLSJDNTRKB)
			WLSJDNTRKB.SelectionStart = 0
			WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkJDNTRKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2)))
			Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
			If DBSTAT = 0 Then
				WLSJDNTRKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
				WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
				
				'2008/07/02 DEL START FKS)NAKATA
				'XX 受注取引区分一覧サブ画面にて区分が選択された時、即検索をさせないため消去
				
				'XX '            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'XX '            WM_WLS_ENDKEY = "9"
				'XX            WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'XX            WM_WLS_ENDKEY = "1" & "9"
				'XX            WM_WLS_KeyCode = 0
				'XX            WM_WLS_Dspflg = True
				'XX            WM_WLS_Pagecnt = -1
				'XX            DoEvents
				'XX '''            strSQL = ""
				'XX '''            strSQL = strSQL & " SELECT * FROM ( "
				'XX '''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
				'XX '''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX '''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX '''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
				'XX '''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'XX '''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'XX '''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX '''
				'XX '''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX '''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'XX            Call WLS_BaseSQL(WM_WLS_STTKEY)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                Call WLSSSS_DSP
				'XX            End If
				'XX            PP_SSSMAIN.SlistCom = Null
				'2008/07/02 DEL E.N.D FKS)NAKATA
			Else
				Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
				Call P_SetFocus(WLSJDNTRKB)
				WLSJDNTRKB.SelectionStart = 0
				WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
			End If
		End If
		
	End Sub
	
	Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		DB_PARA(DBN_TOKMTA).KeyBuf = WLSTOKCD.Text
		WLSTOK.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		''98/09/25 追加
		WLSTOK.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_TOKMTA.TOKCD = ""
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_TOKMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 5), BtrNormal)
			If DBSTAT = 0 Then
				WLSTOKCD.Text = RTrim(DB_TOKMTA.TOKCD)
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				
				'2008/07/04 DEL START FKS)NAKATA
				'XX サブ画面にて選ばれた場合、即検索行かないようにする。
				'XX            W_Key = "1" & "1" & HD_TEXT.Text
				'XX            DoEvents
				'XX'''            strSQL = ""
				'XX'''            strSQL = strSQL & " SELECT * FROM ( "
				'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX            Call WLS_BaseSQL(W_Key)
				'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                WM_WLS_INIT = 1
				'XX                Call WLSSSS_DSP
				'XX            End If
				'2008/07/04 DEL E.N.D FKS)NAKATA
				
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_NHSCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_NHSCD.Click
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		DB_PARA(DBN_NHSMTA).KeyBuf = WLSNHSCD.Text
		WLSNHS.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		''98/09/25 追加
		WLSNHS.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_NHSMTA.NHSCD = ""
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_NHSMTA, 1, VB.Left(PP_SSSMAIN.SlistCom, 9), BtrNormal)
			If DBSTAT = 0 Then
				WLSNHSCD.Text = DB_NHSMTA.NHSCD
				WM_WLS_KeyCode = -1
				WM_WLS_Dspflg = False
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				
				'2008/07/05 DEL START FKS)NAKATA
				'XX ボタンを押された場合、即検索に行かない
				'XX            W_Key = "1" & "1" & HD_TEXT.Text
				'XX            DoEvents
				'XX'''            strSQL = ""
				'XX'''            strSQL = strSQL & " SELECT * FROM ( "
				'XX'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
				'XX'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'XX'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'XX'''            strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || A.WRTFSTTM = B.DT "
				'XX'''            strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'XX'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'XX'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'XX'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'XX            Call WLS_BaseSQL(W_Key)
				'XX'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
				'XX            If WLSSSS_SET_KEYBAK() = True Then
				'XX                WM_WLS_INIT = 1
				'XX                Call WLSSSS_DSP
				'XX            End If
				'2008/07/05 DEL E.N.D FKS)NAKATA
			End If
		End If
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
	
	Private Sub COM_UDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_UDNDT.Click
		Dim I As Short
		Dim strSQL As String
		
		Set_date.Value = CNV_DATE(DB_UNYMTA.UNYDT)
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		System.Windows.Forms.Application.DoEvents()
		
		WLSUDNDT.Text = Set_date.Value
		'    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
		'    WM_WLS_ENDKEY = "9"
		'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_ENDKEY = "1" & "9"
		WM_WLS_KeyCode = 0
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		System.Windows.Forms.Application.DoEvents()
		'''    strSQL = ""
		'''    strSQL = strSQL & " SELECT * FROM ( "
		'''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
		'''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		'''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
		'''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
		'''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		'''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		'''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
		
		'2008/07/05 DEL START FKS)NAKATA
		'XX 日付が選択されて時に即検索にいかないよう消去
		'XX    Call WLS_BaseSQL(WM_WLS_STTKEY)
		'XX    If WLSSSS_SET_KEYBAK() = True Then
		'XX        Call WLSSSS_DSP
		'XX    End If
		'2008/07/05 DEL E.ND FKS)NAKATA
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
		
	End Sub
	
	'UPGRADE_WARNING: Form イベント WLSUDN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSUDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call WLSSSS_FORM_ACTIVATE()
		'DblClickイベント障害対応  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSUDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call WLS_FORM_LOAD()
		Call WLSSSS_FORM_INIT()
		pv_blnChange_Flg = False
	End Sub
	'
	
	'UPGRADE_WARNING: イベント HD_TEXT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
		Dim s As Integer
		s = HD_TEXT.SelectionStart
		HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.UpperCase)
		HD_TEXT.SelectionStart = s
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		''    If LenWid(HD_TEXT.Text) > 0 Then
		''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		''    Else
		''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		''    End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		Dim strSQL As String
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
				HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
				HD_TEXT.SelectionStart = 0
				'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
				HD_TEXT.SelectionLength = HD_TEXT.Maxlength
				'            WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'            WM_WLS_ENDKEY = "9"
				'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_ENDKEY = "1" & "9"
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_KeyNo = WM_WLS_TextKey
				'''            strSQL = ""
				'''            strSQL = strSQL & " SELECT * FROM ( "
				'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'''            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call WLS_BaseSQL(WM_WLS_STTKEY)
				
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				LST1.Items.Clear()
				WM_WLS_Pagecnt = -1
				'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				
				
				'        Case 40  '↓キー
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
	
	Private Sub HD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Enter
		HD_TOKJDNNO.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HD_TOKJDNNO.SelectionLength = LenWid(HD_TOKJDNNO.Text)
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			WM_WLS_INIT = 1
			Call WLSSSS_DSP()
		End If
	End Sub
	
	''Private Sub HD_TOKJDNNO_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        LST.ListIndex = 0
	'''''''    Else
	'''''''        WLSTOKCD.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSJDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSJDNTRKB.Enter
		''    If LenWid(WLSJDNTRKB.Text) > 0 Then
		''        WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
		''    Else
		''        WLSJDNTRKB.Text = Space$(LenWid(DB_UDNTHA.JDNTRKB))
		''    End If
		WLSJDNTRKB.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
		
	End Sub
	
	Private Sub WLSJDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSJDNTRKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Object
		Dim STAT As Short
		Dim wkJDNTRKB As String
		Dim strSQL As String
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				KEYBAK.Items.Clear()
				LST.Items.Clear()
				LST1.Items.Clear()
				WLSJDNTRKB.Text = SSS_EDTITM_WLS(WLSJDNTRKB.Text, LenWid(DB_UDNTHA.JDNTRKB), "0")
				WLSJDNTRKB.SelectionStart = 0
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLSJDNTRKB.SelectionLength = LenWid(DB_UDNTHA.JDNTRKB)
				If Trim(WLSJDNTRKB.Text) = "" Then
					Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
					Call P_SetFocus(WLSJDNTRKB)
					WLSJDNTRKB.SelectionStart = 0
					WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
					'2008/07/02 ADD START FKS)NAKATA
					'XX 受注取引区分がブランクの場合、表示を消す。
					WLSJDNTRNM.Text = ""
					'2008/07/02 ADD E.N.D FKS)NAKATA
				Else
					wkJDNTRKB = WLSJDNTRKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSJDNTRKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
					Call DB_GetEq(DBN_MEIMTA, 1, "006" & wkJDNTRKB, BtrNormal)
					If DBSTAT = 0 Then
						WLSJDNTRKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
						WLSJDNTRNM.Text = DB_MEIMTA.MEINMA
						'                    WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
						'                    WM_WLS_ENDKEY = "9"
						'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_ENDKEY = "1" & "9"
						WM_WLS_KeyCode = 0
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						'''                    strSQL = ""
						'''                    strSQL = strSQL & " SELECT * FROM ( "
						'''                    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
						'''                    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
						'''                    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
						'''                    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
						'''                    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
						'''                    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
						'''                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call WLS_BaseSQL(WM_WLS_STTKEY)
						'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If WLSSSS_SET_KEYBAK() = True Then
							Call WLSSSS_DSP()
						End If
					Else
						Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
						Call P_SetFocus(WLSJDNTRKB)
						WLSJDNTRKB.SelectionStart = 0
						WLSJDNTRKB.SelectionLength = Len(WLSJDNTRKB.Text)
						
					End If
				End If
				'        Case 40  '↓キー
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClickイベント障害対応  97/04/07
		DblClickFl = True
		
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case 13
				Call WLS_SLIST_MOVE(VB6.GetItemString(LST1, LST.SelectedIndex), WM_WLS_LEN)
				'DblClickイベント障害対応  97/04/07
				'Call WLSCANCEL_CLICK
				If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 27
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case 37 '←キー
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				'       Case 38  '↑キー
				'           If LST.ListIndex = 0 Then
				'               LST.ListIndex = -1
				'               HD_TEXT.SetFocus
				'           End If
			Case 39 '→キー
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
		
	End Sub
	
	Private Sub WLS_DISPLAY()
		'====================================
		'   WINDOW 明細表示
		'====================================
		Dim WK_JDNNO As New VB6.FixedLengthString(8)
		Dim WK_DENDT As New VB6.FixedLengthString(10)
		Dim WK_UDNDT As New VB6.FixedLengthString(10)
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			WK_JDNNO.Value = VB.Left(DB_UDNTRA.JDNNO, 6) & Mid(DB_UDNTRA.JDNLINNO, 2, 2)
			WK_UDNDT.Value = VB.Left(DB_UDNTRA.UDNDT, 4) & "/" & Mid(DB_UDNTRA.UDNDT, 5, 2) & "/" & VB.Right(DB_UDNTRA.UDNDT, 2)
			
			WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_UDNTRA.TOKCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
			
			Call NHSMTA_RClear()
			WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_UDNTRA.NHSCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)
			
			Call JDNTRA_RClear()
			WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND AKAKROKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND JDNNO = '" & DB_UDNTRA.JDNNO & "'"
			WlsFromWhere = WlsFromWhere & "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
			WlsOrderBy = " ORDER BY DATNO DESC"
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)
			
			WK_DENDT.Value = VB.Left(DB_JDNTRA.DENDT, 4) & "/" & Mid(DB_JDNTRA.DENDT, 5, 2) & "/" & VB.Right(DB_JDNTRA.DENDT, 2)
			
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			WK_JDNNO.Value = VB.Left(DB_ODNTRA.JDNNO, 6) & Mid(DB_ODNTRA.JDNLINNO, 2, 2)
			WK_UDNDT.Value = VB.Left(DB_ODNTRA.ODNDT, 4) & "/" & Mid(DB_ODNTRA.ODNDT, 5, 2) & "/" & VB.Right(DB_ODNTRA.ODNDT, 2)
			
			WlsFromWhere = "From TOKMTA Where TOKCD = '" & DB_ODNTRA.TOKCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL1, DB_SQLBUFF)
			
			Call NHSMTA_RClear()
			WlsFromWhere = "From NHSMTA Where NHSCD = '" & DB_ODNTRA.NHSCD & "'"
			WlsOrderBy = ""
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL2, DB_SQLBUFF)
			
			Call JDNTRA_RClear()
			WlsFromWhere = "From JDNTRA     Where DATKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND AKAKROKB = '1'"
			WlsFromWhere = WlsFromWhere & "   AND JDNNO = '" & DB_ODNTRA.JDNNO & "'"
			WlsFromWhere = WlsFromWhere & "   AND LINNO = '" & DB_ODNTRA.JDNLINNO & "'"
			WlsOrderBy = " ORDER BY DATNO DESC"
			'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
			Call DB_GetSQL2(WM_WLS_SFIL3, DB_SQLBUFF)
			
			WK_DENDT.Value = VB.Left(DB_JDNTRA.DENDT, 4) & "/" & Mid(DB_JDNTRA.DENDT, 5, 2) & "/" & VB.Right(DB_JDNTRA.DENDT, 2)
		End If
		'20090115 ADD END   RISE)Tanimura
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX 受注番号で検索したものには受注取区を表示しない
		Dim wkTRKB As String
		If Trim(HD_TEXT.Text) <> "" Then
			wkTRKB = ""
		Else
			wkTRKB = WLSJDNTRKB.Text
		End If
		'2008/07/05 E.N.D START FKS)NAKATA
		
		
		'2008/04/07 FKS)ASANO ADD START
		If VB.Left(WK_DENDT.Value, 4) <> "    " Then
			'2008/04/07 FKS)ASANO ADD END
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 売上済の場合
			If g_strURIKB = "1" Then
				'20090115 ADD END   RISE)Tanimura
				LST.Items.Add(WK_JDNNO.Value & " " & WK_UDNDT.Value & " " & WK_DENDT.Value & " " & LeftWid2(DB_UDNTRA.TOKCD, 5) & " " & LeftWid2(DB_TOKMTA.TOKRN, 20) & " " & LeftWid2(DB_UDNTRA.NHSCD, 9) & " " & LeftWid2(DB_NHSMTA.NHSRN, 20) & " " & LeftWid2(DB_UDNTRA.HINNMA, 20) & " " & LeftWid2(DB_UDNTRA.HINNMB, 10) & " " & New String(" ", 7 - Len(VB6.Format(DB_UDNTRA.URISU, "###,##0"))) & VB6.Format(DB_UDNTRA.URISU, "###,##0") & " " & wkTRKB)
				
				'2008/07/05 DEL START FKS)NAKATA
				'XX         + String(7 - Len(Format$(DB_UDNTRA.URISU, "###,##0")), " ") + Format$(DB_UDNTRA.URISU, "###,##0") + " " + WLSJDNTRKB       ' DB_UDNTHA.JDNTRKB
				'2008/07/05 DEL E.N.D FKS)NAKATA
				
				LST1.Items.Add(DB_UDNTRA.DATNO & DB_UDNTRA.LINNO & DB_UDNTRA.UDNNO)
				'20090115 ADD START RISE)Tanimura '連絡票No.523
				' 未売上の場合
			Else
				LST.Items.Add(WK_JDNNO.Value & " " & WK_UDNDT.Value & " " & WK_DENDT.Value & " " & LeftWid2(DB_ODNTRA.TOKCD, 5) & " " & LeftWid2(DB_TOKMTA.TOKRN, 20) & " " & LeftWid2(DB_ODNTRA.NHSCD, 9) & " " & LeftWid2(DB_NHSMTA.NHSRN, 20) & " " & LeftWid2(DB_ODNTRA.HINNMA, 20) & " " & LeftWid2(DB_ODNTRA.HINNMB, 10) & " " & New String(" ", 7 - Len(VB6.Format(DB_ODNTRA.OTPSU, "###,##0"))) & VB6.Format(DB_ODNTRA.OTPSU, "###,##0") & " " & wkTRKB)
				
				LST1.Items.Add(DB_ODNTRA.DATNO & DB_ODNTRA.LINNO & DB_ODNTRA.ODNNO)
			End If
			'20090115 ADD END   RISE)Tanimura
			
			'2008/07/05 ADD START FKS)NAKATA
			'XX 画面に表示されるListBoxの内容を退避させる。
			If WM_WLS_LIST_END = False Then
				
				ReDim Preserve WK_LSTBOX_BEF(LST.Items.Count)
				
				WK_LSTBOX_BEF(LST.Items.Count).LSTNO = CStr(LST.Items.Count) 'リスト番号
				WK_LSTBOX_BEF(LST.Items.Count).JDNNO = WK_JDNNO.Value '受注№
				WK_LSTBOX_BEF(LST.Items.Count).UDNDT = WK_UDNDT.Value '売上日
			End If
			
			'2008/07/05 ADD E.N.D FKS)NAKATA
			
			'2008/04/07 FKS)ASANO ADD START
		End If
		'2008/04/07 FKS)ASANO ADD END
		
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkTOKCD As String
		Dim wkNHSCD As String
		
		'2008/07/04 ADD START FKS)NAKATA
		Dim wkTOKJDNNO As String
		Dim wkTOKCNT As Short
		'2008/07/04 ADD E.N.D FKS)NAKATA
		
		
		'====================================
		'   WINDOW 表示可能チェック
		'       WLS_DSP_CHECK = True  :表示可
		'       WLS_DSP_CHECK = FALSE :表示不可
		'====================================
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLS_DSP_CHECK = SSS_OK
			If DB_UDNTRA.DATKB <> "1" Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			If DB_UDNTRA.AKAKROKB <> "1" Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If DB_UDNTRA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
			'''    Call DB_GetEq(DBN_UDNTHA, 1, DB_UDNTRA.DATNO, BtrNormal)
			'''    If DBSTAT = 0 Then
			'''        If DB_UDNTHA.JDNTRKB <> WLSJDNTRKB Then WLS_DSP_CHECK = SSS_NEXT
			'''    Else
			'''        WLS_DSP_CHECK = SSS_NEXT
			'''    End If
			
			wkTOKCD = WLSTOKCD.Text & Space(Len(DB_UDNTRA.TOKCD) - Len(WLSTOKCD.Text))
			wkNHSCD = WLSNHSCD.Text & Space(Len(DB_UDNTRA.NHSCD) - Len(WLSNHSCD.Text))
			
			
			
			
			'2008/07/04 ADD START FKS)NAKATA
			wkTOKCNT = Len(HD_TOKJDNNO.Text)
			wkTOKJDNNO = VB.Left(Trim(DB_UDNTRA.TOKJDNNO), wkTOKCNT)
			'2008/07/04 ADD E.N.D FKS)NAKATA
			
			'2008/07/05 CHG START FKS)NAKATA
			'XX    If (Trim$(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> WLSNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (Trim(WLSNHSCD.Text) <> "") And (DB_UDNTRA.NHSCD <> wkNHSCD) Then WLS_DSP_CHECK = SSS_NEXT
			'2008/07/05 CHG START FKS)NAKATA
			
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (Trim(WLSTOKCD.Text) <> "") And (DB_UDNTRA.TOKCD <> wkTOKCD) Then WLS_DSP_CHECK = SSS_NEXT
			
			'2008/07/04 CHG STRAT FKS)NAKATA
			'XX    If (Trim$(HD_TOKJDNNO.Text) <> "") And (DB_UDNTRA.TOKJDNNO <> HD_TOKJDNNO.Text) Then WLS_DSP_CHECK = SSS_NEXT
			
			If (Trim(HD_TOKJDNNO.Text) <> "") And (Trim(HD_TOKJDNNO.Text) <> wkTOKJDNNO) Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			'2008/07/04 CHG E.N.D FKS)NAKATA
			
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (Trim(WLSUDNDT.Text) <> "") And (DB_UDNTRA.UDNDT < DeCNV_DATE(WLSUDNDT.Text)) Then WLS_DSP_CHECK = SSS_NEXT
			
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLS_DSP_CHECK = SSS_OK
			
			If DB_ODNTRA.DATKB <> "1" Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			
			If DB_ODNTRA.DENKB <> "1" Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_END
				Exit Function
			End If
			
			wkTOKCD = WLSTOKCD.Text & Space(Len(DB_ODNTRA.TOKCD) - Len(WLSTOKCD.Text))
			wkNHSCD = WLSNHSCD.Text & Space(Len(DB_ODNTRA.NHSCD) - Len(WLSNHSCD.Text))
			
			wkTOKCNT = Len(HD_TOKJDNNO.Text)
			wkTOKJDNNO = VB.Left(Trim(DB_ODNTRA.TOKJDNNO), wkTOKCNT)
			
			If Trim(WLSNHSCD.Text) <> "" And Trim(VB.Left(DB_ODNTRA.NHSCD, Len(Trim(wkNHSCD)))) <> Trim(wkNHSCD) Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			If Trim(WLSTOKCD.Text) <> "" And Trim(VB.Left(DB_ODNTRA.TOKCD, Len(Trim(wkTOKCD)))) <> Trim(wkTOKCD) Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_NEXT
			End If
			
			If Trim(HD_TOKJDNNO.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> wkTOKJDNNO Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_NEXT
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Private Function WLS_DSP_SUB_CHECK() As Object
		'''''    Dim WL_OTPSU As Currency
		'''''    WLS_DSP_SUB_CHECK = SSS_OK
		'''''    Call DB_GetGrEq(DBN_UDNTRA, 1, "1" & DB_UDNTRA.JDNNO, BtrNormal)
		'''''    Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1") And (SSSVal(DB_UDNTRA.JDNLINNO) < 990)
		'''''        WL_OTPSU = 0
		'''''        Do While (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1")
		'''''            Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'''''        Loop
		'''''        WL_OTPSU = DB_UDNTRA.FRDSU - DB_UDNTRA.HIKSU
		'''''        If WL_OTPSU > 0 Then
		'''''            WLS_DSP_SUB_CHECK = SSS_OK
		'''''            DBSTAT = 0
		'''''            Exit Function
		'''''        Else
		'''''            WLS_DSP_SUB_CHECK = SSS_NEXT
		'''''        End If
		'''''        Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'''''    Loop
		'''''    DBSTAT = 0
	End Function
	
	Private Sub WLS_FORM_LOAD()
		
		'=== WINDOW 位置設定 ===
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		
		'=== ｺｰﾄﾞTEXT ===
		'WLSTOKCD.Height = 285
		'WLSRN.Height = 285
		'WLSTOKCD.Text = ""
		
		
		'=== WINDOW 表示ファイル設定 ===
		WM_WLS_MFIL = DBN_UDNTRA
		WM_WLS_SFIL1 = DBN_TOKMTA
		WM_WLS_SFIL2 = DBN_NHSMTA
		WM_WLS_SFIL3 = DBN_JDNTRA
		
		'UPGRADE_WARNING: オブジェクト SWlsSelList の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SWlsSelList = "*"
		
		
		'=== 表示開始コード桁数設定 ===
		'UPGRADE_WARNING: オブジェクト LenWid(DB_UDNTRA.UDNNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(DB_UDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_LEN = LenWid(DB_UDNTRA.DATNO) + LenWid(DB_UDNTRA.LINNO) + LenWid(DB_UDNTRA.UDNNO)
		
		'=== ＬＡＢＥＬ設定 ===
		'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSLABEL = "受注番号 売上日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"
		
		WM_WLS_INIT = 0
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoadイベント障害対応  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX ページ送りカウント
		If WM_WLS_PAGE_END > WM_WLS_PAGE_CLICK_NUM Then
			WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM + 1
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		If LST.Items.Count > 0 Then
			If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
				Exit Sub
			Else
				If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
					'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If WLSSSS_SET_KEYBAK() = False Then Exit Sub
				Else
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
					
					
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					'2008/07/04 CHG START FKS)NAKATA
					'XX                Call WLS_BaseSQL(WL_Key)
					'20090115 CHG START RISE)Tanimura '連絡票No.523
					'                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					' 売上済の場合
					If g_strURIKB = "1" Then
						Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)
						
						' 未売上の場合
					Else
						' 受注番号から検索
						If Trim(HD_TEXT.Text) <> "" Then
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  * "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  ("
							strSQL = strSQL & "   SELECT"
							strSQL = strSQL & "     A.*"
							strSQL = strSQL & "   FROM"
							strSQL = strSQL & "     ODNTRA A"
							strSQL = strSQL & "   , ("
							strSQL = strSQL & "      SELECT"
							strSQL = strSQL & "        B2.*"
							strSQL = strSQL & "      FROM"
							strSQL = strSQL & "        JDNTHA B1"
							strSQL = strSQL & "      , JDNTRA B2"
							strSQL = strSQL & "      WHERE"
							strSQL = strSQL & "        B1.DATNO = B2.DATNO"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
							strSQL = strSQL & "                                 SELECT"
							strSQL = strSQL & "                                   MAX(DATNO) DATNO"
							strSQL = strSQL & "                                 , LINNO      LINNO"
							strSQL = strSQL & "                                 FROM"
							strSQL = strSQL & "                                   JDNTRA"
							strSQL = strSQL & "                                 WHERE"
							strSQL = strSQL & "                                   JDNNO " & mJDNNO
							strSQL = strSQL & "                                 GROUP BY"
							strSQL = strSQL & "                                   JDNNO"
							strSQL = strSQL & "                                 , LINNO"
							strSQL = strSQL & "                                )"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B2.OTPSU > B2.URISU"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
							strSQL = strSQL & "      AND"
							' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
							'            strSQL = strSQL & "        B1.FRNKB = '0'"
							strSQL = strSQL & "       (B1.FRNKB = '0'"
							strSQL = strSQL & "        OR ("
							strSQL = strSQL & "                  B1.FRNKB   = '1' "
							strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
							strSQL = strSQL & "           )"
							strSQL = strSQL & "       )"
							' === 20110305 === UPDATE E TOM)Morimoto
							strSQL = strSQL & "     ) B "
							strSQL = strSQL & "   WHERE"
							strSQL = strSQL & "     A.JDNNO = B.JDNNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DATKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DENKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.OTPSU > 0"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO " & mJDNNO
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
							strSQL = strSQL & "  ) "
							strSQL = strSQL & "ORDER BY"
							strSQL = strSQL & "  DATKB "
							strSQL = strSQL & ", DENKB "
							strSQL = strSQL & ", JDNNO "
							strSQL = strSQL & ", JDNLINNO "
							strSQL = strSQL & ", ODNDT "
							
							' 受注取区 + 客先注文番号
						ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  * "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  ("
							strSQL = strSQL & "   SELECT"
							strSQL = strSQL & "     A.*"
							strSQL = strSQL & "   FROM"
							strSQL = strSQL & "     ODNTRA A"
							strSQL = strSQL & "   , ("
							strSQL = strSQL & "      SELECT"
							strSQL = strSQL & "        B2.*"
							strSQL = strSQL & "      FROM"
							strSQL = strSQL & "        JDNTHA B1"
							strSQL = strSQL & "      , JDNTRA B2"
							strSQL = strSQL & "      WHERE"
							strSQL = strSQL & "        B1.DATNO = B2.DATNO"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
							strSQL = strSQL & "                                 SELECT"
							strSQL = strSQL & "                                   MAX(DATNO) DATNO"
							strSQL = strSQL & "                                 , LINNO      LINNO"
							strSQL = strSQL & "                                 FROM"
							strSQL = strSQL & "                                   JDNTRA"
							strSQL = strSQL & "                                 GROUP BY"
							strSQL = strSQL & "                                   JDNNO"
							strSQL = strSQL & "                                 , LINNO"
							strSQL = strSQL & "                                )"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B2.OTPSU > B2.URISU"
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
							strSQL = strSQL & "      AND"
							' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
							'            strSQL = strSQL & "        B1.FRNKB = '0'"
							strSQL = strSQL & "       (B1.FRNKB = '0'"
							strSQL = strSQL & "        OR ("
							strSQL = strSQL & "                  B1.FRNKB   = '1' "
							strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
							strSQL = strSQL & "           )"
							strSQL = strSQL & "       )"
							' === 20110305 === UPDATE E TOM)Morimoto
							strSQL = strSQL & "      AND"
							strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
							strSQL = strSQL & "     ) B "
							strSQL = strSQL & "   WHERE"
							strSQL = strSQL & "     A.JDNNO = B.JDNNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DATKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.DENKB = '1'"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.OTPSU > 0"
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
							strSQL = strSQL & "   AND"
							strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
							strSQL = strSQL & "  ) "
							strSQL = strSQL & "ORDER BY"
							strSQL = strSQL & "  DATKB "
							strSQL = strSQL & ", DENKB "
							strSQL = strSQL & ", JDNNO "
							strSQL = strSQL & ", JDNLINNO "
							strSQL = strSQL & ", ODNDT "
						End If
						
						Call DB_GetSQL2(DBN_ODNTRA, strSQL)
					End If
					'20090115 CHG END   RISE)Tanimura
					'2008/07/04 CHG E.N.D FKS)NAKATA
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
				Call WLSSSS_DSP()
				'2008/07/05 ADD START FKS)NAKATA
				'XX 最終ページの表示チェック(最終ページを一度確認している場合)
				If VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1) = "z" And LST.Items.Count > UBound(WK_LSTBOX_BEF) Then
					Call CHK_ListBox()
				ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then 
					Call CHK_ListBox()
				End If
				
				'2008/07/05 ADD E.N.D FKS)NAKATA
			End If
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoadイベント障害対応  97/04/07
		'Unload Me
		
		Hide()
	End Sub
	
	Private Sub WLSHINCD_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSHINCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        WLSHINNMA.SetFocus
	'''''''    Else
	'''''''        WLSHINCD.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSSOUCD_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSSOUCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        WLSSOUCD.SetFocus
	'''''''    Else
	'''''''        WLSUDNDT.SetFocus
	'''''''    End If
	''
	''End Sub
	
	Private Sub WLSHINNMA_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	''Private Sub WLSHINNMA_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''''''''    If LST.ListCount > 0 Then
	''''''''        WLSTOKCD.SetFocus
	''''''''    Else
	''''''''        WLSHINNMA.SetFocus
	''''''''    End If
	''
	''End Sub
	
	''Private Sub WLSJDNTRKB_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''''''    If LST.ListCount > 0 Then
	''''''        LST.ListIndex = 0
	''''''    Else
	''''''        WLSTOKCD.SetFocus
	''''''    End If
	''
	''
	''End Sub
	
	'UPGRADE_WARNING: イベント WLSNHSCD.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSNHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNHSCD.TextChanged
		Dim s As Integer
		s = WLSNHSCD.SelectionStart
		WLSNHSCD.Text = StrConv(WLSNHSCD.Text, VbStrConv.UpperCase)
		WLSNHSCD.SelectionStart = s
	End Sub
	
	Private Sub WLSNHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNHSCD.Enter
		WLSNHSCD.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSNHSCD.SelectionLength = LenWid(WLSNHSCD.Text)
	End Sub
	
	Private Sub WLSNHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNHSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			
			'2008/07/02 CHG START FKS)NAKATA
			'XX        If WLSSSS_SET_KEYBAK() = True Then
			'XX            WM_WLS_INIT = 1
			'XX            Call WLSSSS_DSP
			'XX        End If
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
			'2008/07/02 CHG START FKS)NAKATA
			
		End If
		
	End Sub
	
	''Private Sub WLSNHSCD_LostFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	''
	''End Sub
	''
	Private Sub WLSTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSTOKCD.Enter
		WLSTOKCD.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSTOKCD.SelectionLength = LenWid(WLSTOKCD.Text)
	End Sub
	
	Private Sub WLSTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSTOKCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			''98/09/25 削除
			''WM_WLS_KeyNo = WM_WLS_TextKey
			W_Key = "1" & "1" & HD_TEXT.Text
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			Call WLS_BaseSQL(W_Key)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			
			'2008/07/05 ADD START FKS)NAKATA
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			WM_WLS_INIT = 1
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
			'2008/07/05 ADD E.N.D FKS)NAKATA
			
		End If
	End Sub
	
	''Private Sub WLSTOKCD_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''
	''    WM_WLS_Dspflg = False
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    ''98/09/25 削除
	''    ''WM_WLS_KeyNo = WM_WLS_TextKey
	''    W_Key = "1" & "1" & HD_TEXT.Text
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	'''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        WM_WLS_INIT = 1
	''        Call WLSSSS_DSP
	''    End If
	'''''''    If LST.ListCount > 0 Then
	'''''''        LST.ListIndex = 0
	'''''''    Else
	'''''''        WLSTOKCD.SetFocus
	'''''''    End If
	''
	''End Sub
	''
	'UPGRADE_WARNING: イベント WLSUDNDT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSUDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.TextChanged
		WLSUDNDT.SelectionLength = 1
		If pv_blnChange_Flg = True Then
			Exit Sub
		Else
			Call CtrlDatChange(WLSUDNDT)
		End If
		
	End Sub
	
	Private Sub WLSUDNDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Click
		WLSUDNDT.SelectionStart = 0
		WLSUDNDT.SelectionLength = 1
	End Sub
	
	Private Sub WLSUDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSUDNDT.Enter
		If Len(Trim(WLSUDNDT.Text)) = 0 Then
			pv_blnChange_Flg = True
			WLSUDNDT.Text = Space(10)
			pv_blnChange_Flg = False
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		ElseIf Len(Trim(WLSUDNDT.Text)) >= 8 Then 
			WLSUDNDT.SelectionStart = 8
			WLSUDNDT.SelectionLength = 1
		Else
			WLSUDNDT.SelectionStart = 0
			WLSUDNDT.SelectionLength = 1
		End If
	End Sub
	
	Private Sub WLSUDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSUDNDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim strDat As String
		
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		Select Case True
			'ｴﾝﾀｰｷｰ押
			Case KEYCODE = System.Windows.Forms.Keys.Return And Shift = 0
				
				If Trim(WLSUDNDT.Text) <> "" Then
					If CHECK_DATE(WLSUDNDT) = False Then
						Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
						Call P_SetFocus(WLSUDNDT)
						Exit Sub
					End If
				End If
				
				'        WM_WLS_STTKEY = "1" & "1" & Left$(HD_TEXT.Text, 6) & "0" & Mid$(HD_TEXT.Text, 2, 2)
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_STTKEY = "1" & "1" & HD_TEXT.Text
				'        WM_WLS_ENDKEY = "9"
				'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_ENDKEY = "1" & "9"
				WM_WLS_KeyCode = 0
				WM_WLS_Dspflg = True
				WM_WLS_Pagecnt = -1
				'''            strSQL = ""
				'''            strSQL = strSQL & " SELECT * FROM ( "
				'''            strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
				'''            strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				'''            strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
				'''    '''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
				'''            strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
				'''            strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				'''            Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call WLS_BaseSQL(WM_WLS_STTKEY)
				'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If WLSSSS_SET_KEYBAK() = True Then
					Call WLSSSS_DSP()
				End If
				'→押
			Case KEYCODE = System.Windows.Forms.Keys.Right And Shift = 0
				KEYCODE = 0
				
				'→制御
				If WLSUDNDT.SelectionStart < Len(WLSUDNDT.Text) Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart + 1
					WLSUDNDT.SelectionLength = 1
					Call NextForcus(WLSUDNDT)
				End If
				
				'↓押
			Case KEYCODE = System.Windows.Forms.Keys.Down And Shift = 0
				'↓制御
				KEYCODE = 0
				
				'↓押
			Case KEYCODE = System.Windows.Forms.Keys.Up And Shift = 0
				'↓制御
				KEYCODE = 0
				
				'←押
			Case KEYCODE = System.Windows.Forms.Keys.Left And Shift = 0
				KEYCODE = 0
				
				'←制御
				If WLSUDNDT.SelectionStart > 0 Then
					WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
					WLSUDNDT.SelectionLength = 1
					Call PrevForcus(WLSUDNDT)
				End If
				
			Case KEYCODE = System.Windows.Forms.Keys.Delete And Shift = 0
				KEYCODE = 0
				
				''        'TAB押
				''        Case KEYCODE = vbKeyF16
				''            Call F_SendKey(KEYCODE, "HD_KESIDT")
				''        Case KEYCODE = vbKeyS And Shift = 2
				''            pv_blnChange_Flg = True
				''            WLSUDNDT.Text = Space(10)
				''            WLSUDNDT.SelStart = 0
				''            WLSUDNDT.SelLength = 1
				''            pv_blnChange_Flg = False
				
		End Select
		
	End Sub
	
	Private Sub WLSUDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles WLSUDNDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = System.Windows.Forms.Keys.Back Then
			KeyAscii = 0
			pv_blnChange_Flg = True
			If WLSUDNDT.SelectionStart > 0 Then
				WLSUDNDT.SelectionStart = WLSUDNDT.SelectionStart - 1
			End If
			WLSUDNDT.SelectionLength = 1
			Call PrevForcus(WLSUDNDT)
			pv_blnChange_Flg = False
		Else
			' ADD 2007/02/20 数値以外は入力不可
			Select Case True
				Case (KeyAscii >= Asc("0") And KeyAscii <= Asc("9"))
					
				Case Else
					KeyAscii = 0
			End Select
			' ADD 2007/02/20 数値以外は入力不可
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	''Private Sub WLSUDNDT_LOSTFocus()
	''    Dim I As Integer
	''    Dim W_Key As String
	''    Dim strSQL As String
	''    Dim strDat As String
	''
	''    If Trim$(WLSUDNDT) <> "" Then
	''        If ConvDat(Trim(WLSUDNDT.Text), strDat) = False Then
	''            WLSUDNDT.SetFocus
	''            Exit Sub
	''        End If
	''        If CHECK_DATE(WLSUDNDT) = False Then
	''            Call DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付エラー
	''            Call P_SetFocus(WLSUDNDT)
	''            Exit Sub
	''        End If
	''    End If
	''    WM_WLS_STTKEY = "1" & "1"
	'''    WM_WLS_ENDKEY = "9"
	''    WM_WLS_ENDKEY = "1" & "9"
	''    WM_WLS_KeyCode = 0
	''    WM_WLS_Dspflg = True
	''    WM_WLS_Pagecnt = -1
	''    strSQL = ""
	''    strSQL = strSQL & " SELECT * FROM ( "
	''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
	''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
	''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
	''''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
	''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WM_WLS_STTKEY & "')"
	''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
	''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
	''''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
	''    If WLSSSS_SET_KEYBAK() = True Then
	''        Call WLSSSS_DSP
	''    End If
	''
	''End Sub
	''
	
	'20090115 ADD START RISE)Tanimura '連絡票No.523
	Private Sub WLSURIKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSURIKB.Enter
		WLSURIKB.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSURIKB.SelectionLength = LenWid(WLSURIKB.Text)
	End Sub
	
	Private Sub WLSURIKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSURIKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim W_Key As String
		
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			WM_WLS_KeyCode = 0
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			
			' 入力された値が 1 or 2 でない場合
			If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
				' 無条件に 1 にする
				WLSURIKB.Text = "1"
			End If
			
			W_Key = "1" & "1" & HD_TEXT.Text
			
			Call WLS_BaseSQL(W_Key)
			
			KEYBAK.Items.Clear()
			LST.Items.Clear()
			LST1.Items.Clear()
			WM_WLS_Pagecnt = -1
			WM_WLS_INIT = 1
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True Then
				Call WLSSSS_DSP()
			End If
		End If
	End Sub
	
	Private Sub WLSURIKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSURIKB.Leave
		' 入力された値が 1 or 2 でない場合
		If WLSURIKB.Text <> "1" And WLSURIKB.Text <> "2" Then
			' 無条件に 1 にする
			WLSURIKB.Text = "1"
		End If
	End Sub
	'20090115 ADD END   RISE)Tanimura
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX ページ送りカウント
		If WM_WLS_PAGE_CLICK_NUM > 0 Then
			WM_WLS_PAGE_CLICK_NUM = WM_WLS_PAGE_CLICK_NUM - 1
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
		Else
			Exit Sub
		End If
		WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
		''    strSQL = ""
		''    strSQL = strSQL & " SELECT * FROM ( "
		''    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
		''    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		''    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
		''    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
		''    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		''    Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		'20080702 CHG START FKS)NAKATA
		'XX    Call WLS_BaseSQL(WL_Key)
		''     Call DB_GetPre(DBN_UDNTRA, BtrNormal)
		'20090115 CHG START RISE)Tanimura '連絡票No.523
		'       Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
		' 売上済の場合
		If g_strURIKB = "1" Then
			Call DB_GetGrEq(WM_WLS_MFIL, 10, WL_Key, BtrNormal)
			
			' 未売上の場合
		Else
			' 受注番号から検索
			If Trim(HD_TEXT.Text) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				strSQL = strSQL & "                                   JDNNO " & mJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO " & mJDNNO
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
				
				' 受注取区 + 客先注文番号
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(mJDNTRKB) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.TOKJDNNO " & mTOKJDNNO
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO || A.JDNLINNO || A.ODNDT >= '" & Mid(WL_Key, 3, 21) & "' "
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
			End If
			
			Call DB_GetSQL2(DBN_ODNTRA, strSQL)
		End If
		'20090115 CHG END   RISE)Tanimura
		'20080702 CHG END FKS)NAKATA
		
		''    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
		Call WLSSSS_DSP()
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
	End Sub
	
	Private Sub WLSSSS_DSP()
		Dim WL_Mode As Short
		Dim WL_Key As String
		Dim strSQL As String
		
		If WM_WLS_Dspflg = False Then Exit Sub
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		'2008/07/05 ADD START FKS)NAKATA
		'XX 配列の初期化
		If WM_WLS_LIST_END = False Then
			ReDim Preserve WK_LSTBOX_BEF(0)
		End If
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		
		'2008/07/03 CHG START FKS)NAKATA
		'XX 入力必須条件が「受注取区+客先注文番号」「受注番号」になったため変更
		'XX    If Trim$(WLSJDNTRKB) <> "" Then
		If (Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "") Or Trim(HD_TEXT.Text) <> "" Then
			'2008/07/03 CHG E.N.D FKS)NAKATA
			If DBSTAT = 0 Then
				Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
					'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WL_Mode = WLSSSS_DSP_CHECK()
					If WL_Mode = SSS_OK Then
						'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WL_Mode = WLS_DSP_CHECK()
						If WL_Mode = SSS_OK Then
							Call WLS_DISPLAY()
						End If
					End If
					If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
						Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
					ElseIf WL_Mode = SSS_RPSN Then 
						'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WL_Key = WLSSSS_RPSN()
						'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If LenWid(WL_Key) = 0 Then
							Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
						Else
							'''                        strSQL = ""
							'''                        strSQL = strSQL & " SELECT * FROM ( "
							'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
							'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
							'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
							'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
							'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
							'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
							Call WLS_BaseSQL(WL_Key)
							'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
						End If
					ElseIf WL_Mode = SSS_NPSN Then 
						'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WL_Key = WLSSSS_NPSN()
						'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If LenWid(WL_Key) = 0 Then
							Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
						Else
							'''                        strSQL = ""
							'''                        strSQL = strSQL & " SELECT * FROM ( "
							'''                        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
							'''                        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
							'''                        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
							'''                        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
							'''                        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
							'''                        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
							Call WLS_BaseSQL(WL_Key)
							'''                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
						End If
					End If
					
				Loop 
				If LST.Items.Count > 0 Then
					'                LST.SetFocus
					LST.SelectedIndex = 0
				End If
			End If
			
			If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
				If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
					KEYBAK.Items.Add(HighValue(1))
					WM_WLS_LIST_END = True
				End If
				'2008/07/05 ADD START FKS)NAKATA
				'Else
				'XX 画面表示記録用配列の初期化
				'    ReDim WK_LSTBOX_BEF(0)
				'2008/07/05 ADD E.N.D FKS)NAKATA
			End If
		End If
		
		If LST.Items.Count <= 0 Then
			MsgBox("      該当するデータが存在しません。")
			WM_WLS_Dspflg = False
			Call UDNTRA_RClear()
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			Call ODNTRA_RClear()
			'20090115 ADD END   RISE)Tanimura
			Call JDNTRA_RClear()
		End If
		
		
	End Sub
	
	Private Function WLSSSS_DSP_CHECK() As Object
		Dim CHKDAT As Object
		
		'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSSSS_DSP_CHECK = SSS_OK
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If Not IsDbNull(WM_WLS_ENDKEY) Then
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト LenWid(WM_WLS_ENDKEY) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
				'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLSSSS_DSP_CHECK = SSS_END
				Exit Function
			End If
		End If
		
	End Function
	
	Private Sub WLSSSS_FORM_ACTIVATE()
		Dim I As Short
		Dim W_Key As String
		Dim strSQL As String
		
		WM_WLS_Dspflg = False
		WM_WLS_KeyCode = 2
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		''98/09/25 削除
		''WM_WLS_KeyNo = WM_WLS_TextKey
		W_Key = "1" & "1" & HD_TEXT.Text
		Call UDNTRA_RClear()
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		Call ODNTRA_RClear()
		'20090115 ADD END   RISE)Tanimura
		'UPGRADE_WARNING: オブジェクト SSSVal(WLSJDNTRKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WLSJDNTRKB) <> 0 Then
			'''        strSQL = ""
			'''        strSQL = strSQL & " SELECT * FROM ( "
			'''        strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
			'''        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'''        strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'''        strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & W_Key & "')"
			'''        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'''        Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'''        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
			Call WLS_BaseSQL(W_Key)
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
				WM_WLS_INIT = 1
				Call WLSSSS_DSP()
			End If
		Else
			Call P_SetFocus(WLSJDNTRKB)
		End If
	End Sub
	
	Private Sub WLSSSS_FORM_INIT()
		Dim I As Short
		
		WM_WLS_KeyCode = False
		'''''    WM_WLS_MAX = LST.Height \ 225
		'''''    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 200)
		
		'HD_TEXT.Height = 285
		'''''    HD_TEXT.MaxLength = WM_WLS_LEN
		'''''    HD_TEXT.Width = (WM_WLS_LEN + 1) * 100
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_STTKEY = "1" & "1"
		'    WM_WLS_ENDKEY = "9"
		'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_ENDKEY = "1" & "9"
		
		'''''    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
		'''''    If LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
		'''''        HD_TEXT.Text = ""
		'''''    End If
		''98/09/25 追加
		WM_WLS_KeyNo = WM_WLS_TextKey
		
		WLSJDNTRKB.Text = ""
		HD_TOKJDNNO.Text = ""
		WLSNHSCD.Text = ""
		WLSTOKCD.Text = ""
		HD_TEXT.Text = ""
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' デフォルトは売上済
		WLSURIKB.Text = "1"
		'20090115 ADD END   RISE)Tanimura
		
	End Sub
	
	Private Function WLSSSS_NPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSSSS_NPSN = WL_Key
	End Function
	
	Private Function WLSSSS_RPSN() As Object
		Dim WL_Key As String
		WL_Key = ""
		'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSSSS_RPSN = WL_Key
	End Function
	
	Private Function WLSSSS_SET_KEYBAK() As Object
		Dim WL_Mode As Short
		Dim WL_Key As String
		Dim strSQL As String
		
		
		'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSSSS_SET_KEYBAK = True
		
		
		LST.Items.Clear()
		LST1.Items.Clear()
		
		Do While DBSTAT = 0
			'UPGRADE_WARNING: オブジェクト WLSSSS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_Mode = WLSSSS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_Mode = WLS_DSP_CHECK()
				If WL_Mode = SSS_OK Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					'KEYBAK.AddItem DB_PARA(WM_WLS_MFIL).KeyBuf
					'20090115 ADD START RISE)Tanimura '連絡票No.523
					' 売上済の場合
					If g_strURIKB = "1" Then
						'20090115 ADD END   RISE)Tanimura
						KEYBAK.Items.Add(DB_UDNTRA.DATKB & DB_UDNTRA.AKAKROKB & DB_UDNTRA.JDNNO & DB_UDNTRA.JDNLINNO & DB_UDNTRA.UDNDT)
						'20090115 ADD START RISE)Tanimura '連絡票No.523
						' 未売上の場合
					Else
						KEYBAK.Items.Add(DB_ODNTRA.DATKB & DB_ODNTRA.DENKB & DB_ODNTRA.JDNNO & DB_ODNTRA.JDNLINNO & DB_ODNTRA.ODNDT)
					End If
					'20090115 ADD END   RISE)Tanimura
				End If
			End If
			If WL_Mode = SSS_NEXT Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			ElseIf WL_Mode = SSS_RPSN Then 
				'UPGRADE_WARNING: オブジェクト WLSSSS_RPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_Key = WLSSSS_RPSN()
				'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
					Call WLS_BaseSQL(WL_Key)
				End If
			ElseIf WL_Mode = SSS_NPSN Then 
				'UPGRADE_WARNING: オブジェクト WLSSSS_NPSN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_Key = WLSSSS_NPSN()
				'UPGRADE_WARNING: オブジェクト LenWid(WL_Key) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If LenWid(WL_Key) = 0 Then
					Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
				Else
					'''                strSQL = ""
					'''                strSQL = strSQL & " SELECT * FROM ( "
					'''                strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA "
					'''                strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
					'''                strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
					'''                strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & WL_Key & "')"
					'''                strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
					'''                Call DB_GetSQL2(DBN_UDNTRA, strSQL)
					Call WLS_BaseSQL(WL_Key)
					'''                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
				End If
			Else
				Exit Do
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then
			'UPGRADE_WARNING: オブジェクト WLSSSS_SET_KEYBAK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLSSSS_SET_KEYBAK = False
		End If
	End Function
	
	Private Sub P_SetFocus(ByRef objCtl As System.Windows.Forms.Control)
		
		On Error Resume Next
		objCtl.Focus()
		
	End Sub
	
	Private Function LeftWid2(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		LeftWid2 = ""
		
		If AnsiLenB(pm_Characters) <= pm_Wid Then
			LeftWid2 = pm_Characters & Space(pm_Wid - AnsiLenB(pm_Characters))
			Exit Function
		End If
		
		If AnsiLenB(pm_Characters) > pm_Wid Then
			
			Do Until lngKeta >= pm_Wid
				lngMoji = lngMoji + 1
				'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
				lngKeta = lngKeta + LenB(StrConv(Mid(pm_Characters, lngMoji, 1), vbFromUnicode))
			Loop 
			
			If lngKeta > pm_Wid Then
				LeftWid2 = VB.Left(pm_Characters, lngMoji - 1) & Space(1)
			Else
				LeftWid2 = VB.Left(pm_Characters, lngMoji)
			End If
		End If
		
	End Function
	
	
	Private Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
	End Function
	
	Private Function AnsiLenB(ByVal StrArg As String) As Integer
		'概要：文字数ｶｳﾝﾄ
		'引数：StrArg,Input,String,対象文字列
		'説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(StrArg)
#End If
	End Function
	
	' StrConv を呼び出します。
	Private Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If
		
	End Function
	
	Private Function ConvDat(ByVal strTarget As String, ByRef strDat As String) As Boolean
		
		Dim blnRtnVal As Boolean
		Dim strYYYY As String
		Dim strMM As String
		Dim strDD As String
		
		blnRtnVal = False
		strDat = ""
		strYYYY = ""
		strMM = ""
		strDD = ""
		
		If IsDate(strTarget) = True Then
			strDat = strTarget
			blnRtnVal = True
		Else
			If Len(strTarget) = 8 Then
				strYYYY = VB.Left(strTarget, 4)
				strMM = Mid(strTarget, 5, 2)
				strDD = VB.Right(strTarget, 2)
				If IsDate(strYYYY & "/" & strMM & "/" & strDD) = True Then
					strDat = strYYYY & "/" & strMM & "/" & strDD
					blnRtnVal = True
				End If
			End If
		End If
		
		ConvDat = blnRtnVal
		
	End Function
	
	Private Function CtrlDatChange(ByRef Ctl As System.Windows.Forms.TextBox) As String
		
		Dim lngSelstart As Integer
		Dim Wk_DspMoji As String
		Dim Wk_EditMoji As String
		Wk_EditMoji = CnvDspItem_Date(Ctl.Text)
		
		'編集後の文字を表示形式に変換
		Wk_DspMoji = CnvDspItem_Date(Wk_EditMoji)
		
		pv_blnChange_Flg = True
		lngSelstart = Ctl.SelectionStart
		Ctl.Text = VB.Left(Wk_DspMoji & Space(10), 10)
		Ctl.SelectionStart = lngSelstart
		Ctl.SelectionLength = 1
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ可
		pv_blnChange_Flg = False
		
		'現在ﾌｫｰｶｽ位置から右へ移動
		Call NextForcus(Ctl)
		
	End Function
	
	Private Function CnvDspItem_Date(ByVal strValue As String) As String
		
		Dim Rtn_Str_Value As String
		
		Rtn_Str_Value = strValue
		
		'日付の場合
		If Trim(Rtn_Str_Value) = "" Then
			'未入力の場合
			Rtn_Str_Value = New String(Space(1), 10)
		Else
			'入力ありの場合
			If Len(Trim(Rtn_Str_Value)) <> Len("YYYYMMDD") Then
				'入力形式が異なる場合
				'詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
				Rtn_Str_Value = LTrim(Rtn_Str_Value) & New String(Space(1), 10)
				'右からバイト数分だけ取得
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, 10)
			Else
				'表示形式有
				Rtn_Str_Value = CF_Ctr_AnsiLeftB(VB6.Format(Rtn_Str_Value, "0000/00/00") & New String(Space(1), 10), 10)
			End If
		End If
		
		CnvDspItem_Date = Rtn_Str_Value
		
	End Function
	
	Private Function NextForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '移動フラグ初期化
		'    pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		
		'現在のﾃｷｽﾄ上の選択状態を取得
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'全選択の場合（選択文字が最大バイト数と一致）
			'詰文字が左詰の場合
			'最終文字を選択する
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'選択開始位置が一番右の場合
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSSIRCD.SetFocus
				''                        End If
				''                End Select
				Ctl.SelectionStart = Len(Ctl.Text) - 1
				Ctl.SelectionLength = 1
			Else
				'選択開始位置が一番右でない場合
				
				'１つ右の１桁を取得
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'一番右へ移動し選択なし状態に
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'右に１桁ずつずらし入力可能な文字を検索
					Next_SelStart = -1
					For Wk_Point = Act_SelStart + 1 To Len(Ctl.Text) Step 1
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'日付/年月/時刻項目の場合
						'入力可能文字＆と空白も移動可能
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'選択可能な文字がない場合
						''                        Select Case Ctl.NAME
						''                            Case WLSHDNDT.NAME
						''                                If IsDate(Ctl.Text) = True Then
						''                                    WLSHDNDT.ForeColor = COLOR_BLACK
						''                                    WLSSIRCD.SetFocus
						''                                End If
						''                        End Select
					Else
						'選択可能な文字がある場合
						
						If Act_SelLength = 0 Then
							'移動前の選択文字数がない場合
							'同じ項目で移動する場合に選択文字数は継続する
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
			
		End If
		
	End Function
	
	Private Function PrevForcus(ByRef Ctl As System.Windows.Forms.TextBox) As Object
		
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'    '移動フラグ初期化
		'    pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		
		'現在のﾃｷｽﾄ上の選択状態を取得
		Act_SelStart = Ctl.SelectionStart
		Act_SelLength = Ctl.SelectionLength
		Act_SelStr = Ctl.SelectedText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		
		If Act_SelStart = 0 And Act_SelStrB = 10 Then
			'全選択の場合（選択文字が最大バイト数と一致）
			'詰文字が左詰の場合
			'最終文字を選択する
			Ctl.SelectionStart = Len(Ctl.Text) - 1
			Ctl.SelectionLength = 1
		Else
			If Act_SelStart = Len(Ctl.Text) Then
				'選択開始位置が一番右の場合
				''                Select Case Ctl.NAME
				''                    Case WLSHDNDT.NAME
				''                        If IsDate(Ctl.Text) = True Then
				''                            WLSHDNDT.ForeColor = COLOR_BLACK
				''                            WLSHDNTRKB.SetFocus
				''                        End If
				''                End Select
			Else
				'選択開始位置が一番右でない場合
				
				'１つ右の１桁を取得
				Str_Wk = Mid(Ctl.Text, Act_SelStart + 1, 1)
				
				If Str_Wk = "" Then
					'一番右へ移動し選択なし状態に
					Ctl.SelectionStart = Len(Ctl.Text)
					Ctl.SelectionLength = 0
				Else
					'右に１桁ずつずらし入力可能な文字を検索
					Next_SelStart = -1
					'                    For Wk_Point = Act_SelStart + 1 To 0 Step -1       ' DEL 2007/02/20
					For Wk_Point = Act_SelStart + 1 To 1 Step -1 ' ADD 2007/02/20
						
						Str_Wk = Mid(Ctl.Text, Wk_Point, 1)
						
						'日付/年月/時刻項目の場合
						'入力可能文字＆と空白も移動可能
						If (Str_Wk >= "0" And Str_Wk <= "9") Or Str_Wk = Space(1) Then
							Next_SelStart = Wk_Point - 1
							Exit For
						End If
					Next 
					
					If Next_SelStart = -1 Then
						'選択可能な文字がない場合
						''                Select Case Ctl.NAME
						''                    Case WLSHDNDT.NAME
						''                        If IsDate(Ctl.Text) = True Then
						''                            WLSHDNDT.ForeColor = COLOR_BLACK
						''                            WLSHDNTRKB.SetFocus
						''                        End If
						''                End Select
					Else
						'選択可能な文字がある場合
						
						If Act_SelLength = 0 Then
							'移動前の選択文字数がない場合
							'同じ項目で移動する場合に選択文字数は継続する
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						Ctl.SelectionStart = Next_SelStart
						Ctl.SelectionLength = Wk_SelLength
					End If
				End If
			End If
			
		End If
		
	End Function
	
	
	Private Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	
	Private Function GP_Get_NM(ByVal strNM As String, ByVal lngMR As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		GP_Get_NM = ""
		
		If AnsiLenB(strNM) <= lngMR Then
			GP_Get_NM = strNM
			Exit Function
		End If
		
		If AnsiLenB(strNM) > lngMR Then
			
			Do Until lngKeta >= lngMR
				lngMoji = lngMoji + 1
				'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
				lngKeta = lngKeta + LenB(StrConv(Mid(strNM, lngMoji, 1), vbFromUnicode))
			Loop 
			
			If lngKeta > lngMR Then
				GP_Get_NM = VB.Left(strNM, lngMoji - 1)
			Else
				GP_Get_NM = VB.Left(strNM, lngMoji)
			End If
		End If
		
	End Function
	
	
	Sub WLS_BaseSQL(Optional ByVal strKeyBak As String = " ")
		Dim strSQL As String
		Dim wkTOKCD As String
		Dim wkTANCD As String
		Dim strSQLWhere As String
		Dim strSQLWhereB As String
		
		'2008/07/03 ADD START FKS)NAKATA
		'XX あいまい検索用変数
		Dim wkJDNNO As String '受注番号
		Dim wkTOKJDNNO As String '客先注文番号
		
		Dim wkKEYBAK As String
		'2008/07/03 ADD START FKS)NAKATA
		
		
		'XX 最終ページフラグの初期化
		WM_WLS_LIST_END = False
		WM_WLS_PAGE_CLICK_NUM = 0
		
		
		'2008/07/03 ADD START FKS)NAKATA
		'XX 必須項目が入力されていない場合、メッセージを表示させる。
		If (Trim(WLSJDNTRKB.Text) = "" Or Trim(HD_TOKJDNNO.Text) = "") And Trim(HD_TEXT.Text) = "" Then
			MsgBox("[受注取区＋客先注文番号」または「受注番号」を入力して下さい。")
			Exit Sub
		End If
		
		
		'XX 受注番号を検索用文字に変更する。
		If Len(Trim(HD_TEXT.Text)) >= 6 Then
			'XX 受注番号が６桁入力されている場合、「 = JDNNO」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkJDNNO = " = '" + Trim(HD_TEXT.Text) + "'"
			wkJDNNO = " = '" & AE_EditSQLText(Trim(HD_TEXT.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(HD_TEXT.Text)) > 0 And Len(Trim(HD_TEXT.Text)) < 6 Then 
			'XX 受注番号が６桁以下の場合、「 LIKE JDNNO%」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkJDNNO = " LIKE '" + Trim(HD_TEXT.Text) + "%'"
			wkJDNNO = " LIKE '" & AE_EditSQLText(Trim(HD_TEXT.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX 客先注文番号を検索用文字に変更する。番号に規則がないため語尾に「％」を付ける。
		If Trim(HD_TOKJDNNO.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkTOKJDNNO = " LIKE '" + Trim(HD_TOKJDNNO.Text) + "%'"
			wkTOKJDNNO = " LIKE '" & AE_EditSQLText(Trim(HD_TOKJDNNO.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上状態を退避する
		g_strURIKB = WLSURIKB.Text
		'20090115 ADD END   RISE)Tanimura
		
		'XX 件数取得
		If SerchCount(wkJDNNO, wkTOKJDNNO) <> True Then
			Exit Sub
		End If
		
		
		'    If WM_WLS_Pagecnt > -1 Then
		'
		'    'XX 「↑」ボタンが押された場合
		'    wkKEYBAK = KEYBAK.List(WM_WLS_Pagecnt)
		'    wkJDNNO = Mid$(wkKEYBAK, 3, 8)
		'    wkUDNDT = Right$(wkKEYBAK, 8)
		'
		'
		'         strSQL = ""
		'        strSQL = strSQL & " SELECT * "
		'        strSQL = strSQL & " FROM "
		'        strSQL = strSQL & "   (SELECT UDNTRA.*  "
		'        strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
		'        strSQL = strSQL & "      (SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
		'        strSQL = strSQL & "        FROM UDNTHA "
		'        strSQL = strSQL & "        WHERE DENKB = '1' "
		'        strSQL = strSQL & "          AND JDNNO >= '" & wkJDNNO & "'"
		'        strSQL = strSQL & "          AND UDNDT >= '" & wkUDNDT & "'"
		'        strSQL = strSQL & "        GROUP BY UDNNO ) B"
		'        strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
		'        strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
		'        strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
		'        strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
		'        strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
		'        strSQL = strSQL & "   AND UDNTRA.JDNNO  >= '" & wkJDNNO & "'"
		'        strSQL = strSQL & " ) "
		'        strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
		'
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'=== ＬＡＢＥＬ設定 ===
			'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLSLABEL = "受注番号 売上日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"
			
			WM_WLS_MFIL = DBN_UDNTRA
			'20090115 ADD END   RISE)Tanimura
			'XX 「受注番号」が入力されている場合、以下の処理にて検索する。
			If Trim(HD_TEXT.Text) <> "" Then
				
				'XX 必須項目が受注番号の場合
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM "
				strSQL = strSQL & "   (SELECT UDNTRA.*  "
				strSQL = strSQL & "    FROM UDNTRA ,UDNTHA , "
				strSQL = strSQL & "      (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "        FROM UDNTHA "
				strSQL = strSQL & "        WHERE DENKB = '1' "
				strSQL = strSQL & "          AND JDNNO " & wkJDNNO
				strSQL = strSQL & "        GROUP BY UDNNO ) B"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				strSQL = strSQL & "     ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "        FROM  UDNTRA "
				strSQL = strSQL & "        WHERE DENKB = '1' "
				strSQL = strSQL & "          AND DATKB = '1' "
				strSQL = strSQL & "          AND AKAKROKB = '1' "
				strSQL = strSQL & "          AND JDNNO " & wkJDNNO
				strSQL = strSQL & "        GROUP BY RECNO ) C"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
				strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				strSQL = strSQL & "   AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
				strSQL = strSQL & "   AND UDNTRA.RECNO = C.RECNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "   AND UDNTRA.DATKB = '1' "
				strSQL = strSQL & "   AND UDNTRA.AKAKROKB = '1' "
				strSQL = strSQL & "   AND UDNTRA.JDNNO  " & wkJDNNO
				strSQL = strSQL & " ) "
				strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
				
				'XX 「受注取区 + 客先注文番号」が入力されている場合
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM (SELECT UDNTRA. * "
				strSQL = strSQL & "         FROM UDNTRA , "
				strSQL = strSQL & "         UDNTHA ,"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				'            strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) DT "
				'            strSQL = strSQL & "             FROM    UDNTRA "
				'            strSQL = strSQL & "             WHERE   TOKJDNNO " & wkTOKJDNNO
				'            strSQL = strSQL & "             AND     AKAKROKB = '1' "
				'            strSQL = strSQL & "             AND     DATKB = '1' "
				'            strSQL = strSQL & "             GROUP BY UDNNO "
				'            strSQL = strSQL & "         ) B "
				strSQL = strSQL & "         (SELECT   RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "             FROM  UDNTRA "
				strSQL = strSQL & "             WHERE DENKB = '1' "
				strSQL = strSQL & "             AND   DATKB = '1' "
				strSQL = strSQL & "             AND   AKAKROKB = '1' "
				strSQL = strSQL & "             AND   TOKJDNNO " & wkTOKJDNNO
				strSQL = strSQL & "             GROUP BY RECNO "
				strSQL = strSQL & "         ) B "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO "
				strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				'            strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO "
				strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
				strSQL = strSQL & "     AND UDNTHA.DENKB = '1' ) "
				strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO , UDNDT "
				
			End If
			
			'2008/07/03 ADD E.N.D FKS)NAKATA
			'2008/07/03 DEL START FKS)NAKATA
			'XX    strSQL = ""
			'XX    strSQL = strSQL & " SELECT * FROM ( "
			'XX    strSQL = strSQL & " SELECT UDNTRA.* FROM UDNTRA ,UDNTHA ,( SELECT UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTHA WHERE DENKB = '1' GROUP BY UDNNO ) B "
			'XX    strSQL = strSQL & "  WHERE UDNTRA.DATNO = UDNTHA.DATNO "
			'XX    strSQL = strSQL & "    AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB & "'"
			'XX''    strSQL = strSQL & "    AND UDNTHA.URIKJN <> '02'"       '検収基準売上は返品不可 2007.08.23 ADD
			'XX    strSQL = strSQL & "   AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
			'XX    strSQL = strSQL & "   AND UDNTHA.UDNNO = B.UDNNO "
			'XX    strSQL = strSQL & "    AND UDNTRA.DATKB || UDNTRA.AKAKROKB || UDNTRA.JDNNO || UDNTRA.JDNLINNO || UDNTRA.UDNDT >= '" & strKeyBak & "')"
			'XX    strSQL = strSQL & " ORDER BY DATKB , AKAKROKB , JDNNO , JDNLINNO  , UDNDT   "
			'2008/07/03 DEL E.N.D FKS)NAKATA
			
			
			Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			'=== ＬＡＢＥＬ設定 ===
			'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLSLABEL = "受注番号 出荷日付   受注日付   得意先                     納入先                         型式                 品名       数量    受注取区"
			
			WM_WLS_MFIL = DBN_ODNTRA
			
			' 受注番号から検索
			If Trim(HD_TEXT.Text) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				strSQL = strSQL & "                                   JDNNO " & wkJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNNO " & wkJDNNO
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
				
				' 受注取区 + 客先注文番号
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(HD_TOKJDNNO.Text) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
				strSQL = strSQL & "  ) "
				strSQL = strSQL & "ORDER BY"
				strSQL = strSQL & "  DATKB "
				strSQL = strSQL & ", DENKB "
				strSQL = strSQL & ", JDNNO "
				strSQL = strSQL & ", JDNLINNO "
				strSQL = strSQL & ", ODNDT "
			End If
			
			Call DB_GetSQL2(DBN_ODNTRA, strSQL)
		End If
		'20090115 ADD END   RISE)Tanimura
		
	End Sub
	
	'2008/07/04/ ADD START FKS)NAKATA
	Private Function SerchCount(ByRef wkJDNNO As Object, ByRef wkTOKJDNNO As Object) As Boolean
		'XX
		'XX 検索件数取得ファンクション (戻り値：True / False)
		'XX
		
		
		Dim strSQL As String
		Dim strMSG As String '検索件数表示用
		
		Dim wkCNT As Double
		Dim wkPAGE As Double
		Dim wkLIST As Double
		Dim I As Short
		
		
		
		'2008/07/05 ADD START FKS)NAKATA
		Dim wkTOKCD As String
		Dim wkNHSCD As String
		Dim wkUDNDT As String
		
		
		'XX 得意先を検索用文字に変更する。
		If Len(Trim(WLSTOKCD.Text)) >= 5 Then
			'XX 得意先が４桁入力されている場合、「 = TOKCD」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkTOKCD = " = '" + Trim(WLSTOKCD.Text) + "'"
			wkTOKCD = " = '" & AE_EditSQLText(Trim(WLSTOKCD.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(WLSTOKCD.Text)) > 0 And Len(Trim(WLSTOKCD.Text)) < 5 Then 
			'XX 得意先が４桁以下の場合、「 LIKE TOKCD%」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkTOKCD = " LIKE '" + Trim(WLSTOKCD.Text) + "%'"
			wkTOKCD = " LIKE '" & AE_EditSQLText(Trim(WLSTOKCD.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX 納入先を検索用文字に変更する。
		If Len(Trim(WLSNHSCD.Text)) >= 9 Then
			'XX 納入先が９桁入力されている場合、「 = wkNHSCD」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkNHSCD = " = '" + Trim(WLSNHSCD.Text) + "'"
			wkNHSCD = " = '" & AE_EditSQLText(Trim(WLSNHSCD.Text)) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		ElseIf Len(Trim(WLSNHSCD.Text)) > 0 And Len(Trim(WLSNHSCD.Text)) < 9 Then 
			'XX 納入先が９桁以下の場合、「 LIKE TOKCD%」の形にする
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'            wkNHSCD = " LIKE '" + Trim(WLSNHSCD.Text) + "%'"
			wkNHSCD = " LIKE '" & AE_EditSQLText(Trim(WLSNHSCD.Text)) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		
		'XX 売上日を「yyyy/mm/dd」から「yyyymmdd」に変更する。
		wkUDNDT = WLSUDNDT.Text
		wkUDNDT = VB.Left(wkUDNDT, 4) & Mid(wkUDNDT, 6, 2) & VB.Right(wkUDNDT, 2)
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 検索条件を退避しておく
		mJDNTRKB = WLSJDNTRKB.Text ' 受注取区
		'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mJDNNO = wkJDNNO ' 受注番号
		'UPGRADE_WARNING: オブジェクト wkTOKJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mTOKJDNNO = wkTOKJDNNO ' 客先注文番号
		'20090115 ADD END   RISE)Tanimura
		
		'2008/07/05 ADD E.N.D FKS)NAKATA
		
		SerchCount = True
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(wkJDNNO) <> "" Then
				
				'XX 受注番号から検索
				strSQL = ""
				'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
				'        strSQL = strSQL & " FROM JDNTRA"
				'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN"
				'        strSQL = strSQL & " ("
				'        strSQL = strSQL & "  SELECT TRIM(JDNNO) || TRIM(JDNLINNO) "
				strSQL = strSQL & "  SELECT COUNT(DATNO) "
				strSQL = strSQL & "  FROM "
				strSQL = strSQL & "    (SELECT UDNTRA.*  "
				strSQL = strSQL & "     FROM UDNTRA ,UDNTHA , "
				strSQL = strSQL & "       (SELECT /*+ INDEX(UDNTHA X_UDNTHA91)*/ UDNNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "         FROM UDNTHA "
				strSQL = strSQL & "         WHERE DENKB = '1' "
				'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "           AND JDNNO " & wkJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         GROUP BY UDNNO ) B"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				strSQL = strSQL & "      ,(SELECT RECNO,MAX(WRTFSTDT || WRTFSTTM) as DT "
				strSQL = strSQL & "         FROM  UDNTRA "
				strSQL = strSQL & "         WHERE DENKB = '1' "
				strSQL = strSQL & "           AND DATKB = '1' "
				strSQL = strSQL & "           AND AKAKROKB = '1' "
				'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "           AND JDNNO " & wkJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         GROUP BY RECNO ) C"
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "   WHERE UDNTRA.DATNO = UDNTHA.DATNO "
				strSQL = strSQL & "    AND UDNTHA.WRTFSTDT || UDNTHA.WRTFSTTM = B.DT "
				strSQL = strSQL & "    AND UDNTHA.UDNNO = B.UDNNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				strSQL = strSQL & "    AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = C.DT "
				strSQL = strSQL & "    AND UDNTRA.RECNO = C.RECNO "
				'''' ADD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "    AND UDNTRA.DATKB = '1' "
				strSQL = strSQL & "    AND UDNTRA.AKAKROKB = '1' "
				'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "    AND UDNTRA.JDNNO  " & wkJDNNO
				strSQL = strSQL & "   ) "
				'        strSQL = strSQL & " ) "
				
				'UPGRADE_WARNING: オブジェクト wkTOKJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then 
				
				'XX 受注取区 + 客先注文番号
				strSQL = ""
				'        strSQL = strSQL & " SELECT /*+ INDEX(JDNTRA.X_JDNTRA02)*/ COUNT(DATNO)"
				'        strSQL = strSQL & " FROM JDNTRA"
				'        strSQL = strSQL & " WHERE TRIM(JDNNO) || TRIM(LINNO) IN (SELECT TRIM(JDNNO) || TRIM(JDNLINNO)"
				strSQL = strSQL & "  SELECT COUNT(DATNO) "
				strSQL = strSQL & " FROM (SELECT UDNTRA. *"
				strSQL = strSQL & "     FROM UDNTRA ,"
				strSQL = strSQL & "         UDNTHA ,"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				'        strSQL = strSQL & "         (SELECT /*+ INDEX(UDNTRA X_UDNTRA91)*/ UDNNO"
				strSQL = strSQL & "         (SELECT RECNO"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "             ,MAX(WRTFSTDT || WRTFSTTM) DT"
				strSQL = strSQL & "         FROM UDNTRA"
				'UPGRADE_WARNING: オブジェクト wkTOKJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "         WHERE TOKJDNNO" & wkTOKJDNNO
				If wkUDNDT <> "" Then
					strSQL = strSQL & "           AND UDNDT >= '" & wkUDNDT & "'"
				End If
				If wkTOKCD <> "" Then
					strSQL = strSQL & "           AND TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "           AND NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "         AND AKAKROKB = '1'"
				strSQL = strSQL & "         AND DATKB = '1'"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				'        strSQL = strSQL & "         GROUP BY UDNNO) B"
				strSQL = strSQL & "         GROUP BY RECNO) B"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				strSQL = strSQL & "     WHERE UDNTHA.DATNO = UDNTRA.DATNO"
				strSQL = strSQL & "     AND UDNTRA.WRTFSTDT || UDNTRA.WRTFSTTM = B.DT"
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
				'        strSQL = strSQL & "     AND UDNTRA.UDNNO = B.UDNNO"
				strSQL = strSQL & "     AND UDNTRA.RECNO = B.RECNO "
				'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
				'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
				'        strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & WLSJDNTRKB.Text & "'"
				strSQL = strSQL & "     AND UDNTHA.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				'''' UPD 2009/12/03  FKS) T.Yamamoto    End
				strSQL = strSQL & "     AND UDNTHA.DENKB = '1')"
				'       strSQL = strSQL & " )"
			End If
			
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			' 受注番号から検索
			'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(wkJDNNO) <> "" Then
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  COUNT(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 WHERE"
				'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "                                   JDNNO " & wkJDNNO
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				'UPGRADE_WARNING: オブジェクト wkJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "     A.JDNNO " & wkJDNNO
				If wkTOKCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "  ) "
				
				' 受注取区 + 客先注文番号
				'UPGRADE_WARNING: オブジェクト wkTOKJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf Trim(WLSJDNTRKB.Text) <> "" And Trim(wkTOKJDNNO) <> "" Then 
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  COUNT(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.JDNTRKB = '" & AE_EditSQLText(WLSJDNTRKB.Text) & "'"
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				'UPGRADE_WARNING: オブジェクト wkTOKJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "     A.TOKJDNNO " & wkTOKJDNNO
				If wkTOKCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.TOKCD " & wkTOKCD
				End If
				If wkNHSCD <> "" Then
					strSQL = strSQL & "   AND"
					strSQL = strSQL & "     A.NHSCD " & wkNHSCD
				End If
				strSQL = strSQL & "  ) "
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
		
		Call DB_GetSQL2(DBN_JDNTHA, strSQL)
		
		
		'XX　検索結果が１００件以上ならメッセージを表示
		If DB_ExtNum.ExtNum(0) >= 100 Then
			
			strMSG = strMSG & "検索件数：" & DB_ExtNum.ExtNum(0) & "件"
			
			If MsgBox(strMSG, MsgBoxStyle.OKCancel) = MsgBoxResult.Cancel Then
				SerchCount = False
				WM_WLS_Dspflg = False
				Call JDNTRA_RClear()
				Exit Function
			End If
		End If
		
		'XX 該当データがない場合、メッセージを表示させる
		If DB_ExtNum.ExtNum(0) <= 0 Then
			MsgBox("      該当するデータが存在しません。")
			SerchCount = False
			WM_WLS_Dspflg = False
			Call UDNTRA_RClear()
			Exit Function
		End If
		
		
		'XX ページ送り用に、最終ページ番号と最終リスト番号を算出する。
		
		wkCNT = DB_ExtNum.ExtNum(0)
		
		'最終ページ番号
		'UPGRADE_WARNING: Mod に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		WM_WLS_PAGE_END = Int(wkCNT / 18) + CShort(IIf((wkCNT Mod 18) = 0, 0, 1))
		
		'最終リスト番号
		Do While (wkCNT > 18)
			wkCNT = wkCNT - 18
		Loop 
		
		WM_WLS_LIST_CNT = wkCNT
		
	End Function
	'2008/07/04/ ADD E.N.D FKS)NAKATA
	
	'2008/07/05 ADD START FKS)NAKATA
	Private Sub CHK_ListBox()
		
		
		Dim wkLSTCNT As String
		Dim wkJDNNO As String
		Dim wkUDNDT As String
		
		Dim lstLSTCNT As String
		Dim lstJDNNO As String
		Dim lstUDNDT As String
		
		Dim wkStr As String
		
		Dim I As Short
		
		
		If LST.Items.Count <> UBound(WK_LSTBOX_BEF) Then
			
			'XX　配列の取り出し
			wkLSTCNT = Trim(WK_LSTBOX_BEF(UBound(WK_LSTBOX_BEF)).LSTNO)
			wkJDNNO = Trim(WK_LSTBOX_BEF(CInt(wkLSTCNT)).JDNNO)
			wkUDNDT = Trim(WK_LSTBOX_BEF(CInt(wkLSTCNT)).UDNDT)
			
			'XX ListBoxからの取り出し
			wkStr = VB6.GetItemString(LST, CDbl(wkLSTCNT) - 1)
			
			lstJDNNO = VB.Left(Trim(wkStr), 8)
			lstUDNDT = Mid(Trim(wkStr), 10, 10)
			
			If wkJDNNO = lstJDNNO And wkUDNDT = lstUDNDT Then
				
				For I = LST.Items.Count - 1 To CInt(wkLSTCNT) Step -1
					LST.Items.RemoveAt((I))
				Next 
			Else
				Exit Sub
			End If
			
			'XX ページ送りされた場合の対処
		ElseIf WM_WLS_PAGE_END = WM_WLS_PAGE_CLICK_NUM + 1 Then 
			
			For I = LST.Items.Count - 1 To WM_WLS_LIST_CNT Step -1
				LST.Items.RemoveAt((I))
			Next 
		End If
		
	End Sub
	'2008/07/05 ADD START FKS)NAKATA
End Class