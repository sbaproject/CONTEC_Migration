Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	
	Public gv_bolKeyFlg As Boolean

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '��d�N������
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '20190703 DELL START
        'If App.PrevInstance Then
        '    MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '20190703 DELL END

        ' "���΂炭���҂���������" �E�B���h�E�\��
        'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
        '20190703 CHG START
        'Load(ICN_ICON)
        'ICN_ICON.ShowDialog()
        '20190703 CHG END
        'DB�ڑ�
        '20190703 CHG START
        'Call CF_Ora_USR1_Open()
        Call DB_START()
        '20190703 CHG END


        '���ʏ���������
        Call CF_Init()


        '�����󋵏Ɖ�ďo������
        Call F_DSP_TNADL71C()


        '20190703 DELL START
        '      ' "���΂炭���҂���������" �E�B���h�E����
        '      ICN_ICON.Close()

        ''��ʏI��
        'Me.Close()
        '20190703 DELL END
        '20190703 ADD START
        SetBar(Me)
        '20190703 ADD END

    End Sub

    '20190703 ADD START
    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBox�̖߂�l

        '--------------------------------------------------------------------------
        '�G���[�g���b�v�錾
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '�����J�n
            '--------------------------------------------------------------------------
            '---�߂�l�ݒ�---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---�߂�l�ݒ�---'
            SetBar = True

            '--------------------------------------------------------------------------
            '�G���[�g���b�v���[�`��
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("�����ް,�ð���ް�ݒ�֐��G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    '20190703 ADD END

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSMAIN ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '20190703 DELL START
        'Me = Nothing
        '20190703 DELL END

        'DB�ڑ�����
        '20190703 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        Call DB_CLOSE(CON)
        '20190703 CHG END

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click

    End Sub
    '20190703 ADD START
    'Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
    '    Call Ctl_Item_Click(btnF1)
    'End Sub

    'Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
    '    Call Ctl_Item_Click(btnF2)
    'End Sub

    'Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
    '    Call Ctl_Item_Click(btnF3)
    'End Sub

    'Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
    '    Call Ctl_Item_Click(btnF4)
    'End Sub

    'Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
    '    Call Ctl_Item_Click(btnF5)
    'End Sub

    'Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
    '    Call Ctl_Item_Click(btnF6)
    'End Sub

    'Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
    '    Call Ctl_Item_Click(btnF7)
    'End Sub

    'Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
    '    Call Ctl_Item_Click(btnF8)
    'End Sub

    'Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
    '    Call Ctl_Item_Click(btnF9)
    'End Sub

    'Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
    '    Call Ctl_Item_Click(btnF10)
    'End Sub

    'Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
    '    Call Ctl_Item_Click(btnF11)
    'End Sub

    'Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
    '    Call Ctl_Item_Click(btnF12)
    'End Sub
    '20190703 ADD END
End Class