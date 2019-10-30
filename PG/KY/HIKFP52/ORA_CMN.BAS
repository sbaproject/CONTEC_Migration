Attribute VB_Name = "ORA_CMN"
Option Explicit
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
Public Const ORADATA_EDITNONE = 0
Public Const ORADATA_EDITMODE = 1
Public Const ORADATA_EDITADD = 2

' Field Data Types
' These are intended to match similar constants in the
' Visual Basic file DATACONS.TXT
Public Const ORADB_BOOLEAN = 1
Public Const ORADB_BYTE = 2
Public Const ORADB_INTEGER = 3
Public Const ORADB_LONG = 4
Public Const ORADB_CURRENCY = 5
Public Const ORADB_SINGLE = 6
Public Const ORADB_DOUBLE = 7
Public Const ORADB_DATE = 8
Public Const ORADB_OBJECT = 9
Public Const ORADB_TEXT = 10
Public Const ORADB_LONGBINARY = 11
Public Const ORADB_MEMO = 12

'Parameter Types
Public Const ORAPARM_INPUT = 1
Public Const ORAPARM_OUTPUT = 2
Public Const ORAPARM_BOTH = 3

'Parameter Status
Public Const ORAPSTAT_INPUT = &H1&
Public Const ORAPSTAT_OUTPUT = &H2&
Public Const ORAPSTAT_AUTOENABLE = &H4&
Public Const ORAPSTAT_ENABLE = &H8&

'CreateDynaset Method Options
Public Const ORADYN_DEFAULT = &H0&
Public Const ORADYN_NO_AUTOBIND = &H1&
Public Const ORADYN_NO_BLANKSTRIP = &H2&
Public Const ORADYN_READONLY = &H4&
Public Const ORADYN_NOCACHE = &H8&
Public Const ORADYN_ORAMODE = &H10&
Public Const ORADYN_NO_REFETCH = &H20&
Public Const ORADYN_NO_MOVEFIRST = &H40&
Public Const ORADYN_DIRTY_WRITE = &H80&

'OpenDatabase Method Options
Public Const ORADB_DEFAULT = &H0&
Public Const ORADB_ORAMODE = &H1&
Public Const ORADB_NOWAIT = &H2&
Public Const ORADB_DBDEFAULT = &H4&
Public Const ORADB_DEFERRED = &H8&
Public Const ORADB_ENLIST_IN_MTS = &H10&

'Oracle type codes
Public Const ORATYPE_VARCHAR2 = 1
Public Const ORATYPE_NUMBER = 2
Public Const ORATYPE_SINT = 3
Public Const ORATYPE_FLOAT = 4
Public Const ORATYPE_STRING = 5
Public Const ORATYPE_DECIMAL = 7
Public Const ORATYPE_VARCHAR = 9
Public Const ORATYPE_DATE = 12
Public Const ORATYPE_REAL = 21
Public Const ORATYPE_DOUBLE = 22
Public Const ORATYPE_UNSIGNED8 = 23
Public Const ORATYPE_UNSIGNED16 = 25
Public Const ORATYPE_UNSIGNED32 = 26
Public Const ORATYPE_SIGNED8 = 27
Public Const ORATYPE_SIGNED16 = 28
Public Const ORATYPE_SIGNED32 = 29
Public Const ORATYPE_PTR = 32
Public Const ORATYPE_OPAQUE = 58
Public Const ORATYPE_UINT = 68
Public Const ORATYPE_RAW = 95
Public Const ORATYPE_CHAR = 96
Public Const ORATYPE_CHARZ = 97
Public Const ORATYPE_CURSOR = 102
Public Const ORATYPE_ROWID = 104
Public Const ORATYPE_MLSLABEL = 105
Public Const ORATYPE_OBJECT = 108
Public Const ORATYPE_REF = 110
Public Const ORATYPE_CLOB = 112
Public Const ORATYPE_BLOB = 113
Public Const ORATYPE_BFILE = 114
Public Const ORATYPE_CFILE = 115
Public Const ORATYPE_RSLT = 116
Public Const ORATYPE_NAMEDCOLLECTION = 122
Public Const ORATYPE_COLL = 122
Public Const ORATYPE_SYSFIRST = 228
Public Const ORATYPE_SYSLAST = 235
Public Const ORATYPE_OCTET = 245
Public Const ORATYPE_SMALLINT = 246
Public Const ORATYPE_VARRAY = 247
Public Const ORATYPE_TABLE = 248
Public Const ORATYPE_OTMLAST = 320
Public Const ORATYPE_RAW_BIN = 2000


