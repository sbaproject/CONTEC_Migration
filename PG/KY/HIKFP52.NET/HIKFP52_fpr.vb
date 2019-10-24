Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'商品マスタ情報
	Public Structure UODDL52_TYPE_HINMTA
		Dim DATKB As String '削除区分
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
	End Structure
	
	Public UODDL52_HINMTA_Inf As UODDL52_TYPE_HINMTA
	
	'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	
	' === 20060802 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
	Public gv_bolKeyFlg As Boolean
	Public gv_bolHIKFP52_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	' === 20060802 === INSERT E -
	
	''**ﾁｪｯｸ関数関連 Start **
	'//戻値
	Public Const CHK_OK As Short = 0 '正常
	Public Const CHK_WARN As Short = 1 '警告
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '未入力エラー
	Public Const CHK_ERR_ELSE As Short = 11 'その他エラー
	
	'F_Chk_Jge_Action関数用
	Public Const CHK_KEEP As Short = 0 'チェック続行
	Public Const CHK_STOP As Short = 1 'チェック中断
	
	'**ﾁｪｯｸ関数関連 End  **
	
	'//F_Set_Next_Focus処理モード
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURNと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHTと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWNと同様の制御
	'//F_Dsp_Item_Detail処理モード
	Public Const DSP_SET As Short = 0 '表示
	Public Const DSP_CLR As Short = 1 'クリア
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_Change
	'   概要：  対象項目のCHANGEの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽの場合
				'現在のﾃｷｽﾄ上の選択状態を取得
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
				Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'現在の値を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_NUM
						'数値項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_DATE
						'日付項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_CODE, IN_TYP_STR
						'コード、文字項目
						Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
							'変更後の値変換
							Case IN_STR_TYP_N
								'全角の場合
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
										Wk_EditMoji = Wk_EditMoji & "　"
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
							Case Else
								'全角以外
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
										Wk_EditMoji = Wk_EditMoji & Space(2)
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
						End Select
					Case IN_TYP_YYYYMM
						'年月項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case IN_TYP_HHMM
						'時刻項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case Else
				End Select
				
				'編集後の文字を表示形式に変換
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
				
				'選択文字と入力文字の置き換え
				'文字設定
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'入力後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	'ADD START FKS)INABA 2009/09/30 **********************************************************************************************
	'連絡票№FC09100103
	'削除できる引当内訳ファイルかどうかチェックを行う
	'引数：
	'
	'戻り値：0  削除OK
	'　　　：1  削除NG
	'　　　：-1 エラー発生
	Function F_DEL_DTLTRA_CHK(ByRef ps_TRAKB As String, ByRef ps_TRANO As String, ByRef ps_MITNOV As String, ByRef ps_LINNO As String, ByRef ps_TRADT As String, ByRef ps_HIKNO As String, ByRef ps_ATMNKB As String, ByRef ps_HINCD As String, ByRef ps_PUDLNO As String) As Short
		Dim ls_sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim lb_Ret As Boolean
		Dim lw_cnt As Short
		On Error GoTo F_DEL_DTLTRA_CHK_ERR
		F_DEL_DTLTRA_CHK = -1
		ls_sql = " SELECT COUNT(*) CNT "
		Select Case ps_TRAKB
			Case "2" '受注
				ls_sql = ls_sql & "  FROM JDNTRA "
				ls_sql = ls_sql & " WHERE (DATNO ,LINNO) IN "
				ls_sql = ls_sql & "                      (SELECT MAX(DATNO),LINNO "
				ls_sql = ls_sql & "                         FROM JDNTRA"
				ls_sql = ls_sql & "                        WHERE JDNNO = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "                          AND LINNO = '" & Trim(ps_LINNO) & "'"
				ls_sql = ls_sql & "                     GROUP BY JDNNO,LINNO) "
				ls_sql = ls_sql & "                      "
				ls_sql = ls_sql & "   AND DATKB  = '1' "
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
			Case "3" '支給
				ls_sql = ls_sql & "  FROM SKYTBL"
				ls_sql = ls_sql & " WHERE DATKB  = '1' "
				ls_sql = ls_sql & "   AND SPRNOKDT  = '" & Trim(ps_TRADT) & "'"
				ls_sql = ls_sql & "   AND HINCD  = '" & Trim(ps_HINCD) & "'"
				ls_sql = ls_sql & "   AND SBNNO  = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
				ls_sql = ls_sql & "   AND SPRRENNO  = '" & Trim(ps_LINNO) & "'"
				ls_sql = ls_sql & "   AND PLANKB = '" & ps_MITNOV & "'"
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				
			Case "4" '製番出庫
				ls_sql = ls_sql & "  FROM SBNTRA "
				ls_sql = ls_sql & " WHERE SBNNO  = '" & Trim(ps_TRANO) & "'"
				ls_sql = ls_sql & "   AND HINCD  = '" & Trim(ps_HINCD) & "'"
				ls_sql = ls_sql & "   AND PUDLNO = '" & Trim(ps_PUDLNO) & "'"
				ls_sql = ls_sql & "   AND FRDSU  <> 0 "
				ls_sql = ls_sql & "   AND DATKB  = '1' "
				
			Case Else '見積等
				'削除条件なし(全削除)
				F_DEL_DTLTRA_CHK = 0
				Exit Function
				
		End Select
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lw_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT", 0)
		'判定
		
		If lw_cnt = 0 Then
			F_DEL_DTLTRA_CHK = 0
		Else
			F_DEL_DTLTRA_CHK = 1
		End If
		
