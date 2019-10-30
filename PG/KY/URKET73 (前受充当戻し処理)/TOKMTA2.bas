Attribute VB_Name = "TOKMTA_DBM"
        Option Explicit
'==========================================================================
'   TOKMTA.DBM   ¾Óæ}X^                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TOKMTA
    DATKB          As String * 1     '`[íæª          0
    TOKMSTKB       As String * 1     '}X^æª(¾Óæ)    0
    THSCD          As String * 1     'æøæªÞ            0
    TOKCD          As String * 10    '¾ÓæR[h          !@@@@@@@@@@
    TOKNMA         As String * 60    '¾Óæ¼ÌP
    TOKNMB         As String * 60    '¾Óæ¼ÌQ
    TOKRN          As String * 40    '¾ÓæªÌ
    TOKNK          As String * 10    '¾Óæ¼ÌJi
    TOKNMC         As String * 30    '¾Óæ¼Ì¼pP
    TOKNMD         As String * 30    '¾Óæ¼Ì¼pQ
    TOKRNNK        As String * 20    '¾ÓæªÌJi
    TOKZP          As String * 20    '¾ÓæXÖÔ
    TOKADA         As String * 60    '¾ÓæZP
    TOKADB         As String * 60    '¾ÓæZQ
    TOKADC         As String * 60    '¾ÓæZR
    TOKTL          As String * 20    '¾ÓædbÔ
    TOKFX          As String * 20    '¾Óæe`wÔ
    TOKBOSNM       As String * 30    '¾Óæã\Ò¼
    TOKTANNM       As String * 30    '¾ÓæäSÒ¼
    TOKMLAD        As String * 50    '¾Óæ[AhX
    TANCD          As String * 6     'SÒR[h          000000
    TANNM          As String * 40    'SÒ¼
    LMTKN          As Currency       '^MÀxz            ####,###,##0.0000;;#
    TOKCLAKB       As String * 1     'ªÞæªPi¾Óæj  0
    TOKCLBKB       As String * 1     'ªÞæªQi¾Óæj  0
    TOKCLCKB       As String * 1     'ªÞæªRi¾Óæj  0
    TOKCLAID       As String * 6     'ªÞR[hP(¾Óæ)  !@@@@@@
    TOKCLBID       As String * 6     'ªÞR[hQ(¾Óæ)  !@@@@@@
    TOKCLCID       As String * 6     'ªÞR[hR(¾Óæ)  !@@@@@@
    TOKCLANM       As String * 20    'ªÞ¼ÌP(¾Óæ)
    TOKCLBNM       As String * 20    'ªÞ¼ÌQ(¾Óæ)
    TOKCLCNM       As String * 20    'ªÞ¼ÌR(¾Óæ)
    DSPKB          As String * 1     'õ\¦æª          0
    TOKJUNKB       As String * 1     'Ê\oÍæª        0
    TOKSEICD       As String * 10    '¿æR[h          !@@@@@@@@@@
    MAINHSCD       As String * 10    'ã\[üæR[h      !@@@@@@@@@@
    TOKSMEKB       As String * 1     '÷æª                0
    TOKSMEDD       As String * 2     '÷úút(ã)      DD
    TOKSMECC       As String * 2     '÷TCN(ã)      99
    TOKSDWKB       As String * 1     '÷ßjú              0
    TOKKESCC       As String * 2     'ñûTCN          00
    TOKKESDD       As String * 2     'ñûút              DD
    TOKKDWKB       As String * 1     'ñûjú              0
    LSTID          As String * 7     '`[íÊ              !@@@@@@@
    TKNRPSKB       As String * 1     'àz[      0
    TKNZRNKB       As String * 1     'àz[æª      0
    TOKZEIKB       As String * 1     'ÁïÅæª            0
    TOKZCLKB       As String * 1     'ÁïÅZoæª        0
    TOKRPSKB       As String * 1     'ÁïÅ[    0
    TOKZRNKB       As String * 1     'ÁïÅ[æª    0
    TOKNMMKB       As String * 1     '¼ÌÏÆ­±Ùæªi¾j   0
    SKCHKB         As String * 1     'ûæª              0
    IKOUKB         As String * 1     'Úsf[^æª        0
    TOKLEADD       As String * 2     '^ú              DD
    URKZANDT       As String * 8     '|cút          YYYY/MM/DD
    URKZANKN       As Currency       '|càz          ##,###,###,###
    SEIZANDT       As String * 8     '¿cút          YYYY/MM/DD
    SEIZANKN       As Currency       '¿càz          ##,###,###,###
    SMAZANDT       As String * 8     'o÷cút        YYYY/MM/DD
    SMAZANKN       As Currency       'o÷càz        ##,###,###,###
    SSAZANDT       As String * 8     '¿Ex¥÷cút  YYYY/MM/DD
    SSAZANKN       As Currency       '¿Ex¥÷càz  ##,###,###,###
    TOKSMEDT       As String * 8     '¿÷út            YYYY/MM/DD
    SSKKZADT       As String * 8     '¿÷Ácút    YYYY/MM/DD
    SSKKZAKN       As Currency       '¿÷Ácàz    ##,###,###,###
    OLDTOKCD       As String * 5     'æøæR[h        00000
    TGRPCD         As String * 10    'ã\ïÐR[h        0000000000
    OLTGRPCD       As String * 5     'ã\ïÐR[h      00000
    KIGYOCD        As String * 6     'êéÆR[h¯Ê    000000
    KGYEDACD       As String * 6     'êéÆR[h}Ô    000000
    KAKZUKE        As String * 10    'it
    BNKCD          As String * 7     'âsR[h            !@@@@@@@
    YKNKB          As String * 1     'aàíÊ              0
    KOZNO          As String * 7     'ûÀÔ              0000000
    HMEIGI         As String * 40    'U¼`
    SHAKB          As String * 1     'x¥æª              0
    TEGSHKN        As Currency       'è`x¥àz          ##,###,###,###
    TEGRT          As Currency       'è`ä¦              ##0.00;;#
    NYUDD          As Currency       'TCg
    TEGSHBS        As String * 1     'è`x¥ê          0
    HTSUKB         As String * 1     'Uè¿Sæª    0
    FCTCMCD        As String * 10    't@N^OïÐR  0000000000
    GYOSHU         As String * 5     'Æí                  00000
    CHIIKI         As String * 5     'næ                  00000
    SEIHKKB        As String * 1     '¿­sæª        0
    TOKDNKB        As String * 1     'qæwè`[æª      0
    TUKKB          As String * 3     'ÊÝæª              !@@@
    BINCD          As String * 2     'Ö¼R[h            00
    FRNKB          As String * 1     'COæøæª          0
    SIMUKE         As String * 5     'dün                00000
    EDIKB          As String * 1     'EDIæª               0
    EDIKBC         As String * 1     'EDIæª(¶îñ  0
    EDIKBCU        As String * 1     'EDIæª(¶¿    0
    EDIKBN         As String * 1     'EDIæª([úñ  0
    EDIKBS         As String * 1     'EDIæª(o×Êm  0
    EDIKBSEI       As String * 1     'EDIæª(¿îñ  0
    EDIKBNYU       As String * 1     'EDIæª(üàîñ  0
    EDIKBP         As String * 1     'EDIæª(x¥¾×  0
    EDIKBYBA       As String * 1     'EDIæª(¤iîñ  0
    EDIKBYBB       As String * 1     'EDIæª(\õQ    0
    EDIKBYBC       As String * 1     'EDIæª(\õR    0
    RELFL          As String * 1     'AgtO            0
    FOPEID         As String * 8     'ño^Õ°»Þ°ID       !@@@@@@@@
    FCLTID         As String * 5     'ño^¸×²±ÝÄID      !@@@@@
    WRTFSTTM       As String * 6     'À²Ñ½ÀÝÌß(o^Ô)    9(06)
    WRTFSTDT       As String * 8     'À²Ñ½ÀÝÌß(o^ú)      YYYY/MM/DD
    OPEID          As String * 8     'ÅIìÆÒR[h      !@@@@@@@@
    CLTID          As String * 5     'NCAghc      !@@@@@
    WRTTM          As String * 6     'À²Ñ½ÀÝÌß(Ô)        9(06)
    WRTDT          As String * 8     'À²Ñ½ÀÝÌß(út)        YYYY/MM/DD
    UOPEID         As String * 8     '[UID(ÊÞ¯Á)        !@@@@@@@@
    UCLTID         As String * 5     '¸×²±ÝÄID(ÊÞ¯Á)        !@@@@@
    UWRTTM         As String * 6     'À²Ñ½ÀÝÌß(Ô)        9(06)
    UWRTDT         As String * 8     'À²Ñ½ÀÝÌß(út)        YYYY/MM/DD
    PGID           As String * 7     'vOID          !@@@@@@@@
    
    SHAKBNM        As String * 10    'x¥ðði[iIvVpj
    HYTOKKESDD     As String * 4     'ñûút(\¦p)ði[ (IvVp)
    KESISMEDT      As String * 8     'ÁúÉ¨¯é¿÷úði[   (XbVÜÞ)
End Type
Global DB_TOKMTA As TYPE_DB_TOKMTA
'Global DBN_TOKMTA As Integer
' Index1( TOKCD )
' Index2( TOKNK + TOKCD )
' Index3( TOKCLAID + TOKCLBID + TOKCLCID + TOKCD )
' Index4( TOKCLBID + TOKCLCID + TOKCD )
' Index5( TOKCLCID + TOKCD )
' Index6( TANCD + TOKCD )
' Index7( TOKSEICD + TOKCD )
' Index8( DATKB + KOZNO + HMEIGI )
' Index9( TGRPCD + TOKCD )
' Index10( DATKB + KOZNO )

'Sub TOKMTA_RClear()
'Dim TmpStat
'    TmpStat = Dll_RClear(DBN_TOKMTA, G_LB)
'    Call ResetBuf(DBN_TOKMTA)
'End Sub
