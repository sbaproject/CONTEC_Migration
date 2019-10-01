Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'2019/04/17 ADD START AE_CMN追加したら消す
Imports PronesDbAccess
Imports Oracle.DataAccess.Client
'2019/04/17 ADD EN D
Module SSSWIN


    '******************************************************************'
    '* PG名:URKET53 入金消込
    '* 更新日   : 2008/07/25
    '* 更新者   : FKS)中田
    '* 処理内容 : 明細が2行以上ある受注に対し、返品登録を行った後
    '*            受注訂正を行うと本来出力対象にあらないデータが
    '*            画面上に出てきてしまうのを修正
    '******************************************************************'

    '2019/04/17 ADD START
    Public Const SSS_MAX_DB As Short = 22
    Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
    Public SSS_VALKB As Boolean '有効データ区分(True=明細行なしでの登録可)
    '単プロジェクトごとの共通ライブラリ
    Public PP_SSSMAIN As clsPP
    Public CP_SSSMAIN(169 + 23 + 0 + 1) As clsCP
    Public CL_SSSMAIN(169) As Short
    Public CQ_SSSMAIN(54) As String

    Public SSS_BILFL As Short 'ビリング発行区分(1:発行/9:なし)
    Public SSS_ReadOnly As Short

    ' MsgKB メッセージ種別
    Public Const SSS_EEE As String = "0" ' ｅｅｅのメッセージ
    Public Const SSS_ERROR As String = "2" ' ＳＳＳエラーメッセージ

    Public Structure Cmn_Inp_Inf
        Dim InpTanCd As String '入力担当者ＩＤ
        Dim InpTanNm As String '入力担当者名
        Dim InpTKCHGKB As String '単価変更権限
        Dim InpCLIID As String 'クライアントＩＤ
        ' === 20060828 === INSERT S - ACE)Sejima
        Dim InpJDNUPDKB As String '受注更新権限
        ' === 20060828 === INSERT E
        ' === 20061030 === INSERT S - ACE)Nagasawa 権限の読み方の変更
        Dim InpPRTAUTH As String '印刷権限
        Dim InpFILEAUTH As String 'ファイル出力権限
        ' === 20061030 === INSERT E -
    End Structure

    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String 'ダミー
        Dim DKBID As String
        Dim DKBNM As String
        Dim KANKOZ As String
        Dim NYUKN As Decimal
        Dim FNYUKN As Double
        Dim BNKCD As String
        Dim BNKNM As String
        Dim JDNNO As String
        Dim JDNLINNO As String
        Dim STNNM As String
        Dim TEGDT As String
        Dim TEGNO As String
        Dim LINCMA As String
        Dim LINCMB As String
        Dim SYSTBD As TYPE_DB_SYSTBD
    End Structure
    '2019/04/17 ADD E N D

    '--------------------
    '■関数部
    '--------------------


    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'概要：文字列のｺｰﾄﾞ変換
		'引数：varArg,Input,Variant,変換元文字列
		'　　：varCnv,Input,Variant,conversion定数(StrConv 関数参照)
		'説明：Ａｎｓｉ ⇔ ＵｎｉＣｏｄｅに変換した文字列を返す
		
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト varCnv の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト varArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = varArg
#End If
		
	End Function

    Public Function AnsiLenB(ByVal strArg As String) As Integer
        '概要：文字数カウント
        '引数：strArg,Input,String,対象文字列
        '説明：Ａｎｓｉコードのバイトオーダで文字列のﾊﾞｲﾄ数を返す

