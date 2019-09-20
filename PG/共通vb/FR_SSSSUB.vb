Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSSUB
	Inherits System.Windows.Forms.Form
	
	Dim blnUsableEvent As Boolean '����Ă����s���邩�ǂ������׸�(�ėp)
	Dim intChkKb As Short '�`�F�b�N�敪(1:�`�F�b�N
	'             2:�`�F�b�N(�O�񂩂�ύX���̂�)
	'             3:�`�F�b�N(�t�H�[�J�X�͈ړ����Ȃ�)
	
	Dim strHDkouza As String '�w�b�_�̊�������̒l���i�[
	Dim CurrentLine As Short '�t�H�[�J�X�̂���s�ԍ����Z�b�g(�w�b�_�̎���-1�j
	
	'// V3.01�� ADD
	Dim intEventUkai As Short '����Ă��I�񂷂邩�ǂ������׸�(�ėp)
	'// V3.01�� ADD
	
	'�t�H�[�����[�h��
	Private Sub FR_SSSSUB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		'������
		initForm()
        '���ڏ�����
        initItem()

        '2019/04/26 ADD START
        Call UNYMTA_GetFirst()
        SetBar(Me)
        '2019/04/26 ADD E N D

    End Sub
	
	'�t�H�[���A�����[�h��
	Private Sub FR_SSSSUB_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'���I���m�F��MSG
		If chkLineNull(0) = True Then
			If chkLineNull(1) = True Then
				If chkLineNull(2) = True Then
					If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
                        Cancel = MsgBoxResult.Cancel
                        '20190508 ADD START
                        eventArgs.Cancel = Cancel
                        '20190508 ADD END
                        Exit Sub
					Else
                        '20190508 DEL START
                        'Me.Close() '��PG�I��
                        '20190508 DEL END
                        Exit Sub
					End If
				End If
			End If
		End If
		
		If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
			Cancel = MsgBoxResult.Cancel
			Exit Sub
		End If
		
		Me.Close() '��PG�I��
		eventArgs.Cancel = Cancel
	End Sub
	
	
	
	
	Private Sub initForm()
		Dim ssBevelNone As Object
        '���ЂƂ܂��s�ǉ��͕ۗ�
        '2019/04/26 CHG START
        'mnu_gyoin.Visible = False
        'img_gyoin.Visible = False
        Button7.Visible = False
        '2019/04/26 CHG EN D

        '�^�p���̕\��
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_unydt.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_unydt.Text = CNV_DATE(gstrUnydt.Value)

        '�������̕\��
        txt_nyudt.Text = CNV_DATE(gstrKesidt.Value)
		
		'������̕\��
		txt_tokseicd.Text = DB_TOKMTA.TOKSEICD
		txt_tokseinma.Text = DB_TOKMTA.TOKNMA
		
		'���͒S���҂̕\��
		txt_opeid.Text = FR_SSSMAIN.txt_opeid.Text
		txt_openm.Text = FR_SSSMAIN.txt_openm.Text

        '�\������e�L�X�g�{�b�N�X�ݒ�p�p�l�����B��
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_hihyoji.Text = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'pnl_hihyoji.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D
    End Sub
	
	'���ڂ̏�����
	Private Sub initItem()
		txt_HDkouza.Text = "          " '10byte space
		txt_HDkouza.ForeColor = System.Drawing.Color.Black
		txt_HDkouza.BackColor = System.Drawing.Color.White
		strHDkouza = ""
		
		blnUsableEvent = True
		intChkKb = 2
		
		initBody()
	End Sub
	
	'���ו��̍폜
	Private Sub initBody()
		Dim i As Short
		For i = 0 To 2
			initLine((i))
		Next i
	End Sub
	
	'�s�̏�����
	Private Sub initLine(ByRef intRow As Short)
		txt_BDdkbid(intRow).Text = "  " '2byte space
		txt_BDdkbnm(intRow).Text = ""
		txt_BDkouza(intRow).Text = "          " '10byte space
		txt_BDnyukn(intRow).Text = ""
		txt_BDlincma(intRow).Text = "                    " '20byte space
		
		txt_BDdkbid(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDdkbid(intRow).BackColor = System.Drawing.Color.White
		txt_BDkouza(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDkouza(intRow).BackColor = System.Drawing.Color.White
		txt_BDnyukn(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDnyukn(intRow).BackColor = System.Drawing.Color.White
		txt_BDlincma(intRow).ForeColor = System.Drawing.Color.Black
		txt_BDlincma(intRow).BackColor = System.Drawing.Color.White
		
		Call initSubFormType(intRow)
	End Sub
	
	Private Function chkHDkouza() As Boolean
		chkHDkouza = False
		
		'�`�F�b�N�敪��1,3�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
		If intChkKb = 1 Or txt_HDkouza.Text <> strHDkouza Or intChkKb = 3 Then
			
			'�󔒓��͎��̓`�F�b�N���Ȃ�
			If Trim(txt_HDkouza.Text) = "" Then Exit Function
			
			'������Ͻ����犨��������̂��擾
			Select Case GET_MEIMTA_KANKOZ(txt_HDkouza.Text)
				'���݂���Ƃ�
				Case 0
					txt_HDkouza.ForeColor = System.Drawing.Color.Black
					chkHDkouza = True
					
					'// V2.00�� ADD
					'���݂��邪�A�폜���R�[�h�̏ꍇ
				Case 8
					'�`�F�b�N�敪��3�łȂ��Ƃ��A���b�Z�[�W��\��
					If intChkKb <> 3 Then
						Call showMsg("2", "URKET53_039", "0") '���폜�ς݃��R�[�h�ł�
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
					End If
					'// V2.00�� ADD
					
					'���݂��Ȃ���
				Case 9
					'�`�F�b�N�敪��3�łȂ��Ƃ��A���b�Z�[�W��\��
					If intChkKb <> 3 Then
						Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
					End If
			End Select
		End If
		strHDkouza = txt_HDkouza.Text
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	'���ו���������̓��̓`�F�b�N
	Private Function chkBDkouza(ByRef Index As Short) As Boolean
		chkBDkouza = False
		
		'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s���B
		'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(Index).SUB_KOUZA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If intChkKb = 1 Or txt_BDkouza(Index).Text <> gtypeFR_SUB(Index).SUB_KOUZA Then
			
			'�󔒓��͎��̓`�F�b�N���Ȃ�
			If Trim(txt_BDkouza(Index).Text) <> "" Then
				
				'������Ͻ����犨��������̂��擾
				Select Case GET_MEIMTA_KANKOZ(txt_BDkouza(Index).Text)
					'���݂���Ƃ�
					Case 0
						txt_BDkouza(Index).ForeColor = System.Drawing.Color.Black
						chkBDkouza = True
						
						'// V2.00�� ADD
						'���݂��邪�A�폜���R�[�h�̏ꍇ
					Case 8
						Call showMsg("2", "URKET53_039", "0") '���폜�ς݃��R�[�h�ł�
						txt_HDkouza.ForeColor = System.Drawing.Color.Red
						txt_HDkouza.Focus()
						'// V2.00�� ADD
						
						'���݂��Ȃ���
					Case 9
						Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
						txt_BDkouza(Index).ForeColor = System.Drawing.Color.Red
						txt_BDkouza(Index).Focus()
				End Select
			End If
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(Index).SUB_KOUZA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gtypeFR_SUB(Index).SUB_KOUZA = txt_BDkouza(Index).Text
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	'������ʂ̓��̓`�F�b�N
	Private Function chkBDdkbid(ByRef Index As Short) As Boolean
		Dim tmp As String
		
		chkBDdkbid = False
		
		'�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
		'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If intChkKb = 1 Or Trim(txt_BDdkbid(Index).Text) <> Trim(gtypeFR_SUB(Index).SUB_DKBID) Then
			txt_BDdkbnm(Index).Text = ""
			
			'�󔒓��͎��̓`�F�b�N���Ȃ�
			If Trim(txt_BDdkbid(Index).Text) <> "" Then
				
				'���͒l��2byte�Ŗ�������0����
				blnUsableEvent = False
				txt_BDdkbid(Index).Text = VB6.Format(txt_BDdkbid(Index).Text, "00")
				blnUsableEvent = True
				
				'��SYSTBD���������ʖ��̂��擾
				tmp = getDkbnm(txt_BDdkbid(Index).Text, Index)
				If tmp <> "" Then
					'���݂���Ƃ�
					txt_BDdkbid(Index).ForeColor = System.Drawing.Color.Black
					txt_BDdkbnm(Index).Text = tmp
					'�w�b�_�Ɋ���������w�肳��Ă��āA�����ׂɊ�����������͂���Ă��Ȃ���΃R�s�[
					intChkKb = 3 '�`�F�b�N�̂�
					If txt_HDkouza.Text <> "" And chkHDkouza = True Then
						blnUsableEvent = False
						'// V2.13�� UPD
						'                    txt_BDkouza(Index).Text = txt_HDkouza.Text
						If Trim(txt_BDkouza(Index).Text) = "" Then
							txt_BDkouza(Index).Text = txt_HDkouza.Text
						End If
						'// V2.13�� UPD
						blnUsableEvent = True
					End If
					chkBDdkbid = True
					
					'���݂��Ȃ���
				Else
					Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
					txt_BDdkbid(Index).ForeColor = System.Drawing.Color.Red
					txt_BDdkbid(Index).Focus()
				End If
				
				'�󔒂̂Ƃ��A�o�^���������s����
			Else
                'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB().SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gtypeFR_SUB(Index).SUB_DKBID = ""
                '2019/04/26 CHG START
                'mnu_regist_Click(mnu_regist, New System.EventArgs())
                mnu_regist_Click(Button1, New System.EventArgs())
                '2019/04/26 CHG E N D
            End If
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(Index).SUB_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gtypeFR_SUB(Index).SUB_DKBID = txt_BDdkbid(Index).Text
		intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
	End Function
	
	'�s�P�ʂɓ��̓`�F�b�N���s��
	'intPattern��0�̎��͕K���`�F�b�N
	Private Function chkLine(ByRef intRow As Short, Optional ByRef intPattern As Short = 1) As Boolean
		chkLine = False
		
		CurrentLine = intRow
		'�s�ɂ����ꂩ�ɍ��ڂ����͂���Ă�����A�ʂ̕K�{���ڂ̓��̓`�F�b�N���s��
		If Trim(txt_BDdkbid(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDlincma(intRow).Text) <> "" Or intPattern = 0 Then
			
			If Trim(txt_BDdkbid(intRow).Text) = "" Then
				showMsg("0", "_COMPLETEC", "0") '���K�{���ږ����͂�MSG
				txt_BDdkbid(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDdkbid(intRow).Focus()
				Exit Function
			Else
				intChkKb = 1
				If chkBDdkbid(intRow) = False Then
					Exit Function
				End If
			End If
			
			If Trim(txt_BDkouza(intRow).Text) = "" Then
				txt_BDkouza(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDkouza(intRow).Focus()
				showMsg("0", "_COMPLETEC", "0")
				Exit Function
			Else
				intChkKb = 1
				If chkBDkouza(intRow) = False Then
					Exit Function
				End If
			End If
			
			If Trim(txt_BDnyukn(intRow).Text) = "" Then
				showMsg("0", "_COMPLETEC", "0")
				txt_BDnyukn(intRow).ForeColor = System.Drawing.Color.Red
				txt_BDnyukn(intRow).Focus()
				Exit Function
			End If
		End If
		
		chkLine = True
	End Function
	
	'�s��NULL���ǂ������m�F
	Private Function chkLineNull(ByRef intRow As Short) As Boolean
		chkLineNull = False
		
		If Trim(txt_BDdkbid(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDkouza(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDnyukn(intRow).Text) <> "" Then Exit Function
		If Trim(txt_BDlincma(intRow).Text) <> "" Then Exit Function
		
		chkLineNull = True
	End Function


    '2019/04/26 DEL START
    ''�I���{�^���N���b�N��
    'Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_exit_Click(mnu_exit, New System.EventArgs())
    'End Sub
    ''�I���}�E�X�_�E����
    'Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(1).Image
    'End Sub
    ''�I���}�E�X���[�u��
    'Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "���j���[�ɖ߂�܂��B"
    'End Sub
    ''�I���}�E�X�A�b�v��
    'Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(0).Image
    'End Sub

    ''�s�폜�{�^���N���b�N��
    'Private Sub img_gyodel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    If mnu_gyodel.Enabled = False Then Exit Sub
    '    mnu_gyodel_Click(mnu_gyodel, New System.EventArgs())
    'End Sub
    ''�s�폜�}�E�X�_�E����
    'Private Sub img_gyodel_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_gyodel.Image = img_bkgyodel(1).Image
    'End Sub
    ''�s�폜�}�E�X���[�u��
    'Private Sub img_gyodel_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "���ׂ���s�폜���܂��B"
    'End Sub
    ''�s�폜�}�E�X�A�b�v��
    'Private Sub img_gyodel_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_gyodel.Image = img_bkgyodel(0).Image
    'End Sub
    ''�s�}���{�^���N���b�N��
    'Private Sub img_gyoin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    If mnu_gyoin.Enabled = False Then Exit Sub
    '    mnu_gyoin_Click(mnu_gyoin, New System.EventArgs())
    'End Sub
    ''�s�}���}�E�X�_�E����
    'Private Sub img_gyoin_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_gyoin.Image = img_bkgyoin(1).Image
    'End Sub
    ''�s�}���}�E�X���[�u��
    'Private Sub img_gyoin_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "���׍s��}�����܂��B"
    'End Sub
    ''�s�}���}�E�X�A�b�v��
    'Private Sub img_gyoin_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_gyoin.Image = img_bkgyoin(0).Image
    'End Sub
    ''�o�^�{�^���N���b�N��
    'Private Sub img_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_regist_Click(mnu_regist, New System.EventArgs())
    'End Sub
    ''�o�^�}�E�X�_�E����
    'Private Sub img_regist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_regist.Image = img_bkregist(1).Image
    'End Sub
    ''�o�^�}�E�X���[�u��
    'Private Sub img_regist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "�o�^���܂��B"
    'End Sub
    ''�o�^�}�E�X�A�b�v��
    'Private Sub img_regist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_regist.Image = img_bkregist(0).Image
    'End Sub

    ''�����{�^���N���b�N��
    'Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
    'End Sub
    ''�����}�E�X�_�E����
    'Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(1).Image
    'End Sub
    ''�����}�E�X���[�u��
    'Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "�E�B���h�E��\�����܂��B"
    'End Sub
    ''�����}�E�X�A�b�v��
    'Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(0).Image
    'End Sub

    ''���׍s���������j���[�N���b�N��
    'Public Sub mnu_bdinitdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    '�s�̏������s��
    '    initLine(CurrentLine)
    '    txt_BDdkbid(CurrentLine).Focus()
    '    txt_BDdkbid(CurrentLine).BackColor = System.Drawing.Color.Yellow
    'End Sub
    '2019/04/26 DEL E N D
    '�I�����j���[�N���b�N��
    Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
    End Sub

    '�s�폜���j���[�N���b�N��
    Public Sub mnu_gyodel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim i As Short

        '�s�̏������s��
        initLine(CurrentLine)
        '���i�̍s�����ݍs�Ɉړ�
        If CurrentLine < 2 Then
            For i = CurrentLine To 1 - CurrentLine
                '���i�̍s���󔒂łȂ�������A��i�ɃR�s�[
                If chkLineNull(i + 1) = False Then
                    blnUsableEvent = False

                    txt_BDdkbid(i).Text = txt_BDdkbid(i + 1).Text
                    txt_BDdkbnm(i).Text = txt_BDdkbnm(i + 1).Text
                    txt_BDkouza(i).Text = txt_BDkouza(i + 1).Text
                    txt_BDnyukn(i).Text = txt_BDnyukn(i + 1).Text
                    txt_BDlincma(i).Text = txt_BDlincma(i + 1).Text
                    Call moveSubFormType(i) '�\���̂̒l���R�s�[
                    initLine(i + 1) '���i�̏����폜

                    blnUsableEvent = True
                End If
            Next i
        End If
        txt_BDdkbid(CurrentLine).Focus()
        txt_BDdkbid(CurrentLine).BackColor = System.Drawing.Color.Yellow
    End Sub

    '�s�ǉ����j���[�N���b�N��
    Public Sub mnu_gyoin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '
    End Sub

    '��ʏ��������j���[�N���b�N��
    Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '������
        initItem()
        '�w�b�_����������Ƀt�H�[�J�X���ړ�
        CurrentLine = -1 '�w�b�_������-1���Z�b�g
        txt_HDkouza.Focus()
        txt_HDkouza.BackColor = System.Drawing.Color.Yellow
    End Sub

    '�o�^���j���[�N���b�N��
    Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim p As Short
        Dim i As Short

        '// V3.01�� UPD
        '    p = CurrentLine
        '    If chkLine(0, 0) = False Then Exit Sub  '1�s�ڂ͕K�{����
        '    If chkLine(1) = False Then Exit Sub
        '    If chkLine(2) = False Then Exit Sub
        '    CurrentLine = p

        intEventUkai = 1
        p = CurrentLine
        If chkLine(0, 0) = False Then
            intEventUkai = 0
            Exit Sub '1�s�ڂ͕K�{����
        End If
        If chkLine(1) = False Then
            intEventUkai = 0
            Exit Sub
        End If
        If chkLine(2) = False Then
            intEventUkai = 0
            Exit Sub
        End If
        CurrentLine = p
        intEventUkai = 0
        '// V3.01�� UPD


        '���o�^�m�F��MSG
        If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
            '�������̔��f
            If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
                showMsg("2", "UPDAUTH", "0")
            Else
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                If F_UPDATE_SUB() = 1 Then
                    '2019/04/26 CHG START
                    'mnu_initdsp_Click(mnu_initdsp, New System.EventArgs()) '��ʕ\���̏�����
                    mnu_initdsp_Click(Button9, New System.EventArgs()) '��ʕ\���̏�����
                    '2019/04/26 CHG E N D
                Else
                    '���X�V�������s��
                    MsgBox("�X�V�Ɏ��s���܂����B", MsgBoxStyle.Critical, "�X�V�G���[")
                End If
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If
        Else
            If CurrentLine <> -1 Then
                txt_BDdkbid(CurrentLine).Focus()
            End If
        End If
    End Sub

    '�������j���[�N���b�N��
    Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '�w�b�_����������Ƀt�H�[�J�X������Ƃ�
        'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        If Me.ActiveControl.Name = txt_HDkouza.Name Then
            blnUsableEvent = False
            cmd_HDkouza_Click()
            blnUsableEvent = True

            '���ו��Ƀt�H�[�J�X������Ƃ�
        ElseIf CurrentLine >= 0 Then
            '������ʂ̂Ƃ�
            'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            If Me.ActiveControl.Name = txt_BDdkbid(CurrentLine).Name Then
                blnUsableEvent = False
                cmd_BDdkbid_Click()
                blnUsableEvent = True

                '��������̂Ƃ�
                'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            ElseIf Me.ActiveControl.Name = txt_BDkouza(CurrentLine).Name Then
                blnUsableEvent = False
                cmd_BDkouza_Click()
                blnUsableEvent = True
            End If
        End If
    End Sub

    '�w�b�_�p�l���}�E�X���[�u��
    Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'�q���g�̕\��������������
		img_light.Image = img_bklight(0).Image
		txt_message.Text = ""
	End Sub
	
	
	
	
	
	
	'=======================================================�������(����)�K�{����=======================================================
	
	
	'UPGRADE_WARNING: �C�x���g txt_BDdkbid.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_BDdkbid_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.TextChanged
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		Dim p As Short
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		'�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
		If txt_BDdkbid(Index).SelectionStart = 2 Then
			intChkKb = 1 '��������ʂ̓��̓`�F�b�N
			txt_BDkouza(Index).Focus() '���ו�����������ڂֈړ�
		End If
		
	End Sub
	
	Private Sub txt_BDdkbid_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.Enter
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		'�S�I����Ԃɂ���
		txt_BDdkbid(Index).SelectionStart = 0
		txt_BDdkbid(Index).SelectionLength = 2
		'�w�i�F�����F�ɂ���
		txt_BDdkbid(Index).BackColor = System.Drawing.Color.Yellow
        '2019/04/26 DEL START
        ''���׍s�R�}���h�����s�Ƃ���
        'mnu_bdinitdsp.Enabled = True
        'mnu_gyoin.Enabled = True
        'mnu_gyodel.Enabled = True
        ''�������������s�\�Ƃ���
        'mnu_showwnd.Enabled = True
        '2019/04/26 DEL E N D
        '���ݍs�ԍ���ۑ�
        CurrentLine = Index
	End Sub
	
	Private Sub txt_BDdkbid_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDdkbid.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		
		'�E��󉟉���
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDdkbid(Index).SelectionStart < (2 - 1) Then
				txt_BDdkbid(Index).SelectionStart = txt_BDdkbid(Index).SelectionStart + 1
				
				'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
			Else
				intChkKb = 2 '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
				txt_BDkouza(Index).Focus() '���ו�����������ڂֈړ�
			End If
			txt_BDdkbid(Index).SelectionLength = 1
			
			'Backspace or ����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDdkbid(Index).SelectionStart > 0 Then
				txt_BDdkbid(Index).SelectionStart = txt_BDdkbid(Index).SelectionStart - 1
				
				'�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
			Else
				'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
				If Trim(txt_BDdkbid(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				
				intChkKb = 2 '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
				If Index = 0 Then
					txt_HDkouza.Focus() '�w�b�_������������ڂֈړ�
				Else
					txt_BDlincma(Index - 1).Focus() '���l���ڂֈړ�
				End If
			End If
			txt_BDdkbid(Index).SelectionLength = 1
			
			'���󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 2 '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
			If Index = 0 Then
				txt_HDkouza.Focus() '�w�b�_������������ڂֈړ�
			Else
				txt_BDdkbid(Index - 1).Focus() '���l���ڂֈړ�
			End If
			
			'����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 2 '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
			If Index < 2 Then
				txt_BDdkbid(Index + 1).Focus() '���ו�����������ڂֈړ�
			End If
			
			'Enter������
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '��������ʂ̓��̓`�F�b�N
			txt_BDkouza(Index).Focus() '���ו�����������ڂֈړ�
			
			'Delete������
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDdkbid_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDdkbid.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		If KeyAscii = System.Windows.Forms.Keys.Back Then GoTo EventExitSub
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDdkbid_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDdkbid.Leave
		Dim Index As Short = txt_BDdkbid.GetIndex(eventSender)
		'������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		'���̓`�F�b�N
		chkBDdkbid(Index)
		'�w�i�F�𔒂ɖ߂�
		txt_BDdkbid(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================�������(����)�K�{����=======================================================
	
	
	'UPGRADE_WARNING: �C�x���g txt_BDkouza.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_BDkouza_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.TextChanged
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		Dim p As Short
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_BDkouza(Index).SelectionStart
		
		'�S�p���폜����
		txt_BDkouza(Index).Text = delZenkaku(txt_BDkouza(Index).Text)
		'���͒l��10byte�Ŗ������͋󔒖���
		txt_BDkouza(Index).Text = txt_BDkouza(Index).Text & Space(10 - Len(txt_BDkouza(Index).Text))
		
		txt_BDkouza(Index).SelectionStart = p
		blnUsableEvent = True
		
		'�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
		If txt_BDkouza(Index).SelectionStart = 10 Then
			intChkKb = 1 '������������ނ̓��̓`�F�b�N
			txt_BDnyukn(Index).Focus() '�����z���ڂֈړ�
		End If
		txt_BDkouza(Index).SelectionLength = 1
	End Sub
	
	Private Sub txt_BDkouza_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.Enter
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'�擪�ʒu��I����Ԃɂ���
		txt_BDkouza(Index).SelectionStart = 0
		txt_BDkouza(Index).SelectionLength = 1
        '�w�i�F�����F�ɂ���
        txt_BDkouza(Index).BackColor = System.Drawing.Color.Yellow
        '2019/04/26 DEL START
        ''���׍s�R�}���h�����s�Ƃ���
        'mnu_bdinitdsp.Enabled = True
        'mnu_gyoin.Enabled = True
        'mnu_gyodel.Enabled = True
        ''�������������s�\�Ƃ���
        'mnu_showwnd.Enabled = True
        '2019/04/26 DEL E N D
        '���ݍs�ԍ���ۑ�
        CurrentLine = Index
	End Sub
	
	Private Sub txt_BDkouza_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDkouza.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		
		'�E��󉟉���
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDkouza(Index).SelectionStart < (10 - 1) Then
				txt_BDkouza(Index).SelectionStart = txt_BDkouza(Index).SelectionStart + 1
				
				'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
			Else
				intChkKb = 2 '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
				txt_BDnyukn(Index).Focus() '�����z���ڂֈړ�
			End If
			txt_BDkouza(Index).SelectionLength = 1
			
			'Backspace or ����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDkouza(Index).SelectionStart > 0 Then
				txt_BDkouza(Index).SelectionStart = txt_BDkouza(Index).SelectionStart - 1
				
				'�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
			Else
				'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
				If Trim(txt_BDkouza(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				intChkKb = 2 '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
				txt_BDdkbid(Index).Focus() '������ʍ��ڂֈړ�
			End If
			txt_BDkouza(Index).SelectionLength = 1
			
			'���󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 2 '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
			If Index = 0 Then
				txt_HDkouza.Focus()
			Else
				txt_BDkouza(Index - 1).Focus() '������ʍ��ڂֈړ�
			End If
			
			'����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 2 '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
			If Index < 2 Then
				txt_BDkouza(Index + 1).Focus() '�����z���ڂֈړ�
			End If
			
			'Enter������
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '������������ނ̓��̓`�F�b�N
			txt_BDnyukn(Index).Focus() '�����z���ڂֈړ�
			
			'Delete������
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDkouza_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDkouza.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'�A���t�@�x�b�g��������啶���ɕϊ�����
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDkouza_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDkouza.Leave
		Dim Index As Short = txt_BDkouza.GetIndex(eventSender)
		'������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		'���̓`�F�b�N(�󔒂͖���)
		chkBDkouza(Index)
		'�w�i�F�𔒂ɖ߂�
		txt_BDkouza(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================���l(����)=======================================================
	
	
	'UPGRADE_WARNING: �C�x���g txt_BDlincma.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_BDlincma_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.TextChanged
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		Dim p As Short
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		With txt_BDlincma(Index)
			blnUsableEvent = False
			p = .SelectionStart
			
			'���͒l��10byte�Ŗ������͋󔒖���
			.Text = LeftWid(.Text, 20)
			
			.SelectionStart = p
			blnUsableEvent = True
			
			'�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
			If .SelectionStart = 20 Then
				If Index < 2 Then
					txt_BDdkbid(Index + 1).Focus() '������ʍ��ڂֈړ�
				Else
					intChkKb = 2 '���o�^���s
					txt_HDkouza.Focus()
				End If
			End If
			.SelectionLength = 1
			
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(Index).SUB_LINCMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gtypeFR_SUB(Index).SUB_LINCMA = .Text
		End With
		
	End Sub
	
	Private Sub txt_BDlincma_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.Enter
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		'�擪�ʒu��I����Ԃɂ���
		txt_BDlincma(Index).SelectionStart = 0
		txt_BDlincma(Index).SelectionLength = 1
        '�w�i�F�����F�ɂ���
        txt_BDlincma(Index).BackColor = System.Drawing.Color.Yellow
        '2019/04/26 DEL START
        ''���׍s�R�}���h�����s�Ƃ���
        'mnu_bdinitdsp.Enabled = True
        'mnu_gyoin.Enabled = True
        'mnu_gyodel.Enabled = True
        ''�������������s�s�Ƃ���
        'mnu_showwnd.Enabled = False
        '2019/04/26 DEL E N D
        '���ݍs�ԍ���ۑ�
        CurrentLine = Index
	End Sub
	
	Private Sub txt_BDlincma_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDlincma.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		
		'�E��󉟉���
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_BDlincma(Index).SelectionStart < 19 Then
				txt_BDlincma(Index).SelectionStart = txt_BDlincma(Index).SelectionStart + 1
				
				'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
			Else
				If Index < 2 Then
					txt_BDdkbid(Index + 1).Focus() '������ʍ��ڂֈړ�
				Else
					intChkKb = 1 '���o�^���s
					txt_HDkouza.Focus()
				End If
			End If
			txt_BDlincma(Index).SelectionLength = 1
			
			'Backspace or ����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_BDlincma(Index).SelectionStart > 0 Then
				txt_BDlincma(Index).SelectionStart = txt_BDlincma(Index).SelectionStart - 1
				
				'�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
			Else
				'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
				If Trim(txt_BDlincma(Index).Text) <> "" And KeyCode = System.Windows.Forms.Keys.Back Then
					Exit Sub
				End If
				intChkKb = 1 '�o�^���Ȃ�
				txt_BDnyukn(Index).Focus() '�����z���ڂֈړ�
			End If
			txt_BDlincma(Index).SelectionLength = 1
			
			'���󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			intChkKb = 1 '�o�^���Ȃ�
			If Index = 0 Then
				txt_HDkouza.Focus()
			Else
				txt_BDlincma(Index - 1).Focus() '���������ڂֈړ�
			End If
			
			'����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			If Index < 2 Then
				txt_BDlincma(Index + 1).Focus() '������ʍ��ڂֈړ�
			Else
				intChkKb = 2 '���o�^���s
				txt_HDkouza.Focus()
			End If
			
			'Enter������
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			If Index < 2 Then
				txt_BDdkbid(Index + 1).Focus() '������ʍ��ڂֈړ�
			Else
				intChkKb = 2 '���o�^���s
				txt_HDkouza.Focus()
			End If
			
			'Delete������
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDlincma_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDlincma.Leave
		Dim Index As Short = txt_BDlincma.GetIndex(eventSender)
		'�w�i�F�𔒂ɖ߂�
		txt_BDlincma(Index).BackColor = System.Drawing.Color.White
		'���o�^���s
		If Index = 2 And intChkKb = 2 Then
            '// V3.01�� UPD
            '        mnu_regist_Click
            If intEventUkai = 0 Then
                '2019/04/26 CHG START
                'mnu_regist_Click(mnu_regist, New System.EventArgs())
                mnu_regist_Click(Button1, New System.EventArgs())
                '2019/04/26 CHG E N D
            End If
            '// V3.01�� UPD
        End If
		intChkKb = 1
	End Sub
	
	
	'=======================================================�����z(����)�K�{����=======================================================
	
	
	'�����z���ڕύX��
	'UPGRADE_WARNING: �C�x���g txt_BDnyukn.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_BDnyukn_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.TextChanged
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		With txt_BDnyukn(Index)
			blnUsableEvent = False
			'���z�̌����\��������t��
			'// V2.01�� UPD
			''''        .Text = Format(.Text, "#,###,##0")
			''''        .SelStart = Len(.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_BDnyukn(Index).Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(.Text) <> 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				.Text = VB6.Format(SSSVal(.Text), "#,###,##0")
			Else
				.Text = VB6.Format(.Text, "#,###,##0")
			End If
			.SelectionStart = Len(.Text)
			'// V2.01�� UPD
			blnUsableEvent = True
			
			''''        '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
			''''        If .SelStart = 4 Or .SelStart = 7 Then
			''''            .SelStart = .SelStart + 1
			''''        ElseIf .SelStart = 9 Then
			''''            txt_BDlincma(Index).SetFocus                 '���l���ڂֈړ�
			''''        End If
			''''        .SelLength = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g gtypeFR_SUB(Index).SUB_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gtypeFR_SUB(Index).SUB_NYUKN = SSSVal(.Text)
		End With
	End Sub
	
	Private Sub txt_BDnyukn_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.Enter
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'�S�I����Ԃɂ���
		txt_BDnyukn(Index).SelectionStart = 0
		txt_BDnyukn(Index).SelectionLength = 9
        '�w�i�F�����F�ɂ���
        txt_BDnyukn(Index).BackColor = System.Drawing.Color.Yellow
        '2019/04/26 DEL START
        ''���׍s�R�}���h�����s�Ƃ���
        'mnu_bdinitdsp.Enabled = True
        'mnu_gyoin.Enabled = True
        'mnu_gyodel.Enabled = True
        ''�������������s�s�Ƃ���
        'mnu_showwnd.Enabled = False
        '2019/04/26 DEL E N D
        '���ݍs�ԍ���ۑ�
        CurrentLine = Index
	End Sub
	
	Private Sub txt_BDnyukn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_BDnyukn.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		With txt_BDnyukn(Index)
			
			'�E��� or Space������
			If KeyCode = System.Windows.Forms.Keys.Right Or KeyCode = System.Windows.Forms.Keys.Space Then
				If .SelectionStart < 9 Then
					'// V2.01�� UPD
					''''                .SelStart = .SelStart + 1
					''''                '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
					''''                If .SelStart = 1 Or .SelStart = 5 Then
					''''                    .SelStart = .SelStart + 1
					''''                End If
					.SelectionStart = .SelectionStart + 1
					If Mid(.Text, .SelectionStart + 1, 1) = "," Then
						.SelectionStart = .SelectionStart + 1
					End If
					'// V2.01�� UPD
					
					'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
				Else
					txt_BDlincma(Index).Focus() '���l���ڂֈړ�
				End If
				
				'Backspace or ����󉟉���
			ElseIf KeyCode = System.Windows.Forms.Keys.Left Then 
				If .SelectionStart > 0 Then
					'// V2.01�� UPD
					'                .SelStart = .SelStart - 1
					'                '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
					'                If .SelStart = 4 Or .SelStart = 7 Then
					'                    .SelStart = .SelStart - 1
					'                End If
					.SelectionStart = .SelectionStart - 1
					If Mid(.Text, .SelectionStart + 1, 1) = "," Then
						.SelectionStart = .SelectionStart - 1
					End If
					'// V2.01�� UPD
					
					'�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
				Else
					txt_BDkouza(Index).Focus() '����������ڂֈړ�
				End If
				
				'���󉟉���
			ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
				If Index = 0 Then
					txt_HDkouza.Focus()
				Else
					txt_BDnyukn(Index - 1).Focus() '����������ڂֈړ�
				End If
				
				'����󉟉���
			ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
				If Index < 2 Then
					txt_BDnyukn(Index + 1).Focus() '���l���ڂֈړ�
				End If
				
				'Enter������
			ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
				txt_BDlincma(Index).Focus() '���l���ڂֈړ�
				
			ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
				Exit Sub
			End If
			
		End With
		KeyCode = 0
	End Sub
	
	Private Sub txt_BDnyukn_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_BDnyukn.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'Backspace, �}�C�i�X�L���͓��͂ł���
		If KeyAscii = System.Windows.Forms.Keys.Back Then GoTo EventExitSub
		If KeyAscii = 45 And VB.Left(txt_BDnyukn(Index).Text, 1) <> "-" Then GoTo EventExitSub
		
		'// V2.01�� ADD
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_BDnyukn(Index)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(txt_BDnyukn(Index)) >= 9999999 Or SSSVal(txt_BDnyukn(Index)) <= -999999 Then
			KeyAscii = 0
			GoTo EventExitSub
		End If
		'// V2.01�� ADD
		
		'���l�̂ݓ��͉Ƃ���
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_BDnyukn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_BDnyukn.Leave
		Dim Index As Short = txt_BDnyukn.GetIndex(eventSender)
		'�����F�����ɖ߂�
		txt_BDnyukn(Index).ForeColor = System.Drawing.Color.Black
		'�w�i�F�𔒂ɖ߂�
		txt_BDnyukn(Index).BackColor = System.Drawing.Color.White
	End Sub
	
	
	'=======================================================�������(�w�b�_)=======================================================
	
	'UPGRADE_WARNING: �C�x���g txt_HDkouza.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub txt_HDkouza_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.TextChanged
		Dim p As Short
		
		'�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_HDkouza.SelectionStart
		
		'�S�p���폜����
		txt_HDkouza.Text = delZenkaku((txt_HDkouza.Text))
		'���͒l��10byte�Ŗ������͋󔒖���
		txt_HDkouza.Text = txt_HDkouza.Text & Space(10 - Len(txt_HDkouza.Text))
		
		txt_HDkouza.SelectionStart = p
		blnUsableEvent = True
		
		'�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
		If txt_HDkouza.SelectionStart = 10 Then
			intChkKb = 1 '������������ނ̓��̓`�F�b�N
			txt_BDdkbid(0).Focus() '������ʍ��ڂֈړ�
		End If
		txt_HDkouza.SelectionLength = 1
	End Sub
	
	Private Sub txt_HDkouza_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.Enter
		'�擪�ʒu��I����Ԃɂ���
		txt_HDkouza.SelectionStart = 0
		txt_HDkouza.SelectionLength = 1
		'�w�i�F�����F�ɂ���
		txt_HDkouza.BackColor = System.Drawing.Color.Yellow

        '2019/04/26 DEL START
        ''���׍s�R�}���h�����s�s�Ƃ���
        'mnu_bdinitdsp.Enabled = False
        'mnu_gyoin.Enabled = False
        'mnu_gyodel.Enabled = False

        ''�������������s�\�Ƃ���
        'mnu_showwnd.Enabled = True
        '2019/04/26 DEL E N D

        CurrentLine = -1 '�w�b�_��\���l���Z�b�g
	End Sub
	
	Private Sub txt_HDkouza_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_HDkouza.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'�E��󉟉���
		If KeyCode = System.Windows.Forms.Keys.Right Then
			If txt_HDkouza.SelectionStart < (10 - 1) Then
				txt_HDkouza.SelectionStart = txt_HDkouza.SelectionStart + 1
				
				'�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
			Else
				intChkKb = 1 '������������ނ̓��̓`�F�b�N
				txt_BDdkbid(0).Focus() '������ʍ��ڂֈړ�
			End If
			txt_HDkouza.SelectionLength = 1
			
			'Backspace or ����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Back Or KeyCode = System.Windows.Forms.Keys.Left Then 
			If txt_HDkouza.SelectionStart > 0 Then
				txt_HDkouza.SelectionStart = txt_HDkouza.SelectionStart - 1
			End If
			txt_HDkouza.SelectionLength = 1
			
			'���󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then 
			'
			
			'����󉟉���
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then 
			intChkKb = 1 '������������ނ̓��̓`�F�b�N
			txt_BDdkbid(0).Focus() '������ʍ��ڂֈړ�
			
			'Enter������
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Then 
			intChkKb = 1 '������������ނ̓��̓`�F�b�N
			txt_BDdkbid(0).Focus() '������ʍ��ڂֈړ�
			
			'Delete������
		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
			Exit Sub
			
		End If
		KeyCode = 0
	End Sub
	
	Private Sub txt_HDkouza_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_HDkouza.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'�A���t�@�x�b�g��������啶���ɕϊ�����
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txt_HDkouza_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_HDkouza.Leave
		'������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
		If blnUsableEvent = False Then Exit Sub
		
		'���̓`�F�b�N(�󔒂͖���)
		chkHDkouza()
		'�w�i�F�𔒂ɖ߂�
		txt_HDkouza.BackColor = System.Drawing.Color.White
	End Sub
	
	'���ו�������ʃ{�^���N���b�N��
	Private Sub cmd_BDdkbid_Click()
		If CurrentLine >= 0 Then
			'���X�g��\��
			WLS_LIST1.ShowDialog()
			WLS_LIST1.Close()
			
			txt_BDdkbid(CurrentLine).Focus()
			If WLSTBD_RTNCODE <> "" Then
				txt_BDdkbid(CurrentLine).Text = WLSTBD_RTNCODE
				txt_BDkouza(CurrentLine).Focus()
			End If
		End If
	End Sub
	
	'���ו���������{�^���N���b�N��
	Private Sub cmd_BDkouza_Click()
		If CurrentLine >= 0 Then
			'���X�g��\��
			WLS_LIST2.ShowDialog()
			WLS_LIST2.Close()
			
			txt_BDkouza(CurrentLine).Focus()
			If WLSKOZ_RTNCODE <> "" Then
				txt_BDkouza(CurrentLine).Text = WLSKOZ_RTNCODE
				txt_BDnyukn(CurrentLine).Focus()
			End If
		End If
	End Sub
	
	'�w�b�_����������{�^���N���b�N��
	Private Sub cmd_HDkouza_Click()
		'���X�g��\��
		WLS_LIST2.ShowDialog()
		WLS_LIST2.Close()
		
		txt_HDkouza.Focus()
		If WLSKOZ_RTNCODE <> "" Then
			txt_HDkouza.Text = WLSKOZ_RTNCODE
			txt_BDdkbid(0).Focus()
		End If
	End Sub

    '2019/04/26 ADD START
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mnu_regist_Click(Button1, New System.EventArgs())
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        mnu_showwnd_Click(Button5, New System.EventArgs())
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        '�ۗ�
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        mnu_gyodel_Click(Button8, New System.EventArgs())
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        mnu_initdsp_Click(Button9, New System.EventArgs())
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        mnu_exit_Click(Button12, New System.EventArgs())
    End Sub

    Private Sub cmd_HDkouza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_HDkouza.Click
        cmd_HDkouza_Click()
    End Sub

    Private Sub cmd_BDdkbid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_BDdkbid.Click
        cmd_BDdkbid_Click()
    End Sub

    Private Sub cmd_BDkouza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_BDkouza.Click
        cmd_BDkouza_Click()
    End Sub

    Private Sub FR_SSSSUB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

                Case Keys.F7
                    Me.Button7.PerformClick()

                Case Keys.F8
                    Me.Button8.PerformClick()

                Case Keys.F9
                    Me.Button9.PerformClick()

                Case Keys.F12
                    Me.Button12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    '2019/04/26 ADD E N D

End Class