'CreateSql Method options
Public Const ORASQL_DEFAULT = &H0&
Public Const ORASQL_NO_AUTOBIND = &H1&
Public Const ORASQL_FAILEXEC = &H2&
Public Const ORASQL_NONBLK = &H4&

'OraLob operation return codes
Public Const ORALOB_SUCCESS = 0
Public Const ORALOB_NEED_DATA = 99
Public Const ORALOB_NODATA = 100

'OraLob Write operation chunck  modes
Public Const ORALOB_ONE_PIECE = 0
Public Const ORALOB_FIRST_PIECE = 1
Public Const ORALOB_NEXT_PIECE = 2
Public Const ORALOB_LAST_PIECE = 3

'OraRef Lock operation
Public Const ORAREF_NO_LOCK = 1
Public Const ORAREF_EXCLUSIVE_LOCK = 2
Public Const ORAREF_NOWAIT_LOCK = 3

'OraRef Pin operaion
Public Const ORAREF_READ_ANY = 3
Public Const ORAREF_READ_RECENT = 4
Public Const ORAREF_READ_LATEST = 5

'OIP errors returned as part of the OLE Automation error.
Public Const OERROR_ADVISEULINK = 4096  ' Invalid advisory connection
Public Const OERROR_POSITION = 4098     ' Invalid database position
Public Const OERROR_NOFIELDNAME = 4099  ' Field 'field-name' not found
Public Const OERROR_TRANSIP = 4101      ' Transaction already in process
Public Const OERROR_TRANSNIPC = 4104    ' Commit detected with no active transaction
Public Const OERROR_TRANSNIPR = 4105    ' Rollback detected with no active transaction
Public Const OERROR_NODSET = 4106       ' No such set attached to connection
Public Const OERROR_INVROWNUM = 4108    ' Invalid row reference
Public Const OERROR_TEMPFILE = 4109     ' Error creating temporary file
Public Const OERROR_DUPSESSION = 4110   ' Duplicate session name
Public Const OERROR_NOSESSION = 4111    ' Session not found during detach
Public Const OERROR_NOOBJECTN = 4112    ' No such object named 'object-name'
Public Const OERROR_DUPCONN = 4113      ' Duplicate connection name
Public Const OERROR_NOCONN = 4114       ' No such connection during detach
Public Const OERROR_BFINDEX = 4115      ' Invalid field index
Public Const OERROR_CURNREADY = 4116    ' Cursor not ready for I/O
Public Const OERROR_NOUPDATES = 4117    ' Not an updatable set
Public Const OERROR_NOTEDITING = 4118   ' Attempt to update without edit or add operation
Public Const OERROR_DATACHANGE = 4119   ' Data has been modified
Public Const OERROR_NOBUFMEM = 4120     ' No memory for data transfer buffers
Public Const OERROR_INVBKMRK = 4121     ' Invalid bookmark
Public Const OERROR_BNDVNOEN = 4122     ' Bind variable not fully enabled
Public Const OERROR_DUPPARAM = 4123     ' Duplicate parameter name
Public Const OERROR_INVARGVAL = 4124    ' Invalid argument value
Public Const OERROR_INVFLDTYPE = 4125   ' Invalid field type
Public Const OERROR_TRANSFORUP = 4127   ' For Update detected with no active transaction
Public Const OERROR_NOTUPFORUP = 4128   ' For Update detected but not updatable set
Public Const OERROR_TRANSLOCK = 4129    ' Commit/Rollback with SELECT FOR UPDATE in progress
Public Const OERROR_CACHEPARM = 4130    ' Invalid cache parameter
Public Const OERROR_FLDRQROWID = 4131   ' Field processing requires ROWID
Public Const OERROR_OUTOFMEMORY = 4132  ' Internal Error
Public Const OERROR_MAXSIZE = 4135      ' Element size specified in AddTable exceeds the maximum allowed size for that variable type. See AddTable Method for more details.
Public Const OERROR_INVDIMENSION = 4136 ' Dimension specified in AddTable is invalid (i.e. negative). See AddTable Method for more details.
Public Const OERROR_MAXBUFFER = 4137    ' Buffer size for parameter array variable exceeds 32512 bytes (OCI limit).
Public Const OERROR_ARRAYSIZ = 4138     ' Dimensions of array parameters used in insert/update/delete statements are not equal.
Public Const OERROR_ARRAYFAILP = 4139   ' Error processing arrays. For details refer to OO4OERR.LOG in the windows directory.
Public Const OERROR_CREATEPOOL = 4147   ' Database Pool Already exists for this session.
Public Const OERROR_GETDB = 4148        ' Unable to obtain a free database object from the pool.

