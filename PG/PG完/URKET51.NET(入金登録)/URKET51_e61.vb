Option Strict Off
Option Explicit On
Module URKET51_E61
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : URKET51.E61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : URKET51
	'
	'Global Const WG_TUKKB = "JPY"
	'Global Const WG_DKBSB = "050"
	'Global Const WG_DENKB = "8"
	Public DateFirst As Boolean
	Function DSPTRN() As Object
		'Dim WK_DATNO, I As Integer
		'    '
		'    I = 0
		'    WK_DATNO = Trim$(SSS_LASTKEY)
		'    Call DB_GetGrEq(DBN_UDNTHA, 1, SSS_LASTKEY, BtrNormal)
		'    If DBSTAT = 0 Then
		''        If DB_UDNTHA.UDNDT <= DB_SYSTBA.UKSMEDT Then
		''            SSS_UPDATEFL = False   '呼び出し伝票の経理確定処理日以前の更新を無効に
		''        End If
		'        Call SCR_FromUDNTHA(0)
		'        Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY, BtrNormal)
		'        If (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) Then
		'            Do While (DBSTAT = 0) And (WK_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
		'                Call SCR_FromMfil(I)
		'                Call DB_GetNext(DBN_UDNTRA, BtrNormal)
		'                I = I + 1
		'            Loop
		'        End If
		'    End If
		'    DSPTRN = I
	End Function
	
	Sub INITDSP()
		'Dim Px As Integer
		'Dim I As Integer
		'    '
		'    Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
		'    '
		'    '背景色変更
		'    AE_BackColor(1) = &H8000000F
		'    AE_BackColor(2) = &HFFFFFF
		'    '
		'    ' ヘッダ
		'    CL_SSSMAIN(4) = 1
		'    CL_SSSMAIN(5) = 1
		'    CL_SSSMAIN(7) = 1
		'    CL_SSSMAIN(8) = 1
		'    '
		'    ' ボディ
		'    For I = 0 To PP_SSSMAIN.MaxDe
		'        CL_SSSMAIN(29 + (I * 23) + 0) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 2) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 6) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 7) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 8) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 9) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 10) = 1
		'        CL_SSSMAIN(29 + (I * 23) + 11) = 1
		'    Next
		'    '
		'    ' テイル
		'    CL_SSSMAIN(29 + (PP_SSSMAIN.MaxDe + 1) * 23 + 0) = 11
		'    CL_SSSMAIN(29 + (PP_SSSMAIN.MaxDe + 1) * 23 + 1) = 11
		
	End Sub
	
	Function INQ_UPDATE() As Object
		'Dim Rtn As Integer
		'    '
		'    INQ_UPDATE = -1
		'    '
		'    Select Case SSS_BILFL
		'    Case 1      ' 伝票発行有り
		'        ' 伝票発行の場合はメッセージ確認をしないのでここでウィンドウを表示する
		'        DLGLST3.Show 1
		'        Select Case SSSVal(SSS_RTNWIN)
		'        Case 0              ' 計上＋発行
		'            Rtn = DELTRN()
		'            Rtn = WRTTRN()
		'            '1999/12/01 更新エラーの場合には伝票発行しない
		'            If Rtn = True Then Call PRNBIL
		'            'Call PRNBIL
		'        Case 1              ' 計上のみ
		'            Rtn = DELTRN()
		'            Rtn = WRTTRN()
		'        Case 2              ' 発行のみ
		'            Call PRNBIL
		'        Case Else           ' 戻る
		'            INQ_UPDATE = 0
		'        End Select
		'    Case 9      ' 計上のみ
		'        Rtn = DELTRN()
		'        Rtn = WRTTRN()
		'    End Select
	End Function
	
	' プリンタ切り替え機能を有効にする場合は以下のコメントアウト部分を有効にする。
	' 次にＳＦＤまたはＰＤＢで画面の”CM_LCONFIG”イメージを非表示から表示へ変更する。
	Function LCONFIG_GetEvent() As Short
		'   ' プリンター設定
		'    LCONFIG_GetEvent = True
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        SSS_RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        SSS_RPTID = ""
		'    End If
		'    WLS_PRN.Show 1
	End Function
End Module