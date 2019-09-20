Option Strict Off
Option Explicit On

'2019/04/02 ADD START
Imports Oracle.DataAccess.Client
'2019/04/02 ADD E N D

Module UDNTRA_M81

    '2019/04/02 ADD START
    Private Structure sUDNTRA
        Dim inUDNTRA_datno As String()
        Dim inUDNTRA_datkb As String()
        Dim inUDNTRA_akakrokb As String()
        Dim inUDNTRA_denkb As String()
        Dim inUDNTRA_udnno As String()
        Dim inUDNTRA_linno As String()
        Dim inUDNTRA_zktkb As String()
        Dim inUDNTRA_odnno As String()
        Dim inUDNTRA_odnlinno As String()
        Dim inUDNTRA_jdnno As String()
        Dim inUDNTRA_jdnlinno As String()
        Dim inUDNTRA_recno As String()
        Dim inUDNTRA_usdno As String()
        Dim inUDNTRA_udndt As String()
        Dim inUDNTRA_dkbsb As String()
        Dim inUDNTRA_dkbid As String()
        Dim inUDNTRA_dkbnm As String()
        Dim inUDNTRA_henrsncd As String()
        Dim inUDNTRA_hensttcd As String()
        Dim inUDNTRA_smadt As String()
        Dim inUDNTRA_ssadt As String()
        Dim inUDNTRA_kesdt As String()
        Dim inUDNTRA_tokcd As String()
        Dim inUDNTRA_tancd As String()
        Dim inUDNTRA_nhscd As String()
        Dim inUDNTRA_tokseicd As String()
        Dim inUDNTRA_soucd As String()
        Dim inUDNTRA_sbnno As String()
        Dim inUDNTRA_hincd As String()
        Dim inUDNTRA_tokjdnno As String()
        Dim inUDNTRA_hinnma As String()
        Dim inUDNTRA_hinnmb As String()
        Dim inUDNTRA_untcd As String()
        Dim inUDNTRA_untnm As String()
        Dim inUDNTRA_irisu As Decimal()
        Dim inUDNTRA_cassu As Decimal()
        Dim inUDNTRA_urisu As Decimal()
        Dim inUDNTRA_uritk As Decimal()
        Dim inUDNTRA_gnktk As Decimal()
        Dim inUDNTRA_siktk As Decimal()
        Dim inUDNTRA_furitk As Decimal()
        Dim inUDNTRA_urikn As Decimal()
        Dim inUDNTRA_furikn As Decimal()
        Dim inUDNTRA_sikkn As Decimal()
        Dim inUDNTRA_uzekn As Decimal()
        Dim inUDNTRA_nyudt As String()
        Dim inUDNTRA_nyukn As Decimal()
        Dim inUDNTRA_fnyukn As Decimal()
        Dim inUDNTRA_gnkkn As Decimal()
        Dim inUDNTRA_jkesikn As Decimal()
        Dim inUDNTRA_fkesikn As Decimal()
        Dim inUDNTRA_kesikb As String()
        Dim inUDNTRA_nyukb As String()
        Dim inUDNTRA_tnkid As String()
        Dim inUDNTRA_tukkb As String()
        Dim inUDNTRA_ratert As Decimal()
        Dim inUDNTRA_emgodnkb As String()
        Dim inUDNTRA_okrjono As String()
        Dim inUDNTRA_invno As String()
        Dim inUDNTRA_lincma As String()
        Dim inUDNTRA_lincmb As String()
        Dim inUDNTRA_bnkcd As String()
        Dim inUDNTRA_bnknm As String()
        Dim inUDNTRA_tegno As String()
        Dim inUDNTRA_tegdt As String()
        Dim inUDNTRA_updid As String()
        Dim inUDNTRA_dfldkbcd As String()
        Dim inUDNTRA_dkbzaifl As String()
        Dim inUDNTRA_dkbtegfl As String()
        Dim inUDNTRA_dkbfla As String()
        Dim inUDNTRA_dkbflb As String()
        Dim inUDNTRA_dkbflc As String()
        Dim inUDNTRA_lstid As String()
        Dim inUDNTRA_hinzeikb As String()
        Dim inUDNTRA_hinmstkb As String()
        Dim inUDNTRA_tokmstkb As String()
        Dim inUDNTRA_nhsmstkb As String()
        Dim inUDNTRA_tanmstkb As String()
        Dim inUDNTRA_zeirnkkb As String()
        Dim inUDNTRA_hinkb As String()
        Dim inUDNTRA_zeirt As Decimal()
        Dim inUDNTRA_zaikb As String()
        Dim inUDNTRA_mrpkb As String()
        Dim inUDNTRA_hinjunkb As String()
        Dim inUDNTRA_makcd As String()
        Dim inUDNTRA_hinsircd As String()
        Dim inUDNTRA_hinnmmkb As String()
        Dim inUDNTRA_hrtdd As String()
        Dim inUDNTRA_ortdd As String()
        Dim inUDNTRA_znkurikn As Decimal()
        Dim inUDNTRA_zkmurikn As Decimal()
        Dim inUDNTRA_zkmuzekn As Decimal()
        Dim inUDNTRA_motdatno As String()
        Dim inUDNTRA_fopeid As String()
        Dim inUDNTRA_fcltid As String()
        Dim inUDNTRA_wrtfsttm As String()
        Dim inUDNTRA_wrtfstdt As String()
        Dim inUDNTRA_opeid As String()
        Dim inUDNTRA_cltid As String()
        Dim inUDNTRA_wrttm As String()
        Dim inUDNTRA_wrtdt As String()
        Dim inUDNTRA_uopeid As String()
        Dim inUDNTRA_ucltid As String()
        Dim inUDNTRA_uwrttm As String()
        Dim inUDNTRA_uwrtdt As String()
        Dim inUDNTRA_pgid As String()
        Dim inUDNTRA_dlflg As String()
    End Structure
    '2019/04/02 ADD E N D

    '2019/04/03 ADD START
    Private S_UDNTRA As sUDNTRA
    '2019/04/03 ADD E N D

    '2019/04/03 ADD START
    Private Sub SetArrayUDNTRA(ByVal pCnt As Long, ByVal pDB_UDNTRA As TYPE_DB_UDNTRA)
        ReDim Preserve S_UDNTRA.inUDNTRA_datno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_datkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_akakrokb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_denkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_udnno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_linno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zktkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_odnno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_odnlinno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_jdnno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_jdnlinno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_recno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_usdno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_udndt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbsb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbnm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_henrsncd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hensttcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_smadt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_ssadt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_kesdt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tokcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tancd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_nhscd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tokseicd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_soucd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_sbnno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hincd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tokjdnno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinnma(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinnmb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_untcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_untnm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_irisu(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_cassu(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_urisu(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_uritk(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_gnktk(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_siktk(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_furitk(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_urikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_furikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_sikkn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_uzekn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_nyudt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_nyukn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_fnyukn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_gnkkn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_jkesikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_fkesikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_kesikb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_nyukb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tnkid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tukkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_ratert(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_emgodnkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_okrjono(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_invno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_lincma(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_lincmb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_bnkcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_bnknm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tegno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tegdt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_updid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dfldkbcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbzaifl(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbtegfl(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbfla(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbflb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dkbflc(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_lstid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinzeikb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinmstkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tokmstkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_nhsmstkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_tanmstkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zeirnkkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zeirt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zaikb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_mrpkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinjunkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_makcd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinsircd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hinnmmkb(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_hrtdd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_ortdd(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_znkurikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zkmurikn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_zkmuzekn(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_motdatno(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_fopeid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_fcltid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_wrtfsttm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_wrtfstdt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_opeid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_cltid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_wrttm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_wrtdt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_uopeid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_ucltid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_uwrttm(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_uwrtdt(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_pgid(pCnt)
        ReDim Preserve S_UDNTRA.inUDNTRA_dlflg(pCnt)

        S_UDNTRA.inUDNTRA_datno(pCnt) = pDB_UDNTRA.DATNO
        S_UDNTRA.inUDNTRA_datkb(pCnt) = pDB_UDNTRA.DATKB
        S_UDNTRA.inUDNTRA_akakrokb(pCnt) = pDB_UDNTRA.AKAKROKB
        S_UDNTRA.inUDNTRA_denkb(pCnt) = pDB_UDNTRA.DENKB
        S_UDNTRA.inUDNTRA_udnno(pCnt) = pDB_UDNTRA.UDNNO
        S_UDNTRA.inUDNTRA_linno(pCnt) = pDB_UDNTRA.LINNO
        S_UDNTRA.inUDNTRA_zktkb(pCnt) = pDB_UDNTRA.ZKTKB
        S_UDNTRA.inUDNTRA_odnno(pCnt) = pDB_UDNTRA.ODNNO
        S_UDNTRA.inUDNTRA_odnlinno(pCnt) = pDB_UDNTRA.ODNLINNO
        S_UDNTRA.inUDNTRA_jdnno(pCnt) = pDB_UDNTRA.JDNNO
        S_UDNTRA.inUDNTRA_jdnlinno(pCnt) = pDB_UDNTRA.JDNLINNO
        S_UDNTRA.inUDNTRA_recno(pCnt) = pDB_UDNTRA.RECNO
        S_UDNTRA.inUDNTRA_usdno(pCnt) = pDB_UDNTRA.USDNO
        S_UDNTRA.inUDNTRA_udndt(pCnt) = pDB_UDNTRA.UDNDT
        S_UDNTRA.inUDNTRA_dkbsb(pCnt) = pDB_UDNTRA.DKBSB
        S_UDNTRA.inUDNTRA_dkbid(pCnt) = pDB_UDNTRA.DKBID
        S_UDNTRA.inUDNTRA_dkbnm(pCnt) = pDB_UDNTRA.DKBNM
        S_UDNTRA.inUDNTRA_henrsncd(pCnt) = pDB_UDNTRA.HENRSNCD
        S_UDNTRA.inUDNTRA_hensttcd(pCnt) = pDB_UDNTRA.HENSTTCD
        S_UDNTRA.inUDNTRA_smadt(pCnt) = pDB_UDNTRA.SMADT
        S_UDNTRA.inUDNTRA_ssadt(pCnt) = pDB_UDNTRA.SSADT
        S_UDNTRA.inUDNTRA_kesdt(pCnt) = pDB_UDNTRA.KESDT
        S_UDNTRA.inUDNTRA_tokcd(pCnt) = pDB_UDNTRA.TOKCD
        S_UDNTRA.inUDNTRA_tancd(pCnt) = pDB_UDNTRA.TANCD
        S_UDNTRA.inUDNTRA_nhscd(pCnt) = pDB_UDNTRA.NHSCD
        S_UDNTRA.inUDNTRA_tokseicd(pCnt) = pDB_UDNTRA.TOKSEICD
        S_UDNTRA.inUDNTRA_soucd(pCnt) = pDB_UDNTRA.SOUCD
        S_UDNTRA.inUDNTRA_sbnno(pCnt) = pDB_UDNTRA.SBNNO
        S_UDNTRA.inUDNTRA_hincd(pCnt) = pDB_UDNTRA.HINCD
        S_UDNTRA.inUDNTRA_tokjdnno(pCnt) = pDB_UDNTRA.TOKJDNNO
        S_UDNTRA.inUDNTRA_hinnma(pCnt) = pDB_UDNTRA.HINNMA
        S_UDNTRA.inUDNTRA_hinnmb(pCnt) = pDB_UDNTRA.HINNMB
        S_UDNTRA.inUDNTRA_untcd(pCnt) = pDB_UDNTRA.UNTCD
        S_UDNTRA.inUDNTRA_untnm(pCnt) = pDB_UDNTRA.UNTNM
        S_UDNTRA.inUDNTRA_irisu(pCnt) = pDB_UDNTRA.IRISU
        S_UDNTRA.inUDNTRA_cassu(pCnt) = pDB_UDNTRA.CASSU
        S_UDNTRA.inUDNTRA_urisu(pCnt) = pDB_UDNTRA.URISU
        S_UDNTRA.inUDNTRA_uritk(pCnt) = pDB_UDNTRA.URITK
        S_UDNTRA.inUDNTRA_gnktk(pCnt) = pDB_UDNTRA.GNKTK
        S_UDNTRA.inUDNTRA_siktk(pCnt) = pDB_UDNTRA.SIKTK
        S_UDNTRA.inUDNTRA_furitk(pCnt) = pDB_UDNTRA.FURITK
        S_UDNTRA.inUDNTRA_urikn(pCnt) = pDB_UDNTRA.URIKN
        S_UDNTRA.inUDNTRA_furikn(pCnt) = pDB_UDNTRA.FURIKN
        S_UDNTRA.inUDNTRA_sikkn(pCnt) = pDB_UDNTRA.SIKKN
        S_UDNTRA.inUDNTRA_uzekn(pCnt) = pDB_UDNTRA.UZEKN
        S_UDNTRA.inUDNTRA_nyudt(pCnt) = pDB_UDNTRA.NYUDT
        S_UDNTRA.inUDNTRA_nyukn(pCnt) = pDB_UDNTRA.NYUKN
        S_UDNTRA.inUDNTRA_fnyukn(pCnt) = pDB_UDNTRA.FNYUKN
        S_UDNTRA.inUDNTRA_gnkkn(pCnt) = pDB_UDNTRA.GNKKN
        S_UDNTRA.inUDNTRA_jkesikn(pCnt) = pDB_UDNTRA.JKESIKN
        S_UDNTRA.inUDNTRA_fkesikn(pCnt) = pDB_UDNTRA.FKESIKN
        S_UDNTRA.inUDNTRA_kesikb(pCnt) = pDB_UDNTRA.KESIKB
        S_UDNTRA.inUDNTRA_nyukb(pCnt) = pDB_UDNTRA.NYUKB
        S_UDNTRA.inUDNTRA_tnkid(pCnt) = pDB_UDNTRA.TNKID
        S_UDNTRA.inUDNTRA_tukkb(pCnt) = pDB_UDNTRA.TUKKB
        S_UDNTRA.inUDNTRA_ratert(pCnt) = pDB_UDNTRA.RATERT
        S_UDNTRA.inUDNTRA_emgodnkb(pCnt) = pDB_UDNTRA.EMGODNKB
        S_UDNTRA.inUDNTRA_okrjono(pCnt) = pDB_UDNTRA.OKRJONO
        S_UDNTRA.inUDNTRA_invno(pCnt) = pDB_UDNTRA.INVNO
        S_UDNTRA.inUDNTRA_lincma(pCnt) = pDB_UDNTRA.LINCMA
        S_UDNTRA.inUDNTRA_lincmb(pCnt) = pDB_UDNTRA.LINCMB
        S_UDNTRA.inUDNTRA_bnkcd(pCnt) = pDB_UDNTRA.BNKCD
        S_UDNTRA.inUDNTRA_bnknm(pCnt) = pDB_UDNTRA.BNKNM
        S_UDNTRA.inUDNTRA_tegno(pCnt) = pDB_UDNTRA.TEGNO
        S_UDNTRA.inUDNTRA_tegdt(pCnt) = pDB_UDNTRA.TEGDT
        S_UDNTRA.inUDNTRA_updid(pCnt) = pDB_UDNTRA.UPDID
        S_UDNTRA.inUDNTRA_dfldkbcd(pCnt) = pDB_UDNTRA.DFLDKBCD
        S_UDNTRA.inUDNTRA_dkbzaifl(pCnt) = pDB_UDNTRA.DKBZAIFL
        S_UDNTRA.inUDNTRA_dkbtegfl(pCnt) = pDB_UDNTRA.DKBTEGFL
        S_UDNTRA.inUDNTRA_dkbfla(pCnt) = pDB_UDNTRA.DKBFLA
        S_UDNTRA.inUDNTRA_dkbflb(pCnt) = pDB_UDNTRA.DKBFLB
        S_UDNTRA.inUDNTRA_dkbflc(pCnt) = pDB_UDNTRA.DKBFLC
        S_UDNTRA.inUDNTRA_lstid(pCnt) = pDB_UDNTRA.LSTID
        S_UDNTRA.inUDNTRA_hinzeikb(pCnt) = pDB_UDNTRA.HINZEIKB
        S_UDNTRA.inUDNTRA_hinmstkb(pCnt) = pDB_UDNTRA.HINMSTKB
        S_UDNTRA.inUDNTRA_tokmstkb(pCnt) = pDB_UDNTRA.TOKMSTKB
        S_UDNTRA.inUDNTRA_nhsmstkb(pCnt) = pDB_UDNTRA.NHSMSTKB
        S_UDNTRA.inUDNTRA_tanmstkb(pCnt) = pDB_UDNTRA.TANMSTKB
        S_UDNTRA.inUDNTRA_zeirnkkb(pCnt) = pDB_UDNTRA.ZEIRNKKB
        S_UDNTRA.inUDNTRA_hinkb(pCnt) = pDB_UDNTRA.HINKB
        S_UDNTRA.inUDNTRA_zeirt(pCnt) = pDB_UDNTRA.ZEIRT
        S_UDNTRA.inUDNTRA_zaikb(pCnt) = pDB_UDNTRA.ZAIKB
        S_UDNTRA.inUDNTRA_mrpkb(pCnt) = pDB_UDNTRA.MRPKB
        S_UDNTRA.inUDNTRA_hinjunkb(pCnt) = pDB_UDNTRA.HINJUNKB
        S_UDNTRA.inUDNTRA_makcd(pCnt) = pDB_UDNTRA.MAKCD
        S_UDNTRA.inUDNTRA_hinsircd(pCnt) = pDB_UDNTRA.HINSIRCD
        S_UDNTRA.inUDNTRA_hinnmmkb(pCnt) = pDB_UDNTRA.HINNMMKB
        S_UDNTRA.inUDNTRA_hrtdd(pCnt) = pDB_UDNTRA.HRTDD
        S_UDNTRA.inUDNTRA_ortdd(pCnt) = pDB_UDNTRA.ORTDD
        S_UDNTRA.inUDNTRA_znkurikn(pCnt) = pDB_UDNTRA.ZNKURIKN
        S_UDNTRA.inUDNTRA_zkmurikn(pCnt) = pDB_UDNTRA.ZKMURIKN
        S_UDNTRA.inUDNTRA_zkmuzekn(pCnt) = pDB_UDNTRA.ZKMUZEKN
        S_UDNTRA.inUDNTRA_motdatno(pCnt) = pDB_UDNTRA.MOTDATNO
        S_UDNTRA.inUDNTRA_fopeid(pCnt) = pDB_UDNTRA.FOPEID
        S_UDNTRA.inUDNTRA_fcltid(pCnt) = pDB_UDNTRA.FCLTID
        S_UDNTRA.inUDNTRA_wrtfsttm(pCnt) = pDB_UDNTRA.WRTFSTTM
        S_UDNTRA.inUDNTRA_wrtfstdt(pCnt) = pDB_UDNTRA.WRTFSTDT
        S_UDNTRA.inUDNTRA_opeid(pCnt) = pDB_UDNTRA.OPEID
        S_UDNTRA.inUDNTRA_cltid(pCnt) = pDB_UDNTRA.CLTID
        S_UDNTRA.inUDNTRA_wrttm(pCnt) = pDB_UDNTRA.WRTTM
        S_UDNTRA.inUDNTRA_wrtdt(pCnt) = pDB_UDNTRA.WRTDT
        S_UDNTRA.inUDNTRA_uopeid(pCnt) = pDB_UDNTRA.UOPEID
        S_UDNTRA.inUDNTRA_ucltid(pCnt) = pDB_UDNTRA.UCLTID
        S_UDNTRA.inUDNTRA_uwrttm(pCnt) = pDB_UDNTRA.UWRTTM
        S_UDNTRA.inUDNTRA_uwrtdt(pCnt) = pDB_UDNTRA.UWRTDT
        S_UDNTRA.inUDNTRA_pgid(pCnt) = pDB_UDNTRA.PGID
        S_UDNTRA.inUDNTRA_dlflg(pCnt) = pDB_UDNTRA.DLFLG
    End Sub
    '2019/04/03 ADD E N D
 
    '2019/04/02 ADD START
    Private Sub SetPlsqlParamUDNTHA(ByVal pCmd As OracleCommand, ByVal pDB_UDNTHA As TYPE_DB_UDNTHA)
        'udntha arrsize
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_ArrSize", OracleDbType.Int32, ParameterDirection.Input))

        pCmd.Parameters("inUDNTHA_ArrSize").Value = 1

        '----------

        'udntha add param
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_datno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_datkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_akakrokb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_denkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_udnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_fdnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_jdnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_usdno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_udndt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_dendt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_regdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokrn", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhscd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsrn", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsnma", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsnmb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tancd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tannm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_bumcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_bumnm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokseicd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_soucd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sounm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nxtkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nxtnm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_emgodnkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_okrjono", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_invno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_smadt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_ssadt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_kesdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nyucd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_zktkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_zktnm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_kennma", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_kennmb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsada", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsadb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsadc", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_maeuknm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_keibumcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_upfkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbaurikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbauzekn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbauzkkn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbafrukn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbanyukn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_sbafrnkn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_dencm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_dencmin", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_toksmekb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_toksmedd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_toksmecc", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_toksdwkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokkescc", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokkesdd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokkdwkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_lstid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokjunkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tknrpskb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tknzrnkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokzeikb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokzclkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokrpskb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tokzrnkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_toknmmkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_nhsnmmkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tanmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_urikjn", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_maeukkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_seikb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_jdntrkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_tukkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_frnkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_udnprakb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_udnprbkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_motdatno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_fopeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_fcltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_wrtfsttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_wrtfstdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_opeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_cltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_wrttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_wrtdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_uopeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_ucltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_uwrttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_uwrtdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_pgid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTHA_dlflg", OracleDbType.Char, ParameterDirection.Input))

        'udntha set param
        pCmd.Parameters("inUDNTHA_datno").Value = pDB_UDNTHA.DATNO
        pCmd.Parameters("inUDNTHA_datkb").Value = pDB_UDNTHA.DATKB
        pCmd.Parameters("inUDNTHA_akakrokb").Value = pDB_UDNTHA.AKAKROKB
        pCmd.Parameters("inUDNTHA_denkb").Value = pDB_UDNTHA.DENKB
        pCmd.Parameters("inUDNTHA_udnno").Value = pDB_UDNTHA.UDNNO
        pCmd.Parameters("inUDNTHA_fdnno").Value = pDB_UDNTHA.FDNNO
        pCmd.Parameters("inUDNTHA_jdnno").Value = pDB_UDNTHA.JDNNO
        pCmd.Parameters("inUDNTHA_usdno").Value = pDB_UDNTHA.USDNO
        pCmd.Parameters("inUDNTHA_udndt").Value = pDB_UDNTHA.UDNDT
        pCmd.Parameters("inUDNTHA_dendt").Value = pDB_UDNTHA.DENDT
        pCmd.Parameters("inUDNTHA_regdt").Value = pDB_UDNTHA.REGDT
        pCmd.Parameters("inUDNTHA_tokcd").Value = pDB_UDNTHA.TOKCD
        pCmd.Parameters("inUDNTHA_tokrn").Value = pDB_UDNTHA.TOKRN
        pCmd.Parameters("inUDNTHA_nhscd").Value = pDB_UDNTHA.NHSCD
        pCmd.Parameters("inUDNTHA_nhsrn").Value = pDB_UDNTHA.NHSRN
        pCmd.Parameters("inUDNTHA_nhsnma").Value = pDB_UDNTHA.NHSNMA
        pCmd.Parameters("inUDNTHA_nhsnmb").Value = pDB_UDNTHA.NHSNMB
        pCmd.Parameters("inUDNTHA_tancd").Value = pDB_UDNTHA.TANCD
        pCmd.Parameters("inUDNTHA_tannm").Value = pDB_UDNTHA.TANNM
        pCmd.Parameters("inUDNTHA_bumcd").Value = pDB_UDNTHA.BUMCD
        pCmd.Parameters("inUDNTHA_bumnm").Value = pDB_UDNTHA.BUMNM
        pCmd.Parameters("inUDNTHA_tokseicd").Value = pDB_UDNTHA.TOKSEICD
        pCmd.Parameters("inUDNTHA_soucd").Value = pDB_UDNTHA.SOUCD
        pCmd.Parameters("inUDNTHA_sounm").Value = pDB_UDNTHA.SOUNM
        pCmd.Parameters("inUDNTHA_nxtkb").Value = pDB_UDNTHA.NXTKB
        pCmd.Parameters("inUDNTHA_nxtnm").Value = pDB_UDNTHA.NXTNM
        pCmd.Parameters("inUDNTHA_emgodnkb").Value = pDB_UDNTHA.EMGODNKB
        pCmd.Parameters("inUDNTHA_okrjono").Value = pDB_UDNTHA.OKRJONO
        pCmd.Parameters("inUDNTHA_invno").Value = pDB_UDNTHA.INVNO
        pCmd.Parameters("inUDNTHA_smadt").Value = pDB_UDNTHA.SMADT
        pCmd.Parameters("inUDNTHA_ssadt").Value = pDB_UDNTHA.SSADT
        pCmd.Parameters("inUDNTHA_kesdt").Value = pDB_UDNTHA.KESDT
        pCmd.Parameters("inUDNTHA_nyucd").Value = pDB_UDNTHA.NYUCD
        pCmd.Parameters("inUDNTHA_zktkb").Value = pDB_UDNTHA.ZKTKB
        pCmd.Parameters("inUDNTHA_zktnm").Value = pDB_UDNTHA.ZKTNM
        pCmd.Parameters("inUDNTHA_kennma").Value = pDB_UDNTHA.KENNMA
        pCmd.Parameters("inUDNTHA_kennmb").Value = pDB_UDNTHA.KENNMB
        pCmd.Parameters("inUDNTHA_nhsada").Value = pDB_UDNTHA.NHSADA
        pCmd.Parameters("inUDNTHA_nhsadb").Value = pDB_UDNTHA.NHSADB
        pCmd.Parameters("inUDNTHA_nhsadc").Value = pDB_UDNTHA.NHSADC
        pCmd.Parameters("inUDNTHA_maeuknm").Value = pDB_UDNTHA.MAEUKNM
        pCmd.Parameters("inUDNTHA_keibumcd").Value = pDB_UDNTHA.KEIBUMCD
        pCmd.Parameters("inUDNTHA_upfkb").Value = pDB_UDNTHA.UPFKB
        pCmd.Parameters("inUDNTHA_sbaurikn").Value = pDB_UDNTHA.SBAURIKN    'NUMBER
        pCmd.Parameters("inUDNTHA_sbauzekn").Value = pDB_UDNTHA.SBAUZEKN    'NUMBER
        pCmd.Parameters("inUDNTHA_sbauzkkn").Value = pDB_UDNTHA.SBAUZKKN    'NUMBER
        pCmd.Parameters("inUDNTHA_sbafrukn").Value = pDB_UDNTHA.SBAFRUKN    'NUMBER
        pCmd.Parameters("inUDNTHA_sbanyukn").Value = pDB_UDNTHA.SBANYUKN    'NUMBER
        pCmd.Parameters("inUDNTHA_sbafrnkn").Value = pDB_UDNTHA.SBAFRNKN    'NUMBER
        pCmd.Parameters("inUDNTHA_dencm").Value = pDB_UDNTHA.DENCM
        pCmd.Parameters("inUDNTHA_dencmin").Value = pDB_UDNTHA.DENCMIN
        pCmd.Parameters("inUDNTHA_toksmekb").Value = pDB_UDNTHA.TOKSMEKB
        pCmd.Parameters("inUDNTHA_toksmedd").Value = pDB_UDNTHA.TOKSMEDD
        pCmd.Parameters("inUDNTHA_toksmecc").Value = pDB_UDNTHA.TOKSMECC
        pCmd.Parameters("inUDNTHA_toksdwkb").Value = pDB_UDNTHA.TOKSDWKB
        pCmd.Parameters("inUDNTHA_tokkescc").Value = pDB_UDNTHA.TOKKESCC
        pCmd.Parameters("inUDNTHA_tokkesdd").Value = pDB_UDNTHA.TOKKESDD
        pCmd.Parameters("inUDNTHA_tokkdwkb").Value = pDB_UDNTHA.TOKKDWKB
        pCmd.Parameters("inUDNTHA_lstid").Value = pDB_UDNTHA.LSTID
        pCmd.Parameters("inUDNTHA_tokjunkb").Value = pDB_UDNTHA.TOKJUNKB
        pCmd.Parameters("inUDNTHA_tokmstkb").Value = pDB_UDNTHA.TOKMSTKB
        pCmd.Parameters("inUDNTHA_tknrpskb").Value = pDB_UDNTHA.TKNRPSKB
        pCmd.Parameters("inUDNTHA_tknzrnkb").Value = pDB_UDNTHA.TKNZRNKB
        pCmd.Parameters("inUDNTHA_tokzeikb").Value = pDB_UDNTHA.TOKZEIKB
        pCmd.Parameters("inUDNTHA_tokzclkb").Value = pDB_UDNTHA.TOKZCLKB
        pCmd.Parameters("inUDNTHA_tokrpskb").Value = pDB_UDNTHA.TOKRPSKB
        pCmd.Parameters("inUDNTHA_tokzrnkb").Value = pDB_UDNTHA.TOKZRNKB
        pCmd.Parameters("inUDNTHA_toknmmkb").Value = pDB_UDNTHA.TOKNMMKB
        pCmd.Parameters("inUDNTHA_nhsmstkb").Value = pDB_UDNTHA.NHSMSTKB
        pCmd.Parameters("inUDNTHA_nhsnmmkb").Value = pDB_UDNTHA.NHSNMMKB
        pCmd.Parameters("inUDNTHA_tanmstkb").Value = pDB_UDNTHA.TANMSTKB
        pCmd.Parameters("inUDNTHA_urikjn").Value = pDB_UDNTHA.URIKJN
        pCmd.Parameters("inUDNTHA_maeukkb").Value = pDB_UDNTHA.MAEUKKB
        pCmd.Parameters("inUDNTHA_seikb").Value = pDB_UDNTHA.SEIKB
        pCmd.Parameters("inUDNTHA_jdntrkb").Value = pDB_UDNTHA.JDNTRKB
        pCmd.Parameters("inUDNTHA_tukkb").Value = pDB_UDNTHA.TUKKB
        pCmd.Parameters("inUDNTHA_frnkb").Value = pDB_UDNTHA.FRNKB
        pCmd.Parameters("inUDNTHA_udnprakb").Value = pDB_UDNTHA.UDNPRAKB
        pCmd.Parameters("inUDNTHA_udnprbkb").Value = pDB_UDNTHA.UDNPRBKB
        pCmd.Parameters("inUDNTHA_motdatno").Value = pDB_UDNTHA.MOTDATNO
        pCmd.Parameters("inUDNTHA_fopeid").Value = pDB_UDNTHA.FOPEID
        pCmd.Parameters("inUDNTHA_fcltid").Value = pDB_UDNTHA.FCLTID
        pCmd.Parameters("inUDNTHA_wrtfsttm").Value = pDB_UDNTHA.WRTFSTTM
        pCmd.Parameters("inUDNTHA_wrtfstdt").Value = pDB_UDNTHA.WRTFSTDT
        pCmd.Parameters("inUDNTHA_opeid").Value = pDB_UDNTHA.OPEID
        pCmd.Parameters("inUDNTHA_cltid").Value = pDB_UDNTHA.CLTID
        pCmd.Parameters("inUDNTHA_wrttm").Value = pDB_UDNTHA.WRTTM
        pCmd.Parameters("inUDNTHA_wrtdt").Value = pDB_UDNTHA.WRTDT
        pCmd.Parameters("inUDNTHA_uopeid").Value = pDB_UDNTHA.UOPEID
        pCmd.Parameters("inUDNTHA_ucltid").Value = pDB_UDNTHA.UCLTID
        pCmd.Parameters("inUDNTHA_uwrttm").Value = pDB_UDNTHA.UWRTTM
        pCmd.Parameters("inUDNTHA_uwrtdt").Value = pDB_UDNTHA.UWRTDT
        pCmd.Parameters("inUDNTHA_pgid").Value = pDB_UDNTHA.PGID
        pCmd.Parameters("inUDNTHA_dlflg").Value = pDB_UDNTHA.DLFLG
    End Sub
    '2019/04/02 ADD E N D

    '2019/04/02 ADD START
    Private Sub SetPlsqlParamUDNTRA(ByVal pCmd As OracleCommand)
        'udntra arrsize
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_ArrSize", OracleDbType.Int32, ParameterDirection.Input))

        pCmd.Parameters("inUDNTRA_ArrSize").Value = S_UDNTRA.inUDNTRA_datno.Length

        '----------

        'udntra add param
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_datno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_datkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_akakrokb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_denkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_udnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_linno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zktkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_odnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_odnlinno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_jdnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_jdnlinno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_recno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_usdno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_udndt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbsb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbnm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_henrsncd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hensttcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_smadt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_ssadt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_kesdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tokcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tancd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_nhscd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tokseicd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_soucd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_sbnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hincd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tokjdnno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinnma", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinnmb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_untcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_untnm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_irisu", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_cassu", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_urisu", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_uritk", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_gnktk", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_siktk", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_furitk", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_urikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_furikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_sikkn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_uzekn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_nyudt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_nyukn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_fnyukn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_gnkkn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_jkesikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_fkesikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_kesikb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_nyukb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tnkid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tukkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_ratert", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_emgodnkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_okrjono", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_invno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_lincma", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_lincmb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_bnkcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_bnknm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tegno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tegdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_updid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dfldkbcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbzaifl", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbtegfl", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbfla", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbflb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dkbflc", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_lstid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinzeikb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tokmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_nhsmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_tanmstkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zeirnkkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zeirt", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zaikb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_mrpkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinjunkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_makcd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinsircd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hinnmmkb", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_hrtdd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_ortdd", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_znkurikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zkmurikn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_zkmuzekn", OracleDbType.Decimal, ParameterDirection.Input))    'NUMBER
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_motdatno", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_fopeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_fcltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_wrtfsttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_wrtfstdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_opeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_cltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_wrttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_wrtdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_uopeid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_ucltid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_uwrttm", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_uwrtdt", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_pgid", OracleDbType.Char, ParameterDirection.Input))
        pCmd.Parameters.Add(New OracleParameter("inUDNTRA_dlflg", OracleDbType.Char, ParameterDirection.Input))

        '配列
        ' PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_datno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_datkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_akakrokb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_denkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_udnno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_linno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zktkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_odnno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_odnlinno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_jdnno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_jdnlinno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_recno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_usdno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_udndt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbsb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbnm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_henrsncd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hensttcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_smadt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_ssadt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_kesdt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tokcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tancd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_nhscd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tokseicd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_soucd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_sbnno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hincd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tokjdnno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinnma").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinnmb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_untcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_untnm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_irisu").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_cassu").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_urisu").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_uritk").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_gnktk").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_siktk").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_furitk").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_urikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_furikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_sikkn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_uzekn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_nyudt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_nyukn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_fnyukn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_gnkkn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_jkesikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_fkesikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_kesikb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_nyukb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tnkid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tukkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_ratert").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_emgodnkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_okrjono").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_invno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_lincma").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_lincmb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_bnkcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_bnknm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tegno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tegdt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_updid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dfldkbcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbzaifl").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbtegfl").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbfla").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbflb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dkbflc").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_lstid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinzeikb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinmstkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tokmstkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_nhsmstkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_tanmstkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zeirnkkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zeirt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zaikb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_mrpkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinjunkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_makcd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinsircd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hinnmmkb").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_hrtdd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_ortdd").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_znkurikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zkmurikn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_zkmuzekn").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_motdatno").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_fopeid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_fcltid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_wrtfsttm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_wrtfstdt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_opeid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_cltid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_wrttm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_wrtdt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_uopeid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_ucltid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_uwrttm").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_uwrtdt").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_pgid").CollectionType = OracleCollectionType.PLSQLAssociativeArray
        pCmd.Parameters("inUDNTRA_dlflg").CollectionType = OracleCollectionType.PLSQLAssociativeArray

        ' size
        pCmd.Parameters("inUDNTRA_datno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_datkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_akakrokb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_denkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_udnno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_linno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zktkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_odnno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_odnlinno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_jdnno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_jdnlinno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_recno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_usdno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_udndt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbsb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbnm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_henrsncd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hensttcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_smadt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_ssadt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_kesdt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tokcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tancd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_nhscd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tokseicd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_soucd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_sbnno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hincd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tokjdnno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinnma").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinnmb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_untcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_untnm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_irisu").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_cassu").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_urisu").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_uritk").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_gnktk").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_siktk").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_furitk").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_urikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_furikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_sikkn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_uzekn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_nyudt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_nyukn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_fnyukn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_gnkkn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_jkesikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_fkesikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_kesikb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_nyukb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tnkid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tukkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_ratert").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_emgodnkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_okrjono").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_invno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_lincma").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_lincmb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_bnkcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_bnknm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tegno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tegdt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_updid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dfldkbcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbzaifl").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbtegfl").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbfla").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbflb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dkbflc").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_lstid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinzeikb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinmstkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tokmstkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_nhsmstkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_tanmstkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zeirnkkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zeirt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zaikb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_mrpkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinjunkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_makcd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinsircd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hinnmmkb").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_hrtdd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_ortdd").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_znkurikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zkmurikn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_zkmuzekn").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_motdatno").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_fopeid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_fcltid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_wrtfsttm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_wrtfstdt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_opeid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_cltid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_wrttm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_wrtdt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_uopeid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_ucltid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_uwrttm").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_uwrtdt").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_pgid").Size = S_UDNTRA.inUDNTRA_datno.Length
        pCmd.Parameters("inUDNTRA_dlflg").Size = S_UDNTRA.inUDNTRA_datno.Length

        ' array bind size
        pCmd.Parameters("inUDNTRA_datno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_datkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_akakrokb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_denkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_udnno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_linno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zktkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_odnno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_odnlinno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_jdnno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_jdnlinno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_recno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_usdno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_udndt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbsb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbnm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_henrsncd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hensttcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_smadt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_ssadt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_kesdt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tokcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tancd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_nhscd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tokseicd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_soucd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_sbnno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hincd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tokjdnno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinnma").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinnmb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_untcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_untnm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_irisu").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_cassu").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_urisu").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_uritk").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_gnktk").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_siktk").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_furitk").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_urikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_furikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_sikkn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_uzekn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_nyudt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_nyukn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_fnyukn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_gnkkn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_jkesikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_fkesikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_kesikb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_nyukb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tnkid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tukkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_ratert").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_emgodnkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_okrjono").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_invno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_lincma").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_lincmb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_bnkcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_bnknm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tegno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tegdt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_updid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dfldkbcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbzaifl").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbtegfl").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbfla").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbflb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dkbflc").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_lstid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinzeikb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinmstkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tokmstkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_nhsmstkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_tanmstkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zeirnkkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zeirt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zaikb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_mrpkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinjunkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_makcd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinsircd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hinnmmkb").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_hrtdd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_ortdd").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_znkurikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zkmurikn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_zkmuzekn").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_motdatno").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_fopeid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_fcltid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_wrtfsttm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_wrtfstdt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_opeid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_cltid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_wrttm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_wrtdt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_uopeid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_ucltid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_uwrttm").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_uwrtdt").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_pgid").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}
        pCmd.Parameters("inUDNTRA_dlflg").ArrayBindSize = New Integer(S_UDNTRA.inUDNTRA_datno.Length - 1) {}

        'udntra set ArrayBindSize
        For i As Integer = 0 To S_UDNTRA.inUDNTRA_datno.Length - 1
            pCmd.Parameters("inUDNTRA_datno").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_datkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_akakrokb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_denkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_udnno").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_linno").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_zktkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_odnno").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_odnlinno").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_jdnno").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_jdnlinno").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_recno").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_usdno").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_udndt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_dkbsb").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_dkbid").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_dkbnm").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_henrsncd").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_hensttcd").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_smadt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_ssadt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_kesdt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_tokcd").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_tancd").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_nhscd").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_tokseicd").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_soucd").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_sbnno").ArrayBindSize(i) = 20
            pCmd.Parameters("inUDNTRA_hincd").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_tokjdnno").ArrayBindSize(i) = 23
            pCmd.Parameters("inUDNTRA_hinnma").ArrayBindSize(i) = 50
            pCmd.Parameters("inUDNTRA_hinnmb").ArrayBindSize(i) = 50
            pCmd.Parameters("inUDNTRA_untcd").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_untnm").ArrayBindSize(i) = 4
            pCmd.Parameters("inUDNTRA_irisu").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_cassu").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_urisu").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_uritk").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_gnktk").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_siktk").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_furitk").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_urikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_furikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_sikkn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_uzekn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_nyudt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_nyukn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_fnyukn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_gnkkn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_jkesikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_fkesikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_kesikb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_nyukb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_tnkid").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_tukkb").ArrayBindSize(i) = 3
            pCmd.Parameters("inUDNTRA_ratert").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_emgodnkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_okrjono").ArrayBindSize(i) = 15
            pCmd.Parameters("inUDNTRA_invno").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_lincma").ArrayBindSize(i) = 20
            pCmd.Parameters("inUDNTRA_lincmb").ArrayBindSize(i) = 20
            pCmd.Parameters("inUDNTRA_bnkcd").ArrayBindSize(i) = 7
            pCmd.Parameters("inUDNTRA_bnknm").ArrayBindSize(i) = 50
            pCmd.Parameters("inUDNTRA_tegno").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_tegdt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_updid").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_dfldkbcd").ArrayBindSize(i) = 13
            pCmd.Parameters("inUDNTRA_dkbzaifl").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_dkbtegfl").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_dkbfla").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_dkbflb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_dkbflc").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_lstid").ArrayBindSize(i) = 7
            pCmd.Parameters("inUDNTRA_hinzeikb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_hinmstkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_tokmstkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_nhsmstkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_tanmstkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_zeirnkkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_hinkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_zeirt").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_zaikb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_mrpkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_hinjunkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_makcd").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_hinsircd").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_hinnmmkb").ArrayBindSize(i) = 1
            pCmd.Parameters("inUDNTRA_hrtdd").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_ortdd").ArrayBindSize(i) = 2
            pCmd.Parameters("inUDNTRA_znkurikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_zkmurikn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_zkmuzekn").ArrayBindSize(i) = 22
            pCmd.Parameters("inUDNTRA_motdatno").ArrayBindSize(i) = 10
            pCmd.Parameters("inUDNTRA_fopeid").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_fcltid").ArrayBindSize(i) = 5
            pCmd.Parameters("inUDNTRA_wrtfsttm").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_wrtfstdt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_opeid").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_cltid").ArrayBindSize(i) = 5
            pCmd.Parameters("inUDNTRA_wrttm").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_wrtdt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_uopeid").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_ucltid").ArrayBindSize(i) = 5
            pCmd.Parameters("inUDNTRA_uwrttm").ArrayBindSize(i) = 6
            pCmd.Parameters("inUDNTRA_uwrtdt").ArrayBindSize(i) = 8
            pCmd.Parameters("inUDNTRA_pgid").ArrayBindSize(i) = 7
            pCmd.Parameters("inUDNTRA_dlflg").ArrayBindSize(i) = 1
        Next

        'udntra set value
        pCmd.Parameters("inUDNTRA_datno").Value = S_UDNTRA.inUDNTRA_datno
        pCmd.Parameters("inUDNTRA_datkb").Value = S_UDNTRA.inUDNTRA_datkb
        pCmd.Parameters("inUDNTRA_akakrokb").Value = S_UDNTRA.inUDNTRA_akakrokb
        pCmd.Parameters("inUDNTRA_denkb").Value = S_UDNTRA.inUDNTRA_denkb
        pCmd.Parameters("inUDNTRA_udnno").Value = S_UDNTRA.inUDNTRA_udnno
        pCmd.Parameters("inUDNTRA_linno").Value = S_UDNTRA.inUDNTRA_linno
        pCmd.Parameters("inUDNTRA_zktkb").Value = S_UDNTRA.inUDNTRA_zktkb
        pCmd.Parameters("inUDNTRA_odnno").Value = S_UDNTRA.inUDNTRA_odnno
        pCmd.Parameters("inUDNTRA_odnlinno").Value = S_UDNTRA.inUDNTRA_odnlinno
        pCmd.Parameters("inUDNTRA_jdnno").Value = S_UDNTRA.inUDNTRA_jdnno
        pCmd.Parameters("inUDNTRA_jdnlinno").Value = S_UDNTRA.inUDNTRA_jdnlinno
        pCmd.Parameters("inUDNTRA_recno").Value = S_UDNTRA.inUDNTRA_recno
        pCmd.Parameters("inUDNTRA_usdno").Value = S_UDNTRA.inUDNTRA_usdno
        pCmd.Parameters("inUDNTRA_udndt").Value = S_UDNTRA.inUDNTRA_udndt
        pCmd.Parameters("inUDNTRA_dkbsb").Value = S_UDNTRA.inUDNTRA_dkbsb
        pCmd.Parameters("inUDNTRA_dkbid").Value = S_UDNTRA.inUDNTRA_dkbid
        pCmd.Parameters("inUDNTRA_dkbnm").Value = S_UDNTRA.inUDNTRA_dkbnm
        pCmd.Parameters("inUDNTRA_henrsncd").Value = S_UDNTRA.inUDNTRA_henrsncd
        pCmd.Parameters("inUDNTRA_hensttcd").Value = S_UDNTRA.inUDNTRA_hensttcd
        pCmd.Parameters("inUDNTRA_smadt").Value = S_UDNTRA.inUDNTRA_smadt
        pCmd.Parameters("inUDNTRA_ssadt").Value = S_UDNTRA.inUDNTRA_ssadt
        pCmd.Parameters("inUDNTRA_kesdt").Value = S_UDNTRA.inUDNTRA_kesdt
        pCmd.Parameters("inUDNTRA_tokcd").Value = S_UDNTRA.inUDNTRA_tokcd
        pCmd.Parameters("inUDNTRA_tancd").Value = S_UDNTRA.inUDNTRA_tancd
        pCmd.Parameters("inUDNTRA_nhscd").Value = S_UDNTRA.inUDNTRA_nhscd
        pCmd.Parameters("inUDNTRA_tokseicd").Value = S_UDNTRA.inUDNTRA_tokseicd
        pCmd.Parameters("inUDNTRA_soucd").Value = S_UDNTRA.inUDNTRA_soucd
        pCmd.Parameters("inUDNTRA_sbnno").Value = S_UDNTRA.inUDNTRA_sbnno
        pCmd.Parameters("inUDNTRA_hincd").Value = S_UDNTRA.inUDNTRA_hincd
        pCmd.Parameters("inUDNTRA_tokjdnno").Value = S_UDNTRA.inUDNTRA_tokjdnno
        pCmd.Parameters("inUDNTRA_hinnma").Value = S_UDNTRA.inUDNTRA_hinnma
        pCmd.Parameters("inUDNTRA_hinnmb").Value = S_UDNTRA.inUDNTRA_hinnmb
        pCmd.Parameters("inUDNTRA_untcd").Value = S_UDNTRA.inUDNTRA_untcd
        pCmd.Parameters("inUDNTRA_untnm").Value = S_UDNTRA.inUDNTRA_untnm
        pCmd.Parameters("inUDNTRA_irisu").Value = S_UDNTRA.inUDNTRA_irisu   'NUMBER
        pCmd.Parameters("inUDNTRA_cassu").Value = S_UDNTRA.inUDNTRA_cassu   'NUMBER
        pCmd.Parameters("inUDNTRA_urisu").Value = S_UDNTRA.inUDNTRA_urisu   'NUMBER
        pCmd.Parameters("inUDNTRA_uritk").Value = S_UDNTRA.inUDNTRA_uritk   'NUMBER
        pCmd.Parameters("inUDNTRA_gnktk").Value = S_UDNTRA.inUDNTRA_gnktk   'NUMBER
        pCmd.Parameters("inUDNTRA_siktk").Value = S_UDNTRA.inUDNTRA_siktk   'NUMBER
        pCmd.Parameters("inUDNTRA_furitk").Value = S_UDNTRA.inUDNTRA_furitk   'NUMBER
        pCmd.Parameters("inUDNTRA_urikn").Value = S_UDNTRA.inUDNTRA_urikn   'NUMBER
        pCmd.Parameters("inUDNTRA_furikn").Value = S_UDNTRA.inUDNTRA_furikn   'NUMBER
        pCmd.Parameters("inUDNTRA_sikkn").Value = S_UDNTRA.inUDNTRA_sikkn   'NUMBER
        pCmd.Parameters("inUDNTRA_uzekn").Value = S_UDNTRA.inUDNTRA_uzekn   'NUMBER
        pCmd.Parameters("inUDNTRA_nyudt").Value = S_UDNTRA.inUDNTRA_nyudt
        pCmd.Parameters("inUDNTRA_nyukn").Value = S_UDNTRA.inUDNTRA_nyukn   'NUMBER
        pCmd.Parameters("inUDNTRA_fnyukn").Value = S_UDNTRA.inUDNTRA_fnyukn   'NUMBER
        pCmd.Parameters("inUDNTRA_gnkkn").Value = S_UDNTRA.inUDNTRA_gnkkn   'NUMBER
        pCmd.Parameters("inUDNTRA_jkesikn").Value = S_UDNTRA.inUDNTRA_jkesikn   'NUMBER
        pCmd.Parameters("inUDNTRA_fkesikn").Value = S_UDNTRA.inUDNTRA_fkesikn   'NUMBER
        pCmd.Parameters("inUDNTRA_kesikb").Value = S_UDNTRA.inUDNTRA_kesikb
        pCmd.Parameters("inUDNTRA_nyukb").Value = S_UDNTRA.inUDNTRA_nyukb
        pCmd.Parameters("inUDNTRA_tnkid").Value = S_UDNTRA.inUDNTRA_tnkid
        pCmd.Parameters("inUDNTRA_tukkb").Value = S_UDNTRA.inUDNTRA_tukkb
        pCmd.Parameters("inUDNTRA_ratert").Value = S_UDNTRA.inUDNTRA_ratert   'NUMBER
        pCmd.Parameters("inUDNTRA_emgodnkb").Value = S_UDNTRA.inUDNTRA_emgodnkb
        pCmd.Parameters("inUDNTRA_okrjono").Value = S_UDNTRA.inUDNTRA_okrjono
        pCmd.Parameters("inUDNTRA_invno").Value = S_UDNTRA.inUDNTRA_invno
        pCmd.Parameters("inUDNTRA_lincma").Value = S_UDNTRA.inUDNTRA_lincma
        pCmd.Parameters("inUDNTRA_lincmb").Value = S_UDNTRA.inUDNTRA_lincmb
        pCmd.Parameters("inUDNTRA_bnkcd").Value = S_UDNTRA.inUDNTRA_bnkcd
        pCmd.Parameters("inUDNTRA_bnknm").Value = S_UDNTRA.inUDNTRA_bnknm
        pCmd.Parameters("inUDNTRA_tegno").Value = S_UDNTRA.inUDNTRA_tegno
        pCmd.Parameters("inUDNTRA_tegdt").Value = S_UDNTRA.inUDNTRA_tegdt
        pCmd.Parameters("inUDNTRA_updid").Value = S_UDNTRA.inUDNTRA_updid
        pCmd.Parameters("inUDNTRA_dfldkbcd").Value = S_UDNTRA.inUDNTRA_dfldkbcd
        pCmd.Parameters("inUDNTRA_dkbzaifl").Value = S_UDNTRA.inUDNTRA_dkbzaifl
        pCmd.Parameters("inUDNTRA_dkbtegfl").Value = S_UDNTRA.inUDNTRA_dkbtegfl
        pCmd.Parameters("inUDNTRA_dkbfla").Value = S_UDNTRA.inUDNTRA_dkbfla
        pCmd.Parameters("inUDNTRA_dkbflb").Value = S_UDNTRA.inUDNTRA_dkbflb
        pCmd.Parameters("inUDNTRA_dkbflc").Value = S_UDNTRA.inUDNTRA_dkbflc
        pCmd.Parameters("inUDNTRA_lstid").Value = S_UDNTRA.inUDNTRA_lstid
        pCmd.Parameters("inUDNTRA_hinzeikb").Value = S_UDNTRA.inUDNTRA_hinzeikb
        pCmd.Parameters("inUDNTRA_hinmstkb").Value = S_UDNTRA.inUDNTRA_hinmstkb
        pCmd.Parameters("inUDNTRA_tokmstkb").Value = S_UDNTRA.inUDNTRA_tokmstkb
        pCmd.Parameters("inUDNTRA_nhsmstkb").Value = S_UDNTRA.inUDNTRA_nhsmstkb
        pCmd.Parameters("inUDNTRA_tanmstkb").Value = S_UDNTRA.inUDNTRA_tanmstkb
        pCmd.Parameters("inUDNTRA_zeirnkkb").Value = S_UDNTRA.inUDNTRA_zeirnkkb
        pCmd.Parameters("inUDNTRA_hinkb").Value = S_UDNTRA.inUDNTRA_hinkb
        pCmd.Parameters("inUDNTRA_zeirt").Value = S_UDNTRA.inUDNTRA_zeirt   'NUMBER
        pCmd.Parameters("inUDNTRA_zaikb").Value = S_UDNTRA.inUDNTRA_zaikb
        pCmd.Parameters("inUDNTRA_mrpkb").Value = S_UDNTRA.inUDNTRA_mrpkb
        pCmd.Parameters("inUDNTRA_hinjunkb").Value = S_UDNTRA.inUDNTRA_hinjunkb
        pCmd.Parameters("inUDNTRA_makcd").Value = S_UDNTRA.inUDNTRA_makcd
        pCmd.Parameters("inUDNTRA_hinsircd").Value = S_UDNTRA.inUDNTRA_hinsircd
        pCmd.Parameters("inUDNTRA_hinnmmkb").Value = S_UDNTRA.inUDNTRA_hinnmmkb
        pCmd.Parameters("inUDNTRA_hrtdd").Value = S_UDNTRA.inUDNTRA_hrtdd
        pCmd.Parameters("inUDNTRA_ortdd").Value = S_UDNTRA.inUDNTRA_ortdd
        pCmd.Parameters("inUDNTRA_znkurikn").Value = S_UDNTRA.inUDNTRA_znkurikn   'NUMBER
        pCmd.Parameters("inUDNTRA_zkmurikn").Value = S_UDNTRA.inUDNTRA_zkmurikn   'NUMBER
        pCmd.Parameters("inUDNTRA_zkmuzekn").Value = S_UDNTRA.inUDNTRA_zkmuzekn   'NUMBER
        pCmd.Parameters("inUDNTRA_motdatno").Value = S_UDNTRA.inUDNTRA_motdatno
        pCmd.Parameters("inUDNTRA_fopeid").Value = S_UDNTRA.inUDNTRA_fopeid
        pCmd.Parameters("inUDNTRA_fcltid").Value = S_UDNTRA.inUDNTRA_fcltid
        pCmd.Parameters("inUDNTRA_wrtfsttm").Value = S_UDNTRA.inUDNTRA_wrtfsttm
        pCmd.Parameters("inUDNTRA_wrtfstdt").Value = S_UDNTRA.inUDNTRA_wrtfstdt
        pCmd.Parameters("inUDNTRA_opeid").Value = S_UDNTRA.inUDNTRA_opeid
        pCmd.Parameters("inUDNTRA_cltid").Value = S_UDNTRA.inUDNTRA_cltid
        pCmd.Parameters("inUDNTRA_wrttm").Value = S_UDNTRA.inUDNTRA_wrttm
        pCmd.Parameters("inUDNTRA_wrtdt").Value = S_UDNTRA.inUDNTRA_wrtdt
        pCmd.Parameters("inUDNTRA_uopeid").Value = S_UDNTRA.inUDNTRA_uopeid
        pCmd.Parameters("inUDNTRA_ucltid").Value = S_UDNTRA.inUDNTRA_ucltid
        pCmd.Parameters("inUDNTRA_uwrttm").Value = S_UDNTRA.inUDNTRA_uwrttm
        pCmd.Parameters("inUDNTRA_uwrtdt").Value = S_UDNTRA.inUDNTRA_uwrtdt
        pCmd.Parameters("inUDNTRA_pgid").Value = S_UDNTRA.inUDNTRA_pgid
        pCmd.Parameters("inUDNTRA_dlflg").Value = S_UDNTRA.inUDNTRA_dlflg
    End Sub
    '2019/04/02 ADD E N D

    '2019/04/03 ADD START
    Private Sub SetPlsqlParamG_PlCnd(ByVal pCmd As OracleCommand)
        'G_PlCnd

        '定義
        Dim inoutJobMode As OracleParameter = New OracleParameter("inoutJobMode", OracleDbType.Int32, ParameterDirection.InputOutput)
        Dim inoutCndStr As OracleParameter = New OracleParameter("inoutCndStr", OracleDbType.Varchar2, ParameterDirection.InputOutput)
        Dim inoutCndNum As OracleParameter = New OracleParameter("inoutCndNum", OracleDbType.Decimal, ParameterDirection.InputOutput)
        Dim inOpeid As OracleParameter = New OracleParameter("inOpeid", OracleDbType.Char, ParameterDirection.Input)
        Dim inCltid As OracleParameter = New OracleParameter("inCltid", OracleDbType.Char, ParameterDirection.Input)
        Dim inoutErrMsg As OracleParameter = New OracleParameter("inoutErrMsg", OracleDbType.Varchar2, ParameterDirection.InputOutput)

        '型
        'inoutJobMode.OracleDbType = OracleDbType.Int32
        'inoutCndStr.OracleDbType = OracleDbType.Varchar2
        'inoutCndNum.OracleDbType = OracleDbType.Decimal
        'inOpeid.OracleDbType = OracleDbType.Char
        'inCltid.OracleDbType = OracleDbType.Char
        'inoutErrMsg.OracleDbType = OracleDbType.Varchar2

        ''IN/OUT
        'inoutJobMode.Direction = ParameterDirection.InputOutput
        'inoutCndStr.Direction = ParameterDirection.InputOutput
        'inoutCndNum.Direction = ParameterDirection.InputOutput
        'inOpeid.Direction = ParameterDirection.Input
        'inCltid.Direction = ParameterDirection.Input
        'inoutErrMsg.Direction = ParameterDirection.InputOutput

        '値
        inoutJobMode.Value = G_PlCnd.nJobMode

        'inoutCndStr.Value = G_PlCnd.sCndStr
        inoutCndStr.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inoutCndStr.Size = G_PlCnd.sCndStr.Length
        inoutCndStr.ArrayBindSize = New Integer(G_PlCnd.sCndStr.Length - 1) {}
        For i As Integer = 0 To G_PlCnd.sCndStr.Length - 1
            inoutCndStr.ArrayBindSize(i) = 513
        Next
        inoutCndStr.Value = G_PlCnd.sCndStr

        'inoutCndNum.Value = G_PlCnd.nCndNum
        inoutCndNum.CollectionType = OracleCollectionType.PLSQLAssociativeArray
        inoutCndNum.Size = G_PlCnd.nCndNum.Length
        inoutCndNum.ArrayBindSize = New Integer(G_PlCnd.nCndNum.Length - 1) {}
        For i As Integer = 0 To G_PlCnd.nCndNum.Length - 1
            inoutCndNum.ArrayBindSize(i) = 22
        Next
        inoutCndNum.Value = G_PlCnd.nCndNum

        inOpeid.Value = G_PlCnd.sOpeID
        inCltid.Value = G_PlCnd.sCltID
        inoutErrMsg.Value = ""

        'add parameters
        pCmd.Parameters.Add(inoutJobMode)
        pCmd.Parameters.Add(inoutCndStr)
        pCmd.Parameters.Add(inoutCndNum)
        pCmd.Parameters.Add(inOpeid)
        pCmd.Parameters.Add(inCltid)
        pCmd.Parameters.Add(inoutErrMsg)
    End Sub
    '2019/04/03 ADD E N D

    '
    ' スロット名        : 売上トラン・メインファイル更新スロット(PL/SQL対応)
    ' ユニット名        : UDNTRA.M21
    ' 記述者            : Standard Library
    ' 作成日付          : 1998/05/12
    ' 使用プログラム名  : URIET01
    '
    '20190731 CHG START
    'Function WRTTRN() As Short
    Function WRTTRN2() As Short
        '20190731 CHG END

        Dim I As Short
        Dim PlStat As Integer

        '2019/04/02 ADD START
        Dim sqlStr As String = ""
        '2019/04/02 ADD E N D

        FR_SSSMAIN.Enabled = False
        'ADD START FKS)INABA 2009/11/19 *********************
        '連絡票№758
        If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
            MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)

            '20190731 CHG START
            'WRTTRN = False
            WRTTRN2 = False
            '20190731 CHG END

            PlStat = DB_PlFree()
            FR_SSSMAIN.Enabled = True
            Exit Function
        Else
            Call SSSWIN_EXCTBZ_OPEN()
        End If
        'ADD  END  FKS)INABA 2009/11/19 *********************

        '2019/04/02 ADD START
        Dim cmd As New OracleCommand
        Try
            Call DB_BeginTrans(CON)

            cmd.Connection = CON
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "URIET51_PACK.M_UDNTRA"
            '2019/04/02 ADD E N D

            ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される

            If WG_DSPKB = 2 Then
                G_PlCnd.nJobMode = 0
            End If

            For I = 0 To MAX_CNDARR - 1
                '2019/04/02 ADD START
                ReDim Preserve G_PlCnd.sCndStr(I)
                ReDim Preserve G_PlCnd.nCndNum(I)
                '2019/04/02 ADD E N D
                G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
                G_PlCnd.nCndNum(I) = I + 1
            Next I

            G_PlCnd.sOpeID = SSS_OPEID.Value
            G_PlCnd.sCltID = SSS_CLTID.Value
            G_PlCnd.nCndNum(9) = -9999 'PL/SQLでコミットしない

            '20190731 DEL START
            'G_PlInfo.FCnt = 2
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.Fno(0)
            ''2019/04/02 ADD E N D
            'G_PlInfo.Fno(0) = DBN_UDNTRA
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.RCnt(0)
            ''2019/04/02 ADD E N D
            'G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.ArrayFlg(0)
            ''2019/04/02 ADD E N D
            'G_PlInfo.ArrayFlg(0) = 1
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.Fno(1)
            ''2019/04/02 ADD E N D
            'G_PlInfo.Fno(1) = DBN_UDNTHA
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.RCnt(1)
            ''2019/04/02 ADD E N D
            'G_PlInfo.RCnt(1) = 1
            ''2019/04/02 ADD START
            'ReDim Preserve G_PlInfo.ArrayFlg(1)
            ''2019/04/02 ADD E N D
            'G_PlInfo.ArrayFlg(1) = 0
            '20190731 DEL END

            '
            ' 売上基準
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            G_PlCnd.sCndStr(0) = RD_SSSMAIN_URIKJN(0)
            '最新受注情報のDATNO
            G_PlCnd.sCndStr(1) = WG_JDNDATNO
            '直送区分
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            G_PlCnd.sCndStr(2) = RD_SSSMAIN_ZKTKB(0)
            '受注取引区分
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            G_PlCnd.sCndStr(3) = RD_SSSMAIN_JDNTRKB(0)

            '20190731 DEL START
            'Call UDNTHA_RClear()
            '20190731 DEL END

            Call UDNTHA_FromSCR(-1)
            DB_UDNTHA.DATKB = "1"
            DB_UDNTHA.AKAKROKB = "1"
            DB_UDNTHA.DENKB = "1"
            DB_UDNTHA.UDNPRAKB = "9"
            DB_UDNTHA.UDNPRBKB = "9"
            DB_UDNTHA.SMADT = SSS_SMADT.Value
            DB_UDNTHA.SSADT = SSS_SSADT.Value
            DB_UDNTHA.KESDT = SSS_KESDT.Value

            ' 緊急出荷基準
            ''''If FR_SSSMAIN.CHECK_EMGODNKB.Value = 0 Then
            ''''    DB_UDNTHA.EMGODNKB = "0"
            ''''Else
            ''''    DB_UDNTHA.EMGODNKB = "1"
            ''''End If
            DB_UDNTHA.EMGODNKB = "0"

            '
            PlStat = DB_PlStart()
            '2019/04/02 DEL START
            'PlStat = DB_PlCndSet()
            'PlStat = DB_PlSet(DBN_UDNTHA, 0)
            '2019/04/02 DEL E N D
            I = 0
            '2019/04/03 ADD START
            S_UDNTRA = Nothing
            '2019/04/03 ADD E N D
            Do While I < PP_SSSMAIN.LastDe
                '20190731 DEL START
                'Call UDNTRA_RClear()
                '20190731 DEL END

                Call Mfil_FromSCR(I)
                DB_UDNTRA.DATKB = "1"
                DB_UDNTRA.AKAKROKB = "1"
                DB_UDNTRA.DENKB = "1"
                DB_UDNTRA.SMADT = SSS_SMADT.Value
                DB_UDNTRA.SSADT = SSS_SSADT.Value
                DB_UDNTRA.KESDT = SSS_KESDT.Value
                DB_UDNTRA.DKBSB = WG_DKBSB
                DB_UDNTRA.LINNO = VB6.Format(I + 1, "000")

                ' 緊急出荷基準
                ''''''''If FR_SSSMAIN.CHECK_EMGODNKB.Value = 0 Then
                ''''''''    DB_UDNTRA.EMGODNKB = "0"
                ''''''''Else
                ''''''''    DB_UDNTRA.EMGODNKB = "1"
                ''''''''End If
                DB_UDNTRA.EMGODNKB = "0"

                '2019/04/03 DEL START
                'PlStat = DB_PlSet(DBN_UDNTRA, I)
                '2019/04/03 DEL E N D

                '2019/04/03 ADD START
                Call SetArrayUDNTRA(I, DB_UDNTRA)
                '2019/04/03 ADD E N D

                I = I + 1
            Loop

            '2019/04/03 ADD START
            Call SetPlsqlParamG_PlCnd(cmd)  '引数の順番通り渡す
            Call SetPlsqlParamUDNTRA(cmd)  '引数の順番通り渡す
            Call SetPlsqlParamUDNTHA(cmd, DB_UDNTHA)  '引数の順番通り渡す
            '2019/04/03 ADD E N D

            '2019/04/02 DEL START
            'Call DB_BeginTransaction(CStr(BTR_Exclude))
            '2019/04/02 DEL E N D

            '2019/04/02 CHG START
            'PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
            cmd.ExecuteNonQuery()
            '2019/04/02 CHG E N D

            '2019/04/10 ADD START
            PlStat = 0
            '2019/04/10 ADD E N D

            '2019/04/02 ADD START
        Catch ex As Exception
            Debug.Print("ex.Message:" & ex.Message)
            MsgBox(ex.Message)

            '2019/04/10 ADD START
            PlStat = 1
            '2019/04/10 ADD E N D

            'Throw ex
        Finally
            Debug.Print("inoutJobMode:" & cmd.Parameters("inoutJobMode").Value.ToString())
            Debug.Print("inoutCndStr:" & cmd.Parameters("inoutCndStr").Value.ToString())
            Debug.Print("inoutCndNum:" & cmd.Parameters("inoutCndNum").Value.ToString())
            Debug.Print("inoutErrMsg:" & cmd.Parameters("inoutErrMsg").Value.ToString())
        End Try
        '2019/04/02 ADD E N D

        '2019/04/10 ADD START
        Try
            If cmd.Parameters("inoutCndStr").Value IsNot Nothing Then
                For cnt As Integer = 0 To cmd.Parameters("inoutCndStr").Value.length - 1
                    ReDim Preserve G_PlCnd2.sCndStr(cnt)
                    G_PlCnd2.sCndStr(cnt) = cmd.Parameters("inoutCndStr").Value(cnt).ToString
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If G_PlCnd2.sCndStr Is Nothing Then
            ReDim Preserve G_PlCnd2.sCndStr(2)
        End If
        '2019/04/10 ADD E N D

        '2019/04/10 CHG START
        'If PlStat <> 0 And PlStat <> 1485 Then
        If PlStat <> 0 Then
            Debug.Print(cmd.Parameters("inoutCndStr").Value.length)
            '2019/04/10 CHG E N D

            '2019/04/10 DEL START
            'MsgBox("PL/SQL Error：" & PlStat)
            '2019/04/10 DEL E N D

            '20190731 CHG START
            'WRTTRN = False
            WRTTRN2 = False
            '20190731 CHG END

            '2019/04/09 CHG START
            'DB_AbortTransaction()
            Call DB_Rollback()
            '2019/04/09 CHG E N D
        ElseIf Trim(G_PlCnd2.sCndStr(2)) <> "" Then
            '2019/04/09 DEL START
            'MsgBox(ErrorToString())
            '2019/04/09 DEL E N D

            '20190731 CHG START
            'WRTTRN = False
            WRTTRN2 = False
            '20190731 CHG END

            '2019/04/09 CHG START
            'DB_AbortTransaction()
            Call DB_Rollback()
            '2019/04/09 CHG E N D
        Else
            '20190731 CHG START
            'WRTTRN = True
            WRTTRN2 = False
            '20190731 CHG END

            '2019/04/02 CHG START
            'Call DB_EndTransaction()
            Call DB_Commit()
            '2019/04/02 CHG E N D
            '1998/05/12  １行追加
            Call DP_SSSMAIN_UDNNO(-1, G_PlCnd2.sCndStr(1))
            ' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の解除
            Call SSSWIN_Unlock_EXCTBZ()
            ' === 20130416 === INSERT E -
        End If
        PlStat = DB_PlFree()

        'シリアル№登録ワークの削除
        '2019/04/02 CHG START
        'Call DB_BeginTransaction(CStr(BTR_Exclude))
        Call DB_BeginTrans(CON)
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Call DB_GetGrEq(DBN_USRET51, 3, SSS_CLTID.Value, BtrNormal)
        sqlStr = ""
        sqlStr &= " SELECT "
        sqlStr &= "  * "
        sqlStr &= " FROM CNT_USR9.USRET51 "
        sqlStr &= " WHERE RPTCLTID = '" & SSS_CLTID.Value & "'"

        Dim dtUSRET51 As DataTable = DB_GetTable(sqlStr)
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Do While (DBSTAT = 0) And (Trim(DB_USRET51.RPTCLTID) = Trim(SSS_CLTID.Value))
        '	Call DB_Delete(DBN_USRET51)
        '	Call DB_GetNext(DBN_USRET51, BtrNormal)
        'Loop
        For Each row As DataRow In dtUSRET51.Rows
            sqlStr = ""
            sqlStr &= " DELETE "
            sqlStr &= " FROM CNT_USR9.USRET51 "
            sqlStr &= " WHERE RPTCLTID = '" & row("RPTCLTID") & "'"

            Call DB_Execute(sqlStr)
        Next
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Call DB_EndTransaction()
        Call DB_Commit()
        '2019/04/02 CHG E N D

        FR_SSSMAIN.Enabled = True
    End Function

    '20190731 DEL START
    'Function DELTRN() As Short

    '    'Dim PlStat As Long
    '    'Dim I%
    '    '
    '    '     PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
    '    '    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete以外
    '    '    FR_SSSMAIN.Enabled = False
    '    '
    '    '    For I = 0 To MAX_CNDARR - 1
    '    '        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
    '    '        G_PlCnd.nCndNum(I) = I + 1
    '    '    Next I
    '    '
    '    '    G_PlCnd.sOpeID = SSS_OPEID
    '    '    G_PlCnd.sCltID = SSS_CLTID
    '    '
    '    '    G_PlInfo.FCnt = 2
    '    '    G_PlInfo.Fno(0) = DBN_UDNTRA
    '    '    G_PlInfo.RCnt(0) = 1
    '    '    G_PlInfo.ArrayFlg(0) = 1
    '    '    G_PlInfo.Fno(1) = DBN_UDNTHA
    '    '    G_PlInfo.RCnt(1) = 1
    '    '    G_PlInfo.ArrayFlg(1) = 0
    '    '
    '    '    DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(-1)
    '    '
    '    '    PlStat = DB_PlStart
    '    '    PlStat = DB_PlCndSet
    '    '    PlStat = DB_PlSet(DBN_UDNTHA, 0)
    '    '    PlStat = DB_PlSet(DBN_UDNTRA, 0)
    '    '
    '    '    Call DB_BeginTransaction(BTR_Exclude)
    '    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    '    If PlStat <> 0 And PlStat <> 1485 Then
    '    '        MsgBox "PL/SQL Error：" & PlStat
    '    '        DELTRN = False
    '    '        DB_AbortTransaction
    '    '    Else
    '    '        DELTRN = True
    '    '        Call DB_EndTransaction
    '    '    End If
    '    '
    '    '    PlStat = DB_PlFree
    '    '
    '    '    FR_SSSMAIN.Enabled = True
    'End Function
    '20190731 DEL END

End Module