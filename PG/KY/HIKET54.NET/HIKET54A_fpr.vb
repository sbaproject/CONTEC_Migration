Option Strict Off
Option Explicit On
Module SSSMAIN0003
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	'Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	
	Public Structure HIKET54A_DSP_DATA
		Dim Mode As Short 'モード（3:支給品情報、4:製番出庫情報）
		Dim DENSBT As String '伝票情報
		Dim SBNNO As String '製番
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '製品名
		Dim UODSU As Decimal '数量
		Dim MNSU As Decimal '手動済数
		Dim ZUMISU As Decimal '引当済数
		Dim HIKSUKEI As Decimal '引当済数（明細合計）
	End Structure
	
	' === 20080725 === INSERT S - RISE)Izumi
	Public Structure TYPE_DTLTRA_EXEC
		Dim HINCD As String ' 製品コード
		Dim INPYTDT As String ' 入庫予定日
		Dim LOTNO As String ' ロット番号
		Dim SOUCD As String ' 倉庫コード
		Dim TRANO As String ' トラン番号
		Dim MITNOV As String ' 版数
		Dim LINNO As String ' 行番号
		Dim DATNO As String ' 伝票管理№
		Dim SUB_TRAKB As String ' トラン種別
		Dim SUB_TRANO As String ' トラン番号
		Dim SUB_MITNOV As String ' 版数
		Dim SUB_LINNO As String ' 行番号
		Dim SUB_PUDLNO As String ' 入出庫番号
		Dim SUB_TRADT As String ' トラン日付
		Dim SUB_HIKNO As String ' 引当番号
		Dim SUB_HINCD As String ' 製品コード
		Dim SUB_OPEID As String ' 最終作業者コード
		Dim SUB_CLTID As String ' クライアントＩＤ
		Dim SUB_WRTTM As String ' タイムスタンプ（バッチ時間）
		Dim SUB_WRTDT As String ' タイムスタンプ（バッチ日）
		' === 20080804 === INSERT S - RISE)Izumi
		Dim InterfaceFlg As Boolean ' インターフェース更新フラグ
		' === 20080804 === INSERT E -
	End Structure
	
	Public TYPE_DTLTRA_EXEC_BEF() As TYPE_DTLTRA_EXEC ' 更新前データ取得変数
	' === 20080725 === INSERT E -
	
	'画面編集情報退避用
	Public HIKET54A_DSP_DATA_Inf As HIKET54A_DSP_DATA
	Public HIKET54A_DSP_DATA_Clr As HIKET54A_DSP_DATA
	
	'引当内訳ファイル情報退避
	Private mv_strDTLTRA_UMKB As String 'データ有無区分
	Private mv_strDTLTRA_TRAKB As String 'トラン種別
	Private mv_strDTLTRA_TRANO As String 'トラン番号
	Private mv_strDTLTRA_MITNOV As String '版数
	Private mv_strDTLTRA_LINNO As String '行番号
	Private mv_strDTLTRA_PUDLNO As String '入出庫番号
	Private mv_strDTLTRA_TRADT As String 'トラン日付
	Private mv_strDTLTRA_HIKNO As String '引当番号
	Private mv_strDTLTRA_HINCD As String '製品コード
	Private mv_strDTLTRA_ATMNKB As String '自動手動区分
	Private mv_strDTLTRA_INPYTDT As String '入荷予定日
	Private mv_strDTLTRA_LOTNO As String 'ロット番号
	Private mv_strDTLTRA_SOUCD As String '倉庫コード
	Private mv_strDTLTRA_SISNKB As String '資産元区分
	Private mv_strDTLTRA_SOUTRICD As String '取引先コード
	Private mv_strDTLTRA_SOUKOKB As String '倉庫区分
	Private mv_curDTLTRA_HIKSU As Decimal '引当数
	Private mv_curDTLTRA_UPD_HIKSU As Decimal '引当数(更新用)
	Private mv_curDTLTRA_HIKSU_SA As Decimal '引当数（差分）
	' === 20080725 === INSERT S - RISE)Izumi
	Private mv_strDTLTRA_DATNO As String '伝票管理№
	' === 20080725 === INSERT E -
	' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
	Private mv_curDTLTRA_FRDSU As Decimal '出荷指示数
	Private mv_curFRDSU_AT As Decimal '出荷指示数(自動分)
	Private mv_curFRDSU_MN As Decimal '出荷指示数(手動分)
	Private mv_curFRDSU_AT_WK As Decimal '出荷指示数(自動分計算用WK)
	Private mv_curFRDSU_MN_WK As Decimal '出荷指示数(手動分計算用WK)
	' === 20080720 === INSERT E -
	
	'処理対象データキー情報退避
	Private mv_strKEY_TRAKB As String 'トラン種別
	Private mv_strKEY_TRANO As String 'トラン番号
	Private mv_strKEY_MITNOV As String '版数
	Private mv_strKEY_LINNO As String '行番号
	Private mv_strKEY_PUDLNO As String '入出庫番号
	Private mv_strKEY_TRADT As String 'トラン日付
	Private mv_strKEY_HINCD As String '製品コード
	Private mv_strKEY_INPYTDT As String '入庫予定日
	Private mv_strKEY_LOTNO As String 'ロット番号
	Private mv_strKEY_SOUCD As String '倉庫コード
	Private mv_strKEY_DATNO As String '伝票管理№
	
	'明細列番号退避領域
	Private mv_intSOUNM_Col As Short '倉庫名の列
	Private mv_intLOTNO_Col As Short 'ロット番号の列
	Private mv_intINPYTDT_Col As Short '入庫予定日の列
	Private mv_intRELZAISU_Col As Short '現在庫数の列
	Private mv_intZUMISU_Col As Short '引当済数の列
	Private mv_intHIKSU_Col As Short '引当可能数の列
	Private mv_intMNSU_Col As Short '手動引当数の列
	Private mv_intINPHIKSU_Col As Short '引当数の列
	
	Private mv_curATZHIKSU_SA As Short '自動在庫引当数の差
	Private mv_curATNHIKSU_SA As Short '自動入庫予定引当数の差
	Private mv_curMNZHIKSU_SA As Short '手動在庫引当数の差
	Private mv_curMNNHIKSU_SA As Short '手動入庫予定引当数の差
	
	'画面初期化フラグ
	Public gv_bolHIKET54_INIT As Boolean 'True:変更あり
	Public gv_bolUpdFlg As Boolean
	
	'サブ画面データ件数
	Public gv_bolHIKET54A_CNT As Integer '明細件数
	
	' === 20080725 === INSERT S - RISE)Izumi
	'排他対象テーブル区分
	Private Enum ex_tblKbn
		HINMTB = 1 '倉庫別在庫マスタ
		INPTRA = 2 '入荷予定ファイル
		SKYTBL = 3 '支給品ファイル
		SBNTRA = 4 '製番出庫ファイル
		DTLTRA = 5 '引当内訳ファイル
	End Enum
	' === 20080725 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_Change
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
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	
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
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					'編集後のSelLengthを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
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
						Input_Flg = True
						
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
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			bolSameCtl = False
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'右クリックしたコントロールがアクティブなコントロールと一致
				'カーソル制御用テキストにフォーカスを一時的に退避
				Wk_Index = CShort(FR_SSSSUB01.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'｢項目内容コピー｣判定
			FR_SSSSUB01.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'｢項目内容に貼り付け｣判定
			FR_SSSSUB01.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
				'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSSUB01.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				FR_SSSSUB01.PopupMenu(FR_SSSSUB01.SM_ShortCut, vbPopupMenuLeftButton)
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
				pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
			'以降の処理は行わない。
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_VS_Scrl_CHANGE
	'   概要：  VS_ScrlのCHANGEの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		'縦スクロールバーの値を最上明細ｲﾝﾃﾞｯｸｽに設定
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'画面ボディ情報の配列を再設定
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		
		'画面表示
		Call CF_Body_Dsp(pm_All)
		'明細カラー付け
		Call CF_Set_BD_Color(pm_All)
		'コントロール制御
		Call F_Set_Body_Enable(pm_All)
		'チェック済みとする
		Call F_Set_Body_Bef_Chk_Value(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'入力可能な項目かどうかの判断を行う
					If CF_Set_Focus_Ctl(pm_Act_Dsp_Sub_Inf, pm_All) = True Then
						'選択状態の設定（初期選択）
						Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
						'項目色設定
						Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					Else
						'同一項目の１つ前からENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Init_Clr_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
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
		
		'入力後の後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
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
		' === 20080728 === INSERT S - RISE)Izumi
		Dim bolTran As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strOPEID As String
		Dim strCLTID As String
		Dim strWRTTM As String
		Dim strWRTDT As String
		Dim strUOPEID As String
		Dim strUCLTID As String
		Dim strUWRTTM As String
		Dim strUWRTDT As String
		Dim strSOUCD As String
		Dim strHinCd As String
		Dim strInpYtDt As String
		Dim strLotNo As String
		Dim intMeiCnt As Short
		Dim intCnt As Short
		Dim intLoop As Short
		' === 20080728 === INSERT E -
		
		F_Ctl_Upd_Process = 9
		
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'ヘッダ部のチェック
		intRet = F_Ctl_Head_Chk(pm_All)
		If intRet <> CHK_OK Then
			'チェックＮＧの場合
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'ボディ部のチェック
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'チェックＮＧの場合
			GoTo End_F_Ctl_Upd_Process
		End If
		
		' === 20080728 === INSERT S - RISE)Izumi
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'明細行数を取得する
		intMeiCnt = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		Dim ls_sql As String
		For intCnt = 1 To intMeiCnt
			With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				' 明細編集された行のみ処理を行う
				If .Bus_Inf.SUB_IsDataRow = True Then
					' 画面の値と初期明細編集時に退避した値をチェックし、値が変わっていれば処理を続行
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .Item_Detail(mv_intINPHIKSU_Col).Dsp_Value <> .Bus_Inf.SUB_MOTO_HIKSU Then
						' SUB_KB = "1"(倉庫別在庫データ)の場合は処理を行う
						If .Bus_Inf.SUB_KB = "1" Then
							
							strSQL = F_GET_EX_SQL(intCnt, ex_tblKbn.HINMTB, pm_All)
							If Len(strSQL) = 0 Then
								'エラーが発生
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All) ' MSG内容:更新異常
								GoTo Err_F_Ctl_Upd_Process
							End If
							
							'DBアクセス
							Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
							
							If DBSTAT <> 0 Then
								'データなしの場合
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
								GoTo Err_F_Ctl_Upd_Process
							Else
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strOPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strCLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（日付）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' タイムスタンプ（バッチ時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' タイムスタンプ（バッチ日）
								
								'排他処理が実行中か確認する
								If strOPEID <> .Bus_Inf.SUB_OPEID Or strCLTID <> .Bus_Inf.SUB_CLTID Or strWRTTM <> .Bus_Inf.SUB_WRTTM Or strWRTDT <> .Bus_Inf.SUB_WRTDT Or strUOPEID <> .Bus_Inf.SUB_UOPEID Or strUCLTID <> .Bus_Inf.SUB_UCLTID Or strUWRTTM <> .Bus_Inf.SUB_UWRTTM Or strUWRTDT <> .Bus_Inf.SUB_UWRTDT Then
									'メッセージ表示
									Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
									GoTo Err_F_Ctl_Upd_Process
								End If
							End If
						End If
						
						'SUB_KB = "2"(入荷予定ファイル)の場合は処理を行う
						If .Bus_Inf.SUB_KB = "2" Then
							'排他処理情報取得
							strSQL = F_GET_EX_SQL(intCnt, ex_tblKbn.INPTRA, pm_All)
							If Len(strSQL) = 0 Then
								'エラーが発生
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All) ' MSG内容:更新異常
								GoTo Err_F_Ctl_Upd_Process
							End If
							
							'DBアクセス
							Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
							
							If DBSTAT <> 0 Then
								'データなしの場合
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
								GoTo Err_F_Ctl_Upd_Process
							Else
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strOPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strCLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（日付）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' タイムスタンプ（バッチ時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' タイムスタンプ（バッチ日）
								
								'排他処理が実行中か確認する
								If strOPEID <> .Bus_Inf.SUB_OPEID Or strCLTID <> .Bus_Inf.SUB_CLTID Or strWRTTM <> .Bus_Inf.SUB_WRTTM Or strWRTDT <> .Bus_Inf.SUB_WRTDT Or strUOPEID <> .Bus_Inf.SUB_UOPEID Or strUCLTID <> .Bus_Inf.SUB_UCLTID Or strUWRTTM <> .Bus_Inf.SUB_UWRTTM Or strUWRTDT <> .Bus_Inf.SUB_UWRTDT Then
									'メッセージ表示
									Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
									GoTo Err_F_Ctl_Upd_Process
								End If
							End If
						End If
						
						'初期化
						mv_strKEY_TRAKB = ""
						mv_strKEY_TRANO = ""
						mv_strKEY_MITNOV = ""
						mv_strKEY_LINNO = ""
						mv_strKEY_PUDLNO = ""
						mv_strKEY_TRADT = ""
						mv_strKEY_HINCD = ""
						mv_strKEY_INPYTDT = ""
						mv_strKEY_LOTNO = ""
						mv_strKEY_SOUCD = ""
						
						'倉庫別在庫の場合
						If .Bus_Inf.SUB_KB = "1" Then
							'トラン種別
							mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
							'トラン番号(製番)
							mv_strKEY_TRANO = HIKET54_Interface.SBNNO
							'版数
							mv_strKEY_MITNOV = "  "
							'行番号
							mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
							'入出庫番号
							mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
							'トラン日付
							mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
							'製品コード
							mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
							'入荷予定日
							mv_strKEY_INPYTDT = "        "
							'ロット番号
							mv_strKEY_LOTNO = "                    "
							'倉庫コード
							mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
							'伝票管理№
							mv_strKEY_DATNO = HIKET54_Interface.DATNO
						Else
							'トラン種別
							mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
							'トラン番号(製番)
							mv_strKEY_TRANO = HIKET54_Interface.SBNNO
							'版数
							mv_strKEY_MITNOV = "  "
							'行番号
							mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
							'入出庫番号
							mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
							'トラン日付
							mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
							'製品コード
							mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
							'入荷予定日
							mv_strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
							'ロット番号
							mv_strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
							'倉庫コード
							mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
							'伝票管理№
							mv_strKEY_DATNO = HIKET54_Interface.DATNO
						End If
						
						'支給品ファイルの場合は処理を行う
						If mv_strKEY_TRAKB = "3" Then
							'排他処理情報取得
							strSQL = F_GET_EX_SQL(intCnt, ex_tblKbn.SKYTBL, pm_All)
							If Len(strSQL) = 0 Then
								'エラーが発生
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All) ' MSG内容:更新異常
								GoTo Err_F_Ctl_Upd_Process
							End If
							
							'DBアクセス
							Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
							
							If DBSTAT <> 0 Then
								'データなしの場合
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
								GoTo Err_F_Ctl_Upd_Process
							Else
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strOPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strCLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（日付）
								
								'排他処理が実行中か確認する
								If strOPEID <> HIKET54_Interface.OPEID Or strCLTID <> HIKET54_Interface.CLTID Or strWRTTM <> HIKET54_Interface.WRTTM Or strWRTDT <> HIKET54_Interface.WRTDT Then
									'メッセージ表示
									Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
									GoTo Err_F_Ctl_Upd_Process
								End If
							End If
							
						Else '支給品ファイルでない場合、製番出庫ファイルの処理を行う
							'排他処理情報取得
							strSQL = F_GET_EX_SQL(intCnt, ex_tblKbn.SBNTRA, pm_All)
							If Len(strSQL) = 0 Then
								'エラーが発生
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All) ' MSG内容:更新異常
								GoTo Err_F_Ctl_Upd_Process
							End If
							
							'DBアクセス
							Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
							
							If CF_Ora_EOF(Usr_Ody) = True Then
								'メッセージ表示
								Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_012, pm_All)
								
								GoTo Err_F_Ctl_Upd_Process
							End If
							
							If DBSTAT <> 0 Then
								'データなしの場合
								intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
								GoTo Err_F_Ctl_Upd_Process
							Else
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strOPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strCLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（日付）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' 最終作業者コード
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' クライアントＩＤ
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' タイムスタンプ（バッチ時間）
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strUWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' タイムスタンプ（バッチ日）
								
								'排他処理が実行中か確認する
								If strOPEID <> HIKET54_Interface.OPEID Or strCLTID <> HIKET54_Interface.CLTID Or strWRTTM <> HIKET54_Interface.WRTTM Or strWRTDT <> HIKET54_Interface.WRTDT Or strUOPEID <> HIKET54_Interface.UOPEID Or strUCLTID <> HIKET54_Interface.UCLTID Or strUWRTTM <> HIKET54_Interface.UWRTTM Or strUWRTDT <> HIKET54_Interface.UWRTDT Then
									'メッセージ表示
									Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他端末で更新中です。
									GoTo Err_F_Ctl_Upd_Process
								End If
							End If
						End If
						
						' 引当内訳ファイルの件数分処理を行う
						For intLoop = 1 To UBound(TYPE_DTLTRA_EXEC_BEF)
							With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
								'倉庫別在庫の場合
								If .Bus_Inf.SUB_KB = "1" Then
									'トラン種別
									mv_strDTLTRA_TRAKB = CStr(HIKET54_Interface.Mode)
									'トラン番号(製番)
									mv_strDTLTRA_TRANO = HIKET54_Interface.SBNNO
									'版数
									mv_strDTLTRA_MITNOV = "  "
									'行番号
									mv_strDTLTRA_LINNO = HIKET54_Interface.SPRRENNO
									'入出庫番号
									mv_strDTLTRA_PUDLNO = HIKET54_Interface.PUDLNO
									'トラン日付
									mv_strDTLTRA_TRADT = HIKET54_Interface.ODNYTDT
									'製品コード
									mv_strDTLTRA_HINCD = .Bus_Inf.SUB_HINCD
									'入荷予定日
									mv_strDTLTRA_INPYTDT = "        "
									'ロット番号
									mv_strDTLTRA_LOTNO = "                    "
									'倉庫コード
									mv_strDTLTRA_SOUCD = .Bus_Inf.SUB_SOUCD
									'伝票管理№
									mv_strDTLTRA_DATNO = HIKET54_Interface.DATNO
								Else
									'トラン種別
									mv_strDTLTRA_TRAKB = CStr(HIKET54_Interface.Mode)
									'トラン番号(製番)
									mv_strDTLTRA_TRANO = HIKET54_Interface.SBNNO
									'版数
									mv_strDTLTRA_MITNOV = "  "
									'行番号
									mv_strDTLTRA_LINNO = HIKET54_Interface.SPRRENNO
									'入出庫番号
									mv_strDTLTRA_PUDLNO = HIKET54_Interface.PUDLNO
									'トラン日付
									mv_strDTLTRA_TRADT = HIKET54_Interface.ODNYTDT
									'製品コード
									mv_strDTLTRA_HINCD = .Bus_Inf.SUB_HINCD
									'入荷予定日
									mv_strDTLTRA_INPYTDT = .Bus_Inf.SUB_NYUYTDT
									'ロット番号
									mv_strDTLTRA_LOTNO = .Bus_Inf.SUB_LOTNO
									'倉庫コード
									mv_strDTLTRA_SOUCD = .Bus_Inf.SUB_SOUCD
									'伝票管理№
									mv_strDTLTRA_DATNO = HIKET54_Interface.DATNO
								End If
							End With
							
							
							With TYPE_DTLTRA_EXEC_BEF(intLoop)
								' 条件が一致する場合
								If mv_strDTLTRA_HINCD = .HINCD And mv_strDTLTRA_INPYTDT = .INPYTDT And mv_strDTLTRA_LOTNO = .LOTNO And mv_strDTLTRA_SOUCD = .SOUCD And mv_strDTLTRA_TRANO = .TRANO And mv_strDTLTRA_MITNOV = .MITNOV And mv_strDTLTRA_LINNO = .LINNO Then
									' 引当内訳ファイルから現在の更新日時を取得する
									ls_sql = ""
									ls_sql = ls_sql & "SELECT"
									ls_sql = ls_sql & "  DTL.OPEID OPEID "
									ls_sql = ls_sql & ", DTL.CLTID CLTID "
									ls_sql = ls_sql & ", DTL.WRTTM WRTTM "
									ls_sql = ls_sql & ", DTL.WRTDT WRTDT "
									ls_sql = ls_sql & "FROM"
									ls_sql = ls_sql & "  DTLTRA DTL "
									ls_sql = ls_sql & "WHERE"
									ls_sql = ls_sql & "  TRAKB   =  '" & CF_Ora_String(.SUB_TRAKB, 1) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  TRANO   =  '" & CF_Ora_String(.SUB_TRANO, 20) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  MITNOV  =  '" & CF_Ora_String(.SUB_MITNOV, 2) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  LINNO   =  '" & CF_Ora_String(.SUB_LINNO, 3) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  PUDLNO  =  '" & CF_Ora_String(.SUB_PUDLNO, 10) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  TRADT   =  '" & CF_Ora_String(.SUB_TRADT, 8) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  HIKNO   =  '" & CF_Ora_String(.SUB_HIKNO, 5) & "' "
									ls_sql = ls_sql & "AND"
									ls_sql = ls_sql & "  HINCD   =  '" & CF_Ora_String(.SUB_HINCD, 10) & "' "
									
									ls_sql = ls_sql & "FOR UPDATE"
									
									' DBアクセス
									Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
									
									If DBSTAT <> 0 Then
										' データなしの場合
										intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他のプログラムで更新されたため、更新できません。
										GoTo Err_F_Ctl_Upd_Process
										
									Else
										' 更新前データと異なるデータが存在した場合はエラーとする。
										'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or TYPE_DTLTRA_EXEC_BEF(intLoop).SUB_WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
											intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_901, pm_All) ' MSG内容:他のプログラムで更新されたため、更新できません。
											GoTo Err_F_Ctl_Upd_Process
										End If
									End If
								End If
							End With
						Next intLoop
					End If
				End If
			End With
		Next intCnt
		' === 20080728 === INSERT E -
		
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'登録確認
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_014, pm_All) = MsgBoxResult.No Then
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'更新権限がない場合は処理を行わない
		If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_019, pm_All)
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'ボタン非表示
		FR_SSSSUB01.CM_Execute.Visible = False
		
		'登録処理
		intRet = F_Update_Main(pm_All)
		If intRet <> 0 Then
			GoTo Err_F_Ctl_Upd_Process
		End If
		
		' === 20080728 === INSERT S - RISE)Izumi
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		For intLoop = 1 To UBound(HIKET54_UPDATE_FLAG_Inf)
			' 伝票管理No.と行番号が一致した場合
			If HIKET54_UPDATE_FLAG_Inf(intLoop).DATNO = HIKET54_Interface.DATNO And HIKET54_UPDATE_FLAG_Inf(intLoop).SPRRENNO = HIKET54_Interface.SPRRENNO Then
				' タイムスタンプ等を格納する
				HIKET54_UPDATE_FLAG_Inf(intLoop).OPEID = HIKET54_Interface.OPEID
				HIKET54_UPDATE_FLAG_Inf(intLoop).CLTID = HIKET54_Interface.CLTID
				HIKET54_UPDATE_FLAG_Inf(intLoop).WRTDT = HIKET54_Interface.WRTDT
				HIKET54_UPDATE_FLAG_Inf(intLoop).WRTTM = HIKET54_Interface.WRTTM
				HIKET54_UPDATE_FLAG_Inf(intLoop).UOPEID = HIKET54_Interface.UOPEID
				HIKET54_UPDATE_FLAG_Inf(intLoop).UCLTID = HIKET54_Interface.UCLTID
				HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTDT = HIKET54_Interface.UWRTDT
				HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTTM = HIKET54_Interface.UWRTTM
			End If
		Next intLoop
		' === 20080728 === INSERT E -
		
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_017, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20080728 === INSERT S - RISE)Izumi
		'ロールバック
		If bolTran = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		' === 20080728 === INSERT E -
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'ボタン表示
		FR_SSSSUB01.CM_Execute.Visible = True
		
		gv_bolUpdFlg = False
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Update_Main
	'   概要：  更新メイン処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_All As Cls_All) As Short
		
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim intCnt As Short
		Dim bolTran As Boolean
		Dim intMeiCnt As Short
		
		On Error GoTo F_Update_Main_err
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'列番号取得
		mv_intSOUNM_Col = 1 '倉庫名の列
		mv_intLOTNO_Col = CShort(FR_SSSSUB01.BD_LOTNO(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 'ロット番号
		mv_intINPYTDT_Col = CShort(FR_SSSSUB01.BD_NYUYTDT(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '入庫予定日
		mv_intRELZAISU_Col = CShort(FR_SSSSUB01.BD_RELZAISU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '現在庫数
		mv_intZUMISU_Col = CShort(FR_SSSSUB01.BD_ZUMISU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '引当済数
		mv_intHIKSU_Col = CShort(FR_SSSSUB01.BD_HIKSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '引当可能数
		mv_intMNSU_Col = CShort(FR_SSSSUB01.BD_MNSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '引当可能数
		mv_intINPHIKSU_Col = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag) - CShort(FR_SSSSUB01.BD_SOUNM(1).Tag) + 1 '引当数
		
		intMeiCnt = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'更新時刻取得
		Call CF_Get_SysDt()
		
		' === 20080728 === DELETE S - RISE)Izumi
		'    'トランザクションの開始
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTran = True
		' === 20080728 === DELETE E -
		
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		'出荷指示数を計算用WKへ退避
		mv_curFRDSU_AT_WK = mv_curFRDSU_AT '自動
		mv_curFRDSU_MN_WK = mv_curFRDSU_MN '手動
		' === 20080720 === INSERT E -
		
		For intCnt = 1 To intMeiCnt Step 1
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				'明細編集された行のみ処理を行う
				If .Bus_Inf.SUB_IsDataRow = True Then
					'画面の値と初期明細編集時に退避した値をチェックし、値が変わっていれば処理を続行
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .Item_Detail(mv_intINPHIKSU_Col).Dsp_Value <> .Bus_Inf.SUB_MOTO_HIKSU Then
						
						'SUB_KB = "1"(倉庫別在庫データ)の場合は処理を行う
						If .Bus_Inf.SUB_KB = "1" Then
							'倉庫別在庫マスタ更新
							intRet = F_HINMTB_Update(intCnt, pm_All)
							If intRet <> 0 Then
								GoTo F_Update_Main_err
							End If
						End If
						
						'SUB_KB = "2"(入荷予定ファイル)の場合は処理を行う
						If .Bus_Inf.SUB_KB = "2" Then
							'入荷予定ファイル更新
							intRet = F_INPTRA_Update(intCnt, pm_All)
							If intRet <> 0 Then
								GoTo F_Update_Main_err
							End If
						End If
						
						'引当内訳メイン処理
						intRet = F_DTLTRA_Main(intCnt, pm_All)
						If intRet <> 0 Then
							GoTo F_Update_Main_err
						End If
						
					End If
				End If
				
			End With
			
		Next intCnt
		
		' === 20080728 === DELETE S - RISE)Izumi
		'    'コミット
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTran = False
		' === 20080728 === DELETE E -
		
		F_Update_Main = 0
		
F_Update_Main_End: 
		'砂時計を戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_Update_Main_err: 
		
		' === 20080728 === DELETE S - RISE)Izumi
		'    If bolTran = True Then
		'        'ロールバック
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'    End If
		' === 20080728 === DELETE E -
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_HINMTB_Update
	'   概要：  倉庫別在庫マスタ更新処理
	'   引数：  pin_intRow    : 行番号
	'           pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_HINMTB_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '引当数
		Dim curMotoHikSu As Decimal '元引当数
		Dim curUpdHikSu As Decimal '更新用引当数
		Dim strSOUCD As String '倉庫コード
		Dim strHinCd As String '製品コード
		Dim bolRet As Boolean
		
		On Error GoTo F_HINMTB_Update_err
		
		F_HINMTB_Update = 9
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		
		'引当数
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		'元引当数
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		'更新用引当数
		curUpdHikSu = curMotoHikSu - curHIKSU
		'倉庫コード
		strSOUCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_SOUCD
		'製品コード
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		
		strSQL = ""
		strSQL = strSQL & " UPDATE HINMTB "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSU = HIKSU - " & CF_Ora_Number(CStr(curUpdHikSu))
		strSQL = strSQL & "   , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND SOUCD =  '" & CF_Ora_String(strSOUCD, 3) & "'"
		strSQL = strSQL & " AND HINCD =  '" & CF_Ora_String(strHinCd, 10) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_HINMTB_Update_err
		End If
		
		F_HINMTB_Update = 0
		
F_HINMTB_Update_End: 
		Exit Function
		
F_HINMTB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_HINMTB_Update")
		GoTo F_HINMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_INPTRA_Update
	'   概要：  入荷予定ファイル更新処理
	'   引数：  pin_intRow    : 行番号
	'           pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_INPTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '引当数
		Dim curMotoHikSu As Decimal '元引当数
		Dim curUpdHikSu As Decimal '更新用引当数
		Dim strHinCd As String '製品コード
		Dim strInpYtDt As String '入荷予定日
		Dim strLotNo As String 'ロット番号
		Dim bolRet As Boolean
		
		On Error GoTo F_INPTRA_Update_err
		
		F_INPTRA_Update = 9
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		
		'引当数
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		'元引当数
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		'更新用引当数
		curUpdHikSu = curMotoHikSu - curHIKSU
		'製品コード
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'入荷予定日
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'ロット番号
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		strSQL = strSQL & " UPDATE INPTRA "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     INHIKSU = INHIKSU - " & CF_Ora_Number(CStr(curUpdHikSu))
		strSQL = strSQL & "   , UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND HINCD   =  '" & CF_Ora_String(strHinCd, 10) & "'"
		strSQL = strSQL & " AND INPYTDT =  '" & CF_Ora_String(strInpYtDt, 8) & "'"
		strSQL = strSQL & " AND LOTNO   =  '" & CF_Ora_String(strLotNo, 12) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_INPTRA_Update_err
		End If
		
		F_INPTRA_Update = 0
		
F_INPTRA_Update_End: 
		Exit Function
		
F_INPTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_INPTRA_Update")
		GoTo F_INPTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DTLTRA_Main
	'   概要：  引当内訳メイン処理
	'   引数：  pin_intRow    : 行番号
	'           pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Main(ByVal pin_intRow As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim intRet As Short
		' === 20070312 === INSERT S - ACE)Yano
		Dim intCnt As Short
		' === 20070312 === INSERT E -
		
		On Error GoTo F_DTLTRA_Main_err
		
		F_DTLTRA_Main = 9
		
		'初期化
		mv_strKEY_TRAKB = ""
		mv_strKEY_TRANO = ""
		mv_strKEY_MITNOV = ""
		mv_strKEY_LINNO = ""
		mv_strKEY_PUDLNO = ""
		mv_strKEY_TRADT = ""
		mv_strKEY_HINCD = ""
		mv_strKEY_INPYTDT = ""
		mv_strKEY_LOTNO = ""
		mv_strKEY_SOUCD = ""
		
		With pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow)
			
			'倉庫別在庫の場合
			If .Bus_Inf.SUB_KB = "1" Then
				'トラン種別
				mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
				'トラン番号(製番)
				mv_strKEY_TRANO = HIKET54_Interface.SBNNO
				'版数
				mv_strKEY_MITNOV = "  "
				'行番号
				mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
				'入出庫番号
				mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
				'トラン日付
				mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
				'製品コード
				mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
				'入荷予定日
				mv_strKEY_INPYTDT = "        "
				'ロット番号
				mv_strKEY_LOTNO = "                    "
				'倉庫コード
				mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
				'伝票管理№
				mv_strKEY_DATNO = HIKET54_Interface.DATNO
				' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
				'出荷指示数
				mv_curDTLTRA_FRDSU = .Bus_Inf.SUB_FRDSU
				' === 20080720 === INSERT E -
			Else
				'トラン種別
				mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
				'トラン番号(製番)
				mv_strKEY_TRANO = HIKET54_Interface.SBNNO
				'版数
				mv_strKEY_MITNOV = "  "
				'行番号
				mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
				'入出庫番号
				mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
				'トラン日付
				mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
				'製品コード
				mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
				'入荷予定日
				mv_strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
				'ロット番号
				mv_strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
				'倉庫コード
				mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
				'伝票管理№
				mv_strKEY_DATNO = HIKET54_Interface.DATNO
				' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
				'出荷指示数
				mv_curDTLTRA_FRDSU = .Bus_Inf.SUB_FRDSU
				' === 20080720 === INSERT E -
			End If
			
		End With
		
		' === 20070312 === UPDATE S - ACE)Yano
		
		For intCnt = 1 To 2
			'１回目:元の引当数 ⇒ 0
			'２回目:0 ⇒ 入力引当数
			
			If mv_strKEY_TRAKB = "3" Then
				'支給品ファイル更新
				'intRet = F_SKYTBL_Update(pin_intRow, pm_All)
				intRet = F_SKYTBL_Update(pin_intRow, pm_All, intCnt)
				If intRet <> 0 Then
					GoTo F_DTLTRA_Main_err
				End If
			Else
				'製番出庫ファイル更新
				'intRet = F_SBNTRA_Update(pin_intRow, pm_All)
				intRet = F_SBNTRA_Update(pin_intRow, pm_All, intCnt)
				If intRet <> 0 Then
					GoTo F_DTLTRA_Main_err
				End If
			End If
			
			' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
			'出荷指示数(２回目はマイナス値に変更)
			If intCnt = 2 Then
				mv_curDTLTRA_FRDSU = mv_curDTLTRA_FRDSU * (-1)
			End If
			' === 20080720 === INSERT E -
			
			'引当内訳ファイル処理
			intRet = F_DTLTRA_Prc(pm_All)
			If intRet <> 0 Then
				GoTo F_DTLTRA_Main_err
			End If
			
		Next intCnt
		
		' === 20070312 === UPDATE E -
		
		F_DTLTRA_Main = 0
		
F_DTLTRA_Main_End: 
		Exit Function
		
F_DTLTRA_Main_err: 
		GoTo F_DTLTRA_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DTLTRA_Prc
	'   概要：  引当内訳ファイル処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Prc(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim intRet As Short
		
		On Error GoTo ERR_F_DTLTRA_Prc
		
		F_DTLTRA_Prc = 9
		
		'初期化
		mv_strDTLTRA_UMKB = "0"
		mv_strDTLTRA_TRAKB = ""
		mv_strDTLTRA_TRANO = ""
		mv_strDTLTRA_MITNOV = ""
		mv_strDTLTRA_LINNO = ""
		mv_strDTLTRA_PUDLNO = ""
		mv_strDTLTRA_TRADT = ""
		mv_strDTLTRA_ATMNKB = ""
		mv_strDTLTRA_HIKNO = ""
		mv_strDTLTRA_HINCD = ""
		mv_strDTLTRA_INPYTDT = ""
		mv_strDTLTRA_LOTNO = ""
		mv_strDTLTRA_SOUCD = ""
		mv_strDTLTRA_SISNKB = ""
		mv_strDTLTRA_SOUTRICD = ""
		mv_strDTLTRA_SOUKOKB = ""
		mv_curDTLTRA_HIKSU = 0
		'引当解除数初期セット
		mv_curDTLTRA_HIKSU_SA = mv_curATZHIKSU_SA + mv_curATNHIKSU_SA + mv_curMNZHIKSU_SA + mv_curMNNHIKSU_SA
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		mv_curDTLTRA_HIKSU_SA = mv_curDTLTRA_HIKSU_SA + mv_curDTLTRA_FRDSU
		' === 20080720 === INSERT E -
		
		'引当内訳ファイル取得SQL
		strSQL = F_GET_DTLTRA_SQL
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If mv_curDTLTRA_HIKSU_SA > 0 Then
			
			'///////////////////////////////////////////////
			'/ 引当数を減らした
			'///////////////////////////////////////////////
			
			'取得レコード分or引当解除数に達するまで処理を行う
			If CF_Ora_EOF(Usr_Ody) = False Then
				Do 
					mv_strDTLTRA_UMKB = "1" 'データ有無
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") 'トラン種別
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") 'トラン番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '版数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") '行番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '入出庫番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") 'トラン日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "") '自動手動区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") '引当番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_INPYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '入荷予定日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") 'ロット番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '倉庫コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '資産元区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '取引先コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '倉庫区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_curDTLTRA_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0) '引当数
					
					'更新用引当数の作成
					mv_curDTLTRA_UPD_HIKSU = 0
					'更新用引当数>取得内訳データ(1件分)の引当数の場合
					'差分データを減らし、ZEROで更新
					If mv_curDTLTRA_HIKSU_SA > mv_curDTLTRA_HIKSU Then
						mv_curDTLTRA_HIKSU_SA = mv_curDTLTRA_HIKSU_SA - mv_curDTLTRA_HIKSU
						'念のため現引当数から引く為対象のデータをセット
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU
						'引当内訳ファイル更新用データのセット
						mv_curDTLTRA_HIKSU = 0
					Else
						'更新用引当数<取得内訳データ(1件分)の引当数の場合
						'対象データで引当は完了となる為、差分分を更新
						'念のため現引当数から引く為差分をセット
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU_SA
						'引当内訳ファイル更新用データのセット
						mv_curDTLTRA_HIKSU = mv_curDTLTRA_HIKSU - mv_curDTLTRA_HIKSU_SA
						mv_curDTLTRA_HIKSU_SA = 0
					End If
					
					'引当内訳ファイル更新
					intRet = F_DTLTRA_Update(pm_All)
					If intRet <> 0 Then
						GoTo ERR_F_DTLTRA_Prc
					End If
					
					'次レコード
					Call CF_Ora_MoveNext(Usr_Ody)
				Loop Until CF_Ora_EOF(Usr_Ody) = True Or mv_curDTLTRA_HIKSU_SA <= 0
				
			End If
			
		Else
			
			'///////////////////////////////////////////////
			'/ 引当数を増やした
			'///////////////////////////////////////////////
			
			'取得レコード分or引当解除数に達するまで処理を行う
			If CF_Ora_EOF(Usr_Ody) = False Then
				Do 
					mv_strDTLTRA_UMKB = "1" 'データ有無
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") 'トラン種別
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") 'トラン番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '版数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") '行番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '入出庫番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") 'トラン日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "") '自動手動区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") '引当番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_INPYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '入荷予定日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") 'ロット番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '倉庫コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '資産元区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '取引先コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_strDTLTRA_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '倉庫区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					mv_curDTLTRA_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0) '引当数
					
					If mv_strDTLTRA_ATMNKB = "M" Then
						
						'更新用引当数の作成
						mv_curDTLTRA_UPD_HIKSU = 0
						
						'差分データの全てを引当て更新
						mv_curDTLTRA_UPD_HIKSU = mv_curDTLTRA_HIKSU_SA
						mv_curDTLTRA_HIKSU_SA = 0
						
						'引当内訳ファイル更新
						intRet = F_DTLTRA_Update(pm_All)
						If intRet <> 0 Then
							GoTo ERR_F_DTLTRA_Prc
						End If
						
					End If
					
					'次レコード
					Call CF_Ora_MoveNext(Usr_Ody)
				Loop Until CF_Ora_EOF(Usr_Ody) = True Or mv_curDTLTRA_HIKSU_SA = 0
				
			End If
			
			If mv_curDTLTRA_HIKSU_SA <> 0 Then
				
				'引当内訳ファイル追加
				intRet = F_DTLTRA_Insert(pm_All)
				If intRet <> 0 Then
					GoTo ERR_F_DTLTRA_Prc
				End If
				
			End If
			
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_DTLTRA_Prc = 0
		
		Exit Function
		
ERR_F_DTLTRA_Prc: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_DTLTRA_SQL
	'   概要：  引当内訳ファイル取得ＳＱＬ生成
	'   引数：  なし
	'       ：　pm_All               :画面情報
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SQL() As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     TRAKB "
		strSQL = strSQL & "   , TRANO "
		strSQL = strSQL & "   , MITNOV "
		strSQL = strSQL & "   , LINNO "
		strSQL = strSQL & "   , PUDLNO "
		strSQL = strSQL & "   , TRADT "
		strSQL = strSQL & "   , ATMNKB "
		strSQL = strSQL & "   , HIKNO "
		strSQL = strSQL & "   , HINCD "
		strSQL = strSQL & "   , INPYTDT "
		strSQL = strSQL & "   , LOTNO "
		strSQL = strSQL & "   , SOUCD "
		strSQL = strSQL & "   , SISNKB "
		strSQL = strSQL & "   , SOUTRICD "
		strSQL = strSQL & "   , SOUKOKB "
		strSQL = strSQL & "   , HIKSU "
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品
			strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		Else
			'製番出庫
			strSQL = strSQL & " And LINNO  = '   ' "
		End If
		strSQL = strSQL & " And PUDLNO  = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT   = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And HINCD   = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     ATMNKB DESC "
		
		F_GET_DTLTRA_SQL = strSQL
		
	End Function
	
	' === 20080728 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_DTLTRA_SQL2
	'   概要：  引当内訳ファイル取得ＳＱＬ生成
	'   引数：  なし
	'       ：　pm_All               :画面情報
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SQL2() As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     TRAKB "
		strSQL = strSQL & "   , TRANO "
		strSQL = strSQL & "   , MITNOV "
		strSQL = strSQL & "   , LINNO "
		strSQL = strSQL & "   , PUDLNO "
		strSQL = strSQL & "   , TRADT "
		strSQL = strSQL & "   , ATMNKB "
		strSQL = strSQL & "   , HIKNO "
		strSQL = strSQL & "   , HINCD "
		strSQL = strSQL & "   , INPYTDT "
		strSQL = strSQL & "   , LOTNO "
		strSQL = strSQL & "   , SOUCD "
		strSQL = strSQL & "   , SISNKB "
		strSQL = strSQL & "   , SOUTRICD "
		strSQL = strSQL & "   , SOUKOKB "
		strSQL = strSQL & "   , HIKSU "
		strSQL = strSQL & "   , OPEID "
		strSQL = strSQL & "   , CLTID "
		strSQL = strSQL & "   , WRTTM "
		strSQL = strSQL & "   , WRTDT "
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品
			strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		Else
			'製番出庫
			strSQL = strSQL & " And LINNO  = '   ' "
		End If
		strSQL = strSQL & " And PUDLNO  = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT   = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And HINCD   = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		strSQL = strSQL & " And LOTNO    = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		strSQL = strSQL & " And SOUCD    = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     ATMNKB DESC "
		
		F_GET_DTLTRA_SQL2 = strSQL
		
	End Function
	' === 20080728 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_DTLTRA_SAIBAN
	'   概要：  引当内訳ファイル引当番号採番処理
	'   引数：　pin_intRow           :行番号
	'       ：　pm_All               :画面情報
	'   戻値：　引当番号（採番値）
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SAIBAN() As String
		
		Dim strSQL As String
		Dim strHikNo As String
		Dim curHikNo As Decimal
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		'初期化
		strHikNo = ""
		curHikNo = 0
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " SELECT"
		strSQL = strSQL & "     NVL(MAX(TO_NUMBER(HIKNO)), 0)  HIKNO "
		strSQL = strSQL & " FROM"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE"
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "' "
		strSQL = strSQL & " AND TRANO  = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "' "
		strSQL = strSQL & " AND MITNOV = '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "' "
		strSQL = strSQL & " AND LINNO  = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "' "
		strSQL = strSQL & " AND PUDLNO = '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "' "
		strSQL = strSQL & " AND TRADT  = '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & " AND HINCD  = '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			curHikNo = 1
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curHikNo = CF_Ora_GetDyn(Usr_Ody, "HIKNO", 0)
			'ｶｳﾝﾄｱｯﾌﾟ
			curHikNo = curHikNo + 1
		End If
		
		strHikNo = CStr(curHikNo)
		F_GET_DTLTRA_SAIBAN = CF_ZeroLenFormat(strHikNo, 5)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SBNTRA_Update
	'   概要：  製番出庫ファイル更新処理
	'   引数：  pin_intRow    : 行番号
	'           pm_All        : 画面情報
	'           pin_Cnt       : 回数(1or2)
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_SBNTRA_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All, ByVal pin_Cnt As Short) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '引当数
		Dim curMotoHikSu As Decimal '元引当数
		Dim curUpdHikSu As Decimal '更新用引当数
		Dim strHinCd As String '製品コード
		Dim strInpYtDt As String '入荷予定日
		Dim strLotNo As String 'ロット番号
		Dim bolRet As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim curAtzHikSu As Decimal '自動在庫引当数
		Dim curAtnHikSu As Decimal '自動入庫予定引当数
		Dim curMnzHikSu As Decimal '手動在庫引当数
		Dim curMnnHikSu As Decimal '手動入庫予定引当数
		Dim curUpdAtzHikSu As Decimal '自動在庫引当数(更新用)
		Dim curUpdAtnHikSu As Decimal '自動入庫予定引当数(更新用)
		Dim curUpdMnzHikSu As Decimal '手動在庫引当数(更新用)
		Dim curUpdMnnHikSu As Decimal '手動入庫予定引当数(更新用)
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		Dim curFRDSU_WK As Decimal '出荷指示数（計算用)
		' === 20080720 === INSERT E -
		
		On Error GoTo F_SBNTRA_Update_err
		
		F_SBNTRA_Update = 9
		
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		curFRDSU_WK = mv_curDTLTRA_FRDSU
		' === 20080720 === INSERT E -
		
		'////////////////////////////////////////////////////////////////
		'/ 引当内訳ﾌｧｲﾙの各引当数合計を取得
		'////////////////////////////////////////////////////////////////
		
		'内訳ﾌｧｲﾙ検索SQL（自動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATZHIKSU" '自動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '   ' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtzHikSu = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（自動入庫予定引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATNHIKSU" '自動入庫予定引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '   ' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And LOTNO  = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtnHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtnHikSu = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（手動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNZHIKSU" '手動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '   ' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnzHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnzHikSu = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（手動入庫予定引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNNHIKSU" '手動入庫予定引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '   ' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And LOTNO  = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnnHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnnHikSu = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'////////////////////////////////////////////////////////////////
		'/ 各引当数の算出
		'////////////////////////////////////////////////////////////////
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		strHinCd = ""
		strInpYtDt = ""
		strLotNo = ""
		curUpdAtzHikSu = curAtzHikSu
		curUpdAtnHikSu = curAtnHikSu
		curUpdMnzHikSu = curMnzHikSu
		curUpdMnnHikSu = curMnnHikSu
		
		' === 20070312 === UPDATE S - ACE)Yano
		'引当数
		'curHIKSU = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		If pin_Cnt = 1 Then
			curHIKSU = 0
		Else
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		End If
		'元引当数
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		If pin_Cnt = 1 Then
			curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		Else
			curMotoHikSu = 0
		End If
		' === 20070312 === UPDATE E -
		'更新用引当数
		curUpdHikSu = curMotoHikSu - curHIKSU
		
		'(引当数から変更分をマイナス。増えた分はプラス。)
		If pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_KB = "1" Then
			'倉庫別在庫の場合(実在庫の更新)
			If curMnzHikSu > curUpdHikSu Then
				curUpdMnzHikSu = curMnzHikSu - curUpdHikSu
			Else
				curUpdMnzHikSu = 0
				curUpdAtzHikSu = curAtzHikSu - (curUpdHikSu - curMnzHikSu)
			End If
		Else
			'入荷予定の場合(入荷予定の更新)
			If curMnnHikSu > curUpdHikSu Then
				curUpdMnnHikSu = curMnnHikSu - curUpdHikSu
			Else
				curUpdMnnHikSu = 0
				curUpdAtnHikSu = curAtnHikSu - (curUpdHikSu - curMnnHikSu)
			End If
		End If
		
		mv_curATZHIKSU_SA = curAtzHikSu - curUpdAtzHikSu
		mv_curATNHIKSU_SA = curAtnHikSu - curUpdAtnHikSu
		mv_curMNZHIKSU_SA = curMnzHikSu - curUpdMnzHikSu
		mv_curMNNHIKSU_SA = curMnnHikSu - curUpdMnnHikSu
		
		'////////////////////////////////////////////////////////////////
		'/ 製番出庫ﾌｧｲﾙの更新
		'////////////////////////////////////////////////////////////////
		
		'製品コード
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'入荷予定日
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'ロット番号
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		strSQL = strSQL & " UPDATE SBNTRA"
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSMSU  = HIKSMSU - " & CF_Ora_Number(CStr(mv_curATZHIKSU_SA))
		strSQL = strSQL & "                        - " & CF_Ora_Number(CStr(mv_curATNHIKSU_SA))
		strSQL = strSQL & "                        - " & CF_Ora_Number(CStr(mv_curMNZHIKSU_SA))
		strSQL = strSQL & "                        - " & CF_Ora_Number(CStr(mv_curMNNHIKSU_SA))
		strSQL = strSQL & "   , UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSQL = strSQL & "   , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "'"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATNO   = '" & CF_Ora_String(mv_strKEY_DATNO, 10) & "'"
		strSQL = strSQL & " AND DATKB   = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SBNTRA_Update_err
		End If
		
		' === 20080729 === INSERT S - RISE)Izumi
		'構造体にタイムスタンプ情報を入れ直す
		With HIKET54_Interface
			.UOPEID = SSS_OPEID.Value
			.UCLTID = SSS_CLTID.Value
			.UWRTTM = GV_SysTime
			.UWRTDT = GV_SysDate
		End With
		' === 20080729 === INSERT E -
		
		F_SBNTRA_Update = 0
		
F_SBNTRA_Update_End: 
		Exit Function
		
F_SBNTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_SBNTRA_Update")
		GoTo F_SBNTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SKYTBL_Update
	'   概要：  支給品ファイル更新処理
	'   引数：  pin_intRow    : 行番号
	'           pm_All        : 画面情報
	'           pin_Cnt       : 回数(1or2)
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_SKYTBL_Update(ByVal pin_intRow As Short, ByRef pm_All As Cls_All, ByVal pin_Cnt As Short) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '引当数
		Dim curMotoHikSu As Decimal '元引当数
		Dim curUpdHikSu As Decimal '更新用引当数
		Dim strHinCd As String '製品コード
		Dim strInpYtDt As String '入荷予定日
		Dim strLotNo As String 'ロット番号
		Dim bolRet As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim curAtzHikSu As Decimal '自動在庫引当数
		Dim curAtnHikSu As Decimal '自動入庫予定引当数
		Dim curMnzHikSu As Decimal '手動在庫引当数
		Dim curMnnHikSu As Decimal '手動入庫予定引当数
		Dim curUpdAtzHikSu As Decimal '自動在庫引当数(更新用)
		Dim curUpdAtnHikSu As Decimal '自動入庫予定引当数(更新用)
		Dim curUpdMnzHikSu As Decimal '手動在庫引当数(更新用)
		Dim curUpdMnnHikSu As Decimal '手動入庫予定引当数(更新用)
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		Dim curFRDSU_WK As Decimal '出荷指示数（計算用)
		' === 20080720 === INSERT E -
		
		On Error GoTo F_SKYTBL_Update_err
		
		F_SKYTBL_Update = 9
		
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		curFRDSU_WK = mv_curDTLTRA_FRDSU
		' === 20080720 === INSERT E -
		
		'////////////////////////////////////////////////////////////////
		'/ 支給品ﾌｧｲﾙの各引当数を取得
		'////////////////////////////////////////////////////////////////
		
		'現在の支給品ﾌｧｲﾙ検索SQL
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     ATZHIKSU" '自動在庫引当数
		strSQL = strSQL & "    ,ATNHIKSU" '自動入庫予定引当数
		strSQL = strSQL & "    ,MNZHIKSU" '手動在庫引当数
		strSQL = strSQL & "    ,MNNHIKSU" '手動入庫予定引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     SKYTBL"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND SPRNOKDT = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "'"
		strSQL = strSQL & " AND HINCD    = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "'"
		strSQL = strSQL & " AND SBNNO    = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "'"
		strSQL = strSQL & " AND PLANKB   = ' '"
		strSQL = strSQL & " AND SPRRENNO = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu = 0
			curAtnHikSu = 0
			curMnzHikSu = 0
			curMnnHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtzHikSu = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtnHikSu = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnzHikSu = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnnHikSu = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'////////////////////////////////////////////////////////////////
		'/ 引当内訳ﾌｧｲﾙの各引当数合計を取得
		'////////////////////////////////////////////////////////////////
		
		'内訳ﾌｧｲﾙ検索SQL（自動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATZHIKSU" '自動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtzHikSu = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（自動入庫予定引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATNHIKSU" '自動入庫予定引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And LOTNO  = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtnHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtnHikSu = CF_Ora_GetDyn(Usr_Ody, "ATNHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（手動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNZHIKSU" '手動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT = "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnzHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnzHikSu = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（手動入庫予定引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNNHIKSU" '手動入庫予定引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(mv_strKEY_TRAKB, 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(mv_strKEY_PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "' "
		If mv_strKEY_INPYTDT <> "        " Then
			strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String(mv_strKEY_INPYTDT, 8) & "' "
		Else
			strSQL = strSQL & " And INPYTDT = '99999999' "
		End If
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And LOTNO  = '" & CF_Ora_String(mv_strKEY_LOTNO, 20) & "' "
		'ADD 20151202 START C2-20151106-03
		strSQL = strSQL & " And SOUCD  = '" & CF_Ora_String(mv_strKEY_SOUCD, 3) & "' "
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnnHikSu = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnnHikSu = CF_Ora_GetDyn(Usr_Ody, "MNNHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'////////////////////////////////////////////////////////////////
		'/ 各引当数の算出
		'////////////////////////////////////////////////////////////////
		
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		'自動分在庫引当数を計算（出荷指示数をマイナス)
		If mv_curFRDSU_AT_WK > 0 Then
			If curFRDSU_WK > 0 Then
				If mv_curFRDSU_AT_WK >= curFRDSU_WK Then
					If curAtzHikSu - curFRDSU_WK >= 0 Then
						curAtzHikSu = curAtzHikSu - curFRDSU_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curFRDSU_WK
						End If
						curFRDSU_WK = 0
					Else
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curAtzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curAtzHikSu
						curAtzHikSu = 0
					End If
				Else
					If curAtzHikSu - mv_curFRDSU_AT_WK >= 0 Then
						curAtzHikSu = curAtzHikSu - mv_curFRDSU_AT_WK
						curFRDSU_WK = curFRDSU_WK - mv_curFRDSU_AT_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = 0
						End If
					Else
						If pin_Cnt = 2 Then
							mv_curFRDSU_AT_WK = mv_curFRDSU_AT_WK - curAtzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curAtzHikSu
						curAtzHikSu = 0
					End If
				End If
			End If
		End If
		
		'手動分在庫引当数を計算（出荷指示数をマイナス)
		If mv_curFRDSU_MN_WK > 0 Then
			If curFRDSU_WK > 0 Then
				If mv_curFRDSU_MN_WK >= curFRDSU_WK Then
					If curMnzHikSu - curFRDSU_WK >= 0 Then
						curMnzHikSu = curMnzHikSu - curFRDSU_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curFRDSU_WK
						End If
						curFRDSU_WK = 0
					Else
						'こちらのロジックは通らないはず(念のため。。)
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curMnzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curMnzHikSu
						curMnzHikSu = 0
					End If
				Else
					If curMnzHikSu - mv_curFRDSU_MN_WK >= 0 Then
						curMnzHikSu = curMnzHikSu - mv_curFRDSU_MN_WK
						curFRDSU_WK = curFRDSU_WK - mv_curFRDSU_MN_WK
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = 0
						End If
					Else
						'こちらのロジックは通らないはず(念のため。。)
						If pin_Cnt = 2 Then
							mv_curFRDSU_MN_WK = mv_curFRDSU_MN_WK - curMnzHikSu
						End If
						curFRDSU_WK = curFRDSU_WK - curMnzHikSu
						curMnzHikSu = 0
					End If
				End If
			End If
		End If
		' === 20080720 === INSERT E -
		
		curHIKSU = 0
		curMotoHikSu = 0
		curUpdHikSu = 0
		strHinCd = ""
		strInpYtDt = ""
		strLotNo = ""
		curUpdAtzHikSu = curAtzHikSu
		curUpdAtnHikSu = curAtnHikSu
		curUpdMnzHikSu = curMnzHikSu
		curUpdMnnHikSu = curMnnHikSu
		
		' === 20070312 === UPDATE S - ACE)Yano
		'引当数
		'curHIKSU = CCur(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		If pin_Cnt = 1 Then
			curHIKSU = 0
		Else
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curHIKSU = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Item_Detail(mv_intINPHIKSU_Col).Dsp_Value)
		End If
		'元引当数
		curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		If pin_Cnt = 1 Then
			curMotoHikSu = CDec(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_MOTO_HIKSU)
		Else
			curMotoHikSu = 0
		End If
		' === 20070312 === UPDATE E -
		'更新用引当数
		curUpdHikSu = curMotoHikSu - curHIKSU
		
		'(引当数から変更分をマイナス。増えた分はプラス。)
		If pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_KB = "1" Then
			'倉庫別在庫の場合(実在庫の更新)
			If curMnzHikSu > curUpdHikSu Then
				curUpdMnzHikSu = curMnzHikSu - curUpdHikSu
			Else
				curUpdMnzHikSu = 0
				curUpdAtzHikSu = curAtzHikSu - (curUpdHikSu - curMnzHikSu)
			End If
		Else
			'入荷予定の場合(入荷予定の更新)
			If curMnnHikSu > curUpdHikSu Then
				curUpdMnnHikSu = curMnnHikSu - curUpdHikSu
			Else
				curUpdMnnHikSu = 0
				curUpdAtnHikSu = curAtnHikSu - (curUpdHikSu - curMnnHikSu)
			End If
		End If
		
		mv_curATZHIKSU_SA = curAtzHikSu - curUpdAtzHikSu
		mv_curATNHIKSU_SA = curAtnHikSu - curUpdAtnHikSu
		mv_curMNZHIKSU_SA = curMnzHikSu - curUpdMnzHikSu
		mv_curMNNHIKSU_SA = curMnnHikSu - curUpdMnnHikSu
		
		'////////////////////////////////////////////////////////////////
		'/ 支給品ﾌｧｲﾙの更新
		'////////////////////////////////////////////////////////////////
		
		'製品コード
		strHinCd = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_HINCD
		'入荷予定日
		strInpYtDt = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_NYUYTDT
		'ロット番号
		strLotNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SUB_LOTNO
		
		strSQL = ""
		strSQL = strSQL & " UPDATE SKYTBL"
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     ATZHIKSU = ATZHIKSU - " & CF_Ora_Number(CStr(mv_curATZHIKSU_SA))
		strSQL = strSQL & "   , ATNHIKSU = ATNHIKSU - " & CF_Ora_Number(CStr(mv_curATNHIKSU_SA))
		strSQL = strSQL & "   , MNZHIKSU = MNZHIKSU - " & CF_Ora_Number(CStr(mv_curMNZHIKSU_SA))
		strSQL = strSQL & "   , MNNHIKSU = MNNHIKSU - " & CF_Ora_Number(CStr(mv_curMNNHIKSU_SA))
		' === 20080729 === INSERT S - RISE)Izumi
		strSQL = strSQL & "   , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		' === 20080729 === INSERT E -
		strSQL = strSQL & "   , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSQL = strSQL & "   , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND SPRNOKDT = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "'"
		strSQL = strSQL & " AND HINCD    = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "'"
		strSQL = strSQL & " AND SBNNO    = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "'"
		strSQL = strSQL & " AND PLANKB   = ' '"
		strSQL = strSQL & " AND SPRRENNO = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SKYTBL_Update_err
		End If
		
		' === 20080729 === INSERT S - RISE)Izumi
		'構造体にタイムスタンプ情報を入れ直す
		With HIKET54_Interface
			.OPEID = SSS_OPEID.Value
			.CLTID = SSS_CLTID.Value
			.WRTTM = GV_SysTime
			.WRTDT = GV_SysDate
		End With
		' === 20080729 === INSERT E -
		
		F_SKYTBL_Update = 0
		
F_SKYTBL_Update_End: 
		Exit Function
		
F_SKYTBL_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_SKYTBL_Update")
		GoTo F_SKYTBL_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DTLTRA_Update
	'   概要：  引当内訳ファイル更新処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Update(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim curHIKSU As Decimal '引当数
		Dim bolRet As Boolean
		
		On Error GoTo F_DTLTRA_Update_err
		
		F_DTLTRA_Update = 9
		
		strSQL = ""
		strSQL = strSQL & " UPDATE DTLTRA "
		strSQL = strSQL & " SET "
		strSQL = strSQL & "     HIKSU   = HIKSU - " & CF_Ora_Number(CStr(mv_curDTLTRA_UPD_HIKSU))
		' === 20080729 === INSERT S - RISE)Izumi
		strSQL = strSQL & "   , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		' === 20080729 === INSERT E -
		strSQL = strSQL & "   , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "   , WRTTM   = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , WRTDT   = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB   =  '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "'"
		strSQL = strSQL & " AND TRANO   =  '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "'"
		strSQL = strSQL & " AND MITNOV  =  '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   =  '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND PUDLNO  =  '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "'"
		strSQL = strSQL & " AND TRADT   =  '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "'"
		strSQL = strSQL & " AND HIKNO   =  '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "'"
		strSQL = strSQL & " AND HINCD   =  '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Update_err
		End If
		
		' 引当数=0ならば、削除する
		strSQL = ""
		strSQL = strSQL & " DELETE FROM DTLTRA "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB   = '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "'"
		strSQL = strSQL & " AND TRANO   = '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "'"
		strSQL = strSQL & " AND MITNOV  = '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
		strSQL = strSQL & " AND LINNO   = '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
		strSQL = strSQL & " AND PUDLNO  = '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "'"
		strSQL = strSQL & " AND TRADT   = '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & " AND HIKNO   = '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "'"
		strSQL = strSQL & " AND HINCD   = '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		strSQL = strSQL & " AND HIKSU   = 0 "
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Update_err
		End If
		
		F_DTLTRA_Update = 0
		
F_DTLTRA_Update_End: 
		Exit Function
		
F_DTLTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_DTLTRA_Update")
		GoTo F_DTLTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DTLTRA_Insert
	'   概要：  引当内訳ファイル追加処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DTLTRA_Insert(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_DTLTRA_Insert_err
		
		F_DTLTRA_Insert = 9
		
		'実在庫を引き当てる為、現レコードのデータをセット
		mv_strDTLTRA_TRAKB = mv_strKEY_TRAKB 'トラン種別
		mv_strDTLTRA_TRANO = mv_strKEY_TRANO 'トラン番号
		mv_strDTLTRA_MITNOV = mv_strKEY_MITNOV '版数
		mv_strDTLTRA_LINNO = mv_strKEY_LINNO '行番号
		mv_strDTLTRA_PUDLNO = mv_strKEY_PUDLNO '入出庫番号
		mv_strDTLTRA_TRADT = mv_strKEY_TRADT 'トラン日付
		mv_strDTLTRA_ATMNKB = "M" '自動手動区分
		mv_strDTLTRA_HINCD = mv_strKEY_HINCD '製品コード
		mv_strDTLTRA_SOUCD = mv_strKEY_SOUCD '製品コード
		
		mv_strDTLTRA_HIKNO = F_GET_DTLTRA_SAIBAN '引当番号(採番処理)
		
		mv_strDTLTRA_INPYTDT = mv_strKEY_INPYTDT '入荷予定日
		mv_strDTLTRA_LOTNO = mv_strKEY_LOTNO 'ロット番号
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO DTLTRA "
		strSQL = strSQL & "  SELECT "
		strSQL = strSQL & "     '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_ATMNKB, 1) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_INPYTDT, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_LOTNO, 20) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(mv_strDTLTRA_SOUCD, 3) & "' "
		strSQL = strSQL & "   , SOUMTA.SISNKB "
		strSQL = strSQL & "   , SOUMTA.SOUTRICD "
		strSQL = strSQL & "   , SOUMTA.SOUKOKB "
		strSQL = strSQL & "   ,  " & CF_Ora_Number(CStr(System.Math.Abs(mv_curDTLTRA_HIKSU_SA)))
		strSQL = strSQL & "   , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysTime, 6) & "' "
		strSQL = strSQL & "   , '" & CF_Ora_String(GV_SysDate, 8) & "' "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        SOUMTA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(mv_strDTLTRA_SOUCD, 3) & "' "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_DTLTRA_Insert_err
		End If
		
		F_DTLTRA_Insert = 0
		
F_DTLTRA_Insert_End: 
		Exit Function
		
F_DTLTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_DTLTRA_Insert")
		GoTo F_DTLTRA_Insert_End
		
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
					'画面ボディ情報の配列を再設定
					Call CF_Dell_Refresh_Body_Inf(pm_All)
					'画面表示
					Call CF_Body_Dsp(pm_All)
					'明細カラー付け
					Call CF_Set_BD_Color(pm_All)
					'コントロール制御
					Call F_Set_Body_Enable(pm_All)
					
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
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Next_Focus
	'   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'ボディ部
			'Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'最終準備行の場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'入力可能な最初の項目の場合
					'モードにより検索開始位置を決定
					Select Case pm_Mode
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN、KEYDOWNの場合
							'検索開始はフッタ部の最初の項目から
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHTの場合
							'割当ｲﾝﾃﾞｯｸｽ取得
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'最終準備行以外の場合
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'表示されている最終行の場合
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'入力可能な最後の項目の場合
						If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
							'最終準備行以外＆画面上の最終行＆最終項目
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
							
							'画面の内容を退避
							Call CF_Body_Bkup(pm_All)
							'移動可能行を一番下に表示した場合の最上明細インデックスを設定
							pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
							If pm_All.Bd_Vs_Scrl Is Nothing = False Then
								'縦スクロールバーを設定
								Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
							End If
							'画面ボディ情報の配列を再設定
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							'画面表示
							Call CF_Body_Dsp(pm_All)
							'明細カラー付け
							Call CF_Set_BD_Color(pm_All)
							'コントロール制御
							Call F_Set_Body_Enable(pm_All)
							
							'明細１番下行の入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'明細１番下行の最初の項目の一つ前から検索
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
							Else
								'検索開始は対象の項目の次
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							End If
							
						Else
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						End If
					Else
						'入力可能な最後の項目以外の場合
						'検索開始は対象の項目の次
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'最終行以外場合
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'ボディ部以外
			'検索開始は対象の項目の次
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk <> CHK_OK Then
					'チェックＮＧの場合
					Exit For
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
		
		'最終項目まで検索終了時
		If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
			'モードにより検索終了後の処理を決定
			Select Case pm_Mode
				Case NEXT_FOCUS_MODE_KEYRETURN
					'KEYRETURNの場合
					'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
					'移動先が検索不可の場合
					'更新前チェック⇒ＤＢ更新⇒初期化
					Call FR_SSSSUB01.Ctl_MN_Execute_Click()
					'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
					pm_Move_Flg = True
				Case NEXT_FOCUS_MODE_KEYRIGHT
					'KEYRIGHTの場合
					'検索開始項目で選択状態が移動する
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
				Case NEXT_FOCUS_MODE_KEYDOWN
					'KEYDOWNの場合
					
			End Select
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Left_Next_Focus
	'   概要：  Left押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
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
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'開始位置が一番左の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
							'ENTキー押下と同様に次の項目へ
							Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
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
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
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
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細カラー付け
						Call CF_Set_BD_Color(pm_All)
						'コントロール制御
						Call F_Set_Body_Enable(pm_All)
						
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
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'明細部以外の場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
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
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細カラー付け
						Call CF_Set_BD_Color(pm_All)
						'コントロール制御
						Call F_Set_Body_Enable(pm_All)
						
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
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
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
			If Wk_Mode = ITM_ALL_CLR Then
				'フッタ部以降の項目を全ﾌｫｰｶｽなしとする
				If Index_Wk > pm_All.Dsp_Base.Foot_Fst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 1
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'画面ボディ情報
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'スクロール初期化
			'最大値
			Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最小値
			Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最大ｽｸﾛｰﾙ量
			Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最小ｽｸﾛｰﾙ量
			Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'初期値
			Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'配列０の初期情報を対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'全体初期化の場合
			If Wk_Mode = BODY_ALL_CLR Then
				'全行初期状態
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'個別初期化
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
			'(対象の明細の番号情報だけが必要、)
			Wk_Index = CShort(FR_SSSSUB01.BD_SOUNM(Index_Bd_Wk).Tag)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			'Dsp_Body_Infの行ＮＯに変換
			Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Dsp_Body_Infに値を初期値を設定
			Call F_Init_Dsp_Body(Wk_Row, pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'案件ＩＤにフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
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
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
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
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
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
	'   名称：  Function F_Dsp_BD_INP_HIKSU_Inf
	'   概要：  引当数よる画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_INP_HIKSU_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		'画面の行
		Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'前回チェック内容ではなく、前回内容と比較し、変更されていればフラグ立てる
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Value) Then
					'画面編集ありとする
					gv_bolHIKET54_INIT = True
				End If
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_INP_HIKSU
	'   概要：  引当数のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'         　pm_Row_Cnt            :行番号(明細ﾁｪｯｸ用)
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSU(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All, ByRef pm_Row_Cnt As Short) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_INP_HIKSU = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = gc_strMsgHIKET54_E_011 '未入力エラー
			'未入力以外のチェック済
			'(初期値が入っている場合、未入力OKとさせない為、フラグを立てる)
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_010 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
			End If
			
			'個別チェック
			If Retn_Code = CHK_OK Then
				If CInt(Input_Value) < 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET54_E_006 'マイナスエラー
				End If
			End If
			
			'個別チェック
			If Retn_Code = CHK_OK Then
				'引当可能数オーバーチェック
				Retn_Code = F_Chk_BD_INP_HIKSU_Over(pm_Chk_Dsp_Sub_Inf, Err_Cd, pm_All, pm_Row_Cnt)
			End If
			
			'個別チェック
			If Retn_Code = CHK_OK Then
				
				'入力引当数＞受注数の場合エラー
				If HIKET54A_DSP_DATA_Inf.UODSU < CF_Get_CCurString(Input_Value) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET54_E_015
				End If
			End If
			
			'明細合計の退避
			If Retn_Code = CHK_OK Then
				'前回の内容をマイナス
				HIKET54A_DSP_DATA_Inf.HIKSUKEI = HIKET54A_DSP_DATA_Inf.HIKSUKEI - CF_Get_CcurVariant(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU_BEF)
				'今回の内容をプラス
				HIKET54A_DSP_DATA_Inf.HIKSUKEI = HIKET54A_DSP_DATA_Inf.HIKSUKEI + CF_Get_CcurVariant(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value)
				'前回入力引当済数を格納
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU_BEF = CF_Get_CcurVariant(Input_Value)
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_INP_HIKSU = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_INP_HIKSU_Over
	'   概要：  引当数が引当可能数を越えているかチェックを行う
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_ErrCd   　　　　　 :エラーコード
	'           pm_All                :画面情報
	'         　pm_Row_Cnt            :行番号(明細ﾁｪｯｸ用)
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSU_Over(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_ErrCd As String, ByRef pm_All As Cls_All, ByRef pm_Row_Cnt As Short) As Short
		
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim curHIKSU As Decimal
		Dim curHikKnSu As Decimal
		Dim curMotoHikSu As Decimal
		
		Rtn_Cd = CHK_OK
		pm_ErrCd = ""
		
		'全体チェック以外の場合は行番号を編集
		If pm_Row_Cnt = 0 Then
			'pm_All.Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		Else
			'ﾁｪｯｸ用行番号を使用する
			Bd_Index = pm_Row_Cnt
		End If
		
		'隠し行の場合はチェックしない
		If Bd_Index <> 0 Then
			'引当数の退避
			'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curHIKSU = pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value
			'引当可能数の退避
			curHikKnSu = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_HIKSU
			'元引当数の退避
			curMotoHikSu = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_MOTO_HIKSU
			
			'引当可能数チェック
			If curHIKSU > curHikKnSu + curMotoHikSu Then
				Rtn_Cd = CHK_ERR_ELSE
				pm_ErrCd = gc_strMsgHIKET54_E_007
			End If
		End If
		
		F_Chk_BD_INP_HIKSU_Over = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_INP_HIKSUKEI_Over
	'   概要：  引当数の合計が引当済数を越えているかチェックを行う
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_ErrCd   　　　　　 :エラーコード
	'           pm_All                :画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_INP_HIKSUKEI_Over(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_ErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Cd As Short
		Dim curHikSuKei As Decimal
		Dim curZumiSu As Decimal
		
		Rtn_Cd = CHK_OK
		pm_ErrCd = ""
		curHikSuKei = 0
		curZumiSu = 0
		
		'引当済数の退避
		curZumiSu = HIKET54A_DSP_DATA_Inf.UODSU
		
		'明細合計
		curHikSuKei = HIKET54A_DSP_DATA_Inf.HIKSUKEI
		'前回の内容をマイナス
		'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curHikSuKei = curHikSuKei - CDec(pm_Chk_Dsp_Sub_Inf.Detail.Bef_Value)
		'今回の内容をプラス
		'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		curHikSuKei = curHikSuKei + CDec(pm_Chk_Dsp_Sub_Inf.Detail.Dsp_Value)
		
		'明細の引当数の合計＞引当済合計の場合はエラー
		If curHikSuKei > curZumiSu Then
			Rtn_Cd = CHK_ERR_ELSE
			pm_ErrCd = gc_strMsgHIKET54_E_008
		End If
		
		F_Chk_BD_INP_HIKSUKEI_Over = Rtn_Cd
		
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
			Case FR_SSSSUB01.BD_INP_HIKSU(1).Name
				'引当数による画面表示
				Call F_Dsp_BD_INP_HIKSU_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
		End Select
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Chk
	'   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　pm_Dsp_Sub_Inf   :画面情報
	'         　pm_Process       :ﾁｪｯｸ関数呼出元
	'         　pm_Chk_Move_Flg  :移動フラグ
	'         　pm_All           :画面情報
	'         　pm_Row_Cnt       :行番号(明細ﾁｪｯｸ用)
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Row_Cnt As Short = 0) As Short
		
		Dim Rtn_Chk As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'①基本入力内容のチェック
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSSUB01.BD_INP_HIKSU(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'引当数のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_INP_HIKSU(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All, pm_Row_Cnt)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
		End Select
		
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
		Dim Dsp_Mode As Short
		Dim intMoveFocus As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
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
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'未入力メッセージ
				If Rtn_Chk = CHK_ERR_NOT_INPUT Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_011, pm_All)
				End If
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		'チェックＮＧ
		If Rtn_Chk <> CHK_OK Then
			
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
			
			F_Ctl_Head_Chk = Rtn_Chk
			Exit Function
		End If
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'フッタ部を開放する
			Call F_Foot_In_Ready(pm_All)
			'チェックＯＫ
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_RelChk
	'   概要：  ﾍｯﾀﾞ部の関連ﾁｪｯｸ
	'   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象（ゼロ:案件IDへ移動）
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Trg_Index As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_ERR_ELSE
		
		Rtn_Chk = CHK_OK
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Body_Chk
	'   概要：  ﾎﾞﾃﾞｨ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk_Col As Short
		Dim Index_Wk_Row As Short
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Dsp_Mode As Short
		
		Dim Err_Row As Short
		Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Bd_Idx As Short
		Dim Err_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
					'入力待状態、入力済状態状態を対象
					
					' === 20070320 === INSERT S - ACE)Nagasawa
					'隠行に画面明細の対象行をコピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					' === 20070320 === INSERT E -
					
					For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
						
						'画面明細の隠行の項目のｲﾝﾃﾞｯｸｽを取得
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
						
						'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All, Index_Wk_Row)
						
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
						Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
						
						'｢画面ボディ情報｣にワークの｢画面項目情報｣を編集
						'画面項目詳細情報を設定
						'条件によって変更される項目のみ
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						
						' === 20070320 === INSERT S - ACE)Nagasawa
						'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Index_Wk_Col).Bef_Chk_Value = Dsp_Sub_Inf_Wk.Detail.Bef_Chk_Value
						'画面明細の対象行に隠行をコピー
						Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
						' === 20070320 === INSERT E -
						
						'チェックＮＧ
						If Rtn_Chk <> CHK_OK Then
							
							'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
							'エラー用変数格納
							'行情報
							Err_Row = Index_Wk_Row
							'対象ｺﾝﾄﾛｰﾙ情報
							Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
							'画面項目詳細情報を設定
							'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
							
							GoTo ERR_EXIT
						End If
						
					Next 
			End Select
		Next 
		
		'関連ﾁｪｯｸ
		If HIKET54A_DSP_DATA_Inf.HIKSUKEI > HIKET54A_DSP_DATA_Inf.UODSU Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_008, pm_All)
			Rtn_Chk = CHK_ERR_ELSE
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		
		Exit Function
		
