Option Strict Off
Option Explicit On
Module MST_CMN
	'
	' ユニット名        : MST_CMN
	' 記述者            : M.SUEZAWA
	' 作成日付          : 2007/12/10
	'
	' 備考　　          : マスタメンテナンスでの排他制御対応用に新規作成
	
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_MOTO
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
	End Structure
	Public M_MOTO_inf As M_TYPE_MOTO
	Public M_MOTO_A_inf() As M_TYPE_MOTO
	
	'エラーメッセージ
	
	'部門登録
	Public Const gc_strMsgBMNMT51_E_UPD As String = "BMNMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgBMNMT51_E_DEL As String = "BMNMT51_002" '他のプログラムで更新されたため、削除できません。
	'銀行登録
	Public Const gc_strMsgBNKMT51_E_UPD As String = "BNKMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgBNKMT51_E_DEL As String = "BNKMT51_002" '他のプログラムで更新されたため、削除できません。
	'カレンダー登録  2007/12/27 メッセージ表示関数が異なるため
	Public Const gc_strMsgCLDMT51_E_UPD As String = "2CLDMT51_013" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgCLDMT51_E_DEL As String = "2CLDMT51_014" '他のプログラムで更新されたため、削除できません。
	''''商品Ｍ登録     ･･･　未使用
	'''Public Const gc_strMsgHINMR51_E_UPD         As String = "HINMR51_001"  '他のプログラムで更新されたため、訂正できません。
	'''Public Const gc_strMsgHINMR51_E_DEL         As String = "HINMR51_002"  '他のプログラムで更新されたため、削除できません。
	
	'固定値登録
	Public Const gc_strMsgFIXMT51_E_UPD As String = "FIXMT51_017" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgFIXMT51_E_DEL As String = "FIXMT51_018" '他のプログラムで更新されたため、削除できません。
	'名称登録
	Public Const gc_strMsgMEIMT52_E_UPD As String = "MEIMT52_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgMEIMT52_E_DEL As String = "MEIMT52_002" '他のプログラムで更新されたため、削除できません。
	'納入先M登録
	Public Const gc_strMsgNHSMR52_E_UPD As String = "NHSMR52_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgNHSMR52_E_DEL As String = "NHSMR52_002" '他のプログラムで更新されたため、削除できません。
	'レートマスタ登録
	Public Const gc_strMsgRATMT51_E_UPD As String = "RATMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgRATMT51_E_DEL As String = "RATMT51_002" '他のプログラムで更新されたため、削除できません。
	'製品別仕入先単価登録
	Public Const gc_strMsgSIRMT52_E_UPD As String = "SIRMT52_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgSIRMT52_E_DEL As String = "SIRMT52_002" '他のプログラムで更新されたため、削除できません。
	'製品別仕入先別ロット単価登録
	Public Const gc_strMsgSIRMT53_E_UPD As String = "SIRMT53_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgSIRMT53_E_DEL As String = "SIRMT53_002" '他のプログラムで更新されたため、削除できません｡
	'倉庫登録
	Public Const gc_strMsgSOUMT51_E_UPD As String = "SOUMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgSOUMT51_E_DEL As String = "SOUMT51_002" '他のプログラムで更新されたため、削除できません。
	'権限登録
	''Public Const gc_strMsgKNGMT51_E_UPD         As String = "KNGMT51_001"  '他のプログラムで更新されたため、訂正できません。
	''Public Const gc_strMsgKNGMT51_E_DEL         As String = "KNGMT51_002"  '他のプログラムで更新されたため、削除できません。
	'担当者登録
	Public Const gc_strMsgTANMT51_E_UPD As String = "TANMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTANMT51_E_DEL As String = "TANMT51_002" '他のプログラムで更新されたため、削除できません。
	'取引先Ｍ登録
	Public Const gc_strMsgTHSMR51_E_UPD As String = "THSMR51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTHSMR51_E_DEL As String = "THSMR51_002" '他のプログラムで更新されたため、削除できません。
	'製品別得意先単価登録
	Public Const gc_strMsgTOKMT52_E_UPD As String = "TOKMT52_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTOKMT52_E_DEL As String = "TOKMT52_002" '他のプログラムで更新されたため、削除できません。
	'製品別得意先別ロット単価登録
	Public Const gc_strMsgTOKMT53_E_UPD As String = "TOKMT53_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTOKMT53_E_DEL As String = "TOKMT53_002" '他のプログラムで更新されたため、削除できません。
	'製番Ｍ登録  2007/12/27 メッセージ表示関数が異なるため
	Public Const gc_strMsgSBNMT51_E_UPD As String = "2SBNMT51_023" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgSBNMT51_E_DEL As String = "2SBNMT51_024" '他のプログラムで更新されたため、削除できません。
	'ランク別仕切率登録
	Public Const gc_strMsgTOKMT55_E_UPD As String = "TOKMT55_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTOKMT55_E_DEL As String = "TOKMT55_002" '他のプログラムで更新されたため、削除できません。
	'単位登録
	Public Const gc_strMsgUNTMT51_E_UPD As String = "UNTMT51_001" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgUNTMT51_E_DEL As String = "UNTMT51_002" '他のプログラムで更新されたため、削除できません。
	'得意先別商品ランク登録   ･･･　未使用
	''Public Const gc_strMsgTOKMT54_E_UPD         As String = "TOKMT54_001"  '他のプログラムで更新されたため、訂正できません。
	''Public Const gc_strMsgTOKMT54_E_DEL         As String = "TOKMT54_002"  '他のプログラムで更新されたため、削除できません。
	'得意先別取扱商品登録     ･･･　未使用
	''Public Const gc_strMsgTOKMT56_E_UPD         As String = "TOKMT56_001"  '他のプログラムで更新されたため、訂正できません。
	''Public Const gc_strMsgTOKMT56_E_DEL         As String = "TOKMT56_002"  '他のプログラムで更新されたため、削除できません。
	
	'2008/04/03 add-str H.HONDA 共通メッセージを追加。
	'共通エラーメッセージ
	Public Const gc_strMsgCMNER01_E_UPD As String = "CMNER01_001" '他のプログラムで更新されたため、更新できません。
	Public Const gc_strMsgCMNER01_E_DEL As String = "CMNER01_002" '他のプログラムで更新されたため、削除できません。
	'2008/04/03 add-end H.HONDA 共通メッセージを追加。
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_Chk_UWRTDTTM
	'   概要：  更新時間チェック処理
	'   引数：  pin_strWRTDT    : 更新日付
	'           pin_strWRTTM    : 更新時刻
	'           pin_strUWRTDT   : バッチ更新日付
	'           pin_strUWRTTM   : バッチ更新時刻
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Chk_UWRTDTTM(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String) As Boolean
		
		
		On Error GoTo MF_Chk_UWRTDTTM_err
		
		MF_Chk_UWRTDTTM = False
		
		
		'更新時間チェック
		If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_inf.WRTDT) & Trim(M_MOTO_inf.WRTTM) & Trim(M_MOTO_inf.UWRTDT) & Trim(M_MOTO_inf.UWRTTM) Then
			GoTo MF_Chk_UWRTDTTM_End
		End If
		
		MF_Chk_UWRTDTTM = True
		
MF_Chk_UWRTDTTM_End: 
		Exit Function
		
MF_Chk_UWRTDTTM_err: 
		GoTo MF_Chk_UWRTDTTM_End
		
	End Function
	
	'''
	'''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''   名称：  Function MF_Chk_UWRTDTTM_A
	''''   概要：  更新時間チェック処理
	''''   引数：  pin_strWRTDT    : 更新日付
	''''           pin_strWRTTM    : 更新時刻
	''''           pin_strUWRTDT   : バッチ更新日付
	''''           pin_strUWRTTM   : バッチ更新時刻
	''''           pin_intIDX      : 明細行（0～）
	''''   戻値：　True：チェックOK　False：チェックNG
	''''   備考：  複数レコード対応
	'''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''Public Function MF_Chk_UWRTDTTM_A(ByVal pin_strWRTDT As String, _
	''''                                  ByVal pin_strWRTTM As String, _
	''''                                  ByVal pin_strUWRTDT As String, _
	''''                                  ByVal pin_strUWRTTM As String, _
	''''                                  ByVal pin_intIDX As Integer) As Boolean
	'''
	'''    On Error GoTo MF_Chk_UWRTDTTM_A_err
	'''
	'''    MF_Chk_UWRTDTTM_A = False
	'''
	'''    '更新時間チェック
	'''    If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> _
	''''       Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
	''''       Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
	'''        GoTo MF_Chk_UWRTDTTM_A_End
	'''    End If
	'''
	'''    MF_Chk_UWRTDTTM_A = True
	'''
	'''MF_Chk_UWRTDTTM_A_End:
	'''    Exit Function
	'''
	'''MF_Chk_UWRTDTTM_A_err:
	'''    GoTo MF_Chk_UWRTDTTM_A_End
	'''
	'''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_Chk_UWRTDTTM_T
	'   概要：  更新時間チェック処理
	'   引数：  pin_strWRTDT    : 更新日付
	'           pin_strWRTTM    : 更新時刻
	'           pin_strUWRTDT   : バッチ更新日付
	'           pin_strUWRTTM   : バッチ更新時刻
	'           pin_intIDX      : 多明細の場合　　　　明細行（0～）
	'   　　　　　　　　　　　　　得意先Ｍ登録の場合　0…得意先 1…仕入先
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：  多明細及び、得意先Ｍ登録用
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Chk_UWRTDTTM_T(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		
		On Error GoTo MF_Chk_UWRTDTTM_T_err
		
		MF_Chk_UWRTDTTM_T = False
		
		'''    MsgBox "A " & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM)
		'''    MsgBox "B " & Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
		'Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM)
		
		'CHG START FKS)ASANO 2008/03/18
		If InStr(Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'更新時間チェック
			If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
				GoTo MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		'CHG END FKS)ASANO 2008/03/18
		
		MF_Chk_UWRTDTTM_T = True
		
MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
MF_Chk_UWRTDTTM_T_err: 
		GoTo MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_CmnMsgLibrary
	'   概要：  メッセージ表示処理
	'   引数：  pin_strMsgCode  : メッセージコード
	'   戻値：  選択ボタン
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_DspMsg(ByVal pin_strMsgCode As String) As Short
		
		Dim intRet As Short
		
		On Error Resume Next
		
		MF_DspMsg = False
		
		'メッセージ表示
		intRet = DSP_MsgBox(SSS_ERROR, pin_strMsgCode, 0)
		
		MF_DspMsg = intRet
		
MF_DspMsg_End: 
		Exit Function
		
MF_DspMsg_err: 
		GoTo MF_DspMsg_End
		
	End Function
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo MF_UpDown_UWRTDTTM_err
		
		MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		MF_UpDown_UWRTDTTM = True
		
MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
MF_UpDown_UWRTDTTM_err: 
		GoTo MF_UpDown_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo MF_SaveRestore_UWRTDTTM_err
		
		MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'退避・復元処理
			M_MOTO_inf.WRTDT = M_MOTO_A_inf(pin_intIDX).WRTDT
			M_MOTO_inf.WRTTM = M_MOTO_A_inf(pin_intIDX).WRTTM
			M_MOTO_inf.UWRTDT = M_MOTO_A_inf(pin_intIDX).UWRTDT
			M_MOTO_inf.UWRTTM = M_MOTO_A_inf(pin_intIDX).UWRTTM
		Else
			'復元処理
			M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_inf.WRTDT
			M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_inf.WRTTM
			M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_inf.UWRTDT
			M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_inf.UWRTTM
		End If
		
		MF_SaveRestore_UWRTDTTM = True
		
MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
MF_SaveRestore_UWRTDTTM_err: 
		GoTo MF_SaveRestore_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo MF_Clear_UWRTDTTM_err
		
		MF_Clear_UWRTDTTM = False
		'更新時間　配列クリア
		M_MOTO_A_inf(pin_intIDX).WRTDT = ""
		M_MOTO_A_inf(pin_intIDX).WRTTM = ""
		M_MOTO_A_inf(pin_intIDX).UWRTDT = ""
		M_MOTO_A_inf(pin_intIDX).UWRTTM = ""
		
		MF_Clear_UWRTDTTM = True
		
MF_Clear_UWRTDTTM_End: 
		Exit Function
		
MF_Clear_UWRTDTTM_err: 
		GoTo MF_Clear_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
End Module