Option Strict Off
Option Explicit On
'2019/09/27 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'2019/09/27 ADD END
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(82) As String
	
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	Public Structure HIKET54_DSP_DATA
		Dim SBNNO As String '製番
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '品名
	End Structure
	
	'画面編集情報退避用
	Public HIKET54_DSP_DATA_Inf As HIKET54_DSP_DATA
	Public HIKET54_DSP_DATA_Clr As HIKET54_DSP_DATA
	
	'商品マスタ情報
	Public Structure HIKET54_TYPE_HINMTA
		Dim DATKB As String '削除区分
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
	End Structure
	
	Public HIKET54_HINMTA_Inf As HIKET54_TYPE_HINMTA
	
	'選択行ｲﾝﾃﾞｯｸｽ退避用
	Public HIKET54_Bd_Sel_Index As Short
	'選択オプションボタン画像
	Public HIKET54_Bd_Sel_Img As Cls_Img_Inf
	
	Public gv_bolHIKET54_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	
	Public gv_bolKeyFlg As Boolean
	
	' === 20080729 === INSERT S - RISE)Izumi
	Public Structure HIKET51_UPDATE_FLAG
		Dim DATNO As String ' 伝票管理№
		Dim SPRRENNO As String ' 行番号
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（バッチ時間）
		Dim WRTDT As String ' タイムスタンプ（バッチ日）
		Dim UOPEID As String ' 最終作業者コード
		Dim UCLTID As String ' クライアントＩＤ
		Dim UWRTTM As String ' タイムスタンプ（バッチ時間）
		Dim UWRTDT As String ' タイムスタンプ（バッチ日）
	End Structure
	
	Public HIKET54_UPDATE_FLAG_Inf() As HIKET51_UPDATE_FLAG
	' === 20080729 === INSERT E -
	
	'**ﾁｪｯｸ関数関連 Start **
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
                '2019/09/26 CHG START
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/09/26 CHG E N D
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
			
			If pm_All.Dsp_Base.Head_Ok_Flg = True Then
                '元の項目へﾌｫｰｶｽ移動
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/10/09 CHG START
                'Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.CS_HIK.Tag)), pm_All)
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.btnF6.Tag)), pm_All)
                '2019/10/09 CHG END
                Exit Function
			End If
			
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
            '2019/09/26 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/09/26 CHG E N D
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
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart + 1
                    '2019/09/26 CHG E N D
                    '編集後のSelLengthを決定
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                    '2019/09/26 CHG E N D
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
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                            '2019/09/26 CHG E N D
                            '編集後のSelLengthを決定
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            '2019/09/26 CHG E N D
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
                                    '2019/09/26 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                    '2019/09/26 CHG E N D
                                    '編集後のSelLengthを決定
                                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/09/26 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                    '2019/09/26 CHG E N D

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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        '編集後のSelLengthを決定
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                                '2019/09/26 CHG E N D
                                '編集後のSelLengthを決定
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                                '2019/09/26 CHG E N D
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        '編集後のSelLengthを決定
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                '2019/09/26 CHG E N D
                                '編集後のSelLengthを決定
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                '2019/09/26 CHG E N D
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
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
                '2019/09/26 DEL START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                '2019/09/26 DEL E N D
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
	'   概要：  VS_ScrlのMOUSEDOWNの制御
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
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color_MEISAI(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
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
	'   名称：  Function CF_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
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
        '2019/09/26 CHG START
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/09/26 CHG E N D
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
        '2019/09/26 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart

        '2019/09/26 CHG E N D
        '編集後のSelLengthを決定
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelLength
        '入力後の後処理
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
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
		
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    '行を追加された後に
		'    '初期値を追加した行に対してループ内で１行ずつ行う
		'    'ここでの行は、Dsp_Body_Infの行！！
		'    For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'    Next
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
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
		Dim bolDsp As Boolean
		
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
		
		bolDsp = False
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				
				If Rtn_Chk <> CHK_OK Then
					'チェックＮＧの場合
					'キーフラグを元に戻す
					gv_bolKeyFlg = False
					Exit For
				End If
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					If bolDsp = False Then
						'画面編集
						Call F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
						'【※注意※】強引に、ｲﾝﾃﾞｯｸｽをフッタ部の頭にジャンプさせている。
						'ループ回数減のため。明細に入力項目がないから可能。
						Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx
						'キーフラグを元に戻す
						gv_bolKeyFlg = False
                        bolDsp = True
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
		
		'最終項目まで検索終了時
		If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
			'モードにより検索終了後の処理を決定
			Select Case pm_Mode
				Case NEXT_FOCUS_MODE_KEYRETURN
					'KEYRETURNの場合
					'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
					'移動先が検索不可の場合
					'更新前チェック⇒ＤＢ更新⇒初期化
					Call F_Ctl_Upd_Process(pm_All)
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
            '2019/09/26 CHG START
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            '2019/09/26 CHG E N D
            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '１文字目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/06 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 0
                    '2019/09/06 CHG E N D
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/06 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/06 CHG E N D
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
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        '2019/09/26 CHG E N D
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/09/26 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '2019/09/26 CHG E N D
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
            '2019/09/26 CHG START
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/09/26 CHG E N D
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
            If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '最終文字を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    '2019/09/26 CHG E N D
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/26 CHG E N D

                Else
                    '詰文字が左詰以外の場合
                    '１桁目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/09/26 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = 1
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                    '2019/09/26 CHG E N D
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
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            '2019/09/26 CHG E N D
                        Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '一番右へ移動し選択なし状態に
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/09/26 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                                '2019/09/26 CHG E N D
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
                            '2019/09/26 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Next_SelStart
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                            '2019/09/26 CHG E N D
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			Case FR_SSSMAIN.HD_SBNNO.Name
				'製番による画面表示
				Call F_Dsp_HD_SBNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_HINCD.Name
				'製品コードによる画面表示
				Call F_Dsp_HD_HINCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
		End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_SBNNO_Inf
	'   概要：  製番による画面表示
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_SBNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			'製番が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'【型式】
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMA.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(HIKET54_HINMTA_Inf.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'【品名】
				Trg_Index = CShort(FR_SSSMAIN.HD_HINNMB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(HIKET54_HINMTA_Inf.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
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
			Case FR_SSSMAIN.HD_SBNNO.Name
				'ﾁｪｯｸ前処理(KEYRETURNを設定)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'対象見積番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_SBNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_HINCD.Name
				'ﾁｪｯｸ前処理(KEYRETURNを設定)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'版数のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_SBNNO
	'   概要：  製番のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_SBNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_SBNNO = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			'   Retn_Code = CHK_ERR_NOT_INPUT
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_010
			Else
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
		
		F_Chk_HD_SBNNO = Retn_Code
		
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
        '2019/09/26 CHG START
        'Call DB_HINMTA_Clear(Mst_Inf)
        Call InitDataCommon("HINMTA")
        '2019/09/26 CHG E N D
        '未入力チェック
        If CF_Trim_Item((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf) = "" Then
			'        Retn_Code = CHK_ERR_NOT_INPUT
			
			HIKET54_HINMTA_Inf.DATKB = Mst_Inf_Clr.DATKB
			HIKET54_HINMTA_Inf.HINCD = Mst_Inf_Clr.HINCD '製品コード
			HIKET54_HINMTA_Inf.HINNMA = Mst_Inf_Clr.HINNMA '型式
			HIKET54_HINMTA_Inf.HINNMB = Mst_Inf_Clr.HINNMB '品名
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base((pm_Chk_Dsp_Sub_Inf.Ctl.Text), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_010
			Else
				'マスタチェック
				If DSPHINCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'論理削除チェック
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKET54_E_004
						GoTo F_Chk_HD_HINCD_End
					End If
					
					'在庫管理区分チェック
					If Mst_Inf.ZAIKB = gc_strZAIKB_NG Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgHIKET54_E_005
						GoTo F_Chk_HD_HINCD_End
					End If
					
					'チェックＯＫ
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					HIKET54_HINMTA_Inf.DATKB = Mst_Inf.DATKB
					HIKET54_HINMTA_Inf.HINCD = Mst_Inf.HINCD '製品コード
					HIKET54_HINMTA_Inf.HINNMA = Mst_Inf.HINNMA '型式
					HIKET54_HINMTA_Inf.HINNMB = Mst_Inf.HINNMB '品名
					
				Else
					'該当データ無し
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgHIKET54_E_003
					
				End If
			End If
		End If
		
F_Chk_HD_HINCD_End: 
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_HINCD = Retn_Code
		
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
			
			gv_bolHIKET54_LF_Enable = False
			
			WLSHIN_KHNSEARCH = gc_strKHNKB_HON
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'製品検索画面を呼び出す
			WLSHIN.ShowDialog()
			WLSHIN.Close()
			
			gv_bolHIKET54_LF_Enable = True
			
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
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		If Rtn_Chk = CHK_OK Then
			'関連チェック
			Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		End If
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'１行目のボディ部を準備最終行として開放する
			pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'フッタ部を開放する
			Call F_Foot_In_Ready(pm_All)
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
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
		Dim Wk_Mode As Short
		Dim Now_Dt As Date
		
		Now_Dt = Now
		
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
			
			'個別初期化（日付項目に初期値・システム日付をセットする、等）
			
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
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Act_Index As Short
		
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'案件ＩＤにフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Act_Index = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Act_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color_MEISAI(pm_All.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, pm_All)
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Upd_Process
	'   概要：  更新メインルーチン
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_RelChk
	'   概要：  ヘッダ部関連チェック
	'   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim strCode1 As String
		Dim strCode2 As String
		Dim intRet As Short
		Dim Err_Cd As String
		
		'初期化
		Retn_Code = CHK_OK
		Msg_Flg = False
		Err_Cd = ""
		
		If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" Or Trim(FR_SSSMAIN.HD_HINCD.Text) = "" Then
			'いずれも未入力の場合はエラー
			Retn_Code = CHK_ERR_NOT_INPUT
			If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" And Trim(FR_SSSMAIN.HD_HINCD.Text) = "" Then
				Err_Cd = gc_strMsgHIKET54_E_002
			Else
				Err_Cd = gc_strMsgHIKET54_E_011
			End If
			If Trim(FR_SSSMAIN.HD_SBNNO.Text) = "" Then
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
			Else
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_HINCD.Tag)
			End If
		End If
		
		If Retn_Code = CHK_OK Then
			strCode1 = Trim(FR_SSSMAIN.HD_SBNNO.Text)
			strCode2 = Trim(FR_SSSMAIN.HD_HINCD.Text)
			'対象レコード存在チェック
			intRet = F_CHK_DSPCD(strCode1, strCode2)
			If intRet <> CHK_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgHIKET54_E_003
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_SBNNO.Tag)
			End If
		End If
		
		Msg_Flg = True
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Head_RelChk = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_CHK_DSPCD
	'   概要：  検索対象データ有無
	'   引数：　pm_strCode1           :ｺｰﾄﾞ１
	'           pm_strCode2　　　　　 :ｺｰﾄﾞ２
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_CHK_DSPCD(ByVal pm_strCode1 As String, Optional ByVal pm_strCode2 As String = "") As Short
		
		Dim intRet As Short
		Dim Retn_Code As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		Retn_Code = CHK_OK
		intRet = 0
		
		'/////////////////////////////////////////////////////////////
		' 支給品の検索
		'/////////////////////////////////////////////////////////////
		
		'検索SQL
		strSQL = ""
		strSQL = strSQL & " SELECT    '3' SYBT"
		strSQL = strSQL & "         , SKYTBL.OUTSOUCD"
		strSQL = strSQL & "         , ' ' OUTKB"
		strSQL = strSQL & "         , SKYTBL.HINCD"
		strSQL = strSQL & "         , SKYTBL.SPRNOKDT OUTYTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTTM"
		strSQL = strSQL & "         , SKYTBL.SBNNO"
		strSQL = strSQL & "         , SKYTBL.SPRRENNO"
		strSQL = strSQL & "         , SKYTBL.PUDLNO"
		strSQL = strSQL & "         , SKYTBL.TOKCD"
		strSQL = strSQL & "         , SKYTBL.OUTYOTSU OUTYTSU"
		strSQL = strSQL & "         , SKYTBL.FRDSU    FRDSU"
		strSQL = strSQL & "         , SKYTBL.OUTZMISU OTPSU"
		strSQL = strSQL & " From SKYTBL"
		strSQL = strSQL & " WHERE     SKYTBL.DATKB    =  '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & "   AND     SKYTBL.SBNNO = '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD = '" & CF_Ora_Sgl(pm_strCode2) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし（つまり、すべて対象外）
			intRet = -1
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'/////////////////////////////////////////////////////////////
		' 製番出庫の検索
		'/////////////////////////////////////////////////////////////
		If intRet <> 0 Then
			
			intRet = 0
			
			'検索SQL
			strSQL = ""
			strSQL = strSQL & " SELECT    '4' SYBT"
			strSQL = strSQL & "         , SBNTRA.OUTSOUCD"
			strSQL = strSQL & "         , SBNTRA.OUTKB"
			strSQL = strSQL & "         , SBNTRA.HINCD"
			strSQL = strSQL & "         , SBNTRA.OUTYTDT"
			strSQL = strSQL & "         , SBNTRA.WRTFSTDT"
			strSQL = strSQL & "         , SBNTRA.WRTFSTTM"
			strSQL = strSQL & "         , SBNTRA.SBNNO"
			strSQL = strSQL & "         , '0' SPRRENNO"
			strSQL = strSQL & "         , SBNTRA.PUDLNO"
			strSQL = strSQL & "         , SBNTRA.TOKCD"
			strSQL = strSQL & "         , SBNTRA.FRDYTSU OUTYTSU"
			strSQL = strSQL & "         , SBNTRA.FRDSU   FRDSU"
			strSQL = strSQL & "         , SBNTRA.OUTSMSU OTPSU"
			strSQL = strSQL & " From SBNTRA"
			strSQL = strSQL & " WHERE     SBNTRA.DATKB    =  '" & gc_strDATKB_USE & "'"
			strSQL = strSQL & "   AND     SBNTRA.SBNNO = '" & CF_Ora_Sgl(pm_strCode1) & "'"
			strSQL = strSQL & "   AND     SBNTRA.HINCD = '" & CF_Ora_Sgl(pm_strCode2) & "'"
			
			'DBアクセス
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			
			If CF_Ora_EOF(Usr_Ody) = True Then
				'取得データなし（つまり、すべて対象外）
				intRet = -1
			End If
			
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			
		End If
		
		If intRet <> 0 Then
			'対象データ無し（エラーコードを変えるべき？）
			Retn_Code = CHK_ERR_ELSE
		End If
		
		F_CHK_DSPCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DSP_BD_Inf
	'   概要：  ボディ部編集メイン
	'   引数：　なし
	'   戻値：　処理ステータス
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strCode1 As String
		Dim strCode2 As String
		Dim intCnt As Short
		Dim intRet As Short
		
		Dim Trg_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			
			'変数の設定
			strCode1 = Trim(FR_SSSMAIN.HD_SBNNO.Text)
			strCode2 = Trim(FR_SSSMAIN.HD_HINCD.Text)
			
			' === 20080729 === INSERT S - RISE)Izumi
			'排他情報が書き換わったフラグをOFFにする(すべての行)
			Erase HIKET54_UPDATE_FLAG_Inf
			' === 20080729 === INSERT E -
			
			'データ取得
			intCnt = F_GET_BD_DATA(strCode1, strCode2, HIKET54_DSP_DATA_Inf, pm_All)
			
			If intCnt > 0 Then
				'チェックOK
				pm_All.Dsp_Base.Head_Ok_Flg = True
				
				'データ編集
				intRet = F_SET_BD_DATA(HIKET54_DSP_DATA_Inf, pm_All, intCnt)
                'ヘッダ部入力可否制御
                Call F_Set_Inp_Item_Focus_Ctl(False, pm_All)
            End If
			
			'復元内容、前回内容を退避
			Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
			
			
			
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：　pm_strCode1           :ｺｰﾄﾞ1
	'           pm_strCode2           :ｺｰﾄﾞ2
	'           pm_All                :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_DATA(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intIdx As Short
		Dim Wk_Index As Short
		Dim HIKET54_DSP_DATA_Clr As HIKET54_DSP_DATA
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'初期化
		'UPGRADE_WARNING: オブジェクト pm_HIKET54_DSP_DATA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_HIKET54_DSP_DATA = HIKET54_DSP_DATA_Clr
		
		'検索ＳＱＬ生成
		strSQL = F_GET_BD_SQL(pm_strCode1, pm_strCode2)

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし（つまり、すべて対象外）
			F_GET_BD_DATA = 0
			'メッセージ表示
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_020, pm_All)
			Exit Function
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			intCnt = 0
			'取得全レコードよりボディ情報退避
			Do Until CF_Ora_EOF(Usr_Ody) = True
				intCnt = intCnt + 1
				
				'行追加
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				
				' === 20080725 === INSERT S - RISE)Izumi
				ReDim Preserve HIKET54_UPDATE_FLAG_Inf(intCnt)
				' === 20080725 === INSERT E -
				
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					'(6.)
					.Bus_Inf.IsDataRow = True
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SYBT = CF_Ora_GetDyn(Usr_Ody, "SYBT", "") '種別
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SBNNO = CF_Ora_GetDyn(Usr_Ody, "SBNNO", "") '製番
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "") '製品コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "") '型式
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "") '品名
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.ODNYTDT = CF_Ora_GetDyn(Usr_Ody, "ODNYTDT", "") '出荷予定日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OTPSU, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FRDSU, 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.OUTYTSU = CF_Ora_GetDyn(Usr_Ody, "OUTYTSU", 0) - CF_Ora_GetDyn(Usr_Ody, "FRDSU", 0) - CF_Ora_GetDyn(Usr_Ody, "OTPSU", 0) '数量
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.ORGSBNNO = CF_Ora_GetDyn(Usr_Ody, "ORGSBNNO", "") '元製番
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.OUTRSNCD = CF_Ora_GetDyn(Usr_Ody, "OUTRSNCD", "") '出庫理由コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.OUTRSNNM = CF_Ora_GetDyn(Usr_Ody, "OUTRSNNM", "") '出庫理由名
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
					' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.OUTBMCD = CF_Ora_GetDyn(Usr_Ody, "OUTBMCD", "") '送り先部門コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.OUTTANCD = CF_Ora_GetDyn(Usr_Ody, "OUTTANCD", "") '送り先担当者コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '納入先コード
					' === 20080725 === INSERT E -
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SIRCD = CF_Ora_GetDyn(Usr_Ody, "SIRCD", "") '仕入先コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SIRRN = CF_Ora_GetDyn(Usr_Ody, "SIRRN", "") '仕入先略称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '登録日
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '登録時間
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '倉庫コード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '倉庫名称
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '伝票管理№
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SPRRENNO = CF_Ora_GetDyn(Usr_Ody, "SPRRENNO", "") '分割連番
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.PUDLNO = CF_Ora_GetDyn(Usr_Ody, "PUDLNO", "") '入出庫番号
					' === 20080725 === INSERT S - RISE)Izumi
					'                .Bus_Inf.SUB_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    ' 最終作業者コード
					'                .Bus_Inf.SUB_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    ' クライアントＩＤ
					'                .Bus_Inf.SUB_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    ' タイムスタンプ（時間）
					'                .Bus_Inf.SUB_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    ' タイムスタンプ（日付）
					'                .Bus_Inf.SUB_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")                  ' 最終作業者コード
					'                .Bus_Inf.SUB_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")                  ' クライアントＩＤ
					'                .Bus_Inf.SUB_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")                  ' タイムスタンプ（バッチ時間）
					'                .Bus_Inf.SUB_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")                  ' タイムスタンプ（バッチ日）
					With HIKET54_UPDATE_FLAG_Inf(intCnt)
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '伝票管理№
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SPRRENNO = CF_Ora_GetDyn(Usr_Ody, "SPRRENNO", "") '行番号
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") ' 最終作業者コード
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") ' クライアントＩＤ
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") ' タイムスタンプ（バッチ時間）
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") ' タイムスタンプ（バッチ日）
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") ' 最終作業者コード
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") ' クライアントＩＤ
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") ' タイムスタンプ（バッチ時間）
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") ' タイムスタンプ（バッチ日）
					End With
					' === 20080725 === INSERT E -
					
					
					'(7.)
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					'出荷予定日
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTYTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.ODNYTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'数量
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTYTSU(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.OUTYTSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'受注製番
					Wk_Index = CShort(FR_SSSMAIN.BD_ORGSBNNO(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.ORGSBNNO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'出庫理由
					Wk_Index = CShort(FR_SSSMAIN.BD_OUTRSNNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.OUTRSNNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'得意先
					Wk_Index = CShort(FR_SSSMAIN.BD_TOKRN(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.TOKRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'仕入先
					Wk_Index = CShort(FR_SSSMAIN.BD_SIRRN(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SIRRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'登録日
					Wk_Index = CShort(FR_SSSMAIN.BD_WRTFSTDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.WRTFSTDT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					'倉庫
					Wk_Index = CShort(FR_SSSMAIN.BD_SOUNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
					
				End With
				
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
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Bus_Inf.IsDataRow = False
				Next intIdx
			End If
			
		End If
		
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
	Private Function F_SET_BD_DATA(ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_All As Cls_All, ByRef pm_intCnt As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		F_SET_BD_DATA = 9

        '■ボディ部
        'スクロールバー値設定
        '最大値
        '2019/10/09 CHG START
        'Call CF_Set_VScrl_Max(F_Get_VScrl_Max(pm_intCnt, pm_All.Dsp_Base.Dsp_Body_Cnt), pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        pm_intCnt = IIf(pm_intCnt = 1, pm_intCnt, pm_intCnt - 1)
        Call CF_Set_VScrl_Max(pm_intCnt, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
        '2019/10/09 CHG END

        '最上行設定（検索直後なので１）
        pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		
		'明細編集メイン
		Call CF_Body_Dsp(pm_All)
		'明細選択処理
		Trg_Index = CShort(FR_SSSMAIN.BD_SELECTB(1).Tag)
		Call F_Set_BD_Sel_Index(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, HIKET54_Bd_Sel_Index)
		Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		
		F_SET_BD_DATA = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_SQL
	'   概要：  明細情報データ取得ＳＱＬ生成
	'   引数：　pm_strCode1           :ｺｰﾄﾞ1
	'           pm_strCode2           :ｺｰﾄﾞ2
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_BD_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String) As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " ("
		strSQL = strSQL & " SELECT    '3' SYBT"
		strSQL = strSQL & "         , SKYTBL.SBNNO"
		strSQL = strSQL & "         , SKYTBL.HINCD"
		strSQL = strSQL & "         , HINMTA.HINNMA"
		strSQL = strSQL & "         , HINMTA.HINNMB"
		strSQL = strSQL & "         , SKYTBL.SPRNOKDT ODNYTDT"
		strSQL = strSQL & "         , SKYTBL.OUTYOTSU OUTYTSU"
		strSQL = strSQL & "         , SKYTBL.FRDSU    FRDSU"
		strSQL = strSQL & "         , SKYTBL.OUTZMISU OTPSU"
		strSQL = strSQL & "         , ' '    ORGSBNNO"
		strSQL = strSQL & "         , ' '    OUTRSNCD"
		strSQL = strSQL & "         , ' '    OUTRSNNM"
		strSQL = strSQL & "         , SKYTBL.TOKCD"
		' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & "         , ' '    OUTBMCD"
		strSQL = strSQL & "         , ' '    OUTTANCD"
		strSQL = strSQL & "         , ' '    NHSCD"
		' === 20080725 === INSERT E -
		strSQL = strSQL & "         , TOKMTA.TOKRN"
		strSQL = strSQL & "         , SKYTBL.SIRCD"
		strSQL = strSQL & "         , SIRMTA.SIRRN"
		strSQL = strSQL & "         , SKYTBL.WRTFSTDT"
		strSQL = strSQL & "         , SKYTBL.WRTFSTTM"
		strSQL = strSQL & "         , SUBSTR(HINMTA.TNACM,1,3) SOUCD"
		strSQL = strSQL & "         , SOUMTA.SOUNM"
		strSQL = strSQL & "         , ' '    DATNO"
		strSQL = strSQL & "         , SKYTBL.SPRRENNO"
		strSQL = strSQL & "         , SKYTBL.PUDLNO"
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "         , SKYTBL.OPEID    As OPEID" '最終作業者コード
		strSQL = strSQL & "         , SKYTBL.CLTID    As CLTID" 'クライアントＩＤ
		strSQL = strSQL & "         , SKYTBL.WRTTM    As WRTTM" 'タイムスタンプ（時間）
		strSQL = strSQL & "         , SKYTBL.WRTDT    As WRTDT" 'タイムスタンプ（日付）
		strSQL = strSQL & "         , ' '    UOPEID" '最終作業者コード（支給品ファイルに無い為空とする）
		strSQL = strSQL & "         , ' '    UCLTID" 'クライアントＩＤ（支給品ファイルに無い為空とする）
		strSQL = strSQL & "         , ' '    UWRTTM" 'タイムスタンプ（バッチ時間）（支給品ファイルに無い為空とする）
		strSQL = strSQL & "         , ' '    UWRTDT" 'タイムスタンプ（バッチ日）（支給品ファイルに無い為空とする）
		' === 20080725 === INSERT E -
		strSQL = strSQL & " From SKYTBL"
		strSQL = strSQL & "         , HINMTA"
		strSQL = strSQL & "         , TOKMTA"
		strSQL = strSQL & "         , SIRMTA"
		strSQL = strSQL & "         , SOUMTA"
		strSQL = strSQL & " WHERE     SKYTBL.DATKB             =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.SBNNO             =  '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD             =  '" & CF_Ora_Sgl(pm_strCode2) & "'"
		strSQL = strSQL & "   AND     SKYTBL.PLANKB            =  ' '"
		strSQL = strSQL & "   AND     HINMTA.DATKB             =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.HINCD             =  HINMTA.HINCD"
		strSQL = strSQL & "   AND     SKYTBL.OUTYOTSU          >  SKYTBL.FRDSU + SKYTBL.OUTZMISU"
		strSQL = strSQL & "   AND     HINMTA.ZAIKB             =  '1'"
		strSQL = strSQL & "   AND     HINMTA.JODHIKKB          =  '1'"
		strSQL = strSQL & "   AND     HINMTA.ORTSTPKB          =  '1'"
		strSQL = strSQL & "   AND     SKYTBL.TOKCD             =  TOKMTA.TOKCD(+)"
		strSQL = strSQL & "   AND     SKYTBL.SIRCD             =  SIRMTA.SIRCD(+)"
		strSQL = strSQL & "   AND     SUBSTR(HINMTA.TNACM,1,3) =  SOUMTA.SOUCD(+)"
		strSQL = strSQL & " )"
		strSQL = strSQL & " Union All"
		strSQL = strSQL & " ("
		strSQL = strSQL & " SELECT    '4' SYBT"
		strSQL = strSQL & "         , SBNTRA.SBNNO"
		strSQL = strSQL & "         , SBNTRA.HINCD"
		strSQL = strSQL & "         , HINMTA.HINNMA"
		strSQL = strSQL & "         , HINMTA.HINNMB"
		strSQL = strSQL & "         , SBNTRA.OUTYTDT"
		strSQL = strSQL & "         , SBNTRA.FRDYTSU ODNYTSU"
		strSQL = strSQL & "         , SBNTRA.FRDSU   FRDSU"
		strSQL = strSQL & "         , SBNTRA.OUTSMSU OTPSU"
		strSQL = strSQL & "         , SBNTRA.ORGSBNNO"
		strSQL = strSQL & "         , SBNTRA.OUTRSNCD"
		strSQL = strSQL & "         , MEIMTA.MEINMA OUTRSNNM"
		strSQL = strSQL & "         , SBNTRA.TOKCD"
		' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		strSQL = strSQL & "         , SBNTRA.OUTBMCD"
		strSQL = strSQL & "         , SBNTRA.OUTTANCD"
		strSQL = strSQL & "         , SBNTRA.NHSCD"
		' === 20080725 === INSERT E -
		strSQL = strSQL & "         , TOKMTA.TOKRN"
		strSQL = strSQL & "         , ' '    SIRCD"
		strSQL = strSQL & "         , ' '    SIRRN"
		strSQL = strSQL & "         , SBNTRA.WRTFSTDT"
		strSQL = strSQL & "         , SBNTRA.WRTFSTTM"
		strSQL = strSQL & "         , SBNTRA.OUTSOUCD SOUCD"
		strSQL = strSQL & "         , SOUMTA.SOUNM"
		strSQL = strSQL & "         , SBNTRA.DATNO"
		strSQL = strSQL & "         , ' ' SPRRENNO"
		strSQL = strSQL & "         , SBNTRA.PUDLNO"
		' === 20080725 === INSERT S - RISE)Izumi
		strSQL = strSQL & "         , SBNTRA.OPEID     As OPEID" '最終作業者コード
		strSQL = strSQL & "         , SBNTRA.CLTID     As CLTID" 'クライアントＩＤ
		strSQL = strSQL & "         , SBNTRA.WRTTM     As WRTTM" 'タイムスタンプ（時間）
		strSQL = strSQL & "         , SBNTRA.WRTDT     As WRTDT" 'タイムスタンプ（日付）
		strSQL = strSQL & "         , SBNTRA.UOPEID    As UOPEID" '最終作業者コード
		strSQL = strSQL & "         , SBNTRA.UCLTID    As UCLTID" 'クライアントＩＤ
		strSQL = strSQL & "         , SBNTRA.UWRTTM    As UWRTTM" 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "         , SBNTRA.UWRTDT    As UWRTDT" 'タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
		strSQL = strSQL & " From SBNTRA"
		strSQL = strSQL & "         , HINMTA"
		strSQL = strSQL & "         , TOKMTA"
		strSQL = strSQL & "         , MEIMTA"
		strSQL = strSQL & "         , SOUMTA"
		strSQL = strSQL & " WHERE     SBNTRA.DATKB    =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.SBNNO    =  '" & CF_Ora_Sgl(pm_strCode1) & "'"
		strSQL = strSQL & "   AND     SBNTRA.HINCD    =  '" & CF_Ora_Sgl(pm_strCode2) & "'"
		strSQL = strSQL & "   AND     HINMTA.DATKB    =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.HINCD    =  HINMTA.HINCD"
		strSQL = strSQL & "   AND     SBNTRA.FRDYTSU  >  SBNTRA.FRDSU + SBNTRA.OUTSMSU"
		strSQL = strSQL & "   AND     HINMTA.ZAIKB    =  '1'"
		strSQL = strSQL & "   AND     HINMTA.JODHIKKB =  '1'"
		strSQL = strSQL & "   AND     HINMTA.ORTSTPKB =  '1'"
		strSQL = strSQL & "   AND     SBNTRA.TOKCD    =  TOKMTA.TOKCD(+)"
		strSQL = strSQL & "   AND     '066'           =  MEIMTA.KEYCD(+)"
		strSQL = strSQL & "   AND     SBNTRA.OUTRSNCD =  MEIMTA.MEICDA(+)"
		strSQL = strSQL & "   AND     SBNTRA.OUTSOUCD =  SOUMTA.SOUCD(+)"
		strSQL = strSQL & " )"
		strSQL = strSQL & " ORDER BY  ODNYTDT"
		strSQL = strSQL & "         , WRTFSTDT"
		strSQL = strSQL & "         , WRTFSTTM"
		
		F_GET_BD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_BD_Sel_Index
	'   概要：  選択行ｲﾝﾃﾞｯｸｽ退避
	'   引数：　pm_Dsp_Sub_Inf        :対象コントロール
	'           pm_Sel_Index          :選択行ｲﾝﾃﾞｯｸｽ退避変数
	'   戻値：　設定値
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_BD_Sel_Index(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Sel_Index As Short) As Short
		
		Dim Row_Index As Short
		
		F_Set_BD_Sel_Index = 9
		
		'対象コントロールの（Dsp_Body_Infの）ｲﾝﾃﾞｯｸｽを取得
		Row_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		If pm_All.Dsp_Body_Inf.Row_Inf(Row_Index).Bus_Inf.IsDataRow = True Then
			'選択可能行であれば、退避
			pm_Sel_Index = Row_Index
		End If
		
		F_Set_BD_Sel_Index = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_BD_Select
	'   概要：  明細選択処理
	'   引数：　pm_Dsp_Sub_Inf        :
	'   戻値：　処理結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_BD_Select(ByRef pm_Sel_Index As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Row_Index As Short
		Dim intIdx As Short
		
		F_Ctl_BD_Select = 9
		
		'表示明細数分ループ
		For intIdx = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
			'対象コントロールの（Dsp_Sub_Infの）ｲﾝﾃﾞｯｸｽを取得
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, intIdx, pm_All)
			'対象コントロールの（Dsp_Body_Infの）ｲﾝﾃﾞｯｸｽを取得
			Row_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'対象の明細が選択行であれば、選択状態に
			If Row_Index = pm_Sel_Index Then
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Ctl.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/09/26 CHAG START
                'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Value = True
                If TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is CheckBox Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, CheckBox).Checked = True
                ElseIf TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is RadioButton Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, RadioButton).Checked = True
                End If
                '2019/09/26 CHAG E N D
            Else
                'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Ctl.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/09/26 CHAG START
                'pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Value = False
                If TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is CheckBox Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, CheckBox).Checked = False
                ElseIf TypeOf pm_All.Dsp_Sub_Inf(Trg_Index).Ctl Is RadioButton Then
                    DirectCast(pm_All.Dsp_Sub_Inf(Trg_Index).Ctl, RadioButton).Checked = False
                End If
                '2019/09/26 CHAG E N D
            End If
			
		Next intIdx
		
		F_Ctl_BD_Select = 0
		
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
	'   名称：  Function F_Set_Item_Focus_Ctl_FromTo
	'   概要：  コントロールの使用可否制御（範囲指定）
	'   引数：　pm_Value              :設定値
	'           pm_All                :全構造体
	'           pm_Fst_Index          :範囲自（Dsp_Sub_Infのｲﾝﾃﾞｯｸｽ）
	'           pm_Lst_Index          :範囲至（Dsp_Sub_Infのｲﾝﾃﾞｯｸｽ）
	'   戻値：　処理結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Item_Focus_Ctl_FromTo(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All, ByRef pm_Fst_Index As Short, ByRef pm_Lst_Index As Short) As Short
		
		Dim intIdx As Short
		
		F_Set_Item_Focus_Ctl_FromTo = 9
		
		'範囲内の全コントロール分ループ
		For intIdx = pm_Fst_Index To pm_Lst_Index Step 1
			Call CF_Set_Item_Focus_Ctl(pm_Value, pm_All.Dsp_Sub_Inf(intIdx))
		Next intIdx
		
		F_Set_Item_Focus_Ctl_FromTo = 0
		
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

        '引当/解除ボタン
        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/09 CHG START
        'Trg_Index = CShort(FR_SSSMAIN.CS_HIK.Tag)
        Trg_Index = CShort(FR_SSSMAIN.btnF6.Tag)
        '2019/10/09 CHG END
        Call CF_Set_Item_Focus_Ctl(Not pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Interface
	'   概要：  インターフェース格納
	'   引数：　pm_Row_Inf             :行情報構造体
	'           pm_HIKET54_DSP_DATA    :画面業務情報構造体
	'           pm_HIKET54_Interface   :インターフェース
	'           pm_Bd_Sel_Index        :選択行ｲﾝﾃﾞｯｸｽ
	'   戻値：  処理結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    連絡票№FC12031301
	'Public Function F_Set_Interface(pm_Row_Inf As Cls_Dsp_Body_Row_Inf, _
	''                                pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, _
	''                                pm_HIKET54_Interface As Cls_HIKET54_Interface) As Integer
	Public Function F_Set_Interface(ByRef pm_Row_Inf As Cls_Dsp_Body_Row_Inf, ByRef pm_HIKET54_DSP_DATA As HIKET54_DSP_DATA, ByRef pm_HIKET54_Interface As Cls_HIKET54_Interface, ByRef pm_Bd_Sel_Index As Short) As Short
		'''' UPD 2012/03/13  FKS) T.Yamamoto    End
		
		F_Set_Interface = 9
		
		'インターフェースに値を格納
		With pm_HIKET54_Interface
			'伝票種別（3:支給品情報/4:製番出庫情報）
			.Mode = pm_Row_Inf.Bus_Inf.SYBT
			'伝票管理№
			.DATNO = pm_Row_Inf.Bus_Inf.DATNO
			'出庫予定日
			.ODNYTDT = pm_Row_Inf.Bus_Inf.ODNYTDT
			'分割連番
			.SPRRENNO = pm_Row_Inf.Bus_Inf.SPRRENNO
			'製番
			.SBNNO = pm_Row_Inf.Bus_Inf.SBNNO
			'製品コード
			.HINCD = pm_Row_Inf.Bus_Inf.HINCD
			'型式
			.HINNMA = pm_Row_Inf.Bus_Inf.HINNMA
			'商品名１
			.HINNMB = pm_Row_Inf.Bus_Inf.HINNMB
			'受注数量
			.UODSU = pm_Row_Inf.Bus_Inf.OUTYTSU
			'得意先コード
			.TOKCD = pm_Row_Inf.Bus_Inf.TOKCD
			' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
			'送り先部門コード
			.OUTBMCD = pm_Row_Inf.Bus_Inf.OUTBMCD
			'送り先担当者コード
			.OUTTANCD = pm_Row_Inf.Bus_Inf.OUTTANCD
			'納入先コード
			.NHSCD = pm_Row_Inf.Bus_Inf.NHSCD
			' === 20080725 === INSERT E -
			'倉庫コード
			.SOUCD = pm_Row_Inf.Bus_Inf.SOUCD
			'入出庫番号
			.PUDLNO = pm_Row_Inf.Bus_Inf.PUDLNO
			'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    連絡票№FC12031301
			'' === 20080725 === INSERT S - RISE)Izumi
			'' === 20080729 === UPDATE S - RISE)Izumi
			''        '排他情報が書き換わっている場合は情報をセットしない
			''        If gv_bolInterfaceFlg = False Then
			''            ' 最終作業者コード
			''            .OPEID = pm_Row_Inf.Bus_Inf.SUB_OPEID
			''            'クライアントＩＤ
			''            .CLTID = pm_Row_Inf.Bus_Inf.SUB_CLTID
			''            'タイムスタンプ（時間）
			''            .WRTTM = pm_Row_Inf.Bus_Inf.SUB_WRTTM
			''            'タイムスタンプ（日付）
			''            .WRTDT = pm_Row_Inf.Bus_Inf.SUB_WRTDT
			''            ' 最終作業者コード
			''            .UOPEID = pm_Row_Inf.Bus_Inf.SUB_UOPEID
			''            'クライアントＩＤ
			''            .UCLTID = pm_Row_Inf.Bus_Inf.SUB_UCLTID
			''            'タイムスタンプ（バッチ時間）
			''            .UWRTTM = pm_Row_Inf.Bus_Inf.SUB_UWRTTM
			''            'タイムスタンプ（バッチ日）
			''            .UWRTDT = pm_Row_Inf.Bus_Inf.SUB_UWRTDT
			''        End If
			'        Dim intLoop     As Integer
			'
			'        For intLoop = 1 To UBound(HIKET54_UPDATE_FLAG_Inf)
			'            ' 伝票管理No.と行番号が一致した場合
			'            If HIKET54_UPDATE_FLAG_Inf(intLoop).DATNO = pm_Row_Inf.Bus_Inf.DATNO _
			''                    And HIKET54_UPDATE_FLAG_Inf(intLoop).SPRRENNO = pm_Row_Inf.Bus_Inf.SPRRENNO Then
			'                ' 最終作業者コード
			'                .OPEID = HIKET54_UPDATE_FLAG_Inf(intLoop).OPEID
			'                ' クライアントＩＤ
			'                .CLTID = HIKET54_UPDATE_FLAG_Inf(intLoop).CLTID
			'                ' タイムスタンプ（バッチ時間）
			'                .WRTTM = HIKET54_UPDATE_FLAG_Inf(intLoop).WRTTM
			'                ' タイムスタンプ（バッチ日）
			'                .WRTDT = HIKET54_UPDATE_FLAG_Inf(intLoop).WRTDT
			'                ' 最終作業者コード
			'                .UOPEID = HIKET54_UPDATE_FLAG_Inf(intLoop).UOPEID
			'                ' クライアントＩＤ
			'                .UCLTID = HIKET54_UPDATE_FLAG_Inf(intLoop).UCLTID
			'                ' タイムスタンプ（バッチ時間）
			'                .UWRTTM = HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTTM
			'                ' タイムスタンプ（バッチ日）
			'                .UWRTDT = HIKET54_UPDATE_FLAG_Inf(intLoop).UWRTDT
			'                Exit For
			'            End If
			'        Next intLoop
			''20080725 ADD END   RISE)Tanimura
			'' === 20080729 === UPDATE E -
			'' === 20080725 === INSERT E -
			' 最終作業者コード
			.OPEID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).OPEID
			' クライアントＩＤ
			.CLTID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).CLTID
			' タイムスタンプ（バッチ時間）
			.WRTTM = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).WRTTM
			' タイムスタンプ（バッチ日）
			.WRTDT = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).WRTDT
			' 最終作業者コード
			.UOPEID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UOPEID
			' クライアントＩＤ
			.UCLTID = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UCLTID
			' タイムスタンプ（バッチ時間）
			.UWRTTM = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UWRTTM
			' タイムスタンプ（バッチ日）
			.UWRTDT = HIKET54_UPDATE_FLAG_Inf(pm_Bd_Sel_Index).UWRTDT
			'''' UPD 2012/03/13  FKS) T.Yamamoto    End
		End With
		
		F_Set_Interface = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Clr_Dsp_Out
	'   概要：  出力情報を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Clr_Dsp_Out(ByRef pm_Sel_Index As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Wk_Mode As Short
		
		Wk_Index_S = pm_All.Dsp_Base.Head_Lst_Idx + 1
		Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
		pm_All.Dsp_Base.Head_Ok_Flg = False
		Wk_Mode = ITM_ALL_CLR
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			'共通初期化
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
		Next 
		
		'☆☆☆☆☆
		'明細選択なしにする
		pm_Sel_Index = 0
		Call F_Ctl_BD_Select(pm_Sel_Index, pm_Dsp_Sub_Inf, pm_All)
		'☆☆☆☆☆
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_TANNM
	'   概要：  担当者名称取得
	'   引数：　pm_Def_LineNo
	'           pm_HIKET54_DSP_DATA    :画面業務情報構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""

        '担当者マスタ検索
        '2019/09/26 CHG START
        'Call DB_TANMTA_Clear(DB_TANMTA)
        Call InitDataCommon("TANMTA")
        '2019/09/26 CHG E N D
        intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
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
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.CS_HIK.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case CShort(FR_SSSMAIN.HD_HINCD.Tag)
				'実行
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'画面印刷
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'終了
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'項目初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
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
				
				'選択
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'前頁
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'次頁
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'候補の一覧
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
			Case CShort(FR_SSSMAIN.CS_HIK.Tag)
				'実行
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'画面印刷
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'終了
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'項目初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
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
				
				'選択
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'前頁
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'次頁
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'候補の一覧
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
			Case Else
				'実行
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'画面印刷
				Trg_Index = CShort(FR_SSSMAIN.MN_HARDCOPY.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'終了
				Trg_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				
				'項目初期化
				Trg_Index = CShort(FR_SSSMAIN.MN_ClearItm.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'項目復元
				Trg_Index = CShort(FR_SSSMAIN.MN_UnDoItem.Tag)
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
				
				'選択
				Trg_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'前頁
				Trg_Index = CShort(FR_SSSMAIN.MN_PREV.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'次頁
				Trg_Index = CShort(FR_SSSMAIN.MN_NEXTCM.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'候補の一覧
				Trg_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
		End Select
		
		'メニューボタンイメージの可視制御
		'終了ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'実行ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'検索画面表示ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_SLIST.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Slist.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'明細部クリアボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_SELECTCM.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_SELECTCM.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
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
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '2019/09/26 DEL START
        'FR_SSSMAIN.PrintForm()
        '2019/09/26 DEL E N D
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	' add 20170616 start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_EXCTBZ_2
	'   概要：  PL/SQL実行処理(排他制御処理)
	'   引数：　Pin_strPRCCASE   : 処理ケース(C:チェック W:書込処理 D:削除処理)
	'           Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御用PL/SQL(PRC_EXCTBZ_2)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ_2(ByVal Pin_strPRCCASE As String, ByRef pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(担当者コード)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(クライアントID)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(処理ケース)
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4(業務コード(PGID))
		Dim strPara5 As String 'ﾊﾟﾗﾒｰﾀ5(製番)
		Dim strPara6 As String 'ﾊﾟﾗﾒｰﾀ6(品番)
		Dim lngPara7 As Integer 'ﾊﾟﾗﾒｰﾀ7(復帰ｺｰﾄﾞ)
		Dim lngPara8 As Integer 'ﾊﾟﾗﾒｰﾀ8(ｴﾗｰｺｰﾄﾞ)
		Dim strPara9 As String 'ﾊﾟﾗﾒｰﾀ9(ｴﾗｰ内容)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(9) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ_2 = 9

        '2019/10/09 ADD START
        Try
            '2019/10/09 ADD END


            '受渡し変数初期設定
            strPara1 = Inp_Inf.InpTanCd
            strPara2 = SSS_CLTID.Value
            strPara3 = Pin_strPRCCASE
            strPara4 = SSS_PrgId
            strPara5 = FR_SSSMAIN.HD_SBNNO.Text
            strPara6 = FR_SSSMAIN.HD_HINCD.Text
            lngPara7 = 0
            lngPara8 = 0
            strPara9 = ""

            pot_strMsg = ""

            '2019/10/09 ADD START

            Dim cmd As New OracleCommand

            cmd.Connection = CON

            cmd.CommandType = CommandType.StoredProcedure

            '2019/10/09 ADD END

            '2019/10/09 CHG START

            '      'パラメータの初期設定を行う（バインド変数）
            '      'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '      gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P5", strPara5, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)

            ''データ型をオブジェクトにセット
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(1) = gv_Odb_USR1.Parameters("P1")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(2) = gv_Odb_USR1.Parameters("P2")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(3) = gv_Odb_USR1.Parameters("P3")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(4) = gv_Odb_USR1.Parameters("P4")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(5) = gv_Odb_USR1.Parameters("P5")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(6) = gv_Odb_USR1.Parameters("P6")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(7) = gv_Odb_USR1.Parameters("P7")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(8) = gv_Odb_USR1.Parameters("P8")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(9) = gv_Odb_USR1.Parameters("P9")

            ''各オブジェクトのデータ型を設定
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(1).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(2).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(3).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(4).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(5).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(6).serverType = ORATYPE_CHAR
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(7).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(8).serverType = ORATYPE_NUMBER
            ''UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'param(9).serverType = ORATYPE_VARCHAR2

            '      'PL/SQL呼び出しSQL
            '      strSQL = "BEGIN PRC_EXCTBZ_2(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9); End;"

            Dim inP1 As OracleParameter = New OracleParameter
            inP1.ParameterName = "P1"
            inP1.Direction = ParameterDirection.Input
            inP1.Value = strPara1
            cmd.Parameters.Add(inP1)

            Dim inP2 As OracleParameter = New OracleParameter
            inP2.ParameterName = "P2"
            inP2.Direction = ParameterDirection.Input
            inP2.Value = strPara2
            cmd.Parameters.Add(inP2)

            Dim inP3 As OracleParameter = New OracleParameter
            inP3.ParameterName = "P3"
            inP3.Direction = ParameterDirection.Input
            inP3.Value = strPara3
            cmd.Parameters.Add(inP3)

            Dim inP4 As OracleParameter = New OracleParameter
            inP4.ParameterName = "P4"
            inP4.Direction = ParameterDirection.Input
            inP4.Value = strPara4
            cmd.Parameters.Add(inP4)

            Dim inP5 As OracleParameter = New OracleParameter
            inP5.ParameterName = "P5"
            inP5.Direction = ParameterDirection.Input
            inP5.Value = strPara5
            cmd.Parameters.Add(inP5)

            Dim inP6 As OracleParameter = New OracleParameter
            inP6.ParameterName = "P6"
            inP6.Direction = ParameterDirection.Input
            inP6.Value = strPara6
            cmd.Parameters.Add(inP6)

            Dim outP7 As OracleParameter = New OracleParameter
            outP7.ParameterName = "P7"
            outP7.Direction = ParameterDirection.Output
            outP7.Value = lngPara7
            cmd.Parameters.Add(outP7)

            Dim outP8 As OracleParameter = New OracleParameter
            outP8.ParameterName = "P8"
            outP8.Direction = ParameterDirection.Output
            outP8.Value = lngPara8
            cmd.Parameters.Add(outP8)

            Dim outP9 As OracleParameter = New OracleParameter
            outP9.ParameterName = "P9"
            outP9.Direction = ParameterDirection.Output
            outP9.Value = strPara9
            cmd.Parameters.Add(outP9)

            inP1.OracleDbType = OracleDbType.Char
            inP2.OracleDbType = OracleDbType.Char
            inP3.OracleDbType = OracleDbType.Char
            inP4.OracleDbType = OracleDbType.Char
            inP5.OracleDbType = OracleDbType.Char
            inP6.OracleDbType = OracleDbType.Char
            outP7.OracleDbType = OracleDbType.Decimal
            outP8.OracleDbType = OracleDbType.Decimal
            outP9.OracleDbType = OracleDbType.Varchar2

            'PL/SQL呼び出しSQL
            cmd.CommandText = "CNT_USR1.PRC_EXCTBZ_2"

            '2019/10/09 CHG END

            'DBアクセス
            '2019/10/09 CHG START
            'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
            'If bolRet = False Then
            '    GoTo AE_Execute_PLSQL_EXCTBZ_2_END
            'End If
            cmd.ExecuteNonQuery()
            '2019/10/09 CHG END

            '** 戻り値取得
            '2019/10/09 CHG START
            ''UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'lngPara7 = param(7).Value
            ''UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'lngPara8 = param(8).Value
            ''UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'If IsDbNull(param(9).Value) = False Then
            '    'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    strPara9 = param(9).Value
            '    pot_strMsg = strPara9
            'End If

            lngPara7 = outP7.Value.ToString

            lngPara8 = outP8.Value.ToString

            If IsDBNull(outP9.Value.ToString) = False Then
                strPara9 = outP9.Value.ToString
                pot_strMsg = strPara9
            End If

            '2019/10/09 CHG END

            'エラー情報設定
            gv_Int_OraErr = lngPara8
            gv_Str_OraErrText = strPara9

            AE_Execute_PLSQL_EXCTBZ_2 = lngPara7

            '2019/10/09 CHG START
            'AE_Execute_PLSQL_EXCTBZ_2_END: 
            ''** パラメタ解消
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P1")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P2")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P3")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P4")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P5")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P6")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P7")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P8")
            ''UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'gv_Odb_USR1.Parameters.Remove("P9")

            cmd.Parameters.Clear()

            '2019/10/09 CHG END

            '2019/10/09 ADD START
        Catch ex As Exception
            MsgBox("AE_Execute_PLSQL_EXCTBZ_2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
        '2019/10/09 ADD END

    End Function
	' add 20170616 end
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module