Imports System
Imports System.Collections
Imports System.Windows.Forms

''' <summary>
''' ListView�̍��ڂ̕��ёւ��Ɏg�p����N���X
''' </summary>
Public Class ListViewItemComparer
    Implements IComparer

    ''' <summary>
    ''' ��r������@
    ''' </summary>
    Public Enum ComparerMode
        ''' <summary>
        ''' ������Ƃ��Ĕ�r
        ''' </summary>
        [String]
        ''' <summary>
        ''' ���l�iInt32�^�j�Ƃ��Ĕ�r
        ''' </summary>
        [Integer]
        ''' <summary>
        ''' �����iDataTime�^�j�Ƃ��Ĕ�r
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
    ''' �w��̃\�[�g�I�[�_�[��D�悷�邩�ǂ���
    ''' Column�w��O�ɐݒ肷��
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
    ''' ���ёւ���ListView��̔ԍ�
    ''' </summary>
    Public Property Column() As Integer
        '���݂Ɠ�����̎��́A�����~����؂�ւ���
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
    ''' �������~����
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
    ''' ���ёւ��̕��@
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
    '''' �񂲂Ƃ̕��ёւ��̕��@
    '''' </summary>
    'Public WriteOnly Property ColumnModes() As ComparerMode()
    '    Set(ByVal value As ComparerMode())
    '        _columnModes = value
    '    End Set
    'End Property
    '2019/04/16 DEL E N D

    ''' <summary>
    ''' ListViewItemComparer�N���X�̃R���X�g���N�^
    ''' </summary>
    ''' <param name="col">���ёւ����̔ԍ�</param>
    ''' <param name="ord">�������~����</param>
    ''' <param name="cmod">���ёւ��̕��@</param>
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

    'x��y��菬�����Ƃ��̓}�C�i�X�̐��A�傫���Ƃ��̓v���X�̐��A
    '�����Ƃ���0��Ԃ�
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements IComparer.Compare

        If _order = SortOrder.None Then
            '���ёւ��Ȃ���
            Return 0
        End If

        Dim result As Integer = 0
        'ListViewItem�̎擾
        Dim itemx As ListViewItem = DirectCast(x, ListViewItem)
        Dim itemy As ListViewItem = DirectCast(y, ListViewItem)

        '���בւ��̕��@������
        '2019/04/16 CHG START
        'If Not (_columnModes Is Nothing) AndAlso _
        '        _columnModes.Length > _column Then
        '    _mode = _columnModes(_column)
        'End If
        _mode = _mode
        '2019/04/16 CHG E N D

        '���ёւ��̕��@�ʂɁAx��y���r����
        Select Case _mode
            Case ComparerMode.[String]
                '������Ƃ��Ĕ�r
                result = String.Compare( _
                    itemx.SubItems(_column).Text, _
                    itemy.SubItems(_column).Text)
                Exit Select
            Case ComparerMode.[Integer]
                'Int32�ɕϊ����Ĕ�r
                '.NET Framework 2.0����́ATryParse���\�b�h���g�����Ƃ��ł���
                result = _
                    Integer.Parse(itemx.SubItems(_column).Text).CompareTo( _
                    Integer.Parse(itemy.SubItems(_column).Text))
                Exit Select
            Case ComparerMode.DateTime
                'DateTime�ɕϊ����Ĕ�r
                '.NET Framework 2.0����́ATryParse���\�b�h���g�����Ƃ��ł���
                result = DateTime.Compare( _
                    DateTime.Parse(itemx.SubItems(_column).Text), _
                    DateTime.Parse(itemy.SubItems(_column).Text))
                Exit Select
        End Select

        '�~���̎��͌��ʂ�+-�t�ɂ���
        If _order = SortOrder.Descending Then
            result = -result
        End If

        '���ʂ�Ԃ�
        Return result
    End Function

End Class
