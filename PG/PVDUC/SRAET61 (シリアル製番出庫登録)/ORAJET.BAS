Attribute VB_Name = "BasOraJet"
Option Explicit
'
' ------------------------------------------------------------------
' 必ず SSSORAIF.DLL のバージョン(前3桁)と合わせる事！
Global Const sBAS_VER$ = "3.0.1.26" '2003.08.28A
' ------------------------------------------------------------------
'
'以下２行は SSSWIN.BAS で宣言しているため不要
'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
'Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Any, ByVal lpFileName As String) As Long
'以下は 16bit API
'Declare Function GetPrivateProfileString Lib "Kernel" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
'Declare Function WritePrivateProfileString Lib "Kernel" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As String, ByVal lpFileName As String) As Integer

'Declare Function GETPTR Lib "sssbtrif.DLL" (DataBuf As Any) As Long
'
''Start: Delare Export Functions in sssoraif.dll
'' Getting Data
Declare Function Dll_GetFirst Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetNext Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ExtNum As Any) As Long
Declare Function Dll_GetPre Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ExtNum As Any) As Long
Declare Function Dll_GetLast Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetEq Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetGrEq Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetGr Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetLs Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetLsEq Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$, ByVal LockFlg&, ByVal sFields$, ExtNum As Any) As Long
Declare Function Dll_GetSQL Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal sqlStmt$, ExtNum As Any) As Long
Declare Function Dll_Execute Lib "sssoraif" (ByVal Fno&, ByVal sqlStmt$) As Long

'' Deleting , Inserting and Updating Data
Declare Function Dll_Delete Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long
Declare Function Dll_Insert Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$) As Long
Declare Function Dll_Update Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal keyVal$) As Long

'' Others
Declare Function Dll_Stat Lib "sssoraif" (ByVal Fno&, ByRef xxx&) As Long
Declare Function Dll_Start Lib "sssoraif" (ByVal sCon$, ByVal sHead$) As Long
Declare Function Dll_ChkVer Lib "sssoraif" (ByVal sVer$) As Long
Declare Function Dll_RESET Lib "sssoraif" () As Long
Declare Function Dll_Stop Lib "sssoraif" () As Long
Declare Function Dll_Open Lib "sssoraif" (ByVal Fno&, ByVal DBID$, ByVal tblid$) As Long
Declare Function Dll_Close Lib "sssoraif" (ByVal Fno&) As Long
Declare Function Dll_Can Lib "sssoraif" (ByVal Fno&) As Long
Declare Function Dll_End Lib "sssoraif" () As Long
Declare Function Dll_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
Declare Function Dll_AbortTransaction Lib "sssoraif" () As Long
Declare Function Dll_EndTransaction Lib "sssoraif" () As Long
Declare Function Dll_Usr1Exec Lib "sssoraif" (ByVal pSql$) As Long
Declare Function Dll_TpaLock Lib "sssoraif" (ByVal pSql$, ByRef nProc&) As Long
Declare Function Dll_TpaIns Lib "sssoraif" (ByVal pSql$, ByRef nProc&, ByVal sOP$, ByVal sCL$, ByVal sTM$, ByVal sDT$) As Long
Declare Function Dll_GetPassWD Lib "sssoraif" (ByVal nUsrNo&, ByVal passWD$) As Long
Declare Function Dll_ChgMode Lib "sssoraif" (ByVal sMode$) As Long
Declare Function Dll_ClrMode Lib "sssoraif" () As Long
Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno&, ByVal sDT$, ByVal sTM$) As Long
Declare Function Dll_SetPGID Lib "sssoraif" (ByVal sPrgId$) As Long

'' Calling Interface for PL/SQL
Declare Function Dll_PlStart Lib "sssoraif" (pPl_Info As Any, ByVal bGetRec As Long) As Long
Declare Function Dll_PlFree Lib "sssoraif" () As Long
Declare Function Dll_PlSet Lib "sssoraif" (ByVal Fno&, ByVal RNo&, pBuff As Any) As Long
Declare Function Dll_PlCndSet Lib "sssoraif" (pBuff As Any) As Long
Declare Function Dll_PlExec Lib "sssoraif" (ByVal pSql$, pBuff As Any) As Long
Declare Function Dll_PlGetCnt Lib "sssoraif" (ByVal Fno&) As Long
Declare Function Dll_PlGet Lib "sssoraif" (ByVal Fno&, pBuff As Any, ByVal RNo&) As Long

'' Nop inside
Declare Function Dll_ErrorCheck Lib "sssoraif" (ByVal opCode%, tblName As Any) As Long
Declare Function Dll_NCCLOSE Lib "sssoraif" (ByVal Fno&) As Long
Declare Function Dll_NCOPEN Lib "sssoraif" (ByVal Fno&, FileLocation As Any, DBFLocation As Any) As Long
Declare Function Dll_Unlock Lib "sssoraif" (ByVal Fno&) As Long

'' Exception (Header with "DB_")
Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long

Declare Function sOraErrMsg Lib "sssoraif" (ByVal nErr&, ByVal sMsg$) As Long

Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

''End: Declare

Private WRK_PATH As String
Private USR2     As String

Private Section As String
Private Entry As String
Private IniFileName As String
Private USR_PATH$
Private EXT_PATH$

Private DB_StTime

Global Const DB_Err_Busy = 999

Type TYPE_DB_PARA
    RecLength As Integer
    KeyBuf As String * 256
    KeyNo As Integer
    tblid As String          'テーブル名
    Status As Integer
    DBID As String * 8
    DBNo As Integer
    nDirection As Integer
End Type

Type TYPE_KeySeg
    KeyName As String * 12
    ItmCnt As Integer
    'ItmName(9) As String * 8
    'bKb(9)   As Integer
    ItmLen(9)  As Integer
    ItmPos(9)  As Integer
End Type

Type TYPE_KeyIndex
    tblName As String * 8
    KeyCnt    As Integer
    Seg(9) As TYPE_KeySeg
End Type

Public Const RecNoLock = 0              ' 汎用 レコードロックパラメータ
Public Const RecLock = -1               '    上に同じ

'旧インターフェイス
Global Const NCCNo = -1                 ' No-Currency-Change オプション値
Global Const BtrNormal = 0              ' Btrieve レコードロックパラメータ
Global Const BtrLock = -1               '    上に同じ
Global Const AppLock = 777              ' アプリによるロックチェック用
Global BtrMaxReTryCnt As Integer        ' 最大リトライ回数
Global BtrRetry As Integer              ' リトライ回数カウント変数
Global DBSTAT As Long                   ' ファイルステータス
Global Const BTR_Exclude% = 0
Global Const BTR_Share% = 1000
Private DB_MAXWAITSEC%, DB_APPWAITSEC%, DB_REALWAITSEC@
'

'Type TYPE_DB_PARA
'    PosBlk As String * 129
'    RecLength As Integer
'    KeyBuf As String * 256
'    KeyNo As Integer
'    RecPointer As Long       'レコード構造体のポインタ
'    TblId As String          'テーブル名
'    DBFLocation As String
'    Status As Integer
'End Type

Public Const dbsMAX = 25
Public Const rstMAX = 200
'Public Const SSS_MAX_DB = dbsMAX '???????????

Private DicPath As String

'Type TYPE_DB_SPEC
'    sID     As String
'    sLoc    As String
'    bOra    As Integer
'    bReged  As Integer
'    bLogin  As Integer
'    Jet_DB  As Database
'End Type
'Private DB_Spec(dbsMAX) As TYPE_DB_SPEC

'Public Jet_WS As Workspace ' ワークスペース
'Public Jet_DB(dbsMAX) As Database
'Public DbOpened(dbsMAX) As Integer  '
'Public JET_RS(rstMAX) As Recordset
'Private bOracle(rstMAX) As Integer  ' 変数を宣言します。
Public RsOpened(rstMAX) As Integer  '
Public KeyIndex(rstMAX) As TYPE_KeyIndex  '  Index定義
'Public Jet_Td As TableDef
Public Jet_SQL$
Public G_Fld(rstMAX, 200) As Object
Private G_FNO%
Private ret%
Private G_NO_ALTLOG%
Public Const SSS_NO_ALTOUT = -9999

Private NoCheck%
Public Const Jet_NoErr = 0
Public Const Jet_OpnErr = -1
Public Const Jet_NoMAtch = -8
Public Const Jet_EOF = -9
Public Const Jet_BOF = -10

Public Const Cn_NoCommit = -9999 'PL/SQLでコミットしない

Type T_G_LB
    tgLB1(16 * 1024) As Byte
    tgLB2(4 * 1024) As Byte 'Pre=16
    'tgLB3(4 * 1024) As Byte
End Type
Global G_LB As T_G_LB

Type T_PlInfo
    FCnt As Long
    Fno(9) As Long
    RCnt(9) As Long
    ArrayFlg(9) As Long ' 非0 = Array, 0 = スカラ型
    RMax(9) As Long
End Type
Global G_PlInfo As T_PlInfo

Global Const MAX_CNDARR = 14 'Pre=10/Lim=19
Type T_PlCnd
    nJobMode As Long
    sCndStr(MAX_CNDARR - 1) As String * 512
    nCndNum(MAX_CNDARR - 1) As Currency
    sOpeID As String * 8
    sCltID As String * 5
    sErrMsg As String * 512
End Type
Global G_PlCnd As T_PlCnd
Global G_PlCnd2 As T_PlCnd
Private G_bExtCnd As Boolean

Global Const nDir_None = 0
Global Const nDir_Fore = 1
Global Const nDir_Back = 2

Type KeySpec
    KeyPos          As Integer
    KeyLen          As Integer
    KeyFlags        As Integer
    KeyTot          As Long
    KeyType         As String * 1
    Reserved        As String * 5
End Type

Type TYPE_StatFileSpecs
     RecLen         As Integer
     PageSize       As Integer
     IndexTot       As Integer
     RecTot         As Long
     FileFlags      As Integer
     Reserved       As String * 2
     UnusedPages    As Integer
     KeyBuf(119)     As KeySpec
End Type

Global StatFileBuffer As TYPE_StatFileSpecs

Type TYPE_DB_EXTRA_NUM
    ExtNum(9)       As Currency
End Type
Global DB_ExtNum As TYPE_DB_EXTRA_NUM

