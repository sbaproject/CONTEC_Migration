
Option Strict Off
Option Explicit On
Module SSSWIN

    'Public DBN_SYSTBE As Short
    'Public SSS_INIDAT(4) As String 'ＩＮＩの内容
    'Public Const SSS_ReTryCnt As Short = 100 'ログファイルオープンリトライカウント
    'Public Const SSS_MAX_DB As Short = 22

    'Sub Error_Exit(ByVal ErrorMsg As String)
    '    Dim rtn As Object
    '    Dim I As Short
    '    '
    '    Call SSSWIN_LOGWRT(ErrorMsg)
    '    MsgBox("プログラムを終了します。", MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
    '    '
    '    If DBSTAT <> 0 Then
    '        MsgBox("エラーログの書き込みエラー ! Windows を再起動してください")
    '        '
    '    Else
    '        For I = SSS_MAX_DB - 1 To 0 Step -1
    '            Call DB_NCCLOSE(I)
    '        Next I
    '    End If
    '    Call DB_End()

    '    Dim A As Short = SSS_MAX_DB
    '    End
    'End Sub

    '    Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
    '        Dim errcnt, Fno, rtn As Short
    '        Dim wbuf As String
    '        '
    '        Call ResetDBSTAT(DBN_SYSTBE)
    '        '
    '        DB_SYSTBE.PRGID = SSS_PrgId
    '        DB_SYSTBE.LOGNM = LogMsg
    '        DB_SYSTBE.OPEID = SSS_OPEID.Value
    '        DB_SYSTBE.CLTID = SSS_CLTID.Value
    '        DB_SYSTBE.WRTTM = VB6.Format(Now, "hhnnss")
    '        DB_SYSTBE.WRTDT = VB6.Format(Now, "YYYYMMDD")
    '        '
    '        errcnt = 0
    '        Fno = FreeFile()
    '        On Error Resume Next
    '        'ディレクトリ存在チェック
    '        wbuf = Dir(SSS_INIDAT(1), 16)
    '        If wbuf = "" Then
    '            Call MsgBox("SSSWIN.INI の の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
    '            Call SSS_CLOSE()
    '            rtn = CspPurgeFilterReq(frmRptViewer.Handle.ToInt32)
    '            End
    '        End If
    '        Err.Clear()
    '        On Error GoTo ErrorLogFile
    '        Exit Sub
    'ErrorLogFile:
    '        errcnt = errcnt + 1
    '        If errcnt > SSS_ReTryCnt Then
    '            If MsgBox("履歴ファイルロックエラー !" & Chr(13) & "中止しても宜しいですか？", 20) = 6 Then
    '                Call SSS_CLOSE()
    '                rtn = CspPurgeFilterReq(frmRptViewer.Handle.ToInt32)
    '                End
    '            Else
    '                errcnt = 0
    '            End If
    '        End If
    '        System.Windows.Forms.Application.DoEvents()
    '        Resume
    '    End Sub


    'add start 20190820 kuwa 'おそらくDSP_MSGBOXはほかに存在する
    'Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
    '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
    '    '※メイン画面からのメッセ-ジ出力のみ対応。サブ画面未対応。
    '    Dim WK_PP As clsPP
    '    'UPGRADE_WARNING: オブジェクト WK_PP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    WK_PP = PP_SSSMAIN
    '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
    '    ' SSS/Win 共通のメッセージを表示します。
    '    '
    '    'delete start 20190807 kuwahara
    '    ''Close後はメッセージを表示しない
    '    'If RsOpened(DBN_SYSTBH) = False Then Exit Function
    '    '''delete end 20190807 kuwahara
    '    '''
    '    DB_SYSTBH.MSGNM = msgName
    '    '2019.04.11 CHG START
    '    'Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & VB6.Format(MSGSQ, "0"), BtrNormal)
    '    'change start 20190807 kuwahara
    '    'SYSTBH_GetFirst(MSGKB, DB_SYSTBH.MSGNM, VB6.Format(MSGSQ, "0"))
    '    GetRowsCommon("SYSTBH", "where MSGKB = '" & MSGKB & "' And MSGNM = '" & DB_SYSTBH.MSGNM & "' And MSGSQ = '" & VB6.Format(MSGSQ, "0") & "'")
    '    'change end 20190807 kuwahara
    '    '2019.04.11 CHG END
    '    If DBSTAT = 0 Then
    '        'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.ICNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNON) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBH.BTNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        DSP_MsgBox = MsgBox(Trim(DB_SYSTBH.MSGCM), SSSVAL(DB_SYSTBH.BTNKB) + SSSVAL(DB_SYSTBH.BTNON) + SSSVAL(DB_SYSTBH.ICNKB), Trim(SSS_PrgNm))
    '    Else
    '        MsgBox("メッセージファイルエラー  " & Chr(13) & Chr(13) & "DBSTAT=" & VB6.Format(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & VB6.Format(MSGSQ, "0"), MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
    '        Call Error_Exit("メッセージファイルエラー!")
    '    End If
    '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
    '    'UPGRADE_WARNING: オブジェクト PP_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    PP_SSSMAIN = WK_PP
    '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
    'End Function
    Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
        '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
        '    '※メイン画面からのメッセ-ジ出力のみ対応。サブ画面未対応。
        '    Dim WK_PP As clsPP
        '    WK_PP = PP_SSSMAIN
        '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
        '' SSS/Win 共通のメッセージを表示します。
        '    '
        '    ''Close後はメッセージを表示しない
        '    If RsOpened(DBN_SYSTBH) = False Then Exit Function
        '    ''
        '    DB_SYSTBH.MSGNM = msgName
        '    Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
        '    If DBSTAT = 0 Then
        '        DSP_MsgBox = MsgBox(Trim$(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
        '    Else
        '        MsgBox "メッセージファイルエラー  " & Chr(13) & Chr(13) & "DBSTAT=" & Format$(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & Format$(MSGSQ, "0"), MB_OK, Trim$(SSS_PrgNm)
        '        Call Error_Exit("メッセージファイルエラー!")
        '    End If
        '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
        '    PP_SSSMAIN = WK_PP
        '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
    End Function

    Public Const SSS_ERROR As String = "2" ' ＳＳＳエラーメッセージ



    'add end 20190820 kuwa

End Module