Public Const OERROR_NOOBJECT = 4796     'Creating Oracle object instance in client side object cache is failed
Public Const OERROR_BINDERR = 4797      'Binding  Oracle object instance to the SQL statement  is failed
Public Const OERROR_NOATTRNAME = 4798   'Getting attribute name of Oracle object instance is failed
Public Const OERROR_NOATTRINDEX = 4799  'Getting attribute index of Oracle object instance is failed
Public Const OERROR_INVINPOBJECT = 4801 'Invalid input object type for binding operation
Public Const OERROR_BAD_INDICATOR = 4802 'Fetched Oracle Object instance comes with invalid indicator structure
Public Const OERROR_OBJINSTNULL = 4803  'Operation on NULL Oracle object instance is failed. See IsNull property on OraObject
Public Const OERROR_REFNULL = 4804      'Pin Operation on NULL  Ref value is failed. See IsRefNull property on OraRef

Public Const OERROR_INVPOLLPARAMS = 4896 'Invalid  polling amount and chunksize specified for LOB read/write operation.
Public Const OERROR_INVSEEKPARAMS = 4897 'Invalid seek value is specified for LOB read/write operation.
Public Const OERROR_LOBREAD = 4898      'Read operation failed
Public Const OERROR_LOBWRITE = 4899     'Write operation failure
Public Const OERROR_INVCLOBBUF = 4900   'Input buffer type is not string for CLOB write operation
Public Const OERROR_INVBLOBBUF = 4901   'Input buffer type is not bytes for BLOB write operation
Public Const OERROR_INVLOBLEN = 4902    'Invalid buffer length for LOB write operation
Public Const OERROR_NOEDIT = 4903       'Write,Trim ,Append,Copy operation is allowed outside the dynaset edit
Public Const OERROR_INVINPUTLOB = 4904  'Invalid input LOB for bind operation
Public Const OERROR_NOEDITONCLONE = 4905 'Write,Trim,Append,Copy is not allowed for clone LOB object
Public Const OERROR_LOBFILEOPEN = 4906  'Specified file could not be opened in LOB operation
Public Const OERROR_LOBFILEIOERR = 4907 'File Read or Write failed in LOB Operation.
Public Const OERROR_LOBNULL = 4908    'Operation on NULL LOB has failed.

Public Const OERROR_AQCREATEERR = 4996    'Error creating AQ object
Public Const OERROR_MSGCREATEERR = 4997   'Error creating AQMsg object
Public Const OERROR_PAYLOADCREATEERR = 4998 ' Error creating Payload object
Public Const OERROR_MAXAGENTS = 4998       ' Maximum number of subscribers exceeded.
Public Const OERROR_AGENTCREATEERR = 5000  ' Error creating AQ Agent

Public Const OERROR_COLLINSTNULL = 5196 'Operation on NULL Oracle collection is  failed. See IsNull property on OraCollection
Public Const OERROR_NOELEMENT = 5197    'Element does not exist for given index
Public Const OERROR_INVINDEX = 5198     'Invalid collection index is specified
Public Const OERROR_NODELETE = 5199     'Delete operation is not supported for VARRAY collection type
Public Const OERROR_SAFEARRINVELEM = 5200  'Variant SafeArray cannot be created from the collection having non scalar element types

Public Const OERROR_NULLNUMBER = 5296   'Operation on NULL Oracle Number  is  failed.

