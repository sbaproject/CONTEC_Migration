Option Strict Off
Option Explicit On

Module HKKET143M

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    Public gvintIndex As Short
    Public Const gvstrClass As String = "056" '//種別
    Public Const gvstrOrder_Rcv As String = "1" '//受注
    Public Const gvstrOrder As String = "2" '//発注
    Public Const gvstrEstimate As String = "3" '//見積
    Public Const gvstrIssue As String = "4" '//案件
    Public Const gvstrProvision As String = "5" '//支給
    Public Const gvstrOrderRcvEstimate As String = "6" '//見積(受注)
    Public Const gvstrSeiban As String = "7" '//製番出庫

    '2019/04/16 ADD START
    'SortOrder
    Private LvSortOrder As SortOrder
    '2019/04/16 ADD E N D

    '2019/04/24 ADD START
    Private InitSortColumn As Integer
    '2019/04/24 ADD E N D

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_Initialize
    '//*
    '//* <戻り値>
    '//*
    '//* <引  数>     項目名                  I/O           内容
    '//*
    '//* <説  明>
    '//*    初期処理
    '//*****************************************************************************************
    Function Set_Initialize() As Boolean
        '2019/04/11 DEL START
        'Dim SetLvFormat As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_Initialize"

        Set_Initialize = False

        On Error GoTo ONERR_STEP

        '// ＦＯＲＭキャプションセット
        'HKKET143F.Caption = gvcstJOB_Titl

        '//ＦＯＲＭ初期セット
        Call SetFormInitOrg(HKKET143F, 1)

        '//表示情報管理取得
        '2019/04/16 CHG START
        'Call SetLvFormat("E03", HKKET143F.lvwMEISAI)
        Call SetLvFormat("E03", HKKET143F.lvwMEISAI, LvSortOrder, InitSortColumn)
        '2019/04/16 CHG E N D

        '// 画面クリアー
        Call HKKET143M.Clr_Display()

        '//画面表示に必要なデータを取得し表示する
        If Not HKKET143M.Get_DisplayData Then
            GoTo EXIT_STEP
        End If

        Set_Initialize = True

        '--------------------------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '--------------------------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Clr_Display
    '//*
    '//* <戻り値>   型                  説明
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    画面クリア処理
    '//*****************************************************************************************
    Sub Clr_Display()

        Const PROCEDURE As String = "Clr_Display"


        On Error GoTo ONERR_STEP

        With HKKET143F
            .txtTERM.Text = vbNullString
            .txtYEAR.Text = vbNullString
            .txtMONTH.Text = vbNullString
            .txtHINCD.Text = vbNullString
            .txtHINNMA.Text = vbNullString
            .txtHINNMB.Text = vbNullString
            .txtZAIRNK.Text = vbNullString
            'UPGRADE_WARNING: オブジェクト HKKET143F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/11 CHG START
            '.lvwMEISAI.ListItems.Clear()
            .lvwMEISAI.Items.Clear()
            '2019/04/11 CHG E N D

            '2019/04/16 ADD START
            .LvSorter143F.Order = SortOrder.None
            '2019/04/16 ADD E N D

            .txtINQTY.Text = vbNullString
            .txtOUTQTY.Text = vbNullString
            .txtSKYQTY.Text = vbNullString
            .txtISSUE.Text = vbNullString
            .txtESTIMATE.Text = vbNullString
            .txtMKOUTQTY.Text = vbNullString

        End With

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_DisplayData
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*
    '//*****************************************************************************************
    Public Function Get_DisplayData() As Boolean

        Const PROCEDURE As String = "Get_DisplayData"
        Dim vntArray As Object

        Get_DisplayData = False

        On Error GoTo ONERR_STEP

        With HKKET143F
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= CDbl(Mid(gvstrUNYDT, 1, 4)) - 1 & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= Mid(gvstrUNYDT, 1, 4) & "03" Then
                .txtTERM.Text = CStr(CDbl(gvstrTERMNO) - 1)
            End If
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= Mid(gvstrUNYDT, 1, 4) & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= CDbl(Mid(gvstrUNYDT, 1, 4)) + 1 & "03" Then
                .txtTERM.Text = gvstrTERMNO
            End If
            If HKKET142F.cmdMONTH(gvintIndex).Tag >= CDbl(Mid(gvstrUNYDT, 1, 4)) + 1 & "04" And HKKET142F.cmdMONTH(gvintIndex).Tag <= CDbl(Mid(gvstrUNYDT, 1, 4)) + 2 & "03" Then
                .txtTERM.Text = CStr(CDbl(gvstrTERMNO) + 1)
            End If

            .txtTODAY.Text = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
            .txtYEAR.Text = Mid(HKKET142F.cmdMONTH(gvintIndex).Tag, 1, 4)
            .txtMONTH.Text = Mid(HKKET142F.cmdMONTH(gvintIndex).Tag, 5, 2)
            .txtHINCD.Text = HKKET142F.txtHINCD.Text
            .txtHINNMA.Text = HKKET142F.txtHINNMA.Text
            .txtHINNMB.Text = HKKET142F.txtHINNMB.Text
            .txtZAIRNK.Text = HKKET142F.txtZAIRNK.Text
            .txtTODAY.Text = HKKET142F.txtTODAY.Text
            .txtINQTY.Text = CStr(musrHKKZTRA.dblINPTRA(gvlngNowPage + gvintIndex))
            .txtOUTQTY.Text = CStr(musrHKKZTRA.dblOUTTRA(gvlngNowPage + gvintIndex))
            .txtSKYQTY.Text = CStr(musrHKKZTRA.dblSKYOUT(gvlngNowPage + gvintIndex))
            .txtISSUE.Text = CStr(musrMKMTRA.dblMKMAK(gvlngNowPage + gvintIndex))
            .txtESTIMATE.Text = CStr(musrMKMTRA.dblMKMMT(gvlngNowPage + gvintIndex))
            .txtMKOUTQTY.Text = CStr(musrMKMTRA.dblMKMOUTTRA(gvlngNowPage + gvintIndex))

        End With
        '//販売計画詳細情報取得
        If Not Get_HKDTRA() Then
            GoTo EXIT_STEP
        End If

        Get_DisplayData = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Get_HKDTRA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*
    '//* <説  明>
    '//*    販売計画詳細情報を取得する
    '//*****************************************************************************************
    Public Function Get_HKDTRA() As Boolean

        Const PROCEDURE As String = "Get_HKDTRA"

        Dim strSQL As String
        '2019/05/13 DEL START
        ''UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        'Dim objRec As OraDynaset
        '2019/05/13 DEL E N D

        Get_HKDTRA = False

        On Error GoTo ONERR_STEP

        ' SQL文の作成
        strSQL = ""
        strSQL = strSQL & "SELECT HKDTRA.* , MEIMTA.* , HKDTRA.DATKB AS HKDDATKB" & vbCrLf
        strSQL = strSQL & "FROM   HKDTRA,MEIMTA " & vbCrLf
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "WHERE  HKKYM = " & D0.Edt_SQL("S", HKKET143F.txtYEAR.Text & HKKET143F.txtMONTH.Text) & vbCrLf
        '// 2007/06/08 ↓ REP
        '    strSQL = strSQL & "  AND  HINCD = " & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text) & vbCrLf
        If HKKET141F.optVERSION.Checked Then
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "  AND  HINCD LIKE (" & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text & "%") & ")" & vbCrLf
        Else
            'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "  AND  HINCD = " & D0.Edt_SQL("S", HKKET143F.txtHINCD.Text) & vbCrLf
        End If
        '// 2007/06/08 ↑ REP
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  AND  KEYCD = " & D0.Edt_SQL("S", gvstrClass) & vbCrLf
        strSQL = strSQL & "  AND  SBCD  = MEICDA "
        strSQL = strSQL & "  AND  SBCD  in  ("
        '// 2007/03/10 ↓ DEL
        '    If HKKET143F.txtYEAR.Text & HKKET143F.txtMONTH.Text >= Mid(gvstrUNYDT, 1, 6) Then
        '// 2007/03/10 ↑ DEL
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder_Rcv) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrEstimate) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrIssue) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrProvision) & vbCrLf
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrderRcvEstimate) & vbCrLf
        '// 2007/02/20 ↓ ADD
        strSQL = strSQL & ","
        'UPGRADE_WARNING: オブジェクト D0.Edt_SQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & D0.Edt_SQL("S", gvstrSeiban) & vbCrLf
        '// 2007/02/20 ↑ ADD
        '// 2007/03/10 ↓ DEL
        '    Else
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder_Rcv) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrder) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrProvision) & vbCrLf
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrOrderRcvEstimate) & vbCrLf
        ''// 2007/02/20 ↓ ADD
        '        strSQL = strSQL & ","
        '        strSQL = strSQL & D0.Edt_SQL("S", gvstrSeiban) & vbCrLf
        ''// 2007/02/20 ↑ ADD
        '    End If
        '// 2007/03/10 ↑ DEL
        strSQL = strSQL & "  )"

        ' データ取得
        'UPGRADE_WARNING: オブジェクト clsOra.OraCreateDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/15 CHG E N D

        'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/15 CHG E N D
            '//販売計画詳細情報より画面に表示する
            '2019/04/15 CHG START
            'If Not Set_HKDTRA(objRec) Then
            If Not Set_HKDTRA(dt) Then
                '2019/04/15 CHG E N D
                GoTo EXIT_STEP
            End If
            'UPGRADE_WARNING: オブジェクト HKKET143F.lvwMEISAI.FullRowSelect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            HKKET143F.lvwMEISAI.FullRowSelect = True
            'UPGRADE_WARNING: オブジェクト HKKET143F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/11 CHG START
            'HKKET143F.lvwMEISAI.ListItems.Item(1).Selected = True
            HKKET143F.lvwMEISAI.Items.Item(0).Selected = True
            '2019/04/11 CHG E N D
        End If
        'UPGRADE_WARNING: オブジェクト clsOra.OraCloseDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKDTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    Set_HKDTRA
    '//*
    '//* <戻り値>   型                  説明
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <引  数>   項目名              型              I/O     内容
    '//*            objRec              OraDynaset       I
    '//*
    '//* <説  明>
    '//*    販売計画詳細情報表示
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKDTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKDTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKDTRA"

        'UPGRADE_ISSUE: ListItem オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        'Dim i As Short
        '2019/04/11 DEL E N D
        Set_HKDTRA = False

        On Error GoTo ONERR_STEP

        '2019/04/11 ADD START
        With HKKET143F.lvwMEISAI
            '2019/04/11 ADD E N D

            '2019/04/11 DEL START
            'i = 1
            '2019/04/11 DEL E N D

            '2019/04/15 ADD START
            Dim itemCnt As Integer = 0
            '2019/04/15 ADD E N D

            'UPGRADE_WARNING: オブジェクト clsOra.OraEOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/11 CHG START
            'Do Until clsOra.OraEOF(objRec)
            For Each row As DataRow In pDT.Rows
                '2019/04/11 CHG E N D
                '// 2007/01/09 ↓ UPD STR
                '        Set objLitem = HKKET143F.lvwMEISAI.ListItems.Add(i, , D0.Chk_Null(objRec("MEINMA")))      '//種別
                '        objLitem.SubItems(1) = D0.Chk_Null(objRec("HKKSU"))    '//販売計画数量
                '        objLitem.SubItems(2) = D0.Chk_Null(objRec("HKKINFA"))  '//受注番号等
                '        objLitem.SubItems(3) = D0.Chk_Null(objRec("TANNM"))    '//担当者名
                '        objLitem.SubItems(4) = Format(D0.Chk_Null(objRec("HKKINFC")), "@@@@/@@/@@") '//受注日等
                '        objLitem.SubItems(5) = Format(D0.Chk_Null(objRec("HKKINFD")), "@@@@/@@/@@") '//出荷日等
                '        objLitem.SubItems(6) = D0.Chk_Null(objRec("HKKINFE"))  '//件名等
                '        objLitem.SubItems(7) = D0.Chk_Null(objRec("HKKINFF"))  '//得意先名等
                '        objLitem.SubItems(8) = D0.Chk_Null(objRec("PHINCD"))   '//親製品コード
                '        objLitem.SubItems(9) = D0.Chk_Null(objRec("PHINKTA"))  '//親型式
                '        objLitem.SubItems(10) = D0.Chk_Null(objRec("ORDSCLNM")) '//受注規模／確度名
                '        objLitem.SubItems(11) = IIf(D0.Chk_Null(objRec("KHIKKB")) = "1", "仮", "") '//仮引当区分
                'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト HKKET143F.lvwMEISAI.ListItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/11 CHG START
                'objLitem = HKKET143F.lvwMEISAI.ListItems.Add(i, , D0.Chk_Null(objRec("MEINMA"))) '//種別
                '0～13(全14列)
                '//0:
                .Items.Add(D0.Chk_Null(row("MEINMA")), itemCnt) '//種別
                '2019/04/11 CHG E N D
                'UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '//1:
                Select Case D0.Chk_Null(row("HKDDATKB")) '//削除区分
                    Case "1"
                        'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = "黒"
                        .Items(itemCnt).SubItems.Add("黒")
                        '2019/04/11 CHG E N D
                    Case "9"
                        'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = "赤"
                        .Items(itemCnt).SubItems.Add("赤")
                        '2019/04/11 CHG E N D
                    Case Else
                        'UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/11 CHG START
                        'objLitem.SubItems(1) = ""
                        .Items(itemCnt).SubItems.Add("")
                        '2019/04/11 CHG E N D
                End Select
                '2019/04/11 CHG START
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(2) = D0.Chk_Null(objRec("HKKSU")) '//販売計画数量
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(3) = D0.Chk_Null(objRec("HKKINFA")) '//受注番号等
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(4) = D0.Chk_Null(objRec("MITNO")) '//見積番号
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(5) = D0.Chk_Null(objRec("TANNM")) '//担当者名
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(6) = VB6.Format(D0.Chk_Null(objRec("HKKINFC")), "@@@@/@@/@@") '//受注日等
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(7) = VB6.Format(D0.Chk_Null(objRec("HKKINFD")), "@@@@/@@/@@") '//出荷日等
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(8) = D0.Chk_Null(objRec("HKKINFE")) '//件名等
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(9) = D0.Chk_Null(objRec("HKKINFF")) '//得意先名等
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(10) = D0.Chk_Null(objRec("PHINCD")) '//親製品コード
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(11) = D0.Chk_Null(objRec("PHINKTA")) '//親型式
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(12) = D0.Chk_Null(objRec("ORDSCLNM")) '//受注規模／確度名
                ''UPGRADE_WARNING: オブジェクト objLitem.SubItems の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト D0.Chk_Null の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'objLitem.SubItems(13) = IIf(D0.Chk_Null(objRec("KHIKKB")) = "1", "仮", "") '//仮引当区分
                '//2:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKSU"))) '//販売計画数量
                '//3:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFA"))) '//受注番号等
                Debug.Print("itemCnt:" & itemCnt)
                Debug.Print("row(""HKKINFA""):" & row("HKKINFA"))
                Debug.Print("Text:" & HKKET143F.lvwMEISAI.Items(itemCnt).SubItems(3).Text)
                '//4:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("MITNO"))) '//見積番号
                '//5:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("TANNM"))) '//担当者名
                '//6:
                .Items(itemCnt).SubItems.Add(VB6.Format(D0.Chk_Null(row("HKKINFC")), "@@@@/@@/@@")) '//受注日等
                '//7:
                .Items(itemCnt).SubItems.Add(VB6.Format(D0.Chk_Null(row("HKKINFD")), "@@@@/@@/@@")) '//出荷日等
                '//8:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFE"))) '//件名等
                '//9:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HKKINFF"))) '//得意先名等
                '//10:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("PHINCD"))) '//親製品コード
                '//11:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("PHINKTA"))) '//親型式
                '//12:
                .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("ORDSCLNM"))) '//受注規模／確度名
                '//13:
                .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("KHIKKB")) = "1", "仮", "")) '//仮引当区分
                '2019/04/11 CHG E N D
                '// 2007/01/09 ↑ UPD END
                '2019/04/15 DEL START
                'i = i + 1
                '2019/04/15 DEL E N D

                '2019/04/15 DEL START
                ''//次ﾚｺｰﾄﾞ検索
                ''UPGRADE_WARNING: オブジェクト clsOra.OraMoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'clsOra.OraMoveNext(objRec)
                '2019/04/15 DEL E N D

                '2019/04/15 ADD START
                itemCnt += 1
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                'Loop
            Next
            '2019/04/15 CHG E N D

        '2019/04/11 ADD START
        End With
        '2019/04/11 ADD E N D

        '2019/04/16 ADD START
        HKKET143F.lvSorter143F.Order = LvSortOrder  'ItemAdd後に設定する
        Call SortLv(HKKET143F.lvwMEISAI, InitSortColumn, HKKET143F.lvSorter143F, True)
        '2019/04/16 ADD E N D

        Set_HKDTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: オブジェクト ClsMessage.RuntimeErrorMsg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
End Module