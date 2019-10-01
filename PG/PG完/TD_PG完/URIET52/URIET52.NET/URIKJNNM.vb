Option Strict Off
Option Explicit On
Module URIKJNNM_F51
	'
	' スロット名        : 売上基準名称・画面項目スロット
	' ユニット名        : URIKJNNM.F51
	' 記述者            :
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	
	'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
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
	'''' ADD 2010/07/02  FKS) T.Yamamoto    End
	
	Function URIKJNNM_Derived(ByVal URIKJN As Object) As Object
		Dim Rtn As Short
		Dim KEY_CODE As String
		
		'UPGRADE_WARNING: オブジェクト URIKJN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Dim strSQL As String
		Dim strExePath As String
		If Trim(URIKJN) <> "" Then
			'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
			
			strSQL = ""
			strSQL = strSQL & "SELECT DISTINCT 1 FROM SYSTBH" & vbCrLf
			strSQL = strSQL & " WHERE EXISTS (" & vbCrLf
			strSQL = strSQL & "               SELECT C_JYUCYU_NO" & vbCrLf
			strSQL = strSQL & "                 FROM JDN_SHINKO" & vbCrLf
			strSQL = strSQL & "                WHERE C_FAC_CD = 'CONTEC'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "                  AND C_JYUCYU_NO = TRIM('" & RD_SSSMAIN_JDNNO(-1) & "')" & vbCrLf
			strSQL = strSQL & "                  AND  C_SHINKO_CLS = '1'" & vbCrLf
			strSQL = strSQL & "              )" & vbCrLf
			Call DB_GetSQL4(DBN_SYSTBH, strSQL)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト URIKJNNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URIKJNNM_Derived = "進行基準"
			Else
				'EOF, NULL以外
				If Not (DBSTAT = 1403 Or DBSTAT = 1405) Then
					'イベントテーブルへメッセージを書き込む
					With M_EVTTBL_PARA
						.IVWRDT = VB6.Format(Now, "YYYYMMDD") ' イベント発生日
						.IVWRTM = VB6.Format(Now, "HHMMSS") ' イベント発生時間
						.PGID = SSS_PrgId ' プログラムＩＤ
						.CLTID = SSS_CLTID.Value ' クライアントＩＤ
						.IVCLASS = "ERR" ' イベント種別
						.IVCODE = "0" ' イベントコード
						.IVPOINT = "URIKJNNM_Derived" ' イベント発生箇所
						.SNDPROFLG = "1" ' 送信可否フラグ
						.IVMSG = "OraError=[JDN_SHINKO:" & DBSTAT & "]" ' イベント内容
						
						strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
					End With
					Call Shell(strExePath)
				End If
                '''' ADD 2010/07/02  FKS) T.Yamamoto    End
                '''
                '20190627 DELL START
                'Call MEIMTA_RClear()
                '20190726 DELL END
                'UPGRADE_WARNING: オブジェクト URIKJN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                KEY_CODE = VB6.Format(URIKJN, "00")
				Call DB_GetEq(DBN_MEIMTA, 1, "005" & KEY_CODE & " ", BtrNormal)
				If DBSTAT <> 0 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: オブジェクト URIKJNNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URIKJNNM_Derived = ""
					Exit Function
				End If
				Call SCR_FromMEIMTA_URIKJN(0)
				'''' ADD 2010/07/02  FKS) T.Yamamoto    Start    連絡票№FC10070201
			End If
			'''' ADD 2010/07/02  FKS) T.Yamamoto    End
		Else
			'UPGRADE_WARNING: オブジェクト URIKJNNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKJNNM_Derived = ""
		End If
		
		'
		'    If Trim$(URIKJN) <> "" Then
		'        Select Case Trim$(URIKJN)
		'            Case "1"
		'                URIKJNNM_Derived = "出荷基準"
		'            Case "2"
		'                URIKJNNM_Derived = "検収基準"
		'            Case "3"
		'                URIKJNNM_Derived = "役務完了基準"
		'            Case "4"
		'                URIKJNNM_Derived = "工事完了基準"
		'        End Select
		'    Else
		'        URIKJNNM_Derived = ""
		'    End If
	End Function
	
	Sub SCR_FromMEIMTA_URIKJN(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_URIKJN(De, Trim(DB_MEIMTA.MEICDA))
		Call DP_SSSMAIN_URIKJNNM(De, Trim(DB_MEIMTA.MEINMA))
	End Sub
End Module