' meta data type, OraMetaData.type returns one of the following
Public Const ORAMD_TABLE = 1
Public Const ORAMD_VIEW = 2
Public Const ORAMD_COLUMN = 3
Public Const ORAMD_COLUMN_LIST = 4
Public Const ORAMD_TYPE = 5
Public Const ORAMD_TYPE_ATTR = 6
Public Const ORAMD_TYPE_ATTR_LIST = 7
Public Const ORAMD_TYPE_METHOD = 8
Public Const ORAMD_TYPE_METHOD_LIST = 9
Public Const ORAMD_TYPE_ARG = 10
Public Const ORAMD_TYPE_RESULT = 11
Public Const ORAMD_PROC = 12
Public Const ORAMD_FUNC = 13
Public Const ORAMD_ARG = 14
Public Const ORAMD_ARG_LIST = 15
Public Const ORAMD_PACKAGE = 16
Public Const ORAMD_SUBPROG_LIST = 17
Public Const ORAMD_COLLECTION = 18
Public Const ORAMD_SYNONYM = 19
Public Const ORAMD_SEQENCE = 20
Public Const ORAMD_SCHEMA = 21
Public Const ORAMD_OBJECT_LIST = 22
Public Const ORAMD_SCHEMA_LIST = 23
Public Const ORAMD_DATABASE = 24

' AQ Options
' AQ Visible options
Public Const ORAAQ_ENQ_IMMEDIATE = 1
Public Const ORAAQ_ENQ_ON_COMMIT = 2

' AQ MessageID options
Public Const ORAAQ_NULL_MSGID = Null

' Selection Criteria for filtering messages
Public Const ORAAQ_ANY = 0
Public Const ORAAQ_CONSUMER = 1
Public Const ORAAQ_MSGID = 2

' Locking behaviour while dequeueing messages
Public Const ORAAQ_DQ_BROWSE = 1
Public Const ORAAQ_DQ_LOCKED = 2
Public Const ORAAQ_DQ_REMOVE = 3

' Message Position criteria for dequeuing
Public Const ORAAQ_DQ_FIRST_MSG = 1
Public Const ORAAQ_DQ_NEXT_TRANS = 2
Public Const ORAAQ_DQ_NEXT_MSG = 3

' Wait options for a dequeue operation
Public Const ORAAQ_DQ_WAIT_FOREVER = -1
Public Const ORAAQ_DQ_NOWAIT = 0


' Values of various OraAQMsg properties

' Number of Seconds to delay a newly enqueued message
' before it is available for dequeueing
Public Const ORAAQ_MSG_NO_DELAY = 0
' Prioirity values for messages
Public Const ORAAQ_MSG_PRIORITY_NORMAL = 0
Public Const ORAAQ_MSG_PRIORITY_HIGH = -10
Public Const ORAAQ_MSG_PRIORITY_LOW = 10

' Message Expiration in seconds
Public Const ORAAQ_MSG_NO_EXPIRE = 0
Public Const ORAAQ_MAX_AGENTS = 10

'Non Blocking return values
Public Const ORASQL_STILL_EXECUTING = -3123
Public Const ORASQL_SUCCESS = 0
'============================================================================


'// ORACLE接続固定情報---------------------------
Public Const ORA_MAX_PASS As String = "P"
Public Const ORA_MAX_USR1 As String = "USR1"
Public Const ORA_MAX_USR9 As String = "USR9"
'// ORACLEﾃﾞｰﾀﾍﾞｰｽ変数---------------------------
'// ダイナセット情報構造体
Public Type U_Ody
    Obj_Ody             As Object           '//OraDynasetｵﾌﾞｼﾞｪｸﾄ
    Obj_Flds()          As Object           '//ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ
    Lng_FldCnt          As Long             '//ﾌｨｰﾙﾄﾞ数
    Str_FldNm           As String           '//フィールド番号とﾌｨｰﾙﾄﾞ名
End Type

'// ORACLEﾃﾞｰﾀﾍﾞｰｽ変数---------------------------
'// USR1用
Public gv_Oss_USR1              As Object           '//ORACLEセッション
Public gv_Odb_USR1              As Object           '//ORACLEデータベース
'// USR9用
Public gv_Oss_USR9              As Object           '//ORACLEセッション
Public gv_Odb_USR9              As Object           '//ORACLEデータベース

