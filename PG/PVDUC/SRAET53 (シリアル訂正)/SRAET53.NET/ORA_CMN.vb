Option Strict Off
Option Explicit On
Module ORA_CMN
	'//* All Right Reserved Copy Right (C)  ������Еx�m�ʊ֐��V�X�e���Y
	'//***************************************************************************************
	'//*
	'//*�����́�
	'//*    ORA_INF.bas
	'//*
	'//*���o�[�W������
	'//* 1.00
	'//*
	'//*���쐬�ҁ�
	'//* FKS)
	'//*
	'//*��������
	'//*    ���ʃ��W���[���iORACLE���ʊ֐��j
	'//*    ORACLE�ɑ΂��ď������s���֐����L�q
	'//*    ORACLE�ɑ΂��鏈���͖{���W���[���̊֐����g�p���邱�ƁB
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|-------------------------------------------------
	'//* 1.00     |20021101|FKS)           |�V�K�쐬
	'//**************************************************************************************
	
	'============================================================================
	''''''''''''''''''''''''''''
	' Oracle Objects for OLE public constant file.
	' This file can be loaded into a code module.
	''''''''''''''''''''''''''''
	'Editmode property values
	' These are intended to match similar constants in the
	' Visual Basic file CONSTANT.TXT
	Public Const ORADATA_EDITNONE As Short = 0
	Public Const ORADATA_EDITMODE As Short = 1
	Public Const ORADATA_EDITADD As Short = 2
	
	' Field Data Types
	' These are intended to match similar constants in the
	' Visual Basic file DATACONS.TXT
	Public Const ORADB_BOOLEAN As Short = 1
	Public Const ORADB_BYTE As Short = 2
	Public Const ORADB_INTEGER As Short = 3
	Public Const ORADB_LONG As Short = 4
	Public Const ORADB_CURRENCY As Short = 5
	Public Const ORADB_SINGLE As Short = 6
	Public Const ORADB_DOUBLE As Short = 7
	Public Const ORADB_DATE As Short = 8
	Public Const ORADB_OBJECT As Short = 9
	Public Const ORADB_TEXT As Short = 10
	Public Const ORADB_LONGBINARY As Short = 11
	Public Const ORADB_MEMO As Short = 12
	
	'Parameter Types
	Public Const ORAPARM_INPUT As Short = 1
	Public Const ORAPARM_OUTPUT As Short = 2
	Public Const ORAPARM_BOTH As Short = 3
	
	'Parameter Status
	Public Const ORAPSTAT_INPUT As Integer = &H1
	Public Const ORAPSTAT_OUTPUT As Integer = &H2
	Public Const ORAPSTAT_AUTOENABLE As Integer = &H4
	Public Const ORAPSTAT_ENABLE As Integer = &H8
	
	'CreateDynaset Method Options
	Public Const ORADYN_DEFAULT As Integer = &H0
	Public Const ORADYN_NO_AUTOBIND As Integer = &H1
	Public Const ORADYN_NO_BLANKSTRIP As Integer = &H2
	Public Const ORADYN_READONLY As Integer = &H4
	Public Const ORADYN_NOCACHE As Integer = &H8
	Public Const ORADYN_ORAMODE As Integer = &H10
	Public Const ORADYN_NO_REFETCH As Integer = &H20
	Public Const ORADYN_NO_MOVEFIRST As Integer = &H40
	Public Const ORADYN_DIRTY_WRITE As Integer = &H80
	
	'OpenDatabase Method Options
	Public Const ORADB_DEFAULT As Integer = &H0
	Public Const ORADB_ORAMODE As Integer = &H1
	Public Const ORADB_NOWAIT As Integer = &H2
	Public Const ORADB_DBDEFAULT As Integer = &H4
	Public Const ORADB_DEFERRED As Integer = &H8
	Public Const ORADB_ENLIST_IN_MTS As Integer = &H10
	
	'Oracle type codes
	Public Const ORATYPE_VARCHAR2 As Short = 1
	Public Const ORATYPE_NUMBER As Short = 2
	Public Const ORATYPE_SINT As Short = 3
	Public Const ORATYPE_FLOAT As Short = 4
	Public Const ORATYPE_STRING As Short = 5
	Public Const ORATYPE_DECIMAL As Short = 7
	Public Const ORATYPE_VARCHAR As Short = 9
	Public Const ORATYPE_DATE As Short = 12
	Public Const ORATYPE_REAL As Short = 21
	Public Const ORATYPE_DOUBLE As Short = 22
	Public Const ORATYPE_UNSIGNED8 As Short = 23
	Public Const ORATYPE_UNSIGNED16 As Short = 25
	Public Const ORATYPE_UNSIGNED32 As Short = 26
	Public Const ORATYPE_SIGNED8 As Short = 27
	Public Const ORATYPE_SIGNED16 As Short = 28
	Public Const ORATYPE_SIGNED32 As Short = 29
	Public Const ORATYPE_PTR As Short = 32
	Public Const ORATYPE_OPAQUE As Short = 58
	Public Const ORATYPE_UINT As Short = 68
	Public Const ORATYPE_RAW As Short = 95
	Public Const ORATYPE_CHAR As Short = 96
	Public Const ORATYPE_CHARZ As Short = 97
	Public Const ORATYPE_CURSOR As Short = 102
	Public Const ORATYPE_ROWID As Short = 104
	Public Const ORATYPE_MLSLABEL As Short = 105
	Public Const ORATYPE_OBJECT As Short = 108
	Public Const ORATYPE_REF As Short = 110
	Public Const ORATYPE_CLOB As Short = 112
	Public Const ORATYPE_BLOB As Short = 113
	Public Const ORATYPE_BFILE As Short = 114
	Public Const ORATYPE_CFILE As Short = 115
	Public Const ORATYPE_RSLT As Short = 116
	Public Const ORATYPE_NAMEDCOLLECTION As Short = 122
	Public Const ORATYPE_COLL As Short = 122
	Public Const ORATYPE_SYSFIRST As Short = 228
	Public Const ORATYPE_SYSLAST As Short = 235
	Public Const ORATYPE_OCTET As Short = 245
	Public Const ORATYPE_SMALLINT As Short = 246
	Public Const ORATYPE_VARRAY As Short = 247
	Public Const ORATYPE_TABLE As Short = 248
	Public Const ORATYPE_OTMLAST As Short = 320
	Public Const ORATYPE_RAW_BIN As Short = 2000
	
	
	'CreateSql Method options
	Public Const ORASQL_DEFAULT As Integer = &H0
	Public Const ORASQL_NO_AUTOBIND As Integer = &H1
	Public Const ORASQL_FAILEXEC As Integer = &H2
	Public Const ORASQL_NONBLK As Integer = &H4
	
	'OraLob operation return codes
	Public Const ORALOB_SUCCESS As Short = 0
	Public Const ORALOB_NEED_DATA As Short = 99
	Public Const ORALOB_NODATA As Short = 100
	
	'OraLob Write operation chunck  modes
	Public Const ORALOB_ONE_PIECE As Short = 0
	Public Const ORALOB_FIRST_PIECE As Short = 1
	Public Const ORALOB_NEXT_PIECE As Short = 2
	Public Const ORALOB_LAST_PIECE As Short = 3
	
	'OraRef Lock operation
	Public Const ORAREF_NO_LOCK As Short = 1
	Public Const ORAREF_EXCLUSIVE_LOCK As Short = 2
	Public Const ORAREF_NOWAIT_LOCK As Short = 3
	
	'OraRef Pin operaion
	Public Const ORAREF_READ_ANY As Short = 3
	Public Const ORAREF_READ_RECENT As Short = 4
	Public Const ORAREF_READ_LATEST As Short = 5
	
	'OIP errors returned as part of the OLE Automation error.
	Public Const OERROR_ADVISEULINK As Short = 4096 ' Invalid advisory connection
	Public Const OERROR_POSITION As Short = 4098 ' Invalid database position
	Public Const OERROR_NOFIELDNAME As Short = 4099 ' Field 'field-name' not found
	Public Const OERROR_TRANSIP As Short = 4101 ' Transaction already in process
	Public Const OERROR_TRANSNIPC As Short = 4104 ' Commit detected with no active transaction
	Public Const OERROR_TRANSNIPR As Short = 4105 ' Rollback detected with no active transaction
	Public Const OERROR_NODSET As Short = 4106 ' No such set attached to connection
	Public Const OERROR_INVROWNUM As Short = 4108 ' Invalid row reference
	Public Const OERROR_TEMPFILE As Short = 4109 ' Error creating temporary file
	Public Const OERROR_DUPSESSION As Short = 4110 ' Duplicate session name
	Public Const OERROR_NOSESSION As Short = 4111 ' Session not found during detach
	Public Const OERROR_NOOBJECTN As Short = 4112 ' No such object named 'object-name'
	Public Const OERROR_DUPCONN As Short = 4113 ' Duplicate connection name
	Public Const OERROR_NOCONN As Short = 4114 ' No such connection during detach
	Public Const OERROR_BFINDEX As Short = 4115 ' Invalid field index
	Public Const OERROR_CURNREADY As Short = 4116 ' Cursor not ready for I/O
	Public Const OERROR_NOUPDATES As Short = 4117 ' Not an updatable set
	Public Const OERROR_NOTEDITING As Short = 4118 ' Attempt to update without edit or add operation
	Public Const OERROR_DATACHANGE As Short = 4119 ' Data has been modified
	Public Const OERROR_NOBUFMEM As Short = 4120 ' No memory for data transfer buffers
	Public Const OERROR_INVBKMRK As Short = 4121 ' Invalid bookmark
	Public Const OERROR_BNDVNOEN As Short = 4122 ' Bind variable not fully enabled
	Public Const OERROR_DUPPARAM As Short = 4123 ' Duplicate parameter name
	Public Const OERROR_INVARGVAL As Short = 4124 ' Invalid argument value
	Public Const OERROR_INVFLDTYPE As Short = 4125 ' Invalid field type
	Public Const OERROR_TRANSFORUP As Short = 4127 ' For Update detected with no active transaction
	Public Const OERROR_NOTUPFORUP As Short = 4128 ' For Update detected but not updatable set
	Public Const OERROR_TRANSLOCK As Short = 4129 ' Commit/Rollback with SELECT FOR UPDATE in progress
	Public Const OERROR_CACHEPARM As Short = 4130 ' Invalid cache parameter
	Public Const OERROR_FLDRQROWID As Short = 4131 ' Field processing requires ROWID
	Public Const OERROR_OUTOFMEMORY As Short = 4132 ' Internal Error
	Public Const OERROR_MAXSIZE As Short = 4135 ' Element size specified in AddTable exceeds the maximum allowed size for that variable type. See AddTable Method for more details.
	Public Const OERROR_INVDIMENSION As Short = 4136 ' Dimension specified in AddTable is invalid (i.e. negative). See AddTable Method for more details.
	Public Const OERROR_MAXBUFFER As Short = 4137 ' Buffer size for parameter array variable exceeds 32512 bytes (OCI limit).
	Public Const OERROR_ARRAYSIZ As Short = 4138 ' Dimensions of array parameters used in insert/update/delete statements are not equal.
	Public Const OERROR_ARRAYFAILP As Short = 4139 ' Error processing arrays. For details refer to OO4OERR.LOG in the windows directory.
	Public Const OERROR_CREATEPOOL As Short = 4147 ' Database Pool Already exists for this session.
	Public Const OERROR_GETDB As Short = 4148 ' Unable to obtain a free database object from the pool.
	
	Public Const OERROR_NOOBJECT As Short = 4796 'Creating Oracle object instance in client side object cache is failed
	Public Const OERROR_BINDERR As Short = 4797 'Binding  Oracle object instance to the SQL statement  is failed
	Public Const OERROR_NOATTRNAME As Short = 4798 'Getting attribute name of Oracle object instance is failed
	Public Const OERROR_NOATTRINDEX As Short = 4799 'Getting attribute index of Oracle object instance is failed
	Public Const OERROR_INVINPOBJECT As Short = 4801 'Invalid input object type for binding operation
	Public Const OERROR_BAD_INDICATOR As Short = 4802 'Fetched Oracle Object instance comes with invalid indicator structure
	Public Const OERROR_OBJINSTNULL As Short = 4803 'Operation on NULL Oracle object instance is failed. See IsNull property on OraObject
	Public Const OERROR_REFNULL As Short = 4804 'Pin Operation on NULL  Ref value is failed. See IsRefNull property on OraRef
	
	Public Const OERROR_INVPOLLPARAMS As Short = 4896 'Invalid  polling amount and chunksize specified for LOB read/write operation.
	Public Const OERROR_INVSEEKPARAMS As Short = 4897 'Invalid seek value is specified for LOB read/write operation.
	Public Const OERROR_LOBREAD As Short = 4898 'Read operation failed
	Public Const OERROR_LOBWRITE As Short = 4899 'Write operation failure
	Public Const OERROR_INVCLOBBUF As Short = 4900 'Input buffer type is not string for CLOB write operation
	Public Const OERROR_INVBLOBBUF As Short = 4901 'Input buffer type is not bytes for BLOB write operation
	Public Const OERROR_INVLOBLEN As Short = 4902 'Invalid buffer length for LOB write operation
	Public Const OERROR_NOEDIT As Short = 4903 'Write,Trim ,Append,Copy operation is allowed outside the dynaset edit
	Public Const OERROR_INVINPUTLOB As Short = 4904 'Invalid input LOB for bind operation
	Public Const OERROR_NOEDITONCLONE As Short = 4905 'Write,Trim,Append,Copy is not allowed for clone LOB object
	Public Const OERROR_LOBFILEOPEN As Short = 4906 'Specified file could not be opened in LOB operation
	Public Const OERROR_LOBFILEIOERR As Short = 4907 'File Read or Write failed in LOB Operation.
	Public Const OERROR_LOBNULL As Short = 4908 'Operation on NULL LOB has failed.
	
	Public Const OERROR_AQCREATEERR As Short = 4996 'Error creating AQ object
	Public Const OERROR_MSGCREATEERR As Short = 4997 'Error creating AQMsg object
	Public Const OERROR_PAYLOADCREATEERR As Short = 4998 ' Error creating Payload object
	Public Const OERROR_MAXAGENTS As Short = 4998 ' Maximum number of subscribers exceeded.
	Public Const OERROR_AGENTCREATEERR As Short = 5000 ' Error creating AQ Agent
	
	Public Const OERROR_COLLINSTNULL As Short = 5196 'Operation on NULL Oracle collection is  failed. See IsNull property on OraCollection
	Public Const OERROR_NOELEMENT As Short = 5197 'Element does not exist for given index
	Public Const OERROR_INVINDEX As Short = 5198 'Invalid collection index is specified
	Public Const OERROR_NODELETE As Short = 5199 'Delete operation is not supported for VARRAY collection type
	Public Const OERROR_SAFEARRINVELEM As Short = 5200 'Variant SafeArray cannot be created from the collection having non scalar element types
	
	Public Const OERROR_NULLNUMBER As Short = 5296 'Operation on NULL Oracle Number  is  failed.
	
	' meta data type, OraMetaData.type returns one of the following
	Public Const ORAMD_TABLE As Short = 1
	Public Const ORAMD_VIEW As Short = 2
	Public Const ORAMD_COLUMN As Short = 3
	Public Const ORAMD_COLUMN_LIST As Short = 4
	Public Const ORAMD_TYPE As Short = 5
	Public Const ORAMD_TYPE_ATTR As Short = 6
	Public Const ORAMD_TYPE_ATTR_LIST As Short = 7
	Public Const ORAMD_TYPE_METHOD As Short = 8
	Public Const ORAMD_TYPE_METHOD_LIST As Short = 9
	Public Const ORAMD_TYPE_ARG As Short = 10
	Public Const ORAMD_TYPE_RESULT As Short = 11
	Public Const ORAMD_PROC As Short = 12
	Public Const ORAMD_FUNC As Short = 13
	Public Const ORAMD_ARG As Short = 14
	Public Const ORAMD_ARG_LIST As Short = 15
	Public Const ORAMD_PACKAGE As Short = 16
	Public Const ORAMD_SUBPROG_LIST As Short = 17
	Public Const ORAMD_COLLECTION As Short = 18
	Public Const ORAMD_SYNONYM As Short = 19
	Public Const ORAMD_SEQENCE As Short = 20
	Public Const ORAMD_SCHEMA As Short = 21
	Public Const ORAMD_OBJECT_LIST As Short = 22
	Public Const ORAMD_SCHEMA_LIST As Short = 23
	Public Const ORAMD_DATABASE As Short = 24
	
	' AQ Options
	' AQ Visible options
	Public Const ORAAQ_ENQ_IMMEDIATE As Short = 1
	Public Const ORAAQ_ENQ_ON_COMMIT As Short = 2
	
	' AQ MessageID options
	'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
	Public Const ORAAQ_NULL_MSGID As Object = System.DBNull.Value
	
	' Selection Criteria for filtering messages
	Public Const ORAAQ_ANY As Short = 0
	Public Const ORAAQ_CONSUMER As Short = 1
	Public Const ORAAQ_MSGID As Short = 2
	
	' Locking behaviour while dequeueing messages
	Public Const ORAAQ_DQ_BROWSE As Short = 1
	Public Const ORAAQ_DQ_LOCKED As Short = 2
	Public Const ORAAQ_DQ_REMOVE As Short = 3
	
	' Message Position criteria for dequeuing
	Public Const ORAAQ_DQ_FIRST_MSG As Short = 1
	Public Const ORAAQ_DQ_NEXT_TRANS As Short = 2
	Public Const ORAAQ_DQ_NEXT_MSG As Short = 3
	
	' Wait options for a dequeue operation
	Public Const ORAAQ_DQ_WAIT_FOREVER As Short = -1
	Public Const ORAAQ_DQ_NOWAIT As Short = 0
	
	
	' Values of various OraAQMsg properties
	
	' Number of Seconds to delay a newly enqueued message
	' before it is available for dequeueing
	Public Const ORAAQ_MSG_NO_DELAY As Short = 0
	' Prioirity values for messages
	Public Const ORAAQ_MSG_PRIORITY_NORMAL As Short = 0
	Public Const ORAAQ_MSG_PRIORITY_HIGH As Short = -10
	Public Const ORAAQ_MSG_PRIORITY_LOW As Short = 10
	
	' Message Expiration in seconds
	Public Const ORAAQ_MSG_NO_EXPIRE As Short = 0
	Public Const ORAAQ_MAX_AGENTS As Short = 10
	
	'Non Blocking return values
	Public Const ORASQL_STILL_EXECUTING As Short = -3123
	Public Const ORASQL_SUCCESS As Short = 0
	'============================================================================
	
	
	'// ORACLE�ڑ��Œ���---------------------------
	Public Const ORA_MAX_PASS As String = "P"
	Public Const ORA_MAX_USR1 As String = "USR1"
	Public Const ORA_MAX_USR9 As String = "USR9"
	'// ORACLE�ް��ް��ϐ�---------------------------
	'// �_�C�i�Z�b�g���\����
	Public Structure U_Ody
		Dim Obj_Ody As Object '//OraDynaset��޼ު��
		Dim Obj_Flds() As Object '//̨���޵�޼ު��
		Dim Lng_FldCnt As Integer '//̨���ސ�
		Dim Str_FldNm As String '//�t�B�[���h�ԍ���̨���ޖ�
	End Structure
	
	'// ORACLE�ް��ް��ϐ�---------------------------
	'// USR1�p
	Public gv_Oss_USR1 As Object '//ORACLE�Z�b�V����
	Public gv_Odb_USR1 As Object '//ORACLE�f�[�^�x�[�X
	'// USR9�p
	Public gv_Oss_USR9 As Object '//ORACLE�Z�b�V����
	Public gv_Odb_USR9 As Object '//ORACLE�f�[�^�x�[�X
	
	'// ����
	Public gv_Int_OraErr As Short '//ORACLE�G���[�ԍ�
	Public gv_Str_OraErrText As String '//ORACLE�G���[�e�L�X�g
	'//----------------------------------------------
	Private mv_Bol_TranFlg As Boolean
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_USR1_Open
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�ڑ�����
	'//*                         False...�ڑ����s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//* <��  ��>
	'//*    USR1��ORACLE�ް��ް��ɐڑ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_USR1_Open() As Boolean
		
		Dim lRet As Integer
		Dim Wk As New VB6.FixedLengthString(256)
		Dim sHost As String
		Dim sUserID As String
		Dim sErrMsg As String
		Dim sErrMsg2 As String
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_USR1_Open = False
		
		'//USR1�̐ڑ����擾
		lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR1, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		If lRet > 0 Then
			sHost = LeftWid(Wk.Value, lRet)
			sHost = Trim(sHost)
			sUserID = Get_DBHEAD & "_" & ORA_MAX_USR1
			'//�ڑ�
			If F_Ora_Connect(gv_Oss_USR1, gv_Odb_USR1, sHost, sUserID, ORA_MAX_PASS) = False Then
				GoTo ERR_HANDLE
			End If
		End If
		
		'//����I��
		CF_Ora_USR1_Open = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		'//�v���O�����I��
		sErrMsg = "Ora  Error �c�a�G���[�ł��I = [CF_Ora_Open:" & sHost & ":" & Get_DBHEAD & ORA_MAX_USR1 & ":" & ORA_MAX_PASS & "]"
		sErrMsg2 = gv_Str_OraErrText
		MsgBox(sErrMsg & Chr(13) & sErrMsg2)
		Call Error_Exit(sErrMsg2)
		End
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_USR9_Open
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�ڑ�����
	'//*                         False...�ڑ����s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//* <��  ��>
	'//*    USR9��ORACLE�ް��ް��ɐڑ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060605|ACE)����       |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_USR9_Open() As Boolean
		
		Dim lRet As Integer
		Dim Wk As New VB6.FixedLengthString(256)
		Dim sHost As String
		Dim sUserID As String
		Dim sErrMsg As String
		Dim sErrMsg2 As String
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_USR9_Open = False
		
		'//USR9�̐ڑ����擾
		lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR9, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		If lRet > 0 Then
			sHost = LeftWid(Wk.Value, lRet)
			sHost = Trim(sHost)
			sUserID = Get_DBHEAD & "_" & ORA_MAX_USR9
			'//�ڑ�
			If F_Ora_Connect(gv_Oss_USR9, gv_Odb_USR9, sHost, sUserID, ORA_MAX_PASS) = False Then
				GoTo ERR_HANDLE
			End If
		End If
		
		'//����I��
		CF_Ora_USR9_Open = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		'//�v���O�����I��
		sErrMsg = "Ora  Error �c�a�G���[�ł��I = [CF_Ora_Open:" & sHost & ":" & Get_DBHEAD & ORA_MAX_USR9 & ":" & ORA_MAX_PASS & "]"
		sErrMsg2 = gv_Str_OraErrText
		MsgBox(sErrMsg & Chr(13) & sErrMsg2)
		Call Error_Exit(sErrMsg2)
		End
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    F_Ora_Connect
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�ڑ�����
	'//*                         False...�ڑ����s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Oss              Object           O            ORACLE�Z�b�V����
	'//*             pm_Odb              Object           O            ORACLE�f�[�^�x�[�X
	'//*             pm_Host             String           I            �ڑ�������
	'//*             pm_UserID           String           I            ���[�U�[ID
	'//*             pm_Password         String           I            �p�X���[�h
	'//*             pm_Option           Long             I            �ڑ��I�v�V����
	'//* <��  ��>
	'//*    �����̏���ORACLE�ް��ް��ɐڑ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Private Function F_Ora_Connect(ByRef pm_Oss As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
		
		Dim Lng_Option As Integer '//���Ұ�
		
		On Error GoTo ERR_HANDLE
		
		F_Ora_Connect = False
		
		'// ���Ұ��̐ݒ�
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pm_Option) = False Then
			Lng_Option = CInt(pm_Option)
		Else
			'//�f�t�H���g
			Lng_Option = ORADB_DEFAULT
		End If
		
		'// ���ɵ���ݍςȂ�ΐ�������
		If (pm_Oss Is Nothing) = False And (pm_Odb Is Nothing) = False Then
			F_Ora_Connect = True
			GoTo EXIT_HANDLE
		End If
		
		'// ORACLE�ް��ް��ɐڑ�
		pm_Oss = CreateObject("OracleInProcServer.XOraSession")
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Oss.dbopendatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Odb = pm_Oss.dbopendatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)
		
		'//����I��
		F_Ora_Connect = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLE�G���[�ԍ��擾
		With pm_Odb
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrReset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_DisConnect
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�ڑ���������
	'//*                         False...�ڑ��������s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Oss              Object           O            ORACLE�Z�b�V����
	'//*             pm_Odb              Object           O            ORACLE�f�[�^�x�[�X
	'//*
	'//* <��  ��>
	'//*    ORACLE�ް��ް��̐ڑ����������܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_DisConnect(ByRef pm_Oss As Object, ByRef pm_Odb As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_DisConnect = False
		
		'// �ް��ް��̸۰��
		If (pm_Odb Is Nothing) = False Then
			'UPGRADE_NOTE: �I�u�W�F�N�g pm_Odb ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			pm_Odb = Nothing
		End If
		If (pm_Oss Is Nothing) = False Then
			'UPGRADE_NOTE: �I�u�W�F�N�g pm_Oss ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			pm_Oss = Nothing
		End If
		
		'//����I��
		CF_Ora_DisConnect = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_BeginTrans
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�g�����U�N�V�����J�n����
	'//*                         False...�g�����U�N�V�����J�n���s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Oss              Object           O            ORACLE�Z�b�V����
	'//*
	'//* <��  ��>
	'//*    �g�����U�N�V�������J�n���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_BeginTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_BeginTrans = False
		
		'//��ݻ޸��݊J�n
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Oss.DbBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Oss.DbBeginTrans()
		mv_Bol_TranFlg = True
		
		'//����I��
		CF_Ora_BeginTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_CommitTrans
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�R�~�b�g����
	'//*                         False...�R�~�b�g���s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Oss              Object           O            ORACLE�Z�b�V����
	'//*
	'//* <��  ��>
	'//*    �g�����U�N�V�������R�~�b�g���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_CommitTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_CommitTrans = False
		
		'//�Я�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Oss.DbCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Oss.DbCommitTrans()
		mv_Bol_TranFlg = False
		
		'//����I��
		CF_Ora_CommitTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_RollbackTrans
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...���[���o�b�N����
	'//*                         False...���[���o�b�N���s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Oss              Object           O            ORACLE�Z�b�V����
	'//*
	'//* <��  ��>
	'//*    �g�����U�N�V���������[���o�b�N���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_RollbackTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_RollbackTrans = False
		
		'//۰��ޯ�
		If mv_Bol_TranFlg = True Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Oss.DbRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Oss.DbRollback()
			mv_Bol_TranFlg = False
		End If
		
		'//����I��
		CF_Ora_RollbackTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_BOF
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...BOF
	'//*                         False...BOF�ł͂Ȃ�
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    BOF�`�F�b�N���s���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_BOF(ByRef pm_Ody As U_Ody) As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.BOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CF_Ora_BOF = pm_Ody.Obj_Ody.BOF
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_EOF
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...EOF
	'//*                         False...EOF�ł͂Ȃ�
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    EOF�`�F�b�N���s���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_EOF(ByRef pm_Ody As U_Ody) As Boolean
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CF_Ora_EOF = pm_Ody.Obj_Ody.EOF
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_Execute
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...SQL���s����
	'//*                         False...SQL���s���s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*             pm_Odb              Object           O            ORACLE�f�[�^�x�[�X
	'//*              pm_SQL             String           I            ���sSQL
	'//*              pm_RowCnt          Long             O            ���s���R�[�h��
	'//* <��  ��>
	'//*    �X�V�n(INSERT UPDATE DELETE)��SQL�ð���Ă����s���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_Execute(ByRef pm_Odb As Object, ByVal pm_SQL As String, Optional ByRef pm_RowCnt As Integer = 0, Optional ByVal pm_LogFlg As Boolean = False) As Boolean
		
		Dim Lng_RowCnt As Integer '//���s�̖߂�l
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_Execute = False
		
		'// SQL�ð���Ă̎��s
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.ExecuteSQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Lng_RowCnt = pm_Odb.ExecuteSQL(pm_SQL)
		
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If Not IsNothing(pm_RowCnt) Then
			pm_RowCnt = Lng_RowCnt
		End If
		
		'//����I��
		CF_Ora_Execute = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLE�G���[�ԍ��擾
		With pm_Odb
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrReset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_CreateDyn
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...����I��
	'//*                         False...�ُ�I��
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Odb             Object           O            ORACLE�f�[�^�x�[�X
	'//*              pm_Ody             U_Ody            O            �ް��ް����ð��فiհ�ް��`�j
	'//*              pm_SQL             String           I            SQL�ð����
	'//*              pm_Option          Variant          I            ��߼��[�ȗ���=&0]
	'//*
	'//* <��  ��>
	'//*    �Q�ƌn(SELECT)��SQL�ð���Ă����s���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_CreateDyn(ByRef pm_Odb As Object, ByRef pm_Ody As U_Ody, ByVal pm_SQL As String, Optional ByVal pm_Option As Object = Nothing) As Boolean
		
		Dim Int_Cnt As Integer '//�t�B�[���h�J�E���^
		Dim Lng_Option As Integer '//���Ұ��iORADYN_READONLY Or ORADYN_NOCACHE�Ȃǁj
		
		On Error GoTo ERR_HANDLE
		
		'// ���Ұ��̐ݒ�
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pm_Option) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Option �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Lng_Option = CInt(pm_Option)
		Else
			Lng_Option = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
		End If
		
		'// SQL�ð���Ă̎��s
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.CreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody = pm_Odb.CreateDynaset(pm_SQL, Lng_Option)
		
		'//�\���̃f�t�H���g�l�ݒ�
		Erase pm_Ody.Obj_Flds
		pm_Ody.Lng_FldCnt = 0
		pm_Ody.Str_FldNm = ""
		
		If CF_Ora_EOF(pm_Ody) = False Then
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Ody.Lng_FldCnt = pm_Ody.Obj_Ody.Fields.count
			
			ReDim pm_Ody.Obj_Flds(pm_Ody.Lng_FldCnt - 1)
			
			For Int_Cnt = 0 To pm_Ody.Lng_FldCnt - 1
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Ody.Obj_Flds(Int_Cnt) = pm_Ody.Obj_Ody.Fields(Int_Cnt)
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Flds().Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Ody.Str_FldNm = pm_Ody.Str_FldNm & VB6.Format(Int_Cnt, "0000") & ":" & UCase(pm_Ody.Obj_Flds(Int_Cnt).Name) & ":"
			Next 
			
		End If
		
		'//����I��
		CF_Ora_CreateDyn = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLE�G���[�ԍ��擾
		With pm_Odb
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrReset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_CloseDyn
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean     True ...�������
	'//*                         False...������s
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    �����̍\���̂�۰�ދy�щ�����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_CloseDyn(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_CloseDyn = False
		
		If (pm_Ody.Obj_Ody Is Nothing) = False Then
			Erase pm_Ody.Obj_Flds
			'UPGRADE_NOTE: �I�u�W�F�N�g pm_Ody.Obj_Ody ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			pm_Ody.Obj_Ody = Nothing
		End If
		
		CF_Ora_CloseDyn = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_GetDyn
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Variant      �擾�ް��̒l
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
	'//*              pm_Fld             String           I            �擾�Ώۃt�B�[���h��
	'//*              pm_Default         Variant          I            �f�t�H���g�l
	'//*              pm_Format          String           I            �t�H�[�}�b�g�`��
	'//* <��  ��>
	'//*    pm_Ody�̎w��t�B�[���h�̒l���擾���܂��B
	'//*    pm_Fld�ɂ̓t�B�[���h���ƃt�B�[���h�ԍ��̂ǂ���ł��w��ł��܂��B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_GetDyn(ByRef pm_Ody As U_Ody, ByVal pm_Fld As String, Optional ByVal pm_Default As Object = "", Optional ByVal pm_Format As String = "") As Object
		
		Dim Str_Format As String '// ̫�ϯČ`���w��
		Dim Int_FldType As Short '// ̨��������
		Dim Var_Value As Object '// �ް�
		Dim Str_FldNm As String '// ̨���ޖ�
		Dim Var_Default As Object '// �ް���NULL�̎��̏����l
		
		On Error GoTo ERR_HANDLE
		
		'// �ް���NULL�̎��̏����l�̐ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Var_Default = pm_Default
		
		'// ̫�ϯČ`���w����Ҕ�
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If Not IsNothing(pm_Format) Then
			Str_Format = pm_Format
		Else
			Str_Format = ""
		End If
		'// �����upm_Format�v�̏����l���֐���`�Ŏw��
		
		'// ̨���ޖ��̎擾
		Str_FldNm = pm_Fld
		
		Str_FldNm = Mid(pm_Ody.Str_FldNm, InStr(pm_Ody.Str_FldNm, ":" & UCase(Str_FldNm) & ":") - 4, 4)
		
		'// ̨�������߂��ް����擾
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Flds(CInt(Str_FldNm)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Var_Value = pm_Ody.Obj_Flds(CShort(Str_FldNm))
		
		'// ���t�^�Ȃ��̫�ϯČ`����YYYY/MM/DD�ɐݒ�
		
		'// �ް��̎擾
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(Var_Value) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CF_Ora_GetDyn = Var_Default
		Else
			If Str_Format = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CF_Ora_GetDyn = Var_Value
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CF_Ora_GetDyn = VB6.Format(Var_Value, Str_Format)
			End If
		End If
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_RecordCount
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Double       �擾�ް�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g�̃��R�[�h�������擾���܂��B
	'//*    �G���[���͖߂�l��-1�ł��B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_RecordCount(ByRef pm_Ody As U_Ody) As Double
		
		Dim Lng_Cnt As Integer '//�s��
		
		On Error GoTo ERR_HANDLE
		
		Lng_Cnt = -1
		
		'//�s���̎擾
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.RecordCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Lng_Cnt = pm_Ody.Obj_Ody.RecordCount
		
		CF_Ora_RecordCount = Lng_Cnt
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MoveFirst
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g�̐擪���R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MoveFirst(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		'//�擪���R�[�h�ֈړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MoveFirst �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MoveFirst()
		
		'//����I��
		CF_Ora_MoveFirst = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MoveLast
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g�̍ŏI���R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MoveLast(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveLast = False
		
		'//�ŏI���R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MoveLast �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MoveLast()
		
		'//����I��
		CF_Ora_MoveLast = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MovePrev
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g�̂ЂƂO�̃��R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MovePrev(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MovePrev = False
		
		'//�O���R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MovePrevious �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MovePrevious()
		
		'//����I��
		CF_Ora_MovePrev = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MoveNext
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g�̂ЂƂ��̃��R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MoveNext(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveNext = False
		
		'//�����R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MoveNext()
		
		'//����I��
		CF_Ora_MoveNext = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MovePrevN
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//*              pm_Row             Long             I            �ړ��s��
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g��pm_Row�Ŏw�肵���s�����O�̃��R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MovePrevN(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MovePrevN = False
		
		'//�m�s���O���R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MovePreviousn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MovePreviousn(pm_Row)
		
		'//����I��
		CF_Ora_MovePrevN = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MoveNextN
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//*              pm_Row             Long             I            �ړ��s��
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g��pm_Row�Ŏw�肵���s�������̃��R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MoveNextN(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveNextN = False
		
		'//�m�s�������R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MoveNextn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MoveNextn(pm_Row)
		
		'//����I��
		CF_Ora_MoveNextN = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_MoveTo
	'//*
	'//* <�߂�l>     �^          ����
	'//*             Boolean      True:����I��, False:�ُ�I��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Ody             U_Ody           I/O           �ް��ް����ð��فiհ�ް��`�j
	'//*              pm_Row             Long             I            �ړ��s�ԍ�
	'//* <��  ��>
	'//*    pm_Ody�Ɋi�[����Ă���_�C�i�Z�b�g��pm_Row�Ŏw�肵���ԍ��̃��R�[�h�ֈړ����܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_MoveTo(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveTo = False
		
		'//�w�背�R�[�h�Ɉړ�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.MoveTo �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Ody.Obj_Ody.MoveTo(pm_Row)
		
		'//����I��
		CF_Ora_MoveTo = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ora_Sgl
	'//*
	'//* <�߂�l>     �^          ����
	'//*             String       �ϊ��㕶����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           Variant          I            �ϊ��O�l
	'//*
	'//* <��  ��>
	'//*    �����̃V���O���N�H�[�e�[�V����1���V���O���N�H�[�e�[�V����2�ɂ���B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020802|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ora_Sgl(ByVal pm_Value As Object) As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CF_Ora_Sgl = Replace(CStr(pm_Value), "'", "''")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ora_String
	'   �T�v�F  �e�[�u���X�V���̕�����ҏW����
	'   �����F�@pm_Value     :�Ώە�����
	'           pm_lngLen    :������
	'   �ߒl�F�@�ҏW�㕶����
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ora_String(ByVal pm_Value As String, ByVal pm_lngLen As Integer) As String
		
		Dim strRtn As String
		
		CF_Ora_String = ""
		
		strRtn = CF_Ora_Sgl(LeftWid(pm_Value & Space(pm_lngLen), pm_lngLen))
		
		CF_Ora_String = strRtn
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ora_Number
	'   �T�v�F  �e�[�u���X�V���̐��l�ҏW����
	'   �����F�@pm_Value     :�Ώە�����
	'   �ߒl�F�@�ҏW�㐔�l
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ora_Number(ByVal pm_Value As String) As Decimal
		
		Dim strRtn As String
		
		CF_Ora_Number = 0
		
		If IsNumeric(pm_Value) = False Then
			Exit Function
		End If
		
		CF_Ora_Number = CDec(pm_Value)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ora_Date
	'   �T�v�F  �e�[�u���X�V���̓��t�ҏW����
	'   �����F�@pm_Value     :�Ώە�����
	'   �ߒl�F�@�ҏW����t
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ora_Date(ByVal pm_Value As String) As String
		
		Dim strRtn As String
		
		CF_Ora_Date = Space(8)
		
		If IsDate(pm_Value) = False Then
			If IsDate(VB6.Format(pm_Value, "@@@@/@@/@@")) = False Then
				Exit Function
			Else
				CF_Ora_Date = pm_Value
			End If
		Else
			CF_Ora_Date = VB6.Format(pm_Value, "yyyymmdd")
		End If
		
	End Function
End Module