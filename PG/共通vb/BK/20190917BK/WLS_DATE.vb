Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_DATE
	Inherits System.Windows.Forms.Form
	Dim DAYIDX As Short
	'   �V�X�e���̓��t
	Dim Sys_date As New VB6.FixedLengthString(10)
	Dim Sys_year As New VB6.FixedLengthString(4)
	Dim Sys_month As New VB6.FixedLengthString(2)
	Dim Sys_day As New VB6.FixedLengthString(2)
	'   �J�����_�[�\���̔N��
	Dim Cur_year As New VB6.FixedLengthString(4)
	Dim Cur_month As New VB6.FixedLengthString(2)
	'   �j���̃o�b�t�@�[
	' H_KB �j���敪  0:�j���łȂ��i����߁^�{�s�O�j, 1:�U��ւ��x���̂���j��,
	'               2:�U��ւ��̂Ȃ��x��, 3:�t��/�H��, 4:�悎���j
	'               �悎���j�̓��t�̈Ӗ�  �ꌅ��:�悎 �񌅖�:2�`6 �� ���`�� �Ƃ���
	'                 ��)��񌎗j = 22, ��l���j = 46
	' H_SttYY �{�s�N
	' H_OldDD �{�s�N�ȑO�̐ݒ��
	' H_OldKB �{�s�N�ȑO�̏j���敪
	' �{�s�N�̐ݒ�� 07/20(1)1996:00(0) = 1996�N����7��20�����ʏ�̏j���Ƃ��ĐV�݂��ꂽ
	'               01/22(4)2000:15(1) = 2000�N�����2���j�ɕύX���ꂽ(�ȑO��15��������)
	Private Structure HOLIDAY_TYPE
		Dim H_MM As Short
		Dim H_DD As Short
		Dim H_KB As Short
		Dim H_SttYY As Short
		Dim H_OldDD As Short
		Dim H_OldKB As Short
	End Structure
	
	'�e�J�����_�敪���ʐF
	Private Const KBNDAY_BACKCOLOR As Integer = &HFFFFFF
	'�ʏ���w�i�F
	Private Const NORMALDAY_BACKCOLOR As Integer = &HC0C0C0
	'�I����w�i�F
	Private Const SELECTDAY_BACKCOLOR As Integer = &HFFFF00
	
	'�x���O�i�F
	Private Const HOLIDAY_FORECOlOR As Integer = &HFF
	'�y�j�O�i�F
	Private Const SATDAY_FORECOlOR As Integer = &HFF0000
	'�ʏ���O�i�F
	Private Const NORMALDAY_FORECOlOR As Integer = &H80000008
	
	
	Dim WLS_HoliDay() As HOLIDAY_TYPE
	
	'�J�����_�}�X�^���
	Private WLS_Cldmt() As TYPE_DB_CLDMTA
	
	Dim HdayCnt As Short
	Dim D_MAX As Short
	Dim W_DAY As Short
	Dim W_DAYIDX As Short
	
	Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Get_Cldmta
	'   �T�v�F  �J�����_���擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_Get_Cldmta(ByRef yy As Short, ByRef mm As Short)
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        '20190322 DEL START
        'Dim Usr_Ody_LC As U_Ody
        '20190322 DEL END

		Dim Cnt As Short
		
		strSQL = ""
		strSQL = strSQL & " Select CLDDT " '���t
		strSQL = strSQL & "      , CLDWKKB " '�j��
		strSQL = strSQL & "      , CLDHLKB " '�j��
		strSQL = strSQL & "      , SLDKB " '�c�Ɠ��敪
		strSQL = strSQL & "      , BNKKDKB " '��s�ғ��敪
		strSQL = strSQL & "      , DTBKDKB " '�����ғ��敪
		strSQL = strSQL & "      , ETCKBA " '���̑��敪�P
		strSQL = strSQL & "      , ETCKBB " '���̑��敪�Q
		strSQL = strSQL & "      , ETCKBC " '���̑��敪�R
		strSQL = strSQL & "      , ETCKBD " '���̑��敪�S
		strSQL = strSQL & "      , ETCKBE " '���̑��敪�T
		strSQL = strSQL & "      , ETCKBF " '���̑��敪�U
		strSQL = strSQL & "      , ETCKBG " '���̑��敪�V
		strSQL = strSQL & "      , ETCKBH " '���̑��敪�W
		strSQL = strSQL & "      , ETCKBI " '���̑��敪�X
		strSQL = strSQL & "      , ETCKBJ " '���̑��敪�P�O
		strSQL = strSQL & "   from CLDMTA "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "   and  CLDDT >= " & VB6.Format(yy, "0000") & VB6.Format(mm, "00") & "01"
		strSQL = strSQL & "   and  CLDDT <= " & VB6.Format(yy, "0000") & VB6.Format(mm, "00") & "99"
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "        CLDDT " '���t
		
        'DB�A�N�Z�X
        '2019/03/20 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/20 CHG E N D
		
		ReDim WLS_Cldmt(0)
        Cnt = 0
        '2019/03/20 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '    Cnt = Cnt + 1
        '    ReDim Preserve WLS_Cldmt(Cnt)

        '    With WLS_Cldmt(Cnt)
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLDDT = CF_Ora_GetDyn(Usr_Ody_LC, "CLDDT", "") '���t
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDWKKB", "") '�j��
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDHLKB", "") '�j��
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SLDKB = CF_Ora_GetDyn(Usr_Ody_LC, "SLDKB", "") '�c�Ɠ��敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "BNKKDKB", "") '��s�ғ��敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "DTBKDKB", "") '�����ғ��敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBA", "") '���̑��敪�P
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBB", "") '���̑��敪�Q
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBC", "") '���̑��敪�R
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBD", "") '���̑��敪�S
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBE", "") '���̑��敪�T
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBF", "") '���̑��敪�U
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBG", "") '���̑��敪�V
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBH", "") '���̑��敪�W
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBI", "") '���̑��敪�X
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBJ", "") '���̑��敪�P�O
        '    End With

        '    Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop
        For Each row As DataRow In dt.Rows

            Cnt = Cnt + 1
            ReDim Preserve WLS_Cldmt(Cnt)

            With WLS_Cldmt(Cnt)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDDT = DB_NullReplace(row("CLDDT"), "") '���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDWKKB = DB_NullReplace(row("CLDWKKB"), "") '�j��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDHLKB = DB_NullReplace(row("CLDHLKB"), "") '�j��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SLDKB = DB_NullReplace(row("SLDKB"), "") '�c�Ɠ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BNKKDKB = DB_NullReplace(row("BNKKDKB"), "") '��s�ғ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DTBKDKB = DB_NullReplace(row("DTBKDKB"), "") '�����ғ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBA = DB_NullReplace(row("ETCKBA"), "") '���̑��敪�P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBB = DB_NullReplace(row("ETCKBB"), "") '���̑��敪�Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBC = DB_NullReplace(row("ETCKBC"), "") '���̑��敪�R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBD = DB_NullReplace(row("ETCKBD"), "") '���̑��敪�S
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBE = DB_NullReplace(row("ETCKBE"), "") '���̑��敪�T
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBF = DB_NullReplace(row("ETCKBF"), "") '���̑��敪�U
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBG = DB_NullReplace(row("ETCKBG"), "") '���̑��敪�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBH = DB_NullReplace(row("ETCKBH"), "") '���̑��敪�W
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBI = DB_NullReplace(row("ETCKBI"), "") '���̑��敪�X
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBJ = DB_NullReplace(row("ETCKBJ"), "") '���̑��敪�P�O
            End With
        Next
        '2019/03/20 CHG E N D
		
        '�N���[�Y
        '20190322 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '20190322 DEL END
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Get_YmdKbn
	'   �T�v�F  �敪���擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function WLS_Get_YmdKbn(ByRef yy As Short, ByRef mm As Short, ByRef dd As Short) As Boolean
		
		Dim Cnt As Short
		Dim bolKbnFlg As Boolean
		Dim strKbn As String
		
		'�敪�ݒ�t���O
		bolKbnFlg = False
		
		For Cnt = 1 To UBound(WLS_Cldmt)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 7, 2)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 5, 2)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 1, 4)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 1, 4)) = yy And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 5, 2)) = mm And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 7, 2)) = dd Then
				'���t����v
				strKbn = ""
				Select Case WLSDATE_KBN
					Case DATE_KBN_SLDKB
						'�c�Ɠ��敪
						strKbn = WLS_Cldmt(Cnt).SLDKB
					Case DATE_KBN_BNKKDKB
						'��s�ғ��敪
						strKbn = WLS_Cldmt(Cnt).BNKKDKB
					Case DATE_KBN_DTBKDKB
						'�����ғ��敪
						strKbn = WLS_Cldmt(Cnt).DTBKDKB
					Case DATE_KBN_ETCKBA
						'���̑��敪�P
						strKbn = WLS_Cldmt(Cnt).ETCKBA
					Case DATE_KBN_ETCKBB
						'���̑��敪�Q
						strKbn = WLS_Cldmt(Cnt).ETCKBB
					Case DATE_KBN_ETCKBC
						'���̑��敪�R
						strKbn = WLS_Cldmt(Cnt).ETCKBC
					Case DATE_KBN_ETCKBD
						'���̑��敪�S
						strKbn = WLS_Cldmt(Cnt).ETCKBD
					Case DATE_KBN_ETCKBE
						'���̑��敪�T
						strKbn = WLS_Cldmt(Cnt).ETCKBE
					Case DATE_KBN_ETCKBF
						'���̑��敪�U
						strKbn = WLS_Cldmt(Cnt).ETCKBF
					Case DATE_KBN_ETCKBG
						'���̑��敪�V
						strKbn = WLS_Cldmt(Cnt).ETCKBG
					Case DATE_KBN_ETCKBH
						'���̑��敪�W
						strKbn = WLS_Cldmt(Cnt).ETCKBH
					Case DATE_KBN_ETCKBI
						'���̑��敪�X
						strKbn = WLS_Cldmt(Cnt).ETCKBI
					Case DATE_KBN_ETCKBJ
						'���̑��敪�P�O
						strKbn = WLS_Cldmt(Cnt).ETCKBJ
				End Select
				
				'��������ʂ̃p�����[�^�ɊY������敪�Ŕ���
				If strKbn = "1" Then
					bolKbnFlg = True
				End If
				Exit For
				
			End If
		Next 
		
		WLS_Get_YmdKbn = bolKbnFlg
		
	End Function
	
	'UPGRADE_WARNING: Form �C�x���g WLS_DATE.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLS_DATE_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190521 DEL START
        '      DblClickFl = False

        ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'If IsDbNull(Set_date.Value) Or Not IsDate(Set_date.Value) Then
        '	Sys_date.Value = DateString
        '	Sys_year.Value = VB.Left(Sys_date.Value, 4)
        '	Sys_month.Value = Mid(Sys_date.Value, 6, 2)
        '	Sys_day.Value = VB.Right(Sys_date.Value, 2)
        'Else
        '	Sys_date.Value = Set_date.Value
        '	Sys_year.Value = VB.Left(Set_date.Value, 4)
        '	Sys_month.Value = Mid(Set_date.Value, 6, 2)
        '          Sys_day.Value = VB.Right(Set_date.Value, 2)
        '      End If
        'Cur_year.Value = Sys_year.Value
        'Cur_month.Value = Sys_month.Value
        '      Set_calendar()
        '20190521 DEL END

    End Sub
	
	Private Sub WLS_DATE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = 27 Then Hide()
	End Sub
	
	Private Sub WLS_DATE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim w_date As String
		w_date = CStr(Today)
		If Len(w_date) <> 10 Then
			MsgBox("���t�̌`�����Ⴂ�܂��B" & Chr(13) & "�R���g���[���p�l���̊e���Ή��̒Z���`�����C�����ĉ������B", 48)
			Hide()
		End If
		
		'   �j���̐ݒ�
		Dim INI_NO As Short
		Dim sLine As String
		INI_NO = FreeFile
		
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WLSDATE_RTNCODE = ""
		
		On Error Resume Next
		FileOpen(INI_NO, SSS_INIDAT(2) & "CALENDAR.INI", OpenMode.Input)
		If Err.Number <> 0 Then
			On Error GoTo CALENDAR_ERR
			FileOpen(INI_NO, SSS_INIDAT(0) & "CALENDAR.INI", OpenMode.Input)
		End If
		
		ReDim WLS_HoliDay(20)
		
		HdayCnt = 0
		Do Until EOF(INI_NO)
			sLine = LineInput(INI_NO)
			If InStr(sLine, "=") = 3 And InStr(sLine, "/") = 6 And Len(sLine) > 10 Then
				If HdayCnt > UBound(WLS_HoliDay) Then ReDim Preserve WLS_HoliDay(HdayCnt + 10)
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_HoliDay(HdayCnt).H_MM = SSSVal(Mid(sLine, 4, 2))
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_HoliDay(HdayCnt).H_DD = SSSVal(Mid(sLine, 7, 2))
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WLS_HoliDay(HdayCnt).H_KB = SSSVal(Mid(sLine, 10, 1))
				If InStr(sLine, ":") = 16 And InStr(sLine, ";") = 22 Then
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WLS_HoliDay(HdayCnt).H_SttYY = SSSVal(Mid(sLine, 12, 4))
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WLS_HoliDay(HdayCnt).H_OldDD = SSSVal(Mid(sLine, 17, 2))
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WLS_HoliDay(HdayCnt).H_OldKB = SSSVal(Mid(sLine, 20, 1))
				End If
				HdayCnt = HdayCnt + 1
			End If
		Loop 
		FileClose(INI_NO)

        '20190521 ADD START
        DblClickFl = False

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(Set_date.Value) Or Not IsDate(Set_date.Value) Then
            Sys_date.Value = DateString
            Sys_year.Value = VB.Left(Sys_date.Value, 4)
            Sys_month.Value = Mid(Sys_date.Value, 6, 2)
            Sys_day.Value = VB.Right(Sys_date.Value, 2)
        Else
            Sys_date.Value = Set_date.Value
            Sys_year.Value = VB.Left(Set_date.Value, 4)
            Sys_month.Value = Mid(Set_date.Value, 6, 2)
            Sys_day.Value = VB.Right(Set_date.Value, 2)
        End If
        Cur_year.Value = Sys_year.Value
        Cur_month.Value = Sys_month.Value
        Set_calendar()
        '20190521 ADD END

        Exit Sub

