Option Strict Off
Option Explicit On
Module IDOET52_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : UODET01.E01
	' 記述者            : Standard Library
	' 作成日付          : 1997/09/18
	' 使用プログラム名  : UODET01
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
End Module