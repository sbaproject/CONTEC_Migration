Attribute VB_Name = "AE_RSMR"
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
'
'Common Library 2 V6.60 'レベルアップの際に変更。
'
Type clsPP                            'Project Form Property
    MainFormFile As String            '
    MainFormObj As String             '
    MainForm As String                'MANDALA ﾌｫｰﾑ略称（UCase に変換されている）。処理対象を判定するために用いる。
    ScX As Integer                    '各種の MANDALA システムコントロール (CursorRestなどの) の global indeX。
    CtB As Integer                    '配列 AE_Controls の global Base。
    ControlsC As Integer              'MANDALA コントロールの個数。
    OnFocus As Boolean                'MANDALA コントロール上にフォーカスがあることを示す（フラグ）。'V4.32
    NextTx As Integer                 '次にフォーカスを当てる AE_Controls の Tx。
    CursorDest As Integer             '0: CursorDirectionに従う, 1: Loop, 2:Top, 3:Bottom, 4:Scroll Up , 5:Scroll Down, 9:Check
    CursorDirection As Integer        '1: Next, 2: Prev, 3:Down, 4:Up, 0:Mouse
    CursorSet As Boolean              'AE_SetFocus によって次にフォーカスを移すべきところが設定済。
    CursorSave As Integer             'AE_CursorSave によって次にフォーカスを移すべきところが設定済。
    CursorToWhere As Integer          'CursorRest の次にフォーカスを移すべき AE_Controls の Tx。
    SuppressGotLostFocus As Integer   'メニューの中で他のフォームのモーダルな Show のような
                                      'フォーカスの移動を伴う処理をした後で、あるコントロールに
                                      'SetFocus すると、一旦は現コントロールにフォーカスが移った
                                      '後に SetFocus が有効になること (すぐに有効にならないこと)
                                      'の補正。
    HeadN As Integer                  'ヘッド項目の個数。(VirCtrl は含まない)
    BodyN As Integer                  'ボディ項目の個数。(VirCtrl は含まない)
    EBodyN As Integer                 '拡張ボディ項目の個数。(VirCtrl は含まない)
    TailN As Integer                  'テール項目の個数。(VirCtrl は含まない)
    BodyV As Integer                  'ボディ項目の個数。(VirCtrl も含む)
    EBodyV As Integer                 '拡張ボディ項目の個数。(VirCtrl も含む)
    'HeadTx As Integer                 '
    BodyTx As Integer                 '
    EBodyTx As Integer                '
    NrBodyTx As Integer               'ボディ部の縮退して消えた部分の先頭 BodyTx。
    NrEBodyTx As Integer              '拡張ボディ部の縮退して消えた部分の先頭 EBodyTx。
    TailTx As Integer                 '
    BodyPx As Integer                 '
    EBodyPx As Integer                '
    TailPx As Integer                 '
    PrpC As Integer                   '
    Tx As Integer                     'TabIndex。
    ExTx As Integer                   'Tx の以前値。
    InCompletePx As Integer           'インプット不完全な Tx の値。
    Px As Integer                     '
    De As Integer                     'ボディの Current 明細(De)番号（0 から始まる）。
    De2 As Integer                    'ボディの Current 明細(De)番号（-1 または 0 から始まる）。
    TopDe As Integer                  '現在、表示されている明細の Top の 明細(De)番号。
    TopEDe As Integer                 '現在、表示されている明細の Top の 明細(Ee)番号。
    MaxDe As Integer                  '
    MaxEDe As Integer                 '
    LastDe As Integer                 '現在、値が設定されている (される) 明細の中の Last 明細(De)番号。
    LastEDe As Integer                '現在、値が設定されている (される) 明細の中の Last 明細(De)番号。
    LastReadDe As Integer             'V6.47(5)
    LastReadEDe As Integer            'V6.47(5)
    AlreadyCDe As Integer             '既に、明細の全クリアがされている。
    AlreadyCEDe As Integer            '既に、明細の全クリアがされている。
    ActiveDe As Integer               '挿入空白明細行の明細(De)番号。-1 ならば、挿入空白明細行なし。
    ActiveEDe As Integer              '挿入空白明細行の明細(De)番号。-1 ならば、挿入空白明細行なし。
    UnDoDeNo As Integer               '復元すべき De の番号。
    UnDoEDeNo As Integer              '復元すべき De の番号。
    UnDoDeOp As Integer               'De の復元。 1: 初期化、2: 削除、3: 挿入。
    UnDoEDeOp As Integer              'De の復元。 1: 初期化、2: 削除、3: 挿入。
    DeApendable As Boolean            '
    EDeApendable As Boolean           '
    ScrlMaxL As Integer               'Page Up/Down 操作で VS_Scrl を Scroll する行数。
    EScrlMaxL As Integer              'Page Up/Down 操作で VS_EScrl を Scroll する行数。
    ScrlFlag As Boolean               'LostFocus での Check を抑止する。
    UpDownFlag As Boolean             'ScrlFlag を立てない。'V5.41
    MaxDsp As Integer                 '
    MaxEDsp As Integer                '
    MaxDspC As Integer                '現状でのボディ部の最大表示行番号（0 から始まる）。
    MaxEDspC As Integer               '現状での拡張ボディ部の最大表示行番号（0 から始まる）。
    MaskMode As Boolean               'Change イベントのマスクモード。
    InitValStatus As Integer          '変更の有無、例えば InitVal が不要な状態かどうかを示す。
                                      'InitVal Current First Last Next Prev UpdateC で設定。
                                      'Cancel で参照。 Chenge ClearItm ClearDe DeleteDe DeleteDR でクリア。
    RecalcMode As Boolean             '再計算モード。
    CheckErrNglct As Boolean          '初期化した項目が AE_Check の Check 高級イベントルーチンでエラーになっても無視する。
    ErrorC As Integer                 'Body, EBody 再計算モードで見つかったエラーの数。
    'ErrorMsg As String                '最後に出したエラーメッセージ。