'// 共通
Public gv_Int_OraErr            As Integer          '//ORACLEエラー番号
Public gv_Str_OraErrText        As String           '//ORACLEエラーテキスト
'//----------------------------------------------
Private mv_Bol_TranFlg          As Boolean

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

    Dim lRet As Long
    Dim Wk As String * 256
    Dim sHost As String
    Dim sUserID As String
    Dim sErrMsg As String
    Dim sErrMsg2 As String
    
    On Error GoTo ERR_HANDLE

    CF_Ora_USR1_Open = False

    '//USR1の接続情報取得
    lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR1, "", Wk, Len(Wk), "SSSWIN.INI")
    If lRet > 0 Then
        sHost = CF_Ctr_AnsiLeftB(Wk, lRet)
        sHost = Trim$(sHost)
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
    MsgBox sErrMsg & Chr$(13) & sErrMsg2
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

    Dim lRet As Long
    Dim Wk As String * 256
    Dim sHost As String
    Dim sUserID As String
    Dim sErrMsg As String
    Dim sErrMsg2 As String
    
    On Error GoTo ERR_HANDLE

    CF_Ora_USR9_Open = False

    '//USR9の接続情報取得
    lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR9, "", Wk, Len(Wk), "SSSWIN.INI")
    If lRet > 0 Then
        sHost = CF_Ctr_AnsiLeftB(Wk, lRet)
        sHost = Trim$(sHost)
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
    MsgBox sErrMsg & Chr$(13) & sErrMsg2
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
Private Function F_Ora_Connect(ByRef pm_Oss As Object, _
                               ByRef pm_Odb As Object, _
                               ByVal pm_Host As String, _
                               ByVal pm_UserID As String, _
                               ByVal pm_Password As String, _
                      Optional ByVal pm_Option As Long) As Boolean

    Dim Lng_Option As Long '//ﾊﾟﾗﾒｰﾀ

    On Error GoTo ERR_HANDLE

    F_Ora_Connect = False

    '// ﾊﾟﾗﾒｰﾀの設定
    If IsMissing(pm_Option) = False Then
        Lng_Option = CLng(pm_Option)
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
    Set pm_Oss = CreateObject("OracleInProcServer.XOraSession")
    Set pm_Odb = pm_Oss.dbopendatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)

    '//正常終了
    F_Ora_Connect = True

EXIT_HANDLE:
    On Error GoTo 0
    Exit Function