Global DB_SQLBUFF As String
Public DB_ORADT As String
Public DB_ORATM As String
Private Const Ora_Connect$ = "_USR1/P"
Private Ora_DBName$, Ora_DBHead$, Ora_Connect1$
Private Ora_DBStart_FLG As Integer
Private StTime@, EnTime@, CurTime@
Private G_sRRRLock As String
Private G_sRRRLock2 As String
Private G_sRRRLock3 As String
Private G_RetryItv As Long
Private G_sFields As String
Private nErr As Long
Private G_sUNIID$
Private G_nUNICNT&
Private G_sPRGID$
Private G_sPRGNM$
Private G_sOPEID$
Private G_sCLTID$
Private G_sErrMsg$
Private G_bRetApp As Boolean
Private G_bORA_RPS As Boolean
Private G_bORA_RPS_EXT As Boolean
Private G_bUSR1_ON As Boolean
Private G_bSUP_ERR As Boolean
Private G_bBusyLog As Boolean
Private G_bTranLog As Boolean
Private G_nTranStt@
Private TRAN_LOG_PATH$
Private G_tmSTT$
Private Const nSecOfDay# = 24 * 3600#
Private G_bTool As Boolean

'Private Sub ResetExtNum()
'    Dim I%
'    With DB_ExtNum
'        For I% = 0 To 9: .ExtNum(I%) = 0: Next I%
'    End With
'End Sub
'
''Public Sub JB_AbortTransaction()
''    On Error Resume Next
''    Err.Clear
''    DBSTAT = 0
''    If IsNull(Jet_WS) Then Return
''    Jet_WS.Rollback
''    DBSTAT = Err
''    Call JB_ErrorCheck("AbortTransaction", 0)
''End Sub
'
'' エラー汎用ルーチン
'Sub DB_ErrorCheck(opCode As String, Fno As Integer) 'TblName As String)
'    If IS_ORA(Fno, True) Then
'        Call Ora_ErrorCheck(opCode, Fno)
'    Else
'        Call JB_ErrorCheck(opCode, Fno)
'    End If
'End Sub
'
''Sub DB_MsgBox(Msg$)
''    On Error Resume Next
''    Err.Clear
''    If IsNull(Jet_WS) = False Then Jet_WS.Rollback
''    Err.Clear
''    'Call DB_LockOff2
''    DBSTAT = Dll_AbortTransaction
''    If Msg$ <> "" And G_bSUP_ERR = False Then Call MsgBox(Msg$)
''End Sub
'
'Sub JB_ErrorCheck(opCode As String, Fno As Integer) 'TblName As String)
''    Dim tblName As String, nHantei As Integer
''    Dim sErrMsg As String
''
''    If Fno >= 0 Then tblName = DB_PARA(Fno).tblid
''    '
''    nHantei = 0
''    Select Case DBSTAT
''        'Case 0, Jet_BOF, Jet_EOF, Jet_NoMAtch
''        Case 0, Jet_NoMAtch
''        Case 3021
''            If opCode = "GetNext" Or opCode = "GetPre" Then DBSTAT = Jet_EOF Else nHantei = 9
''        Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
''            nHantei = 1
''        Case Else
''            nHantei = 9
''    End Select
''    Select Case nHantei
''        Case 1
''            sErrMsg = "Jet ReTry Error ! [" & tblName & ":" & opCode & ":" & Str$(DB_MAXWAITSEC%) & "]" & Error$
''            DB_MsgBox ""
''            Call Error_Exit(sErrMsg)
''            DoEvents
''        Case 9
''            sErrMsg = "Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & Error$
''            DB_MsgBox "Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & Chr$(13) & Error$
''            Call Error_Exit(sErrMsg)
''        Case Else
''    End Select
'End Sub
'
'Sub Ora_ErrorCheck(opCode As String, Fno As Integer, Optional LockFlg As Integer) 'TblName As String)
''    Dim tblName As String
''    Dim Msg$
''    Dim sErrMsg As String
''    Dim sErrMsg2 As String
''    If Fno >= 0 Then tblName = DB_PARA(Fno).tblid Else tblName = " "
''    '
''    If opCode = "DB_Start" Or opCode = "DB_Open" Then
''        Msg$ = ""
''        Select Case DBSTAT
''        Case 0
''        Case 1  'Call Han_msgINFO("テスト環境です！", BOX_OK%)
''            DBSTAT = 0
''        Case 2  'Call Han_msgINFO("評価版です！", BOX_OK%)
''            DBSTAT = 0
''        Case -1
''            Msg$ = "環境が未設定です！"
''        Case -2
''            Msg$ = "古い環境です！"
''        Case -3
''            Msg$ = "環境が違います！"
''        Case -4
''            Msg$ = "現在使用できません！"
''        Case -5
''            Msg$ = "環境情報が壊れています！"
''        Case -6
''            Msg$ = "同時実行版ライセンスが登録されていません！"
''        Case -7
''            Msg$ = "同時実行版ライセンスが壊れています！"
''        Case -8
''            Msg$ = "ユーザ名称が違います！"
''        Case -9
''            Msg$ = "ライセンスの最大ユーザ数を超えました！"
''        Case -10
''            Msg$ = "データベースに接続できません！"
''        Case -11
''            Msg$ = "接続許可が得られません！"
''        Case Else
''            If DBSTAT < 0 Then
''                Msg$ = "環境エラーです！"
''            Else
''                Msg$ = "ＤＢエラーです！"
''            End If
''        End Select
''        If Msg$ <> "" Then
''            sErrMsg = "Ora  Error " & Msg$ & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
''            'MsgBox "Ora  Error " & Msg$ & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
''            If DBSTAT > 0 Then sErrMsg2 = Space(513): Call sOraErrMsg(DBSTAT, sErrMsg2): sErrMsg = sErrMsg + Chr$(13) + sErrMsg2
''            MsgBox sErrMsg
''            Call Error_Exit("Ora  Error " & Msg$ & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]")
''        End If
''    End If
''
''    Select Case DBSTAT
''        '   OK,  EOF, NULL
''        Case 0, 1403, 1405
''                        G_sErrMsg = "ORA:" + Str$(DBSTAT)
''        Case Else
''            If opCode = "DB_PlExec" Then Exit Sub
''            sErrMsg = "Ora  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
''            If DBSTAT > 0 Then sErrMsg2 = Space(513): Call sOraErrMsg(DBSTAT, sErrMsg2): sErrMsg = sErrMsg + Chr$(13) + sErrMsg2
''            If Not IsMissing(LockFlg) Then
''                If LockFlg = AppLock Then G_sErrMsg = sErrMsg: Exit Sub
''            End If
''            DB_MsgBox sErrMsg
''            'DBSTAT = Dll_AbortTransaction
''            Call Error_Exit(sErrMsg)
''    End Select
'End Sub
'
'Sub DB_APP_END()
''    DB_MsgBox G_sErrMsg
''    Call Error_Exit(G_sErrMsg)
'End Sub
'
'Public Sub JB_BeginTransaction(shareMode As Integer)
''    On Error Resume Next
''    Err.Clear
''    DBSTAT = 0
''    If IsNull(Jet_WS) Then Return
''    Jet_WS.BeginTrans
''    DBSTAT = Err
''    Call JB_ErrorCheck("BeginTransaction", 0)
'End Sub
'
'Public Sub JB_Close(Fno As Integer)
'''''Dim I%
'''''    On Error Resume Next
'''''    Err.Clear
'''''    If RsOpened(Fno) Then
'''''        For I = 0 To JET_RS(Fno).Fields.Count - 1
'''''            Set G_Fld(Fno, I) = Nothing
'''''        Next I
'''''        JET_RS(Fno).Close
'''''        Set JET_RS(Fno) = Nothing
'''''        RsOpened(Fno) = False
'''''    End If
'''''    DBSTAT = Err
'''''    DB_PARA(Fno).Status = DBSTAT
'''''    If NoCheck = False Then Call JB_ErrorCheck("Close", Fno)
'End Sub
'
'Public Sub JB_DELETE(Fno As Integer)
'    On Error Resume Next
'    Err.Clear
'    Call JT_OutPut(Fno, "D")
'    DBSTAT = nErr
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("Delete", Fno)
'End Sub
'
'Public Sub JB_DelAll(Fno As Integer)
''    On Error Resume Next
''    Err.Clear
''    With DB_Spec(DB_PARA(Fno).DBNo)
''    .Jet_DB.Execute ("DELETE FROM " & DB_PARA(Fno).tblid)
''    DBSTAT = Err
''    DB_PARA(Fno).Status = DBSTAT
''    Call JB_ErrorCheck("DelAll", Fno)
''    End With
'End Sub
'
'Public Sub JB_Execute(Fno As Integer, sqlStmt As String)
''    On Error Resume Next
''    Err.Clear
''    With DB_Spec(DB_PARA(Fno).DBNo)
''    .Jet_DB.Execute (sqlStmt)
''    DBSTAT = Err
''    DB_PARA(Fno).Status = DBSTAT
''    Call JB_ErrorCheck("Execute", Fno)
''    End With
'End Sub
'
'Public Sub JB_End()
'''''Dim I%, J%
'''''    On Error Resume Next
'''''    Err.Clear
'''''    For I = 0 To rstMAX
'''''        If RsOpened(I) Then
'''''            If Not IS_ORA(I) Then
'''''                For J = 0 To JET_RS(I).Fields.Count - 1
'''''                    Set G_Fld(I, J) = Nothing
'''''                Next J
'''''                JET_RS(I).Close
'''''                Set JET_RS(I) = Nothing
'''''                RsOpened(I) = False
'''''            End If
'''''        End If
'''''    Next I
'''''    For I = 0 To dbsMAX
'''''        With DB_Spec(I)
'''''        If .sID < "0" Then Exit For
'''''        If Not (.Jet_DB Is Nothing) Then
'''''            .Jet_DB.Close
'''''            Set .Jet_DB = Nothing
'''''            .bLogin = False
'''''        End If
'''''        End With
'''''    Next I
'''''    If Not (Jet_WS Is Nothing) Then
'''''        Jet_WS.Close
'''''        Set Jet_WS = Nothing
'''''    End If
'End Sub
'
'Public Sub JB_EndTransaction()
''    On Error Resume Next
''    Err.Clear
''    DBSTAT = 0
''    If IsNull(Jet_WS) Then Return
''    Jet_WS.CommitTrans
''    DBSTAT = Err
''    Call JB_ErrorCheck("EndTransaction", 0)
'End Sub
'
'Public Sub JB_GetEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, "=", KeyNo, keyVal, LockFlg)
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetEq", Fno)
'End Sub
'
'Public Function JT_Get%(ByVal Fno As Integer, ByVal Rel As String, ByVal KeyNo As Integer, ByVal keyVal As String, LockFlg As Integer)
''Dim k(9) As String, I%, ofs%, Vlen%
''     On Error Resume Next
''    Err.Clear
''    If JET_RS(Fno).Type <> dbOpenTable Then
''        JET_RS(Fno).Close
''        Set JET_RS(Fno) = Nothing
''        With DB_Spec(DB_PARA(Fno).DBNo)
''        Set JET_RS(Fno) = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, dbOpenTable)
''        For I = 0 To JET_RS(Fno).Fields.count - 1
''            Set G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
''        Next I
''        End With
''    End If
''    JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
''    Vlen = LenWid(keyVal)
''    With KeyIndex(Fno).Seg(KeyNo - 1)
''        ofs = 1
''        For I = 0 To .ItmCnt - 1
''            k(I) = ""
''            If Vlen >= ofs Then k(I) = MidWid(keyVal, ofs, .ItmLen(I))
''            ofs = ofs + .ItmLen(I)
''        Next I
''    End With
''    Select Case I
''        Case 1: JET_RS(Fno).Seek Rel, k(0)
''        Case 2: JET_RS(Fno).Seek Rel, k(0), k(1)
''        Case 3: JET_RS(Fno).Seek Rel, k(0), k(1), k(2)
''        Case 4: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3)
''        Case 5: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4)
''        Case 6: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4), k(5)
''        Case 7: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6)
''        Case 8: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7)
''        Case 9: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8)
''        Case Else: JET_RS(Fno).Seek Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8), k(9)
''    End Select
''    If Err = 0 Then
''        If JET_RS(Fno).NoMatch Then
''            JT_Get = Jet_NoMAtch
''        Else
''            nErr = 0
''            If LockFlg Then Call JT_OutPut(Fno, "E")
''            If nErr = 0 Then
''                JT_Get = Jet_NoErr
''                DB_PARA(Fno).KeyNo = KeyNo
''                Call RecordFromObject(Fno)
''                If Err = 0 Then Call KeyFromObject(Fno) Else JT_Get = Err
''            Else
''                JT_Get = nErr
''            End If
''        End If
''    Else
''        JT_Get = Err
''    End If
'End Function
'
'Sub JT_OutPut(Fno%, Kbn$)
'''    Dim StTime@, EnTime@, CurTime@
''    Dim Msg$, Syori$
'''
''    StTime@ = Timer
''    EnTime@ = StTime@ + DB_MAXWAITSEC%
''    Do
''        On Error Resume Next
''        'Err.Clear
''        Select Case Kbn$
''        Case "E"
''            JET_RS(Fno).Edit
''        Case "U"
''            JET_RS(Fno).Update
''        Case "D"
''            JET_RS(Fno).Delete
''        End Select
''        nErr = Err
''        On Error GoTo 0
''        '
''        Select Case nErr
''        Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
''            DoEvents
''            CurTime@ = Timer
''            If CurTime@ < StTime@ Then StTime@ = CurTime@: EnTime@ = StTime@ + 5
''            If CurTime@ > EnTime@ Then
''                If Kbn$ = "E" Then Syori$ = "EDIT" Else If Kbn$ = "U" Then Syori$ = "Update" Else Kbn$ = "Delete"
''                Msg$ = Str$(DB_MAXWAITSEC%) + "秒間待ちましたが、Jetファイルが使用中です。" + Chr$(13)
''                Msg$ = Msg$ + "FILE_ID = (" + DB_PARA(Fno).tblid + ")  処理 = " + Syori$ + Chr$(13)
''                Msg$ = Msg$ + "再試行（リトライ）しますか？" + Chr$(13)
''                Msg$ = Msg$ + "［注意］キャンセルすると、このデータを登録せずにプログラムを終了します！"
''                If MsgBox(Msg$, vbRetryCancel) = vbCancel Then
''                    'Call Error_Exit("Jet ReTry Error ! [" & DB_PARA(Fno).tblid & ":" & opCode & ":" & DB_MAXWAITSEC% & "]" & Error$)
''                    Exit Do
''                Else
''                    StTime@ = Timer
''                    EnTime@ = StTime@ + DB_MAXWAITSEC%
''                End If
''            Else
''                DoEvents
''            End If
''        Case Else
''            Exit Do
''        End Select
''        '
''    Loop
'End Sub
'
'Sub KeyFromObject(Fno)
'Dim S$, I%
'    S$ = ""
'    With KeyIndex(Fno).Seg(DB_PARA(Fno).KeyNo - 1)
'        For I = 0 To .ItmCnt - 1
'            S$ = S$ + JET_RS(Fno).Fields(.ItmPos(I)).Value
'        Next I
'    End With
'    DB_PARA(Fno).KeyBuf = S$
'End Sub
'
'Public Sub JB_GetFirst(Fno As Integer, KeyNo As Integer, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, ">=", KeyNo, "", LockFlg)
''    Jet_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
''    Jet_RS(Fno).MoveFirst
''    If Err = 0 Then
''        If Jet_RS(Fno).BOF Then
''            DBSTAT = Jet_NoMAtch
''            'DBSTAT = Jet_BOF
''        Else
''            DBSTAT = Jet_NoErr
''            DB_PARA(Fno).KeyNo = KeyNo
''            Call RecordFromObject(Fno)
''            Call KeyFromObject(Fno)
''        End If
''    Else
''        DBSTAT = Err
''    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetFirst", Fno)
'End Sub
'
'Public Sub JB_GetGr(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, ">", KeyNo, keyVal, LockFlg)
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetGr", Fno)
'End Sub
'
'Public Sub JB_GetGrEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, ">=", KeyNo, keyVal, LockFlg)
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetGrEq", Fno)
'End Sub
'
'Public Sub JB_GetLast(Fno As Integer, KeyNo As Integer, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
'    JET_RS(Fno).MoveLast
'    If Err = 0 Then
'        If JET_RS(Fno).EOF Then
'            DBSTAT = Jet_NoMAtch
'            'DBSTAT = Jet_EOF
'        Else
'            nErr = 0
'            If LockFlg Then Call JT_OutPut(Fno, "E")
'            If nErr = 0 Then
'                DBSTAT = Jet_NoErr
'                DB_PARA(Fno).KeyNo = KeyNo
'                Call RecordFromObject(Fno)
'                If Err = 0 Then Call KeyFromObject(Fno)
'                If Err Then DBSTAT = Err
'            Else
'                DBSTAT = nErr
'            End If
'        End If
'    Else
'        DBSTAT = Err
'    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetLast", Fno)
'End Sub
'
'Public Sub JB_GetLs(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, "<", KeyNo, keyVal, LockFlg)
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetLs", Fno)
'End Sub
'
'Public Sub JB_GetLsEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    DBSTAT = JT_Get(Fno, "<=", KeyNo, keyVal, LockFlg)
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetLsEq", Fno)
'End Sub
'
'Public Sub JB_GetNext(Fno As Integer, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    JET_RS(Fno).MoveNext
'    If Err = 0 Then
'        If JET_RS(Fno).EOF Then
'            DBSTAT = Jet_NoMAtch
'            'DBSTAT = Jet_EOF
'        Else
'            nErr = 0
'            If LockFlg Then Call JT_OutPut(Fno, "E")
'            If nErr = 0 Then
'                DBSTAT = Jet_NoErr
'                'DB_PARA(Fno).KeyNo = KeyNo
'                Call RecordFromObject(Fno)
'                If Err = 0 Then Call KeyFromObject(Fno)
'                If Err Then DBSTAT = Err
'            Else
'                DBSTAT = nErr
'            End If
'        End If
'    Else
'        DBSTAT = Err
'    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetNext", Fno)
'End Sub
'
'Public Sub JB_GetPre(Fno As Integer, LockFlg As Integer)
'    On Error Resume Next
'    Err.Clear
'    JET_RS(Fno).MovePrevious
'    If Err = 0 Then
'        If JET_RS(Fno).BOF Then
'            DBSTAT = Jet_NoMAtch
'            'DBSTAT = Jet_BOF
'        Else
'            nErr = 0
'            If LockFlg Then Call JT_OutPut(Fno, "E")
'            If nErr = 0 Then
'                DBSTAT = Jet_NoErr
'                'DB_PARA(Fno).KeyNo = KeyNo
'                Call RecordFromObject(Fno)
'                If Err = 0 Then Call KeyFromObject(Fno)
'                If Err Then DBSTAT = Err
'            Else
'                DBSTAT = nErr
'            End If
'        End If
'    Else
'        DBSTAT = Err
'    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetPre", Fno)
'End Sub
'
'Public Sub JB_GetSQL(Fno As Integer, Sql As String)
''Dim Sql$, i%
'Dim I%
''   On Error Resume Next
'    Err.Clear
'    'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + Joken
'    If Not (JET_RS(Fno) Is Nothing) Then
'        JET_RS(Fno).Close
'        Set JET_RS(Fno) = Nothing
'    End If
'    With DB_Spec(DB_PARA(Fno).DBNo)
'    Set JET_RS(Fno) = .Jet_DB.OpenRecordset(Sql, dbOpenDynaset)
'    If JET_RS(Fno).RecordCount > 0 Then
'        For I = 0 To JET_RS(Fno).Fields.count - 1
'            Set G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
'        Next I
'        If Err = 0 Then
'            DB_PARA(Fno).KeyNo = 1 'KeyNo
'            Call RecordFromObject(Fno)
'            Call KeyFromObject(Fno)
'        End If
'        DBSTAT = Err
'        If DBSTAT <> 0 Then MsgBox "JB_GetSQL DBSTAT=" & Str$(DBSTAT) & " " & Error$
'    Else
'        DBSTAT = Jet_NoMAtch
'    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("GetSQL", Fno)
'    End With
'End Sub
'
'Public Sub JB_Insert(Fno As Integer, KeyNo As Integer)
'    On Error Resume Next
'    Err.Clear
'    JET_RS(Fno).AddNew
'    Call ObjectFromRecord(Fno)
'    If Err = 0 Then Call JT_OutPut(Fno, "U"): DBSTAT = nErr Else DBSTAT = Err
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("Insert", Fno)
'End Sub
'
'Public Sub JB_NCCLOSE(Fno As Integer)
'    NoCheck = True
'    JB_Close Fno
'    NoCheck = False
''    Call JB_ErrorCheck("NCClose", Fno)
'End Sub
'
'Public Sub JB_NCOPEN(Fno As Integer)
'    NoCheck = True
'    JB_Open Fno
'    NoCheck = False
''    Call JB_ErrorCheck("JB_NCOpen", Fno)
'End Sub
'
'Public Sub JB_Open(Fno As Integer)
'Dim I%, DBNo%, Wk$, ret, sDB$
'    On Error Resume Next
'    Err.Clear
'    DBNo = JT_GetDBno(Fno)
'    If DBNo >= 0 Then
'        DB_PARA(Fno).DBNo = DBNo
'    Else
'        MsgBox "データベース定義エラー: " & DB_PARA(Fno).tblid
'        Exit Sub
'    End If
'
'    With DB_Spec(DBNo)
'    If .bLogin = False Then
'        'Wk = .sLoc & .sID & ".MDB"
'        sDB = Switch(.sID = "SYSDBC", "SYSDBN", .sID = "SSSWB2", "SSSWB1", True, .sID)
'        Wk = .sLoc & sDB & ".MDB"
'        Set .Jet_DB = Jet_WS.OpenDatabase(Wk)
'        If Err = 3343 Then
'            ret = MsgBox("Jetデータベースが破損している様です。(JET-3343)" + Chr$(13) + Wk + Chr$(13) + "修復しますか？", vbYesNo)
'            If ret = vbYes Then
'                Err.Clear
'                DBEngine.RepairDatabase Wk
'                If Err = 0 Then Set .Jet_DB = Jet_WS.OpenDatabase(Wk)
'            End If
'        End If
'        If Err <> 0 Then
'            DBSTAT = Err
'            MsgBox "Jetデータベースを開く事はできません。JET[" + Str$(DBSTAT) + "]" + Chr$(13) + Wk
'            Exit Sub
'        End If
'        .bLogin = True
'    End If
'
'    If Not RsOpened(Fno) Then
'        Set JET_RS(Fno) = .Jet_DB.OpenRecordset(Trim$(DB_PARA(Fno).tblid), dbOpenTable)
'        If Err = 0 Then Err = JT_KeySet(Fno)
'        If Err = 0 Then
'            For I = 0 To JET_RS(Fno).Fields.count - 1
'                Set G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
'            Next I
'            RsOpened(Fno) = True
'        End If
'    End If
'    DBSTAT = Err
'    DB_PARA(Fno).Status = DBSTAT
'    If NoCheck = False Then Call JB_ErrorCheck("Open", Fno)
'    End With
'End Sub
'
'Private Function JT_GetDBno(Fno As Integer)
'Dim Wk$, Wkno%
''    On Error Resume Next
'    Wk = UCase(Trim$(DB_PARA(Fno).DBID))
'    JT_GetDBno = -1
'    For Wkno = 0 To dbsMAX
'        With DB_Spec(Wkno)
'        If .sID < "0" Then Exit For
'        If Wk = .sID Then
'            JT_GetDBno = Wkno
'            Exit For
'        End If
'        End With
'    Next Wkno
'End Function
'
'Private Function JT_KeySet(Fno As Integer)
'Dim I%, ii%, J%, DBNo%, xx$
'    DBNo = DB_PARA(Fno).DBNo
'    With DB_Spec(DBNo)
'    On Error Resume Next
'    Err.Clear
'    JT_KeySet = Jet_OpnErr
'    Set Jet_Td = Nothing
'    For I = 0 To .Jet_DB.TableDefs.count - 1
'        If Trim$(.Jet_DB.TableDefs(I).Name) = Trim$(DB_PARA(Fno).tblid) Then
'             Set Jet_Td = .Jet_DB.TableDefs(I)
'             Exit For
'        End If
'    Next I
'    If I >= .Jet_DB.TableDefs.count Then
'        Set Jet_Td = Nothing
'        Exit Function
'    End If
'    End With
'    With KeyIndex(Fno)
'        .tblName = DB_PARA(Fno).tblid
'        .KeyCnt = Jet_Td.Indexes.count
'        For I = 0 To .KeyCnt - 1
'            xx$ = Trim(Jet_Td.Indexes(I).Name)
'            ii = CInt(Right$(xx$, 2)) - 1
'            With .Seg(ii)
'                .KeyName = xx$ 'Jet_Td.Indexes(i).Name
'                .ItmCnt = Jet_Td.Indexes(I).Fields.count
'                For J = 0 To .ItmCnt - 1
'                    '.ItmName(J) = Jet_Td.Indexes(I).Fields(J).Name
'                    '.bKb(j) = 0
'                    '.ItmLen(j) = GetFldSize(Jet_Td.Fields, .ItmName(j))
'                    .ItmLen(J) = GetFldSize(Jet_Td.Fields, Jet_Td.Indexes(I).Fields(J).Name)
'                    .ItmPos(J) = GetFldPos(Jet_Td.Fields, Jet_Td.Indexes(I).Fields(J).Name)
'                Next J
'            End With
'        Next I
'    End With
'    Set Jet_Td = Nothing
'    JT_KeySet = Err
'End Function
'
''Function GetFldSize(flds As Fields, IName As String) As Integer
''    Dim I%
''    GetFldSize = 0
''    For I = 0 To flds.Count - 1
''        If Trim$(flds(I).Name) = Trim$(IName) Then
''            GetFldSize = flds(I).Size
''            Exit For
''        End If
''    Next I
''End Function
'
''Function GetFldPos(flds As Fields, IName As String) As Integer
''    Dim I%
''    GetFldPos = -1
''    For I = 0 To flds.Count - 1
''        If Trim$(flds(I).Name) = Trim$(IName) Then
''            GetFldPos = I
''            Exit For
''        End If
''    Next I
''End Function
'
'Public Sub JB_Start()
'Dim Wk As String * 513, ret, wk2$
'    On Error Resume Next
'    Err.Clear
'    DB_MAXWAITSEC% = 10
'    ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk, Len(Wk), "SSSWIN.INI")
'    DicPath = UCase(LeftWid(Wk, ret)) & "\LIB\DIC\"
'    ret = GetPrivateProfileString("SSSWIN", "LCK_RTRY", "", Wk, Len(Wk), "SSSWIN.INI")
'    BtrMaxReTryCnt = SSSVal(LeftWid(Wk, ret))
''    ret = GetPrivateProfileString("SSSUSR", "WAIT_SEC", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    ret = GetPrivateProfileString("DBSPEC", "WAIT_SEC", "", Wk, Len(Wk), "SSSWIN.INI")
'    If ret > 0 Then DB_MAXWAITSEC% = CInt(LeftWid(Wk, ret))
'    DB_APPWAITSEC% = 200
'    ret = GetPrivateProfileString("DBSPEC", "LOCK_MILISEC", "", Wk, Len(Wk), "SSSWIN.INI")
'    If ret > 0 Then DB_APPWAITSEC% = CInt(LeftWid(Wk, ret))
'    '
'
'    Erase DB_Spec '1998/11/11 by Kitomi
'    Call SetDBSpec
'    ret = GetPrivateProfileString("LOCK", "RRRLOCK", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = LeftWid(Wk, ret)
'    G_sRRRLock = Switch(wk2$ = "SRX", "SHARE ROW EXCLUSIVE", wk2$ = "RX", "ROW EXCLUSIVE", _
'        wk2$ = "RS", "ROW SHARE", wk2$ = "X", "EXCLUSIVE", wk2$ = "S", "SHARE", True, UCase$(wk2$))
'    '
'    ret = GetPrivateProfileString("LOCK", "RRRLOCK2", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = LeftWid(Wk, ret)
'    G_sRRRLock2 = Switch(wk2$ = "SRX", "SHARE ROW EXCLUSIVE", wk2$ = "RX", "ROW EXCLUSIVE", _
'        wk2$ = "RS", "ROW SHARE", wk2$ = "X", "EXCLUSIVE", wk2$ = "S", "SHARE", True, UCase$(wk2$))
'    '
'    ret = GetPrivateProfileString("LOCK", "RRRLOCK3", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = LeftWid(Wk, ret)
'    G_sRRRLock3 = Switch(wk2$ = "SRX", "SHARE ROW EXCLUSIVE", wk2$ = "RX", "ROW EXCLUSIVE", _
'        wk2$ = "RS", "ROW SHARE", wk2$ = "X", "EXCLUSIVE", wk2$ = "S", "SHARE", wk2$ = "", "")
'    '
'    ret = GetPrivateProfileString("LOCK", "BUSY_APP", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = UCase(LeftWid(Wk, ret))
'    If wk2$ = "TRUE" Then G_bRetApp = True
'    '
'    ret = GetPrivateProfileString("PLSQL", "EXT_CND", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = UCase(LeftWid(Wk, ret))
'    If wk2$ = "TRUE" Then G_bExtCnd = True
'    '
'    ret = GetPrivateProfileString("PLSQL", "ALERT_LOG", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    If UCase(LeftWid(Wk, ret)) = "FALSE" Then G_NO_ALTLOG = True Else G_NO_ALTLOG = False
'    '
'    ret = GetPrivateProfileString("SSSUSR", "BUSY_LOG", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    If UCase(LeftWid(Wk, ret)) = "TRUE" Then G_bBusyLog = True Else G_bBusyLog = False
'    '
'    ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    If UCase(LeftWid(Wk, ret)) = "TRUE" Then G_bTranLog = True Else G_bBusyLog = False
'    '
'    ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG_PATH", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2$ = LeftWid(Wk, ret): TRAN_LOG_PATH$ = wk2$
'    If Right$(TRAN_LOG_PATH$, 1) <> "\" Then TRAN_LOG_PATH$ = TRAN_LOG_PATH$ + "\"
'    '
'    Set Jet_WS = DBEngine.Workspaces(0)
'    DBSTAT = Err
'End Sub
'
'Sub SetDBSpec()
'Dim Wk As String * 513, wk2$, ret
'Dim DBNo%, I%
''
'    If DB_Spec(0).sID > "0" Then Exit Sub
'    DB_Spec(0).sID = "SYSDBN"
'    DB_Spec(1).sID = "SYSDBC"
'    DB_Spec(2).sID = "SSSDF1"
'    DB_Spec(3).sID = "SSSDF2"
'    DB_Spec(4).sID = "SSSDF3"
'    DB_Spec(5).sID = "SSSDS1"
'    DB_Spec(6).sID = "SSSDS2"
'    DB_Spec(7).sID = "SSSDS3"
'    DB_Spec(8).sID = "SSSWB1"
'    DB_Spec(9).sID = "SSSWB2"
'    DB_Spec(10).sID = "SSSWB3"
'    DB_Spec(11).sID = "USR1"
'    DB_Spec(12).sID = "USR2"
'    DB_Spec(13).sID = "USR3"
'    DB_Spec(14).sID = "USR4"
'    DB_Spec(15).sID = "USR5"
'    DB_Spec(16).sID = "USR6"
'    DB_Spec(17).sID = "USR7"
'    DB_Spec(18).sID = "USR8"
'    DB_Spec(19).sID = "USR9"
'    DB_Spec(20).sID = ""
'    DB_Spec(11).bOra = True
'    DB_Spec(12).bOra = False
'    DB_Spec(13).bOra = False
'    DB_Spec(14).bOra = True
'    DB_Spec(15).bOra = True
'    DB_Spec(16).bOra = True
'    DB_Spec(17).bOra = True
'    DB_Spec(18).bOra = True
'    DB_Spec(19).bOra = True
'    DB_Spec(20).bOra = False
''
'    ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk, Len(Wk), "SSSWIN.INI")
'    If ret > 0 Then USR_PATH$ = LeftWid(Wk, ret): If Right$(USR_PATH$, 1) <> "\" Then USR_PATH$ = USR_PATH$ + "\"
'    ret = GetPrivateProfileString("SSSWIN", "EXT_PATH", "", Wk, Len(Wk), "SSSWIN.INI")
'    If ret > 0 Then EXT_PATH$ = LeftWid(Wk, ret): If Right$(EXT_PATH$, 1) <> "\" Then EXT_PATH$ = EXT_PATH$ + "\"
'    G_sCLTID$ = MidWid$(Command$, 2, 5)
'    G_sOPEID$ = MidWid$(Command$, 7, 8)
''
'    ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
'    wk2 = UCase(LeftWid(Wk, ret)): G_bORA_RPS = (wk2 = "TRUE")
''    ret = GetPrivateProfileString("DBSPEC", "ORA_RPS_EXT", "", Wk, Len(Wk), "SSSWIN.INI")
'    ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk, Len(Wk), EXT_PATH$ + "SSSUSR.INI")
'    wk2 = UCase(LeftWid(Wk, ret)): G_bORA_RPS_EXT = (wk2 = "TRUE")
'    '
'    For I = 0 To 10: DB_Spec(I).bOra = G_bORA_RPS: Next I
'    DB_Spec(1).bOra = G_bORA_RPS_EXT
'    DB_Spec(9).bOra = G_bORA_RPS_EXT
''
'    For DBNo% = 0 To dbsMAX
'        If DB_Spec(DBNo%).sID < "0" Then Exit For
'        ret = GetPrivateProfileString("DBLOC", DB_Spec(DBNo%).sID, "", Wk, Len(Wk), "SSSWIN.INI")
'        DB_Spec(DBNo%).bLogin = False
'        Set DB_Spec(DBNo%).Jet_DB = Nothing
'        If ret > 0 Then
'            wk2 = LeftWid(Wk, ret)
'            wk2 = Trim$(wk2)
'            If DB_Spec(DBNo%).bOra = False Then If Right$(wk2, 1) <> "\" Then wk2 = wk2 + "\"
'            DB_Spec(DBNo%).sLoc = wk2
'            DB_Spec(DBNo%).bReged = True
'        Else
'            DB_Spec(DBNo%).sLoc = ""
'            DB_Spec(DBNo%).bReged = False
'        End If
'    Next DBNo%
''
'    ret = GetPrivateProfileString("DBLOC", "RWRK", "", Wk, Len(Wk), "SSSWIN.INI")
'    DBNo% = 12
'    If ret > 0 Then
'        wk2 = LeftWid(Wk, ret)
'        wk2 = Trim$(wk2)
'        If Right$(wk2, 1) <> "\" Then wk2 = wk2 + "\"
'        DB_Spec(DBNo%).sLoc = wk2
'        DB_Spec(DBNo%).bReged = True
'    Else
'        DB_Spec(DBNo%).sLoc = ""
'        DB_Spec(DBNo%).bReged = False
'    End If
'    ret = GetPrivateProfileString("DBSPEC", "RETRYITV", "0", Wk, Len(Wk), "SSSWIN.INI")
'    G_RetryItv = 100
'    On Error Resume Next
'    G_RetryItv = CInt(Wk)
'    On Error GoTo 0
'End Sub
'
'Public Function JB_STAT(Fno As Integer) As Long
'Dim Sql$, DBNo%
'Dim TMP_RS As Recordset
'    On Error Resume Next
'    Err.Clear
'    With DB_Spec(DB_PARA(Fno).DBNo)
'    Set TMP_RS = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, dbOpenTable)
'    JB_STAT = TMP_RS.RecordCount
'    TMP_RS.Close
'    Set TMP_RS = Nothing
'    DBSTAT = Err
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("Stat", Fno)
'    End With
'End Function
'
'Public Sub JB_Unlock(Fno As Integer)
'    On Error Resume Next
'    Err.Clear
'    JET_RS(Fno).CancelUpdate
'    DBSTAT = Err
'    DB_PARA(Fno).Status = DBSTAT
'End Sub
'
'Public Sub JB_Update(Fno As Integer, KeyNo As Integer)
'    On Error Resume Next
'    Err.Clear
'    Call JT_OutPut(Fno, "E")
'    If nErr = 0 Then
'        Call ObjectFromRecord(Fno)
'        If Err = 0 Then Call JT_OutPut(Fno, "U"): DBSTAT = nErr
'        If Err Then DBSTAT = Err
'    Else
'        DBSTAT = nErr
'    End If
'    DB_PARA(Fno).Status = DBSTAT
'    Call JB_ErrorCheck("Update", Fno)
'End Sub
'
''旧関数インターフェイス
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''' Followings:  Added on Aug. 20,'96  ''''''''''''''''''''''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Public Sub ResetDBSTAT(Fno As Integer, Optional bApp%)
'    G_FNO = Fno
'    If (Fno >= 0) Then
'        DB_PARA(Fno).Status = DBSTAT
'    End If
'    DBSTAT = 0
'    Err.Clear
'    ret = 0
'    StTime@ = Timer
'    DB_REALWAITSEC@ = IIf(bApp% = AppLock, DB_APPWAITSEC% / 1000, DB_MAXWAITSEC%)
'    EnTime@ = StTime@ + DB_REALWAITSEC@
'End Sub
'
'Public Sub SetDBSTAT(erno As Variant)
'    DBSTAT = CLng(erno)
'    If G_FNO >= 0 Then DB_PARA(G_FNO).Status = DBSTAT
'End Sub
'
'Public Function IS_ORA(Fno As Integer, Optional bNoCheck As Variant)
'Dim sID$, n%
'    If IsMissing(bNoCheck) And RsOpened(Fno) = False Then
'        MsgBox ("ファイルがオープンされていません。(" + DB_PARA(Fno).tblid + ")")
'        Call Error_Exit("Table is Not Opened !" & " = [" & DB_PARA(Fno).tblid & ":" & DBSTAT & "]")
'    End If
'    'sID$ = UCase(Left$(DB_PARA(Fno).DBID, 4))
'    sID$ = Trim$(UCase(DB_PARA(Fno).DBID))
'    IS_ORA = False
'    If sID$ = "USR2" Or sID$ = "USR3" Then Exit Function
'    'If (sID$ = "SYSDBC" Or sID$ = "SSSWB2") And G_bORA_RPS_EXT = False Then Exit Function
'    'If Left$(sID$, 3) <> "USR" And G_bORA_RPS = False Then Exit Function
'    If (sID$ = "SYSDBC" Or sID$ = "SSSWB2") Then
'        If G_bORA_RPS_EXT = False Then Exit Function
'    ElseIf Left$(sID$, 3) <> "USR" Then
'        If G_bORA_RPS = False Then Exit Function
'    End If
'    IS_ORA = True
'End Function
'
'Sub DB_ChkKey(Fno As Integer, KeyNo As Integer)
'    If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
'    If IsNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
'End Sub
'
'Sub DB_MakKey(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant)
'    If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
'    DB_PARA(Fno).KeyBuf = CStr(keyVal)
'    If IsNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
'End Sub
'
'''Declare Function DB_GetFirst Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal lockFlg&) As Long
'Sub DB_GetFirst(Fno As Integer, KeyNo As Integer, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetFirst(Fno, KeyNo, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_ChkKey(Fno, KeyNo)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetFirst(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetFirst", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_GetNext Lib "sssoraif" (Fno as integer, recBuf As Any, lockFlg as integer) As Long
'Sub DB_GetNext(Fno As Integer, LockFlg As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_GetNext(Fno, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call ResetExtNum
'    If DB_PARA(Fno).nDirection = nDir_Fore Then
'        Call SetBuf(Fno)
'        Call DB_ChkKey(Fno, -1)
'        Do
'            DBSTAT = Dll_GetNext(Fno, G_LB, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, DB_ExtNum)
'        Loop While IsBusy_ORA("DB_GetNext", LockFlg)
'        Call ResetBuf(Fno)
'        'Debug.Print DB_PARA(FNO).KeyBuf
'    Else
'        DBSTAT = -11
'    End If
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
'''Declare Function DB_GetPre Lib "sssoraif" (ByVal FNo&, recBuf As Any, lockFlg as integer) As Long
'Sub DB_GetPre(Fno As Integer, LockFlg As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_GetPre(Fno, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call ResetExtNum
'    If DB_PARA(Fno).nDirection = nDir_Back Then
'        Call SetBuf(Fno)
'        Call DB_ChkKey(Fno, -1)
'        Do
'            DBSTAT = Dll_GetPre(Fno, G_LB, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, DB_ExtNum)
'        Loop While IsBusy_ORA("DB_GetPre", LockFlg)
'        Call ResetBuf(Fno)
'    Else
'        DBSTAT = -12
'    End If
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
'''Declare Function DB_GetLast Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, lockFlg as integer) As Long
'Sub DB_GetLast(Fno As Integer, KeyNo As Integer, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetLast(Fno, KeyNo, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_ChkKey(Fno, KeyNo)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetLast(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetLast", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
'End Sub
'
'''Declare Function DB_GetEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, ByVal keyVal$, lockFlg as integer) As Long
'Sub DB_GetEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetEq(Fno, KeyNo, keyVal, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_MakKey(Fno, KeyNo, keyVal)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetEq", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
'End Sub
'
'''Declare Function DB_GetGrEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal as string, lockFlg as integer) As Long
'Sub DB_GetGrEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetGrEq(Fno, KeyNo, keyVal, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_MakKey(Fno, KeyNo, keyVal)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetGrEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'
'    Loop While IsBusy_ORA("DB_GetGrEq", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_GetGr Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
'Sub DB_GetGr(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetGr(Fno, KeyNo, keyVal, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_MakKey(Fno, KeyNo, keyVal)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetGr(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetGr", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_GetLs Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
'Sub DB_GetLs(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetLs(Fno, KeyNo, keyVal, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_MakKey(Fno, KeyNo, keyVal)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetLs(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetLs", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
'End Sub
'
'''Declare Function DB_GetLsEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
'Sub DB_GetLsEq(Fno As Integer, KeyNo As Integer, ByVal keyVal As Variant, LockFlg As Integer, Optional ByVal sFields)
'    If IS_ORA(Fno) = 0 Then Call JB_GetLsEq(Fno, KeyNo, keyVal, LockFlg): Exit Sub
'    Call ResetDBSTAT(Fno, LockFlg)
'    Call SetBuf(Fno)
'    Call DB_MakKey(Fno, KeyNo, keyVal)
'    If IsMissing(sFields) Then G_sFields = "" Else G_sFields = sFields
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetLsEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetLsEq", LockFlg)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
'End Sub
'
'''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
'Sub DB_GetSQL(Fno As Integer, sqlStmt As String, Optional ByVal sFields)
'Dim Sql$, I%
'    If IS_ORA(Fno) = 0 Or IsMissing(sFields) Then
'        Sql = "Select *"
'    Else
'        Sql = "Select " + sFields
'    End If
'    Sql = Sql + " From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
'    If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, Sql): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetSQL(Fno, G_LB, Sql, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetSQL")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
'Sub DB_GetSQL2(Fno As Integer, sqlStmt As String)
''Dim Sql$, i%
'    If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt): Exit Sub
'    'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetSQL(Fno, G_LB, sqlStmt, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetSQL")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
'Sub DB_GetSQL3(Fno As Integer, sqlStmt As String)
''Dim Sql$, i%
'    If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt): Exit Sub
'    'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
'    Call ResetDBSTAT(Fno, AppLock)
'    Call SetBuf(Fno)
'    Call ResetExtNum
'    Do
'        DBSTAT = Dll_GetSQL(Fno, G_LB, sqlStmt, DB_ExtNum)
'    Loop While IsBusy_ORA("DB_GetSQL", AppLock)
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
'End Sub
'
'''Declare Function DB_Execute Lib "sssoraif" (ByVal sqlStmt$) As Long
'Sub DB_Execute(Fno As Integer, sqlStmt As String)
'    If IS_ORA(Fno) = 0 Then Call JB_Execute(Fno, sqlStmt): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Do
'        DBSTAT = Dll_Execute(Fno, sqlStmt)
'    Loop While IsBusy_ORA("DB_Execute")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    ''If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
'End Sub
'
'Public Sub DB_DelAll(Fno As Integer)
'    Dim swk$
'    If IS_ORA(Fno) = 0 Then Call JB_DelAll(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    'sWK$ = "DELETE FROM " + Trim$(DB_PARA(Fno).DBID) + "." + Trim$(DB_PARA(Fno).tblid)
'    swk$ = "DELETE FROM " + Trim$(DB_PARA(Fno).tblid)
'    Do
'        DBSTAT = Dll_Execute(Fno, swk$)
'    Loop While IsBusy_ORA("DB_DelAll")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
'End Sub
'
''' Deleting , Inserting and Updating Data
'''Declare Function DB_Delete Lib "sssoraif" (ByVal FNo&, recBuf As Any) As Long
'Sub DB_Delete(Fno As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_DELETE(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Do
'        DBSTAT = Dll_Delete(Fno, G_LB)
'    Loop While IsBusy_ORA("DB_Delete")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
'''Declare Function DB_Insert Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer) As Long
'Sub DB_Insert(Fno As Integer, KeyNo As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_Insert(Fno, KeyNo): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Call DB_ChkKey(Fno, KeyNo)
'    Do
'        DBSTAT = Dll_Insert(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf)
'    Loop While IsBusy_ORA("DB_Insert")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
'''Declare Function DB_Update Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer) As Long
'Sub DB_Update(Fno As Integer, KeyNo As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_Update(Fno, KeyNo): Exit Sub
'    Call ResetDBSTAT(Fno)
'    Call SetBuf(Fno)
'    Call DB_ChkKey(Fno, KeyNo)
'    Do
'        DBSTAT = Dll_Update(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf)
'    Loop While IsBusy_ORA("DB_Update")
'    Call ResetBuf(Fno)
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
''' Others
'Sub DB_Stat(Fno As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_STAT(Fno): Exit Sub
'    Dim xxx&
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_Stat(Fno, xxx&)
'    If DBSTAT = 0 Then
'        StatFileBuffer.RecTot = xxx&
'    Else
'        StatFileBuffer.RecTot = 0
'    End If
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
'End Sub
'
'''Declare Function DB_Start Lib "sssoraif" (ByVal sCon$) As Long
'Sub DB_Start(DbNm As String, DbHd As String)
'    Dim sDLL_VER$
'    Call DB_End
'    Call ResetDBSTAT(-1)
'    G_sUNIID$ = "": G_nUNICNT& = 0
'    G_bUSR1_ON = False
'    G_bSUP_ERR = False
'    G_nTranStt = 0
'    G_bBusyLog = False
'    G_bTranLog = False
'    Ora_DBName$ = DbNm: Ora_DBHead$ = DbHd: Ora_Connect1$ = Ora_DBHead$ + Ora_Connect$
''Debug.Print Timer
'    sDLL_VER$ = "            "
'    Call Dll_ChkVer(sDLL_VER$)
'    If Left$(sBAS_VER$, 5) <> Left$(sDLL_VER$, 5) Then
'        Call MsgBox("バージョン不一致:ORAJET.BAS=" + sBAS_VER$ + ", SSSORAIF.DLL=" + Left$(sDLL_VER$, 7))
'        Call Error_Exit("バージョン不一致:ORAJET.BAS=" + sBAS_VER$ + ", SSSORAIF.DLL=" + Left$(sDLL_VER$, 7))
'    End If
'    DBSTAT = Dll_Start(Ora_DBName$, Ora_DBHead$)
'    Ora_DBStart_FLG = 1
'    Call Ora_ErrorCheck("DB_Start", -1)
''Debug.Print Timer
'    If Ora_DBStart_FLG = 0 Then
'        If DBSTAT = 0 Then
'            'Call JB_Start
'            Ora_DBStart_FLG = 1
'        End If
'    End If
'    Call JB_Start
'    If Len(G_sPRGID) < 7 Then G_bTool = True Else G_bTool = False
'End Sub
'
'''Declare Function DB_RESET Lib "sssoraif" () As Long
'Sub DB_RESET()
'    Call DB_End
'End Sub
'
'''Declare Function DB_Stop Lib "sssoraif" () As Long
'Sub DB_Stop()
'    Call DB_End
'End Sub
'
'''Declare Function DB_Open Lib "sssoraif" (Fno as integer, ByVal dbid$, ByVal tblid$) As Long
'Sub DB_Open(Fno As Integer, DBID As String, tblid As String)
'    Dim EN_TIME
'    Dim sMsg$
'    If IS_ORA(Fno, True) = 0 Then Call JB_Open(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    EN_TIME = Timer + 10
''Debug.Print Timer
'    Do While True
'        DBSTAT = Dll_Open(Fno, DBID, tblid)
'        If DBSTAT <> -171 Then Exit Do
'        If Timer > EN_TIME Then
'            sMsg$ = tblid + "のＳＣＭファイルが読めません。"
'            sMsg$ = sMsg$ + vbCrLf + "ファイルや通信の不良等の可能性が有ります。"
'            sMsg$ = sMsg$ + vbCrLf + "再試行（リトライ）しますか？"
'            If MsgBox(sMsg$, vbRetryCancel) = vbCancel Then Exit Do
'            EN_TIME = Timer + 10
'        Else
'            Call Sleep(G_RetryItv) 'DoEvents
'        End If
'    Loop
''Debug.Print Timer
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_Open", Fno)
'    If DBSTAT = 0 Then
'        RsOpened(Fno) = True: DB_PARA(Fno).nDirection = nDir_None
'        If Left$(UCase(DBID), 3) = "USR" Then G_bUSR1_ON = True
'    End If
'End Sub
'
'''Declare Function DB_Close Lib "sssoraif" (Fno as integer) As Long
'Sub DB_Close(Fno As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_Close(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_Close(Fno)
''    bOracle(Fno) = 0
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_Close", Fno)
'    If DBSTAT = 0 Then RsOpened(Fno) = False
'End Sub
'
'''Declare Function DB_Can Lib "sssoraif" (Fno as integer) As Long
'Sub DB_Can(Fno As Integer)
'    If Fno = -1 Then DBSTAT = Dll_Can(Fno): Exit Sub
'    If IS_ORA(Fno) = 0 Then Exit Sub
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_Can(Fno)
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_Can", Fno)
'End Sub
'
'''Declare Function DB_End Lib "sssoraif" () As Long
'Sub DB_End()
'    ' if Ora_DBName$ <> "" And Ora_DBHead$ <> "" Then
'    If Ora_DBStart_FLG <> 0 Then ' 2000.2.14 for 8i
'        DBSTAT = Dll_End
'        Ora_DBStart_FLG = 0
'    Else
'        DBSTAT = 0
'    End If
'    Call JB_End
'End Sub
'
'''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
'Sub DB_BeginTransaction(shareMode As String)
'    Call ResetDBSTAT(-1)
'    Do
'        DBSTAT = Dll_BeginTransaction(0)
'    Loop While IsBusy_ORA("DB_BeginTransaction")
'    If G_bUSR1_ON And DBSTAT = 0 Then
'        Do
'            DBSTAT = DB_LockOn(1)
'        Loop While IsBusy_ORA("DB_BeginTransaction")
'    End If
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then
'        If G_bTranLog = True Then
'            G_nTranStt = Timer
'            Call DB2_UtlGetOraDT
'            G_tmSTT = DB_ORATM
'        End If
'        JB_BeginTransaction 0 'shareMode
'    End If
'End Sub
'
'''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
'Sub DB_BeginTransaction2(shareMode As String)
'    Call ResetDBSTAT(-1)
'    Do
'        DBSTAT = Dll_BeginTransaction(1)
'    Loop While IsBusy_ORA("DB_BeginTransaction2")
'    If G_bUSR1_ON And DBSTAT = 0 Then
'        Do
'            DBSTAT = DB_LockOn(2)
'        Loop While IsBusy_ORA("DB_BeginTransaction2")
'    End If
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then
'        If G_bTranLog = True Then
'            G_nTranStt = Timer
'            Call DB2_UtlGetOraDT
'            G_tmSTT = DB_ORATM
'        End If
'        JB_BeginTransaction 0 'shareMode
'    End If
'End Sub
'
'''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
'Sub DB_BeginTransaction3(shareMode As String)
'    Call ResetDBSTAT(-1)
'    'JB_BeginTransaction 0 'shareMode
'    Do
'        DBSTAT = Dll_BeginTransaction(1)
'    Loop While IsBusy_ORA("DB_BeginTransaction3")
'    If DBSTAT = 0 Then
'        Do
'            DBSTAT = DB_LockOn(3)
'        Loop While IsBusy_ORA("DB_BeginTransaction3")
'    End If
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then
'        If G_bTranLog = True Then
'            G_nTranStt = Timer
'            Call DB2_UtlGetOraDT
'            G_tmSTT = DB_ORATM
'        End If
'        JB_BeginTransaction 0 'shareMode
'    End If
'End Sub
'
'''Declare Function DB_AbortTransaction Lib "sssoraif" () As Long
'Sub DB_AbortTransaction()
'    JB_AbortTransaction
'    Call JB_ErrorCheck("JB_AbortTransaction", -1)
'    DBSTAT = Dll_AbortTransaction
'    Call Ora_ErrorCheck("Dll_AbortTransaction", -1)
'    If G_bUSR1_ON Then Call DB_LockOff(0)
'    Call Ora_ErrorCheck("DB_LockOff", -1)
'    If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog: G_nTranStt = 0
'End Sub
'
'''Declare Function DB_EndTransaction Lib "sssoraif" () As Long
'Sub DB_EndTransaction()
'    JB_EndTransaction
'    Call JB_ErrorCheck("JB_EndTransaction", -1)
'    DBSTAT = Dll_EndTransaction
'    Call Ora_ErrorCheck("Dll_EndTransaction", -1)
'    If G_bUSR1_ON Then Call DB_LockOff(1)
'    Call Ora_ErrorCheck("DB_LockOff", -1)
'    If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog: G_nTranStt = 0
'End Sub
'
''' Nop inside
'''Declare Function JB_ErrorCheck Lib "sssoraif" (ByVal opCode%, tblName As Any) As Long
''????????????????????Sub JB_ErrorCheck(opCode As Integer, tblName As String)
''    DBSTAT = Dll_ErrorCheck(opCode, tblName)
''End Sub
'
'''Declare Function DB_NCCLOSE Lib "sssoraif" (ByVal FNo&) As Long
'Sub DB_NCCLOSE(Fno As Integer)
'    If IS_ORA(Fno, True) = 0 Then Call JB_NCCLOSE(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_NCCLOSE(Fno)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then RsOpened(Fno) = False
'End Sub
'
'''Declare Function DB_NCOPEN Lib "sssoraif" (ByVal FNo&, FileLocation As Any, DBFLocation As Any) As Long
'Sub DB_NCOPEN(Fno As Integer, FileLocation As String, DBFLocation As String)
'    If IS_ORA(Fno, True) = 0 Then Call JB_NCOPEN(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_NCOPEN(Fno, FileLocation, DBFLocation)
'    Call SetDBSTAT(DBSTAT)
'    If DBSTAT = 0 Then RsOpened(Fno) = True: DB_PARA(Fno).nDirection = nDir_None
'End Sub
'
'''Declare Function DB_Unlock Lib "sssoraif" (ByVal FNo&) As Long
'Sub DB_Unlock(Fno As Integer)
'    If IS_ORA(Fno) = 0 Then Call JB_Unlock(Fno): Exit Sub
'    Call ResetDBSTAT(Fno)
'    DBSTAT = Dll_Unlock(Fno)
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_Unlock", Fno)
'End Sub
'
'Function DB_PlStart&(Optional bGetRec_V As Variant)
'    Dim bGetRec&
'    If IsMissing(bGetRec_V) Then bGetRec& = 0 Else bGetRec& = CLng(bGetRec_V)
'    Call ResetDBSTAT(-1)
'    DB_PlStart = Dll_PlStart(G_PlInfo, bGetRec&)
'    Call SetDBSTAT(DB_PlStart)
'    Call Ora_ErrorCheck("DB_PlStart", -1)
'End Function
'
'Function DB_PlFree&()
'    Call ResetDBSTAT(-1)
'    DB_PlFree = Dll_PlFree()
'    Call SetDBSTAT(DB_PlFree)
'    Call Ora_ErrorCheck("DB_PlFree", -1)
'End Function
'
'Function DB_PlSet&(Fno%, RNo%)
'    Call ResetDBSTAT(-1)
'    Call SetBuf(Fno%)
'    DB_PlSet& = Dll_PlSet(Fno%, RNo%, G_LB)
'    '''''Call ResetBuf(FNo)
'    Call SetDBSTAT(DB_PlSet&)
'    Call Ora_ErrorCheck("DB_PlSet", -1)
'End Function
'
'Function DB_PlCndSet&()
'    Dim n%
'    Call ResetDBSTAT(-1)
'    n = IIf(G_bExtCnd, 12, 8)
'    If G_NO_ALTLOG Then G_PlCnd.nCndNum(n) = SSS_NO_ALTOUT
'    LSet G_LB = G_PlCnd
'    DB_PlCndSet& = Dll_PlCndSet(G_LB)
'    Call SetDBSTAT(DB_PlCndSet&)
'    Call Ora_ErrorCheck("DB_PlCndSet", -1)
'End Function
'
'Function DB_PlExec&(Pack_Proc$)
'    Call ResetDBSTAT(-1)
'    LSet G_LB = G_PlCnd2
'    Do
'        DB_PlExec& = Dll_PlExec(Pack_Proc$, G_LB)
'        DBSTAT = DB_PlExec&
'    Loop While IsBusy_ORA("DB_PlExec")
'    LSet G_PlCnd2 = G_LB
'    Call SetDBSTAT(DB_PlExec&)
'End Function
'
'Function DB_PlGetCnt&(Fno%)
'    Call ResetDBSTAT(-1)
'    DB_PlGetCnt& = Dll_PlGetCnt(CLng(Fno))
'    If DB_PlGetCnt& < 0 Then
'        Call SetDBSTAT(DB_PlGetCnt&)
'        Call Ora_ErrorCheck("DB_PlGetCnt", -1)
'    Else
'        Call SetDBSTAT(0)
'        'Call Ora_ErrorCheck("DB_PlGetCnt", -1)
'    End If
'End Function
'
'Function DB_PlGet&(Fno%, Optional RNo_V As Variant)
'    Dim RNo&
'    Call ResetDBSTAT(-1)
'    If IsMissing(RNo_V) Then RNo = -1 Else RNo = CLng(RNo_V)
'    Call SetBuf(Fno%)
'    DB_PlGet& = Dll_PlGet(Fno%, G_LB, RNo&)
'    If DBSTAT = 0 Then Call ResetBuf(Fno%)
'    Call SetDBSTAT(DB_PlGet&)
'    Call Ora_ErrorCheck("DB_PlGet", -1)
'End Function
'
'Function IsBusy_ORA%(opCode As String, Optional LockFlg As Integer)
'    Dim tblName As String
'    Dim Msg$
'    Dim bApp As Boolean
'    '
'    IsBusy_ORA% = 0
'    If DBSTAT = 0 Then Exit Function
'    If G_FNO >= 0 Then tblName = DB_PARA(G_FNO).tblid Else tblName = " "
'    '
'    bApp = False
'    If Not IsMissing(LockFlg) Then
'        If LockFlg = AppLock Then bApp = True
'    End If
'    '
''    If DBSTAT = 60 Then
''        If opCode <> "DB_PlExec" Then Call Ora_ErrorCheck(opCode, G_FNO)
''    End If
'    Select Case DBSTAT
'        Case 54, 56 'when busy
'        'Case 54, 56, 60, -60 'when busy or Dlck
'            'If DBSTAT = 1 And opCode <> "DB_PlExec" Then
'            '    Call Ora_ErrorCheck(opCode, G_FNO)
'            '    Exit Function
'            'End If
'            IsBusy_ORA% = 1
'            DoEvents
'            CurTime@ = Timer
'            If CurTime@ < StTime@ Then StTime@ = CurTime@: EnTime@ = StTime@ + 5
'            If CurTime@ > EnTime@ Then
'                If G_bBusyLog Then Call DB2_BusyLog
'                'If Kbn$ = "E" Then Syori$ = "EDIT" Else If Kbn$ = "U" Then Syori$ = "Update" Else Kbn$ = "Delete"
'                ''Msg$ = Str$(DB_MAXWAITSEC%) + "秒間待ちましたが、ORACLEファイルが使用中です。" + Chr$(13)
'                ''Msg$ = Msg$ + "FILE_ID = (" + tblName + ")  処理 = " + opCode + " コード = " + Str$(DBSTAT) + Chr$(13) + Chr$(13)
'                If bApp Then
'                    Msg$ = "このデータは現在他でロックされています。" + Chr$(13)
'                    Msg$ = Msg$ + "管理者に連絡するか、しばらく待ってから再度処理を行って下さい。" + Chr$(13)
'                    Msg$ = Msg$ + "FILE_ID = (" + tblName + ")  処理 = " + opCode + " コード = " + Str$(DBSTAT) + Chr$(13) + Chr$(13)
'                    Msg$ = Msg$ + "再試行（リトライ）しますか？" + Chr$(13)
'                    Msg$ = Msg$ + "［注意］キャンセルすると、このデータをロックせずに処理に戻ります！"
'                Else
'                    Msg$ = "サーバがビジー状態のため登録処理を行えません。" + Chr$(13)
'                    Msg$ = Msg$ + "管理者に連絡するか、しばらく待ってから再度登録処理を行って下さい。" + Chr$(13)
'                    Msg$ = Msg$ + "FILE_ID = (" + tblName + ")  処理 = " + opCode + " コード = " + Str$(DBSTAT) + Chr$(13) + Chr$(13)
'                    Msg$ = Msg$ + "再試行（リトライ）しますか？" + Chr$(13)
'                    Msg$ = Msg$ + "［注意］キャンセルすると、このデータ"
'                    If opCode <> "DB_PlExec" Then
'                        If G_bRetApp = True And Left$(opCode, 10) = "DB_BeginTr" Then bApp = True: LockFlg = AppLock
'                        If bApp = True Then
'                            Msg$ = Msg$ + "を登録せずに処理に戻ります！"
'                        Else
'                            Msg$ = Msg$ + "を登録せずにプログラムを終了します！"
'                        End If
'                    Else
'                        Msg$ = Msg$ + "を登録せずに画面がクリアされます！"
'                    End If
'                End If
'                If MsgBox(Msg$, vbRetryCancel) = vbCancel Then
'                    IsBusy_ORA% = 0
'                    If opCode <> "DB_PlExec" Then
'                        If bApp = True Then
'                            GoTo IsBusy_ORA_EX
'                        Else
'                            G_bSUP_ERR = True
'                            GoTo IsBusy_ORA_EX
'                            'Call Error_Exit("ORACLE ReTry Error ! [" & tblName & ":" & opCode & ":" & DB_MAXWAITSEC% & "]")
'                        End If
'                    Else
'                        Exit Function
'                    End If
'                Else
'                    StTime@ = Timer
'                    EnTime@ = StTime@ + DB_REALWAITSEC@
'                End If
'            Else
'                Call Sleep(G_RetryItv) 'DoEvents
'            End If
'        Case Else
'            GoTo IsBusy_ORA_EX
'    End Select
'    Exit Function
'    '
'IsBusy_ORA_EX:
'    If bApp = False Then
'        Call Ora_ErrorCheck(opCode, G_FNO)
'    Else
'        Call Ora_ErrorCheck(opCode, G_FNO, LockFlg)
'    End If
'End Function
'
'Function DB_LockOn&(nSyu%)
'    Dim sSyu$, sSQL$, nUNICNT&
'    DBSTAT = 0
'    sSyu$ = Switch(nSyu% = 1, G_sRRRLock, nSyu% = 2, G_sRRRLock2, nSyu% = 3, G_sRRRLock3)
'    If sSyu$ <> "" Then
'        sSQL$ = "LOCK TABLE SYSTBL IN " + sSyu$ + " MODE NOWAIT"
'        '''Do-2.3.0.3
'        If sSyu$ = "TPA" Then
'            nUNICNT& = G_nUNICNT&
'            DBSTAT = Dll_TpaLock(G_sUNIID$, nUNICNT&)
'            If DBSTAT = 1403 Then
'                nUNICNT& = G_nUNICNT&
'                DBSTAT = Dll_TpaIns(G_sUNIID$, nUNICNT&, G_sOPEID$, _
'                    G_sCLTID$, Format$(Time, "hhmmss"), Format$(Date, "yyyymmdd"))
'                If DBSTAT = 1 Then DBSTAT = 0
'                If DBSTAT = 0 Then DBSTAT = 54
'            End If
'        Else
'            DBSTAT = Dll_Usr1Exec(sSQL$)
'        End If
'        '''Loop While IsBusy_ORA("DB_LockOn")
'    End If
'    DB_LockOn& = DBSTAT
'End Function
'
'Sub DB2_BusyLog()
'    If G_bTool Then Exit Sub
'    Dim sFName$, sMsg$, swk$
'    Dim IMA
'    sFName$ = TRAN_LOG_PATH$ + "BUSY.LOG"
'    If DB_REALWAITSEC = DB_MAXWAITSEC Then sMsg$ = "tp=BUSY" Else sMsg$ = "tp=LOCK"
'    sMsg$ = sMsg$ + ", clid=" + G_sCLTID$
'    sMsg$ = sMsg$ + ", pid=" + Format$(G_sPRGID, "!@@@@@@@@@@")
'    swk$ = Space$(10) + Format$(DB_REALWAITSEC * 1000, "##########")
'    sMsg$ = sMsg$ + ", ms=" + Right$(swk$, 10)
'    'sMsg$ = sMsg$ + ", tm=" + Format$(Time, "hhmmss")
'    'sMsg$ = sMsg$ + ", dt=" + Format$(Date, "yyyymmdd")
'    Call DB2_UtlGetOraDT
'    swk$ = Left(DB_ORADT, 2) + "/" + Mid(DB_ORADT, 3, 2) + "/" + Right(DB_ORADT, 2) + " "
'    swk$ = swk$ + Left(DB_ORATM, 2) + ":" + Mid(DB_ORATM, 3, 2) + ":" + Right(DB_ORATM, 2)
'    IMA = CDate(swk$) - DB_REALWAITSEC / nSecOfDay#
'    sMsg$ = sMsg$ + ", st=" + Format$(IMA, "hhmmss")
'    sMsg$ = sMsg$ + ", et=" + DB_ORATM
'    sMsg$ = sMsg$ + ", dt=" + DB_ORADT
'    sMsg$ = sMsg$ + ", pn=" + G_sPRGNM
'    If DB_REALWAITSEC = DB_MAXWAITSEC Then sMsg$ = sMsg$ + ", tpa=" + G_sUNIID$
'    Call DB3_OutBusyLog(sFName$, sMsg$)
'End Sub
'
'Sub DB2_TranLog()
'    If G_bTool Then Exit Sub
'    Dim sFName$, sMsg$, swk$, nTranMS&
'    nTranMS = (Timer - G_nTranStt) * 1000
'    sFName$ = TRAN_LOG_PATH$ + "TRAN.LOG"
'    sMsg$ = "tp=TRAN, clid=" + G_sCLTID$
'    sMsg$ = sMsg$ + ", pid=" + Format$(G_sPRGID, "!@@@@@@@@@@")
'    swk$ = Space$(10) + Format$(nTranMS, "##########")
'    sMsg$ = sMsg$ + ", ms=" + Right$(swk$, 10)
'    sMsg$ = sMsg$ + ", st=" + G_tmSTT
'    Call DB2_UtlGetOraDT
'    sMsg$ = sMsg$ + ", et=" + DB_ORATM
'    sMsg$ = sMsg$ + ", dt=" + DB_ORADT
'    sMsg$ = sMsg$ + ", pn=" + G_sPRGNM
'    sMsg$ = sMsg$ + ", tpa=" + G_sUNIID$
'    Call DB3_OutBusyLog(sFName$, sMsg$)
'End Sub
'
'Sub DB3_OutBusyLog(sFName$, sMsg$)
'    Dim nErr&
'    On Error Resume Next
'    Do
'        Err.Clear
'        Open sFName$ For Append Lock Write As #1
'        nErr = Err
'        If nErr = 70 Then Call Sleep(G_RetryItv / 10) 'DoEvents
'    Loop While (nErr = 70)
'    Print #1, sMsg$
'    Close #1
'End Sub
'
''Sub Put_SYSTBL()
''    Dim sSQL$
''    sSQL$ = "INSERT INTO SYSTBL VALUES('" + G_sUNIID$ + "', 'Auto Inserted', '" _
''            + G_sOPEID$ + "', '" + G_sCLTID$ + "', '" _
''            + Format$(Time, "hhmmss") + "', '" + Format$(Date, "yyyymmdd") + "')"
''    Do
''        DBSTAT = Dll_Usr1Exec(sSQL$)
''        If DBSTAT = 1 Then DBSTAT = 0
''    Loop While IsBusy_ORA("Put_SYSTBL")
''End Sub
'
'Function DB_LockOff&(bIsCommit%)
'    Dim sSQL$
'    DB_LockOff& = 0
'    'If IsMissing(bIsCommit%) Then bIsCommit% = 0
'    'If G_sRRRLock <> "" Or G_sRRRLock2 <> "" Then
'    If G_sRRRLock <> "" Or G_sRRRLock2 <> "" Or G_sRRRLock3 <> "" Then
'        If bIsCommit% Then
'            sSQL$ = "COMMIT"
'        Else
'            sSQL$ = "ROLLBACK"
'        End If
'        Do
'            DBSTAT = Dll_Usr1Exec(sSQL$)
'        Loop While IsBusy_ORA("DB_LockOff")
'    End If
'    DB_LockOff& = DBSTAT
'End Function
'
'''Declare Function DB_ChgMode Lib "sssoraif" (ByVal sMode$) As Long
'Sub DB_ChgMode(sMode As String)
'    Call ResetDBSTAT(-1)
'    DBSTAT = Dll_ChgMode(sMode)
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_ChgMode", -1)
'End Sub
'
'''Declare Function DB_ClrMode Lib "sssoraif" () As Long
'Sub DB_ClrMode()
'    Call ResetDBSTAT(-1)
'    DBSTAT = Dll_ClrMode()
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_ClrMode", -1)
'End Sub
'
''Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno&, ByVal sDT$, ByVal sTM$) As Long
'Sub DB_GetOraDT(Fno As Integer)
'    If Fno >= 0 Then If IS_ORA(Fno) = 0 Then Call Error_Exit("ファイルＮＯが無効です。:Fno=" + Str$(Fno))
'    DB_ORADT = "        "
'    DB_ORATM = "      "
'    DBSTAT = Dll_GetOraDT(Fno, DB_ORADT, DB_ORATM)
'    DB_ORADT = Left(DB_ORADT, 8)
'    DB_ORATM = Left(DB_ORATM, 6)
'End Sub
'
'Sub DB2_UtlGetOraDT()
'    DB_ORADT = "        "
'    DB_ORATM = "      "
'    If G_bTool Then Exit Sub
'    Call Dll_GetOraDT(-1, DB_ORADT, DB_ORATM)
'    DB_ORADT = Left(DB_ORADT, 8)
'    DB_ORATM = Left(DB_ORATM, 6)
'End Sub
'
'Sub DB_SetPGID(sPGID As String)
'    Call ResetDBSTAT(-1)
'    DBSTAT = Dll_SetPGID(sPGID)
'    If DBSTAT = 0 Then
'        G_sPRGID$ = Trim(sPGID)
'        If G_sRRRLock = "TPA" Or G_sRRRLock2 = "TPA" Or G_sRRRLock3 = "TPA" Then Call GetTPA_Info
'    End If
'    If Len(G_sPRGID) < 7 Then G_bTool = True Else G_bTool = False
'    Call SetDBSTAT(DBSTAT)
'    Call Ora_ErrorCheck("DB_SetPGID", -1)
'End Sub
'
'Sub DB_SetPGNM(sPGNM As String)
'    Call ResetDBSTAT(-1)
'    G_sPRGNM$ = Trim(sPGNM)
'    Call SetDBSTAT(DBSTAT)
'End Sub
'
'Sub GetTPA_Info()
'    Dim sBUF$
'    Dim bErr As Boolean
'    bErr = False
'    G_sUNIID$ = "": G_nUNICNT& = 0
'    On Error GoTo ERR1
'    Open USR_PATH$ + "DAT\" + G_sPRGID$ + ".TPA" For Input As #1
'    Do While EOF(1) = False
'        Line Input #1, sBUF$
'        If Len(sBUF$) > 2 And Left$(sBUF$, 1) = "'" And Right$(sBUF$, 1) = "'" Then
'            If G_nUNICNT& Then G_sUNIID$ = G_sUNIID$ + ","
'            G_sUNIID$ = G_sUNIID$ + sBUF$
'            G_nUNICNT& = G_nUNICNT& + 1
'        Else
'            bErr = True
'            Err.Raise 1
'            'G_sUNIID$ = "": G_nUNICNT& = 0: Exit Do
'        End If
'    Loop
'ERR1:
'    If Err Then bErr = True: G_sUNIID$ = "": G_nUNICNT& = 0
'    Close #1
'    On Error GoTo 0
'    If G_sUNIID$ = "" Then
'        If bErr Then
'            G_sRRRLock = "EXCLUSIVE"
'            G_sRRRLock2 = "EXCLUSIVE"
'            G_sRRRLock3 = "EXCLUSIVE"
'            MsgBox ("排他制御用の　TPA:" + G_sPRGID$ + ".TPA" _
'                + " ファイルが読み込めません。" + Chr$(13) + "管理者に連絡して下さい。")
'        Else
'            G_sRRRLock = ""
'            G_sRRRLock2 = ""
'            G_sRRRLock3 = ""
'        End If
'    End If
'End Sub
'
