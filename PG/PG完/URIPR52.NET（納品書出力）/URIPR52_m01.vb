Option Strict Off
Option Explicit On
Module URIPR52_M01
	'
	' スロット名        : 納品書・メインファイル更新スロット
	' ユニット名        : URIPR52.M01
	' 記述者            : Standard Library
	' 作成日付          : 1997/06/30
	' 使用プログラム名  : URIPR52
	'
	'
	'   |              |              |
	'   |    |    |    |    |    |    |
	'---+----+----+****+////+----+----+----+---
	'   |    |    | N  | R  |    |    |
	'   |           P  | P            |
	'               S ↑ S ↑
	'               N-+  N-+
	
	'20081223 ADD START RISE)Tanimura '連絡票No.643
	Structure M_TYPE_EVTTBL_PARA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVWRDT() As Char ' イベント発生日
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public IVWRTM() As Char ' イベント発生時間
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public PGID() As Char ' プログラムＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public IVCLASS() As Char ' イベント種別
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVCODE() As Char ' イベントコード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public IVPOINT() As Char ' イベント発生箇所
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SNDPROFLG() As Char ' 送信可否フラグ
		Dim IVMSG As String ' イベント内容
	End Structure
	Private M_EVTTBL_PARA As M_TYPE_EVTTBL_PARA
    '20081223 ADD END   RISE)Tanimura

    '2019.04.15 add start
    Public wCount As Integer = 0
    Public wUdnthaSql As String
    '2019.04.15 add end

    Function CHK_LCTL() As Short
		' 印字抑制
		'''   If DB_URIPR52.URIKN = 0 Then
		'''      CHK_LCTL = False
		'''   Else
		CHK_LCTL = True ' 印字する
		'''   End If
	End Function
	
	Function ENDCHK() As Short
		' 終了条件判定
		If DB_UDNTHA.DATKB = "9" Then
			ENDCHK = True
			Exit Function
		Else
			ENDCHK = False
		End If
		If WG_KINKYU = "1" Then
			If DB_UDNTHA.EMGODNKB <> "9" Then
				ENDCHK = True
				Exit Function
			End If
		End If
		If WG_KINKYU = "2" Then
			If DB_UDNTHA.EMGODNKB <> "1" Then
				ENDCHK = True
				Exit Function
			End If
		End If
		'''    If WG_KINKYU <> DB_UDNTHA.EMGODNKB Then
		'''        ENDCHK = True
		'''        Exit Function
		'''    Else
		'''        ENDCHK = False
		'''    End If
		If WG_PRTKB <> "0" And DB_UDNTHA.UDNPRAKB = "9" Then
			ENDCHK = True
			Exit Function
		Else
			ENDCHK = False
		End If
	End Function

    '2019.04.18 chg start
    '    Sub Loop_Mfil()
    Sub Loop_Mfil(Optional ByRef result As Integer = 9)
        '2019.04.19 chg end
        Dim MCHK As String
        '
        Dim WK_UDNDT As String
        ''''2007.02.07 UPD START
        '''    Dim WK_JDNNO    As String
        Dim WK_FDNNO As String
        ''''2007.02.07 UPD END
        Dim WK_CNT1 As Integer
        Dim WK_CNT2 As Integer '得意先・納入先内の行カウント
        Dim WK_CNT3 As Integer 'ページ内の行カウント
        Dim WK_CNT4 As Integer '行番号出力用カウント
        Dim WK_CNT5 As Integer '総ページ数算出用カウント
        Dim WK_MAXPAGE As Integer
        Dim WK_PAGE As Integer
        Dim WK_MAXGYO As Integer
        Dim WK_SUMURIKN As Integer
        Dim WK_SUMUZEKN As Integer
        Dim WK_DENCM As String
        Dim wkMEICDA As String
        Dim wkSITEI As String
        Dim wkTOKDNKB As String
        Dim wkBRK As Boolean

        Dim strSQL As String
        'add-S-tom***
        Dim W_BUMCD As String
        'add-E-tom***

        '20081223 ADD START RISE)Tanimura '連絡票No.643
        Dim strExePath As String
        '20081223 ADD END   RISE)Tanimura
        'ADD START FKS)INABA 2010/05/27 ******************************
        '連絡票№789
        Dim wk_MFILKEYNO() As String
        Dim wk_DATNO_E As String
        Dim lw_CNT As Short
        Dim lw_CNT1 As Short
        Dim ls_NewFLG As String
        Dim Rtn As Object
        lw_CNT = 0
        ls_NewFLG = ""
        'ADD  END  FKS)INABA 2010/05/27 ******************************

        'add-S-tom***
        W_BUMCD = ""
        'add-E-tom***

        WK_CNT1 = 0
        WK_CNT2 = 0
        WK_CNT3 = 0
        WK_PAGE = 1
        WK_SUMURIKN = 0
        WK_SUMUZEKN = 0
        wkSITEI = "0"
        wkBRK = False

        Call WK_FromScr(0)
        '
        MCHK = SEL_RECORD()
        '2019.04.22 add start
        If SSS_LSTOP Then
           Exit sub
        End If
        '2019.04.22 add end

        Do Until MCHK = "END"

            '2019.04.15 del start
            'Call CNT_GAUGE()
            '2019.04.15 del end

            '20081223 ADD START RISE)Tanimura '連絡票No.643
            If DB_UDNTHA.JDNTRKB <> "31" Then
                ' 部門コードを取得する
                W_BUMCD = Get_HenBmn(DB_UDNTHA.BUMCD, DB_UDNTHA.UDNDT, DB_UDNTHA.JDNNO)

                'delete start 20190808 kuwahara
                'Call BMNMTA_RClear()
                'delete end 20190808 kuwahara

                '2019.04.16 chg start
                'strSQL = ""
                'strSQL = strSQL & "SELECT"
                'strSQL = strSQL & "  * "
                'strSQL = strSQL & "FROM"
                'strSQL = strSQL & "  BMNMTA "
                'strSQL = strSQL & "WHERE"
                'strSQL = strSQL & "  DATKB    = '1' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  BMNCD    = '" & W_BUMCD & "' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  STTTKDT <= '" & DB_UDNTHA.UDNDT & "' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  ENDTKDT >= '" & DB_UDNTHA.UDNDT & "' "

                'Call DB_GetSQL2(DBN_BMNMTA, strSQL)

                DBSTAT = DSPBMNCD_SEARCH(W_BUMCD, DB_BMNMTA, DB_UDNTHA.UDNDT)
                '2019.04.16 chg end

                ' 部門マスタに存在しなかった場合
                If DBSTAT <> 0 Then
                    ' イベントテーブルへメッセージを書き込む
                    With M_EVTTBL_PARA
                        .IVWRDT = VB6.Format(Now, "YYYYMMDD") ' イベント発生日
                        .IVWRTM = VB6.Format(Now, "HHMMSS") ' イベント発生時間
                        .PGID = SSS_PrgId ' プログラムＩＤ
                        .CLTID = SSS_CLTID.Value ' クライアントＩＤ
                        .IVCLASS = "ERR" ' イベント種別
                        .IVCODE = "0" ' イベントコード
                        .IVPOINT = "Loop_Mfil" ' イベント発生箇所
                        .SNDPROFLG = "1" ' 送信可否フラグ
                        .IVMSG = "部門マスタに登録されていない部門コードのため、納品書を印刷出来ませんでした。" & "（売上伝票番号 = " & DB_UDNTHA.UDNNO & "　部門コード = " & W_BUMCD & "　売上日 = " & DB_UDNTHA.UDNDT & "）" ' イベント内容

                        strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
                    End With
                    '2019.04.18 del start
                    'Call Shell(strExePath)
                    '2019.04.18 del end
                    GoTo NEXT_PAGE
                End If

                ' 営業所コードを取得する
                '2019.04.16 chg start
                'wkMEICDA = DB_BMNMTA.EIGYOCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_BMNMTA.EIGYOCD))
                wkMEICDA = DB_BMNMTA.EIGYOCD & Space(20 - Len(DB_BMNMTA.EIGYOCD))
                '2019.04.16 chg end

                'delete start 20190808 kuwahara
                'Call MEIMTC_RClear()
                'delete end 20190808 kuwahara

                '2019.04.16 chg start
                'strSQL = ""
                'strSQL = strSQL & "SELECT"
                'strSQL = strSQL & "  * "
                'strSQL = strSQL & "FROM"
                'strSQL = strSQL & "  MEIMTC "
                'strSQL = strSQL & "WHERE"
                'strSQL = strSQL & "  DATKB    = '1' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  KEYCD    = '058' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  MEICDA   = '" & wkMEICDA & "' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  STTTKDT <= '" & DB_BMNMTA.STTTKDT & "' "
                'strSQL = strSQL & "AND"
                'strSQL = strSQL & "  ENDTKDT >= '" & DB_BMNMTA.STTTKDT & "' "

                'Call DB_GetSQL2(DBN_MEIMTC, strSQL)
                strSQL = ""
                strSQL = strSQL & "WHERE"
                strSQL = strSQL & "  DATKB    = '1' "
                strSQL = strSQL & "AND"
                strSQL = strSQL & "  KEYCD    = '058' "
                strSQL = strSQL & "AND"
                strSQL = strSQL & "  MEICDA   = '" & wkMEICDA & "' "
                strSQL = strSQL & "AND"
                strSQL = strSQL & "  STTTKDT <= '" & DB_BMNMTA.STTTKDT & "' "
                strSQL = strSQL & "AND"
                strSQL = strSQL & "  ENDTKDT >= '" & DB_BMNMTA.STTTKDT & "' "
                'change start 20190808 kuwahara
                'MEIMTC_GetFirstRecWhere(strSQL)
                GetRowsCommon("MEIMTC", strSQL)
                'change end 20190808 kuwahara
                '2019.04.16 chg end

                ' 適用日名称マスタの範囲内に存在しなかった場合
                If DBSTAT <> 0 Then
                    ' イベントテーブルへメッセージを書き込む
                    With M_EVTTBL_PARA
                        .IVWRDT = VB6.Format(Now, "YYYYMMDD") ' イベント発生日
                        .IVWRTM = VB6.Format(Now, "HHMMSS") ' イベント発生時間
                        .PGID = SSS_PrgId ' プログラムＩＤ
                        .CLTID = SSS_CLTID.Value ' クライアントＩＤ
                        .IVCLASS = "ERR" ' イベント種別
                        .IVCODE = "0" ' イベントコード
                        .IVPOINT = "Loop_Mfil" ' イベント発生箇所
                        .SNDPROFLG = "1" ' 送信可否フラグ
                        .IVMSG = "適用日名称マスタに登録されていない営業所コードのため、納品書を印刷出来ませんでした。" & "（売上伝票番号 = " & DB_UDNTHA.UDNNO & "　部門コード = " & W_BUMCD & "　キー = 058" & "　営業所コード = " & DB_BMNMTA.EIGYOCD & "　適用開始日 = " & DB_BMNMTA.STTTKDT & "）" ' イベント内容

                        strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
                    End With
                    '2019.04.18 del start
                    'Call Shell(strExePath)
                    '2019.04.18 del end
                    GoTo NEXT_PAGE
                End If

                'delete start 20190808 kuwahara
                'Call BMNMTB_RClear()
                'delete end 20190808 kuwahara

                '2019.04.17 chg start
                'If DB_TOKMTA.TOKDNKB = "2" Then
                '    Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTC.MEIKBC), BtrNormal)
                'Else
                '    Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTC.MEIKBB), BtrNormal)
                'End If
                strSQL = ""
                strSQL = strSQL & "WHERE"
                If DB_TOKMTA.TOKDNKB = "2" Then
                    strSQL = strSQL & "  NHADCD    = '" & Trim(DB_MEIMTC.MEIKBC) & "'"
                Else
                    strSQL = strSQL & "  NHADCD    = '" & Trim(DB_MEIMTC.MEIKBB) & "'"
                End If
                'change start 20190808 kuwahara
                'BMNMTB_GetFirstRecWhere(strSQL)
                GetRowsCommon("BMNMTB", strSQL)
                'change end 20190808 kuwahara
                '2019.04.17 chg end

                ' 対外帳票住所マスタに存在しなかった場合
                If DBSTAT <> 0 Then
                    ' イベントテーブルへメッセージを書き込む
                    With M_EVTTBL_PARA
                        .IVWRDT = VB6.Format(Now, "YYYYMMDD") ' イベント発生日
                        .IVWRTM = VB6.Format(Now, "HHMMSS") ' イベント発生時間
                        .PGID = SSS_PrgId ' プログラムＩＤ
                        .CLTID = SSS_CLTID.Value ' クライアントＩＤ
                        .IVCLASS = "ERR" ' イベント種別
                        .IVCODE = "0" ' イベントコード
                        .IVPOINT = "Loop_Mfil" ' イベント発生箇所
                        .SNDPROFLG = "1" ' 送信可否フラグ
                        .IVMSG = "対外帳票住所マスタに登録されていない対外帳票住所コードのため、納品書を印刷出来ませんでした。" & "（売上伝票番号 = " & DB_UDNTHA.UDNNO & "　対外帳票住所コード = " & IIf(DB_TOKMTA.TOKDNKB = "2", Trim(DB_MEIMTC.MEIKBC), Trim(DB_MEIMTC.MEIKBB)) & "　部門コード = " & W_BUMCD & "　営業所コード = " & DB_BMNMTA.EIGYOCD & "）" ' イベント内容

                        strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
                    End With
                    '2019.04.18 del start
                    'Call Shell(strExePath)
                    '2019.04.18 del end
                    GoTo NEXT_PAGE
                End If
            End If
            '20081223 ADD END   RISE)Tanimura

            '
            ''''2007.02.07 DLT START
            '''        Call DB_GetSQL2(DBN_UDNTRA, "select COUNT(*) from UDNTRA where UDNDT = '" & DB_UDNTHA.UDNDT & "'  and JDNNO = '" & DB_UDNTHA.JDNNO & "'  and LINNO < '990'  ")
            '''        WK_CNT5 = DB_ExtNum.ExtNum(0)
            '''        If RD_SSSMAIN_HAKKOU(-1) = "1" Then
            '''            If DB_TOKMTA.TOKDNKB = "2" Then
            '''                WK_MAXPAGE = WK_CNT5
            '''            Else
            '''                If WK_CNT5 < 16 Then
            '''                    WK_MAXPAGE = 1
            '''                Else
            '''                    WK_MAXPAGE = Int(((WK_CNT5 - 16) / 22) + 0.99 + 1)
            '''                End If
            '''            End If
            '''        Else
            '''            If WK_CNT5 < 16 Then
            '''                WK_MAXPAGE = 1
            '''            Else
            '''                WK_MAXPAGE = Int(((WK_CNT5 - 16) / 22) + 0.99 + 1)
            '''            End If
            '''        End If
            ''''2007.02.07 DLT END
            '''
            '2019.04.17 chg start
            'Call DB_GetGrEq(DBN_UDNTRA, 1, DB_UDNTHA.DATNO & "001", BtrNormal)
            strSQL = ""
            strSQL = strSQL & "WHERE"
            strSQL = strSQL & "  DATNO    = '" & DB_UDNTHA.DATNO & "'"
            'strSQL = strSQL & "AND"
            'strSQL = strSQL & "  LINNO    = '001' "
            'change start 20190809 kuwahara
            'UDNTRA_GetFirstRecWhere(strSQL)
            GetRowsCommon("UDNTRA", strSQL)
            'change end 20190809 kuwahara
            Dim strSqlUdntra As String = strSQL
            Dim countUdntra As Integer = 1
            '2019.04.17 chg end

            '2019.04.08 CHG START
            'Do While DBSTAT = 0 And DB_UDNTHA.DATNO = DB_UDNTRA.DATNO And CDbl(DB_UDNTRA.LINNO) < 990
            Do While DBSTAT = 0 And DB_UDNTHA.DATNO = IIf(IsNothing(DB_UDNTRA.DATNO), 0, DB_UDNTRA.DATNO) And Integer.Parse(IIf(IsNothing(DB_UDNTRA.LINNO), 0, DB_UDNTRA.LINNO)) < 990
                '2019.04.08 CHG END
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HAKKOU(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If RD_SSSMAIN_HAKKOU(-1) = "1" Then
                    If wkTOKDNKB = "2" Then
                        wkSITEI = "1"
                    Else
                        wkSITEI = "0"
                    End If
                Else
                    wkSITEI = "0"
                End If
                If wkSITEI = "1" Then
                    wkBRK = True
                Else
                    wkBRK = False
                End If

                If WK_CNT1 = 0 Then
                    WK_UDNDT = DB_UDNTHA.UDNDT
                    ''''2007.02.07 UPD START
                    '''               WK_JDNNO = DB_UDNTHA.JDNNO
                    WK_FDNNO = DB_UDNTHA.FDNNO
                    ''''2007.02.07 UPD END
                    Call URIPR52_RClear()
                End If
                WK_CNT1 = WK_CNT1 + 1
                WK_CNT2 = WK_CNT2 + 1
                WK_CNT3 = WK_CNT3 + 1
                ''''2007.02.07 UPD START
                '''            If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_JDNNO <> DB_UDNTHA.JDNNO Or _
                ''''              (WK_CNT2 = WK_CNT3 And WK_CNT3 > 16) Or (WK_CNT2 > WK_CNT3 And WK_CNT3 > 22) Or (wkBRK = True) Then
                If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_FDNNO <> DB_UDNTHA.FDNNO Or (WK_CNT2 = WK_CNT3 And WK_CNT3 > 16) Or (WK_CNT2 > WK_CNT3 And WK_CNT3 > 22) Or (wkBRK = True) Then
                    ''''2007.02.07 UPD END
                    'プリントパターン・再発行・発行失敗の編集
                    If WK_CNT2 = WK_CNT3 Then
                        DB_URIPR52.PRTPATN = "1"
                    Else
                        DB_URIPR52.PRTPATN = "2"
                    End If
                    If wkSITEI = "1" Then
                        DB_URIPR52.PRTPATN = "3"
                        DB_URIPR52.PRTLINNO(0) = "01" '2007.03.12
                    End If
                    If WG_PRTKB = "1" Then
                        DB_URIPR52.PRTKBNM = "再発行"
                    Else
                        DB_URIPR52.PRTKBNM = "　　　"
                    End If
                    If WG_PRTKB = "9" Then
                        DB_URIPR52.SIPPAI = "*"
                    Else
                        DB_URIPR52.SIPPAI = " "
                    End If
                    'フッタ部セット
                    ''''2007.02.07 UPD START
                    '''                If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_JDNNO <> DB_UDNTHA.JDNNO Or wkSITEI = "1" Then
                    If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_FDNNO <> DB_UDNTHA.FDNNO Or wkSITEI = "1" Then
                        ''''2007.02.07 UPD END
                        DB_URIPR52.DENCM = WK_DENCM
                        DB_URIPR52.SBAURIKN = WK_SUMURIKN
                        DB_URIPR52.SBAUZEKN = WK_SUMUZEKN
                        DB_URIPR52.SBAUZKKN = WK_SUMURIKN + WK_SUMUZEKN
                    End If
                    If CHK_LCTL() Then
                        '2019.04.17 chg start
                        'Call DB_Insert(DBN_URIPR52, 1)
                        InsertURIPR52(DB_URIPR52)
                        '2019.04.17 chg end
                        SSS_LFILCNT = SSS_LFILCNT + 1
                    End If
                    ''''2007.02.07 ADD START
                    'ＭＡＸページ数更新
                    If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_FDNNO <> DB_UDNTHA.FDNNO Or wkSITEI = "1" Then
                        strSQL = ""
                        '2019.04.18 chg start
                        'strSQL = strSQL & "UPDATE URIPR52 SET URIPR52.MAXPAGE = '" & WK_MAXPAGE & "'"
                        strSQL = strSQL & "UPDATE CNT_USR9.URIPR52 SET URIPR52.MAXPAGE = '" & WK_MAXPAGE & "'"
                        '2019.04.18 chg end
                        strSQL = strSQL & " WHERE DENDT = '" & WK_UDNDT & "'"
                        strSQL = strSQL & "   AND FDNNO = '" & WK_FDNNO & "'"
                        strSQL = strSQL & "   AND RPTCLTID = '" & SSS_CLTID.Value & "'"
                        '2019.04.18 chg start
                        'Call DB_Execute(DBN_URIPR52, strSQL)
                        Call DB_Execute(strSQL)
                        '2019.04.18 chg end
                    End If
                    ''''2007.02.07 ADD END




                    '行カウント初期設定＆集計項目クリア
                    ''''2007.02.07 UPD START
                    '''                If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_JDNNO <> DB_UDNTHA.JDNNO Then
                    If WK_UDNDT <> DB_UDNTHA.UDNDT Or WK_FDNNO <> DB_UDNTHA.FDNNO Then
                        ''''2007.02.07 UPD END
                        WK_CNT2 = 1
                        WK_PAGE = 1
                        WK_SUMURIKN = 0
                        WK_SUMUZEKN = 0
                    End If
                    WK_CNT3 = 1
                    Call URIPR52_RClear()
                End If
                Call Mfil_FromSCR(0)
                Call URIPR52_FromUDNTRA()
                If WK_CNT3 = 1 Then
                    'ヘッダ部セット
                    Call URIPR52_FromUDNTHA()
                    ''''''''''''''''If Trim$(DB_UDNTHA.NHSCD) = "" Then
                    '2019.04.17 chg start
                    'Call DB_GetEq(DBN_TOKMTA, 1, DB_UDNTHA.TOKCD, BtrNormal)
                    'change start 20190808 kuwahara
                    'TOKMTA_GetFirst(DB_UDNTHA.TOKCD)
                    Dim strsql2 As String = "where TOKCD = '" & DB_UDNTHA.TOKCD & "'"
                    GetRowsCommon("TOKMTA", strsql2)
                    'change end 20190808 kuwahara
                    '2019.04.17 chg end

                    DB_URIPR52.NHSNMA = DB_TOKMTA.TOKNMA
                    DB_URIPR52.NHSNMB = DB_TOKMTA.TOKNMB
                    DB_URIPR52.NHSZP = DB_TOKMTA.TOKZP
                    DB_URIPR52.NHSADA = DB_TOKMTA.TOKADA
                    DB_URIPR52.NHSADB = DB_TOKMTA.TOKADB
                    DB_URIPR52.NHSADC = DB_TOKMTA.TOKADC
                    DB_URIPR52.NHSTL = DB_TOKMTA.TOKTL
                    DB_URIPR52.NHSFX = DB_TOKMTA.TOKFX
                    DB_URIPR52.NHSCD = DB_UDNTHA.TOKCD
                    ''''''''''''''''Else
                    ''''''''''''''''    Call DB_GetEq(DBN_NHSMTA, 1, DB_UDNTHA.NHSCD, BtrNormal)
                    ''''''''''''''''    DB_URIPR52.NHSNMA = DB_UDNTHA.NHSNMA
                    ''''''''''''''''    DB_URIPR52.NHSNMB = DB_UDNTHA.NHSNMB
                    ''''''''''''''''    DB_URIPR52.NHSZP = DB_NHSMTA.NHSZP
                    ''''''''''''''''    DB_URIPR52.NHSADA = DB_UDNTHA.NHSADA
                    ''''''''''''''''    DB_URIPR52.NHSADB = DB_UDNTHA.NHSADB
                    ''''''''''''''''    DB_URIPR52.NHSADC = DB_UDNTHA.NHSADC
                    ''''''''''''''''    DB_URIPR52.NHSTL = DB_NHSMTA.NHSTL
                    ''''''''''''''''    DB_URIPR52.NHSFX = DB_NHSMTA.NHSFX
                    ''''''''''''''''    DB_URIPR52.NHSCD = DB_UDNTHA.NHSCD
                    ''''''''''''''''End If
                    DB_URIPR52.FDNNO = DB_UDNTHA.FDNNO
                    ''''2007.01.29 UPD
                    ''''            DB_URIPR52.PRTDT = DB_UNYMTA.UNYDT
                    DB_URIPR52.PRTDT = DB_UDNTHA.UDNDT
                    '''                Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
                    '''                If DBSTAT = 0 Then
                    '''                    DB_URIPR52.BUMNM = DB_SYSTBA.USRNMA
                    '''                End If

                    '''                Call DB_GetEq(DBN_BMNMTA, 1, DB_UDNTHA.BUMCD, BtrNormal)
                    '''                If DBSTAT = 0 Then Call URIPR52_FromBMNMTA
                    '''                Call DB_GetGrEq(DBN_BMNMTA, 1, DB_UDNTHA.BUMCD & "        ", BtrNormal)
                    '''                Do While DBSTAT = 0
                    '''                    If (DB_BMNMTA.BMNCD = DB_UDNTHA.BUMCD) And _
                    ''''                    (DB_BMNMTA.STTTKDT <= DB_UDNTHA.UDNDT) And _
                    ''''                    (DB_BMNMTA.ENDTKDT >= DB_UDNTHA.UDNDT) Then
                    '''                        Call URIPR52_FromBMNMTA
                    '''                    End If
                    '''                    Call DB_GetNext(DBN_BMNMTA, BtrNormal)
                    '''                Loop
                    '''
                    DB_URIPR52.EBUMNM = DB_UDNTHA.BUMNM

                    Select Case DB_UDNTHA.JDNTRKB
                        Case "31" '修理
                            'delete start 20190808 kuwahara
                            'Call BMNMTB_RClear()
                            'delete end 20190808 kuwahara
                            strSQL = ""
                            '2019.04.18 chg start
                            'strSQL = strSQL & "SELECT * FROM BMNMTB"
                            'strSQL = strSQL & " WHERE NHADCD = '8'"
                            'Call DB_GetSQL2(DBN_BMNMTB, strSQL)
                            strSQL = strSQL & " WHERE NHADCD = '8'"
                            'change start 20190808 kuwahara
                            'BMNMTB_GetFirstRecWhere(strSQL)
                            GetRowsCommon("BMNMTB", strSQL)
                            'change end 20190808 kuwahara
                            '2019.04.18 chg end
                            DB_URIPR52.BUMNM = DB_BMNMTB.BMNNM
                            DB_URIPR52.BMNZP = DB_BMNMTB.BMNZP
                            DB_URIPR52.BMNADA = DB_BMNMTB.BMNADA
                            DB_URIPR52.BMNADB = DB_BMNMTB.BMNADB
                            DB_URIPR52.BMNADC = ""
                            DB_URIPR52.BMNTL = DB_BMNMTB.BMNTL
                            DB_URIPR52.BMNFX = DB_BMNMTB.BMNFX
                            DB_URIPR52.BMNURL = DB_BMNMTB.BMNURL
                        Case Else
                            '***add-S-tom***
                            W_BUMCD = Get_HenBmn(DB_UDNTHA.BUMCD, DB_UDNTHA.UDNDT, DB_UDNTHA.JDNNO)
                            '***add-E-tom***
                            'delete start 20190808 kuwahara
                            'Call BMNMTA_RClear()
                            'delete end 20190808 kuwahara
                            '2019.04.17 chg start
                            'strSQL = ""
                            'strSQL = strSQL & "SELECT * FROM BMNMTA"
                            'strSQL = strSQL & " WHERE DATKB = '1'"
                            ''***add-S-tom***
                            ''                        strSQL = strSQL & "   AND BMNCD = '" & DB_UDNTHA.BUMCD & "'"
                            'strSQL = strSQL & "   AND BMNCD = '" & W_BUMCD & "'"
                            ''***add-E-tom***
                            'strSQL = strSQL & "   AND STTTKDT <= '" & DB_UDNTHA.UDNDT & "'"
                            'strSQL = strSQL & "   AND ENDTKDT >= '" & DB_UDNTHA.UDNDT & "'"
                            'Call DB_GetSQL2(DBN_BMNMTA, strSQL)
                            'wkMEICDA = DB_BMNMTA.EIGYOCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_BMNMTA.EIGYOCD))
                            DSPBMNCD_SEARCH(W_BUMCD, DB_BMNMTA, DB_UDNTHA.UDNDT, "1")
                            wkMEICDA = DB_BMNMTA.EIGYOCD & Space(20 - Len(DB_BMNMTA.EIGYOCD))
                            '2019.04.17 chg end
                            '20081223 CHG START RISE)Tanimura '連絡票No.643
                            '                        Call MEIMTA_RClear
                            '                        Call DB_GetEq(DBN_MEIMTA, 2, "058" & wkMEICDA, BtrNormal)
                            '                        Call BMNMTB_RClear
                            '                        If DB_TOKMTA.TOKDNKB = "2" Then
                            '                            Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTA.MEIKBC), BtrNormal)
                            '                        Else
                            '                            Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTA.MEIKBB), BtrNormal)
                            '                        End If
                            'delete start 20190808 kuwahara
                            'Call MEIMTC_RClear()
                            'delete end 20190808 kuwahara

                            ' 適用日名称マスタから対象のデータを取得する(部門マスタの適用開始日を元に抽出する)
                            '2019.04.17 chg start
                            'strSQL = ""
                            'strSQL = strSQL & "SELECT"
                            'strSQL = strSQL & "  * "
                            'strSQL = strSQL & "FROM"
                            'strSQL = strSQL & "  MEIMTC "
                            'strSQL = strSQL & "WHERE"
                            'strSQL = strSQL & "  DATKB    = '1' "
                            'strSQL = strSQL & "AND"
                            'strSQL = strSQL & "  KEYCD    = '058' "
                            'strSQL = strSQL & "AND"
                            'strSQL = strSQL & "  MEICDA   = '" & wkMEICDA & "' "
                            'strSQL = strSQL & "AND"
                            'strSQL = strSQL & "  STTTKDT <= '" & DB_BMNMTA.STTTKDT & "' "
                            'strSQL = strSQL & "AND"
                            'strSQL = strSQL & "  ENDTKDT >= '" & DB_BMNMTA.STTTKDT & "' "

                            'Call DB_GetSQL2(DBN_MEIMTC, strSQL)

                            strSQL = ""
                            strSQL = strSQL & "WHERE"
                            strSQL = strSQL & "  DATKB    = '1' "
                            strSQL = strSQL & "AND"
                            strSQL = strSQL & "  KEYCD    = '058' "
                            strSQL = strSQL & "AND"
                            strSQL = strSQL & "  MEICDA   = '" & wkMEICDA & "' "
                            strSQL = strSQL & "AND"
                            strSQL = strSQL & "  STTTKDT <= '" & DB_BMNMTA.STTTKDT & "' "
                            strSQL = strSQL & "AND"
                            strSQL = strSQL & "  ENDTKDT >= '" & DB_BMNMTA.STTTKDT & "' "
                            'change start 20190808 kuwahara
                            'MEIMTC_GetFirstRecWhere(strSQL)
                            GetRowsCommon("MEIMTC", strSQL)
                            'change end 20190808 kuwahara
                            '2019.04.17 chg end

                            'delete start 20190808 kuwahara
                            'Call BMNMTB_RClear()
                            'delete end 20190808 kuwahara

                            '2019.04.17 chg start
                            'If DB_TOKMTA.TOKDNKB = "2" Then
                            '    Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTC.MEIKBC), BtrNormal)
                            'Else
                            '    Call DB_GetEq(DBN_BMNMTB, 1, Trim(DB_MEIMTC.MEIKBB), BtrNormal)
                            'End If
                            strSQL = ""
                            strSQL = strSQL & "WHERE"
                            If DB_TOKMTA.TOKDNKB = "2" Then
                                strSQL = strSQL & "  NHADCD    = '" & Trim(DB_MEIMTC.MEIKBC) & "'"
                            Else
                                strSQL = strSQL & "  NHADCD    = '" & Trim(DB_MEIMTC.MEIKBB) & "'"
                            End If
                            'change start 20190808 kuwahara
                            'BMNMTB_GetFirstRecWhere(strSQL)
                            GetRowsCommon("BMNMTB", strSQL)
                            'change end 20190808 kuwahara
                            '2019.04.17 chg end

                            '20081223 CHG END   RISE)Tanimura
                            DB_URIPR52.BUMNM = DB_BMNMTB.BMNNM
                            DB_URIPR52.BMNZP = DB_BMNMTB.BMNZP
                            DB_URIPR52.BMNADA = DB_BMNMTB.BMNADA
                            DB_URIPR52.BMNADB = DB_BMNMTB.BMNADB
                            DB_URIPR52.BMNADC = ""
                            DB_URIPR52.BMNTL = DB_BMNMTB.BMNTL
                            DB_URIPR52.BMNFX = DB_BMNMTB.BMNFX
                            DB_URIPR52.BMNURL = DB_BMNMTB.BMNURL
                    End Select

                    DB_URIPR52.TANNM = DB_UDNTHA.TANNM
                    'ページセット
                    DB_URIPR52.PRTPAGE = WK_PAGE

                    ''''2007.02.07 UPD START
                    '''                DB_URIPR52.MAXPAGE = WK_MAXPAGE
                    WK_MAXPAGE = WK_PAGE
                    ''''2007.02.07 UPD END
                    WK_PAGE = WK_PAGE + 1

                    WK_CNT5 = 16 '2007.03.12

                    '行番号セット
                    If wkSITEI = "1" Then
                        WK_MAXGYO = WK_CNT5
                    Else
                        If WK_CNT2 = 1 Then
                            WK_MAXGYO = 16
                        Else
                            WK_MAXGYO = 22
                        End If
                    End If
                    WK_CNT4 = 0
                    '2019.04.17 add start
                    DB_URIPR52.PRTLINNO = Nothing
                    '2019.04.17 add end
                    Do Until WK_MAXGYO = WK_CNT4
                        '2019.04.17 add start
                        ReDim Preserve DB_URIPR52.PRTLINNO(WK_CNT4)
                        '2019.04.17 add end
                        DB_URIPR52.PRTLINNO(WK_CNT4) = VB6.Format(WK_CNT2 + WK_CNT4, "00")
                        WK_CNT4 = WK_CNT4 + 1
                    Loop
                End If

                'ボディ部セット
                '2019.04.17 add start
                ReDim Preserve DB_URIPR52.TOKJDNNO(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.HINCD(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.HINNMA(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.HINNMB(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.URISU(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.UNTNM(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.URITK(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.URIKN(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.UZEKN(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.PRTJDNNO(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.LINCMA(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.LINCMB(WK_CNT3 - 1)
                ReDim Preserve DB_URIPR52.TOKJDNBC(WK_CNT3 - 1)
                '2019.04.17 add end
                DB_URIPR52.TOKJDNNO(WK_CNT3 - 1) = DB_UDNTRA.TOKJDNNO
                DB_URIPR52.HINCD(WK_CNT3 - 1) = Trim(DB_UDNTRA.HINCD)
                DB_URIPR52.HINNMA(WK_CNT3 - 1) = DB_UDNTRA.HINNMA
                'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
                DB_URIPR52.HINNMB(WK_CNT3 - 1) = LeftB(DB_UDNTRA.HINNMB, 40)
                DB_URIPR52.URISU(WK_CNT3 - 1) = DB_UDNTRA.URISU
                DB_URIPR52.UNTNM(WK_CNT3 - 1) = DB_UDNTRA.UNTNM
                DB_URIPR52.URITK(WK_CNT3 - 1) = DB_UDNTRA.URITK
                DB_URIPR52.URIKN(WK_CNT3 - 1) = DB_UDNTRA.URIKN
                DB_URIPR52.UZEKN(WK_CNT3 - 1) = DB_UDNTRA.UZEKN
                ''''''''''''DB_URIPR52.PRTJDNNO(WK_CNT3 - 1) = Left(DB_UDNTRA.JDNNO, 6) & "-" & DB_UDNTRA.JDNLINNO
                DB_URIPR52.PRTJDNNO(WK_CNT3 - 1) = Left(DB_UDNTRA.JDNNO, 6) & Mid(DB_UDNTRA.JDNLINNO, 2, 2)
                DB_URIPR52.LINCMA(WK_CNT3 - 1) = DB_UDNTRA.LINCMA
                If Left(DB_UDNTRA.LINCMB, 1) = "#" Then
                    DB_URIPR52.LINCMB(WK_CNT3 - 1) = " "
                Else
                    DB_URIPR52.LINCMB(WK_CNT3 - 1) = DB_UDNTRA.LINCMB
                End If
                DB_URIPR52.SORTCD = Space(12 - Len(Trim(CStr(WK_CNT1)))) & WK_CNT1
                DB_URIPR52.TOKJDNBC(WK_CNT3 - 1) = GET_DEGIT(DB_UDNTRA.TOKJDNNO, "{", "}") '2006.11.08
                '売上金額・消費税集計
                WK_SUMURIKN = WK_SUMURIKN + DB_UDNTRA.URIKN
                WK_SUMUZEKN = WK_SUMUZEKN + DB_UDNTRA.UZEKN
                '備考退避
                WK_DENCM = DB_UDNTHA.DENCM
                'ブレーク項目退避
                WK_UDNDT = DB_UDNTHA.UDNDT
                ''''2007.02.07 UPD START
                '''            WK_JDNNO = DB_UDNTHA.JDNNO
                WK_FDNNO = DB_UDNTHA.FDNNO
                ''''2007.02.07 UPD END
                wkTOKDNKB = DB_TOKMTA.TOKDNKB
                '            If wkSITEI = "1" Then
                '                wkBRK = True
                '            Else
                '                wkBRK = False
                '            End If

                '2019.04.18 chg start
                'Call DB_GetNext(DBN_UDNTRA, BtrNormal)
                'change start 20190809 kuwahara
                'UDNTRA_GetFirstRecWhere(strSqlUdntra)
                GetRowsCommon("UDNTRA", strSqlUdntra)
                'change end 20190809 kuwahara
                'change start 20190809 kuwahara
                'DB_UDNTRA = UDNTRA_GetNext(countUdntra)
                DB_UDNTRA = GetNextRowsCommon("UDNTRA", countUdntra)
                'change end 20190809 kuwahara
                countUdntra += 1
                '2019.04.18 chg end
            Loop
            'CHG START FKS)INABA 2010/05/27 ******************************
            '連絡票№789
            '        '発行区分
            If WG_PRTKB = "0" Then
                If SSS_DonePrintFlg = 1 Then 'ADD 2007/02/19 IMAI 印刷済み伝票のみアップデート対象
                    ls_NewFLG = "1"
                    ReDim Preserve wk_MFILKEYNO(lw_CNT)
                    wk_MFILKEYNO(lw_CNT) = DB_UDNTHA.DATNO
                    lw_CNT = lw_CNT + 1
                    '                DB_UDNTHA.UDNPRAKB = "1"
                    '                Call DB_Update(DBN_UDNTHA, SSS_MFILKEYNO)
                End If
            End If
            'CHG  END  FKS)INABA 2010/05/27 ******************************
            '20081223 ADD START RISE)Tanimura '連絡票No.643
NEXT_PAGE:
            '20081223 ADD END   RISE)Tanimura
            '
            MCHK = SEL_RECORD()
            '2019.04.22 add start
            If SSS_LSTOP Then
                Exit Sub
            End If
            '2019.04.22 add end
        Loop

        SSS_DonePrintFlg = 0 'ADD 2007/02/19 IMAI 印刷フラグ初期化

        ''''2007.02.02 ADD START
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HAKKOU(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If RD_SSSMAIN_HAKKOU(-1) = "1" Then
            If wkTOKDNKB = "2" Then
                wkSITEI = "1"
            Else
                wkSITEI = "0"
            End If
        Else
            wkSITEI = "0"
        End If
        ''''2007.02.02 ADD END
        If WK_CNT1 <> 0 Then
            'プリントパターン・再発行・発行失敗の編集
            If WK_CNT2 = WK_CNT3 Then
                DB_URIPR52.PRTPATN = "1"
            Else
                DB_URIPR52.PRTPATN = "2"
            End If
            If wkSITEI = "1" Then
                DB_URIPR52.PRTPATN = "3"
                DB_URIPR52.PRTLINNO(0) = "01" '2007.03.12
            End If
            If WG_PRTKB = "1" Then
                DB_URIPR52.PRTKBNM = "再発行"
            Else
                DB_URIPR52.PRTKBNM = "　　　"
            End If
            If WG_PRTKB = "9" Then
                DB_URIPR52.SIPPAI = "*"
            Else
                DB_URIPR52.SIPPAI = " "
            End If
            'フッタ部セット
            DB_URIPR52.DENCM = WK_DENCM
            DB_URIPR52.SBAURIKN = WK_SUMURIKN
            DB_URIPR52.SBAUZEKN = WK_SUMUZEKN
            DB_URIPR52.SBAUZKKN = WK_SUMURIKN + WK_SUMUZEKN
            If CHK_LCTL() Then
                '2019.04.17 chg start
                'Call DB_Insert(DBN_URIPR52, 1)
                InsertURIPR52(DB_URIPR52)
                '2019.04.17 chg end
                SSS_LFILCNT = SSS_LFILCNT + 1
            End If
            ''''2007.02.07 ADD START
            'ＭＡＸページ数更新
            strSQL = ""
            '2019.04.18 chg start
            'strSQL = strSQL & "UPDATE URIPR52 SET URIPR52.MAXPAGE = '" & WK_MAXPAGE & "'"
            strSQL = strSQL & "UPDATE CNT_USR9.URIPR52 SET URIPR52.MAXPAGE = '" & WK_MAXPAGE & "'"
            '2019.04.18 chg end
            strSQL = strSQL & " WHERE DENDT = '" & WK_UDNDT & "'"
            strSQL = strSQL & "   AND FDNNO = '" & WK_FDNNO & "'"
            strSQL = strSQL & "   AND RPTCLTID = '" & SSS_CLTID.Value & "'"
            '2019.04.18 chg start
            'Call DB_Execute(DBN_URIPR52, strSQL)
            DB_Execute(strSQL)
            '2019.04.18 chg end
            ''''2007.02.07 ADD END
        End If
        'ADD START FKS)INABA 2010/05/27 ******************************
        '連絡票№789
        '発行区分

        If ls_NewFLG = "1" Then 'ADD 2007/02/19 IMAI 印刷済み伝票のみアップデート対象
            wk_DATNO_E = ""
            If UBound(wk_MFILKEYNO) > 999 Then
                MsgBox("出力件数が多すぎます。出力条件を指定して再度処理を行ってください。")
                SSS_LSTOP = True
                Exit Sub
            End If
            For lw_CNT1 = 0 To UBound(wk_MFILKEYNO)
                wk_DATNO_E = wk_DATNO_E & "'" & Trim(wk_MFILKEYNO(lw_CNT1)) & "',"
            Next lw_CNT1
            wk_DATNO_E = Left(wk_DATNO_E, Len(wk_DATNO_E) - 1)

            strSQL = ""
            '2019.04.22 chg start
            'select句のコメントを解除 20190809 kuwahara
            strSQL = strSQL & "SELECT DATNO FROM UDNTHA "
            'strSQL = strSQL & " WHERE DATNO IN (" & wk_DATNO_E & ")"
            'strSQL = strSQL & "   AND UDNPRAKB = '1'"
            'strSQL = strSQL & "   FOR UPDATE "
            'Call DB_GetSQL2(DBN_UDNTHA, strSQL)
            strSQL = strSQL & " WHERE DATNO IN (" & wk_DATNO_E & ")"
            strSQL = strSQL & "   AND UDNPRAKB = '1'"
            strSQL = strSQL & "   FOR UPDATE "
            'change start 20190809 kuwahara
            'UDNTHA_GetFirstRecWhere(strSQL, " DATNO ")
            DB_GetTable(strSQL) 'GetRowsCommonでは対応ができないため、DB_GetTableで対応。そのため、select句のコメントを解除
            'change end 20190809 kuwahara
            '2019.04.22 chg end
            If DBSTAT <> 0 Then
                '取得データ無の場合は売上見出トランの納品書発行区分に発行済み(1)を立てる
                strSQL = ""
                strSQL = strSQL & "UPDATE UDNTHA"
                strSQL = strSQL & "   SET UDNPRAKB = '1' "
                strSQL = strSQL & " WHERE DATNO IN (" & wk_DATNO_E & ")"
                '2019.04.22 chg start
                'Call DB_Execute(DBN_UDNTHA, strSQL)
                Call DB_Execute(strSQL)
                '2019.04.22 chg end
            Else
                MsgBox("他の端末で既に出力されている明細が有ります。再度処理を行ってください。")
                SSS_LSTOP = True
            End If
        End If
        'ADD  END  FKS)INABA 2010/05/27 ******************************

        '2019.04.18 add start
        result = 0
        '2019.04.18 add end
    End Sub

    Function NEXTCHK() As Short
		
		Dim wkDATNO As String
		Dim strSQL As String
		
		' 読み飛ばし条件チェック
		NEXTCHK = False
		'''    If DB_UDNTHA.EMGODNKB <> WG_KINKYU Then
		'''        NEXTCHK = True
		'''        Exit Function
		'''    End If
		If Trim(WG_TANCD) <> "" And DB_UDNTHA.TANCD <> WG_TANCD Then
			NEXTCHK = True
			Exit Function
		End If
		If Trim(WG_BMNCD) <> "" And DB_UDNTHA.BUMCD <> WG_BMNCD Then
			NEXTCHK = True
			Exit Function
		End If
		''''If Trim(WG_JDNNO) <> "" And RTrim(DB_UDNTHA.JDNNO) <> WG_JDNNO Then
		''''    NEXTCHK = True
		''''    Exit Function
		''''End If
		If Trim(WG_TOKCD) <> "" And RTrim(DB_UDNTHA.TOKCD) <> WG_TOKCD Then
			NEXTCHK = True
			Exit Function
		End If
		If Trim(WG_JDNTRKB) <> "" And DB_UDNTHA.JDNTRKB <> WG_JDNTRKB Then
			NEXTCHK = True
			Exit Function
		End If
		Select Case WG_PRTKB
			Case "0"
				If DB_UDNTHA.UDNPRAKB <> "9" Then
					NEXTCHK = True
					Exit Function
				End If
				If DB_UDNTHA.UDNDT > WG_DENDT Then
					NEXTCHK = True
					Exit Function
				End If
			Case "1"
				If DB_UDNTHA.UDNPRAKB = "9" Then
					NEXTCHK = True
					Exit Function
				End If
				If DB_UDNTHA.UDNDT <> WG_DENDT Then
					NEXTCHK = True
					Exit Function
				End If
			Case "9"
				If DB_UDNTHA.UDNPRAKB = "9" Then
					NEXTCHK = True
					Exit Function
				End If
				If DB_UDNTHA.UDNDT <> WG_DENDT Then
					NEXTCHK = True
					Exit Function
				End If
			Case Else
				NEXTCHK = True
				Exit Function
		End Select

        '直送のみ出力
        ''''If DB_UDNTHA.ZKTKB <> "2" Then
        ''''    NEXTCHK = True
        ''''    Exit Function
        ''''End If
        strSQL = ""
        '2019.04.18 chg start
        'strSQL = strSQL & "SELECT * FROM UDNTRA"
        'strSQL = strSQL & "        WHERE DATNO = '" & DB_UDNTHA.DATNO & "'"
        'Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        strSQL = strSQL & "        WHERE DATNO = '" & DB_UDNTHA.DATNO & "'"
        'change start 20190809 kuwahara
        'UDNTRA_GetFirstRecWhere(strSQL)
        GetRowsCommon("UDNTRA", strSQL)
        'change end 20190809 kuwahara
        '2019.04.18 chg end
        If DBSTAT = 0 Then
			If (Trim(DB_UDNTRA.ODNNO) <> "" And DB_UDNTHA.ZKTKB <> "2") Then
				NEXTCHK = True
				Exit Function
			End If
		Else
			NEXTCHK = True
			Exit Function
		End If


        '得意先マスタ取得
        '2019.04.18 chg start
        'Call DB_GetEq(DBN_TOKMTA, 1, DB_UDNTHA.TOKCD, BtrNormal)
        'change start 20190809 kuwahara
        'TOKMTA_GetFirst(DB_UDNTHA.TOKCD)
        GetRowsCommon("TOKMTA", "where TOKCD = '" & DB_UDNTHA.TOKCD & "'")
        'change end 20190809 kuwahara
        '2019.04.18 chg end
        '客先指定伝票区分　０：通常のみ出力
        ''''If DB_TOKMTA.TOKDNKB = "1" Then
        ''''    NEXTCHK = True
        ''''    Exit Function
        ''''End If

        strSQL = ""
        '2019.04.18 chg start
        '20190808 select句の一部コメント解除
        strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
        'strSQL = strSQL & "        WHERE JDNNO = '" & DB_UDNTHA.JDNNO & "'"
        'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
        'wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
        Dim tableFiled As String = " MAX(DATNO) AS DATNO "
        strSQL = strSQL & "        WHERE JDNNO = '" & DB_UDNTHA.JDNNO & "'"
        'change start 20190808 kuwahara
        'Call JDNTRA_GetFirstRecWhere(strSQL, tableFiled)
        DB_GetTable(strSQL) 'GetRowsCommonのメソッドでは引数が足らないので、DB_GetTableで代用（そのため、Select句のコメントを解除）
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190808 kuwahara
        'add start 20190819 kuwahara
        wkDATNO = VB6.Format(IIf(IsNothing(dt.Rows(0)("MAX(DATNO)")) Or Trim(dt.Rows(0)("MAX(DATNO)")) = "", 0, dt.Rows(0)("MAX(DATNO)")), "0000000000")
        'add end 20190819 kuwahara
        'delete start 20190819 kuwahara
        'wkDATNO = VB6.Format(IIf(IsNothing(DB_JDNTRA.DATNO) Or Trim(DB_JDNTRA.DATNO) = "", 0, DB_JDNTRA.DATNO), "0000000000")
        'delete end 20190819 kuwahara
        DB_JDNTRA = Nothing
        '2019.04.18 chg end
        'ADD START FKS)INABA 2008/04/15 *******************************************
        If wkDATNO = "0000000000" Then
			NEXTCHK = True
			Exit Function
		End If
        'ADD  END  FKS)INABA 2008/04/15 *******************************************
        strSQL = ""
        '2019.04.18 chg start
        'strSQL = strSQL & "SELECT * FROM JDNTRA"
        'strSQL = strSQL & "        WHERE DATNO = '" & wkDATNO & "'"
        'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
        strSQL = strSQL & "        WHERE DATNO = '" & wkDATNO & "'"
        'change start 20190808 kuwahara
        'Call JDNTRA_GetFirstRecWhere(strSQL)
        GetRowsCommon("JDNTRA", strSQL)
        'change end 20190808 kuwahara
        '2019.04.18 chg end
        '客先指定伝票区分　０：通常のみ出力
        If DB_JDNTRA.TOKDNKB = "1" Then
			NEXTCHK = True
			Exit Function
		End If
		
	End Function
	
	Function NPSNCHK() As Short
		' 一つ目のキー繰り上げチェック
		Dim rtns As String
		'
		'''    If DB_UDNTHA.UDNNO > WG_ENDUDNNO Then
		'''        rtns = SSS_UPLCHAR(DB_UDNTHA.UDNDT)
		'''        DB_PARA(SSS_MFIL).KeyBuf = "1" & rtns & WG_STTUDNNO & WG_STTTOKCD
		'''        NPSNCHK = True
		'''    Else
		NPSNCHK = False
		'''    End If
	End Function
	
	Function RPSNCHK() As Short
		' 二つめのキーによる再ポジショニング
		'''    If DB_UDNTHA.UDNNO < WG_STTUDNNO Then
		'''        DB_PARA(SSS_MFIL).KeyBuf = "1" & DB_UDNTHA.UDNDT & WG_STTUDNNO & WG_STTTOKCD
		'''        RPSNCHK = True
		'''    Else
		RPSNCHK = False
		'''    End If
	End Function
	
	Function SEL_RECORD() As String
		Dim WL_SELFLG As String
		Dim WK_EMGODNKB As String
        Dim strSQL As String

        '
        '2019.04.22 add start
        Application.DoEvents()
        '2019.04.22 add end

        If SSS_LSTOP Then
			SEL_RECORD = "END"
			Exit Function
		End If
        '
        If WG_KINKYU = "1" Then
            WK_EMGODNKB = "9"
        Else
            WK_EMGODNKB = "1"
        End If

        If SSS_MFILCNT = 0 Then
            If WG_PRTKB = "0" Then
                '''            Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WG_KINKYU & "9" & WG_DENDT & WG_JDNNO, BtrNormal)
                '''            Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WK_EMGODNKB & "9" & WG_DENDT & WG_JDNNO, BtrNormal)
                ''''2007.02.07 UPD START
                '''            Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WK_EMGODNKB & "9" & "00000000" & WG_JDNNO, BtrNormal)
                ''''2007.02.27 UPD START
                ''''        Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WK_EMGODNKB & "9" & "00000000" & "          ", BtrNormal)
                ''''2007.02.07 UPD END

                ''''2007.03.12 UPD-START
                ''''        strSQL = ""
                ''''        strSQL = strSQL & "SELECT * FROM UDNTHA"
                ''''        strSQL = strSQL & " WHERE UDNTHA.FDNNO IN"
                ''''        strSQL = strSQL & "     ( SELECT FDNNO FROM UDNTHA"
                ''''        Select Case Trim(WG_JDNNO)
                ''''                Case ""
                ''''                    strSQL = strSQL & "                                                )"
                ''''                Case Else
                ''''                    strSQL = strSQL & "        WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' )"
                ''''        End Select
                ''''        strSQL = strSQL & "   AND DATKB = '1'"
                ''''        strSQL = strSQL & "   AND EMGODNKB = '" & WK_EMGODNKB & "'"
                ''''        strSQL = strSQL & "   AND UDNPRAKB = '9'"
                ''''        strSQL = strSQL & " ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO"
                strSQL = ""
                '2019.04.15 chg start 仮
                'strSQL = strSQL & "SELECT * FROM UDNTHA WHERE DATNO IN"
                strSQL = strSQL & " WHERE DATNO IN"
                '2019.04.15 chg end
                strSQL = strSQL & " ( SELECT MAX(DATNO) FROM"
                '***chg-S-tom***
                '            strSQL = strSQL & "   ( SELECT * FROM UDNTHA"
                '            strSQL = strSQL & "      WHERE UDNTHA.FDNNO IN"
                strSQL = strSQL & "   ( SELECT U.* FROM UDNTHA U,FIXMTA F"
                strSQL = strSQL & "      WHERE U.FDNNO IN"
                '***chg-S-tom***
                strSQL = strSQL & "       ( SELECT FDNNO FROM UDNTHA"
                Select Case Trim(WG_JDNNO)
                    '''' UPD 2010/01/26  FKS) T.Yamamoto    Start    連絡票№778
                    '納品書№なしは対象としない
                    '                    Case ""
                    '                        strSQL = strSQL & "                                                 )"
                    '                    Case Else
                    '                        strSQL = strSQL & "         WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' )"
                    Case ""
                        strSQL = strSQL & "         WHERE UDNTHA.FDNNO <> ' ' )"
                    Case Else
                        strSQL = strSQL & "         WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' "
                        strSQL = strSQL & "           AND UDNTHA.FDNNO <> ' ' )"
                        '''' UPD 2010/01/26  FKS) T.Yamamoto    End
                End Select
                '***chg-S-tom***
                '            strSQL = strSQL & "       AND DATKB = '1'"
                '            strSQL = strSQL & "       AND EMGODNKB = '" & WK_EMGODNKB & "'"
                '            strSQL = strSQL & "       AND UDNPRAKB = '9'"
                '            strSQL = strSQL & "     ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO ) "
                strSQL = strSQL & "       AND U.DATKB = '1'"
                strSQL = strSQL & "       AND U.EMGODNKB = '" & WK_EMGODNKB & "'"
                strSQL = strSQL & "       AND U.UDNPRAKB = '9'"

                strSQL = strSQL & "       AND F.DATKB = '1'"
                strSQL = strSQL & "       AND F.CTLCD = '201       '"
                strSQL = strSQL & "       AND SUBSTR(F.FIXVAL,1,10) <> SUBSTR(U.TOKCD,1,10)"

                '''' ADD 2013/11/13  FWEST) T.Yamamoto    Start    連絡票№HAN20131031-01
                strSQL = strSQL & "       AND NOT EXISTS (SELECT * FROM MEIMTA M"
                strSQL = strSQL & "                        WHERE M.DATKB = '1'"
                strSQL = strSQL & "                          AND M.KEYCD = '113'"
                strSQL = strSQL & "                          AND SUBSTR(M.MEINMB,1,10) = SUBSTR(U.TOKCD,1,10) )"
                '''' ADD 2013/11/13  FWEST) T.Yamamoto    End

                strSQL = strSQL & "     ORDER BY U.DATKB,U.EMGODNKB,U.UDNPRAKB,U.UDNDT,U.FDNNO ) "
                '***chg-E-tom***
                strSQL = strSQL & " WHERE (udnno, wrtfstdt || wrtfsttm) IN"
                strSQL = strSQL & "   ( SELECT UDNTHA.udnno, MAX(UDNTHA.wrtfstdt || UDNTHA.wrtfsttm) FROM UDNTHA,udntra"
                strSQL = strSQL & "      WHERE udntha.datno = UDNTRA.DATNO "
                strSQL = strSQL & "        AND UDNTRA.LINNO = '001'"
                strSQL = strSQL & "        AND UDNTHA.denkb = '1'"
                strSQL = strSQL & "        AND (( UDNTRA.dkbid = '01' AND UDNTRA.akakrokb = '1') "
                strSQL = strSQL & "          or (UDNTRA.dkbid <> '01' AND UDNTRA.akakrokb = '9'))"
                strSQL = strSQL & "      GROUP BY UDNTHA.udnno"
                strSQL = strSQL & "                       )"
                strSQL = strSQL & "  GROUP BY UDNNO )"
                strSQL = strSQL & "  AND datkb = 1"
                strSQL = strSQL & " ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO "

                ''''2007.03.12 UPD-END
                '2019.04.15 chg start 仮
                'Call DB_GetSQL2(DBN_UDNTHA, strSQL)
                wCount = 0
                wUdnthaSql = strSQL
                'change start 20190809 kuwahara
                'UDNTHA_GetFirstRecWhere(strSQL)
                GetRowsCommon("UDNTHA", strSQL)
                'change end 20190809 kuwhara
                wCount = wCount + 1
                '2019.04.15 chg end
                ''''2007.02.27 UPD END

            Else
                '''            Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WG_KINKYU & "1" & WG_DENDT & WG_JDNNO, BtrNormal)
                ''''2007.02.07 UPD START
                '''            Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WK_EMGODNKB & "1" & WG_DENDT & WG_JDNNO, BtrNormal)
                ''''2007.02.27 UPD START
                ''''        Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, "1" & WK_EMGODNKB & "1" & WG_DENDT & "          ", BtrNormal)
                ''''2007.02.07 UPD END

                ''''2007.03.12 UPD-START
                ''''        strSQL = ""
                ''''        strSQL = strSQL & "SELECT * FROM UDNTHA"
                ''''        strSQL = strSQL & " WHERE UDNTHA.FDNNO IN"
                ''''        strSQL = strSQL & "     ( SELECT FDNNO FROM UDNTHA"
                ''''        Select Case Trim(WG_JDNNO)
                ''''                Case ""
                ''''                    strSQL = strSQL & "                                                )"
                ''''                Case Else
                ''''                    strSQL = strSQL & "        WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' )"
                ''''        End Select
                ''''        strSQL = strSQL & "   AND DATKB = '1'"
                ''''        strSQL = strSQL & "   AND EMGODNKB = '" & WK_EMGODNKB & "'"
                ''''        strSQL = strSQL & "   AND UDNPRAKB = '1'"
                ''''        strSQL = strSQL & "   AND UDNDT = '" & WG_DENDT & "'"
                ''''        strSQL = strSQL & " ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO"

                strSQL = ""
                '2019.04.16 chg start 仮
                'strSQL = strSQL & "SELECT * FROM UDNTHA WHERE DATNO IN"
                strSQL = strSQL & " WHERE DATNO IN"
                '2019.04.16 chg end
                strSQL = strSQL & " ( SELECT MAX(DATNO) FROM"
                '***chg-S-tom***
                '            strSQL = strSQL & "   ( SELECT * FROM UDNTHA"
                '            strSQL = strSQL & "      WHERE UDNTHA.FDNNO IN"
                strSQL = strSQL & "   ( SELECT U.* FROM UDNTHA U,FIXMTA F"
                strSQL = strSQL & "      WHERE U.FDNNO IN"
                '***chg-S-tom***
                strSQL = strSQL & "      ( SELECT FDNNO FROM UDNTHA"
                Select Case Trim(WG_JDNNO)
                    '''' UPD 2010/01/26  FKS) T.Yamamoto    Start    連絡票№778
                    '納品書№なしは対象としない
                    '                    Case ""
                    '                        strSQL = strSQL & "                                                )"
                    '                    Case Else
                    '                        strSQL = strSQL & "        WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' )"
                    Case ""
                        strSQL = strSQL & "         WHERE UDNTHA.FDNNO <> ' ' )"
                    Case Else
                        strSQL = strSQL & "         WHERE UDNTHA.JDNNO = '" & WG_JDNNO & "' "
                        strSQL = strSQL & "           AND UDNTHA.FDNNO <> ' ' )"
                        '''' UPD 2010/01/26  FKS) T.Yamamoto    End
                End Select
                '***chg-S-tom***
                '            strSQL = strSQL & "       AND DATKB = '1'"
                '            strSQL = strSQL & "       AND EMGODNKB = '" & WK_EMGODNKB & "'"
                '            strSQL = strSQL & "       AND UDNPRAKB = '1'"
                '            strSQL = strSQL & "       AND UDNDT = '" & WG_DENDT & "'"
                '            strSQL = strSQL & "     ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO ) "
                strSQL = strSQL & "       AND U.DATKB = '1'"
                strSQL = strSQL & "       AND U.EMGODNKB = '" & WK_EMGODNKB & "'"
                strSQL = strSQL & "       AND U.UDNPRAKB = '1'"
                strSQL = strSQL & "       AND U.UDNDT = '" & WG_DENDT & "'"

                strSQL = strSQL & "       AND F.DATKB = '1'"
                strSQL = strSQL & "       AND F.CTLCD = '201       '"
                strSQL = strSQL & "       AND SUBSTR(F.FIXVAL,1,10) <> SUBSTR(U.TOKCD,1,10)"
                '''' ADD 2013/11/13  FWEST) T.Yamamoto    Start    連絡票№HAN20131031-01
                strSQL = strSQL & "       AND NOT EXISTS (SELECT * FROM MEIMTA M"
                strSQL = strSQL & "                        WHERE M.DATKB = '1'"
                strSQL = strSQL & "                          AND M.KEYCD = '113'"
                strSQL = strSQL & "                          AND SUBSTR(M.MEINMB,1,10) = SUBSTR(U.TOKCD,1,10) )"
                '''' ADD 2013/11/13  FWEST) T.Yamamoto    End

                strSQL = strSQL & "     ORDER BY U.DATKB,U.EMGODNKB,U.UDNPRAKB,U.UDNDT,U.FDNNO ) "
                '***chg-E-tom***
                strSQL = strSQL & " WHERE (udnno, wrtfstdt || wrtfsttm) IN"
                strSQL = strSQL & "   ( SELECT UDNTHA.udnno, MAX(UDNTHA.wrtfstdt || UDNTHA.wrtfsttm) FROM UDNTHA,udntra"
                strSQL = strSQL & "      WHERE udntha.datno = UDNTRA.DATNO "
                strSQL = strSQL & "        AND UDNTRA.LINNO = '001'"
                strSQL = strSQL & "        AND UDNTHA.denkb = '1'"
                strSQL = strSQL & "        AND (( UDNTRA.dkbid = '01' AND UDNTRA.akakrokb = '1') "
                strSQL = strSQL & "          or (UDNTRA.dkbid <> '01' AND UDNTRA.akakrokb = '9')) "
                strSQL = strSQL & "      GROUP BY UDNTHA.udnno"
                strSQL = strSQL & "                       )"
                strSQL = strSQL & "  GROUP BY UDNNO )"
                strSQL = strSQL & "  AND datkb = 1"
                strSQL = strSQL & " ORDER BY DATKB,EMGODNKB,UDNPRAKB,UDNDT,FDNNO "

                ''''2007.03.12 UPD-END
                '2019.04.15 chg start 仮
                'Call DB_GetSQL2(DBN_UDNTHA, strSQL)
                wCount = 0
                wUdnthaSql = strSQL
                'change start 20190809 kuwahara
                'UDNTHA_GetFirstRecWhere(strSQL)
                GetRowsCommon("UDNTHA", strSQL)
                'change end 20190809 kuwahara
                wCount = wCount + 1
                '2019.04.15 chg end

            End If
        Else
            '2019.04.15 chg start 仮
            'Call DB_GetNext(SSS_MFIL, BtrNormal)
            'change start 20190809 kuwahara
            'UDNTHA_GetFirstRecWhere(wUdnthaSql)
            GetRowsCommon("UDNTHA", wUdnthaSql)
            'change end 20190809 kuwahara
            'change start 20190809 kuwahara
            'DB_UDNTHA = UDNTHA_GetNext(wCount)
            DB_UDNTHA = GetNextRowsCommon("UDNTHA", wCount)
            'change end 20190809 kuwahara
            If DB_UDNTHA.DATNO Is Nothing Then
                DBSTAT = 1
            Else
                DBSTAT = 0
            End If
            wCount = wCount + 1
            '2019.04.15 chg end
        End If
        Select Case DBSTAT
            Case 0
            Case Else ' 該当レコードなし/EOF
                WL_SELFLG = "END"
        End Select
        Do Until WL_SELFLG = "SEL" Or WL_SELFLG = "END"
            If ENDCHK() Then
                WL_SELFLG = "END"
            Else
                If RPSNCHK() Then
                    Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, DB_PARA(SSS_MFIL).KeyBuf, BtrNormal)
                Else
                    If NPSNCHK() Then
                        Call DB_GetGrEq(SSS_MFIL, SSS_MFILKEYNO, DB_PARA(SSS_MFIL).KeyBuf, BtrNormal)
                    Else
                        If NEXTCHK() Then
                            '2019.04.15 chg start 仮
                            'Call DB_GetNext(SSS_MFIL, BtrNormal)
                            'change start 20190809 kuwahara
                            'UDNTHA_GetFirstRecWhere(wUdnthaSql)
                            GetRowsCommon("UDNTHA", wUdnthaSql)
                            'change end 20190809 kuwahara
                            'change start 20190809 kuwahara
                            'DB_UDNTHA = UDNTHA_GetNext(wCount)
                            DB_UDNTHA = GetNextRowsCommon("UDNTHA", wCount)
                            'change end 20190809 kuwahara
                            If DB_UDNTHA.DATNO Is Nothing Then
                                DBSTAT = 1
                            Else
                                DBSTAT = 0
                            End If
                            wCount = wCount + 1
                            '2019.04.15 chg end
                        Else
                            WL_SELFLG = "SEL"
                        End If
                    End If
                End If
                '
                Select Case DBSTAT
                    Case 0
                    Case Else
                        WL_SELFLG = "END"
                End Select
            End If
            SSS_MFILCNT = SSS_MFILCNT + 1
        Loop
        SEL_RECORD = WL_SELFLG
    End Function
    '***add-S-tom***
    Function Get_HenBmn(ByVal BUMCD As String, ByVal UDNDT As String, ByVal JDNNO As String) As String
		Dim strSQL As String
		Dim NEW_BMNCD As String
		Dim OLD_BMNCD As String
		
		NEW_BMNCD = ""
        OLD_BMNCD = ""
        'delete start 20190808 kuwahara
        'Call MEIMTC_RClear()
        'delete end 20190808 kuwahara
        strSQL = ""
        '2019.04.19 chg start
        'strSQL = strSQL & "SELECT * FROM MEIMTC"
        'strSQL = strSQL & " WHERE KEYCD = '086'"
        'strSQL = strSQL & "   AND DATKB = '1'"
        'strSQL = strSQL & "   AND MEICDA = '" & Trim(BUMCD) & "'"
        'strSQL = strSQL & "   AND STTTKDT <= '" & UDNDT & "'"
        'strSQL = strSQL & "   AND ENDTKDT >= '" & UDNDT & "'"
        'Call DB_GetSQL2(DBN_MEIMTC, strSQL)
        strSQL = strSQL & " WHERE KEYCD = '086'"
        strSQL = strSQL & "   AND DATKB = '1'"
        strSQL = strSQL & "   AND MEICDA = '" & Trim(BUMCD) & "'"
        strSQL = strSQL & "   AND STTTKDT <= '" & UDNDT & "'"
        strSQL = strSQL & "   AND ENDTKDT >= '" & UDNDT & "'"
        'change start 20190808 kuwahara
        'MEIMTC_GetFirstRecWhere(strSQL)
        GetRowsCommon("MEIMTC", strSQL)
        'change end 20190808 kuwahara
        '2019.04.19 chg end
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDbNull(DB_MEIMTC.MEINMA) Or Trim(DB_MEIMTC.MEINMA) = "" Then
			Get_HenBmn = BUMCD
        Else
            '2019.04.08 DEL START
            'Call JDNTHA_RClear()
            '2019.04.08 DEL END
            strSQL = ""
            '2019.04.19 chg start
            'strSQL = strSQL & "SELECT * FROM JDNTHA"
            'strSQL = strSQL & " WHERE DATNO IN"
            'strSQL = strSQL & "   (SELECT MAX(DATNO)"
            'strSQL = strSQL & "    FROM JDNTHA"
            'strSQL = strSQL & "    WHERE JDNNO = '" & JDNNO & "'"
            'strSQL = strSQL & "      AND BUMCD = '" & BUMCD & "')"
            'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
            strSQL = strSQL & " WHERE DATNO IN"
            strSQL = strSQL & "   (SELECT MAX(DATNO)"
            strSQL = strSQL & "    FROM JDNTHA"
            strSQL = strSQL & "    WHERE JDNNO = '" & JDNNO & "'"
            strSQL = strSQL & "      AND BUMCD = '" & BUMCD & "')"
            'change start 20190808 kuwahara
            'JDNTHA_GetFirstRecWhere(strSQL)
            GetRowsCommon("JDNTHA", strSQL)
            'change end 20190808 kuwahara
            '2019.04.19 chg end
            NEW_BMNCD = DB_JDNTHA.BUMCD
            '2019.04.08 DEL START
            'Call JDNTHA_RClear()
            '2019.04.08 DEL END
            strSQL = ""
            '2019.04.19 chg start
            'strSQL = strSQL & "SELECT * FROM JDNTHA"
            'strSQL = strSQL & " WHERE DATNO IN"
            'strSQL = strSQL & "   (SELECT MAX(DATNO)"
            'strSQL = strSQL & "    FROM JDNTHA"
            'strSQL = strSQL & "    WHERE JDNNO = '" & JDNNO & "'"
            'strSQL = strSQL & "      AND JDNDT < '" & DB_MEIMTC.STTTKDT & "')"
            'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
            strSQL = strSQL & " WHERE DATNO IN"
            strSQL = strSQL & "   (SELECT MAX(DATNO)"
            strSQL = strSQL & "    FROM JDNTHA"
            strSQL = strSQL & "    WHERE JDNNO = '" & JDNNO & "'"
            strSQL = strSQL & "      AND JDNDT < '" & DB_MEIMTC.STTTKDT & "')"
            'change start 20190808 kuwahara
            'JDNTHA_GetFirstRecWhere(strSQL)
            GetRowsCommon("JDNTHA", strSQL)
            'change end 20190808 kuwahara
            '2019.04.19 chg end
            OLD_BMNCD = DB_JDNTHA.BUMCD
            '2019.04.08 DEL START
            'Call JDNTHA_RClear()
            '2019.04.08 DEL END
            If NEW_BMNCD = OLD_BMNCD Then
                Get_HenBmn = Trim(DB_MEIMTC.MEINMA)
            Else
                Get_HenBmn = BUMCD
            End If
		End If
		
	End Function
    '***add-E-tom***

    Sub Set_Value()
        '=
        'add start 20190819 kuwahara
        DBN_UDNTHA = 8  'init_fil() をコメントアウトしたため、DBN_UDNTHAに数値が入らなくなったため
        'add end 20190819 kuwahara
        SSS_MFIL = DBN_UDNTHA
        SSS_MFILNM = DB_PARA(SSS_MFIL).tblid
        ''''2007.02.07 UPD START
        ''''    SSS_MFILKEYNO = 8
        SSS_MFILKEYNO = 11
        ''''2007.02.07 UPD END
    End Sub
End Module