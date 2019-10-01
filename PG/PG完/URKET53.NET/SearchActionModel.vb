Imports PronesDbAccess

''' <summary>
''' 検索アクションのモデルです。
''' </summary>
''' <remarks></remarks>
''' <history>
''' <detail date="2017/10/19" author="富士通)橋本" bugNo="">新規作成</detail>
''' </history>
Friend Class SearchActionModel
    ''' <summary>
    ''' ビュー
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Friend View As Object = Nothing

    ''' <summary>
    ''' CSV出力パス
    ''' </summary>
    ''' <remarks></remarks>

    Friend CsvPath As String = ""

    ''' <summary>
    ''' 検索結果(SYKDL52)
    ''' </summary>
    ''' <remarks></remarks>
    Friend SearchResult_1 As OraDynaset = Nothing           'ヘッダ部分
    Friend SearchResult_avg As OraDynaset = Nothing         'ヘッダ部分(当月除外平均)
    Friend SearchResult As OraDynaset = Nothing             '明細部分
    Friend SearchResult_sum As OraDynaset = Nothing         '期ごとの合計


    ''' <summary>
    ''' 検索結果(SYKDL52_Chart)
    ''' </summary>
    ''' <remarks></remarks>
    Friend SearchChart_1 As OraDynaset = Nothing             '出庫実績数
    Friend SearchChart_2 As OraDynaset = Nothing             '出庫推移数
    Friend SearchChart_3 As OraDynaset = Nothing             '平均



    ''' <summary>
    ''' ヘッダ部分一覧表示最大行数
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_1_MaxRow As Integer = 0

    ''' <summary>
    ''' ヘッダ部分一覧警告行数
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_1_ListWarningRow As Integer = 0

    ''' <summary>
    ''' 明細部分一覧表示最大行数
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_MaxRow As Integer = 0

    ''' <summary>
    ''' 明細部分一覧警告行数
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_ListWarningRow As Integer = 0

End Class
