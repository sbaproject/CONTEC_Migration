Attribute VB_Name = "JDNTHA_DBM"
        Option Explicit
'==========================================================================
'   JDNTHA.DBM   ó©og                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTHA
    DATNO           As String * 10      '`[Ç
    DATKB           As String * 1       '`[íæª
    DENKB           As String * 1       '`[æª
    JDNNO           As String * 10      'óÔ
    JHDNO           As String * 10      'ó­
    JDNDT           As String * 8       'ó`[út
    DENDT           As String * 8       'óút
    DEFNOKDT        As String * 8       '[ú
    TOKCD           As String * 10      '¾ÓæR[h
    TOKRN           As String * 40      '¾ÓæªÌ
    NHSCD           As String * 10      '[üæR[h
    NHSNMA          As String * 60      '[üæ¼ÌP
    NHSNMB          As String * 60      '[üæ¼ÌQ
    TANCD           As String * 6       'SÒR[h
    TANNM           As String * 40      'SÒ¼
    BUMCD           As String * 6       'åR[h
    BUMNM           As String * 40      'å¼
    TOKSEICD        As String * 10      '¿æR[h
    SOUCD           As String * 3       'qÉR[h
    SOUNM           As String * 20      'qÉ¼
    ZKTKB           As String * 1       'æøæª
    ZKTNM           As String * 4       'æøæª¼
    SMADT           As String * 8       'o÷út
    JDNENDKB        As String * 1       'ó®¹æª
    SBAUODKN        As Currency         'óàzi{Ìvj
    SBAUZEKN        As Currency         'óàziÁïÅzj
    SBAUZKKN        As Currency         'óàzi`[vj
    DENCM           As String * 40      'õl
    TOKSMEKB        As String * 1       '÷æª
    TOKSMEDD        As String * 2       '÷úútiãj
    TOKSMECC        As String * 2       '÷TCNiãj
    TOKSDWKB        As String * 1       '÷ßjú
    TOKKESCC        As String * 2       'ñûTCN
    TOKKESDD        As String * 2       'ñûút
    TOKKDWKB        As String * 1       'ñûjú
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
    MITNO           As String * 10      '©ÏÔ
    MITNOV          As String * 2       'Å
' === 20060726 === UPDATE S - ACE)Nagasawa
'    AKNID           As Currency         'Ähc
    AKNID           As String           'Ähc
' === 20060726 === UPDATE E -
    CLMDL           As String * 15      'ªÞ^®
    URIKJN          As String * 1       'ãî
    BINCD           As String * 2       'Ö¼R[h
    KENNMA          As String * 40      '¼P
    KENNMB          As String * 40      '¼Q
    BKTHKKB         As String * 1       'ªsÂæª
    MAEUKKB         As String * 1       'Oóæª
    SEIKB           As String * 1       '¿æª
    JDNTRKB         As String * 2       'óæøæª
    NHSADA          As String * 60      '[üæZP
    NHSADB          As String * 60      '[üæZQ
    NHSADC          As String * 60      '[üæZR
    JDNINKB         As String * 1       'óæíÊ
    DFKJDNNO        As String * 12      '_CtNóÔ
    TOKJDNNO        As String * 23      'qæ¶No.
    HDKEIKN         As Currency         'n[h_ñàz
    HDSIKKN         As Currency         'n[hdØàz
    SFKEIKN         As Currency         '\tg_ñàz
    SFSIKKN         As Currency         '\tgdØàz
    CMPKTCD         As String * 2       'Rs[^^®R[h
    CMPKTNM         As String * 20      'Rs[^^®¼
    PRDTBMCD        As String * 6       '¶YSåR[h
    TUKKB           As String * 3       'ÊÝæª
    SBAFRCKN        As Currency         'OÝóàzi`[vj
    JODRSNKB        As String * 3       'óRæª
    JODCNKB         As String * 3       'óLZRæª
    JSKTANCD        As String * 6       'næÀÑSÒR[h
    JSKTANNM        As String * 40      'næÀÑSÒ¼
    JSKBMNCD        As String * 6       'næÀÑåR[h
    JSKBMNNM        As String * 40      'næÀÑå¼
    FRNKB           As String * 1       'COæøæª
    SIMUKE          As String * 5       'dün
    JDNPRKB         As String * 1       '­sæª
    DENCMIN         As String * 40      'Ðàõl
    OPEID           As String * 8       'ÅIìÆÒR[h
    CLTID           As String * 5       'NCAghc
    WRTTM           As String * 6       '^CX^viÔj
    WRTDT           As String * 8       '^CX^viútj
    WRTFSTTM        As String * 6       '^CX^vio^Ôj
    WRTFSTDT        As String * 8       '^CX^vio^új
    JDNENDNM        As String * 6       'ó®¹æª¼
End Type
Global DB_JDNTHA As TYPE_DB_JDNTHA
Global DBN_JDNTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + JDNNO )
' Index3( SMADT )
' Index4( DATKB + JDNDT + JDNNO + TOKCD )
' Index5( DATKB + TOKCD + JDNNO )
' Index6( DATKB + JDNENDKB + TOKCD + DEFNOKDT + JDNNO )

