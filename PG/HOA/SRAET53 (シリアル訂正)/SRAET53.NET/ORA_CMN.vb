Option Strict Off
Option Explicit On
Module ORA_CMN
	'//* All Right Reserved Copy Right (C)  株式会社富士通関西システムズ
	'//***************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ORA_INF.bas
	'//*
	'//*＜バージョン＞
	'//* 1.00
	'//*
	'//*＜作成者＞
	'//* FKS)
	'//*
	'//*＜説明＞
	'//*    共通モジュール（ORACLE共通関数）
	'//*    ORACLEに対して処理を行う関数を記述
	'//*    ORACLEに対する処理は本モジュールの関数を使用すること。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|-------------------------------------------------
	'//* 1.00     |20021101|FKS)           |新規作成
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
	'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
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
	
	
	'// ORACLE接続固定情報---------------------------
	Public Const ORA_MAX_PASS As String = "P"
	Public Const ORA_MAX_USR1 As String = "USR1"
	Public Const ORA_MAX_USR9 As String = "USR9"
	'// ORACLEﾃﾞｰﾀﾍﾞｰｽ変数---------------------------
	'// ダイナセット情報構造体
	Public Structure U_Ody
		Dim Obj_Ody As Object '//OraDynasetｵﾌﾞｼﾞｪｸﾄ
		Dim Obj_Flds() As Object '//ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ
		Dim Lng_FldCnt As Integer '//ﾌｨｰﾙﾄﾞ数
		Dim Str_FldNm As String '//フィールド番号とﾌｨｰﾙﾄﾞ名
	End Structure
	
	'// ORACLEﾃﾞｰﾀﾍﾞｰｽ変数---------------------------
	'// USR1用
	Public gv_Oss_USR1 As Object '//ORACLEセッション
	Public gv_Odb_USR1 As Object '//ORACLEデータベース
	'// USR9用
	Public gv_Oss_USR9 As Object '//ORACLEセッション
	Public gv_Odb_USR9 As Object '//ORACLEデータベース
	
	'// 共通
	Public gv_Int_OraErr As Short '//ORACLEエラー番号
	Public gv_Str_OraErrText As String '//ORACLEエラーテキスト
	'//----------------------------------------------
	Private mv_Bol_TranFlg As Boolean
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_USR1_Open
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...接続成功
	'//*                         False...接続失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//* <説  明>
	'//*    USR1のORACLEﾃﾞｰﾀﾍﾞｰｽに接続します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
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
		
		'//USR1の接続情報取得
		lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR1, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		If lRet > 0 Then
			sHost = LeftWid(Wk.Value, lRet)
			sHost = Trim(sHost)
			sUserID = Get_DBHEAD & "_" & ORA_MAX_USR1
			'//接続
			If F_Ora_Connect(gv_Oss_USR1, gv_Odb_USR1, sHost, sUserID, ORA_MAX_PASS) = False Then
				GoTo ERR_HANDLE
			End If
		End If
		
		'//正常終了
		CF_Ora_USR1_Open = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		'//プログラム終了
		sErrMsg = "Ora  Error ＤＢエラーです！ = [CF_Ora_Open:" & sHost & ":" & Get_DBHEAD & ORA_MAX_USR1 & ":" & ORA_MAX_PASS & "]"
		sErrMsg2 = gv_Str_OraErrText
		MsgBox(sErrMsg & Chr(13) & sErrMsg2)
		Call Error_Exit(sErrMsg2)
		End
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_USR9_Open
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...接続成功
	'//*                         False...接続失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//* <説  明>
	'//*    USR9のORACLEﾃﾞｰﾀﾍﾞｰｽに接続します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060605|ACE)糸島       |新規作成
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
		
		'//USR9の接続情報取得
		lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR9, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		If lRet > 0 Then
			sHost = LeftWid(Wk.Value, lRet)
			sHost = Trim(sHost)
			sUserID = Get_DBHEAD & "_" & ORA_MAX_USR9
			'//接続
			If F_Ora_Connect(gv_Oss_USR9, gv_Odb_USR9, sHost, sUserID, ORA_MAX_PASS) = False Then
				GoTo ERR_HANDLE
			End If
		End If
		
		'//正常終了
		CF_Ora_USR9_Open = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		'//プログラム終了
		sErrMsg = "Ora  Error ＤＢエラーです！ = [CF_Ora_Open:" & sHost & ":" & Get_DBHEAD & ORA_MAX_USR9 & ":" & ORA_MAX_PASS & "]"
		sErrMsg2 = gv_Str_OraErrText
		MsgBox(sErrMsg & Chr(13) & sErrMsg2)
		Call Error_Exit(sErrMsg2)
		End
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    F_Ora_Connect
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...接続成功
	'//*                         False...接続失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Oss              Object           O            ORACLEセッション
	'//*             pm_Odb              Object           O            ORACLEデータベース
	'//*             pm_Host             String           I            接続文字列
	'//*             pm_UserID           String           I            ユーザーID
	'//*             pm_Password         String           I            パスワード
	'//*             pm_Option           Long             I            接続オプション
	'//* <説  明>
	'//*    引数の情報でORACLEﾃﾞｰﾀﾍﾞｰｽに接続します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Private Function F_Ora_Connect(ByRef pm_Oss As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
		
		Dim Lng_Option As Integer '//ﾊﾟﾗﾒｰﾀ
		
		On Error GoTo ERR_HANDLE
		
		F_Ora_Connect = False
		
		'// ﾊﾟﾗﾒｰﾀの設定
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(pm_Option) = False Then
			Lng_Option = CInt(pm_Option)
		Else
			'//デフォルト
			Lng_Option = ORADB_DEFAULT
		End If
		
		'// 既にｵｰﾌﾟﾝ済ならば正常ﾘﾀｰﾝ
		If (pm_Oss Is Nothing) = False And (pm_Odb Is Nothing) = False Then
			F_Ora_Connect = True
			GoTo EXIT_HANDLE
		End If
		
		'// ORACLEﾃﾞｰﾀﾍﾞｰｽに接続
		pm_Oss = CreateObject("OracleInProcServer.XOraSession")
		'UPGRADE_WARNING: オブジェクト pm_Oss.dbopendatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Odb = pm_Oss.dbopendatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)
		
		'//正常終了
		F_Ora_Connect = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLEエラー番号取得
		With pm_Odb
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrReset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_DisConnect
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...接続解除成功
	'//*                         False...接続解除失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Oss              Object           O            ORACLEセッション
	'//*             pm_Odb              Object           O            ORACLEデータベース
	'//*
	'//* <説  明>
	'//*    ORACLEﾃﾞｰﾀﾍﾞｰｽの接続を解除します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_DisConnect(ByRef pm_Oss As Object, ByRef pm_Odb As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_DisConnect = False
		
		'// ﾃﾞｰﾀﾍﾞｰｽのｸﾛｰｽﾞ
		If (pm_Odb Is Nothing) = False Then
			'UPGRADE_NOTE: オブジェクト pm_Odb をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			pm_Odb = Nothing
		End If
		If (pm_Oss Is Nothing) = False Then
			'UPGRADE_NOTE: オブジェクト pm_Oss をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			pm_Oss = Nothing
		End If
		
		'//正常終了
		CF_Ora_DisConnect = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_BeginTrans
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...トランザクション開始成功
	'//*                         False...トランザクション開始失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Oss              Object           O            ORACLEセッション
	'//*
	'//* <説  明>
	'//*    トランザクションを開始します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_BeginTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_BeginTrans = False
		
		'//ﾄﾗﾝｻﾞｸｼｮﾝ開始
		'UPGRADE_WARNING: オブジェクト pm_Oss.DbBeginTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Oss.DbBeginTrans()
		mv_Bol_TranFlg = True
		
		'//正常終了
		CF_Ora_BeginTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_CommitTrans
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...コミット成功
	'//*                         False...コミット失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Oss              Object           O            ORACLEセッション
	'//*
	'//* <説  明>
	'//*    トランザクションをコミットします。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_CommitTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_CommitTrans = False
		
		'//ｺﾐｯﾄ
		'UPGRADE_WARNING: オブジェクト pm_Oss.DbCommitTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Oss.DbCommitTrans()
		mv_Bol_TranFlg = False
		
		'//正常終了
		CF_Ora_CommitTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_RollbackTrans
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...ロールバック成功
	'//*                         False...ロールバック失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Oss              Object           O            ORACLEセッション
	'//*
	'//* <説  明>
	'//*    トランザクションをロールバックします。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_RollbackTrans(ByRef pm_Oss As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_RollbackTrans = False
		
		'//ﾛｰﾙﾊﾞｯｸ
		If mv_Bol_TranFlg = True Then
			'UPGRADE_WARNING: オブジェクト pm_Oss.DbRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Oss.DbRollback()
			mv_Bol_TranFlg = False
		End If
		
		'//正常終了
		CF_Ora_RollbackTrans = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_BOF
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...BOF
	'//*                         False...BOFではない
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody            I            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    BOFチェックを行います。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_BOF(ByRef pm_Ody As U_Ody) As Boolean
		
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.BOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Ora_BOF = pm_Ody.Obj_Ody.BOF
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_EOF
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...EOF
	'//*                         False...EOFではない
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody            I            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    EOFチェックを行います。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_EOF(ByRef pm_Ody As U_Ody) As Boolean
		
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.EOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Ora_EOF = pm_Ody.Obj_Ody.EOF
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_Execute
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...SQL実行成功
	'//*                         False...SQL実行失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*             pm_Odb              Object           O            ORACLEデータベース
	'//*              pm_SQL             String           I            実行SQL
	'//*              pm_RowCnt          Long             O            実行レコード数
	'//* <説  明>
	'//*    更新系(INSERT UPDATE DELETE)のSQLｽﾃｰﾄﾒﾝﾄを実行します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_Execute(ByRef pm_Odb As Object, ByVal pm_SQL As String, Optional ByRef pm_RowCnt As Integer = 0, Optional ByVal pm_LogFlg As Boolean = False) As Boolean
		
		Dim Lng_RowCnt As Integer '//実行の戻り値
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_Execute = False
		
		'// SQLｽﾃｰﾄﾒﾝﾄの実行
		'UPGRADE_WARNING: オブジェクト pm_Odb.ExecuteSQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Lng_RowCnt = pm_Odb.ExecuteSQL(pm_SQL)
		
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(pm_RowCnt) Then
			pm_RowCnt = Lng_RowCnt
		End If
		
		'//正常終了
		CF_Ora_Execute = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLEエラー番号取得
		With pm_Odb
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrReset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_CreateDyn
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...正常終了
	'//*                         False...異常終了
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Odb             Object           O            ORACLEデータベース
	'//*              pm_Ody             U_Ody            O            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//*              pm_SQL             String           I            SQLｽﾃｰﾄﾒﾝﾄ
	'//*              pm_Option          Variant          I            ｵﾌﾟｼｮﾝ[省略化=&0]
	'//*
	'//* <説  明>
	'//*    参照系(SELECT)のSQLｽﾃｰﾄﾒﾝﾄを実行します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_CreateDyn(ByRef pm_Odb As Object, ByRef pm_Ody As U_Ody, ByVal pm_SQL As String, Optional ByVal pm_Option As Object = Nothing) As Boolean
		
		Dim Int_Cnt As Integer '//フィールドカウンタ
		Dim Lng_Option As Integer '//ﾊﾟﾗﾒｰﾀ（ORADYN_READONLY Or ORADYN_NOCACHEなど）
		
		On Error GoTo ERR_HANDLE
		
		'// ﾊﾟﾗﾒｰﾀの設定
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(pm_Option) = False Then
			'UPGRADE_WARNING: オブジェクト pm_Option の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Lng_Option = CInt(pm_Option)
		Else
			Lng_Option = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
		End If
		
		'// SQLｽﾃｰﾄﾒﾝﾄの実行
		'UPGRADE_WARNING: オブジェクト pm_Odb.CreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody = pm_Odb.CreateDynaset(pm_SQL, Lng_Option)
		
		'//構造体デフォルト値設定
		Erase pm_Ody.Obj_Flds
		pm_Ody.Lng_FldCnt = 0
		pm_Ody.Str_FldNm = ""
		
		If CF_Ora_EOF(pm_Ody) = False Then
			
			'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Ody.Lng_FldCnt = pm_Ody.Obj_Ody.Fields.count
			
			ReDim pm_Ody.Obj_Flds(pm_Ody.Lng_FldCnt - 1)
			
			For Int_Cnt = 0 To pm_Ody.Lng_FldCnt - 1
				'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Ody.Obj_Flds(Int_Cnt) = pm_Ody.Obj_Ody.Fields(Int_Cnt)
				'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Flds().Name の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Ody.Str_FldNm = pm_Ody.Str_FldNm & VB6.Format(Int_Cnt, "0000") & ":" & UCase(pm_Ody.Obj_Flds(Int_Cnt).Name) & ":"
			Next 
			
		End If
		
		'//正常終了
		CF_Ora_CreateDyn = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		
		'//ORACLEエラー番号取得
		With pm_Odb
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Int_OraErr = .LastServerErr
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			gv_Str_OraErrText = .LastServerErrText
			'UPGRADE_WARNING: オブジェクト pm_Odb.LastServerErrReset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.LastServerErrReset()
		End With
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_CloseDyn
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean     True ...解放成功
	'//*                         False...解放失敗
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    引数の構造体をｸﾛｰｽﾞ及び解放します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_CloseDyn(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_CloseDyn = False
		
		If (pm_Ody.Obj_Ody Is Nothing) = False Then
			Erase pm_Ody.Obj_Flds
			'UPGRADE_NOTE: オブジェクト pm_Ody.Obj_Ody をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
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
	'//* <名  称>
	'//*    CF_Ora_GetDyn
	'//*
	'//* <戻り値>     型          説明
	'//*             Variant      取得ﾃﾞｰﾀの値
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody            I            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//*              pm_Fld             String           I            取得対象フィールド名
	'//*              pm_Default         Variant          I            デフォルト値
	'//*              pm_Format          String           I            フォーマット形式
	'//* <説  明>
	'//*    pm_Odyの指定フィールドの値を取得します。
	'//*    pm_Fldにはフィールド名とフィールド番号のどちらでも指定できます。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_GetDyn(ByRef pm_Ody As U_Ody, ByVal pm_Fld As String, Optional ByVal pm_Default As Object = "", Optional ByVal pm_Format As String = "") As Object
		
		Dim Str_Format As String '// ﾌｫｰﾏｯﾄ形式指定
		Dim Int_FldType As Short '// ﾌｨｰﾙﾄﾞﾀｲﾌﾟ
		Dim Var_Value As Object '// ﾃﾞｰﾀ
		Dim Str_FldNm As String '// ﾌｨｰﾙﾄﾞ名
		Dim Var_Default As Object '// ﾃﾞｰﾀがNULLの時の初期値
		
		On Error GoTo ERR_HANDLE
		
		'// ﾃﾞｰﾀがNULLの時の初期値の設定
		'UPGRADE_WARNING: オブジェクト pm_Default の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Var_Default の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Var_Default = pm_Default
		
		'// ﾌｫｰﾏｯﾄ形式指定情報待避
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(pm_Format) Then
			Str_Format = pm_Format
		Else
			Str_Format = ""
		End If
		'// 引数「pm_Format」の初期値を関数定義で指定
		
		'// ﾌｨｰﾙﾄﾞ名の取得
		Str_FldNm = pm_Fld
		
		Str_FldNm = Mid(pm_Ody.Str_FldNm, InStr(pm_Ody.Str_FldNm, ":" & UCase(Str_FldNm) & ":") - 4, 4)
		
		'// ﾌｨｰﾙﾄﾞﾀｲﾌﾟとﾃﾞｰﾀを取得
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Flds(CInt(Str_FldNm)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Var_Value = pm_Ody.Obj_Flds(CShort(Str_FldNm))
		
		'// 日付型ならばﾌｫｰﾏｯﾄ形式をYYYY/MM/DDに設定
		
		'// ﾃﾞｰﾀの取得
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(Var_Value) Then
			'UPGRADE_WARNING: オブジェクト Var_Default の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CF_Ora_GetDyn = Var_Default
		Else
			If Str_Format = "" Then
				'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CF_Ora_GetDyn = Var_Value
			Else
				'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	'//* <名  称>
	'//*    CF_Ora_RecordCount
	'//*
	'//* <戻り値>     型          説明
	'//*             Double       取得ﾃﾞｰﾀ件数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody            I            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのレコード件数を取得します。
	'//*    エラー時は戻り値が-1です。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_RecordCount(ByRef pm_Ody As U_Ody) As Double
		
		Dim Lng_Cnt As Integer '//行数
		
		On Error GoTo ERR_HANDLE
		
		Lng_Cnt = -1
		
		'//行数の取得
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.RecordCount の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	'//* <名  称>
	'//*    CF_Ora_MoveFirst
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットの先頭レコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MoveFirst(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		'//先頭レコードへ移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MoveFirst の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MoveFirst()
		
		'//正常終了
		CF_Ora_MoveFirst = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MoveLast
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットの最終レコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MoveLast(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveLast = False
		
		'//最終レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MoveLast の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MoveLast()
		
		'//正常終了
		CF_Ora_MoveLast = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MovePrev
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのひとつ前のレコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MovePrev(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MovePrev = False
		
		'//前レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MovePrevious の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MovePrevious()
		
		'//正常終了
		CF_Ora_MovePrev = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MoveNext
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのひとつ次のレコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MoveNext(ByRef pm_Ody As U_Ody) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveNext = False
		
		'//次レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MoveNext()
		
		'//正常終了
		CF_Ora_MoveNext = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MovePrevN
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//*              pm_Row             Long             I            移動行数
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのpm_Rowで指定した行数分前のレコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MovePrevN(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MovePrevN = False
		
		'//Ｎ行分前レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MovePreviousn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MovePreviousn(pm_Row)
		
		'//正常終了
		CF_Ora_MovePrevN = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MoveNextN
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//*              pm_Row             Long             I            移動行数
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのpm_Rowで指定した行数分次のレコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MoveNextN(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveNextN = False
		
		'//Ｎ行分次レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MoveNextn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MoveNextn(pm_Row)
		
		'//正常終了
		CF_Ora_MoveNextN = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_MoveTo
	'//*
	'//* <戻り値>     型          説明
	'//*             Boolean      True:正常終了, False:異常終了
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
	'//*              pm_Row             Long             I            移動行番号
	'//* <説  明>
	'//*    pm_Odyに格納されているダイナセットのpm_Rowで指定した番号のレコードへ移動します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_MoveTo(ByRef pm_Ody As U_Ody, ByVal pm_Row As Integer) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_MoveTo = False
		
		'//指定レコードに移動
		'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Ody.MoveTo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Ody.Obj_Ody.MoveTo(pm_Row)
		
		'//正常終了
		CF_Ora_MoveTo = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//**************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ora_Sgl
	'//*
	'//* <戻り値>     型          説明
	'//*             String       変換後文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           Variant          I            変換前値
	'//*
	'//* <説  明>
	'//*    引数のシングルクォーテーション1つをシングルクォーテーション2つにする。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020802|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ora_Sgl(ByVal pm_Value As Object) As String
		
		'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CF_Ora_Sgl = Replace(CStr(pm_Value), "'", "''")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ora_String
	'   概要：  テーブル更新時の文字列編集処理
	'   引数：　pm_Value     :対象文字列
	'           pm_lngLen    :文字列長
	'   戻値：　編集後文字列
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ora_String(ByVal pm_Value As String, ByVal pm_lngLen As Integer) As String
		
		Dim strRtn As String
		
		CF_Ora_String = ""
		
		strRtn = CF_Ora_Sgl(LeftWid(pm_Value & Space(pm_lngLen), pm_lngLen))
		
		CF_Ora_String = strRtn
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ora_Number
	'   概要：  テーブル更新時の数値編集処理
	'   引数：　pm_Value     :対象文字列
	'   戻値：　編集後数値
	'   備考：
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
	'   名称：  Function CF_Ora_Date
	'   概要：  テーブル更新時の日付編集処理
	'   引数：　pm_Value     :対象文字列
	'   戻値：　編集後日付
	'   備考：
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