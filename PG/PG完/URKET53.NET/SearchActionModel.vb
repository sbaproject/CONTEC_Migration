Imports PronesDbAccess

''' <summary>
''' �����A�N�V�����̃��f���ł��B
''' </summary>
''' <remarks></remarks>
''' <history>
''' <detail date="2017/10/19" author="�x�m��)���{" bugNo="">�V�K�쐬</detail>
''' </history>
Friend Class SearchActionModel
    ''' <summary>
    ''' �r���[
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Friend View As Object = Nothing

    ''' <summary>
    ''' CSV�o�̓p�X
    ''' </summary>
    ''' <remarks></remarks>

    Friend CsvPath As String = ""

    ''' <summary>
    ''' ��������(SYKDL52)
    ''' </summary>
    ''' <remarks></remarks>
    Friend SearchResult_1 As OraDynaset = Nothing           '�w�b�_����
    Friend SearchResult_avg As OraDynaset = Nothing         '�w�b�_����(�������O����)
    Friend SearchResult As OraDynaset = Nothing             '���ו���
    Friend SearchResult_sum As OraDynaset = Nothing         '�����Ƃ̍��v


    ''' <summary>
    ''' ��������(SYKDL52_Chart)
    ''' </summary>
    ''' <remarks></remarks>
    Friend SearchChart_1 As OraDynaset = Nothing             '�o�Ɏ��ѐ�
    Friend SearchChart_2 As OraDynaset = Nothing             '�o�ɐ��ڐ�
    Friend SearchChart_3 As OraDynaset = Nothing             '����



    ''' <summary>
    ''' �w�b�_�����ꗗ�\���ő�s��
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_1_MaxRow As Integer = 0

    ''' <summary>
    ''' �w�b�_�����ꗗ�x���s��
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_1_ListWarningRow As Integer = 0

    ''' <summary>
    ''' ���ו����ꗗ�\���ő�s��
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_MaxRow As Integer = 0

    ''' <summary>
    ''' ���ו����ꗗ�x���s��
    ''' </summary>
    ''' <remarks></remarks>
    Friend Dt_SYKList_ListWarningRow As Integer = 0

End Class