#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/04/17 CHG START
        'AnsiLenB = LenB(AnsiStrConv(strArg, vbFromUnicode))
        AnsiLenB = LenB(strArg)
        '2019/04/17 CHG E N D
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(strArg)
#End If

    End Function

    '2019/04/17 DEL START
    '   Public Function LenWid(ByVal pm_Characters As Object) As Object
    '	'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '	If IsDbNull(pm_Characters) Then
    '		'        Call AE_SystemError("LenWid のパラメタに", 190)
    '		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '		'UPGRADE_WARNING: オブジェクト LenWid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		LenWid = System.DBNull.Value
    '		Exit Function '--------------------
    '	End If
    '	'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト pm_Characters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '	LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    'Public Function LeftWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    '    'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '    'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '    'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '    LeftWid = StrConv(LeftB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    '   Public Function MidWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer, Optional ByVal pm_LnWid As Object = Nothing) As String
    '	'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
    '	If IsNothing(pm_LnWid) Then
    '		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: MidB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '		MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    '	Else
    '		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '		'UPGRADE_ISSUE: MidB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '		MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
    '	End If
    'End Function
    '2019/04/17 DEL E N D

    '2019/04/17 DEL START
    'Public Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    '	'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: RightB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '	RightWid = StrConv(RightB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
    'End Function
    '2019/04/17 DEL E N D

    Function Get_DBHEAD() As String
		'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function

    '2019/04/19　DEL START 仮
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Init
    '   概要：  プログラム起動時初期処理
    '   引数：  なし
    '   戻値：  なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Sub CF_Init()
    Public Sub CF_Init_URKET53()

        'Dim datDT           As Date
        'Dim strYMD          As String
        'Dim strUNYDT        As String
        Dim intLenCommand As String
        'Dim intRet          As Integer

        '二重起動ﾁｪｯｸ
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '2019/04/17 DEL START
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/04/17 DEL E N D

        '// V2.00↓ ADD
        ' "しばらくお待ちください" ウィンドウ表示
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '2019/04/17 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/04/17 CHG E N D
        '// V2.00↑ ADD

        '---------------------
        ' 起動パラメータ設定
        '---------------------
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        intLenCommand = LenWid(Trim(VB.Command()))
        If CDbl(intLenCommand) < 15 Then
            MsgBox("メニューから実行してください。", MsgBoxStyle.OkOnly, SSS_PrgNm)
            End
            'Call Error_Exit("メニューから実行してください。")
        End If

        SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
        SSS_OPEID.Value = MidWid(VB.Command(), 7, 6)

        '---------------------
        ' SSSWIN.INI テーブル設定
        '---------------------
        strINIDATNM(0) = "USR_PATH"
        strINIDATNM(1) = "DAT_PATH"
        strINIDATNM(2) = "PRG_PATH"
        strINIDATNM(3) = "WRK_PATH"
        strINIDATNM(4) = "IMG_PATH"
        SSS_INICnt = 4
        'Iniファイル読込み
        Call CF_INIT_GETINI()

        '// V2.00↓ ADD
        ' "しばらくお待ちください" ウィンドウ消去
        ICN_ICON.Close()
        '// V2.00↑ ADD

    End Sub
    '2019/04/19 DEL E N D

    Function SSSVal(ByRef INP_Value As Object) As Object
		If IsNumeric(INP_Value) = True Then
			'UPGRADE_WARNING: オブジェクト INP_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSVal = CDec(INP_Value)
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSSVal = 0
		End If
	End Function
	
	Function CNV_DATE(ByRef pdate As String) As String
		
		'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(pdate) = 8 Then
			CNV_DATE = LeftWid(pdate, 4) & "/" & MidWid(pdate, 5, 2) & "/" & RightWid(pdate, 2)
			'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(pdate) = 6 Then 
			CNV_DATE = LeftWid(pdate, 2) & "/" & MidWid(pdate, 3, 2) & "/" & RightWid(pdate, 2)
		Else
			CNV_DATE = ""
		End If
	End Function
	
	Function DeCNV_DATE(ByRef pdate As String) As String
		'
		'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(pdate) = 10 Then
			DeCNV_DATE = LeftWid(pdate, 4) & MidWid(pdate, 6, 2) & RightWid(pdate, 2)
			'UPGRADE_WARNING: オブジェクト LenWid(pdate) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(pdate) = 8 Then 
			DeCNV_DATE = LeftWid(pdate, 2) & MidWid(pdate, 4, 2) & RightWid(pdate, 2)
		Else
			DeCNV_DATE = ""
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_INIT_GETINI
	'   概要：  INIファイル読込み（共通）
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim i, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI 読込み
		'---------------------
		For i = 0 To SSS_INICnt
            rtnPara.Value = ""
            '2019/04/23 CHG START
            'LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(i), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
            LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(i), "", rtnPara.Value, Len(rtnPara.Value), Application.StartupPath & "\SSSWIN.INI")
            '2019/04/23 CHG E N D

            If LENGTH = 0 Then
				MsgBox("SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(i) & "]")
				'            Call Error_Exit("SSSUSR.INI を確認してください。[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(i) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(i), 1) <> "\" And Right(SSS_INIDAT(i), 1) <> ":" Then SSS_INIDAT(i) = SSS_INIDAT(i) & "\"
		Next i
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   引数：  Pin_strDate     : 計算対象日付(８桁の数値Or日付）
	'           Pin_strTOKSMEKB : 締区分
	'           Pin_strTOKSMEDD : 締初期日付（売上）
	'           Pin_strTOKSMECC : 締サイクル（売上）
	'           Pin_strTOKSDWKB : 締め曜日
	'   備考：改造(Saito 2007/02/24)
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function getSmedt(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String) As String
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim Cnt As Short
		Dim i As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intToksmeCc As Short
		Dim intToksmeDD As Short
		Dim intTOKSDWKB As Short
		Dim strSmedt As String
		
		getSmedt = ""
		
		'日付チェック
		If IsDate(pin_strDate) = True Then
			strDate = VB6.Format(pin_strDate, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strDate, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strDate, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		'締区分＝"日"の場合
		If CDbl(Pin_strTOKSMEKB) = 1 Then
			'締初期日付取得
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intToksmeDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'締サイクル取得
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intToksmeCc = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			If intToksmeCc = 1 Then '毎日締め
				getSmedt = DeCNV_DATE(CStr(DateSerial(yy, mm, dd)))
				Exit Function
			End If
			'
			If intToksmeCc <= 0 Or intToksmeCc > 15 Then intToksmeCc = 30
			Cnt = Int(30 / intToksmeCc) '締回数／月
			setidx = False
			For i = 0 To Cnt - 1
				smeday(i) = intToksmeDD + intToksmeCc * i
				If smeday(i) > 27 Then smeday(i) = 99
				If dd <= smeday(i) And setidx = False Then
					'idx = I + Pin_intCHTNKB '該当日付の締日配列添字
					setidx = True
				End If
			Next i
			If setidx = False Then idx = Cnt '+ Pin_intCHTNKB
			addMM = Int(idx / Cnt)
			idx = idx Mod Cnt
			If idx < 0 Then idx = idx + Cnt
			'
			If smeday(idx) = 99 Then
				strSmedt = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				strSmedt = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
			End If
			
		Else
			'締曜日取得
			If IsNumeric(Pin_strTOKSDWKB) = True Then
				intTOKSDWKB = CShort(Pin_strTOKSDWKB)
			Else
				Exit Function
			End If
			
			'締日区分＝"曜日"の場合
			If WeekDay(CDate(strDate)) > intTOKSDWKB Then
				strSmedt = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB)))
			Else
				strSmedt = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate)))))
			End If
		End If
		
		getSmedt = DeCNV_DATE(strSmedt)
		
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function GET_MEIMTA_KANKOZ
	'   概要： 名称マスタ存在チェック
	'   引数： pin_MEICDA   : 名称キー
	'   戻値： 0:正常終了 9:異常終了 8:削除済みレコード
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_MEIMTA_KANKOZ(ByVal pin_MEICDA As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strMEICDA As String
		
		On Error GoTo ERR_GET_MEIMTA_KANKOZ
		
		GET_MEIMTA_KANKOZ = 9
		
		strMEICDA = Trim(pin_MEICDA) & Space(10)
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From MEIMTA"
		strSql = strSql & vbCrLf & " Where KEYCD    = '062'"
		strSql = strSql & vbCrLf & "   And MEICDA   = " & "'" & Mid(Trim(strMEICDA) & Space(20), 2, 9) & "'"
		strSql = strSql & vbCrLf & "   And MEICDB   = " & "'" & Left(Trim(strMEICDA) & Space(5), 1) & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        ''// V2.00↓ UPD
        ''        GET_MEIMTA_KANKOZ = 0
        'Select Case CF_Ora_GetDyn(Usr_Ody, "DATKB", "")

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            Select Case DB_NullReplace(dt.Rows(0)("DATKB"), "")
                '2019/04/23 CHG E N D
                Case "1"
                    GET_MEIMTA_KANKOZ = 0
                Case "9"
                    GET_MEIMTA_KANKOZ = 8
            End Select
            '// V2.00↑ UPD

            GoTo END_GET_MEIMTA_KANKOZ
        End If

END_GET_MEIMTA_KANKOZ:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
ERR_GET_MEIMTA_KANKOZ: 
		GoTo END_GET_MEIMTA_KANKOZ
		
	End Function

    '2019/04/26 DEL START
    '   '**************************************************************************************************
    '   'プロシジャ名   ：Get_Authority
    '   '処理概要       ：プログラムの実行権限を取得する
    '   '                 CrystalReportのプレビュー画面の印刷ボタンをユーザ権限によって制御する
    '   '引数   １：ec_DATE(担当者の適用日を判断する日付)
    '   '       ２：ec_CRW(CrystalReportコントロール名) オプション
    '   '戻値   1：権限マスタにデータ有り
    '   '       9：権限マスタにデータなし
    '   '**************************************************************************************************
    '   Public Function Get_Authority(ByRef ec_DATE As String, Optional ByRef ec_CRW As Object = Nothing) As String

    '	'変数宣言
    '	Dim strSql As String
    '	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '	Dim Usr_Ody As U_Ody

    '	'初期値は全権限なし
    '	gs_UPDAUTH = "9" '更新権限
    '	gs_PRTAUTH = "9" '印刷権限
    '	gs_FILEAUTH = "9" 'ファイル出力権限
    '	gs_SALTAUTH = "9" '販売単価変更権限
    '	gs_HDNTAUTH = "9" '発注単価変更権限
    '	gs_SAPMAUTH = "9" '販売計画年初計画修正権限

    '	'ユーザIDから印刷権限を取得する
    '	strSql = "Select"
    '	strSql = strSql & " K.UPDAUTH"
    '	strSql = strSql & ",K.PRTAUTH"
    '	strSql = strSql & ",K.FILEAUTH"
    '	strSql = strSql & ",K.SALTAUTH"
    '	strSql = strSql & ",K.HDNTAUTH"
    '	strSql = strSql & ",K.SAPMAUTH"
    '	strSql = strSql & " From KNGMTB K"
    '	strSql = strSql & "     ,TANMTA T"
    '	strSql = strSql & " Where K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END)"
    '	strSql = strSql & "   And T.TANCD   = " & "'" & Trim(SSS_OPEID.Value) & "'"
    '	strSql = strSql & "   And K.PGID    = " & "'" & SSS_PrgId & "'"
    '	strSql = strSql & "   And K.DATKB   = '1'"
    '	strSql = strSql & "   And T.DATKB   = '1'"

    '       '2019/04/23 CHG START
    '       'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '       'If CF_Ora_EOF(Usr_Ody) = True Then
    '       '	'取得データなしの場合は権限なしとみなす。
    '       '	Get_Authority = CStr(9)
    '       'Else
    '       '	Do While CF_Ora_EOF(Usr_Ody) = False

    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '更新権限
    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '印刷権限
    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") 'ファイル出力権限
    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '販売単価変更権限
    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '発注単価変更権限
    '       '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '販売計画年初計画修正権限

    '       '		'次レコード
    '       '		'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '		Usr_Ody.Obj_Ody.MoveNext()
    '       '	Loop 
    '       '	Get_Authority = CStr(1)
    '       'End If
    '       Dim dt As DataTable = DB_GetTable(strSql)

    '       If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '           '取得データなしの場合は権限なしとみなす。
    '           Get_Authority = CStr(9)
    '       Else
    '           For i As Integer = 0 To dt.Rows.Count - 1
    '               gs_UPDAUTH = DB_NullReplace(dt.Rows(i)("UPDAUTH"), "") '更新権限
    '               gs_PRTAUTH = DB_NullReplace(dt.Rows(i)("PRTAUTH"), "") '印刷権限
    '               gs_FILEAUTH = DB_NullReplace(dt.Rows(i)("FILEAUTH"), "") 'ファイル出力権限
    '               gs_SALTAUTH = DB_NullReplace(dt.Rows(i)("SALTAUTH"), "") '販売単価変更権限
    '               gs_HDNTAUTH = DB_NullReplace(dt.Rows(i)("HDNTAUTH"), "") '発注単価変更権限
    '               gs_SAPMAUTH = DB_NullReplace(dt.Rows(i)("SAPMAUTH"), "") '販売計画年初計画修正権限
    '           Next
    '       End If
    '       '2019/04/23 CHG E N D

    '       If ec_CRW Is Nothing Then
    '	Else
    '		If gs_PRTAUTH = "1" Then
    '			'印刷権限がある場合
    '			'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			ec_CRW.WindowShowPrintBtn = True '印刷ボタン
    '		Else
    '			'印刷権限が無い場合
    '			'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			ec_CRW.WindowShowPrintBtn = False '印刷ボタン
    '		End If
    '		If gs_FILEAUTH = "1" Then
    '			'エクスポート権限がある場合
    '			'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			ec_CRW.WindowShowExportBtn = True 'エクスポートボタン
    '		Else
    '			'エクスポート権限が無い場合
    '			'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			ec_CRW.WindowShowExportBtn = False 'エクスポートボタン
    '		End If
    '	End If

    'End Function
    '2019/04/26 DEL E N D

    Function Get_Acedt(ByVal wdate As String) As String
		' 該当経理締日付
		
		wdate = CNV_DATE(wdate)
		'    If Not CHECK_DATE(wdate) Then
		'        Call Error_Exit("日付エラー(Get_Acedt): " & wdate)
		'    End If
		If DB_SYSTBA.SMADD > "27" Then
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, 0))
		ElseIf Right(wdate, 2) <= DB_SYSTBA.SMADD Then 
			Get_Acedt = Left(wdate, 8) & DB_SYSTBA.SMADD
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYSTBA.SMADD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Get_Acedt = CStr(DateSerial(Year(CDate(wdate)), Month(CDate(wdate)) + 1, SSSVal(DB_SYSTBA.SMADD)))
		End If
	End Function
	
	'// V2.04↓ UPD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_TANMTA_KEIBMNCD
	'   概要：  経理部門コードを取得
	'   引数：　pot_TANCD       : 担当者コード
	'       ：　pot_KEIBMNCD    : 経理部門コード
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_TANMTA_KEIBMNCD(ByRef pot_TANCD As String, ByRef pot_KEIBMNCD As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		' === 20081015 === ADD    S - RISE)Miyajima 連絡票№664
		Dim strKEIBMNCD As String '所属部門コード
		Dim strOLDBMNCD As String '旧所属部門コード
		Dim strTANTKDT As String '適用日
		Dim strZMBMNCD As String '会計部門コード
		' === 20081015 === ADD    E - RISE)Miyajima
		
		On Error GoTo ERR_GET_TANMTA_KEIBMNCD
		
		GET_TANMTA_KEIBMNCD = 9
		
		' === 20081015 === UPDATE S - RISE)Miyajima 連絡票№664
		'    strSql = ""
		'    strSql = strSql & "Select KEIBMNCD From TANMTA"
		'    strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"
		'
		'    'DBアクセス
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		'
		'    If CF_Ora_EOF(Usr_Ody) = False Then
		'        pot_KEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "KEIBMNCD", "")
		'        GET_TANMTA_KEIBMNCD = 0
		'
		'        GoTo END_GET_TANMTA_KEIBMNCD
		'    End If
		
		'担当者Ｍ
		strSql = ""
		strSql = strSql & "Select TANBMNCD,OLDBMNCD,TANTKDT From TANMTA"
		strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strKEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strOLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strTANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")
        'Else
        '	GoTo END_GET_TANMTA_KEIBMNCD
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strKEIBMNCD = DB_NullReplace(dt.Rows(0)("TANBMNCD"), "")
            strOLDBMNCD = DB_NullReplace(dt.Rows(0)("OLDBMNCD"), "")
            strTANTKDT = DB_NullReplace(dt.Rows(0)("TANTKDT"), "")
        Else
            GoTo END_GET_TANMTA_KEIBMNCD
        End If
        '2019/04/23 CHG E N D

        '部門Ｍ
        strSql = ""
		strSql = strSql & "Select ZMBMNCD From BMNMTA"
		'UPGRADE_WARNING: オブジェクト SSSVal(strTANTKDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(gstrKesidt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(gstrKesidt.Value) >= SSSVal(strTANTKDT) Then
			strSql = strSql & " Where BMNCD = " & "'" & strKEIBMNCD & "'"
		Else
			strSql = strSql & " Where BMNCD = " & "'" & strOLDBMNCD & "'"
		End If
		strSql = strSql & "   and " & "'" & gstrKesidt.Value & "'" & " BETWEEN STTTKDT AND ENDTKDT "

        'DBアクセス
        '2019/04/23 CHG START
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")
        'Else
        '	GoTo END_GET_TANMTA_KEIBMNCD
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "")
        Else
            GoTo END_GET_TANMTA_KEIBMNCD
        End If
        '2019/04/23 CHG E N D

        '経理部門コードを引数へ設定する
        pot_KEIBMNCD = strZMBMNCD
		
		' === 20081015 === UPDATE E - RISE)Miyajima
		
		GET_TANMTA_KEIBMNCD = 0
		
