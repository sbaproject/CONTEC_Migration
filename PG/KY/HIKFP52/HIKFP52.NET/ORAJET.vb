Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module BasOraJet
	'
	' ------------------------------------------------------------------
	' 必ず SSSORAIF.DLL のバージョン(前3桁)と合わせる事！
	Public Const sBAS_VER As String = "3.0.1.26" '2003.08.28A
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
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetFirst Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetNext Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetPre Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetLast Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetGrEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetGr Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetLs Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetLsEq Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String, ByVal LockFlg As Integer, ByVal sFields As String, ByRef ExtNum As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_GetSQL Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal sqlStmt As String, ByRef ExtNum As Any) As Integer
	Declare Function Dll_Execute Lib "sssoraif" (ByVal Fno As Integer, ByVal sqlStmt As String) As Integer
	
	'' Deleting , Inserting and Updating Data
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_Delete Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_Insert Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_Update Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any, ByVal KeyNo As Integer, ByVal keyVal As String) As Integer
	
	'' Others
	Declare Function Dll_Stat Lib "sssoraif" (ByVal Fno As Integer, ByRef xxx As Integer) As Integer
	Declare Function Dll_Start Lib "sssoraif" (ByVal sCon As String, ByVal sHead As String) As Integer
	Declare Function Dll_ChkVer Lib "sssoraif" (ByVal sVer As String) As Integer
	Declare Function Dll_RESET Lib "sssoraif" () As Integer
	Declare Function Dll_Stop Lib "sssoraif" () As Integer
	Declare Function Dll_Open Lib "sssoraif" (ByVal Fno As Integer, ByVal DBID As String, ByVal tblid As String) As Integer
	Declare Function Dll_Close Lib "sssoraif" (ByVal Fno As Integer) As Integer
	Declare Function Dll_Can Lib "sssoraif" (ByVal Fno As Integer) As Integer
	Declare Function Dll_End Lib "sssoraif" () As Integer
	Declare Function Dll_BeginTransaction Lib "sssoraif" (ByVal shareMode As Integer) As Integer
	Declare Function Dll_AbortTransaction Lib "sssoraif" () As Integer
	Declare Function Dll_EndTransaction Lib "sssoraif" () As Integer
	Declare Function Dll_Usr1Exec Lib "sssoraif" (ByVal pSql As String) As Integer
	Declare Function Dll_TpaLock Lib "sssoraif" (ByVal pSql As String, ByRef nProc As Integer) As Integer
	Declare Function Dll_TpaIns Lib "sssoraif" (ByVal pSql As String, ByRef nProc As Integer, ByVal sOP As String, ByVal sCL As String, ByVal sTM As String, ByVal sDT As String) As Integer
	Declare Function Dll_GetPassWD Lib "sssoraif" (ByVal nUsrNo As Integer, ByVal passWD As String) As Integer
	Declare Function Dll_ChgMode Lib "sssoraif" (ByVal sMode As String) As Integer
	Declare Function Dll_ClrMode Lib "sssoraif" () As Integer
	Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno As Integer, ByVal sDT As String, ByVal sTM As String) As Integer
	Declare Function Dll_SetPGID Lib "sssoraif" (ByVal sPrgId As String) As Integer
	
	'' Calling Interface for PL/SQL
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_PlStart Lib "sssoraif" (ByRef pPl_Info As Any, ByVal bGetRec As Integer) As Integer
	Declare Function Dll_PlFree Lib "sssoraif" () As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_PlSet Lib "sssoraif" (ByVal Fno As Integer, ByVal RNo As Integer, ByRef pBuff As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_PlCndSet Lib "sssoraif" (ByRef pBuff As Any) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_PlExec Lib "sssoraif" (ByVal pSql As String, ByRef pBuff As Any) As Integer
	Declare Function Dll_PlGetCnt Lib "sssoraif" (ByVal Fno As Integer) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_PlGet Lib "sssoraif" (ByVal Fno As Integer, ByRef pBuff As Any, ByVal RNo As Integer) As Integer
	
	'' Nop inside
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_ErrorCheck Lib "sssoraif" (ByVal opCode As Short, ByRef tblName As Any) As Integer
	Declare Function Dll_NCCLOSE Lib "sssoraif" (ByVal Fno As Integer) As Integer
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_NCOPEN Lib "sssoraif" (ByVal Fno As Integer, ByRef FileLocation As Any, ByRef DBFLocation As Any) As Integer
	Declare Function Dll_Unlock Lib "sssoraif" (ByVal Fno As Integer) As Integer
	
	'' Exception (Header with "DB_")
	'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
	Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno As Integer, ByRef recBuf As Any) As Integer
	
	Declare Function sOraErrMsg Lib "sssoraif" (ByVal nErr As Integer, ByVal sMsg As String) As Integer
	
	Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	''End: Declare
	
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
		<VBFixedString(256),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=256)> Public KeyBuf() As Char
		Dim KeyNo As Short
		Dim tblid As String 'テーブル名
		Dim Status As Short
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public DBID() As Char
		Dim DBNo As Short
		Dim nDirection As Short
	End Structure
	
	Structure TYPE_KeySeg
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(12),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=12)> Public KeyName() As Char
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
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public tblName() As Char
		Dim KeyCnt As Short
		'UPGRADE_WARNING: 配列 Seg で各要素を初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"' をクリックしてください。
		<VBFixedArray(9)> Dim Seg() As TYPE_KeySeg
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim Seg(9)
		End Sub
	End Structure
	
	Public Const RecNoLock As Short = 0 ' 汎用 レコードロックパラメータ
	Public Const RecLock As Short = -1 '    上に同じ
	
	'旧インターフェイス
	Public Const NCCNo As Short = -1 ' No-Currency-Change オプション値
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
	
	Structure T_G_LB
		<VBFixedArray(16 * 1024)> Dim tgLB1() As Byte
		<VBFixedArray(4 * 1024)> Dim tgLB2() As Byte 'Pre=16
		'tgLB3(4 * 1024) As Byte
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim tgLB1(16 * 1024)
			ReDim tgLB2(4 * 1024)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 G_LB の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public G_LB As T_G_LB
	
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
	'UPGRADE_WARNING: 構造体 G_PlInfo の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public G_PlInfo As T_PlInfo
	
	Public Const MAX_CNDARR As Short = 14 'Pre=10/Lim=19
	Structure T_PlCnd
		Dim nJobMode As Integer
		'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
		Dim sCndStr(MAX_CNDARR - 1) As String*512
		<VBFixedArray(MAX_CNDARR - 1)> Dim nCndNum() As Decimal
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public sOpeID() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public sCltID() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(512),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=512)> Public sErrMsg() As Char
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim nCndNum(MAX_CNDARR - 1)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 G_PlCnd の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public G_PlCnd As T_PlCnd
	'UPGRADE_WARNING: 構造体 G_PlCnd2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public G_PlCnd2 As T_PlCnd
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
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public KeyType() As Char
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public Reserved() As Char
	End Structure
	
	Structure TYPE_StatFileSpecs
		Dim RecLen As Short
		Dim PageSize As Short
		Dim IndexTot As Short
		Dim RecTot As Integer
		Dim FileFlags As Short
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public Reserved() As Char
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
	'UPGRADE_WARNING: 構造体 DB_ExtNum の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
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
	Private Const nSecOfDay As Double = 24 * 3600#
	Private G_bTool As Boolean
	
	Private Sub ResetExtNum()
		Dim I As Short
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
		If IsDbNull(Jet_WS.Databases) Then Return 
		Jet_WS.Rollback()
		DBSTAT = Err.Number
		Call JB_ErrorCheck("AbortTransaction", 0)
	End Sub
	
	' エラー汎用ルーチン
	Sub DB_ErrorCheck(ByRef opCode As String, ByRef Fno As Short) 'TblName As String)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno, True) Then
			Call Ora_ErrorCheck(opCode, Fno)
		Else
			Call JB_ErrorCheck(opCode, Fno)
		End If
	End Sub
	
	Sub DB_MsgBox(ByRef Msg As String)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(Jet_WS.Databases) = False Then Jet_WS.Rollback()
		Err.Clear()
		'Call DB_LockOff2
		DBSTAT = Dll_AbortTransaction
		If Msg <> "" And G_bSUP_ERR = False Then Call MsgBox(Msg)
	End Sub
	
	Sub JB_ErrorCheck(ByRef opCode As String, ByRef Fno As Short) 'TblName As String)
		Dim tblName As String
		Dim nHantei As Short
		Dim sErrMsg As String
		
		If Fno >= 0 Then tblName = DB_PARA(Fno).tblid
		'
		nHantei = 0
		Select Case DBSTAT
			'Case 0, Jet_BOF, Jet_EOF, Jet_NoMAtch
			Case 0, Jet_NoMAtch
			Case 3021
				If opCode = "GetNext" Or opCode = "GetPre" Then DBSTAT = Jet_EOF Else nHantei = 9
			Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
				nHantei = 1
			Case Else
				nHantei = 9
		End Select
		Select Case nHantei
			Case 1
				sErrMsg = "Jet ReTry Error ! [" & tblName & ":" & opCode & ":" & Str(DB_MAXWAITSEC) & "]" & ErrorToString()
				DB_MsgBox("")
				Call Error_Exit(sErrMsg)
				System.Windows.Forms.Application.DoEvents()
			Case 9
				sErrMsg = "Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & ErrorToString()
				DB_MsgBox("Jet  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]" & Chr(13) & ErrorToString())
				Call Error_Exit(sErrMsg)
			Case Else
		End Select
	End Sub
	
	Sub Ora_ErrorCheck(ByRef opCode As String, ByRef Fno As Short, Optional ByRef LockFlg As Short = 0) 'TblName As String)
		Dim tblName As String
		Dim Msg As String
		Dim sErrMsg As String
		Dim sErrMsg2 As String
		If Fno >= 0 Then tblName = DB_PARA(Fno).tblid Else tblName = " "
		'
		If opCode = "DB_Start" Or opCode = "DB_Open" Then
			Msg = ""
			Select Case DBSTAT
				Case 0
				Case 1 'Call Han_msgINFO("テスト環境です！", BOX_OK%)
					DBSTAT = 0
				Case 2 'Call Han_msgINFO("評価版です！", BOX_OK%)
					DBSTAT = 0
				Case -1
					Msg = "環境が未設定です！"
				Case -2
					Msg = "古い環境です！"
				Case -3
					Msg = "環境が違います！"
				Case -4
					Msg = "現在使用できません！"
				Case -5
					Msg = "環境情報が壊れています！"
				Case -6
					Msg = "同時実行版ライセンスが登録されていません！"
				Case -7
					Msg = "同時実行版ライセンスが壊れています！"
				Case -8
					Msg = "ユーザ名称が違います！"
				Case -9
					Msg = "ライセンスの最大ユーザ数を超えました！"
				Case -10
					Msg = "データベースに接続できません！"
				Case -11
					Msg = "接続許可が得られません！"
				Case Else
					If DBSTAT < 0 Then
						Msg = "環境エラーです！"
					Else
						Msg = "ＤＢエラーです！"
					End If
			End Select
			If Msg <> "" Then
				sErrMsg = "Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
				'MsgBox "Ora  Error " & Msg$ & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
				If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
				MsgBox(sErrMsg)
				Call Error_Exit("Ora  Error " & Msg & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]")
			End If
		End If
		
		Select Case DBSTAT
			'   OK,  EOF, NULL
			Case 0, 1403, 1405
				G_sErrMsg = "ORA:" & Str(DBSTAT)
			Case Else
				If opCode = "DB_PlExec" Then Exit Sub
				sErrMsg = "Ora  Error " & " = [" & tblName & ":" & opCode & ":" & DBSTAT & "]"
				If DBSTAT > 0 Then sErrMsg2 = Space(513) : Call sOraErrMsg(DBSTAT, sErrMsg2) : sErrMsg = sErrMsg & Chr(13) & sErrMsg2
				'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
				If Not IsNothing(LockFlg) Then
					If LockFlg = AppLock Then G_sErrMsg = sErrMsg : Exit Sub
				End If
				DB_MsgBox(sErrMsg)
				'DBSTAT = Dll_AbortTransaction
				Call Error_Exit(sErrMsg)
		End Select
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
		If IsDbNull(Jet_WS.Databases) Then Return 
		Jet_WS.BeginTrans()
		DBSTAT = Err.Number
		Call JB_ErrorCheck("BeginTransaction", 0)
	End Sub
	
	Public Sub JB_Close(ByRef Fno As Short)
		Dim I As Short
		On Error Resume Next
		Err.Clear()
		If RsOpened(Fno) Then
			For I = 0 To JET_RS(Fno).Fields.Count - 1
				'UPGRADE_NOTE: オブジェクト G_Fld() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
				G_Fld(Fno, I) = Nothing
			Next I
			JET_RS(Fno).Close()
			'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			JET_RS(Fno) = Nothing
			RsOpened(Fno) = False
		End If
		DBSTAT = Err.Number
		DB_PARA(Fno).Status = DBSTAT
		If NoCheck = False Then Call JB_ErrorCheck("Close", Fno)
	End Sub
	
	Public Sub JB_DELETE(ByRef Fno As Short)
		On Error Resume Next
		Err.Clear()
		Call JT_OutPut(Fno, "D")
		DBSTAT = nErr
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("Delete", Fno)
	End Sub
	
	Public Sub JB_DelAll(ByRef Fno As Short)
		On Error Resume Next
		Err.Clear()
		With DB_Spec(DB_PARA(Fno).DBNo)
			.Jet_DB.Execute(("DELETE FROM " & DB_PARA(Fno).tblid))
			DBSTAT = Err.Number
			DB_PARA(Fno).Status = DBSTAT
			Call JB_ErrorCheck("DelAll", Fno)
		End With
	End Sub
	
	Public Sub JB_Execute(ByRef Fno As Short, ByRef sqlStmt As String)
		On Error Resume Next
		Err.Clear()
		With DB_Spec(DB_PARA(Fno).DBNo)
			.Jet_DB.Execute((sqlStmt))
			DBSTAT = Err.Number
			DB_PARA(Fno).Status = DBSTAT
			Call JB_ErrorCheck("Execute", Fno)
		End With
	End Sub
	
	Public Sub JB_End()
		Dim I, j As Short
		On Error Resume Next
		Err.Clear()
		For I = 0 To rstMAX
			If RsOpened(I) Then
				If Not IS_ORA(I) Then
					For j = 0 To JET_RS(I).Fields.Count - 1
						'UPGRADE_NOTE: オブジェクト G_Fld() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
						G_Fld(I, j) = Nothing
					Next j
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
		If IsDbNull(Jet_WS.Databases) Then Return 
		Jet_WS.CommitTrans()
		DBSTAT = Err.Number
		Call JB_ErrorCheck("EndTransaction", 0)
	End Sub
	
	Public Sub JB_GetEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = JT_Get(Fno, "=", KeyNo, keyVal, LockFlg)
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetEq", Fno)
	End Sub
	
	Public Function JT_Get(ByVal Fno As Short, ByVal Rel As String, ByVal KeyNo As Short, ByVal keyVal As String, ByRef LockFlg As Short) As Short
		Dim k(9) As String
		Dim ofs, I, Vlen As Short
		On Error Resume Next
		Err.Clear()
		If JET_RS(Fno).Type <> DAO.RecordsetTypeEnum.dbOpenTable Then
			JET_RS(Fno).Close()
			'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			JET_RS(Fno) = Nothing
			With DB_Spec(DB_PARA(Fno).DBNo)
				JET_RS(Fno) = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, DAO.RecordsetTypeEnum.dbOpenTable)
				For I = 0 To JET_RS(Fno).Fields.Count - 1
					G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
				Next I
			End With
		End If
		JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Vlen = LenWid(keyVal)
		With KeyIndex(Fno).Seg(KeyNo - 1)
			ofs = 1
			For I = 0 To .ItmCnt - 1
				k(I) = ""
				If Vlen >= ofs Then k(I) = MidWid(keyVal, ofs, .ItmLen(I))
				ofs = ofs + .ItmLen(I)
			Next I
		End With
		Select Case I
			Case 1 : JET_RS(Fno).Seek(Rel, k(0))
			Case 2 : JET_RS(Fno).Seek(Rel, k(0), k(1))
			Case 3 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2))
			Case 4 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3))
			Case 5 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4))
			Case 6 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5))
			Case 7 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6))
			Case 8 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7))
			Case 9 : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8))
			Case Else : JET_RS(Fno).Seek(Rel, k(0), k(1), k(2), k(3), k(4), k(5), k(6), k(7), k(8), k(9))
		End Select
		If Err.Number = 0 Then
			If JET_RS(Fno).NoMatch Then
				JT_Get = Jet_NoMAtch
			Else
				nErr = 0
				If LockFlg Then Call JT_OutPut(Fno, "E")
				If nErr = 0 Then
					JT_Get = Jet_NoErr
					DB_PARA(Fno).KeyNo = KeyNo
					Call RecordFromObject(Fno)
					If Err.Number = 0 Then Call KeyFromObject(Fno) Else JT_Get = Err.Number
				Else
					JT_Get = nErr
				End If
			End If
		Else
			JT_Get = Err.Number
		End If
	End Function
	
	Sub JT_OutPut(ByRef Fno As Short, ByRef Kbn As String)
		'    Dim StTime@, EnTime@, CurTime@
		Dim Msg, Syori As String
		'
		StTime = VB.Timer()
		EnTime = StTime + DB_MAXWAITSEC
		Do 
			On Error Resume Next
			'Err.Clear
			Select Case Kbn
				Case "E"
					JET_RS(Fno).Edit()
				Case "U"
					JET_RS(Fno).Update()
				Case "D"
					JET_RS(Fno).Delete()
			End Select
			nErr = Err.Number
			On Error GoTo 0
			'
			Select Case nErr
				Case 3008, 3009, 3050, 3187, 3189, 3330, 3356, 3260, 3218
					System.Windows.Forms.Application.DoEvents()
					CurTime = VB.Timer()
					If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
					If CurTime > EnTime Then
						If Kbn = "E" Then Syori = "EDIT" Else If Kbn = "U" Then Syori = "Update" Else Kbn = "Delete"
						Msg = Str(DB_MAXWAITSEC) & "秒間待ちましたが、Jetファイルが使用中です。" & Chr(13)
						Msg = Msg & "FILE_ID = (" & DB_PARA(Fno).tblid & ")  処理 = " & Syori & Chr(13)
						Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
						Msg = Msg & "［注意］キャンセルすると、このデータを登録せずにプログラムを終了します！"
						If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
							'Call Error_Exit("Jet ReTry Error ! [" & DB_PARA(Fno).tblid & ":" & opCode & ":" & DB_MAXWAITSEC% & "]" & Error$)
							Exit Do
						Else
							StTime = VB.Timer()
							EnTime = StTime + DB_MAXWAITSEC
						End If
					Else
						System.Windows.Forms.Application.DoEvents()
					End If
				Case Else
					Exit Do
			End Select
			'
		Loop 
	End Sub
	
	Sub KeyFromObject(ByRef Fno As Object)
		Dim S As String
		Dim I As Short
		S = ""
		'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		With KeyIndex(Fno).Seg(DB_PARA(Fno).KeyNo - 1)
			'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For I = 0 To .ItmCnt - 1
				'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				S = S + JET_RS(Fno).Fields(.ItmPos(I)).Value
			Next I
		End With
		'UPGRADE_WARNING: オブジェクト Fno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(Fno).KeyBuf = S
	End Sub
	
	Public Sub JB_GetFirst(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		DBSTAT = JT_Get(Fno, ">=", KeyNo, "", LockFlg)
		'    Jet_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
		'    Jet_RS(Fno).MoveFirst
		'    If Err = 0 Then
		'        If Jet_RS(Fno).BOF Then
		'            DBSTAT = Jet_NoMAtch
		'            'DBSTAT = Jet_BOF
		'        Else
		'            DBSTAT = Jet_NoErr
		'            DB_PARA(Fno).KeyNo = KeyNo
		'            Call RecordFromObject(Fno)
		'            Call KeyFromObject(Fno)
		'        End If
		'    Else
		'        DBSTAT = Err
		'    End If
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetFirst", Fno)
	End Sub
	
	Public Sub JB_GetGr(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = JT_Get(Fno, ">", KeyNo, keyVal, LockFlg)
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetGr", Fno)
	End Sub
	
	Public Sub JB_GetGrEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = JT_Get(Fno, ">=", KeyNo, keyVal, LockFlg)
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetGrEq", Fno)
	End Sub
	
	Public Sub JB_GetLast(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		JET_RS(Fno).Index = KeyIndex(Fno).Seg(KeyNo - 1).KeyName
		JET_RS(Fno).MoveLast()
		If Err.Number = 0 Then
			If JET_RS(Fno).EOF Then
				DBSTAT = Jet_NoMAtch
				'DBSTAT = Jet_EOF
			Else
				nErr = 0
				If LockFlg Then Call JT_OutPut(Fno, "E")
				If nErr = 0 Then
					DBSTAT = Jet_NoErr
					DB_PARA(Fno).KeyNo = KeyNo
					Call RecordFromObject(Fno)
					If Err.Number = 0 Then Call KeyFromObject(Fno)
					If Err.Number Then DBSTAT = Err.Number
				Else
					DBSTAT = nErr
				End If
			End If
		Else
			DBSTAT = Err.Number
		End If
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetLast", Fno)
	End Sub
	
	Public Sub JB_GetLs(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = JT_Get(Fno, "<", KeyNo, keyVal, LockFlg)
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetLs", Fno)
	End Sub
	
	Public Sub JB_GetLsEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = JT_Get(Fno, "<=", KeyNo, keyVal, LockFlg)
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetLsEq", Fno)
	End Sub
	
	Public Sub JB_GetNext(ByRef Fno As Short, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		JET_RS(Fno).MoveNext()
		If Err.Number = 0 Then
			If JET_RS(Fno).EOF Then
				DBSTAT = Jet_NoMAtch
				'DBSTAT = Jet_EOF
			Else
				nErr = 0
				If LockFlg Then Call JT_OutPut(Fno, "E")
				If nErr = 0 Then
					DBSTAT = Jet_NoErr
					'DB_PARA(Fno).KeyNo = KeyNo
					Call RecordFromObject(Fno)
					If Err.Number = 0 Then Call KeyFromObject(Fno)
					If Err.Number Then DBSTAT = Err.Number
				Else
					DBSTAT = nErr
				End If
			End If
		Else
			DBSTAT = Err.Number
		End If
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetNext", Fno)
	End Sub
	
	Public Sub JB_GetPre(ByRef Fno As Short, ByRef LockFlg As Short)
		On Error Resume Next
		Err.Clear()
		JET_RS(Fno).MovePrevious()
		If Err.Number = 0 Then
			If JET_RS(Fno).BOF Then
				DBSTAT = Jet_NoMAtch
				'DBSTAT = Jet_BOF
			Else
				nErr = 0
				If LockFlg Then Call JT_OutPut(Fno, "E")
				If nErr = 0 Then
					DBSTAT = Jet_NoErr
					'DB_PARA(Fno).KeyNo = KeyNo
					Call RecordFromObject(Fno)
					If Err.Number = 0 Then Call KeyFromObject(Fno)
					If Err.Number Then DBSTAT = Err.Number
				Else
					DBSTAT = nErr
				End If
			End If
		Else
			DBSTAT = Err.Number
		End If
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("GetPre", Fno)
	End Sub
	
	Public Sub JB_GetSQL(ByRef Fno As Short, ByRef Sql As String)
		'Dim Sql$, i%
		Dim I As Short
		'   On Error Resume Next
		Err.Clear()
		'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + Joken
		If Not (JET_RS(Fno) Is Nothing) Then
			JET_RS(Fno).Close()
			'UPGRADE_NOTE: オブジェクト JET_RS() をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			JET_RS(Fno) = Nothing
		End If
		With DB_Spec(DB_PARA(Fno).DBNo)
			JET_RS(Fno) = .Jet_DB.OpenRecordset(Sql, DAO.RecordsetTypeEnum.dbOpenDynaset)
			If JET_RS(Fno).RecordCount > 0 Then
				For I = 0 To JET_RS(Fno).Fields.Count - 1
					G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
				Next I
				If Err.Number = 0 Then
					DB_PARA(Fno).KeyNo = 1 'KeyNo
					Call RecordFromObject(Fno)
					Call KeyFromObject(Fno)
				End If
				DBSTAT = Err.Number
				If DBSTAT <> 0 Then MsgBox("JB_GetSQL DBSTAT=" & Str(DBSTAT) & " " & ErrorToString())
			Else
				DBSTAT = Jet_NoMAtch
			End If
			DB_PARA(Fno).Status = DBSTAT
			Call JB_ErrorCheck("GetSQL", Fno)
		End With
	End Sub
	
	Public Sub JB_Insert(ByRef Fno As Short, ByRef KeyNo As Short)
		On Error Resume Next
		Err.Clear()
		JET_RS(Fno).AddNew()
		Call ObjectFromRecord(Fno)
		If Err.Number = 0 Then Call JT_OutPut(Fno, "U") : DBSTAT = nErr Else DBSTAT = Err.Number
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("Insert", Fno)
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
		Dim I, DBNo As Short
		Dim Wk, sDB As String
		Dim ret As Object
		On Error Resume Next
		Err.Clear()
		'UPGRADE_WARNING: オブジェクト JT_GetDBno() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBNo = JT_GetDBno(Fno)
		If DBNo >= 0 Then
			DB_PARA(Fno).DBNo = DBNo
		Else
			MsgBox("データベース定義エラー: " & DB_PARA(Fno).tblid)
			Exit Sub
		End If
		
		With DB_Spec(DBNo)
			If .bLogin = False Then
				'Wk = .sLoc & .sID & ".MDB"
				'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				sDB = VB.Switch(.sID = "SYSDBC", "SYSDBN", .sID = "SSSWB2", "SSSWB1", True, .sID)
				Wk = .sLoc & sDB & ".MDB"
				.Jet_DB = Jet_WS.OpenDatabase(Wk)
				If Err.Number = 3343 Then
					'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ret = MsgBox("Jetデータベースが破損している様です。(JET-3343)" & Chr(13) & Wk & Chr(13) & "修復しますか？", MsgBoxStyle.YesNo)
					If ret = MsgBoxResult.Yes Then
						Err.Clear()
						DAODBEngine_definst.RepairDatabase(Wk)
						If Err.Number = 0 Then .Jet_DB = Jet_WS.OpenDatabase(Wk)
					End If
				End If
				If Err.Number <> 0 Then
					DBSTAT = Err.Number
					MsgBox("Jetデータベースを開く事はできません。JET[" & Str(DBSTAT) & "]" & Chr(13) & Wk)
					Exit Sub
				End If
				.bLogin = True
			End If
			
			If Not RsOpened(Fno) Then
				JET_RS(Fno) = .Jet_DB.OpenRecordset(Trim(DB_PARA(Fno).tblid), DAO.RecordsetTypeEnum.dbOpenTable)
				'UPGRADE_WARNING: オブジェクト JT_KeySet() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Err.Number = 0 Then Err.Number = JT_KeySet(Fno)
				If Err.Number = 0 Then
					For I = 0 To JET_RS(Fno).Fields.Count - 1
						G_Fld(Fno, I) = JET_RS(Fno).Fields(I)
					Next I
					RsOpened(Fno) = True
				End If
			End If
			DBSTAT = Err.Number
			DB_PARA(Fno).Status = DBSTAT
			If NoCheck = False Then Call JB_ErrorCheck("Open", Fno)
		End With
	End Sub
	
	Private Function JT_GetDBno(ByRef Fno As Short) As Object
		Dim Wk As String
		Dim Wkno As Short
		'    On Error Resume Next
		Wk = UCase(Trim(DB_PARA(Fno).DBID))
		'UPGRADE_WARNING: オブジェクト JT_GetDBno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JT_GetDBno = -1
		For Wkno = 0 To dbsMAX
			With DB_Spec(Wkno)
				If .sID < "0" Then Exit For
				If Wk = .sID Then
					'UPGRADE_WARNING: オブジェクト JT_GetDBno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					JT_GetDBno = Wkno
					Exit For
				End If
			End With
		Next Wkno
	End Function
	
	Private Function JT_KeySet(ByRef Fno As Short) As Object
		Dim j, I, ii, DBNo As Short
		Dim xx As String
		DBNo = DB_PARA(Fno).DBNo
		With DB_Spec(DBNo)
			On Error Resume Next
			Err.Clear()
			'UPGRADE_WARNING: オブジェクト JT_KeySet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			JT_KeySet = Jet_OpnErr
			'UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			Jet_Td = Nothing
			For I = 0 To .Jet_DB.TableDefs.Count - 1
				If Trim(.Jet_DB.TableDefs(I).Name) = Trim(DB_PARA(Fno).tblid) Then
					Jet_Td = .Jet_DB.TableDefs(I)
					Exit For
				End If
			Next I
			If I >= .Jet_DB.TableDefs.Count Then
				'UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
				Jet_Td = Nothing
				Exit Function
			End If
		End With
		With KeyIndex(Fno)
			.tblName = DB_PARA(Fno).tblid
			.KeyCnt = Jet_Td.Indexes.Count
			For I = 0 To .KeyCnt - 1
				xx = Trim(Jet_Td.Indexes(I).Name)
				ii = CShort(Right(xx, 2)) - 1
				With .Seg(ii)
					.KeyName = xx 'Jet_Td.Indexes(i).Name
					'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields.Count の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ItmCnt = Jet_Td.Indexes(I).Fields.Count
					For j = 0 To .ItmCnt - 1
						'.ItmName(J) = Jet_Td.Indexes(I).Fields(J).Name
						'.bKb(j) = 0
						'.ItmLen(j) = GetFldSize(Jet_Td.Fields, .ItmName(j))
						'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields().Name の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.ItmLen(j) = GetFldSize((Jet_Td.Fields), Jet_Td.Indexes(I).Fields(j).Name)
						'UPGRADE_WARNING: オブジェクト Jet_Td.Indexes().Fields().Name の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.ItmPos(j) = GetFldPos((Jet_Td.Fields), Jet_Td.Indexes(I).Fields(j).Name)
					Next j
				End With
			Next I
		End With
		'UPGRADE_NOTE: オブジェクト Jet_Td をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		Jet_Td = Nothing
		'UPGRADE_WARNING: オブジェクト JT_KeySet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JT_KeySet = Err.Number
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
		Dim Wk As New VB6.FixedLengthString(513)
		Dim ret As Object
		Dim wk2 As String
		On Error Resume Next
		Err.Clear()
		DB_MAXWAITSEC = 10
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DicPath = UCase(LeftWid(Wk.Value, ret)) & "\LIB\DIC\"
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSWIN", "LCK_RTRY", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BtrMaxReTryCnt = SSSVal(LeftWid(Wk.Value, ret))
		'    ret = GetPrivateProfileString("SSSUSR", "WAIT_SEC", "", Wk, Len(Wk), USR_PATH$ + "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("DBSPEC", "WAIT_SEC", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ret > 0 Then DB_MAXWAITSEC = CShort(LeftWid(Wk.Value, ret))
		DB_APPWAITSEC = 200
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("DBSPEC", "LOCK_MILISEC", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ret > 0 Then DB_APPWAITSEC = CShort(LeftWid(Wk.Value, ret))
		'
		
		'UPGRADE_NOTE: Erase は System.Array.Clear にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		System.Array.Clear(DB_Spec, 0, DB_Spec.Length) '1998/11/11 by Kitomi
		Call SetDBSpec()
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("LOCK", "RRRLOCK", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = LeftWid(Wk.Value, ret)
		'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		G_sRRRLock = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", True, UCase(wk2))
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("LOCK", "RRRLOCK2", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = LeftWid(Wk.Value, ret)
		'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		G_sRRRLock2 = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", True, UCase(wk2))
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("LOCK", "RRRLOCK3", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = LeftWid(Wk.Value, ret)
		'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		G_sRRRLock3 = VB.Switch(wk2 = "SRX", "SHARE ROW EXCLUSIVE", wk2 = "RX", "ROW EXCLUSIVE", wk2 = "RS", "ROW SHARE", wk2 = "X", "EXCLUSIVE", wk2 = "S", "SHARE", wk2 = "", "")
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("LOCK", "BUSY_APP", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = UCase(LeftWid(Wk.Value, ret))
		If wk2 = "TRUE" Then G_bRetApp = True
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("PLSQL", "EXT_CND", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = UCase(LeftWid(Wk.Value, ret))
		If wk2 = "TRUE" Then G_bExtCnd = True
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("PLSQL", "ALERT_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UCase(LeftWid(Wk.Value, ret)) = "FALSE" Then G_NO_ALTLOG = True Else G_NO_ALTLOG = False
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSUSR", "BUSY_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UCase(LeftWid(Wk.Value, ret)) = "TRUE" Then G_bBusyLog = True Else G_bBusyLog = False
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UCase(LeftWid(Wk.Value, ret)) = "TRUE" Then G_bTranLog = True Else G_bBusyLog = False
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSUSR", "TRAN_LOG_PATH", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = LeftWid(Wk.Value, ret) : TRAN_LOG_PATH = wk2
		If Right(TRAN_LOG_PATH, 1) <> "\" Then TRAN_LOG_PATH = TRAN_LOG_PATH & "\"
		'
		Jet_WS = DAODBEngine_definst.Workspaces(0)
		DBSTAT = Err.Number
	End Sub
	
	Sub SetDBSpec()
		Dim Wk As New VB6.FixedLengthString(513)
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
		ret = GetPrivateProfileString("SSSWIN", "USR_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ret > 0 Then
			'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			USR_PATH = LeftWid(Wk.Value, ret) : If Right(USR_PATH, 1) <> "\" Then USR_PATH = USR_PATH & "\"
		End If
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSWIN", "EXT_PATH", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ret > 0 Then
			'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			EXT_PATH = LeftWid(Wk.Value, ret) : If Right(EXT_PATH, 1) <> "\" Then EXT_PATH = EXT_PATH & "\"
		End If
		G_sCLTID = MidWid(VB.Command(), 2, 5)
		G_sOPEID = MidWid(VB.Command(), 7, 8)
		'
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk.Value, Len(Wk.Value), USR_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = UCase(LeftWid(Wk.Value, ret)) : G_bORA_RPS = (wk2 = "TRUE")
		'    ret = GetPrivateProfileString("DBSPEC", "ORA_RPS_EXT", "", Wk, Len(Wk), "SSSWIN.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("SSSUSR", "ORA_RPS", "", Wk.Value, Len(Wk.Value), EXT_PATH & "SSSUSR.INI")
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk2 = UCase(LeftWid(Wk.Value, ret)) : G_bORA_RPS_EXT = (wk2 = "TRUE")
		'
		For I = 0 To 10 : DB_Spec(I).bOra = G_bORA_RPS : Next I
		DB_Spec(1).bOra = G_bORA_RPS_EXT
		DB_Spec(9).bOra = G_bORA_RPS_EXT
		'
		For DBNo = 0 To dbsMAX
			If DB_Spec(DBNo).sID < "0" Then Exit For
			'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ret = GetPrivateProfileString("DBLOC", DB_Spec(DBNo).sID, "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
			DB_Spec(DBNo).bLogin = False
			'UPGRADE_NOTE: オブジェクト DB_Spec().Jet_DB をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			DB_Spec(DBNo).Jet_DB = Nothing
			'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ret > 0 Then
				'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk2 = LeftWid(Wk.Value, ret)
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
		ret = GetPrivateProfileString("DBLOC", "RWRK", "", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		DBNo = 12
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ret > 0 Then
			'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk2 = LeftWid(Wk.Value, ret)
			wk2 = Trim(wk2)
			If Right(wk2, 1) <> "\" Then wk2 = wk2 & "\"
			DB_Spec(DBNo).sLoc = wk2
			DB_Spec(DBNo).bReged = True
		Else
			DB_Spec(DBNo).sLoc = ""
			DB_Spec(DBNo).bReged = False
		End If
		'UPGRADE_WARNING: オブジェクト ret の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ret = GetPrivateProfileString("DBSPEC", "RETRYITV", "0", Wk.Value, Len(Wk.Value), "SSSWIN.INI")
		G_RetryItv = 100
		On Error Resume Next
		G_RetryItv = CShort(Wk.Value)
		On Error GoTo 0
	End Sub
	
	Public Function JB_STAT(ByRef Fno As Short) As Integer
		Dim Sql As String
		Dim DBNo As Short
		'UPGRADE_WARNING: 構造体 TMP_RS の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim TMP_RS As DAO.Recordset
		On Error Resume Next
		Err.Clear()
		With DB_Spec(DB_PARA(Fno).DBNo)
			TMP_RS = .Jet_DB.OpenRecordset(DB_PARA(Fno).tblid, DAO.RecordsetTypeEnum.dbOpenTable)
			JB_STAT = TMP_RS.RecordCount
			TMP_RS.Close()
			'UPGRADE_NOTE: オブジェクト TMP_RS をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			TMP_RS = Nothing
			DBSTAT = Err.Number
			DB_PARA(Fno).Status = DBSTAT
			Call JB_ErrorCheck("Stat", Fno)
		End With
	End Function
	
	Public Sub JB_Unlock(ByRef Fno As Short)
		On Error Resume Next
		Err.Clear()
		JET_RS(Fno).CancelUpdate()
		DBSTAT = Err.Number
		DB_PARA(Fno).Status = DBSTAT
	End Sub
	
	Public Sub JB_Update(ByRef Fno As Short, ByRef KeyNo As Short)
		On Error Resume Next
		Err.Clear()
		Call JT_OutPut(Fno, "E")
		If nErr = 0 Then
			Call ObjectFromRecord(Fno)
			If Err.Number = 0 Then Call JT_OutPut(Fno, "U") : DBSTAT = nErr
			If Err.Number Then DBSTAT = Err.Number
		Else
			DBSTAT = nErr
		End If
		DB_PARA(Fno).Status = DBSTAT
		Call JB_ErrorCheck("Update", Fno)
	End Sub
	
	'旧関数インターフェイス
	
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'''''''''''''''''' Followings:  Added on Aug. 20,'96  ''''''''''''''''''''''
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Public Sub ResetDBSTAT(ByRef Fno As Short, Optional ByRef bApp As Short = 0)
		G_FNO = Fno
		If (Fno >= 0) Then
			DB_PARA(Fno).Status = DBSTAT
		End If
		DBSTAT = 0
		Err.Clear()
		ret = 0
		StTime = VB.Timer()
		DB_REALWAITSEC = IIf(bApp = AppLock, DB_APPWAITSEC / 1000, DB_MAXWAITSEC)
		EnTime = StTime + DB_REALWAITSEC
	End Sub
	
	Public Sub SetDBSTAT(ByRef erno As Object)
		'UPGRADE_WARNING: オブジェクト erno の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DBSTAT = CInt(erno)
		If G_FNO >= 0 Then DB_PARA(G_FNO).Status = DBSTAT
	End Sub
	
	Public Function IS_ORA(ByRef Fno As Short, Optional ByRef bNoCheck As Object = Nothing) As Object
		Dim sID As String
		Dim n As Short
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(bNoCheck) And RsOpened(Fno) = False Then
			MsgBox("ファイルがオープンされていません。(" & DB_PARA(Fno).tblid & ")")
			Call Error_Exit("Table is Not Opened !" & " = [" & DB_PARA(Fno).tblid & ":" & DBSTAT & "]")
		End If
		'sID$ = UCase(Left$(DB_PARA(Fno).DBID, 4))
		sID = Trim(UCase(DB_PARA(Fno).DBID))
		'UPGRADE_WARNING: オブジェクト IS_ORA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		IS_ORA = False
		If sID = "USR2" Or sID = "USR3" Then Exit Function
		'If (sID$ = "SYSDBC" Or sID$ = "SSSWB2") And G_bORA_RPS_EXT = False Then Exit Function
		'If Left$(sID$, 3) <> "USR" And G_bORA_RPS = False Then Exit Function
		If (sID = "SYSDBC" Or sID = "SSSWB2") Then
			If G_bORA_RPS_EXT = False Then Exit Function
		ElseIf Left(sID, 3) <> "USR" Then 
			If G_bORA_RPS = False Then Exit Function
		End If
		'UPGRADE_WARNING: オブジェクト IS_ORA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		IS_ORA = True
	End Function
	
	Sub DB_ChkKey(ByRef Fno As Short, ByRef KeyNo As Short)
		If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
	End Sub
	
	Sub DB_MakKey(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object)
		If KeyNo >= 0 Then DB_PARA(Fno).KeyNo = KeyNo
		'UPGRADE_WARNING: オブジェクト keyVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(Fno).KeyBuf = CStr(keyVal)
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(DB_PARA(Fno).KeyBuf) Or Asc(DB_PARA(Fno).KeyBuf) = 0 Then DB_PARA(Fno).KeyBuf = ""
	End Sub
	
	''Declare Function DB_GetFirst Lib "sssoraif" (ByVal Fno&, recBuf As Any, ByVal KeyNo&, ByVal lockFlg&) As Long
	Sub DB_GetFirst(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetFirst(Fno, KeyNo, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_ChkKey(Fno, KeyNo)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetFirst(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetFirst", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_GetNext Lib "sssoraif" (Fno as integer, recBuf As Any, lockFlg as integer) As Long
	Sub DB_GetNext(ByRef Fno As Short, ByRef LockFlg As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetNext(Fno, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call ResetExtNum()
		If DB_PARA(Fno).nDirection = nDir_Fore Then
			Call SetBuf(Fno)
			Call DB_ChkKey(Fno, -1)
			Do 
				'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DBSTAT = Dll_GetNext(Fno, G_LB, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, DB_ExtNum)
			Loop While IsBusy_ORA("DB_GetNext", LockFlg)
			Call ResetBuf(Fno)
			'Debug.Print DB_PARA(FNO).KeyBuf
		Else
			DBSTAT = -11
		End If
		Call SetDBSTAT(DBSTAT)
	End Sub
	
	''Declare Function DB_GetPre Lib "sssoraif" (ByVal FNo&, recBuf As Any, lockFlg as integer) As Long
	Sub DB_GetPre(ByRef Fno As Short, ByRef LockFlg As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetPre(Fno, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call ResetExtNum()
		If DB_PARA(Fno).nDirection = nDir_Back Then
			Call SetBuf(Fno)
			Call DB_ChkKey(Fno, -1)
			Do 
				'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DBSTAT = Dll_GetPre(Fno, G_LB, DB_PARA(Fno).KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, DB_ExtNum)
			Loop While IsBusy_ORA("DB_GetPre", LockFlg)
			Call ResetBuf(Fno)
		Else
			DBSTAT = -12
		End If
		Call SetDBSTAT(DBSTAT)
	End Sub
	
	''Declare Function DB_GetLast Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, lockFlg as integer) As Long
	Sub DB_GetLast(ByRef Fno As Short, ByRef KeyNo As Short, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetLast(Fno, KeyNo, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_ChkKey(Fno, KeyNo)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetLast(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetLast", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
	End Sub
	
	''Declare Function DB_GetEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, ByVal keyVal$, lockFlg as integer) As Long
	Sub DB_GetEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_MakKey(Fno, KeyNo, keyVal)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetEq", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
	End Sub
	
	''Declare Function DB_GetGrEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal as string, lockFlg as integer) As Long
	Sub DB_GetGrEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetGrEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_MakKey(Fno, KeyNo, keyVal)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetGrEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
			
		Loop While IsBusy_ORA("DB_GetGrEq", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_GetGr Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
	Sub DB_GetGr(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetGr(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_MakKey(Fno, KeyNo, keyVal)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetGr(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetGr", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_GetLs Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
	Sub DB_GetLs(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetLs(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_MakKey(Fno, KeyNo, keyVal)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetLs(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetLs", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
	End Sub
	
	''Declare Function DB_GetLsEq Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer, keyVal As Variant, lockFlg as integer) As Long
	Sub DB_GetLsEq(ByRef Fno As Short, ByRef KeyNo As Short, ByVal keyVal As Object, ByRef LockFlg As Short, Optional ByVal sFields As Object = Nothing)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetLsEq(Fno, KeyNo, keyVal, LockFlg) : Exit Sub
		Call ResetDBSTAT(Fno, LockFlg)
		Call SetBuf(Fno)
		Call DB_MakKey(Fno, KeyNo, keyVal)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(sFields) Then
			G_sFields = ""
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			G_sFields = sFields
		End If
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetLsEq(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf, LockFlg, G_sFields, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetLsEq", LockFlg)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Back
	End Sub
	
	''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
	Sub DB_GetSQL(ByRef Fno As Short, ByRef sqlStmt As String, Optional ByVal sFields As Object = Nothing)
		Dim Sql As String
		Dim I As Short
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Or IsNothing(sFields) Then
			Sql = "Select *"
		Else
			'UPGRADE_WARNING: オブジェクト sFields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Sql = "Select " + sFields
		End If
		Sql = Sql & " From " & DB_PARA(Fno).tblid & " WHERE " & sqlStmt
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, Sql) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetSQL(Fno, G_LB, Sql, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetSQL")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
	Sub DB_GetSQL2(ByRef Fno As Short, ByRef sqlStmt As String)
		'Dim Sql$, i%
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt) : Exit Sub
		'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetSQL(Fno, G_LB, sqlStmt, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetSQL")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_GetSQL Lib "sssoraif" (Fno as integer, recBuf As Any, ByVal sqlStmt$) As Long
	Sub DB_GetSQL3(ByRef Fno As Short, ByRef sqlStmt As String)
		'Dim Sql$, i%
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_GetSQL(Fno, sqlStmt) : Exit Sub
		'Sql = "Select * From " + DB_PARA(Fno).tblid + " WHERE " + sqlStmt
		Call ResetDBSTAT(Fno, AppLock)
		Call SetBuf(Fno)
		Call ResetExtNum()
		Do 
			'UPGRADE_WARNING: オブジェクト DB_ExtNum の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_GetSQL(Fno, G_LB, sqlStmt, DB_ExtNum)
		Loop While IsBusy_ORA("DB_GetSQL", AppLock)
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_Fore
	End Sub
	
	''Declare Function DB_Execute Lib "sssoraif" (ByVal sqlStmt$) As Long
	Sub DB_Execute(ByRef Fno As Short, ByRef sqlStmt As String)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_Execute(Fno, sqlStmt) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Do 
			DBSTAT = Dll_Execute(Fno, sqlStmt)
		Loop While IsBusy_ORA("DB_Execute")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		''If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
	End Sub
	
	Public Sub DB_DelAll(ByRef Fno As Short)
		Dim swk As String
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_DelAll(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		'sWK$ = "DELETE FROM " + Trim$(DB_PARA(Fno).DBID) + "." + Trim$(DB_PARA(Fno).tblid)
		swk = "DELETE FROM " & Trim(DB_PARA(Fno).tblid)
		Do 
			DBSTAT = Dll_Execute(Fno, swk)
		Loop While IsBusy_ORA("DB_DelAll")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
	End Sub
	
	'' Deleting , Inserting and Updating Data
	''Declare Function DB_Delete Lib "sssoraif" (ByVal FNo&, recBuf As Any) As Long
	Sub DB_Delete(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_DELETE(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Do 
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_Delete(Fno, G_LB)
		Loop While IsBusy_ORA("DB_Delete")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
	End Sub
	
	''Declare Function DB_Insert Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer) As Long
	Sub DB_Insert(ByRef Fno As Short, ByRef KeyNo As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_Insert(Fno, KeyNo) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Call DB_ChkKey(Fno, KeyNo)
		Do 
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_Insert(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf)
		Loop While IsBusy_ORA("DB_Insert")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
	End Sub
	
	''Declare Function DB_Update Lib "sssoraif" (ByVal FNo&, recBuf As Any, KeyNo as integer) As Long
	Sub DB_Update(ByRef Fno As Short, ByRef KeyNo As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_Update(Fno, KeyNo) : Exit Sub
		Call ResetDBSTAT(Fno)
		Call SetBuf(Fno)
		Call DB_ChkKey(Fno, KeyNo)
		Do 
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DBSTAT = Dll_Update(Fno, G_LB, KeyNo, DB_PARA(Fno).KeyBuf)
		Loop While IsBusy_ORA("DB_Update")
		Call ResetBuf(Fno)
		Call SetDBSTAT(DBSTAT)
	End Sub
	
	'' Others
	Sub DB_Stat(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_STAT(Fno) : Exit Sub
		Dim xxx As Integer
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_Stat(Fno, xxx)
		If DBSTAT = 0 Then
			StatFileBuffer.RecTot = xxx
		Else
			StatFileBuffer.RecTot = 0
		End If
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then DB_PARA(Fno).nDirection = nDir_None
	End Sub
	
	''Declare Function DB_Start Lib "sssoraif" (ByVal sCon$) As Long
	Sub DB_Start(ByRef DbNm As String, ByRef DbHd As String)
		Dim sDLL_VER As String
		Call DB_End()
		Call ResetDBSTAT(-1)
		G_sUNIID = "" : G_nUNICNT = 0
		G_bUSR1_ON = False
		G_bSUP_ERR = False
		G_nTranStt = 0
		G_bBusyLog = False
		G_bTranLog = False
		Ora_DBName = DbNm : Ora_DBHead = DbHd : Ora_Connect1 = Ora_DBHead & Ora_Connect
		'Debug.Print Timer
		sDLL_VER = "            "
		Call Dll_ChkVer(sDLL_VER)
		If Left(sBAS_VER, 5) <> Left(sDLL_VER, 5) Then
			Call MsgBox("バージョン不一致:ORAJET.BAS=" & sBAS_VER & ", SSSORAIF.DLL=" & Left(sDLL_VER, 7))
			Call Error_Exit("バージョン不一致:ORAJET.BAS=" & sBAS_VER & ", SSSORAIF.DLL=" & Left(sDLL_VER, 7))
		End If
		DBSTAT = Dll_Start(Ora_DBName, Ora_DBHead)
		Ora_DBStart_FLG = 1
		Call Ora_ErrorCheck("DB_Start", -1)
		'Debug.Print Timer
		If Ora_DBStart_FLG = 0 Then
			If DBSTAT = 0 Then
				'Call JB_Start
				Ora_DBStart_FLG = 1
			End If
		End If
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
	Sub DB_Open(ByRef Fno As Short, ByRef DBID As String, ByRef tblid As String)
		Dim EN_TIME As Object
		Dim sMsg As String
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno, True) = 0 Then Call JB_Open(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		'UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		EN_TIME = VB.Timer() + 10
		'Debug.Print Timer
		Do While True
			DBSTAT = Dll_Open(Fno, DBID, tblid)
			If DBSTAT <> -171 Then Exit Do
			'UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If VB.Timer() > EN_TIME Then
				sMsg = tblid & "のＳＣＭファイルが読めません。"
				sMsg = sMsg & vbCrLf & "ファイルや通信の不良等の可能性が有ります。"
				sMsg = sMsg & vbCrLf & "再試行（リトライ）しますか？"
				If MsgBox(sMsg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then Exit Do
				'UPGRADE_WARNING: オブジェクト EN_TIME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				EN_TIME = VB.Timer() + 10
			Else
				Call Sleep(G_RetryItv) 'DoEvents
			End If
		Loop 
		'Debug.Print Timer
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_Open", Fno)
		If DBSTAT = 0 Then
			RsOpened(Fno) = True : DB_PARA(Fno).nDirection = nDir_None
			If Left(UCase(DBID), 3) = "USR" Then G_bUSR1_ON = True
		End If
	End Sub
	
	''Declare Function DB_Close Lib "sssoraif" (Fno as integer) As Long
	Sub DB_Close(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_Close(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_Close(Fno)
		'    bOracle(Fno) = 0
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_Close", Fno)
		If DBSTAT = 0 Then RsOpened(Fno) = False
	End Sub
	
	''Declare Function DB_Can Lib "sssoraif" (Fno as integer) As Long
	Sub DB_Can(ByRef Fno As Short)
		If Fno = -1 Then DBSTAT = Dll_Can(Fno) : Exit Sub
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Exit Sub
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_Can(Fno)
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_Can", Fno)
	End Sub
	
	''Declare Function DB_End Lib "sssoraif" () As Long
	Sub DB_End()
		' if Ora_DBName$ <> "" And Ora_DBHead$ <> "" Then
		If Ora_DBStart_FLG <> 0 Then ' 2000.2.14 for 8i
			DBSTAT = Dll_End
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
			DBSTAT = Dll_BeginTransaction(0)
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
			DBSTAT = Dll_BeginTransaction(1)
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
			DBSTAT = Dll_BeginTransaction(1)
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
		DBSTAT = Dll_AbortTransaction
		Call Ora_ErrorCheck("Dll_AbortTransaction", -1)
		If G_bUSR1_ON Then Call DB_LockOff(0)
		Call Ora_ErrorCheck("DB_LockOff", -1)
		If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog() : G_nTranStt = 0
	End Sub
	
	''Declare Function DB_EndTransaction Lib "sssoraif" () As Long
	Sub DB_EndTransaction()
		JB_EndTransaction()
		Call JB_ErrorCheck("JB_EndTransaction", -1)
		DBSTAT = Dll_EndTransaction
		Call Ora_ErrorCheck("Dll_EndTransaction", -1)
		If G_bUSR1_ON Then Call DB_LockOff(1)
		Call Ora_ErrorCheck("DB_LockOff", -1)
		If G_bTranLog = True And G_nTranStt <> 0 Then Call DB2_TranLog() : G_nTranStt = 0
	End Sub
	
	'' Nop inside
	''Declare Function JB_ErrorCheck Lib "sssoraif" (ByVal opCode%, tblName As Any) As Long
	'????????????????????Sub JB_ErrorCheck(opCode As Integer, tblName As String)
	'    DBSTAT = Dll_ErrorCheck(opCode, tblName)
	'End Sub
	
	''Declare Function DB_NCCLOSE Lib "sssoraif" (ByVal FNo&) As Long
	Sub DB_NCCLOSE(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno, True) = 0 Then Call JB_NCCLOSE(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_NCCLOSE(Fno)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then RsOpened(Fno) = False
	End Sub
	
	''Declare Function DB_NCOPEN Lib "sssoraif" (ByVal FNo&, FileLocation As Any, DBFLocation As Any) As Long
	Sub DB_NCOPEN(ByRef Fno As Short, ByRef FileLocation As String, ByRef DBFLocation As String)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno, True) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno, True) = 0 Then Call JB_NCOPEN(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_NCOPEN(Fno, FileLocation, DBFLocation)
		Call SetDBSTAT(DBSTAT)
		If DBSTAT = 0 Then RsOpened(Fno) = True : DB_PARA(Fno).nDirection = nDir_None
	End Sub
	
	''Declare Function DB_Unlock Lib "sssoraif" (ByVal FNo&) As Long
	Sub DB_Unlock(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If IS_ORA(Fno) = 0 Then Call JB_Unlock(Fno) : Exit Sub
		Call ResetDBSTAT(Fno)
		DBSTAT = Dll_Unlock(Fno)
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_Unlock", Fno)
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
		'UPGRADE_WARNING: オブジェクト G_PlInfo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PlStart = Dll_PlStart(G_PlInfo, bGetRec)
		Call SetDBSTAT(DB_PlStart)
		Call Ora_ErrorCheck("DB_PlStart", -1)
	End Function
	
	Function DB_PlFree() As Integer
		Call ResetDBSTAT(-1)
		DB_PlFree = Dll_PlFree()
		Call SetDBSTAT(DB_PlFree)
		Call Ora_ErrorCheck("DB_PlFree", -1)
	End Function
	
	Function DB_PlSet(ByRef Fno As Short, ByRef RNo As Short) As Integer
		Call ResetDBSTAT(-1)
		Call SetBuf(Fno)
		'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PlSet = Dll_PlSet(Fno, RNo, G_LB)
		'''''Call ResetBuf(FNo)
		Call SetDBSTAT(DB_PlSet)
		Call Ora_ErrorCheck("DB_PlSet", -1)
	End Function
	
	Function DB_PlCndSet() As Integer
		Dim n As Short
		Call ResetDBSTAT(-1)
		n = IIf(G_bExtCnd, 12, 8)
		If G_NO_ALTLOG Then G_PlCnd.nCndNum(n) = SSS_NO_ALTOUT
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
		G_LB = LSet(G_PlCnd)
		'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PlCndSet = Dll_PlCndSet(G_LB)
		Call SetDBSTAT(DB_PlCndSet)
		Call Ora_ErrorCheck("DB_PlCndSet", -1)
	End Function
	
	Function DB_PlExec(ByRef Pack_Proc As String) As Integer
		Call ResetDBSTAT(-1)
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
		G_LB = LSet(G_PlCnd2)
		Do 
			'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_PlExec = Dll_PlExec(Pack_Proc, G_LB)
			DBSTAT = DB_PlExec
		Loop While IsBusy_ORA("DB_PlExec")
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
		G_PlCnd2 = LSet(G_LB)
		Call SetDBSTAT(DB_PlExec)
	End Function
	
	Function DB_PlGetCnt(ByRef Fno As Short) As Integer
		Call ResetDBSTAT(-1)
		DB_PlGetCnt = Dll_PlGetCnt(CInt(Fno))
		If DB_PlGetCnt < 0 Then
			Call SetDBSTAT(DB_PlGetCnt)
			Call Ora_ErrorCheck("DB_PlGetCnt", -1)
		Else
			Call SetDBSTAT(0)
			'Call Ora_ErrorCheck("DB_PlGetCnt", -1)
		End If
	End Function
	
	Function DB_PlGet(ByRef Fno As Short, Optional ByRef RNo_V As Object = Nothing) As Integer
		Dim RNo As Integer
		Call ResetDBSTAT(-1)
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(RNo_V) Then
			RNo = -1
		Else
			'UPGRADE_WARNING: オブジェクト RNo_V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RNo = CInt(RNo_V)
		End If
		Call SetBuf(Fno)
		'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PlGet = Dll_PlGet(Fno, G_LB, RNo)
		If DBSTAT = 0 Then Call ResetBuf(Fno)
		Call SetDBSTAT(DB_PlGet)
		Call Ora_ErrorCheck("DB_PlGet", -1)
	End Function
	
	Function IsBusy_ORA(ByRef opCode As String, Optional ByRef LockFlg As Short = 0) As Short
		Dim tblName As String
		Dim Msg As String
		Dim bApp As Boolean
		'
		IsBusy_ORA = 0
		If DBSTAT = 0 Then Exit Function
		If G_FNO >= 0 Then tblName = DB_PARA(G_FNO).tblid Else tblName = " "
		'
		bApp = False
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(LockFlg) Then
			If LockFlg = AppLock Then bApp = True
		End If
		'
		'    If DBSTAT = 60 Then
		'        If opCode <> "DB_PlExec" Then Call Ora_ErrorCheck(opCode, G_FNO)
		'    End If
		Select Case DBSTAT
			Case 54, 56 'when busy
				'Case 54, 56, 60, -60 'when busy or Dlck
				'If DBSTAT = 1 And opCode <> "DB_PlExec" Then
				'    Call Ora_ErrorCheck(opCode, G_FNO)
				'    Exit Function
				'End If
				IsBusy_ORA = 1
				System.Windows.Forms.Application.DoEvents()
				CurTime = VB.Timer()
				If CurTime < StTime Then StTime = CurTime : EnTime = StTime + 5
				If CurTime > EnTime Then
					If G_bBusyLog Then Call DB2_BusyLog()
					'If Kbn$ = "E" Then Syori$ = "EDIT" Else If Kbn$ = "U" Then Syori$ = "Update" Else Kbn$ = "Delete"
					''Msg$ = Str$(DB_MAXWAITSEC%) + "秒間待ちましたが、ORACLEファイルが使用中です。" + Chr$(13)
					''Msg$ = Msg$ + "FILE_ID = (" + tblName + ")  処理 = " + opCode + " コード = " + Str$(DBSTAT) + Chr$(13) + Chr$(13)
					If bApp Then
						Msg = "このデータは現在他でロックされています。" & Chr(13)
						Msg = Msg & "管理者に連絡するか、しばらく待ってから再度処理を行って下さい。" & Chr(13)
						Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
						Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
						Msg = Msg & "［注意］キャンセルすると、このデータをロックせずに処理に戻ります！"
					Else
						Msg = "サーバがビジー状態のため登録処理を行えません。" & Chr(13)
						Msg = Msg & "管理者に連絡するか、しばらく待ってから再度登録処理を行って下さい。" & Chr(13)
						Msg = Msg & "FILE_ID = (" & tblName & ")  処理 = " & opCode & " コード = " & Str(DBSTAT) & Chr(13) & Chr(13)
						Msg = Msg & "再試行（リトライ）しますか？" & Chr(13)
						Msg = Msg & "［注意］キャンセルすると、このデータ"
						If opCode <> "DB_PlExec" Then
							If G_bRetApp = True And Left(opCode, 10) = "DB_BeginTr" Then bApp = True : LockFlg = AppLock
							If bApp = True Then
								Msg = Msg & "を登録せずに処理に戻ります！"
							Else
								Msg = Msg & "を登録せずにプログラムを終了します！"
							End If
						Else
							Msg = Msg & "を登録せずに画面がクリアされます！"
						End If
					End If
					If MsgBox(Msg, MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
						IsBusy_ORA = 0
						If opCode <> "DB_PlExec" Then
							If bApp = True Then
								GoTo IsBusy_ORA_EX
							Else
								G_bSUP_ERR = True
								GoTo IsBusy_ORA_EX
								'Call Error_Exit("ORACLE ReTry Error ! [" & tblName & ":" & opCode & ":" & DB_MAXWAITSEC% & "]")
							End If
						Else
							Exit Function
						End If
					Else
						StTime = VB.Timer()
						EnTime = StTime + DB_REALWAITSEC
					End If
				Else
					Call Sleep(G_RetryItv) 'DoEvents
				End If
			Case Else
				GoTo IsBusy_ORA_EX
		End Select
		Exit Function
		'
IsBusy_ORA_EX: 
		If bApp = False Then
			Call Ora_ErrorCheck(opCode, G_FNO)
		Else
			Call Ora_ErrorCheck(opCode, G_FNO, LockFlg)
		End If
	End Function
	
	Function DB_LockOn(ByRef nSyu As Short) As Integer
		Dim sSyu, sSQL As String
		Dim nUNICNT As Integer
		DBSTAT = 0
		'UPGRADE_WARNING: オブジェクト Switch() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		sSyu = VB.Switch(nSyu = 1, G_sRRRLock, nSyu = 2, G_sRRRLock2, nSyu = 3, G_sRRRLock3)
		If sSyu <> "" Then
			sSQL = "LOCK TABLE SYSTBL IN " & sSyu & " MODE NOWAIT"
			'''Do-2.3.0.3
			If sSyu = "TPA" Then
				nUNICNT = G_nUNICNT
				DBSTAT = Dll_TpaLock(G_sUNIID, nUNICNT)
				If DBSTAT = 1403 Then
					nUNICNT = G_nUNICNT
					DBSTAT = Dll_TpaIns(G_sUNIID, nUNICNT, G_sOPEID, G_sCLTID, VB6.Format(TimeOfDay, "hhmmss"), VB6.Format(Today, "yyyymmdd"))
					If DBSTAT = 1 Then DBSTAT = 0
					If DBSTAT = 0 Then DBSTAT = 54
				End If
			Else
				DBSTAT = Dll_Usr1Exec(sSQL)
			End If
			'''Loop While IsBusy_ORA("DB_LockOn")
		End If
		DB_LockOn = DBSTAT
	End Function
	
	Sub DB2_BusyLog()
		If G_bTool Then Exit Sub
		Dim sMsg, sFName, swk As String
		Dim IMA As Object
		sFName = TRAN_LOG_PATH & "BUSY.LOG"
		If DB_REALWAITSEC = DB_MAXWAITSEC Then sMsg = "tp=BUSY" Else sMsg = "tp=LOCK"
		sMsg = sMsg & ", clid=" & G_sCLTID
		sMsg = sMsg & ", pid=" & VB6.Format(G_sPRGID, "!@@@@@@@@@@")
		swk = Space(10) & VB6.Format(DB_REALWAITSEC * 1000, "##########")
		sMsg = sMsg & ", ms=" & Right(swk, 10)
		'sMsg$ = sMsg$ + ", tm=" + Format$(Time, "hhmmss")
		'sMsg$ = sMsg$ + ", dt=" + Format$(Date, "yyyymmdd")
		Call DB2_UtlGetOraDT()
		swk = Left(DB_ORADT, 2) & "/" & Mid(DB_ORADT, 3, 2) & "/" & Right(DB_ORADT, 2) & " "
		swk = swk & Left(DB_ORATM, 2) & ":" & Mid(DB_ORATM, 3, 2) & ":" & Right(DB_ORATM, 2)
		'UPGRADE_WARNING: オブジェクト IMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		IMA = System.Date.FromOADate(CDate(swk).ToOADate - DB_REALWAITSEC / nSecOfDay)
		'UPGRADE_WARNING: オブジェクト IMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		sMsg = sMsg & ", st=" & VB6.Format(IMA, "hhmmss")
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
		sMsg = sMsg & ", pid=" & VB6.Format(G_sPRGID, "!@@@@@@@@@@")
		swk = Space(10) & VB6.Format(nTranMS, "##########")
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
			If nErr = 70 Then Call Sleep(G_RetryItv / 10) 'DoEvents
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
				DBSTAT = Dll_Usr1Exec(sSQL)
			Loop While IsBusy_ORA("DB_LockOff")
		End If
		DB_LockOff = DBSTAT
	End Function
	
	''Declare Function DB_ChgMode Lib "sssoraif" (ByVal sMode$) As Long
	Sub DB_ChgMode(ByRef sMode As String)
		Call ResetDBSTAT(-1)
		DBSTAT = Dll_ChgMode(sMode)
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_ChgMode", -1)
	End Sub
	
	''Declare Function DB_ClrMode Lib "sssoraif" () As Long
	Sub DB_ClrMode()
		Call ResetDBSTAT(-1)
		DBSTAT = Dll_ClrMode()
		Call SetDBSTAT(DBSTAT)
		Call Ora_ErrorCheck("DB_ClrMode", -1)
	End Sub
	
	'Declare Function Dll_GetOraDT Lib "sssoraif" (ByVal Fno&, ByVal sDT$, ByVal sTM$) As Long
	Sub DB_GetOraDT(ByRef Fno As Short)
		'UPGRADE_WARNING: オブジェクト IS_ORA(Fno) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Fno >= 0 Then If IS_ORA(Fno) = 0 Then Call Error_Exit("ファイルＮＯが無効です。:Fno=" & Str(Fno))
		DB_ORADT = "        "
		DB_ORATM = "      "
		DBSTAT = Dll_GetOraDT(Fno, DB_ORADT, DB_ORATM)
		DB_ORADT = Left(DB_ORADT, 8)
		DB_ORATM = Left(DB_ORATM, 6)
	End Sub
	
	Sub DB2_UtlGetOraDT()
		DB_ORADT = "        "
		DB_ORATM = "      "
		If G_bTool Then Exit Sub
		Call Dll_GetOraDT(-1, DB_ORADT, DB_ORATM)
		DB_ORADT = Left(DB_ORADT, 8)
		DB_ORATM = Left(DB_ORATM, 6)
	End Sub
	
	Sub DB_SetPGID(ByRef sPGID As String)
		Call ResetDBSTAT(-1)
		DBSTAT = Dll_SetPGID(sPGID)
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
End Module