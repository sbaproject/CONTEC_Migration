Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    '//* All Right Reserved Copy Right (C)  株式会社富士通関西システムズ
    '//***************************************************************************************
    '//*
    '//*＜名称＞
    '//* URKET53 入金消込
    '//*
    '//*＜バージョン＞
    '//* 1.00
    '//*
    '//*＜作成者＞
    '//* FKS)
    '//*
    '//*＜説明＞
    '//* 入金消込の入力画面
    '//*
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付    | 更新者        |内容
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 1.00     |          |FKS)           |新規作成Template12
    '//*          |2008/07/25|FKS)中田       |明細が2行以上ある受注に対し、返品登録を行った後
    '//*          |          |               |受注訂正を行うと本来出力対象にあらないデータが
    '//*          |          |               |画面上に出てきてしまうのを修正
    '//*          |2008/08/05|FKS)中田       |入力された消込日以降の売上データを出力しないよう修正
    '//*          |2008/08/13|FKS)中田       |分納された売上に対する赤黒チェックの修正・追加
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 2.00     |2008/08/22|RISE)宮島      |入金関連の処理見直しにおける修正
    '//* 2.01     |2008/09/22|RISE)宮島      |
    '//* 2.02     |2008/10/08|RISE)宮島      |
    '//* 2.03     |2008/10/14|RISE)宮島      |返品不具合対応
    '//* 2.04     |2008/10/17|RISE)宮島      |現状プログラムの障害反映（連絡票№:664）
    '//* 2.05     |2008/10/23|RISE)宮島      |得意先の名称が正式名称が表示されているが本来なら略称を表示する
    '//* 2.06     |2008/11/04|RISE)森田      |①チェック関連見直し
    '//           |          |               |②日付を削除できるように変更
    '//* 2.07     |2008/11/05|RISE)森田      |①入金消込トランへの更新について変更
    '//           |          |               |②消し込み順序の変更
    '//           |          |               |③消し込み方法の変更
    '//* 2.09     |2008/12/04|RISE)森田      |消込処理に前月入金消込残額がマイナスの場合の処理追加
    '//* 2.10     |2008/12/09|RISE)森田      |検索SQL 変更
    '//* 2.11     |2008/12/12|RISE)宮島      |検索SQL 変更（入金日消込日も検索条件に入れていたので前月以前が表示されない）
    '//* 2.12     |2009/01/09|RISE)森田      |非表示列が表示されてしまっているので修正
    '//* 2.13     |2009/01/21|RISE)宮島      |明細部分の振込期日の入力チェックを行う
    '//*          |          |               |差額入力画面で勘定口座が置き換わってしまう
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 3.00     |2009/03/10|FKS)中田       |返品登録を行った受注に対し単価訂正を行った場合、旧単価とその時の返品レコードを出力しないよう修正
    '//* 3.01     |2009/03/19|RISE)宮島      |差額入金登録の画面にて、実行時エラーが起こる。
    '//* 3.02     |2009/03/19|RISE)宮島      |画面ラベル項目にカーソルが遷移できる。（画面にピクチャーボックスを貼り付けて制御を行う）
    '//* 3.10     |2009/03/19|RISE)宮島      |・振込期日変更処理は、消込取消⇒再消込の処理（※現行仕様）とする。
    '//* 3.10     |2009/03/19|RISE)宮島      |・入金種別混在時、消込みの優先順位は以下の順番とする。
    '//*          |          |               |  ①相殺→②消費税→③手数料→④現金→⑤振込→⑥手形→⑦振込仮→⑧値引き→⑨他
    '//* 3.10     |2009/03/19|RISE)宮島      |・入金消込残額がマイナスになる場合、強制的にゼロとしない。
    '//* 3.10     |2009/03/19|RISE)宮島      |・入金種別に「手形」「振込期日（ファクタリング）」がある場合、振込期日
    '//*          |          |               |  は入力可能とする。複数金種混在時は、入力分につき「手形」「期日
    '//*          |          |               |　振込（ファクタリング）」行のみ有効とする。
    '//* 3.20     |2009/03/24|RISE)宮島      |・本入金に振替え時、入金額を現金に変更する必要性につき、入金消込
    '//*          |          |               |  と整合性が取れているか確認が必要｡
    '//* 3.30     |2009/06/12|FKS)中田       |・差額入金サブ画面を起動後、明細行にてチェックが入っているものを
    '//*          |          |　　　　　　　 |　消込可能額にも反映させる
    '//* 3.40     |2009/07/17|FKS)中田       |・返品時の更新用インデックスの取得ロジックの修正
    '//* 3.50     |2009/08/07|FKS)中田       |・返品時の不具合修正　(RISE)宮島殿指示分)
    '//* 　　　　 |          |               |・入金消込更新の準備処理（消込金額配列戻し）
    '//* 3.60     |2009/08/26|FKS)中田       |・返品時の不具合修正　(RISE)宮島殿指示分)
    '//* 3.70     |2009/09/03|RISE)宮島      |・返品データは期間指定に関係なく常時画面表示される仕様になっている
    '//*          |          |               |・入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
    '//*          |          |               |・製番抜取済データの入金消込取消を行った場合、エラーが表示されるか。
    '//*          |          |               |・未請求分のデータ画面表示について「対応なし」の回答だが問題ありそうである。
    '//*          |          |               |・入金登録時、担当者が営業担当であることのチェックも必要
    '//*          |2009/09/08|RISE)宮島      |・返品データは期間指定内にペアで存在しない場合は表示しないようにする
    '//*          |          |               |・返品データの消込は金種単位ではなく１レコードで消しこむ
    '//*          |2009/09/10|RISE)宮島      |・レスポンス対応と完了している赤黒ペアは表示しない
    '//*          |2009/09/15|RISE)宮島      |・返品時の消し込み方法の変更
    '//*          |          |               |・入金消込サマリーの本入金項目に対して何も更新しないようにする
    '//*          |          |               |・前月解除時の入金消込サマリーの戻し先変更（入金→消込）
    '//*          |          |               |・売上の請求締日＞得意先の請求締日の時金額が変更されていたらエラー
    '//*          |2009/09/18|RISE)宮島      |・手数料、消費税の取り扱い変更対応
    '//*          |2009/09/23|RISE)宮島      |・手形の消し込みの時に手形期日項目が更新されない
    '//*          |2009/09/24|RISE)宮島      |・差額画面より復帰時残額が正しく表示されない
    '//*          |2009/09/27|RISE)宮島      |・『請求締め月以降の明細を表示しない』は止める
    '//*          |          |               |・『売上の請求締日＞得意先の請求締日の時金額が変更されていたらエラー』は止める
    '//*          |          |               |・振込期日のロック制御を行う
    '//*          |          |               |・画面表示レスポンスの改善（振込期日の入手方法の変更）
    '//*          |2009/09/29|RISE)宮島      |・明細9999を超えた場合にエラーメッセージを表示しヘッダーに戻る
    '//*          |2009/10/01|RISE)宮島      |・チェック時得意先マスタの支払条件SHAKB[256]のみ振込期日が表示されるようになっていたが
    '//*          |          |               |　ヘッダーの振込期日が入力されている場合に表示する
    '//*          |2009/10/01|RISE)宮島      |・入金種別(03手形)の場合、期日到来時現金化する
    '//*          |2009/10/06|RISE)宮島      |・消し込み時消し込み金額を減額すると消し込み解除されるが減額された金額のレコードが作成されない
    '//*          |2009/10/22|RISE)宮島      |・差額入金画面で入金額を入力してきた時に金額が正しく表示されない
    '//*          |2009/10/22|RISE)宮島      |・消込時、残額と不一致の消し込みが発生した場合エラーを表示する
    '//*          |2009/11/02|RISE)宮島      |・入金消込画面（差額入金登録）の振込期日の設定方法変更
    '//*          |2009/11/02|RISE)宮島      |・一部消込時で振込期日が設定されている場合の入金消込トランの振込期日の設定方法変更
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 4.00     |2010/07/21|FKS)山本       |画面の表示内容をCSVに出力するボタンを追加
    '//* 4.01     |2010/09/28|FKS)山本       |未消込の返品がある消込済みデータであっても単価訂正されていたら表示しない
    '//* 4.02     |2010/10/19|FKS)山本       |返品の赤黒チェックと返品後、受注訂正処理の赤黒チェックのパラメータにTOKSEICDを追加
    '//* 4.03     |2011/06/13|FKS)山本       |返品後、受注訂正処理の赤黒チェックのパラメータにDATNOを追加
    '//**************************************************************************************

    Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
    Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    連絡票№CF10042801
    Private Declare Function IsDBCSLeadByte Lib "kernel32" (ByVal TestChar As Byte) As Boolean
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    Dim intUrigoukei As Decimal '売上金額の合計を格納（明細表示時にセット）
    Dim intBfkesiknkei As Decimal '消込済額(締日前)の合計額を格納（明細表示時にセット）

    '// V3.10↓ UPD
    'Dim blnFriEnabled   As Boolean      '振込期日を入力できるかどうかのフラグ(判定は請求先選択時)
    Dim blnFriEnabled As Boolean '振込期日を入力できるかどうかのフラグ(判定は「手形」「振込期日（ファクタリング）」が存在する時）
    '// V3.10↑ UPD

    Dim blnUsableSpread As Boolean 'ｽﾌﾟﾚｯﾄﾞのｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
    Dim intMaxRow As Short 'ｽﾌﾟﾚｯﾄﾞの表示最大行数を格納

    Dim blnUsableButton As Boolean '手数料、消費税差額、全消込、全解除、再表示、振込期日(明細部)のｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
    Dim intChkKb As Short 'チェック区分(1:チェック 2:チェック(前回から変更時のみ)
    Dim blnUsableEvent As Boolean 'ｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ(汎用)
    Dim blnINIT_FLG As Boolean

    '// V2.00↓ ADD
    Dim intInputMode As Short '入力状態(1:ヘッダー 2:明細 9:画面クリアー処理)
    '// V2.00↑ ADD


    '2008/07/30 DEL START FKS)NAKATA
    'XX '2007/12/05 FKS)minamoto ADD START
    'XX Private HAITA_UDNTRA()      As TYPE_HAITA_UPDDT
    'XX Private HAITA_JDNTRA()      As TYPE_HAITA_UPDDT
    '2007/12/05 FKS)minamoto ADD END
    '2008/07/30 DEL START FKS)NAKATA


    '2008/08/13 ADD START FKS)NAKATA
    ''赤黒チェック用構造体
    Private Structure TYPE_AKAKRO_CHK
        Dim idx As Integer '行番号
        Dim CHKMK As Short 'チェックマーク
        Dim UDNDT As String '売上日
        Dim JDNNO As String '受注№
        Dim kesikn As Decimal '消込金額
    End Structure

    Private AKAKRO_CHK() As TYPE_AKAKRO_CHK
    '2008/08/13 ADD START FKS)NAKATA

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    連絡票№CF10042801
    'INIファイル読込用定数
    Private Const pc_strIni_OUTNAME As String = "OUT_NAME"
    Private Const pc_strIni_OUTTYPE As String = "OUT_TYPE"
    Private Const pc_strIni_TABCHAR As String = "TAB_CHAR"

    'INIファイル読込内容格納変数
    Public gv_strOUT_NAME As String '出力ファイル名
    Public gv_strOUT_TYPE As String '出力ファイル拡張子
    Public gv_strTAB_CHAR As String '区切り文字
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End




    'フォームロードイベント
    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'WINDOW 位置設定
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'ローカル変数初期化
        intUrigoukei = 0
        intBfkesiknkei = 0
        intMaxRow = 0
        intChkKb = 2

        blnFriEnabled = False
        blnUsableSpread = False
        blnUsableButton = False
        blnUsableEvent = True

        '★DBへの接続
        '2019/04/18 CHG START
        'If CF_Ora_USR1_Open() = False Then
        '    MsgBox("DBの接続に失敗しました。", MsgBoxStyle.Critical, "接続エラー")
        'End If
        CON = DB_START()
        '2019/04/18 CHG E N D

        'PG初期化
        '2019/04/26 CHG START
        Call CF_Init()
        'Call CF_Init_URKET53()
        '2019/04/26 CHG E N D

        '画面初期化
        initForm()
        initCondition()
        initHead()
        initBody()

        '// V2.00↓ ADD
        intInputMode = 1

        'システム共通処理
        Call CF_System_Process(Me)
        '// V2.00↑ ADD

        '2019/04/26 ADD START
        'Call UNYMTA_GetFirst()
        Call GetRowsCommon("UNYMTA", "")
        SetBar(Me)
        '2019/04/26 ADD E N D

        '★ログの書き出し
        Call SSSWIN_LOGWRT("プログラム起動")
    End Sub

    'フォームアンロードイベント
    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        '●終了確認のMSG
        '// V2.00↓ UPD
        ''    If blnUsableButton = True Then
        ''        If showMsg("0", "_ENDCK", 0) = vbNo Then
        ''            Cancel = vbCancel
        ''            Exit Sub
        ''        End If
        ''    Else
        ''        If showMsg("0", "_ENDCM", 0) = vbNo Then
        ''            Cancel = vbCancel
        ''            Exit Sub
        ''        End If
        ''    End If
        If ChkInputChange() = True Then
            If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                'add 20190809 START hou
                eventArgs.Cancel = Cancel
                'add 201908090 END hou
                Exit Sub
            End If
        Else
            If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                'add 201908090 START hou
                eventArgs.Cancel = Cancel
                'add 201908090 END hou
                Exit Sub
            End If
        End If
        '// V2.00↑ UPD

        '2007/12/11 FKS)minamoto ADD START
        '排他日時削除

        'NAKATA
        'XX    Call Execute_PLSQL_PRC_URKET53_03
        '2007/12/11 FKS)minamoto ADD END

        '20091227↓DEL
        '    '排他テーブル削除
        '    Call SSSEXC_EXCTBZ_CLOSE
        '20091227↑DEL

        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
        Call SSSWIN_Unlock_EXCTBZ()
        '排他テーブル削除
        Call SSSEXC_EXCTBZ_CLOSE()
        ' === 20130708 === INSERT E -

        'DBの接続を切断
        '2019/04/18 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        ''// V2.00↓ ADD
        'Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)
        ''// V2.00↑ ADD
        DB_CLOSE(CON)
        '2019/04/18 CHG E N D
        '★ログの書き出し
        Call SSSWIN_LOGWRT("プログラム終了")

        End '●PG終了
        eventArgs.Cancel = Cancel
    End Sub

    ' === 20130708 === DELETE S - FWEST)Koroyasu 排他制御の解除
    ''20091227↓ADD
    'Private Sub Form_Unload(Cancel As Integer)
    '
    '    '排他テーブル削除
    '    Call SSSEXC_EXCTBZ_CLOSE
    '
    'End Sub
    ''20091227↑ADD
    ' === 20130708 === DELETE E -


    'フォームの初期化
    Private Sub initForm()
        Dim ssBevelNone As Object
        Dim i As Short
        '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
        Dim strRet As String
        '''' ADD 2009/11/26  FKS) T.Yamamoto    End

        'フォームキャプションセット
        Me.Text = SSS_PrgNm

        '運用日の取得
        gstrUnydt.Value = getUnydt()
        '前回経理締実行日の取得
        Call getSYSTBA()
        '''' UPD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
        '    '権限の取得
        '    Call Get_Authority(gstrUnydt)
        '権限の取得
        strRet = Get_Authority(gstrUnydt.Value)
        If strRet = "9" Then
            '起動権限なしの場合、処理終了
            Call showMsg("2", "RUNAUTH", CStr(0))
            End
        End If
        '''' UPD 2009/11/26  FKS) T.Yamamoto    End

        '画面右上の項目に運用日をセット
        'UPGRADE_WARNING: オブジェクト pnl_unydt.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_unydt.Text = CNV_DATE(gstrUnydt.Value)

        '入力担当者をセット
        txt_opeid.Text = SSS_OPEID.Value
        txt_openm.Text = getTannm(SSS_OPEID.Value)

        txt_message.Text = ""

        '条件固定用パネルを隠す
        'UPGRADE_WARNING: オブジェクト pnl_condition1.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_condition1.Text = ""
        'UPGRADE_WARNING: オブジェクト pnl_condition1.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/17 DEL START
        'pnl_condition1.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D
        'UPGRADE_WARNING: オブジェクト pnl_condition2.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_condition2.Text = ""
        'UPGRADE_WARNING: オブジェクト pnl_condition2.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/17 DEL START
        'pnl_condition2.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D
        '表示限定テキストボックス設定用パネルを隠す
        'UPGRADE_WARNING: オブジェクト pnl_hihyoji.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_hihyoji.Text = ""
        'UPGRADE_WARNING: オブジェクト pnl_hihyoji.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/17 DEL START
        'pnl_hihyoji.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D

        'ｽﾌﾟﾚｯﾄﾞ隠し項目を非表示にする

        '// V2.02↓ UPD
        ''''    If SHOW_HIDE_COLUMN_FLAG = False Then
        ''''        With spd_body
        ''''            .Row = -1
        ''''            '締日前消込金項目から、JDNDATNOまでを非表示とする。
        '''''// V2.03↓ UPD
        ''''            For i = COL_BFKESIKN To COL_HENPI
        ''''''''// V2.00↓ UPD
        '''''''''            For i = COL_BFKESIKN To COL_JDNDATNO
        '''''''''            For i = COL_BFKESIKN To COL_BFCHECK
        '''''''            For i = COL_BFKESIKN To COL_KESIKN_MAE
        ''''''''// V2.00↑ UPD
        '''''// V2.03↑ UPD
        ''''                .Col = i
        ''''                .ColHidden = True
        ''''            Next i
        ''''        End With
        ''''    End If
        '// V2.02↑ UPD

        '// V2.12↓ ADD
        '2019/04/22 DEL START
        'ｽﾌﾟﾚｯﾄﾞ隠し項目を非表示にする
        'If SHOW_HIDE_COLUMN_FLAG = False Then
        '    With spd_body
        '        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .Row = -1
        '        '2009/09/15 UPD START RISE)MIYAJIMA
        '        '            For i = COL_BFKESIKN To COL_HENPI
        '        For i = COL_BFKESIKN To COL_SSADT
        '            '2009/09/15 UPD E.N.D RISE)MIYAJIMA
        '            'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .Col = i
        '            'UPGRADE_WARNING: オブジェクト spd_body.ColHidden の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .ColHidden = True
        '        Next i
        '    End With
        'End If
        '2019/04/22 DEL E N D

        '// V2.12↑ ADD

    End Sub

    '入力条件の初期化
    Private Sub initCondition()

        Call initVal() 'ｸﾞﾛｰﾊﾞﾙ変数の初期化

        txt_kesidt.Text = CNV_DATE(gstrUnydt.Value) '運用日をセット
        txt_kesidt.ForeColor = System.Drawing.Color.Black
        txt_kesidt.BackColor = System.Drawing.Color.White

        txt_tokseicd.Text = Space(5) '5byte space
        txt_tokseicd.ForeColor = System.Drawing.Color.Black
        txt_tokseicd.BackColor = System.Drawing.Color.White

        txt_tokseinma.Text = ""

        '// V2.00↓ UPD
        '    txt_kaidt.Text = CNV_DATE(gstrUnydt)    '運用日をセット
        '    txt_kaidt.ForeColor = vbBlack
        '    txt_kaidt.BackColor = vbWhite
        txt_kaidt_From.Text = Space(10) '10byte space
        txt_kaidt_From.ForeColor = System.Drawing.Color.Black
        txt_kaidt_From.BackColor = System.Drawing.Color.White

        txt_kaidt_To.Text = CNV_DATE(gstrUnydt.Value) '運用日をセット
        txt_kaidt_To.ForeColor = System.Drawing.Color.Black
        txt_kaidt_To.BackColor = System.Drawing.Color.White
        '// V2.00↑ UPD

        txt_kesikb.Text = CStr(1)

        blnFriEnabled = False
        '// V2.00↓ UPD
        '    txt_fridt.Text = Space(8)               '8byte space
        txt_fridt.Text = Space(10) '10byte space
        '// V2.00↑ UPD
        txt_fridt.ForeColor = System.Drawing.Color.Black
        txt_fridt.BackColor = System.Drawing.Color.White
        txt_fridt.Enabled = blnFriEnabled

        blnUsableButton = False
        blnUsableEvent = True

        'オプション項目の制御
        frm_opt1.Visible = OPTION_SHOW_FLAG
        opt_sort(0).Checked = True
        lbl_shakbnm(0).Visible = OPTION_SHOW_FLAG
        lbl_shakbnm(1).Visible = OPTION_SHOW_FLAG
        lbl_shakbnm(1).Text = ""
        lbl_hytokkesdd(0).Visible = OPTION_SHOW_FLAG
        lbl_hytokkesdd(1).Visible = OPTION_SHOW_FLAG
        lbl_hytokkesdd(1).Text = ""
        '2019/04/26 DEL START
        'bar21.Visible = OPTION_SHOW_FLAG
        'mnu_zenkesi.Visible = OPTION_SHOW_FLAG
        'mnu_zenkaijo.Visible = OPTION_SHOW_FLAG
        'mnu_zenkesi.Enabled = blnUsableButton
        'mnu_zenkaijo.Enabled = blnUsableButton
        '2019/04/26 DEL E N D
    End Sub

    'ヘッダ部(消込情報)の初期化
    Private Sub initHead()
        txt_urigoukei.Text = CStr(0)
        txt_nyukin.Text = CStr(0)
        txt_tesuryo.Text = CStr(0)
        txt_syohi.Text = CStr(0)
        txt_nyugoukei.Text = CStr(0)
        txt_kesizan.Text = CStr(0)
        intUrigoukei = 0
        intBfkesiknkei = 0
    End Sub

    '明細部の初期化
    Private Sub initBody()
        Dim ActionSelectBlock As Object
        Dim ActionClearText As Object
        '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
        blnUsableSpread = False

        With spd_body
            '2019/04/22 CHG START
            ''UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False

            ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = -1
            ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = -1
            ''UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Action = ActionClearText

            ''カーソル位置を先頭に戻す
            ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = 1
            ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト ActionSelectBlock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Action = ActionSelectBlock

            ''UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MaxRows = 9999
            ''UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True

            '描画停止
            .SuspendLayout()

            'カーソル位置を先頭に戻す
            .Focus()
            .Template = Nothing
            '.RowCount = 0

            '再描画
            .ResumeLayout()
            '2019/04/22 CHG E N D
        End With

        intMaxRow = 0

        'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
        blnUsableSpread = True
    End Sub

    '明細部の情報を表示
    '2019/04/19 CHG START
    '    Private Sub showBody()
    '        Dim strSql As Object
    '        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody As U_Ody
    '        Dim tmp As Object
    '        '2007/12/10 FKS)minamoto ADD START
    '        Dim intRet As Short
    '        '2007/12/10 FKS)minamoto ADD END
    '        'ADD START FKS)INABA 2007/07/23 **************
    '        Dim lw_sort As Short
    '        'ADD  END  FKS)INABA 2007/07/23 **************
    '        '2008/1/10 FKS)ichihara ADD START
    '        Dim bleNextFlg As Boolean
    '        '2008/1/10 FKS)ichihara ADD END


    '        '2008/08/05 ADD START FKS)NAKATA
    '        Dim idxRow As Integer
    '        Dim strHYJDNNO As String
    '        '2008/08/05 ADD E.N.D FKS)NAKATA

    '        '// V2.00↓ ADD
    '        Dim strTEGDT As String
    '        '// V2.00↑ ADD

    '        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
    '        Dim rResult As Short ' 処理チェック関数戻り値
    '        Dim strUDNDT As String
    '        ' === 20130708 === INSERT E

    '        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
    '        Call SSSWIN_Unlock_EXCTBZ()
    '        ' === 20130708 === INSERT E -

    '        '// V2.00↓ ADD
    '        '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
    '        blnUsableSpread = False

    '        ReDim ARY_UDNTRA_HAITA(0)
    '        ReDim ARY_JDNTRA_HAITA(0)
    '        '// V2.00↑ ADD

    '        'マウスカーソルを砂時計にする
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        '明細データ取得用SQLを作成
    '        'CHG START FKS)INABA 2007/07/23 *******************************************************************************
    '        Select Case True
    '            Case opt_sort(0).Checked
    '                lw_sort = 0
    '            Case opt_sort(1).Checked
    '                lw_sort = 1
    '            Case opt_sort(2).Checked
    '                lw_sort = 2
    '        End Select
    '        '2009/09/10 UPD START RISE)MIYAJIMA
    '        ''// V2.00↓ UPD
    '        ''    strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd, gstrKaidt, txt_kesikb.Text, lw_sort)
    '        '    strSql = getSQLforBody( _
    '        ''                            DB_SYSTBA.SMAUPDDT, _
    '        ''                            gstrTokseicd, _
    '        ''                            gstrKaidt_Fr, _
    '        ''                            gstrKaidt_To, _
    '        ''                            txt_kesikb.Text, _
    '        ''                            lw_sort)
    '        ''// V2.00↑ UPD
    '        gstrTokseicd.Value = txt_tokseicd.Text
    '        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
    '        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
    '        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
    '        '2009/09/10 UPD E.N.D RISE)MIYAJIMA

    '        '    strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd, gstrKaidt, txt_kesikb.Text, opt_sort(0).Value)
    '        'CHG  END  FKS)INABA 2007/07/23 *******************************************************************************
    '        'ﾃﾞｰﾀ取得
    '        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '2019/04/18 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '        Dim dt As DataTable = DB_GetTable(strSql)
    '        '2019/04/18 CHG E N D

    '        '表示項目初期化
    '        initHead()
    '        initBody()

    '        '2008/07/30 DEL START FKS)NAKATA
    '        'XX    '2007/12/05 FKS)minamoto ADD START
    '        'XX    ' 排他更新日付クリア
    '        'XX
    '        'XX    ReDim HAITA_UDNTRA(0)
    '        'XX    ReDim HAITA_JDNTRA(0)
    '        'XX    '2007/12/11 FKS)minamoto ADD START
    '        'XX    '排他日時削除
    '        'XX
    '        'XX    Call Execute_PLSQL_PRC_URKET53_03
    '        'XX    '2007/12/11 FKS)minamoto ADD END
    '        'XX   '2007/12/05 FKS)minamoto ADD END
    '        '2008/07/30 DEL E.N.D FKS)NAKATA


    '        '// V2.00↓ UPD
    '        '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
    '        blnUsableSpread = False
    '        '// V2.00↑ UPD

    '        With spd_body
    '            'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '2019/04/19 DEL START
    '            '.ReDraw = False
    '            '2019/04/19 DEL E N D
    '            '2019/04/18 CHG START
    '            'Do While CF_Ora_EOF(Usr_Ody) = False
    '            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
    '                For cnt As Integer = 0 To dt.Rows.Count - 1
    '                    '2019/04/18 CHG E N D

    '                    '2008/1/10 FKS)ichihara ADD START
    '                    '貼り付けるデータが返品データの場合､黒データを検索
    '                    bleNextFlg = True

    '                    '2008/07/25 DEL START FKS)NAKATA
    '                    '            If CF_Ora_GetDyn(Usr_Ody, "AKAKROKB", "") = "9" Then
    '                    '                If getKuroTbl(Trim$(CF_Ora_GetDyn(Usr_Ody, "jdnno", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "HENSTTCD", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "udndt", ""))) = False Then
    '                    '
    '                    '                    'データの表示を行わない
    '                    '                    bleNextFlg = False
    '                    '                End If
    '                    '            End If
    '                    '2008/07/25 DEL E.N.D FKS)NAKATA


    '                    '2008/07/25 ADD START FKS)NAKATA
    '                    '''' UPD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
    '                    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    '                    ''返品の赤黒チェックのパラメータにRECNO,URITK,WRTFSTDT,WRTFSTTMを追加
    '                    '
    '                    '            'XX 返品の赤黒チェック
    '                    ''            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
    '                    '
    '                    '
    '                    '            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
    '                    ''V3.00 2009/03/10 CHG E.N.D FKS)NAKATA
    '                    '返品の赤黒チェックのパラメータにTOKSEICDを追加
    '                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    '2019/04/18 CHG START
    '                    'If chkHenpin(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", ""))) = False Then
    '                    If chkHenpin(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("RECNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTTM"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URITK"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), ""))) = False Then
    '                        '2019/04/18 CHG E N D
    '                        '''' UPD 2010/10/19  FKS) T.Yamamoto    End

    '                        'データの表示を行わない
    '                        bleNextFlg = False
    '                    Else
    '                        bleNextFlg = True
    '                    End If
    '                    '2008/07/25 ADD E.N.D FKS)NAKATA

    '                    '2008/07/26 ADD START FKS)NAKATA
    '                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    '2019/04/18 CHG START
    '                    'If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
    '                    If Trim(DB_NullReplace(dt.Rows(cnt)("HENRSNCD"), "")) = "" Then
    '                        '2019/04/18 CHG E N D
    '                        'XX 返品後、受注訂正処理の赤黒チェック
    '                        '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    連絡票№830
    '                        ''''' UPD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
    '                        ''                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
    '                        '                'パラメータにTOKSEICDを追加
    '                        '                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", ""))) = False Then
    '                        ''''' UPD 2010/10/19  FKS) T.Yamamoto    End
    '                        'パラメータにDATNOを追加
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        'If chkHenpinTeisei(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))) = False Then
    '                        If chkHenpinTeisei(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("LINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))) = False Then
    '                            '2019/04/18 CHG E N D
    '                            '''' UPD 2011/06/13  FKS) T.Yamamoto    End

    '                            'データの表示を行わない
    '                            bleNextFlg = False
    '                        Else
    '                            bleNextFlg = True
    '                        End If
    '                    End If
    '                    '2008/07/26 ADD E.N.D FKS)NAKATA

    '                    '2008/08/05 ADD START FKS)NAKATA
    '                    ''入力された消込日以降の売上データを出さない

    '                    If bleNextFlg = False Then
    '                        bleNextFlg = False

    '                    Else
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        'If Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) > 0 Then
    '                        If Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) > 0 Then
    '                            '2019/04/18 CHG E N D

    '                            '黒データで入力された消込日より後の売上は表示しない
    '                            bleNextFlg = False

    '                            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            '2019/041/18 CHG START
    '                            'ElseIf Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) < 0 Then
    '                        ElseIf Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) < 0 Then
    '                            '2019/04/18 CHG E N D

    '                            '返品の場合は、既に画面上に同じ受注番号が存在するかを確認する。
    '                            With spd_body
    '                                For idxRow = intMaxRow To 1 Step -1
    '                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                                    '2019/04/19 CHG START
    '                                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
    '                                    tmp = .GetValue(idxRow, COL_HYJDNNO)
    '                                    '2019/04/19 CHG E N D

    '                                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                                    strHYJDNNO = CStr(tmp)

    '                                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                                    '2019/04/18 CHG START
    '                                    'If Trim(strHYJDNNO) = Trim(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
    '                                    If Trim(strHYJDNNO) = Trim(DB_NullReplace(dt.Rows(cnt)("HY_JDNNO"), "")) Then
    '                                        '2019/04/18 CHG E N D

    '                                        '画面上に黒がいれば出力
    '                                        bleNextFlg = True
    '                                        Exit For
    '                                    Else
    '                                        bleNextFlg = False
    '                                    End If
    '                                Next idxRow
    '                            End With
    '                        Else
    '                            bleNextFlg = True

    '                        End If
    '                    End If
    '                    '2008/08/05 ADD E.N.D FKS)NAKATA

    '                    ''2009/09/10 DEL START RISE)MIYAJIMA
    '                    ''// V2.13↓ ADD
    '                    '            '//表示判断チェック
    '                    ''2009/09/08 UPD START RISE)MIYAJIMA
    '                    '''2009/09/03 ADD START RISE)MIYAJIMA
    '                    ''            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And Trim$(CF_Ora_GetDyn(Usr_Ody, "AKAKROKB", "")) = "9" Then
    '                    '''2009/09/03 ADD E.N.D RISE)MIYAJIMA
    '                    ''                If chkHenpin2(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
    '                    ''                    bleNextFlg = False
    '                    ''                End If
    '                    '''2009/09/03 ADD START RISE)MIYAJIMA
    '                    ''            End If
    '                    '''2009/09/03 ADD E.N.D RISE)MIYAJIMA
    '                    ''            If chkDspData(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "KOMIKN", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKN", ""))) = False Then
    '                    ''                bleNextFlg = False
    '                    ''            End If
    '                    ''2009/09/08 UPD E.N.D RISE)MIYAJIMA
    '                    ''// V2.13↑ ADD
    '                    '2009/09/10 DEL E.N.D RISE)MIYAJIMA

    '                    If bleNextFlg = True Then
    '                        '2008/1/10 FKS)ichihara ADD END

    '                        intMaxRow = intMaxRow + 1

    '                        '2009/09/29 ADD START RISE)MIYAJIMA
    '                        'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        If intMaxRow > .MaxRows Then
    '                            Exit Do
    '                        End If
    '                        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '                        'スプレッドに取得したデータを表示
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

    '                        .Row = intMaxRow
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_NO 'No.
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = intMaxRow

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_NXTKB '帳端
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_HYUDNDT '売上日
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_udndt"), "")
    '                        '2019/04/18 CHG E N D
    '                        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        strUDNDT = .Text
    '                        ' === 20130708 === INSERT E -

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_HYJDNNO '受注番号
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), "")
    '                        '2019/04/18 CHG E N D
    '                        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        If .Text <> "" Then
    '                            '排他チェック
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(.Text, 6))


    '                            Select Case rResult
    '                            '正常
    '                                Case 0

    '                                '排他処理中
    '                                Case 1
    '                                    'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                                    MsgBox("他のプログラムで更新中のため、登録できません。" & vbCrLf & vbCrLf & "行No:" & vbTab & intMaxRow & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & .Text)
    '                                    Call SSSWIN_Unlock_EXCTBZ()
    '                                    initBody()
    '                                    GoTo STEP10_ShowBody

    '                                '異常終了
    '                                Case 9
    '                                    Call showMsg("2", "URKET53_034 ", CStr(0)) '更新異常
    '                                    Call SSSWIN_Unlock_EXCTBZ()
    '                                    initBody()
    '                                    GoTo STEP10_ShowBody
    '                            End Select
    '                        End If
    '                        ' === 20130708 === INSERT E -

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/19 CHG START
    '                        .Col = COL_HYKAIDT '回収予定日
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/40/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_kaidt"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TOKJDNNO '客先注文番号
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("tokjdnno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TANNM '営業担当者
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("tannm"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_URIKN '税抜売上金額
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("urikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_UZEKN '消費税額
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("uzekn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_KOMIKN '税込売上金額
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("komikn"), "")
    '                        '2019/04/18 CHG E N D
    '                        '合計金額を計算
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        intUrigoukei = intUrigoukei + SSSVal(.Text)

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_KESIKN '入金済額
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("kesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_MINYUKN '未入金額(非表示)
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("kesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        '2009/09/27 UPD START RISE)MIYAJIMA
    '                        '2009/09/27 UPD START RISE)MIYAJIMA
    '                        '                '振込期日の取得
    '                        '                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        'strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    '                        strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")
    '                        '2019/04/18 CHG E N D
    '                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_BFHYFRIDT '振込期日(変更前)
    '                        If Trim(strTEGDT) <> "" Then
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            .Text = CNV_DATE(strTEGDT)
    '                        End If

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_HYFRIDT '振込期日
    '                        If Trim(strTEGDT) <> "" Then
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            .Text = CNV_DATE(strTEGDT)
    '                        Else
    '                            If txt_kesikb.Text <> "9" Then
    '                                'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                                .Text = CNV_DATE(gstrFridt.Value) 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                            End If
    '                        End If


    '                        ''// V2.00↓ UPD
    '                        '''                .Col = COL_HYFRIDT      '振込期日
    '                        '''    'CHG START FKS)INABA 2007/07/26 ****************************************************
    '                        '''
    '                        '''                If txt_kesikb.Text = "9" Then
    '                        '''                    .Text = Format(CF_Ora_GetDyn(Usr_Ody, "TEGDT", ""), "YYYY/MM/DD") '取得したデータを表示
    '                        '''                Else
    '                        '''                    .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        '''                End If
    '                        '''
    '                        '''    '            .Text = CNV_DATE(gstrFridt)       'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        '''    'CHG  END  FKS)INABA 2007/07/26 ****************************************************
    '                        '
    '                        ''// V3.20↓ UPD
    '                        '''''                .Col = COL_HYFRIDT      '振込期日
    '                        '''''                If txt_kesikb.Text = "9" Then
    '                        '''''                    strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        '''''                    .Text = CNV_DATE(strTEGDT)
    '                        '''''                Else
    '                        '''''                    .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        '''''                End If
    '                        '                .Col = COL_HYFRIDT      '振込期日
    '                        '                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        '                If Trim(strTEGDT) <> "" Then
    '                        '                    .Text = CNV_DATE(strTEGDT)
    '                        '                Else
    '                        '                    .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        '                End If
    '                        '
    '                        '                .Col = COL_BFHYFRIDT    '振込期日(変更前)
    '                        '                If Trim(strTEGDT) <> "" Then
    '                        '                    .Text = CNV_DATE(strTEGDT)
    '                        '                Else
    '                        '                    .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        '                End If
    '                        ''// V3.20↑ UPD
    '                        ''                .Col = COL_BFHYFRIDT    '振込期日(変更前)
    '                        ''                If txt_kesikb.Text = "9" Then
    '                        ''                    .Text = CNV_DATE(strTEGDT)
    '                        ''                Else
    '                        ''                    .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
    '                        ''                End If
    '                        ''// V2.00↑ UPD
    '                        ''// V2.13↓ ADD
    '                        '                .Col = COL_HYFRIDT      '振込期日
    '                        ''// V2.13↑ ADD
    '                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA

    '                        'ヘッダ部と同じく、明細部の入力も制限
    '                        'CHG START FKS)INABA 2007/05/08 ****************************************************
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Lock = Not blnFriEnabled
    '                        '.Lock = Not blnFriEnabled
    '                        'CHG  END  FKS)INABA 2007/05/08 ****************************************************
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_BFKESIKN '消込済額(締日前)
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")
    '                        '2019/04/18 CHG E N D
    '                        '合計金額を計算
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)

    '                        '●入金済額(KESIKN) - 消込済額(締日前) > 0 のときﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸを付ける
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/19 CHG START
    '                        '.GetText(COL_KESIKN, .Row, tmp)
    '                        tmp = .GetValue(.Row, COL_KESIKN)
    '                        '2019/04/19 CHG E N D
    '                        '// V2.00↓ UPD
    '                        ''''                    If SSSVal(tmp) - SSSVal(.Text) <> 0 Then
    '                        'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        If SSSVal(tmp) <> 0 Then
    '                            '// V2.00↑ UPD
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            '2019/04/19 CHG START
    '                            .Col = COL_CHK
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            .Value = 1
    '                            '// V2.00↓ ADD
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            .Col = COL_BFCHECK
    '                            'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                            .Value = 1
    '                            '// V2.00↑ ADD
    '                        End If

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_AFKESIKN '消込済額(締日後)
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("afkesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_JDNNO '受注番号(6桁)
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdnno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_JDNLINNO '受注行番号
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdnlinno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_UDNDT '売上日(スラッシュなし)
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_KESDT '回収予定日(スラッシュなし）
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TOKCD '得意先ｺｰﾄﾞ
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tokcd"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TOKSEICD '請求先ｺｰﾄﾞ
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tokseicd"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TANCD '担当者ｺｰﾄﾞ
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_JDNDT '受注日
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdndt"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_TUKKB '通貨区分
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tukkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_INVNO 'ｲﾝﾎﾞｲｽ番号
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("invno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_FURIKN '海外売上金額
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("furikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_FRNKB '海外取引区分
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("frnkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_UDNDATNO '売上DATNO
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("datno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_UDNLINNO '売上行番号
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("linno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_MAEUKKB '前受区分
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("maeukkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_JDNDATNO '受注DATNO
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdndatno"), "")
    '                        '2019/04/18 CHG E N D

    '                        '2009/09/15 ADD START RISE)MIYAJIMA
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_SSADT '請求締日
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "SSADT", "")
    '                        '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '                        '// V2.00↓ ADD
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        .Col = COL_KESIKN_MAE '消込金額前
    '                        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, afkesikn, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        '2019/04/18 CHG START
    '                        '.Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))
    '                        .Text = SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")) + SSSVal(DB_NullReplace(dt.Rows(cnt)("afkesikn"), ""))
    '                        '2019/04/18 CHG E N D

    '                        '売上トランの排他情報取得
    '                        ReDim Preserve ARY_UDNTRA_HAITA(intMaxRow)
    '                        '2019/04/18 CHG START
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNOPEID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNCLTID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTDT", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTTM", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUOPEID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUCLTID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTDT", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTTM", ""))
    '                        ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("LINNO"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNOPEID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNCLTID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTDT"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTTM"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUOPEID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUCLTID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTDT"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTTM"), ""))
    '                        '2019/04/18 CHG E N D

    '                        '受注トランの排他情報取得
    '                        ReDim Preserve ARY_JDNTRA_HAITA(intMaxRow)
    '                        '2019/04/18 CHG START
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNDATNO", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNOPEID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNCLTID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTDT", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTTM", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUOPEID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUCLTID", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTDT", ""))
    '                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTTM", ""))
    '                        ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNDATNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNOPEID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNCLTID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTDT"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTTM"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUOPEID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUCLTID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTDT"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTTM"), ""))
    '                        '2019/04/18 CHG E N D
    '                        '// V2.00↑ ADD

    '                        '2008/07/30 DEL START FKS)NAKATA
    '                        'XX                '2007/12/05 FKS)minamoto ADD START
    '                        'XX                '売上トラン：排他日時取得
    '                        'XX
    '                        'XX                ReDim Preserve HAITA_UDNTRA(intMaxRow)
    '                        'XX                HAITA_UDNTRA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "datno", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "udnwrtdt", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "udnwrttm", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "udnuwrtdt", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "udnuwrttm", ""))
    '                        'XX                '受注トラン：排他日時取得
    '                        'XX
    '                        'XX                ReDim Preserve HAITA_JDNTRA(intMaxRow)
    '                        'XX                HAITA_JDNTRA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "jdndatno", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnwrtdt", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnwrttm", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnuwrtdt", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnuwrttm", ""))
    '                        'XX                '入金消込トラン：排他日時取得
    '                        'XX
    '                        'XX
    '                        'XX            intRet = Execute_PLSQL_PRC_URKET53_01(HAITA_UDNTRA(intMaxRow).DATNO, HAITA_UDNTRA(intMaxRow).LINNO)
    '                        'XX            If intRet <> 0 Then
    '                        'XX               Exit Do
    '                        'XX            End If
    '                        '2008/07/30 DEL E.N.D FKS)NAKATA

    '                        '2008/1/10 FKS)ichihara ADD START
    '                    End If
    '                    '2008/1/10 FKS)ichihara ADD END

    '                    '2007/12/05 FKS)minamoto ADD END
    '                    'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    '2019/04/18 CHG START
    '                    'Usr_Ody.Obj_Ody.MoveNext()
    '                    'Loop
    '                Next
    '            End If
    '            '2019/04/18 CHG E N D


    '            '// V2.00↓ DEL
    '            '        .ReDraw = True
    '            '// V2.00↑ ADD
    '        End With

    '        '2019/04/18 DEL START
    '        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '        '2019/04/18 DEL E N D

    '        '消込対象がなければメッセージを表示
    '        Dim i As Short
    '        Dim vntTmp As Object
    '        If intMaxRow = 0 Then
    '            Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
    '            txt_kesidt.Focus()

    '            '対象がある時
    '        Else

    '            '2009/09/29 ADD START RISE)MIYAJIMA
    '            'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            If intMaxRow > spd_body.MaxRows Then
    '                initBody()
    '                Call showMsg("2", "URKET53_043", CStr(0)) '●表示可能数を超えました。日付を絞り直して下さい。
    '                txt_kesidt.Focus()
    '                GoTo STEP10_ShowBody
    '            End If
    '            '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '            '// V2.00↓ ADD
    '            '入金消込トランの排他情報取得
    '            Call Get_NKSTRA_HAITA_INF()
    '            '// V2.00↑ ADD
    '            '表示行数が16行以上のとき、ｽﾌﾟﾚｯﾄﾞ行数を設定
    '            If intMaxRow > 16 Then
    '                'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                spd_body.MaxRows = intMaxRow
    '            Else
    '                'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                spd_body.MaxRows = 16
    '            End If

    '            ''2009/09/27 ADD START RISE)MIYAJIMA

    '            With spd_body
    '                'UPGRADE_WARNING: オブジェクト spd_body.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .BlockMode = True
    '                'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                For i = 1 To spd_body.MaxRows
    '                    '20091227↓UPD
    '                    'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .Col = COL_HYFRIDT '振込期日(変更前)
    '                    'UPGRADE_WARNING: オブジェクト spd_body.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .Col2 = COL_HYFRIDT '振込期日(変更前)
    '                    'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .Row = i
    '                    'UPGRADE_WARNING: オブジェクト spd_body.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .Row2 = i
    '                    'UPGRADE_WARNING: オブジェクト spd_body.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                    .Lock = False
    '                    '                .GetText COL_BFHYFRIDT, i, vntTmp
    '                    '                If Trim(vntTmp) <> "" Then
    '                    '                    .Col = COL_HYFRIDT    '振込期日(変更前)
    '                    '                    .Col2 = COL_HYFRIDT    '振込期日(変更前)
    '                    '                    .Row = i
    '                    '                    .Row2 = i
    '                    '                    .Lock = True
    '                    '                Else
    '                    '                    .Col = COL_HYFRIDT    '振込期日(変更前)
    '                    '                    .Col2 = COL_HYFRIDT    '振込期日(変更前)
    '                    '                    .Row = i
    '                    '                    .Row2 = i
    '                    '                    .Lock = False
    '                    '                End If
    '                    '20091227↑UPD
    '                Next i
    '                'UPGRADE_WARNING: オブジェクト spd_body.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .Protect = True
    '                'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .Col = COL_CHK '振込期日(変更前)
    '                'UPGRADE_WARNING: オブジェクト spd_body.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .Col2 = COL_CHK '振込期日(変更前)
    '                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .Row = 1
    '                'UPGRADE_WARNING: オブジェクト spd_body.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .Row2 = 1
    '                'UPGRADE_WARNING: オブジェクト spd_body.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .BlockMode = False
    '            End With
    '            ''2009/09/27 ADD E.N.D RISE)MIYAJIMA

    '            showHead() 'ﾍｯﾀﾞ部の表示

    '            'spd_body.SetFocus
    '            blnUsableButton = True '●ﾎﾞﾀﾝ使用の許可
    '            mnu_zenkesi.Enabled = blnUsableButton
    '            mnu_zenkaijo.Enabled = blnUsableButton
    '            '条件パネルのロック
    '            'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            pnl_condition1.Enabled = False
    '            'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            pnl_condition2.Enabled = False
    '        End If

    '        '2009/09/29 ADD START RISE)MIYAJIMA
    'STEP10_ShowBody:
    '        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '        '// V2.00↓ DEL
    '        ''    '2007/12/10 FKS)minamoto ADD START
    '        ''    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    '        ''
    '        ''    '2007/12/10 FKS)minamoto ADD END
    '        '// V2.00↑ DEL

    '        '// V2.00↓ DEL
    '        'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        spd_body.ReDraw = True
    '        '// V2.00↑ ADD


    '        'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
    '        blnUsableSpread = True

    '        'マウスカーソルを標準に戻す
    '        'UPGRADE_ISSUE: vbNormal をアップグレードする定数を決定できません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"' をクリックしてください。
    '        'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
    '        '2019/04/18 DEL START
    '        'Me.Cursor = vbNormal
    '        '2019/04/18 DEL E N D
    '    End Sub

    'ヘッダ部(消込情報)の表示
    Private Sub showBody()
        Dim strSql As Object
        Dim Usr_Ody As U_Ody
        Dim tmp As Object
        Dim intRet As Short
        Dim lw_sort As Short
        Dim bleNextFlg As Boolean
        Dim idxRow As Integer
        Dim strHYJDNNO As String
        Dim strTEGDT As String
        Dim rResult As Short ' 処理チェック関数戻り値
        Dim strUDNDT As String
        Call SSSWIN_Unlock_EXCTBZ()

        '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
        blnUsableSpread = False

        ReDim ARY_UDNTRA_HAITA(0)
        ReDim ARY_JDNTRA_HAITA(0)

        'マウスカーソルを砂時計にする
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '明細データ取得用SQLを作成
        Select Case True
            Case opt_sort(0).Checked
                lw_sort = 0
            Case opt_sort(1).Checked
                lw_sort = 1
            Case opt_sort(2).Checked
                lw_sort = 2
        End Select

        gstrTokseicd.Value = txt_tokseicd.Text
        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
        strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
        '2019/04/18 ADD START
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 ADD E N D

        '表示項目初期化
        initHead()
        initBody()


        '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
        blnUsableSpread = False

        Try

            With spd_body

                .Template = Me.Template11

                .SuspendLayout()

                If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                    'スプレッドに取得したデータを表示
                    .RowCount = dt.Rows.Count

                    For cnt As Integer = 0 To dt.Rows.Count - 1

                        '貼り付けるデータが返品データの場合､黒データを検索
                        bleNextFlg = True

                        If chkHenpin(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("RECNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTTM"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URITK"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), ""))) = False Then
                            'データの表示を行わない
                            bleNextFlg = False
                        Else
                            bleNextFlg = True
                        End If

                        If Trim(DB_NullReplace(dt.Rows(cnt)("HENRSNCD"), "")) = "" Then

                            If chkHenpinTeisei(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("LINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))) = False Then

                                'データの表示を行わない
                                bleNextFlg = False
                            Else
                                bleNextFlg = True
                            End If
                        End If

                        ''入力された消込日以降の売上データを出さない

                        If bleNextFlg = False Then
                            bleNextFlg = False
                        Else

                            If Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) > 0 Then

                                '黒データで入力された消込日より後の売上は表示しない
                                bleNextFlg = False

                            ElseIf Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) < 0 Then

                                '返品の場合は、既に画面上に同じ受注番号が存在するかを確認する。
                                With spd_body
                                    For idxRow = intMaxRow To 1 Step -1

                                        tmp = .GetValue(idxRow, COL_HYJDNNO)

                                        strHYJDNNO = CStr(tmp)

                                        If Trim(strHYJDNNO) = Trim(DB_NullReplace(dt.Rows(cnt)("HY_JDNNO"), "")) Then

                                            '画面上に黒がいれば出力
                                            bleNextFlg = True
                                            Exit For
                                        Else
                                            bleNextFlg = False
                                        End If
                                    Next idxRow
                                End With
                            Else
                                bleNextFlg = True

                            End If
                        End If

                        If bleNextFlg = True Then

                            intMaxRow = intMaxRow + 1

                            '2019/04/25 CHG START
                            'If intMaxRow > .RowCount - 1 Then
                            If intMaxRow > .RowCount Then
                                '2019/04/25 CHG E N D
                                Exit For
                            End If

                            'チェック
                            .SetValue(cnt, COL_CHK, False)

                            'No.
                            .SetValue(cnt, COL_NO, cnt + 1)

                            '帳端
                            .SetValue(cnt, COL_NXTKB, DB_NullReplace(dt.Rows(cnt)("nxtkb"), ""))

                            '売上日
                            .SetValue(cnt, COL_HYUDNDT, IIf(DB_NullReplace(dt.Rows(cnt)("hy_udndt").ToString, "") = "", "", VB6.Format(dt.Rows(cnt)("hy_udndt"), "yyyy/mm/dd")))
                            strUDNDT = DB_NullReplace(dt.Rows(cnt)("hy_udndt"), "")

                            '受注番号
                            .SetValue(cnt, COL_HYJDNNO, DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), ""))

                            If DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), "") <> "" Then
                                '排他チェック
                                rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), ""), 6))

                                Select Case rResult
                            '正常
                                    Case 0

                                '排他処理中
                                    Case 1
                                        MsgBox("他のプログラムで更新中のため、登録できません。" & vbCrLf & vbCrLf & "行No:" & vbTab & intMaxRow & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & .Text)
                                        Call SSSWIN_Unlock_EXCTBZ()
                                        initBody()
                                        GoTo STEP10_ShowBody

                                '異常終了
                                    Case 9
                                        Call showMsg("2", "URKET53_034 ", CStr(0)) '更新異常
                                        Call SSSWIN_Unlock_EXCTBZ()
                                        initBody()
                                        GoTo STEP10_ShowBody
                                End Select
                            End If

                            '回収予定日
                            .SetValue(cnt, COL_HYKAIDT, IIf(DB_NullReplace(dt.Rows(cnt)("hy_kaidt").ToString, "") = "", "", VB6.Format(dt.Rows(cnt)("hy_kaidt"), "yyyy/mm/dd")))

                            '客先注文番号
                            .SetValue(cnt, COL_TOKJDNNO, DB_NullReplace(dt.Rows(cnt)("tokjdnno"), ""))

                            '営業担当者
                            .SetValue(cnt, COL_TANNM, DB_NullReplace(dt.Rows(cnt)("tannm"), ""))

                            '税抜売上金額
                            .SetValue(cnt, COL_URIKN, DB_NullReplace(dt.Rows(cnt)("urikn"), ""))

                            '消費税額
                            .SetValue(cnt, COL_UZEKN, DB_NullReplace(dt.Rows(cnt)("uzekn"), ""))

                            '税込売上金額
                            .SetValue(cnt, COL_KOMIKN, DB_NullReplace(dt.Rows(cnt)("komikn"), ""))

                            '合計金額を計算
                            intUrigoukei = intUrigoukei + SSSVal(DB_NullReplace(dt.Rows(cnt)("komikn"), ""))

                            '入金済額
                            .SetValue(cnt, COL_KESIKN, DB_NullReplace(dt.Rows(cnt)("kesikn"), ""))

                            '未入金額(非表示)
                            .SetValue(cnt, COL_MINYUKN, DB_NullReplace(dt.Rows(cnt)("kesikn"), ""))

                            '振込期日の取得
                            strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")

                            '振込期日(変更前)
                            If Trim(strTEGDT) <> "" Then
                                .SetValue(cnt, COL_BFHYFRIDT, CNV_DATE(Trim(strTEGDT)))
                            End If

                            '振込期日
                            If Trim(strTEGDT) <> "" Then
                                .SetValue(cnt, COL_HYFRIDT, CNV_DATE(strTEGDT))
                            Else
                                If txt_kesikb.Text <> "9" Then
                                    .SetValue(cnt, COL_HYFRIDT, CNV_DATE(Trim(gstrFridt.Value))) 'ﾍｯﾀﾞで指定した振込期日を初期表示
                                End If
                            End If

                            'ヘッダ部と同じく、明細部の入力も制限
                            .Rows(cnt).Cells(COL_HYFRIDT).Enabled = Not blnFriEnabled

                            '消込済額(締日前)
                            .SetValue(cnt, COL_BFKESIKN, DB_NullReplace(dt.Rows(cnt)("bfkesikn"), ""))


                            '合計金額を計算
                            intBfkesiknkei = intBfkesiknkei + SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), ""))

                            '●入金済額(KESIKN) - 消込済額(締日前) > 0 のときﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸを付ける
                            tmp = .GetValue(cnt, COL_KESIKN)

                            If SSSVal(tmp) <> 0 Then
                                .SetValue(cnt, COL_CHK, True)
                                .SetValue(cnt, COL_BFCHECK, 1)
                            End If

                            '消込済額(締日後)
                            .SetValue(cnt, COL_AFKESIKN, DB_NullReplace(dt.Rows(cnt)("afkesikn"), ""))

                            '受注番号(6桁)
                            .SetValue(cnt, COL_JDNNO, DB_NullReplace(dt.Rows(cnt)("jdnno"), ""))

                            '受注行番号
                            .SetValue(cnt, COL_JDNLINNO, DB_NullReplace(dt.Rows(cnt)("jdnlinno"), ""))

                            '売上日(スラッシュなし)
                            .SetValue(cnt, COL_UDNDT, DB_NullReplace(dt.Rows(cnt)("udndt"), ""))

                            '回収予定日(スラッシュなし）
                            .SetValue(cnt, COL_KESDT, DB_NullReplace(dt.Rows(cnt)("kesdt"), ""))

                            '得意先ｺｰﾄﾞ
                            .SetValue(cnt, COL_TOKCD, DB_NullReplace(dt.Rows(cnt)("tokcd"), ""))

                            '請求先ｺｰﾄﾞ
                            .SetValue(cnt, COL_TOKSEICD, DB_NullReplace(dt.Rows(cnt)("tokseicd"), ""))

                            '担当者ｺｰﾄﾞ
                            .SetValue(cnt, COL_TANCD, DB_NullReplace(dt.Rows(cnt)("tancd"), ""))

                            '受注日
                            .SetValue(cnt, COL_JDNDT, DB_NullReplace(dt.Rows(cnt)("jdndt"), ""))

                            '通貨区分
                            .SetValue(cnt, COL_TUKKB, DB_NullReplace(dt.Rows(cnt)("tukkb"), ""))

                            'ｲﾝﾎﾞｲｽ番号
                            .SetValue(cnt, COL_INVNO, DB_NullReplace(dt.Rows(cnt)("invno"), ""))

                            '海外売上金額
                            .SetValue(cnt, COL_FURIKN, DB_NullReplace(dt.Rows(cnt)("furikn"), ""))

                            '海外取引区分
                            .SetValue(cnt, COL_FRNKB, DB_NullReplace(dt.Rows(cnt)("frnkb"), ""))

                            '売上DATNO
                            .SetValue(cnt, COL_UDNDATNO, DB_NullReplace(dt.Rows(cnt)("datno"), ""))

                            '売上行番号
                            .SetValue(cnt, COL_UDNLINNO, DB_NullReplace(dt.Rows(cnt)("linno"), ""))

                            '前受区分
                            .SetValue(cnt, COL_MAEUKKB, DB_NullReplace(dt.Rows(cnt)("maeukkb"), ""))

                            '受注DATNO
                            .SetValue(cnt, COL_JDNDATNO, DB_NullReplace(dt.Rows(cnt)("jdndatno"), ""))

                            '請求締日
                            .SetValue(cnt, COL_SSADT, DB_NullReplace(dt.Rows(cnt)("SSADT"), ""))

                            '消込金額前
                            .SetValue(cnt, COL_KESIKN_MAE, SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")) + SSSVal(DB_NullReplace(dt.Rows(cnt)("afkesikn"), "")))


                            '売上トランの排他情報取得
                            ReDim Preserve ARY_UDNTRA_HAITA(cnt)

                            ARY_UDNTRA_HAITA(cnt).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))

                            ARY_UDNTRA_HAITA(cnt).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("LINNO"), ""))

                            ARY_UDNTRA_HAITA(cnt).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNOPEID"), ""))

                            ARY_UDNTRA_HAITA(cnt).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNCLTID"), ""))

                            ARY_UDNTRA_HAITA(cnt).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTDT"), ""))

                            ARY_UDNTRA_HAITA(cnt).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTTM"), ""))

                            ARY_UDNTRA_HAITA(cnt).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUOPEID"), ""))

                            ARY_UDNTRA_HAITA(cnt).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUCLTID"), ""))

                            ARY_UDNTRA_HAITA(cnt).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTDT"), ""))

                            ARY_UDNTRA_HAITA(cnt).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTTM"), ""))


                            '受注トランの排他情報取得
                            ReDim Preserve ARY_JDNTRA_HAITA(cnt)

                            ARY_JDNTRA_HAITA(cnt).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNDATNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).JDNNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNOPEID"), ""))

                            ARY_JDNTRA_HAITA(cnt).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNCLTID"), ""))

                            ARY_JDNTRA_HAITA(cnt).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTDT"), ""))

                            ARY_JDNTRA_HAITA(cnt).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTTM"), ""))

                            ARY_JDNTRA_HAITA(cnt).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUOPEID"), ""))

                            ARY_JDNTRA_HAITA(cnt).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUCLTID"), ""))

                            ARY_JDNTRA_HAITA(cnt).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTDT"), ""))

                            ARY_JDNTRA_HAITA(cnt).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTTM"), ""))

                        End If

                    Next

                End If

            End With


            '消込対象がなければメッセージを表示
            Dim i As Short
            Dim vntTmp As Object
            If intMaxRow = 0 Then
                Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
                txt_kesidt.Focus()

                '対象がある時
            Else

                If intMaxRow > 9999 Then
                    initBody()
                    Call showMsg("2", "URKET53_043", CStr(0)) '●表示可能数を超えました。日付を絞り直して下さい。
                    txt_kesidt.Focus()
                    GoTo STEP10_ShowBody
                End If

                '入金消込トランの排他情報取得
                Call Get_NKSTRA_HAITA_INF()

                '表示行数が16行以上のとき、ｽﾌﾟﾚｯﾄﾞ行数を設定
                '2019/04/25 DEL START
                'If intMaxRow > 16 Then
                '    spd_body.RowCount = intMaxRow
                'Else
                '    spd_body.RowCount = 16
                'End If
                '2019/04/25 DEL E N D

                With spd_body

                    For i = 0 To spd_body.RowCount - 1
                        .Rows(i).Cells(COL_HYFRIDT).Enabled = True
                        .Rows(i).Cells(COL_CHK).Enabled = True
                    Next i

                End With

                showHead() 'ﾍｯﾀﾞ部の表示

                blnUsableButton = True '●ﾎﾞﾀﾝ使用の許可
                '2019/04/26 DEL START
                'mnu_zenkesi.Enabled = blnUsableButton
                'mnu_zenkaijo.Enabled = blnUsableButton
                '2019/04/26 DEL E N D
                '条件パネルのロック
                pnl_condition1.Enabled = False
                pnl_condition2.Enabled = False
            End If
        Catch ex As Exception

        End Try
STEP10_ShowBody:

        '再描画
        spd_body.ResumeLayout()


        'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
        blnUsableSpread = True

        'マウスカーソルを標準に戻す
        '2019/04/18 DEL START
        'Me.Cursor = vbNormal
        Me.Cursor = Cursors.Default

        '2019/04/18 DEL E N D
    End Sub
    '2019/04/19 CHG E N D

    Public Sub showHead()
        '// V2.09↓ DEL
        ''''    Dim strSql  As Variant
        ''''    Dim Usr_Ody As U_Ody
        '// V2.09↑ DEL

        Dim intZankn As Decimal '消込日月度までの消込残額計
        Dim intKesikn As Decimal '経理締日以降の消込額
        Dim intTesuryo As Decimal '消込日月度の手数料額を格納
        Dim intSyohi As Decimal '消込日月度の消費税額を格納

        Dim tmp As Decimal

        '// V2.00↓ ADD
        Dim i As Short
        '// V2.00↑ ADD

        intZankn = 0
        intKesikn = 0
        intTesuryo = 0
        intSyohi = 0

        '// V2.09↓ ADD
        Call getHaitaAndKnSum(DB_TOKMTA2.TOKSEICD, Get_Acedt(gstrKesidt.Value), DB_TOKMTA2.SHAKB)
        '// V2.09↑ ADD

        '// V2.00↓ UPD
        ''    '消込日月度までの消込残額計
        ''    strSql = "SELECT SUM(kskzankn) kskzankn FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt <= '" & DB_TOKMTA2.KESISMEDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        intZankn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "kskzankn", ""))
        ''    End If
        ''
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        ''    '経理締日以降の消込額
        ''    strSql = "SELECT SUM(ksknykkn) ksknykkn FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt > '" & DB_SYSTBA.SMAUPDDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        'intKesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ksknykkn", ""))
        ''        intKesikn = getBodyKesikei(COL_AFKESIKN)        '変更　2007/03/02 Saito
        ''    End If
        ''
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        ''    '消込日月度の手数料・消費税額を格納
        ''    strSql = "SELECT * FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt = '" & DB_TOKMTA2.KESISMEDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        intTesuryo = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        ''        intSyohi = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & SyohiID, ""))
        ''    End If
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        '// V2.09↓ DEL
        ''''    '消込日月度の消込状態を取得
        ''''    strSql = ""
        ''''    strSql = strSql & "SELECT * "
        ''''    strSql = strSql & "FROM   NKSSMA "
        ''''    strSql = strSql & "WHERE  "
        ''''    strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(DB_TOKMTA2.TOKSEICD) & "' "
        ''''    strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(Get_Acedt(gstrKesidt))) & "' "
        ''''
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    '入金消込サマリーの排他情報取得
        ''''    ReDim ARY_NKSSMA_HAITA(1)
        ''''    ARY_NKSSMA_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
        ''''    ARY_NKSSMA_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
        ''''    ARY_NKSSMA_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
        ''''    ARY_NKSSMA_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
        ''''    ARY_NKSSMA_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
        ''''    ARY_NKSSMA_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
        ''''
        ''''    '入金消込サマリの情報を構造体配列へ取得
        ''''    ReDim ARY_NKSSMA_KS(9)
        ''''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''''        For i = 0 To 9
        '// V2.09↑ DEL

        '// V2.07↓ UPD
        ''''            ARY_NKSSMA_KS(i).SEQ = i + 10
        ''''            ARY_NKSSMA_KS(i).UPDID = Format(i, "00")
        ''''            ARY_NKSSMA_KS(i).SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).ZAN_KIN = ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN + ARY_NKSSMA_KS(i).KSKZANKN
        ''''            '取引区分の設定
        ''''            Select Case i
        ''''                Case 0
        ''''                    ARY_NKSSMA_KS(i).DATKB = "01"
        ''''                Case 1
        ''''                    ARY_NKSSMA_KS(i).DATKB = "02"
        ''''                Case 2
        ''''                    ARY_NKSSMA_KS(i).DATKB = "03"
        ''''                Case 3
        ''''                    ARY_NKSSMA_KS(i).DATKB = "04"
        ''''                Case 4
        ''''                    ARY_NKSSMA_KS(i).DATKB = "05"
        ''''                Case 5
        ''''                    ARY_NKSSMA_KS(i).DATKB = "06"
        ''''                Case 6
        ''''                    ARY_NKSSMA_KS(i).DATKB = "07"
        ''''                Case 7
        ''''                    ARY_NKSSMA_KS(i).DATKB = "08"
        ''''                Case 8
        ''''                    ARY_NKSSMA_KS(i).DATKB = "09"
        ''''                Case 9
        ''''                    ARY_NKSSMA_KS(i).DATKB = "99"
        ''''            End Select

        '// V2.09↓ DEL
        ''''            With ARY_NKSSMA_KS(i)
        ''''                .UPDID = Format(i, "00")
        ''''                If i <> 8 Then
        ''''                    .SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & Format(i, "00"), ""))
        ''''                    .KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & Format(i, "00"), ""))
        ''''                    .KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & Format(i, "00"), ""))
        ''''                    .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
        ''''                Else
        ''''                    '09：本入金 は、相手にしない
        ''''                    .SSANYUKN = 0
        ''''                    .KSKNYKKN = 0
        ''''                    .KSKZANKN = 0
        ''''                    .ZAN_KIN = 0
        ''''                End If
        ''''
        ''''                '取引区分の設定
        ''''                Select Case i
        ''''                    Case 0: .DATKB = "01"       '01：現金
        ''''                    Case 1: .DATKB = "02"       '02：振込
        ''''                    Case 2: .DATKB = "03"       '03：手形
        ''''                    Case 3: .DATKB = "04"       '04：相殺
        ''''                    Case 4: .DATKB = "05"       '05：値引
        ''''                    Case 5: .DATKB = "06"       '06：手数
        ''''                    Case 6: .DATKB = "07"       '07：他
        ''''                    Case 7: .DATKB = "08"       '08：振込仮
        ''''                    Case 8: .DATKB = "09"       '09：本入金
        ''''                    Case 9: .DATKB = "99"       '99：消費
        ''''                End Select
        ''''
        ''''                '消込順序の設定（-1 は消込なし）
        ''''                Select Case SSSVal(DB_TOKMTA2.SHAKB)
        ''''                    Case 1                  '支払条件＝1：振込
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 2            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 1            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 5            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 3            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 4            '取引区分＝99：消費
        ''''                        End Select
        ''''                    Case 2                  '支払条件＝2：手形
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 2            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 5            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 1            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 3            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 4            '取引区分＝99：消費
        ''''                        End Select
        ''''                    Case 3                  '支払条件＝3：振込または手形
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 1            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 2            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 4            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 5            '取引区分＝99：消費
        ''''                        End Select
        ''''                    Case 4                  '支払条件＝4：振込手形併用
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 1            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 2            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 4            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 5            '取引区分＝99：消費
        ''''                        End Select
        ''''                    Case 5                  '支払条件＝5：期日振込
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 2            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 1            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 4            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 5            '取引区分＝99：消費
        ''''                        End Select
        ''''                    Case 6                  '支払条件＝6：ﾌｧｸﾀﾘﾝｸﾞ
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '取引区分＝01：現金
        ''''                            Case 1: .SEQ = 2            '取引区分＝02：振込
        ''''                            Case 2: .SEQ = 1            '取引区分＝03：手形
        ''''                            Case 3: .SEQ = 6            '取引区分＝04：相殺
        ''''                            Case 4: .SEQ = 7            '取引区分＝05：値引
        ''''                            Case 5: .SEQ = 4            '取引区分＝06：手数
        ''''                            Case 6: .SEQ = 8            '取引区分＝07：他
        ''''                            Case 7: .SEQ = 9            '取引区分＝08：振込仮
        ''''                            Case 8: .SEQ = -1           '取引区分＝09：本入金
        ''''                            Case 9: .SEQ = 5            '取引区分＝99：消費
        ''''                        End Select
        ''''                End Select
        ''''            End With
        '''''// V2.07↑ UPD
        ''''        Next i
        ''''    End If
        '// V2.09↑ DEL

        '// V2.07↓ DEL
        ''''    '消込順序の設定
        ''''    Select Case SSSVal(DB_TOKMTA2.SHAKB)   '1：振込、2：手形、3：振込または手形、4：振込手形併用、5：期日振込、6：ﾌｧｸﾀﾘﾝｸﾞ
        ''''        Case 1
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''        Case 2
        ''''            ARY_NKSSMA_KS(2).SEQ = 1
        ''''        Case 3
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''            ARY_NKSSMA_KS(2).SEQ = 2
        ''''        Case 4
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''            ARY_NKSSMA_KS(2).SEQ = 2
        ''''        Case 5
        ''''            ARY_NKSSMA_KS(2).SEQ = 1
        ''''        Case 6
        ''''    End Select
        '// V2.07↑ DEL

        '消込日月度までの消込残額計
        For i = 0 To 9
            intZankn = intZankn + ARY_NKSSMA_KS(i).KSKZANKN
        Next i

        '経理締日以降の消込額
        For i = 0 To 9
            intKesikn = intKesikn + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN
        Next i

        '消込日月度の手数料・消費税額を格納
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        i = SSSVal(TesuryoID)
        intTesuryo = ARY_NKSSMA_KS(i).KSKZANKN + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        i = SSSVal(SyohiID)
        intSyohi = ARY_NKSSMA_KS(i).KSKZANKN + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        '// V2.00↑ UPD

        '売上合計金額の表示
        txt_urigoukei.Text = VB6.Format(intUrigoukei, "###,###,##0")

        '入金額・手数料額・消費税額の表示
        tmp = intZankn + intKesikn
        If tmp - (intTesuryo + intSyohi) > 0 Then
            txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
            txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
            txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
            '残がプラスのとき
        ElseIf tmp > 0 Then
            If intTesuryo > 0 Then
                If intSyohi > 0 Then
                    '残額がプラスで、手数料も、消費税差額もプラスの時
                    If tmp - intTesuryo > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(tmp, "#,###,##0")
                        txt_syohi.Text = VB6.Format(0, "#,###,##0")
                    End If

                ElseIf intSyohi <= 0 Then
                    '残額がプラスで、手数料がプラス、消費税差額がマイナスの時
                    txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                    txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                End If

            ElseIf intTesuryo <= 0 Then
                If intSyohi > 0 Then
                    '残額がプラスで、手数量がマイナス、消費税差額がプラスの時
                    txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                ElseIf intSyohi <= 0 Then
                    '残額がプラスで、手数料も、消費税差額もマイナスの時
                    'tmp - (intTesuryo + intSyohi) は絶対に正なので、ここに処理は不要
                End If
            End If

            '残が負の時
        ElseIf tmp <= 0 Then
            If intTesuryo > 0 Then
                If intSyohi > 0 Then
                    '残額がマイナスで、手数料も、消費税差額もプラスの時
                    txt_nyukin.Text = VB6.Format(tmp, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
                    txt_syohi.Text = VB6.Format(0, "#,###,##0")
                ElseIf intSyohi <= 0 Then
                    '残額がマイナスで、手数料がプラス、消費税差額がマイナスの時
                    If tmp + intTesuryo + intSyohi > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                        txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
                        txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                    End If
                End If
            ElseIf intTesuryo <= 0 Then
                If intSyohi > 0 Then
                    '残額がマイナスで、手数量がマイナス、消費税差額がプラスの時
                    If tmp + intTesuryo + intSyohi > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(0, "#,###,##0")
                    End If
                ElseIf intSyohi <= 0 Then
                    '残額がマイナスで、手数料も、消費税差額もマイナスの時
                    txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                End If
            End If
        End If

        '入金合計額の表示
        'UPGRADE_WARNING: オブジェクト SSSVal(txt_syohi.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SSSVal(txt_tesuryo.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        tmp = SSSVal((txt_nyukin.Text)) + SSSVal((txt_tesuryo.Text)) + SSSVal((txt_syohi.Text))
        txt_nyugoukei.Text = VB6.Format(tmp, "###,###,##0")

        '入金残額の表示
        '// V2.00↓ UPD
        '    txt_kesizan.Text = Format(tmp - (getBodyKesikei(COL_KESIKN) - intBfkesiknkei), "###,###,##0")
        'txt_kesizan.Text = Format(intKesikn, "###,###,##0")
        'MMMM
        txt_kesizan.Text = VB6.Format(intZankn + intKesikn, "###,###,##0")

        '// V2.00↑ UPD
    End Sub

    '明細部合計金額の取得
    Private Function getBodyKesikei(ByRef strColName As String) As Decimal
        Dim i As Short
        Dim intKesikei As Decimal
        Dim tmp As Object

        intKesikei = 0
        blnUsableSpread = False
        With spd_body
            '2019/04/25 CHG START
            'For i = 1 To intMaxRow
            For i = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/19 CHG START
                '.GetText(strColName, i, tmp)
                tmp = .GetValue(i, strColName)
                '2019/04/19 CHG E N D

                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKesikei = intKesikei + SSSVal(tmp)
            Next i
        End With
        blnUsableSpread = True

        getBodyKesikei = intKesikei
    End Function

    '// V2.09↓ ADD
    '排他情報と消込金額情報を取得、グローバル変数に格納
    Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
        Dim strSql As Object
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim i As Short

        '消込日月度の消込状態を取得
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = ""
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & " SELECT * "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "   FROM NKSSMA "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 CHG E N D

        '入金消込サマリーの排他情報取得
        ReDim ARY_NKSSMA_HAITA(1)
        '2019/04/18 CHG START
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'ARY_NKSSMA_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))

        ARY_NKSSMA_HAITA(1).TOKCD = CStr(DB_NullReplace(dt.Rows(0)("TOKCD"), ""))

        ARY_NKSSMA_HAITA(1).SMADT = CStr(DB_NullReplace(dt.Rows(0)("SMADT"), ""))

        ARY_NKSSMA_HAITA(1).OPEID = CStr(DB_NullReplace(dt.Rows(0)("OPEID"), ""))

        ARY_NKSSMA_HAITA(1).CLTID = CStr(DB_NullReplace(dt.Rows(0)("CLTID"), ""))

        ARY_NKSSMA_HAITA(1).WRTDT = CStr(DB_NullReplace(dt.Rows(0)("WRTDT"), ""))

        ARY_NKSSMA_HAITA(1).WRTTM = CStr(DB_NullReplace(dt.Rows(0)("WRTTM"), ""))
        '2019/04/18 CHG E N D

        '入金消込サマリの情報を構造体配列へ取得
        ReDim ARY_NKSSMA_KS(9)
        For i = 0 To 9
            With ARY_NKSSMA_KS(i)
                .UPDID = VB6.Format(i, "00")

                If i <> 8 Then
                    '2019/04/18 CHG START
                    'If CF_Ora_EOF(Usr_Ody) = False Then
                    '    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & .UPDID, ""))
                    '    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & .UPDID, ""))
                    '    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & .UPDID, ""))
                    'End If
                    If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                        .SSANYUKN = SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN" & .UPDID), ""))

                        .KSKNYKKN = SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN" & .UPDID), ""))

                        .KSKZANKN = SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN" & .UPDID), ""))
                    End If
                    '2019/04/18 CHG 
                Else
                    '09：本入金 は、相手にしない
                    .SSANYUKN = 0
                    .KSKNYKKN = 0
                    .KSKZANKN = 0
                End If

                '取引区分の設定
                Select Case i
                    Case 0 : .DATKB = "01" '01：現金
                    Case 1 : .DATKB = "02" '02：振込
                    Case 2 : .DATKB = "03" '03：手形
                    Case 3 : .DATKB = "04" '04：相殺
                    Case 4 : .DATKB = "05" '05：値引
                    Case 5 : .DATKB = "06" '06：手数
                    Case 6 : .DATKB = "07" '07：他
                    Case 7 : .DATKB = "08" '08：振込仮
                    Case 8 : .DATKB = "09" '09：本入金
                    Case 9 : .DATKB = "99" '99：消費
                End Select

                '// V3.10↓ UPD
                '消込順序の設定（-1 は消込なし）
                ' ①相殺→②消費税→③手数料→④現金→⑤振込→⑥手形→⑦振込仮→⑧値引き→⑨他
                Select Case i
                    Case 0 : .SEQ = 4 '取引区分＝01：現金
                    Case 1 : .SEQ = 5 '取引区分＝02：振込
                    Case 2 : .SEQ = 6 '取引区分＝03：手形
                    Case 3 : .SEQ = 1 '取引区分＝04：相殺
                    Case 4 : .SEQ = 8 '取引区分＝05：値引
                    Case 5 : .SEQ = 3 '取引区分＝06：手数
                    Case 6 : .SEQ = 9 '取引区分＝07：他
                    Case 7 : .SEQ = 7 '取引区分＝08：振込仮
                    Case 8 : .SEQ = -1 '取引区分＝09：本入金
                    Case 9 : .SEQ = 2 '取引区分＝99：消費
                End Select
                '            '消込順序の設定（-1 は消込なし）
                '            Select Case SSSVal(pin_strSHAKB)
                '                Case 1                  '支払条件＝1：振込
                '                    Select Case i
                '                        Case 0: .SEQ = 2            '取引区分＝01：現金
                '                        Case 1: .SEQ = 1            '取引区分＝02：振込
                '                        Case 2: .SEQ = 5            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 3            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 4            '取引区分＝99：消費
                '                    End Select
                '                Case 2                  '支払条件＝2：手形
                '                    Select Case i
                '                        Case 0: .SEQ = 2            '取引区分＝01：現金
                '                        Case 1: .SEQ = 5            '取引区分＝02：振込
                '                        Case 2: .SEQ = 1            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 3            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 4            '取引区分＝99：消費
                '                    End Select
                '                Case 3                  '支払条件＝3：振込または手形
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '取引区分＝01：現金
                '                        Case 1: .SEQ = 1            '取引区分＝02：振込
                '                        Case 2: .SEQ = 2            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 4            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 5            '取引区分＝99：消費
                '                    End Select
                '                Case 4                  '支払条件＝4：振込手形併用
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '取引区分＝01：現金
                '                        Case 1: .SEQ = 1            '取引区分＝02：振込
                '                        Case 2: .SEQ = 2            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 4            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 5            '取引区分＝99：消費
                '                    End Select
                '                Case 5                  '支払条件＝5：期日振込
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '取引区分＝01：現金
                '                        Case 1: .SEQ = 2            '取引区分＝02：振込
                '                        Case 2: .SEQ = 1            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 4            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 5            '取引区分＝99：消費
                '                    End Select
                '                Case 6                  '支払条件＝6：ﾌｧｸﾀﾘﾝｸﾞ
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '取引区分＝01：現金
                '                        Case 1: .SEQ = 2            '取引区分＝02：振込
                '                        Case 2: .SEQ = 1            '取引区分＝03：手形
                '                        Case 3: .SEQ = 6            '取引区分＝04：相殺
                '                        Case 4: .SEQ = 7            '取引区分＝05：値引
                '                        Case 5: .SEQ = 4            '取引区分＝06：手数
                '                        Case 6: .SEQ = 8            '取引区分＝07：他
                '                        Case 7: .SEQ = 9            '取引区分＝08：振込仮
                '                        Case 8: .SEQ = -1           '取引区分＝09：本入金
                '                        Case 9: .SEQ = 5            '取引区分＝99：消費
                '                    End Select
                '            End Select
                '// V3.10↑ UPD
            End With
        Next i

        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        '// V3.10↓ DEL
        '    '前月入金消込残額のマイナスデータ処理
        '    Call cutMinusKSKZANKN
        '// V3.10↑ DEL

        For i = 0 To 9
            '残金を計算する
            With ARY_NKSSMA_KS(i)
                .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
            End With
        Next i
    End Sub
    '// V2.09↑ ADD

    '// V3.10↓ DEL
    ''// V2.09↓ ADD
    ''前月入金消込残額のマイナスデータがあると消込処理がおかしくなるので、
    ''ここでマイナスの前月入金消込残額をカットする
    ''ただし、消込順序が高いものから相殺する形で切る
    'Private Sub cutMinusKSKZANKN()
    '    Dim i           As Integer
    '    Dim intSEQ      As Integer
    '    Dim intUPDID    As Integer
    '    Dim curKSKZANKN As Currency
    '
    '    '消込順序が高いものから相殺する形で切る
    '    For i = 0 To 9
    '        For intSEQ = 1 To 20
    '            If ARY_NKSSMA_KS(i).SEQ = intSEQ Then
    '                curKSKZANKN = ARY_NKSSMA_KS(i).KSKZANKN
    '                For intUPDID = 0 To 9
    '                    With ARY_NKSSMA_KS(intUPDID)
    '                        '入金消込サマリ
    '                        If curKSKZANKN > 0 And .KSKZANKN < 0 Then
    '                            If (curKSKZANKN + .KSKZANKN) < 0 Then
    '                                .KSKZANKN = curKSKZANKN + .KSKZANKN
    '                                curKSKZANKN = 0
    '                            Else
    '                                curKSKZANKN = curKSKZANKN + .KSKZANKN
    '                                .KSKZANKN = 0
    '                            End If
    '                        End If
    '                    End With
    '                Next intUPDID
    '                ARY_NKSSMA_KS(i).KSKZANKN = curKSKZANKN
    '            End If
    '        Next intSEQ
    '    Next i
    '
    '    '相殺し切れなかったマイナスは強制的に切る
    '    For i = 0 To 9
    '        With ARY_NKSSMA_KS(i)
    '            If .KSKZANKN < 0 Then
    '                .KSKZANKN = 0
    '            End If
    '        End With
    '    Next i
    'End Sub
    ''// V2.09↑ ADD
    '// V3.10↑ DEL

    '// V2.00↓ DEL
    '''消込日付のチェック
    ''Private Function chkKesidt() As Boolean
    ''    chkKesidt = False
    ''    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    ''    If intChkKb = 1 Or txt_kesidt.Text <> CNV_DATE(gstrKesidt) Then
    '''        'ヘッダ、明細のクリア
    '''        initHead
    '''        initBody
    ''
    ''        '日付形式のチェック
    ''        If IsDate(txt_kesidt.Text) = False Then
    ''            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    ''
    ''        '経理締日以前の日付の時はエラー
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '''        ElseIf DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.MONUPDDT Then
    ''            Call showMsg("1", "URKET53_010", 0)     '●経理締め済みのMSG
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    ''        '運用日より後日付の時はエラー
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) > gstrUnydt Then
    ''            Call showMsg("2", "DATE_1", 3)          '●運用日後日付エラー
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    '''ADD START FKS)INABA 2007/05/25 **************************************
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) > _
    '''            DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    ''            Call showMsg("1", "URKET53_038", 0)          '●締めを跨いでの日付は入力できません
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    '''ADD  END  FKS)INABA 2007/05/25 **************************************
    ''        Else
    ''            txt_kesidt.ForeColor = vbBlack
    ''            chkKesidt = True
    ''        End If
    ''    End If
    ''    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    ''    intChkKb = 2            '●基本は変更時にチェック
    ''
    ''End Function
    '// V2.00↑ DEL

    '''請求先ｺｰﾄﾞのチェック
    ''Private Function chkTokseicd() As Boolean
    ''    chkTokseicd = False
    ''
    ''    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    ''    If intChkKb = 1 Or txt_tokseicd.Text <> gstrTokseicd Then
    '''        'ヘッダ、明細のクリア
    '''        initHead
    '''        initBody
    ''
    ''        '変更されていたら項目クリア
    ''        If txt_tokseicd.Text <> gstrTokseicd Then
    ''            txt_tokseinma.Text = ""
    ''            txt_fridt.Text = "        " '8byte space
    ''            txt_fridt.Enabled = False
    ''
    ''            lbl_shakbnm(1).Caption = ""
    ''            lbl_hytokkesdd(1).Caption = ""
    ''            gstrFridt = Space(8)        'add 2007/03/29 Saito
    ''        End If
    ''
    ''        '空白入力時はチェックしない（chkConditionでチェック）
    ''        If Trim(txt_tokseicd.Text) = "" Then Exit Function
    ''
    ''        blnFriEnabled = False
    ''
    ''        '得意先ﾏｽﾀから請求先名称を取得
    ''        Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), txt_tokseicd.Text)
    ''            '国内請求先のとき
    ''            Case 0:
    ''                txt_tokseicd.ForeColor = vbBlack
    ''                txt_tokseinma.Text = DB_TOKMTA2.TOKNMA
    ''                lbl_shakbnm(1).Caption = DB_TOKMTA2.SHAKBNM
    ''                lbl_hytokkesdd(1).Caption = DB_TOKMTA2.HYTOKKESDD
    ''                '支払条件が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日項目を入力可とする
    ''                '●支払条件の値に応じて、期日振込入力可能フラグをたてる
    '''CHG START FKS) INABA 2007/05/08 *******************************************
    '''支払条件に手形が入っている場合は明細の振込期日を入力できるようにする
    ''                Select Case DB_TOKMTA2.SHAKB
    ''                    Case "2", "3", "4", "5", "6"
    ''                        blnFriEnabled = True
    ''                End Select
    '''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '''                    blnFriEnabled = True
    '''                End If
    '''CHG  END  FKS) INABA 2007/05/08 *******************************************
    ''                txt_fridt.Enabled = blnFriEnabled
    ''                chkTokseicd = True
    ''
    ''            '海外請求先のとき
    ''            Case 1:
    ''                Call showMsg("1", "URKET53_013", 0)     '●国内の得意先ではありません。     '2007.03.05
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''
    ''            '請求先でない得意先のとき
    ''            Case 8:
    ''                Call showMsg("2", "DONTSELECT", "2")    '●請求先ではない
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''
    ''            '請求先が存在しない時
    ''            Case 9:
    ''                Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''        End Select
    ''    End If
    ''    gstrTokseicd = txt_tokseicd.Text
    ''    intChkKb = 2            '●基本は変更時にチェック
    ''End Function

    '// V2.00↓ UPD
    '''回収予定日付のチェック
    ''Private Function chkKaidt() As Boolean
    ''    chkKaidt = False
    ''
    ''    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    ''    If intChkKb = 1 Or txt_kaidt.Text <> CNV_DATE(gstrKaidt) Then
    '''        'ヘッダ、明細のクリア
    '''        initHead
    '''        initBody
    ''
    ''        '日付形式のチェック
    ''        If IsDate(txt_kaidt.Text) = False Then
    ''            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    ''            txt_kaidt.ForeColor = vbRed
    ''            txt_kaidt.SetFocus
    '''ADD START FKS)INABA 2007/08/01 **************************************
    ''        ElseIf DeCNV_DATE(txt_kaidt.Text) > _
    '''            DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    ''            Call showMsg("1", "URKET53_038", 0)          '●締めを跨いでの日付は入力できません
    ''            txt_kaidt.ForeColor = vbRed
    ''            txt_kaidt.SetFocus
    '''ADD  END  FKS)INABA 2007/08/01 **************************************
    ''        Else
    ''            txt_kaidt.ForeColor = vbBlack
    ''            chkKaidt = True
    ''        End If
    ''    End If
    ''    gstrKaidt = DeCNV_DATE(txt_kaidt.Text)
    ''    intChkKb = 2            '●基本は変更時にチェック
    ''End Function
    '// V2.00↑ UPD

    '// V2.06↓ DEL
    ''振込期日のチェック
    'Private Function chkFridt() As Boolean
    'On Error Resume Next
    '    chkFridt = False
    '
    '    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    '    If intChkKb = 1 Or txt_fridt.Text <> CNV_DATE(gstrFridt) Then
    '
    '        '空白時はチェックしない(Trueを返す)
    '        If Trim(txt_fridt.Text) = "" Then
    '            txt_fridt.ForeColor = vbBlack
    '            chkFridt = True
    '
    '        '日付形式のチェック
    '        ElseIf IsDate(txt_fridt.Text) = False Then
    '            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    '            txt_fridt.ForeColor = vbRed
    '            txt_fridt.SetFocus
    ''ADD START FKS)INABA 2007/05/25 ******************************************
    '        '経理締日以前の日付の時はエラー
    '        ElseIf DeCNV_DATE(txt_fridt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '            Call showMsg("1", "URKET53_010", 0)     '●経理締め済みのMSG
    '            txt_fridt.ForeColor = vbRed
    '            txt_fridt.SetFocus
    ''ADD  END  FKS)INABA 2007/05/25 ******************************************
    '        Else
    '            txt_fridt.ForeColor = vbBlack
    '            chkFridt = True
    '
    '        End If
    '    Else
    '        chkFridt = True
    '    End If
    '    gstrFridt = DeCNV_DATE(txt_fridt.Text)
    '    intChkKb = 2            '●基本は変更時にチェック
    'End Function
    '// V2.06↑ DEL

    '// V2.00↓ DEL
    '''ヘッダ部の入力チェック
    ''Private Function chkCondition() As Boolean
    ''    chkCondition = False
    ''
    ''    intChkKb = 1
    ''    If chkKesidt = True Then
    ''        intChkKb = 1
    ''        If chkTokseicd = True Then
    ''            intChkKb = 1
    ''            If chkKaidt = True Then
    ''                '振込期日が入力できる時は必須とする
    ''                If blnFriEnabled = True Then
    ''                    '未入力時はエラーとする
    ''                    If Trim(txt_fridt.Text) = "" Then
    ''                        Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
    ''                        txt_fridt.ForeColor = vbRed
    ''                        txt_fridt.SetFocus
    ''                        Exit Function
    ''                    End If
    ''
    ''                    intChkKb = 1
    ''                    If chkFridt = True Then
    ''                        chkCondition = True
    ''                    End If
    ''                Else
    ''                    chkCondition = True
    ''                End If
    ''            End If
    ''        '請求先ｺｰﾄﾞが未入力の時はｴﾗｰとする
    ''        Else
    ''            If Trim(txt_tokseicd.Text) = "" Then
    ''                Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''            End If
    ''        End If
    ''    End If
    ''End Function
    '// V2.00↑ DEL




    '全解除メニュークリック時
    Public Sub mnu_zenkaijo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmd_zenkaijo_Click()
    End Sub

    '全選択メニュークリック時
    Public Sub mnu_zenkesi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmd_zenkesi_Click()
    End Sub

    Private Sub opt_sort_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles opt_sort.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = opt_sort.GetIndex(eventSender)

        '// V2.00↓ ADD
        'ファンクションキー押下時
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00↑ ADD

    End Sub

    'ヘッダパネルマウスムーブ時
    Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        'ヒントの表示を初期化する
        img_light.Image = img_bklight(0).Image
        txt_message.Text = ""
    End Sub

    '2019/04/26 DEL START
    ''アイコン[終了]クリック時
    'Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.Close()
    'End Sub
    ''アイコン[終了]マウスダウン時
    'Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(1).Image
    'End Sub
    ''アイコン[終了]マウスムーブ時
    'Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "メニューに戻ります。"
    'End Sub
    ''アイコン[終了]マウスアップ時
    'Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(0).Image
    'End Sub

    ''アイコン[登録]クリック時
    'Private Sub img_resist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_regist_Click(mnu_regist, New System.EventArgs())
    'End Sub

    ''アイコン[登録]マウスダウン時
    'Private Sub img_resist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_resist.Image = img_bkresist(1).Image
    'End Sub
    ''アイコン[登録]マウスムーブ時
    'Private Sub img_resist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "登録します。"
    'End Sub
    ''アイコン[登録]マウスアップ時
    'Private Sub img_resist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_resist.Image = img_bkresist(0).Image
    'End Sub

    ''アイコン[検索]クリック時
    'Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
    'End Sub

    ''アイコン[検索]マウスダウン時
    'Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(1).Image
    'End Sub
    ''アイコン[検索]マウスムーブ時
    'Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "ウィンドウを表示します。"
    'End Sub
    ''アイコン[検索]マウスアップ時
    'Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(0).Image
    'End Sub
    '2019/04/26 DEL E N D

    'アイコン[解除]クリック時
    Private Sub img_unlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '// V2.00↓ UPD
        ''    If blnUsableButton = True Then
        ''        pnl_condition1.Enabled = True
        ''        pnl_condition2.Enabled = True
        ''        txt_kesidt.SetFocus
        ''        initHead
        ''        initBody
        ''        blnUsableButton = False
        ''    End If
        If blnUsableButton = True Then
            blnUsableButton = False
            'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pnl_condition1.Enabled = True
            'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pnl_condition2.Enabled = True
            initHead()
            initBody()
            txt_kesidt.Focus()
            intInputMode = 1
            ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
            Call SSSWIN_Unlock_EXCTBZ()
            ' === 20130708 === INSERT E -
        End If
        '// V2.00↑ UPD
    End Sub

    '2019/04/26 DEL START
    ''アイコン[解除]マウスダウン時
    'Private Sub img_unlock_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_unlock.Image = img_bkunlock(1).Image
    'End Sub
    ''アイコン[解除]マウスムーブ時
    'Private Sub img_unlock_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "画面をクリアしてコードの入力を待ちます。"
    'End Sub
    ''アイコン[解除]マウスアップ時
    'Private Sub img_unlock_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_unlock.Image = img_bkunlock(0).Image
    'End Sub

    ''メニュー[処理]－[終了]選択時
    'Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.Close()
    'End Sub
    '2019/04/26 DEL E N D

    'メニュー[処理]－[登録]選択時
    Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '2007/12/11 FKS)minamoto ADD START
        Dim intRtn As Short
        '2007/12/12 FKS)minamoto ADD END

        'ヘッダ部の入力チェック
        If chkCondition() = False Then Exit Sub
        '明細部の入力チェック
        If blnUsableButton = False Then
            showMsg("0", "_UPDATE", "2") '●明細部未入力のMSG
            Exit Sub
        End If

        '2008/07/29 ADD START FKS)NAKATA
        'XX 返品処理のなき分かれチェック

        If chkAkaKro() = False Then
            Exit Sub
        End If

        '// V2.13↓ ADD
        If chkFurikomiDT() = False Then
            Exit Sub
        End If
        '// V2.13↑ ADD

        '2008/07/29 ADD E.N.D FKS)NAKATA
        '2018/10/26 ADD START <C2-20181002-01> CIS)山口
        Dim i As Short
        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
            With spd_body
                'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'For i = 1 To spd_body.MaxRows
                '    'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .Row = i
                '    'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .Col = 
                'ﾁｪｯｸﾎﾞｯｸｽ
                '    'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    If .Value = 1 Then
                '        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        .Col = COL_HYFRIDT '振込期日
                '        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        If Trim(.Text) <> "" Then
                '            'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            If F_GET_EIGYO_DAY(.Text) = 9 Then
                '                If showMsg("2", "URKET53_049", "0") = MsgBoxResult.No Then '●振込期日が営業日ではありませんがよろしいですか？
                '                    'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '                    .Action = 0
                '                    Exit Sub
                '                Else
                '                    Exit For
                '                End If
                '            End If
                '        End If
                '    End If
                'Next i
                For i = 0 To spd_body.RowCount - 1
                    '.Row = i
                    '.Col = COL_CHK 'ﾁｪｯｸﾎﾞｯｸｽ

                    If .Rows(i).Cells(COL_CHK).Value Then 'ﾁｪｯｸ済み
                        '振込期日が空白でない場合
                        If Trim(.Rows(i).Cells(COL_HYFRIDT).Value) <> "" Then
                            If F_GET_EIGYO_DAY(.Text) = 9 Then
                                If showMsg("2", "URKET53_049", "0") = MsgBoxResult.No Then '●振込期日が営業日ではありませんがよろしいですか？
                                    .Rows(i).Cells(COL_HYFRIDT).ReadOnly = False
                                    Exit Sub
                                Else
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                Next i
                '2019/04/22 CHG E N D

            End With
        End If
        '2018/10/26 ADD END <C2-20181002-01> CIS)山口

        '●登録確認のMSG
        If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
            '★権限の判断
            If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
                showMsg("2", "UPDAUTH", "0")
                Exit Sub
            End If

            '排他チェック
            If VB.Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
                MsgBox("【" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
                '            Call HD_CLEAR
                '            Call P_vaData_Init
                Exit Sub
            Else
                Call SSSEXC_EXCTBZ_OPEN()
            End If

            '2008/07/30 DEL START FKS)NAKATA
            'XX        '2007/12/10 FKS)minamoto ADD START
            'XX        '排他更新日時チェック
            'XX
            'XX        intRtn = CHK_HAITA_UPD
            'XX        If intRtn = 0 Then
            'XX            'エラー
            'XX            Call showMsg("2", "URKET53_039", 0) '他のプログラムで更新されたため、登録できません。
            'XX            Exit Sub
            'XX        End If
            'XX        '2007/12/10 FKS)minamoto ADD END
            '2008/07/30 DEL E.N.D FKS)NAKATA

            '// V2.00↓ UPD
            ''        Me.MousePointer = vbHourglass
            ''        If sRegistration(spd_body) = True Then
            ''            '★ログの書き出し
            ''            Call SSSWIN_LOGWRT("登録完了:" & Left(DB_TOKMTA2.TOKSEICD, 5) & ":" & DB_TOKMTA2.TOKRN)
            ''
            '''2008/07/30 DEL START FKS)NAKATA
            '''XX            '2007/12/11 FKS)minamoto ADD START
            '''XX            '排他日時削除
            '''XX            Call Execute_PLSQL_PRC_URKET53_03
            '''XX            '2007/12/11 FKS)minamoto ADD END
            '''2008/07/30 DEL E.N.D FKS)NAKATA
            ''
            ''            mnu_initdsp_Click   '画面表示の初期化
            ''            txt_kesidt.SetFocus                     '2007.03.05
            ''        Else
            ''            '●更新処理失敗時
            ''            MsgBox "更新に失敗しました。", vbCritical, "更新エラー"
            ''        End If
            '2009/10/22 ADD START RISE)MIYAJIMA
            intProcErrFlg = 0
            '2009/10/22 ADD E.N.D RISE)MIYAJIMA

            '2019/04/26 ADD START
            'Me.MousePointer = vbHourglass

            Select Case sRegistration(spd_body)
                Case 9
                    '●更新処理失敗時
                    If intProcErrFlg = 1 Then
                        Call showMsg("2", "URKET53_044", 0) ' 残額と一致しない消込が発生しました。中止します。
                    End If

                    MsgBox("更新に失敗しました。", vbCritical, "更新エラー")

                Case 1

                Case 0
                    '★ログの書き出し
                    Call SSSWIN_LOGWRT("登録完了:" & LeftB(DB_TOKMTA2.TOKSEICD, 5) & ":" & DB_TOKMTA2.TOKRN)

                    '2019/05/07 CHG START
                    'mnu_initdsp_Click() '画面初期化
                    mnu_initdsp_Click(Button1, New System.EventArgs()) '画面初期化
                    '2019/05/07 CHG E N D
            End Select

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'UPGRADE_WARNING: mnu_regist_Click に変換されていないステートメントがあります。ソース コードを確認してください。

            '// V2.00↑ UPD
            Me.Cursor = System.Windows.Forms.Cursors.Default


        End If

    End Sub

    'メニュー[編集]－[画面初期化]選択時
    Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '// V2.00↓ UPD
        '    pnl_condition1.Enabled = True
        '    pnl_condition2.Enabled = True
        '    '画面の初期化
        '    initCondition
        '    initHead
        '    initBody
        '    '消込日にフォーカスを移動
        '    txt_kesidt.SetFocus
        '    txt_kesidt.BackColor = vbYellow
        '    blnINIT_FLG = True

        intInputMode = 9
        'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_condition1.Enabled = True
        'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pnl_condition2.Enabled = True
        '画面の初期化
        initCondition()
        initHead()
        initBody()
        '消込日にフォーカスを移動
        txt_kesidt.Focus()
        txt_kesidt.BackColor = System.Drawing.Color.Yellow
        blnINIT_FLG = True
        '// V2.00↑ UPD
        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
        Call SSSWIN_Unlock_EXCTBZ()
        ' === 20130708 === INSERT E -
    End Sub


    'メニュー[操作]－[候補の一覧]
    Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '消込日にフォーカスがあるとき
        'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        If Me.ActiveControl.Name = txt_kesidt.Name Then
            cmd_kesidt_Click()

            '請求先ｺｰﾄﾞにフォーカスがあるとき
            'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then
            cmd_tokseicd_Click()

            '// V2.00↓ UPD
            ''    '回収予定日にフォーカスがあるとき
            ''    ElseIf Me.ActiveControl.Name = txt_kaidt.Name Then
            ''        cmd_kaidt_Click

            '回収予定日にフォーカスがあるとき
            'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then
            Call cmd_kaidt_From_Click()

            '回収予定日にフォーカスがあるとき
            'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then
            Call cmd_kaidt_To_Click()
            '// V2.00↑ UPD

            '振込期日にフォーカスがあるとき
            'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
        ElseIf Me.ActiveControl.Name = txt_fridt.Name Then
            cmd_fridt_Click()
        End If
    End Sub



    Private Sub spd_body_Change(ByVal Col As Integer, ByVal Row As Integer)
        Dim spd_fridt As String
        Dim spd_fridt_val As Object
        Dim ret As Boolean
        Dim lw_col As Integer
        Dim lw_row As Integer

        If Col = 14 Then '期日振込日のチェック
            'ADD START FKS)INABA 2007/05/25 ******************************************
            lw_col = Col
            lw_row = Row
            '経理締日以前の日付の時はエラー
            '2019/04/22 CHG START 
            ''UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'ret = spd_body.GetText(Col, Row, spd_fridt_val)
            'If ret = True Then
            '    'UPGRADE_WARNING: オブジェクト spd_fridt_val の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")
            '    If Trim(spd_fridt) = "" Then
            '        blnUsableButton = True
            '    End If
            '    If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
            '        Call showMsg("1", "URKET53_010", CStr(0)) '●経理締め済みのMSG
            '        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Col = lw_col
            '        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Row = lw_row
            '        'UPGRADE_WARNING: オブジェクト spd_body.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
            '        'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Action = 0
            '        blnUsableButton = False
            '    Else
            '        'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Col = Col
            '        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Row = Row
            '        'UPGRADE_WARNING: オブジェクト spd_body.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            '        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Row = Row + 1
            '        'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        spd_body.Action = 0
            '        blnUsableButton = True
            '    End If
            'End If
            ''ADD  END  FKS)INABA 2007/05/25 ******************************************

            spd_fridt_val = spd_body.GetValue(Row, Col)
            If Trim(spd_fridt_val.ToString) <> "" Then

                spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")

                If Trim(spd_fridt) = "" Then
                    blnUsableButton = True
                End If
                If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
                    Call showMsg("1", "URKET53_010", CStr(0)) '●経理締め済みのMSG
                    spd_body.Rows(lw_row).Cells(lw_col).Style.ForeColor = Color.Red
                    blnUsableButton = False
                Else
                    spd_body.Rows(Row).Cells(Col).Style.ForeColor = Color.Black
                    blnUsableButton = True
                End If
            End If
            '2019/04/22 CHG E N D
        End If
    End Sub

    Private Sub spd_body_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)

        '// V2.00↓ ADD
        'ファンクションキー押下時
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00↑ ADD

    End Sub

    Private Sub txt_fridt_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txt_fridt.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'ADD START FKS)INABA 2007/05/25 ******************
        '入力チェック
        chkFridt()

        '背景色を白に戻す
        txt_fridt.BackColor = System.Drawing.Color.White
        'ADD  END  FKS)INABA 2007/05/25 ******************
        eventArgs.Cancel = Cancel
    End Sub

    '// V2.00↓ DEL
    '''=======================================================消込日=======================================================
    ''
    ''
    '''消込日項目を変更した時
    ''Private Sub txt_kesidt_Change()
    ''    'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''    If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''        txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''    ElseIf txt_kesidt.SelStart = 10 Then
    ''        intChkKb = 1                            '★日付の入力チェック
    ''        txt_tokseicd.SetFocus                   '請求先ｺｰﾄﾞ項目へ移動
    ''    End If
    ''    txt_kesidt.SelLength = 1
    ''End Sub
    ''
    '''消込日項目クリック時
    ''Private Sub txt_kesidt_Click()
    ''    txt_kesidt.SelStart = 0
    ''    txt_kesidt.SelLength = 1
    ''End Sub
    ''
    '''消込日項目にフォーカスが移った時
    ''Private Sub txt_kesidt_GotFocus()
    ''    '日付の十の位を選択状態にする
    ''    txt_kesidt.SelStart = 8
    ''    txt_kesidt.SelLength = 1
    ''    '背景色を黄色にする
    ''    txt_kesidt.BackColor = vbYellow
    ''    '検索処理を実行可能とする
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''消込日項目でキーを押した時
    ''Private Sub txt_kesidt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''    intChkKb = 0
    ''
    ''    '右矢印 or Space押下時
    ''    If KEYCODE = vbKeyRight Or KEYCODE = vbKeySpace Then
    ''        If txt_kesidt.SelStart < 9 Then
    ''            txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''            'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''            If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''                txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''            End If
    ''
    ''        'カーソルが右端に来たら次の項目へ移動
    ''        Else
    ''            intChkKb = 2                        '★日付の入力チェック（変更時のみ)
    ''            txt_tokseicd.SetFocus               '請求先ｺｰﾄﾞ項目へ移動
    ''        End If
    ''        txt_kesidt.SelLength = 1
    ''
    ''    'Backspace or 左矢印押下時
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_kesidt.SelStart > 0 Then
    ''            txt_kesidt.SelStart = txt_kesidt.SelStart - 1
    ''            'スラッシュにカーソルがきたら前の文字にカーソルを移動
    ''            If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''                txt_kesidt.SelStart = txt_kesidt.SelStart - 1
    ''            End If
    ''        End If
    ''        txt_kesidt.SelLength = 1
    ''
    ''    '上矢印押下時
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        '何もしない
    ''
    ''    '下矢印押下時
    ''    ElseIf KEYCODE = vbKeyDown Then
    ''        intChkKb = 2                            '★日付の入力チェック（変更時のみ)
    ''        txt_tokseicd.SetFocus                   '請求先ｺｰﾄﾞ項目へ移動
    ''
    ''    'Enter押下時
    ''    ElseIf KEYCODE = vbKeyReturn Then
    ''        intChkKb = 1                            '★日付の入力チェック
    ''        txt_tokseicd.SetFocus                   '請求先ｺｰﾄﾞ項目へ移動
    ''
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''消込日項目でキーを押した時
    ''Private Sub txt_kesidt_KeyPress(KeyAscii As Integer)
    ''    '数値のみ入力可とする
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''消込日項目からフォーカスが移った時
    ''Private Sub txt_kesidt_LostFocus()
    ''    '入力チェック
    ''    chkKesidt
    ''    '背景色を白に戻す
    ''    txt_kesidt.BackColor = vbWhite
    ''End Sub
    '// V2.00↑ DEL


    '=======================================================請求先ｺｰﾄﾞ=======================================================


    '請求先ｺｰﾄﾞ項目を変更した時
    'UPGRADE_WARNING: イベント txt_tokseicd.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_tokseicd_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.TextChanged
        Dim p As Short

        'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
        If blnUsableEvent = False Then Exit Sub

        blnUsableEvent = False
        p = txt_tokseicd.SelectionStart

        '全角を削除する
        txt_tokseicd.Text = delZenkaku((txt_tokseicd.Text))
        '入力値が5byteで無い時は空白埋め
        txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))

        txt_tokseicd.SelectionStart = p
        blnUsableEvent = True

        'カーソルが右端に移動した時は、次の項目へ移動
        If txt_tokseicd.SelectionStart = 5 Then
            intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
            '// V2.00↓ UPD
            '入力チェック
            If chkTokseicd() = True Then
                '次項目
                txt_kaidt_From.Focus()
            End If
            '// V2.00↑ UPD
        End If
        txt_tokseicd.SelectionLength = 1

    End Sub

    '請求先ｺｰﾄﾞ項目にフォーカスが移った時
    Private Sub txt_tokseicd_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Enter
        '先頭位置を選択状態にする
        txt_tokseicd.SelectionStart = 0
        txt_tokseicd.SelectionLength = 1
        '背景色を黄色にする
        txt_tokseicd.BackColor = System.Drawing.Color.Yellow
        '検索処理を実行可能とする
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D
    End Sub

    '// V2.00↓ UPD
    '請求先ｺｰﾄﾞ項目でキーを押した時
    Private Sub txt_tokseicd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_tokseicd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        'キー入力制御
        Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
            Case 0
                '何もしない
            Case 1
                '入力チェック
                If chkTokseicd() = True Then
                    '次項目
                    txt_kaidt_From.Focus()
                End If
            Case 2
                '入力チェック
                If chkTokseicd() = True Then
                    '前項目
                    txt_kesidt.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub
    ''// V2.00↑ UPD

    '請求先ｺｰﾄﾞ項目でキーを押した時
    Private Sub txt_tokseicd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_tokseicd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'アルファベット小文字を大文字に変換する
        If Chr(KeyAscii) Like "[a-z]" Then
            KeyAscii = KeyAscii - 32
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '請求先ｺｰﾄﾞ項目からフォーカスが移った時
    Private Sub txt_tokseicd_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Leave

        '背景色を白に戻す
        txt_tokseicd.BackColor = System.Drawing.Color.White

    End Sub

    '// V2.00↓ DEL
    ''=======================================================回収予定日=======================================================
    ''
    ''
    '''回収予定日項目を変更した時
    ''Private Sub txt_kaidt_Change()
    ''    'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''    If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''        txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''    ElseIf txt_kaidt.SelStart = 10 Then
    ''        intChkKb = 1                            '★日付の入力チェック
    ''        txt_kesikb.SetFocus                     '回収予定日項目へ移動
    ''    End If
    ''    txt_kaidt.SelLength = 1
    ''End Sub
    ''
    '''回収予定日項目にフォーカスが移った時
    ''Private Sub txt_kaidt_GotFocus()
    ''    '日付の十の位を選択状態にする
    ''    txt_kaidt.SelStart = 8
    ''    txt_kaidt.SelLength = 1
    ''    '背景色を黄色にする
    ''    txt_kaidt.BackColor = vbYellow
    ''    '検索処理を実行可能とする
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''回収予定日項目でキーを押した時
    ''Private Sub txt_kaidt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''
    ''    '右矢印 or Space押下時
    ''    If KEYCODE = vbKeyRight Or KEYCODE = vbKeySpace Then
    ''        If txt_kaidt.SelStart < 9 Then
    ''            txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''            'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''            If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''                txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''            End If
    ''
    ''        'カーソルが右端に来たら次の項目へ移動
    ''        Else
    ''            intChkKb = 2                        '★日付の入力チェック（変更時のみ)
    ''            txt_kesikb.SetFocus                 '消込済ﾃﾞｰﾀ表示項目へ移動
    ''        End If
    ''        txt_kaidt.SelLength = 1
    ''
    ''    'Backspace or 左矢印押下時
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_kaidt.SelStart > 0 Then
    ''            txt_kaidt.SelStart = txt_kaidt.SelStart - 1
    ''            'スラッシュにカーソルがきたら前の文字にカーソルを移動
    ''            If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''                txt_kaidt.SelStart = txt_kaidt.SelStart - 1
    ''            End If
    ''
    ''        'カーソルが左端に来たら前の項目へ移動
    ''        Else
    ''            intChkKb = 2                        '★日付の入力チェック（変更時のみ)
    ''            txt_tokseicd.SetFocus               '請求先ｺｰﾄﾞ項目へ移動
    ''        End If
    ''        txt_kaidt.SelLength = 1
    ''
    ''    '上矢印押下時
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        intChkKb = 2                            '★日付の入力チェック（変更時のみ)
    ''        txt_tokseicd.SetFocus                   '請求先ｺｰﾄﾞ項目へ移動
    ''
    ''    '下矢印押下時
    ''    ElseIf KEYCODE = vbKeyDown Then
    ''        intChkKb = 2                            '★日付の入力チェック（変更時のみ)
    ''        txt_kesikb.SetFocus                     '消込済ﾃﾞｰﾀ表示項目へ移動
    ''
    ''    'Enter押下時
    ''    ElseIf KEYCODE = vbKeyReturn Then
    ''        intChkKb = 1                            '★日付の入力チェック
    ''        txt_kesikb.SetFocus                     '消込済ﾃﾞｰﾀ表示項目へ移動
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''回収予定日項目でキーを押した時
    ''Private Sub txt_kaidt_KeyPress(KeyAscii As Integer)
    ''    '数値のみ入力可とする
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''回収予定日項目からフォーカスが移った時
    ''Private Sub txt_kaidt_LostFocus()
    ''    '入力チェック
    ''    chkKaidt
    ''    '背景色を白に戻す
    ''    txt_kaidt.BackColor = vbWhite
    ''End Sub
    '// V2.00↑ DEL


    '=======================================================消込済みﾃﾞｰﾀ表示=======================================================


    '消込済みﾃﾞｰﾀ表示項目を変更した時
    'UPGRADE_WARNING: イベント txt_kesikb.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_kesikb_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.TextChanged
        If CDbl(txt_kesikb.Text) <> 9 Then
            txt_kesikb.Text = CStr(1)
        End If
        txt_kesikb.SelectionStart = 0
        txt_kesikb.SelectionLength = 1
        '// V2.00↓ ADD
        If CDbl(txt_kesikb.Text) = 1 Then
            'UPGRADE_WARNING: オブジェクト cmd_kaidt_From.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            cmd_kaidt_From.Text = " 売上日(開始)"
        Else
            'UPGRADE_WARNING: オブジェクト cmd_kaidt_From.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            cmd_kaidt_From.Text = " *売上日(開始)"
        End If
        '// V2.00↑ ADD
    End Sub

    '消込済みﾃﾞｰﾀ表示項目にフォーカスが移った時
    Private Sub txt_kesikb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Enter
        '選択状態にする
        txt_kesikb.SelectionStart = 0
        txt_kesikb.SelectionLength = 1
        '背景色を黄色にする
        txt_kesikb.BackColor = System.Drawing.Color.Yellow

        '検索処理を実行不可とする
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = False
        Button5.Enabled = False
        '2019/04/26 CHG E N D
    End Sub

    '消込済みﾃﾞｰﾀ表示項目でキーを押した時
    Private Sub txt_kesikb_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesikb.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '// V2.00↓ ADD
        'ファンクションキー押下時
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00↑ ADD

        '上矢印 or 左矢印押下時
        If KeyCode = System.Windows.Forms.Keys.Up Or KeyCode = System.Windows.Forms.Keys.Left Then
            txt_kaidt_To.Focus()

            'Enter or 下矢印 or 右矢印押下時
        ElseIf KeyCode = System.Windows.Forms.Keys.Return Or KeyCode = System.Windows.Forms.Keys.Down Or KeyCode = System.Windows.Forms.Keys.Right Then
            '請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
            'それ以外は消込対象を検索
            If blnFriEnabled = True Then
                txt_fridt.Focus()
            Else
                'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'spd_body.SetFocus()
                spd_body.Focus()
                '2019/04/22 CHG E N D

            End If
            '// V2.00↓ UPD
            'TAB押
        ElseIf KeyCode = System.Windows.Forms.Keys.F16 Then
            '請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
            'それ以外は消込対象を検索
            If blnFriEnabled = True Then
                txt_fridt.Focus()
            Else
                'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'spd_body.SetFocus()
                spd_body.Focus()
                '2019/04/22 CHG E N D
            End If
            '// V2.00↑ UPD

            '// V2.00↓ UPD
            'TAB押
        ElseIf KeyCode = System.Windows.Forms.Keys.F15 Then
            txt_kaidt_To.Focus()
            '// V2.00↑ UPD

        End If

        KeyCode = 0
    End Sub

    '消込済みﾃﾞｰﾀ表示項目でキーを押した時
    Private Sub txt_kesikb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesikb.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '数値のみ入力可とする
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '消込済みﾃﾞｰﾀ表示項目からフォーカスが移った時
    Private Sub txt_kesikb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Leave
        '背景色を白に戻す
        txt_kesikb.BackColor = System.Drawing.Color.White
    End Sub

    '// V2.00↓ DEL
    '''=======================================================振込期日=======================================================
    ''
    ''
    '''振込期日項目を変更した時
    ''Private Sub txt_fridt_Change()
    ''    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    ''    If blnUsableEvent = False Then Exit Sub
    ''
    ''    '文字列が8文字になったらスラッシュを自動作成
    ''    If Len(Trim(txt_fridt.Text)) = 8 Then
    ''        blnUsableEvent = False
    ''
    ''        txt_fridt.Text = Left(txt_fridt.Text, 4) & "/" & Mid(txt_fridt.Text, 5, 2) & "/" & Right(txt_fridt.Text, 2)
    ''        intChkKb = 1                            '★日付の入力チェック
    ''        spd_body.SetFocus
    ''
    ''        blnUsableEvent = True
    ''
    ''    ElseIf Len(txt_fridt.Text) = 10 Then
    ''        'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''        If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''        ElseIf txt_fridt.SelStart = 10 Then
    ''            intChkKb = 1                        '★日付の入力チェック
    ''            spd_body.SetFocus
    ''        End If
    ''    End If
    ''    txt_fridt.SelLength = 1
    ''End Sub
    ''
    '''振込期日項目にフォーカスが移った時
    ''Private Sub txt_fridt_GotFocus()
    '''// V2.00↓ UPD
    '''    '日付の十の位を選択状態にする
    '''    txt_fridt.SelStart = 0
    '''    txt_fridt.SelLength = 1
    ''    If Trim(txt_fridt) = "" Then
    ''        'なにも入っていないので最初へ位置づけ
    ''        txt_fridt.SelStart = 0
    ''        txt_fridt.SelLength = 1
    ''    Else
    ''        'なにか入っていたら日付の十の位を選択状態にする
    ''        txt_fridt.SelStart = 8
    ''        txt_fridt.SelLength = 1
    ''    End If
    '''// V2.00↑ UPD
    ''    '背景色を黄色にする
    ''    txt_fridt.BackColor = vbYellow
    ''    '検索処理を実行可能とする
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''振込期日項目でキーを押した時
    ''Private Sub txt_fridt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''
    ''    '右矢印押下時
    ''    If KEYCODE = vbKeyRight Then
    ''        If txt_fridt.SelStart < 9 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''            'スラッシュにカーソルがきたら次の文字にカーソルを移動
    ''            If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''                txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''            End If
    ''
    ''        'カーソルが右端に来たら次の項目へ移動
    ''        Else
    ''            intChkKb = 1                    '★日付の入力チェック（変更時のみ)
    ''            spd_body.SetFocus
    ''        End If
    ''        txt_fridt.SelLength = 1
    ''
    ''    'Backspace or 左矢印押下時
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_fridt.SelStart > 0 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart - 1
    ''            'スラッシュにカーソルがきたら前の文字にカーソルを移動
    ''            If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''                txt_fridt.SelStart = txt_fridt.SelStart - 1
    ''            End If
    ''
    ''        'カーソルが左端に来たら前の項目へ移動
    ''        Else
    ''            intChkKb = 2                    '★日付の入力チェック（変更時のみ)
    ''            txt_kesikb.SetFocus
    ''        End If
    ''        txt_fridt.SelLength = 1
    ''
    ''    '上矢印押下時
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        intChkKb = 2                        '★日付の入力チェック（変更時のみ)
    ''        txt_kesikb.SetFocus
    ''
    ''    'Enter or 下矢印押下時
    ''    ElseIf KEYCODE = vbKeyReturn Or KEYCODE = vbKeyDown Then
    ''        intChkKb = 1                        '★日付の入力チェック
    ''        spd_body.SetFocus
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''振込期日項目でキーを押した時
    ''Private Sub txt_fridt_KeyPress(KeyAscii As Integer)
    ''    '数値のみ入力可とする
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''振込期日項目からフォーカスが移った時
    ''Private Sub txt_fridt_LostFocus()
    '''DEL START FKS)INABA 2007/05/25 ******************
    '''    '入力チェック
    '''    chkFridt
    '''
    '''    '背景色を白に戻す
    '''    txt_fridt.BackColor = vbWhite
    '''DEL  END  FKS)INABA 2007/05/25 ******************
    ''End Sub
    '// V2.00↑ DEL



    '=======================================================明細部(スプレッド)=======================================================

    'フォーカス取得時
    Private Sub spd_body_GotFocus()
        '// V2.00↓ ADD
        If intInputMode <> 1 Then
            Exit Sub
        End If
        '// V2.00↑ ADD
        'ﾎﾞﾀﾝが使用可能(明細ﾃﾞｰﾀあり)の時は実行しないCOL_MINYUKN
        If blnUsableButton = True Then Exit Sub

        'ヘッダが入力されていたらデータを検索・表示する
        If chkCondition() = True Then
            '// V2.00↓ ADD
            intInputMode = 2
            '// V2.00↑ ADD
            showBody() '★ﾃﾞｰﾀ表示
            '2007/11/26 FKS)minamoto ADD START
            '返品を消込し、ロック
            lockHenpin()
            '2007/11/26 FKS)minamoto ADD END
        End If
    End Sub

    '明細ﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub spd_body_ButtonClicked(ByVal Col As Integer, ByVal Row As Integer, ByVal ButtonDown As Short)

        Dim intKesizan As Decimal 'ヘッダ部消込残額
        Dim intKomikn As Decimal '税込売上額
        Dim intKesikn As Decimal '消込額
        Dim intBfKesikn As Decimal '消込額(締日前)
        Dim tmp As Object
        'ADD START FKS)INABA 2007/07/30 **********************************
        Dim LS_HYFRIDT As Object
        'ADD  END  FKS)INABA 2007/07/30 **********************************
        '2007/11/26 FKS)minamoto ADD START
        Dim sumHenpin As Decimal
        Dim intJDNNOKesikn As Decimal
        Dim intHenkn As Decimal
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short
        Dim idxRowJDNNO As Integer
        '2007/11/26 FKS)minamoto ADD END

        '2009/09/27 ADD START RISE)MIYAJIMA
        Dim vntTmp As Object
        '2009/09/27 ADD E.N.D RISE)MIYAJIMA

        '// V2.00↓ ADD
        'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
        If blnUsableSpread = False Then
            Exit Sub
        End If
        '// V2.00↑ ADD

        On Error Resume Next
        '// V2.00↓ DEL
        ''''    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
        ''''    If blnUsableSpread = False Then Exit Sub
        '// V2.00↑ DEL

        With spd_body
            'ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ時、明細の金額、ヘッダの残金額に応じてチェックのON、OFFを行う
            '2019/05/09 CHG START
            'If Col = 1 Then
            If Col = COL_CHK Then
                '2019/05/09 CHG E N D

                '2019/04/22 DEL START
                ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Col = Col
                ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Row = Row

                '表示行以上の行をクリックした時はチェックはつけない
                If Row > intMaxRow Then
                    'ﾁｪｯｸ解除しない
                    blnUsableSpread = False
                    'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    '.Value = 0
                    .SetValue(Row, Col, False)
                    '2019/04/22 CHG E N D
                    blnUsableSpread = True
                    Exit Sub
                End If

                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKesizan = SSSVal((txt_kesizan.Text))

                '税込売上額を取得
                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KOMIKN, .Row, tmp)
                tmp = .GetValue(Row, COL_KOMIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKomikn = SSSVal(tmp)
                '// V2.00↓ UPD
                ''''            '明細部消込額 - 締日以前消込額
                ''''            Call .GetText(COL_KESIKN, .Row, tmp)
                ''''            intKesikn = SSSVal(tmp)
                ''''            '締日以前消込額
                ''''            Call .GetText(COL_BFKESIKN, .Row, tmp)
                ''''            intBfKesikn = SSSVal(tmp)
                '// V2.01↓ UPD
                '            '前消込額
                '            Call .GetText(COL_KESIKN_MAE, .Row, tmp)
                '            intKesikn = SSSVal(tmp)
                '明細部消込額
                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, .Row, tmp)
                tmp = .GetValue(Row, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKesikn = SSSVal(tmp)
                '// V2.01↑ UPD
                '// V2.00↑ UPD

                'ﾁｪｯｸが付いていて、解除した時
                If ButtonDown = 0 Then
                    '2008/07/31 DEL START FKS)NAKATA
                    'XX
                    'XX            '2007/11/26 FKS)minamoto CHG START
                    'XX            '    '解除額がプラスであれば、無条件にヘッダ部に加算
                    'XX            '    If intKesikn - intBfKesikn > 0 Then
                    'XX            '        txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    'XX            '        .SetText COL_KESIKN, .Row, intBfKesikn
                    'XX'ADD START FKS)INABA 2007/07/30 **********************************
                    'XX            '        If DB_TOKMTA2.SHAKB Like "[256]" Then
                    'XX            '            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    'XX            '            If Trim$(LS_HYFRIDT) <> "" Then
                    'XX            '                .SetText COL_HYFRIDT, .Row, ""
                    'XX            '            End If
                    'XX            '        End If
                    'XX'ADD  END  FKS)INABA 2007/07/30 **********************************
                    'XX            '    ElseIf intKesizan >= intBfKesikn - intKesikn Then
                    'XX            '        txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    'XX            '        .SetText COL_KESIKN, .Row, intBfKesikn
                    'XX
                    'XX
                    'XX                '返品であればチェック解除しない
                    'XX                If intKesikn < 0 Then
                    'XX                    blnUsableSpread = False
                    'XX                    .Value = 1
                    'XX                    blnUsableSpread = True
                    'XX                    '受注番号取得
                    'XX
                    'XX                    Exit Sub
                    'XX                End If
                    'XX
                    'XX
                    'XX                Call .GetText(COL_HYJDNNO, .Row, tmp)
                    'XX                strHYJDNNO = CStr(tmp)
                    'XX                '返品額クリア
                    'XX
                    'XX                sumHenpin = 0
                    'XX                '同一受注番号の返品を検索
                    'XX
                    'XX                For idxRowJDNNO = intMaxRow To 1 Step -1
                    'XX                    .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                    'XX                    str_theHYJDNNO = CStr(tmp)
                    'XX                    '受注番号一致
                    'XX
                    'XX                    If strHYJDNNO <> str_theHYJDNNO Then
                    'XX                    Else
                    'XX                        '自分自身でない
                    'XX                        If idxRowJDNNO = .Row Then
                    'XX                        Else
                    'XX                            '入金済額を取得
                    'XX
                    'XX                            Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                    'XX                            intJDNNOKesikn = SSSVal(tmp)
                    'XX                            '返品の場合
                    'XX
                    'XX
                    'XX                            If intJDNNOKesikn < 0 Then
                    'XX                                '返品総額を求める
                    'XX                                sumHenpin = sumHenpin - intJDNNOKesikn
                    'XX                                '返品額より大きい場合は解除しない
                    'XX
                    'XX
                    'XX                                End If
                    'XX                       End If
                    'XX                    End If
                    'XX                Next idxRowJDNNO
                    'XX
                    'XX
                    'XX
                    'XX                If sumHenpin > intKesikn - intBfKesikn Then
                    'XX                    'ﾁｪｯｸ解除しない
                    'XX
                    'XX                    blnUsableSpread = False
                    'XX                    .Value = 1
                    'XX                    blnUsableSpread = True
                    'XX                    Exit Sub
                    'XX                End If
                    'XX
                    'XX
                    'XX                '返品額を残して差し引く
                    'XX                intHenkn = intKesikn - intBfKesikn - sumHenpin
                    'XX                txt_kesizan.Text = Format(intKesizan + intHenkn, "###,###,##0")
                    'XX                .SetText COL_KESIKN, .Row, intKesikn - intHenkn
                    'XX
                    'XX
                    'XX
                    'XX                'チェック解除
                    'XX                blnUsableSpread = False
                    'XX                .Value = 0
                    'XX                blnUsableSpread = True
                    'XX            '2007/11/26 FKS)minamoto CHG END
                    'XX'ADD START FKS)INABA 2007/07/30 **********************************
                    'XX                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                    'XX                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    'XX                        If Trim$(LS_HYFRIDT) <> "" Then
                    'XX                            .SetText COL_HYFRIDT, .Row, ""
                    'XX                        End If
                    'XX                    End If
                    'XX'ADD  END  FKS)INABA 2007/07/30 **********************************
                    'XX            '2007/11/26 FKS)minamoto DEL START
                    'XX            '    Else
                    'XX            '        'ﾁｪｯｸ解除しない
                    'XX            '        blnUsableSpread = False
                    'XX            '        .Value = 1
                    'XX            '        blnUsableSpread = True
                    'XX            '    End If
                    'XX            '2007/11/26 FKS)minamoto DEL END
                    'XX
                    '2008/07/31 DEL E.N.D FKS)NAKATA

                    '2019/05/09 ADD START
                    .SetValue(Row, Col, False)
                    '2019/05/09 ADD E N D

                    '2008/07/31 ADD START FKS)NAKATA
                    '解除額がプラスであれば、無条件にヘッダ部に加算
                    If intKesikn - intBfKesikn > 0 Then
                        txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intBfKesikn)
                        .SetValue(Row, COL_KESIKN, intBfKesikn)
                        '2019/04/22 CHG E N D
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                        LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(LS_HYFRIDT) <> "" Then
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, "")
                            .SetValue(Row, COL_HYFRIDT, "")
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA

                    ElseIf intKesizan >= intBfKesikn - intKesikn Then
                        txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intBfKesikn)
                        .SetValue(Row, COL_KESIKN, intBfKesikn)
                        ''2019/04/22 CHG E N D

                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                        LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                        '2019/04/22 CHG E N D

                        'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(LS_HYFRIDT) <> "" Then
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, "")
                            .SetValue(Row, COL_HYFRIDT, "")
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA

                    Else
                        'ﾁｪｯｸ解除しない
                        blnUsableSpread = False
                        'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.Value = 1
                        .SetValue(Row, Col, True)
                        '2019/04/22 CHG E N D

                        blnUsableSpread = True
                    End If
                    '2008/07/31 ADD E.N.D FKS)NAKATA

                    'ﾁｪｯｸが付いていなくて、チェックを入れた時
                ElseIf ButtonDown = 1 Then
                    '2007/11/26 FKS)minamoto CHG START
                    '消込額がマイナスであれば、無条件にヘッダ部に加算
                    'If intKomikn - intKesikn < 0 Then
                    '    txt_kesizan.Text = Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                    '    .SetText COL_KESIKN, .Row, intKomikn
                    'ADD START FKS)INABA 2007/07/30 **********************************
                    '    If DB_TOKMTA2.SHAKB Like "[256]" Then
                    '        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    '
                    '        If Trim$(LS_HYFRIDT) = "" Then
                    '            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                    '        End If
                    '    End If
                    'ADD  END  FKS)INABA 2007/07/30 **********************************
                    'ヘッダ消込残が負の時はチェックをつけない
                    'ElseIf intKesizan <= 0 Then

                    '2019/05/09 ADD START
                    .SetValue(Row, Col, True)
                    '2019/05/09 ADD E N D

                    '2008/07/31 ADD START FKS)NAKATA
                    '消込額がマイナスであれば､無条件にヘッダ部に加算
                    If intKomikn - intKesikn < 0 Then
                        txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKomikn)
                        .SetValue(Row, COL_KESIKN, intKomikn)
                        '2019/04/22 CHG E N D
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: オブジェクト vntTmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        'ヘッダ消込残が負の時はチェックをつけない
                    ElseIf intKesizan <= 0 Then

                        'XX                If intKesizan <= 0 Then
                        'XX                '2007/11/26 FKS)minamoto CHG END
                        '2008/07/31 ADD E.N.D FKS)NAKATA

                        blnUsableSpread = False
                        'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.Value = 0
                        .SetValue(Row, Col, False)
                        '2019/04/22 CHG E N D
                        blnUsableSpread = True

                    ElseIf intKesizan >= intKomikn - intKesikn Then
                        txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKomikn)
                        .SetValue(Row, COL_KESIKN, intKomikn)
                        '2019/04/22 CHG E N D
                        'ADD START FKS)INABA 2007/07/30 **********************************
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: オブジェクト vntTmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        'M                    End If
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        'ADD  END  FKS)INABA 2007/07/30 **********************************

                    Else
                        txt_kesizan.Text = VB6.Format(0, "###,###,##0")
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKesikn + intKesizan)
                        .SetValue(Row, COL_KESIKN, intKesikn + intKesizan)
                        '2019/04/22 CHG E N D
                        'ADD START FKS)INABA 2007/07/30 **********************************
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: オブジェクト vntTmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        'ADD  END  FKS)INABA 2007/07/30 **********************************
                    End If
                End If
            End If
        End With
    End Sub

    '手数料ﾎﾞﾀﾝ実行時
    Private Sub cmd_tesuryo_Click()

        '// V3.30↓ ADD
        Dim tmp As Object
        Dim intchk As Integer
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer

        Dim kesizan As Decimal 'ヘッダ部消込残額
        Dim kesikn As Decimal '明細行の入金済額
        '// V3.30↑ ADD


        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '●差額入金画面の表示
        VB6.ShowForm(FR_SSSSUB, (VB6.FormShowConstants.Modal))

        '// V2.00↓ ADD
        'ヘッダ情報の再表示
        showHead()
        '// V2.00↑ ADD

        '2009/10/22 ADD START RISE)MIYAJIMA
        Dim kesikn_ATO As Decimal '明細行の入金済額(後)
        Dim kesikn_MAE As Decimal '明細行の入金済額(後)
        With spd_body
            'ヘッダ部消込残額の退避
            kesizan = CDec(txt_kesizan.Text)
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '消込額の取得
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                kesikn_ATO = kesikn_ATO + CDec(tmp)
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                kesikn_MAE = kesikn_MAE + CDec(tmp)
            Next idxRow
            kesizan = kesizan + kesikn_MAE - kesikn_ATO
            txt_kesizan.Text = VB6.Format(kesizan, "###,###,##0")
        End With
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

        '2009/09/24 DEL START RISE)MIYAJIMA
        ''// V3.30↓ ADD
        '    'ヘッダ部消込残額の退避
        '    kesizan = txt_kesizan.Text
        '
        '    With spd_body
        '        For idxRow = 1 To intMaxRow
        '            'チェックが入っているかを確認
        '            .GetText COL_CHK, idxRow, tmp
        '            intchk = SSSVal(tmp)
        '
        '            'チェックが入っている場合
        '            If intchk = 1 Then
        '                '消込額の取得
        '                Call .GetText(COL_KESIKN, idxRow, tmp)
        '                kesikn = kesikn + CCur(tmp)
        '            End If
        '
        '       Next idxRow
        '    End With
        '
        '    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
        ''// V3.30↑ ADD
        '2009/09/24 DEL E.N.D RISE)MIYAJIMA

    End Sub

    '消費税額ﾎﾞﾀﾝ実行時
    Private Sub cmd_syohi_Click()

        '// V3.30↓ ADD
        Dim tmp As Object
        Dim intchk As Integer
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer

        Dim kesizan As Decimal 'ヘッダ部消込残額
        Dim kesikn As Decimal '明細行の入金済額
        '// V3.30↑ ADD

        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '●差額入金画面の表示
        VB6.ShowForm(FR_SSSSUB, (VB6.FormShowConstants.Modal))

        '// V2.00↓ ADD
        'ヘッダ情報の再表示
        showHead()
        '// V2.00↑ ADD

        '2009/10/22 ADD START RISE)MIYAJIMA
        Dim kesikn_ATO As Decimal '明細行の入金済額(後)
        Dim kesikn_MAE As Decimal '明細行の入金済額(後)
        With spd_body
            'ヘッダ部消込残額の退避
            kesizan = CDec(txt_kesizan.Text)
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '消込額の取得
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                kesikn_ATO = kesikn_ATO + CDec(tmp)
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                kesikn_MAE = kesikn_MAE + CDec(tmp)
            Next idxRow
            kesizan = kesizan + kesikn_MAE - kesikn_ATO
            txt_kesizan.Text = VB6.Format(kesizan, "###,###,##0")
        End With
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

        '2009/09/24 DEL START RISE)MIYAJIMA
        ''// V3.30↓ ADD
        '    'ヘッダ部消込残額の退避
        '    kesizan = txt_kesizan.Text
        '
        '    With spd_body
        '        For idxRow = 1 To intMaxRow
        '            'チェックが入っているかを確認
        '            .GetText COL_CHK, idxRow, tmp
        '            intchk = SSSVal(tmp)
        '
        '            'チェックが入っている場合
        '            If intchk = 1 Then
        '                '消込額の取得
        '                Call .GetText(COL_KESIKN, idxRow, tmp)
        '                kesikn = kesikn + CCur(tmp)
        '            End If
        '
        '       Next idxRow
        '    End With
        '
        '    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
        ''// V3.30↑ ADD
        '2009/09/24 DEL E.N.D RISE)MIYAJIMA


    End Sub

    '全消込ﾎﾞﾀﾝ実行時
    Private Sub cmd_zenkesi_Click()
        Dim i As Short
        Dim varKesikn As Object

        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '2008/07/25 ADD START FKS)NAKATA
        ''全消込ボタンを押下時は、初期表示時と同じ消込対象にチェックを入れる。
        lockHenpin()
        '2008/07/25 ADD E.N.D FKS)NAKATA

        '全行に対し、ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸ
        '2019/04/25 CHG START
        'For i = 1 To intMaxRow
        For i = 0 To intMaxRow - 1
            '2019/04/25 CHG E N D
            With spd_body
                '2019/04/22 CHG START
                ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Col = COL_CHK
                ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Row = i
                ''UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'If .Value = 0 Then
                '    '全消込時にチェックが入らない不具合を修正 2007/02/28 Saito
                '    spd_body_ButtonClicked(COL_CHK, i, 1)
                '    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .GetText(COL_KESIKN, i, varKesikn)
                '    'UPGRADE_WARNING: オブジェクト SSSVal(varKesikn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    If SSSVal(varKesikn) <> 0 Then
                '        blnUsableSpread = False
                '        'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        .Value = 1
                '        blnUsableSpread = True
                '    End If
                'End If
                If .Rows(i).Cells(COL_CHK).Value = False Then
                    '全消込時にチェックが入らない不具合を修正 
                    spd_body_ButtonClicked(COL_CHK, i, 1)
                    varKesikn = .GetValue(i, COL_KESIKN)
                    If SSSVal(varKesikn) <> 0 Then
                        blnUsableSpread = False
                        .SetValue(i, COL_CHK, True)
                        blnUsableSpread = True
                    End If
                End If
                '2019/04/22 CHG E N D
            End With
        Next i

    End Sub

    '全解除ﾎﾞﾀﾝ実行時
    Private Sub cmd_zenkaijo_Click()
        Dim i As Short
        Dim varKesikn As Object
        Dim varBfKesikn As Object

        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '全行に対し、ﾁｪｯｸﾎﾞｯｸｽの解除
        '2019/04/25 CHG START
        'For i = 1 To intMaxRow
        For i = 0 To intMaxRow - 1
            '2019/04/25 CHG E N D
            With spd_body
                '2019/04/22 CHG START
                ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Col = COL_CHK
                ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.Row = i
                ''UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'If .Value = 1 Then
                '    '解除時にチェックが外れない不具合を修正 2007/02/28 Saito
                '    spd_body_ButtonClicked(COL_CHK, i, 0)

                '    '2008/07/31 CHG START FKS)NAKATA
                '    'XX 返品をロックしなくなったため削除を解除

                '    '2007/11/26 FKS)minamoto DEL START
                '    '.GetText COL_KESIKN, i, varKesikn
                '    '.GetText COL_BFKESIKN, i, varBfKesikn
                '    'If SSSVal(varKesikn) - SSSVal(varBfKesikn) = 0 Then
                '    '    blnUsableSpread = False
                '    '    .Value = 0
                '    '    blnUsableSpread = True
                '    'End If
                '    '2007/11/26 FKS)minamoto DEL END

                '    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .GetText(COL_KESIKN, i, varKesikn)
                '    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .GetText(COL_BFKESIKN, i, varBfKesikn)
                '    '// V2.02↓ UPD
                '    ''''                If SSSVal(varKesikn) - SSSVal(varBfKesikn) = 0 Then
                '    'UPGRADE_WARNING: オブジェクト SSSVal(varKesikn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    If SSSVal(varKesikn) = 0 Then
                '        '// V2.02↑ UPD
                '        blnUsableSpread = False
                '        'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        .Value = 0
                '        blnUsableSpread = True
                '    End If
                '    '2008/07/31 CHG E.N.D FKS)NAKATA
                'End If

                If .Rows(i).Cells(COL_CHK).Value Then

                    spd_body_ButtonClicked(COL_CHK, i, 0)

                    varKesikn = .GetValue(i, COL_KESIKN)

                    varBfKesikn = .GetValue(i, COL_BFKESIKN)

                    If SSSVal(varKesikn) = 0 Then
                        blnUsableSpread = False

                        .SetValue(i, COL_CHK, False)
                        blnUsableSpread = True
                    End If
                End If
                '2019/04/22 CHG E N D
            End With
        Next i
    End Sub

    '再表示ﾎﾞﾀﾝ実行時
    Private Sub cmd_saihyoji_Click()
        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '// V2.00↓ ADD
        If ChkInputChange() = True Then
            If showMsg("1", "URKET53_040", CStr(0)) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        '// V2.00↑ ADD

        'ヘッダ情報の再表示
        '// V2.00↓ DEL
        ''''    showHead
        '// V2.00↑ DEL
        '// V2.00↓ ADD
        'ヘッダが入力されていたらデータを検索・表示する
        If chkCondition() = True Then
            '// V2.00↓ ADD
            intInputMode = 2
            '// V2.00↑ ADD
            showBody() '★ﾃﾞｰﾀ表示
            '2007/11/26 FKS)minamoto ADD START
            '返品を消込し、ロック
            lockHenpin()
            '2007/11/26 FKS)minamoto ADD END
        End If
        '// V2.00↑ ADD
    End Sub

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    連絡票№CF10042801
    Private Sub cmd_csvout_Click()
        Dim bolRet As Boolean
        Dim intRet As Short
        Dim strSavePath As String

        On Error GoTo Exit_Handler

        'ﾌﾗｸﾞがたっていなければ実行しない
        If blnUsableButton = False Then Exit Sub

        '●登録確認のMSG
        If showMsg("1", "URKET53_045", "0") = MsgBoxResult.Yes Then
            '★権限の判断
            If gs_FILEAUTH = "9" And AUTHORITY_ENABLE = True Then
                Call showMsg("2", "FILEAUTH", "0")
                GoTo Exit_Handler
            End If

            'プロンプト表示領域にメッセージ出力
            img_light.Image = img_bklight(1).Image
            txt_message.Text = "作業中！ しばらくお待ちください。"

            'INIファイル読込処理
            bolRet = funcGetIni()
            If Not bolRet Then
                Call showMsg("2", "URKET53_046", "0") '●INIファイル読込エラーが発生しました。
                GoTo Exit_Handler
            End If

            '保存ダイアログを開く
            strSavePath = gv_strOUT_NAME
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Me.CommonDialog1.FileName = strSavePath 'ファイル名をデフォルトセット
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.DefaultExt の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Me.CommonDialog1.DefaultExt = gv_strOUT_TYPE 'ファイル拡張子の既定値
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.Filter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Me.CommonDialog1.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE
            'ファイルの種類のフィルタ
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.CancelError の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/18 DEL START
            'Me.CommonDialog1.CancelError = True 'キャンセルボタン押下時エラー生成
            '2019/04/18 DEL E N D
            Do
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.ShowSave の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/40/18 CHG START
                'Me.CommonDialog1.ShowSave() 'ダイアログを開く
                Me.CommonDialog1.ShowDialog()
                '2019/4/18 CHG E N D
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CommonDialog1.FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSavePath = Me.CommonDialog1.FileName '選択されたファイル名を変数に格納

                'ダイアログ画面でパスが取得できなかったとき(キャンセル時)は処理終了
                If strSavePath = "" Then
                    GoTo Exit_Handler
                End If

                '選択されたファイル名が存在する場合
                'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
                If Dir(strSavePath) <> "" Then
                    intRet = MsgBox(strSavePath & " は既に存在します。" & vbCrLf & "上書きしますか?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, SSS_PrgNm)
                    If intRet = MsgBoxResult.Yes Then
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Loop

            'CSV出力処理
            bolRet = funcOutPutCSV(strSavePath)
            If Not bolRet Then
                Call showMsg("2", "URKET53_047", "0") '●ＣＳＶ出力処理でエラーが発生しました。
                GoTo Exit_Handler
            Else
                Call showMsg("1", "URKET53_048", "0") '●処理を終了しました。
            End If
        End If

Exit_Handler:

        'ヒントの表示を初期化する
        img_light.Image = img_bklight(0).Image
        txt_message.Text = ""

    End Sub
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    '消込日ﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub cmd_kesidt_Click()
        If txt_kesidt.Enabled = False Then Exit Sub

        If Trim(txt_kesidt.Text) <> "" Then
            Set_date.Value = txt_kesidt.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        'カレンダーウィンドウを表示
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kesidt.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kesidt.Text = WLSDATE_RTNCODE
            intChkKb = 1 '★日付の入力チェック
            txt_tokseicd.Focus()
        End If
    End Sub

    '請求先ｺｰﾄﾞﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub cmd_tokseicd_Click()
        If txt_tokseicd.Enabled = False Then Exit Sub
        '2019/04/18 CHG START
        'WLS_TOK1.ShowDialog()
        'WLS_TOK1.Close()
        WLSTOK1.ShowDialog()
        WLSTOK1.Close()
        '2019/04/18 CHG E N D

        txt_tokseicd.Focus()
        '2019/04/24 CHG START
        'If WLSTOKSUB_RTNCODE <> "" Then
        '    txt_tokseicd.Text = WLSTOKSUB_RTNCODE
        If WLSTOK_RTNCODE <> "" Then
            txt_tokseicd.Text = WLSTOK_RTNCODE
            '// V2.00↓ UPD
            ''        txt_kaidt.SetFocus
            intChkKb = 1
            chkTokseicd()
            txt_kaidt_From.Focus()
            '// V2.00↑ UPD
        End If
    End Sub

    '回収日ﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub cmd_kaidt_From_Click()
        '// V2.00↓ UPD
        ''    If txt_kaidt.Enabled = False Then Exit Sub
        ''
        ''    If Trim(txt_kaidt.Text) <> "" Then
        ''        Set_date = txt_kaidt.Text
        ''    Else
        ''        Set_date = CNV_DATE(gstrUnydt)
        ''    End If
        ''
        ''    WLSDATE_RTNCODE = ""
        ''
        ''    'カレンダーウィンドウを表示
        ''    WLS_DATE.Show vbModal
        ''    Unload WLS_DATE
        ''
        ''    txt_kaidt.SetFocus
        ''    If WLSDATE_RTNCODE <> "" Then
        ''        txt_kaidt.Text = WLSDATE_RTNCODE
        ''        intChkKb = 1                   '★日付の入力チェック
        ''        txt_kesikb.SetFocus
        ''    End If
        If txt_kaidt_From.Enabled = False Then Exit Sub

        If Trim(txt_kaidt_From.Text) <> "" Then
            Set_date.Value = txt_kaidt_From.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        'カレンダーウィンドウを表示
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kaidt_From.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kaidt_From.Text = WLSDATE_RTNCODE
            intChkKb = 1 '★日付の入力チェック
            txt_kaidt_To.Focus()
        End If
        '// V2.00↑ UPD
    End Sub

    '// V2.00↓ ADD
    '回収日ﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub cmd_kaidt_To_Click()
        If txt_kaidt_To.Enabled = False Then Exit Sub

        If Trim(txt_kaidt_To.Text) <> "" Then
            Set_date.Value = txt_kaidt_To.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        'カレンダーウィンドウを表示
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kaidt_To.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kaidt_To.Text = WLSDATE_RTNCODE
            intChkKb = 1 '★日付の入力チェック
            txt_kesikb.Focus()
        End If
    End Sub
    '// V2.00↑ ADD

    '振込期日ﾎﾞﾀﾝｸﾘｯｸ時
    Private Sub cmd_fridt_Click()
        '振込期日が入力できない時はｲﾍﾞﾝﾄは実行しない
        If blnFriEnabled = False Then Exit Sub
        If txt_fridt.Enabled = False Then Exit Sub

        If Trim(txt_fridt.Text) <> "" Then
            If IsDate(txt_fridt.Text) = True Then
                Set_date.Value = txt_fridt.Text
            Else
                Set_date.Value = CNV_DATE(gstrUnydt.Value)
                txt_fridt.Text = ""
            End If
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        'カレンダーウィンドウを表示
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_fridt.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_fridt.Text = WLSDATE_RTNCODE
            intChkKb = 1 '★日付の入力チェック
            'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/22 CHG START
            'spd_body.SetFocus()
            spd_body.Focus()
            '2019/04/22 CHG E N D
        End If
    End Sub

    '2007/11/26 FKS)minamoto ADD START
    '返品消込
    Private Sub lockHenpin()
        Dim intKesizan As Decimal 'ヘッダ部消込残額
        Dim intKomikn As Decimal '税込売上額
        Dim intKesikn As Decimal '消込額
        Dim intBfKesikn As Decimal '消込額(締日前)
        Dim tmp As Object
        Dim LS_HYFRIDT As Object
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer
        Dim strFRIDT As String
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short

        On Error Resume Next
        '振込期日を取得

        strFRIDT = txt_fridt.Text
        '消込残額を取得

        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        intKesizan = SSSVal((txt_kesizan.Text))
        '返品を検索

        With spd_body

            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '税込売上額を取得

                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KOMIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KOMIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKomikn = SSSVal(tmp)
                '入金済額を取得

                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intKesikn = SSSVal(tmp)
                '締日以前消込額

                '// V2.03↓ UPD
                ''''            Call .GetText(COL_BFKESIKN, idxRow, tmp)
                ''''            intBfKesikn = SSSVal(tmp)
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                intBfKesikn = SSSVal(tmp)
                '// V2.03↑ UPD

                '消込額がマイナスであれば同一受注番号で相殺
                If intKomikn - intKesikn < 0 Then

                    '消込額を消込残額へ追加
                    intKesizan = intKesizan - (intKomikn - intKesikn)

                    '入金済額設定
                    'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    '.SetText(COL_KESIKN, idxRow, intKomikn)
                    .SetValue(idxRow, COL_KESIKN, intKomikn)
                    '2019/04/22 CHG E N D

                    'チェックボックス設定
                    blnUsableSpread = False
                    '2019/04/22 CHG START
                    ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Row = idxRow
                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Col = COL_CHK
                    ''UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Value = 1
                    .SetValue(idxRow, COL_CHK, True)
                    '2019/04/22 CHG E N D
                    blnUsableSpread = True

                    '// V2.03↓ ADD
                    'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .SetText(COL_HENPI, idxRow, "1")
                    .SetValue(idxRow, COL_HENPI, "1")
                    '2019/04/22 CHG E N D
                    '// V2.03↑ ADD

                    '受注番号取得
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYJDNNO)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strHYJDNNO = CStr(tmp)

                    '同一受注番号を検索
                    For idxRowJDNNO = intMaxRow To 1 Step -1
                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/22 CHG START
                        '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                        tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        str_theHYJDNNO = CStr(tmp)

                        '受注番号一致すれば相殺
                        If strHYJDNNO <> str_theHYJDNNO Then
                        Else
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/22 CHG START
                            '.GetText(COL_CHK, idxRowJDNNO, tmp)
                            tmp = .GetValue(idxRowJDNNO, COL_CHK)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/25 CHG START
                            'intchk = SSSVal(tmp)
                            intchk = SSSVal(IIf(tmp = True, 1, 0))
                            '2019/04/25 CHG E N D

                            '自分自身でない、またはチェックされていない
                            If idxRowJDNNO <> idxRow And intchk = 1 Then
                            Else

                                '税込売上額を取得
                                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KOMIKN)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                intKomikn = SSSVal(tmp)

                                '入金済額を取得
                                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KESIKN)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                intKesikn = SSSVal(tmp)

                                '締日以前消込額
                                '// V2.03↓ UPD
                                '2009/09/15 UPD START RISE)MIYAJIMA
                                '                            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KESIKN_MAE, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KESIKN_MAE)
                                '2019/04/22 CHG E N D
                                '2009/09/15 UPD E.N.D RISE)MIYAJIMA
                                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                intBfKesikn = SSSVal(tmp)
                                ''''                            Call .GetText(COL_BFKESIKN, idxRowJDNNO, tmp)
                                ''''                            intBfKesikn = SSSVal(tmp)
                                '// V2.03↑ UPD

                                '税込売上金額全額相殺
                                If intKesizan >= intKomikn - intKesikn Then

                                    '入金済額設定
                                    'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    '.SetText(COL_KESIKN, idxRowJDNNO, intKomikn)
                                    .SetValue(idxRowJDNNO, COL_KESIKN, intKomikn)
                                    '2019/04/22 CHG E N D

                                    'チェックボックス設定
                                    blnUsableSpread = False
                                    '2019/04/22 CHG START
                                    ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '.Row = idxRowJDNNO
                                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '.Col = COL_CHK
                                    ''UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '.Value = 1
                                    .SetValue(idxRowJDNNO, COL_CHK, True)
                                    '2019/04/22 CHG E N D
                                    blnUsableSpread = True

                                    '// V2.03↓ ADD
                                    'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    'Call .SetText(COL_HENPI, idxRowJDNNO, "1")
                                    .SetValue(idxRowJDNNO, COL_HENPI, "1")
                                    '2019/04/22 CHG E N D
                                    '// V2.03↑ ADD

                                    '消込残額設定
                                    intKesizan = intKesizan - (intKomikn - intKesikn)

                                    '振込期日設定
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    '                                If DB_TOKMTA2.SHAKB Like "[256]" Then
                                    'M                                If Trim(txt_fridt.Text) <> "" Then
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    '.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
                                    LS_HYFRIDT = .GetValue(idxRowJDNNO, COL_HYFRIDT)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    If Trim(LS_HYFRIDT) = "" Then
                                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/22 CHG START
                                        '.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
                                        .SetValue(idxRowJDNNO, COL_HYFRIDT, strFRIDT)
                                        '2019/04/22 CHG E N D
                                    End If
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    'M                               End If
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    '税込売上金額一部相殺
                                    '入金済額設定

                                Else

                                    'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    '.SetText(COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan)
                                    .SetValue(idxRowJDNNO, COL_KESIKN, intKesikn + intKesizan)
                                    '2019/04/22 CHG E N D
                                    'チェックボックス設定

                                    '2008/08/13 ADD START FKS)NAKATA
                                    ''消込残額がゼロの場合、チェックをつけない
                                    If intKesizan > 0 Then
                                        '2008/08/13 ADD E.N.D FKS)NAKATA

                                        blnUsableSpread = False
                                        '2019/04/22 CHG START
                                        ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '.Row = idxRowJDNNO
                                        ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '.Col = COL_CHK
                                        ''UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '.Value = 1
                                        .SetValue(idxRowJDNNO, COL_CHK, True)
                                        '2019/04/22 CHG E N D
                                        blnUsableSpread = True

                                        '// V2.03↓ ADD
                                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/22 CHG START
                                        'Call .SetText(COL_HENPI, idxRowJDNNO, "1")
                                        .SetValue(idxRowJDNNO, COL_HENPI, "1")
                                        '2019/04/22 CHG E N D
                                        '// V2.03↑ ADD

                                        '2008/08/13 ADD START FKS)NAKATA
                                    End If
                                    '2008/08/13 ADD E.N.D FKS)NAKATA


                                    '消込残額ゼロ
                                    intKesizan = 0

                                    '振込期日設定
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    '                                If DB_TOKMTA2.SHAKB Like "[256]" Then
                                    'M                                If Trim(txt_fridt.Text) <> "" Then
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    '.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
                                    LS_HYFRIDT = .GetValue(idxRowJDNNO, COL_HYFRIDT)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    If Trim(LS_HYFRIDT) = "" Then
                                        'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/22 CHG START
                                        '.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
                                        .SetValue(idxRowJDNNO, COL_HYFRIDT, strFRIDT)
                                        '2019/04/22 CHG E N D
                                        '消込残額を設定

                                    End If
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    'M                                End If
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                End If
                            End If
                        End If
                    Next idxRowJDNNO
                End If
            Next idxRow
        End With

        txt_kesizan.Text = VB6.Format(intKesizan, "###,###,##0")

    End Sub
    '2007/11/26 FKS)minamoto ADD END

    '2008/07/30 DEL START FKS)NAKATA
    '''2007/12/10 FKS)minamoto ADD START
    ''Function CHK_HAITA_UPD()
    ''    Dim idxRow    As Integer
    ''    Dim strSql  As String
    ''    Dim Usr_Ody As U_Ody
    ''
    ''    CHK_HAITA_UPD = 1
    ''    '受注伝票
    ''
    ''    For idxRow = 1 To intMaxRow
    ''
    ''        '売上トラン
    ''
    ''        strSql = ""
    ''        strSql = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM UDNTRA"
    ''        strSql = strSql + " WHERE DATNO = '" + HAITA_UDNTRA(idxRow).DATNO + "'"
    ''        strSql = strSql + "  AND LINNO = '" + HAITA_UDNTRA(idxRow).LINNO + "'"
    ''        'DBアクセス
    ''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''
    ''        If CF_Ora_EOF(Usr_Ody) = True Then
    ''            'エラー
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Call CF_Ora_CloseDyn(Usr_Ody)
    ''            Exit Function
    ''        End If
    ''        If Val(HAITA_UDNTRA(idxRow).WRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).WRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).UWRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).UWRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))) Then
    ''            'エラー
    ''            CHK_HAITA_UPD = 0
    ''            Call CF_Ora_CloseDyn(Usr_Ody)
    ''            Exit Function
    ''        End If
    ''        Call CF_Ora_CloseDyn(Usr_Ody)
    ''
    ''        '受注トラン
    ''
    ''        strSql = ""
    ''        strSql = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM JDNTRA"
    ''        strSql = strSql + " WHERE DATNO = '" + HAITA_JDNTRA(idxRow).DATNO + "'"
    ''        strSql = strSql + "  AND LINNO = '" + HAITA_JDNTRA(idxRow).LINNO + "'"
    ''        'DBアクセス
    ''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''        If CF_Ora_EOF(Usr_Ody) = True Then
    ''            'エラー
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Exit Function
    ''        End If
    ''        If Val(HAITA_JDNTRA(idxRow).WRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).WRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).UWRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).UWRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))) Then
    ''            'エラー
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Exit Function
    ''        End If
    ''        Call CF_Ora_CloseDyn(Usr_Ody)
    ''
    ''    Next idxRow
    ''
    ''End Function
    '''2007/12/10 FKS)minamoto ADD END
    '2008/07/30 DEL START FKS)NAKATA



    '2008/1/10 FKS)ichihara ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function getKuroTbl
    '   概要： 売上日以降の未消し込みの黒データを取得
    '   引数： strJdnNo   : 返品データの受注伝票番号
    '   　　： strJdnlinNo: 返品データの受注伝票行番号
    '   　　： strRecNo   : 返品データのレコード管理番号
    '   　　： strAKesiKb : 返品データの消込区分
    '   　　： strHenryu  : 返品データの返品理由
    '   　　： strHenj    : 返品データの返品状態
    '   　　： strUriDate :返品データの売上伝票日付
    '   戻値： チェック結果
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function getKuroTbl(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, ByVal strAKesiKb As String, ByVal strHenryu As String, ByVal strHenj As String, ByVal strUriDate As String) As Boolean

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_getKuroTbl

        getKuroTbl = False

        strSql = " SELECT JDNNO,KESIKB,UDNDT"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
        strSql = strSql & " AND     RECNO    =  '" & strRECNO & "'"
        strSql = strSql & " AND     UDNDT    <= '" & strUriDate & "'" '～返品した日まで
        strSql = strSql & " AND     HENRSNCD =  '" & strHenryu & "'" '返品理由
        strSql = strSql & " AND     HENSTTCD =  '" & strHenj & "'" '返品状態
        strSql = strSql & " AND     AKAKROKB =  '1'" '黒
        strSql = strSql & " ORDER BY UDNDT "

        '2019/04/18 CHG START
        ''DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''データが存在した場合
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    If gstrKaidt_To.Value < CF_Ora_GetDyn(Usr_Ody, "UDNDT", "") Then
        '        '画面に表示されない黒データの場合

        '        '赤（返品）も黒（売上）も消し込みされていない場合
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, KESIKB, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If (strAKesiKb <> "1" And CF_Ora_GetDyn(Usr_Ody, "KESIKB", "") <> "1") Then
        '            '赤を表示しない
        '            getKuroTbl = False
        '            GoTo END_getKuroTbl
        '        End If

        '        '赤（返品）も黒（売上）も消し込みされている場合
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, KESIKB, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If (strAKesiKb = "1" And CF_Ora_GetDyn(Usr_Ody, "KESIKB", "") = "1") Then
        '            '赤を表示しない
        '            getKuroTbl = False
        '            GoTo END_getKuroTbl
        '        End If
        '    End If
        '    'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Usr_Ody.Obj_Ody.MoveNext()
        'Loop
        'DBアクセス
        Dim dt As DataTable = DB_GetTable(strSql)

        'データが存在した場合
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If gstrKaidt_To.Value < DB_NullReplace(dt.Rows(0)("UDNDT"), "") Then
                    '画面に表示されない黒データの場合

                    '赤（返品）も黒（売上）も消し込みされていない場合
                    If (strAKesiKb <> "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") <> "1") Then

                        If (strAKesiKb <> "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") <> "1") Then
                            '赤を表示しない
                            getKuroTbl = False
                            GoTo END_getKuroTbl
                        End If

                        '赤（返品）も黒（売上）も消し込みされている場合
                        If (strAKesiKb = "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") = "1") Then
                            '赤を表示しない
                            getKuroTbl = False
                            GoTo END_getKuroTbl
                        End If

                    End If

                End If
            Next
        End If
        '2019/04/18 CHG E N D

        getKuroTbl = True

END_getKuroTbl:
        'クローズ
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D

        Exit Function

ERR_getKuroTbl:
        GoTo END_getKuroTbl

    End Function
    '2008/1/10 FKS)ichihara ADD END

    '2008/07/25 FKS) NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function chk_HENPIN
    '   概要： 締日をまたいで返品登録、受注訂正を行った際
    '          赤黒にて相殺される受注を表示しない
    '   引数： strJdnNo   : 受注伝票番号
    '   　　： strJdnlinNo: 受注伝票行番号
    '   　　： strRECNO   : レコード管理番号
    '       ： strWrtFstDt: 登録日
    '       ： strWrtFstTm: 登録時間
    '       ： strUritk   : 売上単価
    '       ： strUrikn   : 売上金額
    '   　　： strTokseicd: 請求先コード
    '   戻値： チェック結果
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    '''' UPD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    ''パラメータにRECNOを追加
    ''Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String) As Boolean
    'Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, _
    ''                                    ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String) As Boolean
    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    'パラメータにTOKSEICDを追加
    Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String, ByVal strTokseicd As String) As Boolean
        '''' UPD 2010/10/19  FKS) T.Yamamoto    End


        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: 構造体 Usr_Ody2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody2 As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkHENPIN

        chkHenpin = False

        strSql = " "
        strSql = " SELECT *"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & Trim(strJDNNO) & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & Trim(strJdnlinNo) & "'"
        strSql = strSql & " AND     DATKB =  '1'"
        strSql = strSql & " AND     AKAKROKB =  '9'"
        strSql = strSql & " AND     DKBID    =  '01'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
        strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    End

        '2019/04/18 CHG START
        'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''データが存在した場合
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    '消込されていない場合、処理を行う
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then

        '        '返品理由に値が格納されている売上を対象とする
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, DKBID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then

        '            '黒と赤のURIKNの差額が「0」になるのなら表示しない
        '            'If (CLng(strUrikn) + CLng(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            If CInt(strUrikn) = CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
        'DBアクセス
        Dim dt As DataTable = DB_GetTable(strSql)

        'データが存在した場合
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                '消込されていない場合、処理を行う
                If Trim(DB_NullReplace(dt.Rows(i)("KESIKB"), "")) <> "1" Then

                    '返品理由に値が格納されている売上を対象とする
                    If Trim(DB_NullReplace(dt.Rows(i)("HENRSNCD"), "")) <> "" And DB_NullReplace(dt.Rows(i)("DKBID"), "") = "01" Then

                        '黒と赤のURIKNの差額が「0」になるのなら表示しない
                        If CInt(strUrikn) = CInt(DB_NullReplace(dt.Rows(i)("URIKN"), "")) * (-1) Then
                            '2019/04/18 CHG E N D

                            chkHenpin = False
                            GoTo END_chkHENPIN
                        Else


                            'V3.00 2009/03/10 ADD START FKS)NAKATA
                            '
                            strSql = " "
                            strSql = " SELECT COUNT(*) AS CNT"
                            strSql = strSql & " FROM    UDNTRA"
                            strSql = strSql & " WHERE   JDNNO       =  '" & Trim(strJDNNO) & "'"
                            strSql = strSql & " AND     JDNLINNO    =  '" & Trim(strJdnlinNo) & "'"
                            strSql = strSql & " AND     DATKB       =  '1'"
                            strSql = strSql & " AND     AKAKROKB    =  '1'"
                            strSql = strSql & " AND     DKBID       =  '01'"
                            strSql = strSql & " AND     RECNO       =  '" & Trim(strRECNO) & "'"
                            strSql = strSql & " AND     URITK       !=   " & strUritk & " "
                            strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  >  '" & strWrtFstDt & strWrtFstTm & "'"
                            '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
                            strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
                            '''' ADD 2010/10/19  FKS) T.Yamamoto    End

                            '2019/04/18 CHG START
                            ''DBアクセス
                            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)

                            ''データが存在した場合
                            'Do While CF_Ora_EOF(Usr_Ody2) = False

                            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '    If CInt(CF_Ora_GetDyn(Usr_Ody2, "CNT", 0)) >= 1 Then
                            '        chkHenpin = False
                            '        Call CF_Ora_CloseDyn(Usr_Ody2)
                            '        GoTo END_chkHENPIN
                            '    Else
                            '        chkHenpin = True
                            '        Call CF_Ora_CloseDyn(Usr_Ody2)
                            '        GoTo END_chkHENPIN
                            '    End If
                            '    'UPGRADE_WARNING: オブジェクト Usr_Ody2.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '    Usr_Ody2.Obj_Ody.MoveNext()
                            'Loop
                            'DBアクセス
                            Dim dt2 As DataTable = DB_GetTable(strSql)

                            'データが存在した場合
                            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                                For j As Integer = 0 To dt2.Rows.Count - 1
                                    If CInt(DB_NullReplace(dt.Rows(j)("CNT"), 0)) >= 1 Then
                                        chkHenpin = False
                                        GoTo END_chkHENPIN
                                    Else
                                        chkHenpin = True
                                        GoTo END_chkHENPIN
                                    End If
                                Next
                            End If
                            'V3.00 2009/03/10 ADD E.N.D FKS)NAKATA
                        End If
                    End If

                End If

                '2019/04/18 CHG START
                '        'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '        Usr_Ody.Obj_Ody.MoveNext()
                'Loop
            Next
        End If
        '2019/04/18 CHG E N D

        chkHenpin = True

