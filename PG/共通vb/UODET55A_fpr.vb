Option Strict Off
Option Explicit On
Module SSSMAIN0003
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'画面初期化フラグ
	Public gv_bolUODET55A_INIT As Boolean 'True:変更あり
	Public gv_bolUODET55A_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	Public gv_bolUODET55A_KeyFlg As Boolean
	' === 20061015 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
	Public gv_bolUODET55A_Locked As Boolean '画面ロックフラグ(True:ロックする)
	' === 20061015 === INSERT E -
	
	' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	Public gv_intZIPCD_KETA As Short '郵便番号桁数
	Public gv_intZIPCD_HAIHUN As Short '郵便番号ハイフン位置
	Public gv_intTLFAX_KETA As Short '電話番号/FAX番号の桁数
	Public gv_intTLFAX_HAIHUN As Short '電話番号/FAX番号のハイフン個数
	Public gv_intTLFAX_LSTNUM As Short '電話番号/FAX番号の最終ブロック文字数
	' === 20061224 === INSERT E -
	
	'納入先マスタ情報
	Public Structure UODET55A_TYPE_NHSMTA
		Dim DATKB As String '削除区分
		Dim NHSCD As String '納入先コード0          000000
		Dim NHSRN As String '納入先略称0
		Dim NHSNMA As String '納入先名称１
		Dim NHSNMB As String '納入先名称２
		Dim NHSADA As String '納入先住所１
		Dim NHSADB As String '納入先住所２
		Dim NHSADC As String '納入先住所３
		Dim NHSNMMKB As String '名称マニュアル入力区分(納入先)
		' === 20061014 === INSERT S - ACE)Nagasawa 納入先便名コード対応
		Dim BINCD As String '便名コード(開発場所)
		Dim BINNM As String '便名（開発場所）
		' === 20061014 === INSERT E -
		' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		Dim NHSZIPCD As String '納入先郵便番号
		Dim NHSTL As String '納入先電話番号
		Dim NHSFAX As String '納入先FAX番号
		Dim NHSFRNKB As String '納入先海外区分
		' === 20061224 === INSERT E -
	End Structure
	Public UODET55A_NHSMTA_Inf As UODET55A_TYPE_NHSMTA
	' === 20060901 === INSERT S - ACE)Sejima
	Public UODET55A_NHSMTA_Def As UODET55A_TYPE_NHSMTA
	' === 20060901 === INSERT E
	
	'メッセージコード
	Public Const gc_strMsgUODET55_E_101 As String = "2UODET55_101" '入力値が許容範囲外です。
	Public Const gc_strMsgUODET55_E_102 As String = "2UODET55_102" '削除済みレコードです。
	Public Const gc_strMsgUODET55_E_103 As String = "2UODET55_103" '該当するデータが存在しません。
	Public Const gc_strMsgUODET55_E_104 As String = "2UODET55_104" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgUODET55_E_105 As String = "2UODET55_105" '住所のみの入力はできません
	' === 20061013 === INSERT S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
	Public Const gc_strMsgUODET55_E_106 As String = "2UODET55_106" '住所を入力してください。
	' === 20061013 === INSERT E -
	' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	Public Const gc_strMsgUODET55_E_107 As String = "2UODET55_107" '桁数オーバーです。
	Public Const gc_strMsgUODET55_E_108 As String = "2UODET55_108" 'ハイフン個数の誤りです。
	Public Const gc_strMsgUODET55_E_109 As String = "2UODET55_109" 'ハイフンが先頭にあります。
	Public Const gc_strMsgUODET55_E_110 As String = "2UODET55_110" 'ハイフンが末尾にあります。
	Public Const gc_strMsgUODET55_E_111 As String = "2UODET55_111" 'ハイフンを連続して入力しています。
	Public Const gc_strMsgUODET55_E_112 As String = "2UODET55_112" '入力が不正です。
	Public Const gc_strMsgUODET55_E_113 As String = "2UODET55_113" 'ハイフンの位置が正しくありません。
	Public Const gc_strMsgUODET55_E_114 As String = "2UODET55_114" '桁数が正しくありません。
	Public Const gc_strMsgUODET55_E_115 As String = "2UODET55_115" '郵便番号を入力してください。
	Public Const gc_strMsgUODET55_E_116 As String = "2UODET55_116" '電話番号を入力してください。
	Public Const gc_strMsgUODET55_E_117 As String = "2UODET55_117" '見積用の諸口の納入先は入力できません。
	' === 20061224 === INSERT E -
	
	
	'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	
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
                '20190905 CHG START
                '            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                '            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '20190905 CHG END

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
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
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
            '20190905 CHG START
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190905 CHG END

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
                    '20190905 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
                    '' === 20060823 === UPDATE E -
                    ''編集後のSelLengthを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart + 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                    '20190905 CHG END

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
                            '20190905 CHG START
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            ''編集後のSelLengthを決定
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 0
                            '20190905 CHG END
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
                                    '20190905 CHG START
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''編集後のSelLengthを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                    '20190905 CHG END
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
                        '20190905 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '20190905 CHG END

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
                                '20190905 CHG START
                                '                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '                        pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Len(Wk_DspMoji)
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = 1
                                '20190905 CHG END

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
                        '20190905 CHG START
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '20190905 CHG END

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
                                '20190905 CHG START
                                '                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '                        pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                                '20190905 CHG END

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
                        '20190905 CHG START
                        '                  'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '                  pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart = Wk_SelStart
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength = Wk_SelLength
                        '20190905 CHG END

                        '20190905 ADD START
                    Case System.Windows.Forms.Keys.Return
                        pm_Move_Flg = True
                        pm_KeyAscii = 0
                        '20190905 ADD E N D

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
	
	'======================= 変更部分 2006.07.02 Start =================================
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
				Wk_Index = CShort(FR_SSSSUB01.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				' === 20060907 === INSERT S - ACE)Sejima
				bolSameCtl = True
				' === 20060907 === INSERT E
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
                '20190809 CHG START
                'FR_SSSSUB01.PopupMenu(FR_SSSSUB01.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSSUB01.SM_ShortCut.Show()
                '20190809 CHG END
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
	'======================= 変更部分 2006.07.02 End =================================
	
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'行を追加された後に
		'初期値を追加した行に対してループ内で１行ずつ行う
		'ここでの行は、Dsp_Body_Infの行！！
		For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
		Next 
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
						'======================= 変更部分 2006.07.02 Start =================================
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN、KEYDOWNの場合
							'======================= 変更部分 2006.07.02 End =================================
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
							'======================= 変更部分 2006.07.02 Start =================================
							'画面ボディ情報の配列を再設定
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							'======================= 変更部分 2006.07.02 End =================================
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
		
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				If gv_bolInit = False Then
					Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				Else
					Rtn_Chk = CHK_OK
				End If
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
					'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
					pm_Move_Flg = True
					'======================= 変更部分 2006.07.02 Start =================================
				Case NEXT_FOCUS_MODE_KEYRIGHT
					'KEYRIGHTの場合
					'検索開始項目で選択状態が移動する
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
				Case NEXT_FOCUS_MODE_KEYDOWN
					'KEYDOWNの場合
					'======================= 変更部分 2006.07.02 End =================================
					
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
            '20190809 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            '20190809 CHG END
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190809 CHG START
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            '20190809 CHG END
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190809 CHG START
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190809 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '１文字目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190809 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '20190809 CHG END
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
                        '20190809 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190809 CHG END
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
            '20190809 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190809 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '最終文字を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190809 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '20190809 CHG END
                Else
                    '詰文字が左詰以外の場合
                    '１桁目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190809 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '20190809 CHG END

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
                            '20190809 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '20190809 CHG END
                        Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '一番右へ移動し選択なし状態に
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '20190809 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '20190809 CHG END
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
                            '20190809 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '20190809 CHG END

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
	
	'======================= 変更部分 2006.07.02 Start =================================
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
	'======================= 変更部分 2006.07.02 End =================================
	
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
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
	'   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'画面明細の行と同一の明細をインデックスを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'移動先が同じ場合
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'項目色設定
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				
			Else
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細初期化
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細削除
		Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'行を追加された後に
		'初期値を追加した行に対してループ内で１行ずつ行う
		'ここでの行は、Dsp_Body_Infの行！！
		For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		Next 
		
		'行Ｎｏ採番処理
		Call F_Edi_Saiban_No(pm_All)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'画面表示
		Call CF_Body_Dsp(pm_All)
		
		'元の画面の行に移動
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'フォーカス決定
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細挿入
		If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'対象行を画面に表示
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			
			'追加行に移動
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細復元
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'行を追加された後に
			'初期値を追加した行に対してループ内で１行ずつ行う
			'ここでの行は、Dsp_Body_Infの行！！
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 Start =================================
	
	'======================= 変更部分 2006.07.02 Start =================================
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
        '20190809 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '20190809 CHG END
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
        '20190809 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        '編集後のSelLengthを決定
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '20190809 CHG END
        ' === 20061228 === INSERT S - ACE)Nagasawa
        '入力後の後処理
        Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		' === 20061228 === INSERT E -
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	'======================= 変更部分 2006.07.02 End =================================
	
	''======================= 変更部分 2006.06.26 Start =================================
	''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   名称：  Function F_Edi_Saiban_No
	'    '   概要：  全明細の行ＮＯを設定する
	'    '   引数：　なし
	'    '   戻値：　なし
	'    '   備考：  プログラム単位の処理
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Edi_Saiban_No(pm_All As Cls_All) As Integer
	'    Dim Wk_Index As Integer
	'    Dim Bd_Index As Integer
	'
	'    Wk_Index = CInt(FR_SSSSUB01.BD_LINNO(0).Tag)
	'    For Bd_Index = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
	'        '【ＮＯ】１・２～を編集
	'        '画面ボディ情報(pm_All.Dsp_Body_Inf)に編集
	'        Call CF_Edi_Dsp_Body_Inf(Bd_Index _
	''                               , pm_All.Dsp_Sub_Inf(Wk_Index) _
	''                               , Bd_Index _
	''                               , pm_All _
	''                               , SET_FLG_DEF)
	'    Next
	'
	'End Function
	''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	''======================= 変更部分 2006.06.26 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		'
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
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'        'Dsp_Body_Infの行ＮＯに変換
		'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'    Next
		'
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
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSCD.Tag)
		' === 20061015 === INSERT S - ACE)Nagasawa 受注訂正時の項目の入力可否制御の変更
		If gv_bolUODET55A_Locked = True Then
			Trg_Index = CShort(FR_SSSSUB01.HD_Cursol_Wk_1.Tag)
		End If
		' === 20061015 === INSERT E -
		
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
	'   名称：  Function F_Chk_HD_KHTBSCD
	'   概要：  開発場所コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_NHSMTA
		Dim Mst_Inf_BMNCD As TYPE_DB_NHSMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim Init_Inf As UODET55A_TYPE_NHSMTA
		' === 20061014 === INSERT S - ACE)Nagasawa 納入先便名コード対応
		Dim Mst_Inf_Bincd As TYPE_DB_MEIMTA
		' === 20061014 === INSERT E -
		' === 20061224 === INSERT S - ACE)Nagasawa
		Dim Mst_Inf_SKCHNHSCD As TYPE_DB_MEIMTA
		' === 20061224 === INSERT E -
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSCD = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
        pm_Chk_Move = True
        '20190809 CHG START
        'Call DB_NHSMTA_Clear(Mst_Inf)
        Call InitDataCommon("NHSMTA")
        '20190809 CHG END

        ' === 20060721 === DELETE S - ACE)Nagasawa
        '    UODET55A_NHSMTA_Inf = Init_Inf
        ' === 20060721 === DELETE E - ACE)Nagasawa

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Retn_Code = CHK_ERR_NOT_INPUT
			'UPGRADE_WARNING: オブジェクト UODET55A_NHSMTA_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UODET55A_NHSMTA_Inf = Init_Inf
			' === 20060721 === UPDATE E - ACE)Nagasawa
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'マスタチェック
				If DSPNHSCD_SEARCH(Input_Value, Mst_Inf) = 0 Then
					'論理削除チェック
					If Mst_Inf.DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_102 '削除済みデータ
					Else
						' === 20061224 === INSERT S - ACE)Nagasawa 見積用の諸口納入先はエラーとする
						If DSPMEIM_SEARCH(gc_strKEYCD_MITNHSCD, Input_Value, Mst_Inf_SKCHNHSCD) = 0 Then
							If Mst_Inf_SKCHNHSCD.DATKB = gc_strDATKB_USE Then
								Retn_Code = CHK_ERR_ELSE
								Err_Cd = gc_strMsgUODET55_E_117
								GoTo F_Chk_HD_KHTBSCD_End
							End If
						End If
						' === 20061224 === INSERT E -
						
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
						' === 20060721 === INSERT S - ACE)Nagasawa
						'UPGRADE_WARNING: オブジェクト UODET55A_NHSMTA_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						UODET55A_NHSMTA_Inf = Init_Inf
						' === 20060721 === INSERT E - ACE)Nagasawa
						UODET55A_NHSMTA_Inf.NHSCD = Mst_Inf.NHSCD '納入先コード
						UODET55A_NHSMTA_Inf.NHSNMA = Mst_Inf.NHSNMA '納入先名１
						UODET55A_NHSMTA_Inf.NHSNMB = Mst_Inf.NHSNMB '納入先名２
						UODET55A_NHSMTA_Inf.NHSADA = Mst_Inf.NHSADA '納入先住所１
						UODET55A_NHSMTA_Inf.NHSADB = Mst_Inf.NHSADB '納入先住所２
						UODET55A_NHSMTA_Inf.NHSADC = Mst_Inf.NHSADC '納入先住所３
						' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
						UODET55A_NHSMTA_Inf.NHSZIPCD = Mst_Inf.NHSZP '納入先郵便番号
						UODET55A_NHSMTA_Inf.NHSTL = Mst_Inf.NHSTL '納入先電話番号
						UODET55A_NHSMTA_Inf.NHSFAX = Mst_Inf.NHSFX '納入先FAX番号
						UODET55A_NHSMTA_Inf.NHSFRNKB = Mst_Inf.FRNKB '納入先FAX番号
						' === 20061224 === INSERT E -
						UODET55A_NHSMTA_Inf.NHSNMMKB = Mst_Inf.NHSNMMKB '名称マニュアル入力区分
						' === 20061014 === INSERT S - ACE)Nagasawa 納入先便名コード対応
						UODET55A_NHSMTA_Inf.BINCD = Mst_Inf.BINCD '便名コード
						
						'便名取得
						If DSPMEIM_SEARCH(gc_strKEYCD_BINCD, Mst_Inf.BINCD, Mst_Inf_Bincd) = 0 Then
							If Mst_Inf_Bincd.DATKB = gc_strDATKB_USE Then
								UODET55A_NHSMTA_Inf.BINNM = Mst_Inf_Bincd.MEINMA
							End If
						End If
						' === 20061014 === INSERT E -
					End If
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgUODET55_E_103 '該当データなし
				End If
			End If
		End If
		
		' === 20061224 === INSERT S - ACE)Nagasawa
