Option Strict Off
Option Explicit On
Module THSFP61_IEV
	Public Const SSS_MAX_DB As Short = 20
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	' === 20110216 === UPDATE S TOM)Morimoto
	'Global Const SSS_PrgId = "THSPR51"
	Public Const SSS_PrgId As String = "THSFP61"
	' === DB用変数及び定数
	Private Const ORA_MAX_PASS As String = "P"
	Private Const ORA_MAX_USR1 As String = "USR1"
	Public gv_Oss_USR1 As Object '//ORACLEセッション
	Public gv_Odb_USR1 As Object '//ORACLEデータベース
	Public gv_Int_OraErr As Short '//ORACLEエラー番号
	Public gv_Str_OraErrText As String '//ORACLEエラーテキスト
	
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
	
	'ＡＰＩ宣言
	Declare Function IsDBCSLeadByte Lib "kernel32" (ByVal TestChar As Byte) As Boolean
	' === 20110216 === UPDATE E
	'''' UPD 2009/12/25  FKS) T.Yamamoto    Start    連絡票№FC09122501
	'Global Const SSS_PrgNm = "取引先一覧マスタリスト        "
	'Global Const SSS_PrgNm = "取引先マスタ一覧リスト"
	'''' UPD 2009/12/25  FKS) T.Yamamoto    End
	Public Const SSS_PrgNm As String = "取引先マスタ一括抽出"
	' === 20110216 === UPDATE E
	Public Const SSS_FraId As String = "FP"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_THSCD As String
	Public WG_STTTOKCD As String
	Public WG_STTTOKNM As String
	Public WG_ENDTOKCD As String
	Public WG_ENDTOKNM As String
	
	Sub Init_Fil() 'Generated.
		'
		DBN_THSPR51 = 0
		DB_PARA(DBN_THSPR51).tblid = "THSPR51"
		DB_PARA(DBN_THSPR51).DBID = "USR9"
		SSS_MFIL = DBN_THSPR51
		'
		DBN_SYSTBA = 1
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 2
		DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 3
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 4
		DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 5
		DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 6
		DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 7
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_CLSMTA = 8
		DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 9
		DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TANMTA = 10
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 11
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_SIRMTA = 12
		DB_PARA(DBN_SIRMTA).tblid = "SIRMTA"
		DB_PARA(DBN_SIRMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 13
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_TOKMTA = 14
		DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_NHSMTA = 15
		DB_PARA(DBN_NHSMTA).tblid = "NHSMTA"
		DB_PARA(DBN_NHSMTA).DBID = "USR1"
		'
		DBN_BNKMTA = 16
		DB_PARA(DBN_BNKMTA).tblid = "BNKMTA"
		DB_PARA(DBN_BNKMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 17
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 18
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 19
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'
		' === 20110218 === DELETE S Morimoto
		'    DBN_THSPR51A = -1
		' === 20110218 === DELETE E
		SSS_LSTMFIL = DBN_THSPR51
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_OPENM(De, DB_TANMTA.TANNM)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.TANNM = RD_SSSMAIN_OPENM(De)
		DB_TANMTA.OPEID = SSS_OPEID.Value
		DB_TANMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TANMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TANMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TANMTA.WRTTM = DB_ORATM
			DB_TANMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_ENDTOKCD(De, DB_THSPR51.ENDTOKCD)
		Call DP_SSSMAIN_ENDTOKNM(De, DB_THSPR51.ENDTOKNM)
		Call DP_SSSMAIN_STTTOKCD(De, DB_THSPR51.STTTOKCD)
		Call DP_SSSMAIN_STTTOKNM(De, DB_THSPR51.STTTOKNM)
		Call DP_SSSMAIN_THSCD(De, DB_THSPR51.INPTHSCD)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_THSPR51.ENDTOKCD = RD_SSSMAIN_ENDTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_THSPR51.ENDTOKNM = RD_SSSMAIN_ENDTOKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_THSPR51.STTTOKCD = RD_SSSMAIN_STTTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_THSPR51.STTTOKNM = RD_SSSMAIN_STTTOKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_THSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_THSPR51.INPTHSCD = RD_SSSMAIN_THSCD(De)
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
	
	Sub WK_FromScr(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_OPEID = RD_SSSMAIN_OPEID(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_OPENM = RD_SSSMAIN_OPENM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_THSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_THSCD = RD_SSSMAIN_THSCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKCD = RD_SSSMAIN_STTTOKCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKNM = RD_SSSMAIN_STTTOKNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDTOKCD = RD_SSSMAIN_ENDTOKCD(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDTOKCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDTOKCD)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDTOKCD = HighValue(LenWid(WG_ENDTOKCD))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDTOKNM = RD_SSSMAIN_ENDTOKNM(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDTOKNM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDTOKNM)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDTOKNM = HighValue(LenWid(WG_ENDTOKNM))
		End If
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_THSPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_THSPR51)
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBA)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBC)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBD)
			Case DBN_SYSTBF
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBF)
			Case DBN_SYSTBG
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBG)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBH)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTA)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TANMTA)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UNYMTA)
			Case DBN_SIRMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SIRMTA)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_MEIMTA)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKMTA)
			Case DBN_NHSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_NHSMTA)
			Case DBN_BNKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_BNKMTA)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_EXCTBZ)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_GYMTBZ)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_KNGMTB)
		End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_THSPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_THSPR51 = LSet(G_LB)
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBA = LSet(G_LB)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBB = LSet(G_LB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBC = LSet(G_LB)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBD = LSet(G_LB)
			Case DBN_SYSTBF
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBF = LSet(G_LB)
			Case DBN_SYSTBG
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBG = LSet(G_LB)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBH = LSet(G_LB)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTA = LSet(G_LB)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTB = LSet(G_LB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TANMTA = LSet(G_LB)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UNYMTA = LSet(G_LB)
			Case DBN_SIRMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SIRMTA = LSet(G_LB)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_MEIMTA = LSet(G_LB)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKMTA = LSet(G_LB)
			Case DBN_NHSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_NHSMTA = LSet(G_LB)
			Case DBN_BNKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_BNKMTA = LSet(G_LB)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_EXCTBZ = LSet(G_LB)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_GYMTBZ = LSet(G_LB)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_KNGMTB = LSet(G_LB)
		End Select
	End Sub
	
	Function RecordFromObject(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		RecordFromObject = Rtc
	End Function
	
	Function ObjectFromRecord(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		ObjectFromRecord = Rtc
	End Function
	
	' === 20110217 === INSERT S TOM)Morimoto DBプロシージャ構築（ACE流用）
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
			sHost = CF_Ctr_AnsiLeftB(Wk.Value, lRet)
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
	Private Function CF_Ora_DisConnect(ByRef pm_Oss As Object, ByRef pm_Odb As Object) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Ora_DisConnect = False
		
		'// ﾃﾞｰﾀﾍﾞｰｽのｸﾛｰｽﾞ
		If (pm_Odb Is Nothing) = False Then
			'UPGRADE_NOTE: オブジェクト pm_Odb をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			pm_Odb = Nothing
		End If
		If (pm_Oss Is Nothing) = False Then
			'UPGRADE_WARNING: オブジェクト pm_Oss.Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Oss.Close()
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
	
	'データ抽出用プロシージャ
	'引数: strSQL SQL文
	'      objrst データセット(取得)
	Public Function get_select(ByVal strSQL As String, ByRef objrst As Object) As Boolean
		Dim Lng_Option As Integer
		On Error GoTo err_get_select
		Lng_Option = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.CreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		objrst = gv_Odb_USR1.CreateDynaset(strSQL, Lng_Option)
		get_select = True
		Exit Function
err_get_select: 
		
	End Function
	Public Sub DB_ORA_Close()
		CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
	End Sub
	
	' === DB為だけのプロシージャ
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiLeftB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Private Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		' --------------+---------------+---------------+---------------+---------------
		Dim lngIdx As Integer
		Dim lngStep As Integer
		Dim bytWrk() As Byte
		Dim lngLength As Integer
		' --------------+---------------+---------------+---------------+---------------
		
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() を使うためにコードがアップグレードされましたが、動作が異なる可能性があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' をクリックしてください。
		bytWrk = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pm_Value, vbFromUnicode))
		
		lngLength = 0
		
		lngIdx = LBound(bytWrk)
		Do While lngIdx <= UBound(bytWrk)
			If IsDBCSLeadByte(bytWrk(lngIdx)) = False Then
				lngStep = 1
			Else
				lngStep = 2
			End If
			lngIdx = lngIdx + lngStep
			If (lngLength + lngStep) > pm_Len Then
				Exit Do
			End If
			lngLength = lngLength + lngStep
		Loop 
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: MidB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		pm_Value = StrConv(MidB$(bytWrk, lngLength + 1), vbUnicode)
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLeftB = StrConv(LeftB$(bytWrk, lngLength), vbUnicode)
		
		Exit Function
		
	End Function
	
	
	' === 20110217 === INSERT E
End Module