Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSSIR4
	Inherits System.Windows.Forms.Form
	'�ȉ��� �R�s�̐ݒ���s������
	Const WM_WLS_MSTKB As String = "4" '�}�X�^�敪�i1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i "":���ނȂ��j
	Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]
	Const WM_WLS_KanaINPUT As Boolean = False '�J�i���ړ��͎g�p�iTrue:���ړ��� False:�J�i�R���{�j
	
	'�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
	Const WM_WLS_TextKey As Short = 1 '�J�n�R�[�h�̃\�[�g�L�[No
	Const WM_WLS_KanaKey As Short = 2 '�J�i�����̃\�[�g�L�[No+���L�[
	Const WM_WLS_SirrnKey As Short = 3
	
	'�E�B���hհ�ް�ݒ�ϐ�
	Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
	Dim WM_WLS_KANALEN As Short '�J�i���͕�����
	Dim WM_WLS_SIRRN As Short
	
	'�E�B���h�����g�p�ϐ�
	Dim WM_WLS_MAX As Short '�P��ʂ̕\������
	Dim WM_WLS_STTKEY As Object '�J�n�L�[
	Dim WM_WLS_ENDKEY As Object '�I���L�[
	Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
	Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Dim WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Dim WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Dim WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	
	
	Dim WlsSelList As String
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	Dim DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07
	
	Private Sub WLS_FORM_INIT()
		'=== WINDOW �\���t�@�C���ݒ� ===
		WM_WLS_MFIL = DBN_SIRMTA
		
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_LEN = Len(DB_SIRMTA.SIRCD) 'LenWid �̓_��
		WM_WLS_KANALEN = Len(DB_SIRMTA.SIRNK) 'LenWid �̓_��
		WM_WLS_SIRRN = Len(DB_SIRMTA.SIRRN)
		''    WlsSelList = "*"
		WlsSelList = "A.SIRNMB, A.DATKB, A.SIRZEIKB, A.SIRSMEKB, A.SIRSMEDD, A.SIRKESCC, A.SIRKESDD, A.SIRNK,  A.SIRCD, A.SIRRN, A.SIRTL, A.SIRSHACD"
		WlsSelList = WlsSelList & ",B.SIRNMA"
        '=== �k�`�a�d�k�ݒ� ===
        ' WLSLABEL = "�R�[�h" & Space(2) & "�d���旪�̖�" & Space(34) & "����" & Space(2) & "�ŋ�" & Space(2) & "�d�b�ԍ�"
        'XXXX5  MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4 123456 MMMMM6 XXXXXXXXX1XXXXXXXXX2
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190911 kuwa
        'WLSLABEL = "�x���溰��" & Space(Len(DB_SIRMTA.SIRCD) - Len(" ����") + 1) & "�x���旪�̖�" & Space(Len(DB_SIRMTA.SIRRN) - Len("�x���旪�̖�") - 0) & "�d���溰��  �d���旪�̖�"
        WLSLABEL.Text = "�x���溰��" & Space(Len(DB_SIRMTA.SIRCD) - Len(" ����") + 1) & "�x���旪�̖�" & Space(Len(DB_SIRMTA.SIRRN) - Len("�x���旪�̖�") - 0) & "�d���溰��  �d���旪�̖�"
        'change end 20190911 

        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = ""
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_ENDKEY = System.DBNull.Value
		HD_TEXT.Text = ""
		HD_SIRRN.Text = ""
		'HD_TEXT.Height = 330
		'HD_TEXT.MaxLength = WM_WLS_LEN
		'HD_TEXT.Width = (WM_WLS_LEN + 1) * 120
		
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		If DB_SIRMTA.DATKB = "9" Or Len(Trim(DB_SIRMTA.SIRSHACD)) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_NEXT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WLS_DSP_CHECK = SSS_OK
		End If
	End Function
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		'====================================
		'   WINDOW ���אݒ�
		'====================================
		
		Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
		Dim WK_TK As New VB6.FixedLengthString(13)
		Dim WK_KESDD As String
		Dim WK_SIRSHANM As String
		'
		WK_SIRSHANM = Mid(DB_SIRMTA.SIRNMA, 1, 40)
		
		''  '  WM_WLS_DSPArray(ArrayCnt) = DB_SIRMTA.SIRCD & " " & LeftWid$(DB_SIRMTA.SIRRN, 40) & " " & LeftWid$(WK_SMENM, 6) & " " & LeftWid$(WK_ZEINM, 6) & " " & LeftWid$(DB_SIRMTA.SIRTL, 20)
		''     WM_WLS_DSPArray(ArrayCnt) = DB_SIRMTA.SIRSHACD & " " & LeftWid$(DB_SIRMTA.SIRCD, Len(DB_SIRMTA.SIRCD)) & "  " & LeftWid$(DB_SIRMTA.SIRRN, Len(DB_SIRMTA.SIRRN))
		WM_WLS_DSPArray(ArrayCnt) = DB_SIRMTA.SIRSHACD & "      " & LeftWid(WK_SIRSHANM, Len(DB_SIRMTA.SIRRN)) & "      " & LeftWid(DB_SIRMTA.SIRCD, Len(DB_SIRMTA.SIRCD)) & "  " & LeftWid(DB_SIRMTA.SIRRN, Len(DB_SIRMTA.SIRRN))
	End Sub
	
	Sub WLS_TextSQL()
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		''    WlsFromWhere = "From SIRMTA Where SIRSHACD >= '" & WM_WLS_STTKEY & "'"
		''    WlsOrderBy = "Order By SIRSHACD,SIRCD"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
		'    WlsFromWhere = "From SIRMTA A,(SELECT SIRCD,SIRRN SIRNMA FROM SIRMTA) B Where A.SIRCD >= '" & WM_WLS_STTKEY & "'"
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From SIRMTA A,(SELECT SIRCD,SIRRN SIRNMA FROM SIRMTA) B Where A.SIRCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		WlsFromWhere = WlsFromWhere & " AND A.SIRSHACD = B.SIRCD(+)"
		WlsOrderBy = "Order By A.SIRSHACD,A.SIRCD"
		'
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_SirrnSQL()
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		''    WlsFromWhere = "From SIRMTA Where SIRRN Like '%" & WM_WLS_STTKEY & "%'"
		''    WlsOrderBy = "Order By SIRCD"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
		'    WlsFromWhere = "From SIRMTA A,(SELECT SIRCD,SIRRN SIRNMA FROM SIRMTA) B Where (A.SIRRN Like " & "'%" & WM_WLS_STTKEY & "%' Or A.SIRNK Like " & " '%" & WM_WLS_STTKEY & "%')"
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From SIRMTA A,(SELECT SIRCD,SIRRN SIRNMA FROM SIRMTA) B Where (A.SIRRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%' Or A.SIRNK Like " & " '%" & AE_EditSQLText(WM_WLS_STTKEY) & "%')"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		'20081006 CHG START RISE)Tanimura '�A���[No.FC08100201
		'    WlsFromWhere = WlsFromWhere & " AND A.SIRSHACD = B.SIRKCD(+)"
		WlsFromWhere = WlsFromWhere & " AND A.SIRSHACD = B.SIRCD(+)"
		'20081006 CHG END   RISE)Tanimura
		WlsOrderBy = "Order By A.SIRSHACD, A.SIRRN, A.SIRNK, A.SIRCD"
		'
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_KanaSQL()
		WM_WLS_KeyNo = WM_WLS_KanaKey
		''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WlsFromWhere = "From SIRMTA Where SIRNK >= '" & WM_WLS_STTKEY & "' And SIRNK < '" & WM_WLS_ENDKEY & "'"
		'WlsOrderBy = "Order By SIRNK, SIRCD"
		WlsOrderBy = "Order By SIRCD"
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Private Sub WLS_DspNew()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		WL_Mode = 0
		cnt = 0
		Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
			'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_Mode = WLS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				If cnt = 0 Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WM_WLS_LastPage = WM_WLS_Pagecnt
					ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
				End If
				Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
				cnt = cnt + 1
			End If
			If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
		If cnt > 0 Then
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
		End If
	End Sub
	
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim strWNM, strWKEY, strWDSP As String
		Dim cnt As Short
		
		LST.Items.Clear()
		cnt = 0
		Do While cnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
				''           strWKEY = LeftWid$(Left(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt), 5), Len(DB_SIRMTA.SIRRN))
				''           strWNM = Space(Len(DB_SIRMTA.SIRRN))
				''           If Trim(strWKEY) > "" Then
				''              Call DB_GetEq(DBN_SIRMTA, 1, strWKEY, BtrNormal)
				''              If DBSTAT = 0 Then strWNM = LeftWid$(DB_SIRMTA.SIRRN, Len(DB_SIRMTA.SIRRN))
				''           End If
				''           strWDSP = strWKEY & "          " & strWNM & "    " & Mid(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt), 9, 50)
				''           LST.AddItem strWDSP
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
			End If
			cnt = cnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
		End If
	End Sub
	
	
	Sub WLS_Kana_Init()
		
		'�J�i���� Combo ������
		'���̈�s�����s���Ȃ���, WLSKANA.ListIndex = 0 �ŃG���[�ɂȂ�
		'  WLSKANA.AddItem "�R�[�h"
		
		If WM_WLS_KanaKey < 1 Then
			'�J�i���������Ȃ�
			'   PNL_USENM(3).Visible = False
			'   WLSKANA.Visible = False
			'   HD_Kana.Visible = False
		ElseIf WM_WLS_KanaINPUT Then 
			'�J�i����͍��ڂ̗L����
			'   WLSKANA.Visible = False
			'   HD_Kana.Visible = True
			'   HD_Kana.Width = WLSKANA.Width
			'    HD_Kana.Left = WLSKANA.Left
		Else
			'  WLSKANA.AddItem "�A        ��"
			' WLSKANA.AddItem "�J        ��"
			' WLSKANA.AddItem "�T        ��"
			'  WLSKANA.AddItem "�^        ��"
			'  WLSKANA.AddItem "�i        ��"
			'  WLSKANA.AddItem "�n        ��"
			'  WLSKANA.AddItem "�}        ��"
			'  WLSKANA.AddItem "��        ��"
			'  WLSKANA.AddItem "��        ��"
			'  WLSKANA.AddItem "��        ��"
		End If
	End Sub
	
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g WLSSIR4.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub WLSSIR4_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'=== WINDOW �ʒu�ݒ� ===
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		''    WM_WLS_STTKEY = ""
		''    WM_WLS_ENDKEY = Null
		''    HD_TEXT.Text = ""
		''    HD_SIRRN.Text = ""
		WM_WLS_Dspflg = False
		'  WLSKANA.ListIndex = 0
		'  HD_Kana.Text = ""
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		ReDim WM_WLS_DSPArray(0)
		
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSSIR4_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window�����ݒ�
		Call WLS_FORM_INIT()
		'���ސݒ�
		Call WLS_Kana_Init()
	End Sub
	
	Private Sub HD_Kana_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			'   WM_WLS_STTKEY = HD_Kana.Text
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = Chr(Asc("�") + 1)
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_KanaSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_Kana_KeyPress(ByRef KeyAscii As Short)
		If KeyAscii < Asc(" ") Then Exit Sub
		''2000/04/18 �J�i���͕����͈͂̌����C��
		''If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
		If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then Exit Sub
		If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
			KeyAscii = 0
		End If
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'' If LenWid(HD_TEXT.Text) > 0 Then
		'     HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		' Else
		'     HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		' End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'    HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_TEXT.Text
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = System.DBNull.Value
			'  WLSKANA.ListIndex = 0
			'   HD_Kana.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	Private Sub HD_SIRRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SIRRN.Enter
		''    If LenWid(HD_SIRRN.Text) > 0 Then
		''        HD_SIRRN.Text = SSS_EDTITM_WLS(HD_SIRRN.Text, HD_SIRRN.MaxLength, WM_WLSKEY_ZOKUSEI)
		''    Else
		''        HD_SIRRN.Text = Space$(HD_SIRRN.MaxLength)
		''    End If
		HD_SIRRN.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_SIRRN.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_SIRRN.SelectionLength = HD_SIRRN.Maxlength
	End Sub
	
	Private Sub HD_SIRRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SIRRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_SIRRN.Text
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = HD_SIRRN.Text
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_SirrnSQL()
			Call WLS_DspNew()
			
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClick�C�x���g��Q�Ή�  97/04/07
		DblClickFl = True
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case System.Windows.Forms.Keys.Left '���L�[
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
			Case System.Windows.Forms.Keys.Right '���L�[
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
	End Sub
	
	
	Private Sub WLSKANA_Click()
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		ReDim WM_WLS_DSPArray(0)
		
		' If WLSKANA.ListIndex > 0 Then
		'    HD_TEXT.Text = ""
		'   W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
		'   WM_WLS_STTKEY = Left$(W_BUF, 1)
		'   WM_WLS_ENDKEY = Chr$(Asc(Right$(W_BUF, 1)) + 1)
		'   Call WLS_KanaSQL
		'  Else
		'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
		Call WLS_TextSQL()
		'  End If
		Call WLS_DspNew()
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByRef KEYCODE As Short, ByRef Shift As Short)
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_Click()
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
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
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
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
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoad�C�x���g��Q�Ή�  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	Private Sub COM_SIRCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_SIRCD.Click
		Dim i As Short
		Dim W_Key As String
		
		DB_PARA(DBN_SIRMTA).KeyBuf = HD_TEXT.Text ' WLSSIRCD.Text
		WLSSIR.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		''98/09/25 �ǉ�
		WLSSIR.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			DB_SIRMTA.SIRCD = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			HD_TEXT.Text = VB.Left(PP_SSSMAIN.SlistCom, 5)
			HD_TEXT.Focus()
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_STTKEY = HD_TEXT.Text & Space(10 - Len(HD_TEXT.Text))
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_ENDKEY = System.DBNull.Value
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		
	End Sub
End Class