F_Chk_HD_KHTBSCD_End: 
		' === 20061224 === INSERT E -
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSCD_Inf
	'   概要：  開発場所コードによる画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		
		If pm_Mode = DSP_SET Then
			'表示
			'開発場所コードが変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'【開発場所名１】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMA.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【開発場所名２】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSNMB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
				'【郵便番号】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSZIPCD.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSZIPCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【電話番号】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSTL.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSTL, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【FAX番号】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSFAX.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSFAX, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				' === 20061224 === INSERT E -
				
				'【住所１】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADA.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADA, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【住所２】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【住所３】
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADC.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(UODET55A_NHSMTA_Inf.NHSADC, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'** ｺﾝﾄﾛｰﾙ制御 **
				'【開発場所名】
				'名称ﾏﾆｭｱﾙ入力区分='1'の場合、納入先名は変更可
				If UODET55A_NHSMTA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
					Focus_Ctl = True
				Else
					Focus_Ctl = False
				End If
				
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMA.Tag)
				Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
				
				Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMB.Tag)
				Call CF_Set_Item_Focus_Ctl(Focus_Ctl, pm_All.Dsp_Sub_Inf(Trg_Index))
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'【開発場所名１】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMA.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【開発場所名２】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSNMB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
			'【郵便番号】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSZIPCD.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【電話番号】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSTL.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【FAX番号】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSFAX.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			' === 20061224 === INSERT E -
			
			'【住所１】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADA.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【住所２】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【住所３】
			Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADC.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.DATKB = UODET55A_NHSMTA_Def.DATKB
						.NHSCD = UODET55A_NHSMTA_Def.NHSCD
						.NHSNMA = UODET55A_NHSMTA_Def.NHSNMA
						.NHSNMB = UODET55A_NHSMTA_Def.NHSNMB
						.NHSADA = UODET55A_NHSMTA_Def.NHSADA
						.NHSADB = UODET55A_NHSMTA_Def.NHSADB
						.NHSADC = UODET55A_NHSMTA_Def.NHSADC
						.NHSNMMKB = UODET55A_NHSMTA_Def.NHSNMMKB
						.NHSRN = UODET55A_NHSMTA_Def.NHSRN
						' === 20061014 === INSERT S - ACE)Nagasawa 納入先便名コード対応
						.BINCD = UODET55A_NHSMTA_Def.BINCD
						.BINNM = UODET55A_NHSMTA_Def.BINNM
						' === 20061014 === INSERT E -
						' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
						.NHSZIPCD = UODET55A_NHSMTA_Def.NHSZIPCD
						.NHSTL = UODET55A_NHSMTA_Def.NHSTL
						.NHSFAX = UODET55A_NHSMTA_Def.NHSFAX
						.NHSFRNKB = UODET55A_NHSMTA_Def.NHSFRNKB
						' === 20061224 === INSERT E -
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.DATKB = ""
						.NHSCD = ""
						.NHSNMA = ""
						.NHSNMB = ""
						.NHSADA = ""
						.NHSADB = ""
						.NHSADC = ""
						.NHSNMMKB = ""
						.NHSRN = ""
						' === 20061014 === INSERT S - ACE)Nagasawa 納入先便名コード対応
						.BINCD = ""
						.BINNM = ""
						' === 20061014 === INSERT E -
						' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
						.NHSZIPCD = ""
						.NHSTL = ""
						.NHSFAX = ""
						.NHSFRNKB = ""
						' === 20061224 === INSERT E -
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' === 20060721 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSNMA
	'   概要：  開発場所名称１のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSNMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSNMA = Retn_Code
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
			UODET55A_NHSMTA_Inf.NHSNMA = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				'取得内容退避
				UODET55A_NHSMTA_Inf.NHSNMA = Input_Value
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSNMA = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSNMA_Inf
	'   概要：  開発場所名称１による画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSNMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSNMA = UODET55A_NHSMTA_Def.NHSNMA
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSNMA = ""
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSNMB
	'   概要：  開発場所名称２のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSNMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSNMB = Retn_Code
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
			UODET55A_NHSMTA_Inf.NHSNMB = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				'取得内容退避
				UODET55A_NHSMTA_Inf.NHSNMB = Input_Value
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSNMB = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSNMB_Inf
	'   概要：  開発場所名称２による画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSNMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSNMB = UODET55A_NHSMTA_Def.NHSNMB
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSNMB = ""
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	' === 20060721 === INSERT E - ACE)Nagasawa
	
	' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSZIPCD
	'   概要：  郵便番号のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSZIPCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim intRet As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSZIPCD = Retn_Code
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
			UODET55A_NHSMTA_Inf.NHSZIPCD = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'郵便番号書式チェック
				intRet = CF_Chk_ZIPCD(Trim(Input_Value), gv_intZIPCD_KETA, gv_intZIPCD_HAIHUN, UODET55A_NHSMTA_Inf.NHSFRNKB)
				Select Case intRet
					Case 10
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_114
						GoTo F_Chk_HD_KHTBSZIPCD_End
					Case 20
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_113
						GoTo F_Chk_HD_KHTBSZIPCD_End
					Case Else
						
				End Select
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				UODET55A_NHSMTA_Inf.NHSZIPCD = Input_Value
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
F_Chk_HD_KHTBSZIPCD_End: 
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSZIPCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSZIPCD_Inf
	'   概要：  郵便番号による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSZIPCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
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
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSZIPCD = UODET55A_NHSMTA_Def.NHSZIPCD
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSZIPCD = ""
					End With
					
			End Select
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSTL
	'   概要：  電話番号のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSTL(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim intRet As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSTL = Retn_Code
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
			UODET55A_NHSMTA_Inf.NHSTL = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'電話番号/FAX番号の書式チェック
				intRet = CF_Chk_FAXNO(Trim(Input_Value), gv_intTLFAX_KETA, gv_intTLFAX_HAIHUN, gv_intTLFAX_LSTNUM, UODET55A_NHSMTA_Inf.NHSFRNKB)
				Select Case intRet
					Case 10
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_109
						GoTo F_Chk_HD_KHTBSTL_End
					Case 20
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_111
						GoTo F_Chk_HD_KHTBSTL_End
					Case 30
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_110
						GoTo F_Chk_HD_KHTBSTL_End
					Case 40
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_107
						GoTo F_Chk_HD_KHTBSTL_End
					Case 50
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_108
						GoTo F_Chk_HD_KHTBSTL_End
					Case 60
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_112
						GoTo F_Chk_HD_KHTBSTL_End
				End Select
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				UODET55A_NHSMTA_Inf.NHSTL = Input_Value
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
F_Chk_HD_KHTBSTL_End: 
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSTL = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSTL_Inf
	'   概要：  電話番号による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSTL_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
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
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSTL = UODET55A_NHSMTA_Def.NHSTL
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSTL = ""
					End With
					
			End Select
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSFAX
	'   概要：  FAX番号のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSFAX(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim intRet As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSFAX = Retn_Code
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
			UODET55A_NHSMTA_Inf.NHSFAX = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'電話番号/FAX番号の書式チェック
				intRet = CF_Chk_FAXNO(Trim(Input_Value), gv_intTLFAX_KETA, gv_intTLFAX_HAIHUN, gv_intTLFAX_LSTNUM, UODET55A_NHSMTA_Inf.NHSFRNKB)
				Select Case intRet
					Case 10
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_109
						GoTo F_Chk_HD_KHTBSFAX_End
					Case 20
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_111
						GoTo F_Chk_HD_KHTBSFAX_End
					Case 30
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_110
						GoTo F_Chk_HD_KHTBSFAX_End
					Case 40
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_107
						GoTo F_Chk_HD_KHTBSFAX_End
					Case 50
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_108
						GoTo F_Chk_HD_KHTBSFAX_End
					Case 60
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgUODET55_E_112
						GoTo F_Chk_HD_KHTBSFAX_End
				End Select
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				UODET55A_NHSMTA_Inf.NHSFAX = Input_Value
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
F_Chk_HD_KHTBSFAX_End: 
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSFAX = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSFAX_Inf
	'   概要：  FAX番号による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSFAX_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
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
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSFAX = UODET55A_NHSMTA_Def.NHSFAX
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSFAX = ""
					End With
					
			End Select
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	' === 20061224 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSADA
	'   概要：  開発場所住所１のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSADA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSADA = Retn_Code
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
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Retn_Code = CHK_ERR_NOT_INPUT
			UODET55A_NHSMTA_Inf.NHSADA = ""
			' === 20060721 === UPDATE E - ACE)Nagasawa
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				' === 20060721 === INSERT S - ACE)Nagasawa
				'取得内容退避
				UODET55A_NHSMTA_Inf.NHSADA = Input_Value
				' === 20060721 === INSERT E - ACE)Nagasawa
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSADA = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSADA_Inf
	'   概要：  開発場所住所１による画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSADA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSADA = UODET55A_NHSMTA_Def.NHSADA
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSADA = ""
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSADB
	'   概要：  開発場所住所２のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSADB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSADB = Retn_Code
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
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Retn_Code = CHK_ERR_NOT_INPUT
			UODET55A_NHSMTA_Inf.NHSADB = ""
			' === 20060721 === UPDATE E - ACE)Nagasawa
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				' === 20060721 === INSERT S - ACE)Nagasawa
				'取得内容退避
				UODET55A_NHSMTA_Inf.NHSADB = Input_Value
				' === 20060721 === INSERT E - ACE)Nagasawa
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSADB = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSADB_Inf
	'   概要：  開発場所住所２による画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSADB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSADB = UODET55A_NHSMTA_Def.NHSADB
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSADB = ""
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KHTBSADC
	'   概要：  開発場所住所３のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KHTBSADC(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KHTBSADC = Retn_Code
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
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Retn_Code = CHK_ERR_NOT_INPUT
			UODET55A_NHSMTA_Inf.NHSADC = ""
			' === 20060721 === UPDATE E - ACE)Nagasawa
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgUODET55_E_101 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				' === 20060721 === INSERT S - ACE)Nagasawa
				'取得内容退避
				UODET55A_NHSMTA_Inf.NHSADC = Input_Value
				' === 20060721 === INSERT E - ACE)Nagasawa
			End If
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KHTBSADC = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KHTBSADC_Inf
	'   概要：  開発場所住所３による画面表示
	'   引数：
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KHTBSADC_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'画面編集ありとする
				gv_bolUODET55A_INIT = True
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			' === 20060901 === INSERT S - ACE)Sejima
			Select Case pm_Mode
				Case DSP_DEF
					With UODET55A_NHSMTA_Inf
						.NHSADC = UODET55A_NHSMTA_Def.NHSADC
					End With
					
				Case Else
					With UODET55A_NHSMTA_Inf
						.NHSADC = ""
					End With
					
			End Select
			' === 20060901 === INSERT E
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
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
			Case FR_SSSSUB01.HD_KHTBSCD.Name
				'開発場所ｺｰﾄﾞによる画面表示
				Call F_Dsp_HD_KHTBSCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSNMA.Name
				'開発場所名称１による画面表示
				Call F_Dsp_HD_KHTBSNMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSNMB.Name
				'開発場所名称２による画面表示
				Call F_Dsp_HD_KHTBSNMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
			Case FR_SSSSUB01.HD_KHTBSZIPCD.Name
				'開発場所郵便番号による画面表示
				Call F_Dsp_HD_KHTBSZIPCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSTL.Name
				'開発場所電話番号による画面表示
				Call F_Dsp_HD_KHTBSTL_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSFAX.Name
				'開発場所FAX番号による画面表示
				Call F_Dsp_HD_KHTBSFAX_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				' === 20061224 === INSERT E -
				
			Case FR_SSSSUB01.HD_KHTBSADA.Name
				'開発場所住所１による画面表示
				Call F_Dsp_HD_KHTBSADA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSADB.Name
				'開発場所住所２による画面表示
				Call F_Dsp_HD_KHTBSADB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSADC.Name
				'開発場所住所３による画面表示
				Call F_Dsp_HD_KHTBSADC_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
		End Select
		
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
			Case FR_SSSSUB01.HD_KHTBSCD.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSNMA.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSNMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSNMB.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSNMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
			Case FR_SSSSUB01.HD_KHTBSZIPCD.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'郵便番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSZIPCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSTL.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'電話番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSTL(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSFAX.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'FAX番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSFAX(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				' === 20061224 === INSERT E -
				
			Case FR_SSSSUB01.HD_KHTBSADA.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSADA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSADB.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSADB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSSUB01.HD_KHTBSADC.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'ﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KHTBSADC(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
		End Select
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'    Select Case True
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'            If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value) Then
		'                '画面編集ありとする
		'                gv_bolUODET55A_INIT = True
		'            End If
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'            If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> vbUnchecked Then
		'                '画面編集ありとする
		'                gv_bolUODET55A_INIT = True
		'            End If
		'
		'        Case Else
		'    End Select
		
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
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			' === 20060721 === UPDATE E - ACE)Nagasawa
			
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
			' === 20060721 === UPDATE S - ACE)Nagasawa
			'        Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			Call SSSMAIN0003.F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			' === 20060721 === UPDATE E - ACE)Nagasawa
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'未入力メッセージ
				If Rtn_Chk = CHK_ERR_NOT_INPUT Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET55_E_104, pm_All)
				End If
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		' === 20060721 === UPDATE S - ACE)Nagasawa
		'    Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		Rtn_Chk = SSSMAIN0003.F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		' === 20060721 === UPDATE E - ACE)Nagasawa
		'チェックＮＧ
		If Rtn_Chk <> CHK_OK Then
			
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
			
			F_Ctl_Head_Chk = Rtn_Chk
			Exit Function
		End If
		
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' === 20060721 === INSERT S - ACE)Nagasawa
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
		Dim Err_Cd As String 'エラーコード
		Dim intRet As Short
		Dim strKHTBSCD As String '開発場所コード
		' === 20061013 === INSERT S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		Dim strKHTBSADA As String '開発場所住所１
		Dim strKHTBSADB As String '開発場所住所２
		Dim strKHTBSADC As String '開発場所住所３
		' === 20061013 === INSERT E -
		' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		Dim strKHTBSZIPCD As String '開発場所郵便番号
		Dim strKHTBSTL As String '開発場所電話番号
		Dim strKHTBSFAX As String '開発場所FAX番号
		' === 20061224 === INSERT E -
		'ADD START FKS)INABA 2007/07/18 *********************
		Dim lv_HDKEIKN As Object
		Dim lv_SFKEIKN As Object
		Dim lv_HDSIKKN As Object
		Dim lv_SFSIKKN As Object
		'ADD  END  FKS)INABA 2007/07/18 *********************
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSSUB01.HD_KHTBSCD.Tag)
		
		'開発場所コード取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSCD.Tag)
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
		
		' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		'開発場所郵便番号取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSZIPCD.Tag)
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSZIPCD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		
		'開発場所電話番号取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSTL.Tag)
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSTL = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		
		'開発場所FAX番号取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSFAX.Tag)
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSFAX = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		' === 20061224 === INSERT E -
		
		'開発場所住所取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADA.Tag)
		' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		'    strKHTBSAD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSADA = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		' === 20061013 === UPDATE E -
		
		' === 20061224 === DELETE S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		'    '納入先コードが未入力で、住所に入力がある場合、エラー
		'' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		''    If Trim(strKHTBSCD) = "" And Trim(strKHTBSAD) <> "" Then
		'    If Trim(strKHTBSCD) = "" And Trim(strKHTBSADA) <> "" Then
		'' === 20061013 === UPDATE E -
		'        Err_Cd = gc_strMsgUODET55_E_105
		'        pm_ErrIdx = CInt(FR_SSSSUB01.HD_KHTBSADA.Tag)
		'        GoTo F_Ctl_Head_RelChk_END
		'    End If
		' === 20061224 === DELETE E -
		
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADB.Tag)
		' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		'    strKHTBSAD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSADB = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		' === 20061013 === UPDATE E -
		
		' === 20061224 === DELETE S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		'    '納入先コードが未入力で、住所に入力がある場合、エラー
		'' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		''    If Trim(strKHTBSCD) = "" And Trim(strKHTBSAD) <> "" Then
		'    If Trim(strKHTBSCD) = "" And Trim(strKHTBSADB) <> "" Then
		'' === 20061013 === UPDATE E -
		'        Err_Cd = gc_strMsgUODET55_E_105
		'        pm_ErrIdx = CInt(FR_SSSSUB01.HD_KHTBSADB.Tag)
		'        GoTo F_Ctl_Head_RelChk_END
		'    End If
		' === 20061224 === DELETE E -
		
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSADC.Tag)
		' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		'    strKHTBSAD = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strKHTBSADC = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
		' === 20061013 === UPDATE E -
		
		' === 20061224 === UPDATE S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
		'    '納入先コードが未入力で、住所に入力がある場合、エラー
		'' === 20061013 === UPDATE S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		''    If Trim(strKHTBSCD) = "" And Trim(strKHTBSAD) <> "" Then
		'    If Trim(strKHTBSCD) = "" And Trim(strKHTBSADC) <> "" Then
		'' === 20061013 === UPDATE E -
		'        Err_Cd = gc_strMsgUODET55_E_105
		'        pm_ErrIdx = CInt(FR_SSSSUB01.HD_KHTBSADC.Tag)
		'        GoTo F_Ctl_Head_RelChk_END
		'    End If
		'
		'' === 20061013 === INSERT S - ACE)Nagasawa 便名コード、住所も倉庫コードと同じ条件で必須
		'    If Trim(strKHTBSCD) <> "" And Trim(strKHTBSADA) = "" _
		''    And Trim(strKHTBSADB) = "" And Trim(strKHTBSADC) = "" Then
		'        Err_Cd = gc_strMsgUODET55_E_106
		'        pm_ErrIdx = CInt(FR_SSSSUB01.HD_KHTBSADA.Tag)
		'        GoTo F_Ctl_Head_RelChk_END
		'    End If
		'' === 20061013 === INSERT E -
		
		'納入先コードが未入力で、住所等に入力がある場合、エラー
		If Trim(strKHTBSCD) = "" And Trim(strKHTBSADA) & Trim(strKHTBSADB) & Trim(strKHTBSADC) & Trim(strKHTBSZIPCD) & Trim(strKHTBSTL) & Trim(strKHTBSFAX) <> "" Then
			Err_Cd = gc_strMsgUODET55_E_105
			pm_ErrIdx = CShort(FR_SSSSUB01.HD_KHTBSCD.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		
		'納入先コードが入力されている場合、電話番号は必須
		If Trim(strKHTBSCD) <> "" And Trim(strKHTBSTL) = "" Then
			Err_Cd = gc_strMsgUODET55_E_116
			pm_ErrIdx = CShort(FR_SSSSUB01.HD_KHTBSTL.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		
		'納入先コードが入力されている場合、住所は必須
		If Trim(strKHTBSCD) <> "" And Trim(strKHTBSADA) & Trim(strKHTBSADB) & Trim(strKHTBSADC) = "" Then
			Err_Cd = gc_strMsgUODET55_E_106
			pm_ErrIdx = CShort(FR_SSSSUB01.HD_KHTBSADA.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		' === 20061224 === UPDATE E -
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Head_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Head_RelChk = Rtn_Chk
		
	End Function
	' === 20060721 === INSERT E - ACE)Nagasawa
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Foot_In_Ready
	'   概要：  フッタ部の入力準備
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		'
		'    Dim Index_Wk        As Integer
		'
		'    'フッタ部内で処理
		'    For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
		'        Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.NAME
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'            Case FR_SSSSUB01.TL_NHSCD.NAME _
		''               , FR_SSSSUB01.TL_NHSADA.NAME _
		''               , FR_SSSSUB01.TL_NHSADB.NAME _
		''               , FR_SSSSUB01.TL_NHSADC.NAME _
		''               , FR_SSSSUB01.TL_MAEUKKB.NAME _
		''               , FR_SSSSUB01.TL_SEIKB.NAME _
		''               , FR_SSSSUB01.TL_BINCD.NAME _
		''               , FR_SSSSUB01.TL_DFKJDNNO.NAME _
		''               , FR_SSSSUB01.TL_SBAUODKN.NAME _
		''               , FR_SSSSUB01.TL_DENCMIN.NAME _
		''               , FR_SSSSUB01.TL_DENCM.NAME
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'            '初期状態で入力可能なｺﾝﾄﾛｰﾙ
		'                '入力可能
		'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
		'
		'            Case FR_SSSSUB01.TL_NHSNMA.NAME _
		''               , FR_SSSSUB01.TL_NHSNMB.NAME
		'
		'            '納入先コードに入力があり、名称マニュアル区分＝"1"（変更可)の場合
		'            If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSSUB01.TL_NHSCD.Tag)))) <> "" _
		''            And UODET55A_NHSMTA_Inf.NHSNMMKB = gc_strNMMKB_OK Then
		'                '入力可能
		'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
		'            End If
		'
		'        End Select
		'    Next
		'
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
	'   名称：  Function F_Set_Value_NotInput
	'   概要：  画面に入力されている場合はその値を優先する
	'   引数：
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Value_NotInput(ByRef pm_inpValue As Object, ByRef pm_intTag As Short, ByRef pm_All As Cls_All) As Object
		
		Dim DspValue As Object
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_All.Dsp_Sub_Inf(pm_intTag).Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽ
				'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				F_Set_Value_NotInput = ""
				
				'画面より表示項目を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DspValue = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_intTag)))
				
				'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If DspValue <> "" Then
					'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					F_Set_Value_NotInput = DspValue
				Else
					'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					F_Set_Value_NotInput = pm_inpValue
				End If
				
			Case TypeOf pm_All.Dsp_Sub_Inf(pm_intTag).Ctl Is System.Windows.Forms.CheckBox
				'ﾁｪｯｸﾎﾞｯｸｽ
				'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				F_Set_Value_NotInput = System.Windows.Forms.CheckState.Unchecked
				
				'画面より表示項目を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DspValue = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_intTag))
				
				If DspValue <> System.Windows.Forms.CheckState.Unchecked Then
					'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					F_Set_Value_NotInput = DspValue
				Else
					'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					F_Set_Value_NotInput = pm_inpValue
				End If
				
		End Select
		
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Value_NotInput2
	'   概要：  変数に入力されている場合はその値を優先する
	'   引数：
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Value_NotInput2(ByRef pm_inpValue As Object, ByRef pm_Value As Object) As Object
		
		Dim DspValue As Object
		
		'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(pm_Value) = "" Then
			'UPGRADE_WARNING: オブジェクト pm_inpValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			F_Set_Value_NotInput2 = pm_inpValue
		Else
			'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト F_Set_Value_NotInput2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			F_Set_Value_NotInput2 = pm_Value
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_KHTBSCD
	'   概要：  対象項目の備考入力ﾎﾞﾀﾝの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_KHTBSCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		' === 20060702 === INSERT S - ACE)Sejima
		Dim Next_Focus As Short
		' === 20060702 === INSERT E
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSSUB01.HD_KHTBSCD.Tag)
		
		' === 20060702 === INSERT S - ACE)Sejima
		Next_Focus = Trg_Index
		' === 20060702 === INSERT E
		
		'ﾌｫｰｶｽを納入先コードへ移動
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			' === 20060702 === INSERT S - ACE)Sejima
			'現在のActiveコントロールの選択状態解除
			'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSSUB01.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			' === 20060702 === INSERT E
			'ﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolUODET55A_LF_Enable = False
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()

            '納入先検索画面を呼び出す
            '20190809 CHG START
            '         WLSNHS.ShowDialog()
            'WLSNHS.Close()
            WLSNHS1.ShowDialog()
            WLSNHS1.Close()
            '20190809 CHG END
            gv_bolUODET55A_LF_Enable = True
			
			If WLSNHSMTA_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSNHSMTA_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				' === 20060721 === UPDATE S - ACE)Nagasawa
				'            Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				' === 20060721 === UPDATE E - ACE)Nagasawa
				
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
				
				Debug.Print(Chk_Move_Flg & "  " & Next_Focus)
				' === 20060702 === INSERT S - ACE)Sejima
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0003.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					' === 20060803 === UPDATE S - ACE)Sejima
					'D                'ﾁｪｯｸ後移動なし
					'D                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
					'D                '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					'D                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
					' === 20060803 === UPDATE ↓
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					' === 20060803 === UPDATE E
				End If
				' === 20060702 === INSERT E
			End If
		End If
		
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
        '20190809 DLT START
        'FR_SSSSUB01.PrintForm()
        '20190809 DLT END
        FR_SSSSUB01.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

    '20190809 ADD START
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

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
    '20190809 ADD END
End Module