Option Strict Off
Option Explicit On
Module BMNMT51_E01
	Public wk_SRTNKEY As New VB6.FixedLengthString(128) '検索画面リターンKEY
	Public Len506 As Short
	Public Len508 As Short
	Public Len509 As Short
	Public Len507 As Short
	Public Len511 As Short
	
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : BMNMT51.E01
	' 記述者            : Standard Library
	' 作成日付          : 1997/08/04
	' 使用プログラム名  : BMNMT51
	'
	Function DSPMST() As Short
		Dim I As Short
		Dim svBMNCD As String
		Dim svENDTKDT As String
		Dim strSQL As String
		Dim strKEY As String
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		''''Call DB_GetGrEq(DBN_BMNMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"

        'Call DB_GetSQL2(DBN_BMNMTA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)

        ' === 20080929 === UPDATE S - RISE)Izumi チェック項目追加
        '2007/12/17 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
        '    ReDim M_MOTO_A_inf(4)
        '2007/12/17 add-end M.SUEZAWA
        ReDim M_BMNMT_A_inf(4)
        ' === 20080929 === UPDATE E - RISE)Izumi

        'If DBSTAT = 0 Then
        '	Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
        '              Call SCR_FromMfil(I)
        '              '20190807 CHG START
        '              '            Call DP_SSSMAIN_V_DATKB(I, DB_BMNMTA.DATKB) '2006.11.07
        '              'Call DP_SSSMAIN_V_ENDTKD(I, DB_BMNMTA.ENDTKDT) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNNM(I, DB_BMNMTA.BMNNM) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNZP(I, DB_BMNMTA.BMNZP) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNADA(I, DB_BMNMTA.BMNADA) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNADB(I, DB_BMNMTA.BMNADB) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNADC(I, DB_BMNMTA.BMNADC) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNTL(I, DB_BMNMTA.BMNTL) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNFX(I, DB_BMNMTA.BMNFX) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNURL(I, DB_BMNMTA.BMNURL) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNCDU(I, DB_BMNMTA.BMNCDUP) '2006.11.07
        '              'Call DP_SSSMAIN_V_ZMJGYC(I, DB_BMNMTA.ZMJGYCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_ZMCD(I, DB_BMNMTA.ZMCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_ZMBMNC(I, DB_BMNMTA.ZMBMNCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_EIGYOC(I, DB_BMNMTA.EIGYOCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_TIKKB(I, DB_BMNMTA.TIKKB) '2006.11.07
        '              'Call DP_SSSMAIN_V_HTANCD(I, DB_BMNMTA.HTANCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_STANCD(I, DB_BMNMTA.STANCD) '2006.11.07
        '              'Call DP_SSSMAIN_V_BMNPRN(I, DB_BMNMTA.BMNPRNM) '2006.11.07
        '              Call DP_SSSMAIN_V_DATKB(I, DB_BMNMTA2.DATKB) '2006.11.07
        '              Call DP_SSSMAIN_V_ENDTKD(I, DB_BMNMTA2.ENDTKDT) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNNM(I, DB_BMNMTA2.BMNNM) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNZP(I, DB_BMNMTA2.BMNZP) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNADA(I, DB_BMNMTA2.BMNADA) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNADB(I, DB_BMNMTA2.BMNADB) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNADC(I, DB_BMNMTA2.BMNADC) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNTL(I, DB_BMNMTA2.BMNTL) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNFX(I, DB_BMNMTA2.BMNFX) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNURL(I, DB_BMNMTA2.BMNURL) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNCDU(I, DB_BMNMTA2.BMNCDUP) '2006.11.07
        '              Call DP_SSSMAIN_V_ZMJGYC(I, DB_BMNMTA2.ZMJGYCD) '2006.11.07
        '              Call DP_SSSMAIN_V_ZMCD(I, DB_BMNMTA2.ZMCD) '2006.11.07
        '              Call DP_SSSMAIN_V_ZMBMNC(I, DB_BMNMTA2.ZMBMNCD) '2006.11.07
        '              Call DP_SSSMAIN_V_EIGYOC(I, DB_BMNMTA2.EIGYOCD) '2006.11.07
        '              Call DP_SSSMAIN_V_TIKKB(I, DB_BMNMTA2.TIKKB) '2006.11.07
        '              Call DP_SSSMAIN_V_HTANCD(I, DB_BMNMTA2.HTANCD) '2006.11.07
        '              Call DP_SSSMAIN_V_STANCD(I, DB_BMNMTA2.STANCD) '2006.11.07
        '              Call DP_SSSMAIN_V_BMNPRN(I, DB_BMNMTA2.BMNPRNM) '2006.11.07
        '              '            svBMNCD = DB_BMNMTA.BMNCD
        '              'svENDTKDT = DB_BMNMTA.WRTFSTDT
        '              'If DB_BMNMTA.DATKB = "9" Then
        '              svBMNCD = DB_BMNMTA2.BMNCD
        '              svENDTKDT = DB_BMNMTA2.WRTFSTDT
        '              If DB_BMNMTA2.DATKB = "9" Then
        '                  Call DP_SSSMAIN_UPDKB(I, "削除")
        '              Else
        '                  Call DP_SSSMAIN_UPDKB(I, "更新")
        '		End If
        '              'Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCDUP & "        ", BtrNormal)
        '              Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA2.BMNCDUP & "        ", BtrNormal)
        '              '20190807 CHG END

        '              '''' UPD 2009/08/25  FKS) T.Yamamoto    Start    連絡票№:FC09082501
        '              '            If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) Then
        '              '                Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
        '              '            Else
        '              '                Call DP_SSSMAIN_BMNNMUP(I, "")
        '              '            End If
        '              Call DP_SSSMAIN_BMNNMUP(I, "")
        '		Do While (DBSTAT = 0)
        '                  'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                  'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                  'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCDUP(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                  '20190807 CHG START
        '                  'If (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
        '                  '    Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
        '                  If (DB_BMNMTA2.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA2.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA2.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
        '                      Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA2.BMNNM)
        '                      '20190807 CHG END
        '                      Exit Do
        '                  End If
        '                  Call DB_GetNext(DBN_BMNMTA, BtrNormal)
        '		Loop 
        '		'''' UPD 2009/08/25  FKS) T.Yamamoto    End
        '		I = I + 1

        '		''''''''''''Call DB_GetGrEq(DBN_BMNMTA, 1, svBMNCD, BtrNormal)
        '		strKEY = svBMNCD & svENDTKDT
        '		strSQL = ""
        '		strSQL = strSQL & "SELECT *"
        '		strSQL = strSQL & "  FROM   ("
        '		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
        '		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
        '		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
        '		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
        '		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
        '		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
        '		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
        '		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
        '		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
        '		strSQL = strSQL & "                    BMN.PGID "
        '		strSQL = strSQL & "             From BMNMTA BMN"
        '		strSQL = strSQL & "             ) TBL"
        '		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(strKEY) & "'"
        '		strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
        '		Call DB_GetSQL2(DBN_BMNMTA, strSQL)

        '		Call DB_GetNext(DBN_BMNMTA, BtrNormal)
        '	Loop 
        'End If
        For j As Integer = 0 To dt.Rows.Count - 1
            If DBSTAT = 0 And (I < (PP_SSSMAIN.MaxDspC + 1)) Then
                DB_BMNMTA2.BMNADA = dt.Rows(j)("BMNADA")
                DB_BMNMTA2.BMNADB = dt.Rows(j)("BMNADB")
                DB_BMNMTA2.BMNADC = dt.Rows(j)("BMNADC")
                DB_BMNMTA2.BMNCD = dt.Rows(j)("BMNCD")
                DB_BMNMTA2.BMNCDUP = dt.Rows(j)("BMNCDUP")
                DB_BMNMTA2.BMNFX = dt.Rows(j)("BMNFX")
                DB_BMNMTA2.BMNLV = dt.Rows(j)("BMNLV")
                DB_BMNMTA2.BMNNM = dt.Rows(j)("BMNNM")
                DB_BMNMTA2.BMNPRNM = dt.Rows(j)("BMNPRNM")
                DB_BMNMTA2.BMNTL = dt.Rows(j)("BMNTL")
                DB_BMNMTA2.BMNURL = dt.Rows(j)("BMNURL")
                DB_BMNMTA2.BMNZP = dt.Rows(j)("BMNZP")
                DB_BMNMTA2.EIGYOCD = DB_NullReplace(dt.Rows(j)("EIGYOCD"), "")
                DB_BMNMTA2.ENDTKDT = dt.Rows(j)("ENDTKDT")
                DB_BMNMTA2.HTANCD = dt.Rows(j)("HTANCD")
                DB_BMNMTA2.STANCD = dt.Rows(j)("STANCD")
                DB_BMNMTA2.STTTKDT = dt.Rows(j)("STTTKDT")
                DB_BMNMTA2.TIKKB = DB_NullReplace(dt.Rows(j)("TIKKB"), "")
                DB_BMNMTA2.ZMBMNCD = dt.Rows(j)("DATKB")
                DB_BMNMTA2.ZMCD = dt.Rows(j)("ZMCD")
                DB_BMNMTA2.ZMJGYCD = dt.Rows(j)("ZMJGYCD")
                DB_BMNMTA2.OPEID = dt.Rows(j)("OPEID")
                DB_BMNMTA2.CLTID = dt.Rows(j)("CLTID")
                DB_BMNMTA2.UOPEID = dt.Rows(j)("UOPEID")
                DB_BMNMTA2.WRTDT = dt.Rows(j)("WRTDT")
                DB_BMNMTA2.WRTDT = dt.Rows(j)("WRTDT")
                DB_BMNMTA2.WRTTM = dt.Rows(j)("WRTTM")
                DB_BMNMTA2.UWRTDT = dt.Rows(j)("UWRTDT")
                DB_BMNMTA2.UWRTTM = dt.Rows(j)("UWRTTM")
                Call SCR_FromMfil(I)
                '20190807 CHG START
                '            Call DP_SSSMAIN_V_DATKB(I, DB_BMNMTA.DATKB) '2006.11.07
                'Call DP_SSSMAIN_V_ENDTKD(I, DB_BMNMTA.ENDTKDT) '2006.11.07
                'Call DP_SSSMAIN_V_BMNNM(I, DB_BMNMTA.BMNNM) '2006.11.07
                'Call DP_SSSMAIN_V_BMNZP(I, DB_BMNMTA.BMNZP) '2006.11.07
                'Call DP_SSSMAIN_V_BMNADA(I, DB_BMNMTA.BMNADA) '2006.11.07
                'Call DP_SSSMAIN_V_BMNADB(I, DB_BMNMTA.BMNADB) '2006.11.07
                'Call DP_SSSMAIN_V_BMNADC(I, DB_BMNMTA.BMNADC) '2006.11.07
                'Call DP_SSSMAIN_V_BMNTL(I, DB_BMNMTA.BMNTL) '2006.11.07
                'Call DP_SSSMAIN_V_BMNFX(I, DB_BMNMTA.BMNFX) '2006.11.07
                'Call DP_SSSMAIN_V_BMNURL(I, DB_BMNMTA.BMNURL) '2006.11.07
                'Call DP_SSSMAIN_V_BMNCDU(I, DB_BMNMTA.BMNCDUP) '2006.11.07
                'Call DP_SSSMAIN_V_ZMJGYC(I, DB_BMNMTA.ZMJGYCD) '2006.11.07
                'Call DP_SSSMAIN_V_ZMCD(I, DB_BMNMTA.ZMCD) '2006.11.07
                'Call DP_SSSMAIN_V_ZMBMNC(I, DB_BMNMTA.ZMBMNCD) '2006.11.07
                'Call DP_SSSMAIN_V_EIGYOC(I, DB_BMNMTA.EIGYOCD) '2006.11.07
                'Call DP_SSSMAIN_V_TIKKB(I, DB_BMNMTA.TIKKB) '2006.11.07
                'Call DP_SSSMAIN_V_HTANCD(I, DB_BMNMTA.HTANCD) '2006.11.07
                'Call DP_SSSMAIN_V_STANCD(I, DB_BMNMTA.STANCD) '2006.11.07
                'Call DP_SSSMAIN_V_BMNPRN(I, DB_BMNMTA.BMNPRNM) '2006.11.07
                Call DP_SSSMAIN_V_DATKB(I, DB_BMNMTA2.DATKB) '2006.11.07
                Call DP_SSSMAIN_V_ENDTKD(I, DB_BMNMTA2.ENDTKDT) '2006.11.07
                Call DP_SSSMAIN_V_BMNNM(I, DB_BMNMTA2.BMNNM) '2006.11.07
                Call DP_SSSMAIN_V_BMNZP(I, DB_BMNMTA2.BMNZP) '2006.11.07
                Call DP_SSSMAIN_V_BMNADA(I, DB_BMNMTA2.BMNADA) '2006.11.07
                Call DP_SSSMAIN_V_BMNADB(I, DB_BMNMTA2.BMNADB) '2006.11.07
                Call DP_SSSMAIN_V_BMNADC(I, DB_BMNMTA2.BMNADC) '2006.11.07
                Call DP_SSSMAIN_V_BMNTL(I, DB_BMNMTA2.BMNTL) '2006.11.07
                Call DP_SSSMAIN_V_BMNFX(I, DB_BMNMTA2.BMNFX) '2006.11.07
                Call DP_SSSMAIN_V_BMNURL(I, DB_BMNMTA2.BMNURL) '2006.11.07
                Call DP_SSSMAIN_V_BMNCDU(I, DB_BMNMTA2.BMNCDUP) '2006.11.07
                Call DP_SSSMAIN_V_ZMJGYC(I, DB_BMNMTA2.ZMJGYCD) '2006.11.07
                Call DP_SSSMAIN_V_ZMCD(I, DB_BMNMTA2.ZMCD) '2006.11.07
                Call DP_SSSMAIN_V_ZMBMNC(I, DB_BMNMTA2.ZMBMNCD) '2006.11.07
                Call DP_SSSMAIN_V_EIGYOC(I, DB_BMNMTA2.EIGYOCD) '2006.11.07
                Call DP_SSSMAIN_V_TIKKB(I, DB_BMNMTA2.TIKKB) '2006.11.07
                Call DP_SSSMAIN_V_HTANCD(I, DB_BMNMTA2.HTANCD) '2006.11.07
                Call DP_SSSMAIN_V_STANCD(I, DB_BMNMTA2.STANCD) '2006.11.07
                Call DP_SSSMAIN_V_BMNPRN(I, DB_BMNMTA2.BMNPRNM) '2006.11.07






                '            svBMNCD = DB_BMNMTA.BMNCD
                'svENDTKDT = DB_BMNMTA.WRTFSTDT
                'If DB_BMNMTA.DATKB = "9" Then
                svBMNCD = DB_BMNMTA2.BMNCD
                svENDTKDT = DB_BMNMTA2.WRTFSTDT
                If DB_BMNMTA2.DATKB = "9" Then
                    Call DP_SSSMAIN_UPDKB(I, "削除")
                Else
                    Call DP_SSSMAIN_UPDKB(I, "更新")
                End If
                'Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCDUP & "        ", BtrNormal)

                ' Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA2.BMNCDUP & "        ", BtrNormal)

                Dim strSQL1 As String = ""
                strSQL1 = "Select * From BMNMTA  Where BMNCDUP  = '" & DB_BMNMTA2.BMNCDUP & "' "
                Dim dt1 As DataTable = DB_GetTable(strSQL1)

                '20190807 CHG END

                '''' UPD 2009/08/25  FKS) T.Yamamoto    Start    連絡票№:FC09082501
                '            If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) Then
                '                Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
                '            Else
                '                Call DP_SSSMAIN_BMNNMUP(I, "")
                '            End If
                Call DP_SSSMAIN_BMNNMUP(I, "")

                'Do While (DBSTAT = 0)
                '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCDUP(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    '20190807 CHG START
                '    'If (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
                '    '    Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
                '    If (DB_BMNMTA2.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA2.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA2.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
                '        Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA2.BMNNM)
                '        '20190807 CHG END
                '        Exit Do
                '    End If
                '    Call DB_GetNext(DBN_BMNMTA, BtrNormal)
                'Loop

                For k As Integer = 0 To dt1.Rows.Count - 1
                    If (DB_BMNMTA2.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA2.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA2.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
                        Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA2.BMNNM)
                        '20190807 CHG END
                        Exit For
                    End If
                Next
                '''' UPD 2009/08/25  FKS) T.Yamamoto    End
                I = I + 1

                ''''''''''''Call DB_GetGrEq(DBN_BMNMTA, 1, svBMNCD, BtrNormal)
                strKEY = svBMNCD & svENDTKDT
                strSQL = ""
                strSQL = strSQL & "SELECT *"
                strSQL = strSQL & "  FROM   ("
                strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
                strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
                strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
                strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
                strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
                strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
                strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
                strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
                strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
                strSQL = strSQL & "                    BMN.PGID "
                strSQL = strSQL & "             From BMNMTA BMN"
                strSQL = strSQL & "             ) TBL"
                strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(strKEY) & "'"
                strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
                Dim dt3 As DataTable = DB_GetTable(strSQL)
                ' Call DB_GetSQL2(DBN_BMNMTA, strSQL)
            End If
        Next



        If DBSTAT = 0 Then
            '20190807 CHG START
            'SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.WRTFSTDT
            SSS_LASTKEY.Value = DB_BMNMTA2.BMNCD & DB_BMNMTA2.WRTFSTDT
            '20190807 CHG END
        Else
            'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190807 CHG START
            'SSS_LASTKEY.Value = HighValue(LenWid(DB_BMNMTA.BMNCD)) & HighValue(LenWid(DB_BMNMTA.WRTFSTDT))
            SSS_LASTKEY.Value = HighValue(LenWid(DB_BMNMTA2.BMNCD)) & HighValue(LenWid(DB_BMNMTA2.WRTFSTDT))
            '20190807 CHG END
        End If
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim wkCRW As System.Windows.Forms.Control
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(2 + (lngI * 23)) = 1             '2006.11.07
			''''    CL_SSSMAIN(23 + (lngI * 23)) = 1            '2006.11.07
			''''    CL_SSSMAIN(24 + (lngI * 23)) = 1            '2006.11.07
			CL_SSSMAIN(2 + (lngI * 42)) = 1
			CL_SSSMAIN(23 + (lngI * 42)) = 1
			CL_SSSMAIN(24 + (lngI * 42)) = 1
		Next

        '運用日取得
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")

        '実行権限チェック
        gs_userid = Left(SSS_OPEID.Value, 6) 'ユーザID
		gs_pgid = SSS_PrgId 'プログラムID
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("実行権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If

        'マスタ値取得（固定値マスタ）
        ' Call DB_GetEq(DBN_FIXMTA, 1, "506", BtrNormal) '14
        Dim strSQL1 As String = ""
        strSQL1 = strSQL1 & "  Where CTLCD  = '506' "

        Call GetRowsCommon("FIXMTA", strSQL1)

        If DBSTAT = 0 Then Len506 = CShort(DB_FIXMTA.FIXVAL)

        'Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal) '2
        Dim strSQL2 As String = ""
        strSQL2 = strSQL2 & "  Where CTLCD  = '507' "

        Call GetRowsCommon("FIXMTA", strSQL2)
        If DBSTAT = 0 Then Len507 = CShort(DB_FIXMTA.FIXVAL)

        ' Call DB_GetEq(DBN_FIXMTA, 1, "508", BtrNormal) '8
        Dim strSQL3 As String = ""
        strSQL3 = strSQL3 & "  Where CTLCD  = '508' "

        Call GetRowsCommon("FIXMTA", strSQL3)

        If DBSTAT = 0 Then Len508 = CShort(DB_FIXMTA.FIXVAL)

        ' Call DB_GetEq(DBN_FIXMTA, 1, "509", BtrNormal) '4
        Dim strSQL4 As String = ""
        strSQL4 = strSQL4 & "  Where CTLCD  = '509' "

        Call GetRowsCommon("FIXMTA", strSQL4)
        If DBSTAT = 0 Then Len509 = CShort(DB_FIXMTA.FIXVAL)

        ' Call DB_GetEq(DBN_FIXMTA, 1, "511", BtrNormal) '4
        Dim strSQL5 As String = ""
        strSQL5 = strSQL5 & "  Where CTLCD  = '511' "

        Call GetRowsCommon("FIXMTA", strSQL5)
        If DBSTAT = 0 Then Len511 = CShort(DB_FIXMTA.FIXVAL)

    End Sub
	
	Function MST_NEXT() As Short
		Dim rtn As Short
		Dim strSQL As String
		'
		''''Call DB_GetGrEq(DBN_BMNMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
		Call DB_GetSQL2(DBN_BMNMTA, strSQL)
		
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I As Short
		Dim strSQL As String
		'
		I = SET_GAMEN_KEY()
		I = 0
		''''Call DB_GetLs(DBN_BMNMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD DESC, TBL.WRTFSTDT DESC"
		
		Call DB_GetSQL2(DBN_BMNMTA, strSQL)
		
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			DB_PARA(DBN_BMNMTA).nDirection = 2
			Call DB_GetPre(DBN_BMNMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
            '        Call DB_GetFirst(DBN_BMNMTA, 1, BtrNormal)
            '20190807 CHG START
            'SSS_LASTKEY.Value = Space(Len(DB_BMNMTA.BMNCD)) & VB6.Format(DB_BMNMTA.WRTFSTDT, "00000000")
            SSS_LASTKEY.Value = Space(Len(DB_BMNMTA2.BMNCD)) & VB6.Format(DB_BMNMTA2.WRTFSTDT, "00000000")
        Else
            'SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.WRTFSTDT
            SSS_LASTKEY.Value = DB_BMNMTA2.BMNCD & DB_BMNMTA2.WRTFSTDT
            '20190807 CHG END
        End If
		
		I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
        '
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190807 CHG START
        'DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCD(0)
        DB_BMNMTA2.BMNCD = RD_SSSMAIN_BMNCD(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(RD_SSSMAIN_ENDTKDT(0)) = "" Then
            'DB_BMNMTA.ENDTKDT = "00000000"
            DB_BMNMTA2.ENDTKDT = "00000000"
        Else
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_BMNMTA.ENDTKDT = VB6.Format(99999999 - Val(RD_SSSMAIN_ENDTKDT(0)), "00000000")
            DB_BMNMTA2.ENDTKDT = VB6.Format(99999999 - Val(RD_SSSMAIN_ENDTKDT(0)), "00000000")
        End If

        'SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.ENDTKDT
        SSS_LASTKEY.Value = DB_BMNMTA2.BMNCD & DB_BMNMTA2.ENDTKDT
        '20190807 CHG END
        SET_GAMEN_KEY = 4
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim rtn As Short
		
		'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			rtn = DSP_MsgBox(CStr(0), "NO_ENTRY", 0) 'データを入力して下さい
			'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module