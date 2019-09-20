Imports System
Imports System.Collections
Imports System.Windows.Forms

''' <summary>
''' ListViewの項目の並び替えに使用するクラス
''' </summary>
Public Class ListViewItemComparer
    Implements IComparer

    ''' <summary>
    ''' 比較する方法
    ''' </summary>
    Public Enum ComparerMode
        ''' <summary>
        ''' 文字列として比較
        ''' </summary>
        [String]
        ''' <summary>
        ''' 数値（Int32型）として比較
        ''' </summary>
        [Integer]
        ''' <summary>
        ''' 日時（DataTime型）として比較
        ''' </summary>
        DateTime
    End Enum

    Private _column As Integer
    Private _order As SortOrder
    Private _mode As ComparerMode
    '2019/04/16 DEL START
    'Private _columnModes As ComparerMode()
    '2019/04/16 DEL E N D

    '2019/04/16 ADD START
    Private _sortorder_priority_flg As Boolean = False
    '2019/04/16 ADD E N D

    ''' <summary>
    ''' 指定のソートオーダーを優先するかどうか
    ''' Column指定前に設定する
    ''' </summary>
    Public Property SortOrderPriorityFlg() As Boolean
        Get
            Return _sortorder_priority_flg
        End Get
        Set(ByVal value As Boolean)
            _sortorder_priority_flg = value
        End Set
    End Property

    ''' <summary>
    ''' 並び替えるListView列の番号
    ''' </summary>
    Public Property Column() As Integer
        '現在と同じ列の時は、昇順降順を切り替える
        Get
            Return _column
        End Get
        Set(ByVal value As Integer)
            '2019/04/16 ADD START
            If _sortorder_priority_flg = False Then
                '2019/04/16 ADD E N D
                If _column = value Then
                    If _order = SortOrder.Ascending Then
                        _order = SortOrder.Descending
                    ElseIf _order = SortOrder.Descending Then
                        _order = SortOrder.Ascending
                    End If
                    '2019/04/16 ADD START
                Else
                    _order = SortOrder.Ascending
                    '2019/04/16 ADD E N D
                End If
                '2019/04/16 ADD START
            End If
            '2019/04/16 ADD E N D
            _column = value
            '2019/04/16 ADD START
            _sortorder_priority_flg = False
            '2019/04/16 ADD E N D
        End Set
    End Property

    ''' <summary>
    ''' 昇順か降順か
    ''' </summary>
    Public Property Order() As SortOrder
        Get
            Return _order
        End Get
        Set(ByVal value As SortOrder)
            _order = value
        End Set
    End Property

    ''' <summary>
    ''' 並び替えの方法
    ''' </summary>
    Public Property Mode() As ComparerMode
        Get
            Return _mode
        End Get
        Set(ByVal value As ComparerMode)
            _mode = value
        End Set
    End Property

    '2019/04/16 DEL START
    '''' <summary>
    '''' 列ごとの並び替えの方法
    '''' </summary>
    'Public WriteOnly Property ColumnModes() As ComparerMode()
    '    Set(ByVal value As ComparerMode())
    '        _columnModes = value
    '    End Set
    'End Property
    '2019/04/16 DEL E N D

    ''' <summary>
    ''' ListViewItemComparerクラスのコンストラクタ
    ''' </summary>
    ''' <param name="col">並び替える列の番号</param>
    ''' <param name="ord">昇順か降順か</param>
    ''' <param name="cmod">並び替えの方法</param>
    Public Sub New(ByVal col As Integer, ByVal ord As SortOrder, ByVal cmod As ComparerMode)
        _column = col
        _order = ord
        _mode = cmod
    End Sub

    Public Sub New()
        _column = 0
        _order = SortOrder.Ascending
        _mode = ComparerMode.[String]
    End Sub

    'xがyより小さいときはマイナスの数、大きいときはプラスの数、
    '同じときは0を返す
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements IComparer.Compare

        If _order = SortOrder.None Then
            '並び替えない時
            Return 0
        End If

        Dim result As Integer = 0
        'ListViewItemの取得
        Dim itemx As ListViewItem = DirectCast(x, ListViewItem)
        Dim itemy As ListViewItem = DirectCast(y, ListViewItem)

        '並べ替えの方法を決定
        '2019/04/16 CHG START
        'If Not (_columnModes Is Nothing) AndAlso _
        '        _columnModes.Length > _column Then
        '    _mode = _columnModes(_column)
        'End If
        _mode = _mode
        '2019/04/16 CHG E N D

        '並び替えの方法別に、xとyを比較する
        Select Case _mode
            Case ComparerMode.[String]
                '文字列として比較
                result = String.Compare( _
                    itemx.SubItems(_column).Text, _
                    itemy.SubItems(_column).Text)
                Exit Select
            Case ComparerMode.[Integer]
                'Int32に変換して比較
                '.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                result = _
                    Integer.Parse(itemx.SubItems(_column).Text).CompareTo( _
                    Integer.Parse(itemy.SubItems(_column).Text))
                Exit Select
            Case ComparerMode.DateTime
                'DateTimeに変換して比較
                '.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                result = DateTime.Compare( _
                    DateTime.Parse(itemx.SubItems(_column).Text), _
                    DateTime.Parse(itemy.SubItems(_column).Text))
                Exit Select
        End Select

        '降順の時は結果を+-逆にする
        If _order = SortOrder.Descending Then
            result = -result
        End If

        '結果を返す
        Return result
    End Function

End Class
