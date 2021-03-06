Attribute VB_Name = "MITTHA_DBM"
        Option Explicit
'==========================================================================
'   MITTHA.DBM   ©Ï©og                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_MITTHA
    DATNO           As String * 10      '`[Ç
    DATKB           As String * 1       '`[íæª
    DENKB           As String * 1       '`[æª
    MITNO           As String * 10      '©ÏÔ
    MITNOV          As String * 2       'Å
    AKNID           As String * 8       'Ähc
    MITDT           As String * 8       '©Ïút
    JDNYTDT         As String * 8       'ó\èú
    DEFNOKDT        As String * 8       '[ú
    NOKDTPRT        As String * 40      'qæ[úiópj
    TOKCD           As String * 10      '¾ÓæR[h
    TOKRN           As String * 40      '¾ÓæªÌ
    NHSCD           As String * 10      '[üæR[h
    NHSNMA          As String * 60      '[üæ¼ÌP
    NHSNMB          As String * 60      '[üæ¼ÌQ
    TANCD           As String * 6       'SÒR[h
    TANNM           As String * 40      'SÒ¼
    BUMCD           As String * 6       'åR[h
    BUMNM           As String * 40      'cÆå¼
    SOUCD           As String * 3       'qÉR[h
    SOUNM           As String * 20      'qÉ¼
    ZKTKB           As String * 1       'æøæª
    ZKTNM           As String * 4       'æøæª¼
    SBAMITKN        As Currency         '©Ïàzi{Ìvj
    SBAMZEKN        As Currency         '©ÏàziÁïÅzj
    SBAMZKKN        As Currency         '©Ïàzi`[vj
    DENCMA          As String * 80      'õlP
    DENCMB          As String * 80      'õlQ
    DENCMC          As String * 80      'õlR
    DENCMD          As String * 80      'õlS
    DENCME          As String * 80      'õlT
    DENCMF          As String * 80      'õlU
    TFPATH          As String * 128     'Ytt@CpX
    LSTID           As String * 7       '`[íÊ
    TKNRPSKB        As String * 1       'àz[
    TKNZRNKB        As String * 1       'àz[æª
    TOKZEIKB        As String * 1       'ÁïÅæª
    TOKZCLKB        As String * 1       'ÁïÅZoæª
    TOKRPSKB        As String * 1       'ÁïÅ[
    TOKZRNKB        As String * 1       'ÁïÅ[æª
    TOKNMMKB        As String * 1       '¼ÌÏÆ­±ÙüÍæªi¾Óæj
    NHSNMMKB        As String * 1       '¼ÌÏÆ­±ÙüÍæªi[üæj
    TOKMSTKB        As String * 1       '}X^æªi¾Óæj
    NHSMSTKB        As String * 1       '}X^æªi[üæj
    TANMSTKB        As String * 1       '}X^æªiSÒj
    JDNNO           As String * 10      'óÔ
    MSBNNO          As String * 20      '»Ô
    KENNMA          As String * 40      '¼P
    KENNMB          As String * 40      '¼Q
    YUKOKGN         As String * 30      'LøúÀ
    SHAJKN          As String * 30      'x¥ð
    JDNTRKB         As String * 2       'óæøæª
    NHSADA          As String * 60      '[üæZP
    NHSADB          As String * 60      '[üæZQ
    NHSADC          As String * 60      '[üæZR
    KKTMTFL         As String * 1       'mè©ÏtO
    HANPLFL         As String * 1       'ÌvæAgtO
    TKAFL           As String * 1       'Á¿tO
    KHIKFL          As String * 1       '¼øtO
    TOKTL           As String * 20      '¾ÓædbÔ
    TOKFX           As String * 20      '¾Óæe`wÔ
    TOKTANNM        As String * 30      '¾ÓæäSÒ¼
    TOKMLAD         As String * 50      '¾Óæ[AhX
    OPEID           As String * 8       'ÅIìÆÒR[h
    CLTID           As String * 5       'NCAghc
    WRTTM           As String * 6       '^CX^viÔj
    WRTDT           As String * 8       '^CX^viútj
    WRTFSTTM        As String * 6       '^CX^vio^Ôj
    WRTFSTDT        As String * 8       '^CX^vio^új
End Type
Global DB_MITTHA As TYPE_DB_MITTHA
Global DBN_MITTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + MITNO )
' Index3( SMADT )
' Index4( DATKB + MITDT + MITNO + TOKCD )

