Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

'2019/05/13 ADD START
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'2019/05/13 ADD E N D
Module Module1

    '//**************************************************************************************
    '//*
    '//* <名  称>
    '//*    MAIN
    '//* <概　要>
    '//*    印刷処理
    '//*    各プログラムによって、抽出条件が異なる
    '//*
    '//* <戻り値>     型          説明
    '//*　　なし
    '//* <引  数>     項目名             型              I/O           内容
    '//*　　　　　　　帳票PK
    '//*　　　　　　　プリント区分
    '//*　　　　　　　プレビュー区分
    '//*　　　　　　　プロネス共通引数
    '//*
    '//* <説  明>
    '//*
    '//*
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)          |新規作成
    '//* 1.01     |20100420|ECHO)          |<ST-0038>ＣＳＶ出力パス変更
    '//* 1.02     |20100517|ECHO)          |<IT-0036,0037>
    '//*                                   |売上原価対照表(経理調整・全社)のCSV出力条件追加
    '//* 1.03     |20100518|ECHO)          |<ST-0134>製造原価元帳のタイトル変更
    '//* 1.05     |20100526|ECHO)植村      |<ST-0152>進行基準フラグを出力
    '//* 1.06     |20100604|ECHO)          |<IT2-00XX>仕掛品明細表・売上時原価明細表・
    '//*                                   |追加原価明細表のタイトル変更
    '//* 1.06     |20100625|ECHO)          |<OT-00XX>レスポンス対応
    '//*                                   |抽出のSQLとoo4oを使用するように変更
    '//*                                   |仕掛品明細票のみ暫定対応
    '//* 1.07     |20100720|ECHO)          |<OT-0138>見出し項目の修正(労務費 → 労務・間接費)
    '//* 1.08     |20150109|RS)            |製造原価元帳CSV出力順の設定追加　製番体系区分、製番、SQL
    '//*                                   |原価差額分析表CSVタイトル修正
    '//*          |20151006|FWEST          |PDF出力処理追加
    '//*          |20151029|FWEST          |CSV出力処理追加
    '//**************************************************************************************

    '**** レポートファイル保存場所 ****
    '** 　下記フォルダ内に、RPTフォルダを作成し、その中にレポートファイルをまとめて保存 **
    '**********************************

    '**** コマンドライン引数 ****
    Public ps_UserName As String 'ｵﾗｸﾙﾕｰｻﾞ
    Public ps_Password As String 'ｵﾗｸﾙ接続 ﾊﾟｽﾜｰﾄﾞ
    Public ps_DatabaseName As String 'ｵﾗｸﾙ接続文字列
    Public ps_GENKAUserName As String '原価ｼｽﾃﾑﾕｰｻﾞ
    Public ps_User_Lang As String '
    Public ps_Rpt_Lang As String
    Public ps_Param_Mode As String
    Public ps_Param_Factory As String
    Public ps_Param_AnyNo As String
    Public li_StartIdx As String
    Public ps_prtPmKey As String

    Public SSS_PrgId As String 'ﾌﾟﾛｸﾞﾗﾑＩＤ
    Public SSS_PrgNm As String 'ﾌﾟﾛｸﾞﾗﾑ名
    Public SSS_PrtID As String 'レポートＩＤ
    Public SSS_RPT_DIR As String 'レポート格納場所
    Public SSS_TblID As String 'テーブルＩＤ
    Public SSS_PRINTER_NM As String 'プリンタ名称

    'レポートＩＤ
    Public Const ps_rptid_GNKPR01 As String = "GNKPR01"
    Public Const ps_rptid_GNKPR02 As String = "GNKPR02"
    Public Const ps_rptid_GNKPR03 As String = "GNKPR03"
    Public Const ps_rptid_GNKPR04 As String = "GNKPR04"
    Public Const ps_rptid_GNKPR05 As String = "GNKPR05"
    Public Const ps_rptid_GNKPR06 As String = "GNKPR06"
    Public Const ps_rptid_GNKPR07 As String = "GNKPR07"
    Public Const ps_rptid_GNKPR08 As String = "GNKPR08"
    Public Const ps_rptid_GNKPR09 As String = "GNKPR09"
    Public Const ps_rptid_GNKPR10 As String = "GNKPR10"
    Public Const ps_rptid_GNKPR18 As String = "GNKPR18"
    Public Const ps_rptid_GNKPR12 As String = "GNKPR12"
    Public Const ps_rptid_GNKPR13 As String = "GNKPR13"
    Public Const ps_rptid_GNKPR14 As String = "GNKPR14"
    Public Const ps_rptid_GNKPR16 As String = "GNKPR16"
    'レポート名
    Const ps_rptnm_GNKPR01 As String = "売上原価対照表（経理調整後）(全社）"
    Const ps_rptnm_GNKPR02 As String = "売上原価対照表(全社）"
    Const ps_rptnm_GNKPR03 As String = "売上原価対照表(本部別）"
    Const ps_rptnm_GNKPR04 As String = "売上原価対照表(取引先別）"
    Const ps_rptnm_GNKPR05 As String = "売上時原価明細表"
    Const ps_rptnm_GNKPR06 As String = "追加原価明細表"
    Const ps_rptnm_GNKPR07 As String = "仕掛品明細表"
    Const ps_rptnm_GNKPR08 As String = "製造原価元帳"
    Const ps_rptnm_GNKPR09 As String = "見込品元帳"
    '<2014/10/21 UPD STR>
    'Const ps_rptnm_GENPR10 As String = "棚札"
    Const ps_rptnm_GNKPR10 As String = "仕掛品チェックリスト"
    Const ps_rptnm_GNKPR18 As String = "原価分析表"
    Const ps_rptnm_GNKPR12 As String = "工数集計総括表"
    Const ps_rptnm_GNKPR13 As String = "原価差額分析表"
    Const ps_rptnm_GNKPR14 As String = "労務費・間接費配賦総括表"
    Const ps_rptnm_GNKPR16 As String = "原価振替リスト"
    '<2014/10/21 UPD END>


    'UPGRADE_WARNING: Sub Main() が完了したときにアプリケーションは終了します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"' をクリックしてください。
    Public Sub Main()


        Dim li_MsgRtn As Short 'MsgBoxの戻り値
        Dim li_UpperBound As Short 'MsgBoxの戻り値
        Dim wrk As String 'コマンドライン引数設定用ワーク
        Dim prtCmd() As String
        Dim prtKbn As String 'プリント区分
        Dim prvKbn As String 'プレビュー区分
        Dim is_Proness As String 'プロネス共通引数
        Dim li_Ret As Short
        Dim li_StrLen As Short
        Dim li_UserSTR As Short
        Dim li_PassSTR As Short
        Dim li_DbNameSTR As Short
        Dim li_PRONES_UserSTR As Short
        Dim li_ULangSTR As Short
        Dim li_RLangSTR As Short
        Dim li_ModeSTR As Short
        Dim li_FactorySTR As Short
        Dim li_AnyNoSTR As Short
        Dim li_UserLen As Short
        Dim li_PassLen As Short
        Dim li_DbNameLen As Short
        Dim li_PRONES_UserLen As Short
        Dim li_ULangLen As Short
        Dim li_RLangLen As Short
        Dim li_ModeLen As Short
        Dim li_FactoryLen As Short
        Dim li_AnyNoLen As Short
        Dim li_Idx As Short
        Dim ls_CmdFlg As String
        Dim ls_WorkStr As String
        Dim ls_StartTxt As String
        Dim ls_FileName As String '2015/10/6追記　FWEST


        '--------------------------------------------------------------------------
        '処理開始
        '--------------------------------------------------------------------------
        '---戻り値設定---'
        li_UpperBound = 0

        '---初期化---'
        'コマンドライン引数の設定
        wrk = VB.Command()

        prtCmd = Split(Trim(wrk), ",")

        ' 帳票PK
        ps_prtPmKey = prtCmd(1)
        ' レポートＩＤ
        SSS_PrtID = prtCmd(2)
        'プリンター名
        SSS_PRINTER_NM = prtCmd(3)
        ' プリント区分
        prtKbn = prtCmd(4)
        ' プレビュー区分
        '            prvKbn = Left(prtCmd(3), 1)
        prvKbn = prtCmd(5)
        ' プロネス共通引数
        is_Proness = Trim(prtCmd(6))

        '2015/10/6追記　FWEST
        'もしPDF出力用のコマンドライン引数があるならば
        If UBound(prtCmd) - LBound(prtCmd) + 1 = 8 Then
            ' PDFのファイル名(絶対パス)
            ls_FileName = Trim(prtCmd(7))
        End If

        '文字数
        li_UpperBound = Len(ps_prtPmKey) + Len(prtKbn) + Len(prvKbn)
        '''コマンドライン引数確認用
        '''MsgBox("コマンドライン引数:" & wrk)
        '''MsgBox("レポートＩＤ:" & SSS_PrtID)
        '''MsgBox("プリンタ名:" & SSS_PRINTER_NM)
        '''MsgBox("帳票PK:" & ps_prtPmKey)
        '''MsgBox("プリント区分:" & prtKbn)
        '''MsgBox("プレビュー区分:" & prvKbn)
        '''MsgBox("プロネス共通引数:" & is_Proness)
        '''MsgBox("PDF名:" & PDF_NM)


        li_StrLen = Len(is_Proness)
        li_UserSTR = 1
        li_PassSTR = 1
        li_DbNameSTR = 1
        li_PRONES_UserSTR = 1
        li_ULangSTR = 1
        li_RLangSTR = 1
        li_ModeSTR = 1
        li_FactorySTR = 1
        li_AnyNoSTR = 1
        li_UserLen = 0
        li_PassLen = 0
        li_DbNameLen = 0
        li_PRONES_UserLen = 0
        li_ULangLen = 0
        li_RLangLen = 0
        li_ModeLen = 0
        li_FactoryLen = 0
        li_AnyNoLen = 0

        ls_CmdFlg = "USER"
        For li_Idx = 1 To li_StrLen
            Select Case Trim(ls_CmdFlg)
                Case "USER"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "/" Then
                        li_PassSTR = li_Idx + 1
                        ls_CmdFlg = "PASS"
                    Else
                        li_UserLen = li_UserLen + 1
                    End If
                Case "PASS"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "@" Then
                        li_DbNameSTR = li_Idx + 1
                        ls_CmdFlg = "DBNAME"
                    Else
                        li_PassLen = li_PassLen + 1
                    End If
                Case "DBNAME"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_PRONES_UserSTR = li_Idx + 1
                        ls_CmdFlg = "PRONES_USER"
                    Else
                        li_DbNameLen = li_DbNameLen + 1
                    End If
                Case "PRONES_USER"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_ULangSTR = li_Idx + 1
                        ls_CmdFlg = "ULang"
                    Else
                        li_PRONES_UserLen = li_PRONES_UserLen + 1
                    End If
                Case "ULang"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_RLangSTR = li_Idx + 1
                        ls_CmdFlg = "RLang"
                    Else
                        li_ULangLen = li_ULangLen + 1
                    End If
                Case "RLang"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_ModeSTR = li_Idx + 1
                        ls_CmdFlg = "Mode"
                    Else
                        li_RLangLen = li_RLangLen + 1
                    End If
                Case "Mode"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_FactorySTR = li_Idx + 1
                        ls_CmdFlg = "Factory"
                    Else
                        li_ModeLen = li_ModeLen + 1
                    End If
                Case "Factory"
                    ls_WorkStr = Mid(is_Proness, li_Idx, 1)
                    If ls_WorkStr = "&" Then
                        li_AnyNoSTR = li_Idx + 1
                        ls_CmdFlg = "AnyNo"
                    Else
                        li_FactoryLen = li_FactoryLen + 1
                    End If
                Case "AnyNo"
                    li_AnyNoLen = li_AnyNoLen + 1
            End Select
        Next li_Idx

        ps_UserName = Mid(is_Proness, li_UserSTR, li_UserLen)
        ps_Password = Mid(is_Proness, li_PassSTR, li_PassLen)
        ps_DatabaseName = Mid(is_Proness, li_DbNameSTR, li_DbNameLen)
        ps_GENKAUserName = Mid(is_Proness, li_PRONES_UserSTR, li_PRONES_UserLen)
        ps_User_Lang = Mid(is_Proness, li_ULangSTR, li_ULangLen)
        ps_Rpt_Lang = Mid(is_Proness, li_RLangSTR, li_RLangLen)
        ps_Param_Mode = Mid(is_Proness, li_ModeSTR, li_ModeLen)
        ps_Param_Factory = Mid(is_Proness, li_FactorySTR, li_FactoryLen)
        ps_Param_AnyNo = Mid(is_Proness, li_AnyNoSTR, li_AnyNoLen)


        '****************************************
        '***
        '***   iniファイル 取得（保留）
        '***
        '****************************************
        'CALL GENKA_GETINI()


        '****************************************
        '***
        '***   レポートファイル格納場所　取得
        '***
        '****************************************
        Dim sDIR As String
        Dim lLen As Integer
        Dim lStt As Integer
        Dim lEnd As Integer

        sDIR = My.Application.Info.DirectoryPath
        lLen = Len(sDIR)
        For lStt = 1 To lLen
            If InStr(lStt, sDIR, "\") <> 0 Then
                lEnd = InStr(lStt, sDIR, "\")
                lStt = lEnd
            Else
                Exit For
            End If
        Next
        SSS_RPT_DIR = Left(sDIR, lEnd) & "RPT"

        'MsgBox SSS_RPT_DIR

        '****************************************
        '***
        '***   帳票名　取得
        '***
        '****************************************
        If GET_RPTNM() = 0 Then

            '2015/10/6追記　FWEST
            If UBound(prtCmd) - LBound(prtCmd) + 1 = 8 Then
                '帳票PDF出力処理
                PDF_OUTPUT(ls_FileName)

                '2015/10/29追記　FWEST
                '工数集計総括表はCSV出力ボタンを表示しない
                If SSS_PrtID <> ps_rptid_GNKPR12 Then
                    'CSV出力処理
                    CSV_OUTPUT_B(ls_FileName)
                End If
            Else
                '帳票VIEWER処理
                Call frmRptViewer.Show()
            End If
        End If

    End Sub


    Private Function GET_RPTNM() As Short

        Dim li_Ret As Short

        li_Ret = 0


        Select Case SSS_PrtID

            Case ps_rptid_GNKPR01 '売上原価対照表（経理調整後）(全社）
                SSS_TblID = "C_G105W"
                SSS_PrgNm = ps_rptnm_GNKPR01

            Case ps_rptid_GNKPR02 '売上原価対照表(全社）
                SSS_TblID = "C_G106W"
                SSS_PrgNm = ps_rptnm_GNKPR02

            Case ps_rptid_GNKPR03 '売上原価対照表(事業部）
                SSS_TblID = "C_G107W"
                SSS_PrgNm = ps_rptnm_GNKPR03

            Case ps_rptid_GNKPR04 '売上原価対照表(取引先別）
                SSS_TblID = "C_G108W"
                SSS_PrgNm = ps_rptnm_GNKPR04

            Case ps_rptid_GNKPR05 '売上時原価明細表
                SSS_TblID = "C_G103W"
                SSS_PrgNm = ps_rptnm_GNKPR05

            Case ps_rptid_GNKPR06 '追加原価明細表
                SSS_TblID = "C_G104W"
                SSS_PrgNm = ps_rptnm_GNKPR06

            Case ps_rptid_GNKPR07 '仕掛品明細表
                SSS_TblID = "C_G101W"
                SSS_PrgNm = ps_rptnm_GNKPR07

            Case ps_rptid_GNKPR08 '製造原価元帳
                SSS_TblID = "C_G110W"
                SSS_PrgNm = ps_rptnm_GNKPR08

            Case ps_rptid_GNKPR09 '見込品元帳
                SSS_TblID = "C_G102W"
                SSS_PrgNm = ps_rptnm_GNKPR09

                '        Case ps_rptid_GENPR10           '棚札
                '            SSS_TblID = "C_G013W"
                '            SSS_PrgNm = ps_rptnm_GENPR10

            Case ps_rptid_GNKPR10 '仕掛品チェックリスト
                SSS_TblID = "C_G114W"
                SSS_PrgNm = ps_rptnm_GNKPR10

            Case ps_rptid_GNKPR18 '原価分析表
                SSS_TblID = "C_G112W"
                SSS_PrgNm = ps_rptnm_GNKPR18

            Case ps_rptid_GNKPR12 '工数集計総括表
                SSS_TblID = "C_G109W"
                SSS_PrgNm = ps_rptnm_GNKPR12

            Case ps_rptid_GNKPR13 '原価差額分析表
                SSS_TblID = "C_G111W"
                SSS_PrgNm = ps_rptnm_GNKPR13

            Case ps_rptid_GNKPR14 '労務費・間接費配賦総括表
                SSS_TblID = "C_G115W"
                SSS_PrgNm = ps_rptnm_GNKPR14

            Case ps_rptid_GNKPR16 '原価振替リスト
                SSS_TblID = "C_G117W"
                SSS_PrgNm = ps_rptnm_GNKPR16

            Case Else
                MsgBox("指定された帳票は存在しません。")
                li_Ret = 9
        End Select

        GET_RPTNM = li_Ret

    End Function

    '2019/05/21 CHG START
    '    Public Function CSV_OUTPUT(ByVal ps_FormID As String, ByVal ps_Sql As String, ByVal ps_ClmHedNm As String, ByVal ps_RowHedNm As String, ByVal ps_RowHedNm2 As String, Optional ByVal ps_FilePath As String = "") As Boolean
    '        '==========================================================================
    '        '   関数:CSV出力
    '        '   概要:引数のSQLからCSVを直接作成する
    '        '   IO  引数            値          内容
    '        '   IN  ps_FormID                   画面ID
    '        '   IN  ps_CSV_Data                 出力対象文字列
    '        '   IN  ps_FilePath                 出力ﾌｧｲﾙﾊﾟｽ
    '        '
    '        '   戻り値              値          内容
    '        '                       True        正常終了
    '        '                       False       異常終了
    '        '
    '        '   作成・更新      担当者      変更内容
    '        '   2009/12/18      大矢        新規作成
    '        '
    '        '==========================================================================
    '        '--------------------------------------------------------------------------
    '        '変数の定義
    '        '--------------------------------------------------------------------------
    '        Dim li_MsgRtn As Short 'MsgBoxの戻り値
    '        Dim ls_CSV_Data As String
    '        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody As U_Ody
    '        Dim i As Short

    '        'UPGRADE_ISSUE: OraFields オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '        '2019/05/13 CHG START
    '        'Dim OraFields As OraFields
    '        Dim OraFields As Object
    '        '2019/05/13 CHG E N D

    '        On Error GoTo ERR_END

    '        '--------------------------------------------------------------------------
    '        'エラートラップ宣言
    '        '--------------------------------------------------------------------------

    '        '--------------------------------------------------------------------------
    '        '処理開始
    '        '--------------------------------------------------------------------------
    '        '//接続
    '        ' < OT-00XX> UPD STR
    '        '            If F_Ora_Connect(gv_Oss, gv_Odb, ps_DatabaseName, ps_UserName, ps_Password) = False Then
    '        '                GoTo ERR_END
    '        '            End If
    '        'UPGRADE_WARNING: CSV_OUTPUT に変換されていないステートメントがあります。ソース コードを確認してください。
    '        ' < OT-00XX> UPD END

    '        '---戻り値設定---'
    '        CSV_OUTPUT = False

    '        'ﾀﾞｲﾅｾｯﾄ初期化()
    '        ' < OT-00XX> UPD STR
    '        '''            Usr_Ody.Obj_Ody = Nothing
    '        '            'SQL実行()
    '        '            Call CF_Ora_CreateDyn(gv_Odb, Usr_Ody, ps_Sql)
    '        '''            lo_Dynaset = OraDatabase.CreateDynaset(ps_Sql, 2)
    '        'UPGRADE_WARNING: オブジェクト ODatabase.DbCreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Odynaset = ODatabase.DbCreateDynaset(ps_Sql, ORADYN_ORAMODE)

    '        ' < OT-00XX> UPD END

    '        '---0件時はｴﾗｰﾒｯｾｰｼﾞ表示---'
    '        'UPGRADE_WARNING: オブジェクト Odynaset.RecordCount の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        If Odynaset.RecordCount = 0 Then
    '            '2015/10/29追記　FWEST
    '            If Len(Trim(ps_FilePath)) = 0 Then
    '                li_MsgRtn = MsgBox("CSV出力ﾃﾞｰﾀが存在しませんでした。", MsgBoxStyle.OkOnly, "原価管理システム")
    '            End If
    '            '---戻り値設定---'
    '            CSV_OUTPUT = True
    '            Exit Function
    '        Else

    '            '原価差額分析表のみ列ヘッダを2行出力する
    '            If SSS_PrtID = ps_rptid_GNKPR13 Then
    '                '---列ﾍｯﾀﾞｰ情報設定---'
    '                If Len(Trim(ps_RowHedNm2)) <> 0 Then
    '                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm2 & """" & vbCrLf)
    '                End If
    '            End If

    '            '---列ﾍｯﾀﾞｰ情報設定---'
    '            If Len(Trim(ps_ClmHedNm)) <> 0 Then
    '                ls_CSV_Data = ls_CSV_Data & ("""" & ps_ClmHedNm & """" & vbCrLf)
    '            End If

    '            '読込
    '            ' < OT-00XX> UPD STR
    '            '*D*Usr_Ody.Obj_Ody.movefirst
    '            '*D*OraFields = Usr_Ody
    '            'UPGRADE_WARNING: オブジェクト Odynaset.MoveFirst の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            Odynaset.MoveFirst()

    '            'UPGRADE_WARNING: オブジェクト Odynaset.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            OraFields = Odynaset.Fields

    '            'UPGRADE_WARNING: オブジェクト Odynaset.EOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            Do Until Odynaset.EOF

    '                '---行ﾍｯﾀﾞｰ情報設定---'
    '                If Len(Trim(ps_RowHedNm)) <> 0 Then
    '                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm & """,")
    '                End If

    '                'UPGRADE_WARNING: オブジェクト OraFields().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                ls_CSV_Data = ls_CSV_Data & CStr(OraFields(0).Value) & vbCrLf

    '                '                    '---項目件数分処理実施---'
    '                '                    For i = 0 To Odynaset.Fields.Count - 1
    '                '                        '---ﾃﾞｰﾀ取得---'
    '                '                        '*D*ls_CSV_Data = ls_CSV_Data & ("""" & CF_Ora_GetDyn(Usr_Ody, i, "") & "")
    '                '
    '                '                        If i >= Odynaset.Fields.Count - 1 Then
    '                '                            '---最終項目の場合改行---'
    '                '                            ls_CSV_Data = ls_CSV_Data & ("""" & vbCrLf)
    '                '                        Else
    '                '                            ls_CSV_Data = ls_CSV_Data & (""",")
    '                '                        End If
    '                '                    Next
    '                'UPGRADE_WARNING: オブジェクト Odynaset.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                Odynaset.MoveNext()
    '            Loop
    '        End If
    '        ' < OT-00XX> UPD END

    '        'CSV出力
    '        If CSV_OUTPUT2(ps_FormID, ls_CSV_Data, ps_FilePath) = False Then Exit Function


    '        '---戻り値設定---'
    '        CSV_OUTPUT = True

    '        Exit Function

    '        '--------------------------------------------------------------------------
    '        'エラートラップルーチン
    '        '--------------------------------------------------------------------------
    'ERR_END:
    '        li_MsgRtn = MsgBox("CSV出力関数エラー" & vbCrLf, MsgBoxStyle.Critical, "エラー")

    '    End Function
    Public Function CSV_OUTPUT(ByVal ps_FormID As String, ByVal ps_Sql As String, ByVal ps_ClmHedNm As String, ByVal ps_RowHedNm As String, ByVal ps_RowHedNm2 As String, Optional ByVal ps_FilePath As String = "") As Boolean
        '==========================================================================
        '   関数:CSV出力
        '   概要:引数のSQLからCSVを直接作成する
        '   IO  引数            値          内容
        '   IN  ps_FormID                   画面ID
        '   IN  ps_CSV_Data                 出力対象文字列
        '   IN  ps_FilePath                 出力ﾌｧｲﾙﾊﾟｽ
        '
        '   戻り値              値          内容
        '                       True        正常終了
        '                       False       異常終了
        '
        '   作成・更新      担当者      変更内容
        '   2009/12/18      大矢        新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Short 'MsgBoxの戻り値
        Dim ls_CSV_Data As String

        On Error GoTo ERR_END
        'add test 20190822 kuwa
        'MsgBox(ps_FilePath)
        'ps_FilePath = ""
        'MsgBox(ps_FilePath)
        'add end 20190822 kuwa
        '--------------------------------------------------------------------------
        '処理開始
        '--------------------------------------------------------------------------
        '//接続
        DB_START_GENKA()

        '---戻り値設定---'
        CSV_OUTPUT = False

        'データ取得
        Dim dt As DataTable = DB_GetTable(ps_Sql, CON_GENKA)

        '---0件時はｴﾗｰﾒｯｾｰｼﾞ表示---'
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            If Len(Trim(ps_FilePath)) = 0 Then
                li_MsgRtn = MsgBox("CSV出力ﾃﾞｰﾀが存在しませんでした。", MsgBoxStyle.OkOnly, "原価管理システム")
            End If
            '---戻り値設定---'
            CSV_OUTPUT = True
            Exit Function
        Else

            '原価差額分析表のみ列ヘッダを2行出力する
            If SSS_PrtID = ps_rptid_GNKPR13 Then
                '---列ﾍｯﾀﾞｰ情報設定---'
                If Len(Trim(ps_RowHedNm2)) <> 0 Then
                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm2 & """" & vbCrLf)
                End If
            End If

            '---列ﾍｯﾀﾞｰ情報設定---'
            If Len(Trim(ps_ClmHedNm)) <> 0 Then
                ls_CSV_Data = ls_CSV_Data & ("""" & ps_ClmHedNm & """" & vbCrLf)
            End If

            '読込
            For cnt As Integer = 0 To dt.Rows.Count - 1
                If Len(Trim(ps_RowHedNm)) <> 0 Then
                    ls_CSV_Data = ls_CSV_Data & ("""" & ps_RowHedNm & """,")
                End If

                ls_CSV_Data = ls_CSV_Data & CStr(dt.Rows(cnt)("data")) & vbCrLf

            Next
        End If

        'CSV出力
        If CSV_OUTPUT2(ps_FormID, ls_CSV_Data, ps_FilePath) = False Then Exit Function


        '---戻り値設定---'
        CSV_OUTPUT = True

        Exit Function

        '--------------------------------------------------------------------------
        'エラートラップルーチン
        '--------------------------------------------------------------------------
ERR_END:
        li_MsgRtn = MsgBox("CSV出力関数エラー" & vbCrLf, MsgBoxStyle.Critical, "エラー")

    End Function
    '2019/05/21 CHG E N D

    ''' <summary>
    ''' CSV出力(文字列から出力)
    Public Function CSV_OUTPUT2(ByVal ps_FormID As String, ByVal ps_CSV_Data As String, Optional ByVal ps_FilePath As String = "") As Boolean
        Dim cdlCancel As Object
        '==========================================================================
        '   関数:CSV出力
        '   概要:引数の文字列からCSVを直接作成する
        '   IO  引数            値          内容
        '   IN  ps_FormID                   画面ID
        '   IN  ps_CSV_Data                 出力対象文字列(コンマ区切りや改行等、整形済みであること)
        '   IN  ps_FilePath                 出力ﾌｧｲﾙﾊﾟｽ(省略時はファイル指定ダイアログを表示します)
        '
        '   戻り値              値          内容
        '                       True        正常終了
        '                       False       異常終了
        '
        '   作成・更新      担当者      変更内容
        '   2009/12/21      大矢        新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Short 'MsgBoxの戻り値
        Dim ls_CSV_Data As String
        Dim ls_FilePath As String '出力ﾌｧｲﾙﾊﾟｽ
        Dim iFno As Short
        Dim li_ExeMsgRtn As Short

        '        Dim lo_SW As System.IO.StreamWriter

        '--------------------------------------------------------------------------
        '処理開始
        '--------------------------------------------------------------------------
        '---戻り値設定---'
        CSV_OUTPUT2 = False

        '2019/05/13 ADD START
        frmRptViewer.CmDlg = New OpenFileDialog()
        '2019/05/13 ADD E N D

        '------------------------------
        '保存ﾌｧｲﾙ名取得
        '------------------------------
        '---引数ﾌｧｲﾙﾊﾟｽﾁｪｯｸ---'
        ls_FilePath = ps_FilePath
        'ﾌｧｲﾙﾊﾟｽが無ければ、ここでﾌｧｲﾙﾊﾟｽを聞く
        If Len(Trim(ls_FilePath)) = 0 Then

            'CancelErrorの初期化
            'UPGRADE_WARNING: オブジェクト frmRptViewer.CmDlg.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/5/13 CHG START
            'frmRptViewer.CmDlg.CancelError = True
            frmRptViewer.CmDlg.CheckFileExists = True
            '2019/05/13 CHG E N D

            On Error Resume Next

            'フィルタ設定
            ' === ST-0038 ===
            '*D*frmRptViewer.CmDlg.InitDir = "V:\"
            ' === ST-0038 ===
            'UPGRADE_WARNING: オブジェクト frmRptViewer.CmDlg.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            frmRptViewer.CmDlg.Filter = "csv ファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"

            '2019/05/13 CHG 
            ''ダイアログを表示する
            ''UPGRADE_WARNING: オブジェクト frmRptViewer.CmDlg.ShowSave の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'frmRptViewer.CmDlg.ShowSave()

            ''キャンセルのエラーイベントを取得した場合
            ''UPGRADE_WARNING: オブジェクト cdlCancel の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'If Err.Number = cdlCancel Then
            '	Exit Function
            'End If
            '2019/05/21 CHG START
            'If frmRptViewer.CmDlg.ShowDialog() <> DialogResult.Cancel Then
            '    Exit Function
            'End If
            ''2019/05/13 CHG E N D

            ''UPGRADE_WARNING: オブジェクト frmRptViewer.CmDlg.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'ls_FilePath = frmRptViewer.CmDlg.FileName
            'If Trim(ls_FilePath) = CStr(VariantType.Null) Then
            '    Exit Function
            'End If
            ls_FilePath = "C:\Users\nb003674.CONTEC\Desktop"
            '2019/05/21 CHG E N D

            'add test 20190822 kuwa
            'ps_FilePathに値が入っていなければ(ﾌｧｲﾙﾊﾟｽが無ければ)下記のパスにtest.csvという名称でcsvを出力
            ls_FilePath = "C:\Users\nb003380.CONTEC\Desktop\test.csv"
            ls_FilePath = "C:\Users\CIS03\Desktop\test.csv"

            'message 20190822 フォームを閉じた際にbinフォルダに3.csvという名前でcsvが出力される不具合あり
            'add test 20190822 kuwa

        End If

        '書き込む値のセット
        ls_CSV_Data = ps_CSV_Data

        'ファイルオープン
        iFno = FreeFile()
        MsgBox("csv") 'add test
        FileOpen(iFno, ls_FilePath, OpenMode.Output)
        MsgBox("csv2") 'add test
        'CSV書込
        PrintLine(iFno, ls_CSV_Data)

        'ファイルクローズ
        FileClose(iFno)


        ''            'ﾄﾗﾝｻﾞｸｼｮﾝの開始
        ''            OraSession.BeginTrans()
        ''
        ''            Try
        ''                '------------------------------
        ''                'CSV出力履歴管理テーブル追加
        ''                '------------------------------
        ''                'SQL文作成
        ''                EmpQuery = ""
        ''                EmpQuery = EmpQuery & " insert into C_Z025T ( "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_DDT, "
        ''                EmpQuery = EmpQuery & "     C_EMP_CD, "
        ''                EmpQuery = EmpQuery & "     C_PG_ID, "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_DESC, "
        ''                EmpQuery = EmpQuery & "     C_EXP_CSV_SQL "
        ''                EmpQuery = EmpQuery & " ) values ( "
        ''                EmpQuery = EmpQuery & " '" & Format(Now(), "yyyyMMddHHmmss") & "', "        'CSV出力日時
        ''                EmpQuery = EmpQuery & " '" & ps_PRONESUserName & "', "                      '従業員ｺｰﾄﾞ
        ''                EmpQuery = EmpQuery & " '" & ps_FormID & "', "                              '画面ID
        ''                EmpQuery = EmpQuery & " '" & ls_FilePath & "', "                             '出力CSVﾌｧｲﾙ名
        ''                EmpQuery = EmpQuery & " '画面明細出力' "                                    'CSV出力SQL文
        ''                EmpQuery = EmpQuery & " ) "
        ''                'SQL実行
        ''                OraDatabase.ExecuteSQL (EmpQuery)
        ''
        ''            Catch ex As Exception
        ''                'ﾛｰﾙﾊﾞｯｸ
        ''                OraSession.Rollback()
        ''                If pb_YakanFlg = False Then
        ''                    li_MsgRtn = MsgBox("CSV出力履歴更新時エラー(Oracle・Insert)" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        ''                Else
        ''                    WRITE_LOG ("CSV出力履歴更新時エラー(Oracle・Insert)" & " , " & ex.Message.ToString)
        ''                End If
        ''                Exit Function
        ''            End Try

        ''            'ｺﾐｯﾄ
        ''            OraSession.CommitTrans()

        '2015/10/29追記　FWEST
        If Len(Trim(ls_FilePath)) = 0 Then
            '完了メッセージ出力フラグがTrueの場合かつ夜間フラグがFalseの場合はメッセージ表示
            li_MsgRtn = MsgBox("CSV出力が完了しました。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "原価管理システム") 'CSV出力が完了しました。
        End If

        '---戻り値設定---'
        CSV_OUTPUT2 = True

        Exit Function

        '--------------------------------------------------------------------------
        'エラートラップルーチン
        '--------------------------------------------------------------------------


ERR_END:
        li_MsgRtn = MsgBox("CSV出力関数エラー" & vbCrLf, MsgBoxStyle.Critical, "エラー")

    End Function



    Public Function Get_Sql(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        Dim bolRet As Boolean

        On Error GoTo ERR_END


        Get_Sql = False

        'ＳＱＬ・ヘッダの取得
        Select Case SSS_PrtID

            Case ps_rptid_GNKPR01 '売上原価対照表（経理調整後）(全社）
                bolRet = GET_SQL_売上原価対照表_経理調整後(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR02 '売上原価対照表(全社）
                bolRet = GET_SQL_売上原価対照表_全社(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR03 '売上原価対照表(本部別）
                bolRet = GET_SQL_売上原価対照表_本部別(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR04 '売上原価対照表(取引先別）
                bolRet = GET_SQL_売上原価対照表_取引先別(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR05 '売上時原価明細表
                bolRet = GET_SQL_売上時原価明細表(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR06 '追加原価明細表
                bolRet = GET_SQL_追加原価明細表(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR07 '仕掛品明細表
                bolRet = GET_SQL_仕掛品明細表(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR08 '製造原価元帳
                bolRet = GET_SQL_製造原価元帳(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR09 '見込品元帳
                bolRet = GET_SQL_見込品元帳(sSql, sColHeader, sRowHeader)

                '        Case ps_rptid_GENPR10           '棚札
                '            bolRet = GET_SQL_棚札(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR10 '仕掛品チェックリスト
                bolRet = GET_SQL_仕掛品チェックリスト(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR18 '原価分析表
                bolRet = GET_SQL_原価分析表(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR12 '工数集計総括表
                bolRet = GET_SQL_工数集計総括表(sSql, sColHeader, sRowHeader)

            Case ps_rptid_GNKPR13 '原価差額分析表
                bolRet = GET_SQL_原価差額分析表(sSql, sColHeader, sRowHeader, sColHeader2)

            Case ps_rptid_GNKPR14 '労務費・間接費配賦総括表
                bolRet = GET_SQL_労務費間接費配賦総括表(sSql, sColHeader, sRowHeader, sColHeader2)

            Case ps_rptid_GNKPR16 '原価振替リスト
                bolRet = GET_SQL_原価振替リスト(sSql, sColHeader, sRowHeader, sColHeader2)

            Case Else
                MsgBox("指定された帳票は存在しません。")
        End Select


        Get_Sql = bolRet

        Exit Function

ERR_END:
        'エラー

        Exit Function
    End Function

    '==========================================================================
    '   関数:GET_SQL_売上原価対照表_経理調整後
    '   概要:売上原価対象表（経理調整後）（全社）のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_売上原価対照表_経理調整後(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_売上原価対照表_経理調整後 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '====< IT-0037 > ADD STR ====
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        '====< IT-0037 > ADD END ====
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""


        '行ヘッダ
        sColHeader = sColHeader & "行名称"","""
        sColHeader = sColHeader & "売上金額(当月)"","""
        sColHeader = sColHeader & "売上金額(累計)"","""
        'sColHeader = sColHeader & "仕切原価(当月)"","""
        'sColHeader = sColHeader & "仕切原価(累計)"","""
        sColHeader = sColHeader & "計画原価(当月)"","""
        sColHeader = sColHeader & "計画原価(累計)"","""
        sColHeader = sColHeader & "売上時原価(当月)"","""
        sColHeader = sColHeader & "売上時原価(累計)"","""
        sColHeader = sColHeader & "追加原価(当月)"","""
        sColHeader = sColHeader & "追加原価(累計)"","""
        sColHeader = sColHeader & "売上原価計(当月)"","""
        sColHeader = sColHeader & "売上原価計(累計)"","""
        sColHeader = sColHeader & "売差額(当月)"","""
        sColHeader = sColHeader & "売差額(累計)"","""
        sColHeader = sColHeader & "売差率(当月)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差率(累計)"","""
        sColHeader = sColHeader & "売差率(累計)"
        '2010/05/14 UPD END
        GET_SQL_売上原価対照表_経理調整後 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_売上原価対照表_全社
    '   概要:売上原価対象表（全社）のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_売上原価対照表_全社(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_売上原価対照表_全社 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '====< IT-0037 > ADD STR ====
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        '====< IT-0037 > ADD END ====
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01


        '列ヘッダ
        sColHeader = ""


        '行ヘッダ
        sColHeader = sColHeader & "行名称"","""
        sColHeader = sColHeader & "売上金額(当月)"","""
        sColHeader = sColHeader & "売上金額(累計)"","""
        'sColHeader = sColHeader & "仕切原価(当月)"","""
        'sColHeader = sColHeader & "仕切原価(累計)"","""
        sColHeader = sColHeader & "計画原価(当月)"","""
        sColHeader = sColHeader & "計画原価(累計)"","""
        sColHeader = sColHeader & "売上時原価(当月)"","""
        sColHeader = sColHeader & "売上時原価(累計)"","""
        sColHeader = sColHeader & "追加原価(当月)"","""
        sColHeader = sColHeader & "追加原価(累計)"","""
        sColHeader = sColHeader & "売上原価計(当月)"","""
        sColHeader = sColHeader & "売上原価計(累計)"","""
        sColHeader = sColHeader & "売差額(当月)"","""
        sColHeader = sColHeader & "売差額(累計)"","""
        sColHeader = sColHeader & "売差率(当月)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差率(累計)" & vbCrLf
        sColHeader = sColHeader & "売差率(累計)"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_売上原価対照表_全社 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_売上原価対照表_本部別
    '   概要:売上原価対象表（事業部）のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_売上原価対照表_本部別(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_売上原価対照表_本部別 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_JIGYO_CD             || '"",""' || "
        sSql = sSql & "C_JIGYO_DESC           || '"",""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        sSql = sSql & "   AND " & "C_GYO_SUB_NO = '1' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "事業所コード"","""
        sColHeader = sColHeader & "事業所名称"","""
        sColHeader = sColHeader & "行名称"","""
        sColHeader = sColHeader & "売上金額(当月)"","""
        sColHeader = sColHeader & "売上金額(累計)"","""
        'sColHeader = sColHeader & "仕切原価(当月)"","""
        'sColHeader = sColHeader & "仕切原価(累計)"","""
        sColHeader = sColHeader & "計画原価(当月)"","""
        sColHeader = sColHeader & "計画原価(累計)"","""
        sColHeader = sColHeader & "売上時原価(当月)"","""
        sColHeader = sColHeader & "売上時原価(累計)"","""
        sColHeader = sColHeader & "追加原価(当月)"","""
        sColHeader = sColHeader & "追加原価(累計)"","""
        sColHeader = sColHeader & "売上原価計(当月)"","""
        sColHeader = sColHeader & "売上原価計(累計)"","""
        sColHeader = sColHeader & "売差額(当月)"","""
        sColHeader = sColHeader & "売差額(累計)"","""
        sColHeader = sColHeader & "売差率(当月)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差率(累計)" & vbCrLf
        sColHeader = sColHeader & "売差率(累計)"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_売上原価対照表_本部別 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_売上原価対照表_取引先別
    '   概要:売上原価対象表（取引先別）のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_売上原価対照表_取引先別(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_売上原価対照表_取引先別 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_GYO_DESC             || '"",""' || "
        sSql = sSql & "C_SALES_AMT            || '"",""' || "
        sSql = sSql & "C_SALES_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT           || '"",""' || "
        sSql = sSql & "C_SIKIRI_AMT_SUM       || '"",""' || "
        sSql = sSql & "C_SALES_CST            || '"",""' || "
        sSql = sSql & "C_SALES_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ADD_CST              || '"",""' || "
        sSql = sSql & "C_ADD_CST_SUM          || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL      || '"",""' || "
        sSql = sSql & "C_SALES_CST_TOTAL_SUM  || '"",""' || "
        sSql = sSql & "C_BAISA_AMT            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_BAISA_RATE           || '"",""' || "
        sSql = sSql & "C_BAISA_RATE_SUM       || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = sColHeader & "行名称"","""
        sColHeader = sColHeader & "売上金額(当月)"","""
        sColHeader = sColHeader & "売上金額(累計)"","""
        'sColHeader = sColHeader & "仕切原価(当月)"","""
        'sColHeader = sColHeader & "仕切原価(累計)"","""
        sColHeader = sColHeader & "計画原価(当月)"","""
        sColHeader = sColHeader & "計画原価(累計)"","""
        sColHeader = sColHeader & "売上時原価(当月)"","""
        sColHeader = sColHeader & "売上時原価(累計)"","""
        sColHeader = sColHeader & "追加原価(当月)"","""
        sColHeader = sColHeader & "追加原価(累計)"","""
        sColHeader = sColHeader & "売上原価計(当月)"","""
        sColHeader = sColHeader & "売上原価計(累計)"","""
        sColHeader = sColHeader & "売差額(当月)"","""
        sColHeader = sColHeader & "売差額(累計)"","""
        sColHeader = sColHeader & "売差率(当月)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差率(累計)"","""
        sColHeader = sColHeader & "売差率(累計)"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_売上原価対照表_取引先別 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_売上時原価明細表
    '   概要:売上時原価明細表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '   2014/10/22      RS)石本     システム統合により項目を変更
    '
    '==========================================================================
    Private Function GET_SQL_売上時原価明細表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_売上時原価明細表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'|| '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 売上時原価明細表 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS      || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC     || '"",""' || "
        '=== < ST-0152 > ADD STR
        sSql = sSql & "C_SINKO_FLG        || '"",""' || "
        '=== < ST-0152 > ADD END
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        '<2014/10/22 UPD STR>
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_CUS_CD           || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC       || '"",""' || "
        sSql = sSql & "C_CUS_DESC         || '"",""' || "
        sSql = sSql & "C_SALES_AMT        || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        'sSql = sSql + "C_BAISA_RATE       || '"",""' || "
        sSql = sSql & "C_PLAN_BAISA_RATE  || '"",""' || "
        sSql = sSql & "C_JSK_BAISA_RATE   || '"",""' || "
        sSql = sSql & "C_GENKA_FLG        || '"" ' "
        'sSql = sSql + "C_BAISA_FLG        || '"" ' "
        '<2014/10/22 UPD END>
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "製番体系区分"","""
        sColHeader = sColHeader & "製番体系名称"","""
        '=== < ST-0152 > ADD STR
        sColHeader = sColHeader & "進行基準フラグ"","""
        '=== < ST-0152 > ADD END
        sColHeader = sColHeader & "製番"","""
        '<2014/10/22 UPD STR>
        sColHeader = sColHeader & "製番名称"","""
        sColHeader = sColHeader & "得意先CD"","""
        sColHeader = sColHeader & "得意先名"","""
        '*D*sColHeader = sColHeader & "納入先名"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "得意先名称"","""
        'sColHeader = sColHeader & "品名"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "売上金額"","""
        '*D*sColHeader = sColHeader & "仕切原価"","""
        sColHeader = sColHeader & "計画原価"","""
        sColHeader = sColHeader & "材料費"","""
        sColHeader = sColHeader & "経費"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "労務費"","""
        sColHeader = sColHeader & "労務・間接費"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "振替"","""
        sColHeader = sColHeader & "合計"","""
        '*D*sColHeader = sColHeader & "売差"","""
        sColHeader = sColHeader & "計画売差"","""
        sColHeader = sColHeader & "実績売差"","""
        sColHeader = sColHeader & "原価残フラグ"
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差フラグ"","""
        '*D*sColHeader = sColHeader & "売差フラグ"
        '2010/05/14 UPD END
        '<2014/10/22 UPD END>

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_売上時原価明細表 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_追加原価明細表
    '   概要:追加原価明細表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '   2014/10/21      RS)石本     システム統合により項目を変更
    '
    '==========================================================================
    Private Function GET_SQL_追加原価明細表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_追加原価明細表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'                                                    || '"",""' || "
        sSql = sSql & "C_CRT_DATE                                                             || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 追加原価明細表 【' || C_CO_DESC || '】'    || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS                                                          || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC                                                         || '"",""' || "
        sSql = sSql & "C_SEIBAN                                                               || '"",""' || "
        '<2014/10/21 ADD STR>
        sSql = sSql & "C_SEIBAN_DESC                                                          || '"",""' || "
        sSql = sSql & "C_CUS_CD                                                               || '"",""' || "
        sSql = sSql & "C_CUS_DESC                                                             || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC                                                           || '"",""' || "
        'sSql = sSql + "C_CUS_DESC                                                             || '"",""' || "
        sSql = sSql & "C_SALES_AMT                                                            || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT                                                         || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST                                                           || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM                                                       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST                                                            || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM                                                        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST                                                     || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM                                                 || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST                                                          || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM                                                      || '"",""' || "
        'sSql = sSql + "C_ADD_CST_TOU_TOTAL                                                    || '"",""' || "
        'sSql = sSql + "C_ADD_CST_RUI_TOTAL                                                    || '"",""' || "
        sSql = sSql & "C_ADD_CST_TOTAL                                                        || '"",""' || "
        sSql = sSql & "C_ADD_CST_TOTAL_SUM                                                    || '"",""' || "
        sSql = sSql & "C_SALES_CST                                                            || '"",""' || "
        sSql = sSql & "C_TOTAL_CST                                                            || '"",""' || "
        sSql = sSql & "C_BAISA_AMT                                                            || '"",""' || "
        sSql = sSql & "C_BAISA_RATE                                                           || '"",""' || "
        sSql = sSql & "C_SALES_YM                                                             || '"",""' || "
        'sSql = sSql + "C_BAISA_RATE                                                           || '"",""' || "
        sSql = sSql & "C_BAISA_FLG                                                            || '"" ' "
        '<2014/10/21 ADD END>
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "製番体系区分"","""
        sColHeader = sColHeader & "製番体系名称"","""
        sColHeader = sColHeader & "製番"","""
        '<2014/10/21 ADD STR>
        sColHeader = sColHeader & "製番名称"","""
        sColHeader = sColHeader & "得意先コード"","""
        sColHeader = sColHeader & "得意先名"","""
        'sColHeader = sColHeader & "納入先名"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "得意先名称"","""
        'sColHeader = sColHeader & "品名"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "売上金額"","""
        sColHeader = sColHeader & "計画原価"","""
        sColHeader = sColHeader & "材料費"","""
        sColHeader = sColHeader & "材料費（累計）"","""
        sColHeader = sColHeader & "経費"","""
        sColHeader = sColHeader & "経費（累計）"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "労務費"","""
        sColHeader = sColHeader & "労務・間接費"","""
        sColHeader = sColHeader & "労務・間接費（累計）"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "振替"","""
        sColHeader = sColHeader & "振替（累計）"","""
        'sColHeader = sColHeader & "当月"","""
        'sColHeader = sColHeader & "累計"","""
        sColHeader = sColHeader & "当月発生追加原価計"","""
        sColHeader = sColHeader & "追加原価累計"","""
        sColHeader = sColHeader & "売上時原価金額"","""
        sColHeader = sColHeader & "原価合計"","""
        sColHeader = sColHeader & "売差金額"","""
        'sColHeader = sColHeader & "売上年月"","""
        'sColHeader = sColHeader & "売差"","""
        sColHeader = sColHeader & "売差率"","""
        sColHeader = sColHeader & "売上年月"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "売差フラグ"","""
        sColHeader = sColHeader & "売差フラグ"
        '2010/05/14 UPD END
        '<2014/10/21 ADD END>

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_追加原価明細表 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_仕掛品明細表
    '   概要:仕掛品明細表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '   2014/10/21      RS)石本     システム統合により項目を変更
    '
    '==========================================================================
    Private Function GET_SQL_仕掛品明細表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_仕掛品明細表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 仕掛品明細表 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS      || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC     || '"",""' || "
        '=== < ST-0152 > UPD STR
        sSql = sSql & "C_SINKO_FLG        || '"",""' || "
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        '<2014/10/21 ADD STR>
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_CUS_CD           || '"",""' || "
        '=== < ST-0152 > UPD END
        '*D* sSql = sSql & " C_SEIBAN "
        'sSql = sSql & "C_NONYU_DESC       || '"",""' || "
        sSql = sSql & "C_CUS_DESC         || '"",""' || "
        sSql = sSql & "C_KEIYAKU_AMT      || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM   || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM    || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM  || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM    || '"",""' || "
        sSql = sSql & "C_NOUKI_DATE       || '"" ' "
        'sSql = sSql & "C_DEL_FLG          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "製番体系区分"","""
        sColHeader = sColHeader & "製番体系名称"","""
        '=== < ST-0152 > ADD STR
        sColHeader = sColHeader & "進行基準フラグ"","""
        '=== < ST-0152 > ADD END
        sColHeader = sColHeader & "製番"","""
        '<2014/10/21 CHG STR>
        sColHeader = sColHeader & "製番名称"","""
        sColHeader = sColHeader & "得意先コード"","""
        sColHeader = sColHeader & "得意先名"","""
        'sColHeader = sColHeader & "納入先名"","""
        '< IT2-00XX > UPD STR
        '*D*sColHeader = sColHeader & "得意先名称"","""
        'sColHeader = sColHeader & "品名"","""
        '< IT2-00XX > UPD END
        sColHeader = sColHeader & "受注金額"","""
        sColHeader = sColHeader & "仕切金額"","""
        sColHeader = sColHeader & "材料費"","""
        sColHeader = sColHeader & "材料費（累計）"","""
        sColHeader = sColHeader & "経費"","""
        sColHeader = sColHeader & "経費（累計）"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "労務費"","""
        sColHeader = sColHeader & "労務・間接費"","""
        sColHeader = sColHeader & "労務・間接費（累計）"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "振替"","""
        sColHeader = sColHeader & "振替（累計）"","""
        sColHeader = sColHeader & "合計"","""
        sColHeader = sColHeader & "合計（累計）"","""
        sColHeader = sColHeader & "納期"
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "取消フラグ" & vbCrLf
        'sColHeader = sColHeader & "取消フラグ"
        '2010/05/14 UPD END
        '<2014/10/21 CHG END>

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_仕掛品明細表 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_製造原価元帳
    '   概要:製造原価元帳のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '   2014/10/22      RS)石本     システム統合により項目を変更
    '
    '==========================================================================
    Private Function GET_SQL_製造原価元帳(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_製造原価元帳 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'                                               || '"",""' || "
        '<2015/01/09 UPD STR>
        sSql = sSql & "C_SEQ_10                                                          || '"",""' || "
        '<2015/01/09 UPD STR>
        sSql = sSql & "C_CRT_DATE                                                        || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 製造原価元帳 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_SEI_TAI_CLS                                                     || '"",""' || "
        sSql = sSql & "C_SEI_TAI_DESC                                                    || '"",""' || "
        sSql = sSql & "C_SEIBAN                                                          || '"",""' || "
        '<2014/10/22 UPD STR>
        sSql = sSql & "C_SEIBAN_DESC                                                     || '"",""' || "
        sSql = sSql & "C_COMMENT20        　                                             || '"",""' || "
        'sSql = sSql + "C_NONYU_DESC                                                      || '"",""' || "
        'sSql = sSql + "C_ITEM_DESC                                                       || '"",""' || "
        '<2014/10/22 UPD END>
        sSql = sSql & "C_DEL                                                             || '"",""' || "
        sSql = sSql & "C_URI_KAN                                                         || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT                                                    || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST                                                      || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM                                                  || '"",""' || "
        sSql = sSql & "C_KEIHI_CST                                                       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM                                                   || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST                                                || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM                                            || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST                                                     || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM                                                 || '"",""' || "
        sSql = sSql & "C_TOTAL_CST                                                       || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM                                                   || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        '<2015/01/09 UPD STR>
        sSql = sSql & " Order By C_SEI_TAI_CLS,C_SEIBAN,C_SEQ_10"
        '<2015/01/09 UPD END>


        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "SEQ"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "製番体系区分"","""
        sColHeader = sColHeader & "製番体系名称"","""
        sColHeader = sColHeader & "製番"","""
        '<2014/10/22 UPD STR>
        sColHeader = sColHeader & "製番名称"","""
        sColHeader = sColHeader & "備考"","""
        'sColHeader = sColHeader & "納入先名"","""
        'sColHeader = sColHeader & "品名"","""
        sColHeader = sColHeader & "納期"","""
        '*D*sColHeader = sColHeader & "売上・完成"","""
        sColHeader = sColHeader & "完了・完成"","""
        '<2014/10/22 UPD END>
        '==== < ST-0134 > UPD STR =====
        '*D*sColHeader = sColHeader & "契約金額"","""
        '=== < 統合対応 > 2015/03/25 UPD STR ===
        '*D*sColHeader = sColHeader & "仕切・予定"","""
        sColHeader = sColHeader & "予定原価(標準価格)"","""
        '=== < 統合対応 > 2015/03/25 UPD END ===
        '==== < ST-0134 > UPD END =====
        sColHeader = sColHeader & "材料費(当月)"","""
        sColHeader = sColHeader & "材料費(累計)"","""
        sColHeader = sColHeader & "経費(当月)"","""
        sColHeader = sColHeader & "経費(累計)"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "労務費"","""
        '*D* sColHeader = sColHeader & "労務費(累計)"","""
        sColHeader = sColHeader & "労務・間接費"","""
        sColHeader = sColHeader & "労務・間接費(累計)"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "振替(当月)"","""
        sColHeader = sColHeader & "振替(累計)"","""
        sColHeader = sColHeader & "合計(当月)"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "合計(累計)" & vbCrLf
        sColHeader = sColHeader & "合計(累計)"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_製造原価元帳 = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   関数:GET_SQL_見込品元帳
    '   概要:見込品元帳のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '   2014/10/22      RS)石本     システム統合により項目を変更
    '
    '==========================================================================
    Private Function GET_SQL_見込品元帳(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_見込品元帳 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'    || '"",""' || "
        sSql = sSql & "C_CRT_DATE        || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 見込品元帳 【' || C_CO_DESC || '】' || '"",""' || "
        '<2014/10/22 ADD STR>
        sSql = sSql & "C_SEIHIN               || '"",""' || "
        sSql = sSql & "C_SEIBAN               || '"",""' || "
        sSql = sSql & "C_ITEM_CD              || '"",""' || "
        sSql = sSql & "C_ITEM_DESC            || '"",""' || "
        sSql = sSql & "C_COM_DATE             || '"",""' || "
        sSql = sSql & "C_DEL                  || '"",""' || "
        sSql = sSql & "C_COM_QTY              || '"",""' || "
        '<2014/10/22 ADD END>
        sSql = sSql & "C_PO_QTY               || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST           || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST_SUM       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST            || '"",""' || "
        sSql = sSql & "C_KEIHI_CST_SUM        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST     || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST_SUM || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST          || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST_SUM      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST            || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM        || '"",""' || "
        sSql = sSql & "C_NYUKO_QTY            || '"",""' || "
        sSql = sSql & "C_NYUKO_QTY_SUM        || '"",""' || "
        sSql = sSql & "C_NYUKO_AMT            || '"",""' || "
        sSql = sSql & "C_NYUKO_AMT_SUM        || '"",""' || "
        sSql = sSql & "C_WIP_QTY              || '"",""' || "
        sSql = sSql & "C_WIP_AMT              || '"",""' || "
        sSql = sSql & "C_SAGAKU_SONEKI_AMT    || '"",""' || "
        sSql = sSql & "C_SONEKI_RATE          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        '<2014/10/22 ADD STR>
        sColHeader = sColHeader & "製品区分"","""
        sColHeader = sColHeader & "製番"","""
        sColHeader = sColHeader & "品番"","""
        sColHeader = sColHeader & "品名"","""
        sColHeader = sColHeader & "完成"","""
        sColHeader = sColHeader & "納期"","""
        sColHeader = sColHeader & "完成数"","""
        '<2014/10/22 ADD END>
        sColHeader = sColHeader & "手配数"","""
        sColHeader = sColHeader & "材料費"","""
        sColHeader = sColHeader & "材料費(累計)"","""
        sColHeader = sColHeader & "経費"","""
        sColHeader = sColHeader & "経費(累計)"","""
        '=== < OT-0138 > UPD STR
        '*D* sColHeader = sColHeader & "労務費"","""
        '*D* sColHeader = sColHeader & "労務費(累計)"","""
        sColHeader = sColHeader & "労務・間接費"","""
        sColHeader = sColHeader & "労務・間接費(累計)"","""
        '=== < OT-0138 > UPD END
        sColHeader = sColHeader & "振替"","""
        sColHeader = sColHeader & "振替(累計)"","""
        sColHeader = sColHeader & "原価計"","""
        sColHeader = sColHeader & "原価計(累計)"","""
        sColHeader = sColHeader & "入庫数"","""
        sColHeader = sColHeader & "入庫数(累計)"","""
        sColHeader = sColHeader & "入庫金額"","""
        sColHeader = sColHeader & "入庫金額(累計)"","""
        sColHeader = sColHeader & "仕掛数"","""
        sColHeader = sColHeader & "仕掛金額"","""
        sColHeader = sColHeader & "差額損益"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "損益率" & vbCrLf
        sColHeader = sColHeader & "損益率"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_見込品元帳 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_棚札
    '   概要:棚札のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_棚札(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_棚札 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = ""


        '列ヘッダ
        sColHeader = ""


        '行ヘッダ
        sRowHeader = ""


        GET_SQL_棚札 = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   関数:GET_SQL_仕掛品チェックリスト
    '   概要:仕掛品チェックリストのＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2014/10/22      RS)石本     新規作成
    '
    '==========================================================================
    Private Function GET_SQL_仕掛品チェックリスト(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_仕掛品チェックリスト = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE         || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 仕掛品チェックリスト 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_CLS    || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_DESC   || '"",""' || "
        sSql = sSql & "C_LISTTYPE_CD      || '"",""' || "
        sSql = sSql & "C_LISTTYPE         || '"",""' || "
        sSql = sSql & "C_SEIBAN           || '"",""' || "
        sSql = sSql & "C_SEIBAN_DESC      || '"",""' || "
        sSql = sSql & "C_DEL_DEST_DESC    || '"",""' || "
        sSql = sSql & "C_KEIYAKU_AMT      || '"",""' || "
        sSql = sSql & "C_PLAN_CST_AMT     || '"",""' || "
        sSql = sSql & "C_CANSEL_DATE      || '"",""' || "
        sSql = sSql & "C_DEL              || '"",""' || "
        sSql = sSql & "C_ZAIRYO_CST       || '"",""' || "
        sSql = sSql & "C_KEIHI_CST        || '"",""' || "
        sSql = sSql & "C_ROMU_KANSETU_CST || '"",""' || "
        sSql = sSql & "C_FURIKAE_CST      || '"",""' || "
        sSql = sSql & "C_TOTAL_CST        || '"",""' || "
        sSql = sSql & "C_CST_ST_DATE      || '"",""' || "
        sSql = sSql & "C_CST_END_DATE     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "事業部コード"","""
        sColHeader = sColHeader & "事業部名称"","""
        sColHeader = sColHeader & "種別コード"","""
        sColHeader = sColHeader & "種別"","""
        sColHeader = sColHeader & "製番"","""
        sColHeader = sColHeader & "製番名"","""
        sColHeader = sColHeader & "得意先名"","""
        '=== < 統合対応 > 2015/03/25 UPD STR ===
        '*D*sColHeader = sColHeader & "契約金額"","""
        sColHeader = sColHeader & "受注金額"","""
        '=== < 統合対応 > 2015/03/25 UPD END ===
        sColHeader = sColHeader & "計画原価"","""
        sColHeader = sColHeader & "取消日"","""
        sColHeader = sColHeader & "納期"","""
        sColHeader = sColHeader & "直接材料費"","""
        sColHeader = sColHeader & "直接経費"","""
        sColHeader = sColHeader & "労務費・間接費"","""
        sColHeader = sColHeader & "振替"","""
        sColHeader = sColHeader & "原価合計"","""
        sColHeader = sColHeader & "原価発生開始年月"","""
        sColHeader = sColHeader & "原価発生最終年月"

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_仕掛品チェックリスト = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   関数:GET_SQL_原価分析表
    '   概要:原価分析表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_原価分析表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_原価分析表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = ""
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "C_PLANT_NO                 || '"",""' || "
        sSql = sSql & "C_SO_NO                    || '"",""' || "
        sSql = sSql & "C_NONYUSAKI_DESC           || '"",""' || "
        sSql = sSql & "C_ITEM_DESC                || '"",""' || "
        sSql = sSql & "C_SO_DATE                  || '"",""' || "
        sSql = sSql & "C_MODEL                    || '"",""' || "
        sSql = sSql & "C_MODEL_BUNRUI             || '"",""' || "
        sSql = sSql & "C_SALES_DATE               || '"",""' || "
        sSql = sSql & "C_TAN_DESC                 || '"",""' || "
        sSql = sSql & "C_SEISAN_TAN_DESC          || '"",""' || "
        sSql = sSql & "C_HD_KEIYAKU_AMT           || '"",""' || "
        sSql = sSql & "C_SF_KEIYAKU_AMT           || '"",""' || "
        sSql = sSql & "C_KEI_KEIYAKU_AMT          || '"",""' || "
        sSql = sSql & "C_HD_KEI_SIK_CST           || '"",""' || "
        sSql = sSql & "C_SF_KEI_SIK_CST           || '"",""' || "
        sSql = sSql & "C_KEI_SIK_CST              || '"",""' || "
        sSql = sSql & "C_HD_KEI_MOKUHYOU_CST      || '"",""' || "
        sSql = sSql & "C_SF_KEI_MOKUHYOU_CST      || '"",""' || "
        sSql = sSql & "C_KEI_MOKUHYOU_CST         || '"",""' || "
        sSql = sSql & "C_HD_KEI_JISS_CST          || '"",""' || "
        sSql = sSql & "C_SF_KEI_JISS_CST          || '"",""' || "
        sSql = sSql & "C_KEI_JISS_CST             || '"",""' || "
        sSql = sSql & "C_HD_SIK_CST_RATE          || '"",""' || "
        sSql = sSql & "C_SF_SIK_CST_RATE          || '"",""' || "
        sSql = sSql & "C_KEI_SIK_CST_RATE         || '"",""' || "
        sSql = sSql & "C_HD_MOKUHYOU_CST_RATE     || '"",""' || "
        sSql = sSql & "C_SF_MOKUHYOU_CST_RATE     || '"",""' || "
        sSql = sSql & "C_KEI_MOKUHYOU_CST_RATE    || '"",""' || "
        sSql = sSql & "C_HD_KEI_JISS_CST_RATE     || '"",""' || "
        sSql = sSql & "C_SF_KEI_JISS_CST_RATE     || '"",""' || "
        sSql = sSql & "C_KEI_JISS_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_SEK_NAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_SEK_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEK_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEK_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_SEZ_NAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_SEZ_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_HD_KENSA_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KENSA_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KENSA_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KENSA_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_SIK_CST        || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_JISS_CST       || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_CST_RATE       || '"",""' || "
        sSql = sSql & "C_HD_KOUNYU_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_HD_SEQ_SIK_CST           || '"",""' || "
        sSql = sSql & "C_HD_SEQ_JISS_CST          || '"",""' || "
        sSql = sSql & "C_HD_SEQ_CST_RATE          || '"",""' || "
        sSql = sSql & "C_HD_SEQ_KOSEI_RATE        || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_SIK_CST        || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_JISS_CST       || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_CST_RATE       || '"",""' || "
        sSql = sSql & "C_HD_HANNYU_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_SIK_CST      || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_JISS_CST     || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_CST_RATE     || '"",""' || "
        sSql = sSql & "C_HD_COMPUTER_KOSEI_RATE   || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_SIK_CST         || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_JISS_CST        || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_CST_RATE        || '"",""' || "
        sSql = sSql & "C_HD_KEIHI_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_SIK_CST       || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_JISS_CST      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_CST_RATE      || '"",""' || "
        sSql = sSql & "C_HD_FURIKAE_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_MEI_HD_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_SIK_CST     || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_NAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_GAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_CST_RATE    || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_NAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_GAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KEI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_SIK_CST     || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_NAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_GAI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_JISS_CST    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_CST_RATE    || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_NAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_GAI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KEI_KOSEI_RATE  || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_SIK_CST        || '"",""' || "
        sSql = sSql & "C_SF_PG_NAI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_GAI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_JISS_CST       || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_CST_RATE       || '"",""' || "
        sSql = sSql & "C_SF_PG_NAI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_PG_GAI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_PG_KEI_KOSEI_RATE     || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_SF_TYS_NAI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_SF_TYS_GAI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_SF_TYS_NAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYS_GAI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYS_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_SIK_CST         || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_JISS_CST        || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_CST_RATE        || '"",""' || "
        sSql = sSql & "C_SF_TYSKE_KOSEI_RATE      || '"",""' || "
        sSql = sSql & "C_SF_SYOK_SIK_CST          || '"",""' || "
        sSql = sSql & "C_SF_SYOK_JISS_CST         || '"",""' || "
        sSql = sSql & "C_SF_SYOK_CST_RATE         || '"",""' || "
        sSql = sSql & "C_SF_SYOK_KOSEI_RATE       || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_SIK_CST       || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_JISS_CST      || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_CST_RATE      || '"",""' || "
        sSql = sSql & "C_MEI_SF_KEI_KOSEI_RATE    || '"",""' || "
        sSql = sSql & "C_MEI_KEI_SIK_CST          || '"",""' || "
        sSql = sSql & "C_MEI_KEI_JISS_CST         || '"",""' || "
        sSql = sSql & "C_MEI_KEI_CST_RATE         || '"",""' || "
        sSql = sSql & "C_HD_SEK_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_HD_SEZ_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_HD_KENSA_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_HD_KOUJI_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_SYSEK_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_BSSEK_KOS_QTY         || '"",""' || "
        sSql = sSql & "C_SF_PG_KOS_QTY            || '"",""' || "
        sSql = sSql & "C_SF_TYS_KOS_QTY           || '"",""' || "
        sSql = sSql & "C_SF_HOKA_KOS_QTY          || '"",""' || "
        sSql = sSql & "C_SF_HOKA_KOS_QTY          || '"",""' || "
        sSql = sSql & "C_SOU_PGM_QTY              || '"",""' || "
        sSql = sSql & "C_PGM_UP                   || '"",""' || "
        sSql = sSql & "C_SOU_STEP_QTY             || '"",""' || "
        sSql = sSql & "C_STEP_UP                  || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'UPD 20160603 START C2-20160603-01
        '        sSql = sSql & "Order By C_SO_NO"
        sSql = sSql & "Order By C_SO_NO, C_SEQ_10 "
        'UPD 20160603  END  C2-20160603-01


        '列ヘッダ
        sColHeader = sColHeader & "プラントNo"","""
        sColHeader = sColHeader & "受注No"","""
        sColHeader = sColHeader & "納入先名"","""
        sColHeader = sColHeader & "品名"","""
        sColHeader = sColHeader & "受注日"","""
        sColHeader = sColHeader & "型式"","""
        sColHeader = sColHeader & "分類"","""
        sColHeader = sColHeader & "売上日"","""
        sColHeader = sColHeader & "担当者"","""
        sColHeader = sColHeader & "生産担当者"","""
        sColHeader = sColHeader & "契約金額・ハード"","""
        sColHeader = sColHeader & "契約金額・ソフト"","""
        sColHeader = sColHeader & "契約金額・計"","""
        sColHeader = sColHeader & "仕切原価計・ハード"","""
        sColHeader = sColHeader & "仕切原価計・ソフト"","""
        sColHeader = sColHeader & "仕切原価計"","""
        sColHeader = sColHeader & "目標原価計・ハード"","""
        sColHeader = sColHeader & "目標原価計・ソフト"","""
        sColHeader = sColHeader & "目標原価計"","""
        sColHeader = sColHeader & "実績原価計・ハード"","""
        sColHeader = sColHeader & "実績原価計・ソフト"","""
        sColHeader = sColHeader & "実績原価計"","""
        sColHeader = sColHeader & "仕切原価率・ハード"","""
        sColHeader = sColHeader & "仕切原価率・ソフト"","""
        sColHeader = sColHeader & "仕切原価率・計"","""
        sColHeader = sColHeader & "目標原価率・ハード"","""
        sColHeader = sColHeader & "目標原価率・ソフト"","""
        sColHeader = sColHeader & "目標原価率・計"","""
        sColHeader = sColHeader & "実績原価率・ハード"","""
        sColHeader = sColHeader & "実績原価率・ソフト"","""
        sColHeader = sColHeader & "実績原価率・計"","""
        sColHeader = sColHeader & "仕切原価・ハード・設計・計"","""
        sColHeader = sColHeader & "実績原価・ハード・設計・社内"","""
        sColHeader = sColHeader & "実績原価・ハード・設計・外注"","""
        sColHeader = sColHeader & "実績原価・ハード・設計・計"","""
        sColHeader = sColHeader & "原価率・ハード・設計・計"","""
        sColHeader = sColHeader & "構成比・ハード・設計・社内"","""
        sColHeader = sColHeader & "構成比・ハード・設計・外注"","""
        sColHeader = sColHeader & "構成比・ハード・設計・計"","""
        sColHeader = sColHeader & "仕切原価・ハード・製造・計"","""
        sColHeader = sColHeader & "実績原価・ハード・製造・社内"","""
        sColHeader = sColHeader & "実績原価・ハード・製造・外注"","""
        sColHeader = sColHeader & "実績原価・ハード・製造・計"","""
        sColHeader = sColHeader & "原価率・ハード・製造・計"","""
        sColHeader = sColHeader & "構成比・ハード・製造・社内"","""
        sColHeader = sColHeader & "構成比・ハード・製造・外注"","""
        sColHeader = sColHeader & "構成比・ハード・製造・計"","""
        sColHeader = sColHeader & "仕切原価・ハード・検査"","""
        sColHeader = sColHeader & "実績原価・ハード・検査"","""
        sColHeader = sColHeader & "原価率・ハード・検査"","""
        sColHeader = sColHeader & "構成比・ハード・検査"","""
        sColHeader = sColHeader & "仕切原価・ハード・購入機器"","""
        sColHeader = sColHeader & "実績原価・ハード・購入機器"","""
        sColHeader = sColHeader & "原価率・ハード・購入機器"","""
        sColHeader = sColHeader & "構成比・ハード・購入機器"","""
        sColHeader = sColHeader & "仕切原価・ハード・シーケンサー"","""
        sColHeader = sColHeader & "実績原価・ハード・シーケンサー"","""
        sColHeader = sColHeader & "原価率・ハード・シーケンサー"","""
        sColHeader = sColHeader & "構成比・ハード・シーケンサー"","""
        sColHeader = sColHeader & "仕切原価・ハード・搬入運搬"","""
        sColHeader = sColHeader & "実績原価・ハード・搬入運搬"","""
        sColHeader = sColHeader & "原価率・ハード・搬入運搬"","""
        sColHeader = sColHeader & "構成比・ハード・搬入運搬"","""
        sColHeader = sColHeader & "仕切原価・ハード・工事据付"","""
        sColHeader = sColHeader & "実績原価・ハード・工事据付"","""
        sColHeader = sColHeader & "原価率・ハード・工事据付"","""
        sColHeader = sColHeader & "構成比・ハード・工事据付"","""
        sColHeader = sColHeader & "仕切原価・ハード・計算機"","""
        sColHeader = sColHeader & "実績原価・ハード・計算機"","""
        sColHeader = sColHeader & "原価率・ハード・計算機"","""
        sColHeader = sColHeader & "構成比・ハード・計算機"","""
        sColHeader = sColHeader & "仕切原価・ハード・経費"","""
        sColHeader = sColHeader & "実績原価・ハード・経費"","""
        sColHeader = sColHeader & "原価率・ハード・経費"","""
        sColHeader = sColHeader & "構成比・ハード・経費"","""
        sColHeader = sColHeader & "仕切原価・ハード・振替"","""
        sColHeader = sColHeader & "実績原価・ハード・振替"","""
        sColHeader = sColHeader & "原価率・ハード・振替"","""
        sColHeader = sColHeader & "構成比・ハード・振替"","""
        sColHeader = sColHeader & "仕切原価・ハード・計"","""
        sColHeader = sColHeader & "実績原価・ハード・計"","""
        sColHeader = sColHeader & "原価率・ハード・計"","""
        sColHeader = sColHeader & "構成比・ハード・計"","""
        sColHeader = sColHeader & "仕切原価・ソフト・システム設計・計"","""
        sColHeader = sColHeader & "実績原価・ソフト・システム設計・社内"","""
        sColHeader = sColHeader & "実績原価・ソフト・システム設計・外注"","""
        sColHeader = sColHeader & "実績原価・ソフト・システム設計・計"","""
        sColHeader = sColHeader & "原価率・ソフト・システム設計・計"","""
        sColHeader = sColHeader & "構成比・ソフト・システム設計・社内"","""
        sColHeader = sColHeader & "構成比・ソフト・システム設計・外注"","""
        sColHeader = sColHeader & "構成比・ソフト・システム設計・計"","""
        sColHeader = sColHeader & "仕切原価・ソフト・基本設計・計"","""
        sColHeader = sColHeader & "実績原価・ソフト・基本設計・社内"","""
        sColHeader = sColHeader & "実績原価・ソフト・基本設計・外注"","""
        sColHeader = sColHeader & "実績原価・ソフト・基本設計・計"","""
        sColHeader = sColHeader & "原価率・ソフト・基本設計・計"","""
        sColHeader = sColHeader & "構成比・ソフト・基本設計・社内"","""
        sColHeader = sColHeader & "構成比・ソフト・基本設計・外注"","""
        sColHeader = sColHeader & "構成比・ソフト・基本設計・計"","""
        sColHeader = sColHeader & "仕切原価・ソフト・プログラム・計"","""
        sColHeader = sColHeader & "実績原価・ソフト・プログラム・社内"","""
        sColHeader = sColHeader & "実績原価・ソフト・プログラム・外注"","""
        sColHeader = sColHeader & "実績原価・ソフト・プログラム・計"","""
        sColHeader = sColHeader & "原価率・ソフト・プログラム・計"","""
        sColHeader = sColHeader & "構成比・ソフト・プログラム・社内"","""
        sColHeader = sColHeader & "構成比・ソフト・プログラム・外注"","""
        sColHeader = sColHeader & "構成比・ソフト・プログラム・計"","""
        sColHeader = sColHeader & "仕切原価・ソフト・現地調整・計"","""
        sColHeader = sColHeader & "実績原価・ソフト・現地調整・社内"","""
        sColHeader = sColHeader & "実績原価・ソフト・現地調整・外注"","""
        sColHeader = sColHeader & "実績原価・ソフト・現地調整・計"","""
        sColHeader = sColHeader & "原価率・ソフト・現地調整・計"","""
        sColHeader = sColHeader & "構成比・ソフト・現地調整・社内"","""
        sColHeader = sColHeader & "構成比・ソフト・現地調整・外注"","""
        sColHeader = sColHeader & "構成比・ソフト・現地調整・計"","""
        sColHeader = sColHeader & "仕切原価・ソフト・現地調整経費"","""
        sColHeader = sColHeader & "実績原価・ソフト・現地調整経費"","""
        sColHeader = sColHeader & "原価率・ソフト・現地調整経費"","""
        sColHeader = sColHeader & "構成比・ソフト・現地調整経費"","""
        sColHeader = sColHeader & "仕切原価・ソフト・その他諸経費"","""
        sColHeader = sColHeader & "実績原価・ソフト・その他諸経費"","""
        sColHeader = sColHeader & "原価率・ソフト・その他諸経費"","""
        sColHeader = sColHeader & "構成比・ソフト・その他諸経費"","""
        sColHeader = sColHeader & "仕切原価・ソフト・計"","""
        sColHeader = sColHeader & "実績原価・ソフト・計"","""
        sColHeader = sColHeader & "原価率・ソフト・計"","""
        sColHeader = sColHeader & "構成比・ソフト・計"","""
        sColHeader = sColHeader & "仕切原価・合計"","""
        sColHeader = sColHeader & "実績原価・合計"","""
        sColHeader = sColHeader & "原価率・合計"","""
        sColHeader = sColHeader & "工数内訳・ハード・設計"","""
        sColHeader = sColHeader & "工数内訳・ハード・製造"","""
        sColHeader = sColHeader & "工数内訳・ハード・検査"","""
        sColHeader = sColHeader & "工数内訳・ハード・工事据付"","""
        sColHeader = sColHeader & "工数内訳・ソフト・システム設計"","""
        sColHeader = sColHeader & "工数内訳・ソフト・基本設計"","""
        sColHeader = sColHeader & "工数内訳・ソフト・プログラム"","""
        sColHeader = sColHeader & "工数内訳・ソフト・現地調整"","""
        sColHeader = sColHeader & "工数内訳・ソフト・その他"","""
        sColHeader = sColHeader & "工数内訳・合計"","""
        sColHeader = sColHeader & "ＰＧ総本数"","""
        sColHeader = sColHeader & "ＰＧ１本当り単価"","""
        sColHeader = sColHeader & "総ステップ数"","""
        '2010/05/14 UPD STR
        '*D*sColHeader = sColHeader & "ステップ当り単価"","""
        sColHeader = sColHeader & "ステップ当り単価"
        '2010/05/14 UPD END

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_原価分析表 = True

        Exit Function

ERR_END:


    End Function

    '==========================================================================
    '   関数:GET_SQL_工数集計総括表
    '   概要:工数集計総括表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_工数集計総括表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String) As Boolean


        GET_SQL_工数集計総括表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = ""


        '列ヘッダ
        sColHeader = ""


        '行ヘッダ
        sRowHeader = ""


        GET_SQL_工数集計総括表 = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   関数:GET_SQL_原価差額分析表
    '   概要:原価差額分析表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2009/12/18      大矢        新規作成
    '
    '==========================================================================
    Private Function GET_SQL_原価差額分析表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_原価差額分析表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & " C_BMN_CD                || '"",""' || "
        sSql = sSql & " C_MEI2                  || '"",""' || "

        sSql = sSql & " C_YUKO_TIME                     || '"",""' || "
        sSql = sSql & " C_MUKO_TIME                     || '"",""' || "
        sSql = sSql & " C_TOTAL_TIME                    || '"",""' || "
        sSql = sSql & " C_YUKO_TIME_RITU                || '"",""' || "
        sSql = sSql & " C_SOGYODO                       || '"",""' || "
        sSql = sSql & " C_YOTEI_HAI_TAN                 || '"",""' || "
        sSql = sSql & " C_TYOKU_YOTEI_AMT               || '"",""' || "
        sSql = sSql & " C_TYOKU_JISS_ROUMU_AMT          || '"",""' || "
        sSql = sSql & " C_TYOKU_TIME_FURIKAE            || '"",""' || "
        sSql = sSql & " C_TYOKU_KOUSU_HOJYO_BMN_AMT     || '"",""' || "
        sSql = sSql & " C_TYOKU_TOTAL_AMT               || '"",""' || "
        sSql = sSql & " C_TYOKU_SAGAKU_AMT              || '"",""' || "
        sSql = sSql & " C_KAN_YOTEI_HAI_AMT             || '"",""' || "
        sSql = sSql & " C_KAN_JISS_ROUMU_AMT            || '"",""' || "
        sSql = sSql & " C_KAN_KEI_AMT                   || '"",""' || "
        sSql = sSql & " C_KAN_BMN_AMT                   || '"",""' || "
        sSql = sSql & " C_KAN_TOTAL_AMT                 || '"",""' || "
        sSql = sSql & " C_KAN_SAGAKU_AMT                || '"",""' || "
        sSql = sSql & " C_SAGAKU_KEI_CST                || '"",""' || "
        sSql = sSql & " C_JISS_RATE                     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        sSql = sSql & "ORDER BY C_PAGE_INS "
        sSql = sSql & " , C_SYUKEI_1 "
        sSql = sSql & " , C_SYUKEI_2 "
        sSql = sSql & " , C_SYUKEI_3 "
        sSql = sSql & " , C_UPDOWN "

        '列ヘッダ
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "労務費・間接費予定配賦"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "間接費予定配賦額"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & "間接費実績"","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "","""
        sColHeader2 = sColHeader2 & " "

        sColHeader = sColHeader & "部門名"","""
        sColHeader = sColHeader & " "","""
        '2015/01/09 DEL STR
        'sColHeader = sColHeader & " "","""
        '2015/01/09 DEL END

        sColHeader = sColHeader & "有効工数"","""
        sColHeader = sColHeader & "無効工数"","""
        sColHeader = sColHeader & "総工数"","""
        sColHeader = sColHeader & "有効工数率"","""
        sColHeader = sColHeader & "操業度対象値"","""
        sColHeader = sColHeader & "予定配賦単価(率)"","""
        sColHeader = sColHeader & "直接労務費 予定配賦額"","""
        sColHeader = sColHeader & "直接労務費 労務費実績"","""
        sColHeader = sColHeader & "直接労務費 工数振替"","""
        sColHeader = sColHeader & "直接労務費 工数補助部門費"","""
        sColHeader = sColHeader & "直接労務費 計"","""
        sColHeader = sColHeader & "直接労務費 労務費差額"","""
        sColHeader = sColHeader & "製造間接費 予定配賦額"","""
        sColHeader = sColHeader & "製造間接費 労務費実績"","""
        sColHeader = sColHeader & "製造間接費 間接経費"","""
        sColHeader = sColHeader & "製造間接費 間接部門費"","""
        sColHeader = sColHeader & "製造間接費 計"","""
        sColHeader = sColHeader & "製造間接費 間接費差額"","""
        sColHeader = sColHeader & "原価差額 合計"","""
        sColHeader = sColHeader & "実績賃率"


        '行ヘッダ
        sRowHeader = ""


        GET_SQL_原価差額分析表 = True

        Exit Function

ERR_END:


    End Function


    '==========================================================================
    '   関数:GET_SQL_労務費間接費配賦総括表
    '   概要:労務費間接費配賦総括表のＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2014/10/22      RS)石本     新規作成
    '
    '==========================================================================
    Private Function GET_SQL_労務費間接費配賦総括表(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_労務費間接費配賦総括表 = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "' || '"",""' || "
        sSql = sSql & "C_CRT_DATE          || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 労務費・間接費配賦総括表 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_CLS     || '"",""' || "
        sSql = sSql & "C_SHU_KOJYO_DESC    || '"",""' || "
        sSql = sSql & "C_BMN_DESC          || '"",""' || "
        sSql = sSql & "C_TIME_CST          || '"",""' || "
        sSql = sSql & "C_TIME_CST_SUM      || '"",""' || "
        sSql = sSql & "C_MACHINE_TIME_CST  || '"",""' || "
        sSql = sSql & "C_MACHINE_TIME_CST_SUM    || '"",""' || "
        sSql = sSql & "C_GIJ_CST           || '"",""' || "
        sSql = sSql & "C_GIJ_CST_SUM       || '"",""' || "
        sSql = sSql & "C_KOU1_CST          || '"",""' || "
        sSql = sSql & "C_KOU1_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KOU2_CST          || '"",""' || "
        sSql = sSql & "C_KOU2_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KOU3_CST          || '"",""' || "
        sSql = sSql & "C_KOU3_CST_SUM      || '"",""' || "
        sSql = sSql & "C_KANRI_CST         || '"",""' || "
        sSql = sSql & "C_KANRI_CST_SUM     || '"",""' || "
        sSql = sSql & "C_KOTEI_CST         || '"",""' || "
        sSql = sSql & "C_KOTEI_CST_SUM     || '"",""' || "
        sSql = sSql & "C_TOTAL_CST         || '"",""' || "
        sSql = sSql & "C_TOTAL_CST_SUM     || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "事業部コード"","""
        sColHeader = sColHeader & "事業部名"","""
        sColHeader = sColHeader & "主管部門名称"","""
        sColHeader = sColHeader & "工数配賦"","""
        sColHeader = sColHeader & "工数配賦(累計)"","""
        sColHeader = sColHeader & "機械加工費"","""
        sColHeader = sColHeader & "機械加工費(累計)"","""
        sColHeader = sColHeader & "技術部配賦"","""
        sColHeader = sColHeader & "技術部配賦(累計)"","""
        sColHeader = sColHeader & "購買費配賦（引当直接材料費）"","""
        sColHeader = sColHeader & "購買費配賦（引当直接材料費）(累計)"","""
        sColHeader = sColHeader & "購買費配賦(出庫直接材料費)"","""
        sColHeader = sColHeader & "購買費配賦(出庫直接材料費)(累計)"","""
        sColHeader = sColHeader & "購買費配賦（外注費）"","""
        sColHeader = sColHeader & "購買費配賦（外注費）(累計)"","""
        sColHeader = sColHeader & "管理費配賦"","""
        sColHeader = sColHeader & "管理費配賦(累計)"","""
        sColHeader = sColHeader & "共通固定費配賦"","""
        sColHeader = sColHeader & "共通固定費配賦(累計)"","""
        sColHeader = sColHeader & "合計"","""
        sColHeader = sColHeader & "合計（累計）"

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_労務費間接費配賦総括表 = True

        Exit Function

ERR_END:


    End Function



    '==========================================================================
    '   関数:GET_SQL_原価振替リスト
    '   概要:原価振替リストのＣＳＶ出力用ＳＱＬ、ヘッダを作成
    '   IO  引数            値          内容
    '   OUT sSql                       抽出ＳＱＬ
    '   OUT sColHeader                 列ヘッダ
    '   OUT sRowHeader                 行ヘッダ
    '
    '   戻り値              値          内容
    '                       True        正常終了
    '                       False       異常終了
    '
    '   作成・更新      担当者      変更内容
    '   2014/10/22      RS)石本     新規作成
    '
    '==========================================================================
    Private Function GET_SQL_原価振替リスト(ByRef sSql As String, ByRef sColHeader As String, ByRef sRowHeader As String, ByRef sColHeader2 As String) As Boolean


        GET_SQL_原価振替リスト = False
        On Error GoTo ERR_END

        '抽出SQL
        sSql = "SELECT "
        sSql = sSql & " '""' || "
        sSql = sSql & "'" & SSS_PrtID & "'  || '"",""' || "
        sSql = sSql & "C_CRT_DATE           || '"",""' || "
        sSql = sSql & "C_Y || '年' || C_M || '月度 原価振替リスト 【' || C_CO_DESC || '】' || '"",""' || "
        sSql = sSql & "C_ORDER_NO           || '"",""' || "
        sSql = sSql & "C_FURI_DATE          || '"",""' || "
        sSql = sSql & "C_FURIKAE_DESC       || '"",""' || "
        sSql = sSql & "C_MOTO_SEIBAN        || '"",""' || "
        sSql = sSql & "C_MOTO_SYUYAKU_NO    || '"",""' || "
        sSql = sSql & "C_SAKI_SEIBAN        || '"",""' || "
        sSql = sSql & "C_SAKI_SYUYAKU_NO    || '"",""' || "
        sSql = sSql & "C_AMT                || '"",""' || "
        sSql = sSql & "C_SYORI_KBN          || '"",""' || "
        sSql = sSql & "C_CREATE_CD          || '"" ' "
        '2019/05/21 ADD START
        sSql = sSql & " as data "
        '2019/05/21 ADD E N D
        sSql = sSql & "From " & SSS_TblID
        sSql = sSql & " WHERE " & "C_PRT_PK_NO = '" & ps_prtPmKey & "' "
        'ADD 20160603 START C2-20160603-01
        sSql = sSql & " Order By C_SEQ_10 "
        'ADD 20160603  END  C2-20160603-01

        '列ヘッダ
        sColHeader = ""
        sColHeader = sColHeader & "帳票ID"","""
        sColHeader = sColHeader & "作成日"","""
        sColHeader = sColHeader & "帳票タイトル"","""
        sColHeader = sColHeader & "処理№"","""
        sColHeader = sColHeader & "振替日"","""
        sColHeader = sColHeader & "振替区分名称"","""
        sColHeader = sColHeader & "元製番"","""
        sColHeader = sColHeader & "元集約№"","""
        sColHeader = sColHeader & "先製番"","""
        sColHeader = sColHeader & "先集約№"","""
        sColHeader = sColHeader & "振替金額"","""
        sColHeader = sColHeader & "処理区分"","""
        sColHeader = sColHeader & "処理担当"

        '行ヘッダ
        sRowHeader = ""


        GET_SQL_原価振替リスト = True

        Exit Function

ERR_END:


    End Function

    'PDF出力用関数
    '2015/10/6追記　FWEST

    '2019/05/13 CHG START
    'Private Function PDF_OUTPUT_BK(ByVal PDF_NM As String) As Object
    '    Dim crEFTPortableDocFormat As Object
    '    Dim crEDTDiskFile As Object
    '    Dim CRAXDRT As Object

    '    Dim CRAPP As CRAXDRT.Application
    '    'UPGRADE_ISSUE: CRAXDRT.Report オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '    Dim Report As CRAXDRT.Report
    '    'UPGRADE_ISSUE: CRAXDRT.ConnectionProperty オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '    Dim ConnectProperty As CRAXDRT.ConnectionProperty

    '    Dim iPaperOrnt As Short
    '    Dim iPaperSize As Short
    '    Dim i As Short

    '    'レポートファイル指定
    '    CRAPP = CreateObject("Crystalruntime.Application")
    '    'UPGRADE_WARNING: オブジェクト CRAPP.OpenReport の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report = CRAPP.OpenReport(SSS_RPT_DIR & "\" & SSS_PrtID & ".RPT")
    '    '用紙情報　退避
    '    'UPGRADE_WARNING: オブジェクト Report.PaperOrientation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    iPaperOrnt = Report.PaperOrientation
    '    'UPGRADE_WARNING: オブジェクト Report.PaperSize の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    iPaperSize = Report.PaperSize


    '    'ＤＢ接続
    '    'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    For i = 1 To Report.Database.Tables.Count

    '        'IT2-0005 UPD STR
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Server")
    '        '*D*        ConnectProperty.Value = ps_DatabaseName
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("User ID")
    '        '*D*        ConnectProperty.Value = ps_UserName
    '        '*D*        Set ConnectProperty = Report.Database.Tables.Item(i).ConnectionProperties.Item("Password")
    '        '*D*        ConnectProperty.Value = ps_Password
    '        'SID
    '        'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.Database.Tables(i).ConnectionProperties.Item("Server") = ps_DatabaseName
    '        'ﾕｰｻﾞ
    '        'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.Database.Tables(i).ConnectionProperties.Item("User ID") = ps_UserName
    '        'ﾊﾟｽﾜｰﾄﾞ
    '        'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.Database.Tables(i).ConnectionProperties.Item("Password") = ps_Password
    '        'ﾛｹｰｼｮﾝ　※ﾕｰｻﾞを大文字変換しないと正しくプレビューされない
    '        'UPGRADE_WARNING: オブジェクト Report.Database の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.Database.Tables(i).Location = UCase(ps_UserName) & "." & SSS_TblID
    '        'IT2-0005 UPD END

    '    Next i


    '    '抽出条件指定
    '    'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    If Trim(Report.RecordSelectionFormula) <> "" Then
    '        'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '    Else
    '        'UPGRADE_WARNING: オブジェクト Report.RecordSelectionFormula の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
    '    End If


    '    'UPGRADE_WARNING: オブジェクト Report.PaperOrientation の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.PaperOrientation = iPaperOrnt
    '    'UPGRADE_WARNING: オブジェクト Report.PaperSize の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.PaperSize = iPaperSize

    '    'ファイル名に日付をつける
    '    PDF_NM = PDF_NM & ".pdf"

    '    '// pdfとして外部ファイル出力を行う
    '    'UPGRADE_WARNING: オブジェクト Report.ExportOptions の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト crEDTDiskFile の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.ExportOptions.DestinationType = crEDTDiskFile
    '    'UPGRADE_WARNING: オブジェクト Report.ExportOptions の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.ExportOptions.DiskFileName = PDF_NM '"C:\output.pdf"
    '    'UPGRADE_WARNING: オブジェクト Report.ExportOptions の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト crEFTPortableDocFormat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.ExportOptions.FormatType = crEFTPortableDocFormat
    '    'UPGRADE_WARNING: オブジェクト Report.Export の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Report.Export(False)

    'End Function
    Private Sub PDF_OUTPUT(ByVal PDF_NM As String)

        Dim CR As New CrstlRpt
        Dim Report = CR.NewCRReport()
        Dim iPaperOrnt As Short
        Dim iPaperSize As Short

        'レポートファイル指定
        Report.Load(SSS_RPT_DIR & "\" & SSS_PrtID & ".rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByDefault)

        '用紙情報　退避
        iPaperOrnt = Report.PrintOptions.PaperOrientation
        iPaperSize = Report.PrintOptions.PaperSize

        Dim sSql As String '抽出ＳＱＬ
        Dim sColHeader As String '列タイトル
        Dim sColHeader2 As String '列タイトル２
        Dim sRowHeader As String '行タイトル

        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Sub
        End If

        '抽出条件指定
        If Trim(Report.RecordSelectionFormula) <> "" Then
            Report.RecordSelectionFormula = Report.RecordSelectionFormula & " AND {" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        Else
            Report.RecordSelectionFormula = "{" & SSS_TblID & ".C_PRT_PK_NO} = '" & ps_prtPmKey & "' " & Chr(0)
        End If

        'CR = New CrstlRpt

        '用紙設定
        Report.PrintOptions.PaperOrientation = iPaperOrnt
        Report.PrintOptions.PaperSize = iPaperSize
        'レポートが接続するＤＢ情報をセット※画面表示時のログイン画面の表示を回避***
        Report.SetDatabaseLogon("GENKA_USR1", "GENKA_USR1")
        '***************************************************************************
        'CR.SetDatabase("CONORCL", "GENKA_USR1P", "GENKA_USR1", sSql, SSS_TblID, Report)
        CR.SetDatabase("DEV02", "GENKA_USR1", "GENKA_USR1", sSql, SSS_TblID, Report)

        'ファイル名に日付をつける
        PDF_NM = PDF_NM & ".pdf"

        CR.ReportPreview(Report, sSql, "01")

        CR.ReportPrint(Report, 4)

    End Sub
    '2019/05/13 CHG E N D


    'CSV出力用関数
    '2015/10/29追記　FWEST
    Private Function CSV_OUTPUT_B(ByVal CSV_NM As String) As Object

        Dim sSql As String '抽出ＳＱＬ
        Dim sColHeader As String '列タイトル
        Dim sColHeader2 As String '列タイトル２
        Dim sRowHeader As String '行タイトル

        'ヘッダ文・ＳＱＬ文作成
        If Get_Sql(sSql, sColHeader, sRowHeader, sColHeader2) = False Then
            Exit Function
        End If

        'ＣＳＶ出力
        If CSV_OUTPUT("BATCH", sSql, sColHeader, sRowHeader, sColHeader2, CSV_NM & ".csv") = False Then
            Exit Function
        End If

    End Function
End Module