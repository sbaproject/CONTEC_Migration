Option Strict Off
Option Explicit On
Module SYKFP51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : SYKFP51.E01
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/20
	' 使用プログラム名  : SYKFP51
	'
	Public WG_WRKFSTDT As String
	Public WG_WRKFSTTM As String
	
	Sub INITDSP()
		
		Dim lngI As Integer
		Dim EXEPATH As String
		Dim I As Short
		Dim rtn As Short
		Dim strSQL As String
		
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(2) = 1
		CL_SSSMAIN(3) = 1
		CL_SSSMAIN(4) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(6) = 1
		
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		'出庫予定ファイルの削除
		''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
		''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
		'''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
		''''    Call DB_Delete(DBN_SYKTRA)
		''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		''''Loop
		
		'実行権限の取得
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		'権限チェック
		If gs_UPDAUTH = "9" Then
			rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '更新権限なし
			End
		End If
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If


        '出庫予定ファイル作成実行

        EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
        '2019/10/03 仮
        'I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)

        '      strSQL = ""
        'strSQL = strSQL & "SELECT MAX(WRTFSTDT || WRTFSTTM) FROM FDNTHA"
        'strSQL = strSQL & "  WHERE PGID = 'SYKFP51'"
        'Call DB_GetSQL2(DBN_FDNTHA, strSQL)

        'WG_WRTFSTDT = Left(CStr(DB_ExtNum.ExtNum(0)), 8)
        'WG_WRTFSTTM = Mid(CStr(DB_ExtNum.ExtNum(0)), 9, 6)
        '2019/10/03 仮

    End Sub
End Module