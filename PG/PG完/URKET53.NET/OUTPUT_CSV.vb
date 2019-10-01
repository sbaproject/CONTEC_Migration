Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports GrapeCity.Win.MultiRow
Imports PronesDbAccess
Module OUTPUT_CSV
#Region "■フィールド"
    ''' <summary>
    ''' ヘッダ情報の表示最大行数
    ''' </summary>
    ''' <remarks></remarks>
    Private Dt_SYKList_1_MaxRow As Integer = 100

    ''' <summary>
    ''' ヘッダ情報の警告行数
    ''' </summary>
    ''' <remarks></remarks>
    Private Dt_SYKList_1_ListWarningRow As Integer = 75

    ''' <summary>
    ''' 明細情報の表示最大行数
    ''' </summary>
    ''' <remarks></remarks>
    Private Dt_SYKList_MaxRow As Integer = 999

    ''' <summary>
    ''' 明細一覧の警告行数
    ''' </summary>
    ''' <remarks></remarks>
    Private Dt_SYKList_ListWarningRow As Integer = 500

    ''' <summary>
    ''' CSV出力の出力列群
    ''' </summary>
    ''' <remarks></remarks>
    'Private _csvOutSYKListColumns As New List(Of String)

    '''' <summary>
    '''' CSV出力の出力列群
    '''' </summary>
    '''' <remarks></remarks>
    'Private _csvHeaderColumns As New List(Of String)

    '''' <summary>
    '''' CSV出力の出力列群_ヘッダ
    '''' </summary>
    '''' <remarks></remarks>
    'Private _csvOutSYKListColumns_head As New List(Of String)

    '''' <summary>
    '''' CSV出力の出力列群_ヘッダ
    '''' </summary>
    '''' <remarks></remarks>
    'Private _csvHeaderColumns_head As New List(Of String)

    '''' <summary>
    '''' CSV出力の出力列群_当月除外平均
    '''' </summary>
    '''' <remarks></remarks>
    'Private _csvOutSYKListColumns_avg As New List(Of String)

    '''' <summary>
    '''' CSV出力の出力列群_当月除外平均
    '''' </summary>
    '''' <remarks></remarks>
    'Private _csvHeaderColumns_avg As New List(Of String)
    'Private _csvOutSYKListColumns As New List(Of String)

    'CSV対象ｾﾙ情報
    Public Structure pst_CSVCell
        Dim pss_Key As String               'ｾﾙｷｰ
        Dim pss_Type As String              'EditorType
    End Structure

    '有効ｾﾙﾀｲﾌﾟ定数
    Public Const CGS_TYPE_TEXT As String = "1"                          '文字列項目
    Public Const CGS_TYPE_COMBO_V As String = "2"                       '拡張ｺﾝﾎﾞ項目（ﾊﾞﾘｭｰ）
    Public Const CGS_TYPE_COMBO_T As String = "3"                       '拡張ｺﾝﾎﾞ項目（ﾃｷｽﾄ）
    Public Const CGS_TYPE_DATE As String = "4"                          '日付項目
    Public Const CGS_TYPE_NUMBER As String = "5"                        '数値項目

    'コンボボックス表示モード定数
    Public Const CGS_MODE_VALUE As String = "1"                         '値のみ表示モード
    Public Const CGS_MODE_DESCRIPTION As String = "2"                   '説明のみ表示モード
    Public Const CGS_MODE_BOTH As String = "3"                          '値、説明の両方表示モード

#End Region

#Region ""

