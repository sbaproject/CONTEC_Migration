Option Strict Off
Option Explicit On
'2019/06/20 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/06/20 ADD END
Module SSSMAIN0001
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    ' このソースファイルはIDOET52/IDOET53共通です (H.Y. 9/28)
    'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '単プロジェクトごとの共通ライブラリ
    Public PP_SSSMAIN As clsPP
    Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
    Public CQ_SSSMAIN(82) As String


    '□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '初期処理時チェック実行フラグ
    Public gv_bolInit As Boolean '初期処理時はTrue(チェックなし）　それ以外はFalse
    '画面初期化フラグ
    Public gv_bolUODET51_INIT As Boolean 'True:変更あり
    Public gv_bolUODET51_INIT_MITNO As Boolean 'True:変更あり(見積番号、版数の変更は除く）

    Public gv_bolUODET51_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
    ' エンターキー連打による不具合修正
    Public gv_bolKeyFlg As Boolean
    ' エンターキー連打による不具合修正２
    Public gv_bolUpdFlg As Boolean

    '2019/06/20 ADD START
    Public D0 = New ClsComn
    Public LV_Col_Order() As Integer
    '2019/06/20 DELL START


    ' フィールドを追加したときはF_Reset_IDOET52_TYPE_SBNTRA_Allにも付けること
    Private Structure IDOET52_TYPE_SBNTRA
        Dim DENDT As String '受注日付
        Dim TOKCD As String '得意先コード
        Dim TOKRN As String '得意先略称
        Dim NHSCD As String '納入先コード
        Dim NHSNMA As String '納入先名称１
        Dim NHSNMB As String '納入先名称２
        Dim TANCD As String '担当者コード
        Dim TANNM As String '担当者名
        Dim BUMCD As String '部門コード
        Dim BUMNM As String '部門名
        Dim SOUCD As String '倉庫コード
        Dim SOUNM As String '倉庫名
        Dim SOUBSCD As String '場所コード
        Dim KKOUT As Short '緊急出庫（チェック時=1, オフ時=0）
        Dim TOKADA As String '得意先住所１
        Dim TOKADB As String '得意先住所２
        Dim TOKADC As String '得意先住所３
        Dim NHSADA As String '納入先住所１
        Dim NHSADB As String '納入先住所２
        Dim NHSADC As String '納入先住所３
        Dim SBNNO As String '製番
        Dim OUTRYCD As String '出庫理由コード
        Dim OUTRYNM As String '出庫理由名
        Dim OUTRYKB1 As String '出庫理由区分１
        Dim OUTRYKB2 As String '出庫理由区分２
        Dim OUTRYKB3 As String '出庫理由区分３
        Dim OUTKB As String '出庫区分 (->SBNTRA)
        Dim DATNO As String '伝票管理番号（IDOET53で訂正対象となる番号です）
        'ADD START FKS)INABA 2006/12/28 *********************************************************
        Dim NHSZIPCD As String '納入先郵便番号
        Dim NHSTL As String '納入先電話番号
        Dim NHSFAX As String '納入先ＦＡＸ番号
        Dim FRNKB As String '海外取引区分
        'ADD  END  FKS)INABA 2006/12/28 *********************************************************
        'ADD START FKS)INABA 2007/01/05 *********************************************************
        Dim NHSNMMKB As String '名称マニュアル入力区分
        'ADD  END  FKS)INABA 2007/01/05 *********************************************************
        'ADD START FKS)INABA 2006/11/16 *********************************************************
        Dim BINCD As String
        Dim BINNM As String
        '    HINCD           As String
        '    HINNMA          As String
        '    HINNMB          As String
        '    UODSU           As String
        '    UNTNM           As String
        '    LINCMA          As String
        '    LINCMB          As String
        'ADD  END  FKS)INABA 2006/11/16 *********************************************************
        'ADD START FKS)INABA 2007/01/20 *********************************************************
        Dim CLMDL As String
        Dim REGDT As String
        Dim J_BMNCD As String
        'ADD  END  FKS)INABA 2007/01/20 *********************************************************
        Dim FRDSU As Integer
        Dim HIKSMSU As Integer
        Dim OUTSMSU As Integer
        'ADD START FKS)INABA 2007/02/20 *********************************************************
        Dim PUDLNO As String
        'ADD  END  FKS)INABA 2007/02/20 *********************************************************
    End Structure

    '製番出庫見出し情報
    Private IDOET52_SBNTRA_Inf As IDOET52_TYPE_SBNTRA

    Private curTL_SBAUODKN As Decimal '受注合計（本体合計)
    Private curTL_SBAUZEKN As Decimal '受注合計（消費税合計)
    Private curTL_SBAUZKKN As Decimal '受注合計（伝票合計)
    Private bolMEISAI_INPUT As Boolean '明細入力フラグ(True:入力あり）
    Private intMeisaiCnt As Short '入力明細数（更新時使用）
    Private strCSVFilePath As String 'CSVファイル名(フルパス)
    Private pv_bolAKN_FLG As Boolean 'CSV案件情報付け替えフラグ(True：あり）
    Private bolInput_Bef_Row As Boolean '前行入力フラグ（True:入力済）
    ' 商品マスタ仮本区分対応他
    Private intInput_Bef_RowNo As Short '空白行の先頭行№
    ' 見積参照における受注取区チェック
    Private strArr_JDNTRKB() As String

    Private intODNYTLT As Short '運送LT
    Private curJDOSURT As Decimal '大口受注の比率
    Private intODNYTLT_ORD As Short '運送LT(注文情報取込用)
    ' 注文情報取込時には納入先コード(EDI連携用)を使用
    Private strNHSCD_ORD_INIT As String '納入先コード(注文情報取込用)

    'カレンダ検索画面起動
    Public Const CS_JDNDT_W As String = "1" '出庫日検索
    Public Const CS_DEFNOKDT_W As String = "2" '客先納期検索（未使用）

    '名称マスタ検索画面起動
    Public Const CS_JDNTRKB_W As String = "1" '受注取引区分検索
    Public Const CS_URIKJN_W As String = "2" '売上基準検索
    Public Const CS_OUTRY_W As String = "3" '出庫理由検索
    Public Const CS_MAEUKKB_W As String = "5" '前受区分検索
    Public Const CS_SEIKB_W As String = "6" '請求区分検索
    Public Const CS_GNKCD_W As String = "7" '原価管理コード検索
    Public Const CS_TNKKB_W As String = "8" '単価種別検索
    Public Const CS_BINCD_W As String = "9" '便コード検索

    '画面表示定数
    Public Const DSP_PER As String = "％"
    Public Const DSP_SIKSA As String = "(      %)"

    Private Const SYSTBC_FDNNO As String = "020"
    Private Const SYSTBC_PUDLNO As String = "165"

    ''**ﾁｪｯｸ関数関連 Start **
    '//戻値
    Public Const CHK_OK As Short = 0 '正常
    Public Const CHK_WARN As Short = 1 '警告
    Public Const CHK_ERR_NOT_INPUT As Short = 10 '未入力エラー
    Public Const CHK_ERR_ELSE As Short = 11 'その他エラー

    'F_Chk_Jge_Action関数用
    Public Const CHK_KEEP As Short = 0 'チェック続行
    Public Const CHK_STOP As Short = 1 'チェック中断

    '**ﾁｪｯｸ関数関連 End  **

    '//F_Set_Next_Focus処理モード
    Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURNと同様の制御
    Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHTと同様の制御
    Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWNと同様の制御
    '//F_Dsp_Item_Detail処理モード
    Public Const DSP_SET As Short = 0 '表示
    Public Const DSP_CLR As Short = 1 'クリア

    ' 出庫区分
    Public Const OUTKB_NORMAL As String = "1" ' 通常
    Public Const OUTKB_KOUKAN As String = "2" ' 交換品出荷
    Public Const BKTHKKB_KINKYU As Short = 1 ' 緊急出庫

    ' このモジュールをどちらで使うか
    Private RunMode As Short
    Private Const RUNMODE_IDOET52 As Short = 0
    Private Const RUNMODE_IDOET53 As Short = 1
    Private Const RUNMODE_IDOET54 As Short = 2

    ' === 20061127 === INSERT S - ACE)Nagasawa 諸口の製品コードの入力制限を設ける
    Public gv_strCTLCD_HINCD_H As String '発注金額用諸口コード
    Public gv_strCTLCD_HINCD_J As String '発注金額外用諸口コード
    Public gv_strCTLCD_HINCD_K As String '購買品諸口コード
    ' === 20061127 === INSERT E -
    ' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
    Private intZIPCD_KETA As Short '郵便番号桁数
    Private intZIPCD_HAIHUN As Short '郵便番号ハイフン位置
    Private intTLFAX_KETA As Short '電話番号/FAX番号の桁数
    Private intTLFAX_HAIHUN As Short '電話番号/FAX番号のハイフン個数
    Private intTLFAX_LSTNUM As Short '電話番号/FAX番号の最終ブロック文字数
    ' === 20061223 === INSERT E -
    ' === 20061031 === INSERT S - ACE)Nagasawa 排他制御の追加
    Public gv_bolUPDLock As Boolean 'True:排他制御中
    Public gv_strUpdLockMsg As String '排他制御の対象処理名
    ' === 20061031 === INSERT E -
    Public gv_moto_su As Integer

    '2008/05/13 FKS)HONDA ADD START
    Public gv_strSBNFlg As String
    '2008/05/13 FKS)HONDA ADD END

    '関数名　:Omission_Return
    '処理内容：文字列に含まれるキャリッジリターン(Chr(13))&ラインフィード(Chr(10))、タブ(Chr(9))
    '　　　　　は空白一文字に変換し、文字列を返す。
    '引数：変換前文字列
    '戻値：変換後文字列
    '作成日：2007/05/10
    '作成：FKS)INABA
    Function Omission_Return_Tab(ByRef ps_InString As Object) As String
        Dim ls_OutString As String
        Dim lw_i As Short

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDbNull(ps_InString) = True Then
            'UPGRADE_WARNING: オブジェクト ps_InString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ps_InString = ""
        Else
            For lw_i = 1 To Len(ps_InString)
                'UPGRADE_WARNING: オブジェクト ps_InString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Select Case Asc(Mid(ps_InString, lw_i, 1))
                    Case 13 'キャリッジリターン
                        ls_OutString = ls_OutString & ""
                    Case 10 'ラインフィード
                        ls_OutString = ls_OutString & ""
                    Case 9 'タブ
                        ls_OutString = ls_OutString & ""
                    Case Else 'その他
                        'UPGRADE_WARNING: オブジェクト ps_InString の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        ls_OutString = ls_OutString & Mid(ps_InString, lw_i, 1)
                End Select
            Next lw_i
        End If
        Omission_Return_Tab = ls_OutString
    End Function



    Sub PUT_LOG(ByRef ps_SYORI As String, ByRef pm_All As Cls_All, Optional ByRef ps_HANTEI1 As String = "", Optional ByRef ps_HANTEI2 As String = "", Optional ByRef ps_HANTEI3 As String = "")
        '変数ログ出力
        'ps_SYORI:1,2,3,4,5

        Dim FILE1_PATH As String
        Dim lngFileNo1 As Integer
        Dim ls_REC As String
        Dim ls_pgmode As String
        Dim ls_LOGMODE As String

        If RunMode = RUNMODE_IDOET52 Then
            ls_pgmode = "IDOET52"
        Else
            ls_pgmode = "IDOET53"
        End If

        FILE1_PATH = GP_GetIni(My.Application.Info.DirectoryPath & "\" & ls_pgmode & ".ini", "FILEPATH", "FILE3")
        ls_LOGMODE = GP_GetIni(My.Application.Info.DirectoryPath & "\" & ls_pgmode & ".ini", "FILEPATH", "LOGMODE")
        If Trim(ls_LOGMODE) = "0" Then Exit Sub

        If Trim(FILE1_PATH) = "" Then
            FILE1_PATH = "C:\FMMAX\CNT\TEMP\" & ls_pgmode & "_" & Trim(SSS_CLTID.Value) & ".LOG"
        Else
            FILE1_PATH = Left(FILE1_PATH, Len(FILE1_PATH) - 4) & "_" & Trim(SSS_CLTID.Value) & ".LOG"
        End If

        lngFileNo1 = FreeFile
        FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Append)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_HINCD(1).Tag).Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SOUCD.Tag).Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SBNNO.Tag).Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ls_REC = Trim(ps_SYORI) & ":" & VB6.Format(Now, "YYYY/MM/DD HH:NN:SS") & ",OPEID : " & Trim(SSS_OPEID.Value) & ",CLTID : " & Trim(SSS_CLTID.Value) & ",SBNNO : " & pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value & ",SOUCD : " & pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value & ",HINCD : " & pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value & ""
        Select Case Trim(ps_SYORI)
            Case "001"
                ls_REC = ls_REC & ",IDOET52_SBNTRA_Inf.OUTRYKB3 : " & ps_HANTEI1 & ",FR_SSSMAIN.HD_OPT2.Value : " & IIf(ps_HANTEI2 = "-1", "True", "False") & ",ll_su : " & ps_HANTEI3
            Case "002"
                ls_REC = ls_REC & ",RunMode : " & IIf(ps_HANTEI1 = "0", "RUNMODE_IDOET52", "RUNMODE_IDOET53") & ",IDOET52_SBNTRA_Inf.DATNO : " & ps_HANTEI2
            Case "003"
                ls_REC = ls_REC & ",RunMode : " & IIf(ps_HANTEI1 = "0", "RUNMODE_IDOET52", "RUNMODE_IDOET53") & ",IDOET52_SBNTRA_Inf.OUTRYKB1 : " & ps_HANTEI2
            Case "004"
                ls_REC = ls_REC & ",IDOET52_SBNTRA_Inf.KKOUT : " & ps_HANTEI1 & ",RunMode : " & IIf(ps_HANTEI2 = "0", "RUNMODE_IDOET52", "RUNMODE_IDOET53")
            Case "005"
                ls_REC = ls_REC & ",pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UODSU : " & ps_HANTEI1 & ",pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_UODSU(1).Tag).Detail.Dsp_Value : " & ps_HANTEI2
            Case "END"
            Case "ERR"
        End Select

        PrintLine(lngFileNo1, ls_REC)
        FileClose(lngFileNo1)

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SBNNO_Saiban
    '   概要：  伝票NO採番処理
    '   引数：  Pit_strBUMCD     :受注トランの部門コード
    '   引数：  Pit_strCLMDL     :受注トランの分類型式
    '   引数：  Pit_strOUTYTDT   :画面の出庫予定日
    '   引数：  Pot_strDENNO     :取得された伝票№
    '   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SBNNO_Saiban(ByRef pm_All As Cls_All, ByRef Pit_strBUMCD As String, ByRef Pit_strCLMDL As String, ByRef Pit_strOUTYTDT As String, ByRef Pot_strDENNO As String) As Short


        Static strSQL As String
        'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Static usrOdy As U_Ody
        Static bolRet As Boolean
        Static bolTran As Boolean
        Static strDenNo As String
        Static intCnt As Short
        Static strRtn As String
        Static strFixCd As String
        Static strDate As String
        Static strTime As String
        Static strPCOED As String
        Static strWPot_strDENNO As String

        Static strW_JDNNO_2 As String
        Static strW_HINCD As String

        'CHG START FKS)INABA 2007/03/13 **************************************************
        Static strW_JDNNO_1 As String
        'CHG  END  FKS)INABA 2007/03/13 **************************************************

        On Error GoTo ERR_SBNNO_Saiban

        SBNNO_Saiban = 9
        bolTran = False
        Pot_strDENNO = ""
        strFixCd = ""

        '一桁目(M固定)
        Pot_strDENNO = "M"

        '二桁目()
        If Trim(Pit_strBUMCD) = "" Then
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strW_JDNNO_2 = Mid(Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_JDNNO.Tag)).Detail.Dsp_Value), 2, 1)
            strSQL = "SELECT MEIKBA"
            strSQL = strSQL & " FROM BMNMTA B "
            strSQL = strSQL & "     ,(SELECT * FROM MEIMTA WHERE KEYCD = '060') M "
            strSQL = strSQL & "WHERE B.EIGYOCD = '" & strW_JDNNO_2 & "' "
            strSQL = strSQL & "  AND B.TIKKB = M.MEICDA "
        Else
            strSQL = "SELECT MEIKBA"
            strSQL = strSQL & " FROM BMNMTA B "
            strSQL = strSQL & "     ,(SELECT * FROM MEIMTA WHERE KEYCD = '060') M "
            strSQL = strSQL & "WHERE B.BMNCD = '" & Pit_strBUMCD & "' "
            strSQL = strSQL & "  AND B.TIKKB = M.MEICDA "
        End If

        'SQL実行
        bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If
        'CHG START FKS)INABA 2007/03/13 **************************************************
        '取得できなかった場合は二桁目はDとする
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(CF_Ora_GetDyn(usrOdy, "MEIKBA", "")) = "" Then
            Pot_strDENNO = Trim(Pot_strDENNO) & "D"
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(usrOdy, MEIKBA, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Pot_strDENNO = Trim(Pot_strDENNO) & CF_Ora_GetDyn(usrOdy, "MEIKBA", "")
        End If
        '    Pot_strDENNO = Trim$(Pot_strDENNO) & CF_Ora_GetDyn(usrOdy, "MEIKBA", "")
        'CHG  END  FKS)INABA 2007/03/13 **************************************************
        bolRet = CF_Ora_CloseDyn(usrOdy)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If

        If Trim(Pit_strBUMCD) = "" Then
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strW_HINCD = Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value)
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Pit_strOUTYTDT = VB6.Format(Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag)).Detail.Dsp_Value), "YYYYMMDD")

            strSQL = "  SELECT MDLCL "
            strSQL = strSQL & " FROM HINMTA "
            strSQL = strSQL & " WHERE HINCD = '" & strW_HINCD & "'"
            strSQL = strSQL & "   AND DATKB = '1' "
            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
            If bolRet = False Then
                GoTo ERR_SBNNO_Saiban
            End If
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Pit_strCLMDL = CF_Ora_GetDyn(usrOdy, "MDLCL", "")
            bolRet = CF_Ora_CloseDyn(usrOdy)

        End If

        '七～八桁目を取得(商品群略名をセット)
        '排他処理を極力少なくする為取得のみ前に持ってくる
        '    strPCOED = GET_PCODE_KISYU_VB(Pit_strCLMDL, Pit_strOUTYTDT)


        strSQL = "SELECT GET_PCODE_KISYU('" & Trim(Pit_strCLMDL) & "','" & Pit_strOUTYTDT & "') PCODE "
        strSQL = strSQL & " FROM DUAL "
        'SQL実行
        bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If

        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strPCOED = CF_Ora_GetDyn(usrOdy, "PCODE", "")
        bolRet = CF_Ora_CloseDyn(usrOdy)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If

        If Trim(strPCOED) = "" Then
            GoTo ERR_SBNNO_Saiban
        End If

        strSQL = "SELECT DISTINCT HINGRPRM "
        strSQL = strSQL & "  FROM KSYMTA"
        strSQL = strSQL & " WHERE PCODE = '" & Trim(strPCOED) & "'"
        strSQL = strSQL & "   AND STTTKDT <='" & Pit_strOUTYTDT & "'"
        strSQL = strSQL & "   AND ENDTKDT >=  '" & Pit_strOUTYTDT & "'"

        'SQL実行
        bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strWPot_strDENNO = CF_Ora_GetDyn(usrOdy, "HINGRPRM", "")
        bolRet = CF_Ora_CloseDyn(usrOdy)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If

        '三～六桁目(自動採番)
        'トランザクション開始
        '2019/06/21 CHG START
        ' Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/06/21 CHG END
        bolTran = True
        '採番マスタ取得
        strSQL = ""
        strSQL = strSQL & " Select *             "
        strSQL = strSQL & "   from SAIMTA        "
        strSQL = strSQL & "  Where SDKBSB   = '40' "
        strSQL = strSQL & "    for Update "
        'SQL実行
        bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        If bolRet = False Then
            GoTo ERR_SBNNO_Saiban
        End If

        'タイムスタンプ決定
        strDate = ""
        strTime = ""
        If Trim(GV_SysTime) <> "" Then
            strDate = GV_SysTime
            strTime = GV_SysTime
        Else
            strDate = CStr(VB6.Format(Now, "yyyymmdd"))
            strTime = CStr(VB6.Format(Now, "hhmmss"))
        End If

        'EOF判定
        If CF_Ora_EOF(usrOdy) = True Then
            GoTo ERR_SBNNO_Saiban
        Else
            '連番取得
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")

            If strDenNo = "" Then
                GoTo ERR_SBNNO_Saiban
            End If

            '受注番号
            For intCnt = 4 To 1 Step -1
                bolRet = SBNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
                strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
                If bolRet = False Then
                    Exit For
                End If
            Next intCnt

            If Trim(strDenNo) = "0000" Then
                strDenNo = "0001 "
            End If

            Pot_strDENNO = Trim(Pot_strDENNO) & strDenNo

            strSQL = ""
            strSQL = strSQL & " UPDATE SAIMTA "
            strSQL = strSQL & " SET "
            strSQL = strSQL & "     SDENNO = '" & strDenNo & "' "
            strSQL = strSQL & "   , OPEID  = '" & SSS_OPEID.Value & "' "
            strSQL = strSQL & "   , CLTID  = '" & SSS_CLTID.Value & "' "
            strSQL = strSQL & "   , WRTTM  = '" & strTime & "' "
            strSQL = strSQL & "   , WRTDT  = '" & strDate & "' "
            strSQL = strSQL & "   , UOPEID = '" & SSS_OPEID.Value & "' "
            strSQL = strSQL & "   , UCLTID = '" & SSS_CLTID.Value & "' "
            strSQL = strSQL & "   , UWRTTM = '" & strTime & "' "
            strSQL = strSQL & "   , UWRTDT = '" & strDate & "' "
            strSQL = strSQL & "   , PGID   = '" & SSS_PrgId & "' "
            strSQL = strSQL & "  WHERE SDKBSB   = '40' "
            'SQL実行
            '2019/06/24 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo ERR_SBNNO_Saiban
            'End If
            Call DB_Execute(strSQL)
            '2019/06/24 CHG END
            bolRet = CF_Ora_CloseDyn(usrOdy)
            If bolRet = False Then
                GoTo ERR_SBNNO_Saiban
            End If
            strSQL = " SELECT * FROM  MEIMTA"
            strSQL = strSQL & " WHERE KEYCD='019'"
            strSQL = strSQL & " AND MEICDA='M'"
            '2019/06/24 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo ERR_SBNNO_Saiban
            'End If
            Call DB_Execute(strSQL)
            '2019/06/24 CHG END
            '製番マスタに登録する
            strSQL = "INSERT INTO SBNMTA ("
            strSQL = strSQL & " DATKB" '伝票削除区分
            strSQL = strSQL & ",SBNNO" '製番
            strSQL = strSQL & ",HINNMA" '型式
            strSQL = strSQL & ",HINNMB" '商品名１
            strSQL = strSQL & ",SBNSU" '数量
            strSQL = strSQL & ",UNTCD" '単位コード
            strSQL = strSQL & ",SIKGNKTK" '仕切原価
            strSQL = strSQL & ",SBNHKDT" '発行日
            strSQL = strSQL & ",SBNNOUDT" '納期
            strSQL = strSQL & ",SBNENDDT" '完了日
            strSQL = strSQL & ",SBNDELDT" '取消日
            strSQL = strSQL & ",SNKSBNKB" '先行製番区分
            strSQL = strSQL & ",TANCD" '担当者
            strSQL = strSQL & ",RELFL" '連携フラグ
            strSQL = strSQL & ",FOPEID" '最終作業者コード
            strSQL = strSQL & ",FCLTID" 'クライアントＩＤ
            strSQL = strSQL & ",WRTFSTTM" 'タイムスタンプ（時間）
            strSQL = strSQL & ",WRTFSTDT" 'タイムスタンプ（日付）
            strSQL = strSQL & ",OPEID" '作業者コード
            strSQL = strSQL & ",CLTID" 'クライアントＩＤ
            strSQL = strSQL & ",WRTTM" 'タイムスタンプ（登録時間）
            strSQL = strSQL & ",WRTDT" 'タイムスタンプ（登録日）
            strSQL = strSQL & ",UOPEID" '作業者コード
            strSQL = strSQL & ",UCLTID" 'クライアントＩＤ
            strSQL = strSQL & ",UWRTTM" 'タイムスタンプ（登録時間）
            strSQL = strSQL & ",UWRTDT" 'タイムスタンプ（登録日）
            strSQL = strSQL & ",PGID" 'プログラムID

            strSQL = strSQL & ") VALUES ("
            strSQL = strSQL & "   '1'" '伝票削除区分
            strSQL = strSQL & ",    '" & Pot_strDENNO & "'" '製番
            'CHG START FKS)INABA 2008/02/19 ***********************************************************************************************
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)).Detail.Dsp_Value, 50) & "' " '型式
            '            strSQL = strSQL & ",  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, 50) & "' "    '型式
            'CHG START FKS)INABA 2008/02/19 ***********************************************************************************************
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_LINCMB(1).Tag)).Detail.Dsp_Value, 20) & "' " '商品名１
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ",   " & CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value) '数量
            strSQL = strSQL & ",  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD, 2) & "' " '単位コード
            strSQL = strSQL & ",0    " '仕切原価
            strSQL = strSQL & ",  '" & GV_SysDate & "' " '発行日
            strSQL = strSQL & ",  '" & Pit_strOUTYTDT & "' " '納期
            strSQL = strSQL & ",  '00000000'" '完了日
            strSQL = strSQL & ",  '00000000'" '取消日
            strSQL = strSQL & ", '1' " '先行製番区分
            strSQL = strSQL & ",  '" & Trim(SSS_OPEID.Value) & "'" '担当者"
            strSQL = strSQL & ", '1'" '連携フラグ

            strSQL = strSQL & ", '" & Trim(SSS_OPEID.Value) & "' " '最終作業者コード
            strSQL = strSQL & ", '" & Trim(SSS_CLTID.Value) & "' " 'クライアントＩＤ
            strSQL = strSQL & ", '" & Trim(strTime) & "' " 'タイムスタンプ（時間）
            strSQL = strSQL & ", '" & Trim(GV_SysDate) & "' " 'タイムスタンプ（日付）
            strSQL = strSQL & ", '" & Trim(SSS_OPEID.Value) & "' " '作業者コード
            strSQL = strSQL & ", '" & Trim(SSS_CLTID.Value) & "' " 'クライアントＩＤ
            strSQL = strSQL & ", '" & Trim(strTime) & "' " 'タイムスタンプ（登録時間）
            strSQL = strSQL & ", '" & Trim(GV_SysDate) & "' " 'タイムスタンプ（登録日）
            strSQL = strSQL & ", '" & Trim(SSS_OPEID.Value) & "' " '作業者コード
            strSQL = strSQL & ", '" & Trim(SSS_CLTID.Value) & "' " 'クライアントＩＤ
            strSQL = strSQL & ", '" & Trim(strTime) & "'" 'タイムスタンプ（登録時間）
            strSQL = strSQL & ", '" & Trim(GV_SysDate) & "' " 'タイムスタンプ（登録日）
            strSQL = strSQL & "   ,'" & Trim(SSS_PrgId) & "'" 'プログラムID"
            strSQL = strSQL & "  ) "
            'SQL実行
            '2019/06/24 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo ERR_SBNNO_Saiban
            'End If
            Call DB_Execute(strSQL)
            '2019/06/24 CHG END
            bolRet = CF_Ora_CloseDyn(usrOdy)
            If bolRet = False Then
                GoTo ERR_SBNNO_Saiban
            End If
        End If
        '七～八桁目をセット
        Pot_strDENNO = Trim(Pot_strDENNO) & Trim(strWPot_strDENNO)
        SBNNO_Saiban = 0

EXIT_SBNNO_Saiban:
        Exit Function

ERR_SBNNO_Saiban:

        If gv_Int_OraErr = 51 Then
            SBNNO_Saiban = 2
        End If
        If bolTran = True Then
            'ロールバック
            '2019/06/21 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/06/21 CHG END
        End If
        GoTo EXIT_SBNNO_Saiban

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function GET_PCODE_KISYU_VB
    '   概要：  機種分類取得用PL/SQL実行処理
    '   引数：  Pit_strCLMDL    分類型式
    '   引数：  Pit_strREGDT    初回伝票日付(受注)
    '   戻値：　戻り値
    '   備考：  PL/SQLを実行する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function GET_PCODE_KISYU_VB(ByRef Pit_strCLMDL As String, ByRef Pit_strREGDT As String) As String

        Dim strSQL As String 'SQL文
        Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1
        Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2
        Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3
        'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim param(4) As OraParameter 'PL/SQLのバインド変数

        '** パラメタ解消
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P1")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P2")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P3")

        '受渡し変数初期設定
        strPara1 = Trim(Pit_strCLMDL)
        strPara2 = Trim(Pit_strREGDT) '
        strPara3 = "" '製品コード

        'パラメータの初期設定を行う（バインド変数）
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_OUTPUT)

        'データ型をオブジェクトにセット
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(1) = gv_Odb_USR1.Parameters("P1")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(2) = gv_Odb_USR1.Parameters("P2")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(3) = gv_Odb_USR1.Parameters("P3")

        '各オブジェクトのデータ型を設定
        'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(1).serverType = ORATYPE_CHAR
        'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(2).serverType = ORATYPE_CHAR
        'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        param(3).serverType = ORATYPE_CHAR

        'PL/SQL呼び出しSQL
        strSQL = "BEGIN :P3 := GET_PCODE_KISYU(:P1,:P2); End;"

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END

        '** 戻り値取得
        'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strPara3 = param(3).Value

        '戻り値設定
        GET_PCODE_KISYU_VB = strPara3

        '** パラメタ解消
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P1")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P2")
        'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gv_Odb_USR1.Parameters.Remove("P3")

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SBNNO_CntUp
    '   概要：  製番番号カウントアップ処理
    '   引数：  pin_strSBNNO   :カウントアップ対象文字
    '           pot_strRtn     :カウントアップ後文字
    '   戻値：  True:桁上がりあり  False:桁上がりなし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function SBNNO_CntUp(ByVal pin_strSBNNO As String, ByRef pot_strRtn As String) As Boolean

        Dim intSBNNO As Short
        Dim strSBNNO As String

        SBNNO_CntUp = False

        Select Case Trim(pin_strSBNNO)
            Case "9"
                pot_strRtn = "A"
                Exit Function

            Case "Z"
                pot_strRtn = "0"
                SBNNO_CntUp = True
                Exit Function

            Case ""
                pot_strRtn = " "
                SBNNO_CntUp = True
                Exit Function
        End Select

        intSBNNO = Asc(pin_strSBNNO)
        pot_strRtn = Chr(intSBNNO + 1)

        Select Case pot_strRtn
            Case "I", "O"
                intSBNNO = Asc(pot_strRtn)
                pot_strRtn = Chr(intSBNNO + 1)
            Case Else
        End Select

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSZIPCD
    '   概要：  郵便番号のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSZIPCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim intRet As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSZIPCD = Retn_Code
            Exit Function
        End If

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                '郵便番号書式チェック
                intRet = CF_Chk_ZIPCD(Trim(Input_Value), intZIPCD_KETA, intZIPCD_HAIHUN, IDOET52_SBNTRA_Inf.FRNKB)
                Select Case intRet
                    Case 10
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_090
                        GoTo F_Chk_HD_NHSZIPCD_End
                    Case 20
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_089
                        GoTo F_Chk_HD_NHSZIPCD_End
                    Case Else

                End Select

                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

F_Chk_HD_NHSZIPCD_End:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSZIPCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSTL
    '   概要：  電話番号のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSTL(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim intRet As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSTL = Retn_Code
            Exit Function
        End If

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                '電話番号/FAX番号の書式チェック
                intRet = CF_Chk_FAXNO(Trim(Input_Value), intTLFAX_KETA, intTLFAX_HAIHUN, intTLFAX_LSTNUM, IDOET52_SBNTRA_Inf.FRNKB)
                Select Case intRet
                    Case 10
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_085
                        GoTo F_Chk_HD_NHSTL_End
                    Case 20
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_087
                        GoTo F_Chk_HD_NHSTL_End
                    Case 30
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_086
                        GoTo F_Chk_HD_NHSTL_End
                    Case 40
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_083
                        GoTo F_Chk_HD_NHSTL_End
                    Case 50
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_084
                        GoTo F_Chk_HD_NHSTL_End
                    Case 60
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_088
                        GoTo F_Chk_HD_NHSTL_End
                End Select

                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

F_Chk_HD_NHSTL_End:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSTL = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSFAX
    '   概要：  FAX番号のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSFAX(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim intRet As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSFAX = Retn_Code
            Exit Function
        End If

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                '電話番号/FAX番号の書式チェック
                intRet = CF_Chk_FAXNO(Trim(Input_Value), intTLFAX_KETA, intTLFAX_HAIHUN, intTLFAX_LSTNUM, IDOET52_SBNTRA_Inf.FRNKB)
                Select Case intRet
                    Case 10
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_085
                        GoTo F_Chk_HD_NHSFAX_End
                    Case 20
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_087
                        GoTo F_Chk_HD_NHSFAX_End
                    Case 30
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_086
                        GoTo F_Chk_HD_NHSFAX_End
                    Case 40
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_083
                        GoTo F_Chk_HD_NHSFAX_End
                    Case 50
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_084
                        GoTo F_Chk_HD_NHSFAX_End
                    Case 60
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_088
                        GoTo F_Chk_HD_NHSFAX_End
                End Select

                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

F_Chk_HD_NHSFAX_End:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSFAX = Retn_Code

    End Function


    Function F_JDNTRA_SBNNO_SEARCH(ByRef p_SBNNO As String) As Short
        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim ll_cnt As Integer
        Dim ll_cnt2 As Integer
        Dim ls_JDNTRKB As String
        On Error GoTo ERR_F_JDNTRA_SBNNO_SEARCH

        F_JDNTRA_SBNNO_SEARCH = 9


        'CHG START FKS)INABA 2007/04/18 **********************************************
        If Len(Trim(p_SBNNO)) = 8 Then
            strSQL = ""
            strSQL = strSQL & " Select COUNT(*) CNT"
            strSQL = strSQL & "   from JDNTRA "
            strSQL = strSQL & "  Where SBNNO = '" & p_SBNNO & "' "
            'DBアクセス
            '2019/06/21 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            DB_GetTable(strSQL)
            '2019/06/21 CHG END

            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ll_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT", 0) 'カウント
            If ll_cnt = 0 Then
                '取得データなし
                F_JDNTRA_SBNNO_SEARCH = 1
                GoTo END_F_JDNTRA_SBNNO_SEARCH
            End If
        ElseIf Len(Trim(p_SBNNO)) = 7 Then
            strSQL = ""
            strSQL = strSQL & " Select DISTINCT JDNTRKB "
            strSQL = strSQL & "   from JDNTHA "
            strSQL = strSQL & "  Where JDNNO = '" & Left(p_SBNNO, 6) & "' "
            '2019/06/21 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            DB_GetTable(strSQL)
            '2019/06/21 CHG END
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ls_JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", 0)
            Select Case Trim(ls_JDNTRKB)
                Case "01", "31", "41", ""
                    F_JDNTRA_SBNNO_SEARCH = 1
                    GoTo END_F_JDNTRA_SBNNO_SEARCH
                    'CHG START FKS)INABA 2008/01/21 *****************************************
                    '製番の7桁目は名称マスタの原価管理コード（KEYCD=048）に存在する必要がある
                Case Else
                    strSQL = ""
                    strSQL = strSQL & " Select COUNT(*) CNT"
                    strSQL = strSQL & "   from MEIMTA "
                    strSQL = strSQL & "  Where KEYCD = '048' "
                    strSQL = strSQL & "    AND MEICDA LIKE '" & Mid(p_SBNNO, 7, 1) & "%' "
                    '2019/06/21 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                    DB_GetTable(strSQL)
                    '2019/06/21 CHG END
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ll_cnt2 = CF_Ora_GetDyn(Usr_Ody, "CNT", 0) 'カウント
                    If ll_cnt2 = 0 Then
                        F_JDNTRA_SBNNO_SEARCH = 1
                        GoTo END_F_JDNTRA_SBNNO_SEARCH
                    End If
                    'CHG  END  FKS)INABA 2008/01/21 *****************************************
            End Select
        Else
            GoTo END_F_JDNTRA_SBNNO_SEARCH
        End If
        ''CHG START FKS)INABA 2007/02/28 *********************************************
        '        strSQL = ""
        '        strSQL = strSQL & " Select COUNT(*) CNT"
        '        strSQL = strSQL & "   from JDNTRA "
        '        If Left(p_SBNNO, 1) = "R" And Len(Trim(p_SBNNO)) = 7 Then
        '            strSQL = strSQL & "  Where JDNNO = '" & Left$(p_SBNNO, 6) & "' "
        '        Else
        '            strSQL = strSQL & "  Where SBNNO = '" & p_SBNNO & "' "
        '        End If
        ''        strSQL = strSQL & "  Where SBNNO = '" & p_SBNNO & "' "
        ''CHG  END  FKS)INABA 2007/02/28 *********************************************
        'CHG  END  FKS)INABA 2007/04/18 **********************************************

        F_JDNTRA_SBNNO_SEARCH = 0

END_F_JDNTRA_SBNNO_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Exit Function

ERR_F_JDNTRA_SBNNO_SEARCH:
        GoTo END_F_JDNTRA_SBNNO_SEARCH

    End Function

    Public Function F_Set_IDOET52() As Short
        RunMode = RUNMODE_IDOET52
        F_Set_IDOET52 = 0
    End Function

    Public Function F_Set_IDOET53() As Short
        RunMode = RUNMODE_IDOET53
        F_Set_IDOET53 = 0
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  対象項目のCHANGEの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Wk_CurMoji As String
        Dim Wk_Cnt As Short
        Dim Wk_EditMoji As String
        Dim Wk_DspMoji As String
        Dim Move_Flg As Boolean

        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        Select Case True
            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
                'ﾃｷｽﾄﾎﾞｯｸｽの場合
                '現在のﾃｷｽﾄ上の選択状態を取得
                '2019/06/20 CHG START
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText

                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/06/20 CHG END
                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

                '現在の値を取得
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

                Wk_EditMoji = ""

                Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                    Case IN_TYP_NUM
                        '数値項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                    Case IN_TYP_DATE
                        '日付項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
                    Case IN_TYP_CODE, IN_TYP_STR
                        'コード、文字項目
                        Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
                            '変更後の値変換
                            Case IN_STR_TYP_N
                                '全角の場合
                                '半角空白⇒全角空白
                                For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                    If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
                                        Wk_EditMoji = Wk_EditMoji & "　"
                                    Else
                                        Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                    End If
                                Next

                            Case Else
                                '全角以外
                                '半角空白⇒全角空白
                                For Wk_Cnt = 1 To Len(Wk_CurMoji)
                                    If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
                                        Wk_EditMoji = Wk_EditMoji & Space(2)
                                    Else
                                        Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
                                    End If
                                Next

                        End Select
                    Case IN_TYP_YYYYMM
                        '年月項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)

                    Case IN_TYP_HHMM
                        '時刻項目の場合
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)

                    Case Else
                End Select

                '編集後の文字を表示形式に変換
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)

                '選択文字と入力文字の置き換え
                '文字設定
                Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

                '現在ﾌｫｰｶｽ位置から右へ移動
                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)

            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox

            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton

            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox

        End Select

        '入力後処理
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

        '明細入力後の後処理
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Item_GotFocus
    '   概要：  対象項目のGOTFOCUSの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Move_Flg As Boolean

        If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
            'ﾌｫｰｶｽを受け取れない場合
            '元の項目へﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
        Else

            '移動前と異なる場合のみ退避
            If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
                '前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
                pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
                '移動後のｲﾝﾃﾞｯｸｽを退避
                pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
            End If

            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyPress
    '   概要：  対象項目のKEYPRESSの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim All_Sel_Flg As Boolean
        Dim wk_Moji As String
        Dim Wk_SelMoji As String
        Dim Wk_BefMoji As String
        Dim Wk_DelMoji As String
        Dim Wk_EditMoji As String
        Dim Wk_DspMoji As String
        Dim Wk_Cnt As Short
        Dim Wk_SelStart As Short
        Dim Wk_SelLength As Short
        Dim Wk_CurMoji As String
        Dim Input_Flg As Boolean
        Dim Re_Body_Crt As Boolean

        '移動フラグ初期化
        pm_Move_Flg = False

        '入力フラグ初期化
        Input_Flg = False
        '明細部再作成フラグ初期化
        Re_Body_Crt = False

        '以下の入力の場合、無視する
        Select Case pm_KeyAscii
            Case 1 To 7, 9 To 12, 14 To 29, 127
                Beep()
                pm_KeyAscii = 0
                Exit Function
        End Select

        '入力文字取得
        wk_Moji = Chr(pm_KeyAscii)

        'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then

            '現在のﾃｷｽﾄ上の選択状態を取得
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/06/20 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText

            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/20 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            '現在の値を取得
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

            All_Sel_Flg = False
            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                '全選択の場合（選択文字が最大バイト数と一致）
                All_Sel_Flg = True
            End If

            '入力コード判定
            If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
                '入力可能文字の場合

                '入力可能な文字の場合、入力後処理、明細部再作成を行う
                Input_Flg = True
                Re_Body_Crt = True

                'CF_Jge_Input_Str関数の文字変更を考慮
                pm_KeyAscii = Asc(wk_Moji)

                '日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
                '表示形式が決まっているため一つずつ入力させる
                Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                    Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                        If Act_SelLength <> 1 Then
                            Beep()
                            pm_KeyAscii = 0
                            Exit Function
                        End If
                End Select

                If All_Sel_Flg = True Then
                    '全選択時

                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                        '詰文字が左詰の場合
                        Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji

                    Else
                        '詰文字が左詰以外の場合
                        Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)

                    End If

                    '編集後の文字を表示形式に変換
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)

                    '編集後のSelStartを決定
                    If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                        '詰文字が左詰の場合
                        '右端へ移動
                        Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                        Wk_SelLength = 0
                    Else
                        '詰文字が左詰以外の場合
                        Wk_SelStart = 0
                        Wk_SelLength = 1
                    End If

                    '削除後の文字置き換え
                    '文字設定
                    Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                    pm_KeyAscii = 0

                    '編集後のSelStartを決定
                    ' ２文字以上入力すると１文字目が入力されない現象への対応
                    ' pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/06/20 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    ''編集後のSelLengthを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength

                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)

                    ' １桁項目で入力後にフォーカス移動しないことへの対応
                    '数値項目特別処理
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then

                        '小数部があり小数桁数と設定値が同じ場合
                        If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        Else
                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                        End If

                    Else
                        '数値項目以外
                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '編集後の文字がMAXの場合
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/06/20 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            ''編集後のSelLengthを決定
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '2019/06/20 CHG END
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If
                    End If

                Else
                    '部分選択もしくは、選択なし

                    If Act_SelLength = 0 Then
                        '選択なしの場合(挿入状態)
                        '挿入部分の前の文字を取得
                        Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            Select Case wk_Moji
                                Case "+"
                                    '｢＋｣入力時
                                    If Trim(Wk_BefMoji) <> "" Then
                                        '前文字が上記の文字以外は挿入できない
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If

                                Case "-"
                                    '｢－｣入力時
                                    If Trim(Wk_BefMoji) <> "" Then
                                        '前文字が上記の文字以外は挿入できない
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If

                                Case "."
                                    '｢．｣入力時
                                    If InStr(Wk_CurMoji, ".") > 1 Then
                                        'すでに｢．｣が入力されいる場合
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If
                            End Select
                        End If

                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '空白除去後の現在の文字がMAXの場合、オーバーフロー

                            '数値項目特別処理
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                '一番右でオーバーフローした場合、次の項目へ
                                If Act_SelStart >= Len(Wk_CurMoji) Then
                                    '編集前の開始位置が一番右の場合
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                Else
                                    '入力不可
                                    Beep()
                                End If
                            Else

                                '編集後の移動先を判定
                                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                                    '詰文字が左詰の場合
                                Else
                                    '編集後のSelStartを決定
                                    If Act_SelStart + 1 > Len(Wk_CurMoji) Then
                                        '１つ右の位置が右端の場合
                                        Wk_SelStart = Len(Wk_CurMoji)
                                    Else
                                        '１つ右へ
                                        Wk_SelStart = Act_SelStart + 1
                                    End If
                                    '編集後のSelLengthを決定
                                    Wk_SelLength = 0

                                    '編集後のSelStartを決定
                                    '2019/06/20 CHG START
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''編集後のSelLengthを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '2019/06/20 CHG END
                                End If

                                '入力不可
                                Beep()
                            End If

                            '入力不可
                            pm_KeyAscii = 0
                            Exit Function
                        End If

                        '文字編集
                        Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)

                        '編集後の文字を表示形式に変換
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)

                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '整数部で整数桁数より多く入力されている場合
                            If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                                '入力不可
                                pm_KeyAscii = 0
                                Exit Function
                            End If

                            '小数部があり小数桁数と設定値が同じ場合
                            If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                '入力不可
                                pm_KeyAscii = 0
                                Exit Function
                            End If
                        End If

                        '編集後のSelStartを決定
                        If Act_SelStart + 1 > Len(Wk_DspMoji) Then
                            '１つ右の位置が右端の場合
                            Wk_SelStart = Len(Wk_DspMoji)
                        Else
                            '１つ右へ
                            Wk_SelStart = Act_SelStart + 1
                        End If
                        '編集後のSelLengthを決定
                        Wk_SelLength = 0

                        '削除後の文字置き換え
                        '文字設定
                        Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                        pm_KeyAscii = 0

                        '編集後のSelStartを決定
                        '2019/06/20 CHG START
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/06/20 CHG END

                        '編集後の移動先を判定
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '詰文字が左詰の場合

                            If Wk_SelStart >= Len(Wk_DspMoji) Then
                                '編集後の開始位置が一番右の場合
                                '数値項目特別処理
                                If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                    '小数部があり小数桁数と設定値が同じ場合
                                    If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                        '現在ﾌｫｰｶｽ位置から右へ移動
                                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                    Else
                                        If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                            '編集後の文字がMAXの場合
                                            '現在ﾌｫｰｶｽ位置から右へ移動
                                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                        End If
                                    End If
                                Else
                                    '数値項目以外
                                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                        '編集後の文字がMAXの場合
                                        '現在ﾌｫｰｶｽ位置から右へ移動
                                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                    End If
                                End If
                            End If
                        Else
                            '詰文字が左詰以外の場合
                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合

                                '編集後のSelStartを決定
                                '2019/06/20 CHG START
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '2019/06/20 CHG END

                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                        End If
                    Else
                        '一部選択
                        '現在選択されている文字の１桁を取得
                        Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)

                        If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
                            '選択文字が空文字以外でかつ入力対象の文字以外の場合

                            '入力不可
                            Beep()
                            pm_KeyAscii = 0
                            Exit Function
                        End If

                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            Select Case wk_Moji
                                Case "+"
                                    '｢＋｣入力時
                                    If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
                                        '選択文字が上記の文字以外は置き換えられない
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If

                                Case "-"
                                    '｢－｣入力時
                                    If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
                                        '選択文字が上記の文字以外は置き換えられない
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If

                                Case "."
                                    '｢．｣入力時
                                    If InStr(Wk_CurMoji, ".") > 0 Then
                                        'すでに｢．｣が入力されいる場合
                                        '入力不可
                                        Beep()
                                        pm_KeyAscii = 0
                                        Exit Function
                                    End If
                            End Select
                        End If

                        '文字編集
                        Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)

                        '編集後の文字を表示形式に変換
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)

                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            '整数部無しの場合
                            '整数部ありで整数桁数より多く入力されている場合
                            If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                                '入力不可
                                pm_KeyAscii = 0
                                Exit Function
                            End If

                            '小数部があり小数桁数と設定値が同じ場合
                            If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                '現在ﾌｫｰｶｽ位置から右へ移動
                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                '入力不可
                                pm_KeyAscii = 0
                                Exit Function
                            End If
                        End If

                        If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
                            '編集前の開始位置が最後の文字以降の場合
                            '編集後のSelStartを決定
                            Wk_SelStart = Len(Wk_DspMoji)
                            '編集後のSelLengthを決定
                            Wk_SelLength = 0
                        Else
                            '編集後のSelStartを決定
                            Wk_SelStart = Act_SelStart
                            '編集後のSelLengthを決定
                            Wk_SelLength = 1
                        End If

                        '数値項目特別処理
                        If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                            If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
                                '入力可能な文字が１桁の場合
                                '開始位置を一番右に設定
                                '編集後のSelStartを決定
                                Wk_SelStart = Len(Wk_DspMoji)
                                '編集後のSelLengthを決定
                                Wk_SelLength = 0
                            End If

                        End If

                        '編集後の文字置き換え
                        '文字設定
                        Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                        pm_KeyAscii = 0

                        '編集後のSelStartを決定
                        '2019/06/20 CHG START
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/06/20 CHG END

                        '編集後の移動先を判定
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
                            '編集後の開始位置が最後の文字以降の場合
                            '数値項目特別処理
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then

                                '小数部があり小数桁数と設定値が同じ場合
                                If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                Else
                                    If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                        '編集後の文字がMAXの場合
                                        '現在ﾌｫｰｶｽ位置から右へ移動
                                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                    End If
                                End If

                            Else
                                '数値項目以外
                                If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                    '編集後の文字がMAXの場合
                                    '現在ﾌｫｰｶｽ位置から右へ移動
                                    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                                End If
                            End If
                        Else
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                        End If

                    End If
                End If

            Else
                '入力コード以外
                Select Case pm_KeyAscii
                    Case System.Windows.Forms.Keys.Back
                        'BackSpaceキー
                        pm_KeyAscii = 0
                        'ADD START FKS)INABA 2007/01/11 *************************************
                        'BackSpaceキー押下時の動作修正
                        Input_Flg = True
                        'ADD  END  FKS)INABA 2007/01/11 *************************************
                        '日付/年月/時刻の場合
                        Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                            Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                                '削除後のSelStartを決定
                                Wk_SelStart = Act_SelStart
                                For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
                                    '削現在の開始位置から左へ移動し文字が入力対象かを判定
                                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
                                        '入力文字でない場合
                                        Wk_SelStart = Wk_Cnt
                                        Exit For
                                    End If

                                Next
                                '編集後のSelLengthを決定
                                Wk_SelLength = Act_SelLength

                                '編集後のSelStartを決定
                                '2019/06/20 CHG START
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '2019/06/20 CHG END

                                '削除不可
                                Exit Function
                            Case Else

                        End Select

                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '詰文字が左詰の場合
                            '開始位置が左の場合、終了
                            If Act_SelStart = 0 Then
                                '削除不可
                                Exit Function
                            End If

                            '削除対象の文字１桁を取得
                            Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)

                            '数値項目特別処理
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                If Wk_DelMoji = "." Then
                                    '削除対象の文字が小数点の場合
                                    If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
                                        '削除後の桁数オーバーの場合
                                        '削除不可
                                        Exit Function
                                    End If
                                End If
                            End If

                            '削除文字の判定
                            If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
                                '削除文字が入力対象の文字の場合
                                If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                                    '文字編集
                                    Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
                                Else
                                    '削除対象がない為、空白を編集
                                    Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                                End If
                            Else
                                '削除文字が入力対象の文字の以外場合
                                'そのまま
                                Wk_EditMoji = Wk_CurMoji
                            End If

                            '削除後の文字を表示形式に変換
                            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)

                            '削除後のSelStartを決定
                            Wk_SelStart = Act_SelStart
                            For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
                                '削除後に現在の開始位置からの文字が入力対象かを判定
                                If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
                                    Exit For
                                End If
                                '入力文字でない場合、右へ移動
                                Wk_SelStart = Wk_SelStart + 1
                            Next
                            '編集後のSelLengthを決定
                            Wk_SelLength = Act_SelLength

                            '数値項目特別処理
                            If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
                                '数値項目で未入力の場合は、一番右を開始位置に設定
                                If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
                                    Wk_SelStart = Len(Wk_DspMoji)
                                    '編集後のSelLengthを決定
                                    Wk_SelLength = 0
                                End If
                            End If
                        Else
                            '詰文字が左詰以外の場合
                            If Act_SelStart = 0 Then
                                '開始位置が一番左の場合
                                If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
                                    '文字編集
                                    Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                                Else
                                    '削除対象がない為、空白を編集
                                    Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
                                End If

                                '削除後のSelStartを決定
                                Wk_SelStart = Act_SelStart
                            Else
                                '文字編集
                                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)

                                '削除後のSelStartを決定
                                Wk_SelStart = Act_SelStart - 1
                            End If
                            '編集後のSelLengthを決定
                            Wk_SelLength = Act_SelLength

                            '編集後の文字を表示形式に変換
                            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
                        End If

                        '削除後の文字置き換え
                        '文字設定
                        Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
                        '2019/06/20 CHG START
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/06/20 CHG END

                    Case Else
                        pm_KeyAscii = 0

                End Select
            End If
        End If

        If Input_Flg = True Then
            '入力後処理
            Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
        End If

        If Re_Body_Crt = True Then
            '明細入力後の後処理
            Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Item_MouseDown
    '   概要：  対象項目のMOUSEDOWNの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
        Dim Wk_Index As Short
        Dim bolSameCtl As Boolean

        If pm_Button = VB6.MouseButtonConstants.RightButton Then
            '右クリック

            bolSameCtl = False
            If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
                '右クリックしたコントロールがアクティブなコントロールと一致
                'カーソル制御用テキストにフォーカスを一時的に退避
                Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
                bolSameCtl = True
            End If

            '｢項目内容コピー｣判定
            FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)

            '｢項目内容に貼り付け｣判定
            FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)

            '対象コントロールの使用不可
            pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False

            '｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
            If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
                'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
                pm_All.Dsp_Base.LostFocus_Flg = True
                'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/06/20 CHG START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSMAIN.SM_ShortCut.Show()
                '2019/06/20 CHG END
                'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
                pm_All.Dsp_Base.LostFocus_Flg = False
                System.Windows.Forms.Application.DoEvents()
            End If

            'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
            '以降の処理は行わない。
            If pm_All.Dsp_Base.IsUnload = True Then
                Exit Function
            End If

            '対象コントロールの使用可
            pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
            'フォーカスを移動を元に戻す
            If bolSameCtl = True Then
                Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
            End If

        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_Dsp_Body_Page
    '   概要：  明細部分のページ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Dsp_Body_Page(ByRef pm_Page_Value As Short, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Cur_Top_Index As Short
        Dim Focus_Ctl_Ok_Fst_Idx As Short
        Dim Move_Flg As Boolean
        Dim Row_Move_Value As Short
        Dim Cur_Row As Short
        Dim Next_Row As Short
        Dim Next_Index As Short

        '最上明細ｲﾝﾃﾞｯｸｽを退避
        Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)
        '最上明細ｲﾝﾃﾞｯｸｽに設定
        '（画面表示明細数－１）×（画面移動量）＋１　　⇒１、６、１１、１６となる
        pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Move_Qty) * (pm_Page_Value - 1) + 1
        '画面表示
        Call CF_Body_Dsp(pm_All)

        'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
        If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then

            '現在の行を取得
            Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
            'ﾌｫｰｶｽ制御
            '移動量
            Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index

            '移動後の行
            Next_Row = Cur_Row + Row_Move_Value
            If Next_Row <= 0 Then
                Next_Row = 1
            End If
            If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
                Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
            End If

            '移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
            Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
            If Next_Index > 0 Then
                If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
                    '同一ｺﾝﾄﾛｰﾙの場合
                    '選択状態の設定（初期選択）
                    Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
                Else
                    '同一ｺﾝﾄﾛｰﾙでない場合
                    '同一項目の１つ前からENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If
            Else
                '入力可能な最初のインデックスを取得
                Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
                If Focus_Ctl_Ok_Fst_Idx > 0 Then
                    '同一項目の１つ前からENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else

                    If Row_Move_Value > 0 Then
                        '上へ移動
                        'ヘッダ部の最後の項目の１つ後ろから
                        '１つ前の項目へ
                        Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
                    Else
                        '下へ移動
                        'フッタ部の最初の項目の１つ前から
                        'ENTキー押下と同様に次の項目へ
                        Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                    End If
                End If
            End If
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
    '   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean

        Dim Trg_Index As Short
        Dim Move_Flg As Boolean
        Dim Focus_Ctl_Ok_Fst_Idx As Short

        '画面明細の行と同一の明細をインデックスを取得
        Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)

        If Trg_Index > 0 Then
            If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
                '移動先が同じ場合
                If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
                    '選択状態の設定（初期選択）
                    Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                Else
                    '次のコントロールを探す
                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                End If

            Else
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If

        Else
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_ClearDE
    '   概要：  メニューの明細初期化の制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Bd_Index As Short
        Dim Row_Wk As Short

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)

        'Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        '共通の明細初期化
        If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
            '業務の初期値を編集
            Call F_Init_Dsp_Body(Bd_Index, pm_All)

            '行Ｎｏ採番処理
            Call F_Edi_Saiban_No(pm_All)

            '画面表示
            Call CF_Body_Dsp(pm_All)

            '元の画面の行に移動
            Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index

            'フォーカス決定
            Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)

        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_DeleteDE
    '   概要：  メニューの明細削除の制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Bd_Index As Short
        Dim Row_Inf_Max_S As Short
        Dim Row_Inf_Max_E As Short
        Dim Bd_Index_Wk As Short
        Dim Row_Wk As Short

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)

        'Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        '共通の明細削除
        Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)

        '行を追加された後に
        '初期値を追加した行に対してループ内で１行ずつ行う
        'ここでの行は、Dsp_Body_Infの行！！
        For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
            Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
        Next

        '行Ｎｏ採番処理
        Call F_Edi_Saiban_No(pm_All)

        '画面表示
        Call CF_Body_Dsp(pm_All)

        '元の画面の行に移動
        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index

        'フォーカス決定
        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_InsertDE
    '   概要：  メニューの明細挿入の制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Bd_Index As Short
        Dim Bd_Index_Wk As Short
        Dim Ins_Bd_Index As Short
        Dim Row_Wk As Short

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)

        'Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        '共通の明細挿入
        If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
            '業務の初期値を編集
            Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)

            '行Ｎｏ採番処理
            Call F_Edi_Saiban_No(pm_All)

            '対象行を画面に表示
            Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)

            '追加行に移動
            Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)

            'フォーカス決定
            Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)

        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_UnDoDe
    '   概要：  メニューの明細復元の制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Bd_Index As Short
        Dim Row_Inf_Max_S As Short
        Dim Row_Inf_Max_E As Short
        Dim Bd_Index_Wk As Short
        Dim Row_Wk As Short

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)

        'Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        '共通の明細復元
        If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
            '行を追加された後に
            '初期値を追加した行に対してループ内で１行ずつ行う
            'ここでの行は、Dsp_Body_Infの行！！
            For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
                Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
            Next

            '行Ｎｏ採番処理
            Call F_Edi_Saiban_No(pm_All)

            '画面表示
            Call CF_Body_Dsp(pm_All)

            '元の画面の行に移動
            Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index

            'フォーカス決定
            Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)

        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Ctl_MN_Paste
    '   概要：  貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Clip_Value As String
        Dim Paste_Value As String

        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Wk_SelStart As Short
        Dim Wk_SelLength As Short
        Dim Wk_EditMoji As String
        Dim Wk_CurMoji As String
        Dim Wk_DspMoji As String

        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
        'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        Clip_Value = My.Computer.Clipboard.GetText()
        '入力文字可能を取り出す
        Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)

        '貼り付け内容がない場合、処理中断
        If Paste_Value = "" Then
            Exit Function
        End If

        '現在のﾃｷｽﾄ上の選択状態を取得
        '2019/06/20 CHG START
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/06/20 CHG END

        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
        '現在の値を取得
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)

        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
            '詰文字が左詰の場合

            '文字編集
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)

            '編集後のSelStartを決定
            '右端へ移動
            Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
            Wk_SelLength = 0
        Else
            '詰文字が左詰以外の場合

            If Act_SelLength = 0 Then
                '選択なしの場合(挿入状態)
                '文字編集
                Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
            Else
                '一部選択
                If Act_SelLength >= 2 Then
                    '２文字以上選択している場合は
                    '選択文字より後ろの文字もつける
                    '文字編集
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
                Else
                    '１文字以下選択している場合は
                    '選択文字以降は入れ換え
                    '文字編集
                    Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value

                End If

            End If

            '編集後のSelStartを決定
            '左端へ移動
            Wk_SelStart = 0
            Wk_SelLength = 1

        End If

        Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
            Case IN_TYP_DATE
                '日付の場合、入力形式が決まっている場合
                '日付入力形式の桁数だけ取得
                Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
            Case IN_TYP_YYYYMM
                '年月の場合、入力形式が決まっている場合
                '日付入力形式の桁数だけ取得
                Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
            Case IN_TYP_HHMM
                '時刻の場合、入力形式が決まっている場合
                '日付入力形式の桁数だけ取得
                Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
            Case Else

        End Select

        '編集後の文字を表示形式に変換
        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)

        'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
        Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

        '編集後のSelStartを決定
        '2019/06/20 CHG START
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        ''編集後のSelLengthを決定
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '2091/06/20 CHG END
        'ADD START FKS)INABA 2007/01/11 ******************************
        '入力後の後処理
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
        'ADD  END  FKS)INABA 2007/01/11 ******************************

        '明細入力後の後処理
        Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Edi_Saiban_No
    '   概要：  全明細の行ＮＯを設定する
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の処理　製品出庫登録に明細Noはない(H.Y.)
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
        Dim Wk_Index As Short
        Dim Bd_Index As Short

        ''H.Y.(9/20)S    Wk_Index = CInt(FR_SSSMAIN.BD_LINNO(0).Tag)
        ''    For Bd_Index = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
        ''        '【ＮＯ】１・２～を編集
        ''        '画面ボディ情報(pm_All.Dsp_Body_Inf)に編集
        ''        Call CF_Edi_Dsp_Body_Inf(Bd_Index _
        '''                               , pm_All.Dsp_Sub_Inf(Wk_Index) _
        '''                               , Bd_Index _
        '''                               , pm_All _
        '''                               , SET_FLG_DEF)
        ''H.Y.(9/20)E    Next

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Clr_Dsp_Body
    '   概要：  指定された明細の初期値を設定する
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
        Dim Wk_Index As Short

        '個別初期化
        '【製品コード】
        Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【型式】
        Wk_Index = CShort(FR_SSSMAIN.BD_HINNMA(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【品名】
        Wk_Index = CShort(FR_SSSMAIN.BD_HINNMB(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【数量】
        Wk_Index = CShort(FR_SSSMAIN.BD_UODSU(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【単位】
        Wk_Index = CShort(FR_SSSMAIN.BD_UNTNM(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【明細備考】
        Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)

        '【明細備考】
        Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
        Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Item_Input_Aft
    '   概要：  画面で項目入力された場合の後処理を行います
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean

        Dim Row_Inf_Max_S As Short
        Dim Row_Inf_Max_E As Short
        Dim Bd_Index As Short

        '明細の再作成を行う
        Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)

        '行を追加された後に
        '初期値を追加した行に対してループ内で１行ずつ行う
        'ここでの行は、Dsp_Body_Infの行！！
        For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
            Call F_Init_Dsp_Body(Bd_Index, pm_All)
        Next

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Befe_Focus
    '   概要：  前のフォーカス位置設定(LEFTなど)
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
        Dim Trg_Index As Short
        Dim Index_Wk As Short
        Dim Focus_Ctl_Ok_Fst_Idx As Short
        Dim Cur_Top_Index As Short
        Dim Focus_Ctl_Ok_Lst_Idx As Short

        '移動フラグ初期化
        pm_Move_Flg = False

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        '次の項目を検索
        For Index_Wk = Trg_Index - 1 To 1 Step -1

            If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
                'フッタ部からボディ部へ移動する場合
                '入力可能な最初のインデックスを取得
                Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
                If Focus_Ctl_Ok_Fst_Idx > 0 Then
                    Index_Wk = Focus_Ctl_Ok_Fst_Idx
                End If

            End If

            If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
                'ボディ部からヘッダ部へ移動する場合
                If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
                    '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合

                    '画面の内容を退避
                    Call CF_Body_Bkup(pm_All)
                    '移動可能行を一番上に表示した場合の最上明細インデックスを設定
                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                        '縦スクロールバーを設定
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                    End If
                    '画面ボディ情報の配列を再設定
                    Call CF_Dell_Refresh_Body_Inf(pm_All)
                    '画面表示
                    Call CF_Body_Dsp(pm_All)

                    '入力可能な最後のインデックスを取得
                    Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
                    If Focus_Ctl_Ok_Lst_Idx > 0 Then
                        Index_Wk = Focus_Ctl_Ok_Lst_Idx
                    End If

                End If
            End If

            'ﾌｫｰｶｽ移動がOK
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
                If pm_Run_Flg = True Then
                    '実行指定がある場合(基本あり)
                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
                End If
                '移動フラグ決定
                pm_Move_Flg = True
                Exit For
            End If
        Next

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Next_Focus
    '   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
        Dim Sta_Index As Short
        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Bd_Index As Short
        Dim Cur_Index As Short
        Dim HD_NHSADA_Index As Short
        Dim HD_NHSADB_Index As Short
        Dim HD_NHSADC_Index As Short
        Dim Focus_Ctl_Ok_Fst_Idx As Short
        Dim Focus_Ctl_Ok_Lst_Idx As Short
        Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
        Dim Cur_Top_Index As Short
        Dim intRet As Short
        Dim bolDspLstRow As Boolean

        bolDspLstRow = False

        Cur_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
        HD_NHSADA_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
        HD_NHSADB_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
        HD_NHSADC_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)

        '移動フラグ初期化
        pm_Move_Flg = False

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
            'ボディ部
            'Dsp_Body_Infの行ＮＯを取得
            Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

            '        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
            '        '最終準備行の場合
            '            '入力可能な最初のインデックスを取得
            '            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
            '
            '            If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
            '            '入力可能な最初の項目の場合
            '                'モードにより検索開始位置を決定
            '                Select Case pm_Mode
            '                    Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
            '                    'KEYRETURN、KEYDOWNの場合
            '                        '検索開始はフッタ部の最初の項目から
            '                        Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
            '
            '                    Case NEXT_FOCUS_MODE_KEYRIGHT
            '                    'KEYRIGHTの場合
            '                        '割当ｲﾝﾃﾞｯｸｽ取得
            '                        '検索開始は対象の項目の次
            '                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            '
            '                End Select
            '            Else
            '                '検索開始は対象の項目の次
            '                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            '            End If
            '
            '        Else
            '最終準備行以外の場合
            If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
                '表示されている最終行の場合
                '入力可能な最後のインデックスを取得
                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)

                If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
                    '入力可能な最後の項目の場合
                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                        '最終準備行以外＆画面上の最終行＆最終項目
                        '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合

                        '画面の内容を退避
                        Call CF_Body_Bkup(pm_All)
                        '移動可能行を一番下に表示した場合の最上明細インデックスを設定
                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                            '縦スクロールバーを設定
                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                        End If
                        '画面ボディ情報の配列を再設定
                        Call CF_Dell_Refresh_Body_Inf(pm_All)
                        '画面表示
                        Call CF_Body_Dsp(pm_All)
                        'コントロール制御
                        Call F_Set_Body_Enable(pm_All)

                        '明細１番下行の入力可能な最初のインデックスを取得
                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
                            '明細１番下行の最初の項目の一つ前から検索
                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
                            '画面上の最終表示明細の最終入力項目から
                            '次の項目へ移動する場合！！
                            bolDspLstRow = True
                        Else
                            '検索開始は対象の項目の次
                            Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                        End If

                    Else
                        '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
                        '検索開始は対象の項目の次
                        Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                    End If
                Else
                    '入力可能な最後の項目以外の場合
                    '検索開始は対象の項目の次
                    Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
                End If

            Else
                '最終行以外場合
                '検索開始は対象の項目の次
                Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
            End If
            '        End If

        Else
            'ボディ部以外
            '検索開始は対象の項目の次
            Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
        End If

        '次の項目を検索
        For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt

            If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
                'ヘッダ部からボディ部へ移動する場合
                'ﾍｯﾀﾞ部ﾁｪｯｸ
                If gv_bolInit = False Then
                    Rtn_Chk = F_Ctl_Head_Chk(pm_All)
                Else
                    Rtn_Chk = CHK_OK
                End If
                If Rtn_Chk <> CHK_OK Then
                    'チェックＮＧの場合
                    ' エンターキー連打による不具合修正2
                    'キーフラグを元に戻す
                    gv_bolKeyFlg = False
                    Exit For
                End If
            End If

            If Index_Wk = CShort(FR_SSSMAIN.TL_KKOUT.Tag) Then
                GoTo F_Set_Next_Focus_Skip01
                'DEL START FKS)INABA 2006/12/26 ***************************
                '        ElseIf (Cur_Index <> HD_NHSADA_Index And Cur_Index <> HD_NHSADB_Index And Cur_Index <> HD_NHSADC_Index) And _
                ''            (Index_Wk = HD_NHSADA_Index Or Index_Wk = HD_NHSADB_Index Or Index_Wk = HD_NHSADC_Index) Then
                '            GoTo F_Set_Next_Focus_Skip01
                'DEL  END  FKS)INABA 2006/12/26 ***************************
            End If

            'ﾌｫｰｶｽ移動がOK
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
                'D            If pm_Run_Flg = True Then
                'D            '実行指定がある場合(基本あり)
                If pm_Run_Flg = True Or bolDspLstRow = True Then
                    '以下のいずれかを満たす場合、フォーカス移動を行う。
                    '
                    '　①実行指定がある場合(基本あり)。
                    '　②画面上の最終表示明細の最終入力項目から次の項目へ移動する場合。
                    '
                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
                End If
                '移動フラグ決定
                pm_Move_Flg = True
                '画面上の最終表示明細の最終入力項目から次の項目へ移動する場合は、
                '移動フラグを立てない。
                '（Ctl_Item_KeyPressから再度本関数が呼ばれるのを回避するため）
                If bolDspLstRow = True Then
                    pm_Move_Flg = False
                End If
                Exit For
            End If

F_Set_Next_Focus_Skip01:

        Next

        '最終項目まで検索終了時
        If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
            'モードにより検索終了後の処理を決定
            Select Case pm_Mode
                Case NEXT_FOCUS_MODE_KEYRETURN
                    'KEYRETURNの場合
                    '移動先が検索不可の場合
                    '更新前チェック⇒ＤＢ更新⇒初期化
                    intRet = F_Ctl_Upd_Process(pm_All)
                    If intRet = 0 Then
                        '画面初期化
                        Call F_Init_BodyOnly(pm_All)
                    End If
                    pm_Move_Flg = True
                Case NEXT_FOCUS_MODE_KEYRIGHT
                    'KEYRIGHTの場合
                    '検索開始項目で選択状態が移動する
                    '選択状態の設定（初期選択）
                    Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
                Case NEXT_FOCUS_MODE_KEYDOWN
                    'KEYDOWNの場合

            End Select
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Left_Next_Focus
    '   概要：  Left押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
        Dim Index_Wk As Short
        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Str_Wk As String
        Dim Wk_Point As Short
        Dim Wk_SelStart As Short
        Dim Wk_SelLength As Short

        '移動フラグ初期化
        pm_Move_Flg = False

        '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '現在のﾃｷｽﾄ上の選択状態を取得
            '2019/06/20 CHG START
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/20 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                '全選択の場合（選択文字が最大バイト数と一致）
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '１文字目を選択する
                    '2019/06/20 CHG START
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '2019/06/20 CHG END
                Else
                    '詰文字が左詰以外の場合
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)

                End If
            Else
                If Act_SelStart = 0 Then
                    '開始位置が一番左の場合
                    '１つ前の項目へ
                    Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
                Else

                    '左に１桁ずつずらし入力可能な文字を検索
                    Wk_SelStart = -1
                    For Wk_Point = Act_SelStart - 1 To 0 Step -1
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
                        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                            Wk_SelStart = Wk_Point
                            Exit For
                        End If
                    Next

                    If Wk_SelStart = -1 Then
                        '選択可能な文字がない場合
                        '１つ前の項目へ
                        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
                    Else
                        '選択可能な文字がある場合
                        If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
                            '移動前の選択開始位置が一番右以外でかつ
                            '選択文字数がない場合のみ、
                            '同じ項目で移動する場合に選択文字数は継続する
                            Wk_SelLength = 0
                        Else
                            Wk_SelLength = 1
                        End If
                        '2019/06/20 CHG START
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/06/20 CHG END
                    End If

                End If
            End If
        Else
            '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
            '１つ前の項目へ
            Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Right_Next_Focus
    '   概要：  Right押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
        Dim Index_Wk As Short
        Dim Act_SelStart As Short
        Dim Act_SelLength As Short
        Dim Act_SelStr As String
        Dim Act_SelStrB As Integer
        Dim Str_Wk As String
        Dim Next_SelStart As Short
        Dim Wk_Point As Short
        Dim Wk_SelLength As Short

        '移動フラグ初期化
        pm_Move_Flg = False

        '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '現在のﾃｷｽﾄ上の選択状態を取得
            '2019/06/20 CHG START
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/06/20 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)

            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                '全選択の場合（選択文字が最大バイト数と一致）
                If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '最終文字を選択する
                    '2019/06/20 CHG STAT
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '2019/06/20 CHG END
                Else
                    '詰文字が左詰以外の場合
                    '１桁目を選択する
                    '2019/06/20 CHG START
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '2019/06/20 CHG END
                End If
            Else
                If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
                    '選択開始位置が一番右の場合
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                Else
                    '選択開始位置が一番右でない場合

                    '１つ右の１桁を取得
                    'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)

                    If Str_Wk = "" Then
                        '次の１桁がない場合
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '詰文字が左詰の場合
                            '一番右へ移動し選択なし状態に
                            '2019/06/20 CHG START
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '2019/06/20 CHG END
                        Else
                            '詰文字が左詰以外の場合
                            If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '一番右へ移動し選択なし状態に
                                '2019/06/20 CHG START
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '2019/06/20 CHG END
                            Else
                                'ENTキー押下と同様に次の項目へ
                                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                            End If
                        End If
                    Else

                        '右に１桁ずつずらし入力可能な文字を検索
                        Next_SelStart = -1
                        For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1

                            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)

                            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
                                Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
                                    '日付/年月/時刻項目の場合
                                    '入力可能文字＆と空白も移動可能
                                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
                                        Next_SelStart = Wk_Point
                                        Exit For
                                    End If
                                Case Else
                                    '日付/年月/時刻項目以外の場合
                                    If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
                                        Next_SelStart = Wk_Point
                                        Exit For
                                    End If

                            End Select
                        Next

                        If Next_SelStart = -1 Then
                            '選択可能な文字がない場合
                            'ENTキー押下と同様に次の項目へ
                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
                        Else
                            '選択可能な文字がある場合

                            If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '同じ項目で移動する場合に選択文字数は継続する
                                Wk_SelLength = 0
                            Else
                                Wk_SelLength = 1
                            End If
                            '2019/06/20 CHG START
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '2019/06/20 CHG END
                        End If
                    End If
                End If

            End If
        Else
            '現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
            'ENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Down_Next_Focus
    '   概要：  Down押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
        Dim Trg_Index As Short
        Dim Index_Wk As Short
        Dim Next_Index As Short
        Dim Wk_Cnt As Short
        Dim Cur_Top_Index As Short
        Dim Focus_Ctl_Ok_Fst_Idx As Short

        '移動フラグ初期化
        pm_Move_Flg = False

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
        Exit Function

        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
            '明細部の場合
            Wk_Cnt = 0
            Do
                Wk_Cnt = Wk_Cnt + 1
                '現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
                Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)

                If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
                    '項目数を超えた場合
                    'ENTキー押下と同様に次の項目へ
                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                    Exit Do
                End If

                If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
                    '移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
                    If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
                        'ﾌｫｰｶｽ受取ＯＫ
                        '同一列に移動
                        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
                        pm_Move_Flg = True
                        Exit Do
                    End If
                Else
                    '次の項目名が明細部でない場合
                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
                        '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
                        '画面の内容を退避
                        Call CF_Body_Bkup(pm_All)
                        '移動可能行を一番下に表示した場合の最上明細インデックスを設定
                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
                            '縦スクロールバーを設定
                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
                        End If
                        '画面ボディ情報の配列を再設定
                        Call CF_Dell_Refresh_Body_Inf(pm_All)
                        '画面表示
                        Call CF_Body_Dsp(pm_All)
                        '明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
                        Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                        If Next_Index > 0 Then
                            If Next_Index = Trg_Index Then
                                '同一ｺﾝﾄﾛｰﾙの場合
                                '移動無しで終了
                                pm_Move_Flg = False
                                Exit Do
                            Else
                                '同一ｺﾝﾄﾛｰﾙでない場合
                                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                                Exit Do
                            End If
                        Else
                            '入力可能な最初のインデックスを取得
                            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
                            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                                Exit Do
                            Else
                                'フッタ部の最初の項目の１つ前から
                                'ENTキー押下と同様に次の項目へ
                                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                                Exit Do
                            End If
                        End If

                    Else
                        '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
                        'フッタ部の最初の項目の１つ前から
                        'ENTキー押下と同様に次の項目へ
                        Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
                        Exit Do
                    End If
                End If
            Loop

        Else
            '明細部以外の場合
            'ENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Up_Next_Focus
    '   概要：  Up押下時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
        Dim Trg_Index As Short
        Dim Index_Wk As Short
        Dim Next_Index As Short
        Dim Wk_Cnt As Short
        Dim Cur_Top_Index As Short
        Dim Focus_Ctl_Ok_Fst_Idx As Short

        '移動フラグ初期化
        pm_Move_Flg = False

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        ' 明細行は１行しかないので、明細部かどうかに関係なく一つ前の項目に戻る (H.Y. 9/21)
        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
        Exit Function

        ''H.Y.(9/21)S    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
        ''    '明細部の場合
        ''        Wk_Cnt = 0
        ''        Do
        ''            Wk_Cnt = Wk_Cnt + 1
        ''            '現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
        ''            Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
        ''
        ''            If Next_Index < 0 Then
        ''                'マイナスの場合
        ''                '１つ前の項目へ
        ''                Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
        ''                Exit Do
        ''            End If
        ''
        ''            If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD _
        '''            And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.NAME = pm_Dsp_Sub_Inf.Ctl.NAME Then
        ''            '移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
        ''                If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
        ''                'ﾌｫｰｶｽ受取ＯＫ
        ''                    '同一列に移動
        ''                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
        ''                    pm_Move_Flg = True
        ''                    Exit Do
        ''                End If
        ''            Else
        ''            '次の項目名が明細部でない場合
        ''                If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
        ''                '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
        ''                    '画面の内容を退避
        ''                    Call CF_Body_Bkup(pm_All)
        ''                    '移動可能行を一番上に表示した場合の最上明細インデックスを設定
        ''                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
        ''                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
        ''                        '縦スクロールバーを設定
        ''                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        ''                    End If
        ''                    '画面ボディ情報の配列を再設定
        ''                    Call CF_Dell_Refresh_Body_Inf(pm_All)
        ''                    '画面表示
        ''                    Call CF_Body_Dsp(pm_All)
        ''                    '明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
        ''                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
        ''                    If Next_Index > 0 Then
        ''                        If Next_Index = Trg_Index Then
        ''                        '同一ｺﾝﾄﾛｰﾙの場合
        ''                            '移動無しで終了
        ''                            pm_Move_Flg = False
        ''                            Exit Do
        ''                        Else
        ''                        '同一ｺﾝﾄﾛｰﾙでない場合
        ''                            '同一項目の１つ後ろから
        ''                            '１つ前の項目へ
        ''                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
        ''                            Exit Do
        ''                        End If
        ''                    Else
        ''                        '入力可能な最初のインデックスを取得
        ''                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
        ''                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
        ''                            '入力可能な最初の項目の１つ後ろから
        ''                            '１つ前の項目へ
        ''                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
        ''                            Exit Do
        ''                        Else
        ''                            'ヘッダ部の最後の項目の１つ後ろから
        ''                            '１つ前の項目へ
        ''                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
        ''                            Exit Do
        ''
        ''                        End If
        ''                    End If
        ''                Else
        ''                    'ヘッダ部の最後の項目の１つ後ろから
        ''                    '１つ前の項目へ
        ''                    Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
        ''                    Exit Do
        ''                End If
        ''
        ''            End If
        ''        Loop
        ''    Else
        ''    '明細部以外の場合
        ''        '１つ前の項目へ
        ''        Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
        ''H.Y.(9/21)E    End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Clr_Dsp
    '   概要：  各画面の項目を初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short
        Dim Wk_Index_S As Short
        Dim Wk_Index_E As Short
        Dim Now_Dt As Date
        Dim Wk_Mode As Short
        Dim Init_WK As IDOET52_TYPE_SBNTRA
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim intRet As Short

        Now_Dt = Now

        If pm_Index = -1 Then
            Wk_Index_S = 1
            Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
            pm_All.Dsp_Base.Head_Ok_Flg = False
            Wk_Mode = ITM_ALL_CLR
        Else
            Wk_Index_S = pm_Index
            Wk_Index_E = pm_Index
            Wk_Mode = ITM_ALL_ONLY
        End If

        For Index_Wk = Wk_Index_S To Wk_Index_E

            '共通初期化
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)

            '全体初期化の場合
            If Wk_Mode = ITM_ALL_CLR Then
                'フッタ部以降の項目を全ﾌｫｰｶｽなしとする
                '' 緊急出庫チェックボックスはフッタ部分にある、という扱いにするので、これだけフォーカス可。(H.Y. 9/21)
                If Index_Wk >= pm_All.Dsp_Base.Foot_Fst_Idx Then
                    If Index_Wk <> CShort(FR_SSSMAIN.TL_KKOUT.Tag) Then ' 緊急出庫チェックボックスを除いて (H.Y. 9/21)
                        Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
                    End If
                End If
            End If
            '        '個別初期化
            '        Select Case Index_Wk
            '            Case CInt(FR_SSSMAIN.HD_DENDT.Tag)
            '                '出庫日
            '                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All, SET_FLG_DB)
            '        End Select

        Next

        '全初期化の場合、画面情報保持用の構造体をクリアする
        If Wk_Mode = ITM_ALL_CLR Then
            'UPGRADE_WARNING: オブジェクト IDOET52_SBNTRA_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf = Init_WK
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Clr_Dsp_Body
    '   概要：  各画面のボディ項目を初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short

        Dim Index_Bd_Wk As Short
        Dim Wk_Bd_Index_S As Short
        Dim Wk_Bd_Index_E As Short
        Dim Wk_Mode As Short
        Dim Wk_Index As Short
        Dim Wk_Row As Short

        If pm_Bd_Index = -1 Then
            Wk_Bd_Index_S = 1
            Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt

            '画面ボディ情報
            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)

            ''H.Y.(9/20)S        'スクロール初期化
            ''        '最大値
            ''        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
            ''        '最小値
            ''        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
            ''        '最大ｽｸﾛｰﾙ量
            ''        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
            ''        '最小ｽｸﾛｰﾙ量
            ''        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
            ''        '初期値
            ''H.Y.(9/20)E        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All, SET_FLG_DEF)
            Wk_Mode = BODY_ALL_CLR
        Else
            Wk_Bd_Index_S = pm_Bd_Index
            Wk_Bd_Index_E = pm_Bd_Index
            Wk_Mode = BODY_ALL_ONLY
        End If

        For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E

            '共通初期化
            Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)

            '配列０の初期情報を対象行にコピー
            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))

            '全体初期化の場合
            If Wk_Mode = BODY_ALL_CLR Then
                '全行初期状態
                pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
            End If

            '個別初期化
            '以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
            '(対象の明細の番号情報だけが必要、)
            ''H.Y.(9/20)        Wk_Index = CInt(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
            Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(Index_Bd_Wk).Tag) ''H.Y.(9/20)
            'Dsp_Body_Infの行ＮＯに変換
            Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
            'Dsp_Body_Infに値を初期値を設定
            Call F_Init_Dsp_Body(Wk_Row, pm_All)

        Next

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Cursor_Set
    '   概要：  画面初期状態時のフォーカス位置設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short

        '各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
        '案件ＩＤにフォーカス設定
        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_DENDT.Tag)

        'ﾌｫｰｶｽ移動
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '選択状態の設定（初期選択）
        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
        '項目色設定
        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_Jge_Action
    '   概要：  各チェック関数のチェック前の
    '　　　　　 チェック続行を判定
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_From_Process　　　 :呼出元処理
    '           pm_Err_Rtn　　     　 :エラー戻値
    '           pm_Msg_Flg　　     　 :メッセージフラグ
    '           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
        Dim Rtn_Cd As Short

        '続行
        Rtn_Cd = CHK_KEEP

        Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
            Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    '前回と同じチェック内容の場合
                    If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                        '項目のステータスがエラーなし
                        '中断
                        Rtn_Cd = CHK_STOP
                        'メッセージ非表示
                        pm_Msg_Flg = False
                        '移動可
                        pm_Move = True
                        'チェックＯＫ
                        pm_Err_Rtn = CHK_OK
                    End If
                End If

            Case CHK_FROM_KEYPRESS
                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    '前回と同じチェック内容の場合
                    If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                        '項目のステータスがエラーなし
                        '中断
                        Rtn_Cd = CHK_STOP
                        'メッセージ非表示
                        pm_Msg_Flg = False
                        '移動可
                        pm_Move = True
                        'チェックＯＫ
                        pm_Err_Rtn = CHK_OK
                    End If

                End If

            Case CHK_FROM_KEYRETURN
                '｢KEYRETURN｣
                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    '前回と同じチェック内容の場合
                    If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
                        '項目のステータスがエラーなし
                        '中断
                        Rtn_Cd = CHK_STOP
                        'メッセージ非表示
                        pm_Msg_Flg = False
                        '移動可
                        pm_Move = True
                        'チェックＯＫ
                        pm_Err_Rtn = CHK_OK
                    End If

                End If

            Case CHK_FROM_ALL_CHK
                '一括チェックなど｣
                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    '前回と同じチェック内容の場合
                    If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
                        '項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
                        '中断
                        Rtn_Cd = CHK_STOP
                        'メッセージ非表示
                        pm_Msg_Flg = False
                        '移動可
                        pm_Move = True
                        'チェックＯＫ
                        pm_Err_Rtn = CHK_OK
                    End If

                End If

        End Select

        If Rtn_Cd = CHK_STOP Then
            'チェックを中断
            'チェック関数呼出元処理をクリア
            pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
        End If

        F_Chk_Jge_Action = Rtn_Cd

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_Jge_Msg_Move
    '   概要：  各チェック関数のチェック後の
    '　　　　　 メッセージ、ステータス、移動制御
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_From_Process　　　 :呼出元処理
    '           pm_Err_Rtn　　     　 :エラー戻値
    '           pm_Msg_Flg　　     　 :メッセージフラグ
    '           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short

        'メッセージ表示なし
        pm_Msg_Flg = False
        '移動可
        pm_Move = True

        If pm_Err_Rtn = CHK_OK Then
            'チェックＯＫ
            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
        Else

            Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
                Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
                    Select Case pm_Err_Rtn
                        Case CHK_ERR_NOT_INPUT
                            '必須入力で未入力
                            If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                                '１度も未入力以外チェックをしていない場合
                                'チェックＯＫとする
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                                pm_Err_Rtn = CHK_OK
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            Else
                                '１度でも未入力チェックをしている場合
                                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                                    '前回と同じチェック内容の場合
                                    'チェックエラーとする
                                    pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                    'メッセージ出力なし
                                    pm_Msg_Flg = False
                                    '移動ＯＫ
                                    pm_Move = True
                                Else
                                    '前回と異なるチェック内容の場合
                                    'チェックエラーとする
                                    pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                    'メッセージ出力なし
                                    pm_Msg_Flg = False
                                    '移動ＯＫ
                                    pm_Move = False
                                End If

                            End If
                        Case CHK_ERR_ELSE
                            'その他エラー時
                            'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                                '前回と同じチェック内容の場合
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            Else
                                '前回と異なるチェック内容の場合
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                                'メッセージ出力あり
                                pm_Msg_Flg = True
                                '移動ＯＫ
                                pm_Move = False
                            End If

                    End Select

                Case CHK_FROM_KEYPRESS
                    Select Case pm_Err_Rtn
                        Case CHK_ERR_NOT_INPUT
                            '必須入力で未入力
                            If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                                '１度も未入力以外チェックをしていない場合
                                'チェックＯＫとする
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                                pm_Err_Rtn = CHK_OK
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            Else
                                '１度でも未入力チェックをしている場合
                                'チェックエラーとする
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            End If
                        Case CHK_ERR_ELSE
                            'その他エラー時
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＮＧ
                            pm_Move = False

                    End Select

                Case CHK_FROM_KEYRETURN
                    '｢KEYRETURN｣
                    Select Case pm_Err_Rtn
                        Case CHK_ERR_NOT_INPUT
                            '必須入力で未入力
                            If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
                                '１度も未入力以外チェックをしていない場合
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
                                pm_Err_Rtn = CHK_OK
                                'メッセージ出力なし
                                pm_Msg_Flg = False
                                '移動ＯＫ
                                pm_Move = True
                            Else
                                '１度でも未入力チェックをしている場合
                                pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                                'メッセージ出力あり
                                pm_Msg_Flg = True
                                '移動ＮＧ
                                pm_Move = False
                            End If

                        Case CHK_ERR_ELSE
                            'その他エラー時
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＮＧ
                            pm_Move = False

                    End Select
                Case CHK_FROM_ALL_CHK

                    Select Case pm_Err_Rtn
                        Case CHK_ERR_NOT_INPUT
                            '必須入力で未入力
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＮＧ
                            pm_Move = False

                        Case CHK_ERR_ELSE
                            'その他エラー時
                            pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
                            'メッセージ出力あり
                            pm_Msg_Flg = True
                            '移動ＮＧ
                            pm_Move = False

                    End Select

            End Select

        End If

        'チェック関数呼出元処理をクリア
        pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_DENDT
    '   概要：  受注日のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_DENDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        'ADD START FKS)INABA 2007/06/07 ******************
        Dim lb_KKOUT As Boolean
        'UPGRADE_WARNING: 構造体 Mst_Inf_SYSTBA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA

        'ADD START FKS)INABA 2007/06/07 ******************

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_DENDT = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            Retn_Code = CHK_ERR_NOT_INPUT
            Err_Cd = ""
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_039 '入力範囲外
            Else
                ''CHG START FKS)INABA 2007/06/07 *************************************************************
                '            lb_KKOUT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.TL_KKOUT.Tag)))
                '            If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
                '                Exit Function
                '            End If
                '
                '            If lb_KKOUT = True Then '緊急出荷の場合
                '                '運用日より古い日付はエラー
                '                If Input_Value > GV_UNYDate Or Input_Value <= Mst_Inf_SYSTBA.UKSMEDT Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_001          '入力範囲外
                '                Else
                '                    'ＯＫ
                '                    Retn_Code = CHK_OK
                '                    pm_Chk_Move = True
                '
                '                    ' 権限の考慮の追加、部門の適用日の考慮対応
                '                    '入力担当者情報の再取得を行う
                '                    Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf, Input_Value)
                '                    Call F_Set_Body_Enable(pm_All)
                '                End If
                '            Else
                '                '運用日より古い日付はエラー
                '                If Input_Value < GV_UNYDate Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_001          '入力範囲外
                '                Else
                '                    'ＯＫ
                '                    Retn_Code = CHK_OK
                '                    pm_Chk_Move = True
                '
                '                    ' 権限の考慮の追加、部門の適用日の考慮対応
                '                    '入力担当者情報の再取得を行う
                '                    Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf, Input_Value)
                '                    Call F_Set_Body_Enable(pm_All)
                '                End If
                '            End If
                '
                ''            '運用日より古い日付はエラー
                ''            If Input_Value < GV_UNYDate Then
                ''                Retn_Code = CHK_ERR_ELSE
                ''                Err_Cd = gc_strMsgIDOET52_E_001          '入力範囲外
                ''            Else
                ''                'ＯＫ
                ''                Retn_Code = CHK_OK
                ''                pm_Chk_Move = True
                ''
                ''                ' 権限の考慮の追加、部門の適用日の考慮対応
                ''                '入力担当者情報の再取得を行う
                ''                Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf, Input_Value)
                ''                Call F_Set_Body_Enable(pm_All)
                ''            End If
                ''CHG  END  FKS)INABA 2007/06/07 *************************************************************

            End If
        End If

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_DENDT = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_JDNNO
    '   概要：  参照受注番号のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_JDNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Trn_Inf As TYPE_DB_JDNTRA
        'ADD START FKS)INABA 2006/11/21 *************************************************
        Dim Trn_Inf_TH As TYPE_DB_JDNTHA
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim Wk_Index As Short
        Dim Bd_Index As Short
        'ADD START FKS)INABA 2006/11/21 *************************************************
        Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
        Dim Mst_Inf_NHSMTA As TYPE_DB_NHSMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Trg_Index As Short

        Dim Retn_Code2 As Short
        Dim Mst_Inf_SBNMTA As TYPE_DB_SBNMTA

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_JDNNO = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then
                'DEL START FKS)INABA 2006/12/05 *********************
                '受注番号は必須ではない（本山氏より）
                'ADD START FKS)INABA 2007/01/20 ********************************************************
                'CHG START FKS)INABA 2007/01/26 ********************************************************
                Retn_Code = CHK_ERR_NOT_INPUT
                '        If RunMode = RUNMODE_IDOET52 Then
                '            Select Case Trim$(IDOET52_SBNTRA_Inf.OUTRYCD)
                '                Case "01", "02", "03"
                '                    Retn_Code = CHK_ERR_NOT_INPUT
                '                Case Else
                '            End Select
                '        End If
                'CHG  END  FKS)INABA 2007/01/20 ********************************************************
                'ADD  END  FKS)INABA 2007/01/20 ********************************************************
                '            Retn_Code = CHK_ERR_NOT_INPUT
                'DEL START FKS)INABA 2006/12/05 *********************
            End If
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'トランチェック
                'CHG STRAT FKS)INABA 2007/03/14 ***********************************************
                If F_DSPJDNTRA_SEARCH(Trim(Input_Value), Trn_Inf, Trn_Inf_TH) = 0 Then
                    ''CHG START FKS)INABA 2006/11/21 *************************************************
                    '            If F_DSPJDNTRA_SEARCH(Input_Value, Trn_Inf, Trn_Inf_TH) = 0 Then
                    ''            If F_DSPJDNTRA_SEARCH(Input_Value, Trn_Inf, Trn_Inf_TH) = 0 Then
                    ''CHG  end  FKS)INABA 2006/11/21 *************************************************
                    'CHG  END  FKS)INABA 2007/03/14 ***********************************************
                    Retn_Code = CHK_OK
                    pm_Chk_Move = True
                    If RunMode <> RUNMODE_IDOET52 Then
                        Exit Function
                    End If
                    '取得項目格納
                    'CHG START FKS)INABA 2006/11/20 *******************************************************
                    '       IDOET52_SBNTRA_Inf.SBNNO = Input_Value                  ' 製番
                    IDOET52_SBNTRA_Inf.SBNNO = Trn_Inf.SBNNO ' 製番
                    IDOET52_SBNTRA_Inf.TOKCD = Trn_Inf_TH.TOKCD ' 得意先コード
                    IDOET52_SBNTRA_Inf.TOKRN = Trn_Inf_TH.TOKRN ' 得意先名
                    IDOET52_SBNTRA_Inf.NHSCD = Trn_Inf_TH.NHSCD ' 納入先コード
                    IDOET52_SBNTRA_Inf.NHSNMA = Trn_Inf_TH.NHSNMA '納入先名称１
                    IDOET52_SBNTRA_Inf.NHSNMB = Trn_Inf_TH.NHSNMB '納入先名称２
                    IDOET52_SBNTRA_Inf.NHSADA = Trn_Inf_TH.NHSADA '納入先住所１
                    IDOET52_SBNTRA_Inf.NHSADB = Trn_Inf_TH.NHSADB '納入先住所２
                    IDOET52_SBNTRA_Inf.NHSADC = Trn_Inf_TH.NHSADC '納入先住所３
                    IDOET52_SBNTRA_Inf.BINCD = Trn_Inf_TH.BINCD '便コード
                    If DSPMEIM_SEARCH("002", IDOET52_SBNTRA_Inf.BINCD, Mst_Inf) = 0 Then
                        IDOET52_SBNTRA_Inf.BINNM = Mst_Inf.MEINMA '便名
                    Else
                        IDOET52_SBNTRA_Inf.BINNM = "" '便名
                    End If
                    'ADD START FKS)INABA 2007/01/11 *************************************************
                    IDOET52_SBNTRA_Inf.CLMDL = Trn_Inf.CLMDL
                    IDOET52_SBNTRA_Inf.REGDT = Trn_Inf_TH.REGDT
                    IDOET52_SBNTRA_Inf.J_BMNCD = Trn_Inf_TH.BUMCD
                    'ADD  END  FKS)INABA 2007/01/11 *************************************************

                    '画面ボディ部初期化
                    Call F_Init_Clr_Dsp_Body(-1, pm_All)
                    Bd_Index = 1

                    '【製品コード】
                    Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Item(Trn_Inf.HINCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
                    pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA = Trn_Inf.HINCD
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)

                    '【型式】
                    Wk_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Item(Trn_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
                    pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA = Trn_Inf.HINNMA
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
                    '【品名】
                    Wk_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Item(Trn_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
                    pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMB = Trn_Inf.HINNMB
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
                    '【数量】
                    Wk_Index = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Item(Trn_Inf.UODSU, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
                    pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = CStr(Trn_Inf.UODSU)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)

                    '【単位名】
                    Wk_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Item(Trn_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
                    pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UNTNM = Trn_Inf.UNTNM
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
                    '''
                    '                IDOET52_SBNTRA_Inf.TOKCD = Trn_Inf.TOKCD            ' 得意先コード
                    '                IDOET52_SBNTRA_Inf.NHSCD = Trn_Inf.NHSCD            ' 納入先コード
                    '                ' 得意先
                    '                If DSPTOKCD_SEARCH(IDOET52_SBNTRA_Inf.TOKCD, Mst_Inf_TOKMTA) = 0 Then
                    '                    IDOET52_SBNTRA_Inf.TOKRN = Mst_Inf_TOKMTA.TOKRN
                    '                Else
                    '                    IDOET52_SBNTRA_Inf.TOKRN = ""
                    '                End If
                    '                ' 納入先
                    '                If DSPNHSCD_SEARCH(IDOET52_SBNTRA_Inf.NHSCD, Mst_Inf_NHSMTA) = 0 Then
                    '                    IDOET52_SBNTRA_Inf.NHSNMA = Mst_Inf_NHSMTA.NHSNMA
                    '                    IDOET52_SBNTRA_Inf.NHSNMB = Mst_Inf_NHSMTA.NHSNMB
                    '                Else
                    '                    IDOET52_SBNTRA_Inf.NHSNMA = ""
                    '                    IDOET52_SBNTRA_Inf.NHSNMB = ""
                    '                End If
                    'CHG  END  FKS)INABA 2006/11/20 *******************************************************
                Else
                    'CHG START FKS)INABA 2007/01/25 *******************************************************
                    Retn_Code2 = DSPSBNM_SEARCH(Input_Value, Mst_Inf_SBNMTA) ' 製番を製番マスタと照合する
                    If Retn_Code2 <> 0 Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                    End If
                    'CHG  END  FKS)INABA 2007/01/25 *******************************************************
                    '                Retn_Code = CHK_ERR_ELSE
                    '                Err_Cd = gc_strMsgIDOET52_E_009          '該当データなし
                End If

            End If

        End If

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_JDNNO = Retn_Code

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_JDNNO_Inf
    '   概要：  見積番号による画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_JDNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_HD_OUTRYCD As String

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                'ADD START FKS)INABA 2006/11/20 ************************************************************************
                'CHG START FKS)INABA 2007/01/20 ************************************************************************
                'CHG START FKS)INABA 2007/01/26 ************************************************************************

                If RunMode = RUNMODE_IDOET52 Then
                    If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then
                        Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
                        Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                    Else
                        Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                        Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                    End If
                Else
                    Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                End If
                '            Trg_Index = CInt(FR_SSSMAIN.HD_OUTRYCD.Tag)
                '            Wk_HD_OUTRYCD = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.OUTRYCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '            If RunMode = RUNMODE_IDOET52 Then
                '                If Wk_HD_OUTRYCD <> "01" And Wk_HD_OUTRYCD <> "02" Then
                '                    Trg_Index = CInt(FR_SSSMAIN.HD_SBNNO.Tag)
                '                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '                Else
                '                    Trg_Index = CInt(FR_SSSMAIN.HD_SBNNO.Tag)
                '                    Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '                End If
                '            Else
                '                Trg_Index = CInt(FR_SSSMAIN.HD_SBNNO.Tag)
                '                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '            End If
                ''            Trg_Index = CInt(FR_SSSMAIN.HD_SBNNO.Tag)
                ''            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                ''            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'CHG  END  FKS)INABA 2007/01/26 ************************************************************************
                'CHG  END  FKS)INABA 2007/01/20 ************************************************************************
                'ADD  END  FKS)INABA 2006/11/20 ************************************************************************
                '【得意先コード】
                Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TOKCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【得意先名】
                Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【納入先コード】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【納入先名１】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【納入先名２】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD START FKS)INABA 2006/11/20 ************************************************************************
                '【納入先住所１】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '【納入先住所２】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '【納入先住所３】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADC, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '【便名コード】
                Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '【便名】
                Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)


                'ADD START FKS)INABA 2007/01/04 *************************************************************
                '            If pm_All.Dsp_Base.Head_Ok_Flg = True Then
                '** ｺﾝﾄﾛｰﾙ制御 **
                '【納入先名】
                '名称ﾏﾆｭｱﾙ入力区分='1'の場合、納入先名は変更可
                If IDOET52_SBNTRA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
                    Focus_Ctl = True
                Else
                    Focus_Ctl = False
                End If

                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
                If Focus_Ctl = True Then
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
                Else
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
                End If
                'コントロールの前景/背景色
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)

                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
                If Focus_Ctl = True Then
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
                Else
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
                End If
                'コントロールの前景/背景色
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)

                '            End If
                'ADD  END  FKS)INABA 2007/01/04 *************************************************************


                '            '【製品コード】
                '            Dim Init_Inf            As Cls_Dsp_Body_Bus_Inf
                '            Dim Bd_Index            As Integer
                '            Wk_Index = CInt(FR_SSSMAIN.BD_HINCD(1).Tag)
                '            Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
                '
                '            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINCD = IDOET52_SBNTRA_Inf.HINCD
                '            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINCD _
                ''                                   , pm_All.Dsp_Sub_Inf(Wk_Index) _
                ''                                   , Bd_Index _
                ''                                   , pm_All _
                ''                                   , SET_FLG_DB)


                '            IDOET52_SBNTRA_Inf.HINCD = Trn_Inf.HINCD                '製品コード
                '            IDOET52_SBNTRA_Inf.HINNMA = Trn_Inf.HINNMA              '型式
                '            IDOET52_SBNTRA_Inf.HINNMB = Trn_Inf.HINNMB              '品名
                '            IDOET52_SBNTRA_Inf.UODSU = Trn_Inf.UODSU                '数量
                '            IDOET52_SBNTRA_Inf.UNTNM = Trim$(Trn_Inf.UNTNM)         '単位名

                'ADD  END  FKS)INABA 2006/11/20 ************************************************************************


                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_TOKCD
    '   概要：  得意先コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_TOKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_TOKMTA
        Dim Mst_Inf_NHSCD As TYPE_DB_NHSMTA
        Dim Mst_Inf_BINCD As TYPE_DB_MEIMTA
        Dim Mst_Inf_YSN As TYPE_DB_YSNTRA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim intCnt As Short
        Dim intRet As Short
        Dim Err_Msg As String
        ' 得意先が変更された場合、単価の再表示を行う
        Dim Wk_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_TOKCD = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Err_Msg = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/21 CHG START
        'Call DB_TOKMTA_Clear(Mst_Inf)
        Call InitDataCommon("TOKMTA")
        '2019/06/21 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '得意先マスタ情報の初期化
            With IDOET52_SBNTRA_Inf
                .TOKCD = "" '得意先コード
                .TOKRN = "" '得意先略称
                .TOKADA = "" '得意先住所１
                .TOKADB = "" '得意先住所２
                .TOKADC = "" '得意先住所３
                .TANCD = "" '担当者コード
                .TANNM = "" '担当者名
                'ADD START FKS)INABA 2006/12/28 *********************************
                .FRNKB = ""
                'ADD  END  FKS)INABA 2006/12/28 *********************************
            End With
            '' 得意先コードは必須で無くなった(H.Y.)
            ''        Retn_Code = CHK_ERR_NOT_INPUT
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPTOKCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                    '論理削除チェック
                    Select Case True
                        '' 受注登録ではこれらのチェックを行っていたが、製番出庫ではコメントアウトしておく(H.Y. 9/22)
                        ''                    Case Mst_Inf.DATKB = gc_strDATKB_DEL
                        ''                        Retn_Code = CHK_ERR_ELSE
                        ''                        Err_Cd = gc_strMsgIDOET52_E_002       '削除済みデータ
                        ''
                        ''                    Case Mst_Inf.DSPKB = gc_strDSPKB_NG
                        ''                        Retn_Code = CHK_ERR_ELSE
                        ''                        Err_Cd = gc_strMsgIDOET52_E_003      '検索対象外データ
                        ''
                        Case Else
                            'ＯＫ
                            Retn_Code = CHK_OK
                            pm_Chk_Move = True

                            'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                                GoTo F_Chk_HD_TOKCD_END
                            End If

                            With IDOET52_SBNTRA_Inf
                                .TOKCD = Mst_Inf.TOKCD '得意先コード
                                .TOKRN = Mst_Inf.TOKRN '得意先略称
                                .TOKADA = Mst_Inf.TOKADA '得意先住所１
                                .TOKADB = Mst_Inf.TOKADB '得意先住所２
                                .TOKADC = Mst_Inf.TOKADC '得意先住所３
                                'ADD START FKS)INABA 2006/12/28 *********************************
                                .FRNKB = Mst_Inf.FRNKB '海外取引区分
                                'ADD  END  FKS)INABA 2006/12/28 *********************************
                                '修正内容
                                '得意先コードが入力された場合、納入先が入っていない場合は得意先に紐付く納入先をセットする。
                                '但し、納入先コードが入力されていた場合は納入先コード、住所、便コードについてはセットしない。
                                '                            .BINCD = Mst_Inf.BINCD
                                'CHG START FKS)INABA 2006/11/16*******************************************************************
                                If Trim(.NHSCD) = "" Then '納入先コードが既に設定されていた場合
                                    If Trim(Mst_Inf.MAINHSCD) = "" Then 'メイン納入先がマスタに設定されていない場合
                                        .NHSADA = Mst_Inf.TOKADA '納品先住所１
                                        .NHSADB = Mst_Inf.TOKADB '納品先住所２
                                        .NHSADC = Mst_Inf.TOKADC '納品先住所３
                                        .BINCD = Mst_Inf.BINCD '便コード
                                        'ADD START FKS)INABA 2006/12/26 ******************************************************************
                                        .NHSZIPCD = Mst_Inf.TOKZP '納入先郵便番号
                                        .NHSTL = Mst_Inf.TOKTL '納入先電話番号
                                        .NHSFAX = Mst_Inf.TOKFX '納入先ＦＡＸ番号
                                        'ADD START FKS)INABA 2006/12/28 *********************************
                                        .FRNKB = Mst_Inf.FRNKB '海外取引区分
                                        'ADD  END  FKS)INABA 2006/12/28 *********************************
                                        'ADD  END  FKS)INABA 2006/12/26 ******************************************************************
                                    Else
                                        .NHSCD = Mst_Inf.MAINHSCD
                                        .NHSNMA = "" '納品先名称１
                                        .NHSNMB = "" '納品先名称２
                                        .NHSADA = "" '納品先住所１
                                        .NHSADB = "" '納品先住所２
                                        .NHSADC = "" '納品先住所３
                                        .BINCD = "" '便コード
                                        .BINNM = ""
                                        'ADD START FKS)INABA 2006/12/26 ******************************************************************
                                        .NHSZIPCD = "" '納入先郵便番号
                                        .NHSTL = "" '納入先電話番号
                                        .NHSFAX = "" '納入先ＦＡＸ番号
                                        'ADD  END  FKS)INABA 2006/12/26 ******************************************************************
                                        'ADD START FKS)INABA 2006/12/28 *********************************
                                        .FRNKB = "" '海外取引区分
                                        'ADD  END  FKS)INABA 2006/12/28 *********************************
                                        '納入先マスタ検索
                                        If DSPNHSCD_SEARCH(IDOET52_SBNTRA_Inf.NHSCD, Mst_Inf_NHSCD) = 0 Then
                                            If Mst_Inf_NHSCD.DATKB <> gc_strDATKB_DEL Then
                                                .NHSNMA = Mst_Inf_NHSCD.NHSNMA '納品先名称１
                                                .NHSNMB = Mst_Inf_NHSCD.NHSNMB '納品先名称２
                                                .NHSADA = Mst_Inf_NHSCD.NHSADA '納品先住所１
                                                .NHSADB = Mst_Inf_NHSCD.NHSADB '納品先住所２
                                                .NHSADC = Mst_Inf_NHSCD.NHSADC '納品先住所３
                                                .BINCD = Mst_Inf_NHSCD.BINCD '便コード
                                                'ADD START FKS)INABA 2006/12/26 ******************************************************************
                                                .NHSZIPCD = Mst_Inf_NHSCD.NHSZP '納入先郵便番号
                                                .NHSTL = Mst_Inf_NHSCD.NHSTL '納入先電話番号
                                                .NHSFAX = Mst_Inf_NHSCD.NHSFX '納入先ＦＡＸ番号
                                                'ADD  END  FKS)INABA 2006/12/26 ******************************************************************
                                                'ADD START FKS)INABA 2007/01/06 ******************************************************************
                                                .NHSNMMKB = Mst_Inf_NHSCD.NHSNMMKB
                                                'ADD  END  FKS)INABA 2007/01/06 ******************************************************************

                                                'ADD START FKS)INABA 2006/12/28 *********************************
                                                .FRNKB = Mst_Inf_NHSCD.FRNKB '海外取引区分
                                                'ADD  END  FKS)INABA 2006/12/28 *********************************
                                            Else
                                                .NHSADA = Mst_Inf.TOKADA '納品先住所１
                                                .NHSADB = Mst_Inf.TOKADB '納品先住所２
                                                .NHSADC = Mst_Inf.TOKADC '納品先住所３
                                                'ADD START FKS)INABA 2006/12/26 ******************************************************************
                                                .NHSZIPCD = Mst_Inf.TOKZP '納入先郵便番号
                                                .NHSTL = Mst_Inf.TOKTL '納入先電話番号
                                                .NHSFAX = Mst_Inf.TOKFX '納入先ＦＡＸ番号
                                                'ADD  END  FKS)INABA 2006/12/26 ******************************************************************
                                                'ADD START FKS)INABA 2006/12/28 *********************************
                                                .FRNKB = Mst_Inf.FRNKB '海外取引区分
                                                'ADD  END  FKS)INABA 2006/12/28 *********************************
                                                .BINCD = Mst_Inf.BINCD '便コード
                                            End If
                                        Else
                                            .NHSADA = Mst_Inf.TOKADA '納品先住所１
                                            .NHSADB = Mst_Inf.TOKADB '納品先住所２
                                            .NHSADC = Mst_Inf.TOKADC '納品先住所３
                                            .BINCD = Mst_Inf.BINCD '便コード
                                            'ADD START FKS)INABA 2006/12/26 ******************************************************************
                                            .NHSZIPCD = Mst_Inf.TOKZP '納入先郵便番号
                                            .NHSTL = Mst_Inf.TOKTL '納入先電話番号
                                            .NHSFAX = Mst_Inf.TOKFX '納入先ＦＡＸ番号
                                            'ADD  END  FKS)INABA 2006/12/26 ******************************************************************
                                            'ADD START FKS)INABA 2006/12/28 *********************************
                                            .FRNKB = Mst_Inf.FRNKB '海外取引区分
                                            'ADD  END  FKS)INABA 2006/12/28 *********************************
                                        End If
                                    End If

                                    If DSPMEIM_SEARCH("002", .BINCD, Mst_Inf_BINCD) = 0 Then
                                        '論理削除チェック
                                        If Mst_Inf_BINCD.DATKB = gc_strDATKB_DEL Then
                                            .BINNM = "" '便名名称
                                        Else
                                            .BINNM = Mst_Inf_BINCD.MEINMA '便名名称
                                        End If
                                    Else
                                        .BINNM = "" '便名名称
                                    End If
                                Else '納入先コードが既に設定されていた場合は何もしない

                                End If
                                '                            .NHSCD = Mst_Inf.MAINHSCD
                                '                            .NHSNMA = ""                           '納品先名称１
                                '                            .NHSNMB = ""                           '納品先名称２
                                '                            .NHSADA = ""                           '納品先住所１
                                '                            .NHSADB = ""                           '納品先住所２
                                '                            .NHSADC = ""                           '納品先住所３
                                '                            '納入先マスタ検索
                                '                            If DSPNHSCD_SEARCH(IDOET52_SBNTRA_Inf.NHSCD, Mst_Inf_NHSCD) = 0 Then
                                '                                If Mst_Inf_NHSCD.DATKB <> gc_strDATKB_DEL Then
                                '                                    .NHSNMA = Mst_Inf_NHSCD.NHSNMA     '納品先名称１
                                '                                    .NHSNMB = Mst_Inf_NHSCD.NHSNMB     '納品先名称２
                                '                                    .NHSADA = Mst_Inf_NHSCD.NHSADA     '納品先住所１
                                '                                    .NHSADB = Mst_Inf_NHSCD.NHSADB     '納品先住所２
                                '                                    .NHSADC = Mst_Inf_NHSCD.NHSADC     '納品先住所３
                                '                                End If
                                '                            End If
                                '
                                '                            .NHSADA = Mst_Inf.TOKADA                    '納品先住所１
                                '                            .NHSADB = Mst_Inf.TOKADB                    '納品先住所２
                                '                            .NHSADC = Mst_Inf.TOKADC
                                'CHG  END  FKS)INABA 2006/11/16*******************************************************************
                            End With
                    End Select
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If
        End If

F_Chk_HD_TOKCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
        End If

        F_Chk_HD_TOKCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_TOKCD_Inf
    '   概要：  得意先コードによる画面表示
    '   引数：
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_TOKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim intCnt As Short
        Dim intRet As Short

        If pm_Mode = DSP_SET Then
            '表示
            '得意先コードが変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【得意先名】
                Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '明細編集メイン
                '            Call CF_Body_Dsp(pm_All)
                'コントロール制御
                Call F_Set_Body_Enable(pm_All)

                If Trim(IDOET52_SBNTRA_Inf.NHSCD) <> "" Then
                    '【納入先コード】
                    Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                    '【納入先名１】
                    Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                    '【納入先名２】
                    Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                    If pm_All.Dsp_Base.Head_Ok_Flg = True Then
                        '** ｺﾝﾄﾛｰﾙ制御 **
                    End If

                End If
                'ADD START FKS)INABA 2006/12/26 **************************************************************************
                '郵便番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSZIPCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSZIPCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '電話番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSTL, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ＦＡＸ番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSFAX.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSFAX, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD  END  FKS)INABA 2006/12/26 **************************************************************************
                '【住所１】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【住所２】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【住所３】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADC, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                'ADD START FKS)INABA 2006/11/16 ***********************************************************************
                '便コード
                Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '便名
                Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD  END  FKS)INABA 2006/11/16 ***********************************************************************

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【得意先名】
            Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '** ｺﾝﾄﾛｰﾙ制御 **
            '【得意先名】
            Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
            Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Trg_Index))

            '得意先マスタ情報の初期化
            With IDOET52_SBNTRA_Inf
                .TOKCD = "" '得意先コード
                .TOKRN = "" '得意先略称0
                .TOKADA = "" '得意先住所１
                .TOKADB = "" '得意先住所２
                .TOKADC = "" '得意先住所３
                .TANCD = "" '担当者コード
                .TANNM = "" '担当者名
            End With
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_TOKRN
    '   概要：  得意先略称のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_TOKRN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_TOKRN = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_TOKRN = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_TOKRN_Inf
    '   概要：  得意先略称による画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_TOKRN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_TANCD
    '   概要：  営業担当者コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_TANCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_TANMTA
        Dim Mst_Inf_BMNCD As TYPE_DB_BMNMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim strJDNDT As String
        Dim Bd_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_TANCD = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/21 CHG START
        'Call DB_TANMTA_Clear(Mst_Inf)
        Call InitDataCommon("TANMTA")
        '2019/06/21 CHG END
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.TANCD = "" '担当者コード
            IDOET52_SBNTRA_Inf.TANNM = "" '担当者名
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_BUMCD.Tag)).Detail.Bef_Chk_Value = IDOET52_SBNTRA_Inf.TANCD
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_BUMCD.Tag)).Detail.Bef_Chk_Value = IDOET52_SBNTRA_Inf.TANNM
            '' 担当者コードは必須で無くなった(H.Y.)
            ''        Retn_Code = CHK_ERR_NOT_INPUT
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPTANCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_TANCD_END
                        End If

                        IDOET52_SBNTRA_Inf.TANCD = Mst_Inf.TANCD '担当者コード
                        IDOET52_SBNTRA_Inf.TANNM = Mst_Inf.TANNM '担当者名
                        ' 部門の適用日の考慮対応
                        '                    IDOET52_SBNTRA_Inf.BUMCD = Mst_Inf.TANBMNCD    '所属部門コード
                        '受注日取得
                        'H.Y.(9/20)strJDNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag))))
                        'システム日付
                        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        strJDNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag))))

                        IDOET52_SBNTRA_Inf.BUMCD = CF_Get_TANBMNCD(Mst_Inf, strJDNDT) '所属部門コード
                        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_BUMCD.Tag)).Detail.Bef_Chk_Value = Mst_Inf.TANBMNCD

                        IDOET52_SBNTRA_Inf.BUMNM = "" '担当部門名
                        ' 部門の適用日の考慮対応
                        If DSPBMNCD_SEARCH(IDOET52_SBNTRA_Inf.BUMCD, Mst_Inf_BMNCD, strJDNDT) = 0 Then
                            If Mst_Inf_BMNCD.DATKB <> gc_strDATKB_DEL Then
                                IDOET52_SBNTRA_Inf.BUMNM = Mst_Inf_BMNCD.BMNNM '担当部門名
                            End If
                        End If
                    End If
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If
        End If

F_Chk_HD_TANCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_TANCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_TANCD_Inf
    '   概要：  営業担当者コードによる画面表示
    '   引数：
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_TANCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object

        If pm_Mode = DSP_SET Then
            '表示
            '担当者コードが変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【営業担当者名】
                Trg_Index = CShort(FR_SSSMAIN.HD_TANNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TANNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                If Trim(IDOET52_SBNTRA_Inf.BUMCD) <> "" Then
                    '【営業部門コード】
                    Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                    '【営業部門名】
                    Trg_Index = CShort(FR_SSSMAIN.HD_BUMNM.Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                End If

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【営業担当者名】
            Trg_Index = CShort(FR_SSSMAIN.HD_TANNM.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '変数のクリア
            With IDOET52_SBNTRA_Inf
                .TANCD = ""
                .TANNM = ""
            End With
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_BUMCD
    '   概要：  部門コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_BUMCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_BMNMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        ' 部門の適用日の考慮対応
        Dim strJDNDT As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_BUMCD = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_BMNMTA_Clear(Mst_Inf)
        Call InitDataCommon("BMNMTA")
        '2019/06/20 CHG END'

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.BUMCD = ""
            IDOET52_SBNTRA_Inf.BUMNM = ""
            '' 担当者コードは必須で無くなった(H.Y.)
            ''        Retn_Code = CHK_ERR_NOT_INPUT
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                ' 部門の適用日の考慮対応
                '            If DSPBMNCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                ''H.Y.(9/20)            strJDNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag))))
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strJDNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag))))
                If DSPBMNCD_SEARCH(Input_Value, Mst_Inf, strJDNDT) = 0 Then
                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_BUMCD_END
                        End If

                        IDOET52_SBNTRA_Inf.BUMCD = Mst_Inf.BMNCD '部門コード
                        IDOET52_SBNTRA_Inf.BUMNM = Mst_Inf.BMNNM '部門名
                    End If
                Else
                    IDOET52_SBNTRA_Inf.BUMNM = ""
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If

        End If

F_Chk_HD_BUMCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_BUMCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_BUMCD_Inf
    '   概要：  営業部門コードによる画面表示
    '   引数：
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_BUMCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object

        If pm_Mode = DSP_SET Then
            '表示
            '部門コードが変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                ' 部門の適用日の考慮対応
                '【営業部門】
                Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【営業部門名】
                Trg_Index = CShort(FR_SSSMAIN.HD_BUMNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【営業部門名】
            Trg_Index = CShort(FR_SSSMAIN.HD_BUMNM.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '変数のクリア
            With IDOET52_SBNTRA_Inf
                .BUMCD = ""
                .BUMNM = ""
            End With
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_SOUCD
    '   概要：  倉庫コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_SOUCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_SOUMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim strHINCD As String ' 品番
        Dim curSU As Decimal ' 数量
        Dim intRet As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_SOUCD = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/21 CHG START
        'Call DB_SOUMTA_Clear(Mst_Inf)
        Call InitDataCommon("SOUMTA")
        '2019/0/21 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            F_Reset_IDOET52_TYPE_SBNTRA_Sou(IDOET52_SBNTRA_Inf)
            'DEL START FKS)INABA 2007/02/15 ************************************
            '        Retn_Code = CHK_ERR_NOT_INPUT
            'DEL  END  FKS)INABA 2007/02/15 ************************************
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPSOUCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                    'ADD START FKS)INABA 2007/03/26 ****************************************
                    If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" Then
                        Select Case Trim(Mst_Inf.SOUKOKB)
                            Case "11", "12"
                                Retn_Code = CHK_ERR_ELSE
                                Err_Cd = gc_strMsgIDOET52_E_103
                                GoTo F_Chk_HD_SOUCD_END
                            Case Else
                        End Select
                    End If
                    'ADD  END  FKS)INABA 2007/03/26 ****************************************

                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                    Else
                        '有効在庫数チェック
                        strHINCD = pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINCD ' 品番
                        If IsNumeric(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UODSU) = True Then
                            curSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UODSU)
                        Else
                            curSU = 0
                        End If
                        If Trim(strHINCD) <> "" And curSU <> 0 Then
                            'CHG START FKS)INABA 2006/11/30 ***************************************************************
                            intRet = F_Chk_Relzaisu(Input_Value, strHINCD, curSU, pm_All)
                            '                        Select Case intRet
                            '                            Case 1  '在庫管理しない製品コード
                            '                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_064, pm_All)
                            '                            Case 2  'HINMTAに無い
                            '                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_081, pm_All)
                            ''ADD START FKS)INABA 2007/01/08 ********************************************************************
                            '                        '有効在庫数チェック仕様変更（ワーニングを表示する）
                            '                            Case 3  '現在庫数＜出庫数
                            '
                            ''CHG START FKS)INABA 2007/12/14 ********************************************
                            '                                If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
                            '                                   Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_016, pm_All)
                            '                                   Msg_Flg = True
                            '                                Else
                            '                                   Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_095, pm_All)
                            '                                End If
                            ''                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_095, pm_All)
                            ''CHG  END  FKS)INABA 2007/12/14 ********************************************
                            '                            Case 4  '現在庫数－引当済数＜出庫数
                            ''CHG START FKS)INABA 2007/12/14 ********************************************
                            '                                If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
                            '                                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_017, pm_All)
                            '                                    Msg_Flg = True
                            '                                Else
                            '                                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_096, pm_All)
                            '                                End If
                            ''                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_096, pm_All)
                            ''CHG  END  FKS)INABA 2007/12/14 ********************************************
                            '                            Case 5  '現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
                            '                                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_097, pm_All)
                            ''ADD  END  FKS)INABA 2007/01/08 ********************************************************************
                            '                            Case 0  '正常終了
                            '                        End Select
                            '                        intRet = F_Chk_Relzaisu(Input_Value, strHINCD, curSU)
                            '                        If intRet = 1 Or intRet = 2 Then
                            '                            'メッセージ出力
                            '                            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_063, pm_All)
                            '                        End If
                            'CHG  END  FKS)INABA 2006/11/30 ***************************************************************
                        End If

                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_SOUCD_END
                        End If

                        IDOET52_SBNTRA_Inf.SOUCD = Mst_Inf.SOUCD '倉庫コード
                        IDOET52_SBNTRA_Inf.SOUNM = Mst_Inf.SOUNM '倉庫名
                        IDOET52_SBNTRA_Inf.SOUBSCD = Mst_Inf.SOUBSCD '場所コード
                    End If
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If
        End If

F_Chk_HD_SOUCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_SOUCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_SOUCD_Inf
    '   概要：  倉庫コードによる画面表示
    '   引数：  pm_Dsp_Sub_Inf  :
    '           pm_Mode         :
    '           pm_All          :
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_SOUCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object

        If pm_Mode = DSP_SET Then
            '表示
            '倉庫コードが変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【出荷倉庫名】
                Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【出荷倉庫名】
            Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '変数のクリア
            With IDOET52_SBNTRA_Inf
                '            .SOUCD = ""
                .SOUNM = ""
            End With
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_OUTRYCD
    '   概要：  出庫理由のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_OUTRYCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Const gc_strKEYCD_SYRY As String = "066" ' 出庫理由
        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_OUTRYCD = Retn_Code
            Exit Function
        End If

        FR_SSSMAIN.HD_OPT1.Checked = False
        FR_SSSMAIN.HD_OPT2.Checked = False
        FR_SSSMAIN.HD_OPT3.Checked = False

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_MEIMTA_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTA")
        '2019/06/20 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            'ADD START FKS)INABA 2006/11/30 ******************************
            FR_SSSMAIN.HD_OPT1.Enabled = False
            FR_SSSMAIN.HD_OPT2.Enabled = False
            FR_SSSMAIN.HD_OPT3.Enabled = False
            'ADD  END  FKS)INABA 2006/11/30 ******************************

            F_Reset_IDOET52_TYPE_SBNTRA_OutRy(IDOET52_SBNTRA_Inf)
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPMEIM_SEARCH("066", Input_Value, Mst_Inf) = 0 Then
                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        'DEL START FKS)INABA 2008/07/29 ********************************************
                        '                    Retn_Code = CHK_ERR_ELSE
                        '                    Err_Cd = gc_strMsgIDOET52_E_002       '削除済みデータ
                        'DEL  END T FKS)INABA 2008/07/29 ********************************************
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_OUTRYCD_END
                        End If

                        '取得項目格納（出庫理由で必要な項目を取得するように変更すること H.Y.9/21)
                        IDOET52_SBNTRA_Inf.OUTRYCD = Mst_Inf.MEICDA '出庫理由コード
                        IDOET52_SBNTRA_Inf.OUTRYNM = Mst_Inf.MEINMA '出庫理由名称
                        IDOET52_SBNTRA_Inf.OUTRYKB1 = Mst_Inf.MEIKBA '出庫理由区分１
                        IDOET52_SBNTRA_Inf.OUTRYKB2 = Mst_Inf.MEIKBB '出庫理由区分２
                        IDOET52_SBNTRA_Inf.OUTRYKB3 = Mst_Inf.MEIKBC '出庫理由区分３

                        ' 出庫理由が代替出荷のときは
                        ' 1.参照受注番号が必須、それいがいは入力不可
                        If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then ' 区分1='1' : 代替出荷 -> 参照受注番号必須
                            ''ボタンの押下不可制御は不要(H.Y. 9/25) FR_SSSMAIN.CS_REF_JDNNO.Enabled = True
                            FR_SSSMAIN.HD_JDNNO.Enabled = True
                            IDOET52_SBNTRA_Inf.OUTKB = OUTKB_KOUKAN
                            'DEL STRAT FKS)INABA 2008/07/29 *****************************************************************************
                            '                        If RunMode = RUNMODE_IDOET52 Then
                            '                            FR_SSSMAIN.HD_OPT1.Enabled = False
                            '                            FR_SSSMAIN.HD_OPT2.Enabled = False
                            '                            FR_SSSMAIN.HD_OPT3.Enabled = False
                            '                            FR_SSSMAIN.HD_Cursol_Wk_2.Enabled = False
                            '                            FR_SSSMAIN.HD_Cursol_Wk_3.Enabled = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Focus_Ctl = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Locked = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Focus_Ctl = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Locked = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Focus_Ctl = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Locked = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Focus_Ctl = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Locked = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Focus_Ctl = False
                            '                            pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Locked = False
                            '                        End If
                            'DEL  END  FKS)INABA 2008/07/29 *****************************************************************************
                        Else
                            'CHG START FKS)INABA 2006/11/29 *******************************************************************************
                            If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" Then
                                FR_SSSMAIN.HD_JDNNO.Text = ""
                                FR_SSSMAIN.HD_JDNNO.Enabled = False
                                '                            FR_SSSMAIN.HD_JDNNO.Enabled = True
                                IDOET52_SBNTRA_Inf.OUTKB = OUTKB_NORMAL
                                'DEL STRAT FKS)INABA 2008/07/29 *****************************************************************************
                                '                            If RunMode = RUNMODE_IDOET52 Then
                                '                                FR_SSSMAIN.HD_OPT1.Enabled = False
                                '                                FR_SSSMAIN.HD_OPT2.Enabled = False
                                '                                FR_SSSMAIN.HD_OPT3.Enabled = False
                                '                                FR_SSSMAIN.HD_Cursol_Wk_2.Enabled = False
                                '                                FR_SSSMAIN.HD_Cursol_Wk_3.Enabled = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Locked = False
                                '                            End If
                                'DEL  END  FKS)INABA 2008/07/29 *****************************************************************************
                            Else
                                ''ボタンの押下不可制御は不要(H.Y. 9/25) FR_SSSMAIN.CS_REF_JDNNO.Enabled = False
                                FR_SSSMAIN.HD_JDNNO.Text = ""
                                FR_SSSMAIN.HD_JDNNO.Enabled = False

                                IDOET52_SBNTRA_Inf.OUTKB = OUTKB_NORMAL
                                'DEL STRAT FKS)INABA 2008/07/29 *****************************************************************************
                                '                            If RunMode = RUNMODE_IDOET52 Then
                                '                                FR_SSSMAIN.HD_OPT1.Enabled = False
                                '                                FR_SSSMAIN.HD_OPT2.Enabled = False
                                '                                FR_SSSMAIN.HD_OPT3.Enabled = False
                                '                                FR_SSSMAIN.HD_Cursol_Wk_2.Enabled = False
                                '                                FR_SSSMAIN.HD_Cursol_Wk_3.Enabled = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT1.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT2.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_OPT3.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_2.Tag).Detail.Locked = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Focus_Ctl = False
                                '                                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_Cursol_Wk_3.Tag).Detail.Locked = False
                                '                            End If
                                'DEL  END  FKS)INABA 2008/07/29 *****************************************************************************
                            End If
                            '                        ''ボタンの押下不可制御は不要(H.Y. 9/25) FR_SSSMAIN.CS_REF_JDNNO.Enabled = False
                            '                        FR_SSSMAIN.HD_JDNNO.Text = ""
                            '                        FR_SSSMAIN.HD_JDNNO.Enabled = False
                            '                        IDOET52_SBNTRA_Inf.OUTKB = OUTKB_NORMAL
                            'CHG  END  FKS)INABA 2006/11/29 *******************************************************************************
                        End If

                        ' 製番（常に手入力です 9/25）
                        ''                    Select Case Trim(IDOET52_SBNTRA_Inf.OUTRYKB2)    ' 区分2
                        ''                    Case "0", "1"       ' 自動採番
                        ''                        FR_SSSMAIN.HD_SBNNO.Enabled = False          ' 入力不可
                        ''                    Case Else           ' 手入力
                        ''                        FR_SSSMAIN.HD_SBNNO.Enabled = True
                        ''                    End Select
                    End If
                Else
                    'DEL  END  FKS)INABA 2008/07/29 *****************************************************************************
                    '                Retn_Code = CHK_ERR_ELSE
                    '                Err_Cd = gc_strMsgIDOET52_E_009          '該当データなし
                    'DEL  END  FKS)INABA 2008/07/29 *****************************************************************************
                End If
            End If

        End If
        'ADD START FKS)INABA 2008/01/23 ***********************************
        '2008/05/13 FKS)HONDA ADD START
        '    If Retn_Code = CHK_OK Then
        If Retn_Code = CHK_OK And gv_strSBNFlg = "" Then
            '2008/05/13 FKS)HONDA ADD END

            IDOET52_SBNTRA_Inf.SBNNO = ""
            FR_SSSMAIN.HD_SBNNO.Text = IDOET52_SBNTRA_Inf.SBNNO
        End If
        'ADD  END  FKS)INABA 2008/01/23 ***********************************
F_Chk_HD_OUTRYCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_OUTRYCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_BINCD
    '   概要：  便名のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_BINCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Const gc_strKEYCD_SYRY As String = "002" ' 便名
        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_BINCD = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_MEIMTA_Clear(Mst_Inf)
        Call InitDataCommon("MEIMTA")
        '2019/06/20 CHG END

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '        F_Reset_IDOET52_TYPE_SBNTRA_OutRy IDOET52_SBNTRA_Inf
            IDOET52_SBNTRA_Inf.BINCD = "" '便名コード
            IDOET52_SBNTRA_Inf.BINNM = "" '便名名称
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPMEIM_SEARCH("002", Input_Value, Mst_Inf) = 0 Then
                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_BINCD_END
                        End If

                        '取得項目格納（便名で必要な項目を取得するように変更すること H.Y.9/21)
                        IDOET52_SBNTRA_Inf.BINCD = Mst_Inf.MEICDA '便名コード
                        IDOET52_SBNTRA_Inf.BINNM = Mst_Inf.MEINMA '便名名称
                    End If
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If

        End If

F_Chk_HD_BINCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_BINCD = Retn_Code

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_OUTRYCD_Inf
    '   概要：  出荷理由区分による画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_OUTRYCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim WK_HD_OUTRYNM As String

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【出荷理由区分名】
                Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.OUTRYNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD START FKS)INABA 207/01/20*******************************
                'CHG START FKS)INABA 207/01/26*******************************
                If RunMode = RUNMODE_IDOET52 Then
                    If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then
                        Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
                        'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                        Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                    End If
                End If
                '            Trg_Index = CInt(FR_SSSMAIN.HD_OUTRYCD.Tag)
                '            WK_HD_OUTRYNM = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.OUTRYCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '            If WK_HD_OUTRYNM = "01" Or WK_HD_OUTRYNM = "02" Then
                '                Trg_Index = CInt(FR_SSSMAIN.HD_SBNNO.Tag)
                '                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.OUTRYNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '                Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '            End If
                'CHG  END  FKS)INABA 207/01/26*******************************
                'ADD START FKS)INABA 207/01/20*******************************
                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【出荷理由区分名】
            Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYNM.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '変数のクリア
            F_Reset_IDOET52_TYPE_SBNTRA_OutRy(IDOET52_SBNTRA_Inf)
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_BINCD_Inf
    '   概要：  便コードによる画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_BINCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【便コード名】
                Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【便コード名】
            Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '変数のクリア
            F_Reset_IDOET52_TYPE_SBNTRA_OutRy(IDOET52_SBNTRA_Inf)
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_SBNNO
    '   概要：  製番（ヘッダ）のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_SBNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Retn_Code2 As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_SBNNO = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.SBNNO = ""
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ADD START FKS)INABA 2006/12/01 ****************************************************************************************************
                IDOET52_SBNTRA_Inf.SBNNO = Input_Value
                If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" Then
                    'CHG START FKS)INABA 2006/02/28 ****************************************************************************************************

                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Retn_Code2 = F_Chk_Shikyu(Input_Value, CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 20), CInt(CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)))
                    '                Retn_Code2 = F_Chk_Shikyu(Input_Value)
                    'CHG  END  FKS)INABA 2006/02/08 ****************************************************************************************************
                    Select Case Retn_Code2
                        Case 1
                            '製番が支給品ファイルに存在する。(正常)
                            FR_SSSMAIN.HD_OPT1.Checked = False
                            FR_SSSMAIN.HD_OPT2.Checked = True
                        Case 2
                            '製番、製品コードで検索し、存在する(正常)
                            FR_SSSMAIN.HD_OPT1.Checked = False
                            FR_SSSMAIN.HD_OPT2.Checked = True
                        Case 7
                            '出庫済み数量が戻し数量より少ない
                            Err_Cd = gc_strMsgIDOET52_E_080
                            Retn_Code = CHK_ERR_ELSE
                            GoTo F_Chk_HD_SBNNO_END
                        Case 8
                            '存在しないエラー
                            FR_SSSMAIN.HD_OPT1.Checked = True
                            FR_SSSMAIN.HD_OPT2.Checked = False
                            'ADD START FKS)INABA 2008/03/14 *****************************
                            Retn_Code = 0
                            'ADD  END  FKS)INABA 2008/03/14 *****************************
                            ''ADD START FKS)INABA 2006/02/28 ****************************************************************************************************
                            '                        Err_Cd = gc_strMsgIDOET52_E_009
                            '                        Retn_Code = CHK_ERR_ELSE
                            '                        GoTo F_Chk_HD_SBNNO_END
                            ''ADD  END  FKS)INABA 2006/02/28 ****************************************************************************************************
                        Case 9
                            'その他エラー
                    End Select
                Else
                    FR_SSSMAIN.HD_OPT1.Checked = True
                    FR_SSSMAIN.HD_OPT2.Checked = False
                    'ADD START FKS)INABA 2008/01/23 *********************************************
                    '戻し処理で無い場合、初期不良用の製番(自動で採番された製番)は入力不可とする
                    'ロジックとしてはSBNTRAのORGSBNNOに値が入っているデータでSBNNOに存在するデータはNG
                    If F_Chk_Sbnno_2(IDOET52_SBNTRA_Inf.SBNNO) <> 0 Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_003
                        GoTo F_Chk_HD_SBNNO_END
                    End If
                    'ADD  END  FKS)INABA 2008/01/23 *********************************************
                End If
                'ADD  END  FKS)INABA 2006/12/01 ****************************************************************************************************
                '            If FR_SSSMAIN.HD_OPT1.Value = True Then
                '                Retn_Code2 = F_Chk_Sbnno(Input_Value, Format$(FR_SSSMAIN.HD_DENDT.Text, "YYYYMMDD"))      ' 製番を製番マスタと照合する
                '                If Retn_Code2 = 0 Then
                '                    'ＯＫ
                '                    Retn_Code = CHK_OK
                '                    pm_Chk_Move = True
                '
                '                    If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                '                        GoTo F_Chk_HD_SBNNO_END
                '                    End If
                '                    IDOET52_SBNTRA_Inf.SBNNO = Input_Value
                '                ElseIf Retn_Code2 = 1 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_060
                '                ElseIf Retn_Code2 = 2 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_061
                '                ElseIf Retn_Code2 = 3 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_062
                '    'ADD START FKS)INABA 2006/11/15 ******************************
                '                ElseIf Retn_Code2 = 4 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_070
                '                ElseIf Retn_Code2 = 5 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_003
                '                ElseIf Retn_Code2 = 6 Then
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_071
                '    'ADD  END  FKS)INABA 2006/11/15 ******************************
                '    'ADD START FKS)INABA 2007/03/06 ******************************
                '                ElseIf Retn_Code2 = 7 Then
                '                    If Trim$(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" Then
                '                        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_A_102, pm_All) = vbYes Then
                '                            Retn_Code = CHK_OK
                '                            pm_Chk_Move = True
                '
                '                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                '                                GoTo F_Chk_HD_SBNNO_END
                '                            End If
                '                        Else
                '                            Retn_Code = CHK_ERR_ELSE
                '                            Err_Cd = ""
                '                        End If
                '                    Else
                '                        Retn_Code = CHK_ERR_ELSE
                '                        Err_Cd = gc_strMsgIDOET52_E_062
                '                    End If
                '    'ADD  END  FKS)INABA 2007/03/06 ******************************
                '                Else
                '                    Retn_Code = CHK_ERR_ELSE
                '                    Err_Cd = gc_strMsgIDOET52_E_001
                '                End If
                '            End If
            End If
        End If

F_Chk_HD_SBNNO_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_SBNNO = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ADD FUNCTION FKS)INABA 2006/11/14
    '   名称：  Function F_Chk_Sbnno
    '   概要：  製番を名称マスタおよび製番マスタと照合してチェックする
    '   引数：  sbnno           : チェック対象製番
    '           pm_All           : 画面情報
    '   戻値：  0 : OK
    '           1 : 頭文字不正
    '           2 : 文字数不正
    '           3 : 製番マスタ未登録
    '           4 : 費用製番マスタ未登録
    '           5 : 製番体系不正
    '           6 : 適用範囲外製番
    '           7 : 取り消しデータ
    '           9 : その他
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Chk_Sbnno(ByVal p_SBNNO As String, ByVal p_DENDT As String) As Short
        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
        Dim strCode1 As String '名称マスタのコード１
        Dim intSu1 As Short '名称マスタの数値1
        Dim intSu2 As Short '名称マスタの数値3
        Dim intSu3 As Short '名称マスタの数値3
        Dim DB_SBNMTA_W As TYPE_DB_SBNMTA '製番マスタレコード
        Dim Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)

        Dim ls_SBNNO As String
        Dim ls_SBNNO_1 As String
        Dim ls_MEINMC As String
        Dim ll_MEINMC_LEN As Integer
        Dim ll_MCMA As Integer
        Dim strSelect As String
        Dim strFrom As String
        Dim strWhere As String
        Dim ls_Check_cd As String
        Dim ls_DENDT As String
        Dim ls_STTTKDT As String
        Dim ls_ENDTKDT As String

        On Error GoTo F_Chk_Sbnno_err

        Dyn_Open = False
        F_Chk_Sbnno = 1

        ls_SBNNO = Trim(p_SBNNO)
        ls_SBNNO_1 = Left(Trim(ls_SBNNO), 1)
        ls_DENDT = p_DENDT

        Select Case IsNumeric(ls_SBNNO_1)
            Case True
                '一桁目が数値項目なら費用製番マスタを検索する
                strSQL = ""
                strSQL = strSQL & " SELECT STTTKDT,ENDTKDT "
                strSQL = strSQL & " FROM SBNMTB "
                strSQL = strSQL & " WHERE SBNNO = '" & Left(Trim(ls_SBNNO) & Space(20), 20) & "'"
                strSQL = strSQL & "   AND DATKB = '1'  "
                '2019/06/21 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/06/21 CHG E N D
                Dyn_Open = True
                '2019/06/21 CHG START
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    '2019/06/21 CHG END
                    F_Chk_Sbnno = 4
                Else
                    '2019/06/21 CHG START
                    'Do Until CF_Ora_EOF(Usr_Ody) = True
                    '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    ls_STTTKDT = Trim(CF_Ora_GetDyn(Usr_Ody, "STTTKDT", ""))
                    '    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    ls_ENDTKDT = Trim(CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", ""))
                    '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    Call CF_Ora_MoveNext(Usr_Ody)
                    'Loop
                    For i As Integer = 0 To dt.Rows.Count - 1
                        ls_STTTKDT = Trim(DB_NullReplace(dt.Rows(i)("STTTKDT"), ""))
                        ls_ENDTKDT = Trim(DB_NullReplace(dt.Rows(i)("ENDTKDT"), ""))
                    Next
                    '2019/06/21 CHG END
                    If ls_STTTKDT <= ls_DENDT And ls_ENDTKDT >= ls_DENDT Then
                        F_Chk_Sbnno = 0
                    Else
                        F_Chk_Sbnno = 6
                    End If
                End If
                If Dyn_Open = True Then
                    Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
                End If
            Case False
                '一桁目が英字なら製番のチェックを行う。
                ''入力された製番の下Ｎ桁のチェックを行う（ＮはMEISUC-MEISUA）
                strSQL = ""
                strSQL = strSQL & " SELECT MEICDA "
                strSQL = strSQL & "       ,MEINMC "
                strSQL = strSQL & "       ,MEISUA "
                strSQL = strSQL & "       ,MEISUB "
                strSQL = strSQL & "       ,MEISUC "
                strSQL = strSQL & "   FROM MEIMTA "
                strSQL = strSQL & "  WHERE KEYCD  ='019' "
                strSQL = strSQL & "    AND MEICDA = '" & Left(Trim(ls_SBNNO_1) & Space(20), 20) & "'"
                strSQL = strSQL & "    AND DATKB = '1'  "

                '2019/06/21 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/06/21 CHG END
                Dyn_Open = True
                '2019/06/21 CHG START
                'Do Until CF_Ora_EOF(Usr_Ody) = True
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    ls_MEINMC = Trim(CF_Ora_GetDyn(Usr_Ody, "MEINMC", "")) '製番チェック用のキーを取得(複数入っている場合あり EX) "075048" )
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    intSu1 = CF_Ora_GetDyn(Usr_Ody, "MEISUA", 0) '数値１（チェック対象文字数）
                '    'ADD START FKS)INABA 2007/02/03 **********************************************************************
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    intSu2 = CF_Ora_GetDyn(Usr_Ody, "MEISUB", 0) '数値２（チェック対象文字数２）
                '    'ADD  END  FKS)INABA 2007/02/03 **********************************************************************
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    intSu3 = CF_Ora_GetDyn(Usr_Ody, "MEISUC", 0) '数値３（製番の最大文字数）
                '    Call CF_Ora_MoveNext(Usr_Ody)
                'Loop
                For i As Integer = 0 To dt.Rows.Count - 1
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ls_MEINMC = Trim(DB_NullReplace(dt.Rows(i).Item("MEINMC"), "")) '製番チェック用のキーを取得(複数入っている場合あり EX) "075048" )
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intSu1 = DB_NullReplace(dt.Rows(i).Item("TOKCD"), "") '数値１（チェック対象文字数）
                    'ADD START FKS)INABA 2007/02/03 **********************************************************************
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intSu2 = DB_NullReplace(dt.Rows(i).Item("MEISUB"), 0) '数値２（チェック対象文字数２）
                    'ADD  END  FKS)INABA 2007/02/03 **********************************************************************
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intSu3 = DB_NullReplace(dt.Rows(i).Item("MEISUC"), 0) '数値３（製番の最大文字数）
                Next
                '2019/06/21 CHG END
                If Dyn_Open = True Then
                    Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
                End If

ISU2_SET:
                ll_MEINMC_LEN = Len(Trim(ls_MEINMC)) '設定されている値の桁数を取得
                'CHG START FKS)INABA 2007/02/28 *********************************************
                If Trim(ls_SBNNO_1) = "A" Or Trim(ls_SBNNO_1) = "R" Then
                    '            If Trim$(ls_SBNNO_1) = "A" Then
                    'CHG  END  FKS)INABA 2007/02/28 *********************************************
                    If intSu1 = 6 Then
                        ll_MCMA = intSu3 - intSu1 - 1
                    Else
                        ll_MCMA = intSu3 - intSu1
                    End If
                Else
                    ll_MCMA = intSu3 - intSu1
                End If
                If ll_MCMA > 0 And ll_MEINMC_LEN <> 0 Then '(製番の最大文字数-チェック対象文字数)がゼロ以上の場合、最終Ｎ桁のチェックを行う
                    '名称３に設定されている値の桁数によって動的にSQL文を作成する
                    strSelect = " SELECT DISTINCT TRIM(A.MEICDA) "
                    strFrom = " FROM MEIMTA A "
                    strWhere = " WHERE A.KEYCD IN (SUBSTR('" & ls_MEINMC & "',1,3))"
                    strWhere = strWhere & "   AND A.DATKB = '1'  "

                    If Fix(ll_MEINMC_LEN / 3) >= 2 Then
                        strSelect = strSelect & " || TRIM(B.MEICDA) "
                        strFrom = strFrom & " , MEIMTA B "
                        strWhere = strWhere & "  AND B.KEYCD IN (SUBSTR('" & ls_MEINMC & "',4,3))"
                        strWhere = strWhere & "  AND B.DATKB = '1'  "
                    End If
                    If Fix(ll_MEINMC_LEN / 3) >= 3 Then
                        strSelect = strSelect & " || TRIM(C.MEICDA) "
                        strFrom = strFrom & " ,MEIMTA C "
                        strWhere = strWhere & "  AND C.KEYCD IN (SUBSTR('" & ls_MEINMC & "',7,3))"
                        strWhere = strWhere & "  AND C.DATKB = '1'  "
                    End If
                    If Fix(ll_MEINMC_LEN / 3) >= 4 Then
                        strSelect = strSelect & " || TRIM(D.MEICDA) "
                        strFrom = strFrom & " ,MEIMTA D "
                        strWhere = strWhere & "  AND D.KEYCD IN (SUBSTR('" & ls_MEINMC & "',10,3))"
                        strWhere = strWhere & "  AND D.DATKB = '1'  "
                    End If
                    If Fix(ll_MEINMC_LEN / 3) >= 5 Then
                        strSelect = strSelect & " || TRIM(E.MEICDA) "
                        strFrom = strFrom & " ,MEIMTA E "
                        strWhere = strWhere & "  AND E.KEYCD IN (SUBSTR('" & ls_MEINMC & "',13,3))"
                        strWhere = strWhere & "  AND E.DATKB = '1'  "
                    End If
                    If Fix(ll_MEINMC_LEN / 3) >= 6 Then
                        strSelect = strSelect & " || TRIM(F.MEICDA) "
                        strFrom = strFrom & " ,MEIMTA F "
                        strWhere = strWhere & "  AND F.KEYCD IN (SUBSTR('" & ls_MEINMC & "',16,3))"
                        strWhere = strWhere & "  AND F.DATKB = '1'  "
                    End If
                    strSelect = strSelect & " Check_CD "

                    'SQL文の組み立て
                    strSQL = strSelect & Chr(13)
                    strSQL = strSQL & strFrom & Chr(13)
                    strSQL = strSQL & strWhere & Chr(13)
                    '2019/06/21 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                    Dim dt1 As DataTable = DB_GetTable(strSQL)
                    '2019/06/21 CHG E N D
                    Dyn_Open = True
                    ls_Check_cd = Right(Trim(ls_SBNNO), ll_MCMA)
                    '2019/06/21 CHG START
                    'Do Until CF_Ora_EOF(Usr_Ody) = True
                    '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    If ls_Check_cd = Trim(CF_Ora_GetDyn(Usr_Ody, "Check_CD", 0)) Then
                    '        F_Chk_Sbnno = 0
                    '        Exit Do
                    '    Else
                    '        F_Chk_Sbnno = 5
                    '    End If
                    '    Call CF_Ora_MoveNext(Usr_Ody)
                    'Loop

                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If ls_Check_cd = Trim(DB_NullReplace(dt1.Rows(i).Item("Check_CD"), 0)) Then
                            F_Chk_Sbnno = 0
                            Exit For
                        Else
                            F_Chk_Sbnno = 5
                        End If
                    Next
                    '2019/06/21 CHG END

                    If Dyn_Open = True Then
                        Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
                    End If
                Else
                    F_Chk_Sbnno = 0
                End If
                If F_Chk_Sbnno = 0 Then
                    '製番マスタの検索
                    If CF_Ctr_AnsiLenB(ls_SBNNO) <= intSu3 Or ll_MCMA = 0 Then ' 最大文字列長以下か
                        If ll_MCMA <> 0 Then
                            '2019/06/21 CHG START
                            'If DSPSBNM_SEARCH(CF_Ctr_AnsiLeftB(ls_SBNNO, intSu1), DB_SBNMTA_W) = 0 Then ' 製番マスタに登録されているか
                            If DSPSBNM_SEARCH(LeftB(ls_SBNNO, intSu1), DB_SBNMTA_W) = 0 Then ' 製番マスタに登録されているか
                                '2019/06/21 CHG END
                                'CHG START FKS)INABA 2007/03/06 ***********************************************************
                                If DB_SBNMTA_W.DATKB = "1" Then
                                    F_Chk_Sbnno = 0
                                Else
                                    F_Chk_Sbnno = 7
                                End If
                                '                            F_Chk_Sbnno = 0
                                'CHG  END FKS)INABA 2007/03/06 ***********************************************************
                            Else
                                'ADD START FKS)INABA 2006/11/29 ******************************************
                                '製番マスタに無い場合、受注ファイル(JDNTRA)を検索する
                                If F_JDNTRA_SBNNO_SEARCH(ls_SBNNO) = 0 Then
                                    F_Chk_Sbnno = 0
                                Else
                                    F_Chk_Sbnno = 3
                                End If
                                'ADD  END  FKS)INABA 2006/11/29 ******************************************
                            End If
                        Else
                            If DSPSBNM_SEARCH(ls_SBNNO, DB_SBNMTA_W) = 0 Then ' 製番マスタに登録されているか
                                'CHG START FKS)INABA 2007/04/18 ***********************************************************
                                F_Chk_Sbnno = 0
                                ''CHG START FKS)INABA 2007/03/06 ***********************************************************
                                '                            If DB_SBNMTA_W.DATKB = "1" Then
                                '                                F_Chk_Sbnno = 0
                                '                            Else
                                '                                F_Chk_Sbnno = 7
                                '                            End If
                                ''                            F_Chk_Sbnno = 0
                                ''CHG  END FKS)INABA 2007/03/06 ***********************************************************
                                'CHG  END  FKS)INABA 2007/04/18 ***********************************************************
                            Else
                                'ADD START FKS)INABA 2006/11/29 ******************************************
                                '製番マスタに無い場合、受注ファイル(JDNTRA)を検索する
                                If F_JDNTRA_SBNNO_SEARCH(ls_SBNNO) = 0 Then
                                    'CHG START FKS)INABA 2007/04/18 ***********************************************************
                                    F_Chk_Sbnno = 0
                                    ''CHG START FKS)INABA 2007/03/06 ***********************************************************
                                    '                            If DB_SBNMTA_W.DATKB = "1" Then
                                    '                                F_Chk_Sbnno = 0
                                    '                            Else
                                    '                                F_Chk_Sbnno = 3
                                    '                            End If
                                    ''                            F_Chk_Sbnno = 0
                                    'CHG  END  FKS)INABA 2007/04/18 ***********************************************************
                                    ''CHG  END FKS)INABA 2007/03/06 ***********************************************************
                                Else
                                    F_Chk_Sbnno = 3
                                End If
                                'ADD  END  FKS)INABA 2006/11/29 ******************************************
                            End If
                        End If

                    Else
                        F_Chk_Sbnno = 2
                        'ADD START FKS)INABA 2006/11/29 ******************************************
                        '製番マスタに無い場合、受注ファイル(JDNTRA)を検索する
                        If F_JDNTRA_SBNNO_SEARCH(ls_SBNNO) = 0 Then
                            F_Chk_Sbnno = 0
                        Else
                            F_Chk_Sbnno = 3
                        End If
                        'ADD  END  FKS)INABA 2006/11/29 ******************************************
                    End If
                End If
        End Select



F_Chk_Sbnno_end:
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
        End If
        If F_Chk_Sbnno <> 0 Then
            If intSu2 <> 0 Then
                'CHG START FKS)INABA 2007/02/28 *********************************************
                If Trim(ls_SBNNO_1) = "A" Or Trim(ls_SBNNO_1) = "R" Then
                    '            If Trim$(ls_SBNNO_1) = "A"  Then
                    'CHG  END  FKS)INABA 2007/02/28 *********************************************
                    If Len(ls_SBNNO) = 6 Then
                    Else
                        intSu1 = intSu2
                        intSu2 = 0
                        GoTo ISU2_SET
                    End If
                End If
            End If
        End If
        Exit Function

F_Chk_Sbnno_err:
        F_Chk_Sbnno = 9
        GoTo F_Chk_Sbnno_end
    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   DEL FUNCTION FKS)INABA 2006/11/14
    '   全面改修の為
    '   名称：  Function F_Chk_Sbnno_bk
    '   概要：  製番を名称マスタおよび製番マスタと照合してチェックする
    '   引数：  sbnno           : チェック対象製番
    '           pm_All           : 画面情報
    '   戻値：  0 : OK
    '           1 : 頭文字不正
    '           2 : 文字数不正
    '           3 : 製番マスタ未登録
    '           9 : その他
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function F_Chk_Sbnno_bk(ByVal SBNNO As String) As Integer
    '    Dim strSQL          As String
    '    Dim Usr_Ody         As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    '    Dim strCode1        As String           '名称マスタのコード１
    '    Dim intSu1          As Integer          '名称マスタの数値1
    '    Dim intSu3          As Integer          '名称マスタの数値3
    '    Dim DB_SBNMTA_W     As TYPE_DB_SBNMTA   '製番マスタレコード
    '    Dim Dyn_Open        As Boolean          'ダイナセット状態（True:Open False:Close)
    '
    '    On Error GoTo F_Chk_Sbnno_bk_err
    '
    '    Dyn_Open = False
    '    F_Chk_Sbnno_bk = 1
    '    SBNNO = Trim(SBNNO)
    '    strSQL = ""
    '    strSQL = strSQL & "select MEICDA,MEISUA,MEISUC from MEIMTA where KEYCD='019'"
    '    'DBアクセス
    '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '    Dyn_Open = True
    '
    '    Do Until CF_Ora_EOF(Usr_Ody) = True
    '        '取得内容退避
    '        strCode1 = Trim(CF_Ora_GetDyn(Usr_Ody, "MEICDA", ""))   'コード１（製番の頭文字）
    '        intSu1 = CF_Ora_GetDyn(Usr_Ody, "MEISUA", 0)            '数値１（チェック対象文字数）
    '        intSu3 = CF_Ora_GetDyn(Usr_Ody, "MEISUC", 0)            '数値３（製番の最大文字数）
    '       'Debug.Print "[" & strCode1 & "]"
    '
    '        If strCode1 = CF_Ctr_AnsiLeftB(SBNNO, CF_Ctr_AnsiLenB(strCode1)) Then       ' 名称マスタに登録されている頭文字か
    '            If CF_Ctr_AnsiLenB(SBNNO) <= intSu3 Then        ' 最大文字列長以下か
    '                If DSPSBNM_SEARCH(CF_Ctr_AnsiLeftB(SBNNO, intSu1), DB_SBNMTA_W) = 0 Then    ' 製番マスタに登録されているか
    '                    F_Chk_Sbnno_bk = 0
    '                Else
    '                    F_Chk_Sbnno_bk = 3
    '                End If
    '            Else
    '                F_Chk_Sbnno_bk = 2
    '            End If
    '            Exit Do
    '        End If
    '        Call CF_Ora_MoveNext(Usr_Ody)
    '    Loop
    'F_Chk_Sbnno_bk_end:
    '    If Dyn_Open = True Then
    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody)
    '    End If
    '    Exit Function
    '
    'F_Chk_Sbnno_bk_err:
    '    F_Chk_Sbnno_bk = 9
    '    GoTo F_Chk_Sbnno_bk_end
    'End Function
    Private Function F_Chk_Sbnno_2(ByVal p_SBNNO As String) As Short
        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
        Dim Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
        Dim ls_SBNNO As String
        Dim lw_cnt As Short
        On Error GoTo F_Chk_Sbnno2_err

        ls_SBNNO = Trim(p_SBNNO)

        strSQL = ""
        strSQL = strSQL & " SELECT COUNT(*) CNT "
        strSQL = strSQL & " FROM SBNTRA "
        strSQL = strSQL & " WHERE SBNNO = '" & Left(Trim(ls_SBNNO) & Space(20), 20) & "'"
        strSQL = strSQL & "   AND ORGSBNNO <> ' '  "
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/24 CHG END
        Dyn_Open = True
        '2019/06/24 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    lw_cnt = CShort(Trim(CF_Ora_GetDyn(Usr_Ody, "CNT", "")))
        '    Call CF_Ora_MoveNext(Usr_Ody)
        'Loop
        For i As Integer = 0 To dt.Rows.Count - 1
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            lw_cnt = CShort(Trim(DB_NullReplace(dt.Rows(i).Item("CNT"), "")))
        Next

        If Dyn_Open = True Then
            Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
        End If

        F_Chk_Sbnno_2 = lw_cnt

F_Chk_Sbnno2_end:
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
        End If
        Exit Function
F_Chk_Sbnno2_err:
        F_Chk_Sbnno_2 = -1
        GoTo F_Chk_Sbnno2_end

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ADD FUNCTION FKS)INABA 2006/11/14
    '   名称：  Function F_Chk_Shikyu
    '   概要：  製番を
    '   引数：  sbnno           : チェック対象製番
    '           p_HINCD         : 製品コード
    '   戻値：  0 : OK
    '           1 : 製番が支給品ファイルに存在する。(正常)
    '           2 : 製番、製品コードで検索し、存在する(正常)
    '           7 : 出庫済み数量が戻し数量より少ない
    '           8 : 存在しないエラー
    '           9 : その他エラー
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Chk_Shikyu(ByVal p_SBNNO As String, Optional ByRef p_HINCD As String = "", Optional ByRef p_INPUT_SU As Integer = 0) As Short
        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
        Dim Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)

        Dim ls_SBNNO As String
        Dim LS_HINCD As String
        Dim ll_OUTZMISU As Integer
        Dim ls_Check_cd As String
        Dim ll_cnt As Integer

        On Error GoTo F_Chk_Shikyu_err

        Dyn_Open = False
        F_Chk_Shikyu = 9

        ls_SBNNO = Trim(p_SBNNO)
        LS_HINCD = Trim(p_HINCD)
        If LS_HINCD = "" Then
            ls_Check_cd = "1" '製番のみ入力された場合、製番が支給品ファイルにあるかどうかチェックする
        Else
            ls_Check_cd = "2" '製番及び製品コードが入力された場合
        End If

        Select Case ls_Check_cd
            Case "1"
                strSQL = ""
                strSQL = strSQL & " SELECT COUNT(*) CNT"
                strSQL = strSQL & "   FROM SKYTBL "
                strSQL = strSQL & "  WHERE SBNNO = '" & ls_SBNNO & "'"
                strSQL = strSQL & "    AND DATKB = '1'  "
                '2019/06/24 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/06/24 CHG END
                Dyn_Open = True
                '2019/06/24 CHG START
                'Do Until CF_Ora_EOF(Usr_Ody) = True
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    ll_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT", 0)
                '    Call CF_Ora_MoveNext(Usr_Ody)
                'Loop
                For i As Integer = 0 To dt.Rows.Count - 1
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ll_cnt = DB_NullReplace(dt.Rows(i).Item("CNT"), 0)
                Next
                '2019/06/24 CHG END
                If Dyn_Open = True Then
                    Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
                End If
                If ll_cnt <> 0 Then
                    F_Chk_Shikyu = 1
                Else
                    F_Chk_Shikyu = 8
                End If

            Case "2"
                strSQL = ""
                strSQL = strSQL & " SELECT SBNNO, "
                strSQL = strSQL & "        HINCD, "
                strSQL = strSQL & "        SUM(OUTZMISU) OUTZMISU_SUM "
                strSQL = strSQL & "   FROM SKYTBL "
                strSQL = strSQL & "  WHERE SBNNO = '" & ls_SBNNO & "'"
                strSQL = strSQL & "    AND HINCD = '" & LS_HINCD & "'"
                strSQL = strSQL & "    AND DATKB = '1' "
                strSQL = strSQL & " GROUP BY SBNNO,HINCD"
                '2019/06/24 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                'Dyn_Open = True
                'If CF_Ora_EOF(Usr_Ody) = True Then
                '    F_Chk_Shikyu = 8
                'Else
                '    Do Until CF_Ora_EOF(Usr_Ody) = True
                '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        ll_OUTZMISU = CF_Ora_GetDyn(Usr_Ody, "OUTZMISU_SUM", 0)
                '        F_Chk_Shikyu = 2
                '        Call CF_Ora_MoveNext(Usr_Ody)
                '    Loop
                Dim dt As DataTable = DB_GetTable(strSQL)
                Dyn_Open = True
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    F_Chk_Shikyu = 8
                Else
                    For i As Integer = 0 To dt.Rows.Count - 1
                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        ll_OUTZMISU = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("OUTZMISU_SUM"), 0)
                        F_Chk_Shikyu = 2
                    Next
                    '2019/06/24 CHG END
                    If System.Math.Abs(p_INPUT_SU) > ll_OUTZMISU Then
                        F_Chk_Shikyu = 7
                    End If
                End If
                If Dyn_Open = True Then
                    Call CF_Ora_CloseDyn(Usr_Ody) 'クローズ
                End If

        End Select


F_Chk_Shikyu_end:
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
        End If
        Exit Function

F_Chk_Shikyu_err:
        F_Chk_Shikyu = 9
        GoTo F_Chk_Shikyu_end
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_SBNNO_Inf
    '   概要：  客先注文番号（ヘッダ）による画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_SBNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_TL_KKOUT
    '   概要：  緊急出庫のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_TL_KKOUT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_TL_KKOUT = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                ''            If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then    ' 代替出荷
                ''                If pm_Chk_Dsp_Sub_Inf.Ctl.Value = 1 Then
                ''                    Retn_Code = CHK_ERR_ELSE
                ''                    Err_Cd = gc_strMsgIDOET52_E_065
                ''                    'pm_Chk_Dsp_Sub_Inf.Ctl.Value = 0
                ''                    GoTo F_Chk_TL_KKOUT_END
                ''                End If
                ''            End If

                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True

            End If
        End If

F_Chk_TL_KKOUT_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_TL_KKOUT = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_TL_KKOUT_Inf
    '   概要：  緊急出庫による画面表示
    '   引数：  pm_Dsp_Sub_Inf   : 画面項目情報
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_TL_KKOUT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_HINCD
    '   概要：  製品コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    '※大幅変更の為、F_Chk_BD_HINCD_BKにバックアップを取り再作成　FKS)INABA 2007/11/31
    '
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_HINCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_HINMTA
        Dim Mst_Inf_SYSTBB As TYPE_DB_SYSTBB
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Bd_Index As Short
        Dim Bd_Meisai_Index As Short '画面の明細の位置
        Dim Err_Cd As String
        Dim Init_Inf As Cls_Dsp_Body_Bus_Inf
        Dim Trg_Index As Short
        Dim strJDNYTDT As String
        Dim Mst_Inf_RNKMTA As TYPE_DB_RNKMTA
        Dim curMITTK As Decimal
        Dim curSIKRT As Decimal
        Dim intRet As Short
        Dim curZeigk As Decimal
        Dim curSIKSA As Decimal
        Dim strUODSU As String
        Dim strODNYTDT As String
        Dim strTOKJDNNO As String
        Dim strTOKJDNED As String
        Dim strORD_HINCD As String
        Dim intCnt As Short
        Dim Wk_Col As Short
        Dim Err_Msg As String
        Dim curUODTK As Decimal
        ' 原価単価適用日対応
        Dim strJDNDT As String '受注日
        Dim curTEIKATK As Decimal
        'ADD START FKS)INABA 2007/02/15 *************************
        Dim Dsp_Value As String
        Dim Mst_Inf_SOUMTA As TYPE_DB_SOUMTA
        'ADD  END  FKS)INABA 2007/02/15 *************************
        'AND START FKS)INABA 2007/06/12 *************************************************
        'サービスパーツ対応
        Dim SP_FLG As String
        'AND  END  FKS)INABA 2007/06/12 *************************************************


        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_HINCD = Retn_Code
            Exit Function
        End If

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Err_Msg = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_HINMTA_Clear(Mst_Inf)
        Call InitDataCommon("HINMTA")
        '2019/06/20 CHG END
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
        Bd_Meisai_Index = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '        Retn_Code = CHK_ERR_NOT_INPUT
            ' 注文情報取込時は処理を行わない
            If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED) = "" Then
                'クリアしない値の退避
                strUODSU = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU
                strTOKJDNNO = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO
                strTOKJDNED = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED
                strORD_HINCD = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD
                '構造体クリア
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf = Init_Inf
                '退避した情報を戻す
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = strUODSU
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO = strTOKJDNNO
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED = strTOKJDNED
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD = strORD_HINCD
                '変更項目のチェック用の内容退避
                Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
                ' 注文情報取込時は処理を行わない
            End If
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else

                'マスタチェック
                'ADD START FKS)INABA 2006/12/01 ****************************************************************************************************
                If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" And FR_SSSMAIN.HD_OPT2.Checked = True Then
                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Retn_Code = F_Chk_Shikyu(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20), CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 20), CInt(CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)))
                    Select Case Retn_Code
                        Case 1
                            '製番が支給品ファイルに存在する。(正常)
                            Retn_Code = CHK_OK
                        Case 2
                            '製番、製品コードで検索し、存在する(正常)
                            Retn_Code = CHK_OK
                        Case 7
                            'DEL START FKS)INABA 2007/03/12 **************************************
                            '                        '出庫済み数量が戻し数量より少ない
                            '                        Err_Cd = gc_strMsgIDOET52_E_080
                            '                        Retn_Code = CHK_ERR_ELSE
                            '                        GoTo F_Chk_BD_HINCD_END
                            'DEL  END  FKS)INABA 2007/03/12 **************************************
                        Case 8
                            '存在しないエラー
                            'ADD START FKS)INABA 2007/03/10 *****************************
                            FR_SSSMAIN.HD_OPT1.Checked = True
                            FR_SSSMAIN.HD_OPT2.Checked = False
                            'ADD START FKS)INABA 2008/03/14 *****************************
                            Retn_Code = 0
                            'ADD  END  FKS)INABA 2008/03/14 *****************************
                            'ADD  END  FKS)INABA 2007/03/10 *****************************
                            'DEL START FKS)INABA 2007/03/12 **************************************
                            '                        Err_Cd = gc_strMsgIDOET52_E_009
                            '                        Retn_Code = CHK_ERR_ELSE
                            '                        GoTo F_Chk_BD_HINCD_END
                            'DEL  END  FKS)INABA 2007/03/12 **************************************
                        Case 9
                            'その他エラー
                    End Select
                End If
                'ADD  END  FKS)INABA 2006/12/01 ****************************************************************************************************

                '画面.受注日取得
                ''H.Y.(9/20) strJDNDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag)))
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strJDNDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag)))

                If DSPHINCD_SEARCH(Input_Value, Mst_Inf, strJDNDT) = 0 Then

                    With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
                        .HINCD = Mst_Inf.HINCD '商品マスタ.製品コード
                        .HINNMA = Mst_Inf.HINNMA '商品マスタ.型式
                        .HINNMB = Mst_Inf.HINNMB '商品マスタ.商品名１
                        .UNTCD = Mst_Inf.UNTCD '商品マスタ.単位コード
                        .UNTNM = Mst_Inf.UNTNM '商品マスタ.単位名
                        .HINKB = Mst_Inf.HINKB '商品マスタ.商品区分
                        .HINMTA_HINID = Mst_Inf.HINID '商品マスタ.商品種別
                        .ZAIKB = Mst_Inf.ZAIKB '商品マスタ.在庫管理区分
                        .HINZEIKB = Mst_Inf.HINZEIKB '商品マスタ.商品消費税区分
                        .ZEIRNKKB = Mst_Inf.ZEIRNKKB '商品マスタ.消費税ランク
                        .TEIKATK = CStr(Mst_Inf.TEIKATK) '商品マスタ.定価
                        .SIKTK = CStr(Mst_Inf.GNKTK) '商品マスタ.原価単価
                        .HINNMMKB = Mst_Inf.HINNMMKB '商品マスタ.名称ﾏﾆｭｱﾙ入力区分
                        .HINMTA_PRDENDKB = Mst_Inf.PRDENDKB '商品マスタ.生産終了
                        .HINMTA_PRDENDDT = Mst_Inf.PRDENDDT '商品マスタ.生産終了日付
                        .HINMTA_SLENDKB = Mst_Inf.SLENDKB '商品マスタ.販売完了
                        .HINMTA_SLENDDT = Mst_Inf.SLENDDT '商品マスタ.販売完了日付
                        .HINMTA_JODSTPKB = Mst_Inf.JODSTPKB '商品マスタ.受注停止
                        .HINMTA_JODSTPDT = Mst_Inf.JODSTPDT '商品マスタ.受注停止日付
                        .HINMTA_MDLCL = Mst_Inf.MDLCL '商品マスタ.機種分類
                        .HINMTA_HINGRP = Mst_Inf.HINGRP '商品マスタ.商品群
                        .GNKCD = Mst_Inf.GNKCD '商品マスタ.原価管理コード
                        .MAKCD = Mst_Inf.MAKCD '商品マスタ.メーカーコード
                        .MAKNM = Mst_Inf.MAKNM '商品マスタ.メーカー名
                        .HRTDD = Mst_Inf.HRTDD '商品マスタ.発注リードタイム
                        .ORTDD = Mst_Inf.ORTDD '商品マスタ.出荷リードタイム
                        .ZAIRNK = Mst_Inf.ZAIRNK '商品マスタ.在庫ランク
                        .SODUNTSU = Mst_Inf.SODUNTSU '商品マスタ.発注単位数
                        .SIKRT_PER = DSP_PER
                        .SIKSA_DSP = DSP_SIKSA
                        .HINMTA_KHNKB = Mst_Inf.KHNKB '商品マスタ.仮本区分
                        .JANCD = Mst_Inf.JANCD '商品マスタ.JANコード (H.Y. 9/24)
                        .TNACM = Mst_Inf.TNACM
                    End With

                    SP_FLG = " "
                    If Mst_Inf.HINKB Like "[345]" = True And Mst_Inf.ZAIKB = gc_strZAIKB_OK Then
                        SP_FLG = "1"
                    Else
                        SP_FLG = "9"
                    End If
                    'DEL START FKS)INABA 2008/07/29 **********************************************************************************
                    '                    '論理削除チェック
                    '                    Select Case True
                    '                        Case Mst_Inf.DATKB = gc_strDATKB_DEL
                    '                            Retn_Code = CHK_ERR_ELSE
                    '                            Err_Cd = gc_strMsgIDOET52_E_002       '削除済みデータ
                    '                        Case Else
                    '                            '保守終了品チェック
                    '                            If Mst_Inf.MNTENDKB = gc_strMNTENDKB_END And SP_FLG <> "1" Then
                    '                                Err_Cd = gc_strMsgIDOET52_E_004       '保守終了品
                    '                                GoTo F_Chk_BD_HINCD_END
                    '                            End If
                    '
                    '                             '生産終了品チェック
                    '                            If Mst_Inf.PRDENDKB = gc_strPRDENDKB_END And SP_FLG <> "1" Then
                    '                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_007, pm_All) = vbCancel Then
                    '                                    GoTo F_Chk_BD_HINCD_END
                    '                                End If
                    '                            End If
                    '
                    '                            '出荷停止品チェック
                    '                            If Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
                    '                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_008, pm_All) = vbCancel Then
                    '                                    GoTo F_Chk_BD_HINCD_END
                    '                                End If
                    '                            End If
                    '                            '出荷準備品チェック
                    '                            If Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
                    '                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_093, pm_All) = vbCancel Then
                    '                                    GoTo F_Chk_BD_HINCD_END
                    '                                End If
                    '                            End If
                    '
                    '                            '仮製品チェック
                    '                            If Mst_Inf.KHNKB = "9" Then
                    '                                Retn_Code = CHK_ERR_ELSE
                    '                                Err_Cd = "HINCD"
                    '                                GoTo F_Chk_BD_HINCD_ERROR
                    '                            End If
                    '
                    '                            '在庫管理区分チェック (06/09/26 H.Y.)
                    '                            If Mst_Inf.ZAIKB <> gc_strZAIKB_OK Then
                    '                                Retn_Code = CHK_ERR_ELSE
                    '                                Err_Cd = gc_strMsgIDOET52_E_064
                    '                                GoTo F_Chk_BD_HINCD_END
                    '                            End If
                    '
                    '                            'OEM区分
                    '                            If Mst_Inf.OEMKB = gc_strOEMKB_OK Then
                    '                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_094, pm_All) = vbCancel Then
                    '                                    GoTo F_Chk_BD_HINCD_END
                    '                                End If
                    '                            End If
                    '
                    '                            If Trim$(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SOUCD.Tag).Detail.Dsp_Value) <> "" Then
                    '                                IDOET52_SBNTRA_Inf.SOUCD = Trim$(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SOUCD.Tag).Detail.Dsp_Value)
                    '                                If Trim$(IDOET52_SBNTRA_Inf.SOUCD) <> Trim$(Mst_Inf.TNACM) Then '標準倉庫コード
                    '                                    '画面で入力された倉庫コードと商品マスタに設定されている標準倉庫が違う場合メッセージを表示する。
                    '                                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_101, pm_All)
                    '                                    '入力した倉庫と標準倉庫が違いますが、確認してください。
                    '                                End If
                    '                            End If
                    '                    End Select
                    'DEL  END  FKS)INABA 2008/07/29 **********************************************************************************
                Else
                    'DEL START FKS)INABA 2008/07/29 **********************************************************************************
                    '                    Retn_Code = CHK_ERR_ELSE
                    '                    Err_Cd = gc_strMsgIDOET52_E_009          '該当データなし
                    'DEL  END  FKS)INABA 2008/07/29 **********************************************************************************
                End If

            End If
        End If
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

F_Chk_BD_HINCD_END:
        '戻値、メッセージ、ステータス、移動制御

        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
        End If

        '2006.11.09 ADD -[START]
        GoTo LBL_END

F_Chk_BD_HINCD_ERROR:
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        Call AE_CmnMsgLibrary(SSS_PrgNm, "2HINCD", pm_All, Err_Msg)

LBL_END:
        '2006.11.09 ADD -[E N D]

        F_Chk_BD_HINCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_HINCD_BK
    '   概要：  製品コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_HINCD_BK(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_HINMTA
        Dim Mst_Inf_SYSTBB As TYPE_DB_SYSTBB
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Bd_Index As Short
        Dim Bd_Meisai_Index As Short '画面の明細の位置
        Dim Err_Cd As String
        Dim Init_Inf As Cls_Dsp_Body_Bus_Inf
        Dim Trg_Index As Short
        Dim strJDNYTDT As String
        Dim Mst_Inf_RNKMTA As TYPE_DB_RNKMTA
        Dim curMITTK As Decimal
        Dim curSIKRT As Decimal
        Dim intRet As Short
        Dim curZeigk As Decimal
        Dim curSIKSA As Decimal
        Dim strUODSU As String
        Dim strODNYTDT As String
        Dim strTOKJDNNO As String
        Dim strTOKJDNED As String
        Dim strORD_HINCD As String
        Dim intCnt As Short
        Dim Wk_Col As Short
        Dim Err_Msg As String
        Dim curUODTK As Decimal
        ' 原価単価適用日対応
        Dim strJDNDT As String '受注日
        Dim curTEIKATK As Decimal
        'ADD START FKS)INABA 2007/02/15 *************************
        Dim Dsp_Value As String
        Dim Mst_Inf_SOUMTA As TYPE_DB_SOUMTA
        'ADD  END  FKS)INABA 2007/02/15 *************************
        'AND START FKS)INABA 2007/06/12 *************************************************
        'サービスパーツ対応
        Dim SP_FLG As String
        'AND  END  FKS)INABA 2007/06/12 *************************************************


        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_HINCD_BK = Retn_Code
            Exit Function
        End If

        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Err_Msg = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_HINMTA_Clear(Mst_Inf)
        Call InitDataCommon("HINMTA")
        '2019/06/20 CHG END
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
        Bd_Meisai_Index = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '        Retn_Code = CHK_ERR_NOT_INPUT
            ' 注文情報取込時は処理を行わない
            If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED) = "" Then
                'クリアしない値の退避
                strUODSU = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU
                strTOKJDNNO = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO
                strTOKJDNED = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED
                strORD_HINCD = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD
                '構造体クリア
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf = Init_Inf
                '退避した情報を戻す
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = strUODSU
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO = strTOKJDNNO
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED = strTOKJDNED
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD = strORD_HINCD
                '変更項目のチェック用の内容退避
                Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
                ' 注文情報取込時は処理を行わない
            End If
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else

                'マスタチェック
                'ADD START FKS)INABA 2006/12/01 ****************************************************************************************************
                If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" And FR_SSSMAIN.HD_OPT2.Checked = True Then
                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Retn_Code = F_Chk_Shikyu(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20), CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 20), CInt(CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)))
                    Select Case Retn_Code
                        Case 1
                            '製番が支給品ファイルに存在する。(正常)
                            Retn_Code = CHK_OK
                        Case 2
                            '製番、製品コードで検索し、存在する(正常)
                            Retn_Code = CHK_OK
                        Case 7
                            '出庫済み数量が戻し数量より少ない
                            Err_Cd = gc_strMsgIDOET52_E_080
                            Retn_Code = CHK_ERR_ELSE
                            GoTo F_Chk_BD_HINCD_BK_END
                        Case 8
                            '存在しないエラー
                            'ADD START FKS)INABA 2007/03/10 *****************************
                            FR_SSSMAIN.HD_OPT1.Checked = True
                            FR_SSSMAIN.HD_OPT2.Checked = False
                            'ADD  END  FKS)INABA 2007/03/10 *****************************
                            'DEL START FKS)INABA 2007/03/12 **************************************
                            '                        Err_Cd = gc_strMsgIDOET52_E_009
                            '                        Retn_Code = CHK_ERR_ELSE
                            '                        GoTo F_Chk_BD_HINCD_BK_END
                            'DEL  END  FKS)INABA 2007/03/12 **************************************
                        Case 9
                            'その他エラー
                    End Select
                End If
                'ADD  END  FKS)INABA 2006/12/01 ****************************************************************************************************

                '画面.受注日取得
                ''H.Y.(9/20) strJDNDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag)))
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strJDNDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag)))

                If DSPHINCD_SEARCH(Input_Value, Mst_Inf, strJDNDT) = 0 Then
                    'CHG START FKS)INABA 2007/06/12 *************************************************
                    'サービスパーツ対応
                    SP_FLG = " "
                    If Mst_Inf.HINKB Like "[345]" = True And Mst_Inf.ZAIKB = gc_strZAIKB_OK Then
                        SP_FLG = "1"
                    Else
                        SP_FLG = "9"
                    End If
                    'CHG  END  FKS)INABA 2007/06/12 *************************************************
                    '論理削除チェック
                    Select Case True
                        Case Mst_Inf.DATKB = gc_strDATKB_DEL
                            Retn_Code = CHK_ERR_ELSE
                            Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                            'DEL START FKS)INABA 2006/12/25 *******************************
                            'E-1218-303対応
                            '                        Case Mst_Inf.DSPKB = gc_strDSPKB_NG
                            '                            Retn_Code = CHK_ERR_ELSE
                            '                            Err_Cd = gc_strMsgIDOET52_E_003      '検索不可データ
                            'DEL  END  FKS)INABA 2006/12/25 *******************************

                        Case Else
                            '保守終了品チェック
                            'CHG START FKS)INABA 2007/06/12 *************************************************
                            'サービスパーツ対応
                            If Mst_Inf.MNTENDKB = gc_strMNTENDKB_END And SP_FLG <> "1" Then
                                '                            If Mst_Inf.MNTENDKB = gc_strMNTENDKB_END Then
                                'CHG  END  FKS)INABA 2007/06/12 *************************************************
                                Retn_Code = CHK_ERR_ELSE
                                Err_Cd = gc_strMsgIDOET52_E_004 '保守終了品
                                GoTo F_Chk_BD_HINCD_BK_END
                            End If

                            'DEL START FKS)INABA 2006/12/26 ******************************************************
                            '                            '販売完了品チェック
                            '                            If Mst_Inf.SLENDKB = gc_strSLENDKB_END Then
                            '                                Retn_Code = CHK_ERR_ELSE
                            '                                Err_Cd = gc_strMsgIDOET52_E_005       '販売完了品
                            '                                GoTo F_Chk_BD_HINCD_BK_END
                            '                            End If
                            '
                            '                            '受注停止品チェック
                            '                            If Mst_Inf.JODSTPKB = gc_strJODSTPKB_STOP Then
                            '                                Retn_Code = CHK_ERR_ELSE
                            '                                Err_Cd = gc_strMsgIDOET52_E_006       '受注停止品
                            '                                GoTo F_Chk_BD_HINCD_BK_END
                            '                            End If
                            'DEL  END  FKS)INABA 2006/12/26 ******************************************************
                            '生産終了品チェック
                            'CHG START FKS)INABA 2007/06/12 *************************************************
                            'サービスパーツ対応
                            If Mst_Inf.PRDENDKB = gc_strPRDENDKB_END And SP_FLG <> "1" Then
                                '                            If Mst_Inf.PRDENDKB = gc_strPRDENDKB_END Then
                                'CHG  END  FKS)INABA 2007/06/12 *************************************************
                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_007, pm_All) = MsgBoxResult.Cancel Then
                                    Retn_Code = CHK_ERR_ELSE
                                    GoTo F_Chk_BD_HINCD_BK_END
                                End If
                            End If

                            '出荷停止品チェック
                            If Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_008, pm_All) = MsgBoxResult.Cancel Then
                                    Retn_Code = CHK_ERR_ELSE
                                    GoTo F_Chk_BD_HINCD_BK_END
                                End If
                            End If
                            'ADD START FKS)INABA 2006/12/26 **********************************************************************************
                            '出荷準備品チェック
                            If Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_093, pm_All) = MsgBoxResult.Cancel Then
                                    Retn_Code = CHK_ERR_ELSE
                                    GoTo F_Chk_BD_HINCD_BK_END
                                End If
                            End If
                            'ADD  END  FKS)INABA 2006/12/26 **********************************************************************************

                            '2006.11.09 ADD -[START]
                            '仮製品チェック
                            If Mst_Inf.KHNKB = "9" Then
                                Retn_Code = CHK_ERR_ELSE
                                Err_Cd = "HINCD"
                                GoTo F_Chk_BD_HINCD_BK_ERROR
                            End If
                            '2006.11.09 ADD -[E N D]

                            '在庫管理区分チェック (06/09/26 H.Y.)
                            If Mst_Inf.ZAIKB <> gc_strZAIKB_OK Then
                                Retn_Code = CHK_ERR_ELSE
                                Err_Cd = gc_strMsgIDOET52_E_064
                                GoTo F_Chk_BD_HINCD_BK_END
                            End If

                            'OEM区分
                            'CHG START FKS)INABA 2007/06/07 **********************************************************************************
                            If Mst_Inf.OEMKB = gc_strOEMKB_OK Then
                                '                            If Mst_Inf.OEMKB <> gc_strOEMKB_OK Then
                                'CHG  END  FKS)INABA 2007/06/07 **********************************************************************************
                                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_094, pm_All) = MsgBoxResult.Cancel Then
                                    Retn_Code = CHK_ERR_ELSE
                                    GoTo F_Chk_BD_HINCD_BK_END
                                End If
                            End If

                            'DEL START FKS)INABA 2006/12/26 ***********************************************
                            '                            '出荷停止日チェック (06/09/26 H.Y.)
                            '                            If Trim(Mst_Inf.ORTSTPDT) <> "" And Mst_Inf.ORTSTPDT <= GV_UNYDate Then
                            '                                Retn_Code = CHK_ERR_ELSE
                            '                                Err_Cd = gc_strMsgIDOET52_W_008
                            '                                GoTo F_Chk_BD_HINCD_BK_END
                            '                            End If
                            '                            '商品種別チェック
                            '                            If Mst_Inf.HINID = gc_strHINID_TITLE _
                            ''                            Or Mst_Inf.HINID = gc_strHINID_NEBIKI Then
                            '                                Retn_Code = CHK_ERR_ELSE
                            '                                Err_Cd = gc_strMsgIDOET52_E_018
                            '                                GoTo F_Chk_BD_HINCD_BK_END
                            '                            End If
                            'DEL  END  FKS)INABA 2006/12/26 ***********************************************
                            ' 一括チェックの場合は警告は表示させない
                            'ＯＫ
                            Retn_Code = CHK_OK
                            pm_Chk_Move = True
                            Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

                            'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                                GoTo F_Chk_BD_HINCD_BK_END
                            End If



                            ' === 20060831 === DELETE S - ACE)Nagasawa 一括チェックの場合は警告は表示させない
                            '                        'ＯＫ
                            '                        Retn_Code = CHK_OK
                            '                        pm_Chk_Move = True
                            '                        Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_all)
                            '
                            '                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            '                            GoTo F_Chk_BD_HINCD_BK_END
                            '                        End If
                            ' === 20060831 === DELETE E -

                            With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
                                .HINCD = Mst_Inf.HINCD '商品マスタ.製品コード
                                .HINNMA = Mst_Inf.HINNMA '商品マスタ.型式
                                .HINNMB = Mst_Inf.HINNMB '商品マスタ.商品名１
                                .UNTCD = Mst_Inf.UNTCD '商品マスタ.単位コード
                                .UNTNM = Mst_Inf.UNTNM '商品マスタ.単位名
                                .HINKB = Mst_Inf.HINKB '商品マスタ.商品区分
                                .HINMTA_HINID = Mst_Inf.HINID '商品マスタ.商品種別
                                .ZAIKB = Mst_Inf.ZAIKB '商品マスタ.在庫管理区分
                                .HINZEIKB = Mst_Inf.HINZEIKB '商品マスタ.商品消費税区分
                                .ZEIRNKKB = Mst_Inf.ZEIRNKKB '商品マスタ.消費税ランク
                                .TEIKATK = CStr(Mst_Inf.TEIKATK) '商品マスタ.定価
                                .SIKTK = CStr(Mst_Inf.GNKTK) '商品マスタ.原価単価
                                .HINNMMKB = Mst_Inf.HINNMMKB '商品マスタ.名称ﾏﾆｭｱﾙ入力区分
                                .HINMTA_PRDENDKB = Mst_Inf.PRDENDKB '商品マスタ.生産終了
                                .HINMTA_PRDENDDT = Mst_Inf.PRDENDDT '商品マスタ.生産終了日付
                                .HINMTA_SLENDKB = Mst_Inf.SLENDKB '商品マスタ.販売完了
                                .HINMTA_SLENDDT = Mst_Inf.SLENDDT '商品マスタ.販売完了日付
                                .HINMTA_JODSTPKB = Mst_Inf.JODSTPKB '商品マスタ.受注停止
                                .HINMTA_JODSTPDT = Mst_Inf.JODSTPDT '商品マスタ.受注停止日付
                                .HINMTA_MDLCL = Mst_Inf.MDLCL '商品マスタ.機種分類
                                .HINMTA_HINGRP = Mst_Inf.HINGRP '商品マスタ.商品群
                                .GNKCD = Mst_Inf.GNKCD '商品マスタ.原価管理コード
                                .MAKCD = Mst_Inf.MAKCD '商品マスタ.メーカーコード
                                .MAKNM = Mst_Inf.MAKNM '商品マスタ.メーカー名
                                .HRTDD = Mst_Inf.HRTDD '商品マスタ.発注リードタイム
                                .ORTDD = Mst_Inf.ORTDD '商品マスタ.出荷リードタイム
                                .ZAIRNK = Mst_Inf.ZAIRNK '商品マスタ.在庫ランク
                                .SODUNTSU = Mst_Inf.SODUNTSU '商品マスタ.発注単位数
                                .SIKRT_PER = DSP_PER
                                .SIKSA_DSP = DSP_SIKSA
                                .HINMTA_KHNKB = Mst_Inf.KHNKB '商品マスタ.仮本区分
                                .JANCD = Mst_Inf.JANCD '商品マスタ.JANコード (H.Y. 9/24)
                                'ADD START FKS)INABA 2007/01/25 *************************************************
                                .TNACM = Mst_Inf.TNACM
                                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value) <> "" Then
                                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    IDOET52_SBNTRA_Inf.SOUCD = Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value)
                                    If Trim(IDOET52_SBNTRA_Inf.SOUCD) <> Trim(Mst_Inf.TNACM) Then '標準倉庫コード
                                        '画面で入力された倉庫コードと商品マスタに設定されている標準倉庫が違う場合メッセージを表示する。
                                        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_W_101, pm_All)
                                        '入力した倉庫と標準倉庫が違いますが、確認してください。
                                    End If
                                End If
                                'ADD  END  FKS)INABA 2007/01/25 *************************************************
                            End With

                    End Select
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If

            End If
        End If
        'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

F_Chk_BD_HINCD_BK_END:
        '戻値、メッセージ、ステータス、移動制御

        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
        End If

        '2006.11.09 ADD -[START]
        GoTo LBL_END

F_Chk_BD_HINCD_BK_ERROR:
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        Call AE_CmnMsgLibrary(SSS_PrgNm, "2HINCD", pm_All, Err_Msg)

LBL_END:
        '2006.11.09 ADD -[E N D]

        F_Chk_BD_HINCD_BK = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_HINCD_Inf
    '   概要：  製品コードによる画面表示
    '   引数：
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_HINCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Wk_Index As Short
        Dim Trg_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short
        Dim Wk_Col As Short
        Dim Wk_Value As Object
        Dim Focus_Ctl As Boolean
        Dim curBSART As Decimal
        Dim curMitKn As Decimal
        Dim Bd_Meisai_Index As Short '画面の明細の位置
        Dim Init_Inf As Cls_Dsp_Body_Bus_Inf
        Dim strUODSU As String
        Dim strTOKJDNNO As String
        Dim strTOKJDNED As String
        Dim strORD_HINCD As String
        Dim Dsp_Value As Object

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '製品コードが変更された場合
            'DEL START FKS)INABA 2007/11/13 **********************************************************
            '        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            'DEL  END  FKS)INABA 2007/11/13 **********************************************************
            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(0).Tag)
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)

            '--------------------------------------------------------------
            '--------------------------------------------------------------
            '【型式】
            Wk_Index = CShort(FR_SSSMAIN.BD_HINNMA(0).Tag)

            '画面に編集
            Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB_ERR)
            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
            '--------------------------------------------------------------
            '--------------------------------------------------------------
            '【品名】
            Wk_Index = CShort(FR_SSSMAIN.BD_HINNMB(0).Tag)

            '画面に編集
            Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB_ERR)
            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
            '--------------------------------------------------------------
            '--------------------------------------------------------------
            '【単位】
            Wk_Index = CShort(FR_SSSMAIN.BD_UNTNM(0).Tag)

            '画面に編集
            Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB_ERR)
            '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB_ERR)
            '--------------------------------------------------------------
            '--------------------------------------------------------------
            '--------------------------------------------------------------

            ''H.Y.(9/22)S '** ｺﾝﾄﾛｰﾙ制御 **
            ''            '名称ﾏﾆｭｱﾙ入力区分='1'の場合、型式・品名は変更可
            ''            If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMMKB = gc_strNMMKB_OK Then
            ''                Focus_Ctl = True
            ''            Else
            ''                Focus_Ctl = False
            ''            End If
            ''            '【型式】
            ''            Wk_Index = CInt(FR_SSSMAIN.BD_HINNMA(0).Tag)
            ''            Call CF_Set_Dsp_Body_Item_Focus_Ctl(Focus_Ctl _
            '''                                              , pm_All.Dsp_Sub_Inf(Wk_Index) _
            '''                                              , Wk_Row _
            '''                                              , pm_All)
            ''
            ''            '【品名】
            ''            Wk_Index = CInt(FR_SSSMAIN.BD_HINNMB(0).Tag)
            ''            Call CF_Set_Dsp_Body_Item_Focus_Ctl(Focus_Ctl _
            '''                                              , pm_All.Dsp_Sub_Inf(Wk_Index) _
            '''                                              , Wk_Row _
            '''H.Y.(9/22)E                                   , pm_All)

            '--------------------------------------------------------------

            '復元内容、前回内容を退避
            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            'DEL START FKS)INABA 2007/11/13 **********************************************************
            '        End If
            'DEL  END  FKS)INABA 2007/11/13 **********************************************************
        Else
            'クリア
            '--------------------------------------------------------------
            If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED) = "" Then
                '--------------------------------------------------------------
                '--------------------------------------------------------------
                '【型式】
                Wk_Index = CShort(FR_SSSMAIN.BD_HINNMA(0).Tag)

                '画面クリア
                Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
                '--------------------------------------------------------------
                '--------------------------------------------------------------
                '【品名】
                Wk_Index = CShort(FR_SSSMAIN.BD_HINNMB(0).Tag)

                '画面クリア
                Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
                '--------------------------------------------------------------
                '【単位】
                Wk_Index = CShort(FR_SSSMAIN.BD_UNTNM(0).Tag)

                '画面クリア
                Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
                '--------------------------------------------------------------
                '** ｺﾝﾄﾛｰﾙ制御 **
                '【型式】
                Wk_Index = CShort(FR_SSSMAIN.BD_HINNMA(0).Tag)
                Call CF_Set_Dsp_Body_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)

                '【品名】
                Wk_Index = CShort(FR_SSSMAIN.BD_HINNMB(0).Tag)
                Call CF_Set_Dsp_Body_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)


                'クリアしない値の退避
                strUODSU = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU
                strTOKJDNNO = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO
                strTOKJDNED = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED
                strORD_HINCD = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD
                '構造体クリア
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf = Init_Inf
                '退避した情報を戻す
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = strUODSU
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNNO = strTOKJDNNO
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TOKJDNED = strTOKJDNED
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.ORD_HINCD = strORD_HINCD
            End If

        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_HINNMA
    '   概要：  型式のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_HINNMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Bd_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_HINNMA = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA = ""
            Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
                Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_BD_HINNMA_END
                End If

                '入力内容格納
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMA = Input_Value
            End If

        End If

F_Chk_BD_HINNMA_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_BD_HINNMA = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_HINNMA_Inf
    '   概要：  型式よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_HINNMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then


                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_HINNMB
    '   概要：  品名のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_HINNMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Bd_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_HINNMB = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
                Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_BD_HINNMB_END
                End If

            End If

        End If

F_Chk_BD_HINNMB_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_BD_HINNMB = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_HINNMB_Inf
    '   概要：  品名よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_HINNMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_UODSU
    '   概要：  数量のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_UODSU(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Bd_Index As Short
        Dim curZeigk As Decimal
        Dim intRet As Short
        Dim Err_Msg As String
        Dim strTeikaTK As String
        Dim Wk_Col As Short
        Dim strSOUCD As String ' 倉庫コード
        Dim strHINCD As String ' 品番コード

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_UODSU = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Err_Msg = ""
        Msg_Flg = False
        pm_Chk_Move = True
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        '    If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        '        pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = ""
        '        Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
        '''H.Y.(9/21)        pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODKN = ""    ' 受注金額
        '    Else
        '未入力以外のチェック済
        pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
        Dim a As Short
        '基礎チェック
        '        If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
        '            Retn_Code = CHK_ERR_ELSE
        '            Err_Cd = gc_strMsgIDOET52_E_001              '入力範囲外
        '        Else
        'CHG START FKS)INABA 2006/11/15 ***********************************************
        '出庫理由の区分３が９の場合、数量はマイナスでなければエラーとする
        a = CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value)
        If Trim(Input_Value) = "" Then Input_Value = CStr(Val(Input_Value))
        If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" Then
            'CHG START FKS)INABA 2007/03/28 ********************************
            '戻り処理の場合にゼロ入力を許す(保留)
            '                If CCur(Trim(Input_Value)) > 0 Then
            'CHG START FKS)INABA 2007/10/03 ********************************
            If IsNumeric(Input_Value) = False Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_072
                GoTo F_Chk_BD_UODSU_END
            ElseIf CDec(Trim(Input_Value)) >= 0 Then
                '                If CCur(Trim(Input_Value)) >= 0 Then
                'CHG  END  FKS)INABA 2007/10/03 ********************************
                'CHG  END  FKS)INABA 2007/03/28 ********************************
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_072
                GoTo F_Chk_BD_UODSU_END
            End If
            'ADD START FKS)INABA 2006/12/01 ****************************************************************************************************
            If Trim(IDOET52_SBNTRA_Inf.OUTRYKB3) = "9" And FR_SSSMAIN.HD_OPT2.Checked = True Then
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Retn_Code = F_Chk_Shikyu(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20), CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 20), CDec(Trim(Input_Value)))
                Select Case Retn_Code
                    Case 1
                        '製番が支給品ファイルに存在する。(正常)
                    Case 2
                        '製番、製品コードで検索し、存在する(正常)
                    Case 7
                        '出庫済み数量が戻し数量より少ない
                        Err_Cd = gc_strMsgIDOET52_E_080
                        Retn_Code = CHK_ERR_ELSE
                        GoTo F_Chk_BD_UODSU_END
                    Case 8
                        'ADD START FKS)INABA 2007/03/10 *****************************
                        FR_SSSMAIN.HD_OPT1.Checked = True
                        FR_SSSMAIN.HD_OPT2.Checked = False
                        'ADD  END  FKS)INABA 2007/03/10 *****************************
                        'DEL START FKS)INABA 2007/03/12 **************************************
                        '                                Err_Cd = gc_strMsgIDOET52_E_009
                        '                                Retn_Code = CHK_ERR_ELSE
                        '                                GoTo F_Chk_BD_UODSU_END
                        'DEL  END  FKS)INABA 2007/03/12 **************************************
                    Case 9
                        'その他エラー
                End Select
            End If
            'ADD  END  FKS)INABA 2006/12/01 ****************************************************************************************************

        Else
            If CDec(Trim(CStr(Val(Input_Value)))) < 0 Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_079
                GoTo F_Chk_BD_UODSU_END
            End If
            If RunMode = RUNMODE_IDOET53 And IDOET52_SBNTRA_Inf.OUTSMSU <> 0 Then
                'CHG START FKS)INABA 2007/05/29 *********************************************************************************************************
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value) < IDOET52_SBNTRA_Inf.OUTSMSU Then
                    '                    If CF_Ora_Number(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_UODSU(1).Tag).Detail.Dsp_Value) <= IDOET52_SBNTRA_Inf.OUTSMSU Then
                    'CHG  END  FKS)INABA 2007/05/29 *********************************************************************************************************
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_098
                    GoTo F_Chk_BD_UODSU_END
                End If
            End If
            '有効在庫数チェック
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSOUCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_SOUCD.Tag))) ' 倉庫コード
            'strHINCD = pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINCD                             ' 品番
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strHINCD = pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value ' 品番

            'DEL START FKS)INABA 2008/07/29 ********************************************************************
            ''CHG START FKS)INABA 2006/11/30 ***************************************************************
            '                intRet = F_Chk_Relzaisu(strSOUCD, strHINCD, CCur(Trim(Val(Input_Value))), pm_All)
            '                Select Case intRet
            '                    Case 1  '在庫管理しない製品コード
            '                        Retn_Code = CHK_ERR_ELSE
            '                        Err_Cd = gc_strMsgIDOET52_E_064
            '                        GoTo F_Chk_BD_UODSU_END
            '                    Case 2  'HINMTAに無い
            '                        Retn_Code = CHK_ERR_ELSE
            '                        Err_Cd = gc_strMsgIDOET52_E_081
            '                        GoTo F_Chk_BD_UODSU_END
            ''ADD START FKS)INABA 2007/01/08 ********************************************************************
            ''有効在庫数チェック仕様変更（ワーニングを表示する）
            ''①現在庫数＜出庫数
            ''Message：出庫数が現在庫数を超えています。
            ''②現在庫数－引当済数＜出庫数
            ''Message：出庫数が有効在庫数を超えています。
            ''③現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
            ''Message：安全在庫数を下回ります。
            '                    Case 3  '現在庫数＜出庫数
            ''CHG START FKS)INABA 2007/12/14 ********************************************
            '                        If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
            '                            Retn_Code = CHK_ERR_ELSE
            '                            Err_Cd = gc_strMsgIDOET52_E_016
            '                            Msg_Flg = True
            '                            GoTo F_Chk_BD_UODSU_END
            '                        Else
            '                            Err_Cd = gc_strMsgIDOET52_W_095
            '                            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
            '                        End If
            ''                        Err_Cd = gc_strMsgIDOET52_W_095
            ''                        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
            ''CHG  END  FKS)INABA 2007/12/14 ********************************************
            '                    Case 4  '現在庫数－引当済数＜出庫数
            ''CHG START FKS)INABA 2007/12/14 ********************************************
            '                        If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
            '                           Retn_Code = CHK_ERR_ELSE
            '                           Err_Cd = gc_strMsgIDOET52_E_017
            '                            Msg_Flg = True
            '                            GoTo F_Chk_BD_UODSU_END
            '                        Else
            '                            Err_Cd = gc_strMsgIDOET52_W_096
            '                            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
            '                        End If
            ''                        Err_Cd = gc_strMsgIDOET52_W_096
            ''                        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
            ''CHG  END  FKS)INABA 2007/12/14 ********************************************
            '                    Case 5  '現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
            '                        Err_Cd = gc_strMsgIDOET52_W_097
            '                        Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
            ''ADD  END  FKS)INABA 2007/01/08 ********************************************************************
            '                    Case 0  '正常終了
            '                End Select
            '
            'DEL  END  FKS)INABA 2008/07/29 ********************************************************************
            '                intRet = F_Chk_Relzaisu(strSOUCD, strHINCD, CCur(Trim(Input_Value)))
            '                If intRet = 1 Or intRet = 2 Then
            '                    Retn_Code = CHK_ERR_ELSE
            '                    Err_Cd = gc_strMsgIDOET52_E_063
            '                    GoTo F_Chk_BD_UODSU_END
            '                End If
            'CHG  END  FKS)INABA 2006/11/30 ***************************************************************
        End If
        '            '有効在庫数チェック
        '            strSOUCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)))     ' 倉庫コード
        '            'strHINCD = pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINCD                             ' 品番
        '            strHINCD = pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_HINCD(1).Tag).Detail.Dsp_Value          ' 品番
        '            intRet = F_Chk_Relzaisu(strSOUCD, strHINCD, CCur(Trim(Input_Value)))
        '            If intRet = 1 Or intRet = 2 Then
        '                Retn_Code = CHK_ERR_ELSE
        '                Err_Cd = gc_strMsgIDOET52_E_063
        '                GoTo F_Chk_BD_UODSU_END
        '            End If
        'CHG  END  FKS)INABA 2006/11/15 ***********************************************

        'ＯＫ
        Retn_Code = CHK_OK
        pm_Chk_Move = True
        Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
            GoTo F_Chk_BD_UODSU_END
        End If

        'pm_All.Dsp_Body_Infの行ＮＯを取得
        pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UODSU = Input_Value

        '        End If

        'End If

F_Chk_BD_UODSU_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All, Err_Msg)
        End If

        F_Chk_BD_UODSU = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_UODSU_Inf
    '   概要：  数量による画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_UODSU_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_LINCMA
    '   概要：  明細備考１のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_LINCMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Bd_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_LINCMA = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
                Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_BD_LINCMA_END
                End If

                'pm_All.Dsp_Body_Inf.Row_Inf().Bus_Infに設定
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA = Input_Value
            End If

        End If

F_Chk_BD_LINCMA_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_BD_LINCMA = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSADA
    '   概要：  住所１のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSADA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSADA = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.NHSADA = ""
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_HD_NHSADA_END
                End If

                IDOET52_SBNTRA_Inf.NHSADA = Input_Value
            End If

        End If

F_Chk_HD_NHSADA_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSADA = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSADB
    '   概要：  住所２のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSADB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSADB = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.NHSADB = ""
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_HD_NHSADB_END
                End If

                IDOET52_SBNTRA_Inf.NHSADB = Input_Value
            End If

        End If

F_Chk_HD_NHSADB_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSADB = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSADC
    '   概要：  住所３のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSADC(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSADC = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.NHSADC = ""
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True

                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_HD_NHSADC_END
                End If

                IDOET52_SBNTRA_Inf.NHSADC = Input_Value
            End If

        End If

F_Chk_HD_NHSADC_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSADC = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_LINCMA_Inf
    '   概要：  明細備考１よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_LINCMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSADA_Inf
    '   概要：  住所１よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSADA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSADB_Inf
    '   概要：  住所２よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSADB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSADC_Inf
    '   概要：  住所３よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSADC_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_BD_LINCMB
    '   概要：  明細備考２のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_BD_LINCMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String
        Dim Bd_Index As Short

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_BD_LINCMB = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            Call CF_Edi_Dsp_Body_Inf("", pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
                Call CF_Edi_Dsp_Body_Inf(Input_Value, pm_Chk_Dsp_Sub_Inf, Bd_Index, pm_All)

                'H.Y.(9/24) Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
                'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    GoTo F_Chk_BD_LINCMB_END
                End If

                'pm_All.Dsp_Body_Inf.Row_Inf().Bus_Infに設定
                pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB = Input_Value
            End If

        End If

F_Chk_BD_LINCMB_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_BD_LINCMB = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_BD_LINCMB_Inf
    '   概要：  明細備考２よる画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_BD_LINCMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short
        Dim Wk_Row As Short
        Dim Bd_Index As Short

        '画面の行
        Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
        'pm_All.Dsp_Body_Infの行ＮＯを取得
        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSCD
    '   概要：  納入先コードのﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Mst_Inf As TYPE_DB_NHSMTA
        Dim Mst_Inf_BIN As TYPE_DB_MEIMTA
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            Retn_Code = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True
        '2019/06/20 CHG START
        'Call DB_NHSMTA_Clear(Mst_Inf)
        Call InitDataCommon("NHSMTA")
        '2019/06/20 CHG'

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            IDOET52_SBNTRA_Inf.NHSCD = "" '納入先コード
            IDOET52_SBNTRA_Inf.NHSNMA = "" '納入先名称１
            IDOET52_SBNTRA_Inf.NHSNMB = "" '納入先名称２
            IDOET52_SBNTRA_Inf.NHSADA = "" '納入先住所１
            IDOET52_SBNTRA_Inf.NHSADB = "" '納入先住所２
            IDOET52_SBNTRA_Inf.NHSADC = "" '納入先住所３
            'ADD START FKS) INABA 2006/11/16 *************************************************************
            IDOET52_SBNTRA_Inf.BINCD = ""
            IDOET52_SBNTRA_Inf.BINNM = ""
            'ADD  END  FKS) INABA 2006/11/16 *************************************************************
            'ADD START FKS) INABA 2006/12/26 *************************************************************
            IDOET52_SBNTRA_Inf.NHSZIPCD = ""
            IDOET52_SBNTRA_Inf.NHSTL = ""
            IDOET52_SBNTRA_Inf.NHSFAX = ""
            IDOET52_SBNTRA_Inf.NHSNMMKB = ""
            'ADD  END  FKS) INABA 2006/12/26 *************************************************************

            '' 納入先は必須で無くなった(H.Y.)
            ''        Retn_Code = CHK_ERR_NOT_INPUT
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'マスタチェック
                If DSPNHSCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
                    '論理削除チェック
                    If Mst_Inf.DATKB = gc_strDATKB_DEL Then
                        Retn_Code = CHK_ERR_ELSE
                        Err_Cd = gc_strMsgIDOET52_E_002 '削除済みデータ
                    Else
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                            GoTo F_Chk_HD_NHSCD_END
                        End If

                        IDOET52_SBNTRA_Inf.NHSNMMKB = Mst_Inf.NHSNMMKB
                        If IDOET52_SBNTRA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
                            IDOET52_SBNTRA_Inf.NHSCD = Mst_Inf.NHSCD '納入先コード
                            IDOET52_SBNTRA_Inf.NHSNMA = IDOET52_SBNTRA_Inf.NHSNMA '納入先名称１
                            IDOET52_SBNTRA_Inf.NHSNMB = IDOET52_SBNTRA_Inf.NHSNMB '納入先名称２
                            IDOET52_SBNTRA_Inf.NHSADA = IDOET52_SBNTRA_Inf.NHSADA '納入先住所１
                            IDOET52_SBNTRA_Inf.NHSADB = IDOET52_SBNTRA_Inf.NHSADB '納入先住所２
                            IDOET52_SBNTRA_Inf.NHSADC = IDOET52_SBNTRA_Inf.NHSADC '納入先住所３
                            'ADD START FKS) INABA 2006/12/26 *************************************************************
                            IDOET52_SBNTRA_Inf.NHSZIPCD = IDOET52_SBNTRA_Inf.NHSZIPCD
                            IDOET52_SBNTRA_Inf.NHSTL = IDOET52_SBNTRA_Inf.NHSTL
                            IDOET52_SBNTRA_Inf.NHSFAX = IDOET52_SBNTRA_Inf.NHSFAX
                            IDOET52_SBNTRA_Inf.NHSNMMKB = IDOET52_SBNTRA_Inf.NHSNMMKB
                            'ADD  END  FKS) INABA 2006/12/26 *************************************************************
                        Else
                            IDOET52_SBNTRA_Inf.NHSCD = Mst_Inf.NHSCD '納入先コード
                            IDOET52_SBNTRA_Inf.NHSNMA = Mst_Inf.NHSNMA '納入先名称１
                            IDOET52_SBNTRA_Inf.NHSNMB = Mst_Inf.NHSNMB '納入先名称２
                            '' 納入先入力時は納入先の住所を「住所」とする(9/27)
                            IDOET52_SBNTRA_Inf.NHSADA = Mst_Inf.NHSADA '納入先住所１
                            IDOET52_SBNTRA_Inf.NHSADB = Mst_Inf.NHSADB '納入先住所２
                            IDOET52_SBNTRA_Inf.NHSADC = Mst_Inf.NHSADC '納入先住所３
                            'ADD START FKS) INABA 2006/12/26 *************************************************************
                            IDOET52_SBNTRA_Inf.NHSZIPCD = Mst_Inf.NHSZP
                            IDOET52_SBNTRA_Inf.NHSTL = Mst_Inf.NHSTL
                            IDOET52_SBNTRA_Inf.NHSFAX = Mst_Inf.NHSFX
                            IDOET52_SBNTRA_Inf.NHSNMMKB = Mst_Inf.NHSNMMKB
                            'ADD  END  FKS) INABA 2006/12/26 *************************************************************
                        End If
                        'ADD START FKS) INABA 2006/11/16 *************************************************************
                        IDOET52_SBNTRA_Inf.BINCD = Mst_Inf.BINCD '便コード
                        If DSPMEIM_SEARCH("002", IDOET52_SBNTRA_Inf.BINCD, Mst_Inf_BIN) = 0 Then
                            '論理削除チェック
                            If Mst_Inf_BIN.DATKB = gc_strDATKB_DEL Then
                                IDOET52_SBNTRA_Inf.BINNM = "" '便名名称
                            Else
                                IDOET52_SBNTRA_Inf.BINNM = Mst_Inf_BIN.MEINMA '便名名称
                            End If
                        Else
                            IDOET52_SBNTRA_Inf.BINNM = "" '便名名称
                        End If
                        'ADD  END  FKS) INABA 2006/11/16 *************************************************************
                    End If
                Else
                    Retn_Code = CHK_ERR_ELSE
                    Err_Cd = gc_strMsgIDOET52_E_009 '該当データなし
                End If
            End If
        End If

F_Chk_HD_NHSCD_END:
        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSCD = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSCD_Inf
    '   概要：  納入先コードによる画面表示
    '   引数：
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object

        If pm_Mode = DSP_SET Then
            '表示
            '得意先コードが変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '【納入先名１】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【納入先名２】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD START FKS)INABA 2006/12/26 **************************************************************************
                '郵便番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSZIPCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSZIPCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                '電話番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSTL, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ＦＡＸ番号
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSFAX.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSFAX, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD  END  FKS)INABA 2006/12/26 **************************************************************************

                '【住所１】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【住所２】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '【住所３】
                Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSADC, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD START FKS)INABA 2006/11/16 ***********************************************************************
                '便コード
                Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)

                '便名
                Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BINNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB_ERR)
                'ADD  END  FKS)INABA 2006/11/16 ***********************************************************************
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_NHSCD.Tag)))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_TOKCD.Tag)))) <> "" Then
                Else
                End If
                'ADD START FKS)INABA 2007/01/04 *************************************************************
                '            If pm_All.Dsp_Base.Head_Ok_Flg = True Then
                '** ｺﾝﾄﾛｰﾙ制御 **
                '【納入先名】
                '名称ﾏﾆｭｱﾙ入力区分='1'の場合、納入先名は変更可
                If IDOET52_SBNTRA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
                    Focus_Ctl = True
                Else
                    Focus_Ctl = False
                End If

                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
                If Focus_Ctl = True Then
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
                Else
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
                End If
                'コントロールの前景/背景色
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)

                Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
                If Focus_Ctl = True Then
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
                Else
                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
                End If
                'コントロールの前景/背景色
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)

                '            End If
                'ADD  END  FKS)INABA 2007/01/04 *************************************************************

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
            '【納入先名１】
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '【納入先名２】
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
            Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

            '** ｺﾝﾄﾛｰﾙ制御 **
            '【納入先名称１】
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
            Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Trg_Index))

            '【納入先名称２】
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
            Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Trg_Index))

            '変数のクリア
            With IDOET52_SBNTRA_Inf
                .NHSCD = ""
                .NHSNMA = ""
                .NHSNMB = ""
                .NHSADA = ""
                .NHSADB = ""
                .NHSADC = ""
            End With
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSNMA
    '   概要：  納入先名称１のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSNMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSNMA = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSNMA = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSNMA_Inf
    '   概要：  納入先名称１による画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSNMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_HD_NHSNMB
    '   概要：  納入先名称２のﾁｪｯｸ
    '   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
    '           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
    '           pm_All                :画面情報
    '   戻値：　チェック結果
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Chk_HD_NHSNMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Input_Value As String
        Dim Retn_Code As Short
        Dim Msg_Flg As Boolean
        Dim Rtn_Cd As Short
        Dim Err_Cd As String

        'チェック実行判定
        Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
        If Rtn_Cd = CHK_STOP Then
            '中断の場合
            F_Chk_HD_NHSNMB = Retn_Code
            Exit Function
        End If

        '初期化
        Retn_Code = CHK_OK
        Err_Cd = ""
        Msg_Flg = False
        pm_Chk_Move = True

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgIDOET52_E_001 '入力範囲外
            Else
                'ＯＫ
                Retn_Code = CHK_OK
                pm_Chk_Move = True
            End If

        End If

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)

        If Msg_Flg = True And Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Chk_HD_NHSNMB = Retn_Code

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_HD_NHSNMB_Inf
    '   概要：  納入先名称２による画面表示
    '   引数：  pm_Dsp_Sub_Inf   :
    '           pm_Mode          : 画面表示モード
    '           pm_All           : 画面情報
    '   戻値：
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_HD_NHSNMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Dsp_Value As Object
        Dim Wk_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '項目内容が変更された場合
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)

            End If
        Else
            'クリア
        End If

        '前回チェック内容に退避
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Dsp_Item_Detail
    '   概要：  各項目の画面表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)

        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            Case FR_SSSMAIN.HD_JDNNO.Name
                '参照見積番号による画面表示
                Call F_Dsp_HD_JDNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_TOKCD.Name
                '得意先コードによる画面表示
                Call F_Dsp_HD_TOKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_TOKRN.Name
                '得意先名による画面表示
                Call F_Dsp_HD_TOKRN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_TANCD.Name
                '営業担当者コードによる画面表示
                Call F_Dsp_HD_TANCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_BUMCD.Name
                '営業部門コードによる画面表示
                Call F_Dsp_HD_BUMCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_SOUCD.Name
                '出荷倉庫コードによる画面表示
                Call F_Dsp_HD_SOUCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_OUTRYCD.Name
                '出荷理由による画面表示
                Call F_Dsp_HD_OUTRYCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_SBNNO.Name
                '客先注文番号（ボディ）画面表示
                Call F_Dsp_HD_SBNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.TL_KKOUT.Name
                '緊急出庫による画面表示
                Call F_Dsp_TL_KKOUT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
                'ADD START FKS)INABA 2006/11/16 ******************************************
            Case FR_SSSMAIN.HD_BINCD.Name
                '便コードによる画面表示
                Call F_Dsp_HD_BINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
                'ADD  END  FKS)INABA 2006/11/16 ******************************************

            Case FR_SSSMAIN.BD_HINCD(1).Name
                '製品コードによる画面表示
                Call F_Dsp_BD_HINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.BD_HINNMA(1).Name
                '型式による画面表示
                Call F_Dsp_BD_HINNMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.BD_HINNMB(1).Name
                '品名による画面表示
                Call F_Dsp_BD_HINNMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.BD_UODSU(1).Name
                '数量による画面表示
                Call F_Dsp_BD_UODSU_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.BD_LINCMA(1).Name
                '明細備考１による画面表示
                Call F_Dsp_BD_LINCMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.BD_LINCMB(1).Name
                '明細備考２による画面表示
                Call F_Dsp_BD_LINCMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSCD.Name
                '納入先コードによる画面表示
                Call F_Dsp_HD_NHSCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSNMA.Name
                '納入先名称１による画面表示
                Call F_Dsp_HD_NHSNMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSNMB.Name
                '納入先名称２による画面表示
                Call F_Dsp_HD_NHSNMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSADA.Name
                '住所１による画面表示
                Call F_Dsp_HD_NHSADA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSADB.Name
                '住所２による画面表示
                Call F_Dsp_HD_NHSADB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

            Case FR_SSSMAIN.HD_NHSADC.Name
                '住所３による画面表示
                Call F_Dsp_HD_NHSADC_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)

        End Select

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Item_Chk
    '   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short

        Dim Rtn_Chk As Short

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK
        pm_Chk_Move_Flg = True
        '①基本入力内容のチェック
        Select Case pm_Dsp_Sub_Inf.Ctl.Name
            Case FR_SSSMAIN.HD_DENDT.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '出庫日のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_DENDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_OUTRYCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '出庫理由のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_OUTRYCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_JDNNO.Name
                '参照受注番号のﾁｪｯｸ
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                Rtn_Chk = F_Chk_HD_JDNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_TOKCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '得意先コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_TOKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_TOKRN.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '得意先名のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_TOKRN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_TANCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '営業担当者コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_TANCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_BUMCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '営業部門コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_BUMCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_SOUCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '出庫倉庫コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_SOUCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_SBNNO.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                'CHG START FKS)INABA 2006/11/29 ***********************************************
                '製番のチェック
                'CHG  END  FKS)INABA 2006/11/29 ***********************************************
                Rtn_Chk = F_Chk_HD_SBNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.TL_KKOUT.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '緊急出庫のﾁｪｯｸ
                Rtn_Chk = F_Chk_TL_KKOUT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
                'ADD START FKS)INABA 2006/11/16************************************************
            Case FR_SSSMAIN.HD_BINCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '便コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_BINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
                'ADD  END  FKS)INABA 2006/11/16************************************************
            Case FR_SSSMAIN.BD_HINCD(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '製品コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_HINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.BD_HINNMA(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '型式のﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_HINNMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.BD_HINNMB(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '品名のﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_HINNMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.BD_UODSU(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '数量のﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_UODSU(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.BD_LINCMA(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '明細備考１のﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_LINCMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.BD_LINCMB(1).Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '明細備考２のﾁｪｯｸ
                Rtn_Chk = F_Chk_BD_LINCMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_NHSCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '納入先コードのﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_NHSNMA.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '納入先名１のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSNMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_NHSNMB.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '納入先名２のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSNMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
            Case FR_SSSMAIN.HD_NHSTL.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '電話番号のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSTL(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
            Case FR_SSSMAIN.HD_NHSZIPCD.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '郵便番号のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSZIPCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
            Case FR_SSSMAIN.HD_NHSFAX.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                'FAX番号のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSFAX(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
            Case FR_SSSMAIN.HD_NHSADA.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '住所１のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSADA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_NHSADB.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '住所２のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSADB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

            Case FR_SSSMAIN.HD_NHSADC.Name
                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
                '住所３のﾁｪｯｸ
                Rtn_Chk = F_Chk_HD_NHSADC(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)

        End Select

        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        Select Case True
            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox

                'DEL START FKS)INABA 2007/11/13 **************************************************************************
                '            If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value) Then
                'DEL  END  FKS)INABA 2007/11/13 **************************************************************************
                If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
                    '画面編集ありとする
                    gv_bolUODET51_INIT = True
                    ''H.Y.(9/20)S (HD_MITNOV削除)                    If pm_Dsp_Sub_Inf.Ctl.NAME <> FR_SSSMAIN.HD_JDNNO.NAME _
                    '''                        And pm_Dsp_Sub_Inf.Ctl.NAME <> FR_SSSMAIN.HD_MITNOV.NAME Then
                    ''                        gv_bolUODET51_INIT_MITNO = True
                    ''H.Y.(9/20)E                    End If
                End If
                'DEL START FKS)INABA 2007/11/13 **************************************************************************
                '            End If
                'DEL  END  FKS)INABA 2007/11/13 **************************************************************************

            Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
                    If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True And pm_Dsp_Sub_Inf.Detail.Locked = False Then
                        '画面編集ありとする
                        gv_bolUODET51_INIT = True
                    End If
                End If

            Case Else
        End Select

        F_Ctl_Item_Chk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_RunMode_Chk
    '   概要：  保存前の実行モードチェック
    '   引数：　なし
    '   戻値：　なし
    '   備考：  IDOET53では訂正対象となるSBNTRAの伝票管理番号DATNOが指定されていなければならない
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Ctl_RunMode_Chk(ByRef pm_All As Cls_All) As Short
        Dim Rtn_Chk As Short

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK

        If RunMode = RUNMODE_IDOET53 And IDOET52_SBNTRA_Inf.DATNO = "" Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_068, pm_All)
            Rtn_Chk = CHK_ERR_ELSE
        End If

        F_Ctl_RunMode_Chk = Rtn_Chk
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Head_Chk
    '   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Dsp_Mode As Short
        Dim intMoveFocus As Short

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK

        'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
        For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx

            ' 関連チェック対応
            'エラー状態を初期状態に（単項目ﾁｪｯｸを行わせるため）
            Call F_Reset_ErrStatus(pm_All.Dsp_Sub_Inf(Index_Wk))

            '各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
            Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)

            If Rtn_Chk = CHK_OK Then
                'チェックＯＫ時
                '取得内容表示
                Dsp_Mode = DSP_SET
            Else
                'チェックＮＧ時
                '取得内容クリア
                Dsp_Mode = DSP_CLR
            End If

            '取得内容表示/クリア
            Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)

            'チェックＮＧ
            If Rtn_Chk <> CHK_OK Then

                '未入力メッセージ
                If Rtn_Chk = CHK_ERR_NOT_INPUT Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_011, pm_All)
                End If

                'ﾁｪｯｸ後移動なし
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

                F_Ctl_Head_Chk = Rtn_Chk
                Exit Function
            End If
        Next

        '関連ﾁｪｯｸ
        Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
        'チェックＮＧ
        If Rtn_Chk <> CHK_OK Then

            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)

            F_Ctl_Head_Chk = Rtn_Chk
            Exit Function
        End If

        If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
            'チェックＯＫでかつ
            'ヘッダ部のチェックが初めての場合
            '１行目のボディ部を準備最終行として開放する
            pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
            'フッタ部を開放する
            Call F_Foot_In_Ready(pm_All)
            'チェックＯＫ
            pm_All.Dsp_Base.Head_Ok_Flg = True
        End If

        F_Ctl_Head_Chk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Head_RelChk
    '   概要：  ﾍｯﾀﾞ部の関連ﾁｪｯｸ
    '   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象（ゼロ:案件IDへ移動）
    '   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short

        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Trg_Index As Short
        Dim Err_Cd As String 'エラーコード
        Dim strMITNO As String '見積番号
        Dim strMITNOV As String '版数
        Dim intRet As Short
        Dim strSMEDT As String
        Dim strDENDT As String '受注日
        Dim strANID As String '案件ID
        Dim strJODRSNKB As String '受注理由
        Dim Mst_Inf_SOUMTA As TYPE_DB_SOUMTA
        Dim strSOUCD As String
        Dim strTOKCD As String
        Dim strSBNNO As String '製番

        'ADD START FKS)INABA 2006/11/20 **********************************************************
        Dim strTANCD As String '送り先担当者
        Dim strBUMCD As String '送り先部門コード
        Dim strNHSCD As String '納入先名
        Dim strNHSADA As String '納入先住所
        Dim strNHSADB As String '納入先住所
        Dim strNHSADC As String '納入先住所
        Dim strBINCD As String '便コード
        Dim strNHSTL As String '郵便番号
        'ADD  END  FKS)INABA 2006/11/20 **********************************************************
        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_ERR_ELSE
        Err_Cd = ""

        '参照受注番号取得
        Trg_Index = CShort(FR_SSSMAIN.HD_JDNNO.Tag)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strMITNO = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Dsp_Value

        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Trg_Index = CShort(FR_SSSMAIN.SYSDT.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strDENDT = VB6.Format(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)), "yyyymmdd")

        ''H.Y.(9/21)S    Select Case AE_UpdateJDN_Chk(strDENDT, IDOET52_SBNTRA_Inf.TOKCD)
        ''        '月次仮締日過ぎ
        ''        Case 1
        ''            Err_Cd = gc_strMsgIDOET52_E_052
        ''            pm_ErrIdx = CInt(FR_SSSMAIN.HD_DENDT.Tag)
        ''            GoTo F_Ctl_Head_RelChk_END
        ''        '得意先の請求締日過ぎ
        ''        Case 2
        ''            Err_Cd = gc_strMsgIDOET52_E_053
        ''            pm_ErrIdx = CInt(FR_SSSMAIN.HD_DENDT.Tag)
        ''            GoTo F_Ctl_Head_RelChk_END
        ''        Case Else
        ''H.Y.(9/21)E    End Select
        ' === 20060907 === UPDATE E -

        '出庫理由取得
        Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strJODRSNKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        If Trim(strJODRSNKB) = "" Then
            Err_Cd = gc_strMsgIDOET52_E_057
            pm_ErrIdx = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
            GoTo F_Ctl_Head_RelChk_END
        End If

        'DEL START FKS)INABA 2007/02/15 ********************************
        '    '倉庫コード取得
        '    Trg_Index = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
        '    strSOUCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        '    If Trim(strSOUCD) = "" Then
        '        Err_Cd = gc_strMsgIDOET52_E_058
        '        pm_ErrIdx = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
        '        GoTo F_Ctl_Head_RelChk_END
        '    End If
        'DEL  END  FKS)INABA 2007/02/15 ********************************

        '製番取得
        Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSBNNO = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSBNNO = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        'ADD START FKS)INABA 2007/01/20 *********************************
        'CHG START FKS)INABA 2007/01/26 *********************************
        If IDOET52_SBNTRA_Inf.OUTRYKB1 <> "1" And RunMode = RUNMODE_IDOET52 Then
            '    If strJODRSNKB <> "01" And strJODRSNKB <> "02" And RunMode = RUNMODE_IDOET52 Then
            'CHG  END  FKS)INABA 2007/01/26 *********************************
            'ADD  END  FKS)INABA 2007/01/20 *********************************
            If Trim(strSBNNO) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_059
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If
            'ADD START FKS)INABA 2007/01/20 *********************************
        End If
        'ADD  END  FKS)INABA 2007/01/20 *********************************

        'ADD START FKS)INABA 2006/11/20 **************************************
        '社内出庫、社外出庫のチェック

        '送り先担当者の取得
        Trg_Index = CShort(FR_SSSMAIN.HD_TANCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strTANCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        '送り先部門コードの取得
        Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strBUMCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))

        '得意先コードの取得
        Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strTOKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        '納入先コードの取得
        Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strNHSCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        '納入先住所の取得
        Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strNHSADA = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strNHSADB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strNHSADC = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        '便コードの取得
        Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strBINCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))

        '送り先担当者もしくは送り先部門コードが入力されている場合、
        '得意先コード、納入先コード、納入先住所、便コードが入っていればエラーとする
        If Trim(strTANCD) <> "" Or Trim(strBUMCD) <> "" Then
            If Trim(strTANCD) <> "" And Trim(strBUMCD) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_078
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If

            If Trim(strTANCD) = "" And Trim(strBUMCD) <> "" Then
                Err_Cd = gc_strMsgIDOET52_E_077
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_TANCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If

            If Trim(strTOKCD) <> "" Then
                Err_Cd = gc_strMsgIDOET52_E_073
            End If
            If Trim(strNHSCD) <> "" Then
                Err_Cd = gc_strMsgIDOET52_E_073
            End If
            If Trim(strNHSADA) <> "" Then
                Err_Cd = gc_strMsgIDOET52_E_073
            End If
            If Trim(strBINCD) <> "" Then
                Err_Cd = gc_strMsgIDOET52_E_073
            End If
            If Err_Cd <> "" Then
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_TANCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If
        End If
        '社外出庫の場合、得意先、納入先住所、便コードは必須とする
        If Trim(strTANCD) = "" Or Trim(strBUMCD) = "" Then
            If Trim(strTOKCD) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_074
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If
            If Trim(strNHSADA) & Trim(strNHSADB) & Trim(strNHSADC) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_075
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If
            If Trim(strBINCD) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_076
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_BINCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If
            If Err_Cd <> "" Then
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_TANCD.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If

            '電話番号取得
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strNHSTL = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))

            '電話番号は倉庫コードと同じ条件で必須
            If Trim(strNHSTL) = "" Then
                Err_Cd = gc_strMsgIDOET52_E_092
                pm_ErrIdx = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
                GoTo F_Ctl_Head_RelChk_END
            End If


        End If
        'ADD  END  FKS)INABA 2006/11/20 **************************************


        ' === 20060824 === INSERT S - ACE)Sejima 諸口対応
        ''H.Y.(9/21)S    '諸口チェック
        ''    If IDOET52_SBNTRA_Inf.SKCHKB = gc_strSKCHKB_SKCH Then
        ''        Err_Cd = gc_strMsgIDOET52_E_048
        ''        pm_ErrIdx = CInt(FR_SSSMAIN.HD_TOKCD.Tag)
        ''        GoTo F_Ctl_Head_RelChk_END
        ''H.Y.(9/21)E    End If
        ' === 20060824 === INSERT E

        ''H.Y.(9/21)S    '得意先コード取得
        ''    Trg_Index = CInt(FR_SSSMAIN.HD_TOKCD.Tag)
        ''H.Y.(9/21)E    strTOKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))

        ''H.Y.(9/21)S    '得意先取り置き倉庫チェック
        ''    If DSPSOUCD_SEARCH(strSOUCD, Mst_Inf_SOUMTA) = 0 Then
        ''        If Mst_Inf_SOUMTA.DATKB = gc_strDATKB_USE Then
        ''            If Trim(Mst_Inf_SOUMTA.SOUTRICD) <> "" _
        '''            And Trim(Mst_Inf_SOUMTA.SOUTRICD) <> Trim(strTOKCD) Then
        ''                Err_Cd = gc_strMsgIDOET52_E_015
        ''                pm_ErrIdx = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
        ''                GoTo F_Ctl_Head_RelChk_END
        ''            End If
        ''        End If
        ''H.Y.(9/21)E    End If

        Rtn_Chk = CHK_OK

F_Ctl_Head_RelChk_END:

        If Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Ctl_Head_RelChk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Body_Chk
    '   概要：  ﾎﾞﾃﾞｨ部のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk_Col As Short
        Dim Index_Wk_Row As Short
        Dim Trg_Index As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
        Dim Dsp_Mode As Short

        Dim Err_Row As Short
        Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
        Dim Bd_Idx As Short
        Dim Err_Index As Short
        Dim Move_Flg As Boolean
        Dim Focus_Ctl_Ok_Fst_Idx As Short
        Dim intMoveFocus As Short
        Dim intErrRow As Short
        Dim curUodKn As Decimal
        Dim curZeiKn As Decimal
        'UPGRADE_WARNING: 構造体 Row_inf_Zero の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Row_inf_Zero As Cls_Dsp_Body_Row_Inf

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK

        bolMEISAI_INPUT = False
        intMeisaiCnt = 0
        curTL_SBAUODKN = 0
        curTL_SBAUZEKN = 0
        curTL_SBAUZKKN = 0
        bolInput_Bef_Row = True
        ' 未入力行の対応
        intInput_Bef_RowNo = 0

        'ゼロ行目情報退避
        'UPGRADE_WARNING: オブジェクト Row_inf_Zero の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Row_inf_Zero = pm_All.Dsp_Body_Inf.Row_Inf(0)

        'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
        For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)

            Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
                Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
                    '入力待状態、入力済状態、最終準備行を対象
                    '隠行に画面明細の対象行をコピー
                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))

                    For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
                        '画面明細の隠行の項目のｲﾝﾃﾞｯｸｽを取得
                        Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)

                        'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
                        Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl

                        'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
                        '画面項目詳細情報を設定
                        'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)

                        ' 関連チェック対応
                        'エラー状態を初期状態に（単項目ﾁｪｯｸを行わせるため）
                        Call F_Reset_ErrStatus(Dsp_Sub_Inf_Wk)

                        '各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
                        Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)

                        If Rtn_Chk = CHK_OK Then
                            'チェックＯＫ時
                            '取得内容表示
                            Dsp_Mode = DSP_SET
                        Else
                            'チェックＮＧ時
                            '取得内容クリア
                            Dsp_Mode = DSP_CLR
                        End If

                        '取得内容表示/クリア
                        Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)

                        '｢画面ボディ情報｣にワークの｢画面項目情報｣を編集
                        '画面項目詳細情報を設定
                        '条件によって変更される項目のみ
                        Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)

                        'チェックＮＧ
                        Select Case Rtn_Chk
                            'OKの場合
                            Case CHK_OK

                                '未入力
                            Case CHK_ERR_NOT_INPUT

                            Case Else

                                'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
                                'エラー用変数格納
                                '行情報
                                Err_Row = Index_Wk_Row
                                '対象ｺﾝﾄﾛｰﾙ情報
                                Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
                                '画面項目詳細情報を設定
                                'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail

                                GoTo ERR_EXIT
                        End Select

                    Next
                    '関連ﾁｪｯｸ
                    Rtn_Chk = F_Ctl_Body_RelChk(Index_Wk_Row, pm_All, intMoveFocus, intErrRow)
                    'チェックＮＧ
                    If Rtn_Chk <> CHK_OK Then
                        F_Ctl_Body_Chk = Rtn_Chk
                        'エラー用変数格納
                        Err_Row = intErrRow
                        '対象ｺﾝﾄﾛｰﾙ情報
                        Err_Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(intMoveFocus).Ctl
                        '画面項目詳細情報を設定
                        'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Err_Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Sub_Inf(intMoveFocus).Detail

                        GoTo ERR_EXIT
                    End If

                    '本体合計金額計算
                    With pm_All.Dsp_Body_Inf.Row_Inf(0).Bus_Inf
                        ' === 20060722 === UPDATE S - ACE)Nagasawa
                        '                    If IsNumeric(.UODSU) = True And IsNumeric(.UODTK) = True Then
                        '                        curUodKn = CCur(.UODSU) * CCur(.UODTK)
                        '                    Else
                        '                        curUodKn = 0
                        '                    End If
                        If IsNumeric(.UODKN) = True Then
                            curUodKn = CDec(.UODKN)
                        Else
                            If IsNumeric(.UODSU) = True And IsNumeric(.UODTK) = True Then
                                curUodKn = CDec(.UODSU) * CDec(.UODTK)
                            Else
                                curUodKn = 0
                            End If
                        End If

                        If IsNumeric(.UZEKN) = True Then
                            curZeiKn = CDec(.UZEKN)
                        Else
                            curZeiKn = 0
                        End If
                    End With
                    curTL_SBAUODKN = curTL_SBAUODKN + curUodKn
                    curTL_SBAUZEKN = curTL_SBAUZEKN + curZeiKn
                    curTL_SBAUZKKN = curTL_SBAUZKKN + curUodKn + curZeiKn

                    '画面明細の対象行に隠行をコピー(元に戻す)
                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
            End Select
        Next

        '明細行に入力がない場合、エラー
        If bolMEISAI_INPUT = False Then

            'エラーメッセージ表示
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_014, pm_All)

            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)), pm_All)

            F_Ctl_Body_Chk = CHK_ERR_ELSE
            Exit Function

        End If

        F_Ctl_Body_Chk = Rtn_Chk

        Exit Function

ERR_EXIT:
        'エラー時、ﾌｫｰｶｽ移動
        '対象行を画面に表示
        Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
        'コントロール制御
        Call F_Set_Body_Enable(pm_All)
        '対象行から画面明細の行を取得
        Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
        '画面明細の行と同一の明細をインデックスを取得
        Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)

        If Err_Index > 0 Then
            '同一項目の１つ前からENTキー押下と同様に次の項目へ
            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)

        Else
            '入力可能な最初のインデックスを取得
            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
            If Focus_Ctl_Ok_Fst_Idx > 0 Then
                '同一項目の１つ前からENTキー押下と同様に次の項目へ
                Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            End If
        End If

        F_Ctl_Body_Chk = Rtn_Chk
        Exit Function

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Body_RelChk
    '   概要：  ﾎﾞﾃﾞｨ部の関連ﾁｪｯｸ
    '   引数：　pm_intRow : チェック対象明細行
    '         　pm_all    : 画面情報
    '   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Body_RelChk(ByRef pm_intRow As Short, ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short, ByRef pm_ErrRow As Short) As Short

        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Trg_Index As Short
        Dim Err_Cd As String 'エラーコード
        Dim intHINCD As Short
        Dim intGNKCD As Short
        Dim intUODSU As Short
        Dim intUODTK As Short
        Dim intKBN As Short
        Dim intODNYTDT As Short
        Dim intBIKO1 As Short
        Dim intBIKO2 As Short
        Dim intTOKJDNNO As Short
        Dim bolCheck As Boolean
        Dim bolNotInput As Boolean
        Dim strKbn As String
        Dim strURIKJN As String
        Dim strODNYTDT As String
        Dim strSOUCD As String
        Dim strHINCD As String
        Dim curSU As Decimal
        Dim intRet As Short

        '2008/05/12 FKS)HONDA ADD START
        Dim strJDNDT As String
        Dim Mst_Inf As TYPE_DB_HINMTA
        Dim Dsp_Value As Object
        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSBNNO As String

        '2008/05/12 FKS)HONDA ADD END

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_ERR_ELSE
        Err_Cd = ""
        pm_ErrRow = pm_intRow
        pm_ErrIdx = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
        bolNotInput = False

        '１行チェック
        intHINCD = CShort(FR_SSSMAIN.BD_HINCD(0).Tag)
        intUODSU = CShort(FR_SSSMAIN.BD_UODSU(0).Tag)
        intBIKO1 = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
        intBIKO2 = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)

        bolCheck = False
        '１行に必要な情報が入力されている場合、OK
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))) <> "" Then
            '    And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUODSU))) <> "" Then

            '2008/05/12 FKS)HONDA ADD START
            If RunMode = RUNMODE_IDOET52 Then

                '' 型式をテストのためクリアする
                'pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = ""
                'Trg_Index = CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)
                'Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                'Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                'MsgBox "test"

                '明細の型式、名称、単位が消える場合があるのでマスタより再セット
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strHINCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))

                '画面.受注日取得
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strJDNDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag)))

                If DSPHINCD_SEARCH(strHINCD, Mst_Inf, strJDNDT) = 0 Then

                    With pm_All.Dsp_Body_Inf.Row_Inf(pm_intRow).Bus_Inf
                        .HINCD = Mst_Inf.HINCD '商品マスタ.製品コード
                        .HINNMA = Mst_Inf.HINNMA '商品マスタ.型式
                        .HINNMB = Mst_Inf.HINNMB '商品マスタ.商品名１
                        .UNTCD = Mst_Inf.UNTCD '商品マスタ.単位コード
                        .UNTNM = Mst_Inf.UNTNM '商品マスタ.単位名
                    End With
                    ' 型式
                    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    ' 品名
                    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    ' 単位
                    Trg_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                Else
                    '該当データなし
                End If
            Else
                '訂正の場合SBNTRAより再取得
                '' 型式をテストのためクリアする
                'pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = ""
                'Trg_Index = CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)
                'Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                'Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                'MsgBox "test"

                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSBNNO = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_SBNNO.Tag)))

                strSQL = ""
                strSQL = strSQL & " select SBNTRA.* "
                strSQL = strSQL & "   from SBNTRA, "
                strSQL = strSQL & "        (select MAX(DATNO) DATNO "
                strSQL = strSQL & "         from SBNTRA "
                strSQL = strSQL & "         where SBNTRA.SBNNO = '" & strSBNNO & "' ) SBNWK "
                strSQL = strSQL & "   where SBNTRA.DATNO = SBNWK.DATNO  "
                strSQL = strSQL & "   And   SBNTRA.DATKB = '" & gc_strDATKB_USE & "' "
                'DBアクセス
                '2019/06/24 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                'If CF_Ora_EOF(Usr_Ody) = True Then
                '    '取得データなし

                'End If
                Dim dt As DataTable = DB_GetTable(strSQL)
                '2019/06/24 CHG END
                '2019/06/24 CHG START
                'If CF_Ora_EOF(Usr_Ody) = False Then

                '    ' 型式
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")
                '    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
                '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                '    ' 品名
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")
                '    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
                '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                '    ' 単位
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")
                '    Trg_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
                '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                '    ' 単位コード。画面には表示されないが、SBNTRAには保存されているもの。再保存に備えて記憶しておく (F_SBNTRA_Insert() 参照)
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")
                'End If
                If dt.Rows.Count > 0 Then

                    ' 型式
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "")
                    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    ' 品名
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "")
                    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                    ' 単位
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "")
                    Trg_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
                    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    ' 単位コード。画面には表示されないが、SBNTRAには保存されているもの。再保存に備えて記憶しておく (F_SBNTRA_Insert() 参照)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "")
                End If
                '2019/06/24 CHG END
                'クローズ
                Call CF_Ora_CloseDyn(Usr_Ody)

            End If
            '2008/05/12 FKS)HONDA ADD END


            bolCheck = True
            bolMEISAI_INPUT = True
            intMeisaiCnt = intMeisaiCnt + 1
        Else
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Select Case True
                Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))) = "" '_
                    'And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUODSU))) <> ""
                    pm_ErrIdx = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
                Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))) <> "" '_
                    'And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUODSU))) = ""
                    pm_ErrIdx = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
            End Select
        End If

        '１行全部未入力の場合OK
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBIKO1))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBIKO2))) = "" Then
            '    And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUODSU))) = "" _
            ''        'かつ「入力済み状態」"でない"場合
            '        If pm_All.Dsp_Body_Inf.Row_Inf(pm_intRow).Status <> BODY_ROW_STATE_INPUT Then
            '            bolCheck = True
            '            bolNotInput = True
            '        End If
            bolCheck = True
            bolNotInput = True
        End If

        If bolCheck = False Then
            Err_Cd = gc_strMsgIDOET52_E_013
            GoTo F_Ctl_Body_RelChk_END
        End If

        '未入力の場合、後のチェックは無し
        If bolNotInput = True Then
            bolInput_Bef_Row = False
            ' 未入力行が複数行ある場合の対応
            If intInput_Bef_RowNo = 0 Then
                intInput_Bef_RowNo = pm_intRow
            End If
            Rtn_Chk = CHK_OK
            GoTo F_Ctl_Body_RelChk_END
        Else
            '未入力以外で前の行が未入力の場合エラー
            If bolInput_Bef_Row = False Then
                Err_Cd = gc_strMsgIDOET52_E_013
                pm_ErrRow = intInput_Bef_RowNo
                GoTo F_Ctl_Body_RelChk_END
            End If
        End If

        ' 有効在庫数チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSOUCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_SOUCD.Tag)))
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strHINCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHINCD))
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        curSU = CDec(Val(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Val(CStr(intUODSU))))))
        'CHG START FKS)INABA 2006/11/30 ***************************************************************
        intRet = F_Chk_Relzaisu(strSOUCD, strHINCD, curSU, pm_All)
        'DEL START FKS)INABA 2008/07/29 ************************************************************
        '    Select Case intRet
        '        Case 1  '在庫管理しない製品コード
        '            Err_Cd = gc_strMsgIDOET52_E_064
        '            GoTo F_Ctl_Body_RelChk_END
        '        Case 2  'HINMTAに無い
        '            Err_Cd = gc_strMsgIDOET52_E_081
        '            GoTo F_Ctl_Body_RelChk_END
        ''ADD START FKS)INABA 2007/01/08 ********************************************************************
        '    '有効在庫数チェック仕様変更（ワーニングを表示する）
        '        Case 3  '現在庫数＜出庫数
        ''CHG START FKS)INABA 2007/12/14 ********************************************
        '            If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
        '                Err_Cd = gc_strMsgIDOET52_E_016
        '                GoTo F_Ctl_Body_RelChk_END
        '            Else
        '                Err_Cd = gc_strMsgIDOET52_W_095
        '            End If
        ''            Err_Cd = gc_strMsgIDOET52_W_095
        ''CHG  END  FKS)INABA 2007/12/14 ********************************************
        '        Case 4  '現在庫数－引当済数＜出庫数
        ''CHG START FKS)INABA 2007/12/14 ********************************************
        '            If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
        '                Err_Cd = gc_strMsgIDOET52_E_017
        '                GoTo F_Ctl_Body_RelChk_END
        '            Else
        '                Err_Cd = gc_strMsgIDOET52_W_096
        '            End If
        ''            Err_Cd = gc_strMsgIDOET52_W_096
        ''CHG  END  FKS)INABA 2007/12/14 ********************************************
        '        Case 5  '現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
        '            Err_Cd = gc_strMsgIDOET52_W_097
        '
        ''ADD  END  FKS)INABA 2007/01/08 ********************************************************************
        '        Case 0  '正常終了
        '    End Select
        'DEL  END  FKS)INABA 2008/07/29 ************************************************************

        '    intRet = F_Chk_Relzaisu(strSOUCD, strHINCD, curSU)
        '    If intRet = 1 Or intRet = 2 Then
        ''        pm_ErrRow = intInput_Bef_RowNo
        '        Err_Cd = gc_strMsgIDOET52_E_063
        '        GoTo F_Ctl_Body_RelChk_END
        '    End If
        'CHG  END  FKS)INABA 2006/11/30 ***************************************************************

        strURIKJN = ""
        Rtn_Chk = CHK_OK

F_Ctl_Body_RelChk_END:

        If Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Ctl_Body_RelChk = Rtn_Chk
        Exit Function

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Tail_Chk
    '   概要：  ﾃｲﾙ部のﾁｪｯｸﾙｰﾁﾝ制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Tail_Chk(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim intMoveFocus As Short

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK

        '最終項目まで各項目のﾁｪｯｸを行う
        For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt

            '各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
            Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)

            'チェックＮＧ
            If Rtn_Chk <> CHK_OK Then

                '未入力メッセージ
                If Rtn_Chk = CHK_ERR_NOT_INPUT Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_013, pm_All)
                End If

                'ﾁｪｯｸ後移動なし
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

                F_Ctl_Tail_Chk = Rtn_Chk
                Exit Function
            End If
        Next

        '関連ﾁｪｯｸ
        Rtn_Chk = F_Ctl_Tail_RelChk(pm_All, intMoveFocus)
        'チェックＮＧ
        If Rtn_Chk <> CHK_OK Then

            ' 与信チェック後フォーカス位置統一
            If intMoveFocus <> -1 Then
                'ﾁｪｯｸ後移動なし
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
            End If

            F_Ctl_Tail_Chk = Rtn_Chk
            Exit Function
        End If

        F_Ctl_Tail_Chk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Tail_RelChk
    '   概要：  ﾃｲﾙ部の関連ﾁｪｯｸ
    '   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象（ゼロ:案件IDへ移動）
    '   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Tail_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short

        Dim Index_Wk As Short
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Trg_Index As Short
        Dim Err_Cd As String 'エラーコード
        Dim intRet As Short
        Dim strJDNTRKB As String '受注取引区分
        Dim strMAEUKKB As String '前受区分
        Dim strSEIKB As String '請求区分
        Dim strAKNID As String '案件ID
        Dim Mst_Inf As TYPE_DB_YSNTRA
        Dim Mst_Inf_AknId As TYPE_DB_ANKNVIEW
        Dim curHIKSU As Decimal
        Dim strNHSCD As String
        Dim strNHSNM As String

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_ERR_ELSE
        Err_Cd = ""
        'D    pm_ErrIdx = CInt(FR_SSSMAIN.HD_AKNID.Tag)
        pm_ErrIdx = -1

        If IDOET52_SBNTRA_Inf.OUTRYKB1 = "1" Then ' 代替出荷
            If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
                Err_Cd = gc_strMsgIDOET52_E_065
                GoTo F_Ctl_Tail_RelChk_END
            End If
        End If

        ''H.Y.(9/22)    '納入先コード取得
        ''    Trg_Index = CInt(FR_SSSMAIN.HD_NHSCD.Tag)
        ''    strNHSCD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
        ''
        ''    '納入先名取得
        ''    Trg_Index = CInt(FR_SSSMAIN.HD_NHSCD.Tag)
        ''    strNHSNM = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSNMA.Tag)))) & _
        '''               Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSNMB.Tag))))
        ''
        ''    If strNHSNM <> "" And strNHSCD = "" Then
        ''        Err_Cd = gc_strMsgIDOET52_E_046
        ''        pm_ErrIdx = CInt(FR_SSSMAIN.HD_NHSCD.Tag)
        ''        GoTo F_Ctl_Tail_RelChk_END
        ''H.Y.(9/22)    End If

        ''H.Y.(9/22)    '案件ID取得
        ''    pv_bolAKN_FLG = False
        ''    Trg_Index = CInt(FR_SSSMAIN.HD_AKNID.Tag)
        ''    strAKNID = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
        ''    If IsNumeric(strAKNID) = True Then
        ''        strAKNID = Trim(CStr(Format(CLng(strAKNID), String(8, "0"))))
        ''H.Y.(9/22)    End If

        ''H.Y.(9/22)    '受注取込チェック
        ''    If Trim(strAKNID) <> "" Or strAKNID <> String(8, "0") Then
        ''        '案件情報検索
        ''        If DSPANID_SEARCH(strAKNID, Mst_Inf_AknId) = 0 Then
        ''            If Trim(Mst_Inf_AknId.JDNNO) <> "" Then
        ''                If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_041, pm_All) = vbCancel Then
        ''                    pm_ErrIdx = CInt(FR_SSSMAIN.HD_AKNID.Tag)
        ''                    Rtn_Chk = CHK_ERR_ELSE
        ''                    GoTo F_Ctl_Tail_RelChk_END
        ''                End If
        ''            Else
        ''                If F_Get_JDNTHA_AKNID(Format(strAKNID, String(8, "0")), pm_All) = 0 Then
        ''                    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_041, pm_All) = vbCancel Then
        ''                        pm_ErrIdx = CInt(FR_SSSMAIN.HD_AKNID.Tag)
        ''                        Rtn_Chk = CHK_ERR_ELSE
        ''                        GoTo F_Ctl_Tail_RelChk_END
        ''                    End If
        ''                End If
        ''            End If
        ''            pv_bolAKN_FLG = True
        ''        End If
        ''H.Y.(9/22)    End If

        Rtn_Chk = CHK_OK

F_Ctl_Tail_RelChk_END:

        If Trim(Err_Cd) <> "" Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
        End If

        F_Ctl_Tail_RelChk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Foot_In_Ready
    '   概要：  フッタ部の入力準備
    '   引数：　なし
    '   戻値：　なし
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short

        'フッタ部内で処理
        For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
            Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
                Case FR_SSSMAIN.HD_NHSCD.Name
                    '初期状態で入力可能なｺﾝﾄﾛｰﾙ
                    '入力可能
                    Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))

            End Select
        Next

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_REF_JDNNO
    '   概要：  対象項目の受注情報検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  見積情報検索を受注情報検索に変更 (H.Y.)
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_REF_JDNNO(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_JDNNO.Tag)
        Next_Focus = Trg_Index ' 製番へ

        'ﾌｫｰｶｽを見積番号へ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            ''H.Y.(9/21)        WLSMIT_KKTFL = "1"

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '受注検索画面を呼び出す
            WLS_JDN2.ShowDialog()
            WLS_JDN2.Close()
            ''        WLS_UODET63.Show vbModal
            ''        Unload WLS_UODET63
            '''        WLSJDN.Show vbModal
            '''        Unload WLSJDN

            gv_bolUODET51_LF_Enable = True

            ''        If WLSJDN_RTNJDNNO <> "" Then
            If WLSJDN_RTNJDNNO <> "" Then
                '検索ＯＫ
                '画面に編集
                '見積番号
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSJDN_RTNJDNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                ''H.Y.(9/20)S            '参照見積番号
                ''            Trg_Index = CInt(FR_SSSMAIN.HD_MITNOV.Tag)
                ''            Dsp_Value = CF_Cnv_Dsp_Item(WLSMIT_RTNMITNOV, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                ''            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                ''
                ''            '見積版数のチェックを行うため、クリア
                ''H.Y.(9/20)E            pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_MITNOV.Tag)).Detail.Bef_Chk_Value = ""

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    ' === 20060731 === UPDATE S - ACE)Nagasawa
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
            ' 検索画面表示ボタンを押したことが見えるようにする対応
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_REF_SBN
    '   概要：  出庫訂正対象検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  出庫訂正対象検索WLS_IDO1ウインドウは製番出庫ファイルの伝票管理番号を取得するが、
    '           このフォーム上にはそれ表示のためのテキストボックスは無い
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_REF_SBN(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        Dim intRet As Short
        Dim strMsg As String
        Dim strHeadMsg As String
        Dim Rtn_Cd As Object
        Dim Retn_Code As Short
        Dim Err_Cd As Object
        Dim Msg_Flg As Boolean
        Dim pm_Chk_Move As Boolean
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************
        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_DENDT.Tag)
        Next_Focus = Trg_Index '出庫日へ

        'ﾌｫｰｶｽを見積番号へ移動
        'If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
        '        '現在のActiveコントロールの選択状態解除
        '        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
        '        'ﾌｫｰｶｽ移動
        '        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '        '選択状態の設定（初期選択）
        '        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
        '        '項目色設定
        '        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
        '
        gv_bolUODET51_LF_Enable = False

        'Windowsに処理を返す
        System.Windows.Forms.Application.DoEvents()

        '製番出庫伝票検索画面を呼び出す
        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLS_IDO1_SYSDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag))))
        WLS_IDO1.ShowDialog()
        WLS_IDO1.Close()

        gv_bolUODET51_LF_Enable = True
        If WLS_IDO1_DATNO <> "" Then
            '検索ＯＫ
            intRet = F_DSPSBNTRA_SEARCH(WLS_IDO1_DATNO, pm_All)
            If intRet <> 0 Then
                Exit Function
            End If
            '2008/05/13 FKS)HONDA ADD START
            gv_strSBNFlg = "ON"
            '2008/05/13 FKS)HONDA ADD END

            'チェック
            '各項目のﾁｪｯｸﾙｰﾁﾝ
            'SBNTRAに保存はされないが、マスタから補足情報を取得する必要がある。
            '出庫理由（出庫理由名、出庫理由区分１／２／３　を取得する）
            Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
            Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

            '2008/05/13 FKS)HONDA ADD START
            gv_strSBNFlg = ""
            '2008/05/13 FKS)HONDA ADD END


            If Rtn_Chk = CHK_OK Then

                'チェックＯＫ時
                '取得内容表示
                Dsp_Mode = DSP_SET
            Else
                'チェックＮＧ時
                '取得内容クリア
                Dsp_Mode = DSP_CLR
            End If
            '取得内容表示/クリア
            Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

            ''ADD START FKS)INABA 2007/01/04 *************************************************************
            '                '【納入先名】
            '                '名称ﾏﾆｭｱﾙ入力区分='1'の場合、納入先名は変更可
            '                Dim Focus_Ctl As Boolean
            '                Dim Mst_Inf             As TYPE_DB_NHSMTA
            '
            '                If DSPNHSCD_SEARCH(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_NHSCD.Tag).Detail.Dsp_Value, Mst_Inf) = 0 Then
            '                End If
            '                If Mst_Inf.NHSNMMKB = gc_strNMMKB_OK Then
            '                    Focus_Ctl = True
            '                Else
            '                    Focus_Ctl = False
            '                End If
            '
            '                Trg_Index = CInt(FR_SSSMAIN.HD_NHSNMA.Tag)
            '                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
            '                If Focus_Ctl = True Then
            '                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
            '                Else
            '                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
            '                End If
            '               'コントロールの前景/背景色
            '                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
            '
            '                Trg_Index = CInt(FR_SSSMAIN.HD_NHSNMB.Tag)
            '                Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
            '                If Focus_Ctl = True Then
            '                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = False
            '                Else
            '                    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Locked = True
            '                End If
            '                'コントロールの前景/背景色
            '                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
        End If
        ' 検索画面表示ボタンを押したことが見えるようにする対応
        '    Else
        '        'ﾁｪｯｸ後移動なし
        '        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
        '        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        '        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        '    End If

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_DT
    '   概要：  対象項目のカレンダ検索ﾎﾞﾀﾝの制御
    '   引数：  pm_Mode : 呼出元項目判定用コード
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_DT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Mode As String) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************
        '割当ｲﾝﾃﾞｯｸｽ取得
        Select Case pm_Mode
            Case CS_JDNDT_W '受注日検索
                Trg_Index = CShort(FR_SSSMAIN.HD_DENDT.Tag)
            Case Else
                Exit Function
        End Select

        Next_Focus = Trg_Index + 1

        'ﾌｫｰｶｽを各項目へ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            ' === 20060831 === INSERT S - ACE)Nagasawa カレンダの初期表示の修正
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Set_date.Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(Trg_Index)))
            ' === 20060831 === INSERT E -

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            'カレンダ検索画面を呼び出す
            WLS_DATE.ShowDialog()
            WLS_DATE.Close()

            gv_bolUODET51_LF_Enable = True

            If WLSDATE_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    ' === 20060731 === UPDATE S - ACE)Nagasawa
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                    ' === 20060731 === UPDATE E -
                End If
            End If
            ' === 20060731 === INSERT S - ACE)Nagasawa  検索画面表示ボタンを押したことが見えるようにする対応
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
            ' === 20060731 === INSERT E -
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_CODE
    '   概要：  対象項目の名称マスタ検索ﾎﾞﾀﾝの制御
    '   引数：  pm_Mode : 呼出元項目判定用コード
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_CODE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Mode As String) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************
        '割当ｲﾝﾃﾞｯｸｽ取得
        Select Case pm_Mode
            Case CS_OUTRY_W '出庫理由検索 (H.Y. 9/21)
                Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag) ' 出庫理由コード欄
                WLSMEI_KEYCD = "066" ' AE_CONSTで定義されている定数を指定すること(H.Y. 9/24)
                'ADD START FKS)INABA 2006/11/16 **************************************************************
            Case CS_BINCD_W '便コード検索
                Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag) ' 便コード
                WLSMEI_KEYCD = "002"
                'ADD  END  FKS)INABA 2006/11/16 **************************************************************
            Case Else
                WLSMEI_KEYCD = ""
                Exit Function
        End Select

        Next_Focus = Trg_Index + 1

        'ﾌｫｰｶｽを各項目へ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '名称マスタ検索画面を呼び出す
            WLS_MEI.ShowDialog()
            WLS_MEI.Close()

            gv_bolUODET51_LF_Enable = True

            If WLSMEI_RTNMEICDA <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSMEI_RTNMEICDA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    ' === 20060731 === UPDATE S - ACE)Nagasawa
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
            ' 検索Wボタン対応
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_TOKCD
    '   概要：  対象項目の得意先検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_TOKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
        '    Next_Focus = Trg_Index + 1
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを得意先コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '得意先検索画面を呼び出す
            WLSTOK_SKCHKB = gc_strSKCHKB_NML
            '2019/06/20 CHG START
            'WLSTOK.ShowDialog()
            'WLSTOK.Close()
            WLSTOK1.ShowDialog()
            WLSTOK1.Close()
            '2019/06/20 CHG END

            gv_bolUODET51_LF_Enable = True

            If WLSTOK_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSTOK_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If

            End If
            ' 検索画面表示ボタンを押したことが見えるようにする対応
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_TANCD
    '   概要：  対象項目の担当者検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_TANCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_TANCD.Tag)
        Next_Focus = Trg_Index + 1

        'ﾌｫｰｶｽを営業担当者コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            ' 部門の適用日の考慮対応
            '基準日として受注日を渡す
            'H.Y.(9/20) WLSTAN_TANTKDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag))))
            '基準日としてシステム日付を渡す H.Y.(9/20)
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WLSTAN_TANTKDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag))))

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '担当者検索画面を呼び出す
            '2019/06/20 CHG START
            'WLSTAN.ShowDialog()
            'WLSTAN.Close()
            WLSTAN1.ShowDialog()
            WLSTAN1.Close()
            '2019/06/20 CHG END

            gv_bolUODET51_LF_Enable = True

            If WLSTAN_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSTAN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
            ' 検索画面表示ボタンを押したことが見えるようにする対応
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_BUMCD
    '   概要：  対象項目の部門検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_BUMCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
        Next_Focus = Trg_Index + 1

        'ﾌｫｰｶｽを営業部門コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            ' 部門の適用日の考慮対応
            '受注日を基準日とする
            ''H.Y.(9/20) WLSBMN_KJNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag))))
            'システム日付を基準日とする
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WLSBMN_KJNDT = CF_Ora_Date(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.SYSDT.Tag))))

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '部門検索画面を呼び出す
            WLSBMN.ShowDialog()
            WLSBMN.Close()

            gv_bolUODET51_LF_Enable = True

            If WLSBMN_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSBMN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_SOUCD
    '   概要：  対象項目の倉庫検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_SOUCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************
        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを営業部門コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '倉庫検索画面を呼び出す
            WLSSOU.ShowDialog()
            WLSSOU.Close()

            gv_bolUODET51_LF_Enable = True

            If WLSSOU_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSSOU_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    ' === 20060731 === UPDATE S - ACE)Nagasawa
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_HINCD
    '   概要：  対象項目の製品検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_HINCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Wk_Index As Short
        Dim Trg_Index As Short
        Dim Focus_Flg As Boolean

        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************
        '製品コード割当ｲﾝﾃﾞｯｸｽ取得
        Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(0).Tag)

        'ﾌｫｰｶｽ移動先を検索
        Focus_Flg = False
        Trg_Index = 0
        If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
            '明細領域
            '対象行の製品コードへ移動
            Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
        Else
            '明細以外領域
            ' ボディ以外⇒ボディ部ボタン押下の場合（検索Wボタン対応）
            '        If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Then
            If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
                'ヘッタ部の場合
                'ﾍｯﾀﾞ部ﾁｪｯｸ
                Rtn_Chk = F_Ctl_Head_Chk(pm_All)
                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫの場合
                    '明細の１行目に移動
                    Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
                End If
            End If
        End If

        Next_Focus = Trg_Index

        If Trg_Index > 0 Then
            'ﾌｫｰｶｽを製品コードへ移動
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
                '現在のActiveコントロールの選択状態解除
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
                'ﾌｫｰｶｽ移動
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                '選択状態の設定（初期選択）
                Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
                '項目色設定
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                'ﾌｫｰｶｽ移動
                Focus_Flg = True
            End If
        End If

        If Focus_Flg = True Then
            '製品検索画面を呼び出す

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '製品検索画面を呼び出す
            WLSHIN.ShowDialog()
            WLSHIN.Close()

            gv_bolUODET51_LF_Enable = True

            If WLSHIN_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSHIN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)

                'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
                Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                '明細入力後の後処理
                Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                '復元内容、前回内容を退避
                Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                ' === 20060731 === UPDATE S - ACE)Nagasawa 検索画面表示ボタンを押したことが見えるようにする対応
                '            If Chk_Move_Flg = True Then
                '                'ﾁｪｯｸ後移動あり
                '                Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                '            Else
                '                'ﾁｪｯｸ後移動なし
                '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
                '            End If

                '対象行の次項目へ移動（wk_indexは該当のテキスト配列ゼロを指定しておく）
                Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    'ﾁｪｯｸ後移動なし
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
                    '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_UODSU
    '   概要：  対象項目の製品検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_UODSU(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Wk_Index As Short
        Dim Trg_Index As Short
        Dim Focus_Flg As Boolean

        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short

        Dim LS_CLTID As String
        Dim LS_PGID As String
        Dim ls_SBNNO As New VB6.FixedLengthString(20)
        Dim LS_HINCD As New VB6.FixedLengthString(10)
        Dim LL_URISU As Integer
        Dim LL_KKOUT As Integer
        Dim rtn As Short
        Dim Err_Cd As String
        Dim Full_Nm As String
        Dim Mst_Inf As TYPE_DB_HINMTA
        Dim strJDNDT As String '
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If

        LS_CLTID = SSS_CLTID.Value
        LS_PGID = SSS_PrgId
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ls_SBNNO.Value = Trim(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20))
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        LS_HINCD.Value = CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 10)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        LL_URISU = CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        'change 20190828 start hou
        'LL_KKOUT = pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.TL_KKOUT.Tag)).Detail.Dsp_Value
        LL_KKOUT = IDOET52_SBNTRA_Inf.KKOUT
        'change 20190828 end hou


        '緊急出庫チェックボックスの入力チェック
        If LL_KKOUT <> 1 Then
            Err_Cd = gc_strMsgIDOET52_E_015
            'cancel 20190828 start hou
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            Wk_Index = CInt(FR_SSSMAIN.TL_KKOUT.Tag)
            Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            End If
            'cancel 20190828 end hou
            Exit Function
        End If
        '製番の入力チェック
        If Trim(ls_SBNNO.Value) = "" Then
            Err_Cd = gc_strMsgIDOET52_E_059
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            Wk_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
            Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then

            End If
            Exit Function
        End If
        '製品コードの入力チェック
        If Trim(LS_HINCD.Value) = "" Then
            Err_Cd = gc_strMsgIDOET52_E_010
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
            Wk_Index = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
            Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then

            End If
            Exit Function
        End If
        '数量の入力チェック
        If LL_URISU = 0 Then
            Err_Cd = gc_strMsgIDOET52_E_012
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            Wk_Index = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
            Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then

            End If
            Exit Function
        End If

        'シリアル登録画面を呼び出す
        'SRAET61の引数【/RPTCLTID:CLTID /PGID:IDOET52 /SBNNO:RA02HF /HINCD:LRBQ671 /URISU:100】
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '2019/06/20 DELL START
        'Link_Clr = LSet(Link_OUT)
        '2019/06/20 DELL END
        'CHG START FKS)INABA 2008/09/24 *********************************************************
        Full_Nm = SSS_INIDAT(2) & "EXE\" & "SRAET62" & " /RPTCLTID:" & LS_CLTID & " /RSTDT:" & GV_UNYDate & " /HINCD:" & Trim(LS_HINCD.Value) & " /SBNNO:" & Trim(ls_SBNNO.Value) & " /URISU:" & LL_URISU & " /DATNO:" & IDOET52_SBNTRA_Inf.DATNO
        'CHG  END  FKS)INABA 2008/09/24 *********************************************************
        rtn = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, Full_Nm)
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '2019/06/20 DELL START
        'Link_Clr = LSet(Link_IN)
        '2019/06/20 DELL END

        Wk_Index = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
        Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then

        End If


    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_CS_NHSCD
    '   概要：  対象項目の納入先検索ﾎﾞﾀﾝの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_CS_NHSCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Dsp_Mode As Short
        Dim Chk_Move_Flg As Boolean
        Dim Next_Focus As Short
        'ADD START FKS)INABA 2006/11/21 ******************
        If FR_SSSMAIN.ActiveControl Is Nothing Then
            Exit Function
        End If
        'ADD  END  FKS)INABA 2006/11/21 ******************

        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
        '    Next_Focus = Trg_Index + 1
        Next_Focus = Trg_Index

        'ﾌｫｰｶｽを納入先コードへ移動
        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
            '現在のActiveコントロールの選択状態解除
            'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
            'ﾌｫｰｶｽ移動
            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
            '項目色設定
            Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            gv_bolUODET51_LF_Enable = False

            'Windowsに処理を返す
            System.Windows.Forms.Application.DoEvents()

            '納入先検索画面を呼び出す
            '2019/06/20 CHG START
            'WLSNHS.ShowDialog()
            'WLSNHS.Close()
            WLSNHS1.ShowDialog()
            WLSNHS1.Close()
            '2019/06/20 CHG END

            gv_bolUODET51_LF_Enable = True

            If WLSNHSMTA_RTNCODE <> "" Then
                '検索ＯＫ
                '画面に編集
                'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Dsp_Value = CF_Cnv_Dsp_Item(WLSNHSMTA_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

                'チェック
                '各項目のﾁｪｯｸﾙｰﾁﾝ
                Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)

                If Rtn_Chk = CHK_OK Then
                    'チェックＯＫ時
                    '取得内容表示
                    Dsp_Mode = DSP_SET
                Else
                    'チェックＮＧ時
                    '取得内容クリア
                    Dsp_Mode = DSP_CLR
                End If
                '取得内容表示/クリア
                Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)

                If Chk_Move_Flg = True Then
                    'ﾁｪｯｸ後移動あり
                    Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
                Else
                    ' === 20060731 === UPDATE S - ACE)Nagasawa
                    '                'ﾁｪｯｸ後移動なし
                    '                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                    '                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
                    '                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)

                    'ﾌｫｰｶｽ移動
                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                    '項目色設定
                    Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

                End If
            End If
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_TL_KKOUT
    '   概要：  緊急出庫チェックボックスの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_TL_KKOUT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/21 CHG START
        'If pm_Dsp_Sub_Inf.Ctl.Value = 1 Then
        If DirectCast(pm_Dsp_Sub_Inf.Ctl, CheckBox).Checked = True Then
            '2019/06/21 CHG END
            IDOET52_SBNTRA_Inf.KKOUT = 1
        Else
            IDOET52_SBNTRA_Inf.KKOUT = 0
        End If
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Upd_Process
    '   概要：  更新メインルーチン
    '   引数：　なし
    '   戻値：　0 :更新終了　9:更新なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short

        Dim intRet As Short
        Dim strJdnNo As String


        F_Ctl_Upd_Process = 9

        ' 権限の考慮の追加

        ' エンターキー連打による不具合修正２
        If gv_bolUpdFlg = True Then
            Exit Function
        End If

        gv_bolUpdFlg = True

        '砂時計にする
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '動作モードのチェック
        intRet = F_Ctl_RunMode_Chk(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)
        'DEL START FKS)INABA 2008/07/29 **********************
        '    'ヘッダ部のチェック
        '    intRet = F_Ctl_Head_Chk(pm_All)
        '    If intRet <> CHK_OK Then
        '        'チェックＮＧの場合
        '        GoTo End_F_Ctl_Upd_Process
        '    End If
        '
        '    'ボディ部のチェック
        '    intRet = F_Ctl_Body_Chk(pm_All)
        '    If intRet <> CHK_OK Then
        '    'チェックＮＧの場合
        '        GoTo End_F_Ctl_Upd_Process
        '    End If
        '
        '    'テイル部のチェック
        '    intRet = F_Ctl_Tail_Chk(pm_All)
        '    If intRet <> CHK_OK Then
        '    'チェックＮＧの場合
        '        GoTo End_F_Ctl_Upd_Process
        '    End If
        'DEL  END  FKS)INABA 2008/07/29 **********************
        Dim lw_su As Short
        Dim lwUODSU As Short
        Dim strHINCD As String
        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        If IDOET52_SBNTRA_Inf.KKOUT = 0 Then

            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strHINCD = CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 10)
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            lwUODSU = CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value) * (-1)
            strSQL = " SELECT RELZAISU ZAISU"
            strSQL = strSQL & "  FROM HINMTB "
            strSQL = strSQL & " WHERE SOUCD = '910' "
            strSQL = strSQL & "   AND HINCD = '" & Trim(strHINCD) & "'"
            strSQL = strSQL & "   AND DATKB = '1' "
            '2019/06/24 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            'Debug.Print(strSQL)
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    lw_su = CF_Ora_GetDyn(Usr_Ody, "ZAISU", 0)
            'Else
            '    lw_su = 0
            'End If
            Dim dt As DataTable = DB_GetTable(strSQL)
            Debug.Print(strSQL)
            If dt.Rows.Count > 0 Then
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                lw_su = DB_NullReplace(dt.Rows(0)("ZAISU"), 0)
            Else
                lw_su = 0
            End If
            '2019/06/24 CHG END
            If lwUODSU > lw_su Then
                MsgBox("返品在庫に存在しません。")
                GoTo End_F_Ctl_Upd_Process
            End If
        End If
        'マウスポインタを戻す
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'Windowsに処理を返す
        System.Windows.Forms.Application.DoEvents()

        '確認メッセージ表示
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_A_037, pm_All)

        Select Case intRet
            Case MsgBoxResult.Yes
                If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET51_E_066, pm_All)
                    GoTo End_F_Ctl_Upd_Process
                End If
                'ボタン非表示
                FR_SSSMAIN.CM_Execute.Visible = False

                '登録処理
                intRet = F_Update_Main(strJdnNo, pm_All)
                If intRet <> 0 Then
                    GoTo Err_F_Ctl_Upd_Process
                End If
                '画面内容初期化
                Call SSSMAIN0001.F_Init_Clr_Dsp(-1, pm_All)

                '            F_Reset_IDOET52_TYPE_SBNTRA_All IDOET52_SBNTRA_Inf
                'ADD START FKS)INABA 2005/12/03 ************************************
                FR_SSSMAIN.HD_OPT1.Checked = False
                FR_SSSMAIN.HD_OPT2.Checked = False
                FR_SSSMAIN.HD_OPT2.Checked = False
                'ADD  END FKS)INABA 2005/12/03 ************************************

                ''H.Y.(9/24)            '受注番号表示画面
                ''            gv_strDLGMSG01_BNGNM = "受注番号"
                ''            gv_strDLGMSG01_NO = strJdnNo
                ''H.Y.(9/24)            DLGMSG01_ACE.Show vbModal

            Case Else ' 戻る
                GoTo End_F_Ctl_Upd_Process
        End Select

        F_Ctl_Upd_Process = 0

End_F_Ctl_Upd_Process:
        'マウスポインタを戻す
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'ボタン表示
        'change 20190829 start hou
        'FR_SSSMAIN.CM_Execute.Visible = True
        FR_SSSMAIN.CM_Execute.Visible = False
        'change 20190829 end hou

        ' エンターキー連打による不具合修正２
        gv_bolUpdFlg = False

        'キーフラグを元に戻す
        gv_bolKeyFlg = False

        Exit Function

Err_F_Ctl_Upd_Process:
        GoTo End_F_Ctl_Upd_Process

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Update_Main
    '   概要：  更新メイン処理
    '   引数：  pot_strJdnNo  : 受注番号
    '           pm_All        : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Update_Main(ByRef pot_strJdnNo As String, ByRef pm_All As Cls_All) As Short

        Dim bolRet As Boolean
        Dim intRet As Short
        Dim strDATNO() As String '伝票管理№
        Dim strRECNO() As String 'レコード管理№
        Dim strPUDLNO() As String '入出庫番号
        Dim strFDNNO() As String '納品書番号
        Dim strJdnNo As String '受注番号
        Dim intMaxMeisai As Short '入力明細最大行
        Dim intCnt As Short
        Dim bolTran As Boolean
        Dim strJDNTRKB As String '受注取引区分
        Dim bolAKNID As Boolean '案件ID入力フラグ(True:入力　False:未入力)
        Dim bolMitNo As Boolean '参照見積番号入力フラグ
        Dim bolNoki As Boolean '納期回答フラグ
        Dim intRet2 As Short

        '2006/10/11 [ADD-START]
        Dim FILE1_PATH As String
        Dim lngFileNo1 As Integer
        '2006/10/11 [ADD-END]
        'ADD START FKS)INABA 2009/07/02 **********************
        '連絡票№739
        Dim GV_UNYDate_BK As String
        'ADD  END  FKS)INABA 2009/07/02 **********************


        On Error GoTo F_Update_Main_err

        '砂時計にする
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        F_Update_Main = 9
        bolTran = False

        '返り値初期化
        pot_strJdnNo = ""
        intMeisaiCnt = 1
        intMaxMeisai = intMeisaiCnt


        ReDim strDATNO(1)
        ReDim strRECNO(intMaxMeisai)
        ReDim strPUDLNO(intMaxMeisai)
        ReDim strFDNNO(intMaxMeisai)

        '更新時刻取得
        Call CF_Get_SysDt()
        'ADD START FKS)INABA 2009/07/02 **********************
        '連絡票№739
        GV_UNYDate_BK = GV_UNYDate
        'ADD  END  FKS)INABA 2009/07/02 **********************
        'DEL START FKS)INABA 2009/10/15 **********************
        '連絡票№739追加修正
        '    '運用日付再取得
        '    Call CF_Get_UnyDt
        'DEL  END  FKS)INABA 2009/10/15 **********************

        'ADD START FKS)INABA 2009/07/02 *******************************
        '連絡票№739
        Dim lw_ret As Short
        'UPGRADE_WARNING: オブジェクト CHK_UNYDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        lw_ret = CHK_UNYDT(GV_UNYDate_BK)
        If lw_ret = 1 Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, "2DATE_2", pm_All)
            GoTo F_Update_Main_err
        End If
        'ADD  END  FKS)INABA 2009/07/02 *******************************


        '伝票番号採番処理
        intRet = AE_SYSTBASaiban(strDATNO, strRECNO)
        If intRet <> 0 Then
            If intRet = 2 Then
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_036, pm_All)
            End If
            GoTo F_Update_Main_err
        End If

        strPUDLNO(1) = IDOET52_SBNTRA_Inf.PUDLNO

        'トランザクションの開始
        '2019/06/21 CHG START
        ' Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/06/21 CHG END
        bolTran = True

        '製番出庫ファイルの削除
        intRet = F_SBNTRA_Delete(IDOET52_SBNTRA_Inf.DATNO, pm_All)
        If intRet <> 0 Then
            GoTo F_Update_Main_err
        End If
        '出荷指示の更新、追加
        intRet = F_FDNTRA_Update(IDOET52_SBNTRA_Inf.DATNO, pm_All)
        If intRet <> 0 Then
            GoTo F_Update_Main_err
        End If
        intRet = F_FDNTRA_Insert(strDATNO(1), IDOET52_SBNTRA_Inf.DATNO, pm_All)
        If intRet <> 0 Then
            GoTo F_Update_Main_err
        End If

        ''倉庫別在庫マスタの更新(引当数)
        '    If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
        '        '倉庫別在庫マスタ更新
        '        intRet = F_HINMTB_Update(pm_All)
        '        If intRet <> 0 Then
        '            GoTo F_Update_Main_err
        '        End If
        '    End If

        '物流連携へのテキスト出力
        'INIファイル取得用関数
        Dim ll_su As Integer
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ll_su = CInt(Val(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value))
        If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
            '    If ll_su > 0 Then
            FILE1_PATH = GP_GetIni(My.Application.Info.DirectoryPath & "\" & "IDOET54.ini", "FILEPATH", "FILE1")
        Else
            FILE1_PATH = GP_GetIni(My.Application.Info.DirectoryPath & "\" & "IDOET54.ini", "FILEPATH", "FILE2")
        End If
        lngFileNo1 = FreeFile
        FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
        FileClose(lngFileNo1)

        'コミット
        '2019/06/21 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/06/21 CHG END
        bolTran = False
        '返り値設定
        F_Update_Main = 0


F_Update_Main_End:
        '砂時計を戻す
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Exit Function

F_Update_Main_err:
        If bolTran = True Then
            'ロールバック
            '2019/06/21 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/06/21 CHG END
        End If
        GoTo F_Update_Main_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_SBNTRA_Insert
    '   概要：  製番出庫トラン追加処理
    '   引数：  pin_strDatNo  : 伝票管理No
    '           pin_strPUDLNO  : 入出庫番号
    '           pm_All        : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_SBNTRA_Insert(ByVal pin_strDatNo As String, ByVal pin_strPUDLNO As String, ByRef pm_All As Cls_All) As Short

        Dim strSQL As String
        Dim bolRet As Boolean
        Dim intRet As Short
        Dim curSikKngk As Decimal '営業仕切金額
        Dim strBKTHKKB As String '分割不可区分
        Dim strJDNDT As String '受注予定日
        Dim strSMADT As String '経理締日
        Dim strJDNENDKB As String '受注完了区分
        Dim Mst_Inf_MEIMTA As TYPE_DB_MEIMTA
        Dim intHINCD_Col As Short
        Dim intUODSU_Col As Short
        Dim intBIKO1_Col As Short
        Dim intBIKO2_Col As Short

        On Error GoTo F_SBNTRA_Insert_err

        F_SBNTRA_Insert = 9

        '列番号取得
        intHINCD_Col = CShort(FR_SSSMAIN.BD_HINCD(0).Tag) - CShort(FR_SSSMAIN.BD_HINCD(0).Tag) + 1 '製品コードの列
        intUODSU_Col = CShort(FR_SSSMAIN.BD_UODSU(0).Tag) - CShort(FR_SSSMAIN.BD_HINCD(0).Tag) + 1 '数量の列
        intBIKO1_Col = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag) - CShort(FR_SSSMAIN.BD_HINCD(0).Tag) + 1 '明細備考1
        intBIKO2_Col = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag) - CShort(FR_SSSMAIN.BD_HINCD(0).Tag) + 1 '明細備考2

        strSQL = ""
        strSQL = strSQL & " Insert into SBNTRA "
        ' 1
        strSQL = strSQL & "        ( DATNO " '伝票管理№
        strSQL = strSQL & "        , DATKB " '伝票削除区分
        strSQL = strSQL & "        , OUTKB " '出庫区分
        strSQL = strSQL & "        , OUTYTDT " '出庫予定日
        strSQL = strSQL & "        , SBNNO " '製番
        ' 6
        strSQL = strSQL & "        , ORGSBNNO " '元製番
        strSQL = strSQL & "        , HINCD " '製品コード
        strSQL = strSQL & "        , FRDYTSU " '出荷指示予定数
        strSQL = strSQL & "        , FRDSU " '出荷指示数量
        strSQL = strSQL & "        , OUTSOUCD " '出庫元倉庫
        ' 11
        strSQL = strSQL & "        , NHSCD " '納入先コード
        strSQL = strSQL & "        , OUTBMCD " '出庫先部門
        strSQL = strSQL & "        , OUTBNNM " '出庫先名称
        strSQL = strSQL & "        , OUTENDKB " '出庫完了区分
        strSQL = strSQL & "        , HIKSMSU " '引き当て済み数
        ' 16
        strSQL = strSQL & "        , OUTSMSU " '出庫済み数
        strSQL = strSQL & "        , PUDLNO " '入出庫番号
        'DEL START FKS)INABA 2006/11/20 ***************************************************
        '    strSQL = strSQL & "        , OPEID "            '最終作業者コード
        '    strSQL = strSQL & "        , CLTID "            'クライアントID
        '    strSQL = strSQL & "        , WRTTM "            'タイムスタンプ（時間）
        '    ' 21
        '    strSQL = strSQL & "        , WRTDT "            'タイムスタンプ（日付）
        '    strSQL = strSQL & "        , WRTFSTTM "         'タイムスタンプ（登録時間）
        '    strSQL = strSQL & "        , WRTFSTDT "         'タイムスタンプ（登録日）
        'DEL  END  FKS)INABA 2006/11/20 ***************************************************
        strSQL = strSQL & "        , OUTRSNCD " '出庫理由コード
        strSQL = strSQL & "        , OUTSOUNM " '出庫倉庫名
        ' 26
        strSQL = strSQL & "        , OUTTANCD " '送り先担当者コード
        strSQL = strSQL & "        , OUTTANNM " '送り先担当者名称
        strSQL = strSQL & "        , TOKCD " '得意先コード
        strSQL = strSQL & "        , TOKRN " '得意先略名
        strSQL = strSQL & "        , NHSNMA " '納入先名称１
        ' 31
        strSQL = strSQL & "        , NHSNMB " '納入先名称２
        strSQL = strSQL & "        , NHSZP " '郵便番号
        strSQL = strSQL & "        , NHSADA " '住所１
        strSQL = strSQL & "        , NHSADB " '住所２
        strSQL = strSQL & "        , NHSADC " '住所３
        ' 36
        strSQL = strSQL & "        , NHSTL " '電話番号
        strSQL = strSQL & "        , NHSFX " 'FAX番号
        strSQL = strSQL & "        , HINNMA " '型式
        strSQL = strSQL & "        , HINNMB " '商品名１
        strSQL = strSQL & "        , UNTCD " '単位コード
        ' 41
        strSQL = strSQL & "        , UNTNM " '単位名
        strSQL = strSQL & "        , LINCMA " '明細備考１
        strSQL = strSQL & "        , LINCMB " '明細備考２
        strSQL = strSQL & "        , EMGODNKB " '緊急出荷区分
        strSQL = strSQL & "        , OKRJONO " '送り状no
        'ADD START FKS)INABA 2006/11/20 *********************************************
        strSQL = strSQL & "        , BINCD " '便コード
        strSQL = strSQL & "        , RELFL " '連携フラグ
        strSQL = strSQL & "        , FOPEID " '初回登録ユーザID
        strSQL = strSQL & "        , FCLTID " '初回登録クライアントID
        strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間)
        strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日付)
        strSQL = strSQL & "        , OPEID " 'ユーザID(訂正)
        strSQL = strSQL & "        , CLTID " 'クライアントID(訂正)
        strSQL = strSQL & "        , WRTTM " 'タイムスタンプ(訂正時間)
        strSQL = strSQL & "        , WRTDT " 'タイムスタンプ(訂正日付)
        strSQL = strSQL & "        , UOPEID " 'ユーザID(バッチ)
        strSQL = strSQL & "        , UCLTID " 'クライアントID(バッチ)
        strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ(時間)
        strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ(日付)
        strSQL = strSQL & "        , PGID  " '更新PG
        strSQL = strSQL & "        , DLFLG " '削除フラグ
        'ADD START FKS)INABA 2006/11/20 *********************************************

        strSQL = strSQL & "        ) "
        '' ここから Values
        strSQL = strSQL & " Values "
        ' 1
        strSQL = strSQL & "        (  '" & CF_Ora_String(pin_strDatNo, 10) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
        strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.OUTKB, 1) & "'"
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_Date(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag)).Detail.Dsp_Value) & "' "
        '    strSQL = strSQL & "        ,  '" & Trim$(CF_Ora_String(IDOET52_SBNTRA_Inf.SBNNO, 20)) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SBNNO.Tag).Detail.Dsp_Value, 20) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20)) = "" Then
            If Trim(CF_Ora_String(IDOET52_SBNTRA_Inf.SBNNO, 20)) <> "" Then
                strSQL = strSQL & "        ,  '" & Trim(CF_Ora_String(IDOET52_SBNTRA_Inf.SBNNO, 20)) & "' "
            Else
                MsgBox("製番に値が入っていません。管理者に連絡してください。")
                GoTo F_SBNTRA_Insert_err
            End If
        Else
            'CHG START FKS)INABA 2007/05/08 *******************************************************
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "        ,  '" & LTrim(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value, 20)) & "' "
            '        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_SBNNO.Tag).Detail.Dsp_Value, 20) & "' "
            'CHG  END  FKS)INABA 2007/05/08 *******************************************************
        End If
        ' 6
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_JDNNO.Tag)).Detail.Dsp_Value), 20) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 10) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,   " & CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,   " & IIf(IDOET52_SBNTRA_Inf.KKOUT = BKTHKKB_KINKYU, CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value), " 0")
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value, 3) & "' "
        ' 11
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSCD.Tag)).Detail.Dsp_Value, 10) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_BUMCD.Tag)).Detail.Dsp_Value, 6) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.BUMNM, 40) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String("0", 1) & "'"
        If RunMode = RUNMODE_IDOET52 Then
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "        ,   " & IIf(IDOET52_SBNTRA_Inf.KKOUT = BKTHKKB_KINKYU, CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value), " 0")
        Else
            If IDOET52_SBNTRA_Inf.KKOUT = BKTHKKB_KINKYU Then
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSQL = strSQL & "        ,   " & CF_Ora_Number(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UODSU(1).Tag)).Detail.Dsp_Value)
            Else
                strSQL = strSQL & "        ,   " & IDOET52_SBNTRA_Inf.HIKSMSU
            End If
        End If
        ' 16
        strSQL = strSQL & "        ,  " & IDOET52_SBNTRA_Inf.OUTSMSU ' 出庫済み数
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strPUDLNO, 10) & "'"
        'DEL START FKS)INABA 2006/11/20 ********************************************************
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID, 8) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID, 5) & "' "
        '    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
        '    ' 21
        '    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
        '    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
        '    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
        'DEL  END  FKS)INABA 2006/11/20 ********************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_OUTRYCD.Tag)).Detail.Dsp_Value, 2) & "' "

        'CHG START FKS)INABA 2006/11/29 ***********************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUNM.Tag)).Detail.Dsp_Value, 20) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.SOUNM, 20) & "' "
        'CHG  END  FKS)INABA 2006/11/29 ***********************************************************

        ' 26
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_TANCD.Tag)).Detail.Dsp_Value, 6) & "' "

        'CHG START FKS)INABA 2006/11/29 ***********************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_TANNM.Tag)).Detail.Dsp_Value, 40) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.TANNM, 40) & "' "
        'CHG  END  FKS)INABA 2006/11/29 ***********************************************************

        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_TOKCD.Tag)).Detail.Dsp_Value, 10) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.TOKRN, 40) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSNMA.Tag)).Detail.Dsp_Value, 40) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.NHSNMA, 60) & "' "
        ' 31
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSNMB.Tag)).Detail.Dsp_Value, 40) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(IDOET52_SBNTRA_Inf.NHSNMB, 60) & "' "
        'CHG START FKS)INABA 2006/12/26 ***********************************************************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSZIPCD.Tag)).Detail.Dsp_Value, 20) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String("", 20) & "' "
        'CHG  END  FKS)INABA 2006/12/26 ***********************************************************************************************

        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSADA.Tag)).Detail.Dsp_Value, 60) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSADB.Tag)).Detail.Dsp_Value, 60) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSADC.Tag)).Detail.Dsp_Value, 60) & "' "
        ' 36

        'CHG START FKS)INABA 2006/12/26 ***********************************************************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSTL.Tag)).Detail.Dsp_Value, 20) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NHSFAX.Tag)).Detail.Dsp_Value, 20) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String("", 20) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String("", 20) & "' "
        'CHG  END  FKS)INABA 2006/12/26 ***********************************************************************************************
        'CHG START FKS)INABA 2008/02/19 ***********************************************************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)).Detail.Dsp_Value, 50)) = "" Then
            MsgBox("型式の内部処理エラーです。管理者に連絡してください。")
            GoTo F_SBNTRA_Insert_err
        End If
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)).Detail.Dsp_Value, 50) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINNMB(1).Tag)).Detail.Dsp_Value, 50) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD, 2) & "' "
        ' 41
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_UNTNM(1).Tag)).Detail.Dsp_Value, 2) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, 50) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, 50) & "' "
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD, 2) & "' "
        '    ' 41
        '    strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, 4) & "' "
        'CHG  END  FKS)INABA 2008/02/19 ***********************************************************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_LINCMA(1).Tag)).Detail.Dsp_Value, 20) & "' "
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_LINCMB(1).Tag)).Detail.Dsp_Value, 20) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(IIf(IDOET52_SBNTRA_Inf.KKOUT = BKTHKKB_KINKYU, "1", "9"), 1) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String("", 15) & "' "
        'ADD START FKS)INABA 2006/11/20 ***************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "        ,  '" & CF_Ora_String(IIf(Trim(CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_BINCD.Tag)).Detail.Dsp_Value, 2)) = "", "99", CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_BINCD.Tag)).Detail.Dsp_Value, 2)), 2) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String("0", 1) & "' "
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザID
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントID
        strSQL = strSQL & "        ,  '" & GV_SysTime & "' " 'タイムスタンプ（登録時間)
        strSQL = strSQL & "        ,  '" & GV_SysDate & "' " 'タイムスタンプ（登録日付)
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(訂正)
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(訂正)
        strSQL = strSQL & "        ,  '" & GV_SysTime & "' " 'タイムスタンプ(訂正時間)
        strSQL = strSQL & "        ,  '" & GV_SysDate & "' " 'タイムスタンプ(訂正日付)
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(バッチ)
        strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(バッチ)
        strSQL = strSQL & "        ,  '" & GV_SysTime & "' " 'タイムスタンプ(時間)
        strSQL = strSQL & "        ,  '" & GV_SysDate & "' " 'タイムスタンプ(日付)
        strSQL = strSQL & "        ,  '" & SSS_PrgId & "' " '更新PG
        strSQL = strSQL & "        ,  '" & CF_Ora_String("", 1) & "' " '削除フラグ
        'ADD START FKS)INABA 2006/11/20 ***************************************
        strSQL = strSQL & "        ) "

        'SQL実行
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_SBNTRA_Insert_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END

        F_SBNTRA_Insert = 0

F_SBNTRA_Insert_End:
        Exit Function

F_SBNTRA_Insert_err:
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_034, pm_All, "F_SBNTRA_Insert")
        GoTo F_SBNTRA_Insert_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_SBNTRA_Delete
    '   概要：  製番出庫トラン削除処理
    '   引数：  pin_strDatNo  : 伝票管理No
    '           pm_All        : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：  削除とは言っても 対象レコードの伝票削除区分に"9"をセットするだけです。
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_SBNTRA_Delete(ByVal pin_strDatNo As Object, ByRef pm_All As Cls_All) As Short
        Dim strSQL As String
        Dim bolRet As Boolean
        Dim intRet As Short

        On Error GoTo F_SBNTRA_Delete_err

        F_SBNTRA_Delete = 9

        strSQL = ""
        strSQL = strSQL & " Update SBNTRA "
        strSQL = strSQL & "   set "
        strSQL = strSQL & "     DATKB = '" & gc_strDATKB_DEL & "' "
        strSQL = strSQL & "    ,WRTTM = '" & GV_SysTime & "'"
        strSQL = strSQL & "    ,WRTDT = '" & GV_SysDate & "'"
        strSQL = strSQL & "    ,PGID = '" & SSS_PrgId & "'"
        strSQL = strSQL & "   where "
        'UPGRADE_WARNING: オブジェクト pin_strDatNo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     DATNO = '" & pin_strDatNo & "'"

        'SQL実行(SBNTRA)
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_SBNTRA_Delete_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END

        F_SBNTRA_Delete = 0

F_SBNTRA_Delete_End:
        Exit Function

F_SBNTRA_Delete_err:
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_034, pm_All, "F_SBNTRA_Delete")
        GoTo F_SBNTRA_Delete_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_FDNTRA_Update
    '   概要：  FDNTHA、FDNTRA更新処理
    '   引数：  pin_strDatNo  : 伝票管理No
    '           pm_All        : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_FDNTRA_Update(ByVal pin_strDatNo As Object, ByRef pm_All As Cls_All) As Short
        Dim strSQL As String
        Dim bolRet As Boolean
        Dim intRet As Short

        On Error GoTo F_FDNTRA_Update_err

        F_FDNTRA_Update = 9

        strSQL = ""
        strSQL = strSQL & " Update FDNTHA "
        strSQL = strSQL & "   set "
        strSQL = strSQL & "     DATKB = '" & gc_strDATKB_DEL & "' " '伝票削除区分
        strSQL = strSQL & "    ,DENKB = '1' " '伝票区分
        strSQL = strSQL & "    ,CANKB = '0' " '取消区分
        strSQL = strSQL & "    ,DLFLG = '1' " '削除フラグ
        strSQL = strSQL & "    ,WRTTM = '" & GV_SysTime & "'" 'タイムスタンプ（時間）
        strSQL = strSQL & "    ,WRTDT = '" & GV_SysDate & "'" 'タイムスタンプ（日付）
        strSQL = strSQL & "    ,PGID = '" & SSS_PrgId & "'" '更新PGID
        strSQL = strSQL & "   where "
        'UPGRADE_WARNING: オブジェクト pin_strDatNo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     DATNO = '" & pin_strDatNo & "'"


        'SQL実行(FDNTHA)
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_FDNTRA_Update_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END
        strSQL = ""
        strSQL = strSQL & " Update FDNTRA "
        strSQL = strSQL & "   set "
        strSQL = strSQL & "     DATKB = '" & gc_strDATKB_DEL & "' " '伝票削除区分
        strSQL = strSQL & "    ,DENKB = '1' " '伝票区分
        strSQL = strSQL & "    ,CANKB = '0' " '取消区分
        strSQL = strSQL & "    ,DLFLG = '1'" '削除フラグ
        strSQL = strSQL & "    ,WRTTM = '" & GV_SysTime & "'" 'タイムスタンプ（時間）
        strSQL = strSQL & "    ,WRTDT = '" & GV_SysDate & "'" 'タイムスタンプ（日付）
        strSQL = strSQL & "    ,PGID = '" & SSS_PrgId & "'" '更新PGID
        strSQL = strSQL & "   where "
        'UPGRADE_WARNING: オブジェクト pin_strDatNo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     DATNO = '" & pin_strDatNo & "'"

        'SQL実行(FDNTRA)
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_FDNTRA_Update_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END

        F_FDNTRA_Update = 0

F_FDNTRA_Update_End:
        Exit Function

F_FDNTRA_Update_err:
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_034, pm_All, "F_FDNTRA_Update")
        GoTo F_FDNTRA_Update_End

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_FDNTRA_Insert
    '   概要：  出荷指示トラン＆出荷指示見出トラン追加処理
    '   引数：  pin_strDatNo    : 伝票管理No
    '           pin_strPUDLNO   : 入出庫番号
    '           pin_strFdnno    : 納品書番号
    '           pin_strRecno    : レコード管理番号
    '           pm_All          : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_FDNTRA_Insert(ByVal pin_strDatNo As String, ByVal pin_strDatNo_OLD As String, ByRef pm_All As Cls_All) As Short

        Dim strSQL As String
        Dim bolRet As Boolean
        '''' DEL 2012/07/12  FWEST) T.Yamamoto    Start    連絡票№CF12071001
        '    Dim intRet          As Integer
        '    Dim ls_SKSMEDT      As String
        '''' DEL 2012/07/12  FWEST) T.Yamamoto    End
        Dim ls_FDNDT As String
        '''' DEL 2012/07/12  FWEST) T.Yamamoto    Start    連絡票№CF12071001
        '    Dim intData         As Integer
        '    Dim usrOdy          As U_Ody
        '''' DEL 2012/07/12  FWEST) T.Yamamoto    End
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: 構造体 Usr_Ody2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody2 As U_Ody

        Dim strSQL2 As String
        Dim strSQL3 As String
        Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
        Dim ls_SRANO As String
        Dim ls_RSTDT As String
        Dim ls_RSTTM As String
        Dim strHINCD As String
        F_FDNTRA_Insert = 9

        '''' UPD 2012/07/12  FWEST) T.Yamamoto    Start    連絡票№CF12071001
        '    strSQL = ""
        '    strSQL = strSQL & " SELECT TO_CHAR(ADD_MONTHS(TO_DATE(SKSMEDT),1),'YYYYMMDD') SKSMEDT "
        '    strSQL = strSQL & "   FROM SYSTBJ  "
        '    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        '    If CF_Ora_EOF(usrOdy) = True Then
        '
        '    Else
        '        ls_SKSMEDT = CCur(CF_Ora_GetDyn(usrOdy, "SKSMEDT", " "))
        '    End If
        '
        '    If GV_UNYDate > ls_SKSMEDT Then
        '        ls_FDNDT = ls_SKSMEDT
        '    Else
        '        ls_FDNDT = GV_UNYDate
        '    End If
        ls_FDNDT = GV_UNYDate
        '''' UPD 2012/07/12  FWEST) T.Yamamoto    End


        ' 出荷指示トラン(FDNTRA)更新SQL
        strSQL = ""
        strSQL = strSQL & " Insert into FDNTHA "
        strSQL = strSQL & " SELECT '" & pin_strDatNo & "' " '伝票管理No.
        strSQL = strSQL & "       ,'9' " '伝票削除区分
        strSQL = strSQL & "       ,'1' " '伝票区分
        strSQL = strSQL & "       ,FDNNO " '納品書№
        strSQL = strSQL & "       ,SHFDNNO " '納品書№（表示用）
        strSQL = strSQL & "       ,'" & ls_FDNDT & "'" '出荷指示日
        strSQL = strSQL & "       ,'1' " '取消区分
        strSQL = strSQL & "       ,WRKKB " '処理区分
        strSQL = strSQL & "       ,INVNO " 'インボイス№
        strSQL = strSQL & "       ,BINCD " '便区分
        strSQL = strSQL & "       ,OUTBSCD " '出荷場所
        strSQL = strSQL & "       ,OUTSOUCD " '出荷倉庫
        strSQL = strSQL & "       ,ODNYTDT " '出荷予定日
        strSQL = strSQL & "       ,DEFNOKDT " '納期
        strSQL = strSQL & "       ,INPBSCD " '入荷場所
        strSQL = strSQL & "       ,INPSOUCD " '入荷倉庫
        strSQL = strSQL & "       ,TOKCD " '得意先コード
        strSQL = strSQL & "       ,TOKNMA " '得意先名称１
        strSQL = strSQL & "       ,TOKNMB " '得意先名称２
        strSQL = strSQL & "       ,TOKZP " '得意先郵便番号
        strSQL = strSQL & "       ,TOKADA " '得意先住所１
        strSQL = strSQL & "       ,TOKADB " '得意先住所２
        strSQL = strSQL & "       ,TOKADC " '得意先住所３
        strSQL = strSQL & "       ,TOKTL " '得意先電話番号
        strSQL = strSQL & "       ,TOKFX " '得意先FAX番号
        strSQL = strSQL & "       ,NHSCD " '納入先コード
        strSQL = strSQL & "       ,NHSNMA " '納入先名１
        strSQL = strSQL & "       ,NHSNMB " '納入先名２
        strSQL = strSQL & "       ,NHSZP " '納入先郵便番号
        strSQL = strSQL & "       ,NHSADA " '納入先住所１
        strSQL = strSQL & "       ,NHSADB " '納入先住所２
        strSQL = strSQL & "       ,NHSADC " '納入先住所３
        strSQL = strSQL & "       ,NHSTL " '納入先ＴＥＬ
        strSQL = strSQL & "       ,NHSFX " '納入先ＦＡＸ
        strSQL = strSQL & "       ,BMNNM " '出荷元名
        strSQL = strSQL & "       ,BMNZP " '出荷元郵便番号
        strSQL = strSQL & "       ,BMNADA " '出荷元住所１
        strSQL = strSQL & "       ,BMNADB " '出荷元住所２
        strSQL = strSQL & "       ,BMNADC " '出荷元住所３
        strSQL = strSQL & "       ,BMNTL " '出荷元ＴＥＬ
        strSQL = strSQL & "       ,BMNFX " '出荷元ＦＡＸ
        strSQL = strSQL & "       ,BMNURL " '出荷元ＵＲＬ
        strSQL = strSQL & "       ,BUMNM " '部門名
        strSQL = strSQL & "       ,TANNM " '営業担当者名
        strSQL = strSQL & "       ,DENCM " '伝票備考
        strSQL = strSQL & "       ,PUDLNO " '入出庫番号
        strSQL = strSQL & "       ,MOTDATNO " '元伝票管理番号
        strSQL = strSQL & "       ,SIMUKE " '仕向地
        strSQL = strSQL & "       ,CASEMKA " 'ケースマーク１
        strSQL = strSQL & "       ,CASEMKB " 'ケースマーク２
        strSQL = strSQL & "       ,CASEMKC " 'ケースマーク３
        strSQL = strSQL & "       ,CASEMKD " 'ケースマーク４
        strSQL = strSQL & "       ,CASEMKE " 'ケースマーク５
        strSQL = strSQL & "       ,RELFL " '連携フラグ
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザID
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントID
        strSQL = strSQL & "       , '" & GV_SysTime & "' " 'タイムスタンプ（登録時間)
        strSQL = strSQL & "       , '" & GV_SysDate & "' " 'タイムスタンプ（登録日付)
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(訂正)
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(訂正)
        strSQL = strSQL & "       , '" & GV_SysTime & "' " 'タイムスタンプ(訂正時間)
        strSQL = strSQL & "       , '" & GV_SysDate & "' " 'タイムスタンプ(訂正日付)
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(バッチ)
        strSQL = strSQL & "       , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(バッチ)
        strSQL = strSQL & "       , '" & GV_SysTime & "' " 'タイムスタンプ(時間)
        strSQL = strSQL & "       , '" & GV_SysDate & "' " 'タイムスタンプ(日付)
        strSQL = strSQL & "       , '" & SSS_PrgId & "' " '更新PG
        strSQL = strSQL & "       , '" & CF_Ora_String("3", 1) & "' " '削除フラグ
        strSQL = strSQL & "   FROM FDNTHA "
        strSQL = strSQL & "  WHERE DATNO = '" & pin_strDatNo_OLD & "'"

        'SQL実行(FDNTHA)
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_FDNTRA_Insert_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END
        strSQL = ""
        strSQL = strSQL & "  INSERT INTO FDNTRA "
        strSQL = strSQL & "      SELECT '" & pin_strDatNo & "' " '伝票管理No.
        strSQL = strSQL & "            ,'9' " '伝票削除区分
        strSQL = strSQL & "            ,'1' " '伝票区分
        strSQL = strSQL & "            ,'1' " '取消区分
        strSQL = strSQL & "            ,WRKKB " '処理区分
        strSQL = strSQL & "            ,FDNNO " '納品書№
        strSQL = strSQL & "            ,SHFDNNO " '納品書№（表示用）
        strSQL = strSQL & "            ,LINNO " '納品書行№
        strSQL = strSQL & "            ,INVNO " 'インボイス№
        strSQL = strSQL & "            ,RECNO " 'レコード管理No.
        strSQL = strSQL & "            ,SBNNO " '製番
        strSQL = strSQL & "            ,BINCD " '便区分
        strSQL = strSQL & "            ,OUTBSCD " '出荷場所
        strSQL = strSQL & "            ,OUTSOUCD " '出荷倉庫
        strSQL = strSQL & "            ,'" & ls_FDNDT & "'" '出荷指示日
        strSQL = strSQL & "            ,ODNYTDT " '出荷予定日
        strSQL = strSQL & "            ,DEFNOKDT " '納期
        strSQL = strSQL & "            ,JDNNO " '受注№
        strSQL = strSQL & "            ,JDNLINNO " '受注行番号
        strSQL = strSQL & "            ,HINCD " '製品コード
        strSQL = strSQL & "            ,HINNMA " '型式
        strSQL = strSQL & "            ,HINNMB " '商品名１
        strSQL = strSQL & "            ,JANCD " 'ＪＡＮコード
        strSQL = strSQL & "            ,LOTNO " 'ロット№
        strSQL = strSQL & "            ,FRDYTSU * (-1) " '出荷予定数
        strSQL = strSQL & "            ,HIKSU * (-1) " '引当数
        'CHG START
        strSQL = strSQL & "            ,FRDYTSU* (-1) " '出荷指示数量
        strSQL = strSQL & "            ,0 " '出荷実績数量
        '    strSQL = strSQL & "            ,FRDSU * (-1) "                              '出荷指示数量
        '    strSQL = strSQL & "            ,OTPSU "                                     '出荷実績数量
        'CHG  END
        strSQL = strSQL & "            ,UNTNM " '単位
        strSQL = strSQL & "            ,FRDTK " '単価
        strSQL = strSQL & "            ,FRDKN " '金額
        strSQL = strSQL & "            ,UZEKN " '消費税
        strSQL = strSQL & "            ,TOKJDNNO " '客先注文番号
        strSQL = strSQL & "            ,TOKJDNED " '客先注文No枝番
        strSQL = strSQL & "            ,LINCMA " '明細備考１
        strSQL = strSQL & "            ,LINCMB " '明細備考２
        strSQL = strSQL & "            ,INPBSCD " '入荷場所
        strSQL = strSQL & "            ,INPSOUCD " '入荷倉庫
        strSQL = strSQL & "            ,TOKCD " '得意先コード
        strSQL = strSQL & "            ,TOKNMA " '得意先名称１
        strSQL = strSQL & "            ,TOKNMB " '得意先名称２
        strSQL = strSQL & "            ,TOKZP " '得意先郵便番号
        strSQL = strSQL & "            ,TOKADA " '得意先住所１
        strSQL = strSQL & "            ,TOKADB " '得意先住所２
        strSQL = strSQL & "            ,TOKADC " '得意先住所３
        strSQL = strSQL & "            ,TOKTL " '得意先電話番号
        strSQL = strSQL & "            ,TOKFX " '得意先FAX番号
        strSQL = strSQL & "            ,NHSCD " '納入先コード
        strSQL = strSQL & "            ,NHSNMA " '納入先名１
        strSQL = strSQL & "            ,NHSNMB " '納入先名２
        strSQL = strSQL & "            ,NHSZP " '納入先郵便番号
        strSQL = strSQL & "            ,NHSADA " '納入先住所１
        strSQL = strSQL & "            ,NHSADB " '納入先住所２
        strSQL = strSQL & "            ,NHSADC " '納入先住所３
        strSQL = strSQL & "            ,NHSTL " '納入先ＴＥＬ
        strSQL = strSQL & "            ,NHSFX " '納入先ＦＡＸ
        strSQL = strSQL & "            ,BMNNM " '出荷元名
        strSQL = strSQL & "            ,BMNZP " '出荷元郵便番号
        strSQL = strSQL & "            ,BMNADA " '出荷元住所１
        strSQL = strSQL & "            ,BMNADB " '出荷元住所２
        strSQL = strSQL & "            ,BMNADC " '出荷元住所３
        strSQL = strSQL & "            ,BMNTL " '出荷元ＴＥＬ
        strSQL = strSQL & "            ,BMNFX " '出荷元ＦＡＸ
        strSQL = strSQL & "            ,BMNURL " '出荷元ＵＲＬ
        strSQL = strSQL & "            ,BUMNM " '部門名
        strSQL = strSQL & "            ,TANNM " '営業担当者名
        strSQL = strSQL & "            ,DENCM " '伝票備考
        strSQL = strSQL & "            ,PUDLNO " '入出庫番号
        strSQL = strSQL & "            ,MOTDATNO " '元伝票管理番号
        If IDOET52_SBNTRA_Inf.KKOUT = 1 Then '緊急出庫取消時
            strSQL = strSQL & "            ,'1' " '出荷済フラグ
        Else '戻し取消時
            strSQL = strSQL & "            ,'3' " '出荷済フラグ
        End If
        strSQL = strSQL & "            ,BKTHKKB " '分割不可区分
        strSQL = strSQL & "            ,SYKDATNO " '出庫予定管理№
        strSQL = strSQL & "            ,'" & CF_Ora_String("", 5) & "'" 'ダミー１
        strSQL = strSQL & "            ,'" & CF_Ora_String("", 10) & "'" 'ダミー２
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザID
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントID
        strSQL = strSQL & "            ,'" & GV_SysTime & "' " 'タイムスタンプ（登録時間)
        strSQL = strSQL & "            ,'" & GV_SysDate & "' " 'タイムスタンプ（登録日付)
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(訂正)
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(訂正)
        strSQL = strSQL & "            ,'" & GV_SysTime & "' " 'タイムスタンプ(訂正時間)
        strSQL = strSQL & "            ,'" & GV_SysDate & "' " 'タイムスタンプ(訂正日付)
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(バッチ)
        strSQL = strSQL & "            ,'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID(バッチ)
        strSQL = strSQL & "            ,'" & GV_SysTime & "' " 'タイムスタンプ(時間)
        strSQL = strSQL & "            ,'" & GV_SysDate & "' " 'タイムスタンプ(日付)
        strSQL = strSQL & "            ,'" & SSS_PrgId & "' " '更新PG
        strSQL = strSQL & "            ,'" & CF_Ora_String("3", 1) & "' " '削除フラグ
        strSQL = strSQL & "   FROM FDNTRA "
        strSQL = strSQL & "  WHERE DATNO = '" & pin_strDatNo_OLD & "'"

        'SQL実行(FDNTRA)
        '2019/06/24 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        'If bolRet = False Then
        '    GoTo F_FDNTRA_Insert_err
        'End If
        Call DB_Execute(strSQL)
        '2019/06/24 CHG END

        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strHINCD = CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 10)
        If DSPHINCD_SEARCH(strHINCD, Mst_Inf_HINMTA) = 0 Then
            'CHG START FKS)INABA 2009/12/21 **********************************************************
            '連絡票№766
            If IDOET52_SBNTRA_Inf.KKOUT = 1 Then
                '        If IDOET52_SBNTRA_Inf.KKOUT = 1 And Mst_Inf_HINMTA.SERIKB = "1" Then
                'CHG  END  FKS)INABA 2009/12/21 **********************************************************
                strSQL = " SELECT SRANO "
                strSQL = strSQL & "  FROM SRACNTTB "
                strSQL = strSQL & " WHERE HINCD  = '" & strHINCD & "'"
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSQL = strSQL & "   AND SBNNO  = '" & Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value) & "'"
                strSQL = strSQL & "   AND PUDLNO = '" & Trim(IDOET52_SBNTRA_Inf.PUDLNO) & "'"
                strSQL = strSQL & " ORDER BY SRANO "
                '2019/06/24 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                'Do Until CF_Ora_EOF(Usr_Ody) = True
                '    ls_SRANO = ""
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    ls_SRANO = CF_Ora_GetDyn(Usr_Ody, "SRANO", "")

                '    ls_RSTDT = ""
                '    ls_RSTTM = ""
                '    strSQL2 = " SELECT RSTDT ,RSTTM FROM SRARSTTB "
                '    strSQL2 = strSQL2 & " WHERE SRANO='" & ls_SRANO & "'"
                '    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    strSQL2 = strSQL2 & "   AND SBNNO <> '" & Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value) & "'"
                '    strSQL2 = strSQL2 & "   AND PUDLNO <> '" & Trim(IDOET52_SBNTRA_Inf.PUDLNO) & "'"

                '    strSQL2 = strSQL2 & " ORDER BY SRANO, RSTDT DESC, RSTTM DESC"
                '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSQL2)

                '    If CF_Ora_EOF(Usr_Ody2) = False Then
                '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        ls_RSTDT = CF_Ora_GetDyn(Usr_Ody2, "RSTDT", "")
                '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        ls_RSTTM = CF_Ora_GetDyn(Usr_Ody2, "RSTTM", "")

                '        strSQL3 = "INSERT INTO SRARSTTB  "
                '        strSQL3 = strSQL3 & " SELECT  "
                '        strSQL3 = strSQL3 & "         SRANO    "
                '        strSQL3 = strSQL3 & "        ,LOTNO    "
                '        strSQL3 = strSQL3 & "        ,RSTDT    "
                '        strSQL3 = strSQL3 & "        ,RSTTM    "
                '        strSQL3 = strSQL3 & "        ,HINCD    "
                '        strSQL3 = strSQL3 & "        ,SBNNO    "
                '        strSQL3 = strSQL3 & "        ,PUDLNO   "
                '        strSQL3 = strSQL3 & "        ,SZTNM    "
                '        strSQL3 = strSQL3 & "        ,SZTNM    "
                '        strSQL3 = strSQL3 & "        ,ZAISYOBN "
                '        strSQL3 = strSQL3 & "        ,RELFL    "
                '        strSQL3 = strSQL3 & "        ,FOPEID   "
                '        strSQL3 = strSQL3 & "        ,FCLTID   "
                '        strSQL3 = strSQL3 & "        ,WRTFSTTM "
                '        strSQL3 = strSQL3 & "        ,WRTFSTDT "
                '        strSQL3 = strSQL3 & "        ,OPEID    "
                '        strSQL3 = strSQL3 & "        ,CLTID    "
                '        strSQL3 = strSQL3 & "        ,WRTTM    "
                '        strSQL3 = strSQL3 & "        ,WRTDT    "
                '        strSQL3 = strSQL3 & "        ,UOPEID   "
                '        strSQL3 = strSQL3 & "        ,UCLTID   "
                '        strSQL3 = strSQL3 & "        ,UWRTTM   "
                '        strSQL3 = strSQL3 & "        ,UWRTDT   "
                '        strSQL3 = strSQL3 & "        ,PGID     "
                '        strSQL3 = strSQL3 & " FROM SRACNTTB "
                '        strSQL3 = strSQL3 & " WHERE SRANO = '" & ls_SRANO & "'"
                '        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL3)
                '        If bolRet = False Then
                '            GoTo F_FDNTRA_Insert_err
                '        End If

                '        strSQL3 = "UPDATE SRACNTTB  SET ("
                '        strSQL3 = strSQL3 & "     LOTNO    "
                '        strSQL3 = strSQL3 & "    ,RSTDT    "
                '        strSQL3 = strSQL3 & "    ,RSTTM    "
                '        strSQL3 = strSQL3 & "    ,HINCD    "
                '        strSQL3 = strSQL3 & "    ,SBNNO    "
                '        strSQL3 = strSQL3 & "    ,PUDLNO   "
                '        strSQL3 = strSQL3 & "    ,SZTNM    "
                '        strSQL3 = strSQL3 & "    ,ZAISYOBN "
                '        strSQL3 = strSQL3 & "    ,RELFL    "
                '        strSQL3 = strSQL3 & "    ,OPEID    "
                '        strSQL3 = strSQL3 & "    ,CLTID    "
                '        strSQL3 = strSQL3 & "    ,WRTTM    "
                '        strSQL3 = strSQL3 & "    ,WRTDT    "
                '        strSQL3 = strSQL3 & "    ,PGID) =  "

                '        strSQL3 = strSQL3 & " ( SELECT  "
                '        strSQL3 = strSQL3 & "          LOTNO    "
                '        strSQL3 = strSQL3 & "         ,'" & GV_SysDate & "'" 'RSTDT
                '        strSQL3 = strSQL3 & "         ,'" & GV_SysTime & "'" 'RSTTM
                '        strSQL3 = strSQL3 & "         ,HINCD    "
                '        strSQL3 = strSQL3 & "         ,SBNNO    "
                '        strSQL3 = strSQL3 & "         ,PUDLNO   "
                '        strSQL3 = strSQL3 & "         ,SZTNM    "
                '        strSQL3 = strSQL3 & "         ,ZAISYOBN "
                '        strSQL3 = strSQL3 & "         ,RELFL    "
                '        strSQL3 = strSQL3 & "         ,'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
                '        strSQL3 = strSQL3 & "         ,'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
                '        strSQL3 = strSQL3 & "         ,'" & GV_SysTime & "'" 'WRTTM
                '        strSQL3 = strSQL3 & "         ,'" & GV_SysDate & "'" 'WRTDT
                '        strSQL3 = strSQL3 & "         ,'" & SSS_PrgId & "'"
                '        strSQL3 = strSQL3 & "   FROM SRARSTTB "
                '        strSQL3 = strSQL3 & "  WHERE SRANO = '" & ls_SRANO & "'"
                '        strSQL3 = strSQL3 & "    AND RSTDT = '" & ls_RSTDT & "'"
                '        strSQL3 = strSQL3 & "    AND RSTTM = '" & ls_RSTTM & "' )"
                '        strSQL3 = strSQL3 & " WHERE SRANO = '" & ls_SRANO & "'"
                '        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL3)
                '        If bolRet = False Then
                '            GoTo F_FDNTRA_Insert_err
                '        End If
                '    End If
                '    Call CF_Ora_CloseDyn(Usr_Ody2)

                '    Call CF_Ora_MoveNext(Usr_Ody)
                'Loop
                Dim dt As DataTable = DB_GetTable(strSQL)
                For i As Integer = 0 To dt.Rows.Count - 1
                    ls_SRANO = ""
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ls_SRANO = DB_NullReplace(dt.Rows(0)("SRANO"), "")

                    ls_RSTDT = ""
                    ls_RSTTM = ""
                    strSQL2 = " SELECT RSTDT ,RSTTM FROM SRARSTTB "
                    strSQL2 = strSQL2 & " WHERE SRANO='" & ls_SRANO & "'"
                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strSQL2 = strSQL2 & "   AND SBNNO <> '" & Trim(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SBNNO.Tag)).Detail.Dsp_Value) & "'"
                    strSQL2 = strSQL2 & "   AND PUDLNO <> '" & Trim(IDOET52_SBNTRA_Inf.PUDLNO) & "'"

                    strSQL2 = strSQL2 & " ORDER BY SRANO, RSTDT DESC, RSTTM DESC"

                    Dim dt2 As DataTable = DB_GetTable(strSQL2)

                    If dt2.Rows.Count > 0 Then
                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        ls_RSTDT = DB_NullReplace(dt2.Rows(0)("RSTDT"), "")
                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        ls_RSTTM = DB_NullReplace(dt2.Rows(0)("RSTTM"), "")

                        strSQL3 = "INSERT INTO SRARSTTB  "
                        strSQL3 = strSQL3 & " SELECT  "
                        strSQL3 = strSQL3 & "         SRANO    "
                        strSQL3 = strSQL3 & "        ,LOTNO    "
                        strSQL3 = strSQL3 & "        ,RSTDT    "
                        strSQL3 = strSQL3 & "        ,RSTTM    "
                        strSQL3 = strSQL3 & "        ,HINCD    "
                        strSQL3 = strSQL3 & "        ,SBNNO    "
                        strSQL3 = strSQL3 & "        ,PUDLNO   "
                        strSQL3 = strSQL3 & "        ,SZTNM    "
                        strSQL3 = strSQL3 & "        ,SZTNM    "
                        strSQL3 = strSQL3 & "        ,ZAISYOBN "
                        strSQL3 = strSQL3 & "        ,RELFL    "
                        strSQL3 = strSQL3 & "        ,FOPEID   "
                        strSQL3 = strSQL3 & "        ,FCLTID   "
                        strSQL3 = strSQL3 & "        ,WRTFSTTM "
                        strSQL3 = strSQL3 & "        ,WRTFSTDT "
                        strSQL3 = strSQL3 & "        ,OPEID    "
                        strSQL3 = strSQL3 & "        ,CLTID    "
                        strSQL3 = strSQL3 & "        ,WRTTM    "
                        strSQL3 = strSQL3 & "        ,WRTDT    "
                        strSQL3 = strSQL3 & "        ,UOPEID   "
                        strSQL3 = strSQL3 & "        ,UCLTID   "
                        strSQL3 = strSQL3 & "        ,UWRTTM   "
                        strSQL3 = strSQL3 & "        ,UWRTDT   "
                        strSQL3 = strSQL3 & "        ,PGID     "
                        strSQL3 = strSQL3 & " FROM SRACNTTB "
                        strSQL3 = strSQL3 & " WHERE SRANO = '" & ls_SRANO & "'"
                        '2019/06/24 CHG START
                        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL3)
                        'If bolRet = False Then
                        '    GoTo F_FDNTRA_Insert_err
                        'End If
                        DB_Execute(strSQL3)
                        '2019/06/24 CHG END
                        strSQL3 = "UPDATE SRACNTTB  SET ("
                        strSQL3 = strSQL3 & "     LOTNO    "
                        strSQL3 = strSQL3 & "    ,RSTDT    "
                        strSQL3 = strSQL3 & "    ,RSTTM    "
                        strSQL3 = strSQL3 & "    ,HINCD    "
                        strSQL3 = strSQL3 & "    ,SBNNO    "
                        strSQL3 = strSQL3 & "    ,PUDLNO   "
                        strSQL3 = strSQL3 & "    ,SZTNM    "
                        strSQL3 = strSQL3 & "    ,ZAISYOBN "
                        strSQL3 = strSQL3 & "    ,RELFL    "
                        strSQL3 = strSQL3 & "    ,OPEID    "
                        strSQL3 = strSQL3 & "    ,CLTID    "
                        strSQL3 = strSQL3 & "    ,WRTTM    "
                        strSQL3 = strSQL3 & "    ,WRTDT    "
                        strSQL3 = strSQL3 & "    ,PGID) =  "

                        strSQL3 = strSQL3 & " ( SELECT  "
                        strSQL3 = strSQL3 & "          LOTNO    "
                        strSQL3 = strSQL3 & "         ,'" & GV_SysDate & "'" 'RSTDT
                        strSQL3 = strSQL3 & "         ,'" & GV_SysTime & "'" 'RSTTM
                        strSQL3 = strSQL3 & "         ,HINCD    "
                        strSQL3 = strSQL3 & "         ,SBNNO    "
                        strSQL3 = strSQL3 & "         ,PUDLNO   "
                        strSQL3 = strSQL3 & "         ,SZTNM    "
                        strSQL3 = strSQL3 & "         ,ZAISYOBN "
                        strSQL3 = strSQL3 & "         ,RELFL    "
                        strSQL3 = strSQL3 & "         ,'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
                        strSQL3 = strSQL3 & "         ,'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
                        strSQL3 = strSQL3 & "         ,'" & GV_SysTime & "'" 'WRTTM
                        strSQL3 = strSQL3 & "         ,'" & GV_SysDate & "'" 'WRTDT
                        strSQL3 = strSQL3 & "         ,'" & SSS_PrgId & "'"
                        strSQL3 = strSQL3 & "   FROM SRARSTTB "
                        strSQL3 = strSQL3 & "  WHERE SRANO = '" & ls_SRANO & "'"
                        strSQL3 = strSQL3 & "    AND RSTDT = '" & ls_RSTDT & "'"
                        strSQL3 = strSQL3 & "    AND RSTTM = '" & ls_RSTTM & "' )"
                        strSQL3 = strSQL3 & " WHERE SRANO = '" & ls_SRANO & "'"
                        '2019/06/24 CHG START
                        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL3)
                        'If bolRet = False Then
                        '    GoTo F_FDNTRA_Insert_err
                        'End If
                        DB_Execute(strSQL3)
                        '2019/06/24 CHG END
                    End If
                    Call CF_Ora_CloseDyn(Usr_Ody2)

                Next
                '2019/06/24 CHG END
                Call CF_Ora_CloseDyn(Usr_Ody)
            End If
        End If

        F_FDNTRA_Insert = 0

F_FDNTRA_Insert_End:
        Exit Function

F_FDNTRA_Insert_err:
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_034, pm_All, "F_FDNTRA_Insert")
        GoTo F_FDNTRA_Insert_End

    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_HINMTB_Update
    '   概要：  倉庫別在庫マスタ更新処理
    '   引数：
    '           pm_All          : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_HINMTB_Update(ByRef pm_All As Cls_All) As Short
        Dim strSQL As String
        Dim bolRet As Boolean
        Dim intRet As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim ls_RowID As String
        Dim Mst_Inf_SOUMTA As TYPE_DB_SOUMTA
        Dim ls_SOUCD As String
        Dim LS_HINCD As String
        On Error GoTo F_HINMTB_Update_err

        F_HINMTB_Update = 9
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ls_SOUCD = CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value, 3)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        LS_HINCD = CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_HINCD(1).Tag)).Detail.Dsp_Value, 10)
        strSQL = ""
        strSQL = strSQL & " SELECT ROWID "
        strSQL = strSQL & "   FROM HINMTB "
        strSQL = strSQL & " WHERE DATKB = '1'"
        strSQL = strSQL & "   AND SOUCD = '" & ls_SOUCD & "'"
        strSQL = strSQL & "   AND HINCD = '" & LS_HINCD & "'"
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/24 CHG END
        '取得データ退避
        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    ls_RowID = CF_Ora_GetDyn(Usr_Ody, "ROWID", "")
        'Else
        '    ls_RowID = ""
        'End If
        If dt.Rows.Count > 0 Then
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ls_RowID = DB_NullReplace(dt.Rows(0)("ROWID"), "")
        Else
            ls_RowID = ""
        End If
        '2019/06/24 CHG END
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        'データが存在しない場合、データを追加する。
        If ls_RowID = "" Then
            intRet = DSPSOUCD_SEARCH(ls_SOUCD, Mst_Inf_SOUMTA)
            strSQL = ""
            strSQL = strSQL & "INSERT INTO HINMTB ("
            strSQL = strSQL & " DATKB " '1
            strSQL = strSQL & ",HINMSTKB " '2
            strSQL = strSQL & ",SOUCD " '3
            strSQL = strSQL & ",HINCD " '4
            strSQL = strSQL & ",SISNKB " '5
            strSQL = strSQL & ",SOUTRICD " '6
            strSQL = strSQL & ",SOUKOKB " '7
            strSQL = strSQL & ",HIKKB " '8
            strSQL = strSQL & ",HINCLAKB " '9
            strSQL = strSQL & ",HINCLBKB " '10
            strSQL = strSQL & ",HINCLCKB " '11
            strSQL = strSQL & ",HINCLAID " '12
            strSQL = strSQL & ",HINCLBID " '13
            strSQL = strSQL & ",HINCLCID " '14
            strSQL = strSQL & ",ZNETNADT " '15
            strSQL = strSQL & ",ZNETNATK " '16
            strSQL = strSQL & ",ZNETNASU " '17
            strSQL = strSQL & ",ZNETNAKN " '18
            strSQL = strSQL & ",SMAZANDT " '19
            strSQL = strSQL & ",SMAZANSU " '20
            strSQL = strSQL & ",SMAZANTK " '21
            strSQL = strSQL & ",SMAZANKN " '22
            strSQL = strSQL & ",RELZAISU " '23
            strSQL = strSQL & ",HIKSU " '24
            strSQL = strSQL & ",RELJDNSU " '25
            strSQL = strSQL & ",RELHDNSU " '26
            strSQL = strSQL & ",RELFDNSU " '27
            strSQL = strSQL & ",RELADNSU " '28
            strSQL = strSQL & ",RELODNSU " '29
            strSQL = strSQL & ",RELIDNSU " '30
            strSQL = strSQL & ",RELAZUSU " '31
            strSQL = strSQL & ",FSTSTKDT " '32
            strSQL = strSQL & ",FSTDLVDT " '33
            strSQL = strSQL & ",NEWSTKDT " '34
            strSQL = strSQL & ",NEWDLVDT " '35
            strSQL = strSQL & ",WRKTNADT " '36
            strSQL = strSQL & ",WRKTNATK " '37
            strSQL = strSQL & ",WRKTNASU " '38
            strSQL = strSQL & ",WRKTNAKN " '39
            strSQL = strSQL & ",RELFL " '40
            strSQL = strSQL & ",FOPEID " '41　初回ユーザID
            strSQL = strSQL & ",FCLTID " '42　初回登録クライアントID
            strSQL = strSQL & ",WRTFSTTM " '43　タイムスタンプ（登録時間）
            strSQL = strSQL & ",WRTFSTDT " '44　タイムスタンプ（登録日付）
            strSQL = strSQL & ",OPEID " '45　ユーザID（訂正）
            strSQL = strSQL & ",CLTID " '46　クライアントID
            strSQL = strSQL & ",WRTTM " '47　タイムスタンプ（訂正時間）
            strSQL = strSQL & ",WRTDT " '48　タイムスタンプ（訂正日付）
            strSQL = strSQL & ",UOPEID " '49　ユーザID（バッチ）
            strSQL = strSQL & ",UCLTID " '50　ユーザID（バッチ）
            strSQL = strSQL & ",UWRTTM " '51　タイムスタンプ（時間）
            strSQL = strSQL & ",UWRTDT " '52　タイムスタンプ（日付）
            strSQL = strSQL & ",PGID " '53　更新PG
            strSQL = strSQL & " )VALUES( "
            strSQL = strSQL & "   '1'" '1
            strSQL = strSQL & ",  '5'" '2
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & ", '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_SOUCD.Tag)).Detail.Dsp_Value, 3) & "'" '3
            strSQL = strSQL & ", '" & CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINCD, 10) & "'" '4
            strSQL = strSQL & ", '" & Mst_Inf_SOUMTA.SISNKB & "'" '5
            strSQL = strSQL & ", '" & Mst_Inf_SOUMTA.SOUTRICD & "'" '6
            strSQL = strSQL & ", '" & Mst_Inf_SOUMTA.SOUKOKB & "'" '7
            strSQL = strSQL & ", '" & Mst_Inf_SOUMTA.HIKKB & "'" '8
            strSQL = strSQL & ", ' '" '9
            strSQL = strSQL & ", ' '" '10
            strSQL = strSQL & ", ' '" '11
            strSQL = strSQL & ", ' '" '12
            strSQL = strSQL & ", ' '" '13
            strSQL = strSQL & ", ' '" '14
            strSQL = strSQL & ", ' '" '15　前期末棚卸日付
            strSQL = strSQL & ", 0 " '16　前期末棚卸単価
            strSQL = strSQL & ", 0 " '17　前期末棚卸数量
            strSQL = strSQL & ", 0 " '18　前期末棚卸金額
            strSQL = strSQL & ", ' '" '19　経理締残高日付
            strSQL = strSQL & ", 0 " '20　経理締残高数量
            strSQL = strSQL & ", 0 " '21　経理締残高単価
            strSQL = strSQL & ", 0 " '22　経理締残高金額
            strSQL = strSQL & ", 0 " '23　現在庫数
            strSQL = strSQL & ", " & CF_Ora_Number(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UODSU) * (-1) '24　引当数
            strSQL = strSQL & ", 0 " '25　現在受注残数
            strSQL = strSQL & ", 0 " '26　現在発注残数
            strSQL = strSQL & ", 0 " '27　現在出荷指示残数
            strSQL = strSQL & ", 0 " '28　現在入荷予定残数
            strSQL = strSQL & ", 0 " '29　現在出荷残数
            strSQL = strSQL & ", 0 " '30　現在入荷残数
            strSQL = strSQL & ", 0 " '31　現在預り残数
            strSQL = strSQL & ", '" & GV_SysDate & "'" '32　第1回入庫日
            strSQL = strSQL & ", ' '" '33　第1回出庫日
            strSQL = strSQL & ", '" & GV_SysDate & "'" '34　最新入庫日
            strSQL = strSQL & ", ' '" '35　最新出庫日
            strSQL = strSQL & ", ' '" '36　棚卸日付
            strSQL = strSQL & ", 0 " '37　棚卸単価
            strSQL = strSQL & ", 0 " '38　棚卸数量
            strSQL = strSQL & ", 0 " '39　棚卸金額
            strSQL = strSQL & ", ' '" '40　連携フラグ
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '41　初回登録ユーザID
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '42　初回登録クライアントID
            strSQL = strSQL & ", '" & GV_SysTime & "' " '43　タイムスタンプ（登録時間)
            strSQL = strSQL & ", '" & GV_SysDate & "' " '44　タイムスタンプ（登録日付)
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '45　ユーザID(訂正)
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '46　クライアントID(訂正)
            strSQL = strSQL & ", '" & GV_SysTime & "' " '47　タイムスタンプ(訂正時間)
            strSQL = strSQL & ", '" & GV_SysDate & "' " '48　タイムスタンプ(訂正日付)
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '49　ユーザID(バッチ)
            strSQL = strSQL & ", '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '50　クライアントID(バッチ)
            strSQL = strSQL & ", '" & GV_SysTime & "' " '51　タイムスタンプ(時間)
            strSQL = strSQL & ", '" & GV_SysDate & "' " '52　タイムスタンプ(日付)
            strSQL = strSQL & ", '" & SSS_PrgId & "' " '53　更新PG

            strSQL = strSQL & " )"
            'SQL実行(FDNTRA)
            '2019/06/24 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo F_HINMTB_Update_err
            'End If
            Call DB_Execute(strSQL)
            '2019/06/20 CHG END

        Else
            strSQL = ""
            strSQL = strSQL & " Update HINMTB "
            strSQL = strSQL & " set HIKSU = HIKSU + " & CF_Ora_Number(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UODSU) * (-1)
            strSQL = strSQL & ", OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '45　ユーザID(訂正)
            strSQL = strSQL & ", CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '46　クライアントID(訂正)
            strSQL = strSQL & ", WRTTM = '" & GV_SysTime & "' " '47　タイムスタンプ(訂正時間)
            strSQL = strSQL & ", WRTDT = '" & GV_SysDate & "' " '48　タイムスタンプ(訂正日付)
            strSQL = strSQL & ", UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '49　ユーザID(バッチ)
            strSQL = strSQL & ", UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '50　クライアントID(バッチ)
            strSQL = strSQL & ", UWRTTM = '" & GV_SysTime & "' " '51　タイムスタンプ(時間)
            strSQL = strSQL & ", UWRTDT = '" & GV_SysDate & "' " '52　タイムスタンプ(日付)
            strSQL = strSQL & ", PGID = '" & SSS_PrgId & "' " '53　更新PG
            strSQL = strSQL & " where ROWID = '" & ls_RowID & "'"

            'SQL実行(FDNTRA)
            '2019/06/24 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo F_HINMTB_Update_err
            'End If
            Call DB_Execute(strSQL)
            '2019/06/24 CHG END
        End If
        F_HINMTB_Update = 0

F_HINMTB_Update_End:
        Exit Function

F_HINMTB_Update_err:
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_034, pm_All, "F_HINMTB_Update")
        GoTo F_HINMTB_Update_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_VScrl_Max
    '   概要：  スクロールバーのmaxプロパティへの設定値取得
    '   引数：　pm_Dsp_Data_Cnt       :取得データ数（UBound(Row_Inf)）
    '           pm_Dsp_Body_Cnt       :最大表示明細数（Dsp_Base設定値）
    '   戻値：　設定値
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Get_VScrl_Max(ByRef pm_Dsp_Data_Cnt As Short, ByRef pm_Dsp_Body_Cnt As Short) As Short

        Dim Ret_Value As Short
        Dim Wk_Value As Short

        '    Ret_Value = ((pm_Dsp_Data_Cnt - 2) / (pm_Dsp_Body_Cnt - 1)) + 1

        'とりあえず１を設定
        Ret_Value = 1
        '取得件数が最大表示件数を上回る場合、オーバー分を加算
        Wk_Value = pm_Dsp_Data_Cnt - pm_Dsp_Body_Cnt
        If Wk_Value > 0 Then
            Ret_Value = Ret_Value + Wk_Value
        End If

        F_Get_VScrl_Max = Ret_Value

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Body_Enable
    '   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
    '   　　　　明細行のｺﾝﾄﾛｰﾙ制御を行う
    '   引数：　pm_All　: 画面情報
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short
        Dim Bd_Index As Short
        Dim Bd_Index_Bk As Short
        Dim Bd_Col_Index As Short
        Dim Bd_Row_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Wk_Row As Short
        Dim Wk_Index As Short
        Dim InpRow As Short

        Bd_Row_Index = 0

        If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
            '明細表示の画面

            'ボディ部内で処理
            Bd_Index = 0
            Bd_Index_Bk = 0

            For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1

                If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then

                    Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
                    'pm_All.Dsp_Body_Infの行ＮＯを取得
                    Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

                    If Bd_Index_Bk <> Bd_Index Then
                        '明細行ブレイク
                        Bd_Col_Index = 1
                        Bd_Index_Bk = Bd_Index
                        Bd_Row_Index = Bd_Row_Index + 1
                    Else
                        Bd_Col_Index = Bd_Col_Index + 1
                    End If

                    '** ｺﾝﾄﾛｰﾙ制御 **
                    ''H.Y.(9/22)S    Select Case Index_Wk
                    ''                    '型式
                    ''                    Case CInt(FR_SSSMAIN.BD_HINNMA(1).Tag)          ' (2)-(5)は不要 (H.Y.)
                    ''
                    ''                        '名称ﾏﾆｭｱﾙ入力区分='1'の場合、型式・品名は変更可
                    ''                        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMMKB = gc_strNMMKB_OK Then
                    ''                            Focus_Ctl = True
                    ''                        Else
                    ''                            Focus_Ctl = False
                    ''                        End If
                    ''
                    ''                        '【型式】
                    ''                        Wk_Index = CInt(FR_SSSMAIN.BD_HINNMA(0).Tag)
                    ''                        Call CF_Set_Dsp_Body_Item_Focus_Ctl(Focus_Ctl _
                    '''                                                          , pm_All.Dsp_Sub_Inf(Wk_Index) _
                    '''                                                          , Wk_Row _
                    '''                                                          , pm_All)
                    ''
                    ''                    '品名
                    ''                    Case CInt(FR_SSSMAIN.BD_HINNMB(1).Tag)          ' (2)-(5)は不要 (H.Y.)
                    ''
                    ''                        '名称ﾏﾆｭｱﾙ入力区分='1'の場合、品名は変更可
                    ''                        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HINNMMKB = gc_strNMMKB_OK Then
                    ''                            Focus_Ctl = True
                    ''                        Else
                    ''                            Focus_Ctl = False
                    ''                        End If
                    ''
                    ''                        '【品名】
                    ''                        Wk_Index = CInt(FR_SSSMAIN.BD_HINNMB(0).Tag)
                    ''                        Call CF_Set_Dsp_Body_Item_Focus_Ctl(Focus_Ctl _
                    '''                                                          , pm_All.Dsp_Sub_Inf(Wk_Index) _
                    '''                                                          , Wk_Row _
                    '''                                                          , pm_All)
                    ''H.Y.(9/22)E    End Select

                End If
            Next
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Body_Bef_Chk_Value
    '   概要：  明細表示時にチェック済み項目とする
    '   引数：　pm_All　: 画面情報
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Body_Bef_Chk_Value(ByRef pm_All As Cls_All) As Short

        Dim Index_Wk As Short
        Dim Bd_Index As Short
        Dim Bd_Index_Bk As Short
        Dim Bd_Col_Index As Short
        Dim Bd_Row_Index As Short
        Dim Focus_Ctl As Boolean
        Dim Wk_Row As Short
        Dim Wk_Index As Short

        Bd_Row_Index = 0

        If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
            '明細表示の画面

            'ボディ部内で処理
            Bd_Index = 0
            Bd_Index_Bk = 0

            For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1

                If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then

                    Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
                    'pm_All.Dsp_Body_Infの行ＮＯを取得
                    Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

                    If Bd_Index_Bk <> Bd_Index Then
                        '明細行ブレイク
                        Bd_Col_Index = 1
                        Bd_Index_Bk = Bd_Index
                        Bd_Row_Index = Bd_Row_Index + 1
                    Else
                        Bd_Col_Index = Bd_Col_Index + 1
                    End If

                    With pm_All.Dsp_Sub_Inf(Index_Wk)
                        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                        Select Case True
                            Case TypeOf .Ctl Is System.Windows.Forms.TextBox
                                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))) <> "" Then
                                    'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    .Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
                                    .Detail.Not_Input_Chk_Fin_Flg = True
                                End If
                            Case TypeOf .Ctl Is System.Windows.Forms.CheckBox
                                If CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk)) <> System.Windows.Forms.CheckState.Unchecked Then
                                    'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    .Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
                                    .Detail.Not_Input_Chk_Fin_Flg = True
                                End If
                        End Select
                    End With
                End If
            Next
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Value_NotInput
    '   概要：  画面に入力されている場合はその値を優先する
    '   引数：
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Value_NotInput(ByRef pm_inpValue As Object, ByRef pm_intTag As Short, ByRef pm_All As Cls_All) As Object

        Dim DspValue As Object

        'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        Select Case True
            Case TypeOf pm_All.Dsp_Sub_Inf(pm_intTag).Ctl Is System.Windows.Forms.TextBox
                'ﾃｷｽﾄﾎﾞｯｸｽ
                'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                F_Set_Value_NotInput = ""

                '画面より表示項目を取得
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                DspValue = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_intTag)))

                'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If DspValue <> "" Then
                    'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    F_Set_Value_NotInput = DspValue
                Else
                    'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    F_Set_Value_NotInput = pm_inpValue
                End If

            Case TypeOf pm_All.Dsp_Sub_Inf(pm_intTag).Ctl Is System.Windows.Forms.CheckBox
                'ﾁｪｯｸﾎﾞｯｸｽ
                'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                F_Set_Value_NotInput = System.Windows.Forms.CheckState.Unchecked

                '画面より表示項目を取得
                'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                DspValue = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_intTag))

                If DspValue <> System.Windows.Forms.CheckState.Unchecked Then
                    'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    F_Set_Value_NotInput = DspValue
                Else
                    'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    F_Set_Value_NotInput = pm_inpValue
                End If

        End Select



    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_Value_NotInput2
    '   概要：  変数に入力されている場合はその値を優先する
    '   引数：
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_Value_NotInput2(ByRef pm_inpValue As Object, ByRef pm_Value As Object) As Object

        Dim DspValue As Object

        'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(pm_Value) = "" Then
            'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            F_Set_Value_NotInput2 = pm_inpValue
        Else
            'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            F_Set_Value_NotInput2 = pm_Value
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Hardcopy_SSSMAIN
    '   概要：  ハードコピー画面呼出し後処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
        If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        On Error Resume Next
        System.Windows.Forms.Application.DoEvents()
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '2019/06/20 DELL START
        'FR_SSSMAIN.PrintForm()
        '2019/06/20 DELL END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
        If Err.Number <> 0 Then
            If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        End If
        On Error GoTo 0
        AE_Hardcopy_SSSMAIN = Cn_CuCurrent
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_Def_Body_Inf
    '   概要：  画面ボディ情報設定
    '   引数：　pm_All     : 画面情報
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_Def_Body_Inf(ByRef pm_All As Cls_All) As Short

        Dim Bd_Col_Index As Short
        Dim Index_Wk As Short

        '初期画面ボディ情報設定
        Call CF_Init_Set_Body_Inf(pm_All)

        If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
            '明細行が存在する場合

            '画面ボディの列分の配列定義
            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
            '初期状態
            pm_All.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT

            '初期化用設定
            '画面ボディの列分の配列定義
            ReDim Preserve pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
            '初期状態
            pm_All.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT

            '復元情報設定
            '列分の復元行の配列定義
            ReDim Preserve pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
            '初期状態
            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT

            '画面ボディ情報の配列０番目に列情報を定義する
            For Bd_Col_Index = 1 To pm_All.Dsp_Base.Body_Col_Cnt
                '画面ボディ情報
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail

                '初期化用情報
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)

                '復元情報
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
            Next

        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Edi_Dsp_Def
    '   概要：  初期時の画面編集
    '   引数：　pm_All     : 画面情報
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Edi_Dsp_Def(ByRef pm_All As Cls_All) As Short
        Dim Index_Wk As Short
        Dim Mst_Inf As TYPE_DB_MEIMTA

        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Index_Wk = CShort(FR_SSSMAIN.SYSDT.Tag)
        '画面日付
        '    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now(), "YYYY/MM/DD"), pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_APPENDC_Click
    '   概要：  画面初期化制御
    '   引数：　pm_All     : 画面情報
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_MN_APPENDC_Click(ByRef pm_All As Cls_All) As Short

        '画面明細情報設定
        Call F_Init_Def_Body_Inf(pm_All)

        '画面内容初期化
        Call F_Init_Clr_Dsp(-1, pm_All)

        '入力担当者編集
        Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, pm_All)

        '画面ボディ部初期化
        Call F_Init_Clr_Dsp_Body(-1, pm_All)

        '初期表示編集
        Call F_Edi_Dsp_Def(pm_All)

        '画面明細表示
        Call CF_Body_Dsp(pm_All)

        gv_bolInit = True

        '初期ﾌｫｰｶｽ位置設定
        Call F_Init_Cursor_Set(pm_All)

        gv_bolInit = False

        '画面変更なしとする
        gv_bolUODET51_INIT = False
        gv_bolUODET51_INIT_MITNO = False
        gv_bolUODET51_LF_Enable = True

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Init_BodyOnly
    '   概要：  明細部のみ初期化制御
    '   引数：　pm_All     : 画面情報
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Init_BodyOnly(ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Mst_Inf_YSN As TYPE_DB_YSNTRA
        Dim Mst_Inf_TOK As TYPE_DB_TOKMTA
        Dim Mst_Inf_NHS As TYPE_DB_NHSMTA
        Dim Mst_Inf_MEI As TYPE_DB_MEIMTA
        Dim intRet As Short
        Dim Dsp_Value As Object
        Dim intCnt As Short
        Dim Focus_Ctl As Boolean

        gv_bolInit = True

        '画面明細情報設定
        Call F_Init_Def_Body_Inf(pm_All)

        '画面ボディ部初期化
        Call F_Init_Clr_Dsp_Body(-1, pm_All)

        '画面明細表示
        Call CF_Body_Dsp(pm_All)

        '出庫理由クリア
        Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

        '出庫理由名称クリア
        Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

        '参照受注番号クリア
        Trg_Index = CShort(FR_SSSMAIN.HD_JDNNO.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)

        '製番クリア
        Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
        'ADD START FKS)INABA 2006/12/02***********************************************
        '倉庫コードクリア
        Trg_Index = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
        '倉庫名クリア
        Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
        Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
        'ADD START FKS)INABA 2006/12/02***********************************************

        'テイル部クリア
        For intCnt = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
            Call F_Init_Clr_Dsp(intCnt, pm_All)
        Next

        '与信限度額再編集
        With IDOET52_SBNTRA_Inf

            '変数クリア
            .NHSCD = "" '納入先コード
            .TOKADA = "" '得意先住所
            .TOKADB = "" '得意先住所
            .TOKADC = "" '得意先住所
            .NHSNMA = "" '納入先名１
            .NHSNMB = "" '納入先名２
            .NHSADA = "" '納入先住所１
            .NHSADB = "" '納入先住所２
            .NHSADC = "" '納入先住所３

            '得意先関連情報再編集
            If DSPTOKCD_SEARCH(.TOKCD, Mst_Inf_TOK) = 0 Then
                If Mst_Inf_TOK.DATKB = gc_strDATKB_USE Then
                    .NHSCD = Mst_Inf_TOK.MAINHSCD '納入先コード
                    .TOKADA = Mst_Inf_TOK.TOKADA '得意先住所
                    .TOKADB = Mst_Inf_TOK.TOKADB '得意先住所
                    .TOKADC = Mst_Inf_TOK.TOKADC '得意先住所
                End If

                '納入先関連情報取得
                If DSPNHSCD_SEARCH(.NHSCD, Mst_Inf_NHS) = 0 Then
                    If Mst_Inf_NHS.DATKB = gc_strDATKB_USE Then
                        .NHSNMA = Mst_Inf_NHS.NHSNMA '納入先名１
                        .NHSNMB = Mst_Inf_NHS.NHSNMB '納入先名２
                        .NHSADA = Mst_Inf_NHS.NHSADA '納入先住所１
                        .NHSADB = Mst_Inf_NHS.NHSADB '納入先住所２
                        .NHSADC = Mst_Inf_NHS.NHSADC '納入先住所３
                    End If
                End If

                '画面編集
                ''H.Y.(9/24)S            '【納入先コード】
                ''            Trg_Index = CInt(FR_SSSMAIN.HD_NHSCD.Tag)
                ''            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                ''            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                ''
                ''            '【納入先名１】
                ''            Trg_Index = CInt(FR_SSSMAIN.HD_NHSNMA.Tag)
                ''            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                ''            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                ''
                ''            '【納入先名２】
                ''            Trg_Index = CInt(FR_SSSMAIN.HD_NHSNMB.Tag)
                ''            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.NHSNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
                ''H.Y.(9/24)E            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

            End If
        End With

        '１行目のボディ部を準備最終行として開放する
        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW

        'ﾌｫｰｶｽ位置設定
        '割当ｲﾝﾃﾞｯｸｽ取得
        Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)

        'ﾌｫｰｶｽ移動
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '選択状態の設定（初期選択）
        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
        '項目色設定
        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

        gv_bolInit = False

        '画面変更なしとする
        gv_bolUODET51_INIT = False
        gv_bolUODET51_INIT_MITNO = False
        gv_bolUODET51_LF_Enable = True

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_HINMTB
    '   概要：  倉庫別在庫マスタ検索処理
    '   引数：　pm_intRow  : 対象行番号
    '           pm_All     : 画面情報
    '   戻値：　在庫数
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Get_HINMTB(ByRef pin_intRow As Short, ByRef pm_All As Cls_All) As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSQL As String
        Dim strSOUCD As String
        Dim strHINCD As String
        Dim Wk_Col As Short

        F_Get_HINMTB = 0

        '倉庫コード取得
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSOUCD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_SOUCD.Tag))))
        '製品コード取得
        '画面項目情報(pm_All.Dsp_Sub_Inf)のの列番号を取得
        Wk_Col = CF_Get_Col_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_HINCD(0).Tag)), pin_intRow, pm_All)
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strHINCD = Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(Wk_Col).Dsp_Value)

        strSQL = ""
        strSQL = strSQL & " Select  "
        strSQL = strSQL & "        RELZAISU " '現在庫数
        strSQL = strSQL & "   From HINMTB "
        strSQL = strSQL & "  Where "
        strSQL = strSQL & "        DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and SOUCD     = '" & CF_Ora_String(strSOUCD, 3) & "' "
        strSQL = strSQL & "    and HINCD     = '" & CF_Ora_String(strHINCD, 10) & "' "

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/24 CHG END

        '取得データ退避
        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    F_Get_HINMTB = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
        'End If
        If dt.Rows.Count < 0 Then
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            F_Get_HINMTB = DB_NullReplace(dt.Rows(0)("RELZAISU"), 0)
        End If
        '2019/06/24 CHG END

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_JDNTHA_AKNID
    '   概要：  担当者コードより部門検索処理
    '   引数：　pm_strAKNID : チェック対象案件ID
    '           pm_All      : 画面情報
    '   戻値：  0 : 取得データ有　1 : 該当データ無し  9 : 異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Get_JDNTHA_AKNID(ByRef pm_strAKNID As String, ByRef pm_All As Cls_All) As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSQL As String

        F_Get_JDNTHA_AKNID = 9

        strSQL = ""
        strSQL = strSQL & " Select  "
        strSQL = strSQL & "        AKNID " '案件ID
        strSQL = strSQL & "   From JDNTHA "
        strSQL = strSQL & "  Where "
        strSQL = strSQL & "        DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and AKNID     = '" & CF_Ora_String(pm_strAKNID, 8) & "' "

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        ''取得データ退避
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    F_Get_JDNTHA_AKNID = 0
        'Else
        '    F_Get_JDNTHA_AKNID = 1
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        '取得データ退避
        If dt.Rows.Count > 0 Then
            F_Get_JDNTHA_AKNID = 0
        Else
            F_Get_JDNTHA_AKNID = 1
        End If
        '2019/06/24 CHG END

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_HINCD
    '   概要：  商品コード検索処理（バージョン考慮あり）
    '   引数：　pm_strHINCD    : 検索対象商品コード
    '           pm_strJANCD    : 検索対象JANコード
    '           pm_strHINMLID  : 検索対象通販製品ID
    '           pm_strHINNMA   : 検索対象型式
    '           pm_strPRCKB    : 取込種別
    '   戻値：　0:正常 1:該当データ無し 9:異常
    '   備考：  注文情報取込時に対象製品の一番古いバージョンを取得する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Get_HINCD(ByRef pm_strHINCD As String, ByVal pm_strJANCD As String, ByVal pm_strHINMLID As String, ByVal pm_strHINNMA As String, ByVal pm_strPRCKB As String) As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSQL As String
        Dim strHINCD As String

        F_Get_HINCD = 9
        strHINCD = ""

        If Trim(pm_strHINCD) = "" Then
            '製品コード未設定の場合、商品マスタを検索して推測する。

            If Trim(pm_strPRCKB) = gc_strPRCKB_TUHAN Then
                '通販製品ＩＤ使用
                strSQL = ""
                strSQL = strSQL & " SELECT HINCD "
                strSQL = strSQL & "   FROM HINMTA "
                strSQL = strSQL & "  WHERE HINCD = ( "
                strSQL = strSQL & "                  SELECT MIN(HINCD) "
                strSQL = strSQL & "                    FROM HINMTA "
                strSQL = strSQL & "                   WHERE MLOHINID = '" & pm_strHINMLID & "' "
                strSQL = strSQL & "                     AND DATKB    = '" & gc_strDATKB_USE & "' "
                strSQL = strSQL & "                     AND JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
                strSQL = strSQL & "                 ) "

            Else
                '型式、ＪＡＮ使用
                strSQL = ""
                strSQL = strSQL & " SELECT HINCD "
                strSQL = strSQL & "   FROM HINMTA "
                strSQL = strSQL & "  WHERE HINCD = ( "
                strSQL = strSQL & "                  SELECT MIN(HINCD) "
                strSQL = strSQL & "                    FROM HINMTA "
                '            strSQL = strSQL & "                   WHERE (HINNMA   = '" & CF_Ora_String(pm_strHINNMA, 50) & "' "
                '            strSQL = strSQL & "                      OR  JANCD    = '" & CF_Ora_String(pm_strJANCD, 13) & "') "
                strSQL = strSQL & "                   WHERE (HINNMA   = '" & Trim(pm_strHINNMA) & "' "
                strSQL = strSQL & "                      OR  JANCD    = '" & Trim(pm_strJANCD) & "') "
                strSQL = strSQL & "                     AND DATKB    = '" & gc_strDATKB_USE & "' "
                strSQL = strSQL & "                     AND JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
                strSQL = strSQL & "                 ) "

            End If
        Else

            strSQL = ""
            strSQL = strSQL & " Select  "
            strSQL = strSQL & "        HINCD " '商品コード
            strSQL = strSQL & "   From HINMTA "
            strSQL = strSQL & "  Where HINCD = ("
            strSQL = strSQL & "                 SELECT MIN(HINCD) "
            strSQL = strSQL & "                 FROM   HINMTA "
            strSQL = strSQL & "                 WHERE  HINCD LIKE '" & CF_Ora_Sgl(Trim(pm_strHINCD)) & "%' "
            strSQL = strSQL & "                 AND    DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "                 AND    JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
            strSQL = strSQL & "                )"
        End If

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        ''取得データ退避
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strHINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")
        'Else
        '    F_Get_HINCD = 1
        '    GoTo F_Get_HINCD_END
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        '取得データ退避
        If dt.Rows.Count > 0 Then
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strHINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "")
        Else
            F_Get_HINCD = 1
            GoTo F_Get_HINCD_END
        End If
        '2019/06/24 CHG END

        '変数編集
        pm_strHINCD = strHINCD

        F_Get_HINCD = 0

F_Get_HINCD_END:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

    End Function

    ' === 20060730 === INSERT S - ACE)Nagasawa
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_FIXMTA
    '   概要：  固定値マスタ検索処理
    '   引数：　なし
    '   戻値：　0:正常  9:異常
    '   備考：  固定値マスタより運送ＬＴと大口受注の比率を取得する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Get_FIXMTA() As Short

        Dim Mst_Inf_FIXMTA As TYPE_DB_FIXMTA

        F_Get_FIXMTA = 9

        '変数初期化
        intODNYTLT = 0
        curJDOSURT = 0
        intODNYTLT_ORD = 0
        ' === 20061127 === INSERT S - ACE)Nagasawa 諸口の製品コードの入力制限を設ける
        gv_strCTLCD_HINCD_H = ""
        gv_strCTLCD_HINCD_J = ""
        gv_strCTLCD_HINCD_K = ""
        ' === 20061127 === INSERT E -
        ' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
        intZIPCD_KETA = 0
        intZIPCD_HAIHUN = 0
        intTLFAX_KETA = 0
        intTLFAX_HAIHUN = 0
        intTLFAX_LSTNUM = 0
        ' === 20061223 === INSERT E -
        ' 注文情報取込時には納入先コード(EDI連携用)を使用
        strNHSCD_ORD_INIT = ""

        '運送LT取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_ODNYTLT, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                If IsNumeric(Mst_Inf_FIXMTA.FIXVAL) = True Then
                    intODNYTLT = CShort(Mst_Inf_FIXMTA.FIXVAL) * (-1)
                End If
            End If
        End If

        '大口受注の比率取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_JDOSURT, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                If IsNumeric(Mst_Inf_FIXMTA.FIXVAL) = True Then
                    curJDOSURT = CDec(Mst_Inf_FIXMTA.FIXVAL)
                End If
            End If
        End If

        '運送LT(注文情報用)取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_ODNYTLT_ORD, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                If IsNumeric(Mst_Inf_FIXMTA.FIXVAL) = True Then
                    intODNYTLT_ORD = CShort(Mst_Inf_FIXMTA.FIXVAL) * (-1)
                End If
            End If
        End If

        ' 注文情報取込時には納入先コード(EDI連携用)を使用
        '納入先コード(注文情報用)取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_NHSCD_EDI, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                strNHSCD_ORD_INIT = Mst_Inf_FIXMTA.FIXVAL
            End If
        End If

        ' === 20061127 === INSERT S -
        '購買品諸口コード取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_HINCD_K, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                gv_strCTLCD_HINCD_K = Trim(Mst_Inf_FIXMTA.FIXVAL)
            End If
        End If
        ' === 20061127 === INSERT E -

        ' === 20061223 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
        '郵便番号桁数取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_ZIPCD_KETA, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                intZIPCD_KETA = CShort(Trim(Mst_Inf_FIXMTA.FIXVAL))
            End If
        End If

        '郵便番号ハイフン位置取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_ZIPCD_HAIHUN, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                intZIPCD_HAIHUN = CShort(Trim(Mst_Inf_FIXMTA.FIXVAL))
            End If
        End If

        '電話番号/FAX番号桁数取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_TELFAX_KETA, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                intTLFAX_KETA = CShort(Trim(Mst_Inf_FIXMTA.FIXVAL))
            End If
        End If

        '電話番号/FAX番号ハイフン数取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_TELFAX_HAIHUN, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                intTLFAX_HAIHUN = CShort(Trim(Mst_Inf_FIXMTA.FIXVAL))
            End If
        End If

        '電話番号/FAX番号最終数値部分桁数取得
        '2019/06/20 CHG START
        'Call DB_FIXMTA_Clear(Mst_Inf_FIXMTA)
        Call InitDataCommon("FIXMTA")
        '2019/06/20 CHG END'

        If DSPCTLCD_SEARCH(gc_strCTLCD_TELFAX_LSTKETA, Mst_Inf_FIXMTA) = 0 Then
            If Mst_Inf_FIXMTA.DATKB = gc_strDATKB_USE Then
                intTLFAX_LSTNUM = CShort(Trim(Mst_Inf_FIXMTA.FIXVAL))
            End If
        End If
        ' === 20061223 === INSERT E -

        F_Get_FIXMTA = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Reset_ErrStatus
    '   概要：  エラー状態初期化
    '   引数：　なし
    '   戻値：　0:正常  11:異常
    '   備考：  対象外のコントロールについては初期化を行わない
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Reset_ErrStatus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short

        Dim Ret_Value As Short

        F_Reset_ErrStatus = 9

        Ret_Value = CHK_OK

        With FR_SSSMAIN
            Select Case pm_Dsp_Sub_Inf.Ctl.Name
                'いちおう、ヘッダ部、ボディ部、テイル部は分けておく
                'D            Case .HD_SOUCD.NAME
                'D                '通貨区分、倉庫コード
                'D                pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
                'D

                Case .HD_BUMCD.Name
                    '部門コード
                    pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = ""

                Case Else
                    '対象が「○○○」の場合

            End Select
        End With

        F_Reset_ErrStatus = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Add_BlankRow
    '   概要：  空白行情報追加
    '   引数：　pm_Value              :設定値
    '           pm_All                :全構造体
    '   戻値：　必要ページ数
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_Add_BlankRow(ByRef pm_All As Cls_All) As Short

        Dim Ret_Value As Short
        Dim intPage As Short
        Dim bolFind As Boolean
        Dim intBfrUBound As Short
        Dim intAfrUBound As Short
        Dim intIdx As Short

        Ret_Value = 0

        '初期化
        intBfrUBound = UBound(pm_All.Dsp_Body_Inf.Row_Inf)

        'データ件数が表示明細数未満か否かで、Redim後の上限を決定する
        If intBfrUBound < pm_All.Dsp_Base.Dsp_Body_Cnt Then
            intAfrUBound = pm_All.Dsp_Base.Dsp_Body_Cnt
        Else
            intAfrUBound = intBfrUBound + (pm_All.Dsp_Base.Dsp_Body_Cnt - 1)
        End If

        '最大行オーバーの考慮
        If intAfrUBound > pm_All.Dsp_Base.Max_Body_Cnt Then
            intAfrUBound = pm_All.Dsp_Base.Max_Body_Cnt
        End If

        '空白行情報を追加
        If intAfrUBound > intBfrUBound Then
            '行追加
            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intAfrUBound)
            For intIdx = intBfrUBound + 1 To intAfrUBound
                '行項目情報コピー
                Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
                '明細行初期化
                Call F_Init_Dsp_Body(intIdx, pm_All)
            Next intIdx
        End If

        F_Ctl_Add_BlankRow = Ret_Value

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Set_JDNTRKB_Array
    '   概要：  使用可能受注取区退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Set_JDNTRKB_Array() As Short

        Erase strArr_JDNTRKB
        ReDim strArr_JDNTRKB(1)

        strArr_JDNTRKB(0) = gc_strJDNTRKB_SYS
        strArr_JDNTRKB(1) = gc_strJDNTRKB_SET

    End Function
    'CHG FKS)INABA 2006/11/20 全面改修（バックアップはF_DSPJDNTRA_SEARCH_bkに保存）
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSPJDNTRA_SEARCH
    '   概要：  JDNTRA検索
    '   引数：　pin_strJDNNO_LINNO          :受注番号（行番号付き）
    '           pot_DB_JDNTRA　　　　 :JDNTRAレコード
    '           pin_strDATKB 　　　　 :伝票削除区分（Optional、渡されない場合"1"）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_DSPJDNTRA_SEARCH(ByVal pin_strJDNNO_LINNO As Object, ByRef pot_DB_JDNTRA As TYPE_DB_JDNTRA, ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPJDNTRA_SEARCH

        F_DSPJDNTRA_SEARCH = 9
        strSQL = ""
        strSQL = strSQL & " SELECT "
        strSQL = strSQL & "    JR.DATNO     JR_DATNO "
        strSQL = strSQL & "   ,JR.DATKB     JR_DATKB "
        strSQL = strSQL & "   ,JR.AKAKROKB  JR_AKAKROKB "
        strSQL = strSQL & "   ,JR.DENKB     JR_DENKB "
        strSQL = strSQL & "   ,JR.JDNNO     JR_JDNNO "
        strSQL = strSQL & "   ,JR.LINNO     JR_LINNO "
        strSQL = strSQL & "   ,JR.RECNO     JR_RECNO "
        strSQL = strSQL & "   ,JR.JDNKB     JR_JDNKB "
        strSQL = strSQL & "   ,JR.JHDNO     JR_JHDNO "
        strSQL = strSQL & "   ,JR.JDNDT     JR_JDNDT "
        strSQL = strSQL & "   ,JR.DENDT     JR_DENDT "
        strSQL = strSQL & "   ,JR.DEFNOKDT  JR_DEFNOKDT "
        strSQL = strSQL & "   ,JR.TOKCD     JR_TOKCD "
        strSQL = strSQL & "   ,JR.NHSCD     JR_NHSCD "
        strSQL = strSQL & "   ,JR.TANCD     JR_TANCD "
        strSQL = strSQL & "   ,JR.BUMCD     JR_BUMCD "
        strSQL = strSQL & "   ,JR.TOKSEICD  JR_TOKSEICD "
        strSQL = strSQL & "   ,JR.SOUCD     JR_SOUCD "
        strSQL = strSQL & "   ,JR.ZKTKB     JR_ZKTKB "
        strSQL = strSQL & "   ,JR.SMADT     JR_SMADT "
        strSQL = strSQL & "   ,JR.HINCD     JR_HINCD "
        strSQL = strSQL & "   ,JR.HINNMA    JR_HINNMA "
        strSQL = strSQL & "   ,JR.HINNMB    JR_HINNMB "
        strSQL = strSQL & "   ,JR.UODSU     JR_UODSU "
        strSQL = strSQL & "   ,JR.UNTCD     JR_UNTCD "
        strSQL = strSQL & "   ,JR.UNTNM     JR_UNTNM "
        strSQL = strSQL & "   ,JR.UODTK     JR_UODTK "
        strSQL = strSQL & "   ,JR.UODKN     JR_UODKN "
        strSQL = strSQL & "   ,JR.SIKTK     JR_SIKTK "
        strSQL = strSQL & "   ,JR.SIKKN     JR_SIKKN "
        strSQL = strSQL & "   ,JR.TEIKATK   JR_TEIKATK "
        strSQL = strSQL & "   ,JR.SIKRT     JR_SIKRT "
        strSQL = strSQL & "   ,JR.KONSIKRT  JR_KONSIKRT "
        strSQL = strSQL & "   ,JR.ZAIKB     JR_ZAIKB "
        strSQL = strSQL & "   ,JR.LINCMA    JR_LINCMA "
        strSQL = strSQL & "   ,JR.LINCMB    JR_LINCMB "
        strSQL = strSQL & "   ,JR.LSTID     JR_LSTID "
        strSQL = strSQL & "   ,JR.HINZEIKB  JR_HINZEIKB "
        strSQL = strSQL & "   ,JR.ZEIRT     JR_ZEIRT "
        strSQL = strSQL & "   ,JR.UZEKN     JR_UZEKN "
        strSQL = strSQL & "   ,JR.ZEIRNKKB  JR_ZEIRNKKB "
        strSQL = strSQL & "   ,JR.HINNMMKB  JR_HINNMMKB "
        strSQL = strSQL & "   ,JR.MAKCD     JR_MAKCD "
        strSQL = strSQL & "   ,JR.HINKB     JR_HINKB "
        strSQL = strSQL & "   ,JR.HRTDD     JR_HRTDD "
        strSQL = strSQL & "   ,JR.ORTDD     JR_ORTDD "
        strSQL = strSQL & "   ,JR.TOKMSTKB  JR_TOKMSTKB "
        strSQL = strSQL & "   ,JR.NHSMSTKB  JR_NHSMSTKB "
        strSQL = strSQL & "   ,JR.TANMSTKB  JR_TANMSTKB "
        strSQL = strSQL & "   ,JR.HINMSTKB  JR_HINMSTKB "
        strSQL = strSQL & "   ,JR.ODNYTDT   JR_ODNYTDT "
        strSQL = strSQL & "   ,JR.UDNYTDT   JR_UDNYTDT "
        strSQL = strSQL & "   ,JR.TNKKB     JR_TNKKB "
        strSQL = strSQL & "   ,JR.GNKCD     JR_GNKCD "
        strSQL = strSQL & "   ,JR.CLMDL     JR_CLMDL "
        strSQL = strSQL & "   ,JR.HINGRP    JR_HINGRP "
        strSQL = strSQL & "   ,JR.ATZHIKSU  JR_ATZHIKSU "
        strSQL = strSQL & "   ,JR.ATNHIKSU  JR_ATNHIKSU "
        strSQL = strSQL & "   ,JR.MNZHIKSU  JR_MNZHIKSU "
        strSQL = strSQL & "   ,JR.MNNHIKSU  JR_MNNHIKSU "
        strSQL = strSQL & "   ,JR.TUKKB     JR_TUKKB "
        strSQL = strSQL & "   ,JR.RATERT    JR_RATERT "
        strSQL = strSQL & "   ,JR.FRCTK     JR_FRCTK "
        strSQL = strSQL & "   ,JR.FRCKN     JR_FRCKN "
        strSQL = strSQL & "   ,JR.FRCTEITK  JR_FRCTEITK "
        strSQL = strSQL & "   ,JR.HSTJDNNO  JR_HSTJDNNO "
        strSQL = strSQL & "   ,JR.TOKJDNNO  JR_TOKJDNNO "
        strSQL = strSQL & "   ,JR.TOKJDNED  JR_TOKJDNED "
        strSQL = strSQL & "   ,JR.MAKNM     JR_MAKNM "
        strSQL = strSQL & "   ,JR.SBNNO     JR_SBNNO "
        strSQL = strSQL & "   ,JR.JDNDELDT  JR_JDNDELDT "
        strSQL = strSQL & "   ,JR.FDNDT     JR_FDNDT "
        strSQL = strSQL & "   ,JR.FRDSU     JR_FRDSU "
        strSQL = strSQL & "   ,JR.ODNDT     JR_ODNDT "
        strSQL = strSQL & "   ,JR.OTPSU     JR_OTPSU "
        strSQL = strSQL & "   ,JR.UDNDT     JR_UDNDT "
        strSQL = strSQL & "   ,JR.URISU     JR_URISU "
        strSQL = strSQL & "   ,JR.URIKN     JR_URIKN "
        strSQL = strSQL & "   ,JR.FURIKN    JR_FURIKN "
        strSQL = strSQL & "   ,JR.URISIKKN  JR_URISIKKN "
        strSQL = strSQL & "   ,JR.NYUDT     JR_NYUDT "
        strSQL = strSQL & "   ,JR.NYUKN     JR_NYUKN "
        strSQL = strSQL & "   ,JR.FNYUKN    JR_FNYUKN "
        strSQL = strSQL & "   ,JR.NYUKB     JR_NYUKB "
        strSQL = strSQL & "   ,JR.INVNO     JR_INVNO "
        strSQL = strSQL & "   ,JR.FRNMOVSU  JR_FRNMOVSU "
        strSQL = strSQL & "   ,JR.TOKDNKB   JR_TOKDNKB "
        strSQL = strSQL & "   ,JR.ZAIRNK    JR_ZAIRNK "
        strSQL = strSQL & "   ,JR.PUDLNO    JR_PUDLNO "
        strSQL = strSQL & "   ,JR.MOTDATNO  JR_MOTDATNO "
        strSQL = strSQL & "   ,JR.FOPEID    JR_FOPEID "
        strSQL = strSQL & "   ,JR.FCLTID    JR_FCLTID "
        strSQL = strSQL & "   ,JR.WRTFSTTM  JR_WRTFSTTM "
        strSQL = strSQL & "   ,JR.WRTFSTDT  JR_WRTFSTDT "
        strSQL = strSQL & "   ,JR.OPEID     JR_OPEID "
        strSQL = strSQL & "   ,JR.CLTID     JR_CLTID "
        strSQL = strSQL & "   ,JR.WRTTM     JR_WRTTM "
        strSQL = strSQL & "   ,JR.WRTDT     JR_WRTDT "
        strSQL = strSQL & "   ,JR.UOPEID    JR_UOPEID "
        strSQL = strSQL & "   ,JR.UCLTID    JR_UCLTID "
        strSQL = strSQL & "   ,JR.UWRTTM    JR_UWRTTM "
        strSQL = strSQL & "   ,JR.UWRTDT    JR_UWRTDT "
        strSQL = strSQL & "   ,JR.PGID      JR_PGID "
        strSQL = strSQL & "   ,JR.DLFLG     JR_DLFLG "
        strSQL = strSQL & "   ,JH.TOKCD     JH_TOKCD " '得意先コード（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.TOKRN     JH_TOKRN " '得意先略名（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSCD     JH_NHSCD " '納入先コード（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSNMA    JH_NHSNMA " '納入先名称１（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSNMB    JH_NHSNMB " '納入先名称２（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSADA    JH_NHSADA " '納入先住所１（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSADB    JH_NHSADB " '納入先住所２（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.NHSADC    JH_NHSADC " '納入先住所３（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.BINCD     JH_BINCD  " '便名コード（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.REGDT     JH_REGDT  " '初回受注日付（受注見出しトラン情報）
        strSQL = strSQL & "   ,JH.BUMCD     JH_BUMCD  " '部門コード（受注見出しトラン情報）
        strSQL = strSQL & "   FROM JDNTRA JR "
        strSQL = strSQL & "       ,JDNTHA JH "
        strSQL = strSQL & "   WHERE JR.DATKB = " & "'" & pin_strDATKB & "'"
        'UPGRADE_WARNING: オブジェクト pin_strJDNNO_LINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     AND JR.JDNNO = " & "'" & Left(pin_strJDNNO_LINNO, 6) & "'"
        'UPGRADE_WARNING: オブジェクト pin_strJDNNO_LINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     AND JR.LINNO = " & "'" & "0" & Right(pin_strJDNNO_LINNO, 2) & "'"
        strSQL = strSQL & "     AND JR.DATNO = JH.DATNO "
        strSQL = strSQL & "     AND JH.DATKB = " & "'" & pin_strDATKB & "'"


        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    '取得データなし
        '    F_DSPJDNTRA_SEARCH = 1
        '    Exit Function
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '取得データなし
            F_DSPJDNTRA_SEARCH = 1
            Exit Function
        End If
        '2019/06/24 CHG END
        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_JDNTRA
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATNO = CF_Ora_GetDyn(Usr_Ody, "JR_DATNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "JR_DATKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .AKAKROKB = CF_Ora_GetDyn(Usr_Ody, "JR_AKAKROKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DENKB = CF_Ora_GetDyn(Usr_Ody, "JR_DENKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JR_JDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINNO = CF_Ora_GetDyn(Usr_Ody, "JR_LINNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RECNO = CF_Ora_GetDyn(Usr_Ody, "JR_RECNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNKB = CF_Ora_GetDyn(Usr_Ody, "JR_JDNKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JR_JHDNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JR_JDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DENDT = CF_Ora_GetDyn(Usr_Ody, "JR_DENDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "JR_DEFNOKDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKCD = CF_Ora_GetDyn(Usr_Ody, "JR_TOKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "JR_NHSCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TANCD = CF_Ora_GetDyn(Usr_Ody, "JR_TANCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .BUMCD = CF_Ora_GetDyn(Usr_Ody, "JR_BUMCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "JR_TOKSEICD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "JR_SOUCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "JR_ZKTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMADT = CF_Ora_GetDyn(Usr_Ody, "JR_SMADT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCD = CF_Ora_GetDyn(Usr_Ody, "JR_HINCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMA = CF_Ora_GetDyn(Usr_Ody, "JR_HINNMA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMB = CF_Ora_GetDyn(Usr_Ody, "JR_HINNMB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "JR_UODSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UNTCD = CF_Ora_GetDyn(Usr_Ody, "JR_UNTCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UNTNM = CF_Ora_GetDyn(Usr_Ody, "JR_UNTNM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODTK = CF_Ora_GetDyn(Usr_Ody, "JR_UODTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "JR_UODKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKTK = CF_Ora_GetDyn(Usr_Ody, "JR_SIKTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "JR_SIKKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "JR_TEIKATK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKRT = CF_Ora_GetDyn(Usr_Ody, "JR_SIKRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .KONSIKRT = CF_Ora_GetDyn(Usr_Ody, "JR_KONSIKRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "JR_ZAIKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINCMA = CF_Ora_GetDyn(Usr_Ody, "JR_LINCMA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINCMB = CF_Ora_GetDyn(Usr_Ody, "JR_LINCMB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LSTID = CF_Ora_GetDyn(Usr_Ody, "JR_LSTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "JR_HINZEIKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "JR_ZEIRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UZEKN = CF_Ora_GetDyn(Usr_Ody, "JR_UZEKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "JR_ZEIRNKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "JR_HINNMMKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MAKCD = CF_Ora_GetDyn(Usr_Ody, "JR_MAKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINKB = CF_Ora_GetDyn(Usr_Ody, "JR_HINKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HRTDD = CF_Ora_GetDyn(Usr_Ody, "JR_HRTDD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ORTDD = CF_Ora_GetDyn(Usr_Ody, "JR_ORTDD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "JR_TOKMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "JR_NHSMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "JR_TANMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "JR_HINMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ODNYTDT = CF_Ora_GetDyn(Usr_Ody, "JR_ODNYTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UDNYTDT = CF_Ora_GetDyn(Usr_Ody, "JR_UDNYTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TNKKB = CF_Ora_GetDyn(Usr_Ody, "JR_TNKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .GNKCD = CF_Ora_GetDyn(Usr_Ody, "JR_GNKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLMDL = CF_Ora_GetDyn(Usr_Ody, "JR_CLMDL", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINGRP = CF_Ora_GetDyn(Usr_Ody, "JR_HINGRP", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ATZHIKSU = CF_Ora_GetDyn(Usr_Ody, "JR_ATZHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ATNHIKSU = CF_Ora_GetDyn(Usr_Ody, "JR_ATNHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MNZHIKSU = CF_Ora_GetDyn(Usr_Ody, "JR_MNZHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MNNHIKSU = CF_Ora_GetDyn(Usr_Ody, "JR_MNNHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TUKKB = CF_Ora_GetDyn(Usr_Ody, "JR_TUKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RATERT = CF_Ora_GetDyn(Usr_Ody, "JR_RATERT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCTK = CF_Ora_GetDyn(Usr_Ody, "JR_FRCTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCKN = CF_Ora_GetDyn(Usr_Ody, "JR_FRCKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCTEITK = CF_Ora_GetDyn(Usr_Ody, "JR_FRCTEITK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HSTJDNNO = CF_Ora_GetDyn(Usr_Ody, "JR_HSTJDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "JR_TOKJDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKJDNED = CF_Ora_GetDyn(Usr_Ody, "JR_TOKJDNED", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MAKNM = CF_Ora_GetDyn(Usr_Ody, "JR_MAKNM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SBNNO = CF_Ora_GetDyn(Usr_Ody, "JR_SBNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNDELDT = CF_Ora_GetDyn(Usr_Ody, "JR_JDNDELDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FDNDT = CF_Ora_GetDyn(Usr_Ody, "JR_FDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRDSU = CF_Ora_GetDyn(Usr_Ody, "JR_FRDSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ODNDT = CF_Ora_GetDyn(Usr_Ody, "JR_ODNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OTPSU = CF_Ora_GetDyn(Usr_Ody, "JR_OTPSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UDNDT = CF_Ora_GetDyn(Usr_Ody, "JR_UDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URISU = CF_Ora_GetDyn(Usr_Ody, "JR_URISU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URIKN = CF_Ora_GetDyn(Usr_Ody, "JR_URIKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FURIKN = CF_Ora_GetDyn(Usr_Ody, "JR_FURIKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URISIKKN = CF_Ora_GetDyn(Usr_Ody, "JR_URISIKKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUDT = CF_Ora_GetDyn(Usr_Ody, "JR_NYUDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUKN = CF_Ora_GetDyn(Usr_Ody, "JR_NYUKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FNYUKN = CF_Ora_GetDyn(Usr_Ody, "JR_FNYUKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUKB = CF_Ora_GetDyn(Usr_Ody, "JR_NYUKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .INVNO = CF_Ora_GetDyn(Usr_Ody, "JR_INVNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRNMOVSU = CF_Ora_GetDyn(Usr_Ody, "JR_FRNMOVSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "JR_TOKDNKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "JR_ZAIRNK", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .PUDLNO = CF_Ora_GetDyn(Usr_Ody, "JR_PUDLNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MOTDATNO = CF_Ora_GetDyn(Usr_Ody, "JR_MOTDATNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FOPEID = CF_Ora_GetDyn(Usr_Ody, "JR_FOPEID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FCLTID = CF_Ora_GetDyn(Usr_Ody, "JR_FCLTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "JR_WRTFSTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "JR_WRTFSTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "JR_OPEID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "JR_CLTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "JR_WRTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "JR_WRTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UOPEID = CF_Ora_GetDyn(Usr_Ody, "JR_UOPEID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UCLTID = CF_Ora_GetDyn(Usr_Ody, "JR_UCLTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UWRTTM = CF_Ora_GetDyn(Usr_Ody, "JR_UWRTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UWRTDT = CF_Ora_GetDyn(Usr_Ody, "JR_UWRTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .PGID = CF_Ora_GetDyn(Usr_Ody, "JR_PGID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DLFLG = CF_Ora_GetDyn(Usr_Ody, "JR_DLFLG", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.TOKCD = CF_Ora_GetDyn(Usr_Ody, "JH_TOKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.TOKRN = CF_Ora_GetDyn(Usr_Ody, "JH_TOKRN", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSCD = CF_Ora_GetDyn(Usr_Ody, "JH_NHSCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSNMA = CF_Ora_GetDyn(Usr_Ody, "JH_NHSNMA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSNMB = CF_Ora_GetDyn(Usr_Ody, "JH_NHSNMB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSADA = CF_Ora_GetDyn(Usr_Ody, "JH_NHSADA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSADB = CF_Ora_GetDyn(Usr_Ody, "JH_NHSADB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.NHSADC = CF_Ora_GetDyn(Usr_Ody, "JH_NHSADC", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.BINCD = CF_Ora_GetDyn(Usr_Ody, "JH_BINCD", "")
        '        'ADD START FKS)INABA 2007/01/11 ***************************************************
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.REGDT = CF_Ora_GetDyn(Usr_Ody, "JH_REGDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        pot_DB_JDNTHA.BUMCD = CF_Ora_GetDyn(Usr_Ody, "JH_BUMCD", "")
        '        'ADD  END  FKS)INABA 2007/01/11 ***************************************************
        '    End With
        'End If
        With pot_DB_JDNTRA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATNO = DB_NullReplace(dt.Rows(0)("JR_DATNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(dt.Rows(0)("JR_DATKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .AKAKROKB = DB_NullReplace(dt.Rows(0)("JR_AKAKROKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DENKB = DB_NullReplace(dt.Rows(0)("JR_DENKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNNO = DB_NullReplace(dt.Rows(0)("JR_JDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINNO = DB_NullReplace(dt.Rows(0)("JR_LINNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RECNO = DB_NullReplace(dt.Rows(0)("JR_RECNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNKB = DB_NullReplace(dt.Rows(0)("JR_JDNKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JHDNO = DB_NullReplace(dt.Rows(0)("JR_JHDNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNDT = DB_NullReplace(dt.Rows(0)("JR_JDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DENDT = DB_NullReplace(dt.Rows(0)("JR_DENDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DEFNOKDT = DB_NullReplace(dt.Rows(0)("JR_DEFNOKDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKCD = DB_NullReplace(dt.Rows(0)("JR_TOKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCD = DB_NullReplace(dt.Rows(0)("JR_NHSCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TANCD = DB_NullReplace(dt.Rows(0)("JR_TANCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BUMCD = DB_NullReplace(dt.Rows(0)("JR_BUMCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKSEICD = DB_NullReplace(dt.Rows(0)("JR_TOKSEICD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUCD = DB_NullReplace(dt.Rows(0)("JR_SOUCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZKTKB = DB_NullReplace(dt.Rows(0)("JR_ZKTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMADT = DB_NullReplace(dt.Rows(0)("JR_SMADT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCD = DB_NullReplace(dt.Rows(0)("JR_HINCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMA = DB_NullReplace(dt.Rows(0)("JR_HINNMA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMB = DB_NullReplace(dt.Rows(0)("JR_HINNMB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODSU = DB_NullReplace(dt.Rows(0)("JR_UODSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UNTCD = DB_NullReplace(dt.Rows(0)("JR_UNTCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UNTNM = DB_NullReplace(dt.Rows(0)("JR_UNTNM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODTK = DB_NullReplace(dt.Rows(0)("JR_UODTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODKN = DB_NullReplace(dt.Rows(0)("JR_UODKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKTK = DB_NullReplace(dt.Rows(0)("JR_SIKTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKKN = DB_NullReplace(dt.Rows(0)("JR_SIKKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TEIKATK = DB_NullReplace(dt.Rows(0)("JR_TEIKATK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKRT = DB_NullReplace(dt.Rows(0)("JR_SIKRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .KONSIKRT = DB_NullReplace(dt.Rows(0)("JR_KONSIKRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZAIKB = DB_NullReplace(dt.Rows(0)("JR_ZAIKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINCMA = DB_NullReplace(dt.Rows(0)("JR_LINCMA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINCMB = DB_NullReplace(dt.Rows(0)("JR_LINCMB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LSTID = DB_NullReplace(dt.Rows(0)("JR_LSTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINZEIKB = DB_NullReplace(dt.Rows(0)("JR_HINZEIKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRT = DB_NullReplace(dt.Rows(0)("JR_ZEIRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UZEKN = DB_NullReplace(dt.Rows(0)("JR_UZEKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("JR_ZEIRNKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMMKB = DB_NullReplace(dt.Rows(0)("JR_HINNMMKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MAKCD = DB_NullReplace(dt.Rows(0)("JR_MAKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINKB = DB_NullReplace(dt.Rows(0)("JR_HINKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HRTDD = DB_NullReplace(dt.Rows(0)("JR_HRTDD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ORTDD = DB_NullReplace(dt.Rows(0)("JR_ORTDD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKMSTKB = DB_NullReplace(dt.Rows(0)("JR_TOKMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSMSTKB = DB_NullReplace(dt.Rows(0)("JR_NHSMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TANMSTKB = DB_NullReplace(dt.Rows(0)("JR_TANMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINMSTKB = DB_NullReplace(dt.Rows(0)("JR_HINMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ODNYTDT = DB_NullReplace(dt.Rows(0)("JR_ODNYTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNYTDT = DB_NullReplace(dt.Rows(0)("JR_UDNYTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TNKKB = DB_NullReplace(dt.Rows(0)("JR_TNKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .GNKCD = DB_NullReplace(dt.Rows(0)("JR_GNKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLMDL = DB_NullReplace(dt.Rows(0)("JR_CLMDL"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINGRP = DB_NullReplace(dt.Rows(0)("JR_HINGRP"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ATZHIKSU = DB_NullReplace(dt.Rows(0)("JR_ATZHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ATNHIKSU = DB_NullReplace(dt.Rows(0)("JR_ATNHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MNZHIKSU = DB_NullReplace(dt.Rows(0)("JR_MNZHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MNNHIKSU = DB_NullReplace(dt.Rows(0)("JR_MNNHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TUKKB = DB_NullReplace(dt.Rows(0)("JR_TUKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RATERT = DB_NullReplace(dt.Rows(0)("JR_RATERT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCTK = DB_NullReplace(dt.Rows(0)("JR_FRCTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCKN = DB_NullReplace(dt.Rows(0)("JR_FRCKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCTEITK = DB_NullReplace(dt.Rows(0)("JR_FRCTEITK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HSTJDNNO = DB_NullReplace(dt.Rows(0)("JR_HSTJDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKJDNNO = DB_NullReplace(dt.Rows(0)("JR_TOKJDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKJDNED = DB_NullReplace(dt.Rows(0)("JR_TOKJDNED"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MAKNM = DB_NullReplace(dt.Rows(0)("JR_MAKNM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SBNNO = DB_NullReplace(dt.Rows(0)("JR_SBNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNDELDT = DB_NullReplace(dt.Rows(0)("JR_JDNDELDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FDNDT = DB_NullReplace(dt.Rows(0)("JR_FDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRDSU = DB_NullReplace(dt.Rows(0)("JR_FRDSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ODNDT = DB_NullReplace(dt.Rows(0)("JR_ODNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OTPSU = DB_NullReplace(dt.Rows(0)("JR_OTPSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNDT = DB_NullReplace(dt.Rows(0)("JR_UDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URISU = DB_NullReplace(dt.Rows(0)("JR_URISU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URIKN = DB_NullReplace(dt.Rows(0)("JR_URIKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FURIKN = DB_NullReplace(dt.Rows(0)("JR_FURIKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URISIKKN = DB_NullReplace(dt.Rows(0)("JR_URISIKKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUDT = DB_NullReplace(dt.Rows(0)("JR_NYUDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKN = DB_NullReplace(dt.Rows(0)("JR_NYUKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FNYUKN = DB_NullReplace(dt.Rows(0)("JR_FNYUKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKB = DB_NullReplace(dt.Rows(0)("JR_NYUKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .INVNO = DB_NullReplace(dt.Rows(0)("JR_INVNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRNMOVSU = DB_NullReplace(dt.Rows(0)("JR_FRNMOVSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKDNKB = DB_NullReplace(dt.Rows(0)("JR_TOKDNKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZAIRNK = DB_NullReplace(dt.Rows(0)("JR_ZAIRNK"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PUDLNO = DB_NullReplace(dt.Rows(0)("JR_PUDLNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MOTDATNO = DB_NullReplace(dt.Rows(0)("JR_MOTDATNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FOPEID = DB_NullReplace(dt.Rows(0)("JR_FOPEID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FCLTID = DB_NullReplace(dt.Rows(0)("JR_FCLTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("JR_WRTFSTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("JR_WRTFSTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("JR_OPEID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("JR_CLTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("JR_WRTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("JR_WRTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UOPEID = DB_NullReplace(dt.Rows(0)("JR_UOPEID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UCLTID = DB_NullReplace(dt.Rows(0)("JR_UCLTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTTM = DB_NullReplace(dt.Rows(0)("JR_UWRTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTDT = DB_NullReplace(dt.Rows(0)("JR_UWRTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PGID = DB_NullReplace(dt.Rows(0)("JR_PGID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DLFLG = DB_NullReplace(dt.Rows(0)("JR_DLFLG"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.TOKCD = DB_NullReplace(dt.Rows(0)("JH_TOKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.TOKRN = DB_NullReplace(dt.Rows(0)("JH_TOKRN"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSCD = DB_NullReplace(dt.Rows(0)("JH_NHSCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSNMA = DB_NullReplace(dt.Rows(0)("JH_NHSNMA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSNMB = DB_NullReplace(dt.Rows(0)("JH_NHSNMB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSADA = DB_NullReplace(dt.Rows(0)("JH_NHSADA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSADB = DB_NullReplace(dt.Rows(0)("JH_NHSADB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.NHSADC = DB_NullReplace(dt.Rows(0)("JH_NHSADC"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.BINCD = DB_NullReplace(dt.Rows(0)("JH_BINCD"), "")
            'ADD START FKS)INABA 2007/01/11 ***************************************************
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.REGDT = DB_NullReplace(dt.Rows(0)("JH_REGDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_DB_JDNTHA.BUMCD = DB_NullReplace(dt.Rows(0)("JH_BUMCD"), "")
            'ADD  END  FKS)INABA 2007/01/11 ***************************************************
        End With
        '2019/06/24 CHG END

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        F_DSPJDNTRA_SEARCH = 0

        Exit Function

ERR_DSPJDNTRA_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSPJDNTRA_SEARCH_bk
    '   概要：  JDNTRA検索
    '   引数：　pin_strSBNNO          :製番
    '           pot_DB_JDNTRA　　　　 :JDNTRAレコード
    '           pin_strDATKB 　　　　 :伝票削除区分（Optional、渡されない場合"1"）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_DSPJDNTRA_SEARCH_bk(ByVal pin_strSBNNO As Object, ByRef pot_DB_JDNTRA As TYPE_DB_JDNTRA, Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPJDNTRA_SEARCH

        F_DSPJDNTRA_SEARCH_bk = 9

        strSQL = ""
        strSQL = strSQL & " select * "
        strSQL = strSQL & "   from JDNTRA "
        ''''strSQL = strSQL & "   where SBNNO = '" & pin_strSBNNO & "' "                '2006.10.19
        strSQL = strSQL & "   Where DATKB = " & "'" & pin_strDATKB & "'"
        'UPGRADE_WARNING: オブジェクト pin_strSBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     And JDNNO = " & "'" & Left(pin_strSBNNO, 6) & "'"
        'UPGRADE_WARNING: オブジェクト pin_strSBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "     And LINNO = " & "'" & "0" & Right(pin_strSBNNO, 2) & "'"

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    '取得データなし
        '    F_DSPJDNTRA_SEARCH_bk = 1
        '    Exit Function
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '取得データなし
            F_DSPJDNTRA_SEARCH_bk = 1
            Exit Function
        End If
        '2019/06/24 CHG END
        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_JDNTRA
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .AKAKROKB = CF_Ora_GetDyn(Usr_Ody, "AKAKROKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RECNO = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNKB = CF_Ora_GetDyn(Usr_Ody, "JDNKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODTK = CF_Ora_GetDyn(Usr_Ody, "UODTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKTK = CF_Ora_GetDyn(Usr_Ody, "SIKTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKKN = CF_Ora_GetDyn(Usr_Ody, "SIKKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "TEIKATK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .KONSIKRT = CF_Ora_GetDyn(Usr_Ody, "KONSIKRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "ZAIKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINCMA = CF_Ora_GetDyn(Usr_Ody, "LINCMA", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LINCMB = CF_Ora_GetDyn(Usr_Ody, "LINCMB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "HINZEIKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UZEKN = CF_Ora_GetDyn(Usr_Ody, "UZEKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "HINNMMKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MAKCD = CF_Ora_GetDyn(Usr_Ody, "MAKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINKB = CF_Ora_GetDyn(Usr_Ody, "HINKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HRTDD = CF_Ora_GetDyn(Usr_Ody, "HRTDD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ORTDD = CF_Ora_GetDyn(Usr_Ody, "ORTDD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ODNYTDT = CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UDNYTDT = CF_Ora_GetDyn(Usr_Ody, "UDNYTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TNKKB = CF_Ora_GetDyn(Usr_Ody, "TNKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .GNKCD = CF_Ora_GetDyn(Usr_Ody, "GNKCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ATZHIKSU = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ATNHIKSU = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MNZHIKSU = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MNNHIKSU = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RATERT = CF_Ora_GetDyn(Usr_Ody, "RATERT", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCTK = CF_Ora_GetDyn(Usr_Ody, "FRCTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCKN = CF_Ora_GetDyn(Usr_Ody, "FRCKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRCTEITK = CF_Ora_GetDyn(Usr_Ody, "FRCTEITK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HSTJDNNO = CF_Ora_GetDyn(Usr_Ody, "HSTJDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKJDNED = CF_Ora_GetDyn(Usr_Ody, "TOKJDNED", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MAKNM = CF_Ora_GetDyn(Usr_Ody, "MAKNM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SBNNO = CF_Ora_GetDyn(Usr_Ody, "SBNNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .JDNDELDT = CF_Ora_GetDyn(Usr_Ody, "JDNDELDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FDNDT = CF_Ora_GetDyn(Usr_Ody, "FDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRDSU = CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ODNDT = CF_Ora_GetDyn(Usr_Ody, "ODNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OTPSU = CF_Ora_GetDyn(Usr_Ody, "OTPSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .UDNDT = CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URISU = CF_Ora_GetDyn(Usr_Ody, "URISU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URIKN = CF_Ora_GetDyn(Usr_Ody, "URIKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FURIKN = CF_Ora_GetDyn(Usr_Ody, "FURIKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .URISIKKN = CF_Ora_GetDyn(Usr_Ody, "URISIKKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUDT = CF_Ora_GetDyn(Usr_Ody, "NYUDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUKN = CF_Ora_GetDyn(Usr_Ody, "NYUKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FNYUKN = CF_Ora_GetDyn(Usr_Ody, "FNYUKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .INVNO = CF_Ora_GetDyn(Usr_Ody, "INVNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRNMOVSU = CF_Ora_GetDyn(Usr_Ody, "FRNMOVSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "TOKDNKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "ZAIRNK", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .MOTDATNO = CF_Ora_GetDyn(Usr_Ody, "MOTDATNO", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
        '    End With
        'End If
        With pot_DB_JDNTRA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .AKAKROKB = DB_NullReplace(dt.Rows(0)("AKAKROKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DENKB = DB_NullReplace(dt.Rows(0)("DENKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNNO = DB_NullReplace(dt.Rows(0)("JDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINNO = DB_NullReplace(dt.Rows(0)("LINNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RECNO = DB_NullReplace(dt.Rows(0)("RECNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNKB = DB_NullReplace(dt.Rows(0)("JDNKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JHDNO = DB_NullReplace(dt.Rows(0)("JHDNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNDT = DB_NullReplace(dt.Rows(0)("JDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DENDT = DB_NullReplace(dt.Rows(0)("DENDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DEFNOKDT = DB_NullReplace(dt.Rows(0)("DEFNOKDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKCD = DB_NullReplace(dt.Rows(0)("TOKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCD = DB_NullReplace(dt.Rows(0)("NHSCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TANCD = DB_NullReplace(dt.Rows(0)("TANCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BUMCD = DB_NullReplace(dt.Rows(0)("BUMCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKSEICD = DB_NullReplace(dt.Rows(0)("TOKSEICD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZKTKB = DB_NullReplace(dt.Rows(0)("ZKTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMADT = DB_NullReplace(dt.Rows(0)("SMADT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODSU = DB_NullReplace(dt.Rows(0)("UODSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODTK = DB_NullReplace(dt.Rows(0)("UODTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UODKN = DB_NullReplace(dt.Rows(0)("UODKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKTK = DB_NullReplace(dt.Rows(0)("SIKTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKKN = DB_NullReplace(dt.Rows(0)("SIKKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TEIKATK = DB_NullReplace(dt.Rows(0)("TEIKATK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SIKRT = DB_NullReplace(dt.Rows(0)("SIKRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .KONSIKRT = DB_NullReplace(dt.Rows(0)("KONSIKRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZAIKB = DB_NullReplace(dt.Rows(0)("ZAIKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINCMA = DB_NullReplace(dt.Rows(0)("LINCMA"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LINCMB = DB_NullReplace(dt.Rows(0)("LINCMB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .LSTID = DB_NullReplace(dt.Rows(0)("LSTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINZEIKB = DB_NullReplace(dt.Rows(0)("HINZEIKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UZEKN = DB_NullReplace(dt.Rows(0)("UZEKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINNMMKB = DB_NullReplace(dt.Rows(0)("HINNMMKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MAKCD = DB_NullReplace(dt.Rows(0)("MAKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINKB = DB_NullReplace(dt.Rows(0)("HINKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HRTDD = DB_NullReplace(dt.Rows(0)("HRTDD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ORTDD = DB_NullReplace(dt.Rows(0)("ORTDD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKMSTKB = DB_NullReplace(dt.Rows(0)("TOKMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSMSTKB = DB_NullReplace(dt.Rows(0)("NHSMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TANMSTKB = DB_NullReplace(dt.Rows(0)("TANMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ODNYTDT = DB_NullReplace(dt.Rows(0)("ODNYTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNYTDT = DB_NullReplace(dt.Rows(0)("UDNYTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TNKKB = DB_NullReplace(dt.Rows(0)("TNKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .GNKCD = DB_NullReplace(dt.Rows(0)("GNKCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLMDL = DB_NullReplace(dt.Rows(0)("CLMDL"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINGRP = DB_NullReplace(dt.Rows(0)("HINGRP"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ATZHIKSU = DB_NullReplace(dt.Rows(0)("ATZHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ATNHIKSU = DB_NullReplace(dt.Rows(0)("ATNHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MNZHIKSU = DB_NullReplace(dt.Rows(0)("MNZHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MNNHIKSU = DB_NullReplace(dt.Rows(0)("MNNHIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TUKKB = DB_NullReplace(dt.Rows(0)("TUKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RATERT = DB_NullReplace(dt.Rows(0)("RATERT"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCTK = DB_NullReplace(dt.Rows(0)("FRCTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCKN = DB_NullReplace(dt.Rows(0)("FRCKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRCTEITK = DB_NullReplace(dt.Rows(0)("FRCTEITK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HSTJDNNO = DB_NullReplace(dt.Rows(0)("HSTJDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKJDNNO = DB_NullReplace(dt.Rows(0)("TOKJDNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKJDNED = DB_NullReplace(dt.Rows(0)("TOKJDNED"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MAKNM = DB_NullReplace(dt.Rows(0)("MAKNM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SBNNO = DB_NullReplace(dt.Rows(0)("SBNNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .JDNDELDT = DB_NullReplace(dt.Rows(0)("JDNDELDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FDNDT = DB_NullReplace(dt.Rows(0)("FDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRDSU = DB_NullReplace(dt.Rows(0)("FRDSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ODNDT = DB_NullReplace(dt.Rows(0)("ODNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OTPSU = DB_NullReplace(dt.Rows(0)("OTPSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UDNDT = DB_NullReplace(dt.Rows(0)("UDNDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URISU = DB_NullReplace(dt.Rows(0)("URISU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URIKN = DB_NullReplace(dt.Rows(0)("URIKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FURIKN = DB_NullReplace(dt.Rows(0)("FURIKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .URISIKKN = DB_NullReplace(dt.Rows(0)("URISIKKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUDT = DB_NullReplace(dt.Rows(0)("NYUDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKN = DB_NullReplace(dt.Rows(0)("NYUKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FNYUKN = DB_NullReplace(dt.Rows(0)("FNYUKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NYUKB = DB_NullReplace(dt.Rows(0)("NYUKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .INVNO = DB_NullReplace(dt.Rows(0)("INVNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRNMOVSU = DB_NullReplace(dt.Rows(0)("FRNMOVSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .TOKDNKB = DB_NullReplace(dt.Rows(0)("TOKDNKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZAIRNK = DB_NullReplace(dt.Rows(0)("ZAIRNK"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PUDLNO = DB_NullReplace(dt.Rows(0)("PUDLNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MOTDATNO = DB_NullReplace(dt.Rows(0)("MOTDATNO"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "")
        End With
        '2019/06/24 CHG END

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        F_DSPJDNTRA_SEARCH_bk = 0

        Exit Function

ERR_DSPJDNTRA_SEARCH:

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSPSBNTRA_SEARCH
    '   概要：  SBNTRA検索
    '   引数：　pin_strDATNO          :伝票管理番号
    '   戻値：　0:正常終了 1:対象データ無し 2:出荷指示数=0 かつ 引当数<>0 3:出荷指示数<>0 9:異常終了
    '   備考：  IDOET53用。指定された伝票管理番号のSBNTRAを検索する。訂正不可データのとき
    '           メッセージを出して処理終了。訂正可能なデータならば画面にデータをセットする
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_DSPSBNTRA_SEARCH(ByVal pin_strDatNo As String, ByRef pm_All As Cls_All) As Short
        Dim strSQL As String
        Dim intFRDSU As Short ' 出荷指示数
        Dim intHIKSMSU As Short ' 引き当て済み数
        Dim intOUTSMSU As Short ' 出庫済数
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim Trg_Index As Short
        Dim Dsp_Value As Object
        Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA

        'ADD START FKS)INABA 2006/11/27 ******************************************
        Dim ls_TOKCD As String
        'ADD  END  FKS)INABA 2006/11/27 ******************************************

        On Error GoTo DSPSBNTRA_SEARCH_err

        F_DSPSBNTRA_SEARCH = 9

        strSQL = ""
        'CHG START FKS)INABA 2006/11/27 ****************************************
        strSQL = strSQL & " select SBNTRA.* ,MEIMTA.MEINMA BINNM "
        strSQL = strSQL & "   from SBNTRA "
        strSQL = strSQL & "        ,MEIMTA "
        strSQL = strSQL & "   where SBNTRA.DATNO = '" & pin_strDatNo & "' "
        strSQL = strSQL & "   And   SBNTRA.DATKB = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   And   MEIMTA.KEYCD = '002' "
        strSQL = strSQL & "   And   SBNTRA.BINCD = MEIMTA.MEICDA "
        '    strSQL = strSQL & " select * "
        '    strSQL = strSQL & "   from SBNTRA "
        '    strSQL = strSQL & "   where DATNO = '" & pin_strDatNo & "' "
        '    strSQL = strSQL & "   And   DATKB = '" & gc_strDATKB_USE & "' "
        'CNG  END  FKS)INABA 2006/11/27 ****************************************


        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/24 CHG END

        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    '取得データなし
        '    F_DSPSBNTRA_SEARCH = 1
        '    'メッセージ出力
        '    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_009, pm_All)
        '    GoTo DSPSBNTRA_SEARCH_err
        'End If

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            F_DSPSBNTRA_SEARCH = 1
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_009, pm_All)
            GoTo DSPSBNTRA_SEARCH_err
        End If

        '2019/06/24 CHG END
        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    intFRDSU = CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    intHIKSMSU = CF_Ora_GetDyn(Usr_Ody, "HIKSMSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    intOUTSMSU = CF_Ora_GetDyn(Usr_Ody, "HIKSMSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.FRDSU = CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.HIKSMSU = CF_Ora_GetDyn(Usr_Ody, "HIKSMSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.OUTSMSU = CF_Ora_GetDyn(Usr_Ody, "OUTSMSU", 0)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "")
        '    '        If intFRDSU = 0 And intHIKSMSU <> 0 Then            ' 出荷指示数=0 かつ 引当数<>0
        '    ''DEL START FKS)INABA 2007/01/27 *********************************************************
        '    ''            F_DSPSBNTRA_SEARCH = 2
        '    ''            'メッセージ出力
        '    ''            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_066, pm_All)
        '    ''
        '    ''DEL START FKS)INABA 2007/01/27 *********************************************************            GoTo DSPSBNTRA_SEARCH_err
        '    '        ElseIf intFRDSU <> 0 Then                           ' 出荷指示数<>0
        '    '            F_DSPSBNTRA_SEARCH = 3
        '    '            'メッセージ出力
        '    '            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_067, pm_All)
        '    '            GoTo DSPSBNTRA_SEARCH_err
        '    '        End If

        '    ' 伝票管理番号
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")

        '    ' 出庫日
        '    Trg_Index = CShort(FR_SSSMAIN.HD_DENDT.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "OUTYTDT", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 出庫理由コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "OUTRSNCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 出庫理由名　はSBNTRAに保存されないので、マスタから検索する(F_Ctl_CS_REF_SBN()でF_Ctl_Item_Chk()実行)
        '    ' 参照受注番号
        '    Trg_Index = CShort(FR_SSSMAIN.HD_JDNNO.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "ORGSBNNO", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    '' 参照受注番号は「チェック済み」とする。そうしないと、SBNTRAに保存されている得意先／納品先がこの参照受注番号の
        '    '' 得意先／納品先で上書きされる危険性がある。下の行はそのため。(H.Y. 9/29)
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
        '    ' 製番
        '    Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "SBNNO", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 倉庫コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "OUTSOUCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 倉庫名
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.SOUNM = CF_Ora_GetDyn(Usr_Ody, "OUTSOUNM", "")
        '    Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 送り先担当者コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_TANCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "OUTTANCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 送り先担当者名
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.TANNM = CF_Ora_GetDyn(Usr_Ody, "OUTTANNM", "")
        '    Trg_Index = CShort(FR_SSSMAIN.HD_TANNM.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TANNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 送り先部門コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "OUTBMCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 送り先部門名
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.BUMNM = CF_Ora_GetDyn(Usr_Ody, "OUTBNNM", "")
        '    Trg_Index = CShort(FR_SSSMAIN.HD_BUMNM.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 得意先コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    'ADD STRAT FKS)INABA 2006/11/27 **************************************************
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    ls_TOKCD = Trim(Dsp_Value)
        '    'ADD  END  FKS)INABA 2006/11/27 **************************************************

        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    '' 下の行は、手入力してSBNTRAに保存した住所１２３がこの得意先の住所で上書きされることを防ぐ。(H.Y. 9/29)
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
        '    ' 得意先名
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    IDOET52_SBNTRA_Inf.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")
        '    Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 納入先コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    '' 下の行は、手入力してSBNTRAに保存した住所１２３がこの納入先の住所で上書きされることを防ぐ。(H.Y. 9/29)
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
        '    ' 納入先名１
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSNMA", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 納入先名２
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSNMB", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    '電話番号
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSTL", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    '郵便番号
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSZIPCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSZP", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    'FAX番号
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSFAX.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSFX", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '    ' 住所１
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSADA", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 住所２
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSADB", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 住所３
        '    Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "NHSADC", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

        '    'ADD START FKS)INABA 2006/11/27 *********************************************************************************
        '    '便コード
        '    Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "BINCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    If Trim(ls_TOKCD) <> "" Then
        '        Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    End If
        '    '便名
        '    Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "BINNM", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    If Trim(ls_TOKCD) <> "" Then
        '        Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    End If
        '    'ADD  END  FKS)INABA 2006/11/27 *********************************************************************************
        '    ' 製品コード
        '    Trg_Index = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "HINCD", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' JANコード。画面に表示されずSBNTRAに保存もされないが、「緊急出庫」化すると必要になるので、マスタから取得しておく(H.Y. 6/29)
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If DSPHINCD_SEARCH(Dsp_Value, Mst_Inf_HINMTA) = 0 Then
        '        pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.JANCD = Mst_Inf_HINMTA.JANCD
        '    End If
        '    ' 型式
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")
        '    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 品名
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")
        '    Trg_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 数量
        '    Trg_Index = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "FRDYTSU", 0), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    'ADD STRAT FKS)INABA 2007/02/20 ******************************
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    gv_moto_su = Dsp_Value
        '    'ADD STRAT FKS)INABA 2007/02/20 ******************************

        '    ' 単位
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")
        '    Trg_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 単位コード。画面には表示されないが、SBNTRAには保存されているもの。再保存に備えて記憶しておく (F_SBNTRA_Insert() 参照)
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")
        '    ' 備考１
        '    Trg_Index = CShort(FR_SSSMAIN.BD_LINCMA(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "LINCMA", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    ' 備考２
        '    Trg_Index = CShort(FR_SSSMAIN.BD_LINCMB(1).Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "LINCMB", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    'ADD START FKS)INABA 2006/01/27 *********************************************************************************
        '    Trg_Index = CShort(FR_SSSMAIN.TL_KKOUT.Tag)
        '    'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Dsp_Value = CF_Cnv_Dsp_Item(CF_Ora_GetDyn(Usr_Ody, "EMGODNKB", ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
        '    'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If Trim(Dsp_Value) = "1" Then
        '        Call CF_Set_Item_Direct("1", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    Else
        '        Call CF_Set_Item_Direct("0", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '    End If
        '    'ADD  END  FKS)INABA 2006/01/27 *********************************************************************************


        'End If
        If dt.Rows.Count > 0 Then
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            intFRDSU = DB_NullReplace(dt.Rows(0)("FRDSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            intHIKSMSU = DB_NullReplace(dt.Rows(0)("HIKSMSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            intOUTSMSU = DB_NullReplace(dt.Rows(0)("HIKSMSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.FRDSU = DB_NullReplace(dt.Rows(0)("FRDSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.HIKSMSU = DB_NullReplace(dt.Rows(0)("HIKSMSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.OUTSMSU = DB_NullReplace(dt.Rows(0)("OUTSMSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.PUDLNO = DB_NullReplace(dt.Rows(0)("PUDLNO"), "")
            '        If intFRDSU = 0 And intHIKSMSU <> 0 Then            ' 出荷指示数=0 かつ 引当数<>0
            ''DEL START FKS)INABA 2007/01/27 *********************************************************
            ''            F_DSPSBNTRA_SEARCH = 2
            ''            'メッセージ出力
            ''            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_066, pm_All)
            ''
            ''DEL START FKS)INABA 2007/01/27 *********************************************************            GoTo DSPSBNTRA_SEARCH_err
            '        ElseIf intFRDSU <> 0 Then                           ' 出荷指示数<>0
            '            F_DSPSBNTRA_SEARCH = 3
            '            'メッセージ出力
            '            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgIDOET52_E_067, pm_All)
            '            GoTo DSPSBNTRA_SEARCH_err
            '        End If

            ' 伝票管理番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")

            ' 出庫日
            Trg_Index = CShort(FR_SSSMAIN.HD_DENDT.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("OUTYTDT"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 出庫理由コード
            Trg_Index = CShort(FR_SSSMAIN.HD_OUTRYCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("OUTRSNCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 出庫理由名　はSBNTRAに保存されないので、マスタから検索する(F_Ctl_CS_REF_SBN()でF_Ctl_Item_Chk()実行)
            ' 参照受注番号
            Trg_Index = CShort(FR_SSSMAIN.HD_JDNNO.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("ORGSBNNO"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '' 参照受注番号は「チェック済み」とする。そうしないと、SBNTRAに保存されている得意先／納品先がこの参照受注番号の
            '' 得意先／納品先で上書きされる危険性がある。下の行はそのため。(H.Y. 9/29)
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
            ' 製番
            Trg_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("SBNNO"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 倉庫コード
            Trg_Index = CShort(FR_SSSMAIN.HD_SOUCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("OUTSOUCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 倉庫名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.SOUNM = DB_NullReplace(dt.Rows(0)("OUTSOUNM"), "")
            Trg_Index = CShort(FR_SSSMAIN.HD_SOUNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 送り先担当者コード
            Trg_Index = CShort(FR_SSSMAIN.HD_TANCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("OUTTANCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 送り先担当者名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.TANNM = DB_NullReplace(dt.Rows(0)("OUTTANNM"), "")
            Trg_Index = CShort(FR_SSSMAIN.HD_TANNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TANNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 送り先部門コード
            Trg_Index = CShort(FR_SSSMAIN.HD_BUMCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("OUTBMCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 送り先部門名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.BUMNM = DB_NullReplace(dt.Rows(0)("OUTBNNM"), "")
            Trg_Index = CShort(FR_SSSMAIN.HD_BUMNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.BUMNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 得意先コード
            Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("TOKCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            'ADD STRAT FKS)INABA 2006/11/27 **************************************************
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ls_TOKCD = Trim(Dsp_Value)
            'ADD  END  FKS)INABA 2006/11/27 **************************************************

            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '' 下の行は、手入力してSBNTRAに保存した住所１２３がこの得意先の住所で上書きされることを防ぐ。(H.Y. 9/29)
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
            ' 得意先名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            IDOET52_SBNTRA_Inf.TOKRN = DB_NullReplace(dt.Rows(0)("TOKRN"), "")
            Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(IDOET52_SBNTRA_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 納入先コード
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '' 下の行は、手入力してSBNTRAに保存した住所１２３がこの納入先の住所で上書きされることを防ぐ。(H.Y. 9/29)
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Bef_Chk_Value = Dsp_Value
            ' 納入先名１
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMA.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSNMA"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 納入先名２
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSNMB.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSNMB"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '電話番号
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSTL.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSTL"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            '郵便番号
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSZIPCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSZP"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            'FAX番号
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSFAX.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSFX"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

            ' 住所１
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSADA.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSADA"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 住所２
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSADB.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSADB"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 住所３
            Trg_Index = CShort(FR_SSSMAIN.HD_NHSADC.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("NHSADC"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)

            'ADD START FKS)INABA 2006/11/27 *********************************************************************************
            '便コード
            Trg_Index = CShort(FR_SSSMAIN.HD_BINCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("BINCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            If Trim(ls_TOKCD) <> "" Then
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            End If
            '便名
            Trg_Index = CShort(FR_SSSMAIN.HD_BINNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("BINNM"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            If Trim(ls_TOKCD) <> "" Then
                Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            End If
            'ADD  END  FKS)INABA 2006/11/27 *********************************************************************************
            ' 製品コード
            Trg_Index = CShort(FR_SSSMAIN.BD_HINCD(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("HINCD"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' JANコード。画面に表示されずSBNTRAに保存もされないが、「緊急出庫」化すると必要になるので、マスタから取得しておく(H.Y. 6/29)
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If DSPHINCD_SEARCH(Dsp_Value, Mst_Inf_HINMTA) = 0 Then
                pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.JANCD = Mst_Inf_HINMTA.JANCD
            End If
            ' 型式
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "")
            Trg_Index = CShort(FR_SSSMAIN.BD_HINNMA(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 品名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "")
            Trg_Index = CShort(FR_SSSMAIN.BD_HINNMB(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 数量
            Trg_Index = CShort(FR_SSSMAIN.BD_UODSU(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("FRDYTSU"), 0), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            'ADD STRAT FKS)INABA 2007/02/20 ******************************
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            gv_moto_su = Dsp_Value
            'ADD STRAT FKS)INABA 2007/02/20 ******************************

            ' 単位
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "")
            Trg_Index = CShort(FR_SSSMAIN.BD_UNTNM(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 単位コード。画面には表示されないが、SBNTRAには保存されているもの。再保存に備えて記憶しておく (F_SBNTRA_Insert() 参照)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Body_Inf.Row_Inf(1).Bus_Inf.UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "")
            ' 備考１
            Trg_Index = CShort(FR_SSSMAIN.BD_LINCMA(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("LINCMA"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            ' 備考２
            Trg_Index = CShort(FR_SSSMAIN.BD_LINCMB(1).Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("LINCMB"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            'ADD START FKS)INABA 2006/01/27 *********************************************************************************
            Trg_Index = CShort(FR_SSSMAIN.TL_KKOUT.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(DB_NullReplace(dt.Rows(0)("EMGODNKB"), ""), pm_All.Dsp_Sub_Inf(Trg_Index), False)
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Trim(Dsp_Value) = "1" Then
                Call CF_Set_Item_Direct("1", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            Else
                Call CF_Set_Item_Direct("0", pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
            End If
            'ADD  END  FKS)INABA 2006/01/27 *********************************************************************************


        End If
        '2019/06/24 CHG END

        F_DSPSBNTRA_SEARCH = 0

DSPSBNTRA_SEARCH_end:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

DSPSBNTRA_SEARCH_err:
        GoTo DSPSBNTRA_SEARCH_end
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Chk_Relzaisu
    '   概要：  有効在庫数チェック（数量＜＝有効在庫数　かどうかを確認する）
    '   引数：　pin_strSOUCD         :倉庫コード
    '           pin_strHINCD        :品番コード
    '           pin_curSU           :数量
    'CHG START FKS)INABA 2007/01/08 ***********************************************************************
    '有効在庫数チェック仕様変更（ワーニングを表示する）
    '①現在庫数＜出庫数
    'Message：出庫数が現在庫数を超えています。
    '②現在庫数－引当済数＜出庫数
    'Message：出庫数が有効在庫数を超えています。
    '③現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
    'Message：安全在庫数を下回ります。
    'CHG START FKS)INABA 2006/11/30 ***********************************************************************
    '   戻値：　0:正常 1:在庫管理しない製品コード 2:HINMTAに無い　3:現在庫数＜出庫数
    '           4:現在庫数－引当済数＜出庫数      5:現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
    '                9:異常終了
    '    '   戻値：　0:正常 1:在庫管理しない製品コード 2:HINMTAに無い　9:異常終了
    ''    '   戻値：　0:正常（数量＜＝有効在庫数） 1:数量過大（数量＞有効在庫数） 2:HINMTBに無い　9:異常終了
    'CHG START FKS)INABA 2006/11/30 ***********************************************************************
    'CHG START FKS)INABA 2007/01/08 ***********************************************************************
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Chk_Relzaisu(ByVal pin_strSOUCE As String, ByVal pin_strHINCD As String, ByVal pin_curSU As Decimal, ByRef pm_All As Cls_All) As Short
        Dim Mst_Inf_HINMTB As TYPE_DB_HINMTB
        'ADD START FKS)INABA 2006/11/30 ************************
        Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA

        'ADD  END  FKS)INABA 2006/11/30 ************************

        On Error GoTo F_Chk_Relzaisu_err

        F_Chk_Relzaisu = 9
        'CHG START FKS)INABA 2007/01/08 *************************************************************
        'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA, CF_Ora_Date(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_DENDT.Tag)).Detail.Dsp_Value)) = 0 Then
            If Trim(Mst_Inf_HINMTA.ZAIKB) = "1" Then
                '在庫管理対象になっている場合、倉庫別在庫マスタを検索
                'ADD START FKS) INABA 2007/02/20 ************************************************************
                If F_DSPHINMTB_SEARCH(pin_strSOUCE, pin_strHINCD, Mst_Inf_HINMTB) = 0 Then
                    'ADD  END  FKS) INABA 2007/02/20 ************************************************************
                    If RunMode = RUNMODE_IDOET52 Then
                        Select Case True
                            Case Mst_Inf_HINMTB.RELZAISU < pin_curSU
                                '3:現在庫数＜出庫数の場合
                                F_Chk_Relzaisu = 3
                            Case Mst_Inf_HINMTB.RELZAISU - Mst_Inf_HINMTB.HIKSU < pin_curSU
                                '4:現在庫数－引当済数＜出庫数の場合
                                F_Chk_Relzaisu = 4
                            Case Mst_Inf_HINMTB.RELZAISU - Mst_Inf_HINMTB.HIKSU - pin_curSU < Mst_Inf_HINMTA.ANZZAISU
                                '5:現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
                                F_Chk_Relzaisu = 5
                            Case Else
                                F_Chk_Relzaisu = 0

                        End Select
                        'ADD START FKS) INABA 2007/02/20 ************************************************************
                    Else
                        Select Case True
                            Case Mst_Inf_HINMTB.RELZAISU < pin_curSU
                                '3:現在庫数＜出庫数の場合
                                F_Chk_Relzaisu = 3
                            Case Mst_Inf_HINMTB.RELZAISU + gv_moto_su - Mst_Inf_HINMTB.HIKSU < pin_curSU
                                '4:現在庫数－引当済数＜出庫数の場合
                                F_Chk_Relzaisu = 4
                            Case Mst_Inf_HINMTB.RELZAISU + gv_moto_su - Mst_Inf_HINMTB.HIKSU - pin_curSU < Mst_Inf_HINMTA.ANZZAISU
                                '5:現在庫数－引当済数－出庫数＜商品マスタ．安全在庫数
                                F_Chk_Relzaisu = 5
                            Case Else
                                F_Chk_Relzaisu = 0

                        End Select
                    End If
                    'ADD  END  FKS) INABA 2007/02/20 ************************************************************
                End If

            Else
                F_Chk_Relzaisu = 1 '在庫管理しない
            End If
        Else
            F_Chk_Relzaisu = 2 '製品マスタにない
        End If
        '    If F_DSPHINMTB_SEARCH(pin_strSOUCE, pin_strHINCD, Mst_Inf_HINMTB) = 0 Then
        '''''''''2006.11.01仕変(E-1013-112)CF101303:有効在庫とのチェックは行わない。
        '''''''''If pin_curSU <= (Mst_Inf_HINMTB.RELZAISU - Mst_Inf_HINMTB.HIKSU) Then
        '''''''''    F_Chk_Relzaisu = 0
        '''''''''Else
        '''''''''    F_Chk_Relzaisu = 1
        '''''''''End If
        '        F_Chk_Relzaisu = 0
        '    Else
        ''CHG START FKS)INABA 2006/11/30 ***********************************************************
        '        '倉庫別在庫マスタに無ければ商品マスタの在庫管理区分が管理するになっていればokとする
        '        If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA, _
        ''                CF_Ora_Date(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_DENDT.Tag).Detail.Dsp_Value)) = 0 Then
        '            If Trim$(Mst_Inf_HINMTA.ZAIKB) = "1" Then
        '                F_Chk_Relzaisu = 0
        '            Else
        '                F_Chk_Relzaisu = 1
        '            End If
        '        Else
        '            F_Chk_Relzaisu = 2
        '        End If
        ''        F_Chk_Relzaisu = 2
        ''CHG  END  FKS)INABA 2006/11/30 ***********************************************************
        '    End If
        'CHG START FKS)INABA 2007/01/08 *************************************************************

        Exit Function

F_Chk_Relzaisu_err:
        F_Chk_Relzaisu = 9
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSPHINMTB_SEARCH
    '   概要：  HINMTB検索
    '   引数：　pin_strSBNNO          :倉庫コード
    '           pin_strHINCD         :品番コード
    '           pot_DB_HINMTB　　　　 :HINMTBレコード
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_DSPHINMTB_SEARCH(ByVal pin_strSOUCD As Object, ByVal pin_strHINCD As Object, ByRef pot_DB_HINMTB As TYPE_DB_HINMTB) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPHINMTB_SEARCH

        F_DSPHINMTB_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " select * "
        strSQL = strSQL & "   from HINMTB "
        'UPGRADE_WARNING: オブジェクト pin_strSOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "   where SOUCD = '" & pin_strSOUCD & "' "
        'UPGRADE_WARNING: オブジェクト pin_strHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "   And   HINCD = '" & pin_strHINCD & "' "
        strSQL = strSQL & "   And   DATKB = '" & gc_strDATKB_USE & "' "

        'DBアクセス
        '2019/06/24 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/24 CHG END

        '2019/06/24 CHG START
        ' CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/24 CHG END
            '取得データなし
            F_DSPHINMTB_SEARCH = 1
            Exit Function
        End If

        '2019/06/24 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_HINMTB
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLAKB = CF_Ora_GetDyn(Usr_Ody, "HINCLAKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLBKB = CF_Ora_GetDyn(Usr_Ody, "HINCLBKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLCKB = CF_Ora_GetDyn(Usr_Ody, "HINCLCKB", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLAID = CF_Ora_GetDyn(Usr_Ody, "HINCLAID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLBID = CF_Ora_GetDyn(Usr_Ody, "HINCLBID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HINCLCID = CF_Ora_GetDyn(Usr_Ody, "HINCLCID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZNETNADT = CF_Ora_GetDyn(Usr_Ody, "ZNETNADT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZNETNATK = CF_Ora_GetDyn(Usr_Ody, "ZNETNATK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZNETNASU = CF_Ora_GetDyn(Usr_Ody, "ZNETNASU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZNETNAKN = CF_Ora_GetDyn(Usr_Ody, "ZNETNAKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMAZANDT = CF_Ora_GetDyn(Usr_Ody, "SMAZANDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMAZANSU = CF_Ora_GetDyn(Usr_Ody, "SMAZANSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMAZANTK = CF_Ora_GetDyn(Usr_Ody, "SMAZANTK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SMAZANKN = CF_Ora_GetDyn(Usr_Ody, "SMAZANKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELJDNSU = CF_Ora_GetDyn(Usr_Ody, "RELJDNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELHDNSU = CF_Ora_GetDyn(Usr_Ody, "RELHDNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELFDNSU = CF_Ora_GetDyn(Usr_Ody, "RELFDNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELADNSU = CF_Ora_GetDyn(Usr_Ody, "RELADNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELODNSU = CF_Ora_GetDyn(Usr_Ody, "RELODNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELIDNSU = CF_Ora_GetDyn(Usr_Ody, "RELIDNSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELAZUSU = CF_Ora_GetDyn(Usr_Ody, "RELAZUSU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FSTSTKDT = CF_Ora_GetDyn(Usr_Ody, "FSTSTKDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FSTDLVDT = CF_Ora_GetDyn(Usr_Ody, "FSTDLVDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NEWSTKDT = CF_Ora_GetDyn(Usr_Ody, "NEWSTKDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NEWDLVDT = CF_Ora_GetDyn(Usr_Ody, "NEWDLVDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRKTNADT = CF_Ora_GetDyn(Usr_Ody, "WRKTNADT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRKTNATK = CF_Ora_GetDyn(Usr_Ody, "WRKTNATK", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRKTNASU = CF_Ora_GetDyn(Usr_Ody, "WRKTNASU", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRKTNAKN = CF_Ora_GetDyn(Usr_Ody, "WRKTNAKN", 0)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
        '    End With
        'End If


        With pot_DB_HINMTB
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SISNKB = DB_NullReplace(dt.Rows(0)("SISNKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUTRICD = DB_NullReplace(dt.Rows(0)("SOUTRICD"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUKOKB = DB_NullReplace(dt.Rows(0)("SOUKOKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HIKKB = DB_NullReplace(dt.Rows(0)("HIKKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLAKB = DB_NullReplace(dt.Rows(0)("HINCLAKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLBKB = DB_NullReplace(dt.Rows(0)("HINCLBKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLCKB = DB_NullReplace(dt.Rows(0)("HINCLCKB"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLAID = DB_NullReplace(dt.Rows(0)("HINCLAID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLBID = DB_NullReplace(dt.Rows(0)("HINCLBID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HINCLCID = DB_NullReplace(dt.Rows(0)("HINCLCID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZNETNADT = DB_NullReplace(dt.Rows(0)("ZNETNADT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZNETNATK = DB_NullReplace(dt.Rows(0)("ZNETNATK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZNETNASU = DB_NullReplace(dt.Rows(0)("ZNETNASU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZNETNAKN = DB_NullReplace(dt.Rows(0)("ZNETNAKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMAZANDT = DB_NullReplace(dt.Rows(0)("SMAZANDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMAZANSU = DB_NullReplace(dt.Rows(0)("SMAZANSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMAZANTK = DB_NullReplace(dt.Rows(0)("SMAZANTK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SMAZANKN = DB_NullReplace(dt.Rows(0)("SMAZANKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELZAISU = DB_NullReplace(dt.Rows(0)("RELZAISU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HIKSU = DB_NullReplace(dt.Rows(0)("HIKSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELJDNSU = DB_NullReplace(dt.Rows(0)("RELJDNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELHDNSU = DB_NullReplace(dt.Rows(0)("RELHDNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFDNSU = DB_NullReplace(dt.Rows(0)("RELFDNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELADNSU = DB_NullReplace(dt.Rows(0)("RELADNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELODNSU = DB_NullReplace(dt.Rows(0)("RELODNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELIDNSU = DB_NullReplace(dt.Rows(0)("RELIDNSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELAZUSU = DB_NullReplace(dt.Rows(0)("RELAZUSU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FSTSTKDT = DB_NullReplace(dt.Rows(0)("FSTSTKDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FSTDLVDT = DB_NullReplace(dt.Rows(0)("FSTDLVDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NEWSTKDT = DB_NullReplace(dt.Rows(0)("NEWSTKDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NEWDLVDT = DB_NullReplace(dt.Rows(0)("NEWDLVDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRKTNADT = DB_NullReplace(dt.Rows(0)("WRKTNADT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRKTNATK = DB_NullReplace(dt.Rows(0)("WRKTNATK"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRKTNASU = DB_NullReplace(dt.Rows(0)("WRKTNASU"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRKTNAKN = DB_NullReplace(dt.Rows(0)("WRKTNAKN"), 0)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "")
        End With


        '2019/06/24 CHG END

        'クローズ
        '2019/06/24 DELL  START
        ' Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/06/20 DELL END
        F_DSPHINMTB_SEARCH = 0

        Exit Function

ERR_DSPHINMTB_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Get_SYSTBC
    '   概要：  SYSTBC採番マスタ取得
    '   引数：  pin_strDKBSB : キー
    '           pin_strDENNO : 値
    '   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Get_SYSTBC(ByVal Pin_strDKBSB As Object, ByRef pin_strDENNO As String) As Short

        Static strSQL As String
        'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Static usrOdy As U_Ody
        Static bolRet As Boolean
        Static bolTran As Boolean
        Static curDENNO As Decimal
        Static curSTTNO As Decimal
        Static curENDNO As Decimal
        Static strADDDENCD As String
        Static strNewDENNO As String

        On Error GoTo F_Get_SYSTBC_err

        F_Get_SYSTBC = 9

        bolTran = False

        'トランザクション開始
        '2019/06/21 CHG START
        ' Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/06/21 CHG END
        bolTran = True

        'ユーザー伝票№テーブル取得
        strSQL = ""
        strSQL = strSQL & " Select *             "
        strSQL = strSQL & "   from SYSTBC        "
        'UPGRADE_WARNING: オブジェクト Pin_strDKBSB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSQL = strSQL & "  Where DKBSB    = '" & Pin_strDKBSB & "' "
        strSQL = strSQL & "    for Update NoWait "

        'SQL実行
        '2019/06/24 CHG START
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
        'If bolRet = False Then
        '    GoTo F_Get_SYSTBC_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count > 0 Then
            GoTo F_Get_SYSTBC_err
        End If
        '2019/06/24 CHG END

        'EOF判定
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            F_Get_SYSTBC = 1
            GoTo F_Get_SYSTBC_err
        End If

        '伝票付属コード取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strADDDENCD = Trim(DB_NullReplace(dt.Rows(0)("ADDDENCD"), ""))

        '開始伝票No取得
        If IsNumeric(DB_NullReplace(dt.Rows(0)("STTNO"), "")) = False Then
            curSTTNO = 1
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            curSTTNO = CDec(DB_NullReplace(dt.Rows(0)("STTNO"), 0))
        End If

        '終了伝票No取得
        If IsNumeric(DB_NullReplace(dt.Rows(0)("ENDNO"), "")) = False Then
            curENDNO = 1
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            curENDNO = CDec(DB_NullReplace(dt.Rows(0)("ENDNO"), 0))
        End If

        '伝票NO.取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        curDENNO = CDec(DB_NullReplace(dt.Rows(0)("DENNO"), "0")) + 1
        If curDENNO > curENDNO Then
            '終了伝票NOを超えた場合は戻る
            curDENNO = curSTTNO
        End If

        strNewDENNO = VB6.Format(curDENNO, New String("0", 8))
        pin_strDENNO = strADDDENCD & strNewDENNO
        curDENNO = curDENNO + 1
        If curDENNO > curENDNO Then
            '終了伝票Noを超えた場合は戻る
            curDENNO = curSTTNO
        End If

        'SYSTBCテーブル更新
        'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        usrOdy.Obj_Ody.Edit()
        'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        usrOdy.Obj_Ody.Fields("DENNO").Value = strNewDENNO
        If Trim(GV_SysTime) <> "" Then
            'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
        Else
            'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
        End If
        If Trim(GV_SysDate) <> "" Then
            'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
        Else
            'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
        End If
        'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        usrOdy.Obj_Ody.Update()

        bolRet = CF_Ora_CloseDyn(usrOdy)
        If bolRet = False Then
            GoTo F_Get_SYSTBC_err
        End If

        'コミット
        '2019/06/21 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/06/21 CHG END
        bolTran = False

        F_Get_SYSTBC = 0

EXIT_F_Get_SYSTBC:
        Exit Function

F_Get_SYSTBC_err:

        If gv_Int_OraErr = 54 Then
            '他で使用中
            F_Get_SYSTBC = 2
        End If

        If bolTran = True Then
            'ロールバック
            '2019/06/21 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/06/21 CHG END
        End If

        GoTo EXIT_F_Get_SYSTBC

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub F_Reset_IDOET52_TYPE_SBNTRA_All
    '   概要：  IDOET52_TYPE_SBNTRA構造体の全フィールドリセット
    '   引数：
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub F_Reset_IDOET52_TYPE_SBNTRA_All(ByRef r As IDOET52_TYPE_SBNTRA)
        r.DENDT = "" 'String'受注日付
        r.TOKCD = "" 'String'得意先コード
        r.TOKRN = "" 'String'得意先略称
        r.NHSCD = "" 'String'納入先コード
        r.NHSNMA = "" 'String'納入先名称１
        r.NHSNMB = "" 'String'納入先名称２
        r.TANCD = "" 'String'担当者コード
        r.TANNM = "" 'String'担当者名
        r.BUMCD = "" 'String'部門コード
        r.BUMNM = "" 'String'部門名
        r.SOUCD = "" 'String'倉庫コード
        r.SOUNM = "" 'String'倉庫名
        r.SOUBSCD = "" 'String'場所コード
        r.KKOUT = 0 'Integer'緊急出庫（チェック時=1,オフ時=0）
        r.TOKADA = "" 'String'得意先住所１
        r.TOKADB = "" 'String'得意先住所２
        r.TOKADC = "" 'String'得意先住所３
        r.NHSADA = "" 'String'納入先住所１
        r.NHSADB = "" 'String'納入先住所２
        r.NHSADC = "" 'String'納入先住所３
        r.SBNNO = "" 'String'製番
        r.OUTRYCD = "" 'String'出庫理由コード
        r.OUTRYNM = "" 'String'出庫理由名
        r.OUTRYKB1 = "" 'String'出庫理由区分１
        r.OUTRYKB2 = "" 'String'出庫理由区分２
        r.OUTRYKB3 = "" 'String'出庫理由区分３
        r.OUTKB = "" 'String'出庫区分(->SBNTRA)

        r.DATNO = "" 'String'伝票管理番号
        'ADD START FKS)INABA 2006/11/21 *********************************************************
        r.BINCD = "" '便名コード
        r.BINNM = "" '便名
        '    r.HINCD = ""
        '    r.HINNMA = ""
        '    r.HINNMB = ""
        '    r.UODSU = ""
        '    r.UNTNM = ""
        '    r.LINCMA = ""
        '    r.LINCMB = ""
        '
        'ADD  END  FKS)INABA 2006/11/21 *********************************************************
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub F_Reset_IDOET52_TYPE_SBNTRA_OutRy
    '   概要：  IDOET52_TYPE_SBNTRA構造体の出庫理由情報のみリセット
    '   引数：
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub F_Reset_IDOET52_TYPE_SBNTRA_OutRy(ByRef r As IDOET52_TYPE_SBNTRA)
        r.OUTRYCD = ""
        r.OUTRYNM = ""
        r.OUTRYKB1 = ""
        r.OUTRYKB2 = ""
        r.OUTRYKB3 = ""
        r.OUTKB = ""
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub F_Reset_IDOET52_TYPE_SBNTRA_Sou
    '   概要：  IDOET52_TYPE_SBNTRA構造体の倉庫情報のみリセット
    '   引数：
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub F_Reset_IDOET52_TYPE_SBNTRA_Sou(ByRef r As IDOET52_TYPE_SBNTRA)
        '    r.SOUCD = ""
        r.SOUNM = ""
        r.SOUBSCD = ""

    End Sub

    ' @(f) GP_GetIni
    '
    ' 機能      :汎用INIファイル書込サブルーチン
    '
    ' 返り値    : String
    '
    ' 引き数    :strIniName INIファイルの名前（拡張子は不要）
    '            strAppName INIファイル内のアプリケーション名
    '　　　　　　keyname　　INIファイル内のキー名
    '
    Function GP_GetIni(ByVal strIniName As String, ByVal strAppName As String, ByVal strKeyName As String) As String

        Dim strTxt As New VB6.FixedLengthString(255)
        Dim lngLen As Integer

        GP_GetIni = ""

        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(strIniName) = "" Then
            MsgBox("対象のINIファイルが存在しません。" & vbCrLf & "[" & strIniName & "]", MsgBoxStyle.Critical, "INIファイル読込エラー")
            Exit Function
        End If

        '<< データPATHを取得 >>
        lngLen = GetPrivateProfileString(strAppName, strKeyName, "", strTxt.Value, 255, strIniName)

        On Error GoTo Error_Routine

        GP_GetIni = P_GetIniItem(AnsiLeftB(strTxt.Value, lngLen))

        Exit Function

Error_Routine:
        '*MsgBox "指定したキーのエントリが存在しません。" & vbCrLf & "[" & strIniName & "]" & vbCrLf & "アプリケーション：" & strAppName & vbCrLf & "キー：" & strKeyName, vbCritical, "INIファイル読込エラー"
    End Function

    Function P_GetIniItem(ByVal strData As String) As String

        Dim strWk As String
        Dim strDummy As String
        Dim lngInstr As Integer
        Dim lngInstrRev As Integer

        lngInstr = 0

        'イニファイルの";"以降はコメントなので、コメントを省く。
        'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/06/21 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/06/21 CHG END
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/06/21 CHG START
            'strWk = MidB(strData, 1, InStrB(strData, ";") - 1)
            strWk = MidB(strData, 1, InStr(strData, ";") - 1)
            '2019/06/21 CHG END
        Else
            strWk = strData
        End If

        lngInstr = 0
        lngInstrRev = 0

        'strWK=""及び、strWK=""""の場合はコメント行。
        If strWk <> "" And strWk <> """" Then
            'シングルコーテーションで囲んだ中の文字のみ取得したいので、
            'シングルコーテーションの文字位置を取得する。
            lngInstr = InStr(strWk, """")
            lngInstrRev = InStrRev(strWk, """")
            'strWkの中にシングルコーテーションが含まれているか判断する。
            If lngInstr <> lngInstrRev Then
                'シングルコーテーションが含まれていた場合。
                'シングルコーテーションで囲んだ中の文字のみ取得する。
                strDummy = Mid(strWk, lngInstr + 1, lngInstrRev - lngInstr - 1)

                If strDummy <> "" Then
                    '戻り値のセット。
                    P_GetIniItem = Trim(strDummy)
                End If
            Else
                'シングルコーテーションが含まれていない場合。
                If Trim(strWk) <> "" Then
                    '戻り値のセット
                    P_GetIniItem = Trim(strWk)
                End If
            End If
        Else
            P_GetIniItem = ""
        End If

    End Function

    Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/21 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/0621 CHG END
    End Function

    Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/06/21 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/06/21 CHG END
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(StrArg)
#End If
    End Function

    ' StrConv を呼び出します。
    Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
        'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If

    End Function

    '2019/06/21 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_IN_TANCD
    '   概要：  入力担当者編集
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '入力担当者コード
            'UPGRADE_ISSUE: Control HD_IN_TANCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '入力担当者名
            'UPGRADE_ISSUE: Control HD_IN_TANNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '2091/06/21 ADD END

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

End Module