Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System
Imports System.Reflection

Module BasOraJet
    '
    ' ------------------------------------------------------------------
    ' 必ず SSSORAIF.DLL のバージョン(前3桁)と合わせる事！
    Public Const sBAS_VER As String = "3.0.1.26" '2003.08.28A

    ' ------------------------------------------------------------------
    '
    '以下２行は SSSWIN.BAS で宣言しているため不要
    'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
    'Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Integer, ByVal lpFileName As String) As Long
    '以下は 16bit API
    'Declare Function GetPrivateProfileString Lib "Kernel" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    'Declare Function WritePrivateProfileString Lib "Kernel" (ByVal lpApplicationName As String, ByVal lpKeyName As Integer, ByVal lpString As String, ByVal lpFileName As String) As Integer

    'Declare Function GETPTR Lib "sssbtrif.DLL" (DataBuf As Integer) As Long
    '
    ''Start: Delare Export Functions in sssoraif.dll
    '' Getting Data

    '20190219
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    'Declare Function Dll_GetFirst Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetNext Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetPre Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetLast Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetGrEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetGr Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetLs Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetLsEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_GetSQL Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal sqlStmt As String, ByRef ExtNum As Integer) As Integer
    '   Declare Function Dll_Execute Lib "sssoraif" (ByVal Fno As Integer, ByVal sqlStmt As String) As Integer

    '   '' Deleting , Inserting and Updating Data
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_Delete Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_Insert Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_Update Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer, ByVal KeyNo As Integer, ByVal keyVal As String) As Integer

    '   '' Others
    '   Declare Function Dll_Stat Lib "sssoraif" (ByVal Fno As Integer, ByRef xxx As Integer) As Integer
    '   Declare Function Dll_Start Lib "sssoraif" (ByVal sCon As String, ByVal sHead As String) As Integer
    '   Declare Function Dll_ChkVer Lib "sssoraif" (ByVal sVer As String) As Integer
    '   Declare Function Dll_RESET Lib "sssoraif" () As Integer
    '   Declare Function Dll_Stop Lib "sssoraif" () As Integer
    '   Declare Function Dll_Open Lib "sssoraif" (ByVal Fno As Integer, ByVal DBID As String, ByVal tblid As String) As Integer
    '   Declare Function Dll_Close Lib "sssoraif" (ByVal Fno As Integer) As Integer
    '   Declare Function Dll_Can Lib "sssoraif" (ByVal Fno As Integer) As Integer
    '   Declare Function Dll_End Lib "sssoraif" () As Integer
    '   Declare Function Dll_BeginTransaction Lib "sssoraif" (ByVal shareMode As Integer) As Integer
    '   Declare Function Dll_AbortTransaction Lib "sssoraif" () As Integer
    '   Declare Function Dll_EndTransaction Lib "sssoraif" () As Integer
    '   Declare Function Dll_Usr1Exec Lib "sssoraif" (ByVal pSql As String) As Integer
    '   Declare Function Dll_TpaLock Lib "sssoraif" (ByVal pSql As String, ByRef nProc As Integer) As Integer
    '   Declare Function Dll_TpaIns Lib "sssoraif" (ByVal pSql As String, ByRef nProc As Integer, ByVal sOP As String, ByVal sCL As String, ByVal sTM As String, ByVal sDT As String) As Integer
    '   Declare Function Dll_GetPassWD Lib "sssoraif" (ByVal nUsrNo As Integer, ByVal passWD As String) As Integer
    '   Declare Function Dll_ChgMode Lib "sssoraif" (ByVal sMode As String) As Integer
    '   Declare Function Dll_ClrMode Lib "sssoraif" () As Integer
    '   Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno As Integer, ByVal sDT As String, ByVal sTM As String) As Integer
    '   Declare Function Dll_SetPGID Lib "sssoraif" (ByVal sPrgId As String) As Integer

    '   '' Calling Interface for PL/SQL
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_PlStart Lib "sssoraif" (ByRef pPl_Info As Integer, ByVal bGetRec As Integer) As Integer
    '   Declare Function Dll_PlFree Lib "sssoraif" () As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_PlSet Lib "sssoraif" (ByVal Fno As Integer, ByVal RNo As Integer, ByRef pBuff As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_PlCndSet Lib "sssoraif" (ByRef pBuff As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_PlExec Lib "sssoraif" (ByVal pSql As String, ByRef pBuff As Integer) As Integer
    '   Declare Function Dll_PlGetCnt Lib "sssoraif" (ByVal Fno As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_PlGet Lib "sssoraif" (ByVal Fno As Integer, ByRef pBuff As Integer, ByVal RNo As Integer) As Integer

    '   '' Nop inside
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_ErrorCheck Lib "sssoraif" (ByVal opCode As Short, ByRef tblName As Integer) As Integer
    '   Declare Function Dll_NCCLOSE Lib "sssoraif" (ByVal Fno As Integer) As Integer
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_NCOPEN Lib "sssoraif" (ByVal Fno As Integer, ByRef FileLocation As Integer, ByRef DBFLocation As Integer) As Integer
    'Declare Function Dll_Unlock Lib "sssoraif" (ByVal Fno As Integer) As Integer

    ' '' Exception (Header with "DB_")
    '   'UPGRADE_ISSUE: パラメータ 'As Integer' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '   Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Integer) As Integer

    'Declare Function sOraErrMsg Lib "sssoraif" (ByVal nErr As Integer, ByVal sMsg As String) As Integer

    'Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    ' ''End: Declare

    Private WRK_PATH As String
    Private USR2 As String

    Private Section As String
    Private Entry As String
    Private IniFileName As String
    Private USR_PATH As String
    Private EXT_PATH As String

    Private DB_StTime As Object

    Public Const DB_Err_Busy As Short = 999

    Structure TYPE_DB_PARA
        Dim RecLength As Short
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(256), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=256)> Public KeyBuf As String
        Dim KeyNo As Short
        Dim tblid As String 'テーブル名
        Dim Status As Short
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public DBID As String
        Dim DBNo As Short
        Dim nDirection As Short
    End Structure

    Structure TYPE_KeySeg
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(12), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=12)> Public KeyName As String
        Dim ItmCnt As Short
        'ItmName(9) As String * 8
        'bKb(9)   As Integer
        <VBFixedArray(9)> Dim ItmLen() As Short
        <VBFixedArray(9)> Dim ItmPos() As Short

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim ItmLen(9)
            ReDim ItmPos(9)
        End Sub
    End Structure

    Structure TYPE_KeyIndex
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public tblName As String
        Dim KeyCnt As Short
        'UPGRADE_WARNING: 配列 Seg で各要素を初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"' をクリックしてください。
        <VBFixedArray(9)> Dim Seg() As TYPE_KeySeg

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_DB_GetEq(DB_GetEcommoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim Seg(9)
        End Sub
    End Structure

    Public Const RecNoLock As Short = 0 ' 汎用 レコードロックパラメータ
    Public Const RecLock As Short = -1 '    上に同じ

    '旧インターフェイス
    Public Const NCCNo As Short = -1 ' No-Currency-Change オプション値DB_GetEq(
    Public Const BtrNormal As Short = 0 ' Btrieve レコードロックパラメータ
    Public Const BtrLock As Short = -1 '    上に同じ
    Public Const AppLock As Short = 777 ' アプリによるロックチェック用
    Public BtrMaxReTryCnt As Short ' 最大リトライ回数
    Public BtrRetry As Short ' リトライ回数カウント変数
    Public DBSTAT As Integer ' ファイルステータス
    Public Const BTR_Exclude As Short = 0
    Public Const BTR_Share As Short = 1000
    Private DB_MAXWAITSEC, DB_APPWAITSEC As Short
    Private DB_REALWAITSEC As Decimal
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

    Public Const dbsMAX As Short = 25
    Public Const rstMAX As Short = 200
    'Public Const SSS_MAX_DB = dbsMAX '???????????

    Private DicPath As String

    Structure TYPE_DB_SPEC
        Dim sID As String
        Dim sLoc As String
        Dim bOra As Short
        Dim bReged As Short
        Dim bLogin As Short
        Dim Jet_DB As DAO.Database
    End Structure
    Private DB_Spec(dbsMAX) As TYPE_DB_SPEC

    Public Jet_WS As DAO.Workspace ' ワークスペース
    'Public Jet_DB(dbsMAX) As Database
    'Public DbOpened(dbsMAX) As Integer  '
    Public JET_RS(rstMAX) As DAO.Recordset
    'Private bOracle(rstMAX) As Integer  ' 変数を宣言します。
    Public RsOpened(rstMAX) As Short '
    'UPGRADE_WARNING: 配列 KeyIndex で各要素を初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"' をクリックしてください。
    Public KeyIndex(rstMAX) As TYPE_KeyIndex '  Index定義
    Public Jet_Td As DAO.TableDef
    Public Jet_SQL As String
    Public G_Fld(rstMAX, 200) As Object
    Private G_FNO As Short
    Private ret As Short
    Private G_NO_ALTLOG As Short
    Public Const SSS_NO_ALTOUT As Short = -9999

    Private NoCheck As Short
    Public Const Jet_NoErr As Short = 0
    Public Const Jet_OpnErr As Short = -1
    Public Const Jet_NoMAtch As Short = -8
    Public Const Jet_EOF As Short = -9
    Public Const Jet_BOF As Short = -10

    Public Const Cn_NoCommit As Short = -9999 'PL/SQLでコミットしない

    Structure T_0
        <VBFixedArray(16 * 1024)> Dim tgLB1() As Byte
        <VBFixedArray(4 * 1024)> Dim tgLB2() As Byte 'Pre=16
        'tgLB3(4 * 1024) As Byte

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim tgLB1(16 * 1024)
            ReDim tgLB2(4 * 1024)
        End Sub
    End Structure
    'UPGRADE_WARNING: 構造体 0 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Public G_LB As T_0

    Structure T_PlInfo
        Dim FCnt As Integer
        <VBFixedArray(9)> Dim Fno() As Integer
        <VBFixedArray(9)> Dim RCnt() As Integer
        <VBFixedArray(9)> Dim ArrayFlg() As Integer ' 非0 = Array, 0 = スカラ型
        <VBFixedArray(9)> Dim RMax() As Integer

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim Fno(9)
            ReDim RCnt(9)
            ReDim ArrayFlg(9)
            ReDim RMax(9)
        End Sub
    End Structure
    'UPGRADE_WARNING: 構造体 0 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Public G_PlInfo As T_PlInfo

    Public Const MAX_CNDARR As Short = 14 'Pre=10/Lim=19
    Structure T_PlCnd
        Dim nJobMode As Integer
        'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        Dim sCndStr() As String '*512
        <VBFixedArray(MAX_CNDARR - 1)> Dim nCndNum() As Decimal
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public sOpeID As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public sCltID As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(512), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=512)> Public sErrMsg As String

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim nCndNum(MAX_CNDARR - 1)
        End Sub
    End Structure
    'UPGRADE_WARNING: 構造体 G_PlCnd の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '2019/03/25 CHG START
    'Public G_PlCnd As String 'T_PlCnd
    Public G_PlCnd As T_PlCnd 'T_PlCnd
    '2019/03/25 CHG E N D
    'UPGRADE_WARNING: 構造体 G_PlCnd2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '2019/03/25 CHG START
    'Public G_PlCnd2 As String 'T_PlCnd
    Public G_PlCnd2 As T_PlCnd 'T_PlCnd
    '2019/03/25 CHG E N D
    Private G_bExtCnd As Boolean

    Public Const nDir_None As Short = 0
    Public Const nDir_Fore As Short = 1
    Public Const nDir_Back As Short = 2

    Structure KeySpec
        Dim KeyPos As Short
        Dim KeyLen As Short
        Dim KeyFlags As Short
        Dim KeyTot As Integer
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public KeyType As String
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public Reserved As String
    End Structure

    Structure TYPE_StatFileSpecs
        Dim RecLen As Short
        Dim PageSize As Short
        Dim IndexTot As Short
        Dim RecTot As Integer
        Dim FileFlags As Short
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public Reserved As String
        Dim UnusedPages As Short
        <VBFixedArray(119)> Dim KeyBuf() As KeySpec

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim KeyBuf(119)
        End Sub
    End Structure

    'UPGRADE_WARNING: 構造体 StatFileBuffer の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Public StatFileBuffer As TYPE_StatFileSpecs

    Structure TYPE_DB_EXTRA_NUM
        <VBFixedArray(9)> Dim ExtNum() As Decimal

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim ExtNum(9)
        End Sub
    End Structure
    'UPGRADE_WARNING: 構造体 0 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Public DB_ExtNum As TYPE_DB_EXTRA_NUM

    Public DB_SQLBUFF As String
    Public DB_ORADT As String
    Public DB_ORATM As String
    Private Const Ora_Connect As String = "_USR1/P"
    Private Ora_DBHead, Ora_DBName, Ora_Connect1 As String
    Private Ora_DBStart_FLG As Short
    Private EnTime, StTime, CurTime As Decimal
    Private G_sRRRLock As String
    Private G_sRRRLock2 As String
    Private G_sRRRLock3 As String
    Private G_RetryItv As Integer
    Private G_sFields As String
    Private nErr As Integer
    Private G_sUNIID As String
    Private G_nUNICNT As Integer
    Private G_sPRGID As String
    Private G_sPRGNM As String
    Private G_sOPEID As String
    Private G_sCLTID As String
    Private G_sErrMsg As String
    Private G_bRetApp As Boolean
    Private G_bORA_RPS As Boolean
    Private G_bORA_RPS_EXT As Boolean
    Private G_bUSR1_ON As Boolean
    Private G_bSUP_ERR As Boolean
    Private G_bBusyLog As Boolean
    Private G_bTranLog As Boolean
    Private G_nTranStt As Decimal
    Private TRAN_LOG_PATH As String
    Private G_tmSTT As String
    Private Const nSecOfDay As Double = 24 * 3600.0#
    Private G_bTool As Boolean

    Private Sub ResetExtNum()
        Dim I As Short
        '2019.03.29 ADD START
        ReDim DB_ExtNum.ExtNum(9)
        '2019.03.29 ADD END
        With DB_ExtNum
            For I = 0 To 9 : .ExtNum(I) = 0 : Next I
        End With
    End Sub

    Public Sub JB_AbortTransaction()
        On Error Resume Next
        Err.Clear()
        DBSTAT = 0
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsDBNull(Jet_WS.Databases) Then Return
        Jet_WS.Rollback()
        DBSTAT = Err.Number
        Call JB_ErrorCheck("AbortTransaction", 0)
    End Sub

    ' エラー汎用ルーチン
    '20190617 chg start
    'Sub DB_ErrorCheck(ByRef opCode As String, ByRef Fno As Short) 'TblName As String)
    Sub DB_ErrorCheck(ByRef opCode As String, ByRef Fno As Object) 'TblName As String)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno, True) Then
        '    Call Ora_ErrorCheck(opCode, Fno)
        'Else
        '    Call JB_ErrorCheck(opCode, Fno)
        'End If
        '20190617 del end
    End Sub

    Sub DB_MsgBox(ByRef Msg As String)
        On Error Resume Next
        Err.Clear()
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(Jet_WS.Databases) = False Then Jet_WS.Rollback()
        Err.Clear()
        'Call DB_LockOff2

        '20190219
        'DBSTAT = Dll_AbortTransaction
        If Msg <> "" And G_bSUP_ERR = False Then Call MsgBox(Msg)
    End Sub

    '20190617 chg start
    'Sub JB_ErrorCheck(ByRef opCode As String, ByRef Fno As Short) 'TblName As String)

    Sub JB_ErrorCheck(ByRef opCode As String, ByRef Fno As Object) 'TblName As String)
        '20190617 chg end
        '2019/04/26 DEL START
        'Dim tblName As String
        'Dim nHantei As Short
        'Dim sErrMsg As String

        'If Fno >= 0 Then tblName = DB_PARA(Fno).tblid

        ''
        'nHantei = 0
        'Select Case DBSTAT
        '    'Case 0, Jet_BOF, Jet_EOF, Jet_NoMAtch
        '    Case 0, Jet_NoMAtch
        '    Case 3021
        '        If opCode = "GetNext" Or opCode = "GetPre" Then DBSTAT = Jet_EOF Else nHantei = 9
        '    Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
        '        nHantei = 1
        '    Case Else
        '        nHantei = 9
        'End Select
        'Select Case nHantei
        '    Case 1
        '        sErrMsg = "Jet ReTry Error ! [" & tblName & ":" & opCode & ":" & Str(DB_MAXWAITSEC) & "]" & ErrorToString()
        '        DB_MsgBox("")
        '        Call Error_Exit(sErrMsg)
        '        System.Windows.Forms.Application.DoEvents()
        '    Case 9
        '        sErrMsg = "Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & ErrorToString()
        '        DB_MsgBox("Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & Chr(13) & ErrorToString())
        '        Call Error_Exit(sErrMsg)
        '    Case Else
        'End Select
        '2019/04/26 DEL E N D
    End Sub

    '20190617 chg start
    'Sub Ora_ErrorCheck(ByRef opCode As String, ByRef Fno As Short, Optional ByRef LockFlg As Short = 0) 'TblName As String)
    Sub Ora_ErrorCheck(ByRef opCode As String, ByRef Fno As Object, Optional ByRef LockFlg As Short = 0) 'TblName As String)

        '20190617 chg end
        '2019/05/08 DEL START
        'Dim tblName As String
        'Dim Msg As String
        'Dim sErrMsg As String
        'Dim sErrMsg2 As String
        'If Fno >= 0 Then tblName = DB_PARA(Fno).tblid Else tblName = " "
        ''
        'If opCode = "DB_Start" Or opCode = "DB_Open" Then
        '    Msg = ""
        '    Select Case DBSTAT
        '        Case 0
        '        Case 1 'Call Han_msgINFO("テスト環境です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case 2 'Call Han_msgINFO("評価版です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case -1
        '            Msg = "環境が未設定です！"
        '        Case -2
        '            Msg = "古い環境です！"
        '        Case -3
        '            Msg = "環境が違います！"
        '        Case -4
        '            Msg = "現在使用できません！"
        '        Case -5
        '            Msg = "環境情報が壊れています！"
        '        Case -6
        '            Msg = "同時実行版ライセンスが登録されていません！"
        '        Case -7
        '            Msg = "同時実行版ライセンスが壊れています！"
        '        Case -8
        '            Msg = "ユーザ名称が違います！"
        '        Case -9
        '            Msg = "ライセンスの最大ユーザ数を超えました！"
        '        Case -10
        '            Msg = "データベースに接続できません！"
        '        Case -11
        '            Msg = "接続許可が得られません！"
        '        Case Else
        '            If DBSTAT < 0 Then
        '                Msg = "環境エラーです！"
        '            Else
        '                Msg = "ＤＢエラーです！"
        '            End If
        '    End Select
        '    If Msg <> "" Then
        '        sErrMsg = "Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
        '        'MsgBox "Ora  Error " & Msg$ & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"

        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
        '        MsgBox(sErrMsg)
        '        Call Error_Exit("Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]")
        '    End If
        'End If

        'Select Case DBSTAT
        '    '   OK,  EOF, NULL
        '    Case 0, 1403, 1405
        '        G_sErrMsg = "ORA:" & Str(DBSTAT)
        '    Case Else
        '        If opCode = "DB_PlExec" Then Exit Sub
        '        sErrMsg = "Ora  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"

        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2

        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then G_sErrMsg = sErrMsg : Exit Sub
        '        End If
        '        DB_MsgBox(sErrMsg)
        '        'DBSTAT = Dll_AbortTransaction
        '        Call Error_Exit(sErrMsg)
        'End Select
        '2019/05/08 DEL E N D
    End Sub

    Sub DB_APP_END()
        DB_MsgBox(G_sErrMsg)
        Call Error_Exit(G_sErrMsg)
    End Sub

    Public Sub JB_BeginTransaction(ByRef shareMode As Short)
        On Error Resume Next
        Err.Clear()
        DBSTAT = 0
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsDBNull(Jet_WS.Databases) Then Return
        Jet_WS.BeginTrans()
        DBSTAT = Err.Number
        Call JB_ErrorCheck("BeginTransaction", 0)
    End Sub

    Public Sub JB_Close(ByRef Fno As Short)
        '2019/05/08 DEL START
        'Dim I As Short
        'On Error Resume Next
        'Err.Clear()
        'If RsOpened(Fno) Then
        '    For I = 0 To JET_RS(Fno).Fields.Count - 1
        '        'UPGRADE_NOTE: オブジェクト G_Fld() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '        G_Fld(Fno, I) = Nothing
        '    Next I
        '    JET_RS(Fno).Close()
        '    'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '    JET_RS(Fno) = Nothing
        '    RsOpened(Fno) = False
        'End If
        'DBSTAT = Err.Number
        'DB_PARA(Fno).Status = DBSTAT
        'If NoCheck = False Then Call JB_ErrorCheck("Close", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_DELETE(ByRef Fno As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        'Call JT_OutPut(Fno, "D")
        'DBSTAT = nErr
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("Delete", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_DelAll(ByRef Fno As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        'With DB_Spec(DB_PARA(Fno).DBNo)
        '    .Jet_DB.Execute(("DELETE FROM " & DB_PARA(Fno).tblid))
        '    DBSTAT = Err.Number
        '    DB_PARA(Fno).Status = DBSTAT
        '    Call JB_ErrorCheck("DelAll", Fno)
        'End With
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_Execute(ByRef Fno As Short, ByRef sqlStmt As String)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        'With DB_Spec(DB_PARA(Fno).DBNo)
        '    .Jet_DB.Execute((sqlStmt))
        '    DBSTAT = Err.Number
        '    DB_PARA(Fno).Status = DBSTAT
        '    Call JB_ErrorCheck("Execute", Fno)
        'End With
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_End()
        Dim I, J As Short
        On Error Resume Next
        Err.Clear()
        For I = 0 To rstMAX
            If RsOpened(I) Then
                If Not IS_ORA(I) Then
                    For J = 0 To JET_RS(I).Fields.Count - 1
                        'UPGRADE_NOTE: オブジェクト G_Fld() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                        G_Fld(I, J) = Nothing
                    Next J
                    JET_RS(I).Close()
                    'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    JET_RS(I) = Nothing
                    RsOpened(I) = False
                End If
            End If
        Next I
        For I = 0 To dbsMAX
            With DB_Spec(I)
                If .sID < "0" Then Exit For
                If Not (.Jet_DB Is Nothing) Then
                    .Jet_DB.Close()
                    'UPGRADE_NOTE: オブジェクト DB_Spec().Jet_DB をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
                    .Jet_DB = Nothing
                    .bLogin = False
                End If
            End With
        Next I
        If Not (Jet_WS Is Nothing) Then
            Jet_WS.Close()
            'UPGRADE_NOTE: オブジェクト Jet_WS をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            Jet_WS = Nothing
        End If
    End Sub

    Public Sub JB_EndTransaction()
        On Error Resume Next
        Err.Clear()
        DBSTAT = 0
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsDBNull(Jet_WS.Databases) Then Return
        Jet_WS.CommitTrans()
        DBSTAT = Err.Number
        Call JB_ErrorCheck("EndTransaction", 0)
    End Sub

    Public Sub JB_GetEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = JT_Get(Fno, "=", KeyNo, keyVal, LockFlg)
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetEq", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Function JT_Get(ByVal Fno As Short, ByVal Rel As String, ByVal KeyNo As Short, ByVal keyVal As String, ByRef LockFlg As Short) As Short
        '2019/04/11 DEL START
        'Dim k(9) As String
        'Dim ofs, I, Vlen As Short
        'On Error Resume Next
        'Err.Clear()
        'If JET_RS(Fno).Type <> DAO.RecordsetTypeEnum.dbOpenTable Then
        '    JET_RS(Fno).Close()
        '    'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '    JET_RS(Fno) = Nothing
        '    With DB_Spec(DB_PARA(Fno).DBNo)
        '        JET_RS(Fno) = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, DAO.RecordsetTypeEnum.dbOpenTable)
        '        For I = 0 To JET_RS(Fno).Fields.Count - 1
        '            G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
        '        Next I
        '    End With
        'End If
        'JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
        ''UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Vlen = LenWid(keyVal)
        'With KeyIndex(Fno).Seg(KeyNo - 1)
        '    ofs = 1
        '    For I = 0 To .ItmCnt - 1
        '        k(I) = ""
        '        If Vlen >= ofs Then k(I) = MidWid(keyVal, ofs, .ItmLen(I))
        '        ofs = ofs + .ItmLen(I)
        '    Next I
        'End With
        'Select Case I
        '    Case 1 : JET_RS(Fno).Seek(Rel, k(0))
        '    Case 2 : JET_RS(Fno).Seek(Rel, k(0), k(1))
        '    Case 3 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2))
        '    Case 4 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3))
        '    Case 5 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4))
        '    Case 6 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5))
        '    Case 7 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6))
        '    Case 8 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7))
        '    Case 9 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8))
        '    Case Else : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8), k(9))
        'End Select
        'If Err.Number = 0 Then
        '    If JET_RS(Fno).NoMatch Then
        '        JT_Get = Jet_NoMAtch
        '    Else
        '        nErr = 0
        '        If LockFlg Then Call JT_OutPut(Fno, "E")
        '        If nErr = 0 Then
        '            JT_Get = Jet_NoErr
        '            DB_PARA(Fno).KeyNo = KeyNo
        '            Call RecordFromObject(Fno)
        '            If Err.Number = 0 Then Call KeyFromObject(Fno) Else JT_Get = Err.Number
        '        Else
        '            JT_Get = nErr
        '        End If
        '    End If
        'Else
        '    JT_Get = Err.Number
        'End If
        ''2019/04/11 DEL E N D
    End Function

    Sub JT_OutPut(ByRef Fno As Short, ByRef Kbn As String)
        '2019/05/08 DEL START
        ''    Dim StTime@, EnTime@, CurTime@
        'Dim Msg, Syori As String
        ''
        'StTime = VB.Timer()
        'EnTime = StTime + DB_MAXWAITSEC
        'Do
        '    On Error Resume Next
        '    'Err.Clear
        '    Select Case Kbn
        '        Case "E"
        '            JET_RS(Fno).Edit()
        '        Case "U"
        '            JET_RS(Fno).Update()
        '        Case "D"
        '            JET_RS(Fno).Delete()
        '    End Select
        '    nErr = Err.Number
        '    On Error GoTo 0
        '    '
        '    Select Case nErr
        '        Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
        '            System.Windows.Forms.Application.DoEvents()
        '            CurTime = VB.Timer()
        '            If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
        '            If CurTime > EnTime Then
        '                If Kbn = "E" Then Syori = "EDIT" Else If Kbn = "U" Then Syori = "Update" Else Kbn = "Delete"
        '                Msg = Str(DB_MAXWAITSEC) & "秒間待ちましたが、Jetファイルが使用中です。" & Chr(13)
        '                Msg = Msg & "FILE_ID = (" & DB_PARA(Fno).tblid & ")  処理 = " & Syori & Chr(13)
        '                Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                Msg = Msg & "［注意］キャンセルすると、このデータを登録せずにプログラムを終了します！"
        '                If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
        '                    'Call Error_Exit("Jet ReTry Error ! [" & DB_PARA(Fno).tblid & ":" & opCode & ":" & DB_MAXWAITSEC% & "]" & Error$)
        '                    Exit Do
        '                Else
        '                    StTime = VB.Timer()
        '                    EnTime = StTime + DB_MAXWAITSEC
        '                End If
        '            Else
        '                System.Windows.Forms.Application.DoEvents()
        '            End If
        '        Case Else
        '            Exit Do
        '    End Select
        '    '
        'Loop
        '2019/05/08 DEL E N D
    End Sub

    Sub KeyFromObject(ByRef Fno As Object)
        '2019/05/08 DEL START
        'Dim s As String
        'Dim I As Short
        's = ""
        ''UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'With KeyIndex(Fno).Seg(DB_PARA(Fno).KeyNo - 1)
        '    'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    For I = 0 To .ItmCnt - 1
        '        'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        s = s + JET_RS(Fno).Fields(.ItmPos(I)).Value
        '    Next I
        'End With
        ''UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(Fno).KeyBuf = s
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetFirst(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        'DBSTAT = JT_Get(Fno, ">=", KeyNo, "", LockFlg)
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
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetFirst", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetGr(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = JT_Get(Fno, ">", KeyNo, keyVal, LockFlg)
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetGr", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetGrEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = JT_Get(Fno, ">=", KeyNo, keyVal, LockFlg)
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetGrEq", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetLast(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short)
        '2019/04/11 DEL START
        'On Error Resume Next
        'Err.Clear()
        'JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
        'JET_RS(Fno).MoveLast()
        'If Err.Number = 0 Then
        '    If JET_RS(Fno).EOF Then
        '        DBSTAT = Jet_NoMAtch
        '        'DBSTAT = Jet_EOF
        '    Else
        '        nErr = 0
        '        If LockFlg Then Call JT_OutPut(Fno, "E")
        '        If nErr = 0 Then
        '            DBSTAT = Jet_NoErr
        '            DB_PARA(Fno).KeyNo = KeyNo
        '            Call RecordFromObject(Fno)
        '            If Err.Number = 0 Then Call KeyFromObject(Fno)
        '            If Err.Number Then DBSTAT = Err.Number
        '        Else
        '            DBSTAT = nErr
        '        End If
        '    End If
        'Else
        '    DBSTAT = Err.Number
        'End If
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetLast", Fno)
        '2019/04/11 DEL E N D
    End Sub

    Public Sub JB_GetLs(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = JT_Get(Fno, "<", KeyNo, keyVal, LockFlg)
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetLs", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetLsEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = JT_Get(Fno, "<=", KeyNo, keyVal, LockFlg)
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetLsEq", Fno)
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_GetNext(ByRef Fno As Short, ByRef LockFlg As Short)
        '2019/04/11 DEL START
        'On Error Resume Next
        'Err.Clear()
        'JET_RS(Fno).MoveNext()
        'If Err.Number = 0 Then
        '    If JET_RS(Fno).EOF Then
        '        DBSTAT = Jet_NoMAtch
        '        'DBSTAT = Jet_EOF
        '    Else
        '        nErr = 0
        '        If LockFlg Then Call JT_OutPut(Fno, "E")
        '        If nErr = 0 Then
        '            DBSTAT = Jet_NoErr
        '            'DB_PARA(Fno).KeyNo = KeyNo
        '            Call RecordFromObject(Fno)
        '            If Err.Number = 0 Then Call KeyFromObject(Fno)
        '            If Err.Number Then DBSTAT = Err.Number
        '        Else
        '            DBSTAT = nErr
        '        End If
        '    End If
        'Else
        '    DBSTAT = Err.Number
        'End If
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetNext", Fno)
        '2019/04/11 DEL E N D
    End Sub

    Public Sub JB_GetPre(ByRef Fno As Short, ByRef LockFlg As Short)
        '2019/04/11 DEL START
        'On Error Resume Next
        'Err.Clear()
        'JET_RS(Fno).MovePrevious()
        'If Err.Number = 0 Then
        '    If JET_RS(Fno).BOF Then
        '        DBSTAT = Jet_NoMAtch
        '        'DBSTAT = Jet_BOF
        '    Else
        '        nErr = 0
        '        If LockFlg Then Call JT_OutPut(Fno, "E")
        '        If nErr = 0 Then
        '            DBSTAT = Jet_NoErr
        '            'DB_PARA(Fno).KeyNo = KeyNo
        '            Call RecordFromObject(Fno)
        '            If Err.Number = 0 Then Call KeyFromObject(Fno)
        '            If Err.Number Then DBSTAT = Err.Number
        '        Else
        '            DBSTAT = nErr
        '        End If
        '    End If
        'Else
        '    DBSTAT = Err.Number
        'End If
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("GetPre", Fno)
        '2019/04/11 DEL E N D
    End Sub

    Public Sub JB_GetSQL(ByRef Fno As Short, ByRef Sql As String)
        '2019/04/11 DEL START
        ''Dim Sql$, i%
        'Dim I As Short
        ''   On Error Resume Next
        'Err.Clear()
        ''Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + Joken
        'If Not (JET_RS(Fno) Is Nothing) Then
        '    JET_RS(Fno).Close()
        '    'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '    JET_RS(Fno) = Nothing
        'End If
        'With DB_Spec(DB_PARA(Fno).DBNo)
        '    JET_RS(Fno) = .Jet_DB.OpenRecordset(Sql, DAO.RecordsetTypeEnum.dbOpenDynaset)
        '    If JET_RS(Fno).RecordCount > 0 Then
        '        For I = 0 To JET_RS(Fno).Fields.Count - 1
        '            G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
        '        Next I
        '        If Err.Number = 0 Then
        '            DB_PARA(Fno).KeyNo = 1 'KeyNo
        '            Call RecordFromObject(Fno)
        '            Call KeyFromObject(Fno)
        '        End If
        '        DBSTAT = Err.Number
        '        If DBSTAT <> 0 Then MsgBox("JB_GetSQL DBSTAT=" & Str(DBSTAT) & " " & ErrorToString())
        '    Else
        '        DBSTAT = Jet_NoMAtch
        '    End If
        '    DB_PARA(Fno).Status = DBSTAT
        '    Call JB_ErrorCheck("GetSQL", Fno)
        'End With
        '2019/04/11 DEL E N D
    End Sub

    Public Sub JB_Insert(ByRef Fno As Short, ByRef KeyNo As Short)
        '2019/04/11 DEL START
        'On Error Resume Next
        'Err.Clear()
        'JET_RS(Fno).AddNew()
        'Call ObjectFromRecord(Fno)
        'If Err.Number = 0 Then Call JT_OutPut(Fno, "U") : DBSTAT = nErr Else DBSTAT = Err.Number
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("Insert", Fno)
        '2019/04/11 DEL E N D
    End Sub

    Public Sub JB_NCCLOSE(ByRef Fno As Short)
        NoCheck = True
        JB_Close(Fno)
        NoCheck = False
        '    Call JB_ErrorCheck("NCClose", Fno)
    End Sub

    Public Sub JB_NCOPEN(ByRef Fno As Short)
        NoCheck = True
        JB_Open(Fno)
        NoCheck = False
        '    Call JB_ErrorCheck("JB_NCOpen", Fno)
    End Sub

    Public Sub JB_Open(ByRef Fno As Short)
        '2019/04/11 DEL START
        'Dim I, DBNo As Short
        'Dim Wk, sDB As String
        'Dim ret As Object
        'On Error Resume Next
        'Err.Clear()
        ''UPGRADE_WARNING: オブジェクト JT_GetDBno() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBNo = JT_GetDBno(Fno)
        'If DBNo >= 0 Then
        '    DB_PARA(Fno).DBNo = DBNo
        'Else
        '    MsgBox("データベース定義エラー: " & DB_PARA(Fno).tblid)
        '    Exit Sub
        'End If

        'With DB_Spec(DBNo)
        '    If .bLogin = False Then
        '        'Wk = .sLoc & .sID & ".MDB"
        '        'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        sDB = VB.Switch(.sID = "SYSDBC", "SYSDBN", .sID = "SSSWB2", "SSSWB1", True, .sID)
        '        Wk = .sLoc & sDB & ".MDB"
        '        .Jet_DB = Jet_WS.OpenDatabase(Wk)
        '        If Err.Number = 3343 Then
        '            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            ret = MsgBox("Jetデータベースが破損している様です。(JET-3343)" & Chr(13) & Wk & Chr(13) & "修復しますか？", MsgBoxStyle.YesNo)
        '            If ret = MsgBoxResult.Yes Then
        '                Err.Clear()
        '                DAODBEngine_definst.RepairDatabase(Wk)
        '                If Err.Number = 0 Then .Jet_DB = Jet_WS.OpenDatabase(Wk)
        '            End If
        '        End If
        '        If Err.Number <> 0 Then
        '            DBSTAT = Err.Number
        '            MsgBox("Jetデータベースを開く事はできません。JET[" & Str(DBSTAT) & "]" & Chr(13) & Wk)
        '            Exit Sub
        '        End If
        '        .bLogin = True
        '    End If

        '    If Not RsOpened(Fno) Then
        '        JET_RS(Fno) = .Jet_DB.OpenRecordset(Trim(DB_PARA(Fno).tblid), DAO.RecordsetTypeEnum.dbOpenTable)
        '        'UPGRADE_WARNING: オブジェクト JT_KeySet() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If Err.Number = 0 Then Err.Number = JT_KeySet(Fno)
        '        If Err.Number = 0 Then
        '            For I = 0 To JET_RS(Fno).Fields.Count - 1
        '                G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
        '            Next I
        '            RsOpened(Fno) = True
        '        End If
        '    End If
        '    DBSTAT = Err.Number
        '    DB_PARA(Fno).Status = DBSTAT
        '    If NoCheck = False Then Call JB_ErrorCheck("Open", Fno)
        'End With
        '2019/04/11 DEL E N D
    End Sub

    Private Function JT_GetDBno(ByRef Fno As Short) As Object
        '2019/05/08 DEL START
        'Dim Wk As String
        'Dim Wkno As Short
        ''    On Error Resume Next
        'Wk = UCase(Trim(DB_PARA(Fno).DBID))
        ''UPGRADE_WARNING: オブジェクト JT_GetDBno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'JT_GetDBno = -1
        'For Wkno = 0 To dbsMAX
        '    With DB_Spec(Wkno)
        '        If .sID < "0" Then Exit For
        '        If Wk = .sID Then
        '            'UPGRADE_WARNING: オブジェクト JT_GetDBno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            JT_GetDBno = Wkno
        '            Exit For
        '        End If
        '    End With
        'Next Wkno
        '2019/05/08 DEL E N D
    End Function

    Private Function JT_KeySet(ByRef Fno As Short) As Object
        '2019/05/08 DEL START
        'Dim J, I, ii, DBNo As Short
        'Dim xx As String
        'DBNo = DB_PARA(Fno).DBNo
        'With DB_Spec(DBNo)
        '    On Error Resume Next
        '    Err.Clear()
        '    'UPGRADE_WARNING: オブジェクト JT_KeySet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    JT_KeySet = Jet_OpnErr
        '    'UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '    Jet_Td = Nothing
        '    For I = 0 To .Jet_DB.TableDefs.Count - 1
        '        If Trim(.Jet_DB.TableDefs(I).Name) = Trim(DB_PARA(Fno).tblid) Then
        '            Jet_Td = .Jet_DB.TableDefs(I)
        '            Exit For
        '        End If
        '    Next I
        '    If I >= .Jet_DB.TableDefs.Count Then
        '        'UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '        Jet_Td = Nothing
        '        Exit Function
        '    End If
        'End With
        'With KeyIndex(Fno)
        '    .tblName = DB_PARA(Fno).tblid
        '    .KeyCnt = Jet_Td.Indexes.Count
        '    For I = 0 To .KeyCnt - 1
        '        xx = Trim(Jet_Td.Indexes(I).Name)
        '        ii = CShort(Right(xx, 2)) - 1
        '        With .Seg(ii)
        '            .KeyName = xx 'Jet_Td.Indexes(i).Name
        '            'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields.count の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .ItmCnt = Jet_Td.Indexes(I).Fields.count
        '            For J = 0 To .ItmCnt - 1
        '                '.ItmName(J) = Jet_Td.Indexes(I).Fields(J).Name
        '                '.bKb(j) = 0
        '                '.ItmLen(j) = GetFldSize(Jet_Td.Fields, .ItmName(j))
        '                'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields().NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .ItmLen(J) = GetFldSize((Jet_Td.Fields), Jet_Td.Indexes(I).Fields(J).NAME)
        '                'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields().NAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                .ItmPos(J) = GetFldPos((Jet_Td.Fields), Jet_Td.Indexes(I).Fields(J).NAME)
        '            Next J
        '        End With
        '    Next I
        'End With
        ''UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        'Jet_Td = Nothing
        ''UPGRADE_WARNING: オブジェクト JT_KeySet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'JT_KeySet = Err.Number
        '2019/05/08 DEL E N D
    End Function

    Function GetFldSize(ByRef flds As DAO.Fields, ByRef IName As String) As Short
        Dim I As Short
        GetFldSize = 0
        For I = 0 To flds.Count - 1
            If Trim(flds(I).Name) = Trim(IName) Then
                GetFldSize = flds(I).Size
                Exit For
            End If
        Next I
    End Function

    Function GetFldPos(ByRef flds As DAO.Fields, ByRef IName As String) As Short
        Dim I As Short
        GetFldPos = -1
        For I = 0 To flds.Count - 1
            If Trim(flds(I).Name) = Trim(IName) Then
                GetFldPos = I
                Exit For
            End If
        Next I
    End Function

    Public Sub JB_Start()
#Disable Warning BC40000 ' Type or member is obsolete
        Dim Wk As New VB6.FixedLengthString(513)
#Enable Warning BC40000 ' Type or member is obsolete
        Dim ret As Object
        Dim wk2 As String
        On Error Resume Next
        Err.Clear()

        'DB_MAXWAITSEC = 10
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DicPath = UCase(LeftWid(Wk.Value, ret)) & "\LIB\DIC\"
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("SSSWIN", "LCK_RTRY", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'BtrMaxReTryCnt = SSSVal(LeftWid(Wk.Value, ret))
        ''    ret = GetPrivateProfileString("SSSUSR", "WAIT_SEC", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("DBSPEC", "WAIT_SEC", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If ret > 0 Then DB_MAXWAITSEC = CShort(LeftWid(Wk.Value, ret))
        'DB_APPWAITSEC = 200
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("DBSPEC", "LOCK_MILISEC", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If ret > 0 Then DB_APPWAITSEC = CShort(LeftWid(Wk.Value, ret))
        ''

        ''UPGRADE_NOTE: Erase は System.Array.Clear にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
        'System.Array.Clear(DB_Spec, 0, DB_Spec.Length) '1998/11/11 by Kitomi
        'Call SetDBSpec()
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("LOCK", "RRRLOCK", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = LeftWid(Wk.Value, ret)
        ''UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'G_sRRRLock = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", True, UCase(wk2))
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("LOCK", "RRRLOCK2", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = LeftWid(Wk.Value, ret)
        ''UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'G_sRRRLock2 = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", True, UCase(wk2))
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("LOCK", "RRRLOCK3", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = LeftWid(Wk.Value, ret)
        ''UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'G_sRRRLock3 = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", wk2 = "", "")
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("LOCK", "BUSY_APP", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = UCase(LeftWid(Wk.Value, ret))
        'If wk2 = "TRUE" Then G_bRetApp = True
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("PLSQL", "EXT_CND", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = UCase(LeftWid(Wk.Value, ret))
        'If wk2 = "TRUE" Then G_bExtCnd = True
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("PLSQL", "ALERT_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If UCase(LeftWid(Wk.Value, ret)) = "FALSE" Then G_NO_ALTLOG = True Else G_NO_ALTLOG = False
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("SSSUSR", "BUSY_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If UCase(LeftWid(Wk.Value, ret)) = "TRUE" Then G_bBusyLog = True Else G_bBusyLog = False
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If UCase(LeftWid(Wk.Value, ret)) = "TRUE" Then G_bTranLog = True Else G_bBusyLog = False
        ''
        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG_PATH", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        ''UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'wk2 = LeftWid(Wk.Value, ret) : TRAN_LOG_PATH = wk2
        'If Right(TRAN_LOG_PATH, 1) <> "\" Then TRAN_LOG_PATH = TRAN_LOG_PATH & "\"
        ''
        'Jet_WS = DAODBEngine_definst.Workspaces(0)
        'DBSTAT = Err.Number

        ''20190219
        'Dim Conn As New OracleConnection
        'Conn.ConnectionString = "User Id = CNT_USR1; Password = CNT_USR1P; Data Source = CONORCL"
        'Conn.Open()

    End Sub

    Sub SetDBSpec()
#Disable Warning BC40000 ' Type or member is obsolete
        Dim Wk As New VB6.FixedLengthString(513)
#Enable Warning BC40000 ' Type or member is obsolete
        Dim wk2 As String
        Dim ret As Object
        Dim DBNo, I As Short
        '
        If DB_Spec(0).sID > "0" Then Exit Sub
        DB_Spec(0).sID = "SYSDBN"
        DB_Spec(1).sID = "SYSDBC"
        DB_Spec(2).sID = "SSSDF1"
        DB_Spec(3).sID = "SSSDF2"
        DB_Spec(4).sID = "SSSDF3"
        DB_Spec(5).sID = "SSSDS1"
        DB_Spec(6).sID = "SSSDS2"
        DB_Spec(7).sID = "SSSDS3"
        DB_Spec(8).sID = "SSSWB1"
        DB_Spec(9).sID = "SSSWB2"
        DB_Spec(10).sID = "SSSWB3"
        DB_Spec(11).sID = "USR1"
        DB_Spec(12).sID = "USR2"
        DB_Spec(13).sID = "USR3"
        DB_Spec(14).sID = "USR4"
        DB_Spec(15).sID = "USR5"
        DB_Spec(16).sID = "USR6"
        DB_Spec(17).sID = "USR7"
        DB_Spec(18).sID = "USR8"
        DB_Spec(19).sID = "USR9"
        DB_Spec(20).sID = ""
        DB_Spec(11).bOra = True
        DB_Spec(12).bOra = False
        DB_Spec(13).bOra = False
        DB_Spec(14).bOra = True
        DB_Spec(15).bOra = True
        DB_Spec(16).bOra = True
        DB_Spec(17).bOra = True
        DB_Spec(18).bOra = True
        DB_Spec(19).bOra = True
        DB_Spec(20).bOra = False
        '
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If ret > 0 Then
            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/26 CHG START
            'USR_PATH = LeftWid(Wk.Value, ret) : If Right(USR_PATH, 1) <> "\" Then USR_PATH = USR_PATH & "\"
            USR_PATH = LeftB(Wk.Value, ret) : If Right(USR_PATH, 1) <> "\" Then USR_PATH = USR_PATH & "\"
            '2019/04/26 CHG E N D
        End If
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("SSSWIN", "EXT_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")

        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If ret > 0 Then
            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/26 CHG START
            'EXT_PATH = LeftWid(Wk.Value, ret) : If Right(EXT_PATH, 1) <> "\" Then EXT_PATH = EXT_PATH & "\"
            EXT_PATH = LeftB(Wk.Value, ret) : If Right(EXT_PATH, 1) <> "\" Then EXT_PATH = EXT_PATH & "\"
            '2019/04/26 CHG E N D
        End If
        '2019/04/26 CHG START
        'G_sCLTID = MidWid(VB.Command(), 2, 5)
        'G_sOPEID = MidWid(VB.Command(), 7, 8)
        G_sCLTID = MidB(VB.Command(), 2, 5)
        G_sOPEID = MidB(VB.Command(), 7, 8)
        '2019/04/26 CHG E N D
        '
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")

        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/26 CHG START
        'wk2 = UCase(LeftWid(Wk.Value, ret)) : G_bORA_RPS = (wk2 = "TRUE")
        wk2 = UCase(LeftB(Wk.Value, ret)) : G_bORA_RPS = (wk2 = "TRUE")
        '2019/04/26 CHG E N D
        '    ret = GetPrivateProfileString("DBSPEC", "ORA_RPS_EXT", "", Wk, Len(Wk), "SSSWIN.INI")
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk.Value, Len(Wk.Value), EXT_PATH & "SSSUSR.INI")

        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/26 CHG START
        'wk2 = UCase(LeftWid(Wk.Value, ret)) : G_bORA_RPS_EXT = (wk2 = "TRUE")
        wk2 = UCase(LeftB(Wk.Value, ret)) : G_bORA_RPS_EXT = (wk2 = "TRUE")
        '2019/04/26 CHG E N D
        '
        For I = 0 To 10 : DB_Spec(I).bOra = G_bORA_RPS : Next I
        DB_Spec(1).bOra = G_bORA_RPS_EXT
        DB_Spec(9).bOra = G_bORA_RPS_EXT
        '
        For DBNo = 0 To dbsMAX
            If DB_Spec(DBNo).sID < "0" Then Exit For
            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190219
            'ret = GetPrivateProfileString("DBLOC", DB_Spec(DBNo).sID, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
            DB_Spec(DBNo).bLogin = False
            'UPGRADE_NOTE: オブジェクト DB_Spec().Jet_DB をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            DB_Spec(DBNo).Jet_DB = Nothing
            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If ret > 0 Then
                'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/26 CHG START
                'wk2 = LeftWid(Wk.Value, ret)
                wk2 = LeftB(Wk.Value, ret)
                '2019/04/26 CHG E N D
                wk2 = Trim(wk2)
                If DB_Spec(DBNo).bOra = False Then If Right(wk2, 1) <> "\" Then wk2 = wk2 & "\"
                DB_Spec(DBNo).sLoc = wk2
                DB_Spec(DBNo).bReged = True
            Else
                DB_Spec(DBNo).sLoc = ""
                DB_Spec(DBNo).bReged = False
            End If
        Next DBNo
        '
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("DBLOC", "RWRK", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
        DBNo = 12
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If ret > 0 Then
            'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/26 CHG START
            'wk2 = LeftWid(Wk.Value, ret)
            wk2 = LeftB(Wk.Value, ret)
            '2019/04/26 CHG E N D
            wk2 = Trim(wk2)
            If Right(wk2, 1) <> "\" Then wk2 = wk2 & "\"
            DB_Spec(DBNo).sLoc = wk2
            DB_Spec(DBNo).bReged = True
        Else
            DB_Spec(DBNo).sLoc = ""
            DB_Spec(DBNo).bReged = False
        End If
        'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'ret = GetPrivateProfileString("DBSPEC", "RETRYITV", "0", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
        G_RetryItv = 100
        On Error Resume Next
        G_RetryItv = CShort(Wk.Value)
        On Error GoTo 0
    End Sub

    Public Function JB_STAT(ByRef Fno As Short) As Integer
        '2019/05/08 DEL START
        'Dim Sql As String
        'Dim DBNo As Short
        ''UPGRADE_WARNING: 構造体 TMP_RS の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        'Dim TMP_RS As DAO.Recordset
        'On Error Resume Next
        'Err.Clear()
        'With DB_Spec(DB_PARA(Fno).DBNo)
        '    TMP_RS = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, DAO.RecordsetTypeEnum.dbOpenTable)
        '    JB_STAT = TMP_RS.RecordCount
        '    TMP_RS.Close()
        '    'UPGRADE_NOTE: オブジェクト TMP_RS をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '    TMP_RS = Nothing
        '    DBSTAT = Err.Number
        '    DB_PARA(Fno).Status = DBSTAT
        '    Call JB_ErrorCheck("Stat", Fno)
        'End With
        '2019/05/08 DEL E N D
    End Function

    Public Sub JB_Unlock(ByRef Fno As Short)
        '2019/05/08 DEL START
        'On Error Resume Next
        'Err.Clear()
        'JET_RS(Fno).CancelUpdate()
        'DBSTAT = Err.Number
        'DB_PARA(Fno).Status = DBSTAT
        '2019/05/08 DEL E N D
    End Sub

    Public Sub JB_Update(ByRef Fno As Short, ByRef KeyNo As Short)
        '2019/04/11 DEL START
        'On Error Resume Next
        'Err.Clear()
        'Call JT_OutPut(Fno, "E")
        'If nErr = 0 Then
        '    Call ObjectFromRecord(Fno)
        '    If Err.Number = 0 Then Call JT_OutPut(Fno, "U") : DBSTAT = nErr
        '    If Err.Number Then DBSTAT = Err.Number
        'Else
        '    DBSTAT = nErr
        'End If
        'DB_PARA(Fno).Status = DBSTAT
        'Call JB_ErrorCheck("Update", Fno)
        '2019/04/11 DEL E N D
    End Sub

    '旧関数インターフェイス

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''' Followings:  Added on Aug. 20,'96  ''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '20190617 chg start
    'Public Sub ResetDBSTAT(ByRef Fno As Short, Optional ByRef bApp As Short = 0)
    Public Sub ResetDBSTAT(ByRef Fno As Object, Optional ByRef bApp As Short = 0)
        '20190617 chg end
        '2019/05/08 DEL START
        'G_FNO = Fno
        'If (Fno >= 0) Then
        '    DB_PARA(Fno).Status = DBSTAT
        'End If
        'DBSTAT = 0
        'Err.Clear()
        'ret = 0
        'StTime = VB.Timer()
        'DB_REALWAITSEC = IIf(bApp = AppLock, DB_APPWAITSEC / 1000, DB_MAXWAITSEC)
        'EnTime = StTime + DB_REALWAITSEC
        '2019/05/08 DEL E N D
    End Sub

    Public Sub SetDBSTAT(ByRef erno As Object)
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト erno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DBSTAT = CInt(erno)
        'If G_FNO >= 0 Then DB_PARA(G_FNO).Status = DBSTAT
        '2019/05/08 DEL E N D
    End Sub

    '20190617 chg start
    'Public Function IS_ORA(ByRef Fno As Short, Optional ByRef bNoCheck As Object = Nothing) As Object
    Public Function IS_ORA(ByRef Fno As Object, Optional ByRef bNoCheck As Object = Nothing) As Object
        '20190617 chg end
        '2019/05/08 DEL START
        'Dim sID As String
        'Dim N As Short
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(bNoCheck) And RsOpened(Fno) = False Then
        '    MsgBox("ファイルがオープンされていません。(" & DB_PARA(Fno).tblid & ")")
        '    Call Error_Exit("Table is Not Opened !" & " = [" & DB_PARA(Fno).tblid & ":" & DBSTAT & "]")
        'End If
        ''sID$ = UCase(Left$(DB_PARA(Fno).DBID, 4))
        'sID = Trim(UCase(DB_PARA(Fno).DBID))
        ''UPGRADE_WARNING: オブジェクト IS_ORA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'IS_ORA = False
        'If sID = "USR2" Or sID = "USR3" Then Exit Function
        ''If (sID$ = "SYSDBC" Or sID$ = "SSSWB2") And G_bORA_RPS_EXT = False Then Exit Function
        ''If Left$(sID$, 3) <> "USR" And G_bORA_RPS = False Then Exit Function
        'If (sID = "SYSDBC" Or sID = "SSSWB2") Then
        '    If G_bORA_RPS_EXT = False Then Exit Function
        'ElseIf Left(sID, 3) <> "USR" Then
        '    If G_bORA_RPS = False Then Exit Function
        'End If
        ''UPGRADE_WARNING: オブジェクト IS_ORA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'IS_ORA = True
        '2019/05/08 DEL E N D
    End Function

    '20190617 chg start
    'Sub DB_ChkKey(ByRef Fno As Short, ByRef KeyNo As Short)
    Sub DB_ChkKey(ByRef Fno As Object, ByRef KeyNo As Short)
        '20190617 chg end
        '2019/05/08 DEL START
        'If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
        ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'If IsDBNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
        '2019/05/08 DEL E N D
    End Sub

    '20190617 chg start
    'Sub DB_MakKey(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object)
    Sub DB_MakKey(ByRef Fno As Object, ByRef KeyNo As Short, ByVal keyVal As Object)
        '20190617 chg end
        '2019/05/08 DEL START
        'If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
        ''UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(Fno).KeyBuf = CStr(keyVal)
        ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'If IsDBNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_GetFirst Lib "sssoraif" (ByVal Fno&, recBuf As Integer, ByVal KeyNo&, ByVal lockFlg&) As Long
    '20190617 chg start
    'Sub DB_GetFirst(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetFirst(ByRef ptablename As Object, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_GetFirst(Fno, KeyNo, LockFlg) : Exit Sub

        ''20190219
        ''Call ResetDBSTAT(Fno, LockFlg)
        '''20190205
        '' ''Call SetBuf(Fno)
        ''Call DB_ChkKey(Fno, KeyNo)
        '''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        ''If IsNothing(sFields) Then
        ''    G_sFields = ""
        ''Else
        ''    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''    G_sFields = sFields
        ''End If
        ''Call ResetExtNum()
        ''   Do
        ''UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        ''DBSTAT = Dll_GetFirst(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        ''   Loop While IsBusy_ORA("DB_GetFirst", LockFlg)
        '''Call ResetBuf(Fno)
        ''Call SetDBSTAT(DBSTAT)
        ''If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore


        'DBSTAT = 0
        '20190617 del end

        '20190617 add start
        GetRowsCommon(ptablename, "")
        '20190617 add end
    End Sub


    Private CON_USR1 As OracleConnection = Nothing
    '2019/05/07 ADD START
    Private CON_USR9 As OracleConnection = Nothing
    '2019/05/07 ADD E N D
    '2019/05/21 ADD START
    Public CON_GENKA As OracleConnection = Nothing
    '2019/05/21 ADD E N D
    Private txn As OracleTransaction = Nothing
    Public dsList As DataSet

    Public Function DB_START() As OracleConnection

        Dim LENGTH As Short
#Disable Warning BC40000 ' Type or member is obsolete
        Dim Wk As New VB6.FixedLengthString(513)
#Enable Warning BC40000 ' Type or member is obsolete
        Dim UP As String
        Dim DS As String

        If CON_USR1 IsNot Nothing Then
            Return CON_USR1
        End If

        Wk.Value = ""
        'change start 20190703 kuwahara
        'LENGTH = GetPrivateProfileString("SSSWIN", "USER_PASS", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        LENGTH = GetPrivateProfileString("SSSWIN", "USER_PASS", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        'change end 20190703 kuwahara

        If LENGTH = 0 Then
            UP = ""
        Else
            '2019/04/26 CHG START
            'UP = LeftWid(Wk.Value, LENGTH)
            UP = LeftB(Wk.Value, LENGTH)
            '2019/04/26 CHG E N D
        End If

        Wk.Value = ""
        LENGTH = GetPrivateProfileString("SSSWIN", "DATA_SOURCE", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        If LENGTH = 0 Then
            DS = ""
        Else
            '2019/04/26 CHG START
            'DS = LeftWid(Wk.Value, LENGTH)
            DS = LeftB(Wk.Value, LENGTH)
            '2019/04/26 CHG E N D
        End If

        If UP = "" Or DS = "" Then

        Else
            Call DB_START_OPEN(DS, UP)
        End If

        Return CON_USR1

    End Function

    '2019/05/07 ADD START
    Public Function DB_START_USR9() As OracleConnection

        Dim LENGTH As Short
#Disable Warning BC40000 ' Type or member is obsolete
        Dim Wk As New VB6.FixedLengthString(513)
#Enable Warning BC40000 ' Type or member is obsolete
        Dim UP As String
        Dim DS As String

        If CON_USR9 IsNot Nothing Then
            Return CON_USR9
        End If

        Wk.Value = ""
        LENGTH = GetPrivateProfileString("SSSWIN", "USER9_PASS", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        If LENGTH = 0 Then
            UP = ""
        Else
            UP = LeftB(Wk.Value, LENGTH)
        End If

        Wk.Value = ""
        LENGTH = GetPrivateProfileString("SSSWIN", "DATA_SOURCE", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        If LENGTH = 0 Then
            DS = ""
        Else
            DS = LeftB(Wk.Value, LENGTH)
        End If

        If UP = "" Or DS = "" Then

        Else
            Call DB_START_OPEN_USR9(DS, UP)
        End If

        Return CON_USR9

    End Function
    '2019/05/07 ADD E N D

    '2019/05/21 ADD START
    Public Function DB_START_GENKA() As OracleConnection

        Dim LENGTH As Short
#Disable Warning BC40000 ' Type or member is obsolete
        Dim Wk As New VB6.FixedLengthString(513)
#Enable Warning BC40000 ' Type or member is obsolete
        Dim UP As String
        Dim DS As String

        If CON_GENKA IsNot Nothing Then
            Return CON_GENKA
        End If

        Wk.Value = ""
        LENGTH = GetPrivateProfileString("SSSWIN", "GENKA_PASS", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        If LENGTH = 0 Then
            UP = ""
        Else
            UP = LeftB(Wk.Value, LENGTH)
        End If

        Wk.Value = ""
        LENGTH = GetPrivateProfileString("SSSWIN", "DATA_SOURCE", "", Wk.Value, Len(Wk.Value), Application.StartupPath & "\SSSWIN.INI")
        If LENGTH = 0 Then
            DS = ""
        Else
            DS = LeftB(Wk.Value, LENGTH)
        End If

        If UP = "" Or DS = "" Then

        Else
            Call DB_START_OPEN_GENKA(DS, UP)
        End If

        Return CON_GENKA

    End Function
    '2019/05/21 ADD E N D

    '2019/04/12 ADD START
    Public Function DB_START_FOR_HKK(ByVal pUserId As String _
                                    , ByVal pPassword As String _
                                    , ByVal pDataSource As String) As OracleConnection

        If String.IsNullOrEmpty(pUserId) = False _
            AndAlso String.IsNullOrEmpty(pPassword) = False _
            AndAlso String.IsNullOrEmpty(pDataSource) = False Then
            Call DB_START_OPEN(pDataSource, pUserId & "/" & pPassword)
        End If

        Return CON_USR1

    End Function
    '2019/04/12 ADD E N D

    Public Sub DB_START_OPEN(ByVal dbName As String, ByVal connect As String)

        Try
            Dim uid As String
            Dim pwd As String

            'connect文字列からユーザとパスワードの抽出
            Dim find As Integer
            find = InStr(connect, "/")
            uid = Mid(connect, 1, find - 1)
            pwd = Mid(connect, find + 1)

            'ODP.NET接続文字列の組み立て
            Dim connStr As String
            connStr = ""
            connStr &= "User Id=" & uid & ";"
            connStr &= "Password=" & pwd & ";"
            connStr &= "Data Source=" & dbName & ";"

            CON_USR1 = New OracleConnection
            CON_USR1.ConnectionString = connStr
            CON_USR1.Open()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '2019/05/07 ADD START
    Public Sub DB_START_OPEN_USR9(ByVal dbName As String, ByVal connect As String)

        Try
            Dim uid As String
            Dim pwd As String

            'connect文字列からユーザとパスワードの抽出
            Dim find As Integer
            find = InStr(connect, "/")
            uid = Mid(connect, 1, find - 1)
            pwd = Mid(connect, find + 1)

            'ODP.NET接続文字列の組み立て
            Dim connStr As String
            connStr = ""
            connStr &= "User Id=" & uid & ";"
            connStr &= "Password=" & pwd & ";"
            connStr &= "Data Source=" & dbName & ";"

            CON_USR9 = New OracleConnection
            CON_USR9.ConnectionString = connStr
            CON_USR9.Open()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '2019/05/07 ADD E N D

    '2019/05/21 ADD START
    Public Sub DB_START_OPEN_GENKA(ByVal dbName As String, ByVal connect As String)

        Try
            Dim uid As String
            Dim pwd As String

            'connect文字列からユーザとパスワードの抽出
            Dim find As Integer
            find = InStr(connect, "/")
            uid = Mid(connect, 1, find - 1)
            pwd = Mid(connect, find + 1)

            'ODP.NET接続文字列の組み立て
            Dim connStr As String
            connStr = ""
            connStr &= "User Id=" & uid & ";"
            connStr &= "Password=" & pwd & ";"
            connStr &= "Data Source=" & dbName & ";"

            CON_GENKA = New OracleConnection
            CON_GENKA.ConnectionString = connStr
            CON_GENKA.Open()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '2019/05/21 ADD E N D

    Public Sub DB_Execute(ByVal sql As String, Optional ByRef pm_RowCnt As Integer = 0, Optional ByVal pCon As OracleConnection = Nothing)
        Dim cmd As New OracleCommand

        If pCon Is Nothing Then
            cmd.Connection = CON_USR1
        Else
            cmd.Connection = pCon
        End If
        cmd.CommandText = sql

        pm_RowCnt = cmd.ExecuteNonQuery()

    End Sub

    Public Function DB_BeginTrans(ByVal pCon As OracleConnection) As Boolean
        DB_BeginTrans = False
        txn = Nothing
        txn = pCon.BeginTransaction()
        DB_BeginTrans = True
    End Function

    Public Function DB_Commit() As Boolean
        DB_Commit = False
        txn.Commit()
        DB_Commit = True
    End Function

    Public Function DB_Rollback() As Boolean
        DB_Rollback = False
        txn.Rollback()
        DB_Rollback = True
    End Function

    Public Sub DB_CLOSE(ByVal pCon As OracleConnection)

        If pCon IsNot Nothing Then
            pCon.Close()
            pCon.Dispose()
        End If

    End Sub

    Public Sub DB_GetData(ByVal tableName As String, ByVal tableCond As String, ByVal tableField As String)

        Dim CmdText As String

        If DB_NullReplace(tableField, "") = "" Then
            CmdText = "select * from " & tableName & " " & tableCond
        Else
            CmdText = "select " & tableField & "from " & tableName & " " & tableCond
        End If

        Dim cmd As New OracleCommand
        cmd.Connection = CON_USR1
        cmd.CommandText = CmdText

        dsList = New DataSet
        Dim adp As New OracleDataAdapter(cmd)
        adp.Fill(dsList, tableName)

    End Sub

    '2019/05/08 CHG START
    'Public Function DB_GetTable(ByVal pSql As String) As DataTable

    '    Dim cmd As New OracleCommand
    '    cmd.Connection = CON_USR1
    '    cmd.CommandText = pSql

    '    dsList = New DataSet
    '    Dim adp As New OracleDataAdapter(cmd)
    '    adp.Fill(dsList, "tableName")

    '    Return dsList.Tables(0)

    'End Function
    Public Function DB_GetTable(ByVal pSql As String, Optional ByVal pCon As OracleConnection = Nothing) As DataTable

        Dim cmd As New OracleCommand
        If pCon IsNot Nothing Then
            cmd.Connection = pCon
        Else
            cmd.Connection = CON_USR1
        End If
        cmd.CommandText = pSql

        dsList = New DataSet
        Dim adp As New OracleDataAdapter(cmd)
        adp.Fill(dsList, "tableName")

        Return dsList.Tables(0)

    End Function
    '2019/05/08 CHG E N D

    Public Function DB_GetCount(ByVal tableName As String, ByVal tableCond As String) As Decimal

        Dim strSql As String = ""

        DB_GetCount = 0

        If DB_NullReplace(tableName, "") = "" Then
            Exit Function
        Else
            strSql = "select count(*) cnt from " & tableName & " " & tableCond
        End If

        Dim cmd As New OracleCommand
        cmd.Connection = CON_USR1
        cmd.CommandText = strSql

        dsList = New DataSet
        Dim adp As New OracleDataAdapter(cmd)
        adp.Fill(dsList, "dataCount")

        If dsList.Tables("dataCount").Rows.Count > 0 Then
            DB_GetCount = CF_Ora_Number(dsList.Tables("dataCount").Rows(0).Item("cnt"))
        End If

    End Function

    Public Function DB_InsertSQL(ByVal tableName As String, ByVal setValue As String) As String

        Dim li_MsgRtn As Integer
        Dim strSQL As String = Nothing

        Try

            Dim cmd As New OracleCommand
            cmd.Connection = CON_USR1
            cmd.CommandText = "SELECT COLUMN_NAME FROM USER_TAB_COLUMNS " & " WHERE TABLE_NAME = '" & tableName & "'"
            cmd.CommandText = cmd.CommandText & "Order by COLUMN_ID"　'add 20190917 kuwa COLUMN_ID順にする。

            Dim rdr As OracleDataReader
            rdr = cmd.ExecuteReader

            strSQL = ""
            strSQL = strSQL & " insert into " & tableName
            strSQL = strSQL & " ( "

            Do While rdr.Read
                strSQL = strSQL & CStr(rdr("COLUMN_NAME")) & ","
            Loop

            strSQL = strSQL.Remove(strSQL.Length - 1, 1)

            strSQL = strSQL & " )values( "

            strSQL = strSQL & setValue

            strSQL = strSQL & " ) "

        Catch ex As Exception
            li_MsgRtn = MsgBox("DB_InsertSQL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally

        End Try

        Return strSQL

    End Function

    Public Function DB_NullReplace(ByVal pVal As Object, ByVal pReplaceString As Object) As Object
        If IsDBNull(pVal) = True Then
            Return pReplaceString
        ElseIf IsNothing(pVal) = True Then
            Return pReplaceString
        End If
        Return pVal
    End Function

    Public Function CF_Ora_Sgl(ByVal pm_Value As Object) As String

        CF_Ora_Sgl = Replace(CStr(pm_Value), "'", "''")

    End Function

    Public Function CF_Ora_String(ByVal pm_Value As String, ByVal pm_lngLen As Integer) As String

        Dim strRtn As String

        CF_Ora_String = ""

        strRtn = CF_Ora_Sgl(LeftB(pm_Value & Space(pm_lngLen), pm_lngLen))

        CF_Ora_String = strRtn

    End Function

    Public Function CF_Ora_Number(ByVal pm_Value As String) As Decimal

        '2019/04/26 DEL START
        'Dim strRtn As String
        '2019/04/26 DEL E N D

        CF_Ora_Number = 0

        If IsNumeric(pm_Value) = False Then
            Exit Function
        End If

        CF_Ora_Number = CDec(pm_Value)

    End Function

    Public Function CF_Ora_Date(ByVal pm_Value As String) As String

        '2019/04/26 DEL START
        'Dim strRtn As String
        '2019/04/26 DEL E N D

        CF_Ora_Date = Space(8)

        If IsDate(pm_Value) = False Then
#Disable Warning BC40000 ' Type or member is obsolete
            If IsDate(VB6.Format(pm_Value, "@@@@/@@/@@")) = False Then
#Enable Warning BC40000 ' Type or member is obsolete
                Exit Function
            Else
                CF_Ora_Date = pm_Value
            End If
        Else
#Disable Warning BC40000 ' Type or member is obsolete
            CF_Ora_Date = VB6.Format(pm_Value, "yyyymmdd")
#Enable Warning BC40000 ' Type or member is obsolete
        End If

    End Function


    ''Declare Function DB_GetNext Lib "sssoraif" (Fno as integer, recBuf As Integer, lockFlg as integer) As Long
    '20190614 chg start
    'Sub DB_GetNext(ByRef Fno As Short, ByRef LockFlg As Short)
    Sub DB_GetNext(ByRef pTableName As Object, ByRef LockFlg As Short)
        '20190614 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetNext(Fno, LockFlg) : Exit Sub

        ''Call ResetDBSTAT(Fno, LockFlg)
        ''Call ResetExtNum()
        'If DB_PARA(Fno).nDirection = nDir_Fore Then
        '    ''Call SetBuf(Fno)
        '    'Call DB_ChkKey(Fno, -1)
        '    'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        '    '20190219
        '    'DBSTAT = Dll_GetNext(Fno, 0, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, 0)

        '    'Loop While IsBusy_ORA("DB_GetNext", LockFlg)
        '    ''Call ResetBuf(Fno)
        '    'Debug.Print DB_PARA(FNO).KeyBuf
        'Else
        '    DBSTAT = -11
        'End If
        'Call SetDBSTAT(DBSTAT)
        '2019/05/08 DEL E N D

        '20190614 add start
        SetDataCommon(pTableName, GetNextRowsCommon(pTableName, SetDataCount(pTableName, False)))
        '20190614 add end
    End Sub

    ''Declare Function DB_GetPre Lib "sssoraif" (ByVal FNo&, recBuf As Integer, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetPre(ByRef Fno As Short, ByRef LockFlg As Short)
    Sub DB_GetPre(ByRef Fno As Object, ByRef LockFlg As Short)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetPre(Fno, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        'Call ResetExtNum()
        'If DB_PARA(Fno).nDirection = nDir_Back Then
        '    ''Call SetBuf(Fno)
        '    Call DB_ChkKey(Fno, -1)
        '    Do
        '        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        '        '20190219
        '        'DBSTAT = Dll_GetPre(Fno, 0, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, 0)
        '    Loop While IsBusy_ORA("DB_GetPre", LockFlg)
        '    ''Call ResetBuf(Fno)
        'Else
        '    DBSTAT = -12
        'End If
        'Call SetDBSTAT(DBSTAT)
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_GetLast Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetLast(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetLast(ByRef Fno As Object, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetLast(Fno, KeyNo, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_ChkKey(Fno, KeyNo)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetLast(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        'Loop While IsBusy_ORA("DB_GetLast", LockFlg)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_GetEq Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, ByVal keyVal$, lockFlg as integer) As Long
    '20190614 chg start
    'Sub DB_GetEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetEq(ByRef pTableName As Object, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190614 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub

        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_MakKey(Fno, KeyNo, keyVal)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        '    '20190219
        '    'DBSTAT = Dll_GetEq(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        '    '20190219

        'Loop While IsBusy_ORA("DB_GetEq", LockFlg)
        ''20190219
        ''Call ResetBuf(Fno)
        ''Call SetDBSTAT(DBSTAT)
        ''20190219
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
        '2019/05/08 DEL E N D

        '20190614 add start
        Dim cTableName As String = ""

        If pTableName.Contains("2") = True Then
            cTableName = pTableName.Replace("2", "")
        Else
            cTableName = pTableName
        End If

        'インデックス取得*****
        Dim strKeyNo As String = KeyNo.ToString("00")
        Dim strSQL As String = ""
        strSQL = strSQL & " SELECT"
        strSQL = strSQL & "  COL.COLUMN_NAME"
        strSQL = strSQL & " ,COL.COLUMN_LENGTH"
        strSQL = strSQL & " ,DATA.DATA_TYPE"
        strSQL = strSQL & " FROM"
        strSQL = strSQL & "  USER_IND_COLUMNS COL"
        strSQL = strSQL & "  INNER JOIN"
        strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
        strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
        strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & "     COL.TABLE_NAME = '" & cTableName & "'"
        strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & cTableName & strKeyNo & "'"
        strSQL = strSQL & " ORDER BY"
        strSQL = strSQL & "   COL.COLUMN_POSITION ASC"

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count = 0 Then
            If KeyNo = 1 Then
                strKeyNo = ""
                strSQL = ""
                strSQL = strSQL & " SELECT"
                strSQL = strSQL & "  COL.COLUMN_NAME"
                strSQL = strSQL & " ,COL.COLUMN_LENGTH"
                strSQL = strSQL & " ,DATA.DATA_TYPE"
                strSQL = strSQL & " FROM"
                strSQL = strSQL & "  USER_IND_COLUMNS COL"
                strSQL = strSQL & "  INNER JOIN"
                strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
                strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
                strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
                strSQL = strSQL & " WHERE"
                strSQL = strSQL & "     COL.TABLE_NAME = '" & cTableName & "'"
                strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & cTableName & strKeyNo & "'"
                strSQL = strSQL & " ORDER BY"
                strSQL = strSQL & "   COL.COLUMN_POSITION ASC"
                dt = DB_GetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    'エラー
                    DBSTAT = 1
                    MessageBox.Show("テスト用メッセージ：DB_GetEq インデックス取得時エラー")
                    Exit Sub
                End If
            End If
        End If
        '*********************

        'Where句作成
        Dim columnLength As Integer = 0
        Dim tempKeyVal As String = ""
        Dim strWhere As String = " WHERE "
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                If columnLength > keyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetEq Where句作成時エラー")
                    Exit Sub
                End If
                strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "= '" & Trim(keyVal.substring(0, columnLength)) & "'"
                tempKeyVal = keyVal.substring(columnLength)
            Else
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                strWhere = strWhere & " AND "

                If columnLength > tempKeyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetEq Where句作成時エラー")
                    Exit Sub
                Else
                    strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "= '" & Trim(tempKeyVal.Substring(0, columnLength)) & "'"
                    tempKeyVal = tempKeyVal.Substring(columnLength)
                End If

            End If
        Next

        'GetRowsCommonにてデータ取得
        GetRowsCommon(pTableName, strWhere)
        '20190614 add end

    End Sub

    ''Declare Function DB_GetGrEq Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, keyVal as string, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetGrEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetGrEq(ByRef pTableName As Object, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetGrEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_MakKey(Fno, KeyNo, keyVal)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetGrEq(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)

        'Loop While IsBusy_ORA("DB_GetGrEq", LockFlg)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D

        '20190617 add start

        'インデックス取得*****
        Dim strKeyNo As String = KeyNo.ToString("00")
        Dim strSQL As String = " "
        strSQL = strSQL & " SELECT"
        strSQL = strSQL & "  COL.COLUMN_NAME"
        strSQL = strSQL & " ,COL.COLUMN_LENGTH"
        strSQL = strSQL & " ,DATA.DATA_TYPE"
        strSQL = strSQL & " FROM"
        strSQL = strSQL & "  USER_IND_COLUMNS COL"
        strSQL = strSQL & "  INNER JOIN"
        strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
        strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
        strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
        strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
        strSQL = strSQL & " ORDER BY"
        strSQL = strSQL & "   COL.COLUMN_POSITION ASC"

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count = 0 Then
            If KeyNo = 1 Then
                strKeyNo = ""
                strSQL = ""
                strSQL = strSQL & " SELECT"
                strSQL = strSQL & "  COL.COLUMN_NAME"
                strSQL = strSQL & " ,COL.COLUMN_LENGTH"
                strSQL = strSQL & " ,DATA.DATA_TYPE"
                strSQL = strSQL & " FROM"
                strSQL = strSQL & "  USER_IND_COLUMNS COL"
                strSQL = strSQL & "  INNER JOIN"
                strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
                strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
                strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
                strSQL = strSQL & " WHERE"
                strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
                strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
                strSQL = strSQL & " ORDER BY"
                strSQL = strSQL & "   COL.COLUMN_POSITION ASC"
                dt = DB_GetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetGrEq インデックス取得時エラー")
                    Exit Sub
                End If
            End If
        End If
        '*********************

        'Where句作成
        Dim columnLength As Integer = 0
        Dim tempKeyVal As String = ""
        Dim strWhere As String = " WHERE "
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                If columnLength > keyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetGrEq Where句作成時エラー")
                    Exit Sub
                End If
                strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & ">= '" & Trim(keyVal.substring(0, columnLength)) & "'"
                tempKeyVal = keyVal.substring(columnLength)
            Else
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                strWhere = strWhere & " AND "

                If columnLength > tempKeyVal.ToString.Length Then
                    If DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "CHAR" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & ">= ' '"
                    ElseIf DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "NUMBER" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & ">= 0"
                    End If
                Else
                    strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & ">= '" & Trim(tempKeyVal.Substring(0, columnLength)) & "'"
                    tempKeyVal = tempKeyVal.Substring(columnLength)
                End If

            End If
        Next

        'GetRowsCommonにてデータ取得
        GetRowsCommon(pTableName, strWhere)
        '20190617 add end
    End Sub

    ''Declare Function DB_GetGr Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetGr(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetGr(ByRef pTableName As Object, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetGr(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_MakKey(Fno, KeyNo, keyVal)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetGr(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        'Loop While IsBusy_ORA("DB_GetGr", LockFlg)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D

        '20190617 add start

        'インデックス取得*****
        Dim strKeyNo As String = KeyNo.ToString("00")
        Dim strSQL As String = " "
        strSQL = strSQL & " SELECT"
        strSQL = strSQL & "  COL.COLUMN_NAME"
        strSQL = strSQL & " ,COL.COLUMN_LENGTH"
        strSQL = strSQL & " ,DATA.DATA_TYPE"
        strSQL = strSQL & " FROM"
        strSQL = strSQL & "  USER_IND_COLUMNS COL"
        strSQL = strSQL & "  INNER JOIN"
        strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
        strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
        strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
        strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
        strSQL = strSQL & " ORDER BY"
        strSQL = strSQL & "   COL.COLUMN_POSITION ASC"

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count = 0 Then
            If KeyNo = 1 Then
                strKeyNo = ""
                strSQL = ""
                strSQL = strSQL & " SELECT"
                strSQL = strSQL & "  COL.COLUMN_NAME"
                strSQL = strSQL & " ,COL.COLUMN_LENGTH"
                strSQL = strSQL & " ,DATA.DATA_TYPE"
                strSQL = strSQL & " FROM"
                strSQL = strSQL & "  USER_IND_COLUMNS COL"
                strSQL = strSQL & "  INNER JOIN"
                strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
                strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
                strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
                strSQL = strSQL & " WHERE"
                strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
                strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
                strSQL = strSQL & " ORDER BY"
                strSQL = strSQL & "   COL.COLUMN_POSITION ASC"
                dt = DB_GetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetGr インデックス取得時エラー")
                    Exit Sub
                End If
            End If
        End If
        '*********************

        'Where句作成
        Dim columnLength As Integer = 0
        Dim tempKeyVal As String = ""
        Dim strWhere As String = " WHERE "
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                If columnLength > keyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetGr Where句作成時エラー")
                    Exit Sub
                End If
                strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "> '" & Trim(keyVal.substring(0, columnLength)) & "'"
                tempKeyVal = keyVal.substring(columnLength)
            Else
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                strWhere = strWhere & " AND "

                If columnLength > tempKeyVal.ToString.Length Then
                    If DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "CHAR" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "> ' '"
                    ElseIf DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "NUMBER" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "> 0"
                    End If
                Else
                    strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "> '" & Trim(tempKeyVal.Substring(0, columnLength)) & "'"
                    tempKeyVal = tempKeyVal.Substring(columnLength)
                End If

            End If
        Next

        'GetRowsCommonにてデータ取得
        GetRowsCommon(pTableName, strWhere)
        '20190617 add end
    End Sub

    ''Declare Function DB_GetLs Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetLs(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetLs(ByRef pTableName As Object, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetLs(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_MakKey(Fno, KeyNo, keyVal)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetLs(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        'Loop While IsBusy_ORA("DB_GetLs", LockFlg)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
        '2019/05/08 DEL E N D

        '20190617 add start

        'インデックス取得*****
        Dim strKeyNo As String = KeyNo.ToString("00")
        Dim strSQL As String = " "
        strSQL = strSQL & " SELECT"
        strSQL = strSQL & "  COL.COLUMN_NAME"
        strSQL = strSQL & " ,COL.COLUMN_LENGTH"
        strSQL = strSQL & " ,DATA.DATA_TYPE"
        strSQL = strSQL & " FROM"
        strSQL = strSQL & "  USER_IND_COLUMNS COL"
        strSQL = strSQL & "  INNER JOIN"
        strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
        strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
        strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
        strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
        strSQL = strSQL & " ORDER BY"
        strSQL = strSQL & "   COL.COLUMN_POSITION ASC"

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count = 0 Then
            If KeyNo = 1 Then
                strKeyNo = ""
                strSQL = ""
                strSQL = strSQL & " SELECT"
                strSQL = strSQL & "  COL.COLUMN_NAME"
                strSQL = strSQL & " ,COL.COLUMN_LENGTH"
                strSQL = strSQL & " ,DATA.DATA_TYPE"
                strSQL = strSQL & " FROM"
                strSQL = strSQL & "  USER_IND_COLUMNS COL"
                strSQL = strSQL & "  INNER JOIN"
                strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
                strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
                strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
                strSQL = strSQL & " WHERE"
                strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
                strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
                strSQL = strSQL & " ORDER BY"
                strSQL = strSQL & "   COL.COLUMN_POSITION ASC"
                dt = DB_GetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetLs インデックス取得時エラー")
                    Exit Sub
                End If
            End If
        End If
        '*********************

        'Where句作成
        Dim columnLength As Integer = 0
        Dim tempKeyVal As String = ""
        Dim strWhere As String = " WHERE "
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                If columnLength > keyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetLs Where句作成時エラー")
                    Exit Sub
                End If
                strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "< '" & Trim(keyVal.substring(0, columnLength)) & "'"
                tempKeyVal = keyVal.substring(columnLength)
            Else
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                strWhere = strWhere & " AND "

                If columnLength > tempKeyVal.ToString.Length Then
                    If DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "CHAR" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "< ' '"
                    ElseIf DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "NUMBER" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "< 0"
                    End If
                Else
                    strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "< '" & Trim(tempKeyVal.Substring(0, columnLength)) & "'"
                    tempKeyVal = tempKeyVal.Substring(columnLength)
                End If

            End If
        Next

        'GetRowsCommonにてデータ取得
        GetRowsCommon(pTableName, strWhere)
        '20190617 add end
    End Sub

    ''Declare Function DB_GetLsEq Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
    '20190617 chg start
    'Sub DB_GetLsEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
    Sub DB_GetLsEq(ByRef pTableName As Object, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetLsEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
        'Call ResetDBSTAT(Fno, LockFlg)
        ''Call SetBuf(Fno)
        'Call DB_MakKey(Fno, KeyNo, keyVal)
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        'If IsNothing(sFields) Then
        '    G_sFields = ""
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    G_sFields = sFields
        'End If
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetLsEq(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, 0)
        'Loop While IsBusy_ORA("DB_GetLsEq", LockFlg)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
        '2019/05/08 DEL E N D

        '20190617 add start

        'インデックス取得*****
        Dim strKeyNo As String = KeyNo.ToString("00")
        Dim strSQL As String = " "
        strSQL = strSQL & " SELECT"
        strSQL = strSQL & "  COL.COLUMN_NAME"
        strSQL = strSQL & " ,COL.COLUMN_LENGTH"
        strSQL = strSQL & " ,DATA.DATA_TYPE"
        strSQL = strSQL & " FROM"
        strSQL = strSQL & "  USER_IND_COLUMNS COL"
        strSQL = strSQL & "  INNER JOIN"
        strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
        strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
        strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
        strSQL = strSQL & " WHERE"
        strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
        strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
        strSQL = strSQL & " ORDER BY"
        strSQL = strSQL & "   COL.COLUMN_POSITION ASC"

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count = 0 Then
            If KeyNo = 1 Then
                strKeyNo = ""
                strSQL = ""
                strSQL = strSQL & " SELECT"
                strSQL = strSQL & "  COL.COLUMN_NAME"
                strSQL = strSQL & " ,COL.COLUMN_LENGTH"
                strSQL = strSQL & " ,DATA.DATA_TYPE"
                strSQL = strSQL & " FROM"
                strSQL = strSQL & "  USER_IND_COLUMNS COL"
                strSQL = strSQL & "  INNER JOIN"
                strSQL = strSQL & "      USER_TAB_COLUMNS DATA"
                strSQL = strSQL & "  ON  COL.TABLE_NAME= DATA.TABLE_NAME"
                strSQL = strSQL & "  AND COL.COLUMN_NAME = DATA.COLUMN_NAME"
                strSQL = strSQL & " WHERE"
                strSQL = strSQL & "     COL.TABLE_NAME = '" & pTableName & "'"
                strSQL = strSQL & " AND COL.INDEX_NAME = 'X_" & pTableName & strKeyNo & "'"
                strSQL = strSQL & " ORDER BY"
                strSQL = strSQL & "   COL.COLUMN_POSITION ASC"
                dt = DB_GetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetLsEq インデックス取得時エラー")
                    Exit Sub
                End If
            End If
        End If
        '*********************

        'Where句作成
        Dim columnLength As Integer = 0
        Dim tempKeyVal As String = ""
        Dim strWhere As String = " WHERE "
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                If columnLength > keyVal.ToString.Length Then
                    'エラー
                    DBSTAT = 1
                    'MessageBox.Show("テスト用メッセージ：DB_GetLsEq Where句作成時エラー")
                    Exit Sub
                End If
                strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "<= '" & Trim(keyVal.substring(0, columnLength)) & "'"
                tempKeyVal = keyVal.substring(columnLength)
            Else
                columnLength = DB_NullReplace(dt.Rows(i)("COLUMN_LENGTH"), 0)
                strWhere = strWhere & " AND "

                If columnLength > tempKeyVal.ToString.Length Then
                    If DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "CHAR" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "<= ' '"
                    ElseIf DB_NullReplace(dt.Rows(i)("DATA_TYPE"), "") = "NUMBER" Then
                        strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "<= 0"
                    End If
                Else
                    strWhere = strWhere & (DB_NullReplace(dt.Rows(i)("COLUMN_NAME"), "")) & "<= '" & Trim(tempKeyVal.Substring(0, columnLength)) & "'"
                    tempKeyVal = tempKeyVal.Substring(columnLength)
                End If

            End If
        Next

        'GetRowsCommonにてデータ取得
        GetRowsCommon(pTableName, strWhere)
        '20190617 add end
    End Sub

    ''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Integer, ByVal sqlStmt$) As Long
    Sub DB_GetSQL(ByRef Fno As Short, ByRef sqlStmt As String, Optional ByVal sFields As Object = Nothing)
        '2019/05/08 DEL START
        'Dim Sql As String
        'Dim I As Short
        ''UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Or IsNothing(sFields) Then
        '    Sql = "Select *"
        'Else
        '    'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    Sql = "Select " + sFields
        'End If
        'Sql = Sql & " From " & DB_PARA(Fno).tblid & " WHERE " & sqlStmt
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, Sql) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''Call SetBuf(Fno)
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetSQL(Fno, 0, Sql, 0)
        'Loop While IsBusy_ORA("DB_GetSQL")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Integer, ByVal sqlStmt$) As Long
    '20190617 chg start
    'Sub DB_GetSQL2(ByRef Fno As Short, ByRef sqlStmt As String)
    Sub DB_GetSQL2(ByRef pTableName As Object, ByRef sqlStmt As String)
        '20190617 chg end
        '2019/05/08 DEL START
        ''Dim Sql$, i%
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt) : Exit Sub
        ''Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
        ''Call ResetDBSTAT(Fno)
        '' 'Call SetBuf(Fno)
        ''Call ResetExtNum()
        ''Do
        ''UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ''20190219
        ''DBSTAT = Dll_GetSQL(Fno, 0, sqlStmt, 0)

        ''Dim Conn As New OracleConnection
        ''Conn.ConnectionString = "User Id = CNT_USR1; Password = CNT_USR1P; Data Source = CONORCL"
        ''Conn.Open()
        ''Dim cmd As New OracleCommand
        ' ''CommandTextにSQLを設定する。
        ''cmd.Connection = Conn
        ''cmd.CommandText = sqlStmt

        ' ''OracleCommandオブジェクトのExecuteReaderメソッドを実行して、OracleDataReaderオブジェクトを生成
        ''Dim rdr As OracleDataReader
        ''rdr = cmd.ExecuteReader
        ' ''デバックウィンドウに値を表示
        ''Do While rdr.Read
        ''    'Debug.WriteLine(CStr(rdr("empno")) + " / " + _
        ''    '  rdr("ename"))
        ''    'DB_UNYMTA.UNYDT = CStr(rdr("UNYDT"))

        ''    DB_KNGMTB.UPDAUTH = CStr(rdr("UPDAUTH"))
        ''    DB_KNGMTB.PRTAUTH = CStr(rdr("PRTAUTH"))
        ''    DB_KNGMTB.FILEAUTH = CStr(rdr("FILEAUTH"))
        ''    DB_KNGMTB.SALTAUTH = CStr(rdr("SALTAUTH"))
        ''    DB_KNGMTB.HDNTAUTH = CStr(rdr("HDNTAUTH"))
        ''    DB_KNGMTB.SAPMAUTH = CStr(rdr("SAPMAUTH"))
        ''Loop

        ' ''接続をClose
        ''rdr.Close()
        ''Conn.Close()

        ''Loop While IsBusy_ORA("DB_GetSQL")
        ''Call ResetBuf(Fno)
        ''Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D

        '20190617 add start
        Dim cmd As New OracleCommand
        cmd.Connection = CON_USR1
        cmd.CommandText = sqlStmt

        dsList = New DataSet
        Dim adp As New OracleDataAdapter(cmd)
        adp.Fill(dsList, pTableName)
        SetDataCommon(pTableName, GetNextRowsCommon(pTableName, SetDataCount(pTableName, True)))
        '20190617 add end
    End Sub

    ''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Integer, ByVal sqlStmt$) As Long
    Sub DB_GetSQL3(ByRef Fno As Short, ByRef sqlStmt As String)
        '2019/05/08 DEL START
        ''Dim Sql$, i%
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt) : Exit Sub
        ''Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
        'Call ResetDBSTAT(Fno, AppLock)
        ''Call SetBuf(Fno)
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetSQL(Fno, 0, sqlStmt, 0)
        'Loop While IsBusy_ORA("DB_GetSQL", AppLock)
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D
    End Sub

    '''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
    ''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Integer, ByVal sqlStmt$) As Long
    '20190617 chg start
    'Sub DB_GetSQL4(ByRef Fno As Short, ByRef sqlStmt As String)
    Sub DB_GetSQL4(ByRef pTableName As Object, ByRef sqlStmt As String)
        '20190617 chg end
        '2019/05/08 DEL START
        ''Dim Sql$, i%
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt) : Exit Sub
        ''Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
        'Call ResetDBSTAT(Fno)
        '' 'Call SetBuf(Fno)
        'Call ResetExtNum()
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_GetSQL(Fno, 0, sqlStmt, 0)
        'Loop While IsBusy_ORA3("DB_GetSQL4")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
        '2019/05/08 DEL E N D

        '20190617 add start
        Dim cmd As New OracleCommand
        cmd.Connection = CON_USR1
        cmd.CommandText = sqlStmt

        dsList = New DataSet
        Dim adp As New OracleDataAdapter(cmd)
        adp.Fill(dsList, pTableName)
        SetDataCommon(pTableName, GetNextRowsCommon(pTableName, SetDataCount(pTableName, True)))
        '20190617 add end
    End Sub
    '''' ADD 2010/07/02  FKS) T.Yamamoto    End

    ''Declare Function DB_Execute Lib "sssoraif" (ByVal sqlStmt$) As Long
    '20190617 chg start
    'Sub DB_Execute(ByRef Fno As Short, ByRef sqlStmt As String)
    Sub DB_Execute(ByRef Fno As Object, ByRef sqlStmt As String)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_Execute(Fno, sqlStmt) : Exit Sub
        'Call ResetDBSTAT(Fno)
        '' 'Call SetBuf(Fno)
        'Do
        '    '20190219
        '    'DBSTAT = Dll_Execute(Fno, sqlStmt)
        'Loop While IsBusy_ORA("DB_Execute")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
        '2019/05/08 DEL E N D

        '20190617 add start
        DB_Execute(sqlStmt)
        '20190617 add end

    End Sub
    '2019061 chg start
    'Public Sub DB_DelAll(ByRef Fno As Short)
    Sub DB_DelAll(ByRef Fno As Object, ByRef KeyNo As Short)
        '20190617 chg end
        '2019/05/08 DEL START
        'Dim swk As String
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_DelAll(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        '' 'Call SetBuf(Fno)
        ''sWK$ = "DELETE FROM " + Trim$(DB_PARA(Fno).DBID) + "." + Trim$(DB_PARA(Fno).tblid)
        'swk = "DELETE FROM " & Trim(DB_PARA(Fno).tblid)
        'Do
        '    '20190219
        '    'DBSTAT = Dll_Execute(Fno, swk)
        'Loop While IsBusy_ORA("DB_DelAll")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
        '2019/05/08 DEL E N D
    End Sub

    '' Deleting , Inserting and Updating Data
    ''Declare Function DB_Delete Lib "sssoraif" (ByVal FNo&, recBuf As Integer) As Long
    '20190617 chg start
    'Sub DB_Delete(ByRef Fno As Short)
    Sub DB_Delete(ByRef Fno As Object)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        ''20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_DELETE(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''Call SetBuf(Fno)
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_Delete(Fno, 0)
        'Loop While IsBusy_ORA("DB_Delete")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        '20190617 del end
    End Sub

    ''Declare Function DB_Insert Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer) As Long
    '20190617 chg start
    'Sub DB_Insert(ByRef Fno As Short, ByRef KeyNo As Short)
    Sub DB_Insert(ByRef Fno As Object, ByRef KeyNo As Short)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_Insert(Fno, KeyNo) : Exit Sub
        'Call ResetDBSTAT(Fno)
        '' 'Call SetBuf(Fno)
        'Call DB_ChkKey(Fno, KeyNo)
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_Insert(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf)
        'Loop While IsBusy_ORA("DB_Insert")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        '20190617 del end


    End Sub

    ''Declare Function DB_Update Lib "sssoraif" (ByVal FNo&, recBuf As Integer, KeyNo as integer) As Long
    '20190617 chg start
    'Sub DB_Update(ByRef Fno As Short, ByRef KeyNo As Short)
    Sub DB_Update(ByRef Fno As Object, ByRef KeyNo As Short)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_Update(Fno, KeyNo) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''Call SetBuf(Fno)
        'Call DB_ChkKey(Fno, KeyNo)
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '20190219
        '    'DBSTAT = Dll_Update(Fno, 0, KeyNo, DB_PARA(Fno).KeyBuf)
        'Loop While IsBusy_ORA("DB_Update")
        ''Call ResetBuf(Fno)
        'Call SetDBSTAT(DBSTAT)
        '20190617 del end
    End Sub

    '' Others
    '20190617 chg start
    'Sub DB_Stat(ByRef Fno As Short)
    Sub DB_Stat(ByRef Fno As Object)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno) = 0 Then Call JB_STAT(Fno) : Exit Sub
        'Dim xxx As Integer
        'Call ResetDBSTAT(Fno)
        ''20190219
        ''DBSTAT = Dll_Stat(Fno, xxx)
        'If DBSTAT = 0 Then
        '    StatFileBuffer.RecTot = xxx
        'Else
        '    StatFileBuffer.RecTot = 0
        'End If
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_Start Lib "sssoraif" (ByVal sCon$) As Long
    Sub DB_Start(ByRef DbNm As String, ByRef DbHd As String)
        Dim sDLL_VER As String

        '20190219
        'Call DB_End()
        'Call ResetDBSTAT(-1)

        G_sUNIID = "" : G_nUNICNT = 0
        G_bUSR1_ON = False
        G_bSUP_ERR = False
        G_nTranStt = 0
        G_bBusyLog = False
        G_bTranLog = False
        Ora_DBName = DbNm : Ora_DBHead = DbHd : Ora_Connect1 = Ora_DBHead & Ora_Connect
        'Debug.Print Timer
        sDLL_VER = "            "

        '20190218
        'Call Dll_ChkVer(sDLL_VER)

        '20190219
        'If Left(sBAS_VER, 5) <> Left(sDLL_VER, 5) Then
        '    Call MsgBox("バージョン不一致:ORAJET.BAS=" & sBAS_VER & ", SSSORAIF.DLL=" & Left(sDLL_VER, 7))
        '    Call Error_Exit("バージョン不一致:ORAJET.BAS=" & sBAS_VER & ", SSSORAIF.DLL=" & Left(sDLL_VER, 7))
        'End If

        '20190219
        'DBSTAT = Dll_Start(Ora_DBName, Ora_DBHead)
        Ora_DBStart_FLG = 1
        'Call Ora_ErrorCheck("DB_Start", -1)
        'Debug.Print Timer
        'If Ora_DBStart_FLG = 0 Then
        '    If DBSTAT = 0 Then
        '        'Call JB_Start
        '        Ora_DBStart_FLG = 1
        '    End If
        'End If
        Call JB_Start()
        If Len(G_sPRGID) < 7 Then G_bTool = True Else G_bTool = False
    End Sub

    ''Declare Function DB_RESET Lib "sssoraif" () As Long
    Sub DB_RESET()
        Call DB_End()
    End Sub

    ''Declare Function DB_Stop Lib "sssoraif" () As Long
    Sub DB_Stop()
        Call DB_End()
    End Sub

    ''Declare Function DB_Open Lib "sssoraif" (Fno as integer, ByVal dbid$, ByVal tblid$) As Long
    '20190617 chg start
    'Sub DB_Open(ByRef Fno As Short, ByRef DBID As String, ByRef tblid As String)
    Sub DB_Open(ByRef Fno As Object, ByRef DBID As String, ByRef tblid As String)
        '20190617 chg end
        '2019/05/08 DEL START
        'Dim EN_TIME As Object
        'Dim sMsg As String
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno, True) = 0 Then Call JB_Open(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'EN_TIME = VB.Timer() + 10
        ''Debug.Print Timer
        'Do While True
        '    '20190219
        '    'DBSTAT = Dll_Open(Fno, DBID, tblid)
        '    If DBSTAT <> -171 Then Exit Do
        '    'UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    If VB.Timer() > EN_TIME Then
        '        sMsg = tblid & "のＳＣＭファイルが読めません。"
        '        sMsg = sMsg & vbCrLf & "ファイルや通信の不良等の可能性が有ります。"
        '        sMsg = sMsg & vbCrLf & "再試行（リトライ）しますか？"
        '        If MsgBox(sMsg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then Exit Do
        '        'UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        EN_TIME = VB.Timer() + 10
        '    Else
        '        '20190219
        '        'Call Sleep(G_RetryItv) 'DoEvents
        '    End If
        'Loop
        ''Debug.Print Timer
        'Call SetDBSTAT(DBSTAT)
        'Call Ora_ErrorCheck("DB_Open", Fno)
        'If DBSTAT = 0 Then
        '    RsOpened(Fno) = True : DB_PARA(Fno).nDirection = nDir_None
        '    If Left(UCase(DBID), 3) = "USR" Then G_bUSR1_ON = True
        'End If
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_Close Lib "sssoraif" (Fno as integer) As Long
    Sub DB_Close(ByRef Fno As Short)
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_Close(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''20190219
        ''DBSTAT = Dll_Close(Fno)

        ''    bOracle(Fno) = 0
        'Call SetDBSTAT(DBSTAT)
        'Call Ora_ErrorCheck("DB_Close", Fno)
        'If DBSTAT = 0 Then RsOpened(Fno) = False
        '20190617 del end
    End Sub

    ''Declare Function DB_Can Lib "sssoraif" (Fno as integer) As Long
    '20190617 chg start
    'Sub DB_Can(ByRef Fno As Short)
    Sub DB_Can(ByRef Fno As Object)
        '20190617 chg end
        '20190219
        'If Fno = -1 Then DBSTAT = Dll_Can(Fno) : Exit Sub

        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Exit Sub
        'Call ResetDBSTAT(Fno)
        ''20190219
        ''DBSTAT = Dll_Can(Fno)
        'Call SetDBSTAT(DBSTAT)
        'Call Ora_ErrorCheck("DB_Can", Fno)
        '20190617 del end
    End Sub

    ''Declare Function DB_End Lib "sssoraif" () As Long
    Sub DB_End()
        ' if Ora_DBName$ <> "" And Ora_DBHead$ <> "" Then
        If Ora_DBStart_FLG <> 0 Then ' 2000.2.14 for 8i
            '20190219
            'DBSTAT = Dll_End
            Ora_DBStart_FLG = 0
        Else
            DBSTAT = 0
        End If
        Call JB_End()
    End Sub

    ''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
    Sub DB_BeginTransaction(ByRef shareMode As String)
        Call ResetDBSTAT(-1)
        Do
            '20190219
            'DBSTAT = Dll_BeginTransaction(0)
        Loop While IsBusy_ORA("DB_BeginTransaction")
        If G_bUSR1_ON And DBSTAT = 0 Then
            Do
                DBSTAT = DB_LockOn(1)
            Loop While IsBusy_ORA("DB_BeginTransaction")
        End If
        Call SetDBSTAT(DBSTAT)
        If DBSTAT = 0 Then
            If G_bTranLog = True Then
                G_nTranStt = VB.Timer()
                Call DB2_UtlGetOraDT()
                G_tmSTT = DB_ORATM
            End If
            JB_BeginTransaction(0) 'shareMode
        End If
    End Sub

    ''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
    Sub DB_BeginTransaction2(ByRef shareMode As String)
        Call ResetDBSTAT(-1)
        Do
            '20190219
            'DBSTAT = Dll_BeginTransaction(1)
        Loop While IsBusy_ORA("DB_BeginTransaction2")
        If G_bUSR1_ON And DBSTAT = 0 Then
            Do
                DBSTAT = DB_LockOn(2)
            Loop While IsBusy_ORA("DB_BeginTransaction2")
        End If
        Call SetDBSTAT(DBSTAT)
        If DBSTAT = 0 Then
            If G_bTranLog = True Then
                G_nTranStt = VB.Timer()
                Call DB2_UtlGetOraDT()
                G_tmSTT = DB_ORATM
            End If
            JB_BeginTransaction(0) 'shareMode
        End If
    End Sub

    ''Declare Function DB_BeginTransaction Lib "sssoraif" (ByVal shareMode&) As Long
    Sub DB_BeginTransaction3(ByRef shareMode As String)
        Call ResetDBSTAT(-1)
        'JB_BeginTransaction 0 'shareMode
        Do
            '20190219
            'DBSTAT = Dll_BeginTransaction(1)
        Loop While IsBusy_ORA("DB_BeginTransaction3")
        If DBSTAT = 0 Then
            Do
                DBSTAT = DB_LockOn(3)
            Loop While IsBusy_ORA("DB_BeginTransaction3")
        End If
        Call SetDBSTAT(DBSTAT)
        If DBSTAT = 0 Then
            If G_bTranLog = True Then
                G_nTranStt = VB.Timer()
                Call DB2_UtlGetOraDT()
                G_tmSTT = DB_ORATM
            End If
            JB_BeginTransaction(0) 'shareMode
        End If
    End Sub

    ''Declare Function DB_AbortTransaction Lib "sssoraif" () As Long
    Sub DB_AbortTransaction()
        JB_AbortTransaction()
        Call JB_ErrorCheck("JB_AbortTransaction", -1)
        '20190219
        'DBSTAT = Dll_AbortTransaction
        Call Ora_ErrorCheck("Dll_AbortTransaction", -1)
        If G_bUSR1_ON Then Call DB_LockOff(0)
        Call Ora_ErrorCheck("DB_LockOff", -1)
        If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog() : G_nTranStt = 0
    End Sub

    ''Declare Function DB_EndTransaction Lib "sssoraif" () As Long
    Sub DB_EndTransaction()
        JB_EndTransaction()
        Call JB_ErrorCheck("JB_EndTransaction", -1)
        '20190219
        'DBSTAT = Dll_EndTransaction
        Call Ora_ErrorCheck("Dll_EndTransaction", -1)
        If G_bUSR1_ON Then Call DB_LockOff(1)
        Call Ora_ErrorCheck("DB_LockOff", -1)
        If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog() : G_nTranStt = 0
    End Sub

    'ADD START FKS)INABA 2009/09/17 *****************************************************
    '連絡票№706
    Function DB_EndTransaction2() As Boolean
        Dim lb_ret As Boolean
        lb_ret = True

        Call JB_EndTransaction2()
        If DBSTAT <> 0 Then lb_ret = False
        Call JB_ErrorCheck2("JB_EndTransaction", -1)
        If lb_ret = False Then GoTo EXIT_FUNC

        '20190219
        'DBSTAT = Dll_EndTransaction
        If DBSTAT <> 0 Then lb_ret = False
        Call Ora_ErrorCheck2("Dll_EndTransaction", -1)
        If lb_ret = False Then GoTo EXIT_FUNC

        If G_bUSR1_ON Then Call DB_LockOff2(1)
        If DBSTAT <> 0 Then lb_ret = False
        Call Ora_ErrorCheck2("DB_LockOff", -1)
        If lb_ret = False Then GoTo EXIT_FUNC

        If G_bTranLog = True And G_nTranStt <> 0 Then
            Call DB2_TranLog()
            G_nTranStt = 0
        End If

EXIT_FUNC:
        DB_EndTransaction2 = lb_ret

    End Function
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************



    'ADD START FKS)INABA 2009/09/17 *****************************************************
    '連絡票№706
    Public Sub JB_EndTransaction2()
        On Error Resume Next
        Err.Clear()
        DBSTAT = 0
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsDBNull(Jet_WS.Databases) Then Return
        Jet_WS.CommitTrans()
        DBSTAT = Err.Number
        Call JB_ErrorCheck2("EndTransaction", 0)
    End Sub
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************


    'ADD START FKS)INABA 2009/09/17 *****************************************************
    '連絡票№706
    '20190617 chg start
    'Sub JB_ErrorCheck2(ByRef opCode As String, ByRef Fno As Short) 'TblName As String)
    Sub JB_ErrorCheck2(ByRef opCode As String, ByRef Fno As Object) 'TblName As String)
        '20190617 cgh end
        '2019/05/08 DEL START
        'Dim tblName As String
        'Dim nHantei As Short
        'Dim sErrMsg As String

        'If Fno >= 0 Then tblName = DB_PARA(Fno).tblid
        ''
        'nHantei = 0
        'Select Case DBSTAT
        '    'Case 0, Jet_BOF, Jet_EOF, Jet_NoMAtch
        '    Case 0, Jet_NoMAtch
        '    Case 3021
        '        If opCode = "GetNext" Or opCode = "GetPre" Then DBSTAT = Jet_EOF Else nHantei = 9
        '    Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
        '        nHantei = 1
        '    Case Else
        '        nHantei = 9
        'End Select
        'Select Case nHantei
        '    Case 1
        '        sErrMsg = "Jet ReTry Error ! [" & tblName & ":" & opCode & ":" & Str(DB_MAXWAITSEC) & "]" & ErrorToString()
        '        DB_MsgBox("")
        '        Call Error_Exit2(sErrMsg)
        '        System.Windows.Forms.Application.DoEvents()
        '    Case 9
        '        sErrMsg = "Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & ErrorToString()
        '        DB_MsgBox("Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & Chr(13) & ErrorToString())
        '        Call Error_Exit2(sErrMsg)
        '    Case Else
        'End Select
        '2019/05/08 DEL E N D
    End Sub
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************

    'ADD START FKS)INABA 2009/09/17 *****************************************************
    '連絡票№706
    Sub Error_Exit2(ByVal ErrorMsg As String)
        '2019/04/26 DEL START
        'Dim Rtn As Object
        'Dim I As Short
        ''
        'Call SSSWIN_LOGWRT(ErrorMsg)
        ''2019/04/11 CHG START
        ''MsgBox("プログラムを終了します。", MB_OK, Trim(SSS_PrgNm))
        'MsgBox("プログラムを終了します。", MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
        ''2019/04/11 CHG E N D
        ''
        'If DBSTAT <> 0 Then
        '    MsgBox("エラーログの書き込みエラー ! Windows を再起動してください")
        '    '
        'Else
        '    For I = SSS_MAX_DB - 1 To 0 Step -1
        '        Call DB_NCCLOSE(I)
        '    Next I
        'End If
        'Call DB_End()
        ''UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        ''20190218
        ''Rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
        '2019/04/26 DEL E N D
    End Sub
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************




    'ADD START FKS)INABA 2009/09/17 *****************************************************
    '連絡票№706
    '20190617 chg start
    'Sub Ora_ErrorCheck2(ByRef opCode As String, ByRef Fno As Short, Optional ByRef LockFlg As Short = 0) 'TblName As String)
    Sub Ora_ErrorCheck2(ByRef opCode As String, ByRef Fno As Object, Optional ByRef LockFlg As Short = 0) 'TblName As String)
        '20190617 chg end
        '2019/05/08 DEL START
        'Dim tblName As String
        'Dim Msg As String
        'Dim sErrMsg As String
        'Dim sErrMsg2 As String
        'If Fno >= 0 Then tblName = DB_PARA(Fno).tblid Else tblName = " "
        ''
        'If opCode = "DB_Start" Or opCode = "DB_Open" Then
        '    Msg = ""
        '    Select Case DBSTAT
        '        Case 0
        '        Case 1 'Call Han_msgINFO("テスト環境です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case 2 'Call Han_msgINFO("評価版です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case -1
        '            Msg = "環境が未設定です！"
        '        Case -2
        '            Msg = "古い環境です！"
        '        Case -3
        '            Msg = "環境が違います！"
        '        Case -4
        '            Msg = "現在使用できません！"
        '        Case -5
        '            Msg = "環境情報が壊れています！"
        '        Case -6
        '            Msg = "同時実行版ライセンスが登録されていません！"
        '        Case -7
        '            Msg = "同時実行版ライセンスが壊れています！"
        '        Case -8
        '            Msg = "ユーザ名称が違います！"
        '        Case -9
        '            Msg = "ライセンスの最大ユーザ数を超えました！"
        '        Case -10
        '            Msg = "データベースに接続できません！"
        '        Case -11
        '            Msg = "接続許可が得られません！"
        '        Case Else
        '            If DBSTAT < 0 Then
        '                Msg = "環境エラーです！"
        '            Else
        '                Msg = "ＤＢエラーです！"
        '            End If
        '    End Select
        '    If Msg <> "" Then
        '        sErrMsg = "Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
        '        MsgBox(sErrMsg)
        '        Call Error_Exit2("Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]")
        '    End If
        'End If

        'Select Case DBSTAT
        '    '   OK,  EOF, NULL
        '    Case 0, 1403, 1405
        '        G_sErrMsg = "ORA:" & Str(DBSTAT)
        '    Case Else
        '        If opCode = "DB_PlExec" Then Exit Sub
        '        sErrMsg = "Ora  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then G_sErrMsg = sErrMsg : Exit Sub
        '        End If
        '        DB_MsgBox(sErrMsg)
        '        Call Error_Exit2(sErrMsg)
        'End Select
        '2019/05/08 DEL E N D
    End Sub
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************

    '''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
    '20190617 chg start
    'Sub Ora_ErrorCheck3(ByRef opCode As String, ByRef Fno As Short, Optional ByRef LockFlg As Short = 0) 'TblName As String)
    Sub Ora_ErrorCheck3(ByRef opCode As String, ByRef Fno As Object, Optional ByRef LockFlg As Short = 0) 'TblName As String)
        '20190617 chg end
        '2019/05/08 DEL START
        'Dim tblName As String
        'Dim Msg As String
        'Dim sErrMsg As String
        'Dim sErrMsg2 As String
        'If Fno >= 0 Then tblName = DB_PARA(Fno).tblid Else tblName = " "
        ''
        'If opCode = "DB_Start" Or opCode = "DB_Open" Then
        '    Msg = ""
        '    Select Case DBSTAT
        '        Case 0
        '        Case 1 'Call Han_msgINFO("テスト環境です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case 2 'Call Han_msgINFO("評価版です！", BOX_OK%)
        '            DBSTAT = 0
        '        Case -1
        '            Msg = "環境が未設定です！"
        '        Case -2
        '            Msg = "古い環境です！"
        '        Case -3
        '            Msg = "環境が違います！"
        '        Case -4
        '            Msg = "現在使用できません！"
        '        Case -5
        '            Msg = "環境情報が壊れています！"
        '        Case -6
        '            Msg = "同時実行版ライセンスが登録されていません！"
        '        Case -7
        '            Msg = "同時実行版ライセンスが壊れています！"
        '        Case -8
        '            Msg = "ユーザ名称が違います！"
        '        Case -9
        '            Msg = "ライセンスの最大ユーザ数を超えました！"
        '        Case -10
        '            Msg = "データベースに接続できません！"
        '        Case -11
        '            Msg = "接続許可が得られません！"
        '        Case Else
        '            If DBSTAT < 0 Then
        '                Msg = "環境エラーです！"
        '            Else
        '                Msg = "ＤＢエラーです！"
        '            End If
        '    End Select
        '    If Msg <> "" Then
        '        sErrMsg = "Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
        '        MsgBox(sErrMsg)
        '    End If
        'End If

        'Select Case DBSTAT
        '    '   OK,  EOF, NULL
        '    Case 0, 1403, 1405
        '        G_sErrMsg = "ORA:" & Str(DBSTAT)
        '    Case Else
        '        If opCode = "DB_PlExec" Then Exit Sub
        '        sErrMsg = "Ora  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
        '        '20190219
        '        'If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2

        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then G_sErrMsg = sErrMsg : Exit Sub
        '        End If
        '        MsgBox(sErrMsg)
        'End Select
        '2019/05/08 DEL E N D
    End Sub
    '''' ADD 2010/07/02  FKS) T.Yamamoto    End

    '' Nop inside
    ''Declare Function JB_ErrorCheck Lib "sssoraif" (ByVal opCode%, tblName As Integer) As Long
    '????????????????????Sub JB_ErrorCheck(opCode As Integer, tblName As String)
    '    DBSTAT = Dll_ErrorCheck(opCode, tblName)
    'End Sub

    ''Declare Function DB_NCCLOSE Lib "sssoraif" (ByVal FNo&) As Long
    '20190617 chg start
    'Sub DB_NCCLOSE(ByRef Fno As Short)
    Sub DB_NCCLOSE(ByRef Fno As Object)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019067 del start
        '    If IS_ORA(Fno, True) = 0 Then Call JB_NCCLOSE(Fno) : Exit Sub
        '    Call ResetDBSTAT(Fno)
        '    '20190219
        '    'DBSTAT = Dll_NCCLOSE(Fno)
        '    Call SetDBSTAT(DBSTAT)
        '    If DBSTAT = 0 Then RsOpened(Fno) = False
        '20190617 del end
    End Sub

    ''Declare Function DB_NCOPEN Lib "sssoraif" (ByVal FNo&, FileLocation As Integer, DBFLocation As Integer) As Long
    '20190617 chg start
    'Sub DB_NCOPEN(ByRef Fno As Short, ByRef FileLocation As String, ByRef DBFLocation As String)
    Sub DB_NCOPEN(ByRef Fno As Object, ByRef FileLocation As String, ByRef DBFLocation As String)
        '20190617 chg end
        '2019/05/08 DEL START
        ''UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If IS_ORA(Fno, True) = 0 Then Call JB_NCOPEN(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''20190219
        ''DBSTAT = Dll_NCOPEN(Fno, FileLocation, DBFLocation)
        'Call SetDBSTAT(DBSTAT)
        'If DBSTAT = 0 Then RsOpened(Fno) = True : DB_PARA(Fno).nDirection = nDir_None
        '2019/05/08 DEL E N D
    End Sub

    ''Declare Function DB_Unlock Lib "sssoraif" (ByVal FNo&) As Long
    '20190617 chg start
    'Sub DB_Unlock(ByRef Fno As Short)
    Sub DB_Unlock(ByRef Fno As Object)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If IS_ORA(Fno) = 0 Then Call JB_Unlock(Fno) : Exit Sub
        'Call ResetDBSTAT(Fno)
        ''20190219
        ''DBSTAT = Dll_Unlock(Fno)
        'Call SetDBSTAT(DBSTAT)
        'Call Ora_ErrorCheck("DB_Unlock", Fno)
        '20190617 del end
    End Sub

    Function DB_PlStart(Optional ByRef bGetRec_V As Object = Nothing) As Integer
        Dim bGetRec As Integer
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(bGetRec_V) Then
            bGetRec = 0
        Else
            'UPGRADE_WARNING: オブジェクト bGetRec_V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            bGetRec = CInt(bGetRec_V)
        End If
        Call ResetDBSTAT(-1)
        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'DB_PlStart = Dll_PlStart(0, bGetRec)
        Call SetDBSTAT(DB_PlStart)
        Call Ora_ErrorCheck("DB_PlStart", -1)
    End Function

    Function DB_PlFree() As Integer
        Call ResetDBSTAT(-1)
        '20190219
        'DB_PlFree = Dll_PlFree()
        Call SetDBSTAT(DB_PlFree)
        Call Ora_ErrorCheck("DB_PlFree", -1)
    End Function

    '20190617 chg start
    'Function DB_PlSet(ByRef Fno As Short, ByRef RNo As Short) As Integer
    Function DB_PlSet(ByRef Fno As Object, ByRef RNo As Short) As Integer
        '20190617 chg end
        Call ResetDBSTAT(-1)
        'Call SetBuf(Fno)
        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'DB_PlSet = Dll_PlSet(Fno, RNo, 0)

        ''''''Call ResetBuf(Fno)
        Call SetDBSTAT(DB_PlSet)
        Call Ora_ErrorCheck("DB_PlSet", -1)
    End Function

    Function DB_PlCndSet() As Integer
        Dim N As Short
        Call ResetDBSTAT(-1)
        N = IIf(G_bExtCnd, 12, 8)
        'If G_NO_ALTLOG Then G_PlCnd.nCndNum(N) = SSS_NO_ALTOUT
        ''UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '0 = LSet(G_PlCnd)
        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'DB_PlCndSet = Dll_PlCndSet(0)
        Call SetDBSTAT(DB_PlCndSet)
        Call Ora_ErrorCheck("DB_PlCndSet", -1)
    End Function

    Function DB_PlExec(ByRef Pack_Proc As String) As Integer
        Call ResetDBSTAT(-1)
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        'G_PlInfo = LSet(G_PlCnd2, 1)
        'Do
        '    'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    DB_PlExec = Dll_PlExec(Pack_Proc, 0)
        '    DBSTAT = DB_PlExec
        'Loop While IsBusy_ORA("DB_PlExec")
        ''UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        'G_PlCnd2 = LSet(0)
        Call SetDBSTAT(DB_PlExec)
    End Function

    '20190617 chg start
    'Function DB_PlGetCnt(ByRef Fno As Short) As Integer
    Function DB_PlGetCnt(ByRef Fno As Object) As Integer
        '20190617 chg end
        Call ResetDBSTAT(-1)
        '20190219
        'DB_PlGetCnt = Dll_PlGetCnt(CInt(Fno))
        If DB_PlGetCnt < 0 Then
            Call SetDBSTAT(DB_PlGetCnt)
            Call Ora_ErrorCheck("DB_PlGetCnt", -1)
        Else
            Call SetDBSTAT(0)
            'Call Ora_ErrorCheck("DB_PlGetCnt", -1)
        End If
    End Function

    '20190617 chg start
    'Function DB_PlGet(ByRef Fno As Short, Optional ByRef RNo_V As Object = Nothing) As Integer
    Function DB_PlGet(ByRef Fno As Object, Optional ByRef RNo_V As Object = Nothing) As Integer
        '20190617 chg end
        Dim RNo As Integer
        Call ResetDBSTAT(-1)
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(RNo_V) Then
            RNo = -1
        Else
            'UPGRADE_WARNING: オブジェクト RNo_V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RNo = CInt(RNo_V)
        End If
        'Call SetBuf(Fno)
        'UPGRADE_WARNING: オブジェクト 0 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190219
        'DB_PlGet = Dll_PlGet(Fno, 0, RNo)

        'If DBSTAT = 0 Then 'Call ResetBuf(Fno)
        Call SetDBSTAT(DB_PlGet)
        Call Ora_ErrorCheck("DB_PlGet", -1)
    End Function

    Function IsBusy_ORA(ByRef opCode As String, Optional ByRef LockFlg As Short = 0) As Short
        '2019/05/08 DEL START
        '        Dim tblName As String
        '        Dim Msg As String
        '        Dim bApp As Boolean
        '        '
        '        IsBusy_ORA = 0
        '        If DBSTAT = 0 Then Exit Function
        '        'DEL START FKS)INABA 2009/01/15 ******************************
        '        'FC09011501(FC08120202対応の戻し)
        '        ''''' ADD 2008/12/03  FKS) S.Nakajima    Start
        '        '    ' 自動引当処理中に画面が待ち状態になるのを回避するため追加
        '        '    If Trim$(SSS_PrgId) = "SODET53" Or _
        '        ''       Trim$(SSS_PrgId) = "SODET54" Then
        '        '        If DBSTAT = 54 Then Exit Function
        '        '    End If
        '        ''''' ADD 2008/12/03  FKS) S.Nakajima    End
        '        'DEL  END  FKS)INABA 2009/01/15 ******************************
        '        If G_FNO >= 0 Then tblName = DB_PARA(G_FNO).tblid Else tblName = " "
        '        '
        '        bApp = False
        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then bApp = True
        '        End If
        '        '
        '        '    If DBSTAT = 60 Then
        '        '        If opCode <> "DB_PlExec" Then Call Ora_ErrorCheck(opCode, G_FNO)
        '        '    End If
        '        Select Case DBSTAT
        '            Case 54, 56 'when busy
        '                'Case 54, 56, 60, -60 'when busy or Dlck
        '                'If DBSTAT = 1 And opCode <> "DB_PlExec" Then
        '                '    Call Ora_ErrorCheck(opCode, G_FNO)
        '                '    Exit Function
        '                'End If
        '                IsBusy_ORA = 1
        '                System.Windows.Forms.Application.DoEvents()
        '                CurTime = VB.Timer()
        '                If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
        '                If CurTime > EnTime Then
        '                    If G_bBusyLog Then Call DB2_BusyLog()
        '                    'If Kbn$ = "E" Then Syori$ = "EDIT" Else If Kbn$ = "U" Then Syori$ = "Update" Else Kbn$ = "Delete"
        '                    ''Msg$ = Str$(DB_MAXWAITSEC%) + "秒間待ちましたが、ORACLEファイルが使用中です。" + Chr$(13)
        '                    ''Msg$ = Msg$ + "FILE_ID = (" + tblName + ")  処理 = " + opCode + " コード = " + Str$(DBSTAT) + Chr$(13) + Chr$(13)
        '                    If bApp Then
        '                        Msg = "このデータは現在他でロックされています。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータをロックせずに処理に戻ります！"
        '                    Else
        '                        Msg = "サーバがビジー状態のため登録処理を行えません。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度登録処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータ"
        '                        If opCode <> "DB_PlExec" Then
        '                            If G_bRetApp = True And Left(opCode, 10) = "DB_BeginTr" Then bApp = True : LockFlg = AppLock
        '                            If bApp = True Then
        '                                Msg = Msg & "を登録せずに処理に戻ります！"
        '                            Else
        '                                Msg = Msg & "を登録せずにプログラムを終了します！"
        '                            End If
        '                        Else
        '                            Msg = Msg & "を登録せずに画面がクリアされます！"
        '                        End If
        '                    End If
        '                    If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
        '                        IsBusy_ORA = 0
        '                        If opCode <> "DB_PlExec" Then
        '                            If bApp = True Then
        '                                GoTo IsBusy_ORA_EX
        '                            Else
        '                                G_bSUP_ERR = True
        '                                GoTo IsBusy_ORA_EX
        '                                'Call Error_Exit("ORACLE ReTry Error ! [" & tblName & ":" & opCode & ":" & DB_MAXWAITSEC% & "]")
        '                            End If
        '                        Else
        '                            Exit Function
        '                        End If
        '                    Else
        '                        StTime = VB.Timer()
        '                        EnTime = StTime + DB_REALWAITSEC
        '                    End If
        '                Else
        '                    '20190219
        '                    'Call Sleep(G_RetryItv) 'DoEvents
        '                End If
        '            Case Else
        '                GoTo IsBusy_ORA_EX
        '        End Select
        '        Exit Function
        '        '
        'IsBusy_ORA_EX:
        '        If bApp = False Then
        '            Call Ora_ErrorCheck(opCode, G_FNO)
        '        Else
        '            Call Ora_ErrorCheck(opCode, G_FNO, LockFlg)
        '        End If
        '2019/05/08 DEL E N D
    End Function

    Function DB_LockOn(ByRef nSyu As Short) As Integer
        Dim sSyu, sSQL As String
        Dim nUNICNT As Integer
        DBSTAT = 0
        'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        sSyu = VB.Switch(nSyu = 1, G_sRRRLock, nSyu = 2, G_sRRRLock2, nSyu = 3, G_sRRRLock3)
        If sSyu <> "" Then
            sSQL = "LOCK TABLE SYSTBL IN " & sSyu & " MODE NOWAIT"
            'Do-2.3.0.3
            If sSyu = "TPA" Then
                nUNICNT = G_nUNICNT
                '20190219
                'DBSTAT = Dll_TpaLock(G_sUNIID, nUNICNT)
                If DBSTAT = 1403 Then
                    nUNICNT = G_nUNICNT
                    '20190219
                    'DBSTAT = Dll_TpaIns(G_sUNIID, nUNICNT, G_sOPEID, G_sCLTID, VB6.Format(TimeOfDay, "hhmmss"), VB6.Format(Today, "yyyymmdd"))
                    If DBSTAT = 1 Then DBSTAT = 0
                    If DBSTAT = 0 Then DBSTAT = 54
                End If
            Else
                '20190219
                'DBSTAT = Dll_Usr1Exec(sSQL)
            End If
            'Loop While IsBusy_ORA("DB_LockOn")
        End If
        DB_LockOn = DBSTAT
    End Function

    Function IsBusy_ORA2(ByRef opCode As String, Optional ByRef LockFlg As Short = 0) As Short
        '2019/05/08 DEL START
        '        Dim tblName As String
        '        Dim Msg As String
        '        Dim bApp As Boolean
        '        '
        '        IsBusy_ORA2 = 0
        '        If DBSTAT = 0 Then Exit Function
        '        If G_FNO >= 0 Then tblName = DB_PARA(G_FNO).tblid Else tblName = " "
        '        '
        '        bApp = False
        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then bApp = True
        '        End If
        '        Select Case DBSTAT
        '            Case 54, 56 'when busy
        '                IsBusy_ORA2 = 1
        '                System.Windows.Forms.Application.DoEvents()
        '                CurTime = VB.Timer()
        '                If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
        '                If CurTime > EnTime Then
        '                    If G_bBusyLog Then Call DB2_BusyLog()
        '                    If bApp Then
        '                        Msg = "このデータは現在他でロックされています。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータをロックせずに処理に戻ります！"
        '                    Else
        '                        Msg = "サーバがビジー状態のため登録処理を行えません。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度登録処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータ"
        '                        If opCode <> "DB_PlExec" Then
        '                            If G_bRetApp = True And Left(opCode, 10) = "DB_BeginTr" Then bApp = True : LockFlg = AppLock
        '                            If bApp = True Then
        '                                Msg = Msg & "を登録せずに処理に戻ります！"
        '                            Else
        '                                Msg = Msg & "を登録せずにプログラムを終了します！"
        '                            End If
        '                        Else
        '                            Msg = Msg & "を登録せずに画面がクリアされます！"
        '                        End If
        '                    End If
        '                    If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
        '                        IsBusy_ORA2 = 0
        '                        If opCode <> "DB_PlExec" Then
        '                            If bApp = True Then
        '                                GoTo IsBusy_ORA2_EX
        '                            Else
        '                                G_bSUP_ERR = True
        '                                GoTo IsBusy_ORA2_EX
        '                            End If
        '                        Else
        '                            Exit Function
        '                        End If
        '                    Else
        '                        StTime = VB.Timer()
        '                        EnTime = StTime + DB_REALWAITSEC
        '                    End If
        '                Else
        '                    '20190219
        '                    'Call Sleep(G_RetryItv) 'DoEvents
        '                End If
        '            Case Else
        '                GoTo IsBusy_ORA2_EX
        '        End Select
        '        Exit Function
        '        '
        'IsBusy_ORA2_EX:
        '        If bApp = False Then
        '            Call Ora_ErrorCheck2(opCode, G_FNO)
        '        Else
        '            Call Ora_ErrorCheck2(opCode, G_FNO, LockFlg)
        '        End If
        '2019/05/08 DEL E N D
    End Function

    '''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
    Function IsBusy_ORA3(ByRef opCode As String, Optional ByRef LockFlg As Short = 0) As Short
        '2019/05/08 DEL START
        '        Dim tblName As String
        '        Dim Msg As String
        '        Dim bApp As Boolean
        '        '
        '        IsBusy_ORA3 = 0
        '        If DBSTAT = 0 Then Exit Function
        '        If G_FNO >= 0 Then tblName = DB_PARA(G_FNO).tblid Else tblName = " "
        '        '
        '        bApp = False
        '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '        If Not IsNothing(LockFlg) Then
        '            If LockFlg = AppLock Then bApp = True
        '        End If
        '        Select Case DBSTAT
        '            Case 54, 56 'when busy
        '                IsBusy_ORA3 = 1
        '                System.Windows.Forms.Application.DoEvents()
        '                CurTime = VB.Timer()
        '                If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
        '                If CurTime > EnTime Then
        '                    If G_bBusyLog Then Call DB2_BusyLog()
        '                    If bApp Then
        '                        Msg = "このデータは現在他でロックされています。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータをロックせずに処理に戻ります！"
        '                    Else
        '                        Msg = "サーバがビジー状態のため登録処理を行えません。" & Chr(13)
        '                        Msg = Msg & "管理者に連絡するか、しばらく待ってから再度登録処理を行って下さい。" & Chr(13)
        '                        Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
        '                        Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
        '                        Msg = Msg & "［注意］キャンセルすると、このデータ"
        '                        If opCode <> "DB_PlExec" Then
        '                            If G_bRetApp = True And Left(opCode, 10) = "DB_BeginTr" Then bApp = True : LockFlg = AppLock
        '                            If bApp = True Then
        '                                Msg = Msg & "を登録せずに処理に戻ります！"
        '                            Else
        '                                Msg = Msg & "を登録せずにプログラムを終了します！"
        '                            End If
        '                        Else
        '                            Msg = Msg & "を登録せずに画面がクリアされます！"
        '                        End If
        '                    End If
        '                    If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
        '                        IsBusy_ORA3 = 0
        '                        If opCode <> "DB_PlExec" Then
        '                            If bApp = True Then
        '                                GoTo IsBusy_ORA3_EX
        '                            Else
        '                                G_bSUP_ERR = True
        '                                GoTo IsBusy_ORA3_EX
        '                            End If
        '                        Else
        '                            Exit Function
        '                        End If
        '                    Else
        '                        StTime = VB.Timer()
        '                        EnTime = StTime + DB_REALWAITSEC
        '                    End If
        '                Else
        '                    '20190219
        '                    'Call Sleep(G_RetryItv) 'DoEvents
        '                End If
        '            Case Else
        '                GoTo IsBusy_ORA3_EX
        '        End Select
        '        Exit Function
        '        '
        'IsBusy_ORA3_EX:
        '        If bApp = False Then
        '            Call Ora_ErrorCheck3(opCode, G_FNO)
        '        Else
        '            Call Ora_ErrorCheck3(opCode, G_FNO, LockFlg)
        '        End If
        '2019/05/08 DEL E N D
    End Function
    '''' ADD 2010/07/02  FKS) T.Yamamoto    End

    Sub DB2_BusyLog()
        If G_bTool Then Exit Sub
        Dim sMsg, sFName, swk As String
        Dim IMA As Object
        sFName = TRAN_LOG_PATH & "BUSY.LOG"
        If DB_REALWAITSEC = DB_MAXWAITSEC Then sMsg = "tp=BUSY" Else sMsg = "tp=LOCK"
        sMsg = sMsg & ", clid=" & G_sCLTID
#Disable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", pid=" & VB6.Format(G_sPRGID, "!@@@@@@@@@@")
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        swk = Space(10) & VB6.Format(DB_REALWAITSEC * 1000, "##########")
#Enable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", ms=" & Right(swk, 10)
        'sMsg$ = sMsg$ + ", tm=" + Format$(Time, "hhmmss")
        'sMsg$ = sMsg$ + ", dt=" + Format$(Date, "yyyymmdd")
        Call DB2_UtlGetOraDT()
        swk = Left(DB_ORADT, 2) & "/" & Mid(DB_ORADT, 3, 2) & "/" & Right(DB_ORADT, 2) & " "
        swk = swk & Left(DB_ORATM, 2) & ":" & Mid(DB_ORATM, 3, 2) & ":" & Right(DB_ORATM, 2)
        'UPGRADE_WARNING: オブジェクト IMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        IMA = System.DateTime.FromOADate(CDate(swk).ToOADate - DB_REALWAITSEC / nSecOfDay)
        'UPGRADE_WARNING: オブジェクト IMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
#Disable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", st=" & VB6.Format(IMA, "hhmmss")
#Enable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", et=" & DB_ORATM
        sMsg = sMsg & ", dt=" & DB_ORADT
        sMsg = sMsg & ", pn=" & G_sPRGNM
        If DB_REALWAITSEC = DB_MAXWAITSEC Then sMsg = sMsg & ", tpa=" & G_sUNIID
        Call DB3_OutBusyLog(sFName, sMsg)
    End Sub

    Sub DB2_TranLog()
        If G_bTool Then Exit Sub
        Dim sMsg, sFName, swk As String
        Dim nTranMS As Integer
        nTranMS = (VB.Timer() - G_nTranStt) * 1000
        sFName = TRAN_LOG_PATH & "TRAN.LOG"
        sMsg = "tp=TRAN, clid=" & G_sCLTID
#Disable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", pid=" & VB6.Format(G_sPRGID, "!@@@@@@@@@@")
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
        swk = Space(10) & VB6.Format(nTranMS, "##########")
#Enable Warning BC40000 ' Type or member is obsolete
        sMsg = sMsg & ", ms=" & Right(swk, 10)
        sMsg = sMsg & ", st=" & G_tmSTT
        Call DB2_UtlGetOraDT()
        sMsg = sMsg & ", et=" & DB_ORATM
        sMsg = sMsg & ", dt=" & DB_ORADT
        sMsg = sMsg & ", pn=" & G_sPRGNM
        sMsg = sMsg & ", tpa=" & G_sUNIID
        Call DB3_OutBusyLog(sFName, sMsg)
    End Sub

    Sub DB3_OutBusyLog(ByRef sFName As String, ByRef sMsg As String)
        Dim nErr As Integer
        On Error Resume Next
        Do
            Err.Clear()
            FileOpen(1, sFName, OpenMode.Append, , OpenShare.LockWrite)
            nErr = Err.Number
            '20190219
            'If nErr = 70 Then Call Sleep(G_RetryItv / 10) 'DoEvents
        Loop While (nErr = 70)
        PrintLine(1, sMsg)
        FileClose(1)
    End Sub

    'Sub Put_SYSTBL()
    '    Dim sSQL$
    '    sSQL$ = "INSERT INTO SYSTBL VALUES('" + G_sUNIID$ + "', 'Auto Inserted', '" _
    ''            + G_sOPEID$ + "', '" + G_sCLTID$ + "', '" _
    ''            + Format$(Time, "hhmmss") + "', '" + Format$(Date, "yyyymmdd") + "')"
    '    Do
    '        DBSTAT = Dll_Usr1Exec(sSQL$)
    '        If DBSTAT = 1 Then DBSTAT = 0
    '    Loop While IsBusy_ORA("Put_SYSTBL")
    'End Sub

    Function DB_LockOff(ByRef bIsCommit As Short) As Integer
        Dim sSQL As String
        DB_LockOff = 0
        'If IsMissing(bIsCommit%) Then bIsCommit% = 0
        'If G_sRRRLock <> "" Or G_sRRRLock2 <> "" Then
        If G_sRRRLock <> "" Or G_sRRRLock2 <> "" Or G_sRRRLock3 <> "" Then
            If bIsCommit Then
                sSQL = "COMMIT"
            Else
                sSQL = "ROLLBACK"
            End If
            Do
                '20190219
                'DBSTAT = Dll_Usr1Exec(sSQL)
            Loop While IsBusy_ORA("DB_LockOff")
        End If
        DB_LockOff = DBSTAT
    End Function

    'ADD START FKS)INABA 2009/09/17 ********************************
    '連絡票№706
    Function DB_LockOff2(ByRef bIsCommit As Short) As Integer
        Dim sSQL As String
        DB_LockOff2 = 0
        If G_sRRRLock <> "" Or G_sRRRLock2 <> "" Or G_sRRRLock3 <> "" Then
            If bIsCommit Then
                sSQL = "COMMIT"
            Else
                sSQL = "ROLLBACK"
            End If
            Do
                '20190219
                'DBSTAT = Dll_Usr1Exec(sSQL)
            Loop While IsBusy_ORA2("DB_LockOff")
        End If
        DB_LockOff2 = DBSTAT
    End Function
    'ADD  END  FKS)INABA 2009/09/17 *****************************************************

    'テキストファイルの削除処理
    'ADD START FKS)INABA 2009/09/17 **********************
    '連絡票№706
    Function Kill_FILE(ByRef strFILE1_PATH As String) As Boolean
        On Error GoTo Err_sec
        Kill_FILE = False
        If Trim(strFILE1_PATH) = "" Then
            GoTo END_FUNC
        End If
        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If Dir(strFILE1_PATH) <> "" Then
            Kill(strFILE1_PATH)
        End If
END_FUNC:
        Kill_FILE = True
        On Error GoTo 0
        Exit Function
Err_sec:
        Kill_FILE = False
        On Error GoTo 0
    End Function
    'ADD  END  FKS)INABA 2009/09/17 **********************



    ''Declare Function DB_ChgMode Lib "sssoraif" (ByVal sMode$) As Long
    Sub DB_ChgMode(ByRef sMode As String)
        Call ResetDBSTAT(-1)
        '20190219
        'DBSTAT = Dll_ChgMode(sMode)
        Call SetDBSTAT(DBSTAT)
        Call Ora_ErrorCheck("DB_ChgMode", -1)
    End Sub

    ''Declare Function DB_ClrMode Lib "sssoraif" () As Long
    Sub DB_ClrMode()
        Call ResetDBSTAT(-1)
        '20190219
        'DBSTAT = Dll_ClrMode()
        Call SetDBSTAT(DBSTAT)
        Call Ora_ErrorCheck("DB_ClrMode", -1)
    End Sub

    'Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno&, ByVal sDT$, ByVal sTM$) As Long
    '20190617 chg start
    'Sub DB_GetOraDT(ByRef Fno As Short)
    Sub DB_GetOraDT(ByRef Fno As Object)
        '20190617 chg end
        'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190617 del start
        'If Fno >= 0 Then If IS_ORA(Fno) = 0 Then Call Error_Exit("ファイルＮＯが無効です。:Fno=" & Str(Fno))
        '2190617 del end
        DB_ORADT = "        "
        DB_ORATM = "      "
        '20190219
        'DBSTAT = Dll_GetOraDT(Fno, DB_ORADT, DB_ORATM)
        DB_ORADT = Left(DB_ORADT, 8)
        DB_ORATM = Left(DB_ORATM, 6)
    End Sub

    Sub DB2_UtlGetOraDT()
        DB_ORADT = "        "
        DB_ORATM = "      "
        If G_bTool Then Exit Sub
        '20190219
        'Call Dll_GetOraDT(-1, DB_ORADT, DB_ORATM)
        DB_ORADT = Left(DB_ORADT, 8)
        DB_ORATM = Left(DB_ORATM, 6)
    End Sub

    Sub DB_SetPGID(ByRef sPGID As String)
        Call ResetDBSTAT(-1)
        '20190219
        'DBSTAT = Dll_SetPGID(sPGID)
        If DBSTAT = 0 Then
            G_sPRGID = Trim(sPGID)
            If G_sRRRLock = "TPA" Or G_sRRRLock2 = "TPA" Or G_sRRRLock3 = "TPA" Then Call GetTPA_Info()
        End If
        If Len(G_sPRGID) < 7 Then G_bTool = True Else G_bTool = False
        Call SetDBSTAT(DBSTAT)
        Call Ora_ErrorCheck("DB_SetPGID", -1)
    End Sub

    Sub DB_SetPGNM(ByRef sPGNM As String)
        Call ResetDBSTAT(-1)
        G_sPRGNM = Trim(sPGNM)
        Call SetDBSTAT(DBSTAT)
    End Sub

    Sub GetTPA_Info()
        Dim sBUF As String
        Dim bErr As Boolean
        bErr = False
        G_sUNIID = "" : G_nUNICNT = 0
        On Error GoTo ERR1
        FileOpen(1, USR_PATH & "DAT\" & G_sPRGID & ".TPA", OpenMode.Input)
        Do While EOF(1) = False
            sBUF = LineInput(1)
            If Len(sBUF) > 2 And Left(sBUF, 1) = "'" And Right(sBUF, 1) = "'" Then
                If G_nUNICNT Then G_sUNIID = G_sUNIID & ","
                G_sUNIID = G_sUNIID & sBUF
                G_nUNICNT = G_nUNICNT + 1
            Else
                bErr = True
                Err.Raise(1)
                'G_sUNIID$ = "": G_nUNICNT& = 0: Exit Do
            End If
        Loop
ERR1:
        If Err.Number Then bErr = True : G_sUNIID = "" : G_nUNICNT = 0
        FileClose(1)
        On Error GoTo 0
        If G_sUNIID = "" Then
            If bErr Then
                G_sRRRLock = "EXCLUSIVE"
                G_sRRRLock2 = "EXCLUSIVE"
                G_sRRRLock3 = "EXCLUSIVE"
                MsgBox("排他制御用の　TPA:" & G_sPRGID & ".TPA" & " ファイルが読み込めません。" & Chr(13) & "管理者に連絡して下さい。")
            Else
                G_sRRRLock = ""
                G_sRRRLock2 = ""
                G_sRRRLock3 = ""
            End If
        End If
    End Sub

    '20190610 add start
    ''' <summary>
    ''' テーブルとfrom以下を指定し、指定テーブルの全項目を取得(0行目)
    ''' </summary>
    ''' <param name="pTableName">テーブル名</param>
    ''' <param name="pWhere">from以下を指定(例)where 〇〇cd = 'a'～</param>
    Sub GetRowsCommon(ByVal pTableName As String, ByVal pWhere As String)

        Dim li_MsgRtn As Integer

        Try
            Dim sqlWhereStr As String = ""
            Dim sqlColumnsStr As String = ""

            sqlWhereStr = " " & pWhere

            '20190911 CHG START 仮
            'DB_GetData(pTableName, sqlWhereStr, "")

            'SetDataCommon(pTableName, GetNextRowsCommon(pTableName, SetDataCount(pTableName, True)))

            Dim cTableName As String = ""

            If pTableName.Contains("2") = True Then
                cTableName = pTableName.Replace("2", "")
            Else
                cTableName = pTableName
            End If

            DB_GetData(cTableName, sqlWhereStr, "")

            SetDataCommon(pTableName, GetNextRowsCommon(pTableName, SetDataCount(pTableName, True)))

            '20190911 CHG END 仮


        Catch ex As Exception
            li_MsgRtn = MsgBox("GetRowsCommon" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        Finally

        End Try

    End Sub

    ''' <summary>
    ''' GetRowsCommonで取得したデータを構造体にセットする
    ''' </summary>
    ''' <param name="pTablename">テーブル名</param>
    ''' <param name="dataCount">列数</param>
    ''' <returns>構造体</returns>
    Function GetNextRowsCommon(ByVal pTablename As String, ByVal dataCount As Integer) As Object
        Dim li_MsgRtn As Integer
        Dim t As Type

        t = GetTableType(pTablename, 2)

        Dim members As MemberInfo() = t.GetMembers(
            BindingFlags.Public Or BindingFlags.NonPublic Or
            BindingFlags.Instance Or BindingFlags.Static Or
            BindingFlags.DeclaredOnly)

        Dim v As ValueType = GetTableType(pTablename, 1)
        Dim f As FieldInfo
        Dim m As MemberInfo

        Try

            DBSTAT = 1

            '構造体初期化
            InitDataCommon(pTablename)

            If dsList.Tables(pTablename).Rows.Count - 1 < dataCount Then
                Return Nothing
            End If

            Select Case pTablename
                Case "HINSMA"
                    Set_DB_HINSMA(dsList.Tables(pTablename), v, dataCount)
                Case "TANSMA"
                    Set_DB_TANSMA(dsList.Tables(pTablename), v, dataCount)
                Case "TOKMTB"
                    Set_DB_TOKMTB(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSMA"
                    Set_DB_TOKSMA(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSMB"
                    Set_DB_TOKSMB(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSMC"
                    Set_DB_TOKSMC(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSME"
                    Set_DB_TOKSME(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSSA"
                    Set_DB_TOKSSA(dsList.Tables(pTablename), v, dataCount)
                Case "TOKSSB"
                    Set_DB_TOKSSB(dsList.Tables(pTablename), v, dataCount)
                Case "ZAISMA"
                    Set_DB_ZAISMA(dsList.Tables(pTablename), v, dataCount)
                Case "CNT_USR9.SEIPR53"
                    Set_DB_SEIPR53(dsList.Tables(pTablename), v, dataCount)
                Case Else
                    For Each m In members
                        'メンバの型と、名前を表示する
                        Console.WriteLine("{0} - {1}", m.MemberType, m.Name)

                        f = v.GetType().GetField(m.Name)

                        For i As Integer = 0 To dsList.Tables(pTablename).Columns.Count - 1
                            If dsList.Tables(pTablename).Columns(i).Caption = m.Name Then
                                If f.FieldType.Name = "String" Then
                                    f.SetValue(v, DB_NullReplace(dsList.Tables(pTablename).Rows(dataCount).Item(m.Name), ""))
                                Else
                                    f.SetValue(v, DB_NullReplace(dsList.Tables(pTablename).Rows(dataCount).Item(m.Name), 0))
                                End If
                                v = DirectCastData(pTablename, v)
                                Exit For
                            End If
                        Next
                    Next
            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox(ex.ToString)
        End Try

        DBSTAT = 0
        Return v

    End Function

    Public Function GetTableType(ByVal pTableName As String, ByVal pNum As Integer) As Object
#Region "データ型を渡す"
        Select Case pTableName

            Case "BMNMTA"
                If pNum = 1 Then
                    Return DB_BMNMTA
                Else
                    Return GetType(TYPE_DB_BMNMTA)
                End If

            Case "BMNMTA2"
                If pNum = 1 Then
                    Return DB_BMNMTA2
                Else
                    Return GetType(TYPE_DB_BMNMTA2)
                End If

            Case "BMNMTB"
                If pNum = 1 Then
                    Return DB_BMNMTB
                Else
                    Return GetType(TYPE_DB_BMNMTB)
                End If

            Case "BNKMTA"
                If pNum = 1 Then
                    Return DB_BNKMTA
                Else
                    Return GetType(TYPE_DB_BNKMTA)
                End If

            Case "CLDMTA"
                If pNum = 1 Then
                    Return DB_CLDMTA
                Else
                    Return GetType(TYPE_DB_CLDMTA)
                End If

            Case "CLSMTB"
                If pNum = 1 Then
                    Return DB_CLSMTB
                Else
                    Return GetType(TYPE_DB_CLSMTB)
                End If

            Case "ENDMTA"
                If pNum = 1 Then
                    Return DB_ENDMTA
                Else
                    Return GetType(TYPE_DB_ENDMTA)
                End If

            Case "EXCTBZ"
                If pNum = 1 Then
                    Return DB_EXCTBZ
                Else
                    Return GetType(TYPE_DB_EXCTBZ)
                End If

            Case "FBTRA"
                If pNum = 1 Then
                    Return DB_FBTRA
                Else
                    Return GetType(TYPE_DB_FBTRA)
                End If

            Case "FDNTHA"
                If pNum = 1 Then
                    Return DB_FDNTHA
                Else
                    Return GetType(TYPE_DB_FDNTHA)
                End If

            Case "FDNTRA"
                If pNum = 1 Then
                    Return DB_FDNTRA
                Else
                    Return GetType(TYPE_DB_FDNTRA)
                End If

            Case "FIXMTA"
                If pNum = 1 Then
                    Return DB_FIXMTA
                Else
                    Return GetType(TYPE_DB_FIXMTA)
                End If

            Case "FIXMTA2"
                If pNum = 1 Then
                    Return DB_FIXMTA2
                Else
                    Return GetType(TYPE_DB_FIXMTA2)
                End If

            Case "GYMTBZ"
                If pNum = 1 Then
                    Return DB_GYMTBZ
                Else
                    Return GetType(TYPE_DB_GYMTBZ)
                End If

            Case "HINMTA"
                If pNum = 1 Then
                    Return DB_HINMTA
                Else
                    Return GetType(TYPE_DB_HINMTA)
                End If

            Case "HINMTB"
                If pNum = 1 Then
                    Return DB_HINMTB
                Else
                    Return GetType(TYPE_DB_HINMTB)
                End If

            Case "HINSMA"
                If pNum = 1 Then
                    Return DB_HINSMA
                Else
                    Return GetType(TYPE_DB_HINSMA)
                End If

            Case "HDNTHA"
                If pNum = 1 Then
                    Return DB_HDNTHA
                Else
                    Return GetType(TYPE_DB_HDNTHA)
                End If

            Case "HDNTRA"
                If pNum = 1 Then
                    Return DB_HDNTRA
                Else
                    Return GetType(TYPE_DB_HDNTRA)
                End If

            Case "SYSTBE"
                If pNum = 1 Then
                    Return DB_SYSTBE
                Else
                    Return GetType(TYPE_DB_SYSTBE)
                End If

            Case "JDNTHA"
                If pNum = 1 Then
                    Return DB_JDNTHA
                Else
                    Return GetType(TYPE_DB_JDNTHA)
                End If

            Case "JDNTHA2"
                If pNum = 1 Then
                    Return DB_JDNTHA2
                Else
                    Return GetType(TYPE_DB_JDNTHA2)
                End If

            Case "JDNTRA"
                If pNum = 1 Then
                    Return DB_JDNTRA
                Else
                    Return GetType(TYPE_DB_JDNTRA)
                End If

            Case "JDNTRA2"
                If pNum = 1 Then
                    Return DB_JDNTRA2
                Else
                    Return GetType(TYPE_DB_JDNTRA2)
                End If

            Case "JDNDL01"
                If pNum = 1 Then
                    Return DB_JDNDL01
                Else
                    Return GetType(TYPE_DB_JDNDL01)
                End If

            Case "KNGMTA"
                If pNum = 1 Then
                    Return DB_KNGMTA
                Else
                    Return GetType(TYPE_DB_KNGMTA)
                End If

            Case "KNGMTB"
                If pNum = 1 Then
                    Return DB_KNGMTB
                Else
                    Return GetType(TYPE_DB_KNGMTB)
                End If

            Case "MEIMTA"
                If pNum = 1 Then
                    Return DB_MEIMTA
                Else
                    Return GetType(TYPE_DB_MEIMTA)
                End If

            Case "MEIMTB"
                If pNum = 1 Then
                    Return DB_MEIMTB
                Else
                    Return GetType(TYPE_DB_MEIMTB)
                End If

            Case "MEIMTC"
                If pNum = 1 Then
                    Return DB_MEIMTC
                Else
                    Return GetType(TYPE_DB_MEIMTC)
                End If

            Case "NHSMTA"
                If pNum = 1 Then
                    Return DB_NHSMTA
                Else
                    Return GetType(TYPE_DB_NHSMTA)
                End If

            Case "NHSMTA2"
                If pNum = 1 Then
                    Return DB_NHSMTA2
                Else
                    Return GetType(TYPE_DB_NHSMTA2)
                End If

            Case "ODNTRA"
                If pNum = 1 Then
                    Return DB_ODNTRA
                Else
                    Return GetType(TYPE_DB_ODNTRA)
                End If

            Case "ORDTHB"
                If pNum = 1 Then
                    Return DB_ORDTHB
                Else
                    Return GetType(TYPE_DB_ORDTHB)
                End If

            Case "ORDTRB"
                If pNum = 1 Then
                    Return DB_ORDTRB
                Else
                    Return GetType(TYPE_DB_ORDTRB)
                End If

            Case "RNKMTA"
                If pNum = 1 Then
                    Return DB_RNKMTA
                Else
                    Return GetType(TYPE_DB_RNKMTA)
                End If

            Case "RNKMTA2"
                If pNum = 1 Then
                    Return DB_RNKMTA2
                Else
                    Return GetType(TYPE_DB_RNKMTA2)
                End If

            Case "SDNTHA"
                If pNum = 1 Then
                    Return DB_SDNTHA
                Else
                    Return GetType(TYPE_DB_SDNTHA)
                End If

            Case "SDNTRA"
                If pNum = 1 Then
                    Return DB_SDNTRA
                Else
                    Return GetType(TYPE_DB_SDNTRA)
                End If

            Case "SIRMTA"
                If pNum = 1 Then
                    Return DB_SIRMTA
                Else
                    Return GetType(TYPE_DB_SIRMTA)
                End If

            Case "SOUMTA"
                If pNum = 1 Then
                    Return DB_SOUMTA
                Else
                    Return GetType(TYPE_DB_SOUMTA)
                End If

            Case "SOUMTA2"
                If pNum = 1 Then
                    Return DB_SOUMTA2
                Else
                    Return GetType(TYPE_DB_SOUMTA2)
                End If

            Case "SRACNTTB"
                If pNum = 1 Then
                    Return DB_SRACNTTB
                Else
                    Return GetType(TYPE_DB_SRACNTTB)
                End If

            Case "SRARSTTB"
                If pNum = 1 Then
                    Return DB_SRARSTTB
                Else
                    Return GetType(TYPE_DB_SRARSTTB)
                End If

            Case "SYKTRA"
                If pNum = 1 Then
                    Return DB_SYKTRA
                Else
                    Return GetType(TYPE_DB_SYKTRA)
                End If

            Case "SYSTBA"
                If pNum = 1 Then
                    Return DB_SYSTBA
                Else
                    Return GetType(TYPE_DB_SYSTBA)
                End If

            Case "SYSTBB"
                If pNum = 1 Then
                    Return DB_SYSTBB
                Else
                    Return GetType(TYPE_DB_SYSTBB)
                End If

            Case "SYSTBC"
                If pNum = 1 Then
                    Return DB_SYSTBC
                Else
                    Return GetType(TYPE_DB_SYSTBC)
                End If

            Case "SYSTBD"
                If pNum = 1 Then
                    Return DB_SYSTBD
                Else
                    Return GetType(TYPE_DB_SYSTBD)
                End If

            Case "SYSTBF"
                If pNum = 1 Then
                    Return DB_SYSTBF
                Else
                    Return GetType(TYPE_DB_SYSTBF)
                End If

            Case "SYSTBG"
                If pNum = 1 Then
                    Return DB_SYSTBG
                Else
                    Return GetType(TYPE_DB_SYSTBG)
                End If

            Case "SYSTBH"
                If pNum = 1 Then
                    Return DB_SYSTBH
                Else
                    Return GetType(TYPE_DB_SYSTBH)
                End If

            Case "SYSTBI"
                If pNum = 1 Then
                    Return DB_SYSTBI
                Else
                    Return GetType(TYPE_DB_SYSTBI)
                End If

            Case "SYSTBM"
                If pNum = 1 Then
                    Return DB_SYSTBM
                Else
                    Return GetType(TYPE_DB_SYSTBM)
                End If

            Case "TANMTA"
                If pNum = 1 Then
                    Return DB_TANMTA
                Else
                    Return GetType(TYPE_DB_TANMTA)
                End If

            Case "TANSMA"
                If pNum = 1 Then
                    Return DB_TANSMA
                Else
                    Return GetType(TYPE_DB_TANSMA)
                End If

            Case "TANWTA"
                If pNum = 1 Then
                    Return DB_TANWTA
                Else
                    Return GetType(TYPE_DB_TANWTA)
                End If

            Case "TOKMTA"
                If pNum = 1 Then
                    Return DB_TOKMTA
                Else
                    Return GetType(TYPE_DB_TOKMTA)
                End If

            Case "TOKMTA2"
                If pNum = 1 Then
                    Return DB_TOKMTA2
                Else
                    Return GetType(TYPE_DB_TOKMTA2)
                End If

            Case "TOKMTB"
                If pNum = 1 Then
                    Return DB_TOKMTB
                Else
                    Return GetType(TYPE_DB_TOKMTB)
                End If

            Case "TOKSMA"
                If pNum = 1 Then
                    Return DB_TOKSMA
                Else
                    Return GetType(TYPE_DB_TOKSMA)
                End If

            Case "TOKSMB"
                If pNum = 1 Then
                    Return DB_TOKSMB
                Else
                    Return GetType(TYPE_DB_TOKSMB)
                End If

            Case "TOKSMC"
                If pNum = 1 Then
                    Return DB_TOKSMC
                Else
                    Return GetType(TYPE_DB_TOKSMC)
                End If

            Case "TOKSME"
                If pNum = 1 Then
                    Return DB_TOKSME
                Else
                    Return GetType(TYPE_DB_TOKSME)
                End If

            Case "TOKSSA"
                If pNum = 1 Then
                    Return DB_TOKSSA
                Else
                    Return GetType(TYPE_DB_TOKSSA)
                End If

            Case "TOKSSB"
                If pNum = 1 Then
                    Return DB_TOKSSB
                Else
                    Return GetType(TYPE_DB_TOKSSB)
                End If

            Case "TUKMTA"
                If pNum = 1 Then
                    Return DB_TUKMTA
                Else
                    Return GetType(TYPE_DB_TUKMTA)
                End If

            Case "UDNTHA"
                If pNum = 1 Then
                    Return DB_UDNTHA
                Else
                    Return GetType(TYPE_DB_UDNTHA)
                End If

            Case "UDNTRA"
                If pNum = 1 Then
                    Return DB_UDNTRA
                Else
                    Return GetType(TYPE_DB_UDNTRA)
                End If

            Case "UNTMTA"
                If pNum = 1 Then
                    Return DB_UNTMTA
                Else
                    Return GetType(TYPE_DB_UNTMTA)
                End If

            Case "UNYMTA"
                If pNum = 1 Then
                    Return DB_UNYMTA
                Else
                    Return GetType(TYPE_DB_UNYMTA)
                End If

            Case "YSNTRA"
                If pNum = 1 Then
                    Return DB_YSNTRA
                Else
                    Return GetType(TYPE_DB_YSNTRA)
                End If

            Case "ZAISMA"
                If pNum = 1 Then
                    Return DB_ZAISMA
                Else
                    Return GetType(TYPE_DB_ZAISMA)
                End If

            Case "CNT_USR9.SEIPR53"
                If pNum = 1 Then
                    Return DB_SEIPR53
                Else
                    Return GetType(TYPE_DB_SEIPR53)
                End If

        End Select
#End Region
    End Function

    Public Sub InitDataCommon(ByVal pTableName As String)
#Region "構造体を初期化する"
        Select Case pTableName
            Case "BMNMTA"
                DB_BMNMTA = New TYPE_DB_BMNMTA
                Exit Sub

            Case "BMNMTA2"
                DB_BMNMTA2 = New TYPE_DB_BMNMTA2
                Exit Sub

            Case "BMNMTB"
                DB_BMNMTB = New TYPE_DB_BMNMTB
                Exit Sub

            Case "BNKMTA"
                DB_BNKMTA = New TYPE_DB_BNKMTA
                Exit Sub

            Case "CLDMTA"
                DB_CLDMTA = New TYPE_DB_CLDMTA
                Exit Sub

            Case "CLSMTA"
                DB_CLSMTA = New TYPE_DB_CLSMTA
                Exit Sub

            Case "CLSMTB"
                DB_CLSMTB = New TYPE_DB_CLSMTB
                Exit Sub

            Case "ENDMTA"
                DB_ENDMTA = New TYPE_DB_ENDMTA
                Exit Sub

            Case "EXCTBZ"
                DB_EXCTBZ = New TYPE_DB_EXCTBZ
                Exit Sub

            Case "FBTRA"
                DB_FBTRA = New TYPE_DB_FBTRA
                Exit Sub

            Case "FDNTHA"
                DB_FDNTHA = New TYPE_DB_FDNTHA
                Exit Sub

            Case "FDNTRA"
                DB_FDNTRA = New TYPE_DB_FDNTRA
                Exit Sub

            Case "FIXMTA"
                DB_FIXMTA = New TYPE_DB_FIXMTA
                Exit Sub

            Case "FIXMTA2"
                DB_FIXMTA2 = New TYPE_DB_FIXMTA2
                Exit Sub

            Case "GYMTBZ"
                DB_GYMTBZ = New TYPE_DB_GYMTBZ
                Exit Sub

            Case "HINMTA"
                DB_HINMTA = New TYPE_DB_HINMTA
                Exit Sub

            Case "HINMTB"
                DB_HINMTB = New TYPE_DB_HINMTB
                Exit Sub

            Case "HINSMA"
                DB_HINSMA = New TYPE_DB_HINSMA
                Exit Sub

            Case "HDNTHA"
                DB_HDNTHA = New TYPE_DB_HDNTHA
                Exit Sub

            Case "HDNTRA"
                DB_HDNTRA = New TYPE_DB_HDNTRA
                Exit Sub

            Case "SYSTBE"
                DB_SYSTBE = New TYPE_DB_SYSTBE
                Exit Sub

            Case "JDNTHA"
                DB_JDNTHA = New TYPE_DB_JDNTHA
                Exit Sub

            Case "JDNTHA2"
                DB_JDNTHA2 = New TYPE_DB_JDNTHA2
                Exit Sub

            Case "JDNTRA"
                DB_JDNTRA = New TYPE_DB_JDNTRA
                Exit Sub

            Case "JDNTRA2"
                DB_JDNTRA2 = New TYPE_DB_JDNTRA2
                Exit Sub

            Case "JDNDL01"
                DB_JDNDL01 = New TYPE_DB_JDNDL01
                Exit Sub

            Case "KNGMTA"
                DB_KNGMTA = New TYPE_DB_KNGMTA
                Exit Sub

            Case "KNGMTB"
                DB_KNGMTB = New TYPE_DB_KNGMTB
                Exit Sub

            Case "MEIMTA"
                DB_MEIMTA = New TYPE_DB_MEIMTA
                Exit Sub

            Case "MEIMTB"
                DB_MEIMTB = New TYPE_DB_MEIMTB
                Exit Sub

            Case "MEIMTC"
                DB_MEIMTC = New TYPE_DB_MEIMTC
                Exit Sub

            Case "NHSMTA"
                DB_NHSMTA = New TYPE_DB_NHSMTA
                Exit Sub

            Case "NHSMTA2"
                DB_NHSMTA2 = New TYPE_DB_NHSMTA2
                Exit Sub

            Case "ODNTRA"
                DB_ODNTRA = New TYPE_DB_ODNTRA
                Exit Sub

            Case "ORDTHB"
                DB_ORDTHB = New TYPE_DB_ORDTHB
                Exit Sub

            Case "ORDTRB"
                DB_ORDTRB = New TYPE_DB_ORDTRB
                Exit Sub

            Case "RNKMTA"
                DB_RNKMTA = New TYPE_DB_RNKMTA
                Exit Sub

            Case "RNKMTA2"
                DB_RNKMTA2 = New TYPE_DB_RNKMTA2
                Exit Sub

            Case "SDNTHA"
                DB_SDNTHA = New TYPE_DB_SDNTHA
                Exit Sub

            Case "SDNTRA"
                DB_SDNTRA = New TYPE_DB_SDNTRA
                Exit Sub

            Case "SIRMTA"
                DB_SIRMTA = New TYPE_DB_SIRMTA
                Exit Sub

            Case "SOUMTA"
                DB_SOUMTA = New TYPE_DB_SOUMTA
                Exit Sub

            Case "SOUMTA2"
                DB_SOUMTA2 = New TYPE_DB_SOUMTA2
                Exit Sub

            Case "SRACNTTB"
                DB_SRACNTTB = New TYPE_DB_SRACNTTB
                Exit Sub

            Case "SRARSTTB"
                DB_SRARSTTB = New TYPE_DB_SRARSTTB
                Exit Sub

            Case "SYKTRA"
                DB_SYKTRA = New TYPE_DB_SYKTRA
                Exit Sub

            Case "SYSTBA"
                DB_SYSTBA = New TYPE_DB_SYSTBA
                Exit Sub

            Case "SYSTBB"
                DB_SYSTBB = New TYPE_DB_SYSTBB
                Exit Sub

            Case "SYSTBC"
                DB_SYSTBC = New TYPE_DB_SYSTBC
                Exit Sub

            Case "SYSTBD"
                DB_SYSTBD = New TYPE_DB_SYSTBD
                Exit Sub

            Case "SYSTBF"
                DB_SYSTBF = New TYPE_DB_SYSTBF
                Exit Sub

            Case "SYSTBG"
                DB_SYSTBG = New TYPE_DB_SYSTBG
                Exit Sub

            Case "SYSTBH"
                DB_SYSTBH = New TYPE_DB_SYSTBH
                Exit Sub

            Case "SYSTBI"
                DB_SYSTBI = New TYPE_DB_SYSTBI
                Exit Sub

            Case "SYSTBM"
                DB_SYSTBM = New TYPE_DB_SYSTBM
                Exit Sub

            Case "TANMTA"
                DB_TANMTA = New TYPE_DB_TANMTA
                Exit Sub

            Case "TANSMA"
                DB_TANSMA = New TYPE_DB_TANSMA
                Exit Sub

            Case "TANWTA"
                DB_TANWTA = New TYPE_DB_TANWTA
                Exit Sub

            Case "TOKMTA"
                DB_TOKMTA = New TYPE_DB_TOKMTA
                Exit Sub

            Case "TOKMTA2"
                DB_TOKMTA2 = New TYPE_DB_TOKMTA2
                Exit Sub

            Case "TOKMTB"
                DB_TOKMTB = New TYPE_DB_TOKMTB
                Exit Sub

            Case "TOKSMA"
                DB_TOKSMA = New TYPE_DB_TOKSMA
                Exit Sub

            Case "TOKSMB"
                DB_TOKSMB = New TYPE_DB_TOKSMB
                Exit Sub

            Case "TOKSMC"
                DB_TOKSMC = New TYPE_DB_TOKSMC
                Exit Sub

            Case "TOKSME"
                DB_TOKSME = New TYPE_DB_TOKSME
                Exit Sub

            Case "TOKSSA"
                DB_TOKSSA = New TYPE_DB_TOKSSA
                Exit Sub

            Case "TOKSSB"
                DB_TOKSSB = New TYPE_DB_TOKSSB
                Exit Sub

            Case "TUKMTA"
                DB_TUKMTA = New TYPE_DB_TUKMTA
                Exit Sub

            Case "UDNTHA"
                DB_UDNTHA = New TYPE_DB_UDNTHA
                Exit Sub

            Case "UDNTRA"
                DB_UDNTRA = New TYPE_DB_UDNTRA
                Exit Sub

            Case "UNTMTA"
                DB_UNTMTA = New TYPE_DB_UNTMTA
                Exit Sub

            Case "UNYMTA"
                DB_UNYMTA = New TYPE_DB_UNYMTA
                Exit Sub

            Case "YSNTRA"
                DB_YSNTRA = New TYPE_DB_YSNTRA
                Exit Sub

            Case "ZAISMA"
                DB_ZAISMA = New TYPE_DB_ZAISMA
                Exit Sub

            Case "CNT_USR9.SEIPR53"
                DB_SEIPR53 = New TYPE_DB_SEIPR53
                Exit Sub

        End Select
#End Region
    End Sub

    Public Function DirectCastData(ByVal pTableName As String, ByVal pValueType As ValueType) As ValueType
#Region "データをキャストする"
        Select Case pTableName
            Case "BMNMTA"
                Return DirectCast(pValueType, TYPE_DB_BMNMTA)

            Case "BMNMTA2"
                Return DirectCast(pValueType, TYPE_DB_BMNMTA2)

            Case "BMNMTB"
                Return DirectCast(pValueType, TYPE_DB_BMNMTB)

            Case "BNKMTA"
                Return DirectCast(pValueType, TYPE_DB_BNKMTA)

            Case "CLDMTA"
                Return DirectCast(pValueType, TYPE_DB_CLDMTA)

            Case "CLSMTA"
                Return DirectCast(pValueType, TYPE_DB_CLSMTA)

            Case "CLSMTB"
                Return DirectCast(pValueType, TYPE_DB_CLSMTB)

            Case "ENDMTA"
                Return DirectCast(pValueType, TYPE_DB_ENDMTA)

            Case "EXCTBZ"
                Return DirectCast(pValueType, TYPE_DB_EXCTBZ)

            Case "FBTRA"
                Return DirectCast(pValueType, TYPE_DB_FBTRA)

            Case "FDNTHA"
                Return DirectCast(pValueType, TYPE_DB_FDNTHA)

            Case "FDNTRA"
                Return DirectCast(pValueType, TYPE_DB_FDNTRA)

            Case "FIXMTA"
                Return DirectCast(pValueType, TYPE_DB_FIXMTA)

            Case "FIXMTA2"
                Return DirectCast(pValueType, TYPE_DB_FIXMTA2)

            Case "GYMTBZ"
                Return DirectCast(pValueType, TYPE_DB_GYMTBZ)

            Case "HINMTA"
                Return DirectCast(pValueType, TYPE_DB_HINMTA)

            Case "HINMTB"
                Return DirectCast(pValueType, TYPE_DB_HINMTB)

            Case "HINSMA"
                Return DirectCast(pValueType, TYPE_DB_HINSMA)

            Case "HDNTHA"
                Return DirectCast(pValueType, TYPE_DB_HDNTHA)

            Case "HDNTRA"
                Return DirectCast(pValueType, TYPE_DB_HDNTRA)

            Case "SYSTBE"
                Return DirectCast(pValueType, TYPE_DB_SYSTBE)

            Case "JDNTHA"
                Return DirectCast(pValueType, TYPE_DB_JDNTHA)

            Case "JDNTHA2"
                Return DirectCast(pValueType, TYPE_DB_JDNTHA2)

            Case "JDNTRA"
                Return DirectCast(pValueType, TYPE_DB_JDNTRA)

            Case "JDNTRA2"
                Return DirectCast(pValueType, TYPE_DB_JDNTRA2)

            Case "JDNDL01"
                Return DirectCast(pValueType, TYPE_DB_JDNDL01)

            Case "KNGMTA"
                Return DirectCast(pValueType, TYPE_DB_KNGMTA)

            Case "KNGMTB"
                Return DirectCast(pValueType, TYPE_DB_KNGMTB)

            Case "MEIMTA"
                Return DirectCast(pValueType, TYPE_DB_MEIMTA)

            Case "MEIMTB"
                Return DirectCast(pValueType, TYPE_DB_MEIMTB)

            Case "MEIMTC"
                Return DirectCast(pValueType, TYPE_DB_MEIMTC)

            Case "NHSMTA"
                Return DirectCast(pValueType, TYPE_DB_NHSMTA)

            Case "NHSMTA2"
                Return DirectCast(pValueType, TYPE_DB_NHSMTA2)

            Case "ODNTRA"
                Return DirectCast(pValueType, TYPE_DB_ODNTRA)

            Case "ORDTHB"
                Return DirectCast(pValueType, TYPE_DB_ORDTHB)

            Case "ORDTRB"
                Return DirectCast(pValueType, TYPE_DB_ORDTRB)

            Case "RNKMTA"
                Return DirectCast(pValueType, TYPE_DB_RNKMTA)

            Case "RNKMTA2"
                Return DirectCast(pValueType, TYPE_DB_RNKMTA2)

            Case "SDNTHA"
                Return DirectCast(pValueType, TYPE_DB_SDNTHA)

            Case "SDNTRA"
                Return DirectCast(pValueType, TYPE_DB_SDNTRA)

            Case "SIRMTA"
                Return DirectCast(pValueType, TYPE_DB_SIRMTA)

            Case "SOUMTA"
                Return DirectCast(pValueType, TYPE_DB_SOUMTA)

            Case "SOUMTA2"
                Return DirectCast(pValueType, TYPE_DB_SOUMTA2)

            Case "SRACNTTB"
                Return DirectCast(pValueType, TYPE_DB_SRACNTTB)

            Case "SRARSTTB"
                Return DirectCast(pValueType, TYPE_DB_SRARSTTB)

            Case "SYKTRA"
                Return DirectCast(pValueType, TYPE_DB_SYKTRA)

            Case "SYSTBA"
                Return DirectCast(pValueType, TYPE_DB_SYSTBA)

            Case "SYSTBB"
                Return DirectCast(pValueType, TYPE_DB_SYSTBB)

            Case "SYSTBC"
                Return DirectCast(pValueType, TYPE_DB_SYSTBC)

            Case "SYSTBD"
                Return DirectCast(pValueType, TYPE_DB_SYSTBD)

            Case "SYSTBF"
                Return DirectCast(pValueType, TYPE_DB_SYSTBF)

            Case "SYSTBG"
                Return DirectCast(pValueType, TYPE_DB_SYSTBG)

            Case "SYSTBH"
                Return DirectCast(pValueType, TYPE_DB_SYSTBH)

            Case "SYSTBI"
                Return DirectCast(pValueType, TYPE_DB_SYSTBI)

            Case "SYSTBM"
                Return DirectCast(pValueType, TYPE_DB_SYSTBM)

            Case "TANMTA"
                Return DirectCast(pValueType, TYPE_DB_TANMTA)

            Case "TANSMA"
                Return DirectCast(pValueType, TYPE_DB_TANSMA)

            Case "TANWTA"
                Return DirectCast(pValueType, TYPE_DB_TANWTA)

            Case "TOKMTA"
                Return DirectCast(pValueType, TYPE_DB_TOKMTA)

            Case "TOKMTA2"
                Return DirectCast(pValueType, TYPE_DB_TOKMTA2)

            Case "TOKMTB"
                Return DirectCast(pValueType, TYPE_DB_TOKMTB)

            Case "TOKSMA"
                Return DirectCast(pValueType, TYPE_DB_TOKSMA)

            Case "TOKSMB"
                Return DirectCast(pValueType, TYPE_DB_TOKSMB)

            Case "TOKSMC"
                Return DirectCast(pValueType, TYPE_DB_TOKSMC)

            Case "TOKSME"
                Return DirectCast(pValueType, TYPE_DB_TOKSME)

            Case "TOKSSA"
                Return DirectCast(pValueType, TYPE_DB_TOKSSA)

            Case "TOKSSB"
                Return DirectCast(pValueType, TYPE_DB_TOKSSB)

            Case "TUKMTA"
                Return DirectCast(pValueType, TYPE_DB_TUKMTA)

            Case "UDNTHA"
                Return DirectCast(pValueType, TYPE_DB_UDNTHA)

            Case "UDNTRA"
                Return DirectCast(pValueType, TYPE_DB_UDNTRA)

            Case "UNTMTA"
                Return DirectCast(pValueType, TYPE_DB_UNTMTA)

            Case "UNYMTA"
                Return DirectCast(pValueType, TYPE_DB_UNYMTA)

            Case "YSNTRA"
                Return DirectCast(pValueType, TYPE_DB_YSNTRA)

            Case "ZAISMA"
                Return DirectCast(pValueType, TYPE_DB_ZAISMA)

            Case "CNT_USR9.SEIPR53"
                Return DirectCast(pValueType, TYPE_DB_SEIPR53)

        End Select
#End Region
    End Function

    Public Sub SetDataCommon(ByVal pTableName As String, ByVal pData As Object)
#Region "データをセットする"
        Select Case pTableName
            Case "BMNMTA"
                DB_BMNMTA = pData
                Exit Sub

            Case "BMNMTA2"
                DB_BMNMTA2 = pData
                Exit Sub

            Case "BMNMTB"
                DB_BMNMTB = pData
                Exit Sub


            Case "BNKMTA"
                DB_BNKMTA = pData
                Exit Sub


            Case "CLDMTA"
                DB_CLDMTA = pData
                Exit Sub


            Case "CLSMTA"
                DB_CLSMTA = pData
                Exit Sub


            Case "CLSMTB"
                DB_CLSMTB = pData
                Exit Sub


            Case "ENDMTA"
                DB_ENDMTA = pData
                Exit Sub


            Case "EXCTBZ"
                DB_EXCTBZ = pData
                Exit Sub


            Case "FBTRA"
                DB_FBTRA = pData
                Exit Sub


            Case "FDNTHA"
                DB_FDNTHA = pData
                Exit Sub


            Case "FDNTRA"
                DB_FDNTRA = pData
                Exit Sub


            Case "FIXMTA"
                DB_FIXMTA = pData
                Exit Sub


            Case "FIXMTA2"
                DB_FIXMTA2 = pData
                Exit Sub


            Case "GYMTBZ"
                DB_GYMTBZ = pData
                Exit Sub


            Case "HINMTA"
                DB_HINMTA = pData
                Exit Sub


            Case "HINMTB"
                DB_HINMTB = pData
                Exit Sub


            Case "HINSMA"
                DB_HINSMA = pData
                Exit Sub


            Case "HDNTHA"
                DB_HDNTHA = pData
                Exit Sub


            Case "HDNTRA"
                DB_HDNTRA = pData
                Exit Sub


            Case "SYSTBE"
                DB_SYSTBE = pData
                Exit Sub


            Case "JDNTHA"
                DB_JDNTHA = pData
                Exit Sub

            Case "JDNTHA2"
                DB_JDNTHA2 = pData
                Exit Sub


            Case "JDNTRA"
                DB_JDNTRA = pData
                Exit Sub

            Case "JDNTRA2"
                DB_JDNTRA2 = pData
                Exit Sub

            Case "JDNDL01"
                DB_JDNDL01 = pData
                Exit Sub

            Case "KNGMTA"
                DB_KNGMTA = pData
                Exit Sub


            Case "KNGMTB"
                DB_KNGMTB = pData
                Exit Sub

            Case "MEIMTA"
                DB_MEIMTA = pData
                Exit Sub

            Case "MEIMTB"
                DB_MEIMTB = pData
                Exit Sub


            Case "MEIMTC"
                DB_MEIMTC = pData
                Exit Sub


            Case "NHSMTA"
                DB_NHSMTA = pData
                Exit Sub


            Case "NHSMTA2"
                DB_NHSMTA2 = pData
                Exit Sub


            Case "ODNTRA"
                DB_ODNTRA = pData
                Exit Sub


            Case "ORDTHB"
                DB_ORDTHB = pData
                Exit Sub


            Case "ORDTRB"
                DB_ORDTRB = pData
                Exit Sub


            Case "RNKMTA"
                DB_RNKMTA = pData
                Exit Sub


            Case "RNKMTA2"
                DB_RNKMTA2 = pData
                Exit Sub


            Case "SDNTHA"
                DB_SDNTHA = pData
                Exit Sub


            Case "SDNTRA"
                DB_SDNTRA = pData
                Exit Sub


            Case "SIRMTA"
                DB_SIRMTA = pData
                Exit Sub


            Case "SOUMTA"
                DB_SOUMTA = pData
                Exit Sub


            Case "SOUMTA2"
                DB_SOUMTA2 = pData
                Exit Sub


            Case "SRACNTTB"
                DB_SRACNTTB = pData
                Exit Sub


            Case "SRARSTTB"
                DB_SRARSTTB = pData
                Exit Sub


            Case "SYKTRA"
                DB_SYKTRA = pData
                Exit Sub


            Case "SYSTBA"
                DB_SYSTBA = pData
                Exit Sub


            Case "SYSTBB"
                DB_SYSTBB = pData
                Exit Sub


            Case "SYSTBC"
                DB_SYSTBC = pData
                Exit Sub


            Case "SYSTBD"
                DB_SYSTBD = pData
                Exit Sub


            Case "SYSTBF"
                DB_SYSTBF = pData
                Exit Sub


            Case "SYSTBG"
                DB_SYSTBG = pData
                Exit Sub


            Case "SYSTBH"
                DB_SYSTBH = pData
                Exit Sub


            Case "SYSTBI"
                DB_SYSTBI = pData
                Exit Sub


            Case "SYSTBM"
                DB_SYSTBM = pData
                Exit Sub


            Case "TANMTA"
                DB_TANMTA = pData
                Exit Sub


            Case "TANSMA"
                DB_TANSMA = pData
                Exit Sub


            Case "TANWTA"
                DB_TANWTA = pData
                Exit Sub


            Case "TOKMTA"
                DB_TOKMTA = pData
                Exit Sub


            Case "TOKMTA2"
                DB_TOKMTA2 = pData
                Exit Sub


            Case "TOKMTB"
                DB_TOKMTB = pData
                Exit Sub


            Case "TOKSMA"
                DB_TOKSMA = pData
                Exit Sub


            Case "TOKSMB"
                DB_TOKSMB = pData
                Exit Sub


            Case "TOKSMC"
                DB_TOKSMC = pData
                Exit Sub


            Case "TOKSME"
                DB_TOKSME = pData
                Exit Sub


            Case "TOKSSA"
                DB_TOKSSA = pData
                Exit Sub


            Case "TOKSSB"
                DB_TOKSSB = pData
                Exit Sub


            Case "TUKMTA"
                DB_TUKMTA = pData
                Exit Sub


            Case "UDNTHA"
                DB_UDNTHA = pData
                Exit Sub


            Case "UDNTRA"
                DB_UDNTRA = pData
                Exit Sub

            Case "UNTMTA"
                DB_UNTMTA = pData
                Exit Sub


            Case "UNYMTA"
                DB_UNYMTA = pData
                Exit Sub


            Case "YSNTRA"
                DB_YSNTRA = pData
                Exit Sub


            Case "ZAISMA"
                DB_ZAISMA = pData
                Exit Sub

            Case "CNT_USR9.SEIPR53"
                DB_SEIPR53 = pData
                Exit Sub

        End Select
#End Region
    End Sub

    Public Function SetDataCount(ByVal pTableName As String, ByVal pFisrtFlg As Boolean) As Integer
#Region "データカウントを取得する"

        If pFisrtFlg = True Then
            Select Case pTableName
                '20190617 add start
                Case "BMNMTA"
                    bmnmtacount = 0

                Case "BMNMTA2"
                    bmnmta2count = 0

                Case "BMNMTB"
                    bmnmtbcount = 0

                Case "BNKMTA"
                    bnkmtacount = 0

                Case "CLDMTA"
                    cldmtacount = 0

                Case "CLSMTA"
                    clsmtacount = 0

                Case "CLSMTB"
                    clsmtbcount = 0

                Case "ENDMTA"
                    endmtacount = 0

                Case "EXCTBZ"
                    exctbzcount = 0

                Case "FBTRA"
                    fbtracount = 0

                Case "FDNTHA"
                    fdnthacount = 0

                Case "FDNTRA"
                    fdntracount = 0

                Case "FIXMTA"
                    fixmtacount = 0

                Case "FIXMTA2"
                    fixmta2count = 0

                Case "GYMTBZ"
                    gymtbzcount = 0

                Case "HINMTA"
                    hinmtacount = 0

                Case "HINMTB"
                    hinmtbcount = 0

                Case "HINSMA"
                    hinsmacount = 0

                Case "HDNTHA"
                    hdnthacount = 0

                Case "HDNTRA"
                    hdntracount = 0

                Case "SYSTBE"
                    systbecount = 0

                Case "JDNTHA"
                    jdnthacount = 0

                Case "JDNTHA2"
                    jdntha2count = 0

                Case "JDNTRA"
                    jdntracount = 0

                Case "JDNTRA2"
                    jdntra2count = 0

                Case "JDNDL01"
                    jdndl01count = 0

                Case "KNGMTA"
                    kngmtacount = 0

                Case "KNGMTB"
                    kngmtbcount = 0

                Case "MEIMTA"
                    meimtacount = 0

                Case "MEIMTB"
                    meimtbcount = 0

                Case "MEIMTC"
                    meimtccount = 0

                Case "NHSMTA"
                    nhsmtacount = 0

                Case "NHSMTA2"
                    nhsmta2count = 0

                Case "ODNTRA"
                    odntracount = 0

                Case "ORDTHB"
                    ordthbcount = 0

                Case "ORDTRB"
                    ordtrbcount = 0

                Case "RNKMTA"
                    rnkmtacount = 0

                Case "RNKMTA2"
                    rnkmta2count = 0

                Case "SDNTHA"
                    sdnthacount = 0

                Case "SDNTRA"
                    sdntracount = 0

                Case "SIRMTA"
                    sirmtacount = 0

                Case "SOUMTA"
                    soumtacount = 0

                Case "SOUMTA2"
                    soumta2count = 0

                Case "SRACNTTB"
                    sracnttbcount = 0

                Case "SRARSTTB"
                    srarsttbcount = 0

                Case "SYKTRA"
                    syktracount = 0

                Case "SYSTBA"
                    systbacount = 0

                Case "SYSTBB"
                    systbbcount = 0

                Case "SYSTBC"
                    systbccount = 0

                Case "SYSTBD"
                    systbdcount = 0

                Case "SYSTBF"
                    systbfcount = 0

                Case "SYSTBG"
                    systbgcount = 0

                Case "SYSTBH"
                    systbhcount = 0

                Case "SYSTBI"
                    systbicount = 0

                Case "SYSTBM"
                    systbmcount = 0

                Case "TANMTA"
                    tanmtacount = 0

                Case "TANSMA"
                    tansmacount = 0

                Case "TANWTA"
                    tanwtacount = 0

                Case "TOKMTA"
                    tokmtacount = 0

                Case "TOKMTA2"
                    tokmta2count = 0

                Case "TOKMTB"
                    tokmtbcount = 0

                Case "TOKSMA"
                    toksmacount = 0

                Case "TOKSMB"
                    toksmbcount = 0

                Case "TOKSMC"
                    toksmccount = 0

                Case "TOKSME"
                    toksmecount = 0

                Case "TOKSSA"
                    tokssacount = 0

                Case "TOKSSB"
                    tokssbcount = 0

                Case "TUKMTA"
                    tukmtacount = 0

                Case "UDNTHA"
                    udnthacount = 0

                Case "UDNTRA"
                    udntracount = 0

                Case "UNTMTA"
                    untmtacount = 0

                Case "UNYMTA"
                    unymtacount = 0

                Case "YSNTRA"
                    ysntracount = 0

                Case "ZAISMA"
                    zaismacount = 0

                Case "CNT_USR9.SEIPR53"
                    seipr53count = 0
            End Select

        Else
            Select Case pTableName
                Case "BMNMTA"
                    bmnmtacount = bmnmtacount + 1

                Case "BMNMTA2"
                    bmnmta2count = bmnmta2count + 1

                Case "BMNMTB"
                    bmnmtbcount = bmnmtbcount + 1

                Case "BNKMTA"
                    bnkmtacount = bnkmtacount + 1

                Case "CLDMTA"
                    cldmtacount = cldmtacount + 1

                Case "CLSMTA"
                    clsmtacount = clsmtacount + 1

                Case "CLSMTB"
                    clsmtbcount = clsmtbcount + 1

                Case "ENDMTA"
                    endmtacount = endmtacount + 1

                Case "EXCTBZ"
                    exctbzcount = exctbzcount + 1

                Case "FBTRA"
                    fbtracount = fbtracount + 1

                Case "FDNTHA"
                    fdnthacount = fdnthacount + 1

                Case "FDNTRA"
                    fdntracount = fdntracount + 1

                Case "FIXMTA"
                    fixmtacount = fixmtacount + 1

                Case "FIXMTA2"
                    fixmta2count = fixmta2count + 1

                Case "GYMTBZ"
                    gymtbzcount = gymtbzcount + 1

                Case "HINMTA"
                    hinmtacount = hinmtacount + 1

                Case "HINMTB"
                    hinmtbcount = hinmtbcount + 1

                Case "HINSMA"
                    hinsmacount = hinsmacount + 1

                Case "HDNTHA"
                    hdnthacount = hdnthacount + 1

                Case "HDNTRA"
                    hdntracount = hdntracount + 1

                Case "SYSTBE"
                    systbecount = systbecount + 1

                Case "JDNTHA"
                    jdnthacount = jdnthacount + 1

                Case "JDNTHA2"
                    jdntha2count = jdntha2count + 1

                Case "JDNTRA"
                    jdntracount = jdntracount + 1

                Case "JDNTRA2"
                    jdntra2count = jdntra2count + 1

                Case "JDNDL01"
                    jdndl01count = jdndl01count + 1

                Case "KNGMTA"
                    kngmtacount = kngmtacount + 1

                Case "KNGMTB"
                    kngmtbcount = kngmtbcount + 1

                Case "MEIMTA"
                    meimtacount = meimtacount + 1

                Case "MEIMTB"
                    meimtbcount = meimtbcount + 1

                Case "MEIMTC"
                    meimtccount = meimtccount + 1

                Case "NHSMTA"
                    nhsmtacount = nhsmtacount + 1

                Case "NHSMTA2"
                    nhsmta2count = nhsmta2count + 1

                Case "ODNTRA"
                    odntracount = odntracount + 1

                Case "ORDTHB"
                    ordthbcount = ordthbcount + 1

                Case "ORDTRB"
                    ordtrbcount = ordtrbcount + 1

                Case "RNKMTA"
                    rnkmtacount = rnkmtacount + 1

                Case "RNKMTA2"
                    rnkmta2count = rnkmta2count + 1

                Case "SDNTHA"
                    sdnthacount = sdnthacount + 1

                Case "SDNTRA"
                    sdntracount = sdntracount + 1

                Case "SIRMTA"
                    sirmtacount = sirmtacount + 1

                Case "SOUMTA"
                    soumtacount = soumtacount + 1

                Case "SOUMTA2"
                    soumta2count = soumta2count + 1

                Case "SRACNTTB"
                    sracnttbcount = sracnttbcount + 1

                Case "SRARSTTB"
                    srarsttbcount = srarsttbcount + 1

                Case "SYKTRA"
                    syktracount = syktracount + 1

                Case "SYSTBA"
                    systbacount = systbacount + 1

                Case "SYSTBB"
                    systbbcount = systbbcount + 1

                Case "SYSTBC"
                    systbccount = systbccount + 1

                Case "SYSTBD"
                    systbdcount = systbdcount + 1

                Case "SYSTBF"
                    systbfcount = systbfcount + 1

                Case "SYSTBG"
                    systbgcount = systbgcount + 1

                Case "SYSTBH"
                    systbhcount = systbhcount + 1

                Case "SYSTBI"
                    systbicount = systbicount + 1

                Case "SYSTBM"
                    systbmcount = systbmcount + 1

                Case "TANMTA"
                    tanmtacount = tanmtacount + 1

                Case "TANSMA"
                    tansmacount = tansmacount + 1

                Case "TANWTA"
                    tanwtacount = tanwtacount + 1

                Case "TOKMTA"
                    tokmtacount = tokmtacount + 1

                Case "TOKMTA2"
                    tokmta2count = tokmta2count + 1

                Case "TOKMTB"
                    tokmtbcount = tokmtbcount + 1

                Case "TOKSMA"
                    toksmacount = toksmacount + 1

                Case "TOKSMB"
                    toksmbcount = toksmbcount + 1

                Case "TOKSMC"
                    toksmccount = toksmccount + 1

                Case "TOKSME"
                    toksmecount = toksmecount + 1

                Case "TOKSSA"
                    tokssacount = tokssacount + 1

                Case "TOKSSB"
                    tokssbcount = tokssbcount + 1

                Case "TUKMTA"
                    tukmtacount = tukmtacount + 1

                Case "UDNTHA"
                    udnthacount = udnthacount + 1

                Case "UDNTRA"
                    udntracount = udntracount + 1

                Case "UNTMTA"
                    untmtacount = untmtacount + 1

                Case "UNYMTA"
                    unymtacount = unymtacount + 1

                Case "YSNTRA"
                    ysntracount = ysntracount + 1

                Case "ZAISMA"
                    zaismacount = zaismacount + 1

                Case "CNT_USR9.SEIPR53"
                    seipr53count = seipr53count + 1
            End Select

        End If

        Select Case pTableName
            Case "BMNMTA"
                Return bmnmtacount

            Case "BMNMTA2"
                Return bmnmta2count

            Case "BMNMTB"
                Return bmnmtbcount

            Case "BNKMTA"
                Return bnkmtacount

            Case "CLDMTA"
                Return cldmtacount

            Case "CLSMTA"
                Return clsmtacount

            Case "CLSMTB"
                Return clsmtbcount

            Case "ENDMTA"
                Return endmtacount

            Case "EXCTBZ"
                Return exctbzcount

            Case "FBTRA"
                Return fbtracount

            Case "FDNTHA"
                Return fdnthacount

            Case "FDNTRA"
                Return fdntracount

            Case "FIXMTA"
                Return fixmtacount

            Case "FIXMTA2"
                Return fixmta2count

            Case "GYMTBZ"
                Return gymtbzcount

            Case "HINMTA"
                Return hinmtacount

            Case "HINMTB"
                Return hinmtbcount

            Case "HINSMA"
                Return hinsmacount

            Case "HDNTHA"
                Return hdnthacount

            Case "HDNTRA"
                Return hdntracount

            Case "SYSTBE"
                Return systbecount

            Case "JDNTHA"
                Return jdnthacount

            Case "JDNTHA2"
                Return jdntha2count

            Case "JDNTRA"
                Return jdntracount

            Case "JDNTRA2"
                Return jdntra2count

            Case "JDNDL01"
                Return jdndl01count

            Case "KNGMTA"
                Return kngmtacount

            Case "KNGMTB"
                Return kngmtbcount

            Case "MEIMTA"
                Return meimtacount

            Case "MEIMTB"
                Return meimtbcount

            Case "MEIMTC"
                Return meimtccount

            Case "NHSMTA"
                Return nhsmtacount

            Case "NHSMTA2"
                Return nhsmta2count

            Case "ODNTRA"
                Return odntracount

            Case "ORDTHB"
                Return ordthbcount

            Case "ORDTRB"
                Return ordtrbcount

            Case "RNKMTA"
                Return rnkmtacount

            Case "RNKMTA2"
                Return rnkmta2count

            Case "SDNTHA"
                Return sdnthacount

            Case "SDNTRA"
                Return sdntracount

            Case "SIRMTA"
                Return sirmtacount

            Case "SOUMTA"
                Return soumtacount

            Case "SOUMTA2"
                Return soumta2count

            Case "SRACNTTB"
                Return sracnttbcount

            Case "SRARSTTB"
                Return srarsttbcount

            Case "SYKTRA"
                Return syktracount

            Case "SYSTBA"
                Return systbacount

            Case "SYSTBB"
                Return systbbcount

            Case "SYSTBC"
                Return systbccount

            Case "SYSTBD"
                Return systbdcount

            Case "SYSTBF"
                Return systbfcount

            Case "SYSTBG"
                Return systbgcount

            Case "SYSTBH"
                Return systbhcount

            Case "SYSTBI"
                Return systbicount

            Case "SYSTBM"
                Return systbmcount

            Case "TANMTA"
                Return tanmtacount

            Case "TANSMA"
                Return tansmacount

            Case "TANWTA"
                Return tanwtacount

            Case "TOKMTA"
                Return tokmtacount

            Case "TOKMTA2"
                Return tokmta2count

            Case "TOKMTB"
                Return tokmtbcount

            Case "TOKSMA"
                Return toksmacount

            Case "TOKSMB"
                Return toksmbcount

            Case "TOKSMC"
                Return toksmccount

            Case "TOKSME"
                Return toksmecount

            Case "TOKSSA"
                Return tokssacount

            Case "TOKSSB"
                Return tokssbcount

            Case "TUKMTA"
                Return tukmtacount

            Case "UDNTHA"
                Return udnthacount

            Case "UDNTRA"
                Return udntracount

            Case "UNTMTA"
                Return untmtacount

            Case "UNYMTA"
                Return unymtacount

            Case "YSNTRA"
                Return ysntracount

            Case "ZAISMA"
                Return zaismacount

            Case "CNT_USR9.SEIPR53"
                Return seipr53count
        End Select

#End Region
    End Function
    '20190610 add end
End Module