Sub MITTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_MITTHA, G_LB)
    Call ResetBuf(DBN_MITTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ¼ÌF  Function DSPMITTHA_SEARCH
    '   TvF  ©Ï©oµgõ
    '   øF@pin_strMITNO          :©ÏÔ
    '           pin_strMITNOV  @@@ :Å
    '           pot_DB_MITTHA  @@@ :©Ï©oµgf[^
    '           pin_strDATKB   @@@ :`[íæªiOptionalAn³êÈ¢ê"1"j
    '   ßlF@0:³íI¹ 1:ÎÛf[^³µ 9:ÙíI¹
    '   õlF
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPMITTHA_SEARCH(ByVal pin_strMITNO As String, _
                                  ByVal pin_strMITNOV As String, _
                                  ByRef pot_DB_MITTHA As TYPE_DB_MITTHA, _
                         Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPMITTHA_SEARCH
    
    DSPMITTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from MITTHA "
    strSQL = strSQL & "  Where MITNO = '" & pin_strMITNO & "' "
    strSQL = strSQL & "  And   MITNOV = '" & pin_strMITNOV & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DBANZX
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        'æ¾f[^Èµ
        DSPMITTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_MITTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '`[Ç
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '`[íæª
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '`[æª
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '©ÏÔ
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  'Å
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    'Ähc
            .MITDT = CF_Ora_GetDyn(Usr_Ody, "MITDT", "")                    '©Ïút
            .JDNYTDT = CF_Ora_GetDyn(Usr_Ody, "JDNYTDT", "")                'ó\èú
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '[ú
            .NOKDTPRT = CF_Ora_GetDyn(Usr_Ody, "NOKDTPRT", "")              'qæ[úiópj
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '¾ÓæR[h
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '¾ÓæªÌ
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '[üæR[h
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '[üæ¼ÌP
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '[üæ¼ÌQ
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    'SÒR[h
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    'SÒ¼
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    'åR[h
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    'cÆå¼
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    'qÉR[h
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    'qÉ¼
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    'æøæª
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    'æøæª¼
            .SBAMITKN = CF_Ora_GetDyn(Usr_Ody, "SBAMITKN", 0)               '©Ïàzi{Ìvj
            .SBAMZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZEKN", 0)               '©ÏàziÁïÅzj
            .SBAMZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZKKN", 0)               '©Ïàzi`[vj
            .DENCMA = CF_Ora_GetDyn(Usr_Ody, "DENCMA", "")                  'õlP
            .DENCMB = CF_Ora_GetDyn(Usr_Ody, "DENCMB", "")                  'õlQ
            .DENCMC = CF_Ora_GetDyn(Usr_Ody, "DENCMC", "")                  'õlR
            .DENCMD = CF_Ora_GetDyn(Usr_Ody, "DENCMD", "")                  'õlS
            .DENCME = CF_Ora_GetDyn(Usr_Ody, "DENCME", "")                  'õlT
            .DENCMF = CF_Ora_GetDyn(Usr_Ody, "DENCMF", "")                  'õlU
            .TFPATH = CF_Ora_GetDyn(Usr_Ody, "TFPATH", "")                  'Ytt@CpX
            .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "")                    '`[íÊ
            .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "TKNRPSKB", "")              'àz[
            .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "TKNZRNKB", "")              'àz[æª
            .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")              'ÁïÅæª
            .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "TOKZCLKB", "")              'ÁïÅZoæª
            .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "TOKRPSKB", "")              'ÁïÅ[
            .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "TOKZRNKB", "")              'ÁïÅ[æª
            .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '¼ÌÏÆ­±ÙüÍæªi¾Óæj
            .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "")              '¼ÌÏÆ­±ÙüÍæªi[üæj
            .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              '}X^æªi¾Óæj
            .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "")              '}X^æªi[üæj
            .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "")              '}X^æªiSÒj
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    'óÔ
            .MSBNNO = CF_Ora_GetDyn(Usr_Ody, "MSBNNO", "")                  '»Ô
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '¼P
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '¼Q
            .YUKOKGN = CF_Ora_GetDyn(Usr_Ody, "YUKOKGN", "")                'LøúÀ
            .SHAJKN = CF_Ora_GetDyn(Usr_Ody, "SHAJKN", "")                  'x¥ð
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                'óæøæª
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '[üæZP
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '[üæZQ
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '[üæZR
            .KKTMTFL = CF_Ora_GetDyn(Usr_Ody, "KKTMTFL", "")                'mè©ÏtO
            .HANPLFL = CF_Ora_GetDyn(Usr_Ody, "HANPLFL", "")                'ÌvæAgtO
            .TKAFL = CF_Ora_GetDyn(Usr_Ody, "TKAFL", "")                    'Á¿tO
            .KHIKFL = CF_Ora_GetDyn(Usr_Ody, "KHIKFL", "")                  '¼øtO
            .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '¾ÓædbÔ
            .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '¾Óæe`wÔ
            .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '¾ÓæäSÒ¼
            .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '¾Óæ[AhX
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
    

    DSPMITTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPMITTHA_SEARCH:
        
End Function
    