CALENDAR_ERR: 
		MsgBox("�J�����_�[��񂪐���������܂���B", 48)
	End Sub
	
	Private Sub Label1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.Click
		Dim Index As Short = Label1.GetIndex(eventSender)
		Dim W_DAY As String
		Sys_year.Value = Cur_year.Value
		Sys_month.Value = Cur_month.Value
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Sys_day.Value = VB6.Format(SSSVal(Me.Label1(Index).Text), "00")
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		W_DAY = VB6.Format(SSSVal(Me.Label1(W_DAYIDX).Text), "00")
		'�J�����_�}�X�^�́����敪����
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(W_DAY) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Sys_month) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WLS_Get_YmdKbn(SSSVal(Sys_year.Value), SSSVal(Sys_month.Value), SSSVal(W_DAY)) = True Then
			'�w�i�F�y���z
			Me.Label1(W_DAYIDX).BackColor = System.Drawing.ColorTranslator.FromOle(KBNDAY_BACKCOLOR)
		Else
			Me.Label1(W_DAYIDX).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
		End If
		
		W_DAYIDX = Index
		Me.Label1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(SELECTDAY_BACKCOLOR)
	End Sub
	
	Private Sub Label1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.DoubleClick
		Dim Index As Short = Label1.GetIndex(eventSender)
		Dim C_day As Short
		C_day = Index + 2 - W_DAY
		If C_day > 0 And C_day <= D_MAX Then
			Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
			WLSDATE_RTNCODE = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
			Call WLS_SLIST_MOVE(Set_date.Value, Len(Set_date.Value))
			'DblClick�C�x���g��Q�Ή�  97/04/07
			DblClickFl = True
		End If
	End Sub
	
	Private Sub Set_calendar()
		'   �������ݒ�
		Dim yy As Short
		Dim mm As Short
		Dim hday, hyear, hidx As Short
		Dim HdayArr() As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mm = SSSVal(Cur_month.Value)
		'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DATE.ymdpanel.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/12 CHG START
        'Me.ymdpanel.Caption = VB6.Format(yy, "0000") & "�N " & VB6.Format(mm, "00") & "��"
        Me.ymdpanel.Text = VB6.Format(yy, "0000") & "�N " & VB6.Format(mm, "00") & "��"
        '2019/03/12 CHG E N D
		
		'�J�����_���擾
		Call WLS_Get_Cldmta(yy, mm)
		
		'   �����̓����v�Z(28-31)
		If mm = 1 Or mm = 3 Or mm = 5 Or mm = 7 Or mm = 8 Or mm = 10 Or mm = 12 Then
			D_MAX = 31
		ElseIf mm = 4 Or mm = 6 Or mm = 9 Or mm = 11 Then 
			D_MAX = 30
		ElseIf (yy Mod 4 = 0 And yy Mod 100 <> 0) Or yy Mod 400 = 0 Then 
			D_MAX = 29
		Else
			D_MAX = 28
		End If
		
		ReDim HdayArr(D_MAX)
		Dim tmpX, tmpN, tmpD As Short
		
		'   ��������̗j���v�Z(1-7)
		Dim s_date As New VB6.FixedLengthString(10)
		s_date.Value = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		'UPGRADE_WARNING: DateValue �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		W_DAY = WeekDay(DateValue(s_date.Value))
		
		'   �e���t�ւ̋敪�ݒ� 0:�ʏ�, 1:�U�։\�j��, 2:�U�֕s�x��
		For hidx = 0 To HdayCnt - 1
			If WLS_HoliDay(hidx).H_MM = mm Then
				If WLS_HoliDay(hidx).H_KB = 3 Then '�t��/�H��
					'   �t���ƏH���̌v�Z
					hyear = yy - 1980
					If mm = 3 Then
						Select Case hyear
							Case 0, 4, 8, 12, 13, 16, 17, 20, 21, 24, 25, 28, 29, 32, 33, 36, 37, 40, 41, 44, 45, 46, 48, 49, 50, 52, 53, 54, 56, 57, 58, 60, 61, 62, 64, 65, 66, 68, 69, 70
								hday = 20
							Case Else
								hday = 21
						End Select
					ElseIf mm = 9 Then 
						Select Case hyear
							Case 32, 36, 40, 44, 48, 52, 56, 60, 64, 65, 68, 69
								hday = 22
							Case Else
								hday = 23
						End Select
					End If
					HdayArr(hday) = 1
				ElseIf WLS_HoliDay(hidx).H_SttYY > yy Then  '�{�s���ȑO
					'H_OldDD =0 �̏ꍇ�̓_�~�[�z��(=0)�ɓ���
					If WLS_HoliDay(hidx).H_OldKB = 4 Then '��N X�j��
						tmpN = WLS_HoliDay(hidx).H_OldDD / 10
						tmpX = WLS_HoliDay(hidx).H_OldDD Mod 10
						tmpD = tmpX - W_DAY + (tmpN - 1) * 7
						If tmpX < W_DAY Then tmpD = tmpD + 7
						HdayArr(tmpD) = 2
					Else
						HdayArr(WLS_HoliDay(hidx).H_OldDD) = WLS_HoliDay(hidx).H_OldKB
					End If
				ElseIf WLS_HoliDay(hidx).H_KB = 4 Then  '��N X�j��
					tmpN = WLS_HoliDay(hidx).H_DD / 10
					tmpX = WLS_HoliDay(hidx).H_DD Mod 10
					tmpD = tmpX - W_DAY + (tmpN - 1) * 7 + 1
					If tmpX < W_DAY Then tmpD = tmpD + 7
					HdayArr(tmpD) = 2
				Else
					HdayArr(WLS_HoliDay(hidx).H_DD) = WLS_HoliDay(hidx).H_KB
				End If
			End If
		Next hidx
		
		'   ���t�̌v�Z
		Dim count As Short ' count:����
		Dim hnext As Short ' hnext:�U�֋x�����ǂ���
		Dim k, X, Y, L As Short ' x:X���W, y:Y���W, k:���W�A��(0�`41),
		hnext = False
		count = 2 - W_DAY
		For Y = 0 To 5
			For X = 0 To 6
				k = Y * 7 + X
				If count > 0 And count <= D_MAX Then
					Me.Label1(k).Enabled = True
                    Me.Label1(k).Text = Trim(Str(count))
                    Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_FORECOlOR)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
					If hnext Then ' �U�֋x�����ǂ���
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
						hnext = False
					ElseIf X = 0 Then  ' ���j��
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
						If HdayArr(count) = 1 Then hnext = True '�������U�։\�ȏj���Ȃ�U�֋x����ݒ肷��
					ElseIf HdayArr(count) > 0 Then 
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
					ElseIf X = 6 Then  '�y�j��
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(SATDAY_FORECOlOR)
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Sys_day) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Sys_month) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(Sys_year) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(Sys_year.Value) = yy And SSSVal(Sys_month.Value) = mm And SSSVal(Sys_day.Value) = count Then
						Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(SELECTDAY_BACKCOLOR)
						W_DAYIDX = k
					End If
					
					'�J�����_�}�X�^�́����敪����
					If WLS_Get_YmdKbn(yy, mm, count) = True Then
						'�w�i�F�y���z
						Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(KBNDAY_BACKCOLOR)
					End If
				Else
					Me.Label1(k).Enabled = False
					Me.Label1(k).Text = ""
					Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_FORECOlOR)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
				End If
				count = count + 1
			Next X
		Next Y
	End Sub
	
	Private Sub Label1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = Label1.GetIndex(eventSender)
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mm = SSSVal(Cur_month.Value)
		If mm = 12 Then
			yy = yy + 1
			mm = 1
		Else
			mm = mm + 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		mm = SSSVal(Cur_month.Value)
		If mm = 1 Then
			yy = yy - 1
			mm = 12
		Else
			mm = mm - 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Dim C_day As Short
		
		If (Sys_year.Value = Cur_year.Value) And (Sys_month.Value = Cur_month.Value) Then
			C_day = W_DAYIDX + 2 - W_DAY
			If C_day > 0 And C_day <= D_MAX Then
				Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
				WLSDATE_RTNCODE = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			End If
		Else
			MsgBox("���t���I������Ă��܂���")
		End If
	End Sub
End Class