'Timer
    TimerStartUp As Boolean           'Timer を StartUp 用に用いる。
    TimerWorkId As Integer            'Timer を 指定の Timer Work Id に用いる。
                                      ': 表示モードで Enter キーを押した場合の処理。
'
    SlistCall As Boolean              'Slist 呼び出しスイッチ。
    SlistCom As Variant               'Slist の通信領域。
    SlistPx As Integer                'Slist 項目の Px 値。'V5.44
    SlistSw As Boolean                '項目へのインプット途中で Slist の指令を発した場合に、エラーにならないようにバイパスするためのスイッチ。
    Mode As Integer                   ':Append, 2:Select, 3:Indicate, 4:Update
    ExMode As Integer                 'Mode 変更を認識できるように以前の Mode が設定される。
    KeyDownMode As Integer            'KeyDown イベント発生時の Mode。
    ExMessage As String               '
    ChOprtMode As Integer             'AE_ChOprtLater と AE_ChOprt の通信領域。
    Operable As Boolean               '操作可能状態かどうかを示すフラグ。
    Executing As Boolean              '実行中。
    PY_BTop As Single                 'Top of Body
    PY_EBTop As Single                'Top of EBody
    PY_BHgt As Single                 'Height of Body
    PY_EBHgt As Single                'Height of EBody
    'PY_FHgtFst As Single              'Height of Form (First)
    'PY_FHgtCur As Single              'Height of Form (Current)
    SelValid As Boolean               'GotFocus 時に Sel を有効にする。
    ArrowLimit As Boolean             'Right や Left キーで項目内だけしか移動できなくする。
    ExplicitExec As Boolean           'メニューや PF キーやコマンドによる Execute。
    FormHeight As Integer             'MANDALA ﾌｫｰﾑ系ﾓｼﾞｭｰﾙの高さ(Form Height)
    FormWidth As Single               'MANDALA ﾌｫｰﾑ系ﾓｼﾞｭｰﾙの幅(Form Width)
    ButtonClick As Boolean            'Button がクリックされたことを示すフラグ。
    Override As Integer               'Insert モードか Override かを示すフラグ。
    ServerCheck As Integer            'ServerCheck
    ComboUpDown As Boolean            '上下の矢印キーによる ComboBox の Up Down 操作。
    SaveExStatus As Integer           'Check での ExStatus の Save 領域。
    SaveXV As Variant                 'Check での ExVal の Save 領域。
    SaveCV As Variant                 'Check での CuVal の Save 領域。
    NewVal As Variant                 'Change イベント用の作業領域。
    Caption As String                 '
    JustAfterSList As Boolean         'V4.21, V4.24 で削除したが、V4.27 で復活。
    DerivedOrigin As String           '派生の大元の項目名。
    DerivedFrom As String             '派生元の項目名。
    DateSaveFormat As String          '日付をデータベースに格納する際のフォーマット。
    MultiLineF As Integer             'マルチラインフラグ (Integer)。 V4.12
    SuppressMultiTlDerived As Boolean 'Tail への複数回の Derived を抑止する。 V4.12
    NullZero As Boolean               'V4.14
    AL As Boolean                     'V4.15
    BrightOnOff As Long               'V4.15
    CloseCode As Integer              'Close Code 'V4.17
    NeglectLostFocusCheck As Boolean  'Image による Slist 指示の問題解決策。
    LostFocusCheck As Boolean         'V6.44
    ErrorByBackColor As Boolean       'BackColor によるエラー表示。
    ReadTopDe As Integer              '読込み済みの先頭の明細データの明細インデックス 'V4.28
    ReadTopEDe As Integer             '読込み済みの先頭の明細データの明細インデックス 'V4.28
    ReadableMaxDe As Integer          '最終的な読込みの結果、画面に表示されるボディ部の明細インデックスの最大値 (最大行数 - 1)。'V4.28
    ReadableMaxEDe As Integer         '最終的な読込みの結果、画面に表示される拡張ボディ部の明細インデックスの最大値 (最大行数 - 1)。'V4.28
    'ForeColor As Long                 '表示項目の ForeColor を青色にするため。'V4.29 'V5.39 で削除。
    DspTopDe As Integer               '表示すべき明細の Top の 明細(De)番号。'V4.34
    DspTopEDe As Integer              '表示すべき明細の Top の 明細(Ee)番号。'V4.34
    SuppressCodeClear As Boolean      'Status Bar の Code 部のクリアを抑止。V4.34
    SSCommand5Ajst As Boolean         'SSCommand5 の 補正。V4.38
    UnloadMode As Integer             'V5.39
    ActiveBlockNo As Integer          'アクティブブロック番号 'V5.41
    MaxBlockNo As Integer             '最大ブロック番号 'V5.41
    MouseDownTx As Integer            'GotFocus を確実にするための情報 'V6.45
    ShortCutTx As Integer             'ShortCut Tx 'V6.55S
    ModalFlag As Boolean              'Modal 後の GotFocus を確実にするためのフラグ'V6.45
    ClickPosition As Integer          'TextBox がクリックされた位置 (OP_Toyota) 'V6.45
    ScrollObject As Integer           'スクロール対象 1:Body  2:EBody  3:Both 'V6.45
    Activated As Integer              'Activate 済。'V6.45
    SetCursorRR As Boolean            'V6.46
    SetCursorLF As Boolean            'V6.56F
    hIMC As Long                      'IME コンテキストのハンドル
    hIMCHwnd As Long                  'IME コンテキスト所有コントロールのハンドル
    EditText As Boolean               'テキスト編集フラグ (IME 使用中にキー入力があればオンにする )
    SpecSubID As String               '
    PageUpDownObject As Integer       'PageUp/Down の対象 1:Body  2:EBody
    UniScrl As Boolean                '
    DoButtonClick As Boolean          'CommandButton の Click エミュレートのためのフラグ。'V6.47D
    VisibleForItem As Boolean         '項目ごとの表示/非表示制御。'V6.47V
    AllowNullDes As Boolean           '空の明細行が複数存在してよい。'V6.47B
    No2Scroll As Boolean              '形式２のｽｸﾛｰﾙ操作。'V6.47S
    SuppressBeep As Boolean           'KeyPreView でコードを変更した際の Beep 音の抑止 'V6.49
    ChangeAtGotFocus As Boolean       'GotFocus 時に内容の変更を行なった。'V6.50
    SuppressVSScroll As Integer       'VS_Scrl のスクロールをサプレスする。'V6.53
    SuppressKeyPress As Integer       'KeyPress をサプレスする。'V6.53
    ModelessForm As Form              '起動すべきモードレスフォーム 'V5.42
    MaskFurigana As Boolean           'Furigana 補正 'V6.57
    UnderFurigana As Boolean          'Furigana 補正 'V6.57
    UnderFurigana22 As Boolean        'Furigana 補正 'V6.59
    PopupTx As Integer                'PopUp に関する補正 'V6.59Pop
    NeglectPopupFocus As Boolean      'V6.59Pop
    lpPrevWndProc As Long             'V6.59Pop