F_DEL_DTLTRA_CHK_END: 
		On Error GoTo 0
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
F_DEL_DTLTRA_CHK_ERR: 
		F_DEL_DTLTRA_CHK = -1
		GoTo F_DEL_DTLTRA_CHK_END
		
	End Function
	'ADD  END  FKS)INABA 2009/09/30 **********************************************************************************************
	
	'======================= 変更部分 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Now_Dt As Date
		Dim Wk_Mode As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Now_Dt = Now
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'全体初期化の場合
			If Wk_Mode = 0 Then
				'ボディ部以降の項目を全ﾌｫｰｶｽなしとする
				If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'個別初期化
			Select Case Index_Wk
				Case Else
			End Select
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		'    Dim Index_Bd_Wk         As Integer
		'    Dim Wk_Bd_Index_S       As Integer
		'    Dim Wk_Bd_Index_E       As Integer
		'    Dim Wk_Mode             As Integer
		'    Dim Wk_Index            As Integer
		'    Dim Wk_Row              As Integer
		'
		'    If pm_Bd_Index = -1 Then
		'        Wk_Bd_Index_S = 1
		'        Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
		'
		'        '画面ボディ情報
		'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		'
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''        'スクロール初期化
		''        '最大値
		''        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '最小値
		''        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '最大ｽｸﾛｰﾙ量
		''        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Cnt - 1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '最小ｽｸﾛｰﾙ量
		''        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''        '初期値
		''        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'        Wk_Mode = BODY_ALL_CLR
		'    Else
		'        Wk_Bd_Index_S = pm_Bd_Index
		'        Wk_Bd_Index_E = pm_Bd_Index
		'        Wk_Mode = BODY_ALL_ONLY
		'    End If
		'
		'    For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
		'
		'        '共通初期化
		'        Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
		'
		'        '配列０の初期情報を対象行にコピー
		'        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
		'
		'        '全体初期化の場合
		'        If Wk_Mode = BODY_ALL_CLR Then
		'            '全行初期状態
		'            pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
		'        End If
		'
		'        '個別初期化
		'''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''        '以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
		''        '(対象の明細の番号情報だけが必要、)
		''        Wk_Index = CInt(BD_LINNO(Index_Bd_Wk).Tag)
		'''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		''        'Dsp_Body_Infの行ＮＯに変換
		''        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		'''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''        'Dsp_Body_Infに値を初期値を設定
		''        Call F_Init_Dsp_Body(Wk_Row, pm_All)
		'''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'    Next
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'案件ＩＤにフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
	'======================= 変更部分 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_GotFocus
	'   概要：  対象項目のGOTFOCUSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'ﾌｫｰｶｽを受け取れない場合
			'@'        '次の項目へﾌｫｰｶｽ移動
			'@'        If TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 Then
			'@'            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, pm_All)
			'@'        Else
			'@'        '元の項目へﾌｫｰｶｽ移動
			'@'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
			'@'        End If
			
			'元の項目へﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			'移動前と異なる場合のみ退避
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'移動後のｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyPress
	'   概要：  対象項目のKEYPRESSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'入力フラグ初期化
		Input_Flg = False
		'明細部再作成フラグ初期化
		Re_Body_Crt = False
		
		'以下の入力の場合、無視する
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'入力文字取得
		wk_Moji = Chr(pm_KeyAscii)
		
		'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'現在の値を取得
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				All_Sel_Flg = True
			End If
			
			'入力コード判定
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
				'入力可能文字の場合
				
				'入力可能な文字の場合、入力後処理、明細部再作成を行う
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str関数の文字変更を考慮
				pm_KeyAscii = Asc(wk_Moji)
				
				'日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
				'表示形式が決まっているため一つずつ入力させる
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'全選択時
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'詰文字が左詰以外の場合
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'編集後の文字を表示形式に変換
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'編集後のSelStartを決定
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'右端へ移動
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'詰文字が左詰以外の場合
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'削除後の文字置き換え
					'文字設定
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0
					
					'編集後のSelStartを決定
					' === 20060823 === UPDATE S - ACE)Nagasawa 全選択時、２文字以上入力すると１文字目が入力されない現象への対応
					'                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					' === 20060823 === UPDATE E -
					'編集後のSelLengthを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
					' === 20060731 === INSERT S - ACE)Nagasawa １桁項目で入力後にフォーカス移動しないことへの対応
					'数値項目特別処理
					If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'小数部があり小数桁数と設定値が同じ場合
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'数値項目以外
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'編集後の文字がMAXの場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060731 === INSERT E
					
				Else
					'部分選択もしくは、選択なし
					
					If Act_SelLength = 0 Then
						'選択なしの場合(挿入状態)
						'挿入部分の前の文字を取得
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 1 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'空白除去後の現在の文字がMAXの場合、オーバーフロー
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'一番右でオーバーフローした場合、次の項目へ
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'編集前の開始位置が一番右の場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'入力不可
									Beep()
								End If
							Else
								
								'編集後の移動先を判定
								If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
									'詰文字が左詰の場合
								Else
									'編集後のSelStartを決定
									If Act_SelStart + 1 > Len(Wk_CurMoji) Then
										'１つ右の位置が右端の場合
										Wk_SelStart = Len(Wk_CurMoji)
									Else
										'１つ右へ
										Wk_SelStart = Act_SelStart + 1
									End If
									'編集後のSelLengthを決定
									Wk_SelLength = 0
									
									'編集後のSelStartを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'編集後のSelLengthを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								End If
								
								'入力不可
								Beep()
							End If
							
							'入力不可
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部で整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'編集後のSelStartを決定
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'１つ右の位置が右端の場合
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'１つ右へ
							Wk_SelStart = Act_SelStart + 1
						End If
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'編集後の移動先を判定
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'編集後の開始位置が一番右の場合
								'数値項目特別処理
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'小数部があり小数桁数と設定値が同じ場合
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'編集後の文字がMAXの場合
											'現在ﾌｫｰｶｽ位置から右へ移動
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'数値項目以外
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
								
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'一部選択
						'現在選択されている文字の１桁を取得
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'選択文字が空文字以外でかつ入力対象の文字以外の場合
							
							'入力不可
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 0 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部無しの場合
							'整数部ありで整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集前の開始位置が最後の文字以降の場合
							'編集後のSelStartを決定
							Wk_SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							Wk_SelLength = 0
						Else
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'入力可能な文字が１桁の場合
								'開始位置を一番右に設定
								'編集後のSelStartを決定
								Wk_SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								Wk_SelLength = 0
							End If
							
						End If
						
						'編集後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'編集後の移動先を判定
						If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集後の開始位置が最後の文字以降の場合
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'小数部があり小数桁数と設定値が同じ場合
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'数値項目以外
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'編集後の文字がMAXの場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'入力コード以外
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpaceキー
						pm_KeyAscii = 0
						' === 20061228 === INSERT S - ACE)Nagasawa BackSpaceキー押下時の動作修正
						Input_Flg = True
						' === 20061228 === INSERT E -
						
						'日付/年月/時刻の場合
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'削現在の開始位置から左へ移動し文字が入力対象かを判定
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'入力文字でない場合
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'編集後のSelLengthを決定
								Wk_SelLength = Act_SelLength
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								
								'削除不可
								Exit Function
							Case Else
								
						End Select
						
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'開始位置が左の場合、終了
							If Act_SelStart = 0 Then
								'削除不可
								Exit Function
							End If
							
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'削除対象の文字が小数点の場合
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'削除後の桁数オーバーの場合
										'削除不可
										Exit Function
									End If
								End If
							End If
							
							'削除文字の判定
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'削除文字が入力対象の文字の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'削除文字が入力対象の文字の以外場合
								'そのまま
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'削除後のSelStartを決定
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'削除後に現在の開始位置からの文字が入力対象かを判定
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'入力文字でない場合、右へ移動
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'数値項目で未入力の場合は、一番右を開始位置に設定
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'編集後のSelLengthを決定
									Wk_SelLength = 0
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If Act_SelStart = 0 Then
								'開始位置が一番左の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
							Else
								'文字編集
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart - 1
							End If
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'編集後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Case Else
						pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'入力後処理
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'明細入力後の後処理
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_MouseDown
	'   概要：  対象項目のMOUSEDOWNの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		' === 20060907 === INSERT S - ACE)Sejima
		Dim bolSameCtl As Boolean
		' === 20060907 === INSERT E
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			' === 20060907 === INSERT S - ACE)Sejima
			bolSameCtl = False
			' === 20060907 === INSERT E
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'右クリックしたコントロールがアクティブなコントロールと一致
				'カーソル制御用テキストにフォーカスを一時的に退避
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
				bolSameCtl = True
				' === 20060907 === INSERT E
			End If
			
			'｢項目内容コピー｣判定
			FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'｢項目内容に貼り付け｣判定
			FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
				'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
				pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			' === 20060907 === INSERT S - ACE)Sejima
			'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
			'以降の処理は行わない。
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			' === 20060907 === INSERT E
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			' === 20060907 === INSERT S - ACE)Sejima
			If bolSameCtl = True Then
				' === 20060907 === INSERT E
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
			End If
			' === 20060907 === INSERT E
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Input_Aft
	'   概要：  画面で項目入力された場合の後処理を行います
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'明細の再作成を行う
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Befe_Focus
	'   概要：  前のフォーカス位置設定(LEFTなど)
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'次の項目を検索
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'フッタ部からボディ部へ移動する場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'ボディ部からヘッダ部へ移動する場合
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
					
					'画面の内容を退避
					Call CF_Body_Bkup(pm_All)
					'移動可能行を一番上に表示した場合の最上明細インデックスを設定
					pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'縦スクロールバーを設定
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					End If
					'画面表示
					Call CF_Body_Dsp(pm_All)
					
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
				End If
			End If
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'実行指定がある場合(基本あり)
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	'★入力コントロールが１つのため、不要
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Next_Focus
	'   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Set_Next_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Mode As Integer, ByRef pm_Move_Flg As Boolean, pm_All As Cls_All, Optional pm_Run_Flg As Boolean = True) As Integer
	'    Dim Sta_Index           As Integer
	'    Dim Index_Wk            As Integer
	'    Dim Rtn_Chk             As Integer
	'    Dim Bd_Index            As Integer
	'    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
	'    Dim Focus_Ctl_Ok_Lst_Idx    As Integer
	'    Dim Focus_Ctl_Ok_Fst_Idx_Wk As Integer
	'    Dim Cur_Top_Index       As Integer
	'    Dim bolDsp              As Boolean
	'
	'    '移動フラグ初期化
	'    pm_Move_Flg = False
	'
	'    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CInt(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
	'    'ボディ部
	'        'Dsp_Body_Infの行ＮＯを取得
	'        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
	'
	'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
	'        '最終準備行の場合
	'            '入力可能な最初のインデックスを取得
	'            Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'
	'            If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
	'            '入力可能な最初の項目の場合
	'                'モードにより検索開始位置を決定
	'                Select Case pm_Mode
	'                    Case NEXT_FOCUS_MODE_KEYRETURN
	'                    'KEYRETURNの場合
	'                        '検索開始はフッタ部の最初の項目から
	'                        Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
	'
	'                    Case NEXT_FOCUS_MODE_KEYRIGHT
	'                    'KEYRIGHTの場合
	'                        '割当ｲﾝﾃﾞｯｸｽ取得
	'                        '検索開始は対象の項目の次
	'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'
	'                End Select
	'            Else
	'                '検索開始は対象の項目の次
	'                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'            End If
	'
	'        Else
	'        '最終準備行以外の場合
	'            If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
	'            '表示されている最終行の場合
	'                '入力可能な最後のインデックスを取得
	'                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'
	'                If CInt(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
	'                '入力可能な最後の項目の場合
	'                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
	'                    '最終準備行以外＆画面上の最終行＆最終項目
	'                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
	'
	'                        '画面の内容を退避
	'                        Call CF_Body_Bkup(pm_All)
	'                        '移動可能行を一番下に表示した場合の最上明細インデックスを設定
	'                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
	'                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
	'                            '縦スクロールバーを設定
	'                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
	'                        End If
	'                        '画面表示
	'                        Call CF_Body_Dsp(pm_All)
	'
	'                        '明細１番下行の入力可能な最初のインデックスを取得
	'                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
	'                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
	'                            '明細１番下行の最初の項目の一つ前から検索
	'                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
	'                        Else
	'                            '検索開始は対象の項目の次
	'                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                        End If
	'
	'                     Else
	'                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
	'                        '検索開始は対象の項目の次
	'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                     End If
	'                Else
	'                '入力可能な最後の項目以外の場合
	'                    '検索開始は対象の項目の次
	'                    Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'                End If
	'
	'            Else
	'            '最終行以外場合
	'                '検索開始は対象の項目の次
	'                Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'            End If
	'        End If
	'
	'    Else
	'    'ボディ部以外
	'        '検索開始は対象の項目の次
	'        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
	'    End If
	'
	'    bolDsp = False
	'    '次の項目を検索
	'    For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
	'
	'        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD _
	''        And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
	'            'ﾍｯﾀﾞ部ﾁｪｯｸ
	'            Rtn_Chk = F_Ctl_Head_Chk(pm_All)
	'            If Rtn_Chk = CHK_OK Then
	'                'チェックOKの場合
	''                If bolDsp = False Then
	''                    '更新処理
	''                    Rtn_Chk = F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
	''                    If Rtn_Chk <> CHK_OK Then
	''                        'データなしの場合
	''                        Exit For
	''                    End If
	''                    '【※注意※】強引に、ｲﾝﾃﾞｯｸｽをフッタ部の頭にジャンプさせている。
	''                    'ループ回数減のため。明細に入力項目がないから可能。
	''                    Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx
	''
	''                    bolDsp = True
	''                End If
	'
	'            Else
	'                'チェックＮＧの場合
	'                Exit For
	'            End If
	'        End If
	'
	'        'ﾌｫｰｶｽ移動がOK
	'        If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
	'            If pm_Run_Flg = True Then
	'            '実行指定がある場合(基本あり)
	'                'ﾌｫｰｶｽ移動
	'                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
	'            End If
	'            '移動フラグ決定
	'            pm_Move_Flg = True
	'            Exit For
	'        End If
	'
	'    Next
	'
	'    '最終項目まで検索終了時
	'    If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
	'        'モードにより検索終了後の処理を決定
	'        Select Case pm_Mode
	'            Case NEXT_FOCUS_MODE_KEYRETURN
	'            'KEYRETURNの場合
	''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'                '移動先が検索不可の場合
	'                '更新前チェック⇒ＤＢ更新⇒初期化
	'                Call F_Ctl_Upd_Process(pm_All)
	''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	'                pm_Move_Flg = True
	'            Case NEXT_FOCUS_MODE_KEYRIGHT
	'            'KEYRIGHTの場合
	'        End Select
	'    End If
	'
	'End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Left_Next_Focus
	'   概要：  Left押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'１文字目を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'詰文字が左詰以外の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'開始位置が一番左の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
				Else
					
					'左に１桁ずつずらし入力可能な文字を検索
					Wk_SelStart = -1
					For Wk_Point = Act_SelStart - 1 To 0 Step -1
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
							Wk_SelStart = Wk_Point
							Exit For
						End If
					Next 
					
					If Wk_SelStart = -1 Then
						'選択可能な文字がない場合
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Else
						'選択可能な文字がある場合
						If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
							'移動前の選択開始位置が一番右以外でかつ
							'選択文字数がない場合のみ、
							'同じ項目で移動する場合に選択文字数は継続する
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					End If
					
				End If
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Right_Next_Focus
	'   概要：  Right押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'最終文字を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'詰文字が左詰以外の場合
					'１桁目を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = 1
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'選択開始位置が一番右の場合
					'★入力コントロールが１つのため、不要
					'                'ENTキー押下と同様に次の項目へ
					'                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					'選択開始位置が一番右でない場合
					
					'１つ右の１桁を取得
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'次の１桁がない場合
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'一番右へ移動し選択なし状態に
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
						Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'一番右へ移動し選択なし状態に
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							Else
								'★入力コントロールが１つのため、不要
								'                            'ENTキー押下と同様に次の項目へ
								'                            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						
						'右に１桁ずつずらし入力可能な文字を検索
						Next_SelStart = -1
						For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1
							
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
							
							Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
								Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
									'日付/年月/時刻項目の場合
									'入力可能文字＆と空白も移動可能
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
										Next_SelStart = Wk_Point
										Exit For
									End If
								Case Else
									'日付/年月/時刻項目以外の場合
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
										Next_SelStart = Wk_Point
										Exit For
									End If
									
							End Select
						Next 
						
						If Next_SelStart = -1 Then
							'選択可能な文字がない場合
							'★入力コントロールが１つのため、不要
							'                        'ENTキー押下と同様に次の項目へ
							'                        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'選択可能な文字がある場合
							
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'同じ項目で移動する場合に選択文字数は継続する
								Wk_SelLength = 0
							Else
								Wk_SelLength = 1
							End If
							
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						End If
					End If
				End If
				
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'★入力コントロールが１つのため、不要
			'        'ENTキー押下と同様に次の項目へ
			'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Down_Next_Focus
	'   概要：  Down押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
					'項目数を超えた場合
					'★入力コントロールが１つのため、不要
					'                'ENTキー押下と同様に次の項目へ
					'                Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番下に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'★入力コントロールが１つのため、不要
								'                            '同一項目の１つ前からENTキー押下と同様に次の項目へ
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'★入力コントロールが１つのため、不要
								'                            '同一項目の１つ前からENTキー押下と同様に次の項目へ
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'★入力コントロールが１つのため、不要
								'                            'ENTキー押下と同様に次の項目へ
								'                            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'★入力コントロールが１つのため、不要
						'                    'ENTキー押下と同様に次の項目へ
						'                    Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'明細部以外の場合
			'★入力コントロールが１つのため、不要
			'        'ENTキー押下と同様に次の項目へ
			'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Up_Next_Focus
	'   概要：  Up押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'マイナスの場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番上に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'入力可能な最初の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'ヘッダ部の最後の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
					Else
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'明細部以外の場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	'======================= 変更部分 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Action
	'   概要：  各チェック関数のチェック前の
	'　　　　　 チェック続行を判定
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'続行
		Rtn_Cd = CHK_KEEP
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'｢KEYRETURN｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'一括チェックなど｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'チェックを中断
			'チェック関数呼出元処理をクリア
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Msg_Move
	'   概要：  各チェック関数のチェック後の
	'　　　　　 メッセージ、ステータス、移動制御
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'メッセージ表示なし
		pm_Msg_Flg = False
		'移動可
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'チェックＯＫ
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'前回と同じチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = True
								Else
									'前回と異なるチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'前回と同じチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'前回と異なるチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＯＫ
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'チェックエラーとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'｢KEYRETURN｣
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＮＧ
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'チェック関数呼出元処理をクリア
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_HINCD
	'   概要：  製品コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_HINCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_HINMTA
		Dim Mst_Inf_Clr As TYPE_DB_HINMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_HINCD = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_HINMTA_Clear(Mst_Inf)
		
		'未入力チェック
		If CF_Trim_Item((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf) = "" Then
			'未入力以外のチェック済かどうかの考慮は今回不要
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = gc_strMsgHIKFP52_A_COMPLETEC
			UODDL52_HINMTA_Inf.DATKB = Mst_Inf_Clr.DATKB
			UODDL52_HINMTA_Inf.HINCD = Mst_Inf_Clr.HINCD '製品コード0          000000
			UODDL52_HINMTA_Inf.HINNMA = Mst_Inf_Clr.HINNMA '型式
			UODDL52_HINMTA_Inf.HINNMB = Mst_Inf_Clr.HINNMB '品名
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKFP52_E_INPUTERR
			Else
				'マスタチェック
				If DSPHINCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'論理削除チェック
					' === 20060921 === UPDATE S - ACE)Nagasawa 検索不可でもエラーとしない
					'                If Mst_Inf.DATKB = gc_strDATKB_DEL Or Mst_Inf.DSPKB = gc_strDSPKB_NG Then
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						' === 20060921 === UPDATE E -
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_E_DELDATA
					End If
					
					' === 20060921 === DELETE S - ACE)Nagasawa 検索不可でもエラーとしない
					'                '検索不可データチェック
					'                If Mst_Inf.DSPKB = gc_strDSPKB_NG Then
					'                    Retn_Code = CHK_ERR_ELSE
					'                    Err_Cd = gc_strMsgHIKFP52_E_011
					'                End If
					' === 20060921 === DELETE E -
					
					'在庫管理区分チェック
					If Err_Cd = "" And Mst_Inf.ZAIKB = gc_strZAIKB_NG Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_Q_ZAIKBNG
					End If
					
					'商品種別チェック
					If Err_Cd = "" And Mst_Inf.HINID > gc_strHINID_SETUP Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKFP52_E_NOTSEIHIN
					End If
					
					'チェックＯＫ
					If Err_Cd = "" Then
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						UODDL52_HINMTA_Inf.DATKB = Mst_Inf.DATKB
						UODDL52_HINMTA_Inf.HINCD = Mst_Inf.HINCD '製品コード0          000000
						UODDL52_HINMTA_Inf.HINNMA = Mst_Inf.HINNMA '型式
						UODDL52_HINMTA_Inf.HINNMB = Mst_Inf.HINNMB '品名
					End If
					
				Else
					'該当データ無し
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKFP52_E_NODATA01
					
				End If
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_HD_HINCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_Item_Detail
	'   概要：  各項目の画面表示
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_HINCD.Name
				'製品コードによる画面表示
				Call F_Dsp_HD_HINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_HINCD_Inf
	'   概要：  製品コードによる画面表示
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_HINCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			'製品コードが変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_Dsp_Sub_Inf.Ctl.Text <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'【型式】
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODDL52_HINMTA_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'【品名】
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODDL52_HINMTA_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'【型式】
			Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			'【品名】
			Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = pm_Dsp_Sub_Inf.Ctl.Text
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Chk
	'   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'①基本入力内容のチェック
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_HINCD.Name
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'製品コードのﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_Chk
	'   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		'======================= 変更部分 2006.06.12 Start =================================
		Dim Dsp_Mode As Short
		'======================= 変更部分 2006.06.12 End =================================
		Dim strUDNYTDTFM As String
		Dim strUDNYTDTTO As String
		Dim strDEFNOKDTFM As String
		Dim strDEFNOKDTTO As String
		Dim strJDNTRKB As String
		Dim intHSYYT As Short
		Dim Err_Cd As String
		Dim Err_Index As Short
		Dim Chk_Move As Boolean
		Dim Msg_Flg As Boolean
		Dim Trg_Index As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			'======================= 変更部分 2006.06.12 Start =================================
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			
			'取得内容表示/クリア
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			'======================= 変更部分 2006.06.12 End =================================
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				'（標準の動き）
				'            'ﾁｪｯｸ後移動なし
				'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				'（瀬島案ボツ）
				''            If Rtn_Chk <> CHK_OK _
				'''            Or pm_All.Dsp_Base.Head_Ok_Flg <> False Then
				''                'チェックＯＫでなく、かつ
				''                'ヘッダ部のチェックが初めてでない場合
				''                'フッタ部を開放する
				''                '（★コントロールがひとつしかない本画面のような場合の特別な措置）
				''                Call F_Foot_In_Ready(pm_All)
				''                'チェックＯＫ
				''                pm_All.Dsp_Base.Head_Ok_Flg = True
				''            End If
				'ダミーコントロールへ移動
				Trg_Index = CShort(FR_SSSMAIN.TX_Dummy.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
			
		Next 
		
		'関連ﾁｪｯｸ
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Err_Cd = ""
		Err_Index = 0
		
		'関連チェックエラー発生
		If Err_Cd <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			'フォーカス移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Err_Index), pm_All)
			
			'処理結果は「エラー」
			Rtn_Chk = CHK_ERR_ELSE
		End If
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'    If Rtn_Chk = CHK_OK _
		''    And pm_All.Dsp_Base.Head_Ok_Flg = False Then
		'        'チェックＯＫでかつ
		'        'ヘッダ部のチェックが初めての場合
		'        '１行目のボディ部を準備最終行として開放する
		'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
		'        'フッタ部を開放する
		'        Call F_Foot_In_Ready(pm_All)
		'        'チェックＯＫ
		'        pm_All.Dsp_Base.Head_Ok_Flg = True
		'    End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Foot_In_Ready
	'   概要：  フッタ部の入力準備
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		'フッタ部内で処理
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
			Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				Case FR_SSSMAIN.TX_Dummy.Name
					'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
					'初期状態で入力可能なｺﾝﾄﾛｰﾙ
					'入力可能
					Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
			End Select
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_First_Day
	'   概要：  月初日取得
	'   引数：　pm_strYYYYMM          :年月（YYYYMM）
	'   戻値：　月初日（YYYYMMDD）
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_First_Day(ByRef pm_strYYYYMM As String) As String
		
		Dim Ret_Value As String
		Dim strWk As String
		Dim strWk2 As String
		
		Ret_Value = ""
		
		strWk = pm_strYYYYMM & "01"
		strWk2 = VB6.Format(strWk, "@@@@/@@/@@")
		
		'日付として正しければ、値を返す
		If IsDate(strWk2) = True Then
			Ret_Value = strWk
		End If
		
		CF_Get_First_Day = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Last_Day
	'   概要：  月末日取得
	'   引数：　pm_strYYYYMM          :年月（YYYYMM）
	'   戻値：　月末日（YYYYMMDD）
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Last_Day(ByRef pm_strYYYYMM As String) As String
		
		Dim Ret_Value As String
		Dim strWk As String
		Dim strWk2 As String
		
		Ret_Value = ""
		
		strWk = pm_strYYYYMM & "01"
		strWk2 = VB6.Format(strWk, "@@@@/@@/@@")
		
		'日付として正しければ、月末日を算出、値を返す
		If IsDate(strWk2) = True Then
			'今月初日の、１ヶ月後の、１日前
			strWk = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(strWk2))), "yyyymmdd")
			Ret_Value = strWk
		End If
		
		CF_Get_Last_Day = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Inp_Item_Focus_Ctl
	'   概要：  入力コントロールの使用可否制御
	'   引数：　pm_Value              :設定値
	'           pm_All                :全構造体
	'   戻値：　処理結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Inp_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		F_Set_Inp_Item_Focus_Ctl = 9
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS
	'   概要：  検索画面表示
	'   引数：　pm_All          :全構造体
	'   戻値：　なし
	'   備考：  検索画面表示イメージをクリックした際の処理
	'           フォーカスは入力コントロールにあるままの状態
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
		
		Dim Cursor_Index As Short
		Dim Trg_Index As Short
		
		'現在のフォーカス取得コントロールのインデックス
		Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
		
		Select Case Cursor_Index
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'製品
				'            Trg_Index = CInt(FR_SSSMAIN.CS_HINCD.Tag)
				'            Call F_Ctl_CS_HINCD(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				Call F_Ctl_CS_HINCD(pm_All)
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_HINCD
	'   概要：  対象項目の製品検索ﾎﾞﾀﾝの制御
	'   引数：　pm_All        : 全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_HINCD(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
		
		'ﾌｫｰｶｽを製品コードへ移動
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'ﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			' === 20060802 === INSERT S - ACE)Nagasawa
			gv_bolHIKFP52_LF_Enable = False
			' === 20060802 === INSERT E -
			
			' === 20060907 === INSERT S - ACE)Hashiri 仮製品を含めて検索
			WLSHIN_KHNSEARCH = "1"
			' === 20060907 === INSERT E -
			
			'======================= 変更部分 2006.06.12 Start =================================
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			'======================= 変更部分 2006.06.12 End =================================
			
			'製品検索画面を呼び出す
			WLSHIN.ShowDialog()
			' === 20060802 === INSERT S - ACE)Nagasawa
			WLSHIN.Close()
			
			gv_bolHIKFP52_LF_Enable = True
			' === 20060802 === INSERT E -
			
			If WLSHIN_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSHIN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_WLS_Close
	'   概要：  各検索画面クローズ処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'製品
		WLSHIN.Close()
		'UPGRADE_NOTE: オブジェクト WLSHIN をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		WLSHIN = Nothing
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_MN_Enabled
	'   概要：  メニュー使用可否制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_MN_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_MN_Enabled = 9
		
		'現在のフォーカス位置に応じて、各ｺﾝﾄﾛｰﾙの使用可否を制御
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'登録
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'削除（使用不可！！）
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'画面印刷
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'終了
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'画面初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_APPENDC.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行削除
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行挿入
				Trg_Index = CShort(FR_SSSMAIN.MN_InsertDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoDe.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'切り取り
				Trg_Index = CShort(FR_SSSMAIN.MN_Cut.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'コピー
				Trg_Index = CShort(FR_SSSMAIN.MN_Copy.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'貼り付け
				Trg_Index = CShort(FR_SSSMAIN.MN_Paste.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
				'候補の一覧
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
			Case Else
				'登録
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'削除（使用不可！！）
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'画面印刷
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'終了
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'画面初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_APPENDC.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行削除
				Trg_Index = CShort(FR_SSSMAIN.MN_DeleteDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行挿入
				Trg_Index = CShort(FR_SSSMAIN.MN_InsertDE.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'明細行復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoDe.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'切り取り
				Trg_Index = CShort(FR_SSSMAIN.MN_Cut.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'コピー
				Trg_Index = CShort(FR_SSSMAIN.MN_Copy.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'貼り付け
				Trg_Index = CShort(FR_SSSMAIN.MN_Paste.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
				'候補の一覧
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
		End Select
		
		'メニューボタンイメージの可視制御
		'終了ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'登録ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'検索画面表示ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_Slist.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Upd_Process
	'   概要：  更新メインルーチン
	'   引数：　なし
	'   戻値：　0 :更新終了　9:更新なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim Trg_Index As Short
		Dim strHINCD As String
		' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
		Dim strMsg As String
		' === 20061105 === INSERT E -
		
		F_Ctl_Upd_Process = 9
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'ヘッダ部のチェック
		intRet = F_Ctl_Head_Chk(pm_All)
		If intRet <> CHK_OK Then
			'チェックＮＧの場合
			' === 20060915 === UPDATE S - ACE)Nagasawa
			'        Exit Function
			GoTo End_F_Ctl_Upd_Process
			' === 20060915 === UPDATE E -
		End If
		
		'    'ボディ部のチェック
		'    intRet = F_Ctl_Body_Chk(pm_All)
		'    If intRet <> CHK_OK Then
		'    'チェックＮＧの場合
		'        Exit Function
		'    End If
		'
		'    'テイル部のチェック
		'    intRet = F_Ctl_Tail_Chk(pm_All)
		'    If intRet <> CHK_OK Then
		'    'チェックＮＧの場合
		'        Exit Function
		'    End If
		
		'Windowsに処理を返す
		System.Windows.Forms.Application.DoEvents()
		
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_Q_RUN, pm_All) = MsgBoxResult.Yes Then
			
			' === 20061129 === INSERT S - ACE)Nagasawa 更新権限チェックを変更する
			'更新権限がない場合は処理を行わない
			If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_013, pm_All)
				GoTo End_F_Ctl_Upd_Process
			End If
			' === 20061129 === INSERT E -
			
			' === 20061105 === INSERT S - ACE)Nagasawa
			'排他チェックを行う
			Select Case CF_Chk_Lock_EXCTBZ(strMsg)
				'正常
				Case 0
					
					'排他処理中
				Case 1
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_012, pm_All, "", strMsg)
					GoTo End_F_Ctl_Upd_Process
					
					'異常終了
				Case 9
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All)
					GoTo End_F_Ctl_Upd_Process
					
			End Select
			' === 20061105 === INSERT E -
			
			'初期ﾌｫｰｶｽ位置設定
			Call F_Init_Cursor_Set(pm_All)
			
			'ボタン非表示
			FR_SSSMAIN.CM_Execute.Visible = False
			
			'登録処理
			Trg_Index = CShort(FR_SSSMAIN.HD_HINCD.Tag)
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strHINCD = CStr(pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Dsp_Value)
			intRet = F_Update_Main(strHINCD, pm_All)
			If intRet <> 0 Then
				GoTo Err_F_Ctl_Upd_Process
				
			Else
				' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
				'排他解除
				Call CF_Unlock_EXCTBZ(strMsg)
				' === 20061105 === INSERT E -
				
				'更新完了メッセージ表示
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_A_UPDATEOK, pm_All)
				
			End If
			
		End If
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
		'排他解除
		Call CF_Unlock_EXCTBZ(strMsg)
		' === 20061105 === INSERT E -
		'ボタン表示
		FR_SSSMAIN.CM_Execute.Visible = True
		' === 20060915 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		' === 20060915 === INSERT E -
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Update_Main
	'   概要：  更新メイン処理
	'   引数：  pm_HINCD      : 製品コード
	'           pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_HINCD As String, ByRef pm_All As Cls_All) As Short
		
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim bolTran As Boolean
		Dim strDate As String
		Dim strTime As String
		
		On Error GoTo F_Update_Main_err
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'排他処理☆★☆★☆保留★☆★☆★
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'日付・時刻を取得
		strDate = VB6.Format(Now, "yyyyMMdd")
		strTime = VB6.Format(Now, "hhmmss")
		
		'見積トラン更新
		intRet = F_MITTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'受注トラン更新
		intRet = F_JDNTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'製番出庫ファイル更新
		intRet = F_SBNTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'倉庫別在庫マスタ更新
		intRet = F_HINMTB_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'入庫予定ファイル更新
		intRet = F_INPTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'支給品予定ファイル更新
		intRet = F_SKYTBL_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'欠品ファイル更新
		intRet = F_STOTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'引当内訳ファイル更新
		intRet = F_DTLTRA_Update(pm_HINCD, strDate, strTime, pm_All)
		If intRet <> 0 Then
			GoTo F_Update_Main_err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		F_Update_Main = 0
		
F_Update_Main_End: 
		'砂時計を戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_Update_Main_err: 
		
		If bolTran = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_MITTRA_Update
	'   概要：  見積トラン更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_MITTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_MITTRA_Update = 9
		
		On Error GoTo F_MITTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update MITTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ZAIHIKSU = 0"
		strSQL = strSQL & "    ,NYTHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And KHIKKB = '1'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_MITTRA_Update_err
		End If
		
		F_MITTRA_Update = 0
		
F_MITTRA_Update_End: 
		Exit Function
		
F_MITTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_MITTRA_Update")
		
		GoTo F_MITTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_JDNTRA_Update
	'   概要：  受注トラン更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_JDNTRA_Update = 9
		
		On Error GoTo F_JDNTRA_Update_err
		
		strSQL = ""
		' === 20060907 === UPDATE S - ACE)Hashiri 赤黒対応(JDNTRVに変更)
		' === 20061107 === UPDATE S - ACE)Yano    Viewよりﾃｰﾌﾞﾙからの更新に戻す
		''strSQL = strSQL & " Update JDNTRA"
		''strSQL = strSQL & " Update JDNTRV"
		strSQL = strSQL & " Update JDNTRA TRA"
		' === 20061107 === UPDATE E -
		' === 20060907 === UPDATE E -
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ATZHIKSU = 0"
		strSQL = strSQL & "    ,ATNHIKSU = 0"
		strSQL = strSQL & "    ,MNZHIKSU = 0"
		strSQL = strSQL & "    ,MNNHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB    = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		' === 20061107 === UPDATE S - ACE)Yano    Viewよりﾃｰﾌﾞﾙからの更新に戻す
		strSQL = strSQL & " And AKAKROKB = '1' "
		strSQL = strSQL & " And DATNO    = ( Select Max(DATNO) DATNO "
		strSQL = strSQL & "                    From JDNTRA TRB "
		strSQL = strSQL & "                 Where   TRB.DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & "                   And   TRB.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & "                   And   TRB.JDNNO = TRA.JDNNO "
		strSQL = strSQL & "                   And   TRB.LINNO = TRA.LINNO "
		strSQL = strSQL & "                Group By JDNNO "
		strSQL = strSQL & "                       , LINNO "
		strSQL = strSQL & "                ) "
		' === 20061107 === UPDATE E -
		
		'すべて出庫済みの場合は対象としない
		strSQL = strSQL & " And UODSU > OTPSU"
		'ADD START FKS)INABA 2009/09/30 ***************************************
		'連絡票№FC09100103
		strSQL = strSQL & " And FRDSU = 0"
		'ADD  END  FKS)IABA  2009/09/30 ***************************************
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_JDNTRA_Update_err
		End If
		
		F_JDNTRA_Update = 0
		
F_JDNTRA_Update_End: 
		Exit Function
		
F_JDNTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_JDNTRA_Update")
		
		GoTo F_JDNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SBNTRA_Update
	'   概要：  製番出庫ファイル更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SBNTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_SBNTRA_Update = 9
		
		On Error GoTo F_SBNTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update SBNTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     HIKSMSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And FRDYTSU > OUTSMSU"
		'ADD START FKS)INABA 2009/09/30 ************************************
		'連絡票№FC09100103
		strSQL = strSQL & " And FRDSU = 0"
		'ADD  END  FKS)INABA 2009/09/30 ************************************
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SBNTRA_Update_err
		End If
		
		F_SBNTRA_Update = 0
		
F_SBNTRA_Update_End: 
		Exit Function
		
F_SBNTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_SBNTRA_Update")
		
		GoTo F_SBNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_HINMTB_Update
	'   概要：  倉庫別在庫マスタ更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_HINMTB_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_HINMTB_Update = 9
		
		On Error GoTo F_HINMTB_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update HINMTB"
		strSQL = strSQL & " Set"
		' === 20070919 === UPDATE S - ACE)Nagasawa 倉庫別在庫マスタの引当数クリア時、出荷指示数分をキープする
		'strSQL = strSQL & "     HIKSU = 0"
		strSQL = strSQL & "     HIKSU = (SELECT NVL(FRDSU, 0) "
		strSQL = strSQL & "                FROM (" & F_FRDSU_Select(pm_HINCD, pm_All) & ") SUB_FRDSU "
		strSQL = strSQL & "               WHERE HINMTB.SOUCD = SUB_FRDSU.SOUCD (+) "
		strSQL = strSQL & "                 AND HINMTB.HINCD = SUB_FRDSU.HINCD (+) )"
		' === 20070919 === UPDATE E -
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		' === 20070919 === INSERT S - ACE)Nagasawa 解除対象を引当対象区分="1"（対象)の倉庫のみとする
		strSQL = strSQL & " And HIKKB = '" & CF_Ora_Sgl(gc_strHIKKB_OK) & "'"
		' === 20070919 === INSERT E -
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_HINMTB_Update_err
		End If
		
		F_HINMTB_Update = 0
		
F_HINMTB_Update_End: 
		Exit Function
		
F_HINMTB_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_HINMTB_Update")
		
		GoTo F_HINMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_INPTRA_Update
	'   概要：  入庫予定ファイル更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_INPTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_INPTRA_Update = 9
		
		On Error GoTo F_INPTRA_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update INPTRA"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     INHIKSU = 0"
		' === 20061119 === UPDATE S - ACE)Yano
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "    ,UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,UWRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,UWRTDT = '" & pm_Date & "'"
		strSQL = strSQL & "    ,PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And INPSU > INPSMSU"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_INPTRA_Update_err
		End If
		
		F_INPTRA_Update = 0
		
F_INPTRA_Update_End: 
		Exit Function
		
F_INPTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_INPTRA_Update")
		
		GoTo F_INPTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DTLTRA_Update
	'   概要：  引当内訳ファイル更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_DTLTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_DTLTRA_Update = 9
		
		On Error GoTo F_DTLTRA_Update_err
		'CHG START FKS)INABA 2009/09/30 *********************
		'連絡票№FC09100103
		Dim lw_ret As Short
		Dim ls_sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim ls_TRAKB As String
		Dim ls_TRANO As String
		Dim ls_MITNOV As String
		Dim ls_LINNO As String
		Dim ls_TRADT As String
		Dim ls_HIKNO As String
		Dim ls_ATMNKB As String
		Dim ls_HINCD As String
		Dim ls_PUDLNO As String
		Dim ls_ROWID As String
		ls_sql = ""
		ls_sql = ls_sql & " SELECT TRAKB,TRANO,MITNOV,LINNO,TRADT,HIKNO,ATMNKB,HINCD,PUDLNO,ROWID "
		ls_sql = ls_sql & "   FROM DTLTRA"
		ls_sql = ls_sql & "  WHERE HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		ls_sql = ls_sql & "  ORDER BY TRAKB,TRANO,MITNOV,LINNO,TRADT"
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		lw_ret = 0
		Do Until CF_Ora_EOF(Usr_Ody) = True
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ls_ROWID = CF_Ora_GetDyn(Usr_Ody, "ROWID", "")
			lw_ret = F_DEL_DTLTRA_CHK(ls_TRAKB, ls_TRANO, ls_MITNOV, ls_LINNO, ls_TRADT, ls_HIKNO, ls_ATMNKB, ls_HINCD, ls_PUDLNO)
			If lw_ret = 0 Then
				strSQL = ""
				strSQL = strSQL & " DELETE FROM DTLTRA"
				strSQL = strSQL & " WHERE ROWID = '" & Trim(ls_ROWID) & "'"
				'SQL実行
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_DTLTRA_Update_err
				End If
			ElseIf lw_ret = -1 Then 
				GoTo F_DTLTRA_Update_err
			End If
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		'    strSQL = ""
		''///////////////// 2006.08.28 ACE MENTE START ////////////////////////
		'' 引当数=0ならば、削除する
		''   strSQL = strSQL & " Update DTLTRA"
		''   strSQL = strSQL & " Set"
		''   strSQL = strSQL & "     HIKSU = 0"
		''   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		''   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		''   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		'    strSQL = strSQL & " Delete From DTLTRA"
		'    strSQL = strSQL & " Where"
		'    strSQL = strSQL & "     HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		''///////////////// 2006.08.28 ACE MENTE E N D ////////////////////////
		'
		'    'SQL実行
		'    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		'    If bolRet = False Then
		'        GoTo F_DTLTRA_Update_err
		'    End If
		'
		'        Call CF_Ora_MoveNext(Usr_Ody)
		'    Loop
		'CHG  END  FKS)INABA 2009/09/30 *********************
		F_DTLTRA_Update = 0
		
F_DTLTRA_Update_End: 
		'ADD START FKS)INABA 2009/09/30 *********************
		'連絡票№FC09100103
		Call CF_Ora_CloseDyn(Usr_Ody)
		'ADD  END  FKS)INABA 2009/09/30 *********************
		Exit Function
		
F_DTLTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_DTLTRA_Update")
		
		GoTo F_DTLTRA_Update_End
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SKYTBL_Update
	'   概要：  支給品テーブル更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SKYTBL_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		F_SKYTBL_Update = 9
		
		On Error GoTo F_SKYTBL_Update_err
		
		strSQL = ""
		strSQL = strSQL & " Update SKYTBL"
		strSQL = strSQL & " Set"
		strSQL = strSQL & "     ATZHIKSU = 0"
		strSQL = strSQL & "    ,ATNHIKSU = 0"
		strSQL = strSQL & "    ,MNZHIKSU = 0"
		strSQL = strSQL & "    ,MNNHIKSU = 0"
		strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		strSQL = strSQL & " And OUTYOTSU > OUTZMISU"
		'ADD START FKS)INABA 2009/09/30 ************************************************
		'連絡票№FC09100103
		strSQL = strSQL & " And FRDSU = 0 "
		'ADD  END  FKS)INABA 2009/09/30 ************************************************
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SKYTBL_Update_err
		End If
		
		F_SKYTBL_Update = 0
		
F_SKYTBL_Update_End: 
		Exit Function
		
F_SKYTBL_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_SKYTBL_Update")
		
		GoTo F_SKYTBL_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_STOTRA_Update
	'   概要：  欠品ファイル更新処理
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_STOTRA_Update(ByRef pm_HINCD As String, ByRef pm_Date As String, ByRef pm_Time As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_STOTRA_Update_err
		
		F_STOTRA_Update = 9
		
		strSQL = ""
		'///////////////// 2006.09.14 ACE MENTE START ////////////////////////
		' 引当数=0ならば、削除する
		'   strSQL = strSQL & " Update STOTRA"
		'   strSQL = strSQL & " Set"
		'   strSQL = strSQL & "     HIKSU = 0"
		'   strSQL = strSQL & "    ,CLTID = '" & CF_Ora_String(SSS_CLTID, 5) & "'"
		'   strSQL = strSQL & "    ,WRTTM = '" & pm_Time & "'"
		'   strSQL = strSQL & "    ,WRTDT = '" & pm_Date & "'"
		strSQL = strSQL & " Delete From STOTRA"
		'///////////////// 2006.09.14 ACE MENTE E N D ////////////////////////
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " And HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_STOTRA_Update_err
		End If
		
		F_STOTRA_Update = 0
		
F_STOTRA_Update_End: 
		Exit Function
		
F_STOTRA_Update_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_STOTRA_Update")
		
		GoTo F_STOTRA_Update_End
		
	End Function
	
	' === 20070919 === INSERT S - ACE)Nagasawa 倉庫別在庫マスタの引当数クリア時、出荷指示数分をキープする
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_FRDSU_Select
	'   概要：  出荷指示済数量取得SQL作成
	'   引数：  pm_HINCD      : 製品コード
	'   戻値：　作成SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_FRDSU_Select(ByRef pm_HINCD As String, ByRef pm_All As Cls_All) As String
		
		Dim strSQL As String
		
		On Error GoTo F_FRDSU_Select_err
		
		F_FRDSU_Select = ""
		
		strSQL = ""
		strSQL = strSQL & " SELECT HINMTB.SOUCD "
		strSQL = strSQL & "      , HINMTB.HINCD "
		strSQL = strSQL & "      , NVL(JDNTRA.FRDSU, 0) + NVL(JDNTRT.FRDSU, 0) +"
		strSQL = strSQL & "        NVL(SKYTBL.FRDSU, 0) +"
		strSQL = strSQL & "        NVL(SBNTRA.FRDSU, 0) + NVL(SYKTRI.FRDSU, 0) FRDSU"
		strSQL = strSQL & "   FROM HINMTB ,"
		
		'受注(通販以外)
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "        (SELECT FDNTRA.SOUCD"
		strSQL = strSQL & "              , JDNTRA.HINCD"
		strSQL = strSQL & "              , SUM(FDNTRA.FRDSU) FRDSU"
		'    strSQL = strSQL & "        (SELECT SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		'    strSQL = strSQL & "              , JDNTRA.HINCD"
		'    strSQL = strSQL & "              , SUM(JDNTRA.FRDSU) FRDSU"
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		strSQL = strSQL & "           FROM JDNTRA "
		strSQL = strSQL & "              , ( "
		strSQL = strSQL & "                  SELECT MAX(DATNO) DATNO "
		strSQL = strSQL & "                       , JDNNO "
		strSQL = strSQL & "                       , LINNO "
		strSQL = strSQL & "                    FROM JDNTRA "
		strSQL = strSQL & "                   WHERE DATKB   = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                   GROUP BY DATKB "
		strSQL = strSQL & "                          , JDNNO "
		strSQL = strSQL & "                          , LINNO "
		strSQL = strSQL & "                   ORDER BY DATKB "
		strSQL = strSQL & "                          , JDNNO "
		strSQL = strSQL & "                          , LINNO "
		strSQL = strSQL & "                ) JDNTRB "
		strSQL = strSQL & "              , HINMTA "
		strSQL = strSQL & "              , JDNTHA "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "              , (SELECT DATKB,JDNNO,JDNLINNO,PUDLNO,HINCD,OUTSOUCD SOUCD,SUM(FRDSU-OTPSU) FRDSU "
		strSQL = strSQL & "                  FROM FDNTRA "
		strSQL = strSQL & "                 WHERE DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                   AND FRDSU > OTPSU "
		strSQL = strSQL & "                 GROUP BY DATKB,JDNNO,JDNLINNO,PUDLNO,HINCD,OUTSOUCD) FDNTRA "
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "          WHERE JDNTHA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTHA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTHA.JDNINKB  <> '" & gc_strJDNINKB_ML & "' "
		strSQL = strSQL & "            AND JDNTHA.DATNO    = JDNTRA.DATNO "
		strSQL = strSQL & "            AND JDNTRA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTRA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTRA.DATNO    = JDNTRB.DATNO"
		strSQL = strSQL & "            AND JDNTRA.JDNNO    = JDNTRB.JDNNO"
		strSQL = strSQL & "            AND JDNTRA.LINNO    = JDNTRB.LINNO"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = HINMTA.HINCD"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "            AND FDNTRA.JDNNO    = JDNTRA.JDNNO"
		strSQL = strSQL & "            AND FDNTRA.JDNLINNO = JDNTRA.LINNO"
		strSQL = strSQL & "            AND FDNTRA.PUDLNO   = JDNTRA.PUDLNO"
		strSQL = strSQL & "            AND FDNTRA.HINCD    = JDNTRA.HINCD"
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "           GROUP BY JDNTRA.DATKB"
		strSQL = strSQL & "                  , JDNTRA.AKAKROKB"
		strSQL = strSQL & "                  , FDNTRA.SOUCD"
		strSQL = strSQL & "                  , JDNTRA.HINCD ) JDNTRA, "
		'    strSQL = strSQL & "           GROUP BY JDNTRA.DATKB"
		'    strSQL = strSQL & "                  , JDNTRA.AKAKROKB"
		'    strSQL = strSQL & "                  , HINMTA.TNACM"
		'    strSQL = strSQL & "                  , JDNTRA.HINCD ) JDNTRA, "
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		'受注(通販)
		strSQL = strSQL & "        (SELECT JDNTRA.SOUCD"
		strSQL = strSQL & "              , JDNTRA.HINCD"
		strSQL = strSQL & "              , SUM(JDNTRA.FRDSU) FRDSU"
		strSQL = strSQL & "           FROM JDNTRA"
		strSQL = strSQL & "              , (SELECT MAX(DATNO) DATNO"
		strSQL = strSQL & "                      , JDNNO"
		strSQL = strSQL & "                      , LINNO"
		strSQL = strSQL & "                   FROM JDNTRA "
		strSQL = strSQL & "                  WHERE DATKB   = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                  GROUP BY DATKB"
		strSQL = strSQL & "                         , JDNNO"
		strSQL = strSQL & "                         , LINNO"
		strSQL = strSQL & "                  ORDER BY DATKB"
		strSQL = strSQL & "                         , JDNNO"
		strSQL = strSQL & "                         , LINNO"
		strSQL = strSQL & "                ) JDNTRB"
		strSQL = strSQL & "              , JDNTHA"
		strSQL = strSQL & "          WHERE JDNTHA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTHA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTHA.JDNINKB  = '" & gc_strJDNINKB_ML & "' "
		strSQL = strSQL & "            AND JDNTHA.DATNO    = JDNTRA.DATNO"
		strSQL = strSQL & "            AND JDNTRA.DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND JDNTRA.AKAKROKB = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "            AND JDNTRA.DATNO    = JDNTRB.DATNO"
		strSQL = strSQL & "            AND JDNTRA.JDNNO    = JDNTRB.JDNNO"
		strSQL = strSQL & "            AND JDNTRA.LINNO    = JDNTRB.LINNO"
		strSQL = strSQL & "            AND JDNTRA.HINCD    = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "            GROUP BY JDNTRA.DATKB"
		strSQL = strSQL & "                   , JDNTRA.AKAKROKB"
		strSQL = strSQL & "                   , JDNTRA.SOUCD"
		strSQL = strSQL & "                   , JDNTRA.HINCD) JDNTRT, "
		
		'支給品ファイル
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "        (SELECT FDNTRA.SOUCD"
		strSQL = strSQL & "         　   , SKYTBL.HINCD"
		strSQL = strSQL & "         　   , SUM(FDNTRA.FRDSU) FRDSU"
		'    strSQL = strSQL & "        (SELECT SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		'    strSQL = strSQL & "         　   , SKYTBL.HINCD"
		'    strSQL = strSQL & "         　   , SUM(SKYTBL.FRDSU) FRDSU"
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "          FROM SKYTBL"
		strSQL = strSQL & "             , HINMTA"
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "             ,(SELECT DATKB,SBNNO,PUDLNO,HINCD,OUTSOUCD SOUCD,SUM(FRDSU - OTPSU) FRDSU"
		strSQL = strSQL & "                 FROM FDNTRA"
		strSQL = strSQL & "                WHERE DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "                  AND FRDSU > OTPSU"
		strSQL = strSQL & "               GROUP BY DATKB,SBNNO,PUDLNO,HINCD,OUTSOUCD ) FDNTRA"
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		strSQL = strSQL & "         WHERE SKYTBL.DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "           AND SKYTBL.PLANKB = ' '"
		strSQL = strSQL & "           AND SKYTBL.HINCD  = HINMTA.HINCD"
		strSQL = strSQL & "           AND SKYTBL.HINCD  = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		'ADD START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "           AND SKYTBL.SBNNO  = FDNTRA.SBNNO  "
		strSQL = strSQL & "           AND SKYTBL.PUDLNO = FDNTRA.PUDLNO "
		strSQL = strSQL & "           AND SKYTBL.HINCD  = FDNTRA.HINCD  "
		'ADD  END  FKS)INABA 2009/09/30 *************************************************************
		'CHG START FKS)INABA 2009/09/30 *************************************************************
		'連絡票№FC09100103
		strSQL = strSQL & "         GROUP BY SKYTBL.DATKB"
		strSQL = strSQL & "                , SKYTBL.PLANKB"
		strSQL = strSQL & "                , FDNTRA.SOUCD "
		strSQL = strSQL & "                , SKYTBL.HINCD) SKYTBL, "
		'    strSQL = strSQL & "         GROUP BY SKYTBL.DATKB"
		'    strSQL = strSQL & "                , SKYTBL.PLANKB"
		'    strSQL = strSQL & "                , HINMTA.TNACM"
		'    strSQL = strSQL & "                , SKYTBL.HINCD) SKYTBL, "
		'CHG  END  FKS)INABA 2009/09/30 *************************************************************
		
		'製番出庫ファイル
		strSQL = strSQL & "        (SELECT SBNTRA.OUTSOUCD SOUCD"
		strSQL = strSQL & "              , SBNTRA.HINCD"
		strSQL = strSQL & "              , SUM(SBNTRA.FRDSU) FRDSU"
		strSQL = strSQL & "          FROM SBNTRA"
		strSQL = strSQL & "         WHERE SBNTRA.DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "           AND SBNTRA.HINCD  = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "         GROUP BY SBNTRA.DATKB"
		strSQL = strSQL & "                , SBNTRA.OUTSOUCD"
		strSQL = strSQL & "                , SBNTRA.HINCD) SBNTRA, "
		
		'出荷予定ファイル移動
		strSQL = strSQL & "        (SELECT SYKTRI.OUTSOUCD SOUCD"
		strSQL = strSQL & "              , SYKTRI.HINCD"
		strSQL = strSQL & "              , SUM(SYKTRI.HIKSU) + SUM(SYKTRI.FRDSU) FRDSU"
		strSQL = strSQL & "           FROM SYKTRI"
		strSQL = strSQL & "          WHERE SYKTRI.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "            AND SYKTRI.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "          GROUP BY SYKTRI.DATKB"
		strSQL = strSQL & "                 , SYKTRI.OUTSOUCD"
		strSQL = strSQL & "                 , SYKTRI.HINCD) SYKTRI"
		strSQL = strSQL & "  WHERE HINMTB.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND HINMTB.HINCD = '" & CF_Ora_Sgl(pm_HINCD) & "' "
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  JDNTRA.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  JDNTRA.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  JDNTRT.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  JDNTRT.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SKYTBL.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SKYTBL.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SBNTRA.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SBNTRA.HINCD (+)"
		strSQL = strSQL & "    AND HINMTB.SOUCD  =  SYKTRI.SOUCD (+)"
		strSQL = strSQL & "    AND HINMTB.HINCD  =  SYKTRI.HINCD (+)"
		
		F_FRDSU_Select = strSQL
		
F_FRDSU_Select_End: 
		
		Exit Function
		
F_FRDSU_Select_err: 
		'エラーメッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_E_UPDATENG, pm_All, "F_FRDSU_Select")
		
		GoTo F_FRDSU_Select_End
		
	End Function
	' === 20070919 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Paste
	'   概要：  貼り付け
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
		'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		Clip_Value = My.Computer.Clipboard.GetText()
		'入力文字可能を取り出す
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'貼り付け内容がない場合、処理中断
		If Paste_Value = "" Then
			Exit Function
		End If
		
		'現在のﾃｷｽﾄ上の選択状態を取得
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'現在の値を取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'詰文字が左詰の場合
			
			'文字編集
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'編集後のSelStartを決定
			'右端へ移動
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'詰文字が左詰以外の場合
			
			If Act_SelLength = 0 Then
				'選択なしの場合(挿入状態)
				'文字編集
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'一部選択
				If Act_SelLength >= 2 Then
					'２文字以上選択している場合は
					'選択文字より後ろの文字もつける
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'１文字以下選択している場合は
					'選択文字以降は入れ換え
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'編集後のSelStartを決定
			'左端へ移動
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'日付の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'年月の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'時刻の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'編集後の文字を表示形式に変換
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
		
		'編集後のSelStartを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'編集後のSelLengthを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
		
		' === 20061228 === INSERT S - ACE)Nagasawa
		'入力後の後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		' === 20061228 === INSERT E -
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module