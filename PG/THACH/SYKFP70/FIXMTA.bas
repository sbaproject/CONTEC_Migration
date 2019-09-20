Attribute VB_Name = "FIXMTA_DBM"
        Option Explicit
'==========================================================================
'   FIXMTA.DBM   固定値マスタ                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_FIXMTA
    DATKB          As String * 1     '削除区分
    CTLCD          As String * 10    '管理コード
    CTLNM          As String * 50    '管理名称
    FIXVAL         As String * 20    '固定値
    REMARK         As String * 128   '備考
    RELFL          As String * 1     '連携フラグ
    OPEID          As String * 8     '最終作業者コード
    CLTID          As String * 5     'クライアントＩＤ
    WRTTM          As String * 6     'タイムスタンプ（時間）
    WRTDT          As String * 8     'タイムスタンプ（日付）
    WRTFSTTM       As String * 6     'タイムスタンプ（登録時間）
    WRTFSTDT       As String * 8     'タイムスタンプ（登録日）
End Type
Global DB_FIXMTA As TYPE_DB_FIXMTA
Global DBN_FIXMTA As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_FIXMTA_Clear
    '   概要：  固定値マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_FIXMTA_Clear(ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA)

        Dim Clr_DB_FIXMTA As TYPE_DB_FIXMTA
    
        pot_DB_FIXMTA = Clr_DB_FIXMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPCTLCD_SEARCH
    '   概要：  管理コード検索
    '   引数：  pin_strCTLCD  : 検索対象管理コード
    '           pot_DB_FIXMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, _
                                    ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPCTLCD_SEARCH
    
        DSPCTLCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from FIXMTA "
        strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPCTLCD_SEARCH = 1
            GoTo END_DSPCTLCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_FIXMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '削除区分
                .CTLCD  = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "")                   '管理コード
                .CTLNM  = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "")                   '管理名称
                .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "")                  '固定値
                .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "")                  '備考
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        DSPCTLCD_SEARCH = 0
        
END_DSPCTLCD_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPCTLCD_SEARCH:
        GoTo END_DSPCTLCD_SEARCH
        
    End Function
