Attribute VB_Name = "SSSMAIN0002"
Option Explicit
'プログラム総括情報プロシジャ

'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
''================================================================================
'☆　画面ボディ部の行単位の業務情報　　　　　☆
'☆　　Cls_Dsp_Body_Row_Infとの互換性を　　　☆
'☆　　共通の全てのＰＧで宣言する　　　　　　☆
'☆　　そのため以下の｢Dummy｣は必須！！ 　　　☆
Public Type Cls_Dsp_Body_Bus_Inf
    Dummy                 As String        'ダミー
End Type
''================================================================================
'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

'メッセージコード
'共通
Public Const gc_strMsgTNAPR82_I_001         As String = "1TNAPR82_001"      '○実行してよろしいですか？
Public Const gc_strMsgTNAPR82_I_002         As String = "1TNAPR82_002"      '○終了してよろしいですか？
Public Const gc_strMsgTNAPR82_I_003         As String = "1TNAPR82_003"      '○処理を終了しました。
Public Const gc_strMsgTNAPR82_I_004         As String = "1TNAPR82_014"      '○処理を中断しました。
'---------------------------------------------------------------------------------------------------------------------
Public Const gc_strMsgTNAPR82_E_005         As String = "2TNAPR82_005"      '●入力値が許容範囲外です。
Public Const gc_strMsgTNAPR82_E_006         As String = "2TNAPR82_006"      '●該当するデータが存在しません。
Public Const gc_strMsgTNAPR82_E_007         As String = "2TNAPR82_017"      '●シーケンス取得でエラーが発生しました。
Public Const gc_strMsgTNAPR82_E_008         As String = "2TNAPR82_008"      '●ＤＢ更新エラーが発生しました。
Public Const gc_strMsgTNAPR82_E_009         As String = "2TNAPR82_009"      '●ＤＢ参照エラーが発生しました。
Public Const gc_strMsgTNAPR82_E_010         As String = "2TNAPR82_010"      '●ＤＢアクセスエラーが発生しました。
Public Const gc_strMsgTNAPR82_E_011         As String = "2TNAPR82_011"      '●帳票出力処理でエラーが発生しました。
Public Const gc_strMsgTNAPR82_E_012         As String = "2TNAPR82_012"      '●入力されていない項目があります。入力して下さい。
Public Const gc_strMsgTNAPR82_E_013         As String = "2TNAPR82_013"      '●日付に誤りがあります。修正してください。
'---------------------------------------------------------------------------------------------------------------------
Public Const gc_strMsgTNAPR82_E_014         As String = "2TNAPR82_014"      '●年月に誤りがあります。修正してください。
Public Const gc_strMsgTNAPR82_E_015         As String = "2TNAPR82_015"      '●必須入力項目です。
Public Const gc_strMsgTNAPR82_E_016         As String = "2TNAPR82_016"      '●場所ｺｰﾄﾞと倉庫ｺｰﾄﾞの関係が不正です。

