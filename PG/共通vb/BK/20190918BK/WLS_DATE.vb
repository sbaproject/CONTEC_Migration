Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_DATE
	Inherits System.Windows.Forms.Form
	Dim DAYIDX As Short
	'   システムの日付
	Dim Sys_date As New VB6.FixedLengthString(10)
	Dim Sys_year As New VB6.FixedLengthString(4)
	Dim Sys_month As New VB6.FixedLengthString(2)
	Dim Sys_day As New VB6.FixedLengthString(2)
	'   カレンダー表示の年月
	Dim Cur_year As New VB6.FixedLengthString(4)
	Dim Cur_month As New VB6.FixedLengthString(2)
	'   祝日のバッファー
	' H_KB 祝日区分  0:祝日でない（取りやめ／施行前）, 1:振り替え休日のある祝日,
	'               2:振り替えのない休日, 3:春分/秋分, 4:第ｎ○曜
	'               第ｎ○曜の日付の意味  一桁目:第ｎ 二桁目:2～6 を 月～金 とする
	'                 例)第二月曜 = 22, 第四金曜 = 46
	' H_SttYY 施行年
	' H_OldDD 施行年以前の設定日
	' H_OldKB 施行年以前の祝日区分
	' 施行年の設定例 07/20(1)1996:00(0) = 1996年から7月20日が通常の祝日として新設された
	'               01/22(4)2000:15(1) = 2000年から第2月曜に変更された(以前は15日だった)
	Private Structure HOLIDAY_TYPE
		Dim H_MM As Short
		Dim H_DD As Short
		Dim H_KB As Short
		Dim H_SttYY As Short
		Dim H_OldDD As Short
		Dim H_OldKB As Short
	End Structure
	
	'各カレンダ区分識別色
	Private Const KBNDAY_BACKCOLOR As Integer = &HFFFFFF
	'通常日背景色
	Private Const NORMALDAY_BACKCOLOR As Integer = &HC0C0C0
	'選択日背景色
	Private Const SELECTDAY_BACKCOLOR As Integer = &HFFFF00
	
	'休日前景色
	Private Const HOLIDAY_FORECOlOR As Integer = &HFF
	'土曜前景色
	Private Const SATDAY_FORECOlOR As Integer = &HFF0000
	'通常日前景色
	Private Const NORMALDAY_FORECOlOR As Integer = &H80000008
	
	
	Dim WLS_HoliDay() As HOLIDAY_TYPE
	
	'カレンダマスタ情報
	Private WLS_Cldmt() As TYPE_DB_CLDMTA
	
	Dim HdayCnt As Short
	Dim D_MAX As Short
	Dim W_DAY As Short
	Dim W_DAYIDX As Short
	
	Private DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Get_Cldmta
	'   概要：  カレンダ情報取得
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_Get_Cldmta(ByRef yy As Short, ByRef mm As Short)
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        '20190322 DEL START
        'Dim Usr_Ody_LC As U_Ody
        '20190322 DEL END

		Dim Cnt As Short
		
		strSQL = ""
		strSQL = strSQL & " Select CLDDT " '日付
		strSQL = strSQL & "      , CLDWKKB " '曜日
		strSQL = strSQL & "      , CLDHLKB " '祝日
		strSQL = strSQL & "      , SLDKB " '営業日区分
		strSQL = strSQL & "      , BNKKDKB " '銀行稼動区分
		strSQL = strSQL & "      , DTBKDKB " '物流稼動区分
		strSQL = strSQL & "      , ETCKBA " 'その他区分１
		strSQL = strSQL & "      , ETCKBB " 'その他区分２
		strSQL = strSQL & "      , ETCKBC " 'その他区分３
		strSQL = strSQL & "      , ETCKBD " 'その他区分４
		strSQL = strSQL & "      , ETCKBE " 'その他区分５
		strSQL = strSQL & "      , ETCKBF " 'その他区分６
		strSQL = strSQL & "      , ETCKBG " 'その他区分７
		strSQL = strSQL & "      , ETCKBH " 'その他区分８
		strSQL = strSQL & "      , ETCKBI " 'その他区分９
		strSQL = strSQL & "      , ETCKBJ " 'その他区分１０
		strSQL = strSQL & "   from CLDMTA "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "   and  CLDDT >= " & VB6.Format(yy, "0000") & VB6.Format(mm, "00") & "01"
		strSQL = strSQL & "   and  CLDDT <= " & VB6.Format(yy, "0000") & VB6.Format(mm, "00") & "99"
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "        CLDDT " '日付
		
        'DBアクセス
        '2019/03/20 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/20 CHG E N D
		
		ReDim WLS_Cldmt(0)
        Cnt = 0
        '2019/03/20 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '    Cnt = Cnt + 1
        '    ReDim Preserve WLS_Cldmt(Cnt)

        '    With WLS_Cldmt(Cnt)
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLDDT = CF_Ora_GetDyn(Usr_Ody_LC, "CLDDT", "") '日付
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDWKKB", "") '曜日
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDHLKB", "") '祝日
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SLDKB = CF_Ora_GetDyn(Usr_Ody_LC, "SLDKB", "") '営業日区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "BNKKDKB", "") '銀行稼動区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "DTBKDKB", "") '物流稼動区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBA", "") 'その他区分１
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBB", "") 'その他区分２
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBC", "") 'その他区分３
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBD", "") 'その他区分４
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBE", "") 'その他区分５
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBF", "") 'その他区分６
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBG", "") 'その他区分７
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBH", "") 'その他区分８
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBI", "") 'その他区分９
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBJ", "") 'その他区分１０
        '    End With

        '    Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop
        For Each row As DataRow In dt.Rows

            Cnt = Cnt + 1
            ReDim Preserve WLS_Cldmt(Cnt)

            With WLS_Cldmt(Cnt)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDDT = DB_NullReplace(row("CLDDT"), "") '日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDWKKB = DB_NullReplace(row("CLDWKKB"), "") '曜日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDHLKB = DB_NullReplace(row("CLDHLKB"), "") '祝日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SLDKB = DB_NullReplace(row("SLDKB"), "") '営業日区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BNKKDKB = DB_NullReplace(row("BNKKDKB"), "") '銀行稼動区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DTBKDKB = DB_NullReplace(row("DTBKDKB"), "") '物流稼動区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBA = DB_NullReplace(row("ETCKBA"), "") 'その他区分１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBB = DB_NullReplace(row("ETCKBB"), "") 'その他区分２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBC = DB_NullReplace(row("ETCKBC"), "") 'その他区分３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBD = DB_NullReplace(row("ETCKBD"), "") 'その他区分４
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBE = DB_NullReplace(row("ETCKBE"), "") 'その他区分５
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBF = DB_NullReplace(row("ETCKBF"), "") 'その他区分６
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBG = DB_NullReplace(row("ETCKBG"), "") 'その他区分７
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBH = DB_NullReplace(row("ETCKBH"), "") 'その他区分８
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBI = DB_NullReplace(row("ETCKBI"), "") 'その他区分９
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBJ = DB_NullReplace(row("ETCKBJ"), "") 'その他区分１０
            End With
        Next
        '2019/03/20 CHG E N D
		
        'クローズ
        '20190322 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '20190322 DEL END
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_Get_YmdKbn
	'   概要：  区分情報取得
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function WLS_Get_YmdKbn(ByRef yy As Short, ByRef mm As Short, ByRef dd As Short) As Boolean
		
		Dim Cnt As Short
		Dim bolKbnFlg As Boolean
		Dim strKbn As String
		
		'区分設定フラグ
		bolKbnFlg = False
		
		For Cnt = 1 To UBound(WLS_Cldmt)
			
			'UPGRADE_WARNING: オブジェクト SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 7, 2)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 5, 2)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 1, 4)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 1, 4)) = yy And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 5, 2)) = mm And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 7, 2)) = dd Then
				'日付が一致
				strKbn = ""
				Select Case WLSDATE_KBN
					Case DATE_KBN_SLDKB
						'営業日区分
						strKbn = WLS_Cldmt(Cnt).SLDKB
					Case DATE_KBN_BNKKDKB
						'銀行稼動区分
						strKbn = WLS_Cldmt(Cnt).BNKKDKB
					Case DATE_KBN_DTBKDKB
						'物流稼動区分
						strKbn = WLS_Cldmt(Cnt).DTBKDKB
					Case DATE_KBN_ETCKBA
						'その他区分１
						strKbn = WLS_Cldmt(Cnt).ETCKBA
					Case DATE_KBN_ETCKBB
						'その他区分２
						strKbn = WLS_Cldmt(Cnt).ETCKBB
					Case DATE_KBN_ETCKBC
						'その他区分３
						strKbn = WLS_Cldmt(Cnt).ETCKBC
					Case DATE_KBN_ETCKBD
						'その他区分４
						strKbn = WLS_Cldmt(Cnt).ETCKBD
					Case DATE_KBN_ETCKBE
						'その他区分５
						strKbn = WLS_Cldmt(Cnt).ETCKBE
					Case DATE_KBN_ETCKBF
						'その他区分６
						strKbn = WLS_Cldmt(Cnt).ETCKBF
					Case DATE_KBN_ETCKBG
						'その他区分７
						strKbn = WLS_Cldmt(Cnt).ETCKBG
					Case DATE_KBN_ETCKBH
						'その他区分８
						strKbn = WLS_Cldmt(Cnt).ETCKBH
					Case DATE_KBN_ETCKBI
						'その他区分９
						strKbn = WLS_Cldmt(Cnt).ETCKBI
					Case DATE_KBN_ETCKBJ
						'その他区分１０
						strKbn = WLS_Cldmt(Cnt).ETCKBJ
				End Select
				
				'当検索画面のパラメータに該当する区分で判定
				If strKbn = "1" Then
					bolKbnFlg = True
				End If
				Exit For
				
			End If
		Next 
		
		WLS_Get_YmdKbn = bolKbnFlg
		
	End Function
	
	'UPGRADE_WARNING: Form イベント WLS_DATE.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_DATE_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190521 DEL START
        '      DblClickFl = False

        ''UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        'If IsDbNull(Set_date.Value) Or Not IsDate(Set_date.Value) Then
        '	Sys_date.Value = DateString
        '	Sys_year.Value = VB.Left(Sys_date.Value, 4)
        '	Sys_month.Value = Mid(Sys_date.Value, 6, 2)
        '	Sys_day.Value = VB.Right(Sys_date.Value, 2)
        'Else
        '	Sys_date.Value = Set_date.Value
        '	Sys_year.Value = VB.Left(Set_date.Value, 4)
        '	Sys_month.Value = Mid(Set_date.Value, 6, 2)
        '          Sys_day.Value = VB.Right(Set_date.Value, 2)
        '      End If
        'Cur_year.Value = Sys_year.Value
        'Cur_month.Value = Sys_month.Value
        '      Set_calendar()
        '20190521 DEL END

    End Sub
	
	Private Sub WLS_DATE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = 27 Then Hide()
	End Sub
	
	Private Sub WLS_DATE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim w_date As String
		w_date = CStr(Today)
		If Len(w_date) <> 10 Then
			MsgBox("日付の形式が違います。" & Chr(13) & "コントロールパネルの各国対応の短い形式を修正して下さい。", 48)
			Hide()
		End If
		
		'   祝日の設定
		Dim INI_NO As Short
		Dim sLine As String
		INI_NO = FreeFile
		
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WLSDATE_RTNCODE = ""
		
		On Error Resume Next
		FileOpen(INI_NO, SSS_INIDAT(2) & "CALENDAR.INI", OpenMode.Input)
		If Err.Number <> 0 Then
			On Error GoTo CALENDAR_ERR
			FileOpen(INI_NO, SSS_INIDAT(0) & "CALENDAR.INI", OpenMode.Input)
		End If
		
		ReDim WLS_HoliDay(20)
		
		HdayCnt = 0
		Do Until EOF(INI_NO)
			sLine = LineInput(INI_NO)
			If InStr(sLine, "=") = 3 And InStr(sLine, "/") = 6 And Len(sLine) > 10 Then
				If HdayCnt > UBound(WLS_HoliDay) Then ReDim Preserve WLS_HoliDay(HdayCnt + 10)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_MM = SSSVal(Mid(sLine, 4, 2))
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_DD = SSSVal(Mid(sLine, 7, 2))
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_HoliDay(HdayCnt).H_KB = SSSVal(Mid(sLine, 10, 1))
				If InStr(sLine, ":") = 16 And InStr(sLine, ";") = 22 Then
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_SttYY = SSSVal(Mid(sLine, 12, 4))
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_OldDD = SSSVal(Mid(sLine, 17, 2))
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_HoliDay(HdayCnt).H_OldKB = SSSVal(Mid(sLine, 20, 1))
				End If
				HdayCnt = HdayCnt + 1
			End If
		Loop 
		FileClose(INI_NO)

        '20190521 ADD START
        DblClickFl = False

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(Set_date.Value) Or Not IsDate(Set_date.Value) Then
            Sys_date.Value = DateString
            Sys_year.Value = VB.Left(Sys_date.Value, 4)
            Sys_month.Value = Mid(Sys_date.Value, 6, 2)
            Sys_day.Value = VB.Right(Sys_date.Value, 2)
        Else
            Sys_date.Value = Set_date.Value
            Sys_year.Value = VB.Left(Set_date.Value, 4)
            Sys_month.Value = Mid(Set_date.Value, 6, 2)
            Sys_day.Value = VB.Right(Set_date.Value, 2)
        End If
        Cur_year.Value = Sys_year.Value
        Cur_month.Value = Sys_month.Value
        Set_calendar()
        '20190521 ADD END

        Exit Sub

