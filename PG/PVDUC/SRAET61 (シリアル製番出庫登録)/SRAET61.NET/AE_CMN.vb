Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module AE_CMN
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　共通
	'*  モジュール名　　：　業務共通処理
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.24
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '入力担当者ＩＤ
		Dim InpTanNm As String '入力担当者名
		Dim InpTKCHGKB As String '単価変更権限
		Dim InpCLIID As String 'クライアントＩＤ
	End Structure
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	'端数計算桁数
	Public Const gc_strRPSKB_D1 As String = "1" '小数第一位
	Public Const gc_strRPSKB_D2 As String = "2" '小数第二位
	Public Const gc_strRPSKB_D3 As String = "3" '小数第三位
	Public Const gc_strRPSKB_D4 As String = "4" '小数第四位
	Public Const gc_strRPSKB_D5 As String = "5" '小数第五位
	Public Const gc_strRPSKB_I1 As String = "10" '１
	Public Const gc_strRPSKB_I2 As String = "11" '１０
	Public Const gc_strRPSKB_I3 As String = "12" '１００
	'************************************************************************************
	'   Public変数
	'************************************************************************************
	Public Inp_Inf As Cmn_Inp_Inf '入力者情報
	Public GV_SysDate As String 'ＤＢサーバー日付
	Public GV_SysTime As String 'ＤＢサーバー時刻
	Public GV_UNYDate As String '運用日付
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	Dim strINIDATNM(4) As String 'ＩＮＩのシンボル
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init
	'   概要：  プログラム起動時初期処理
	'   引数：  なし
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CF_Init()
		
		'''    Dim datDT           As Date
		'''    Dim DB_TANMTA       As TYPE_DB_TANMTA
		'''    Dim strYMD          As String
		'''    Dim strUNYDT        As String
		'''    Dim intLenCommand   As String
		'''    Dim intRet          As Integer
		'''
		'''    '二重起動ﾁｪｯｸ
		'''    If App.PrevInstance Then
		'''        MsgBox "【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", vbExclamation Or vbOKOnly, SSS_PrgNm
		'''        End
		'''    End If
		'''
		'''    ' "しばらくお待ちください" ウィンドウ表示
		''''    Load ICN_ICON
		'''
		''''   日付形式チェック
		'''    datDT = Date
		'''    strYMD = Format(Year(datDT), "0000") & "/" & Format(Month(datDT), "00") & "/" & Format(Day(datDT), "00")
		'''
		'''    If CStr(datDT) <> strYMD Then
		'''        MsgBox "日付の形式 '" & CStr(datDT) & "' が違います。" & vbCrLf _
		''''             & "コントロールパネルの地域（地球の絵）の日付" & vbCrLf _
		''''             & "の短い形式を yyyy/MM/dd に変更して下さい。", vbCritical
		'''        Call Error_Exit("日付の形式が違います。")
		'''    End If
		'''
		'''    '---------------------
		'''    ' 起動パラメータ設定
		'''    '---------------------
		'''    intLenCommand = LenWid(Trim$(Command$))
		''''    If intLenCommand < 15 Then
		''''        MsgBox "メニューから実行してください。", vbOKOnly, SSS_PrgNm
		''''        Call Error_Exit("メニューから実行してください。")
		''''    End If
		'''
		'''    SSS_CLTID = MidWid$(Command$, 2, 5)
		'''    SSS_OPEID = MidWid$(Command$, 7, 8)
		'''    SSS_OPEID = "000001"                            'TEST
		'''    'リードオンリーモード設定
		'''    If Left$(Command$, 1) = "'" Then SSS_ReadOnly = True
		'''
		'''    '入力担当者名取得
		'''    FR_SSSMAIN.HD_TANCD.Text = SSS_OPEID
		'''    If DSPTANCD_SEARCH(SSS_OPEID, DB_TANMTA) = 0 Then
		'''        FR_SSSMAIN.HD_TANNM.Text = DB_TANMTA.TANNM             '入力担当者名
		'''      Else
		'''        FR_SSSMAIN.HD_TANNM.Text = "XXXXX"
		'''    End If
		'''
		'''    '---------------------
		'''    ' SSSWIN.INI テーブル設定
		'''    '---------------------
		'''    strINIDATNM(0) = "USR_PATH"
		'''    strINIDATNM(1) = "DAT_PATH"
		'''    strINIDATNM(2) = "PRG_PATH"
		'''    strINIDATNM(3) = "WRK_PATH"
		'''    strINIDATNM(4) = "IMG_PATH"
		'''    SSS_INICnt = 4
		'''    'Iniファイル読込み
		'''    Call CF_INIT_GETINI
		'''
		'''    '運用日付取得
		'''    Call CF_Get_UnyDt
		'''
		'''    ' "しばらくお待ちください" ウィンドウ消去
		''''    Unload ICN_ICON
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_INIT_GETINI
	'   概要：  INIファイル読込み（共通）
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI 読込み
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				MsgBox("SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI を確認してください。[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_TANNM
	'   概要：  担当者名称取得
	'   引数：　pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :画面業務情報構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		'''    Dim Ret_Value        As String
		'''    Dim DB_TANMTA        As TYPE_DB_TANMTA
		'''    Dim intRet           As Integer
		'''
		'''    Ret_Value = ""
		'''
		'''    '担当者マスタ検索
		'''    Call DB_TANMTA_Clear(DB_TANMTA)
		'''    intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		'''    If intRet = 0 Then
		'''        Ret_Value = DB_TANMTA.TANNM
		'''    End If
		'''
		'''    CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Frm_Location
	'   概要：  初期表示位置設定
	'   引数：　pm_Form        :フォーム
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_Location(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		With pm_Form
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Frm_IN_TANCD
	'   概要：  入力担当者編集
	'   引数：　pm_Form        :フォーム
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		With pm_Form
			'入力担当者コード
			'UPGRADE_ISSUE: Control HD_IN_TANCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Trg_Index = CShort(.HD_IN_TANCD.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			'入力担当者名
			'UPGRADE_ISSUE: Control HD_IN_TANNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Trg_Index = CShort(.HD_IN_TANNM.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBASaiban
	'   概要：  伝票管理NO採番処理
	'   引数：　Pm_strDATNO()  :伝票管理No
	'           Pm_strRECNO()  :レコード管理No
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBASaiban(ByRef pot_strDatNo() As String, ByRef Pot_strRECNO() As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDatNo As Decimal
		Static curRecNo As Decimal
		Static intCnt As Short
		
		On Error GoTo ERR_AE_SYSTBASaiban
		
		AE_SYSTBASaiban = 9
		
		bolTran = False
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー情報管理テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBA        "
		strSQL = strSQL & "    for Update NoWait "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBASaiban = 1
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'伝票管理No取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0")) + 1
		If curDatNo > 9999999999# Then
			'9999999999を超えた場合は戻る
			curDatNo = 1
		End If
		For intCnt = 1 To UBound(pot_strDatNo)
			pot_strDatNo(intCnt) = VB6.Format(CStr(curDatNo), "0000000000")
			curDatNo = curDatNo + 1
			If curDatNo > 9999999999# Then
				'9999999999を超えた場合は戻る
				curDatNo = 1
			End If
		Next intCnt
		
		
		
		'レコード管理No取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0")) + 1
		If curRecNo > 9999999999# Then
			'9999999999を超えた場合は戻る
			curRecNo = 1
		End If
		
		For intCnt = 1 To UBound(Pot_strRECNO)
			Pot_strRECNO(intCnt) = VB6.Format(CStr(curRecNo), "0000000000")
			curRecNo = curRecNo + 1
			If curRecNo > 9999999999# Then
				'9999999999を超えた場合は戻る
				curRecNo = 1
			End If
		Next intCnt
		
		'ユーザー情報管理テーブル更新
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Edit()
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
		If UBound(Pot_strRECNO) > 0 Then
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
		End If
		If Trim(GV_SysTime) <> "" Then
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		End If
		If Trim(GV_SysDate) <> "" Then
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		End If
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Update()
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBASaiban = 0
		
EXIT_AE_SYSTBASaiban: 
		Exit Function
		
ERR_AE_SYSTBASaiban: 
		
		If gv_Int_OraErr = 54 Then
			'他で使用中
			AE_SYSTBASaiban = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBASaiban
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBCSaiban
	'   概要：  伝票NO採番処理
	'   引数：　Pin_strDKBSB     :採番対象の伝票取引区分種別
	'           Pot_strDENNO     :取得された伝票№
	'           Pin_strADDDENCD  :見積番号の採番の場合、処理年月(数字６桁）
	'           Pin_strKbn       :受注番号の場合取引区分
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, ByRef Pot_strDENNO As String, Optional ByVal Pin_strADDDENCD As String = "", Optional ByVal Pin_strKbn As String = "") As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static intCnt As Short
		Static strRtn As String
		Static strFixCd As String
		Static intRet As Short
		
		On Error GoTo ERR_AE_SYSTBCSaiban
		
		AE_SYSTBCSaiban = 9
		
		bolTran = False
		Pot_strDENNO = ""
		strFixCd = ""
		
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If IsNothing(Pin_strADDDENCD) = True And Pin_strDKBSB = gc_strDKBSB_MIT Then
			GoTo EXIT_AE_SYSTBCSaiban
		End If
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		Select Case Pin_strDKBSB
			'見積番号の採番
			Case gc_strDKBSB_MIT
				
				
				'見積番号採番処理
				intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
				If intRet <> 0 Then
					AE_SYSTBCSaiban = intRet
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				'受注番号の採番
			Case gc_strDKBSB_UOD
				'採番マスタ取得
				strSQL = ""
				strSQL = strSQL & " Select *             "
				strSQL = strSQL & "   from SAIMTA        "
				strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
				strSQL = strSQL & "    for Update NoWait "
				
				'SQL実行
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				'EOF判定
				If CF_Ora_EOF(usrOdy) = True Then
					Pot_strDENNO = "00001"
					'ユーザー伝票Noテーブル追加
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.AddNew の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.AddNew()
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD '伝票種別
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("FIXCD").Value = "R" '固定値
					strFixCd = "R"
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO '連番
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1) '区分１
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1) '区分２
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1) '区分３
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
					If Trim(GV_SysTime) <> "" Then
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime 'タイムスタンプ（時間）
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime 'タイムスタンプ（登録時間）
					End If
					If Trim(GV_SysDate) <> "" Then
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate 'タイムスタンプ（日付）
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate 'タイムスタンプ（登録日付）
					End If
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Update()
				Else
					'連番取得
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")
					
					If strDenNo = "" Then
						GoTo ERR_AE_SYSTBCSaiban
					End If
					
					'受注番号
					For intCnt = 4 To 1 Step -1
						bolRet = JDNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
						strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
						If bolRet = False Then
							Exit For
						End If
					Next intCnt
					
					If strDenNo = "00000" Then
						strDenNo = "00001"
					End If
					
					Pot_strDENNO = strDenNo
					
					'ユーザー伝票Noテーブル更新
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Edit()
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO '伝票No
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
					If Trim(GV_SysTime) <> "" Then
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
					Else
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
					End If
					If Trim(GV_SysDate) <> "" Then
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
					Else
						'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
					End If
					'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					usrOdy.Obj_Ody.Update()
				End If
				
				bolRet = CF_Ora_CloseDyn(usrOdy)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
		End Select
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		'採番
		Select Case Pin_strDKBSB
			'見積番号
			Case gc_strDKBSB_MIT
				Pot_strDENNO = Mid(Pin_strADDDENCD, 3, 4) & Mid(Pot_strDENNO, 5, 4)
				
				'受注番号
			Case gc_strDKBSB_UOD
				Select Case Pin_strKbn
					Case gc_strJDNTRKB_TAN '単品
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SET 'セットアップ
						Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SYS 'システム
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_SYR '修理
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_HSY '保守
						Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_KAS '貸出
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_ELS 'その他
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case Else
				End Select
			Case Else
				
		End Select
		
		AE_SYSTBCSaiban = 0
		
EXIT_AE_SYSTBCSaiban: 
		Exit Function
		
ERR_AE_SYSTBCSaiban: 
		
		If gv_Int_OraErr = 54 Then
			'他で使用中
			AE_SYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBC_Update
	'   概要：  SYSTBC更新処理
	'   引数：　Pin_strADDDENCD  :処理年月(数字６桁）
	' 　　　　　Pot_strDENNO     :取得された伝票№
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_Update(ByVal Pin_strADDDENCD As String, ByRef Pot_strDENNO As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static strSTTNO As String
		Static strENDNO As String
		
		On Error GoTo ERR_F_SYSTBC_Update
		
		F_SYSTBC_Update = 9
		
		Pot_strDENNO = ""
		strSTTNO = ""
		strENDNO = ""
		
		'ユーザー伝票Noテーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_MIT & "' "
		strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
		strSQL = strSQL & "    for Update NoWait "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			strSTTNO = "00000001"
			strENDNO = "00009999"
			Pot_strDENNO = strSTTNO
			'ユーザー伝票Noテーブル追加
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.AddNew の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.AddNew()
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT '伝票取引区分種別
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD '伝票付属ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT '伝票名称
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("STTNO").Value = strSTTNO '開始伝票NO.
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("ENDNO").Value = strENDNO '終了伝票NO.
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime 'タイムスタンプ（時間）
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime 'タイムスタンプ（登録時間）
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate 'タイムスタンプ（日付）
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate 'タイムスタンプ（登録日付）
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Update()
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSTTNO = CF_Ora_GetDyn(usrOdy, "STTNO", "0")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strENDNO = CF_Ora_GetDyn(usrOdy, "ENDNO", "")
			If IsNumeric(strENDNO) = False Then
				strENDNO = "00009999"
			End If
			
			'見積番号は４桁
			If curDENNO > CF_Get_CCurString(strENDNO) Then
				curDENNO = CF_Get_CCurString(strSTTNO)
			End If
			strDenNo = VB6.Format(CStr(curDENNO), New String("0", 8))
			
			Pot_strDENNO = strDenNo
			
			'ユーザー伝票Noテーブル更新
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Edit()
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '伝票No
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '最終作業者ｺｰﾄﾞ
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value 'クライアントID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			Else
				'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Update()
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		F_SYSTBC_Update = 0
		
EXIT_F_SYSTBC_Update: 
		Exit Function
		
ERR_F_SYSTBC_Update: 
		
		If gv_Int_OraErr = 54 Then
			'他で使用中
			F_SYSTBC_Update = 2
		End If
		
		GoTo EXIT_F_SYSTBC_Update
		
	End Function
	' === 20060814 === INSERT E -
	
	' === 20060815 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_SYSTBCSaiban_PUDLNO
	'   概要：  入出庫番号採番処理
	'   引数：　Pm_strPUDLNO()  :入出庫番号
	'   戻値：  0:正常  1:データ無し  2:Lock中  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban_PUDLNO(ByRef Pm_strPUDLNO() As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		
		On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		
		AE_SYSTBCSaiban_PUDLNO = 9
		
		bolTran = False
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ユーザー伝票№テーブル取得
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
		strSQL = strSQL & "    for Update NoWait "
		
		'SQL実行
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'EOF判定
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_PUDLNO = 1
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'伝票付属コード取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'開始伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'終了伝票No取得
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'伝票NO.取得
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'終了伝票NOを超えた場合は戻る
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To UBound(Pm_strPUDLNO)
			Pm_strPUDLNO(intCnt) = strADDDENCD & VB6.Format(curDENNO, New String("0", 8))
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'終了伝票Noを超えた場合は戻る
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'ユーザー伝票№テーブル更新
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Edit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Edit()
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
		If Trim(GV_SysTime) <> "" Then
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		End If
		If Trim(GV_SysDate) <> "" Then
			'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		End If
		'UPGRADE_WARNING: オブジェクト usrOdy.Obj_Ody.Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		usrOdy.Obj_Ody.Update()
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_PUDLNO = 0
		
EXIT_AE_SYSTBCSaiban_PUDLNO: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_PUDLNO: 
		
		If gv_Int_OraErr = 54 Then
			'他で使用中
			AE_SYSTBCSaiban_PUDLNO = 2
		End If
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_PUDLNO
		
	End Function
	' === 20060815 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function JDNNO_CntUp
	'   概要：  受注番号カウントアップ処理
	'   引数：　pin_strJDNNO     :カウントアップ対象文字
	'           pot_strRtn     :カウントアップ後文字
	'   戻値：  True:桁上がりあり  False:桁上がりなし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function JDNNO_CntUp(ByVal pin_strJDNNO As String, ByRef pot_strRtn As String) As Boolean
		
		Dim intJDNNO As Short
		Dim strJdnNo As String
		
		JDNNO_CntUp = False
		
		Select Case pin_strJDNNO
			Case "9"
				pot_strRtn = "A"
				Exit Function
				
			Case "Z"
				pot_strRtn = "0"
				JDNNO_CntUp = True
				Exit Function
		End Select
		
		intJDNNO = Asc(pin_strJDNNO)
		pot_strRtn = Chr(intJDNNO + 1)
		
		Select Case pot_strRtn
			Case "I", "O"
				intJDNNO = Asc(pot_strRtn)
				pot_strRtn = Chr(intJDNNO + 1)
			Case Else
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcTAX_Meisai
	'   概要：  消費税計算処理
	'   引数：　Pin_strHINZEIKB    :商品消費税区分
	'           Pin_curZEIRT       :消費税率
	'           Pin_curTANKA       :単価(税抜き単価)
	'           Pin_curSURYO       :数量
	'           Pin_strTOKZEIKB    :得意先消費税区分
	'           Pin_strTOKRPSKB    :消費税端数処理桁数
	'           Pin_strTOKZRNKB    :消費税端数処理区分
	'           Pot_curUZEKN       :消費税額
	'   戻値：  True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, ByVal Pin_curZEIRT As Decimal, ByVal Pin_curTANKA As Decimal, ByVal Pin_curSURYO As Decimal, ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_curUZEKN As Decimal) As Short
		
		Static curZeigk As Decimal
		Static strRPSKB As String
		
		On Error GoTo ERR_AE_CalcTAX_Meisai
		
		AE_CalcTAX_Meisai = False
		
		Pot_curUZEKN = 0
		
		strRPSKB = ""
		Select Case Pin_strTOKRPSKB
			'円未満
			Case gc_strTOKRPSKB_0
				strRPSKB = gc_strRPSKB_I1
				'十円未満
			Case gc_strTOKRPSKB_10
				strRPSKB = gc_strRPSKB_I2
				'百円未満
			Case gc_strTOKRPSKB_100
				strRPSKB = gc_strRPSKB_I3
		End Select
		
		Select Case Pin_strHINZEIKB '商品消費税区分
			'取引先区分どおり
			Case gc_strHINZEIKB_TOK
				Select Case Pin_strTOKZEIKB '得意先消費税区分
					'税抜き、税込み
					Case gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_NUK
						curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
						Pot_curUZEKN = curZeigk
						
						'非課税
					Case gc_strTOKZEIKB_HIK
				End Select
				
				'税抜き,税込み
			Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
				curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
				Pot_curUZEKN = curZeigk
				'非課税
			Case gc_strHINZEIKB_HIK
			Case Else
		End Select
		
		AE_CalcTAX_Meisai = True
		
EXIT_AE_CalcTAX_Meisai: 
		Exit Function
		
ERR_AE_CalcTAX_Meisai: 
		
		GoTo EXIT_AE_CalcTAX_Meisai
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcRoundKingk
	'   概要：  金額まるめ計算処理
	'   引数：　Pio_curKingk       :まるめ金額
	'           Pin_strRPSKB    :金額端数処理桁数（消費税端数処理桁数の場合
	'           Pin_strZRNKB    :金額端数処理区分
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Decimal, ByVal Pin_strRPSKB As String, ByVal Pin_strZRNKB As String)
		
		Dim curKingk As Decimal
		Dim curKingk_wk As Decimal
		
		curKingk = 0
		
		Select Case Pin_strRPSKB '金額端数処理桁数
			'１
			Case gc_strRPSKB_I1
				curKingk = Pio_curKingk
				'１０
			Case gc_strRPSKB_I2
				curKingk = Pio_curKingk / 10
				'１００
			Case gc_strRPSKB_I3
				curKingk = Pio_curKingk / 100
				'小数第一位
			Case gc_strRPSKB_D1
				curKingk = Pio_curKingk
				'小数第二位
			Case gc_strRPSKB_D2
				curKingk = Pio_curKingk * 10
				'小数第三位
			Case gc_strRPSKB_D3
				curKingk = Pio_curKingk * 100
				'小数第四位
			Case gc_strRPSKB_D4
				curKingk = Pio_curKingk * 1000
				'小数第五位
			Case gc_strRPSKB_D5
				curKingk = Pio_curKingk * 10000
		End Select
		
		Select Case Pin_strZRNKB '金額端数処理区分
			'切捨て
			Case gc_strTOKZRNKB_DWN
				curKingk = Fix(curKingk)
				'四捨五入
			Case gc_strTOKZRNKB_RND
				curKingk = System.Math.Round(curKingk)
				'切り上げ
			Case gc_strTOKZRNKB_UP
				curKingk_wk = Fix(curKingk)
				If curKingk_wk < curKingk Then
					curKingk = curKingk_wk + 1
				Else
					curKingk = curKingk_wk
				End If
		End Select
		
		Select Case Pin_strRPSKB '金額端数処理桁数
			'１
			Case gc_strRPSKB_I1
				curKingk = curKingk
				'１０
			Case gc_strRPSKB_I2
				curKingk = curKingk * 10
				'１００
			Case gc_strRPSKB_I3
				curKingk = curKingk * 100
				'小数第一位
			Case gc_strRPSKB_D1
				curKingk = curKingk
				'小数第二位
			Case gc_strRPSKB_D2
				curKingk = curKingk / 10
				'小数第三位
			Case gc_strRPSKB_D3
				curKingk = curKingk / 100
				'小数第四位
			Case gc_strRPSKB_D4
				curKingk = curKingk / 1000
				'小数第五位
			Case gc_strRPSKB_D5
				curKingk = curKingk / 10000
		End Select
		
		Pio_curKingk = curKingk
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_SIKRT
	'   概要：  仕切率計算処理
	'   引数：　Pin_curTANKA       :単価
	'           Pin_curTEIKATK     :定価
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  仕切率
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_SIKRT(ByVal Pin_curTANKA As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curSIKRT As Decimal
		Static strZRNKB As String
		
		AE_Calc_SIKRT = 0
		If Pin_curTEIKATK = 0 Then
			curSIKRT = 0
		Else
			curSIKRT = Pin_curTANKA / Pin_curTEIKATK * 100
		End If
		
		Select Case Pin_strTKNZRNKB '金額端数処理区分
			'切捨て
			Case gc_strTOKZRNKB_DWN
				strZRNKB = gc_strTOKZRNKB_UP
				'四捨五入
			Case gc_strTOKZRNKB_RND
				strZRNKB = gc_strTOKZRNKB_RND
				'切り上げ
			Case gc_strTOKZRNKB_UP
				strZRNKB = gc_strTOKZRNKB_DWN
		End Select
		
		'金額丸め処理
		Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
		
		AE_Calc_SIKRT = curSIKRT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_TANKA
	'   概要：  単価計算処理（仕切率より）
	'   引数：　Pin_curSIKRT       :仕切率
	'           Pin_curTEIKATK     :定価
	'           Pin_strTKNRPSKB    :金額端数処理桁数
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  単価
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_TANKA(ByVal Pin_curSIKRT As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curTanka As Decimal
		
		AE_Calc_TANKA = 0
		curTanka = Pin_curTEIKATK * Pin_curSIKRT / 100
		
		'金額丸め処理
		Call AE_CalcRoundKingk(curTanka, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
		AE_Calc_TANKA = curTanka
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Calc_BSART
	'   概要：  売差率計算処理
	'   引数：　Pin_curTANKA       :単価
	'           Pin_curSIKTK       :仕切単価
	'           Pin_strTKNRPSKB    :金額端数処理桁数
	'           Pin_strTKNZRNKB    :金額端数処理区分
	'   戻値：  仕切率
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_BSART(ByVal Pin_curTANKA As Decimal, ByVal Pin_curSIKTK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curBSART As Decimal
		
		AE_Calc_BSART = 0
		
		If Pin_curTANKA = 0 Then
			curBSART = 0
		Else
			curBSART = (Pin_curTANKA - Pin_curSIKTK) / Pin_curTANKA * 100
		End If
		
		'金額丸め処理
		Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
		AE_Calc_BSART = curBSART
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CalcDateAdd
	'   概要：  日付計算処理
	'   引数：　Pio_strDate     :計算対象日(数字８桁、またはyyyy/mm/ddの形式）
	'           Pin_intAddDate  :加算対象日数（マイナス値は減算）
	'           Pin_strKind     :営業日種別("1":営業日 "2":銀行稼働日　"3":物流稼働日）
	'                            省略時は営業日による考慮無し
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, _
	''                               ByVal Pin_intAddDate As Integer, _
	''                               Optional ByVal Pin_strKind As String = "0") As Integer
	'
	'    Dim strDate         As String
	'    Dim Mst_Inf         As TYPE_DB_CLDMTA
	'    Dim intAddDate      As Integer              '日付計算用
	'
	'    AE_CalcDateAdd = 9
	'
	'    strDate = ""
	'
	'    '日付整合性チェック
	'    If IsDate(Pio_strDate) = True Then
	'        strDate = Pio_strDate
	'    End If
	'
	'    '日付様式に変換
	'    If IsDate(Format(Pio_strDate, "@@@@/@@/@@")) = True Then
	'        strDate = Format(Pio_strDate, "@@@@/@@/@@")
	'    End If
	'
	'    If Trim(strDate) = "" Then
	'        Exit Function
	'    End If
	'
	'    '日付加算
	'    strDate = DateAdd("d", Pin_intAddDate, strDate)
	'
	'    'カレンダマスタ検索
	'    If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'        Exit Function
	'    End If
	'
	'    If Pin_intAddDate >= 0 Then
	'        intAddDate = 1
	'    Else
	'        intAddDate = -1
	'    End If
	'
	'    Select Case Pin_strKind
	'        '営業日計算
	'        Case "1"
	'            Do Until Mst_Inf.SLDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                'カレンダマスタ検索
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        '銀行稼働日計算
	'        Case "2"
	'            Do Until Mst_Inf.BNKKDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                'カレンダマスタ検索
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        '物流稼働日計算
	'        Case "3"
	'            Do Until Mst_Inf.DTBKDKB = "1"
	'                strDate = DateAdd("d", intAddDate, strDate)
	'                'カレンダマスタ検索
	'                If DSPCLDDT_SEARCH(Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
	'                    Exit Function
	'                End If
	'            Loop
	'
	'        Case Else
	'
	'    End Select
	'
	'    Pio_strDate = strDate
	'    AE_CalcDateAdd = 0
	'
	'End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CmnMsgLibrary
	'   概要：  標準メッセージ表示処理
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pm_All  　　　  : 画面情報
	'           pin_strMsg      : 追加メッセージ
	'   戻値：  選択ボタン
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, ByRef pm_All As Cls_All, Optional ByVal pin_strMsg As String = "") As Short
		
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		AE_CmnMsgLibrary = False
		
		If pm_All.Dsp_IM_Denkyu Is Nothing Then
		Else
			'プロンプトメッセージのクリア
			Call CF_Clr_Prompt(pm_All)
		End If
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) 'メッセージ種別
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) 'メッセージアイテム
		
		' === 20060810 === INSERT S - ACE)Nagasawa
		Beep()
		' === 20060810 === INSERT E -
		
		'メッセージマスタ検索
		'UPGRADE_WARNING: AE_CmnMsgLibrary に変換されていないステートメントがあります。ソース コードを確認してください。
		If intRet <> 0 Then
			'UPGRADE_WARNING: AE_CmnMsgLibrary に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'追加メッセージの編集
		strMsg_add = ""
		'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGSQ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Mst_Inf.MSGSQ = "9" Then
			'ＤＢアクセス系エラーとする
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'Windowsに制御を戻す
		System.Windows.Forms.Application.DoEvents()
		
		'メッセージ表示
		'UPGRADE_WARNING: オブジェクト Mst_Inf.BTNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/キャンセル
			Case gc_strBTNKB_OKCancel
				'UPGRADE_WARNING: オブジェクト Mst_Inf.BTNON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'中止/再試行/無視
			Case gc_strBTNKB_AbortRetryIgnore
				'UPGRADE_WARNING: オブジェクト Mst_Inf.BTNON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ/キャンセル
			Case gc_strBTNKB_YesNoCancel
				'UPGRADE_WARNING: オブジェクト Mst_Inf.BTNON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ
			Case gc_strBTNKB_YesNo
				'UPGRADE_WARNING: オブジェクト Mst_Inf.BTNON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'再試行/キャンセル
			Case gc_strBTNKB_RetryCancel
				'UPGRADE_WARNING: オブジェクト Mst_Inf.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetSMEDT
	'   概要：  締日計算処理
	'   引数：  Pin_strDate     : 計算対象日付(８桁の数値Or日付）
	'           Pin_strTOKSMEKB : 締区分
	'           Pin_strTOKSMEDD : 締初期日付（売上）
	'           Pin_strTOKSMECC : 締サイクル（売上）
	'           Pin_strTOKSDWKB : 締め曜日
	'           Pin_intCHTNKB   : 帳端区分(計算対象日から何回目の締日かを指定)
	'           Pot_strSMEDT    : 計算結果締日
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetSMEDT(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal Pin_intCHTNKB As Short, ByRef Pot_strSMEDT As String) As Short
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim cnt As Short
		Dim I As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intTOKSMECC As Short
		Dim intTOKSMEDD As Short
		Dim intTOKSDWKB As Short
		
		AE_GetSMEDT = 9
		Pot_strSMEDT = ""
		
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
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'締初期日付取得
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intTOKSMEDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'締サイクル取得
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intTOKSMECC = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			'締区分＝"日"の場合
			If intTOKSMECC = 1 Then '毎日締め
				Pot_strSMEDT = CStr(DateSerial(yy, mm, dd + Pin_intCHTNKB))
				Exit Function
			End If
			'
			If intTOKSMECC <= 0 Or intTOKSMECC > 15 Then intTOKSMECC = 30
			cnt = Int(30 / intTOKSMECC) '締回数／月
			setidx = False
			For I = 0 To cnt - 1
				smeday(I) = intTOKSMEDD + intTOKSMECC * I
				If smeday(I) > 27 Then smeday(I) = 99
				If dd <= smeday(I) And setidx = False Then
					idx = I + Pin_intCHTNKB '該当日付の締日配列添字
					setidx = True
				End If
			Next I
			If setidx = False Then idx = cnt + Pin_intCHTNKB
			addMM = Int(idx / cnt)
			idx = idx Mod cnt
			If idx < 0 Then idx = idx + cnt
			'
			If smeday(idx) = 99 Then
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
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
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB) + (7 * Pin_intCHTNKB)))
			Else
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate))) + (7 * Pin_intCHTNKB)))
			End If
		End If
		
		Pot_strSMEDT = VB6.Format(Pot_strSMEDT, "yyyymmdd")
		
		AE_GetSMEDT = 0
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetUDNYTDT
	'   概要：  売上予定日計算処理
	'   引数：  Pin_strDEFNOKDT : 納期(８桁の数値Or日付）
	'           Pin_strODNYTDT  : 出荷予定日
	'           Pin_strUDNYTDT  : 売上予定日（画面入力項目)
	'           Pin_strTOKSMEKB : 締区分
	'           Pin_strTOKSMEDD : 締初期日付（売上）
	'           Pin_strTOKSMECC : 締サイクル（売上）
	'           Pin_strTOKSDWKB : 締め曜日
	'           Pin_strURIKJN   : 売上基準
	'           Pot_strUDNYTDT  : 計算結果売上予定日(yyyymmddの形式）
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, _
	'''''                       ByVal Pin_strODNYTDT As String, _
	'''''                       ByVal Pin_strUDNYTDT As String, _
	'''''                       ByVal Pin_strTOKSMEKB As String, _
	'''''                       ByVal Pin_strTOKSMEDD As String, _
	'''''                       ByVal Pin_strTOKSMECC As String, _
	'''''                       ByVal Pin_strTOKSDWKB As String, _
	'''''                       ByVal Pin_strURIKJN As String, _
	'''''                       ByRef Pot_strUDNYTDT As String) As Integer
	''''
	''''    Dim strDate     As String
	''''    Dim strDate2    As String
	''''    Dim intRet      As Integer
	''''    Dim strSMEDT    As String
	''''
	''''    AE_GetUDNYTDT = 9
	''''    Pot_strUDNYTDT = ""
	''''
	''''    Select Case Pin_strURIKJN
	''''        '出荷基準
	''''        Case gc_strURIKJN_SYK
	''''            '日付チェック
	''''            If IsDate(Pin_strODNYTDT) = True Then
	''''                strDate = Format(Pin_strODNYTDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strODNYTDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strODNYTDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''
	''''            '営業日取得
	''''            intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
	''''            If intRet <> 0 Then
	''''                Exit Function
	''''            End If
	''''
	''''        '検収基準、工事完了基準
	''''        Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
	''''            '日付チェック
	''''
	''''' === 20060726 === INSERT S - ACE)Nagasawa
	''''            If Trim(Pin_strUDNYTDT) <> "" Then
	''''' === 20060726 === INSERT E -
	''''            If IsDate(Pin_strUDNYTDT) = True Then
	''''                strDate = Format(Pin_strUDNYTDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strUDNYTDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''' === 20060726 === INSERT S - ACE)Nagasawa
	''''            Else
	''''                If IsDate(Pin_strODNYTDT) = True Then
	''''                    strDate = Format(Pin_strODNYTDT, "yyyymmdd")
	''''                Else
	''''                    If IsDate(Format(Pin_strODNYTDT, "@@@@/@@/@@")) = True Then
	''''                        strDate = Pin_strODNYTDT
	''''                    Else
	''''                        Exit Function
	''''                    End If
	''''                End If
	''''            End If
	''''' === 20060726 === INSERT E -
	''''
	''''            Pot_strUDNYTDT = strDate
	''''
	''''        '役務完了基準
	''''        Case gc_strURIKJN_EKM
	''''            '日付チェック
	''''            If IsDate(Pin_strDEFNOKDT) = True Then
	''''                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
	''''            Else
	''''                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
	''''                    strDate = Pin_strDEFNOKDT
	''''                Else
	''''                    Exit Function
	''''                End If
	''''            End If
	''''
	''''            '売上予定日を計算
	''''            intRet = AE_GetSMEDT(strDate, _
	'''''                                 Pin_strTOKSMEKB, _
	'''''                                 Pin_strTOKSMEDD, _
	'''''                                 Pin_strTOKSMECC, _
	'''''                                 Pin_strTOKSDWKB, _
	'''''                                 1, _
	'''''                                 strDate2)
	''''            If intRet = 9 Then
	''''                Exit Function
	''''            End If
	''''
	''''            '営業日取得
	''''            intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
	''''            If intRet <> 0 Then
	''''                Exit Function
	''''            End If
	''''
	''''    End Select
	''''
	''''
	''''    AE_GetUDNYTDT = 0
	''''
	''''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_GetKRSMADT
	'   概要：  経理締日計算処理
	'   引数：  Pin_strKJNDT    : 基準日
	'           Pot_strSMADT  　: 計算結果経理締日(yyyymmddの形式）
	'   戻値：  0：正常　9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Function AE_GetKRSMADT(ByVal Pin_strKJNDT As String, _
	'''''                       ByRef pot_strSMADT As String) As Integer
	''''
	''''    Dim strSMEDT                As String
	''''    Dim strSQL                  As String
	''''    Dim Mst_Inf_SYSTBA          As TYPE_DB_SYSTBA
	''''    Dim intRet                  As Integer
	''''
	''''    AE_GetKRSMADT = 9
	''''    pot_strSMADT = ""
	''''
	''''    Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
	''''
	''''    'ユーザー情報管理テーブル検索
	''''    If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
	''''        Exit Function
	''''    End If
	''''
	''''    '経理締日計算
	''''    intRet = AE_GetSMEDT(Pin_strKJNDT _
	'''''                       , gc_strSMEKB_DAY _
	'''''                       , Mst_Inf_SYSTBA.SMEDD _
	'''''                       , "99" _
	'''''                       , "" _
	'''''                       , 0 _
	'''''                       , strSMEDT)
	''''    If intRet <> 0 Then
	''''        Exit Function
	''''    End If
	''''
	''''    pot_strSMADT = strSMEDT
	''''
	''''    AE_GetKRSMADT = 0
	''''
	''''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_GetTanka
	'   概要：  PL/SQL実行処理(単価取得処理)
	'   引数：　Pin_strHINCD  : 商品コード
	'           Pin_strTOKCD  : 得意先コード
	'           Pin_strDATE   : 適用日
	'           Pin_strTUKKB  : 通貨区分
	'           Pin_lngSU     : 数量
	'           Pot_curTanka  : 取得単価
	'           Pot_curSIKRT  : 取得仕切率
	'           Pin_strJDNKB  : 受注区分（"1"海外　それ以外は空白）
	'           Pot_curTEITK  : 定価
	'   戻値：　0 : 正常 9: 異常
	'   備考：  単価取得用PL/SQL(PRC_CMNPL90_01)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, _
	'''''                                          ByVal pin_strTOKCD As String, _
	'''''                                          ByVal pin_strDate As String, _
	'''''                                          ByVal pin_strTUKKB As String, _
	'''''                                          ByVal Pin_lngSU As Long, _
	'''''                                          ByRef Pot_curTANKA As Currency, _
	'''''                                          ByRef Pot_curSIKRT As Currency, _
	'''''                                          Optional ByRef Pin_strJDNKB As String = "", _
	'''''                                          Optional ByRef Pot_curTEITK As Currency) As Integer
	''''
	''''    Dim strSQL      As String           'SQL文
	''''    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(製品コード)
	''''    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(得意先コード)
	''''    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(適用日)
	''''    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(通貨区分)
	''''    Dim lngPara5    As Long             'ﾊﾟﾗﾒｰﾀ5(数量)
	''''    Dim strPara6    As String           'ﾊﾟﾗﾒｰﾀ6(受注区分)
	''''    Dim lngPara7    As Long             'ﾊﾟﾗﾒｰﾀ7(復帰ｺｰﾄﾞ)
	''''    Dim lngPara8    As Long             'ﾊﾟﾗﾒｰﾀ8(ｴﾗｰｺｰﾄﾞ)
	''''    Dim strPara9    As String           'ﾊﾟﾗﾒｰﾀ9(ｴﾗｰ内容)
	''''    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10(販売単価)
	''''    Dim lngPara11   As Long             'ﾊﾟﾗﾒｰﾀ11(仕切率)
	''''    Dim lngPara12   As Long             'ﾊﾟﾗﾒｰﾀ12(定価)
	''''    Dim param(13)   As OraParameter     'PL/SQLのバインド変数
	''''    Dim bolRet      As Boolean
	''''
	''''    AE_Execute_PLSQL_GetTanka = 9
	''''
	''''    '受渡し変数初期設定
	''''    strPara1 = pin_strHINCD
	''''    strPara2 = pin_strTOKCD
	''''    strPara3 = pin_strDate
	''''    strPara4 = pin_strTUKKB
	''''    lngPara5 = Pin_lngSU
	''''    strPara6 = Pin_strJDNKB
	''''    lngPara7 = 0
	''''    lngPara8 = 0
	''''    strPara9 = ""
	''''    lngPara10 = 0
	''''    lngPara11 = 0
	''''    lngPara12 = 0
	''''
	''''    'パラメータの初期設定を行う（バインド変数）
	''''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P9", strPara9, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P12", lngPara12, ORAPARM_OUTPUT
	''''
	''''    'データ型をオブジェクトにセット
	''''    Set param(1) = gv_Odb_USR1.Parameters("P1")
	''''    Set param(2) = gv_Odb_USR1.Parameters("P2")
	''''    Set param(3) = gv_Odb_USR1.Parameters("P3")
	''''    Set param(4) = gv_Odb_USR1.Parameters("P4")
	''''    Set param(5) = gv_Odb_USR1.Parameters("P5")
	''''    Set param(6) = gv_Odb_USR1.Parameters("P6")
	''''    Set param(7) = gv_Odb_USR1.Parameters("P7")
	''''    Set param(8) = gv_Odb_USR1.Parameters("P8")
	''''    Set param(9) = gv_Odb_USR1.Parameters("P9")
	''''    Set param(10) = gv_Odb_USR1.Parameters("P10")
	''''    Set param(11) = gv_Odb_USR1.Parameters("P11")
	''''    Set param(12) = gv_Odb_USR1.Parameters("P12")
	''''
	''''    '各オブジェクトのデータ型を設定
	''''    param(1).serverType = ORATYPE_CHAR
	''''    param(2).serverType = ORATYPE_CHAR
	''''    param(3).serverType = ORATYPE_CHAR
	''''    param(4).serverType = ORATYPE_CHAR
	''''    param(5).serverType = ORATYPE_NUMBER
	''''    param(6).serverType = ORATYPE_CHAR
	''''    param(7).serverType = ORATYPE_NUMBER
	''''    param(8).serverType = ORATYPE_NUMBER
	''''    param(9).serverType = ORATYPE_VARCHAR2
	''''    param(10).serverType = ORATYPE_NUMBER
	''''    param(11).serverType = ORATYPE_NUMBER
	''''    param(12).serverType = ORATYPE_NUMBER
	''''
	''''    'PL/SQL呼び出しSQL
	''''    strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
	''''
	''''    'DBアクセス
	''''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
	''''    If bolRet = False Then
	''''        GoTo AE_Execute_PLSQL_GetTanka_END
	''''    End If
	''''
	''''    '** 戻り値取得
	''''    lngPara7 = param(7).Value
	''''    lngPara8 = param(8).Value
	''''    If IsNull(param(9).Value) = False Then
	''''        strPara9 = param(9).Value
	''''    End If
	''''
	''''    If IsNull(param(10).Value) = False Then
	''''        lngPara10 = param(10).Value
	''''    Else
	''''        lngPara10 = 0
	''''    End If
	''''
	''''    If IsNull(param(11).Value) = False Then
	''''        lngPara11 = param(11).Value
	''''    Else
	''''        lngPara11 = 0
	''''    End If
	''''
	''''    If IsNull(param(12).Value) = False Then
	''''        lngPara12 = param(12).Value
	''''    Else
	''''        lngPara12 = 0
	''''    End If
	''''
	''''    Pot_curTANKA = CCur(lngPara10)
	''''    Pot_curSIKRT = CCur(lngPara11)
	''''    Pot_curTEITK = CCur(lngPara12)
	''''
	''''    'エラー情報設定
	''''    gv_Int_OraErr = lngPara8
	''''    gv_Str_OraErrText = strPara9 & vbCrLf
	''''
	''''    AE_Execute_PLSQL_GetTanka = lngPara7
	''''
	''''AE_Execute_PLSQL_GetTanka_END:
	''''    '** パラメタ解消
	''''    gv_Odb_USR1.Parameters.Remove "P1"
	''''    gv_Odb_USR1.Parameters.Remove "P2"
	''''    gv_Odb_USR1.Parameters.Remove "P3"
	''''    gv_Odb_USR1.Parameters.Remove "P4"
	''''    gv_Odb_USR1.Parameters.Remove "P5"
	''''    gv_Odb_USR1.Parameters.Remove "P6"
	''''    gv_Odb_USR1.Parameters.Remove "P7"
	''''    gv_Odb_USR1.Parameters.Remove "P8"
	''''    gv_Odb_USR1.Parameters.Remove "P9"
	''''    gv_Odb_USR1.Parameters.Remove "P10"
	''''    gv_Odb_USR1.Parameters.Remove "P11"
	''''    gv_Odb_USR1.Parameters.Remove "P12"
	''''
	''''
	''''End Function
	''''
	
	''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''''   名称：  Function AE_Get_TANKA
	'''''   概要：  単価、仕切率取得処理
	'''''   引数：　Pin_strHINCD       :製品コード
	'''''           Pin_strTOKCD       :得意先コード
	'''''           Pin_strDATE        :基準日
	'''''           Pot_curSIKRT       :仕切率
	'''''           Pot_curTANKA       :取得単価
	'''''   戻値：  0 : 正常　9 : 異常
	'''''   備考：
	''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
	'''''                                    ByVal pin_strTOKCD As String, _
	'''''                                    ByVal pin_strDate As String, _
	'''''                                    ByRef Pot_curSIKRT As Currency, _
	'''''                                    ByRef Pot_curTANKA As Currency) As Integer
	''''
	''''    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '商品マスタ検索結果
	'''''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       'ランク別仕切り率マスタ検索結果
	''''    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '得意先マスタ検索結果
	'''''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '得意先別商品ランクマスタ検索結果
	''''
	''''    AE_Get_TANKA = 9
	''''
	''''    Pot_curSIKRT = 100
	''''    Pot_curTANKA = 0
	''''
	''''    '商品マスタ検索
	''''    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
	''''        GoTo AE_Get_TANKA_ERR
	''''    End If
	''''
	''''    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
	''''        GoTo AE_Get_TANKA_ERR
	''''    End If
	''''
	'''''**********************仮☆★☆★
	''''    Pot_curSIKRT = 90
	''''    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
	'''''**********************仮☆★☆★
	'''''    '得意先マスタ検索
	'''''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '得意先別商品ランクマスタ検索
	'''''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '仕切率取得
	'''''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
	'''''        GoTo AE_Get_TANKA_ERR
	'''''    End If
	'''''
	'''''    '仕切率取得
	'''''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
	'''''
	'''''    '単価取得
	'''''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
	''''''                                 Mst_Inf_HINMTA.TEIKATK, _
	''''''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
	''''''                                 Mst_Inf_TOKMTA.TKNZRNKB)
	''''
	''''    AE_Get_TANKA = 0
	''''
	''''    Exit Function
	''''
	''''AE_Get_TANKA_ERR:
	''''
	''''End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_SysDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    DBサーバーの日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20041016|ACE)Moriga     |新規作成
	'//**************************************************************************************
	Public Function CF_Get_SysDt() As Boolean
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim Str_Val As String
		Dim Lng_Cnt As Integer
		Dim Lng_Idx As Integer
		Dim Str_SysDt As String
		
		CF_Get_SysDt = False
		
		'// 初期化
		GV_SysDate = ""
		GV_SysTime = ""
		Str_SysDt = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
		
		GV_SysDate = Mid(Str_SysDt, 1, 8)
		GV_SysTime = Mid(Str_SysDt, 9, 6)
		
		CF_Get_SysDt = True
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_UnyDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    運用日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060706|ACE)Nagasawa   |新規作成
	'//**************************************************************************************
	Public Function CF_Get_UnyDt() As Boolean
		
		'''    Dim intRet      As Integer
		'''    Dim Mst_Inf     As TYPE_DB_UNYMTA
		'''
		'''    CF_Get_UnyDt = False
		'''
		'''    '初期化
		'''    GV_UNYDate = ""
		'''
		'''    'サーバーのシステム日付取得
		'''    Call CF_Get_SysDt
		'''
		'''    '運用日付を取得
		'''    intRet = DSPUNYDT_SEARCH(Mst_Inf)
		'''    If intRet = 0 Then
		'''        GV_UNYDate = Mst_Inf.UNYDT
		'''    Else
		'''        GV_UNYDate = GV_SysDate
		'''    End If
		'''
		'''    CF_Get_UnyDt = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_PRC_UODFP53
	'   概要：  PL/SQL実行処理(自動発注処理)
	'   引数：　Pin_strPRCCASE  : 処理ケース（"1":登録 "2":訂正 "3": 削除）
	'           Pin_strJDNNO    : 受注番号
	'           Pin_strLINNO    : 行番号
	'           Pin_strSBNNO    : 製番
	'           Pin_strHINCD    : 商品コード
	'           Pin_lngBFRSU    : 変更前受注数量（登録の場合はゼロ）
	'           Pin_lngAFTSU    : 変更後受注数量（削除の場合はゼロ）
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：  自動発注処理PL/SQL(PRC_UODFP53_01)を実行する
	'           ただし、変更前受注数量＝変更後受注数量の場合は実行しない
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
	'''''                                           , ByVal pin_strJDNNO As String _
	'''''                                           , ByVal pin_strLINNO As String _
	'''''                                           , ByVal pin_strSBNNO As String _
	'''''                                           , ByVal pin_strHINCD As String _
	'''''                                           , ByVal Pin_lngBFRSU As Currency _
	'''''                                           , ByVal Pin_lngAFTSU As Currency) As Integer
	''''
	''''    Dim strSQL      As String           'SQL文
	''''    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(担当者コード)
	''''    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(クライアントID)
	''''    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(処理ケース)
	''''    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(受注番号)
	''''    Dim strPara5    As String           'ﾊﾟﾗﾒｰﾀ5(行番号)
	''''    Dim strPara6    As String           'ﾊﾟﾗﾒｰﾀ6(製番)
	''''    Dim strPara7    As String           'ﾊﾟﾗﾒｰﾀ7(製品コード)
	''''    Dim lngPara8    As Long             'ﾊﾟﾗﾒｰﾀ8(変更前受注数量)
	''''    Dim lngPara9    As Long             'ﾊﾟﾗﾒｰﾀ9(変更後受注数量)
	''''    Dim lngPara10   As Long             'ﾊﾟﾗﾒｰﾀ10(復帰ｺｰﾄﾞ)
	''''    Dim lngPara11   As Long             'ﾊﾟﾗﾒｰﾀ11(ｴﾗｰｺｰﾄﾞ)
	''''    Dim strPara12   As String * 1000    'ﾊﾟﾗﾒｰﾀ12(ｴﾗｰ内容)
	''''    Dim lngPara13   As Long             'ﾊﾟﾗﾒｰﾀ13(読込件数)
	''''    Dim lngPara14   As Long             'ﾊﾟﾗﾒｰﾀ14(登録件数)
	''''    Dim param(15)   As OraParameter     'PL/SQLのバインド変数
	''''    Dim bolRet      As Boolean
	''''
	''''    AE_Execute_PLSQL_PRC_UODFP53 = 9
	''''
	''''    '変更前受注数量＝変更後受注数量の場合は処理終了
	''''    If Pin_lngBFRSU = Pin_lngAFTSU Then
	''''        AE_Execute_PLSQL_PRC_UODFP53 = 0
	''''        Exit Function
	''''    End If
	''''
	''''    '受渡し変数初期設定
	''''    strPara1 = SSS_OPEID
	''''    strPara2 = SSS_CLTID
	''''    strPara3 = Pin_strPRCCASE
	''''    strPara4 = pin_strJDNNO
	''''    strPara5 = pin_strLINNO
	''''    strPara6 = pin_strSBNNO
	''''    strPara7 = pin_strHINCD
	''''    lngPara8 = Pin_lngBFRSU
	''''    lngPara9 = Pin_lngAFTSU
	''''    lngPara10 = 0
	''''    lngPara11 = 0
	''''    strPara12 = ""
	''''    lngPara13 = 0
	''''    lngPara14 = 0
	''''
	''''    'パラメータの初期設定を行う（バインド変数）
	''''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P6", strPara6, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_INPUT
	''''    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P11", lngPara11, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P12", strPara12, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P13", lngPara13, ORAPARM_OUTPUT
	''''    gv_Odb_USR1.Parameters.Add "P14", lngPara14, ORAPARM_OUTPUT
	''''
	''''    'データ型をオブジェクトにセット
	''''    Set param(1) = gv_Odb_USR1.Parameters("P1")
	''''    Set param(2) = gv_Odb_USR1.Parameters("P2")
	''''    Set param(3) = gv_Odb_USR1.Parameters("P3")
	''''    Set param(4) = gv_Odb_USR1.Parameters("P4")
	''''    Set param(5) = gv_Odb_USR1.Parameters("P5")
	''''    Set param(6) = gv_Odb_USR1.Parameters("P6")
	''''    Set param(7) = gv_Odb_USR1.Parameters("P7")
	''''    Set param(8) = gv_Odb_USR1.Parameters("P8")
	''''    Set param(9) = gv_Odb_USR1.Parameters("P9")
	''''    Set param(10) = gv_Odb_USR1.Parameters("P10")
	''''    Set param(11) = gv_Odb_USR1.Parameters("P11")
	''''    Set param(12) = gv_Odb_USR1.Parameters("P12")
	''''    Set param(13) = gv_Odb_USR1.Parameters("P13")
	''''    Set param(14) = gv_Odb_USR1.Parameters("P14")
	''''
	''''    '各オブジェクトのデータ型を設定
	''''    param(1).serverType = ORATYPE_CHAR
	''''    param(2).serverType = ORATYPE_CHAR
	''''    param(3).serverType = ORATYPE_CHAR
	''''    param(4).serverType = ORATYPE_CHAR
	''''    param(5).serverType = ORATYPE_CHAR
	''''    param(6).serverType = ORATYPE_CHAR
	''''    param(7).serverType = ORATYPE_CHAR
	''''    param(8).serverType = ORATYPE_NUMBER
	''''    param(9).serverType = ORATYPE_NUMBER
	''''    param(10).serverType = ORATYPE_NUMBER
	''''    param(11).serverType = ORATYPE_NUMBER
	''''    param(12).serverType = ORATYPE_VARCHAR2
	''''    param(13).serverType = ORATYPE_NUMBER
	''''    param(14).serverType = ORATYPE_NUMBER
	''''
	''''    'PL/SQL呼び出しSQL
	''''    strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"
	''''
	''''    'DBアクセス
	''''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
	''''    If bolRet = False Then
	''''        GoTo AE_Execute_PLSQL_PRC_UODFP53_END
	''''    End If
	''''
	''''    '** 戻り値取得
	''''    lngPara10 = param(10).Value
	''''    lngPara11 = param(11).Value
	''''    If IsNull(param(12).Value) = False Then
	''''        strPara12 = param(12).Value
	''''    End If
	''''    lngPara13 = param(13).Value
	''''    lngPara14 = param(14).Value
	''''
	''''    'エラー情報設定
	''''    gv_Int_OraErr = lngPara11
	''''    gv_Str_OraErrText = Trim(strPara12) & vbCrLf
	''''
	''''    AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
	''''
	''''AE_Execute_PLSQL_PRC_UODFP53_END:
	''''    '** パラメタ解消
	''''    gv_Odb_USR1.Parameters.Remove "P1"
	''''    gv_Odb_USR1.Parameters.Remove "P2"
	''''    gv_Odb_USR1.Parameters.Remove "P3"
	''''    gv_Odb_USR1.Parameters.Remove "P4"
	''''    gv_Odb_USR1.Parameters.Remove "P5"
	''''    gv_Odb_USR1.Parameters.Remove "P6"
	''''    gv_Odb_USR1.Parameters.Remove "P7"
	''''    gv_Odb_USR1.Parameters.Remove "P8"
	''''    gv_Odb_USR1.Parameters.Remove "P9"
	''''    gv_Odb_USR1.Parameters.Remove "P10"
	''''    gv_Odb_USR1.Parameters.Remove "P11"
	''''    gv_Odb_USR1.Parameters.Remove "P12"
	''''    gv_Odb_USR1.Parameters.Remove "P13"
	''''    gv_Odb_USR1.Parameters.Remove "P14"
	''''
	''''End Function
End Module