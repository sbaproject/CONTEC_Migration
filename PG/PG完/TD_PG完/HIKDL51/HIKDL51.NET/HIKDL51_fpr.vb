Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'20190703 ADD START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'20190703 ADD END
Module SSSMAIN0001
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	
	Public gv_bolKeyFlg As Boolean
	
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
    '20190703 ADD START
    Public D0 As ClsComn = New ClsComn
    Public LV_Col_Order() As Integer
    '20190703 ADD END
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_DSP_TNADL71C
    '   概要：  引当状況照会画面の表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  画面連携処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_DSP_TNADL71C() As Short
		
		Dim stArrayData() As String
		
		stArrayData = Split(VB.Command(), "|")
		
		'照会受け渡しパラメータ設定
		'ヘッダ商品情報全部取得
		'製品コード
		TNADL71C_HINCD = stArrayData(2)
		'型式
		TNADL71C_HINNMA = stArrayData(3)
		'商品名１
		TNADL71C_HINNMB = stArrayData(4)
		
		'明細部分全部取得
		'入出庫日
		TNADL71C_STKDLVDT = stArrayData(5)
		'出庫数
		TNADL71C_DLVSU = 0
		'引当数
		TNADL71C_HIKSU = 0
		'状態
		TNADL71C_JOTAI = stArrayData(6)
		'入庫
		TNADL71C_STKSU = CDec(stArrayData(7))
		'推定
		TNADL71C_SZAISU = CDec(stArrayData(8))
		'登録日
		TNADL71C_DENDT = ""
		'製番
		TNADL71C_SBNNO = stArrayData(9)
		'得意先
		TNADL71C_TOKRN = stArrayData(10)
		'倉庫
		TNADL71C_SOUNM = stArrayData(11)
		'客先注文番号
		TNADL71C_TOKJDNNO = stArrayData(12)
		
		'内部変数取得
		'状態区分
		TNADL71C_TRAKB = "4"
		'受注番号
		TNADL71C_JDNNO = ""
		'参照見積番号
		TNADL71C_MITNO = ""
		'版数
		TNADL71C_MITNOV = "  "
		'行番号
		TNADL71C_LINNO = "   "

        '引当状況照会表示
        FR_SSSSUB03.Show()

        'ICN_ICON.Close()

        ''画面終了
        'FR_SSSMAIN.Close()

    End Function
End Module