Option Strict Off
Option Explicit On
Friend Class DLGLST1
    Inherits System.Windows.Forms.Form

    Private Sub CMD_SELECT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMD_SELECT.Click
        Dim Index As Short = CMD_SELECT.GetIndex(eventSender)
        'UPGRADE_WARNING: �I�u�W�F�N�g SSS_RTNWIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSS_RTNWIN = Index
        Me.Close()
    End Sub

    Private Sub DLGLST1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Text = FR_SSSMAIN.Text
        '2019.04.11 DEL START
        'Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(FR_SSSMAIN.Top) + VB6.PixelsToTwipsY(FR_SSSMAIN.Height) - VB6.PixelsToTwipsY(Height))
        'Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(FR_SSSMAIN.Left) + VB6.PixelsToTwipsX(FR_SSSMAIN.Width) - VB6.PixelsToTwipsX(Width))
        '2019.04.11 DEL END

        '2019.04.11 CHG START
        'CHG START FKS)INABA 2006/11/15******************************************************************
        '��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
        '���s�����̎擾
        'Call Get_Authority(DB_UNYMTA.UNYDT)

        ''��Ɏ擾���������ɂ��APreview��ʂ̈���{�^���A�v�����^�ݒ�{�^���A�t�@�C���o�̓{�^���𐧌䂷��
        'If gs_PRTAUTH = "1" Then '��������L��
        '	CMD_SELECT(0).Enabled = True
        '	CMD_SELECT(1).Enabled = True
        'Else
        '	CMD_SELECT(0).Enabled = False
        '	CMD_SELECT(1).Enabled = True
        'End If
        'If gs_FILEAUTH = "1" Then '�t�@�C���o�͌����L��
        '	CMD_SELECT(1).Enabled = True
        '	CMD_SELECT(2).Enabled = True
        'Else
        '	CMD_SELECT(1).Enabled = True
        '	CMD_SELECT(2).Enabled = False
        'End If
        'CHG  END  FKS)INABA 2006/11/15******************************************************************

        '      
        CMD_SELECT(0).Enabled = True
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(2).Enabled = True
        '2019.04.11 CHG END

    End Sub
End Class