Sub JDNTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_JDNTHA, G_LB)
    Call ResetBuf(DBN_JDNTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ¼ÌF  Function DSPJDNTHA_SEARCH
    '   TvF  ó©oµgõ
    '   øF@pin_strJDNNO          :óÔ
    '           pot_DB_JDNTHA@@@@ :ó©oµgf[^
    '           pin_strDATKB @@@@ :`[íæªiOptionalAn³êÈ¢ê"1"j
    '   ßlF@0:³íI¹ 1:ÎÛf[^³µ 9:ÙíI¹
    '   õlF
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPJDNTHA_SEARCH(ByVal pin_strJDNNO As String, _
                                 ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, _
                        Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPJDNTHA_SEARCH
    
    DSPJDNTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from JDNTHA "
    strSQL = strSQL & "  Where JDNNO = '" & pin_strJDNNO & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DBANZX
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        'æ¾f[^Èµ
        DSPJDNTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_JDNTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '`[Ç
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '`[íæª
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '`[æª
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    'óÔ
            .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "")                    'ó­
            .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "")                    'ó`[út
            .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "")                    'óút
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '[ú
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '¾ÓæR[h
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '¾ÓæªÌ
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '[üæR[h
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '[üæ¼ÌP
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '[üæ¼ÌQ
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    'SÒR[h
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    'SÒ¼
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    'åR[h
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    'å¼
            .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '¿æR[h
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    'qÉR[h
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    'qÉ¼
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    'æøæª
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    'æøæª¼
            .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "")                    'o÷út
            .JDNENDKB = CF_Ora_GetDyn(Usr_Ody, "JDNENDKB", "")              'ó®¹æª
            .SBAUODKN = CF_Ora_GetDyn(Usr_Ody, "SBAUODKN", 0)               'óàzi{Ìvj
            .SBAUZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZEKN", 0)               'óàziÁïÅzj
            .SBAUZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZKKN", 0)               'óàzi`[vj
            .DENCM = CF_Ora_GetDyn(Usr_Ody, "DENCM", "")                    'õl
            .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")              '÷æª
            .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")              '÷úútiãj
            .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "TOKSMECC", "")              '÷TCNiãj
            .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")              '÷ßjú
            .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")              'ñûTCN
            .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")              'ñûút
            .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")              'ñûjú
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
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '©ÏÔ
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  'Å
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    'Ähc
            .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "")                    'ªÞ^®
            .URIKJN = CF_Ora_GetDyn(Usr_Ody, "URIKJN", "")                  'ãî
            .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    'Ö¼R[h
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '¼P
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '¼Q
            .BKTHKKB = CF_Ora_GetDyn(Usr_Ody, "BKTHKKB", "")                'ªsÂæª
            .MAEUKKB = CF_Ora_GetDyn(Usr_Ody, "MAEUKKB", "")                'Oóæª
            .SEIKB = CF_Ora_GetDyn(Usr_Ody, "SEIKB", "")                    '¿æª
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                'óæøæª
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '[üæZP
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '[üæZQ
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '[üæZR
            .JDNINKB = CF_Ora_GetDyn(Usr_Ody, "JDNINKB", "")                'óæíÊ
            .DFKJDNNO = CF_Ora_GetDyn(Usr_Ody, "DFKJDNNO", "")              '_CtNóÔ
            .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "")              'qæ¶No.
            .HDKEIKN = CF_Ora_GetDyn(Usr_Ody, "HDKEIKN", 0)                 'n[h_ñàz
            .HDSIKKN = CF_Ora_GetDyn(Usr_Ody, "HDSIKKN", 0)                 'n[hdØàz
            .SFKEIKN = CF_Ora_GetDyn(Usr_Ody, "SFKEIKN", 0)                 '\tg_ñàz
            .SFSIKKN = CF_Ora_GetDyn(Usr_Ody, "SFSIKKN", 0)                 '\tgdØàz
            .CMPKTCD = CF_Ora_GetDyn(Usr_Ody, "CMPKTCD", "")                'Rs[^^®R[h
            .CMPKTNM = CF_Ora_GetDyn(Usr_Ody, "CMPKTNM", "")                'Rs[^^®¼
            .PRDTBMCD = CF_Ora_GetDyn(Usr_Ody, "PRDTBMCD", "")              '¶YSåR[h
            .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    'ÊÝæª
            .SBAFRCKN = CF_Ora_GetDyn(Usr_Ody, "SBAFRCKN", 0)               'OÝóàzi`[vj
            .JODRSNKB = CF_Ora_GetDyn(Usr_Ody, "JODRSNKB", "")              'óRæª
            .JODCNKB = CF_Ora_GetDyn(Usr_Ody, "JODCNKB", "")                'óLZRæª
            .JSKTANCD = CF_Ora_GetDyn(Usr_Ody, "JSKTANCD", "")              'næÀÑSÒR[h
            .JSKTANNM = CF_Ora_GetDyn(Usr_Ody, "JSKTANNM", "")              'næÀÑSÒ¼
            .JSKBMNCD = CF_Ora_GetDyn(Usr_Ody, "JSKBMNCD", "")              'næÀÑåR[h
            .JSKBMNNM = CF_Ora_GetDyn(Usr_Ody, "JSKBMNNM", "")              'næÀÑå¼
            .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    'COæøæª
            .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  'dün
            .JDNPRKB = CF_Ora_GetDyn(Usr_Ody, "JDNPRKB", "")                '­sæª
            .DENCMIN = CF_Ora_GetDyn(Usr_Ody, "DENCMIN", "")                'Ðàõl
            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    'ÅIìÆÒR[h
            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'NCAghc
            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    '^CX^viÔj
            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    '^CX^viútj
            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              '^CX^vio^Ôj
            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              '^CX^vio^új
            .JDNENDNM = CF_Ora_GetDyn(Usr_Ody, "JDNENDNM", "")              'ó®¹æª¼
        End With
    End If

    'N[Y
    Call CF_Ora_CloseDyn(Usr_Ody)
    

    DSPJDNTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPJDNTHA_SEARCH:
        
End Function