ERR_HANDLE:
    
    '//ORACLEエラー番号取得
    With pm_Odb
        gv_Int_OraErr = .LastServerErr
        gv_Str_OraErrText = .LastServerErrText
        .LastServerErrReset
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
Public Function CF_Ora_DisConnect(ByRef pm_Oss As Object, _
                                  ByRef pm_Odb As Object) As Boolean

    On Error GoTo ERR_HANDLE

    CF_Ora_DisConnect = False

    '// ﾃﾞｰﾀﾍﾞｰｽのｸﾛｰｽﾞ
    If (pm_Odb Is Nothing) = False Then
        Set pm_Odb = Nothing
    End If
    If (pm_Oss Is Nothing) = False Then
        Set pm_Oss = Nothing
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
    pm_Oss.DbBeginTrans
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
    pm_Oss.DbCommitTrans
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
        pm_Oss.DbRollback
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
Public Function CF_Ora_BOF(pm_Ody As U_Ody) As Boolean

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
Public Function CF_Ora_EOF(pm_Ody As U_Ody) As Boolean

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
Public Function CF_Ora_Execute(ByRef pm_Odb As Object, _
                               ByVal pm_SQL As String, _
                      Optional ByRef pm_RowCnt As Long, _
                      Optional ByVal pm_LogFlg As Boolean = False) As Boolean

    Dim Lng_RowCnt As Long  '//実行の戻り値

    On Error GoTo ERR_HANDLE
    
    CF_Ora_Execute = False
    
    '// SQLｽﾃｰﾄﾒﾝﾄの実行
    Lng_RowCnt = pm_Odb.ExecuteSQL(pm_SQL)
    
    If Not IsMissing(pm_RowCnt) Then
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
        gv_Int_OraErr = .LastServerErr
        gv_Str_OraErrText = .LastServerErrText
        .LastServerErrReset
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
Public Function CF_Ora_CreateDyn(ByRef pm_Odb As Object, _
                                 ByRef pm_Ody As U_Ody, _
                                 ByVal pm_SQL As String, _
                        Optional ByVal pm_Option As Variant) As Boolean

    Dim Int_Cnt         As Long     '//フィールドカウンタ
    Dim Lng_Option      As Long     '//ﾊﾟﾗﾒｰﾀ（ORADYN_READONLY Or ORADYN_NOCACHEなど）

    On Error GoTo ERR_HANDLE

    '// ﾊﾟﾗﾒｰﾀの設定
    If IsMissing(pm_Option) = False Then
        Lng_Option = CLng(pm_Option)
    Else
        Lng_Option = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
    End If

    '// SQLｽﾃｰﾄﾒﾝﾄの実行
    Set pm_Ody.Obj_Ody = pm_Odb.CreateDynaset(pm_SQL, Lng_Option)

    '//構造体デフォルト値設定
    Erase pm_Ody.Obj_Flds
    pm_Ody.Lng_FldCnt = 0
    pm_Ody.Str_FldNm = ""

    If CF_Ora_EOF(pm_Ody) = False Then
    
        pm_Ody.Lng_FldCnt = pm_Ody.Obj_Ody.Fields.Count
        
        ReDim pm_Ody.Obj_Flds(0 To pm_Ody.Lng_FldCnt - 1)
        
        For Int_Cnt = 0 To pm_Ody.Lng_FldCnt - 1
            Set pm_Ody.Obj_Flds(Int_Cnt) = pm_Ody.Obj_Ody.Fields(Int_Cnt)
            pm_Ody.Str_FldNm = pm_Ody.Str_FldNm & Format$(Int_Cnt, "0000") & ":" & UCase$(pm_Ody.Obj_Flds(Int_Cnt).Name) & ":"
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
        gv_Int_OraErr = .LastServerErr
        gv_Str_OraErrText = .LastServerErrText
        .LastServerErrReset
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
        Set pm_Ody.Obj_Ody = Nothing
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
Public Function CF_Ora_GetDyn(ByRef pm_Ody As U_Ody, _
                               ByVal pm_Fld As String, _
                      Optional ByVal pm_Default As Variant = "", _
                      Optional ByVal pm_Format As String = "") As Variant

    Dim Str_Format      As String   '// ﾌｫｰﾏｯﾄ形式指定
    Dim Int_FldType     As Integer  '// ﾌｨｰﾙﾄﾞﾀｲﾌﾟ
    Dim Var_Value       As Variant  '// ﾃﾞｰﾀ
    Dim Str_FldNm       As String   '// ﾌｨｰﾙﾄﾞ名
    Dim Var_Default     As Variant   '// ﾃﾞｰﾀがNULLの時の初期値

    On Error GoTo ERR_HANDLE

    '// ﾃﾞｰﾀがNULLの時の初期値の設定
    Var_Default = pm_Default
    
    '// ﾌｫｰﾏｯﾄ形式指定情報待避
    If Not IsMissing(pm_Format) Then
        Str_Format = pm_Format
    Else
        Str_Format = ""
    End If
    '// 引数「pm_Format」の初期値を関数定義で指定

    '// ﾌｨｰﾙﾄﾞ名の取得
    Str_FldNm = pm_Fld

    Str_FldNm = Mid$(pm_Ody.Str_FldNm, InStr(pm_Ody.Str_FldNm, ":" & UCase$(Str_FldNm) & ":") - 4, 4)
    
    '// ﾌｨｰﾙﾄﾞﾀｲﾌﾟとﾃﾞｰﾀを取得
    Var_Value = pm_Ody.Obj_Flds(CInt(Str_FldNm))

    '// 日付型ならばﾌｫｰﾏｯﾄ形式をYYYY/MM/DDに設定

    '// ﾃﾞｰﾀの取得
    If IsNull(Var_Value) Then
        CF_Ora_GetDyn = Var_Default
    Else
        If Str_Format = "" Then
            CF_Ora_GetDyn = Var_Value
        Else
            CF_Ora_GetDyn = Format$(Var_Value, Str_Format)
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

    Dim Lng_Cnt     As Long     '//行数

    On Error GoTo ERR_HANDLE

    Lng_Cnt = -1

    '//行数の取得
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
    pm_Ody.Obj_Ody.MoveFirst

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
    pm_Ody.Obj_Ody.MoveLast

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
    pm_Ody.Obj_Ody.MovePrevious

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
    pm_Ody.Obj_Ody.MoveNext

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
Public Function CF_Ora_MovePrevN(ByRef pm_Ody As U_Ody, _
                                  ByVal pm_Row As Long) As Boolean

    On Error GoTo ERR_HANDLE

    CF_Ora_MovePrevN = False

    '//Ｎ行分前レコードに移動
    pm_Ody.Obj_Ody.MovePreviousn pm_Row

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
Public Function CF_Ora_MoveNextN(ByRef pm_Ody As U_Ody, _
                                  ByVal pm_Row As Long) As Boolean

    On Error GoTo ERR_HANDLE

    CF_Ora_MoveNextN = False

    '//Ｎ行分次レコードに移動
    pm_Ody.Obj_Ody.MoveNextn pm_Row

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
Public Function CF_Ora_MoveTo(ByRef pm_Ody As U_Ody, _
                               ByVal pm_Row As Long) As Boolean

    On Error GoTo ERR_HANDLE

    CF_Ora_MoveTo = False

    '//指定レコードに移動
    pm_Ody.Obj_Ody.MoveTo pm_Row

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
Public Function CF_Ora_Sgl(ByVal pm_Value As Variant) As String
                      
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
Public Function CF_Ora_String(ByVal pm_Value As String, _
                               ByVal pm_lngLen As Long) As String
    
    Dim strRtn          As String
    
    CF_Ora_String = ""
    
    strRtn = CF_Ora_Sgl(CF_Ctr_AnsiLeftB(pm_Value & Space(pm_lngLen), pm_lngLen))

    CF_Ora_String = strRtn
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Ora_Number
'   概要：  テーブル更新時の数値編集処理
'   引数：　pm_Value     :対象文字列
'   戻値：　編集後数値
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ora_Number(ByVal pm_Value As String) As Currency
    
    Dim strRtn          As String
    
    CF_Ora_Number = 0
    
    If IsNumeric(pm_Value) = False Then
        Exit Function
    End If
    
    CF_Ora_Number = CCur(pm_Value)
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Ora_Date
'   概要：  テーブル更新時の日付編集処理
'   引数：　pm_Value     :対象文字列
'   戻値：　編集後日付
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Ora_Date(ByVal pm_Value As String) As String
    
    Dim strRtn          As String
    
    CF_Ora_Date = Space(8)
    
    If IsDate(pm_Value) = False Then
        If IsDate(Format(pm_Value, "@@@@/@@/@@")) = False Then
            Exit Function
        Else
            CF_Ora_Date = pm_Value
        End If
    Else
        CF_Ora_Date = Format(pm_Value, "yyyymmdd")
    End If
    
