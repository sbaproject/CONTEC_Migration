Option Strict Off
Option Explicit On
Module TOKMT54_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : TOKMT54.E01
	' 記述者            : Standard Library
	' 作成日付          : 1997/08/04
	' 使用プログラム名  : TOKMT54
	'
	
	Public Const WG_DKBSB As String = "010"
	
	Function DSPTRN() As Short
		'Dim DATNO As String, I As Integer, rtn As Integer
		'    '
		'    I = 0
		'    DATNO = Trim$(SSS_LASTKEY)
		'    Call DB_GetGrEq(DBN_JDNTHA, 1, SSS_LASTKEY, BtrNormal)
		'    If DBSTAT = 0 Then
		'        If SSSVal(DB_JDNTHA.JDNENDKB) > 0 Then        ' 受注確定済
		'            SSS_UPDATEFL = False
		'            Call DSP_MsgBox(SSS_CINFO, "CHANGE", 0)   ' 受注確定済の為、変更できません。
		'        ElseIf DB_JDNTHA.JDNDT <= DB_SYSTBA.MONUPDDT Then
		'            SSS_UPDATEFL = False                      ' 呼び出し伝票の経理確定処理日以前の更新を無効に
		'        End If
		'        Call SCR_FromJDNTHA(0)
		'        Call DB_GetGrEq(DBN_JDNTRA, 1, SSS_LASTKEY, BtrNormal)
		'        If (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) Then
		'            Do While (DBSTAT = 0) And (DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
		'                Call SCR_FromMfil(I)
		'                Call DB_GetNext(DBN_JDNTRA, BtrNormal)
		'                I = I + 1
		'            Loop
		'        End If
		'    End If
		'    '
		'    DSPTRN = I
	End Function
	
	Sub INITDSP()
		'
		'    Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
	End Sub
	
	Function INQ_UPDATE() As Object
		'Dim rtn As Integer
		'    '
		'    INQ_UPDATE = -1
		'    '
		'    Select Case SSS_BILFL
		'    Case 1      ' 伝票発行有り
		'        ' 伝票発行の場合はメッセージ確認をしないのでここでウィンドウを表示する
		'        DLGLST3.Show 1
		'        Select Case SSSVal(SSS_RTNWIN)
		'        Case 0              ' 計上＋発行
		'            rtn = DELTRN()
		'            rtn = WRTTRN()
		'            '1999/12/01 更新エラーの場合には伝票発行しない
		'            If rtn = True Then Call PRNBIL
		'            'Call PRNBIL
		'        Case 1              ' 計上のみ
		'            rtn = DELTRN()
		'            rtn = WRTTRN()
		'        Case 2              ' 発行のみ
		'            Call PRNBIL
		'        Case Else           ' 戻る
		'            INQ_UPDATE = 0
		'        End Select
		'    Case 9      ' 計上のみ
		'        rtn = DELTRN()
		'        rtn = WRTTRN()
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
	
	
	'Function DSPMST() As Integer
	'Dim I As Integer
	'    '
	'    I = 0
	'    SSS_FASTKEY = SSS_LASTKEY
	'    Call DB_GetGrEq(DBN_BNKMTA, 1, SSS_FASTKEY, BtrNormal)
	'    If DBSTAT = 0 Then
	'        Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
	'            Call SCR_FromMfil(I)
	'            If DB_BNKMTA.DATKB = "9" Then
	'                Call DP_SSSMAIN_UPDKB(I, "削除")
	'            Else
	'                Call DP_SSSMAIN_UPDKB(I, "更新")
	'            End If
	'            I = I + 1
	'            Call DB_GetNext(DBN_BNKMTA, BtrNormal)
	'        Loop
	'    End If
	'    If DBSTAT = 0 Then
	'        SSS_LASTKEY = DB_BNKMTA.BNKCD
	'    Else
	'        SSS_LASTKEY = HighValue(LenWid(DB_BNKMTA.BNKCD))
	'    End If
	'    DSPMST = I
	'End Function
	
	'Sub INITDSP()
	'Dim lngI As Long
	'
	'    '背景色の設定
	'    AE_BackColor(1) = &H8000000F
	'
	'    CL_SSSMAIN(0) = 1
	'    CL_SSSMAIN(1) = 1
	'
	'    For lngI = 0 To PP_SSSMAIN.MaxDe
	'        CL_SSSMAIN(2 + (lngI * 6)) = 1
	'    Next
	'
	'End Sub
	
	'Function MST_NEXT() As Integer
	'Dim Rtn As Integer
	'    '
	'    Call DB_GetGrEq(DBN_BNKMTA, 1, SSS_LASTKEY, BtrNormal)
	'    If DBSTAT = 0 Then
	'        MST_NEXT = DSPMST()
	'    Else
	'        SSS_LASTKEY = SSS_FASTKEY
	'        MST_NEXT = DSPMST()
	'    End If
	'End Function
	
	'Function MST_PREV() As Integer
	'Dim I As Integer
	'    '
	'    I = SET_GAMEN_KEY()
	'    I = 0
	'    Call DB_GetLs(DBN_BNKMTA, 1, SSS_FASTKEY, BtrNormal)
	'    Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
	'        I = I + 1
	'        Call DB_GetPre(DBN_BNKMTA, BtrNormal)
	'    Loop
	'    If DBSTAT <> 0 And I = 0 Then
	'        Call DB_GetFirst(DBN_BNKMTA, 1, BtrNormal)
	'    End If
	'    SSS_LASTKEY = DB_PARA(DBN_BNKMTA).KeyBuf
	'    I = DSPMST()
	'    MST_PREV = I
	'End Function
	
	'Function SET_GAMEN_KEY() As Integer
	'    '
	'    DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(0)
	'    SSS_LASTKEY = DB_BNKMTA.BNKCD
	'    SET_GAMEN_KEY = 4
	'End Function
End Module