#End Region
#Region "メイン処理"
    ''' <summary>
    ''' CSV出力のメイン処理を行います。
    ''' </summary>
    ''' <param name="p_view">ビュー</param>
    ''' <param name="inNAME">CSV出力ダイアログのタイトル</param>
    ''' <returns>処理結果(True:正常、False:異常)</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' <detail date="2017/11/27" author="富士通)橋本" bugNo="">新規作成</detail>
    ''' </history>
    Friend Function OutputCsvMain(ByVal p_view As Object, ByVal inNAME As String) As Boolean

        ' ■引数チェック---
        If p_view Is Nothing Then
            Throw New ArgumentNullException("p_view")
        End If

        ' ■各処理に渡す情報を作成
        'ヘッダ部分
        Dim searchModel_head As New SearchActionModel()
        With searchModel_head
            .View = p_view
        End With

        ' ■CSV出力パスの取得(ダイアログ表示)
        Dim baseFileName As String = p_view.Ic_HINCD.Text & "_{0:yyyyMMdd}.txt"
        Dim csvPath As String = Nothing
        csvPath = "V:\"
        If ShowTextSaveDialog(csvPath, inNAME, String.Format(baseFileName, DateTime.Now)) <> DialogResult.OK Then
            Return False
        End If

        ' ■各処理に渡す情報を作成
        '明細部分
        Dim searchModel_meisai As New SearchActionModel()
        With searchModel_meisai
            .View = p_view
            .CsvPath = csvPath
        End With

        '当月除外平均　ここいるか微妙
        Dim searchModel_avg As New SearchActionModel()
        With searchModel_avg
            .View = p_view
        End With

        Try
            ' ■CSV出力
            OutputSList(searchModel_meisai, searchModel_head, searchModel_avg)
        Catch ex As Exception
            Return False
        End Try


        Return True

    End Function

    Friend Sub OutputSList(ByVal p_model_meisai As SearchActionModel,
                                    ByVal p_model_head As SearchActionModel,
                                    ByVal p_model_avg As SearchActionModel)

        ' ■引数チェック---
        If p_model_meisai Is Nothing Then
            Throw New ArgumentNullException("p_model_meisai")
        End If

        If p_model_head Is Nothing Then
            Throw New ArgumentNullException("p_model_head")
        End If

        If p_model_avg Is Nothing Then
            Throw New ArgumentNullException("p_model_avg")
        End If


        ' -----------------
        Dim fileOutputed As Boolean = False

        ' ■CSV出力
        'fileOutputed = OutputCsvFromDB(p_model_meisai.CsvPath, p_model_meisai.SearchResult,
        '                                    p_model_head.SearchResult_1, p_model_avg.SearchResult_avg,
        '                                    SYKListModel._csvOutSYKListColumns_head, SYKListModel._csvHeaderColumns_head,
        '                                    SYKListModel._csvOutSYKListColumns_avg, SYKListModel._csvHeaderColumns_avg,
        '                                    SYKListModel._csvOutSYKListColumns, SYKListModel._csvHeaderColumns)
    End Sub

    Friend Function ShowTextSaveDialog(ByRef p_outputFilePath As String, Optional ByVal p_title As String = Nothing,
                                      Optional ByVal p_fileName As String = Nothing) As DialogResult
        Dim dialog As New SaveFileDialog()

        dialog.Filter = "txt ファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*"
        dialog.Title = p_title
        dialog.FileName = p_fileName
        dialog.InitialDirectory = p_outputFilePath

        Dim result As DialogResult = dialog.ShowDialog()

        p_outputFilePath = dialog.FileName

        Return result
    End Function

#End Region

    Public Function COM_CSV_OUTPUT_SQL(ByVal ps_FormID As String, ByVal ps_Sql As String, Optional ByVal ps_HedNm As String = "", Optional ByVal ps_FilePath As String = "", Optional ByVal po_Form As Form = Nothing) As Boolean
        '==========================================================================
        '   関数:CSV出力
        '   概要:引数のSQLからCSVを直接作成する
        '   注意:項目の区切りを","で判断しているため、複雑なSQL文ではｴﾗｰになる
        '        複雑なSQL文を使用する時は
        '        SELECT 項目 FROM ( SQL文 )
        '        のようにﾒｲﾝのSQLを副問い合わせで包むことで回避可能
        '   IO  引数            値          内容
        '   IN  ps_FormID                   画面ID
        '   IN  ps_Sql                      出力対象CSV
        '   IN  ps_HedNm                    ﾍｯﾀﾞｰ文字列(ｶﾝﾏ区切り)
        '   IN  ps_FilePath                 ﾌｧｲﾙﾊﾟｽ
        '   IN  po_Form                     画面ﾌｫｰﾑ(ﾏｳｽﾎﾟｲﾝﾀｰ用)
        '
        '   戻り値              値          内容
        '                       True        正常終了
        '                       False       異常終了
        '
        '   作成・更新      担当者      変更内容
        '   2007/11/02      SKR)濱口    新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer        'MsgBoxの戻り値
        Dim ls_FileNam As String        '保存ﾌｧｲﾙ名
        Dim ls_InvalidFileChars As Char() = System.IO.Path.GetInvalidFileNameChars()
        'Dim lo_Dynaset As OracleInProcServer.OraDynaset
        Dim lo_Dynaset As PronesDbAccess.OraDynaset
        Dim lt_Item_Cd() As String
        Dim li_Item_Idx As Integer
        Dim li_Item_Max As Integer
        Dim ls_Capital_Sql As String    'SQL(大文字化)
        Dim li_Start_Idx As Integer     '開始位置
        Dim li_Now_Idx As Integer       '現在処理位置
        Dim li_Comma_Idx As Integer     'ｺﾝﾏ位置
        Dim li_From_Idx As Integer      'FROM位置
        Dim li_MaxLen As Integer        'SQL長
        Dim ls_CSV_Data As New System.Text.StringBuilder(String.Empty)
        Dim lo_SaveFile As New SaveFileDialog
        Dim lo_SW As System.IO.StreamWriter
        Dim ls_Item_Sav As String       '項目名一時保存
        Dim li_AS_Idx As Integer        'AS位置

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            COM_CSV_OUTPUT_SQL = False

            '---初期化---'
            ls_FileNam = ""

            '---引数ﾌｧｲﾙﾊﾟｽﾁｪｯｸ---'
            ls_FileNam = ps_FilePath
            'ﾌｧｲﾙﾊﾟｽが無ければ、ここでﾌｧｲﾙﾊﾟｽを聞く
            If Len(Trim(ls_FileNam)) = 0 Then
                '------------------------------
                '保存ﾌｧｲﾙ名取得
                '------------------------------
                'フィルタ設定
                lo_SaveFile.InitialDirectory = "c:\"
                lo_SaveFile.Filter = "csv ファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"
                'ダイアログを表示する
                If lo_SaveFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Exit Function
                End If
                ls_FileNam = lo_SaveFile.FileName
            End If

            If Len(Trim(ls_FileNam)) = 0 Then
                'li_MsgRtn = SetMsg("60067", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "")  '出力対象ファイルを指定してください。
                li_MsgRtn = MsgBox("CSV書込エラー" & Constants.vbCrLf & "出力対象ファイルを指定してください。", MsgBoxStyle.Critical, "エラー")
                Exit Function
            End If

            '砂時計設定
            If po_Form Is Nothing Then
            Else
                po_Form.Cursor = Cursors.WaitCursor
            End If

            '---ﾜｰｸ設定---'
            ls_Capital_Sql = UCase(Trim(ps_Sql))
            li_Start_Idx = 1
            li_Now_Idx = 1
            li_Comma_Idx = 1
            li_From_Idx = 1
            li_MaxLen = Len(ls_Capital_Sql)
            ReDim lt_Item_Cd(0)
            li_Item_Idx = 0

            '------------------------------
            '項目名取得
            '------------------------------
            '---開始位置取得---'
            li_Start_Idx = InStr(1, ls_Capital_Sql, "SELECT")
            If li_Start_Idx = 0 Then
                '---SELECT文が存在せず---'
                Exit Function
            Else
                '---開始位置設定(6はSELECTの文字数)---'
                li_Start_Idx = li_Start_Idx + 6
                ls_Capital_Sql = Mid(ls_Capital_Sql, li_Start_Idx)
                li_Now_Idx = 1

                '---処理開始---'
                Do Until li_Now_Idx > li_MaxLen
                    '---項目IDX取得---'
                    li_Comma_Idx = InStr(li_Now_Idx, ls_Capital_Sql, ",")
                    li_From_Idx = InStr(li_Now_Idx, ls_Capital_Sql, "FROM")

                    If li_Comma_Idx = 0 Or
                        li_Comma_Idx > li_From_Idx Then
                        '---最終項目名取得---'
                        li_Item_Idx = li_Item_Idx + 1
                        ReDim Preserve lt_Item_Cd(li_Item_Idx)
                        'lt_Item_Cd(li_Item_Idx) = Trim(Mid(ls_Capital_Sql, li_Now_Idx, li_From_Idx - 1))
                        ls_Item_Sav = Trim(Mid(ls_Capital_Sql, li_Now_Idx, li_From_Idx - 1))
                        li_AS_Idx = InStr(ls_Item_Sav, " AS ")
                        If li_AS_Idx = 0 Then
                            lt_Item_Cd(li_Item_Idx) = ls_Item_Sav
                        Else
                            lt_Item_Cd(li_Item_Idx) = Trim(Mid(ls_Item_Sav, li_AS_Idx + 4))
                        End If
                        '---ｶﾝﾏ終了又はFROM位置より後ろの場合は処理終了---'
                        li_Now_Idx = li_MaxLen + 1
                    Else
                        '---項目名保存---'
                        li_Item_Idx = li_Item_Idx + 1
                        ReDim Preserve lt_Item_Cd(li_Item_Idx)
                        'lt_Item_Cd(li_Item_Idx) = Trim(Mid(ls_Capital_Sql, li_Now_Idx, li_Comma_Idx - 1))
                        ls_Item_Sav = Trim(Mid(ls_Capital_Sql, li_Now_Idx, li_Comma_Idx - 1))
                        li_AS_Idx = InStr(ls_Item_Sav, " AS ")
                        If li_AS_Idx = 0 Then
                            lt_Item_Cd(li_Item_Idx) = ls_Item_Sav
                        Else
                            lt_Item_Cd(li_Item_Idx) = Trim(Mid(ls_Item_Sav, li_AS_Idx + 4))
                        End If
                    End If
                    ls_Capital_Sql = Mid(ls_Capital_Sql, li_Comma_Idx + 1)
                Loop
            End If

            'ﾀﾞｲﾅｾｯﾄ初期化()
            lo_Dynaset = Nothing

            'SQL実行()
            'lo_Dynaset = OraDatabase.CreateDynaset(ps_Sql, 2)
            Dim dt As DataTable = DB_GetTable(ps_Sql)
            '---0件時はｴﾗｰﾒｯｾｰｼﾞ表示---'
            'If lo_Dynaset.EOF = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                'li_MsgRtn = SetMsg("69019", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "") '処理対象が存在しません。
                li_MsgRtn = MsgBox("CSV書込エラー" & Constants.vbCrLf & "処理対象が存在しません。", MsgBoxStyle.Critical, "エラー")

                Exit Function
            Else
                '---ﾜｰｸの初期化---'
                li_Item_Max = lt_Item_Cd.GetUpperBound(0)

                '---ﾍｯﾀﾞｰ情報設定---'kaori
                If Len(Trim(ps_HedNm)) <> 0 Then
                    ls_CSV_Data.Append("""" & ps_HedNm & """" & Constants.vbCrLf)
                End If

                '読込
                'lo_Dynaset.MoveFirst()
                'Do Until lo_Dynaset.EOF

                '    '---項目件数分処理実施---'
                '    For li_Item_Idx = 1 To li_Item_Max
                '        '---ﾃﾞｰﾀ取得---'
                '        'ls_CSV_Data = ls_CSV_Data & """" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & "")
                '        ls_CSV_Data.Append("""" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & ""))
                '        'ls_CSV_Data.Append("=""" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & ""))
                '        If li_Item_Idx >= li_Item_Max Then
                '            '---最終項目の場合改行---'
                '            'ls_CSV_Data = ls_CSV_Data & """" & Constants.vbCrLf
                '            ls_CSV_Data.Append("""" & Constants.vbCrLf)
                '        Else
                '            'ls_CSV_Data = ls_CSV_Data & ""","
                '            ls_CSV_Data.Append(""",")
                '        End If
                '    Next
                '    lo_Dynaset.MoveNext()
                'Loop

                For i As Integer = 0 To dt.Rows.Count - 1
                    For li_Item_Idx = 1 To li_Item_Max
                        '---ﾃﾞｰﾀ取得---'
                        'ls_CSV_Data = ls_CSV_Data & """" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & "")
                        'ls_CSV_Data.Append("""" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & ""))
                        ls_CSV_Data.Append("""" & CStr(DB_NullReplace(dt.Rows(i)(lt_Item_Cd(li_Item_Idx)), "") & ""))

                        'ls_CSV_Data.Append("=""" & CStr(lo_Dynaset.Fields(lt_Item_Cd(li_Item_Idx)).Value & ""))
                        If li_Item_Idx >= li_Item_Max Then
                            '---最終項目の場合改行---'
                            'ls_CSV_Data = ls_CSV_Data & """" & Constants.vbCrLf
                            ls_CSV_Data.Append("""" & Constants.vbCrLf)
                        Else
                            'ls_CSV_Data = ls_CSV_Data & ""","
                            ls_CSV_Data.Append(""",")
                        End If
                    Next
                Next
                'ｽﾄﾘｰﾑｵｰﾌﾟﾝ
                lo_SW = New System.IO.StreamWriter(ls_FileNam, False, System.Text.Encoding.GetEncoding("shift_jis"))

                Try
                    'CSV書込
                    lo_SW.Write(ls_CSV_Data)
                    'ｽﾄﾘｰﾑｸﾛｰｽﾞ
                    lo_SW.Close()

                Catch ex As Exception
                    'ｽﾄﾘｰﾑｸﾛｰｽﾞ
                    lo_SW.Close()
                    li_MsgRtn = MsgBox("CSV書込エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
                    Exit Function
                End Try

                li_MsgRtn = MsgBox("CSV出力が完了しました。", MsgBoxStyle.Critical, "")


            End If
            lo_Dynaset = Nothing

            '---戻り値設定---'
            COM_CSV_OUTPUT_SQL = True
            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV出力関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally
            '砂時計設定
            If po_Form Is Nothing Then
            Else
                po_Form.Cursor = Cursors.Default
            End If
        End Try

    End Function


    ''' <summary>
    ''' CSV形式のタイトルに変換
    ''' </summary>
    ''' <param name="po_Title">タイトル(ArrayList)</param>
    ''' <returns>Stringタイトル(CSV形式)</returns>
    ''' <remarks></remarks>
    Public Function Make_CsvTitle(ByVal po_Title As ArrayList) As String
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値
        'Dim lb_Ret As Boolean       '関数の戻り値

        Dim la_Title As New ArrayList
        Dim ls_CsvTitle As String = ""
        Dim li_int As Integer

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try

            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            la_Title = po_Title

            If po_Title.Count = 0 Then
                li_MsgRtn = MsgBox("タイトル(Arraylist)が設定されておりません。", MsgBoxStyle.Critical, "エラー")
                Return Nothing
            End If

            'タイトル文字列生成(CSV用)
            For li_int = 0 To po_Title.Count - 1
                If li_int = po_Title.Count - 1 Then
                    '最終objectの場合
                    ls_CsvTitle &= """" & po_Title(li_int) & """"
                Else
                    ls_CsvTitle &= """" & po_Title(li_int) & """" & ","
                End If
            Next

            '戻り値
            Return ls_CsvTitle
            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV出力処理時エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
            Return Nothing
        End Try

    End Function

    Public Function COM_CSV_OUTPUT_LIST(ByVal ps_FormID As String, ByVal pt_CSVCell() As pst_CSVCell, ByVal ps_FilePath As String, ByVal pb_ExistDataCheck As Boolean, ByVal ps_ExistKey As String, ByRef pc_ElTabelle As GrapeCity.Win.MultiRow.GcMultiRow, Optional ByVal ps_HedNm As String = "") As Boolean
        '==========================================================================
        '   関数:CSV出力関数
        '   概要:一覧内に表示されているデータのCSV出力を行う
        '   IO  引数            値          内容
        '   IN ps_FormID                    画面ID
        '   IN pt_CSVCell                   CSV出力対象ｾﾙ配列
        '   IN ps_FilePath                  出力ﾌｧｲﾙﾊﾟｽ
        '   IN pb_ExistDataCheck            ﾃﾞｰﾀ存在ﾁｪｯｸﾌﾗｸﾞ
        '   IN ps_ExistKey                  ﾃﾞｰﾀ有と見なすｾﾙ(このｾﾙにﾃﾞｰﾀが入っていればﾃﾞｰﾀ有とする)
        '   IO pc_ElTabelle                 対象ｴﾙﾀﾌﾞﾚ
        '   IN ps_HedNm                     ﾍｯﾀﾞ文字列【Optional】
        '
        '   戻り値              値          内容
        '                       True        正常終了
        '                       False       異常終了
        '
        '   作成・更新      担当者      変更内容
        '   2007/05/28      SKR)山田    新規作成
        '   2008/01/09      SKR)山田    ﾍｯﾀﾞ名を書き込み出来るように変更
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer            'MsgBoxの戻り値
        Dim lo_SaveFile As New SaveFileDialog
        Dim li_MaxMRow As Integer           '最大ﾏﾙﾁ行
        Dim li_MRowIndex As Integer         'ﾏﾙﾁ行
        Dim li_CSVCellIndex As Integer
        Dim li_MaxCSVCell As Integer
        Dim lt_CSVCell() As pst_CSVCell
        'Dim ls_CSV_Data As String
        Dim ls_CSV_Data As New System.Text.StringBuilder(String.Empty)
        Dim lo_SW As System.IO.StreamWriter
        Dim ls_FilePath As String           '出力ﾌｧｲﾙﾊﾟｽ
        Dim strSQL As String
        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            COM_CSV_OUTPUT_LIST = False

            '最大ﾏﾙﾁ行取得
            'No.766 li_MaxMRow = pc_ElTabelle.MaxMRows
            li_MaxMRow = pc_ElTabelle.RowCount

            If pb_ExistDataCheck = True Then
                '一覧のﾃﾞｰﾀが0件の場合、処理中止
                If li_MaxMRow = 0 Then
                    'li_MsgRtn = SetMsg("69019", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "") '処理対象が存在しません。
                    li_MsgRtn = MsgBox("処理対象が存在しません。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "")
                    Exit Function
                End If
            End If

            '---引数ﾌｧｲﾙﾊﾟｽﾁｪｯｸ---'
            ls_FilePath = ps_FilePath
            'ﾌｧｲﾙﾊﾟｽが無ければ、ここでﾌｧｲﾙﾊﾟｽを聞く
            If Len(Trim(ls_FilePath)) = 0 Then

                'フィルタ設定
                ' === <ST-0038> DEL STR ===
                '*D*lo_SaveFile.InitialDirectory = "V:\"
                ' === <ST-0038> DEL END ===

                lo_SaveFile.Filter = "csv ファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"
                'ダイアログを表示する
                If lo_SaveFile.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                    Exit Function
                End If
                ls_FilePath = lo_SaveFile.FileName
            End If

            '引数取得
            lt_CSVCell = pt_CSVCell

            'CSV出力対象ｾﾙ配列最大値取得
            li_MaxCSVCell = lt_CSVCell.Length

            ' 2008/01/09 SKR)山田 ADD STR ﾍｯﾀﾞ部付加可能機能を追加
            '---ﾍｯﾀﾞｰ情報設定---'
            If Len(Trim(ps_HedNm)) <> 0 Then
                'ls_CSV_Data = """" & ps_HedNm & """" & Constants.vbCrLf
                ls_CSV_Data.Append("""" & ps_HedNm & """" & Constants.vbCrLf)
            End If
            ' 2008/01/09 SKR)山田 ADD END

            'ﾏﾙﾁ行ﾙｰﾌﾟ
            For li_MRowIndex = 0 To li_MaxMRow - 1
                '配列ﾙｰﾌﾟ
                For li_CSVCellIndex = 0 To li_MaxCSVCell - 1

                    'ﾃﾞｰﾀ有とみなすｾﾙのﾁｪｯｸ
                    If Len(Trim(ps_ExistKey)) <> 0 Then
                        'No.772 If Len(Get_El(pc_ElTabelle.MRows(li_MRowIndex).Item(ps_ExistKey))) = 0 Then
                        If Len(Get_El(pc_ElTabelle.Rows(li_MRowIndex).Item(ps_ExistKey))) = 0 Then
                            Exit For
                        End If
                    End If

                    Select Case lt_CSVCell(li_CSVCellIndex).pss_Type
                        Case CGS_TYPE_TEXT
                            'ls_CSV_Data = ls_CSV_Data & """" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Text
                            'No.791 ls_CSV_Data.Append("""" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Text)
                            ls_CSV_Data.Append("""" & pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                        Case CGS_TYPE_COMBO_V
                            'ls_CSV_Data = ls_CSV_Data & """" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value
                            'No.772 ls_CSV_Data.Append("""" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                            ls_CSV_Data.Append("""" & pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                        Case CGS_TYPE_COMBO_T
                            'ls_CSV_Data = ls_CSV_Data & """" & Get_Combo_Desc(pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Editor, pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                            'No.772 ls_CSV_Data.Append("""" & Get_Combo_Desc(pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Editor, pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value))
                            ls_CSV_Data.Append("""" & Get_Combo_Desc(pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key), pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value))
                        Case CGS_TYPE_DATE
                            'ls_CSV_Data = ls_CSV_Data & """" & Get_ElDate_Data(pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key)).Replace("/", "")
                            'No.772 ls_CSV_Data.Append("""" & Get_ElDate_Data(pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key)).Replace("/", ""))
                            ls_CSV_Data.Append("""" & Get_ElDate_Data(pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key)).Replace("/", ""))
                        Case CGS_TYPE_NUMBER
                            'ls_CSV_Data = ls_CSV_Data & """" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value
                            'No.772 s_CSV_Data.Append("""" & pc_ElTabelle.MRows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                            ls_CSV_Data.Append("""" & pc_ElTabelle.Rows(li_MRowIndex).Item(lt_CSVCell(li_CSVCellIndex).pss_Key).Value)
                    End Select

                    '最終ｾﾙ判断
                    Select Case li_CSVCellIndex = li_MaxCSVCell - 1
                        Case True   '最終ｾﾙであった場合、改行
                            'ls_CSV_Data = ls_CSV_Data & """" & Constants.vbCrLf
                            ls_CSV_Data.Append("""" & Constants.vbCrLf)
                        Case False  '最終ｾﾙでなかった場合、ｶﾝﾏ付加
                            'ls_CSV_Data = ls_CSV_Data & ""","
                            ls_CSV_Data.Append(""",")
                    End Select
                Next
            Next

            'ｽﾄﾘｰﾑｵｰﾌﾟﾝ
            lo_SW = New System.IO.StreamWriter(ls_FilePath, False, System.Text.Encoding.GetEncoding("shift_jis"))

            Try
                'CSV書込
                lo_SW.Write(ls_CSV_Data)
                'ｽﾄﾘｰﾑｸﾛｰｽﾞ
                lo_SW.Close()

            Catch ex As Exception
                'ｽﾄﾘｰﾑｸﾛｰｽﾞ
                lo_SW.Close()
                li_MsgRtn = MsgBox("CSV書込エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
                Exit Function
            End Try


            li_MsgRtn = MsgBox("CSV出力が完了しました。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "")

            '---戻り値設定---'
            COM_CSV_OUTPUT_LIST = True

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV出力関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Function

    Public Function Get_El(ByVal po_Cell As GrapeCity.Win.MultiRow.Cell, Optional ByVal ps_Type As String = CGS_MODE_VALUE) As String
        '==========================================================================
        '   関数:取得関数（Eltabelle用）
        '   概要:Eltabelleから値を取得する（ﾃｷｽﾄﾎﾞｯｸｽやｺﾝﾎﾞﾎﾞｯｸｽ等の型によって取得方法が違い、ややこしいので本関数で制御する）
        '
        '   ※下記の関数では本共通関数を使用していないので、本共通関数に変更を加えた場合は下記の関数も要ﾁｪｯｸ
        '       COM_CSV_OUTPUT_LIST
        '       COM_Ctrl_Nece_Check
        '       COM_ElTab_Nece_Check
        '       ClearCtrl
        '
        '   IO  引数            値          内容
        '   IN  po_Cell                     ｾﾙ
        '   IN  ps_Type                     ｺﾝﾎﾞﾎﾞｯｸｽ時ｺｰﾄﾞ、説明のどちらを取得するのか
        '
        '   戻り値              値          内容
        '                                   取得値
        '
        '   作成・更新      担当者      変更内容
        '   2007/11/08      SKR)山田    新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値
        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値設定---'
            Get_El = ""

            '---型判定---'
            'No.743 No.792 If TypeOf po_Cell.Editor Is GrapeCity.Win.ElTabelle.Editors.TextEditor Then
            If TypeOf po_Cell Is GrapeCity.Win.MultiRow.InputMan.GcTextBoxCell Then
                'ﾃｷｽﾄﾎﾞｯｸｽｺﾝﾄﾛｰﾙの場合
                ' 2008/04/04 SKR)山田 MOD STR 改行コード除去
                ' 2008/10/01 SKR)山田 MOD Tabも除去
                'Get_El = Trim(po_Cell.Text)
                'Get_El = Trim(po_Cell.Text.Replace(vbTab, " ").Replace(vbCr, "").Replace(vbLf, ""))
                'No.791 Get_El = Trim(po_Cell.Text.Replace(vbCr, "").Replace(vbLf, ""))
                Get_El = Trim(po_Cell.FormattedValue.Replace(vbCr, "").Replace(vbLf, ""))
                If Len(Get_El) = LenB(Get_El) Then
                    '2byte文字がないなら半角ｽﾍﾟｰｽで置換
                    Get_El = Get_El.Replace(vbTab, " ")
                Else
                    '2byte文字があるなら全角ｽﾍﾟｰｽで置換
                    Get_El = Get_El.Replace(vbTab, "　")
                End If
                ' 2008/04/04 SKR)山田 MOD END
                'No.743 ElseIf TypeOf po_Cell.Editor Is GrapeCity.Win.ElTabelle.Editors.SuperiorComboEditor Then
            ElseIf TypeOf po_Cell Is GrapeCity.Win.MultiRow.InputMan.GcComboBoxCell Then
                'ｺﾝﾎﾞﾎﾞｯｸｽｺﾝﾄﾛｰﾙの場合
                Select Case ps_Type
                    Case CGS_MODE_VALUE
                        Get_El = Trim(CStr(po_Cell.Value & ""))
                    Case CGS_MODE_DESCRIPTION
                        'No.743 Get_El = Trim(Get_Combo_Desc(po_Cell.Editor, po_Cell.Value))
                        Get_El = Trim(Get_Combo_Desc(po_Cell, po_Cell.Value))
                End Select
                'No.734 No.743 ElseIf TypeOf po_Cell.Editor Is GrapeCity.Win.ElTabelle.Editors.DateEditor Then
            ElseIf TypeOf po_Cell Is GrapeCity.Win.MultiRow.DateTimePickerCell Then
                '日付ｺﾝﾄﾛｰﾙの場合
                Get_El = Trim(Get_ElDate_Data(po_Cell))

                'No.743 ElseIf TypeOf po_Cell.Editor Is GrapeCity.Win.ElTabelle.Editors.NumberEditor Then
            ElseIf TypeOf po_Cell Is GrapeCity.Win.MultiRow.InputMan.GcNumberCell Then
                '数値ｺﾝﾄﾛｰﾙの場合
                Get_El = Trim(CStr(po_Cell.Value & ""))
                'No.726 No.743 ElseIf TypeOf po_Cell.Editor Is GrapeCity.Win.ElTabelle.Editors.CheckBoxEditor Then
            ElseIf TypeOf po_Cell Is GrapeCity.Win.MultiRow.CheckBoxCell Then
                'ﾁｪｯｸﾎﾞｯｸｽｺﾝﾄﾛｰﾙの場合
                Get_El = Trim(CStr(po_Cell.Value & ""))

            End If
            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            Get_El = ""
            li_MsgRtn = MsgBox("取得関数（Eltabelle用）エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Function

    Public Function Get_Combo_Desc(ByVal po_SCmbEditor As GrapeCity.Win.MultiRow.InputMan.GcComboBoxCell, ByVal ps_Value As String) As String
        '==========================================================================
        '   関数:コンボボックス説明取得関数
        '   概要:EltabelleコンボボックスのDescription部の取得
        '   IO  引数            値          内容
        '   IN  po_SCmbEditor               対象拡張ｺﾝﾎﾞﾎﾞｯｸｽ
        '   IN  ps_Value                    検索文字列(Value値)
        '
        '   戻り値              値          内容
        '                                   説明文
        '
        '   作成・更新      担当者      変更内容
        '   2007/05/15      SKR)山田    新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBoxの戻り値
        Dim li_FindIndex As Integer
        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---初期化---'
            Get_Combo_Desc = ""
            li_FindIndex = -1

            'SelectedTextｲﾝﾃﾞｯｸｽ検索
            'No.751 No.815 非互換 li_FindIndex = po_SCmbEditor.FindStringExact(ps_Value, GrapeCity.Win.ElTabelle.Editors.TargetMember.ValueMember)
            Dim i As Integer
            For i = 0 To po_SCmbEditor.Items.Count - 1
                If po_SCmbEditor.Items(i).SubItems(1).Value = ps_Value Then
                    li_FindIndex = i
                    Exit For
                End If
            Next

            'Descriptionﾃｷｽﾄ取得
            If li_FindIndex = -1 Then
                Get_Combo_Desc = ""
            Else
                'No.816 Get_Combo_Desc = po_SCmbEditor.Items.Item(li_FindIndex).Description
                Get_Combo_Desc = po_SCmbEditor.Items(li_FindIndex).SubItems(2).Value
            End If

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            Get_Combo_Desc = ""
            li_MsgRtn = MsgBox("コンボボックス説明取得関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Function

    Public Function Get_ElDate_Data(ByVal pc_DateControl As GrapeCity.Win.MultiRow.Cell) As String
        '==========================================================================
        '   関数:日付ﾃﾞｰﾀ取得(ElTabelle用)
        '   概要:
        '   IO  引数            値          内容
        '   IN  pc_DateControl              取得対象ｺﾝﾄﾛｰﾙ
        '
        '   戻り値              値          内容
        '                                   取得した日付
        '
        '   作成・更新      担当者      変更内容
        '   2007/03/14      SKR)濱口    新規作成
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '変数の定義
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer        'MsgBoxの戻り値
        Dim ls_Date As String           '取得した日付

        '--------------------------------------------------------------------------
        'エラートラップ宣言
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '処理開始
            '--------------------------------------------------------------------------
            '---戻り値の設定---'
            Get_ElDate_Data = ""

            '---ﾜｰｸの初期化---'
            ls_Date = ""

            If IsNothing(pc_DateControl.Value) Then
                '---未入力時は処理しない---'
            Else
                If Len(Trim(pc_DateControl.Value.ToString)) = 0 Then
                    '---文字長が0の場合は処理しない---'
                Else
                    ls_Date = Format(pc_DateControl.Value, "yyyy/MM/dd")
                End If
            End If

            '---戻り値の設定---'
            Get_ElDate_Data = ls_Date

            '--------------------------------------------------------------------------
            'エラートラップルーチン
            '--------------------------------------------------------------------------
        Catch ex As Exception
            Get_ElDate_Data = ""
            li_MsgRtn = MsgBox("日付ﾃﾞｰﾀ取得(ElTabelle用)関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Function

End Module