END_chkHENPIN:
        'クローズ
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_chkHENPIN:
        GoTo END_chkHENPIN

    End Function

    '2008/07/26 FKS) NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function chkHenpinTeisei
    '   概要： 締日をまたいで返品登録、受注訂正を行った際
    '          赤黒にて相殺される受注を表示しない
    '   引数： strJdnNo   : 受注伝票番号
    '   　　： strJdnlinNo: 受注伝票行番号
    '   　　： strUrikn   : 売上金額
    '   　　： strUdnno   : 売上伝票番号
    '   　　： strLinno   : 行番号
    '   　　： strUriDt   : 売上日
    '   　　： strTokseicd: 請求先コード
    '   戻値： チェック結果
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    連絡票№830
    ''''' UPD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
    ''Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, _
    '''                                ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String) As Boolean
    ''パラメータにTOKSEICDを追加
    'Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, _
    ''                            ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, _
    ''                            ByVal strTokseicd As String) As Boolean
    ''''' UPD 2010/10/19  FKS) T.Yamamoto    End
    'パラメータにDATNOを追加
    Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, ByVal strTokseicd As String, ByVal strDATNO As String) As Boolean
        '''' UPD 2011/06/13  FKS) T.Yamamoto    End

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkHenpinTeisei

        chkHenpinTeisei = False

        strSql = " "
        strSql = " SELECT *"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
        strSql = strSql & " AND     DATKB =  '1'"
        strSql = strSql & " AND     AKAKROKB =  '9'"
        '2008/08/30 ADD START FKS)NAKATA
        ''全数返品後売上対応
        strSql = strSql & " AND     DKBID =  '01'"
        '2008/08/30 ADD E.N.D FKS)NAKATA
        strSql = strSql & " AND     UDNNO  <>  '" & strUDNNO & "'"
        strSql = strSql & " AND     LINNO  =  '" & strLINNO & "'"
        '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    連絡票№830
        '訂正前のデータを表示しない
        '    strSql = strSql & " AND     UDNDT <>  '" & strURIDT & "'"
        strSql = strSql & " AND     MOTDATNO =  '" & Trim(strDATNO) & "'"
        '''' UPD 2011/06/13  FKS) T.Yamamoto    End
        '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    連絡票№FC10100601
        strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    End


        'DBアクセス
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''データが存在した場合
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    '消込されていない場合、処理を行う
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then

        '        '黒と赤のURIKNの差額が「0」になるのなら表示しない
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If (CInt(strUrikn) + CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                '消込されていない場合、処理を行う
                If Trim(DB_NullReplace(dt.Rows(i)("KESIKB"), "")) <> "1" Then

                    '黒と赤のURIKNの差額が「0」になるのなら表示しない
                    If (CInt(strUrikn) + CInt(DB_NullReplace(dt.Rows(i)("URIKN"), ""))) = 0 Then
                        '2019/04/18 CHG E N D

                        chkHenpinTeisei = False
                        GoTo END_chkHenpinTeisei
                    Else
                        chkHenpinTeisei = True
                        GoTo END_chkHenpinTeisei
                    End If

                End If

                '2019/04/18 CHG START
                ''UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Usr_Ody.Obj_Ody.MoveNext()
                'Loop
            Next
        End If
        '2019/04/18 CHG E N D

        chkHenpinTeisei = True

END_chkHenpinTeisei:
        'クローズ
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_chkHenpinTeisei:
        GoTo END_chkHenpinTeisei

    End Function
    '2008/07/26 ADD E.N.D FKS)NAKATA

    '2008/07/30 ADD START FKS)NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Sub chkAkaKro
    '   概要： 一部返品が存在する売上を消込する際、赤と黒を割り出し
    '　　　　  赤のみ消込される場合は、エラーメッセージを出す。
    '          黒のみ消込される場合は、赤の存在があることをメッセージする。
    '
    '   備考： 2008/08/13 分納された売上に対しての赤黒チェックの追加・修正
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkAkaKro() As Object

        Dim intKesizan As Decimal 'ヘッダ部消込残額
        Dim intKomikn As Decimal '税込売上額
        Dim intKesikn As Decimal '消込額
        Dim intBfKesikn As Decimal '消込額(締日前)
        Dim intAfKesikn As Decimal
        '2008/08/13 ADD START FKS)NAKATA
        Dim intUrikn As Decimal '売上金額
        Dim wkKesikn As Decimal '赤黒チェック用消込金ワーク変数
        Dim sumKesikn As Decimal '赤黒チェック用消込金変数
        Dim Cnt As Short '赤黒チェック用カウント変数
        Dim i As Short '赤黒チェック用
        Dim wkRow As Integer '赤黒チェック用行番号
        '2008/08/13 ADD E.N.D FKS)NAKATA
        Dim tmp As Object
        Dim LS_HYFRIDT As Object
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer
        Dim strFRIDT As String
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short
        Dim strUDNDT As String
        '2009/09/15 ADD START RISE)MIYAJIMA
        Dim strSSADT As String
        Dim curKESIKN As Decimal
        Dim curKESIKN_MAE As Decimal
        Dim strJDNNO As String
        '2009/09/15 ADD E.N.D RISE)MIYAJIMA


        'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        chkAkaKro = True

        '返品を検索
        With spd_body
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG EN D
                'チェックが入っているかを確認
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/22 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_CHK)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/25 CHG START
                'intchk = SSSVal(tmp)
                intchk = SSSVal(IIf(tmp = True, 1, 0))
                '2019/04/25 CHG E N D

                'チェックが入っている場合
                If intchk = 1 Then

                    '2008/08/13 ADD START FKS)NAKATA
                    ''赤黒チェック配列の初期化
                    ReDim Preserve AKAKRO_CHK(0)
                    Cnt = 1
                    '2008/08/13 ADD E.N.D FKS)NAKATA


                    '2008/08/05 ADD START FKS)NAKATA
                    ''画面入力値の消込日以降の日付されている場合エラーとする。
                    '売上日の取得
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .GetText(COL_UDNDT, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_UDNDT)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strUDNDT = CStr(tmp)

                    If strUDNDT > DeCNV_DATE(Trim(txt_kesidt.Text)) Then
                        MsgBox("入力された消込日以降の売上が存在します。")
                        'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        chkAkaKro = False
                        Exit Function
                    End If
                    '2008/08/05 ADD E.N.D FKS)NAKATA

                    '2009/09/27 DEL START RISE)MIYAJIMA
                    ''2009/09/15 ADD START RISE)MIYAJIMA
                    '                '請求締日の取得
                    '                Call .GetText(COL_SSADT, idxRow, tmp)
                    '                strSSADT = CStr(tmp)
                    '                '消込金額の取得
                    '                Call .GetText(COL_KESIKN, idxRow, tmp)
                    '                curKESIKN = SSSVal(tmp)
                    '                '消込金額の取得（前）
                    '                Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                    '                curKESIKN_MAE = SSSVal(tmp)
                    '                '受注番号の取得
                    '                Call .GetText(COL_JDNNO, idxRow, tmp)
                    '                strJDNNO = CStr(tmp)
                    '                If curKESIKN <> 0 And curKESIKN <> curKESIKN_MAE And strSSADT > DB_TOKMTA2.TOKSMEDT Then
                    '                    MsgBox ("消込金額が変更されています。更新できません。" & vbCrLf & vbCrLf _
                    ''                                & "行No:" & vbTab & idxRow & vbCrLf _
                    ''                                & "売上日: " & vbTab & strUDNDT & vbCrLf _
                    ''                                & "受注番号: " & vbTab & strJDNNO)
                    '                    chkAkaKro = False
                    '                    Exit Function
                    '                End If
                    ''2009/09/15 ADD E.N.D RISE)MIYAJIMA
                    '2009/09/27 DEL E.N.D RISE)MIYAJIMA

                    '入金済額(締日前)
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .GetText(COL_BFKESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_BFKESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intBfKesikn = SSSVal(tmp)

                    '入金済額(締日後)
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .GetText(COL_AFKESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_AFKESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intAfKesikn = SSSVal(tmp)


                    '入金済額を取得
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/22 CHG START
                    'Call .GetText(COL_KESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_KESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intKesikn = SSSVal(tmp)

                    '以前に消込されているもの以外
                    If intBfKesikn + intAfKesikn = 0 Then

                        '消込額がマイナスであれば同一受注番号の黒を検索
                        If intKesikn < 0 Then

                            '受注番号取得
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/23 CHG START
                            'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_HYJDNNO)
                            '2019/04/23 CHG E N D
                            'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            strHYJDNNO = CStr(tmp)

                            '2008/08/13 ADD START FKS)NAKATA
                            ''赤のデータを配列に格納
                            AKAKRO_CHK(0).idx = idxRow
                            AKAKRO_CHK(0).CHKMK = intchk
                            AKAKRO_CHK(0).UDNDT = strUDNDT
                            AKAKRO_CHK(0).JDNNO = strHYJDNNO
                            AKAKRO_CHK(0).kesikn = intKesikn
                            '2008/08/13 ADD E.N.D FKS)NAKATA

                            '同一受注番号を検索
                            For idxRowJDNNO = intMaxRow To 1 Step -1
                                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/22 CHG START
                                '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                str_theHYJDNNO = CStr(tmp)

                                '受注番号一致すれば相殺
                                If strHYJDNNO <> str_theHYJDNNO Then
                                Else
                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/22 CHG START
                                    '.GetText(COL_CHK, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_CHK)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/25 CHG START
                                    'intchk = SSSVal(tmp)
                                    intchk = SSSVal(IIf(tmp = True, 1, 0))
                                    '2019/04/25 CHG E N D

                                    '2008/08/13 ADD START FKS)NAKATA
                                    If idxRowJDNNO <> idxRow Then

                                        ''同一受注番号の黒の消込金額を取得
                                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/22 CHG START
                                        '.GetText(COL_KESIKN, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_KESIKN)
                                        '2019/04/22 CHG E N D
                                        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        wkKesikn = SSSVal(tmp)


                                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/22 CHG START
                                        '.GetText(COL_UDNDT, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_UDNDT)
                                        '2019/04/22 CHG E N D
                                        'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strUDNDT = CStr(tmp)

                                        ''同一受注番号の黒を配列に格納
                                        ReDim Preserve AKAKRO_CHK(Cnt)

                                        AKAKRO_CHK(Cnt).idx = idxRowJDNNO
                                        AKAKRO_CHK(Cnt).CHKMK = intchk
                                        AKAKRO_CHK(Cnt).JDNNO = strHYJDNNO
                                        AKAKRO_CHK(Cnt).UDNDT = strUDNDT
                                        AKAKRO_CHK(Cnt).kesikn = wkKesikn

                                        Cnt = Cnt + 1
                                    End If
                                    '2008/08/13 ADD E.N.D FKS)NAKATA

                                    '2008/08/13 DEL START FKS)NAKATA
                                    ''                                '自分自身でない、またはチェックされていない
                                    ''                                If idxRowJDNNO <> idxRow And intChk = 0 Then
                                    ''                                'If idxRowJDNNO <> idxRow And intChk = 0 And wkKesikn < 0 Then
                                    ''
                                    ''
                                    ''                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                    ''                                    strUDNDT = CStr(tmp)
                                    ''
                                    ''                                    MsgBox ("消込が必要な売上があります。" & vbCrLf & vbCrLf _
                                    '''                                                & "行No:" & vbTab & idxRowJDNNO & vbCrLf _
                                    '''                                                & "売上日: " & vbTab & strUDNDT & vbCrLf _
                                    '''                                                & "受注番号: " & vbTab & strHYJDNNO)
                                    ''                                    chkAkaKro = False
                                    ''                                    Exit Function
                                    ''                                End If
                                    '2008/08/13 DEL E.N.D FKS)NAKATA

                                End If
                            Next idxRowJDNNO

                            '2008/08/13 ADD START FKS)NAKATA
                            ''返品の赤黒チェック

                            'サマリの初期化
                            sumKesikn = AKAKRO_CHK(0).kesikn

                            For i = 1 To Cnt - 1

                                'チェックが入っていない場合
                                If AKAKRO_CHK(i).CHKMK = 0 Then

                                    wkRow = AKAKRO_CHK(i).idx
                                    strUDNDT = AKAKRO_CHK(i).UDNDT

                                    '入っている場合
                                Else
                                    '赤のマイナスの消込金以上に黒の消込がされている
                                    If sumKesikn + AKAKRO_CHK(i).kesikn >= 0 Then
                                        sumKesikn = 0
                                        Exit For
                                    Else
                                        '
                                        wkRow = AKAKRO_CHK(i).idx
                                        sumKesikn = sumKesikn + AKAKRO_CHK(i).kesikn
                                    End If

                                End If
                            Next i

                            'サマリがマイナスになっている場合はエラーメッセージを表示
                            If Cnt - 1 >= 1 And sumKesikn < 0 Then
                                MsgBox("消込が必要な売上があります。" & vbCrLf & vbCrLf & "行No:" & vbTab & wkRow & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & strHYJDNNO)
                                'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                chkAkaKro = False
                                Exit Function
                            End If
                            '2008/08/13 ADD E.N.D FKS)NAKATA

                        Else
                            '黒データからの検索

                            '受注番号取得
                            'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/23 CHG START
                            'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_HYJDNNO)
                            '2019/04/23 CHG E N D
                            'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            strHYJDNNO = CStr(tmp)

                            '同一受注番号を検索
                            '2019/04/25 CHG START
                            'For idxRowJDNNO = intMaxRow To 1 Step -1
                            For idxRowJDNNO = intMaxRow - 1 To 0 Step -1
                                '2019/04/25 CHG E N D

                                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/04/23 CHG START
                                '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                                '2019/04/23 CHG E N D
                                'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                str_theHYJDNNO = CStr(tmp)

                                '受注番号一致すれば相殺
                                If strHYJDNNO <> str_theHYJDNNO Then
                                Else

                                    'チェック
                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/23 CHG START
                                    '.GetText(COL_CHK, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_CHK)
                                    '2019/04/23 CHG E N D
                                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/25 CHG START
                                    'intchk = SSSVal(tmp)
                                    intchk = SSSVal(IIf(tmp = True, 1, 0))
                                    '2019/04/25 CHG E N D

                                    '2008/08/13 ADD START FKS)NAKATA
                                    '売上金額
                                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/04/23 CHG START
                                    '.GetText(COL_URIKN, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_URIKN)
                                    '2019/04/23 CHG E N D
                                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    intUrikn = SSSVal(tmp)
                                    '2008/08/13 ADD START FKS)NAKATA


                                    '2008/08/13 CHG START FKS)NAKATA
                                    ''分納されている黒データを検出しないよう修正

                                    ''自分自身でない、またはチェックされていない
                                    ''If idxRowJDNNO <> idxRow And intChk = 0 Then

                                    '自分自身でない、かつチェックされていない、かつ黒データでない
                                    If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
                                        '2008/08/13 CHG START FKS)NAKATA

                                        'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        '2019/04/23 CHG START
                                        '.GetText(COL_UDNDT, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_UDNDT)
                                        '2019/04/23 CHG E N D
                                        'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                        strUDNDT = CStr(tmp)

                                        If MsgBox("消込が必要な売上があります。" & vbCrLf & "更新しますか？" & vbCrLf & vbCrLf & "行No:" & vbTab & idxRowJDNNO & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & strHYJDNNO, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                                            'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                            chkAkaKro = True

                                        Else
                                            'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                            chkAkaKro = False
                                            Exit Function
                                        End If

                                    End If
                                End If
                            Next idxRowJDNNO

                        End If
                    End If
                End If
            Next idxRow
        End With

    End Function
    '2008/07/30 ADD E.N.D FKS)NAKATA

    '// V2.06↓ DEL
    ''// V2.00↓ ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Sub chkCondition
    '    '   概要：  ヘッダ部の入力チェック
    '    '   引数：  無し
    '    '   戻値：　True:正常  False:異常
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkCondition() As Boolean
    '    chkCondition = False
    '
    '    intChkKb = 1
    '    If chkKesidt = True Then
    '        intChkKb = 1
    '        If chkTokseicd = True Then
    '            intChkKb = 1
    '            If chkKaidt_From = True Then
    '                intChkKb = 1
    '                If chkKaidt_To = True Then
    '                    '振込期日が入力できる時は必須とする
    '                    If blnFriEnabled = True Then
    '                        '未入力時はエラーとする
    '                        If Trim(txt_fridt.Text) = "" Then
    '                            Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
    '                            txt_fridt.ForeColor = vbRed
    '                            txt_fridt.SetFocus
    '                            Exit Function
    '                        End If
    '
    '                        intChkKb = 1
    '                        If chkFridt = True Then
    '                            chkCondition = True
    '                        End If
    '                    Else
    '                        chkCondition = True
    '                    End If
    '                End If
    '            End If
    '        '請求先ｺｰﾄﾞが未入力の時はｴﾗｰとする
    '        Else
    '            If Trim(txt_tokseicd.Text) = "" Then
    '                Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
    '                txt_tokseicd.ForeColor = vbRed
    '                txt_tokseicd.SetFocus
    '            End If
    '        End If
    '    End If
    'End Function
    ''// V2.00↑ ADD
    '// V2.06↑ DEL

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub ChkInputChange
    '   概要：  明細の入力内容の変更確認
    '   引数：  無し
    '   戻値：　True:変更有り  False:変更無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function ChkInputChange() As Boolean

        Dim i As Short
        Dim vnt_AFCHK As Object
        Dim vnt_BFCHK As Object

        ChkInputChange = False

        With spd_body
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'For i = 1 To .MaxRows
            '    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(COL_CHK, i, vnt_AFCHK)
            '    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(COL_BFCHECK, i, vnt_BFCHK)
            '    'UPGRADE_WARNING: オブジェクト SSSVal(vnt_BFCHK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    'UPGRADE_WARNING: オブジェクト SSSVal(vnt_AFCHK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
            '        ChkInputChange = True
            '        Exit For
            '    End If
            'Next i
            For i = 0 To .RowCount - 1
                vnt_AFCHK = IIf(.GetValue(i, COL_CHK), "1", "0")
                vnt_BFCHK = .GetValue(i, COL_BFCHECK)
                If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
                    ChkInputChange = True
                    Exit For
                End If
            Next
            '2019/04/23 CHG E N D
        End With

    End Function

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_NKSTRA_HAITA_INF
    '   概要：  入金消込トランの排他情報取得
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Get_NKSTRA_HAITA_INF() As Boolean

        Dim strSql As Object
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_1 As U_Ody
        Dim i As Integer
        Dim Lng_Cnt As Integer
        '2019/04/18 ADD START
        Dim dt As DataTable
        '2019/04/18 CADD E N D
        Get_NKSTRA_HAITA_INF = False

        ReDim ARY_NKSTRA_HAITA(0)

        For i = 1 To UBound(ARY_UDNTRA_HAITA)
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = ""
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "SELECT " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "       KDNNO  " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,OPEID  " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,CLTID  " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,WRTDT  " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,WRTTM  " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,UOPEID " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,UCLTID " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,UWRTDT " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "      ,UWRTTM " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "FROM " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "       NKSTRA " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "WHERE " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "       UDNDATNO = '" & ARY_UDNTRA_HAITA(i).DATNO & "' " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "AND    UDNLINNO = '" & ARY_UDNTRA_HAITA(i).LINNO & "' " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "AND    DATKB    = '1' " & vbCrLf

            'DBアクセス
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            'Do While CF_Ora_EOF(Usr_Ody) = False
            dt = DB_GetTable(strSql)

            For cnt As Integer = 0 To dt.Rows.Count - 1
                '2019/04/18 CHG E N D

                '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = ""
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = strSql & "SELECT " & vbCrLf
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = strSql & "       KDNNO " & vbCrLf
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = strSql & "FROM " & vbCrLf
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = strSql & "       NKSTRA " & vbCrLf
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                strSql = strSql & "WHERE " & vbCrLf
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/18 CHG START
                'strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf
                strSql = strSql & "       MOTKDNNO = '" & DB_NullReplace(dt.Rows(cnt)("KDNNO"), "") & "' " & vbCrLf
                '2019/04/18 CHG E N D

                'DBアクセス
                'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/18 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)

                'If CF_Ora_EOF(Usr_Ody_1) Then

                Dim dt2 As DataTable = DB_GetTable(strSql)

                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    '2019/04/18 CHG E N D

                    Lng_Cnt = Lng_Cnt + 1
                    ReDim Preserve ARY_NKSTRA_HAITA(Lng_Cnt)
                    '2019/04/18 CHG START
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "KDNNO", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
                    ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(DB_NullReplace(dt2.Rows(0)("KDNNO"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(DB_NullReplace(dt2.Rows(0)("OPEID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(DB_NullReplace(dt2.Rows(0)("CLTID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(DB_NullReplace(dt2.Rows(0)("WRTDT"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(DB_NullReplace(dt2.Rows(0)("WRTTM"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(DB_NullReplace(dt2.Rows(0)("UOPEID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(DB_NullReplace(dt2.Rows(0)("UCLTID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(DB_NullReplace(dt2.Rows(0)("UWRTDT"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(DB_NullReplace(dt2.Rows(0)("UWRTTM"), ""))
                    '2019/04/18 CHG E N D
                End If
                '2019/04/18 CHG START
                '         Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                '	'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	Usr_Ody.Obj_Ody.MoveNext()
                'Loop 
                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Next
            '2019/04/18 CHG E N D
        Next i

        Get_NKSTRA_HAITA_INF = True

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_NKSTRA_HAITA_INF
    '   概要：  入金消込トランの期日振込日の取得
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Get_NKSTRA_TEGDT(ByRef vnt_UDNDATNO As Object, ByRef vnt_UDNLINNO As Object) As String

        Dim strSql As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_1 As U_Ody
        Dim strTEGDT As String
        Dim blnExist As Boolean

        strTEGDT = ""

        blnExist = False

        '// V2.01↓ UPD
        strSql = ""
        strSql = strSql & "SELECT " & vbCrLf
        strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
        strSql = strSql & "FROM " & vbCrLf
        strSql = strSql & "       NKSTRA " & vbCrLf
        strSql = strSql & "WHERE " & vbCrLf
        'UPGRADE_WARNING: オブジェクト vnt_UDNDATNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        'UPGRADE_WARNING: オブジェクト vnt_UDNLINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
        strSql = strSql & "AND    KDNNO NOT IN ( " & vbCrLf
        strSql = strSql & "       SELECT " & vbCrLf
        strSql = strSql & "              MOTKDNNO " & vbCrLf
        strSql = strSql & "       FROM " & vbCrLf
        strSql = strSql & "              NKSTRA " & vbCrLf
        strSql = strSql & "       WHERE " & vbCrLf
        'UPGRADE_WARNING: オブジェクト vnt_UDNDATNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "              UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        'UPGRADE_WARNING: オブジェクト vnt_UDNLINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "       AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        strSql = strSql & "       AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
        strSql = strSql & "       ) " & vbCrLf

        'DBアクセス
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If Not CF_Ora_EOF(Usr_Ody) Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strTEGDT = DB_NullReplace(dt.Rows(0)("TEGDT"), "")
        End If
        '2019/04/18 CHG E N D

        Get_NKSTRA_TEGDT = strTEGDT

        ''''    strSql = ""
        ''''    strSql = strSql & "SELECT " & vbCrLf
        ''''    strSql = strSql & "       kdnno " & vbCrLf
        ''''    strSql = strSql & "FROM " & vbCrLf
        ''''    strSql = strSql & "       NKSTRA " & vbCrLf
        ''''    strSql = strSql & "WHERE " & vbCrLf
        ''''    strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        ''''    strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        ''''    strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        ''''    strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
        ''''
        ''''    'DBアクセス
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    Do While CF_Ora_EOF(Usr_Ody) = False
        ''''        '取消データが存在するか確認し、いない場合は取り消しされていない
        ''''        strSql = ""
        ''''        strSql = strSql & "SELECT " & vbCrLf
        ''''        strSql = strSql & "       * " & vbCrLf
        ''''        strSql = strSql & "FROM " & vbCrLf
        ''''        strSql = strSql & "       NKSTRA " & vbCrLf
        ''''        strSql = strSql & "WHERE " & vbCrLf
        ''''        strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
        ''''
        ''''        'DBアクセス
        ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
        ''''
        ''''        If CF_Ora_EOF(Usr_Ody_1) = False Then
        ''''            Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        ''''            blnExist = True
        ''''            Exit Do
        ''''        End If
        ''''        Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        ''''        Usr_Ody.Obj_Ody.MoveNext
        ''''    Loop
        ''''
        ''''    Call CF_Ora_CloseDyn(Usr_Ody)     'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        ''''
        ''''    If blnExist = False Then
        ''''        strSql = ""
        ''''        strSql = strSql & "SELECT " & vbCrLf
        ''''        strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
        ''''        strSql = strSql & "FROM " & vbCrLf
        ''''        strSql = strSql & "       NKSTRA " & vbCrLf
        ''''        strSql = strSql & "WHERE " & vbCrLf
        ''''        strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        ''''        strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        ''''        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        ''''
        ''''        'DBアクセス
        ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''        If Not CF_Ora_EOF(Usr_Ody) Then
        ''''            strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
        ''''        End If
        ''''    End If
        ''''
        ''''    Get_NKSTRA_TEGDT = strTEGDT
        '// V2.01↑ UPD

    End Function
    '// V2.00↑ ADD

    '// V2.06↓ DEL
    ''// V2.00↓ ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Sub chkKesidt
    '    '   概要：  消込日付のチェック
    '    '   引数：  無し
    '    '   戻値：　True:正常  False:異常
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''消込日付のチェック
    'Private Function chkKesidt() As Boolean
    '
    '    chkKesidt = False
    '
    '    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    '
    '    If intChkKb = 1 Then
    '
    '        If txt_kesidt.Text <> CNV_DATE(gstrKesidt) Then
    '
    '            '日付形式のチェック
    '            If IsDate(txt_kesidt.Text) = False Then
    '                Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '経理締日以前の日付の時はエラー
    '            If DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '                Call showMsg("1", "URKET53_010", 0)     '●経理締め済みのMSG
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '運用日より後日付の時はエラー
    '            If DeCNV_DATE(txt_kesidt.Text) > gstrUnydt Then
    '                Call showMsg("2", "DATE_1", 3)          '●運用日後日付エラー
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kesidt.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)     '●締めを跨いでの日付は入力できません
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            txt_kesidt.ForeColor = vbBlack
    '            chkKesidt = True
    '        Else
    '            chkKesidt = True
    '        End If
    '    Else
    '        chkKesidt = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    '    intChkKb = 2            '●基本は変更時にチェック
    '
    'End Function
    ''// V2.00↑ ADD
    '// V2.06↑ DEL

    '// V2.06↓ DEL
    ''// V2.00↓ ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Sub chkTokseicd
    '    '   概要：  請求先ｺｰﾄﾞのチェック
    '    '   引数：  無し
    '    '   戻値：　True:正常  False:異常
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkTokseicd() As Boolean
    '
    '    chkTokseicd = False
    '
    '    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    '    If intChkKb = 1 Then
    '
    '        If txt_tokseicd.Text <> gstrTokseicd Then
    '
    '            '変更されていたら項目クリア
    '            If txt_tokseicd.Text <> gstrTokseicd Then
    '                txt_tokseinma.Text = ""
    '                txt_fridt.Text = "        " '8byte space
    '                txt_fridt.Enabled = False
    '
    '                lbl_shakbnm(1).Caption = ""
    '                lbl_hytokkesdd(1).Caption = ""
    '                gstrFridt = Space(8)        'add 2007/03/29 Saito
    '            End If
    '
    '            '空白入力時はチェックしない（chkConditionでチェック）
    '            If Trim(txt_tokseicd.Text) = "" Then
    '                chkTokseicd = True
    '                Exit Function
    '            End If
    '
    '            blnFriEnabled = False
    '
    '            '得意先ﾏｽﾀから請求先名称を取得
    '            Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), txt_tokseicd.Text)
    '                '国内請求先のとき
    '                Case 0:
    '                    txt_tokseicd.ForeColor = vbBlack
    ''// V2.05↓ UPD
    ''                    txt_tokseinma.Text = DB_TOKMTA2.TOKNMA
    '                    txt_tokseinma.Text = DB_TOKMTA2.TOKRN
    ''// V2.05↑ UPD
    '                    lbl_shakbnm(1).Caption = DB_TOKMTA2.SHAKBNM
    '                    lbl_hytokkesdd(1).Caption = DB_TOKMTA2.HYTOKKESDD
    '                    '支払条件が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日項目を入力可とする
    '                    '●支払条件の値に応じて、期日振込入力可能フラグをたてる
    ''CHG START FKS) INABA 2007/05/08 *******************************************
    ''支払条件に手形が入っている場合は明細の振込期日を入力できるようにする
    '                    Select Case DB_TOKMTA2.SHAKB
    '                        Case "2", "3", "4", "5", "6"
    '                            blnFriEnabled = True
    '                    End Select
    ''CHG  END  FKS) INABA 2007/05/08 *******************************************
    '                    txt_fridt.Enabled = blnFriEnabled
    '                    chkTokseicd = True
    '
    '                '海外請求先のとき
    '                Case 1:
    '                    Call showMsg("1", "URKET53_013", 0)     '●国内の得意先ではありません。     '2007.03.05
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '
    '                '請求先でない得意先のとき
    '                Case 8:
    '                    Call showMsg("2", "DONTSELECT", "2")    '●請求先ではない
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '
    '                '請求先が存在しない時
    '                Case 9:
    '                    Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '            End Select
    '
    '            txt_tokseicd.ForeColor = vbBlack
    '            chkTokseicd = True
    '        Else
    '            chkTokseicd = True
    '        End If
    '    Else
    '        chkTokseicd = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrTokseicd = txt_tokseicd.Text
    '    intChkKb = 2            '●基本は変更時にチェック
    '
    'End Function
    ''// V2.00↑ ADD
    '// V2.06↑ DEL

    '// V2.06↓ DEL
    ''// V2.00↓ ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Sub chkKaidt_From
    '    '   概要：  回収予定日付（開始）のチェック
    '    '   引数：  無し
    '    '   戻値：　True:正常  False:異常
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkKaidt_From() As Boolean
    '
    '    chkKaidt_From = False
    '
    '    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    '    If intChkKb = 1 Then
    '
    '        '日付形式のチェック
    '        If Trim(txt_kaidt_From.Text) <> "" Or txt_kesikb = "9" Then
    '
    '            If IsDate(txt_kaidt_From.Text) = False Then
    '                Call showMsg("2", "DATE", 0)                '●日付誤りのMSG
    '                txt_kaidt_From.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kaidt_From.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)         '●締めを跨いでの日付は入力できません
    '                txt_kaidt_From.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '入金消込画面で受注日(売上日)＞入金消込日はエラー
    '            If IsDate(txt_kaidt_From.Text) And IsDate(txt_kesidt.Text) Then
    '                If Format(txt_kaidt_From.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    '                    txt_kaidt_From.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            txt_kaidt_From.ForeColor = vbBlack
    '            chkKaidt_From = True
    '        Else
    '            chkKaidt_From = True
    '        End If
    '    Else
    '        chkKaidt_From = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKaidt_Fr = DeCNV_DATE(txt_kaidt_From.Text)
    '    intChkKb = 2            '●基本は変更時にチェック
    '
    'End Function
    ''// V2.00↑ ADD
    '// V2.06↑ DEL

    '// V2.06↓ DEL
    ''// V2.00↓ ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Sub chkKaidt_To
    '    '   概要：  回収予定日付（終了）のチェック
    '    '   引数：  無し
    '    '   戻値：　True:正常  False:異常
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkKaidt_To() As Boolean
    '
    '    chkKaidt_To = False
    '
    '    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    '    If intChkKb = 1 Then
    '
    '        If txt_kaidt_To.Text <> CNV_DATE(gstrKaidt_To) Then
    '
    '            '日付形式のチェック
    '            If IsDate(txt_kaidt_To.Text) = False Then
    '                Call showMsg("2", "DATE", 0)                '●日付誤りのMSG
    '                txt_kaidt_To.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kaidt_To.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)         '●締めを跨いでの日付は入力できません
    '                txt_kaidt_To.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '入金消込画面で受注日(売上日)＞入金消込日はエラー
    '            If IsDate(txt_kaidt_To.Text) And IsDate(txt_kesidt.Text) Then
    '                If Format(txt_kaidt_To.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    '                    txt_kaidt_To.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            '日付の大小比較
    '            If IsDate(txt_kaidt_From.Text) And IsDate(txt_kaidt_To.Text) Then
    '                If Format(txt_kaidt_From.Text, "0000/00/00") > Format(txt_kaidt_To.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
    '                    txt_kaidt_To.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            txt_kaidt_To.ForeColor = vbBlack
    '            chkKaidt_To = True
    '        Else
    '            chkKaidt_To = True
    '        End If
    '    Else
    '        chkKaidt_To = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKaidt_To = DeCNV_DATE(txt_kaidt_To.Text)
    '    intChkKb = 2            '●基本は変更時にチェック
    '
    'End Function
    ''// V2.00↑ ADD
    '// V2.06↑ DEL

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkCondition
    '   概要：  ヘッダ部の入力チェック
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkCondition() As Boolean
        chkCondition = False

        'チェック：消込日
        With txt_kesidt
            If Trim(.Text) = "" Then
                '必須入力チェック
                Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                'チェック処理
                If chkKesidt(True) = False Then 'チェック処理を強制的に走らせる
                    'エラー
                    Call .Focus()
                    Exit Function
                End If
            End If
        End With

        'チェック：請求先コード
        With txt_tokseicd
            If Trim(.Text) = "" Then
                '必須入力チェック
                Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                'チェック処理
                If chkTokseicd(True) = False Then 'チェック処理を強制的に走らせる
                    'エラー
                    Call .Focus()
                    Exit Function
                End If
            End If
        End With

        'チェック：売上日(開始)
        With txt_kaidt_From
            If Trim(.Text) = "" Then
                If Trim(txt_kesikb.Text) = "9" Then
                    '必須入力チェック
                    Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                    .ForeColor = System.Drawing.Color.Red
                    .Focus()
                    Exit Function
                End If
            Else
                intChkKb = 1
                If chkKaidt_From(True) = False Then 'チェック処理を強制的に走らせる
                    'エラー
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        'チェック：売上日(終了)
        With txt_kaidt_To
            If Trim(.Text) = "" Then
                '必須入力チェック
                Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                'チェック処理
                If chkKaidt_To(True) = False Then 'チェック処理を強制的に走らせる
                    'エラー
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        With txt_fridt
            If Trim(.Text) = "" Then
                If blnFriEnabled = True Then
                    '2009/09/18 ADD START RISE)MIYAJIMA
                    'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If pnl_condition1.Enabled = False Then
                        blnUsableButton = False
                        'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pnl_condition1.Enabled = True
                        'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pnl_condition2.Enabled = True
                        initBody()
                        intInputMode = 1
                        '必須入力チェック
                        Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                        Exit Function
                    End If
                    '2009/09/18 ADD E.N.D RISE)MIYAJIMA
                    '必須入力チェック
                    Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
                    '// V3.10↓ ADD
                    .Enabled = True
                    '// V3.10↑ ADD
                    .ForeColor = System.Drawing.Color.Red

                    .Focus()
                    Exit Function
                End If
            Else
                intChkKb = 1
                'チェック処理
                If chkFridt(True) = False Then 'チェック処理を強制的に走らせる
                    'エラー
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        chkCondition = True
    End Function
    '// V2.06↑ ADD

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkKesidt
    '   概要：  消込日付のチェック
    '   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKesidt = False

        With txt_kesidt
            If pin_blnChk = False Then
                'チェック区分が1のとき、あるいは変更されていたらチェックを行う
                If intChkKb <> 1 Then
                    chkKesidt = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKesidt.Value) Then
                    chkKesidt = True
                    GoTo END_STEP
                End If
            End If

            '空白入力時はチェックしない（chkConditionでチェック）
            If Trim(.Text) = "" Then
                chkKesidt = True
                Exit Function
            End If

            '日付形式のチェック
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '2009/09/03 ADD START RISE)MIYAJIMA
            '入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
            If Trim(txt_tokseicd.Text) <> "" Then
                If DeCNV_DATE(.Text) <= DB_TOKMTA2.TOKSMEDT Then
                    Call showMsg("2", "URKET53_041", CStr(0)) '●請求締日以前です。この日付では入力できません。MSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If
            '2009/09/03 ADD E.N.D RISE)MIYAJIMA

            '経理締日以前の日付の時はエラー
            If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
                'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
                Call showMsg("1", "URKET53_010", CStr(0)) '●経理締め済みのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '運用日より後日付の時はエラー
            If DeCNV_DATE(.Text) > gstrUnydt.Value Then
                Call showMsg("2", "DATE_1", CStr(3)) '●運用日後日付エラー
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '締めを跨いでの日付はエラー
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '●締めを跨いでの日付は入力できません
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKesidt = True

END_STEP:

        gstrKesidt.Value = DeCNV_DATE((txt_kesidt.Text))
        intChkKb = 2 '●基本は変更時にチェック
    End Function
    '// V2.06↑ ADD

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkTokseicd
    '   概要：  請求先ｺｰﾄﾞのチェック
    '   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean

        '2009/09/03 ADD START RISE)MIYAJIMA
        Dim strTANCLAKB As String
        '2009/09/03 ADD E.N.D RISE)MIYAJIMA

        chkTokseicd = False

        With txt_tokseicd
            If pin_blnChk = False Then
                'チェック区分が1のとき、あるいは変更されていたらチェックを行う
                If intChkKb <> 1 Then
                    chkTokseicd = True
                    GoTo END_STEP
                End If
                If .Text = gstrTokseicd.Value Then
                    chkTokseicd = True
                    GoTo END_STEP
                End If
            End If

            '変更されていたら項目クリア
            If .Text <> gstrTokseicd.Value Then
                txt_tokseinma.Text = ""
                txt_fridt.Text = Space(8)
                txt_fridt.Enabled = False

                lbl_shakbnm(1).Text = ""
                lbl_hytokkesdd(1).Text = ""
                gstrFridt.Value = Space(8)
            End If

            '空白入力時はチェックしない（chkConditionでチェック）
            If Trim(.Text) = "" Then
                chkTokseicd = True
                Exit Function
            End If

            blnFriEnabled = False

            '得意先ﾏｽﾀから請求先名称を取得
            Select Case getTokseinm(DeCNV_DATE((txt_kesidt.Text)), .Text)
                '国内請求先のとき
                Case 0
                    .ForeColor = System.Drawing.Color.Black
                    txt_tokseinma.Text = DB_TOKMTA2.TOKRN
                    lbl_shakbnm(1).Text = DB_TOKMTA2.SHAKBNM
                    lbl_hytokkesdd(1).Text = DB_TOKMTA2.HYTOKKESDD

                    '2009/09/03 ADD START RISE)MIYAJIMA
                    '入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
                    If DeCNV_DATE((txt_kesidt.Text)) <= DB_TOKMTA2.TOKSMEDT Then
                        Call showMsg("2", "URKET53_041", CStr(0)) '●請求締日以前です。この日付では入力できません。MSG
                        txt_kesidt.ForeColor = System.Drawing.Color.Red
                        txt_kesidt.Focus()
                        GoTo END_STEP
                    End If
                    '2009/09/03 ADD E.N.D RISE)MIYAJIMA
                    '2009/09/03 ADD START RISE)MIYAJIMA
                    Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA2.TANCD, strTANCLAKB)
                    If strTANCLAKB <> "1" Then
                        Call showMsg("2", "URKET53_042", CStr(0)) '●請求先担当者が営業でありません。
                        .ForeColor = System.Drawing.Color.Red
                        GoTo END_STEP
                    End If
                    '2009/09/03 ADD E.N.D RISE)MIYAJIMA

                    '// V3.10↓ UPD
                    Call getInputHYFRIDT(DB_TOKMTA2.TOKSEICD, Get_Acedt(DeCNV_DATE((txt_kesidt.Text))), DB_TOKMTA2.SHAKB)
                    '                '支払条件に手形が入っている場合は明細の振込期日を入力できるようにする
                    '                Select Case DB_TOKMTA2.SHAKB
                    '                    Case "2", "3", "4", "5", "6"
                    '                        blnFriEnabled = True
                    '                End Select
                    '// V3.10↑ UPD

                    txt_fridt.Enabled = blnFriEnabled
                    chkTokseicd = True

                    '海外請求先のとき
                Case 1
                    Call showMsg("1", "URKET53_013", CStr(0)) '●国内の得意先ではありません。
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP

                    '請求先でない得意先のとき
                Case 8
                    Call showMsg("2", "DONTSELECT", "2") '●請求先ではない
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP

                    '請求先が存在しない時
                Case 9
                    Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
            End Select

            .ForeColor = System.Drawing.Color.Black
        End With

        chkTokseicd = True

END_STEP:

        gstrTokseicd.Value = txt_tokseicd.Text
        intChkKb = 2 '●基本は変更時にチェック
    End Function
    '// V2.06↑ ADD

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkKaidt_From
    '   概要：  回収予定日付（開始）のチェック
    '   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKaidt_From = False

        With txt_kaidt_From
            If pin_blnChk = False Then
                'チェック区分が1のとき、あるいは変更されていたらチェックを行う
                If intChkKb <> 1 Then
                    chkKaidt_From = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKaidt_Fr.Value) Then
                    chkKaidt_From = True
                    GoTo END_STEP
                End If
            End If

            '空白入力時はチェックしない（chkConditionでチェック）
            If Trim(.Text) = "" Then
                gstrKaidt_Fr.Value = ""
                chkKaidt_From = True
                Exit Function
            End If

            '日付形式のチェック
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '締めを跨いでの日付はエラー
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '●締めを跨いでの日付は入力できません
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '入金消込画面で受注日(売上日)＞入金消込日はエラー
            If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
                If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKaidt_From = True

END_STEP:

        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
        intChkKb = 2 '●基本は変更時にチェック
    End Function
    '// V2.06↑ ADD

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkKaidt_To
    '   概要：  回収予定日付（終了）のチェック
    '   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKaidt_To = False

        With txt_kaidt_To
            If pin_blnChk = False Then
                'チェック区分が1のとき、あるいは変更されていたらチェックを行う
                If intChkKb <> 1 Then
                    chkKaidt_To = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKaidt_To.Value) Then
                    chkKaidt_To = True
                    GoTo END_STEP
                End If
            End If

            '空白入力時はチェックしない（chkConditionでチェック）
            If Trim(.Text) = "" Then
                chkKaidt_To = True
                Exit Function
            End If

            '日付形式のチェック
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '締めを跨いでの日付はエラー
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '●締めを跨いでの日付は入力できません
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '入金消込画面で受注日(売上日)＞入金消込日はエラー
            If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
                If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If

            '日付の大小比較
            If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
                If VB6.Format(txt_kaidt_From.Text, "0000/00/00") > VB6.Format(.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                    .ForeColor = System.Drawing.Color.Red
                    txt_kaidt_From.ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                Else
                    'チェックエラーなし
                    txt_kaidt_From.ForeColor = System.Drawing.Color.Black
                End If
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKaidt_To = True

END_STEP:

        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
        intChkKb = 2 '●基本は変更時にチェック
    End Function
    '// V2.06↑ ADD

    '// V2.06↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function chkFridt
    '   概要：  振込期日のチェック
    '   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        chkFridt = False

        With txt_fridt
            If pin_blnChk = False Then
                'チェック区分が1のとき、あるいは変更されていたらチェックを行う
                If intChkKb <> 1 Then
                    chkFridt = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrFridt.Value) Then
                    chkFridt = True
                    GoTo END_STEP
                End If
            End If

            '空白入力時はチェックしない（chkConditionでチェック）
            If Trim(.Text) = "" Then
                chkFridt = True
                Exit Function
            End If

            '日付形式のチェック
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '経理締日以前の日付の時はエラー
            If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
                'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
                Call showMsg("1", "URKET53_010", CStr(0)) '●経理締め済みのMSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkFridt = True

END_STEP:

        gstrFridt.Value = DeCNV_DATE((txt_fridt.Text))
        intChkKb = 2 '●基本は変更時にチェック
    End Function
    '// V2.06↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_Change
    '   概要：  日付項目日付変換
    '   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub Ctl_DTItem_Change(ByRef pm_objDt As Object)
        '2019/04/17 CHG START
        'With pm_objDt
        '    'スラッシュが存在しているときは、スラッシュを飛ばして次の項目へ
        '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If Mid(.Text, .SelStart + 1, 1) = "/" Then
        '        'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SelStart = .SelStart + 1
        '    End If
        '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    .SelLength = 1

        '    '入力された値が８桁に到達したのでスラッシュ編集する
        '    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If Len(Trim(.Text)) = 8 Then
        '        'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .Text = VB6.Format(.Text, "0000/00/00")
        '        '日付の日の部分を選択状態にする
        '        'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SelStart = 8
        '        'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SelLength = 1
        '    End If
        'End With

        If TypeOf pm_objDt Is System.Windows.Forms.TextBox Then
            With DirectCast(pm_objDt, TextBox)
                'スラッシュが存在しているときは、スラッシュを飛ばして次の項目
                If Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                    .SelectionStart = .SelectionStart + 1
                End If

                .SelectionLength = 1

                '入力された値が８桁に到達したのでスラッシュ編集する
                If Len(Trim(.Text)) = 8 Then
                    .Text = VB6.Format(.Text, "0000/00/00")
                    '日付の日の部分を選択状態にする
                    .SelectionStart = 8
                    .SelectionLength = 1
                End If

            End With
        End If
        '2019/04/17 CHG EN D
    End Sub
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_GotFocus
    '   概要：  日付項目のカーソル位置付け
    '   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub Ctl_DTItem_GotFocus(ByRef pm_objDt As Object)

        '2019/04/17 CHG START
        'With pm_objDt
        '	'UPGRADE_WARNING: オブジェクト pm_objDt.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	If Trim(.Text) = "" Or pm_objDt.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then
        '		'なにも入っていないまたはエラーの時に先頭へ位置づけ
        '		'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SelStart = 0
        '		'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SelLength = 1
        '	Else
        '		'なにか入っていたら日付の十の位を選択状態にする
        '		'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SelStart = 8
        '		'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SelLength = 1
        '	End If
        '	'背景色を黄色にする
        '	'UPGRADE_WARNING: オブジェクト pm_objDt.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        'End With
        If TypeOf pm_objDt Is System.Windows.Forms.TextBox Then
            With DirectCast(pm_objDt, TextBox)
                If Trim(.Text) = "" Or pm_objDt.ForeColor = Color.Red Then
                    'なにも入っていないまたはエラーの時に先頭へ位置づけ
                    .SelectionStart = 0
                    .SelectionLength = 1
                Else
                    'なにか入っていたら日付の十の位を選択状態にする
                    .SelectionStart = 8
                    .SelectionLength = 1
                End If
                '背景色を黄色にする
                pm_objDt.BackColor = Color.Yellow
            End With
        End If
        '2019/04/17 CHG EN D

    End Sub
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_KeyDown
    '   概要：  請求先ｺｰﾄﾞキー入力制御
    '   引数：  pm_KeyCode    : キーコード
    '           pm_Shift      : シフト押下状態
    '           pm_objDt      : 請求先ｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　0:移動無し 1:次項目 2:前項目
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_tokseicd_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objCD As Object) As Short

        Ctl_tokseicd_KeyDown = 0

        With pm_objCD

            Select Case pm_KeyCode

                'ファンクションキー押下時
                Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
                    'ファンクションキー共通処理
                    Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)

                    '右矢印押下時
                Case System.Windows.Forms.Keys.Right
                    'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    'If .SelStart < 4 Then
                    '    'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SelStart = .SelStart + 1
                    '    'UPGRADE_WARNING: オブジェクト pm_objCD.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SelLength = 1
                    If .SelectionStart < 4 Then
                        .SelectionStart = .SelectionStart + 1
                        .SelectionLength = 1
                        '2019/04/17 CHG E N D
                    Else
                        intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                        Ctl_tokseicd_KeyDown = 1
                    End If

                    'Backspace or 左矢印押下時
                Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
                    'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    'If .SelStart > 0 Then
                    '	'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '	.SelStart = .SelStart - 1
                    '	'UPGRADE_WARNING: オブジェクト pm_objCD.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '	.SelLength = 1
                    If .SelectionStart > 0 Then
                        .SelectionStart = .SelectionStart - 1
                        .SelectionLength = 1
                        '2019/04/17 CHG E N D
                    Else
                        'Backspaceの時は、入力値が空白の時、前項目へ移動
                        'UPGRADE_WARNING: オブジェクト pm_objCD.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(.Text) <> "" And pm_KeyCode = System.Windows.Forms.Keys.Back Then
                            Exit Function
                        End If
                        intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                        Ctl_tokseicd_KeyDown = 2
                    End If

                    '上矢印押下時
                Case System.Windows.Forms.Keys.Up
                    intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                    Ctl_tokseicd_KeyDown = 2

                    '下矢印押下時
                Case System.Windows.Forms.Keys.Down
                    intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                    Ctl_tokseicd_KeyDown = 1

                    'Enter押下時
                Case System.Windows.Forms.Keys.Return
                    intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
                    Ctl_tokseicd_KeyDown = 1

                    'Delete押下時
                Case System.Windows.Forms.Keys.Delete
                    Exit Function

                    'TAB押
                Case System.Windows.Forms.Keys.F16
                    intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
                    Ctl_tokseicd_KeyDown = 1

                    'SHIFT+TAB押
                Case System.Windows.Forms.Keys.F15
                    intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック
                    Ctl_tokseicd_KeyDown = 2

                Case Else
                    Exit Function

            End Select

        End With

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_KeyDown
    '   概要：  日付項目キー入力制御
    '   引数：  pm_KeyCode    : キーコード
    '           pm_Shift      : シフト押下状態
    '           pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　0:移動無し 1:次項目 2:前項目
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_DTItem_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objDt As Object) As Short

        Ctl_DTItem_KeyDown = 0

        'UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
        Dim str_Renamed As String
        With pm_objDt

            Select Case pm_KeyCode

                'ファンクションキー押下時
                Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
                    'ファンクションキー共通処理
                    Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)

                    '右矢印 or Space押下時
                Case System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.Space

                    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    'If .SelStart < 9 Then
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SelStart = .SelStart + 1
                    '    'スラッシュにカーソルがきたら次の文字にカーソルを移動
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                    '        'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        .SelStart = .SelStart + 1
                    '    End If
                    If .SelectionStart < 9 Then
                        .SelectionStart = .SelectionStart + 1
                        'スラッシュにカーソルがきたら次の文字にカーソルを移動
                        If .SelectionStart = 4 And Mid(.Text, .SelectionStart + 1, 1) = "/" Or .SelectionStart = 7 And Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                            .SelectionStart = .SelectionStart + 1
                        End If
                        '2019/04/17 CHG E N D
                        'カーソルが右端に来たら次の項目へ移動
                    Else
                        intChkKb = 2 '★日付の入力チェック（変更時のみ)
                        Ctl_DTItem_KeyDown = 1
                    End If
                    'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    '.SelLength = 1
                    .SelectionLength = 1
                    '2019/04/17 CHG E N D

                    'Backspace or 左矢印押下時
                Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left

                    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    'If .SelStart > 0 Then
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SelStart = .SelStart - 1
                    '    'スラッシュにカーソルがきたら前の文字にカーソルを移動
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                    '        'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        .SelStart = .SelStart - 1
                    '    End If
                    If .SelectionStart > 0 Then
                        .SelectionStart = .SelectionStart - 1
                        'スラッシュにカーソルがきたら前の文字にカーソルを移動
                        If .SelectionStart = 4 And Mid(.Text, .SelectionStart + 1, 1) = "/" Or .SelectionStart = 7 And Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                            .SelectionStart = .SelectionStart - 1
                        End If
                        '2019/04/17 CHG E N D
                        'カーソルが左端に来たら前の項目へ移動
                    Else
                        intChkKb = 2 '★日付の入力チェック（変更時のみ)
                        Ctl_DTItem_KeyDown = 2
                    End If
                    'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    '.SelLength = 1
                    .SelectionLength = 1
                    '2019/04/17 CHG E N D

                    '上矢印押下時
                Case System.Windows.Forms.Keys.Up
                    intChkKb = 2 '★日付の入力チェック（変更時のみ)
                    Ctl_DTItem_KeyDown = 2

                    '下矢印押下時
                Case System.Windows.Forms.Keys.Down
                    intChkKb = 2 '★日付の入力チェック（変更時のみ)
                    Ctl_DTItem_KeyDown = 1

                    'Enter押下時
                Case System.Windows.Forms.Keys.Return
                    intChkKb = 1 '★日付の入力チェック
                    Ctl_DTItem_KeyDown = 1

                    'TAB押
                Case System.Windows.Forms.Keys.F16
                    intChkKb = 1 '★日付の入力チェック
                    Ctl_DTItem_KeyDown = 1

                    'Shift+TAB押
                Case System.Windows.Forms.Keys.F15
                    intChkKb = 2 '★日付の入力チェック（変更時のみ)
                    Ctl_DTItem_KeyDown = 2
                    '// V2.06↓ ADD
                    'Shift+DELETE押
                Case System.Windows.Forms.Keys.Delete And pm_Shift = 1
                    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    str_Renamed = .Text
                    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/17 CHG START
                    'If Len(str_Renamed) > 0 And .SelStart < Len(str_Renamed) Then
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    str_Renamed = Mid(str_Renamed, 1, .SelStart) & Mid(str_Renamed, .SelStart + 2)
                    '    str_Renamed = Replace(str_Renamed, "/", "")
                    '    'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    .SelStart = 0
                    If Len(str_Renamed) > 0 And .SelectionStart < Len(str_Renamed) Then
                        str_Renamed = Mid(str_Renamed, 1, .SelectionStart) & Mid(str_Renamed, .SelectionStart + 2)
                        str_Renamed = Replace(str_Renamed, "/", "")
                        .SelectionStart = 0
                        '2019/04/17 CHG E N D

                        If Len(str_Renamed) > 0 Then
                            'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/17 CHG START
                            '.SelLength = 1
                            .SelectionLength = 1
                            '2019/04/17 CHG E N D
                        End If
                    End If
                    'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Text = str_Renamed
                    '// V2.06↑ ADD

            End Select

        End With

    End Function
    '// V2.00↑ ADD

    '=======================================================回収予定日(開始)=======================================================

    '回収予定日クリック時
    Private Sub txt_kaidt_From_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Click

        txt_kaidt_From.SelectionStart = 0
        txt_kaidt_From.SelectionLength = 1

    End Sub

    '回収予定日項目を変更した時
    'UPGRADE_WARNING: イベント txt_kaidt_From.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_kaidt_From_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.TextChanged

        '日付変換処理
        Call Ctl_DTItem_Change(txt_kaidt_From)

    End Sub

    '回収予定日項目にフォーカスが移った時
    Private Sub txt_kaidt_From_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Enter

        'カーソル位置付け
        Call Ctl_DTItem_GotFocus(txt_kaidt_From)

        '検索処理を実行可能とする
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '回収予定日項目でキーを押した時
    Private Sub txt_kaidt_From_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_From.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        'キー入力制御
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
            Case 0
                '何もしない
            Case 1
                '入力チェック
                If chkKaidt_From() = True Then
                    '次項目
                    txt_kaidt_To.Focus()
                End If
            Case 2
                '入力チェック
                If chkKaidt_From() = True Then
                    '前項目
                    txt_tokseicd.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '回収予定日項目でキーを押した時
    Private Sub txt_kaidt_From_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_From.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '数値のみ入力可とする
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '回収予定日項目からフォーカスが移った時
    Private Sub txt_kaidt_From_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Leave

        '背景色を白に戻す
        txt_kaidt_From.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================回収予定日(終了)=======================================================

    '回収予定日クリック時
    Private Sub txt_kaidt_To_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Click

        txt_kaidt_To.SelectionStart = 0
        txt_kaidt_To.SelectionLength = 1

    End Sub

    '回収予定日項目を変更した時
    'UPGRADE_WARNING: イベント txt_kaidt_To.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_kaidt_To_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.TextChanged

        '日付変換処理
        Call Ctl_DTItem_Change(txt_kaidt_To)

    End Sub

    '回収予定日項目にフォーカスが移った時
    Private Sub txt_kaidt_To_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Enter

        'カーソル位置付け
        Call Ctl_DTItem_GotFocus(txt_kaidt_To)

        '検索処理を実行可能とする
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '回収予定日項目でキーを押した時
    Private Sub txt_kaidt_To_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_To.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        'キー入力制御
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
            Case 0
                '何もしない
            Case 1
                '入力チェック
                If chkKaidt_To() = True Then
                    '次項目
                    txt_kesikb.Focus()
                End If
            Case 2
                '入力チェック
                If chkKaidt_To() = True Then
                    '前項目
                    txt_kaidt_From.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '回収予定日項目でキーを押した時
    Private Sub txt_kaidt_To_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_To.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '数値のみ入力可とする
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '回収予定日項目からフォーカスが移った時
    Private Sub txt_kaidt_To_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Leave

        '背景色を白に戻す
        txt_kaidt_To.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================消込日=======================================================

    '消込日項目クリック時
    Private Sub txt_kesidt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Click

        txt_kesidt.SelectionStart = 0
        txt_kesidt.SelectionLength = 1

    End Sub

    '消込日項目を変更した時
    'UPGRADE_WARNING: イベント txt_kesidt.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_kesidt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.TextChanged

        '日付変換処理
        Call Ctl_DTItem_Change(txt_kesidt)

    End Sub

    '消込日項目にフォーカスが移った時
    Private Sub txt_kesidt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Enter

        intInputMode = 1

        'カーソル位置付け
        Call Ctl_DTItem_GotFocus(txt_kesidt)

        '2019/04/26 CHG START
        ''検索処理を実行可能とする
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D
    End Sub

    '消込日項目でキーを押した時
    Private Sub txt_kesidt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesidt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        intChkKb = 0

        'キー入力制御
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
            Case 0
                '何もしない
            Case 1
                '入力チェック
                If chkKesidt() = True Then
                    '次項目
                    txt_tokseicd.Focus()
                End If
            Case 2
                '入力チェック
                If chkKesidt() = True Then
                    '前項目
                    txt_kesidt.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '消込日項目でキーを押した時
    Private Sub txt_kesidt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesidt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '数値のみ入力可とする
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '消込日項目からフォーカスが移った時
    Private Sub txt_kesidt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Leave

        '背景色を白に戻す
        txt_kesidt.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================振込期日=======================================================

    '振込期日項目を変更した時
    'UPGRADE_WARNING: イベント txt_fridt.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub txt_fridt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.TextChanged

        'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
        If blnUsableEvent = False Then
            Exit Sub
        End If

        '日付変換処理
        Call Ctl_DTItem_Change(txt_fridt)

        blnUsableEvent = True

    End Sub

    '振込期日項目にフォーカスが移った時
    Private Sub txt_fridt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Enter

        'カーソル位置付け
        Call Ctl_DTItem_GotFocus(txt_fridt)

        '検索処理を実行可能とする
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '振込期日項目でキーを押した時
    Private Sub txt_fridt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_fridt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        'キー入力制御
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
            Case 0
                '何もしない
            Case 1
                '入力チェック
                If chkFridt() = True Then
                    '次項目
                    'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/23 CHG START
                    'spd_body.SetFocus()
                    spd_body.Focus()
                    '2019/04/23 CHG E N D
                End If
            Case 2
                '入力チェック
                If chkFridt() = True Then
                    '前項目
                    txt_kesikb.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '振込期日項目でキーを押した時
    Private Sub txt_fridt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_fridt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '数値のみ入力可とする
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '振込期日項目からフォーカスが移った時
    Private Sub txt_fridt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Leave

        '背景色を白に戻す
        txt_fridt.BackColor = System.Drawing.Color.White

    End Sub

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_FuncKey_Execute
    '   概要：  システム共通処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Short, ByVal pm_Shift As Short) As Short

        CF_FuncKey_Execute = 0

        Select Case True
            'F1キー押下
            Case pm_KeyCode = System.Windows.Forms.Keys.F1 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%1")

                'F2キー押下
            Case pm_KeyCode = System.Windows.Forms.Keys.F2 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%2")

                'F3キー押下
            Case pm_KeyCode = System.Windows.Forms.Keys.F3 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%3")
        End Select

    End Function
    '// V2.00↑ ADD

    '2019/04/24 DEL START
    ''// V2.00↓ ADD
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function CF_System_Process
    ''   概要：  システム共通処理
    ''   引数：　なし
    ''   戻値：　なし
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short

    '    'パッケージ内のＤＬＬにて
    '    '｢ＴＡＢ｣＆｢ＴＡＢ＋ＳＨＩＦＴ｣をそれぞれ｢Ｆ１６｣＆｢Ｆ１５｣に割当
    '    ReleaseTabCapture(0)
    '    SetTabCapture(pm_Form.Handle.ToInt32)

    'End Function
    ''// V2.00↑ ADD
    '2019/04/24 DEL E N D

    '// V2.13↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Sub chkFurikomiDT
    '   概要： TOKMTA.SHAKB（支払条件）に手形が入っている場合は振込期日が必須
    '       ： 売上げ請求締日＞得意先の請求締日の時金額が変更されていたらエラー
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkFurikomiDT() As Boolean

        Dim idxRow As Integer
        Dim tmp As Object
        Dim intchk As Short
        Dim strHYFRIDT As String
        '2009/10/01 ADD START RISE)MIYAJIMA COL_BFHYFRIDT
        Dim intchk_mae As Short
        Dim vntBFHYFRIDT As Object
        '2009/10/01 ADD E.N.D RISE)MIYAJIMA

        chkFurikomiDT = False

        If blnFriEnabled = False Then
            chkFurikomiDT = True
            Exit Function
        End If

        '返品を検索
        With spd_body
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D

                'チェックが入っているかを確認
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_CHK)
                '2019/04/23 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/25 CHG START
                'intchk = SSSVal(tmp)
                intchk = SSSVal(IIf(tmp = True, 1, 0))
                '2019/04/25 CHG E N D

                'チェックが入っている場合
                If intchk = 1 Then
                    '売上日の取得
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/23 CHG START
                    'Call .GetText(COL_HYFRIDT, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYFRIDT)
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strHYFRIDT = CStr(tmp)

                    '2009/09/27 UPD START RISE)MIYAJIMA
                    '                If Trim(strHYFRIDT) = "" Then
                    '                    Call showMsg("0", "_COMPLETEC", 0)     '●入力されていない項目があります。入力してください。
                    '                    Exit Function
                    '                End If
                    '2009/10/01 UPD START RISE)MIYAJIMA
                    '                If Trim(gstrFridt) <> "" Then
                    '                    If Trim(strHYFRIDT) = "" Then
                    '                        Call showMsg("0", "_COMPLETEC", 0)     '●入力されていない項目があります。入力してください。
                    '                        Exit Function
                    '                    End If
                    '                End If

                    'チェックが入っているかを確認
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/23 CHG START
                    '.GetText(COL_BFCHECK, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_BFCHECK)
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    intchk_mae = SSSVal(tmp)
                    '売上日の取得
                    'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/23 CHG START
                    'Call .GetText(COL_BFHYFRIDT, idxRow, vntBFHYFRIDT)
                    vntBFHYFRIDT = .GetValue(idxRow, COL_BFHYFRIDT)
                    '2019/04/23 CHG E N D

                    If intchk_mae <> 1 Then
                        If Trim(gstrFridt.Value) <> "" Then
                            If Trim(strHYFRIDT) = "" Then
                                Call showMsg("0", "_COMPLETEC", CStr(0)) '●入力されていない項目があります。入力してください。
                                Exit Function
                            End If
                        End If
                    End If
                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                    '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                End If
            Next idxRow
        End With

        chkFurikomiDT = True

    End Function

    '2009/09/08 UPD START RISE)MIYAJIMA
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称： Function chk_HENPIN
    ''   概要： 未来に返品が発生しているかチェックする
    ''   引数： strJdnNo   : 受注伝票番号
    ''   　　： strJdnlinNo: 受注伝票行番号
    ''       :  strUrikn   : 売上金額
    ''   戻値： チェック結果
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Function chkHenpin2(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUDNDT As String) As Boolean
    '
    '    Dim Usr_Ody         As U_Ody
    '    Dim strSql          As String
    '
    '    On Error GoTo ERR_chkHENPIN2
    '
    '    '//表示します
    '    chkHenpin2 = True
    '
    '    If Trim$(gstrKaidt_Fr) = "" Then
    '        '//表示します
    '        GoTo END_chkHENPIN2
    '    End If
    '
    '    '//未来に返品データが存在しているか確認する
    '    strSql = " "
    '    strSql = " SELECT *"
    '    strSql = strSql & " FROM    UDNTRA"
    '    strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
    '    strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
    '    strSql = strSql & " AND     DATKB =  '1'"
    ''2009/09/03 UPD START RISE)MIYAJIMA
    ''    strSql = strSql & " AND     AKAKROKB =  '9'"
    ''    strSql = strSql & " AND     DKBID    =  '02'"
    '    strSql = strSql & " AND     AKAKROKB =  '1'"
    '    strSql = strSql & " AND     DKBID    =  '01'"
    ''2009/09/03 UPD E.N.D RISE)MIYAJIMA
    ''2009/09/03 DEL START RISE)MIYAJIMA
    ''    strSql = strSql & " AND     UDNDT    >= '" & gstrKaidt_Fr & "'"
    ''2009/09/03 DEL E.N.D RISE)MIYAJIMA
    '    strSql = strSql & " AND     UDNDT    <= '" & gstrKaidt_To & "'"
    '
    '    'DBアクセス
    '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '    'データが存在した場合
    '    If CF_Ora_EOF(Usr_Ody) = False Then
    '
    '        Select Case txt_kesikb.Text
    '            Case 1
    '                '消込されていない場合、処理を行う
    '                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
    '                    '//表示します
    '                    GoTo END_chkHENPIN2
    '                Else
    '                    '//表示しません
    '                    chkHenpin2 = False
    '                    GoTo END_chkHENPIN2
    '                End If
    '            Case 9
    ''2009/09/03 UPD START RISE)MIYAJIMA
    ''                '消込されていない場合、処理を行う
    ''                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
    '                '消込されていない場合、処理を行う
    '                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
    ''2009/09/03 UPD E.N.D RISE)MIYAJIMA
    '                    '//表示します
    '                    GoTo END_chkHENPIN2
    '                Else
    '                    '//表示しません
    '                    chkHenpin2 = False
    '                    GoTo END_chkHENPIN2
    '                End If
    '        End Select
    '
    '        '//表示します
    '        GoTo END_chkHENPIN2
    '
    '    End If
    '
    '    'データが存在しなかった場合
    '    If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
    '        '//表示しません
    '        chkHenpin2 = False
    '        GoTo END_chkHENPIN2
    '    End If
    '
    'END_chkHENPIN2:
    '    'クローズ
    '    Call CF_Ora_CloseDyn(Usr_Ody)
    '
    '    Exit Function
    '
    'ERR_chkHENPIN2:
    '    GoTo END_chkHENPIN2
    '
    'End Function
    ''// V2.13↑ ADD

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function chkDspData
    '   概要： データを表示していいかの判断を行う
    '   引数： strJdnNo   : 受注伝票番号
    '   　　： strJdnlinNo: 受注伝票行番号
    '       :  strUDNDT   :
    '       :  strKOMIKN  :
    '       :  strKESIKN  :
    '   戻値： チェック結果(False:表示対象外データ true:表示対象)
    '   備考： 画面の範囲内に赤黒データが存在しているか確認しなければ表示しない
    '   　　： 画面の消込データ表示区分にしたがって表示するかしないかを決定する
    '   　　： 画面の範囲で指定されているデータのみを表示するために範囲の確認をする
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Function chkDspData(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUDNDT As String, ByVal strKOMIKN As String, ByVal strKESIKN As String) As Boolean

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkDspData

        '//表示します
        chkDspData = True

        '2009/09/10 DEL START RISE)MIYAJIMA
        '    '★画面の範囲内に赤黒データが存在しているか確認しなければ表示しない
        '
        '    '//範囲外に片割れがいるか確認する
        '    strSql = ""
        '    strSql = strSql & " SELECT COUNT(*) DATCNT FROM UDNTRA" & vbCrLf
        '    strSql = strSql & " WHERE " & vbCrLf
        '    strSql = strSql & "      JDNNO    = '" & strJDNNO & "'" & vbCrLf
        '    strSql = strSql & " AND  JDNLINNO = '" & strJdnlinNo & "'" & vbCrLf
        '    strSql = strSql & " AND ((DKBID   = '01' AND AKAKROKB = '1')" & vbCrLf
        '    strSql = strSql & "       OR" & vbCrLf
        '    strSql = strSql & "      (DKBID  <> '01' AND AKAKROKB = '9'))" & vbCrLf
        '    strSql = strSql & " AND  DATKB    = '1'" & vbCrLf
        '    strSql = strSql & " AND  DENKB    = '1'" & vbCrLf
        '    If Trim(gstrKaidt_Fr) <> "" Then
        '        strSql = strSql & " AND (UDNDT < '" & gstrKaidt_Fr & "'" & " OR  UDNDT > '" & gstrKaidt_To & "')" & vbCrLf
        '    Else
        '        strSql = strSql & " AND  UDNDT    > '" & gstrKaidt_To & "'" & vbCrLf
        '    End If
        '    strSql = strSql & " AND  SSADT    > '" & DB_TOKMTA2.TOKSMEDT & "'" & vbCrLf
        '
        '    'DBアクセス
        '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        '
        '    'データが存在した場合
        '    If CF_Ora_EOF(Usr_Ody) = False Then
        '        If CF_Ora_GetDyn(Usr_Ody, "DATCNT", "") <> 0 Then
        '            '//表示しません（範囲外にいるのでひょうじしない）
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '
        '    '★画面の消込データ表示区分にしたがって表示するかしないかを決定する
        '    If txt_kesikb.Text = "1" Then
        '
        '        If strKOMIKN = strKESIKN Then
        '
        '            '//未来に返品データが存在しているか確認する
        '            strSql = " "
        '            strSql = strSql & " SELECT COUNT(*) DATCNT" & vbCrLf
        '            strSql = strSql & " FROM   UDNTRA" & vbCrLf
        '            strSql = strSql & " WHERE  JDNNO    =  '" & strJDNNO & "'" & vbCrLf
        '            strSql = strSql & " AND    JDNLINNO =  '" & strJdnlinNo & "'" & vbCrLf
        '            strSql = strSql & " AND    DATKB    =  '1'" & vbCrLf
        '            strSql = strSql & " AND    AKAKROKB =  '9'" & vbCrLf
        '            strSql = strSql & " AND    DKBID    IN  ('02','06')" & vbCrLf
        '            If Trim(gstrKaidt_Fr) <> "" Then
        '                strSql = strSql & " AND    UDNDT    >= '" & gstrKaidt_Fr & "'" & vbCrLf
        '            End If
        '            strSql = strSql & " AND    UDNDT    <= '" & gstrKaidt_To & "'" & vbCrLf
        '            strSql = strSql & " AND    SSADT    <= '" & DB_TOKMTA2.TOKSMEDT & "'" & vbCrLf
        '
        '            'DBアクセス
        '            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        '
        '            'データが存在した場合
        '            If CF_Ora_EOF(Usr_Ody) = False Then
        '                If CF_Ora_GetDyn(Usr_Ody, "DATCNT", "") = 0 Then
        '                    '//表示しません
        '                    chkDspData = False
        '                    GoTo END_chkDspData
        '                End If
        '            End If
        '
        '        End If
        '    End If
        '
        '    '★画面の範囲で指定されているデータのみを表示するために範囲の確認をする
        '    If Trim(gstrKaidt_Fr) <> "" Then
        '        If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
        '            '//表示しません
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '    If Trim(gstrKaidt_To) <> "" Then
        '        If Trim$(strUDNDT) > Trim$(gstrKaidt_To) Then
        '            '//表示しません
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '2009/09/10 DEL E.N.D RISE)MIYAJIMA

END_chkDspData:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_chkDspData:
        GoTo END_chkDspData

    End Function
    '2009/09/08 UPD E.N.D RISE)MIYAJIMA

    '// V3.10↓ ADD
    '振込期日の入力可能判断
    Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)

        Dim strSql As Object
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        Dim curNYUKIN1 As Short
        Dim curNYUKIN2 As Short

        '消込日月度の消込状態を取得
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = ""
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & " SELECT * "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "   FROM NKSSMA "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

        'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 CHG E N D

        '振込期日を入力できるかどうかのフラグを設定する
        blnFriEnabled = False

        '2019/04/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If
        End If
        '2019/04/18 CHG E N D

        ''''    blnFriEnabled = False
        ''''
        ''''    '振込期日を入力できるかどうかのフラグを設定する(手形、期日振込データが存在する場合は入力可能とする）
        ''''    strSql = " "
        ''''    strSql = " SELECT count(*) DATCNT "
        ''''    strSql = strSql & " FROM    UDNTRA"
        ''''    strSql = strSql & " WHERE   DATKB =  '1'"
        ''''    strSql = strSql & " AND     DENKB =  '8' "
        ''''    strSql = strSql & " AND     DKBID IN ('03','08') "
        ''''    strSql = strSql & " AND     UDNDT <= '" & gstrKaidt_To & "'"
        ''''
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''''        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "DATCNT", "")) <> 0 Then
        ''''            blnFriEnabled = True
        ''''        End If
        ''''    End If

END_getInputHYFRIDT:

        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
    End Sub
    '// V3.10↑ ADD

    '2009/09/03 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Util_GET_TANMTA_TANCLAKB
    '   概要：  営業担当フラグを取得
    '   引数：　pot_strTANCD       : 担当者コード
    '       ：　pot_strKEIBMNCD    : 営業担当フラグ
    '   戻値：　0:正常終了 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB

        F_Util_GET_TANMTA_TANCLAKB = 9

        pot_strTANCLAKB = ""

        '担当者Ｍ
        strSql = ""
        strSql = strSql & " SELECT TANCLAKB "
        strSql = strSql & " FROM TANMTA "
        strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DBアクセス
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            pot_strTANCLAKB = DB_NullReplace(dt.Rows(0)("TANCLAKB"), "")
            '2019/04/18 CHG E N D
        Else
            GoTo END_F_Util_GET_TANMTA_TANCLAKB
        End If

        F_Util_GET_TANMTA_TANCLAKB = 0

END_F_Util_GET_TANMTA_TANCLAKB:
        'クローズ
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_F_Util_GET_TANMTA_TANCLAKB:
        GoTo END_F_Util_GET_TANMTA_TANCLAKB

    End Function
    '2009/09/03 ADD E.N.D RISE)MIYAJIMA

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    連絡票№CF10042801
    '//***************************************************************************************
    '//*
    '//* <名  称>
    '//*    CF_Ctr_AnsiLeftB
    '//*
    '//* <戻り値>     型          説明
    '//*              String      変換後の文字列
    '//*
    '//* <引  数>     項目名             型              I/O           内容
    '//*              pm_Value           String           I            対象文字列
    '//*              pm_Len             Long             I            文字列の長さ
    '//* <説  明>
    '//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
    '//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |新規作成
    '//**************************************************************************************
    Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

        ' --------------+---------------+---------------+---------------+---------------
        Dim lngIdx As Integer
        Dim lngStep As Integer
        Dim bytWrk() As Byte
        Dim lngLength As Integer
        ' --------------+---------------+---------------+---------------+---------------

        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
        '2019/04/18 CHG START
        'bytWrk = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pm_Value, vbFromUnicode))
        bytWrk = System.Text.UnicodeEncoding.Unicode.GetBytes(pm_Value)
        '2019/04/18 CHG E N D

        lngLength = 0

        lngIdx = LBound(bytWrk)
        Do While lngIdx <= UBound(bytWrk)
            If IsDBCSLeadByte(bytWrk(lngIdx)) = False Then
                lngStep = 1
            Else
                lngStep = 2
            End If
            lngIdx = lngIdx + lngStep
            If (lngLength + lngStep) > pm_Len Then
                Exit Do
            End If
            lngLength = lngLength + lngStep
        Loop

        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: MidB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/18 CHG START
        'pm_Value = StrConv(MidB$(bytWrk, lngLength + 1), vbUnicode)
        pm_Value = MidB(pm_Value, lngLength + 1)
        '2019/04/18 CHG E N D
        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/18 CHG START
        'CF_Ctr_AnsiLeftB = StrConv(LeftB$(bytWrk, lngLength), vbUnicode)
        CF_Ctr_AnsiLeftB = LeftB(pm_Value, lngLength)
        '2019/04/18 CHG E N D
        Exit Function

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_IniInf
    '   概要：  Iniファイル読込み処理（プログラム固有）
    '   引数：  pin_strSection :
    '   戻値：  0 : 正常 9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short

        Dim Wk As New VB6.FixedLengthString(256)
        Dim lngRet As Integer

        CF_Get_IniInf = 9

        pot_strValue = ""

        'Iniファイル読込み
        lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
        If lngRet > 0 Then
            '2019/05/24 CHG START
            'pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
            pot_strValue = Mid(Wk.Value, 1, InStr(Wk.Value, vbNullChar) - 1)
            '2019/05/24 CHG E N D
            pot_strValue = Trim(pot_strValue)
        Else
            Exit Function
        End If

        CF_Get_IniInf = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function funcGetIni
    '   概要： INIファイル読込処理
    '   引数： なし
    '   戻値： TRUE : 正常 FALSE : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcGetIni() As Boolean

        Dim intRet As Short

        On Error GoTo Err_Run

        funcGetIni = False

        'INIファイル読込み
        '出力ファイル名
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_OUTNAME, gv_strOUT_NAME)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '出力ファイル拡張子
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_OUTTYPE, gv_strOUT_TYPE)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '区切り文字
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_TABCHAR, gv_strTAB_CHAR)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '数値チェック
        If Not IsNumeric(gv_strTAB_CHAR) Then
            GoTo Err_Run
        End If
        gv_strTAB_CHAR = Chr(CInt(gv_strTAB_CHAR))

        funcGetIni = True

Exit_Run:

        Exit Function

Err_Run:

        GoTo Exit_Run

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function funcOutput
    '   概要：  ファイル出力処理（上書き）
    '   引数：  pin_strOUT_PATH    : 出力ファイルパス
    '           pin_strOUT_TXT     : 出力テキスト
    '   戻値：  TRUE : 正常 FALSE : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutput(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_TXT As Object) As Boolean

        Dim intFNo As Short
        Dim bolOpen As Boolean

        On Error GoTo Err_Run

        funcOutput = False
        bolOpen = False

        intFNo = FreeFile()

        'ファイルオープン
        FileOpen(intFNo, Trim(pin_strOUT_PATH), OpenMode.Output)
        bolOpen = True

        PrintLine(intFNo, pin_strOUT_TXT)

        funcOutput = True

Err_Run:

        If bolOpen = True Then
            'クローズ
            FileClose(intFNo)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function funcOutput_Append
    '   概要：  ファイル出力処理（追記）
    '   引数：  pin_strOUT_PATH    : 出力ファイルパス
    '           pin_strOUT_TXT     : 出力テキスト
    '   戻値：  TRUE : 正常 FALSE : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutput_Append(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_TXT As Object) As Boolean

        Dim intFNo As Short
        Dim bolOpen As Boolean

        On Error GoTo Err_Run

        funcOutput_Append = False
        bolOpen = False

        intFNo = FreeFile()

        'ファイルオープン
        FileOpen(intFNo, Trim(pin_strOUT_PATH), OpenMode.Append)
        bolOpen = True

        PrintLine(intFNo, pin_strOUT_TXT)

        funcOutput_Append = True

Err_Run:

        If bolOpen = True Then
            'クローズ
            FileClose(intFNo)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function funcOutPutCSV
    '   概要： CSV出力処理
    '   引数： pin_strOUT_PATH   : CSV出力先
    '   戻値： TRUE : 正常 FALSE : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutPutCSV(ByVal pin_strOUT_PATH As String) As Boolean

        Dim i As Short
        Dim count As Short
        Dim bolRet As Boolean
        Dim strTXT As String
        Dim tmp As Object
        Dim rowNo As Short

        On Error GoTo Err_Run

        funcOutPutCSV = False
        strTXT = ""

        'ヘッダ
        'PGID
        strTXT = strTXT & """" & SSS_PrgId & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '作表日
        'UPGRADE_WARNING: オブジェクト pnl_unydt.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strTXT = strTXT & """" & pnl_unydt.Text & "出力"""
        strTXT = strTXT & vbCrLf

        '検索条件
        '項目名
        strTXT = strTXT & """消込日""" & gv_strTAB_CHAR & """請求先""" & gv_strTAB_CHAR & """請求先名""" & gv_strTAB_CHAR & """売上日"""
        strTXT = strTXT & vbCrLf

        '消込日
        strTXT = strTXT & """" & txt_kesidt.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '請求先
        strTXT = strTXT & """" & txt_tokseicd.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '請求先名
        strTXT = strTXT & """" & txt_tokseinma.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '売上日
        strTXT = strTXT & """" & Trim(txt_kaidt_From.Text) & "～" & txt_kaidt_To.Text & """"
        strTXT = strTXT & vbCrLf

        'ファイルへ出力
        If Not funcOutput(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If
        strTXT = ""

        '消込情報
        '中見出し
        strTXT = strTXT & """＜消込情報＞"""
        strTXT = strTXT & vbCrLf
        '項目名
        strTXT = strTXT & """売上合計""" & gv_strTAB_CHAR & """入金額""" & gv_strTAB_CHAR & """手数料"""
        strTXT = strTXT & gv_strTAB_CHAR & """消費税差額""" & gv_strTAB_CHAR & """入金合計""" & gv_strTAB_CHAR & """消込残額"""
        strTXT = strTXT & vbCrLf
        '売上合計
        strTXT = strTXT & """" & txt_urigoukei.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '入金額
        strTXT = strTXT & """" & txt_nyukin.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '手数料
        strTXT = strTXT & """" & txt_tesuryo.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '消費税差額
        strTXT = strTXT & """" & txt_syohi.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '入金合計
        strTXT = strTXT & """" & txt_nyugoukei.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '消込残額
        strTXT = strTXT & """" & txt_kesizan.Text & """"
        strTXT = strTXT & vbCrLf
        'ファイルへ出力
        If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If
        strTXT = ""

        '明細
        '項目名
        strTXT = strTXT & """消込""" & gv_strTAB_CHAR & """№""" & gv_strTAB_CHAR & """帳端""" & gv_strTAB_CHAR & """売上日"""
        strTXT = strTXT & gv_strTAB_CHAR & """受注番号""" & gv_strTAB_CHAR & """回収予定日""" & gv_strTAB_CHAR & """客先注文番号"""
        strTXT = strTXT & gv_strTAB_CHAR & """営業担当者""" & gv_strTAB_CHAR & """税抜売上金額""" & gv_strTAB_CHAR & """消費税額"""
        strTXT = strTXT & gv_strTAB_CHAR & """税込売上金額""" & gv_strTAB_CHAR & """入金済額""" & gv_strTAB_CHAR & """振込期日"""
        strTXT = strTXT & vbCrLf
        '100行を超えたらファイル出力
        count = 1
        With spd_body
            'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/23 CHG START
            'For i = 1 To .MaxRows
            For i = 0 To .RowCount - 1
                '2019/04/23 CHG E N D 
                '№
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_NO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_NO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    rowNo = SSSVal(tmp)
                Else
                    Exit For
                End If

                '消込
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_CHK, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_CHK)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                Else
                    strTXT = strTXT & """0"""
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '№
                strTXT = strTXT & """" & rowNo & """"
                strTXT = strTXT & gv_strTAB_CHAR
                '帳端
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_NXTKB, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_NO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '売上日
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYUDNDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYUDNDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '受注番号
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYJDNNO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYJDNNO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '回収予定日
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYKAIDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYKAIDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '客先注文番号
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_TOKJDNNO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_TOKJDNNO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '営業担当者
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_TANNM, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_TANNM)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '税抜売上金額
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/04/23 CHG START
                'bolRet = .GetText(COL_URIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_URIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '消費税額
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_UZEKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_UZEKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '税込売上金額
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_KOMIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_KOMIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '入金済額
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_KESIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_KESIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '振込期日
                'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYFRIDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYFRIDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strTXT = strTXT & """" & tmp & """"
                End If

                If count >= 100 Then
                    'ファイルへ出力
                    If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
                        GoTo Err_Run
                    End If

                    strTXT = ""
                    count = 0
                Else
                    strTXT = strTXT & vbCrLf
                End If

                count = count + 1
            Next i
        End With

        'ファイルへ出力
        If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If

        funcOutPutCSV = True

Exit_Run:

        Exit Function

Err_Run:

        GoTo Exit_Run

    End Function
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    '2018/10/26 ADD START <C2-20181002-01> CIS)山口
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_GET_EIGYO_DAY
    '   概要：  銀行営業日を取得
    '   引数：　strHYFRIDT       : 明細．振込期日
    '   戻値：　1 : 正常 9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_GET_EIGYO_DAY(ByVal strHYFRIDT As String) As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_F_GET_EIGYO_DAY

        F_GET_EIGYO_DAY = 9

        'カレンダＭ
        strSql = ""
        strSql = strSql & " SELECT BNKKDKB "
        strSql = strSql & " FROM CLDMTA "
        strSql = strSql & " WHERE DATKB = '1' "
        strSql = strSql & " AND     CLDDT = '" & Replace(strHYFRIDT, "/", "") & "' "

        'DBアクセス
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, BNKKDKB, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") = "1" Then

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            If DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") = "1" Then
                '2019/04/18 CHG E N D
                F_GET_EIGYO_DAY = 1
            End If
        Else
            F_GET_EIGYO_DAY = 8
        End If

END_F_GET_EIGYO_DAY:
        'クローズ
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_F_GET_EIGYO_DAY:
        GoTo END_F_GET_EIGYO_DAY

    End Function

    '2018/10/26 ADD END <C2-20181002-01> CIS)山口

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

    '2019/04/25 ADD START
    '更新ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mnu_regist_Click(Button1, New System.EventArgs())
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        mnu_showwnd_Click(Button5, New System.EventArgs())
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim li_MsgRtn As Integer

        Try
            'change 20190809 START hou
            'img_unlock_Click(Button9, New System.EventArgs())
            initForm()
            initCondition()
            initHead()
            initBody()
            intInputMode = 1
            'change 20190809 END hou
        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    '終了ボタン
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim li_MsgRtn As Integer

        Try
            Me.Close()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面終了エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    Private Sub cmd_kesidt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kesidt.Click
        cmd_kesidt_Click()
    End Sub

    Private Sub cmd_tokseicd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tokseicd.Click
        cmd_tokseicd_Click()
    End Sub

    Private Sub cmd_kaidt_From_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kaidt_From.Click
        cmd_kaidt_From_Click()
    End Sub

    Private Sub cmd_kaidt_To_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kaidt_To.Click
        cmd_kaidt_To_Click()
    End Sub

    Private Sub cmd_fridt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_fridt.Click
        cmd_fridt_Click()
    End Sub

    Private Sub cmd_tesuryo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tesuryo.Click
        cmd_tesuryo_Click()
    End Sub

    Private Sub cmd_syohi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_syohi.Click
        cmd_syohi_Click()
    End Sub

    Private Sub cmd_zenkaijo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_zenkaijo.Click
        cmd_zenkaijo_Click()
    End Sub

    Private Sub cmd_zenkesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_zenkesi.Click
        cmd_zenkesi_Click()
    End Sub

    Private Sub cmd_saihyoji_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_saihyoji.Click
        cmd_saihyoji_Click()
    End Sub

    Private Sub cmd_csvout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_csvout.Click
        cmd_csvout_Click()
    End Sub

    Private Sub spd_body_Enter(sender As Object, e As EventArgs) Handles spd_body.Enter
        spd_body_GotFocus()
    End Sub

    Private Sub FR_SSSMAIN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub FKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.Button1.PerformClick()

                Case Keys.F5
                    Me.Button5.PerformClick()

                Case Keys.F9
                    Me.Button9.PerformClick()

                Case Keys.F12
                    Me.Button12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    Private Sub spd_body_CellClick(sender As Object, e As GrapeCity.Win.MultiRow.CellEventArgs) Handles spd_body.CellClick

        Select Case e.CellIndex
            Case COL_CHK
                If spd_body.GetValue(e.RowIndex, e.CellIndex) = False Then
                    spd_body_ButtonClicked(e.CellIndex, e.RowIndex, 1)
                Else
                    spd_body_ButtonClicked(e.CellIndex, e.RowIndex, 0)
                End If

        End Select
    End Sub

    Private Sub spd_body_CellValidated(sender As Object, e As GrapeCity.Win.MultiRow.CellEventArgs) Handles spd_body.CellValidated

        Dim InData As String = StrConv(Trim(spd_body.GetValue(e.RowIndex, e.CellIndex)), VbStrConv.Narrow).Replace(",", "")
        Select Case e.CellIndex
            Case COL_KESIKN
                If InData = "" OrElse IsNumeric(InData) = False Then
                    spd_body.SetValue(e.RowIndex, e.CellIndex, 0)
                Else
                    spd_body.SetValue(e.RowIndex, e.CellIndex, String.Format("{0:#,0}", Integer.Parse(InData)))
                End If
        End Select
    End Sub

    Private Sub spd_body_CellEndEdit(sender As Object, e As GrapeCity.Win.MultiRow.CellEndEditEventArgs) Handles spd_body.CellEndEdit

        With spd_body
            Select Case e.CellIndex
                Case COL_HYFRIDT
                    '日付変換処理
                    Dim a As String = CNV_DATE(.GetValue(e.RowIndex, e.CellIndex))
                    .SetValue(e.RowIndex, e.CellIndex, a)
            End Select
        End With

    End Sub
    '2019/04/25 ADD E N D

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        '==========================================================================
        '   関数:CSV出力ボタン押下時処理
        '   概要:明細内容CSV出力処理
        '
        '   作成・更新      担当者      変更内容
        '   2019/06/07      FJ)頃安     新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値
        Dim lb_Ret As Boolean       '関数の戻り値

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '確認メッセージ（CSV出力を行います。よろしいですか？）
            If showMsg("1", "URKET53_045", "0") = MsgBoxResult.Yes Then

                'CSV出力
                lb_Ret = M0_OutCSV()
                If lb_Ret = False Then
                    'フォーカスのセット
                    Me.spd_body.Focus()
                    Exit Sub
                End If

                'フォーカスのセット
                Me.spd_body.Focus()

            End If

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV出力処理エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    Private Function M0_OutCSV() As Boolean
        '==========================================================================
        '   関数:CSV出力処理
        '   概要:明細内容をCSVファイルに出力する
        '
        '   IO  引数            値          内容
        '    なし
        '
        '   戻り値              値          内容
        '                       True        正常終了
        '                       False       異常終了
        '
        '   作成・更新      担当者      変更内容
        '   2019/06/07      FJ)頃安     新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer        'MsgBoxの戻り値
        Dim lb_Ret As Boolean           '関数の戻り値
        Dim lt_CSVCell() As pst_CSVCell 'CSV対象ｾﾙ配列
        Dim ls_HedNm As String          'ﾍｯﾀﾞ文字列

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '戻り値の設定
            M0_OutCSV = False

            '砂時計設定
            Me.Cursor = Cursors.WaitCursor

            'CSV対象ｾﾙ配列作成
            ReDim lt_CSVCell(11)
            ls_HedNm = ""
            ls_HedNm = ls_HedNm & "No."
            lt_CSVCell(0).pss_Key = "GcNumberCell1"
            lt_CSVCell(0).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""帳端"
            lt_CSVCell(1).pss_Key = "GcNumberCell2"
            lt_CSVCell(1).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""売上日"
            lt_CSVCell(2).pss_Key = "GcTextBoxCell4"
            lt_CSVCell(2).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""受注番号"
            lt_CSVCell(3).pss_Key = "GcTextBoxCell1"
            lt_CSVCell(3).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""回収予定日"
            lt_CSVCell(4).pss_Key = "GcTextBoxCell5"
            lt_CSVCell(4).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""客先注文番号"
            lt_CSVCell(5).pss_Key = "GcTextBoxCell2"
            lt_CSVCell(5).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""営業担当者"
            lt_CSVCell(6).pss_Key = "GcTextBoxCell3"
            lt_CSVCell(6).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""税抜売上金額"
            lt_CSVCell(7).pss_Key = "GcTextBoxCell26"
            lt_CSVCell(7).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""消費税額"
            lt_CSVCell(8).pss_Key = "GcTextBoxCell27"
            lt_CSVCell(8).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""税込売上金額"
            lt_CSVCell(9).pss_Key = "GcTextBoxCell28"
            lt_CSVCell(9).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""入金済額"
            lt_CSVCell(10).pss_Key = "GcTextBoxCell29"
            lt_CSVCell(10).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""振込期日"
            lt_CSVCell(11).pss_Key = "GcTextBoxCell6"
            lt_CSVCell(11).pss_Type = CGS_TYPE_TEXT

            '------------------------------
            ' CSV出力関数
            '------------------------------
            lb_Ret = COM_CSV_OUTPUT_LIST(Me.Name, lt_CSVCell, "", True, "", Me.spd_body, ls_HedNm)
            If lb_Ret = False Then
                Exit Function
            End If

            '---戻り値の設定---'
            M0_OutCSV = True

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV出力関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally
            '砂時計設定
            Me.Cursor = Cursors.Default
        End Try

    End Function

End Class