ERR_EXIT: 
		'エラー時、ﾌｫｰｶｽ移動
		'対象行を画面に表示
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'対象行から画面明細の行を取得
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'画面明細の行と同一の明細をインデックスを取得
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		'項目の色設定
		Call CF_Set_BD_Color(pm_All)
		
		If Err_Index > 0 Then
			'同一項目の１つ前からENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Foot_In_Ready
	'   概要：  フッタ部の入力準備
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Enable
	'   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
	'   　　　　明細行のｺﾝﾄﾛｰﾙ制御を行う
	'   引数：　pm_All　: 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		Dim InpRow As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'** ｺﾝﾄﾛｰﾙ制御 **
					Select Case Index_Wk
						'引当数
						Case CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(2).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(3).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(4).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(5).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(6).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(7).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(8).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(9).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(10).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(11).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(12).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(13).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(14).Tag), CShort(FR_SSSSUB01.BD_INP_HIKSU(15).Tag)
							
							'【引当数】
							Wk_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
							Call CF_Set_Dsp_Body_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
							
					End Select
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Bef_Chk_Value
	'   概要：  明細表示時にチェック済み項目とする
	'   引数：　pm_All　: 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Bef_Chk_Value(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
					Select Case True
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.TextBox
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))) <> "" Then
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.CheckBox
							If CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk)) <> System.Windows.Forms.CheckState.Unchecked Then
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
					End Select
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DSP_BD_Inf_SUB
	'   概要：  ボディ部編集_サブ照会画面用
	'   引数：　なし
	'   戻値：　処理ステータス
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DSP_BD_Inf_SUB(ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		Dim intRet As Short
		
		Dim Trg_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'ヘッダデータ取得
			intCnt = F_GET_HD_DATA(HIKET54A_DSP_DATA_Inf, pm_All)
			
			'データ取得
			intCnt = F_GET_BD_DATA(HIKET54A_DSP_DATA_Inf, pm_All)
			
			If intCnt > 0 Then
				'データ編集
				intRet = F_SET_BD_DATA(HIKET54A_DSP_DATA_Inf, pm_All, intCnt)
			End If
			
		End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_HD_DATA
	'   概要：  ヘッダ部データ取得
	'   引数：　pm_All                :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_HD_DATA(ByRef pm_HIKET54A_DSP_DATA As HIKET54A_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim strCode1 As String
		Dim strCode2 As String
		Dim strCode3 As String
		Dim strCode4 As String
		Dim HIKET54A_DSP_DATA_Clr As HIKET54A_DSP_DATA
		
		On Error GoTo ERR_F_GET_HD_DATA
		
		F_GET_HD_DATA = -1
		
		'初期化
		'UPGRADE_WARNING: オブジェクト pm_HIKET54A_DSP_DATA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_HIKET54A_DSP_DATA = HIKET54A_DSP_DATA_Clr
		
		'検索ＳＱＬ生成
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品情報
			strCode1 = Trim(HIKET54_Interface.ODNYTDT)
			strCode2 = Trim(HIKET54_Interface.HINCD)
			strCode3 = Trim(HIKET54_Interface.SBNNO)
			strCode4 = Trim(HIKET54_Interface.SPRRENNO)
			strSQL = F_GET_SKY_HD_SQL(strCode1, strCode2, strCode3, strCode4)
			intMode = 3
		Else
			'製番出庫情報
			strCode1 = Trim(HIKET54_Interface.DATNO)
			strSQL = F_GET_SBN_HD_SQL(strCode1, strCode1)
			intMode = 4
		End If
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし（つまり、すべて対象外）
			F_GET_HD_DATA = 0
			'メッセージ表示
			Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_009, pm_All)
			
			Exit Function
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'モード
			pm_HIKET54A_DSP_DATA.Mode = intMode
			'数量(ヘッダ)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_HIKET54A_DSP_DATA.UODSU = CF_Ora_GetDyn(Usr_Ody, "UODSU", 0)
			'引当済数(ヘッダ)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_HIKET54A_DSP_DATA.ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0)
			
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		'自動/手動出荷指示数取得
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品情報
			If F_GET_FRDSU_ATMN_SKY(pm_All) <> 9 Then
				Exit Function
			End If
		Else
			mv_curFRDSU_AT = 0 '自動引当分出荷指示数
			mv_curFRDSU_MN = 0 '手動引当分出荷指示数
		End If
		' === 20080720 === INSERT E -
		
		F_GET_HD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_HD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：　pm_All                :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_DATA(ByRef pm_HIKET54A_DSP_DATA As HIKET54A_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim HIKET54A_DSP_DATA_Clr As HIKET54A_DSP_DATA
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'初期化
		gv_bolHIKET54A_CNT = 0
		
		'入荷予定ファイル取得
		strSQL = F_GET_INP_SQL
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし（つまり、すべて対象外）
			F_GET_BD_DATA = 0
			'メッセージ表示
			Call AE_CmnMsgLibrary(SSS_PrgId, gc_strMsgHIKET54_E_009, pm_All)
			
			Exit Function
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			With pm_HIKET54A_DSP_DATA
				'１レコード目より見出し情報退避
				'支給品データ、製番出庫データ共通部分
				.Mode = HIKET54_Interface.Mode '種別
				.SBNNO = HIKET54_Interface.SBNNO '製番
				.HINCD = HIKET54_Interface.HINCD '製品コード
				.HINNMA = HIKET54_Interface.HINNMA '型式
				.HINNMB = HIKET54_Interface.HINNMB '品名
				'支給品データの場合
				If .Mode = 3 Then
					.DENSBT = "支給品　" '伝票種別
					'製番出庫データの場合
				Else
					.DENSBT = "製番出庫" '伝票種別
				End If
			End With
			
			intCnt = 0
			'取得全レコードよりボディ情報退避
			Do Until CF_Ora_EOF(Usr_Ody) = True
				intCnt = intCnt + 1
				'データ件数退避
				gv_bolHIKET54A_CNT = intCnt
				
				'行追加
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					'(6.)
					.Bus_Inf.SUB_IsDataRow = True
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_KB = CF_Ora_GetDyn(Usr_Ody, "KB", "") '区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '倉庫コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "") '資産元区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "") '取引先コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "") '倉庫区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '倉庫名
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_LOTNO = CF_Ora_GetDyn(Usr_Ody, "LOTNO", "") 'ロット番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_NYUYTDT = CF_Ora_GetDyn(Usr_Ody, "INPYTDT", "") '入庫予定日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_RELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0) '現在庫数
					' === 20080720 === UPDATE S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
					'                .Bus_Inf.SUB_ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0)               '引当済数
					'                .Bus_Inf.SUB_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)                 '引当可能数
					'                .Bus_Inf.SUB_INP_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)         '引当数
					'                .Bus_Inf.SUB_MOTO_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)        '引当数
					'                .Bus_Inf.SUB_HIKSU_BEF = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0)         '前回入力引当済数
					'                .Bus_Inf.SUB_MNSU = CF_Ora_GetDyn(Usr_Ody, "MNSU", 0)                   '手動引当数
					' === 20080725 === INSERT S - RISE)Izumi
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（時間）
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（日付）
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' 最終作業者コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' クライアントＩＤ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' タイムスタンプ（バッチ時間）
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' タイムスタンプ（バッチ日）
					' === 20080725 === INSERT E -
					
					'出荷指示数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_FRDSU = CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0)
					'引当済数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_ZUMISU = CF_Ora_GetDyn(Usr_Ody, "ZUMISU", 0) - .Bus_Inf.SUB_FRDSU
					'引当可能数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
					'引当数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_INP_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
					'引当数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_MOTO_HIKSU = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
					'前回入力引当済数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SUB_HIKSU_BEF = CF_Ora_GetDyn(Usr_Ody, "INP_HIKSU", 0) - .Bus_Inf.SUB_FRDSU
					'手動引当数
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, MNSU, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If CF_Ora_GetDyn(Usr_Ody, "MNSU", 0) - .Bus_Inf.SUB_FRDSU >= 0 Then
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Bus_Inf.SUB_MNSU = CF_Ora_GetDyn(Usr_Ody, "MNSU", 0) - .Bus_Inf.SUB_FRDSU
					Else
						.Bus_Inf.SUB_MNSU = 0
					End If
					' === 20080720 === UPDATE E -
					
					'ヘッダ情報に明細の合計を退避
					HIKET54A_DSP_DATA_Inf.HIKSUKEI = HIKET54A_DSP_DATA_Inf.HIKSUKEI + CDec(.Bus_Inf.SUB_INP_HIKSU)
					HIKET54A_DSP_DATA_Inf.MNSU = HIKET54A_DSP_DATA_Inf.MNSU + CDec(.Bus_Inf.SUB_MNSU)
					
					'(7.)
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					Wk_Index = CShort(FR_SSSSUB01.BD_SOUNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_LOTNO(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_LOTNO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_NYUYTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_NYUYTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_RELZAISU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_RELZAISU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_ZUMISU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_ZUMISU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_HIKSU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_MNSU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_MNSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					Wk_Index = CShort(FR_SSSSUB01.BD_INP_HIKSU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB_INP_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DEF)
					
				End With
				
				'ボディ部を入力済みに設定
				pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
				'次レコード
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			
			'行情報の配列は、最低、画面表示明細数分必要
			'（満たない場合、CF_Body_Dsp にてエラーが発生する）
			'なので、ここで配列の Redim を行う　　※いずれ共通化？？
			If intCnt < pm_All.Dsp_Base.Dsp_Body_Cnt Then
				'行追加
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
				For intIdx = intCnt + 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
					'行項目情報コピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Bus_Inf.SUB_IsDataRow = False
				Next intIdx
			End If
			
			With pm_HIKET54A_DSP_DATA
				'引当済数
				.ZUMISU = HIKET54A_DSP_DATA_Inf.HIKSUKEI
			End With
			
		End If
		
		' === 20080725 === INSERT S - RISE)Izumi
		Dim intLoop As Short
		Dim intIndex As Short
		Dim strKEY_HINCD As String
		Dim strKEY_INPYTDT As String
		Dim strKEY_LOTNO As String
		Dim strKEY_SOUCD As String
		Dim strKEY_TRANO As String
		Dim strKEY_MITNOV As String
		Dim strKEY_LINNO As String
		
		intIndex = 0
		
		' ダミー作成
		ReDim Preserve TYPE_DTLTRA_EXEC_BEF(intIndex)
		
		For intLoop = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'初期化
			mv_strKEY_TRAKB = ""
			mv_strKEY_TRANO = ""
			mv_strKEY_MITNOV = ""
			mv_strKEY_LINNO = ""
			mv_strKEY_PUDLNO = ""
			mv_strKEY_TRADT = ""
			mv_strKEY_HINCD = ""
			mv_strKEY_INPYTDT = ""
			mv_strKEY_LOTNO = ""
			mv_strKEY_SOUCD = ""
			
			With pm_All.Dsp_Body_Inf.Row_Inf(intLoop)
				'倉庫別在庫の場合
				If .Bus_Inf.SUB_KB = "1" Then
					'トラン種別
					mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
					'トラン番号(製番)
					mv_strKEY_TRANO = HIKET54_Interface.SBNNO
					'版数
					mv_strKEY_MITNOV = "  "
					'行番号
					mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
					'入出庫番号
					mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
					'トラン日付
					mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
					'製品コード
					mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
					'入荷予定日
					mv_strKEY_INPYTDT = "        "
					'ロット番号
					mv_strKEY_LOTNO = "                    "
					'倉庫コード
					mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
					'伝票管理№
					mv_strKEY_DATNO = HIKET54_Interface.DATNO
				Else
					'トラン種別
					mv_strKEY_TRAKB = CStr(HIKET54_Interface.Mode)
					'トラン番号(製番)
					mv_strKEY_TRANO = HIKET54_Interface.SBNNO
					'版数
					mv_strKEY_MITNOV = "  "
					'行番号
					mv_strKEY_LINNO = HIKET54_Interface.SPRRENNO
					'入出庫番号
					mv_strKEY_PUDLNO = HIKET54_Interface.PUDLNO
					'トラン日付
					mv_strKEY_TRADT = HIKET54_Interface.ODNYTDT
					'製品コード
					mv_strKEY_HINCD = .Bus_Inf.SUB_HINCD
					'入荷予定日
					mv_strKEY_INPYTDT = .Bus_Inf.SUB_NYUYTDT
					'ロット番号
					mv_strKEY_LOTNO = .Bus_Inf.SUB_LOTNO
					'倉庫コード
					mv_strKEY_SOUCD = .Bus_Inf.SUB_SOUCD
					'伝票管理№
					mv_strKEY_DATNO = HIKET54_Interface.DATNO
				End If
				
				'引当内訳ファイル取得SQL
				strSQL = F_GET_DTLTRA_SQL2
				'DBアクセス
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
				
				'                intIndex = 0
				'
				'                ' ダミー作成
				'                ReDim Preserve TYPE_DTLTRA_EXEC_BEF(intIndex)
				'
				Do Until CF_Ora_EOF(Usr_Ody)
					intIndex = intIndex + 1
					
					ReDim Preserve TYPE_DTLTRA_EXEC_BEF(intIndex)
					
					With TYPE_DTLTRA_EXEC_BEF(intIndex)
						.HINCD = mv_strKEY_HINCD ' 製品コード
						.INPYTDT = mv_strKEY_INPYTDT ' 入荷予定日
						.LOTNO = mv_strKEY_LOTNO ' ロット番号
						.SOUCD = mv_strKEY_SOUCD ' 倉庫コード
						.TRANO = mv_strKEY_TRANO ' トラン番号
						.MITNOV = mv_strKEY_MITNOV ' 版数
						.LINNO = mv_strKEY_LINNO ' 行番号
						.DATNO = mv_strKEY_DATNO ' 伝票管理№
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") ' トラン種別
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") ' トラン番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") ' 版数
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "") ' 行番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") ' 入出庫番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") ' トラン日付
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_HIKNO = CF_Ora_GetDyn(Usr_Ody, "HIKNO", "") ' 引当番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") ' 製品コード
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（バッチ時間）
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（バッチ日）
					End With
					
					'次レコード
					Call CF_Ora_MoveNext(Usr_Ody)
				Loop 
			End With
		Next intLoop
		' === 20080725 === INSERT E -
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SET_BD_DATA
	'   概要：  ボディ部データ編集
	'   引数：　pm_All                :全構造体
	'   戻値：　処理ステータス
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_HIKET54A_DSP_DATA As HIKET54A_DSP_DATA, ByRef pm_All As Cls_All, ByRef pm_intCnt As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		F_SET_BD_DATA = 9
		
		'■ヘッダ部
		With pm_HIKET54A_DSP_DATA
			'【伝票情報】
			Trg_Index = CShort(FR_SSSSUB01.HD_DEN_SBT.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.DENSBT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【製番】
			Trg_Index = CShort(FR_SSSSUB01.HD_SBNNO.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【製品コード】
			Trg_Index = CShort(FR_SSSSUB01.HD_HINCD.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【型式】
			Trg_Index = CShort(FR_SSSSUB01.HD_HINNMA.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【品名】
			Trg_Index = CShort(FR_SSSSUB01.HD_HINNMB.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【数量】
			Trg_Index = CShort(FR_SSSSUB01.HD_UODSU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.UODSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【手動済数】
			Trg_Index = CShort(FR_SSSSUB01.HD_MNSU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.MNSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【引当済数】
			Trg_Index = CShort(FR_SSSSUB01.HD_ZUMISU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.ZUMISU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			
		End With
		
		'■ボディ部
		'スクロールバー値設定
		'最大値
		Call CF_Set_VScrl_Max(F_Get_VScrl_Max(pm_intCnt, pm_All.Dsp_Base.Dsp_Body_Cnt), pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		
		'最上行設定（検索直後なので１）
		pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		
		'明細編集メイン
		Call CF_Body_Dsp(pm_All)
		
		'明細カラー付け
		Call CF_Set_BD_Color(pm_All)
		
		'■フッタ部
		
		F_SET_BD_DATA = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_INP_SQL
	'   概要：  入荷予定情報データ取得ＳＱＬ生成
	'   引数：　pm_strCode1           :ｺｰﾄﾞ1
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_INP_SQL() As String
		
		Dim strSQL As String
		
		'サーバシステム日付取得
		Call CF_Get_SysDt()
		
		'検索ＳＱＬ発行
		strSQL = ""
		
		'//////////////////////////////////////////////////////////////////////
		'倉庫別在庫マスタ情報(製品倉庫)
		'//////////////////////////////////////////////////////////////////////
		strSQL = " ( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     0               As SORTNO" 'ソート用
		strSQL = strSQL & "    ,1               As KB" 'データ区分
		strSQL = strSQL & "    ,HIN.SOUCD       As SOUCD" '倉庫コード
		strSQL = strSQL & "    ,HIN.HINCD       As HINCD" '製品コード
		strSQL = strSQL & "    ,HIN.SISNKB      As SISNKB" '資産元区分
		strSQL = strSQL & "    ,HIN.SOUTRICD    As SOUTRICD" '取引先コード
		strSQL = strSQL & "    ,HIN.SOUKOKB     As SOUKOKB" '倉庫区分
		strSQL = strSQL & "    ,SOU.SOUNM       As SOUNM" '倉庫名
		strSQL = strSQL & "    ,NULL            As LOTNO" 'ロット番号
		strSQL = strSQL & "    ,NULL            As INPYTDT" '入庫予定日
		strSQL = strSQL & "    ,HIN.RELZAISU    As RELZAISU" '現在在庫数
		strSQL = strSQL & "    ,HIN.HIKSU       As ZUMISU" '引当済数
		strSQL = strSQL & "    ,HIN.RELZAISU - HIN.HIKSU As HIKSU" '引当可能数
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '引当数
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '引当数
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "    ,HIN.OPEID       As OPEID" '最終作業者コード
		strSQL = strSQL & "    ,HIN.CLTID       As CLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,HIN.WRTTM       As WRTTM" 'タイムスタンプ（時間）
		strSQL = strSQL & "    ,HIN.WRTDT       As WRTDT" 'タイムスタンプ（日付）
		strSQL = strSQL & "    ,HIN.UOPEID      As UOPEID" '最終作業者コード
		strSQL = strSQL & "    ,HIN.UCLTID      As UCLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,HIN.UWRTTM      As UWRTTM" 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "    ,HIN.UWRTDT      As UWRTDT" 'タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & "    ,FDN.FRDSU       As FRDSU" '出荷指示数
		' === 20080715 === INSERT E -
		strSQL = strSQL & " From"
		strSQL = strSQL & "     HINMTB HIN"
		strSQL = strSQL & "    ,SOUMTA SOU"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		'2008/05/19 FKS)HONDA ADD START ####
		strSQL = strSQL & "    ,MEIMTA "
		'2008/05/19 FKS)HONDA ADD END ####
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			' === 20090104 === UPDATE S - ACE)Nagasawa 出荷指示数の取得計算式変更
			'D        strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "              ,SUM(FRDSU) AS FRDSU"
			' === 20090104 === UPDATE E -
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  HINCD    = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  SBNNO    = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		Else
			'製番出庫の場合
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			' === 20090104 === UPDATE S - ACE)Nagasawa 出荷指示数の取得計算式変更
			'D        strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "              ,SUM(FRDSU) AS FRDSU"
			' === 20090104 === UPDATE E -
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  WRKKB    = '" & CF_Ora_String(gc_strWRKKB_SBN, 1) & "' "
			strSQL = strSQL & "          AND  SBNNO    = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 10) & "' "
			strSQL = strSQL & "          AND  HINCD    = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			If Trim(HIKET54_Interface.TOKCD) <> "" Then
				strSQL = strSQL & "      AND  TOKCD    = '" & CF_Ora_String(HIKET54_Interface.TOKCD, 10) & "' "
			Else
				strSQL = strSQL & "      AND  TOKCD    = '" & CF_Ora_String(HIKET54_Interface.OUTBMCD, 10) & "' "
			End If
			If Trim(HIKET54_Interface.TOKCD) <> "" Then
				strSQL = strSQL & "      AND  NHSCD    = '" & CF_Ora_String(HIKET54_Interface.NHSCD, 10) & "' "
			Else
				strSQL = strSQL & "      AND  NHSCD    = '" & CF_Ora_String(HIKET54_Interface.OUTTANCD, 10) & "' "
			End If
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		End If
		' === 20080720 === INSERT E -
		' === 20071230 === UPDATE S - ACE)Yano
		'    If HIKET54_Interface.Mode = "3" Then
		'        '支給品の場合
		'        strSQL = strSQL & "    ,( SELECT  HINCD"
		'        strSQL = strSQL & "              ,SUBSTR(TNACM, 1, 3) SOUCD"
		'        strSQL = strSQL & "         FROM  HINMTA"
		'        strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		'        strSQL = strSQL & "     ) HIA"
		'    Else
		'        '製番出庫の場合
		'        strSQL = strSQL & "    ,( SELECT  HINCD"
		'        strSQL = strSQL & "              ,OUTSOUCD"
		'        strSQL = strSQL & "              ,SBNNO"
		'        strSQL = strSQL & "              ,PUDLNO"
		'        strSQL = strSQL & "         FROM  SBNTRA"
		'        strSQL = strSQL & "        WHERE  DATNO = '" & CF_Ora_String(HIKET54_Interface.DATNO, 10) & "' "
		'        strSQL = strSQL & "     ) SBN"
		'    End If
		' === 20071230 === UPDATE E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     HIN.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And HIN.HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		' === 20071230 === INSERT S - ACE)Yano
		' === 20080326 === INSERT S - ACE)Nagasawa 倉庫区分の対象を"05""14"も対象とする
		'    strSQL = strSQL & " And HIN.SOUKOKB = '01' "
		'2008/05/19 FKS)HONDA UPD START ####
		'名称マスタより製品引当可能倉庫を指定するように変更。
		'    strSQL = strSQL & " And HIN.SOUKOKB IN ('01', '05', '14') "
		strSQL = strSQL & " And HIN.SOUCD = MEIMTA.MEICDA "
		strSQL = strSQL & " And MEIMTA.KEYCD = '097' "
		'2008/05/20 FKS)HONDA ADD START ####
		strSQL = strSQL & " And MEIMTA.DATKB = '1' "
		'2008/05/20 FKS)HONDA ADD END ####
		'2008/05/19 FKS)HONDA UPD END ####
		' === 20080326 === INSERT E -
		' === 20071230 === INSERT E -
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			' === 20071230 === UPDATE S - ACE)Yano
			'        strSQL = strSQL & " And HIN.SOUCD = HIA.SOUCD"
			' === 20071230 === UPDATE E -
			strSQL = strSQL & " And HIN.SOUCD = SOU.SOUCD(+)"
			strSQL = strSQL & " And HIN.SOUCD = DTL.SOUCD(+)"
		Else
			'製番出庫の場合
			' === 20071230 === UPDATE S - ACE)Yano
			'        strSQL = strSQL & " And HIN.SOUCD = SBN.OUTSOUCD"
			' === 20071230 === UPDATE E -
			strSQL = strSQL & " And HIN.SOUCD = SOU.SOUCD(+)"
			strSQL = strSQL & " And HIN.SOUCD = DTL.SOUCD(+)"
		End If
		strSQL = strSQL & " And HIN.HINCD = DTL.HINCD(+)"
		strSQL = strSQL & " And DTL.INPYTDT(+) = '        ' " 'SPACEは倉庫別在庫
		' === 20080715 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & " And HIN.SOUCD    = FDN.SOUCD(+)"
		' === 20080715 === INSERT E -
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '3' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '  ' "
			strSQL = strSQL & " And DTL.LINNO(+)  = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		Else
			'製番出庫の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '4' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'倉庫別在庫マスタ情報(取引先取置倉庫分)
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & "UNION ALL( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     1               As SORTNO" 'ソート用
		strSQL = strSQL & "    ,1               As KB" 'データ区分
		strSQL = strSQL & "    ,HIN.SOUCD       As SOUCD" '倉庫コード
		strSQL = strSQL & "    ,HIN.HINCD       As HINCD" '製品コード
		strSQL = strSQL & "    ,HIN.SISNKB      As SISNKB" '資産元区分
		strSQL = strSQL & "    ,HIN.SOUTRICD    As SOUTRICD" '取引先コード
		strSQL = strSQL & "    ,HIN.SOUKOKB     As SOUKOKB" '倉庫区分
		strSQL = strSQL & "    ,'専用倉庫'      As SOUNM" '倉庫名
		strSQL = strSQL & "    ,NULL            As LOTNO" 'ロット番号
		strSQL = strSQL & "    ,NULL            As INPYTDT" '入庫予定日
		strSQL = strSQL & "    ,HIN.RELZAISU    As RELZAISU" '現在在庫数
		strSQL = strSQL & "    ,HIN.HIKSU       As ZUMISU" '引当済数
		strSQL = strSQL & "    ,HIN.RELZAISU - HIN.HIKSU As HIKSU" '引当可能数
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '引当数
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '引当数
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "    ,HIN.OPEID       As OPEID" '最終作業者コード
		strSQL = strSQL & "    ,HIN.CLTID       As CLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,HIN.WRTTM       As WRTTM" 'タイムスタンプ（時間）
		strSQL = strSQL & "    ,HIN.WRTDT       As WRTDT" 'タイムスタンプ（日付）
		strSQL = strSQL & "    ,HIN.UOPEID      As UOPEID" '最終作業者コード
		strSQL = strSQL & "    ,HIN.UCLTID      As UCLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,HIN.UWRTTM      As UWRTTM" 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "    ,HIN.UWRTDT      As UWRTDT" 'タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & "    ,FDN.FRDSU       As FRDSU" '出荷指示数
		' === 20080715 === INSERT E -
		strSQL = strSQL & " From"
		strSQL = strSQL & "     HINMTB HIN"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			' === 20090104 === UPDATE S - ACE)Nagasawa 出荷指示数の取得計算式変更
			'D        strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "              ,SUM(FRDSU) AS FRDSU"
			' === 20090104 === UPDATE E -
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  HINCD    = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  SBNNO    = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		Else
			'製番出庫の場合
			strSQL = strSQL & "    ,( SELECT  OUTSOUCD AS SOUCD"
			' === 20090104 === UPDATE S - ACE)Nagasawa 出荷指示数の取得計算式変更
			'D        strSQL = strSQL & "              ,SUM(FRDSU - OTPSU) AS FRDSU"
			strSQL = strSQL & "              ,SUM(FRDSU) AS FRDSU"
			' === 20090104 === UPDATE E -
			strSQL = strSQL & "         FROM  FDNTRA"
			strSQL = strSQL & "        WHERE  WRKKB    = '" & CF_Ora_String(gc_strWRKKB_SBN, 1) & "' "
			strSQL = strSQL & "          AND  SBNNO    = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 10) & "' "
			strSQL = strSQL & "          AND  HINCD    = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "          AND  PUDLNO   = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			If Trim(HIKET54_Interface.TOKCD) <> "" Then
				strSQL = strSQL & "      AND  TOKCD    = '" & CF_Ora_String(HIKET54_Interface.TOKCD, 10) & "' "
			Else
				strSQL = strSQL & "      AND  TOKCD    = '" & CF_Ora_String(HIKET54_Interface.OUTBMCD, 10) & "' "
			End If
			If Trim(HIKET54_Interface.TOKCD) <> "" Then
				strSQL = strSQL & "      AND  NHSCD    = '" & CF_Ora_String(HIKET54_Interface.NHSCD, 10) & "' "
			Else
				strSQL = strSQL & "      AND  NHSCD    = '" & CF_Ora_String(HIKET54_Interface.OUTTANCD, 10) & "' "
			End If
			strSQL = strSQL & "          AND  DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "        GROUP BY"
			strSQL = strSQL & "               OUTSOUCD"
			strSQL = strSQL & "     ) FDN"
		End If
		' === 20080720 === INSERT E -
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     HIN.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And HIN.HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & " And HIN.SISNKB = '" & CF_Ora_String(gc_strSISNKB_JI, 1) & "' "
		strSQL = strSQL & " And HIN.SOUTRICD = '" & CF_Ora_String(HIKET54_Interface.TOKCD, 10) & "' "
		strSQL = strSQL & " And HIN.SOUKOKB = '" & CF_Ora_String(gc_strSOUKOKB_TORIOKI, 2) & "' "
		strSQL = strSQL & " And HIN.SOUCD = DTL.SOUCD(+)"
		strSQL = strSQL & " And HIN.HINCD = DTL.HINCD(+)"
		strSQL = strSQL & " And DTL.INPYTDT(+) = '        ' " 'SPACEは倉庫別在庫
		' === 20080715 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & " And HIN.SOUCD    = FDN.SOUCD(+)"
		' === 20080715 === INSERT E -
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '3' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '  ' "
			strSQL = strSQL & " And DTL.LINNO(+)  = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		Else
			'製番出庫の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '4' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'入荷予定情報
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & "UNION ALL( "
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     2               As SORTNO" 'ソート用
		strSQL = strSQL & "    ,2               As KB" 'データ区分
		strSQL = strSQL & "    ,INP.INPSOUCD    As SOUCD" '倉庫コード
		strSQL = strSQL & "    ,INP.HINCD       As HINCD" '製品コード
		strSQL = strSQL & "    ,SOU.SISNKB      As SISNKB" '資産元区分
		strSQL = strSQL & "    ,SOU.SOUTRICD    As SOUTRICD" '取引先コード
		strSQL = strSQL & "    ,SOU.SOUKOKB     As SOUKOKB" '倉庫区分
		strSQL = strSQL & "    ,SOU.SOUNM       As SOUNM" '倉庫名
		strSQL = strSQL & "    ,INP.LOTNO       As LOTNO" 'ロット番号
		strSQL = strSQL & "    ,INP.INPYTDT     As INPYTDT" '入庫予定日
		strSQL = strSQL & "    ,INP.INPSU - INP.INPSMSU As RELZAISU" '現在在庫数
		strSQL = strSQL & "    ,INP.INHIKSU     As ZUMISU" '引当済数
		strSQL = strSQL & "    ,INP.INPSU - INP.INHIKSU - INP.INPSMSU As HIKSU" '引当可能数
		strSQL = strSQL & "    ,DTL.HIKSU       As INP_HIKSU" '引当数
		strSQL = strSQL & "    ,DTL.MNSU        As MNSU" '手動引当数
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "    ,INP.OPEID       As OPEID" '最終作業者コード
		strSQL = strSQL & "    ,INP.CLTID       As CLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,INP.WRTTM       As WRTTM" 'タイムスタンプ（時間）
		strSQL = strSQL & "    ,INP.WRTDT       As WRTDT" 'タイムスタンプ（日付）
		strSQL = strSQL & "    ,INP.UOPEID      As UOPEID" '最終作業者コード
		strSQL = strSQL & "    ,INP.UCLTID      As UCLTID" 'クライアントＩＤ
		strSQL = strSQL & "    ,INP.UWRTTM      As UWRTTM" 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "    ,INP.UWRTDT      As UWRTDT" 'タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
		' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & "    ,0           As FRDSU" '出荷指示数
		' === 20080720 === INSERT E -
		strSQL = strSQL & " From"
		strSQL = strSQL & "     INPTRA INP"
		strSQL = strSQL & "    ,SOUMTA SOU"
		strSQL = strSQL & "    ,( SELECT  TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,LOTNO"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "              ,SUM(HIKSU) As HIKSU"
		strSQL = strSQL & "              ,SUM(DECODE(ATMNKB , 'M', HIKSU, 0)) As MNSU"
		strSQL = strSQL & "         FROM  DTLTRA"
		strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & "        GROUP BY"
		strSQL = strSQL & "               TRAKB"
		strSQL = strSQL & "              ,TRANO"
		strSQL = strSQL & "              ,MITNOV"
		strSQL = strSQL & "              ,LINNO"
		strSQL = strSQL & "              ,PUDLNO"
		' === 20160623 === INSERT S - FWEST)Koroyasu
		strSQL = strSQL & "              ,TRADT"
		' === 20160623 === INSERT E -
		strSQL = strSQL & "              ,HINCD"
		strSQL = strSQL & "              ,INPYTDT"
		strSQL = strSQL & "              ,LOTNO"
		strSQL = strSQL & "              ,SOUCD"
		strSQL = strSQL & "     ) DTL"
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & "    ,( SELECT  HINCD"
			strSQL = strSQL & "              ,SUBSTR(TNACM, 1, 3) SOUCD"
			strSQL = strSQL & "         FROM  HINMTA"
			strSQL = strSQL & "        WHERE  HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
			strSQL = strSQL & "     ) HIA"
		Else
			'製番出庫の場合
			strSQL = strSQL & "    ,( SELECT  HINCD"
			strSQL = strSQL & "              ,OUTSOUCD"
			strSQL = strSQL & "              ,SBNNO"
			strSQL = strSQL & "              ,PUDLNO"
			strSQL = strSQL & "         FROM  SBNTRA"
			strSQL = strSQL & "        WHERE  DATNO = '" & CF_Ora_String(HIKET54_Interface.DATNO, 10) & "' "
			strSQL = strSQL & "     ) SBN"
		End If
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     INP.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & " And INP.HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & " And INP.PLANKB = ' '"
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & " And INP.INPSOUCD = HIA.SOUCD"
			strSQL = strSQL & " And INP.INPSOUCD = SOU.SOUCD(+)"
			strSQL = strSQL & " And INP.INPSOUCD = DTL.SOUCD(+)"
		Else
			'製番出庫の場合
			strSQL = strSQL & " And INP.INPSOUCD = SBN.OUTSOUCD"
			strSQL = strSQL & " And INP.INPSOUCD = SOU.SOUCD(+)"
			strSQL = strSQL & " And INP.INPSOUCD = DTL.SOUCD(+)"
		End If
		strSQL = strSQL & " And INP.HINCD = DTL.HINCD(+)"
		strSQL = strSQL & " And INP.INPYTDT = DTL.INPYTDT(+)"
		strSQL = strSQL & " And INP.LOTNO = DTL.LOTNO(+)"
		strSQL = strSQL & " And INP.INPSU > INP.INPSMSU "
		If HIKET54_Interface.Mode = CDbl("3") Then
			'支給品の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '3' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.MITNOV(+) = '  ' "
			strSQL = strSQL & " And DTL.LINNO(+)  = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		Else
			'製番出庫の場合
			strSQL = strSQL & " And DTL.TRAKB(+)  = '4' "
			strSQL = strSQL & " And DTL.TRANO(+)  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
			strSQL = strSQL & " And DTL.PUDLNO(+) = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
			' === 20160623 === INSERT S - FWEST)Koroyasu
			strSQL = strSQL & " And DTL.TRADT(+)  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
			' === 20160623 === INSERT E -
		End If
		strSQL = strSQL & " ) "
		
		'//////////////////////////////////////////////////////////////////////
		'ORDER BY句
		'//////////////////////////////////////////////////////////////////////
		strSQL = strSQL & " Order By"
		strSQL = strSQL & "     SORTNO"
		strSQL = strSQL & "    ,INPYTDT"
		strSQL = strSQL & "    ,SOUCD"
		strSQL = strSQL & "    ,LOTNO"
		
		F_GET_INP_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_SKY_HD_SQL
	'   概要：  支給品情報ヘッダデータ取得ＳＱＬ生成
	'   引数：　pm_strCode1           :分割希望納期
	'       ：　pm_strCode2           :製品コード
	'       ：　pm_strCode3           :製番
	'       ：　pm_strCode4           :分割連番
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_SKY_HD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_strCode3 As String, ByRef pm_strCode4 As String) As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     SUM(OUTYOTSU) "
		strSQL = strSQL & "   - SUM(FRDSU) "
		strSQL = strSQL & "   - SUM(OUTZMISU) UODSU" '数量
		strSQL = strSQL & "   , SUM(ATZHIKSU) "
		strSQL = strSQL & "   + SUM(ATNHIKSU) "
		strSQL = strSQL & "   + SUM(MNZHIKSU) "
		strSQL = strSQL & "   + SUM(MNNHIKSU) ZUMISU" '引当済数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     SKYTBL"
		strSQL = strSQL & " Where"
		strSQL = strSQL & "     DATKB    = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & " And SPRNOKDT = '" & pm_strCode1 & "' "
		strSQL = strSQL & " And HINCD    = '" & pm_strCode2 & "' "
		strSQL = strSQL & " And SBNNO    = '" & pm_strCode3 & "' "
		strSQL = strSQL & " And PLANKB   = ' ' "
		strSQL = strSQL & " And SPRRENNO = '" & pm_strCode4 & "' "
		
		F_GET_SKY_HD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_SBN_HD_SQL
	'   概要：  製番出庫情報ヘッダデータ取得ＳＱＬ生成
	'   引数：　pm_strCode1           :伝票管理№
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_SBN_HD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String) As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     SUM(FRDYTSU) "
		strSQL = strSQL & "   - SUM(FRDSU) "
		strSQL = strSQL & "   - SUM(OUTSMSU) UODSU" '数量
		strSQL = strSQL & "   , SUM(HIKSMSU) ZUMISU" '引当済数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     SBNTRA "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & " And DATNO  = '" & pm_strCode1 & "' "
		
		F_GET_SBN_HD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_VScrl_Max
	'   概要：  スクロールバーのmaxプロパティへの設定値取得
	'   引数：　pm_Dsp_Data_Cnt       :取得データ数（UBound(Row_Inf)）
	'           pm_Dsp_Body_Cnt       :最大表示明細数（Dsp_Base設定値）
	'   戻値：　設定値
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_VScrl_Max(ByRef pm_Dsp_Data_Cnt As Short, ByRef pm_Dsp_Body_Cnt As Short) As Short
		
		Dim Ret_Value As Short
		Dim Wk_Value As Short
		
		'とりあえず１を設定
		Ret_Value = 1
		'取得件数が最大表示件数を上回る場合、オーバー分を加算
		Wk_Value = pm_Dsp_Data_Cnt - pm_Dsp_Body_Cnt
		If Wk_Value > 0 Then
			Ret_Value = Ret_Value + Wk_Value
		End If
		
		F_Get_VScrl_Max = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Hardcopy_SSSMAIN
	'   概要：  ハードコピー画面呼出し後処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		FR_SSSSUB01.Cursor = System.Windows.Forms.Cursors.WaitCursor
		'UPGRADE_ISSUE: Form メソッド FR_SSSSUB01.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		FR_SSSSUB01.PrintForm()
		FR_SSSSUB01.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_BD_Color
	'   概要：  前景/背景色設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_BD_Color(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Cur_Top_Index As Short
		
		'ボディ部内で処理
		Bd_Index = 0
		Bd_Index_Bk = 0
		
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
				
				'pm_All.Dsp_Body_Infの行ＮＯを取得
				Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				If Bd_Index_Bk <> Bd_Index Then
					'明細行ブレイク
					Bd_Col_Index = 1
					Bd_Index_Bk = Bd_Index
				Else
					Bd_Col_Index = Bd_Col_Index + 1
				End If
				
				'入庫予定は青色
				If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> FR_SSSSUB01.BD_SOUNM(1).Name And pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> FR_SSSSUB01.BD_INP_HIKSU(1).Name Then
					If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SUB_NYUYTDT) <> "" Then
						pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.ForeColor = AE_CONST.COLOR_NAVY
					End If
				End If
			End If
			
		Next 
		
	End Function
	
	' === 20080725 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_EX_SQL
	'   概要：  排他情報データ取得ＳＱＬ生成
	'   引数：  pin_intRow        :対象行番号
	'           pin_intKbn        :対象テーブル区分
	'           pm_All            :検索対象保持データ
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_EX_SQL(ByVal pin_intRow As Short, ByVal pin_intKbn As Short, ByRef pm_All As Cls_All) As String
		
		Dim strSQL As String
		Dim strSelect As String
		Dim strTable As String
		Dim strWhere As String
		
		On Error GoTo ErrRtn
		
		With pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf
			
			'取得対象テーブルと検索句を設定する
			Select Case pin_intKbn
				
				Case ex_tblKbn.HINMTB '倉庫別在庫マスタ
					'対象テーブル
					strTable = "HINMTB"
					
					'SELECTカラム
					strSelect = strSelect & "           CLTID" 'クライアントID
					strSelect = strSelect & "         , OPEID" '最終作業者コード
					strSelect = strSelect & "         , WRTTM" 'タイムスタンプ（時間）
					strSelect = strSelect & "         , WRTDT" 'タイムスタンプ（日付）
					strSelect = strSelect & "         , UCLTID" 'クライアントID
					strSelect = strSelect & "         , UOPEID" '最終作業者コード
					strSelect = strSelect & "         , UWRTTM" 'タイムスタンプ（バッチ時間）
					strSelect = strSelect & "         , UWRTDT" 'タイムスタンプ（バッチ日）
					
					'検索句
					strWhere = strWhere & "     DATKB =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
					strWhere = strWhere & " AND SOUCD =  '" & CF_Ora_String(.SUB_SOUCD, 3) & "'"
					strWhere = strWhere & " AND HINCD =  '" & CF_Ora_String(.SUB_HINCD, 10) & "'"
					
				Case ex_tblKbn.INPTRA '入荷予定ファイル
					'対象テーブル
					strTable = "INPTRA"
					
					'SELECTカラム
					strSelect = strSelect & "           CLTID" 'クライアントID
					strSelect = strSelect & "         , OPEID" '最終作業者コード
					strSelect = strSelect & "         , WRTTM" 'タイムスタンプ（時間）
					strSelect = strSelect & "         , WRTDT" 'タイムスタンプ（日付）
					strSelect = strSelect & "         , UCLTID" 'クライアントID
					strSelect = strSelect & "         , UOPEID" '最終作業者コード
					strSelect = strSelect & "         , UWRTTM" 'タイムスタンプ（バッチ時間）
					strSelect = strSelect & "         , UWRTDT" 'タイムスタンプ（バッチ日）
					
					'検索句
					strWhere = strWhere & "     DATKB   =  '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
					strWhere = strWhere & " AND HINCD   =  '" & CF_Ora_String(.SUB_HINCD, 10) & "'"
					strWhere = strWhere & " AND INPYTDT =  '" & CF_Ora_String(.SUB_NYUYTDT, 8) & "'"
					strWhere = strWhere & " AND LOTNO   =  '" & CF_Ora_String(.SUB_LOTNO, 12) & "'"
					
				Case ex_tblKbn.SKYTBL '支給品ファイル
					'対象テーブル
					strTable = "SKYTBL"
					
					'SELECTカラム
					strSelect = strSelect & "           CLTID" 'クライアントID
					strSelect = strSelect & "         , OPEID" '最終作業者コード
					strSelect = strSelect & "         , WRTTM" 'タイムスタンプ（時間）
					strSelect = strSelect & "         , WRTDT" 'タイムスタンプ（日付）
					
					'検索句
					strWhere = strWhere & "     DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
					strWhere = strWhere & " AND SPRNOKDT = '" & CF_Ora_String(mv_strKEY_TRADT, 8) & "'"
					strWhere = strWhere & " AND HINCD    = '" & CF_Ora_String(mv_strKEY_HINCD, 10) & "'"
					strWhere = strWhere & " AND SBNNO    = '" & CF_Ora_String(mv_strKEY_TRANO, 20) & "'"
					strWhere = strWhere & " AND PLANKB   = ' '"
					strWhere = strWhere & " AND SPRRENNO = '" & CF_Ora_String(mv_strKEY_LINNO, 3) & "'"
					
				Case ex_tblKbn.SBNTRA '製番出庫ファイル
					'対象テーブル
					strTable = "SBNTRA"
					
					'SELECTカラム
					'SELECTカラム
					strSelect = strSelect & "           CLTID" 'クライアントID
					strSelect = strSelect & "         , OPEID" '最終作業者コード
					strSelect = strSelect & "         , WRTTM" 'タイムスタンプ（時間）
					strSelect = strSelect & "         , WRTDT" 'タイムスタンプ（日付）
					strSelect = strSelect & "         , UCLTID" 'クライアントID
					strSelect = strSelect & "         , UOPEID" '最終作業者コード
					strSelect = strSelect & "         , UWRTTM" 'タイムスタンプ（バッチ時間）
					strSelect = strSelect & "         , UWRTDT" 'タイムスタンプ（バッチ日）
					
					'検索句
					strWhere = strWhere & "     DATNO   = '" & CF_Ora_String(mv_strKEY_DATNO, 10) & "'"
					strWhere = strWhere & " AND DATKB   = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
					
				Case ex_tblKbn.DTLTRA '引当内訳ファイル
					'対象テーブル
					strTable = "DTLTRA"
					
					'SELECTカラム
					strSelect = strSelect & "           CLTID" 'クライアントID
					strSelect = strSelect & "         , OPEID" '最終作業者コード
					strSelect = strSelect & "         , WRTTM" 'タイムスタンプ（時間）
					strSelect = strSelect & "         , WRTDT" 'タイムスタンプ（日付）
					
					'検索句
					strWhere = strWhere & "     TRAKB   =  '" & CF_Ora_String(mv_strDTLTRA_TRAKB, 1) & "'"
					strWhere = strWhere & " AND TRANO   =  '" & CF_Ora_String(mv_strDTLTRA_TRANO, 20) & "'"
					strWhere = strWhere & " AND MITNOV  =  '" & CF_Ora_String(mv_strDTLTRA_MITNOV, 2) & "'"
					strWhere = strWhere & " AND LINNO   =  '" & CF_Ora_String(mv_strDTLTRA_LINNO, 3) & "'"
					strWhere = strWhere & " AND PUDLNO  =  '" & CF_Ora_String(mv_strDTLTRA_PUDLNO, 10) & "'"
					strWhere = strWhere & " AND TRADT   =  '" & CF_Ora_String(mv_strDTLTRA_TRADT, 8) & "'"
					strWhere = strWhere & " AND HIKNO   =  '" & CF_Ora_String(mv_strDTLTRA_HIKNO, 5) & "'"
					strWhere = strWhere & " AND HINCD   =  '" & CF_Ora_String(mv_strDTLTRA_HINCD, 10) & "'"
					
			End Select
			
		End With
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " SELECT " & strSelect
		strSQL = strSQL & " FROM " & strTable
		strSQL = strSQL & " WHERE " & strWhere
		strSQL = strSQL & " FOR UPDATE"
		
ExitRtn: 
		F_GET_EX_SQL = strSQL
		Exit Function
		
ErrRtn: 
		strSQL = ""
		GoTo ExitRtn
		
	End Function
	' === 20080725 === INSERT E -
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
	
	' === 20080720 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_FRDSU_ATMN_SKY
	'   概要：  出荷指示数を自動分と手動分に分ける(支給品分)
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_FRDSU_ATMN_SKY(ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim curAtzHikSu_SKY As Decimal '自動在庫引当数（支給品）
		Dim curMnzHikSu_SKY As Decimal '手動在庫引当数（支給品）
		Dim curAtzHikSu_DTL As Decimal '自動在庫引当数（引当内訳）
		Dim curMnzHikSu_DTL As Decimal '手動在庫引当数（引当内訳）
		
		On Error GoTo F_GET_FRDSU_ATMN_SKY_err
		
		F_GET_FRDSU_ATMN_SKY = 9
		
		'初期化
		mv_curFRDSU_AT = 0 '自動引当分出荷指示数
		mv_curFRDSU_MN = 0 '手動引当分出荷指示数
		
		'現在の支給品ﾌｧｲﾙ検索SQL
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     ATZHIKSU" '自動在庫引当数
		strSQL = strSQL & "    ,MNZHIKSU" '手動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     SKYTBL"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "'"
		strSQL = strSQL & " AND SPRNOKDT = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "'"
		strSQL = strSQL & " AND HINCD    = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "'"
		strSQL = strSQL & " AND SBNNO    = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "'"
		strSQL = strSQL & " AND PLANKB   = ' '"
		strSQL = strSQL & " AND SPRRENNO = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu_SKY = 0
			curMnzHikSu_SKY = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtzHikSu_SKY = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnzHikSu_SKY = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（自動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As ATZHIKSU" '自動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(CStr(HIKET54_Interface.Mode), 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'A' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String("", 8) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curAtzHikSu_DTL = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curAtzHikSu_DTL = CF_Ora_GetDyn(Usr_Ody, "ATZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'内訳ﾌｧｲﾙ検索SQL（手動在庫引当数）
		strSQL = ""
		strSQL = strSQL & " Select"
		strSQL = strSQL & "     Sum(HIKSU)  As MNZHIKSU" '手動在庫引当数
		strSQL = strSQL & " From"
		strSQL = strSQL & "     DTLTRA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     TRAKB  = '" & CF_Ora_String(CStr(HIKET54_Interface.Mode), 1) & "' "
		strSQL = strSQL & " And TRANO  = '" & CF_Ora_String(HIKET54_Interface.SBNNO, 20) & "' "
		strSQL = strSQL & " And MITNOV = '  ' "
		strSQL = strSQL & " And LINNO  = '" & CF_Ora_String(HIKET54_Interface.SPRRENNO, 3) & "' "
		strSQL = strSQL & " And PUDLNO = '" & CF_Ora_String(HIKET54_Interface.PUDLNO, 10) & "' "
		strSQL = strSQL & " And TRADT  = '" & CF_Ora_String(HIKET54_Interface.ODNYTDT, 8) & "' "
		strSQL = strSQL & " And ATMNKB = 'M' "
		strSQL = strSQL & " And HINCD = '" & CF_Ora_String(HIKET54_Interface.HINCD, 10) & "' "
		strSQL = strSQL & " And INPYTDT = '" & CF_Ora_String("", 8) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If CF_Ora_EOF(Usr_Ody) = True Then
			curMnzHikSu_DTL = 0
		Else
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			curMnzHikSu_DTL = CF_Ora_GetDyn(Usr_Ody, "MNZHIKSU", 0)
		End If
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		' 自動引当分出荷指示数
		mv_curFRDSU_AT = curAtzHikSu_DTL - curAtzHikSu_SKY
		
		' 手動引当分出荷指示数
		mv_curFRDSU_MN = curMnzHikSu_DTL - curMnzHikSu_SKY
		
		F_GET_FRDSU_ATMN_SKY = 0
		
F_GET_FRDSU_ATMN_SKY_End: 
		Exit Function
		
F_GET_FRDSU_ATMN_SKY_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, pm_All, "F_GET_FRDSU_ATMN_SKY")
		GoTo F_GET_FRDSU_ATMN_SKY_End
		
	End Function
	' === 20080720 === INSERT E -
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module