End Type
'
Type clsCP 'Control Property
    CpPx As Integer                   'Px
    InOutMode As Long                 '0: Output, 1: Mandatory Output, 2: Input, 3: Mandatory Input
    MaxLength As Integer              'Max Length (Byte)
    AutoEnter As Integer              '0:not, 1:AutoEnter; 16:Enabled; 256:Visible
    KeyInOkClass As Integer           '"0":Numeric, "A":Alphanumeric, "L":WithLowerCase,
                                      '"N":Nihon Go ,"C":2 Currency, "U": c
    FixedFormat As Integer            '0:not, 1:Fixed (Neglect Delete/BackSpace)
    Alignment As Integer              '0:Left, 1:Right, 2:Center
    'Height As Integer                 'Object Height
    FormatClass As Integer            '日付, 数値 などの型 (詳細は、FormatClass の値を参照)。
    StatusC As Integer                '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial, 100:Error
    StatusF As Integer                '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
    ExStatus As Integer               '
    CIn As Integer                    'Character In の状態 (CIn の値を参照)。
    TypeA As Integer                  'コントローの種類 (詳細は、TypeA の値を参照)。
    FractionC As Integer              'Fraction Count
    TabTab As Integer                 'このコントロールが含まれる Tab の Tab 番号 (なければ -1)。
    CuVal As Variant                  'Current Value
    ExVal As Variant                  'Ex Value
    'ErrorFlg As Boolean               'Error Flag 'V4.24
    CheckRtnCode As Integer           'Error Return Code 'V6.54
    LineCount As Integer              'ListBox の Line Count 'V4.24
    FormatChr As String               'Format Character
    TpStr As String                   'Temporary String
    IniStr As String                  'InitVal String
    RelCheckStatus As String          'RelCheck でのエラー状態 'V4.29
    BlockNo As Integer                'ブロック番号 'V5.40
    Modified As Integer               '変更の有無、InitValStatus の各項目版。
    NZero As Boolean                  'Null To Zero
