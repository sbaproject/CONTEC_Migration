Option Strict Off
Option Explicit On
Module AE_RSMR
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'Common Library 2 V6.60 'レベルアップの際に変更。
	'
	Structure clsPP 'Project Form Property
		Dim MainFormFile As String '
		Dim MainFormObj As String '
		Dim MainForm As String 'MANDALA ﾌｫｰﾑ略称（UCase に変換されている）。処理対象を判定するために用いる。
		Dim ScX As Short '各種の MANDALA システムコントロール (CursorRestなどの) の global indeX。
		Dim CtB As Short '配列 AE_Controls の global Base。
		Dim ControlsC As Short 'MANDALA コントロールの個数。
		Dim OnFocus As Boolean 'MANDALA コントロール上にフォーカスがあることを示す（フラグ）。'V4.32
		Dim NextTx As Short '次にフォーカスを当てる AE_Controls の Tx。
		Dim CursorDest As Short '0: CursorDirectionに従う, 1: Loop, 2:Top, 3:Bottom, 4:Scroll Up , 5:Scroll Down, 9:Check
		Dim CursorDirection As Short '1: Next, 2: Prev, 3:Down, 4:Up, 0:Mouse
		Dim CursorSet As Boolean 'AE_SetFocus によって次にフォーカスを移すべきところが設定済。
		Dim CursorSave As Short 'AE_CursorSave によって次にフォーカスを移すべきところが設定済。
		Dim CursorToWhere As Short 'CursorRest の次にフォーカスを移すべき AE_Controls の Tx。
		Dim SuppressGotLostFocus As Short 'メニューの中で他のフォームのモーダルな Show のような
		'フォーカスの移動を伴う処理をした後で、あるコントロールに
		'SetFocus すると、一旦は現コントロールにフォーカスが移った
		'後に SetFocus が有効になること (すぐに有効にならないこと)
		'の補正。
		Dim HeadN As Short 'ヘッド項目の個数。(VirCtrl は含まない)
		Dim BodyN As Short 'ボディ項目の個数。(VirCtrl は含まない)
		Dim EBodyN As Short '拡張ボディ項目の個数。(VirCtrl は含まない)
		Dim TailN As Short 'テール項目の個数。(VirCtrl は含まない)
		Dim BodyV As Short 'ボディ項目の個数。(VirCtrl も含む)
		Dim EBodyV As Short '拡張ボディ項目の個数。(VirCtrl も含む)
		'HeadTx As Integer                 '
		Dim BodyTx As Short '
		Dim EBodyTx As Short '
		Dim NrBodyTx As Short 'ボディ部の縮退して消えた部分の先頭 BodyTx。
		Dim NrEBodyTx As Short '拡張ボディ部の縮退して消えた部分の先頭 EBodyTx。
		Dim TailTx As Short '
		Dim BodyPx As Short '
		Dim EBodyPx As Short '
		Dim TailPx As Short '
		Dim PrpC As Short '
		Dim Tx As Short 'TabIndex。
		Dim ExTx As Short 'Tx の以前値。
		Dim InCompletePx As Short 'インプット不完全な Tx の値。
		Dim Px As Short '
		Dim De As Short 'ボディの Current 明細(De)番号（0 から始まる）。
		Dim De2 As Short 'ボディの Current 明細(De)番号（-1 または 0 から始まる）。
		Dim TopDe As Short '現在、表示されている明細の Top の 明細(De)番号。
		Dim TopEDe As Short '現在、表示されている明細の Top の 明細(Ee)番号。
		Dim MaxDe As Short '
		Dim MaxEDe As Short '
		Dim LastDe As Short '現在、値が設定されている (される) 明細の中の Last 明細(De)番号。
		Dim LastEDe As Short '現在、値が設定されている (される) 明細の中の Last 明細(De)番号。
		Dim LastReadDe As Short 'V6.47(5)
		Dim LastReadEDe As Short 'V6.47(5)
		Dim AlreadyCDe As Short '既に、明細の全クリアがされている。
		Dim AlreadyCEDe As Short '既に、明細の全クリアがされている。
		Dim ActiveDe As Short '挿入空白明細行の明細(De)番号。-1 ならば、挿入空白明細行なし。
		Dim ActiveEDe As Short '挿入空白明細行の明細(De)番号。-1 ならば、挿入空白明細行なし。
		Dim UnDoDeNo As Short '復元すべき De の番号。
		Dim UnDoEDeNo As Short '復元すべき De の番号。
		Dim UnDoDeOp As Short 'De の復元。 1: 初期化、2: 削除、3: 挿入。
		Dim UnDoEDeOp As Short 'De の復元。 1: 初期化、2: 削除、3: 挿入。
		Dim DeApendable As Boolean '
		Dim EDeApendable As Boolean '
		Dim ScrlMaxL As Short 'Page Up/Down 操作で VS_Scrl を Scroll する行数。
		Dim EScrlMaxL As Short 'Page Up/Down 操作で VS_EScrl を Scroll する行数。
		Dim ScrlFlag As Boolean 'LostFocus での Check を抑止する。
		Dim UpDownFlag As Boolean 'ScrlFlag を立てない。'V5.41
		Dim MaxDsp As Short '
		Dim MaxEDsp As Short '
		Dim MaxDspC As Short '現状でのボディ部の最大表示行番号（0 から始まる）。
		Dim MaxEDspC As Short '現状での拡張ボディ部の最大表示行番号（0 から始まる）。
		Dim MaskMode As Boolean 'Change イベントのマスクモード。
		Dim InitValStatus As Short '変更の有無、例えば InitVal が不要な状態かどうかを示す。
		'InitVal Current First Last Next Prev UpdateC で設定。
		'Cancel で参照。 Chenge ClearItm ClearDe DeleteDe DeleteDR でクリア。
		Dim RecalcMode As Boolean '再計算モード。
		Dim CheckErrNglct As Boolean '初期化した項目が AE_Check の Check 高級イベントルーチンでエラーになっても無視する。
		Dim ErrorC As Short 'Body, EBody 再計算モードで見つかったエラーの数。
		'ErrorMsg As String                '最後に出したエラーメッセージ。
		'Timer
		Dim TimerStartUp As Boolean 'Timer を StartUp 用に用いる。
		Dim TimerWorkId As Short 'Timer を 指定の Timer Work Id に用いる。
		': 表示モードで Enter キーを押した場合の処理。
		'
		Dim SlistCall As Boolean 'Slist 呼び出しスイッチ。
		Dim SlistCom As Object 'Slist の通信領域。
		Dim SlistPx As Short 'Slist 項目の Px 値。'V5.44
		Dim SlistSw As Boolean '項目へのインプット途中で Slist の指令を発した場合に、エラーにならないようにバイパスするためのスイッチ。
		Dim Mode As Short ':Append, 2:Select, 3:Indicate, 4:Update
		Dim ExMode As Short 'Mode 変更を認識できるように以前の Mode が設定される。
		Dim KeyDownMode As Short 'KeyDown イベント発生時の Mode。
		Dim ExMessage As String '
		Dim ChOprtMode As Short 'AE_ChOprtLater と AE_ChOprt の通信領域。
		Dim Operable As Boolean '操作可能状態かどうかを示すフラグ。
		Dim Executing As Boolean '実行中。
		Dim PY_BTop As Single 'Top of Body
		Dim PY_EBTop As Single 'Top of EBody
		Dim PY_BHgt As Single 'Height of Body
		Dim PY_EBHgt As Single 'Height of EBody
		'PY_FHgtFst As Single              'Height of Form (First)
		'PY_FHgtCur As Single              'Height of Form (Current)
		Dim SelValid As Boolean 'GotFocus 時に Sel を有効にする。
		Dim ArrowLimit As Boolean 'Right や Left キーで項目内だけしか移動できなくする。
		Dim ExplicitExec As Boolean 'メニューや PF キーやコマンドによる Execute。
		Dim FormHeight As Short 'MANDALA ﾌｫｰﾑ系ﾓｼﾞｭｰﾙの高さ(Form Height)
		Dim FormWidth As Single 'MANDALA ﾌｫｰﾑ系ﾓｼﾞｭｰﾙの幅(Form Width)
		Dim ButtonClick As Boolean 'Button がクリックされたことを示すフラグ。
		Dim Override As Short 'Insert モードか Override かを示すフラグ。
		Dim ServerCheck As Short 'ServerCheck
		Dim ComboUpDown As Boolean '上下の矢印キーによる ComboBox の Up Down 操作。
		Dim SaveExStatus As Short 'Check での ExStatus の Save 領域。
		Dim SaveXV As Object 'Check での ExVal の Save 領域。
		Dim SaveCV As Object 'Check での CuVal の Save 領域。
		Dim NewVal As Object 'Change イベント用の作業領域。
		Dim Caption As String '
		Dim JustAfterSList As Boolean 'V4.21, V4.24 で削除したが、V4.27 で復活。
		Dim DerivedOrigin As String '派生の大元の項目名。
		Dim DerivedFrom As String '派生元の項目名。
		Dim DateSaveFormat As String '日付をデータベースに格納する際のフォーマット。
		Dim MultiLineF As Short 'マルチラインフラグ (Integer)。 V4.12
		Dim SuppressMultiTlDerived As Boolean 'Tail への複数回の Derived を抑止する。 V4.12
		Dim NullZero As Boolean 'V4.14
		Dim AL As Boolean 'V4.15
		Dim BrightOnOff As Integer 'V4.15
		Dim CloseCode As Short 'Close Code 'V4.17
		Dim NeglectLostFocusCheck As Boolean 'Image による Slist 指示の問題解決策。
		Dim LostFocusCheck As Boolean 'V6.44
		Dim ErrorByBackColor As Boolean 'BackColor によるエラー表示。
		Dim ReadTopDe As Short '読込み済みの先頭の明細データの明細インデックス 'V4.28
		Dim ReadTopEDe As Short '読込み済みの先頭の明細データの明細インデックス 'V4.28
		Dim ReadableMaxDe As Short '最終的な読込みの結果、画面に表示されるボディ部の明細インデックスの最大値 (最大行数 - 1)。'V4.28
		Dim ReadableMaxEDe As Short '最終的な読込みの結果、画面に表示される拡張ボディ部の明細インデックスの最大値 (最大行数 - 1)。'V4.28
		'ForeColor As Long                 '表示項目の ForeColor を青色にするため。'V4.29 'V5.39 で削除。
		Dim DspTopDe As Short '表示すべき明細の Top の 明細(De)番号。'V4.34
		Dim DspTopEDe As Short '表示すべき明細の Top の 明細(Ee)番号。'V4.34
		Dim SuppressCodeClear As Boolean 'Status Bar の Code 部のクリアを抑止。V4.34
		Dim SSCommand5Ajst As Boolean 'SSCommand5 の 補正。V4.38
		Dim UnloadMode As Short 'V5.39
		Dim ActiveBlockNo As Short 'アクティブブロック番号 'V5.41
		Dim MaxBlockNo As Short '最大ブロック番号 'V5.41
		Dim MouseDownTx As Short 'GotFocus を確実にするための情報 'V6.45
		Dim ShortCutTx As Short 'ShortCut Tx 'V6.55S
		Dim ModalFlag As Boolean 'Modal 後の GotFocus を確実にするためのフラグ'V6.45
		Dim ClickPosition As Short 'TextBox がクリックされた位置 (OP_Toyota) 'V6.45
		Dim ScrollObject As Short 'スクロール対象 1:Body  2:EBody  3:Both 'V6.45
		Dim Activated As Short 'Activate 済。'V6.45
		Dim SetCursorRR As Boolean 'V6.46
		Dim SetCursorLF As Boolean 'V6.56F
		Dim hIMC As Integer 'IME コンテキストのハンドル
		Dim hIMCHwnd As Integer 'IME コンテキスト所有コントロールのハンドル
		Dim EditText As Boolean 'テキスト編集フラグ (IME 使用中にキー入力があればオンにする )
		Dim SpecSubID As String '
		Dim PageUpDownObject As Short 'PageUp/Down の対象 1:Body  2:EBody
		Dim UniScrl As Boolean '
		Dim DoButtonClick As Boolean 'CommandButton の Click エミュレートのためのフラグ。'V6.47D
		Dim VisibleForItem As Boolean '項目ごとの表示/非表示制御。'V6.47V
		Dim AllowNullDes As Boolean '空の明細行が複数存在してよい。'V6.47B
		Dim No2Scroll As Boolean '形式２のｽｸﾛｰﾙ操作。'V6.47S
		Dim SuppressBeep As Boolean 'KeyPreView でコードを変更した際の Beep 音の抑止 'V6.49
		Dim ChangeAtGotFocus As Boolean 'GotFocus 時に内容の変更を行なった。'V6.50
		Dim SuppressVSScroll As Short 'VS_Scrl のスクロールをサプレスする。'V6.53
		Dim SuppressKeyPress As Short 'KeyPress をサプレスする。'V6.53
		Dim ModelessForm As System.Windows.Forms.Form '起動すべきモードレスフォーム 'V5.42
		Dim MaskFurigana As Boolean 'Furigana 補正 'V6.57
		Dim UnderFurigana As Boolean 'Furigana 補正 'V6.57
		Dim UnderFurigana22 As Boolean 'Furigana 補正 'V6.59
		Dim PopupTx As Short 'PopUp に関する補正 'V6.59Pop
		Dim NeglectPopupFocus As Boolean 'V6.59Pop
		Dim lpPrevWndProc As Integer 'V6.59Pop
	End Structure
	'
	Structure clsCP 'Control Property
		Dim CpPx As Short 'Px
		Dim InOutMode As Integer '0: Output, 1: Mandatory Output, 2: Input, 3: Mandatory Input
		Dim MaxLength As Short 'Max Length (Byte)
		Dim AutoEnter As Short '0:not, 1:AutoEnter; 16:Enabled; 256:Visible
		Dim KeyInOkClass As Short '"0":Numeric, "A":Alphanumeric, "L":WithLowerCase,
		'"N":Nihon Go ,"C":2 Currency, "U": c
		Dim FixedFormat As Short '0:not, 1:Fixed (Neglect Delete/BackSpace)
		Dim Alignment As Short '0:Left, 1:Right, 2:Center
		'Height As Integer                 'Object Height
		Dim FormatClass As Short '日付, 数値 などの型 (詳細は、FormatClass の値を参照)。
		Dim StatusC As Short '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial, 100:Error
		Dim StatusF As Short '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
		Dim ExStatus As Short '
		Dim CIn As Short 'Character In の状態 (CIn の値を参照)。
		Dim TypeA As Short 'コントローの種類 (詳細は、TypeA の値を参照)。
		Dim FractionC As Short 'Fraction Count
		Dim TabTab As Short 'このコントロールが含まれる Tab の Tab 番号 (なければ -1)。
		Dim CuVal As Object 'Current Value
		Dim ExVal As Object 'Ex Value
		'ErrorFlg As Boolean               'Error Flag 'V4.24
		Dim CheckRtnCode As Short 'Error Return Code 'V6.54
		Dim LineCount As Short 'ListBox の Line Count 'V4.24
		Dim FormatChr As String 'Format Character
		Dim TpStr As String 'Temporary String
		Dim IniStr As String 'InitVal String
		Dim RelCheckStatus As String 'RelCheck でのエラー状態 'V4.29
		Dim BlockNo As Short 'ブロック番号 'V5.40
		Dim Modified As Short '変更の有無、InitValStatus の各項目版。
		Dim NZero As Boolean 'Null To Zero
	End Structure
	'
	Public Const Cn_AutoEnter As Short = 1 'AutoEnter。
	Public Const Cn_VisibleInit As Short = 256 'Visible の初期値。
	Public Const Cn_VisibleCur As Short = 512 'Visible の現常値。
	'
	Public AE_Controls() As System.Windows.Forms.Control 'HD_, ED_, TL_ など。
	Public AE_Timer() As System.Windows.Forms.Timer 'Timer
	Public AE_CursorRest() As System.Windows.Forms.TextBox 'カーソルの休憩所。
	Public AE_ModeBar() As System.Windows.Forms.TextBox 'Mode の表示域。
	Public AE_StatusBar() As System.Windows.Forms.Control 'Message の表示域。
	Public AE_StatusCodeBar() As System.Windows.Forms.Control 'Message Code の表示域。'V4.24
	Public AE_ScrlBar() As System.Windows.Forms.Control 'Body Scroll Bar。
	Public AE_EScrlBar() As System.Windows.Forms.Control 'EBody Scroll Bar。
	'
	Public Cn_DebugMode As Boolean
	'
	Public AE_PSI() As String '
	Public AE_PSIC As Short 'PSI の個数。
	'
	Public AE_ScX As Short '各種の AE_Controls システムコントロールの index の基礎値。
	Public AE_CtB As Short 'AE_Controls の Base の基礎値。
	'
	Public AE_SSSWin As Boolean '
	'
	Public Ck_Error As Object '
	'
	Public wk_Var As Object 'バリアント型の Work 領域。
	Public wk_Lng As Integer '長整数型 の Work 領域。
	Public wk_Int As Short '整数型の Work 領域。
	Public wk_Bool As Boolean 'Boolean 型の Work 領域。
	Public wk_String As String 'String 型の Work 領域。
	'
	Public AE_AppPath As String 'App.Path & "\"
	'
	Public AE_BodyTop() As Single 'Body
	Public AE_EBodyTop() As Single 'EBody
	'
	Public AE_Color(8) As Integer '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
	Public AE_BackColor(9) As Integer '0-9
	Public AE_ForeColor(9) As Integer '0-9
	'
	'高級イベントルーチンのパラメタが UnDefine の場合に使用される。
	Public AE_UnDefine As Object 'Empty 値を持つバリアント型変数。
	'
	'各種の定数。-----------------------------------------------------
	'
	'NextTx の値。
	Public Const Cn_NextTxCleared As Short = 10000 'クリアされていることを示す。
	'
	'CursorToWhere の値。
	Public Const Cn_CursorToHome As Short = 10000 '次に CursorHome に設定することを示す。
	Public Const Cn_CursorToRest As Short = -1 '次に CursorRest に設定することを示す。
	'
	'Cursor の行き先の値。
	Public Const Cn_CuInCompletePx As Short = -2 'Cursor を InCompletePx に移動。
	Public Const Cn_CuNop As Short = -1 'Cursor の移動なし。
	Public Const Cn_CuCurrent As Short = 0 'Cursor を元に戻す。
	Public Const Cn_CuInit As Short = 1 'Cursor を初期状態にする。
	Public Const Cn_CuCursorRest As Short = 2 'Cursor を CursorRest に移動。'V6.51C
	Public Const Cn_CuExTx As Short = 10 'Cursor を ExTx に移動。
	Public Const Cn_CuNop100 As Short = 100 'Cursor に対する処理を行なわない。
	'
	'CursorDirection の値。
	Public Const Cn_Direction0 As Short = 0 '0: Mouse
	Public Const Cn_Direction1 As Short = 1 '1: Next
	Public Const Cn_Direction2 As Short = 2 '2: Prev
	Public Const Cn_Direction3 As Short = 3 '3: Down
	Public Const Cn_Direction4 As Short = 4 '4: Up
	'
	'CursorDest の値。'V6.51X
	Public Const Cn_Dest0 As Short = 0 '0: 初期値
	Public Const Cn_Dest1 As Short = 1 '1: Tab ｷｰによるﾙｰﾌﾟ状のｶｰｿﾙ移動
	Public Const Cn_Dest2 As Short = 2 '2: Top
	Public Const Cn_Dest3 As Short = 3 '3: Bottom
	Public Const Cn_Dest4 As Short = 4 '4: Scroll Up
	Public Const Cn_Dest5 As Short = 5 '5: Scroll Down
	Public Const Cn_Dest6 As Short = 6 '6: Next
	Public Const Cn_Dest7 As Short = 7 '7: Prev
	Public Const Cn_Dest9 As Short = 9 '9: SList
	Public Const Cn_DestBySkip As Short = 10 '9: Skip 'V6.59SkipReflection
	'
	'Mode の値。
	Public Const Cn_Mode1 As Short = 1 '1: AppendC
	Public Const Cn_Mode15 As Short = 15 '15: Current & AppendC 'V4.28
	Public Const Cn_Mode16 As Short = 16 '16: InitValAll & AppendC 'V6.56
	Public Const Cn_Mode2 As Short = 2 '2: SelectCm
	Public Const Cn_Mode25 As Short = 25 '25: SelectCl 'V6.59CL
	Public Const Cn_Mode3 As Short = 3 '3: Indicate
	Public Const Cn_Mode4 As Short = 4 '4: UpdateC
	'
	Public Const Cn_ModeDataChanged As Short = 0 '0: DataChanged
	'
	Public Const Cn_EnabledCn As Short = 100 '100: Enabled / Disabled
	'
	'InOutMode の値。
	Public Const Cn_InOutMode0 As Short = 0 '0: Input
	Public Const Cn_InOutMode1 As Short = 1 '1: Input (Mandatory)
	Public Const Cn_InOutMode2 As Short = 2 '2: Output
	Public Const Cn_InOutMode3 As Short = 3 '3: Output (Mandatory)
	'
	'Status の値 (StatusC, StatusF, ExStatus)。
	Public Const Cn_Error As Short = 2
	'
	Public Const Cn_Status0 As Short = 0 '0: Start
	Public Const Cn_Status1 As Short = 1 '1: Incomplete
	Public Const Cn_Status2 As Short = 2 '2: Error
	Public Const Cn_Status3 As Short = 3 '3-5: RelCheck
	Public Const Cn_Status4 As Short = 4
	Public Const Cn_Status5 As Short = 5
	Public Const Cn_Status6 As Short = 6 '6: Checked
	Public Const Cn_Status7 As Short = 7 '7: Derived
	Public Const Cn_Status8 As Short = 8 '8: Initial
	Public Const Cn_StatusError As Short = -1 '-1: Error
	'
	'FormatClass の値 (日付, 数値 などの型の値)
	Public Const Cn_Date As Short = 1 '日付
	Public Const Cn_Time As Short = 2 '時刻
	Public Const Cn_Code As Short = 5 'コード
	Public Const Cn_Memo As Short = 6 'メモ
	Public Const Cn_Name As Short = 7 '名称
	Public Const Cn_Numb As Short = 3 '数値
	Public Const Cn_Snum As Short = 4 '符数
	Public Const Cn_Chnu As Short = 8 '字数値 'V6.50
	Public Const Cn_Schn As Short = 9 '符字数 'V6.50
	Public Const Cn_NonC As Short = 0 'その他
	'
	'TypeA の値。
	Public Const Cn_NormalOrV As Short = 45 'Asc("-")      'Normal or Virtual Control,
	Public Const Cn_InputOnly As Short = 73 'Asc("I")      'Input Only (COMBOBOX2),
	Public Const Cn_OutputOnly As Short = 79 'Asc("O")     'Outout Only (Label),
	Public Const Cn_HandMadeC As Short = 111 'Asc("o")     'Hand Made Control,
	Public Const Cn_CheckBox As Short = 75 'Asc("K")       'Check Box,
	Public Const Cn_ListBox As Short = 76 'Asc("L")        'List Box,
	Public Const Cn_OptionButtonH As Short = 82 'Asc("R")  'Radio (Option) Button の先頭
	Public Const Cn_OptionButtonC As Short = 114 'Asc("r") 'Radio (Option) Button で先頭ではないもの
	'
	'CIn の値。
	Public Const Cn_NoInput As Short = 0 '0: No Input
	Public Const Cn_BSorDL As Short = 1 '1: Back Space or Delete
	Public Const Cn_ChrInput As Short = 2 '2: Character Input
	Public Const Cn_ValueChanged As Short = 3 '3: Value Changed; ListBox 用。
	'
	'AE_StatusClear のパラメタ。
	Public Const Cn_AllClear As Short = -1
	'
	'その他
	Public Const Cn_Surplus4 As Short = 4 'MaxLength への追加分。
	'
	Public Const Cn_PrfxLen As Short = 3
	Public Const Cn_AfterPrfx As Short = 4 '= Cn_PrfxLen + 1
	'
	Public Const Cn_BS As String = "\" 'Back Slash or "\"
End Module