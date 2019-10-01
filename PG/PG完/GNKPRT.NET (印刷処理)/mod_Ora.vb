Option Strict Off
Option Explicit On
'2019/05/21 ADD START 
Imports VB = Microsoft.VisualBasic
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System
Imports System.Reflection
'2019/05/21 ADD E N D

Module mod_Ora

    Public gv_Oss As Object '//ORACLEセッション
    Public gv_Odb As Object '//ORACLEデータベース

    '2019/05/13 CHG START
    ''UPGRADE_ISSUE: OraSessionClass オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'Public OSession As OraSessionClass
    ''UPGRADE_ISSUE: OraDatabase オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'Public ODatabase As OraDatabase
    ''UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    'Public Odynaset As OraDynaset
    Public ODatabase As Object
    Public Odynaset As Object
    '2019/05/13 CHG E N D

    '// ORACLEﾃﾞｰﾀﾍﾞｰｽ変数---------------------------
    '// ダイナセット情報構造体
    Public Structure U_Ody
        Dim Obj_Ody As Object '//OraDynasetｵﾌﾞｼﾞｪｸﾄ
        Dim Obj_Flds() As Object '//ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ
        Dim Lng_FldCnt As Integer '//ﾌｨｰﾙﾄﾞ数
        Dim Str_FldNm As String '//フィールド番号とﾌｨｰﾙﾄﾞ名
    End Structure

    'OpenDatabase Method Options
    Public Const ORADB_DEFAULT As Integer = &H0
    Public Const ORADB_ORAMODE As Integer = &H1
    Public Const ORADB_NOWAIT As Integer = &H2
    Public Const ORADB_DBDEFAULT As Integer = &H4
    Public Const ORADB_DEFERRED As Integer = &H8
    Public Const ORADB_ENLIST_IN_MTS As Integer = &H10

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

    '// 共通
    Public gv_Int_OraErr As Short '//ORACLEエラー番号
    Public gv_Str_OraErrText As String '//ORACLEエラーテキスト



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
    '//* 1.00     |20091127|ECHO)           |新規作成
    '//**************************************************************************************
    Public Function F_Ora_Connect(ByRef pm_Oss As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean

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
        '    With pm_Odb
        ''        gv_Int_OraErr = .LastServerErr
        '        gv_Str_OraErrText = .LastServerErrText
        '        .LastServerErrReset
        '    End With
        '    GoTo EXIT_HANDLE

    End Function

    '//**************************************************************************************
    '//*
    '//* <名  称>
    '//*    F_Ora_Connect2
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
    '//* 1.00     |20091127|ECHO)           |新規作成
    '//**************************************************************************************
    '2019/05/13 CHG START
    'Public Function F_Ora_Connect2(ByRef pm_Osc As OraSessionClass, ByRef pm_Odb As OraDatabase, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
    Public Function F_Ora_Connect2(ByRef pm_Osc As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
        '2019/05/13 CHG E N D
        Dim Lng_Option As Integer '//ﾊﾟﾗﾒｰﾀ

        On Error GoTo ERR_HANDLE

        F_Ora_Connect2 = False

        '// ﾊﾟﾗﾒｰﾀの設定
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pm_Option) = False Then
            Lng_Option = CInt(pm_Option)
        Else
            '//デフォルト
            Lng_Option = ORADB_DEFAULT
        End If

        '// 既にｵｰﾌﾟﾝ済ならば正常ﾘﾀｰﾝ
        If (pm_Osc Is Nothing) = False And (pm_Odb Is Nothing) = False Then
            F_Ora_Connect2 = True
            GoTo EXIT_HANDLE
        End If

        '// ORACLEﾃﾞｰﾀﾍﾞｰｽに接続
        pm_Osc = CreateObject("OracleInProcServer.XOraSession")
        'UPGRADE_WARNING: オブジェクト pm_Osc.OpenDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_Odb = pm_Osc.OpenDatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)

        '//正常終了
        F_Ora_Connect2 = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:

        '//ORACLEエラー番号取得
        '    With pm_Odb
        ''        gv_Int_OraErr = .LastServerErr
        '        gv_Str_OraErrText = .LastServerErrText
        '        .LastServerErrReset
        '    End With
        '    GoTo EXIT_HANDLE

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
            pm_Ody.Lng_FldCnt = pm_Ody.Obj_Ody.Fields.Count

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

        'フィールド番号のみで取得するため削除
        '    Str_FldNm = Mid$(pm_Ody.Str_FldNm, InStr(pm_Ody.Str_FldNm, ":" & UCase$(Str_FldNm) & ":") - 4, 4)

        '// ﾌｨｰﾙﾄﾞﾀｲﾌﾟとﾃﾞｰﾀを取得
        'UPGRADE_WARNING: オブジェクト pm_Ody.Obj_Flds(CInt(Str_FldNm)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Var_Value = pm_Ody.Obj_Flds(CShort(Str_FldNm))

        '// 日付型ならばﾌｫｰﾏｯﾄ形式をYYYY/MM/DDに設定

        '// ﾃﾞｰﾀの取得
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(Var_Value) Then

            '*D*CF_Ora_GetDyn = Var_Default
            Select Case SSS_PrtID
                '売上原価対照表(経理調整),売上原価対照表(全社),売上原価対照表(事業部別),
                '売上原価対照表(取引先),原価差額分析表
                Case ps_rptid_GNKPR01, ps_rptid_GNKPR02, ps_rptid_GNKPR03, ps_rptid_GNKPR04, ps_rptid_GNKPR13
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    CF_Ora_GetDyn = ""
                    '上記以外
                Case Else
                    'UPGRADE_WARNING: オブジェクト Var_Default の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    CF_Ora_GetDyn = Var_Default
            End Select

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
    Public Function CF_Ora_GetDyn2(ByVal pm_Fld As String, Optional ByVal pm_Default As Object = "", Optional ByVal pm_Format As String = "") As Object

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

        '// ﾌｨｰﾙﾄﾞﾀｲﾌﾟとﾃﾞｰﾀを取得
        'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Var_Value = pm_Fld

        '// 日付型ならばﾌｫｰﾏｯﾄ形式をYYYY/MM/DDに設定

        '// ﾃﾞｰﾀの取得
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(Var_Value) Then

            '*D*CF_Ora_GetDyn = Var_Default
            Select Case SSS_PrtID
                '売上原価対照表(経理調整),売上原価対照表(全社),売上原価対照表(事業部別),
                '売上原価対照表(取引先),原価差額分析表
                Case ps_rptid_GNKPR01, ps_rptid_GNKPR02, ps_rptid_GNKPR03, ps_rptid_GNKPR04, ps_rptid_GNKPR13
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    CF_Ora_GetDyn2 = ""
                    '上記以外
                Case Else
                    'UPGRADE_WARNING: オブジェクト Var_Default の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    CF_Ora_GetDyn2 = Var_Default
            End Select

        Else
            If Str_Format = "" Then
                'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CF_Ora_GetDyn2 = Var_Value
            Else
                'UPGRADE_WARNING: オブジェクト Var_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CF_Ora_GetDyn2 = VB6.Format(Var_Value, Str_Format)
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
    '//*    GetChar
    '//*
    '//* <戻り値>     型          説明
    '//*             String       True ...EOF
    '//*                          False...EOFではない
    '//* <引  数>     項目名             型              I/O           内容
    '//*              pm_Ody             U_Ody            I            ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
    '//* <説  明>
    '//*    po_ValueがNull等の場合は""に変換、そうでない場合はそのままの値が返る
    '//*
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |新規作成
    '//**************************************************************************************
    'UPGRADE_NOTE: GetChar は GetChar_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
    Public Function GetChar_Renamed(ByRef po_Value As String) As String

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(po_Value) Then
            GetChar_Renamed = ""
        Else
            GetChar_Renamed = po_Value
        End If

    End Function

    'add start 20190820 kuwa
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

    Public gv_Odb_USR1 As Object '//ORACLEデータベース

    'add end 20190820 kuwa

End Module