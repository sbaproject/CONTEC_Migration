Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'メッセージコード
    '2019/09/24 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/09/24 ADD E N D
    '入金消込
    Public Const gc_strMsgURKET53_E_001 As String = "1URKET53_001" '入力された請求先は得意先マスタに存在しません。
	Public Const gc_strMsgURKET53_E_002 As String = "1URKET53_002" '入力された日付は不正な日付です。
	Public Const gc_strMsgURKET53_E_003 As String = "1URKET53_003" '入力された区分は不正な区分です。
	Public Const gc_strMsgURKET53_E_004 As String = "1URKET53_004" '入力された消し込み日は月次締されています。
	Public Const gc_strMsgURKET53_E_005 As String = "1URKET53_005" '入力必須です。
	
	
	
	
	
	
	Public Const gc_strMsgURKET53_E_009 As String = "2URKET53_009" '該当するデータが存在しません。
	Public Const gc_strMsgURKET53_E_011 As String = "2URKET53_011" '見出部の入力がまだのため明細行の入力ができません。
	Public Const gc_strMsgURKET53_E_013 As String = "2URKET53_013" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgURKET53_E_017 As String = "2URKET53_017" '現在の編集内容は破棄されます。よろしいですか？
	Public Const gc_strMsgURKET53_E_019 As String = "2URKET53_019" '得意先より締日が算出できません。
	Public Const gc_strMsgURKET53_E_029 As String = "2URKET53_029" '入力された日付はカレンダに登録されていません。
	
	Public Const gc_strMsgURKET53_A_031 As String = "1URKET53_031" '終了してよろしいですか？
	Public Const gc_strMsgURKET53_A_032 As String = "1URKET53_032" '未登録のまま終了してもよろしいですか？
	
	Public Const gc_strMsgURKET53_E_034 As String = "2URKET53_034" '更新異常
	Public Const gc_strMsgURKET53_A_037 As String = "1URKET53_037" '更新してよろしいですか？
	Public Const gc_strMsgURKET53_E_039 As String = "2URKET53_039" '日付に誤りがあります。修正してください。
	Public Const gc_strMsgURKET53_E_045 As String = "2URKET53_045" 'この得意先は海外取引先です。
End Module