End Type
'
Public Const Cn_AutoEnter As Integer = 1     'AutoEnter。
Public Const Cn_VisibleInit As Integer = 256 'Visible の初期値。
Public Const Cn_VisibleCur As Integer = 512  'Visible の現常値。
'
Public AE_Controls() As Control       'HD_, ED_, TL_ など。
Public AE_Timer() As Timer            'Timer
Public AE_CursorRest() As TextBox     'カーソルの休憩所。
Public AE_ModeBar() As TextBox        'Mode の表示域。
Public AE_StatusBar() As Control      'Message の表示域。
Public AE_StatusCodeBar() As Control  'Message Code の表示域。'V4.24
Public AE_ScrlBar() As Control        'Body Scroll Bar。
Public AE_EScrlBar() As Control       'EBody Scroll Bar。
'
Public Cn_DebugMode As Boolean
'
Public AE_PSI$()                      '
Public AE_PSIC As Integer             'PSI の個数。
'
Public AE_ScX As Integer              '各種の AE_Controls システムコントロールの index の基礎値。
Public AE_CtB As Integer              'AE_Controls の Base の基礎値。
'
Public AE_SSSWin As Boolean           '
'
Public Ck_Error As Variant            '
'
Public wk_Var As Variant              'バリアント型の Work 領域。
Public wk_Lng As Long                 '長整数型 の Work 領域。
Public wk_Int As Integer              '整数型の Work 領域。
Public wk_Bool As Boolean             'Boolean 型の Work 領域。
Public wk_String$                     'String 型の Work 領域。
'
Public AE_AppPath$                    'App.Path & "\"
'
Public AE_BodyTop() As Single         'Body
Public AE_EBodyTop() As Single        'EBody
'
Public AE_Color(8) As Long            '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
Public AE_BackColor(9) As Long        '0-9
Public AE_ForeColor(9) As Long        '0-9
'
'高級イベントルーチンのパラメタが UnDefine の場合に使用される。
Public AE_UnDefine As Variant         'Empty 値を持つバリアント型変数。
'
'各種の定数。-----------------------------------------------------
'
'NextTx の値。
Public Const Cn_NextTxCleared As Integer = 10000 'クリアされていることを示す。
'
'CursorToWhere の値。
Public Const Cn_CursorToHome As Integer = 10000  '次に CursorHome に設定することを示す。
Public Const Cn_CursorToRest As Integer = -1     '次に CursorRest に設定することを示す。
'
'Cursor の行き先の値。
Public Const Cn_CuInCompletePx As Integer = -2   'Cursor を InCompletePx に移動。
Public Const Cn_CuNop As Integer = -1            'Cursor の移動なし。
Public Const Cn_CuCurrent As Integer = 0         'Cursor を元に戻す。
Public Const Cn_CuInit As Integer = 1            'Cursor を初期状態にする。
Public Const Cn_CuCursorRest As Integer = 2      'Cursor を CursorRest に移動。'V6.51C
Public Const Cn_CuExTx As Integer = 10           'Cursor を ExTx に移動。
Public Const Cn_CuNop100 As Integer = 100        'Cursor に対する処理を行なわない。
'
'CursorDirection の値。
Public Const Cn_Direction0 As Integer = 0        '0: Mouse
Public Const Cn_Direction1 As Integer = 1        '1: Next
Public Const Cn_Direction2 As Integer = 2        '2: Prev
Public Const Cn_Direction3 As Integer = 3        '3: Down
Public Const Cn_Direction4 As Integer = 4        '4: Up
'
'CursorDest の値。'V6.51X
Public Const Cn_Dest0 As Integer = 0             '0: 初期値
Public Const Cn_Dest1 As Integer = 1             '1: Tab ｷｰによるﾙｰﾌﾟ状のｶｰｿﾙ移動
Public Const Cn_Dest2 As Integer = 2             '2: Top
Public Const Cn_Dest3 As Integer = 3             '3: Bottom
Public Const Cn_Dest4 As Integer = 4             '4: Scroll Up
Public Const Cn_Dest5 As Integer = 5             '5: Scroll Down
Public Const Cn_Dest6 As Integer = 6             '6: Next
Public Const Cn_Dest7 As Integer = 7             '7: Prev
Public Const Cn_Dest9 As Integer = 9             '9: SList
Public Const Cn_DestBySkip As Integer = 10       '9: Skip 'V6.59SkipReflection
'
'Mode の値。
Public Const Cn_Mode1 As Integer = 1             '1: AppendC
Public Const Cn_Mode15 As Integer = 15           '15: Current & AppendC 'V4.28
Public Const Cn_Mode16 As Integer = 16           '16: InitValAll & AppendC 'V6.56
Public Const Cn_Mode2 As Integer = 2             '2: SelectCm
Public Const Cn_Mode25 As Integer = 25           '25: SelectCl 'V6.59CL
Public Const Cn_Mode3 As Integer = 3             '3: Indicate
Public Const Cn_Mode4 As Integer = 4             '4: UpdateC
'
Public Const Cn_ModeDataChanged As Integer = 0   '0: DataChanged
'
Public Const Cn_EnabledCn As Integer = 100       '100: Enabled / Disabled
'
'InOutMode の値。
Public Const Cn_InOutMode0 As Integer = 0        '0: Input
Public Const Cn_InOutMode1 As Integer = 1        '1: Input (Mandatory)
Public Const Cn_InOutMode2 As Integer = 2        '2: Output
Public Const Cn_InOutMode3 As Integer = 3        '3: Output (Mandatory)
'
'Status の値 (StatusC, StatusF, ExStatus)。
Public Const Cn_Error As Integer = 2
'
Public Const Cn_Status0 As Integer = 0           '0: Start
Public Const Cn_Status1 As Integer = 1           '1: Incomplete
Public Const Cn_Status2 As Integer = 2           '2: Error
Public Const Cn_Status3 As Integer = 3           '3-5: RelCheck
Public Const Cn_Status4 As Integer = 4
Public Const Cn_Status5 As Integer = 5
Public Const Cn_Status6 As Integer = 6           '6: Checked
Public Const Cn_Status7 As Integer = 7           '7: Derived
Public Const Cn_Status8 As Integer = 8           '8: Initial
Public Const Cn_StatusError As Integer = -1      '-1: Error
'
'FormatClass の値 (日付, 数値 などの型の値)
Public Const Cn_Date As Integer = 1              '日付
Public Const Cn_Time As Integer = 2              '時刻
Public Const Cn_Code As Integer = 5              'コード
Public Const Cn_Memo As Integer = 6              'メモ
Public Const Cn_Name As Integer = 7              '名称
Public Const Cn_Numb As Integer = 3              '数値
Public Const Cn_Snum As Integer = 4              '符数
Public Const Cn_Chnu As Integer = 8              '字数値 'V6.50
Public Const Cn_Schn As Integer = 9              '符字数 'V6.50
Public Const Cn_NonC As Integer = 0              'その他
'
'TypeA の値。
Public Const Cn_NormalOrV As Integer = 45 'Asc("-")      'Normal or Virtual Control,
Public Const Cn_InputOnly As Integer = 73 'Asc("I")      'Input Only (COMBOBOX2),
Public Const Cn_OutputOnly As Integer = 79 'Asc("O")     'Outout Only (Label),
Public Const Cn_HandMadeC As Integer = 111 'Asc("o")     'Hand Made Control,
Public Const Cn_CheckBox As Integer = 75 'Asc("K")       'Check Box,
Public Const Cn_ListBox As Integer = 76 'Asc("L")        'List Box,
Public Const Cn_OptionButtonH As Integer = 82 'Asc("R")  'Radio (Option) Button の先頭
Public Const Cn_OptionButtonC As Integer = 114 'Asc("r") 'Radio (Option) Button で先頭ではないもの
'
'CIn の値。
Public Const Cn_NoInput As Integer = 0           '0: No Input
Public Const Cn_BSorDL As Integer = 1            '1: Back Space or Delete
Public Const Cn_ChrInput As Integer = 2          '2: Character Input
Public Const Cn_ValueChanged As Integer = 3      '3: Value Changed; ListBox 用。
'
'AE_StatusClear のパラメタ。
Public Const Cn_AllClear As Integer = -1
'
'その他
Public Const Cn_Surplus4 As Integer = 4          'MaxLength への追加分。
'
Public Const Cn_PrfxLen As Integer = 3
Public Const Cn_AfterPrfx As Integer = 4         '= Cn_PrfxLen + 1
'
Public Const Cn_BS$ = "\"                        'Back Slash or "\"