END_GET_TANMTA_KEIBMNCD:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
ERR_GET_TANMTA_KEIBMNCD: 
		GoTo END_GET_TANMTA_KEIBMNCD
		
	End Function
	'// V2.04↑ UPD
	
	Function SSS_WEEKNM(ByVal idx As Short) As String
		' 曜日名を返す。
		Select Case idx
			Case 1
				SSS_WEEKNM = "日曜日"
			Case 2
				SSS_WEEKNM = "月曜日"
			Case 3
				SSS_WEEKNM = "火曜日"
			Case 4
				SSS_WEEKNM = "水曜日"
			Case 5
				SSS_WEEKNM = "木曜日"
			Case 6
				SSS_WEEKNM = "金曜日"
			Case 7
				SSS_WEEKNM = "土曜日"
			Case Else
				SSS_WEEKNM = ""
		End Select
	End Function
	
	'ログファイルの書き出し
	'若干改造
	Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
		Dim errcnt, Fno, rtn As Short
		Dim wbuf As String
        '    '
        '    Call ResetDBSTAT(DBN_SYSTBE)
        '    '
        'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
        '2019/04/17 DEL START
        'DB_SYSTBE = LSet(DB_CLRREC)
        '2019/04/17 DEL E N D
        DB_SYSTBE.PRGID = SSS_PrgId
		DB_SYSTBE.LOGNM = LogMsg
		DB_SYSTBE.OPEID = SSS_OPEID.Value
		DB_SYSTBE.CLTID = SSS_CLTID.Value
		DB_SYSTBE.WRTTM = VB6.Format(Now, "hhnnss")
		DB_SYSTBE.WRTDT = VB6.Format(Now, "YYYYMMDD")
		
		errcnt = 0
		Fno = FreeFile
		On Error Resume Next
		'ディレクトリ存在チェック
		'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		wbuf = Dir(SSS_INIDAT(1), 16)
		If wbuf = "" Then
			Call MsgBox("SSSWIN.INI の DAT_PATH の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
			'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
			'''Call SSS_CLOSE
			rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
			End
		End If
		Err.Clear()
		On Error GoTo ErrorLogFile
        'FileOpen(Fno, SSS_INIDAT(1) & SSS_PrgId & ".DTA", OpenMode.Append, OpenAccess.Write, OpenShare.LockWrite)
        ''    Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
        'On Error GoTo 0
        ''    Print #Fno, SSS_PrgId & LogMsg & SSS_OPEID & SSS_CLTID & Format$(Now, "hhnnss") & Format$(Now, "YYYYMMDD")
        'PrintLine(Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT)
        'FileClose(Fno)
        Exit Sub
ErrorLogFile: 
		errcnt = errcnt + 1
		If errcnt > SSS_ReTryCnt Then
			If MsgBox("履歴ファイルロックエラー !" & Chr(13) & "中止しても宜しいですか？", 20) = 6 Then
				'''Call SSS_CLOSE
				rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
				End
			Else
				errcnt = 0
			End If
		End If
		System.Windows.Forms.Application.DoEvents()
		Resume 
	End Sub
	
	'Sub ResetBuf(ByVal Fno As Integer)  'Generated.
	'End Sub
	'
	
	'=======================================================Saito作成分=======================================================
	
	
	'ｸﾞﾛｰﾊﾞﾙ変数の初期化
	Public Sub initVal()
		gstrKesidt.Value = Space(8)
		'// V2.00↓ UPD
		''    gstrKaidt = Space(8)
		gstrKaidt_Fr.Value = Space(8)
		gstrKaidt_To.Value = Space(8)
		gstrTokseicd.Value = Space(5)
		'// V2.00↑ UPD
		gstrFridt.Value = Space(8)

        '20190621 CHG START
        'With DB_TOKMTA
        With DB_TOKMTA2
            '20190621 CHG END

            .TOKSEICD = Space(5)
            .TOKNMA = Space(60)
            .TOKSMEDT = Space(8)
            .SHAKB = Space(1)
            .SHAKBNM = Space(10)
            .TOKSMEKB = Space(1)
            .TOKSMEDD = Space(2)
            .TOKSMECC = Space(2)
            .TOKSDWKB = Space(1)
            .TOKKESDD = Space(2)
            .TOKKESCC = Space(2)
            .HYTOKKESDD = Space(2)
            .TOKKDWKB = Space(1)
            .KESISMEDT = Space(8)
            .FRNKB = Space(1)
            .TUKKB = Space(3)
            .TOKJUNKB = Space(1)
            .TOKMSTKB = Space(1)
            .TKNRPSKB = Space(1)
            .TKNZRNKB = Space(1)
            .TOKZEIKB = Space(1)
            .TOKZCLKB = Space(1)
            .TOKRPSKB = Space(1)
            .TOKZRNKB = Space(1)
            .TOKNMMKB = Space(1)
        End With
    End Sub
	
	'運用日日付を取得する
	Public Function getUnydt() As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT unydt FROM unymta"
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'getUnydt = CF_Ora_GetDyn(Usr_Ody, "unydt", "")
        Dim dt As DataTable = DB_GetTable(strSql)
        getUnydt = DB_NullReplace(dt.Rows(0)("unydt"), "")
        '2019/04/23 CHG E N D

        GV_UNYDate = getUnydt '2007.03.05

        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D
    End Function

    'SYSTBA情報を取得する
    Public Sub getSYSTBA()
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT * FROM systba"
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_SYSTBA.SMAUPDDT = CF_Ora_GetDyn(Usr_Ody, "smaupddt", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_SYSTBA.MONUPDDT = CF_Ora_GetDyn(Usr_Ody, "monupddt", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_SYSTBA.SMADD = CF_Ora_GetDyn(Usr_Ody, "smadd", "")
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            DB_SYSTBA.SMAUPDDT = DB_NullReplace(dt.Rows(0)("smaupddt"), "")
            DB_SYSTBA.MONUPDDT = DB_NullReplace(dt.Rows(0)("monupddt"), "")
            DB_SYSTBA.SMADD = DB_NullReplace(dt.Rows(0)("smadd"), "")
        End If
        '2019/04/23 CHG E N D
    End Sub
	
	'担当者名を取得する
	Public Function getTannm(ByRef strTancd As String) As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String

        strSql = "SELECT tannm FROM tanmta" & " WHERE tancd = '" & strTancd & "'"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'getTannm = CF_Ora_GetDyn(Usr_Ody, "tannm", "")

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)
        getTannm = DB_NullReplace(dt.Rows(0)("tannm"), "")
        '2019/04/23 CHG E N D
    End Function
	
	'現在日付、時刻をセットする
	Public Sub setSysdate(ByRef strWRTTM As String, ByRef strWRTDT As String)
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		strSql = "SELECT TO_CHAR(SYSDATE, 'HH24MISS') wrttm, " & "TO_CHAR(SYSDATE, 'YYYYMMDD') wrtdt " & "FROM dual"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strWRTTM = CF_Ora_GetDyn(Usr_Ody, "wrttm", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strWRTDT = CF_Ora_GetDyn(Usr_Ody, "wrtdt", "")
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strWRTTM = DB_NullReplace(dt.Rows(0)("wrttm"), "")
            strWRTDT = DB_NullReplace(dt.Rows(0)("wrtdt"), "")
        End If
        '2019/04/23 CHG E N D
    End Sub
	
	'請求先名を取得する(同時に支払条件、請求締日、消込日における締日を取得)
	'0:国内取引先
	'1:海外取引先
	'8:請求先ではない得意先
	'9:該当データなし
	Public Function getTokseinm(ByRef strKesidt As String, ByVal strTokseicd As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		'支払条件の名称宣言
		Dim SHAKB_NAME() As Object
		
		getTokseinm = 9
		
		'UPGRADE_WARNING: Array に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		SHAKB_NAME = New Object(){"", "振込", "手形", "振込または手形", "振込手形併用", "期日振込", "ﾌｧｸﾀﾘﾝｸﾞ"}
		
		strSql = "SELECT * FROM tokmta " & "WHERE tokcd = '" & strTokseicd & "' " & "AND tokcd = tokseicd"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	With DB_TOKMTA
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKNMA = CF_Ora_GetDyn(Usr_Ody, "toknma", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKRN = CF_Ora_GetDyn(Usr_Ody, "tokrn", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "toksmedt", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SHAKB = CF_Ora_GetDyn(Usr_Ody, "shakb", "")
        '		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト SHAKB_NAME(SSSVal()) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.SHAKBNM = SHAKB_NAME(SSSVal(CF_Ora_GetDyn(Usr_Ody, "shakb", "")))

        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "toksmekb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "toksmedd", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "toksmecc", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "toksdwkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "tokkescc", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "tokkesdd", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "tokkdwkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.FRNKB = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TUKKB = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "tokjunkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "tokmstkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "tknrpskb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "tknzrnkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "tokzeikb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "tokzclkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "tokrpskb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "tokzrnkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "toknmmkb", "")
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		.TANCD = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

        '		If .TOKSMEKB = "1" Then
        '			'日締め
        '			'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTA.TOKSMEDD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			If SSSVal(.TOKSMEDD) > 27 Then
        '				.HYTOKKESDD = "末日"
        '			Else
        '				.HYTOKKESDD = .TOKSMEDD & "日"
        '			End If
        '		Else
        '			'週締め
        '			.HYTOKKESDD = "週締"
        '		End If

        '		'消込日における締日を取得
        '		.KESISMEDT = getSmedt(strKesidt, .TOKSMEKB, .TOKSMEDD, .TOKSMECC, .TOKSDWKB)

        '		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		getTokseinm = SSSVal(.FRNKB)
        '	End With
        'Else
        '	'請求先ではない得意先として存在すれば8を返す 2007/02/28 Add
        '	strSql = "SELECT * FROM tokmta WHERE tokcd = '" & strTokseicd & "'"
        '	Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        '	If CF_Ora_EOF(Usr_Ody) = True Then
        '		getTokseinm = 9
        '	Else
        '		getTokseinm = 8
        '	End If
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            '20190621 CHG START
            'With DB_TOKMTA
            With DB_TOKMTA2
                '20190621 CHG END

                .TOKSEICD = DB_NullReplace(dt.Rows(0)("tokseicd"), "")
                .TOKNMA = DB_NullReplace(dt.Rows(0)("toknma"), "")
                .TOKRN = DB_NullReplace(dt.Rows(0)("tokrn"), "")
                .TOKSMEDT = DB_NullReplace(dt.Rows(0)("toksmedt"), "")
                .SHAKB = DB_NullReplace(dt.Rows(0)("shakb"), "")
                .SHAKBNM = SHAKB_NAME(SSSVal(DB_NullReplace(dt.Rows(0)("shakb"), "")))
                .TOKSMEKB = DB_NullReplace(dt.Rows(0)("toksmekb"), "")
                .TOKSMEDD = DB_NullReplace(dt.Rows(0)("toksmedd"), "")
                .TOKSMECC = DB_NullReplace(dt.Rows(0)("toksmecc"), "")
                .TOKSDWKB = DB_NullReplace(dt.Rows(0)("toksdwkb"), "")
                .TOKKESCC = DB_NullReplace(dt.Rows(0)("tokkescc"), "")
                .TOKKESDD = DB_NullReplace(dt.Rows(0)("tokkesdd"), "")
                .TOKKDWKB = DB_NullReplace(dt.Rows(0)("tokkdwkb"), "")
                .FRNKB = DB_NullReplace(dt.Rows(0)("frnkb"), "")
                .TUKKB = DB_NullReplace(dt.Rows(0)("tukkb"), "")
                .TOKJUNKB = DB_NullReplace(dt.Rows(0)("tokjunkb"), "")
                .TOKMSTKB = DB_NullReplace(dt.Rows(0)("tokmstkb"), "")
                .TKNRPSKB = DB_NullReplace(dt.Rows(0)("tknrpskb"), "")
                .TKNZRNKB = DB_NullReplace(dt.Rows(0)("tknzrnkb"), "")
                .TOKZEIKB = DB_NullReplace(dt.Rows(0)("tokzeikb"), "")
                .TOKZCLKB = DB_NullReplace(dt.Rows(0)("tokzclkb"), "")
                .TOKRPSKB = DB_NullReplace(dt.Rows(0)("tokrpskb"), "")
                .TOKZRNKB = DB_NullReplace(dt.Rows(0)("tokzrnkb"), "")
                .TOKNMMKB = DB_NullReplace(dt.Rows(0)("toknmmkb"), "")
                .TANCD = DB_NullReplace(dt.Rows(0)("tancd"), "")

                If .TOKSMEKB = "1" Then
                    '日締め
                    If SSSVal(.TOKSMEDD) > 27 Then
                        .HYTOKKESDD = "末日"
                    Else
                        .HYTOKKESDD = .TOKSMEDD & "日"
                    End If
                Else
                    '週締め
                    .HYTOKKESDD = "週締"
                End If

                '消込日における締日を取得
                .KESISMEDT = getSmedt(strKesidt, .TOKSMEKB, .TOKSMEDD, .TOKSMECC, .TOKSDWKB)

                getTokseinm = SSSVal(.FRNKB)
            End With
        Else
            '請求先ではない得意先として存在すれば8を返す 2007/02/28 Add
            strSql = "SELECT * FROM tokmta WHERE tokcd = '" & strTokseicd & "'"

            dt = DB_GetTable(strSql)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                getTokseinm = 9
            Else
                getTokseinm = 8
            End If
        End If
        '2019/04/23 CHG E N D
    End Function
	
	'引数に含まれる全角項目を削除し、その値を返す
	Public Function delZenkaku(ByRef strText As String) As String
		Dim tmp1 As String
		Dim tmp2 As String
		Dim i As Integer
		
		If strText = "" Then Exit Function
		
		tmp2 = ""
		
		For i = 1 To Len(strText)
			tmp1 = Mid(strText, i, 1)
			
			'半角以外の文字は無効にする
			If Len(tmp1) = AnsiLenB(tmp1) Then
			Else
				tmp1 = Space(1)
			End If
			
			tmp2 = tmp2 & tmp1
		Next 
		
		delZenkaku = tmp2
	End Function
	
	'メッセージボックスの表示
	Public Function showMsg(ByRef strMsgkb As String, ByRef strMsgnm As String, ByRef strMsgsq As String) As MsgBoxResult
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strMsgcm As String
		Dim intMsgkb As Short
		
		strSql = "SELECT * FROM systbh"
		strSql = strSql & " WHERE msgkb = '" & Trim(strMsgkb) & "'"
		strSql = strSql & "   AND msgnm = '" & Trim(strMsgnm) & "'"
		strSql = strSql & "   AND msgsq = '" & Trim(strMsgsq) & "'"

        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strMsgcm = CF_Ora_GetDyn(Usr_Ody, "msgcm", "")
        'intMsgkb = Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "btnkb", "")))
        'intMsgkb = intMsgkb + Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "btnon", "")))
        'intMsgkb = intMsgkb + Int(CDbl(CF_Ora_GetDyn(Usr_Ody, "icnkb", "")))
        Dim dt As DataTable = DB_GetTable(strSql)

        strMsgcm = DB_NullReplace(dt.Rows(0)("msgcm"), "")
        intMsgkb = Int(CDbl(DB_NullReplace(dt.Rows(0)("btnkb"), "")))
        intMsgkb = intMsgkb + Int(CDbl(DB_NullReplace(dt.Rows(0)("btnon"), "")))
        intMsgkb = intMsgkb + Int(CDbl(DB_NullReplace(dt.Rows(0)("icnkb"), "")))
        '2019/04/23 CHG E N D

        showMsg = MsgBox(Trim(strMsgcm), intMsgkb, Trim(SSS_PrgNm))
	End Function
	
	'// V2.00↓ DEL
	''
	'''明細部表示データ取得SQLを作成する .
	''Public Function getSQLforBody(strSmaupddt As String, _
	'''                              strTokseicd As String, _
	'''                              strKaidt As String, _
	'''                              strKesikb As String, _
	'''                     Optional intSortkb As Integer = 0) As String
	''
	''    Dim strSql  As String
	'''CHG START FKS)INABA 2007/07/26 ********************************************************************************************************
	'''***chg-S-tom***
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3') ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	'''2007/12/05 FKS)minamoto CHG START
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''         & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	''
	'''2008/1/10 FKS)ichihara CHG START
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	''''          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	''''2007/12/05 FKS)minamoto CHG END
	''
	'''XX 2008/07/08 CHG START FKS)NAKATA
	'''XX   取得項目に「UDNTRA.UDNNO」を追加
	'''XX    strSql = _
	''''XX      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''XX          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''XX          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''XX          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''XX          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''XX          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''XX          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''XX          & ",ur.RECNO,ur.AKAKROKB, ur.KESIKB, ur.HENRSNCD, ur.HENSTTCD " _
	''''XX          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''XX         & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''XX          & ",jr.datno jdndatno " & vbCrLf _
	''''XX          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	''''XX          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	''''XX          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	''''XX      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	''''XX          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''XX          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	''''XX             & "WHERE datkb = '1' AND (nyudt <= "
	''    strSql = _
	'''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	'''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	'''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	'''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	'''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	'''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	'''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	'''          & ",ur.RECNO,ur.AKAKROKB, ur.KESIKB, ur.HENRSNCD, ur.HENSTTCD " _
	'''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	'''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	'''          & "  ,ur.udnno " _
	'''          & ",jr.datno jdndatno " & vbCrLf _
	'''          & ",DECODE(NVL(TRIM(nr2.TEGDT),' '),' ','',TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	'''          & ",ur.wrtdt udnwrtdt, ur.wrttm udnwrttm, ur.uwrtdt udnuwrtdt, ur.uwrttm udnuwrttm  " & vbCrLf _
	'''          & ",jr.wrtdt jdnwrtdt, jr.wrttm jdnwrttm, jr.uwrtdt jdnuwrtdt, jr.uwrttm jdnuwrttm  " & vbCrLf _
	'''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1' AND NYUKB <> '3' AND IRISU <> 9) ur " _
	'''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	'''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	'''             & "WHERE datkb = '1' AND (nyudt <= "
	''
	'''2007/12/05 FKS)minamoto CHG END
	'''2008/1/10 FKS)ichihara CHG END
	'''XX 2008/07/28 CHG E.N.D FKS)NAKATA
	''
	'''***chg-S-tom***
	'''          & ",DECODE(nr2.TEGDT,' ',' ', TO_DATE(nr2.TEGDT, 'YYYY/MM/DD') )TEGDT  " & vbCrLf _
	'''
	'''    strSql = _
	''''      "SELECT uh.nxtkb, TO_DATE(ur.udndt, 'YYYY/MM/DD') hy_udndt " _
	''''          & ",TRIM(ur.jdnno) || SUBSTR(ur.jdnlinno, 2, 2) hy_jdnno " _
	''''          & ",TO_DATE(ur.kesdt, 'YYYY/MM/DD') hy_kaidt, ur.tokjdnno, uh.tannm " _
	''''          & ",ur.urikn, ur.uzekn, ur.urikn + ur.uzekn komikn " _
	''''          & ",NVL(nr1.jkesikn, 0) + NVL(nr2.jkesikn, 0) kesikn " _
	''''          & ",NVL(nr1.jkesikn, 0) bfkesikn, NVL(nr2.jkesikn, 0) afkesikn " _
	''''          & ",ur.jdnno, ur.jdnlinno, ur.udndt, ur.kesdt " _
	''''          & ",ur.tokcd, ur.tokseicd, uh.tancd, jr.jdndt, uh.tukkb " _
	''''          & ",ur.invno, ur.furikn, uh.frnkb, ur.datno, ur.linno, uh.maeukkb " _
	''''          & ",jr.datno jdndatno " & vbCrLf _
	''''      & "FROM (SELECT * FROM udntra WHERE datkb = '1' AND denkb = '1') ur " _
	''''          & ",udntha uh ,( SELECT UDNNO,LINNO,MAX(WRTFSTDT || WRTFSTTM) as DT FROM UDNTRA WHERE DENKB = '1' GROUP BY UDNNO,LINNO ) B" _
	''''          & ",(SELECT udndatno, udnlinno, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt <= "
	'''CHG  END  FKS)INABA 2007/07/26 ********************************************************************************************************
	'''CHG START FKS)INABA 2007/07/26 ********************************************************************************************************
	''
	''    strSql = strSql & "'" & strSmaupddt & "' OR nyukb = '3') " _
	'''             & "GROUP BY udndatno, udnlinno) nr1 " _
	'''          & ",(SELECT udndatno, udnlinno, MAX(TEGDT) TEGDT, SUM(jkesikn) jkesikn FROM nkstra " _
	'''             & "WHERE datkb = '1' AND (nyudt > '" & strSmaupddt & "' AND nyukb <> '3') " _
	'''             & "GROUP BY udndatno, udnlinno) nr2 " & vbCrLf _
	'''          & ",(SELECT * FROM jdntra WHERE datno in " _
	'''             & "(SELECT MAX(datno) FROM jdntra WHERE tokseicd = '" & strTokseicd & "' " _
	'''               & "GROUP BY jdnno)) jr " & vbCrLf
	'''    strSql = strSql & "'" & strSmaupddt & "' OR nyukb = '3') " _
	''''             & "GROUP BY udndatno, udnlinno) nr1 " _
	''''          & ",(SELECT udndatno, udnlinno, SUM(jkesikn) jkesikn FROM nkstra " _
	''''             & "WHERE datkb = '1' AND (nyudt > '" & strSmaupddt & "' AND nyukb <> '3') " _
	''''             & "GROUP BY udndatno, udnlinno) nr2 " & vbCrLf _
	''''          & ",(SELECT * FROM jdntra WHERE datno in " _
	''''             & "(SELECT MAX(datno) FROM jdntra WHERE tokseicd = '" & strTokseicd & "' " _
	''''               & "GROUP BY jdnno)) jr " & vbCrLf
	'''CHG  END  FKS)INABA 2007/07/26 ********************************************************************************************************
	'''CHG START FKS)INABA 2007/07/23 ******************************************************************
	'''抽出条件を回収予定日から売上日に変更
	''    strSql = strSql _
	'''     & "WHERE ur.tokseicd = '" & strTokseicd & "' " _
	'''       & "AND ((ur.urikn >= 0 AND ur.UDNDT <= '" & strKaidt & "') OR ur.urikn < 0)" _
	'''       & "AND ((ur.DKBID = '01' AND ur.AKAKROKB = '1') OR (ur.DKBID <> '01' AND ur.AKAKROKB = '9')) " _
	'''       & "AND ur.WRTFSTDT || ur.WRTFSTTM = B.DT AND ur.UDNNO = B.UDNNO AND ur.LINNO = B.LINNO " _
	'''       & "AND ur.datno = uh.datno AND uh.maeukkb = '1' "
	'''    strSql = strSql _
	''''     & "WHERE ur.tokseicd = '" & strTokseicd & "' " _
	''''       & "AND ((ur.urikn >= 0 AND ur.kesdt <= '" & strKaidt & "') OR ur.urikn < 0)" _
	''''       & "AND ((ur.DKBID = '01' AND ur.AKAKROKB = '1') OR (ur.DKBID <> '01' AND ur.AKAKROKB = '9')) " _
	''''       & "AND ur.WRTFSTDT || ur.WRTFSTTM = B.DT AND ur.UDNNO = B.UDNNO AND ur.LINNO = B.LINNO " _
	''''       & "AND ur.datno = uh.datno AND uh.maeukkb = '1' "
	'''CHG  END  FKS)INABA 2007/07/23 ******************************************************************
	''
	''
	''    '消込済みデータを表示する時は、締日以降の消込日付の明細のみ表示
	''    If strKesikb = 9 Then
	''        'strSql = strSql & "AND (ur.kesikb = '9' OR (ur.kesikb = '1' AND ur.nyudt > '" & strSmaupddt & "')) "
	''        strSql = strSql & "AND (ur.kesikb <> '1' OR (ur.kesikb = '1' AND ur.nyudt > '" & strSmaupddt & "')) "
	''    Else
	''        'strSql = strSql & "AND ur.kesikb = '9' "
	''        strSql = strSql & "AND ur.kesikb <> '1' "
	''    End If
	''
	''    strSql = strSql _
	'''       & "AND TRIM(jr.jdndeldt) IS NULL " _
	'''       & "AND ur.jdnno = jr.jdnno AND ur.jdnlinno = jr.linno " _
	'''       & "AND ur.datno = nr1.udndatno(+) AND ur.linno = nr1.udnlinno(+) " _
	'''       & "AND ur.datno = nr2.udndatno(+) AND ur.linno = nr2.udnlinno(+) "
	''
	''    'ｿｰﾄ順の変更
	'''CHG START FKS)INABA 2007/07/23 *******************************************************************************
	''    Select Case intSortkb
	''        Case 0
	''            strSql = strSql & "ORDER BY udndt, kesdt,  jdnno, jdnlinno, datno"
	''        Case 1
	'''2008/07/30 CHG START FKS)NAKATA
	'''XX            strSql = strSql & "ORDER BY jdnno, jdnlinno, datno, udndt, kesdt"
	''           strSql = strSql & "ORDER BY jdnno, jdnlinno, udndt, kesdt, datno"
	'''2008/07/30 CHG E.N.D FKS)NAKATA
	''        Case 2
	''            strSql = strSql & "ORDER BY TOKJDNNO, udndt, kesdt, jdnno, jdnlinno, datno"
	''    End Select
	'''    If intSortkb <> 0 Then
	'''        strSql = strSql & "ORDER BY kesdt, udndt, jdnno, jdnlinno, datno"
	'''    Else
	'''        strSql = strSql & "ORDER BY jdnno, jdnlinno, datno, kesdt, udndt"
	'''    End If
	'''CHG  END  FKS)INABA 2007/07/23 *******************************************************************************
	''
	''    getSQLforBody = strSql
	''    Debug.Print strSql
	''End Function
	'// V2.00↑ UPD
	
	'回収予定日を取得する
	'スラッシュなしで返す
	Public Function getKesdt(ByRef strToksmekb As String, ByRef strToksmedt As String, ByRef strToksmecc As String, ByRef strToksdwkb As String, ByRef strTokkescc As String, ByRef strTokkesdd As String, ByRef strTokkdwkb As String, ByVal strDate As String) As String
		
		Dim tmp As Short
		
		'スラッシュつきに変換
		strDate = CNV_DATE(strDate)
		'日締め
		If strToksmekb = "1" Then
			'UPGRADE_WARNING: オブジェクト SSSVal(strToksmecc) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(strToksmecc) = 1 Then
				getKesdt = DeCNV_DATE(strDate)
				Exit Function
			End If
			
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			tmp = SSSVal(strTokkesdd)
			If tmp = 99 Then tmp = 30
			If tmp > 27 Then
				'UPGRADE_WARNING: オブジェクト SSSVal(strTokkescc) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)) + SSSVal(strTokkescc) + 1, 0)))
			Else
				'UPGRADE_WARNING: オブジェクト SSSVal(strTokkescc) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)) + SSSVal(strTokkescc), tmp)))
			End If
			'週締め
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(strToksdwkb) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(strTokkdwkb) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(strTokkescc) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			getKesdt = DeCNV_DATE(CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + SSSVal(strTokkescc) * 7 + SSSVal(strTokkdwkb) - SSSVal(strToksdwkb))))
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function getDkbnm
	'   概要： 入金種別名称を取得
	'   引数： pin_MEICDA   : 名称キー  intRow  :行番号
	'   戻値： 区分名称
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function getDkbnm(ByRef strDKBID As String, ByRef intRow As Short) As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_GET_DKBNM
		
		getDkbnm = ""
		
		'dkbflbが1のものが差額入金で選択できる区分となる
		strSql = "SELECT * FROM systbd " & "WHERE dkbsb = '050' " & "AND dkbid = '" & strDKBID & "' " & "AND dkbflb = '1'"

        'DBアクセス
        '2019/04/17 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/17 CHG E N D
            With gtypeFR_SUB(intRow)
                '2019/04/17 CHG START
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBNM = CF_Ora_GetDyn(Usr_Ody, "dkbnm", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_UPDID = CF_Ora_GetDyn(Usr_Ody, "updid", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DFLDKBCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DFLDKBCD = CF_Ora_GetDyn(Usr_Ody, "dfldkbcd", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBZAIFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBZAIFL = CF_Ora_GetDyn(Usr_Ody, "dkbzaifl", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBTEGFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBTEGFL = CF_Ora_GetDyn(Usr_Ody, "dkbtegfl", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBFLA = CF_Ora_GetDyn(Usr_Ody, "dkbfla", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBFLB = CF_Ora_GetDyn(Usr_Ody, "dkbflb", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.SUB_DKBFLC = CF_Ora_GetDyn(Usr_Ody, "dkbflc", "")
                ''UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'getDkbnm = .SUB_DKBNM
                .SUB_DKBNM = DB_NullReplace(dt.Rows(0)("dkbnm"), "")
                .SUB_UPDID = DB_NullReplace(dt.Rows(0)("updid"), "")
                .SUB_DFLDKBCD = DB_NullReplace(dt.Rows(0)("dfldkbcd"), "")
                .SUB_DKBZAIFL = DB_NullReplace(dt.Rows(0)("dkbzaifl"), "")
                .SUB_DKBTEGFL = DB_NullReplace(dt.Rows(0)("dkbtegfl"), "")
                .SUB_DKBFLA = DB_NullReplace(dt.Rows(0)("dkbfla"), "")
                .SUB_DKBFLB = DB_NullReplace(dt.Rows(0)("dkbflb"), "")
                .SUB_DKBFLC = DB_NullReplace(dt.Rows(0)("dkbflc"), "")
                getDkbnm = .SUB_DKBNM.ToString
                '2019/04/17 CHG E N D
            End With
        End If

END_GET_DKBNM:
        'クローズ
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D
        Exit Function
		
ERR_GET_DKBNM: 
		GoTo END_GET_DKBNM
		
	End Function
	
	'差額入金で使う構造体のクリア
	Public Sub initSubFormType(ByRef intRow As Short)
		With gtypeFR_SUB(intRow)
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBID = Space(2) '2byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBNM = Space(6) '6byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_UPDID = Space(2) '2byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DFLDKBCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DFLDKBCD = Space(13) '13byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBZAIFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBZAIFL = Space(1) '1byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBTEGFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBTEGFL = Space(1) '1byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLA = Space(1) '1byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLB = Space(1) '1byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLC = Space(1) '1byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_KOUZA = Space(10) '10byte space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_NYUKN = Space(9) '9byte  space
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_LINCMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_LINCMA = Space(20) '20byte space
		End With
	End Sub
	
	'差額入金で使う構造体の移動
	Public Sub moveSubFormType(ByRef intRow As Short)
		With gtypeFR_SUB(intRow)
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBID = gtypeFR_SUB(intRow + 1).SUB_DKBID
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBNM = gtypeFR_SUB(intRow + 1).SUB_DKBNM
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_UPDID = gtypeFR_SUB(intRow + 1).SUB_UPDID
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DFLDKBCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DFLDKBCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DFLDKBCD = gtypeFR_SUB(intRow + 1).SUB_DFLDKBCD
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBZAIFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBZAIFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBZAIFL = gtypeFR_SUB(intRow + 1).SUB_DKBZAIFL
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBTEGFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBTEGFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBTEGFL = gtypeFR_SUB(intRow + 1).SUB_DKBTEGFL
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLA = gtypeFR_SUB(intRow + 1).SUB_DKBFLA
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLB = gtypeFR_SUB(intRow + 1).SUB_DKBFLB
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_DKBFLC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_DKBFLC = gtypeFR_SUB(intRow + 1).SUB_DKBFLC
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_KOUZA = gtypeFR_SUB(intRow + 1).SUB_KOUZA
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_NYUKN = gtypeFR_SUB(intRow + 1).SUB_NYUKN
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB(intRow).SUB_LINCMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_LINCMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SUB_LINCMA = gtypeFR_SUB(intRow + 1).SUB_LINCMA
		End With
		initSubFormType((intRow + 1))
	End Sub
	
	'2009/09/10 UPD START RISE)MIYAJIMA
	''// V2.00↓ ADD
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称： Function getDkbnm
	''   概要： 明細部表示データ取得SQLを作成する
	''   引数： pm_strSmaupddt   : 消込日
	''       ： pm_strTokseicd   : 請求先コード
	''       ： pm_strKaidt_Fr   : 売上日(開始)
	''       ： pm_strKaidt_To   : 売上日(終了)
	''       ： pm_strKesikb     : 消込表示区分
	''       ： pm_intSortkb     : ソート順
	''   戻値： 生成したSQL文
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function getSQLforBody(pm_strSmaupddt As String, _
	''                              pm_strTokseicd As String, _
	''                              pm_strKaidt_Fr As String, _
	''                              pm_strKaidt_to As String, _
	''                              pm_strKesikb As String, _
	''                     Optional pm_intSortkb As Integer = 0) As String
	'
	'    Dim strSql  As String
	'
	'    strSql = ""
	'    strSql = strSql & "SELECT " & vbCrLf
	'    strSql = strSql & "  UH.NXTKB " & vbCrLf
	'    strSql = strSql & " ,TO_DATE(UR.UDNDT, 'YYYY/MM/DD') HY_UDNDT  " & vbCrLf
	'    strSql = strSql & " ,TRIM(UR.JDNNO) || SUBSTR(UR.JDNLINNO, 2, 2) HY_JDNNO  " & vbCrLf
	'    strSql = strSql & " ,TO_DATE(UR.KESDT, 'YYYY/MM/DD') HY_KAIDT " & vbCrLf
	'    strSql = strSql & " ,UR.TOKJDNNO " & vbCrLf
	'    strSql = strSql & " ,UH.TANNM  " & vbCrLf
	'    strSql = strSql & " ,UR.URIKN " & vbCrLf
	'    strSql = strSql & " ,UR.UZEKN " & vbCrLf
	'    strSql = strSql & " ,UR.URIKN + UR.UZEKN KOMIKN  " & vbCrLf
	'    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) KESIKN  " & vbCrLf
	'    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) BFKESIKN " & vbCrLf
	'    strSql = strSql & " ,NVL(NR2.JKESIKN, 0) AFKESIKN  " & vbCrLf
	'    strSql = strSql & " ,UR.JDNNO " & vbCrLf
	'    strSql = strSql & " ,UR.JDNLINNO " & vbCrLf
	'    strSql = strSql & " ,UR.UDNDT " & vbCrLf
	'    strSql = strSql & " ,UR.KESDT  " & vbCrLf
	'    strSql = strSql & " ,UR.RECNO " & vbCrLf
	'    strSql = strSql & " ,UR.AKAKROKB " & vbCrLf
	'    strSql = strSql & " ,UR.KESIKB " & vbCrLf
	'    strSql = strSql & " ,UR.HENRSNCD " & vbCrLf
	'    strSql = strSql & " ,UR.HENSTTCD  " & vbCrLf
	'    strSql = strSql & " ,UR.TOKCD " & vbCrLf
	'    strSql = strSql & " ,UR.TOKSEICD " & vbCrLf
	'    strSql = strSql & " ,UH.TANCD " & vbCrLf
	'    strSql = strSql & " ,JR.JDNDT " & vbCrLf
	'    strSql = strSql & " ,UH.TUKKB  " & vbCrLf
	'    strSql = strSql & " ,UR.INVNO " & vbCrLf
	'    strSql = strSql & " ,UR.FURIKN " & vbCrLf
	'    strSql = strSql & " ,UH.FRNKB " & vbCrLf
	'    strSql = strSql & " ,UR.DATNO " & vbCrLf
	'    strSql = strSql & " ,UR.LINNO " & vbCrLf
	'    strSql = strSql & " ,UH.MAEUKKB    " & vbCrLf
	'    strSql = strSql & " ,UR.UDNNO  " & vbCrLf
	'    strSql = strSql & " ,JR.DATNO JDNDATNO  " & vbCrLf
	'''    strSql = strSql & " ,DECODE(NVL(TRIM(TG.TEGDT),' '),' ',NULL,TO_DATE(TG.TEGDT, 'YYYY/MM/DD') )TEGDT   " & vbCrLf
	''V3.00 2009/03/10 ADD START FKS)NAKATA
	'    strSql = strSql & " ,UR.URITK  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTFSTDT  UDNWRTFSTDT  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTFSTTM  UDNWRTFSTTM  " & vbCrLf
	''NAKATA 2009/03/10 ADD E.N.D FKS)NAKATA
	'    '排他処理用
	'    strSql = strSql & " ,UR.OPEID  UDNOPEID  " & vbCrLf
	'    strSql = strSql & " ,UR.CLTID  UDNCLTID  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTDT  UDNWRTDT  " & vbCrLf
	'    strSql = strSql & " ,UR.WRTTM  UDNWRTTM  " & vbCrLf
	'    strSql = strSql & " ,UR.UOPEID UDNUOPEID " & vbCrLf
	'    strSql = strSql & " ,UR.UCLTID UDNUCLTID " & vbCrLf
	'    strSql = strSql & " ,UR.UWRTDT UDNUWRTDT " & vbCrLf
	'    strSql = strSql & " ,UR.UWRTTM UDNUWRTTM " & vbCrLf
	'    strSql = strSql & " ,JR.OPEID  JDNOPEID  " & vbCrLf
	'    strSql = strSql & " ,JR.CLTID  JDNCLTID  " & vbCrLf
	'    strSql = strSql & " ,JR.WRTDT  JDNWRTDT  " & vbCrLf
	'    strSql = strSql & " ,JR.WRTTM  JDNWRTTM  " & vbCrLf
	'    strSql = strSql & " ,JR.UOPEID JDNUOPEID " & vbCrLf
	'    strSql = strSql & " ,JR.UCLTID JDNUCLTID " & vbCrLf
	'    strSql = strSql & " ,JR.UWRTDT JDNUWRTDT " & vbCrLf
	'    strSql = strSql & " ,JR.UWRTTM JDNUWRTTM " & vbCrLf
	'
	'    strSql = strSql & "FROM " & vbCrLf
	'    strSql = strSql & "  (SELECT " & vbCrLf
	'    strSql = strSql & "          * " & vbCrLf
	'    strSql = strSql & "   FROM   UDNTRA" & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB =  '1' " & vbCrLf
	'    strSql = strSql & "   AND    DENKB =  '1' " & vbCrLf
	''// V3.20↓ DEL
	''    strSql = strSql & "   AND    NYUKB <> '3' " & vbCrLf
	''// V3.20↓ DEL
	'    strSql = strSql & "   AND    IRISU <>  9 " & vbCrLf
	'    strSql = strSql & "  ) UR " & vbCrLf
	'
	'    strSql = strSql & " ,UDNTHA UH " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT UDNNO " & vbCrLf
	'    strSql = strSql & "         ,LINNO " & vbCrLf
	'    strSql = strSql & "         ,MAX(WRTFSTDT || WRTFSTTM) AS DT " & vbCrLf
	'    strSql = strSql & "   FROM   UDNTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DENKB = '1' " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNNO,LINNO " & vbCrLf
	'    strSql = strSql & "  ) B " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          UDNDATNO " & vbCrLf
	'    strSql = strSql & "         ,UDNLINNO " & vbCrLf
	'    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
	'    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
	'    strSql = strSql & "   AND   (NYUDT <=" & "'" & pm_strSmaupddt & "' OR NYUKB = '3') " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'    strSql = strSql & "  ) NR1 " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          UDNDATNO " & vbCrLf
	'    strSql = strSql & "         ,UDNLINNO " & vbCrLf
	'    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
	'    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
	'    strSql = strSql & "   AND   (NYUDT > '" & pm_strSmaupddt & "' AND NYUKB <> '3') " & vbCrLf
	'    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'    strSql = strSql & "  ) NR2 " & vbCrLf
	'
	'''    strSql = strSql & " ,(SELECT " & vbCrLf
	'''    strSql = strSql & "          V1.UDNDATNO " & vbCrLf
	'''    strSql = strSql & "         ,V1.UDNLINNO " & vbCrLf
	'''    strSql = strSql & "         ,V1.TEGDT " & vbCrLf
	'''    strSql = strSql & "   FROM   NKSTRA V1 " & vbCrLf
	'''    strSql = strSql & "        ,(SELECT  MAX(KDNNO) KDNNO " & vbCrLf
	'''    strSql = strSql & "                 ,UDNDATNO " & vbCrLf
	'''    strSql = strSql & "                 ,UDNLINNO " & vbCrLf
	'''    strSql = strSql & "          FROM    NKSTRA " & vbCrLf
	'''    strSql = strSql & "          WHERE   DATKB = '1' " & vbCrLf
	'''    strSql = strSql & "          GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
	'''    strSql = strSql & "         ) V2 " & vbCrLf
	'''    strSql = strSql & "   WHERE  V1.KDNNO    = V2.KDNNO " & vbCrLf
	'''    strSql = strSql & "   AND    V1.MOTKDNNO = ' ' " & vbCrLf
	'''    strSql = strSql & "  ) TG " & vbCrLf
	'
	'    strSql = strSql & " ,(SELECT " & vbCrLf
	'    strSql = strSql & "          * " & vbCrLf
	'    strSql = strSql & "   FROM   JDNTRA " & vbCrLf
	'    strSql = strSql & "   WHERE  DATNO IN ( " & vbCrLf
	'    strSql = strSql & "                     SELECT MAX(DATNO) " & vbCrLf
	'    strSql = strSql & "                     FROM JDNTRA " & vbCrLf
	'    strSql = strSql & "                     WHERE TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
	'    strSql = strSql & "                     GROUP BY JDNNO " & vbCrLf
	'    strSql = strSql & "                   ) " & vbCrLf
	'    strSql = strSql & "  ) JR  " & vbCrLf
	'
	'    strSql = strSql & "WHERE " & vbCrLf
	'    strSql = strSql & "      UR.TOKSEICD = '" & CF_Ora_Sgl(pm_strTokseicd) & "' " & vbCrLf
	''// V2.13↓ UPD
	''    If Trim(pm_strKaidt_Fr) <> "" Then
	''        strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT >= '" & pm_strKaidt_Fr & "' AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	''        strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''    Else
	''        strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	''        strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''    End If
	'    strSql = strSql & "AND ((UR.URIKN >= 0 AND UR.UDNDT <= '" & pm_strKaidt_to & "') " & vbCrLf
	'    strSql = strSql & "OR    UR.URIKN < 0) " & vbCrLf
	''// V2.13↑ UPD
	'    strSql = strSql & "AND ((UR.DKBID  = '01' AND UR.AKAKROKB = '1') " & vbCrLf
	'    strSql = strSql & "      OR  " & vbCrLf
	'    strSql = strSql & "     (UR.DKBID <> '01' AND UR.AKAKROKB = '9')) " & vbCrLf
	'    strSql = strSql & "AND UR.WRTFSTDT || UR.WRTFSTTM = B.DT " & vbCrLf
	'    strSql = strSql & "AND UR.UDNNO   = B.UDNNO " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO   = B.LINNO " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO   = UH.DATNO " & vbCrLf
	'    strSql = strSql & "AND UH.MAEUKKB = '1' " & vbCrLf
	'
	'
	''2009/09/03 ADD START RISE)MIYAJIMA
	'    strSql = strSql & "AND UR.SSADT  <= " & DB_TOKMTA.TOKSMEDT & vbCrLf
	''2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'
	'    '消込済みデータを表示する時は、締日以降の消込日付の明細のみ表示
	''// V2.11↓ UPD
	''2009/09/08 DEL START RISE)MIYAJIMA
	''    If pm_strKesikb = 1 Then
	''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	''    End If
	''2009/09/08 DEL E.N.D RISE)MIYAJIMA
	''''''// V2.10↓ UPD
	'''''''''    If pm_strKesikb = 1 Then
	'''''''''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) " & vbCrLf
	'''''''''    Else
	'''''''''        strSql = strSql & "AND (UR.URIKN + UR.UZEKN <> NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) " & vbCrLf
	''''''''''// V2.01↓ UPD
	''''''''''        strSql = strSql & "    OR (UR.URIKN + UR.UZEKN = NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) AND UR.NYUDT > '" & pm_strSmaupddt & "')) " & vbCrLf
	'''''''''        strSql = strSql & "    OR (UR.URIKN + UR.UZEKN = NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) )) " & vbCrLf
	''''''''''// V2.01↑ UPD
	'''''''''    End If
	'''''    If pm_strKesikb = 1 Then
	'''''        strSql = strSql & "AND  UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	'''''    Else
	'''''        strSql = strSql & "AND (UR.URIKN + UR.UZEKN <> UR.JKESIKN " & vbCrLf
	'''''        strSql = strSql & "     OR " & vbCrLf
	'''''        strSql = strSql & "     (UR.URIKN + UR.UZEKN = UR.JKESIKN AND UR.NYUDT > '" & pm_strSmaupddt & "') " & vbCrLf
	'''''        strSql = strSql & "    ) " & vbCrLf
	'''''    End If
	''''''// V2.10↑ UPD
	''// V2.11↑ UPD
	'
	'    strSql = strSql & "AND TRIM(JR.JDNDELDT) IS NULL " & vbCrLf
	'    strSql = strSql & "AND UR.JDNNO    = JR.JDNNO " & vbCrLf
	'    strSql = strSql & "AND UR.JDNLINNO = JR.LINNO " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO    = NR1.UDNDATNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO    = NR1.UDNLINNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.DATNO    = NR2.UDNDATNO(+) " & vbCrLf
	'    strSql = strSql & "AND UR.LINNO    = NR2.UDNLINNO(+) " & vbCrLf
	'''    strSql = strSql & "AND UR.DATNO    = TG.UDNDATNO(+)  " & vbCrLf
	'''    strSql = strSql & "AND UR.LINNO    = TG.UDNLINNO(+)  " & vbCrLf
	'
	'    'ｿｰﾄ順の変更
	'    Select Case pm_intSortkb
	'        Case 0
	'            strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
	'        Case 1
	'            strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, DATNO"
	'        Case 2
	'            strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
	'    End Select
	'
	'    getSQLforBody = strSql
	'
	'    Debug.Print strSql
	'
	'End Function
	''// V2.00↑ ADD
	
	'// V2.00↓ ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function getDkbnm
	'   概要： 明細部表示データ取得SQLを作成する
	'   引数： pm_strSmaupddt   : 消込日
	'       ： pm_strTokseicd   : 請求先コード
	'       ： pm_strKaidt_Fr   : 売上日(開始)
	'       ： pm_strKaidt_To   : 売上日(終了)
	'       ： pm_strKesikb     : 消込表示区分
	'       ： pm_intSortkb     : ソート順
	'   戻値： 生成したSQL文
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function getSQLforBody(ByRef pm_strSmaupddt As String, ByRef pm_strTokseicd As String, ByRef pm_strKaidt_Fr As String, ByRef pm_strKaidt_to As String, ByRef pm_strKesikb As String, Optional ByRef pm_intSortkb As Short = 0) As String
		
		Dim strSql As String
		
		strSql = ""
		strSql = strSql & "SELECT " & vbCrLf
		strSql = strSql & "  UH.NXTKB " & vbCrLf
		strSql = strSql & " ,TO_DATE(UR.UDNDT, 'YYYY/MM/DD') HY_UDNDT " & vbCrLf
		strSql = strSql & " ,TRIM(UR.JDNNO) || SUBSTR(UR.JDNLINNO, 2, 2) HY_JDNNO " & vbCrLf
		strSql = strSql & " ,TO_DATE(UR.KESDT, 'YYYY/MM/DD') HY_KAIDT " & vbCrLf
		strSql = strSql & " ,UR.TOKJDNNO " & vbCrLf
		strSql = strSql & " ,UH.TANNM " & vbCrLf
		strSql = strSql & " ,UR.URIKN " & vbCrLf
		strSql = strSql & " ,UR.UZEKN " & vbCrLf
		strSql = strSql & " ,UR.URIKN + UR.UZEKN KOMIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) KESIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR1.JKESIKN, 0) BFKESIKN " & vbCrLf
		strSql = strSql & " ,NVL(NR2.JKESIKN, 0) AFKESIKN " & vbCrLf
		strSql = strSql & " ,UR.JDNNO " & vbCrLf
		strSql = strSql & " ,UR.JDNLINNO " & vbCrLf
		strSql = strSql & " ,UR.UDNDT " & vbCrLf
		strSql = strSql & " ,UR.KESDT " & vbCrLf
		strSql = strSql & " ,UR.RECNO " & vbCrLf
		strSql = strSql & " ,UR.AKAKROKB " & vbCrLf
		strSql = strSql & " ,UR.KESIKB " & vbCrLf
		strSql = strSql & " ,UR.HENRSNCD " & vbCrLf
		strSql = strSql & " ,UR.HENSTTCD " & vbCrLf
		strSql = strSql & " ,UR.TOKCD " & vbCrLf
		strSql = strSql & " ,UR.TOKSEICD " & vbCrLf
		strSql = strSql & " ,UH.TANCD " & vbCrLf
		strSql = strSql & " ,JR.JDNDT " & vbCrLf
		strSql = strSql & " ,UH.TUKKB " & vbCrLf
		strSql = strSql & " ,UR.INVNO " & vbCrLf
		strSql = strSql & " ,UR.FURIKN " & vbCrLf
		strSql = strSql & " ,UH.FRNKB " & vbCrLf
		strSql = strSql & " ,UR.DATNO " & vbCrLf
		strSql = strSql & " ,UR.LINNO " & vbCrLf
		strSql = strSql & " ,UH.MAEUKKB " & vbCrLf
		strSql = strSql & " ,UR.UDNNO " & vbCrLf
		strSql = strSql & " ,JR.DATNO JDNDATNO  " & vbCrLf
		strSql = strSql & " ,UR.URITK " & vbCrLf
		'2009/09/15 ADD START RISE)MIYAJIMA
		strSql = strSql & " ,UR.SSADT " & vbCrLf
		'2009/09/15 ADD E.N.D RISE)MIYAJIMA
		strSql = strSql & " ,UR.WRTFSTDT  UDNWRTFSTDT " & vbCrLf
		strSql = strSql & " ,UR.WRTFSTTM  UDNWRTFSTTM " & vbCrLf
		
		'排他処理用
		strSql = strSql & " ,UR.OPEID  UDNOPEID  " & vbCrLf
		strSql = strSql & " ,UR.CLTID  UDNCLTID  " & vbCrLf
		strSql = strSql & " ,UR.WRTDT  UDNWRTDT  " & vbCrLf
		strSql = strSql & " ,UR.WRTTM  UDNWRTTM  " & vbCrLf
		strSql = strSql & " ,UR.UOPEID UDNUOPEID " & vbCrLf
		strSql = strSql & " ,UR.UCLTID UDNUCLTID " & vbCrLf
		strSql = strSql & " ,UR.UWRTDT UDNUWRTDT " & vbCrLf
		strSql = strSql & " ,UR.UWRTTM UDNUWRTTM " & vbCrLf
		strSql = strSql & " ,JR.OPEID  JDNOPEID  " & vbCrLf
		strSql = strSql & " ,JR.CLTID  JDNCLTID  " & vbCrLf
		strSql = strSql & " ,JR.WRTDT  JDNWRTDT  " & vbCrLf
		strSql = strSql & " ,JR.WRTTM  JDNWRTTM  " & vbCrLf
		strSql = strSql & " ,JR.UOPEID JDNUOPEID " & vbCrLf
		strSql = strSql & " ,JR.UCLTID JDNUCLTID " & vbCrLf
		strSql = strSql & " ,JR.UWRTDT JDNUWRTDT " & vbCrLf
		strSql = strSql & " ,JR.UWRTTM JDNUWRTTM " & vbCrLf
		
		'2009/09/27 ADD START RISE)MIYAJIMA
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
		strSql = strSql & "   FROM " & vbCrLf
		strSql = strSql & "       NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE " & vbCrLf
		strSql = strSql & "          UDNDATNO = UR.DATNO " & vbCrLf
		strSql = strSql & "   AND    UDNLINNO = UR.LINNO " & vbCrLf
		strSql = strSql & "   AND    DATKB    = '1' " & vbCrLf
		strSql = strSql & "   AND    AKAKROKB = '1' " & vbCrLf
		strSql = strSql & "   AND    KDNNO NOT IN ( " & vbCrLf
		strSql = strSql & "          SELECT " & vbCrLf
		strSql = strSql & "              MOTKDNNO " & vbCrLf
		strSql = strSql & "          FROM " & vbCrLf
		strSql = strSql & "              NKSTRA " & vbCrLf
		strSql = strSql & "          WHERE " & vbCrLf
		strSql = strSql & "                 UDNDATNO = UR.DATNO " & vbCrLf
		strSql = strSql & "          AND    UDNLINNO = UR.LINNO " & vbCrLf
		strSql = strSql & "          AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
		strSql = strSql & "       ) ) TEGDT " & vbCrLf
		'2009/09/27 ADD E.N.D RISE)MIYAJIMA
		
		strSql = strSql & "FROM " & vbCrLf
		strSql = strSql & "  (SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA" & vbCrLf
		strSql = strSql & "   WHERE  DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    IRISU    <> 9 " & vbCrLf
		If Trim(pm_strKaidt_Fr) <> "" Then
			strSql = strSql & "   AND    UDNDT    >= '" & pm_strKaidt_Fr & "' " & vbCrLf
		End If
		strSql = strSql & "   AND    UDNDT    <= '" & pm_strKaidt_to & "' " & vbCrLf
		'2009/09/27 DEL START RISE)MIYAJIMA
		''2009/09/15 UPD START RISE)MIYAJIMA
		''    strSql = strSql & "   AND    SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'    If pm_strKesikb = 1 Then
		'        strSql = strSql & "   AND    SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'    Else
		'        strSql = strSql & "   AND    (SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "' " & vbCrLf
		'        strSql = strSql & "           OR " & vbCrLf
		'        strSql = strSql & "           JKESIKN > 0 ) " & vbCrLf
		'    End If
		''2009/09/15 UPD E.N.D RISE)MIYAJIMA
		'2009/09/27 DEL E.N.D RISE)MIYAJIMA
		'2018/10/26 ADD START <C2-20181001-02> CIS)山口
		strSql = strSql & "   UNION ALL " & vbCrLf
		strSql = strSql & "   SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA A " & vbCrLf
		strSql = strSql & "   WHERE  A.DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    A.DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.IRISU    = 9 " & vbCrLf
		strSql = strSql & "   AND    (SELECT CASE COUNT(*) " & vbCrLf
		strSql = strSql & "                           WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
		strSql = strSql & "                           ELSE 0 END " & vbCrLf
		strSql = strSql & "              FROM    UDNTRA B" & vbCrLf
		strSql = strSql & "              WHERE  ( B.DATNO = A.DATNO " & vbCrLf
		strSql = strSql & "                           AND B.LINNO = A.LINNO)" & vbCrLf
		strSql = strSql & "              OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
		strSql = strSql & "                            DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
		strSql = strSql & "                           AND B.JDNNO = A.JDNNO " & vbCrLf
		strSql = strSql & "                           AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
		strSql = strSql & "                           AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
		If Trim(pm_strKaidt_Fr) <> "" Then
			strSql = strSql & "   AND    A.UDNDT    >= '" & pm_strKaidt_Fr & "' " & vbCrLf
		End If
		strSql = strSql & "   AND    A.UDNDT    <= '" & pm_strKaidt_to & "' " & vbCrLf
		'2018/10/26 ADD END <C2-20181001-02> CIS)山口
		strSql = strSql & "  ) UR " & vbCrLf
		
		strSql = strSql & " ,UDNTHA UH " & vbCrLf
		
		strSql = strSql & " ,(SELECT UDNNO " & vbCrLf
		strSql = strSql & "         ,LINNO " & vbCrLf
		strSql = strSql & "         ,MAX(WRTFSTDT || WRTFSTTM) AS DT " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA " & vbCrLf
		strSql = strSql & "   WHERE  DENKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   GROUP BY UDNNO,LINNO " & vbCrLf
		strSql = strSql & "  ) B " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          UDNDATNO " & vbCrLf
		strSql = strSql & "         ,UDNLINNO " & vbCrLf
		strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
		strSql = strSql & "   FROM   NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND   (NYUDT <=" & "'" & pm_strSmaupddt & "' OR NYUKB = '3') " & vbCrLf
		strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
		strSql = strSql & "  ) NR1 " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          UDNDATNO " & vbCrLf
		strSql = strSql & "         ,UDNLINNO " & vbCrLf
		strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
		strSql = strSql & "   FROM   NKSTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
		strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND   (NYUDT > '" & pm_strSmaupddt & "' AND NYUKB <> '3') " & vbCrLf
		strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
		strSql = strSql & "  ) NR2 " & vbCrLf
		
		strSql = strSql & " ,(SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   JDNTRA " & vbCrLf
		strSql = strSql & "   WHERE  DATNO IN ( " & vbCrLf
		strSql = strSql & "                     SELECT MAX(DATNO) " & vbCrLf
		strSql = strSql & "                     FROM JDNTRA " & vbCrLf
		'DEL START FKS)INABA 2010/06/07 **********************************
		'連絡票№817
		'    strSql = strSql & "                     WHERE TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
		'DEL  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "                     GROUP BY JDNNO " & vbCrLf
		strSql = strSql & "                   ) " & vbCrLf
		'ADD START FKS)INABA 2010/06/07 **********************************
		'連絡票№817
		strSql = strSql & "    AND  TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
		'ADD  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "  ) JR  " & vbCrLf
		
		strSql = strSql & "WHERE " & vbCrLf
		strSql = strSql & "  NOT EXISTS " & vbCrLf
		strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		strSql = strSql & "   WHERE " & vbCrLf
		strSql = strSql & "        DATKB    = '1'" & vbCrLf
		strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		strSql = strSql & "   AND  UR.AKAKROKB = '9' " & vbCrLf
		strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
		strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'2018/10/26 ADD START <C2-20181001-02> CIS)山口
		strSql = strSql & "   UNION ALL " & vbCrLf
		strSql = strSql & "   SELECT " & vbCrLf
		strSql = strSql & "          * " & vbCrLf
		strSql = strSql & "   FROM   UDNTRA A " & vbCrLf
		strSql = strSql & "   WHERE  A.DATKB    =  '1' " & vbCrLf
		strSql = strSql & "   AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		strSql = strSql & "   AND    A.JDNNO    = UR.JDNNO " & vbCrLf
		strSql = strSql & "   AND    A.JDNLINNO = UR.JDNLINNO " & vbCrLf
		strSql = strSql & "   AND    A.RECNO    = UR.RECNO " & vbCrLf
		strSql = strSql & "   AND    A.IRISU    = 9 " & vbCrLf
		strSql = strSql & "   AND    (SELECT CASE COUNT(*) " & vbCrLf
		strSql = strSql & "                           WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
		strSql = strSql & "                           ELSE 0 END " & vbCrLf
		strSql = strSql & "              FROM    UDNTRA B" & vbCrLf
		strSql = strSql & "              WHERE  ( B.DATNO = A.DATNO " & vbCrLf
		strSql = strSql & "                           AND B.LINNO = A.LINNO)" & vbCrLf
		strSql = strSql & "              OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
		strSql = strSql & "                            DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
		strSql = strSql & "                           AND B.JDNNO = A.JDNNO " & vbCrLf
		strSql = strSql & "                           AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
		strSql = strSql & "                           AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
		strSql = strSql & "   AND    UR.AKAKROKB = '9' " & vbCrLf
		strSql = strSql & "   AND    (A.DKBID    = '01' AND A.AKAKROKB = '1')" & vbCrLf
		strSql = strSql & "   AND    A.DENKB    = '1'" & vbCrLf
		strSql = strSql & "   AND    A.UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'2018/10/26 ADD END <C2-20181001-02> CIS)山口
		strSql = strSql & " ) " & vbCrLf
		'    strSql = strSql & " (UR.AKAKROKB = '9' AND " & vbCrLf
		'    strSql = strSql & "  NOT EXISTS " & vbCrLf
		'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		'    strSql = strSql & "   WHERE " & vbCrLf
		'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		'    strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
		'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		'    strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
		'    strSql = strSql & " ) OR " & vbCrLf
		'    strSql = strSql & " (UR.AKAKROKB = '1' AND " & vbCrLf
		'    strSql = strSql & "  NOT EXISTS " & vbCrLf
		'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
		'    strSql = strSql & "   WHERE " & vbCrLf
		'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
		'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
		'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
		'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
		'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
		'    strSql = strSql & "   AND (DKBID  <> '01' AND AKAKROKB = '9')" & vbCrLf
		'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
		'    strSql = strSql & "   AND  UDNDT > '" & pm_strKaidt_to & "'" & vbCrLf
		'    strSql = strSql & " )))" & vbCrLf
		
		strSql = strSql & "AND   UR.TOKSEICD = '" & CF_Ora_Sgl(pm_strTokseicd) & "' " & vbCrLf
		strSql = strSql & "AND   UR.UDNDT   <= '" & pm_strKaidt_to & "' " & vbCrLf
		strSql = strSql & "AND ((UR.DKBID  = '01' AND UR.AKAKROKB = '1') " & vbCrLf
		strSql = strSql & "      OR  " & vbCrLf
		strSql = strSql & "     (UR.DKBID <> '01' AND UR.AKAKROKB = '9')) " & vbCrLf
		strSql = strSql & "AND UR.WRTFSTDT || UR.WRTFSTTM = B.DT " & vbCrLf
		strSql = strSql & "AND UR.UDNNO   = B.UDNNO " & vbCrLf
		strSql = strSql & "AND UR.LINNO   = B.LINNO " & vbCrLf
		strSql = strSql & "AND UR.DATNO   = UH.DATNO " & vbCrLf
		strSql = strSql & "AND UH.MAEUKKB = '1' " & vbCrLf
		
		If CDbl(pm_strKesikb) = 1 Then
			strSql = strSql & "AND (" & vbCrLf
			'''' UPD 2014/02/05  FWEST) Yamamoto    Start    連絡票№FC14013101
			'        strSql = strSql & "     (UR.URIKN + UR.UZEKN <> UR.JKESIKN) " & vbCrLf
			strSql = strSql & "     ((UR.URIKN + UR.UZEKN <> UR.JKESIKN) " & vbCrLf
			strSql = strSql & "       AND UR.URIKN + UR.UZEKN <> " & vbCrLf
			strSql = strSql & "                (SELECT NVL(SUM(JKESIKN),0) FROM NKSTRA " & vbCrLf
			strSql = strSql & "                 WHERE  DATKB    = '1' " & vbCrLf
			strSql = strSql & "                 AND    UDNDATNO = UR.DATNO " & vbCrLf
			strSql = strSql & "                 AND    UDNLINNO = UR.LINNO) " & vbCrLf
			strSql = strSql & "      ) " & vbCrLf
			'''' UPD 2014/02/05  FWEST) Yamamoto    End
			strSql = strSql & "      OR" & vbCrLf
			strSql = strSql & "     ((UR.URIKN + UR.UZEKN =  UR.JKESIKN) " & vbCrLf
			strSql = strSql & "       AND EXISTS " & vbCrLf
			strSql = strSql & "       (SELECT * FROM UDNTRA " & vbCrLf
			strSql = strSql & "        WHERE  JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    DATKB    =  '1'" & vbCrLf
			strSql = strSql & "        AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    AKAKROKB =  '9'" & vbCrLf
			strSql = strSql & "        AND    IRISU    <> 9 " & vbCrLf
			strSql = strSql & "        AND    DKBID    IN  ('02','06')" & vbCrLf
			strSql = strSql & "        AND    URIKN + UZEKN   <> JKESIKN " & vbCrLf
			If Trim(pm_strKaidt_Fr) <> "" Then
				strSql = strSql & "        AND    UDNDT    >= '" & pm_strKaidt_Fr & "'" & vbCrLf
			End If
			strSql = strSql & "        AND    UDNDT    <= '" & pm_strKaidt_to & "'" & vbCrLf
			'2018/10/26 ADD START <C2-20181001-02> CIS)山口
			strSql = strSql & "        UNION ALL " & vbCrLf
			strSql = strSql & "        SELECT * FROM UDNTRA A " & vbCrLf
			strSql = strSql & "        WHERE  A.JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    A.JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    A.DATKB    =  '1'" & vbCrLf
			strSql = strSql & "        AND    A.TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    A.AKAKROKB =  '9'" & vbCrLf
			strSql = strSql & "        AND    A.IRISU    = 9 " & vbCrLf
			strSql = strSql & "        AND    (SELECT CASE COUNT(*) " & vbCrLf
			strSql = strSql & "                               WHEN 2 THEN SUM(B.URIKN + B.UZEKN) " & vbCrLf
			strSql = strSql & "                               ELSE 0 END " & vbCrLf
			strSql = strSql & "                   FROM    UDNTRA B" & vbCrLf
			strSql = strSql & "                   WHERE  ( B.DATNO = A.DATNO " & vbCrLf
			strSql = strSql & "                                AND B.LINNO = A.LINNO)" & vbCrLf
			strSql = strSql & "                   OR        ( DECODE(A.DKBID,'06',B.DATNO,B.MOTDATNO) = " & vbCrLf
			strSql = strSql & "                                 DECODE(A.DKBID,'06',A.MOTDATNO,A.DATNO)  " & vbCrLf
			strSql = strSql & "                                AND B.JDNNO = A.JDNNO " & vbCrLf
			strSql = strSql & "                                AND B.JDNLINNO = A.JDNLINNO " & vbCrLf
			strSql = strSql & "                                AND B.RECNO = A.RECNO )) <> 0 " & vbCrLf
			strSql = strSql & "        AND    A.DKBID    IN  ('02','06')" & vbCrLf
			strSql = strSql & "        AND    A.URIKN + A.UZEKN   <> A.JKESIKN " & vbCrLf
			If Trim(pm_strKaidt_Fr) <> "" Then
				strSql = strSql & "        AND    A.UDNDT    >= '" & pm_strKaidt_Fr & "'" & vbCrLf
			End If
			strSql = strSql & "        AND    A.UDNDT    <= '" & pm_strKaidt_to & "'" & vbCrLf
			'2018/10/26 ADD END <C2-20181001-02> CIS)山口
			
			strSql = strSql & "       )" & vbCrLf
			'''' ADD 2010/09/28  FKS) T.Yamamoto    Start    連絡票№FC10092801
			'単価訂正されていない
			strSql = strSql & "       AND NOT EXISTS " & vbCrLf
			strSql = strSql & "       (SELECT * FROM UDNTRA " & vbCrLf
			strSql = strSql & "        WHERE  JDNNO    =  UR.JDNNO" & vbCrLf
			strSql = strSql & "        AND    JDNLINNO =  UR.JDNLINNO" & vbCrLf
			strSql = strSql & "        AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
			strSql = strSql & "        AND    AKAKROKB =  '1'" & vbCrLf
			strSql = strSql & "        AND    DKBID    =  '01'" & vbCrLf
			strSql = strSql & "        AND    RECNO    =  UR.RECNO" & vbCrLf
			strSql = strSql & "        AND    URITK    <> UR.URITK" & vbCrLf
			strSql = strSql & "        AND    (WRTFSTDT || WRTFSTTM)" & vbCrLf
			strSql = strSql & "                        <  (UR.WRTFSTDT || UR.WRTFSTTM)" & vbCrLf
			strSql = strSql & "       )" & vbCrLf
			'''' ADD 2010/09/28  FKS) T.Yamamoto    End
			strSql = strSql & "      ) " & vbCrLf
			strSql = strSql & "    ) " & vbCrLf
		End If
		
		'2009/09/15 DEL START RISE)MIYAJIMA
		'    strSql = strSql & "AND UR.SSADT  <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
		'2009/09/15 DEL E.N.D RISE)MIYAJIMA
		
		strSql = strSql & "AND TRIM(JR.JDNDELDT) IS NULL " & vbCrLf
		strSql = strSql & "AND UR.JDNNO    = JR.JDNNO " & vbCrLf
		strSql = strSql & "AND UR.JDNLINNO = JR.LINNO " & vbCrLf
		'ADD START FKS)INABA 2010/06/07 **********************************
		'連絡票№817
		strSql = strSql & "AND UR.TOKSEICD = JR.TOKSEICD " & vbCrLf
		'ADD  END  FKS)INABA 2010/06/07 **********************************
		strSql = strSql & "AND UR.DATNO    = NR1.UDNDATNO(+) " & vbCrLf
		strSql = strSql & "AND UR.LINNO    = NR1.UDNLINNO(+) " & vbCrLf
		strSql = strSql & "AND UR.DATNO    = NR2.UDNDATNO(+) " & vbCrLf
		strSql = strSql & "AND UR.LINNO    = NR2.UDNLINNO(+) " & vbCrLf
		
		'ｿｰﾄ順の変更
		Select Case pm_intSortkb
			'''' UPD 2010/02/10  FKS) T.Yamamoto    Start    連絡票№771
			'        Case 0
			'            strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
			'        Case 1
			'            strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, DATNO"
			'        Case 2
			'            strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
			Case 0
				strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, UDNWRTFSTDT, UDNWRTFSTTM"
			Case 1
				strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, UDNWRTFSTDT, UDNWRTFSTTM"
			Case 2
				strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, UDNWRTFSTDT, UDNWRTFSTTM"
				'''' UPD 2010/02/10  FKS) T.Yamamoto    End
		End Select
		
		getSQLforBody = strSql
		
		'    Debug.Print strSql
		
	End Function
    '// V2.00↑ ADD
    '2009/09/10 UPD E.N.D RISE)MIYAJIMA

    '2019/04/17 ADD START
    Sub Error_Exit(ByVal ErrorMsg As String)
        Dim rtn As Object
        Dim I As Short
        '
        Call SSSWIN_LOGWRT(ErrorMsg)
        MsgBox("プログラムを終了します。", MsgBoxStyle.OkOnly, Trim(SSS_PrgNm))
        '
        If DBSTAT <> 0 Then
            MsgBox("エラーログの書き込みエラー ! Windows を再起動してください")
            '
        Else
            For I = SSS_MAX_DB - 1 To 0 Step -1
                Call DB_NCCLOSE(I)
            Next I
        End If
        Call DB_End()
        'UPGRADE_WARNING: オブジェクト rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        rtn = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
        End
    End Sub

    Function DSP_MsgBox(ByRef MSGKB As String, ByRef msgName As String, ByRef MSGSQ As Short) As Short
        '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
        '    '※メイン画面からのメッセ-ジ出力のみ対応。サブ画面未対応。
        '    Dim WK_PP As clsPP
        '    WK_PP = PP_SSSMAIN
        '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
        '' SSS/Win 共通のメッセージを表示します。
        '    '
        '    ''Close後はメッセージを表示しない
        '    If RsOpened(DBN_SYSTBH) = False Then Exit Function
        '    ''
        '    DB_SYSTBH.MSGNM = msgName
        '    Call DB_GetEq(DBN_SYSTBH, 1, MSGKB & DB_SYSTBH.MSGNM & Format$(MSGSQ, "0"), BtrNormal)
        '    If DBSTAT = 0 Then
        '        DSP_MsgBox = MsgBox(Trim$(DB_SYSTBH.MSGCM), SSSVal(DB_SYSTBH.BTNKB) + SSSVal(DB_SYSTBH.BTNON) + SSSVal(DB_SYSTBH.ICNKB), Trim$(SSS_PrgNm))
        '    Else
        '        MsgBox "メッセージファイルエラー  " & Chr(13) & Chr(13) & "DBSTAT=" & Format$(DBSTAT, "##0") & Chr(13) & "MsgKb=" & MSGKB & " MsgName=(" & msgName & ") MsgSq=" & Format$(MSGSQ, "0"), MB_OK, Trim$(SSS_PrgNm)
        '        Call Error_Exit("メッセージファイルエラー!")
        '    End If
        '    '[V4.1]　メッセージ出力時にPPを退避　以下追加
        '    PP_SSSMAIN = WK_PP
        '    '[V4.1]　メッセージ出力時にPPを退避　以上追加
    End Function

    Function SSS_EDTITM_WLS(ByVal Item As Object, ByVal KETA As Object, ByVal HENSYU As Object) As String
        Select Case HENSYU
            Case "0"
                'UPGRADE_WARNING: オブジェクト KETA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                SSS_EDTITM_WLS = RightWid(FormatAndRound(Item, "00000000000000000000"), KETA)
            Case Else
                'UPGRADE_WARNING: オブジェクト Item の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                SSS_EDTITM_WLS = Item
        End Select
    End Function

    '2019/04/17 ADD E N D


    'add 20190808 START
    Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
        'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
        'PP_SSSMAIN.CursorDirection = 1
        'WLS_SLISTCOM = SlistCom
    End Sub
    'add 20190808 END

End Module