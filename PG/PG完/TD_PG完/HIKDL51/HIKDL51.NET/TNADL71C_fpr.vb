Option Strict Off
Option Explicit On
Module SSSMAIN0005
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	'Public PP_SSSMAIN As clsPP
	'Public CP_SSSMAIN(1242 + 40 + 0 + 1) As clsCP
	'Public CQ_SSSMAIN(82) As String
	
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	
	Public Structure TNADL71C_DSP_DATA
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim STKDLVDT As String '入出庫日
		Dim DLVSU As Decimal '出庫
		Dim HIKSU As Decimal '引当
		Dim JOTAI As String '状態
		Dim STKSU As Decimal '入庫
		Dim SZAISU As Decimal '推定
		Dim DENDT As String '登録日
		Dim SBNNO As String '製番
		Dim TOKRN As String '得意先
		Dim SOUNM As String '倉庫
		Dim TOKJDNNO As String '客先注文番号
	End Structure
	
	'画面編集情報退避用
	Public TNADL71C_DSP_DATA_Inf As TNADL71C_DSP_DATA
	Public TNADL71C_DSP_DATA_Clr As TNADL71C_DSP_DATA
	
	'画面パラメータ退避用
	Public TNADL71C_HINCD As String
	Public TNADL71C_HINNMA As String
	Public TNADL71C_HINNMB As String
	Public TNADL71C_STKDLVDT As String
	Public TNADL71C_DLVSU As Decimal
	Public TNADL71C_HIKSU As Decimal
	Public TNADL71C_JOTAI As String
	Public TNADL71C_STKSU As Decimal
	Public TNADL71C_SZAISU As Decimal
	Public TNADL71C_DENDT As String
	Public TNADL71C_SBNNO As String
	Public TNADL71C_TOKRN As String
	Public TNADL71C_SOUNM As String
	Public TNADL71C_TOKJDNNO As String
	Public TNADL71C_TRAKB As String
	Public TNADL71C_JDNNO As String
	Public TNADL71C_MITNO As String
	Public TNADL71C_MITNOV As String
	Public TNADL71C_LINNO As String
	
	'**ﾁｪｯｸ関数関連 Start **
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
                '20190703 CHG START
                '            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '20190703 CHG END
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
            '20190703 CHG START
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190703 CHG END
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
                    '20190703 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    '' === 20060823 === UPDATE E -
                    ''編集後のSelLengthを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)
                    '20190703 CHG END

                    ' === 20060823 === INSERT S - ACE)Nagasawa １桁項目で入力後にフォーカス移動しないことへの対応
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
                            '20190704=3 CHG START
                            '                     'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            ''編集後のSelLengthを決定
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '20190703 CHG END
                            '現在ﾌｫｰｶｽ位置から右へ移動
                            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060823 === INSERT E
					
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
									'｢−｣入力時
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
                                    '20190703 CHG START
                                    '                           'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '                           pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''編集後のSelLengthを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '20190703 CHG END
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
                        '20190703 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190703 CHG END

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
                                '20190703 CHG START
                                '                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '                        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '20190703 CHG END

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
									'｢−｣入力時
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
                        '20190703 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190703 CHG END

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
                                '20190703 CHG START
                                '                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '                        pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '20190703 CHG END

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
                        '20190703 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190703 CHG END

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
				Wk_Index = CShort(FR_SSSSUB03.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
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
		
		'画面色設定
		Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
		
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
	'   名称：  Function Init_Clr_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
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
					'画面色設定
					Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
					
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
							'画面色設定
							Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
							
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
					Exit For
				End If
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					If bolDsp = False Then
						'画面編集
						'''''Call F_DSP_BD_Inf(pm_Dsp_Sub_Inf, DSP_SET, pm_All)
						'【※注意※】強引に、ｲﾝﾃﾞｯｸｽをフッタ部の頭にジャンプさせている。
						'ループ回数減のため。明細に入力項目がないから可能。
						Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx
						
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
            '20190703 CHG START
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190703 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '１文字目を選択する
                    '20190703 CHG START
                    '               'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '20190703 CHG END
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
                        '20190703 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190703 CHG END
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
            '20190703 CHG START
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190703 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '最終文字を選択する
                    '20190703 CHG START
                    '               'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '20190703 CHG END
                Else
                    '詰文字が左詰以外の場合
                    '１桁目を選択する
                    '20190703 CHG START
                    '               'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '20190703 CHG END
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
                            '20190703 CHG START
                            '                     'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '20190703 CHG END
                        Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '一番右へ移動し選択なし状態に
                                '20190703 CHG START
                                '                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '                        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '20190703 CHG END
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
                            '20190703 CHG START
                            '                     'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '20190703 CHG END
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
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'画面色設定
						Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
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
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
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
						'画面色設定
						Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
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
			
		Next 
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
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
			Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All, SET_FLG_DEF)
			
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
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'全体初期化の場合
			If Wk_Mode = BODY_ALL_CLR Then
				'全行初期状態
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'個別初期化
			'以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
			'(対象の明細の番号情報だけが必要、)
			Wk_Index = CShort(FR_SSSSUB03.BD_TRAKB(Index_Bd_Wk).Tag)
			'Dsp_Body_Infの行ＮＯに変換
			Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'Dsp_Body_Infに値を初期値を設定
			Call F_Init_Dsp_Body(Wk_Row, pm_All)
			
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
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
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
	'   名称：  Function F_Ctl_Upd_Process
	'   概要：  更新メインルーチン
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
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

        '@基本入力内容のチェック

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

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_OK

        F_Ctl_Head_Chk = Rtn_Chk

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSP_BD_Inf_SUB
    '   概要：  ボディ部編集_サブ照会画面用
    '   引数：　なし
    '   戻値：　処理ステータス
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_DSP_BD_Inf_SUB(ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short

        Dim strCode1 As String
        Dim strCode2 As String
        Dim strCode3 As String
        Dim strCode4 As String
        Dim strCode5 As String
        Dim strCode6 As String
        Dim strCode7 As String
        Dim strCode8 As String
        Dim intCnt As Short
        Dim intRet As Short

        Dim Trg_Index As Short

        If pm_Mode = DSP_SET Then
            '表示
            '受け渡しパラメータを変数にセット
            strCode1 = TNADL71C_TRAKB
            strCode2 = TNADL71C_JDNNO
            strCode3 = TNADL71C_MITNO
            strCode4 = TNADL71C_MITNOV
            strCode5 = TNADL71C_SBNNO
            strCode6 = TNADL71C_STKDLVDT
            strCode7 = TNADL71C_HINCD
            strCode8 = TNADL71C_LINNO

            'データ取得
            intCnt = F_GET_BD_DATA(strCode1, strCode2, strCode3, strCode4, strCode5, strCode6, strCode7, strCode8, TNADL71C_DSP_DATA_Inf, pm_All)

            If intCnt > 0 Then
                'データ編集
                intRet = F_SET_BD_DATA(TNADL71C_DSP_DATA_Inf, pm_All, intCnt)
            End If

        End If


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_GET_BD_DATA
    '   概要：  ボディ部データ取得
    '   引数：　pm_strCode1           :ｺｰﾄﾞ1
    '           pm_All                :全構造体
    '   戻値：　取得行数
    '   備考：  プログラム単位の共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_GET_BD_DATA(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_strCode3 As String, ByRef pm_strCode4 As String, ByRef pm_strCode5 As String, ByRef pm_strCode6 As String, ByRef pm_strCode7 As String, ByRef pm_strCode8 As String, ByRef pm_TNADL71C_DSP_DATA As TNADL71C_DSP_DATA, ByRef pm_All As Cls_All) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim intMode As Short
        Dim intCnt As Short
        Dim intIdx As Short
        Dim Wk_Index As Short
        Dim TNADL71C_DSP_DATA_Clr As TNADL71C_DSP_DATA

        On Error GoTo ERR_F_GET_BD_DATA

        F_GET_BD_DATA = -1

        '初期化
        'UPGRADE_WARNING: オブジェクト pm_TNADL71C_DSP_DATA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pm_TNADL71C_DSP_DATA = TNADL71C_DSP_DATA_Clr

        '検索ＳＱＬ生成
        strSQL = F_GET_DTLTRA_SQL(pm_strCode1, pm_strCode2, pm_strCode3, pm_strCode4, pm_strCode5, pm_strCode6, pm_strCode7, pm_strCode8)

        'DBアクセス
        '20190703 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    '取得データなし（つまり、すべて対象外）
        '    F_GET_BD_DATA = 0
        '    'メッセージ表示
        '    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTNADL71_E_001, pm_All)

        '    Exit Function
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '取得データなし（つまり、すべて対象外）
            F_GET_BD_DATA = 0
            'メッセージ表示
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTNADL71_E_001, pm_All)

            Exit Function
        End If
        '20190703 CHG END

        With pm_TNADL71C_DSP_DATA

            'ヘッダ（パラメータより取得）
            .HINCD = TNADL71C_HINCD '製品コード
            .HINNMA = TNADL71C_HINNMA '型式
            .HINNMB = TNADL71C_HINNMB '商品名１
            .STKDLVDT = TNADL71C_STKDLVDT '入出庫日
            .DLVSU = TNADL71C_DLVSU '出庫
            .HIKSU = TNADL71C_HIKSU '引当
            .JOTAI = TNADL71C_JOTAI '状態
            .STKSU = TNADL71C_STKSU '入庫
            .SZAISU = TNADL71C_SZAISU '推定
            .DENDT = TNADL71C_DENDT '登録日
            .SBNNO = TNADL71C_SBNNO '製番
            .TOKRN = TNADL71C_TOKRN '得意先
            .SOUNM = TNADL71C_SOUNM '倉庫
            .TOKJDNNO = TNADL71C_TOKJDNNO '客先注文番号

        End With

        If dt.Rows.Count > 0 Then

            intCnt = 0
            '20190703 CHG START
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            '    intCnt = intCnt + 1

            '    '行追加
            '    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
            '    '行項目情報コピー
            '    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))

            '    With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)

            '        '(6.)
            '        .Bus_Inf.SUB3_IsDataRow = True
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_TRAKB = CF_Ora_GetDyn(Usr_Ody, "TRAKB", "") '種別
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_TRANO = CF_Ora_GetDyn(Usr_Ody, "TRANO", "") '製番
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_TRADT = CF_Ora_GetDyn(Usr_Ody, "TRADT", "") '入出庫日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_SYUSU = CF_Ora_GetDyn(Usr_Ody, "SYUSU", 0) '出庫
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_HIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0) '引当
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_ATMNKB = CF_Ora_GetDyn(Usr_Ody, "ATMNKB", "") '自／手
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_NYUSU = CF_Ora_GetDyn(Usr_Ody, "NYUSU", 0) '入庫
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "") '営業部門
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Bus_Inf.SUB3_SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '倉庫

            '        '(7.)
            '        '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
            '        Wk_Index = CShort(FR_SSSSUB03.BD_TRAKB(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRAKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_TRANO(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRANO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_TRADT(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRADT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_SYUSU(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_SYUSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_HIKSU(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_ATMNKB(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_ATMNKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_NYUSU(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_NYUSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_TOKRN(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TOKRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_BUMNM(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_BUMNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
            '        Wk_Index = CShort(FR_SSSSUB03.BD_SOUNM(1).Tag)
            '        Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)

            '    End With

            '    '次レコード
            '    Call CF_Ora_MoveNext(Usr_Ody)
            'Loop
            For i As Integer = 0 To dt.Rows.Count
                intCnt = intCnt + 1

                '行追加
                ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
                '行項目情報コピー
                Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))

                With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)

                    '(6.)
                    .Bus_Inf.SUB3_IsDataRow = True
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_TRAKB = DB_NullReplace(dt.Rows(i)("TRAKB"), "") '種別
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_TRANO = DB_NullReplace(dt.Rows(i)("TRANO"), "") '製番
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_TRADT = DB_NullReplace(dt.Rows(i)("TRADT"), "") '入出庫日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_SYUSU = DB_NullReplace(dt.Rows(i)("SYUSU"), 0) '出庫
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_HIKSU = DB_NullReplace(dt.Rows(i)("HIKSU"), 0) '引当
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_ATMNKB = DB_NullReplace(dt.Rows(i)("ATMNKB"), "") '自／手
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_NYUSU = DB_NullReplace(dt.Rows(i)("NYUSU"), 0) '入庫
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_TOKRN = DB_NullReplace(dt.Rows(i)("TOKRN"), "") '得意先
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_BUMNM = DB_NullReplace(dt.Rows(i)("BUMNM"), "") '営業部門
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .Bus_Inf.SUB3_SOUNM = DB_NullReplace(dt.Rows(i)("SOUNM"), "") '倉庫

                    '(7.)
                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
                    Wk_Index = CShort(FR_SSSSUB03.BD_TRAKB(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRAKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_TRANO(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRANO, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_TRADT(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TRADT, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_SYUSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_SYUSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_HIKSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_HIKSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_ATMNKB(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_ATMNKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_NYUSU(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_NYUSU, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_TOKRN(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_TOKRN, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_BUMNM(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_BUMNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)
                    Wk_Index = CShort(FR_SSSSUB03.BD_SOUNM(1).Tag)
                    Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SUB3_SOUNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All)

                End With

            Next
            '20190703 CHG END

            '行情報の配列は、最低、画面表示明細数分必要
            '（満たない場合、CF_Body_Dsp にてエラーが発生する）
            'なので、ここで配列の Redim を行う
            If intCnt < pm_All.Dsp_Base.Dsp_Body_Cnt Then
                '行追加
                ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
                For intIdx = intCnt + 1 To pm_All.Dsp_Base.Dsp_Body_Cnt
                    '行項目情報コピー
                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
                    pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Bus_Inf.SUB_IsDataRow = False
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
	Private Function F_SET_BD_DATA(ByRef pm_TNADL71C_DSP_DATA As TNADL71C_DSP_DATA, ByRef pm_All As Cls_All, ByRef pm_intCnt As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		F_SET_BD_DATA = 9
		
		'■ヘッダ部
		With pm_TNADL71C_DSP_DATA
			'【製品コード】
			Trg_Index = CShort(FR_SSSSUB03.HD_HINCD.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【型式】
			Trg_Index = CShort(FR_SSSSUB03.HD_HINNMA.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【商品名１】
			Trg_Index = CShort(FR_SSSSUB03.HD_HINNMB.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HINNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【入出庫日】
			Trg_Index = CShort(FR_SSSSUB03.HD_STKDLVDT.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.STKDLVDT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【出庫】
			Trg_Index = CShort(FR_SSSSUB03.HD_DLVSU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.DLVSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【引当】
			Trg_Index = CShort(FR_SSSSUB03.HD_HIKSU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.HIKSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【状態】
			Trg_Index = CShort(FR_SSSSUB03.HD_JOTAI.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.JOTAI, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【入庫】
			Trg_Index = CShort(FR_SSSSUB03.HD_STKSU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.STKSU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【推定】
			Trg_Index = CShort(FR_SSSSUB03.HD_SZAISU.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.SZAISU, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【登録日】
			Trg_Index = CShort(FR_SSSSUB03.HD_DENDT.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.DENDT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【製番】
			Trg_Index = CShort(FR_SSSSUB03.HD_SBNNO.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.SBNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【得意先】
			Trg_Index = CShort(FR_SSSSUB03.HD_TOKRN.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【倉庫】
			Trg_Index = CShort(FR_SSSSUB03.HD_SOUNM.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.SOUNM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'【客先注文番号】
			Trg_Index = CShort(FR_SSSSUB03.HD_TOKJDNNO.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(.TOKJDNNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
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
		
		'画面色設定
		Call SSSMAIN0005.CF_Set_BD_Color(pm_All)
		
		F_SET_BD_DATA = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_DTLTRA_SQL
	'   概要：  引当内訳取得ＳＱＬ生成
	'   引数：　pm_strCode1           :ｺｰﾄﾞ1
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_DTLTRA_SQL(ByRef pm_strCode1 As String, ByRef pm_strCode2 As String, ByRef pm_strCode3 As String, ByRef pm_strCode4 As String, ByRef pm_strCode5 As String, ByRef pm_strCode6 As String, ByRef pm_strCode7 As String, ByRef pm_strCode8 As String) As String
		
		Dim strSQL As String
		
		'データ区分によって検索SQL変更
		
		Select Case pm_strCode1
			'受注
			Case "1"
				'検索ＳＱＬ発行
				strSQL = ""
				strSQL = strSQL & " SELECT"
				strSQL = strSQL & " DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,'実在庫','入庫予定') As TRAKB"
				strSQL = strSQL & " ,DTL.LOTNO    As TRANO"
				strSQL = strSQL & " ,DTL.TRADT    As TRADT"
				strSQL = strSQL & " ,0            As SYUSU"
				strSQL = strSQL & " ,DTL.HIKSU    As HIKSU"
				strSQL = strSQL & " ,DECODE(DTL.ATMNKB,'A','自動','手動') As ATMNKB"
				strSQL = strSQL & " ,DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,HIN.RELZAISU,INP.INPSU - INP.INPSMSU) As NYUSU"
				strSQL = strSQL & " ,''           As TOKRN"
				strSQL = strSQL & " ,''           As BUMNM"
				strSQL = strSQL & " ,SOU.SOUNM  As SOUNM"
				strSQL = strSQL & " From"
				strSQL = strSQL & " DTLTRA DTL"
				strSQL = strSQL & " ,(SELECT * FROM INPTRA WHERE DATKB = '1') INP"
				strSQL = strSQL & " ,(SELECT HINCD, SOUCD, RELZAISU FROM HINMTB WHERE DATKB = '1') HIN"
				strSQL = strSQL & " ,(SELECT SOUCD, SOUNM FROM SOUMTA WHERE DATKB = '1') SOU"
				strSQL = strSQL & " Where"
				strSQL = strSQL & " DTL.TRAKB  = '2' "
				strSQL = strSQL & " And DTL.TRANO  = '" & pm_strCode2 & "' "
				strSQL = strSQL & " And DTL.MITNOV = '" & pm_strCode4 & "' "
				strSQL = strSQL & " And DTL.LINNO = '" & pm_strCode8 & "' "
				strSQL = strSQL & " And DTL.TRADT = '" & pm_strCode6 & "' "
				strSQL = strSQL & " And DTL.HINCD = '" & pm_strCode7 & "' "
				strSQL = strSQL & " And DTL.HINCD = INP.HINCD(+) "
				strSQL = strSQL & " And DTL.INPYTDT = INP.INPYTDT(+) "
				strSQL = strSQL & " And DTL.LOTNO = INP.LOTNO(+) "
				strSQL = strSQL & " And DTL.HINCD = HIN.HINCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = HIN.SOUCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = SOU.SOUCD(+) "
				'見積
			Case "2"
				'検索ＳＱＬ発行
				strSQL = ""
				strSQL = strSQL & " SELECT"
				strSQL = strSQL & " DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,'実在庫','入庫予定') As TRAKB"
				strSQL = strSQL & " ,DTL.LOTNO    As TRANO"
				strSQL = strSQL & " ,DTL.TRADT    As TRADT"
				strSQL = strSQL & " ,0            As SYUSU"
				strSQL = strSQL & " ,DTL.HIKSU    As HIKSU"
				strSQL = strSQL & " ,DECODE(DTL.ATMNKB,'A','自動','手動') As ATMNKB"
				strSQL = strSQL & " ,DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,HIN.RELZAISU,INP.INPSU - INP.INPSMSU) As NYUSU"
				strSQL = strSQL & " ,''           As TOKRN"
				strSQL = strSQL & " ,''           As BUMNM"
				strSQL = strSQL & " ,SOU.SOUNM  As SOUNM"
				strSQL = strSQL & " From"
				strSQL = strSQL & " DTLTRA DTL"
				strSQL = strSQL & " ,(SELECT * FROM INPTRA WHERE DATKB = '1') INP"
				strSQL = strSQL & " ,(SELECT HINCD, SOUCD, RELZAISU FROM HINMTB WHERE DATKB = '1') HIN"
				strSQL = strSQL & " ,(SELECT SOUCD, SOUNM FROM SOUMTA WHERE DATKB = '1') SOU"
				strSQL = strSQL & " Where"
				strSQL = strSQL & " DTL.TRAKB  = '1' "
				strSQL = strSQL & " And DTL.TRANO  = '" & pm_strCode3 & "' "
				strSQL = strSQL & " And DTL.MITNOV = '" & pm_strCode4 & "' "
				strSQL = strSQL & " And DTL.LINNO = '" & pm_strCode8 & "' "
				strSQL = strSQL & " And DTL.TRADT = '" & pm_strCode6 & "' "
				strSQL = strSQL & " And DTL.HINCD = '" & pm_strCode7 & "' "
				strSQL = strSQL & " And DTL.HINCD = INP.HINCD(+) "
				strSQL = strSQL & " And DTL.INPYTDT = INP.INPYTDT(+) "
				strSQL = strSQL & " And DTL.LOTNO = INP.LOTNO(+) "
				strSQL = strSQL & " And DTL.HINCD = HIN.HINCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = HIN.SOUCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = SOU.SOUCD(+) "
				'支給
			Case "3"
				'検索ＳＱＬ発行
				strSQL = ""
				strSQL = strSQL & " SELECT"
				strSQL = strSQL & " DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,'実在庫','入庫予定') As TRAKB"
				strSQL = strSQL & " ,DTL.LOTNO    As TRANO"
				strSQL = strSQL & " ,DTL.TRADT    As TRADT"
				strSQL = strSQL & " ,0            As SYUSU"
				strSQL = strSQL & " ,DTL.HIKSU    As HIKSU"
				strSQL = strSQL & " ,DECODE(DTL.ATMNKB,'A','自動','手動') As ATMNKB"
				strSQL = strSQL & " ,DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,HIN.RELZAISU,INP.INPSU - INP.INPSMSU) As NYUSU"
				strSQL = strSQL & " ,''           As TOKRN"
				strSQL = strSQL & " ,''           As BUMNM"
				strSQL = strSQL & " ,SOU.SOUNM  As SOUNM"
				strSQL = strSQL & " From"
				strSQL = strSQL & " DTLTRA DTL"
				strSQL = strSQL & " ,(SELECT * FROM INPTRA WHERE DATKB = '1') INP"
				strSQL = strSQL & " ,(SELECT HINCD, SOUCD, RELZAISU FROM HINMTB WHERE DATKB = '1') HIN"
				strSQL = strSQL & " ,(SELECT SOUCD, SOUNM FROM SOUMTA WHERE DATKB = '1') SOU"
				strSQL = strSQL & " Where"
				strSQL = strSQL & " DTL.TRAKB  = '3' "
				strSQL = strSQL & " And DTL.TRANO  = '" & pm_strCode5 & "' "
				strSQL = strSQL & " And DTL.MITNOV = '" & pm_strCode4 & "' "
				strSQL = strSQL & " And DTL.LINNO = '" & pm_strCode8 & "' "
				strSQL = strSQL & " And DTL.TRADT = '" & pm_strCode6 & "' "
				strSQL = strSQL & " And DTL.HINCD = '" & pm_strCode7 & "' "
				strSQL = strSQL & " And DTL.HINCD = INP.HINCD(+) "
				strSQL = strSQL & " And DTL.INPYTDT = INP.INPYTDT(+) "
				strSQL = strSQL & " And DTL.LOTNO = INP.LOTNO(+) "
				strSQL = strSQL & " And DTL.HINCD = HIN.HINCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = HIN.SOUCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = SOU.SOUCD(+) "
				'入荷
			Case "4"
				'検索ＳＱＬ発行
				strSQL = ""
				strSQL = strSQL & " SELECT"
				strSQL = strSQL & " DECODE(DTL.TRAKB,'1'"
				strSQL = strSQL & " ,'見積',DECODE(DTL.TRAKB,'2'"
				strSQL = strSQL & " ,'受注',DECODE(DTL.TRAKB,'3'"
				strSQL = strSQL & " ,'支給',DECODE(DTL.TRAKB,'4'"
				strSQL = strSQL & " ,'製番','')))) As TRAKB"
				strSQL = strSQL & " ,DECODE(DTL.TRAKB,'1'"
				strSQL = strSQL & " ,TRIM(DTL.TRANO) || '-' || TRIM(DTL.MITNOV) || '-' || SUBSTR(TRIM(DTL.LINNO),2,2),DECODE(DTL.TRAKB,'2'"
				strSQL = strSQL & " ,JDN.SBNNO,DECODE(DTL.TRAKB,'3'"
				strSQL = strSQL & " ,DTL.TRANO,DECODE(DTL.TRAKB,'4'"
				strSQL = strSQL & " ,DTL.TRANO,'')))) As TRANO"
				strSQL = strSQL & " ,DTL.TRADT    As TRADT"
				strSQL = strSQL & " ,DECODE(DTL.TRAKB,'1'"
				strSQL = strSQL & " ,MIT.MITSU,DECODE(DTL.TRAKB,'2'"
				strSQL = strSQL & " ,JDN.UODSU - JDN.OTPSU,DECODE(DTL.TRAKB,'3'"
				strSQL = strSQL & " ,SKY.OUTYOTSU - SKY.FRDSU,DECODE(DTL.TRAKB,'4'"
				strSQL = strSQL & " ,SBN.FRDYTSU - SBN.OUTSMSU,'')))) As SYUSU"
				strSQL = strSQL & " ,DTL.HIKSU    As HIKSU"
				strSQL = strSQL & " ,DECODE(DTL.ATMNKB,'A','自動','手動') As ATMNKB"
				strSQL = strSQL & " ,0            As NYUSU"
				strSQL = strSQL & " ,DECODE(DTL.TRAKB,'1'"
				strSQL = strSQL & " ,MITM.TOKRN,DECODE(DTL.TRAKB,'2'"
				strSQL = strSQL & " ,JDNM.TOKRN,DECODE(DTL.TRAKB,'3'"
				strSQL = strSQL & " ,'',DECODE(DTL.TRAKB,'4'"
				strSQL = strSQL & " ,SBN.TOKRN,'')))) As TOKRN"
				strSQL = strSQL & " ,DECODE(DTL.TRAKB,'1'"
				strSQL = strSQL & " ,MITM.BUMNM,DECODE(DTL.TRAKB,'2'"
				strSQL = strSQL & " ,JDNM.BUMNM,DECODE(DTL.TRAKB,'3'"
				strSQL = strSQL & " ,'',DECODE(DTL.TRAKB,'4'"
				strSQL = strSQL & " ,'','')))) As BUMNM"
				strSQL = strSQL & " ,SOU.SOUNM  As SOUNM"
				strSQL = strSQL & " From"
				strSQL = strSQL & " DTLTRA DTL"
				strSQL = strSQL & " ,(SELECT * FROM MITTRA WHERE DATKB = '1') MIT"
				strSQL = strSQL & " ,(SELECT * FROM MITTHA WHERE DATKB = '1') MITM"
				'            strSQL = strSQL & " ,(SELECT * FROM JDNTRA WHERE DATKB = '1') JDN"
				strSQL = strSQL & " ,(SELECT JDNNO,LINNO,SBNNO,MAX(DATNO) AS DATNO,SUM(UODSU) AS UODSU,SUM(OTPSU) AS OTPSU FROM JDNTRA WHERE DATKB = '1' GROUP BY JDNNO,LINNO,SBNNO) JDN"
				'            strSQL = strSQL & " ,(SELECT * FROM JDNTHA WHERE DATKB = '1') JDNM"
				strSQL = strSQL & " ,(SELECT JDNNO,MAX(DATNO) AS DATNO,MAX(TOKRN) AS TOKRN,MAX(BUMNM) AS BUMNM FROM JDNTHA WHERE DATKB = '1' GROUP BY JDNNO) JDNM"
				strSQL = strSQL & " ,(SELECT * FROM SKYTBL WHERE DATKB = '1') SKY"
				strSQL = strSQL & " ,(SELECT * FROM SBNTRA WHERE DATKB = '1') SBN"
				strSQL = strSQL & " ,(SELECT SOUCD, SOUNM FROM SOUMTA WHERE DATKB = '1') SOU"
				strSQL = strSQL & " Where"
				strSQL = strSQL & " DTL.HINCD  = '" & pm_strCode7 & "' "
				strSQL = strSQL & " And DTL.LOTNO  = '" & pm_strCode5 & "' "
				' === 20160106 === UPDATE S -
				'            strSQL = strSQL & " And DTL.INPYTDT = '" & pm_strCode6 & "' "
				strSQL = strSQL & " And DTL.INPYTDT = (SELECT MIN(INPYTDT) FROM INPTRA WHERE DATKB = '1' AND HINCD = '" & pm_strCode7 & "' AND LOTNO = '" & pm_strCode5 & "' AND INPYTDT >= '" & pm_strCode6 & "')"
				' === 20160106 === UPDATE E -
				strSQL = strSQL & " And DTL.TRANO = MIT.MITNO(+) "
				strSQL = strSQL & " And DTL.MITNOV = MIT.MITNOV(+) "
				strSQL = strSQL & " And DTL.LINNO = MIT.LINNO(+) "
				strSQL = strSQL & " And DTL.TRANO = MITM.MITNO(+) "
				strSQL = strSQL & " And DTL.MITNOV = MITM.MITNOV(+) "
				strSQL = strSQL & " And DTL.TRANO = JDN.JDNNO(+) "
				strSQL = strSQL & " And DTL.LINNO = JDN.LINNO(+) "
				strSQL = strSQL & " And DTL.TRANO = JDNM.JDNNO(+) "
				strSQL = strSQL & " And DTL.TRANO = SKY.SBNNO(+) "
				strSQL = strSQL & " And DTL.HINCD = SKY.HINCD(+) "
				strSQL = strSQL & " And DTL.HINCD = SBN.HINCD(+) "
				strSQL = strSQL & " And DTL.PUDLNO = SBN.PUDLNO(+) "
				strSQL = strSQL & " And DTL.SOUCD = SOU.SOUCD(+) "
				'製番出庫
			Case "5"
				'検索ＳＱＬ発行
				strSQL = ""
				strSQL = strSQL & " SELECT"
				strSQL = strSQL & " DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,'実在庫','入庫予定') As TRAKB"
				strSQL = strSQL & " ,DTL.LOTNO    As TRANO"
				strSQL = strSQL & " ,DTL.TRADT    As TRADT"
				strSQL = strSQL & " ,0            As SYUSU"
				strSQL = strSQL & " ,DTL.HIKSU    As HIKSU"
				strSQL = strSQL & " ,DECODE(DTL.ATMNKB,'A','自動','手動') As ATMNKB"
				strSQL = strSQL & " ,DECODE(DTL.LOTNO,'                    '"
				strSQL = strSQL & " ,HIN.RELZAISU,INP.INPSU - INP.INPSMSU) As NYUSU"
				strSQL = strSQL & " ,''           As TOKRN"
				strSQL = strSQL & " ,''           As BUMNM"
				strSQL = strSQL & " ,SOU.SOUNM  As SOUNM"
				strSQL = strSQL & " From"
				strSQL = strSQL & " DTLTRA DTL"
				strSQL = strSQL & " ,(SELECT * FROM INPTRA WHERE DATKB = '1') INP"
				strSQL = strSQL & " ,(SELECT HINCD, SOUCD, RELZAISU FROM HINMTB WHERE DATKB = '1') HIN"
				strSQL = strSQL & " ,(SELECT SOUCD, SOUNM FROM SOUMTA WHERE DATKB = '1') SOU"
				strSQL = strSQL & " Where"
				strSQL = strSQL & " DTL.TRAKB  = '4' "
				strSQL = strSQL & " And DTL.TRANO  = '" & pm_strCode5 & "' "
				strSQL = strSQL & " And DTL.MITNOV = '" & pm_strCode4 & "' "
				strSQL = strSQL & " And DTL.LINNO = '" & pm_strCode8 & "' "
				strSQL = strSQL & " And DTL.TRADT = '" & pm_strCode6 & "' "
				strSQL = strSQL & " And DTL.HINCD = '" & pm_strCode7 & "' "
				strSQL = strSQL & " And DTL.HINCD = INP.HINCD(+) "
				strSQL = strSQL & " And DTL.INPYTDT = INP.INPYTDT(+) "
				strSQL = strSQL & " And DTL.LOTNO = INP.LOTNO(+) "
				strSQL = strSQL & " And DTL.HINCD = HIN.HINCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = HIN.SOUCD(+) "
				strSQL = strSQL & " And DTL.SOUCD = SOU.SOUCD(+) "
				
		End Select
		
		F_GET_DTLTRA_SQL = strSQL
		
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
	'   名称：  Function F_Get_RoundKingk
	'   概要：  金額まるめ計算処理
	'   引数：　Pin_curKingk       :まるめ対象金額
	'           Pin_strRPSKB       :金額端数処理桁数（消費税端数処理桁数の場合
	'           Pin_strZRNKB       :金額端数処理区分
	'   戻値：  まるめ後金額
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_RoundKingk(ByRef Pin_curKingk As Decimal, ByRef pin_strRPSKB As String, ByRef pin_strZRNKB As String) As Decimal
		
		Dim curWk As Decimal
		
		curWk = Pin_curKingk
		
		Call AE_CalcRoundKingk(curWk, pin_strRPSKB, pin_strZRNKB)
		
		F_Get_RoundKingk = curWk
		
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
		' === 20060907 === UPDATE S - ACE)Sejima
		'D   FR_SSSMAIN.MousePointer = 11
		'D   FR_SSSMAIN.PrintForm
		'D   FR_SSSMAIN.MousePointer = 1
		' === 20060907 === UPDATE ↓
		FR_SSSSUB03.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form メソッド FR_SSSSUB03.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '20190703 DELL START
        'FR_SSSSUB03.PrintForm()
        '20190703 DELL END
        FR_SSSSUB03.Cursor = System.Windows.Forms.Cursors.Arrow
		' === 20060907 === UPDATE E
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
			
			With pm_All.Dsp_Sub_Inf(Index_Wk)
				If .Detail.Body_Index > 0 Then
					
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'奇数行は薄い水色、偶数行が灰色
					If Bd_Index Mod 2 = 1 Then
						.Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_PALEGREEN)
					End If
					
				End If
			End With
		Next 
		
	End Function

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
    '20190703 ADD START
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSSUB03, ByRef pm_All As Cls_All) As Short

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
    '20190703 ADD END
End Module