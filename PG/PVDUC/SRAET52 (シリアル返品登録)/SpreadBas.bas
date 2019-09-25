Attribute VB_Name = "SpreadBas"
Option Explicit

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�̔C�ӂ̃J�����ɃJ�[�\�����ړ�������B
'�y�� �� ���z GP_SpActiveCell
'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
'             ByVal lngCol As Long�F��
'             ByVal lngRow As Long�F�s
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'===========================================================================

Public Sub GP_SpActiveCell(ByRef objSpread As Object, _
                        ByVal lngCol As Long, _
                        ByVal lngRow As Long)
    With objSpread
        .SetFocus
        .Col = lngCol
        .Row = lngRow
        .Action = ActionActiveCell
        .EditMode = True
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�̒P��I�����[�h�̐ݒ�B
'�y�� �� ���z GP_SpSingleMode
'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'===========================================================================

Public Sub GP_SpSingleMode(ByRef objSpread As Object)
    
    With objSpread
        .ReDraw = False
        '�X�v���b�h�̃N���A
        .Action = ActionClearText
        '�\���s=0
        .MaxRows = 0
        '���͕s�B�I���̂݁B
        .OperationMode = OperationModeSingle
        '�I���Z���̃Z���F�B
        .SelBackColor = &HFF8080
        '�����s�y�ъ�s�̔w�i�F�B
        Call .SetOddEvenRowColor(vbWhite, vbBlack, &H8000000F, vbBlack)
        .ReDraw = True
    End With

End Sub



