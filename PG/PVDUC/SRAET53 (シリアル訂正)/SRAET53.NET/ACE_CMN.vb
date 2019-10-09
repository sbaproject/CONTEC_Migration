Option Strict Off
Option Explicit On
Module ACE_CMN
	'//* All Right Reserved Copy Right (C)  株式会社富士通関西システムズ
	'//***************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ACE_CMN.bas
	'//*
	'//*＜バージョン＞
	'//* 1.00
	'//*
	'//*＜作成者＞
	'//* FKS)
	'//*
	'//*＜説明＞
	'//*    共通モジュール
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|-------------------------------------------------
	'//* 1.00     |20021101|FKS)           |新規作成
	'//**************************************************************************************
	
	'//色設定
	'UPGRADE_NOTE: COLOR_BLACK は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_BLACK As System.Drawing.Color = System.Drawing.Color.Black '黒色 = &H0&
	'UPGRADE_NOTE: COLOR_YELLOW は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_YELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '黄色 = &HFFFF&
	'UPGRADE_NOTE: COLOR_RED は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_RED As System.Drawing.Color = System.Drawing.Color.Red '赤色 = &HFF&
	'UPGRADE_NOTE: COLOR_WHITE は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_WHITE As System.Drawing.Color = System.Drawing.Color.White '白色 = &HFFFFFF
	'UPGRADE_NOTE: COLOR_GRAY は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_GRAY As System.Drawing.Color = System.Drawing.SystemColors.Control '灰色 = &H8000000F&
	
	'//画面分類
	Public Const DSP_CTG_REFERENCE As String = "REFERENCE" '照会系
	Public Const DSP_CTG_ENTRY As String = "ENTRY" '登録系(新規入力)
	Public Const DSP_CTG_REVISION As String = "REVISION" '修正系
	
	'//画面入力域
	Public Const IN_AREA_DSP_MN As String = "1" 'メニュー
	Public Const IN_AREA_DSP_HD As String = "2" 'ヘッダ
	Public Const IN_AREA_DSP_HD2 As String = "22" 'ヘッダ２
	Public Const IN_AREA_DSP_HD3 As String = "23" 'ヘッダ３
	Public Const IN_AREA_DSP_BD As String = "3" '明細
	Public Const IN_AREA_DSP_TL As String = "4" 'フッタ
	Public Const IN_AREA_DSP_MS As String = "5" 'メッセージ
	Public Const IN_AREA_ELSE As String = "99" 'その他
	
	'//入力タイプ
	Public Const IN_TYP_NUM As Short = 1 '数値
	Public Const IN_TYP_DATE As Short = 2 '日付
	Public Const IN_TYP_CODE As Short = 3 'コード系
	Public Const IN_TYP_STR As Short = 4 '文字
	Public Const IN_TYP_YYYYMM As Short = 5 '年月
	Public Const IN_TYP_HHMM As Short = 6 '時刻
	Public Const IN_TYP_HHMMSS As Short = 7 '時分秒
	Public Const IN_TYP_ELSE As Short = 99 'ボタン、チェックボックス、オプションなど
	
	'//入力文字タイプ
	Public Const IN_STR_TYP_NUM As String = "NUM" '数値のみ０～９
	Public Const IN_STR_TYP_KIN As String = "KIN" '数量・金額・単価系
	Public Const IN_STR_TYP_X As String = "X" '半角
	Public Const IN_STR_TYP_N As String = "N" '全角
	Public Const IN_STR_TYP_NX As String = "NX" '混在
	Public Const IN_STR_TYP_TEL As String = "TEL" '電話・FAX系
	Public Const IN_STR_TYP_ELSE As String = "ELSE" 'その他
	
	'//数値±フラグ
	Public Const IN_NUM_PLUS As Short = 1 'ﾌﾟﾗｽ
	Public Const IN_NUM_MINUS As Short = 2 'ﾏｲﾅｽ
	Public Const IN_NUM_PLUS_MINUS As Short = 3 '両方
	Public Const IN_NUM_ELSE As Short = 99 'その他
	
	'//表示形式
	Public Const DSP_FMT_DATE_SLASH As String = "0000/00/00" '日付項目
	Public Const DSP_FMT_YYYYMM_SLASH As String = "0000/00" '年月項目
	Public Const DSP_FMT_HHMM As String = "00:00" '時刻
	Public Const DSP_FMT_HHMMSS As String = "00:00:00" '時分秒
	Public Const DSP_FMT_KIN_1 As String = "#,##0" '金額
	Public Const DSP_FMT_TAN_1 As String = "#,##0.00" '単価
	Public Const DSP_FMT_RT_1 As String = "#,##0.0" '率
	
	'//日付入力形式
	Public Const IN_FMT_DATE As String = "YYYYMMDD"
	Public Const IN_FMT_YYYMM As String = "YYYYMM"
	Public Const IN_FMT_HHMM As String = "HHMM"
	Public Const IN_FMT_HHMMSS As String = "HHMMSS"
	
	'//詰文字の揃え
	Public Const FIL_POINT_LEFT As Short = 0 '左揃
	Public Const FIL_POINT_RIGHT As Short = 1 '右揃
	Public Const FIL_POINT_CENTER As Short = 2 '中央
	Public Const FIL_POINT_ELSE As Short = 99 'その他
	
	'//項目ﾌｫｰｶｽ状態
	Public Const ITEM_NORMAL_STATUS As String = "1" 'フォーカスなし
	Public Const ITEM_SELECT_STATUS As String = "2" 'フォーカスあり
	Public Const ITEM_INITIAL_STATUS As String = "3" '初期状態
	'//前景/背景色設定(CF_Set_Item_Color)のモード
	Public Const ITEM_COLOR_DEF As Short = 0 '初期化
	Public Const ITEM_COLOR_NOMAL As Short = 1 '通常
	Public Const ITEM_COLOR_KEYPRESS As Short = 2 'KEYPRESS後の特別仕様
	
	'//項目ｴﾗｰ状態
	Public Const ERR_DEF As String = "0" '初期状態
	Public Const ERR_NOT As String = "1" 'エラーなし
	Public Const ERR_NOT_INPUT As String = "2" '必須入力の未入力エラー
	Public Const ERR_ELSE As String = "3" 'その他エラー
	
	'//画面項目/復元内容のフラグ
	Public Const VALUE_FLG_DEF As Short = 0 '初期値
	Public Const VALUE_FLG_ELSE As Short = 1 '初期値以外
	
	'//ﾁｪｯｸ関数呼出元
	Public Const CHK_FROM_LOSTFOCUS As String = "LOSTFOCUS" 'LOSTFOCUS
	Public Const CHK_FROM_KEYRETURN As String = "KEYRETURN" 'KEYRETURN
	Public Const CHK_FROM_KEYRIGHT As String = "KEYRIGHT" 'KEYRIGHT
	Public Const CHK_FROM_KEYDOWN As String = "KEYDOWN" 'KEYDOWN
	Public Const CHK_FROM_KEYLEFT As String = "KEYLEFT" 'KEYLEFT
	Public Const CHK_FROM_KEYUP As String = "KEYUP" 'KEYUP
	Public Const CHK_FROM_KEYPRESS As String = "KEYPRESS" 'KEYPRESS
	Public Const CHK_FROM_BACK_PROCESS As String = "BACK_PROCESS" '復元時などのＰＧ側主導の場合
	Public Const CHK_FROM_ALL_CHK As String = "ALL_CHK" '一括チェックなど
	Public Const CHK_FROM_ALL_DEFAULT As String = "DEFAULT" '初期状態
	
	'//画面ボディ行状態
	Public Const BODY_ROW_STATE_DEFAULT As Short = 0 '初期状態
	Public Const BODY_ROW_STATE_INPUT_WAIT As Short = 1 '入力待状態
	Public Const BODY_ROW_STATE_INPUT As Short = 2 '入力済状態
	Public Const BODY_ROW_STATE_LST_ROW As Short = 3 '最終準備行(入力待状態)
	
	'//復元フラグ
	Public Const BODY_ROW_REST_FLG_NOT As Short = 0 '復元情報無
	Public Const BODY_ROW_REST_FLG_CLR As Short = 1 '復元情報有(明細初期化の復元情報)
	Public Const BODY_ROW_REST_FLG_DEL As Short = 2 '復元情報有(明細削除の復元情報)
	
	'**ﾁｪｯｸ関数関連 Start **
	'//戻値
	Public Const CHK_BASE_OK As Short = 0 '正常
	Public Const CHK_BASE_ERR_CODE As Short = 1 '文字コードエラー
	Public Const CHK_BASE_ERR_OVER As Short = 2 '桁数エラー
	Public Const CHK_BASE_ERR_TYP As Short = 3 '属性エラー
	'**ﾁｪｯｸ関数関連 End **
	
	'//項目クリア(CF_Init_Clr_Dsp)のモード
	Public Const ITM_ALL_CLR As Short = 0 '全項目クリア
	Public Const ITM_ALL_ONLY As Short = 1 '個別クリア
	'//行クリア(CF_Init_Clr_Dsp_Body)のモード
	Public Const BODY_ALL_CLR As Short = 0 '全項目クリア
	Public Const BODY_ALL_ONLY As Short = 1 '個別クリア
	
	'//特別項目選択(CF_Set_Sel_Ini)のモード
	Public Const SEL_INI_MODE_1 As String = "1" '日付項目＝年／年月項目＝年／時刻項目＝時
	Public Const SEL_INI_MODE_2 As String = "2" '日付項目＝日／年月項目＝月／時刻項目＝分
	
	'//項目編集モード(CF_Set_Item_Direct、CF_Set_Bef_Rest_Value、CF_Edi_Dsp_Body_Inf)
	Public Const SET_FLG_NOMAL As Short = 0 '通常編集
	Public Const SET_FLG_DEF As Short = 1 '初期値編集
	Public Const SET_FLG_DB As Short = 2 'ＤＢ内容編集
	Public Const SET_FLG_DB_ERR As Short = 3 'ＤＢ内容編集(エラーあり)
	
	'-----------------------------------------------------------------------------------------------------------
	'画面項目詳細情報構造体
	Private Structure Cls_Dsp_Sub_Detail_Inf
		Dim Item_Nm As String '画面項目名(ｺﾝﾄﾛｰﾙ名)
		Dim In_Area As String '画面入力域
		Dim In_Typ As Short '入力タイプ
		Dim In_Str_Typ As String '入力文字タイプ
		Dim MaxLengthB As Short '最大バイト数
		Dim Dsp_MaxLengthB As Short '表示最大バイト数
		Dim Num_Int_Fig As Short '数値の整数部桁
		Dim Num_Fra_Fig As Short '数値の小数部桁数
		Dim Num_Sign_Fig As Short '数値±フラグ
		Dim Fil_Chr As String '表示時の詰文字
		Dim Fil_Point As Short 'ﾃｷｽﾄ上で詰める文字の位置
		Dim Dsp_Fmt As String '表示方式
		Dim Body_Index As Short '明細部ＮＯ（１～、ヘッダ/フッタの場合は、０固定）
		'********↑初期設定から変更されない、↓条件次第で変更あり***********************************************************
		Dim Dsp_Value As Object '画面項目内容
		Dim Focus_Ctl As Boolean 'フォーカス制御(T:ﾌｫｰｶｽなし、F:ﾌｫｰｶｽあり)
		'表示/入力が切り替わる場合に設定する
		Dim Focus_Ctl_Bk As Boolean '退避フォーカス制御(初期処理時に定義されたFocus_Ctlの設定保持する)
		Dim Bef_Value As Object '前回内容
		Dim Bef_Value_Flg As Short '前回内容フラグ
		Dim Rest_Value As Object '復元内容
		Dim Rest_Value_Flg As Short '復元内容フラグ
		Dim In_Value_Flg As Boolean '入力フラグ(T:ﾕｰｻﾞｰ入力有、F:ｰｻﾞｰ入力無)
		Dim Item_Init_Flg As Boolean '項目初期化フラグ(T:初期化ＯＫ、F:初期化ＮＧ)
		Dim Item_Rest_Flg As Boolean '項目復元フラグ(T:復元ＯＫ、F:復元ＮＧ)
		Dim Bef_Chk_Value As Object '前回チェック内容
		Dim Err_Status As String '項目のエラー状態
		Dim Locked As Boolean '読取専用フラグ
		Dim Not_Input_Chk_Fin_Flg As Boolean '未入力以外のチェック済フラグ
		'T:未入力以外のチェックを実行した場合
		'F:その他の状態
		Dim Chk_From_Process As String 'チェック関数呼出元処理
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'画面ボディ行情報構造体
	''''Public Type Cls_Dsp_Body_Row_Inf
	''''    Status                  As Integer                      '対象行の状態
	''''    Item_Detail()           As Cls_Dsp_Sub_Detail_Inf       '１行に格納される項目情報
	''''    Bus_Inf                 As Cls_Dsp_Body_Bus_Inf         '１行単位の業務情報'（各プログラムのSSSMAIN0001で必ず宣言する）
	''''End Type
	
	'''''画面ボディ復元行情報構造体
	''''Public Type Cls_Dsp_Rest_Inf
	''''    Rest_Flg                As Integer                      '復元情報の有/無
	''''    Rest_Row                As Integer                      '復元行
	''''    Rest_Row_Inf            As Cls_Dsp_Body_Row_Inf         '復元行情報
	''''End Type
	''''
	'''''画面ボディ情報構造体
	''''Public Type Cls_Dsp_Body_Inf
	''''    Cur_Top_Index               As Integer                  '最上明細ｲﾝﾃﾞｯｸｽ
	''''    Row_Inf()                   As Cls_Dsp_Body_Row_Inf     '１行単位の情報
	''''    Init_Row_Inf                As Cls_Dsp_Body_Row_Inf     '初期化用の１行単位の情報
	''''    Rest_Inf                    As Cls_Dsp_Rest_Inf         '復元行の１行単位の情報
	''''End Type
	
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'画面項目情報構造体
	Public Structure Cls_Dsp_Sub_Inf
		Dim Ctl As System.Windows.Forms.Control '画面コントロール
		Dim Detail As Cls_Dsp_Sub_Detail_Inf '画面項目詳細情報
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'画面基礎情報構造体
	Public Structure Cls_Dsp_Base
		Dim Dsp_Ctg As String '画面分類(照会系、登録系、修正系）
		Dim Item_Cnt As Short '画面項目数
		Dim Dsp_Body_Cnt As Short '画面表示明細数（－１,０：明細なし、１～：表示時明細数）
		Dim Max_Body_Cnt As Short '最大入力明細数（－１：明細なし、０：明細上限無１～：表示時明細数）
		Dim Body_Col_Cnt As Short '明細の列項目数
		Dim Head_Lst_Idx As Short 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
		Dim Body_Fst_Idx As Short '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ
		Dim Foot_Fst_Idx As Short 'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ
		Dim Dsp_Body_Move_Qty As Short '画面移動量（最大ｽｸﾛｰﾙ量、ページボタンの移動量）
		'（０：明細なし、１～：移動量）
		Dim Cursor_Idx As Short '現在のﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		Dim Bef_Cursor_Idx As Short '１つ前のﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		Dim Change_Flg As Boolean 'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		Dim VS_Scr_Flg As Boolean 'ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		Dim LostFocus_Flg As Boolean 'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		Dim Head_Ok_Flg As Boolean 'ヘッダ部チェックＯＫフラグ
		Dim PopupMenu_Idx As Short 'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰのﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		Dim Head2_Lst_Idx As Short 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ(見積登録等でのみ使用)
		Dim Head3_Lst_Idx As Short 'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ(システム受注登録等でのみ使用)
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'//画面のｲﾒｰｼﾞ情報
	Public Structure Cls_Img_Inf
		Dim Click_On_Img As System.Windows.Forms.PictureBox
		Dim Click_Off_Img As System.Windows.Forms.PictureBox
	End Structure
	
	'//全構造体
	Public Structure Cls_All
		'画面基礎情報
		Dim Dsp_Base As Cls_Dsp_Base
		'画面項目情報
		Dim Dsp_Sub_Inf() As Cls_Dsp_Sub_Inf
		''''    '画面ボディ情報
		''''    Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		'初期設定用タイマー
		Dim TM_StartUp_Ctl As System.Windows.Forms.Timer
		'メッセージ電球
		Dim Dsp_IM_Denkyu As System.Windows.Forms.Control '画面表示用
		Dim On_IM_Denkyu As System.Windows.Forms.Control '電球ON
		Dim Off_IM_Denkyu As System.Windows.Forms.Control '電球Off
		'メッセージ
		Dim Dsp_TX_Message As System.Windows.Forms.Control '画面メッセージ
		'明細縦スクロールバー
		Dim Bd_Vs_Scrl As System.Windows.Forms.VScrollBar
		'終了イメージ情報
		Dim IM_EndCm_Inf As Cls_Img_Inf
		'実行イメージ情報
		Dim IM_Execute_Inf As Cls_Img_Inf
		'帳票プリンタ出力イメージ情報
		Dim IM_LSTART_Inf As Cls_Img_Inf
		'帳票画面表示イメージ情報
		Dim IM_VSTART_Inf As Cls_Img_Inf
		'プリンタ設定イメージ情報
		Dim IM_LCONFIG_Inf As Cls_Img_Inf
		'明細追加イメージ情報
		Dim IM_INSERTDE_Inf As Cls_Img_Inf
		'明細削除イメージ情報
		Dim IM_DELETEDE_Inf As Cls_Img_Inf
		'検索イメージ情報
		Dim IM_Slist_Inf As Cls_Img_Inf
		'前ページイメージ情報
		Dim IM_PrevCm_Inf As Cls_Img_Inf
		'次ページイメージ情報
		Dim IM_NextCm_Inf As Cls_Img_Inf
		'明細部クリアボタンイメージ情報（※ボディ部からヘッダ部に制御を戻すボタン）
		Dim IM_SelectCm_Inf As Cls_Img_Inf
	End Structure
	
	'□□□□□□□□ 共通部品 Start □□□□□□□□□□□□□□□□
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_Num_Int_Part
	'//*
	'//* <戻り値>     型          説明
	'//*              String      整数部の桁数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//* <説  明>
	'//*    指定された文字列の整数部を取得します
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Get_Num_Int_Part(ByVal pm_Value As String) As String
		
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim Wk_Str As String
		
		Rtn_Value = ""
		
		For Wk_Cnt = 1 To Len(pm_Value)
			
			Wk_Str = Mid(pm_Value, Wk_Cnt, 1)
			
			If Wk_Str = "." Then
				Exit For
			End If
			
			If Wk_Str >= "0" And Wk_Str <= "9" Then
				Rtn_Value = Rtn_Value & Wk_Str
			End If
		Next 
		
		CF_Get_Num_Int_Part = Rtn_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_Num_Fra_Part
	'//*
	'//* <戻り値>     型          説明
	'//*              String      小数部の桁数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//* <説  明>
	'//*    指定された文字列の小数部を取得します
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Get_Num_Fra_Part(ByVal pm_Value As String) As String
		
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim Wk_Str As String
		
		Rtn_Value = ""
		
		If InStr(pm_Value, ".") > 0 Then
			For Wk_Cnt = InStr(pm_Value, ".") To Len(pm_Value)
				
				Wk_Str = Mid(pm_Value, Wk_Cnt, 1)
				
				If Wk_Str >= "0" And Wk_Str <= "9" Then
					Rtn_Value = Rtn_Value & Wk_Str
				End If
			Next 
			
		End If
		
		CF_Get_Num_Fra_Part = Rtn_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiLeftB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiRightB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして右から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiMidB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Start           Long             I            切り取り開始バイト数
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして指定した位置から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
		Else
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
			
			'//全角文字が途中で途切れる場合１文字多めにカットする。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
				Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
			End If
		End If
		
		CF_Ctr_AnsiMidB = Str_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiLenB
	'//*
	'//* <戻り値>     型          説明
	'//*              Long        長さバイト数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして対象文字列の長さバイト数を取得します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub CF_SpaceLenFormat
	'   概要：  文字列を指定長まで半角スペースで埋める
	'             例）  "123", 5    => "123  "
	'                   "123456", 5 => "123456"
	'   引数：　pin_strIn       : 対象文字列
	'           pin_intLength   : 文字列長（バイト）
	'           pin_bolCut      : 対象文字列長＞文字列長の場合、文字列のカットと行うかどうか
	'   戻値：　抽出内容を編集した構造体
	'   備考：  対象文字列長が指定長以上でpin_bolCut=Trueの場合は指定長までの文字列を返します。
	'           （２バイト文字考慮あり）
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_SpaceLenFormat(ByRef pin_strIn As String, ByRef pin_intLength As Short, Optional ByRef pin_bolCut As Boolean = False) As String
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strRet As String
		Dim strEdt As String
		Dim intIdx As Short
		'execute -------+---------------+---------------+---------------+---------------
		
		'UPGRADE_WARNING: オブジェクト LenWid(pin_strIn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(pin_strIn) > pin_intLength Then
			If pin_bolCut Then
				strRet = ""
				intIdx = 1
				strEdt = Mid(pin_strIn, intIdx, 1)
				'UPGRADE_WARNING: オブジェクト LenWid(strRet + strEdt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Do While LenWid(strRet & strEdt) <= pin_intLength
					strRet = strRet & strEdt
					intIdx = intIdx + 1
					strEdt = Mid(pin_strIn, intIdx, 1)
				Loop 
			Else
				strRet = pin_strIn
			End If
			'UPGRADE_WARNING: オブジェクト LenWid(pin_strIn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(pin_strIn) = pin_intLength Then 
			strRet = pin_strIn
		Else
			strRet = LeftWid(pin_strIn & Space(pin_intLength), pin_intLength)
		End If
		
		CF_SpaceLenFormat = strRet
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub CF_ZeroLenFormat
	'   概要：  文字列を指定長までゼロで埋める（半角数字のみ対象）
	'             例）  "123", 5    => "00123"
	'                   "123456", 5 => "123456"
	'   引数：　pin_strIn       : 対象文字列
	'           pin_intLength   : 文字列長（バイト）
	'           pin_bolCut      : 対象文字列長＞文字列長の場合、文字列のカットと行うかどうか
	'   戻値：　抽出内容を編集した構造体
	'   備考：  対象文字列長が指定長以上でpin_bolCut=Trueの場合は指定長までの文字列を返します。
	'           対象文字列が半角数字以外の場合、そのままの文字列を返します。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_ZeroLenFormat(ByRef pin_strIn As String, ByRef pin_intLength As Short, Optional ByRef pin_bolCut As Boolean = False) As String
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strIn As String
		Dim strRet As String
		Dim intIdx As Short
		Dim strEdt As String
		'execute -------+---------------+---------------+---------------+---------------
		
		strIn = pin_strIn
		
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(strIn) Then
			strIn = ""
		End If
		'半角数字チェック
		'UPGRADE_WARNING: オブジェクト LenWid(pin_strIn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Not (IsNumeric(strIn) And Len(pin_strIn) = LenWid(pin_strIn)) Then
			CF_ZeroLenFormat = strIn
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト LenWid(strIn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(strIn) > pin_intLength Then
			If pin_bolCut Then
				strRet = ""
				intIdx = Len(strIn)
				strEdt = Mid(strIn, intIdx, 1)
				'UPGRADE_WARNING: オブジェクト LenWid(strRet + strEdt) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Do While LenWid(strRet & strEdt) <= pin_intLength
					strRet = strEdt & strRet
					intIdx = intIdx - 1
					strEdt = Mid(strIn, intIdx, 1)
				Loop 
			Else
				strRet = strIn
			End If
			'UPGRADE_WARNING: オブジェクト LenWid(strIn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf LenWid(strIn) = pin_intLength Then 
			strRet = strIn
		Else
			strRet = RightWid(New String("0", pin_intLength) & strIn, pin_intLength)
		End If
		
		CF_ZeroLenFormat = strRet
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Chk_Date
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:チェックＯＫ / False:チェックＮＧもしくは異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_str_Date        String          I             チェック対象となる日付け
	'//*                                                               (YYYY,YYYYMM,YYYYMMDDのいづれかの形式で指定)
	'//*
	'//* <説  明>
	'//*    引数で渡された日付をチェックし、エラー時はメッセージを表示する
	'//*    チェック対象の日付けは、YYYY,YYYY/MM,YYYY/MM/DDのいづれかの形式で指定する必要がある
	'//*　　　　年のみ指定時：1000年以降かをチェック(1000年以降ならチェックＯＫ)
	'//*　　　　月まで指定時：1000年チェック + 月チェック(1～12)
	'//*　　　　日まで指定時：1000年チェック + 日付けチェック(Isdate関数)
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Chk_Date(ByVal pm_str_Date As String) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Chk_Date = False
		
		'//年チェック(1000以降がならＯＫ、それ以前はＮＧ)
		If CShort(Left(pm_str_Date, 4)) < 1000 Then
			GoTo EXIT_HANDLE
		End If
		
		'//月チェック(１月～１２月か)
		If Len(pm_str_Date) > 4 Then
			If CShort(Mid(pm_str_Date, 6, 2)) < 1 Or CShort(Mid(pm_str_Date, 6, 2)) > 12 Then
				GoTo EXIT_HANDLE
			End If
		End If
		
		'//日付けチェック(Isdate関数)
		If Len(pm_str_Date) > 7 Then
			If IsDate(pm_str_Date) = False Then
				GoTo EXIT_HANDLE
			End If
		End If
		
		CF_Chk_Date = True
		
EXIT_HANDLE: 
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	
	'□□□□□□□□ 共通部品 End □□□□□□□□□□□□□□□□
	
	'□□□□□□□□ 全画面共通処理 Start □□□□□□□□□□□□□□□□
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_System_Process
	'   概要：  システム共通処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		
		'パッケージ内のＤＬＬにて
		'｢ＴＡＢ｣＆｢ＴＡＢ＋ＳＨＩＦＴ｣をそれぞれ｢Ｆ１６｣＆｢Ｆ１５｣に割当
		'   ReleaseTabCapture 0
		'   SetTabCapture pm_Form.hwnd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Clr_Prompt
	'   概要：  メッセージ部をクリア
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Clr_Prompt(ByRef pm_All As Cls_All) As String
		Dim Wk_Index As Short
		'電球
		'UPGRADE_WARNING: オブジェクト pm_All.Off_IM_Denkyu.Picture の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_ISSUE: Control メソッド Dsp_IM_Denkyu.Picture はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		pm_All.Dsp_IM_Denkyu.Image = pm_All.Off_IM_Denkyu.Picture
		'メッセージ
		Wk_Index = CShort(pm_All.Dsp_TX_Message.Tag)
		Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		pm_All.Dsp_TX_Message.ForeColor = COLOR_BLACK
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Prompt
	'   概要：  メッセージ部を設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Prompt(ByRef pm_Msg_Inf As String, ByRef pm_ForeColor As Integer, ByRef pm_All As Cls_All) As String
		Dim Wk_Index As Short
		'電球
		'UPGRADE_WARNING: オブジェクト pm_All.On_IM_Denkyu.Picture の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_ISSUE: Control メソッド Dsp_IM_Denkyu.Picture はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		pm_All.Dsp_IM_Denkyu.Image = pm_All.On_IM_Denkyu.Picture
		'メッセージ
		Wk_Index = CShort(pm_All.Dsp_TX_Message.Tag)
		Call CF_Set_Item_Direct(pm_Msg_Inf, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		pm_All.Dsp_TX_Message.ForeColor = System.Drawing.ColorTranslator.FromOle(pm_ForeColor)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_IM_EndCm_Img
	'   概要：  各メッセージを設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Img(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_SetImp As Cls_Img_Inf, ByRef pm_OnOff As Boolean, ByRef pm_All As Cls_All) As String
		
		If pm_OnOff = False Then
			'Off
			Call CF_Set_Item_Direct(pm_SetImp.Click_Off_Img, pm_Dsp_Sub_Inf, pm_All)
		Else
			'On
			Call CF_Set_Item_Direct(pm_SetImp.Click_On_Img, pm_Dsp_Sub_Inf, pm_All)
		End If
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_Item_Property
	'   概要：  項目を設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Item_Property(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		For Index_Wk = 1 To pm_All.Dsp_Base.Item_Cnt
			'==================
			'MaxLength設定
			'==================
			'ﾃｷｽﾄﾎﾞｯｸｽ
			'        If TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is TextBox Then
			'            'MaxLengthB設定
			'            pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.MaxLength = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB
			'
			'        End If
			
			'=====================
			'TabIndex/TabStop設定
			'=====================
			'        If TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is TextBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is CheckBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is OptionButton _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is SSCommand5 _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is SSPanel5 _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is PictureBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is VScrollBar _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is OLE Then
			'            'TabIndex=Tagを設定
			'            pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.TabIndex = CInt(pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Tag)
			'
			'            'TabStopを設定
			'            Call CF_Set_Item_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl, pm_All.Dsp_Sub_Inf(Index_Wk))
			'
			'        End If
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_Def_Dsp
	'   概要：  画面基礎情報の共通設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Def_Dsp(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
		'画面基礎情報設定
		'    With pm_All.Dsp_Base
		'        .Cursor_Idx = 0         '現在のﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		'        .Bef_Cursor_Idx = 0     '１つ前のﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		'        .Change_Flg = False     'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		'        .VS_Scr_Flg = False     'ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		'        .LostFocus_Flg = False  'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ
		'        .Head_Ok_Flg = False    'ヘッダ部チェックＯＫフラグ
		'        .PopupMenu_Idx = 0      'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰのﾌｫｰｶｽのｲﾝﾃﾞｯｸｽ
		'    End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Copy_Def_Dsp_Body
	'   概要：  明細の共通設定を部分を１行前からコピーする
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Copy_Def_Dsp_Body(ByRef pm_Index_Wk As Short, ByRef pm_Body_Col_Cnt As Short, ByRef pm_All As Cls_All) As Short
		
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Area = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Area
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Typ = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Typ
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Str_Typ = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Str_Typ
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.MaxLengthB = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.MaxLengthB
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Dsp_MaxLengthB = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Dsp_MaxLengthB
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Int_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Int_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Fra_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Fra_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Sign_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Sign_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Fil_Chr = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Fil_Chr
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Fil_Point = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Fil_Point
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Dsp_Fmt = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Dsp_Fmt
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Focus_Ctl = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Focus_Ctl
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Err_Status = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Err_Status
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Locked = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Locked
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_ReSet_Dsp_Sub_Inf
	'   概要：  画面項目情報を再設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_ReSet_Dsp_Sub_Inf(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		For Index_Wk = 1 To pm_All.Dsp_Base.Item_Cnt
			'==================
			'画面項目名(ｺﾝﾄﾛｰﾙ名)
			'==================
			'        pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm = pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
			'==================
			'退避フォーカス制御
			'==================
			'初期処理時に定義されたFocus_Ctlの設定保持する
			'        pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl_Bk = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_Set_Body_Inf
	'   概要：  初期画面ボディ情報設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Set_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		''''    '最上明細ｲﾝﾃﾞｯｸｽ
		''''    pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		''''    '行初期化
		''''    ReDim pm_All.Dsp_Body_Inf.Row_Inf(0)
		''''    '列初期化
		''''    ReDim pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(0)
		''''
		''''    '初期化用の列初期化
		''''    ReDim pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(0)
		''''
		''''    '復元情報の無
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
		''''    '復元行初期化
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
		''''    '復元行情報初期化
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf = pm_All.Dsp_Body_Inf.Row_Inf(0)
		''''    '復元行情報初期化
		''''    ReDim pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(0)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_Not_Change
	'   概要：  ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集する
	'   　　　　KEYPRESSなどの入力中(未確定)のときに使用
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Not_Change(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'現在の表示内容を退避
		'    pm_Dsp_Sub_Inf.Detail.Dsp_Value = pm_Value
		'
		'    Select Case True
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        'ﾃｷｽﾄﾎﾞｯｸｽ
		'            'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
		'            pm_All.Dsp_Base.Change_Flg = True
		'            pm_Dsp_Sub_Inf.Ctl.Text = pm_Value
		'            'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ可
		'            pm_All.Dsp_Base.Change_Flg = False
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'        'ﾁｪｯｸﾎﾞｯｸｽ
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'        'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'        '垂直ｽｸﾛｰﾙﾊﾞｰ
		'            'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
		'            pm_All.Dsp_Base.VS_Scr_Flg = True
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'            pm_All.Dsp_Base.VS_Scr_Flg = False
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'        'ﾊﾟﾈﾙ
		'            pm_Dsp_Sub_Inf.Ctl.Caption = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'        'ｲﾒｰｼﾞ
		'            On Error Resume Next
		'            pm_Dsp_Sub_Inf.Ctl.Picture = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'        'ﾋﾟｸﾁｬｰﾎﾞｯｸｽ
		'            On Error Resume Next
		'            pm_Dsp_Sub_Inf.Ctl.Picture = pm_Value
		'
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		''@'        'ﾗﾍﾞﾙ
		''@'            pm_Dsp_Sub_Inf.Ctl.Caption = pm_Value
		'
		'    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_VScrl_Max
	'   概要：  ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに縦ｽｸﾛｰﾙ最大値を編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_Max(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'垂直ｽｸﾛｰﾙﾊﾞｰ(最大値)
					'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.Max の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.Max = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_VScrl_Min
	'   概要：  ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに縦ｽｸﾛｰﾙ最小値を編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_Min(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'垂直ｽｸﾛｰﾙﾊﾞｰ(最小値)
					'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.Min の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.Min = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_VScrl_LargeChange
	'   概要：  ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに最大ｽｸﾛｰﾙ量を編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_LargeChange(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'垂直ｽｸﾛｰﾙﾊﾞｰ(最大ｽｸﾛｰﾙ量)
					'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.LargeChange の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.LargeChange = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_VScrl_LargeChange
	'   概要：  ｽｸﾛｰﾙﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに最小ｽｸﾛｰﾙ量を編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_SmallChange(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'垂直ｽｸﾛｰﾙﾊﾞｰ(最小ｽｸﾛｰﾙ量)
					'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SmallChange の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SmallChange = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_Direct
	'   概要：  画面コントロール編集および復元内容/前回内容の退避を行う
	'   　　　　画面に直接編集する際に使用(確定時)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Direct(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(pm_Value, pm_Dsp_Sub_Inf, pm_All)
		
		'復元内容、前回内容を退避
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf, pm_Set_Flg)
		
		'項目色の初期設定
		Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_INITIAL_STATUS, pm_All, ITEM_COLOR_DEF)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Item_Value
	'   概要：  各コントロールの値を取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Item_Value(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Object
		
		'    CF_Get_Item_Value = Null
		'
		'    Select Case True
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        'ﾃｷｽﾄﾎﾞｯｸｽ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Text
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'        'ﾁｪｯｸﾎﾞｯｸｽ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'        'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'        '垂直ｽｸﾛｰﾙﾊﾞｰ
		'            'ﾁｪﾝｼﾞｲﾍﾞﾝﾄ不可
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'        'ﾊﾟﾈﾙ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Caption
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'        'ｲﾒｰｼﾞ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Picture
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'        'ﾋﾟｸﾁｬﾎﾞｯｸｽ
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Picture
		'
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		''@'        'ﾗﾍﾞﾙ
		''@'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Caption
		'
		'    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_Focus_Ctl
	'   概要：  ﾌｫｰｶｽ制御を編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		pm_Dsp_Sub_Inf.Detail.Focus_Ctl = pm_Value
		
		'TabStop設定
		'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is OLE Then
		'
		'        'TabStop初期化
		'        pm_Dsp_Sub_Inf.Ctl.TabStop = False
		'
		'        If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		'            'TabStop可能
		'            pm_Dsp_Sub_Inf.Ctl.TabStop = True
		'        End If
		'    End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Input_Ok_Item
	'   概要：  入力可能な文字だけ取り出す
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Input_Ok_Item(ByRef pm_Value As String, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As String
		Dim Trg_Value As String
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim wk_Moji As String
		Dim Wk_Value As String
		
		Rtn_Value = ""
		Trg_Value = pm_Value
		
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Or TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				Case IN_TYP_NUM
					'数値の場合
					'右側の空白を除去
					Trg_Value = RTrim(Trg_Value)
			End Select
			
			'入力可能文字だけ取り出す
			For Wk_Cnt = 1 To Len(Trg_Value)
				
				wk_Moji = Mid(Trg_Value, Wk_Cnt, 1)
				
				If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
					
					Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
						Case IN_TYP_NUM
							'数値の場合
							'数値として形式化する
							If Trim(wk_Moji) <> "" Then
								Select Case wk_Moji
									'｢＋｣入力時
									Case "+"
										If Rtn_Value = "" Then
											'最初に入力されている場合、ゼロ編集
											Rtn_Value = Rtn_Value & "0"
										End If
										'｢－｣入力時
									Case "-"
										If Rtn_Value = "" Then
											'最初に入力されている場合、OK
											Rtn_Value = Rtn_Value & wk_Moji
										End If
									Case "."
										'｢．｣入力時
										If InStr(Rtn_Value, ".") = 0 Then
											'｢．｣が１回目
											If Len(CF_Get_Num_Int_Part(Rtn_Value)) > 0 Then
												'整数部がある場合
												Rtn_Value = Rtn_Value & wk_Moji
											Else
												Rtn_Value = Rtn_Value & "0" & wk_Moji
											End If
										End If
										
									Case "0"
										'｢０｣入力時
										If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig = 0 Then
											'小数部無の場合
											If Len(Trg_Value) = Wk_Cnt Then
												'最後の桁の場合
												Rtn_Value = Rtn_Value & wk_Moji
											Else
												If Rtn_Value <> "" And Rtn_Value <> "0" And Rtn_Value <> "-0" And Rtn_Value <> "+0" Then
													'１番はじめの文字以外でかつ｢０｣がない場合
													Rtn_Value = Rtn_Value & wk_Moji
												End If
											End If
										Else
											'小数部有の場合
											If Rtn_Value <> "0" And Rtn_Value <> "-0" And Rtn_Value <> "+0" Then
												'｢０｣がない場合
												Rtn_Value = Rtn_Value & wk_Moji
											End If
											
										End If
									Case Else
										'その他は、CF_Jge_Input_Strで精査されている！！
										If Rtn_Value = "-0" Then
											Rtn_Value = "-" & wk_Moji
										Else
											Rtn_Value = Rtn_Value & wk_Moji
										End If
										
								End Select
							End If
						Case Else
							'数値の以外場合
							Rtn_Value = Rtn_Value & wk_Moji
							
					End Select
				End If
			Next 
			
		End If
		
		CF_Get_Input_Ok_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Trim_Item
	'   概要：  不必要な空白を削除
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Trim_Item(ByRef pm_Value As String, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As String
		Dim Rtn_Value As String
		
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Or TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'表示形式なし
			Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
				Case FIL_POINT_RIGHT
					'詰文字が右詰の場合、右空白を削除
					Rtn_Value = RTrim(pm_Value)
				Case FIL_POINT_LEFT
					'詰文字が左詰の場合、左空白を削除
					Rtn_Value = LTrim(pm_Value)
				Case FIL_POINT_CENTER
					'詰文字が左詰の場合、左空白を削除
					Rtn_Value = Trim(pm_Value)
			End Select
		Else
			Rtn_Value = pm_Value
		End If
		
		CF_Trim_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cnv_Dsp_Item
	'   概要：  対象項目の画面表示用に変換
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cnv_Dsp_Item(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_InPut_Flg As Boolean) As Object
		Dim Rtn_Value As Object
		Dim Rtn_Str_Value As String
		Dim Wk_Cnt As Short
		Dim Fil_Chr As String
		Dim Fil_Space As String
		Dim Wk_Str As String
		
		'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Rtn_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Rtn_Value = pm_Value
		
		'    Select Case True
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        'ﾃｷｽﾄﾎﾞｯｸｽ
		'            If pm_Dsp_Sub_Inf.Detail.In_Str_Typ = IN_STR_TYP_N Then
		'                '全角の場合
		'                Fil_Space = "　"
		'            Else
		'                '半角の場合
		'                Fil_Space = Space(1)
		'            End If
		'
		'            If pm_InPut_Flg = True Then
		'            '入力中の場合
		'                '強制的に空白を詰める場合
		'                Fil_Chr = Fil_Space
		'            Else
		'            '入力外の場合
		'                '画面項目情報のDsp_Sub_Inf.Detail.Fil_Chrを使用する場合
		'                Fil_Chr = pm_Dsp_Sub_Inf.Detail.Fil_Chr
		'            End If
		'
		'            '入力可能文字だけ取り出す
		'            Rtn_Str_Value = CF_Get_Input_Ok_Item(CStr(Rtn_Value), pm_Dsp_Sub_Inf)
		'
		'            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
		'                Case IN_TYP_NUM
		'                    '数値の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        '詰文字ありの場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                        '表示形式有
		'                            Wk_Str = Rtn_Str_Value
		'                            If pm_InPut_Flg = True Then
		'                            '入力中の場合
		'                                'まず整数部のみ編集（単価、率は金額と同じ）
		'                                If InStr(Rtn_Str_Value, "-") = 0 Then
		'                                    Wk_Str = Format(CF_Get_Num_Int_Part(Rtn_Str_Value), DSP_FMT_KIN_1)
		'                                Else
		'                                    Wk_Str = "-" & Format(Replace(CF_Get_Num_Int_Part(Rtn_Str_Value), "-", ""), DSP_FMT_KIN_1)
		'                                End If
		'                                If InStr(Rtn_Str_Value, ".") > 0 Then
		'                                '小数部がある場合
		'                                    Wk_Str = Wk_Str & "." & CF_Get_Num_Fra_Part(Rtn_Str_Value)
		'                                End If
		'                            Else
		'                                '入力外の場合
		'                                Wk_Str = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'
		'                            Rtn_Str_Value = Wk_Str
		'
		'                        End If
		'
		'                        '詰文字ありの場合
		'                        If Fil_Chr <> "" Then
		'                            Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                Case FIL_POINT_RIGHT
		'                                    '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                    Rtn_Str_Value = Rtn_Str_Value _
		''                                              & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                    '左からバイト数分だけ取得
		'                                    Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                Case FIL_POINT_LEFT
		'                                    '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
		'                                    Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                              & Rtn_Str_Value
		'                                    '右からバイト数分だけ取得
		'                                    Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                            End Select
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_DATE
		'                    '日付の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_DATE) Then
		'                        '入力形式が異なる場合
		'                            '詰文字ありの場合
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '左からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '右からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '表示形式有
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'                Case IN_TYP_CODE, IN_TYP_STR
		'                    'コード、文字の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        '詰文字ありの場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                            '表示形式有
		'                            Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                        Else
		'                            '表示形式なし
		'                            Rtn_Str_Value = CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf)
		'                        End If
		'
		'                        '詰文字ありの場合
		'                        If Fil_Chr <> "" Then
		'                            Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                Case FIL_POINT_RIGHT
		'                                    '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                    Rtn_Str_Value = Rtn_Str_Value _
		''                                              & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                    '左からバイト数分だけ取得
		'                                    Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                Case FIL_POINT_LEFT
		'                                    '詰文字が左詰の場合、詰文字をバイト数(桁数として使用)を左側に追加
		'                                    Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                              & Rtn_Str_Value
		'                                    '右からバイト数分だけ取得
		'                                    Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                            End Select
		'                        End If
		'
		'                    End If
		'                Case IN_TYP_YYYYMM
		'                    '年月の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_YYYMM) Then
		'                        '入力形式が異なる場合
		'                            '詰文字ありの場合
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '左からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '右からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '表示形式有
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_HHMM
		'                    '年月の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_HHMM) Then
		'                        '入力形式が異なる場合
		'                            '詰文字ありの場合
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '左からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '右からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '表示形式有
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_HHMMSS
		'                    '時分秒の場合
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '未入力の場合
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '入力ありの場合
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_HHMMSS) Then
		'                        '入力形式が異なる場合
		'                            '詰文字ありの場合
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '詰文字が右詰の場合、詰文字をバイト数(桁数として使用)を右側に追加
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '左からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '詰文字が左詰の場合、、詰文字をバイト数(桁数として使用)を左側に追加
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '右からバイト数分だけ取得
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '表示形式有
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_ELSE
		'                    'その他
		'            End Select
		'
		'            Rtn_Value = Rtn_Str_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'            'ﾁｪｯｸﾎﾞｯｸｽ
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'            'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'            '垂直ｽｸﾛｰﾙﾊﾞｰ
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'            'ﾊﾟﾈﾙ
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'            'ｲﾒｰｼﾞ
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'            'ﾋﾟｸﾁｬﾎﾞｯｸｽ
		'
		'    End Select
		'
		'    CF_Cnv_Dsp_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_Color
	'   概要：  対象項目の状態(ﾌｫｰｶｽ有無、ｴﾗｰ有無)によるの前景/背景色設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Color(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Item_Status As String, ByRef pm_All As Cls_All, Optional ByRef pm_Color_Mode As Short = ITEM_COLOR_NOMAL) As Short
		Dim Set_Focus As Boolean
		
		'フォーカス判定
		If pm_Color_Mode = ITEM_COLOR_DEF Then
			'初期化時は、強制的にフォーカスなしと判断
			Set_Focus = False
		Else
			'初期化以外の場合は、実際のフォーカス移動可を判定
			Set_Focus = CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		'色設定はﾃｷｽﾄﾎﾞｯｸｽのみ
		'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
		'        If Set_Focus = True Then
		'        'ﾌｫｰｶｽ受取ＯＫ
		'            Select Case pm_Item_Status
		'                Case ITEM_NORMAL_STATUS
		'                'フォーカスなし
		'
		'                    Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
		'                        '初期化、エラーなし
		'                        Case ERR_DEF, ERR_NOT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '読取専用
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                            End If
		'
		'                        '必須入力の未入力エラー
		'                        Case ERR_NOT_INPUT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_RED
		'
		'                        'その他エラー
		'                        Case ERR_ELSE
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '読取専用
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                            End If
		'
		'                    End Select
		'
		'                'フォーカスあり
		'                Case ITEM_SELECT_STATUS
		'
		'                    Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
		'                        '初期化、エラーなし
		'                        Case ERR_DEF, ERR_NOT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '読取専用
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                        '必須入力の未入力エラー
		'                        Case ERR_NOT_INPUT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '読取専用
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                        'その他エラー
		'                        Case ERR_ELSE
		'                            Select Case pm_Color_Mode
		'                                Case ITEM_COLOR_NOMAL
		'                                    '通常
		'                                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
		'                                Case ITEM_COLOR_KEYPRESS
		'                                    'KEYPRESS
		'                                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'
		'                            End Select
		'
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '読取専用
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                    End Select
		'
		'                Case ITEM_INITIAL_STATUS
		'                '初期状態
		'                    'エラーステイタスに関係なく通常の文字色を設定(初期設定状態)
		'                    '現在はCF_Set_Item_Direct専用
		'                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                    If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                    '読取専用
		'                        pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                    Else
		'                        pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                    End If
		'
		'            End Select
		'        Else
		'        'ﾌｫｰｶｽ受取ＮＧ
		'            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'            '読取専用
		'              pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'              pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'            Else
		'              pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'              pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'            End If
		'        End If
		'    End If
		
	End Function
	
	' === 20060804 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_Color_MEISAI
	'   概要：  明細の前景/背景色設定（前景/背景色戻し無し）
	'   引数：　なし
	'   戻値：　なし
	'   備考：  項目の色設定が規定と異なる画面にのみ使用
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Color_MEISAI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Item_Status As String, ByRef pm_All As Cls_All, Optional ByRef pm_Color_Mode As Short = ITEM_COLOR_NOMAL) As Short
		
		'色設定はﾃｷｽﾄﾎﾞｯｸｽのみ
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
				Select Case pm_Item_Status
					'フォーカスなし
					Case ITEM_NORMAL_STATUS
						
						Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
							'初期化、エラーなし
							Case ERR_DEF, ERR_NOT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'読取専用
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
								End If
								
								'必須入力の未入力エラー
							Case ERR_NOT_INPUT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_RED
								
								'その他エラー
							Case ERR_ELSE
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'読取専用
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
								End If
								
						End Select
						
						'フォーカスあり
					Case ITEM_SELECT_STATUS
						
						Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
							'初期化、エラーなし
							Case ERR_DEF, ERR_NOT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'読取専用
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
								'必須入力の未入力エラー
							Case ERR_NOT_INPUT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'読取専用
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
								'その他エラー
							Case ERR_ELSE
								Select Case pm_Color_Mode
									Case ITEM_COLOR_NOMAL
										'通常
										pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
									Case ITEM_COLOR_KEYPRESS
										'KEYPRESS
										pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
										
								End Select
								
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'読取専用
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
						End Select
						
				End Select
			Else
				'ﾌｫｰｶｽなし
				If pm_Dsp_Sub_Inf.Detail.Locked = False Then
					'入力可能な項目のみ初期化
					pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
					pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
				End If
			End If
		End If
		
	End Function
	' === 20060804 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Sel_Ini
	'   概要：  TextBoxを全て選択状態にする
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Sel_Ini(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Date_Sel_Kbn As String) As Short
		
		'TextBox場合のみ
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				'日付の場合
				Case IN_TYP_DATE
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_DATE_SLASH
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Chk_Date(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'日付として判定可能な場合
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'年の１０００の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'日の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'定義外はなし！！
								End Select
							Else
								'未入力の場合
								'一番左を選択
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'定義外はなし！！
					End Select
					
					'年月の場合
				Case IN_TYP_YYYYMM
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_YYYYMM_SLASH
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Chk_Date(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) & "/01") = True Then
								'年月として判定可能な場合
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'年の１０００の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'月の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'定義外はなし！！
								End Select
							Else
								'未入力の場合
								'一番左を選択
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'定義外はなし！！
					End Select
					
					'時刻の場合
				Case IN_TYP_HHMM
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_HHMM
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If IsDate(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'時刻として判定可能な場合
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'時の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'分の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'定義外はなし！！
								End Select
							Else
								'未入力の場合
								'一番左を選択
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'定義外はなし！！
					End Select
					
					'時分秒の場合
				Case IN_TYP_HHMMSS
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_HHMMSS
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If IsDate(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'時刻として判定可能な場合
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'時の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'秒の１０の位を選択
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'定義外はなし！！
								End Select
							Else
								'未入力の場合
								'一番左を選択
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'定義外はなし！！
					End Select
					
				Case Else
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'全選択
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = 0
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
					Else
						'詰文字が左詰以外の場合
						'１桁
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = 0
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = 1
					End If
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Item_SetFocus
	'   概要：  項目フォーカス移動処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_SetFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		' === 20060804 === UPDATE S - ACE)Sejima
		'D    '割当ｲﾝﾃﾞｯｸｽ取得
		'D    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)
		'D
		'D'@'    '前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
		'D'@'    pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
		'D
		'D'@'    '移動後のｲﾝﾃﾞｯｸｽを退避
		'D'@'    pm_All.Dsp_Base.Cursor_Idx = Trg_Index
		'D
		'D    'フォーカス移動
		'D    pm_Dsp_Sub_Inf.Ctl.SetFocus
		'D'@'    '選択状態の設定（初期選択）
		'D'@'    Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'D
		'D'@'    '項目色設定
		'D'@'    Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS)
		'D
		'D'@'    '現在のｫｰｶｽのｲﾝﾃﾞｯｸｽを設定
		'D'@'    pm_All.Dsp_Base.Cursor_Idx = Trg_Index
		' === 20060804 === UPDATE ↓
		
		Trg_Index = -1
		
		'ｲﾝﾃﾞｯｸｽが割り当てられているか？
		' （割り当てられていれば、そのｲﾝﾃﾞｯｸｽを取得）
		If IsNumeric(pm_Dsp_Sub_Inf.Ctl.Tag) = True Then
			Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		End If
		
		If Trg_Index >= 0 Then
			'割り当てられている場合
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.Button, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
					
					'使用可として、
					pm_Dsp_Sub_Inf.Ctl.Enabled = True
					'フォーカスをセット
					pm_Dsp_Sub_Inf.Ctl.Focus()
					
				Case Else
					
			End Select
			
		Else
			'割り当てられていない場合は何もしない
			
		End If
		' === 20060804 === UPDATE E
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Input_Str
	'   概要：  入力文字を判定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Input_Str(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef Pm_Moji As String) As Short
		'初期化（入力不可）
		CF_Jge_Input_Str = 0
		
		'共通制御
		
		'入力文字タイプで制御
		Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
			Case IN_STR_TYP_NUM
				'数値のみ０～９
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then
					CF_Jge_Input_Str = 1
				End If
				
			Case IN_STR_TYP_KIN
				'数量・金額・単価系
				'数値＆空白
				If InStr("0123456789 ", Pm_Moji) > 0 Then
					CF_Jge_Input_Str = 1
				End If
				
				'符号
				If CF_Jge_Input_Str = 0 Then
					Select Case pm_Dsp_Sub_Inf.Detail.Num_Sign_Fig
						Case IN_NUM_PLUS
							'ﾌﾟﾗｽ
							If InStr("+", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
						Case IN_NUM_MINUS
							'ﾏｲﾅｽ
							If InStr("-", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
						Case IN_NUM_PLUS_MINUS
							'両方
							If InStr("+-", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
					End Select
				End If
				
				'小数点
				If CF_Jge_Input_Str = 0 Then
					If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And InStr(".", Pm_Moji) > 0 Then
						CF_Jge_Input_Str = 1
					End If
				End If
				
			Case IN_STR_TYP_X
				'半角
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) And CF_Ctr_AnsiLenB(Pm_Moji) = 1 Then
					CF_Jge_Input_Str = 1
					If Pm_Moji = "　" Then
						Pm_Moji = Space(1)
					End If
				End If
				
			Case IN_STR_TYP_N
				'全角
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) And CF_Ctr_AnsiLenB(Pm_Moji) = 2 Then
					CF_Jge_Input_Str = 1
				End If
				
			Case IN_STR_TYP_NX
				'全混在
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then
					CF_Jge_Input_Str = 1
					If Pm_Moji = "　" Then
						Pm_Moji = Space(1)
					End If
				End If
				
			Case IN_STR_TYP_TEL
				'電話・FAX系
				If InStr("0123456789- ", Pm_Moji) > 0 Then
					CF_Jge_Input_Str = 1
				End If
				
		End Select
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyDelete
	'   概要：  対象項目のKEYDELETEの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyDelete(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_DelMoji As String
		Dim Wk_CurMoji As String
		
		
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
			
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM, IN_TYP_HHMMSS
					'日付/年月/時刻/時分秒の場合
					'削除不可
					Exit Function
			End Select
			
			If All_Sel_Flg = True Then
				'全選択時
				'全て空白として削除
				Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
				
				'削除後の文字を表示形式に変換
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
				
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'開始位置を一番右へ
					Wk_SelStart = Len(Wk_DspMoji)
					Wk_SelLength = 0
				Else
					'詰文字が左詰以外の場合
					'開始位置を一番左へ
					Wk_SelStart = 0
					Wk_SelLength = 1
				End If
				
				'削除後の文字置き換え
				'文字設定
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'削除後のSelStartを決定
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
				'削除後のSelLengthを決定
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
			Else
				
				If Act_SelStart >= Len(Wk_CurMoji) Then
					'開始位置が一番右の場合
					'削除なし
					Exit Function
				End If
				
				If Act_SelLength = 0 Then
					'選択なしの場合
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						
						If Act_SelStart = 0 Then
							'開始位置が一番左の場合
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
							
						Else
							'開始位置が一番左以外の場合
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
						End If
						
						'削除文字の判定
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'削除文字が入力対象の文字の場合
							If Act_SelStart = 0 Then
								'開始位置が一番左の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Right(Wk_CurMoji, Len(Wk_CurMoji) - 1)
									
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'文字編集
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								
							End If
						Else
							'削除文字が入力対象の文字の以外場合
							'削除不可
							Exit Function
						End If
						
						'削除後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'編集後のSelStartを決定
						Wk_SelStart = Act_SelStart
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'削除後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'削除後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Else
						'詰文字が左詰以外の場合
						'削除対象の文字１桁を取得
						Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						'削除文字の判定
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'削除文字が入力対象の文字の場合
							If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
								'文字編集
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Right(Wk_CurMoji, Len(Wk_CurMoji) - Act_SelStart - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							Else
								'削除対象がない為、空白を編集
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							End If
						Else
							'削除文字が入力対象の文字の以外場合
							'削除不可
							Exit Function
						End If
						
						'削除後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'編集後のSelStartを決定
						Wk_SelStart = Act_SelStart
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'削除後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'削除後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					End If
				Else
					'一部選択
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'削除対象の文字１桁を取得
						Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						'削除文字の判定
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'削除文字が入力対象の文字の場合
							If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
								'文字編集
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + 1 + 1)
							Else
								'削除対象がない為、空白を編集
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							End If
						Else
							'削除文字が入力対象の文字の以外場合
							'削除不可
							Exit Function
						End If
						
						'削除後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'編集後のSelStartを決定
						Wk_SelStart = Act_SelStart
						'編集後のSelLengthを決定
						Wk_SelLength = 1
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'数値項目で未入力の場合は、一番右を開始位置に設定
							If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
								Wk_SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								Wk_SelLength = 0
							End If
						End If
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'削除後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'削除後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Else
						'詰文字が左詰以外の場合
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_STR Then
							'文字項目の場合
							'文字編集
							Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
							
							'削除後の文字置き換え
							'文字設定
							Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
							
							'削除後のSelStartを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
							'削除後のSelLengthを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
							
						Else
							'文字項目以外の場合
							
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
							
							'削除文字の判定
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'削除文字が入力対象の文字の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + 1 + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'削除文字が入力対象の文字の以外場合
								'削除不可
								Exit Function
							End If
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
							
							'削除後の文字置き換え
							'文字設定
							Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
							
							'削除後のSelStartを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
							'削除後のSelLengthを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
							
						End If
					End If
				End If
				
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyDelete
	'   概要：  対象項目のINSERTの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyInsert(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		
		'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			
			If Act_SelLength = 0 Then
				'選択なしの場合
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Ctl.SelLength = 1
			Else
				'一部選択あり場合
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Ctl.SelLength = 0
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Clr_Dsp(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		If pm_Mode = ITM_ALL_CLR Then
			'画面初期処理および画面全体初期化の場合
			
			'前回内容をクリア
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Dsp_Sub_Inf.Detail.Bef_Value = System.DBNull.Value
			'前回内容フラグをクリア
			pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_DEF
			
			'復元内容をクリア
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Dsp_Sub_Inf.Detail.Rest_Value = System.DBNull.Value
			'復元内容フラグをクリア
			pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = VALUE_FLG_DEF
			
			'ﾕｰｻﾞｰ入力無
			pm_Dsp_Sub_Inf.Detail.In_Value_Flg = False
			
			'項目復元フラグＮＧ
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
			
			'フォーカス制御を退避内容から取得
			Call CF_Set_Item_Focus_Ctl(pm_Dsp_Sub_Inf.Detail.Focus_Ctl_Bk, pm_Dsp_Sub_Inf)
			
			'未入力以外のチェック済フラグ
			pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False
			
		End If
		
		'チェック関数呼出元処理を初期化
		pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
		
		'項目色の初期設定
		Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All, ITEM_COLOR_DEF)
		
		'ﾃｷｽﾄﾎﾞｯｸｽ
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			Call CF_Set_Item_Direct(Space(pm_Dsp_Sub_Inf.Detail.MaxLengthB), pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'ﾁｪｯｸﾎﾞｯｸｽ
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox Then
			Call CF_Set_Item_Direct(False, pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton Then
			Call CF_Set_Item_Direct(False, pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'@'    'ﾗﾍﾞﾙ
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'@'        Call CF_Set_Item_Direct(Space(pm_Dsp_Sub_Inf.Detail.MaxLengthB), pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		'@'    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function CF_Init_Clr_Dsp_Body(pm_Bd_Index As Integer, pm_Mode As Integer, pm_All As Cls_All) As Integer
	''''
	''''    If pm_Mode = BODY_ALL_CLR Then
	''''        '最上明細ｲﾝﾃﾞｯｸｽ
	''''        pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
	''''        '復元情報の無
	''''        pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
	''''        '復元行初期化
	''''        pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
	''''    End If
	''''
	''''    '初期状態
	''''    pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Status = BODY_ROW_STATE_DEFAULT
	''''
	''''End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Copy_Dsp_Body_Row_Inf
	'   概要：  Dsp_Body_Row_Infでコピーする
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function CF_Copy_Dsp_Body_Row_Inf(pm_Moto_Body_Row As Cls_Dsp_Body_Row_Inf, pm_Saki_Body_Row As Cls_Dsp_Body_Row_Inf) As Integer
	''''
	''''    Dim Max_Col            As Integer
	''''    Dim Wk_Col             As Integer
	''''
	''''    '１行単位の業務情報
	''''    pm_Saki_Body_Row.Bus_Inf = pm_Moto_Body_Row.Bus_Inf
	''''    '対象行の状態
	''''    pm_Saki_Body_Row.Status = pm_Moto_Body_Row.Status
	''''
	''''    Max_Col = UBound(pm_Moto_Body_Row.Item_Detail)
	''''    ReDim pm_Saki_Body_Row.Item_Detail(Max_Col)
	''''
	''''    '項目単位列
	''''    For Wk_Col = 1 To Max_Col
	''''        pm_Saki_Body_Row.Item_Detail(Wk_Col) = pm_Moto_Body_Row.Item_Detail(Wk_Col)
	''''    Next
	''''
	''''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_Item_Base
	'   概要：  文字コード、桁数、属性チェック
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Item_Base(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Input_Value As Object) As Short
		
		Dim Str_Value As String
		Dim Wk_Cnt As Short
		Dim wk_Moji As String
		Dim wk_Moji_Err As Short
		Dim Str_Input As String
		
		'初期化
		CF_Chk_Item_Base = CHK_BASE_OK
		'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Input_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Input_Value = pm_Value
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽ
				'UPGRADE_WARNING: オブジェクト pm_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Str_Value = CStr(pm_Value)
				
				'エラー文字件数初期化
				wk_Moji_Err = 0
				
				'入力文字初期化
				Str_Input = ""
				
				'文字分だけ繰り返す
				For Wk_Cnt = 1 To Len(Str_Value)
					wk_Moji = Mid(Str_Value, Wk_Cnt, 1)
					
					If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
						'入力可能文字、OK
						Str_Input = Str_Input & wk_Moji
					Else
						'入力不可能文字
						If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
							'表示形式以外の文字の場合、エラー
							If InStr(pm_Dsp_Sub_Inf.Detail.Dsp_Fmt, wk_Moji) = 0 Then
								'入力値エラー
								wk_Moji_Err = wk_Moji_Err + 1
								Exit For
							End If
						Else
							'表示形式なし
							'入力値エラー
							wk_Moji_Err = wk_Moji_Err + 1
							Exit For
						End If
					End If
				Next 
				
				If wk_Moji_Err > 0 Then
					'コードエラー
					CF_Chk_Item_Base = CHK_BASE_ERR_CODE
				Else
					'桁数チェック
					If CF_Ctr_AnsiLenB(CF_Trim_Item(Str_Input, pm_Dsp_Sub_Inf)) > pm_Dsp_Sub_Inf.Detail.MaxLengthB Then
						'桁数エラー
						CF_Chk_Item_Base = CHK_BASE_ERR_OVER
					Else
						
						'入力タイプ
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_NUM
								'数値の場合
								If IsNumeric(Str_Input) = False Then
									'属性エラー
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
							Case IN_TYP_DATE
								'日付の場合
								If CF_Chk_Date(VB6.Format(Str_Input, "@@@@/@@/@@")) = False Then
									'属性エラー
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
							Case IN_TYP_CODE
								'コード系の場合
								'特になし
								
							Case IN_TYP_STR
								'文字の場合
								'特になし
								
							Case IN_TYP_YYYYMM
								'年月の場合
								If CF_Chk_Date(VB6.Format(Str_Input & "/01", "@@@@/@@")) = False Then
									'属性エラー
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
							Case IN_TYP_HHMM
								'時刻の場合
								If IsDate(VB6.Format(Str_Input, "@@:@@")) = False Then
									'属性エラー
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
							Case IN_TYP_HHMMSS
								'時分秒の場合
								If IsDate(VB6.Format(Str_Input, "@@:@@:@@")) = False Then
									'属性エラー
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
						End Select
					End If
					
				End If
				
				'正常時、入力値を戻す
				If CF_Chk_Item_Base = CHK_BASE_OK Then
					'UPGRADE_WARNING: オブジェクト pm_Input_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Input_Value = Str_Input
				End If
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				'ﾁｪｯｸﾎﾞｯｸｽ
				'特になし
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
				'特になし
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				'ﾋﾟｸﾁｬﾎﾞｯｸｽ
				'特になし
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Chk_From_Process
	'   概要：  チェック関数呼出元処理の設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Chk_From_Process(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_All As Cls_All) As Short
		
		Dim DspValue As Object
		
		'現在の表示を形式化する
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト DspValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DspValue = CF_Cnv_Dsp_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
		'文字設定
		Call CF_Set_Item_Not_Change(DspValue, pm_Dsp_Sub_Inf, pm_All)
		
		Select Case pm_Process
			Case CHK_FROM_LOSTFOCUS
				'ﾛｽﾄﾌｫｰｶｽからの呼出時
				If pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT Or pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_LOSTFOCUS Then
					'現在のチェック関数呼出元処理が初期状態かﾛｽﾄﾌｫｰｶｽの場合
					'ﾛｽﾄﾌｫｰｶｽとする
					pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_LOSTFOCUS
					
				End If
				
			Case Else
				'その他の場合は、そのまま設定
				pm_Dsp_Sub_Inf.Detail.Chk_From_Process = pm_Process
				
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Bef_Rest_Value
	'   概要：  復元内容、前回内容を退避
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Bef_Rest_Value(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		Dim Dsp_Value As Object
		'現在内容
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Dsp_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		Select Case pm_Set_Flg
			Case SET_FLG_NOMAL
				'通常編集の場合
				'前回内容/復元内容を退避する
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'前回内容と現在内容が異なる場合
					'復元内容に前回内容を編集
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'復元内容フラグに前回内容フラグ
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'前回内容に現在内容を編集
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'前回内容フラグに初期値以外
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
			Case SET_FLG_DEF
				'初期値編集の場合
				'前回チェック内容/前回内容/復元内容を編集
				
				'復元内容に前回内容を編集
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
				'復元内容フラグに前回内容フラグ
				pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
				If pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg <> VALUE_FLG_DEF Then
					'復元内容が初期値以外の場合
					'項目復元ＯＫ
					pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
				Else
					'復元内容が初期値の場合
					'項目復元ＮＧ
					pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = False
				End If
				
				'前回内容に現在内容を編集
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
				'前回内容フラグに初期値以外
				pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_DEF
				
				'前回チェック内容に初期値を編集
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'項目のエラー状態に初期値を編集
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
				
				'項目初期化ＮＧ
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = False
				
				'チェック関数呼出元処理を初期化
				pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
				
				'未入力以外のチェック済フラグ
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False
				
			Case SET_FLG_DB
				'ＤＢ値編集の場合
				'入力/表示項目の区別なく、前回チェック内容/前回内容/復元内容
				'を編集
				
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'前回内容と現在内容が異なる場合
					'復元内容に前回内容を編集
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'復元内容フラグに前回内容フラグ
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'前回内容に現在内容を編集
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'前回内容フラグに初期値以外
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
				'前回チェック内容に画面表示内容を編集
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'項目のエラー状態にエラーなしを編集
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
				
				'項目初期化ＯＫ
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
				
				'未入力以外のチェック済フラグをチェック済みに編集
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
				
			Case SET_FLG_DB_ERR
				'ＤＢ値編集の場合(エラーあり)
				'入力/表示項目の区別なく、前回チェック内容/前回内容/復元内容
				'を編集
				
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'前回内容と現在内容が異なる場合
					'復元内容に前回内容を編集
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'復元内容フラグに前回内容フラグ
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'前回内容に現在内容を編集
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'前回内容フラグに初期値以外
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
				'前回チェック内容に画面表示内容を編集
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'項目のエラー状態に初期値を編集
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
				
				'項目初期化ＯＫ
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
				
				'未入力以外のチェック済フラグをチェック済みに編集
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Bd_Idx_To_Idx
	'   概要：  Dsp_Sub_Infの明細ＮＯからpm_All.Dsp_Body_Infの行ＮＯに変換
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Bd_Idx_To_Idx(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index = 0 Then
		''''        'ゼロ
		''''        CF_Bd_Idx_To_Idx = 0
		''''    Else
		''''        '(画面の最上行のpm_All.Dsp_Body_Infｲﾝﾃﾞｯｸｽ)＋(画面上のDsp_Sub_Infの明細ＮＯ)－１
		''''        CF_Bd_Idx_To_Idx = pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_Dsp_Sub_Inf.Detail.Body_Index - 1
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Idx_To_Bd_Idx
	'   概要：  pm_All.Dsp_Body_Infの行ＮＯからDsp_Sub_Infの明細Ｏに変換
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Idx_To_Bd_Idx(ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		''''    '(対象行)－(画面の最上行のpm_All.Dsp_Body_Infｲﾝﾃﾞｯｸｽ)＋－１
		''''    CF_Idx_To_Bd_Idx = pm_Row - pm_All.Dsp_Body_Inf.Cur_Top_Index + 1
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Body_Focus_Ctl_Fst_Idx
	'   概要：  対象行の入力可能な最初の列のインデックスを取得
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Body_Focus_Ctl_Fst_Idx(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Index_Wk As Short
		Dim Index_Wk As Short
		
		Rtn_Index_Wk = 0
		
		'ボディ部内で処理
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Bd_Index Then
				'対象の明細部ＮＯの場合
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					Rtn_Index_Wk = Index_Wk
					Exit For
				End If
			End If
		Next 
		
		CF_Get_Body_Focus_Ctl_Fst_Idx = Rtn_Index_Wk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Body_Focus_Ctl_Lst_Idx
	'   概要：  対象行の入力可能な最後の列のインデックスを取得
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Body_Focus_Ctl_Lst_Idx(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Index_Wk As Short
		Dim Index_Wk As Short
		
		Rtn_Index_Wk = 0
		
		'ボディ部内で処理
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx - 1 To pm_All.Dsp_Base.Body_Fst_Idx Step -1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Bd_Index Then
				'対象の明細部ＮＯの場合
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					Rtn_Index_Wk = Index_Wk
					Exit For
				End If
			End If
		Next 
		
		CF_Get_Body_Focus_Ctl_Lst_Idx = Rtn_Index_Wk
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Focus_Ctl
	'   概要：  フォーカスを受け取れる状態かを取得
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Focus_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index = 0 Then
		''''    'コントロール配列以外の場合
		''''        If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		''''            If pm_Dsp_Sub_Inf.Ctl.Enabled = True _
		'''''            And pm_Dsp_Sub_Inf.Ctl.Visible = True Then
		''''                Rtn_Value = True
		''''            End If
		''''        End If
		''''    Else
		''''    'コントロール配列の場合
		''''        'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status <> BODY_ROW_STATE_DEFAULT Then
		''''        '初期状態以外の場合
		''''            If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		''''                If pm_Dsp_Sub_Inf.Ctl.Enabled = True _
		'''''                And pm_Dsp_Sub_Inf.Ctl.Visible = True Then
		''''                    Rtn_Value = True
		''''                End If
		''''            End If
		''''        End If
		''''    End If
		''''
		''''    CF_Set_Focus_Ctl = Rtn_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Body_Row_Status
	'   概要：  入力系の明細情報の行状態を最適化する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Body_Row_Status(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Row              As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Fst_Def_Row         As Integer
		''''    Dim Iput_Wait_Next_Row  As Integer
		''''
		''''    '｢入力待状態｣の行
		''''    '｢最終準備行｣の行
		''''    '最初の初期状態の行を取得
		''''    Iput_Wait_Row = 0
		''''    Lst_Row = 0
		''''    Fst_Def_Row = 0
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''        '｢入力待状態｣
		''''            Iput_Wait_Row = Wk_Row
		''''        End If
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''        '｢最終準備行｣
		''''            Lst_Row = Wk_Row
		''''        End If
		''''
		''''        '最初の｢初期状態｣
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT _
		'''''        And Fst_Def_Row = 0 Then
		''''            Fst_Def_Row = Wk_Row
		''''        End If
		''''
		''''    Next
		''''
		''''    Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''        Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''        '｢登録系｣の場合
		''''
		''''            If Lst_Row = 0 Then
		''''            '｢最終準備行｣がない場合
		''''                If Iput_Wait_Row = 0 Then
		''''                '｢入力待状態｣がない場合
		''''                    '｢最終準備行｣を設定
		''''                    If Fst_Def_Row > 0 Then
		''''                    '｢初期状態｣がある場合
		''''' === 20060817 === UPDATE S - ACE)Sejima 最大明細数の考慮
		'''''D                        '最初の｢初期状態の行｣⇒｢最終準備行｣
		'''''D                        pm_All.Dsp_Body_Inf.Row_Inf(Fst_Def_Row).Status = BODY_ROW_STATE_LST_ROW
		''''' === 20060817 === UPDATE ↓
		''''                        '対象の行が最大明細数を超えない場合
		''''                        If Fst_Def_Row <= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''                            '最初の｢初期状態の行｣⇒｢最終準備行｣
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Fst_Def_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''' === 20060817 === UPDATE E
		''''                    End If
		''''                Else
		''''                '｢入力待状態｣がある場合
		''''                    '｢入力待状態｣の次の行を検索
		''''                    Iput_Wait_Next_Row = Iput_Wait_Row + 1
		''''
		''''                    If Iput_Wait_Next_Row > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''                    '｢入力待状態｣の次の行が配列を超えた場合
		''''                        '｢入力待状態｣→｢最終準備行｣
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                    Else
		''''                    '｢入力待状態｣の次の行が配列内の場合
		''''                        If pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Next_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''                        '｢入力待状態｣の次の行が｢初期状態｣の場合
		''''                            '｢入力待状態｣→｢最終準備行｣
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''                    End If
		''''
		''''                End If
		''''            Else
		''''            '｢最終準備行｣がある場合
		''''                If Iput_Wait_Row > 0 Then
		''''                '｢入力待状態｣がある場合
		''''                    '｢最終準備行｣→｢初期状態｣
		''''                    pm_All.Dsp_Body_Inf.Row_Inf(Lst_Row).Status = BODY_ROW_STATE_DEFAULT
		''''
		''''                    '｢入力待状態｣の次の行を検索
		''''                    Iput_Wait_Next_Row = Iput_Wait_Row + 1
		''''
		''''                    If Iput_Wait_Next_Row > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''                    '｢入力待状態｣の次の行が配列を超えた場合
		''''                        '｢入力待状態｣→｢最終準備行｣
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                    Else
		''''                    '｢入力待状態｣の次の行が配列内の場合
		''''                        If pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Next_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''                        '｢入力待状態｣の次の行が｢初期状態｣の場合
		''''                            '｢入力待状態｣→｢最終準備行｣
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''                    End If
		''''
		''''                End If
		''''            End If
		''''    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Dell_Refresh_Body_Inf
	'   概要：  画面ボディ情報を画面表示状態に合わせて再設定する
	'   　　：  不要行を削除
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dell_Refresh_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		''''        '最大行退避
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '｢初期状態｣の行
		''''        '｢入力待状態｣の行
		''''        '｢最終準備行｣の行と
		''''        'を取得する
		''''        Def_Cnt = 0
		''''        Iput_Cnt = 0
		''''        Iput_Wait_Row = 0
		''''        Lst_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '｢初期状態｣
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''            '｢入力済状態｣
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            '｢入力待状態｣
		''''                Iput_Wait_Row = Wk_Row
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            '｢最終準備行｣
		''''                Lst_Row = Wk_Row
		''''            End If
		''''
		''''        Next
		''''
		''''        '｢入力待状態｣と｢最終準備行｣のどちらかがある場合
		''''        If Iput_Wait_Row > 0 Or Lst_Row > 0 Then
		''''            If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		''''            '最上明細ｲﾝﾃﾞｯｸｽ＝１の場合
		''''                If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		'''''                And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		''''                End If
		''''            Else
		''''                If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		'''''                And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                '｢初期状態｣の行が画面移動量以上でかつ
		''''                '画面表示明細数より配列が多い場合
		''''                    '最大明細行を１行減らす
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		''''                End If
		''''            End If
		''''
		''''            'スクロールバーの最大値を再設定
		''''            Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''        End If
		''''
		''''        '明細情報の行状態を再設定
		''''        Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Add_Refresh_Body_Inf
	'   概要：  画面ボディ情報を画面表示状態に合わせて再設定する
	'   　　：  必要行を追加
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Add_Refresh_Body_Inf(ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		''''
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Max_Row_Up_Flg      As Boolean
		''''    Dim Max_Row_Up          As Integer
		''''
		''''    '初期化、逆転させる！
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		''''        '最大行退避
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '｢初期状態｣の行
		''''        '｢入力待状態｣の行
		''''        '｢最終準備行｣の行と
		''''        'を取得する
		''''        Def_Cnt = 0
		''''        Iput_Cnt = 0
		''''        Iput_Wait_Row = 0
		''''        Lst_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '｢初期状態｣
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''            '｢入力済状態｣
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            '｢入力待状態｣
		''''                Iput_Wait_Row = Wk_Row
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            '｢最終準備行｣
		''''                Lst_Row = Wk_Row
		''''            End If
		''''
		''''        Next
		''''
		''''        Max_Row_Up_Flg = False
		''''        If Max_Row < pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''        '最大入力明細数に到達していない場合
		''''            '最大明細行を追加する
		''''            Max_Row_Up_Flg = True
		''''        Else
		''''            If Iput_Wait_Row = 0 And Lst_Row = 0 Then
		''''            '｢入力待状態｣と｢最終準備行｣ない場合
		''''                If Iput_Cnt >= pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                '｢入力済状態｣が画面最大表示件数以上
		''''                    '入力可能行を作成する
		''''                    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''                    '最大入力明細数が設定されいる場合
		''''                        If Max_Row < pm_All.Dsp_Base.Max_Body_Cnt Then
		''''                        '最大入力明細数に到達していない場合
		''''                            '最大明細行を追加する
		''''                            Max_Row_Up_Flg = True
		''''                        End If
		''''                    Else
		''''                        '最大明細行を追加する
		''''                        Max_Row_Up_Flg = True
		''''                    End If
		''''                End If
		''''            End If
		''''        End If
		''''
		''''        If Max_Row_Up_Flg = True Then
		''''        '最大明細行を追加する場合
		''''            If pm_All.Dsp_Base.Dsp_Body_Cnt >= Max_Row Then
		''''            '現在の最大明細行が画面の最大表示行以下の場合(１ページ以内)
		''''                '画面最大表示行＋画面ページ移動量
		''''                Max_Row_Up = pm_All.Dsp_Base.Dsp_Body_Cnt + pm_All.Dsp_Base.Dsp_Body_Move_Qty
		''''            Else
		''''            '現在の最大明細行が画面の最大表示行を超えるの場合（２ページ以上）
		''''                Max_Row_Up = Max_Row + 1
		''''            End If
		''''
		''''            'pm_All.Dsp_Body_Infの行を追加
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row_Up)
		''''            '追加行分だけ初期化
		''''            For Wk_Row = Max_Row + 1 To Max_Row_Up
		''''                '配列０の初期情報を対象行にコピー
		''''                Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''            Next
		''''
		''''            'スクロールバーの最大値を再設定
		''''            Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''            '明細行追加後の開始と終了を設定
		''''            pm_Row_Inf_Max_S = Max_Row + 1
		''''            pm_Row_Inf_Max_E = Max_Row_Up
		''''
		''''        End If
		''''
		''''        '明細情報の行状態を再設定
		''''        Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    End If
		''''
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Re_Crt_Body_Inf
	'   概要：  画面で項目入力された場合に明細情報を再作成する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Re_Crt_Body_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		''''    Dim Bd_Index            As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Max_Row_Up_Flg      As Boolean
		''''    Dim Max_Row_Up          As Integer
		''''
		''''    '初期化、逆転させる！
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''    'コントロール配列の場合
		''''        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) = pm_Dsp_Sub_Inf.Detail.Bef_Value Then
		''''            Exit Function
		''''        End If
		''''
		''''        'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''        '画面ボディ行状態を入力状態に設定
		''''        pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
		''''
		''''        '画面ボディ行の配列を再作成
		''''        Call CF_Add_Refresh_Body_Inf(pm_All, pm_Row_Inf_Max_S, pm_Row_Inf_Max_E)
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Bd_Vs_Scrl_Max
	'   概要：  現在の明細情報から縦スクロールバーの最大値を設定
	'   　　　　画面の内容をpm_All.Dsp_Body_Infに退避する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Bd_Vs_Scrl_Max(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Value    As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		''''        Wk_Value = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''        If Wk_Value < 0 Then
		''''            Wk_Value = 1
		''''        End If
		''''        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''            Call CF_Set_VScrl_Max(Wk_Value, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''        End If
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Body_Bkup
	'   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
	'   　　　　画面の内容をpm_All.Dsp_Body_Infに退避する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Bkup(ByRef pm_All As Cls_All) As Short
		
		''''    Dim WK_Dsp_Body_Inf    As Cls_Dsp_Body_Inf
		''''    Dim Max_Row            As Integer
		''''    Dim Wk_Row             As Integer
		''''    Dim Wk_Dsp_Row         As Integer
		''''    Dim Bd_Col_Index       As Integer
		''''    Dim Index_Wk            As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		''''        '現在の最大行を取得
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '一時退避
		''''        ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''        For Wk_Row = 1 To Max_Row
		''''            '対象行にコピー
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''        Next
		''''
		''''        Wk_Dsp_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If Wk_Row >= pm_All.Dsp_Body_Inf.Cur_Top_Index _
		'''''            And Wk_Row <= pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 Then
		''''            '現在表示されている明細
		''''
		''''                '１行単位の情報をまず設定
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''                Wk_Dsp_Row = Wk_Dsp_Row + 1
		''''                Bd_Col_Index = 0
		''''                'ボディ部内で処理
		''''                For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''                    If Wk_Dsp_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index Then
		''''                    '対象の明細行の場合
		''''                        Bd_Col_Index = Bd_Col_Index + 1
		''''                        '画面項目詳細情報を設定
		''''                        '条件によって変更される項目のみ
		''''                        Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Bd_Col_Index) _
		'''''                                                          , pm_All.Dsp_Sub_Inf(Index_Wk).Detail)
		''''
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Bd_Col_Index).Dsp_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
		''''                    End If
		''''
		''''                    If Wk_Dsp_Row < pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index Then
		''''                    '対象の明細行を超えた場合終了
		''''                        Exit For
		''''                    End If
		''''                Next
		''''
		''''            Else
		''''            '現在表示されている以外の明細
		''''                '対象行にコピー
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''            End If
		''''        Next
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Body_Dsp
	'   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
	'   　　　　sp_Body_Infを画面に編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Dsp(ByRef pm_All As Cls_All) As Short
		''''    Dim Index_Wk        As Integer
		''''    Dim Bd_Index        As Integer
		''''    Dim Bd_Index_Bk     As Integer
		''''    Dim Bd_Col_Index    As Integer
		''''    Dim Cur_Top_Index   As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		'''''============================================================================
		''''        '最上明細ｲﾝﾃﾞｯｸｽの再設定
		''''        If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 _
		'''''          > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''        '現在の最上明細ｲﾝﾃﾞｯｸｽから画面表示した場合に
		''''        '配列数が足りない場合
		''''            '最上明細ｲﾝﾃﾞｯｸｽを表示可能な一番下の行に設定
		''''            Cur_Top_Index = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''            If Cur_Top_Index <= 0 Then
		''''                Cur_Top_Index = 1
		''''            End If
		''''            pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
		''''            If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''                '縦スクロールバーを設定
		''''                Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''            End If
		''''        End If
		'''''============================================================================
		''''
		''''        'ボディ部内で処理
		''''        Bd_Index = 0
		''''        Bd_Index_Bk = 0
		''''
		''''        For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''            If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
		''''
		''''                'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''                Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		''''
		''''                If Bd_Index_Bk <> Bd_Index Then
		''''                '明細行ブレイク
		''''                    Bd_Col_Index = 1
		''''                    Bd_Index_Bk = Bd_Index
		''''                Else
		''''                    Bd_Col_Index = Bd_Col_Index + 1
		''''                End If
		''''
		''''                '画面項目詳細情報を設定
		''''                '条件によって変更される項目のみ
		''''                Call CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(pm_All.Dsp_Sub_Inf(Index_Wk).Detail, pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(Bd_Col_Index))
		''''
		''''                '項目の情報が変更される情報をコントロールに設定
		''''                'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		''''                Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		''''                'ﾌｫｰｶｽ制御
		''''                Call CF_Set_Item_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl, pm_All.Dsp_Sub_Inf(Index_Wk))
		''''                'コントロールの前景/背景色
		''''                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_NORMAL_STATUS, pm_All)
		''''
		''''            End If
		''''
		''''        Next
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Dsp_Body_Inf_To_Dsp_Sub_Inf
	'   概要：  ｢画面ボディ情報｣⇒｢画面項目情報｣に編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(ByRef pm_Dsp_Sub_Inf_Detail As Cls_Dsp_Sub_Detail_Inf, ByRef pm_Dsp_Body_Row_Inf_Item_Detail As Cls_Dsp_Sub_Detail_Inf) As Short
		
		'画面項目詳細情報を設定
		'条件によって変更される項目のみ
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf_Detail.Dsp_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value
		pm_Dsp_Sub_Inf_Detail.Focus_Ctl = pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl
		pm_Dsp_Sub_Inf_Detail.Focus_Ctl_Bk = pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl_Bk
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf_Detail.Bef_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value
		pm_Dsp_Sub_Inf_Detail.Bef_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value_Flg
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf_Detail.Rest_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value
		pm_Dsp_Sub_Inf_Detail.Rest_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value_Flg
		pm_Dsp_Sub_Inf_Detail.In_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.In_Value_Flg
		pm_Dsp_Sub_Inf_Detail.Item_Init_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Item_Init_Flg
		pm_Dsp_Sub_Inf_Detail.Item_Rest_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Item_Rest_Flg
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value
		pm_Dsp_Sub_Inf_Detail.Err_Status = pm_Dsp_Body_Row_Inf_Item_Detail.Err_Status
		pm_Dsp_Sub_Inf_Detail.Locked = pm_Dsp_Body_Row_Inf_Item_Detail.Locked
		pm_Dsp_Sub_Inf_Detail.Not_Input_Chk_Fin_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Not_Input_Chk_Fin_Flg
		pm_Dsp_Sub_Inf_Detail.Chk_From_Process = pm_Dsp_Body_Row_Inf_Item_Detail.Chk_From_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Dsp_Sub_Inf_To_Dsp_Body_Inf
	'   概要：  ｢画面項目情報｣⇒｢画面ボディ情報｣に編集する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(ByRef pm_Dsp_Body_Row_Inf_Item_Detail As Cls_Dsp_Sub_Detail_Inf, ByRef pm_Dsp_Sub_Inf_Detail As Cls_Dsp_Sub_Detail_Inf) As Short
		
		'画面項目詳細情報を設定
		'条件によって変更される項目のみ
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value = pm_Dsp_Sub_Inf_Detail.Dsp_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl = pm_Dsp_Sub_Inf_Detail.Focus_Ctl
		pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl_Bk = pm_Dsp_Sub_Inf_Detail.Focus_Ctl_Bk
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value = pm_Dsp_Sub_Inf_Detail.Bef_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value_Flg = pm_Dsp_Sub_Inf_Detail.Bef_Value_Flg
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value = pm_Dsp_Sub_Inf_Detail.Rest_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf_Detail.Rest_Value_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.In_Value_Flg = pm_Dsp_Sub_Inf_Detail.In_Value_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Item_Init_Flg = pm_Dsp_Sub_Inf_Detail.Item_Init_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Item_Rest_Flg = pm_Dsp_Sub_Inf_Detail.Item_Rest_Flg
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value = pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Err_Status = pm_Dsp_Sub_Inf_Detail.Err_Status
		pm_Dsp_Body_Row_Inf_Item_Detail.Locked = pm_Dsp_Sub_Inf_Detail.Locked
		pm_Dsp_Body_Row_Inf_Item_Detail.Not_Input_Chk_Fin_Flg = pm_Dsp_Sub_Inf_Detail.Not_Input_Chk_Fin_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Chk_From_Process = pm_Dsp_Sub_Inf_Detail.Chk_From_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Body_Dsp_Trg_Row
	'   概要：  対象行を画面に表示
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Dsp_Trg_Row(ByRef pm_All As Cls_All, ByRef pm_Row As Short) As Short
		
		''''    Dim Cur_Top_Index   As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''
		''''        '現在表示されている明細に対象行が表示されいているか判断
		''''        If pm_All.Dsp_Body_Inf.Cur_Top_Index <= pm_Row _
		'''''        And pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 >= pm_Row _
		'''''        Then
		''''            '現在表示されている場合は、処理なし
		''''        Else
		''''            '現在表示されている場合は、対象行を表示する為に
		''''            '最上明細ｲﾝﾃﾞｯｸｽを計算
		''''
		''''            '基本として対象行を画面の一番上に設定
		''''            pm_All.Dsp_Body_Inf.Cur_Top_Index = pm_Row
		''''
		''''            '但し、画面表示する場合、
		''''            'Dsp_Body_Inf.Dsp_Body_Infの配列数と画面に表示する数は一致する必要があるため
		''''            '対象行を画面の一番上に設定した場合に、ﾌﾟﾗｽ最大表示行－１が
		''''            'Dsp_Body_Inf.Dsp_Body_Infの配列に必要
		''''            If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 _
		'''''             > UBound(pm_All.Dsp_Body_Inf.Row_Inf) _
		'''''            Then
		''''                '配列数が足りない場合は、対象行を一番下に設定
		''''                pm_All.Dsp_Body_Inf.Cur_Top_Index = pm_Row - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''                '補正
		''''                If pm_All.Dsp_Body_Inf.Cur_Top_Index <= 0 Then
		''''                    pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		''''                End If
		''''
		''''            End If
		''''
		''''        End If
		''''
		''''        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''            '縦スクロールバーを設定
		''''            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''        End If
		''''
		''''        '画面明細表示
		''''        Call CF_Body_Dsp(pm_All)
		''''    End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jdg_Row_Down_Focus
	'   概要：  表示されていない下の明細にフォーカスが受け取れる
	'   　　　　行があるかを判定し、可能な行とその行を表示するとき
	'   　　　　最上明細インデックスを取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jdg_Row_Down_Focus(ByRef pm_Cur_Top_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Low_Top_Row         As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Ok_Row              As Integer
		''''
		''''    '移動可能な行無し
		''''    Rtn_Value = False
		''''    pm_Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        '画面明細より下の一番上の行を取得
		''''        Low_Top_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt
		''''        '現在の最大行を取得
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '明細より下の行から最大行まで検索
		''''        Ok_Row = 0
		''''        For Wk_Row = Low_Top_Row To Max_Row
		''''
		''''            Select Case pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
		''''                    '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣を取得
		''''                    Ok_Row = Wk_Row
		''''                    Exit For
		''''            End Select
		''''        Next
		''''
		''''        '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣がある場合
		''''        If Ok_Row > 0 Then
		''''            Rtn_Value = True
		''''            '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣を一番下に表示した場合の
		''''            '最上明細インデックスを算出
		''''            pm_Cur_Top_Index = Ok_Row - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''            If pm_Cur_Top_Index <= 0 Then
		''''                pm_Cur_Top_Index = 1
		''''            End If
		''''        End If
		''''
		''''    End If
		''''
		''''    CF_Jdg_Row_Down_Focus = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jdg_Row_Up_Focus
	'   概要：  表示されていない上の明細にフォーカスが受け取れる
	'   　　　　行があるかを判定し、可能な行とその行を表示するとき
	'   　　　　最上明細インデックスを取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jdg_Row_Up_Focus(ByRef pm_Cur_Top_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Top_Low_Row         As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Ok_Row              As Integer
		''''
		''''    '移動可能な行無し
		''''    Rtn_Value = False
		''''    pm_Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        '画面明細より上の一番下の行を取得
		''''        Top_Low_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index - 1
		''''
		''''        '明細より上の行から１行目まで検索
		''''        Ok_Row = 0
		''''        For Wk_Row = Top_Low_Row To 1 Step -1
		''''            Select Case pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
		''''                    '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣を取得
		''''                    Ok_Row = Wk_Row
		''''                    Exit For
		''''            End Select
		''''        Next
		''''
		''''        '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣がある場合かつ
		''''        '現在表示されている場合は除く
		''''        If Ok_Row > 0 And Ok_Row <> pm_All.Dsp_Body_Inf.Cur_Top_Index Then
		''''            Rtn_Value = True
		''''            '｢入力待状態｣、｢入力済状態｣、｢最終準備行｣を一番上に表示した場合の
		''''            '最上明細インデックスを算出
		''''            pm_Cur_Top_Index = Ok_Row
		''''        End If
		''''
		''''    End If
		''''
		''''    CF_Jdg_Row_Up_Focus = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Idex_Same_Bd_Ctl
	'   概要：  指定された項目/行に該当する項目のインデックスを取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Idex_Same_Bd_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Idex As Short
		Dim Index_Wk As Short
		
		'初期化
		Rtn_Idex = 0
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
			'明細領域
			
			'ボディ部内で処理
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Row Then
					'対象の明細行の場合
					If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
						'同一ｺﾝﾄﾛｰﾙ名
						Rtn_Idex = Index_Wk
						Exit For
					End If
				End If
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > pm_Row Then
					'対象の明細行を超えた場合終了
					Exit For
				End If
			Next 
			
		End If
		
		CF_Get_Idex_Same_Bd_Ctl = Rtn_Idex
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Col_Same_Bd_Ctl
	'   概要：  指定された項目/行に該当する項目の列を取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Col_Same_Bd_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		''''    Dim Rtn_Col         As Integer
		''''    Dim Col_Wk          As Integer
		''''
		''''    '初期化
		''''    Rtn_Col = 0
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
		''''    '明細領域
		''''
		''''        'ボディ部内で処理
		''''        For Col_Wk = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Item_Detail)
		''''            If pm_Dsp_Sub_Inf.Ctl.Name = pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Item_Detail(Col_Wk).Item_Nm Then
		''''            '同一ｺﾝﾄﾛｰﾙ名
		''''                Rtn_Col = Col_Wk
		''''                Exit For
		''''            End If
		''''        Next
		''''
		''''    End If
		''''
		''''    CF_Get_Col_Same_Bd_Ctl = Rtn_Col
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_Idex_Same_Bd_Ctl_Hide_Row
	'   概要：  指定されたｺﾝﾄﾛｰﾙ名に該当する隠し行の項目のインデックスを取得する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Idex_Same_Bd_Ctl_Hide_Row(ByRef pm_Ctl_Name As String, ByRef pm_All As Cls_All) As Short
		
		''''    Dim Rtn_Idex            As Integer
		''''    Dim Index_Wk            As Integer
		''''
		''''    '初期化
		''''    Rtn_Idex = 0
		''''
		''''    'ボディ部内で処理
		''''    For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''        If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0 Then
		''''        '対象の明細行の場合
		''''            If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name = pm_Ctl_Name Then
		''''            '同一ｺﾝﾄﾛｰﾙ名
		''''                Rtn_Idex = Index_Wk
		''''                Exit For
		''''            End If
		''''        End If
		''''
		''''        If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
		''''        '対象の明細行を超えた場合終了
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    CF_Get_Idex_Same_Bd_Ctl_Hide_Row = Rtn_Idex
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Edi_Dsp_Body_Item
	'   概要：  指定された画面の項目/行に編集を行う
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edi_Dsp_Body_Item(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Value As Object
		
		'画面明細の同行の項目のｲﾝﾃﾞｯｸｽを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'編集値を形式化する
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Wk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_Value = CF_Cnv_Dsp_Item(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index), False)
		
		'画面に編集
		Call CF_Set_Item_Direct(Wk_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, pm_Set_Flg)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Clr_Dsp_Body_Item
	'   概要：  指定された画面の項目/行をクリアする
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Clr_Dsp_Body_Item(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'画面明細の同行の項目のｲﾝﾃﾞｯｸｽを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'画面クリア
		Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Set_Dsp_Body_Item_Focus_Ctl
	'   概要：  指定された画面の項目の編集を行う
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Dsp_Body_Item_Focus_Ctl(ByRef pm_Focus_Ct As Boolean, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'画面明細の同行の項目のｲﾝﾃﾞｯｸｽを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'フォーカス制御を編集
		Call CF_Set_Item_Focus_Ctl(pm_Focus_Ct, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Edi_Dsp_Body_Inf
	'   概要：  指定されたDsp_Body_Infの項目に編集を行う
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edi_Dsp_Body_Inf(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		''''    Dim Trg_Index         As Integer
		''''    Dim Wk_Value          As Variant
		''''    Dim Wk_Col            As Integer
		''''
		''''    '編集値を形式化する
		''''    Wk_Value = CF_Cnv_Dsp_Item(pm_Value _
		'''''                             , pm_Dsp_Sub_Inf _
		'''''                             , False)
		''''
		''''
		''''    '画面項目情報(pm_All.Dsp_Sub_Inf)のの列番号を取得
		''''    Wk_Col = CF_Get_Col_Same_Bd_Ctl(pm_Dsp_Sub_Inf _
		'''''                                  , pm_Bd_Index _
		'''''                                  , pm_All)
		''''
		''''    '画面ボディ情報(pm_All.Dsp_Body_Inf)に編集
		''''    pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Dsp_Value = Wk_Value
		''''
		''''    Select Case pm_Set_Flg
		''''        Case SET_FLG_NOMAL
		''''        '通常編集の場合
		''''        '前回内容/復元内容を退避する
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '前回内容と現在内容が異なる場合
		''''                '復元内容に前回内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '復元内容フラグに前回内容フラグ
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '前回内容に現在内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '前回内容フラグに初期値以外
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''        Case SET_FLG_DEF
		''''        '初期値編集の場合
		''''        '前回チェック内容/前回内容/復元内容を編集
		''''
		''''            '復元内容に前回内容を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''            '復元内容フラグに前回内容フラグ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg <> VALUE_FLG_DEF Then
		''''            '復元内容が初期値以外の場合
		''''                '項目復元ＯＫ
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Rest_Flg = True
		''''            Else
		''''            '復元内容が初期値の場合
		''''                '項目復元ＮＧ
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Rest_Flg = False
		''''            End If
		''''
		''''            '前回内容に現在内容を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''            '前回内容フラグに初期値以外
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_DEF
		''''
		''''            '前回チェック内容に初期値を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '項目のエラー状態に初期値を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_DEF
		''''
		''''            '項目初期化ＮＧ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = False
		''''
		''''            'チェック関数呼出元処理を初期化
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Chk_From_Process = CHK_FROM_ALL_DEFAULT
		''''
		''''            '未入力以外のチェック済フラグ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = False
		''''
		''''        Case SET_FLG_DB
		''''        'ＤＢ値編集の場合
		''''        '入力/表示項目の区別なく、前回チェック内容/前回内容/復元内容
		''''        'を編集
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '前回内容と現在内容が異なる場合
		''''                '復元内容に前回内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '復元内容フラグに前回内容フラグ
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '前回内容に現在内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '前回内容フラグに初期値以外
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''            '前回チェック内容に画面表示内容を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '項目のエラー状態にエラーなしを編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_NOT
		''''
		''''            '項目初期化ＯＫ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = True
		''''
		''''            '未入力以外のチェック済フラグをチェック済みに編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = True
		''''
		''''        Case SET_FLG_DB_ERR
		''''        'ＤＢ値編集の場合(エラーあり)
		''''        '入力/表示項目の区別なく、前回チェック内容/前回内容/復元内容
		''''        'を編集
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '前回内容と現在内容が異なる場合
		''''                '復元内容に前回内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '復元内容フラグに前回内容フラグ
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '前回内容に現在内容を編集
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '前回内容フラグに初期値以外
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''            '前回チェック内容に画面表示内容を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '項目のエラー状態に初期値を編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_DEF
		''''
		''''            '項目初期化ＯＫ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = True
		''''
		''''            '未入力以外のチェック済フラグをチェック済みに編集
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = True
		''''
		''''    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Input_Aft
	'   概要：  ﾁｪﾝｼﾞｲﾍﾞﾝﾄ、ｷｰﾌﾟﾚｽｲﾍﾞﾝﾄの入力後処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'項目初期化フラグＯＫ
		pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
		'項目復元フラグＯＫ
		pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
		
		'復元内容に前回内容を編集
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
		'復元内容フラグに前回内容フラグ
		pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
		
		If pm_Dsp_Sub_Inf.Detail.In_Value_Flg = False Then
			'初回入力時
		End If
		'入力フラグ
		pm_Dsp_Sub_Inf.Detail.In_Value_Flg = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Execute
	'   概要：  メニューの画面｢登録｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Execute(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		Select Case pm_All.Dsp_Base.Dsp_Ctg
			Case DSP_CTG_ENTRY, DSP_CTG_REVISION
				'｢登録系｣、｢修正系｣の場合
				Rtn_Value = True
		End Select
		
		
		CF_Jge_Enabled_MN_Execute = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_DeleteCM
	'   概要：  メニューの画面｢削除｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_DeleteCM(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		CF_Jge_Enabled_MN_DeleteCM = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_HARDCOPY
	'   概要：  メニューの画面｢画面印刷｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_HARDCOPY(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'画面印刷は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_HARDCOPY = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_EndCm
	'   概要：  メニューの画面｢終了｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_EndCm(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'終了は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_EndCm = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_APPENDC
	'   概要：  メニューの画面｢初期化機能｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_APPENDC(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'画面初期化は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_APPENDC = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_ClearItm
	'   概要：  メニューの画面｢項目初期化｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_ClearItm(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'項目初期化は入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					'項目初期化フラグで制御
					If pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True Then
						Rtn_Value = True
					End If
			End Select
		End If
		
		CF_Jge_Enabled_MN_ClearItm = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_UnDoItem
	'   概要：  メニューの画面｢項目復元｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_UnDoItem(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'項目復元は入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					'項目復元フラグで制御
					If pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True Then
						Rtn_Value = True
					End If
			End Select
		End If
		
		CF_Jge_Enabled_MN_UnDoItem = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_ClearDE
	'   概要：  メニューの画面｢明細行初期化｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D            Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		'''''D            '｢登録系｣、｢修正系｣の場合
		''''' === 20060804 === UPDATE ↓
		''''            Case DSP_CTG_ENTRY
		''''            '｢登録系｣の場合
		''''' === 20060804 === UPDATE E
		''''
		''''                '対象項目がボディ部の場合
		''''                If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''                And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''                    'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '対象行が｢入力済状態｣の場合のみ初期化可能
		''''                    If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT Then
		''''                        Rtn_Value = True
		''''                    End If
		''''                End If
		''''        End Select
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_ClearDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_DeleteDE
	'   概要：  メニューの画面｢明細行削除｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        '対象項目がボディ部の場合
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''                '｢登録系｣、｢修正系｣の場合
		''''
		''''                    'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '対象行が｢入力待状態｣,｢入力済状態｣の場合のみ初期化可能
		''''                    Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status
		''''                        Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
		''''                            Rtn_Value = True
		''''                    End Select
		''''
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_DeleteDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_InsertDE
	'   概要：  メニューの画面｢明細行追加｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        '対象項目がボディ部の場合
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		'''''D                '｢登録系｣、｢修正系｣の場合
		''''' === 20060804 === UPDATE ↓
		''''                Case DSP_CTG_ENTRY
		''''                '｢登録系｣の場合
		''''' === 20060804 === UPDATE E
		''''
		''''                    'pm_All.Dsp_Body_Infの行ＮＯを取得
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '対象行が｢入力待状態｣,｢入力済状態｣の場合のみ初期化可能
		''''                    Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status
		''''                        Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
		''''                            Rtn_Value = True
		''''                    End Select
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_InsertDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_UnDoDe
	'   概要：  メニューの画面｢明細行復元｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '明細表示の画面
		''''        '対象項目がボディ部の場合
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D                Case DSP_CTG_ENTRY
		'''''D                '｢登録系｣の場合
		''''' === 20060804 === UPDATE ↓
		''''                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''                '｢登録系｣、｢修正系｣の場合
		''''' === 20060804 === UPDATE E
		''''                    '復元内容が存在する場合
		''''                    Select Case pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg
		''''                        Case BODY_ROW_REST_FLG_CLR
		''''                        '明細初期化の復元情報
		''''                            '対象の復元行が｢入力待状態｣か｢最終準備行｣で
		''''                            'あれば復元可能
		''''
		''''                            If pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row >= 1 _
		'''''                            And pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row <= UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''
		''''                                Select Case pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row).Status
		''''                                    Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_LST_ROW
		''''                                        Rtn_Value = True
		''''                                End Select
		''''                            End If
		''''
		''''                        Case BODY_ROW_REST_FLG_DEL
		''''                        '明細初期化の復元情報,明細削除の復元情報
		''''                            Rtn_Value = True
		''''                    End Select
		''''
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_UnDoDe = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Cut
	'   概要：  メニューの画面｢切り取り｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Cut(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					
					Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
						Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM, IN_TYP_HHMMSS
							'日付/年月/時刻/時分秒の場合、入力形式が決まっている場合は、｢切り取り｣不可
						Case Else
							'その他
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) <> "" Then
								'入力内容がある場合
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If pm_Dsp_Sub_Inf.Ctl.SelLength > 0 Then
									'選択状態の場合
									Rtn_Value = True
								End If
							End If
					End Select
					
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Cut = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Copy
	'   概要：  メニューの画面｢コピー｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Copy(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) <> "" Then
						'入力内容がある場合
						'選択状態の場合
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Copy = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Paste
	'   概要：  メニューの画面｢貼り付け｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容がテキストの場合
					If My.Computer.Clipboard.ContainsText() = True Then
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Paste = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_SM_AllCopy
	'   概要：  ポップアップメニューの｢項目内容コピー｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_SM_AllCopy(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽ
				Rtn_Value = True
				' === 20060802 === INSERT S - ACE)Nagasawa
				'対象コントロールのインデックスを退避
				pm_All.Dsp_Base.PopupMenu_Idx = CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag)
				' === 20060802 === INSERT E -
				'        Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is SSPanel5
				'        'ﾊﾟﾈﾙ
				'            Rtn_Value = True
		End Select
		
		CF_Jge_Enabled_SM_AllCopy = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_SM_FullPast
	'   概要：  ポップアップメニューの｢項目に貼り付け｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_SM_FullPast(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
			'右クリックしたコントロールがアクティブなコントロールと一致
			
			'入力項目の場合
			If CF_Set_Focus_Ctl(pm_Trg_Dsp_Sub_Inf, pm_All) = True Then
				'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
				Select Case True
					Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
						'ﾃｷｽﾄﾎﾞｯｸｽ
						'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容がテキストの場合
						If My.Computer.Clipboard.ContainsText() = True Then
							Rtn_Value = True
							'対象コントロールのインデックスを退避
							pm_All.Dsp_Base.PopupMenu_Idx = CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag)
						End If
				End Select
				
			End If
			
		End If
		
		CF_Jge_Enabled_SM_FullPast = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_PopupMenu
	'   概要：  ポップアップメニューの使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_PopupMenu(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽ
				Rtn_Value = True
				'''        Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is SSPanel5
				'''        'ﾊﾟﾈﾙ
				'''            Rtn_Value = True
		End Select
		
		CF_Jge_Enabled_PopupMenu = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_LStart
	'   概要：  メニューの画面｢プリンタ出力｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_LStart(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'プリンタ出力は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_LStart = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Paste
	'   概要：  メニューの画面｢画面表示｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_VStart(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'画面表示は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_VStart = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_Paste
	'   概要：  メニューの画面｢印刷設定｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_LConfig(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'印刷設定は制限無し
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_LConfig = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Enabled_MN_SList
	'   概要：  メニューの画面｢ウィンドウ表示｣の使用可/不可判定
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_SList(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'入力項目の場合
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'ﾃｷｽﾄﾎﾞｯｸｽ
					'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容がテキストの場合
					If My.Computer.Clipboard.ContainsText() = True Then
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_SList = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_UnDoItem
	'   概要：  メニューの項目復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_UnDoItem(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Rest_Value As Object
		Dim Rest_Value_Flg As Short
		Dim Bef_Value As Object
		Dim Bef_Value_Flg As Short
		
		'退避処理
		'前回内容
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Bef_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
		Bef_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
		'復元内容
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Rest_Value = pm_Dsp_Sub_Inf.Detail.Rest_Value
		Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg
		
		'** 項目初期化フラグ制御 **
		'｢復元内容｣が初期値の場合
		If Rest_Value_Flg = VALUE_FLG_DEF Then
			'初期値を画面に戻すので、項目初期化ＮＧとする
			pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = False
		Else
			'初期値以外を画面に戻すので、項目初期化ＯＫとする
			pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
		End If
		
		'** 項目復元フラグ制御 **
		'｢前回内容｣と｢復元内容｣が両方とも初期値の場合
		If Rest_Value_Flg = VALUE_FLG_DEF And Bef_Value_Flg = VALUE_FLG_DEF Then
			'前回内容も復元内容も初期値になるので、項目復元ＮＧとする
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = False
		Else
			'前回内容か復元内容のどちらかが初期値以外なので、項目復元ＯＫとする
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
		End If
		
		'現在内容と復元内容を入れ換える
		'復元内容→前回内容
		'UPGRADE_WARNING: オブジェクト Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Value = Rest_Value
		pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = Rest_Value_Flg
		'前回内容→復元内容
		'UPGRADE_WARNING: オブジェクト Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Rest_Value = Bef_Value
		pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = Bef_Value_Flg
		
		'｢復元内容｣画面に反映
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Rest_Value, pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_ClearDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Wk_Row          As Integer
		''''    Dim Input_Wait_Cnt  As Integer
		''''    Dim Def_Row         As Integer
		''''
		''''    CF_Cmn_Ctl_MN_ClearDE = False
		''''
		''''    '初期化可能か判定
		''''    '｢入力待状態｣の件数を取得
		''''    Input_Wait_Cnt = 0
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            Input_Wait_Cnt = Input_Wait_Cnt + 1
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    If Input_Wait_Cnt > 0 Then
		''''    '｢入力待状態｣が存在している場合、初期化不可！！
		''''        MsgBox "空白の明細行を先に削除してください。"
		''''        CF_Cmn_Ctl_MN_ClearDE = False
		''''        Exit Function
		''''    End If
		''''
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '対象行の場合
		''''
		''''            '初期化行を復元情報に退避
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
		''''            '復元行
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
		''''            '復元情報の有(明細初期化の復元情報)
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_CLR
		''''
		''''            '配列の初期情報を対象行にコピー
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''            '初期化後｢入力待状態｣
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Status = BODY_ROW_STATE_INPUT_WAIT
		''''
		''''        End If
		''''
		''''        '｢最終準備行｣を｢初期状態｣
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    '画面ボディ情報の配列を再設定
		''''    Call CF_Dell_Refresh_Body_Inf(pm_All)
		''''
		''''    CF_Cmn_Ctl_MN_ClearDE = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_DeleteDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    '初期化、逆転させる！
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    '現在の最大行を取得
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '一時退避
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    For Wk_Row = 1 To Max_Row
		''''        '対象行にコピー
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''    Next
		''''
		''''    Wk_Row_New = 0
		''''    Def_Cnt = 1         '必ず１行は削除される為、｢初期状態｣の開始を１からとする
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''
		''''        '行初期化
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '対象行の場合
		''''            '削除行を復元情報に退避
		''''            Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
		''''            '復元行
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
		''''            '復元情報の有(明細削除の復元情報)
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_DEL
		''''
		''''        Else
		''''            Wk_Row_New = Wk_Row_New + 1
		''''            '対象行にコピー
		''''            Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '｢初期状態｣
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT Then
		''''            '｢入力済状態｣
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''        End If
		''''    Next
		''''
		''''' === 20060818 === UPDATE S - ACE)Sejima
		'''''D    If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		'''''D    '最上明細ｲﾝﾃﾞｯｸｽ＝１の場合
		'''''D        If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		''''''D        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		'''''D            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		'''''D        End If
		'''''D    Else
		'''''D        If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		''''''D        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		'''''D        '｢初期状態｣の行が画面移動量以上でかつ
		'''''D        '画面表示明細数より配列が多い場合
		'''''D            '最大明細行を１行減らす
		'''''D            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		'''''D        End If
		'''''D    End If
		''''' === 20060818 === UPDATE ↓
		''''    If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		'''''    And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''    '｢初期状態｣の行が画面移動量以上でかつ
		''''    '画面表示明細数より配列が多い場合
		''''        '最大明細行を１行減らす
		''''        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		''''    End If
		''''
		''''    If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		''''    '最上明細ｲﾝﾃﾞｯｸｽ＝１の場合
		''''        If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		'''''        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		''''        End If
		''''    End If
		''''' === 20060818 === UPDATE E
		''''
		''''    'スクロールバーの最大値を設定
		''''    Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''    '明細情報の行状態を再設定
		''''    Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    '配列数が変更がない場合は、最終行の初期化が必要
		''''    If Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''        pm_Row_Inf_Max_S = Max_Row
		''''        pm_Row_Inf_Max_E = Max_Row
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_InsertDE(ByRef pm_Bd_Index As Short, ByRef pm_Ins_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    CF_Cmn_Ctl_MN_InsertDE = False
		''''
		''''    '現在の最大行を取得
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '一時退避
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''        '対象行にコピー
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''        '｢入力済状態｣
		''''            Iput_Cnt = Iput_Cnt + 1
		''''        End If
		''''
		''''    Next
		''''
		''''    '増加チェック
		''''    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''    '最大入力明細数が設定されいる場合
		''''        If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''        '｢入力状態｣の件数が最大入力明細数に到達する場合
		''''            MsgBox "明細行はこれ以上挿入できません。"
		''''            CF_Cmn_Ctl_MN_InsertDE = False
		''''            Exit Function
		''''        End If
		''''    End If
		''''
		''''    Wk_Row_New = 0
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '対象行の場合
		''''            Wk_Row_New = Wk_Row_New + 1
		''''            '増加
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''            '配列の初期情報を対象行にコピー
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''            '初期化後｢入力待状態｣
		''''            pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT_WAIT
		''''
		''''            '追加行を呼出元に通知
		''''            pm_Ins_Bd_Index = Wk_Row_New
		''''
		''''        End If
		''''
		''''        Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''            Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
		''''                '｢初期状態｣、｢入力済状態｣だけ退避
		''''                Wk_Row_New = Wk_Row_New + 1
		''''                '増加
		''''                ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''
		''''                '対象行にコピー
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''        End Select
		''''
		''''    Next
		''''
		''''    '明細情報の行状態を再設定
		''''    Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    CF_Cmn_Ctl_MN_InsertDE = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_UnDoDe(ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Boolean
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    CF_Cmn_Ctl_MN_UnDoDe = False
		''''
		''''    '初期化、逆転させる！
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    '現在の最大行を取得
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '一時退避
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''        '対象行にコピー
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''        '｢入力済状態｣
		''''            Iput_Cnt = Iput_Cnt + 1
		''''        End If
		''''
		''''    Next
		''''
		''''    '増加チェック
		''''    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''    '最大入力明細数が設定されいる場合
		''''        If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''        '｢入力状態｣の件数が最大入力明細数に到達する場合
		''''            MsgBox "明細行はこれ以上挿入できません。"
		''''            CF_Cmn_Ctl_MN_UnDoDe = False
		''''            Exit Function
		''''        End If
		''''    End If
		''''
		''''    '復元処理
		''''    Select Case pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg
		''''        Case BODY_ROW_REST_FLG_CLR
		''''        '明細初期化の復元情報
		''''            For Wk_Row = 1 To Max_Row
		''''
		''''                If Wk_Row = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row Then
		''''                '対象行の場合
		''''                    '対象行に復元情報をコピー
		''''                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''                End If
		''''
		''''                '｢最終準備行｣を｢初期状態｣
		''''                If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''                    pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT
		''''                    Exit For
		''''                End If
		''''
		''''            Next
		''''
		''''        Case BODY_ROW_REST_FLG_DEL
		''''        '明細削除の復元情報
		''''
		''''            Wk_Row_New = 0
		''''            Iput_Cnt = 0
		''''            For Wk_Row = 1 To Max_Row
		''''
		''''                If Wk_Row = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row Then
		''''                '対象行に復元情報をコピー
		''''                    Wk_Row_New = Wk_Row_New + 1
		''''                    '増加
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''                    '対象行に復元情報をコピー
		''''                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''                End If
		''''
		''''                Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                    Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
		''''                        '｢初期状態｣、｢入力済状態｣だけ退避
		''''
		''''                        Wk_Row_New = Wk_Row_New + 1
		''''                        '増加
		''''                        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''
		''''                        '対象行にコピー
		''''                        Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''                End Select
		''''
		''''            Next
		''''
		''''    End Select
		''''
		''''    '画面ボディ行の配列を再作成
		''''    Call CF_Add_Refresh_Body_Inf(pm_All, pm_Row_Inf_Max_S, pm_Row_Inf_Max_E)
		''''
		''''    '復元情報クリア
		''''    '復元情報の無
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
		''''    '復元行初期化
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
		''''
		''''    CF_Cmn_Ctl_MN_UnDoDe = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_Cut
	'   概要：  メニューの切り取りの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_Cut(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'対象内容を退避
		On Error Resume Next
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_Dsp_Sub_Inf)))
		On Error GoTo 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_MN_Copy
	'   概要：  メニューのコピーの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_Copy(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'クリア
		On Error Resume Next
		My.Computer.Clipboard.Clear()
		On Error GoTo 0
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If pm_Dsp_Sub_Inf.Ctl.SelLength <= 1 Then
			'対象内容を退避
			On Error Resume Next
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_Dsp_Sub_Inf)))
			On Error GoTo 0
		Else
			'対象内容(選択部分のみ)を退避
			On Error Resume Next
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			My.Computer.Clipboard.SetText(pm_Dsp_Sub_Inf.Ctl.SelText)
			On Error GoTo 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Cmn_Ctl_SM_AllCopy
	'   概要：  項目内容にコピーの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_SM_AllCopy(ByRef pm_All As Cls_All) As Short
		
		'クリア
		On Error Resume Next
		My.Computer.Clipboard.Clear()
		On Error GoTo 0
		
		'対象内容を退避
		On Error Resume Next
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.PopupMenu_Idx))))
		On Error GoTo 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_CCurString
	'   概要：  CCur関数拡張版
	'   引数：　pin_strNum    : 型変換対象文字列
	'   戻値：　型変換後の値
	'   備考：  数値として正しくない場合、ゼロを返還
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CCurString(ByRef pin_strNum As String, Optional ByRef pin_curDefValue As Decimal = 0) As Decimal
		
		Dim Ret_Value As Decimal
		
		If IsNumeric(pin_strNum) = True Then
			'数値として正しい場合は型変換
			Ret_Value = CDec(pin_strNum)
		Else
			'正しくない場合は第２引数の値
			'（渡されない場合はゼロ）
			Ret_Value = pin_curDefValue
		End If
		
		CF_Get_CCurString = Ret_Value
		
	End Function
	
	'□□□□□□□□ 全画面共通処理 End □□□□□□□□□□□□□□□□
End Module