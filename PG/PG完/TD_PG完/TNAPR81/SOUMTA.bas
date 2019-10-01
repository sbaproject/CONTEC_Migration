Attribute VB_Name = "SOUMTA_DBM"
        Option Explicit
'==========================================================================
'   SOUMTA.DBM   qÉ}X^                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SOUMTA
    DATKB          As String * 1     '`[íæª          0
    SOUCD          As String * 3     'qÉR[h            000
    SOUNM          As String * 20    'qÉ¼
    SOUZP          As String * 20    'qÉXÖÔ
    SOUADA         As String * 60    'qÉZP
    SOUADB         As String * 60    'qÉZQ
    SOUADC         As String * 60    'qÉZR
    SOUTL          As String * 20    'qÉdbÔ
    SOUFX          As String * 20    'qÉe`wÔ
    SOUBSCD        As String * 3     'êR[h            000
    SOUKB          As String * 1     'qÉíÊ              0
    SRSCNKB        As String * 1     '¼Ø±Ù½·¬ÝvÛæª      0
    SISNKB         As String * 1     'Y³æª            0
    SOUTRICD       As String * 10    'æøæR[h          !@@@@@@@@@@
    SOUKOKB        As String * 2     'qÉæª              00
    HIKKB          As String * 1     'øÎÛæª          0
    SALPALKB       As String * 1     'ÌvæÎÛæª
    RELFL          As String * 1     'AgtO            X
    OPEID          As String * 8     'ÅIìÆÒR[h      !@@@@@@@@
    CLTID          As String * 5     'NCAghc      !@@@@@
    WRTTM          As String * 6     'À²Ñ½ÀÝÌß(Ô)        9(06)
    WRTDT          As String * 8     'À²Ñ½ÀÝÌß(út)        YYYY/MM/DD
    WRTFSTTM       As String * 6     'À²Ñ½ÀÝÌß(o^Ô)    9(06)
    WRTFSTDT       As String * 8     'À²Ñ½ÀÝÌß(o^ú)      YYYY/MM/DD
End Type
Global DB_SOUMTA As TYPE_DB_SOUMTA
Global DBN_SOUMTA As Integer

'qÉ}X^õßèl
Public WLSSOU_RTNCODE       As String           'qÉR[h

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ¼ÌF  Sub DB_SOUMTA_Clear
    '   TvF  qÉ}X^\¢ÌNA
    '   øF@Èµ
    '   ßlF
    '   õlF
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SOUMTA_Clear(ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA)

        Dim Clr_DB_SOUMTA As TYPE_DB_SOUMTA
    
        pot_DB_SOUMTA = Clr_DB_SOUMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ¼ÌF  Function DSPSOUCD_SEARCH
    '   TvF  qÉR[hõ
    '   øF@Èµ
    '   ßlF@0:³íI¹ 1:ÎÛf[^³µ 9:ÙíI¹
    '   õlF
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPSOUCD_SEARCH(ByVal pin_strSOUCD As String, _
                                    ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody
        
    On Error GoTo ERR_DSPSOUCD_SEARCH
    
        DSPSOUCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SOUMTA "
        strSQL = strSQL & "  Where SOUCD = '" & pin_strSOUCD & "' "
        

        'DBANZX
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            'æ¾f[^Èµ
            Call CF_Ora_CloseDyn(Usr_Ody)
            DSPSOUCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_SOUMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '`[íæª
                .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    'qÉR[h
                .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    'qÉ¼
                .SOUZP = CF_Ora_GetDyn(Usr_Ody, "SOUZP", "")                    'qÉXÖÔ
                .SOUADA = CF_Ora_GetDyn(Usr_Ody, "SOUADA", "")                  'qÉZP
                .SOUADB = CF_Ora_GetDyn(Usr_Ody, "SOUADB", "")                  'qÉZQ
                .SOUADC = CF_Ora_GetDyn(Usr_Ody, "SOUADC", "")                  'qÉZR
                .SOUTL = CF_Ora_GetDyn(Usr_Ody, "SOUTL", "")                    'qÉdbÔ
                .SOUFX = CF_Ora_GetDyn(Usr_Ody, "SOUFX", "")                    'qÉe`wÔ
                .SOUBSCD = CF_Ora_GetDyn(Usr_Ody, "SOUBSCD", "")                'êR[h
                .SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB", "")                    'qÉíÊ
                .SRSCNKB = CF_Ora_GetDyn(Usr_Ody, "SRSCNKB", "")                'VAXLvÛæª
                .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")                  'Y³æª
                .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")              'æøæR[h
                .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "")                'qÉæª
                .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB", "")                    'øÎÛæª
                .SALPALKB = CF_Ora_GetDyn(Usr_Ody, "SALPALKB", "")              'ÌvæÎÛæª
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    'AgtO
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    'ÅIìÆÒR[h
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'NCAghc
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '^CX^viÔj
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '^CX^viútj
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '^CX^vio^Ôj
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '^CX^vio^új
            End With
        End If

        'N[Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPSOUCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPSOUCD_SEARCH:
        
        
    End Function


