Option Strict Off
Option Explicit On
Module NHSMTA_M81
	'
	' スロット名        : 納品先マスタ・メインファイル更新スロット
	' ユニット名        : NHSMTA.M81
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : NHSMR01
	'
	
	' === 20080916 === INSERT S - RISE)Izumi
	Structure TYPE_HAITA_NHSMTA
		Dim NHSCD As String '納入先コード
		Dim WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		Dim UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		Dim OPEID As String '最終作業者コード
		Dim CLTID As String 'クライアントＩＤ
		Dim UOPEID As String '最終作業者コード（バッチ）
		Dim UCLTID As String 'クライアントＩＤ（バッチ）
	End Structure
	Public HAITA_NHSMTA As TYPE_HAITA_NHSMTA
	' === 20080916 === INSERT E - RISE)Izumi
	
	Function DelMst() As Short
		Dim wkWRTTM, keyVal, wkWRTDT As String
		' === 20080916 === INSERT S - RISE)Izumi
		Dim intRtn As Short
		' === 20080916 === INSERT E - RISE)Izumi
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/11 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    Dim bolRet      As Boolean
		'    Dim intRet      As Integer
		''2007/12/11 add-end T.KAWAMUKAI
		''2007/12/13 add-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		'    Dim strWRTDT        As String       '更新日付
		'    Dim strWRTTM        As String       '更新時刻
		'    Dim strUWRTDT       As String       'バッチ更新日付
		'    Dim strUWRTTM       As String       'バッチ更新時刻
		''2007/12/13 add-end M.SUEZAWA
		' === 20080916 === DELETE E - RISE)Izumi
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Function
		End If
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/13 add-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		'    '更新時間取得
		'    Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 add-end M.SUEZAWA
		'
		''2007/12/11 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    '更新時間チェック
		''2007/12/13 upd-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		''''    bolRet = MF_Chk_UWRTDTTM()
		'    bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 upd-end M.SUEZAWA
		'    If bolRet = False Then
		'        intRet = MF_DspMsg(gc_strMsgNHSMR52_E_DEL)
		'        Exit Function
		'    End If
		''2007/12/11 add-end T.KAWAMUKAI
		' === 20080916 === DELETE E - RISE)Izumi
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		keyVal = RD_SSSMAIN_NHSCD(0)
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetEq(DBN_NHSMTA, 1, keyVal, BtrLock)
		' === 20080916 === DELETE S - RISE)Izumi
		'    Call Mfil_FromSCR(0)
		' === 20080916 === DELETE E - RISE)Izumi
		If DBSTAT = 0 Then
			' === 20080916 === INSERT S - RISE)Izumi
			'排他更新日時チェック
			If Val(HAITA_NHSMTA.OPEID) <> Val(DB_NHSMTA.OPEID) Or Val(HAITA_NHSMTA.CLTID) <> Val(DB_NHSMTA.CLTID) Or Val(HAITA_NHSMTA.WRTDT) <> Val(DB_NHSMTA.WRTDT) Or Val(HAITA_NHSMTA.WRTTM) <> Val(DB_NHSMTA.WRTTM) Or Val(HAITA_NHSMTA.UOPEID) <> Val(DB_NHSMTA.UOPEID) Or Val(HAITA_NHSMTA.UCLTID) <> Val(DB_NHSMTA.UCLTID) Or Val(HAITA_NHSMTA.UWRTDT) <> Val(DB_NHSMTA.UWRTDT) Or Val(HAITA_NHSMTA.UWRTTM) <> Val(DB_NHSMTA.UWRTTM) Then
				
				Call DB_AbortTransaction()
				intRtn = MF_DspMsg(gc_strMsgNHSMR52_E_DEL) ' 他のプログラムで更新されたため、削除できません。
				Exit Function
			End If
			Call Mfil_FromSCR(0)
			' === 20080916 === INSERT E - RISE)Izumi
			DB_NHSMTA.DATKB = "9"
			DB_NHSMTA.RELFL = "1"
			DB_NHSMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.UOPEID = SSS_OPEID.Value
			DB_NHSMTA.UCLTID = SSS_CLTID.Value
			DB_NHSMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.PGID = SSS_PrgId
			
			Call DB_Update(DBN_NHSMTA, 1)
		End If
		DelMst = 9 ' 追加モードへの移行
		Call DB_EndTransaction()
	End Function
	
	Function UpdMst() As Short
		Dim wkWRTTM, keyVal, wkWRTDT As String
		' === 20080916 === INSERT S - RISE)Izumi
		Dim intRtn As Short
		' === 20080916 === INSERT E - RISE)Izumi
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/11 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    Dim bolRet      As Boolean
		'    Dim intRet      As Integer
		''2007/12/11 add-end T.KAWAMUKAI
		''2007/12/13 add-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		'    Dim strWRTDT        As String       '更新日付
		'    Dim strWRTTM        As String       '更新時刻
		'    Dim strUWRTDT       As String       'バッチ更新日付
		'    Dim strUWRTTM       As String       'バッチ更新時刻
		''2007/12/13 add-end M.SUEZAWA
		' === 20080916 === DELETE E - RISE)Izumi
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Function
		End If
		
		' === 20080916 === DELETE S - RISE)Izumi
		''2007/12/13 add-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		'    '更新時間取得
		'    Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 add-end M.SUEZAWA
		'
		''2007/12/11 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    '更新時間チェック
		''2007/12/13 upd-str M.SUEZAWA 各プログラムのモジュールで処理するように変更
		''''    bolRet = MF_Chk_UWRTDTTM()
		'    bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
		''2007/12/13 upd-end M.SUEZAWA
		'    If bolRet = False Then
		'        intRet = MF_DspMsg(gc_strMsgNHSMR52_E_UPD)
		'        Exit Function
		'    End If
		''2007/12/11 add-end T.KAWAMUKAI
		' === 20080916 === DELETE E - RISE)Izumi
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		keyVal = RD_SSSMAIN_NHSCD(0)
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetEq(DBN_NHSMTA, 1, keyVal, BtrLock)
        If DBSTAT = 0 Then
            If DB_NHSMTA.DATKB <> "9" Then
                ' === 20080916 === INSERT S - RISE)Izumi
                '排他更新日時チェック
                If Val(HAITA_NHSMTA.OPEID) <> Val(DB_NHSMTA.OPEID) Or Val(HAITA_NHSMTA.CLTID) <> Val(DB_NHSMTA.CLTID) Or Val(HAITA_NHSMTA.WRTDT) <> Val(DB_NHSMTA.WRTDT) Or Val(HAITA_NHSMTA.WRTTM) <> Val(DB_NHSMTA.WRTTM) Or Val(HAITA_NHSMTA.UOPEID) <> Val(DB_NHSMTA.UOPEID) Or Val(HAITA_NHSMTA.UCLTID) <> Val(DB_NHSMTA.UCLTID) Or Val(HAITA_NHSMTA.UWRTDT) <> Val(DB_NHSMTA.UWRTDT) Or Val(HAITA_NHSMTA.UWRTTM) <> Val(DB_NHSMTA.UWRTTM) Then

                    Call DB_AbortTransaction()
                    intRtn = MF_DspMsg(gc_strMsgNHSMR52_E_UPD) ' 他のプログラムで更新されたため、訂正できません。
                    Exit Function
                End If
                ' === 20080916 === INSERT E - RISE)Izumi
                Call Mfil_FromSCR(0)
                Call NHSMTA_FromSYSTBF()
                DB_NHSMTA.RELFL = "1"
                DB_NHSMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
                DB_NHSMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
                DB_NHSMTA.UOPEID = SSS_OPEID.Value
                DB_NHSMTA.UCLTID = SSS_CLTID.Value
                DB_NHSMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
                DB_NHSMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
                DB_NHSMTA.PGID = SSS_PrgId

            End If
            Call DB_Update(DBN_NHSMTA, 1)
        Else
            '2019/09/26 DEL START
            'Call NHSMTA_RClear()
            '2019/09/26 DEL END
            Call Mfil_FromSCR(0)
			Call NHSMTA_FromSYSTBF()
			DB_NHSMTA.NHSMSTKB = SSS_MSTKB.Value
			DB_NHSMTA.DATKB = "1"
			DB_NHSMTA.RELFL = "1"
			DB_NHSMTA.FOPEID = SSS_OPEID.Value
			DB_NHSMTA.FCLTID = SSS_CLTID.Value
			DB_NHSMTA.WRTFSTTM = wkWRTTM ' Format(Now, "hhmmss")
			DB_NHSMTA.WRTFSTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
			DB_NHSMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.UOPEID = SSS_OPEID.Value
			DB_NHSMTA.UCLTID = SSS_CLTID.Value
			DB_NHSMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
			DB_NHSMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
			DB_NHSMTA.PGID = SSS_PrgId
			
			Call DB_Insert(DBN_NHSMTA, 1)
		End If
		UpdMst = 9 ' 追加モードへの移行
		Call DB_EndTransaction()
	End Function
End Module