End Function

'//**************************************************************************************
'//*
'//* <名  称>
'//*    CF_Ora_USR1_Open_BAT
'//*
'//* <戻り値>     型          説明
'//*             Boolean     True ...接続成功
'//*                         False...接続失敗
'//* <引  数>     項目名             型              I/O           内容
'//* <説  明>
'//*    USR1のORACLEﾃﾞｰﾀﾍﾞｰｽに接続します。(バッチ用）
'//*
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20060807|FKS)           |新規作成
'//**************************************************************************************
Public Function CF_Ora_USR1_Open_BAT() As Boolean

    Dim lRet As Long
    Dim Wk As String * 256
    Dim sHost As String
    Dim sUserID As String
    
    On Error GoTo ERR_HANDLE

    CF_Ora_USR1_Open_BAT = False

    '//USR1の接続情報取得
    lRet = GetPrivateProfileString("DBLOC", ORA_MAX_USR1, "", Wk, Len(Wk), "SSSWIN.INI")
    If lRet > 0 Then
        sHost = CF_Ctr_AnsiLeftB(Wk, lRet)
        sHost = Trim$(sHost)
        sUserID = Get_DBHEAD & "_" & ORA_MAX_USR1
        '//接続
        If F_Ora_Connect(gv_Oss_USR1, gv_Odb_USR1, sHost, sUserID, ORA_MAX_PASS) = False Then
            GoTo ERR_HANDLE
        End If
    End If
    
    '//正常終了
    CF_Ora_USR1_Open_BAT = True

EXIT_HANDLE:
    On Error GoTo 0
    Exit Function

ERR_HANDLE:
    '//プログラム終了
End Function