CALENDAR_ERR: 
		MsgBox("カレンダー情報が正しくありません。", 48)
	End Sub
	
	Private Sub Label1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.Click
		Dim Index As Short = Label1.GetIndex(eventSender)
		Dim W_DAY As String
		Sys_year.Value = Cur_year.Value
		Sys_month.Value = Cur_month.Value
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Sys_day.Value = VB6.Format(SSSVal(Me.Label1(Index).Text), "00")
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		W_DAY = VB6.Format(SSSVal(Me.Label1(W_DAYIDX).Text), "00")
		'カレンダマスタの○○区分判定
		'UPGRADE_WARNING: オブジェクト SSSVal(W_DAY) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(Sys_month) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WLS_Get_YmdKbn(SSSVal(Sys_year.Value), SSSVal(Sys_month.Value), SSSVal(W_DAY)) = True Then
			'背景色【白】
			Me.Label1(W_DAYIDX).BackColor = System.Drawing.ColorTranslator.FromOle(KBNDAY_BACKCOLOR)
		Else
			Me.Label1(W_DAYIDX).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
		End If
		
		W_DAYIDX = Index
		Me.Label1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(SELECTDAY_BACKCOLOR)
	End Sub
	
	Private Sub Label1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.DoubleClick
		Dim Index As Short = Label1.GetIndex(eventSender)
		Dim C_day As Short
		C_day = Index + 2 - W_DAY
		If C_day > 0 And C_day <= D_MAX Then
			Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
			WLSDATE_RTNCODE = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
			Call WLS_SLIST_MOVE(Set_date.Value, Len(Set_date.Value))
			'DblClickイベント障害対応  97/04/07
			DblClickFl = True
		End If
	End Sub
	
	Private Sub Set_calendar()
		'   初期化設定
		Dim yy As Short
		Dim mm As Short
		Dim hday, hyear, hidx As Short
		Dim HdayArr() As Short
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		'UPGRADE_WARNING: オブジェクト WLS_DATE.ymdpanel.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/12 CHG START
        'Me.ymdpanel.Caption = VB6.Format(yy, "0000") & "年 " & VB6.Format(mm, "00") & "月"
        Me.ymdpanel.Text = VB6.Format(yy, "0000") & "年 " & VB6.Format(mm, "00") & "月"
        '2019/03/12 CHG E N D
		
		'カレンダ情報取得
		Call WLS_Get_Cldmta(yy, mm)
		
		'   当月の日数計算(28-31)
		If mm = 1 Or mm = 3 Or mm = 5 Or mm = 7 Or mm = 8 Or mm = 10 Or mm = 12 Then
			D_MAX = 31
		ElseIf mm = 4 Or mm = 6 Or mm = 9 Or mm = 11 Then 
			D_MAX = 30
		ElseIf (yy Mod 4 = 0 And yy Mod 100 <> 0) Or yy Mod 400 = 0 Then 
			D_MAX = 29
		Else
			D_MAX = 28
		End If
		
		ReDim HdayArr(D_MAX)
		Dim tmpX, tmpN, tmpD As Short
		
		'   当月一日の曜日計算(1-7)
		Dim s_date As New VB6.FixedLengthString(10)
		s_date.Value = VB6.Format(yy, "0000") & "/" & VB6.Format(mm, "00") & "/01"
		'UPGRADE_WARNING: DateValue に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		W_DAY = WeekDay(DateValue(s_date.Value))
		
		'   各日付への区分設定 0:通常, 1:振替可能祝日, 2:振替不可休日
		For hidx = 0 To HdayCnt - 1
			If WLS_HoliDay(hidx).H_MM = mm Then
				If WLS_HoliDay(hidx).H_KB = 3 Then '春分/秋分
					'   春分と秋分の計算
					hyear = yy - 1980
					If mm = 3 Then
						Select Case hyear
							Case 0, 4, 8, 12, 13, 16, 17, 20, 21, 24, 25, 28, 29, 32, 33, 36, 37, 40, 41, 44, 45, 46, 48, 49, 50, 52, 53, 54, 56, 57, 58, 60, 61, 62, 64, 65, 66, 68, 69, 70
								hday = 20
							Case Else
								hday = 21
						End Select
					ElseIf mm = 9 Then 
						Select Case hyear
							Case 32, 36, 40, 44, 48, 52, 56, 60, 64, 65, 68, 69
								hday = 22
							Case Else
								hday = 23
						End Select
					End If
					HdayArr(hday) = 1
				ElseIf WLS_HoliDay(hidx).H_SttYY > yy Then  '施行日以前
					'H_OldDD =0 の場合はダミー配列(=0)に入る
					If WLS_HoliDay(hidx).H_OldKB = 4 Then '第N X曜日
						tmpN = WLS_HoliDay(hidx).H_OldDD / 10
						tmpX = WLS_HoliDay(hidx).H_OldDD Mod 10
						tmpD = tmpX - W_DAY + (tmpN - 1) * 7
						If tmpX < W_DAY Then tmpD = tmpD + 7
						HdayArr(tmpD) = 2
					Else
						HdayArr(WLS_HoliDay(hidx).H_OldDD) = WLS_HoliDay(hidx).H_OldKB
					End If
				ElseIf WLS_HoliDay(hidx).H_KB = 4 Then  '第N X曜日
					tmpN = WLS_HoliDay(hidx).H_DD / 10
					tmpX = WLS_HoliDay(hidx).H_DD Mod 10
					tmpD = tmpX - W_DAY + (tmpN - 1) * 7 + 1
					If tmpX < W_DAY Then tmpD = tmpD + 7
					HdayArr(tmpD) = 2
				Else
					HdayArr(WLS_HoliDay(hidx).H_DD) = WLS_HoliDay(hidx).H_KB
				End If
			End If
		Next hidx
		
		'   日付の計算
		Dim count As Short ' count:日数
		Dim hnext As Short ' hnext:振替休日かどうか
		Dim k, X, Y, L As Short ' x:X座標, y:Y座標, k:座標連番(0～41),
		hnext = False
		count = 2 - W_DAY
		For Y = 0 To 5
			For X = 0 To 6
				k = Y * 7 + X
				If count > 0 And count <= D_MAX Then
					Me.Label1(k).Enabled = True
                    Me.Label1(k).Text = Trim(Str(count))
                    Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_FORECOlOR)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
					If hnext Then ' 振替休日かどうか
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
						hnext = False
					ElseIf X = 0 Then  ' 日曜日
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
						If HdayArr(count) = 1 Then hnext = True '当日が振替可能な祝日なら振替休日を設定する
					ElseIf HdayArr(count) > 0 Then 
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(HOLIDAY_FORECOlOR)
					ElseIf X = 6 Then  '土曜日
						Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(SATDAY_FORECOlOR)
					End If
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_day) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_month) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(Sys_year) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(Sys_year.Value) = yy And SSSVal(Sys_month.Value) = mm And SSSVal(Sys_day.Value) = count Then
						Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(SELECTDAY_BACKCOLOR)
						W_DAYIDX = k
					End If
					
					'カレンダマスタの○○区分判定
					If WLS_Get_YmdKbn(yy, mm, count) = True Then
						'背景色【白】
						Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(KBNDAY_BACKCOLOR)
					End If
				Else
					Me.Label1(k).Enabled = False
					Me.Label1(k).Text = ""
					Me.Label1(k).ForeColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_FORECOlOR)
					Me.Label1(k).BackColor = System.Drawing.ColorTranslator.FromOle(NORMALDAY_BACKCOLOR)
				End If
				count = count + 1
			Next X
		Next Y
	End Sub
	
	Private Sub Label1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = Label1.GetIndex(eventSender)
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		If mm = 12 Then
			yy = yy + 1
			mm = 1
		Else
			mm = mm + 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		Dim yy As Short
		Dim mm As Short
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		yy = SSSVal(Cur_year.Value)
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mm = SSSVal(Cur_month.Value)
		If mm = 1 Then
			yy = yy - 1
			mm = 12
		Else
			mm = mm - 1
		End If
		Cur_year.Value = VB6.Format(yy, "0000")
		Cur_month.Value = VB6.Format(mm, "00")
		Set_calendar()
		
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		Dim C_day As Short
		
		If (Sys_year.Value = Cur_year.Value) And (Sys_month.Value = Cur_month.Value) Then
			C_day = W_DAYIDX + 2 - W_DAY
			If C_day > 0 And C_day <= D_MAX Then
				Set_date.Value = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
				WLSDATE_RTNCODE = Cur_year.Value & "/" & Cur_month.Value & "/" & VB6.Format(C_day, "00")
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			End If
		Else
			MsgBox("日付が選択されていません")
		End If
	End Sub
End Class